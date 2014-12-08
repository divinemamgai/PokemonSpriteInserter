Public Class Form2
    Private Sub UseTheseOffsetsButtonClick(sender As Object, e As EventArgs) Handles UseTheseOffsetsButton.Click
        Dim ErrorFlag As Boolean = False
        If String.Compare(SpriteFrameDataOffsetTextBox.Text, "000000") = 0 Then
            MessageBox.Show("Sprite Header Data Offset cannot be zero!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorFlag = True
        End If
        If String.Compare(SpriteHeaderDataOffsetTextBox.Text, "000000") = 0 Then
            MessageBox.Show("Sprite Frame Data Offset cannot be zero!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorFlag = True
        End If
        If String.Compare(SpriteArtDataOffsetTextBox.Text, "000000") = 0 Then
            MessageBox.Show("Sprite Art Data Offset cannot be zero!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorFlag = True
        End If
        If ErrorFlag = False Then
            Form1.GlobalSpriteHeaderDataOffset = SpriteFrameDataOffsetTextBox.Text
            Form1.GlobalSpriteFrameDataOffset = SpriteHeaderDataOffsetTextBox.Text
            Form1.GlobalSpriteArtDataOffset = SpriteArtDataOffsetTextBox.Text
            Me.Close()
        End If
    End Sub

    Private Sub Form2Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SpriteHeaderBytesLabel.Text = "[36 Bytes]"
        SpriteFrameBytesLabel.Text = "[" + CStr(8 * CInt(Form1.NumberOfFramesTextBox.Text)) + " Bytes]"
        SpriteArtByteLabel.Text = "[" + CStr((CInt(Form1.WidthTextBox.Text) * CInt(Form1.HeightTextBox.Text) / 2) * CInt(Form1.NumberOfFramesTextBox.Text)) + " Bytes]"
        If Form1.GlobalSpriteHeaderDataOffset <> "" Then
            SpriteFrameDataOffsetTextBox.Text = Form1.GlobalSpriteHeaderDataOffset
        End If
        If Form1.GlobalSpriteFrameDataOffset <> "" Then
            SpriteHeaderDataOffsetTextBox.Text = Form1.GlobalSpriteHeaderDataOffset
        End If
        If Form1.GlobalSpriteArtDataOffset <> "" Then
            SpriteArtDataOffsetTextBox.Text = Form1.GlobalSpriteArtDataOffset
        End If
    End Sub

#Region "Validation"
    Private Sub ApplyValidations() Handles Me.Load
        Dim AllTextBoxControls = SetSpriteDataOffsetsGroupBox.Controls.OfType(Of TextBox)()
        For Each ControlElement In AllTextBoxControls
            If CStr(ControlElement.Tag) <> "" Then
                AddHandler ControlElement.KeyPress, AddressOf SpaceValidator
                AddHandler ControlElement.Leave, AddressOf NullValidator
                AddHandler ControlElement.Leave, AddressOf OffsetValidator
            End If
        Next
    End Sub
#End Region

End Class