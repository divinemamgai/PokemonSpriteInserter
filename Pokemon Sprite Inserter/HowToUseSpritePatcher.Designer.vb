<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HowToUseSpritePatcher
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HowToUseSpritePatcher))
        Me.HowToUseRichTextBox = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'HowToUseRichTextBox
        '
        Me.HowToUseRichTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.HowToUseRichTextBox.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HowToUseRichTextBox.Location = New System.Drawing.Point(13, 13)
        Me.HowToUseRichTextBox.Name = "HowToUseRichTextBox"
        Me.HowToUseRichTextBox.ReadOnly = True
        Me.HowToUseRichTextBox.Size = New System.Drawing.Size(540, 549)
        Me.HowToUseRichTextBox.TabIndex = 0
        Me.HowToUseRichTextBox.Text = ""
        '
        'HowToUseSpritePatcher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(565, 574)
        Me.Controls.Add(Me.HowToUseRichTextBox)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "HowToUseSpritePatcher"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "How To Use Sprite Patcher?"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents HowToUseRichTextBox As System.Windows.Forms.RichTextBox
End Class
