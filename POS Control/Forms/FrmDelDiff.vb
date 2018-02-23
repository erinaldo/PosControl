Imports System.Data.SqlClient
Imports DevExpress.XtraGrid.Views.Base

Public Class FrmDelDiff
    Implements Procedures
    Dim add As Boolean = False
    Dim edit As Boolean = False
    Dim ClsDelDiff As New ClsDelDiff

    Public Sub InitGrid()
        Try
            Dim View As ColumnView = GridControl1.MainView
            View.Columns(0).FieldName = "LineID"
            View.Columns(1).FieldName = "OperID"
            View.Columns(1).VisibleIndex = 0
            View.Columns(2).FieldName = "WhsCode"
            View.Columns(2).VisibleIndex = 1
            View.Columns(3).FieldName = "PosCode"
            View.Columns(3).VisibleIndex = 2
            View.Columns(4).FieldName = "Description"
            View.Columns(4).VisibleIndex = 3
            View.Columns(5).FieldName = "Barcode"
            View.Columns(5).VisibleIndex = 4
            View.Columns(6).FieldName = "color"
            View.Columns(6).VisibleIndex = 5
            View.Columns(7).FieldName = "Size"
            View.Columns(7).VisibleIndex = 6
            View.Columns(8).FieldName = "Qty"
            View.Columns(8).VisibleIndex = 7
            View.Columns(9).FieldName = "QtyAffected"
            View.Columns(9).VisibleIndex = 8
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub FrmDelDiff_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            InitGrid()
            ViewMode()
            LockUnlockMe()
            GridControl1.DataSource = ClsDelDiff.FillDelDiff(FrmLogin.objcon.con)
            GridView1.BestFitColumns(True)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub ViewMode()
        add = False
        edit = False
        Me.Text = "Delivery Discrepancy <" & My.Application.Info.Version.ToString & "> View Mode"
    End Sub
    Public Function cancel() As Object Implements Procedures.cancel
        Return False
    End Function

    Public Sub close1() Implements Procedures.close
        Me.Close()
    End Sub

    Public Sub DeleteRecord() Implements Procedures.DeleteRecord
        Exit Sub
    End Sub

    Public Function EditRecord() As Object Implements Procedures.EditRecord
        Return False
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
        Exit Sub
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
                ' getpriv()
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
        Return True
    End Function

    Public Sub Search() Implements Procedures.Search
        Exit Sub
    End Sub

    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs)
        'Try
        '    If lblLineID.Text = "" Then
        '        Exit Sub
        '    Else
        '        If MessageBox.Show("Clear this dispcrepancy?", "Delivery Descrepancy", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
        '            Dim Sql As String = " update rtDelDiff set cleared = 1 where LineID = " & lblLineID.Text
        '            Dim sqlcom As New SqlCommand(Sql, FrmLogin.objcon.con)
        '            sqlcom.ExecuteNonQuery()
        '            ClsDelDiff.GetDelDiff(FrmLogin.objcon.con)
        '            lastRecord()
        '        End If
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Private Sub BtnClear_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles BtnClear.ButtonClick
        Try
            Try
                Dim view As DevExpress.XtraGrid.Views.Grid.GridView = GridControl1.FocusedView
                Dim row As DataRowView = view.GetRow(view.FocusedRowHandle)
                If IsDBNull(row.Item("LineID")) Or IsNothing(row.Item("LineID")) Then
                    Exit Sub
                End If
                If MessageBox.Show("Clear this line?", "Clear", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    GridView1.DeleteRow(GridView1.FocusedRowHandle)
                    Dim Sql As String = " update rtDelDiff set cleared = 1 where LineID = " & row.Item("LineID")
                    Dim sqlcom As New SqlCommand(Sql, FrmLogin.objcon.con)
                    sqlcom.ExecuteNonQuery()
                End If
                If GridView1.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
                    GridView1.CloseEditor()
                    GridView1.UpdateCurrentRow()
                End If
                GridView1.BestFitColumns(True)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class