Imports System.Text
Imports System.IO

Public Class Form1
    Public Structure Preset
        Dim PresetName As String
        Dim StarterByte As String
        Dim UnknownFunction1 As String
        Dim Unknown1 As String
        Dim UnknownFunction2 As String
        Dim UnknownFunction3 As String
        Dim PalRegisters As String
        Dim Pointer1 As String
        Dim Pointer2 As String
        Dim AnimPointer As String
        Dim Pointer4 As String
    End Structure
    Public PrimaryHero As Preset = New Preset With {
        .PresetName = "Primary Hero Preset - 16x32 - 20 Frames",
        .StarterByte = "FFFF",
        .UnknownFunction1 = "11",
        .Unknown1 = "02110002",
        .UnknownFunction2 = "00",
        .UnknownFunction3 = "00",
        .PalRegisters = "10010000",
        .Pointer1 = "10373A08",
        .Pointer2 = "9C373A08",
        .AnimPointer = "70343A08",
        .Pointer4 = "FC1C2308"
    }
    Public SecondaryHero As Preset = New Preset With {
        .PresetName = "Secondary Hero Preset - 16x32 - 9 Frames",
        .StarterByte = "FFFF",
        .UnknownFunction1 = "11",
        .Unknown1 = "FF110001",
        .UnknownFunction2 = "00",
        .UnknownFunction3 = "00",
        .PalRegisters = "15010000",
        .Pointer1 = "10373A08",
        .Pointer2 = "9C373A08",
        .AnimPointer = "68333A08",
        .Pointer4 = "FC1C2308"
    }
    Public SmallBoy As Preset = New Preset With {
        .PresetName = "Small Boy - 16x16 - 9 Frames",
        .StarterByte = "FFFF",
        .UnknownFunction1 = "11",
        .Unknown1 = "FF118000",
        .UnknownFunction2 = "00",
        .UnknownFunction3 = "00",
        .PalRegisters = "15010000",
        .Pointer1 = "F0363A08",
        .Pointer2 = "48373A08",
        .AnimPointer = "68333A08",
        .Pointer4 = "FC1C2308"
    }
    Public SmallGirl As Preset = New Preset With {
        .PresetName = "Small Girl - 16x16 - 10 Frames",
        .StarterByte = "FFFF",
        .UnknownFunction1 = "11",
        .Unknown1 = "FF118000",
        .UnknownFunction2 = "00",
        .UnknownFunction3 = "00",
        .PalRegisters = "13010000",
        .Pointer1 = "F0363A08",
        .Pointer2 = "48373A08",
        .AnimPointer = "68333A08",
        .Pointer4 = "FC1C2308"
    }
    Public BoyWithCap As Preset = New Preset With {
        .PresetName = "Boy With Cap Preset - 16x32 - 10 Frames",
        .StarterByte = "FFFF",
        .UnknownFunction1 = "11",
        .Unknown1 = "FF110001",
        .UnknownFunction2 = "00",
        .UnknownFunction3 = "00",
        .PalRegisters = "12010000",
        .Pointer1 = "10373A08",
        .Pointer2 = "9C373A08",
        .AnimPointer = "68333A08",
        .Pointer4 = "FC1C2308"
    }
    Public BikerWithTomahawk As Preset = New Preset With {
        .PresetName = "Biker With Tomahawk Preset - 32x32 - 10 Frames",
        .StarterByte = "FFFF",
        .UnknownFunction1 = "11",
        .Unknown1 = "FF110002",
        .UnknownFunction2 = "00",
        .UnknownFunction3 = "00",
        .PalRegisters = "13020000",
        .Pointer1 = "18373A08",
        .Pointer2 = "F0373A08",
        .AnimPointer = "68333A08",
        .Pointer4 = "FC1C2308"
    }
    Public TreeCut As Preset = New Preset With {
        .PresetName = "Tree Cut Preset - 16x16 - 4 Frames",
        .StarterByte = "FFFF",
        .UnknownFunction1 = "11",
        .Unknown1 = "FF118000",
        .UnknownFunction2 = "00",
        .UnknownFunction3 = "00",
        .PalRegisters = "44000000",
        .Pointer1 = "F0363A08",
        .Pointer2 = "48373A08",
        .AnimPointer = "60363A08",
        .Pointer4 = "FC1C2308"
    }
    Public RockSmash As Preset = New Preset With {
        .PresetName = "Rock Smash Preset - 16x16 - 4 Frames",
        .StarterByte = "FFFF",
        .UnknownFunction1 = "11",
        .Unknown1 = "FF118000",
        .UnknownFunction2 = "00",
        .UnknownFunction3 = "00",
        .PalRegisters = "45000000",
        .Pointer1 = "F0363A08",
        .Pointer2 = "48373A08",
        .AnimPointer = "58363A08",
        .Pointer4 = "FC1C2308"
    }
    Public RockStrength As Preset = New Preset With {
        .PresetName = "Rock Strength Preset - 16x16 - 1 Frame",
        .StarterByte = "FFFF",
        .UnknownFunction1 = "11",
        .Unknown1 = "FF118000",
        .UnknownFunction2 = "00",
        .UnknownFunction3 = "00",
        .PalRegisters = "45000000",
        .Pointer1 = "F0363A08",
        .Pointer2 = "48373A08",
        .AnimPointer = "14333A08",
        .Pointer4 = "FC1C2308"
    }
    Public Ship As Preset = New Preset With {
        .PresetName = "Ship Preset - 64x64 - 9 (1) Frames",
        .StarterByte = "FFFF",
        .UnknownFunction1 = "11",
        .Unknown1 = "FF110008",
        .UnknownFunction2 = "00",
        .UnknownFunction3 = "00",
        .PalRegisters = "1A000000",
        .Pointer1 = "20373A08",
        .Pointer2 = "D0383A08",
        .AnimPointer = "68333A08",
        .Pointer4 = "FC1C2308"
    }

    Public CurrentPreset As Preset
    Dim RomIdentifierOffset As String = "0000A0"
    Dim RomIdentifierHexValue As String = "504F4B454D4F4E204649524542505245"
    Dim RomIdentifierBytes As Integer = 16
    Dim MaxHexSize As Integer = 65536 ' 0xFFFF + 0x1 in Decimal
    Public RomFileLoaded As Boolean = False
    Dim SearchOffsetFlag As Boolean = True
    Public RomFilePath As String
    Dim OWSTableOffset As String = ""
    Dim RomLength As Integer = 0

    Public FreeSpaceByteValue As String
    Public SpriteArtDataValue As String
    Public OWSTableListOffset As String
    Public OWSTableListEmptyDataHex As String
    Public OWSTableEmptyDataHex As String
    Public OWSTableListMaxTables As Integer
    Public OWSTableMaxSprites As Integer
    Public RomLock As Boolean
    Public PaletteTableOffset As String
    Public MaxPalette As Integer
    Public PaletteTableEndHex As String

    Public GlobalSpriteHeaderDataOffset As String = ""
    Public GlobalSpriteFrameDataOffset As String = ""
    Public GlobalSpriteArtDataOffset As String = ""
    Public UseCustomSpriteArtData As Boolean = False
    Public CustomSpriteArtData As String = ""

    Public Function ToDecimal(ByVal HexValue As String) As Integer
        ToDecimal = Convert.ToInt32(HexValue, 16)
    End Function

    Public Function ToHex(ByVal DecimalValue As Integer) As String
        ToHex = Hex(DecimalValue)
    End Function

    Public Function ReadData(ByVal FromOffset As String, ByVal NumberOfBytes As Integer) As String
        Dim Data As String = ""
        Dim Buffer(NumberOfBytes - 1) As Byte
        Dim RomFileReadStream As FileStream
        RomFileReadStream = File.OpenRead(RomFilePath)
        RomFileReadStream.Seek(ToDecimal(FromOffset), SeekOrigin.Begin)
        RomFileReadStream.Read(Buffer, 0, NumberOfBytes)
        For x As Integer = 0 To Buffer.Length - 1
            Data += Buffer(x).ToString("X2")
        Next
        RomFileReadStream.Close()
        ReadData = Data
    End Function

    Public Function WriteData(ByVal AtOffset As String, ByVal NumberOfBytes As Integer, ByVal Data As String, Optional ByVal Type As Integer = 0) As Boolean
        Dim RomFileWriteStream As FileStream
