<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReceipts
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReceipts))
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.CmbSalesman = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.DtpCriteriaFrom = New DevExpress.XtraEditors.DateEdit()
        Me.btnGet = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TransID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ThirdID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ThirdName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Amount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Currency = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CheckNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CheckBank = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CheckMaturity = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CheckNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Description = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ManualRef = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MOPLookup = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.btnSubmit = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.DtpCriteriaTill = New DevExpress.XtraEditors.DateEdit()
        CType(Me.CmbSalesman.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtpCriteriaFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtpCriteriaFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MOPLookup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtpCriteriaTill.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtpCriteriaTill.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(45, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "SalesMan"
        '
        'CmbSalesman
        '
        Me.CmbSalesman.Location = New System.Drawing.Point(85, 9)
        Me.CmbSalesman.Name = "CmbSalesman"
        Me.CmbSalesman.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CmbSalesman.Size = New System.Drawing.Size(141, 20)
        Me.CmbSalesman.TabIndex = 1
        '
        'LabelControl12
        '
        Me.LabelControl12.Location = New System.Drawing.Point(272, 12)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(50, 13)
        Me.LabelControl12.TabIndex = 113
        Me.LabelControl12.Text = "From Date"
        '
        'DtpCriteriaFrom
        '
        Me.DtpCriteriaFrom.EditValue = Nothing
        Me.DtpCriteriaFrom.Location = New System.Drawing.Point(328, 7)
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
        Me.DtpCriteriaFrom.Size = New System.Drawing.Size(107, 22)
        Me.DtpCriteriaFrom.TabIndex = 114
        '
        'btnGet
        '
        Me.btnGet.Location = New System.Drawing.Point(712, 7)
        Me.btnGet.Name = "btnGet"
        Me.btnGet.Size = New System.Drawing.Size(75, 23)
        Me.btnGet.TabIndex = 115
        Me.btnGet.Text = "Get"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(12, 36)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.MOPLookup})
        Me.GridControl1.Size = New System.Drawing.Size(854, 304)
        Me.GridControl1.TabIndex = 116
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.TransID, Me.ThirdID, Me.ThirdName, Me.Amount, Me.Currency, Me.CheckNumber, Me.CheckBank, Me.CheckMaturity, Me.CheckNote, Me.Description, Me.ManualRef})
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsSelection.MultiSelect = True
        Me.GridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'TransID
        '
        Me.TransID.Caption = "TransID"
        Me.TransID.Name = "TransID"
        Me.TransID.Visible = True
        Me.TransID.VisibleIndex = 1
        '
        'ThirdID
        '
        Me.ThirdID.Caption = "ThirdID"
        Me.ThirdID.Name = "ThirdID"
        Me.ThirdID.Visible = True
        Me.ThirdID.VisibleIndex = 2
        '
        'ThirdName
        '
        Me.ThirdName.Caption = "Name"
        Me.ThirdName.Name = "ThirdName"
        Me.ThirdName.Visible = True
        Me.ThirdName.VisibleIndex = 3
        '
        'Amount
        '
        Me.Amount.Caption = "Amount"
        Me.Amount.Name = "Amount"
        Me.Amount.Visible = True
        Me.Amount.VisibleIndex = 4
        '
        'Currency
        '
        Me.Currency.Caption = "Currency"
        Me.Currency.Name = "Currency"
        Me.Currency.Visible = True
        Me.Currency.VisibleIndex = 5
        '
        'CheckNumber
        '
        Me.CheckNumber.Caption = "Check Number"
        Me.CheckNumber.Name = "CheckNumber"
        Me.CheckNumber.Visible = True
        Me.CheckNumber.VisibleIndex = 6
        '
        'CheckBank
        '
        Me.CheckBank.Caption = "Check Bank"
        Me.CheckBank.Name = "CheckBank"
        Me.CheckBank.Visible = True
        Me.CheckBank.VisibleIndex = 7
        '
        'CheckMaturity
        '
        Me.CheckMaturity.Caption = "Check Maturity"
        Me.CheckMaturity.Name = "CheckMaturity"
        Me.CheckMaturity.Visible = True
        Me.CheckMaturity.VisibleIndex = 8
        '
        'CheckNote
        '
        Me.CheckNote.Caption = "Check Note"
        Me.CheckNote.Name = "CheckNote"
        Me.CheckNote.Visible = True
        Me.CheckNote.VisibleIndex = 9
        '
        'Description
        '
        Me.Description.Caption = "Description"
        Me.Description.Name = "Description"
        Me.Description.Visible = True
        Me.Description.VisibleIndex = 10
        '
        'ManualRef
        '
        Me.ManualRef.Caption = "ManualRef"
        Me.ManualRef.Name = "ManualRef"
        Me.ManualRef.Visible = True
        Me.ManualRef.VisibleIndex = 11
        '
        'MOPLookup
        '
        Me.MOPLookup.AutoHeight = False
        Me.MOPLookup.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.MOPLookup.Name = "MOPLookup"
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(793, 7)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(75, 23)
        Me.btnSubmit.TabIndex = 117
        Me.btnSubmit.Text = "Submit"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(495, 12)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(38, 13)
        Me.LabelControl2.TabIndex = 118
        Me.LabelControl2.Text = "Till Date"
        '
        'DtpCriteriaTill
        '
        Me.DtpCriteriaTill.EditValue = Nothing
        Me.DtpCriteriaTill.Location = New System.Drawing.Point(567, 7)
        Me.DtpCriteriaTill.Name = "DtpCriteriaTill"
        Me.DtpCriteriaTill.Properties.AutoHeight = False
        Me.DtpCriteriaTill.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DtpCriteriaTill.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DtpCriteriaTill.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.TouchUI
        Me.DtpCriteriaTill.Properties.DisplayFormat.FormatString = " dd/MM/yyyy"
        Me.DtpCriteriaTill.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DtpCriteriaTill.Properties.EditFormat.FormatString = " dd/MM/yyyy"
        Me.DtpCriteriaTill.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DtpCriteriaTill.Properties.Mask.EditMask = " dd/MM/yyyy"
        Me.DtpCriteriaTill.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.DtpCriteriaTill.Properties.NullText = "Select Till Date"
        Me.DtpCriteriaTill.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[False]
        Me.DtpCriteriaTill.Size = New System.Drawing.Size(107, 22)
        Me.DtpCriteriaTill.TabIndex = 119
        '
        'FrmReceipts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(878, 343)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.DtpCriteriaTill)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.btnGet)
        Me.Controls.Add(Me.LabelControl12)
        Me.Controls.Add(Me.DtpCriteriaFrom)
        Me.Controls.Add(Me.CmbSalesman)
        Me.Controls.Add(Me.LabelControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmReceipts"
        Me.Text = "Receipts"
        CType(Me.CmbSalesman.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtpCriteriaFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtpCriteriaFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MOPLookup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtpCriteriaTill.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtpCriteriaTill.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CmbSalesman As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DtpCriteriaFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents btnGet As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TransID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Amount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CheckNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CheckBank As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CheckMaturity As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MOPLookup As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents Currency As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnSubmit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ThirdID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Description As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ManualRef As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CheckNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DtpCriteriaTill As DevExpress.XtraEditors.DateEdit
    Friend WithEvents ThirdName As DevExpress.XtraGrid.Columns.GridColumn
End Class
