Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices

Public Class Sprite

    Public PaletteConvertObject As New PaletteConvert
    Public Sprite As New SpriteData
    Public SpriteCanvasMultiplier As Integer = 1

    Public SpriteEditorControl As Control


    'Public Sub New(ByVal DefaultSprite As SpriteData, ByVal DefaultControl As Control)
    '    If IsNothing(DefaultSprite) = False Then
    '        Sprite = DefaultSprite
    '    End If
    '    If IsNothing(DefaultControl) = False Then
    '        SpriteEditorControl = DefaultControl
    '    End If
    'End Sub

    Public Function CheckNull() As Boolean
        If IsNothing(Sprite) = True Then
            Return True
        End If
        If IsNothing(SpriteEditorControl) = True Then
            Return True
        End If
        Return False
    End Function

    Public Function GetSpriteData(ByVal SpriteNumber As Integer) As String
        Return ReadData(Sprite.SpriteArtDataOffset, Sprite.SpriteFrameSize * (SpriteNumber - 1))
    End Function

    Public Function ProcessSpriteData(ByVal SpriteData As String) As String
        Dim SpriteDataArray() As String = SplitString(SpriteData, 2)
        For i As Integer = 0 To SpriteDataArray.Length - 1
            SpriteDataArray(i) = SpriteDataArray(i)(1) + SpriteDataArray(i)(0)
        Next
        Return RejoinString(SpriteDataArray)
    End Function

    Public Sub DrawSprite(ByVal SpriteData As String, ByVal SpritePaletteData As String, ByVal SpriteSize As Size, ByVal SpriteControl As Control,
                              ByVal Multiplier As Integer, ByVal GridColor As Color, Optional ByVal DrawGrid As Boolean = False,
                              Optional ByVal GridStartMultiplier As Integer = 5)
        For Each Control In SpriteControl.Controls
            Dim PictureBoxElement As PictureBox = DirectCast(Control, PictureBox)
            If IsNothing(PictureBoxElement) = False Then
                If PictureBoxElement.Name = "Sprite" Then
                    PictureBoxElement.Dispose()
                End If
            End If
        Next
        Dim SpritePaletteDataArray() As String = SplitString(SpritePaletteData, 4)
        SpriteData = ProcessSpriteData(SpriteData)
        Dim SpriteCompleteBitmap As Bitmap = New Bitmap(SpriteSize.Width, SpriteSize.Height, PixelFormat.Format32bppRgb)
        Dim SpriteGraphics As Graphics = Graphics.FromImage(SpriteCompleteBitmap)
        SpriteGraphics.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor
        Dim NumberOfBlocks As Integer = SpriteSize.Width * SpriteSize.Height / 64
        Dim BlockSize As New Size(8, 8)
        Dim SpriteDataCount As Integer = 0
        Dim BlockColCount As Integer = SpriteSize.Width / BlockSize.Width
        Dim BlockRowCount As Integer = SpriteSize.Height / BlockSize.Height
        Dim SpriteBitmap(NumberOfBlocks) As Bitmap
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
                            SpriteRGBValues(i + 2) = PaletteConvertObject.ReturnByte(SpritePaletteDataArray(ToDecimal(SpriteData(SpriteDataCount))),
                                                                                     PaletteConvert.ByteOf.Red)
                            SpriteRGBValues(i + 1) = PaletteConvertObject.ReturnByte(SpritePaletteDataArray(ToDecimal(SpriteData(SpriteDataCount))),
                                                                                     PaletteConvert.ByteOf.Green)
                            SpriteRGBValues(i + 0) = PaletteConvertObject.ReturnByte(SpritePaletteDataArray(ToDecimal(SpriteData(SpriteDataCount))),
                                                                                     PaletteConvert.ByteOf.Blue)
                            SpriteDataCount = SpriteDataCount + 1
                        Else
                            Exit For
                        End If
                    Catch ex As Exception
                        MsgBox(ex.Message, , "Error!")
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
        MultipliedGraphics.DrawImage(SpriteCompleteBitmap, 0, 0, SpriteSize.Width * Multiplier, SpriteSize.Height * Multiplier)
        MultipliedGraphics.Dispose()
        If (DrawGrid = True) And (Multiplier > GridStartMultiplier) Then
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

    End Sub

End Class
