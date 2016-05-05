Imports System.Text
Imports System.IO

Public Class Main

    Public PrimaryHero As Preset = New Preset With {
        .PresetName = "Primary Hero Preset - 16x32 - 20 Frames",
        .StarterByte = "FFFF",
        .UnknownFunction1 = "11",
        .Unknown1 = "02110002",
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
        .PalRegisters = "1A000000",
        .Pointer1 = "20373A08",
        .Pointer2 = "D0383A08",
        .AnimPointer = "68333A08",
        .Pointer4 = "FC1C2308"
    }

    Public CurrentPreset As Preset

    'Palette Fix
    Dim PaletteFixOneData As String = "70880907090F002901D005E0"
    Dim PaletteFixOneOffset As String = "05E5E0"
    Dim PaletteFixTwoData As String = "03E0"
    Dim PaletteFixTwoOffset As String = "05E5F8"

    Public RomFileLoaded As Boolean = False
    Public SearchOffsetFlag As Boolean = True
    Public RomFilePath As String = ""
    Public OWSTableOffset As String = ""

    Public FreeSpaceByteValue As String = ""
    Public SpriteArtDataValue As String = ""
    Public OWSTableListOffset As String = ""
    Public OWSTableListEmptyDataHex As String = ""
    Public OWSTableEmptyDataHex As String = ""
    Public OWSTableListMaxTables As Integer = 0
    Public OWSTableMaxSprites As Integer = 0
    Public RomLock As Boolean = True
    Public PaletteTableOffset As String = ""
    Public MaxPalette As Integer = 0
    Public PaletteTableEndHex As String = ""
    Public PaletteTableEmptyDataHex As String = ""
    Public CheckForUpdateOnStart As Boolean = False
    Public MaxSpriteFrameCount As Integer = 20 ' For Now.
    Public RecentRoms As String = ""

    Public GlobalSpriteHeaderDataOffset As String = ""
    Public GlobalSpriteFrameDataOffset As String = ""
    Public GlobalSpriteArtDataOffset As String = ""
    Public UseCustomSpriteArtData As Boolean = False
    Public CustomSpriteArtData As String = ""
    Public RomLength As Integer = 0

    Public SpriteHeaderDataOffset As String = ""
    Public SpriteFrameDataOffset As String = ""
    Public SpriteArtDataOffset As String = ""
    Public SpriteHeaderDataSize As Integer = 36
    Public PaletteDataSize As Integer = 32
    Public SpriteFrameDataSize As Integer = 0
    Public SpriteArtDataSize As Integer = 0

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
                    MessageBox.Show("Selected OWS Table [0x" + OWSTableOffset + "] is full! Please select another table." & vbCrLf & vbCrLf & "Note : You can increase max OWS table sprites in the settings.", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Flag = False
                    Exit While
                End If
            End If
        End While
        RomFileReadStream.Close()
        If Flag = False Then
            SelectOWSTableGroupBox.Show()
            SelectOWSTablePanel.Show()
            CancelSpriteInsertionButton.Enabled = True
            CancelSpriteInsertionButton.Show()
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

    Private Sub OpenRomButtonClick(sender As Object, e As EventArgs) Handles OpenRomButton.Click
        RomFile.Filter = "GBA Files (*.gba*)|*.gba"
        RomFile.Title = "Load GBA Rom"
        Try
            If RomFile.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
                OpenRom(RomFile.FileName)
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred while opening the rom!" & vbCrLf & vbCrLf & "Exception.Message : " + ex.Message, "Error In Opening Rom!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub OpenRom(ByVal FilePath As String)
        RomFilePath = FilePath
        FilePathTextBox.Text = RomFilePath
        If RomLock Then
            If ValidateRom() Then
                Dim RomFileStream As FileStream
                RomFileStream = File.OpenRead(RomFilePath)
                RomLength = RomFileStream.Length
                RomFileStream.Close()
                StartOffsetTextBox.MaxLength = 6    'Can't be more than 6 - Even if it can it can only be of multiples of 2!
                RomStateLabel.Text = "Pokemon Fire Red Rom Detected."
                RomStateLabel.ForeColor = Color.Green
                SpriteTemplateSettingsGroupBox.Enabled = True
                RomFileLoaded = True
                PaletteInserterButton.Enabled = True
                TableBrowserButton.Enabled = True
                SpritePatchCreatorButton.Enabled = True
                ApplySpritePatchButton.Enabled = True
                AddRecentRom(RomFilePath, RecentRoms)
            Else
                RomStateLabel.Text = "Pokemon Fire Red Rom Not Detected!"
                RomStateLabel.ForeColor = Color.Red
                SpriteTemplateSettingsGroupBox.Enabled = False
                RomFileLoaded = False
                PaletteInserterButton.Enabled = False
                TableBrowserButton.Enabled = False
                SpritePatchCreatorButton.Enabled = False
                ApplySpritePatchButton.Enabled = False
                MessageBox.Show("This is not Pokemon Fire Red Rom!" & vbCrLf & vbCrLf & "You can disable this check by switching Rom Check to Off state in Settings.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            If ValidateRom() Then
                Dim RomFileStream As FileStream
                RomFileStream = File.OpenRead(RomFilePath)
                RomLength = RomFileStream.Length
                RomFileStream.Close()
                StartOffsetTextBox.MaxLength = 6    'Can't be more than 6 - Even if it can it can only be of multiples of 2!
                RomStateLabel.Text = "Pokemon Fire Red Rom Detected."
                RomStateLabel.ForeColor = Color.Green
                SpriteTemplateSettingsGroupBox.Enabled = True
                RomFileLoaded = True
                PaletteInserterButton.Enabled = True
                TableBrowserButton.Enabled = True
                SpritePatchCreatorButton.Enabled = True
                ApplySpritePatchButton.Enabled = True
                AddRecentRom(RomFilePath, RecentRoms)
            Else
                Dim RomFileStream As FileStream
                RomFileStream = File.OpenRead(RomFilePath)
                RomLength = RomFileStream.Length
                RomFileStream.Close()
                StartOffsetTextBox.MaxLength = 6    'Can't be more than 6 - Even if it can it can only be of multiples of 2!
                RomStateLabel.Text = "Custom Rom Loaded! Use Valid Data!"
                RomStateLabel.ForeColor = Color.OrangeRed
                SpriteTemplateSettingsGroupBox.Enabled = True
                RomFileLoaded = True
                PaletteInserterButton.Enabled = True
                TableBrowserButton.Enabled = True
                'ApplySpritePatchButton.Enabled = True
                AddRecentRom(RomFilePath, RecentRoms)
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
            ApplySpritePatchButton.Enabled = False
            TableBrowserButton.Enabled = False
            SpritePatchCreatorButton.Enabled = False
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
            RomStateLabel.Text = "Load a Pokemon Fire Red Or Emerald Rom."
            FilePathLabel.Text = "Enter or Browse the path to your Pokemon Fire Red Or Emerald Rom :"
            PokemonRomGroupBox.Text = "Pokemon Fire Red Or Emerald Rom"
        End If
    End Sub

    Private Sub MainLoad(sender As Object, e As EventArgs) Handles MyBase.Load
        CurrentPreset = SecondaryHero
        Settings.LoadSettings()
        LoadForm()
        Log.BackColor = Color.White
        Log.BringToFront()
        SelectOWSTablePanel.BringToFront()
        SelectOWSTableGroupBox.BringToFront()
        HistoryButton.Enabled = False
        If CheckForUpdateOnStart = True Then
            UpdateChecker.RunWorkerAsync()
        End If
        ProcessRecentRoms(RecentRomsMenu, RecentRoms)
    End Sub

    Private Sub UpdateCheckerDoWork(sender As Object, e As EventArgs) Handles UpdateChecker.DoWork
        CheckForUpdate()
    End Sub

    Private Sub CustomPresetCheckBoxCheckedChanged(sender As Object, e As EventArgs) Handles CustomPresetCheckBox.CheckedChanged
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

    Private Sub UseFreeSpaceFinderCheckBoxCheckedChanged(sender As Object, e As EventArgs) Handles UseFreeSpaceFinderCheckBox.CheckedChanged
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

    Private Sub StartSpriteInsertionButtonClick(sender As Object, e As EventArgs) Handles StartSpriteInsertionButton.Click
        'Assemble some variables.
        Dim ErrorFlag As Boolean = False
        Dim Width As Integer = 0
        Dim Height As Integer = 0
        Dim PaletteNumber As Integer = 0
        Dim NumberOfFrames As Integer = 0
        'Checks The Values, even if they can be ignored, let's just keep them.
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
        'This check cannot be ignored!
        If SearchOffsetFlag = False Then
            If Not GlobalSpriteHeaderDataOffset <> "" Then
                MessageBox.Show("Sprite Header Data Offset cannot be zero!" & vbCrLf & "Please set Free Space Offset.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ErrorFlag = True
            End If
            If Not GlobalSpriteFrameDataOffset <> "" Then
                MessageBox.Show("Sprite Frame Data Offset cannot be zero!" & vbCrLf & "Please set Free Space Offset.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ErrorFlag = True
            End If
            If Not GlobalSpriteArtDataOffset <> "" Then
                MessageBox.Show("Sprite Art Data Offset cannot be zero!" & vbCrLf & "Please set Free Space Offset.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ErrorFlag = True
            End If
        End If
        'If No errors occurred let's proceed!
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
            Dim PromptResult As Integer = MessageBox.Show("Do you want to proceed with the Sprite Insertion process?" & vbCrLf & vbCrLf & "Note : This process is reversible in the next screen.", "Proceed With Sprite Data Writing?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If PromptResult = DialogResult.Yes Then
                StartSpriteInsertionButton.Enabled = False
                Log.Text += vbCrLf & "     Proceeding With Sprite Insertion Process..."
                Log.Text += vbCrLf & "Generating Sprite Header Data [" + CStr(SpriteHeaderDataSize) + " Bytes]..."
                Dim SpriteHeaderData As String = ""
                SpriteHeaderData += CurrentPreset.StarterByte
                SpriteHeaderData += ToHex(PaletteNumber, 2)
                SpriteHeaderData += CurrentPreset.UnknownFunction1
                SpriteHeaderData += CurrentPreset.Unknown1
                SpriteHeaderData += SplitString(ToHex(Width, 4), 2)(1)
                SpriteHeaderData += SplitString(ToHex(Width, 4), 2)(0)
                SpriteHeaderData += SplitString(ToHex(Height, 4), 2)(1)
                SpriteHeaderData += SplitString(ToHex(Height, 4), 2)(0)
                SpriteHeaderData += CurrentPreset.PalRegisters
                SpriteHeaderData += CurrentPreset.Pointer1
                SpriteHeaderData += CurrentPreset.Pointer2
                SpriteHeaderData += CurrentPreset.AnimPointer
                SpriteHeaderData += OffsetToPointer(SpriteFrameDataOffset)
                SpriteHeaderData += CurrentPreset.Pointer4
                If SpriteHeaderData.Length / 2 <> SpriteHeaderDataSize Then
                    Log.Text += vbCrLf & "     Internal Error Occurred! Aborting..." + CStr(SpriteHeaderData.Length / 2) & vbCrLf & ToHex(PaletteNumber, 2)
                    BackButton.Enabled = True
                    StartSpriteInsertionButton.Enabled = True
                    Return
                End If
                Log.Text += vbCrLf & "     Done!"
                Log.Text += vbCrLf & "Generating Sprite Frame Data [" + CStr(SpriteFrameDataSize) + " Bytes]..."
                Dim SpriteFrameData As String = ""
                'Size Is In Reversed Bytes!
                'Also Adding A Note Of How Many Frames This Sprite Has Doesn't Interfere With The Game, But It's Still An Experimental Feature.
                'This Will Help In Accurate And Fast Data Processing!
                'Until An Alternative Is Found.
                Dim SpriteFrameDataAdditional As String = SplitString(ToHex(FrameSize, 4), 2)(1) + SplitString(ToHex(FrameSize, 4), 2)(0) + ToHex(NumberOfFrames, 2) + "00"
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
                                MessageBox.Show("OWS Table List contains more than max table list limit (" + CStr(OWSTableListMaxTables) + ")! Ignoring rest of the tables.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Flag = False
                                Exit While
                            End If
                            Dim OWSTablePointerButton As Button = New Button
                            With OWSTablePointerButton
                                .Text = "Table - " + CStr(NumberOfOWSButtonRow * 4 + NumberOfOWSButton) + " [" + PointerToOffset(Data) + "]"
                                .Location = New Point(5 + NumberOfOWSButton * 149, 21 + NumberOfOWSButtonRow * 35)
                                .Width = 131
                                .Tag = PointerToOffset(Data)
                            End With
                            AddHandler OWSTablePointerButton.Click, Sub(senderbutton As Object, ebutton As EventArgs)
                                                                        Dim ButtonElement As Button = DirectCast(senderbutton, Button)
                                                                        Log.Text += vbCrLf & "Prompting User To Proceed Sprite Insertion Process..."
                                                                        Dim PromptTableWriteResult As Integer = MessageBox.Show("Do you want to proceed inserting sprite to " + ButtonElement.Text + "?", "Proceed With Sprite Table Insertion?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                                                        If PromptTableWriteResult = DialogResult.Yes Then
                                                                            Log.Text += vbCrLf & "     Proceeding With Sprite Insertion Process..."
                                                                            CancelSpriteInsertionButton.Hide()
                                                                            CancelSpriteInsertionButton.Enabled = False
                                                                            OWSTableOffset = ButtonElement.Tag
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
                    SelectOWSTableGroupBox.Height = If(NumberOfOWSButton > 0, NumberOfOWSButtonRow, NumberOfOWSButtonRow - 1) * 35 + 57
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

    Private Sub CancelSpriteInsertion(Optional ByVal Prompt As Boolean = True)
        Dim Result As Integer
        If Prompt = True Then
            Result = MessageBox.Show("Do you really want to cancel the sprite insertion process?" & vbCrLf & vbCrLf & "Your rom will be restored to it's original state on cancelation.", "Cancel Sprite Insertion?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        Else
            Return
        End If
        If Result = DialogResult.Yes Then
            SelectOWSTableGroupBox.Controls.Clear()
            SelectOWSTableGroupBox.Hide()
            SelectOWSTablePanel.Hide()
            CancelSpriteInsertionButton.Enabled = False
            CancelSpriteInsertionButton.Hide()
            Log.Text += vbCrLf & "Starting Cancellation Process..."
            Log.Text += vbCrLf & "Rewriting The Writed Offsets With Free Space Byte..."
            Log.Text += vbCrLf & "     Freeing Sprite Art Data [" + CStr(SpriteArtDataSize) + " Bytes] At Offset => 0x" + SpriteArtDataOffset
            If WriteData(SpriteArtDataOffset, SpriteArtDataSize, FreeSpaceByteValue, 1) = False Then
                MessageBox.Show("An Error occured while freeing sprite art data!", "Cancellation Process - Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Log.Text += vbCrLf & "          Done!"
            Log.Text += vbCrLf & "     Freeing Sprite Frame Data [" + CStr(SpriteFrameDataSize) + " Bytes] At Offset => 0x" + SpriteFrameDataOffset
            If WriteData(SpriteFrameDataOffset, SpriteFrameDataSize, FreeSpaceByteValue, 1) = False Then
                MessageBox.Show("An Error occured while freeing sprite frame data!", "Cancellation Process - Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Log.Text += vbCrLf & "          Done!"
            Log.Text += vbCrLf & "     Freeing Sprite Header Data [" + CStr(SpriteHeaderDataSize) + " Bytes] At Offset => 0x" + SpriteHeaderDataOffset
            If WriteData(SpriteHeaderDataOffset, SpriteHeaderDataSize, FreeSpaceByteValue, 1) = False Then
                MessageBox.Show("An Error occured while freeing sprite header data!", "Cancellation Process - Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Log.Text += vbCrLf & "          Done!"
            Log.Text += vbCrLf & "     Free Space Restoration Complete!"
            Log.Text += vbCrLf & "Sprite Insertion Successfully Cancelled!"
            BackButton.Enabled = True
            StartSpriteInsertionButton.Enabled = True
        End If
    End Sub

    Private Sub CancelSpriteInsertionButtonClick(sender As Object, e As EventArgs) Handles CancelSpriteInsertionButton.Click
        CancelSpriteInsertion(True)
    End Sub

    Private Sub PaletteFixButtonClick(sender As Object, e As EventArgs) Handles PaletteFixButton.Click
        Dim Result As Integer = MessageBox.Show("Do you really want to apply the palette fix?" & vbCrLf & vbCrLf & "Note : After applying this fix the default palettes were no longer compatible with the new OWS Tables. So insert new palettes for the new tables even if you are using a sprite of the original table, make sure to add required palette for that sprite.", "Apply Palette Fix", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Result = DialogResult.Yes Then
            If WriteData(PaletteFixOneOffset, PaletteFixOneData.Length / 2, PaletteFixOneData) = True Then
                If WriteData(PaletteFixTwoOffset, PaletteFixTwoData.Length / 2, PaletteFixTwoData) = True Then
                    MessageBox.Show("Done! Palette Fix has been applied to your rom successfully!", "Palette Fix - Completed!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("An Error occured while applying the fix!", "Palette Fix - Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("An Error occured while applying the fix!", "Palette Fix - Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub LogChange(sender As Object, e As EventArgs) Handles Log.TextChanged
        Log.SelectionStart = Log.Text.Length
        Log.ScrollToCaret()
    End Sub

    Private Sub FreeSpaceOffsetsButtonClick(sender As Object, e As EventArgs) Handles FreeSpaceOffsetsButton.Click
        FreeSpaceOffsetsDialog.ShowDialog()
    End Sub

    Private Sub SettingsButtonClick(sender As Object, e As EventArgs) Handles SettingsButton.Click
        Settings.Show()
    End Sub

    Private Sub SelectDataPresetButtonClick(sender As Object, e As EventArgs) Handles SelectDataPresetButton.Click
        SpritePresets.Show()
    End Sub

    Private Sub PaletteInserterButtonClick(sender As Object, e As EventArgs) Handles PaletteInserterButton.Click
        PaletteAdder.Show()
    End Sub

    Private Sub AboutButtonClick(sender As Object, e As EventArgs) Handles AboutButton.Click
        About.Show()
    End Sub

    Private Sub CustomSpriteArtButtonClick(sender As Object, e As EventArgs) Handles CustomSpriteArtButton.Click
        CustomArtData.Show()
    End Sub

    Private Sub CreateOWSTableButtonClick(sender As Object, e As EventArgs) Handles CreateOWSTableButton.Click
        CreateOWSTable.Show()
    End Sub

    Private Sub ViewTableButtonClick(sender As Object, e As EventArgs) Handles TableBrowserButton.Click
        ViewTables.Show()
    End Sub

    Private Sub SpritePatchCreatorButtonClick(sender As Object, e As EventArgs) Handles SpritePatchCreatorButton.Click
        SpritePatchCreator.Show()
    End Sub

    Private Sub ApplySpritePatchButtonClick(sender As Object, e As EventArgs) Handles ApplySpritePatchButton.Click
        Dim Result As Integer = MessageBox.Show("Do you want to apply sprite patch for Fire Red rom?" & vbCrLf & vbCrLf & "This patch allows program to work safely and switfly and accurately with Table Browser. This is because it caches the number of frames in a Sprite in the Sprite Header.", "Apply Sprite Patch?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Result = DialogResult.Yes Then
            ApplySpritePatch()
            MessageBox.Show("Sprite Patch has been applied.", "Sprite Patch Applied!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

#Region "Validation"
    Private Sub ApplyValidations() Handles Me.Load
        Dim AllTextBoxControlsInSpriteTemplate = SpriteTemplateSettingsGroupBox.Controls.OfType(Of TextBox)()
        For Each ControlElement In AllTextBoxControlsInSpriteTemplate
            If CStr(ControlElement.Tag) <> "" Then
                AddHandler ControlElement.KeyPress, AddressOf SpaceValidator
                AddHandler ControlElement.Leave, AddressOf NullValidator
                Select Case ControlElement.Name
                    Case "StartOffsetTextBox"
                        AddHandler ControlElement.Leave, AddressOf OffsetValidator
                        AddHandler ControlElement.KeyPress, AddressOf HexInputValidator
                    Case "SkipBytesTextBox"
                        AddHandler ControlElement.TextChanged, AddressOf SetMaxLimitBytes
                        AddHandler ControlElement.TextChanged, AddressOf MaxLimitValidator
                    Case Else
                        If (String.Compare(ControlElement.Name, "PaletteNumberTextBox") <> 0) Then
                            AddHandler ControlElement.TextChanged, AddressOf NonZeroValidator
                        End If
                        AddHandler ControlElement.TextChanged, AddressOf SetMaxLimitDefault
                        AddHandler ControlElement.TextChanged, AddressOf MaxLimitValidator
                        AddHandler ControlElement.KeyPress, AddressOf DigitValidator
                End Select
            End If
        Next
        Dim AllTextBoxControlsInSpriteDataPreset = SpriteDataPresetGroupBox.Controls.OfType(Of TextBox)()
        For Each ControlElement In AllTextBoxControlsInSpriteDataPreset
            AddHandler ControlElement.KeyPress, AddressOf SpaceValidator
            AddHandler ControlElement.Leave, AddressOf NullValidator
            AddHandler ControlElement.Leave, AddressOf HexValueValidator
            AddHandler ControlElement.KeyPress, AddressOf HexInputValidator
        Next
    End Sub
#End Region

End Class