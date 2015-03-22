<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportSprite
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImportSprite))
        Me.ImportButton = New System.Windows.Forms.Button()
        Me.ImportTypeComboBox = New System.Windows.Forms.ComboBox()
        Me.FileLocationTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.OpenButton = New System.Windows.Forms.Button()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.ImportingSpriteGroupBox = New System.Windows.Forms.GroupBox()
        Me.PaletteFlowLayoutPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.SpritePaletteLabel = New System.Windows.Forms.Label()
        Me.SpriteSizeLabel = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SpriteImageLabel = New System.Windows.Forms.Label()
        Me.ImagePictureBox = New System.Windows.Forms.PictureBox()
        Me.ImportingSpriteGroupBox.SuspendLayout()
        CType(Me.ImagePictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImportButton
        '
        Me.ImportButton.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImportButton.Location = New System.Drawing.Point(285, 173)
        Me.ImportButton.Name = "ImportButton"
        Me.ImportButton.Size = New System.Drawing.Size(78, 27)
        Me.ImportButton.TabIndex = 0
        Me.ImportButton.Text = "Import"
        Me.ImportButton.UseVisualStyleBackColor = True
        '
        'ImportTypeComboBox
        '
        Me.ImportTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ImportTypeComboBox.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImportTypeComboBox.FormattingEnabled = True
        Me.ImportTypeComboBox.Items.AddRange(New Object() {"Only Sprite", "Only Palette", "Both Sprite And Palette"})
        Me.ImportTypeComboBox.Location = New System.Drawing.Point(87, 176)
        Me.ImportTypeComboBox.Name = "ImportTypeComboBox"
        Me.ImportTypeComboBox.Size = New System.Drawing.Size(192, 23)
        Me.ImportTypeComboBox.TabIndex = 1
        '
        'FileLocationTextBox
        '
        Me.FileLocationTextBox.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FileLocationTextBox.Location = New System.Drawing.Point(45, 14)
        Me.FileLocationTextBox.Name = "FileLocationTextBox"
        Me.FileLocationTextBox.Size = New System.Drawing.Size(246, 23)
        Me.FileLocationTextBox.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 179)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Import Type :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 15)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "File : "
        '
        'OpenButton
        '
        Me.OpenButton.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpenButton.Location = New System.Drawing.Point(297, 12)
        Me.OpenButton.Name = "OpenButton"
        Me.OpenButton.Size = New System.Drawing.Size(84, 27)
        Me.OpenButton.TabIndex = 5
        Me.OpenButton.Text = "Open"
        Me.OpenButton.UseVisualStyleBackColor = True
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog"
        '
        'ImportingSpriteGroupBox
        '
        Me.ImportingSpriteGroupBox.Controls.Add(Me.PaletteFlowLayoutPanel)
        Me.ImportingSpriteGroupBox.Controls.Add(Me.SpritePaletteLabel)
        Me.ImportingSpriteGroupBox.Controls.Add(Me.SpriteSizeLabel)
        Me.ImportingSpriteGroupBox.Controls.Add(Me.Label1)
        Me.ImportingSpriteGroupBox.Controls.Add(Me.Label4)
        Me.ImportingSpriteGroupBox.Controls.Add(Me.ImportTypeComboBox)
        Me.ImportingSpriteGroupBox.Controls.Add(Me.ImportButton)
        Me.ImportingSpriteGroupBox.Controls.Add(Me.SpriteImageLabel)
        Me.ImportingSpriteGroupBox.Controls.Add(Me.ImagePictureBox)
        Me.ImportingSpriteGroupBox.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImportingSpriteGroupBox.Location = New System.Drawing.Point(12, 45)
        Me.ImportingSpriteGroupBox.Name = "ImportingSpriteGroupBox"
        Me.ImportingSpriteGroupBox.Size = New System.Drawing.Size(369, 207)
        Me.ImportingSpriteGroupBox.TabIndex = 6
        Me.ImportingSpriteGroupBox.TabStop = False
        Me.ImportingSpriteGroupBox.Text = "Importing Sprite Viewer"
        '
        'PaletteFlowLayoutPanel
        '
        Me.PaletteFlowLayoutPanel.Location = New System.Drawing.Point(145, 113)
        Me.PaletteFlowLayoutPanel.Name = "PaletteFlowLayoutPanel"
        Me.PaletteFlowLayoutPanel.Size = New System.Drawing.Size(218, 56)
        Me.PaletteFlowLayoutPanel.TabIndex = 0
        '
        'SpritePaletteLabel
        '
        Me.SpritePaletteLabel.AutoSize = True
        Me.SpritePaletteLabel.Location = New System.Drawing.Point(142, 95)
        Me.SpritePaletteLabel.Name = "SpritePaletteLabel"
        Me.SpritePaletteLabel.Size = New System.Drawing.Size(82, 15)
        Me.SpritePaletteLabel.TabIndex = 4
        Me.SpritePaletteLabel.Text = "Sprite Palette"
        '
        'SpriteSizeLabel
        '
        Me.SpriteSizeLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SpriteSizeLabel.AutoSize = True
        Me.SpriteSizeLabel.Location = New System.Drawing.Point(142, 42)
        Me.SpriteSizeLabel.Name = "SpriteSizeLabel"
        Me.SpriteSizeLabel.Size = New System.Drawing.Size(74, 15)
        Me.SpriteSizeLabel.TabIndex = 3
        Me.SpriteSizeLabel.Text = "Sprite Size : "
        Me.SpriteSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(113, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 15)
        Me.Label4.TabIndex = 2
        '
        'SpriteImageLabel
        '
        Me.SpriteImageLabel.AutoSize = True
        Me.SpriteImageLabel.Location = New System.Drawing.Point(6, 25)
        Me.SpriteImageLabel.Name = "SpriteImageLabel"
        Me.SpriteImageLabel.Size = New System.Drawing.Size(76, 15)
        Me.SpriteImageLabel.TabIndex = 1
        Me.SpriteImageLabel.Text = "Sprite Image"
        '
        'ImagePictureBox
        '
        Me.ImagePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ImagePictureBox.Location = New System.Drawing.Point(6, 42)
        Me.ImagePictureBox.Name = "ImagePictureBox"
        Me.ImagePictureBox.Size = New System.Drawing.Size(128, 128)
        Me.ImagePictureBox.TabIndex = 0
        Me.ImagePictureBox.TabStop = False
        '
        'ImportSprite
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(393, 264)
        Me.Controls.Add(Me.OpenButton)
        Me.Controls.Add(Me.FileLocationTextBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ImportingSpriteGroupBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ImportSprite"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import Sprite"
        Me.ImportingSpriteGroupBox.ResumeLayout(False)
        Me.ImportingSpriteGroupBox.PerformLayout()
        CType(Me.ImagePictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ImportTypeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents FileLocationTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents OpenButton As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ImportingSpriteGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents SpriteImageLabel As System.Windows.Forms.Label
    Friend WithEvents ImagePictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents PaletteFlowLayoutPanel As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents SpritePaletteLabel As System.Windows.Forms.Label
    Friend WithEvents SpriteSizeLabel As System.Windows.Forms.Label
    Public WithEvents ImportButton As System.Windows.Forms.Button
End Class
