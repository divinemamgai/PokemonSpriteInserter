Public Class Form2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles UseTheseOffsetsButton.Click
        Dim ErrorFlag As Boolean = False
        If String.Compare(SpriteFrameDataOffsetTextBox.Text, "000000") = 0 Then
            MessageBox.Show("Sprite Header Data Offset cannot be zero!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorFlag = True
        End If
        If String.Compare(SpriteHeaderDataOffsetTextBox.Text, "000000") = 0 Then
            MessageBox.Show("Sprite Frame Data Offset cannot be zero!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorFlag = True
        End If
        If String.Compare(SpriteArtDataOffsetTextBox.Text, "000000") = 0 Then
            MessageBox.Show("Sprite Art Data Offset cannot be zero!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorFlag = True
        End If
        If ErrorFlag = False Then
            Form1.GlobalSpriteHeaderDataOffset = SpriteFrameDataOffsetTextBox.Text
            Form1.GlobalSpriteFrameDataOffset = SpriteHeaderDataOffsetTextBox.Text
            Form1.GlobalSpriteArtDataOffset = SpriteArtDataOffsetTextBox.Text
            Me.Close()
        End If
    End Sub
    Private Sub TextBox_Changed(sender As Object, e As EventArgs) Handles SpriteFrameDataOffsetTextBox.Leave, SpriteHeaderDataOffsetTextBox.Leave, SpriteArtDataOffsetTextBox.Leave
        Dim TextBoxItem As TextBox = CType(sender, TextBox)
        If TextBoxItem.Text <> "" Then
            If TextBoxItem.Text.Length <> 6 Then
                TextBoxItem.Text = "000000"
                MessageBox.Show("Offset Value can only be of 6 characters.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                If Not System.Text.RegularExpressions.Regex.IsMatch(TextBoxItem.Text, "\A\b[0-9a-fA-F]+\b\Z") Then
                    TextBoxItem.Text = "000000"
                    MessageBox.Show("Enter a valid hexadecimal offset value!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SpriteHeaderBytesLabel.Text = "[36 Bytes]"
        SpriteFrameBytesLabel.Text = "[" + CStr(8 * CInt(Form1.NumberOfFramesTextBox.Text)) + " Bytes]"
        SpriteArtByteLabel.Text = "[" + CStr((CInt(Form1.WidthTextBox.Text) * CInt(Form1.HeightTextBox.Text) / 2) * CInt(Form1.NumberOfFramesTextBox.Text)) + " Bytes]"
        If Form1.GlobalSpriteHeaderDataOffset <> "" Then
            SpriteFrameDataOffsetTextBox.Text = Form1.GlobalSpriteHeaderDataOffset
        End If
        If Form1.GlobalSpriteFrameDataOffset <> "" Then
            SpriteHeaderDataOffsetTextBox.Text = Form1.GlobalSpriteHeaderDataOffset
        End If
        If Form1.GlobalSpriteArtDataOffset <> "" Then
            SpriteArtDataOffsetTextBox.Text = Form1.GlobalSpriteArtDataOffset
        End If
    End Sub
End Class