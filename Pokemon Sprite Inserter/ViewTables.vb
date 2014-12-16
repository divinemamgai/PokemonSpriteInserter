Public Class ViewTables
    Public PaletteBrowserObject As PaletteBrowser
    'Public OWSTableBrowserObject As OWSTableBrowser
    Private Sub ViewTablesLoad(sender As Object, e As EventArgs) Handles MyBase.Load
        PaletteBrowserObject = New PaletteBrowser(, PaletteTablePage)
        'OWSTableBrowserObject = New OWSTableBrowser(OWSTablePage)
    End Sub
End Class