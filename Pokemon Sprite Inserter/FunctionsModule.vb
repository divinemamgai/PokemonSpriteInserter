Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing

Public Class PaletteBox
    Inherits PictureBox

    Protected Overrides Sub OnPaint(ByVal pe As PaintEventArgs)
        ControlPaint.DrawBorder(pe.Graphics, pe.ClipRectangle,
                                Color.Black, 1, ButtonBorderStyle.Solid,
                                Color.Black, 1, ButtonBorderStyle.Solid,
                                Color.Black, 1, ButtonBorderStyle.Solid,
                                Color.Black, 1, ButtonBorderStyle.Solid)
        If PaletteBoxIndexDisplayFlag = True Then
            Dim IndexRectangle As Rectangle = pe.ClipRectangle
            IndexRectangle.Location = New Point(1, 1)
            Dim IndexFormat As StringFormat = New StringFormat
            IndexFormat.LineAlignment = StringAlignment.Center
            IndexFormat.Alignment = StringAlignment.Near
            ControlPaint.DrawStringDisabled(pe.Graphics, ToHex(Me.Tag, 2),
                                            New Font("Arial", 10, FontStyle.Bold),
                                            Color.Black, IndexRectangle,
                                            IndexFormat)
        End If
        MyBase.OnPaint(pe)
    End Sub

End Class

Public Structure PaletteData
    Dim PaletteIndex As Integer
    Dim PaletteOffset As String
    Dim PaletteNumber As Integer
    Dim PaletteDataOffset As String
    Dim PaletteHexData As String
End Structure

