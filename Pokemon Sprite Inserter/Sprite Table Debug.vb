Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Text

Public Class Sprite_Table_Debug

    Public PaletteConvertObject As New PaletteConvert
    Public PaletteDataArray() As PaletteData = GetPalettes(Main.PaletteTableOffset, Main.PaletteTableEndHex, Main.MaxPalette)
    Public PatchFile As String = "C:\Users\Divya Mamgai\Desktop\Pokemon Sprite Inserter Test Unit\Patch.txt"
    Public CurrentPaletteIndex As Integer = 8

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
        AddHandler SpritePictureBox.MouseClick, AddressOf PanelSelect
        AddHandler SpritePictureBox.MouseDoubleClick, AddressOf PanelDeselect
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

    Private Sub LoadData()
        PatchFile = TextBox3.Text
        If CInt(TextBox4.Text) < PaletteDataArray.Length Then
            CurrentPaletteIndex = CInt(TextBox4.Text)
        End If
        TextBox5.Text = "0"
        FlowLayoutPanel1.Controls.Clear()
        Dim SpriteFrameDataStartOffset As String = "3A00A0"
        Dim Max As Integer = CInt(TextBox2.Text)
        Dim SpriteCount As Integer = If(CInt(TextBox1.Text) > 0, CInt(TextBox1.Text) - 1, 0)
        Dim TempCount As Integer = 1
        Dim CompleteMaxCount As Integer = 1302
        Dim EndFlag As Boolean = False
        Dim CurrentData As String = ""
        Dim CurrentSpriteOffset As String = ""
        Dim CurrentSpriteFrameSize As Integer = 0
        Dim CurrentSpriteSize As Size
        Dim CurrentSpriteData As String = ""
        Dim CurrentDone As String = ""
        Dim CurrentDoneFlag As Boolean = False
        Dim CurrentDoneCount As Integer = 0
        While EndFlag = False
            CurrentData = ReadData(ToHex(ToDecimal(SpriteFrameDataStartOffset) + 8 * SpriteCount), 8)
            CurrentSpriteOffset = PointerToOffset(CurrentData.Substring(0, 8))
            CurrentSpriteFrameSize = ToDecimal(SplitString(CurrentData.Substring(8, 4), 2)(1) + SplitString(CurrentData.Substring(8, 4), 2)(0))
            CurrentDone = CurrentData.Substring(12, 2)
            If (CurrentDoneFlag = True) And (CurrentDoneCount > 0) Then
                CurrentDoneCount = CurrentDoneCount - 1
            Else
                If String.Compare(CurrentDone, "00") = 0 Then
                    CurrentDoneFlag = False
                Else
                    CurrentDoneFlag = True
                    CurrentDoneCount = ToDecimal(CurrentDone) - 1
                End If
            End If
            Select Case CurrentSpriteFrameSize
                Case 128
                    CurrentSpriteSize = New Size(16, 16)
                Case 256
                    CurrentSpriteSize = New Size(16, 32)
                Case 512
                    CurrentSpriteSize = New Size(32, 32)
                Case 2048
                    CurrentSpriteSize = New Size(64, 64)
                Case 4096
                    CurrentSpriteSize = New Size(128, 64)
                Case Else
                    CurrentSpriteSize = New Size(32, 32)
            End Select
            CurrentSpriteData = ReadData(CurrentSpriteOffset, CurrentSpriteFrameSize)
            Dim SpritePanel As New Panel
            Dim SpriteNumberTextBox As New TextBox
            Dim SpriteNumber As New Label
            With SpritePanel
                .Width = CurrentSpriteSize.Width * 3
                .Height = CurrentSpriteSize.Height * 3 + 50
                .BorderStyle = BorderStyle.FixedSingle
                .AutoScroll = False
                .BackColor = If(CurrentDoneFlag = True, Color.GreenYellow, Color.LightPink)
                .Tag = If(CurrentDoneFlag = True, Color.GreenYellow, Color.LightPink)
            End With
            With SpriteNumberTextBox
                .Width = CurrentSpriteSize.Width * 3 - 2
                .Tag = ToHex(ToDecimal(SpriteFrameDataStartOffset) + 8 * SpriteCount, 6) + CurrentData
                .Location = New Point(0, SpritePanel.Height - 25)
            End With
            AddHandler SpriteNumberTextBox.KeyPress, AddressOf PatchSprite
            AddHandler SpriteNumberTextBox.KeyPress, AddressOf DigitValidator
            AddHandler SpriteNumberTextBox.KeyPress, AddressOf MaxLimitValidator
            With SpriteNumber
                .Text = If(CurrentDoneFlag = True, CStr(SpriteCount + 1) & vbCrLf & "C : " + CStr(CurrentDoneCount + 1), CStr(SpriteCount + 1))
                .Font = New Font("Calibri", 8, FontStyle.Bold)
            End With
            FlowLayoutPanel1.Controls.Add(SpritePanel)
            DrawSprite(CurrentSpriteData, PaletteDataArray(CurrentPaletteIndex).PaletteHexData, CurrentSpriteSize, SpritePanel, 3, Color.Black)
            SpritePanel.Controls.Add(SpriteNumberTextBox)
            SpritePanel.Controls.Add(SpriteNumber)
            SpriteNumber.BringToFront()
            SpriteNumberTextBox.BringToFront()
            SpriteCount = SpriteCount + 1
            TempCount = TempCount + 1
            If (TempCount > Max) Or (SpriteCount - 1 > CompleteMaxCount) Then
                EndFlag = True
                Exit While
            End If
        End While
        FlowLayoutPanel1.Select()
    End Sub

    Public Sub PatchSprite(sender As Object, e As KeyPressEventArgs)
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 13) Then
            Dim TextElement As TextBox = DirectCast(sender, TextBox)
            If TextElement.Text <> "" Then
                If CInt(TextElement.Text < 30) Then
                    Dim CurrentData As String = TextElement.Tag
                    Dim CurrentSpriteDataOffset As String = CurrentData.Substring(0, 6)
                    Dim CurrentSpriteData As String = CurrentData.Substring(6, 16)
                    Dim Result As Integer = MessageBox.Show("Do you want to patch this sprite?" & vbCrLf & vbCrLf & "Sprite Data Offset : " + CurrentSpriteDataOffset & vbCrLf & vbCrLf & "Sprite Data : " + CurrentSpriteData,
                                                            "Patch Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If Result = DialogResult.Yes Then
                        CurrentSpriteData = CurrentSpriteData.Substring(0, 12)
                        CurrentSpriteData += ToHex(TextElement.Text, 2)
                        CurrentSpriteData += "00"
                        Dim OtherResult As Integer = MessageBox.Show("Verfiy Data : " & vbCrLf & vbCrLf & "Sprite Data Offset : " + CurrentSpriteDataOffset & vbCrLf & vbCrLf & "Sprite Data : " + CurrentSpriteData, "Verfiy",
                                                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        If OtherResult = DialogResult.Yes Then
                            If WriteData(CurrentSpriteDataOffset, 8, CurrentSpriteData) = True Then
                                Dim PatchFileStream As FileStream = Nothing
                                Try
                                    PatchFileStream = File.Open(PatchFile, FileMode.Append, FileAccess.Write)
                                    Dim WriteData() As Byte = Encoding.ASCII.GetBytes("[" + CurrentSpriteDataOffset + "|" + CurrentSpriteData + "]" & vbCrLf)
                                    PatchFileStream.Write(WriteData, 0, WriteData.Length)
                                    PatchFileStream.Close()
                                    MsgBox("Done! Sprite Patched Successfully.", , "Done!")
                                Catch ex As Exception
                                    MsgBox(ex.Message, , "Error Occurred!")
                                End Try
                                LoadData()
                            Else
                                MsgBox("Error occurred while writing!", , "Error!")
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Public Sub PanelSelect(sender As Object, e As EventArgs)
        Dim SelectPanel As PictureBox = DirectCast(sender, PictureBox)
        If SelectPanel.Parent().BackColor <> Color.LightSteelBlue Then
            SelectPanel.Parent().BackColor = Color.LightSteelBlue
            TextBox5.Text = CStr(CInt(TextBox5.Text) + 1)
        End If
    End Sub

    Public Sub PanelDeselect(sender As Object, e As EventArgs)
        Dim SelectPanel As PictureBox = DirectCast(sender, PictureBox)
        If SelectPanel.Parent().BackColor = Color.LightSteelBlue Then
            SelectPanel.Parent().BackColor = SelectPanel.Parent().Tag
            If CInt(TextBox5.Text) > 0 Then
                TextBox5.Text = CStr(CInt(TextBox5.Text) - 1)
            End If
        End If
    End Sub

    Private Sub Load_Click(sender As Object, e As EventArgs) Handles Load.Click
        LoadData()
    End Sub

    Private Sub Sprite_Table_Debug_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler TextBox1.KeyPress, AddressOf DigitValidator
        AddHandler TextBox1.KeyPress, AddressOf NonZeroValidator
        AddHandler TextBox2.KeyPress, AddressOf DigitValidator
        AddHandler TextBox3.KeyPress, AddressOf DigitValidator
        AddHandler TextBox3.KeyPress, AddressOf MaxLimitValidator
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim AllPanels = FlowLayoutPanel1.Controls.OfType(Of Panel)()
        For Each PanelElement In AllPanels
            PanelElement.BackColor = PanelElement.Tag
        Next
        TextBox5.Text = "0"
    End Sub
End Class