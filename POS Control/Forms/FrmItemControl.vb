Imports System.Data.SqlClient
Imports ConnectionSQL
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.Utils

Public Class FrmItemControl
    Implements Procedures
    Dim BoConxString = "Data Source ='" & FrmMainForm.BOServer & "';Initial Catalog='" & FrmMainForm.BODatabase & "';user ID='" & FrmMainForm.BOUser & "';password='" & FrmMainForm.BOPass & "'"
    Dim BoCnx As SqlConnection = New SqlConnection(BoConxString)
    Dim da As New SqlDataAdapter
    Dim add As Boolean = False
    Dim edit As Boolean = False
    Dim BarcodeArray As New ArrayList

    Public Sub CreateEmptyDataTable()
        Dim dt As New DataTable()
        dt.Columns.Add("Barcode", GetType(String))
        dt.Columns.Add("Description", GetType(String))
        dt.Columns.Add("ColorCode", GetType(String))
        dt.Columns.Add("SizeCode", GetType(String))
        dt.Columns.Add("MinQty", GetType(Integer))
        dt.Columns.Add("MaxQty", GetType(Integer))
        dt.Columns.Add("Blocked", GetType(Boolean))
        GridControl1.DataSource = dt
    End Sub
    Public Sub InitGrid()
        Try
            Dim View As ColumnView = GridControl1.MainView
            View.Columns(0).FieldName = "Barcode"
            View.Columns(0).VisibleIndex = 0
            View.Columns(1).FieldName = "Description"
            View.Columns(1).VisibleIndex = 1
            View.Columns(2).FieldName = "ColorCode"
            View.Columns(2).VisibleIndex = 2
            View.Columns(3).FieldName = "SizeCode"
            View.Columns(3).VisibleIndex = 3
            View.Columns(4).FieldName = "MinQty"
            View.Columns(4).VisibleIndex = 4
            View.Columns(5).FieldName = "MaxQty"
            View.Columns(5).VisibleIndex = 5
            View.Columns(6).FieldName = "Blocked"
            View.Columns(6).VisibleIndex = 6
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FrmItemControl_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
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
            GridView1.OptionsSelection.MultiSelect = True
            GridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect
            GridView1.OptionsView.ShowButtonMode = ShowButtonModeEnum.ShowAlways
            Dim TempMultiSelectionEditingHelper As MultiSelectionEditingHelper = New MultiSelectionEditingHelper(GridView1)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub ViewMode()
        add = False
        edit = False
        Me.Text = "Items Qty Control <" & My.Application.Info.Version.ToString & "> View Mode"
    End Sub
    Public Function FillFamily() As DataTable
        Try
            Dim sqlcomm As New SqlCommand("SpIv_CategoryMain", BoCnx)
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@Cmp", 1)
            sqlcomm.Parameters.AddWithValue("@Code", "")
            sqlcomm.Parameters.AddWithValue("@filter", "")
            sqlcomm.Parameters.AddWithValue("@and", "")
            sqlcomm.Parameters.AddWithValue("@status", 3)
            sqlcomm.Parameters.AddWithValue("@ext", "")
            Dim blnconnectionOpen = ConnStatus(BoCnx)
            If Not blnconnectionOpen Then ConnOpen(BoCnx)
            Dim dt As New DataTable
            da = New SqlDataAdapter(sqlcomm)
            da.Fill(dt)
            Return dt
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
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
        Me.Text = "Items Qty Control <" & My.Application.Info.Version.ToString & "> Edit Mode"
        If BarcodeArray.Count > 0 Then
            BarcodeArray.Clear()
        End If
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
        GridView1.CloseEditor()
        If add = False And edit = True Then
            For i As Integer = 0 To GridView1.DataRowCount - 1
                Dim ClsItemcontrol As New ClsItemControl
                If (Not IsDBNull(GridView1.GetRowCellValue(i, "Barcode")) And Not IsNothing(GridView1.GetRowCellValue(i, "Barcode"))) Then
                    For j = 0 To BarcodeArray.Count - 1
                        If BarcodeArray(j) = GridView1.GetRowCellValue(i, "Barcode") Then
                            ClsItemcontrol._Barcode = IIf(IsDBNull(GridView1.GetRowCellValue(i, "Barcode")) Or IsNothing(GridView1.GetRowCellValue(i, "Barcode")), DBNull.Value, GridView1.GetRowCellValue(i, "Barcode"))
                            ClsItemcontrol._WhsCode = CmbWhs.EditValue
                            ClsItemcontrol._Blocked = IIf(IsDBNull(GridView1.GetRowCellValue(i, "Blocked")) Or IsNothing(GridView1.GetRowCellValue(i, "Blocked")), False, GridView1.GetRowCellValue(i, "Blocked"))
                            ClsItemcontrol._MinQty = IIf(IsDBNull(GridView1.GetRowCellValue(i, "MinQty")) Or IsNothing(GridView1.GetRowCellValue(i, "MinQty")), 0, GridView1.GetRowCellValue(i, "MinQty"))
                            ClsItemcontrol._MaxQty = IIf(IsDBNull(GridView1.GetRowCellValue(i, "MaxQty")) Or IsNothing(GridView1.GetRowCellValue(i, "MaxQty")), 0, GridView1.GetRowCellValue(i, "MaxQty"))
                            ClsItemcontrol.UpdateItemContol(BoCnx)
                        End If
                    Next
                End If
            Next
            ViewMode()
            GridControl1.DataSource = Nothing
            InitGrid()
            CreateEmptyDataTable()
            Return True
        End If
    End Function
    Public Sub Search() Implements Procedures.Search
        Exit Sub
    End Sub

    Private Sub txtdesc_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtdesc.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If IsNothing(CmbWhs.EditValue) Or IsDBNull(CmbWhs.EditValue) Then
                    MessageBox.Show("Whs is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If
            FrmBrowse.GridView1.OptionsView.ColumnAutoWidth = True
            If txtdesc.Text = " " And e.KeyCode = Keys.Enter Then
                FrmBrowse.GridControl1.DataSource = Browse.GetItemsControl(txtdesc.Text, CmbWhs.EditValue, BoCnx)
                FrmBrowse.Text = "Items"
                FrmBrowse.GridView1.Columns("ItemAid").Visible = False
                FrmBrowse.GridControl1.Refresh()
                FrmBrowse.ShowInTaskbar = False
                FrmBrowse.ShowDialog()
                If FrmBrowse.dt.Rows.Count = 0 Then Exit Sub
                Dim dt As New DataTable
                Dim ClsItemControl As New ClsItemControl
                dt = ClsItemControl.GetItemControl(CmbWhs.EditValue, CInt(FrmBrowse.dt.Rows(0).Item("ItemAid")), BoCnx)
                RemoveHandler GridView1.CellValueChanged, AddressOf GridView1_CellValueChanged
                For i = 0 To dt.Rows.Count - 1
                    GridView1.AddNewRow()
                    Dim rowHandle As Integer = GridView1.GetRowHandle(GridView1.DataRowCount)
                    GridView1.SetRowCellValue(rowHandle, "SizeCode", dt.Rows(i).Item("SizeCode").ToString)
                    GridView1.SetRowCellValue(rowHandle, "ColorCode", dt.Rows(i).Item("ColorCode").ToString)
                    GridView1.SetRowCellValue(rowHandle, "Description", dt.Rows(i).Item("Description").ToString)
                    GridView1.SetRowCellValue(rowHandle, "MinQty", dt.Rows(i).Item("MinQty"))
                    GridView1.SetRowCellValue(rowHandle, "MaxQty", dt.Rows(i).Item("MaxQty"))
                    GridView1.SetRowCellValue(rowHandle, "Barcode", dt.Rows(i).Item("Barcode"))
                    GridView1.SetRowCellValue(rowHandle, "Blocked", IIf(IsDBNull(dt.Rows(i).Item("Blocked")) Or IsNothing(dt.Rows(i).Item("Blocked")), False, dt.Rows(i).Item("Blocked")))
                Next
                AddHandler GridView1.CellValueChanged, AddressOf GridView1_CellValueChanged
                txtdesc.Text = ""
            Else
                FrmBrowse.Text = "Items"
                If e.KeyCode = Keys.Enter Then
                    Dim dt As New DataTable
                    dt = Browse.GetItemsControl(txtdesc.Text, CmbWhs.EditValue, BoCnx)
                    FrmBrowse.GridControl1.DataSource = dt
                    If FrmBrowse.GridView1.DataRowCount - 1 = 0 Then
                        Dim dt1 As New DataTable
                        Dim ClsItemControl As New ClsItemControl
                        dt1 = ClsItemControl.GetItemControl(CmbWhs.EditValue, CInt(dt.Rows(0).Item("ItemAid")), BoCnx)
                        RemoveHandler GridView1.CellValueChanged, AddressOf GridView1_CellValueChanged
                        For i = 0 To dt1.Rows.Count - 1
                            GridView1.AddNewRow()
                            Dim rowHandle As Integer = GridView1.GetRowHandle(GridView1.DataRowCount)
                            GridView1.SetRowCellValue(rowHandle, "SizeCode", dt1.Rows(i).Item("SizeCode").ToString)
                            GridView1.SetRowCellValue(rowHandle, "ColorCode", dt1.Rows(i).Item("ColorCode").ToString)
                            GridView1.SetRowCellValue(rowHandle, "Description", dt1.Rows(i).Item("Description").ToString)
                            GridView1.SetRowCellValue(rowHandle, "MinQty", dt1.Rows(i).Item("MinQty"))
                            GridView1.SetRowCellValue(rowHandle, "MaxQty", dt1.Rows(i).Item("MaxQty"))
                            GridView1.SetRowCellValue(rowHandle, "Barcode", dt1.Rows(i).Item("Barcode"))
                            GridView1.SetRowCellValue(rowHandle, "Blocked", dt1.Rows(i).Item("Blocked"))
                        Next
                        AddHandler GridView1.CellValueChanged, AddressOf GridView1_CellValueChanged
                        txtdesc.Text = ""
                    Else
                        FrmBrowse.GridControl1.Refresh()
                        FrmBrowse.Text = "Items"
                        FrmBrowse.GridView1.Columns("ItemAid").Visible = False
                        FrmBrowse.ShowInTaskbar = False
                        FrmBrowse.ShowDialog()
                        If FrmBrowse.dt.Rows.Count = 0 Then Exit Sub
                        Dim dt1 As New DataTable
                        Dim ClsItemControl As New ClsItemControl
                        dt1 = ClsItemControl.GetItemControl(CmbWhs.EditValue, CInt(FrmBrowse.dt.Rows(0).Item("ItemAid")), BoCnx)
                        RemoveHandler GridView1.CellValueChanged, AddressOf GridView1_CellValueChanged
                        For i = 0 To dt1.Rows.Count - 1
                            GridView1.AddNewRow()
                            Dim rowHandle As Integer = GridView1.GetRowHandle(GridView1.DataRowCount)
                            GridView1.SetRowCellValue(rowHandle, "SizeCode", dt1.Rows(i).Item("SizeCode").ToString)
                            GridView1.SetRowCellValue(rowHandle, "ColorCode", dt1.Rows(i).Item("ColorCode").ToString)
                            GridView1.SetRowCellValue(rowHandle, "Description", dt1.Rows(i).Item("Description").ToString)
                            GridView1.SetRowCellValue(rowHandle, "MinQty", dt1.Rows(i).Item("MinQty"))
                            GridView1.SetRowCellValue(rowHandle, "MaxQty", dt1.Rows(i).Item("MaxQty"))
                            GridView1.SetRowCellValue(rowHandle, "Barcode", dt1.Rows(i).Item("Barcode"))
                            GridView1.SetRowCellValue(rowHandle, "Blocked", dt1.Rows(i).Item("Blocked"))
                        Next
                        AddHandler GridView1.CellValueChanged, AddressOf GridView1_CellValueChanged
                        txtdesc.Text = ""
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Try
            BarcodeArray.Add(GridView1.GetRowCellValue(e.RowHandle, "Barcode"))
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Class MultiSelectionEditingHelper

        Private _View As GridView
        Public Sub New(ByVal view As GridView)
            _View = view
            _View.OptionsBehavior.EditorShowMode = EditorShowMode.MouseDownFocused
            AddHandler _View.MouseUp, AddressOf _View_MouseUp
            AddHandler _View.CellValueChanged, AddressOf _View_CellValueChanged
            AddHandler _View.MouseDown, AddressOf _View_MouseDown
        End Sub

        Private Sub _View_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
            If GetInSelectedCell(e) Then
                Dim hi As GridHitInfo = _View.CalcHitInfo(e.Location)
                If _View.FocusedRowHandle = hi.RowHandle Then
                    _View.FocusedColumn = hi.Column
                    DXMouseEventArgs.GetMouseArgs(e).Handled = True
                End If
            End If

        End Sub

        Private Sub _View_CellValueChanged(ByVal sender As Object, ByVal e As CellValueChangedEventArgs)
            OnCellValueChanged(e)
        End Sub

        Private lockEvents As Boolean
        Private Sub OnCellValueChanged(ByVal e As CellValueChangedEventArgs)
            If lockEvents Then
                Return
            End If
            lockEvents = True
            SetSelectedCellsValues(e.Value)
            lockEvents = False
        End Sub

        Private Sub SetSelectedCellsValues(ByVal value As Object)
            Try
                _View.BeginUpdate()
                Dim cells() As GridCell = _View.GetSelectedCells()
                For Each cell As GridCell In cells
                    If cell.Column.FieldName = "MaxQty" Or cell.Column.FieldName = "MinQty" Then
                        _View.SetRowCellValue(cell.RowHandle, cell.Column, value)
                    End If
                Next cell
            Catch ex As Exception

            Finally
                _View.EndUpdate()
            End Try

        End Sub
        Private Function GetInSelectedCell(ByVal e As MouseEventArgs) As Boolean
            Dim hi As GridHitInfo = _View.CalcHitInfo(e.Location)
            Return hi.InRowCell AndAlso hi.InRowCell AndAlso _View.IsCellSelected(hi.RowHandle, hi.Column)
        End Function

        Private Sub _View_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
            Dim inSelectedCell As Boolean = GetInSelectedCell(e)
            If inSelectedCell Then
                DXMouseEventArgs.GetMouseArgs(e).Handled = True
                _View.ShowEditorByMouse()
            End If
        End Sub
    End Class
End Class