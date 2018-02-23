Imports DevExpress.XtraGrid.Views.Base
Imports System.Data.SqlClient
Imports ConnectionSQL
Public Class FrmReceipts
    Implements Procedures
    Dim da As New SqlDataAdapter
    Dim dt As New DataTable
    Dim Server As String = ""
    Dim ServerCnx As SqlConnection
    Private Sub FrmReceipts_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        MenuLockUnlock(False, False)
    End Sub
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

    Private Sub FrmReceipts_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            GetServer()
            Me.Text = "Receipts <" & My.Application.Info.Version.ToString & ">"
            If Server = "" Then
                MessageBox.Show("Set the datasource location", "BusinessPack", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            ServerCnx = New SqlConnection(Server)
            InitRGrid()
            FillMOP()
            FillSalesMan()
            DtpCriteriaFrom.EditValue = Date.Today
            DtpCriteriaTill.EditValue = Date.Today
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub GetServer()
        Try
            Dim SqlCom As New SqlCommand("Select ImagePath from Sacparameter", FrmLogin.objcon.con)
            Dim blnconnectionOpen As Boolean
            blnconnectionOpen = ConnStatus(FrmLogin.objcon.con)
            If Not blnconnectionOpen Then ConnOpen(FrmLogin.objcon.con)
            Server = SqlCom.ExecuteScalar
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub FillSalesMan()
        Try
            Dim dt As New DataTable
            Dim SqlComm As New SqlCommand("select UserName from SacUsers where Thirdid is not null", ServerCnx)
            Dim blnconnectionOpen As Boolean
            blnconnectionOpen = ConnStatus(ServerCnx)
            If Not blnconnectionOpen Then ConnOpen(ServerCnx)
            da = New SqlDataAdapter(SqlComm)
            dt.Clear()
            da.Fill(dt)
            CmbSalesman.Properties.ValueMember = "UserName"
            CmbSalesman.Properties.DisplayMember = "UserName"
            CmbSalesman.Properties.DataSource = dt
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub GetRecA()
        Try
            Dim SqlSelect = " select Aa.TransID,Ab.Amount,Ab.CurCode,Ab.CheckNbr,Ab.CheckBank,Ab.CheckMaturity,Ab.Description,Aa.ManualRef,Ab.CheckNote, Ab.OrderOf "
            SqlSelect = SqlSelect & ", (select ae.ThirdID from AcJournalE1Es ae where ae.TransID = Aa.TransID and Aa.PosCode = Ae.PosCode and Thirdid is not null ) as 'ThirdID'"
            SqlSelect = SqlSelect & " from AcJournalD1Es Aa join AcJournalE1Es Ab On Aa.TransID = Ab.TransID and Aa.PosCode = Ab.PosCode "
            SqlSelect = SqlSelect & " where Aa.PosCode='" & FrmMainForm.TabletPos & "'"
            SqlSelect = SqlSelect & " And Aa.Status = 0 and Aa.iUser='" & CmbSalesman.EditValue & "'"
            SqlSelect = SqlSelect & " and Aa.TransDate>='" & DtpCriteriaFrom.DateTime.Date.ToString("yyyyMMdd") & "'"
            SqlSelect = SqlSelect & " and Aa.TransDate<='" & DtpCriteriaTill.DateTime.Date.ToString("yyyyMMdd") & "' And AB.ThirdId is null"
            Dim SqlCom As New SqlCommand(SqlSelect, FrmLogin.objcon.con)
            If FrmLogin.objcon.con.State = ConnectionState.Closed Then
                FrmLogin.objcon.con.Open()
            End If
            da = New SqlDataAdapter(SqlCom)
            da.Fill(dt)
            GridControl1.DataSource = dt
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub InitRGrid()
        Try
            Dim View As ColumnView = GridControl1.MainView
            View.Columns(0).FieldName = "TransID"
            View.Columns(0).VisibleIndex = 0
            View.Columns(1).FieldName = "ThirdID"
            View.Columns(1).VisibleIndex = 1
            View.Columns(2).FieldName = "OrderOf"
            View.Columns(2).VisibleIndex = 2
            View.Columns(3).FieldName = "Amount"
            View.Columns(3).VisibleIndex = 3
            View.Columns(4).FieldName = "CurCode"
            View.Columns(4).VisibleIndex = 4
            View.Columns(5).FieldName = "CheckNbr"
            View.Columns(5).VisibleIndex = 5
            View.Columns(6).FieldName = "CheckBank"
            View.Columns(6).VisibleIndex = 6
            View.Columns(7).FieldName = "CheckMaturity"
            View.Columns(7).VisibleIndex = 7
            View.Columns(8).FieldName = "CheckNote"
            View.Columns(8).VisibleIndex = 8
            View.Columns(9).FieldName = "Description"
            View.Columns(9).VisibleIndex = 9
            View.Columns(10).FieldName = "ManualRef"
            View.Columns(10).VisibleIndex = 10
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        Try

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub lastRecord() Implements Procedures.lastRecord
        Try

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub LockUnlockMe() Implements Procedures.LockUnlockMe

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

    End Function

    Public Sub nextRecord() Implements Procedures.nextRecord
        Try

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub PreviousRecord() Implements Procedures.PreviousRecord
        Try
            
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub print() Implements Procedures.print

    End Sub

    Public Sub Refresh1() Implements Procedures.Refresh

    End Sub

    Public Function Save() As Object Implements Procedures.Save

    End Function

    Public Sub Search() Implements Procedures.Search

    End Sub

    Private Sub btnGet_Click(sender As System.Object, e As System.EventArgs) Handles btnGet.Click
        Try
            GridView1.SelectAll()
            GridView1.DeleteSelectedRows()
            GridControl1.DataSource = Nothing
            GetRecA()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSubmit_Click(sender As System.Object, e As System.EventArgs) Handles btnSubmit.Click
        Try
            If GridView1.SelectedRowsCount = 0 Then
                MessageBox.Show("Please select the rows you want to submit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            'Dim SqlCom As New SqlCommand("Select * from RsMop where Code ='" & FrmMainForm.PostDatedCode & "'", FrmLogin.objcon.con)
            'If FrmLogin.objcon.con.State = ConnectionState.Closed Then
            '    FrmLogin.objcon.con.Open()
            'End If
            'Dim dt As New DataTable
            'Dim da As New SqlDataAdapter(SqlCom)
            'da.Fill(dt)
            'Dim AccCode = dt.Rows(0).Item("Acccode").ToString
            'Dim AuxbCode = dt.Rows(0).Item("AuxbCode").ToString


            Dim CurrD As DateTime
            Dim SqlQuery = ""
            If MessageBox.Show("Are you sure you want to submit these operations?", "Submit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                For Each c As Integer In GridView1.GetSelectedRows
                    SqlQuery = " Select TransDate from AcJournalD1ES where TransID = " & GridView1.GetRowCellValue(c, "TransID") & " And PosCode ='" & FrmMainForm.TabletPos & "'"
                    Dim SqlCom As New SqlCommand(SqlQuery, FrmLogin.objcon.con)
                    If FrmLogin.objcon.con.State = ConnectionState.Closed Then
                        FrmLogin.objcon.con.Open()
                    End If
                    CurrD = SqlCom.ExecuteScalar
                    If GridView1.GetRowCellValue(c, "Description") = FrmMainForm.PostDatedCode Then
                        InsertPostDated(CurrD.Date, c, GridView1.GetRowCellValue(c, "TransID"))
                    Else
                        InsertReciept(CurrD.Date, c, GridView1.GetRowCellValue(c, "TransID"))
                    End If
                Next
            End If

            GridView1.SelectAll()
            GridView1.DeleteSelectedRows()
            GridControl1.DataSource = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Sub InsertReciept(ByVal datet As DateTime, ByVal i As Integer, ByVal pTransID As String)
        Try
            Dim clsJournalA As New ClsJournalA
            Dim sqlcomm As New SqlCommand("select Sequence from sacsequence where SeqCode='transid' and seqyear=" & Today.Year & "", ServerCnx)
            Dim blnconnectionOpen = ConnStatus(ServerCnx)
            If Not blnconnectionOpen Then ConnOpen(ServerCnx)
            If IsDBNull(sqlcomm.ExecuteScalar) Or IsNothing(sqlcomm.ExecuteScalar) Then
                Dim sqlc As New SqlCommand("insert into SacSequence (SeqCode,SeqYear,Companyid,Sequence) values ('transid" & _
                                       "'," & Today.Year & ",1," & Today.Year & "000000)", ServerCnx)
                sqlc.ExecuteNonQuery()
            End If
            sqlcomm = New SqlCommand("select Sequence from sacsequence where SeqCode='transid' and seqyear=" & Today.Year & "", ServerCnx)
            Dim blnconnectionOpe = ConnStatus(ServerCnx)
            If Not blnconnectionOpe Then ConnOpen(ServerCnx)
            Dim OperID As Integer = sqlcomm.ExecuteScalar + 1

            Dim TransID As Integer = sqlcomm.ExecuteScalar
            clsJournalA._P1 = TransID + 1
            clsJournalA._P2 = "RV"
            Dim sqlcomm1 As New SqlCommand("select Sequence from sacsequence where SeqCode='RV' and seqyear=" & Today.Year & "", ServerCnx)
            blnconnectionOpen = ConnStatus(ServerCnx)
            If Not blnconnectionOpen Then ConnOpen(ServerCnx)
            If IsDBNull(sqlcomm1.ExecuteScalar) Or IsNothing(sqlcomm1.ExecuteScalar) Then
                Dim sqlc As New SqlCommand("insert into SacSequence (SeqCode,SeqYear,Companyid,Sequence) values ('RV'," & Today.Year & ",1," & Today.Year & "000000)", ServerCnx)
                sqlc.ExecuteNonQuery()
            End If
            blnconnectionOpen = ConnStatus(ServerCnx)
            If Not blnconnectionOpen Then ConnOpen(ServerCnx)
            Dim TypeId As Integer = sqlcomm1.ExecuteScalar

            clsJournalA._P3 = TypeId + 1
            clsJournalA._P4 = GridView1.GetRowCellValue(i, "ManualRef")
            clsJournalA._P5 = Today.Date
            clsJournalA._P6 = datet
            clsJournalA._P7 = 0
            clsJournalA._P8 = 0
            clsJournalA._P9 = ""
            clsJournalA._P10 = 2
            clsJournalA._P11 = FrmLogin.user
            clsJournalA._P12 = FrmLogin.user
            clsJournalA.JournalAInsert(ServerCnx)
            Dim sqlcomm2 As New SqlCommand("update sacsequence set Sequence=" & TransID + 1 & " where SeqCode='transid' and seqyear=" & Today.Year & "", ServerCnx)
            Dim blnconnectionOpen1 = ConnStatus(ServerCnx)
            If Not blnconnectionOpen1 Then ConnOpen(ServerCnx)
            sqlcomm2.ExecuteNonQuery()
            Dim sqlcomm3 As New SqlCommand("update sacsequence set Sequence=" & TypeId + 1 & " where SeqCode='RV' and seqyear=" & Today.Year & "", ServerCnx)
            Dim blnconnectionOpen3 = ConnStatus(ServerCnx)
            If Not blnconnectionOpen3 Then ConnOpen(ServerCnx)
            sqlcomm3.ExecuteNonQuery()
            'Journal B

            Dim LineID As Integer = 1

            Dim ClsJournalB1 As New ClsJournalB
            ClsJournalB1._P1 = TransID + 1
            ClsJournalB1._P2 = LineID
            ClsJournalB1._P3 = LineID
            ClsJournalB1._P4 = FrmMainForm.AccCode
            ClsJournalB1._P5 = "C"
            ClsJournalB1._P6 = DBNull.Value
            ClsJournalB1._P7 = DBNull.Value
            ClsJournalB1._P8 = 1
            ClsJournalB1._P9 = GridView1.GetRowCellValue(i, "ThirdID")
            ClsJournalB1._P10 = DBNull.Value
            ClsJournalB1._P11 = ""
            ClsJournalB1._P12 = "USD"
            ClsJournalB1._P13 = 0
            Dim CurDecimals = GetCurrencyDec(FrmMainForm.CurCode)

            Dim SqlCom1 As New SqlCommand("Select Amount, Fl_Amount, Sl_Amount From AcJournalE1ES where TransID = '" & GridView1.GetRowCellValue(i, "TransID") & "' and PosCode = '" & FrmMainForm.TabletPos & "' And ThirdId is not null", FrmLogin.objcon.con)
            If FrmLogin.objcon.con.State = ConnectionState.Closed Then
                FrmLogin.objcon.con.Open()
            End If
            Dim dt As New DataTable
            da = New SqlDataAdapter(SqlCom1)
            da.Fill(dt)
            Dim Amount = dt.Rows(0).Item("Amount")
            ClsJournalB1._P14 = Math.Round(CDbl(Amount), CurDecimals)
            ClsJournalB1._P15 = Math.Round(CDbl(dt.Rows(0).Item("Fl_Amount")), CurDecimals)
            ClsJournalB1._P16 = Math.Round(CDbl(dt.Rows(0).Item("Sl_Amount")), CurDecimals)

            Dim SqlString = " Select Name from SacthirdParty where Thirdid=" & GridView1.GetRowCellValue(i, "ThirdID")
            Dim Sqlcom5 As New SqlCommand(SqlString, ServerCnx)
            If ServerCnx.State = ConnectionState.Closed Then
                ServerCnx.Open()
            End If
            Dim Name = IIf(IsDBNull(Sqlcom5.ExecuteScalar) Or IsNothing(Sqlcom5.ExecuteScalar), "", Sqlcom5.ExecuteScalar)
            Dim CheckNbr = IIf(IsNothing(GridView1.GetRowCellValue(i, "CheckNbr")) Or IsDBNull(GridView1.GetRowCellValue(i, "CheckNbr")), "", GridView1.GetRowCellValue(i, "CheckNbr"))
            Dim MOP = IIf(IsNothing(GridView1.GetRowCellValue(i, "CheckBank")) Or IsDBNull(GridView1.GetRowCellValue(i, "CheckBank")), DBNull.Value, GridView1.GetRowCellValue(i, "CheckBank"))
            If Not IsNothing(GridView1.GetRowCellValue(i, "CheckBank")) And Not IsDBNull(GridView1.GetRowCellValue(i, "CheckBank")) Then
                If GridView1.GetRowCellValue(i, "CheckBank").ToString = "" Then
                    MOP = "Cash"
                Else
                    MOP = GridView1.GetRowCellValue(i, "CheckBank").ToString
                End If
            Else
                MOP = "Cash"
            End If
            Dim CheckMat = IIf(IsNothing(GridView1.GetRowCellValue(i, "CheckMaturity")) Or IsDBNull(GridView1.GetRowCellValue(i, "CheckMaturity")), "", GridView1.GetRowCellValue(i, "CheckMaturity"))

            ClsJournalB1._P17 = MOP + " #" + CheckNbr + " Dt:" + CheckMat
            'checkmaturity
            ClsJournalB1._P18 = GridView1.GetRowCellValue(i, "CheckMaturity")
            ClsJournalB1._P19 = DBNull.Value
            ClsJournalB1._P20 = DBNull.Value
            ClsJournalB1._P21 = IIf(IsNothing(GridView1.GetRowCellValue(i, "CheckNbr")) Or IsDBNull(GridView1.GetRowCellValue(i, "CheckNbr")), "", GridView1.GetRowCellValue(i, "CheckNbr"))
            ClsJournalB1._P22 = FrmLogin.user
            ClsJournalB1._P23 = DateTime.Today
            ClsJournalB1._P24 = Name
            ClsJournalB1.JournalBInsert(ServerCnx)

            LineID += 1


            Dim ClsJournalB As New ClsJournalB
            ClsJournalB._P1 = TransID + 1
            ClsJournalB._P2 = LineID
            ClsJournalB._P3 = LineID
            Dim sqlcomm4 As New SqlCommand("select AccCode from RsMop where Code='" & GridView1.GetRowCellValue(i, "Description") & "'", FrmLogin.objcon.con)
            ClsJournalB._P4 = sqlcomm4.ExecuteScalar
            ClsJournalB._P5 = "D"
            ClsJournalB._P6 = DBNull.Value
            ClsJournalB._P7 = DBNull.Value
            ClsJournalB._P8 = 0
            ClsJournalB._P9 = DBNull.Value
            Dim sqlcomm5 As New SqlCommand("select AuxbCode from RsMop where Code='" & GridView1.GetRowCellValue(i, "Description") & "'", FrmLogin.objcon.con)
            ClsJournalB._P10 = sqlcomm5.ExecuteScalar
            ClsJournalB._P11 = ""
            ClsJournalB._P12 = IIf(IsNothing(GridView1.GetRowCellValue(i, "CurCode")) Or IsDBNull(GridView1.GetRowCellValue(i, "CurCode")), DBNull.Value, GridView1.GetRowCellValue(i, "CurCode"))
            ClsJournalB._P13 = 0
            SqlCom1 = New SqlCommand("Select Amount, Fl_Amount, Sl_Amount From AcJournalE1ES where TransID = '" & GridView1.GetRowCellValue(i, "TransID") & "' and PosCode = '" & FrmMainForm.TabletPos & "' And ThirdId is null", FrmLogin.objcon.con)
            If FrmLogin.objcon.con.State = ConnectionState.Closed Then
                FrmLogin.objcon.con.Open()
            End If
            dt = New DataTable
            dt.Clear()
            da = New SqlDataAdapter(SqlCom1)
            da.Fill(dt)
            Amount = dt.Rows(0).Item("Amount")
            ClsJournalB._P14 = Math.Round(CDbl(Amount), CurDecimals)
            ClsJournalB._P15 = Math.Round(CDbl(dt.Rows(0).Item("Fl_Amount")), CurDecimals)
            ClsJournalB._P16 = Math.Round(CDbl(dt.Rows(0).Item("Sl_Amount")), CurDecimals)


            ClsJournalB._P17 = "From " + Name + " " + MOP + " #" + CheckNbr + " Dt:" + CheckMat

            'checkmaturity
            ClsJournalB._P18 = IIf(IsNothing(GridView1.GetRowCellValue(i, "CheckMaturity")) Or IsDBNull(GridView1.GetRowCellValue(i, "CheckMaturity")), datet, GridView1.GetRowCellValue(i, "CheckMaturity"))
            ClsJournalB._P19 = IIf(IsNothing(GridView1.GetRowCellValue(i, "CheckNbr")) Or IsDBNull(GridView1.GetRowCellValue(i, "CheckNbr")), DBNull.Value, GridView1.GetRowCellValue(i, "CheckNbr"))
            ClsJournalB._P20 = IIf(IsNothing(GridView1.GetRowCellValue(i, "CheckBank")) Or IsDBNull(GridView1.GetRowCellValue(i, "CheckBank")), DBNull.Value, GridView1.GetRowCellValue(i, "CheckBank"))
            ClsJournalB._P21 = IIf(IsNothing(GridView1.GetRowCellValue(i, "CheckNote")) Or IsDBNull(GridView1.GetRowCellValue(i, "CheckNote")), DBNull.Value, GridView1.GetRowCellValue(i, "CheckNote"))
            ClsJournalB._P22 = FrmLogin.user
            ClsJournalB._P23 = DateTime.Today
            ClsJournalB._P24 = ""
            ClsJournalB.JournalBInsert(ServerCnx)
            LineID += 1
            Dim SqlQuery = " Update AcJournalD1Es set Status = 1 where PosCode='" & FrmMainForm.TabletPos & "' and TransID ='" & pTransID & "'"
            Dim sqlCom As New SqlCommand(SqlQuery, FrmLogin.objcon.con)
            If FrmLogin.objcon.con.State = ConnectionState.Closed Then
                FrmLogin.objcon.con.Open()
            End If
            sqlCom.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub InsertPostDated(ByVal datet As DateTime, ByVal i As Integer, ByVal pTransID As String)
        Try
            Dim clsJournalA As New ClsJournalA
            Dim sqlcomm As New SqlCommand("select Sequence from sacsequence where SeqCode='PostDated' and seqyear=" & Today.Year & "", ServerCnx)
            Dim blnconnectionOpen = ConnStatus(ServerCnx)
            If Not blnconnectionOpen Then ConnOpen(ServerCnx)
            If IsDBNull(sqlcomm.ExecuteScalar) Or IsNothing(sqlcomm.ExecuteScalar) Then
                Dim sqlc As New SqlCommand("insert into SacSequence (SeqCode,SeqYear,Companyid,Sequence) values ('PostDated" & _
                                       "'," & Today.Year & ",1," & Today.Year & "000000)", ServerCnx)
                sqlc.ExecuteNonQuery()
            End If
            sqlcomm = New SqlCommand("select Sequence from sacsequence where SeqCode='PostDated' and seqyear=" & Today.Year & "", ServerCnx)
            Dim blnconnectionOpe = ConnStatus(ServerCnx)
            If Not blnconnectionOpe Then ConnOpen(ServerCnx)
            Dim OperID As Integer = sqlcomm.ExecuteScalar + 1

            Dim TransID As Integer = sqlcomm.ExecuteScalar
            clsJournalA._P1 = TransID + 1
            clsJournalA._P2 = "RV"
            Dim sqlcomm1 As New SqlCommand("select Sequence from sacsequence where SeqCode='PostDatedType' and seqyear=" & Today.Year & "", ServerCnx)
            blnconnectionOpen = ConnStatus(ServerCnx)
            If Not blnconnectionOpen Then ConnOpen(ServerCnx)
            If IsDBNull(sqlcomm1.ExecuteScalar) Or IsNothing(sqlcomm1.ExecuteScalar) Then
                Dim sqlc As New SqlCommand("insert into SacSequence (SeqCode,SeqYear,Companyid,Sequence) values ('PostDatedType'," & Today.Year & ",1," & Today.Year & "000000)", ServerCnx)
                sqlc.ExecuteNonQuery()
            End If
            blnconnectionOpen = ConnStatus(ServerCnx)
            If Not blnconnectionOpen Then ConnOpen(ServerCnx)
            Dim TypeId As Integer = sqlcomm1.ExecuteScalar

            clsJournalA._P3 = TypeId + 1
            clsJournalA._P4 = GridView1.GetRowCellValue(i, "ManualRef")
            clsJournalA._P5 = Today.Date
            clsJournalA._P6 = datet
            clsJournalA._P7 = 0
            clsJournalA._P8 = 0
            clsJournalA._P9 = ""
            clsJournalA._P10 = 2
            clsJournalA._P11 = FrmLogin.user
            clsJournalA._P12 = FrmLogin.user
            clsJournalA.PostJournalAInsert(ServerCnx)
            Dim sqlcomm2 As New SqlCommand("update sacsequence set Sequence=" & TransID + 1 & " where SeqCode='PostDated' and seqyear=" & Today.Year & "", ServerCnx)
            Dim blnconnectionOpen1 = ConnStatus(ServerCnx)
            If Not blnconnectionOpen1 Then ConnOpen(ServerCnx)
            sqlcomm2.ExecuteNonQuery()
            Dim sqlcomm3 As New SqlCommand("update sacsequence set Sequence=" & TypeId + 1 & " where SeqCode='PostDatedType' and seqyear=" & Today.Year & "", ServerCnx)
            Dim blnconnectionOpen3 = ConnStatus(ServerCnx)
            If Not blnconnectionOpen3 Then ConnOpen(ServerCnx)
            sqlcomm3.ExecuteNonQuery()
            'Journal B

            Dim LineID As Integer = 1

            Dim ClsJournalB1 As New ClsJournalB
            ClsJournalB1._P1 = TransID + 1
            ClsJournalB1._P2 = LineID
            ClsJournalB1._P3 = LineID
            ClsJournalB1._P4 = FrmMainForm.AccCode
            ClsJournalB1._P5 = "C"
            ClsJournalB1._P6 = DBNull.Value
            ClsJournalB1._P7 = DBNull.Value
            ClsJournalB1._P8 = 1
            ClsJournalB1._P9 = GridView1.GetRowCellValue(i, "ThirdID")
            ClsJournalB1._P10 = DBNull.Value
            ClsJournalB1._P11 = ""
            ClsJournalB1._P12 = GridView1.GetRowCellValue(i, "CurCode")
            ClsJournalB1._P13 = 0
            Dim CurDecimals = GetCurrencyDec(FrmMainForm.CurCode)
            Dim FL As Double = 0
            Dim SL As Double = 0
            Dim Amount = GridView1.GetRowCellValue(i, "Amount")
            Dim sqlcomm8 As New SqlCommand("select CurMain from SacCurrency where CurCode='" & GridView1.GetRowCellValue(i, "CurCode") & "'", ServerCnx)
            If ServerCnx.State = ConnectionState.Closed Then
                ServerCnx.Open()
            End If
            ClsJournalB1._P14 = Math.Round(CDbl(Amount), CurDecimals)
            Dim CurMain = sqlcomm8.ExecuteScalar
            If (CurMain = 1) Then '3m yedfa3 lebenen
                'LBP
                Dim LBP = Math.Round(CDbl(Amount), CurDecimals)
                ClsJournalB1._P15 = LBP
                FL = LBP
                Dim sqlcomm9 As New SqlCommand("select CurCode from SacCurrency where CurMain=2", ServerCnx)
                If ServerCnx.State = ConnectionState.Closed Then
                    ServerCnx.Open()
                End If
                Dim SecondCur2 = sqlcomm9.ExecuteScalar
                Dim salesRate2 = GetSalesRate(1, SecondCur2, DateTime.Today.ToString("yyyyMMdd"))
                'USD
                If Math.Round(CDbl(Amount), CurDecimals) = 0 Then
                    SL = 0
                    ClsJournalB1._P16 = 0
                Else
                    SL = Math.Round(Amount / salesRate2, CurDecimals)
                    ClsJournalB1._P16 = Math.Round(Amount / salesRate2, CurDecimals)
                End If
            Else
                If CurMain = 2 Then '3m yedfa3 $
                    ClsJournalB1._P16 = Math.Round(Amount, CurDecimals)
                    SL = Math.Round(Amount, CurDecimals)
                    Dim sqlcomm9 As New SqlCommand("select CurCode from SacCurrency where CurMain=1", ServerCnx)
                    If ServerCnx.State = ConnectionState.Closed Then
                        ServerCnx.Open()
                    End If
                    Dim SecondCur1 = sqlcomm9.ExecuteScalar
                    Dim salesslRate1 = GetSalesSLRate(1, SecondCur1, DateTime.Today.ToString("yyyyMMdd"))
                    'LBP
                    If Math.Round(CDbl(GridView1.GetRowCellValue(i, "Amount")), CurDecimals) = 0 Then
                        ClsJournalB1._P15 = 0
                        FL = 0
                    Else
                        FL = Math.Round(Amount / salesslRate1, CurDecimals)
                        ClsJournalB1._P15 = Math.Round(Amount / salesslRate1, CurDecimals)
                    End If
                End If
            End If
            Dim SqlString = " Select Name from SacthirdParty where Thirdid=" & GridView1.GetRowCellValue(i, "ThirdID")
            Dim Sqlcom5 As New SqlCommand(SqlString, ServerCnx)
            If ServerCnx.State = ConnectionState.Closed Then
                ServerCnx.Open()
            End If
            Dim Name = IIf(IsDBNull(Sqlcom5.ExecuteScalar) Or IsNothing(Sqlcom5.ExecuteScalar), "", Sqlcom5.ExecuteScalar)
            Dim CheckNbr = IIf(IsNothing(GridView1.GetRowCellValue(i, "CheckNbr")) Or IsDBNull(GridView1.GetRowCellValue(i, "CheckNbr")), "", GridView1.GetRowCellValue(i, "CheckNbr"))
            Dim MOP = IIf(IsNothing(GridView1.GetRowCellValue(i, "CheckBank")) Or IsDBNull(GridView1.GetRowCellValue(i, "CheckBank")), DBNull.Value, GridView1.GetRowCellValue(i, "CheckBank"))
            If Not IsNothing(GridView1.GetRowCellValue(i, "CheckBank")) And Not IsDBNull(GridView1.GetRowCellValue(i, "CheckBank")) Then
                If GridView1.GetRowCellValue(i, "CheckBank").ToString = "" Then
                    MOP = "Cash"
                Else
                    MOP = GridView1.GetRowCellValue(i, "CheckBank").ToString
                End If
            Else
                MOP = "Cash"
            End If
            Dim CheckMat = IIf(IsNothing(GridView1.GetRowCellValue(i, "CheckMaturity")) Or IsDBNull(GridView1.GetRowCellValue(i, "CheckMaturity")), "", GridView1.GetRowCellValue(i, "CheckMaturity"))
            ClsJournalB1._P17 = MOP + " #" + CheckNbr + " Dt:" + CheckMat
            'checkmaturity
            ClsJournalB1._P18 = GridView1.GetRowCellValue(i, "CheckMaturity")
            ClsJournalB1._P19 = DBNull.Value
            ClsJournalB1._P20 = DBNull.Value
            ClsJournalB1._P21 = IIf(IsNothing(GridView1.GetRowCellValue(i, "CheckNote")) Or IsDBNull(GridView1.GetRowCellValue(i, "CheckNote")), DBNull.Value, GridView1.GetRowCellValue(i, "CheckNote"))
            ClsJournalB1._P22 = FrmLogin.user
            ClsJournalB1._P23 = DateTime.Today
            ClsJournalB1._P24 = ""
            ClsJournalB1.PostJournalBInsert(ServerCnx)
            LineID += 1
            Dim ClsJournalB As New ClsJournalB
            ClsJournalB._P1 = TransID + 1
            ClsJournalB._P2 = LineID
            ClsJournalB._P3 = LineID
            Dim sqlcomm4 As New SqlCommand("select AccCode from RsMop where Code='" & GridView1.GetRowCellValue(i, "Description") & "'", FrmLogin.objcon.con)
            ClsJournalB._P4 = sqlcomm4.ExecuteScalar
            ClsJournalB._P5 = "D"
            ClsJournalB._P6 = DBNull.Value
            ClsJournalB._P7 = DBNull.Value
            ClsJournalB._P8 = 0
            ClsJournalB._P9 = DBNull.Value
            Dim sqlcomm5 As New SqlCommand("select AuxbCode from RsMop where Code='" & GridView1.GetRowCellValue(i, "Description") & "'", FrmLogin.objcon.con)
            ClsJournalB._P10 = sqlcomm5.ExecuteScalar
            ClsJournalB._P11 = ""
            ClsJournalB._P12 = IIf(IsNothing(GridView1.GetRowCellValue(i, "CurCode")) Or IsDBNull(GridView1.GetRowCellValue(i, "CurCode")), DBNull.Value, GridView1.GetRowCellValue(i, "CurCode"))
            ClsJournalB._P13 = 0
            ClsJournalB._P14 = Amount
            ClsJournalB._P15 = FL
            ClsJournalB._P16 = SL
            ClsJournalB._P17 = "From " + Name + " " + MOP + " #" + CheckNbr + " Dt:" + CheckMat

            'checkmaturity
            ClsJournalB._P18 = IIf(IsNothing(GridView1.GetRowCellValue(i, "CheckMaturity")) Or IsDBNull(GridView1.GetRowCellValue(i, "CheckMaturity")), datet, GridView1.GetRowCellValue(i, "CheckMaturity"))
            ClsJournalB._P19 = IIf(IsNothing(GridView1.GetRowCellValue(i, "CheckNbr")) Or IsDBNull(GridView1.GetRowCellValue(i, "CheckNbr")), DBNull.Value, GridView1.GetRowCellValue(i, "CheckNbr"))
            ClsJournalB._P20 = IIf(IsNothing(GridView1.GetRowCellValue(i, "CheckBank")) Or IsDBNull(GridView1.GetRowCellValue(i, "CheckBank")), DBNull.Value, GridView1.GetRowCellValue(i, "CheckBank"))
            ClsJournalB._P21 = IIf(IsNothing(GridView1.GetRowCellValue(i, "CheckNote")) Or IsDBNull(GridView1.GetRowCellValue(i, "CheckNote")), DBNull.Value, GridView1.GetRowCellValue(i, "CheckNote"))
            ClsJournalB._P22 = FrmLogin.user
            ClsJournalB._P23 = DateTime.Today
            ClsJournalB._P24 = ""
            ClsJournalB.PostJournalBInsert(ServerCnx)
            LineID += 1
            Dim SqlQuery = " Update AcJournalD1Es set Status = 1 where PosCode='" & FrmMainForm.TabletPos & "' and TransID ='" & pTransID & "'"
            Dim sqlCom As New SqlCommand(SqlQuery, FrmLogin.objcon.con)
            If FrmLogin.objcon.con.State = ConnectionState.Closed Then
                FrmLogin.objcon.con.Open()
            End If
            sqlCom.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Function GetCurrencyDec(ByVal Curcode As String) As Integer
        Try
            Dim sqlCom As New SqlCommand("select Decimals from saccurrency where curcode='" & Curcode & "'", ServerCnx)
            Dim blnconnectionOpen As Boolean
            blnconnectionOpen = ConnStatus(ServerCnx)
            If Not blnconnectionOpen Then ConnOpen(ServerCnx)
            Return IIf(IsDBNull(sqlCom.ExecuteScalar) Or IsNothing(sqlCom.ExecuteScalar), 0, sqlCom.ExecuteScalar)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Public Function GetSalesRate(ByVal CmpID As Integer, ByVal CurCode As String, ByVal Datep As String) As Double
        Try
            Dim sqlcomm As New SqlCommand("Sp_GetHelpRates", ServerCnx)
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@Cmp", 1)
            sqlcomm.Parameters.AddWithValue("@date1", DateTime.Today.ToString("yyyyMMdd"))
            sqlcomm.Parameters.AddWithValue("@cur", CurCode)
            Dim blnconnectionOpen = ConnStatus(ServerCnx)
            If Not blnconnectionOpen Then ConnOpen(ServerCnx)
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
            Dim sqlcomm As New SqlCommand("Sp_GetHelpRates", ServerCnx)
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@Cmp", 1)
            sqlcomm.Parameters.AddWithValue("@date1", DateTime.Today.ToString("yyyyMMdd"))
            sqlcomm.Parameters.AddWithValue("@cur", CurCode)
            Dim blnconnectionOpen = ConnStatus(ServerCnx)
            If Not blnconnectionOpen Then ConnOpen(ServerCnx)
            Dim dt As New DataTable
            da = New SqlDataAdapter(sqlcomm)
            da.Fill(dt)
            Dim SalesSLRate As Double = dt.Rows(0).Item("SalesSLRate")
            Return IIf(IsNothing(SalesSLRate) Or IsDBNull(SalesSLRate), 0, SalesSLRate)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
End Class