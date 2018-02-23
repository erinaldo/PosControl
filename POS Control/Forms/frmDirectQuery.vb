Imports System.IO
Imports System.Data.SqlClient
Public Class frmDirectQuery
    Implements Procedures
    Dim ds As New DataSet
    Dim da As New SqlDataAdapter
    Dim sqlText As String = Nothing
    Private Sub btnopen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnopen.Click
        Try
            Dim filedalog As New OpenFileDialog
            filedalog.InitialDirectory = "D:\"
            filedalog.Filter = "SQL Files(*.sql,*.txt)|*.sql;*.txt "
            If filedalog.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim sqlFile As String = filedalog.FileName.ToString
                sqlText = File.ReadAllText(sqlFile)
                txtSQL.Text = sqlText.ToString
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub frmDirectQuery_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        MenuLockUnlock(False, False)
    End Sub

    Private Sub frmDirectQuery_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Text = "Direct Query <" & My.Application.Info.Version.ToString & ">"
            GridView1.OptionsBehavior.Editable = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Try
            txtSQL.ResetText()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnGet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGet.Click
        Try
            If txtSQL.Text = "" Or String.IsNullOrEmpty(txtSQL.Text) Or String.IsNullOrWhiteSpace(txtSQL.Text) Then
                Exit Sub
            End If
            Dim sqlCmd = New SqlCommand(txtSQL.Text, FrmLogin.objcon.con)
            Try
                ds = New DataSet
                GridControl1.DataSource = Nothing
                GridView1.Columns.Clear()
                da = New SqlDataAdapter(sqlCmd)
                ds.Clear()
                da.Fill(ds)
                GridControl1.DataSource = ds.Tables(0)
            Catch ex As Exception
                MsgBox("Something went wrong: " & ex.Message)
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPDF.Click
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
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnexcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexcel.Click
        Try
            Dim sd As New SaveFileDialog 'declare save file dialog
            sd.InitialDirectory = "D:\"
            sd.Title = "Save Your File"
            sd.Filter = "Excel Document(*.xlsx)|*.xlsx"
            sd.OverwritePrompt = True

            If sd.ShowDialog = Windows.Forms.DialogResult.OK Then 'check if save file dialog was close after selecting a path
                GridView1.ExportToXlsx(sd.FileName)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btntext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btntext.Click
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
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnHTML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHTML.Click
        Try
            Dim sd As New SaveFileDialog 'declare save file dialog
            sd.InitialDirectory = "D:\"
            sd.Title = "Save Your File"
            sd.Filter = "HTML Document(*.html)|*.html"
            sd.OverwritePrompt = True

            If sd.ShowDialog = Windows.Forms.DialogResult.OK Then 'check if save file dialog was close after selecting a path
                GridView1.ExportToHtml(sd.FileName)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnPrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPreview.Click
        Try
            GridView1.ShowPrintPreview()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Function cancel() As Object Implements Procedures.cancel

    End Function

    Public Sub close1() Implements Procedures.close
        Me.Close()
    End Sub

    Public Sub DeleteRecord() Implements Procedures.DeleteRecord

    End Sub

    Public Function EditRecord() As Object Implements Procedures.EditRecord

    End Function

    Public Sub FillDefault() Implements Procedures.FillDefault

    End Sub

    Public Sub find() Implements Procedures.find

    End Sub

    Public Sub FirstRecord() Implements Procedures.FirstRecord

    End Sub

    Public Sub lastRecord() Implements Procedures.lastRecord

    End Sub

    Public Sub LockUnlockMe() Implements Procedures.LockUnlockMe

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

    End Function

    Public Sub nextRecord() Implements Procedures.nextRecord

    End Sub

    Public Sub PreviousRecord() Implements Procedures.PreviousRecord

    End Sub

    Public Sub print() Implements Procedures.print

    End Sub

    Public Sub Refresh1() Implements Procedures.Refresh

    End Sub

    Public Function Save() As Object Implements Procedures.Save

    End Function

    Public Sub Search() Implements Procedures.Search

    End Sub
End Class