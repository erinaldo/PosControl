Imports System.Data.SqlClient
Imports System.IO
Imports ConnectionSQL
Public Class FrmBackup
    Implements Procedures
    Private Sub btnBackUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackUp.Click
        Try
            Dim blnconnectionOpen As Boolean = False
            Timer1.Enabled = True
            ProgressBarControl1.Visible = True
            If Directory.Exists(txtpath.Text) = False Then
                Directory.CreateDirectory(txtpath.Text)
            End If
            Dim query As String = "backup database " & FrmLogin.db & " to disk='" & txtpath.Text & FrmLogin.db & ".bak'"
            blnconnectionOpen = ConnStatus(FrmLogin.objcon.con)
            If Not blnconnectionOpen Then ConnOpen(FrmLogin.objcon.con)
            Dim sqlcomm As New SqlCommand(query, FrmLogin.objcon.con)
            sqlcomm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If ProgressBarControl1.EditValue = 100 Then
            Timer1.Enabled = False
            ProgressBarControl1.Visible = False
            MsgBox("Successfully Done")
            ProgressBarControl1.EditValue = 0
        Else
            ProgressBarControl1.EditValue = ProgressBarControl1.EditValue + 5
        End If
    End Sub

    Private Sub FrmBackup_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        MenuLockUnlock(False, False)
    End Sub
    Private Sub FrmBackup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Text = "BackUp <" & My.Application.Info.Version.ToString & ">"
            ProgressBarControl1.Visible = False
            txtPath.Text = "C:\DataBackUp\"
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
End Class