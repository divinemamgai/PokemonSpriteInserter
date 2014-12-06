﻿Imports System.Text
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
    Public RomLength As Integer = 0

    Dim SpriteHeaderDataOffset As String = ""
    Dim SpriteFrameDataOffset As String = ""
    Dim SpriteArtDataOffset As String = ""
    Dim SpriteHeaderDataSize As Integer = 36
    Dim SpriteFrameDataSize As Integer = 0
    Dim SpriteArtDataSize As Integer = 0

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
            Log.Text += vbCrLf & "Rom File Is In Use! Prompting User To Try Again..."
            Dim DialogBoxResult As Integer = MessageBox.Show("The rom file is in use. Please close any program using the file and click Retry to try again." & vbCrLf & "[Exception.Message : " + ex.Message + "]", "Error!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation)
            If DialogBoxResult = DialogResult.Retry Then
                Log.Text += vbCrLf & "Trying Again To Write Data..."
                GoTo WriteDataTry
            Else
                Log.Text += vbCrLf & "Error! Aborted By User."
                AboutButton.Enabled = True
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
        Log.Text += vbCrLf & "     Writing Sprite Header Data [" + CStr(SpriteHeaderDataSize) + " Bytes]..."
        If WriteData(SpriteHeaderDataOffset, SpriteHeaderDataSize, SpriteHeaderData) = True Then
            Log.Text += vbCrLf & "     Sprite Header Data Write Success!"
            Log.Text += vbCrLf & "     Writing Frame Header Data [" + CStr(SpriteFrameDataSize) + " Bytes]..."
            If WriteData(SpriteFrameDataOffset, SpriteFrameDataSize, SpriteFrameData) = True Then
                Log.Text += vbCrLf & "     Sprite Frame Data Write Success!"
                Log.Text += vbCrLf & "     Writing Art Header Data [" + CStr(SpriteArtDataSize) + " Bytes]..."
                If UseCustomSpriteArtData Then
                    Log.Text += vbCrLf & "          Using Custom Sprite Art Data..."
                    If WriteData(SpriteArtDataOffset, SpriteArtDataSize, CustomSpriteArtData) = True Then
                        Log.Text += vbCrLf & "     Sprite Art Data Write Success!"
                        Return True
                    Else
                        Return False
                    End If
                Else
                    Log.Text += vbCrLf & "          Using Empty Sprite Art Data..."
                    If WriteData(SpriteArtDataOffset, SpriteArtDataSize, SpriteArtData, 1) = True Then
                        Log.Text += vbCrLf & "     Sprite Art Data Write Success!"
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
        SelectOWSTableGroupBox.Hide()
        SelectOWSTablePanel.Hide()
        Log.Text += vbCrLf & "     Using OWS Table At Offset => 0x" + OWSTableOffset
        Log.Text += vbCrLf & "Searching For Free Space In Selected OWS Table [4 Bytes]..."
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
                    Log.Text += vbCrLf & "OWS Table Is Full! Prompting User To Choose OWS Table Again..."
                    MessageBox.Show("OWS Table is full! Please select another table.", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Flag = False
                    Exit While
                End If
            End If
        End While
        RomFileReadStream.Close()
        If Flag = False Then
            SelectOWSTableGroupBox.Show()
            SelectOWSTablePanel.Show()
        Else
            Log.Text += vbCrLf & "     Found At Offset => 0x" + EmptySpriteOffset
            Log.Text += vbCrLf & "Inserting Sprite Pointer To The Selected OWS Table..."
            If WriteData(EmptySpriteOffset, 4, SpritePointer) = True Then
                Log.Text += vbCrLf & "     Done!"
                Log.Text += vbCrLf & "Everything Completed Successfully!"
                BackButton.Enabled = True
            Else
                Log.Text += vbCrLf & "     Error! Aborting..."
                BackButton.Enabled = True
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles OpenRomButton.Click
        If RomFile.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            RomFilePath = RomFile.FileName
            FilePathTextBox.Text = RomFilePath
            If RomLock Then
                If ValidateRom() Then
                    Dim RomFileStream As FileStream
                    RomFileStream = File.OpenRead(RomFilePath)
                    RomLength = RomFileStream.Length
                    RomFileStream.Close()
                    RomStateLabel.Text = "Pokemon Fire Red Rom Detected."
                    RomStateLabel.ForeColor = Color.Green
                    SpriteTemplateSettingsGroupBox.Enabled = True
                    RomFileLoaded = True
                    PaletteInserterButton.Enabled = True
                Else
                    RomStateLabel.Text = "Pokemon Fire Red Rom Not Detected!"
                    RomStateLabel.ForeColor = Color.Red
                    SpriteTemplateSettingsGroupBox.Enabled = False
                    RomFileLoaded = False
                    PaletteInserterButton.Enabled = False
                    MessageBox.Show("This is not Pokemon Fire Red Rom!" & vbCrLf & vbCrLf & "You can disable this check by switching Rom Check to Off state in Settings.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                If ValidateRom() Then
                    Dim RomFileStream As FileStream
                    RomFileStream = File.OpenRead(RomFilePath)
                    RomLength = RomFileStream.Length
                    RomFileStream.Close()
                    RomStateLabel.Text = "Pokemon Fire Red Rom Detected."
                    RomStateLabel.ForeColor = Color.Green
                    SpriteTemplateSettingsGroupBox.Enabled = True
                    RomFileLoaded = True
                    PaletteInserterButton.Enabled = True
                Else
                    Dim RomFileStream As FileStream
                    RomFileStream = File.OpenRead(RomFilePath)
                    RomLength = RomFileStream.Length
                    RomFileStream.Close()
                    RomStateLabel.Text = "Custom Rom Loaded! Use Valid Sprite Preset Data!"
                    RomStateLabel.ForeColor = Color.OrangeRed
                    SpriteTemplateSettingsGroupBox.Enabled = True
                    RomFileLoaded = True
                    PaletteInserterButton.Enabled = True
                End If
            End If
        End If
    End Sub

    Public Sub LoadForm()
        If RomFileLoaded = False Then
            UnknownData1TextBox.Enabled = False
            PalRegistersTextBox.Enabled = False
            Pointer1TextBox.Enabled = False
            Pointer2TextBox.Enabled = False
            AnimPointerTextBox.Enabled = False
            Pointer4TextBox.Enabled = False
            SpriteTemplateSettingsGroupBox.Enabled = False
            PaletteInserterButton.Enabled = False
        End If
        UnknownData1TextBox.Text = CurrentPreset.Unknown1
        PalRegistersTextBox.Text = CurrentPreset.PalRegisters
        Pointer1TextBox.Text = CurrentPreset.Pointer1
        Pointer2TextBox.Text = CurrentPreset.Pointer2
        AnimPointerTextBox.Text = CurrentPreset.AnimPointer
        Pointer4TextBox.Text = CurrentPreset.Pointer4
        UnknownData1TextBox.Tag = CurrentPreset.Unknown1
        PalRegistersTextBox.Tag = CurrentPreset.PalRegisters
        Pointer1TextBox.Tag = CurrentPreset.Pointer1
        Pointer2TextBox.Tag = CurrentPreset.Pointer2
        AnimPointerTextBox.Tag = CurrentPreset.AnimPointer
        Pointer4TextBox.Tag = CurrentPreset.Pointer4
        SpriteDataPresetGroupBox.Text = "Sprite Data Preset [Current : " + CurrentPreset.PresetName + "]"
        Log.Hide()
        BackButton.Hide()
        SelectOWSTableGroupBox.Hide()
        SelectOWSTablePanel.Hide()
        CancelSpriteInsertionButton.Enabled = False
        CancelSpriteInsertionButton.Hide()
        If UseCustomSpriteArtData Then
            CustomSpriteArtButton.Text = "Use Custom Sprite Art Data - On"
        Else
            CustomSpriteArtButton.Text = "Use Custom Sprite Art Data - Off"
        End If
        If RomLock = False Then
            RomStateLabel.Text = "Load a Pokemon Rom."
            FilePathLabel.Text = "Enter or Browse the path to your Pokemon Rom :"
            PokemonRomGroupBox.Text = "Pokemon Rom"
        Else
            RomStateLabel.Text = "Load a Pokemon Fire Red Rom."
            FilePathLabel.Text = "Enter or Browse the path to your Pokemon Fire Red Rom :"
            PokemonRomGroupBox.Text = "Pokemon Fire Red Rom"
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CurrentPreset = SecondaryHero
        Form3.LoadSettings()
        LoadForm()
        Log.BringToFront()
        SelectOWSTablePanel.BringToFront()
        SelectOWSTableGroupBox.BringToFront()
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CustomPresetCheckBox.CheckedChanged
        If CustomPresetCheckBox.Checked = True Then
            UnknownData1TextBox.Enabled = True
            PalRegistersTextBox.Enabled = True
            Pointer1TextBox.Enabled = True
            Pointer2TextBox.Enabled = True
            AnimPointerTextBox.Enabled = True
            Pointer4TextBox.Enabled = True
            SelectDataPresetButton.Enabled = False
        Else
            UnknownData1TextBox.Enabled = False
            PalRegistersTextBox.Enabled = False
            Pointer1TextBox.Enabled = False
            Pointer2TextBox.Enabled = False
            AnimPointerTextBox.Enabled = False
            Pointer4TextBox.Enabled = False
            SelectDataPresetButton.Enabled = True
            LoadForm()
        End If
    End Sub

    Private Sub DigitValidator(sender As Object, e As KeyPressEventArgs) Handles WidthTextBox.KeyPress, HeightTextBox.KeyPress, PaletteNumberTextBox.KeyPress, NumberOfFramesTextBox.KeyPress, SkipBytesTextBox.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If
    End Sub

    Private Sub SpaceValidator(sender As Object, e As KeyPressEventArgs) Handles WidthTextBox.KeyPress, HeightTextBox.KeyPress, PaletteNumberTextBox.KeyPress, NumberOfFramesTextBox.KeyPress, UnknownData1TextBox.KeyPress, PalRegistersTextBox.KeyPress, Pointer1TextBox.KeyPress, Pointer2TextBox.KeyPress, AnimPointerTextBox.KeyPress, StartOffsetTextBox.KeyPress, Pointer4TextBox.KeyPress, SkipBytesTextBox.KeyPress
        If Asc(e.KeyChar) = Keys.Space Then
            e.Handled = True
        End If
    End Sub

    Private Sub SpritePresetDataValidator(sender As Object, e As EventArgs) Handles UnknownData1TextBox.Leave, PalRegistersTextBox.Leave, Pointer1TextBox.Leave, Pointer2TextBox.Leave, AnimPointerTextBox.Leave, Pointer4TextBox.Leave
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

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles UseFreeSpaceFinderCheckBox.CheckedChanged
        If UseFreeSpaceFinderCheckBox.Checked = True Then
            FreeSpaceOffsetsButton.Enabled = False
            FreeSpaceOffsetsButton.Hide()
            StartOffsetTextBox.Enabled = True
            StartOffsetTextBox.Show()
            StartOffsetLabel.Enabled = True
            StartOffsetLabel.Show()
            SkipBytesLabel.Enabled = True
            SkipBytesLabel.Show()
            SkipBytesTextBox.Enabled = True
            SkipBytesTextBox.Show()
            SearchOffsetFlag = True
        Else
            FreeSpaceOffsetsButton.Enabled = True
            FreeSpaceOffsetsButton.Show()
            StartOffsetTextBox.Enabled = False
            StartOffsetTextBox.Hide()
            StartOffsetLabel.Enabled = False
            StartOffsetLabel.Hide()
            SkipBytesLabel.Enabled = False
            SkipBytesLabel.Hide()
            SkipBytesTextBox.Enabled = False
            SkipBytesTextBox.Hide()
            SearchOffsetFlag = False
        End If
    End Sub

    Private Sub TextBox_TextChanged(sender As Object, e As EventArgs) Handles WidthTextBox.TextChanged, HeightTextBox.TextChanged, PaletteNumberTextBox.TextChanged, NumberOfFramesTextBox.TextChanged
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

    Private Sub SkipByteMaxLimitValidator(sender As Object, e As EventArgs) Handles SkipBytesTextBox.TextChanged
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

    Private Sub NonZeroValidator(sender As Object, e As EventArgs) Handles WidthTextBox.TextChanged, HeightTextBox.TextChanged, NumberOfFramesTextBox.TextChanged
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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles StartSpriteInsertionButton.Click
        Dim ErrorFlag As Boolean = False
        Dim Width As Integer
        Dim Height As Integer
        Dim PaletteNumber As Integer
        Dim NumberOfFrames As Integer
        If WidthTextBox.Text <> "" Then
            If CInt(WidthTextBox.Text) > 0 Then
                Width = CInt(WidthTextBox.Text)
            Else
                WidthTextBox.Text = WidthTextBox.Tag
                ErrorFlag = True
                MessageBox.Show("Width cannot be zero or negative!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            WidthTextBox.Text = WidthTextBox.Tag
            ErrorFlag = True
            MessageBox.Show("Width cannot be empty or zero!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        If HeightTextBox.Text <> "" Then
            If CInt(HeightTextBox.Text) > 0 Then
                Height = CInt(HeightTextBox.Text)
            Else
                HeightTextBox.Text = HeightTextBox.Tag
                ErrorFlag = True
                MessageBox.Show("Height cannot be zero or negative!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            HeightTextBox.Text = HeightTextBox.Tag
            ErrorFlag = True
            MessageBox.Show("Height cannot be empty or zero!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        If PaletteNumberTextBox.Text <> "" Then
            PaletteNumber = CInt(PaletteNumberTextBox.Text)
        Else
            PaletteNumberTextBox.Text = PaletteNumberTextBox.Tag
            ErrorFlag = True
            MessageBox.Show("Palette Number cannot be empty!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        If NumberOfFramesTextBox.Text <> "" Then
            If CInt(NumberOfFramesTextBox.Text) > 0 Then
                NumberOfFrames = CInt(NumberOfFramesTextBox.Text)
            Else
                NumberOfFramesTextBox.Text = NumberOfFramesTextBox.Tag
                ErrorFlag = True
                MessageBox.Show("Number Of Frames cannot be zero or negative!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            NumberOfFramesTextBox.Text = NumberOfFramesTextBox.Tag
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
            SpriteHeaderDataSize = 36
            Dim FrameSize As Integer = Width * Height / 2
            SpriteFrameDataSize = 8 * NumberOfFrames
            SpriteArtDataSize = FrameSize * NumberOfFrames
            Log.Show()
            BackButton.Enabled = False
            BackButton.Show()
            SpriteTemplateSettingsGroupBox.Text = "Sprite Data Generation"
            Log.Text = "Starting Sprite Insertion Process..."
            If SearchOffsetFlag = True Then
                Log.Text += vbCrLf & "Searching Free Space For Sprite Header Data [" + CStr(SpriteHeaderDataSize) + " Bytes]..."
                SpriteHeaderDataOffset = SearchFreeSpace(ToDecimal(StartOffsetTextBox.Text), SpriteHeaderDataSize, FreeSpaceByteValue)
                Log.Text += vbCrLf & "     Found At Offset => 0x" + SpriteHeaderDataOffset
                Log.Text += vbCrLf & "Searching Free Space For Sprite Frame Data [" + CStr(SpriteFrameDataSize) + " Bytes]..."
                SpriteFrameDataOffset = SearchFreeSpace((ToDecimal(SpriteHeaderDataOffset) + CInt(SkipBytesTextBox.Text) + SpriteHeaderDataSize), SpriteFrameDataSize, FreeSpaceByteValue)
                Log.Text += vbCrLf & "     Found At Offset => 0x" + SpriteFrameDataOffset
                Log.Text += vbCrLf & "Searching Free Space For Sprite Art Data [" + CStr(SpriteArtDataSize) + " Bytes]..."
                SpriteArtDataOffset = SearchFreeSpace((ToDecimal(SpriteFrameDataOffset) + CInt(SkipBytesTextBox.Text) + SpriteFrameDataSize), SpriteArtDataSize, FreeSpaceByteValue)
                Log.Text += vbCrLf & "     Found At Offset => 0x" + SpriteArtDataOffset
            Else
                SpriteHeaderDataOffset = GlobalSpriteHeaderDataOffset
                Log.Text += "Offset For Sprite Header Data => 0x" + SpriteHeaderDataOffset
                SpriteFrameDataOffset = GlobalSpriteFrameDataOffset
                Log.Text += vbCrLf & "Offset For Sprite Frame Data => 0x" + SpriteFrameDataOffset
                SpriteArtDataOffset = GlobalSpriteArtDataOffset
                Log.Text += vbCrLf & "Offset For Sprite Art Data => 0x" + SpriteArtDataOffset
            End If
            Log.Text += vbCrLf & "Prompting User To Proceed Sprite Insertion Process..."
            Dim PromptResult As Integer = MessageBox.Show("Do you want to proceed writing Sprite Data to your Rom?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If PromptResult = DialogResult.Yes Then
                StartSpriteInsertionButton.Enabled = False
                Log.Text += vbCrLf & "     Proceeding With Sprite Insertion Process..."
                Log.Text += vbCrLf & "Generating Sprite Header Data [" + CStr(SpriteHeaderDataSize) + " Bytes]..."
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
                Log.Text += vbCrLf & "     Done!"
                Log.Text += vbCrLf & "Generating Sprite Frame Data [" + CStr(SpriteFrameDataSize) + " Bytes]..."
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
                Log.Text += vbCrLf & "     Done!"
                Log.Text += vbCrLf & "Writing Data To Rom..."
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
                    Log.Text += vbCrLf & "     Done!"
                    Log.Text += vbCrLf & "Prompting User For Selecting OWS Table To Insert The Created Sprite In..."
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
                                MessageBox.Show("OWS Table List Contains More Than Max Tables Allowed By Program. Ignoring Rest Of The OWS Tables.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
                                                                        Log.Text += vbCrLf & "Prompting User To Proceed Sprite Insertion Process..."
                                                                        Dim PromptTableWriteResult As Integer = MessageBox.Show("Do you want to proceed inserting Sprite to Table - " + CStr(NumberOfOWSButtonRow * 4 + NumberOfOWSButton) + " [" + PointerToOffset(Data) + "] of your Rom?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                                                        If PromptTableWriteResult = DialogResult.Yes Then
                                                                            Log.Text += vbCrLf & "     Proceeding With Sprite Insertion Process..."
                                                                            CancelSpriteInsertionButton.Hide()
                                                                            CancelSpriteInsertionButton.Enabled = False
                                                                            OWSTableOffset = PointerToOffset(Data)
                                                                            PerformSpriteTableInsertion(OffsetToPointer(SpriteHeaderDataOffset))
                                                                        Else
                                                                            Log.Text += vbCrLf & "     Prompting User Again To Select OWS Table To Insert Sprite In..."
                                                                        End If
                                                                    End Sub
                            SelectOWSTableGroupBox.Controls.Add(OWSTablePointerButton)
                            NumberOfOWSButton += 1
                            If NumberOfOWSButton > 3 Then
                                NumberOfOWSButtonRow += 1
                                NumberOfOWSButton = 0
                            End If
                        End If
                    End While
                    RomFileReadStream.Close()
                    SelectOWSTableGroupBox.Height = NumberOfOWSButtonRow * 35 + 57
                    SelectOWSTableGroupBox.Show()
                    SelectOWSTablePanel.Show()
                    CancelSpriteInsertionButton.Enabled = True
                    CancelSpriteInsertionButton.Show()
                Else
                    Log.Text += vbCrLf & "     Error! Aborting..."
                    BackButton.Enabled = True
                    StartSpriteInsertionButton.Enabled = True
                End If
            ElseIf PromptResult = DialogResult.No Then
                Log.Text += vbCrLf & "     Stopped By User!"
                BackButton.Enabled = True
                StartSpriteInsertionButton.Enabled = True
            End If
        End If
    End Sub

    Private Sub BackButtonClick(sender As Object, e As EventArgs) Handles BackButton.Click
        Log.Hide()
        Log.Text = ""
        SpriteTemplateSettingsGroupBox.Text = "Sprite Template Settings"
        BackButton.Enabled = False
        BackButton.Hide()
        SelectOWSTableGroupBox.Hide()
        SelectOWSTableGroupBox.Controls.Clear()
        SelectOWSTablePanel.Hide()
        StartSpriteInsertionButton.Enabled = True
    End Sub

    Private Sub LogChange(sender As Object, e As EventArgs) Handles Log.TextChanged
        Log.SelectionStart = Log.Text.Length
        Log.ScrollToCaret()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles FreeSpaceOffsetsButton.Click
        Form2.Show()
    End Sub

    Private Sub TextBox_Changed(sender As Object, e As EventArgs) Handles StartOffsetTextBox.Leave
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

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles SettingsButton.Click, SettingsButton.Click
        Form3.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles SelectDataPresetButton.Click
        Form4.Show()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles PaletteInserterButton.Click
        Form5.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles AboutButton.Click
        Form6.Show()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles CustomSpriteArtButton.Click
        Form7.Show()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles CancelSpriteInsertionButton.Click
        Dim Result As Integer = MessageBox.Show("Do you really want to cancel the Sprite Insertion process?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Result = DialogResult.Yes Then
            SelectOWSTableGroupBox.Controls.Clear()
            SelectOWSTableGroupBox.Hide()
            SelectOWSTablePanel.Hide()
            CancelSpriteInsertionButton.Enabled = False
            CancelSpriteInsertionButton.Hide()
            Log.Text += vbCrLf & "Starting Cancellation process..."
            Log.Text += vbCrLf & "Rewriting the writed offsets with free space byte..."
            Log.Text += vbCrLf & "     Freeing Sprite Art Data [" + CStr(SpriteArtDataSize) + " Bytes] At Offset => 0x" + SpriteArtDataOffset
            WriteData(SpriteArtDataOffset, SpriteArtDataSize, FreeSpaceByteValue, 1)
            Log.Text += vbCrLf & "          Done!"
            Log.Text += vbCrLf & "     Freeing Sprite Frame Data [" + CStr(SpriteFrameDataSize) + " Bytes] At Offset => 0x" + SpriteFrameDataOffset
            WriteData(SpriteFrameDataOffset, SpriteFrameDataSize, FreeSpaceByteValue, 1)
            Log.Text += vbCrLf & "          Done!"
            Log.Text += vbCrLf & "     Freeing Sprite Header Data [" + CStr(SpriteHeaderDataSize) + " Bytes] At Offset => 0x" + SpriteHeaderDataOffset
            WriteData(SpriteHeaderDataOffset, SpriteHeaderDataSize, FreeSpaceByteValue, 1)
            Log.Text += vbCrLf & "          Done!"
            Log.Text += vbCrLf & "     Free space restoration complete!"
            Log.Text += vbCrLf & "Sprite Insertion successfully cancelled!"
            BackButton.Enabled = True
            StartSpriteInsertionButton.Enabled = True
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles CreateOWSTableButton.Click
        Form8.Show()
    End Sub

End Class