Imports System.Data.SqlClient
Imports System.IO
Imports DevExpress.XtraEditors

Public Class FrmBuild
    Implements Procedures
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet
    Private Sub btnGetValues_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetValues.Click
        Try
            Dim m_TableInfo As New DataTable
            Dim query As String = Nothing
            Dim fetch As String() = Nothing
            Dim tablename As String = Nothing
            If CBQuery.Checked = True Then
                query = txtquery.Text
            Else
                query = "Select * from " & txtquery.Text
            End If
            If CBQuery.Checked = True Then
                Dim sqlstatement As String = Mid(txtquery.Text, txtquery.Text.LastIndexOf("from") + 5)
                If sqlstatement.Contains(" ") Then
                    fetch = sqlstatement.Split(" ")
                    tablename = fetch(1)
                Else
                    tablename = sqlstatement
                End If
            Else
                tablename = txtquery.Text
            End If
            da = New SqlDataAdapter(query, FrmLogin.objcon.con)
            ds = New DataSet
            da.Fill(ds, "Build")
            m_TableInfo = ds.Tables("Build")
            'clear the string member
            Dim m_sSqlStatementText As String = String.Empty
            'create an array of all the columns that are to be included
            Dim aryColumns As New ArrayList
            For Each col As DataColumn In m_TableInfo.Columns
                aryColumns.Add(col.ColumnName)
            Next
            Dim sTargetTableName As String = tablename
            m_sSqlStatementText = Generator.SqlScriptGenerator.GenerateSqlInserts(aryColumns, m_TableInfo, sTargetTableName)
            Dim fileName As String = txtPath.Text
            Dim outputStream As StreamWriter = New StreamWriter(fileName)
            outputStream.Write(m_sSqlStatementText)
            outputStream.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmBuild_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        MenuLockUnlock(False, False)
    End Sub
    Private Sub FrmBuild_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub FrmBuild_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Text = "Build <" & My.Application.Info.Version.ToString & ">"
            txtPath.Text = "C:\BusinessPack\values.txt"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Function cancel() As Object Implements Procedures.cancel
        Return True
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
        Return False
    End Function

    Public Sub Search() Implements Procedures.Search
        Exit Sub
    End Sub

    Private Sub txtquery_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtquery.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPath.Focus()
        End If
    End Sub
End Class