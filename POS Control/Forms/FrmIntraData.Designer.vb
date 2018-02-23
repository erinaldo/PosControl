<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmIntraData
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmIntraData))
        Me.btnSendTransfers = New DevExpress.XtraEditors.SimpleButton()
        Me.lblFrom = New DevExpress.XtraEditors.LabelControl()
        Me.lblto = New DevExpress.XtraEditors.LabelControl()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnGenerate = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl14 = New DevExpress.XtraEditors.LabelControl()
        Me.dtpCriteriaTill = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.DtpCriteriaFrom = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.dtptransfertill = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.dtptransferfrom = New DevExpress.XtraEditors.DateEdit()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.ProgressBarControl1 = New DevExpress.XtraEditors.ProgressBarControl()
        Me.BackgroundWorker2 = New System.ComponentModel.BackgroundWorker()
        Me.CBWhs = New DevExpress.XtraEditors.CheckEdit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dtpCriteriaTill.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpCriteriaTill.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtpCriteriaFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtpCriteriaFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtptransfertill.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtptransfertill.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtptransferfrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtptransferfrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CBWhs.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSendTransfers
        '
        Me.btnSendTransfers.Location = New System.Drawing.Point(161, 57)
        Me.btnSendTransfers.Name = "btnSendTransfers"
        Me.btnSendTransfers.Size = New System.Drawing.Size(233, 23)
        Me.btnSendTransfers.TabIndex = 0
        Me.btnSendTransfers.Text = "Send Transfers"
        '
        'lblFrom
        '
        Me.lblFrom.Location = New System.Drawing.Point(161, 37)
        Me.lblFrom.Name = "lblFrom"
        Me.lblFrom.Size = New System.Drawing.Size(66, 13)
        Me.lblFrom.TabIndex = 1
        Me.lblFrom.Text = "LabelControl1"
        '
        'lblto
        '
        Me.lblto.Location = New System.Drawing.Point(328, 37)
        Me.lblto.Name = "lblto"
        Me.lblto.Size = New System.Drawing.Size(66, 13)
        Me.lblto.TabIndex = 2
        Me.lblto.Text = "LabelControl1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CBWhs)
        Me.GroupBox1.Controls.Add(Me.btnGenerate)
        Me.GroupBox1.Controls.Add(Me.LabelControl14)
        Me.GroupBox1.Controls.Add(Me.dtpCriteriaTill)
        Me.GroupBox1.Controls.Add(Me.LabelControl12)
        Me.GroupBox1.Controls.Add(Me.DtpCriteriaFrom)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 101)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(581, 102)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sales / Purchases"
        '
        'btnGenerate
        '
        Me.btnGenerate.Location = New System.Drawing.Point(149, 65)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(233, 23)
        Me.btnGenerate.TabIndex = 123
        Me.btnGenerate.Text = "Generate"
        '
        'LabelControl14
        '
        Me.LabelControl14.Location = New System.Drawing.Point(299, 25)
        Me.LabelControl14.Name = "LabelControl14"
        Me.LabelControl14.Size = New System.Drawing.Size(38, 13)
        Me.LabelControl14.TabIndex = 121
        Me.LabelControl14.Text = "Till Date"
        '
        'dtpCriteriaTill
        '
        Me.dtpCriteriaTill.EditValue = Nothing
        Me.dtpCriteriaTill.Location = New System.Drawing.Point(354, 20)
        Me.dtpCriteriaTill.Name = "dtpCriteriaTill"
        Me.dtpCriteriaTill.Properties.AutoHeight = False
        Me.dtpCriteriaTill.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtpCriteriaTill.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtpCriteriaTill.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.TouchUI
        Me.dtpCriteriaTill.Properties.DisplayFormat.FormatString = " dd/MM/yyyy"
        Me.dtpCriteriaTill.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtpCriteriaTill.Properties.EditFormat.FormatString = " dd/MM/yyyy"
        Me.dtpCriteriaTill.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtpCriteriaTill.Properties.Mask.EditMask = " dd/MM/yyyy"
        Me.dtpCriteriaTill.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.dtpCriteriaTill.Properties.NullText = "Select Till Date"
        Me.dtpCriteriaTill.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[False]
        Me.dtpCriteriaTill.Size = New System.Drawing.Size(142, 22)
        Me.dtpCriteriaTill.TabIndex = 122
        '
        'LabelControl12
        '
        Me.LabelControl12.Location = New System.Drawing.Point(20, 24)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(50, 13)
        Me.LabelControl12.TabIndex = 119
        Me.LabelControl12.Text = "From Date"
        '
        'DtpCriteriaFrom
        '
        Me.DtpCriteriaFrom.EditValue = Nothing
        Me.DtpCriteriaFrom.Location = New System.Drawing.Point(87, 19)
        Me.DtpCriteriaFrom.Name = "DtpCriteriaFrom"
        Me.DtpCriteriaFrom.Properties.AutoHeight = False
        Me.DtpCriteriaFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DtpCriteriaFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DtpCriteriaFrom.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.TouchUI
        Me.DtpCriteriaFrom.Properties.DisplayFormat.FormatString = " dd/MM/yyyy"
        Me.DtpCriteriaFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DtpCriteriaFrom.Properties.EditFormat.FormatString = " dd/MM/yyyy"
        Me.DtpCriteriaFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DtpCriteriaFrom.Properties.Mask.EditMask = " dd/MM/yyyy"
        Me.DtpCriteriaFrom.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.DtpCriteriaFrom.Properties.NullText = "Select From Date"
        Me.DtpCriteriaFrom.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[False]
        Me.DtpCriteriaFrom.Size = New System.Drawing.Size(142, 22)
        Me.DtpCriteriaFrom.TabIndex = 120
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(331, 14)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(38, 13)
        Me.LabelControl1.TabIndex = 125
        Me.LabelControl1.Text = "Till Date"
        '
        'dtptransfertill
        '
        Me.dtptransfertill.EditValue = Nothing
        Me.dtptransfertill.Location = New System.Drawing.Point(386, 9)
        Me.dtptransfertill.Name = "dtptransfertill"
        Me.dtptransfertill.Properties.AutoHeight = False
        Me.dtptransfertill.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtptransfertill.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtptransfertill.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.TouchUI
        Me.dtptransfertill.Properties.DisplayFormat.FormatString = " dd/MM/yyyy"
        Me.dtptransfertill.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtptransfertill.Properties.EditFormat.FormatString = " dd/MM/yyyy"
        Me.dtptransfertill.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtptransfertill.Properties.Mask.EditMask = " dd/MM/yyyy"
        Me.dtptransfertill.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.dtptransfertill.Properties.NullText = "Select Till Date"
        Me.dtptransfertill.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[False]
        Me.dtptransfertill.Size = New System.Drawing.Size(142, 22)
        Me.dtptransfertill.TabIndex = 126
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(52, 13)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(50, 13)
        Me.LabelControl2.TabIndex = 123
        Me.LabelControl2.Text = "From Date"
        '
        'dtptransferfrom
        '
        Me.dtptransferfrom.EditValue = Nothing
        Me.dtptransferfrom.Location = New System.Drawing.Point(119, 8)
        Me.dtptransferfrom.Name = "dtptransferfrom"
        Me.dtptransferfrom.Properties.AutoHeight = False
        Me.dtptransferfrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtptransferfrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtptransferfrom.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.TouchUI
        Me.dtptransferfrom.Properties.DisplayFormat.FormatString = " dd/MM/yyyy"
        Me.dtptransferfrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtptransferfrom.Properties.EditFormat.FormatString = " dd/MM/yyyy"
        Me.dtptransferfrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtptransferfrom.Properties.Mask.EditMask = " dd/MM/yyyy"
        Me.dtptransferfrom.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.dtptransferfrom.Properties.NullText = "Select From Date"
        Me.dtptransferfrom.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[False]
        Me.dtptransferfrom.Size = New System.Drawing.Size(142, 22)
        Me.dtptransferfrom.TabIndex = 124
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'ProgressBarControl1
        '
        Me.ProgressBarControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBarControl1.Location = New System.Drawing.Point(12, 215)
        Me.ProgressBarControl1.Name = "ProgressBarControl1"
        Me.ProgressBarControl1.Properties.ShowTitle = True
        Me.ProgressBarControl1.Size = New System.Drawing.Size(573, 22)
        Me.ProgressBarControl1.TabIndex = 127
        Me.ProgressBarControl1.Visible = False
        '
        'BackgroundWorker2
        '
        Me.BackgroundWorker2.WorkerReportsProgress = True
        Me.BackgroundWorker2.WorkerSupportsCancellation = True
        '
        'CBWhs
        '
        Me.CBWhs.Location = New System.Drawing.Point(15, 67)
        Me.CBWhs.Name = "CBWhs"
        Me.CBWhs.Properties.Caption = "CheckEdit1"
        Me.CBWhs.Size = New System.Drawing.Size(128, 19)
        Me.CBWhs.TabIndex = 124
        '
        'FrmIntraData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 249)
        Me.Controls.Add(Me.ProgressBarControl1)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.dtptransfertill)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.dtptransferfrom)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblto)
        Me.Controls.Add(Me.lblFrom)
        Me.Controls.Add(Me.btnSendTransfers)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmIntraData"
        Me.Text = "Intra Data"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dtpCriteriaTill.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpCriteriaTill.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtpCriteriaFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtpCriteriaFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtptransfertill.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtptransfertill.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtptransferfrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtptransferfrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CBWhs.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSendTransfers As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblFrom As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblto As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LabelControl14 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents dtpCriteriaTill As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DtpCriteriaFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents btnGenerate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents dtptransfertill As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents dtptransferfrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents ProgressBarControl1 As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents BackgroundWorker2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents CBWhs As DevExpress.XtraEditors.CheckEdit
End Class
