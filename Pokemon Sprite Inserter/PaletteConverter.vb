Imports System.Text

Public Class PaletteConvert

    Public TempPaletteData As String = ""
    Public PaletteEditorGroupBox As GroupBox = Nothing
    Public PaletteNumberTextBox As TextBox = Nothing
    Public PaletteHexDataTextBox As TextBox = Nothing
    Public PaletteContainerFlowPanel As FlowLayoutPanel
    Public PaletteEditing As Boolean = True
    Public PaletteLabelColor As Color = Color.White
    Public SelectedPaletteColor As Color = Nothing
    Public SelectedPaletteIndex As Integer = Nothing
    Public ResetPaletteData As String = ""

    Public Enum PaletteConvertType
        Full
        Compact
    End Enum

    Public Enum ByteOf
        Red
        Blue
        Green
    End Enum

    Public CurrentPaletteConvertType As PaletteConvertType

    Public Sub New()
        ' To Create Empty Object.
    End Sub

    Public Sub New(ByVal DefaultPaletteConvertType As PaletteConvertType,
                   Optional ByVal DefaultGroupBox As GroupBox = Nothing,
                   Optional ByVal DefaultNumberTextBox As TextBox = Nothing,
                   Optional ByVal DefaultHexTextBox As TextBox = Nothing,
                   Optional ByVal DefaultPaletteLabelColor As Color = Nothing)
        CurrentPaletteConvertType = DefaultPaletteConvertType
        If IsNothing(DefaultGroupBox) = False Then
            PaletteEditorGroupBox = DefaultGroupBox
        End If
        If IsNothing(DefaultNumberTextBox) = False Then
            PaletteNumberTextBox = DefaultNumberTextBox
        End If
        If IsNothing(DefaultHexTextBox) = False Then
            PaletteHexDataTextBox = DefaultHexTextBox
            If DefaultPaletteConvertType = PaletteConvertType.Full Then
                AddHandler PaletteHexDataTextBox.TextChanged, AddressOf PaletteHexDataTextBoxTextChanged
            End If
        End If
        If DefaultPaletteConvertType = PaletteConvertType.Full Then
            If IsNothing(DefaultPaletteLabelColor) = False Then
                PaletteLabelColor = DefaultPaletteLabelColor
            End If
        End If
    End Sub

    Public Function CheckNull() As Boolean
        If IsNothing(PaletteEditorGroupBox) = True Then
            Return True
        End If
        If IsNothing(PaletteNumberTextBox) = True Then
            Return True
        End If
        If IsNothing(PaletteHexDataTextBox) = True Then
            Return True
        End If
        Return False
    End Function

