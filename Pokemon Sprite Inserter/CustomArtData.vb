Public Class CustomArtData

    Dim ErrorFlag As Boolean = False
    Dim TotalArtBytes As Integer = (CInt(Main.WidthTextBox.Text) * CInt(Main.HeightTextBox.Text) / 2) * CInt(Main.NumberOfFramesTextBox.Text)

    Private Sub SpriteDataValidator(sender As Object, e As EventArgs) Handles CustomArtRichTextBox.Leave
        Dim RichTextBoxItem As RichTextBox = CType(sender, RichTextBox)
        If RichTextBoxItem.Text <> "" Then
            If RichTextBoxItem.Text.Length <> (TotalArtBytes * 2) Then
                ErrorFlag = True
                RichTextBoxItem.Text = ""
                MessageBox.Show("Custom Sprite Art Data can only be of " + CStr(TotalArtBytes) + " Bytes or " + CStr(TotalArtBytes * 2) + " characters." & vbCrLf & vbCrLf & "Limits are calculated by the values of Width, Height and Number Of Frames provided.", "Custom Art Data - Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                If Not System.Text.RegularExpressions.Regex.IsMatch(RichTextBoxItem.Text, "\A\b[0-9a-fA-F]+\b\Z") Then
                    ErrorFlag = True
                    RichTextBoxItem.Text = ""
                    MessageBox.Show("Enter a valid hexadecimal custom sprite art data value!", "Custom Art Data - Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    ErrorFlag = False
                End If
            End If
        End If
    End Sub

    Private Sub EnableButtonClick(sender As Object, e As EventArgs) Handles EnableButton.Click
        If CustomArtRichTextBox.Text.Length = 0 Then
            ErrorFlag = True
        End If
        If ErrorFlag = False Then
            Main.UseCustomSpriteArtData = True
            Main.CustomSpriteArtData = CustomArtRichTextBox.Text
            Main.LoadForm()
            Me.Close()
        Else
            MessageBox.Show("Please provide a valid Custom Sprite Art Data value.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Form7Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CustomArtRichTextBox.Text = Main.CustomSpriteArtData
        CustomArtDataGroupBox.Text = "Custom Sprite Art Data [" + CStr(TotalArtBytes) + " Bytes Required]"
        If Main.UseCustomSpriteArtData = True Then
            EnableButton.Text = "Change"
            DisableButton.Select()
        Else
            EnableButton.Text = "Enable"
            EnableButton.Select()
        End If
    End Sub

    Private Sub DisableButtonClick(sender As Object, e As EventArgs) Handles DisableButton.Click
        Main.UseCustomSpriteArtData = False
        Main.LoadForm()
        Me.Close()
    End Sub

End Class