WriteDataTry:
        Try
            RomFileWriteStream = File.OpenWrite(RomFilePath)
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
            RichTextBox1.Text += vbCrLf & "Rom file is use! Prompting user to try again..."
            Dim DialogBoxResult As Integer = MessageBox.Show("The rom file is in use. Please close any program using the file and click Retry to try again." & vbCrLf & "[Exception.Message : " + ex.Message + "]", "Error!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation)
            If DialogBoxResult = DialogResult.Retry Then
                RichTextBox1.Text += vbCrLf & "Trying again to write data..."
                GoTo WriteDataTry
            Else
                RichTextBox1.Text += vbCrLf & "Error! Aborted by user."
                Button3.Enabled = True
            End If
        End Try
        Return False
    End Function

    Public Function WriteSpriteData(ByVal SpriteHeaderDataOffset As String,
                               ByVal SpriteFrameDataOffset As String,
                               ByVal SpriteArtDataOffset As String,
                               ByVal SpriteHeaderDataSize As Integer,
                               ByVal SpriteFrameDataSize As Integer,
                               ByVal SpriteArtDataSize As Integer,
                               ByVal SpriteHeaderData As String,
                               ByVal SpriteFrameData As String,
                               ByVal SpriteArtData As String) As Boolean
        If WriteData(SpriteHeaderDataOffset, SpriteHeaderDataSize, SpriteHeaderData) = True Then
            RichTextBox1.Text += vbCrLf & "     Sprite Header Data write success!"
            If WriteData(SpriteFrameDataOffset, SpriteFrameDataSize, SpriteFrameData) = True Then
                RichTextBox1.Text += vbCrLf & "     Sprite Frame Data write success!"
                If UseCustomSpriteArtData Then
                    If WriteData(SpriteArtDataOffset, SpriteArtDataSize, CustomSpriteArtData) = True Then
                        RichTextBox1.Text += vbCrLf & "     Sprite Art Data write success!"
                        Return True
                    Else
                        Return False
                    End If
                Else
                    If WriteData(SpriteArtDataOffset, SpriteArtDataSize, SpriteArtData, 1) = True Then
                        RichTextBox1.Text += vbCrLf & "     Sprite Art Data write success!"
                        Return True
                    Else
                        Return False
                    End If
                End If
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Function ValidateRom() As Boolean
        If Not String.Compare(ReadData(RomIdentifierOffset, RomIdentifierBytes), RomIdentifierHexValue) Then
            ValidateRom = True
        Else
            ValidateRom = False
        End If
    End Function

    Public Function SearchFreeSpace(ByVal FromOffset As Integer, ByVal NumberOfBytes As Integer, ByVal FreeSpaceString As String) As String
        Dim FreeSpaceByte As Byte = Convert.ToByte(FreeSpaceString, 16)
        Using RomFileBinaryReader As New BinaryReader(File.Open(RomFilePath, FileMode.Open, FileAccess.Read, FileShare.Read), Encoding.ASCII)
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

    Public Function OffsetToPointer(ByVal Offset As String) As String
        Dim Pointer As String = "Null"
        If Offset.Length = 6 Then
            Pointer = Offset(4) + Offset(5) + Offset(2) + Offset(3) + Offset(0) + Offset(1) + "08"
        End If
        Return Pointer
    End Function

    Public Function PointerToOffset(ByVal Pointer As String) As String
        Dim Offset As String = "Null"
        If Pointer.Length = 8 Then
            Offset = Pointer(4) + Pointer(5) + Pointer(2) + Pointer(3) + Pointer(0) + Pointer(1)
        End If
        Return Offset
    End Function

    Public Sub PerformSpriteTableInsertion(ByVal SpritePointer As String)
        GroupBox4.Hide()
        Panel1.Hide()
        RichTextBox1.Text += vbCrLf & "     Using Table => 0x" + OWSTableOffset
        RichTextBox1.Text += vbCrLf & "Searching for free space..."
        Dim NumberOfSprites As Integer = 0
        Dim EmptySpriteOffset As String = ""
        Dim RomFileReadStream As FileStream
        RomFileReadStream = File.OpenRead(RomFilePath)
        RomFileReadStream.Seek(ToDecimal(OWSTableOffset), SeekOrigin.Begin)
        Dim Flag As Boolean = False
        While Flag = False
            Dim Data As String = ""
            Dim Buffer(3) As Byte
            RomFileReadStream.Read(Buffer, 0, 4)
            For i As Integer = 0 To Buffer.Length - 1
                Data += Buffer(i).ToString("X2")
            Next
            If String.Compare(Data, OWSTableEmptyDataHex) = 0 Then
                EmptySpriteOffset = ToHex(ToDecimal(OWSTableOffset) + NumberOfSprites * 4)
                Flag = True
                Exit While
            Else
                NumberOfSprites += 1
                If NumberOfSprites > OWSTableMaxSprites Then
                    RichTextBox1.Text += vbCrLf & "Table is full! Prompting user to choose table again..."
                    MessageBox.Show("OWS Table is full! Please select another table.", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Flag = False
                    Exit While
                End If
            End If
        End While
        RomFileReadStream.Close()
        If Flag = False Then
            GroupBox4.Show()
            Panel1.Show()
        Else
            RichTextBox1.Text += vbCrLf & "     Found => 0x" + EmptySpriteOffset
            RichTextBox1.Text += vbCrLf & "Inserting Sprite pointer to the selected OWS table..."
            If WriteData(EmptySpriteOffset, 4, SpritePointer) = True Then
                RichTextBox1.Text += vbCrLf & "     Done!"
                RichTextBox1.Text += vbCrLf & "Everything completed successfully!"
                Button6.Enabled = True
            Else
                RichTextBox1.Text += vbCrLf & "     Error! Aborting..."
                Button6.Enabled = True
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If RomFile.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            RomFilePath = RomFile.FileName
            TextBox1.Text = RomFilePath
            If RomLock Then
                If ValidateRom() Then
                    Dim RomFileStream As FileStream
                    RomFileStream = File.OpenRead(RomFilePath)
                    RomLength = RomFileStream.Length
                    RomFileStream.Close()
                    Label4.Text = "Pokemon Fire Red Rom Detected."
                    Label4.ForeColor = Color.Green
                    GroupBox2.Enabled = True
                    RomFileLoaded = True
                    Button8.Enabled = True
                Else
                    Label4.Text = "Pokemon Fire Red Rom Not Detected!"
                    Label4.ForeColor = Color.Red
                    GroupBox2.Enabled = False
                    RomFileLoaded = False
                    Button8.Enabled = False
                    MessageBox.Show("This is not Pokemon Fire Red Rom!" & vbCrLf & vbCrLf & "You can disable this check by switching Rom Lock to Off state in Settings.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                If ValidateRom() Then
                    Dim RomFileStream As FileStream
                    RomFileStream = File.OpenRead(RomFilePath)
                    RomLength = RomFileStream.Length
                    RomFileStream.Close()
                    Label4.Text = "Pokemon Fire Red Rom Detected."
                    Label4.ForeColor = Color.Green
                    GroupBox2.Enabled = True
                    RomFileLoaded = True
                    Button8.Enabled = True
                Else
                    Dim RomFileStream As FileStream
                    RomFileStream = File.OpenRead(RomFilePath)
                    RomLength = RomFileStream.Length
                    RomFileStream.Close()
                    Label4.Text = "Custom Rom Loaded! Use Valid Sprite Preset Data!"
                    Label4.ForeColor = Color.OrangeRed
                    GroupBox2.Enabled = True
                    RomFileLoaded = True
                    Button8.Enabled = True
                End If
            End If
        End If
    End Sub

    Public Sub LoadForm()
        If RomFileLoaded = False Then
            TextBox6.Enabled = False
            TextBox7.Enabled = False
            TextBox8.Enabled = False
            TextBox9.Enabled = False
            TextBox10.Enabled = False
            TextBox12.Enabled = False
            GroupBox2.Enabled = False
            Button8.Enabled = False
        End If
        TextBox6.Text = CurrentPreset.Unknown1
        TextBox7.Text = CurrentPreset.PalRegisters
        TextBox8.Text = CurrentPreset.Pointer1
        TextBox9.Text = CurrentPreset.Pointer2
        TextBox10.Text = CurrentPreset.AnimPointer
        TextBox12.Text = CurrentPreset.Pointer4
        TextBox6.Tag = CurrentPreset.Unknown1
        TextBox7.Tag = CurrentPreset.PalRegisters
        TextBox8.Tag = CurrentPreset.Pointer1
        TextBox9.Tag = CurrentPreset.Pointer2
        TextBox10.Tag = CurrentPreset.AnimPointer
        TextBox12.Tag = CurrentPreset.Pointer4
        GroupBox3.Text = "Sprite Data Preset [Current : " + CurrentPreset.PresetName + "]"
        RichTextBox1.Hide()
        Button6.Hide()
        GroupBox4.Hide()
        Panel1.Hide()
        If UseCustomSpriteArtData Then
            Button9.Text = "Use Custom Sprite Art Data - On"
        Else
            Button9.Text = "Use Custom Sprite Art Data - Off"
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CurrentPreset = SecondaryHero
        Button8.Enabled = False
        Form3.LoadSettings()
        LoadForm()
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            TextBox6.Enabled = True
            TextBox7.Enabled = True
            TextBox8.Enabled = True
            TextBox9.Enabled = True
            TextBox10.Enabled = True
            TextBox12.Enabled = True
            Button2.Enabled = False
        Else
            TextBox6.Enabled = False
            TextBox7.Enabled = False
            TextBox8.Enabled = False
            TextBox9.Enabled = False
            TextBox10.Enabled = False
            TextBox12.Enabled = False
            Button2.Enabled = True
            LoadForm()
        End If
    End Sub

    Private Sub DigitValidator(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress, TextBox3.KeyPress, TextBox4.KeyPress, TextBox5.KeyPress, TextBox13.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) _
                  Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If
    End Sub

    Private Sub SpaceValidator(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress, TextBox3.KeyPress, TextBox4.KeyPress, TextBox5.KeyPress, TextBox6.KeyPress, TextBox7.KeyPress, TextBox8.KeyPress, TextBox9.KeyPress, TextBox10.KeyPress, TextBox11.KeyPress, TextBox12.KeyPress, TextBox13.KeyPress
        If Asc(e.KeyChar) = Keys.Space Then
            e.Handled = True
        End If
    End Sub

    Private Sub SpritePresetDataValidator(sender As Object, e As EventArgs) Handles TextBox6.Leave, TextBox7.Leave, TextBox8.Leave, TextBox9.Leave, TextBox10.Leave, TextBox12.Leave
        Dim TextBoxItem As TextBox = CType(sender, TextBox)
        If TextBoxItem.Text <> "" Then
            If TextBoxItem.Text.Length <> 8 Then
                TextBoxItem.Text = TextBoxItem.Tag
                MessageBox.Show("Value can only be of 8 characters.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                If Not System.Text.RegularExpressions.Regex.IsMatch(TextBoxItem.Text, "\A\b[0-9a-fA-F]+\b\Z") Then
                    TextBoxItem.Text = TextBoxItem.Tag
                    MessageBox.Show("Enter a valid hexadecimal value!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Else
            TextBoxItem.Text = TextBoxItem.Tag
            MessageBox.Show("Value cannot be empty!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Button5.Enabled = False
            Button5.Hide()
            TextBox11.Enabled = True
            TextBox11.Show()
            Label12.Enabled = True
            Label12.Show()
            Label14.Enabled = True
            Label14.Show()
            TextBox13.Enabled = True
            TextBox13.Show()
            SearchOffsetFlag = True
        Else
            Button5.Enabled = True
            Button5.Show()
            TextBox11.Enabled = False
            TextBox11.Hide()
            Label12.Enabled = False
            Label12.Hide()
            Label14.Enabled = False
            Label14.Hide()
            TextBox13.Enabled = False
            TextBox13.Hide()
            SearchOffsetFlag = False
        End If
    End Sub

    Private Sub TextBox_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged, TextBox3.TextChanged, TextBox4.TextChanged, TextBox5.TextChanged
        Dim TextBoxItem As TextBox = CType(sender, TextBox)
        If RomFileLoaded = True Then
            If TextBoxItem.Text <> "" Then
                Dim TextBoxValue = Integer.Parse(TextBoxItem.Text)
                If TextBoxValue > 255 Then
                    TextBoxItem.Text = TextBoxItem.Tag
                    MessageBox.Show("Max Limit is 255!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub

    Private Sub SkipByteMaxLimitValidator(sender As Object, e As EventArgs) Handles TextBox13.TextChanged
        Dim TextBoxItem As TextBox = CType(sender, TextBox)
        If RomFileLoaded = True Then
            If TextBoxItem.Text <> "" Then
                Dim TextBoxValue = Integer.Parse(TextBoxItem.Text)
                If TextBoxValue > (RomLength / 2) Then
                    TextBoxItem.Text = TextBoxItem.Tag
                    MessageBox.Show("Max Limit is " + CStr(RomLength / 2) + "!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub

    Private Sub NonZeroValidator(sender As Object, e As EventArgs) Handles TextBox2.TextChanged, TextBox3.TextChanged, TextBox5.TextChanged
        Dim TextBoxItem As TextBox = CType(sender, TextBox)
        If RomFileLoaded = True Then
            If TextBoxItem.Text <> "" Then
                Dim TextBoxValue = Integer.Parse(TextBoxItem.Text)
                If TextBoxValue = 0 Then
                    TextBoxItem.Text = TextBoxItem.Tag
                    MessageBox.Show("Value cannot be zero!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim ErrorFlag As Boolean = False
        Dim Width As Integer
        Dim Height As Integer
        Dim PaletteNumber As Integer
        Dim NumberOfFrames As Integer
        If TextBox2.Text <> "" Then
            If CInt(TextBox2.Text) > 0 Then
                Width = CInt(TextBox2.Text)
            Else
                TextBox2.Text = TextBox2.Tag
                ErrorFlag = True
                MessageBox.Show("Width cannot be zero or negative!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            TextBox2.Text = TextBox2.Tag
            ErrorFlag = True
            MessageBox.Show("Width cannot be empty or zero!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        If TextBox3.Text <> "" Then
            If CInt(TextBox3.Text) > 0 Then
                Height = CInt(TextBox3.Text)
            Else
                TextBox3.Text = TextBox3.Tag
                ErrorFlag = True
                MessageBox.Show("Height cannot be zero or negative!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            TextBox3.Text = TextBox3.Tag
            ErrorFlag = True
            MessageBox.Show("Height cannot be empty or zero!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        If TextBox4.Text <> "" Then
            PaletteNumber = CInt(TextBox4.Text)
        Else
            TextBox4.Text = TextBox4.Tag
            ErrorFlag = True
            MessageBox.Show("Palette Number cannot be empty!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        If TextBox5.Text <> "" Then
            If CInt(TextBox5.Text) > 0 Then
                NumberOfFrames = CInt(TextBox5.Text)
            Else
                TextBox5.Text = TextBox5.Tag
                ErrorFlag = True
                MessageBox.Show("Number Of Frames cannot be zero or negative!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            TextBox5.Text = TextBox5.Tag
            ErrorFlag = True
            MessageBox.Show("Number Of Frames cannot be empty or zero!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        If SearchOffsetFlag = False Then
            If Not GlobalSpriteHeaderDataOffset <> "" Then
                MessageBox.Show("Sprite Header Data Offset cannot be zero!" & vbCrLf & "Please set Free Space Pointers.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ErrorFlag = True
            End If
            If Not GlobalSpriteFrameDataOffset <> "" Then
                MessageBox.Show("Sprite Frame Data Offset cannot be zero!" & vbCrLf & "Please set Free Space Pointers.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ErrorFlag = True
            End If
            If Not GlobalSpriteArtDataOffset <> "" Then
                MessageBox.Show("Sprite Art Data Offset cannot be zero!" & vbCrLf & "Please set Free Space Pointers.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ErrorFlag = True
            End If
        End If
        If Not ErrorFlag Then
            Dim SpriteHeaderDataSize As Integer = 36
            Dim FrameSize As Integer = Width * Height / 2
            Dim SpriteFrameDataSize As Integer = 8 * NumberOfFrames
            Dim SpriteArtDataSize As Integer = FrameSize * NumberOfFrames
            RichTextBox1.Show()
            Button6.Enabled = False
            Button6.Show()
            GroupBox2.Text = "Sprite Data Generation"
            RichTextBox1.Text = ""
            Dim SpriteHeaderDataOffset As String = ""
            Dim SpriteFrameDataOffset As String = ""
            Dim SpriteArtDataOffset As String = ""
            If SearchOffsetFlag = True Then
                RichTextBox1.Text += "Searching free space for Sprite Header Data [" + CStr(SpriteHeaderDataSize) + " Bytes]..."
                SpriteHeaderDataOffset = SearchFreeSpace(ToDecimal(TextBox11.Text), SpriteHeaderDataSize, FreeSpaceByteValue)
                RichTextBox1.Text += vbCrLf & "     Found at offset => 0x" + SpriteHeaderDataOffset
                RichTextBox1.Text += vbCrLf & "Searching free space for Sprite Frame Data [" + CStr(SpriteFrameDataSize) + " Bytes]..."
                SpriteFrameDataOffset = SearchFreeSpace((ToDecimal(SpriteHeaderDataOffset) + CInt(TextBox13.Text) + SpriteHeaderDataSize), SpriteFrameDataSize, FreeSpaceByteValue)
                RichTextBox1.Text += vbCrLf & "     Found at offset => 0x" + SpriteFrameDataOffset
                RichTextBox1.Text += vbCrLf & "Searching free space for Sprite Art Data [" + CStr(SpriteArtDataSize) + " Bytes]..."
                SpriteArtDataOffset = SearchFreeSpace((ToDecimal(SpriteFrameDataOffset) + CInt(TextBox13.Text) + SpriteFrameDataSize), SpriteArtDataSize, FreeSpaceByteValue)
                RichTextBox1.Text += vbCrLf & "     Found at offset => 0x" + SpriteArtDataOffset
            Else
                SpriteHeaderDataOffset = GlobalSpriteHeaderDataOffset
                RichTextBox1.Text += "Offset for Sprite Header Data => 0x" + SpriteHeaderDataOffset
                SpriteFrameDataOffset = GlobalSpriteFrameDataOffset
                RichTextBox1.Text += vbCrLf & "Offset for Sprite Frame Data => 0x" + SpriteFrameDataOffset
                SpriteArtDataOffset = GlobalSpriteArtDataOffset
                RichTextBox1.Text += vbCrLf & "Offset for Sprite Art Data => 0x" + SpriteArtDataOffset
            End If
            RichTextBox1.Text += vbCrLf & "Prompting user to proceed to writing..."
            Dim PromptResult As Integer = MessageBox.Show("Do you want to proceed writing Sprite Data to your Rom?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If PromptResult = DialogResult.Yes Then
                RichTextBox1.Text += vbCrLf & "     Proceeding with writing procedure..."
                RichTextBox1.Text += vbCrLf & "Generating Sprite Header Data..."
                Dim SpriteHeaderData As String = ""
                SpriteHeaderData += CurrentPreset.StarterByte
                If ToHex(PaletteNumber).Length = 1 Then
                    SpriteHeaderData += "0"
                End If
                SpriteHeaderData += ToHex(PaletteNumber)
                SpriteHeaderData += CurrentPreset.UnknownFunction1
                SpriteHeaderData += CurrentPreset.Unknown1
                If ToHex(Width).Length = 1 Then
                    SpriteHeaderData += "0"
                End If
                SpriteHeaderData += ToHex(Width)
                SpriteHeaderData += CurrentPreset.UnknownFunction2
                If ToHex(Height).Length = 1 Then
                    SpriteHeaderData += "0"
                End If
                SpriteHeaderData += ToHex(Height)
                SpriteHeaderData += CurrentPreset.UnknownFunction3
                SpriteHeaderData += CurrentPreset.PalRegisters
                SpriteHeaderData += CurrentPreset.Pointer1
                SpriteHeaderData += CurrentPreset.Pointer2
                SpriteHeaderData += CurrentPreset.AnimPointer
                SpriteHeaderData += OffsetToPointer(SpriteFrameDataOffset)
                SpriteHeaderData += CurrentPreset.Pointer4
                'RichTextBox1.Text += vbCrLf & "[" + SpriteHeaderData + "]"
                RichTextBox1.Text += vbCrLf & "     Done!"
                RichTextBox1.Text += vbCrLf & "Generating Sprite Frame Data..."
                Dim SpriteFrameData As String = ""
                Dim SpriteFrameDataAdditional As String = "00"
                Dim j As Integer = 1
                While j <= 4 - ToHex(FrameSize).Length
                    SpriteFrameDataAdditional += "0"
                    j = j + 1
                End While
                SpriteFrameDataAdditional += ToHex(FrameSize) + "00"
                Dim i As Integer = 1
                While i <= NumberOfFrames
                    Dim CurrentFrameArtPointer As String = OffsetToPointer(ToHex(ToDecimal(SpriteArtDataOffset) + (i - 1) * FrameSize))
                    SpriteFrameData += CurrentFrameArtPointer + SpriteFrameDataAdditional
                    i = i + 1
                End While
                'RichTextBox1.Text += vbCrLf & "[" + SpriteFrameData + "]"
                RichTextBox1.Text += vbCrLf & "     Done!"
                RichTextBox1.Text += vbCrLf & "Writing data..."
                Dim WriteResult As Boolean = WriteSpriteData(SpriteHeaderDataOffset,
                          SpriteFrameDataOffset,
                          SpriteArtDataOffset,
                          SpriteHeaderDataSize,
                          SpriteFrameDataSize,
                          SpriteArtDataSize,
                          SpriteHeaderData,
                          SpriteFrameData,
                          SpriteArtDataValue
                    )
                If WriteResult Then
                    RichTextBox1.Text += vbCrLf & "     Done!"
                    RichTextBox1.Text += vbCrLf & "Prompting User for selecting OWS table to insert the created Sprite in..."

                    ' Reading OWS Table Pointers from Rom
                    Dim RomFileReadStream As FileStream
                    RomFileReadStream = File.OpenRead(RomFilePath)
                    RomFileReadStream.Seek(ToDecimal(OWSTableListOffset), SeekOrigin.Begin)
                    Dim Flag As Boolean = True
                    Dim NumberOfOWSButton As Integer = 0
                    Dim NumberOfOWSButtonRow As Integer = 0
                    Dim OWSTableCount As Integer = 0
                    While Flag = True
                        Dim Data As String = ""
                        Dim Buffer(3) As Byte
                        RomFileReadStream.Read(Buffer, 0, 4)
                        For k As Integer = 0 To Buffer.Length - 1
                            Data += Buffer(k).ToString("X2")
                        Next
                        If String.Compare(Data, OWSTableListEmptyDataHex) = 0 Then
                            Flag = False
                            Exit While
                        Else
                            OWSTableCount += 1
                            If OWSTableCount > OWSTableListMaxTables Then
                                MessageBox.Show("OWS Table List contains more than max tables allowed by program. Ignoring rest of the OWS Tables.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Flag = False
                                Exit While
                            End If
                            Dim OWSTablePointerButton As Button = New Button
                            With OWSTablePointerButton
                                .Text = "Table - " + CStr(NumberOfOWSButtonRow * 4 + NumberOfOWSButton) + " [" + PointerToOffset(Data) + "]"
                                .Location = New Point(5 + NumberOfOWSButton * 149, 21 + NumberOfOWSButtonRow * 35)
                                .Width = 131
                            End With
                            AddHandler OWSTablePointerButton.Click, Sub()
                                                                        Dim TableButton As Button = CType(sender, Button)
                                                                        OWSTableOffset = PointerToOffset(Data)
                                                                        PerformSpriteTableInsertion(OffsetToPointer(SpriteHeaderDataOffset))
                                                                    End Sub
                            GroupBox4.Controls.Add(OWSTablePointerButton)
                            NumberOfOWSButton += 1
                            If NumberOfOWSButton >= 4 Then
                                NumberOfOWSButtonRow += 1
                                NumberOfOWSButton = 0
                            End If
                        End If
                    End While
                    RomFileReadStream.Close()
                    GroupBox4.Height = NumberOfOWSButtonRow * 40 + 45
                    GroupBox4.Show()
                    Panel1.Show()
                Else
                    RichTextBox1.Text += vbCrLf & "     Error! Aborting..."
                End If
            ElseIf PromptResult = DialogResult.No Then
                RichTextBox1.Text += vbCrLf & "     Stopped by User!"
                Button6.Enabled = True
            End If
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        RichTextBox1.Hide()
        RichTextBox1.Text = ""
        GroupBox2.Text = "Sprite Template Settings"
        Button6.Enabled = False
        Button6.Hide()
        GroupBox4.Hide()
        GroupBox4.Controls.Clear()
        Panel1.Hide()
    End Sub

    Private Sub RichTextBox1_Change(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged
        RichTextBox1.SelectionStart = RichTextBox1.Text.Length
        RichTextBox1.ScrollToCaret()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form2.Show()
    End Sub

    Private Sub TextBox_Changed(sender As Object, e As EventArgs) Handles TextBox11.Leave
        Dim TextBoxItem As TextBox = CType(sender, TextBox)
        If RomFileLoaded = True Then
            If TextBoxItem.Text <> "" Then
                If TextBoxItem.Text.Length <> 6 Then
                    TextBoxItem.Text = "800000"
                    MessageBox.Show("Offset Value can only be of 6 characters.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    If Not System.Text.RegularExpressions.Regex.IsMatch(TextBoxItem.Text, "\A\b[0-9a-fA-F]+\b\Z") Then
                        TextBoxItem.Text = "800000"
                        MessageBox.Show("Enter a valid hexadecimal offset value!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Form3.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form4.Show()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Form5.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form6.Show()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Form7.Show()
    End Sub

End Class