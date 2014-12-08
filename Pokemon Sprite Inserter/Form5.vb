Imports System.IO

Public Class Form5

    Dim SearchForOffset As Boolean = True
    Dim PaletteDataSize As Integer = 32
    Dim PaletteDataOffset As String

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles DefaultPaletteButton.Click
        PaletteHexDataTextBox.Text = "F051F5211F4B5B3A0F210869E73C8E62AD14BD7FD66ABF25F81C7F2F771E0000"
    End Sub

    Private Sub TextBoxDigitValidation(sender As Object, e As EventArgs) Handles PaletteNumberTextBox.TextChanged
        Dim TextBoxItem As TextBox = CType(sender, TextBox)
        If TextBoxItem.Text <> "" Then
            Dim TextBoxValue = Integer.Parse(TextBoxItem.Text)
            If TextBoxValue > 255 Then
                TextBoxItem.Text = TextBoxItem.Tag
                MessageBox.Show("Max Limit is 255!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            TextBoxItem.Text = TextBoxItem.Tag
            MessageBox.Show("Value cannot be empty!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub PaletteDataValidator(sender As Object, e As EventArgs) Handles PaletteHexDataTextBox.Leave
        Dim TextBoxItem As TextBox = CType(sender, TextBox)
        If TextBoxItem.Text <> "" Then
            If TextBoxItem.Text.Length <> 64 Then
                TextBoxItem.Text = TextBoxItem.Tag
                MessageBox.Show("Palette Hex Data can only be of 64 characters.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                If Not System.Text.RegularExpressions.Regex.IsMatch(TextBoxItem.Text, "\A\b[0-9a-fA-F]+\b\Z") Then
                    TextBoxItem.Text = TextBoxItem.Tag
                    MessageBox.Show("Enter a valid hexadecimal palette hex data value!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Else
            TextBoxItem.Text = TextBoxItem.Tag
            MessageBox.Show("Palette Hex Data cannot be empty!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub OffsetValidator(sender As Object, e As EventArgs) Handles FreeSpaceStartTextBox.Leave, PaletteOffsetTextBox.Leave
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

    Private Sub TextBoxDigitValidator(sender As Object, e As KeyPressEventArgs) Handles PaletteNumberTextBox.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If
    End Sub

    Private Sub SpaceValidator(sender As Object, e As KeyPressEventArgs) Handles PaletteHexDataTextBox.KeyPress, PaletteNumberTextBox.KeyPress, PaletteOffsetTextBox.KeyPress
        If Asc(e.KeyChar) = Keys.Space Then
            e.Handled = True
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles FreeSpaceCheckBox.CheckedChanged
        If FreeSpaceCheckBox.CheckState = CheckState.Checked Then
            PaletteDataOffsetLabel.Enabled = False
            PaletteOffsetTextBox.Enabled = False
            FreeSpaceFromLabel.Enabled = True
            FreeSpaceStartTextBox.Enabled = True
            SearchForOffset = True
        Else
            PaletteDataOffsetLabel.Enabled = True
            PaletteOffsetTextBox.Enabled = True
            FreeSpaceFromLabel.Enabled = False
            FreeSpaceStartTextBox.Enabled = False
            SearchForOffset = False
        End If
    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FreeSpaceCheckBox.Checked = True
        Log.Hide()
        BackButton.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles InsertPaletteButton.Click
        Dim ErrorFlag = False
        PaletteAdderGroupBox.Text = "Adding Palette"
        Log.Show()
        BackButton.Enabled = False
        BackButton.Show()
        Log.Text += "Starting Palette Insertion Process..."
        If SearchForOffset = True Then
            Log.Text += vbCrLf & "Searching Free Space For Palette Data [" + CStr(PaletteDataSize) + " Bytes]..."
            PaletteDataOffset = Form1.SearchFreeSpace(Form1.ToDecimal(FreeSpaceStartTextBox.Text), PaletteDataSize, Form1.FreeSpaceByteValue)
            If String.Compare(PaletteDataOffset, "Null") <> 0 Then
                Log.Text += vbCrLf & "     Found At Offset => 0x" + PaletteDataOffset
            Else
                ErrorFlag = True
                Log.Text += vbCrLf & "     Cannot Found Free Space!"
            End If
        Else
            If Form1.ToDecimal(PaletteOffsetTextBox.Text) <> 0 Then
                ErrorFlag = False
                PaletteDataOffset = PaletteOffsetTextBox.Text
                Log.Text += "Using Palette Data Offset => 0x" + PaletteDataOffset
            Else
                ErrorFlag = True
                Log.Text += vbCrLf & "Palette Offset Value Cannot Be Zero!"
                MessageBox.Show("Palette Offset Value Cannot Be Zero!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
        If ErrorFlag = False Then
            Log.Text += vbCrLf & "Prompting User To Proceed To Write Palette Data..."
            Dim PromptResult As Integer = MessageBox.Show("Do you want to proceed writing Palette Data to your Rom?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If PromptResult = DialogResult.Yes Then
                Log.Text += vbCrLf & "     Proceeding With Writing Procedure..."
                Log.Text += vbCrLf & "Writing Data [" + CStr(PaletteDataSize) + " Bytes]..."
                If Form1.WriteData(PaletteDataOffset, PaletteDataSize, PaletteHexDataTextBox.Text) = True Then
                    Log.Text += vbCrLf & "     Done!"
                    Log.Text += vbCrLf & "Finding Free Space In Palette Table..."
                    Dim RomFileReadStream As FileStream
                    Dim NumberOfPalettes As Integer = 0
                    RomFileReadStream = File.OpenRead(Form1.RomFilePath)
                    RomFileReadStream.Seek(Form1.ToDecimal(Form1.PaletteTableOffset), SeekOrigin.Begin)
                    Dim Flag As Boolean = False
                    While Flag = False
                        Dim Data As String = ""
                        Dim Buffer(7) As Byte
                        RomFileReadStream.Read(Buffer, 0, 8)
                        For i As Integer = 0 To Buffer.Length - 1
                            Data += Buffer(i).ToString("X2")
                        Next
                        If String.Compare(Data.Substring(0, Form1.PaletteTableEndHex.Length), Form1.PaletteTableEndHex) = 0 Then
                            ErrorFlag = False
                            Flag = True
                            Exit While
                        Else
                            NumberOfPalettes += 1
                            If NumberOfPalettes > Form1.MaxPalette Then
                                Log.Text += vbCrLf & "Palette Table Is Full! Aborting..."
                                MessageBox.Show("Palette Table Is Full! Aborting.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Flag = False
                                ErrorFlag = True
                                Exit While
                            End If
                        End If
                    End While
                    RomFileReadStream.Close()
                    If ErrorFlag = False Then
                        Dim PaletteOffset As String = Form1.ToHex(Form1.ToDecimal(Form1.PaletteTableOffset) + NumberOfPalettes * 8)
                        Log.Text += vbCrLf & "     Found At Offset => 0x" + PaletteOffset
                        Log.Text += vbCrLf & "Generating Palette Header Data..."
                        Dim PaletteData As String = Form1.OffsetToPointer(PaletteDataOffset)
                        If Form1.ToHex(CInt(PaletteNumberTextBox.Text)).Length = 1 Then
                            PaletteData += "0"
                        End If
                        PaletteData += Form1.ToHex(CInt(PaletteNumberTextBox.Text))
                        PaletteData += "110000"
                        PaletteData += Form1.PaletteTableEndHex
                        Log.Text += vbCrLf & "     Done..."
                        Log.Text += vbCrLf & "Writing Data [" + CStr(PaletteData.Length / 2) + " Bytes]..."
                        If Form1.WriteData(PaletteOffset, PaletteData.Length / 2, PaletteData) = True Then
                            Log.Text += vbCrLf & "     Done!"
                            Log.Text += vbCrLf & "Everything Completed Successfully!"
                            BackButton.Enabled = True
                        Else
                            Log.Text += vbCrLf & "     Error! Aborting..."
                            BackButton.Enabled = True
                        End If
                    Else
                        Log.Text += vbCrLf & "     Error! Aborting..."
                        BackButton.Enabled = True
                    End If
                Else
                    Log.Text += vbCrLf & "     Error! Aborting..."
                    BackButton.Enabled = True
                End If
            Else
                Log.Text += vbCrLf & "     Error! Aborted by user."
                BackButton.Enabled = True
            End If
        Else
            Log.Text += vbCrLf & "     Error! Aborting..."
            BackButton.Enabled = True
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles BackButton.Click
        Log.Hide()
        Log.Text = ""
        BackButton.Hide()
    End Sub

    Private Sub RichTextBox1_Change(sender As Object, e As EventArgs) Handles Log.TextChanged
        Log.SelectionStart = Log.Text.Length
        Log.ScrollToCaret()
    End Sub

End Class