Public Class SpritePresets
    Private Sub Form4Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CurrentPresetLabel.Text = "Current Preset : " + Main.CurrentPreset.PresetName
    End Sub
    Private Sub DoneButtonClick(sender As Object, e As EventArgs) Handles DoneButton.Click
        Me.Close()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Main.CurrentPreset = Main.SecondaryHero
        CurrentPresetLabel.Text = "Current Preset : " + Main.CurrentPreset.PresetName
        Main.LoadForm()
        Main.WidthTextBox.Text = "16"
        Main.WidthTextBox.Tag = "16"
        Main.HeightTextBox.Text = "32"
        Main.HeightTextBox.Tag = "32"
        Main.NumberOfFramesTextBox.Text = "9"
        Main.NumberOfFramesTextBox.Tag = "9"
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Main.CurrentPreset = Main.BikerWithTomahawk
        CurrentPresetLabel.Text = "Current Preset : " + Main.CurrentPreset.PresetName
        Main.LoadForm()
        Main.WidthTextBox.Text = "32"
        Main.WidthTextBox.Tag = "32"
        Main.HeightTextBox.Text = "32"
        Main.HeightTextBox.Tag = "32"
        Main.NumberOfFramesTextBox.Text = "10"
        Main.NumberOfFramesTextBox.Tag = "10"
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Main.CurrentPreset = Main.PrimaryHero
        CurrentPresetLabel.Text = "Current Preset : " + Main.CurrentPreset.PresetName
        Main.LoadForm()
        Main.WidthTextBox.Text = "16"
        Main.WidthTextBox.Tag = "16"
        Main.HeightTextBox.Text = "32"
        Main.HeightTextBox.Tag = "32"
        Main.NumberOfFramesTextBox.Text = "20"
        Main.NumberOfFramesTextBox.Tag = "20"
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Main.CurrentPreset = Main.SmallBoy
        CurrentPresetLabel.Text = "Current Preset : " + Main.CurrentPreset.PresetName
        Main.LoadForm()
        Main.WidthTextBox.Text = "16"
        Main.WidthTextBox.Tag = "16"
        Main.HeightTextBox.Text = "16"
        Main.HeightTextBox.Tag = "16"
        Main.NumberOfFramesTextBox.Text = "9"
        Main.NumberOfFramesTextBox.Tag = "9"
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Main.CurrentPreset = Main.SmallGirl
        CurrentPresetLabel.Text = "Current Preset : " + Main.CurrentPreset.PresetName
        Main.LoadForm()
        Main.WidthTextBox.Text = "16"
        Main.WidthTextBox.Tag = "16"
        Main.HeightTextBox.Text = "16"
        Main.HeightTextBox.Tag = "16"
        Main.NumberOfFramesTextBox.Text = "10"
        Main.NumberOfFramesTextBox.Tag = "10"
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Main.CurrentPreset = Main.BoyWithCap
        CurrentPresetLabel.Text = "Current Preset : " + Main.CurrentPreset.PresetName
        Main.LoadForm()
        Main.WidthTextBox.Text = "16"
        Main.WidthTextBox.Tag = "16"
        Main.HeightTextBox.Text = "32"
        Main.HeightTextBox.Tag = "32"
        Main.NumberOfFramesTextBox.Text = "10"
        Main.NumberOfFramesTextBox.Tag = "10"
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Main.CurrentPreset = Main.TreeCut
        CurrentPresetLabel.Text = "Current Preset : " + Main.CurrentPreset.PresetName
        Main.LoadForm()
        Main.WidthTextBox.Text = "16"
        Main.WidthTextBox.Tag = "16"
        Main.HeightTextBox.Text = "16"
        Main.HeightTextBox.Tag = "16"
        Main.NumberOfFramesTextBox.Text = "4"
        Main.NumberOfFramesTextBox.Tag = "4"
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Main.CurrentPreset = Main.RockSmash
        CurrentPresetLabel.Text = "Current Preset : " + Main.CurrentPreset.PresetName
        Main.LoadForm()
        Main.WidthTextBox.Text = "16"
        Main.WidthTextBox.Tag = "16"
        Main.HeightTextBox.Text = "16"
        Main.HeightTextBox.Tag = "16"
        Main.NumberOfFramesTextBox.Text = "4"
        Main.NumberOfFramesTextBox.Tag = "4"
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Main.CurrentPreset = Main.RockStrength
        CurrentPresetLabel.Text = "Current Preset : " + Main.CurrentPreset.PresetName
        Main.LoadForm()
        Main.WidthTextBox.Text = "16"
        Main.WidthTextBox.Tag = "16"
        Main.HeightTextBox.Text = "16"
        Main.HeightTextBox.Tag = "16"
        Main.NumberOfFramesTextBox.Text = "1"
        Main.NumberOfFramesTextBox.Tag = "1"
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Main.CurrentPreset = Main.Ship
        CurrentPresetLabel.Text = "Current Preset : " + Main.CurrentPreset.PresetName
        Main.LoadForm()
        Main.WidthTextBox.Text = "64"
        Main.WidthTextBox.Tag = "64"
        Main.HeightTextBox.Text = "64"
        Main.HeightTextBox.Tag = "64"
        Main.NumberOfFramesTextBox.Text = "9"
        Main.NumberOfFramesTextBox.Tag = "9"
    End Sub
End Class