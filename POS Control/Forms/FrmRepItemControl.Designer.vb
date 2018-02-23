<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRepItemControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRepItemControl))
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.CmbWHS = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.RgCleared = New DevExpress.XtraEditors.RadioGroup()
        Me.CmbItems = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.CmbWHS.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RgCleared.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmbItems.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(9, 21)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "WHS"
        '
        'CmbWHS
        '
        Me.CmbWHS.Location = New System.Drawing.Point(71, 18)
        Me.CmbWHS.Name = "CmbWHS"
        Me.CmbWHS.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CmbWHS.Size = New System.Drawing.Size(134, 20)
        Me.CmbWHS.TabIndex = 2
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(9, 90)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(31, 13)
        Me.LabelControl2.TabIndex = 5
        Me.LabelControl2.Text = "Status"
        '
        'RgCleared
        '
        Me.RgCleared.Location = New System.Drawing.Point(71, 84)
        Me.RgCleared.Name = "RgCleared"
        Me.RgCleared.Properties.Columns = 3
        Me.RgCleared.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(-1, "All"), New DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Blocked"), New DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Not Blocked")})
        Me.RgCleared.Size = New System.Drawing.Size(261, 26)
        Me.RgCleared.TabIndex = 4
        '
        'CmbItems
        '
        Me.CmbItems.Location = New System.Drawing.Point(71, 51)
        Me.CmbItems.Name = "CmbItems"
        Me.CmbItems.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CmbItems.Size = New System.Drawing.Size(134, 20)
        Me.CmbItems.TabIndex = 7
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(9, 54)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(27, 13)
        Me.LabelControl3.TabIndex = 6
        Me.LabelControl3.Text = "Items"
        '
        'FrmRepItemControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(360, 122)
        Me.Controls.Add(Me.CmbItems)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.RgCleared)
        Me.Controls.Add(Me.CmbWHS)
        Me.Controls.Add(Me.LabelControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmRepItemControl"
        Me.Text = "Item Control Report"
        CType(Me.CmbWHS.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RgCleared.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmbItems.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CmbWHS As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents RgCleared As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents CmbItems As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
End Class
