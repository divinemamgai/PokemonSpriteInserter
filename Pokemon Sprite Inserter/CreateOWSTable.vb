Imports System.IO

Public Class CreateOWSTable

    Private Sub FreeSpaceCheckBoxCheckedChanged(sender As Object, e As EventArgs) Handles FreeSpaceCheckBox.CheckedChanged
        If FreeSpaceCheckBox.Checked = True Then
            StartOffsetTextBox.Enabled = True
            OWSTableOffsetTextBox.Enabled = False
        Else
            StartOffsetTextBox.Enabled = False
            OWSTableOffsetTextBox.Enabled = True
        End If
    End Sub

    Private Sub InsertTableButtonClick(sender As Object, e As EventArgs) Handles InsertTableButton.Click
        Dim ErrorFlag As Boolean = False
        If FreeSpaceCheckBox.Checked = False Then
            If ToDecimal(OWSTableOffsetTextBox.Text) = 0 Then
                ErrorFlag = True
                MessageBox.Show("OWS Table Offset value cannot be zero!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                ErrorFlag = False
            End If
        End If
        If ErrorFlag = False Then
            Log.Enabled = True
            Log.Show()
            BackButton.Enabled = False
            BackButton.Show()
            Dim OWSTableOffset As String = ""
            Dim NumberOfBytes As Integer = CInt(NumberOfSpritesTextBox.Text) * 4
            Log.Text = "Starting OWS Table Insertion Process..."
            If FreeSpaceCheckBox.Checked = True Then
                Log.Text += vbCrLf & "Searching Free Space For New OWS Table [" + CStr(NumberOfBytes) + " Bytes]..."
                OWSTableOffset = SearchFreeSpace(StartOffsetTextBox.Text, NumberOfBytes, Main.FreeSpaceByteValue)
                If String.Compare(OWSTableOffset, "Null") <> 0 Then
                    ErrorFlag = False
                Else
                    ErrorFlag = True
                    BackButton.Enabled = True
                    BackButton.Show()
                    Log.Text += vbCrLf & "   Error Searching For Free Space! Aborting..."
                End If
            Else
                OWSTableOffset = OWSTableOffsetTextBox.Text
                ErrorFlag = False
            End If
            If ErrorFlag = False Then
                Log.Text += vbCrLf & "   Found At Offset => 0x" + OWSTableOffset
                Log.Text += vbCrLf & "Prompting User To Proceed OWS Table Insertion Process..."
                Dim Result As Integer = MessageBox.Show("Do You Want To Proceed With OWS Table Insertion?", "Proceed With OWS Table Insertion?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If Result = DialogResult.Yes Then
                    Log.Text += vbCrLf & "   Proceeding With OWS Table Insertion..."
                    Log.Text += vbCrLf & "Writing " + CStr(NumberOfBytes) + " Bytes To Rom..."
                    If WriteData(OWSTableOffset, NumberOfBytes, OWSTableEmptyByteTextBox.Text, 1) Then
                        Log.Text += vbCrLf & "   Done Writing To Rom!"
                        Log.Text += vbCrLf & "Searching For Free Space In OWS Table List Table At Offset => 0x" + Main.OWSTableListOffset
                        ' Reading OWS Table List Table Pointers From Rom
                        Dim RomFileReadStream As FileStream
                        RomFileReadStream = File.OpenRead(Main.RomFilePath)
                        RomFileReadStream.Seek(ToDecimal(Main.OWSTableListOffset), SeekOrigin.Begin)
                        Dim Flag As Boolean = True
                        Dim OWSTableCount As Integer = 0
                        While Flag = True
                            Dim Data As String = ""
                            Dim Buffer(3) As Byte
                            RomFileReadStream.Read(Buffer, 0, 4)
                            For k As Integer = 0 To Buffer.Length - 1
                                Data += Buffer(k).ToString("X2")
                            Next
                            If String.Compare(Data, Main.OWSTableListEmptyDataHex) = 0 Then
                                ErrorFlag = False
                                Flag = False
                                Exit While
                            Else
                                OWSTableCount += 1
                                If OWSTableCount > Main.OWSTableListMaxTables Then
                                    ErrorFlag = True
                                    MessageBox.Show("OWS table list is full!" & vbCrLf & vbCrLf & "Note : You can increase the max OWS table list limit in settings.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Flag = False
                                    Exit While
                                End If
                            End If
                        End While
                        RomFileReadStream.Close()
                        If ErrorFlag = False Then
                            Dim OWSTableListTableOffset As String = ToHex(ToDecimal(Main.OWSTableListOffset) + OWSTableCount * 4)
                            Log.Text += vbCrLf & "   Found At Offset => 0x" + OWSTableListTableOffset
                            Log.Text += vbCrLf & "Writing Table Pointer To The OWS Table List Table [4 Bytes]..."
                            If WriteData(OWSTableListTableOffset, 4, OffsetToPointer(OWSTableOffset)) = True Then
                                Log.Text += vbCrLf & "Everything Completed Successfully!"
                                BackButton.Enabled = True
                                BackButton.Show()
                            Else
                                BackButton.Enabled = True
                                BackButton.Show()
                                Log.Text += vbCrLf & "   Error Writing To Rom! Aborting..."
                            End If
                        Else
                            BackButton.Enabled = True
                            BackButton.Show()
                            Log.Text += vbCrLf & "   OWS Table List Table Is Full! Aborting..."
                        End If
                    Else
                        BackButton.Enabled = True
                        BackButton.Show()
                        Log.Text += vbCrLf & "   Error Writing To Rom! Aborting..."
                    End If
                Else
                    BackButton.Enabled = True
                    BackButton.Show()
                    Log.Text += vbCrLf & "   Stopped By User! Aborting..."
                End If
            End If
        End If
    End Sub

    Private Sub Form8Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OWSTableEmptyByteTextBox.Text = Main.OWSTableEmptyDataHex.Substring(0, 2)
        OWSTableEmptyByteTextBox.Tag = Main.OWSTableEmptyDataHex.Substring(0, 2)
        NumberOfSpritesTextBox.Text = Main.OWSTableMaxSprites
        NumberOfSpritesTextBox.Tag = Main.OWSTableMaxSprites
        Log.Enabled = False
        Log.Hide()
        BackButton.Enabled = False
        BackButton.Hide()
        StartOffsetTextBox.MaxLength = ToHex(Main.RomLength).Length
        OWSTableOffsetTextBox.MaxLength = ToHex(Main.RomLength).Length
    End Sub

    Private Sub BakcButtonClick(sender As Object, e As EventArgs) Handles BackButton.Click
        Log.Enabled = False
        Log.Hide()
        BackButton.Enabled = False
        BackButton.Hide()
    End Sub

    Private Sub LogTextChange(sender As Object, e As EventArgs) Handles Log.TextChanged
        Log.SelectionStart = Log.Text.Length
        Log.ScrollToCaret()
    End Sub

#Region "Validation"
    Private Sub ApplyValidations() Handles Me.Load
        Dim AllTextBoxControls = CreateEmptyOWSTableGroupBox.Controls.OfType(Of TextBox)()
        For Each ControlElement In AllTextBoxControls
            If CStr(ControlElement.Tag) <> "" Then
                AddHandler ControlElement.KeyPress, AddressOf SpaceValidator
                AddHandler ControlElement.Leave, AddressOf NullValidator
                Select Case ControlElement.Name
                    Case "StartOffsetTextBox", "OWSTableOffsetTextBox"
                        AddHandler ControlElement.Leave, AddressOf OffsetValidator
                    Case "OWSTableEmptyByteTextBox"
                        AddHandler ControlElement.Leave, AddressOf ByteValidator
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