Imports System.IO
Imports System.Text

Public Class ImportSprite

    Public PaletteData As String = ""
    Public SpriteData As String = ""
    Public SpriteSize As Size = Nothing
    Public SpriteImportType As Integer = Nothing
    Public PaletteConvertObject As New PaletteConvert
    Public FileHeaderSize As Long = 53

    Public Sub ToggleControls(ByVal DisableControl As Boolean)
        If DisableControl = False Then
            ImportingSpriteGroupBox.Enabled = True
        Else
            ImportingSpriteGroupBox.Enabled = False
        End If
    End Sub

    Private Sub ImportSpriteLoad(sender As Object, e As EventArgs) Handles MyBase.Load
        ToggleControls(True)
        ImportTypeComboBox.SelectedIndex = 0
    End Sub

    Private Sub OpenButtonClick(sender As Object, e As EventArgs) Handles OpenButton.Click
        OpenFileDialog.Filter = "BMP Files (*.bmp*)|*.bmp"
        OpenFileDialog.Title = "Import Sprite Bitmap"
        OpenFileDialog.FileName = ""
        If OpenFileDialog.ShowDialog() = DialogResult.OK Then
            PaletteFlowLayoutPanel.Controls.Clear()
            FileLocationTextBox.Text = OpenFileDialog.FileName
            Dim FileLocation As String = OpenFileDialog.FileName
            Dim FileInfoVar As New FileInfo(FileLocation)
            Dim FileSize As Long = FileInfoVar.Length
            If FileSize >= FileHeaderSize Then
                Dim FileType As String = ReadData("000000", 2, FileLocation)
                Dim ImageSize As Size = New Size(ToDecimal(ProcessBitmapData(ReadData("000012", 4, FileLocation))),
                                                 ToDecimal(ProcessBitmapData(ReadData("000016", 4, FileLocation))))
                SpriteSize = ImageSize
                If String.Compare(FileType, "424D") = 0 Then
                    Dim ColorDepth As String = ReadData("00001B", 2, FileLocation)
                    If String.Compare(ColorDepth, "0004") = 0 Then
                        Dim PaletteArraySize As Long = 64
                        If FileSize >= FileHeaderSize + PaletteArraySize Then
                            Dim PixelArraySize As Long = ImageSize.Width * ImageSize.Height / 2
                            If FileSize >= FileHeaderSize + PaletteArraySize + PixelArraySize Then
                                SpriteSizeLabel.Text = "Sprite Size : " + CStr(ImageSize.Width) + " x " + CStr(ImageSize.Height)
                                Dim SpriteRawDataArray() As String = SplitString(ProcessBitmapData(ReadData("000076", PixelArraySize, FileLocation)), ImageSize.Width)
                                'SpriteRawDataArray.Reverse()
                                Dim PaletteDataArray() As String = SplitString(ReadData("000036", PaletteArraySize, FileLocation), 8)
                                Dim PaletteDataBuilder As New StringBuilder()
                                For PaletteCount As Integer = 0 To 15
                                    Dim ProcessedPalette As String = ProcessBitmapData(PaletteDataArray(PaletteCount)).Substring(2, 6)
                                    PaletteDataBuilder.Append(PaletteConvertObject.ConvertColor16(ProcessedPalette))
                                    Dim PaletteElement As New PaletteBox
                                    With PaletteElement
                                        .BackColor = PaletteConvertObject.ReturnColor(ProcessedPalette, False)
                                        .Tag = PaletteCount
                                        .Width = 21
                                        .Height = 21
                                    End With
                                    PaletteFlowLayoutPanel.Controls.Add(PaletteElement)
                                Next
                                PaletteData = PaletteDataBuilder.ToString
                                Erase PaletteDataArray
                                Dim SpriteRawData As New StringBuilder()
                                Dim BlockSize As New Size(8, 8)
                                Dim BlockColCount As Integer = ImageSize.Width / BlockSize.Width
                                Dim BlockRowCount As Integer = ImageSize.Height / BlockSize.Height
                                For BlockRow As Integer = 1 To BlockRowCount
                                    For BlockCol As Integer = 1 To BlockColCount
                                        For Y As Integer = 0 To BlockSize.Height - 1
                                            For X As Integer = 0 To BlockSize.Width - 1
                                                Dim CurrentPixelLocation As Point = New Point((BlockCol - 1) * BlockSize.Width + X, (BlockRow - 1) * BlockSize.Height + Y)
                                                SpriteRawData.Append(SpriteRawDataArray(CurrentPixelLocation.Y)(ImageSize.Width - 1 - CurrentPixelLocation.X))
                                            Next
                                        Next
                                    Next
                                Next
                                SpriteData = ProcessSpriteData(SpriteRawData.ToString)
                                ImagePictureBox.BackgroundImage = Image.FromFile(FileLocation)
                                ImagePictureBox.BackgroundImageLayout = ImageLayout.Center
                                ToggleControls(False)
                            Else
                                MessageBox.Show("The file you have provided doesn't have a pixel array. Please make sure that the bitmap file is of correct format.",
                                                "File Format Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                ToggleControls(True)
                            End If
                        Else
                            MessageBox.Show("The file you have provided doesn't have a palette array. Please make sure that the bitmap file is of correct format.",
                                            "File Format Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            ToggleControls(True)
                        End If
                    Else
                        MessageBox.Show("The bitmap you provided is not of 4bpp color depth. Make sure to import a bitmap having 4bpp color depth.", "Color Depth Error!",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ToggleControls(True)
                    End If
                Else
                    MessageBox.Show("The file you have provided is not of bitmap file type. Make sure to import a bitmap.", "File Type Error!",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ToggleControls(True)
                End If
            Else
                MessageBox.Show("The file you have provided is too small. Make sure to import a bitmap file having sufficient size.", "File Size Error!",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                ToggleControls(True)
            End If
        End If
    End Sub

    Private Sub ImportButtonClick(sender As Object, e As EventArgs) Handles ImportButton.Click
        Select Case ImportTypeComboBox.SelectedIndex
            Case 0
                SpriteImportType = ImportType.OnlySprite
                Me.DialogResult = DialogResult.OK
            Case 1
                SpriteImportType = ImportType.OnlyPalette
                Me.DialogResult = DialogResult.OK
            Case 2
                SpriteImportType = ImportType.BothSpriteAndPalette
                Me.DialogResult = DialogResult.OK
        End Select
    End Sub

    Private Sub OpenFilesButtonClick(sender As Object, e As EventArgs) Handles OpenFilesButton.Click
        OpenFilesDialog.Filter = "BMP Files (*.bmp*)|*.bmp"
        OpenFilesDialog.Title = "Import Sprites Bitmap"
        OpenFilesDialog.FileName = ""
        OpenFilesDialog.Multiselect = True
        If OpenFilesDialog.ShowDialog() = DialogResult.OK Then
            PaletteAllFlowLayoutPanel.Controls.Clear()
            ImportFramesFlowLayoutPanel.Controls.Clear()
            Dim FileNames() As String = OpenFilesDialog.FileNames
            FilesTextBox.Text = String.Join(", ", FileNames)
            For Each FileName As String In FileNames
                Dim FileInfoVar As New FileInfo(FileName)
                Dim FileSize As Long = FileInfoVar.Length
                If FileSize >= FileHeaderSize Then
                    Dim FileType As String = ReadData("000000", 2, FileName)
                    Dim ImageSize As Size = New Size(ToDecimal(ProcessBitmapData(ReadData("000012", 4, FileName))),
                                                 ToDecimal(ProcessBitmapData(ReadData("000016", 4, FileName))))
                    SpriteSize = ImageSize
                    If String.Compare(FileType, "424D") = 0 Then
                        Dim ColorDepth As String = ReadData("00001B", 2, FileName)
                        If String.Compare(ColorDepth, "0004") = 0 Then
                            Dim PaletteArraySize As Long = 64
                            If FileSize >= FileHeaderSize + PaletteArraySize Then
                                Dim PixelArraySize As Long = ImageSize.Width * ImageSize.Height / 2
                                If FileSize >= FileHeaderSize + PaletteArraySize + PixelArraySize Then
                                    SpriteSizeLabel.Text = "Sprite Size : " + CStr(ImageSize.Width) + " x " + CStr(ImageSize.Height)
                                    Dim SpriteRawDataArray() As String = SplitString(ProcessBitmapData(ReadData("000076", PixelArraySize, FileName)), ImageSize.Width)
                                    Dim PaletteDataArray() As String = SplitString(ReadData("000036", PaletteArraySize, FileName), 8)
                                    Dim PaletteDataBuilder As New StringBuilder()
                                    For PaletteCount As Integer = 0 To 15
                                        Dim ProcessedPalette As String = ProcessBitmapData(PaletteDataArray(PaletteCount)).Substring(2, 6)
                                        PaletteDataBuilder.Append(PaletteConvertObject.ConvertColor16(ProcessedPalette))
                                        Dim PaletteElement As New PaletteBox
                                        With PaletteElement
                                            .BackColor = PaletteConvertObject.ReturnColor(ProcessedPalette, False)
                                            .Tag = PaletteCount
                                            .Width = 21
                                            .Height = 21
                                        End With
                                        PaletteFlowLayoutPanel.Controls.Add(PaletteElement)
                                    Next
                                    PaletteData = PaletteDataBuilder.ToString
                                    Erase PaletteDataArray
                                    Dim SpriteRawData As New StringBuilder()
                                    Dim BlockSize As New Size(8, 8)
                                    Dim BlockColCount As Integer = ImageSize.Width / BlockSize.Width
                                    Dim BlockRowCount As Integer = ImageSize.Height / BlockSize.Height
                                    For BlockRow As Integer = 1 To BlockRowCount
                                        For BlockCol As Integer = 1 To BlockColCount
                                            For Y As Integer = 0 To BlockSize.Height - 1
                                                For X As Integer = 0 To BlockSize.Width - 1
                                                    Dim CurrentPixelLocation As Point = New Point((BlockCol - 1) * BlockSize.Width + X, (BlockRow - 1) * BlockSize.Height + Y)
                                                    SpriteRawData.Append(SpriteRawDataArray(CurrentPixelLocation.Y)(ImageSize.Width - 1 - CurrentPixelLocation.X))
                                                Next
                                            Next
                                        Next
                                    Next
                                    SpriteData = ProcessSpriteData(SpriteRawData.ToString)
                                    ImagePictureBox.BackgroundImage = Image.FromFile(FileName)
                                    ImagePictureBox.BackgroundImageLayout = ImageLayout.Center
                                    ToggleControls(False)
                                Else
                                    MessageBox.Show("The file you have provided doesn't have a pixel array. Please make sure that the bitmap file is of correct format.",
                                                "File Format Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    ToggleControls(True)
                                End If
                            Else
                                MessageBox.Show("The file you have provided doesn't have a palette array. Please make sure that the bitmap file is of correct format.",
                                            "File Format Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                ToggleControls(True)
                            End If
                        Else
                            MessageBox.Show("The bitmap you provided is not of 4bpp color depth. Make sure to import a bitmap having 4bpp color depth.", "Color Depth Error!",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error)
                            ToggleControls(True)
                        End If
                    Else
                        MessageBox.Show("The file you have provided is not of bitmap file type. Make sure to import a bitmap.", "File Type Error!",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ToggleControls(True)
                    End If
                Else
                    MessageBox.Show("The file you have provided is too small. Make sure to import a bitmap file having sufficient size.", "File Size Error!",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ToggleControls(True)
                End If
            Next
        End If
    End Sub
End Class