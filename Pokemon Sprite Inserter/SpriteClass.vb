Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Imports System.Text

Public Class SpriteEditor

#Region "Sprite Class Variables"

    Public SpritePalette As PaletteData
    Public SpriteOriginalPalette As PaletteData
    Public Sprite As SpriteData
    Public SpriteOriginal As SpriteData
    Public SpriteCanvasMultiplier As Integer = Nothing
    Public SpriteDrawGridStartMultiplier As Integer = Nothing
    Public SpriteCanvasScrollIncrease As Boolean = Nothing
    Public SpriteDrawGrid As Boolean = Nothing
    Public SpriteImage As Bitmap
    Public SpriteOriginalImage As Bitmap
    Public SpriteImageData As String
    Public SpriteOriginalImageData As String
    Public PaletteConvertObject As PaletteConvert
    Public CurrentSpriteFrame As Integer = Nothing
    Public PreviousPixelLocation As Point

    Public MainForm As Form
    Public SpriteEditorControl As Control
    Public SpriteEditorGroupBox As GroupBox
    Public LogPanel As Panel
    Public SpriteCanvasPanel As SpritePanel
    Public SpriteCanvasInnerPanel As Panel
    Public SpriteCanvasPixel As PictureBox
    Public SpriteCanvasVScroll As VScrollBar
    Public SpriteCanvasHScroll As HScrollBar
    Public SpriteCanvasScrollSeparator As PictureBox
    Public SpriteCanvasVScrollBorder As PictureBox
    Public SpriteCanvasHScrollBorder As PictureBox
    Public SpriteMagnifyTrackBar As TrackBar
    Public SpriteCurrentMagnification As Label
    Public SpriteCurrentSize As Label
    Public SpriteCanvas As PictureBox
    Public SpriteBrowser As TabControl
    Public SpriteFrameBrowserTab As TabPage
    Public SpriteDetailsTab As TabPage
    Public SpriteDetailsIndexLabel As Label
    Public SpriteDetailsTableOffsetLabel As Label
    Public SpriteDetailsHeaderOffsetLabel As Label
    Public SpriteDetailsPaletteLabel As Label
    Public SpriteDetailsPaletteHexDataLabel As Label
    Public SpriteDetailsFrameSizeLabel As Label
    Public SpriteDetailsFrameDataOffsetLabel As Label
    Public SpriteDetailsFrameCountLabel As Label
    Public SpriteDetailsArtDataOffset As Label
    Public SpriteDetailsIndexTextBox As TextBox
    Public SpriteDetailsTableOffsetTextBox As TextBox
    Public SpriteDetailsHeaderOffsetTextBox As TextBox
    Public SpriteDetailsPaletteTextBox As TextBox
    Public SpriteDetailsPaletteHexDataTextBox As TextBox
    Public SpriteDetailsFrameSizeTextBox As TextBox
    Public SpriteDetailsFrameDataOffsetTextBox As TextBox
    Public SpriteDetailsFrameCountTextBox As TextBox
    Public SpriteDetailsArtDataOffsetTextBox As TextBox
    Public SpriteDetailsPresetButton As Button
    Public SpriteFrameBrowserFlowLayoutPanel As FlowLayoutPanel
    Public SpriteFrameBrowserNextButton As Button
    Public SpriteFrameBrowserPreviousButton As Button
    Public SpriteDrawGridCheckBox As CheckBox
    Public SpriteExportButton As Button
    Public SpriteImportButton As Button
    Public SpritePaletteGroupBox As GroupBox
    Public SaveSpriteButton As Button
    Public SavePaletteButton As Button
    Public SaveAllButton As Button

    Public Enum PaletteChange
        Yes
        YesApplied
        YesNotApplied
        No
    End Enum

    Public Enum UpdateSpriteEditor
        All
        Canvas
        Palette
        Browser
        Details
    End Enum

#End Region

#Region "Sprite Canvas Undo"

    Public Structure SpriteButffer
        Dim PixelLocation As Point
        Dim PixelColor As Color
        Dim PixelIndex As Integer
        Dim CanvasMultiplier As Integer
    End Structure

    Public MaintainBuffer As Boolean = True
    Public SpriteBufferCount As Integer = 0
    Public SpriteBufferMaxCount As Integer = 1024
    Public SpriteBufferVar() As SpriteButffer

    Public Sub PushToBuffer(ByVal PixelLocation As Point, ByVal PixelColor As Color, ByVal PixelIndex As Integer, ByVal CanvasMultiplier As Integer)
        If SpriteBufferCount < SpriteBufferMaxCount Then
            ReDim Preserve SpriteBufferVar(SpriteBufferCount)
            SpriteBufferVar(SpriteBufferCount).PixelLocation = PixelLocation
            SpriteBufferVar(SpriteBufferCount).PixelColor = PixelColor
            SpriteBufferVar(SpriteBufferCount).PixelIndex = PixelIndex
            SpriteBufferVar(SpriteBufferCount).CanvasMultiplier = CanvasMultiplier
            SpriteBufferCount = SpriteBufferCount + 1
        End If
    End Sub

    Public Sub PopFromBuffer()
        If SpriteBufferCount > 0 Then
            Dim TempSpriteBuffer(SpriteBufferVar.Length - 1) As SpriteButffer
            Array.Copy(SpriteBufferVar, TempSpriteBuffer, SpriteBufferVar.Length - 1)
            SpriteBufferVar = TempSpriteBuffer
            SpriteBufferCount = SpriteBufferCount - 1
        End If
    End Sub

    Public Sub ClearBuffer()
        Erase SpriteBufferVar
        SpriteBufferCount = 0
    End Sub

