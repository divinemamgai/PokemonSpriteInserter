Public Class Form4
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = "Current Preset : " + Form1.CurrentPreset.PresetName
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.CurrentPreset = Form1.SecondaryHero
        Label1.Text = "Current Preset : " + Form1.CurrentPreset.PresetName
        Form1.LoadForm()
        Form1.TextBox2.Text = "16"
        Form1.TextBox2.Tag = "16"
        Form1.TextBox3.Text = "32"
        Form1.TextBox3.Tag = "32"
        Form1.TextBox5.Tag = "9"
        Form1.TextBox5.Tag = "9"
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form1.CurrentPreset = Form1.BikerWithTomahawk
        Label1.Text = "Current Preset : " + Form1.CurrentPreset.PresetName
        Form1.LoadForm()
        Form1.TextBox2.Text = "32"
        Form1.TextBox2.Tag = "32"
        Form1.TextBox3.Text = "32"
        Form1.TextBox3.Tag = "32"
        Form1.TextBox5.Tag = "10"
        Form1.TextBox5.Tag = "10"
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Form1.CurrentPreset = Form1.PrimaryHero
        Label1.Text = "Current Preset : " + Form1.CurrentPreset.PresetName
        Form1.LoadForm()
        Form1.TextBox2.Text = "16"
        Form1.TextBox2.Tag = "16"
        Form1.TextBox3.Text = "32"
        Form1.TextBox3.Tag = "32"
        Form1.TextBox5.Tag = "20"
        Form1.TextBox5.Tag = "20"
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Form1.CurrentPreset = Form1.SmallBoy
        Label1.Text = "Current Preset : " + Form1.CurrentPreset.PresetName
        Form1.LoadForm()
        Form1.TextBox2.Text = "16"
        Form1.TextBox2.Tag = "16"
        Form1.TextBox3.Text = "16"
        Form1.TextBox3.Tag = "16"
        Form1.TextBox5.Tag = "9"
        Form1.TextBox5.Tag = "9"
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Form1.CurrentPreset = Form1.SmallGirl
        Label1.Text = "Current Preset : " + Form1.CurrentPreset.PresetName
        Form1.LoadForm()
        Form1.TextBox2.Text = "16"
        Form1.TextBox2.Tag = "16"
        Form1.TextBox3.Text = "16"
        Form1.TextBox3.Tag = "16"
        Form1.TextBox5.Tag = "10"
        Form1.TextBox5.Tag = "10"
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Form1.CurrentPreset = Form1.BoyWithCap
        Label1.Text = "Current Preset : " + Form1.CurrentPreset.PresetName
        Form1.LoadForm()
        Form1.TextBox2.Text = "16"
        Form1.TextBox2.Tag = "16"
        Form1.TextBox3.Text = "32"
        Form1.TextBox3.Tag = "32"
        Form1.TextBox5.Tag = "10"
        Form1.TextBox5.Tag = "10"
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form1.CurrentPreset = Form1.TreeCut
        Label1.Text = "Current Preset : " + Form1.CurrentPreset.PresetName
        Form1.LoadForm()
        Form1.TextBox2.Text = "16"
        Form1.TextBox2.Tag = "16"
        Form1.TextBox3.Text = "16"
        Form1.TextBox3.Tag = "16"
        Form1.TextBox5.Tag = "4"
        Form1.TextBox5.Tag = "4"
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form1.CurrentPreset = Form1.RockSmash
        Label1.Text = "Current Preset : " + Form1.CurrentPreset.PresetName
        Form1.LoadForm()
        Form1.TextBox2.Text = "16"
        Form1.TextBox2.Tag = "16"
        Form1.TextBox3.Text = "16"
        Form1.TextBox3.Tag = "16"
        Form1.TextBox5.Tag = "4"
        Form1.TextBox5.Tag = "4"
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Form1.CurrentPreset = Form1.RockStrength
        Label1.Text = "Current Preset : " + Form1.CurrentPreset.PresetName
        Form1.LoadForm()
        Form1.TextBox2.Text = "16"
        Form1.TextBox2.Tag = "16"
        Form1.TextBox3.Text = "16"
        Form1.TextBox3.Tag = "16"
        Form1.TextBox5.Tag = "1"
        Form1.TextBox5.Tag = "1"
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Form1.CurrentPreset = Form1.Ship
        Label1.Text = "Current Preset : " + Form1.CurrentPreset.PresetName
        Form1.LoadForm()
        Form1.TextBox2.Text = "64"
        Form1.TextBox2.Tag = "64"
        Form1.TextBox3.Text = "64"
        Form1.TextBox3.Tag = "64"
        Form1.TextBox5.Tag = "9"
        Form1.TextBox5.Tag = "9"
    End Sub
End Class