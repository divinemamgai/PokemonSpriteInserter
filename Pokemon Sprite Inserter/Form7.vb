Public Class Form7
    Dim ErrorFlag As Boolean = False
    Dim TotalArtBytes As Integer = (CInt(Form1.TextBox2.Text) * CInt(Form1.TextBox3.Text) / 2) * CInt(Form1.TextBox5.Text)
    Private Sub EmptyDataValidator(sender As Object, e As EventArgs) Handles RichTextBox1.Leave
        Dim RichTextBoxItem As RichTextBox = CType(sender, RichTextBox)
        If RichTextBoxItem.Text <> "" Then
            If RichTextBoxItem.Text.Length <> (TotalArtBytes * 2) Then
                ErrorFlag = True
                RichTextBoxItem.Text = ""
                MessageBox.Show("Custom Sprite Art Data can only be of " + CStr(TotalArtBytes) + " Bytes or " + CStr(TotalArtBytes * 2) + " characters." & vbCrLf & vbCrLf & "Limits are calculated by the values of Width, Height and Number Of Frames provided.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                If Not System.Text.RegularExpressions.Regex.IsMatch(RichTextBoxItem.Text, "\A\b[0-9a-fA-F]+\b\Z") Then
                    ErrorFlag = True
                    RichTextBoxItem.Text = ""
                    MessageBox.Show("Enter a valid hexadecimal custom sprite art data value!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    ErrorFlag = False
                End If
            End If
        Else
            ErrorFlag = True
            RichTextBoxItem.Text = ""
            MessageBox.Show("Custom Sprite Art Data cannot be empty!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If RichTextBox1.Text.Length = 0 Then
            ErrorFlag = True
        End If
        If ErrorFlag = False Then
            Form1.UseCustomSpriteArtData = True
            Form1.CustomSpriteArtData = RichTextBox1.Text
            Form1.LoadForm()
            Me.Close()
        Else
            MessageBox.Show("Please provide a valid Custom Sprite Art Data value.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RichTextBox1.Text = Form1.CustomSpriteArtData
        GroupBox1.Text = "Custom Sprite Art Data [" + CStr(TotalArtBytes) + " Bytes Required]"
        If Form1.UseCustomSpriteArtData = True Then
            Button1.Text = "Change"
            Button2.Select()
        Else
            Button1.Text = "Enable"
            Button1.Select()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.UseCustomSpriteArtData = False
        Form1.LoadForm()
        Me.Close()
    End Sub
End Class