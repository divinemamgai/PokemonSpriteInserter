<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewTables
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewTables))
        Me.TableTabControl = New System.Windows.Forms.TabControl()
        Me.OWSTablePage = New System.Windows.Forms.TabPage()
        Me.PaletteTablePage = New System.Windows.Forms.TabPage()
        Me.TableTabControl.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableTabControl
        '
        Me.TableTabControl.Controls.Add(Me.OWSTablePage)
        Me.TableTabControl.Controls.Add(Me.PaletteTablePage)
        Me.TableTabControl.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableTabControl.Location = New System.Drawing.Point(13, 13)
        Me.TableTabControl.Name = "TableTabControl"
        Me.TableTabControl.SelectedIndex = 0
        Me.TableTabControl.Size = New System.Drawing.Size(586, 540)
        Me.TableTabControl.TabIndex = 0
        '
        'OWSTablePage
        '
        Me.OWSTablePage.Location = New System.Drawing.Point(4, 24)
        Me.OWSTablePage.Name = "OWSTablePage"
        Me.OWSTablePage.Padding = New System.Windows.Forms.Padding(3)
        Me.OWSTablePage.Size = New System.Drawing.Size(578, 512)
        Me.OWSTablePage.TabIndex = 0
        Me.OWSTablePage.Text = "OWS Table Browser"
        Me.OWSTablePage.UseVisualStyleBackColor = True
        '
        'PaletteTablePage
        '
        Me.PaletteTablePage.Location = New System.Drawing.Point(4, 24)
        Me.PaletteTablePage.Name = "PaletteTablePage"
        Me.PaletteTablePage.Padding = New System.Windows.Forms.Padding(3)
        Me.PaletteTablePage.Size = New System.Drawing.Size(553, 208)
        Me.PaletteTablePage.TabIndex = 1
        Me.PaletteTablePage.Text = "Palette Table Browser"
        Me.PaletteTablePage.UseVisualStyleBackColor = True
        '
        'ViewTables
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(611, 565)
        Me.Controls.Add(Me.TableTabControl)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ViewTables"
        Me.Text = "Pokemon Sprite Inserter - View Tables"
        Me.TableTabControl.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableTabControl As System.Windows.Forms.TabControl
    Friend WithEvents OWSTablePage As System.Windows.Forms.TabPage
    Friend WithEvents PaletteTablePage As System.Windows.Forms.TabPage
End Class
