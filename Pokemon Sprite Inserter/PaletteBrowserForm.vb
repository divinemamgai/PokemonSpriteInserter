﻿Public Class PaletteBrowserForm

    Public PaletteBrowserObject As PaletteBrowser
    Private Sub PaletteBrowserFormLoad(sender As Object, e As EventArgs) Handles MyBase.Load
        PaletteBrowserObject = New PaletteBrowser(Me, , True, Control.DefaultBackColor)
    End Sub

End Class