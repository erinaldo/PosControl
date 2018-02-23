Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Base
Imports System.Data.SqlClient
Imports ConnectionSQL
Imports System.Text
Imports System.IO

Public Class FrmTouchInvoice
    Inherits DevExpress.XtraEditors.XtraForm
    Implements Procedures
    Public Shared add As Boolean = False
    Public Shared edit As Boolean = False
    Dim clsOperationA As New ClsOperationA
    Public Shared mopTransID As Integer
    Dim da As New SqlDataAdapter
    Dim CurrentOperID As Integer
    Public Shared OperIDg As Integer
    Dim CurDecimals As Integer = 0
    Dim daOpeationsA As New SqlDataAdapter
    Dim daOpeationsB As New SqlDataAdapter
    Dim dsGroupedOperationA As New DataSet
    Dim dsGroupedOperationB As New DataSet
    Dim DsGroupedReciepts As New DataSet
    Dim SalesMan As Integer
    Dim ThirdID As Integer
    Private Sub FrmTouchInvoice_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            MenuLockUnlock(add, edit)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub InitRGrid()
        Try
            Dim View As ColumnView = RecieptGrid.MainView
            View.Columns(0).FieldName = "LigneID"
            View.Columns(1).FieldName = "Code"
            View.Columns(1).VisibleIndex = 0
            View.Columns(2).FieldName = "CurCode"
            View.Columns(2).VisibleIndex = 1
            View.Columns(3).FieldName = "Amount"
            View.Columns(3).VisibleIndex = 2
            View.Columns(4).FieldName = "CheckNbr"
            View.Columns(4).VisibleIndex = 3
            View.Columns(5).FieldName = "CheckMaturity"
            View.Columns(5).VisibleIndex = 4
            View.Columns(6).FieldName = "CheckBank"
            View.Columns(6).VisibleIndex = 5
            View.Columns(7).FieldName = "CheckNote"
            View.Columns(7).VisibleIndex = 6
            View.Columns(8).FieldName = "LBP"
            View.Columns(8).VisibleIndex = 7
            View.Columns(9).FieldName = "USD"
            View.Columns(9).VisibleIndex = 8
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub InitGrid()
        Try
            Dim View As ColumnView = OrderGrid.MainView
            View.Columns(0).FieldName = "ligneid"
            View.Columns(1).FieldName = "ItemBId"
            View.Columns(2).FieldName = "ItemAId"
            View.Columns(3).FieldName = "Barcode"
            View.Columns(3).VisibleIndex = 0
            View.Columns(4).FieldName = "ItemShDescription"
            View.Columns(4).VisibleIndex = 1
            View.Columns(5).FieldName = "ItemPrice"
            View.Columns(5).VisibleIndex = 2
            View.Columns(6).FieldName = "Qty"
            View.Columns(6).VisibleIndex = 3
            View.Columns(7).FieldName = "SizeCode"
            'View.Columns(6).VisibleIndex = 4
            View.Columns(8).FieldName = "ColorCode"
            'View.Columns(7).VisibleIndex = 5
            View.Columns(9).FieldName = "DiscAmt"
            'View.Columns(8).VisibleIndex = 6
            View.Columns(10).FieldName = "DiscPct"
            'View.Columns(9).VisibleIndex = 7
            View.Columns(11).FieldName = "TotalLigne"
            ' View.Columns(10).VisibleIndex = 8
            View.Columns(12).FieldName = "InfoRef"
            ' View.Columns(11).VisibleIndex = 9
            View.Columns(13).FieldName = "VatAmt"
            'View.Columns(12).VisibleIndex = 10
            View.Columns(14).FieldName = "VatRate"
            'View.Columns(13).VisibleIndex = 11

            If FrmMainForm.UseSize = True And FrmMainForm.UseColor = True Then
                View.Columns(7).VisibleIndex = 4
                View.Columns(8).VisibleIndex = 5
                View.Columns(9).VisibleIndex = 6
                View.Columns(10).VisibleIndex = 7
                View.Columns(11).VisibleIndex = 8
                View.Columns(12).VisibleIndex = 9
                View.Columns(13).VisibleIndex = 10
                View.Columns(14).VisibleIndex = 11
            ElseIf FrmMainForm.UseSize = True And FrmMainForm.UseColor = False Then
                View.Columns(7).VisibleIndex = 4
                View.Columns(9).VisibleIndex = 5
                View.Columns(10).VisibleIndex = 6
                View.Columns(11).VisibleIndex = 7
                View.Columns(12).VisibleIndex = 8
                View.Columns(13).VisibleIndex = 9
                View.Columns(14).VisibleIndex = 10
            ElseIf FrmMainForm.UseSize = False And FrmMainForm.UseColor = True Then
                View.Columns(8).VisibleIndex = 4
                View.Columns(9).VisibleIndex = 5
                View.Columns(10).VisibleIndex = 6
                View.Columns(11).VisibleIndex = 7
                View.Columns(12).VisibleIndex = 8
                View.Columns(13).VisibleIndex = 9
                View.Columns(14).VisibleIndex = 10
            Else
                View.Columns(9).VisibleIndex = 4
                View.Columns(10).VisibleIndex = 5
                View.Columns(11).VisibleIndex = 6
                View.Columns(12).VisibleIndex = 7
                View.Columns(13).VisibleIndex = 8
                View.Columns(14).VisibleIndex = 9
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub FrmTouchInvoice_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If edit = True Or add = True Then
            MessageBox.Show("Cant Exit In Add/Edit Mode, Save Or Cancel Your Modifications", "Error", MessageBoxButtons.OK)
            e.Cancel = True
            Exit Sub
        End If
    End Sub

    Public Sub WriteToText(ByVal SForm As String)
        Dim SqlCom As String
        Dim fileName As String
        Dim directory As String
        Dim fs As FileStream
        Dim startupPath As String = ("C:\BusinessPack\PosControl")
        Try
            directory = startupPath & "\SQL\"
            fileName = directory & "sp.sql"
            SqlCom = SForm
            If Not System.IO.Directory.Exists(directory) Then
                System.IO.Directory.CreateDirectory(directory)
            End If

            If File.Exists(fileName) = False Then
                fs = File.Create(fileName)
            Else
                fs = File.Open(fileName, FileMode.Append)
            End If

            Dim info As Byte() = New UTF8Encoding(True).GetBytes(SqlCom)
            fs.Write(info, 0, info.Length)
            fs.Close()
        Catch e As Exception
        End Try
    End Sub
    Private Sub FrmTouchInvoice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            CbSubmitted.Checked = False
            Lbl.Text = ""
            InitDecimals()
            viewmode()
            LockUnlockMe()
            InitGrid()
            InitRGrid()
            FillMOP()
            FillCurr()
            GetInvoiceType()
            GetPOS()
            DtpCriteriaFrom.DateTime = Today.Date
            dtpCriteriaTill.DateTime = Today.Date
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub GetPOS()
        Try
            Dim ClsPOS As New ClsPOS
            Dim dt As New DataTable
            dt = ClsPOS.FillPOS(FrmLogin.objcon.con)
            cmbPOS.Properties.DisplayMember = "Description"
            cmbPOS.Properties.ValueMember = "POSCode"
            cmbPOS.Properties.DataSource = dt
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub GetInvoiceType()
        Try
            Dim ClsInvoiceType As New ClsInvoiceType
            Dim dt As New DataTable
            dt = ClsInvoiceType.FillInvoiceType(FrmLogin.objcon.con)
            cmbInvtype.Properties.DisplayMember = "InvoiceCode"
            cmbInvtype.Properties.ValueMember = "InvTypeID"
            cmbInvtype.Properties.DataSource = dt
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub InitDecimals()
        Try
            Price.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Price.DisplayFormat.FormatString = "n" & FrmMainForm.UPDecimals

            Qty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Qty.DisplayFormat.FormatString = "n" & FrmMainForm.QtyDecimals

            CurDecimals = GetCurrencyDec(FrmMainForm.CurCode)

            txtGross.Properties.Mask.MaskType = Mask.MaskType.Numeric
            txtGross.Properties.Mask.EditMask = "n" & CurDecimals
            txtGross.Properties.Mask.UseMaskAsDisplayFormat = True

            txtDiscAmt.Properties.Mask.MaskType = Mask.MaskType.Numeric
            txtDiscAmt.Properties.Mask.EditMask = "n" & CurDecimals
            txtDiscAmt.Properties.Mask.UseMaskAsDisplayFormat = True

            txtDiscPct.Properties.Mask.MaskType = Mask.MaskType.Numeric
            txtDiscPct.Properties.Mask.EditMask = "n" & CurDecimals
            txtDiscPct.Properties.Mask.UseMaskAsDisplayFormat = True

            txtTotal.Properties.Mask.MaskType = Mask.MaskType.Numeric
            txtTotal.Properties.Mask.EditMask = "n" & CurDecimals
            txtTotal.Properties.Mask.UseMaskAsDisplayFormat = True

            txtVat.Properties.Mask.MaskType = Mask.MaskType.Numeric
            txtVat.Properties.Mask.EditMask = "n" & CurDecimals
            txtVat.Properties.Mask.UseMaskAsDisplayFormat = True

            txtNet.Properties.Mask.MaskType = Mask.MaskType.Numeric
            txtNet.Properties.Mask.EditMask = "n" & CurDecimals
            txtNet.Properties.Mask.MaskType = Mask.MaskType.Numeric
            txtNet.Properties.Mask.UseMaskAsDisplayFormat = True



            Total.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Total.DisplayFormat.FormatString = "n" & CurDecimals

            DiscAmt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            DiscAmt.DisplayFormat.FormatString = "n" & CurDecimals

            DiscPct.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            DiscPct.DisplayFormat.FormatString = "n" & CurDecimals

            Amount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Amount.DisplayFormat.FormatString = "n" & CurDecimals

            LBP.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            LBP.DisplayFormat.FormatString = "n" & CurDecimals

            USD.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            USD.DisplayFormat.FormatString = "n" & CurDecimals
            'txtGross.Properties.DisplayFormat.FormatType = Mask.MaskType.Numeric
            'txtGross.Properties.DisplayFormat.FormatString = "n" & CurDecimals

            'txtDiscAmt.Properties.DisplayFormat.FormatType = Mask.MaskType.Numeric
            'txtDiscAmt.Properties.DisplayFormat.FormatString = "n" & CurDecimals

            'txtDiscPct.Properties.DisplayFormat.FormatType = Mask.MaskType.Numeric
            'txtDiscPct.Properties.DisplayFormat.FormatString = "n" & CurDecimals

            'txtTotal.Properties.DisplayFormat.FormatType = Mask.MaskType.Numeric
            'txtTotal.Properties.DisplayFormat.FormatString = "n" & CurDecimals

            'txtVat.Properties.DisplayFormat.FormatType = Mask.MaskType.Numeric
            'txtVat.Properties.DisplayFormat.FormatString = "n" & CurDecimals

            'txtNet.Properties.DisplayFormat.FormatType = Mask.MaskType.Numeric
            'txtNet.Properties.DisplayFormat.FormatString = "n" & CurDecimals
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Function GetCurrencyDec(ByVal Curcode As String) As Integer
        Try
            Dim sqlCom As New SqlCommand("select Decimals from saccurrency where curcode='" & Curcode & "'", FrmLogin.objcon.con)
            Dim blnconnectionOpen As Boolean
            blnconnectionOpen = ConnStatus(FrmLogin.objcon.con)
            If Not blnconnectionOpen Then ConnOpen(FrmLogin.objcon.con)
            Return IIf(IsDBNull(sqlCom.ExecuteScalar) Or IsNothing(sqlCom.ExecuteScalar), 0, sqlCom.ExecuteScalar)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Public Sub FillMOP()
        Try
            Dim dt As New DataTable
            Dim SqlComm As New SqlCommand("select Code,Description from RsMop", FrmLogin.objcon.con)
            Dim blnconnectionOpen As Boolean
            blnconnectionOpen = ConnStatus(FrmLogin.objcon.con)
            If Not blnconnectionOpen Then ConnOpen(FrmLogin.objcon.con)
            da = New SqlDataAdapter(SqlComm)
            dt.Clear()
            da.Fill(dt)
            MopLookup.ValueMember = "Code"
            MopLookup.DisplayMember = "Description"
            MopLookup.DataSource = dt
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub FillCurr()
        Try
            Dim dt As New DataTable
            Dim SqlComm As New SqlCommand("select CurCode,description from sacCurrency", FrmLogin.objcon.con)
            Dim blnconnectionOpen As Boolean
            blnconnectionOpen = ConnStatus(FrmLogin.objcon.con)
            If Not blnconnectionOpen Then ConnOpen(FrmLogin.objcon.con)
            da = New SqlDataAdapter(SqlComm)
            dt.Clear()
            da.Fill(dt)
            CurLookup.ValueMember = "CurCode"
            CurLookup.DisplayMember = "CurCode"
            CurLookup.DataSource = dt
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub viewmode()
        Me.Text = "Sales Invoice <" & My.Application.Info.Version.ToString & "> View Mode"
        add = False
        edit = False
    End Sub
    Public Function cancel() As Object Implements Procedures.cancel
        Try
            If MessageBox.Show("Cancel All Modifications?", "Cancel", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                viewmode()
                If BackgroundWorker1.IsBusy = True Then
                    Return True
                End If
                BackgroundWorker1.RunWorkerAsync()
                Return True
            End If
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Public Sub close1() Implements Procedures.close
        Me.Close()
    End Sub
    Public Sub DeleteRecord() Implements Procedures.DeleteRecord

    End Sub
    Public Function EditRecord() As Object Implements Procedures.EditRecord
        If txtid.Text = String.Empty Then Return False
        Me.Text = "Invoice <" & My.Application.Info.Version.ToString & "> Edit Mode"
        edit = True
        add = False
        Return True
    End Function
    Public Sub FillDefault() Implements Procedures.FillDefault
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is TextEdit And Not (TypeOf ctrl Is GridLookUpEdit) Then
                CType(ctrl, TextEdit).Text = String.Empty
            End If
            If TypeOf ctrl Is DateEdit Then
                CType(ctrl, DateEdit).EditValue = Today.Date
            End If
        Next
        For Each ctrl As Control In GroupControl1.Controls
            If TypeOf ctrl Is TextEdit Then
                CType(ctrl, TextEdit).Text = String.Empty
            End If
        Next
        GridView1.SelectAll()
        GridView1.DeleteSelectedRows()
        RemoveHandler RecieptView.BeforeLeaveRow, AddressOf RecieptView_BeforeLeaveRow
        RecieptView.SelectAll()
        RecieptView.DeleteSelectedRows()
        AddHandler RecieptView.BeforeLeaveRow, AddressOf RecieptView_BeforeLeaveRow
        txtNet.Text = 0
        txtGross.Text = 0
        txtDiscAmt.Text = 0
        txtDiscPct.Text = 0
        txtVat.Text = 0
        txtTotal.Text = 0
        CBGift.Checked = False
        lblLBP.Text = "0.00"
        lblUSD.Text = "0.00"
        InitDecimals()
        XtraTabControl1.TabPages(0).Show()
        LblTotal.Text = "Total: "
    End Sub
    Public Sub find() Implements Procedures.find
        Exit Sub
    End Sub
    Public Sub FirstRecord() Implements Procedures.FirstRecord
        Try
            Dim OpASettings As New OpASettings
            Dim vEr As String = String.Empty
            OpASettings = clsOperationA.GetFirstInvoiceHeader(vEr)
            If vEr = "" Then
                txtid.Text = OpASettings.OperId
                CurrentOperID = OpASettings.OperId
                txtClient.Text = OpASettings.ThirdDesc
                txtGross.Text = OpASettings.GrossAmt
                txtDiscPct.Text = OpASettings.Disc1Pct
                txtDiscAmt.Text = OpASettings.Disc1Amt
                txtAddDiscount.Text = OpASettings.AddDiscAmt
                txtVat.Text = OpASettings.VatAmt
                txtTotal.Text = OpASettings.NetAmt
                If OpASettings.Closed = 1 Then
                    CbSubmitted.Checked = True
                Else
                    CbSubmitted.Checked = False
                End If
                dtpDate.DateTime = OpASettings.OperDate
                CBGift.Checked = OpASettings.Gift
                lblGiftDate.Text = "Return Date: " & IIf(IsDBNull(OpASettings.GiftReturnDate) Or IsNothing(OpASettings.GiftReturnDate), "", OpASettings.GiftReturnDate)
                GetTotalNet()
                Dim clsOpB As New ClsOperationB
                OrderGrid.DataSource = clsOpB.OperationBGet(txtid.Text, cmbInvtype.EditValue, cmbPOS.EditValue, FrmLogin.objcon.con)
                mopTransID = OpASettings.MopTransId
                getReciept(mopTransID, cmbPOS.EditValue)
                CalculateLabels()
            Else
                CurrentOperID = 0
                txtid.Text = String.Empty
                txtClient.Text = String.Empty
                txtGross.Text = String.Empty
                txtDiscPct.Text = String.Empty
                CbSubmitted.Checked = False
                txtDiscAmt.Text = String.Empty
                txtVat.Text = String.Empty
                txtAddDiscount.Text = String.Empty
                txtTotal.Text = String.Empty
                CBGift.Checked = False
                lblGiftDate.Text = ""
                dtpDate.DateTime = Nothing
                txtNet.Text = String.Empty
                GridView1.SelectAll()
                GridView1.DeleteSelectedRows()
                Dim clsOpB As New ClsOperationB
                OrderGrid.DataSource = clsOpB.OperationBGet(0, cmbInvtype.EditValue, "", FrmLogin.objcon.con)
                RemoveHandler RecieptView.BeforeLeaveRow, AddressOf RecieptView_BeforeLeaveRow
                RecieptView.SelectAll()
                RecieptView.DeleteSelectedRows()
                AddHandler RecieptView.BeforeLeaveRow, AddressOf RecieptView_BeforeLeaveRow
                getReciept(0, "")
                CalculateLabels()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub lastRecord() Implements Procedures.lastRecord
        Try
            Dim OpASettings As New OpASettings
            Dim vEr As String = String.Empty
            OpASettings = clsOperationA.GetLastInvoiceHeader(vEr)
            If vEr = "" Then
                txtid.Text = OpASettings.OperId
                CurrentOperID = OpASettings.OperId
                txtClient.Text = OpASettings.ThirdDesc
                txtGross.Text = OpASettings.GrossAmt
                txtDiscPct.Text = OpASettings.Disc1Pct
                txtDiscAmt.Text = OpASettings.Disc1Amt
                txtAddDiscount.Text = OpASettings.AddDiscAmt
                txtVat.Text = OpASettings.VatAmt
                txtTotal.Text = OpASettings.NetAmt
                dtpDate.DateTime = OpASettings.OperDate
                If OpASettings.Closed = 1 Then
                    CbSubmitted.Checked = True
                Else
                    CbSubmitted.Checked = False
                End If
                CBGift.Checked = OpASettings.Gift
                lblGiftDate.Text = "Return Date: " & IIf(IsDBNull(OpASettings.GiftReturnDate) Or IsNothing(OpASettings.GiftReturnDate), "", OpASettings.GiftReturnDate)
                GetTotalNet()
                Dim clsOpB As New ClsOperationB
                OrderGrid.DataSource = clsOpB.OperationBGet(txtid.Text, cmbInvtype.EditValue, cmbPOS.EditValue, FrmLogin.objcon.con)
                mopTransID = OpASettings.MopTransId
                getReciept(mopTransID, cmbPOS.EditValue)
                CalculateLabels()
            Else
                CurrentOperID = 0
                txtid.Text = String.Empty
                txtClient.Text = String.Empty
                txtGross.Text = String.Empty
                txtDiscPct.Text = String.Empty
                txtDiscAmt.Text = String.Empty
                txtVat.Text = String.Empty
                txtAddDiscount.Text = String.Empty
                txtTotal.Text = String.Empty
                CbSubmitted.Checked = False
                dtpDate.DateTime = Nothing
                txtNet.Text = String.Empty
                CBGift.Checked = False
                lblGiftDate.Text = ""
                GridView1.SelectAll()
                GridView1.DeleteSelectedRows()
                Dim clsOpB As New ClsOperationB
                OrderGrid.DataSource = clsOpB.OperationBGet(0, cmbInvtype.EditValue, "", FrmLogin.objcon.con)
                RemoveHandler RecieptView.BeforeLeaveRow, AddressOf RecieptView_BeforeLeaveRow
                RecieptView.SelectAll()
                RecieptView.DeleteSelectedRows()
                AddHandler RecieptView.BeforeLeaveRow, AddressOf RecieptView_BeforeLeaveRow
                getReciept(0, "")
                CalculateLabels()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub getReciept(ByVal TransID As Integer, ByVal PosCode As String)
        Try
            Dim clsJournalb As New ClsJournalB
            RecieptGrid.DataSource = clsJournalb.GetReciept(TransID, PosCode, FrmLogin.objcon.con)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub LockUnlockMe() Implements Procedures.LockUnlockMe
        Try
            If add = True Or edit = True Then
                For Each ctrl As Control In Me.Controls
                    If TypeOf ctrl Is TextEdit Then
                        CType(ctrl, TextEdit).Properties.ReadOnly = False
                    End If
                    If TypeOf ctrl Is SimpleButton Then
                        CType(ctrl, SimpleButton).Enabled = True
                    End If
                Next
                GridView1.OptionsBehavior.Editable = True
                RecieptView.OptionsBehavior.Editable = True
            Else
                For Each ctrl As Control In Me.Controls
                    If TypeOf ctrl Is TextEdit Then
                        CType(ctrl, TextEdit).Properties.ReadOnly = True
                    End If
                    If TypeOf ctrl Is SimpleButton Then
                        CType(ctrl, SimpleButton).Enabled = False
                    End If
                Next
                GridView1.OptionsBehavior.Editable = False
                RecieptView.OptionsBehavior.Editable = False
            End If
            dtpDate.Properties.ReadOnly = True
            txtid.Properties.ReadOnly = True
            txtVat.Properties.ReadOnly = True
            txtTotal.Properties.ReadOnly = True
            txtGross.Properties.ReadOnly = True
            txtNet.Properties.ReadOnly = True
            CBGift.ReadOnly = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub MenuLockUnlock(ByVal Adding As Boolean, ByVal Editing As Boolean) Implements Procedures.MenuLockUnlock
        Try
            If Adding = True Or Editing = True Then
                FrmMainForm.btnFirst.Enabled = False
                FrmMainForm.FirstToolStripMenuItem.Enabled = False
                FrmMainForm.btnnext.Enabled = False
                FrmMainForm.NextToolStripMenuItem.Enabled = False
                FrmMainForm.btnLast.Enabled = False
                FrmMainForm.LastToolStripMenuItem.Enabled = False
                FrmMainForm.btnprevious.Enabled = False
                FrmMainForm.PreviousToolStripMenuItem.Enabled = False
                FrmMainForm.NewToolStrip.Enabled = False
                FrmMainForm.NewToolStripMenuItem.Enabled = False
                FrmMainForm.EditToolStrip.Enabled = False
                FrmMainForm.EditToolStripMenuItem.Enabled = False
                FrmMainForm.SaveToolStrip.Enabled = True
                FrmMainForm.SaveToolStripMenuItem.Enabled = True
                FrmMainForm.UndoToolStrip.Enabled = True
                FrmMainForm.UndoToolStripMenuItem.Enabled = True
                FrmMainForm.FindToolstrip.Enabled = False
                FrmMainForm.FindToolStripMenuItem.Enabled = False
                FrmMainForm.DeleteToolStrip.Enabled = False
                FrmMainForm.DeleteToolStripMenuItem.Enabled = False
                FrmMainForm.SearchToolStrip.Enabled = False
                FrmMainForm.BrowseToolStripMenuItem.Enabled = False
                FrmMainForm.RefreshToolStrip.Enabled = False
                FrmMainForm.RefreshToolStripMenuItem.Enabled = False
                FrmMainForm.PrintToolStrip.Enabled = False
                FrmMainForm.PrintToolStripMenuItem.Enabled = False
                FrmMainForm.CloseToolStrip.Enabled = False
                FrmMainForm.CloseToolStripMenuItem.Enabled = False
            Else
                FrmMainForm.btnFirst.Enabled = True
                FrmMainForm.FirstToolStripMenuItem.Enabled = True
                FrmMainForm.btnnext.Enabled = True
                FrmMainForm.NextToolStripMenuItem.Enabled = True
                FrmMainForm.btnLast.Enabled = True
                FrmMainForm.LastToolStripMenuItem.Enabled = True
                FrmMainForm.btnprevious.Enabled = True
                FrmMainForm.PreviousToolStripMenuItem.Enabled = True
                FrmMainForm.NewToolStrip.Enabled = True
                FrmMainForm.NewToolStripMenuItem.Enabled = True
                FrmMainForm.EditToolStrip.Enabled = True
                FrmMainForm.EditToolStripMenuItem.Enabled = True
                FrmMainForm.SaveToolStrip.Enabled = False
                FrmMainForm.SaveToolStripMenuItem.Enabled = False
                FrmMainForm.UndoToolStrip.Enabled = False
                FrmMainForm.UndoToolStripMenuItem.Enabled = False
                FrmMainForm.FindToolstrip.Enabled = True
                FrmMainForm.FindToolStripMenuItem.Enabled = True
                FrmMainForm.DeleteToolStrip.Enabled = True
                FrmMainForm.DeleteToolStripMenuItem.Enabled = True
                FrmMainForm.SearchToolStrip.Enabled = True
                FrmMainForm.BrowseToolStripMenuItem.Enabled = True
                FrmMainForm.RefreshToolStrip.Enabled = True
                FrmMainForm.RefreshToolStripMenuItem.Enabled = True
                FrmMainForm.PrintToolStrip.Enabled = True
                FrmMainForm.PrintToolStripMenuItem.Enabled = True
                FrmMainForm.CloseToolStrip.Enabled = True
                FrmMainForm.CloseToolStripMenuItem.Enabled = True
                'getpriv()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    'Public Sub GetPriv()
    '    Try
    '        Dim clsAccess As New ClsAccess
    '        Dim dt As New DataTable
    '        dt = clsAccess.GetPriv("FrmTouchInvoice", FrmLogin.user, FrmLogin.objcon.con)
    '        If dt.Rows(0).Item("editing") = 1 Then
    '            FrmMainForm.EditToolStrip.Enabled = True
    '            FrmMainForm.EditToolStripMenuItem.Enabled = True
    '        Else
    '            FrmMainForm.EditToolStrip.Enabled = False
    '            FrmMainForm.EditToolStripMenuItem.Enabled = False
    '        End If
    '        If dt.Rows(0).Item("printing") = 1 Then
    '            FrmMainForm.PrintToolStrip.Enabled = True
    '            FrmMainForm.PrintToolStripMenuItem.Enabled = True
    '        Else
    '            FrmMainForm.PrintToolStrip.Enabled = False
    '            FrmMainForm.PrintToolStripMenuItem.Enabled = False
    '        End If
    '        If dt.Rows(0).Item("deleting") = 1 Then
    '            FrmMainForm.DeleteToolStrip.Enabled = True
    '            FrmMainForm.DeleteToolStripMenuItem.Enabled = True
    '        Else
    '            FrmMainForm.DeleteToolStrip.Enabled = False
    '            FrmMainForm.DeleteToolStripMenuItem.Enabled = False
    '        End If
    '        If dt.Rows(0).Item("adding") = 1 Then
    '            FrmMainForm.NewToolStrip.Enabled = True
    '            FrmMainForm.NewToolStripMenuItem.Enabled = True
    '        Else
    '            FrmMainForm.NewToolStrip.Enabled = False
    '            FrmMainForm.NewToolStripMenuItem.Enabled = False
    '        End If

    '    Catch ex As Exception
    '       MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub
    Public Function NewRecord() As Object Implements Procedures.NewRecord
        Return False
        Me.Text = "Sales Invoice <" & My.Application.Info.Version.ToString & "> Add Mode"
        add = True
        edit = True
        Return True
    End Function
    Public Sub nextRecord() Implements Procedures.nextRecord
        Try
            Dim OpASettings As New OpASettings
            Dim vEr As String = String.Empty
            OpASettings = clsOperationA.GetNextInvoiceHeader(vEr)
            If vEr = "" Then
                txtid.Text = OpASettings.OperId
                CurrentOperID = OpASettings.OperId
                txtClient.Text = OpASettings.ThirdDesc
                txtGross.Text = OpASettings.GrossAmt
                txtAddDiscount.Text = OpASettings.AddDiscAmt
                txtDiscPct.Text = OpASettings.Disc1Pct
                txtDiscAmt.Text = OpASettings.Disc1Amt
                txtVat.Text = OpASettings.VatAmt
                txtTotal.Text = OpASettings.NetAmt
                dtpDate.DateTime = OpASettings.OperDate
                If OpASettings.Closed = 1 Then
                    CbSubmitted.Checked = True
                Else
                    CbSubmitted.Checked = False
                End If
                CBGift.Checked = OpASettings.Gift
                lblGiftDate.Text = "Return Date: " & IIf(IsDBNull(OpASettings.GiftReturnDate) Or IsNothing(OpASettings.GiftReturnDate), "", OpASettings.GiftReturnDate)
                GetTotalNet()
                Dim clsOpB As New ClsOperationB
                OrderGrid.DataSource = clsOpB.OperationBGet(txtid.Text, cmbInvtype.EditValue, cmbPOS.EditValue, FrmLogin.objcon.con)
                mopTransID = OpASettings.MopTransId
                getReciept(mopTransID, cmbPOS.EditValue)
                CalculateLabels()
            Else
                CurrentOperID = 0
                txtid.Text = String.Empty
                txtClient.Text = String.Empty
                txtGross.Text = String.Empty
                txtDiscPct.Text = String.Empty
                txtDiscAmt.Text = String.Empty
                CbSubmitted.Checked = False
                txtVat.Text = String.Empty
                txtAddDiscount.Text = String.Empty
                txtTotal.Text = String.Empty
                CBGift.Checked = False
                lblGiftDate.Text = ""
                dtpDate.DateTime = Nothing
                txtNet.Text = String.Empty
                GridView1.SelectAll()
                GridView1.DeleteSelectedRows()
                Dim clsOpB As New ClsOperationB
                OrderGrid.DataSource = clsOpB.OperationBGet(0, cmbInvtype.EditValue, "", FrmLogin.objcon.con)
                RemoveHandler RecieptView.BeforeLeaveRow, AddressOf RecieptView_BeforeLeaveRow
                RecieptView.SelectAll()
                RecieptView.DeleteSelectedRows()
                AddHandler RecieptView.BeforeLeaveRow, AddressOf RecieptView_BeforeLeaveRow
                getReciept(0, "")
                CalculateLabels()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub PreviousRecord() Implements Procedures.PreviousRecord
        Try
            Dim OpASettings As New OpASettings
            Dim vEr As String = String.Empty
            OpASettings = clsOperationA.GetPrevInvoiceHeader(vEr)
            If vEr = "" Then
                txtid.Text = OpASettings.OperId
                CurrentOperID = OpASettings.OperId
                txtClient.Text = OpASettings.ThirdDesc
                txtGross.Text = OpASettings.GrossAmt
                If OpASettings.Closed = 1 Then
                    CbSubmitted.Checked = True
                Else
                    CbSubmitted.Checked = False
                End If
                txtDiscPct.Text = OpASettings.Disc1Pct
                txtDiscAmt.Text = OpASettings.Disc1Amt
                txtVat.Text = OpASettings.VatAmt
                txtTotal.Text = OpASettings.NetAmt
                dtpDate.DateTime = OpASettings.OperDate
                CBGift.Checked = OpASettings.Gift
                txtAddDiscount.Text = OpASettings.AddDiscAmt
                lblGiftDate.Text = "Return Date: " & IIf(IsDBNull(OpASettings.GiftReturnDate) Or IsNothing(OpASettings.GiftReturnDate), "", OpASettings.GiftReturnDate)
                GetTotalNet()
                Dim clsOpB As New ClsOperationB
                OrderGrid.DataSource = clsOpB.OperationBGet(txtid.Text, cmbInvtype.EditValue, cmbPOS.EditValue, FrmLogin.objcon.con)
                mopTransID = OpASettings.MopTransId
                getReciept(mopTransID, cmbPOS.EditValue)
                CalculateLabels()
            Else
                CurrentOperID = 0
                txtid.Text = String.Empty
                txtClient.Text = String.Empty
                txtGross.Text = String.Empty
                txtAddDiscount.Text = String.Empty
                txtDiscPct.Text = String.Empty
                CbSubmitted.Checked = False
                txtDiscAmt.Text = String.Empty
                txtVat.Text = String.Empty
                txtTotal.Text = String.Empty
                dtpDate.DateTime = Nothing
                txtNet.Text = String.Empty
                CBGift.Checked = False
                lblGiftDate.Text = ""
                GridView1.SelectAll()
                GridView1.DeleteSelectedRows()
                Dim clsOpB As New ClsOperationB
                OrderGrid.DataSource = clsOpB.OperationBGet(0, cmbInvtype.EditValue, "", FrmLogin.objcon.con)
                RemoveHandler RecieptView.BeforeLeaveRow, AddressOf RecieptView_BeforeLeaveRow
                RecieptView.SelectAll()
                RecieptView.DeleteSelectedRows()
                AddHandler RecieptView.BeforeLeaveRow, AddressOf RecieptView_BeforeLeaveRow
                getReciept(0, "")
                CalculateLabels()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub GetCurrentRecord()
        Try
            Dim OpASettings As New OpASettings
            Dim vEr As String = String.Empty
            OpASettings = clsOperationA.GetCurrentRecord(clsOperationA.i, vEr)
            If vEr = "" Then
                CurrentOperID = OpASettings.OperId
                txtid.Text = OpASettings.OperId
                txtClient.Text = OpASettings.ThirdDesc
                txtGross.Text = OpASettings.GrossAmt
                txtDiscPct.Text = OpASettings.Disc1Pct
                txtAddDiscount.Text = OpASettings.AddDiscAmt
                txtDiscAmt.Text = OpASettings.Disc1Amt
                txtVat.Text = OpASettings.VatAmt
                If OpASettings.Closed = 1 Then
                    CbSubmitted.Checked = True
                Else
                    CbSubmitted.Checked = False
                End If
                txtTotal.Text = OpASettings.NetAmt
                dtpDate.DateTime = OpASettings.OperDate
                CBGift.Checked = OpASettings.Gift
                lblGiftDate.Text = "Return Date: " & IIf(IsDBNull(OpASettings.GiftReturnDate) Or IsNothing(OpASettings.GiftReturnDate), "", OpASettings.GiftReturnDate)
                GetTotalNet()
                Dim clsOpB As New ClsOperationB
                OrderGrid.DataSource = clsOpB.OperationBGet(txtid.Text, cmbInvtype.EditValue, cmbPOS.EditValue, FrmLogin.objcon.con)
                mopTransID = OpASettings.MopTransId
                getReciept(mopTransID, cmbPOS.EditValue)
                CalculateLabels()
            Else
                CurrentOperID = 0
                txtid.Text = String.Empty
                txtClient.Text = String.Empty
                txtGross.Text = String.Empty
                txtDiscPct.Text = String.Empty
                CbSubmitted.Checked = False
                txtDiscAmt.Text = String.Empty
                txtVat.Text = String.Empty
                txtTotal.Text = String.Empty
                dtpDate.DateTime = Nothing
                txtNet.Text = String.Empty
                CBGift.Checked = False
                txtAddDiscount.Text = String.Empty
                lblGiftDate.Text = ""
                GridView1.SelectAll()
                GridView1.DeleteSelectedRows()
                Dim clsOpB As New ClsOperationB
                OrderGrid.DataSource = clsOpB.OperationBGet(0, cmbInvtype.EditValue, "", FrmLogin.objcon.con)
                RemoveHandler RecieptView.BeforeLeaveRow, AddressOf RecieptView_BeforeLeaveRow
                RecieptView.SelectAll()
                RecieptView.DeleteSelectedRows()
                AddHandler RecieptView.BeforeLeaveRow, AddressOf RecieptView_BeforeLeaveRow
                getReciept(0, "")
                CalculateLabels()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub print() Implements Procedures.print
        Exit Sub
    End Sub
    Public Sub Refresh1() Implements Procedures.Refresh
        Exit Sub
    End Sub
    Public Function Save() As Object Implements Procedures.Save
        Try
            If add = False And edit = False Then
                Return False
            End If
            If (lblLBP.Text = "LBP" Or lblUSD.Text = "USD") Then
                MessageBox.Show("Please Fill The Reciept", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                XtraTabControl1.TabPages(1).Show()
                Return False
            End If
            Dim LBP As Integer = Math.Round(CDbl(lblLBP.Text), CurDecimals)
            Dim USD As Integer = Math.Round(CDbl(lblUSD.Text), CurDecimals)
            If (LBP <> 0 Or USD <> 0) Then
                MessageBox.Show("Amount Not Balanced", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                XtraTabControl1.TabPages(1).Show()
                Return False
            End If
            If add = False And edit = True Then
                SetSummary()
                UpdateOperation()
                If CDbl(txtNet.Text) <> 0 Then UpdateReciept()
                viewmode()
            End If
            'clsOperationA.getInvoices(cmbInvtype.EditValue, cmbPOS.EditValue, DtpCriteriaFrom.DateTime.Date.ToString("yyyyMMdd"), FrmLogin.objcon.con)
            lastRecord()

            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Public Sub Search() Implements Procedures.Search

    End Sub
    Public Sub UpdateOperation()
        Try
            Dim clsOperationA As New ClsOperationA
            clsOperationA.UpdateOperationA(CInt(txtid.Text), cmbPOS.EditValue, cmbInvtype.EditValue, CDec(txtGross.Text), CDec(txtDiscPct.Text),
                                           CDec(txtDiscAmt.Text), CDec(txtTotal.Text), CDec(txtVat.Text), FrmLogin.objcon.con)
            For i As Integer = 0 To GridView1.DataRowCount - 1
                clsOperationA.UpdateOperationB(CInt(txtid.Text), cmbPOS.EditValue, cmbInvtype.EditValue, IIf(IsNothing(GridView1.GetRowCellValue(i, "ligneid")) Or IsDBNull(GridView1.GetRowCellValue(i, "ligneid")), DBNull.Value, GridView1.GetRowCellValue(i, "ligneid")),
                                              IIf(IsNothing(GridView1.GetRowCellValue(i, "ItemPrice")) Or IsDBNull(GridView1.GetRowCellValue(i, "ItemPrice")), DBNull.Value, GridView1.GetRowCellValue(i, "ItemPrice")),
                                                                       IIf(IsNothing(GridView1.GetRowCellValue(i, "Qty")) Or IsDBNull(GridView1.GetRowCellValue(i, "Qty")), DBNull.Value, GridView1.GetRowCellValue(i, "Qty")), IIf(IsNothing(GridView1.GetRowCellValue(i, "TotalLigne")) Or IsDBNull(GridView1.GetRowCellValue(i, "TotalLigne")), DBNull.Value, GridView1.GetRowCellValue(i, "TotalLigne")) _
                                                                       , IIf(IsNothing(GridView1.GetRowCellValue(i, "VatAmt")) Or IsDBNull(GridView1.GetRowCellValue(i, "VatAmt")), DBNull.Value, GridView1.GetRowCellValue(i, "VatAmt")), FrmLogin.objcon.con)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub GridView1_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Try
            If e.Column.FieldName <> "Qty" And e.Column.FieldName <> "ItemPrice" And e.Column.FieldName <> "DiscAmt" And e.Column.FieldName <> "DiscPct" Then Exit Sub
            RemoveHandler GridView1.CellValueChanged, AddressOf GridView1_CellValueChanged
            Dim total = GridView1.GetRowCellValue(e.RowHandle, "Qty") * GridView1.GetRowCellValue(e.RowHandle, "ItemPrice")
            Dim discpct = (100 - IIf(IsDBNull(GridView1.GetRowCellValue(e.RowHandle, "DiscPct")) _
                                     Or IsNothing(GridView1.GetRowCellValue(e.RowHandle, "DiscPct")), 0.0, GridView1.GetRowCellValue(e.RowHandle, "DiscPct"))) / 100
            Dim discamt = If(IsDBNull(GridView1.GetRowCellValue(e.RowHandle, "DiscPct")) _
                                     Or IsNothing(GridView1.GetRowCellValue(e.RowHandle, "DiscPct")), 0.0, GridView1.GetRowCellValue(e.RowHandle, "DiscPct")) / 100
            Dim c = Format(total * discamt, "0.00")
            GridView1.SetRowCellValue(e.RowHandle, "DiscAmt", c)
            AddHandler GridView1.CellValueChanged, AddressOf GridView1_CellValueChanged
            Dim Amount = Format(total * discpct, "0.00")
            GridView1.SetRowCellValue(e.RowHandle, "TotalLigne", Amount)
            Dim vatamt = Amount * (GridView1.GetRowCellValue(e.RowHandle, "VatRate") / 100)
            GridView1.SetRowCellValue(e.RowHandle, "VatAmt", vatamt)
            GridView1.UpdateCurrentRow()
            SetSummary()
            CalculateLabels()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub GetTotalNet()
        txtNet.Text = CDec((txtGross.Text - txtDiscAmt.Text) + txtVat.Text)
        txtNet.Text = txtNet.Text - txtAddDiscount.Text
    End Sub
    Private Sub SetSummary()
        Dim total As Decimal = 0
        For i As Integer = 0 To GridView1.DataRowCount - 1
            total += IIf(IsDBNull(GridView1.GetRowCellValue(i, "TotalLigne")) Or IsNothing(GridView1.GetRowCellValue(i, "TotalLigne")), 0, CDec(GridView1.GetRowCellValue(i, "TotalLigne")))
        Next i
        txtGross.Text = CDec(total)
        If Not IsNothing(txtDiscPct.EditValue) And Not IsDBNull(txtDiscPct.EditValue) Then
            If txtDiscPct.EditValue <> "0" Then
                txtDiscAmt.Text = (IIf(String.IsNullOrEmpty(txtDiscPct.EditValue), 0, txtDiscPct.EditValue) / 100) * txtGross.Text
            End If
        End If
        If txtDiscAmt.Text <> "0.000" And txtDiscAmt.Text <> "0" Then
            txtDiscPct.Text = (txtDiscAmt.EditValue * 100) / txtGross.Text
        End If
        txtTotal.Text = CDec(txtGross.Text - txtDiscAmt.Text)
        Dim vat As Double = 0.0
        For i As Integer = 0 To GridView1.DataRowCount - 1
            vat += IIf(IsDBNull(GridView1.GetRowCellValue(i, "VatAmt")) Or IsNothing(GridView1.GetRowCellValue(i, "VatAmt")), 0, GridView1.GetRowCellValue(i, "VatAmt"))
        Next
        txtVat.Text = CDec(vat)
        txtNet.Text = CDec((txtGross.Text - txtDiscAmt.Text) + txtVat.Text)
        If txtDiscAmt.Text = "0.000" Then
            txtDiscPct.Text = 0
        End If
    End Sub
    Sub InsertReciept()
        Try
            Dim BoConxString = "Data Source ='" & FrmMainForm.BOServer & "';Initial Catalog='" & FrmMainForm.BODatabase & "';user ID='" & FrmMainForm.BOUser & "';password='" & FrmMainForm.BOPass & "'"
            Dim BoCnx As SqlConnection = New SqlConnection(BoConxString)
            Dim clsJournalA As New ClsJournalA
            Dim sqlcomm As New SqlCommand("select Sequence from sacsequence where SeqCode='transid' and seqyear=" & Today.Year & "", BoCnx)
            Dim blnconnectionOpen = ConnStatus(BoCnx)
            If Not blnconnectionOpen Then ConnOpen(BoCnx)
            If IsDBNull(sqlcomm.ExecuteScalar) Or IsNothing(sqlcomm.ExecuteScalar) Then
                Dim sqlc As New SqlCommand("insert into SacSequence (SeqCode,SeqYear,Companyid,Sequence) values ('transid" &
                                       "'," & Today.Year & ",1," & Today.Year & "000000)", BoCnx)
                sqlc.ExecuteNonQuery()
            End If
            sqlcomm = New SqlCommand("select Sequence from sacsequence where SeqCode='transid' and seqyear=" & Today.Year & "", BoCnx)
            Dim blnconnectionOpe = ConnStatus(BoCnx)
            If Not blnconnectionOpe Then ConnOpen(BoCnx)
            Dim OperID As Integer = sqlcomm.ExecuteScalar + 1

            Dim TransID As Integer = sqlcomm.ExecuteScalar
            clsJournalA._P1 = TransID + 1
            clsJournalA._P2 = "RV"

            Dim sqlcomm1 As New SqlCommand("select Sequence from sacsequence where SeqCode='" & "RV" & "' and seqyear=" & Today.Year & "", BoCnx)
            blnconnectionOpen = ConnStatus(BoCnx)
            If Not blnconnectionOpen Then ConnOpen(BoCnx)
            If IsDBNull(sqlcomm1.ExecuteScalar) Or IsNothing(sqlcomm1.ExecuteScalar) Then
                Dim sqlc As New SqlCommand("insert into SacSequence (SeqCode,SeqYear,Companyid,Sequence) values ('" &
                               "RV" & "'," & Today.Year & ",1," & Today.Year & "000000)", BoCnx)
                sqlc.ExecuteNonQuery()
            End If
            blnconnectionOpen = ConnStatus(BoCnx)
            If Not blnconnectionOpen Then ConnOpen(BoCnx)
            Dim TypeId As Integer = sqlcomm1.ExecuteScalar

            clsJournalA._P3 = TypeId + 1
            clsJournalA._P4 = ""
            clsJournalA._P5 = dtpDate.DateTime.Date
            clsJournalA._P6 = dtpDate.DateTime.Date
            clsJournalA._P7 = 0
            clsJournalA._P8 = 0
            clsJournalA._P9 = ""
            clsJournalA._P10 = 2
            clsJournalA.P11 = FrmLogin.user
            clsJournalA.P12 = FrmLogin.user
            clsJournalA.JournalAInsert(BoCnx)
            Dim sqlcomm2 As New SqlCommand("update sacsequence set Sequence=" & TransID + 1 & " where SeqCode='transid' and seqyear=" & Today.Year & "", BoCnx)
            Dim blnconnectionOpen1 = ConnStatus(BoCnx)
            If Not blnconnectionOpen1 Then ConnOpen(BoCnx)
            sqlcomm2.ExecuteNonQuery()
            Dim sqlcomm3 As New SqlCommand("update sacsequence set Sequence=" & TypeId + 1 & " where SeqCode='" & "RV" & "' and seqyear=" & Today.Year & "", BoCnx)
            Dim blnconnectionOpen3 = ConnStatus(BoCnx)
            If Not blnconnectionOpen3 Then ConnOpen(BoCnx)
            sqlcomm3.ExecuteNonQuery()
            'Journal B

            Dim LineID As Integer = 1

            Dim ClsJournalB1 As New ClsJournalB
            ClsJournalB1._P1 = TransID + 1
            ClsJournalB1._P2 = LineID
            ClsJournalB1._P3 = LineID
            ClsJournalB1._P4 = FrmMainForm.AccCode
            If cmbInvtype.EditValue = FrmMainForm.SalesInvoice Then
                ClsJournalB1._P5 = "C"
            ElseIf cmbInvtype.EditValue = FrmMainForm.SalesReturn Then
                ClsJournalB1._P5 = "D"
            End If
            ClsJournalB1._P6 = DBNull.Value
            ClsJournalB1._P7 = DBNull.Value
            ClsJournalB1._P8 = 1
            ClsJournalB1._P9 = ThirdID
            ClsJournalB1._P10 = DBNull.Value
            ClsJournalB1._P11 = ""
            ClsJournalB1._P12 = FrmMainForm.CurCode
            ClsJournalB1._P13 = 0
            ClsJournalB1._P14 = Math.Round(CDbl(dsGroupedOperationA.Tables("OperationA").Rows(0).Item("net") + dsGroupedOperationA.Tables("OperationA").Rows(0).Item("vat")), CurDecimals)
            'LBP
            ClsJournalB1._P15 = Math.Round(CDbl(dsGroupedOperationA.Tables("OperationA").Rows(0).Item("net") + dsGroupedOperationA.Tables("OperationA").Rows(0).Item("vat")), CurDecimals)
            'USD
            Dim sqlcomm6 As New SqlCommand("select CurCode from SacCurrency where CurMain=2", BoCnx)
            If BoCnx.State = ConnectionState.Closed Then
                BoCnx.Open()
            End If
            Dim SecondCur = sqlcomm6.ExecuteScalar
            Dim salesRate = GetSalesRate(1, SecondCur, DateTime.Today.ToString("yyyyMMdd"))
            ClsJournalB1._P16 = Math.Round(CDbl(ClsJournalB1._P15) / salesRate, CurDecimals)
            ClsJournalB1._P17 = "Settlement Invoice " & OperIDg
            'checkmaturity
            ClsJournalB1._P18 = Date.Today
            ClsJournalB1._P19 = DBNull.Value
            ClsJournalB1._P20 = DBNull.Value
            ClsJournalB1._P21 = DBNull.Value
            ClsJournalB1._P22 = FrmLogin.user
            ClsJournalB1._P23 = DateTime.Today
            ClsJournalB1._P24 = ""
            ClsJournalB1.JournalBInsert(BoCnx)
            LineID += 1
            For i As Integer = 0 To DsGroupedReciepts.Tables("Reciepts").Rows.Count - 1
                Dim ClsJournalB As New ClsJournalB
                ClsJournalB._P1 = TransID + 1
                ClsJournalB._P2 = LineID
                ClsJournalB._P3 = LineID
                ClsJournalB._P4 = DsGroupedReciepts.Tables("Reciepts").Rows(i).Item("AccCode")
                If cmbInvtype.EditValue = FrmMainForm.SalesInvoice Then
                    ClsJournalB._P5 = "D"
                ElseIf cmbInvtype.EditValue = FrmMainForm.SalesReturn Then
                    ClsJournalB._P5 = "C"
                End If
                ClsJournalB._P6 = DBNull.Value
                ClsJournalB._P7 = DBNull.Value
                ClsJournalB._P8 = 0
                ClsJournalB._P9 = DBNull.Value
                ClsJournalB._P10 = DsGroupedReciepts.Tables("Reciepts").Rows(i).Item("AuxBCode")
                ClsJournalB._P11 = ""
                ClsJournalB._P12 = DsGroupedReciepts.Tables("Reciepts").Rows(i).Item("CurCode")
                ClsJournalB._P13 = 0
                ClsJournalB._P14 = Math.Round(DsGroupedReciepts.Tables("Reciepts").Rows(i).Item("Amount"), CurDecimals)
                'LBP
                ClsJournalB._P15 = Math.Round(DsGroupedReciepts.Tables("Reciepts").Rows(i).Item("Fl_Amount"), CurDecimals)
                ClsJournalB._P16 = Math.Round(DsGroupedReciepts.Tables("Reciepts").Rows(i).Item("Sl_Amount"), CurDecimals)
                ClsJournalB._P17 = "Settlement Invoice " & OperIDg
                'checkmaturity
                ClsJournalB._P18 = DBNull.Value
                ClsJournalB._P19 = DBNull.Value
                ClsJournalB._P20 = DBNull.Value
                ClsJournalB._P21 = DBNull.Value
                ClsJournalB._P22 = FrmLogin.user
                ClsJournalB._P23 = DateTime.Today
                ClsJournalB._P24 = ""
                ClsJournalB.JournalBInsert(BoCnx)
                LineID += 1
            Next
            Dim sqlcomm7 As New SqlCommand("update IvOperationC1Es set MopTransID=" & TransID + 1 & " where operID=" &
                                             OperIDg & " and invTypeId= " & cmbInvtype.EditValue, BoCnx)

            sqlcomm7.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub RecieptsCalculate()
        Try
            Dim AmountleftUSD As Double
            Dim Amountleft As Double = CDbl(txtNet.Text)
            lblLBP.Text = txtNet.Text
            Dim sqlcomm As New SqlCommand("select CurCode from SacCurrency where CurMain=2", FrmLogin.objcon.con)
            If FrmLogin.objcon.con.State = ConnectionState.Closed Then
                FrmLogin.objcon.con.Open()
            End If
            Dim SecondCur = sqlcomm.ExecuteScalar
            Dim salesRate = GetSalesRate(1, SecondCur, DateTime.Today.ToString("yyyyMMdd"))
            lblUSD.Text = CDbl(txtNet.Text) / salesRate
            AmountleftUSD = lblUSD.Text
            lblLBP.Text = txtNet.Text
            For i As Integer = 0 To RecieptView.DataRowCount - 1
                Dim AmountLBP = RecieptView.GetRowCellValue(i, "LBP")
                Amountleft = Amountleft - AmountLBP
            Next
            For i As Integer = 0 To RecieptView.DataRowCount - 1
                Dim AmountUSD = RecieptView.GetRowCellValue(i, "USD")
                AmountleftUSD = AmountleftUSD - AmountUSD
            Next
            lblLBP.Text = CDbl(Amountleft)
            lblUSD.Text = CDbl(AmountleftUSD)
            '    Dim CurCode = RecieptView.GetRowCellValue(i, "CurCode")
            '    Dim Amount = RecieptView.GetRowCellValue(i, "Amount")
            '    Dim sqlcomm As New SqlCommand("select CurMain from SAcCurrency where CurCode='" & CurCode & "'", FrmLogin.objcon.con)
            '    Dim CurMain = sqlcomm.ExecuteScalar()
            '    Dim SalesSLRate As Double = 0
            '    Dim SalesRate As Double = 0
            '    Dim ds As New DataSet
            '    If CurMain = 0 Then5
            '        SalesSLRate = GetSalesSLRate(1, CurCode, DateTime.Today.ToString("yyyyMMdd"))
            '        SalesRate = GetSalesRate(1, CurCode, DateTime.Today.ToString("yyyyMMdd"))
            '        lblLBP.Text = CDbl(Amountleft) - CDbl(Amount * SalesRate)
            '        Dim USDRate = GetSalesSLRate(1, FrmMainForm.Curcode, DateTime.Today.ToString("yyyyMMdd"))
            '        lblUSD.Text = CDbl(Amountleft * USDRate) - CDbl(Amount * SalesSLRate)
            '        Amountleft = lblLBP.Text
            '    ElseIf CurMain = 2 Then
            '        SalesRate = GetSalesRate(1, CurCode, DateTime.Today.ToString("yyyyMMdd"))
            '        lblLBP.Text = CDbl(Amountleft) - CDbl(Amount * SalesRate)
            '        lblUSD.Text = CDbl(CDbl(Amountleft) / SalesRate) - CDbl(Amount)
            '        Amountleft = lblLBP.Text
            '    ElseIf CurMain = 1 Then
            '        SalesSLRate = GetSalesSLRate(1, CurCode, DateTime.Today.ToString("yyyyMMdd"))
            '        lblLBP.Text = CDbl(Amountleft) - CDbl(Amount)
            '        lblUSD.Text = CDbl(CDbl(Amountleft) * SalesSLRate) - CDbl(Amount * SalesSLRate)
            '        Amountleft = lblLBP.Text
            '    End If
            'If RecieptView.DataRowCount = 0 Then
            '    lblLBP.Text = txtNet.Text
            '    Dim sqlcomm As New SqlCommand("select CurCode from SacCurrency where CurMain=2", FrmLogin.objcon.con)
            '    If FrmLogin.objcon.con.State = ConnectionState.Closed Then
            '        FrmLogin.objcon.con.Open()
            '    End If
            '    Dim SecondCur = sqlcomm.ExecuteScalar
            '    Dim salesRate = GetSalesRate(1, SecondCur, DateTime.Today.ToString("yyyyMMdd"))
            '    lblUSD.Text = CDbl(txtNet.Text) / salesRate
            'End If
            lblUSD.Text = Math.Round(CDec(lblUSD.Text), CurDecimals)
            lblLBP.Text = Math.Round(CDec(lblLBP.Text), CurDecimals)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Function GetSalesRate(ByVal CmpID As Integer, ByVal CurCode As String, ByVal Datep As String) As Double
        Try
            Dim sqlcomm As New SqlCommand("Sp_GetHelpRates", FrmLogin.objcon.con)
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@Cmp", 1)
            sqlcomm.Parameters.AddWithValue("@date1", DateTime.Today.ToString("yyyyMMdd"))
            sqlcomm.Parameters.AddWithValue("@cur", CurCode)
            Dim blnconnectionOpen = ConnStatus(FrmLogin.objcon.con)
            If Not blnconnectionOpen Then ConnOpen(FrmLogin.objcon.con)
            Dim dt As New DataTable
            da = New SqlDataAdapter(sqlcomm)
            da.Fill(dt)
            Dim SalesRate As Double = dt.Rows(0).Item("SalesRate")
            Return IIf(IsNothing(SalesRate) Or IsDBNull(SalesRate), 0, SalesRate)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Public Function GetSalesSLRate(ByVal CmpID As Integer, ByVal CurCode As String, ByVal Datep As String) As Double
        Try
            Dim sqlcomm As New SqlCommand("Sp_GetHelpRates", FrmLogin.objcon.con)
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@Cmp", 1)
            sqlcomm.Parameters.AddWithValue("@date1", DateTime.Today.ToString("yyyyMMdd"))
            sqlcomm.Parameters.AddWithValue("@cur", CurCode)
            Dim blnconnectionOpen = ConnStatus(FrmLogin.objcon.con)
            If Not blnconnectionOpen Then ConnOpen(FrmLogin.objcon.con)
            Dim dt As New DataTable
            da = New SqlDataAdapter(sqlcomm)
            da.Fill(dt)
            Dim SalesSLRate As Double = dt.Rows(0).Item("SalesSLRate")
            Return IIf(IsNothing(SalesSLRate) Or IsDBNull(SalesSLRate), 0, SalesSLRate)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Sub RecieptView_BeforeLeaveRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles RecieptView.BeforeLeaveRow
        Try
            RecieptsCalculate()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub RecieptView_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles RecieptView.CellValueChanged
        Try
            If e.Column.Name = "Amount" Then
                RecieptsCalculate()
                Dim sqlcomm8 As New SqlCommand("select CurMain from SacCurrency where CurCode='" & RecieptView.GetRowCellValue(e.RowHandle, "CurCode") & "'", FrmLogin.objcon.con)
                If FrmLogin.objcon.con.State = ConnectionState.Closed Then
                    FrmLogin.objcon.con.Open()
                End If
                Dim CurMain = sqlcomm8.ExecuteScalar
                If (CurMain = 1) Then '3m yedfa3 lebenen
                    'LBP
                    RecieptView.SetRowCellValue(e.RowHandle, RecieptView.Columns("LBP"), IIf(IsNothing(RecieptView.GetRowCellValue(e.RowHandle, "Amount")) Or IsDBNull(RecieptView.GetRowCellValue(e.RowHandle, "Amount")), 0, Math.Round(RecieptView.GetRowCellValue(e.RowHandle, "Amount"), CurDecimals)))
                    Dim sqlcomm9 As New SqlCommand("select CurCode from SacCurrency where CurMain=2", FrmLogin.objcon.con)
                    If FrmLogin.objcon.con.State = ConnectionState.Closed Then
                        FrmLogin.objcon.con.Open()
                    End If
                    Dim SecondCur2 = sqlcomm9.ExecuteScalar
                    Dim salesRate2 = GetSalesRate(1, SecondCur2, DateTime.Today.ToString("yyyyMMdd"))
                    'USD
                    If Math.Round(CDbl(lblUSD.Text), CurDecimals) = 0 Then
                        RecieptView.SetRowCellValue(e.RowHandle, RecieptView.Columns("USD"), 0)
                    Else
                        RecieptView.SetRowCellValue(e.RowHandle, RecieptView.Columns("USD"), IIf(IsNothing(RecieptView.GetRowCellValue(e.RowHandle, "Amount")) Or IsDBNull(RecieptView.GetRowCellValue(e.RowHandle, "Amount")), 0, Math.Round(RecieptView.GetRowCellValue(e.RowHandle, "Amount") / salesRate2, CurDecimals)))
                    End If
                Else
                    If CurMain = 2 Then '3m yedfa3 $
                        RecieptView.SetRowCellValue(e.RowHandle, RecieptView.Columns("USD"), IIf(IsNothing(RecieptView.GetRowCellValue(e.RowHandle, "Amount")) Or IsDBNull(RecieptView.GetRowCellValue(e.RowHandle, "Amount")), 0, Math.Round(RecieptView.GetRowCellValue(e.RowHandle, "Amount"), CurDecimals)))
                        Dim sqlcomm9 As New SqlCommand("select CurCode from SacCurrency where CurMain=1", FrmLogin.objcon.con)
                        If FrmLogin.objcon.con.State = ConnectionState.Closed Then
                            FrmLogin.objcon.con.Open()
                        End If
                        Dim SecondCur1 = sqlcomm9.ExecuteScalar
                        Dim salesslRate1 = GetSalesSLRate(1, SecondCur1, DateTime.Today.ToString("yyyyMMdd"))
                        'LBP
                        If Math.Round(CDbl(lblLBP.Text), CurDecimals) = 0 Then
                            RecieptView.SetRowCellValue(e.RowHandle, RecieptView.Columns("LBP"), 0)
                        Else
                            RecieptView.SetRowCellValue(e.RowHandle, RecieptView.Columns("LBP"), IIf(IsNothing(RecieptView.GetRowCellValue(e.RowHandle, "Amount")) Or IsDBNull(RecieptView.GetRowCellValue(e.RowHandle, "Amount")), 0, Math.Round(RecieptView.GetRowCellValue(e.RowHandle, "Amount") / salesslRate1, CurDecimals)))
                        End If
                    Else
                        Dim salesslRate1 = GetSalesSLRate(1, IIf(IsNothing(RecieptView.GetRowCellValue(e.RowHandle, "CurCode")) Or IsDBNull(RecieptView.GetRowCellValue(e.RowHandle, "CurCode")), DBNull.Value, RecieptView.GetRowCellValue(e.RowHandle, "CurCode")), DateTime.Today.ToString("yyyyMMdd"))
                        Dim salesRate1 = GetSalesRate(1, IIf(IsNothing(RecieptView.GetRowCellValue(e.RowHandle, "CurCode")) Or IsDBNull(RecieptView.GetRowCellValue(e.RowHandle, "CurCode")), DBNull.Value, RecieptView.GetRowCellValue(e.RowHandle, "CurCode")), DateTime.Today.ToString("yyyyMMdd"))
                        RecieptView.SetRowCellValue(e.RowHandle, RecieptView.Columns("LBP"), IIf(IsNothing(RecieptView.GetRowCellValue(e.RowHandle, "Amount")) Or IsDBNull(RecieptView.GetRowCellValue(e.RowHandle, "Amount")), 0, Math.Round(RecieptView.GetRowCellValue(e.RowHandle, "Amount") * salesRate1, CurDecimals)))
                        RecieptView.SetRowCellValue(e.RowHandle, RecieptView.Columns("USD"), IIf(IsNothing(RecieptView.GetRowCellValue(e.RowHandle, "Amount")) Or IsDBNull(RecieptView.GetRowCellValue(e.RowHandle, "Amount")), 0, Math.Round(RecieptView.GetRowCellValue(e.RowHandle, "Amount") * salesslRate1, CurDecimals)))
                    End If
                End If
            End If
            If e.Column.Name = "Cur" Then
                Dim sqlcomm As New SqlCommand("Select CurMain from sacCurrency where CurCode='" &
                                              RecieptView.GetRowCellValue(e.RowHandle, "CurCode") & "'", FrmLogin.objcon.con)
                If FrmLogin.objcon.con.State = ConnectionState.Closed Then
                    FrmLogin.objcon.con.Open()
                End If
                If sqlcomm.ExecuteScalar = 1 Then
                    RecieptView.SetRowCellValue(e.RowHandle, RecieptView.Columns("Amount"), lblLBP.Text)
                ElseIf sqlcomm.ExecuteScalar = 2 Then
                    RecieptView.SetRowCellValue(e.RowHandle, RecieptView.Columns("Amount"), lblUSD.Text)
                ElseIf sqlcomm.ExecuteScalar = 0 Then
                    Dim SalesRate = GetSalesRate(1, RecieptView.GetRowCellValue(e.RowHandle, "CurCode"), DateTime.Today.ToString("yyyyMMdd"))
                    RecieptView.SetRowCellValue(e.RowHandle, RecieptView.Columns("Amount"), lblLBP.Text / SalesRate)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub RecieptView_InitNewRow(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles RecieptView.InitNewRow
        Try
            RecieptView.SetRowCellValue(e.RowHandle, "CurCode", FrmMainForm.CurCode)
            'RecieptView.SetRowCellValue(e.RowHandle, RecieptView.Columns("Amount"), lblLBP.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnDeleteReciept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteReciept.Click
        Try
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = RecieptGrid.FocusedView
            Dim row As DataRowView = view.GetRow(view.FocusedRowHandle)
            If MessageBox.Show("Delete This Line?", "Delete", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                RecieptView.DeleteRow(RecieptView.FocusedRowHandle)
            End If
            RecieptsCalculate()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub CalculateLabels()
        Try

            lblLBP.Text = IIf(IsNothing(txtNet.Text) Or String.IsNullOrEmpty(txtNet.Text), 0, txtNet.Text)
            Dim sqlcomm As New SqlCommand("select CurCode from SacCurrency where CurMain=2", FrmLogin.objcon.con)
            If FrmLogin.objcon.con.State = ConnectionState.Closed Then
                FrmLogin.objcon.con.Open()
            End If
            Dim SecondCur = sqlcomm.ExecuteScalar
            Dim salesRate = GetSalesRate(1, SecondCur, DateTime.Today.ToString("yyyyMMdd"))
            lblUSD.Text = CDbl(IIf(IsNothing(txtNet.Text) Or String.IsNullOrEmpty(txtNet.Text), 0, txtNet.Text)) / salesRate
            lblUSD.Text = Math.Round(CDec(lblUSD.Text), CurDecimals)
            lblLBP.Text = Math.Round(CDec(lblLBP.Text), CurDecimals)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub XtraTabControl1_SelectedPageChanged(ByVal sender As Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged
        If XtraTabControl1.SelectedTabPage.Name = "RecieptTab" Then
            RecieptView.Focus()
        End If
    End Sub
    Private Sub btnDeleteItem_Click(sender As System.Object, e As System.EventArgs) Handles btnDeleteItem.Click
        Try
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = RecieptGrid.FocusedView
            Dim row As DataRowView = view.GetRow(view.FocusedRowHandle)
            If MessageBox.Show("Delete This Line?", "Delete", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                GridView1.DeleteRow(GridView1.FocusedRowHandle)
            End If
            If GridView1.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
                GridView1.CloseEditor()
                GridView1.UpdateCurrentRow()
            End If
            SetSummary()
            CalculateLabels()
            GridView1.BestFitColumns(True)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub txtDiscPct_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDiscPct.KeyDown
        If e.KeyCode <> Keys.Enter Then Exit Sub
        If txtDiscPct.EditValue = "0" Then
            txtDiscAmt.Text = "0.000"
        End If
        txtDiscAmt.Text = (txtDiscPct.EditValue / 100) * txtGross.Text
        txtNet.Text = (txtTotal.Text - txtDiscAmt.Text) + txtVat.Text
        If txtDiscAmt.Text <> "0.000" Then
            For i As Integer = 0 To GridView1.DataRowCount - 1
                Dim TotalLigne = GridView1.GetRowCellValue(i, "TotalLigne")
                Dim disc = TotalLigne * ((100 - txtDiscPct.EditValue) / 100)
                Dim c = (GridView1.GetRowCellValue(i, "VatRate") / 100) * disc
                GridView1.SetRowCellValue(i, "VatAmt", c)
            Next
        Else
            For i As Integer = 0 To GridView1.DataRowCount - 1
                Dim TotalLigne = GridView1.GetRowCellValue(i, "TotalLigne")
                Dim vatamt = TotalLigne * (GridView1.GetRowCellValue(i, "VatRate") / 100)
                GridView1.SetRowCellValue(i, "VatAmt", vatamt)
            Next
        End If
        SetSummary()
        CalculateLabels()
        RemoveHandler txtDiscPct.Leave, AddressOf txtDiscPct_Leave
        txtTotal.Focus()
        AddHandler txtDiscPct.Leave, AddressOf txtDiscPct_Leave
    End Sub
    Private Sub txtDiscPct_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDiscPct.Leave
        If txtDiscPct.EditValue = "0" Then
            txtDiscAmt.Text = "0.000"
        End If
        txtDiscAmt.Text = (txtDiscPct.EditValue / 100) * txtGross.Text
        txtNet.Text = (txtTotal.Text - txtDiscAmt.Text) + txtVat.Text
        If txtDiscAmt.Text <> "0.000" Then
            For i As Integer = 0 To GridView1.DataRowCount - 1
                Dim TotalLigne = GridView1.GetRowCellValue(i, "TotalLigne")
                Dim disc = TotalLigne * ((100 - txtDiscPct.EditValue) / 100)
                Dim c = (GridView1.GetRowCellValue(i, "VatRate") / 100) * disc
                GridView1.SetRowCellValue(i, "VatAmt", c)
            Next
        Else
            For i As Integer = 0 To GridView1.DataRowCount - 1
                Dim TotalLigne = GridView1.GetRowCellValue(i, "TotalLigne")
                Dim vatamt = TotalLigne * (GridView1.GetRowCellValue(i, "VatRate") / 100)
                GridView1.SetRowCellValue(i, "VatAmt", vatamt)
            Next
        End If
        SetSummary()
        CalculateLabels()
        txtTotal.Focus()
    End Sub
    Private Sub txtDiscAmt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDiscAmt.KeyDown
        If e.KeyCode <> Keys.Enter Then Exit Sub
        If txtDiscPct.EditValue = "0" Then
            txtDiscAmt.Text = "0.000"
        End If
        txtDiscAmt.Text = (txtDiscPct.EditValue / 100) * txtGross.Text
        txtNet.Text = (txtTotal.Text - txtDiscAmt.Text) + txtVat.Text
        If txtDiscAmt.Text <> "0.000" Then
            For i As Integer = 0 To GridView1.DataRowCount - 1
                Dim TotalLigne = GridView1.GetRowCellValue(i, "TotalLigne")
                Dim disc = TotalLigne * ((100 - txtDiscPct.EditValue) / 100)
                Dim c = (GridView1.GetRowCellValue(i, "VatRate") / 100) * disc
                GridView1.SetRowCellValue(i, "VatAmt", c)
            Next
        Else
            For i As Integer = 0 To GridView1.DataRowCount - 1
                Dim TotalLigne = GridView1.GetRowCellValue(i, "TotalLigne")
                Dim vatamt = TotalLigne * (GridView1.GetRowCellValue(i, "VatRate") / 100)
                GridView1.SetRowCellValue(i, "VatAmt", vatamt)
            Next
        End If
        SetSummary()
        CalculateLabels()
        RemoveHandler txtDiscAmt.Leave, AddressOf txtDiscAmt_Leave
        txtTotal.Focus()
        AddHandler txtDiscAmt.Leave, AddressOf txtDiscAmt_Leave
    End Sub
    Private Sub txtDiscAmt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDiscAmt.Leave
        If txtDiscPct.EditValue = "0" Then
            txtDiscAmt.Text = "0.000"
        End If
        txtDiscPct.Text = (txtDiscAmt.EditValue * 100) / txtGross.Text
        txtNet.Text = (txtTotal.Text - txtDiscAmt.Text) + txtVat.Text
        If txtDiscAmt.Text <> "0.000" Then
            For i As Integer = 0 To GridView1.DataRowCount - 1
                Dim TotalLigne = GridView1.GetRowCellValue(i, "TotalLigne")
                Dim disc = TotalLigne * ((100 - txtDiscPct.EditValue) / 100)
                Dim c = (GridView1.GetRowCellValue(i, "VatRate") / 100) * disc
                GridView1.SetRowCellValue(i, "VatAmt", c)
            Next
        Else
            For i As Integer = 0 To GridView1.DataRowCount - 1
                Dim TotalLigne = GridView1.GetRowCellValue(i, "TotalLigne")
                Dim vatamt = TotalLigne * (GridView1.GetRowCellValue(i, "VatRate") / 100)
                GridView1.SetRowCellValue(i, "VatAmt", vatamt)
            Next
        End If
        SetSummary()
        CalculateLabels()
        txtTotal.Focus()
    End Sub
    Private Sub GridView1_RowCellDefaultAlignment(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.RowCellAlignmentEventArgs) Handles GridView1.RowCellDefaultAlignment
        e.HorzAlignment = DevExpress.Utils.HorzAlignment.Center
    End Sub
    Private Sub RecieptView_RowCellDefaultAlignment(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.RowCellAlignmentEventArgs) Handles RecieptView.RowCellDefaultAlignment
        e.HorzAlignment = DevExpress.Utils.HorzAlignment.Center
    End Sub
    Private Sub BackgroundWorker1_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        If IsNothing(cmbPOS.EditValue) Or IsDBNull(cmbPOS.EditValue) Then
            MessageBox.Show("Please choose a POS", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If IsNothing(cmbInvtype.EditValue) Or IsDBNull(cmbInvtype.EditValue) Then
            MessageBox.Show("Please choose an Invoice Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        clsOperationA.getInvoices(cmbInvtype.EditValue, cmbPOS.EditValue, DtpCriteriaFrom.DateTime.Date.ToString("yyyyMMdd"), dtpCriteriaTill.DateTime.Date.ToString("yyyyMMdd"), FrmLogin.objcon.con)
        Try
            Dim sqlcom As New SqlCommand("select thirdid,SalesManID from PolyPosConf where PosCode = '" & cmbPOS.EditValue & "'", FrmLogin.objcon.con)
            da = New SqlDataAdapter(sqlcom)
            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                SalesMan = dt.Rows(0).Item("SalesManID")
                ThirdID = dt.Rows(0).Item("thirdid")
            Else
                MessageBox.Show("No Default Salesman And Customer For This POS, Please Contact The IT Department", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        lastRecord()
        GridView1.BestFitColumns()
        RecieptView.BestFitColumns()
        Dim vat As Double = 0
        Dim net As Double = 0
        Dim disc As Double = 0
        Dim total As Double = 0
        Dim AddDiscAmt As Double = 0
        For Each row As DataRow In clsOperationA.ds.Tables("InvoiceHeader").Rows
            vat = row.Item("VatAmt")
            net = row.Item("NetAmt")
            AddDiscAmt = row.Item("AddDiscAmt")
            total += net + vat - AddDiscAmt
        Next
        LblTotal.Text = "Total: " & total & " LBP"
    End Sub
    Private Sub GridView1_ValidatingEditor(sender As System.Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles GridView1.ValidatingEditor
        Try
            If GridView1.FocusedColumn.FieldName = "ItemPrice" Then
                Dim ItemPrice As Integer = 0
                If Not Double.TryParse(e.Value, ItemPrice) Then
                    e.Valid = False
                    e.ErrorText = "Numeric values are only accepted, press Esc to discard changes"
                End If
            End If
            If GridView1.FocusedColumn.FieldName = "Qty" Then
                Dim Qty As Integer = 0
                If Not Double.TryParse(e.Value, Qty) Then
                    e.Valid = False
                    e.ErrorText = "Numeric values are only accepted, press Esc to discard changes"
                End If
            End If
            If GridView1.FocusedColumn.FieldName = "DiscAmt" Then
                Dim DiscAmt As Integer = 0
                If Not Double.TryParse(e.Value, DiscAmt) Then
                    e.Valid = False
                    e.ErrorText = "Numeric values are only accepted, press Esc to discard changes"
                End If
            End If
            If GridView1.FocusedColumn.FieldName = "DiscPct" Then
                Dim DiscPct As Integer = 0
                If Not Double.TryParse(e.Value, DiscPct) Then
                    e.Valid = False
                    e.ErrorText = "Numeric values are only accepted, press Esc to discard changes"
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub RecieptView_ValidatingEditor(sender As System.Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles RecieptView.ValidatingEditor
        Try
            If GridView1.FocusedColumn.FieldName = "Amount" Then
                Dim Amount As Integer = 0
                If Not Double.TryParse(e.Value, Amount) Then
                    e.Valid = False
                    e.ErrorText = "Numeric values are only accepted, press Esc to discard changes"
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub RecieptView_CustomColumnDisplayText(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles RecieptView.CustomColumnDisplayText
        Try
            Dim view As ColumnView = TryCast(sender, ColumnView)
            If e.Column.FieldName = "Amount" AndAlso e.ListSourceRowIndex <> DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
                Dim currencyType As String = view.GetListSourceRowCellValue(e.ListSourceRowIndex, "CurCode")
                Dim price As Decimal = Convert.ToDecimal(e.Value)
                Dim Dec = GetCurrencyDec(currencyType)
                e.DisplayText = Math.Round(price, Dec)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub RecieptGrid_FocusedViewChanged(sender As System.Object, e As DevExpress.XtraGrid.ViewFocusEventArgs) Handles RecieptGrid.FocusedViewChanged
        'If Not e.PreviousView Is Nothing Then

        '    e.PreviousView.CloseEditor()

        '    CType(e.PreviousView, ColumnView).UpdateCurrentRow()

        'End If
    End Sub

    Private Sub RecieptView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles RecieptView.KeyDown
        If (e.KeyCode = Keys.F6 Or e.KeyCode = Keys.F8) And RecieptView.IsNewItemRow(RecieptView.FocusedRowHandle) Then
            RecieptView.CloseEditor()
            RecieptView.UpdateCurrentRow()
            RecieptsCalculate()
        End If
    End Sub
    Private Sub btnGet_Click(sender As System.Object, e As System.EventArgs) Handles btnGet.Click
        Lbl.Text = ""
        If IsNothing(cmbPOS.EditValue) Or IsDBNull(cmbPOS.EditValue) Then
            MessageBox.Show("Please choose a POS", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If IsNothing(cmbInvtype.EditValue) Or IsDBNull(cmbInvtype.EditValue) Then
            MessageBox.Show("Please choose an Invoice Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If BackgroundWorker1.IsBusy = True Then
            Exit Sub
        End If
        BackgroundWorker1.RunWorkerAsync()
    End Sub
    Private Sub btnSubmit_Click(sender As System.Object, e As System.EventArgs) Handles btnSubmit.Click
        Cursor.Current = Cursors.WaitCursor
        If txtid.Text = "" Then
            MessageBox.Show("Empty Oper ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Directory.Exists("C:\BusinessPack\PosControl\SQL") Then
            My.Computer.FileSystem.DeleteDirectory("C:\BusinessPack\PosControl\SQL", FileIO.DeleteDirectoryOption.DeleteAllContents)
        End If
        Try
            Dim CurrD As DateTime = DtpCriteriaFrom.DateTime
            If MessageBox.Show("Are you sure you want to submit these operations?", "Submit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                While (CurrD <= dtpCriteriaTill.DateTime)
                    GroupOperationA(CurrD.Date.ToString("yyyyMMdd"))
                    GroupOperationB(CurrD.Date.ToString("yyyyMMdd"))
                    InsertTransaction(CurrD.Date)
                    CurrD = CurrD.AddDays(1)
                End While
            End If
            CbSubmitted.Checked = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub GroupReciepts()
        Try
            Try
                Dim SqlCom As New SqlCommand("SpRt_BoGroupReceiptsB", FrmLogin.objcon.con)
                SqlCom.CommandType = CommandType.StoredProcedure
                SqlCom.Parameters.AddWithValue("@PosCode", cmbPOS.EditValue)
                SqlCom.Parameters.AddWithValue("@TransCode", "RV")
                SqlCom.Parameters.AddWithValue("@TransDate", dtpDate.DateTime.Date.ToString("yyyyMMdd"))
                SqlCom.Parameters.AddWithValue("@InvTypeID", cmbInvtype.EditValue)
                DsGroupedReciepts.Clear()
                da = New SqlDataAdapter(SqlCom)
                da.Fill(DsGroupedReciepts, "Reciepts")
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub GroupOperationA(ByVal ODate As String)
        Try
            Dim SqlCom As New SqlCommand("SpRt_BoGroupOperationA", FrmLogin.objcon.con)
            SqlCom.CommandType = CommandType.StoredProcedure
            SqlCom.Parameters.AddWithValue("@InvTypeId", cmbInvtype.EditValue)
            SqlCom.Parameters.AddWithValue("@PosCode", cmbPOS.EditValue)
            SqlCom.Parameters.AddWithValue("@OperDate", ODate)
            dsGroupedOperationA.Clear()
            da = New SqlDataAdapter(SqlCom)
            da.Fill(dsGroupedOperationA, "OperationA")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub GroupOperationB(ByVal ODate As String)
        Try
            Dim SqlCom As New SqlCommand("SpRt_BoGroupOperationsB", FrmLogin.objcon.con)
            SqlCom.CommandType = CommandType.StoredProcedure
            SqlCom.Parameters.AddWithValue("@InvTypeId", cmbInvtype.EditValue)
            SqlCom.Parameters.AddWithValue("@PosCode", cmbPOS.EditValue)
            SqlCom.Parameters.AddWithValue("@OperDate", ODate)
            dsGroupedOperationB.Clear()
            da = New SqlDataAdapter(SqlCom)
            da.Fill(dsGroupedOperationB, "OperationB")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub InsertTransaction(ByVal datet As DateTime)
        If Directory.Exists("C:\BusinessPack\PosControl\SQL") Then
            My.Computer.FileSystem.DeleteDirectory("C:\BusinessPack\PosControl\SQL", FileIO.DeleteDirectoryOption.DeleteAllContents)
        End If
        If dsGroupedOperationA.Tables("OperationA").Rows.Count = 0 Then
            Exit Sub
        End If
        Dim WhsCode As String = ""
        'Dim CurCode As Object
        Dim sqls = ""
        Dim BoConxString = "Data Source ='" & FrmMainForm.BOServer & "';Initial Catalog='" & FrmMainForm.BODatabase & "';user ID='" & FrmMainForm.BOUser & "';password='" & FrmMainForm.BOPass & "'"
        Dim BoCnx As SqlConnection = New SqlConnection(BoConxString)
        Try
            Dim InvType As String
            Dim clsOpa As New ClsOperationA
            Dim SqlCommand As New SqlCommand("select ToPost,TransCode from IvInvoiceType1Es where invtypeid=" & cmbInvtype.EditValue, BoCnx)
            Dim ds1 As New DataSet
            Dim blnconnectionOpen = ConnStatus(BoCnx)
            If Not blnconnectionOpen Then ConnOpen(BoCnx)
            da = New SqlDataAdapter(SqlCommand)
            da.Fill(ds1, "IvInv")
            If ds1.Tables("IvInv").Rows(0).Item("ToPost") = 1 Then
                InvType = ds1.Tables("IvInv").Rows(0).Item("TransCode")
            Else
                InvType = "invtype" & cmbInvtype.EditValue
            End If

            Dim sqlcomm As New SqlCommand("select Sequence from sacsequence where SeqCode='" & InvType & "' and seqyear=" & Today.Year & "", BoCnx)
            blnconnectionOpen = ConnStatus(BoCnx)
            If Not blnconnectionOpen Then ConnOpen(BoCnx)
            If IsDBNull(sqlcomm.ExecuteScalar) Or IsNothing(sqlcomm.ExecuteScalar) Then
                Dim sqlc As New SqlCommand("insert into SacSequence (SeqCode,SeqYear,Companyid,Sequence) values ('" &
                                       InvType & "'," & Today.Year & ",1," & Today.Year & "000000)", BoCnx)
                sqlc.ExecuteNonQuery()
            End If
            sqlcomm = New SqlCommand("select Sequence from sacsequence where SeqCode='" & InvType & "' and seqyear=" & Today.Year & "", BoCnx)
            Dim blnconnectionOpe = ConnStatus(BoCnx)
            If Not blnconnectionOpe Then ConnOpen(BoCnx)
            Dim OperID As Integer = sqlcomm.ExecuteScalar + 1

            Dim command As SqlCommand = BoCnx.CreateCommand()
            command.Connection = BoCnx
            command.CommandText = "spRs_OpertaionAInsert"
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@p1", OperID)
            OperIDg = OperID
            command.Parameters.AddWithValue("@p2", cmbInvtype.EditValue)
            command.Parameters.AddWithValue("@p3", Today.Date)
            command.Parameters.AddWithValue("@p4", IIf(IsNothing(datet) Or IsDBNull(datet), DBNull.Value, datet))
            If cmbInvtype.EditValue = FrmMainForm.SalesOrder Then
                command.Parameters.AddWithValue("@p5", DBNull.Value)
                command.Parameters.AddWithValue("@p6", "")
            Else
                command.Parameters.AddWithValue("@p5", ThirdID)
                Dim sqlcomm1 As New SqlCommand("select ShortName from SacThirdParty where thirdid=" & ThirdID & "", BoCnx)
                Dim blnconnectionOpen1 = ConnStatus(BoCnx)
                If Not blnconnectionOpen1 Then ConnOpen(BoCnx)
                Dim desc As String = sqlcomm1.ExecuteScalar
                command.Parameters.AddWithValue("@p6", desc)
            End If
            command.Parameters.AddWithValue("@p7", SalesMan)
            command.Parameters.AddWithValue("@p8", IIf(IsNothing(cmbPOS.EditValue) Or IsDBNull(cmbPOS.EditValue), DBNull.Value, cmbPOS.EditValue))
            command.Parameters.AddWithValue("@p9", dsGroupedOperationA.Tables("OperationA").Rows(0).Item("WHSCode"))
            WhsCode = dsGroupedOperationA.Tables("OperationA").Rows(0).Item("WHSCode")
            command.Parameters.AddWithValue("@p10", DBNull.Value)
            command.Parameters.AddWithValue("@p11", dsGroupedOperationA.Tables("OperationA").Rows(0).Item("Curcode"))

            command.Parameters.AddWithValue("@p12", DBNull.Value)
            command.Parameters.AddWithValue("@p13", "")
            command.Parameters.AddWithValue("@p14", "")
            command.Parameters.AddWithValue("@p15", "")
            command.Parameters.AddWithValue("@p16", 0)   'Posted
            command.Parameters.AddWithValue("@p17", 0)   'Status
            command.Parameters.AddWithValue("@p18", 1)   'Applyvat
            command.Parameters.AddWithValue("@p19", 1)   'Confirmed
            If cmbInvtype.EditValue = FrmMainForm.SalesOrder Then
                command.Parameters.AddWithValue("@p20", 0)
            Else
                command.Parameters.AddWithValue("@p20", 1) 'Closed
            End If
            command.Parameters.AddWithValue("@p21", dsGroupedOperationA.Tables("OperationA").Rows(0).Item("RateFL"))
            command.Parameters.AddWithValue("@p22", dsGroupedOperationA.Tables("OperationA").Rows(0).Item("RateSL"))
            command.Parameters.AddWithValue("@p23", dsGroupedOperationA.Tables("OperationA").Rows(0).Item("RateVat"))
            command.Parameters.AddWithValue("@p24", "RtSales - " & datet) 'Manual Ref
            command.Parameters.AddWithValue("@p25", IIf(IsNothing(datet) Or IsDBNull(datet), DBNull.Value, datet))
            Dim Gross = dsGroupedOperationA.Tables("OperationA").Rows(0).Item("gross")
            command.Parameters.AddWithValue("@p26", IIf(IsDBNull(Gross) Or IsNothing(Gross), 0, Gross))
            command.Parameters.AddWithValue("@p27", 0) 'Disc1PCT
            Dim Disc1Amt = dsGroupedOperationA.Tables("OperationA").Rows(0).Item("disc1amt")
            command.Parameters.AddWithValue("@p28", IIf(IsDBNull(Disc1Amt) Or IsNothing(Disc1Amt), 0, Disc1Amt))
            command.Parameters.AddWithValue("@p29", 0)
            command.Parameters.AddWithValue("@p30", 0)
            command.Parameters.AddWithValue("@p31", 0)
            command.Parameters.AddWithValue("@p32", 0)
            command.Parameters.AddWithValue("@p33", 0)
            command.Parameters.AddWithValue("@p34", dsGroupedOperationA.Tables("OperationA").Rows(0).Item("net"))
            Dim VatAmt = dsGroupedOperationA.Tables("OperationA").Rows(0).Item("vat")
            command.Parameters.AddWithValue("@p35", IIf(IsDBNull(VatAmt) Or IsNothing(VatAmt), 0, VatAmt))
            command.Parameters.AddWithValue("@p36", "")
            command.Parameters.AddWithValue("@p37", FrmLogin.user)
            command.Parameters.AddWithValue("@p38", FrmLogin.user)
            command.Parameters.AddWithValue("@p39", DateTime.Today)
            command.Parameters.AddWithValue("@p40", DBNull.Value)
            command.Parameters.AddWithValue("@p41", DBNull.Value)
            command.Parameters.AddWithValue("@p42", DBNull.Value)
            command.Parameters.AddWithValue("@p43", DBNull.Value)
            command.Parameters.AddWithValue("@p44", 0)
            command.Parameters.AddWithValue("@p45", 0)
            command.Parameters.AddWithValue("@p46", 0)
            command.Parameters.AddWithValue("@p47", 0)
            command.Parameters.AddWithValue("@p48", 0)
            command.Parameters.AddWithValue("@p49", 0)
            command.Parameters.AddWithValue("@p50", 0)
            command.Parameters.AddWithValue("@p51", 0)
            command.Parameters.AddWithValue("@p52", DBNull.Value)
            command.Parameters.AddWithValue("@p53", DBNull.Value)
            command.Parameters.AddWithValue("@p54", DBNull.Value)

            WriteToText(CommandAsSql(command))
            Dim LineID As Integer = 1
            For i = 0 To dsGroupedOperationB.Tables("OperationB").Rows.Count - 1
                Dim command4 As SqlCommand = BoCnx.CreateCommand()
                command4.Connection = BoCnx
                command4.CommandText = "spRs_OpertaionBInsert"
                command4.CommandType = CommandType.StoredProcedure
                command4.Parameters.AddWithValue("@p1", OperID)
                command4.Parameters.AddWithValue("@p2", cmbInvtype.EditValue)
                command4.Parameters.AddWithValue("@p3", LineID)
                command4.Parameters.AddWithValue("@p4", dsGroupedOperationB.Tables("OperationB").Rows(i).Item("ItembId"))
                command4.Parameters.AddWithValue("@p5", dsGroupedOperationB.Tables("OperationB").Rows(i).Item("Itemaid"))
                command4.Parameters.AddWithValue("@p6", dsGroupedOperationB.Tables("OperationB").Rows(i).Item("barcode"))

                command4.Parameters.AddWithValue("@p7", dsGroupedOperationB.Tables("OperationB").Rows(i).Item("itemshdescription"))
                command4.Parameters.AddWithValue("@p8", WhsCode)
                command4.Parameters.AddWithValue("@p9", dsGroupedOperationB.Tables("OperationB").Rows(i).Item("SizeCode"))
                command4.Parameters.AddWithValue("@p10", dsGroupedOperationB.Tables("OperationB").Rows(i).Item("ColorCode"))
                command4.Parameters.AddWithValue("@p11", dsGroupedOperationB.Tables("OperationB").Rows(i).Item("itemshdescription"))
                Dim AmtRnd = "0"
                Dim sqlcomm2 As New SqlCommand("Sp_GetHelpRates", BoCnx)
                sqlcomm2.CommandType = CommandType.StoredProcedure
                sqlcomm2.Parameters.AddWithValue("@Cmp", 1)
                sqlcomm2.Parameters.AddWithValue("@date1", DateTime.Today.ToString("yyyyMMdd"))
                sqlcomm2.Parameters.AddWithValue("@cur", dsGroupedOperationA.Tables("OperationA").Rows(0).Item("Curcode"))

                Dim blnconnectionOpen2 = ConnStatus(FrmLogin.objcon.con)
                If Not blnconnectionOpen2 Then ConnOpen(BoCnx)
                Dim ds As New DataSet
                ds.Clear()
                da = New SqlDataAdapter(sqlcomm2)
                da.Fill(ds, "Rates")
                If ds.Tables("Rates").Rows(0).Item("decimals") = 1 Then
                    AmtRnd = "0.0"
                ElseIf ds.Tables("Rates").Rows(0).Item("decimals") = 2 Then
                    AmtRnd = "0.00"
                ElseIf ds.Tables("Rates").Rows(0).Item("decimals") = 3 Then
                    AmtRnd = "0.000"
                End If
                command4.Parameters.AddWithValue("@p12", DBNull.Value)
                command4.Parameters.AddWithValue("@p13", 0)
                command4.Parameters.AddWithValue("@p14", 0)
                If dsGroupedOperationB.Tables("OperationB").Rows(i).Item("bqty") <> 0 Then
                    command4.Parameters.AddWithValue("@p15", Format(Math.Abs((dsGroupedOperationB.Tables("OperationB").Rows(i).Item("btotal") + dsGroupedOperationB.Tables("OperationB").Rows(i).Item("bdiscamt")) / dsGroupedOperationB.Tables("OperationB").Rows(i).Item("bqty")), AmtRnd))
                    'command4.Parameters.AddWithValue("@p15", Format(Math.Abs((Math.Abs(dsGroupedOperationB.Tables("OperationB").Rows(i).Item("btotal"))) / dsGroupedOperationB.Tables("OperationB").Rows(i).Item("bqty")), AmtRnd))
                Else
                    command4.Parameters.AddWithValue("@p15", 0)
                End If
                command4.Parameters.AddWithValue("@p16", dsGroupedOperationB.Tables("OperationB").Rows(i).Item("bqty"))
                command4.Parameters.AddWithValue("@p17", 0)
                command4.Parameters.AddWithValue("@p18", 0)
                command4.Parameters.AddWithValue("@p19", 0)
                command4.Parameters.AddWithValue("@p20", dsGroupedOperationB.Tables("OperationB").Rows(i).Item("uomcode"))
                command4.Parameters.AddWithValue("@p21", 1) 'factoor
                Dim signAffect As Integer
                Dim sqlcomm1 As New SqlCommand("select SignAffect from IvInvoiceType1ES where invtypeid=" & cmbInvtype.EditValue & "", BoCnx)
                Dim blnconnectionOpen1 = ConnStatus(BoCnx)
                If Not blnconnectionOpen1 Then ConnOpen(BoCnx)
                signAffect = sqlcomm1.ExecuteScalar
                command4.Parameters.AddWithValue("@p22", signAffect)
                command4.Parameters.AddWithValue("@p23", 0)
                command4.Parameters.AddWithValue("@p24", IIf(IsDBNull(dsGroupedOperationB.Tables("OperationB").Rows(i).Item("bdiscamt")) Or IsNothing(dsGroupedOperationB.Tables("OperationB").Rows(i).Item("bdiscamt")), 0, dsGroupedOperationB.Tables("OperationB").Rows(i).Item("bdiscamt")))
                command4.Parameters.AddWithValue("@p25", dsGroupedOperationB.Tables("OperationB").Rows(i).Item("btotal"))

                command4.Parameters.AddWithValue("@p26", dsGroupedOperationB.Tables("OperationB").Rows(i).Item("bvatamt"))

                command4.Parameters.AddWithValue("@p27", dsGroupedOperationB.Tables("OperationB").Rows(i).Item("VatPct"))    'VatPct

                command4.Parameters.AddWithValue("@p28", 0)
                If cmbInvtype.EditValue = FrmMainForm.SalesOrder Then
                    command4.Parameters.AddWithValue("@p29", 0)
                Else
                    command4.Parameters.AddWithValue("@p29", dsGroupedOperationB.Tables("OperationB").Rows(i).Item("bqty"))
                End If

                command4.Parameters.AddWithValue("@p30", 0)
                If cmbInvtype.EditValue = FrmMainForm.SalesOrder Then
                    command4.Parameters.AddWithValue("@p31", dsGroupedOperationB.Tables("OperationB").Rows(i).Item("bqty"))
                Else
                    command4.Parameters.AddWithValue("@p31", 0)
                End If
                command4.Parameters.AddWithValue("@p32", 0)
                command4.Parameters.AddWithValue("@p33", 0)
                command4.Parameters.AddWithValue("@p34", 0)
                command4.Parameters.AddWithValue("@p35", DBNull.Value)
                command4.Parameters.AddWithValue("@p36", DBNull.Value)
                command4.Parameters.AddWithValue("@p37", DBNull.Value)
                command4.Parameters.AddWithValue("@p38", FrmLogin.user)
                command4.Parameters.AddWithValue("@p39", DateTime.Today)
                command4.Parameters.AddWithValue("@p40", "")
                command4.Parameters.AddWithValue("@p41", DBNull.Value)
                command4.Parameters.AddWithValue("@p42", DBNull.Value)
                command4.Parameters.AddWithValue("@p43", LineID)
                command4.Parameters.AddWithValue("@p44", DBNull.Value)
                command4.Parameters.AddWithValue("@p45", DBNull.Value)
                LineID += 1
                WriteToText(CommandAsSql(command4))
            Next
            'Dim TypeId As Integer = 0
            'Dim TransID As Integer = 0
            'If cmbInvtype.EditValue = FrmMainForm.SalesInvoice Or cmbInvtype.EditValue = FrmMainForm.SalesReturn Then
            '    GroupReciepts()
            '    sqlcomm = New SqlCommand("select Sequence from sacsequence where SeqCode='transid' and seqyear=" & Today.Year & "", BoCnx)
            '    blnconnectionOpen = ConnStatus(BoCnx)
            '    If Not blnconnectionOpen Then ConnOpen(BoCnx)
            '    If IsDBNull(sqlcomm.ExecuteScalar) Or IsNothing(sqlcomm.ExecuteScalar) Then
            '        Dim sqlc As New SqlCommand("insert into SacSequence (SeqCode,SeqYear,Companyid,Sequence) values ('transid" & _
            '                               "'," & Today.Year & ",1," & Today.Year & "000000)", BoCnx)
            '        sqlc.ExecuteNonQuery()
            '    End If
            '    sqlcomm = New SqlCommand("select Sequence from sacsequence where SeqCode='transid' and seqyear=" & Today.Year & "", BoCnx)
            '    blnconnectionOpe = ConnStatus(BoCnx)
            '    If Not blnconnectionOpe Then ConnOpen(BoCnx)
            '    Dim OperID1 As Integer = sqlcomm.ExecuteScalar + 1

            '    TransID = sqlcomm.ExecuteScalar

            '    Dim command1 As SqlCommand = BoCnx.CreateCommand()
            '    command1.Connection = BoCnx
            '    command1.CommandText = "spRs_AcJournalAInsert"
            '    command1.CommandType = CommandType.StoredProcedure
            '    command1.Parameters.AddWithValue("@p1", TransID + 1)
            '    command1.Parameters.AddWithValue("@p2", "RV")

            '    Dim sqlcomm1 As New SqlCommand("select Sequence from sacsequence where SeqCode='" & "RV" & "' and seqyear=" & Today.Year & "", BoCnx)
            '    blnconnectionOpen = ConnStatus(BoCnx)
            '    If Not blnconnectionOpen Then ConnOpen(BoCnx)
            '    If IsDBNull(sqlcomm1.ExecuteScalar) Or IsNothing(sqlcomm1.ExecuteScalar) Then
            '        Dim sqlc As New SqlCommand("insert into SacSequence (SeqCode,SeqYear,Companyid,Sequence) values ('" & _
            '                       "RV" & "'," & Today.Year & ",1," & Today.Year & "000000)", BoCnx)
            '        sqlc.ExecuteNonQuery()
            '    End If
            '    blnconnectionOpen = ConnStatus(BoCnx)
            '    If Not blnconnectionOpen Then ConnOpen(BoCnx)
            '    TypeId = sqlcomm1.ExecuteScalar
            '    command1.Parameters.AddWithValue("@p3", TypeId + 1)
            '    command1.Parameters.AddWithValue("@p4", "")
            '    command1.Parameters.AddWithValue("@p5", datet)
            '    command1.Parameters.AddWithValue("@p6", datet)
            '    command1.Parameters.AddWithValue("@p7", 0)
            '    command1.Parameters.AddWithValue("@p8", 0)
            '    command1.Parameters.AddWithValue("@p9", "")
            '    command1.Parameters.AddWithValue("@p10", 2)
            '    command1.Parameters.AddWithValue("@p11", FrmLogin.user)
            '    command1.Parameters.AddWithValue("@p12", FrmLogin.user)
            '    WriteToText(CommandAsSql(command1))

            '    Dim command2 As SqlCommand = BoCnx.CreateCommand()
            '    command2.Connection = BoCnx
            '    command2.CommandText = "spRs_AcJournalBInsert"
            '    command2.CommandType = CommandType.StoredProcedure
            '    'Journal B
            '    Dim LineID1 As Integer = 1
            '    command2.Parameters.AddWithValue("@p1", TransID + 1)
            '    command2.Parameters.AddWithValue("@p2", LineID1)
            '    command2.Parameters.AddWithValue("@p3", LineID1)
            '    command2.Parameters.AddWithValue("@p4", FrmMainForm.AccCode)
            '    If cmbInvtype.EditValue = FrmMainForm.SalesInvoice Then
            '        command2.Parameters.AddWithValue("@p5", "C")
            '    ElseIf cmbInvtype.EditValue = FrmMainForm.SalesReturn Then
            '        command2.Parameters.AddWithValue("@p5", "D")
            '    End If
            '    command2.Parameters.AddWithValue("@p6", DBNull.Value)
            '    command2.Parameters.AddWithValue("@p7", DBNull.Value)
            '    command2.Parameters.AddWithValue("@p8", 1)
            '    command2.Parameters.AddWithValue("@p9", ThirdID)
            '    command2.Parameters.AddWithValue("@p10", DBNull.Value)
            '    command2.Parameters.AddWithValue("@p11", "")
            '    command2.Parameters.AddWithValue("@p12", FrmMainForm.CurCode)
            '    command2.Parameters.AddWithValue("@p13", 0)
            '    command2.Parameters.AddWithValue("@p14", Math.Round(CDbl(dsGroupedOperationA.Tables("OperationA").Rows(0).Item("net") + dsGroupedOperationA.Tables("OperationA").Rows(0).Item("vat")), CurDecimals))
            '    'LBP
            '    command2.Parameters.AddWithValue("@p15", Math.Round(CDbl(dsGroupedOperationA.Tables("OperationA").Rows(0).Item("net") + dsGroupedOperationA.Tables("OperationA").Rows(0).Item("vat")), CurDecimals))
            '    'USD
            '    Dim sqlcomm6 As New SqlCommand("select CurCode from SacCurrency where CurMain=2", BoCnx)
            '    If BoCnx.State = ConnectionState.Closed Then
            '        BoCnx.Open()
            '    End If
            '    Dim SecondCur = sqlcomm6.ExecuteScalar
            '    Dim salesRate = GetSalesRate(1, SecondCur, DateTime.Today.ToString("yyyyMMdd"))
            '    command2.Parameters.AddWithValue("@p16", Math.Round(CDbl(Math.Round(CDbl(dsGroupedOperationA.Tables("OperationA").Rows(0).Item("net") + dsGroupedOperationA.Tables("OperationA").Rows(0).Item("vat")), CurDecimals)) / salesRate, CurDecimals))
            '    command2.Parameters.AddWithValue("@p17", "Settlement Invoice " & OperIDg)
            '    'checkmaturity
            '    command2.Parameters.AddWithValue("@p18", Date.Today)
            '    command2.Parameters.AddWithValue("@p19", DBNull.Value)
            '    command2.Parameters.AddWithValue("@p20", DBNull.Value)
            '    command2.Parameters.AddWithValue("@p21", DBNull.Value)
            '    command2.Parameters.AddWithValue("@p22", FrmLogin.user)
            '    command2.Parameters.AddWithValue("@p23", DateTime.Today)
            '    command2.Parameters.AddWithValue("@p24", "")
            '    WriteToText(CommandAsSql(command2))
            '    LineID1 += 1
            '    For i As Integer = 0 To DsGroupedReciepts.Tables("Reciepts").Rows.Count - 1
            '        Dim command3 As SqlCommand = BoCnx.CreateCommand()
            '        command3.Connection = BoCnx
            '        command3.CommandText = "spRs_AcJournalBInsert"
            '        command3.CommandType = CommandType.StoredProcedure
            '        command3.Parameters.AddWithValue("@p1", TransID + 1)
            '        command3.Parameters.AddWithValue("@p2", LineID1)
            '        command3.Parameters.AddWithValue("@p3", LineID1)
            '        command3.Parameters.AddWithValue("@p4", DsGroupedReciepts.Tables("Reciepts").Rows(i).Item("AccCode"))
            '        If cmbInvtype.EditValue = FrmMainForm.SalesInvoice Then
            '            command3.Parameters.AddWithValue("@p5", "D")
            '        ElseIf cmbInvtype.EditValue = FrmMainForm.SalesReturn Then
            '            command3.Parameters.AddWithValue("@p5", "C")
            '        End If
            '        command3.Parameters.AddWithValue("@p6", DBNull.Value)
            '        command3.Parameters.AddWithValue("@p7", DBNull.Value)
            '        command3.Parameters.AddWithValue("@p8", 0)
            '        command3.Parameters.AddWithValue("@p9", DBNull.Value)
            '        command3.Parameters.AddWithValue("@p10", DsGroupedReciepts.Tables("Reciepts").Rows(i).Item("AuxBCode"))
            '        command3.Parameters.AddWithValue("@p11", "")
            '        command3.Parameters.AddWithValue("@p12", DsGroupedReciepts.Tables("Reciepts").Rows(i).Item("CurCode"))
            '        command3.Parameters.AddWithValue("@p13", 0)
            '        command3.Parameters.AddWithValue("@p14", Math.Round(DsGroupedReciepts.Tables("Reciepts").Rows(i).Item("Amount"), CurDecimals))
            '        'LBP
            '        command3.Parameters.AddWithValue("@p15", Math.Round(DsGroupedReciepts.Tables("Reciepts").Rows(i).Item("Fl_Amount"), CurDecimals))
            '        'USD
            '        command3.Parameters.AddWithValue("@p16", Math.Round(DsGroupedReciepts.Tables("Reciepts").Rows(i).Item("Sl_Amount"), CurDecimals))
            '        command3.Parameters.AddWithValue("@p17", "Settlement Invoice " & OperIDg)
            '        'checkmaturity
            '        command3.Parameters.AddWithValue("@p18", DBNull.Value)
            '        command3.Parameters.AddWithValue("@p19", DBNull.Value)
            '        command3.Parameters.AddWithValue("@p20", DBNull.Value)
            '        command3.Parameters.AddWithValue("@p21", DBNull.Value)
            '        command3.Parameters.AddWithValue("@p22", FrmLogin.user)
            '        command3.Parameters.AddWithValue("@p23", DateTime.Today)
            '        command3.Parameters.AddWithValue("@p24", "")
            '        LineID1 += 1
            '        WriteToText(CommandAsSql(command3))
            '    Next
            'End If
            Try
                Dim objReader As System.IO.StreamReader = Nothing
                Try
                    objReader = New System.IO.StreamReader("C:\BusinessPack\PosControl\SQL\sp.sql")
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                If BoCnx.State = ConnectionState.Closed Then
                    BoCnx.Open()
                End If
                Dim transaction As SqlTransaction = Nothing
                Dim transcommand As SqlCommand = BoCnx.CreateCommand()
                transaction = BoCnx.BeginTransaction("SampleTransaction")

                transcommand.Connection = BoCnx
                transcommand.Transaction = transaction
                transcommand.CommandText = objReader.ReadToEnd
                transcommand.CommandType = CommandType.Text
                Try
                    transcommand.ExecuteNonQuery()
                    transaction.Commit()


                    Dim sqlcomm3 As New SqlCommand("update sacsequence set Sequence=" & OperID & " where SeqCode='" & InvType & "' and seqyear=" & Today.Year & "", BoCnx)
                    Dim blnconnectionOpen3 = ConnStatus(BoCnx)
                    If Not blnconnectionOpen3 Then ConnOpen(BoCnx)
                    sqlcomm3.ExecuteNonQuery()

                    Dim Query As String = String.Empty
                    Query = "update IvOperationC1Es set Closed=1 where invtypeid = " & cmbInvtype.EditValue
                    Query = Query + " and PosCode = '" & cmbPOS.EditValue & "'"
                    Query = Query + " and OperDate = '" & datet.Date.ToString("yyyy/MM/dd") & "'"
                    Dim sqlcom As New SqlCommand(Query, FrmLogin.objcon.con)
                    If FrmLogin.objcon.con.State = ConnectionState.Closed Then
                        FrmLogin.objcon.con.Open()
                    End If
                    sqlcom.ExecuteNonQuery()


                    Query = String.Empty
                    Query = "update AcJournalD1Es set Status=1 where TransCode = 'RV'"
                    Query = Query + " and TransDate = '" & dtpDate.DateTime.Date.ToString("yyyy/MM/dd") & "'"
                    Query = Query + " and PosCode = '" & cmbPOS.EditValue & "'"
                    Query = Query + "  and TransID in (select MopTransID from IvOperationC1Es where InvTypeID = " & cmbInvtype.EditValue
                    Query = Query + " and PosCode = '" & cmbPOS.EditValue & "'"
                    Query = Query + " and OperDate = '" & dtpDate.DateTime.Date.ToString("yyyy/MM/dd") & "')"
                    Dim sqlcom8 As New SqlCommand(Query, FrmLogin.objcon.con)
                    If FrmLogin.objcon.con.State = ConnectionState.Closed Then
                        FrmLogin.objcon.con.Open()
                    End If
                    sqlcom8.ExecuteNonQuery()

                    Lbl.Text = "Successfully Grouped And Saved!"
                    FillDefault()
                    Cursor.Current = Cursors.Default
                Catch ex As Exception
                    Lbl.Text = "Error"
                    MessageBox.Show("Commit exctypr: " & ex.GetType().ToString, "Error")
                    MessageBox.Show("Message exctypr: " & ex.Message, "Error")
                    Utilities.WriteToText("Submit oper", ex.Message)
                    Lbl.Text = "Error!"
                    Cursor.Current = Cursors.Default
                    Try
                        transaction.Rollback()
                    Catch ex2 As Exception
                        MessageBox.Show("Rollback exctypr: " & ex2.GetType().ToString)
                        MessageBox.Show("Rollback msg: " & ex2.Message)
                        Utilities.WriteToText("Submit oper", ex2.Message)
                        Lbl.Text = "Error!"
                        Cursor.Current = Cursors.Default
                    End Try
                End Try
                objReader.Close()
                Cursor.Current = Cursors.Default
                'sqlcomm3 = New SqlCommand("update sacsequence set Sequence=" & TransID + 1 & " where SeqCode='transid' and seqyear=" & Today.Year & "", BoCnx)
                'blnconnectionOpen3 = ConnStatus(BoCnx)
                'If Not blnconnectionOpen3 Then ConnOpen(BoCnx)
                'sqlcomm3.ExecuteNonQuery()
                'sqlcomm3 = New SqlCommand("update sacsequence set Sequence=" & TypeId + 1 & " where SeqCode='" & "RV" & "' and seqyear=" & Today.Year & "", BoCnx)
                'blnconnectionOpen3 = ConnStatus(BoCnx)
                'If Not blnconnectionOpen3 Then ConnOpen(BoCnx)
                'sqlcomm3.ExecuteNonQuery()



                If Directory.Exists("C:\BusinessPack\PosControl\SQL") Then
                    My.Computer.FileSystem.DeleteDirectory("C:\BusinessPack\PosControl\SQL", FileIO.DeleteDirectoryOption.DeleteAllContents)
                End If
                Cursor.Current = Cursors.Default
            Catch ex As Exception
                Cursor.Current = Cursors.Default
                Lbl.Text = "Error"
                Utilities.WriteToText("Submit oper", ex.Message)
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Catch ex As Exception
            Lbl.Text = "Error"
            Utilities.WriteToText("Submit oper", ex.Message)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Public Shared Function ParameterValueForSQL(sp As SqlParameter) As [String]
        Dim retval As [String] = ""

        Select Case sp.SqlDbType
            Case SqlDbType.[Char], SqlDbType.NChar, SqlDbType.NText, SqlDbType.NVarChar, SqlDbType.Text, SqlDbType.Time,
             SqlDbType.VarChar, SqlDbType.Xml, SqlDbType.[Date], SqlDbType.DateTime, SqlDbType.DateTime2, SqlDbType.DateTimeOffset
                retval = "'" + sp.Value.ToString().Replace("'", "''") + "'"
                Exit Select

            Case SqlDbType.Bit
                retval = If((sp.Value.ToBooleanOrDefault(False)), "1", "0")
                Exit Select
            Case Else

                retval = sp.Value.ToString().Replace("'", "''")
                Exit Select
        End Select

        Return retval
    End Function

    Public Shared Function CommandAsSql(sc As SqlCommand) As [String]
        Dim sql As New StringBuilder()
        Dim FirstParam As [Boolean] = True

        sql.AppendLine("use " + sc.Connection.Database + ";")
        Select Case sc.CommandType
            Case CommandType.StoredProcedure
                For Each sp As SqlParameter In sc.Parameters
                    If (sp.Direction = ParameterDirection.InputOutput) OrElse (sp.Direction = ParameterDirection.Output) Then
                        sql.Append("declare " + sp.ParameterName + vbTab + sp.SqlDbType.ToString() + vbTab & "= ")


                        sql.AppendLine((If((sp.Direction = ParameterDirection.Output), "null", sp.Value())) + ";")
                    End If
                Next

                sql.AppendLine("exec [" + sc.CommandText + "]")

                For Each sp As SqlParameter In sc.Parameters
                    If sp.Direction <> ParameterDirection.ReturnValue Then
                        sql.Append(If((FirstParam), vbTab, vbTab & ", "))

                        If FirstParam Then
                            FirstParam = False
                        End If

                        If sp.Direction = ParameterDirection.Input Then
                            Dim v As New Object
                            If IsDBNull(CObj(sp.Value)) Then
                                v = "NULL"
                            ElseIf IsNothing(CObj(sp.Value)) Then
                                v = "NULL"
                            Else
                                v = sp.Value()
                            End If
                            If CStr(v) = "NULL" Then
                                sql.AppendLine(CStr(sp.ParameterName + " = " + CStr(v)))
                            Else
                                If TypeOf (CObj(v)) Is DateTime Then
                                    sql.AppendLine(CStr(sp.ParameterName + " = " + "'" + CDate(v).ToString("yyyyMMdd")) + "'")
                                Else
                                    sql.AppendLine(CStr(sp.ParameterName + " = " + "'" + CStr(v)) + "'")
                                End If
                            End If
                        Else

                            sql.AppendLine(sp.ParameterName + " = " + sp.ParameterName + " output")
                        End If
                    End If
                Next
                sql.AppendLine(";")

                For Each sp As SqlParameter In sc.Parameters
                    If (sp.Direction = ParameterDirection.InputOutput) OrElse (sp.Direction = ParameterDirection.Output) Then
                        sql.AppendLine("select '" + sp.ParameterName + "' = convert(varchar, " + sp.ParameterName + ");")
                    End If
                Next
                Exit Select
            Case CommandType.Text
                sql.AppendLine(sc.CommandText)
                Exit Select
        End Select

        Return sql.ToString()
    End Function
    Public Sub OperationAInsert()
        Try
            Dim BoConxString = "Data Source ='" & FrmMainForm.BOServer & "';Initial Catalog='" & FrmMainForm.BODatabase & "';user ID='" & FrmMainForm.BOUser & "';password='" & FrmMainForm.BOPass & "'"
            Dim BoCnx As SqlConnection = New SqlConnection(BoConxString)
            Dim InvType As String
            Dim clsOpa As New ClsOperationA
            Dim SqlCommand As New SqlCommand("select ToPost,TransCode from IvInvoiceType1Es where invtypeid=" & cmbInvtype.EditValue, BoCnx)
            Dim ds1 As New DataSet
            Dim blnconnectionOpen = ConnStatus(BoCnx)
            If Not blnconnectionOpen Then ConnOpen(BoCnx)
            da = New SqlDataAdapter(SqlCommand)
            da.Fill(ds1, "IvInv")
            If ds1.Tables("IvInv").Rows(0).Item("ToPost") = 1 Then
                InvType = ds1.Tables("IvInv").Rows(0).Item("TransCode")
            Else
                InvType = "invtype" & cmbInvtype.EditValue
            End If

            Dim sqlcomm As New SqlCommand("select Sequence from sacsequence where SeqCode='" & InvType & "' and seqyear=" & Today.Year & "", BoCnx)
            blnconnectionOpen = ConnStatus(BoCnx)
            If Not blnconnectionOpen Then ConnOpen(BoCnx)
            If IsDBNull(sqlcomm.ExecuteScalar) Or IsNothing(sqlcomm.ExecuteScalar) Then
                Dim sqlc As New SqlCommand("insert into SacSequence (SeqCode,SeqYear,Companyid,Sequence) values ('" & _
                                       InvType & "'," & Today.Year & ",1," & Today.Year & "000000)", BoCnx)
                sqlc.ExecuteNonQuery()
            End If
            sqlcomm = New SqlCommand("select Sequence from sacsequence where SeqCode='" & InvType & "' and seqyear=" & Today.Year & "", BoCnx)
            Dim blnconnectionOpe = ConnStatus(BoCnx)
            If Not blnconnectionOpe Then ConnOpen(BoCnx)
            Dim OperID As Integer = sqlcomm.ExecuteScalar + 1
            clsOpa._P1 = OperID
            OperIDg = OperID
            clsOpa._P2 = cmbInvtype.EditValue 'InvTypeID
            clsOpa._P3 = dtpDate.DateTime.Date
            clsOpa._P4 = dtpDate.DateTime.Date
            If cmbInvtype.EditValue = FrmMainForm.SalesOrder Then
                clsOpa._P5 = DBNull.Value 'we need to change it
                clsOpa._P6 = ""
            Else
                clsOpa._P5 = ThirdID
                Dim sqlcomm1 As New SqlCommand("select ShortName from SacThirdParty where thirdid=" & ThirdID & "", BoCnx)
                Dim blnconnectionOpen1 = ConnStatus(BoCnx)
                If Not blnconnectionOpen1 Then ConnOpen(BoCnx)
                Dim desc As String = sqlcomm1.ExecuteScalar
                clsOpa._P6 = desc
            End If
            clsOpa._P7 = SalesMan
            clsOpa._P8 = cmbPOS.EditValue
            clsOpa._P9 = dsGroupedOperationA.Tables("OperationA").Rows(0).Item("WHSCode") 'we need to change it
            clsOpa._P10 = DBNull.Value
            clsOpa._P11 = dsGroupedOperationA.Tables("OperationA").Rows(0).Item("Curcode") 'we need to change it
            clsOpa._P12 = DBNull.Value
            clsOpa._P13 = ""
            clsOpa._P14 = ""
            clsOpa._P15 = ""
            clsOpa._P16 = 0
            clsOpa._P17 = 0
            clsOpa._P18 = 1
            clsOpa._P19 = 1

            If cmbInvtype.EditValue = FrmMainForm.SalesOrder Then
                clsOpa._P20 = 0 ' cLOSED
            Else
                clsOpa._P20 = 1 ' cLOSED
            End If
            clsOpa._P21 = dsGroupedOperationA.Tables("OperationA").Rows(0).Item("RateFL")
            clsOpa._P22 = dsGroupedOperationA.Tables("OperationA").Rows(0).Item("RateSL")
            clsOpa._P23 = dsGroupedOperationA.Tables("OperationA").Rows(0).Item("RateVat")
            clsOpa._P24 = String.Empty
            clsOpa._P25 = DateTime.Today
            Dim Gross = dsGroupedOperationA.Tables("OperationA").Rows(0).Item("gross")
            clsOpa._P26 = IIf(IsDBNull(Gross) Or IsNothing(Gross), 0, Gross)
            clsOpa._P27 = 0 'Disc1Pct
            Dim Disc1Amt = dsGroupedOperationA.Tables("OperationA").Rows(0).Item("disc1amt")
            clsOpa._P28 = IIf(IsDBNull(Disc1Amt) Or IsNothing(Disc1Amt), 0, Disc1Amt)
            clsOpa._P29 = 0
            clsOpa._P30 = 0
            clsOpa._P31 = 0
            clsOpa._P32 = 0
            clsOpa._P33 = 0
            clsOpa._P34 = dsGroupedOperationA.Tables("OperationA").Rows(0).Item("net")
            Dim VatAmt = dsGroupedOperationA.Tables("OperationA").Rows(0).Item("vat")
            clsOpa._P35 = IIf(IsDBNull(VatAmt) Or IsNothing(VatAmt), 0, VatAmt)
            clsOpa._P36 = ""
            clsOpa._P37 = FrmLogin.user
            clsOpa._P38 = FrmLogin.user
            clsOpa._P39 = DateTime.Today
            clsOpa._P40 = DBNull.Value
            clsOpa._P41 = DBNull.Value
            clsOpa._P42 = DBNull.Value
            clsOpa._P43 = DBNull.Value
            clsOpa._P44 = 0
            clsOpa._P45 = 0
            clsOpa._P46 = 0
            clsOpa._P47 = 0
            clsOpa._P48 = 0
            clsOpa._P49 = 0
            clsOpa._P50 = 0
            clsOpa._P51 = 0
            clsOpa._P52 = DBNull.Value
            clsOpa._P53 = DBNull.Value
            clsOpa._P54 = DBNull.Value
            clsOpa.OperationAInsert(BoCnx)
            'we need to change it
            Dim sqlcomm3 As New SqlCommand("update sacsequence set Sequence=" & OperID & " where SeqCode='" & InvType & "' and seqyear=" & Today.Year & "", BoCnx)
            Dim blnconnectionOpen3 = ConnStatus(BoCnx)
            If Not blnconnectionOpen3 Then ConnOpen(BoCnx)
            sqlcomm3.ExecuteNonQuery()
            Dim LineID As Integer = 1
            For i = 0 To dsGroupedOperationB.Tables("OperationB").Rows.Count - 1
                Dim ClsOpB As New ClsOperationB
                ClsOpB._P1 = OperID
                ClsOpB._P2 = cmbInvtype.EditValue
                ClsOpB._P3 = LineID
                ClsOpB._P4 = dsGroupedOperationB.Tables("OperationB").Rows(i).Item("ItembId")
                ClsOpB._P5 = dsGroupedOperationB.Tables("OperationB").Rows(i).Item("Itemaid")
                ClsOpB._P6 = dsGroupedOperationB.Tables("OperationB").Rows(i).Item("barcode")
                ClsOpB._P7 = dsGroupedOperationB.Tables("OperationB").Rows(i).Item("itemshdescription")
                ClsOpB._P8 = dsGroupedOperationA.Tables("OperationA").Rows(0).Item("WhsCode")
                ClsOpB._P9 = dsGroupedOperationB.Tables("OperationB").Rows(i).Item("SizeCode")
                ClsOpB._P10 = dsGroupedOperationB.Tables("OperationB").Rows(i).Item("ColorCode")
                ClsOpB._P11 = dsGroupedOperationB.Tables("OperationB").Rows(i).Item("itemshdescription")
                ClsOpB._P12 = DBNull.Value
                ClsOpB._P13 = 0
                ClsOpB._P14 = 0
                Dim AmtRnd = "0"
                Dim sqlcomm2 As New SqlCommand("Sp_GetHelpRates", BoCnx)
                sqlcomm2.CommandType = CommandType.StoredProcedure
                sqlcomm2.Parameters.AddWithValue("@Cmp", 1)
                sqlcomm2.Parameters.AddWithValue("@date1", DateTime.Today.ToString("yyyyMMdd"))
                sqlcomm2.Parameters.AddWithValue("@cur", dsGroupedOperationA.Tables("OperationA").Rows(0).Item("Curcode"))
                Dim blnconnectionOpen2 = ConnStatus(FrmLogin.objcon.con)
                If Not blnconnectionOpen2 Then ConnOpen(BoCnx)
                Dim ds As New DataSet
                ds.Clear()
                da = New SqlDataAdapter(sqlcomm2)
                da.Fill(ds, "Rates")
                If ds.Tables("Rates").Rows(0).Item("decimals") = 1 Then
                    AmtRnd = "0.0"
                ElseIf ds.Tables("Rates").Rows(0).Item("decimals") = 2 Then
                    AmtRnd = "0.00"
                ElseIf ds.Tables("Rates").Rows(0).Item("decimals") = 3 Then
                    AmtRnd = "0.000"
                End If
                If dsGroupedOperationB.Tables("OperationB").Rows(i).Item("bqty") <> 0 Then
                    ClsOpB._P15 = Format(Math.Abs((Math.Abs(dsGroupedOperationB.Tables("OperationB").Rows(i).Item("btotal")) + dsGroupedOperationB.Tables("OperationB").Rows(i).Item("bdiscamt")) / dsGroupedOperationB.Tables("OperationB").Rows(i).Item("bqty")), AmtRnd)
                Else
                    ClsOpB._P15 = 0
                End If
                ClsOpB._P16 = dsGroupedOperationB.Tables("OperationB").Rows(i).Item("bqty")
                ClsOpB._P17 = 0
                ClsOpB._P18 = 0
                ClsOpB._P19 = 0
                ClsOpB._P20 = dsGroupedOperationB.Tables("OperationB").Rows(i).Item("uomcode")
                ClsOpB._P21 = 1
                ClsOpB._P22 = dsGroupedOperationB.Tables("OperationB").Rows(i).Item("bsign")
                ClsOpB._P23 = 0
                ClsOpB._P24 = 0
                ClsOpB._P25 = dsGroupedOperationB.Tables("OperationB").Rows(i).Item("btotal")
                ClsOpB._P26 = dsGroupedOperationB.Tables("OperationB").Rows(i).Item("bvatamt")
                If dsGroupedOperationB.Tables("OperationB").Rows(i).Item("btotal") <> 0 Then
                    ClsOpB._P27 = Format(100 * dsGroupedOperationB.Tables("OperationB").Rows(i).Item("bvatamt") / dsGroupedOperationB.Tables("OperationB").Rows(i).Item("btotal"), ".0")
                Else
                    ClsOpB._P27 = 0
                End If
                ClsOpB._P28 = 0
                If cmbInvtype.EditValue = FrmMainForm.SalesOrder Then
                    ClsOpB._P29 = 0
                Else
                    ClsOpB._P29 = dsGroupedOperationB.Tables("OperationB").Rows(i).Item("bqty")
                End If
                ClsOpB._P30 = 0
                If cmbInvtype.EditValue = FrmMainForm.SalesOrder Then
                    ClsOpB._P31 = dsGroupedOperationB.Tables("OperationB").Rows(i).Item("bqty")
                Else
                    ClsOpB._P31 = 0
                End If
                ClsOpB._P32 = 0
                ClsOpB._P33 = 0
                ClsOpB._P34 = 0
                ClsOpB._P35 = DBNull.Value
                ClsOpB._P36 = DBNull.Value
                ClsOpB._P37 = DBNull.Value
                ClsOpB._P38 = FrmLogin.user
                ClsOpB._P39 = DateTime.Today
                ClsOpB._P40 = ""
                ClsOpB._P41 = DBNull.Value
                ClsOpB._P42 = DBNull.Value
                ClsOpB._P43 = LineID
                ClsOpB._P44 = DBNull.Value
                ClsOpB._P45 = DBNull.Value
                ClsOpB.OperationBInsert(BoCnx)
                LineID += 1
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub UpdateReciept()
        Try
            For i As Integer = 0 To RecieptView.DataRowCount - 1
                Dim clsJournalb As New ClsJournalB
                Dim Pos = cmbPOS.EditValue
                If (Not IsDBNull(RecieptView.GetRowCellValue(i, "LigneID")) And Not IsNothing(RecieptView.GetRowCellValue(i, "LigneID"))) Then
                    Dim LigneID = RecieptView.GetRowCellValue(i, "LigneID")
                    Dim sqlcomm4 As New SqlCommand("select AccCode from RsMop where Code='" & RecieptView.GetRowCellValue(i, "Code") & "'", FrmLogin.objcon.con)
                    Dim AccCode = sqlcomm4.ExecuteScalar
                    Dim sqlcomm5 As New SqlCommand("select AuxbCode from RsMop where Code='" & RecieptView.GetRowCellValue(i, "Code") & "'", FrmLogin.objcon.con)
                    Dim AuxbCode = IIf(IsDBNull(sqlcomm5.ExecuteScalar) Or IsNothing(sqlcomm5.ExecuteScalar), "", sqlcomm5.ExecuteScalar)
                    Dim CurCode = IIf(IsNothing(RecieptView.GetRowCellValue(i, "CurCode")) Or IsDBNull(RecieptView.GetRowCellValue(i, "CurCode")), DBNull.Value, RecieptView.GetRowCellValue(i, "CurCode"))
                    Dim Amount = IIf(IsNothing(RecieptView.GetRowCellValue(i, "Amount")) Or IsDBNull(RecieptView.GetRowCellValue(i, "Amount")), 0, Math.Round(RecieptView.GetRowCellValue(i, "Amount"), CurDecimals))
                    Dim FlAMount = IIf(IsNothing(RecieptView.GetRowCellValue(i, "LBP")) Or IsDBNull(RecieptView.GetRowCellValue(i, "LBP")), 0, Math.Round(RecieptView.GetRowCellValue(i, "LBP"), CurDecimals))
                    Dim SLAmout = IIf(IsNothing(RecieptView.GetRowCellValue(i, "USD")) Or IsDBNull(RecieptView.GetRowCellValue(i, "USD")), 0, Math.Round(RecieptView.GetRowCellValue(i, "USD"), CurDecimals))
                    Dim CheckMaturity = IIf(IsNothing(RecieptView.GetRowCellValue(i, "CheckMaturity")) Or IsDBNull(RecieptView.GetRowCellValue(i, "CheckMaturity")), Date.Today, RecieptView.GetRowCellValue(i, "CheckMaturity"))
                    Dim CheckNbr = IIf(IsNothing(RecieptView.GetRowCellValue(i, "CheckNbr")) Or IsDBNull(RecieptView.GetRowCellValue(i, "CheckNbr")), "", RecieptView.GetRowCellValue(i, "CheckNbr"))
                    Dim CheckBank = IIf(IsNothing(RecieptView.GetRowCellValue(i, "CheckBank")) Or IsDBNull(RecieptView.GetRowCellValue(i, "CheckBank")), "", RecieptView.GetRowCellValue(i, "CheckBank"))
                    clsJournalb.UpdateReciept(mopTransID, Pos, LigneID, AccCode, AuxbCode, CurCode, Amount, FlAMount, SLAmout, CheckMaturity, CheckNbr, CheckBank, FrmLogin.objcon.con)
                Else
                    clsJournalb._P1 = mopTransID
                    Dim sqlcom As New SqlCommand("select max(ligneID) + 1 from AcJournalE1Es where TransID= " & mopTransID & " and Thirdid is null", FrmLogin.objcon.con)
                    clsJournalb._P2 = sqlcom.ExecuteScalar
                    clsJournalb._P3 = sqlcom.ExecuteScalar
                    Dim sqlcomm4 As New SqlCommand("select AccCode from RsMop where Code='" & RecieptView.GetRowCellValue(i, "Code") & "'", FrmLogin.objcon.con)
                    clsJournalb._P4 = sqlcomm4.ExecuteScalar
                    clsJournalb._P5 = "D"
                    clsJournalb._P6 = DBNull.Value
                    clsJournalb._P7 = DBNull.Value
                    clsJournalb._P8 = 0
                    clsJournalb._P9 = DBNull.Value
                    Dim sqlcomm5 As New SqlCommand("select AuxbCode from RsMop where Code='" & RecieptView.GetRowCellValue(i, "Code") & "'", FrmLogin.objcon.con)
                    clsJournalb._P10 = sqlcomm5.ExecuteScalar
                    clsJournalb._P11 = ""
                    clsJournalb._P12 = IIf(IsNothing(RecieptView.GetRowCellValue(i, "CurCode")) Or IsDBNull(RecieptView.GetRowCellValue(i, "CurCode")), DBNull.Value, RecieptView.GetRowCellValue(i, "CurCode"))
                    clsJournalb._P13 = 0
                    clsJournalb._P14 = IIf(IsNothing(RecieptView.GetRowCellValue(i, "Amount")) Or IsDBNull(RecieptView.GetRowCellValue(i, "Amount")), 0, Math.Round(RecieptView.GetRowCellValue(i, "Amount"), CurDecimals))
                    'LBP
                    clsJournalb._P15 = IIf(IsNothing(RecieptView.GetRowCellValue(i, "LBP")) Or IsDBNull(RecieptView.GetRowCellValue(i, "LBP")), 0, Math.Round(RecieptView.GetRowCellValue(i, "LBP"), CurDecimals))
                    clsJournalb._P16 = IIf(IsNothing(RecieptView.GetRowCellValue(i, "USD")) Or IsDBNull(RecieptView.GetRowCellValue(i, "USD")), 0, Math.Round(RecieptView.GetRowCellValue(i, "USD"), CurDecimals))
                    clsJournalb._P17 = "Settlement Invoice " & txtid.Text
                    'checkmaturity
                    clsJournalb._P18 = IIf(IsNothing(RecieptView.GetRowCellValue(i, "CheckMaturity")) Or IsDBNull(RecieptView.GetRowCellValue(i, "CheckMaturity")), Date.Today, RecieptView.GetRowCellValue(i, "CheckMaturity"))
                    clsJournalb._P19 = IIf(IsNothing(RecieptView.GetRowCellValue(i, "CheckNbr")) Or IsDBNull(RecieptView.GetRowCellValue(i, "CheckNbr")), DBNull.Value, RecieptView.GetRowCellValue(i, "CheckNbr"))
                    clsJournalb._P20 = IIf(IsNothing(RecieptView.GetRowCellValue(i, "CheckBank")) Or IsDBNull(RecieptView.GetRowCellValue(i, "CheckBank")), DBNull.Value, RecieptView.GetRowCellValue(i, "CheckBank"))
                    clsJournalb._P21 = IIf(IsNothing(RecieptView.GetRowCellValue(i, "CheckNote")) Or IsDBNull(RecieptView.GetRowCellValue(i, "CheckNote")), DBNull.Value, RecieptView.GetRowCellValue(i, "CheckNote"))
                    clsJournalb._P22 = FrmLogin.user
                    clsJournalb._P23 = DateTime.Today
                    clsJournalb._P24 = ""
                    clsJournalb.BoJournalBInsert(cmbPOS.EditValue, FrmLogin.objcon.con)
                End If
            Next
            Dim sqlcomm6 As New SqlCommand("select CurCode from SacCurrency where CurMain=2", FrmLogin.objcon.con)
            If FrmLogin.objcon.con.State = ConnectionState.Closed Then
                FrmLogin.objcon.con.Open()
            End If
            Dim SecondCur = sqlcomm6.ExecuteScalar
            Dim salesRate = GetSalesRate(1, SecondCur, DateTime.Today.ToString("yyyyMMdd"))
            Dim SLAmount = Math.Round(CDbl(txtNet.Text) / salesRate, CurDecimals)
            Dim sqlCom2 As New SqlCommand("update AcJournalE1Es set Amount = " & Math.Round(CDbl(txtNet.Text), CurDecimals) & "" _
                                         & ", Fl_Amount = " & Math.Round(CDbl(txtNet.Text), CurDecimals) & ",Sl_Amount = " & SLAmount & " where ligneid = 1 and TransID = " & mopTransID, FrmLogin.objcon.con)
            sqlCom2.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class