#Region "Main Functions"

    Public Function ConvertDecimalToBinary(ByVal Number As Long, ByVal Length As Integer) As String
        Dim Result As String = ""
        Dim LeadingZero As New StringBuilder()
        Result = Convert.ToString(Number, 2)
        If Result.Length >= Length Then
            Return Result
        Else
            For i As Integer = 1 To Length - Result.Length
                LeadingZero.Append("0")
            Next
            LeadingZero.Append(Result)
            Return LeadingZero.ToString
        End If
    End Function

    Public Function ConvertBinaryToDecimal(ByVal Binary As String) As Integer
        Dim ResultDecimal As Integer = 0
        For i As Integer = 0 To Binary.Length - 1
            If Binary(i) = "1" Then
                ResultDecimal += Math.Pow(2, (Binary.Length - i - 1))
            End If
        Next
        Return ResultDecimal
    End Function

    Public Function ConvertColorHex(ByVal Color16 As String) As String
        Color16 = Right(Color16, 2) + Left(Color16, 2)
        Dim Result As New StringBuilder()
        Dim Red As String = Right(ConvertDecimalToBinary(ToDecimal(Color16), 15), 5)
        Dim Green As String = Left(Right(ConvertDecimalToBinary(ToDecimal(Color16), 15), 10), 5)
        Dim Blue As String = Left(ConvertDecimalToBinary(ToDecimal(Color16), 15), 5)
        Result.Append(ToHex(Math.Round(ConvertBinaryToDecimal(Red) * 255 / 31), 2))
        Result.Append(ToHex(Math.Round(ConvertBinaryToDecimal(Green) * 255 / 31), 2))
        Result.Append(ToHex(Math.Round(ConvertBinaryToDecimal(Blue) * 255 / 31), 2))
        Return Result.ToString
    End Function

    Public Function ConvertColor16(ByVal ColorHex As String) As String
        Dim Result As String = ""
        Dim Red As String = ConvertDecimalToBinary(Math.Round(ToDecimal(Left(ColorHex, 2)) * 31 / 255), 5)
        Dim Green As String = ConvertDecimalToBinary(Math.Round(ToDecimal(Right(Left(ColorHex, 4), 2)) * 31 / 255), 5)
        Dim Blue As String = ConvertDecimalToBinary(Math.Round(ToDecimal(Right(ColorHex, 2)) * 31 / 255), 5)
        Result = ToHex(ConvertBinaryToDecimal(Blue + Green + Red), 4)
        Result = Right(Result, 2) + Left(Result, 2)
        Return Result
    End Function

    Public Function ReturnColor(ByVal ColorValue As String, Optional ByVal Is16 As Boolean = True) As Color
        Return ColorTranslator.FromHtml(If(Is16 = True, "#" & ConvertColorHex(ColorValue), "#" & ColorValue))
    End Function

    Public Function ReturnByte(ByVal ColorValue As String, ByVal ReturnByteOf As Integer, Optional ByVal Is16 As Boolean = True) As Byte
        Dim TempColor As Color = ColorTranslator.FromHtml(If(Is16 = True, "#" & ConvertColorHex(ColorValue), "#" & ColorValue))
        Select Case ReturnByteOf
            Case ByteOf.Red
                Return Convert.ToByte(TempColor.R, 10)
            Case ByteOf.Blue
                Return Convert.ToByte(TempColor.B, 10)
            Case ByteOf.Green
                Return Convert.ToByte(TempColor.G, 10)
            Case Else
                Return Nothing
        End Select
        Return Nothing
    End Function

    Public Function ReturnColor16(ByVal ColorValue As Color) As String
        Return ConvertColor16(ToHex(ColorValue.R, 2) + ToHex(ColorValue.G, 2) + ToHex(ColorValue.B, 2))
    End Function

    Public Function GetColorOfIndex(ByVal PaletteData As String, ByVal Index As Integer) As Color
        If PaletteData.Length = 64 Then
            Return ReturnColor(SplitString(PaletteData, 4)(Index), True)
        Else
            Return Nothing
        End If
    End Function

#End Region

