Public Class ViewTables
    Public PaletteBrowserObject As PaletteBrowser
    Private Sub ViewTablesLoad(sender As Object, e As EventArgs) Handles MyBase.Load
        PaletteBrowserObject = New PaletteBrowser(, PaletteTablePage)
    End Sub
End Class