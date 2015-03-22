Public Class PaletteBrowser

#Region "Variables"

    Public MainForm As Form
    Public MainPage As TabPage
    Public PaletteTableGroupBox As New GroupBox
    Public PaletteTablePanel As New TablePanel
    Public PaletteTableHeaderIndex As New Label
    Public PaletteTableHeaderOffset As New Label
    Public PaletteTableHeaderNumber As New Label
    Public PaletteTableHeaderDataOffset As New Label
    Public PaletteTableHeaderData As New Label
    Public PaletteNumberTextBox As New TextBox
    Public PaletteHexDataTextBox As New TextBox
    Public PaletteDataOffsetTextBox As New TextBox
    Public PaletteNumberLabel As New Label
    Public PaletteHexDataLabel As New Label
    Public PaletteDataOffsetLabel As New Label
    Public PaletteViewGroupBox As New GroupBox
    Public EditorButton As New Button
    Public LoadPaletteButton As New Button
    Public CancelButton As New Button
    Public DeleteButton As New Button
    Public SaveChangesButton As New Button
    Public PaletteEditorGroupBox As New GroupBox
    Public PaletteLabelColor As Color = Color.White
    Public Log As New RichTextBox
    Public LogBackButton As New Button

    Public PaletteDataArray As PaletteData()
    Public PaletteConvertObject As PaletteConvert
    Public LoadPaletteFlag As Boolean = False
    Public PaletteEditorFlag As Boolean = False
    Public CurrentPaletteRow As Integer = -1
    Public PreviousPaletteRow As Integer = -1

    Public Sub New(Optional ByVal DefaultForm As Form = Nothing,
                   Optional ByVal DefaultTabPage As TabPage = Nothing,
                   Optional ByVal DefaultLoadPaletteFlag As Boolean = Nothing,
                   Optional ByVal DefaultPaletteLabelColor As Color = Nothing)
        If IsNothing(DefaultPaletteLabelColor) = False Then
            PaletteLabelColor = DefaultPaletteLabelColor
        End If
        If IsNothing(DefaultLoadPaletteFlag) = False Then
            LoadPaletteFlag = DefaultLoadPaletteFlag
        End If
        If IsNothing(DefaultForm) = False Then
            MainForm = DefaultForm
            MainForm.Size = New Size(592, 550)
            PaletteBrowserLoad()
        Else
            If IsNothing(DefaultTabPage) = False Then
                MainPage = DefaultTabPage
                MainPage.Size = New Size(592, 600)
                PaletteBrowserLoad()
            End If
        End If
    End Sub

#End Region

