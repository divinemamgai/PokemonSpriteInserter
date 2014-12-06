Public Class Form6

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RichTextBox1.ForeColor = Color.Black
        GroupBox1.Text = " About - Version " + Application.ProductVersion + " "
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class