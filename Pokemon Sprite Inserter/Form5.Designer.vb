﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form5
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form5))
        Me.PaletteAdderGroupBox = New System.Windows.Forms.GroupBox()
        Me.Log = New System.Windows.Forms.RichTextBox()
        Me.FreeSpaceStartTextBox = New System.Windows.Forms.TextBox()
        Me.FreeSpaceFromLabel = New System.Windows.Forms.Label()
        Me.PaletteOffsetTextBox = New System.Windows.Forms.TextBox()
        Me.PaletteDataOffsetLabel = New System.Windows.Forms.Label()
        Me.FreeSpaceCheckBox = New System.Windows.Forms.CheckBox()
        Me.DefaultPaletteButton = New System.Windows.Forms.Button()
        Me.PaletteHexDataTextBox = New System.Windows.Forms.TextBox()
        Me.PaletteHexDataLabel = New System.Windows.Forms.Label()
        Me.PaletteNumberTextBox = New System.Windows.Forms.TextBox()
        Me.PaletteNumberLabel = New System.Windows.Forms.Label()
        Me.InsertPaletteButton = New System.Windows.Forms.Button()
        Me.BackButton = New System.Windows.Forms.Button()
        Me.PaletteAdderGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'PaletteAdderGroupBox
        '
        Me.PaletteAdderGroupBox.Controls.Add(Me.Log)
        Me.PaletteAdderGroupBox.Controls.Add(Me.FreeSpaceStartTextBox)
        Me.PaletteAdderGroupBox.Controls.Add(Me.FreeSpaceFromLabel)
        Me.PaletteAdderGroupBox.Controls.Add(Me.PaletteOffsetTextBox)
        Me.PaletteAdderGroupBox.Controls.Add(Me.PaletteDataOffsetLabel)
        Me.PaletteAdderGroupBox.Controls.Add(Me.FreeSpaceCheckBox)
        Me.PaletteAdderGroupBox.Controls.Add(Me.DefaultPaletteButton)
        Me.PaletteAdderGroupBox.Controls.Add(Me.PaletteHexDataTextBox)
        Me.PaletteAdderGroupBox.Controls.Add(Me.PaletteHexDataLabel)
        Me.PaletteAdderGroupBox.Controls.Add(Me.PaletteNumberTextBox)
        Me.PaletteAdderGroupBox.Controls.Add(Me.PaletteNumberLabel)
        Me.PaletteAdderGroupBox.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PaletteAdderGroupBox.Location = New System.Drawing.Point(13, 13)
        Me.PaletteAdderGroupBox.Name = "PaletteAdderGroupBox"
        Me.PaletteAdderGroupBox.Size = New System.Drawing.Size(480, 174)
        Me.PaletteAdderGroupBox.TabIndex = 0
        Me.PaletteAdderGroupBox.TabStop = False
        Me.PaletteAdderGroupBox.Text = "Palette Adder"
        '
        'Log
        '
        Me.Log.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Log.Location = New System.Drawing.Point(7, 14)
        Me.Log.Name = "Log"
        Me.Log.ReadOnly = True
        Me.Log.Size = New System.Drawing.Size(467, 154)
        Me.Log.TabIndex = 27
        Me.Log.Text = ""
        '
        'FreeSpaceStartTextBox
        '
        Me.FreeSpaceStartTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.FreeSpaceStartTextBox.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FreeSpaceStartTextBox.Location = New System.Drawing.Point(383, 137)
        Me.FreeSpaceStartTextBox.MaxLength = 6
        Me.FreeSpaceStartTextBox.Name = "FreeSpaceStartTextBox"
        Me.FreeSpaceStartTextBox.Size = New System.Drawing.Size(83, 23)
        Me.FreeSpaceStartTextBox.TabIndex = 25
        Me.FreeSpaceStartTextBox.Tag = "800000"
        Me.FreeSpaceStartTextBox.Text = "800000"
        '
        'FreeSpaceFromLabel
        '
        Me.FreeSpaceFromLabel.AutoSize = True
        Me.FreeSpaceFromLabel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FreeSpaceFromLabel.Location = New System.Drawing.Point(241, 140)
        Me.FreeSpaceFromLabel.Name = "FreeSpaceFromLabel"
        Me.FreeSpaceFromLabel.Size = New System.Drawing.Size(142, 15)
        Me.FreeSpaceFromLabel.TabIndex = 26
        Me.FreeSpaceFromLabel.Text = "Search Free Space From :"
        '
        'PaletteOffsetTextBox
        '
        Me.PaletteOffsetTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.PaletteOffsetTextBox.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PaletteOffsetTextBox.Location = New System.Drawing.Point(130, 137)
        Me.PaletteOffsetTextBox.MaxLength = 6
        Me.PaletteOffsetTextBox.Name = "PaletteOffsetTextBox"
        Me.PaletteOffsetTextBox.Size = New System.Drawing.Size(83, 23)
        Me.PaletteOffsetTextBox.TabIndex = 23
        Me.PaletteOffsetTextBox.Tag = "000000"
        Me.PaletteOffsetTextBox.Text = "000000"
        '
        'PaletteDataOffsetLabel
        '
        Me.PaletteDataOffsetLabel.AutoSize = True
        Me.PaletteDataOffsetLabel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PaletteDataOffsetLabel.Location = New System.Drawing.Point(15, 140)
        Me.PaletteDataOffsetLabel.Name = "PaletteDataOffsetLabel"
        Me.PaletteDataOffsetLabel.Size = New System.Drawing.Size(116, 15)
        Me.PaletteDataOffsetLabel.TabIndex = 24
        Me.PaletteDataOffsetLabel.Text = "Palette Data Offset :"
        '
        'FreeSpaceCheckBox
        '
        Me.FreeSpaceCheckBox.AutoSize = True
        Me.FreeSpaceCheckBox.Location = New System.Drawing.Point(15, 112)
        Me.FreeSpaceCheckBox.Name = "FreeSpaceCheckBox"
        Me.FreeSpaceCheckBox.Size = New System.Drawing.Size(381, 19)
        Me.FreeSpaceCheckBox.TabIndex = 22
        Me.FreeSpaceCheckBox.Text = "Use Built-In Free Space Finder For Palette Data Offset Generation"
        Me.FreeSpaceCheckBox.UseVisualStyleBackColor = True
        '
        'DefaultPaletteButton
        '
        Me.DefaultPaletteButton.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DefaultPaletteButton.Location = New System.Drawing.Point(288, 14)
        Me.DefaultPaletteButton.Name = "DefaultPaletteButton"
        Me.DefaultPaletteButton.Size = New System.Drawing.Size(186, 29)
        Me.DefaultPaletteButton.TabIndex = 21
        Me.DefaultPaletteButton.Text = "Default Hero Palette Hex Data"
        Me.DefaultPaletteButton.UseVisualStyleBackColor = True
        '
        'PaletteHexDataTextBox
        '
        Me.PaletteHexDataTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.PaletteHexDataTextBox.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PaletteHexDataTextBox.Location = New System.Drawing.Point(116, 51)
        Me.PaletteHexDataTextBox.MaxLength = 128
        Me.PaletteHexDataTextBox.Multiline = True
        Me.PaletteHexDataTextBox.Name = "PaletteHexDataTextBox"
        Me.PaletteHexDataTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.PaletteHexDataTextBox.Size = New System.Drawing.Size(326, 55)
        Me.PaletteHexDataTextBox.TabIndex = 18
        Me.PaletteHexDataTextBox.Tag = "F051F5211F4B5B3A0F210869E73C8E62AD14BD7FD66ABF25F81C7F2F771E00000E53F5211F4B5B3A0" & _
    "F210869E73C8E62AD14BD7FD66ABF25F81C7F2F771E0000"
        Me.PaletteHexDataTextBox.Text = "F051F5211F4B5B3A0F210869E73C8E62AD14BD7FD66ABF25F81C7F2F771E00000E53F5211F4B5B3A0" & _
    "F210869E73C8E62AD14BD7FD66ABF25F81C7F2F771E0000"
        '
        'PaletteHexDataLabel
        '
        Me.PaletteHexDataLabel.AutoSize = True
        Me.PaletteHexDataLabel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PaletteHexDataLabel.Location = New System.Drawing.Point(12, 54)
        Me.PaletteHexDataLabel.Name = "PaletteHexDataLabel"
        Me.PaletteHexDataLabel.Size = New System.Drawing.Size(103, 15)
        Me.PaletteHexDataLabel.TabIndex = 17
        Me.PaletteHexDataLabel.Text = "Palette Hex Data :"
        '
        'PaletteNumberTextBox
        '
        Me.PaletteNumberTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.PaletteNumberTextBox.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PaletteNumberTextBox.Location = New System.Drawing.Point(165, 22)
        Me.PaletteNumberTextBox.MaxLength = 3
        Me.PaletteNumberTextBox.Name = "PaletteNumberTextBox"
        Me.PaletteNumberTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.PaletteNumberTextBox.Size = New System.Drawing.Size(70, 23)
        Me.PaletteNumberTextBox.TabIndex = 16
        Me.PaletteNumberTextBox.Tag = "0"
        Me.PaletteNumberTextBox.Text = "0"
        '
        'PaletteNumberLabel
        '
        Me.PaletteNumberLabel.AutoSize = True
        Me.PaletteNumberLabel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PaletteNumberLabel.Location = New System.Drawing.Point(12, 25)
        Me.PaletteNumberLabel.Name = "PaletteNumberLabel"
        Me.PaletteNumberLabel.Size = New System.Drawing.Size(153, 15)
        Me.PaletteNumberLabel.TabIndex = 11
        Me.PaletteNumberLabel.Text = "Palette Number [Decimal] :"
        '
        'InsertPaletteButton
        '
        Me.InsertPaletteButton.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InsertPaletteButton.Location = New System.Drawing.Point(12, 193)
        Me.InsertPaletteButton.Name = "InsertPaletteButton"
        Me.InsertPaletteButton.Size = New System.Drawing.Size(481, 29)
        Me.InsertPaletteButton.TabIndex = 20
        Me.InsertPaletteButton.Text = "Insert Palette"
        Me.InsertPaletteButton.UseVisualStyleBackColor = True
        '
        'BackButton
        '
        Me.BackButton.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BackButton.Location = New System.Drawing.Point(13, 193)
        Me.BackButton.Name = "BackButton"
        Me.BackButton.Size = New System.Drawing.Size(481, 29)
        Me.BackButton.TabIndex = 21
        Me.BackButton.Text = "Back"
        Me.BackButton.UseVisualStyleBackColor = True
        '
        'Form5
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(505, 234)
        Me.Controls.Add(Me.BackButton)
        Me.Controls.Add(Me.InsertPaletteButton)
        Me.Controls.Add(Me.PaletteAdderGroupBox)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form5"
        Me.Text = "Pokemon Sprite Inserter - Palette"
        Me.PaletteAdderGroupBox.ResumeLayout(False)
        Me.PaletteAdderGroupBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PaletteAdderGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents PaletteNumberLabel As System.Windows.Forms.Label
    Friend WithEvents PaletteNumberTextBox As System.Windows.Forms.TextBox
    Friend WithEvents InsertPaletteButton As System.Windows.Forms.Button
    Friend WithEvents PaletteHexDataLabel As System.Windows.Forms.Label
    Friend WithEvents PaletteHexDataTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DefaultPaletteButton As System.Windows.Forms.Button
    Friend WithEvents FreeSpaceCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents PaletteOffsetTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PaletteDataOffsetLabel As System.Windows.Forms.Label
    Friend WithEvents FreeSpaceStartTextBox As System.Windows.Forms.TextBox
    Friend WithEvents FreeSpaceFromLabel As System.Windows.Forms.Label
    Friend WithEvents Log As System.Windows.Forms.RichTextBox
    Friend WithEvents BackButton As System.Windows.Forms.Button
End Class
