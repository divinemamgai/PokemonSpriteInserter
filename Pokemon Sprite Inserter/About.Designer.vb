<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class About
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(About))
        Me.DoneButton = New System.Windows.Forms.Button()
        Me.MyLogo = New System.Windows.Forms.PictureBox()
        Me.AboutGroupBox = New System.Windows.Forms.GroupBox()
        Me.AboutRichTextBox = New System.Windows.Forms.RichTextBox()
        CType(Me.MyLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AboutGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'DoneButton
        '
        Me.DoneButton.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DoneButton.Location = New System.Drawing.Point(12, 227)
        Me.DoneButton.Name = "DoneButton"
        Me.DoneButton.Size = New System.Drawing.Size(401, 29)
        Me.DoneButton.TabIndex = 0
        Me.DoneButton.Text = "Done"
        Me.DoneButton.UseVisualStyleBackColor = True
        '
        'MyLogo
        '
        Me.MyLogo.BackgroundImage = Global.Pokemon_Sprite_Inserter.My.Resources.Resources.main
        Me.MyLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.MyLogo.Location = New System.Drawing.Point(12, 12)
        Me.MyLogo.Name = "MyLogo"
        Me.MyLogo.Size = New System.Drawing.Size(401, 75)
        Me.MyLogo.TabIndex = 1
        Me.MyLogo.TabStop = False
        '
        'AboutGroupBox
        '
        Me.AboutGroupBox.Controls.Add(Me.AboutRichTextBox)
        Me.AboutGroupBox.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AboutGroupBox.Location = New System.Drawing.Point(12, 94)
        Me.AboutGroupBox.Name = "AboutGroupBox"
        Me.AboutGroupBox.Size = New System.Drawing.Size(401, 127)
        Me.AboutGroupBox.TabIndex = 2
        Me.AboutGroupBox.TabStop = False
        Me.AboutGroupBox.Text = "About"
        '
        'AboutRichTextBox
        '
        Me.AboutRichTextBox.BackColor = System.Drawing.SystemColors.Control
        Me.AboutRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.AboutRichTextBox.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.AboutRichTextBox.Location = New System.Drawing.Point(7, 15)
        Me.AboutRichTextBox.Name = "AboutRichTextBox"
        Me.AboutRichTextBox.ReadOnly = True
        Me.AboutRichTextBox.Size = New System.Drawing.Size(388, 106)
        Me.AboutRichTextBox.TabIndex = 0
        Me.AboutRichTextBox.Text = resources.GetString("AboutRichTextBox.Text")
        '
        'About
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(425, 267)
        Me.Controls.Add(Me.AboutGroupBox)
        Me.Controls.Add(Me.MyLogo)
        Me.Controls.Add(Me.DoneButton)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "About"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pokemon Sprite Inserter - About"
        CType(Me.MyLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AboutGroupBox.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DoneButton As System.Windows.Forms.Button
    Friend WithEvents MyLogo As System.Windows.Forms.PictureBox
    Friend WithEvents AboutGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents AboutRichTextBox As System.Windows.Forms.RichTextBox
End Class
