<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Export
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Export))
        Me.ExportTypeGroupBox = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ExportAllButton = New System.Windows.Forms.Button()
        Me.ExportCurrentButton = New System.Windows.Forms.Button()
        Me.ExportTypeGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExportTypeGroupBox
        '
        Me.ExportTypeGroupBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExportTypeGroupBox.Controls.Add(Me.Label1)
        Me.ExportTypeGroupBox.Controls.Add(Me.ExportAllButton)
        Me.ExportTypeGroupBox.Controls.Add(Me.ExportCurrentButton)
        Me.ExportTypeGroupBox.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExportTypeGroupBox.Location = New System.Drawing.Point(13, 13)
        Me.ExportTypeGroupBox.Name = "ExportTypeGroupBox"
        Me.ExportTypeGroupBox.Size = New System.Drawing.Size(207, 121)
        Me.ExportTypeGroupBox.TabIndex = 0
        Me.ExportTypeGroupBox.TabStop = False
        Me.ExportTypeGroupBox.Text = "Export Type"
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(6, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(195, 41)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "How do you want to perform export operation?"
        '
        'ExportAllButton
        '
        Me.ExportAllButton.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExportAllButton.Location = New System.Drawing.Point(6, 92)
        Me.ExportAllButton.Name = "ExportAllButton"
        Me.ExportAllButton.Size = New System.Drawing.Size(195, 23)
        Me.ExportAllButton.TabIndex = 1
        Me.ExportAllButton.Text = "Export All Frames"
        Me.ExportAllButton.UseVisualStyleBackColor = True
        '
        'ExportCurrentButton
        '
        Me.ExportCurrentButton.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExportCurrentButton.Location = New System.Drawing.Point(6, 63)
        Me.ExportCurrentButton.Name = "ExportCurrentButton"
        Me.ExportCurrentButton.Size = New System.Drawing.Size(195, 23)
        Me.ExportCurrentButton.TabIndex = 0
        Me.ExportCurrentButton.Text = "Export Current Frame"
        Me.ExportCurrentButton.UseVisualStyleBackColor = True
        '
        'Export
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(232, 146)
        Me.Controls.Add(Me.ExportTypeGroupBox)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Export"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Export"
        Me.ExportTypeGroupBox.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ExportTypeGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents ExportAllButton As System.Windows.Forms.Button
    Friend WithEvents ExportCurrentButton As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
