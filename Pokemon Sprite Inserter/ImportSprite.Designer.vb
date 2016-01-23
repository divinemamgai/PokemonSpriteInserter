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
        Me.TypeTabControl = New System.Windows.Forms.TabControl()
        Me.FrameTabPage = New System.Windows.Forms.TabPage()
        Me.AllFrameTabPage = New System.Windows.Forms.TabPage()
        Me.PaletteAllFlowLayoutPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ImportTypeAllComboBox = New System.Windows.Forms.ComboBox()
        Me.ImportAllButton = New System.Windows.Forms.Button()
        Me.ImportFramesGroupBox = New System.Windows.Forms.GroupBox()
        Me.ImportFramesFlowLayoutPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.FilesTextBox = New System.Windows.Forms.TextBox()
        Me.OpenFilesButton = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.OpenFilesDialog = New System.Windows.Forms.OpenFileDialog()
        Me.ImportingSpriteGroupBox.SuspendLayout()
        CType(Me.ImagePictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TypeTabControl.SuspendLayout()
        Me.FrameTabPage.SuspendLayout()
        Me.AllFrameTabPage.SuspendLayout()
        Me.ImportFramesGroupBox.SuspendLayout()
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
        Me.FileLocationTextBox.Location = New System.Drawing.Point(39, 8)
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
        Me.Label2.Location = New System.Drawing.Point(6, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 15)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "File : "
        '
        'OpenButton
        '
        Me.OpenButton.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpenButton.Location = New System.Drawing.Point(291, 6)
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
        Me.ImportingSpriteGroupBox.Location = New System.Drawing.Point(6, 39)
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
        'TypeTabControl
        '
        Me.TypeTabControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TypeTabControl.Controls.Add(Me.FrameTabPage)
        Me.TypeTabControl.Controls.Add(Me.AllFrameTabPage)
        Me.TypeTabControl.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TypeTabControl.Location = New System.Drawing.Point(12, 12)
        Me.TypeTabControl.Name = "TypeTabControl"
        Me.TypeTabControl.SelectedIndex = 0
        Me.TypeTabControl.Size = New System.Drawing.Size(389, 279)
        Me.TypeTabControl.TabIndex = 7
        '
        'FrameTabPage
        '
        Me.FrameTabPage.Controls.Add(Me.FileLocationTextBox)
        Me.FrameTabPage.Controls.Add(Me.ImportingSpriteGroupBox)
        Me.FrameTabPage.Controls.Add(Me.OpenButton)
        Me.FrameTabPage.Controls.Add(Me.Label2)
        Me.FrameTabPage.Location = New System.Drawing.Point(4, 24)
        Me.FrameTabPage.Name = "FrameTabPage"
        Me.FrameTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.FrameTabPage.Size = New System.Drawing.Size(381, 251)
        Me.FrameTabPage.TabIndex = 0
        Me.FrameTabPage.Text = "For Current Frame"
        Me.FrameTabPage.UseVisualStyleBackColor = True
        '
        'AllFrameTabPage
        '
        Me.AllFrameTabPage.Controls.Add(Me.PaletteAllFlowLayoutPanel)
        Me.AllFrameTabPage.Controls.Add(Me.Label6)
        Me.AllFrameTabPage.Controls.Add(Me.Label5)
        Me.AllFrameTabPage.Controls.Add(Me.ImportTypeAllComboBox)
        Me.AllFrameTabPage.Controls.Add(Me.ImportAllButton)
        Me.AllFrameTabPage.Controls.Add(Me.ImportFramesGroupBox)
        Me.AllFrameTabPage.Controls.Add(Me.FilesTextBox)
        Me.AllFrameTabPage.Controls.Add(Me.OpenFilesButton)
        Me.AllFrameTabPage.Controls.Add(Me.Label3)
        Me.AllFrameTabPage.Location = New System.Drawing.Point(4, 24)
        Me.AllFrameTabPage.Name = "AllFrameTabPage"
        Me.AllFrameTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.AllFrameTabPage.Size = New System.Drawing.Size(381, 251)
        Me.AllFrameTabPage.TabIndex = 1
        Me.AllFrameTabPage.Text = "For All Frames"
        Me.AllFrameTabPage.UseVisualStyleBackColor = True
        '
        'PaletteAllFlowLayoutPanel
        '
        Me.PaletteAllFlowLayoutPanel.Location = New System.Drawing.Point(157, 189)
        Me.PaletteAllFlowLayoutPanel.Name = "PaletteAllFlowLayoutPanel"
        Me.PaletteAllFlowLayoutPanel.Size = New System.Drawing.Size(218, 56)
        Me.PaletteAllFlowLayoutPanel.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(154, 171)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 15)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Sprite Palette"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 171)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 15)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Import Type :"
        '
        'ImportTypeAllComboBox
        '
        Me.ImportTypeAllComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ImportTypeAllComboBox.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImportTypeAllComboBox.FormattingEnabled = True
        Me.ImportTypeAllComboBox.Items.AddRange(New Object() {"Only Sprite", "Both Sprite And Palette"})
        Me.ImportTypeAllComboBox.Location = New System.Drawing.Point(6, 189)
        Me.ImportTypeAllComboBox.Name = "ImportTypeAllComboBox"
        Me.ImportTypeAllComboBox.Size = New System.Drawing.Size(145, 23)
        Me.ImportTypeAllComboBox.TabIndex = 11
        '
        'ImportAllButton
        '
        Me.ImportAllButton.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImportAllButton.Location = New System.Drawing.Point(6, 218)
        Me.ImportAllButton.Name = "ImportAllButton"
        Me.ImportAllButton.Size = New System.Drawing.Size(145, 27)
        Me.ImportAllButton.TabIndex = 10
        Me.ImportAllButton.Text = "Import All Frames"
        Me.ImportAllButton.UseVisualStyleBackColor = True
        '
        'ImportFramesGroupBox
        '
        Me.ImportFramesGroupBox.Controls.Add(Me.ImportFramesFlowLayoutPanel)
        Me.ImportFramesGroupBox.Location = New System.Drawing.Point(9, 37)
        Me.ImportFramesGroupBox.Name = "ImportFramesGroupBox"
        Me.ImportFramesGroupBox.Size = New System.Drawing.Size(366, 131)
        Me.ImportFramesGroupBox.TabIndex = 9
        Me.ImportFramesGroupBox.TabStop = False
        Me.ImportFramesGroupBox.Text = "Importing Sprite Frames"
        '
        'ImportFramesFlowLayoutPanel
        '
        Me.ImportFramesFlowLayoutPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImportFramesFlowLayoutPanel.Location = New System.Drawing.Point(6, 17)
        Me.ImportFramesFlowLayoutPanel.Name = "ImportFramesFlowLayoutPanel"
        Me.ImportFramesFlowLayoutPanel.Size = New System.Drawing.Size(354, 108)
        Me.ImportFramesFlowLayoutPanel.TabIndex = 0
        '
        'FilesTextBox
        '
        Me.FilesTextBox.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FilesTextBox.Location = New System.Drawing.Point(45, 8)
        Me.FilesTextBox.Name = "FilesTextBox"
        Me.FilesTextBox.Size = New System.Drawing.Size(240, 23)
        Me.FilesTextBox.TabIndex = 6
        '
        'OpenFilesButton
        '
        Me.OpenFilesButton.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpenFilesButton.Location = New System.Drawing.Point(291, 6)
        Me.OpenFilesButton.Name = "OpenFilesButton"
        Me.OpenFilesButton.Size = New System.Drawing.Size(84, 27)
        Me.OpenFilesButton.TabIndex = 8
        Me.OpenFilesButton.Text = "Open All"
        Me.OpenFilesButton.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 15)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Files : "
        '
        'ImportSprite
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(413, 303)
        Me.Controls.Add(Me.TypeTabControl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ImportSprite"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import Sprite"
        Me.ImportingSpriteGroupBox.ResumeLayout(False)
        Me.ImportingSpriteGroupBox.PerformLayout()
        CType(Me.ImagePictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TypeTabControl.ResumeLayout(False)
        Me.FrameTabPage.ResumeLayout(False)
        Me.FrameTabPage.PerformLayout()
        Me.AllFrameTabPage.ResumeLayout(False)
        Me.AllFrameTabPage.PerformLayout()
        Me.ImportFramesGroupBox.ResumeLayout(False)
        Me.ResumeLayout(False)

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
    Friend WithEvents TypeTabControl As TabControl
    Friend WithEvents FrameTabPage As TabPage
    Friend WithEvents AllFrameTabPage As TabPage
    Friend WithEvents FilesTextBox As TextBox
    Friend WithEvents OpenFilesButton As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents ImportFramesGroupBox As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents ImportTypeAllComboBox As ComboBox
    Public WithEvents ImportAllButton As Button
    Friend WithEvents ImportFramesFlowLayoutPanel As FlowLayoutPanel
    Friend WithEvents PaletteAllFlowLayoutPanel As FlowLayoutPanel
    Friend WithEvents Label6 As Label
    Friend WithEvents OpenFilesDialog As OpenFileDialog
End Class