#End Region

    Public Sub New(ByVal DefaultSprite As SpriteData, ByVal DefaultForm As Form, ByVal DefaultControl As Control)
        SpriteCanvasMultiplier = 16
        SpriteDrawGridStartMultiplier = 5
        SpriteCanvasScrollIncrease = False
        SpriteDrawGrid = True
        SpriteImage = Nothing
        SpriteOriginalImage = Nothing
        SpriteImageData = Nothing
        SpriteOriginalImageData = Nothing
        CurrentSpriteFrame = 1
        If IsNothing(DefaultSprite) = False Then
            Sprite = DefaultSprite
            SpriteOriginal = DefaultSprite
            SpritePalette = GetPaletteOfNumber(GetPalettes(Main.PaletteTableOffset, Main.PaletteTableEndHex, Main.MaxPalette, False), Sprite.SpritePalette)
            SpriteOriginalPalette = SpritePalette
        End If
        If IsNothing(DefaultForm) = False Then
            MainForm = DefaultForm
            If IsNothing(DefaultControl) = False Then
                PreviousPixelLocation = Nothing
                SpriteEditorGroupBox = New GroupBox
                LogPanel = Nothing
                SpriteCanvasPanel = New SpritePanel
                SpriteCanvasInnerPanel = New Panel
                SpriteCanvasPixel = New PictureBox
                SpriteCanvasVScroll = New VScrollBar
                SpriteCanvasHScroll = New HScrollBar
                SpriteCanvasScrollSeparator = New PictureBox
                SpriteCanvasVScrollBorder = New PictureBox
                SpriteCanvasHScrollBorder = New PictureBox
                SpriteMagnifyTrackBar = New TrackBar
                SpriteCurrentMagnification = New Label
                SpriteCurrentSize = New Label
                SpriteCanvas = New PictureBox
                SpriteBrowser = New TabControl
                SpriteFrameBrowserTab = New TabPage
                SpriteDetailsTab = New TabPage
                SpriteDetailsIndexLabel = New Label
                SpriteDetailsTableOffsetLabel = New Label
                SpriteDetailsHeaderOffsetLabel = New Label
                SpriteDetailsPaletteLabel = New Label
                SpriteDetailsPaletteHexDataLabel = New Label
                SpriteDetailsFrameSizeLabel = New Label
                SpriteDetailsFrameDataOffsetLabel = New Label
                SpriteDetailsFrameCountLabel = New Label
                SpriteDetailsArtDataOffset = New Label
                SpriteDetailsIndexTextBox = New TextBox
                SpriteDetailsTableOffsetTextBox = New TextBox
                SpriteDetailsHeaderOffsetTextBox = New TextBox
                SpriteDetailsPaletteTextBox = New TextBox
                SpriteDetailsPaletteHexDataTextBox = New TextBox
                SpriteDetailsFrameSizeTextBox = New TextBox
                SpriteDetailsFrameDataOffsetTextBox = New TextBox
                SpriteDetailsFrameCountTextBox = New TextBox
                SpriteDetailsArtDataOffsetTextBox = New TextBox
                SpriteDetailsPresetButton = New Button
                SpriteFrameBrowserFlowLayoutPanel = New FlowLayoutPanel
                SpriteFrameBrowserNextButton = New Button
                SpriteFrameBrowserPreviousButton = New Button
                SpriteDrawGridCheckBox = New CheckBox
                SpriteExportButton = New Button
                SpriteImportButton = New Button
                SpritePaletteGroupBox = New GroupBox
                SaveSpriteButton = New Button
                SavePaletteButton = New Button
                SaveAllButton = New Button
                PaletteConvertObject = New PaletteConvert(PaletteConvert.PaletteConvertType.Compact, SpritePaletteGroupBox, SpriteDetailsPaletteTextBox, SpriteDetailsPaletteHexDataTextBox)
                SpriteEditorControl = DefaultControl
            End If
        End If
    End Sub

    Public Function CheckNull() As Boolean
        If IsNothing(Sprite) = True Then
            Return True
        End If
        If IsNothing(SpriteEditorControl) = True Then
            Return True
        End If
        If Sprite.SpriteValid = False Then
            Return True
        End If
        Return False
    End Function

    Public Function GetSpriteFrameOffset(ByVal SpriteNumber As Integer) As String
        Dim SpriteFrameDataOffset As String = ToHex(ToDecimal(Sprite.SpriteFrameDataOffset) + (SpriteNumber - 1) * 8)
        Dim SpriteFrameData As String = ReadData(SpriteFrameDataOffset, 8)
        Return PointerToOffset(SpriteFrameData.Substring(0, 8))
    End Function

    Public Function GetSpriteData(ByVal SpriteNumber As Integer) As String
        If IsNothing(SpriteNumber) = False Then
            If (SpriteNumber > 0) And (SpriteNumber <= Sprite.SpriteFrameCount) Then
                Return ProcessSpriteData(ReadData(GetSpriteFrameOffset(SpriteNumber), Sprite.SpriteFrameSize))
            End If
        End If
        Return Nothing
    End Function

    Public Sub UpdateSpriteData(ByRef SpriteData As String, ByVal SpriteSize As Size, ByVal PixelLocation As Point, ByVal PixelIndex As Integer)
        Dim NewSpriteData As New StringBuilder()
        Dim BlockSize As New Size(8, 8)
        Dim BlockColCount As Integer = SpriteSize.Width / BlockSize.Width
        Dim BlockRowCount As Integer = SpriteSize.Height / BlockSize.Height
        Dim SpriteDataCount As Integer = 0
        For BlockRow As Integer = 1 To BlockRowCount
            For BlockCol As Integer = 1 To BlockColCount
                For Y As Integer = 0 To BlockSize.Height - 1
                    For X As Integer = 0 To BlockSize.Width - 1
                        Dim CurrentPixelLocation As Point = New Point((BlockCol - 1) * BlockSize.Width + X, (BlockRow - 1) * BlockSize.Height + Y)
                        If CurrentPixelLocation = PixelLocation Then
                            NewSpriteData.Append(ToHex(PixelIndex))
                        Else
                            NewSpriteData.Append(SpriteData(SpriteDataCount))
                        End If
                        SpriteDataCount = SpriteDataCount + 1
                    Next
                Next
            Next
        Next
        SpriteData = NewSpriteData.ToString
    End Sub

    Public Function GetPixelIndex(ByVal SpriteData As String, ByVal SpriteSize As Size, ByVal PixelLocation As Point) As Integer
        Dim BlockSize As New Size(8, 8)
        Dim BlockColCount As Integer = SpriteSize.Width / BlockSize.Width
        Dim BlockRowCount As Integer = SpriteSize.Height / BlockSize.Height
        Dim SpriteDataCount As Integer = 0
        For BlockRow As Integer = 1 To BlockRowCount
            For BlockCol As Integer = 1 To BlockColCount
                For Y As Integer = 0 To BlockSize.Height - 1
                    For X As Integer = 0 To BlockSize.Width - 1
                        Dim CurrentPixelLocation As Point = New Point((BlockCol - 1) * BlockSize.Width + X, (BlockRow - 1) * BlockSize.Height + Y)
                        If CurrentPixelLocation = PixelLocation Then
                            Return ToDecimal(SpriteData(SpriteDataCount))
                        End If
                        SpriteDataCount = SpriteDataCount + 1
                    Next
                Next
            Next
        Next
        Return 0
    End Function

    Public Function GetSpritePictureBox(ByVal SpriteControl As Control) As PictureBox
        For Each Control In SpriteControl.Controls
            Dim PictureBoxElement As PictureBox = DirectCast(Control, PictureBox)
            If IsNothing(PictureBoxElement) = False Then
                If PictureBoxElement.Name = "Sprite" Then
                    Return PictureBoxElement
                End If
            End If
        Next
        Return Nothing
    End Function

    Public Sub GenerateSpriteImage(ByRef SpriteImageVar As Bitmap, ByVal SpriteData As String, ByVal SpritePaletteData As String)
        Dim SpritePaletteDataArray() As String = SplitString(SpritePaletteData, 4)
        SpriteImageVar = New Bitmap(Sprite.SpriteSize.Width, Sprite.SpriteSize.Height, PixelFormat.Format32bppRgb)
        Dim SpriteGraphics As Graphics = Graphics.FromImage(SpriteImageVar)
        SpriteGraphics.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor
        Dim NumberOfBlocks As Integer = Sprite.SpriteSize.Width * Sprite.SpriteSize.Height / 64
        Dim BlockSize As New Size(8, 8)
        Dim SpriteDataCount As Integer = 0
        Dim BlockColCount As Integer = Sprite.SpriteSize.Width / BlockSize.Width
        Dim BlockRowCount As Integer = Sprite.SpriteSize.Height / BlockSize.Height
        Dim SpriteBitmap(NumberOfBlocks) As Bitmap
        Dim TempPaletteConvertObject As New PaletteConvert
        For BlockRow As Integer = 1 To BlockRowCount
            For BlockCol As Integer = 1 To BlockColCount
                Dim BlockCount As Integer = (BlockRow - 1) * BlockColCount + BlockCol - 1
                SpriteBitmap(BlockCount) = New Bitmap(8, 8, PixelFormat.Format32bppRgb)
                Dim SpriteRectangle As Rectangle = New Rectangle(0, 0, SpriteBitmap(BlockCount).Width, SpriteBitmap(BlockCount).Height)
                Dim SpriteBitmapData As BitmapData = SpriteBitmap(BlockCount).LockBits(SpriteRectangle, ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb)
                Dim SpritePointer As IntPtr = SpriteBitmapData.Scan0
                Dim NumberOfBytes As Integer = SpriteBitmapData.Stride * SpriteBitmap(BlockCount).Height
                Dim SpriteRGBValues(NumberOfBytes) As Byte
                Marshal.Copy(SpritePointer, SpriteRGBValues, 0, NumberOfBytes)
                For i As Integer = 0 To SpriteRGBValues.Length - 5 Step 4
                    Try
                        If SpriteDataCount < SpriteData.Length Then
                            SpriteRGBValues(i + 3) = 255
                            SpriteRGBValues(i + 2) = TempPaletteConvertObject.ReturnByte(SpritePaletteDataArray(ToDecimal(SpriteData(SpriteDataCount))),
                                                                                     PaletteConvert.ByteOf.Red)
                            SpriteRGBValues(i + 1) = TempPaletteConvertObject.ReturnByte(SpritePaletteDataArray(ToDecimal(SpriteData(SpriteDataCount))),
                                                                                     PaletteConvert.ByteOf.Green)
                            SpriteRGBValues(i + 0) = TempPaletteConvertObject.ReturnByte(SpritePaletteDataArray(ToDecimal(SpriteData(SpriteDataCount))),
                                                                                     PaletteConvert.ByteOf.Blue)
                            SpriteDataCount = SpriteDataCount + 1
                        Else
                            Exit For
                        End If
                    Catch ex As Exception
                        MsgBox(ex.Message & vbCrLf & vbCrLf & "Function : SpriteImage()" & vbCrLf & "Parameters : " + SpriteData + ", " + SpritePaletteData, , "Error!")
                    End Try
                Next
                Marshal.Copy(SpriteRGBValues, 0, SpritePointer, NumberOfBytes)
                SpriteBitmap(BlockCount).UnlockBits(SpriteBitmapData)
                SpriteGraphics.DrawImage(SpriteBitmap(BlockCount),
                                         (BlockCol - 1) * SpriteBitmap(BlockCount).Width,
                                         (BlockRow - 1) * SpriteBitmap(BlockCount).Height,
                                         SpriteBitmap(BlockCount).Width,
                                         SpriteBitmap(BlockCount).Height)
            Next
        Next
        SpriteGraphics.Dispose()
    End Sub

    Public Sub DrawCanvasSprite(ByVal SpriteControl As Control, ByVal Multiplier As Integer, ByVal GridColor As Color,
                                Optional ByVal DrawGrid As Boolean = False)
        If (CheckNull() = False) Then
            If IsNothing(SpriteControl) = False Then
                If IsNothing(GetSpritePictureBox(SpriteControl)) = False Then
                    GetSpritePictureBox(SpriteControl).Dispose()
                End If
            End If
            Dim SpritePictureBox As New PictureBox
            With SpritePictureBox
                .Name = "Sprite"
                .Width = Sprite.SpriteSize.Width * Multiplier
                .Height = Sprite.SpriteSize.Height * Multiplier
                .Image = New Bitmap(Sprite.SpriteSize.Width * Multiplier, Sprite.SpriteSize.Height * Multiplier, PixelFormat.Format32bppRgb)
                .Location = New Point(If(SpriteControl.Width > Sprite.SpriteSize.Width * Multiplier, (SpriteControl.Width - Sprite.SpriteSize.Width * Multiplier) / 2 - 1, 0),
                                      If(SpriteControl.Height > Sprite.SpriteSize.Height * Multiplier, (SpriteControl.Height - Sprite.SpriteSize.Height * Multiplier) / 2, 0))
            End With
            SpriteControl.Controls.Add(SpritePictureBox)
            AddHandler SpritePictureBox.MouseMove, AddressOf SpritePictureBoxMouseHover
            AddHandler SpritePictureBox.MouseClick, AddressOf SpritePictureBoxMouseClick
            AddHandler SpritePictureBox.MouseMove, AddressOf SpritePictureBoxMouseClick
            Dim MultipliedGraphics As Graphics = Graphics.FromImage(SpritePictureBox.Image)
            MultipliedGraphics.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor
            MultipliedGraphics.CompositingMode = Drawing2D.CompositingMode.SourceOver
            MultipliedGraphics.PixelOffsetMode = Drawing2D.PixelOffsetMode.Half
            MultipliedGraphics.DrawImage(SpriteImage, 0, 0, Sprite.SpriteSize.Width * Multiplier, Sprite.SpriteSize.Height * Multiplier)
            MultipliedGraphics.Dispose()
            If (DrawGrid = True) And (Multiplier > SpriteDrawGridStartMultiplier) Then
                Dim GridGraphics As Graphics = Graphics.FromImage(SpritePictureBox.Image)
                Dim GridSize As Size = New Size(Multiplier, Multiplier)
                Dim GridColCount As Integer = SpritePictureBox.Image.Width / GridSize.Width
                Dim GridRowCount As Integer = SpritePictureBox.Image.Height / GridSize.Height
                For GridRow As Integer = 1 To GridRowCount
                    For GridCol As Integer = 1 To GridColCount
                        GridGraphics.DrawRectangle(New Pen(GridColor, 1),
                                                   (GridCol - 1) * GridSize.Width,
                                                   (GridRow - 1) * GridSize.Height,
                                                   GridSize.Width,
                                                   GridSize.Height)
                    Next
                Next
                GridGraphics.DrawLine(New Pen(GridColor, 1), SpritePictureBox.Image.Width - 1, 0, SpritePictureBox.Image.Width - 1, SpritePictureBox.Image.Height - 1)
                GridGraphics.DrawLine(New Pen(GridColor, 1), 0, SpritePictureBox.Image.Height - 1, SpritePictureBox.Image.Width - 1, SpritePictureBox.Image.Height - 1)
                GridGraphics.Dispose()
            End If
        End If
    End Sub

    Public Sub DrawSprite(ByVal SpriteFrameNumber As Integer, ByVal SpritePaletteData As String, ByVal SpriteSize As Size, ByVal SpriteControl As Control,
                          ByVal Multiplier As Integer, ByVal GridColor As Color, Optional ByVal DrawGrid As Boolean = False)
        If IsNothing(SpriteControl) = False Then
            If IsNothing(GetSpritePictureBox(SpriteControl)) = False Then
                GetSpritePictureBox(SpriteControl).Dispose()
            End If
        End If
        Dim SpritePictureBox As New PictureBox
        With SpritePictureBox
            .Name = "Sprite"
            .Width = SpriteSize.Width * Multiplier
            .Height = SpriteSize.Height * Multiplier
            .Image = New Bitmap(SpriteSize.Width * Multiplier, SpriteSize.Height * Multiplier, PixelFormat.Format32bppRgb)
            .Location = New Point(If(SpriteControl.Width > SpriteSize.Width * Multiplier, (SpriteControl.Width - SpriteSize.Width * Multiplier) / 2 - 1, 0),
                                  If(SpriteControl.Height > SpriteSize.Height * Multiplier, (SpriteControl.Height - SpriteSize.Height * Multiplier) / 2, 0))
        End With
        SpriteControl.Controls.Add(SpritePictureBox)
        Dim MultipliedGraphics As Graphics = Graphics.FromImage(SpritePictureBox.Image)
        MultipliedGraphics.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor
        MultipliedGraphics.CompositingMode = Drawing2D.CompositingMode.SourceOver
        MultipliedGraphics.PixelOffsetMode = Drawing2D.PixelOffsetMode.Half
        Dim TempSpriteImage As Bitmap = Nothing
        GenerateSpriteImage(TempSpriteImage, GetSpriteData(SpriteFrameNumber), SpritePaletteData)
        MultipliedGraphics.DrawImage(TempSpriteImage, 0, 0, SpriteSize.Width * Multiplier, SpriteSize.Height * Multiplier)
        MultipliedGraphics.Dispose()
        If (DrawGrid = True) And (Multiplier > SpriteDrawGridStartMultiplier) Then
            Dim GridGraphics As Graphics = Graphics.FromImage(SpritePictureBox.Image)
            Dim GridSize As Size = New Size(Multiplier, Multiplier)
            Dim GridColCount As Integer = SpritePictureBox.Image.Width / GridSize.Width
            Dim GridRowCount As Integer = SpritePictureBox.Image.Height / GridSize.Height
            For GridRow As Integer = 1 To GridRowCount
                For GridCol As Integer = 1 To GridColCount
                    GridGraphics.DrawRectangle(New Pen(GridColor, 1),
                                               (GridCol - 1) * GridSize.Width,
                                               (GridRow - 1) * GridSize.Height,
                                               GridSize.Width,
                                               GridSize.Height)
                Next
            Next
            GridGraphics.DrawLine(New Pen(GridColor, 1), SpritePictureBox.Image.Width - 1, 0, SpritePictureBox.Image.Width - 1, SpritePictureBox.Image.Height - 1)
            GridGraphics.DrawLine(New Pen(GridColor, 1), 0, SpritePictureBox.Image.Height - 1, SpritePictureBox.Image.Width - 1, SpritePictureBox.Image.Height - 1)
            GridGraphics.Dispose()
        End If
        TempSpriteImage.Dispose()
    End Sub

    'Public Sub DrawSpritePictureBox(ByVal SpriteData As String, ByVal SpritePaletteData As String, ByVal SpriteSize As Size,
    '                       ByVal SpriteControl As Control, ByVal Multiplier As Integer)
    '    Dim SpritePaletteDataArray() As String = SplitString(SpritePaletteData, 4)
    '    SpriteData = ProcessSpriteData(SpriteData)
    '    Dim BlockSize As New Size(8, 8)
    '    Dim SpriteDataCount As Integer = 0
    '    Dim BlockColCount As Integer = SpriteSize.Width / BlockSize.Width
    '    Dim BlockRowCount As Integer = SpriteSize.Height / BlockSize.Height
    '    For BlockRow As Integer = 1 To BlockRowCount
    '        For BlockCol As Integer = 1 To BlockColCount
    '            For Y As Integer = 1 To BlockSize.Height
    '                For X As Integer = 1 To BlockSize.Width
    '                    Dim BlockPixel As New PictureBox
    '                    With BlockPixel
    '                        .Padding = New Padding(0, 0, 0, 0)
    '                        .Margin = New Padding(0, 0, 0, 0)
    '                        .Width = Multiplier
    '                        .Height = Multiplier
    '                        .BackColor = PaletteConvertObject.ReturnColor(SpritePaletteDataArray(ToDecimal(SpriteData(SpriteDataCount))))
    '                        .Location = New Point(((X - 1) + (BlockCol - 1) * BlockSize.Width) * Multiplier, ((Y - 1) + (BlockRow - 1) * BlockSize.Height) * Multiplier)
    '                        .BorderStyle = BorderStyle.FixedSingle
    '                    End With
    '                    SpriteControl.Controls.Add(BlockPixel)
    '                    SpriteDataCount = SpriteDataCount + 1
    '                Next
    '            Next
    '        Next
    '    Next
    'End Sub

    Public Sub GenerateSpriteEditor()
        If CheckNull() = False Then
            SpriteEditorGroupBox.Controls.Clear()
            With SpriteEditorGroupBox
                .Name = "SpriteEditorGroupBox"
                .Location = New Point(3, 0)
                .Size = New Size(SpriteEditorControl.Width - 8, 352)
                .BackColor = Color.White
                .Text = "Sprite Editor"
            End With
            With SpriteCanvasPanel
                .Location = New Point(6, 16)
                .Padding = New Padding(0, 0, 0, 0)
                .Size = New Size(280, 280)
                .BorderStyle = BorderStyle.None
                .AutoScroll = False
            End With
            With SpriteCanvasInnerPanel
                .Location = New Point(2, 2)
                .Padding = New Padding(0, 0, 0, 0)
                .Size = New Size(256, 256)
                .BorderStyle = BorderStyle.None
                .AutoScroll = False
                .BackColor = PaletteConvertObject.GetColorOfIndex(SpritePalette.PaletteHexData, 0)
            End With
            AddHandler SpriteCanvasInnerPanel.MouseWheel, AddressOf ScrollCanvas
            With SpriteCanvasPixel
                .Size = New Size(SpriteCanvasMultiplier, SpriteCanvasMultiplier)
                .BackColor = PaletteConvertObject.SelectedPaletteColor
            End With
            With SpriteCanvasVScroll
                .Height = 256
                .Width = 18
                .Location = New Point(SpriteCanvasPanel.Width - SpriteCanvasVScroll.Width - 2, 2)
            End With
            AddHandler SpriteCanvasVScroll.ValueChanged, Sub()
                                                             SpriteCanvasVerticalScroll()
                                                         End Sub
            With SpriteCanvasHScroll
                .Height = 18
                .Width = 256
                .Location = New Point(2, SpriteCanvasPanel.Height - SpriteCanvasHScroll.Height - 2)
            End With
            AddHandler SpriteCanvasHScroll.ValueChanged, Sub()
                                                             SpriteCanvasHorizontalScroll()
                                                         End Sub
            With SpriteCanvasScrollSeparator
                .Width = 20
                .Height = 20
                .Location = New Point(SpriteCanvasPanel.Width - SpriteCanvasScrollSeparator.Width - 2, SpriteCanvasPanel.Height - SpriteCanvasScrollSeparator.Height - 2)
                .BackColor = Color.Black
            End With
            With SpriteCanvasVScrollBorder
                .Height = 258
                .Width = 2
                .Location = New Point(SpriteCanvasPanel.Width - SpriteCanvasVScroll.Width - 4, 2)
                .BackColor = Color.Black
            End With
            With SpriteCanvasHScrollBorder
                .Height = 2
                .Width = 258
                .Location = New Point(2, SpriteCanvasPanel.Height - SpriteCanvasHScroll.Height - 4)
                .BackColor = Color.Black
            End With
            With SpriteMagnifyTrackBar
                .Location = New Point(6, 302)
                .AutoSize = False
                .Size = New Size(280, 30)
                .Minimum = 1
                .Maximum = 30
                .Value = SpriteCanvasMultiplier
            End With
            AddHandler SpriteMagnifyTrackBar.ValueChanged, AddressOf SpriteMagnifyTrackBarValueChanged
            With SpriteCurrentMagnification
                .Location = New Point(7, 330)
                .Text = CStr(SpriteCanvasMultiplier) + "x Magnified"
                .Font = New Font("Calibri", 8, FontStyle.Bold)
                .AutoSize = False
                .Height = 15
                .TextAlign = ContentAlignment.MiddleLeft
            End With
            With SpriteCurrentSize
                .Location = New Point(79, 330)
                .Text = "Current Size : " + CStr(Sprite.SpriteSize.Width * SpriteCanvasMultiplier) + " x " + CStr(Sprite.SpriteSize.Height * SpriteCanvasMultiplier) + _
                        " [" + CStr(Sprite.SpriteSize.Width) + " x " + CStr(Sprite.SpriteSize.Height) + "]"
                .Font = New Font("Calibri", 8, FontStyle.Bold)
                .AutoSize = False
                .Height = 15
                .Width = 206
                .TextAlign = ContentAlignment.MiddleRight
            End With
            With SpritePaletteGroupBox
                .Text = "Sprite Palette Editor"
                .Location = New Point(SpriteCanvasPanel.Width + 11, 12)
                .Size = New Size(SpriteEditorGroupBox.Width - SpriteCanvasPanel.Width - 16, 117)
            End With
            With SpriteBrowser
                .Location = New Point(SpriteCanvasPanel.Width + 11, 161)
                .Size = New Size(SpriteEditorGroupBox.Width - SpriteCanvasPanel.Width - 14, SpritePaletteGroupBox.Height + 42)
            End With
            With SpriteFrameBrowserTab
                .Text = "Sprite Frame Browser"
                .AutoScroll = False
                .Font = New Font("Calibri", 9, FontStyle.Bold)
                .Padding = New Padding(0, 0, 0, 0)
                .UseVisualStyleBackColor = True
                .BackColor = Color.White
            End With
            With SpriteDetailsTab
                .Text = "Sprite Frame Details"
                .AutoScroll = True
                .Font = New Font("Calibri", 9, FontStyle.Bold)
                .Padding = New Padding(0, 0, 0, 0)
                .UseVisualStyleBackColor = True
                .BackColor = Color.White
            End With
            With SpriteDetailsIndexLabel
                .Location = New Point(1, 5)
                .Text = "Sprite Number :"
                .BackColor = Color.White
                .AutoSize = False
                .Height = 20
            End With
            With SpriteDetailsIndexTextBox
                .Location = New Point(144, 3)
                .BackColor = Color.White
                .AutoSize = False
                .Height = 20
                .ReadOnly = True
                .Width = 100
            End With
            With SpriteDetailsTableOffsetLabel
                .Location = New Point(1, 28)
                .Text = "Table Offset :"
                .BackColor = Color.White
                .AutoSize = False
                .Height = 20
            End With
            With SpriteDetailsTableOffsetTextBox
                .Location = New Point(144, 26)
                .BackColor = Color.White
                .AutoSize = False
                .Height = 20
                .ReadOnly = True
                .Width = 100
                .MaxLength = 6
            End With
            With SpriteDetailsHeaderOffsetLabel
                .Location = New Point(1, 51)
                .Text = "Header Offset :"
                .BackColor = Color.White
                .AutoSize = False
                .Height = 20
            End With
            With SpriteDetailsHeaderOffsetTextBox
                .Location = New Point(144, 49)
                .BackColor = Color.White
                .AutoSize = False
                .Height = 20
                .ReadOnly = True
                .Width = 100
                .MaxLength = 6
            End With
            With SpriteDetailsPaletteLabel
                .Location = New Point(1, 74)
                .Text = "Palette Number [Decimal] :"
                .BackColor = Color.White
                .AutoSize = False
                .Width = 143
                .Height = 20
            End With
            With SpriteDetailsPaletteTextBox
                .Location = New Point(144, 72)
                .BackColor = Color.White
                .AutoSize = False
                .Height = 20
                .ReadOnly = True
                .Width = 100
            End With
            With SpriteDetailsPaletteHexDataLabel
                .Location = New Point(1, 97)
                .Text = "Palette Hex Data :"
                .BackColor = Color.White
                .AutoSize = False
                .Width = 143
                .Height = 20
            End With
            With SpriteDetailsPaletteHexDataTextBox
                .Location = New Point(144, 95)
                .BackColor = Color.White
                .AutoSize = False
                .Height = 20
                .ReadOnly = True
                .Width = 100
                .MaxLength = 64
            End With
            AddHandler SpriteDetailsPaletteHexDataTextBox.TextChanged,
            AddressOf SpriteDetailsPaletteHexDataTextBoxTextChanged
            With SpriteDetailsFrameSizeLabel
                .Location = New Point(1, 120)
                .Text = "Frame Size [Decimal] :"
                .BackColor = Color.White
                .AutoSize = False
                .Width = 143
                .Height = 20
            End With
            With SpriteDetailsFrameSizeTextBox
                .Location = New Point(144, 118)
                .BackColor = Color.White
                .AutoSize = False
                .Height = 20
                .ReadOnly = True
                .Width = 100
            End With
            With SpriteDetailsFrameDataOffsetLabel
                .Location = New Point(1, 143)
                .Text = "Frame Data Offset :"
                .BackColor = Color.White
                .AutoSize = False
                .Width = 143
                .Height = 20
            End With
            With SpriteDetailsFrameDataOffsetTextBox
                .Location = New Point(144, 141)
                .BackColor = Color.White
                .AutoSize = False
                .Height = 20
                .ReadOnly = True
                .Width = 100
                .MaxLength = 6
            End With
            With SpriteDetailsFrameCountLabel
                .Location = New Point(1, 166)
                .Text = "Frame Count :"
                .BackColor = Color.White
                .AutoSize = False
                .Width = 143
                .Height = 20
            End With
            With SpriteDetailsFrameCountTextBox
                .Location = New Point(144, 164)
                .BackColor = Color.White
                .AutoSize = False
                .Height = 20
                .ReadOnly = True
                .Width = 100
            End With
            With SpriteDetailsArtDataOffset
                .Location = New Point(1, 189)
                .Text = "Art Data Offset :"
                .BackColor = Color.White
                .AutoSize = False
                .Width = 143
                .Height = 20
            End With
            With SpriteDetailsArtDataOffsetTextBox
                .Location = New Point(144, 187)
                .BackColor = Color.White
                .AutoSize = False
                .Height = 20
                .ReadOnly = True
                .Width = 100
                .MaxLength = 6
            End With
            With SpriteDetailsPresetButton
                .Location = New Point(1, 209)
                .Text = "Sprite Preset Details"
                .BackColor = Color.Transparent
                .AutoSize = False
                .Height = 26
                .Width = 244
            End With
            AddHandler SpriteDetailsPresetButton.Click, Sub()
                                                            MessageBox.Show("Magikarp Used Splash!", "...")
                                                        End Sub
            With SpriteFrameBrowserFlowLayoutPanel
                .Location = New Point(1, 3)
                .Width = SpriteBrowser.Width - 12
                .Height = SpriteBrowser.Height - 63
                .AutoScroll = True
                .BorderStyle = BorderStyle.FixedSingle
                .BackColor = Color.White
            End With
            With SpriteFrameBrowserNextButton
                .Location = New Point(SpriteBrowser.Width - 111, SpriteBrowser.Height - 56)
                .Text = "Next Sprite"
                .BackColor = Color.Transparent
                .AutoSize = False
                .Height = 26
                .Width = 100
            End With
            AddHandler SpriteFrameBrowserNextButton.Click, AddressOf SpriteFrameBrowserNextButtonClick
            With SpriteFrameBrowserPreviousButton
                .Location = New Point(1, SpriteBrowser.Height - 56)
                .Text = "Previous Sprite"
                .BackColor = Color.Transparent
                .AutoSize = False
                .Height = 26
                .Width = 100
            End With
            AddHandler SpriteFrameBrowserPreviousButton.Click, AddressOf SpriteFrameBrowserPreviousButtonClick
            With SpriteDrawGridCheckBox
                .Text = "Draw Grid"
                .Checked = SpriteDrawGrid
                .Location = New Point(SpriteCanvasPanel.Width + 19, SpritePaletteGroupBox.Height + 17)
                .Padding = New Padding(0, 0, 0, 0)
                .AutoSize = False
                .Width = 82
                .CheckAlign = ContentAlignment.MiddleLeft
                .Margin = New Padding(0, 0, 0, 0)
            End With
            AddHandler SpriteDrawGridCheckBox.CheckedChanged, Sub()
                                                                  SpriteDrawGrid = SpriteDrawGridCheckBox.Checked
                                                                  If SpriteCanvasMultiplier >= SpriteDrawGridStartMultiplier Then
                                                                      ReDrawSprite()
                                                                  End If
                                                              End Sub
            With SpriteExportButton
                .Location = New Point(SpriteEditorGroupBox.Width - 94, SpritePaletteGroupBox.Height + 15)
                .Text = "Export Sprite"
                .BackColor = Color.Transparent
                .AutoSize = False
                .Height = 26
                .Width = 90
            End With
            AddHandler SpriteExportButton.Click, AddressOf SpriteExport
            With SpriteImportButton
                .Location = New Point(SpriteEditorGroupBox.Width - 186, SpritePaletteGroupBox.Height + 15)
                .Text = "Import Sprite"
                .BackColor = Color.Transparent
                .AutoSize = False
                .Height = 26
                .Width = 90
            End With
            AddHandler SpriteImportButton.Click, AddressOf SpriteImport
            With SaveAllButton
                .Text = "Save All"
                .BackColor = Color.Transparent
                .AutoSize = False
                .Height = 26
                .Width = 90
                .Location = New Point(SpriteBrowser.Location.X + SpriteBrowser.Width - SaveAllButton.Width - 1,
                                      SpriteEditorGroupBox.Height - SaveAllButton.Height - 4)
            End With
            AddHandler SaveAllButton.Click, Sub()
                                                SaveAll(True)
                                            End Sub
            With SavePaletteButton
                .Text = "Save Palette"
                .BackColor = Color.Transparent
                .AutoSize = False
                .Height = 26
                .Width = 92
                .Location = New Point(SpriteBrowser.Location.X - 1,
                                      SpriteEditorGroupBox.Height - SavePaletteButton.Height - 4)
            End With
            AddHandler SavePaletteButton.Click, Sub()
                                                    SavePalette(True)
                                                End Sub
            With SaveSpriteButton
                .Text = "Save Sprite"
                .BackColor = Color.Transparent
                .AutoSize = False
                .Height = 26
                .Width = 90
                .Location = New Point(SavePaletteButton.Location.X + SavePaletteButton.Width + 2,
                                      SpriteEditorGroupBox.Height - SaveSpriteButton.Height - 4)
            End With
            AddHandler SaveSpriteButton.Click, Sub()
                                                   SaveSprite(True)
                                               End Sub
            SpriteOriginalImageData = GetSpriteData(CurrentSpriteFrame)
            SpriteImageData = SpriteOriginalImageData
            GenerateSpriteImage(SpriteOriginalImage, SpriteOriginalImageData, SpritePalette.PaletteHexData)
            GenerateSpriteImage(SpriteImage, SpriteImageData, SpritePalette.PaletteHexData)
            SpriteEditorControl.Controls.Add(SpriteEditorGroupBox)
            SpriteEditorGroupBox.Controls.AddRange({SpriteCanvasPanel, SpriteMagnifyTrackBar, SpriteCurrentMagnification, SpriteCurrentSize, SpriteBrowser,
                                                    SpriteDrawGridCheckBox, SpritePaletteGroupBox, SpriteExportButton, SpriteImportButton,
                                                    SavePaletteButton, SaveSpriteButton, SaveAllButton})
            SpriteBrowser.TabPages.Clear()
            SpriteBrowser.TabPages.AddRange({SpriteFrameBrowserTab, SpriteDetailsTab})
            SpriteDetailsTab.Controls.AddRange({SpriteDetailsIndexLabel, SpriteDetailsIndexTextBox,
                                                SpriteDetailsTableOffsetLabel, SpriteDetailsTableOffsetTextBox,
                                                SpriteDetailsHeaderOffsetLabel, SpriteDetailsHeaderOffsetTextBox,
                                                SpriteDetailsPaletteLabel, SpriteDetailsPaletteTextBox,
                                                SpriteDetailsFrameSizeLabel, SpriteDetailsFrameSizeTextBox,
                                                SpriteDetailsFrameDataOffsetLabel, SpriteDetailsFrameDataOffsetTextBox,
                                                SpriteDetailsFrameCountLabel, SpriteDetailsFrameCountTextBox,
                                                SpriteDetailsArtDataOffset, SpriteDetailsArtDataOffsetTextBox,
                                                SpriteDetailsPaletteHexDataLabel, SpriteDetailsPaletteHexDataTextBox,
                                                SpriteDetailsPresetButton})
            SpriteFrameBrowserTab.Controls.AddRange({SpriteFrameBrowserFlowLayoutPanel, SpriteFrameBrowserNextButton, SpriteFrameBrowserPreviousButton})
            GenerateSpriteFrameBrowser()
            GenerateSpriteDetails()
            SpriteCanvasPanel.Controls.AddRange({SpriteCanvasInnerPanel, SpriteCanvasVScroll, SpriteCanvasHScroll, SpriteCanvasScrollSeparator,
                                                 SpriteCanvasVScrollBorder, SpriteCanvasHScrollBorder})
            SpriteCanvasInnerPanel.Controls.Add(SpriteCanvasPixel)
            SpriteCanvasPixel.SendToBack()
            SpriteCanvasPixel.Hide()
            SpriteCanvasInnerPanel.SendToBack()
            SpriteCurrentSize.BringToFront()
            DrawCanvasSprite(SpriteCanvasInnerPanel, SpriteCanvasMultiplier, Color.Black, SpriteDrawGrid)
            PaletteConvertObject.ResetPaletteData = SpritePalette.PaletteHexData
            PaletteConvertObject.GeneratePaletteBoxCompact()
            AddHandler MainForm.MouseWheel, AddressOf ScrollCanvas
            AddHandler MainForm.KeyDown, AddressOf TranslateCanvas
            AddHandler MainForm.KeyDown, AddressOf SpriteCanvaseScrollIncreaseKeyDown
            AddHandler MainForm.KeyUp, AddressOf SpriteCanvaseScrollIncreaseKeyUp
            AddHandler MainForm.KeyPress, AddressOf SpriteCanvaseScrollIncreaseKeyPress
            If MaintainBuffer = True Then
                AddHandler MainForm.KeyDown, AddressOf SpriteUndo
            End If
            EnableDisableScrolls()
            EnableDisableButtons()
        Else
            If Sprite.SpriteValid = False Then
                MessageBox.Show("It seems like the sprite header doesn't have a defined value of number of sprite frames. Please apply sprite patch if not applied yet." + vbCrLf & vbCrLf + "OWS Table Browser is now exiting...", "Invalid Sprite Detected!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                SpriteEditorControl.Dispose()
            End If
        End If
    End Sub

    Public Function CheckSpriteDataChange() As Boolean
        If String.Compare(SpriteImageData, SpriteOriginalImageData) = 0 Then
            Return False
        End If
        Return True
    End Function

    Public Function CheckSpritePaletteChange(Optional ByVal OnlyYesOrNo As Boolean = True) As PaletteChange
        If String.Compare(SpriteOriginalPalette.PaletteHexData, PaletteConvertObject.TempPaletteData) = 0 Then
            Return PaletteChange.No
        Else
            If OnlyYesOrNo = True Then
                Return PaletteChange.Yes
            Else
                If String.Compare(SpritePalette.PaletteHexData, PaletteConvertObject.TempPaletteData) <> 0 Then
                    Return PaletteChange.YesNotApplied
                Else
                    Return PaletteChange.YesApplied
                End If
            End If
        End If
        Return PaletteChange.No
    End Function

    Public Sub Log(ByVal Text As String, Optional ByVal IsStart As Boolean = False, Optional ByVal IsEnd As Boolean = False, Optional ByVal PerformUpdate As Boolean = False)
        If (IsStart = True) And (IsNothing(LogPanel) = True) Then
            LogPanel = New Panel
            Dim LogGroupBox As GroupBox = New GroupBox
            Dim LogRichTextBox As RichTextBox = New RichTextBox
            Dim LogButton As Button = New Button
            With LogPanel
                .Width = SpritePaletteGroupBox.Width
                .Height = SpriteEditorGroupBox.Height - 47
                .Location = New Point(SpritePaletteGroupBox.Location.X, SpritePaletteGroupBox.Location.Y + 3)
                .BorderStyle = BorderStyle.FixedSingle
            End With
            With LogGroupBox
                .Text = "Log"
                .Location = New Point(3, 3)
                .Width = LogPanel.Width - 8
                .Height = LogPanel.Height - 38
            End With
            With LogRichTextBox
                .Name = "LogRichTextBox"
                .Text = Text
                .Width = LogGroupBox.Width - 10
                .Height = LogGroupBox.Height - 18
                .Location = New Point(6, 15)
                .ReadOnly = True
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
            End With
            With LogButton
                .Name = "LogButton"
                .Text = "Back To Editor"
                .Location = New Point(3, LogPanel.Height - 32)
                .AutoSize = False
                .Width = LogGroupBox.Width
                .Height = 27
                .Enabled = False
            End With
            SpriteEditorGroupBox.Controls.Add(LogPanel)
            LogPanel.Controls.AddRange({LogGroupBox, LogButton})
            LogGroupBox.Controls.Add(LogRichTextBox)
            LogPanel.BringToFront()
            Return
        Else
            If IsStart = True Then
                For Each Control In LogPanel.Controls.OfType(Of Button)()
                    If Control.Name = "LogButton" Then
                        Control.Enabled = False
                    End If
                Next
            End If
            For Each Control In LogPanel.Controls.Find("LogRichTextBox", True)
                Control.Text += vbCrLf & Text
            Next
        End If
        If IsEnd = True Then
            For Each Control In LogPanel.Controls.OfType(Of Button)()
                If Control.Name = "LogButton" Then
                    AddHandler Control.Click, Sub()
                                                  If PerformUpdate = True Then
                                                      Update(UpdateSpriteEditor.All)
                                                  End If
                                                  LogPanel.Controls.Clear()
                                                  LogPanel.Dispose()
                                                  LogPanel = Nothing
                                              End Sub
                    Control.Enabled = True
                    Control.Select()
                    Return
                End If
            Next
        End If
    End Sub

    Public Sub EnableDisableScrolls()
        Dim SpritePictureBox As PictureBox = GetSpritePictureBox(SpriteCanvasInnerPanel)
        If SpritePictureBox.Width > SpriteCanvasInnerPanel.Width Then
            SpriteCanvasHScroll.Maximum = SpritePictureBox.Width - SpriteCanvasInnerPanel.Width
            SpriteCanvasHScroll.Minimum = 0
            SpriteCanvasHScroll.Enabled = True
        Else
            SpriteCanvasHScroll.Enabled = False
        End If
        If SpritePictureBox.Height > SpriteCanvasInnerPanel.Height Then
            SpriteCanvasVScroll.Maximum = SpritePictureBox.Height - SpriteCanvasInnerPanel.Height
            SpriteCanvasVScroll.Minimum = 0
            SpriteCanvasVScroll.Enabled = True
        Else
            SpriteCanvasVScroll.Enabled = False
        End If
    End Sub

    Public Sub EnableDisableButtons()
        If CurrentSpriteFrame = 1 Then
            SpriteFrameBrowserPreviousButton.Enabled = False
            SpriteFrameBrowserNextButton.Enabled = True
        ElseIf CurrentSpriteFrame = Sprite.SpriteFrameCount Then
            SpriteFrameBrowserPreviousButton.Enabled = True
            SpriteFrameBrowserNextButton.Enabled = False
        Else
            SpriteFrameBrowserPreviousButton.Enabled = True
            SpriteFrameBrowserNextButton.Enabled = True
        End If
    End Sub

    Public Sub ReDrawSprite()
        SpriteCurrentMagnification.Text = CStr(SpriteCanvasMultiplier) + "x Magnified"
        SpriteCurrentSize.Text = "Current Size : " + CStr(Sprite.SpriteSize.Width * SpriteCanvasMultiplier) + " x " + CStr(Sprite.SpriteSize.Height * SpriteCanvasMultiplier) + _
                                 " [" + CStr(Sprite.SpriteSize.Width) + " x " + CStr(Sprite.SpriteSize.Height) + "]"
        DrawCanvasSprite(SpriteCanvasInnerPanel, SpriteCanvasMultiplier, Color.Black, SpriteDrawGrid)
        SpriteCanvasPixel.Size = New Size(SpriteCanvasMultiplier, SpriteCanvasMultiplier)
        Dim SpritePictureBox As PictureBox = GetSpritePictureBox(SpriteCanvasInnerPanel)
        If SpritePictureBox.Width > SpriteCanvasInnerPanel.Width Then
            SpriteCanvasHorizontalScroll()
        End If
        If SpritePictureBox.Height > SpriteCanvasInnerPanel.Height Then
            SpriteCanvasVerticalScroll()
        End If
        EnableDisableButtons()
        SpriteCanvasInnerPanel.Select()
    End Sub

    Public Sub SpriteMagnifyTrackBarValueChanged(sender As Object, e As EventArgs)
        SpriteCanvasMultiplier = SpriteMagnifyTrackBar.Value
        ReDrawSprite()
        EnableDisableScrolls()
    End Sub

    Public Sub SpritePictureBoxMouseHover(sender As Object, e As MouseEventArgs)
        SpriteCanvasInnerPanel.Select()
    End Sub

    Public Sub SpriteCanvasHScrollIncrease()
        If SpriteCanvasHScroll.Value < SpriteCanvasHScroll.Maximum Then
            If (SpriteCanvasHScroll.Value + If(SpriteCanvasScrollIncrease, SpriteCanvasHScroll.SmallChange * 5, SpriteCanvasHScroll.SmallChange)) _
                <= SpriteCanvasHScroll.Maximum Then
                SpriteCanvasHScroll.Value = SpriteCanvasHScroll.Value + If(SpriteCanvasScrollIncrease, SpriteCanvasHScroll.SmallChange * 5,
                                                                           SpriteCanvasHScroll.SmallChange)
            Else
                SpriteCanvasHScroll.Value = SpriteCanvasHScroll.Maximum
            End If
        End If
    End Sub

    Public Sub SpriteCanvasHScrollDecrease()
        If SpriteCanvasHScroll.Value > SpriteCanvasHScroll.Minimum Then
            If (SpriteCanvasHScroll.Value - If(SpriteCanvasScrollIncrease, SpriteCanvasHScroll.SmallChange * 5, SpriteCanvasHScroll.SmallChange)) _
                >= SpriteCanvasHScroll.Minimum Then
                SpriteCanvasHScroll.Value = SpriteCanvasHScroll.Value - If(SpriteCanvasScrollIncrease, SpriteCanvasHScroll.SmallChange * 5,
                                                                           SpriteCanvasHScroll.SmallChange)
            Else
                SpriteCanvasHScroll.Value = SpriteCanvasHScroll.Minimum
            End If
        End If
    End Sub

    Public Sub SpriteCanvasVScrollIncrease()
        If SpriteCanvasVScroll.Value < SpriteCanvasVScroll.Maximum Then
            If (SpriteCanvasVScroll.Value + If(SpriteCanvasScrollIncrease, SpriteCanvasVScroll.SmallChange * 5, SpriteCanvasVScroll.SmallChange)) _
                <= SpriteCanvasVScroll.Maximum Then
                SpriteCanvasVScroll.Value = SpriteCanvasVScroll.Value + If(SpriteCanvasScrollIncrease, SpriteCanvasVScroll.SmallChange * 5,
                                                                           SpriteCanvasVScroll.SmallChange)
            Else
                SpriteCanvasVScroll.Value = SpriteCanvasVScroll.Maximum
            End If
        End If
    End Sub

    Public Sub SpriteCanvasVScrollDecrease()
        If SpriteCanvasVScroll.Value > SpriteCanvasVScroll.Minimum Then
            If (SpriteCanvasVScroll.Value - If(SpriteCanvasScrollIncrease, SpriteCanvasVScroll.SmallChange * 5, SpriteCanvasVScroll.SmallChange)) _
                >= SpriteCanvasHScroll.Minimum Then
                SpriteCanvasVScroll.Value = SpriteCanvasVScroll.Value - If(SpriteCanvasScrollIncrease, SpriteCanvasVScroll.SmallChange * 5,
                                                                           SpriteCanvasVScroll.SmallChange)
            Else
                SpriteCanvasVScroll.Value = SpriteCanvasVScroll.Minimum
            End If
        End If
    End Sub

    Public Sub ScrollCanvas(sender As Object, e As MouseEventArgs)
        If (e.Delta > 0) And (Control.ModifierKeys = 131072) Then   'Ctrl Key
            SpriteCanvasMultiplier = SpriteCanvasMultiplier + 1
            If SpriteCanvasMultiplier <= SpriteMagnifyTrackBar.Maximum Then
                SpriteMagnifyTrackBar.Value = SpriteCanvasMultiplier
                ReDrawSprite()
                EnableDisableScrolls()
            Else
                SpriteCanvasMultiplier = SpriteMagnifyTrackBar.Maximum
            End If
        ElseIf (e.Delta < 0) And (Control.ModifierKeys = 131072) Then
            SpriteCanvasMultiplier = SpriteCanvasMultiplier - 1
            If SpriteCanvasMultiplier >= SpriteMagnifyTrackBar.Minimum Then
                SpriteMagnifyTrackBar.Value = SpriteCanvasMultiplier
                ReDrawSprite()
                EnableDisableScrolls()
            Else
                SpriteCanvasMultiplier = SpriteMagnifyTrackBar.Minimum
            End If
        ElseIf (e.Delta < 0) And (Control.ModifierKeys = 65536) Then    'Shift Key
            If SpriteCanvasHScroll.Enabled = True Then
                SpriteCanvasHScrollIncrease()
            End If
        ElseIf (e.Delta > 0) And (Control.ModifierKeys = 65536) Then
            If SpriteCanvasHScroll.Enabled = True Then
                SpriteCanvasHScrollDecrease()
            End If
        ElseIf (e.Delta < 0) Then
            If SpriteCanvasVScroll.Enabled = True Then
                SpriteCanvasVScrollIncrease()
            End If
        ElseIf (e.Delta > 0) Then
            If SpriteCanvasVScroll.Enabled = True Then
                SpriteCanvasVScrollDecrease()
            End If
        End If
    End Sub

    Public Sub TranslateCanvas(sender As Object, e As KeyEventArgs)
        Dim SpritePictureBox As PictureBox = GetSpritePictureBox(SpriteCanvasInnerPanel)
        If SpritePictureBox.Width > SpriteCanvasInnerPanel.Width Then
            If e.KeyCode = 37 Then
                SpriteCanvasHScrollDecrease()
            End If
            If e.KeyCode = 39 Then
                SpriteCanvasHScrollIncrease()
            End If
        End If
        If SpritePictureBox.Height > SpriteCanvasInnerPanel.Height Then
            If e.KeyCode = 38 Then
                SpriteCanvasVScrollDecrease()
            End If
            If e.KeyCode = 40 Then
                SpriteCanvasVScrollIncrease()
            End If
        End If
    End Sub

    Public Sub SpriteCanvasVerticalScroll()
        Dim SpritePictureBox As PictureBox = GetSpritePictureBox(SpriteCanvasInnerPanel)
        SpritePictureBox.Top = (-1) * SpriteCanvasVScroll.Value
    End Sub

    Public Sub SpriteCanvasHorizontalScroll()
        Dim SpritePictureBox As PictureBox = GetSpritePictureBox(SpriteCanvasInnerPanel)
        SpritePictureBox.Left = (-1) * SpriteCanvasHScroll.Value
    End Sub

    Public Sub SpriteCanvaseScrollIncreaseKeyDown(sender As Object, e As KeyEventArgs)
        If (SpriteCanvasScrollIncrease = True) And (e.KeyCode = 16) Then
            SpriteCanvasScrollIncrease = True
        ElseIf e.KeyCode = 88 Then
            SpriteCanvasScrollIncrease = True
        Else
            SpriteCanvasScrollIncrease = False
        End If
    End Sub

    Public Sub SpriteCanvaseScrollIncreaseKeyUp(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 88 Then
            SpriteCanvasScrollIncrease = False
        End If
    End Sub

    Public Sub SpriteCanvaseScrollIncreaseKeyPress(sender As Object, e As KeyPressEventArgs)
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 122) Or (Microsoft.VisualBasic.Asc(e.KeyChar) = 90) Then 'Z Key
            If SpriteCanvasScrollIncrease = False Then
                SpriteCanvasScrollIncrease = True
            Else
                SpriteCanvasScrollIncrease = False
            End If
        End If
    End Sub

    Public Sub PerformSpriteFrameChange(ByVal NewSpriteFrame As Integer)
        Dim ChangeSprite As Boolean = False
        If CheckSpriteDataChange() = True Then
            Dim Result As Integer = MessageBox.Show("Sprite #" + CStr(CurrentSpriteFrame) + " has been altered and the changes haven't been saved yet. Proceeding without saving will permanently delete the changes made to the sprite." & vbCrLf & vbCrLf & "Do you want to save and proceed?", "Sprite #" + CStr(CurrentSpriteFrame) + " Altered!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation)
            If Result = DialogResult.Yes Then
                SaveSprite(False, True)
                Update(UpdateSpriteEditor.Browser)
                ChangeSprite = True
            ElseIf Result = DialogResult.No Then
                ChangeSprite = True
            Else
                ChangeSprite = False
            End If
        Else
            ChangeSprite = True
        End If
        If ChangeSprite = True Then
            CurrentSpriteFrame = NewSpriteFrame
            SpriteImageData = GetSpriteData(CurrentSpriteFrame)
            SpriteOriginalImageData = GetSpriteData(CurrentSpriteFrame)
            GenerateSpriteImage(SpriteImage, SpriteImageData, SpritePalette.PaletteHexData)
            SpriteOriginalImage = SpriteImage.Clone()
            ClearBuffer()
            Update(UpdateSpriteEditor.Canvas)
            Update(UpdateSpriteEditor.Details)
        End If
    End Sub

    Public Sub GenerateSpriteFrameBrowser()
        SpriteFrameBrowserFlowLayoutPanel.Controls.Clear()
        For i As Integer = 1 To Sprite.SpriteFrameCount
            Dim SpriteFramePanel As New SpritePanel
            With SpriteFramePanel
                .BorderStyle = BorderStyle.None
                .Size = New Size(Sprite.SpriteSize.Width + 4, Sprite.SpriteSize.Height + 4)
                .Cursor = Cursors.Hand
                .Tag = i
            End With
            SpriteFrameBrowserFlowLayoutPanel.Controls.Add(SpriteFramePanel)
            DrawSprite(i, SpritePalette.PaletteHexData, Sprite.SpriteSize, SpriteFramePanel, 1, Color.Black, False)
            Dim SpriteFramePanelPictureBox As PictureBox = GetSpritePictureBox(SpriteFramePanel)
            SpriteFramePanelPictureBox.Location = New Point(2, 2)
            AddHandler SpriteFramePanelPictureBox.Click, Sub(sender As Object, e As EventArgs)
                                                             Dim SpriteFramePanelPictureBoxTemp As PictureBox = DirectCast(sender, PictureBox)
                                                             PerformSpriteFrameChange(CInt(SpriteFramePanelPictureBoxTemp.Parent.Tag))
                                                         End Sub
        Next
    End Sub

    Public Sub SpriteFrameBrowserNextButtonClick(sender As Object, e As EventArgs)
        PerformSpriteFrameChange(CurrentSpriteFrame + 1)
    End Sub

    Public Sub SpriteFrameBrowserPreviousButtonClick(sender As Object, e As EventArgs)
        PerformSpriteFrameChange(CurrentSpriteFrame - 1)
    End Sub

    Public Sub GenerateSpriteDetails()
        Try
            With SpriteDetailsIndexTextBox
                .Text = CStr(Sprite.SpriteIndex + 1) + " [" + CStr(CurrentSpriteFrame) + "/" + If(Sprite.SpriteFrameCount > 0, CStr(Sprite.SpriteFrameCount), "N/A") + "]"
            End With
            With SpriteDetailsTableOffsetTextBox
                .Text = CStr(Sprite.SpriteTableOffset)
            End With
            With SpriteDetailsHeaderOffsetTextBox
                .Text = CStr(Sprite.SpriteHeaderOffset)
            End With
            With SpriteDetailsPaletteTextBox
                .Text = CStr(Sprite.SpritePalette)
            End With
            With SpriteDetailsPaletteHexDataTextBox
                .Text = SpritePalette.PaletteHexData
            End With
            With SpriteDetailsFrameSizeTextBox
                .Text = CStr(Sprite.SpriteFrameSize) + " Bytes"
            End With
            With SpriteDetailsFrameDataOffsetTextBox
                .Text = CStr(ToHex(ToDecimal(Sprite.SpriteFrameDataOffset) + (CurrentSpriteFrame - 1) * 8))
            End With
            With SpriteDetailsFrameCountTextBox
                .Text = CStr(If(Sprite.SpriteFrameCount > 0, CStr(Sprite.SpriteFrameCount), "N/A"))
            End With
            With SpriteDetailsArtDataOffsetTextBox
                .Text = CStr(ToHex(ToDecimal(Sprite.SpriteArtDataOffset) + (CurrentSpriteFrame - 1) * Sprite.SpriteFrameSize))
            End With
        Catch ex As Exception
            MessageBox.Show("An unexpected error has occurred!" + vbCrLf + vbCrLf + "Exception : " + ex.Message, "Error In GenerateSpriteDetails()", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Bugged...
    Public Sub SpritePictureBoxMouseClick(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            If SpriteCanvasMultiplier >= SpriteDrawGridStartMultiplier Then
                Dim SpritePictureBox As PictureBox = GetSpritePictureBox(SpriteCanvasInnerPanel)
                Dim X As Integer = e.X
                Dim Y As Integer = e.Y
                Dim PixelLocation As Point = New Point(X - X Mod SpriteCanvasMultiplier, Y - Y Mod SpriteCanvasMultiplier)
                Dim ProceedSpriteUpdate As Boolean = False
                    If (PixelLocation.X >= 0 And PixelLocation.Y >= 0) And _
                        (PixelLocation.X < SpritePictureBox.Width And PixelLocation.Y < SpritePictureBox.Height) Then
                        If IsNothing(PreviousPixelLocation) = False Then
                            If PixelLocation <> PreviousPixelLocation Then
                                ProceedSpriteUpdate = True
                            End If
                        Else
                            ProceedSpriteUpdate = True
                        End If
                    End If
                If ProceedSpriteUpdate = True Then
                    If MaintainBuffer = True Then
                        PushToBuffer(PixelLocation, SpriteImage.GetPixel(CInt(PixelLocation.X / SpriteCanvasMultiplier), CInt(PixelLocation.Y / SpriteCanvasMultiplier)),
                                     GetPixelIndex(SpriteImageData, Sprite.SpriteSize, New Point(CInt(PixelLocation.X / SpriteCanvasMultiplier),
                                                                                                 CInt(PixelLocation.Y / SpriteCanvasMultiplier))),
                                     SpriteCanvasMultiplier)
                    End If
                    UpdateSpriteData(SpriteImageData, Sprite.SpriteSize, New Point(CInt(PixelLocation.X / SpriteCanvasMultiplier), CInt(PixelLocation.Y / SpriteCanvasMultiplier)),
                                     PaletteConvertObject.SelectedPaletteIndex)
                    Using SpriteGraphics As Graphics = Graphics.FromImage(SpriteImage)
                        SpriteGraphics.FillRectangle(New SolidBrush(PaletteConvertObject.SelectedPaletteColor),
                                                     CInt(PixelLocation.X / SpriteCanvasMultiplier),
                                                     CInt(PixelLocation.Y / SpriteCanvasMultiplier),
                                                     1,
                                                     1)
                    End Using
                    Using SpriteGraphics As Graphics = Graphics.FromImage(SpritePictureBox.Image)
                        SpriteGraphics.FillRectangle(New SolidBrush(PaletteConvertObject.SelectedPaletteColor),
                                                     If(SpriteDrawGrid = True, PixelLocation.X + 1, PixelLocation.X),
                                                     If(SpriteDrawGrid = True, PixelLocation.Y + 1, PixelLocation.Y),
                                                     If(SpriteDrawGrid = True, If(PixelLocation.X = SpritePictureBox.Width - SpriteCanvasMultiplier, SpriteCanvasMultiplier - 2,
                                                                                  SpriteCanvasMultiplier - 1),
                                                        SpriteCanvasMultiplier),
                                                     If(SpriteDrawGrid = True, If(PixelLocation.Y = SpritePictureBox.Height - SpriteCanvasMultiplier, SpriteCanvasMultiplier - 2,
                                                                                  SpriteCanvasMultiplier - 1),
                                                        SpriteCanvasMultiplier))
                    End Using
                    PreviousPixelLocation = PixelLocation
                    SpritePictureBox.Invalidate()
                End If
            End If
        End If
    End Sub

    ' Bugged...
    Public Sub SpriteUndo(sender As Object, e As KeyEventArgs)
        If ((e.KeyCode = Keys.Z) AndAlso e.Control) Then
            If SpriteBufferCount > 0 Then
                Dim SpritePictureBox As PictureBox = GetSpritePictureBox(SpriteCanvasInnerPanel)
                Dim PixelLocation As Point = SpriteBufferVar(SpriteBufferCount - 1).PixelLocation
                Dim PixelIndex As Integer = SpriteBufferVar(SpriteBufferCount - 1).PixelIndex
                Dim CanvasMultiplier As Integer = SpriteBufferVar(SpriteBufferCount - 1).CanvasMultiplier
                UpdateSpriteData(SpriteImageData, Sprite.SpriteSize, New Point(CInt(PixelLocation.X / SpriteCanvasMultiplier), CInt(PixelLocation.Y / SpriteCanvasMultiplier)),
                                 PixelIndex)
                Using SpriteGraphics As Graphics = Graphics.FromImage(SpriteImage)
                    SpriteGraphics.FillRectangle(New SolidBrush(SpriteBufferVar(SpriteBufferCount - 1).PixelColor),
                                                 CInt(PixelLocation.X / CanvasMultiplier),
                                                 CInt(PixelLocation.Y / CanvasMultiplier),
                                                 1,
                                                 1)
                End Using
                Using SpriteGraphics As Graphics = Graphics.FromImage(SpritePictureBox.Image)
                    SpriteGraphics.FillRectangle(New SolidBrush(SpriteBufferVar(SpriteBufferCount - 1).PixelColor),
                                                 If((SpriteDrawGrid = True) And (SpriteCanvasMultiplier > SpriteDrawGridStartMultiplier),
                                                    CInt(PixelLocation.X / CanvasMultiplier) * SpriteCanvasMultiplier + 1,
                                                    CInt(PixelLocation.X / CanvasMultiplier) * SpriteCanvasMultiplier),
                                                 If((SpriteDrawGrid = True) And (SpriteCanvasMultiplier > SpriteDrawGridStartMultiplier),
                                                    CInt(PixelLocation.Y / CanvasMultiplier) * SpriteCanvasMultiplier + 1,
                                                    CInt(PixelLocation.Y / CanvasMultiplier) * SpriteCanvasMultiplier),
                                                 If((SpriteDrawGrid = True) And (SpriteCanvasMultiplier > SpriteDrawGridStartMultiplier),
                                                    If(PixelLocation.X = SpritePictureBox.Width - SpriteCanvasMultiplier, SpriteCanvasMultiplier - 2,
                                                                              SpriteCanvasMultiplier - 1),
                                                    SpriteCanvasMultiplier),
                                                 If((SpriteDrawGrid = True) And (SpriteCanvasMultiplier > SpriteDrawGridStartMultiplier),
                                                    If(PixelLocation.Y = SpritePictureBox.Height - SpriteCanvasMultiplier, SpriteCanvasMultiplier - 2,
                                                                              SpriteCanvasMultiplier - 1),
                                                    SpriteCanvasMultiplier))
                End Using
                PopFromBuffer()
                SpritePictureBox.Invalidate()
            End If
        End If
    End Sub

    Public Sub SpriteDetailsPaletteHexDataTextBoxTextChanged(sender As Object, e As EventArgs)
        Try
            If (SpriteDetailsPaletteHexDataTextBox.Text.Length = SpriteDetailsPaletteHexDataTextBox.MaxLength) And _
                (SpritePalette.PaletteHexData <> SpriteDetailsPaletteHexDataTextBox.Text) Then
                SpritePalette.PaletteHexData = SpriteDetailsPaletteHexDataTextBox.Text
                GenerateSpriteImage(SpriteImage, SpriteImageData, SpritePalette.PaletteHexData)
                ReDrawSprite()
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Sub SaveSprite(ByVal PerformUpdate As Boolean, Optional ByVal NoLog As Boolean = False)
        If String.Compare(SpriteImageData, SpriteOriginalImageData) = 0 Then
            MessageBox.Show("Sprite data change has not been detected. Please use palette editor and your mouse to draw on the current sprite to your liking.", "No Sprite Change Detected!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            If NoLog = False Then
                Log("Saving Sprite Data To Rom...", True, False, False)
                Log("   Prompting User To Save The Changes Made To Sprite...")
            End If
            Dim Result As Integer = MessageBox.Show("Do you want to proceed writing sprite data to you rom?", "Proceed To Writing?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If Result = DialogResult.Yes Then
                If NoLog = False Then
                    Log("   Proceeding With Writing Procedure...")
                    Log("Writing Sprite Data [" + CStr(Sprite.SpriteFrameSize) + " Bytes] To Rom At Offset => 0x" + GetSpriteFrameOffset(CurrentSpriteFrame))
                End If
                If WriteData(GetSpriteFrameOffset(CurrentSpriteFrame), Sprite.SpriteFrameSize, ProcessSpriteData(SpriteImageData)) Then
                    If NoLog = False Then
                        Log("   Done!")
                    End If
                    SpriteOriginalImage = SpriteImage.Clone()
                    SpriteOriginalImageData = SpriteImageData
                    If NoLog = False Then
                        Log("Sprite Data Has Been Successfully Saved!", False, True, True)
                    End If
                Else
                    If NoLog = False Then
                        Log("   Error! Writing Sprite Data To Rom Failed.")
                        Log("Aborting Due To Error!", False, True, False)
                    End If
                End If
            Else
                If NoLog = False Then
                    Log("Aborted By User!", False, True, False)
                End If
            End If
        End If
    End Sub

    Public Sub SavePalette(ByVal PerformUpdate As Boolean)
        If CheckSpritePaletteChange() = PaletteChange.No Then
            MessageBox.Show("Palette data change has not been detected. Please use palette editor to edit the current palette to your liking.", "No Palette Change Detected!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Dim PaletteHexDataToWrite As String = Nothing
            Log("Saving Palette Data To Rom...", True, False)
            If CheckSpritePaletteChange(False) = PaletteChange.YesNotApplied Then
                Log("Changes Made To Palette Not Applied...")
                Log("   Prompting User To Apply The Changes Made To Palette...")
                Dim ApplyChanges As Integer = MessageBox.Show("It looks like you haven't applied the changes made to the palette by you." & vbCrLf & vbCrLf & "Do you want to apply those changes and proceed to saving the palette to the rom?", "Palette Changes Not Applied!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)
                Select Case ApplyChanges
                    Case DialogResult.Yes
                        Log("Applying Changes Made To The Palette...")
                        SpriteDetailsPaletteHexDataTextBox.Text = PaletteConvertObject.TempPaletteData
                        Log("   Done!")
                    Case DialogResult.No
                        Log("Discarding Changes Made To Palette...")
                        If String.Compare(SpriteOriginalPalette.PaletteHexData, SpritePalette.PaletteHexData) <> 0 Then
                            Log("Using Previously Applied Changes To Palette...")
                        Else
                            Log("No Changes Were Made To Palette Previously...")
                            Log("Aborting Palette Save Process...", False, True, False)
                            Return
                        End If
                    Case DialogResult.Cancel
                        Log("Aborting Palette Save Process...", False, True, False)
                        Return
                End Select
            End If
            PaletteHexDataToWrite = SpritePalette.PaletteHexData
            Dim Result As Integer = MessageBox.Show("Do you want to proceed writing palette data to you rom?", "Proceed To Writing?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If Result = DialogResult.Yes Then
                Log("   Proceeding With Writing Procedure...")
                Log("Writing Palette Data [32 Bytes] To Rom At Offset => 0x" + SpritePalette.PaletteDataOffset)
                If WriteData(SpritePalette.PaletteDataOffset, 32, PaletteHexDataToWrite) Then
                    Log("   Done!")
                    SpriteOriginalPalette = SpritePalette
                    Log("Palette Data Has Been Successfully Saved!", False, True, True)
                Else
                    Log("   Error! Writing Palette Data To Rom Failed.")
                    Log("Aborting Due To Error!", False, True, False)
                End If
            Else
                Log("Aborted By User!", False, True, False)
            End If
        End If
    End Sub

    Public Sub SaveAll(ByVal PerformUpdate As Boolean)
        SavePalette(False)
        SaveSprite(True)
    End Sub

    Public Sub Update(ByVal UpdateType As UpdateSpriteEditor)
        Select Case UpdateType
            Case UpdateSpriteEditor.All
                ReDrawSprite()
                PaletteConvertObject.GeneratePaletteBoxCompact()
                GenerateSpriteFrameBrowser()
                GenerateSpriteDetails()
            Case UpdateSpriteEditor.Canvas
                ReDrawSprite()
            Case UpdateSpriteEditor.Palette
                PaletteConvertObject.GeneratePaletteBoxCompact()
            Case UpdateSpriteEditor.Browser
                GenerateSpriteFrameBrowser()
            Case UpdateSpriteEditor.Details
                GenerateSpriteDetails()
        End Select
    End Sub

    Public Sub SpriteExport()
        If Export.ShowDialog() = DialogResult.Yes Then
            Dim SpriteExportFileDialog As FileDialog = New SaveFileDialog
            SpriteExportFileDialog.FileName = "Sprite - [" + CStr(Sprite.SpriteIndex) + "-" + CStr(CurrentSpriteFrame) + "].bmp"
            SpriteExportFileDialog.Filter = "BMP Files (*.bmp*)|*.bmp"
            SpriteExportFileDialog.Title = "Export Sprite Bitmap"
            If SpriteExportFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                ExportBitmap(SpriteImageData, SpritePalette.PaletteHexData, Sprite.SpriteSize, SpriteExportFileDialog.FileName)
            End If
        Else
            Dim SpriteExportAllFolderDialog As FolderBrowserDialog = New FolderBrowserDialog
            SpriteExportAllFolderDialog.SelectedPath = "E:\My Website\htdocs\Pokemon World\resources\drawable\Sprites\People"
            If SpriteExportAllFolderDialog.ShowDialog() = DialogResult.OK Then
                For i As Integer = 0 To Sprite.SpriteFrameCount - 1
                    ExportBitmap(GetSpriteData(i + 1), SpritePalette.PaletteHexData, Sprite.SpriteSize, SpriteExportAllFolderDialog.SelectedPath + "/" + CStr(i) + ".bmp")
                    Dim ExportedBitmap As Bitmap = New Bitmap(SpriteExportAllFolderDialog.SelectedPath + "/" + CStr(i) + ".bmp")
                    Dim ExportingBitmap As Bitmap = New Bitmap(ExportedBitmap.Width, ExportedBitmap.Height)
                    Dim ExportedBitmapGraphics As Graphics = Graphics.FromImage(ExportingBitmap)
                    ExportedBitmapGraphics.DrawImage(ExportedBitmap, 0, 0)
                    Dim ExportedBitmapTransparentColor As Color = ExportedBitmap.GetPixel(0, 0)
                    ExportedBitmap.MakeTransparent(ExportedBitmapTransparentColor)
                    ExportedBitmap.Save(SpriteExportAllFolderDialog.SelectedPath + "/" + CStr(i) + ".png", Drawing.Imaging.ImageFormat.Png)
                    My.Computer.FileSystem.DeleteFile(SpriteExportAllFolderDialog.SelectedPath + "/" + CStr(i) + ".bmp")
                    ExportedBitmap.Dispose()
                    ExportedBitmapGraphics.Dispose()
                    ExportingBitmap.Dispose()
                Next
                Process.Start(SpriteExportAllFolderDialog.SelectedPath)
            End If
        End If
    End Sub

    Public Sub SpriteImport()
        If ImportSprite.ShowDialog() = DialogResult.OK Then
            Select Case ImportSprite.SpriteImportType
                Case ImportType.OnlySprite
                    If ImportSprite.SpriteSize = Sprite.SpriteSize Then
                        SpriteImageData = ImportSprite.SpriteData
                        GenerateSpriteImage(SpriteImage, SpriteImageData, SpritePalette.PaletteHexData)
                        Update(UpdateSpriteEditor.Canvas)
                    Else
                        MessageBox.Show("The sprite you have imported is not of correct size. The sprite size required is " + CStr(Sprite.SpriteSize.Width) + " x " + CStr(Sprite.SpriteSize.Height) + ".",
                                        "Sprite Size Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Case ImportType.OnlyPalette
                    SpriteDetailsPaletteHexDataTextBox.Text = ImportSprite.PaletteData
                    Update(UpdateSpriteEditor.Palette)
                Case ImportType.BothSpriteAndPalette
                    If ImportSprite.SpriteSize = Sprite.SpriteSize Then
                        SpriteImageData = ImportSprite.SpriteData
                    Else
                        MessageBox.Show("The sprite you have imported is not of correct size. The sprite size required is " + CStr(Sprite.SpriteSize.Width) + " x " + CStr(Sprite.SpriteSize.Height) + ".",
                                        "Sprite Size Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                    SpriteDetailsPaletteHexDataTextBox.Text = ImportSprite.PaletteData
                    Update(UpdateSpriteEditor.Palette)
            End Select
        End If
    End Sub

    Public Sub Delete()
        RemoveHandler MainForm.MouseWheel, AddressOf ScrollCanvas
        RemoveHandler MainForm.KeyDown, AddressOf TranslateCanvas
        RemoveHandler MainForm.KeyDown, AddressOf SpriteCanvaseScrollIncreaseKeyDown
        RemoveHandler MainForm.KeyUp, AddressOf SpriteCanvaseScrollIncreaseKeyUp
        RemoveHandler MainForm.KeyPress, AddressOf SpriteCanvaseScrollIncreaseKeyPress
        If MaintainBuffer = True Then
            RemoveHandler MainForm.KeyDown, AddressOf SpriteUndo
        End If
        SpriteEditorGroupBox.Dispose()
        SpritePalette = Nothing
        SpriteOriginalPalette = Nothing
        Sprite = Nothing
        SpriteOriginal = Nothing
        SpriteCanvasMultiplier = Nothing
        SpriteDrawGridStartMultiplier = Nothing
        SpriteCanvasScrollIncrease = Nothing
        SpriteDrawGrid = Nothing
        SpriteImage = Nothing
        SpriteOriginalImage = Nothing
        SpriteImageData = Nothing
        SpriteOriginalImageData = Nothing
        CurrentSpriteFrame = Nothing
        PreviousPixelLocation = Nothing
        MainForm = Nothing
        SpriteEditorControl = Nothing
        SpriteEditorGroupBox = Nothing
        LogPanel = Nothing
        SpriteCanvasPanel = Nothing
        SpriteCanvasInnerPanel = Nothing
        SpriteCanvasPixel = Nothing
        SpriteCanvasVScroll = Nothing
        SpriteCanvasHScroll = Nothing
        SpriteCanvasScrollSeparator = Nothing
        SpriteCanvasVScrollBorder = Nothing
        SpriteCanvasHScrollBorder = Nothing
        SpriteMagnifyTrackBar = Nothing
        SpriteCurrentMagnification = Nothing
        SpriteCurrentSize = Nothing
        SpriteCanvas = Nothing
        SpriteBrowser = Nothing
        SpriteFrameBrowserTab = Nothing
        SpriteDetailsTab = Nothing
        SpriteDetailsIndexLabel = Nothing
        SpriteDetailsTableOffsetLabel = Nothing
        SpriteDetailsHeaderOffsetLabel = Nothing
        SpriteDetailsPaletteLabel = Nothing
        SpriteDetailsPaletteHexDataLabel = Nothing
        SpriteDetailsFrameSizeLabel = Nothing
        SpriteDetailsFrameDataOffsetLabel = Nothing
        SpriteDetailsFrameCountLabel = Nothing
        SpriteDetailsArtDataOffset = Nothing
        SpriteDetailsIndexTextBox = Nothing
        SpriteDetailsTableOffsetTextBox = Nothing
        SpriteDetailsHeaderOffsetTextBox = Nothing
        SpriteDetailsPaletteTextBox = Nothing
        SpriteDetailsPaletteHexDataTextBox = Nothing
        SpriteDetailsFrameSizeTextBox = Nothing
        SpriteDetailsFrameDataOffsetTextBox = Nothing
        SpriteDetailsFrameCountTextBox = Nothing
        SpriteDetailsArtDataOffsetTextBox = Nothing
        SpriteDetailsPresetButton = Nothing
        SpriteFrameBrowserFlowLayoutPanel = Nothing
        SpriteFrameBrowserNextButton = Nothing
        SpriteFrameBrowserPreviousButton = Nothing
        SpriteDrawGridCheckBox = Nothing
        SpriteExportButton = Nothing
        SpriteImportButton = Nothing
        SpritePaletteGroupBox = Nothing
        SaveSpriteButton = Nothing
        SavePaletteButton = Nothing
        SaveAllButton = Nothing
        PaletteConvertObject = Nothing
    End Sub

End Class
