Public Class Form6

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AboutRichTextBox.ForeColor = Color.Black
        AboutGroupBox.Text = " About - Version " + Application.ProductVersion + " "
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles DoneButton.Click
        Me.Close()
    End Sub
End Class