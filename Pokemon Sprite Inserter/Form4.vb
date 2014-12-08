Public Class Form4
    Private Sub Form4Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CurrentPresetLabel.Text = "Current Preset : " + Form1.CurrentPreset.PresetName
    End Sub
    Private Sub DoneButtonClick(sender As Object, e As EventArgs) Handles DoneButton.Click
        Me.Close()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.CurrentPreset = Form1.SecondaryHero
        CurrentPresetLabel.Text = "Current Preset : " + Form1.CurrentPreset.PresetName
        Form1.LoadForm()
        Form1.WidthTextBox.Text = "16"
        Form1.WidthTextBox.Tag = "16"
        Form1.HeightTextBox.Text = "32"
        Form1.HeightTextBox.Tag = "32"
        Form1.NumberOfFramesTextBox.Text = "9"
        Form1.NumberOfFramesTextBox.Tag = "9"
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form1.CurrentPreset = Form1.BikerWithTomahawk
        CurrentPresetLabel.Text = "Current Preset : " + Form1.CurrentPreset.PresetName
        Form1.LoadForm()
        Form1.WidthTextBox.Text = "32"
        Form1.WidthTextBox.Tag = "32"
        Form1.HeightTextBox.Text = "32"
        Form1.HeightTextBox.Tag = "32"
        Form1.NumberOfFramesTextBox.Text = "10"
        Form1.NumberOfFramesTextBox.Tag = "10"
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Form1.CurrentPreset = Form1.PrimaryHero
        CurrentPresetLabel.Text = "Current Preset : " + Form1.CurrentPreset.PresetName
        Form1.LoadForm()
        Form1.WidthTextBox.Text = "16"
        Form1.WidthTextBox.Tag = "16"
        Form1.HeightTextBox.Text = "32"
        Form1.HeightTextBox.Tag = "32"
        Form1.NumberOfFramesTextBox.Text = "20"
        Form1.NumberOfFramesTextBox.Tag = "20"
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Form1.CurrentPreset = Form1.SmallBoy
        CurrentPresetLabel.Text = "Current Preset : " + Form1.CurrentPreset.PresetName
        Form1.LoadForm()
        Form1.WidthTextBox.Text = "16"
        Form1.WidthTextBox.Tag = "16"
        Form1.HeightTextBox.Text = "16"
        Form1.HeightTextBox.Tag = "16"
        Form1.NumberOfFramesTextBox.Text = "9"
        Form1.NumberOfFramesTextBox.Tag = "9"
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Form1.CurrentPreset = Form1.SmallGirl
        CurrentPresetLabel.Text = "Current Preset : " + Form1.CurrentPreset.PresetName
        Form1.LoadForm()
        Form1.WidthTextBox.Text = "16"
        Form1.WidthTextBox.Tag = "16"
        Form1.HeightTextBox.Text = "16"
        Form1.HeightTextBox.Tag = "16"
        Form1.NumberOfFramesTextBox.Text = "10"
        Form1.NumberOfFramesTextBox.Tag = "10"
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Form1.CurrentPreset = Form1.BoyWithCap
        CurrentPresetLabel.Text = "Current Preset : " + Form1.CurrentPreset.PresetName
        Form1.LoadForm()
        Form1.WidthTextBox.Text = "16"
        Form1.WidthTextBox.Tag = "16"
        Form1.HeightTextBox.Text = "32"
        Form1.HeightTextBox.Tag = "32"
        Form1.NumberOfFramesTextBox.Text = "10"
        Form1.NumberOfFramesTextBox.Tag = "10"
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form1.CurrentPreset = Form1.TreeCut
        CurrentPresetLabel.Text = "Current Preset : " + Form1.CurrentPreset.PresetName
        Form1.LoadForm()
        Form1.WidthTextBox.Text = "16"
        Form1.WidthTextBox.Tag = "16"
        Form1.HeightTextBox.Text = "16"
        Form1.HeightTextBox.Tag = "16"
        Form1.NumberOfFramesTextBox.Text = "4"
        Form1.NumberOfFramesTextBox.Tag = "4"
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form1.CurrentPreset = Form1.RockSmash
        CurrentPresetLabel.Text = "Current Preset : " + Form1.CurrentPreset.PresetName
        Form1.LoadForm()
        Form1.WidthTextBox.Text = "16"
        Form1.WidthTextBox.Tag = "16"
        Form1.HeightTextBox.Text = "16"
        Form1.HeightTextBox.Tag = "16"
        Form1.NumberOfFramesTextBox.Text = "4"
        Form1.NumberOfFramesTextBox.Tag = "4"
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Form1.CurrentPreset = Form1.RockStrength
        CurrentPresetLabel.Text = "Current Preset : " + Form1.CurrentPreset.PresetName
        Form1.LoadForm()
        Form1.WidthTextBox.Text = "16"
        Form1.WidthTextBox.Tag = "16"
        Form1.HeightTextBox.Text = "16"
        Form1.HeightTextBox.Tag = "16"
        Form1.NumberOfFramesTextBox.Text = "1"
        Form1.NumberOfFramesTextBox.Tag = "1"
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Form1.CurrentPreset = Form1.Ship
        CurrentPresetLabel.Text = "Current Preset : " + Form1.CurrentPreset.PresetName
        Form1.LoadForm()
        Form1.WidthTextBox.Text = "64"
        Form1.WidthTextBox.Tag = "64"
        Form1.HeightTextBox.Text = "64"
        Form1.HeightTextBox.Tag = "64"
        Form1.NumberOfFramesTextBox.Text = "9"
        Form1.NumberOfFramesTextBox.Tag = "9"
    End Sub
End Class