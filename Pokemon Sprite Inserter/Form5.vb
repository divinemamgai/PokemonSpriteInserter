Imports System.IO

Public Class Form5

    Dim SearchForOffset As Boolean = True
    Dim PaletteDataSize As Integer = 64
    Dim PaletteDataOffset As String

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = "F051F5211F4B5B3A0F210869E73C8E62AD14BD7FD66ABF25F81C7F2F771E00000E53F5211F4B5B3A0F210869E73C8E62AD14BD7FD66ABF25F81C7F2F771E0000"
    End Sub

    Private Sub TextBoxDigitValidation(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
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

    Private Sub PaletteDataValidator(sender As Object, e As EventArgs) Handles TextBox1.Leave
        Dim TextBoxItem As TextBox = CType(sender, TextBox)
        If TextBoxItem.Text <> "" Then
            If TextBoxItem.Text.Length <> 128 Then
                TextBoxItem.Text = TextBoxItem.Tag
                MessageBox.Show("Palette Hex Data can only be of 128 characters.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub OffsetValidator(sender As Object, e As EventArgs) Handles TextBox2.Leave, TextBox3.Leave
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

    Private Sub TextBoxDigitValidator(sender As Object, e As KeyPressEventArgs) Handles TextBox6.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) _
                  Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If
    End Sub

    Private Sub SpaceValidator(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress, TextBox6.KeyPress
        If Asc(e.KeyChar) = Keys.Space Then
            e.Handled = True
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.CheckState = CheckState.Checked Then
            Label3.Enabled = False
            TextBox3.Enabled = False
            Label4.Enabled = True
            TextBox2.Enabled = True
            SearchForOffset = True
        Else
            Label3.Enabled = True
            TextBox3.Enabled = True
            Label4.Enabled = False
            TextBox2.Enabled = False
            SearchForOffset = False
        End If
    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckBox1.Checked = True
        RichTextBox1.Hide()
        Button3.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ErrorFlag = False
        GroupBox1.Text = "Adding Palette"
        RichTextBox1.Show()
        Button3.Enabled = False
        Button3.Show()
        If SearchForOffset = True Then
            RichTextBox1.Text += "Searching free space for Palette Data [" + CStr(PaletteDataSize) + " Bytes]..."
            PaletteDataOffset = Form1.SearchFreeSpace(Form1.ToDecimal(TextBox2.Text), PaletteDataSize, Form1.FreeSpaceByteValue)
            If String.Compare(PaletteDataOffset, "Null") <> 0 Then
                RichTextBox1.Text += vbCrLf & "     Found at offset => 0x" + PaletteDataOffset
            Else
                ErrorFlag = True
                RichTextBox1.Text += vbCrLf & "     Cannot found free space!"
            End If
        Else
            PaletteDataOffset = TextBox3.Text
            RichTextBox1.Text += "Using Palette Data Offset => 0x" + PaletteDataOffset
        End If
        If ErrorFlag = False Then
            RichTextBox1.Text += vbCrLf & "Prompting user to proceed to writing..."
            Dim PromptResult As Integer = MessageBox.Show("Do you want to proceed writing Palette Data to your Rom?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If PromptResult = DialogResult.Yes Then
                RichTextBox1.Text += vbCrLf & "     Proceeding with writing procedure..."
                RichTextBox1.Text += vbCrLf & "Writing data..."
                If Form1.WriteData(PaletteDataOffset, PaletteDataSize, TextBox1.Text) = True Then
                    RichTextBox1.Text += vbCrLf & "     Done!"
                    RichTextBox1.Text += vbCrLf & "Finding free space in Palette table..."
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
                                RichTextBox1.Text += vbCrLf & "Palette Table is full! Aborting..."
                                MessageBox.Show("Palette Table is full! Aborting.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Flag = False
                                ErrorFlag = True
                                Exit While
                            End If
                        End If
                    End While
                    RomFileReadStream.Close()
                    If ErrorFlag = False Then
                        Dim PaletteOffset As String = Form1.ToHex(Form1.ToDecimal(Form1.PaletteTableOffset) + NumberOfPalettes * 8)
                        RichTextBox1.Text += vbCrLf & "     Found at offset => 0x" + PaletteOffset
                        RichTextBox1.Text += vbCrLf & "Generating Palette Header Data..."
                        Dim PaletteData As String = Form1.OffsetToPointer(PaletteDataOffset)
                        If Form1.ToHex(CInt(TextBox6.Text)).Length = 1 Then
                            PaletteData += "0"
                        End If
                        PaletteData += Form1.ToHex(CInt(TextBox6.Text))
                        PaletteData += "110000"
                        PaletteData += Form1.PaletteTableEndHex
                        RichTextBox1.Text += vbCrLf & "     Done..."
                        RichTextBox1.Text += vbCrLf & "Writing data..."
                        If Form1.WriteData(PaletteOffset, PaletteData.Length / 2, PaletteData) = True Then
                            RichTextBox1.Text += vbCrLf & "     Done!"
                            RichTextBox1.Text += vbCrLf & "Everything completed successfully!"
                            Button3.Enabled = True
                        Else
                            RichTextBox1.Text += vbCrLf & "     Error! Aborting..."
                            Button3.Enabled = True
                        End If
                    Else
                        RichTextBox1.Text += vbCrLf & "     Error! Aborting..."
                        Button3.Enabled = True
                    End If
                Else
                    RichTextBox1.Text += vbCrLf & "     Error! Aborting..."
                    Button3.Enabled = True
                End If
            Else
                RichTextBox1.Text += vbCrLf & "     Error! Aborted by user."
                Button3.Enabled = True
            End If
        Else
            RichTextBox1.Text += vbCrLf & "     Error! Aborting..."
            Button3.Enabled = True
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        RichTextBox1.Hide()
        RichTextBox1.Text = ""
        Button3.Hide()
    End Sub

    Private Sub RichTextBox1_Change(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged
        RichTextBox1.SelectionStart = RichTextBox1.Text.Length
        RichTextBox1.ScrollToCaret()
    End Sub

End Class