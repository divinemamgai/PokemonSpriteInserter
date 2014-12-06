<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RichTextBox1)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TextBox3)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TextBox6)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(13, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(480, 174)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Palette Adder"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.RichTextBox1.Location = New System.Drawing.Point(7, 14)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.Size = New System.Drawing.Size(467, 154)
        Me.RichTextBox1.TabIndex = 27
        Me.RichTextBox1.Text = ""
        '
        'TextBox2
        '
        Me.TextBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(383, 137)
        Me.TextBox2.MaxLength = 6
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(83, 23)
        Me.TextBox2.TabIndex = 25
        Me.TextBox2.Tag = "800000"
        Me.TextBox2.Text = "800000"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(241, 140)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(142, 15)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Search Free Space From :"
        '
        'TextBox3
        '
        Me.TextBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(130, 137)
        Me.TextBox3.MaxLength = 6
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(83, 23)
        Me.TextBox3.TabIndex = 23
        Me.TextBox3.Tag = "000000"
        Me.TextBox3.Text = "000000"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 140)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 15)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Palette Data Offset :"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(15, 112)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(381, 19)
        Me.CheckBox1.TabIndex = 22
        Me.CheckBox1.Text = "Use Built-In Free Space Finder For Palette Data Offset Generation"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(288, 14)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(186, 29)
        Me.Button2.TabIndex = 21
        Me.Button2.Text = "Default Hero Palette Hex Data"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(116, 51)
        Me.TextBox1.MaxLength = 128
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(326, 55)
        Me.TextBox1.TabIndex = 18
        Me.TextBox1.Tag = "F051F5211F4B5B3A0F210869E73C8E62AD14BD7FD66ABF25F81C7F2F771E00000E53F5211F4B5B3A0" & _
    "F210869E73C8E62AD14BD7FD66ABF25F81C7F2F771E0000"
        Me.TextBox1.Text = "F051F5211F4B5B3A0F210869E73C8E62AD14BD7FD66ABF25F81C7F2F771E00000E53F5211F4B5B3A0" & _
    "F210869E73C8E62AD14BD7FD66ABF25F81C7F2F771E0000"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 15)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Palette Hex Data :"
        '
        'TextBox6
        '
        Me.TextBox6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox6.Location = New System.Drawing.Point(165, 22)
        Me.TextBox6.MaxLength = 3
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox6.Size = New System.Drawing.Size(70, 23)
        Me.TextBox6.TabIndex = 16
        Me.TextBox6.Tag = "0"
        Me.TextBox6.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(153, 15)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Palette Number [Decimal] :"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(12, 193)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(481, 29)
        Me.Button1.TabIndex = 20
        Me.Button1.Text = "Add Palette"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(13, 193)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(481, 29)
        Me.Button3.TabIndex = 21
        Me.Button3.Text = "Back"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Form5
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(505, 234)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form5"
        Me.Text = "Pokemon Sprite Inserter - Palette"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
