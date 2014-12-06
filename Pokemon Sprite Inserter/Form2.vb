Public Class Form2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ErrorFlag As Boolean = False
        If String.Compare(TextBox1.Text, "000000") = 0 Then
            MessageBox.Show("Sprite Header Data Offset cannot be zero!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorFlag = True
        End If
        If String.Compare(TextBox2.Text, "000000") = 0 Then
            MessageBox.Show("Sprite Frame Data Offset cannot be zero!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorFlag = True
        End If
        If String.Compare(TextBox3.Text, "000000") = 0 Then
            MessageBox.Show("Sprite Art Data Offset cannot be zero!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorFlag = True
        End If
        If ErrorFlag = False Then
            Form1.GlobalSpriteHeaderDataOffset = TextBox1.Text
            Form1.GlobalSpriteFrameDataOffset = TextBox2.Text
            Form1.GlobalSpriteArtDataOffset = TextBox3.Text
            Me.Close()
        End If
    End Sub
    Private Sub TextBox_Changed(sender As Object, e As EventArgs) Handles TextBox1.Leave, TextBox2.Leave, TextBox3.Leave
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
        If Form1.GlobalSpriteHeaderDataOffset <> "" Then
            TextBox1.Text = Form1.GlobalSpriteHeaderDataOffset
        End If
        If Form1.GlobalSpriteFrameDataOffset <> "" Then
            TextBox2.Text = Form1.GlobalSpriteHeaderDataOffset
        End If
        If Form1.GlobalSpriteArtDataOffset <> "" Then
            TextBox3.Text = Form1.GlobalSpriteArtDataOffset
        End If
    End Sub
End Class