#Region "Main Functions"

    Private Function GetPaletteHeaderIndexLabel(ByVal Index As Integer) As Label
        Dim PaletteLabelItems = PaletteTablePanel.Controls.OfType(Of Label)()
        For Each PaletteLabelItem In PaletteLabelItems
            If IsNothing(PaletteLabelItem) = False Then
                If String.Compare(CStr(PaletteLabelItem.Tag), "HeaderLabel") <> 0 Then
                    If PaletteLabelItem.Name = "PaletteIndexLabel" Then
                        If CInt(PaletteLabelItem.Tag) = Index Then
                            Return PaletteLabelItem
                        End If
                    End If
                End If
            End If
        Next
        Return Nothing
    End Function

    Public Sub SetLabelProp(ByVal PaletteID As Integer, ByVal BackColor As Color, ByVal UseFont As Font)
        Dim PaletteLabelItems = PaletteTablePanel.Controls.OfType(Of Label)()
        For Each PaletteLabelItem In PaletteLabelItems
            If IsNothing(PaletteLabelItem) = False Then
                If String.Compare(CStr(PaletteLabelItem.Tag), "HeaderLabel") <> 0 Then
                    If CInt(PaletteLabelItem.Tag) = PaletteID Then
                        PaletteLabelItem.BackColor = BackColor
                        PaletteLabelItem.Font = UseFont
                    End If
                End If
            End If
        Next
    End Sub

    Public Sub PaletteTableLableMouseIn(sender As Object, e As EventArgs)
        Dim LabelItem As Label = DirectCast(sender, Label)
        If IsNothing(LabelItem) = False Then
            If CInt(LabelItem.Tag) <> CurrentPaletteRow Then
                SetLabelProp(CInt(LabelItem.Tag), Color.WhiteSmoke, New Font("Calibri", 9, FontStyle.Bold))
            End If
        End If
    End Sub

    Public Sub PaletteTableLableMouseClick(sender As Object, e As EventArgs)
        Dim LabelItem As Label = DirectCast(sender, Label)
        If IsNothing(LabelItem) = False Then
            SetLabelProp(CInt(LabelItem.Tag), Color.White, New Font("Calibri", 9, FontStyle.Bold))
            If IsNothing(PaletteNumberTextBox) = False Then
                PaletteNumberTextBox.Text = CStr(PaletteDataArray(CInt(LabelItem.Tag) - 1).PaletteNumber)
                PaletteHexDataTextBox.Text = CStr(PaletteDataArray(CInt(LabelItem.Tag) - 1).PaletteHexData)
            End If
            If IsNothing(PaletteNumberTextBox) = False Then
                PaletteNumberTextBox.Tag = CStr(PaletteDataArray(CInt(LabelItem.Tag) - 1).PaletteNumber)
                PaletteHexDataTextBox.Tag = CStr(PaletteDataArray(CInt(LabelItem.Tag) - 1).PaletteHexData)
            End If
            If IsNothing(PaletteDataOffsetTextBox) = False Then
                PaletteDataOffsetTextBox.Text = CStr(PaletteDataArray(CInt(LabelItem.Tag) - 1).PaletteDataOffset)
                PaletteDataOffsetTextBox.Tag = CStr(PaletteDataArray(CInt(LabelItem.Tag) - 1).PaletteDataOffset)
            End If
            ApplyValidations()
            If PaletteEditorFlag = True Then
                PaletteViewGroupBox.Enabled = True
            End If
            If LoadPaletteFlag = True Then
                LoadPaletteButton.Enabled = True
            End If
            CurrentPaletteRow = CInt(LabelItem.Tag)
            If PreviousPaletteRow <> CurrentPaletteRow Then
                SetLabelProp(PreviousPaletteRow, ColorTranslator.FromHtml("#eeeeee"), New Font("Calibri", 9, FontStyle.Regular))
            End If
            PreviousPaletteRow = CurrentPaletteRow
        End If
    End Sub

    Public Sub PaletteTableLableMouseOut(sender As Object, e As EventArgs)
        Dim LabelItem As Label = DirectCast(sender, Label)
        If IsNothing(LabelItem) = False Then
            If CInt(LabelItem.Tag) <> CurrentPaletteRow Then
                SetLabelProp(CInt(LabelItem.Tag), ColorTranslator.FromHtml("#eeeeee"), New Font("Calibri", 9, FontStyle.Regular))
                PaletteTablePanel.Focus()
            End If
        End If
    End Sub

    Private Sub AppendPaletteLabelHanders()
        Dim PaletteLabelItems = PaletteTablePanel.Controls.OfType(Of Label)()
        For Each PaletteLabelItem In PaletteLabelItems
            If IsNothing(PaletteLabelItem) = False Then
                If String.Compare(CStr(PaletteLabelItem.Tag), "HeaderLabel") <> 0 Then
                    PaletteLabelItem.Cursor = Cursors.Hand
                    AddHandler PaletteLabelItem.MouseEnter, AddressOf PaletteTableLableMouseIn
                    AddHandler PaletteLabelItem.MouseLeave, AddressOf PaletteTableLableMouseOut
                    AddHandler PaletteLabelItem.Click, AddressOf PaletteTableLableMouseClick
                End If
            End If
        Next
    End Sub

    Public Sub UpdatePaletteTable()
        PaletteTablePanel.Controls.Clear()
        With PaletteTableHeaderIndex
            .Name = "PaletteTableHeaderIndex"
            .Text = "#"
            .Tag = "HeaderLabel"
            .Font = New Font("Calibri", 9.75, FontStyle.Bold)
            .BorderStyle = BorderStyle.FixedSingle
            .Padding = New Padding(2, 2, 2, 2)
            .Margin = New Padding(0, 0, 0, 0)
            .Location = New Point(-1, -1)
            .Size = New Point(30, 21)
        End With
        With PaletteTableHeaderOffset
            .Name = "PaletteTableHeaderOffset"
            .Text = "Palette Offset"
            .Tag = "HeaderLabel"
            .Font = New Font("Calibri", 9.75, FontStyle.Bold)
            .BorderStyle = BorderStyle.FixedSingle
            .Padding = New Padding(2, 2, 2, 2)
            .Margin = New Padding(0, 0, 0, 0)
            .Location = New Point(28, -1)
            .Size = New Point(120, 21)
        End With
        With PaletteTableHeaderNumber
            .Name = "PaletteTableHeaderNumber"
            .Text = "Palette Number"
            .Tag = "HeaderLabel"
            .Font = New Font("Calibri", 9.75, FontStyle.Bold)
            .BorderStyle = BorderStyle.FixedSingle
            .Padding = New Padding(2, 2, 2, 2)
            .Margin = New Padding(0, 0, 0, 0)
            .Location = New Point(147, -1)
            .Size = New Point(101, 21)
        End With
        With PaletteTableHeaderDataOffset
            .Name = "PaletteTableHeaderDataOffset"
            .Text = "Palette Data Offset"
            .Tag = "HeaderLabel"
            .Font = New Font("Calibri", 9.75, FontStyle.Bold)
            .BorderStyle = BorderStyle.FixedSingle
            .Padding = New Padding(2, 2, 2, 2)
            .Margin = New Padding(0, 0, 0, 0)
            .Location = New Point(247, -1)
            .Size = New Point(120, 21)
        End With
        With PaletteTableHeaderData
            .Name = "PaletteTableHeaderData"
            .Text = "Palette Data"
            .Tag = "HeaderLabel"
            .Font = New Font("Calibri", 9.75, FontStyle.Bold)
            .BorderStyle = BorderStyle.FixedSingle
            .Padding = New Padding(2, 2, 2, 2)
            .Margin = New Padding(0, 0, 0, 0)
            .Location = New Point(366, -1)
            .Size = New Point(420, 21)
        End With
        PaletteTablePanel.Controls.AddRange({PaletteTableHeaderIndex, PaletteTableHeaderOffset, PaletteTableHeaderNumber, PaletteTableHeaderDataOffset, PaletteTableHeaderData})
        PaletteDataArray = GetPalettes(Main.PaletteTableOffset, Main.PaletteTableEndHex, Main.MaxPalette)
        For i As Integer = 0 To PaletteDataArray.Length - 1
            Dim PaletteIndexLabel As New Label
            With PaletteIndexLabel
                .Name = "PaletteIndexLabel"
                .Width = 30
                .Height = 21
                .Text = PaletteDataArray(i).PaletteIndex
                .Location = New Point(-1, 20 * (i + 1) - 1)
                .BorderStyle = BorderStyle.FixedSingle
                .Margin = New Padding(0, 0, 0, 0)
                .Padding = New Padding(3, 3, 2, 2)
                .BackColor = ColorTranslator.FromHtml("#eeeeee")
                .Tag = i + 1
                .Font = New Font("Calibri", 9, FontStyle.Regular)
            End With
            Dim PaletteOffsetLabel As New Label
            With PaletteOffsetLabel
                .Name = "PaletteOffsetLabel"
                .Width = 120
                .Height = 21
                .Text = PaletteDataArray(i).PaletteOffset
                .Location = New Point(28, 20 * (i + 1) - 1)
                .BorderStyle = BorderStyle.FixedSingle
                .Margin = New Padding(0, 0, 0, 0)
                .Padding = New Padding(3, 3, 2, 2)
                .BackColor = ColorTranslator.FromHtml("#eeeeee")
                .Tag = i + 1
                .Font = New Font("Calibri", 9, FontStyle.Regular)
            End With
            Dim PaletteNumberLabel As New Label
            With PaletteNumberLabel
                .Name = "PaletteNumberLabel"
                .Width = 101
                .Height = 21
                .Text = PaletteDataArray(i).PaletteNumber
                .Location = New Point(147, 20 * (i + 1) - 1)
                .BorderStyle = BorderStyle.FixedSingle
                .Margin = New Padding(0, 0, 0, 0)
                .Padding = New Padding(3, 3, 2, 2)
                .BackColor = ColorTranslator.FromHtml("#eeeeee")
                .Tag = i + 1
                .Font = New Font("Calibri", 9, FontStyle.Regular)
            End With
            Dim PaletteDataOffsetLabel As New Label
            With PaletteDataOffsetLabel
                .Name = "PaletteDataOffsetLabel"
                .Width = 120
                .Height = 21
                .Text = PaletteDataArray(i).PaletteDataOffset
                .Location = New Point(247, 20 * (i + 1) - 1)
                .BorderStyle = BorderStyle.FixedSingle
                .Margin = New Padding(0, 0, 0, 0)
                .Padding = New Padding(3, 3, 2, 2)
                .BackColor = ColorTranslator.FromHtml("#eeeeee")
                .Tag = i + 1
                .Font = New Font("Calibri", 9, FontStyle.Regular)
            End With
            Dim PaletteHexDataLabel As New Label
            With PaletteHexDataLabel
                .Name = "PaletteHexDataLabel"
                .Width = 420
                .Height = 21
                .Text = PaletteDataArray(i).PaletteHexData
                .Location = New Point(366, 20 * (i + 1) - 1)
                .BorderStyle = BorderStyle.FixedSingle
                .Margin = New Padding(0, 0, 0, 0)
                .Padding = New Padding(3, 3, 2, 2)
                .BackColor = ColorTranslator.FromHtml("#eeeeee")
                .Tag = i + 1
                .Font = New Font("Calibri", 9, FontStyle.Regular)
            End With
            PaletteTablePanel.Controls.AddRange({PaletteIndexLabel, PaletteOffsetLabel, PaletteNumberLabel, PaletteDataOffsetLabel, PaletteHexDataLabel})
        Next
        AppendPaletteLabelHanders()
    End Sub

    Public Sub PerformProcess()
        Log.Show()
        LogBackButton.Show()
        Log.Text = "Starting Palette Updation Process..."
        Log.Text += vbCrLf & "Prompting User To Proceed..."
        Dim Result As Integer = MessageBox.Show("Do you really want to update the palette?" & vbCrLf & vbCrLf & "Note : This process is not reversible!", "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If Result = DialogResult.Yes Then
            Log.Text += vbCrLf & "     Proceeding To Writing Procedure..."
            If String.Compare(PaletteDataArray(CurrentPaletteRow - 1).PaletteDataOffset, PaletteDataOffsetTextBox.Text) <> 0 Then
                Log.Text += vbCrLf & "Palette Data Offset Change Detected..."
                Log.Text += vbCrLf & "Freeing Up Previous Palette Hex Data [" + CStr(Main.PaletteDataSize) + " Bytes] Offset => 0x" + PaletteDataArray(CurrentPaletteRow - 1).PaletteDataOffset
                If WriteData(PaletteDataArray(CurrentPaletteRow - 1).PaletteDataOffset, Main.PaletteDataSize, Main.FreeSpaceByteValue, 1) = True Then
                    Log.Text += vbCrLf & "     Done!"
                Else
                    Log.Text += vbCrLf & "     Error Occurred While Freeing Up Previous Palette Data In Rom!"
                    Log.Text += vbCrLf & "Aborting..."
                    LogBackButton.Enabled = True
                    Return
                End If
            End If
            Log.Text += vbCrLf & "Writing Palette Hex Data [" + CStr(Main.PaletteDataSize) + " Bytes] To Rom At Offset => 0x" + PaletteDataOffsetTextBox.Text
            If WriteData(PaletteDataOffsetTextBox.Text, Main.PaletteDataSize, PaletteHexDataTextBox.Text) = True Then
                Log.Text += vbCrLf & "     Done!"
                Log.Text += vbCrLf & "Generating Palette Header Data..."
                Dim PaletteData As String = OffsetToPointer(PaletteDataOffsetTextBox.Text)
                PaletteData += ToHex(CInt(PaletteNumberTextBox.Text), 2)
                PaletteData += "110000"
                Log.Text += vbCrLf & "     Done!"
                Log.Text += vbCrLf & "Writing Palette Header Data [" + CStr(PaletteData.Length / 2) + " Bytes] To Rom At Offset => 0x" + PaletteDataArray(CurrentPaletteRow - 1).PaletteOffset
                If WriteData(PaletteDataArray(CurrentPaletteRow - 1).PaletteOffset, PaletteData.Length / 2, PaletteData) = True Then
                    Log.Text += vbCrLf & "     Done!"
                    Log.Text += vbCrLf & "Everything Completed Successfully!"
                    Log.Text += vbCrLf & "Refreshing Browser..."
                    PaletteTablePanel.Enabled = False
                    UpdatePaletteTable()
                    SetLabelProp(CurrentPaletteRow, Color.White, New Font("Calibri", 9, FontStyle.Bold))
                    If IsNothing(PaletteNumberTextBox) = False Then
                        PaletteNumberTextBox.Text = CStr(PaletteDataArray(CurrentPaletteRow - 1).PaletteNumber)
                        PaletteNumberTextBox.Tag = CStr(PaletteDataArray(CurrentPaletteRow - 1).PaletteNumber)
                    End If
                    If IsNothing(PaletteHexDataTextBox) = False Then
                        PaletteHexDataTextBox.Text = CStr(PaletteDataArray(CurrentPaletteRow - 1).PaletteHexData)
                        PaletteHexDataTextBox.Tag = CStr(PaletteDataArray(CurrentPaletteRow - 1).PaletteHexData)
                    End If
                    If IsNothing(PaletteDataOffsetTextBox) = False Then
                        PaletteDataOffsetTextBox.Text = CStr(PaletteDataArray(CurrentPaletteRow - 1).PaletteDataOffset)
                        PaletteDataOffsetTextBox.Tag = CStr(PaletteDataArray(CurrentPaletteRow - 1).PaletteDataOffset)
                    End If
                    ApplyValidations()
                    If PaletteEditorFlag = True Then
                        PaletteViewGroupBox.Enabled = True
                    End If
                    If LoadPaletteFlag = True Then
                        LoadPaletteButton.Enabled = True
                    End If
                    PaletteTablePanel.Enabled = True
                    GetPaletteHeaderIndexLabel(CurrentPaletteRow).Select()
                    Log.Text += vbCrLf & "     Done!"
                    Log.Select()
                    LogBackButton.Enabled = True
                Else
                    Log.Text += vbCrLf & "     Error Occurred While Writing Palette Header Data To Rom!"
                    Log.Text += vbCrLf & "     Something Went Teribly Wrong!"
                    Log.Text += vbCrLf & "Aborted!"
                    LogBackButton.Enabled = True
                End If
            Else
                Log.Text += vbCrLf & "     Error Occurred While Writing Palette Hex Data To Rom!"
                Log.Text += vbCrLf & "Aborting..."
                LogBackButton.Enabled = True
            End If
        Else
            Log.Text += vbCrLf & "     Stopped By User!"
            LogBackButton.Enabled = True
        End If
    End Sub

    Public Sub DeletePalette()
        Dim Result As Integer = MessageBox.Show("Do you really want to continue with the palette deletion process? This will erase the current palette data from the rom." & vbCrLf & vbCrLf & "This process is not reversible!", "Confirm Palette Deletion?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If Result = DialogResult.Yes Then
            Log.Show()
            LogBackButton.Show()
            Log.Text = "Starting Palette Deletion Process..."
            Log.Text += vbCrLf & "Freeing Up Palette Hex Data [" + CStr(Main.PaletteDataSize) + " Bytes] At Offset => 0x" + PaletteDataArray(CurrentPaletteRow - 1).PaletteDataOffset
            If WriteData(PaletteDataArray(CurrentPaletteRow - 1).PaletteDataOffset, Main.PaletteDataSize, Main.FreeSpaceByteValue, 1) = True Then
                Log.Text += vbCrLf & "     Done!"
                Log.Text += vbCrLf & "Deleting Palette Header Data [8 Bytes] From Palette Table At Offset => 0x" + PaletteDataArray(CurrentPaletteRow - 1).PaletteOffset
                Dim PaletteTableFreeSpaceByte As String = Main.PaletteTableEmptyDataHex.Substring(0, 2)
                If WriteData(PaletteDataArray(CurrentPaletteRow - 1).PaletteOffset, 8, PaletteTableFreeSpaceByte, 1) = True Then
                    Log.Text += vbCrLf & "     Done!"
                    Log.Text += vbCrLf & "Shifting Rest Of The Palette Table..."
                    Log.Text += vbCrLf & "Reading The Rest Of The Palette Table..."
                    Dim NextPaletteOffset As String = ToHex(ToDecimal(PaletteDataArray(CurrentPaletteRow - 1).PaletteOffset) + 8)
                    Dim NumberOfBytesToMove As Integer = (PaletteDataArray.Length - CurrentPaletteRow + 1) * 8
                    Dim RestPaletteTableData As String = ReadData(NextPaletteOffset, NumberOfBytesToMove)
                    Log.Text += vbCrLf & "     Done!"
                    Log.Text += vbCrLf & "Freeing Up Obsolete Palette Table Data [" + CStr(NumberOfBytesToMove) + " Bytes] At Offset => 0x" + NextPaletteOffset
                    If WriteData(NextPaletteOffset, NumberOfBytesToMove, PaletteTableFreeSpaceByte, 1) = True Then
                        Log.Text += vbCrLf & "     Done!"
                        Log.Text += vbCrLf & "Writing Original Palette Table Data [" + CStr(NumberOfBytesToMove) + " Bytes] Back To Rom At Offset => 0x" + PaletteDataArray(CurrentPaletteRow - 1).PaletteOffset
                        If WriteData(PaletteDataArray(CurrentPaletteRow - 1).PaletteOffset, NumberOfBytesToMove, RestPaletteTableData) = True Then
                            Log.Text += vbCrLf & "     Done!"
                            Log.Text += vbCrLf & "Every Thing Completed Successfully!"
                            Log.Text += vbCrLf & "Refreshing Browser..."
                            PaletteTablePanel.Enabled = False
                            UpdatePaletteTable()
                            If IsNothing(PaletteNumberTextBox) = False Then
                                PaletteNumberTextBox.Text = ""
                                PaletteNumberTextBox.Tag = ""
                            End If
                            If IsNothing(PaletteHexDataTextBox) = False Then
                                PaletteHexDataTextBox.Text = ""
                                PaletteHexDataTextBox.Tag = ""
                            End If
                            If IsNothing(PaletteDataOffsetTextBox) = False Then
                                PaletteDataOffsetTextBox.Text = ""
                                PaletteDataOffsetTextBox.Tag = ""
                            End If
                            PaletteTablePanel.Enabled = True
                            PaletteTablePanel.Select()
                            PaletteEditorGroupBox.Controls.Clear()
                            PaletteViewGroupBox.Enabled = False
                            Log.Text += vbCrLf & "     Done!"
                            Log.Select()
                            LogBackButton.Enabled = True
                        Else
                            Log.Text += vbCrLf & "     Error Occurred While Writing New Palette Table Data From Rom!"
                            Log.Text += vbCrLf & "Trying To Restore The Deleted Palette Headers Data To Original State..."
                            Dim PaletteData As String = OffsetToPointer(PaletteDataArray(CurrentPaletteRow - 1).PaletteDataOffset)
                            PaletteData += ToHex(PaletteDataArray(CurrentPaletteRow - 1).PaletteNumber)
                            PaletteData += "110000"
                            PaletteData += RestPaletteTableData
                            If WriteData(PaletteDataArray(CurrentPaletteRow - 1).PaletteOffset, NumberOfBytesToMove + 1, PaletteData) = True Then
                                Log.Text += vbCrLf & "     Done!"
                                Log.Text += vbCrLf & "Error Occurred While Deleting But Rom Restored To Original State Successfully!"
                                LogBackButton.Enabled = True
                            Else
                                Log.Text += vbCrLf & "     Something Went Teribly Wrong!"
                                Log.Text += vbCrLf & "Aborted!"
                                LogBackButton.Enabled = True
                            End If
                        End If
                    Else
                        Log.Text += vbCrLf & "     Error Occurred While Freeing Up Obsolete Palette Table Data From Rom!"
                        Log.Text += vbCrLf & "Trying To Restore The Deleted Palette Header Data To Original State..."
                        Dim PaletteData As String = OffsetToPointer(PaletteDataArray(CurrentPaletteRow - 1).PaletteDataOffset)
                        PaletteData += ToHex(PaletteDataArray(CurrentPaletteRow - 1).PaletteNumber)
                        PaletteData += "110000"
                        Log.Text += vbCrLf & "Writing Palette Header Data [8 Bytes] Back To Rom At Offset => 0x" + PaletteDataArray(CurrentPaletteRow - 1).PaletteOffset
                        If WriteData(PaletteDataArray(CurrentPaletteRow - 1).PaletteOffset, 8, PaletteData) = True Then
                            Log.Text += vbCrLf & "     Done!"
                            Log.Text += vbCrLf & "Error Occurred While Deleting But Rom Restored To Original State Successfully!"
                            LogBackButton.Enabled = True
                        Else
                            Log.Text += vbCrLf & "     Something Went Teribly Wrong!"
                            Log.Text += vbCrLf & "Aborted!"
                            LogBackButton.Enabled = True
                        End If
                    End If
                Else
                    Log.Text += vbCrLf & "     Error Occurred While Deleting Palette Header Data!"
                    Log.Text += vbCrLf & "Trying To Restore The Deleted Palette Hex Data To Original State..."
                    Log.Text += vbCrLf & "Writing Palette Hex Data [" + CStr(Main.PaletteDataSize) + " Bytes] Back To Rom At Offset => 0x" + PaletteDataArray(CurrentPaletteRow - 1).PaletteDataOffset
                    If WriteData(PaletteDataArray(CurrentPaletteRow - 1).PaletteDataOffset, Main.PaletteDataSize, PaletteDataArray(CurrentPaletteRow - 1).PaletteHexData) = True Then
                        Log.Text += vbCrLf & "     Done!"
                        Log.Text += vbCrLf & "Error Occurred While Deleting But Rom Restored To Original State Successfully!"
                        LogBackButton.Enabled = True
                    Else
                        Log.Text += vbCrLf & "     Error Occurred While Writing Palette Hex Data To Rom!"
                        Log.Text += vbCrLf & "     Something Went Teribly Wrong!"
                        Log.Text += vbCrLf & "Aborted!"
                        LogBackButton.Enabled = True
                    End If
                End If
            Else
                Log.Text += vbCrLf & "     Error Occurred While Deleting Palette Data From Rom!"
                Log.Text += vbCrLf & "Aborting..."
                LogBackButton.Enabled = True
            End If
        End If
    End Sub

#End Region

#Region "Palette Browser Load"
    Public Sub PaletteBrowserLoad()
        Try
            With PaletteTableGroupBox
                .Name = "PaletteTableGroupBox"
                .Font = New Font("Calibri", 9.75, FontStyle.Bold)
                .Text = "Palette Table Browser"
                .Margin = New Padding(3, 3, 3, 3)
                .Padding = New Padding(3, 3, 3, 3)
                .Location = New Point(13, 13)
                .Width = 549
                .Height = 191
            End With
            With PaletteTablePanel
                .Name = "PaletteTablePanel"
                .BorderStyle = BorderStyle.FixedSingle
                .Font = New Font("Calibri", 9.75, FontStyle.Bold)
                .AutoScroll = True
                .Margin = New Padding(3, 3, 3, 3)
                .Location = New Point(6, 22)
                .Width = 537
                .Height = 163
            End With
            With PaletteNumberLabel
                .Name = "PaletteNumberLabel"
                .Font = New Font("Calibri", 9.75, FontStyle.Regular)
                .Text = "Palette Number [Decimal] :"
                .Location = New Point(6, 19)
                .Margin = New Padding(3, 0, 3, 0)
                .Width = 153
                .Height = 15
            End With
            With PaletteNumberTextBox
                .Name = "PaletteNumberTextBox"
                .Font = New Font("Calibri", 9.75, FontStyle.Bold)
                .MaxLength = 3
                .ReadOnly = True
                .Location = New Point(159, 18)
                .Margin = New Padding(3, 3, 3, 3)
                .Width = 28
                .Height = 20
                .AutoSize = False
                .ReadOnly = Not PaletteEditorFlag
            End With
            With PaletteHexDataLabel
                .Name = "PaletteHexDataLabel"
                .Font = New Font("Calibri", 9.75, FontStyle.Regular)
                .Text = "Palette Hex Data :"
                .Location = New Point(6, 46)
                .Margin = New Padding(3, 0, 3, 0)
                .Width = 103
                .Height = 15
            End With
            With PaletteHexDataTextBox
                .Name = "PaletteHexDataTextBox"
                .Font = New Font("Calibri", 9, FontStyle.Bold)
                .CharacterCasing = CharacterCasing.Upper
                .MaxLength = 64
                .ReadOnly = True
                .Location = New Point(109, 45)
                .Margin = New Padding(3, 3, 3, 3)
                .Width = 434
                .Height = 20
                .AutoSize = False
                .ReadOnly = Not PaletteEditorFlag
            End With
            AddHandler PaletteHexDataTextBox.TextChanged, AddressOf PaletteHexDataTextBoxTextChanged
            With PaletteDataOffsetLabel
                .Name = "PaletteDataOffsetLabel"
                .Font = New Font("Calibri", 9.75, FontStyle.Regular)
                .Text = "Palette Data Offset :"
                .Location = New Point(191, 19)
                .Margin = New Padding(3, 0, 3, 0)
                .Width = 118
                .Height = 15
            End With
            With PaletteDataOffsetTextBox
                .Name = "PaletteDataOffsetTextBox"
                .Font = New Font("Calibri", 9.75, FontStyle.Bold)
                .CharacterCasing = CharacterCasing.Upper
                .MaxLength = 6
                .ReadOnly = True
                .Location = New Point(307, 18)
                .Margin = New Padding(3, 3, 3, 3)
                .Width = 55
                .Height = 20
                .AutoSize = False
                .ReadOnly = Not PaletteEditorFlag
            End With
            With DeleteButton
                .Name = "DeleteButton"
                .Font = New Font("Calibri", 9.75, FontStyle.Bold)
                .Margin = New Padding(3, 3, 3, 3)
                .Padding = New Padding(0, 0, 0, 0)
                .Location = New Point(368, 15)
                .Size = New Size(69, 25)
                .Text = "Delete"
                .Enabled = False 'PaletteEditorFlag
            End With
            AddHandler DeleteButton.Click, AddressOf DeleteButtonClick
            With SaveChangesButton
                .Name = "SaveChangesButton"
                .Font = New Font("Calibri", 9.75, FontStyle.Bold)
                .Margin = New Padding(3, 3, 3, 3)
                .Padding = New Padding(0, 0, 0, 0)
                .Location = New Point(441, 15)
                .Size = New Size(102, 25)
                .Text = "Save Changes"
                .Enabled = False 'PaletteEditorFlag
            End With
            AddHandler SaveChangesButton.Click, AddressOf SaveButtonClick
            With PaletteViewGroupBox
                .Name = "PaletteViewGroupBox"
                .Font = New Font("Calibri", 9.75, FontStyle.Bold)
                .Margin = New Padding(3, 3, 3, 3)
                .Padding = New Padding(3, 3, 3, 3)
                .Location = New Point(13, 211)
                .Width = 549
                .Height = 256
                .Text = "Palette View"
            End With
            With LoadPaletteButton
                .Name = "LoadPaletteButton"
                .Font = New Font("Calibri", 9.75, FontStyle.Bold)
                .Margin = New Padding(3, 3, 3, 3)
                .Location = New Point(12, 473)
                .Width = 221
                .Height = 26
                .Text = "Load This Palette In Palette Inserter"
                .Enabled = False
            End With
            AddHandler LoadPaletteButton.Click, AddressOf LoadPaletteButtonClick
            With CancelButton
                .Name = "CancelButton"
                .Font = New Font("Calibri", 9.75, FontStyle.Bold)
                .Margin = New Padding(3, 3, 3, 3)
                .Location = New Point(488, 473)
                .Width = 75
                .Height = 26
                .Text = "Cancel"
            End With
            AddHandler CancelButton.Click, AddressOf CancelButtonClick
            With EditorButton
                .Name = "EditorButton"
                .Font = New Font("Calibri", 9.75, FontStyle.Bold)
                .Margin = New Padding(3, 3, 3, 3)
                .Location = New Point(373, 473)
                .Width = 110
                .Height = 26
                .Text = "Enable Editor"
                .Enabled = Not LoadPaletteFlag
            End With
            AddHandler EditorButton.Click, AddressOf EditorButtonClick
            With PaletteEditorGroupBox
                .Name = "PaletteEditorGroupBox"
                .Font = New Font("Calibri", 9.75, FontStyle.Bold)
                .Margin = New Padding(3, 3, 3, 3)
                .Padding = New Padding(3, 3, 3, 3)
                .Location = New Point(6, 77)
                .Width = 537
                .Height = 172
                .Text = "Palette Editor"
            End With
            With Log
                .Name = "Log"
                .Font = New Font("Calibri", 9.75, FontStyle.Bold)
                .Margin = New Padding(3, 3, 3, 3)
                .Location = New Point(25, 303)
                .Width = 525
                .Height = 120
                .Text = ""
                .ReadOnly = True
                .BackColor = Color.White
            End With
            AddHandler Log.TextChanged, AddressOf LogChange
            With LogBackButton
                .Name = "LogBackButton"
                .Text = "Back"
                .Font = New Font("Calibri", 9.75, FontStyle.Bold)
                .Margin = New Padding(3, 3, 3, 3)
                .Location = New Point(25, 427)
                .Width = 525
                .Height = 26
                .Enabled = False
            End With
            AddHandler LogBackButton.Click, AddressOf LogBackButtonClick
            If IsNothing(MainForm) = False Then
                MainForm.Controls.AddRange({PaletteTableGroupBox, PaletteViewGroupBox, CancelButton, EditorButton, LoadPaletteButton, Log, LogBackButton})
            Else
                If IsNothing(MainPage) = False Then
                    MainPage.Controls.AddRange({PaletteTableGroupBox, PaletteViewGroupBox, CancelButton, EditorButton, LoadPaletteButton, Log, LogBackButton})
                End If
            End If
            If (IsNothing(MainForm) = False) Or (IsNothing(MainPage) = False) Then
                PaletteTableGroupBox.Controls.Add(PaletteTablePanel)
                PaletteViewGroupBox.Controls.AddRange({PaletteNumberLabel, PaletteNumberTextBox, PaletteDataOffsetLabel,
                                                       PaletteDataOffsetTextBox, PaletteHexDataLabel, PaletteHexDataTextBox,
                                                       DeleteButton, SaveChangesButton, PaletteEditorGroupBox})
                LoadPaletteButton.BringToFront()
                PaletteNumberTextBox.BringToFront()
                PaletteDataOffsetTextBox.BringToFront()
                Log.BringToFront()
                LogBackButton.BringToFront()
                Log.Hide()
                LogBackButton.Hide()
                UpdatePaletteTable()
                PaletteViewGroupBox.Enabled = True
                PaletteConvertObject = New PaletteConvert(PaletteConvert.PaletteConvertType.Full,
                                                          PaletteEditorGroupBox,
                                                          PaletteNumberTextBox,
                                                          PaletteHexDataTextBox,
                                                          PaletteLabelColor)
                PaletteConvertObject.PaletteEditing = PaletteEditorFlag
                If LoadPaletteFlag = False Then
                    LoadPaletteButton.Hide()
                    CancelButton.Text = "Done"
                End If
                PaletteTablePanel.Select()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, , "Error")
        End Try
    End Sub
#End Region

#Region "Palette Browser Button Events"

    Public Sub PaletteHexDataTextBoxTextChanged(sender As Object, e As EventArgs)
        PaletteConvertObject.GeneratePaletteBox()
    End Sub

    Public Sub CancelButtonClick(sender As Object, e As EventArgs)
        If IsNothing(MainForm) = False Then
            MainForm.Close()
        End If
    End Sub

    Public Sub LoadPaletteButtonClick(sender As Object, e As EventArgs)
        If PaletteAdder.PaletteConvertObject.TempPaletteData <> PaletteAdder.PaletteHexDataTextBox.Text Then
            Dim Result As Integer = MessageBox.Show("It looks like you have modified pallete in the palette inserter!" & vbCrLf & vbCrLf & "Do you really want to overwrite it with a new palette?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If Result = DialogResult.Yes Then
                PaletteAdder.PaletteHexDataTextBox.Text = PaletteHexDataTextBox.Text
                MainForm.Dispose()
            End If
        Else
            PaletteAdder.PaletteHexDataTextBox.Text = PaletteHexDataTextBox.Text
            MainForm.Dispose()
        End If
    End Sub

    Public Sub EditorButtonClick(sender As Object, e As EventArgs)
        If PaletteEditorFlag = True Then
            EditorButton.Text = "Enable Editor"
            PaletteEditorFlag = False
            PaletteNumberTextBox.ReadOnly = True
            PaletteHexDataTextBox.ReadOnly = True
            PaletteDataOffsetTextBox.ReadOnly = True
            PaletteConvertObject.PaletteEditing = False
            SaveChangesButton.Enabled = False
            DeleteButton.Enabled = False
        Else
            EditorButton.Text = "Disable Editor"
            PaletteEditorFlag = True
            PaletteNumberTextBox.ReadOnly = False
            PaletteHexDataTextBox.ReadOnly = False
            PaletteDataOffsetTextBox.ReadOnly = False
            PaletteConvertObject.PaletteEditing = True
            SaveChangesButton.Enabled = True
            DeleteButton.Enabled = True
        End If
        PaletteConvertObject.GeneratePaletteBox()
    End Sub

    Public Sub DeleteButtonClick(sender As Object, e As EventArgs)
        DeletePalette()
    End Sub

    Public Sub SaveButtonClick(sender As Object, e As EventArgs)
        Dim ChangeFlag As Boolean = False
        If String.Compare(PaletteDataArray(CurrentPaletteRow - 1).PaletteNumber, PaletteNumberTextBox.Text) <> 0 Then
            ChangeFlag = True
        End If
        If String.Compare(PaletteDataArray(CurrentPaletteRow - 1).PaletteDataOffset, PaletteDataOffsetTextBox.Text) <> 0 Then
            ChangeFlag = True
        End If
        If String.Compare(PaletteDataArray(CurrentPaletteRow - 1).PaletteHexData, PaletteHexDataTextBox.Text) <> 0 Then
            ChangeFlag = True
        End If
        If ChangeFlag = True Then
            If (CheckPaletteNumberAvailability(CInt(PaletteNumberTextBox.Text), Main.PaletteTableOffset, Main.PaletteTableEndHex, Main.MaxPalette) = False) _
                And (CInt(PaletteNumberTextBox.Text) <> PaletteDataArray(CurrentPaletteRow - 1).PaletteNumber) Then
                MessageBox.Show("The palette number you provided is already taken! Please provide another valid palette number." & vbCrLf & vbCrLf & "If you want to change palette of this number just open palette browser and choose this pallete to perform alterations on it.", "Palette Number Taken - Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                PaletteNumberTextBox.Select()
            Else
                If String.Compare(PaletteDataArray(CurrentPaletteRow - 1).PaletteDataOffset, PaletteDataOffsetTextBox.Text) <> 0 Then
                    Dim Result As Integer = MessageBox.Show("The palette data offset has been changed! Program will not search or validate for free space, since it's under the impression that you have searched for required free space in the offset provided." & vbCrLf & vbCrLf & "Do you want to proceed?", "Palette Data Offset Changed - Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    If Result = DialogResult.Yes Then
                        PerformProcess()
                    End If
                Else
                    PerformProcess()
                End If
            End If
        Else
            MessageBox.Show("No palette data was changed. Please alter palette data to perform this operation.", "Palette Save Changes - No Changes Detected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub LogChange(sender As Object, e As EventArgs)
        Log.SelectionStart = Log.Text.Length
        Log.ScrollToCaret()
    End Sub

    Private Sub LogBackButtonClick(sender As Object, e As EventArgs)
        LogBackButton.Hide()
        Log.Hide()
        Log.Text = ""
    End Sub

#End Region

#Region "Validation"
    Private Sub ApplyValidations()
        Dim AllTextBoxControls = PaletteViewGroupBox.Controls.OfType(Of TextBox)()
        For Each ControlElement In AllTextBoxControls
            If CStr(ControlElement.Tag) <> "" Then
                AddHandler ControlElement.KeyPress, AddressOf SpaceValidator
                AddHandler ControlElement.Leave, AddressOf NullValidator
                Select Case ControlElement.Name
                    Case "PaletteDataOffsetTextBox"
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
