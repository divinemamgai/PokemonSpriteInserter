Public Class FreeSpaceOffsetsDialog
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
            Main.GlobalSpriteHeaderDataOffset = SpriteFrameDataOffsetTextBox.Text
            Main.GlobalSpriteFrameDataOffset = SpriteHeaderDataOffsetTextBox.Text
            Main.GlobalSpriteArtDataOffset = SpriteArtDataOffsetTextBox.Text
            Me.Close()
        End If
    End Sub

    Private Sub Form2Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SpriteHeaderBytesLabel.Text = "[36 Bytes]"
        SpriteFrameBytesLabel.Text = "[" + CStr(8 * CInt(Main.NumberOfFramesTextBox.Text)) + " Bytes]"
        SpriteArtByteLabel.Text = "[" + CStr((CInt(Main.WidthTextBox.Text) * CInt(Main.HeightTextBox.Text) / 2) * CInt(Main.NumberOfFramesTextBox.Text)) + " Bytes]"
        If Main.GlobalSpriteHeaderDataOffset <> "" Then
            SpriteFrameDataOffsetTextBox.Text = Main.GlobalSpriteHeaderDataOffset
        End If
        If Main.GlobalSpriteFrameDataOffset <> "" Then
            SpriteHeaderDataOffsetTextBox.Text = Main.GlobalSpriteHeaderDataOffset
        End If
        If Main.GlobalSpriteArtDataOffset <> "" Then
            SpriteArtDataOffsetTextBox.Text = Main.GlobalSpriteArtDataOffset
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
                AddHandler ControlElement.KeyPress, AddressOf HexInputValidator
            End If
        Next
    End Sub
#End Region

End Class