<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreateOWSTable
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CreateOWSTable))
        Me.CreateEmptyOWSTableGroupBox = New System.Windows.Forms.GroupBox()
        Me.Log = New System.Windows.Forms.RichTextBox()
        Me.NumberOfSpritesTextBox = New System.Windows.Forms.TextBox()
        Me.NumberOfSpritesLabel = New System.Windows.Forms.Label()
        Me.OWSTableOffsetTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.StartOffsetTextBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.FreeSpaceCheckBox = New System.Windows.Forms.CheckBox()
        Me.OWSTableEmptyByteTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.InsertTableButton = New System.Windows.Forms.Button()
        Me.BackButton = New System.Windows.Forms.Button()
        Me.CreateEmptyOWSTableGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'CreateEmptyOWSTableGroupBox
        '
        Me.CreateEmptyOWSTableGroupBox.Controls.Add(Me.Log)
        Me.CreateEmptyOWSTableGroupBox.Controls.Add(Me.NumberOfSpritesTextBox)
        Me.CreateEmptyOWSTableGroupBox.Controls.Add(Me.NumberOfSpritesLabel)
        Me.CreateEmptyOWSTableGroupBox.Controls.Add(Me.OWSTableOffsetTextBox)
        Me.CreateEmptyOWSTableGroupBox.Controls.Add(Me.Label2)
        Me.CreateEmptyOWSTableGroupBox.Controls.Add(Me.StartOffsetTextBox)
        Me.CreateEmptyOWSTableGroupBox.Controls.Add(Me.Label3)
        Me.CreateEmptyOWSTableGroupBox.Controls.Add(Me.FreeSpaceCheckBox)
        Me.CreateEmptyOWSTableGroupBox.Controls.Add(Me.OWSTableEmptyByteTextBox)
        Me.CreateEmptyOWSTableGroupBox.Controls.Add(Me.Label1)
        Me.CreateEmptyOWSTableGroupBox.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CreateEmptyOWSTableGroupBox.Location = New System.Drawing.Point(13, 13)
        Me.CreateEmptyOWSTableGroupBox.Name = "CreateEmptyOWSTableGroupBox"
        Me.CreateEmptyOWSTableGroupBox.Size = New System.Drawing.Size(478, 146)
        Me.CreateEmptyOWSTableGroupBox.TabIndex = 0
        Me.CreateEmptyOWSTableGroupBox.TabStop = False
        Me.CreateEmptyOWSTableGroupBox.Text = "Create Empty OWS Table"
        '
        'Log
        '
        Me.Log.Location = New System.Drawing.Point(7, 22)
        Me.Log.Name = "Log"
        Me.Log.Size = New System.Drawing.Size(465, 118)
        Me.Log.TabIndex = 21
        Me.Log.Text = ""
        '
        'NumberOfSpritesTextBox
        '
        Me.NumberOfSpritesTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.NumberOfSpritesTextBox.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumberOfSpritesTextBox.Location = New System.Drawing.Point(351, 39)
        Me.NumberOfSpritesTextBox.MaxLength = 3
        Me.NumberOfSpritesTextBox.Name = "NumberOfSpritesTextBox"
        Me.NumberOfSpritesTextBox.Size = New System.Drawing.Size(53, 23)
        Me.NumberOfSpritesTextBox.TabIndex = 22
        Me.NumberOfSpritesTextBox.Tag = "100"
        Me.NumberOfSpritesTextBox.Text = "100"
        '
        'NumberOfSpritesLabel
        '
        Me.NumberOfSpritesLabel.AutoSize = True
        Me.NumberOfSpritesLabel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumberOfSpritesLabel.Location = New System.Drawing.Point(238, 42)
        Me.NumberOfSpritesLabel.Name = "NumberOfSpritesLabel"
        Me.NumberOfSpritesLabel.Size = New System.Drawing.Size(113, 15)
        Me.NumberOfSpritesLabel.TabIndex = 23
        Me.NumberOfSpritesLabel.Text = "Number Of Sprites :"
        '
        'OWSTableOffsetTextBox
        '
        Me.OWSTableOffsetTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.OWSTableOffsetTextBox.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OWSTableOffsetTextBox.Location = New System.Drawing.Point(345, 99)
        Me.OWSTableOffsetTextBox.MaxLength = 6
        Me.OWSTableOffsetTextBox.Name = "OWSTableOffsetTextBox"
        Me.OWSTableOffsetTextBox.Size = New System.Drawing.Size(126, 23)
        Me.OWSTableOffsetTextBox.TabIndex = 19
        Me.OWSTableOffsetTextBox.Tag = "000000"
        Me.OWSTableOffsetTextBox.Text = "000000"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(238, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 15)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "OWS Table Offset :"
        '
        'StartOffsetTextBox
        '
        Me.StartOffsetTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.StartOffsetTextBox.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StartOffsetTextBox.Location = New System.Drawing.Point(89, 99)
        Me.StartOffsetTextBox.MaxLength = 6
        Me.StartOffsetTextBox.Name = "StartOffsetTextBox"
        Me.StartOffsetTextBox.Size = New System.Drawing.Size(126, 23)
        Me.StartOffsetTextBox.TabIndex = 10
        Me.StartOffsetTextBox.Tag = "800000"
        Me.StartOffsetTextBox.Text = "800000"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 15)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Start Offset :"
        '
        'FreeSpaceCheckBox
        '
        Me.FreeSpaceCheckBox.AutoSize = True
        Me.FreeSpaceCheckBox.Checked = True
        Me.FreeSpaceCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.FreeSpaceCheckBox.Location = New System.Drawing.Point(17, 73)
        Me.FreeSpaceCheckBox.Name = "FreeSpaceCheckBox"
        Me.FreeSpaceCheckBox.Size = New System.Drawing.Size(331, 19)
        Me.FreeSpaceCheckBox.TabIndex = 9
        Me.FreeSpaceCheckBox.Text = "Use Built-In Free Space Finder To Search For Table Offset"
        Me.FreeSpaceCheckBox.UseVisualStyleBackColor = True
        '
        'OWSTableEmptyByteTextBox
        '
        Me.OWSTableEmptyByteTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.OWSTableEmptyByteTextBox.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OWSTableEmptyByteTextBox.Location = New System.Drawing.Point(148, 39)
        Me.OWSTableEmptyByteTextBox.MaxLength = 2
        Me.OWSTableEmptyByteTextBox.Name = "OWSTableEmptyByteTextBox"
        Me.OWSTableEmptyByteTextBox.Size = New System.Drawing.Size(67, 23)
        Me.OWSTableEmptyByteTextBox.TabIndex = 8
        Me.OWSTableEmptyByteTextBox.Tag = "BB"
        Me.OWSTableEmptyByteTextBox.Text = "BB"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 15)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "OWS Table Empty Byte : "
        '
        'InsertTableButton
        '
        Me.InsertTableButton.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InsertTableButton.Location = New System.Drawing.Point(13, 167)
        Me.InsertTableButton.Name = "InsertTableButton"
        Me.InsertTableButton.Size = New System.Drawing.Size(478, 26)
        Me.InsertTableButton.TabIndex = 1
        Me.InsertTableButton.Text = "Insert Table"
        Me.InsertTableButton.UseVisualStyleBackColor = True
        '
        'BackButton
        '
        Me.BackButton.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BackButton.Location = New System.Drawing.Point(12, 167)
        Me.BackButton.Name = "BackButton"
        Me.BackButton.Size = New System.Drawing.Size(479, 26)
        Me.BackButton.TabIndex = 2
        Me.BackButton.Text = "Back"
        Me.BackButton.UseVisualStyleBackColor = True
        '
        'Form8
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(503, 205)
        Me.Controls.Add(Me.CreateEmptyOWSTableGroupBox)
        Me.Controls.Add(Me.BackButton)
        Me.Controls.Add(Me.InsertTableButton)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form8"
        Me.Text = "Pokemon Sprite Inserter - Table Creator"
        Me.CreateEmptyOWSTableGroupBox.ResumeLayout(False)
        Me.CreateEmptyOWSTableGroupBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CreateEmptyOWSTableGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents OWSTableEmptyByteTextBox As System.Windows.Forms.TextBox
    Friend WithEvents FreeSpaceCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents StartOffsetTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents OWSTableOffsetTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents InsertTableButton As System.Windows.Forms.Button
    Friend WithEvents Log As System.Windows.Forms.RichTextBox
    Friend WithEvents NumberOfSpritesTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NumberOfSpritesLabel As System.Windows.Forms.Label
    Friend WithEvents BackButton As System.Windows.Forms.Button
End Class
