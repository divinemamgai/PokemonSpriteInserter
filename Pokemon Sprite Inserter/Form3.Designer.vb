<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form3))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PaletteTableEndTextBox = New System.Windows.Forms.TextBox()
        Me.PaletteTableEndLabel = New System.Windows.Forms.Label()
        Me.MaxPaletteTextBox = New System.Windows.Forms.TextBox()
        Me.MaxPaletteLabel = New System.Windows.Forms.Label()
        Me.PaletteTableOffsetTextBox = New System.Windows.Forms.TextBox()
        Me.PaletteTableOffsetLabel = New System.Windows.Forms.Label()
        Me.RomCheckButton = New System.Windows.Forms.Button()
        Me.SpriteArtDataByteTextBox = New System.Windows.Forms.TextBox()
        Me.DefaultButton = New System.Windows.Forms.Button()
        Me.TableMaxSpritesTextBox = New System.Windows.Forms.TextBox()
        Me.TableMaxSpritesLabel = New System.Windows.Forms.Label()
        Me.TableListMaxTextBox = New System.Windows.Forms.TextBox()
        Me.TableListMaxLabel = New System.Windows.Forms.Label()
        Me.TableEmptyDataTextBox = New System.Windows.Forms.TextBox()
        Me.TableEmptyDataLabel = New System.Windows.Forms.Label()
        Me.TableListEmptyDataTextBox = New System.Windows.Forms.TextBox()
        Me.TableListEmptyDataLabel = New System.Windows.Forms.Label()
        Me.FreeSpaceByteTextBox = New System.Windows.Forms.TextBox()
        Me.OWSTableListOffsetTextBox = New System.Windows.Forms.TextBox()
        Me.OWSTableListOffsetLabel = New System.Windows.Forms.Label()
        Me.SpriteArtDataByteLabel = New System.Windows.Forms.Label()
        Me.FreeSpaceByteLabel = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PaletteTableEndTextBox)
        Me.GroupBox1.Controls.Add(Me.PaletteTableEndLabel)
        Me.GroupBox1.Controls.Add(Me.MaxPaletteTextBox)
        Me.GroupBox1.Controls.Add(Me.MaxPaletteLabel)
        Me.GroupBox1.Controls.Add(Me.PaletteTableOffsetTextBox)
        Me.GroupBox1.Controls.Add(Me.PaletteTableOffsetLabel)
        Me.GroupBox1.Controls.Add(Me.RomCheckButton)
        Me.GroupBox1.Controls.Add(Me.SpriteArtDataByteTextBox)
        Me.GroupBox1.Controls.Add(Me.DefaultButton)
        Me.GroupBox1.Controls.Add(Me.TableMaxSpritesTextBox)
        Me.GroupBox1.Controls.Add(Me.TableMaxSpritesLabel)
        Me.GroupBox1.Controls.Add(Me.TableListMaxTextBox)
        Me.GroupBox1.Controls.Add(Me.TableListMaxLabel)
        Me.GroupBox1.Controls.Add(Me.TableEmptyDataTextBox)
        Me.GroupBox1.Controls.Add(Me.TableEmptyDataLabel)
        Me.GroupBox1.Controls.Add(Me.TableListEmptyDataTextBox)
        Me.GroupBox1.Controls.Add(Me.TableListEmptyDataLabel)
        Me.GroupBox1.Controls.Add(Me.FreeSpaceByteTextBox)
        Me.GroupBox1.Controls.Add(Me.OWSTableListOffsetTextBox)
        Me.GroupBox1.Controls.Add(Me.OWSTableListOffsetLabel)
        Me.GroupBox1.Controls.Add(Me.SpriteArtDataByteLabel)
        Me.GroupBox1.Controls.Add(Me.FreeSpaceByteLabel)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(356, 315)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Set Sprite Data Offsets"
        '
        'PaletteTableEndTextBox
        '
        Me.PaletteTableEndTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.PaletteTableEndTextBox.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PaletteTableEndTextBox.Location = New System.Drawing.Point(135, 281)
        Me.PaletteTableEndTextBox.MaxLength = 12
        Me.PaletteTableEndTextBox.Name = "PaletteTableEndTextBox"
        Me.PaletteTableEndTextBox.Size = New System.Drawing.Size(126, 23)
        Me.PaletteTableEndTextBox.TabIndex = 26
        Me.PaletteTableEndTextBox.Tag = "00000000FF11"
        Me.PaletteTableEndTextBox.Text = "00000000FF11"
        '
        'PaletteTableEndLabel
        '
        Me.PaletteTableEndLabel.AutoSize = True
        Me.PaletteTableEndLabel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PaletteTableEndLabel.Location = New System.Drawing.Point(6, 284)
        Me.PaletteTableEndLabel.Name = "PaletteTableEndLabel"
        Me.PaletteTableEndLabel.Size = New System.Drawing.Size(129, 15)
        Me.PaletteTableEndLabel.TabIndex = 27
        Me.PaletteTableEndLabel.Text = "Palette Table End Hex :"
        '
        'MaxPaletteTextBox
        '
        Me.MaxPaletteTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.MaxPaletteTextBox.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaxPaletteTextBox.Location = New System.Drawing.Point(84, 252)
        Me.MaxPaletteTextBox.MaxLength = 3
        Me.MaxPaletteTextBox.Name = "MaxPaletteTextBox"
        Me.MaxPaletteTextBox.Size = New System.Drawing.Size(126, 23)
        Me.MaxPaletteTextBox.TabIndex = 24
        Me.MaxPaletteTextBox.Tag = "100"
        Me.MaxPaletteTextBox.Text = "100"
        '
        'MaxPaletteLabel
        '
        Me.MaxPaletteLabel.AutoSize = True
        Me.MaxPaletteLabel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaxPaletteLabel.Location = New System.Drawing.Point(6, 255)
        Me.MaxPaletteLabel.Name = "MaxPaletteLabel"
        Me.MaxPaletteLabel.Size = New System.Drawing.Size(78, 15)
        Me.MaxPaletteLabel.TabIndex = 25
        Me.MaxPaletteLabel.Text = "Max Palette :"
        '
        'PaletteTableOffsetTextBox
        '
        Me.PaletteTableOffsetTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.PaletteTableOffsetTextBox.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PaletteTableOffsetTextBox.Location = New System.Drawing.Point(125, 223)
        Me.PaletteTableOffsetTextBox.MaxLength = 6
        Me.PaletteTableOffsetTextBox.Name = "PaletteTableOffsetTextBox"
        Me.PaletteTableOffsetTextBox.Size = New System.Drawing.Size(126, 23)
        Me.PaletteTableOffsetTextBox.TabIndex = 22
        Me.PaletteTableOffsetTextBox.Tag = "1A2400"
        Me.PaletteTableOffsetTextBox.Text = "1A2400"
        '
        'PaletteTableOffsetLabel
        '
        Me.PaletteTableOffsetLabel.AutoSize = True
        Me.PaletteTableOffsetLabel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PaletteTableOffsetLabel.Location = New System.Drawing.Point(6, 226)
        Me.PaletteTableOffsetLabel.Name = "PaletteTableOffsetLabel"
        Me.PaletteTableOffsetLabel.Size = New System.Drawing.Size(119, 15)
        Me.PaletteTableOffsetLabel.TabIndex = 23
        Me.PaletteTableOffsetLabel.Text = "Palette Table Offset :"
        '
        'RomCheckButton
        '
        Me.RomCheckButton.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RomCheckButton.Location = New System.Drawing.Point(239, 46)
        Me.RomCheckButton.Name = "RomCheckButton"
        Me.RomCheckButton.Size = New System.Drawing.Size(108, 26)
        Me.RomCheckButton.TabIndex = 21
        Me.RomCheckButton.Text = "Rom Check - On"
        Me.RomCheckButton.UseVisualStyleBackColor = True
        '
        'SpriteArtDataByteTextBox
        '
        Me.SpriteArtDataByteTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.SpriteArtDataByteTextBox.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpriteArtDataByteTextBox.Location = New System.Drawing.Point(125, 49)
        Me.SpriteArtDataByteTextBox.MaxLength = 2
        Me.SpriteArtDataByteTextBox.Name = "SpriteArtDataByteTextBox"
        Me.SpriteArtDataByteTextBox.Size = New System.Drawing.Size(53, 23)
        Me.SpriteArtDataByteTextBox.TabIndex = 4
        Me.SpriteArtDataByteTextBox.Tag = "BB"
        Me.SpriteArtDataByteTextBox.Text = "BB"
        '
        'DefaultButton
        '
        Me.DefaultButton.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DefaultButton.Location = New System.Drawing.Point(267, 17)
        Me.DefaultButton.Name = "DefaultButton"
        Me.DefaultButton.Size = New System.Drawing.Size(80, 26)
        Me.DefaultButton.TabIndex = 20
        Me.DefaultButton.Text = "Default"
        Me.DefaultButton.UseVisualStyleBackColor = True
        '
        'TableMaxSpritesTextBox
        '
        Me.TableMaxSpritesTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TableMaxSpritesTextBox.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableMaxSpritesTextBox.Location = New System.Drawing.Point(147, 194)
        Me.TableMaxSpritesTextBox.MaxLength = 3
        Me.TableMaxSpritesTextBox.Name = "TableMaxSpritesTextBox"
        Me.TableMaxSpritesTextBox.Size = New System.Drawing.Size(126, 23)
        Me.TableMaxSpritesTextBox.TabIndex = 17
        Me.TableMaxSpritesTextBox.Tag = "152"
        Me.TableMaxSpritesTextBox.Text = "152"
        '
        'TableMaxSpritesLabel
        '
        Me.TableMaxSpritesLabel.AutoSize = True
        Me.TableMaxSpritesLabel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableMaxSpritesLabel.Location = New System.Drawing.Point(6, 197)
        Me.TableMaxSpritesLabel.Name = "TableMaxSpritesLabel"
        Me.TableMaxSpritesLabel.Size = New System.Drawing.Size(140, 15)
        Me.TableMaxSpritesLabel.TabIndex = 18
        Me.TableMaxSpritesLabel.Text = "OWS Table Max Sprites :"
        '
        'TableListMaxTextBox
        '
        Me.TableListMaxTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TableListMaxTextBox.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableListMaxTextBox.Location = New System.Drawing.Point(167, 165)
        Me.TableListMaxTextBox.MaxLength = 3
        Me.TableListMaxTextBox.Name = "TableListMaxTextBox"
        Me.TableListMaxTextBox.Size = New System.Drawing.Size(126, 23)
        Me.TableListMaxTextBox.TabIndex = 15
        Me.TableListMaxTextBox.Tag = "100"
        Me.TableListMaxTextBox.Text = "100"
        '
        'TableListMaxLabel
        '
        Me.TableListMaxLabel.AutoSize = True
        Me.TableListMaxLabel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableListMaxLabel.Location = New System.Drawing.Point(6, 168)
        Me.TableListMaxLabel.Name = "TableListMaxLabel"
        Me.TableListMaxLabel.Size = New System.Drawing.Size(159, 15)
        Me.TableListMaxLabel.TabIndex = 16
        Me.TableListMaxLabel.Text = "OWS Table List Max Tables :"
        '
        'TableEmptyDataTextBox
        '
        Me.TableEmptyDataTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TableEmptyDataTextBox.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableEmptyDataTextBox.Location = New System.Drawing.Point(167, 136)
        Me.TableEmptyDataTextBox.MaxLength = 8
        Me.TableEmptyDataTextBox.Name = "TableEmptyDataTextBox"
        Me.TableEmptyDataTextBox.Size = New System.Drawing.Size(126, 23)
        Me.TableEmptyDataTextBox.TabIndex = 13
        Me.TableEmptyDataTextBox.Tag = "00000000"
        Me.TableEmptyDataTextBox.Text = "00000000"
        '
        'TableEmptyDataLabel
        '
        Me.TableEmptyDataLabel.AutoSize = True
        Me.TableEmptyDataLabel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableEmptyDataLabel.Location = New System.Drawing.Point(6, 139)
        Me.TableEmptyDataLabel.Name = "TableEmptyDataLabel"
        Me.TableEmptyDataLabel.Size = New System.Drawing.Size(160, 15)
        Me.TableEmptyDataLabel.TabIndex = 14
        Me.TableEmptyDataLabel.Text = "OWS Table Empty Data Hex :"
        '
        'TableListEmptyDataTextBox
        '
        Me.TableListEmptyDataTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TableListEmptyDataTextBox.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableListEmptyDataTextBox.Location = New System.Drawing.Point(188, 107)
        Me.TableListEmptyDataTextBox.MaxLength = 8
        Me.TableListEmptyDataTextBox.Name = "TableListEmptyDataTextBox"
        Me.TableListEmptyDataTextBox.Size = New System.Drawing.Size(126, 23)
        Me.TableListEmptyDataTextBox.TabIndex = 11
        Me.TableListEmptyDataTextBox.Tag = "00000000"
        Me.TableListEmptyDataTextBox.Text = "00000000"
        '
        'TableListEmptyDataLabel
        '
        Me.TableListEmptyDataLabel.AutoSize = True
        Me.TableListEmptyDataLabel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableListEmptyDataLabel.Location = New System.Drawing.Point(6, 110)
        Me.TableListEmptyDataLabel.Name = "TableListEmptyDataLabel"
        Me.TableListEmptyDataLabel.Size = New System.Drawing.Size(182, 15)
        Me.TableListEmptyDataLabel.TabIndex = 12
        Me.TableListEmptyDataLabel.Text = "OWS Table List Empty Data Hex :"
        '
        'FreeSpaceByteTextBox
        '
        Me.FreeSpaceByteTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.FreeSpaceByteTextBox.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FreeSpaceByteTextBox.Location = New System.Drawing.Point(103, 20)
        Me.FreeSpaceByteTextBox.MaxLength = 2
        Me.FreeSpaceByteTextBox.Name = "FreeSpaceByteTextBox"
        Me.FreeSpaceByteTextBox.Size = New System.Drawing.Size(53, 23)
        Me.FreeSpaceByteTextBox.TabIndex = 10
        Me.FreeSpaceByteTextBox.Tag = "FF"
        Me.FreeSpaceByteTextBox.Text = "FF"
        '
        'OWSTableListOffsetTextBox
        '
        Me.OWSTableListOffsetTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.OWSTableListOffsetTextBox.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OWSTableListOffsetTextBox.Location = New System.Drawing.Point(136, 78)
        Me.OWSTableListOffsetTextBox.MaxLength = 6
        Me.OWSTableListOffsetTextBox.Name = "OWSTableListOffsetTextBox"
        Me.OWSTableListOffsetTextBox.Size = New System.Drawing.Size(126, 23)
        Me.OWSTableListOffsetTextBox.TabIndex = 8
        Me.OWSTableListOffsetTextBox.Tag = "1A2000"
        Me.OWSTableListOffsetTextBox.Text = "1A2000"
        '
        'OWSTableListOffsetLabel
        '
        Me.OWSTableListOffsetLabel.AutoSize = True
        Me.OWSTableListOffsetLabel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OWSTableListOffsetLabel.Location = New System.Drawing.Point(6, 81)
        Me.OWSTableListOffsetLabel.Name = "OWSTableListOffsetLabel"
        Me.OWSTableListOffsetLabel.Size = New System.Drawing.Size(130, 15)
        Me.OWSTableListOffsetLabel.TabIndex = 9
        Me.OWSTableListOffsetLabel.Text = "OWS Table List Offset :"
        '
        'SpriteArtDataByteLabel
        '
        Me.SpriteArtDataByteLabel.AutoSize = True
        Me.SpriteArtDataByteLabel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpriteArtDataByteLabel.Location = New System.Drawing.Point(6, 52)
        Me.SpriteArtDataByteLabel.Name = "SpriteArtDataByteLabel"
        Me.SpriteArtDataByteLabel.Size = New System.Drawing.Size(122, 15)
        Me.SpriteArtDataByteLabel.TabIndex = 7
        Me.SpriteArtDataByteLabel.Text = "Sprite Art Data Byte : "
        '
        'FreeSpaceByteLabel
        '
        Me.FreeSpaceByteLabel.AutoSize = True
        Me.FreeSpaceByteLabel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FreeSpaceByteLabel.Location = New System.Drawing.Point(6, 23)
        Me.FreeSpaceByteLabel.Name = "FreeSpaceByteLabel"
        Me.FreeSpaceByteLabel.Size = New System.Drawing.Size(97, 15)
        Me.FreeSpaceByteLabel.TabIndex = 5
        Me.FreeSpaceByteLabel.Text = "Free Space Byte :"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(12, 333)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(356, 29)
        Me.Button1.TabIndex = 19
        Me.Button1.Text = "Save Settings"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(380, 373)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form3"
        Me.Text = "Pokemon Sprite Inserter - Settings"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents OWSTableListOffsetTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OWSTableListOffsetLabel As System.Windows.Forms.Label
    Friend WithEvents SpriteArtDataByteLabel As System.Windows.Forms.Label
    Friend WithEvents SpriteArtDataByteTextBox As System.Windows.Forms.TextBox
    Friend WithEvents FreeSpaceByteLabel As System.Windows.Forms.Label
    Friend WithEvents FreeSpaceByteTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TableListEmptyDataTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TableListEmptyDataLabel As System.Windows.Forms.Label
    Friend WithEvents TableEmptyDataTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TableEmptyDataLabel As System.Windows.Forms.Label
    Friend WithEvents TableListMaxTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TableListMaxLabel As System.Windows.Forms.Label
    Friend WithEvents TableMaxSpritesTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TableMaxSpritesLabel As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DefaultButton As System.Windows.Forms.Button
    Friend WithEvents RomCheckButton As System.Windows.Forms.Button
    Friend WithEvents PaletteTableOffsetTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PaletteTableOffsetLabel As System.Windows.Forms.Label
    Friend WithEvents MaxPaletteTextBox As System.Windows.Forms.TextBox
    Friend WithEvents MaxPaletteLabel As System.Windows.Forms.Label
    Friend WithEvents PaletteTableEndTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PaletteTableEndLabel As System.Windows.Forms.Label
End Class
