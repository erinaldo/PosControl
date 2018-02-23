Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Columns

Public Class FrmBrowse
    Public Shared dt As New DataTable
    Dim Array() As Object
    Public Shared i As Integer
    Private Sub BtnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExcel.Click
        Try
            Dim sd As New SaveFileDialog 'declare save file dialog
            sd.InitialDirectory = "D:\"
            sd.Title = "Save Your File"
            sd.Filter = "Microsoft Excel(*.xlsx)|*.xlsx"
            sd.OverwritePrompt = True
            If sd.ShowDialog = Windows.Forms.DialogResult.OK Then 'check if save file dialog was close after selecting a path
                GridView1.ExportToXlsx(sd.FileName)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub BtnPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPDF.Click
        Try
            Dim sd As New SaveFileDialog 'declare save file dialog
            sd.InitialDirectory = "D:\"
            sd.Title = "Save Your File"
            sd.Filter = "PDF Document(*.pdf)|*.pdf"
            sd.OverwritePrompt = True
            If sd.ShowDialog = Windows.Forms.DialogResult.OK Then 'check if save file dialog was close after selecting a path
                GridView1.ExportToPdf(sd.FileName)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub BtnText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnText.Click
        Try
            Dim sd As New SaveFileDialog 'declare save file dialog
            sd.InitialDirectory = "D:\"
            sd.Title = "Save Your File"
            sd.Filter = "Text Document(*.txt)|*.txt"
            sd.OverwritePrompt = True
            If sd.ShowDialog = Windows.Forms.DialogResult.OK Then 'check if save file dialog was close after selecting a path
                GridView1.ExportToText(sd.FileName)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub FrmBrowse_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            GridView1.Columns.Clear()
            GridView1.FindFilterText = String.Empty
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub GridView1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridView1.KeyDown
        If GridView1.RowCount = 0 Then
            Exit Sub
        End If
        If e.KeyCode = Keys.Enter Then
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = GridControl1.FocusedView
            Dim row As DataRowView = view.GetRow(view.FocusedRowHandle)
            dt.Clear()
            dt.Columns.Clear()
            Array = New Object(GridView1.Columns.Count - 1) {}
            Dim i = 0
            For Each column As GridColumn In GridView1.Columns
                dt.Columns.Add(column.FieldName)
                Array(i) = row.Item(column.FieldName)
                i += 1
            Next
            dt.Rows.Add(Array)
            i = GridView1.GetDataSourceRowIndex(view.FocusedRowHandle)
            Me.Close()
        End If
    End Sub

    Private Sub FrmBrowse_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            dt.Clear()
            dt.Columns.Clear()
            dt.Rows.Clear()
            Me.Close()
        End If
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        dt.Clear()
        dt.Columns.Clear()
        dt.Rows.Clear()
        Me.Close()
    End Sub
    Private Sub GridView1_DoubleClick(sender As System.Object, e As System.EventArgs) Handles GridView1.DoubleClick
        Try
            If GridView1.RowCount = 0 Then
                Exit Sub
            End If
            Dim view As GridView = CType(sender, GridView)
            Dim pt As Point = view.GridControl.PointToClient(Control.MousePosition)
            DoRowDoubleClick(view, pt)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub DoRowDoubleClick(ByVal view As GridView, ByVal pt As Point)
        Dim info As GridHitInfo = view.CalcHitInfo(pt)
        If info.InRow OrElse info.InRowCell Then
            Dim colCaption As String
            If info.Column Is Nothing Then
                colCaption = "N/A"
            Else
                colCaption = info.Column.GetCaption()
            End If
        End If
        Dim row As DataRowView = view.GetRow(info.RowHandle)
        dt.Clear()
        dt.Columns.Clear()
        Array = New Object(GridView1.Columns.Count - 1) {}
        Dim i = 0
        For Each column As GridColumn In GridView1.Columns
            dt.Columns.Add(column.FieldName)
            Array(i) = row.Item(column.FieldName)
            i += 1
        Next
        dt.Rows.Add(Array)
        i = GridView1.GetDataSourceRowIndex(view.FocusedRowHandle)
        Me.Close()
    End Sub

    Private Sub FrmBrowse_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class