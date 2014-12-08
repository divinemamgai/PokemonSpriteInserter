<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.SetSpriteDataOffsetsGroupBox = New System.Windows.Forms.GroupBox()
        Me.SpriteArtByteLabel = New System.Windows.Forms.Label()
        Me.SpriteFrameBytesLabel = New System.Windows.Forms.Label()
        Me.SpriteHeaderBytesLabel = New System.Windows.Forms.Label()
        Me.SpriteArtDataOffsetTextBox = New System.Windows.Forms.TextBox()
        Me.SpriteArtDataOffsetLabel = New System.Windows.Forms.Label()
        Me.SpriteFrameDataOffsetTextBox = New System.Windows.Forms.TextBox()
        Me.SpriteFrameDataOffsetLabel = New System.Windows.Forms.Label()
        Me.SpriteHeaderDataOffsetTextBox = New System.Windows.Forms.TextBox()
        Me.SpriteHeaderDataOffsetLabel = New System.Windows.Forms.Label()
        Me.UseTheseOffsetsButton = New System.Windows.Forms.Button()
        Me.SetSpriteDataOffsetsGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'SetSpriteDataOffsetsGroupBox
        '
        Me.SetSpriteDataOffsetsGroupBox.Controls.Add(Me.SpriteArtByteLabel)
        Me.SetSpriteDataOffsetsGroupBox.Controls.Add(Me.SpriteFrameBytesLabel)
        Me.SetSpriteDataOffsetsGroupBox.Controls.Add(Me.SpriteHeaderBytesLabel)
        Me.SetSpriteDataOffsetsGroupBox.Controls.Add(Me.SpriteArtDataOffsetTextBox)
        Me.SetSpriteDataOffsetsGroupBox.Controls.Add(Me.SpriteArtDataOffsetLabel)
        Me.SetSpriteDataOffsetsGroupBox.Controls.Add(Me.SpriteFrameDataOffsetTextBox)
        Me.SetSpriteDataOffsetsGroupBox.Controls.Add(Me.SpriteFrameDataOffsetLabel)
        Me.SetSpriteDataOffsetsGroupBox.Controls.Add(Me.SpriteHeaderDataOffsetTextBox)
        Me.SetSpriteDataOffsetsGroupBox.Controls.Add(Me.SpriteHeaderDataOffsetLabel)
        Me.SetSpriteDataOffsetsGroupBox.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SetSpriteDataOffsetsGroupBox.Location = New System.Drawing.Point(13, 13)
        Me.SetSpriteDataOffsetsGroupBox.Name = "SetSpriteDataOffsetsGroupBox"
        Me.SetSpriteDataOffsetsGroupBox.Size = New System.Drawing.Size(353, 112)
        Me.SetSpriteDataOffsetsGroupBox.TabIndex = 0
        Me.SetSpriteDataOffsetsGroupBox.TabStop = False
        Me.SetSpriteDataOffsetsGroupBox.Text = "Set Sprite Data Offsets"
        '
        'SpriteArtByteLabel
        '
        Me.SpriteArtByteLabel.AutoSize = True
        Me.SpriteArtByteLabel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpriteArtByteLabel.Location = New System.Drawing.Point(267, 81)
        Me.SpriteArtByteLabel.Name = "SpriteArtByteLabel"
        Me.SpriteArtByteLabel.Size = New System.Drawing.Size(47, 15)
        Me.SpriteArtByteLabel.TabIndex = 12
        Me.SpriteArtByteLabel.Text = "[ Bytes]"
        '
        'SpriteFrameBytesLabel
        '
        Me.SpriteFrameBytesLabel.AutoSize = True
        Me.SpriteFrameBytesLabel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpriteFrameBytesLabel.Location = New System.Drawing.Point(267, 52)
        Me.SpriteFrameBytesLabel.Name = "SpriteFrameBytesLabel"
        Me.SpriteFrameBytesLabel.Size = New System.Drawing.Size(47, 15)
        Me.SpriteFrameBytesLabel.TabIndex = 11
        Me.SpriteFrameBytesLabel.Text = "[ Bytes]"
        '
        'SpriteHeaderBytesLabel
        '
        Me.SpriteHeaderBytesLabel.AutoSize = True
        Me.SpriteHeaderBytesLabel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpriteHeaderBytesLabel.Location = New System.Drawing.Point(267, 23)
        Me.SpriteHeaderBytesLabel.Name = "SpriteHeaderBytesLabel"
        Me.SpriteHeaderBytesLabel.Size = New System.Drawing.Size(47, 15)
        Me.SpriteHeaderBytesLabel.TabIndex = 10
        Me.SpriteHeaderBytesLabel.Text = "[ Bytes]"
        '
        'SpriteArtDataOffsetTextBox
        '
        Me.SpriteArtDataOffsetTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.SpriteArtDataOffsetTextBox.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpriteArtDataOffsetTextBox.Location = New System.Drawing.Point(135, 78)
        Me.SpriteArtDataOffsetTextBox.MaxLength = 6
        Me.SpriteArtDataOffsetTextBox.Name = "SpriteArtDataOffsetTextBox"
        Me.SpriteArtDataOffsetTextBox.Size = New System.Drawing.Size(126, 23)
        Me.SpriteArtDataOffsetTextBox.TabIndex = 8
        Me.SpriteArtDataOffsetTextBox.Tag = "000000"
        Me.SpriteArtDataOffsetTextBox.Text = "000000"
        '
        'SpriteArtDataOffsetLabel
        '
        Me.SpriteArtDataOffsetLabel.AutoSize = True
        Me.SpriteArtDataOffsetLabel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpriteArtDataOffsetLabel.Location = New System.Drawing.Point(6, 81)
        Me.SpriteArtDataOffsetLabel.Name = "SpriteArtDataOffsetLabel"
        Me.SpriteArtDataOffsetLabel.Size = New System.Drawing.Size(132, 15)
        Me.SpriteArtDataOffsetLabel.TabIndex = 9
        Me.SpriteArtDataOffsetLabel.Text = "Sprite Art Data Offset : "
        '
        'SpriteFrameDataOffsetTextBox
        '
        Me.SpriteFrameDataOffsetTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.SpriteFrameDataOffsetTextBox.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpriteFrameDataOffsetTextBox.Location = New System.Drawing.Point(153, 49)
        Me.SpriteFrameDataOffsetTextBox.MaxLength = 6
        Me.SpriteFrameDataOffsetTextBox.Name = "SpriteFrameDataOffsetTextBox"
        Me.SpriteFrameDataOffsetTextBox.Size = New System.Drawing.Size(108, 23)
        Me.SpriteFrameDataOffsetTextBox.TabIndex = 6
        Me.SpriteFrameDataOffsetTextBox.Tag = "000000"
        Me.SpriteFrameDataOffsetTextBox.Text = "000000"
        '
        'SpriteFrameDataOffsetLabel
        '
        Me.SpriteFrameDataOffsetLabel.AutoSize = True
        Me.SpriteFrameDataOffsetLabel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpriteFrameDataOffsetLabel.Location = New System.Drawing.Point(6, 52)
        Me.SpriteFrameDataOffsetLabel.Name = "SpriteFrameDataOffsetLabel"
        Me.SpriteFrameDataOffsetLabel.Size = New System.Drawing.Size(150, 15)
        Me.SpriteFrameDataOffsetLabel.TabIndex = 7
        Me.SpriteFrameDataOffsetLabel.Text = "Sprite Frame Data Offset : "
        '
        'SpriteHeaderDataOffsetTextBox
        '
        Me.SpriteHeaderDataOffsetTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.SpriteHeaderDataOffsetTextBox.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpriteHeaderDataOffsetTextBox.Location = New System.Drawing.Point(158, 20)
        Me.SpriteHeaderDataOffsetTextBox.MaxLength = 6
        Me.SpriteHeaderDataOffsetTextBox.Name = "SpriteHeaderDataOffsetTextBox"
        Me.SpriteHeaderDataOffsetTextBox.Size = New System.Drawing.Size(103, 23)
        Me.SpriteHeaderDataOffsetTextBox.TabIndex = 4
        Me.SpriteHeaderDataOffsetTextBox.Tag = "000000"
        Me.SpriteHeaderDataOffsetTextBox.Text = "000000"
        '
        'SpriteHeaderDataOffsetLabel
        '
        Me.SpriteHeaderDataOffsetLabel.AutoSize = True
        Me.SpriteHeaderDataOffsetLabel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpriteHeaderDataOffsetLabel.Location = New System.Drawing.Point(6, 23)
        Me.SpriteHeaderDataOffsetLabel.Name = "SpriteHeaderDataOffsetLabel"
        Me.SpriteHeaderDataOffsetLabel.Size = New System.Drawing.Size(155, 15)
        Me.SpriteHeaderDataOffsetLabel.TabIndex = 5
        Me.SpriteHeaderDataOffsetLabel.Text = "Sprite Header Data Offset : "
        '
        'UseTheseOffsetsButton
        '
        Me.UseTheseOffsetsButton.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UseTheseOffsetsButton.Location = New System.Drawing.Point(13, 131)
        Me.UseTheseOffsetsButton.Name = "UseTheseOffsetsButton"
        Me.UseTheseOffsetsButton.Size = New System.Drawing.Size(353, 26)
        Me.UseTheseOffsetsButton.TabIndex = 1
        Me.UseTheseOffsetsButton.Text = "Use These Offsets"
        Me.UseTheseOffsetsButton.UseVisualStyleBackColor = True
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(378, 167)
        Me.Controls.Add(Me.UseTheseOffsetsButton)
        Me.Controls.Add(Me.SetSpriteDataOffsetsGroupBox)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form2"
        Me.Text = "Pokemon Sprite Inserter - Offsets"
        Me.SetSpriteDataOffsetsGroupBox.ResumeLayout(False)
        Me.SetSpriteDataOffsetsGroupBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SetSpriteDataOffsetsGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents UseTheseOffsetsButton As System.Windows.Forms.Button
    Friend WithEvents SpriteHeaderDataOffsetTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SpriteHeaderDataOffsetLabel As System.Windows.Forms.Label
    Friend WithEvents SpriteFrameDataOffsetTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SpriteFrameDataOffsetLabel As System.Windows.Forms.Label
    Friend WithEvents SpriteArtDataOffsetTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SpriteArtDataOffsetLabel As System.Windows.Forms.Label
    Friend WithEvents SpriteArtByteLabel As System.Windows.Forms.Label
    Friend WithEvents SpriteFrameBytesLabel As System.Windows.Forms.Label
    Friend WithEvents SpriteHeaderBytesLabel As System.Windows.Forms.Label
End Class
