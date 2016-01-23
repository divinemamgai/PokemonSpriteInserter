Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Text.RegularExpressions

Public Class PaletteBox
    Inherits PictureBox

    Protected Overrides Sub OnPaint(ByVal pe As PaintEventArgs)
        ControlPaint.DrawBorder(pe.Graphics, MyBase.DisplayRectangle,
                                Color.Black, 1, ButtonBorderStyle.Solid,
                                Color.Black, 1, ButtonBorderStyle.Solid,
                                Color.Black, 1, ButtonBorderStyle.Solid,
                                Color.Black, 1, ButtonBorderStyle.Solid)
        If PaletteBoxIndexDisplayFlag = True Then
            Dim IndexRectangle As Rectangle = MyBase.DisplayRectangle
            IndexRectangle.Location = New Point(MyBase.DisplayRectangle.Width - 20, 3)
            Dim IndexFormat As StringFormat = New StringFormat
            IndexFormat.LineAlignment = StringAlignment.Center
            IndexFormat.Alignment = StringAlignment.Near
            ControlPaint.DrawStringDisabled(pe.Graphics, ToHex(Me.Tag, 2),
                                            New Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold, GraphicsUnit.Pixel),
                                            Color.Black, IndexRectangle,
                                            IndexFormat)
        End If
        MyBase.OnPaint(pe)
    End Sub

End Class

Public Class SpritePanel
    Inherits Panel

    Protected Overrides Sub OnPaint(ByVal pe As PaintEventArgs)
        ControlPaint.DrawBorder(pe.Graphics, MyBase.ClientRectangle,
                                Color.Black, 2, ButtonBorderStyle.Solid,
                                Color.Black, 2, ButtonBorderStyle.Solid,
                                Color.Black, 2, ButtonBorderStyle.Solid,
                                Color.Black, 2, ButtonBorderStyle.Solid)
        MyBase.OnPaint(pe)
    End Sub

    Protected Overrides Sub OnResize(eventargs As EventArgs)
        Invalidate()
        MyBase.OnResize(eventargs)
    End Sub

End Class

Public Class TablePanel
    Inherits Panel


End Class

Public Structure Preset
    Dim PresetName As String
    Dim StarterByte As String
    Dim UnknownFunction1 As String
    Dim Unknown1 As String
    Dim PalRegisters As String
    Dim Pointer1 As String
    Dim Pointer2 As String
    Dim AnimPointer As String
    Dim Pointer4 As String
End Structure

Public Structure PaletteData
    Dim PaletteIndex As Integer
    Dim PaletteOffset As String
    Dim PaletteNumber As Integer
    Dim PaletteDataOffset As String
    Dim PaletteHexData As String
End Structure

Public Structure SpriteData
    Dim SpriteIndex As Integer
    Dim SpriteTableOffset As String
    Dim SpriteHeaderOffset As String
    Dim SpritePalette As Integer
    Dim SpriteSize As Size
    Dim SpriteFrameSize As Integer
    Dim SpriteFrameDataOffset As String
    Dim SpriteFrameCount As Integer
    Dim SpriteArtDataOffset As String
    Dim SpritePreset As Preset
    Dim SpriteValid As Boolean
End Structure

Public Structure SpriteTable
    Dim SpriteTableNumber As Integer
    Dim SpriteTableOffset As String
    Dim SpriteTableSpriteCount As Integer
    Dim SpriteTableSpriteArray As SpriteData()
End Structure

