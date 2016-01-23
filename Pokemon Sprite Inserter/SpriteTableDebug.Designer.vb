<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Sprite_Table_Debug
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Sprite_Table_Debug))
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.StartFromTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CountTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SpritePatchFilePathTextBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GlobalPaletteNumberTextBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SelectionCountTextBox = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.OpenSpritePatchFileButton = New System.Windows.Forms.Button()
        Me.LoadSpritesButton = New System.Windows.Forms.Button()
        Me.DeselectButton = New System.Windows.Forms.Button()
        Me.HowToUseButton = New System.Windows.Forms.Button()
        Me.SpritePatchSaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.RomTextBox = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.White
        Me.FlowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(278, 12)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(937, 503)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'StartFromTextBox
        '
        Me.StartFromTextBox.Location = New System.Drawing.Point(112, 41)
        Me.StartFromTextBox.Name = "StartFromTextBox"
        Me.StartFromTextBox.Size = New System.Drawing.Size(160, 23)
        Me.StartFromTextBox.TabIndex = 2
        Me.StartFromTextBox.Text = "1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Start From :"
        '
        'CountTextBox
        '
        Me.CountTextBox.Location = New System.Drawing.Point(112, 70)
        Me.CountTextBox.Name = "CountTextBox"
        Me.CountTextBox.Size = New System.Drawing.Size(160, 23)
        Me.CountTextBox.TabIndex = 4
        Me.CountTextBox.Text = "152"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(64, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 15)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Count : "
        '
        'SpritePatchFilePathTextBox
        '
        Me.SpritePatchFilePathTextBox.Location = New System.Drawing.Point(112, 99)
        Me.SpritePatchFilePathTextBox.Name = "SpritePatchFilePathTextBox"
        Me.SpritePatchFilePathTextBox.ReadOnly = True
        Me.SpritePatchFilePathTextBox.Size = New System.Drawing.Size(160, 23)
        Me.SpritePatchFilePathTextBox.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 15)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Patch File Path : "
        '
        'GlobalPaletteNumberTextBox
        '
        Me.GlobalPaletteNumberTextBox.Location = New System.Drawing.Point(112, 161)
        Me.GlobalPaletteNumberTextBox.Name = "GlobalPaletteNumberTextBox"
        Me.GlobalPaletteNumberTextBox.Size = New System.Drawing.Size(160, 23)
        Me.GlobalPaletteNumberTextBox.TabIndex = 8
        Me.GlobalPaletteNumberTextBox.Text = "8"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 164)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 15)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Global Palette # :"
        '
        'SelectionCountTextBox
        '
        Me.SelectionCountTextBox.Location = New System.Drawing.Point(112, 190)
        Me.SelectionCountTextBox.Name = "SelectionCountTextBox"
        Me.SelectionCountTextBox.Size = New System.Drawing.Size(160, 23)
        Me.SelectionCountTextBox.TabIndex = 11
        Me.SelectionCountTextBox.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 193)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 15)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Selection Count :"
        '
        'OpenSpritePatchFileButton
        '
        Me.OpenSpritePatchFileButton.Location = New System.Drawing.Point(112, 128)
        Me.OpenSpritePatchFileButton.Name = "OpenSpritePatchFileButton"
        Me.OpenSpritePatchFileButton.Size = New System.Drawing.Size(160, 27)
        Me.OpenSpritePatchFileButton.TabIndex = 13
        Me.OpenSpritePatchFileButton.Text = "Open Sprite Patch File"
        Me.OpenSpritePatchFileButton.UseVisualStyleBackColor = True
        '
        'LoadSpritesButton
        '
        Me.LoadSpritesButton.Enabled = False
        Me.LoadSpritesButton.Location = New System.Drawing.Point(12, 252)
        Me.LoadSpritesButton.Name = "LoadSpritesButton"
        Me.LoadSpritesButton.Size = New System.Drawing.Size(260, 40)
        Me.LoadSpritesButton.TabIndex = 1
        Me.LoadSpritesButton.Text = "Load Sprites"
        Me.LoadSpritesButton.UseVisualStyleBackColor = True
        '
        'DeselectButton
        '
        Me.DeselectButton.Location = New System.Drawing.Point(112, 219)
        Me.DeselectButton.Name = "DeselectButton"
        Me.DeselectButton.Size = New System.Drawing.Size(160, 27)
        Me.DeselectButton.TabIndex = 10
        Me.DeselectButton.Text = "Deselect All"
        Me.DeselectButton.UseVisualStyleBackColor = True
        '
        'HowToUseButton
        '
        Me.HowToUseButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.HowToUseButton.Location = New System.Drawing.Point(12, 475)
        Me.HowToUseButton.Name = "HowToUseButton"
        Me.HowToUseButton.Size = New System.Drawing.Size(260, 40)
        Me.HowToUseButton.TabIndex = 14
        Me.HowToUseButton.Text = "How To Use?"
        Me.HowToUseButton.UseVisualStyleBackColor = True
        '
        'RomTextBox
        '
        Me.RomTextBox.Location = New System.Drawing.Point(112, 12)
        Me.RomTextBox.Name = "RomTextBox"
        Me.RomTextBox.ReadOnly = True
        Me.RomTextBox.Size = New System.Drawing.Size(160, 23)
        Me.RomTextBox.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(72, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 15)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Rom :"
        '
        'Sprite_Table_Debug
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1227, 527)
        Me.Controls.Add(Me.RomTextBox)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.HowToUseButton)
        Me.Controls.Add(Me.OpenSpritePatchFileButton)
        Me.Controls.Add(Me.SelectionCountTextBox)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DeselectButton)
        Me.Controls.Add(Me.GlobalPaletteNumberTextBox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.SpritePatchFilePathTextBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CountTextBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.StartFromTextBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LoadSpritesButton)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Sprite_Table_Debug"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sprite Table Debug"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents StartFromTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CountTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SpritePatchFilePathTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GlobalPaletteNumberTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents SelectionCountTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents OpenSpritePatchFileButton As System.Windows.Forms.Button
    Friend WithEvents LoadSpritesButton As System.Windows.Forms.Button
    Friend WithEvents DeselectButton As System.Windows.Forms.Button
    Friend WithEvents HowToUseButton As System.Windows.Forms.Button
    Friend WithEvents SpritePatchSaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents RomTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
