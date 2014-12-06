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
        TextBox1.Text = "FF"
        TextBox1.Tag = "FF"
        TextBox2.Text = "BB"
        TextBox2.Tag = "BB"
        TextBox3.Text = "1A2000"
        TextBox3.Tag = "1A2000"
        TextBox4.Text = "00000000"
        TextBox4.Tag = "00000000"
        TextBox5.Text = "00000000"
        TextBox5.Tag = "00000000"
        TextBox6.Text = 100
        TextBox6.Tag = 100
        TextBox7.Text = 152
        TextBox7.Tag = 152
        TextBox8.Text = "1A2400"
        TextBox8.Tag = "1A2400"
        TextBox9.Text = 100
        TextBox9.Tag = 100
        TextBox10.Text = "00000000FF11"
        TextBox10.Tag = "00000000FF11"
        RomLock = True
        Button3.Text = "Rom Lock - On"
    End Sub
    Public Sub UpdateSettingsFile()
        If Not Directory.Exists(ProgramDataPath) Then
            Directory.CreateDirectory(ProgramDataPath)
        End If
        Dim SettingsDataVarTemp As SettingsData = New SettingsData With {
            .FreeSpaceByteValue = TextBox1.Text,
            .SpriteArtDataValue = TextBox2.Text,
            .OWSTableListOffset = TextBox3.Text,
            .OWSTableListEmptyDataHex = TextBox4.Text,
            .OWSTableEmptyDataHex = TextBox5.Text,
            .OWSTableListMaxTables = CInt(TextBox6.Text),
            .OWSTableMaxSprites = CInt(TextBox7.Text),
            .RomLock = RomLock,
            .PaletteTableOffset = TextBox8.Text,
            .MaxPalette = CInt(TextBox9.Text),
            .PaletteTableEndHex = TextBox10.Text
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
    Private Sub TextBox_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged, TextBox7.TextChanged, TextBox9.TextChanged
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

    Private Sub OffsetValidator(sender As Object, e As EventArgs) Handles TextBox3.Leave, TextBox8.Leave
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

    Private Sub ByteValidator(sender As Object, e As EventArgs) Handles TextBox1.Leave, TextBox2.Leave
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

    Private Sub EmptyDataValidator(sender As Object, e As EventArgs) Handles TextBox4.Leave, TextBox5.Leave
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
        TextBox1.Text = SettingsDataVar.FreeSpaceByteValue
        TextBox1.Tag = SettingsDataVar.FreeSpaceByteValue
        TextBox2.Text = SettingsDataVar.SpriteArtDataValue
        TextBox2.Tag = SettingsDataVar.SpriteArtDataValue
        TextBox3.Text = SettingsDataVar.OWSTableListOffset
        TextBox3.Tag = SettingsDataVar.OWSTableListOffset
        TextBox4.Text = SettingsDataVar.OWSTableListEmptyDataHex
        TextBox4.Tag = SettingsDataVar.OWSTableListEmptyDataHex
        TextBox5.Text = SettingsDataVar.OWSTableEmptyDataHex
        TextBox5.Tag = SettingsDataVar.OWSTableEmptyDataHex
        TextBox6.Text = SettingsDataVar.OWSTableListMaxTables
        TextBox6.Tag = SettingsDataVar.OWSTableListMaxTables
        TextBox7.Text = SettingsDataVar.OWSTableMaxSprites
        TextBox7.Tag = SettingsDataVar.OWSTableMaxSprites
        TextBox8.Text = SettingsDataVar.PaletteTableOffset
        TextBox8.Tag = SettingsDataVar.PaletteTableOffset
        TextBox9.Text = SettingsDataVar.MaxPalette
        TextBox9.Tag = SettingsDataVar.MaxPalette
        TextBox10.Text = SettingsDataVar.PaletteTableEndHex
        TextBox10.Tag = SettingsDataVar.PaletteTableEndHex
        RomLock = SettingsDataVar.RomLock
        If RomLock = True Then
            Button3.Text = "Rom Lock - On"
        Else
            Button3.Text = "Rom Lock - Off"
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.FreeSpaceByteValue = TextBox1.Text
        Form1.SpriteArtDataValue = TextBox2.Text
        Form1.OWSTableListOffset = TextBox3.Text
        Form1.OWSTableListEmptyDataHex = TextBox4.Text
        Form1.OWSTableEmptyDataHex = TextBox5.Text
        Form1.OWSTableListMaxTables = CInt(TextBox6.Text)
        Form1.OWSTableMaxSprites = CInt(TextBox7.Text)
        Form1.RomLock = RomLock
        Form1.PaletteTableOffset = TextBox8.Text
        Form1.MaxPalette = CInt(TextBox9.Text)
        Form1.PaletteTableEndHex = TextBox10.Text
        UpdateSettingsFile()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DefaultSettings()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If RomLock = True Then
            Dim Result As Integer = MessageBox.Show("Are you sure?" & vbCrLf & vbCrLf & "Turning this option off means you would have to provide table list offsets and other sprite data yourself to make this program work." & vbCrLf & "If you don't know how to do that, just keep this option off.", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If Result = DialogResult.Yes Then
                RomLock = False
                Button3.Text = "Rom Lock - Off"
            End If
        Else
            RomLock = True
            Button3.Text = "Rom Lock - On"
        End If
    End Sub

    Private Sub TextBox10_Leave(sender As Object, e As EventArgs) Handles TextBox10.Leave
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

    Private Sub TextBoxDigitValidator(sender As Object, e As KeyPressEventArgs) Handles TextBox6.KeyPress, TextBox7.KeyPress, TextBox9.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) _
                  Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If
    End Sub

    Private Sub SpaceValidator(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress, TextBox2.KeyPress, TextBox3.KeyPress, TextBox4.KeyPress, TextBox5.KeyPress, TextBox6.KeyPress, TextBox7.KeyPress, TextBox8.KeyPress, TextBox9.KeyPress, TextBox10.KeyPress
        If Asc(e.KeyChar) = Keys.Space Then
            e.Handled = True
        End If
    End Sub

End Class