Imports ConnectionSQL
Imports DevExpress.XtraEditors
Imports System.Data.SqlClient
Imports System.Text
Imports System.IO
Imports System.ComponentModel

Public Class FrmPOS
    Implements Procedures
    Public Shared add As Boolean = False
    Public Shared edit As Boolean = False
    Dim ClsPosConf As New ClsPOS
    Dim isGenerate As Boolean = False
    Private Sub FrmPOS_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        Try
            MenuLockUnlock(add, edit)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub FrmPOS_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If edit = True Or add = True Then
            MessageBox.Show("Cant Exit In Add/Edit Mode, Save Or Cancel Your Modifications", "Error", MessageBoxButtons.OK)
            e.Cancel = True
            Exit Sub
        End If
    End Sub
    Private Sub FrmPOS_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            viewmode()
            LockUnlockMe()
            lbl.Text = ""
            ClsPosConf.FillPosConfig(FrmLogin.objcon.con)
            lastRecord()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub viewmode()
        Me.Text = "POS <" & My.Application.Info.Version.ToString & "> View Mode"
        add = False
        edit = False
    End Sub
    Public Sub SetTextBoxInfo(stringValue As String)
        Me.BeginInvoke(Sub() Me.lbl.Text = stringValue)
    End Sub
    Public Function cancel() As Object Implements Procedures.cancel
        Try
            If MessageBox.Show("Cancel All Modifications?", "Cancel", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                viewmode()
                GetCurrentRecord()
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
        Exit Sub
    End Sub
    Public Function EditRecord() As Object Implements Procedures.EditRecord
        If txtPOs.Text = String.Empty Then Return False
        Me.Text = "POS <" & My.Application.Info.Version.ToString & "> Edit Mode"
        edit = True
        add = False
        Return True
    End Function
    Public Sub FillDefault() Implements Procedures.FillDefault
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is TextEdit And Not (TypeOf ctrl Is GridLookUpEdit) Then
                CType(ctrl, TextEdit).Text = String.Empty
            End If
        Next
        txtPOs.Focus()
    End Sub
    Public Sub find() Implements Procedures.find

    End Sub
    Public Sub FirstRecord() Implements Procedures.FirstRecord
        Try
            Dim PosConf As New PosConf
            Dim vEr As String = String.Empty
            PosConf = ClsPosConf.GetFirstPOS(vEr)
            If vEr = "" Then
                txtPOs.Text = PosConf.POSCode
                txtServer.Text = PosConf.Server
                txtDB.Text = PosConf.Database
                txtUser.Text = PosConf.User
                txtPass.Text = PosConf.Password
                txtWHS.Text = PosConf.WhsCode
                txtthirdid.Text = PosConf.ThirdID
                txtSalesManID.Text = PosConf.SalesManID
            Else
                txtSalesManID.Text = String.Empty
                txtthirdid.Text = String.Empty
                txtPOs.Text = String.Empty
                txtServer.Text = String.Empty
                txtDB.Text = String.Empty
                txtUser.Text = String.Empty
                txtPass.Text = String.Empty
                txtWHS.Text = String.Empty
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub lastRecord() Implements Procedures.lastRecord
        Try
            Dim PosConf As New PosConf
            Dim vEr As String = String.Empty
            PosConf = ClsPosConf.GetLastPOS(vEr)
            If vEr = "" Then
                txtPOs.Text = PosConf.POSCode
                txtServer.Text = PosConf.Server
                txtDB.Text = PosConf.Database
                txtUser.Text = PosConf.User
                txtPass.Text = PosConf.Password
                txtWHS.Text = PosConf.WhsCode
                txtthirdid.Text = PosConf.ThirdID
                txtSalesManID.Text = PosConf.SalesManID
            Else
                txtSalesManID.Text = String.Empty
                txtthirdid.Text = String.Empty
                txtPOs.Text = String.Empty
                txtServer.Text = String.Empty
                txtDB.Text = String.Empty
                txtUser.Text = String.Empty
                txtPass.Text = String.Empty
                txtWHS.Text = String.Empty
            End If
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
                Next
            Else
                For Each ctrl As Control In Me.Controls
                    If TypeOf ctrl Is TextEdit Then
                        CType(ctrl, TextEdit).Properties.ReadOnly = True
                    End If
                Next
                btnRegenerate.Enabled = False
                BtnGenerate.Enabled = False
            End If
            If add = False And edit = True Then
                txtWHS.Properties.ReadOnly = True
                txtPOs.Properties.ReadOnly = True
            End If
            If add = False And edit = False Then
                btnRegenerate.Enabled = True
                BtnGenerate.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
        Me.Text = "POS <" & My.Application.Info.Version.ToString & "> Add Mode"
        add = True
        edit = True
        Return True
    End Function
    Public Sub GetCurrentRecord()
        Try
            Dim PosConf As New PosConf
            Dim vEr As String = String.Empty
            PosConf = ClsPosConf.GetCurrentRecord(ClsPOS.i, vEr)
            If vEr = "" Then
                txtPOs.Text = PosConf.POSCode
                txtServer.Text = PosConf.Server
                txtDB.Text = PosConf.Database
                txtUser.Text = PosConf.User
                txtPass.Text = PosConf.Password
                txtWHS.Text = PosConf.WhsCode
                txtthirdid.Text = PosConf.ThirdID
                txtSalesManID.Text = PosConf.SalesManID
            Else
                txtSalesManID.Text = String.Empty
                txtthirdid.Text = String.Empty
                txtPOs.Text = String.Empty
                txtServer.Text = String.Empty
                txtDB.Text = String.Empty
                txtUser.Text = String.Empty
                txtPass.Text = String.Empty
                txtWHS.Text = String.Empty
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub nextRecord() Implements Procedures.nextRecord
        Try
            Dim PosConf As New PosConf
            Dim vEr As String = String.Empty
            PosConf = ClsPosConf.GetNextPOS(vEr)
            If vEr = "" Then
                txtPOs.Text = PosConf.POSCode
                txtServer.Text = PosConf.Server
                txtDB.Text = PosConf.Database
                txtUser.Text = PosConf.User
                txtPass.Text = PosConf.Password
                txtWHS.Text = PosConf.WhsCode
                txtthirdid.Text = PosConf.ThirdID
                txtSalesManID.Text = PosConf.SalesManID
            Else
                txtSalesManID.Text = String.Empty
                txtthirdid.Text = String.Empty
                txtPOs.Text = String.Empty
                txtServer.Text = String.Empty
                txtDB.Text = String.Empty
                txtUser.Text = String.Empty
                txtPass.Text = String.Empty
                txtWHS.Text = String.Empty
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub PreviousRecord() Implements Procedures.PreviousRecord
        Try
            Dim PosConf As New PosConf
            Dim vEr As String = String.Empty
            PosConf = ClsPosConf.GetPrevPOS(vEr)
            If vEr = "" Then
                txtPOs.Text = PosConf.POSCode
                txtServer.Text = PosConf.Server
                txtDB.Text = PosConf.Database
                txtUser.Text = PosConf.User
                txtPass.Text = PosConf.Password
                txtWHS.Text = PosConf.WhsCode
                txtthirdid.Text = PosConf.ThirdID
                txtSalesManID.Text = PosConf.SalesManID
            Else
                txtSalesManID.Text = String.Empty
                txtthirdid.Text = String.Empty
                txtPOs.Text = String.Empty
                txtServer.Text = String.Empty
                txtDB.Text = String.Empty
                txtUser.Text = String.Empty
                txtPass.Text = String.Empty
                txtWHS.Text = String.Empty
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
    Public Function FindPos() As String
        Try
            Dim SqlString = "Select isnull(PosCode,'') from PolyPosConf where PosCode ='" & txtPOs.Text & "'"
            Dim sqlcom As New SqlCommand(SqlString, FrmLogin.objcon.con)
            If FrmLogin.objcon.con.State = ConnectionState.Closed Then
                FrmLogin.objcon.con.Open()
            End If
            Return sqlcom.ExecuteScalar
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Public Function Save() As Object Implements Procedures.Save
        Try
            If txtWHS.Text.Trim = "" Then
                MessageBox.Show("Insert Whs Code", "BusinessPack", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtWHS.Focus()
                Return False
            End If
            If txtPOs.Text.Trim = "" Then
                MessageBox.Show("Insert Pos Code", "BusinessPack", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPOs.Focus()
                Return False
            End If
            If txtServer.Text.Trim = "" Then
                MessageBox.Show("Insert Server Name", "BusinessPack", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtServer.Focus()
                Return False
            End If
            If txtDB.Text.Trim = "" Then
                MessageBox.Show("Insert Database Name", "BusinessPack", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtDB.Focus()
                Return False
            End If
            If txtUser.Text.Trim = "" Then
                MessageBox.Show("Insert User", "BusinessPack", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtUser.Focus()
                Return False
            End If
            If txtSalesManID.Text.Trim = "" Then
                MessageBox.Show("Insert Salesman ID", "BusinessPack", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtSalesManID.Focus()
                Return False
            End If
            If txtthirdid.Text.Trim = "" Then
                MessageBox.Show("Insert Customer ID", "BusinessPack", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtthirdid.Focus()
                Return False
            End If
            Dim ClsPos As New ClsPOS
            If add = True And edit = True Then
                If FindPos() <> "" Then
                    MessageBox.Show("Pos Already Exist", "BusinessPack", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If
                ClsPos._Database = txtDB.Text
                ClsPos._Password = txtPass.Text
                ClsPos._POSCode = txtPOs.Text
                ClsPos._Server = txtServer.Text
                ClsPos._ThirdID = txtthirdid.Text
                ClsPos._User = txtUser.Text
                ClsPos._SalesManID = txtSalesManID.Text
                ClsPos._WhsCode = txtWHS.Text
                ClsPos.SavePosConf(FrmLogin.objcon.con)
                viewmode()
                ClsPosConf.FillPosConfig(FrmLogin.objcon.con)
                lastRecord()
                Dim Sql = String.Empty
                Sql = " IF not exists ( select poscode from IVPos1ES where PosCode='" & txtPOs.Text & "')"
                Sql = Sql & " insert into IvPos1ES (PosCode,Description,AltDescription,Active,iuser)"
                Sql = Sql & " values ('" & txtPOs.Text & "', '" & txtPOs.Text & "','',1,'" & FrmLogin.user & "')"
                Dim sqlcom As New SqlCommand(Sql, FrmLogin.objcon.con)
                sqlcom.ExecuteNonQuery()
                Sql = String.Empty
                Sql = " IF not exists ( select WhsCode from IvWhs1ES where WhsCode='" & txtWHS.Text & "')"
                Sql = Sql & " insert into IvWhs1ES (WhsCode,Description,AltDescription,Active,WhsGroupCode,transferpct,iuser)"
                Sql = Sql & " values ('" & txtWHS.Text & "', '" & txtWHS.Text & "', '',1,'Misc',0,'" & FrmLogin.user & "')"
                sqlcom = New SqlCommand(Sql, FrmLogin.objcon.con)
                sqlcom.ExecuteNonQuery()
                Return True
            ElseIf add = False And edit = True Then
                ClsPos._Database = txtDB.Text
                ClsPos._Password = txtPass.Text
                ClsPos._POSCode = txtPOs.Text
                ClsPos._Server = txtServer.Text
                ClsPos._User = txtUser.Text
                ClsPos._ThirdID = txtthirdid.Text
                ClsPos._SalesManID = txtSalesManID.Text
                ClsPos._WhsCode = txtWHS.Text
                ClsPos.UpdatePosConf(FrmLogin.objcon.con)
                viewmode()
                ClsPosConf.FillPosConfig(FrmLogin.objcon.con)
                GetCurrentRecord()
                Dim Sql = String.Empty
                Sql = " IF not exists ( select poscode from IVPos1ES where PosCode='" & txtPOs.Text & "')"
                Sql = Sql & " insert into IvPos1ES (PosCode,Description,AltDescription,Active,iuser)"
                Sql = Sql & " values ('" & txtPOs.Text & "', '" & txtPOs.Text & "','',1,'" & FrmLogin.user & "')"
                Dim sqlcom As New SqlCommand(Sql, FrmLogin.objcon.con)
                sqlcom.ExecuteNonQuery()
                Sql = String.Empty
                Sql = " IF not exists ( select WhsCode from IvWhs1ES where WhsCode='" & txtWHS.Text & "')"
                Sql = Sql & " insert into IvWhs1ES (WhsCode,Description,AltDescription,Active,WhsGroupCode,transferpct,iuser)"
                Sql = Sql & " values ('" & txtWHS.Text & "', '" & txtWHS.Text & "', '',1,'Misc',0,'" & FrmLogin.user & "')"
                sqlcom = New SqlCommand(Sql, FrmLogin.objcon.con)
                sqlcom.ExecuteNonQuery()
                Return True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Public Sub Search() Implements Procedures.Search
        Exit Sub
    End Sub
    Private Sub BtnGenerate_Click(sender As System.Object, e As System.EventArgs) Handles BtnGenerate.Click
        lbl.Text = ""
        Try
            If MessageBox.Show("Are you sure you want to generate this POS??", "Pos Generator", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                lbl.Text = "Please wait"
                isGenerate = True
                btnRegenerate.Enabled = False
                BtnGenerate.Enabled = False
                Dim strconnection As String = "Data Source ='" & txtServer.Text & "';Initial Catalog='" & txtDB.Text & "';user ID='" & txtUser.Text & "';password='" & txtPass.Text & "'"
                Dim con As SqlConnection = New SqlConnection(strconnection)
                Dim sqlcom As New SqlCommand("SpRt_InitNewPos", con)
                Dim blnconnectionOpen = ConnStatus(con)
                If Not blnconnectionOpen Then ConnOpen(con)
                sqlcom.ExecuteNonQuery()
                ProgressBarControl1.EditValue = 0
                ProgressBarControl1.Visible = True
                BackgroundWorker1.RunWorkerAsync()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lbl.Text = "Error!"
        End Try
    End Sub
    Public Sub InsertPosWhs()
        Try
            Dim Sql = String.Empty
            Dim strconnection As String = "Data Source ='" & txtServer.Text & "';Initial Catalog='" & txtDB.Text & "';user ID='" & txtUser.Text & "';password='" & txtPass.Text & "'"
            Dim con As SqlConnection = New SqlConnection(strconnection)
            Dim blnconnectionOpen As Boolean = False
            blnconnectionOpen = ConnStatus(con)
            If Not blnconnectionOpen Then ConnOpen(con)
            Sql = " insert into IvPos1ES (PosCode,Description,AltDescription,Active,iuser)"
            Sql = Sql & " values ('" & txtPOs.Text & "', '" & txtPOs.Text & "','',1,'" & FrmLogin.user & "')"
            Dim sqlcom As New SqlCommand(Sql, con)
            sqlcom.ExecuteNonQuery()
            Sql = String.Empty
            Sql = " insert into IvWhs1ES (WhsCode,Description,AltDescription,Active,WhsGroupCode,transferpct,iuser)"
            Sql = Sql & " values ('" & txtWHS.Text & "', '" & txtWHS.Text & "', '',1,'Misc',0,'" & FrmLogin.user & "')"
            sqlcom = New SqlCommand(Sql, con)
            sqlcom.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lbl.Text = "Error!"
        End Try
    End Sub
    Public Sub InsertExportVersion()
        Try
            Dim BoConxString = "Data Source ='" & FrmMainForm.BOServer & "';Initial Catalog='" & FrmMainForm.BODatabase & "';user ID='" & FrmMainForm.BOUser & "';password='" & FrmMainForm.BOPass & "'"
            Dim BoCnx As SqlConnection = New SqlConnection(BoConxString)
            Dim blnconnectionOpen1 = ConnStatus(BoCnx)
            If Not blnconnectionOpen1 Then ConnOpen(BoCnx)
            Dim MaxIaStamp = GetMaxItemsTimeStamp(BoCnx)
            Dim MaxIbStamp = GetMaxItemsBTimeStamp(BoCnx)
            Dim MaxBrandsStamp = GetMaxBrandTimeStamp(BoCnx)
            Dim MaxCatsStamp = GetMaxCatTimeStamp(BoCnx)
            Dim MaxTypesStamp = GetMaxTypesTimeStamp(BoCnx)
            Dim MaxThirdStamp = GetMaxThirdTimeStamp(BoCnx)
            Dim MaxPlStamp = GetMaxPlTimeStamp(FrmMainForm.PriceList, BoCnx)
            Dim SqlString = "Delete From RtExportHist where PosCode = '" & txtPOs.Text & "'"
            Dim Sqlcom As New SqlCommand(SqlString, FrmLogin.objcon.con)
            If FrmLogin.objcon.con.State = ConnectionState.Closed Then
                FrmLogin.objcon.con.Open()
            End If
            Sqlcom.ExecuteNonQuery()
            SqlString = " insert into RtExportHist (PosCode,ThirdPartyVersion,ItemsVersion,BrandsVersion,TypesVersion,CategoriesVersion,PriceListVersion,ItemsBVersion) values('" & txtPOs.Text & "',"
            SqlString = SqlString & "'" & MaxThirdStamp & "','" & MaxIaStamp & "','" & MaxBrandsStamp & "','" & MaxTypesStamp & "','" & MaxCatsStamp & "','" & MaxPlStamp & "','" & MaxIbStamp & "')"
            Sqlcom = New SqlCommand(SqlString, FrmLogin.objcon.con)
            If FrmLogin.objcon.con.State = ConnectionState.Closed Then
                FrmLogin.objcon.con.Open()
            End If
            Sqlcom.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lbl.Text = "Error!"
        End Try
    End Sub
    Public Sub InsertCategories()
        Try
            Dim ClsCategory As New ClsCategory
            Dim BoConxString = "Data Source ='" & FrmMainForm.BOServer & "';Initial Catalog='" & FrmMainForm.BODatabase & "';user ID='" & FrmMainForm.BOUser & "';password='" & FrmMainForm.BOPass & "'"
            Dim BoCnx As SqlConnection = New SqlConnection(BoConxString)
            Dim blnconnectionOpen1 = ConnStatus(BoCnx)
            If Not blnconnectionOpen1 Then ConnOpen(BoCnx)
            Dim DtCategories = ClsCategory.InitNewCategories(BoCnx)
            If DtCategories.Rows.Count = 0 Then Exit Sub

            Dim strconnection As String = "Data Source ='" & txtServer.Text & "';Initial Catalog='" & txtDB.Text & "';user ID='" & txtUser.Text & "';password='" & txtPass.Text & "'; Connection TimeOut = 0"
            Dim con As SqlConnection = New SqlConnection(strconnection)
            blnconnectionOpen1 = ConnStatus(con)
            If Not blnconnectionOpen1 Then ConnOpen(con)
            Dim transaction As SqlTransaction = Nothing

            Dim transcommand As SqlCommand = con.CreateCommand()
            transaction = con.BeginTransaction("SampleTransaction")
            Dim bulkcopy As New SqlBulkCopy(con, SqlBulkCopyOptions.Default, transaction)
            bulkcopy.DestinationTableName = "IvCategory1Es"
            transcommand.Connection = con
            Try
                For Each i As DataColumn In DtCategories.Columns
                    bulkcopy.ColumnMappings.Add(i.ColumnName, i.ColumnName)
                Next
                bulkcopy.WriteToServer(DtCategories)
                transaction.Commit()
                DtCategories.Dispose()
                DtCategories = Nothing
                Utilities.WriteToText("InitNewCategories: In POS: " & txtPOs.Text, "Successfully Inserted")
            Catch ex As Exception
                Utilities.WriteToText("InitNewCategories: In POS: " & txtPOs.Text & " Commit Type Failed Due To : ", ex.GetType().ToString)
                Utilities.WriteToText("InitNewCategories: In POS: " & txtPOs.Text & " Commit Message Failed Due To : ", ex.Message)
                Try
                    transaction.Rollback()
                Catch ex2 As Exception
                    Utilities.WriteToText("InitNewCategories: In POS: " & txtPOs.Text & " Rollback Type Failed Due To : ", ex2.GetType().ToString)
                    Utilities.WriteToText("InitNewCategories: In POS: " & txtPOs.Text & " Rollback Message Failed Due To : ", ex2.Message)
                End Try
            End Try
        Catch ex As Exception
            Utilities.WriteToText("InitNewCategories:  In POS: " & txtPOs.Text & " Failed Due to ", ex.Message)
        End Try
    End Sub
    Public Sub InsertTypes()
        Try
            Dim ClsType As New ClsType
            Dim BoConxString = "Data Source ='" & FrmMainForm.BOServer & "';Initial Catalog='" & FrmMainForm.BODatabase & "';user ID='" & FrmMainForm.BOUser & "';password='" & FrmMainForm.BOPass & "'"
            Dim BoCnx As SqlConnection = New SqlConnection(BoConxString)
            Dim blnconnectionOpen1 = ConnStatus(BoCnx)
            If Not blnconnectionOpen1 Then ConnOpen(BoCnx)
            Dim DtTypes = ClsType.InitNewTypes(BoCnx)
            If DtTypes.Rows.Count = 0 Then Exit Sub

            Dim strconnection As String = "Data Source ='" & txtServer.Text & "';Initial Catalog='" & txtDB.Text & "';user ID='" & txtUser.Text & "';password='" & txtPass.Text & "'; Connection TimeOut = 0"
            Dim con As SqlConnection = New SqlConnection(strconnection)
            blnconnectionOpen1 = ConnStatus(con)
            If Not blnconnectionOpen1 Then ConnOpen(con)
            Dim transaction As SqlTransaction = Nothing

            Dim transcommand As SqlCommand = con.CreateCommand()
            transaction = con.BeginTransaction("SampleTransaction")
            Dim bulkcopy As New SqlBulkCopy(con, SqlBulkCopyOptions.Default, transaction)
            bulkcopy.DestinationTableName = "IvType1ES"
            transcommand.Connection = con
            Try
                For Each i As DataColumn In DtTypes.Columns
                    bulkcopy.ColumnMappings.Add(i.ColumnName, i.ColumnName)
                Next
                bulkcopy.WriteToServer(DtTypes)
                transaction.Commit()
                DtTypes.Dispose()
                DtTypes = Nothing
                Utilities.WriteToText("InitNewTypes: In POS: " & txtPOs.Text, "Successfully Inserted")
            Catch ex As Exception
                Utilities.WriteToText("InitNewTypes: In POS: " & txtPOs.Text & " Commit Type Failed Due To : ", ex.GetType().ToString)
                Utilities.WriteToText("InitNewTypes: In POS: " & txtPOs.Text & " Commit Message Failed Due To : ", ex.Message)
                Try
                    transaction.Rollback()
                Catch ex2 As Exception
                    Utilities.WriteToText("InitNewTypes: In POS: " & txtPOs.Text & " Rollback Type Failed Due To : ", ex2.GetType().ToString)
                    Utilities.WriteToText("InitNewTypes: In POS: " & txtPOs.Text & " Rollback Message Failed Due To : ", ex2.Message)
                End Try
            End Try
        Catch ex As Exception
            Utilities.WriteToText("InitNewTypes: In POS: " & txtPOs.Text & " Failed Due to ", ex.Message)
        End Try
    End Sub
    Public Sub InsertBrands()
        Try
            Dim ClsBrand As New ClsBrand
            Dim BoConxString = "Data Source ='" & FrmMainForm.BOServer & "';Initial Catalog='" & FrmMainForm.BODatabase & "';user ID='" & FrmMainForm.BOUser & "';password='" & FrmMainForm.BOPass & "'"
            Dim BoCnx As SqlConnection = New SqlConnection(BoConxString)
            Dim blnconnectionOpen1 = ConnStatus(BoCnx)
            If Not blnconnectionOpen1 Then ConnOpen(BoCnx)
            Dim DtBrands = ClsBrand.InitNewBrands(BoCnx)
            If DtBrands.Rows.Count = 0 Then Exit Sub
            Dim strconnection As String = "Data Source ='" & txtServer.Text & "';Initial Catalog='" & txtDB.Text & "';user ID='" & txtUser.Text & "';password='" & txtPass.Text & "'; Connection TimeOut = 0"
            Dim con As SqlConnection = New SqlConnection(strconnection)
            blnconnectionOpen1 = ConnStatus(con)
            If Not blnconnectionOpen1 Then ConnOpen(con)
            Dim transaction As SqlTransaction = Nothing

            Dim transcommand As SqlCommand = con.CreateCommand()
            transaction = con.BeginTransaction("SampleTransaction")
            Dim bulkcopy As New SqlBulkCopy(con, SqlBulkCopyOptions.Default, transaction)
            bulkcopy.DestinationTableName = "IvBrand1ES"
            transcommand.Connection = con
            Try
                For Each i As DataColumn In DtBrands.Columns
                    bulkcopy.ColumnMappings.Add(i.ColumnName, i.ColumnName)
                Next
                bulkcopy.WriteToServer(DtBrands)
                transaction.Commit()
                DtBrands.Dispose()
                DtBrands = Nothing
                Utilities.WriteToText("InitNewBrands: In POS: " & txtPOs.Text, "Successfully Inserted")
            Catch ex As Exception
                Utilities.WriteToText("InitNewBrands: In POS: " & txtPOs.Text & " Commit Type Failed Due To : ", ex.GetType().ToString)
                Utilities.WriteToText("InitNewBrands: In POS: " & txtPOs.Text & " Commit Message Failed Due To : ", ex.Message)
                Try
                    transaction.Rollback()
                Catch ex2 As Exception
                    Utilities.WriteToText("InitNewBrands: In POS: " & txtPOs.Text & " Rollback Type Failed Due To : ", ex2.GetType().ToString)
                    Utilities.WriteToText("InitNewBrands: In POS: " & txtPOs.Text & " Rollback Message Failed Due To : ", ex2.Message)
                End Try
            End Try
        Catch ex As Exception
            Utilities.WriteToText("InitNewBrands: In POS: " & txtPOs.Text & " Failed Due to ", ex.Message)
        End Try
    End Sub
    Public Sub SendRsTableParam()
        Try
            Dim sqlcomm As New SqlCommand("select * from RsTableParam,IvParameter1ES", FrmLogin.objcon.con)
            Dim blnconnectionOpen = ConnStatus(FrmLogin.objcon.con)
            If Not blnconnectionOpen Then ConnOpen(FrmLogin.objcon.con)
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(sqlcomm)
            da.Fill(ds, "RsParameters")
            Dim strconnection As String = "Data Source ='" & txtServer.Text & "';Initial Catalog='" & txtDB.Text & "';user ID='" & txtUser.Text & "';password='" & txtPass.Text & "'"
            Dim con As SqlConnection = New SqlConnection(strconnection)
            blnconnectionOpen = ConnStatus(con)
            If Not blnconnectionOpen Then ConnOpen(con)
            sqlcomm = New SqlCommand("SpRs_ParametersInsert", con)
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@CurCode", ds.Tables("RsParameters").Rows(0).Item("CurCode"))
            sqlcomm.Parameters.AddWithValue("@InvTypeID", ds.Tables("RsParameters").Rows(0).Item("InvTypeID"))
            sqlcomm.Parameters.AddWithValue("@InvTypeName", ds.Tables("RsParameters").Rows(0).Item("InvTypeName"))
            sqlcomm.Parameters.AddWithValue("@OrderTypeID", ds.Tables("RsParameters").Rows(0).Item("OrderTypeID"))
            sqlcomm.Parameters.AddWithValue("@OrderTypeSequence", ds.Tables("RsParameters").Rows(0).Item("OrderTypeSequence"))
            sqlcomm.Parameters.AddWithValue("@TransType", ds.Tables("RsParameters").Rows(0).Item("TransType"))
            sqlcomm.Parameters.AddWithValue("@Acccode", ds.Tables("RsParameters").Rows(0).Item("AccCode"))
            sqlcomm.Parameters.AddWithValue("@CheckOffers", ds.Tables("RsParameters").Rows(0).Item("CheckOffers"))
            sqlcomm.Parameters.AddWithValue("@UseSize", ds.Tables("RsParameters").Rows(0).Item("UseSize"))
            sqlcomm.Parameters.AddWithValue("@UseColor", ds.Tables("RsParameters").Rows(0).Item("UseColor"))
            sqlcomm.Parameters.AddWithValue("@UsePriceList", ds.Tables("RsParameters").Rows(0).Item("UsePriceList"))
            sqlcomm.Parameters.AddWithValue("@PriceList", ds.Tables("RsParameters").Rows(0).Item("PriceList"))
            sqlcomm.Parameters.AddWithValue("@UPDecimals", CInt(ds.Tables("RsParameters").Rows(0).Item("UPDecimals")))
            sqlcomm.Parameters.AddWithValue("@QtyDecimals", CInt(ds.Tables("RsParameters").Rows(0).Item("QtyDecimals")))
            sqlcomm.Parameters.AddWithValue("@HideFamily", ds.Tables("RsParameters").Rows(0).Item("HideFamily"))
            sqlcomm.Parameters.AddWithValue("@DefaultMOP", ds.Tables("RsParameters").Rows(0).Item("DefaultMop"))
            sqlcomm.Parameters.AddWithValue("@Rounding", ds.Tables("RsParameters").Rows(0).Item("Rounding"))
            sqlcomm.Parameters.AddWithValue("@RoundingMOP", ds.Tables("RsParameters").Rows(0).Item("RoundingMOP"))
            sqlcomm.Parameters.AddWithValue("@NetRounding", ds.Tables("RsParameters").Rows(0).Item("NetRounding"))
            sqlcomm.Parameters.AddWithValue("@PrintAfterSave", ds.Tables("RsParameters").Rows(0).Item("PrintAfterSave"))
            sqlcomm.Parameters.AddWithValue("@PrintPreview", ds.Tables("RsParameters").Rows(0).Item("PrintPreview"))
            sqlcomm.Parameters.AddWithValue("@ReturnInvoiceType", ds.Tables("RsParameters").Rows(0).Item("ReturnInvoiceType"))
            sqlcomm.Parameters.AddWithValue("@ReturnInvoiceTypeID", ds.Tables("RsParameters").Rows(0).Item("ReturnInvoiceTypeID"))
            sqlcomm.Parameters.AddWithValue("@GiftReturnDays", ds.Tables("RsParameters").Rows(0).Item("GiftReturnDays"))
            sqlcomm.Parameters.AddWithValue("@DeliveryOrder", ds.Tables("RsParameters").Rows(0).Item("DeliveryOrder"))
            sqlcomm.Parameters.AddWithValue("@SyncEnabled", ds.Tables("RsParameters").Rows(0).Item("SyncEnabled"))
            sqlcomm.Parameters.AddWithValue("@UseDefaultSalesMan", ds.Tables("RsParameters").Rows(0).Item("UseDefaultSalesMan"))
            sqlcomm.Parameters.AddWithValue("@RoundMode", ds.Tables("RsParameters").Rows(0).Item("RoundMode"))
            sqlcomm.Parameters.AddWithValue("@RoundDecimals", ds.Tables("RsParameters").Rows(0).Item("RoundDecimals"))
            sqlcomm.Parameters.AddWithValue("@NbCopies", ds.Tables("RsParameters").Rows(0).Item("NbCopies"))
            blnconnectionOpen = False
            sqlcomm.ExecuteNonQuery()

            sqlcomm = New SqlCommand("Update RsTableParam set RetailVersion='" & ds.Tables("RsParameters").Rows(0).Item("RetailVersion") & "'", con)
            blnconnectionOpen = ConnStatus(con)
            If Not blnconnectionOpen Then ConnOpen(con)
            sqlcomm.ExecuteNonQuery()
            ds.Dispose()
            ds = Nothing
            Utilities.WriteToText("Initparameters In " & txtPOs.Text, " Successfully Updated")
        Catch ex As Exception
            Utilities.WriteToText("Initparameters: In " & txtPOs.Text & " Failed Due To : ", ex.Message)
        End Try
    End Sub
    Public Sub InsertItemControlInWhs()
        Try
            Dim ClsItemA As New ClsItemA
            Dim BoConxString = "Data Source ='" & FrmMainForm.BOServer & "';Initial Catalog='" & FrmMainForm.BODatabase & "';user ID='" & FrmMainForm.BOUser & "';password='" & FrmMainForm.BOPass & "'"
            Dim BoCnx As SqlConnection = New SqlConnection(BoConxString)
            Dim blnconnectionOpen1 = ConnStatus(BoCnx)
            If Not blnconnectionOpen1 Then ConnOpen(BoCnx)
            Dim SqlString = "select distinct '" & txtWHS.Text & "' as 'WhsCode',0 as 'Modified', 0 as 'MinQty', 0 as 'MaxQty', 'False' as 'Blocked', ib.Barcode as 'Barcode' from IvItemB1ES ib join IvItemA1ES ia on ia.ItemAid = ib.ItemAId where ia.AllowSell = 1"
            Dim DtItemControl As New DataTable
            Dim SQlcom As New SqlCommand(SqlString, BoCnx)
            Dim da As New SqlDataAdapter(SQlcom)
            da.Fill(DtItemControl)
            If DtItemControl.Rows.Count = 0 Then Exit Sub

            Dim strconnection As String = "Data Source ='" & txtServer.Text & "';Initial Catalog='" & txtDB.Text & "';user ID='" & txtUser.Text & "';password='" & txtPass.Text & "'; Connection TimeOut = 0"
            Dim con As SqlConnection = New SqlConnection(strconnection)
            blnconnectionOpen1 = ConnStatus(con)
            If Not blnconnectionOpen1 Then ConnOpen(con)
            Dim transaction As SqlTransaction = Nothing
            Dim transcommand As SqlCommand = con.CreateCommand()
            transaction = con.BeginTransaction("SampleTransaction")
            Dim bulkcopy As New SqlBulkCopy(con, SqlBulkCopyOptions.Default, transaction)
            bulkcopy.DestinationTableName = "IvItemControl"
            transcommand.Connection = con
            Try
                For Each i As DataColumn In DtItemControl.Columns
                    bulkcopy.ColumnMappings.Add(i.ColumnName, i.ColumnName)
                Next
                bulkcopy.WriteToServer(DtItemControl)
                transaction.Commit()
                DtItemControl.Dispose()
                DtItemControl = Nothing
                Utilities.WriteToText("InitItemControlWhs: In POS: " & txtPOs.Text, " Successfully Inserted")
            Catch ex As Exception
                Utilities.WriteToText("InitItemControlWhs: In POS: " & txtPOs.Text & " Commit Type Failed Due To : ", ex.GetType().ToString)
                Utilities.WriteToText("InitItemControlWhs: In POS: " & txtPOs.Text & " Commit Message Failed Due To : ", ex.Message)
                Try
                    transaction.Rollback()
                Catch ex2 As Exception
                    Utilities.WriteToText("InitItemControlWhs: In POS: " & txtPOs.Text & " Rollback Type Failed Due To : ", ex2.GetType().ToString)
                    Utilities.WriteToText("InitItemControlWhs: In POS: " & txtPOs.Text & "  Rollback Message Failed Due To : ", ex2.Message)
                End Try
            End Try
        Catch ex As Exception
            lbl.Text = "An Error Happened, please try again later"
            Utilities.WriteToText("InitNewPOS: InsertItemControlWhs: In POS:  " & txtPOs.Text & " Failed Due to ", ex.Message)
        End Try
    End Sub
    Public Sub InsertItemControlInSpecificWHS(ByVal Whs As String)
        Try
            Dim ClsItemA As New ClsItemA
            Dim strconnection1 As String = "Data Source ='" & FrmMainForm.BOServer & "';Initial Catalog='" & FrmMainForm.BODatabase & "';user ID='" & FrmMainForm.BOUser & "';password='" & FrmMainForm.BOPass & "'"
            Dim Bocnx As SqlConnection = New SqlConnection(strconnection1)
            Dim blnconnectionOpen = ConnStatus(Bocnx)
            If Not blnconnectionOpen Then ConnOpen(Bocnx)
            Dim Sqlcom As New SqlCommand("Select * from IvItemControl where WhsCode='" & Whs & "'", Bocnx)
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter(Sqlcom)
            da.Fill(dt)

            If dt.Rows.Count = 0 Then Exit Sub

            Dim strconnection As String = "Data Source ='" & txtServer.Text & "';Initial Catalog='" & txtDB.Text & "';user ID='" & txtUser.Text & "';password='" & txtPass.Text & "'; Connection TimeOut = 0"
            Dim con As SqlConnection = New SqlConnection(strconnection)
            blnconnectionOpen = ConnStatus(con)
            If Not blnconnectionOpen Then ConnOpen(con)
            Dim transaction As SqlTransaction = Nothing
            Dim transcommand As SqlCommand = con.CreateCommand()
            transaction = con.BeginTransaction("SampleTransaction")
            Dim bulkcopy As New SqlBulkCopy(con, SqlBulkCopyOptions.Default, transaction)
            bulkcopy.DestinationTableName = "IvItemControl"
            transcommand.Connection = con
            Try
                For Each i As DataColumn In dt.Columns
                    bulkcopy.ColumnMappings.Add(i.ColumnName, i.ColumnName)
                Next
                bulkcopy.WriteToServer(dt)
                transaction.Commit()
                dt.Dispose()
                dt = Nothing
                Utilities.WriteToText("InitItemControlSpecificWhs: In POS: " & txtPOs.Text, " Successfully Inserted")
            Catch ex As Exception
                Utilities.WriteToText("InitItemControlSpecificWhs: In POS: " & txtPOs.Text & " Commit Type Failed Due To : ", ex.GetType().ToString)
                Utilities.WriteToText("InitItemControlSpecificWhs: In POS: " & txtPOs.Text & " Commit Message Failed Due To : ", ex.Message)
                Try
                    transaction.Rollback()
                Catch ex2 As Exception
                    Utilities.WriteToText("InitItemControlSpecificWhs: In POS: " & txtPOs.Text & " Rollback Type Failed Due To : ", ex2.GetType().ToString)
                    Utilities.WriteToText("InitItemControlSpecificWhs: In POS: " & txtPOs.Text & "  Rollback Message Failed Due To : ", ex2.Message)
                End Try
            End Try
        Catch ex As Exception
            lbl.Text = "An Error Happened, please try again later"
            Utilities.WriteToText("Regeneration: InitItemControlSpecificWhs: In POS: " & txtPOs.Text & " Failed Due to ", ex.Message)
        End Try
    End Sub
    Public Sub InsertItemControlInBo()
        Try
            Dim ClsItemA As New ClsItemA

            Dim strconnection As String = "Data Source ='" & FrmMainForm.BOServer & "';Initial Catalog='" & FrmMainForm.BODatabase & "';user ID='" & FrmMainForm.BOUser & "';password='" & FrmMainForm.BOPass & "'; Connection TimeOut = 0"
            Dim con As SqlConnection = New SqlConnection(strconnection)
            Dim blnconnectionOpen As Boolean = False
            blnconnectionOpen = ConnStatus(con)
            If Not blnconnectionOpen Then ConnOpen(con)

            Dim sqlcom As New SqlCommand("delete from ivitemcontrol where WhsCode ='" & txtWHS.Text & "'", con)
            sqlcom.ExecuteNonQuery()
            Dim SqlString = "select distinct '" & txtWHS.Text & "' as 'WhsCode',0 as 'Modified', 0 as 'MinQty', 0 as 'MaxQty', 'False' as 'Blocked', ib.Barcode as 'Barcode' from IvItemB1ES ib join IvItemA1ES ia on ia.ItemAid = ib.ItemAId where ia.AllowSell = 1"
            Dim DtItemControl As New DataTable
            sqlcom = New SqlCommand(SqlString, con)
            Dim da As New SqlDataAdapter(sqlcom)
            da.Fill(DtItemControl)
            If DtItemControl.Rows.Count = 0 Then Exit Sub
            Dim transaction As SqlTransaction = Nothing
            blnconnectionOpen = ConnStatus(con)
            If Not blnconnectionOpen Then ConnOpen(con)
            Dim transcommand As SqlCommand = con.CreateCommand()
            transaction = con.BeginTransaction("SampleTransaction")
            Dim bulkcopy As New SqlBulkCopy(con, SqlBulkCopyOptions.Default, transaction)
            bulkcopy.DestinationTableName = "IvItemControl"
            transcommand.Connection = con
            Try
                For Each i As DataColumn In DtItemControl.Columns
                    bulkcopy.ColumnMappings.Add(i.ColumnName, i.ColumnName)
                Next
                bulkcopy.WriteToServer(DtItemControl)
                transaction.Commit()
                DtItemControl.Dispose()
                DtItemControl = Nothing
                Utilities.WriteToText("InitItemControlInBO: From POS:  " & txtPOs.Text, " Successfully Inserted")
            Catch ex As Exception
                Utilities.WriteToText("InitItemControlInBO: From POS:  " & txtPOs.Text & " Commit Type Failed Due To : ", ex.GetType().ToString)
                Utilities.WriteToText("InitItemControlInBO: From POS:  " & txtPOs.Text & " Commit Message Failed Due To : ", ex.Message)
                Try
                    transaction.Rollback()
                Catch ex2 As Exception
                    Utilities.WriteToText("InitItemControlInBO: From POS:  " & txtPOs.Text & " Rollback Type Failed Due To : ", ex2.GetType().ToString)
                    Utilities.WriteToText("InitItemControlInBO: From POS:  " & txtPOs.Text & "  Rollback Message Failed Due To : ", ex2.Message)
                End Try
            End Try
        Catch ex As Exception
            lbl.Text = "An Error Happened, please try again later"
            Utilities.WriteToText("InitItemControlInBO: From POS:  " & txtPOs.Text & " Failed Due to ", ex.Message)
        End Try
    End Sub
    Public Sub InsertItemsA()
        Try
            Dim ClsItemA As New ClsItemA
            Dim BoConxString = "Data Source ='" & FrmMainForm.BOServer & "';Initial Catalog='" & FrmMainForm.BODatabase & "';user ID='" & FrmMainForm.BOUser & "';password='" & FrmMainForm.BOPass & "'"
            Dim BoCnx As SqlConnection = New SqlConnection(BoConxString)
            Dim blnconnectionOpen1 = ConnStatus(BoCnx)
            If Not blnconnectionOpen1 Then ConnOpen(BoCnx)

            Dim DtNewItems = ClsItemA.BoInitNewPosItemsA(BoCnx)
            If DtNewItems.Rows.Count = 0 Then Exit Sub
            Dim strconnection As String = "Data Source ='" & txtServer.Text & "';Initial Catalog='" & txtDB.Text & "';user ID='" & txtUser.Text & "';password='" & txtPass.Text & "'; Connection TimeOut = 0"
            Dim con As SqlConnection = New SqlConnection(strconnection)
            blnconnectionOpen1 = ConnStatus(con)
            If Not blnconnectionOpen1 Then ConnOpen(con)
            Dim transaction As SqlTransaction = Nothing

            Dim transcommand As SqlCommand = con.CreateCommand()
            transaction = con.BeginTransaction("SampleTransaction")
            Dim bulkcopy As New SqlBulkCopy(con, SqlBulkCopyOptions.Default, transaction)
            bulkcopy.DestinationTableName = "IvItemA1ES"
            transcommand.Connection = con
            Try
                For Each i As DataColumn In DtNewItems.Columns
                    bulkcopy.ColumnMappings.Add(i.ColumnName, i.ColumnName)
                Next
                bulkcopy.WriteToServer(DtNewItems)
                transaction.Commit()
                DtNewItems.Dispose()
                DtNewItems = Nothing
                Utilities.WriteToText("InitNewItems In POS: " & txtPOs.Text & ": ", "Successfully Inserted")
            Catch ex As Exception
                Utilities.WriteToText("InitNewItems In POS: " & txtPOs.Text & " Commit Type Failed Due To : ", ex.GetType().ToString)
                Utilities.WriteToText("InitNewItems In POS: " & txtPOs.Text & " Commit Message Failed Due To : ", ex.Message)
                Try
                    transaction.Rollback()
                Catch ex2 As Exception
                    Utilities.WriteToText("InitNewItems In POS: " & txtPOs.Text & " Rollback Type Failed Due To : ", ex2.GetType().ToString)
                    Utilities.WriteToText("InitNewItems In POS: " & txtPOs.Text & " Rollback Message Failed Due To : ", ex2.Message)
                End Try
            End Try
        Catch ex As Exception
            Utilities.WriteToText("InitNewItems: In POS: " & txtPOs.Text & " Failed Due to ", ex.Message)
        End Try
    End Sub
    Public Sub InsertItemsB()
        Try
            Dim ClsItemA As New ClsItemA
            Dim BoConxString = "Data Source ='" & FrmMainForm.BOServer & "';Initial Catalog='" & FrmMainForm.BODatabase & "';user ID='" & FrmMainForm.BOUser & "';password='" & FrmMainForm.BOPass & "'"
            Dim BoCnx As SqlConnection = New SqlConnection(BoConxString)
            Dim blnconnectionOpen1 = ConnStatus(BoCnx)
            If Not blnconnectionOpen1 Then ConnOpen(BoCnx)
            Dim DtNewItems = ClsItemA.BoInitNewPosItemsB(BoCnx)

            If DtNewItems.Rows.Count = 0 Then Exit Sub

            Dim strconnection As String = "Data Source ='" & txtServer.Text & "';Initial Catalog='" & txtDB.Text & "';user ID='" & txtUser.Text & "';password='" & txtPass.Text & "'; Connection TimeOut = 0"
            Dim con As SqlConnection = New SqlConnection(strconnection)
            blnconnectionOpen1 = ConnStatus(con)
            If Not blnconnectionOpen1 Then ConnOpen(con)
            Dim transaction As SqlTransaction = Nothing

            Dim transcommand As SqlCommand = con.CreateCommand()
            transaction = con.BeginTransaction("SampleTransaction")
            Dim bulkcopy As New SqlBulkCopy(con, SqlBulkCopyOptions.Default, transaction)
            bulkcopy.DestinationTableName = "IvItemB1ES"
            transcommand.Connection = con
            Try
                For Each i As DataColumn In DtNewItems.Columns
                    bulkcopy.ColumnMappings.Add(i.ColumnName, i.ColumnName)
                Next
                bulkcopy.WriteToServer(DtNewItems)
                transaction.Commit()
                DtNewItems.Dispose()
                DtNewItems = Nothing
                Utilities.WriteToText("InitNewItems In POS: " & txtPOs.Text & ": ", "Successfully Inserted")
            Catch ex As Exception
                Utilities.WriteToText("InitNewItems In POS: " & txtPOs.Text & " Commit Type Failed Due To : ", ex.GetType().ToString)
                Utilities.WriteToText("InitNewItems In POS: " & txtPOs.Text & " Commit Message Failed Due To : ", ex.Message)
                Try
                    transaction.Rollback()
                Catch ex2 As Exception
                    Utilities.WriteToText("InitNewItems In POS: " & txtPOs.Text & " Rollback Type Failed Due To : ", ex2.GetType().ToString)
                    Utilities.WriteToText("InitNewItems In POS: " & txtPOs.Text & " Rollback Message Failed Due To : ", ex2.Message)
                End Try
            End Try
        Catch ex As Exception
            Utilities.WriteToText("InitNewItems: In POS: " & txtPOs.Text & " Failed Due to ", ex.Message)
        End Try
    End Sub
    Public Sub GetChangedPriceList()
        Try
            Dim clsPriceList As New ClsPriceList
            Dim BoConxString = "Data Source ='" & FrmMainForm.BOServer & "';Initial Catalog='" & FrmMainForm.BODatabase & "';user ID='" & FrmMainForm.BOUser & "';password='" & FrmMainForm.BOPass & "'"
            Dim BoCnx As SqlConnection = New SqlConnection(BoConxString)
            Dim blnconnectionOpen1 = ConnStatus(BoCnx)
            If Not blnconnectionOpen1 Then ConnOpen(BoCnx)
            Dim DtPriceList = clsPriceList.BoInitNewPOSPriceList(FrmMainForm.PriceList, BoCnx)
            If DtPriceList.Rows.Count = 0 Then
                Exit Sub
            End If
            Dim strconnection As String = "Data Source ='" & txtServer.Text & "';Initial Catalog='" & txtDB.Text & "';user ID='" & txtUser.Text & "';password='" & txtPass.Text & "'; Connection TimeOut = 0"
            Dim con As SqlConnection = New SqlConnection(strconnection)
            blnconnectionOpen1 = ConnStatus(con)
            If Not blnconnectionOpen1 Then ConnOpen(con)
            Dim transaction As SqlTransaction = Nothing

            Dim transcommand As SqlCommand = con.CreateCommand()
            transaction = con.BeginTransaction("SampleTransaction")
            Dim bulkcopy As New SqlBulkCopy(con, SqlBulkCopyOptions.Default, transaction)
            bulkcopy.DestinationTableName = "IvPriceListB1ES"
            transcommand.Connection = con
            Try
                For Each i As DataColumn In DtPriceList.Columns
                    bulkcopy.ColumnMappings.Add(i.ColumnName, i.ColumnName)
                Next
                bulkcopy.WriteToServer(DtPriceList)
                transaction.Commit()
                DtPriceList.Dispose()
                DtPriceList = Nothing
                Utilities.WriteToText("InitNewPriceList: ", " PriceList was successfully sent to POS: " & txtPOs.Text)
            Catch ex As Exception
                Utilities.WriteToText("InitNewPriceList In POS: " & txtPOs.Text & " Commit Type Failed Due To : ", ex.GetType().ToString)
                Utilities.WriteToText("InitNewPriceList In POS: " & txtPOs.Text & " Commit Message Failed Due To : ", ex.Message)
                Try
                    transaction.Rollback()
                Catch ex2 As Exception
                    Utilities.WriteToText("InitNewPriceList In POS: " & txtPOs.Text & " Rollback Type Failed Due To : ", ex2.GetType().ToString)
                    Utilities.WriteToText("InitNewPriceList In POS: " & txtPOs.Text & " Rollback Message Failed Due To : ", ex2.Message)
                End Try
            End Try
        Catch ex As Exception
            lbl.Text = "An Error Happened, please try again later"
            Utilities.WriteToText("InitNewPriceList:   In POS: " & txtPOs.Text & " Failed Due To: ", ex.Message)
        End Try
    End Sub
    Public Sub InsertCustomersA()
        Try
            Dim ClsThirdParty As New ClsThirdParty
            Dim BoConxString = "Data Source ='" & FrmMainForm.BOServer & "';Initial Catalog='" & FrmMainForm.BODatabase & "';user ID='" & FrmMainForm.BOUser & "';password='" & FrmMainForm.BOPass & "'"
            Dim BoCnx As SqlConnection = New SqlConnection(BoConxString)
            Dim DtNewCustomers = ClsThirdParty.BoInitNewPosCustomersA(BoCnx)

            Dim strconnection As String = "Data Source ='" & txtServer.Text & "';Initial Catalog='" & txtDB.Text & "';user ID='" & txtUser.Text & "';password='" & txtPass.Text & "'; Connection TimeOut = 0"
            Dim con As SqlConnection = New SqlConnection(strconnection)
            Dim blnconnectionOpen As Boolean = False
            If DtNewCustomers.Rows.Count = 0 Then Exit Sub

            Dim transaction As SqlTransaction = Nothing
            blnconnectionOpen = ConnStatus(con)
            If Not blnconnectionOpen Then ConnOpen(con)
            Dim transcommand As SqlCommand = con.CreateCommand()
            transaction = con.BeginTransaction("SampleTransaction")
            Dim bulkcopy As New SqlBulkCopy(con, SqlBulkCopyOptions.Default, transaction)
            bulkcopy.DestinationTableName = "SacThirdParty"
            transcommand.Connection = con
            Try
                For Each i As DataColumn In DtNewCustomers.Columns
                    bulkcopy.ColumnMappings.Add(i.ColumnName, i.ColumnName)
                Next
                bulkcopy.WriteToServer(DtNewCustomers)
                transaction.Commit()
                DtNewCustomers.Dispose()
                DtNewCustomers = Nothing
                Utilities.WriteToText("InitCustomer In POS: " & txtPOs.Text & ": ", "Successfully Inserted")
            Catch ex As Exception
                Utilities.WriteToText("InitCustomer In POS: " & txtPOs.Text & " Commit Type Failed Due To : ", ex.GetType().ToString)
                Utilities.WriteToText("InitCustomer In POS: " & txtPOs.Text & " Commit Message Failed Due To : ", ex.Message)
                Try
                    transaction.Rollback()
                Catch ex2 As Exception
                    Utilities.WriteToText("InitCustomer In POS: " & txtPOs.Text & " Rollback Type Failed Due To : ", ex2.GetType().ToString)
                    Utilities.WriteToText("InitCustomer In POS: " & txtPOs.Text & " Rollback Message Failed Due To : ", ex2.Message)
                End Try
            End Try
        Catch ex As Exception
            Utilities.WriteToText("InitCustomer In POS: " & txtPOs.Text & "  Failed Due To: ", ex.Message)
            lbl.Text = "An Error Happened, please try again later"
        End Try
    End Sub
    Public Sub InsertCustomersB()
        Try
            Dim ClsThirdParty As New ClsThirdParty
            Dim BoConxString = "Data Source ='" & FrmMainForm.BOServer & "';Initial Catalog='" & FrmMainForm.BODatabase & "';user ID='" & FrmMainForm.BOUser & "';password='" & FrmMainForm.BOPass & "'"
            Dim BoCnx As SqlConnection = New SqlConnection(BoConxString)
            Dim DtNewCustomers = ClsThirdParty.BoInitNewPosCustomersB(BoCnx)

            Dim strconnection As String = "Data Source ='" & txtServer.Text & "';Initial Catalog='" & txtDB.Text & "';user ID='" & txtUser.Text & "';password='" & txtPass.Text & "'; Connection TimeOut = 0"
            Dim con As SqlConnection = New SqlConnection(strconnection)
            Dim blnconnectionOpen As Boolean = False
            If DtNewCustomers.Rows.Count = 0 Then Exit Sub

            Dim transaction As SqlTransaction = Nothing
            blnconnectionOpen = ConnStatus(con)
            If Not blnconnectionOpen Then ConnOpen(con)
            Dim transcommand As SqlCommand = con.CreateCommand()
            transaction = con.BeginTransaction("SampleTransaction")
            Dim bulkcopy As New SqlBulkCopy(con, SqlBulkCopyOptions.Default, transaction)
            bulkcopy.DestinationTableName = "SacThirdExtra1Es"
            transcommand.Connection = con
            Try
                For Each i As DataColumn In DtNewCustomers.Columns
                    bulkcopy.ColumnMappings.Add(i.ColumnName, i.ColumnName)
                Next
                bulkcopy.WriteToServer(DtNewCustomers)
                transaction.Commit()
                DtNewCustomers.Dispose()
                DtNewCustomers = Nothing
                Utilities.WriteToText("InitCustomer In POS: " & txtPOs.Text & ": ", "Successfully Inserted")
            Catch ex As Exception
                Utilities.WriteToText("InitCustomer In POS: " & txtPOs.Text & " Commit Type Failed Due To : ", ex.GetType().ToString)
                Utilities.WriteToText("InitCustomer In POS: " & txtPOs.Text & " Commit Message Failed Due To : ", ex.Message)
                Try
                    transaction.Rollback()
                Catch ex2 As Exception
                    Utilities.WriteToText("InitCustomer In POS: " & txtPOs.Text & " Rollback Type Failed Due To : ", ex2.GetType().ToString)
                    Utilities.WriteToText("InitCustomer In POS: " & txtPOs.Text & " Rollback Message Failed Due To : ", ex2.Message)
                End Try
            End Try
        Catch ex As Exception
            Utilities.WriteToText("InitCustomer In POS: " & txtPOs.Text & "  Failed Due To: ", ex.Message)
            lbl.Text = "An Error Happened, please try again later"
        End Try
    End Sub
    Public Sub SendSequence(ByVal WhsCnx As SqlConnection)
        Try
            Dim strconnection As String = "Data Source ='" & FrmMainForm.BOServer & "';Initial Catalog='" & FrmMainForm.BODatabase & "';user ID='" & FrmMainForm.BOUser & "';password='" & FrmMainForm.BOPass & "'"
            Dim con As SqlConnection = New SqlConnection(strconnection)
            Dim blnconnectionOpen As Boolean = False
            blnconnectionOpen = ConnStatus(con)
            If Not blnconnectionOpen Then ConnOpen(con)
            Dim sqlcom As New SqlCommand("Select ToPost,TransCode from IvInvoiceType1ES where InvTypeID = " & FrmMainForm.SalesInvoice, con)
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter(sqlcom)
            da.Fill(dt)
            Dim SalesInvoiceToPost = IIf(IsDBNull(dt.Rows(0).Item("ToPost")) Or IsNothing(dt.Rows(0).Item("ToPost")), 0, dt.Rows(0).Item("ToPost"))
            Dim SalesInvoiceTransCode = IIf(IsDBNull(dt.Rows(0).Item("TransCode")) Or IsNothing(dt.Rows(0).Item("TransCode")), "", dt.Rows(0).Item("TransCode"))

            sqlcom = New SqlCommand("Select ToPost,TransCode from IvInvoiceType1ES where InvTypeID = " & FrmMainForm.SalesReturn, con)
            dt.Clear()
            da = New SqlDataAdapter(sqlcom)
            da.Fill(dt)
            Dim SalesReturnToPost = IIf(IsDBNull(dt.Rows(0).Item("ToPost")) Or IsNothing(dt.Rows(0).Item("ToPost")), 0, dt.Rows(0).Item("ToPost"))
            Dim SalesReturnTransCode = IIf(IsDBNull(dt.Rows(0).Item("TransCode")) Or IsNothing(dt.Rows(0).Item("TransCode")), "", dt.Rows(0).Item("TransCode"))

            If SalesInvoiceToPost = 1 Then
                If SalesReturnToPost = 1 Then
                    If SalesReturnTransCode = SalesInvoiceTransCode Then
                        Dim SqlQuery = "Select Max(OperID) from IvOperationC1ES where (InvtypeID = " & FrmMainForm.SalesReturn
                        SqlQuery = SqlQuery & " Or InvTypeID = " & FrmMainForm.SalesInvoice & ")"
                        SqlQuery = SqlQuery & " and WhsCode ='" & txtWHS.Text & "'"
                        Dim SqlC As New SqlCommand(SqlQuery, FrmLogin.objcon.con)
                        Dim SalesIRSequence = IIf(IsDBNull(SqlC.ExecuteScalar) Or IsNothing(SqlC.ExecuteScalar), Today.Year & "000000", SqlC.ExecuteScalar)
                        SqlC = New SqlCommand("select sequence from sacSequence where seqcode='" & SalesReturnTransCode & "' and seqyear=" & Today.Year, WhsCnx)
                        If WhsCnx.State = ConnectionState.Closed Then
                            WhsCnx.Open()
                        End If
                        SqlQuery = ""
                        If IsDBNull(SqlC.ExecuteScalar) Or IsNothing(SqlC.ExecuteScalar) Then
                            SqlQuery = " Insert into SacSequence values ('" & SalesReturnTransCode & "'," & Today.Year
                            SqlQuery = SqlQuery & ",1," & SalesIRSequence & ")"
                        Else
                            SqlQuery = " update SacSequence set Sequence = " & SalesIRSequence & " where SeqCode='" & SalesReturnTransCode & "'"
                            SqlQuery = SqlQuery & " and seqyear = " & Today.Year
                        End If
                        SqlC = New SqlCommand(SqlQuery, WhsCnx)
                        If WhsCnx.State = ConnectionState.Closed Then
                            WhsCnx.Open()
                        End If
                        SqlC.ExecuteNonQuery()
                    Else
                        Dim SqlQuery = "Select Max(OperID) from IvOperationC1ES where InvtypeID = " & FrmMainForm.SalesReturn
                        SqlQuery = SqlQuery & " and WhsCode ='" & txtWHS.Text & "'"
                        Dim SqlC As New SqlCommand(SqlQuery, FrmLogin.objcon.con)
                        Dim SalesReturnSequence = IIf(IsDBNull(SqlC.ExecuteScalar) Or IsNothing(SqlC.ExecuteScalar), Today.Year & "000000", SqlC.ExecuteScalar)
                        SqlC = New SqlCommand("select sequence from sacSequence where seqcode='" & SalesReturnTransCode & "' and seqyear=" & Today.Year, WhsCnx)
                        If WhsCnx.State = ConnectionState.Closed Then
                            WhsCnx.Open()
                        End If
                        SqlQuery = ""
                        If IsDBNull(SqlC.ExecuteScalar) Or IsNothing(SqlC.ExecuteScalar) Then
                            SqlQuery = " Insert into SacSequence values ('" & SalesReturnTransCode & "'," & Today.Year
                            SqlQuery = SqlQuery & ",1," & SalesReturnSequence & ")"
                        Else
                            SqlQuery = " update SacSequence set Sequence = " & SalesReturnSequence & " where SeqCode='" & SalesReturnTransCode & "'"
                            SqlQuery = SqlQuery & " and seqyear = " & Today.Year
                        End If
                        SqlC = New SqlCommand(SqlQuery, WhsCnx)
                        If WhsCnx.State = ConnectionState.Closed Then
                            WhsCnx.Open()
                        End If
                        SqlC.ExecuteNonQuery()
                        SqlQuery = ""
                        SqlQuery = "Select Max(OperID) from IvOperationC1ES where InvtypeID = " & FrmMainForm.SalesInvoice
                        SqlQuery = SqlQuery & " and WhsCode ='" & txtWHS.Text & "'"
                        SqlC = New SqlCommand(SqlQuery, FrmLogin.objcon.con)
                        Dim SalesInvoiceSequence = IIf(IsDBNull(SqlC.ExecuteScalar) Or IsNothing(SqlC.ExecuteScalar), Today.Year & "000000", SqlC.ExecuteScalar)
                        SqlC = New SqlCommand("select sequence from sacSequence where seqcode='" & SalesInvoiceTransCode & "' and seqyear=" & Today.Year, WhsCnx)
                        If WhsCnx.State = ConnectionState.Closed Then
                            WhsCnx.Open()
                        End If
                        SqlQuery = ""
                        If IsDBNull(SqlC.ExecuteScalar) Or IsNothing(SqlC.ExecuteScalar) Then
                            SqlQuery = " Insert into SacSequence values ('" & SalesInvoiceTransCode & "'," & Today.Year
                            SqlQuery = SqlQuery & ",1," & SalesInvoiceSequence & ")"
                        Else
                            SqlQuery = " update SacSequence set Sequence = " & SalesInvoiceSequence & " where SeqCode='" & SalesInvoiceTransCode & "'"
                            SqlQuery = SqlQuery & " and seqyear = " & Today.Year
                        End If
                        SqlC = New SqlCommand(SqlQuery, WhsCnx)
                        If WhsCnx.State = ConnectionState.Closed Then
                            WhsCnx.Open()
                        End If
                        SqlC.ExecuteNonQuery()
                    End If
                Else
                    Dim SqlQuery = "Select Max(OperID) from IvOperationC1ES where InvtypeID = " & FrmMainForm.SalesReturn
                    SqlQuery = SqlQuery & " and WhsCode ='" & txtWHS.Text & "'"
                    Dim SqlC As New SqlCommand(SqlQuery, FrmLogin.objcon.con)
                    Dim SalesReturnSequence = IIf(IsDBNull(SqlC.ExecuteScalar) Or IsNothing(SqlC.ExecuteScalar), Today.Year & "000000", SqlC.ExecuteScalar)
                    SqlC = New SqlCommand("select sequence from sacSequence where seqcode='invtype" & FrmMainForm.SalesReturn & "' and seqyear=" & Today.Year, WhsCnx)
                    If WhsCnx.State = ConnectionState.Closed Then
                        WhsCnx.Open()
                    End If
                    SqlQuery = ""
                    If IsDBNull(SqlC.ExecuteScalar) Or IsNothing(SqlC.ExecuteScalar) Then
                        SqlQuery = " Insert into SacSequence values ('invtype" & FrmMainForm.SalesReturn & "'," & Today.Year
                        SqlQuery = SqlQuery & ",1," & SalesReturnSequence & ")"
                    Else
                        SqlQuery = " update SacSequence set Sequence = " & SalesReturnSequence & " where SeqCode='invtype" & FrmMainForm.SalesReturn & "'"
                        SqlQuery = SqlQuery & " and seqyear = " & Today.Year
                    End If
                    SqlC = New SqlCommand(SqlQuery, WhsCnx)
                    If WhsCnx.State = ConnectionState.Closed Then
                        WhsCnx.Open()
                    End If
                    SqlC.ExecuteNonQuery()
                    SqlQuery = ""
                    SqlQuery = "Select Max(OperID) from IvOperationC1ES where InvtypeID = " & FrmMainForm.SalesInvoice
                    SqlQuery = SqlQuery & " and WhsCode ='" & txtWHS.Text & "'"
                    SqlC = New SqlCommand(SqlQuery, FrmLogin.objcon.con)
                    Dim SalesInvoiceSequence = IIf(IsDBNull(SqlC.ExecuteScalar) Or IsNothing(SqlC.ExecuteScalar), Today.Year & "000000", SqlC.ExecuteScalar)
                    SqlC = New SqlCommand("select sequence from sacSequence where seqcode='" & SalesInvoiceTransCode & "' and seqyear=" & Today.Year, WhsCnx)
                    If WhsCnx.State = ConnectionState.Closed Then
                        WhsCnx.Open()
                    End If
                    SqlQuery = ""
                    If IsDBNull(SqlC.ExecuteScalar) Or IsNothing(SqlC.ExecuteScalar) Then
                        SqlQuery = " Insert into SacSequence values ('" & SalesInvoiceTransCode & "'," & Today.Year
                        SqlQuery = SqlQuery & ",1," & SalesInvoiceSequence & ")"
                    Else
                        SqlQuery = " update SacSequence set Sequence = " & SalesInvoiceSequence & " where SeqCode='" & SalesInvoiceTransCode & "'"
                        SqlQuery = SqlQuery & " and seqyear = " & Today.Year
                    End If
                    SqlC = New SqlCommand(SqlQuery, WhsCnx)
                    If WhsCnx.State = ConnectionState.Closed Then
                        WhsCnx.Open()
                    End If
                    SqlC.ExecuteNonQuery()
                End If
            Else
                Dim SqlQuery = "Select Max(OperID) from IvOperationC1ES where InvtypeID = " & FrmMainForm.SalesReturn
                SqlQuery = SqlQuery & " and WhsCode ='" & txtWHS.Text & "'"
                Dim SqlC As New SqlCommand(SqlQuery, FrmLogin.objcon.con)
                Dim SalesReturnSequence = IIf(IsDBNull(SqlC.ExecuteScalar) Or IsNothing(SqlC.ExecuteScalar), Today.Year & "000000", SqlC.ExecuteScalar)
                SqlC = New SqlCommand("select sequence from sacSequence where seqcode='invtype" & FrmMainForm.SalesReturn & "' and seqyear=" & Today.Year, WhsCnx)
                If WhsCnx.State = ConnectionState.Closed Then
                    WhsCnx.Open()
                End If
                SqlQuery = ""
                If IsDBNull(SqlC.ExecuteScalar) Or IsNothing(SqlC.ExecuteScalar) Then
                    SqlQuery = " Insert into SacSequence values ('invtype" & FrmMainForm.SalesReturn & "'," & Today.Year
                    SqlQuery = SqlQuery & ",1," & SalesReturnSequence & ")"
                Else
                    SqlQuery = " update SacSequence set Sequence = " & SalesReturnSequence & " where SeqCode='invtype" & FrmMainForm.SalesReturn & "'"
                    SqlQuery = SqlQuery & " and seqyear = " & Today.Year
                End If
                SqlC = New SqlCommand(SqlQuery, WhsCnx)
                If WhsCnx.State = ConnectionState.Closed Then
                    WhsCnx.Open()
                End If
                SqlC.ExecuteNonQuery()
                SqlQuery = ""
                SqlQuery = "Select Max(OperID) from IvOperationC1ES where InvtypeID = " & FrmMainForm.SalesInvoice
                SqlQuery = SqlQuery & " and WhsCode ='" & txtWHS.Text & "'"
                SqlC = New SqlCommand(SqlQuery, FrmLogin.objcon.con)
                Dim SalesInvoiceSequence = IIf(IsDBNull(SqlC.ExecuteScalar) Or IsNothing(SqlC.ExecuteScalar), Today.Year & "000000", SqlC.ExecuteScalar)
                SqlC = New SqlCommand("select sequence from sacSequence where seqcode='invtype" & FrmMainForm.SalesInvoice & "' and seqyear=" & Today.Year, WhsCnx)
                If WhsCnx.State = ConnectionState.Closed Then
                    WhsCnx.Open()
                End If
                SqlQuery = ""
                If IsDBNull(SqlC.ExecuteScalar) Or IsNothing(SqlC.ExecuteScalar) Then
                    SqlQuery = " Insert into SacSequence values ('invtype" & FrmMainForm.SalesInvoice & "'," & Today.Year
                    SqlQuery = SqlQuery & ",1," & SalesInvoiceSequence & ")"
                Else
                    SqlQuery = " update SacSequence set Sequence = " & SalesInvoiceSequence & " where SeqCode='invtype" & FrmMainForm.SalesInvoice & "'"
                    SqlQuery = SqlQuery & " and seqyear = " & Today.Year
                End If
                SqlC = New SqlCommand(SqlQuery, WhsCnx)
                If WhsCnx.State = ConnectionState.Closed Then
                    WhsCnx.Open()
                End If
                SqlC.ExecuteNonQuery()
            End If
        Catch ex As Exception
            lbl.Text = ex.Message
        End Try
    End Sub
    Private Sub btnRegenerate_Click(sender As System.Object, e As System.EventArgs) Handles btnRegenerate.Click
        lbl.Text = ""
        Try
            If MessageBox.Show("Are you sure you want to regenerate this POS??", "Pos Generator", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                lbl.Text = "Please wait"
                isGenerate = False
                btnRegenerate.Enabled = False
                BtnGenerate.Enabled = False
                Dim strconnection As String = "Data Source ='" & txtServer.Text & "';Initial Catalog='" & txtDB.Text & "';user ID='" & txtUser.Text & "';password='" & txtPass.Text & "'"
                Dim con As SqlConnection = New SqlConnection(strconnection)
                Dim sqlcom As New SqlCommand("SpRt_InitNewPos", con)
                Dim blnconnectionOpen = ConnStatus(con)
                If Not blnconnectionOpen Then ConnOpen(con)
                sqlcom.ExecuteNonQuery()
                ProgressBarControl1.EditValue = 0
                ProgressBarControl1.Visible = True
                BackgroundWorker1.RunWorkerAsync()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lbl.Text = "Error!"
        End Try
    End Sub
    Public Sub SendOpening()
        Try
            Dim BoConxString = "Data Source ='" & FrmMainForm.BOServer & "';Initial Catalog='" & FrmMainForm.BODatabase & "';user ID='" & FrmMainForm.BOUser & "';password='" & FrmMainForm.BOPass & "'; Connection Timeout = 0"
            Dim BoCnx As SqlConnection = New SqlConnection(BoConxString)
            Dim blnconnectionOpen1 = ConnStatus(BoCnx)
            If Not blnconnectionOpen1 Then ConnOpen(BoCnx)
            Dim SqlString = "select " & Today.Year & "000001 as 'OperId', " & FrmMainForm.Opening & " as 'InvTypeId',ROW_NUMBER() over(Order by ib.itembid) as 'LigneId',ROW_NUMBER() over(Order by ib.itembid) as 'lineorder', "
            SqlString = SqlString & " ib.ItemBId,1 As 'Sign', ib.ItemAid,ib.BarCode,ib.ItemShDescription,'LMS' as 'WhsCode',ib.SizeCode,"
            SqlString = SqlString & " ib.ColorCode,ib.LigneDesc,sum(ib.QtyAffect * ib.Sign) as Qty, sum(ib.QtyAffect * ib.Sign) as QtyAffect,ib.UOMCode,ib.Factor"
            SqlString = SqlString & " from ivoperationb1es ib join IvItemA1ES ia on ia.ItemAID = ib.ItemAId"
            SqlString = SqlString & " where ib.WhsCode='" & txtWHS.Text & "' and ia.AllowSell = 1"
            SqlString = SqlString & " group by ib.itembid,ib.itemaid,ib.barcode,ib.itemshdescription,ib.sizecode,"
            SqlString = SqlString & " ib.LigneDesc, ib.UomCode, ib.Factor, ib.colorcode"
            SqlString = SqlString & " Having sum(ib.QtyAffect * ib.Sign) <> 0"
            Dim dt As New DataTable
            Dim sqlcom As New SqlCommand(SqlString, BoCnx)
            sqlcom.CommandTimeout = 0
            Dim da As New SqlDataAdapter(sqlcom)
            da.Fill(dt)
            BoCnx.Close()
            If dt.Rows.Count = 0 Then
                Exit Sub
            End If
            Dim ClsOperationA As New ClsOperationA
            Dim con As SqlConnection = Nothing
            Try
                Dim OperID As Integer
                Dim strconnection As String = "Data Source ='" & txtServer.Text & "';Initial Catalog='" & txtDB.Text & "';user ID='" & txtUser.Text & "';password='" & txtPass.Text & "';Connection Timeout = 0"
                con = New SqlConnection(strconnection)

                OperID = Today.Year & "000001"
                Dim command As SqlCommand = con.CreateCommand()
                command.Connection = con
                command.CommandText = "SpIv_BODeliveryOrderAInsert"
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.AddWithValue("@OperId", OperID)
                command.Parameters.AddWithValue("@InvTypeId", FrmMainForm.Opening)
                command.Parameters.AddWithValue("@OperDate", Today.Date)
                command.Parameters.AddWithValue("@ActivationDate", Today.Date)
                command.Parameters.AddWithValue("@ThirdId", DBNull.Value)
                command.Parameters.AddWithValue("@ThirdDesc", "")
                command.Parameters.AddWithValue("@SalesManId", DBNull.Value)
                command.Parameters.AddWithValue("@PosCode", txtPOs.Text)
                command.Parameters.AddWithValue("@WhsCode", txtWHS.Text)
                command.Parameters.AddWithValue("@CurCode", FrmMainForm.CurCode)
                command.Parameters.AddWithValue("@Delivery1", "")
                command.Parameters.AddWithValue("@Delivery2", "")
                command.Parameters.AddWithValue("@Delivery3", "")
                command.Parameters.AddWithValue("@Posted", 0)
                command.Parameters.AddWithValue("@TransId", DBNull.Value)
                command.Parameters.AddWithValue("@ApplyVat", 1)
                command.Parameters.AddWithValue("@Status", 0)
                command.Parameters.AddWithValue("@Confirmed", 1)
                command.Parameters.AddWithValue("@Closed", 1)
                command.Parameters.AddWithValue("@Costed", DBNull.Value)
                command.Parameters.AddWithValue("@AvgCosted", DBNull.Value)
                command.Parameters.AddWithValue("@RateFl", 0)
                command.Parameters.AddWithValue("@RateSl", 0)
                command.Parameters.AddWithValue("@RateVat", 0)
                command.Parameters.AddWithValue("@ManualRef", "")
                command.Parameters.AddWithValue("@RefDate", Today.Date)
                command.Parameters.AddWithValue("@GrossAmt", 0)
                command.Parameters.AddWithValue("@Disc1Pct", 0)
                command.Parameters.AddWithValue("@Disc1Amt", 0)
                command.Parameters.AddWithValue("@Disc2Pct", 0)
                command.Parameters.AddWithValue("@Disc2Amt", 0)
                command.Parameters.AddWithValue("@ExtraChargeAmt", 0)
                command.Parameters.AddWithValue("@ExtraChargeVat", 0)
                command.Parameters.AddWithValue("@AddDiscAmt", 0)
                command.Parameters.AddWithValue("@NetAmt", 0)
                command.Parameters.AddWithValue("@VatAmt", 0)
                command.Parameters.AddWithValue("@Notes", "")
                command.Parameters.AddWithValue("@Iuser", FrmLogin.user)
                command.Parameters.AddWithValue("@Idate", Today.Date)
                command.Parameters.AddWithValue("@UUser", FrmLogin.user)
                command.Parameters.AddWithValue("@UDate", Today.Date)
                command.Parameters.AddWithValue("@Message", "")
                command.Parameters.AddWithValue("@DeliveryTerms", "")
                command.Parameters.AddWithValue("@PaymentTerms", "")
                command.Parameters.AddWithValue("@ContractId", DBNull.Value)
                command.Parameters.AddWithValue("@ContractCode", DBNull.Value)
                command.Parameters.AddWithValue("@AssignToId", DBNull.Value)
                command.Parameters.AddWithValue("@MopTransID", DBNull.Value)
                command.Parameters.AddWithValue("@Gift", DBNull.Value)
                command.Parameters.AddWithValue("@GiftReturnDate", DBNull.Value)
                command.Parameters.AddWithValue("@Seen", 1)
                blnconnectionOpen1 = ConnStatus(con)
                If Not blnconnectionOpen1 Then ConnOpen(con)
                command.ExecuteNonQuery()
                Try
                    blnconnectionOpen1 = ConnStatus(con)
                    If Not blnconnectionOpen1 Then ConnOpen(con)
                    Dim transaction As SqlTransaction = Nothing
                    Dim transcommand As SqlCommand = con.CreateCommand()
                    transaction = con.BeginTransaction("SampleTransaction")
                    Dim bulkcopy As New SqlBulkCopy(con, SqlBulkCopyOptions.Default, transaction)
                    bulkcopy.DestinationTableName = "IvOperationB1es"
                    transcommand.Connection = con
                    Try
                        For Each i As DataColumn In dt.Columns
                            bulkcopy.ColumnMappings.Add(i.ColumnName, i.ColumnName)
                        Next
                        bulkcopy.WriteToServer(dt)
                        dt.Dispose()
                        dt = Nothing
                        transaction.Commit()

                        Dim sqlc As New SqlCommand("select Sequence from sacsequence where SeqCode='invtype" & FrmMainForm.Opening & "' and seqyear=" & Today.Year & "", con)
                        blnconnectionOpen1 = ConnStatus(con)
                        If Not blnconnectionOpen1 Then ConnOpen(con)

                        If IsDBNull(sqlc.ExecuteScalar) Or IsNothing(sqlc.ExecuteScalar) Then
                            sqlc = New SqlCommand("insert into SacSequence (SeqCode,SeqYear,Companyid,Sequence) values ('invtype" &
                                       FrmMainForm.Opening & "'," & Today.Year & ",1," & Today.Year & "000001)", con)
                            sqlc.ExecuteNonQuery()
                        Else
                            sqlc = New SqlCommand("update SacSequence set Sequence = '" & OperID & "' where SeqCode='invtype" & FrmMainForm.Opening & "' and seqyear = " & Today.Year, con)
                            sqlc.ExecuteNonQuery()
                        End If

                        sqlc = New SqlCommand("update IvOperation1es set seen = 1 where WhsToCode ='" & txtWHS.Text & "' or WhsCode='" & txtWHS.Text & "'", BoCnx)

                        blnconnectionOpen1 = ConnStatus(BoCnx)
                        If Not blnconnectionOpen1 Then ConnOpen(BoCnx)
                        sqlc.ExecuteNonQuery()
                        Utilities.WriteToText("InsertOpening In POS: " & txtWHS.Text & ": ", "Successfully Inserted")
                    Catch ex As Exception
                        Utilities.WriteToText("InsertOpening In POS: " & txtWHS.Text & " Commit Type Failed Due To : ", ex.GetType().ToString)
                        Utilities.WriteToText("InsertOpening In POS: " & txtWHS.Text & " Commit Message Failed Due To : ", ex.Message)
                        Dim ClsLog As New ClsLogs
                        ClsLog._BackOffice = ""
                        ClsLog._PosCode = txtWHS.Text
                        ClsLog._FunctionN = "InsertOpening"
                        ClsLog._Desc = ex.Message
                        ClsLog._Sql = ""
                        ClsLog.WriteToTable(FrmLogin.objcon.con)
                        Try
                            transaction.Rollback()
                        Catch ex2 As Exception
                            Utilities.WriteToText("InsertOpening In POS: " & txtWHS.Text & " Rollback Type Failed Due To : ", ex.GetType().ToString)
                            Utilities.WriteToText("InsertOpening In POS: " & txtWHS.Text & " Rollback Message Failed Due To : ", ex.Message)
                        End Try
                    Finally
                        If BoCnx.State = ConnectionState.Open Then
                            BoCnx.Close()
                        End If
                        If con.State = ConnectionState.Open Then
                            con.Close()
                        End If
                    End Try
                Catch ex As Exception
                    Utilities.WriteToText("InsertOpening In POS: " & txtWHS.Text, " Connection Could not be established")
                End Try
            Catch ex As Exception
                Utilities.WriteToText("InsertOpening in POS:  " & txtWHS.Text & "Failed Due To: ", ex.Message)
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lbl.Text = "Error!"
        End Try
    End Sub
    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        ProgressBarControl1.EditValue = e.ProgressPercentage
    End Sub
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            If isGenerate = True Then
                InsertPosWhs()
                SetTextBoxInfo("Sending Brands")
                InsertBrands()
                SetTextBoxInfo("Sending Types")
                InsertTypes()
                SetTextBoxInfo("Sending Categories")
                InsertCategories()
                BackgroundWorker1.ReportProgress(10)
                SetTextBoxInfo("Sending Items")
                InsertItemsA()
                BackgroundWorker1.ReportProgress(20)
                InsertItemsB()
                BackgroundWorker1.ReportProgress(30)
                SetTextBoxInfo("Sending Item Control")
                'InsertItemControlInWhs()
                BackgroundWorker1.ReportProgress(40)
                SetTextBoxInfo("Sending Item Control")
                'InsertItemControlInBo()
                BackgroundWorker1.ReportProgress(50)
                SetTextBoxInfo("Sending PriceList")
                GetChangedPriceList()
                BackgroundWorker1.ReportProgress(60)
                SetTextBoxInfo("Sending Customers")
                InsertCustomersA()
                BackgroundWorker1.ReportProgress(70)
                SetTextBoxInfo("Sending Customers")
                InsertCustomersB()
                BackgroundWorker1.ReportProgress(80)
                SetTextBoxInfo("Sending Parameters")
                SendRsTableParam()
                BackgroundWorker1.ReportProgress(85)
                SetTextBoxInfo("Sending Opening")
                SendOpening()
                BackgroundWorker1.ReportProgress(90)
                SetTextBoxInfo("Setting Export Version")
                InsertExportVersion()
                BackgroundWorker1.ReportProgress(100)
            Else
                InsertPosWhs()
                SetTextBoxInfo("Sending Brands")
                InsertBrands()
                SetTextBoxInfo("Sending Types")
                InsertTypes()
                SetTextBoxInfo("Sending Categories")
                InsertCategories()
                BackgroundWorker1.ReportProgress(10)
                SetTextBoxInfo("Sending Items")
                InsertItemsA()
                BackgroundWorker1.ReportProgress(20)
                InsertItemsB()
                BackgroundWorker1.ReportProgress(30)
                SetTextBoxInfo("Sending Item Control")
                '  InsertItemControlInWhs()
                'InsertItemControlInSpecificWHS(txtWHS.Text)
                BackgroundWorker1.ReportProgress(50)
                'InsertItemControlInBo()
                BackgroundWorker1.ReportProgress(50)
                SetTextBoxInfo("Sending PriceList")
                GetChangedPriceList()
                BackgroundWorker1.ReportProgress(60)
                SetTextBoxInfo("Sending Customers")
                InsertCustomersA()
                BackgroundWorker1.ReportProgress(70)
                SetTextBoxInfo("Sending Customers")
                InsertCustomersB()
                BackgroundWorker1.ReportProgress(80)
                SetTextBoxInfo("Sending Parameters")
                SendRsTableParam()
                BackgroundWorker1.ReportProgress(85)
                SetTextBoxInfo("Sending Opening")
                SendOpening()
                BackgroundWorker1.ReportProgress(90)
                SetTextBoxInfo("Setting Export Version")
                InsertExportVersion()
                BackgroundWorker1.ReportProgress(95)
                Dim strconnection As String = "Data Source ='" & txtServer.Text & "';Initial Catalog='" & txtDB.Text & "';user ID='" & txtUser.Text & "';password='" & txtPass.Text & "'"
                Dim con As SqlConnection = New SqlConnection(strconnection)
                SetTextBoxInfo("Setting Sequence")
                SendSequence(con)
                BackgroundWorker1.ReportProgress(100)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        lbl.Text = "Done"
        btnRegenerate.Enabled = True
        BtnGenerate.Enabled = True
    End Sub

    'Public Shared Function ParameterValueForSQL(sp As SqlParameter) As [String]
    '    Dim retval As [String] = ""

    '    Select Case sp.SqlDbType
    '        Case SqlDbType.[Char], SqlDbType.NChar, SqlDbType.NText, SqlDbType.NVarChar, SqlDbType.Text, SqlDbType.Time,
    '         SqlDbType.VarChar, SqlDbType.Xml, SqlDbType.[Date], SqlDbType.DateTime, SqlDbType.DateTime2, SqlDbType.DateTimeOffset
    '            retval = "'" + sp.Value.ToString().Replace("'", "''") + "'"
    '            Exit Select

    '        Case SqlDbType.Bit
    '            retval = If((sp.Value.ToBooleanOrDefault(False)), "1", "0")
    '            Exit Select
    '        Case Else

    '            retval = sp.Value.ToString().Replace("'", "''")
    '            Exit Select
    '    End Select

    '    Return retval
    'End Function
    'Public Shared Function CommandAsSql(sc As SqlCommand) As [String]
    '    Dim sql As New StringBuilder()
    '    Dim FirstParam As [Boolean] = True
    '    sql.AppendLine("use " + sc.Connection.Database + ";")
    '    Select Case sc.CommandType
    '        Case CommandType.StoredProcedure
    '            For Each sp As SqlParameter In sc.Parameters
    '                If (sp.Direction = ParameterDirection.InputOutput) OrElse (sp.Direction = ParameterDirection.Output) Then
    '                    sql.Append("declare " + sp.ParameterName + vbTab + sp.SqlDbType.ToString() + vbTab & "= ")
    '                    sql.AppendLine((If((sp.Direction = ParameterDirection.Output), "null", sp.Value())) + ";")
    '                End If
    '            Next
    '            sql.AppendLine("exec [" + sc.CommandText + "]")
    '            For Each sp As SqlParameter In sc.Parameters
    '                If sp.Direction <> ParameterDirection.ReturnValue Then
    '                    sql.Append(If((FirstParam), vbTab, vbTab & ", "))
    '                    If FirstParam Then
    '                        FirstParam = False
    '                    End If
    '                    If sp.Direction = ParameterDirection.Input Then
    '                        Dim v As New Object
    '                        If IsDBNull(CObj(sp.Value)) Then
    '                            v = "NULL"
    '                        ElseIf IsNothing(CObj(sp.Value)) Then
    '                            v = "NULL"
    '                        Else
    '                            v = sp.Value()
    '                        End If
    '                        If CStr(v) = "NULL" Then
    '                            sql.AppendLine(CStr(sp.ParameterName + " = " + CStr(v)))
    '                        Else
    '                            If TypeOf (CObj(v)) Is DateTime Then
    '                                sql.AppendLine(CStr(sp.ParameterName + " = " + "'" + CDate(v).ToString("yyyyMMdd")) + "'")
    '                            Else
    '                                sql.AppendLine(CStr(sp.ParameterName + " = " + "'" + CStr(v)) + "'")
    '                            End If
    '                        End If
    '                    Else
    '                        sql.AppendLine(sp.ParameterName + " = " + sp.ParameterName + " output")
    '                    End If
    '                End If
    '            Next
    '            sql.AppendLine(";")

    '            For Each sp As SqlParameter In sc.Parameters
    '                If (sp.Direction = ParameterDirection.InputOutput) OrElse (sp.Direction = ParameterDirection.Output) Then
    '                    sql.AppendLine("select '" + sp.ParameterName + "' = convert(varchar, " + sp.ParameterName + ");")
    '                End If
    '            Next
    '            Exit Select
    '        Case CommandType.Text
    '            sql.AppendLine(sc.CommandText)
    '            Exit Select
    '    End Select

    '    Return sql.ToString()
    'End Function
End Class