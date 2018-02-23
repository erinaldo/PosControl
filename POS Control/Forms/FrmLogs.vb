Imports DevExpress.XtraTreeList.Nodes
Imports System.IO
Imports DevExpress.XtraRichEdit

Public Class FrmLogs
    Implements Procedures

    Private Sub FrmLogs_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        MenuLockUnlock(False, False)
    End Sub
    Private Sub FrmLogs_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim Captions As String() = {"FullName", "Name", "Type"}
        Dim i As Integer
        For i = 0 To 2
            TreeList1.Columns.Add()
            TreeList1.Columns(i).Caption = Captions(i)
            TreeList1.Columns(i).VisibleIndex = IIf(i = 0, -1, i)
        Next
        InitFolders("C:\\BusinessPack\\POSControl\\Logs\\", Nothing)
        TreeList1.BestFitColumns()
    End Sub
    Private Sub InitFolders(ByVal Path As String, ByVal ParentNode As TreeListNode)
        TreeList1.BeginUnboundLoad()
        Dim Node As TreeListNode
        Dim DI As DirectoryInfo
        Try
            Dim Root As String() = Directory.GetDirectories(Path)
            Dim S As String
            For Each S In Root
                DI = New DirectoryInfo(S)
                Dim Values As Object() = {S, DI.Name, "Folder"}
                Node = TreeList1.AppendNode(Values, ParentNode)
                Node.HasChildren = True
            Next
        Catch
        End Try
        InitFiles(Path, ParentNode)
        TreeList1.EndUnboundLoad()
    End Sub

    Private Sub InitFiles(ByVal Path As String, ByVal ParentNode As TreeListNode)
        Dim Node As TreeListNode
        Dim FI As FileInfo
        Try
            Dim Root As String() = Directory.GetFiles(Path)
            Dim S As String
            For Each S In Root
                FI = New FileInfo(S)
                Dim Values As Object() = {S, FI.Name, "File"}
                Node = TreeList1.AppendNode(Values, ParentNode)
                Node.HasChildren = False
            Next
        Catch
        End Try
    End Sub

    Private Sub TreeList1_BeforeExpand(sender As System.Object, e As DevExpress.XtraTreeList.BeforeExpandEventArgs) Handles TreeList1.BeforeExpand
        InitFolders(e.Node.GetDisplayText(0), e.Node)
    End Sub

    Private Sub TreeList1_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles TreeList1.MouseDown
        Dim hi As DevExpress.XtraTreeList.TreeListHitInfo = TreeList1.CalcHitInfo(e.Location)
        If hi.HitInfoType = DevExpress.XtraTreeList.HitInfoType.Cell Then
            If hi.Node.Item("Type") = "File" Then
                RichEditControl1.LoadDocument(hi.Node("FullName").ToString(), DocumentFormat.PlainText)
            End If
        End If
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

    Public Sub MenuLockUnlock(Adding As Boolean, Editing As Boolean) Implements Procedures.MenuLockUnlock
        Try
            If Adding = True Or Editing = True Then
                FrmMainForm.btnFirst.Enabled = False
                FrmMainForm.btnnext.Enabled = False
                FrmMainForm.btnLast.Enabled = False
                FrmMainForm.btnprevious.Enabled = False
                FrmMainForm.NewToolStrip.Enabled = False
                FrmMainForm.EditToolStrip.Enabled = False
                FrmMainForm.SaveToolStrip.Enabled = True
                FrmMainForm.UndoToolStrip.Enabled = True
                FrmMainForm.FindToolstrip.Enabled = False
                FrmMainForm.DeleteToolStrip.Enabled = False
                FrmMainForm.SearchToolStrip.Enabled = False
                FrmMainForm.RefreshToolStrip.Enabled = False
                FrmMainForm.PrintToolStrip.Enabled = False
                FrmMainForm.CloseToolStrip.Enabled = False
            Else
                FrmMainForm.btnFirst.Enabled = True
                FrmMainForm.btnnext.Enabled = True
                FrmMainForm.btnLast.Enabled = True
                FrmMainForm.btnprevious.Enabled = True
                FrmMainForm.NewToolStrip.Enabled = True
                FrmMainForm.EditToolStrip.Enabled = True
                FrmMainForm.SaveToolStrip.Enabled = False
                FrmMainForm.UndoToolStrip.Enabled = False
                FrmMainForm.FindToolstrip.Enabled = True
                FrmMainForm.DeleteToolStrip.Enabled = True
                FrmMainForm.SearchToolStrip.Enabled = True
                FrmMainForm.RefreshToolStrip.Enabled = True
                FrmMainForm.PrintToolStrip.Enabled = True
                FrmMainForm.CloseToolStrip.Enabled = True
                ' GetPriv()
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
End Class