Module FunctionsModule

    Public ProgramDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\Pokemon Sprite Inserter"
    Public SettingsFilePath As String = ProgramDataPath + "\settings.bin"
    Public UpdateFilePath As String = ProgramDataPath + "\CURRENT.VER"
    Public UpdateRequest As String = "https://raw.githubusercontent.com/divinemamgai/PokemonSpriteInserter/master/CURRENT.VER"
    Public UpdateURL As String = "https://github.com/divinemamgai/PokemonSpriteInserter/raw/master/Pokemon%20Sprite%20Inserter-SetupFiles/Pokemon%20Sprite%20Inserter.exe"
    Dim CurrentVersions() As String

    Public PaletteBoxIndexDisplayFlag As Boolean = True
    Dim RomIdentifierOffset As String = "0000A0"
    Dim RomIdentifierHexValue As String = "504F4B454D4F4E204649524542505245"
    Dim RomIdentifierBytes As Integer = 16
    Dim MaxHexSize As Integer = 65536 ' 0xFFFF + 0x1 in Decimal

    Enum ExtendTo
        Right = 1
        Left = 2
    End Enum

    Public Function ProcessUpdateFile() As Boolean
        Dim NewVersionFlag As Boolean = False
        Dim CurrentVersion As String = My.Computer.FileSystem.ReadAllText(UpdateFilePath, System.Text.Encoding.ASCII)
        If String.Compare(CurrentVersion, Application.ProductVersion) <> 0 Then
            CurrentVersions = CurrentVersion.Split(New [Char]() {"."c})
            Dim ExistVersions() As String = Application.ProductVersion.Split(New [Char]() {"."c})
            If CurrentVersions(0) > ExistVersions(0) Then
                NewVersionFlag = True
            Else
                If CurrentVersions(1) > ExistVersions(1) Then
                    NewVersionFlag = True
                Else
                    If CurrentVersions(2) > ExistVersions(2) Then
                        NewVersionFlag = True
                    Else
                        NewVersionFlag = False
                    End If
                End If
            End If
        End If
        Return NewVersionFlag
    End Function

    Public Sub CheckForUpdate()
        If File.Exists(UpdateFilePath) = True Then
            If ProcessUpdateFile() = True Then
                Dim Result As Integer = MessageBox.Show("A new update is available for Pokemon Sprite Inserter!" & vbCrLf & vbCrLf & "Current Version - " + Application.ProductVersion & vbCrLf & "New Version - " + CurrentVersions(0) + "." + CurrentVersions(1) + "." + CurrentVersions(2) + "" & vbCrLf & vbCrLf & "Do you want to download the latest build now?", "New Update To " + CurrentVersions(0), MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If Result = DialogResult.Yes Then
                    Process.Start(UpdateURL)
                End If
                Return
            Else
                File.Delete(UpdateFilePath)
            End If
        End If
        Try
            My.Computer.Network.DownloadFile(UpdateRequest, UpdateFilePath, False, 500)
            If File.Exists(UpdateFilePath) = True Then
                If ProcessUpdateFile() = True Then
                    Dim Result As Integer = MessageBox.Show("A new update is available for Pokemon Sprite Inserter!" & vbCrLf & vbCrLf & "Current Version - " + Application.ProductVersion & vbCrLf & "New Version - " + CurrentVersions(0) + "." + CurrentVersions(1) + "." + CurrentVersions(2) + "" & vbCrLf & vbCrLf & "Do you want to download the latest build now?", "New Update To " + CurrentVersions(0), MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                    If Result = DialogResult.Yes Then
                        Process.Start(UpdateURL)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Update Check Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function ExtendString(ByVal Input As String, ByVal ExtendChar As String, ByVal Length As Integer, Optional ByVal ExtendToType As Integer = ExtendTo.Left) As String
        Dim Result As String = ""
        If Input.Length >= Length Then
            Return Input
        Else
            If ExtendToType = ExtendTo.Right Then
                Result += Input
            End If
            For Count As Integer = 1 To Length - Input.Length
                Result += ExtendChar
            Next
            If ExtendToType = ExtendTo.Left Then
                Result += Input
            End If
            Return Result
        End If
    End Function

    Public Function ToDecimal(ByVal HexValue As String) As Integer
        ToDecimal = Convert.ToInt32(HexValue, 16)
    End Function

    Public Function ToHex(ByVal DecimalValue As Integer, Optional ByVal DesiredLength As Integer = 0, Optional ByVal DesiredChar As String = "0") As String
        Dim Result As String = Hex(DecimalValue)
        If DesiredLength <> 0 Then
            Result = ExtendString(Result, DesiredChar, DesiredLength)
        End If
        Return Result
    End Function

    Public Function OffsetToPointer(ByVal Offset As String, Optional ByVal SafeMode As Boolean = True) As String
        Dim Pointer As String = ""
        Dim ExtendedOffset As String = ""
        If SafeMode = True Then
            If Offset.Length <= 6 Then
                ExtendedOffset = ExtendString(Offset, "0", 6)
            Else
                Return Nothing
            End If
        Else
            ExtendedOffset = ExtendString(Offset, "0", 8)
        End If
        For Count As Integer = ExtendedOffset.Length - 1 To 0 Step -2
            Pointer += ExtendedOffset(Count - 1) & ExtendedOffset(Count)
        Next
        Pointer += "08"
        Return Pointer
    End Function

    Public Function PointerToOffset(ByVal Pointer As String) As String
        Dim Offset As String = Nothing
        If IsNothing(Pointer) = False Then
            Pointer = Pointer.Substring(0, Pointer.Length - 2)
            For Count As Integer = Pointer.Length - 1 To 0 Step -2
                Offset += Pointer(Count - 1) & Pointer(Count)
            Next
        Else
            Return Nothing
        End If
        Return Offset
    End Function

    Public Function ValidateRom() As Boolean
        If Not String.Compare(ReadData(RomIdentifierOffset, RomIdentifierBytes), RomIdentifierHexValue) Then
            ValidateRom = True
        Else
            ValidateRom = False
        End If
    End Function

    Public Function ReadData(ByVal FromOffset As String, ByVal NumberOfBytes As Integer) As String
        Dim Data As String = ""
        Dim Buffer(NumberOfBytes - 1) As Byte
        Dim RomFileReadStream As FileStream
        RomFileReadStream = File.OpenRead(Main.RomFilePath)
        RomFileReadStream.Seek(ToDecimal(FromOffset), SeekOrigin.Begin)
        RomFileReadStream.Read(Buffer, 0, NumberOfBytes)
        For x As Integer = 0 To Buffer.Length - 1
            Data += Buffer(x).ToString("X2")
        Next
        RomFileReadStream.Close()
        ReadData = Data
    End Function

    Public Function WriteData(ByVal AtOffset As String,
                              ByVal NumberOfBytes As Integer,
                              ByVal Data As String,
                              Optional ByVal Type As Integer = 0) As Boolean
        Dim RomFileWriteStream As FileStream
WriteDataTry:
        Try
            RomFileWriteStream = File.OpenWrite(Main.RomFilePath)
            Dim WriteBuffer As Byte()
            WriteBuffer = New Byte(NumberOfBytes - 1) {}
            Dim i As Integer = 0
            Dim k As Integer = 0
            While i < NumberOfBytes
                If Type = 0 Then
                    WriteBuffer(i) = Convert.ToByte((Data(k) & Data(k + 1)), 16)
                    k = k + 2
                Else
                    WriteBuffer(i) = Convert.ToByte(Data, 16)
                End If
                i = i + 1
            End While
            RomFileWriteStream.Seek(ToDecimal(AtOffset), SeekOrigin.Begin)
            RomFileWriteStream.Write(WriteBuffer, 0, NumberOfBytes)
            RomFileWriteStream.Close()
            Return True
        Catch ex As Exception
            Main.Log.Text += vbCrLf & "Rom File Is In Use! Prompting User To Try Again..."
            Dim DialogBoxResult As Integer = MessageBox.Show("The Rom File Is In Use. Please Close Any Program Using The File And Click Retry To Try Again." & vbCrLf & "[Exception.Message : " + ex.Message + "]", "Error!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation)
            If DialogBoxResult = DialogResult.Retry Then
                Main.Log.Text += vbCrLf & "Trying Again To Write Data..."
                GoTo WriteDataTry
            Else
                Main.Log.Text += vbCrLf & "Error! Aborted By User."
                Main.BackButton.Enabled = True
            End If
        End Try
        Return False
    End Function

    Public Function SearchFreeSpace(ByVal FromOffset As Integer, ByVal NumberOfBytes As Integer, ByVal FreeSpaceString As String) As String
        Dim FreeSpaceByte As Byte = Convert.ToByte(FreeSpaceString, 16)
        Using RomFileBinaryReader As New BinaryReader(File.Open(Main.RomFilePath, FileMode.Open, FileAccess.Read, FileShare.Read), Encoding.ASCII)
            Dim Buffer(MaxHexSize - 1) As Byte
            Dim MaxLoop As Integer = CInt(RomFileBinaryReader.BaseStream.Length) / MaxHexSize
            Dim MaxBuffer As Integer = 0
            Dim Match As Boolean = False
            RomFileBinaryReader.BaseStream.Position = FromOffset
            For i As Integer = 0 To MaxLoop - 1
                Buffer = RomFileBinaryReader.ReadBytes(MaxHexSize)
                If Buffer.Length < NumberOfBytes Then
                    Return "Null"
                End If
                MaxBuffer = If(Buffer.Length > NumberOfBytes, (Buffer.Length - NumberOfBytes), 1)
                Dim j As Integer = 0
                While j < MaxBuffer
                    If Buffer(j + (NumberOfBytes - 1)) = FreeSpaceByte Then
                        If Buffer(j) = FreeSpaceByte Then
                            Match = True
                            Dim k As Integer = j + (NumberOfBytes - 2)
                            While k > j
                                If Buffer(k) <> FreeSpaceByte Then
                                    Match = False
                                    Exit While
                                End If
                                k = k - 1
                            End While
                            If Match Then
                                Return ToHex(FromOffset + j + (MaxHexSize * i))
                            End If
                        End If
                    End If
                    j += NumberOfBytes
                End While
            Next
        End Using
        Return "Null"
    End Function

    Public Function GetPalettes(ByVal PaletteTableOffset As String, ByVal PaletteTableEndHex As String, ByVal MaxPalette As Integer, Optional ByVal Warning As Boolean = True) As PaletteData()
        Dim PaletteDataArray As PaletteData() = Nothing
        Dim PaletteDataCount As Integer = 0
        Dim PaletteDataEndFlag As Boolean = False
        Dim PaletteTableDataSize As Integer = 8
        Dim PaletteDataSize As Integer = 32
        Dim CurrentOffset As Integer = ToDecimal(PaletteTableOffset)
        Dim CurrentPaletteData As String = Nothing
        While PaletteDataEndFlag = False
            CurrentPaletteData = ReadData(ToHex(CurrentOffset), PaletteTableDataSize)
            If CurrentPaletteData <> "" Then
                If String.Compare(CurrentPaletteData, PaletteTableEndHex) = 0 Then
                    PaletteDataEndFlag = True
                    Exit While
                Else
                    If PaletteDataCount = MaxPalette Then
                        If Warning = True Then
                            MessageBox.Show("It seems like you have more palettes in your table than the program let's you process! Program will be ignoring the rest." & vbCrLf & vbCrLf & "To increase this limit just head over to the settings and increase the value of Max Palettes.", "Palette Limit Breach!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                        PaletteDataEndFlag = True
                        Exit While
                    Else
                        ReDim Preserve PaletteDataArray(PaletteDataCount)
                        PaletteDataArray(PaletteDataCount).PaletteIndex = PaletteDataCount + 1
                        PaletteDataArray(PaletteDataCount).PaletteOffset = ToHex(CurrentOffset)
                        PaletteDataArray(PaletteDataCount).PaletteNumber = ToDecimal(CurrentPaletteData.Substring(8, 2))
                        PaletteDataArray(PaletteDataCount).PaletteDataOffset = PointerToOffset(CurrentPaletteData.Substring(0, 8))
                        PaletteDataArray(PaletteDataCount).PaletteHexData = ReadData(PaletteDataArray(PaletteDataCount).PaletteDataOffset, PaletteDataSize)
                        PaletteDataCount = PaletteDataCount + 1
                        CurrentOffset = CurrentOffset + PaletteTableDataSize
                    End If
                End If
            End If
        End While
        Return PaletteDataArray
    End Function

    Public Function CheckPaletteNumberAvailability(ByVal PaletteNumber As Integer, ByVal PaletteTableOffset As String, ByVal PaletteTableEndHex As String, ByVal MaxPalette As Integer)
        For Each PaletteData In GetPalettes(PaletteTableOffset, PaletteTableEndHex, MaxPalette, False)
            If PaletteData.PaletteNumber = PaletteNumber Then
                Return False
            End If
        Next
        Return True
    End Function

#Region "Validators"

    Public ZeroOffsetCheck As Boolean = False
    Public MaxLimit As Integer = 255

    Public Sub SetZeroOffsetCheckTrue(sender As Object, e As EventArgs)
        ZeroOffsetCheck = True
    End Sub

    Public Sub SetMaxLimitBytes(sender As Object, e As EventArgs)
        If Main.RomFileLoaded = True Then
            MaxLimit = Main.RomLength / 2
        End If
    End Sub

    Public Sub SetMaxLimitDefault(sender As Object, e As EventArgs)
        MaxLimit = 255
    End Sub

    Public Sub DigitValidator(sender As Object, e As KeyPressEventArgs)
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If
    End Sub

    Public Sub SpaceValidator(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) = Keys.Space Then
            e.Handled = True
        End If
    End Sub

    Public Sub HexInputValidator(sender As Object, e As KeyPressEventArgs)
        'MsgBox(Microsoft.VisualBasic.Asc(e.KeyChar), , "Debug")
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 3) Then
            e.Handled = False
        ElseIf (Microsoft.VisualBasic.Asc(e.KeyChar) = 26) Then
            e.Handled = False
        ElseIf (Microsoft.VisualBasic.Asc(e.KeyChar) = 22) Then
            If Not System.Text.RegularExpressions.Regex.IsMatch(Clipboard.GetText(), "\A\b[0-9a-fA-F]+\b\Z") Then
                e.Handled = True
                MessageBox.Show("Enter a valid hexadecimal offset value!", "Hex Value - Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                e.Handled = False
            End If
        Else
            If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
                e.Handled = False
            Else
                If ((Microsoft.VisualBasic.Asc(e.KeyChar) < 48) Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57)) _
                    And ((Microsoft.VisualBasic.Asc(e.KeyChar) < 65) Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 70)) _
                    And ((Microsoft.VisualBasic.Asc(e.KeyChar) < 97) Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 102)) Then
                    e.Handled = True
                End If
            End If
        End If
    End Sub

    Public Sub NonZeroValidator(sender As Object, e As EventArgs)
        Dim TextBoxItem As TextBox = CType(sender, TextBox)
        If TextBoxItem.Text <> "" Then
            Dim TextBoxValue = Integer.Parse(TextBoxItem.Text)
            If TextBoxValue = 0 Then
                TextBoxItem.Text = TextBoxItem.Tag
                MessageBox.Show("Value cannot be zero!", "Zero Value - Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Public Sub NullValidator(sender As Object, e As EventArgs)
        Dim TextBoxItem As TextBox = CType(sender, TextBox)
        If TextBoxItem.Text = "" Then
            TextBoxItem.Text = TextBoxItem.Tag
            MessageBox.Show("Value cannot be empty!", "Null Value - Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Public Sub OffsetValidator(sender As Object, e As EventArgs)
        Dim TextBoxItem As TextBox = CType(sender, TextBox)
        If TextBoxItem.Text <> "" Then
            If TextBoxItem.Text.Length <> 6 Then
                TextBoxItem.Text = TextBoxItem.Tag
                MessageBox.Show("Offset value should be of 6 characters.", "Offset - Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                If Not System.Text.RegularExpressions.Regex.IsMatch(TextBoxItem.Text, "\A\b[0-9a-fA-F]+\b\Z") Then
                    TextBoxItem.Text = TextBoxItem.Tag
                    MessageBox.Show("Enter a valid hexadecimal offset value!", "Offset - Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    If ZeroOffsetCheck = True Then
                        If ToDecimal(TextBoxItem.Text) = 0 Then
                            TextBoxItem.Text = TextBoxItem.Tag
                            MessageBox.Show("Offset cannot be zero!", "Offset - Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                End If
            End If
        End If
        ZeroOffsetCheck = False
    End Sub

    Public Sub HexValueValidator(sender As Object, e As EventArgs)
        Dim TextBoxItem As TextBox = CType(sender, TextBox)
        If TextBoxItem.Text <> "" Then
            If TextBoxItem.Text.Length <> TextBoxItem.MaxLength Then
                TextBoxItem.Text = TextBoxItem.Tag
                MessageBox.Show("Value can only be of " + CStr(TextBoxItem.MaxLength) + " characters.", "Hex Value - Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                If Not System.Text.RegularExpressions.Regex.IsMatch(TextBoxItem.Text, "\A\b[0-9a-fA-F]+\b\Z") Then
                    TextBoxItem.Text = TextBoxItem.Tag
                    MessageBox.Show("Enter a valid hexadecimal value!", "Hex Value - Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub

    Public Sub MaxLimitValidator(sender As Object, e As EventArgs)
        Dim TextBoxItem As TextBox = CType(sender, TextBox)
        If TextBoxItem.Text <> "" Then
            Try
                Dim TextBoxValue = Integer.Parse(TextBoxItem.Text.Replace(" ", ""))
                If TextBoxValue > MaxLimit Then
                    TextBoxItem.Text = TextBoxItem.Tag
                    MessageBox.Show("Max Limit is " + CStr(MaxLimit) + "!", "Max Limit - Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MsgBox(ex.Message, , "Error")
            End Try
        End If
    End Sub

    Public Sub PaletteDataValidator(sender As Object, e As EventArgs)
        Dim TextBoxItem As TextBox = CType(sender, TextBox)
        If TextBoxItem.Text <> "" Then
            If TextBoxItem.Text.Length <> 64 Then
                TextBoxItem.Text = TextBoxItem.Tag
                MessageBox.Show("Palette Hex Data can only be of 64 characters.", "Palette Data - Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                If Not System.Text.RegularExpressions.Regex.IsMatch(TextBoxItem.Text, "\A\b[0-9a-fA-F]+\b\Z") Then
                    TextBoxItem.Text = TextBoxItem.Tag
                    MessageBox.Show("Enter a valid hexadecimal palette hex data value!", "Palette Data - Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub

    Public Sub ByteValidator(sender As Object, e As EventArgs)
        Dim TextBoxItem As TextBox = CType(sender, TextBox)
        If TextBoxItem.Text <> "" Then
            If TextBoxItem.Text.Length <> 2 Then
                TextBoxItem.Text = TextBoxItem.Tag
                MessageBox.Show("Byte value can only be of 2 characters!", "Byte Value - Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                If Not System.Text.RegularExpressions.Regex.IsMatch(TextBoxItem.Text, "\A\b[0-9a-fA-F]+\b\Z") Then
                    TextBoxItem.Text = TextBoxItem.Tag
                    MessageBox.Show("Enter a valid hexadecimal byte value!", "Byte Value - Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub

#End Region

End Module