<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.PokemonRomGroupBox = New System.Windows.Forms.GroupBox()
        Me.FilePathLabel = New System.Windows.Forms.Label()
        Me.FilePathTextBox = New System.Windows.Forms.TextBox()
        Me.OpenRomButton = New System.Windows.Forms.Button()
        Me.SpriteTemplateSettingsGroupBox = New System.Windows.Forms.GroupBox()
        Me.CancelSpriteInsertionButton = New System.Windows.Forms.Button()
        Me.CreateOWSTableButton = New System.Windows.Forms.Button()
        Me.PaletteFixButton = New System.Windows.Forms.Button()
        Me.BackButton = New System.Windows.Forms.Button()
        Me.PaletteInserterButton = New System.Windows.Forms.Button()
        Me.CustomSpriteArtButton = New System.Windows.Forms.Button()
        Me.HeightTextBox = New System.Windows.Forms.TextBox()
        Me.HeightLabel = New System.Windows.Forms.Label()
        Me.SkipBytesTextBox = New System.Windows.Forms.TextBox()
        Me.SkipBytesLabel = New System.Windows.Forms.Label()
        Me.StartOffsetTextBox = New System.Windows.Forms.TextBox()
        Me.StartOffsetLabel = New System.Windows.Forms.Label()
        Me.FreeSpaceOffsetsButton = New System.Windows.Forms.Button()
        Me.UseFreeSpaceFinderCheckBox = New System.Windows.Forms.CheckBox()
        Me.SpriteDataPresetGroupBox = New System.Windows.Forms.GroupBox()
        Me.CustomPresetCheckBox = New System.Windows.Forms.CheckBox()
        Me.Pointer4TextBox = New System.Windows.Forms.TextBox()
        Me.Pointer4Label = New System.Windows.Forms.Label()
        Me.AnimPointerTextBox = New System.Windows.Forms.TextBox()
        Me.AnimPointerLabel = New System.Windows.Forms.Label()
        Me.SelectDataPresetButton = New System.Windows.Forms.Button()
        Me.Pointer2TextBox = New System.Windows.Forms.TextBox()
        Me.Pointer2Label = New System.Windows.Forms.Label()
        Me.Pointer1TextBox = New System.Windows.Forms.TextBox()
        Me.Pointer1Label = New System.Windows.Forms.Label()
        Me.PalRegistersTextBox = New System.Windows.Forms.TextBox()
        Me.PalRegistersLabel = New System.Windows.Forms.Label()
        Me.UnknownData1TextBox = New System.Windows.Forms.TextBox()
        Me.UnknownData1Label = New System.Windows.Forms.Label()
        Me.NumberOfFramesTextBox = New System.Windows.Forms.TextBox()
        Me.NumberOfFramesLabel = New System.Windows.Forms.Label()
        Me.PaletteNumberTextBox = New System.Windows.Forms.TextBox()
        Me.PaletteNumberLabel = New System.Windows.Forms.Label()
        Me.WidthTextBox = New System.Windows.Forms.TextBox()
        Me.WidthLabel = New System.Windows.Forms.Label()
        Me.StartSpriteInsertionButton = New System.Windows.Forms.Button()
        Me.RomFile = New System.Windows.Forms.OpenFileDialog()
        Me.RomStateLabel = New System.Windows.Forms.Label()
        Me.AboutButton = New System.Windows.Forms.Button()
        Me.SettingsButton = New System.Windows.Forms.Button()
        Me.ViewTableButton = New System.Windows.Forms.Button()
        Me.HistoryButton = New System.Windows.Forms.Button()
        Me.Log = New System.Windows.Forms.RichTextBox()
        Me.SelectOWSTablePanel = New System.Windows.Forms.Panel()
        Me.SelectOWSTableGroupBox = New System.Windows.Forms.GroupBox()
        Me.PokemonRomGroupBox.SuspendLayout()
        Me.SpriteTemplateSettingsGroupBox.SuspendLayout()
        Me.SpriteDataPresetGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'PokemonRomGroupBox
        '
        Me.PokemonRomGroupBox.Controls.Add(Me.FilePathLabel)
        Me.PokemonRomGroupBox.Controls.Add(Me.FilePathTextBox)
        Me.PokemonRomGroupBox.Controls.Add(Me.OpenRomButton)
        Me.PokemonRomGroupBox.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PokemonRomGroupBox.Location = New System.Drawing.Point(13, 13)
        Me.PokemonRomGroupBox.Name = "PokemonRomGroupBox"
        Me.PokemonRomGroupBox.Size = New System.Drawing.Size(600, 66)
        Me.PokemonRomGroupBox.TabIndex = 0
        Me.PokemonRomGroupBox.TabStop = False
        Me.PokemonRomGroupBox.Text = "Pokemon Fire Red Rom"
        '
        'FilePathLabel
        '
        Me.FilePathLabel.AutoSize = True
        Me.FilePathLabel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FilePathLabel.Location = New System.Drawing.Point(7, 17)
        Me.FilePathLabel.Name = "FilePathLabel"
        Me.FilePathLabel.Size = New System.Drawing.Size(316, 15)
        Me.FilePathLabel.TabIndex = 2
        Me.FilePathLabel.Text = "Enter or Browse the path to your Pokemon Fire Red Rom :"
        '
        'FilePathTextBox
        '
        Me.FilePathTextBox.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FilePathTextBox.Location = New System.Drawing.Point(6, 36)
        Me.FilePathTextBox.Name = "FilePathTextBox"
        Me.FilePathTextBox.Size = New System.Drawing.Size(507, 23)
        Me.FilePathTextBox.TabIndex = 1
        '
        'OpenRomButton
        '
        Me.OpenRomButton.Location = New System.Drawing.Point(519, 34)
        Me.OpenRomButton.Name = "OpenRomButton"
        Me.OpenRomButton.Size = New System.Drawing.Size(75, 26)
        Me.OpenRomButton.TabIndex = 0
        Me.OpenRomButton.Text = "Open Rom"
        Me.OpenRomButton.UseVisualStyleBackColor = True
        '
        'SpriteTemplateSettingsGroupBox
        '
        Me.SpriteTemplateSettingsGroupBox.Controls.Add(Me.SelectOWSTableGroupBox)
        Me.SpriteTemplateSettingsGroupBox.Controls.Add(Me.SelectOWSTablePanel)
        Me.SpriteTemplateSettingsGroupBox.Controls.Add(Me.Log)
        Me.SpriteTemplateSettingsGroupBox.Controls.Add(Me.ViewTableButton)
        Me.SpriteTemplateSettingsGroupBox.Controls.Add(Me.CancelSpriteInsertionButton)
        Me.SpriteTemplateSettingsGroupBox.Controls.Add(Me.CreateOWSTableButton)
        Me.SpriteTemplateSettingsGroupBox.Controls.Add(Me.PaletteFixButton)
        Me.SpriteTemplateSettingsGroupBox.Controls.Add(Me.BackButton)
        Me.SpriteTemplateSettingsGroupBox.Controls.Add(Me.PaletteInserterButton)
        Me.SpriteTemplateSettingsGroupBox.Controls.Add(Me.CustomSpriteArtButton)
        Me.SpriteTemplateSettingsGroupBox.Controls.Add(Me.HeightTextBox)
        Me.SpriteTemplateSettingsGroupBox.Controls.Add(Me.HeightLabel)
        Me.SpriteTemplateSettingsGroupBox.Controls.Add(Me.SkipBytesTextBox)
        Me.SpriteTemplateSettingsGroupBox.Controls.Add(Me.SkipBytesLabel)
        Me.SpriteTemplateSettingsGroupBox.Controls.Add(Me.StartOffsetTextBox)
        Me.SpriteTemplateSettingsGroupBox.Controls.Add(Me.StartOffsetLabel)
        Me.SpriteTemplateSettingsGroupBox.Controls.Add(Me.FreeSpaceOffsetsButton)
        Me.SpriteTemplateSettingsGroupBox.Controls.Add(Me.UseFreeSpaceFinderCheckBox)
        Me.SpriteTemplateSettingsGroupBox.Controls.Add(Me.SpriteDataPresetGroupBox)
        Me.SpriteTemplateSettingsGroupBox.Controls.Add(Me.NumberOfFramesTextBox)
        Me.SpriteTemplateSettingsGroupBox.Controls.Add(Me.NumberOfFramesLabel)
        Me.SpriteTemplateSettingsGroupBox.Controls.Add(Me.PaletteNumberTextBox)
        Me.SpriteTemplateSettingsGroupBox.Controls.Add(Me.PaletteNumberLabel)
        Me.SpriteTemplateSettingsGroupBox.Controls.Add(Me.WidthTextBox)
        Me.SpriteTemplateSettingsGroupBox.Controls.Add(Me.WidthLabel)
        Me.SpriteTemplateSettingsGroupBox.Controls.Add(Me.StartSpriteInsertionButton)
        Me.SpriteTemplateSettingsGroupBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.SpriteTemplateSettingsGroupBox.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpriteTemplateSettingsGroupBox.Location = New System.Drawing.Point(13, 85)
        Me.SpriteTemplateSettingsGroupBox.Name = "SpriteTemplateSettingsGroupBox"
        Me.SpriteTemplateSettingsGroupBox.Size = New System.Drawing.Size(600, 278)
        Me.SpriteTemplateSettingsGroupBox.TabIndex = 1
        Me.SpriteTemplateSettingsGroupBox.TabStop = False
        Me.SpriteTemplateSettingsGroupBox.Text = "Sprite Template Settings"
        '
        'CancelSpriteInsertionButton
        '
        Me.CancelSpriteInsertionButton.Location = New System.Drawing.Point(6, 246)
        Me.CancelSpriteInsertionButton.Name = "CancelSpriteInsertionButton"
        Me.CancelSpriteInsertionButton.Size = New System.Drawing.Size(588, 26)
        Me.CancelSpriteInsertionButton.TabIndex = 33
        Me.CancelSpriteInsertionButton.Text = "Cancel Sprite Insertion"
        Me.CancelSpriteInsertionButton.UseVisualStyleBackColor = True
        '
        'CreateOWSTableButton
        '
        Me.CreateOWSTableButton.Location = New System.Drawing.Point(475, 202)
        Me.CreateOWSTableButton.Name = "CreateOWSTableButton"
        Me.CreateOWSTableButton.Size = New System.Drawing.Size(119, 38)
        Me.CreateOWSTableButton.TabIndex = 30
        Me.CreateOWSTableButton.Text = "Create Empty OWS Table"
        Me.CreateOWSTableButton.UseVisualStyleBackColor = True
        '
        'PaletteFixButton
        '
        Me.PaletteFixButton.Location = New System.Drawing.Point(475, 141)
        Me.PaletteFixButton.Name = "PaletteFixButton"
        Me.PaletteFixButton.Size = New System.Drawing.Size(119, 25)
        Me.PaletteFixButton.TabIndex = 36
        Me.PaletteFixButton.Text = "Palette Fix"
        Me.PaletteFixButton.UseVisualStyleBackColor = True
        '
        'BackButton
        '
        Me.BackButton.Location = New System.Drawing.Point(6, 246)
        Me.BackButton.Name = "BackButton"
        Me.BackButton.Size = New System.Drawing.Size(588, 26)
        Me.BackButton.TabIndex = 17
        Me.BackButton.Text = "Back"
        Me.BackButton.UseVisualStyleBackColor = True
        '
        'PaletteInserterButton
        '
        Me.PaletteInserterButton.Location = New System.Drawing.Point(475, 110)
        Me.PaletteInserterButton.Name = "PaletteInserterButton"
        Me.PaletteInserterButton.Size = New System.Drawing.Size(119, 25)
        Me.PaletteInserterButton.TabIndex = 27
        Me.PaletteInserterButton.Text = "Palette Inserter"
        Me.PaletteInserterButton.UseVisualStyleBackColor = True
        '
        'CustomSpriteArtButton
        '
        Me.CustomSpriteArtButton.Location = New System.Drawing.Point(323, 16)
        Me.CustomSpriteArtButton.Name = "CustomSpriteArtButton"
        Me.CustomSpriteArtButton.Size = New System.Drawing.Size(271, 25)
        Me.CustomSpriteArtButton.TabIndex = 25
        Me.CustomSpriteArtButton.Text = "Use Custom Sprite Art Data - Off"
        Me.CustomSpriteArtButton.UseVisualStyleBackColor = True
        '
        'HeightTextBox
        '
        Me.HeightTextBox.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeightTextBox.Location = New System.Drawing.Point(267, 17)
        Me.HeightTextBox.Name = "HeightTextBox"
        Me.HeightTextBox.Size = New System.Drawing.Size(50, 23)
        Me.HeightTextBox.TabIndex = 4
        Me.HeightTextBox.Tag = "32"
        Me.HeightTextBox.Text = "32"
        '
        'HeightLabel
        '
        Me.HeightLabel.AutoSize = True
        Me.HeightLabel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeightLabel.Location = New System.Drawing.Point(164, 20)
        Me.HeightLabel.Name = "HeightLabel"
        Me.HeightLabel.Size = New System.Drawing.Size(107, 15)
        Me.HeightLabel.TabIndex = 5
        Me.HeightLabel.Text = "Height [Decimal] : "
        '
        'SkipBytesTextBox
        '
        Me.SkipBytesTextBox.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SkipBytesTextBox.Location = New System.Drawing.Point(542, 75)
        Me.SkipBytesTextBox.Name = "SkipBytesTextBox"
        Me.SkipBytesTextBox.Size = New System.Drawing.Size(52, 23)
        Me.SkipBytesTextBox.TabIndex = 29
        Me.SkipBytesTextBox.Tag = "16"
        Me.SkipBytesTextBox.Text = "16"
        '
        'SkipBytesLabel
        '
        Me.SkipBytesLabel.AutoSize = True
        Me.SkipBytesLabel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SkipBytesLabel.Location = New System.Drawing.Point(474, 78)
        Me.SkipBytesLabel.Name = "SkipBytesLabel"
        Me.SkipBytesLabel.Size = New System.Drawing.Size(68, 15)
        Me.SkipBytesLabel.TabIndex = 28
        Me.SkipBytesLabel.Text = "Skip Bytes :"
        '
        'StartOffsetTextBox
        '
        Me.StartOffsetTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.StartOffsetTextBox.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StartOffsetTextBox.Location = New System.Drawing.Point(368, 75)
        Me.StartOffsetTextBox.MaxLength = 6
        Me.StartOffsetTextBox.Name = "StartOffsetTextBox"
        Me.StartOffsetTextBox.Size = New System.Drawing.Size(101, 23)
        Me.StartOffsetTextBox.TabIndex = 14
        Me.StartOffsetTextBox.Tag = "800000"
        Me.StartOffsetTextBox.Text = "800000"
        '
        'StartOffsetLabel
        '
        Me.StartOffsetLabel.AutoSize = True
        Me.StartOffsetLabel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StartOffsetLabel.Location = New System.Drawing.Point(262, 78)
        Me.StartOffsetLabel.Name = "StartOffsetLabel"
        Me.StartOffsetLabel.Size = New System.Drawing.Size(109, 15)
        Me.StartOffsetLabel.TabIndex = 15
        Me.StartOffsetLabel.Text = "Start Offset [Hex] : "
        '
        'FreeSpaceOffsetsButton
        '
        Me.FreeSpaceOffsetsButton.Location = New System.Drawing.Point(390, 74)
        Me.FreeSpaceOffsetsButton.Name = "FreeSpaceOffsetsButton"
        Me.FreeSpaceOffsetsButton.Size = New System.Drawing.Size(204, 25)
        Me.FreeSpaceOffsetsButton.TabIndex = 12
        Me.FreeSpaceOffsetsButton.Text = "Free Space Offsets"
        Me.FreeSpaceOffsetsButton.UseVisualStyleBackColor = True
        '
        'UseFreeSpaceFinderCheckBox
        '
        Me.UseFreeSpaceFinderCheckBox.AutoSize = True
        Me.UseFreeSpaceFinderCheckBox.Checked = True
        Me.UseFreeSpaceFinderCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.UseFreeSpaceFinderCheckBox.Location = New System.Drawing.Point(279, 50)
        Me.UseFreeSpaceFinderCheckBox.Name = "UseFreeSpaceFinderCheckBox"
        Me.UseFreeSpaceFinderCheckBox.Size = New System.Drawing.Size(315, 19)
        Me.UseFreeSpaceFinderCheckBox.TabIndex = 13
        Me.UseFreeSpaceFinderCheckBox.Text = "Use Built-In Free Space Finder For Sprite Data Offsets"
        Me.UseFreeSpaceFinderCheckBox.UseVisualStyleBackColor = True
        '
        'SpriteDataPresetGroupBox
        '
        Me.SpriteDataPresetGroupBox.Controls.Add(Me.CustomPresetCheckBox)
        Me.SpriteDataPresetGroupBox.Controls.Add(Me.Pointer4TextBox)
        Me.SpriteDataPresetGroupBox.Controls.Add(Me.Pointer4Label)
        Me.SpriteDataPresetGroupBox.Controls.Add(Me.AnimPointerTextBox)
        Me.SpriteDataPresetGroupBox.Controls.Add(Me.AnimPointerLabel)
        Me.SpriteDataPresetGroupBox.Controls.Add(Me.SelectDataPresetButton)
        Me.SpriteDataPresetGroupBox.Controls.Add(Me.Pointer2TextBox)
        Me.SpriteDataPresetGroupBox.Controls.Add(Me.Pointer2Label)
        Me.SpriteDataPresetGroupBox.Controls.Add(Me.Pointer1TextBox)
        Me.SpriteDataPresetGroupBox.Controls.Add(Me.Pointer1Label)
        Me.SpriteDataPresetGroupBox.Controls.Add(Me.PalRegistersTextBox)
        Me.SpriteDataPresetGroupBox.Controls.Add(Me.PalRegistersLabel)
        Me.SpriteDataPresetGroupBox.Controls.Add(Me.UnknownData1TextBox)
        Me.SpriteDataPresetGroupBox.Controls.Add(Me.UnknownData1Label)
        Me.SpriteDataPresetGroupBox.Location = New System.Drawing.Point(6, 103)
        Me.SpriteDataPresetGroupBox.Name = "SpriteDataPresetGroupBox"
        Me.SpriteDataPresetGroupBox.Size = New System.Drawing.Size(463, 137)
        Me.SpriteDataPresetGroupBox.TabIndex = 10
        Me.SpriteDataPresetGroupBox.TabStop = False
        Me.SpriteDataPresetGroupBox.Text = "Sprite Data Preset [Current : Preset - 1]"
        '
        'CustomPresetCheckBox
        '
        Me.CustomPresetCheckBox.AutoSize = True
        Me.CustomPresetCheckBox.Location = New System.Drawing.Point(302, 113)
        Me.CustomPresetCheckBox.Name = "CustomPresetCheckBox"
        Me.CustomPresetCheckBox.Size = New System.Drawing.Size(158, 19)
        Me.CustomPresetCheckBox.TabIndex = 14
        Me.CustomPresetCheckBox.Text = "Use Custom Preset Data"
        Me.CustomPresetCheckBox.UseVisualStyleBackColor = True
        '
        'Pointer4TextBox
        '
        Me.Pointer4TextBox.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pointer4TextBox.Location = New System.Drawing.Point(70, 106)
        Me.Pointer4TextBox.MaxLength = 8
        Me.Pointer4TextBox.Name = "Pointer4TextBox"
        Me.Pointer4TextBox.Size = New System.Drawing.Size(143, 23)
        Me.Pointer4TextBox.TabIndex = 23
        '
        'Pointer4Label
        '
        Me.Pointer4Label.AutoSize = True
        Me.Pointer4Label.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pointer4Label.Location = New System.Drawing.Point(6, 109)
        Me.Pointer4Label.Name = "Pointer4Label"
        Me.Pointer4Label.Size = New System.Drawing.Size(66, 15)
        Me.Pointer4Label.TabIndex = 24
        Me.Pointer4Label.Text = "Pointer 4 : "
        '
        'AnimPointerTextBox
        '
        Me.AnimPointerTextBox.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AnimPointerTextBox.Location = New System.Drawing.Point(91, 77)
        Me.AnimPointerTextBox.MaxLength = 8
        Me.AnimPointerTextBox.Name = "AnimPointerTextBox"
        Me.AnimPointerTextBox.Size = New System.Drawing.Size(122, 23)
        Me.AnimPointerTextBox.TabIndex = 19
        '
        'AnimPointerLabel
        '
        Me.AnimPointerLabel.AutoSize = True
        Me.AnimPointerLabel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AnimPointerLabel.Location = New System.Drawing.Point(6, 80)
        Me.AnimPointerLabel.Name = "AnimPointerLabel"
        Me.AnimPointerLabel.Size = New System.Drawing.Size(87, 15)
        Me.AnimPointerLabel.TabIndex = 20
        Me.AnimPointerLabel.Text = "Anim Pointer : "
        '
        'SelectDataPresetButton
        '
        Me.SelectDataPresetButton.Location = New System.Drawing.Point(255, 81)
        Me.SelectDataPresetButton.Name = "SelectDataPresetButton"
        Me.SelectDataPresetButton.Size = New System.Drawing.Size(202, 26)
        Me.SelectDataPresetButton.TabIndex = 3
        Me.SelectDataPresetButton.Text = "Select Data Preset"
        Me.SelectDataPresetButton.UseVisualStyleBackColor = True
        '
        'Pointer2TextBox
        '
        Me.Pointer2TextBox.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pointer2TextBox.Location = New System.Drawing.Point(318, 52)
        Me.Pointer2TextBox.MaxLength = 8
        Me.Pointer2TextBox.Name = "Pointer2TextBox"
        Me.Pointer2TextBox.Size = New System.Drawing.Size(138, 23)
        Me.Pointer2TextBox.TabIndex = 17
        '
        'Pointer2Label
        '
        Me.Pointer2Label.AutoSize = True
        Me.Pointer2Label.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pointer2Label.Location = New System.Drawing.Point(255, 55)
        Me.Pointer2Label.Name = "Pointer2Label"
        Me.Pointer2Label.Size = New System.Drawing.Size(66, 15)
        Me.Pointer2Label.TabIndex = 18
        Me.Pointer2Label.Text = "Pointer 2 : "
        '
        'Pointer1TextBox
        '
        Me.Pointer1TextBox.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pointer1TextBox.Location = New System.Drawing.Point(70, 48)
        Me.Pointer1TextBox.MaxLength = 8
        Me.Pointer1TextBox.Name = "Pointer1TextBox"
        Me.Pointer1TextBox.Size = New System.Drawing.Size(143, 23)
        Me.Pointer1TextBox.TabIndex = 15
        '
        'Pointer1Label
        '
        Me.Pointer1Label.AutoSize = True
        Me.Pointer1Label.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pointer1Label.Location = New System.Drawing.Point(6, 51)
        Me.Pointer1Label.Name = "Pointer1Label"
        Me.Pointer1Label.Size = New System.Drawing.Size(66, 15)
        Me.Pointer1Label.TabIndex = 16
        Me.Pointer1Label.Text = "Pointer 1 : "
        '
        'PalRegistersTextBox
        '
        Me.PalRegistersTextBox.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PalRegistersTextBox.Location = New System.Drawing.Point(339, 18)
        Me.PalRegistersTextBox.MaxLength = 8
        Me.PalRegistersTextBox.Name = "PalRegistersTextBox"
        Me.PalRegistersTextBox.Size = New System.Drawing.Size(117, 23)
        Me.PalRegistersTextBox.TabIndex = 13
        '
        'PalRegistersLabel
        '
        Me.PalRegistersLabel.AutoSize = True
        Me.PalRegistersLabel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PalRegistersLabel.Location = New System.Drawing.Point(255, 21)
        Me.PalRegistersLabel.Name = "PalRegistersLabel"
        Me.PalRegistersLabel.Size = New System.Drawing.Size(84, 15)
        Me.PalRegistersLabel.TabIndex = 14
        Me.PalRegistersLabel.Text = "Pal Registers :"
        '
        'UnknownData1TextBox
        '
        Me.UnknownData1TextBox.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UnknownData1TextBox.Location = New System.Drawing.Point(110, 19)
        Me.UnknownData1TextBox.MaxLength = 8
        Me.UnknownData1TextBox.Name = "UnknownData1TextBox"
        Me.UnknownData1TextBox.Size = New System.Drawing.Size(103, 23)
        Me.UnknownData1TextBox.TabIndex = 11
        '
        'UnknownData1Label
        '
        Me.UnknownData1Label.AutoSize = True
        Me.UnknownData1Label.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UnknownData1Label.Location = New System.Drawing.Point(6, 22)
        Me.UnknownData1Label.Name = "UnknownData1Label"
        Me.UnknownData1Label.Size = New System.Drawing.Size(103, 15)
        Me.UnknownData1Label.TabIndex = 12
        Me.UnknownData1Label.Text = "Unknown Data 1 :"
        '
        'NumberOfFramesTextBox
        '
        Me.NumberOfFramesTextBox.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumberOfFramesTextBox.Location = New System.Drawing.Point(177, 74)
        Me.NumberOfFramesTextBox.Name = "NumberOfFramesTextBox"
        Me.NumberOfFramesTextBox.Size = New System.Drawing.Size(35, 23)
        Me.NumberOfFramesTextBox.TabIndex = 8
        Me.NumberOfFramesTextBox.Tag = "9"
        Me.NumberOfFramesTextBox.Text = "9"
        '
        'NumberOfFramesLabel
        '
        Me.NumberOfFramesLabel.AutoSize = True
        Me.NumberOfFramesLabel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumberOfFramesLabel.Location = New System.Drawing.Point(6, 77)
        Me.NumberOfFramesLabel.Name = "NumberOfFramesLabel"
        Me.NumberOfFramesLabel.Size = New System.Drawing.Size(171, 15)
        Me.NumberOfFramesLabel.TabIndex = 9
        Me.NumberOfFramesLabel.Text = "Number Of Frames [Decimal] :"
        '
        'PaletteNumberTextBox
        '
        Me.PaletteNumberTextBox.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PaletteNumberTextBox.Location = New System.Drawing.Point(159, 45)
        Me.PaletteNumberTextBox.Name = "PaletteNumberTextBox"
        Me.PaletteNumberTextBox.Size = New System.Drawing.Size(53, 23)
        Me.PaletteNumberTextBox.TabIndex = 6
        Me.PaletteNumberTextBox.Tag = "0"
        Me.PaletteNumberTextBox.Text = "0"
        '
        'PaletteNumberLabel
        '
        Me.PaletteNumberLabel.AutoSize = True
        Me.PaletteNumberLabel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PaletteNumberLabel.Location = New System.Drawing.Point(6, 48)
        Me.PaletteNumberLabel.Name = "PaletteNumberLabel"
        Me.PaletteNumberLabel.Size = New System.Drawing.Size(153, 15)
        Me.PaletteNumberLabel.TabIndex = 7
        Me.PaletteNumberLabel.Text = "Palette Number [Decimal] :"
        '
        'WidthTextBox
        '
        Me.WidthTextBox.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WidthTextBox.Location = New System.Drawing.Point(109, 16)
        Me.WidthTextBox.Name = "WidthTextBox"
        Me.WidthTextBox.Size = New System.Drawing.Size(50, 23)
        Me.WidthTextBox.TabIndex = 3
        Me.WidthTextBox.Tag = "16"
        Me.WidthTextBox.Text = "16"
        '
        'WidthLabel
        '
        Me.WidthLabel.AutoSize = True
        Me.WidthLabel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WidthLabel.Location = New System.Drawing.Point(6, 19)
        Me.WidthLabel.Name = "WidthLabel"
        Me.WidthLabel.Size = New System.Drawing.Size(103, 15)
        Me.WidthLabel.TabIndex = 3
        Me.WidthLabel.Text = "Width [Decimal] :"
        '
        'StartSpriteInsertionButton
        '
        Me.StartSpriteInsertionButton.Location = New System.Drawing.Point(6, 246)
        Me.StartSpriteInsertionButton.Name = "StartSpriteInsertionButton"
        Me.StartSpriteInsertionButton.Size = New System.Drawing.Size(588, 26)
        Me.StartSpriteInsertionButton.TabIndex = 11
        Me.StartSpriteInsertionButton.Text = "Start Sprite Insertion"
        Me.StartSpriteInsertionButton.UseVisualStyleBackColor = True
        '
        'RomFile
        '
        Me.RomFile.FileName = "Open Rom"
        Me.RomFile.Title = "Open Pokemon Fire Red Rom"
        '
        'RomStateLabel
        '
        Me.RomStateLabel.AutoSize = True
        Me.RomStateLabel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RomStateLabel.Location = New System.Drawing.Point(10, 381)
        Me.RomStateLabel.Name = "RomStateLabel"
        Me.RomStateLabel.Size = New System.Drawing.Size(173, 15)
        Me.RomStateLabel.TabIndex = 6
        Me.RomStateLabel.Text = "Load a Pokemon Fire Red Rom."
        '
        'AboutButton
        '
        Me.AboutButton.Location = New System.Drawing.Point(547, 369)
        Me.AboutButton.Name = "AboutButton"
        Me.AboutButton.Size = New System.Drawing.Size(66, 26)
        Me.AboutButton.TabIndex = 25
        Me.AboutButton.Text = "About"
        Me.AboutButton.UseVisualStyleBackColor = True
        '
        'SettingsButton
        '
        Me.SettingsButton.Location = New System.Drawing.Point(476, 369)
        Me.SettingsButton.Name = "SettingsButton"
        Me.SettingsButton.Size = New System.Drawing.Size(65, 26)
        Me.SettingsButton.TabIndex = 26
        Me.SettingsButton.Text = "Settings"
        Me.SettingsButton.UseVisualStyleBackColor = True
        '
        'ViewTableButton
        '
        Me.ViewTableButton.Location = New System.Drawing.Point(475, 171)
        Me.ViewTableButton.Name = "ViewTableButton"
        Me.ViewTableButton.Size = New System.Drawing.Size(119, 25)
        Me.ViewTableButton.TabIndex = 37
        Me.ViewTableButton.Text = "View Tables"
        Me.ViewTableButton.UseVisualStyleBackColor = True
        '
        'HistoryButton
        '
        Me.HistoryButton.Location = New System.Drawing.Point(405, 369)
        Me.HistoryButton.Name = "HistoryButton"
        Me.HistoryButton.Size = New System.Drawing.Size(65, 26)
        Me.HistoryButton.TabIndex = 27
        Me.HistoryButton.Text = "History"
        Me.HistoryButton.UseVisualStyleBackColor = True
        '
        'Log
        '
        Me.Log.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Log.Location = New System.Drawing.Point(7, 16)
        Me.Log.Name = "Log"
        Me.Log.Size = New System.Drawing.Size(587, 224)
        Me.Log.TabIndex = 38
        Me.Log.Text = ""
        '
        'SelectOWSTablePanel
        '
        Me.SelectOWSTablePanel.AutoScroll = True
        Me.SelectOWSTablePanel.Location = New System.Drawing.Point(7, 16)
        Me.SelectOWSTablePanel.Name = "SelectOWSTablePanel"
        Me.SelectOWSTablePanel.Size = New System.Drawing.Size(587, 224)
        Me.SelectOWSTablePanel.TabIndex = 39
        '
        'SelectOWSTableGroupBox
        '
        Me.SelectOWSTableGroupBox.Location = New System.Drawing.Point(6, 16)
        Me.SelectOWSTableGroupBox.Name = "SelectOWSTableGroupBox"
        Me.SelectOWSTableGroupBox.Size = New System.Drawing.Size(588, 224)
        Me.SelectOWSTableGroupBox.TabIndex = 0
        Me.SelectOWSTableGroupBox.TabStop = False
        Me.SelectOWSTableGroupBox.Text = "Select OWS Table To Insert Created Sprite In"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(625, 405)
        Me.Controls.Add(Me.HistoryButton)
        Me.Controls.Add(Me.SpriteTemplateSettingsGroupBox)
        Me.Controls.Add(Me.SettingsButton)
        Me.Controls.Add(Me.AboutButton)
        Me.Controls.Add(Me.RomStateLabel)
        Me.Controls.Add(Me.PokemonRomGroupBox)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Pokemon Sprite Inserter"
        Me.PokemonRomGroupBox.ResumeLayout(False)
        Me.PokemonRomGroupBox.PerformLayout()
        Me.SpriteTemplateSettingsGroupBox.ResumeLayout(False)
        Me.SpriteTemplateSettingsGroupBox.PerformLayout()
        Me.SpriteDataPresetGroupBox.ResumeLayout(False)
        Me.SpriteDataPresetGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PokemonRomGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents SpriteTemplateSettingsGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents RomFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents OpenRomButton As System.Windows.Forms.Button
    Friend WithEvents FilePathTextBox As System.Windows.Forms.TextBox
    Friend WithEvents FilePathLabel As System.Windows.Forms.Label
    Friend WithEvents HeightLabel As System.Windows.Forms.Label
    Friend WithEvents RomStateLabel As System.Windows.Forms.Label
    Friend WithEvents PaletteNumberTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PaletteNumberLabel As System.Windows.Forms.Label
    Friend WithEvents SelectDataPresetButton As System.Windows.Forms.Button
    Friend WithEvents NumberOfFramesTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NumberOfFramesLabel As System.Windows.Forms.Label
    Friend WithEvents SpriteDataPresetGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents UnknownData1TextBox As System.Windows.Forms.TextBox
    Friend WithEvents UnknownData1Label As System.Windows.Forms.Label
    Friend WithEvents PalRegistersTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PalRegistersLabel As System.Windows.Forms.Label
    Friend WithEvents Pointer1TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Pointer1Label As System.Windows.Forms.Label
    Friend WithEvents Pointer2TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Pointer2Label As System.Windows.Forms.Label
    Friend WithEvents AnimPointerTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AnimPointerLabel As System.Windows.Forms.Label
    Friend WithEvents Pointer4TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Pointer4Label As System.Windows.Forms.Label
    Friend WithEvents StartSpriteInsertionButton As System.Windows.Forms.Button
    Friend WithEvents FreeSpaceOffsetsButton As System.Windows.Forms.Button
    Friend WithEvents UseFreeSpaceFinderCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents CustomPresetCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents AboutButton As System.Windows.Forms.Button
    Friend WithEvents StartOffsetTextBox As System.Windows.Forms.TextBox
    Friend WithEvents StartOffsetLabel As System.Windows.Forms.Label
    Friend WithEvents BackButton As System.Windows.Forms.Button
    Friend WithEvents SkipBytesLabel As System.Windows.Forms.Label
    Friend WithEvents SkipBytesTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CustomSpriteArtButton As System.Windows.Forms.Button
    Public WithEvents WidthTextBox As System.Windows.Forms.TextBox
    Public WithEvents HeightTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PaletteInserterButton As System.Windows.Forms.Button
    Friend WithEvents CancelSpriteInsertionButton As System.Windows.Forms.Button
    Friend WithEvents SettingsButton As System.Windows.Forms.Button
    Friend WithEvents WidthLabel As System.Windows.Forms.Label
    Friend WithEvents CreateOWSTableButton As System.Windows.Forms.Button
    Friend WithEvents PaletteFixButton As System.Windows.Forms.Button
    Friend WithEvents ViewTableButton As System.Windows.Forms.Button
    Friend WithEvents HistoryButton As System.Windows.Forms.Button
    Friend WithEvents Log As System.Windows.Forms.RichTextBox
    Friend WithEvents SelectOWSTablePanel As System.Windows.Forms.Panel
    Friend WithEvents SelectOWSTableGroupBox As System.Windows.Forms.GroupBox

End Class
