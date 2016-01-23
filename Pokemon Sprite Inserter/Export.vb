Public Class Export

    Private Sub ExportCurrentButtonClick(sender As Object, e As EventArgs) Handles ExportCurrentButton.Click
        Me.DialogResult = Windows.Forms.DialogResult.Yes
    End Sub

    Private Sub ExportAllButtonClick(sender As Object, e As EventArgs) Handles ExportAllButton.Click
        Me.DialogResult = Windows.Forms.DialogResult.No
    End Sub
End Class