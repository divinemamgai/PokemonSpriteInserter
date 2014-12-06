Imports System.IO

Public Class Form8

    Private Sub FreeSpaceCheckBoxCheckedChanged(sender As Object, e As EventArgs) Handles FreeSpaceCheckBox.CheckedChanged
        If FreeSpaceCheckBox.Checked = True Then
            StartOffsetTextBox.Enabled = True
            OWSTableOffsetTextBox.Enabled = False
        Else
            StartOffsetTextBox.Enabled = False
            OWSTableOffsetTextBox.Enabled = True
        End If
    End Sub

    Private Sub TextBoxDigitValidator(sender As Object, e As KeyPressEventArgs) Handles NumberOfSpritesTextBox.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If
    End Sub

    Private Sub SpaceValidator(sender As Object, e As KeyPressEventArgs) Handles NumberOfSpritesTextBox.KeyPress, OWSTableEmptyByteTextBox.KeyPress, OWSTableOffsetTextBox.KeyPress, StartOffsetTextBox.KeyPress
        If Asc(e.KeyChar) = Keys.Space Then
            e.Handled = True
        End If
    End Sub

    Private Sub ByteValidator(sender As Object, e As EventArgs) Handles OWSTableEmptyByteTextBox.Leave
        Dim TextBoxItem As TextBox = CType(sender, TextBox)
        If TextBoxItem.Text <> "" Then
            If TextBoxItem.Text.Length <> 2 Then
                TextBoxItem.Text = TextBoxItem.Tag
                MessageBox.Show("Byte value can only be of 2 characters!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                If Not System.Text.RegularExpressions.Regex.IsMatch(TextBoxItem.Text, "\A\b[0-9a-fA-F]+\b\Z") Then
                    TextBoxItem.Text = TextBoxItem.Tag
                    MessageBox.Show("Enter a valid hexadecimal byte value!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Else
            TextBoxItem.Text = TextBoxItem.Tag
            MessageBox.Show("Byte value cannot be empty!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub OffsetValidator(sender As Object, e As EventArgs) Handles OWSTableOffsetTextBox.Leave, StartOffsetTextBox.Leave
        Dim TextBoxItem As TextBox = CType(sender, TextBox)
        If TextBoxItem.Text <> "" Then
            If TextBoxItem.Text.Length <> 6 Then
                TextBoxItem.Text = TextBoxItem.Tag
                MessageBox.Show("Offset value can only be of 6 characters.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                If Not System.Text.RegularExpressions.Regex.IsMatch(TextBoxItem.Text, "\A\b[0-9a-fA-F]+\b\Z") Then
                    TextBoxItem.Text = TextBoxItem.Tag
                    MessageBox.Show("Enter a valid hexadecimal offset value!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Else
            TextBoxItem.Text = TextBoxItem.Tag
            MessageBox.Show("Offset value cannot be empty!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub LimitValidator(sender As Object, e As EventArgs) Handles NumberOfSpritesTextBox.TextChanged
        Dim TextBoxItem As TextBox = CType(sender, TextBox)
        If TextBoxItem.Text <> "" Then
            Dim TextBoxValue = Integer.Parse(TextBoxItem.Text)
            If TextBoxValue > 255 Then
                TextBoxItem.Text = TextBoxItem.Tag
                MessageBox.Show("Max Limit is 255!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                If TextBoxValue = 0 Then
                    TextBoxItem.Text = TextBoxItem.Tag
                    MessageBox.Show("Value cannot be zero!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Else
            TextBoxItem.Text = TextBoxItem.Tag
            MessageBox.Show("Value cannot be empty!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub SkipByteMaxLimitValidator(sender As Object, e As EventArgs)
        Dim TextBoxItem As TextBox = CType(sender, TextBox)
        If Form1.RomFileLoaded = True Then
            If TextBoxItem.Text <> "" Then
                Dim TextBoxValue = Integer.Parse(TextBoxItem.Text)
                If TextBoxValue > (Form1.RomLength / 2) Then
                    TextBoxItem.Text = TextBoxItem.Tag
                    MessageBox.Show("Max Limit is " + CStr(Form1.RomLength / 2) + "!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub

    Private Sub InsertTableButton_Click(sender As Object, e As EventArgs) Handles InsertTableButton.Click
        Dim ErrorFlag As Boolean = False
        If FreeSpaceCheckBox.Checked = False Then
            If Form1.ToDecimal(OWSTableOffsetTextBox.Text) = 0 Then
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
                OWSTableOffset = Form1.SearchFreeSpace(StartOffsetTextBox.Text, NumberOfBytes, Form1.FreeSpaceByteValue)
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
                Dim Result As Integer = MessageBox.Show("Do you want to proceed with OWS Table Insertion?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If Result = DialogResult.Yes Then
                    Log.Text += vbCrLf & "   Proceeding With OWS Table Insertion..."
                    Log.Text += vbCrLf & "Writing " + CStr(NumberOfBytes) + " Bytes To Rom..."
                    If Form1.WriteData(OWSTableOffset, NumberOfBytes, OWSTableEmptyByteTextBox.Text, 1) Then
                        Log.Text += vbCrLf & "   Done Writing To Rom!"
                        Log.Text += vbCrLf & "Searching For Free Space In OWS Table List Table At Offset => 0x" + Form1.OWSTableListOffset
                        ' Reading OWS Table List Table Pointers From Rom
                        Dim RomFileReadStream As FileStream
                        RomFileReadStream = File.OpenRead(Form1.RomFilePath)
                        RomFileReadStream.Seek(Form1.ToDecimal(Form1.OWSTableListOffset), SeekOrigin.Begin)
                        Dim Flag As Boolean = True
                        Dim OWSTableCount As Integer = 0
                        While Flag = True
                            Dim Data As String = ""
                            Dim Buffer(3) As Byte
                            RomFileReadStream.Read(Buffer, 0, 4)
                            For k As Integer = 0 To Buffer.Length - 1
                                Data += Buffer(k).ToString("X2")
                            Next
                            If String.Compare(Data, Form1.OWSTableListEmptyDataHex) = 0 Then
                                ErrorFlag = False
                                Flag = False
                                Exit While
                            Else
                                OWSTableCount += 1
                                If OWSTableCount > Form1.OWSTableListMaxTables Then
                                    ErrorFlag = True
                                    MessageBox.Show("OWS Table List Table is Full!" & vbCrLf & vbCrLf & "If you want to proceed anyway then increase the OWS Table List Max Tables value in Settings.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Flag = False
                                    Exit While
                                End If
                            End If
                        End While
                        RomFileReadStream.Close()
                        If ErrorFlag = False Then
                            Dim OWSTableListTableOffset As String = Form1.ToHex(Form1.ToDecimal(Form1.OWSTableListOffset) + OWSTableCount * 4)
                            Log.Text += vbCrLf & "   Found At Offset => 0x" + OWSTableListTableOffset
                            Log.Text += vbCrLf & "Writing Table Pointer To The OWS Table List Table [4 Bytes]..."
                            If Form1.WriteData(OWSTableListTableOffset, 4, Form1.OffsetToPointer(OWSTableOffset)) = True Then
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

    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Log.Enabled = False
        Log.Hide()
        BackButton.Enabled = False
        BackButton.Hide()
    End Sub

    Private Sub BackButton_Click(sender As Object, e As EventArgs) Handles BackButton.Click
        Log.Enabled = False
        Log.Hide()
        BackButton.Enabled = False
        BackButton.Hide()
    End Sub

    Private Sub LogChange(sender As Object, e As EventArgs) Handles Log.TextChanged
        Log.SelectionStart = Log.Text.Length
        Log.ScrollToCaret()
    End Sub

End Class