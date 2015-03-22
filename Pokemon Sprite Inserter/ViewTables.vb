Public Class ViewTables

    Public PaletteBrowserObject As PaletteBrowser
    Public OWSTableBrowserObject As OWSTableBrowser

    Private Sub ViewTablesLoad(sender As Object, e As EventArgs) Handles MyBase.Shown
        PaletteBrowserObject = New PaletteBrowser(, PaletteTablePage)
        OWSTableBrowserObject = New OWSTableBrowser(Me, OWSTablePage)
    End Sub

End Class