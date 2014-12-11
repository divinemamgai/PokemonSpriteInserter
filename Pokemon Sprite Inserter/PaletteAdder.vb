Imports System.IO

Public Class PaletteAdder

    Public SearchForOffset As Boolean = True
    Public PaletteDataSize As Integer = 32
    Public PaletteDataOffset As String = ""
    Public PaletteConvertObject As PaletteConvert

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
        Log.BringToFront()
        BackButton.Hide()
        BackButton.BringToFront()
        PaletteOffsetTextBox.MaxLength = 6
        FreeSpaceStartTextBox.MaxLength = 6
        PaletteHexDataTextBox.AutoSize = False
        PaletteHexDataTextBox.Height = 20
        PaletteConvertObject = New PaletteConvert(PaletteEditorGroupBox,
                                                  PaletteNumberTextBox,
                                                  PaletteHexDataTextBox)
        PaletteConvertObject.GeneratePaletteBox()
    End Sub

    Private Sub RestoreRom()
        Log.Text += vbCrLf & "Restoring Rom To Original State By Freeing Up Writed Space..."
        If WriteData(PaletteDataOffset, PaletteDataSize, Main.FreeSpaceByteValue, 1) Then
            Log.Text += vbCrLf & "     Done! Rom Restoration Completed."
        Else
            Log.Text += vbCrLf & "     Error In Rom Restoration! Something Went Terribly Wrong..."
        End If
    End Sub

    Private Sub InsertPaletteButtonClick(sender As Object, e As EventArgs) Handles InsertPaletteButton.Click
        If PaletteConvertObject.TempPaletteData <> PaletteHexDataTextBox.Text Then
            Dim Result As Integer = MessageBox.Show("It looks like you have not applied the changes made to the palette!" & vbCrLf & vbCrLf & "Do you want the changes to be applied and proceed to palette insertion process?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If Result = DialogResult.Yes Then
                PaletteHexDataTextBox.Text = ""
                For i As Integer = 0 To 15
                    PaletteHexDataTextBox.Text += PaletteConvertObject.GetPaletteTextBox(i).Text
                Next
                InsertPaletteButtonClick(sender, e)
            End If
        Else
            If CheckPaletteNumberAvailability(CInt(PaletteNumberTextBox.Text), Main.PaletteTableOffset, Main.PaletteTableEndHex, Main.MaxPalette) = False Then
                MessageBox.Show("The palette number you provided is already taken! Please provide another valid palette number." & vbCrLf & vbCrLf & "If you want to change palette of this number just open palette browser and choose this pallete to perform alterations on it.", "Palette Number Taken - Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                PaletteNumberTextBox.Select()
            Else
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
                                If Flag = True Then
                                    If String.Compare(Data, Main.PaletteTableEmptyDataHex) = 0 Then
                                        ErrorFlag = False
                                        Flag = True
                                        Exit While
                                    Else
                                        Log.Text += vbCrLf & "Palette Table Is Full! Aborting..."
                                        MessageBox.Show("Palette table is full! Aborting.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        Flag = False
                                        ErrorFlag = True
                                        Exit While
                                    End If
                                Else
                                    If String.Compare(Data, Main.PaletteTableEndHex) = 0 Then
                                        ErrorFlag = False
                                        Flag = True
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
                                    RestoreRom()
                                    BackButton.Enabled = True
                                End If
                            Else
                                Log.Text += vbCrLf & "     Error Palette Table Is Full! Aborting..."
                                RestoreRom()
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
            End If
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

    Private Sub LoadPaletteButton(sender As Object, e As EventArgs) Handles LoadPalette.Click
        PaletteBrowserForm.Show()
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