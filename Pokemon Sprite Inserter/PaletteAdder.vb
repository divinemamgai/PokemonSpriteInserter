Imports System.IO

Public Class PaletteAdder

    Public SearchForOffset As Boolean = True
    Public PaletteDataSize As Integer = 32
    Public PaletteDataOffset As String
    Dim PaletteObject As New PaletteConvert

    Private Function GetPaletteBox(ByVal Index As Integer) As PaletteBox
        Dim PaletteBoxContorls = PaletteEditorGroupBox.Controls.OfType(Of PaletteBox)()
        For Each PaletteBoxControl In PaletteBoxContorls
            If CInt(PaletteBoxControl.Tag) = Index Then
                Return PaletteBoxControl
            End If
        Next
        Return Nothing
    End Function

    Private Function GetPaletteTextBox(ByVal Index As Integer) As PaletteTextBox
        Dim PaletteTextBoxContorls = PaletteEditorGroupBox.Controls.OfType(Of PaletteTextBox)()
        For Each PaletteTextBoxContorl In PaletteTextBoxContorls
            If CInt(PaletteTextBoxContorl.Tag) = Index Then
                Return PaletteTextBoxContorl
            End If
        Next
        Return Nothing
    End Function

    Private Function GetColor16Code(ByVal Index As Integer) As String
        Dim Result = ""
        If Index < PaletteHexDataTextBox.MaxLength / 4 Then
            Result = PaletteHexDataTextBox.Text.Substring(Index * 4, 4)
        End If
        Return Result
    End Function

    Private Sub SetPaletteBox(sender As Object, ByVal e As EventArgs)
        Dim TextBoxElement As PaletteTextBox = DirectCast(sender, PaletteTextBox)
        If TextBoxElement.Text <> "" Then
            If IsNothing(GetPaletteBox(CInt(TextBoxElement.Tag))) = False Then
                GetPaletteBox(CInt(TextBoxElement.Tag)).BackColor = PaletteObject.ReturnColor(TextBoxElement.Text, True)
            End If
        End If
    End Sub

    Private Sub PaletteNullValidator(sender As Object, ByVal e As EventArgs)
        Dim TextBoxElement As PaletteTextBox = DirectCast(sender, PaletteTextBox)
        If TextBoxElement.Text = "" Then
            If IsNothing(GetPaletteBox(CInt(TextBoxElement.Tag))) = False Then
                TextBoxElement.Text = GetColor16Code(CInt(TextBoxElement.Tag))
                GetPaletteBox(CInt(TextBoxElement.Tag)).BackColor = PaletteObject.ReturnColor(TextBoxElement.Text, True)
            End If
        End If
    End Sub

    Private Sub SetPaletteColor(sender As Object, ByVal e As EventArgs)
        Dim PictureBoxElement As PaletteBox = DirectCast(sender, PaletteBox)
        PaletteColorDialog.Color = PictureBoxElement.BackColor
        If PaletteColorDialog.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
            PictureBoxElement.BackColor = PaletteColorDialog.Color
            GetPaletteTextBox(CInt(PictureBoxElement.Tag)).Text = PaletteObject.ConvertColor16(ToHex(PaletteColorDialog.Color.R, 2) + ToHex(PaletteColorDialog.Color.G, 2) + ToHex(PaletteColorDialog.Color.B, 2))
        End If
    End Sub

    Private Sub GeneratePaletteBox()
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
            Dim TextBoxElement As New PaletteTextBox
            Dim PictureBoxElement As New PaletteBox
            With TextBoxElement
                .Text = PaletteData.Substring(Count * 4, 4)
                .Location = New Point(6 + CountCol * 66, 32 + CountRow * 52)
                .Width = 60
                .BorderStyle = BorderStyle.None
                .Font = New Font("Calibri", 9, FontStyle.Bold)
                .MaxLength = 4
                .BackColor = Control.DefaultBackColor
                .CharacterCasing = CharacterCasing.Upper
                .TextAlign = HorizontalAlignment.Center
                .Tag = Count
            End With
            With PictureBoxElement
                .BackColor = PaletteObject.ReturnColor(PaletteData.Substring(Count * 4, 4))
                .Location = New Point(6 + CountCol * 66, 46 + CountRow * 52)
                .Width = 60
                .Height = 23
                .Cursor = Cursors.Hand
                .Tag = Count
                .BringToFront()
            End With
            AddHandler TextBoxElement.TextChanged, AddressOf SetPaletteBox
            AddHandler TextBoxElement.KeyPress, AddressOf HexInputValidator
            AddHandler TextBoxElement.Leave, AddressOf PaletteNullValidator
            PaletteEditorGroupBox.Controls.Add(TextBoxElement)
            AddHandler PictureBoxElement.Click, AddressOf SetPaletteColor
            PaletteEditorGroupBox.Controls.Add(PictureBoxElement)
        Next
        Dim ApplyButton As New Button
        Dim ResetButton As New Button
        Dim ImportButton As New Button
        Dim ExportButton As New Button
        With ApplyButton
            .Text = "Apply"
            .Width = 85
            .Height = 26
            .Location = New Point(443, 140)
        End With
        AddHandler ApplyButton.Click, Sub()
                                          PaletteHexDataTextBox.Text = ""
                                          For i As Integer = 0 To CountRow * 8 + CountCol
                                              PaletteHexDataTextBox.Text += GetPaletteTextBox(i).Text
                                          Next
                                      End Sub
        With ResetButton
            .Text = "Reset"
            .Width = 85
            .Height = 26
            .Location = New Point(352, 140)
        End With
        AddHandler ResetButton.Click, Sub()
                                          GeneratePaletteBox()
                                      End Sub
        With ImportButton
            .Text = "Import"
            .Width = 85
            .Height = 26
            .Location = New Point(6, 140)
        End With
        AddHandler ImportButton.Click, Sub()
                                           PaletteImportDialog.FileName = "Palette_" + PaletteNumberTextBox.Text
                                           PaletteImportDialog.Filter = "PAL Files (*.pal*)|*.pal"
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
                                                                   GetPaletteBox(LineCount - 4).BackColor = PaletteObject.ReturnColor(HexColor, False)
                                                                   GetPaletteTextBox(LineCount - 4).Text = PaletteObject.ConvertColor16(HexColor)
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
                                           Dim PaletteFileData As String = ""
                                           PaletteFileData += "JASC-PAL" & vbCrLf
                                           PaletteFileData += "0100" & vbCrLf
                                           PaletteFileData += "16" & vbCrLf
                                           For i As Integer = 0 To CountRow * 8 + CountCol
                                               PaletteFileData += CStr(GetPaletteBox(i).BackColor.R) + " " + CStr(GetPaletteBox(i).BackColor.G) + " " + CStr(GetPaletteBox(i).BackColor.B) + "" & vbCrLf
                                           Next
                                           PaletteExportDialog.FileName = "Palette_" + PaletteNumberTextBox.Text
                                           PaletteExportDialog.Filter = "PAL Files (*.pal*)|*.pal"
                                           If PaletteExportDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                                               My.Computer.FileSystem.WriteAllText(PaletteExportDialog.FileName, PaletteFileData, False)
                                           End If
                                       End Sub
        PaletteEditorGroupBox.Controls.Add(ApplyButton)
        PaletteEditorGroupBox.Controls.Add(ResetButton)
        PaletteEditorGroupBox.Controls.Add(ImportButton)
        PaletteEditorGroupBox.Controls.Add(ExportButton)
    End Sub

    Private Sub DefaultPaletteButtonClick(sender As Object, e As EventArgs) Handles DefaultPaletteButton.Click
        PaletteHexDataTextBox.Text = "F051F5211F4B5B3A0F210869E73C8E62AD14BD7FD66ABF25F81C7F2F771E0000"
    End Sub

    Private Sub FreeSpaceCheckBoxCheckedChanged(sender As Object, e As EventArgs) Handles FreeSpaceCheckBox.CheckedChanged
        If FreeSpaceCheckBox.CheckState = CheckState.Checked Then
            PaletteDataOffsetLabel.Enabled = False
            PaletteOffsetTextBox.Enabled = False
            FreeSpaceFromLabel.Enabled = True
            FreeSpaceStartTextBox.Enabled = True
            SearchForOffset = True
        Else
            PaletteDataOffsetLabel.Enabled = True
            PaletteOffsetTextBox.Enabled = True
            FreeSpaceFromLabel.Enabled = False
            FreeSpaceStartTextBox.Enabled = False
            SearchForOffset = False
        End If
    End Sub

    Private Sub Form5Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FreeSpaceCheckBox.Checked = True
        Log.Hide()
        BackButton.Hide()
        PaletteOffsetTextBox.MaxLength = ToHex(Main.RomLength).Length
        FreeSpaceStartTextBox.MaxLength = ToHex(Main.RomLength).Length
        PaletteHexDataTextBox.AutoSize = False
        PaletteHexDataTextBox.Height = 20
        GeneratePaletteBox()
    End Sub

    Private Sub InsertPaletteButtonClick(sender As Object, e As EventArgs) Handles InsertPaletteButton.Click
        Dim ErrorFlag = False
        PaletteAdderGroupBox.Text = "Adding Palette"
        Log.Show()
        BackButton.Enabled = False
        BackButton.Show()
        Log.Text += "Starting Palette Insertion Process..."
        If SearchForOffset = True Then
            Log.Text += vbCrLf & "Searching Free Space For Palette Data [" + CStr(PaletteDataSize) + " Bytes]..."
            PaletteDataOffset = SearchFreeSpace(ToDecimal(FreeSpaceStartTextBox.Text), PaletteDataSize, Main.FreeSpaceByteValue)
            If String.Compare(PaletteDataOffset, "Null") <> 0 Then
                Log.Text += vbCrLf & "     Found At Offset => 0x" + PaletteDataOffset
            Else
                ErrorFlag = True
                Log.Text += vbCrLf & "     Cannot Found Free Space!"
            End If
        Else
            If ToDecimal(PaletteOffsetTextBox.Text) <> 0 Then
                ErrorFlag = False
                PaletteDataOffset = PaletteOffsetTextBox.Text
                Log.Text += "Using Palette Data Offset => 0x" + PaletteDataOffset
            Else
                ErrorFlag = True
                Log.Text += vbCrLf & "Palette Offset Value Cannot Be Zero!"
                MessageBox.Show("Palette offset value cannot be zero!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
        If ErrorFlag = False Then
            Log.Text += vbCrLf & "Prompting User To Proceed To Write Palette Data..."
            Dim PromptResult As Integer = MessageBox.Show("Do you want to proceed writing Palette Data to your Rom?", "Confirm?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If PromptResult = DialogResult.Yes Then
                Log.Text += vbCrLf & "     Proceeding With Writing Procedure..."
                Log.Text += vbCrLf & "Writing Data [" + CStr(PaletteDataSize) + " Bytes]..."
                If WriteData(PaletteDataOffset, PaletteDataSize, PaletteHexDataTextBox.Text) = True Then
                    Log.Text += vbCrLf & "     Done!"
                    Log.Text += vbCrLf & "Finding Free Space In Palette Table..."
                    Dim RomFileReadStream As FileStream
                    Dim NumberOfPalettes As Integer = 0
                    RomFileReadStream = File.OpenRead(Main.RomFilePath)
                    RomFileReadStream.Seek(ToDecimal(Main.PaletteTableOffset), SeekOrigin.Begin)
                    Dim Flag As Boolean = False
                    While Flag = False
                        Dim Data As String = ""
                        Dim Buffer(7) As Byte
                        RomFileReadStream.Read(Buffer, 0, 8)
                        For i As Integer = 0 To Buffer.Length - 1
                            Data += Buffer(i).ToString("X2")
                        Next
                        If String.Compare(Data.Substring(0, Main.PaletteTableEndHex.Length), Main.PaletteTableEndHex) = 0 Then
                            ErrorFlag = False
                            Flag = True
                            Exit While
                        Else
                            NumberOfPalettes += 1
                            If NumberOfPalettes > Main.MaxPalette Then
                                Log.Text += vbCrLf & "Palette Table Is Full! Aborting..."
                                MessageBox.Show("Palette table is full! Aborting.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Flag = False
                                ErrorFlag = True
                                Exit While
                            End If
                        End If
                    End While
                    RomFileReadStream.Close()
                    If ErrorFlag = False Then
                        Dim PaletteOffset As String = ToHex(ToDecimal(Main.PaletteTableOffset) + NumberOfPalettes * 8)
                        Log.Text += vbCrLf & "     Found At Offset => 0x" + PaletteOffset
                        Log.Text += vbCrLf & "Generating Palette Header Data..."
                        Dim PaletteData As String = OffsetToPointer(PaletteDataOffset)
                        PaletteData += ToHex(CInt(PaletteNumberTextBox.Text), 2)
                        PaletteData += "110000"
                        PaletteData += Main.PaletteTableEndHex
                        Log.Text += vbCrLf & "     Done..."
                        Log.Text += vbCrLf & "Writing Data [" + CStr(PaletteData.Length / 2) + " Bytes]..."
                        If WriteData(PaletteOffset, PaletteData.Length / 2, PaletteData) = True Then
                            Log.Text += vbCrLf & "     Done!"
                            Log.Text += vbCrLf & "Everything Completed Successfully!"
                            BackButton.Enabled = True
                        Else
                            Log.Text += vbCrLf & "     Error Writing Data! Aborting..."
                            BackButton.Enabled = True
                        End If
                    Else
                        Log.Text += vbCrLf & "     Error Palette Table Is Full! Aborting..."
                        BackButton.Enabled = True
                    End If
                Else
                    Log.Text += vbCrLf & "     Error Writing Data! Aborting..."
                    BackButton.Enabled = True
                End If
            Else
                Log.Text += vbCrLf & "     Error! Aborted by user."
                BackButton.Enabled = True
            End If
        Else
            Log.Text += vbCrLf & "     Error! Aborting..."
            BackButton.Enabled = True
        End If
    End Sub

    Private Sub BackButtonClick(sender As Object, e As EventArgs) Handles BackButton.Click
        Log.Hide()
        Log.Text = ""
        BackButton.Hide()
    End Sub

    Private Sub LogTextChanged(sender As Object, e As EventArgs) Handles Log.TextChanged
        Log.SelectionStart = Log.Text.Length
        Log.ScrollToCaret()
    End Sub

    Private Sub PaletteHexDataTextBoxTextChanged(sender As Object, e As EventArgs) Handles PaletteHexDataTextBox.TextChanged
        If PaletteHexDataTextBox.Text.Length = PaletteHexDataTextBox.MaxLength Then
            GeneratePaletteBox()
        End If
    End Sub

#Region "Validation"
    Private Sub ApplyValidations() Handles Me.Load
        Dim AllTextBoxControls = PaletteAdderGroupBox.Controls.OfType(Of TextBox)()
        For Each ControlElement In AllTextBoxControls
            If CStr(ControlElement.Tag) <> "" Then
                AddHandler ControlElement.KeyPress, AddressOf SpaceValidator
                AddHandler ControlElement.Leave, AddressOf NullValidator
                Select Case ControlElement.Name
                    Case "PaletteOffsetTextBox", "FreeSpaceStartTextBox"
                        AddHandler ControlElement.Leave, AddressOf OffsetValidator
                        AddHandler ControlElement.KeyPress, AddressOf HexInputValidator
                    Case "PaletteHexDataTextBox"
                        AddHandler ControlElement.Leave, AddressOf HexValueValidator
                        AddHandler ControlElement.KeyPress, AddressOf HexInputValidator
                    Case Else
                        AddHandler ControlElement.TextChanged, AddressOf SetMaxLimitDefault
                        AddHandler ControlElement.TextChanged, AddressOf MaxLimitValidator
                        AddHandler ControlElement.KeyPress, AddressOf DigitValidator
                End Select
            End If
        Next
    End Sub
#End Region

End Class