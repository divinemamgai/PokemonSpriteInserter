Imports System.Drawing.Imaging

Public Class OWSTableBrowser

    Public MainTabPage As TabPage
    Public PaletteDataArray() As PaletteData = GetPalettes(Main.PaletteTableOffset, Main.PaletteTableEndHex, Main.MaxPalette, False)
    Public PaletteConvertObject As New PaletteConvert
    Public SpriteClassObject As New Sprite
    Public SpriteZoomContainerMultiplier As Integer = 4

    Public CurrentPaletteIndex As Integer = 9
    Public CurrentSpriteData As String = "0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000088880080BCBB0080BBBB00C8BBBB0000000000000000000000000000000088880000BBCB0800BBBB0800BBBB8C0000CFBCBB00CFCC9CF081CACAF0F39699004F6366003F232F00403324006F4F33BBCBFC00C9CCFC00ACAC180F99693F0F6636F400F232F3004233040033F4F6004062CFFF4033C6AC00F477F600F0667F00F066FF0000FF000000000000000000FFFC2604CA6C33046F774F00F7660F00FF660F0000FF00000000000000000000"
    Public CurrentMultiplier As Integer = 15
    Public CurrentSpriteSize As Size = New Size(32, 32)
    Public DrawGrid As Boolean = True

    Public SpriteEditorGroupBox As New GroupBox
    Public SpriteContainerPanel As New Panel
    Public SpriteCanvas As New PictureBox
    Public SpritePalette As New PictureBox
    Public SpriteScaleSlider As New TrackBar
    Public CurrentSizeLabel As New Label
    Public OriginalSizeLabel As New Label
    Public CurrentZoomLabel As New Label
    Public CurrentPaletteColor As New PaletteBox


    Public Sub New(ByVal DefaultTabPage As TabPage)
        If IsNothing(DefaultTabPage) = False Then
            MainTabPage = DefaultTabPage
            MainTabPage.Size = New Size(592, 600)
            GenerateTable()
        End If
    End Sub

    Public Sub GenerateTable()
        MainTabPage.Controls.Clear()
        With SpriteEditorGroupBox
            .Width = 570
            .Height = 324
            .Text = "Sprite Editor"
            .Location = New Point(3, 3)
        End With
        With SpriteContainerPanel
            .Location = New Point(6, 16)
            .Margin = New Padding(3, 3, 3, 3)
            .Padding = New Padding(0, 0, 0, 0)
            .Size = New Size(256, 256)
            .BorderStyle = BorderStyle.FixedSingle
            .AutoScroll = True
            .BackColor = PaletteConvertObject.ReturnColor(PaletteDataArray(CurrentPaletteIndex - 1).PaletteHexData.Substring(0, 4))
        End With
        With SpriteScaleSlider
            .Location = New Point(6, 278)
            .AutoSize = False
            .Size = New Size(256, 40)
            .BackColor = Color.White
            .Minimum = 1
            .Maximum = 30
        End With
        With CurrentZoomLabel
            .Text = CStr(CurrentMultiplier) + "x Magnified"
            .Location = New Point(6, 300)
            .Font = New Font(MainTabPage.Font.FontFamily, 7, FontStyle.Bold)
            .TextAlign = ContentAlignment.MiddleLeft
        End With
        With CurrentSizeLabel
            .Text = "Current Size : W x H [Original : W x H]"
            .Location = New Point(83, 300)
            .Width = 180
            .Font = New Font(MainTabPage.Font.FontFamily, 7, FontStyle.Bold)
            .TextAlign = ContentAlignment.MiddleRight
        End With
        AddHandler SpriteScaleSlider.Scroll, AddressOf GenerateSprite
        MainTabPage.Controls.AddRange({SpriteEditorGroupBox})
        SpriteEditorGroupBox.Controls.AddRange({SpriteContainerPanel, SpriteScaleSlider, CurrentZoomLabel, CurrentSizeLabel})
        SpriteScaleSlider.Value = CurrentMultiplier
        SpriteScaleSlider.SendToBack()
        CurrentSizeLabel.BringToFront()
        SpriteClassObject.DrawSprite(CurrentSpriteData,
                                     PaletteDataArray(CurrentPaletteIndex - 1).PaletteHexData,
                                     CurrentSpriteSize,
                                     SpriteContainerPanel,
                                     CurrentMultiplier,
                                     Color.Black,
                                     DrawGrid)
    End Sub

    Public Sub GenerateSprite(sender As Object, e As EventArgs)
        CurrentMultiplier = SpriteScaleSlider.Value
        SpriteClassObject.DrawSprite(CurrentSpriteData,
                                     PaletteDataArray(CurrentPaletteIndex - 1).PaletteHexData,
                                     CurrentSpriteSize,
                                     SpriteContainerPanel,
                                     CurrentMultiplier,
                                     Color.Black,
                                     DrawGrid)
        CurrentZoomLabel.Text = CStr(CurrentMultiplier) + "x Magnified"
        CurrentSizeLabel.Text = "Current Size : " + CStr(16 * CurrentMultiplier) + " x " + CStr(32 * CurrentMultiplier) + " [Original : 16 x 32]"
    End Sub

End Class
