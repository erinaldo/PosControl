<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRepDeliveryDiscrepancy
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRepDeliveryDiscrepancy))
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.CmbPos = New DevExpress.XtraEditors.LookUpEdit()
        Me.RgCleared = New DevExpress.XtraEditors.RadioGroup()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.dtpFrom = New DevExpress.XtraEditors.DateEdit()
        Me.dtpTill = New DevExpress.XtraEditors.DateEdit()
        CType(Me.CmbPos.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RgCleared.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpTill.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpTill.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 74)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(45, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Pos Code"
        '
        'CmbPos
        '
        Me.CmbPos.Location = New System.Drawing.Point(90, 71)
        Me.CmbPos.Name = "CmbPos"
        Me.CmbPos.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CmbPos.Size = New System.Drawing.Size(134, 20)
        Me.CmbPos.TabIndex = 1
        '
        'RgCleared
        '
        Me.RgCleared.Location = New System.Drawing.Point(90, 109)
        Me.RgCleared.Name = "RgCleared"
        Me.RgCleared.Properties.Columns = 3
        Me.RgCleared.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(-1, "All"), New DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Cleared"), New DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Not Cleared")})
        Me.RgCleared.Size = New System.Drawing.Size(261, 26)
        Me.RgCleared.TabIndex = 2
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 115)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(31, 13)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "Status"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl3.TabIndex = 4
        Me.LabelControl3.Text = "From"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(12, 42)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(12, 13)
        Me.LabelControl4.TabIndex = 5
        Me.LabelControl4.Text = "Till"
        '
        'dtpFrom
        '
        Me.dtpFrom.EditValue = Nothing
        Me.dtpFrom.Location = New System.Drawing.Point(90, 8)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Properties.AutoHeight = False
        Me.dtpFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtpFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtpFrom.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.TouchUI
        Me.dtpFrom.Properties.DisplayFormat.FormatString = " dd/MM/yyyy"
        Me.dtpFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtpFrom.Properties.EditFormat.FormatString = " dd/MM/yyyy"
        Me.dtpFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtpFrom.Properties.Mask.EditMask = " dd/MM/yyyy"
        Me.dtpFrom.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.dtpFrom.Properties.NullText = "Select Date"
        Me.dtpFrom.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[False]
        Me.dtpFrom.Size = New System.Drawing.Size(142, 22)
        Me.dtpFrom.TabIndex = 113
        '
        'dtpTill
        '
        Me.dtpTill.EditValue = Nothing
        Me.dtpTill.Location = New System.Drawing.Point(90, 38)
        Me.dtpTill.Name = "dtpTill"
        Me.dtpTill.Properties.AutoHeight = False
        Me.dtpTill.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtpTill.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtpTill.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.TouchUI
        Me.dtpTill.Properties.DisplayFormat.FormatString = " dd/MM/yyyy"
        Me.dtpTill.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtpTill.Properties.EditFormat.FormatString = " dd/MM/yyyy"
        Me.dtpTill.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtpTill.Properties.Mask.EditMask = " dd/MM/yyyy"
        Me.dtpTill.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.dtpTill.Properties.NullText = "Select Date"
        Me.dtpTill.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[False]
        Me.dtpTill.Size = New System.Drawing.Size(142, 22)
        Me.dtpTill.TabIndex = 114
        '
        'FrmRepDeliveryDiscrepancy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(441, 143)
        Me.Controls.Add(Me.dtpTill)
        Me.Controls.Add(Me.dtpFrom)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.RgCleared)
        Me.Controls.Add(Me.CmbPos)
        Me.Controls.Add(Me.LabelControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmRepDeliveryDiscrepancy"
        Me.Text = "Delivery Discrepancy Report"
        CType(Me.CmbPos.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RgCleared.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpTill.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpTill.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CmbPos As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents RgCleared As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents dtpFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents dtpTill As DevExpress.XtraEditors.DateEdit
End Class
