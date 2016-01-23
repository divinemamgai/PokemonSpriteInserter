Imports System.Drawing.Imaging

Public Class OWSTableBrowser

    Public MainFrom As Form
    Public MainTabPage As TabPage

    Public OWSTableBrowserIsLoaded As Boolean = False
    Public CurrentSpriteTable As Integer = 1
    Public SpriteTables As SpriteTable() = GetSpriteTables(Main.OWSTableListOffset, Main.OWSTableListEmptyDataHex, Main.OWSTableEmptyDataHex, Main.OWSTableMaxSprites)
    Public MaxSprites As Integer = 2
    Public MaxSpritesArray() As Integer = {30, 40, 50, 60, 70}
    Public CurrentSprite As Integer = 1
    Public TotalPages As Integer = Math.Ceiling(SpriteTables(CurrentSpriteTable - 1).SpriteTableSpriteCount / MaxSpritesArray(MaxSprites - 1))
    Public CurrentPage As Integer = 1
    Public SpriteDrawMultiplier As Integer = 1

    Public SpriteEditorObject As SpriteEditor
    Public DummySpriteEditorObject As SpriteEditor
    Public SpriteBrowserGroupBox As New GroupBox
    Public SpriteBrowserFlowLayoutPanel As New FlowLayoutPanel
    Public SpriteTableLabel As New Label
    Public SpriteTableComboBox As New ComboBox
    Public SpriteBrowserMaxSpritesLabel As New Label
    Public SpriteBrowserMaxSpritesComboBox As New ComboBox
    Public SpriteBrowserPreviousButton As New Button
    Public SpriteBrowserCurrentPageComboBox As New ComboBox
    Public SpriteBrowserNextButton As New Button

    Public Sub New(ByVal DefaultForm As Form, ByVal DefaultTabPage As TabPage)
        If IsNothing(DefaultForm) = False Then
            MainFrom = DefaultForm
            If IsNothing(DefaultTabPage) = False Then
                MainTabPage = DefaultTabPage
                SpriteEditorObject = New SpriteEditor(SpriteTables(CurrentSpriteTable - 1).SpriteTableSpriteArray(CurrentSprite - 1), MainFrom, MainTabPage)
                GenerateSpriteBrowser()
            End If
        End If
    End Sub

    Public Function CheckNull() As Boolean
        If IsNothing(MainTabPage) = True Then
            Return True
        End If
        Return False
    End Function

    Public Sub LoadSprites()
        SpriteBrowserFlowLayoutPanel.Controls.Clear()
        For Count As Integer = (CurrentPage - 1) * MaxSpritesArray(MaxSprites - 1) + 1 To CurrentPage * MaxSpritesArray(MaxSprites - 1)
            If Count > SpriteTables(CurrentSpriteTable - 1).SpriteTableSpriteCount Then
                Exit For
            Else
                If SpriteTables(CurrentSpriteTable - 1).SpriteTableSpriteArray(Count - 1).SpriteValid = True Then
                    DummySpriteEditorObject = New SpriteEditor(SpriteTables(CurrentSpriteTable - 1).SpriteTableSpriteArray(Count - 1), Nothing, Nothing)
                    Dim SpriteFramePanel As New SpritePanel
                    With SpriteFramePanel
                        .BorderStyle = BorderStyle.None
                        .Size = New Size(DummySpriteEditorObject.Sprite.SpriteSize.Width * SpriteDrawMultiplier + 4,
                                         DummySpriteEditorObject.Sprite.SpriteSize.Height * SpriteDrawMultiplier + 4)
                        .Cursor = Cursors.Hand
                        .Tag = Count
                    End With
                    SpriteBrowserFlowLayoutPanel.Controls.Add(SpriteFramePanel)
                    DummySpriteEditorObject.DrawSprite(1, DummySpriteEditorObject.SpritePalette.PaletteHexData, DummySpriteEditorObject.Sprite.SpriteSize,
                                                       SpriteFramePanel, SpriteDrawMultiplier, Color.Black, False)
                    Dim SpriteFramePanelPictureBox As PictureBox = DummySpriteEditorObject.GetSpritePictureBox(SpriteFramePanel)
                    SpriteFramePanelPictureBox.Location = New Point(2, 2)
                    AddHandler SpriteFramePanelPictureBox.Click, Sub(sender As Object, e As EventArgs)
                                                                     Dim SpriteFramePanelPictureBoxTemp As PictureBox = DirectCast(sender, PictureBox)
                                                                     CurrentSprite = CInt(SpriteFramePanelPictureBoxTemp.Parent().Tag)
                                                                     Dim SpriteUpdated As Boolean = False
                                                                     If String.Compare(SpriteEditorObject.SpriteImageData, SpriteEditorObject.SpriteOriginalImageData) <> 0 Then
                                                                         Dim Result As Integer = MessageBox.Show("Sprite change has been detected! Do want to save the changes you have made to the sprite and proceed?", "Sprite Change Detected!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
                                                                         If Result = DialogResult.Yes Then
                                                                             SpriteEditorObject.SaveSprite(False, False)
                                                                             SpriteUpdated = True
                                                                         End If
                                                                     End If
                                                                     If SpriteEditorObject.CheckSpritePaletteChange() <> SpriteEditor.PaletteChange.No Then
                                                                         Dim Result As Integer = MessageBox.Show("Palette change has been detected! Do want to save the changes you have made to the palette and proceed?", "Palette Change Detected!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
                                                                         If Result = DialogResult.Yes Then
                                                                             SpriteEditorObject.SavePalette(False)
                                                                             SpriteUpdated = True
                                                                         End If
                                                                     End If
                                                                     SpriteEditorObject.Delete()
                                                                     SpriteEditorObject = New SpriteEditor(SpriteTables(CurrentSpriteTable - 1).SpriteTableSpriteArray(CurrentSprite - 1),
                                                                                                           MainFrom, MainTabPage)
                                                                     SpriteEditorObject.GenerateSpriteEditor()
                                                                     If SpriteUpdated = True Then
                                                                         LoadSprites()
                                                                     End If
                                                                 End Sub
                    OWSTableBrowserIsLoaded = True
                Else
                    OWSTableBrowserIsLoaded = False
                    Exit For
                End If
            End If
        Next
    End Sub

    Public Sub UpdateTotalPages()
        TotalPages = Math.Ceiling(SpriteTables(CurrentSpriteTable - 1).SpriteTableSpriteCount / MaxSpritesArray(MaxSprites - 1))
        SpriteBrowserCurrentPageComboBox.Items.Clear()
        For Page As Integer = 1 To TotalPages
            SpriteBrowserCurrentPageComboBox.Items.Add(Page)
        Next
        SpriteBrowserCurrentPageComboBox.SelectedIndex = 0
    End Sub

    Public Sub LoadBrowserDetails()
        SpriteTableComboBox.Items.Clear()
        For SpriteTableCount As Integer = 1 To SpriteTables.Length
            SpriteTableComboBox.Items.Add(CStr(SpriteTableCount) + " [0x" + SpriteTables(SpriteTableCount - 1).SpriteTableOffset + "] [" + CStr(SpriteTables(SpriteTableCount - 1).SpriteTableSpriteCount) + "]")
        Next
        SpriteBrowserMaxSpritesComboBox.Items.Clear()
        For MaxSpritesCount As Integer = 1 To MaxSpritesArray.Length
            SpriteBrowserMaxSpritesComboBox.Items.Add(MaxSpritesArray(MaxSpritesCount - 1))
        Next
    End Sub

    Public Sub DisableMouseWheel(sender As Object, e As MouseEventArgs)
        Dim MouseWheelEvent As HandledMouseEventArgs = DirectCast(e, HandledMouseEventArgs)
        MouseWheelEvent.Handled = True
        SpriteEditorObject.SpriteCanvasInnerPanel.Select()
    End Sub

    Public Sub ChangeSpriteBrowserPage(sender As Object, e As EventArgs)
        SpriteEditorObject.SpriteCanvasInnerPanel.Select()
        If CurrentPage <> SpriteBrowserCurrentPageComboBox.SelectedIndex + 1 Then
            CurrentPage = SpriteBrowserCurrentPageComboBox.SelectedIndex + 1
            LoadSprites()
            SpriteBrowserNextButton.Text = "Next"
            SpriteBrowserPreviousButton.Text = "Previous"
            If CurrentPage = TotalPages Then
                SpriteBrowserNextButton.Enabled = False
            Else
                SpriteBrowserNextButton.Enabled = True
            End If
            If CurrentPage = 1 Then
                SpriteBrowserPreviousButton.Enabled = False
            Else
                SpriteBrowserPreviousButton.Enabled = True
            End If
        End If
    End Sub

    Public Sub ChangeSpriteBrowserTable(sender As Object, e As EventArgs)
        If CurrentSpriteTable <> SpriteTableComboBox.SelectedIndex + 1 Then
            If SpriteTables(SpriteTableComboBox.SelectedIndex).SpriteTableSpriteCount <> 0 Then
                CurrentSpriteTable = SpriteTableComboBox.SelectedIndex + 1
                UpdateTotalPages()
                LoadSprites()
            Else
                MessageBox.Show("The sprite table you selected is empty! " & vbCrLf & "Please select a sprite table with atleast one sprite.", "Empty Sprite Table", MessageBoxButtons.OK, MessageBoxIcon.Error)
                SpriteTableComboBox.SelectedIndex = CurrentSpriteTable - 1
            End If
        End If
    End Sub

    Public Sub GenerateSpriteBrowser()
        If CheckNull() = False Then
            SpriteEditorObject.GenerateSpriteEditor()
            With SpriteBrowserGroupBox
                .Size = New Size(MainTabPage.Size.Width - 8, MainTabPage.Size.Height - SpriteEditorObject.SpriteEditorGroupBox.Height - 3)
                .Location = New Point(3, SpriteEditorObject.SpriteEditorGroupBox.Height)
                .Text = "Sprite Browser"
            End With
            With SpriteBrowserFlowLayoutPanel
                .Size = New Size(SpriteBrowserGroupBox.Width - 12, SpriteBrowserGroupBox.Height - 27 - 25)
                .Location = New Point(6, 17)
                .BorderStyle = BorderStyle.FixedSingle
                .AutoScroll = True
            End With
            With SpriteTableLabel
                .AutoSize = False
                .Size = New Size(78, 18)
                .Text = "Sprite Table :"
                .Location = New Point(5, 26 + SpriteBrowserFlowLayoutPanel.Height)
            End With
            With SpriteTableComboBox
                .Size = New Size(168, 0)
                .Font = New Font("Calibri", 9)
                .Location = New Point(SpriteTableLabel.Location.X + SpriteTableLabel.Width + 2, 23 + SpriteBrowserFlowLayoutPanel.Height)
                .DropDownStyle = ComboBoxStyle.DropDownList
            End With
            AddHandler SpriteTableComboBox.MouseWheel, AddressOf DisableMouseWheel
            AddHandler SpriteTableComboBox.SelectedIndexChanged, AddressOf ChangeSpriteBrowserTable
            With SpriteBrowserNextButton
                .Size = New Size(70, 26)
                .Location = New Point(SpriteBrowserGroupBox.Width - SpriteBrowserNextButton.Width - 5, 21 + SpriteBrowserFlowLayoutPanel.Height)
                .Text = "Next"
            End With
            AddHandler SpriteBrowserNextButton.Click, Sub()
                                                          If CurrentPage < TotalPages Then
                                                              SpriteBrowserNextButton.Text = "Loading..."
                                                              SpriteBrowserNextButton.Enabled = False
                                                              SpriteBrowserCurrentPageComboBox.SelectedIndex = SpriteBrowserCurrentPageComboBox.SelectedIndex + 1
                                                          End If
                                                      End Sub
            With SpriteBrowserCurrentPageComboBox
                .Size = New Size(42, 0)
                .Font = New Font("Calibri", 9)
                .Location = New Point(SpriteBrowserGroupBox.Width - SpriteBrowserNextButton.Width - SpriteBrowserCurrentPageComboBox.Width - 8, 23 + SpriteBrowserFlowLayoutPanel.Height)
                .DropDownStyle = ComboBoxStyle.DropDownList
            End With
            AddHandler SpriteBrowserCurrentPageComboBox.MouseWheel, AddressOf DisableMouseWheel
            AddHandler SpriteBrowserCurrentPageComboBox.SelectedIndexChanged, AddressOf ChangeSpriteBrowserPage
            With SpriteBrowserPreviousButton
                .Size = New Size(70, 26)
                .Location = New Point(SpriteBrowserCurrentPageComboBox.Location.X - SpriteBrowserPreviousButton.Width - 3, 21 + SpriteBrowserFlowLayoutPanel.Height)
                .Text = "Previous"
                .Enabled = False
            End With
            AddHandler SpriteBrowserPreviousButton.Click, Sub()
                                                              If CurrentPage > 1 Then
                                                                  SpriteBrowserPreviousButton.Text = "Loading..."
                                                                  SpriteBrowserPreviousButton.Enabled = False
                                                                  SpriteBrowserCurrentPageComboBox.SelectedIndex = SpriteBrowserCurrentPageComboBox.SelectedIndex - 1
                                                              End If
                                                          End Sub
            With SpriteBrowserMaxSpritesComboBox
                .Size = New Size(42, 0)
                .Font = New Font("Calibri", 9)
                .Location = New Point(SpriteBrowserPreviousButton.Location.X - SpriteBrowserMaxSpritesComboBox.Width - 3, 23 + SpriteBrowserFlowLayoutPanel.Height)
                .DropDownStyle = ComboBoxStyle.DropDownList
            End With
            AddHandler SpriteBrowserMaxSpritesComboBox.MouseWheel, AddressOf DisableMouseWheel
            AddHandler SpriteBrowserMaxSpritesComboBox.SelectedIndexChanged, Sub()
                                                                                 If MaxSprites <> SpriteBrowserMaxSpritesComboBox.SelectedIndex + 1 Then
                                                                                     MaxSprites = SpriteBrowserMaxSpritesComboBox.SelectedIndex + 1
                                                                                     UpdateTotalPages()
                                                                                 End If
                                                                             End Sub
            With SpriteBrowserMaxSpritesLabel
                .AutoSize = False
                .Size = New Size(78, 18)
                .Location = New Point(SpriteBrowserMaxSpritesComboBox.Location.X - SpriteBrowserMaxSpritesLabel.Width, 26 + SpriteBrowserFlowLayoutPanel.Height)
                .Text = "Max Sprites :"
            End With
            LoadBrowserDetails()
            SpriteTableComboBox.SelectedIndex = CurrentSpriteTable - 1
            SpriteBrowserMaxSpritesComboBox.SelectedIndex = MaxSprites - 1
            LoadSprites()
            UpdateTotalPages()
            MainTabPage.Controls.Add(SpriteBrowserGroupBox)
            SpriteBrowserGroupBox.Controls.AddRange({SpriteBrowserFlowLayoutPanel, SpriteTableLabel, SpriteTableComboBox, SpriteBrowserNextButton, SpriteBrowserCurrentPageComboBox,
                                                     SpriteBrowserPreviousButton, SpriteBrowserMaxSpritesComboBox, SpriteBrowserMaxSpritesLabel})
            AddHandler MainFrom.FormClosed, Sub()
                                                SpriteEditorObject.Delete()
                                                Delete()
                                            End Sub
        End If
    End Sub

    Public Sub Delete()
        RemoveHandler SpriteBrowserMaxSpritesComboBox.MouseWheel, AddressOf DisableMouseWheel
        SpriteEditorObject = Nothing
        DummySpriteEditorObject = Nothing
        SpriteBrowserGroupBox.Dispose()
        SpriteBrowserGroupBox = Nothing
        SpriteBrowserFlowLayoutPanel = Nothing
        SpriteTableLabel = Nothing
        SpriteTableComboBox = Nothing
        SpriteBrowserMaxSpritesLabel = Nothing
        SpriteBrowserMaxSpritesComboBox = Nothing
        SpriteBrowserPreviousButton = Nothing
        SpriteBrowserCurrentPageComboBox = Nothing
        SpriteBrowserNextButton = Nothing
        SpriteTables = Nothing
    End Sub

End Class
