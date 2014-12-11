Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO

Public Class Settings

    <Serializable()>
    Public Structure SettingsData
        Dim FreeSpaceByteValue As String
        Dim SpriteArtDataValue As String
        Dim OWSTableListOffset As String
        Dim OWSTableListEmptyDataHex As String
        Dim OWSTableEmptyDataHex As String
        Dim OWSTableListMaxTables As Integer
        Dim OWSTableMaxSprites As Integer
        Dim RomLock As Integer
        Dim PaletteTableOffset As String
        Dim MaxPalette As Integer
        Dim PaletteTableEndHex As String
        Dim PaletteTableEmptyDataHex As String
    End Structure

    Public RomLock As Boolean = Main.RomLock
    Public SettingsDataVar As SettingsData

    Private Sub DefaultSettings(Optional ByVal Force As Boolean = False)
        FreeSpaceByteTextBox.Text = "FF"
        FreeSpaceByteTextBox.Tag = "FF"
        SpriteArtDataByteTextBox.Text = "BB"
        SpriteArtDataByteTextBox.Tag = "BB"
        OWSTableListOffsetTextBox.Text = "1A2000"
        OWSTableListOffsetTextBox.Tag = "1A2000"
        TableListEmptyDataTextBox.Text = "00000000"
        TableListEmptyDataTextBox.Tag = "00000000"
        TableEmptyDataTextBox.Text = "00000000"
        TableEmptyDataTextBox.Tag = "00000000"
        TableListMaxTextBox.Text = 100
        TableListMaxTextBox.Tag = 100
        TableMaxSpritesTextBox.Text = 152
        TableMaxSpritesTextBox.Tag = 152
        PaletteTableOffsetTextBox.Text = "1A2400"
        PaletteTableOffsetTextBox.Tag = "1A2400"
        MaxPaletteTextBox.Text = 100
        MaxPaletteTextBox.Tag = 100
        PaletteTableEndTextBox.Text = "00000000FF110000"
        PaletteTableEndTextBox.Tag = "00000000FF110000"
        PaletteTableEmptyDataHexTextBox.Text = "0000000000000000"
        PaletteTableEmptyDataHexTextBox.Tag = "0000000000000000"
        RomLock = True
        RomCheckButton.Text = "Rom Check - On"
        If Force = True Then
            SettingsDataVar.FreeSpaceByteValue = "FF"
            SettingsDataVar.SpriteArtDataValue = "BB"
            SettingsDataVar.OWSTableListOffset = "1A2000"
            SettingsDataVar.OWSTableListEmptyDataHex = "00000000"
            SettingsDataVar.OWSTableEmptyDataHex = "00000000"
            SettingsDataVar.OWSTableListMaxTables = 100
            SettingsDataVar.OWSTableMaxSprites = 152
            SettingsDataVar.PaletteTableOffset = "1A2400"
            SettingsDataVar.MaxPalette = 100
            SettingsDataVar.PaletteTableEndHex = "00000000FF110000"
            SettingsDataVar.PaletteTableEmptyDataHex = "0000000000000000"
            SettingsDataVar.RomLock = True
        End If
    End Sub

    Public Sub LoadSettings()
        Dim InputFormatter As BinaryFormatter = New BinaryFormatter()
        If File.Exists(SettingsFilePath) Then
            Dim DataFileStream As FileStream = Nothing
            Try
                DataFileStream = File.Open(SettingsFilePath, FileMode.Open, FileAccess.Read)
                SettingsDataVar = CType(InputFormatter.Deserialize(DataFileStream), SettingsData)
                DataFileStream.Close()
            Catch ex As System.Runtime.Serialization.SerializationException
                DataFileStream.Close()
                File.Delete(SettingsFilePath)
                LoadSettings()
            Catch ex As System.OutOfMemoryException
                DataFileStream.Close()
                File.Delete(SettingsFilePath)
                LoadSettings()
            Catch ex As Exception
                Dim Result As Integer = MessageBox.Show("An error occurred while reading the settings.bin file. Please take a look at message below. Most likely the issue is of access so if you have the program installed in protected drive (Eg. C:) then run the prorgam as Administrator." & vbCrLf & vbCrLf & ex.Message & vbCrLf & vbCrLf & "Do you want to run the program with Administrator rights now?", "Error!", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
                If Result = DialogResult.Yes Then
                    Dim ProcessInfo As New ProcessStartInfo
                    Dim ProcessExec As New Process
                    With ProcessInfo
                        .UseShellExecute = True
                        .FileName = Application.ExecutablePath()
                        .WindowStyle = ProcessWindowStyle.Normal
                        .Verb = "runas"
                    End With
                    Application.Exit()
                    ProcessExec = Process.Start(ProcessInfo)
                Else
                    Environment.Exit(0)
                End If
            End Try
        Else
            DefaultSettings(True)
            UpdateSettingsFile()
        End If
        Dim ErrorFlag As Boolean = False
        If IsNothing(SettingsDataVar.FreeSpaceByteValue) = True Then
            ErrorFlag = True
        End If
        If IsNothing(SettingsDataVar.SpriteArtDataValue) = True Then
            ErrorFlag = True
        End If
        If IsNothing(SettingsDataVar.OWSTableListOffset) = True Then
            ErrorFlag = True
        End If
        If IsNothing(SettingsDataVar.OWSTableListEmptyDataHex) = True Then
            ErrorFlag = True
        End If
        If IsNothing(SettingsDataVar.OWSTableEmptyDataHex) = True Then
            ErrorFlag = True
        End If
        If IsNothing(SettingsDataVar.OWSTableListMaxTables) = True Then
            ErrorFlag = True
        End If
        If IsNothing(SettingsDataVar.OWSTableMaxSprites) = True Then
            ErrorFlag = True
        End If
        If IsNothing(SettingsDataVar.RomLock) = True Then
            ErrorFlag = True
        End If
        If IsNothing(SettingsDataVar.PaletteTableOffset) = True Then
            ErrorFlag = True
        End If
        If IsNothing(SettingsDataVar.MaxPalette) = True Then
            ErrorFlag = True
        End If
        If IsNothing(SettingsDataVar.PaletteTableEndHex) = True Then
            ErrorFlag = True
        End If
        If IsNothing(SettingsDataVar.PaletteTableEmptyDataHex) = True Then
            ErrorFlag = True
        End If
        If ErrorFlag = True Then
            MessageBox.Show("It seems that the Settings values are corrupted or the older version settings are no longer compatible." & vbCrLf & vbCrLf & "Loading default settings to ensure that program continues to function properly.", "Pokemon Sprite Inserter - Settings Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            File.Delete(SettingsFilePath)
            LoadSettings()
        Else
            Main.FreeSpaceByteValue = SettingsDataVar.FreeSpaceByteValue
            Main.SpriteArtDataValue = SettingsDataVar.SpriteArtDataValue
            Main.OWSTableListOffset = SettingsDataVar.OWSTableListOffset
            Main.OWSTableListEmptyDataHex = SettingsDataVar.OWSTableListEmptyDataHex
            Main.OWSTableEmptyDataHex = SettingsDataVar.OWSTableEmptyDataHex
            Main.OWSTableListMaxTables = SettingsDataVar.OWSTableListMaxTables
            Main.OWSTableMaxSprites = SettingsDataVar.OWSTableMaxSprites
            Main.RomLock = SettingsDataVar.RomLock
            Main.PaletteTableOffset = SettingsDataVar.PaletteTableOffset
            Main.MaxPalette = SettingsDataVar.MaxPalette
            Main.PaletteTableEndHex = SettingsDataVar.PaletteTableEndHex
            Main.PaletteTableEmptyDataHex = SettingsDataVar.PaletteTableEmptyDataHex
        End If
    End Sub

    Public Sub UpdateSettingsFile()
        If Not Directory.Exists(ProgramDataPath) Then
            Directory.CreateDirectory(ProgramDataPath)
        End If
        Dim SettingsDataVarTemp As SettingsData = New SettingsData With {
            .FreeSpaceByteValue = FreeSpaceByteTextBox.Text,
            .SpriteArtDataValue = SpriteArtDataByteTextBox.Text,
            .OWSTableListOffset = OWSTableListOffsetTextBox.Text,
            .OWSTableListEmptyDataHex = TableListEmptyDataTextBox.Text,
            .OWSTableEmptyDataHex = TableEmptyDataTextBox.Text,
            .OWSTableListMaxTables = CInt(TableListMaxTextBox.Text),
            .OWSTableMaxSprites = CInt(TableMaxSpritesTextBox.Text),
            .RomLock = RomLock,
            .PaletteTableOffset = PaletteTableOffsetTextBox.Text,
            .MaxPalette = CInt(MaxPaletteTextBox.Text),
            .PaletteTableEndHex = PaletteTableEndTextBox.Text,
            .PaletteTableEmptyDataHex = PaletteTableEmptyDataHexTextBox.Text
        }
        Dim UpdateFormatter As BinaryFormatter = New BinaryFormatter()
        Try
            Dim DataFileStream As FileStream
            DataFileStream = File.Open(SettingsFilePath, FileMode.OpenOrCreate, FileAccess.Write)
            DataFileStream.Flush()
            UpdateFormatter.Serialize(DataFileStream, SettingsDataVarTemp)
            DataFileStream.Close()
        Catch ex As Exception
            Dim Result As Integer = MessageBox.Show("An error occurred while reading the settings.bin file. Please take a look at message below. Most likely the issue is of access so if you have the program installed in protected drive (Eg. C:) then run the prorgam as Administrator." & vbCrLf & vbCrLf & ex.Message & vbCrLf & vbCrLf & "Do you want to run the program with Administrator rights now?", "Error!", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
            If Result = DialogResult.Yes Then
                Dim ProcessInfo As New ProcessStartInfo
                Dim ProcessExec As New Process
                With ProcessInfo
                    .UseShellExecute = True
                    .FileName = Application.ExecutablePath()
                    .WindowStyle = ProcessWindowStyle.Normal
                    .Verb = "runas"
                End With
                Application.Exit()
                ProcessExec = Process.Start(ProcessInfo)
            Else
                Environment.Exit(0)
            End If
        End Try
    End Sub

    Private Sub Form3Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSettings()
        FreeSpaceByteTextBox.Text = SettingsDataVar.FreeSpaceByteValue
        FreeSpaceByteTextBox.Tag = SettingsDataVar.FreeSpaceByteValue
        SpriteArtDataByteTextBox.Text = SettingsDataVar.SpriteArtDataValue
        SpriteArtDataByteTextBox.Tag = SettingsDataVar.SpriteArtDataValue
        OWSTableListOffsetTextBox.Text = SettingsDataVar.OWSTableListOffset
        OWSTableListOffsetTextBox.Tag = SettingsDataVar.OWSTableListOffset
        TableListEmptyDataTextBox.Text = SettingsDataVar.OWSTableListEmptyDataHex
        TableListEmptyDataTextBox.Tag = SettingsDataVar.OWSTableListEmptyDataHex
        TableEmptyDataTextBox.Text = SettingsDataVar.OWSTableEmptyDataHex
        TableEmptyDataTextBox.Tag = SettingsDataVar.OWSTableEmptyDataHex
        TableListMaxTextBox.Text = SettingsDataVar.OWSTableListMaxTables
        TableListMaxTextBox.Tag = SettingsDataVar.OWSTableListMaxTables
        TableMaxSpritesTextBox.Text = SettingsDataVar.OWSTableMaxSprites
        TableMaxSpritesTextBox.Tag = SettingsDataVar.OWSTableMaxSprites
        PaletteTableOffsetTextBox.Text = SettingsDataVar.PaletteTableOffset
        PaletteTableOffsetTextBox.Tag = SettingsDataVar.PaletteTableOffset
        MaxPaletteTextBox.Text = SettingsDataVar.MaxPalette
        MaxPaletteTextBox.Tag = SettingsDataVar.MaxPalette
        PaletteTableEndTextBox.Text = SettingsDataVar.PaletteTableEndHex
        PaletteTableEndTextBox.Tag = SettingsDataVar.PaletteTableEndHex
        PaletteTableEmptyDataHexTextBox.Text = SettingsDataVar.PaletteTableEmptyDataHex
        PaletteTableEmptyDataHexTextBox.Tag = SettingsDataVar.PaletteTableEmptyDataHex
        RomLock = SettingsDataVar.RomLock
        If RomLock = True Then
            RomCheckButton.Text = "Rom Check - On"
        Else
            RomCheckButton.Text = "Rom Check - Off"
        End If
        If Main.RomFileLoaded = True Then
            OWSTableListOffsetTextBox.MaxLength = 6
            PaletteTableOffsetTextBox.MaxLength = 6
        End If
    End Sub

    Private Sub SaveSettingsButtonClick(sender As Object, e As EventArgs) Handles SaveSettingsButton.Click
        Main.FreeSpaceByteValue = FreeSpaceByteTextBox.Text
        Main.SpriteArtDataValue = SpriteArtDataByteTextBox.Text
        Main.OWSTableListOffset = OWSTableListOffsetTextBox.Text
        Main.OWSTableListEmptyDataHex = TableListEmptyDataTextBox.Text
        Main.OWSTableEmptyDataHex = TableEmptyDataTextBox.Text
        Main.OWSTableListMaxTables = CInt(TableListMaxTextBox.Text)
        Main.OWSTableMaxSprites = CInt(TableMaxSpritesTextBox.Text)
        Main.RomLock = RomLock
        Main.PaletteTableOffset = PaletteTableOffsetTextBox.Text
        Main.MaxPalette = CInt(MaxPaletteTextBox.Text)
        Main.PaletteTableEndHex = PaletteTableEndTextBox.Text
        Main.PaletteTableEmptyDataHex = PaletteTableEmptyDataHexTextBox.Text
        UpdateSettingsFile()
        If Main.RomLock = False Then
            Main.RomStateLabel.Text = "Load a Pokemon Rom."
            Main.FilePathLabel.Text = "Enter or Browse the path to your Pokemon Rom :"
            Main.PokemonRomGroupBox.Text = "Pokemon Rom"
        Else
            Main.RomStateLabel.Text = "Load a Pokemon Fire Red Rom."
            Main.FilePathLabel.Text = "Enter or Browse the path to your Pokemon Fire Red Rom :"
            Main.PokemonRomGroupBox.Text = "Pokemon Fire Red Rom"
        End If
        Me.Close()
    End Sub

    Private Sub DefaultButtonClick(sender As Object, e As EventArgs) Handles DefaultButton.Click
        DefaultSettings()
    End Sub

    Private Sub RomCheckButtonClick(sender As Object, e As EventArgs) Handles RomCheckButton.Click
        If RomLock = True Then
            Dim Result As Integer = MessageBox.Show("Are you sure?" & vbCrLf & vbCrLf & "Turning this option off means you would have to provide table list offsets and other sprite data yourself to make this program work." & vbCrLf & "If you don't know how to do that, just keep this option off.", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If Result = DialogResult.Yes Then
                RomLock = False
                RomCheckButton.Text = "Rom Check - Off"
            End If
        Else
            RomLock = True
            RomCheckButton.Text = "Rom Check - On"
        End If
    End Sub

#Region "Validation"

    Private Sub EmptySpaceVerification(sender As Object, e As EventArgs) Handles TableEmptyDataTextBox.Leave, TableListEmptyDataTextBox.Leave, PaletteTableEmptyDataHexTextBox.Leave, SpriteArtDataByteTextBox.Leave
        Dim TextBoxItem As TextBox = CType(sender, TextBox)
        If TextBoxItem.Text <> "" Then
            Dim FreeSpaceString As String = ""
            For i As Integer = 1 To TextBoxItem.MaxLength / 2
                FreeSpaceString += FreeSpaceByteTextBox.Text
            Next
            If String.Compare(FreeSpaceString, TextBoxItem.Text) = 0 Then
                TextBoxItem.Text = TextBoxItem.Tag
                MessageBox.Show("The value cannot be equal to Free Space Byte value!", "Hex Value - Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub FreeSpaceVerification(sender As Object, e As EventArgs) Handles FreeSpaceByteTextBox.Leave
        Dim TextBoxItem As TextBox = CType(sender, TextBox)
        If TextBoxItem.Text <> "" Then
            Dim TableEmptyDataString As String = ""
            For i As Integer = 1 To TableEmptyDataTextBox.MaxLength / 2
                TableEmptyDataString += TextBoxItem.Text
            Next
            Dim TableListEmptyDataString As String = ""
            For i As Integer = 1 To TableListEmptyDataTextBox.MaxLength / 2
                TableListEmptyDataString += TextBoxItem.Text
            Next
            Dim PaletteTableEmptyDataString As String = ""
            For i As Integer = 1 To PaletteTableEmptyDataHexTextBox.MaxLength / 2
                PaletteTableEmptyDataString += TextBoxItem.Text
            Next
            Dim SpriteArtDataByteString As String = ""
            For i As Integer = 1 To SpriteArtDataByteTextBox.MaxLength / 2
                SpriteArtDataByteString += TextBoxItem.Text
            Next
            If String.Compare(TableEmptyDataString, TableEmptyDataTextBox.Text) = 0 Then
                TextBoxItem.Text = TextBoxItem.Tag
                MessageBox.Show("The value of free space byte is interfering with the value of Table Empty Data.", "Hex Value - Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            If String.Compare(TableListEmptyDataString, TableListEmptyDataTextBox.Text) = 0 Then
                TextBoxItem.Text = TextBoxItem.Tag
                MessageBox.Show("The value of free space byte is interfering with the value of Table List Empty Data.", "Hex Value - Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            If String.Compare(PaletteTableEmptyDataString, PaletteTableEmptyDataHexTextBox.Text) = 0 Then
                TextBoxItem.Text = TextBoxItem.Tag
                MessageBox.Show("The value of free space byte is interfering with the value of Palette Table Empty Data.", "Hex Value - Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            If String.Compare(SpriteArtDataByteString, SpriteArtDataByteTextBox.Text) = 0 Then
                TextBoxItem.Text = TextBoxItem.Tag
                MessageBox.Show("The value of free space byte is interfering with the value of Sprite Art Data Byte.", "Hex Value - Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub ApplyValidations() Handles Me.Load
        Dim AllTextBoxControls = SettingsGroupBox.Controls.OfType(Of TextBox)()
        For Each ControlElement In AllTextBoxControls
            If CStr(ControlElement.Tag) <> "" Then
                AddHandler ControlElement.KeyPress, AddressOf SpaceValidator
                AddHandler ControlElement.Leave, AddressOf NullValidator
                Select Case ControlElement.Name
                    Case "OWSTableListOffsetTextBox", "PaletteTableOffsetTextBox"
                        AddHandler ControlElement.Leave, AddressOf SetZeroOffsetCheckTrue
                        AddHandler ControlElement.Leave, AddressOf OffsetValidator
                        AddHandler ControlElement.KeyPress, AddressOf HexInputValidator
                    Case "FreeSpaceByteTextBox", "SpriteArtDataByteTextBox"
                        AddHandler ControlElement.Leave, AddressOf ByteValidator
                        AddHandler ControlElement.KeyPress, AddressOf HexInputValidator
                    Case "TableListEmptyDataTextBox", "TableEmptyDataTextBox", "PaletteTableEndTextBox"
                        AddHandler ControlElement.Leave, AddressOf HexValueValidator
                        AddHandler ControlElement.KeyPress, AddressOf HexInputValidator
                    Case Else
                        AddHandler ControlElement.TextChanged, AddressOf SetMaxLimitDefault
                        AddHandler ControlElement.TextChanged, AddressOf MaxLimitValidator
                        AddHandler ControlElement.KeyPress, AddressOf DigitValidator
                End Select
            End If
        Next
    End Sub

#End Region

End Class