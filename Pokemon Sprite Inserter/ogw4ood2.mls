Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO

Public Class Form3
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
    End Structure
    Dim RomLock As Boolean = Form1.RomLock
    Dim ProgramDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\Pokemon Sprite Inserter"
    Dim SettingsFilePath As String = ProgramDataPath + "\settings.bin"
    Dim SettingsDataVar As SettingsData
    Private Sub DefaultSettings()
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
        PaletteTableEndTextBox.Text = "00000000FF11"
        PaletteTableEndTextBox.Tag = "00000000FF11"
        RomLock = True
        RomCheckButton.Text = "Rom Lock - On"
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
            .PaletteTableEndHex = PaletteTableEndTextBox.Text
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
    Public Sub LoadSettings()
        Dim InputFormatter As BinaryFormatter = New BinaryFormatter()
        If File.Exists(SettingsFilePath) Then
            Try
                Dim DataFileStream As FileStream
                DataFileStream = File.Open(SettingsFilePath, FileMode.Open, FileAccess.Read)
                SettingsDataVar = CType(InputFormatter.Deserialize(DataFileStream), SettingsData)
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
        Else
            DefaultSettings()
            UpdateSettingsFile()
        End If
        Form1.FreeSpaceByteValue = SettingsDataVar.FreeSpaceByteValue
        Form1.SpriteArtDataValue = SettingsDataVar.SpriteArtDataValue
        Form1.OWSTableListOffset = SettingsDataVar.OWSTableListOffset
        Form1.OWSTableListEmptyDataHex = SettingsDataVar.OWSTableListEmptyDataHex
        Form1.OWSTableEmptyDataHex = SettingsDataVar.OWSTableEmptyDataHex
        Form1.OWSTableListMaxTables = SettingsDataVar.OWSTableListMaxTables
        Form1.OWSTableMaxSprites = SettingsDataVar.OWSTableMaxSprites
        Form1.RomLock = SettingsDataVar.RomLock
        Form1.PaletteTableOffset = SettingsDataVar.PaletteTableOffset
        Form1.MaxPalette = SettingsDataVar.MaxPalette
        Form1.PaletteTableEndHex = SettingsDataVar.PaletteTableEndHex
    End Sub
    Private Sub LimitValidator(sender As Object, e As EventArgs) Handles TableListMaxTextBox.TextChanged, TableMaxSpritesTextBox.TextChanged, MaxPaletteTextBox.TextChanged
        Dim TextBoxItem As TextBox = CType(sender, TextBox)
        If TextBoxItem.Text <> "" Then
            Dim TextBoxValue = Integer.Parse(TextBoxItem.Text)
            If TextBoxValue > 255 Then
                TextBoxItem.Text = TextBoxItem.Tag
                MessageBox.Show("Max Limit is 255!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                If TextBoxValue = 0 Then
                    TextBoxItem.Text = TextBoxItem.Tag
                    MessageBox.Show("Value cannot be zero!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Else
            TextBoxItem.Text = TextBoxItem.Tag
            MessageBox.Show("Value cannot be empty!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub OffsetValidator(sender As Object, e As EventArgs) Handles OWSTableListOffsetTextBox.Leave, PaletteTableOffsetTextBox.Leave
        Dim TextBoxItem As TextBox = CType(sender, TextBox)
        If TextBoxItem.Text <> "" Then
            If TextBoxItem.Text.Length <> 6 Then
                TextBoxItem.Text = TextBoxItem.Tag
                MessageBox.Show("Offset value can only be of 6 characters.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                If Not System.Text.RegularExpressions.Regex.IsMatch(TextBoxItem.Text, "\A\b[0-9a-fA-F]+\b\Z") Then
                    TextBoxItem.Text = TextBoxItem.Tag
                    MessageBox.Show("Enter a valid hexadecimal offset value!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Else
            TextBoxItem.Text = TextBoxItem.Tag
            MessageBox.Show("Offset value cannot be empty!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub ByteValidator(sender As Object, e As EventArgs) Handles FreeSpaceByteTextBox.Leave, SpriteArtDataByteTextBox.Leave
        Dim TextBoxItem As TextBox = CType(sender, TextBox)
        If TextBoxItem.Text <> "" Then
            If TextBoxItem.Text.Length <> 2 Then
                TextBoxItem.Text = TextBoxItem.Tag
                MessageBox.Show("Byte value can only be of 2 characters!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                If Not System.Text.RegularExpressions.Regex.IsMatch(TextBoxItem.Text, "\A\b[0-9a-fA-F]+\b\Z") Then
                    TextBoxItem.Text = TextBoxItem.Tag
                    MessageBox.Show("Enter a valid hexadecimal byte value!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Else
            TextBoxItem.Text = TextBoxItem.Tag
            MessageBox.Show("Byte value cannot be empty!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub EmptyDataValidator(sender As Object, e As EventArgs) Handles TableListEmptyDataTextBox.Leave, TableEmptyDataTextBox.Leave
        Dim TextBoxItem As TextBox = CType(sender, TextBox)
        If TextBoxItem.Text <> "" Then
            If TextBoxItem.Text.Length <> 8 Then
                TextBoxItem.Text = TextBoxItem.Tag
                MessageBox.Show("Empty Data Value can only be of 8 characters.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                If Not System.Text.RegularExpressions.Regex.IsMatch(TextBoxItem.Text, "\A\b[0-9a-fA-F]+\b\Z") Then
                    TextBoxItem.Text = TextBoxItem.Tag
                    MessageBox.Show("Enter a valid hexadecimal empty data value!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Else
            TextBoxItem.Text = TextBoxItem.Tag
            MessageBox.Show("Empty Data Value cannot be empty!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        RomLock = SettingsDataVar.RomLock
        If RomLock = True Then
            RomCheckButton.Text = "Rom Check - On"
        Else
            RomCheckButton.Text = "Rom Check - Off"
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.FreeSpaceByteValue = FreeSpaceByteTextBox.Text
        Form1.SpriteArtDataValue = SpriteArtDataByteTextBox.Text
        Form1.OWSTableListOffset = OWSTableListOffsetTextBox.Text
        Form1.OWSTableListEmptyDataHex = TableListEmptyDataTextBox.Text
        Form1.OWSTableEmptyDataHex = TableEmptyDataTextBox.Text
        Form1.OWSTableListMaxTables = CInt(TableListMaxTextBox.Text)
        Form1.OWSTableMaxSprites = CInt(TableMaxSpritesTextBox.Text)
        Form1.RomLock = RomLock
        Form1.PaletteTableOffset = PaletteTableOffsetTextBox.Text
        Form1.MaxPalette = CInt(MaxPaletteTextBox.Text)
        Form1.PaletteTableEndHex = PaletteTableEndTextBox.Text
        UpdateSettingsFile()
        If Form1.RomLock = False Then
            Form1.RomStateLabel.Text = "Load a Pokemon Rom."
            Form1.FilePathLabel.Text = "Enter or Browse the path to your Pokemon Rom :"
            Form1.PokemonRomGroupBox.Text = "Pokemon Rom"
        Else
            Form1.RomStateLabel.Text = "Load a Pokemon Fire Red Rom."
            Form1.FilePathLabel.Text = "Enter or Browse the path to your Pokemon Fire Red Rom :"
            Form1.PokemonRomGroupBox.Text = "Pokemon Fire Red Rom"
        End If
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles DefaultButton.Click
        DefaultSettings()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles RomCheckButton.Click
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

    Private Sub TextBox10_Leave(sender As Object, e As EventArgs) Handles PaletteTableEndTextBox.Leave
        Dim TextBoxItem As TextBox = CType(sender, TextBox)
        If TextBoxItem.Text <> "" Then
            If TextBoxItem.Text.Length <> 12 Then
                TextBoxItem.Text = TextBoxItem.Tag
                MessageBox.Show("Palette Table End Hex can only be of 12 characters.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                If Not System.Text.RegularExpressions.Regex.IsMatch(TextBoxItem.Text, "\A\b[0-9a-fA-F]+\b\Z") Then
                    TextBoxItem.Text = TextBoxItem.Tag
                    MessageBox.Show("Enter a valid hexadecimal palette table end hex value!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Else
            TextBoxItem.Text = TextBoxItem.Tag
            MessageBox.Show("Palette Table End Hex cannot be empty!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub TextBoxDigitValidator(sender As Object, e As KeyPressEventArgs) Handles TableListMaxTextBox.KeyPress, TableMaxSpritesTextBox.KeyPress, MaxPaletteTextBox.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If
    End Sub

    Private Sub SpaceValidator(sender As Object, e As KeyPressEventArgs) Handles FreeSpaceByteTextBox.KeyPress, SpriteArtDataByteTextBox.KeyPress, OWSTableListOffsetTextBox.KeyPress, TableListEmptyDataTextBox.KeyPress, TableEmptyDataTextBox.KeyPress, TableListMaxTextBox.KeyPress, TableMaxSpritesTextBox.KeyPress, PaletteTableOffsetTextBox.KeyPress, MaxPaletteTextBox.KeyPress, PaletteTableEndTextBox.KeyPress
        If Asc(e.KeyChar) = Keys.Space Then
            e.Handled = True
        End If
    End Sub

End Class