Module FunctionsModule

    Public ProgramDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\Pokemon Sprite Inserter"
    Public SettingsFilePath As String = ProgramDataPath + "\settings.bin"
    Public UpdateFilePath As String = ProgramDataPath + "\CURRENT.VER"
    Public UpdateRequest As String = "https://raw.githubusercontent.com/divyamamgai/PokemonSpriteInserter/master/CURRENT.VER"
    Public UpdateURL As String = "https://github.com/divyamamgai/PokemonSpriteInserter/raw/master/Pokemon%20Sprite%20Inserter-SetupFiles/Pokemon%20Sprite%20Inserter.exe"
    Dim CurrentVersions() As String

    Public Function ProcessUpdateFile() As Boolean
        Dim NewVersionFlag As Boolean = False
        Dim CurrentVersion As String = My.Computer.FileSystem.ReadAllText(UpdateFilePath, System.Text.Encoding.ASCII)
        If CurrentVersion <> "" Then
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
            Else
                MessageBox.Show("You have the latest version of Pokemon Sprite Inserter installed." & vbCrLf & "Have fun hacking the Pokemon Roms!", "Latest Version Found!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        Return NewVersionFlag
    End Function

    Public Sub CheckForUpdate(Optional ByRef CheckForUpdateButton As Button = Nothing)
        If IsNothing(CheckForUpdateButton) = False Then
            CheckForUpdateButton.Enabled = False
        End If
        Try
            If File.Exists(UpdateFilePath) = True Then
                File.Delete(UpdateFilePath)
            End If
            My.Computer.Network.DownloadFile(UpdateRequest, UpdateFilePath, False, 500)
            If File.Exists(UpdateFilePath) = True Then
                If ProcessUpdateFile() = True Then
                    Dim Result As Integer = MessageBox.Show("A new update is available for Pokemon Sprite Inserter!" & vbCrLf & vbCrLf & "Current Version - " + Application.ProductVersion & vbCrLf & "New Version - " + CurrentVersions(0) + "." + CurrentVersions(1) + "." + CurrentVersions(2) + "" & vbCrLf & vbCrLf & "Do you want to download the latest build now?", "New Update To " + CurrentVersions(0) + "." + CurrentVersions(1) + "." + CurrentVersions(2), MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                    If Result = DialogResult.Yes Then
                        Process.Start(UpdateURL)
                    End If
                End If
                File.Delete(UpdateFilePath)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Update Check Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        If IsNothing(CheckForUpdateButton) = False Then
            CheckForUpdateButton.Enabled = True
        End If
    End Sub

    Public PaletteBoxIndexDisplayFlag As Boolean = True
    Dim RomIdentifierOffset As String = "0000A0"
    Dim RomIdentifierHexValue As String = "504F4B454D4F4E204649524542505245"
    Dim RomIdentifierBytes As Integer = 16
    Dim MaxHexSize As Integer = 65536 ' 0xFFFF + 0x1 in Decimal

    Enum ExtendTo
        Right = 1
        Left = 2
    End Enum

    Enum ImportType
        OnlySprite
        OnlyPalette
        BothSpriteAndPalette
    End Enum

    Public Function SplitString(ByVal Input As String, ByVal Fraction As Integer) As String()
        If Input.Length Mod Fraction = 0 Then
            Dim Result(Input.Length / Fraction - 1) As String
            Dim Count As Integer = 0
            For i As Integer = 0 To Input.Length - 1 Step +Fraction
                Result(Count) = Input.Substring(Count * Fraction, Fraction)
                Count = Count + 1
            Next
            Return Result
        Else
            Return Nothing
        End If
        Return Nothing
    End Function

    Public Function RejoinString(ByVal SplittedString As String()) As String
        Dim Result As New StringBuilder()
        For i As Integer = 0 To SplittedString.Length - 1
            Result.Append(SplittedString(i))
        Next
        Return Result.ToString
    End Function

    Public Function ExtendString(ByVal Input As String, ByVal ExtendChar As String, ByVal Length As Integer, Optional ByVal ExtendToType As Integer = ExtendTo.Left) As String
        Dim Result As New StringBuilder()
        If Input.Length >= Length Then
            Return Input
        Else
            If ExtendToType = ExtendTo.Right Then
                Result.Append(Input)
            End If
            For Count As Integer = 1 To Length - Input.Length
                Result.Append(ExtendChar)
            Next
            If ExtendToType = ExtendTo.Left Then
                Result.Append(Input)
            End If
            Return Result.ToString
        End If
    End Function

    Public Sub ProcessRecentRoms(ByVal MenuControl As ToolStripMenuItem, ByRef RecentRoms As String)
        If (IsNothing(RecentRoms) = False) Then
            If (RecentRoms.Length <> 0) Then
                Dim RecentRomsArray() As String = RecentRoms.Split(New [Char]() {"|"c})
                For Each RecentRom In RecentRomsArray
                    Dim CurrentItem As New ToolStripMenuItem
                    With CurrentItem
                        .Text = If(RecentRom.Length > 60, RecentRom.Substring(0, 30) + "..." + RecentRom.Substring(RecentRom.LastIndexOf("\"), RecentRom.Length - RecentRom.LastIndexOf("\")), RecentRom)
                        .Tag = RecentRom
                    End With
                    AddHandler CurrentItem.Click, Sub(sender As Object, e As EventArgs)
                                                      Dim MenuItem As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)
                                                      Main.OpenRom(MenuItem.Tag)
                                                  End Sub
                    MenuControl.DropDownItems.Add(CurrentItem)
                Next
                MenuControl.DropDownItems.Add(New ToolStripSeparator)
                Dim ClearAll As New ToolStripMenuItem
                With ClearAll
                    .Text = "Clear All Recent Roms"
                End With
                AddHandler ClearAll.Click, Sub()
                                               Main.RecentRoms = ""
                                               Settings.UpdateSettingsFile()
                                               MenuControl.DropDownItems.Clear()
                                           End Sub
                MenuControl.DropDownItems.Add(ClearAll)
            End If
        End If
    End Sub

    Public Sub AddRecentRom(ByVal CurrentRom As String, ByRef RecentRoms As String)
        Dim IsEmpty As Boolean = False
        If (IsNothing(RecentRoms) = False) Then
            If RecentRoms.Length <> 0 Then
                Dim RecentRomsArray() As String = RecentRoms.Split(New [Char]() {"|"c})
                Dim RecentRomAlreadyAddedFlag As Boolean = False
                For Each RecentRom In RecentRomsArray
                    If String.Compare(RecentRom, CurrentRom) = 0 Then
                        RecentRomAlreadyAddedFlag = True
                    End If
                Next
                If RecentRomAlreadyAddedFlag = False Then
                    RecentRoms += "|" + CurrentRom
                    Settings.UpdateSettingsFile()
                End If
            Else
                IsEmpty = True
            End If
        Else
            IsEmpty = True
        End If
        If IsEmpty Then
            RecentRoms = CurrentRom
            Settings.UpdateSettingsFile()
        End If
    End Sub

    Public Function ToDecimal(ByVal HexValue As String) As Integer
        If Regex.IsMatch(HexValue, "\A\b[0-9a-fA-F]+\b\Z") = True Then
            Return Convert.ToInt32(HexValue, 16)
        End If
        Return Nothing
    End Function

    Public Function ToHex(ByVal DecimalValue As Integer, Optional ByVal DesiredLength As Integer = 0, Optional ByVal DesiredChar As String = "0") As String
        Dim Result As String = Hex(DecimalValue)
        If DesiredLength <> 0 Then
            Result = ExtendString(Result, DesiredChar, DesiredLength)
        End If
        Return Result
    End Function

    Public Function OffsetToPointer(ByVal Offset As String, Optional ByVal SafeMode As Boolean = True) As String
        Dim Pointer As New StringBuilder()
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
            Pointer.Append(ExtendedOffset(Count - 1) & ExtendedOffset(Count))
        Next
        Pointer.Append("08")
        Return Pointer.ToString
    End Function

    Public Function PointerToOffset(ByVal Pointer As String) As String
        Dim Offset As New StringBuilder()
        If IsNothing(Pointer) = False Then
            Pointer = Pointer.Substring(0, Pointer.Length - 2)
            For Count As Integer = Pointer.Length - 1 To 0 Step -2
                Offset.Append(Pointer(Count - 1) & Pointer(Count))
            Next
        Else
            Return Nothing
        End If
        Return Offset.ToString
    End Function

    Public Function IsPointer(ByVal PossiblePointer As String, Optional ByVal SafeMode As Boolean = True) As Boolean
        If IsNothing(PossiblePointer) = False Then
            If (PossiblePointer.Length = 8) And (SafeMode = True) Then
                If String.Compare(PossiblePointer.Substring(6, 2), "08") = 0 Then
                    Return True
                Else
                    Return False
                End If
            Else
                If String.Compare(PossiblePointer.Substring(PossiblePointer.Length - 2), 2) = 0 Then
                    Return True
                Else
                    Return False
                End If
            End If
        End If
        Return Nothing
    End Function

    Public Function ValidateRom() As Boolean
        If Not String.Compare(ReadData(RomIdentifierOffset, RomIdentifierBytes), RomIdentifierHexValue) Then
            ValidateRom = True
        Else
            ValidateRom = False
        End If
    End Function

    Public Function ReadData(ByVal FromOffset As String, ByVal NumberOfBytes As Integer, Optional ByVal FileLocation As String = "") As String
        Dim Data As New StringBuilder()
        Dim Buffer(NumberOfBytes - 1) As Byte
        Dim RomFileReadStream As FileStream
        Try
            If FileLocation <> "" Then
                RomFileReadStream = File.OpenRead(FileLocation)
            Else
                RomFileReadStream = File.OpenRead(Main.RomFilePath)
            End If
            RomFileReadStream.Seek(ToDecimal(FromOffset), SeekOrigin.Begin)
            RomFileReadStream.Read(Buffer, 0, NumberOfBytes)
            For x As Integer = 0 To Buffer.Length - 1
                Data.Append(Buffer(x).ToString("X2"))
            Next
            RomFileReadStream.Close()
            Return Data.ToString
        Catch ex As Exception
            MessageBox.Show("Error occurred while reading from the file. More detailed information is provided below." & vbCrLf & vbCrLf & ex.Message, "Error While Reading!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Nothing
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
            Dim DialogBoxResult As Integer = MessageBox.Show("The rom file is in use. Please close any program using the file and click retry to try again." & vbCrLf & "[Exception.Message : " + ex.Message + "]", "Error!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation)
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
                            MessageBox.Show("It seems like you have more palettes in your table than the program let's you process! Program will be ignoring the rest." & vbCrLf & vbCrLf & "To increase this limit just head over to the settings and increase the value of Max Palettes.",
                                            "Palette Limit Breach!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

    Public Function GetPaletteOfNumber(ByVal PaletteDataArray() As PaletteData, ByVal Number As Integer) As PaletteData
        If (IsNothing(PaletteDataArray) = False) And (IsNothing(Number) = False) Then
            For Each PaletteDataElement In PaletteDataArray
                If PaletteDataElement.PaletteNumber = Number Then
                    Return PaletteDataElement
                End If
            Next
        End If
        Return Nothing
    End Function

    Public Function CheckPaletteNumberAvailability(ByVal PaletteNumber As Integer, ByVal PaletteTableOffset As String, ByVal PaletteTableEndHex As String, ByVal MaxPalette As Integer)
        For Each PaletteData In GetPalettes(PaletteTableOffset, PaletteTableEndHex, MaxPalette, False)
            If PaletteData.PaletteNumber = PaletteNumber Then
                Return False
            End If
        Next
        Return True
    End Function

    Public Function GetSprites(ByVal OWSTableOffset As String, ByVal OWSTableEmptyHex As String, ByVal OWSTableMaxSprites As Integer,
                               Optional ByVal Warning As Boolean = True, Optional ByVal NeedCountOnly As Boolean = False) As SpriteData()
        Dim SpriteDataArray() As SpriteData = Nothing
        Dim SpriteCount As Integer = 0
        Dim OWSTableEndFlag As Boolean = False
        Dim OWSTableDataSize As Integer = 4
        Dim SpriteHeaderDataSize As Integer = 36
        Dim SpriteFrameDataSize As Integer = 8
        Dim SpriteHeaderCheckRegex As String = "FFFF([0-9a-fA-F]{2})11([0-9a-fA-F]+)$"
        Dim CurrentOWSTableData As String = ""
        Dim CurrentSpriteData As String = ""
        Dim CurrentFrameDataEndFlag As Boolean = False
        Dim CurrentSpriteDataCount As Integer = 1
        While OWSTableEndFlag = False
            CurrentOWSTableData = ReadData(ToHex(ToDecimal(OWSTableOffset) + OWSTableDataSize * SpriteCount), OWSTableDataSize)
            If String.Compare(CurrentOWSTableData, OWSTableEmptyHex) <> 0 Then
                If SpriteCount = OWSTableMaxSprites Then
                    If Warning = True Then
                        MessageBox.Show("It seems that the OWS Table At Offset => 0x" + OWSTableOffset + " contains more than maximum number of sprites allowed!" _
                                        & vbCrLf & vbCrLf & "This limit can be increased in settings => OWS Table Max Sprites [Current Value : " + CStr(OWSTableMaxSprites) + "]",
                                        "OWS Table Sprite Limit Breached!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                    OWSTableEndFlag = True
                    Exit While
                Else
                    If IsPointer(CurrentOWSTableData) Then
                        Try
                            CurrentSpriteData = ReadData(PointerToOffset(CurrentOWSTableData), SpriteHeaderDataSize)
                            If Regex.IsMatch(CurrentSpriteData, SpriteHeaderCheckRegex) = True Then
                                ReDim Preserve SpriteDataArray(SpriteCount)
                                If NeedCountOnly = True Then
                                    SpriteDataArray(SpriteCount).SpriteIndex = SpriteCount
                                Else
                                    SpriteDataArray(SpriteCount).SpriteIndex = SpriteCount
                                    SpriteDataArray(SpriteCount).SpriteTableOffset = ToHex(ToDecimal(OWSTableOffset) + OWSTableDataSize * SpriteCount)
                                    SpriteDataArray(SpriteCount).SpriteHeaderOffset = PointerToOffset(CurrentOWSTableData)
                                    CurrentSpriteDataCount = 1
                                    For Each SpriteHeaderElement In SplitString(CurrentSpriteData, 8)
                                        Select Case CurrentSpriteDataCount
                                            Case 1
                                                'SpriteDataArray(SpriteCount).SpritePreset.StarterByte = SplitString(SpriteHeaderElement, 4)(0)
                                                SpriteDataArray(SpriteCount).SpritePreset.StarterByte = "FFFF"
                                                'Eg. : FF FF 06 11 => 06 [Palette Number]
                                                SpriteDataArray(SpriteCount).SpritePalette = ToDecimal(SplitString(SpriteHeaderElement, 2)(2))
                                                'SpriteDataArray(SpriteCount).SpritePreset.StarterByte = SplitString(SpriteHeaderElement, 2)(3)
                                                SpriteDataArray(SpriteCount).SpritePreset.UnknownFunction1 = "11"
                                            Case 2
                                                SpriteDataArray(SpriteCount).SpritePreset.Unknown1 = SpriteHeaderElement
                                            Case 3
                                                'Eg. : 10 00 20 00 => 10 x 20 => 16 x 32 [Sprite Size]
                                                SpriteDataArray(SpriteCount).SpriteSize.Width = ToDecimal(SplitString(SpriteHeaderElement, 2)(1) + SplitString(SpriteHeaderElement, 2)(0))
                                                SpriteDataArray(SpriteCount).SpriteSize.Height = ToDecimal(SplitString(SpriteHeaderElement, 2)(3) + SplitString(SpriteHeaderElement, 2)(2))
                                                SpriteDataArray(SpriteCount).SpriteFrameSize = (SpriteDataArray(SpriteCount).SpriteSize.Width * SpriteDataArray(SpriteCount).SpriteSize.Height / 2)
                                            Case 4
                                                SpriteDataArray(SpriteCount).SpritePreset.PalRegisters = SpriteHeaderElement
                                            Case 5
                                                SpriteDataArray(SpriteCount).SpritePreset.Pointer1 = SpriteHeaderElement
                                            Case 6
                                                SpriteDataArray(SpriteCount).SpritePreset.Pointer2 = SpriteHeaderElement
                                            Case 7
                                                SpriteDataArray(SpriteCount).SpritePreset.AnimPointer = SpriteHeaderElement
                                            Case 8
                                                SpriteDataArray(SpriteCount).SpriteFrameDataOffset = PointerToOffset(SpriteHeaderElement)
                                            Case 9
                                                SpriteDataArray(SpriteCount).SpritePreset.Pointer4 = SpriteHeaderElement
                                        End Select
                                        CurrentSpriteDataCount = CurrentSpriteDataCount + 1
                                    Next
                                    CurrentSpriteData = ReadData(SpriteDataArray(SpriteCount).SpriteFrameDataOffset, SpriteFrameDataSize)
                                    SpriteDataArray(SpriteCount).SpriteArtDataOffset = PointerToOffset(CurrentSpriteData.Substring(0, 8))
                                    SpriteDataArray(SpriteCount).SpriteFrameCount = If(String.Compare(CurrentSpriteData.Substring(12, 2), "00") = 0, -1,
                                                                                       ToDecimal(CurrentSpriteData.Substring(12, 2)))
                                    If SpriteDataArray(SpriteCount).SpriteFrameCount = -1 Then
                                        SpriteDataArray(SpriteCount).SpriteValid = False
                                    Else
                                        SpriteDataArray(SpriteCount).SpriteValid = True
                                    End If
                                End If
                            End If
                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "Error Occured!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                        SpriteCount = SpriteCount + 1
                    Else
                        OWSTableEndFlag = True
                        Exit While
                    End If
                End If
            Else
                OWSTableEndFlag = True
                Exit While
            End If
        End While
        Return SpriteDataArray
    End Function

    Public Function GetSpriteTableOffset(ByVal OWSTableListOffset As String, ByVal OWSTableListEmptyHex As String, ByVal OWSTableNumber As Integer) As String
        If (IsNothing(OWSTableListOffset) = False) And (IsNothing(OWSTableNumber) = False) Then
            If OWSTableNumber <> 0 Then
                Dim OWSTableListTableEndFlag As Boolean = False
                Dim OWSTableFoundFlag As Boolean = False
                Dim CurrentData As String = ""
                Dim OWSTableListTableCount As Integer = 0
                While OWSTableListTableEndFlag = False
                    CurrentData = ReadData(ToHex(ToDecimal(OWSTableListOffset) + OWSTableListTableCount * 4), 4)
                    If String.Compare(CurrentData, OWSTableListEmptyHex) = 0 Then
                        OWSTableListTableEndFlag = True
                        OWSTableFoundFlag = False
                        Exit While
                    Else
                        If OWSTableListTableCount = OWSTableNumber - 1 Then
                            OWSTableListTableEndFlag = True
                            OWSTableFoundFlag = True
                            Exit While
                        Else
                            OWSTableListTableEndFlag = False
                            OWSTableFoundFlag = False
                            OWSTableListTableCount = OWSTableListTableCount + 1
                        End If
                    End If
                End While
                If OWSTableFoundFlag = True Then
                    Return PointerToOffset(CurrentData)
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If
        End If
        Return Nothing
    End Function

    Public Function GetSpriteTables(ByVal OWSTableListOffset As String, ByVal OWSTableListEmptyHex As String,
                                    ByVal OWSTableEmptyHex As String, ByVal OWSTableMaxSprites As Integer) As SpriteTable()
        Dim SpriteTableArray As SpriteTable() = Nothing
        Dim SpriteTableCount As Integer = 1
        Dim SpriteTableOffset As String = GetSpriteTableOffset(OWSTableListOffset, OWSTableListEmptyHex, SpriteTableCount)
        While IsNothing(SpriteTableOffset) = False
            ReDim Preserve SpriteTableArray(SpriteTableCount - 1)
            SpriteTableArray(SpriteTableCount - 1).SpriteTableNumber = SpriteTableCount
            SpriteTableArray(SpriteTableCount - 1).SpriteTableOffset = SpriteTableOffset
            SpriteTableArray(SpriteTableCount - 1).SpriteTableSpriteArray = GetSprites(SpriteTableOffset, OWSTableEmptyHex, OWSTableMaxSprites, False)
            SpriteTableArray(SpriteTableCount - 1).SpriteTableSpriteCount = If(IsNothing(SpriteTableArray(SpriteTableCount - 1).SpriteTableSpriteArray) = False,
                                                                               SpriteTableArray(SpriteTableCount - 1).SpriteTableSpriteArray.Length, 0)
            SpriteTableCount = SpriteTableCount + 1
            SpriteTableOffset = GetSpriteTableOffset(OWSTableListOffset, OWSTableListEmptyHex, SpriteTableCount)
        End While
        Return SpriteTableArray
    End Function

    Public Sub ApplySpritePatch()
        'Dim Log As New StringBuilder()
        Dim PatchDataArray() As String = My.Resources.FireRedPatch.Split(New String() {vbCrLf}, StringSplitOptions.None)
        Dim PatchCount As Integer = 0
        For Each PatchData In PatchDataArray
            PatchCount = PatchCount + 1
            'Log.Append("Patch #" + CStr(PatchCount) + " : ")
            PatchData = PatchData.Replace("[", "")
            PatchData = PatchData.Replace("]", "")
            Dim Patch() As String = PatchData.Split("|")
            If Patch.Length = 2 Then
                If Patch(0).Length = 6 And Patch(1).Length = 16 Then
                    If WriteData(Patch(0), 8, Patch(1)) = True Then
                        'Log.Append("Patch Applied!" & vbCrLf)
                    Else
                        'Log.Append("Patch Cannot Be Applied; Rom File Not Writable." & vbCrLf)
                    End If
                Else
                    'Log.Append("Not Valid Patch Format." & vbCrLf)
                End If
            Else
                'Log.Append("Not Valid Patch Format." & vbCrLf)
            End If
        Next
    End Sub

    Public Function ProcessSpriteData(ByVal SpriteData As String) As String
        Dim SpriteDataArray() As String = SplitString(SpriteData, 2)
        For i As Integer = 0 To SpriteDataArray.Length - 1
            SpriteDataArray(i) = SpriteDataArray(i)(1) + SpriteDataArray(i)(0)
        Next
        Return RejoinString(SpriteDataArray)
    End Function

    Public Function ProcessBitmapData(ByVal BitmapRawData As String) As String
        Dim BitmapProcessedData As New StringBuilder()
        If BitmapRawData.Length Mod 2 <> 0 Then
            BitmapRawData = ExtendString(BitmapRawData, "0", BitmapRawData.Length + 1)
        End If
        Dim BitmapRawDataArray() As String = SplitString(BitmapRawData, 2)
        For Count As Integer = BitmapRawDataArray.Length - 1 To 0 Step -1
            BitmapProcessedData.Append(BitmapRawDataArray(Count))
        Next
        Return BitmapProcessedData.ToString
    End Function

    Public Function ExportBitmap(ByVal SpriteImageData As String, ByVal SpritePaletteData As String, ByVal SpriteSize As Size, ByVal FileLocation As String) As Boolean
        Dim BitmapData As New StringBuilder()
        BitmapData.Append("424D76070000000000007600000028000000")
        BitmapData.Append(ProcessBitmapData(ToHex(SpriteSize.Width, 8)))
        BitmapData.Append(ProcessBitmapData(ToHex(SpriteSize.Height, 8)))
        BitmapData.Append("01000400000000008007000000000000000000001000000000000000")
        Dim SpritePaletteDataArray() As String = SplitString(SpritePaletteData, 4)
        If SpritePaletteDataArray.Length <> 16 Then
            Return False
        End If
        Dim PaletteConvertObject As New PaletteConvert
        For SpritePaletteDataCount As Integer = 0 To 15
            BitmapData.Append(ProcessBitmapData("00" & PaletteConvertObject.ConvertColorHex(SpritePaletteDataArray(SpritePaletteDataCount))))
        Next
        Erase SpritePaletteDataArray
        Dim SpriteDataArray(SpriteSize.Height)() As String
        Dim BlockSize As New Size(8, 8)
        Dim BlockColCount As Integer = SpriteSize.Width / BlockSize.Width
        Dim BlockRowCount As Integer = SpriteSize.Height / BlockSize.Height
        Dim SpriteDataCount As Integer = 0
        For BlockRow As Integer = 1 To BlockRowCount
            For BlockCol As Integer = 1 To BlockColCount
                For Y As Integer = 0 To BlockSize.Height - 1
                    For X As Integer = 0 To BlockSize.Width - 1
                        Dim CurrentPixelLocation As Point = New Point((BlockCol - 1) * BlockSize.Width + X, (BlockRow - 1) * BlockSize.Height + Y)
                        ReDim Preserve SpriteDataArray(CurrentPixelLocation.Y)(CurrentPixelLocation.X)
                        SpriteDataArray(CurrentPixelLocation.Y)(CurrentPixelLocation.X) = SpriteImageData(SpriteDataCount)
                        SpriteDataCount = SpriteDataCount + 1
                    Next
                Next
            Next
        Next
        For SpriteImageDataLineCount As Integer = SpriteSize.Height - 1 To 0 Step -1
            For SpriteImageDataPointCount As Integer = 0 To SpriteSize.Width - 1
                BitmapData.Append(SpriteDataArray(SpriteImageDataLineCount)(SpriteImageDataPointCount))
            Next
        Next
        Erase SpriteDataArray
        BitmapData.Append("0000")
        Dim BitmapFileWriteStream As FileStream
WriteDataTry:
        Try
            BitmapFileWriteStream = File.OpenWrite(FileLocation)
            Dim WriteBuffer As Byte()
            Dim NumberOfBytes As Integer = BitmapData.Length / 2
            WriteBuffer = New Byte(NumberOfBytes - 1) {}
            Dim i As Integer = 0
            Dim k As Integer = 0
            While i < NumberOfBytes
                WriteBuffer(i) = Convert.ToByte((BitmapData(k) & BitmapData(k + 1)), 16)
                k = k + 2
                i = i + 1
            End While
            BitmapFileWriteStream.Seek(0, SeekOrigin.Begin)
            BitmapFileWriteStream.Write(WriteBuffer, 0, NumberOfBytes)
            BitmapFileWriteStream.Close()
            Return True
        Catch ex As Exception
            Dim DialogBoxResult As Integer = MessageBox.Show("The bitmap file is in use. Please close any program using the file and click retry to try again. Or see the message below for more details." & vbCrLf & "[Exception.Message : " + ex.Message + "]", "Error!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation)
            If DialogBoxResult = DialogResult.Retry Then
                GoTo WriteDataTry
            End If
        End Try
        Return False
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