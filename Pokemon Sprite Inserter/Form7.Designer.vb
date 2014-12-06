<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form7
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form7))
        Me.CustomArtDataGroupBox = New System.Windows.Forms.GroupBox()
        Me.CustomArtRichTextBox = New System.Windows.Forms.RichTextBox()
        Me.EnableButton = New System.Windows.Forms.Button()
        Me.DisableButton = New System.Windows.Forms.Button()
        Me.CustomArtDataGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'CustomArtDataGroupBox
        '
        Me.CustomArtDataGroupBox.Controls.Add(Me.CustomArtRichTextBox)
        Me.CustomArtDataGroupBox.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustomArtDataGroupBox.Location = New System.Drawing.Point(13, 13)
        Me.CustomArtDataGroupBox.Name = "CustomArtDataGroupBox"
        Me.CustomArtDataGroupBox.Size = New System.Drawing.Size(460, 204)
        Me.CustomArtDataGroupBox.TabIndex = 0
        Me.CustomArtDataGroupBox.TabStop = False
        Me.CustomArtDataGroupBox.Text = "Custom Art Data"
        '
        'CustomArtRichTextBox
        '
        Me.CustomArtRichTextBox.Location = New System.Drawing.Point(7, 22)
        Me.CustomArtRichTextBox.Name = "CustomArtRichTextBox"
        Me.CustomArtRichTextBox.Size = New System.Drawing.Size(447, 176)
        Me.CustomArtRichTextBox.TabIndex = 0
        Me.CustomArtRichTextBox.Text = ""
        '
        'EnableButton
        '
        Me.EnableButton.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EnableButton.Location = New System.Drawing.Point(253, 223)
        Me.EnableButton.Name = "EnableButton"
        Me.EnableButton.Size = New System.Drawing.Size(220, 26)
        Me.EnableButton.TabIndex = 1
        Me.EnableButton.Text = "Enable"
        Me.EnableButton.UseVisualStyleBackColor = True
        '
        'DisableButton
        '
        Me.DisableButton.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DisableButton.Location = New System.Drawing.Point(12, 223)
        Me.DisableButton.Name = "DisableButton"
        Me.DisableButton.Size = New System.Drawing.Size(220, 26)
        Me.DisableButton.TabIndex = 2
        Me.DisableButton.Text = "Disable"
        Me.DisableButton.UseVisualStyleBackColor = True
        '
        'Form7
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(485, 261)
        Me.Controls.Add(Me.DisableButton)
        Me.Controls.Add(Me.EnableButton)
        Me.Controls.Add(Me.CustomArtDataGroupBox)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form7"
        Me.Text = "Pokemon Sprite Inserter - Custom Art Data"
        Me.CustomArtDataGroupBox.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CustomArtDataGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents EnableButton As System.Windows.Forms.Button
    Friend WithEvents CustomArtRichTextBox As System.Windows.Forms.RichTextBox
    Friend WithEvents DisableButton As System.Windows.Forms.Button
End Class
