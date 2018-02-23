Imports DevExpress.XtraGrid.Views.Base
Imports System.Data.SqlClient
Imports ConnectionSQL
Public Class FrmAdjustment
    Implements Procedures
    Dim add As Boolean = False
    Dim BoConxString = "Data Source ='" & FrmMainForm.BOServer & "';Initial Catalog='" & FrmMainForm.BODatabase & "';user ID='" & FrmMainForm.BOUser & "';password='" & FrmMainForm.BOPass & "'"
    Dim BoCnx As SqlConnection = New SqlConnection(BoConxString)
    Dim edit As Boolean = False
    Public Sub InitGrid()
        Try
            Dim View As ColumnView = GridControl1.MainView
            View.Columns(0).FieldName = "ItemAID"
            View.Columns(1).FieldName = "ItemBID"
            View.Columns(2).FieldName = "ShDescription"
            View.Columns(3).FieldName = "UOMCode"
            View.Columns(4).FieldName = "Barcode"
            View.Columns(4).VisibleIndex = 0
            View.Columns(5).FieldName = "Description"
            View.Columns(5).VisibleIndex = 1
            View.Columns(6).FieldName = "ColorCode"
            View.Columns(6).VisibleIndex = 2
            View.Columns(7).FieldName = "SizeCode"
            View.Columns(7).VisibleIndex = 3
            View.Columns(8).FieldName = "Qty"
            View.Columns(8).VisibleIndex = 4
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub CreateEmptyDataTable()
        Dim dt As New DataTable()
        dt.Columns.Add("ItemAID", GetType(Integer))
        dt.Columns.Add("ItemBID", GetType(Integer))
        dt.Columns.Add("ShDescription", GetType(String))
        dt.Columns.Add("UOMCode", GetType(String))
        dt.Columns.Add("Barcode", GetType(String))
        dt.Columns.Add("Description", GetType(String))
        dt.Columns.Add("ColorCode", GetType(String))
        dt.Columns.Add("SizeCode", GetType(String))
        dt.Columns.Add("Qty", GetType(Integer))
        GridControl1.DataSource = dt
    End Sub
    Private Sub FrmAdjustment_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            InitGrid()
            CreateEmptyDataTable()
            Dim ClsPos As New ClsPOS
            Dim dt As New DataTable
            dt = ClsPos.GetWhsConfig(FrmLogin.objcon.con)
            CmbWhs.Properties.DisplayMember = "WhsCode"
            CmbWhs.Properties.ValueMember = "WhsCode"
            CmbWhs.Properties.DataSource = dt
            ViewMode()
            LockUnlockMe()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub ViewMode()
        add = False
        edit = False
        Me.Text = "Whs Adjustments <" & My.Application.Info.Version.ToString & "> View Mode"
    End Sub
    Public Function cancel() As Object Implements Procedures.cancel
        Try
            If MessageBox.Show("Cancel All Modifications?", "Cancel", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                ViewMode()
                GridControl1.DataSource = Nothing
                Return True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Public Sub close1() Implements Procedures.close
        Me.Close()
    End Sub

    Public Sub DeleteRecord() Implements Procedures.DeleteRecord
        Exit Sub
    End Sub

    Public Function EditRecord() As Object Implements Procedures.EditRecord
        If GridView1.RowCount = 0 Then Return False
        Me.Text = "Whs Adjustments <" & My.Application.Info.Version.ToString & "> Edit Mode"
        edit = True
        add = False
        Return True
    End Function

    Public Sub FillDefault() Implements Procedures.FillDefault
        Exit Sub
    End Sub

    Public Sub find() Implements Procedures.find
        Exit Sub
    End Sub

    Public Sub FirstRecord() Implements Procedures.FirstRecord
        Exit Sub
    End Sub

    Public Sub lastRecord() Implements Procedures.lastRecord
        Exit Sub
    End Sub

    Public Sub LockUnlockMe() Implements Procedures.LockUnlockMe
        If add = False And edit = False Then
            GridView1.OptionsBehavior.Editable = False
        Else
            GridView1.OptionsBehavior.Editable = True
        End If
    End Sub

    Public Sub MenuLockUnlock(Adding As Boolean, Editing As Boolean) Implements Procedures.MenuLockUnlock
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

    Public Function NewRecord() As Object Implements Procedures.NewRecord
        Return False
    End Function

    Public Sub nextRecord() Implements Procedures.nextRecord
        Exit Sub
    End Sub

    Public Sub PreviousRecord() Implements Procedures.PreviousRecord
        Exit Sub
    End Sub

    Public Sub print() Implements Procedures.print
        Exit Sub
    End Sub

    Public Sub Refresh1() Implements Procedures.Refresh
        Exit Sub
    End Sub

    Public Function Save() As Object Implements Procedures.Save
        If IsNothing(CmbWhs.EditValue) Or IsDBNull(CmbWhs.EditValue) Then
            MessageBox.Show("Whs is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        If GridView1.DataRowCount = 0 Then
            MessageBox.Show("There are no items!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        If add = False And edit = True Then
            OperationAInsert()
            ViewMode()
            GridControl1.DataSource = Nothing
            Return True
        End If
    End Function

    Public Sub Search() Implements Procedures.Search
        Exit Sub
    End Sub

    Private Sub txtdesc_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtdesc.KeyDown
        Try
            FrmBrowse.GridView1.OptionsView.ColumnAutoWidth = True
            If txtdesc.Text = " " And e.KeyCode = Keys.Enter Then
                FrmBrowse.GridControl1.DataSource = Browse.GetAdjustmentItems(txtdesc.Text, BoCnx)
                FrmBrowse.Text = "Items"
                FrmBrowse.GridControl1.Refresh()
                FrmBrowse.ShowInTaskbar = False
                FrmBrowse.GridView1.Columns("ItemAID").Visible = False
                FrmBrowse.GridView1.Columns("ShDescription").Visible = False
                FrmBrowse.GridView1.Columns("UOMCode").Visible = False
                FrmBrowse.GridView1.Columns("ItemBID").Visible = False
                FrmBrowse.ShowDialog()

                If FrmBrowse.dt.Rows.Count = 0 Then Exit Sub
                GridView1.AddNewRow()
                Dim rowHandle As Integer = GridView1.GetRowHandle(GridView1.DataRowCount)

                GridView1.SetRowCellValue(rowHandle, "ShDescription", FrmBrowse.dt.Rows(0).Item("ShDescription").ToString)
                GridView1.SetRowCellValue(rowHandle, "UOMCode", FrmBrowse.dt.Rows(0).Item("UOMCode").ToString)
                GridView1.SetRowCellValue(rowHandle, "ItemAID", FrmBrowse.dt.Rows(0).Item("ItemAID").ToString)
                GridView1.SetRowCellValue(rowHandle, "ItemBID", FrmBrowse.dt.Rows(0).Item("ItemBID").ToString)
                GridView1.SetRowCellValue(rowHandle, "SizeCode", FrmBrowse.dt.Rows(0).Item("SizeCode").ToString)
                GridView1.SetRowCellValue(rowHandle, "ColorCode", FrmBrowse.dt.Rows(0).Item("ColorCode").ToString)
                GridView1.SetRowCellValue(rowHandle, "Description", FrmBrowse.dt.Rows(0).Item("Description").ToString)
                GridView1.SetRowCellValue(rowHandle, "Qty", FrmBrowse.dt.Rows(0).Item("Qty").ToString)
                GridView1.SetRowCellValue(rowHandle, "Barcode", FrmBrowse.dt.Rows(0).Item("Barcode"))
                txtdesc.Text = ""
            Else
                FrmBrowse.Text = "Items"
                If e.KeyCode = Keys.Enter Then
                    Dim dt As New DataTable
                    dt = Browse.GetAdjustmentItems(txtdesc.Text, BoCnx)
                    FrmBrowse.GridControl1.DataSource = dt
                    If FrmBrowse.GridView1.DataRowCount - 1 = 0 Then
                        GridView1.AddNewRow()
                        Dim rowHandle As Integer = GridView1.GetRowHandle(GridView1.DataRowCount)
                        GridView1.SetRowCellValue(rowHandle, "ItemAID", dt.Rows(0).Item("ItemAID").ToString)
                        GridView1.SetRowCellValue(rowHandle, "ItemBID", dt.Rows(0).Item("ItemBID").ToString)
                        GridView1.SetRowCellValue(rowHandle, "ShDescription", dt.Rows(0).Item("ShDescription").ToString)
                        GridView1.SetRowCellValue(rowHandle, "UOMCode", dt.Rows(0).Item("UOMCode").ToString)
                        GridView1.SetRowCellValue(rowHandle, "SizeCode", dt.Rows(0).Item("SizeCode").ToString)
                        GridView1.SetRowCellValue(rowHandle, "ColorCode", dt.Rows(0).Item("ColorCode").ToString)
                        GridView1.SetRowCellValue(rowHandle, "Description", dt.Rows(0).Item("Description").ToString)
                        GridView1.SetRowCellValue(rowHandle, "Qty", dt.Rows(0).Item("Qty").ToString)
                        GridView1.SetRowCellValue(rowHandle, "Barcode", dt.Rows(0).Item("Barcode"))
                        txtdesc.Text = ""
                    Else
                        FrmBrowse.GridControl1.Refresh()
                        FrmBrowse.Text = "Items"
                        FrmBrowse.ShowInTaskbar = False
                        FrmBrowse.GridView1.Columns("ItemAID").Visible = False
                        FrmBrowse.GridView1.Columns("ShDescription").Visible = False
                        FrmBrowse.GridView1.Columns("UOMCode").Visible = False
                        FrmBrowse.GridView1.Columns("ItemBID").Visible = False
                        FrmBrowse.ShowDialog()
                        If FrmBrowse.dt.Rows.Count = 0 Then Exit Sub
                        'FrmBrowse.dt = dt
                        GridView1.AddNewRow()
                        Dim rowHandle As Integer = GridView1.GetRowHandle(GridView1.DataRowCount)
                        GridView1.SetRowCellValue(rowHandle, "ItemAID", FrmBrowse.dt.Rows(0).Item("ItemAID").ToString)
                        GridView1.SetRowCellValue(rowHandle, "ItemBID", FrmBrowse.dt.Rows(0).Item("ItemBID").ToString)
                        GridView1.SetRowCellValue(rowHandle, "ShDescription", FrmBrowse.dt.Rows(0).Item("ShDescription").ToString)
                        GridView1.SetRowCellValue(rowHandle, "UOMCode", FrmBrowse.dt.Rows(0).Item("UOMCode").ToString)
                        GridView1.SetRowCellValue(rowHandle, "SizeCode", FrmBrowse.dt.Rows(0).Item("SizeCode").ToString)
                        GridView1.SetRowCellValue(rowHandle, "ColorCode", FrmBrowse.dt.Rows(0).Item("ColorCode").ToString)
                        GridView1.SetRowCellValue(rowHandle, "Description", FrmBrowse.dt.Rows(0).Item("Description").ToString)
                        GridView1.SetRowCellValue(rowHandle, "Qty", FrmBrowse.dt.Rows(0).Item("Qty").ToString)
                        GridView1.SetRowCellValue(rowHandle, "Barcode", FrmBrowse.dt.Rows(0).Item("Barcode"))
                        txtdesc.Text = ""
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Public Sub OperationAInsert()
        Dim OperIDg
        Try
            Dim clsOpa As New ClsOperationA
            Dim sqlcomm As New SqlCommand("select Sequence from sacsequence where SeqCode='invtype" & FrmMainForm.WhsAdjustment & "' and seqyear=" & Today.Year & "", FrmLogin.objcon.con)
            Dim blnconnectionOpen = ConnStatus(FrmLogin.objcon.con)
            If Not blnconnectionOpen Then ConnOpen(FrmLogin.objcon.con)
            If IsDBNull(sqlcomm.ExecuteScalar) Or IsNothing(sqlcomm.ExecuteScalar) Then
                Dim sqlc As New SqlCommand("insert into SacSequence (SeqCode,SeqYear,Companyid,Sequence) values ('invtype" & _
                                       FrmMainForm.WhsAdjustment & "'," & Today.Year & ",1," & Today.Year & "000000)", FrmLogin.objcon.con)
                sqlc.ExecuteNonQuery()
            End If
            sqlcomm = New SqlCommand("select Sequence from sacsequence where SeqCode='invtype" & FrmMainForm.WhsAdjustment & "' and seqyear=" & Today.Year & "", FrmLogin.objcon.con)
            Dim blnconnectionOpe = ConnStatus(FrmLogin.objcon.con)
            If Not blnconnectionOpe Then ConnOpen(FrmLogin.objcon.con)
            Dim OperID As Integer = sqlcomm.ExecuteScalar + 1
            clsOpa._P1 = OperID
            OperIDg = OperID
            clsOpa._P2 = FrmMainForm.WhsAdjustment 'OrderTypeID
            clsOpa._P3 = DateTime.Today
            clsOpa._P4 = DateTime.Today
            clsOpa._P5 = DBNull.Value
            clsOpa._P6 = ""
            clsOpa._P7 = DBNull.Value
            sqlcomm = New SqlCommand("select Poscode from PolyPosConf where WhsCode = '" & CmbWhs.EditValue & "'", FrmLogin.objcon.con)
            blnconnectionOpe = ConnStatus(FrmLogin.objcon.con)
            If Not blnconnectionOpe Then ConnOpen(FrmLogin.objcon.con)
            Dim Poscode = sqlcomm.ExecuteScalar
            clsOpa._P8 = Poscode
            clsOpa._P9 = CmbWhs.EditValue
            clsOpa._P10 = DBNull.Value
            clsOpa._P11 = DBNull.Value
            clsOpa._P12 = DBNull.Value
            clsOpa._P13 = ""
            clsOpa._P14 = ""
            clsOpa._P15 = ""
            clsOpa._P16 = 0
            clsOpa._P17 = 0
            clsOpa._P18 = 1
            clsOpa._P19 = 1
            clsOpa._P20 = 1 ' cLOSED
            clsOpa._P21 = 0
            clsOpa._P22 = 0
            'SalesSLRate = ds.Tables("Rates").Rows(0).Item("SalesslRate")
            clsOpa._P23 = 0
            clsOpa._P24 = String.Empty
            clsOpa._P25 = DateTime.Today
            clsOpa._P26 = 0
            clsOpa._P27 = 0
            clsOpa._P28 = 0
            clsOpa._P29 = 0
            clsOpa._P30 = 0
            clsOpa._P31 = 0
            clsOpa._P32 = 0
            clsOpa._P33 = 0
            clsOpa._P34 = 0
            clsOpa._P35 = 0
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
            clsOpa.OperationCInsert(FrmLogin.objcon.con)
            Dim sqlcomm3 As New SqlCommand("update sacsequence set Sequence=" & OperID & " where SeqCode='invtype" & FrmMainForm.WhsAdjustment & "' and seqyear=" & Today.Year & "", FrmLogin.objcon.con)
            Dim blnconnectionOpen3 = ConnStatus(FrmLogin.objcon.con)
            If Not blnconnectionOpen3 Then ConnOpen(FrmLogin.objcon.con)
            sqlcomm3.ExecuteNonQuery()
            Dim LineID As Integer = 1
            For i As Integer = 0 To GridView1.DataRowCount - 1
                If (Not IsDBNull(GridView1.GetRowCellValue(i, "ItemAID")) And Not IsNothing(GridView1.GetRowCellValue(i, "ItemAID"))) Then
                    Dim ClsOpB As New ClsOperationB
                    ClsOpB._P1 = OperIDg
                    ClsOpB._P2 = FrmMainForm.WhsAdjustment
                    ClsOpB._P3 = LineID
                    ClsOpB._P4 = IIf(IsNothing(GridView1.GetRowCellValue(i, "ItemBID")) Or IsDBNull(GridView1.GetRowCellValue(i, "ItemBID")), DBNull.Value, GridView1.GetRowCellValue(i, "ItemBID"))
                    ClsOpB._P5 = IIf(IsNothing(GridView1.GetRowCellValue(i, "ItemAID")) Or IsDBNull(GridView1.GetRowCellValue(i, "ItemAID")), DBNull.Value, GridView1.GetRowCellValue(i, "ItemAID"))
                    ClsOpB._P6 = IIf(IsNothing(GridView1.GetRowCellValue(i, "Barcode")) Or IsDBNull(GridView1.GetRowCellValue(i, "Barcode")), DBNull.Value, GridView1.GetRowCellValue(i, "Barcode"))
                    ClsOpB._P7 = IIf(IsNothing(GridView1.GetRowCellValue(i, "ShDescription")) Or IsDBNull(GridView1.GetRowCellValue(i, "ShDescription")), DBNull.Value, GridView1.GetRowCellValue(i, "ShDescription"))
                    ClsOpB._P8 = CmbWhs.EditValue
                    ClsOpB._PosCode = Poscode
                    If FrmMainForm.UseSize = False Then
                        ClsOpB._P9 = DBNull.Value    'Size
                    Else
                        ClsOpB._P9 = IIf(IsNothing(GridView1.GetRowCellValue(i, "SizeCode")) Or IsDBNull(GridView1.GetRowCellValue(i, "SizeCode")), DBNull.Value, GridView1.GetRowCellValue(i, "SizeCode"))    'Size
                    End If
                    If FrmMainForm.UseColor = False Then
                        ClsOpB._P10 = DBNull.Value   'Color
                    Else
                        ClsOpB._P10 = IIf(IsNothing(GridView1.GetRowCellValue(i, "ColorCode")) Or IsDBNull(GridView1.GetRowCellValue(i, "ColorCode")), DBNull.Value, GridView1.GetRowCellValue(i, "ColorCode"))   'Color
                    End If
                    ClsOpB._P11 = IIf(IsNothing(GridView1.GetRowCellValue(i, "Description")) Or IsDBNull(GridView1.GetRowCellValue(i, "Description")), DBNull.Value, GridView1.GetRowCellValue(i, "Description"))
                    ClsOpB._P12 = DBNull.Value
                    ClsOpB._P13 = 0
                    ClsOpB._P14 = 0
                    ClsOpB._P15 = 0
                    ClsOpB._P16 = IIf(IsNothing(GridView1.GetRowCellValue(i, "Qty")) Or IsDBNull(GridView1.GetRowCellValue(i, "Qty")), DBNull.Value, GridView1.GetRowCellValue(i, "Qty"))
                    ClsOpB._P17 = 0
                    ClsOpB._P18 = 0
                    ClsOpB._P19 = 0
                    ClsOpB._P20 = IIf(IsNothing(GridView1.GetRowCellValue(i, "UOMCode")) Or IsDBNull(GridView1.GetRowCellValue(i, "UOMCode")), DBNull.Value, GridView1.GetRowCellValue(i, "UOMCode"))
                    ClsOpB._P21 = 1
                    ClsOpB._P22 = 1 'Sign Affect
                    ClsOpB._P23 = 0
                    ClsOpB._P24 = 0
                    ClsOpB._P25 = 0
                    ClsOpB._P26 = 0
                    ClsOpB._P27 = 0
                    ClsOpB._P28 = 0
                    ClsOpB._P29 = IIf(IsNothing(GridView1.GetRowCellValue(i, "Qty")) Or IsDBNull(GridView1.GetRowCellValue(i, "Qty")), DBNull.Value, GridView1.GetRowCellValue(i, "Qty"))
                    ClsOpB._P30 = 0
                    ClsOpB._P31 = 0
                    ClsOpB._P32 = 0
                    ClsOpB._P33 = 0
                    ClsOpB._P34 = 0
                    ClsOpB._P35 = DBNull.Value
                    ClsOpB._P36 = DBNull.Value
                    ClsOpB._P37 = DBNull.Value
                    ClsOpB._P38 = FrmLogin.user
                    ClsOpB._P39 = DateTime.Today
                    ClsOpB._P40 = 0
                    ClsOpB._P41 = DBNull.Value
                    ClsOpB._P42 = DBNull.Value
                    ClsOpB._P43 = LineID
                    ClsOpB._P44 = DBNull.Value
                    ClsOpB._P45 = DBNull.Value
                    ClsOpB.OperationDInsert(FrmLogin.objcon.con)
                    LineID += 1
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class