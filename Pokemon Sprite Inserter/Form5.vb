Imports System.IO

Public Class Form5

    Public SearchForOffset As Boolean = True
    Public PaletteDataSize As Integer = 32
    Public PaletteDataOffset As String

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
        PaletteOffsetTextBox.MaxLength = ToHex(Form1.RomLength).Length
        FreeSpaceStartTextBox.MaxLength = ToHex(Form1.RomLength).Length
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
            PaletteDataOffset = SearchFreeSpace(ToDecimal(FreeSpaceStartTextBox.Text), PaletteDataSize, Form1.FreeSpaceByteValue)
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
                    RomFileReadStream = File.OpenRead(Form1.RomFilePath)
                    RomFileReadStream.Seek(ToDecimal(Form1.PaletteTableOffset), SeekOrigin.Begin)
                    Dim Flag As Boolean = False
                    While Flag = False
                        Dim Data As String = ""
                        Dim Buffer(7) As Byte
                        RomFileReadStream.Read(Buffer, 0, 8)
                        For i As Integer = 0 To Buffer.Length - 1
                            Data += Buffer(i).ToString("X2")
                        Next
                        If String.Compare(Data.Substring(0, Form1.PaletteTableEndHex.Length), Form1.PaletteTableEndHex) = 0 Then
                            ErrorFlag = False
                            Flag = True
                            Exit While
                        Else
                            NumberOfPalettes += 1
                            If NumberOfPalettes > Form1.MaxPalette Then
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
                        Dim PaletteOffset As String = ToHex(ToDecimal(Form1.PaletteTableOffset) + NumberOfPalettes * 8)
                        Log.Text += vbCrLf & "     Found At Offset => 0x" + PaletteOffset
                        Log.Text += vbCrLf & "Generating Palette Header Data..."
                        Dim PaletteData As String = OffsetToPointer(PaletteDataOffset)
                        If ToHex(CInt(PaletteNumberTextBox.Text)).Length = 1 Then
                            PaletteData += "0"
                        End If
                        PaletteData += ToHex(CInt(PaletteNumberTextBox.Text))
                        PaletteData += "110000"
                        PaletteData += Form1.PaletteTableEndHex
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
                    Case "PaletteHexDataTextBox"
                        AddHandler ControlElement.Leave, AddressOf HexValueValidator
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