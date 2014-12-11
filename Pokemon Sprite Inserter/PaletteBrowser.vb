﻿Public Class PaletteBrowser

    Public MainForm As Form
    Public MainPage As TabPage
    Public PaletteTableGroupBox As New GroupBox
    Public PaletteTablePanel As New Panel
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
    Public SaveChangesButton As New Button
    Public PaletteEditorGroupBox As New GroupBox
    Public PaletteLabelColor As Color = Color.White

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
            MainForm.Size = New Point(592, 550)
            PaletteBrowserLoad()
        Else
            If IsNothing(DefaultTabPage) = False Then
                MainPage = DefaultTabPage
                MainPage.Size = New Point(592, 600)
                PaletteBrowserLoad()
            End If
        End If
    End Sub

    Public Sub SetLabelProp(ByVal PaletteID As Integer, ByVal BackColor As Color, ByVal UseFont As Font)
        Dim PaletteLabelItems = PaletteTablePanel.Controls.OfType(Of Label)()
        For Each PaletteLabelItem In PaletteLabelItems
            If IsNothing(PaletteLabelItem) = False Then
                If CStr(PaletteLabelItem.Tag) <> "" Then
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
            PaletteViewGroupBox.Enabled = True
            LoadPaletteButton.Enabled = True
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
                If CStr(PaletteLabelItem.Tag) <> "" Then
                    PaletteLabelItem.Cursor = Cursors.Hand
                    AddHandler PaletteLabelItem.MouseEnter, AddressOf PaletteTableLableMouseIn
                    AddHandler PaletteLabelItem.MouseLeave, AddressOf PaletteTableLableMouseOut
                    AddHandler PaletteLabelItem.Click, AddressOf PaletteTableLableMouseClick
                End If
            End If
        Next
    End Sub

    Public Sub UpdatePaletteTable()
        PaletteDataArray = GetPalettes(Main.PaletteTableOffset, Main.PaletteTableEndHex, Main.MaxPalette)
        For i As Integer = 0 To PaletteDataArray.Length - 1
            Dim PaletteIndexLabel As New Label
            With PaletteIndexLabel
                .Width = 30
                .Height = 21
                .Text = PaletteDataArray(i).PaletteIndex
                .Location = New Point(0, 20 * (i + 1))
                .BorderStyle = BorderStyle.FixedSingle
                .Margin = New Padding(0, 0, 0, 0)
                .Padding = New Padding(3, 3, 2, 2)
                .BackColor = ColorTranslator.FromHtml("#eeeeee")
                .Tag = i + 1
                .Font = New Font("Calibri", 9, FontStyle.Regular)
            End With
            PaletteTablePanel.Controls.Add(PaletteIndexLabel)
            Dim PaletteOffsetLabel As New Label
            With PaletteOffsetLabel
                .Width = 120
                .Height = 21
                .Text = PaletteDataArray(i).PaletteOffset
                .Location = New Point(29, 20 * (i + 1))
                .BorderStyle = BorderStyle.FixedSingle
                .Margin = New Padding(0, 0, 0, 0)
                .Padding = New Padding(3, 3, 2, 2)
                .BackColor = ColorTranslator.FromHtml("#eeeeee")
                .Tag = i + 1
                .Font = New Font("Calibri", 9, FontStyle.Regular)
            End With
            PaletteTablePanel.Controls.Add(PaletteOffsetLabel)
            Dim PaletteNumberLabel As New Label
            With PaletteNumberLabel
                .Width = 101
                .Height = 21
                .Text = PaletteDataArray(i).PaletteNumber
                .Location = New Point(148, 20 * (i + 1))
                .BorderStyle = BorderStyle.FixedSingle
                .Margin = New Padding(0, 0, 0, 0)
                .Padding = New Padding(3, 3, 2, 2)
                .BackColor = ColorTranslator.FromHtml("#eeeeee")
                .Tag = i + 1
                .Font = New Font("Calibri", 9, FontStyle.Regular)
            End With
            PaletteTablePanel.Controls.Add(PaletteNumberLabel)
            Dim PaletteDataOffsetLabel As New Label
            With PaletteDataOffsetLabel
                .Width = 120
                .Height = 21
                .Text = PaletteDataArray(i).PaletteDataOffset
                .Location = New Point(248, 20 * (i + 1))
                .BorderStyle = BorderStyle.FixedSingle
                .Margin = New Padding(0, 0, 0, 0)
                .Padding = New Padding(3, 3, 2, 2)
                .BackColor = ColorTranslator.FromHtml("#eeeeee")
                .Tag = i + 1
                .Font = New Font("Calibri", 9, FontStyle.Regular)
            End With
            PaletteTablePanel.Controls.Add(PaletteDataOffsetLabel)
            Dim PaletteHexDataLabel As New Label
            With PaletteHexDataLabel
                .Width = 420
                .Height = 21
                .Text = PaletteDataArray(i).PaletteHexData
                .Location = New Point(367, 20 * (i + 1))
                .BorderStyle = BorderStyle.FixedSingle
                .Margin = New Padding(0, 0, 0, 0)
                .Padding = New Padding(3, 3, 2, 2)
                .BackColor = ColorTranslator.FromHtml("#eeeeee")
                .Tag = i + 1
                .Font = New Font("Calibri", 9, FontStyle.Regular)
            End With
            PaletteTablePanel.Controls.Add(PaletteHexDataLabel)
        Next
        AppendPaletteLabelHanders()
    End Sub

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
                .BorderStyle = BorderStyle.None
                .Font = New Font("Calibri", 9.75, FontStyle.Bold)
                .AutoScroll = True
                .Margin = New Padding(3, 3, 3, 3)
                .Location = New Point(6, 22)
                .Width = 537
                .Height = 163
            End With
            With PaletteTableHeaderIndex
                .Name = "PaletteTableHeaderIndex"
                .Text = "#"
                .Font = New Font("Calibri", 9.75, FontStyle.Bold)
                .BorderStyle = BorderStyle.FixedSingle
                .Padding = New Padding(2, 2, 2, 2)
                .Margin = New Padding(0, 0, 0, 0)
                .Location = New Point(0, 0)
                .Size = New Point(30, 21)
            End With
            With PaletteTableHeaderOffset
                .Name = "PaletteTableHeaderOffset"
                .Text = "Palette Offset"
                .Font = New Font("Calibri", 9.75, FontStyle.Bold)
                .BorderStyle = BorderStyle.FixedSingle
                .Padding = New Padding(2, 2, 2, 2)
                .Margin = New Padding(0, 0, 0, 0)
                .Location = New Point(29, 0)
                .Size = New Point(120, 21)
            End With
            With PaletteTableHeaderNumber
                .Name = "PaletteTableHeaderNumber"
                .Text = "Palette Number"
                .Font = New Font("Calibri", 9.75, FontStyle.Bold)
                .BorderStyle = BorderStyle.FixedSingle
                .Padding = New Padding(2, 2, 2, 2)
                .Margin = New Padding(0, 0, 0, 0)
                .Location = New Point(148, 0)
                .Size = New Point(101, 21)
            End With
            With PaletteTableHeaderDataOffset
                .Name = "PaletteTableHeaderDataOffset"
                .Text = "Palette Data Offset"
                .Font = New Font("Calibri", 9.75, FontStyle.Bold)
                .BorderStyle = BorderStyle.FixedSingle
                .Padding = New Padding(2, 2, 2, 2)
                .Margin = New Padding(0, 0, 0, 0)
                .Location = New Point(248, 0)
                .Size = New Point(120, 21)
            End With
            With PaletteTableHeaderData
                .Name = "PaletteTableHeaderData"
                .Text = "Palette Data"
                .Font = New Font("Calibri", 9.75, FontStyle.Bold)
                .BorderStyle = BorderStyle.FixedSingle
                .Padding = New Padding(2, 2, 2, 2)
                .Margin = New Padding(0, 0, 0, 0)
                .Location = New Point(367, 0)
                .Size = New Point(420, 21)
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
                .Width = 70
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
                .Location = New Point(236, 19)
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
                .Location = New Point(352, 18)
                .Margin = New Padding(3, 3, 3, 3)
                .Width = 83
                .Height = 20
                .AutoSize = False
                .ReadOnly = Not PaletteEditorFlag
            End With
            With SaveChangesButton
                .Name = "SaveChangesButton"
                .Font = New Font("Calibri", 9.75, FontStyle.Bold)
                .Margin = New Padding(3, 3, 3, 3)
                .Padding = New Padding(0, 0, 0, 0)
                .Location = New Point(441, 15)
                .Size = New Point(102, 25)
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
            If IsNothing(MainForm) = False Then
                MainForm.Controls.AddRange({PaletteTableGroupBox, PaletteViewGroupBox, CancelButton, EditorButton, LoadPaletteButton})
            Else
                If IsNothing(MainPage) = False Then
                    MainPage.Controls.AddRange({PaletteTableGroupBox, PaletteViewGroupBox, CancelButton, EditorButton, LoadPaletteButton})
                End If
            End If
            If (IsNothing(MainForm) = False) Or (IsNothing(MainPage) = False) Then
                PaletteTableGroupBox.Controls.Add(PaletteTablePanel)
                PaletteTablePanel.Controls.AddRange({PaletteTableHeaderIndex, PaletteTableHeaderOffset, PaletteTableHeaderNumber, PaletteTableHeaderDataOffset, PaletteTableHeaderData})
                PaletteViewGroupBox.Controls.AddRange({PaletteNumberLabel, PaletteNumberTextBox, PaletteDataOffsetLabel,
                                                       PaletteDataOffsetTextBox, PaletteHexDataLabel, PaletteHexDataTextBox,
                                                       SaveChangesButton, PaletteEditorGroupBox})
                LoadPaletteButton.BringToFront()
                PaletteNumberTextBox.BringToFront()
                PaletteDataOffsetTextBox.BringToFront()
                UpdatePaletteTable()
                PaletteViewGroupBox.Enabled = True
                PaletteConvertObject = New PaletteConvert(PaletteEditorGroupBox,
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
        MainForm.Close()
    End Sub

    Public Sub LoadPaletteButtonClick(sender As Object, e As EventArgs)
        If PaletteAdder.PaletteConvertObject.TempPaletteData <> PaletteAdder.PaletteHexDataTextBox.Text Then
            Dim Result As Integer = MessageBox.Show("It looks like you have modified pallete in the palette inserter!" & vbCrLf & vbCrLf & "Do you really want to overwrite it with a new palette?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If Result = DialogResult.Yes Then
                PaletteAdder.PaletteHexDataTextBox.Text = PaletteHexDataTextBox.Text
                MainForm.Close()
            End If
        Else
            PaletteAdder.PaletteHexDataTextBox.Text = PaletteHexDataTextBox.Text
            MainForm.Close()
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
            PaletteConvertObject.GeneratePaletteBox()
        Else
            EditorButton.Text = "Disable Editor"
            PaletteEditorFlag = True
            PaletteNumberTextBox.ReadOnly = False
            PaletteHexDataTextBox.ReadOnly = False
            PaletteDataOffsetTextBox.ReadOnly = False
            PaletteConvertObject.PaletteEditing = True
            SaveChangesButton.Enabled = True
            PaletteConvertObject.GeneratePaletteBox()
        End If
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

        Else
            MessageBox.Show("No palette data was changed. Please alter palette data to perform this operation.", "Palette Save Changes - No Changes Detected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
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
