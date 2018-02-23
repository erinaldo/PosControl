<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTouchInvoice
    Inherits DevExpress.XtraEditors.XtraForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTouchInvoice))
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.OrderGrid = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LigneID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ItemBID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ItemAID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Barcode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ItemShDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Price = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Qty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SizeCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColorCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DiscAmt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DiscPct = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Total = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Notes = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.VatAmt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.VatRate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Delete = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.btnDeleteItem = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.txtGross = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.txtAddDiscount = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl35 = New DevExpress.XtraEditors.LabelControl()
        Me.txtNet = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.txtVat = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.txtTotal = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.txtDiscAmt = New DevExpress.XtraEditors.TextEdit()
        Me.txtDiscPct = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.lblUSD = New DevExpress.XtraEditors.LabelControl()
        Me.lblLBP = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.RecieptGrid = New DevExpress.XtraGrid.GridControl()
        Me.RecieptView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RLigneID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MOP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MopLookup = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.Cur = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CurLookup = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.Amount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CheckID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CheckMaturity = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DtpMaturity = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.Bank = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Note = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LBP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.USD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DeleteReciept = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.btnDeleteReciept = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.txtid = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.ItemsTab = New DevExpress.XtraTab.XtraTabPage()
        Me.RecieptTab = New DevExpress.XtraTab.XtraTabPage()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.dtpDate = New DevExpress.XtraEditors.DateEdit()
        Me.btnSubmit = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbInvtype = New DevExpress.XtraEditors.LookUpEdit()
        Me.btnGet = New DevExpress.XtraEditors.SimpleButton()
        Me.DtpCriteriaFrom = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbPOS = New DevExpress.XtraEditors.LookUpEdit()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.LabelControl14 = New DevExpress.XtraEditors.LabelControl()
        Me.dtpCriteriaTill = New DevExpress.XtraEditors.DateEdit()
        Me.txtClient = New DevExpress.XtraEditors.TextEdit()
        Me.CBGift = New DevExpress.XtraEditors.CheckEdit()
        Me.lblGiftDate = New DevExpress.XtraEditors.LabelControl()
        Me.LblTotal = New DevExpress.XtraEditors.LabelControl()
        Me.Lbl = New DevExpress.XtraEditors.LabelControl()
        Me.CbSubmitted = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.OrderGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnDeleteItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGross.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.txtAddDiscount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNet.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDiscAmt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDiscPct.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RecieptGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RecieptView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MopLookup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurLookup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtpMaturity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtpMaturity.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnDeleteReciept, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtid.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.ItemsTab.SuspendLayout()
        Me.RecieptTab.SuspendLayout()
        CType(Me.dtpDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbInvtype.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtpCriteriaFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtpCriteriaFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbPOS.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.dtpCriteriaTill.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpCriteriaTill.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtClient.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CBGift.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CbSubmitted.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Appearance.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.LabelControl2.Location = New System.Drawing.Point(197, 107)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(48, 19)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "Client"
        '
        'OrderGrid
        '
        Me.OrderGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OrderGrid.Location = New System.Drawing.Point(-3, 15)
        Me.OrderGrid.MainView = Me.GridView1
        Me.OrderGrid.Name = "OrderGrid"
        Me.OrderGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.btnDeleteItem})
        Me.OrderGrid.Size = New System.Drawing.Size(1137, 246)
        Me.OrderGrid.TabIndex = 64
        Me.OrderGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.LigneID, Me.ItemBID, Me.ItemAID, Me.Barcode, Me.ItemShDesc, Me.Price, Me.Qty, Me.SizeCode, Me.ColorCode, Me.DiscAmt, Me.DiscPct, Me.Total, Me.Notes, Me.VatAmt, Me.VatRate, Me.Delete})
        Me.GridView1.GridControl = Me.OrderGrid
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp
        Me.GridView1.OptionsNavigation.EnterMoveNextColumn = True
        Me.GridView1.OptionsSelection.MultiSelect = True
        Me.GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'LigneID
        '
        Me.LigneID.Caption = "LigneID"
        Me.LigneID.Name = "LigneID"
        '
        'ItemBID
        '
        Me.ItemBID.Caption = "ItemBID"
        Me.ItemBID.Name = "ItemBID"
        '
        'ItemAID
        '
        Me.ItemAID.Caption = "ItemAID"
        Me.ItemAID.Name = "ItemAID"
        Me.ItemAID.OptionsColumn.AllowEdit = False
        '
        'Barcode
        '
        Me.Barcode.Caption = "Barcode"
        Me.Barcode.Name = "Barcode"
        Me.Barcode.OptionsColumn.AllowEdit = False
        Me.Barcode.Visible = True
        Me.Barcode.VisibleIndex = 0
        Me.Barcode.Width = 85
        '
        'ItemShDesc
        '
        Me.ItemShDesc.Caption = "Item ShDesc"
        Me.ItemShDesc.Name = "ItemShDesc"
        Me.ItemShDesc.OptionsColumn.AllowEdit = False
        Me.ItemShDesc.Visible = True
        Me.ItemShDesc.VisibleIndex = 1
        Me.ItemShDesc.Width = 184
        '
        'Price
        '
        Me.Price.Caption = "Price"
        Me.Price.Name = "Price"
        Me.Price.Visible = True
        Me.Price.VisibleIndex = 2
        Me.Price.Width = 65
        '
        'Qty
        '
        Me.Qty.Caption = "Qty"
        Me.Qty.Name = "Qty"
        Me.Qty.Visible = True
        Me.Qty.VisibleIndex = 3
        Me.Qty.Width = 70
        '
        'SizeCode
        '
        Me.SizeCode.Caption = "Size"
        Me.SizeCode.Name = "SizeCode"
        Me.SizeCode.OptionsColumn.AllowEdit = False
        '
        'ColorCode
        '
        Me.ColorCode.Caption = "Color"
        Me.ColorCode.Name = "ColorCode"
        Me.ColorCode.OptionsColumn.AllowEdit = False
        '
        'DiscAmt
        '
        Me.DiscAmt.Caption = "Disc Amt"
        Me.DiscAmt.Name = "DiscAmt"
        Me.DiscAmt.OptionsColumn.AllowEdit = False
        Me.DiscAmt.Visible = True
        Me.DiscAmt.VisibleIndex = 4
        Me.DiscAmt.Width = 65
        '
        'DiscPct
        '
        Me.DiscPct.Caption = "Disc Pct"
        Me.DiscPct.Name = "DiscPct"
        Me.DiscPct.Visible = True
        Me.DiscPct.VisibleIndex = 5
        Me.DiscPct.Width = 62
        '
        'Total
        '
        Me.Total.Caption = "Total"
        Me.Total.Name = "Total"
        Me.Total.OptionsColumn.AllowEdit = False
        Me.Total.Visible = True
        Me.Total.VisibleIndex = 6
        Me.Total.Width = 69
        '
        'Notes
        '
        Me.Notes.Caption = "Notes"
        Me.Notes.Name = "Notes"
        Me.Notes.Visible = True
        Me.Notes.VisibleIndex = 7
        Me.Notes.Width = 349
        '
        'VatAmt
        '
        Me.VatAmt.Caption = "Vat Amt"
        Me.VatAmt.Name = "VatAmt"
        Me.VatAmt.OptionsColumn.AllowEdit = False
        Me.VatAmt.Visible = True
        Me.VatAmt.VisibleIndex = 8
        '
        'VatRate
        '
        Me.VatRate.Caption = "Vat Rate"
        Me.VatRate.Name = "VatRate"
        Me.VatRate.OptionsColumn.AllowEdit = False
        Me.VatRate.Visible = True
        Me.VatRate.VisibleIndex = 9
        '
        'Delete
        '
        Me.Delete.Caption = "Delete"
        Me.Delete.ColumnEdit = Me.btnDeleteItem
        Me.Delete.Name = "Delete"
        Me.Delete.Visible = True
        Me.Delete.VisibleIndex = 10
        '
        'btnDeleteItem
        '
        Me.btnDeleteItem.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)})
        Me.btnDeleteItem.Name = "btnDeleteItem"
        Me.btnDeleteItem.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'txtGross
        '
        Me.txtGross.EditValue = "0"
        Me.txtGross.Location = New System.Drawing.Point(58, 23)
        Me.txtGross.Name = "txtGross"
        Me.txtGross.Size = New System.Drawing.Size(236, 20)
        Me.txtGross.TabIndex = 69
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(7, 26)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl4.TabIndex = 72
        Me.LabelControl4.Text = "Gross:"
        '
        'GroupControl1
        '
        Me.GroupControl1.Appearance.BackColor = System.Drawing.SystemColors.ControlLight
        Me.GroupControl1.Appearance.Options.UseBackColor = True
        Me.GroupControl1.Controls.Add(Me.txtAddDiscount)
        Me.GroupControl1.Controls.Add(Me.LabelControl35)
        Me.GroupControl1.Controls.Add(Me.txtNet)
        Me.GroupControl1.Controls.Add(Me.LabelControl8)
        Me.GroupControl1.Controls.Add(Me.txtVat)
        Me.GroupControl1.Controls.Add(Me.LabelControl7)
        Me.GroupControl1.Controls.Add(Me.txtTotal)
        Me.GroupControl1.Controls.Add(Me.LabelControl6)
        Me.GroupControl1.Controls.Add(Me.txtDiscAmt)
        Me.GroupControl1.Controls.Add(Me.txtDiscPct)
        Me.GroupControl1.Controls.Add(Me.LabelControl5)
        Me.GroupControl1.Controls.Add(Me.txtGross)
        Me.GroupControl1.Controls.Add(Me.LabelControl4)
        Me.GroupControl1.Location = New System.Drawing.Point(695, 57)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(299, 179)
        Me.GroupControl1.TabIndex = 75
        Me.GroupControl1.Text = "Totals"
        '
        'txtAddDiscount
        '
        Me.txtAddDiscount.Location = New System.Drawing.Point(167, 75)
        Me.txtAddDiscount.Name = "txtAddDiscount"
        Me.txtAddDiscount.Properties.NullText = "0.000"
        Me.txtAddDiscount.Size = New System.Drawing.Size(127, 20)
        Me.txtAddDiscount.TabIndex = 85
        '
        'LabelControl35
        '
        Me.LabelControl35.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl35.Location = New System.Drawing.Point(7, 78)
        Me.LabelControl35.Name = "LabelControl35"
        Me.LabelControl35.Size = New System.Drawing.Size(86, 13)
        Me.LabelControl35.TabIndex = 84
        Me.LabelControl35.Text = "Additional Disc:"
        '
        'txtNet
        '
        Me.txtNet.EditValue = "0"
        Me.txtNet.Location = New System.Drawing.Point(58, 148)
        Me.txtNet.Name = "txtNet"
        Me.txtNet.Size = New System.Drawing.Size(236, 20)
        Me.txtNet.TabIndex = 80
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl8.Location = New System.Drawing.Point(7, 151)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(22, 13)
        Me.LabelControl8.TabIndex = 81
        Me.LabelControl8.Text = "Net:"
        '
        'txtVat
        '
        Me.txtVat.EditValue = "0"
        Me.txtVat.Location = New System.Drawing.Point(58, 123)
        Me.txtVat.Name = "txtVat"
        Me.txtVat.Size = New System.Drawing.Size(236, 20)
        Me.txtVat.TabIndex = 78
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Location = New System.Drawing.Point(7, 126)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(22, 13)
        Me.LabelControl7.TabIndex = 79
        Me.LabelControl7.Text = "Vat:"
        '
        'txtTotal
        '
        Me.txtTotal.EditValue = "0"
        Me.txtTotal.Location = New System.Drawing.Point(58, 97)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(236, 20)
        Me.txtTotal.TabIndex = 76
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Location = New System.Drawing.Point(7, 100)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(32, 13)
        Me.LabelControl6.TabIndex = 77
        Me.LabelControl6.Text = "Total:"
        '
        'txtDiscAmt
        '
        Me.txtDiscAmt.Location = New System.Drawing.Point(167, 49)
        Me.txtDiscAmt.Name = "txtDiscAmt"
        Me.txtDiscAmt.Properties.NullText = "0.000"
        Me.txtDiscAmt.Size = New System.Drawing.Size(127, 20)
        Me.txtDiscAmt.TabIndex = 75
        '
        'txtDiscPct
        '
        Me.txtDiscPct.EditValue = "0.0"
        Me.txtDiscPct.Location = New System.Drawing.Point(58, 49)
        Me.txtDiscPct.Name = "txtDiscPct"
        Me.txtDiscPct.Properties.Mask.EditMask = "P0"
        Me.txtDiscPct.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtDiscPct.Properties.NullText = "0"
        Me.txtDiscPct.Size = New System.Drawing.Size(103, 20)
        Me.txtDiscPct.TabIndex = 73
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(7, 52)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(26, 13)
        Me.LabelControl5.TabIndex = 74
        Me.LabelControl5.Text = "Disc:"
        '
        'lblUSD
        '
        Me.lblUSD.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblUSD.Location = New System.Drawing.Point(549, 12)
        Me.lblUSD.Name = "lblUSD"
        Me.lblUSD.Size = New System.Drawing.Size(25, 16)
        Me.lblUSD.TabIndex = 70
        Me.lblUSD.Text = "USD"
        '
        'lblLBP
        '
        Me.lblLBP.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblLBP.Location = New System.Drawing.Point(337, 12)
        Me.lblLBP.Name = "lblLBP"
        Me.lblLBP.Size = New System.Drawing.Size(23, 16)
        Me.lblLBP.TabIndex = 69
        Me.lblLBP.Text = "LBP"
        '
        'LabelControl10
        '
        Me.LabelControl10.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelControl10.Location = New System.Drawing.Point(459, 12)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(84, 16)
        Me.LabelControl10.TabIndex = 68
        Me.LabelControl10.Text = "Balance USD:"
        '
        'LabelControl9
        '
        Me.LabelControl9.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelControl9.Location = New System.Drawing.Point(249, 12)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(82, 16)
        Me.LabelControl9.TabIndex = 67
        Me.LabelControl9.Text = "Balance LBP:"
        '
        'RecieptGrid
        '
        Me.RecieptGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RecieptGrid.Location = New System.Drawing.Point(-1, 37)
        Me.RecieptGrid.MainView = Me.RecieptView
        Me.RecieptGrid.Name = "RecieptGrid"
        Me.RecieptGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemButtonEdit1, Me.MopLookup, Me.btnDeleteReciept, Me.DtpMaturity, Me.CurLookup})
        Me.RecieptGrid.Size = New System.Drawing.Size(1145, 250)
        Me.RecieptGrid.TabIndex = 66
        Me.RecieptGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.RecieptView})
        '
        'RecieptView
        '
        Me.RecieptView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.RLigneID, Me.MOP, Me.Cur, Me.Amount, Me.CheckID, Me.CheckMaturity, Me.Bank, Me.Note, Me.LBP, Me.USD, Me.DeleteReciept})
        Me.RecieptView.GridControl = Me.RecieptGrid
        Me.RecieptView.Name = "RecieptView"
        Me.RecieptView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.RecieptView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp
        Me.RecieptView.OptionsNavigation.EnterMoveNextColumn = True
        Me.RecieptView.OptionsSelection.MultiSelect = True
        Me.RecieptView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
        Me.RecieptView.OptionsView.ShowGroupPanel = False
        '
        'RLigneID
        '
        Me.RLigneID.Caption = "RLigneID"
        Me.RLigneID.Name = "RLigneID"
        '
        'MOP
        '
        Me.MOP.Caption = "MOP"
        Me.MOP.ColumnEdit = Me.MopLookup
        Me.MOP.Name = "MOP"
        Me.MOP.Visible = True
        Me.MOP.VisibleIndex = 0
        Me.MOP.Width = 129
        '
        'MopLookup
        '
        Me.MopLookup.AutoHeight = False
        Me.MopLookup.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.MopLookup.CloseUpKey = New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F7)
        Me.MopLookup.Name = "MopLookup"
        Me.MopLookup.NullText = "Choose MOP"
        '
        'Cur
        '
        Me.Cur.Caption = "Currency"
        Me.Cur.ColumnEdit = Me.CurLookup
        Me.Cur.Name = "Cur"
        Me.Cur.Visible = True
        Me.Cur.VisibleIndex = 1
        Me.Cur.Width = 47
        '
        'CurLookup
        '
        Me.CurLookup.AutoHeight = False
        Me.CurLookup.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CurLookup.Name = "CurLookup"
        Me.CurLookup.NullText = "Currency"
        '
        'Amount
        '
        Me.Amount.Caption = "Amount"
        Me.Amount.DisplayFormat.FormatString = "n2"
        Me.Amount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.Amount.Name = "Amount"
        Me.Amount.Visible = True
        Me.Amount.VisibleIndex = 2
        Me.Amount.Width = 73
        '
        'CheckID
        '
        Me.CheckID.Caption = "CheckID"
        Me.CheckID.Name = "CheckID"
        Me.CheckID.Visible = True
        Me.CheckID.VisibleIndex = 3
        Me.CheckID.Width = 70
        '
        'CheckMaturity
        '
        Me.CheckMaturity.Caption = "Maturity"
        Me.CheckMaturity.ColumnEdit = Me.DtpMaturity
        Me.CheckMaturity.Name = "CheckMaturity"
        Me.CheckMaturity.Visible = True
        Me.CheckMaturity.VisibleIndex = 4
        Me.CheckMaturity.Width = 117
        '
        'DtpMaturity
        '
        Me.DtpMaturity.AutoHeight = False
        Me.DtpMaturity.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DtpMaturity.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DtpMaturity.Name = "DtpMaturity"
        '
        'Bank
        '
        Me.Bank.Caption = "Bank"
        Me.Bank.Name = "Bank"
        Me.Bank.Visible = True
        Me.Bank.VisibleIndex = 5
        Me.Bank.Width = 98
        '
        'Note
        '
        Me.Note.Caption = "Note"
        Me.Note.Name = "Note"
        Me.Note.Visible = True
        Me.Note.VisibleIndex = 6
        Me.Note.Width = 121
        '
        'LBP
        '
        Me.LBP.Caption = "LBP"
        Me.LBP.Name = "LBP"
        Me.LBP.OptionsColumn.AllowEdit = False
        Me.LBP.Visible = True
        Me.LBP.VisibleIndex = 7
        Me.LBP.Width = 48
        '
        'USD
        '
        Me.USD.Caption = "USD"
        Me.USD.Name = "USD"
        Me.USD.OptionsColumn.AllowEdit = False
        Me.USD.Visible = True
        Me.USD.VisibleIndex = 8
        Me.USD.Width = 37
        '
        'DeleteReciept
        '
        Me.DeleteReciept.Caption = "Delete"
        Me.DeleteReciept.ColumnEdit = Me.btnDeleteReciept
        Me.DeleteReciept.Name = "DeleteReciept"
        Me.DeleteReciept.Visible = True
        Me.DeleteReciept.VisibleIndex = 9
        Me.DeleteReciept.Width = 78
        '
        'btnDeleteReciept
        '
        Me.btnDeleteReciept.AutoHeight = False
        Me.btnDeleteReciept.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)})
        Me.btnDeleteReciept.Name = "btnDeleteReciept"
        Me.btnDeleteReciept.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'RepositoryItemButtonEdit1
        '
        Me.RepositoryItemButtonEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)})
        Me.RepositoryItemButtonEdit1.Name = "RepositoryItemButtonEdit1"
        Me.RepositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(7, 107)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(58, 19)
        Me.LabelControl3.TabIndex = 85
        Me.LabelControl3.Text = "OperID"
        '
        'txtid
        '
        Me.txtid.Location = New System.Drawing.Point(71, 106)
        Me.txtid.Name = "txtid"
        Me.txtid.Size = New System.Drawing.Size(99, 20)
        Me.txtid.TabIndex = 86
        '
        'LabelControl11
        '
        Me.LabelControl11.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl11.Location = New System.Drawing.Point(447, 107)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(39, 19)
        Me.LabelControl11.TabIndex = 87
        Me.LabelControl11.Text = "Date"
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Location = New System.Drawing.Point(3, 242)
        Me.XtraTabControl1.MultiLine = DevExpress.Utils.DefaultBoolean.[True]
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.PaintStyleName = "Office2003"
        Me.XtraTabControl1.SelectedTabPage = Me.ItemsTab
        Me.XtraTabControl1.Size = New System.Drawing.Size(1149, 288)
        Me.XtraTabControl1.TabIndex = 89
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.ItemsTab, Me.RecieptTab})
        '
        'ItemsTab
        '
        Me.ItemsTab.Controls.Add(Me.OrderGrid)
        Me.ItemsTab.Name = "ItemsTab"
        Me.ItemsTab.Size = New System.Drawing.Size(1147, 264)
        Me.ItemsTab.Text = "Items"
        '
        'RecieptTab
        '
        Me.RecieptTab.Controls.Add(Me.lblUSD)
        Me.RecieptTab.Controls.Add(Me.LabelControl9)
        Me.RecieptTab.Controls.Add(Me.lblLBP)
        Me.RecieptTab.Controls.Add(Me.RecieptGrid)
        Me.RecieptTab.Controls.Add(Me.LabelControl10)
        Me.RecieptTab.Name = "RecieptTab"
        Me.RecieptTab.Size = New System.Drawing.Size(1147, 264)
        Me.RecieptTab.Text = "Reciept"
        '
        'BackgroundWorker1
        '
        '
        'dtpDate
        '
        Me.dtpDate.EditValue = Nothing
        Me.dtpDate.Location = New System.Drawing.Point(492, 108)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Properties.AutoHeight = False
        Me.dtpDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtpDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtpDate.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.TouchUI
        Me.dtpDate.Properties.DisplayFormat.FormatString = " dd/MM/yyyy"
        Me.dtpDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtpDate.Properties.EditFormat.FormatString = " dd/MM/yyyy"
        Me.dtpDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtpDate.Properties.Mask.EditMask = " dd/MM/yyyy"
        Me.dtpDate.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.dtpDate.Properties.NullText = "Operation Date"
        Me.dtpDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[False]
        Me.dtpDate.Size = New System.Drawing.Size(142, 22)
        Me.dtpDate.TabIndex = 101
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(1083, 21)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(80, 23)
        Me.btnSubmit.TabIndex = 116
        Me.btnSubmit.Text = "Submit"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(226, 27)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(43, 13)
        Me.LabelControl1.TabIndex = 115
        Me.LabelControl1.Text = "Inv Type"
        '
        'cmbInvtype
        '
        Me.cmbInvtype.Location = New System.Drawing.Point(275, 24)
        Me.cmbInvtype.Name = "cmbInvtype"
        Me.cmbInvtype.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbInvtype.Properties.NullText = "Select Invoice Type"
        Me.cmbInvtype.Size = New System.Drawing.Size(150, 20)
        Me.cmbInvtype.TabIndex = 114
        '
        'btnGet
        '
        Me.btnGet.Location = New System.Drawing.Point(997, 21)
        Me.btnGet.Name = "btnGet"
        Me.btnGet.Size = New System.Drawing.Size(80, 23)
        Me.btnGet.TabIndex = 113
        Me.btnGet.Text = "Get"
        '
        'DtpCriteriaFrom
        '
        Me.DtpCriteriaFrom.EditValue = Nothing
        Me.DtpCriteriaFrom.Location = New System.Drawing.Point(522, 22)
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
        Me.DtpCriteriaFrom.TabIndex = 112
        '
        'LabelControl12
        '
        Me.LabelControl12.Location = New System.Drawing.Point(455, 27)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(50, 13)
        Me.LabelControl12.TabIndex = 111
        Me.LabelControl12.Text = "From Date"
        '
        'LabelControl13
        '
        Me.LabelControl13.Location = New System.Drawing.Point(8, 27)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(20, 13)
        Me.LabelControl13.TabIndex = 110
        Me.LabelControl13.Text = "POS"
        '
        'cmbPOS
        '
        Me.cmbPOS.Location = New System.Drawing.Point(44, 24)
        Me.cmbPOS.Name = "cmbPOS"
        Me.cmbPOS.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbPOS.Properties.NullText = "Select POS"
        Me.cmbPOS.Size = New System.Drawing.Size(150, 20)
        Me.cmbPOS.TabIndex = 109
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.LabelControl14)
        Me.GroupControl2.Controls.Add(Me.dtpCriteriaTill)
        Me.GroupControl2.Controls.Add(Me.LabelControl13)
        Me.GroupControl2.Controls.Add(Me.btnSubmit)
        Me.GroupControl2.Controls.Add(Me.cmbPOS)
        Me.GroupControl2.Controls.Add(Me.LabelControl1)
        Me.GroupControl2.Controls.Add(Me.LabelControl12)
        Me.GroupControl2.Controls.Add(Me.cmbInvtype)
        Me.GroupControl2.Controls.Add(Me.DtpCriteriaFrom)
        Me.GroupControl2.Controls.Add(Me.btnGet)
        Me.GroupControl2.Location = New System.Drawing.Point(3, 2)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(1169, 49)
        Me.GroupControl2.TabIndex = 117
        Me.GroupControl2.Text = "Criteria"
        '
        'LabelControl14
        '
        Me.LabelControl14.Location = New System.Drawing.Point(734, 28)
        Me.LabelControl14.Name = "LabelControl14"
        Me.LabelControl14.Size = New System.Drawing.Size(38, 13)
        Me.LabelControl14.TabIndex = 117
        Me.LabelControl14.Text = "Till Date"
        '
        'dtpCriteriaTill
        '
        Me.dtpCriteriaTill.EditValue = Nothing
        Me.dtpCriteriaTill.Location = New System.Drawing.Point(789, 23)
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
        Me.dtpCriteriaTill.TabIndex = 118
        '
        'txtClient
        '
        Me.txtClient.Location = New System.Drawing.Point(261, 106)
        Me.txtClient.Name = "txtClient"
        Me.txtClient.Size = New System.Drawing.Size(167, 20)
        Me.txtClient.TabIndex = 118
        '
        'CBGift
        '
        Me.CBGift.Location = New System.Drawing.Point(461, 149)
        Me.CBGift.Name = "CBGift"
        Me.CBGift.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBGift.Properties.Appearance.Options.UseFont = True
        Me.CBGift.Properties.AutoHeight = False
        Me.CBGift.Properties.Caption = "Gift"
        Me.CBGift.Size = New System.Drawing.Size(110, 32)
        Me.CBGift.TabIndex = 105
        '
        'lblGiftDate
        '
        Me.lblGiftDate.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGiftDate.Location = New System.Drawing.Point(540, 159)
        Me.lblGiftDate.Name = "lblGiftDate"
        Me.lblGiftDate.Size = New System.Drawing.Size(94, 14)
        Me.lblGiftDate.TabIndex = 106
        Me.lblGiftDate.Text = "LabelControl33"
        Me.lblGiftDate.Visible = False
        '
        'LblTotal
        '
        Me.LblTotal.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotal.Location = New System.Drawing.Point(492, 74)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(35, 14)
        Me.LblTotal.TabIndex = 119
        Me.LblTotal.Text = "Total:"
        '
        'Lbl
        '
        Me.Lbl.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl.Appearance.ForeColor = System.Drawing.Color.DarkRed
        Me.Lbl.Location = New System.Drawing.Point(1000, 74)
        Me.Lbl.Name = "Lbl"
        Me.Lbl.Size = New System.Drawing.Size(32, 14)
        Me.Lbl.TabIndex = 120
        Me.Lbl.Text = "Label"
        '
        'CbSubmitted
        '
        Me.CbSubmitted.Location = New System.Drawing.Point(261, 149)
        Me.CbSubmitted.Name = "CbSubmitted"
        Me.CbSubmitted.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbSubmitted.Properties.Appearance.Options.UseFont = True
        Me.CbSubmitted.Properties.AutoHeight = False
        Me.CbSubmitted.Properties.Caption = "Submitted"
        Me.CbSubmitted.Size = New System.Drawing.Size(110, 32)
        Me.CbSubmitted.TabIndex = 121
        '
        'FrmTouchInvoice
        '
        Me.Appearance.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 554)
        Me.Controls.Add(Me.CbSubmitted)
        Me.Controls.Add(Me.Lbl)
        Me.Controls.Add(Me.LblTotal)
        Me.Controls.Add(Me.txtClient)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.lblGiftDate)
        Me.Controls.Add(Me.CBGift)
        Me.Controls.Add(Me.dtpDate)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Controls.Add(Me.LabelControl11)
        Me.Controls.Add(Me.txtid)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.LabelControl2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "FrmTouchInvoice"
        Me.Text = "Order"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.OrderGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnDeleteItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGross.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.txtAddDiscount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNet.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDiscAmt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDiscPct.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RecieptGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RecieptView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MopLookup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurLookup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtpMaturity.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtpMaturity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnDeleteReciept, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtid.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.ItemsTab.ResumeLayout(False)
        Me.RecieptTab.ResumeLayout(False)
        Me.RecieptTab.PerformLayout()
        CType(Me.dtpDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbInvtype.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtpCriteriaFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtpCriteriaFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbPOS.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.GroupControl2.PerformLayout()
        CType(Me.dtpCriteriaTill.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpCriteriaTill.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtClient.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CBGift.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CbSubmitted.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents OrderGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ItemShDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Price As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Qty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Total As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Notes As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ItemAID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Barcode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DiscAmt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DiscPct As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LigneID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtGross As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents txtNet As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtVat As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtTotal As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtDiscAmt As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtDiscPct As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents VatAmt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents VatRate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Delete As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnDeleteItem As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents RecieptGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents RecieptView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents MOP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Cur As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Amount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CheckID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Bank As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Note As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemButtonEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MopLookup As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents lblUSD As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblLBP As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DeleteReciept As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnDeleteReciept As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents CheckMaturity As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DtpMaturity As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents CurLookup As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtid As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents ItemsTab As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents RecieptTab As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents LBP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents USD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents SizeCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColorCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents dtpDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents ItemBID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnSubmit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbInvtype As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents btnGet As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DtpCriteriaFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbPOS As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents txtClient As DevExpress.XtraEditors.TextEdit
    Friend WithEvents CBGift As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblGiftDate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents RLigneID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LblTotal As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl14 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents dtpCriteriaTill As DevExpress.XtraEditors.DateEdit
    Friend WithEvents CbSubmitted As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents txtAddDiscount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl35 As DevExpress.XtraEditors.LabelControl
End Class