#Region "Palette Editor"

    Public Sub UpdateTempPaletteData(sender As Object, ByVal e As EventArgs)
        If Not IsNothing(PaletteEditorGroupBox) = True Then
            Dim TempPaletteDataBuilder As New StringBuilder()
            For i As Integer = 0 To 15
                TempPaletteDataBuilder.Append(GetPaletteTextBox(i).Text)
            Next
            TempPaletteData = TempPaletteDataBuilder.ToString
        End If
    End Sub

    Public Function GetPaletteBox(ByVal Index As Integer) As PaletteBox
        If CheckNull() = False Then
            Dim PaletteBoxContorls = Nothing
            If (CurrentPaletteConvertType = PaletteConvertType.Full) Then
                PaletteBoxContorls = PaletteEditorGroupBox.Controls.OfType(Of PaletteBox)()
            End If
            If (CurrentPaletteConvertType = PaletteConvertType.Compact) Then
                PaletteBoxContorls = PaletteContainerFlowPanel.Controls.OfType(Of PaletteBox)()
            End If
            For Each PaletteBoxControl In PaletteBoxContorls
                If CInt(PaletteBoxControl.Tag) = Index Then
                    Return PaletteBoxControl
                End If
            Next
            Return Nothing
        Else
            Return Nothing
        End If
    End Function

    Public Function GetPaletteTextBox(ByVal Index As Integer) As TextBox
        If CheckNull() = False Then
            Dim PaletteTextBoxContorls = PaletteEditorGroupBox.Controls.OfType(Of TextBox)()
            For Each PaletteTextBoxContorl In PaletteTextBoxContorls
                If CInt(PaletteTextBoxContorl.Tag) = Index Then
                    Return PaletteTextBoxContorl
                End If
            Next
            Return Nothing
        Else
            Return Nothing
        End If
    End Function

    Public Function GetColor16Code(ByVal Index As Integer) As String
        If CheckNull() = False Then
            Dim Result = ""
            If Index < PaletteHexDataTextBox.MaxLength / 4 Then
                Result = PaletteHexDataTextBox.Text.Substring(Index * 4, 4)
            End If
            Return Result
        Else
            Return ""
        End If
    End Function

    Public Sub SetPaletteBox(sender As Object, ByVal e As EventArgs)
        If CheckNull() = False Then
            Dim TextBoxElement As TextBox = DirectCast(sender, TextBox)
            If TextBoxElement.Text <> "" Then
                If IsNothing(GetPaletteBox(CInt(TextBoxElement.Tag))) = False Then
                    GetPaletteBox(CInt(TextBoxElement.Tag)).BackColor = ReturnColor(TextBoxElement.Text, True)
                End If
            End If
        End If
    End Sub

    Public Sub PaletteHexDataTextBoxTextChanged(sender As Object, e As EventArgs)
        Try
            If PaletteHexDataTextBox.Text.Length = PaletteHexDataTextBox.MaxLength Then
                GeneratePaletteBox()
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Sub PaletteNullValidator(sender As Object, ByVal e As EventArgs)
        If CheckNull() = False Then
            Dim TextBoxElement As TextBox = DirectCast(sender, TextBox)
            If TextBoxElement.Text = "" Then
                If IsNothing(GetPaletteBox(CInt(TextBoxElement.Tag))) = False Then
                    TextBoxElement.Text = GetColor16Code(CInt(TextBoxElement.Tag))
                    GetPaletteBox(CInt(TextBoxElement.Tag)).BackColor = ReturnColor(TextBoxElement.Text, True)
                End If
            End If
        End If
    End Sub

    Public Sub SetPaletteColor(sender As Object, ByVal e As EventArgs)
        If (CheckNull() = False) And (PaletteEditing = True) Then
            Dim PictureBoxElement As PaletteBox = DirectCast(sender, PaletteBox)
            Dim PaletteColorDialog As New ColorDialog
            With PaletteColorDialog
                .FullOpen = True
                .AnyColor = True
            End With
            PaletteColorDialog.Color = PictureBoxElement.BackColor
            If PaletteColorDialog.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
                PictureBoxElement.BackColor = PaletteColorDialog.Color
                GetPaletteTextBox(CInt(PictureBoxElement.Tag)).Text = ConvertColor16(ToHex(PaletteColorDialog.Color.R, 2) + ToHex(PaletteColorDialog.Color.G, 2) + ToHex(PaletteColorDialog.Color.B, 2))
                UpdateTempPaletteData(sender, e)
            End If
        End If
    End Sub

    Public Sub GeneratePaletteBox()
        If (CheckNull() = False) And (PaletteHexDataTextBox.Text.Length = 64) And (CurrentPaletteConvertType = PaletteConvertType.Full) Then
            TempPaletteData = PaletteHexDataTextBox.Text
            PaletteEditorGroupBox.Controls.Clear()
            Dim PaletteData As String = PaletteHexDataTextBox.Text
            Dim CountRow As Integer = 0
            Dim CountCol As Integer = 0
            For Count As Integer = 0 To 15
                If Count = 8 Then
                    CountRow = CountRow + 1
                    CountCol = 0
                ElseIf Count <> 0 Then
                    CountCol = CountCol + 1
                End If
                Dim TextBoxElement As New TextBox
                Dim PictureBoxElement As New PaletteBox
                With TextBoxElement
                    .Text = PaletteData.Substring(Count * 4, 4)
                    .Location = New Point(6 + CountCol * 66, 31 + CountRow * 52)
                    .Width = 60
                    .BorderStyle = BorderStyle.None
                    .Font = New Font("Calibri", 9, FontStyle.Bold)
                    .MaxLength = 4
                    .BackColor = PaletteLabelColor
                    .CharacterCasing = CharacterCasing.Upper
                    .TextAlign = HorizontalAlignment.Center
                    .Tag = Count
                End With
                With PictureBoxElement
                    .BackColor = ReturnColor(PaletteData.Substring(Count * 4, 4))
                    .Location = New Point(6 + CountCol * 66, 46 + CountRow * 52)
                    .Width = 60
                    .Height = 23
                    .Cursor = If(PaletteEditing = True, Cursors.Hand, Cursors.Arrow)
                    .Tag = Count
                    .BringToFront()
                End With
                AddHandler TextBoxElement.TextChanged, AddressOf SetPaletteBox
                AddHandler TextBoxElement.KeyPress, AddressOf HexInputValidator
                AddHandler TextBoxElement.Leave, AddressOf PaletteNullValidator
                AddHandler TextBoxElement.Leave, AddressOf UpdateTempPaletteData
                PaletteEditorGroupBox.Controls.Add(TextBoxElement)
                AddHandler PictureBoxElement.Click, AddressOf SetPaletteColor
                PaletteEditorGroupBox.Controls.Add(PictureBoxElement)
            Next
            Dim ApplyButton As New Button
            Dim ResetButton As New Button
            Dim ImportButton As New Button
            Dim ExportButton As New Button
            Dim DisplayIndexCheckBox As New CheckBox
            With ApplyButton
                .Text = "Apply"
                .Width = 85
                .Height = 26
                .Location = New Point(443, 140)
                .Enabled = PaletteEditing
            End With
            AddHandler ApplyButton.Click, Sub()
                                              Dim PaletteHexDataTextBoxBuilder As New StringBuilder()
                                              For i As Integer = 0 To 15
                                                  PaletteHexDataTextBoxBuilder.Append(GetPaletteTextBox(i).Text)
                                              Next
                                              PaletteHexDataTextBox.Text = PaletteHexDataTextBoxBuilder.ToString
                                          End Sub
            With ResetButton
                .Text = "Reset"
                .Width = 85
                .Height = 26
                .Location = New Point(352, 140)
                .Enabled = PaletteEditing
            End With
            AddHandler ResetButton.Click, Sub()
                                              GeneratePaletteBox()
                                          End Sub
            With ImportButton
                .Text = "Import"
                .Width = 85
                .Height = 26
                .Location = New Point(6, 140)
                .Enabled = PaletteEditing
            End With
            AddHandler ImportButton.Click, Sub()
                                               Dim PaletteImportDialog As FileDialog = New OpenFileDialog
                                               PaletteImportDialog.FileName = "Palette_" + PaletteNumberTextBox.Text
                                               PaletteImportDialog.Filter = "PAL Files (*.pal*)|*.pal"
                                               PaletteImportDialog.Title = "Import Palette"
                                               If PaletteImportDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                                                   Dim PaletteImportData() As String = My.Computer.FileSystem.ReadAllText(PaletteImportDialog.FileName, System.Text.Encoding.ASCII).Split(New String() {vbCrLf}, StringSplitOptions.None)
                                                   Dim LineCount As Integer = 0
                                                   Dim CompatibleFileFlag As Boolean = True
                                                   If PaletteImportData.LongCount() < 19 Then
                                                       CompatibleFileFlag = False
                                                   Else
                                                       For Each PaletteImportDataLine In PaletteImportData
                                                           LineCount = LineCount + 1
                                                           Select Case LineCount
                                                               Case 1
                                                                   If String.Compare(PaletteImportDataLine, "JASC-PAL") = 0 Then
                                                                       CompatibleFileFlag = True
                                                                   Else
                                                                       CompatibleFileFlag = False
                                                                       Exit For
                                                                   End If
                                                               Case 2
                                                                   If String.Compare(PaletteImportDataLine, "0100") = 0 Then
                                                                       CompatibleFileFlag = True
                                                                   Else
                                                                       CompatibleFileFlag = False
                                                                       Exit For
                                                                   End If
                                                               Case 3
                                                                   If String.Compare(PaletteImportDataLine, "16") = 0 Then
                                                                       CompatibleFileFlag = True
                                                                   Else
                                                                       CompatibleFileFlag = False
                                                                       Exit For
                                                                   End If
                                                               Case Else
                                                                   Dim RGBColor() As String = PaletteImportDataLine.Split(" ")
                                                                   If RGBColor.Length = 3 Then
                                                                       Dim HexColor As String = ""
                                                                       For Each IndividualColor In RGBColor
                                                                           HexColor += ToHex(CInt(IndividualColor), 2)
                                                                       Next
                                                                       'GetPaletteBox(LineCount - 4).BackColor = ReturnColor(HexColor, False)
                                                                       GetPaletteTextBox(LineCount - 4).Text = ConvertColor16(HexColor)
                                                                       If (LineCount - 4) = 15 Then
                                                                           CompatibleFileFlag = True
                                                                           Exit For
                                                                       End If
                                                                   Else
                                                                       CompatibleFileFlag = False
                                                                       Exit For
                                                                   End If
                                                           End Select
                                                       Next
                                                   End If
                                                   If CompatibleFileFlag = False Then
                                                       MessageBox.Show("The Palette file you provided seems to be corrupted or incompatible!" & vbCrLf & vbCrLf & " Please select a palette which has been genereated by this program or by program like Irfan View.", "Palette Import - Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                   End If
                                               End If
                                           End Sub
            With ExportButton
                .Text = "Export"
                .Width = 85
                .Height = 26
                .Location = New Point(97, 140)
            End With
            AddHandler ExportButton.Click, Sub()
                                               Dim PaletteFileData As New StringBuilder()
                                               PaletteFileData.Append("JASC-PAL" & vbCrLf)
                                               PaletteFileData.Append("0100" & vbCrLf)
                                               PaletteFileData.Append("16" & vbCrLf)
                                               For i As Integer = 0 To 15
                                                   PaletteFileData.Append(CStr(GetPaletteBox(i).BackColor.R) + " " + CStr(GetPaletteBox(i).BackColor.G) + " " + CStr(GetPaletteBox(i).BackColor.B) + "" & vbCrLf)
                                               Next
                                               Dim PaletteExportDialog As FileDialog = New SaveFileDialog
                                               PaletteExportDialog.FileName = "Palette_" + PaletteNumberTextBox.Text
                                               PaletteExportDialog.Filter = "PAL Files (*.pal*)|*.pal"
                                               PaletteExportDialog.Title = "Export Palette"
                                               If PaletteExportDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                                                   My.Computer.FileSystem.WriteAllText(PaletteExportDialog.FileName, PaletteFileData.ToString, False)
                                               End If
                                           End Sub
            With DisplayIndexCheckBox
                .Text = "Display Palette Index"
                .Location = New Point(200, 142)
                .Width = 200
                .Checked = PaletteBoxIndexDisplayFlag
            End With
            AddHandler DisplayIndexCheckBox.CheckedChanged, Sub(sender As Object, e As EventArgs)
                                                                If DisplayIndexCheckBox.CheckState = CheckState.Checked Then
                                                                    PaletteBoxIndexDisplayFlag = True
                                                                    GeneratePaletteBox()
                                                                Else
                                                                    PaletteBoxIndexDisplayFlag = False
                                                                    GeneratePaletteBox()
                                                                End If
                                                            End Sub
            PaletteEditorGroupBox.Controls.Add(ApplyButton)
            PaletteEditorGroupBox.Controls.Add(ResetButton)
            PaletteEditorGroupBox.Controls.Add(ImportButton)
            PaletteEditorGroupBox.Controls.Add(ExportButton)
            PaletteEditorGroupBox.Controls.Add(DisplayIndexCheckBox)
        End If
    End Sub

    Public Sub SelectPaletteBox(ByVal PaletteIndex As Integer)
        If (CheckNull() = False) And (PaletteHexDataTextBox.Text.Length = 64) And (IsNothing(PaletteContainerFlowPanel) = False) Then
            If PaletteIndex >= 0 And PaletteIndex <= 15 Then
                For Each PaletteElement In PaletteContainerFlowPanel.Controls
                    If CInt(PaletteElement.Tag) = PaletteIndex Then
                        ControlPaint.DrawBorder(PaletteElement.CreateGraphics(), PaletteElement.ClientRectangle,
                                                Color.Black, 2, ButtonBorderStyle.Solid,
                                                Color.Black, 2, ButtonBorderStyle.Solid,
                                                Color.Black, 2, ButtonBorderStyle.Solid,
                                                Color.Black, 2, ButtonBorderStyle.Solid)
                    Else
                        PaletteElement.Invalidate()
                    End If
                Next
            End If
        End If
    End Sub

    Public Sub UpdateTempDataCompact()
        If CheckNull() = False Then
            Dim TempPaletteDataBuilder As New StringBuilder()
            For Each PaletteElement In PaletteContainerFlowPanel.Controls.OfType(Of PaletteBox)()
                TempPaletteDataBuilder.Append(ReturnColor16(PaletteElement.BackColor))
            Next
            TempPaletteData = TempPaletteDataBuilder.ToString
        End If
    End Sub

    Public Sub EnableDisableResetApplyButtons()
        If CheckNull() = False Then
            If String.Compare(ResetPaletteData, TempPaletteData) <> 0 Then
                For Each Control In PaletteEditorGroupBox.Controls.OfType(Of Button)()
                    If Control.Name = "Reset" Then
                        Control.Enabled = True
                    End If
                Next
            Else
                For Each Control In PaletteEditorGroupBox.Controls.OfType(Of Button)()
                    If Control.Name = "Reset" Then
                        Control.Enabled = False
                    End If
                Next
            End If
            If String.Compare(TempPaletteData, PaletteHexDataTextBox.Text) <> 0 Then
                For Each Control In PaletteEditorGroupBox.Controls.OfType(Of Button)()
                    If Control.Name = "Apply" Then
                        Control.Enabled = True
                    End If
                Next
            Else
                For Each Control In PaletteEditorGroupBox.Controls.OfType(Of Button)()
                    If Control.Name = "Apply" Then
                        Control.Enabled = False
                    End If
                Next
            End If
        End If
    End Sub

    Public Sub ApplyPalette()
        If CheckNull() = False Then
            Dim PaletteHexDataBuilder As New StringBuilder()
            For Each PaletteElement In PaletteContainerFlowPanel.Controls.OfType(Of PaletteBox)()
                PaletteHexDataBuilder.Append(ReturnColor16(PaletteElement.BackColor))
            Next
            PaletteHexDataTextBox.Text = PaletteHexDataBuilder.ToString
            UpdateTempDataCompact()
        End If
    End Sub

    Public Sub GeneratePaletteBoxCompact()
        If (CheckNull() = False) And (PaletteHexDataTextBox.Text.Length = 64) And (CurrentPaletteConvertType = PaletteConvertType.Compact) Then
            PaletteEditorGroupBox.Controls.Clear()
            Dim PaletteDataArray() As String = SplitString(PaletteHexDataTextBox.Text, 4)
            PaletteContainerFlowPanel = New FlowLayoutPanel
            With PaletteContainerFlowPanel
                .Location = New Point(13, 21)
                .Size = New Size(PaletteEditorGroupBox.Width - 15, 64)
                .BorderStyle = BorderStyle.None
                .AutoScroll = False
            End With
            PaletteEditorGroupBox.Controls.Add(PaletteContainerFlowPanel)
            PaletteBoxIndexDisplayFlag = False
            Dim PaletteCount As Integer = 0
            For Each PaletteData In PaletteDataArray
                Dim PaletteElement As New PaletteBox
                With PaletteElement
                    .Size = New Size(25, 25)
                    .BackColor = ReturnColor(PaletteData, True)
                    .Tag = PaletteCount
                    .Cursor = Cursors.Hand
                End With
                AddHandler PaletteElement.Click, Sub(sender As Object, e As EventArgs)
                                                     Dim TempPaletteElement As PaletteBox = DirectCast(sender, PaletteBox)
                                                     SelectPaletteBox(CInt(TempPaletteElement.Tag))
                                                     If Control.ModifierKeys = Keys.Control Then
                                                         Dim PaletteColorDialog As New ColorDialog
                                                         With PaletteColorDialog
                                                             .FullOpen = True
                                                             .AnyColor = True
                                                             .SolidColorOnly = True
                                                         End With
                                                         PaletteColorDialog.Color = TempPaletteElement.BackColor
                                                         If PaletteColorDialog.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
                                                             TempPaletteElement.BackColor = PaletteColorDialog.Color
                                                         End If
                                                         UpdateTempDataCompact()
                                                         EnableDisableResetApplyButtons()
                                                     End If
                                                     SelectedPaletteColor = TempPaletteElement.BackColor
                                                     SelectedPaletteIndex = CInt(TempPaletteElement.Tag)
                                                 End Sub
                PaletteContainerFlowPanel.Controls.Add(PaletteElement)
                PaletteCount = PaletteCount + 1
            Next
            Dim PaletteImportButton As New Button
            With PaletteImportButton
                .Text = "Import"
                .Width = 65
                .Height = 26
                .AutoSize = False
                .Location = New Point(3, PaletteContainerFlowPanel.Height + 24)
                .BackColor = Color.Transparent
            End With
            AddHandler PaletteImportButton.Click, Sub()
                                                      Dim PaletteImportDialog As FileDialog = New OpenFileDialog
                                                      PaletteImportDialog.FileName = "Palette_" + PaletteNumberTextBox.Text
                                                      PaletteImportDialog.Filter = "PAL Files (*.pal*)|*.pal"
                                                      PaletteImportDialog.Title = "Import Palette"
                                                      If PaletteImportDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                                                          Dim PaletteImportData() As String = My.Computer.FileSystem.ReadAllText(PaletteImportDialog.FileName, System.Text.Encoding.ASCII).Split(New String() {vbCrLf}, StringSplitOptions.None)
                                                          Dim LineCount As Integer = 0
                                                          Dim CompatibleFileFlag As Boolean = True
                                                          If PaletteImportData.LongCount() < 19 Then
                                                              CompatibleFileFlag = False
                                                          Else
                                                              For Each PaletteImportDataLine In PaletteImportData
                                                                  LineCount = LineCount + 1
                                                                  Select Case LineCount
                                                                      Case 1
                                                                          If String.Compare(PaletteImportDataLine, "JASC-PAL") = 0 Then
                                                                              CompatibleFileFlag = True
                                                                          Else
                                                                              CompatibleFileFlag = False
                                                                              Exit For
                                                                          End If
                                                                      Case 2
                                                                          If String.Compare(PaletteImportDataLine, "0100") = 0 Then
                                                                              CompatibleFileFlag = True
                                                                          Else
                                                                              CompatibleFileFlag = False
                                                                              Exit For
                                                                          End If
                                                                      Case 3
                                                                          If String.Compare(PaletteImportDataLine, "16") = 0 Then
                                                                              CompatibleFileFlag = True
                                                                          Else
                                                                              CompatibleFileFlag = False
                                                                              Exit For
                                                                          End If
                                                                      Case Else
                                                                          Dim RGBColor() As String = PaletteImportDataLine.Split(" ")
                                                                          If RGBColor.Length = 3 Then
                                                                              Dim HexColor As String = ""
                                                                              For Each IndividualColor In RGBColor
                                                                                  HexColor += ToHex(CInt(IndividualColor), 2)
                                                                              Next
                                                                              GetPaletteBox(LineCount - 4).BackColor = ReturnColor(HexColor, False)
                                                                              If (LineCount - 4) = 15 Then
                                                                                  CompatibleFileFlag = True
                                                                                  Exit For
                                                                              End If
                                                                          Else
                                                                              CompatibleFileFlag = False
                                                                              Exit For
                                                                          End If
                                                                  End Select
                                                              Next
                                                          End If
                                                          If CompatibleFileFlag = False Then
                                                              MessageBox.Show("The Palette file you provided seems to be corrupted or incompatible!" & vbCrLf & vbCrLf & " Please select a palette which has been genereated by this program or by program like Irfan View.", "Palette Import - Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                          Else
                                                              UpdateTempDataCompact()
                                                          End If
                                                      End If
                                                  End Sub
            PaletteEditorGroupBox.Controls.Add(PaletteImportButton)
            Dim PaletteExportButton As New Button
            With PaletteExportButton
                .Text = "Export"
                .Width = 65
                .Height = 26
                .AutoSize = False
                .Location = New Point(69, PaletteContainerFlowPanel.Height + 24)
                .BackColor = Color.Transparent
            End With
            AddHandler PaletteExportButton.Click, Sub()
                                                      Dim PaletteFileData As New StringBuilder()
                                                      PaletteFileData.Append("JASC-PAL" & vbCrLf)
                                                      PaletteFileData.Append("0100" & vbCrLf)
                                                      PaletteFileData.Append("16" & vbCrLf)
                                                      For i As Integer = 0 To 15
                                                          PaletteFileData.Append(CStr(GetPaletteBox(i).BackColor.R) + " " + CStr(GetPaletteBox(i).BackColor.G) + " " + CStr(GetPaletteBox(i).BackColor.B) + "" & vbCrLf)
                                                      Next
                                                      Dim PaletteExportDialog As FileDialog = New SaveFileDialog
                                                      PaletteExportDialog.FileName = "Palette_" + PaletteNumberTextBox.Text
                                                      PaletteExportDialog.Filter = "PAL Files (*.pal*)|*.pal"
                                                      PaletteExportDialog.Title = "Export Palette"
                                                      If PaletteExportDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                                                          My.Computer.FileSystem.WriteAllText(PaletteExportDialog.FileName, PaletteFileData.ToString, False)
                                                      End If
                                                  End Sub
            PaletteEditorGroupBox.Controls.Add(PaletteExportButton)
            Dim PaletteResetButton As New Button
            With PaletteResetButton
                .Text = "Reset"
                .Name = "Reset"
                .Width = 65
                .Height = 26
                .AutoSize = False
                .Location = New Point(PaletteEditorGroupBox.Width - 136, PaletteContainerFlowPanel.Height + 24)
                .BackColor = Color.Transparent
            End With
            AddHandler PaletteResetButton.Click, Sub()
                                                     If ResetPaletteData <> "" Then
                                                         If String.Compare(ResetPaletteData, TempPaletteData) <> 0 Then
                                                             Dim Result As Integer = MessageBox.Show("Do you really want to reset? This will delete all the changes made to the palette.", "Confirm Reset?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                                             If Result = DialogResult.Yes Then
                                                                 PaletteHexDataTextBox.Text = ResetPaletteData
                                                                 TempPaletteData = ResetPaletteData
                                                                 GeneratePaletteBoxCompact()
                                                             End If
                                                         End If
                                                     Else
                                                         GeneratePaletteBoxCompact()
                                                     End If
                                                 End Sub
            PaletteEditorGroupBox.Controls.Add(PaletteResetButton)
            Dim PaletteApplyButton As New Button
            With PaletteApplyButton
                .Text = "Apply"
                .Name = "Apply"
                .Width = 65
                .Height = 26
                .AutoSize = False
                .Location = New Point(PaletteEditorGroupBox.Width - 69, PaletteContainerFlowPanel.Height + 24)
                .BackColor = Color.Transparent
            End With
            AddHandler PaletteApplyButton.Click, AddressOf ApplyPalette
            PaletteEditorGroupBox.Controls.Add(PaletteApplyButton)
        End If
        TempPaletteData = PaletteHexDataTextBox.Text
        EnableDisableResetApplyButtons()
    End Sub

#End Region

End Class