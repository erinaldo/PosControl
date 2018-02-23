Imports System.Data.SqlClient
Imports ConnectionSQL
Imports System.Text
Imports System.IO

Public Class FrmMainForm
    Public Shared salesmanid As Integer
    Public Shared DefaultCustomer As Integer
    Public Shared UseSize As Boolean = False
    Public Shared UseColor As Boolean = False
    Public Shared QtyDecimals As Integer
    Public Shared CurCode As String
    Public Shared AccCode As String
    Public Shared PriceList As String
    Public Shared DeliveryOrder As String
    Public Shared BOServer As String
    Public Shared BODatabase As String
    Public Shared BOUser As String
    Public Shared BOPass As String
    Public Shared UPDecimals As Integer
    Public Shared SalesReturn As Integer
    Public Shared SalesInvoice As Integer
    Public Shared SalesOrder As Integer
    Public Shared Sync As Integer
    Dim dsCustomers As New DataSet
    Dim dsPriceList As New DataSet
    Public Shared WhsAdjustment As Integer
    Public Shared Opening As Integer
    Public Shared ReportPath As String
    Public Shared TransferWhs As String
    Public Shared TransferToWhs As String
    Public Shared SupplierID As String
    Public Shared TransferFromWHs As String
    Public Shared TransferFromdb As String
    Public Shared Transfertodb As String
    Public Shared SalesIndB As String
    Public Shared SalesFromDb As String
    Public Shared PurchasePriceList As String
    Public Shared PurchaseInDb As String
    Public Shared PurchaseWhs As String
    Public Shared SalesWhs As String
    Public Shared SalesCustomer As String
    Public Shared PurchaseID As Integer
    Public Shared TabletPos As String
    Public Shared PostDatedCode As String
    Private Sub FrmMainForm_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If CustomersWorker.IsBusy = True Or PriceListWorker.IsBusy = True Then
            MsgBox("Please try again later")
            e.Cancel = True
        Else
            End
        End If
    End Sub
    Private Sub FrmMainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            GetCurCode()
            GetAccCode()
            GetDefaultCustomer() 'From Registery
            GetSalesManID()
            GetParameters()
            GetPriceList()
            GetBOConf()
            GetSync()
            GetSales()
            GetDeliveryOrder()
            GetCompanyParameters()
            If Sync = 0 Then
                Timer1.Interval = 10000 * 60000
            Else
                Timer1.Interval = FrmMainForm.Sync * 60000
            End If
            Timer1.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub 
   Public Sub UpdateItemsQty()
        Try
            Dim sqls = ""
            Dim Whs = ""
            Try
                Dim ClsPos As New ClsPOS
                Dim dt As New DataTable
                dt = ClsPos.GetPosConfig(FrmLogin.objcon.con)
                Dim ClsItemA As New ClsItemA
                Dim BoConxString = "Data Source ='" & BOServer & "';Initial Catalog='" & BODatabase & "';user ID='" & BOUser & "';password='" & BOPass & "'"
                Dim BoCnx As SqlConnection = New SqlConnection(BoConxString)
                Dim blnconnectionOpen1 = ConnStatus(BoCnx)
                If Not blnconnectionOpen1 Then ConnOpen(BoCnx)
                Try
                    For i = 0 To dt.Rows.Count - 1
                        Whs = dt.Rows(i).Item("WhsCode")
                        Dim PosCode = dt.Rows(i).Item("PosCode")
                        If PosIsInstalled(PosCode) = False Then Continue For
                        sqls = ""
                        Dim strconnection As String = "Data Source ='" & dt.Rows(i).Item("PosServer") & "';Initial Catalog='" & dt.Rows(i).Item("PosDatabase") & "';user ID='" & dt.Rows(i).Item("PosUser") & "';password='" & dt.Rows(i).Item("PosPass") & "';Connection Timeout = 320"
                        Dim con As SqlConnection = New SqlConnection(strconnection)
                        Dim DtNewItems = ClsItemA.BoGetItemsQty(Whs, BoCnx)
                        For j = 0 To DtNewItems.Rows.Count - 1
                            Dim command As SqlCommand = con.CreateCommand()
                            command.Connection = con
                            command.CommandText = "SpIv_InsertItemControl"
                            command.CommandType = CommandType.StoredProcedure
                            command.Parameters.AddWithValue("@WhsCode", IIf(IsNothing(Whs) Or IsDBNull(Whs), DBNull.Value, Whs))
                            command.Parameters.AddWithValue("@Barcode", IIf(IsNothing(DtNewItems.Rows(j).Item("Barcode")) Or IsDBNull(DtNewItems.Rows(j).Item("Barcode")), DBNull.Value, DtNewItems.Rows(j).Item("Barcode")))
                            command.Parameters.AddWithValue("@MinQty", IIf(IsNothing(DtNewItems.Rows(j).Item("MinQty")) Or IsDBNull(DtNewItems.Rows(j).Item("MinQty")), 0, DtNewItems.Rows(j).Item("MinQty")))
                            command.Parameters.AddWithValue("@MaxQty", IIf(IsNothing(DtNewItems.Rows(j).Item("MaxQty")) Or IsDBNull(DtNewItems.Rows(j).Item("MaxQty")), 0, DtNewItems.Rows(j).Item("MaxQty")))
                            command.Parameters.AddWithValue("@Blocked", IIf(IsNothing(DtNewItems.Rows(j).Item("Blocked")) Or IsDBNull(DtNewItems.Rows(j).Item("Blocked")), 0, DtNewItems.Rows(j).Item("Blocked")))
                            sqls += CommandAsSql(command)
                        Next
                        If sqls <> "" Then
                            Dim transaction As SqlTransaction = Nothing
                            If con.State = ConnectionState.Closed Then
                                Try
                                    con.Open()
                                    Dim transcommand As SqlCommand = con.CreateCommand()
                                    transaction = con.BeginTransaction("SampleTransaction")
                                    transcommand.Connection = con
                                    transcommand.Transaction = transaction
                                    transcommand.CommandText = sqls
                                    transcommand.CommandType = CommandType.Text
                                    Try
                                        transcommand.ExecuteNonQuery()
                                        transaction.Commit()
                                        If Not blnconnectionOpen1 Then ConnOpen(BoCnx)
                                        Dim SqlCom As New SqlCommand("update IvItemControl set Modified=0 where WhsCode ='" & Whs & "'", BoCnx)
                                        SqlCom.ExecuteNonQuery()
                                        Utilities.WriteToText("UpdateWhsQty: In WHS " & Whs, "Successfully Inserted")
                                    Catch ex As Exception
                                        Utilities.WriteToText("UpdateWhsQty: In WHS: " & Whs & " Commit Type Failed Due To : ", ex.GetType().ToString)
                                        Utilities.WriteToText("UpdateWhsQty: In WHS: " & Whs & " Commit Message Failed Due To : ", ex.Message)
                                        Dim ClsLog As New ClsLogs
                                        ClsLog._BackOffice = ""
                                        ClsLog._PosCode = Whs
                                        ClsLog._FunctionN = "UpdateWhsQty"
                                        ClsLog._Desc = ex.Message
                                        ClsLog._Sql = sqls
                                        ClsLog.WriteToTable(FrmLogin.objcon.con)
                                        Try
                                            transaction.Rollback()
                                        Catch ex2 As Exception
                                            Utilities.WriteToText("UpdateWhsQty: In WHS: " & Whs & " Rollback Type Failed Due To : ", ex2.GetType().ToString)
                                            Utilities.WriteToText("UpdateWhsQty: In WHS: " & Whs & "  Rollback Message Failed Due To : ", ex2.Message)
                                        End Try
                                    Finally
                                        con.Close()
                                    End Try
                                Catch ex As Exception
                                    Utilities.WriteToText("UpdateWhsQty: In WHS: " & Whs, " Connection could not be established")
                                End Try
                            End If
                        End If
                    Next
                Catch ex As Exception
                    Utilities.WriteToText("UpdateWhsQty:  In WHS: " & Whs & " Failed Due to ", ex.Message)
                End Try
            Catch ex As Exception
                Utilities.WriteToText("UpdateWhsQty:  In Whs: " & Whs & " Failed Due to ", ex.Message)
            End Try
        Catch ex As Exception
            Utilities.WriteToText("UpdateWhsQty:    ", ex.Message)
        End Try
    End Sub
    Public Sub GetCompanyParameters()
        Try
            Dim sqlcom As New SqlCommand("select * from SacCompany", FrmLogin.objcon.con)
            sqlcom.CommandType = CommandType.Text
            If FrmLogin.objcon.con.State = ConnectionState.Closed Then
                FrmLogin.objcon.con.Open()
            End If
            Dim da As SqlDataAdapter = New SqlDataAdapter(sqlcom)
            Dim dt As New DataTable
            da.Fill(dt)
            Me.Text = dt.Rows(0).Item("Description").ToString & " (BusinessPack V " & My.Application.Info.Version.ToString & ")"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Function PosIsInstalled(ByVal PosCode As String) As Boolean
        Try
            Dim SqlCom As New SqlCommand("Select PosCode from RtExportHist where PosCode ='" & PosCode & "'", FrmLogin.objcon.con)
            Dim isAvailable As Boolean = False
            If FrmLogin.objcon.con.State = ConnectionState.Closed Then
                FrmLogin.objcon.con.Open()
            End If
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter(SqlCom)
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                isAvailable = True
            Else
                isAvailable = False
            End If
            Return isAvailable
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return False
    End Function
    Private Sub BackgroundWorker1_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles CustomersWorker.DoWork
        Try
            If Sync = 0 Then
                Exit Sub
            End If

            InsertCustomerInBO()
            InsertCustomers()

            InsertBrands()
            InsertTypes()
            InsertCategories()

            InsertItemsA()
            InsertItemsB()

            'InsertNewItemsControl()
            'UpdateItemsQty()
            GetDeliveryOperations()
            GetWhsAdjustments()
        Catch ex As Exception
            Utilities.WriteToText("Sending Operations From BgWorker POS Control Failed Due To: ", ex.Message)
        End Try
    End Sub
    Public Sub InsertCategories()
        Dim POS = ""
        Dim sqls = ""
        Try
            Dim ClsPos As New ClsPOS
            Dim dt As New DataTable
            dt = ClsPos.GetPosConfig(FrmLogin.objcon.con)
            Dim ClsCategory As New ClsCategory
            Dim BoConxString = "Data Source ='" & FrmMainForm.BOServer & "';Initial Catalog='" & FrmMainForm.BODatabase & "';user ID='" & FrmMainForm.BOUser & "';password='" & FrmMainForm.BOPass & "'"
            Dim BoCnx As SqlConnection = New SqlConnection(BoConxString)
            Dim blnconnectionOpen1 As Boolean

            Try
                For i = 0 To dt.Rows.Count - 1
                    sqls = ""
                    Dim strconnection As String = "Data Source ='" & dt.Rows(i).Item("PosServer") & "';Initial Catalog='" & dt.Rows(i).Item("PosDatabase") & "';user ID='" & dt.Rows(i).Item("PosUser") & "';password='" & dt.Rows(i).Item("PosPass") & "';Connection Timeout = 150"
                    Dim con As SqlConnection = New SqlConnection(strconnection)
                    POS = dt.Rows(i).Item("PosCode")

                    blnconnectionOpen1 = ConnStatus(BoCnx)
                    If Not blnconnectionOpen1 Then ConnOpen(BoCnx)


                    If PosIsInstalled(POS) = False Then Continue For
                    Dim CatStamp As String = GetCategoriesTimeStamp(POS, FrmLogin.objcon.con)
                    Dim DtCategories = ClsCategory.GetNewCategories(CatStamp, BoCnx)
                    For j = 0 To DtCategories.Rows.Count - 1
                        Dim command As SqlCommand = con.CreateCommand()
                        command.Connection = con
                        command.CommandText = "SpRt_InsertNewCategory"
                        command.CommandType = CommandType.StoredProcedure
                        command.Parameters.AddWithValue("@CategoryCode", IIf(IsNothing(DtCategories.Rows(j).Item("CategoryCode")) Or IsDBNull(DtCategories.Rows(j).Item("CategoryCode")), DBNull.Value, DtCategories.Rows(j).Item("CategoryCode")))
                        command.Parameters.AddWithValue("@Description", IIf(IsNothing(DtCategories.Rows(j).Item("Description")) Or IsDBNull(DtCategories.Rows(j).Item("Description")), DBNull.Value, DtCategories.Rows(j).Item("Description")))
                        command.Parameters.AddWithValue("@AltDescription", IIf(IsNothing(DtCategories.Rows(j).Item("AltDescription")) Or IsDBNull(DtCategories.Rows(j).Item("AltDescription")), DBNull.Value, DtCategories.Rows(j).Item("AltDescription")))
                        sqls += CommandAsSql(command)
                    Next
                    If sqls <> "" Then
                        Dim transaction As SqlTransaction = Nothing
                        If con.State = ConnectionState.Closed Then
                            Try
                                con.Open()
                                Dim transcommand As SqlCommand = con.CreateCommand()
                                transaction = con.BeginTransaction("SampleTransaction")
                                transcommand.Connection = con
                                transcommand.Transaction = transaction
                                transcommand.CommandText = sqls
                                transcommand.CommandType = CommandType.Text
                                Try
                                    transcommand.ExecuteNonQuery()
                                    transaction.Commit()
                                    Dim MaxCatStamp = GetMaxCatTimeStamp(BoCnx)
                                    UpdateCatsTimeStamp(MaxCatStamp, POS, FrmLogin.objcon.con)
                                    Utilities.WriteToText("InsertNewCategories: In POS: " & POS, "Successfully Inserted")
                                Catch ex As Exception
                                    Utilities.WriteToText("InsertNewCategories: In POS: " & POS & " Commit Type Failed Due To : ", ex.GetType().ToString)
                                    Utilities.WriteToText("InsertNewCategories: In POS: " & POS & " Commit Message Failed Due To : ", ex.Message)
                                    Dim ClsLog As New ClsLogs
                                    ClsLog._BackOffice = ""
                                    ClsLog._PosCode = POS
                                    ClsLog._FunctionN = "InsertCategories"
                                    ClsLog._Desc = ex.Message
                                    ClsLog._Sql = sqls
                                    ClsLog.WriteToTable(FrmLogin.objcon.con)
                                    Try
                                        transaction.Rollback()
                                    Catch ex2 As Exception
                                        Utilities.WriteToText("InsertNewCategories: In POS: " & POS & " Rollback Type Failed Due To : ", ex2.GetType().ToString)
                                        Utilities.WriteToText("InsertNewCategories: In POS: " & POS & " Rollback Message Failed Due To : ", ex2.Message)
                                        Continue For
                                    End Try
                                Finally
                                    con.Close()
                                End Try
                            Catch ex As Exception
                                Utilities.WriteToText("Insert Categories: ", "A Connection could not be established to: " & POS)
                                Continue For
                            End Try
                        End If
                    End If
                Next
            Catch ex As Exception
                Utilities.WriteToText("InsertNewCategories: In POS: " & POS & " Failed Due to ", ex.Message)
            End Try
        Catch ex As Exception
            Utilities.WriteToText("InsertNewCategories:  In POS: " & POS & " Failed Due to ", ex.Message)
        End Try
    End Sub
    Public Sub InsertTypes()
        Dim POS = ""
        Dim sqls = ""
        Try
            Dim ClsPos As New ClsPOS
            Dim dt As New DataTable
            dt = ClsPos.GetPosConfig(FrmLogin.objcon.con)
            Dim ClsType As New ClsType
            Dim BoConxString = "Data Source ='" & FrmMainForm.BOServer & "';Initial Catalog='" & FrmMainForm.BODatabase & "';user ID='" & FrmMainForm.BOUser & "';password='" & FrmMainForm.BOPass & "'"
            Dim BoCnx As SqlConnection = New SqlConnection(BoConxString)
            Dim blnconnectionOpen1 As Boolean

            Try
                For i = 0 To dt.Rows.Count - 1
                    sqls = ""
                    POS = dt.Rows(i).Item("PosCode")

                    blnconnectionOpen1 = ConnStatus(BoCnx)
                    If Not blnconnectionOpen1 Then ConnOpen(BoCnx)

                    If PosIsInstalled(POS) = False Then Continue For
                    Dim TypeStamp As String = GetTypesTimeStamp(POS, FrmLogin.objcon.con)
                    Dim DtTypes = ClsType.GetNewTypes(TypeStamp, BoCnx)

                    Dim strconnection As String = "Data Source ='" & dt.Rows(i).Item("PosServer") & "';Initial Catalog='" & dt.Rows(i).Item("PosDatabase") & "';user ID='" & dt.Rows(i).Item("PosUser") & "';password='" & dt.Rows(i).Item("PosPass") & "';Connection Timeout = 150"
                    Dim con As SqlConnection = New SqlConnection(strconnection)
                    For j = 0 To DtTypes.Rows.Count - 1
                        Dim command As SqlCommand = con.CreateCommand()
                        command.Connection = con
                        command.CommandText = "SpRt_InsertNewType"
                        command.CommandType = CommandType.StoredProcedure
                        command.Parameters.AddWithValue("@TypeCode", IIf(IsNothing(DtTypes.Rows(j).Item("TypeCode")) Or IsDBNull(DtTypes.Rows(j).Item("TypeCode")), DBNull.Value, DtTypes.Rows(j).Item("TypeCode")))
                        command.Parameters.AddWithValue("@Description", IIf(IsNothing(DtTypes.Rows(j).Item("Description")) Or IsDBNull(DtTypes.Rows(j).Item("Description")), DBNull.Value, DtTypes.Rows(j).Item("Description")))
                        command.Parameters.AddWithValue("@AltDescription", IIf(IsNothing(DtTypes.Rows(j).Item("AltDescription")) Or IsDBNull(DtTypes.Rows(j).Item("AltDescription")), DBNull.Value, DtTypes.Rows(j).Item("AltDescription")))
                        sqls += CommandAsSql(command)

                    Next
                    If sqls <> "" Then
                        Dim transaction As SqlTransaction = Nothing
                        If con.State = ConnectionState.Closed Then
                            Try
                                con.Open()
                                Dim transcommand As SqlCommand = con.CreateCommand()
                                transaction = con.BeginTransaction("SampleTransaction")
                                transcommand.Connection = con
                                transcommand.Transaction = transaction
                                transcommand.CommandText = sqls
                                transcommand.CommandType = CommandType.Text
                                Try
                                    transcommand.ExecuteNonQuery()
                                    transaction.Commit()
                                    Dim MaxTypeStamp = GetMaxTypesTimeStamp(BoCnx)
                                    UpdateTypesTimeStamp(MaxTypeStamp, POS, FrmLogin.objcon.con)
                                    Utilities.WriteToText("InsertNewTypes: In POS: " & POS, "Successfully Inserted")
                                Catch ex As Exception
                                    Utilities.WriteToText("InsertNewTypes: In POS: " & POS & " Commit Type Failed Due To : ", ex.GetType().ToString)
                                    Utilities.WriteToText("InsertNewTypes: In POS: " & POS & " Commit Message Failed Due To : ", ex.Message)
                                    Dim ClsLog As New ClsLogs
                                    ClsLog._BackOffice = ""
                                    ClsLog._PosCode = POS
                                    ClsLog._FunctionN = "InsertTypes"
                                    ClsLog._Desc = ex.Message
                                    ClsLog._Sql = sqls
                                    ClsLog.WriteToTable(FrmLogin.objcon.con)
                                    Try
                                        transaction.Rollback()
                                    Catch ex2 As Exception
                                        Utilities.WriteToText("InsertNewTypes: In POS: " & POS & " Rollback Type Failed Due To : ", ex2.GetType().ToString)
                                        Utilities.WriteToText("InsertNewTypes: In POS: " & POS & " Rollback Message Failed Due To : ", ex2.Message)
                                        Continue For
                                    End Try
                                Finally
                                    con.Close()
                                End Try
                            Catch ex As Exception
                                Utilities.WriteToText("InsertNewTypes: In POS: " & POS, " Connection could not be established")
                                Continue For
                            End Try
                        End If
                    End If
                Next
            Catch ex As Exception
                Utilities.WriteToText("InsertNewTypes: In POS: " & POS & " Failed Due to ", ex.Message)
            End Try
        Catch ex As Exception
            Utilities.WriteToText("InsertNewTypes: In POS: " & POS & " Failed Due to ", ex.Message)
        End Try
    End Sub
    Public Sub InsertBrands()
        Dim POS = ""
        Dim sqls = ""
        Try
            Dim ClsPos As New ClsPOS
            Dim dt As New DataTable
            dt = ClsPos.GetPosConfig(FrmLogin.objcon.con)
            Dim ClsBrand As New ClsBrand
            Dim BoConxString = "Data Source ='" & FrmMainForm.BOServer & "';Initial Catalog='" & FrmMainForm.BODatabase & "';user ID='" & FrmMainForm.BOUser & "';password='" & FrmMainForm.BOPass & "'"
            Dim BoCnx As SqlConnection = New SqlConnection(BoConxString)
            Dim blnconnectionOpen1 As Boolean

            Try
                For i = 0 To dt.Rows.Count - 1
                    sqls = ""
                    blnconnectionOpen1 = ConnStatus(BoCnx)
                    If Not blnconnectionOpen1 Then ConnOpen(BoCnx)
                    POS = dt.Rows(i).Item("PosCode")

                    If PosIsInstalled(POS) = False Then Continue For

                    Dim BrandStamp As String = GetBrandsTimeStamp(POS, FrmLogin.objcon.con)
                    Dim DtBrands = ClsBrand.GetNewBrands(BrandStamp, BoCnx)

                    Dim strconnection As String = "Data Source ='" & dt.Rows(i).Item("PosServer") & "';Initial Catalog='" & dt.Rows(i).Item("PosDatabase") & "';user ID='" & dt.Rows(i).Item("PosUser") & "';password='" & dt.Rows(i).Item("PosPass") & "';Connection Timeout = 180"
                    Dim con As SqlConnection = New SqlConnection(strconnection)
                    For j = 0 To DtBrands.Rows.Count - 1
                        Dim command As SqlCommand = con.CreateCommand()
                        command.Connection = con
                        command.CommandText = "SpRt_InsertNewBrand"
                        command.CommandType = CommandType.StoredProcedure
                        command.Parameters.AddWithValue("@BrandCode", IIf(IsNothing(DtBrands.Rows(j).Item("BrandCode")) Or IsDBNull(DtBrands.Rows(j).Item("BrandCode")), DBNull.Value, DtBrands.Rows(j).Item("BrandCode")))
                        command.Parameters.AddWithValue("@Description", IIf(IsNothing(DtBrands.Rows(j).Item("Description")) Or IsDBNull(DtBrands.Rows(j).Item("Description")), DBNull.Value, DtBrands.Rows(j).Item("Description")))
                        command.Parameters.AddWithValue("@AltDescription", IIf(IsNothing(DtBrands.Rows(j).Item("AltDescription")) Or IsDBNull(DtBrands.Rows(j).Item("AltDescription")), DBNull.Value, DtBrands.Rows(j).Item("AltDescription")))
                        sqls += CommandAsSql(command)
                    Next
                    If sqls <> "" Then
                        Dim transaction As SqlTransaction = Nothing
                        If con.State = ConnectionState.Closed Then
                            Try
                                con.Open()
                                Dim transcommand As SqlCommand = con.CreateCommand()
                                transaction = con.BeginTransaction("SampleTransaction")
                                ' Must assign both transaction object and connection
                                ' to Command object for a pending local transaction.
                                transcommand.Connection = con
                                transcommand.Transaction = transaction
                                transcommand.CommandText = sqls
                                transcommand.CommandType = CommandType.Text
                                Try
                                    transcommand.ExecuteNonQuery()
                                    transaction.Commit()
                                    Dim MaxBrandStamp = GetMaxBrandTimeStamp(BoCnx)
                                    UpdateBrandTimeStamp(MaxBrandStamp, POS, FrmLogin.objcon.con)
                                    Utilities.WriteToText("InsertNewBrands: In POS: " & POS, "Successfully Inserted")
                                Catch ex As Exception
                                    Utilities.WriteToText("InsertNewBrands: In POS: " & POS & " Commit Type Failed Due To : ", ex.GetType().ToString)
                                    Utilities.WriteToText("InsertNewBrands: In POS: " & POS & " Commit Message Failed Due To : ", ex.Message)
                                    Dim ClsLog As New ClsLogs
                                    ClsLog._BackOffice = ""
                                    ClsLog._PosCode = POS
                                    ClsLog._FunctionN = "InsertBrands"
                                    ClsLog._Desc = ex.Message
                                    ClsLog._Sql = sqls
                                    ClsLog.WriteToTable(FrmLogin.objcon.con)
                                    Try
                                        transaction.Rollback()
                                    Catch ex2 As Exception
                                        Utilities.WriteToText("InsertNewBrands: In POS: " & POS & " Rollback Type Failed Due To : ", ex2.GetType().ToString)
                                        Utilities.WriteToText("InsertNewBrands: In POS: " & POS & " Rollback Message Failed Due To : ", ex2.Message)
                                        Continue For
                                    End Try
                                Finally
                                    con.Close()
                                End Try
                            Catch ex As Exception
                                Utilities.WriteToText("InsertNewBrands: In POS: " & POS, " Connection could not be established")
                                Continue For
                            End Try
                        End If
                    End If
                Next
            Catch ex As Exception
                Utilities.WriteToText("InsertNewBrands: In POS: " & POS & " Failed Due to ", ex.Message)
            End Try
        Catch ex As Exception
            Utilities.WriteToText("InsertNewBrands: In POS: " & POS & " Failed Due to ", ex.Message)
        End Try
    End Sub
    Public Sub InsertCustomers()
        Dim POS = ""
        Dim Sqls = ""
        Try
            Dim ClsPos As New ClsPOS
            Dim dt As New DataTable
            dt = ClsPos.GetPosConfig(FrmLogin.objcon.con)
            Dim ClsThirdParty As New ClsThirdParty

            Dim BoConxString = "Data Source ='" & FrmMainForm.BOServer & "';Initial Catalog='" & FrmMainForm.BODatabase & "';user ID='" & FrmMainForm.BOUser & "';password='" & FrmMainForm.BOPass & "'"
            Dim BoCnx As SqlConnection = New SqlConnection(BoConxString)
            For i = 0 To dt.Rows.Count - 1

                Sqls = ""
                Dim strconnection As String = "Data Source ='" & dt.Rows(i).Item("PosServer") & "';Initial Catalog='" & dt.Rows(i).Item("PosDatabase") & "';user ID='" & dt.Rows(i).Item("PosUser") & "';password='" & dt.Rows(i).Item("PosPass") & "';Connection Timeout = 180"
                Dim con As SqlConnection = New SqlConnection(strconnection)
                POS = dt.Rows(i).Item("PosCode")

                If PosIsInstalled(POS) = False Then Continue For
                Dim blnconnectionOpen1 = ConnStatus(BoCnx)
                If Not blnconnectionOpen1 Then ConnOpen(BoCnx)
                Dim ThirdStamp As String = GetThirdTimeStamp(POS, FrmLogin.objcon.con)
                Dim DtNewCustomers = ClsThirdParty.BoToPosNewCustomers(ThirdStamp, BoCnx)
                For j = 0 To DtNewCustomers.Rows.Count - 1
                    Dim command As SqlCommand = con.CreateCommand()
                    command.Connection = con
                    command.CommandText = "Sp_ThirdPartyBoToPos"
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@ThirdId", DtNewCustomers.Rows(j).Item("ThirdId"))
                    command.Parameters.AddWithValue("@Name", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("Name")) Or IsNothing(DtNewCustomers.Rows(j).Item("Name")), "", DtNewCustomers.Rows(j).Item("Name")))
                    command.Parameters.AddWithValue("@ShortName", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("ShortName")) Or IsNothing(DtNewCustomers.Rows(j).Item("ShortName")), "", DtNewCustomers.Rows(j).Item("ShortName")))
                    command.Parameters.AddWithValue("@Title", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("Title")) Or IsNothing(DtNewCustomers.Rows(j).Item("Title")), "", DtNewCustomers.Rows(j).Item("Title")))
                    command.Parameters.AddWithValue("@AltName", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("AltName")) Or IsNothing(DtNewCustomers.Rows(j).Item("AltName")), "", DtNewCustomers.Rows(j).Item("AltName")))
                    command.Parameters.AddWithValue("@AltShortName", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("AltShortName")) Or IsNothing(DtNewCustomers.Rows(j).Item("AltShortName")), "", DtNewCustomers.Rows(j).Item("AltShortName")))
                    command.Parameters.AddWithValue("@ManualRef", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("ManualRef")) Or IsNothing(DtNewCustomers.Rows(j).Item("ManualRef")), "", DtNewCustomers.Rows(j).Item("ManualRef")))
                    command.Parameters.AddWithValue("@CountryId", IIf(IsNothing(DtNewCustomers.Rows(j).Item("CountryID")) Or IsDBNull(DtNewCustomers.Rows(j).Item("CountryID")), DBNull.Value, DtNewCustomers.Rows(j).Item("CountryID")))
                    command.Parameters.AddWithValue("@AreaId", IIf(IsNothing(DtNewCustomers.Rows(j).Item("AreaID")) Or IsDBNull(DtNewCustomers.Rows(j).Item("AreaID")), DBNull.Value, DtNewCustomers.Rows(j).Item("AreaID")))
                    command.Parameters.AddWithValue("@SisterCompany", IIf(IsNothing(DtNewCustomers.Rows(j).Item("SisterCompany")) Or IsDBNull(DtNewCustomers.Rows(j).Item("SisterCompany")), False, DtNewCustomers.Rows(j).Item("SisterCompany")))
                    command.Parameters.AddWithValue("@Address", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("Address")) Or IsNothing(DtNewCustomers.Rows(j).Item("Address")), "", DtNewCustomers.Rows(j).Item("Address")))
                    command.Parameters.AddWithValue("@Address2", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("Address2")) Or IsNothing(DtNewCustomers.Rows(j).Item("Address2")), "", DtNewCustomers.Rows(j).Item("Address2")))
                    command.Parameters.AddWithValue("@Address3", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("Address3")) Or IsNothing(DtNewCustomers.Rows(j).Item("Address3")), "", DtNewCustomers.Rows(j).Item("Address3")))
                    command.Parameters.AddWithValue("@Address4", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("Address4")) Or IsNothing(DtNewCustomers.Rows(j).Item("Address4")), "", DtNewCustomers.Rows(j).Item("Address4")))
                    command.Parameters.AddWithValue("@Address5", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("Address5")) Or IsNothing(DtNewCustomers.Rows(j).Item("Address5")), "", DtNewCustomers.Rows(j).Item("Address5")))
                    command.Parameters.AddWithValue("@Phone1", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("Phone1")) Or IsNothing(DtNewCustomers.Rows(j).Item("Phone1")), "", DtNewCustomers.Rows(j).Item("Phone1")))
                    command.Parameters.AddWithValue("@Phone2", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("Phone2")) Or IsNothing(DtNewCustomers.Rows(j).Item("Phone2")), "", DtNewCustomers.Rows(j).Item("Phone2")))
                    command.Parameters.AddWithValue("@Phone3", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("Phone3")) Or IsNothing(DtNewCustomers.Rows(j).Item("Phone3")), "", DtNewCustomers.Rows(j).Item("Phone3")))
                    command.Parameters.AddWithValue("@Fax", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("Fax")) Or IsNothing(DtNewCustomers.Rows(j).Item("Fax")), "", DtNewCustomers.Rows(j).Item("Fax")))
                    command.Parameters.AddWithValue("@POBOX", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("POBOX")) Or IsNothing(DtNewCustomers.Rows(j).Item("POBOX")), "", DtNewCustomers.Rows(j).Item("POBOX")))
                    command.Parameters.AddWithValue("@Email", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("Email")) Or IsNothing(DtNewCustomers.Rows(j).Item("Email")), "", DtNewCustomers.Rows(j).Item("Email")))
                    command.Parameters.AddWithValue("@Site", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("Site")) Or IsNothing(DtNewCustomers.Rows(j).Item("Site")), "", DtNewCustomers.Rows(j).Item("Site")))
                    command.Parameters.AddWithValue("@ShowInPayable", IIf(IsNothing(DtNewCustomers.Rows(j).Item("ShowInPayable")) Or IsDBNull(DtNewCustomers.Rows(j).Item("ShowInPayable")), False, DtNewCustomers.Rows(j).Item("ShowInPayable")))
                    command.Parameters.AddWithValue("@ShowInReceivable", IIf(IsNothing(DtNewCustomers.Rows(j).Item("ShowInReceivable")) Or IsDBNull(DtNewCustomers.Rows(j).Item("ShowInReceivable")), False, DtNewCustomers.Rows(j).Item("ShowInReceivable")))
                    command.Parameters.AddWithValue("@ShowInEmployee", IIf(IsNothing(DtNewCustomers.Rows(j).Item("ShowInEmployee")) Or IsDBNull(DtNewCustomers.Rows(j).Item("ShowInEmployee")), False, DtNewCustomers.Rows(j).Item("ShowInEmployee")))
                    command.Parameters.AddWithValue("@Blocked", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Blocked")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Blocked")), False, DtNewCustomers.Rows(j).Item("Blocked")))
                    command.Parameters.AddWithValue("@ContactName", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("ContactName")) Or IsNothing(DtNewCustomers.Rows(j).Item("ContactName")), "", DtNewCustomers.Rows(j).Item("ContactName")))
                    command.Parameters.AddWithValue("@ContactMail", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("ContactMail")) Or IsNothing(DtNewCustomers.Rows(j).Item("ContactMail")), "", DtNewCustomers.Rows(j).Item("ContactMail")))
                    command.Parameters.AddWithValue("@ContactPhone", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("ContactPhone")) Or IsNothing(DtNewCustomers.Rows(j).Item("ContactPhone")), "", DtNewCustomers.Rows(j).Item("ContactPhone")))
                    command.Parameters.AddWithValue("@Notes", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("Notes")) Or IsNothing(DtNewCustomers.Rows(j).Item("Notes")), "", DtNewCustomers.Rows(j).Item("Notes")))
                    command.Parameters.AddWithValue("@VatREG", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("VatReg")) Or IsNothing(DtNewCustomers.Rows(j).Item("VatReg")), "", DtNewCustomers.Rows(j).Item("VatReg")))
                    command.Parameters.AddWithValue("@iUser", FrmLogin.user)
                    command.Parameters.AddWithValue("@idate", Today.Date)
                    command.Parameters.AddWithValue("@ThirdFinNb", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("ThirdFinNB")) Or IsNothing(DtNewCustomers.Rows(j).Item("ThirdFinNB")), "", DtNewCustomers.Rows(j).Item("ThirdFinNB")))
                    command.Parameters.AddWithValue("@bank1", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("bank1")) Or IsNothing(DtNewCustomers.Rows(j).Item("bank1")), "", DtNewCustomers.Rows(j).Item("bank1")))
                    command.Parameters.AddWithValue("@bank", "")
                    command.Parameters.AddWithValue("@bank2", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("bank2")) Or IsNothing(DtNewCustomers.Rows(j).Item("bank2")), "", DtNewCustomers.Rows(j).Item("bank2")))
                    command.Parameters.AddWithValue("@bank3", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("bank3")) Or IsNothing(DtNewCustomers.Rows(j).Item("bank3")), "", DtNewCustomers.Rows(j).Item("bank3")))
                    command.Parameters.AddWithValue("@bank4", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("bank4")) Or IsNothing(DtNewCustomers.Rows(j).Item("bank4")), "", DtNewCustomers.Rows(j).Item("bank4")))
                    command.Parameters.AddWithValue("@bank5", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("bank5")) Or IsNothing(DtNewCustomers.Rows(j).Item("bank5")), "", DtNewCustomers.Rows(j).Item("bank5")))
                    command.Parameters.AddWithValue("@bank6", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("bank6")) Or IsNothing(DtNewCustomers.Rows(j).Item("bank6")), "", DtNewCustomers.Rows(j).Item("bank6")))
                    command.Parameters.AddWithValue("@bank7", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("bank7")) Or IsNothing(DtNewCustomers.Rows(j).Item("bank7")), "", DtNewCustomers.Rows(j).Item("bank7")))
                    command.Parameters.AddWithValue("@bank8", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("bank8")) Or IsNothing(DtNewCustomers.Rows(j).Item("bank8")), "", DtNewCustomers.Rows(j).Item("bank8")))
                    command.Parameters.AddWithValue("@bank9", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("bank9")) Or IsNothing(DtNewCustomers.Rows(j).Item("bank9")), "", DtNewCustomers.Rows(j).Item("bank9")))
                    command.Parameters.AddWithValue("@bank10", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("bank10")) Or IsNothing(DtNewCustomers.Rows(j).Item("bank10")), "", DtNewCustomers.Rows(j).Item("bank10")))
                    command.Parameters.AddWithValue("@bank11", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("bank11")) Or IsNothing(DtNewCustomers.Rows(j).Item("bank11")), "", DtNewCustomers.Rows(j).Item("bank11")))
                    Sqls += CommandAsSql(command)

                    'SaveThirdExtra
                    Dim command2 As SqlCommand = con.CreateCommand()
                    command2.Connection = con
                    command2.CommandText = "Sp_ThirdExtraBoToPos"
                    command2.CommandType = CommandType.StoredProcedure

                    command2.Parameters.AddWithValue("@ThirdId", IIf(IsNothing(DtNewCustomers.Rows(j).Item("ThirdId")) Or IsDBNull(DtNewCustomers.Rows(j).Item("ThirdId")), DBNull.Value, DtNewCustomers.Rows(j).Item("ThirdId")))
                    command2.Parameters.AddWithValue("@CollectorId", IIf(IsNothing(DtNewCustomers.Rows(j).Item("CollectorID")) Or IsDBNull(DtNewCustomers.Rows(j).Item("CollectorID")), DBNull.Value, DtNewCustomers.Rows(j).Item("CollectorID")))
                    command2.Parameters.AddWithValue("@SalesManId", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("SalesManID")) Or IsNothing(DtNewCustomers.Rows(j).Item("SalesManID")), DBNull.Value, DtNewCustomers.Rows(j).Item("SalesManID")))
                    command2.Parameters.AddWithValue("@Stk_ThirdGroupid", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("Stk_ThirdGroupId")) Or IsNothing(DtNewCustomers.Rows(j).Item("Stk_ThirdGroupId")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_ThirdGroupId")))
                    command2.Parameters.AddWithValue("@Stk_CustCatId", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("Stk_CustCatID")) Or IsNothing(DtNewCustomers.Rows(j).Item("Stk_CustCatID")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_CustCatID")))
                    command2.Parameters.AddWithValue("@Stk_CustCurCode", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("Stk_CustCurCode")) Or IsNothing(DtNewCustomers.Rows(j).Item("Stk_CustCurCode")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_CustCurCode")))
                    command2.Parameters.AddWithValue("@Stk_CustPriceCode", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("Stk_CustPriceCode")) Or IsNothing(DtNewCustomers.Rows(j).Item("Stk_CustPriceCode")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_CustPriceCode")))
                    command2.Parameters.AddWithValue("@Stk_CustSalesList", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("Stk_CustSalesList")) Or IsNothing(DtNewCustomers.Rows(j).Item("Stk_CustSalesList")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_CustSalesList")))
                    command2.Parameters.AddWithValue("@Stk_CustBlocked", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_CustBlocked")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_CustBlocked")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_CustBlocked")))
                    command2.Parameters.AddWithValue("@Stk_CustApplyVat", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_CustApplyVat")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_CustApplyVat")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_CustApplyVat")))
                    command2.Parameters.AddWithValue("@Stk_CustDirectPost", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_CustDirectPost")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_CustDirectPost")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_CustDirectPost")))
                    command2.Parameters.AddWithValue("@Stk_CustGroupInPosting", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_CustGroupInPosting")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_CustGroupInPosting")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_CustGroupInPosting")))
                    command2.Parameters.AddWithValue("@STK_CustMarkUp", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_CustMarkUp")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_CustMarkUp")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_CustMarkUp")))
                    command2.Parameters.AddWithValue("@Stk_CustDisc1", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_CustDisc1")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_CustDisc1")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_CustDisc1")))
                    command2.Parameters.AddWithValue("@Stk_CustDisc2", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_CustDisc2")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_CustDisc2")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_CustDisc2")))
                    command2.Parameters.AddWithValue("@Stk_CustRetailCredit", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_CustRetailCredit")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_CustRetailCredit")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_CustRetailCredit")))
                    command2.Parameters.AddWithValue("@Stk_CustAppearInRetail", 1)
                    command2.Parameters.AddWithValue("@Stk_CustLimit", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_CustLimit")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_CustLimit")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_CustLimit")))
                    command2.Parameters.AddWithValue("@Stk_CustLimitAllCmp", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_CustLimitAllCmp")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_CustLimitAllCmp")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_CustLimitAllCmp")))
                    command2.Parameters.AddWithValue("@Stk_CustLimitAllLedger", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_CustLimitAllLedger")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_CustLimitAllLedger")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_CustLimitAllLedger")))
                    command2.Parameters.AddWithValue("@Stk_CustTerms", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_CustTerms")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_CustTerms")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_CustTerms")))
                    command2.Parameters.AddWithValue("@Stk_CustDeliver1", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_CustDeliver1")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_CustDeliver1")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_CustDeliver1")))
                    command2.Parameters.AddWithValue("@Stk_CustDeliver2", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_CustDeliver2")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_CustDeliver2")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_CustDeliver2")))
                    command2.Parameters.AddWithValue("@Stk_CustDeliver3", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_CustDeliver3")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_CustDeliver3")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_CustDeliver3")))
                    command2.Parameters.AddWithValue("@Stk_SupCatId", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_SupCatID")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_SupCatID")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_SupCatID")))
                    command2.Parameters.AddWithValue("@Stk_SupCurCode", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("Stk_SupCurCode")) Or IsNothing(DtNewCustomers.Rows(j).Item("Stk_SupCurCode")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_SupCurCode")))
                    command2.Parameters.AddWithValue("@Stk_SupPriceCode", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_SupPriceCode")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_SupPriceCode")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_SupPriceCode")))
                    command2.Parameters.AddWithValue("@Stk_SupDirectPost", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_SupDirectPost")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_SupDirectPost")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_SupDirectPost")))
                    command2.Parameters.AddWithValue("@Stk_SupGroupInPosting", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_SupGroupInPosting")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_SupGroupInPosting")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_SupGroupInPosting")))
                    command2.Parameters.AddWithValue("@Stk_SupApplyVat", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_SupApplyVat")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_SupApplyVat")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_SupApplyVat")))
                    command2.Parameters.AddWithValue("@Stk_Suplimit", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_SupLimit")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_SupLimit")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_SupLimit")))
                    command2.Parameters.AddWithValue("@Stk_SupLimitAllCmp", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_SupLimitAllCmp")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_SupLimitAllCmp")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_SupLimitAllCmp")))
                    command2.Parameters.AddWithValue("@Stk_SupLimitAllLedger", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_SupLimitAllLedger")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_SupLimitAllLedger")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_SupLimitAllLedger")))
                    command2.Parameters.AddWithValue("@Stk_SupTerms", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_SupTerms")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_SupTerms")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_SupTerms")))
                    command2.Parameters.AddWithValue("@Stk_SupBlocked", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_SupBlocked")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_SupBlocked")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_SupBlocked")))
                    command2.Parameters.AddWithValue("@Stk_SalCatId", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_SalCatID")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_SalCatID")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_SalCatID")))
                    command2.Parameters.AddWithValue("@Stk_SalCommission", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_SalCommission")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_SalCommission")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_SalCommission")))
                    command2.Parameters.AddWithValue("@Stk_SalSpervisorCom", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_SalSpervisorCom")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_SalSpervisorCom")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_SalSpervisorCom")))
                    command2.Parameters.AddWithValue("@Stk_SalBlocked", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_SalBlocked")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_SalBlocked")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_SalBlocked")))
                    command2.Parameters.AddWithValue("@Stk_CustPoints", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_CustPoints")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_CustPoints")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_CustPoints")))
                    command2.Parameters.AddWithValue("@BankLimit", 0)
                    command2.Parameters.AddWithValue("@Stk_PostToThirdid", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("Stk_PostToThirdID")) Or IsNothing(DtNewCustomers.Rows(j).Item("Stk_PostToThirdID")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_PostToThirdID")))
                    command2.Parameters.AddWithValue("@DeliveryTerms", IIf(IsNothing(DtNewCustomers.Rows(j).Item("DeliveryTerms")) Or IsDBNull(DtNewCustomers.Rows(j).Item("DeliveryTerms")), DBNull.Value, DtNewCustomers.Rows(j).Item("DeliveryTerms")))
                    command2.Parameters.AddWithValue("@PaymentTerms", IIf(IsNothing(DtNewCustomers.Rows(j).Item("PaymentTerms")) Or IsDBNull(DtNewCustomers.Rows(j).Item("PaymentTerms")), DBNull.Value, DtNewCustomers.Rows(j).Item("PaymentTerms")))
                    command2.Parameters.AddWithValue("@OperMess", IIf(IsNothing(DtNewCustomers.Rows(j).Item("OperMess")) Or IsDBNull(DtNewCustomers.Rows(j).Item("OperMess")), DBNull.Value, DtNewCustomers.Rows(j).Item("OperMess")))
                    command2.Parameters.AddWithValue("@collector2id", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("Collector2ID")) Or IsNothing(DtNewCustomers.Rows(j).Item("Collector2ID")), DBNull.Value, DtNewCustomers.Rows(j).Item("Collector2ID")))
                    Sqls += CommandAsSql(command2)
                Next
                If Sqls <> "" Then
                    Dim transaction As SqlTransaction = Nothing
                    If con.State = ConnectionState.Closed Then
                        Try
                            con.Open()
                            Dim transcommand As SqlCommand = con.CreateCommand()
                            transaction = con.BeginTransaction("SampleTransaction")
                            transcommand.Connection = con
                            transcommand.Transaction = transaction
                            transcommand.CommandText = Sqls
                            transcommand.CommandType = CommandType.Text
                            Try
                                transcommand.ExecuteNonQuery()
                                transaction.Commit()
                                Dim MaxThirdStamp = GetMaxThirdTimeStamp(BoCnx)
                                UpdateThirdTimeStamp(MaxThirdStamp, POS, FrmLogin.objcon.con)
                                Utilities.WriteToText("InsertCustomer In POS: " & POS & ": ", "Successfully Inserted")
                            Catch ex As Exception
                                Utilities.WriteToText("InsertCustomer In POS: " & POS & " Commit Type Failed Due To : ", ex.GetType().ToString)
                                Utilities.WriteToText("InsertCustomer In POS: " & POS & " Commit Message Failed Due To : ", ex.Message)
                                Dim ClsLog As New ClsLogs
                                ClsLog._BackOffice = ""
                                ClsLog._PosCode = POS
                                ClsLog._FunctionN = "InsertCustomers"
                                ClsLog._Desc = ex.Message
                                ClsLog._Sql = Sqls
                                ClsLog.WriteToTable(FrmLogin.objcon.con)
                                Try
                                    transaction.Rollback()
                                Catch ex2 As Exception
                                    Utilities.WriteToText("InsertCustomer In POS: " & POS & " Rollback Type Failed Due To : ", ex2.GetType().ToString)
                                    Utilities.WriteToText("InsertCustomer In POS: " & POS & " Rollback Message Failed Due To : ", ex2.Message)
                                End Try
                            Finally
                                con.Close()
                            End Try
                        Catch ex As Exception
                            Utilities.WriteToText("InsertCustomer In POS: " & POS & ": ", " Connection could not be established")
                        End Try
                    End If
                End If
            Next
        Catch ex As Exception
            Utilities.WriteToText("InsertCustomer In POS: " & POS & " Failed Due To: ", ex.Message)
        End Try
    End Sub
    Public Sub SaveThirdExtra(ByVal thirdid As Integer, ByVal dt As DataTable, ByVal i As Integer, ByVal Con As SqlConnection)
        Try
            Dim ClsThirdExtra As New ClsThirdExtra
            ClsThirdExtra._ThirdId = thirdid
            ClsThirdExtra._CollectorId = dt.Rows(i).Item("CollectorID")
            ClsThirdExtra._collector2id = IIf(IsDBNull(dt.Rows(i).Item("Collector2ID")) Or IsNothing(dt.Rows(i).Item("Collector2ID")), DBNull.Value, dt.Rows(i).Item("Collector2ID"))
            ClsThirdExtra._SalesManId = IIf(IsDBNull(dt.Rows(i).Item("SalesManID")) Or IsNothing(dt.Rows(i).Item("SalesManID")), DBNull.Value, dt.Rows(i).Item("SalesManID"))
            ClsThirdExtra._Stk_ThirdGroupid = IIf(IsDBNull(dt.Rows(i).Item("Stk_ThirdGroupId")) Or IsNothing(dt.Rows(i).Item("Stk_ThirdGroupId")), DBNull.Value, dt.Rows(i).Item("Stk_ThirdGroupId"))
            ClsThirdExtra._Stk_PostToThirdid = IIf(IsDBNull(dt.Rows(i).Item("Stk_PostToThirdID")) Or IsNothing(dt.Rows(i).Item("Stk_PostToThirdID")), DBNull.Value, dt.Rows(i).Item("Stk_PostToThirdID"))
            ClsThirdExtra._Stk_CustCatId = IIf(IsDBNull(dt.Rows(i).Item("Stk_CustCatID")) Or IsNothing(dt.Rows(i).Item("Stk_CustCatID")), DBNull.Value, dt.Rows(i).Item("Stk_CustCatID"))
            ClsThirdExtra._Stk_CustPriceCode = IIf(IsDBNull(dt.Rows(i).Item("Stk_CustPriceCode")) Or IsNothing(dt.Rows(i).Item("Stk_CustPriceCode")), DBNull.Value, dt.Rows(i).Item("Stk_CustPriceCode"))
            ClsThirdExtra._Stk_CustSalesList = IIf(IsDBNull(dt.Rows(i).Item("Stk_CustSalesList")) Or IsNothing(dt.Rows(i).Item("Stk_CustSalesList")), DBNull.Value, dt.Rows(i).Item("Stk_CustSalesList"))
            ClsThirdExtra._Stk_CustCurCode = IIf(IsDBNull(dt.Rows(i).Item("Stk_CustCurCode")) Or IsNothing(dt.Rows(i).Item("Stk_CustCurCode")), DBNull.Value, dt.Rows(i).Item("Stk_CustCurCode"))
            ClsThirdExtra._Stk_CustAppearInRetail = 1
            ClsThirdExtra._Stk_CustApplyVat = dt.Rows(i).Item("Stk_CustApplyVat")
            ClsThirdExtra._Stk_CustBlocked = dt.Rows(i).Item("Stk_CustBlocked")
            ClsThirdExtra._Stk_CustDirectPost = dt.Rows(i).Item("Stk_CustDirectPost")
            ClsThirdExtra._Stk_CustGroupInPosting = dt.Rows(i).Item("Stk_CustGroupInPosting")
            ClsThirdExtra._STK_CustMarkUp = dt.Rows(i).Item("Stk_CustMarkUp")
            ClsThirdExtra._Stk_CustDisc1 = dt.Rows(i).Item("Stk_CustDisc1")
            ClsThirdExtra._Stk_CustDisc2 = dt.Rows(i).Item("Stk_CustDisc2")
            ClsThirdExtra._Stk_CustLimit = dt.Rows(i).Item("Stk_CustLimit")
            ClsThirdExtra._Stk_CustTerms = dt.Rows(i).Item("Stk_CustTerms")
            ClsThirdExtra._Stk_CustPoints = dt.Rows(i).Item("Stk_CustPoints")
            ClsThirdExtra._Stk_CustRetailCredit = dt.Rows(i).Item("Stk_CustRetailCredit")
            ClsThirdExtra._Stk_CustLimitAllCmp = dt.Rows(i).Item("Stk_CustLimitAllCmp")
            ClsThirdExtra._Stk_CustLimitAllLedger = dt.Rows(i).Item("Stk_CustLimitAllLedger")
            ClsThirdExtra._PaymentTerms = dt.Rows(i).Item("PaymentTerms")
            ClsThirdExtra._DeliveryTerms = dt.Rows(i).Item("DeliveryTerms")
            ClsThirdExtra._OperMess = dt.Rows(i).Item("OperMess")

            ClsThirdExtra._Stk_SupApplyVat = dt.Rows(i).Item("Stk_SupApplyVat")
            ClsThirdExtra._Stk_SupBlocked = dt.Rows(i).Item("Stk_SupBlocked")
            ClsThirdExtra._Stk_SupDirectPost = dt.Rows(i).Item("Stk_SupDirectPost")
            ClsThirdExtra._Stk_SupGroupInPosting = dt.Rows(i).Item("Stk_SupGroupInPosting")
            ClsThirdExtra._Stk_SupCatId = dt.Rows(i).Item("Stk_SupCatID")
            ClsThirdExtra._Stk_SupPriceCode = dt.Rows(i).Item("Stk_SupPriceCode")
            ClsThirdExtra._Stk_SupCurCode = IIf(IsDBNull(dt.Rows(i).Item("Stk_SupCurCode")) Or IsNothing(dt.Rows(i).Item("Stk_SupCurCode")), DBNull.Value, dt.Rows(i).Item("Stk_SupCurCode"))
            ClsThirdExtra._Stk_SupLimitAllCmp = dt.Rows(i).Item("Stk_SupLimitAllCmp")
            ClsThirdExtra._Stk_SupLimitAllLedger = dt.Rows(i).Item("Stk_SupLimitAllLedger")
            ClsThirdExtra._Stk_Suplimit = dt.Rows(i).Item("Stk_SupLimit")
            ClsThirdExtra._Stk_SupTerms = dt.Rows(i).Item("Stk_SupTerms")
            ClsThirdExtra._Stk_SalBlocked = dt.Rows(i).Item("Stk_SalBlocked")
            ClsThirdExtra._Stk_SalCatId = dt.Rows(i).Item("Stk_SalCatID")
            ClsThirdExtra._Stk_SalCommission = dt.Rows(i).Item("Stk_SalCommission")
            ClsThirdExtra._Stk_SalSpervisorCom = dt.Rows(i).Item("Stk_SalSpervisorCom")
            ClsThirdExtra._Stk_CustDeliver1 = dt.Rows(i).Item("Stk_CustDeliver1")
            ClsThirdExtra._Stk_CustDeliver2 = dt.Rows(i).Item("Stk_CustDeliver2")
            ClsThirdExtra._Stk_CustDeliver3 = dt.Rows(i).Item("Stk_CustDeliver3")
            ClsThirdExtra.ThirdExtraBoToPOS(Con)
        Catch ex As Exception
            Utilities.WriteToText("SaveThirdExtra Failed Due To: ", ex.Message)
        End Try
    End Sub
    Public Sub UpdateThirdExtra(ByVal thirdid As Integer, ByVal dt As DataTable, ByVal i As Integer, ByVal Con As SqlConnection)
        Try
            Dim ClsThirdExtra As New ClsThirdExtra
            ClsThirdExtra._ThirdId = thirdid
            ClsThirdExtra._CollectorId = dt.Rows(i).Item("CollectorID")
            ClsThirdExtra._collector2id = IIf(IsDBNull(dt.Rows(i).Item("Collector2ID")) Or IsNothing(dt.Rows(i).Item("Collector2ID")), DBNull.Value, dt.Rows(i).Item("Collector2ID"))
            ClsThirdExtra._SalesManId = IIf(IsDBNull(dt.Rows(i).Item("SalesManID")) Or IsNothing(dt.Rows(i).Item("SalesManID")), DBNull.Value, dt.Rows(i).Item("SalesManID"))
            ClsThirdExtra._Stk_ThirdGroupid = IIf(IsDBNull(dt.Rows(i).Item("Stk_ThirdGroupId")) Or IsNothing(dt.Rows(i).Item("Stk_ThirdGroupId")), DBNull.Value, dt.Rows(i).Item("Stk_ThirdGroupId"))
            ClsThirdExtra._Stk_PostToThirdid = IIf(IsDBNull(dt.Rows(i).Item("Stk_PostToThirdID")) Or IsNothing(dt.Rows(i).Item("Stk_PostToThirdID")), DBNull.Value, dt.Rows(i).Item("Stk_PostToThirdID"))
            ClsThirdExtra._Stk_CustCatId = IIf(IsDBNull(dt.Rows(i).Item("Stk_CustCatID")) Or IsNothing(dt.Rows(i).Item("Stk_CustCatID")), DBNull.Value, dt.Rows(i).Item("Stk_CustCatID"))
            ClsThirdExtra._Stk_CustPriceCode = IIf(IsDBNull(dt.Rows(i).Item("Stk_CustPriceCode")) Or IsNothing(dt.Rows(i).Item("Stk_CustPriceCode")), DBNull.Value, dt.Rows(i).Item("Stk_CustPriceCode"))
            ClsThirdExtra._Stk_CustSalesList = IIf(IsDBNull(dt.Rows(i).Item("Stk_CustSalesList")) Or IsNothing(dt.Rows(i).Item("Stk_CustSalesList")), DBNull.Value, dt.Rows(i).Item("Stk_CustSalesList"))
            ClsThirdExtra._Stk_CustCurCode = IIf(IsDBNull(dt.Rows(i).Item("Stk_CustCurCode")) Or IsNothing(dt.Rows(i).Item("Stk_CustCurCode")), DBNull.Value, dt.Rows(i).Item("Stk_CustCurCode"))
            ClsThirdExtra._Stk_CustAppearInRetail = 1
            ClsThirdExtra._Stk_CustApplyVat = dt.Rows(i).Item("Stk_CustApplyVat")
            ClsThirdExtra._Stk_CustBlocked = dt.Rows(i).Item("Stk_CustBlocked")
            ClsThirdExtra._Stk_CustDirectPost = dt.Rows(i).Item("Stk_CustDirectPost")
            ClsThirdExtra._Stk_CustGroupInPosting = dt.Rows(i).Item("Stk_CustGroupInPosting")
            ClsThirdExtra._STK_CustMarkUp = dt.Rows(i).Item("Stk_CustMarkUp")
            ClsThirdExtra._Stk_CustDisc1 = dt.Rows(i).Item("Stk_CustDisc1")
            ClsThirdExtra._Stk_CustDisc2 = dt.Rows(i).Item("Stk_CustDisc2")
            ClsThirdExtra._Stk_CustLimit = dt.Rows(i).Item("Stk_CustLimit")
            ClsThirdExtra._Stk_CustTerms = dt.Rows(i).Item("Stk_CustTerms")
            ClsThirdExtra._Stk_CustPoints = dt.Rows(i).Item("Stk_CustPoints")
            ClsThirdExtra._Stk_CustRetailCredit = dt.Rows(i).Item("Stk_CustRetailCredit")
            ClsThirdExtra._Stk_CustLimitAllCmp = dt.Rows(i).Item("Stk_CustLimitAllCmp")
            ClsThirdExtra._Stk_CustLimitAllLedger = dt.Rows(i).Item("Stk_CustLimitAllLedger")
            ClsThirdExtra._PaymentTerms = dt.Rows(i).Item("PaymentTerms")
            ClsThirdExtra._DeliveryTerms = dt.Rows(i).Item("DeliveryTerms")
            ClsThirdExtra._OperMess = dt.Rows(i).Item("OperMess")

            ClsThirdExtra._Stk_SupApplyVat = dt.Rows(i).Item("Stk_SupApplyVat")
            ClsThirdExtra._Stk_SupBlocked = dt.Rows(i).Item("Stk_SupBlocked")
            ClsThirdExtra._Stk_SupDirectPost = dt.Rows(i).Item("Stk_SupDirectPost")
            ClsThirdExtra._Stk_SupGroupInPosting = dt.Rows(i).Item("Stk_SupGroupInPosting")
            ClsThirdExtra._Stk_SupCatId = dt.Rows(i).Item("Stk_SupCatID")
            ClsThirdExtra._Stk_SupPriceCode = dt.Rows(i).Item("Stk_SupPriceCode")
            ClsThirdExtra._Stk_SupCurCode = IIf(IsDBNull(dt.Rows(i).Item("Stk_SupCurCode")) Or IsNothing(dt.Rows(i).Item("Stk_SupCurCode")), DBNull.Value, dt.Rows(i).Item("Stk_SupCurCode"))
            ClsThirdExtra._Stk_SupLimitAllCmp = dt.Rows(i).Item("Stk_SupLimitAllCmp")
            ClsThirdExtra._Stk_SupLimitAllLedger = dt.Rows(i).Item("Stk_SupLimitAllLedger")
            ClsThirdExtra._Stk_Suplimit = dt.Rows(i).Item("Stk_SupLimit")
            ClsThirdExtra._Stk_SupTerms = dt.Rows(i).Item("Stk_SupTerms")
            ClsThirdExtra._Stk_SalBlocked = dt.Rows(i).Item("Stk_SalBlocked")
            ClsThirdExtra._Stk_SalCatId = dt.Rows(i).Item("Stk_SalCatID")
            ClsThirdExtra._Stk_SalCommission = dt.Rows(i).Item("Stk_SalCommission")
            ClsThirdExtra._Stk_SalSpervisorCom = dt.Rows(i).Item("Stk_SalSpervisorCom")
            ClsThirdExtra._Stk_CustDeliver1 = dt.Rows(i).Item("Stk_CustDeliver1")
            ClsThirdExtra._Stk_CustDeliver2 = dt.Rows(i).Item("Stk_CustDeliver2")
            ClsThirdExtra._Stk_CustDeliver3 = dt.Rows(i).Item("Stk_CustDeliver3")
            ClsThirdExtra.ThirdExtraBoToPOS(FrmLogin.objcon.con)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Utilities.WriteToText("UpdateThirdExtra Failed Due To: ", ex.Message)
        End Try
    End Sub
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Try
            If Sync = 0 Then
                Exit Sub
            End If
            If CustomersWorker.IsBusy = True Then
            Else
                CustomersWorker.RunWorkerAsync()
            End If
            If PriceListWorker.IsBusy = True Then
            Else
                PriceListWorker.RunWorkerAsync()
            End If
        Catch ex As Exception
            Utilities.WriteToText("TimerTick Failed Due To: ", ex.Message)
        End Try
    End Sub
    Public Sub GetChangedPriceList1()
        Dim Pos = ""
        Dim ItemAID = ""
        Try
            Dim ClsPos As New ClsPOS
            Dim clsPriceList As New ClsPriceList
            Dim dt As New DataTable
            If FrmLogin.objcon.con.State = ConnectionState.Closed Then
                FrmLogin.objcon.con.Open()
            End If
            dt = ClsPos.GetPosConfig(FrmLogin.objcon.con)
            Dim BoConxString = "Data Source ='" & FrmMainForm.BOServer & "';Initial Catalog='" & FrmMainForm.BODatabase & "';user ID='" & FrmMainForm.BOUser & "';password='" & FrmMainForm.BOPass & "'"
            Dim BoCnx As SqlConnection = New SqlConnection(BoConxString)
            Dim blnconnectionOpen1 = ConnStatus(BoCnx)
            If Not blnconnectionOpen1 Then ConnOpen(BoCnx)
            Dim sqls = ""
            Dim transaction As SqlTransaction
            Try
                For i = 0 To dt.Rows.Count - 1
                    sqls = ""
                    Dim strconnection As String = "Data Source ='" & dt.Rows(i).Item("PosServer") & "';Initial Catalog='" & dt.Rows(i).Item("PosDatabase") & "';user ID='" & dt.Rows(i).Item("PosUser") & "';password='" & dt.Rows(i).Item("PosPass") & "';Connection Timeout = 300"
                    Dim con As SqlConnection = New SqlConnection(strconnection)
                    Pos = dt.Rows(i).Item("POSCode")

                    If PosIsInstalled(Pos) = False Then Continue For
                    Dim PlStamp As String = GetPLTimeStamp(Pos, FrmLogin.objcon.con)
                    Dim DtPriceList = clsPriceList.GetChangedPriceList(PlStamp, PriceList, BoCnx)

                    If DtPriceList.Rows.Count = 0 Then Continue For
                    For j = 0 To DtPriceList.Rows.Count - 1
                        Dim command As SqlCommand = con.CreateCommand()
                        command.Connection = con
                        command.CommandText = "SpIv_BoInsertToPriceList"
                        command.CommandType = CommandType.StoredProcedure
                        command.Parameters.AddWithValue("@ListCode", IIf(IsNothing(DtPriceList.Rows(j).Item("ListCode")) Or IsDBNull(DtPriceList.Rows(j).Item("ListCode")), DBNull.Value, DtPriceList.Rows(j).Item("ListCode")))
                        command.Parameters.AddWithValue("@ItemAid", IIf(IsNothing(DtPriceList.Rows(j).Item("ItemAid")) Or IsDBNull(DtPriceList.Rows(j).Item("ItemAid")), DBNull.Value, DtPriceList.Rows(j).Item("ItemAid")))
                        ItemAID = IIf(IsNothing(DtPriceList.Rows(j).Item("ItemAid")) Or IsDBNull(DtPriceList.Rows(j).Item("ItemAid")), "", DtPriceList.Rows(j).Item("ItemAid"))
                        command.Parameters.AddWithValue("@ItemBid", IIf(IsNothing(DtPriceList.Rows(j).Item("ItemBid")) Or IsDBNull(DtPriceList.Rows(j).Item("ItemBid")), DBNull.Value, DtPriceList.Rows(j).Item("ItemBid")))
                        command.Parameters.AddWithValue("@DiscPct", IIf(IsNothing(DtPriceList.Rows(j).Item("DiscPct")) Or IsDBNull(DtPriceList.Rows(j).Item("DiscPct")), DBNull.Value, DtPriceList.Rows(j).Item("DiscPct")))
                        command.Parameters.AddWithValue("@Price", IIf(IsNothing(DtPriceList.Rows(j).Item("Price")) Or IsDBNull(DtPriceList.Rows(j).Item("Price")), DBNull.Value, DtPriceList.Rows(j).Item("Price")))
                        command.Parameters.AddWithValue("@PromoPrice", IIf(IsNothing(DtPriceList.Rows(j).Item("PromoPrice")) Or IsDBNull(DtPriceList.Rows(j).Item("PromoPrice")), DBNull.Value, DtPriceList.Rows(j).Item("PromoPrice")))
                        command.Parameters.AddWithValue("@Iuser", IIf(IsNothing(DtPriceList.Rows(j).Item("Iuser")) Or IsDBNull(DtPriceList.Rows(j).Item("Iuser")), DBNull.Value, DtPriceList.Rows(j).Item("Iuser")))
                        command.Parameters.AddWithValue("@Uuser", IIf(IsNothing(DtPriceList.Rows(j).Item("Uuser")) Or IsDBNull(DtPriceList.Rows(j).Item("Uuser")), DBNull.Value, DtPriceList.Rows(j).Item("Uuser")))
                        command.Parameters.AddWithValue("@LastTonPrice", IIf(IsNothing(DtPriceList.Rows(j).Item("LastTonPrice")) Or IsDBNull(DtPriceList.Rows(j).Item("LastTonPrice")), DBNull.Value, DtPriceList.Rows(j).Item("LastTonPrice")))
                        command.Parameters.AddWithValue("@LastMargin", IIf(IsNothing(DtPriceList.Rows(j).Item("LastMargin")) Or IsDBNull(DtPriceList.Rows(j).Item("LastMargin")), DBNull.Value, DtPriceList.Rows(j).Item("LastMargin")))
                        command.Parameters.AddWithValue("@PriceBuiltOn", IIf(IsNothing(DtPriceList.Rows(j).Item("PriceBuiltOn")) Or IsDBNull(DtPriceList.Rows(j).Item("PriceBuiltOn")), DBNull.Value, DtPriceList.Rows(j).Item("PriceBuiltOn")))
                        command.Parameters.AddWithValue("@changed", IIf(IsNothing(DtPriceList.Rows(j).Item("Changed")) Or IsDBNull(DtPriceList.Rows(j).Item("Changed")), 0, DtPriceList.Rows(j).Item("Changed")))
                        sqls += CommandAsSql(command)

                    Next
                    If sqls = "" Then Continue For
                    If con.State = ConnectionState.Closed Then
                        Try
                            con.Open()
                            Dim transcommand As SqlCommand = con.CreateCommand()
                            transaction = con.BeginTransaction("SampleTransaction")
                            ' Must assign both transaction object and connection
                            ' to Command object for a pending local transaction.
                            transcommand.Connection = con
                            transcommand.Transaction = transaction
                            transcommand.CommandText = sqls
                            transcommand.CommandType = CommandType.Text
                            Try
                                transcommand.ExecuteNonQuery()
                                transaction.Commit()
                                Dim MaxPLStamp = GetMaxPlTimeStamp(FrmMainForm.PriceList, BoCnx)
                                UpdatePlTimeStamp(MaxPLStamp, Pos, FrmLogin.objcon.con)
                                Utilities.WriteToText("InsertPriceList: ", " PriceList was successfully sent to POS: " & Pos)
                            Catch ex As Exception
                                Utilities.WriteToText("InsertPriceList In POS: " & Pos & " Commit Type Failed Due To : ", ex.GetType().ToString)
                                Utilities.WriteToText("InsertPriceList In POS: " & Pos & " Commit Message Failed Due To : ", ex.Message)
                                Dim ClsLog As New ClsLogs
                                ClsLog._BackOffice = ""
                                ClsLog._PosCode = Pos
                                ClsLog._FunctionN = "InsertPriceList"
                                ClsLog._Desc = ex.Message
                                ClsLog._Sql = sqls
                                ClsLog.WriteToTable(FrmLogin.objcon.con)
                                Try
                                    transaction.Rollback()
                                Catch ex2 As Exception
                                    Utilities.WriteToText("InsertPriceList In POS: " & Pos & " Rollback Type Failed Due To : ", ex2.GetType().ToString)
                                    Utilities.WriteToText("InsertPriceList In POS: " & Pos & " Rollback Message Failed Due To : ", ex2.Message)
                                    Continue For
                                End Try
                            Finally
                                con.Close()
                            End Try
                        Catch ex As Exception
                            Utilities.WriteToText("InsertPriceList In POS: " & Pos, " Connection could not be established")
                            Continue For
                        End Try
                    End If
                Next
            Catch ex As Exception
                Utilities.WriteToText("InsertPriceList: ItemAID = " & ItemAID & " In POS: " & Pos & " Failed Due TO: ", ex.Message)
            End Try
        Catch ex As Exception
            Utilities.WriteToText("InsertPriceList:  ItemAID = " & ItemAID & " In POS: " & Pos & " Failed Due To: ", ex.Message)
        End Try
    End Sub
    Public Sub InsertItemsA()
        Dim POS = ""
        Dim sqls = ""
        Try
            Dim ClsPos As New ClsPOS
            Dim dt As New DataTable
            dt = ClsPos.GetPosConfig(FrmLogin.objcon.con)
            Dim ClsItemA As New ClsItemA
            Dim BoConxString = "Data Source ='" & FrmMainForm.BOServer & "';Initial Catalog='" & FrmMainForm.BODatabase & "';user ID='" & FrmMainForm.BOUser & "';password='" & FrmMainForm.BOPass & "'"
            Dim BoCnx As SqlConnection = New SqlConnection(BoConxString)
            Dim blnconnectionOpen1 As Boolean
            Try
                For i = 0 To dt.Rows.Count - 1

                    sqls = ""
                    Dim strconnection As String = "Data Source ='" & dt.Rows(i).Item("PosServer") & "';Initial Catalog='" & dt.Rows(i).Item("PosDatabase") & "';user ID='" & dt.Rows(i).Item("PosUser") & "';password='" & dt.Rows(i).Item("PosPass") & "';Connection Timeout = 320"
                    Dim con As SqlConnection = New SqlConnection(strconnection)
                    POS = dt.Rows(i).Item("PosCode")

                    blnconnectionOpen1 = ConnStatus(BoCnx)
                    If Not blnconnectionOpen1 Then ConnOpen(BoCnx)

                    If PosIsInstalled(POS) = False Then Continue For

                    Dim BrandStamp As String = GetBrandsTimeStamp(POS, FrmLogin.objcon.con)
                    Dim TypesStamp As String = GetTypesTimeStamp(POS, FrmLogin.objcon.con)
                    Dim CatsStamp As String = GetCategoriesTimeStamp(POS, FrmLogin.objcon.con)

                    If BrandStamp <> GetMaxBrandTimeStamp(BoCnx) Then
                        Continue For
                    End If
                    If TypesStamp <> GetMaxTypesTimeStamp(BoCnx) Then
                        Continue For
                    End If
                    If CatsStamp <> GetMaxCatTimeStamp(BoCnx) Then
                        Continue For
                    End If


                    Dim IaStamp As String = GetItemsTimeStamp(POS, FrmLogin.objcon.con)
                    Dim DtNewItems = ClsItemA.BoGetNewItems(IaStamp, BoCnx)
                    For j = 0 To DtNewItems.Rows.Count - 1
                        Dim command As SqlCommand = con.CreateCommand()
                        command.Connection = con
                        command.CommandText = "SpIv_BOItemAInsert"
                        command.CommandType = CommandType.StoredProcedure
                        command.Parameters.AddWithValue("@ItemAid", IIf(IsNothing(DtNewItems.Rows(j).Item("ItemAid")) Or IsDBNull(DtNewItems.Rows(j).Item("ItemAid")), DBNull.Value, DtNewItems.Rows(j).Item("ItemAid")))
                        command.Parameters.AddWithValue("@ItemCode", IIf(IsNothing(DtNewItems.Rows(j).Item("ItemCode")) Or IsDBNull(DtNewItems.Rows(j).Item("ItemCode")), DBNull.Value, DtNewItems.Rows(j).Item("ItemCode")))
                        command.Parameters.AddWithValue("@CurCode", IIf(IsNothing(DtNewItems.Rows(j).Item("CurCode")) Or IsDBNull(DtNewItems.Rows(j).Item("CurCode")), DBNull.Value, DtNewItems.Rows(j).Item("CurCode")))
                        command.Parameters.AddWithValue("@ShDescription", IIf(IsNothing(DtNewItems.Rows(j).Item("ShDescription")) Or IsDBNull(DtNewItems.Rows(j).Item("ShDescription")), DBNull.Value, DtNewItems.Rows(j).Item("ShDescription")))
                        command.Parameters.AddWithValue("@Description", IIf(IsNothing(DtNewItems.Rows(j).Item("Description")) Or IsDBNull(DtNewItems.Rows(j).Item("Description")), DBNull.Value, DtNewItems.Rows(j).Item("Description")))
                        command.Parameters.AddWithValue("@AltShDescription", IIf(IsNothing(DtNewItems.Rows(j).Item("AltShDescription")) Or IsDBNull(DtNewItems.Rows(j).Item("AltShDescription")), DBNull.Value, DtNewItems.Rows(j).Item("AltShDescription")))
                        command.Parameters.AddWithValue("@AltDescription", IIf(IsNothing(DtNewItems.Rows(j).Item("AltDescription")) Or IsDBNull(DtNewItems.Rows(j).Item("AltDescription")), DBNull.Value, DtNewItems.Rows(j).Item("AltDescription")))
                        command.Parameters.AddWithValue("@UOMCode", IIf(IsNothing(DtNewItems.Rows(j).Item("UOMCode")) Or IsDBNull(DtNewItems.Rows(j).Item("UOMCode")), DBNull.Value, DtNewItems.Rows(j).Item("UOMCode")))
                        command.Parameters.AddWithValue("@SupplierId", IIf(IsNothing(DtNewItems.Rows(j).Item("SupplierId")) Or IsDBNull(DtNewItems.Rows(j).Item("SupplierId")), DBNull.Value, DtNewItems.Rows(j).Item("SupplierId")))
                        command.Parameters.AddWithValue("@CategoryCode", IIf(IsNothing(DtNewItems.Rows(j).Item("CategoryCode")) Or IsDBNull(DtNewItems.Rows(j).Item("CategoryCode")), DBNull.Value, DtNewItems.Rows(j).Item("CategoryCode")))
                        command.Parameters.AddWithValue("@TypeCode", IIf(IsNothing(DtNewItems.Rows(j).Item("TypeCode")) Or IsDBNull(DtNewItems.Rows(j).Item("TypeCode")), DBNull.Value, DtNewItems.Rows(j).Item("TypeCode")))
                        command.Parameters.AddWithValue("@BrandCode", IIf(IsNothing(DtNewItems.Rows(j).Item("BrandCode")) Or IsDBNull(DtNewItems.Rows(j).Item("BrandCode")), DBNull.Value, DtNewItems.Rows(j).Item("BrandCode")))
                        command.Parameters.AddWithValue("@CustomId", IIf(IsNothing(DtNewItems.Rows(j).Item("CustomId")) Or IsDBNull(DtNewItems.Rows(j).Item("CustomId")), DBNull.Value, DtNewItems.Rows(j).Item("CustomId")))
                        command.Parameters.AddWithValue("@VatId", IIf(IsNothing(DtNewItems.Rows(j).Item("VatId")) Or IsDBNull(DtNewItems.Rows(j).Item("VatId")), DBNull.Value, DtNewItems.Rows(j).Item("VatId")))
                        command.Parameters.AddWithValue("@BaseUom", IIf(IsNothing(DtNewItems.Rows(j).Item("BaseUom")) Or IsDBNull(DtNewItems.Rows(j).Item("BaseUom")), DBNull.Value, DtNewItems.Rows(j).Item("BaseUom")))
                        command.Parameters.AddWithValue("@Factor", IIf(IsNothing(DtNewItems.Rows(j).Item("Factor")) Or IsDBNull(DtNewItems.Rows(j).Item("Factor")), DBNull.Value, DtNewItems.Rows(j).Item("Factor")))
                        command.Parameters.AddWithValue("@NbPages", IIf(IsNothing(DtNewItems.Rows(j).Item("NbPages")) Or IsDBNull(DtNewItems.Rows(j).Item("NbPages")), DBNull.Value, DtNewItems.Rows(j).Item("NbPages")))
                        command.Parameters.AddWithValue("@AltUom", IIf(IsNothing(DtNewItems.Rows(j).Item("AltUom")) Or IsDBNull(DtNewItems.Rows(j).Item("AltUom")), DBNull.Value, DtNewItems.Rows(j).Item("AltUom")))
                        command.Parameters.AddWithValue("@ItemAPrice", IIf(IsNothing(DtNewItems.Rows(j).Item("ItemAPrice")) Or IsDBNull(DtNewItems.Rows(j).Item("ItemAPrice")), DBNull.Value, DtNewItems.Rows(j).Item("ItemAPrice")))
                        command.Parameters.AddWithValue("@ProfitMargin", IIf(IsNothing(DtNewItems.Rows(j).Item("ProfitMargin")) Or IsDBNull(DtNewItems.Rows(j).Item("ProfitMargin")), DBNull.Value, DtNewItems.Rows(j).Item("ProfitMargin")))
                        command.Parameters.AddWithValue("@MinimQty", IIf(IsNothing(DtNewItems.Rows(j).Item("MinimQty")) Or IsDBNull(DtNewItems.Rows(j).Item("MinimQty")), DBNull.Value, DtNewItems.Rows(j).Item("MinimQty")))
                        command.Parameters.AddWithValue("@Increase", IIf(IsNothing(DtNewItems.Rows(j).Item("Increase")) Or IsDBNull(DtNewItems.Rows(j).Item("Increase")), DBNull.Value, DtNewItems.Rows(j).Item("Increase")))
                        command.Parameters.AddWithValue("@AddFinal", IIf(IsNothing(DtNewItems.Rows(j).Item("AddFinal")) Or IsDBNull(DtNewItems.Rows(j).Item("AddFinal")), DBNull.Value, DtNewItems.Rows(j).Item("AddFinal")))
                        command.Parameters.AddWithValue("@IncluedInBudget", IIf(IsNothing(DtNewItems.Rows(j).Item("IncluedInBudget")) Or IsDBNull(DtNewItems.Rows(j).Item("IncluedInBudget")), DBNull.Value, DtNewItems.Rows(j).Item("IncluedInBudget")))
                        command.Parameters.AddWithValue("@Blocked", IIf(IsNothing(DtNewItems.Rows(j).Item("Blocked")) Or IsDBNull(DtNewItems.Rows(j).Item("Blocked")), DBNull.Value, DtNewItems.Rows(j).Item("Blocked")))
                        command.Parameters.AddWithValue("@Idle", IIf(IsNothing(DtNewItems.Rows(j).Item("Idle")) Or IsDBNull(DtNewItems.Rows(j).Item("Idle")), DBNull.Value, DtNewItems.Rows(j).Item("Idle")))
                        command.Parameters.AddWithValue("@Consignment", IIf(IsNothing(DtNewItems.Rows(j).Item("Consignment")) Or IsDBNull(DtNewItems.Rows(j).Item("Consignment")), DBNull.Value, DtNewItems.Rows(j).Item("Consignment")))
                        command.Parameters.AddWithValue("@Discountable", IIf(IsNothing(DtNewItems.Rows(j).Item("Discountable")) Or IsDBNull(DtNewItems.Rows(j).Item("Discountable")), DBNull.Value, DtNewItems.Rows(j).Item("Discountable")))
                        command.Parameters.AddWithValue("@KitItem", IIf(IsNothing(DtNewItems.Rows(j).Item("KitItem")) Or IsDBNull(DtNewItems.Rows(j).Item("KitItem")), DBNull.Value, DtNewItems.Rows(j).Item("KitItem")))
                        command.Parameters.AddWithValue("@ServiceItem", IIf(IsNothing(DtNewItems.Rows(j).Item("ServiceItem")) Or IsDBNull(DtNewItems.Rows(j).Item("ServiceItem")), DBNull.Value, DtNewItems.Rows(j).Item("ServiceItem")))

                        command.Parameters.AddWithValue("@UseLot", IIf(IsNothing(DtNewItems.Rows(j).Item("UseLot")) Or IsDBNull(DtNewItems.Rows(j).Item("UseLot")), DBNull.Value, DtNewItems.Rows(j).Item("UseLot")))
                        command.Parameters.AddWithValue("@UseExpiry", IIf(IsNothing(DtNewItems.Rows(j).Item("UseExpiry")) Or IsDBNull(DtNewItems.Rows(j).Item("UseExpiry")), DBNull.Value, DtNewItems.Rows(j).Item("UseExpiry")))
                        command.Parameters.AddWithValue("@UseSerial", IIf(IsNothing(DtNewItems.Rows(j).Item("UseSerial")) Or IsDBNull(DtNewItems.Rows(j).Item("UseSerial")), DBNull.Value, DtNewItems.Rows(j).Item("UseSerial")))
                        command.Parameters.AddWithValue("@ProtectReservedQty", IIf(IsNothing(DtNewItems.Rows(j).Item("ProtectReservedQty")) Or IsDBNull(DtNewItems.Rows(j).Item("ProtectReservedQty")), DBNull.Value, DtNewItems.Rows(j).Item("ProtectReservedQty")))
                        command.Parameters.AddWithValue("@Iuser", IIf(IsNothing(DtNewItems.Rows(j).Item("Iuser")) Or IsDBNull(DtNewItems.Rows(j).Item("Iuser")), DBNull.Value, DtNewItems.Rows(j).Item("Iuser")))
                        command.Parameters.AddWithValue("@IDate", IIf(IsNothing(DtNewItems.Rows(j).Item("IDate")) Or IsDBNull(DtNewItems.Rows(j).Item("IDate")), DBNull.Value, DtNewItems.Rows(j).Item("IDate")))
                        command.Parameters.AddWithValue("@UUser", IIf(IsNothing(DtNewItems.Rows(j).Item("UUser")) Or IsDBNull(DtNewItems.Rows(j).Item("UUser")), DBNull.Value, DtNewItems.Rows(j).Item("UUser")))
                        command.Parameters.AddWithValue("@UDate", IIf(IsNothing(DtNewItems.Rows(j).Item("UDate")) Or IsDBNull(DtNewItems.Rows(j).Item("UDate")), DBNull.Value, DtNewItems.Rows(j).Item("UDate")))
                        command.Parameters.AddWithValue("@PostQty", IIf(IsNothing(DtNewItems.Rows(j).Item("PostQty")) Or IsDBNull(DtNewItems.Rows(j).Item("PostQty")), DBNull.Value, DtNewItems.Rows(j).Item("PostQty")))
                        command.Parameters.AddWithValue("@AvgCost", IIf(IsNothing(DtNewItems.Rows(j).Item("AvgCost")) Or IsDBNull(DtNewItems.Rows(j).Item("AvgCost")), DBNull.Value, DtNewItems.Rows(j).Item("AvgCost")))
                        command.Parameters.AddWithValue("@Fl_AvgCost", IIf(IsNothing(DtNewItems.Rows(j).Item("Fl_AvgCost")) Or IsDBNull(DtNewItems.Rows(j).Item("Fl_AvgCost")), DBNull.Value, DtNewItems.Rows(j).Item("Fl_AvgCost")))
                        command.Parameters.AddWithValue("@Sl_AvgCost", IIf(IsNothing(DtNewItems.Rows(j).Item("Sl_AvgCost")) Or IsDBNull(DtNewItems.Rows(j).Item("Sl_AvgCost")), DBNull.Value, DtNewItems.Rows(j).Item("Fl_AvgCost")))
                        command.Parameters.AddWithValue("@LastPurch", IIf(IsNothing(DtNewItems.Rows(j).Item("LastPurch")) Or IsDBNull(DtNewItems.Rows(j).Item("LastPurch")), DBNull.Value, DtNewItems.Rows(j).Item("LastPurch")))
                        command.Parameters.AddWithValue("@Fl_LastPurch", IIf(IsNothing(DtNewItems.Rows(j).Item("Fl_LastPurch")) Or IsDBNull(DtNewItems.Rows(j).Item("Fl_LastPurch")), DBNull.Value, DtNewItems.Rows(j).Item("Fl_LastPurch")))
                        command.Parameters.AddWithValue("@Sl_LastPurch", IIf(IsNothing(DtNewItems.Rows(j).Item("Sl_LastPurch")) Or IsDBNull(DtNewItems.Rows(j).Item("Sl_LastPurch")), DBNull.Value, DtNewItems.Rows(j).Item("Sl_LastPurch")))
                        command.Parameters.AddWithValue("@LastUnitCost", IIf(IsNothing(DtNewItems.Rows(j).Item("LastUnitCost")) Or IsDBNull(DtNewItems.Rows(j).Item("LastUnitCost")), DBNull.Value, DtNewItems.Rows(j).Item("LastUnitCost")))
                        command.Parameters.AddWithValue("@Fl_LastUnitCost", IIf(IsNothing(DtNewItems.Rows(j).Item("Fl_LastUnitCost")) Or IsDBNull(DtNewItems.Rows(j).Item("Fl_LastUnitCost")), DBNull.Value, DtNewItems.Rows(j).Item("Fl_LastUnitCost")))
                        command.Parameters.AddWithValue("@Sl_LastUnitCost", IIf(IsNothing(DtNewItems.Rows(j).Item("Sl_LastUnitCost")) Or IsDBNull(DtNewItems.Rows(j).Item("Sl_LastUnitCost")), DBNull.Value, DtNewItems.Rows(j).Item("Sl_LastUnitCost")))
                        command.Parameters.AddWithValue("@AllowSell", IIf(IsNothing(DtNewItems.Rows(j).Item("AllowSell")) Or IsDBNull(DtNewItems.Rows(j).Item("AllowSell")), DBNull.Value, DtNewItems.Rows(j).Item("AllowSell")))
                        command.Parameters.AddWithValue("@CostType", IIf(IsNothing(DtNewItems.Rows(j).Item("CostType")) Or IsDBNull(DtNewItems.Rows(j).Item("CostType")), DBNull.Value, DtNewItems.Rows(j).Item("CostType")))
                        command.Parameters.AddWithValue("@StartYear", IIf(IsNothing(DtNewItems.Rows(j).Item("StartYear")) Or IsDBNull(DtNewItems.Rows(j).Item("StartYear")), DBNull.Value, DtNewItems.Rows(j).Item("StartYear")))
                        sqls += CommandAsSql(command)
                    Next
                    If sqls <> "" Then
                        Dim transaction As SqlTransaction = Nothing
                        If con.State = ConnectionState.Closed Then
                            Try
                                con.Open()
                                Dim transcommand As SqlCommand = con.CreateCommand()
                                transaction = con.BeginTransaction("SampleTransaction")
                                transcommand.Connection = con
                                transcommand.Transaction = transaction
                                transcommand.CommandText = sqls
                                transcommand.CommandType = CommandType.Text
                                Try
                                    transcommand.ExecuteNonQuery()
                                    transaction.Commit()
                                    Dim MaxIaStamp = GetMaxItemsTimeStamp(BoCnx)
                                    UpdateItemsTimeStamp(MaxIaStamp, POS, FrmLogin.objcon.con)
                                    Utilities.WriteToText("InsertItemsA In POS: " & POS & ": ", "Successfully Inserted")
                                Catch ex As Exception
                                    Utilities.WriteToText("InsertItemsA In POS: " & POS & " Commit Type Failed Due To : ", ex.GetType().ToString)
                                    Utilities.WriteToText("InsertItemsA In POS: " & POS & " Commit Message Failed Due To : ", ex.Message)
                                    Dim ClsLog As New ClsLogs
                                    ClsLog._BackOffice = ""
                                    ClsLog._PosCode = POS
                                    ClsLog._FunctionN = "InsertItemsA"
                                    ClsLog._Desc = ex.Message
                                    ClsLog._Sql = sqls
                                    ClsLog.WriteToTable(FrmLogin.objcon.con)
                                    Try
                                        transaction.Rollback()
                                    Catch ex2 As Exception
                                        Utilities.WriteToText("InsertItemsA In POS: " & POS & " Rollback Type Failed Due To : ", ex2.GetType().ToString)
                                        Utilities.WriteToText("InsertItemsA In POS: " & POS & " Rollback Message Failed Due To : ", ex2.Message)
                                        Continue For
                                    End Try
                                Finally
                                    con.Close()
                                End Try
                            Catch ex As Exception
                                Utilities.WriteToText("InsertItemsA In POS: " & POS, " Connection could not be established")
                                Continue For
                            End Try
                        End If
                    End If
                Next
            Catch ex As Exception
                Utilities.WriteToText("InsertItemsA: In POS: " & POS & " Failed Due to ", ex.Message)
            End Try
        Catch ex As Exception
            Utilities.WriteToText("InsertItemsA: In POS: " & POS & " Failed Due to ", ex.Message)
        End Try
    End Sub
    Public Sub InsertItemsB()
        Dim POS = ""
        Dim sqls = ""
        Try
            Dim ClsPos As New ClsPOS
            Dim dt As New DataTable
            dt = ClsPos.GetPosConfig(FrmLogin.objcon.con)
            Dim ClsItemB As New ClsItemB
            Dim BoConxString = "Data Source ='" & FrmMainForm.BOServer & "';Initial Catalog='" & FrmMainForm.BODatabase & "';user ID='" & FrmMainForm.BOUser & "';password='" & FrmMainForm.BOPass & "'"
            Dim BoCnx As SqlConnection = New SqlConnection(BoConxString)
            Dim blnconnectionOpen1 As Boolean
            Try
                For i = 0 To dt.Rows.Count - 1

                    sqls = ""
                    Dim strconnection As String = "Data Source ='" & dt.Rows(i).Item("PosServer") & "';Initial Catalog='" & dt.Rows(i).Item("PosDatabase") & "';user ID='" & dt.Rows(i).Item("PosUser") & "';password='" & dt.Rows(i).Item("PosPass") & "';Connection Timeout = 320"
                    Dim con As SqlConnection = New SqlConnection(strconnection)
                    POS = dt.Rows(i).Item("PosCode")

                    blnconnectionOpen1 = ConnStatus(BoCnx)
                    If Not blnconnectionOpen1 Then ConnOpen(BoCnx)

                    If PosIsInstalled(POS) = False Then Continue For

                    Dim IaStamp As String = GetItemsTimeStamp(POS, FrmLogin.objcon.con)

                    If IaStamp <> GetMaxItemsTimeStamp(BoCnx) Then
                        Continue For
                    End If


                    Dim IbStamp As String = GetItemsBTimeStamp(POS, FrmLogin.objcon.con)
                    Dim DtNewItems = ClsItemB.BoGetNewItems(IbStamp, BoCnx)
                    For j = 0 To DtNewItems.Rows.Count - 1
                        Dim command1 As SqlCommand = con.CreateCommand()
                        command1.Connection = con
                        command1.CommandText = "SpIv_BOItemBInsert"
                        command1.CommandType = CommandType.StoredProcedure
                        command1.Parameters.AddWithValue("@ItemBid", IIf(IsNothing(DtNewItems.Rows(j).Item("ItemBid")) Or IsDBNull(DtNewItems.Rows(j).Item("ItemBid")), DBNull.Value, DtNewItems.Rows(j).Item("ItemBid")))
                        command1.Parameters.AddWithValue("@ItemAId", IIf(IsNothing(DtNewItems.Rows(j).Item("ItemAId")) Or IsDBNull(DtNewItems.Rows(j).Item("ItemAId")), DBNull.Value, DtNewItems.Rows(j).Item("ItemAId")))
                        command1.Parameters.AddWithValue("@BarCode", IIf(IsNothing(DtNewItems.Rows(j).Item("BarCode")) Or IsDBNull(DtNewItems.Rows(j).Item("BarCode")), DBNull.Value, DtNewItems.Rows(j).Item("BarCode")))
                        command1.Parameters.AddWithValue("@SizeCode", IIf(IsNothing(DtNewItems.Rows(j).Item("SizeCode")) Or IsDBNull(DtNewItems.Rows(j).Item("SizeCode")), DBNull.Value, DtNewItems.Rows(j).Item("SizeCode")))
                        command1.Parameters.AddWithValue("@ColorCode", IIf(IsNothing(DtNewItems.Rows(j).Item("ColorCode")) Or IsDBNull(DtNewItems.Rows(j).Item("ColorCode")), DBNull.Value, DtNewItems.Rows(j).Item("ColorCode")))
                        command1.Parameters.AddWithValue("@UOMCode", IIf(IsNothing(DtNewItems.Rows(j).Item("UOMCode")) Or IsDBNull(DtNewItems.Rows(j).Item("UOMCode")), DBNull.Value, DtNewItems.Rows(j).Item("UOMCode")))
                        command1.Parameters.AddWithValue("@Factor", IIf(IsNothing(DtNewItems.Rows(j).Item("Factor")) Or IsDBNull(DtNewItems.Rows(j).Item("Factor")), DBNull.Value, DtNewItems.Rows(j).Item("Factor")))
                        command1.Parameters.AddWithValue("@ItemPrice", IIf(IsNothing(DtNewItems.Rows(j).Item("ItemPrice")) Or IsDBNull(DtNewItems.Rows(j).Item("ItemPrice")), DBNull.Value, DtNewItems.Rows(j).Item("ItemPrice")))
                        command1.Parameters.AddWithValue("@ProfitMargin", IIf(IsNothing(DtNewItems.Rows(j).Item("ProfitMargin")) Or IsDBNull(DtNewItems.Rows(j).Item("ProfitMargin")), DBNull.Value, DtNewItems.Rows(j).Item("ProfitMargin")))
                        command1.Parameters.AddWithValue("@UUser", IIf(IsNothing(DtNewItems.Rows(j).Item("UUser")) Or IsDBNull(DtNewItems.Rows(j).Item("UUser")), DBNull.Value, DtNewItems.Rows(j).Item("UUser")))
                        command1.Parameters.AddWithValue("@Udate", IIf(IsNothing(DtNewItems.Rows(j).Item("Udate")) Or IsDBNull(DtNewItems.Rows(j).Item("Udate")), DBNull.Value, DtNewItems.Rows(j).Item("Udate")))
                        sqls += CommandAsSql(command1)
                    Next
                    If sqls <> "" Then
                        Dim transaction As SqlTransaction = Nothing
                        If con.State = ConnectionState.Closed Then
                            Try
                                con.Open()
                                Dim transcommand As SqlCommand = con.CreateCommand()
                                transaction = con.BeginTransaction("SampleTransaction")
                                transcommand.Connection = con
                                transcommand.Transaction = transaction
                                transcommand.CommandText = sqls
                                transcommand.CommandType = CommandType.Text
                                Try
                                    transcommand.ExecuteNonQuery()
                                    transaction.Commit()
                                    Dim MaxIbStamp = GetMaxItemsBTimeStamp(BoCnx)
                                    UpdateItemsBTimeStamp(MaxIbStamp, POS, FrmLogin.objcon.con)
                                    Utilities.WriteToText("InsertItemsB In POS: " & POS & ": ", "Successfully Inserted")
                                Catch ex As Exception
                                    Utilities.WriteToText("InsertItemsB In POS: " & POS & " Commit Type Failed Due To : ", ex.GetType().ToString)
                                    Utilities.WriteToText("InsertItemsB In POS: " & POS & " Commit Message Failed Due To : ", ex.Message)
                                    Dim ClsLog As New ClsLogs
                                    ClsLog._BackOffice = ""
                                    ClsLog._PosCode = POS
                                    ClsLog._FunctionN = "InsertItemsB"
                                    ClsLog._Desc = ex.Message
                                    ClsLog._Sql = sqls
                                    ClsLog.WriteToTable(FrmLogin.objcon.con)
                                    Try
                                        transaction.Rollback()
                                    Catch ex2 As Exception
                                        Utilities.WriteToText("InsertItemsB In POS: " & POS & " Rollback Type Failed Due To : ", ex2.GetType().ToString)
                                        Utilities.WriteToText("InsertItemsB In POS: " & POS & " Rollback Message Failed Due To : ", ex2.Message)
                                        Continue For
                                    End Try
                                Finally
                                    con.Close()
                                End Try
                            Catch ex As Exception
                                Utilities.WriteToText("InsertItemsB In POS: " & POS, " Connection could not be established")
                                Continue For
                            End Try
                        End If
                    End If
                Next
            Catch ex As Exception
                Utilities.WriteToText("InsertItemsB: In POS: " & POS & " Failed Due to ", ex.Message)
            End Try
        Catch ex As Exception
            Utilities.WriteToText("InsertItemsB: In POS: " & POS & " Failed Due to ", ex.Message)
        End Try
    End Sub

    Public Sub WriteToText(ByVal SForm As String)
        Dim SqlCom As String
        Dim fileName As String
        Dim directory As String
        Dim fs As FileStream
        Dim startupPath As String = ("C:\BusinessPack\PosControl")
        Try
            directory = startupPath & "\SQL\"
            fileName = directory & "sp.sql"
            SqlCom = SForm
            If Not System.IO.Directory.Exists(directory) Then
                System.IO.Directory.CreateDirectory(directory)
            End If

            If File.Exists(fileName) = False Then
                fs = File.Create(fileName)
            Else
                fs = File.Open(fileName, FileMode.Append)
            End If

            Dim info As Byte() = New UTF8Encoding(True).GetBytes(SqlCom)
            fs.Write(info, 0, info.Length)
            fs.Close()
        Catch e As Exception
        End Try
    End Sub
    Public Sub GetDeliveryOperations()
        Dim Whs = ""
        Dim Sqls = ""
        Try
            Dim ClsPos As New ClsPOS
            Dim ClsOperationA As New ClsOperationA
            Dim dt As New DataTable
            dt = ClsPos.GetPosConfig(FrmLogin.objcon.con)
            Dim WhsCount = 0
            Dim OperIDOld As Integer = 0
            Dim OperIDNew As Integer = 0
            Dim Count As Integer = 0
            Dim con As SqlConnection = Nothing
            Dim BoConxString = "Data Source ='" & FrmMainForm.BOServer & "';Initial Catalog='" & FrmMainForm.BODatabase & "';user ID='" & FrmMainForm.BOUser & "';password='" & FrmMainForm.BOPass & "'; Connection Timeout= 120"
            Dim BoCnx As SqlConnection = New SqlConnection(BoConxString)
            Try
                Dim OperID As Integer
                For i = 0 To dt.Rows.Count - 1

                    Sqls = ""
                    Dim blnconnectionOpen1 = ConnStatus(BoCnx)
                    If Not blnconnectionOpen1 Then ConnOpen(BoCnx)
                    Whs = dt.Rows(i).Item("WhsCode")

                    Dim Pos = dt.Rows(i).Item("PosCode")
                    If PosIsInstalled(Pos) = False Then Continue For


                    Dim IaStamp As String = GetItemsTimeStamp(Pos, FrmLogin.objcon.con)

                    Dim IbStamp As String = GetItemsBTimeStamp(Pos, FrmLogin.objcon.con)


                    Dim DtDeliveryOrders = ClsOperationA.GetDeliveryOrders(DeliveryOrder, dt.Rows(i).Item("WhsCode"), BoCnx)
                    Dim strconnection As String = "Data Source ='" & dt.Rows(i).Item("PosServer") & "';Initial Catalog='" & dt.Rows(i).Item("PosDatabase") & "';user ID='" & dt.Rows(i).Item("PosUser") & "';password='" & dt.Rows(i).Item("PosPass") & "';Connection Timeout = 320"
                    con = New SqlConnection(strconnection)

                    If IaStamp <> GetMaxItemsTimeStamp(BoCnx) Then
                        Continue For
                    End If
                    If IbStamp <> GetMaxItemsBTimeStamp(BoCnx) Then
                        Continue For
                    End If

                    OperIDOld = 0
                    If DtDeliveryOrders.Rows.Count <> 0 Then
                        If con.State = ConnectionState.Closed Then
                            Try
                                con.Open()
                            Catch ex As Exception
                                Utilities.WriteToText("InsertDeliveryOperation: In POS: " & Whs, " Connection could not be established")
                                Exit Sub
                            End Try
                        End If
                        For j = 0 To DtDeliveryOrders.Rows.Count - 1
                            OperIDNew = DtDeliveryOrders.Rows(j).Item("OperId")
                            If OperIDNew <> OperIDOld Then
                                If Count = 0 Then
                                    Dim sqlcomm As New SqlCommand("select Sequence from sacsequence where SeqCode='invtype" & DeliveryOrder & "' and seqyear=" & Today.Year & "", con)
                                    If IsDBNull(sqlcomm.ExecuteScalar) Or IsNothing(sqlcomm.ExecuteScalar) Then
                                        Dim sqlc As New SqlCommand("insert into SacSequence (SeqCode,SeqYear,Companyid,Sequence) values ('invtype" &
                                                               DeliveryOrder & "'," & Today.Year & ",1," & Today.Year & "000000)", con)
                                        If con.State = ConnectionState.Closed Then
                                            con.Open()
                                        End If
                                        sqlc.ExecuteNonQuery()
                                    End If
                                    sqlcomm = New SqlCommand("select Sequence from sacsequence where SeqCode='invtype" & DeliveryOrder & "' and seqyear=" & Today.Year & "", con)
                                    If con.State = ConnectionState.Closed Then
                                        con.Open()
                                    End If
                                    OperID = sqlcomm.ExecuteScalar + 1
                                Else
                                    OperID += 1
                                End If
                                Dim command As SqlCommand = con.CreateCommand()
                                command.Connection = con
                                command.CommandText = "SpIv_BODeliveryOrderAInsert"
                                command.CommandType = CommandType.StoredProcedure

                                command.Parameters.AddWithValue("@OperId", OperID)
                                command.Parameters.AddWithValue("@InvTypeId", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("InvTypeId")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("InvTypeId")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("InvTypeId")))
                                command.Parameters.AddWithValue("@OperDate", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("OperDate")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("OperDate")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("OperDate")))
                                command.Parameters.AddWithValue("@ActivationDate", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("ActivationDate")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("ActivationDate")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("ActivationDate")))
                                command.Parameters.AddWithValue("@ThirdId", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("ThirdId")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("ThirdId")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("ThirdId")))
                                command.Parameters.AddWithValue("@ThirdDesc", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("ThirdDesc")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("ThirdDesc")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("ThirdDesc")))
                                command.Parameters.AddWithValue("@SalesManId", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("SalesManId")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("SalesManId")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("SalesManId")))
                                command.Parameters.AddWithValue("@PosCode", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("PosCode")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("PosCode")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("PosCode")))
                                command.Parameters.AddWithValue("@WhsCode", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("WhsCode")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("WhsCode")), DBNull.Value, Whs))
                                command.Parameters.AddWithValue("@CurCode", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("CurCode")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("CurCode")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("CurCode")))
                                command.Parameters.AddWithValue("@Delivery1", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("Delivery1")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("Delivery1")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("Delivery1")))
                                command.Parameters.AddWithValue("@Delivery2", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("Delivery2")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("Delivery2")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("Delivery2")))
                                command.Parameters.AddWithValue("@Delivery3", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("Delivery3")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("Delivery3")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("Delivery3")))
                                command.Parameters.AddWithValue("@Posted", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("Posted")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("Posted")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("Posted")))
                                command.Parameters.AddWithValue("@TransId", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("TransId")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("TransId")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("TransId")))
                                command.Parameters.AddWithValue("@Status", 1)
                                command.Parameters.AddWithValue("@ApplyVat", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("ApplyVat")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("ApplyVat")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("ApplyVat")))
                                command.Parameters.AddWithValue("@Confirmed", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("Confirmed")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("Confirmed")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("Confirmed")))
                                command.Parameters.AddWithValue("@Closed", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("Closed")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("Closed")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("Closed")))
                                command.Parameters.AddWithValue("@Costed", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("Costed")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("Costed")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("Costed")))
                                command.Parameters.AddWithValue("@AvgCosted", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("AvgCosted")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("AvgCosted")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("AvgCosted")))
                                command.Parameters.AddWithValue("@RateFl", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("RateFl")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("RateFl")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("RateFl")))
                                command.Parameters.AddWithValue("@RateSl", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("RateSl")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("RateSl")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("RateSl")))
                                command.Parameters.AddWithValue("@RateVat", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("RateVat")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("RateVat")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("RateVat")))
                                command.Parameters.AddWithValue("@ManualRef", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("ManualRef")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("ManualRef")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("ManualRef")))
                                command.Parameters.AddWithValue("@RefDate", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("RefDate")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("RefDate")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("RefDate")))
                                command.Parameters.AddWithValue("@GrossAmt", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("GrossAmt")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("GrossAmt")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("GrossAmt")))
                                command.Parameters.AddWithValue("@Disc1Pct", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("Disc1Pct")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("Disc1Pct")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("Disc1Pct")))
                                command.Parameters.AddWithValue("@Disc1Amt", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("Disc1Amt")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("Disc1Amt")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("Disc1Amt")))
                                command.Parameters.AddWithValue("@Disc2Pct", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("Disc2Pct")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("Disc2Pct")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("Disc2Pct")))
                                command.Parameters.AddWithValue("@Disc2Amt", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("Disc2Amt")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("Disc2Amt")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("Disc2Amt")))
                                command.Parameters.AddWithValue("@ExtraChargeAmt", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("ExtraChargeAmt")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("ExtraChargeAmt")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("ExtraChargeAmt")))
                                command.Parameters.AddWithValue("@ExtraChargeVat", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("ExtraChargeVat")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("ExtraChargeVat")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("ExtraChargeVat")))
                                command.Parameters.AddWithValue("@AddDiscAmt", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("AddDiscAmt")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("AddDiscAmt")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("AddDiscAmt")))
                                command.Parameters.AddWithValue("@NetAmt", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("NetAmt")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("NetAmt")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("NetAmt")))
                                command.Parameters.AddWithValue("@VatAmt", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("VatAmt")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("VatAmt")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("VatAmt")))
                                command.Parameters.AddWithValue("@Notes", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("Notes")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("Notes")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("Notes")))
                                command.Parameters.AddWithValue("@Iuser", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("Iuser")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("Iuser")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("Iuser")))
                                command.Parameters.AddWithValue("@Idate", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("Idate")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("Idate")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("Idate")))
                                command.Parameters.AddWithValue("@UUser", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("UUser")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("UUser")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("UUser")))
                                command.Parameters.AddWithValue("@UDate", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("UDate")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("UDate")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("UDate")))
                                command.Parameters.AddWithValue("@Message", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("Message")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("Message")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("Message")))
                                command.Parameters.AddWithValue("@DeliveryTerms", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("DeliveryTerms")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("DeliveryTerms")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("DeliveryTerms")))
                                command.Parameters.AddWithValue("@PaymentTerms", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("PaymentTerms")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("PaymentTerms")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("PaymentTerms")))
                                command.Parameters.AddWithValue("@ContractId", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("ContractId")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("ContractId")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("ContractId")))
                                command.Parameters.AddWithValue("@ContractCode", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("ContractCode")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("ContractCode")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("ContractCode")))
                                command.Parameters.AddWithValue("@AssignToId", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("AssignToId")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("AssignToId")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("AssignToId")))
                                command.Parameters.AddWithValue("@MopTransID", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("MopTransID")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("MopTransID")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("MopTransID")))
                                command.Parameters.AddWithValue("@Gift", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("Gift")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("Gift")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("Gift")))
                                command.Parameters.AddWithValue("@GiftReturnDate", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("GiftReturnDate")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("GiftReturnDate")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("GiftReturnDate")))
                                command.Parameters.AddWithValue("@Seen", 1)
                                Sqls += CommandAsSql(command)

                                OperIDOld = DtDeliveryOrders.Rows(j).Item("OperId")
                                Count += 1
                            End If
                            Dim command1 As SqlCommand = con.CreateCommand()
                            ' Start a local transaction
                            command1.Connection = con
                            command1.CommandText = "SpIv_BODeliveryOrderBInsert"
                            command1.CommandType = CommandType.StoredProcedure
                            command1.Parameters.AddWithValue("@OperId", OperID)
                            command1.Parameters.AddWithValue("@InvTypeId", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("InvTypeId")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("InvTypeId")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("InvTypeId")))
                            command1.Parameters.AddWithValue("@LigneId", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("LigneId")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("LigneId")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("LigneId")))
                            command1.Parameters.AddWithValue("@ItemBId", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("ItemBId")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("ItemBId")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("ItemBId")))
                            command1.Parameters.AddWithValue("@ItemAid", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("ItemAid")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("ItemAid")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("ItemAid")))
                            command1.Parameters.AddWithValue("@BarCode", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("BarCode")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("BarCode")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("BarCode")))
                            command1.Parameters.AddWithValue("@ItemShDescription", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("ItemShDescription")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("ItemShDescription")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("ItemShDescription")))
                            command1.Parameters.AddWithValue("@WhsCode", Whs)
                            command1.Parameters.AddWithValue("@SizeCode", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("SizeCode")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("SizeCode")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("SizeCode")))
                            command1.Parameters.AddWithValue("@ColorCode", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("ColorCode")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("ColorCode")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("ColorCode")))
                            command1.Parameters.AddWithValue("@LigneDesc", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("LigneDesc")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("LigneDesc")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("LigneDesc")))
                            command1.Parameters.AddWithValue("@ReasonId", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("ReasonId")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("ReasonId")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("ReasonId")))
                            command1.Parameters.AddWithValue("@KitHead", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("KitHead")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("KitHead")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("KitHead")))
                            command1.Parameters.AddWithValue("@KitLink", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("KitLink")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("KitLink")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("KitLink")))
                            command1.Parameters.AddWithValue("@Up", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("Up")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("Up")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("Up")))
                            command1.Parameters.AddWithValue("@Qty", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("Qty")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("Qty")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("Qty")))
                            command1.Parameters.AddWithValue("@F_Qty", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("F_Qty")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("F_Qty")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("F_Qty")))
                            command1.Parameters.AddWithValue("@AltQty", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("AltQty")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("AltQty")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("AltQty")))
                            command1.Parameters.AddWithValue("@AltF_Qty", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("AltF_Qty")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("AltF_Qty")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("AltF_Qty")))
                            command1.Parameters.AddWithValue("@UOMCode", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("UOMCode")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("UOMCode")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("UOMCode")))
                            command1.Parameters.AddWithValue("@Factor", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("Factor")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("Factor")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("Factor")))
                            command1.Parameters.AddWithValue("@Sign", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("Sign")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("Sign")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("Sign")))
                            command1.Parameters.AddWithValue("@DiscPct", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("DiscPct")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("DiscPct")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("DiscPct")))
                            command1.Parameters.AddWithValue("@DiscAmt", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("DiscAmt")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("DiscAmt")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("DiscAmt")))
                            command1.Parameters.AddWithValue("@TotalLigne", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("TotalLigne")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("TotalLigne")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("TotalLigne")))
                            command1.Parameters.AddWithValue("@VatAmt", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("VatBAmt")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("VatBAmt")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("VatBAmt")))
                            command1.Parameters.AddWithValue("@VatPct", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("VatPct")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("VatPct")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("VatPct")))
                            command1.Parameters.AddWithValue("@HeadDisc", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("HeadDisc")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("HeadDisc")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("HeadDisc")))
                            command1.Parameters.AddWithValue("@CreditNote", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("CreditNote")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("CreditNote")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("CreditNote")))
                            command1.Parameters.AddWithValue("@DebitNote", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("DebitNote")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("DebitNote")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("DebitNote")))
                            command1.Parameters.AddWithValue("@QtyAffect", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("QtyAffect")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("QtyAffect")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("QtyAffect")))
                            command1.Parameters.AddWithValue("@AltQtyAffect", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("AltQtyAffect")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("AltQtyAffect")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("AltQtyAffect")))
                            command1.Parameters.AddWithValue("@QtyRemain", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("QtyRemain")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("QtyRemain")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("QtyRemain")))
                            command1.Parameters.AddWithValue("@F_QtyRemain", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("F_QtyRemain")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("F_QtyRemain")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("F_QtyRemain")))
                            command1.Parameters.AddWithValue("@AltQtyRemain", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("AltQtyRemain")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("AltQtyRemain")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("AltQtyRemain")))
                            command1.Parameters.AddWithValue("@F_AltQtyRemain", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("F_AltQtyRemain")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("F_AltQtyRemain")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("F_AltQtyRemain")))
                            command1.Parameters.AddWithValue("@UnitCost", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("UnitCost")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("UnitCost")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("UnitCost")))
                            command1.Parameters.AddWithValue("@UnitCostRateFl", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("UnitCostRateFl")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("UnitCostRateFl")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("UnitCostRateFl")))
                            command1.Parameters.AddWithValue("@UnitCostRateSl", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("UnitCostRateSl")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("UnitCostRateSl")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("UnitCostRateSl")))
                            command1.Parameters.AddWithValue("@AvgCost", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("AvgCost")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("AvgCost")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("AvgCost")))
                            command1.Parameters.AddWithValue("@Fl_AvgCost", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("Fl_AvgCost")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("Fl_AvgCost")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("Fl_AvgCost")))
                            command1.Parameters.AddWithValue("@Sl_AvgCost", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("Sl_AvgCost")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("Sl_AvgCost")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("Sl_AvgCost")))
                            command1.Parameters.AddWithValue("@QtyOnHand", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("QtyOnHand")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("QtyOnHand")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("QtyOnHand")))
                            command1.Parameters.AddWithValue("@CostingOrder", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("CostingOrder")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("CostingOrder")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("CostingOrder")))
                            command1.Parameters.AddWithValue("@UUser", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("UUser")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("UUser")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("UUser")))
                            command1.Parameters.AddWithValue("@Udate", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("Udate")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("Udate")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("Udate")))
                            command1.Parameters.AddWithValue("@InfoRef", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("InfoRef")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("InfoRef")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("InfoRef")))
                            command1.Parameters.AddWithValue("@ContractSubId", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("ContractSubId")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("ContractSubId")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("ContractSubId")))
                            command1.Parameters.AddWithValue("@ContractSubCode", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("ContractSubCode")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("ContractSubCode")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("ContractSubCode")))
                            command1.Parameters.AddWithValue("@lineorder", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("lineorder")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("lineorder")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("lineorder")))
                            Sqls += CommandAsSql(command1)
                        Next
                        If Sqls <> "" Then
                            Dim transaction As SqlTransaction = Nothing
                            If con.State = ConnectionState.Closed Then
                                Try
                                    con.Open()
                                    Dim transcommand As SqlCommand = con.CreateCommand()
                                    transaction = con.BeginTransaction("SampleTransaction")
                                    transcommand.Connection = con
                                    transcommand.Transaction = transaction
                                    transcommand.CommandText = Sqls
                                    transcommand.CommandType = CommandType.Text
                                    Try
                                        transcommand.ExecuteNonQuery()
                                        transaction.Commit()
                                        Dim sqlc As New SqlCommand(" update SacSequence set Sequence = " & OperID & " where SeqCode = 'invtype" & DeliveryOrder & "' and seqyear = " & Today.Year, con)
                                        If con.State = ConnectionState.Closed Then
                                            con.Open()
                                        End If
                                        sqlc.ExecuteNonQuery()

                                        sqlc = New SqlCommand("update IvOperation1es set seen = 1 where WhsToCode ='" & Whs & "' and invtypeid = " & DeliveryOrder, BoCnx)
                                        If BoCnx.State = ConnectionState.Closed Then
                                            BoCnx.Open()
                                        End If
                                        sqlc.ExecuteNonQuery()
                                        Utilities.WriteToText("InsertDeliveryOperation In POS: " & Whs & ": ", "Successfully Inserted")
                                    Catch ex As Exception
                                        Utilities.WriteToText("InsertDeliveryOperation In POS: " & Whs & " Commit Type Failed Due To : ", ex.GetType().ToString)
                                        Utilities.WriteToText("InsertDeliveryOperation In POS: " & Whs & " Commit Message Failed Due To : ", ex.Message)
                                        Dim ClsLog As New ClsLogs
                                        ClsLog._BackOffice = ""
                                        ClsLog._PosCode = Whs
                                        ClsLog._FunctionN = "InsertDeliveryOperation"
                                        ClsLog._Desc = ex.Message
                                        ClsLog._Sql = Sqls
                                        ClsLog.WriteToTable(FrmLogin.objcon.con)
                                        Try
                                            transaction.Rollback()
                                        Catch ex2 As Exception
                                            Utilities.WriteToText("InsertDeliveryOperation In POS: " & Whs & " Rollback Type Failed Due To : ", ex.GetType().ToString)
                                            Utilities.WriteToText("InsertDeliveryOperation In POS: " & Whs & " Rollback Message Failed Due To : ", ex.Message)
                                        End Try
                                    Finally
                                        con.Close()
                                    End Try
                                Catch ex As Exception
                                    Utilities.WriteToText("InsertDeliveryOperation In POS: " & Whs, " Connection Could not be established")
                                End Try
                            Else
                                Dim transcommand As SqlCommand = con.CreateCommand()
                                transaction = con.BeginTransaction("SampleTransaction")
                                ' Must assign both transaction object and connection
                                ' to Command object for a pending local transaction.
                                transcommand.Connection = con
                                transcommand.Transaction = transaction
                                transcommand.CommandText = Sqls
                                transcommand.CommandType = CommandType.Text
                                Try
                                    transcommand.ExecuteNonQuery()
                                    transaction.Commit()
                                    Dim sqlc As New SqlCommand(" update SacSequence set Sequence = " & OperID & " where SeqCode = 'invtype" & DeliveryOrder & "' and seqyear = " & Today.Year, con)
                                    If con.State = ConnectionState.Closed Then
                                        con.Open()
                                    End If
                                    sqlc.ExecuteNonQuery()

                                    sqlc = New SqlCommand("update IvOperation1es set seen = 1 where WhsToCode ='" & Whs & "' and invtypeid = " & DeliveryOrder, BoCnx)
                                    If BoCnx.State = ConnectionState.Closed Then
                                        BoCnx.Open()
                                    End If
                                    sqlc.ExecuteNonQuery()
                                    Utilities.WriteToText("InsertDeliveryOperation In POS: " & Whs & ": ", "Successfully Inserted")
                                Catch ex As Exception
                                    Utilities.WriteToText("InsertDeliveryOperation In POS: " & Whs & " Commit Type Failed Due To : ", ex.GetType().ToString)
                                    Utilities.WriteToText("InsertDeliveryOperation In POS: " & Whs & " Commit Message Failed Due To : ", ex.Message)
                                    Dim ClsLog As New ClsLogs
                                    ClsLog._BackOffice = ""
                                    ClsLog._PosCode = Whs
                                    ClsLog._FunctionN = "InsertDeliveryOperation"
                                    ClsLog._Desc = ex.Message
                                    ClsLog._Sql = Sqls
                                    ClsLog.WriteToTable(FrmLogin.objcon.con)
                                    Try
                                        transaction.Rollback()
                                    Catch ex2 As Exception
                                        Utilities.WriteToText("InsertDeliveryOperation In POS: " & Whs & " Rollback Type Failed Due To : ", ex.GetType().ToString)
                                        Utilities.WriteToText("InsertDeliveryOperation In POS: " & Whs & " Rollback Message Failed Due To : ", ex.Message)
                                    End Try
                                Finally
                                    con.Close()
                                End Try
                            End If
                        End If
                    End If
                Next
                If BoCnx.State = ConnectionState.Open Then
                    BoCnx.Close()
                End If
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
            Catch ex As Exception
                Utilities.WriteToText("InsertDeliveryOperation in POS:  " & Whs & "Failed Due To: ", ex.Message)
            End Try
        Catch ex As Exception
            Utilities.WriteToText("InsertDeliveryOperation in POS:  " & Whs & "Failed Due To: ", ex.Message)
        End Try
    End Sub
    Public Sub InsertCustomerInBO()
        Try
            Try
                Dim ClsThirdParty As New ClsThirdParty
                Dim BoConxString = "Data Source ='" & FrmMainForm.BOServer & "';Initial Catalog='" & FrmMainForm.BODatabase & "';user ID='" & FrmMainForm.BOUser & "';password='" & FrmMainForm.BOPass & "'"
                Dim BoCnx As SqlConnection = New SqlConnection(BoConxString)
                Dim DtNewCustomers = ClsThirdParty.BoGetNewCustomers(FrmLogin.objcon.con)
                Dim sqls As String = ""

                For j = 0 To DtNewCustomers.Rows.Count - 1
                    Dim command As SqlCommand = BoCnx.CreateCommand()
                    command.Connection = BoCnx
                    command.CommandText = "Sp_ThirdPartyBoToPos"
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@ThirdId", DtNewCustomers.Rows(j).Item("ThirdId"))
                    command.Parameters.AddWithValue("@Name", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("Name")) Or IsNothing(DtNewCustomers.Rows(j).Item("Name")), "", DtNewCustomers.Rows(j).Item("Name")))
                    command.Parameters.AddWithValue("@ShortName", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("ShortName")) Or IsNothing(DtNewCustomers.Rows(j).Item("ShortName")), "", DtNewCustomers.Rows(j).Item("ShortName")))
                    command.Parameters.AddWithValue("@Title", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("Title")) Or IsNothing(DtNewCustomers.Rows(j).Item("Title")), "", DtNewCustomers.Rows(j).Item("Title")))
                    command.Parameters.AddWithValue("@AltName", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("AltName")) Or IsNothing(DtNewCustomers.Rows(j).Item("AltName")), "", DtNewCustomers.Rows(j).Item("AltName")))
                    command.Parameters.AddWithValue("@AltShortName", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("AltShortName")) Or IsNothing(DtNewCustomers.Rows(j).Item("AltShortName")), "", DtNewCustomers.Rows(j).Item("AltShortName")))
                    command.Parameters.AddWithValue("@ManualRef", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("ManualRef")) Or IsNothing(DtNewCustomers.Rows(j).Item("ManualRef")), "", DtNewCustomers.Rows(j).Item("ManualRef")))
                    command.Parameters.AddWithValue("@CountryId", IIf(IsNothing(DtNewCustomers.Rows(j).Item("CountryID")) Or IsDBNull(DtNewCustomers.Rows(j).Item("CountryID")), DBNull.Value, DtNewCustomers.Rows(j).Item("CountryID")))
                    command.Parameters.AddWithValue("@AreaId", IIf(IsNothing(DtNewCustomers.Rows(j).Item("AreaID")) Or IsDBNull(DtNewCustomers.Rows(j).Item("AreaID")), DBNull.Value, DtNewCustomers.Rows(j).Item("AreaID")))
                    command.Parameters.AddWithValue("@SisterCompany", IIf(IsNothing(DtNewCustomers.Rows(j).Item("SisterCompany")) Or IsDBNull(DtNewCustomers.Rows(j).Item("SisterCompany")), False, DtNewCustomers.Rows(j).Item("SisterCompany")))
                    command.Parameters.AddWithValue("@Address", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("Address")) Or IsNothing(DtNewCustomers.Rows(j).Item("Address")), "", DtNewCustomers.Rows(j).Item("Address")))
                    command.Parameters.AddWithValue("@Address2", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("Address2")) Or IsNothing(DtNewCustomers.Rows(j).Item("Address2")), "", DtNewCustomers.Rows(j).Item("Address2")))
                    command.Parameters.AddWithValue("@Address3", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("Address3")) Or IsNothing(DtNewCustomers.Rows(j).Item("Address3")), "", DtNewCustomers.Rows(j).Item("Address3")))
                    command.Parameters.AddWithValue("@Address4", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("Address4")) Or IsNothing(DtNewCustomers.Rows(j).Item("Address4")), "", DtNewCustomers.Rows(j).Item("Address4")))
                    command.Parameters.AddWithValue("@Address5", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("Address5")) Or IsNothing(DtNewCustomers.Rows(j).Item("Address5")), "", DtNewCustomers.Rows(j).Item("Address5")))
                    command.Parameters.AddWithValue("@Phone1", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("Phone1")) Or IsNothing(DtNewCustomers.Rows(j).Item("Phone1")), "", DtNewCustomers.Rows(j).Item("Phone1")))
                    command.Parameters.AddWithValue("@Phone2", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("Phone2")) Or IsNothing(DtNewCustomers.Rows(j).Item("Phone2")), "", DtNewCustomers.Rows(j).Item("Phone2")))
                    command.Parameters.AddWithValue("@Phone3", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("Phone3")) Or IsNothing(DtNewCustomers.Rows(j).Item("Phone3")), "", DtNewCustomers.Rows(j).Item("Phone3")))
                    command.Parameters.AddWithValue("@Fax", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("Fax")) Or IsNothing(DtNewCustomers.Rows(j).Item("Fax")), "", DtNewCustomers.Rows(j).Item("Fax")))
                    command.Parameters.AddWithValue("@POBOX", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("POBOX")) Or IsNothing(DtNewCustomers.Rows(j).Item("POBOX")), "", DtNewCustomers.Rows(j).Item("POBOX")))
                    command.Parameters.AddWithValue("@Email", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("Email")) Or IsNothing(DtNewCustomers.Rows(j).Item("Email")), "", DtNewCustomers.Rows(j).Item("Email")))
                    command.Parameters.AddWithValue("@Site", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("Site")) Or IsNothing(DtNewCustomers.Rows(j).Item("Site")), "", DtNewCustomers.Rows(j).Item("Site")))
                    command.Parameters.AddWithValue("@ShowInPayable", IIf(IsNothing(DtNewCustomers.Rows(j).Item("ShowInPayable")) Or IsDBNull(DtNewCustomers.Rows(j).Item("ShowInPayable")), False, DtNewCustomers.Rows(j).Item("ShowInPayable")))
                    command.Parameters.AddWithValue("@ShowInReceivable", IIf(IsNothing(DtNewCustomers.Rows(j).Item("ShowInReceivable")) Or IsDBNull(DtNewCustomers.Rows(j).Item("ShowInReceivable")), False, DtNewCustomers.Rows(j).Item("ShowInReceivable")))
                    command.Parameters.AddWithValue("@ShowInEmployee", IIf(IsNothing(DtNewCustomers.Rows(j).Item("ShowInEmployee")) Or IsDBNull(DtNewCustomers.Rows(j).Item("ShowInEmployee")), False, DtNewCustomers.Rows(j).Item("ShowInEmployee")))
                    command.Parameters.AddWithValue("@Blocked", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Blocked")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Blocked")), False, DtNewCustomers.Rows(j).Item("Blocked")))
                    command.Parameters.AddWithValue("@ContactName", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("ContactName")) Or IsNothing(DtNewCustomers.Rows(j).Item("ContactName")), "", DtNewCustomers.Rows(j).Item("ContactName")))
                    command.Parameters.AddWithValue("@ContactMail", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("ContactMail")) Or IsNothing(DtNewCustomers.Rows(j).Item("ContactMail")), "", DtNewCustomers.Rows(j).Item("ContactMail")))
                    command.Parameters.AddWithValue("@ContactPhone", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("ContactPhone")) Or IsNothing(DtNewCustomers.Rows(j).Item("ContactPhone")), "", DtNewCustomers.Rows(j).Item("ContactPhone")))
                    command.Parameters.AddWithValue("@Notes", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("Notes")) Or IsNothing(DtNewCustomers.Rows(j).Item("Notes")), "", DtNewCustomers.Rows(j).Item("Notes")))
                    command.Parameters.AddWithValue("@VatREG", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("VatReg")) Or IsNothing(DtNewCustomers.Rows(j).Item("VatReg")), "", DtNewCustomers.Rows(j).Item("VatReg")))
                    command.Parameters.AddWithValue("@iUser", FrmLogin.user)
                    command.Parameters.AddWithValue("@idate", Today.Date)
                    command.Parameters.AddWithValue("@ThirdFinNb", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("ThirdFinNB")) Or IsNothing(DtNewCustomers.Rows(j).Item("ThirdFinNB")), "", DtNewCustomers.Rows(j).Item("ThirdFinNB")))
                    command.Parameters.AddWithValue("@bank1", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("bank1")) Or IsNothing(DtNewCustomers.Rows(j).Item("bank1")), "", DtNewCustomers.Rows(j).Item("bank1")))
                    command.Parameters.AddWithValue("@bank", "")
                    command.Parameters.AddWithValue("@bank2", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("bank2")) Or IsNothing(DtNewCustomers.Rows(j).Item("bank2")), "", DtNewCustomers.Rows(j).Item("bank2")))
                    command.Parameters.AddWithValue("@bank3", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("bank3")) Or IsNothing(DtNewCustomers.Rows(j).Item("bank3")), "", DtNewCustomers.Rows(j).Item("bank3")))
                    command.Parameters.AddWithValue("@bank4", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("bank4")) Or IsNothing(DtNewCustomers.Rows(j).Item("bank4")), "", DtNewCustomers.Rows(j).Item("bank4")))
                    command.Parameters.AddWithValue("@bank5", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("bank5")) Or IsNothing(DtNewCustomers.Rows(j).Item("bank5")), "", DtNewCustomers.Rows(j).Item("bank5")))
                    command.Parameters.AddWithValue("@bank6", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("bank6")) Or IsNothing(DtNewCustomers.Rows(j).Item("bank6")), "", DtNewCustomers.Rows(j).Item("bank6")))
                    command.Parameters.AddWithValue("@bank7", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("bank7")) Or IsNothing(DtNewCustomers.Rows(j).Item("bank7")), "", DtNewCustomers.Rows(j).Item("bank7")))
                    command.Parameters.AddWithValue("@bank8", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("bank8")) Or IsNothing(DtNewCustomers.Rows(j).Item("bank8")), "", DtNewCustomers.Rows(j).Item("bank8")))
                    command.Parameters.AddWithValue("@bank9", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("bank9")) Or IsNothing(DtNewCustomers.Rows(j).Item("bank9")), "", DtNewCustomers.Rows(j).Item("bank9")))
                    command.Parameters.AddWithValue("@bank10", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("bank10")) Or IsNothing(DtNewCustomers.Rows(j).Item("bank10")), "", DtNewCustomers.Rows(j).Item("bank10")))
                    command.Parameters.AddWithValue("@bank11", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("bank11")) Or IsNothing(DtNewCustomers.Rows(j).Item("bank11")), "", DtNewCustomers.Rows(j).Item("bank11")))
                    sqls += CommandAsSql(command)

                    'SaveThirdExtra
                    Dim command2 As SqlCommand = BoCnx.CreateCommand()
                    command2.Connection = BoCnx
                    command2.CommandText = "Sp_ThirdExtraBoToPos"
                    command2.CommandType = CommandType.StoredProcedure
                    command2.Parameters.AddWithValue("@ThirdId", IIf(IsNothing(DtNewCustomers.Rows(j).Item("ThirdId")) Or IsDBNull(DtNewCustomers.Rows(j).Item("ThirdId")), DBNull.Value, DtNewCustomers.Rows(j).Item("ThirdId")))
                    command2.Parameters.AddWithValue("@CollectorId", IIf(IsNothing(DtNewCustomers.Rows(j).Item("CollectorID")) Or IsDBNull(DtNewCustomers.Rows(j).Item("CollectorID")), DBNull.Value, DtNewCustomers.Rows(j).Item("CollectorID")))
                    command2.Parameters.AddWithValue("@SalesManId", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("SalesManID")) Or IsNothing(DtNewCustomers.Rows(j).Item("SalesManID")), DBNull.Value, DtNewCustomers.Rows(j).Item("SalesManID")))
                    command2.Parameters.AddWithValue("@Stk_ThirdGroupid", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("Stk_ThirdGroupId")) Or IsNothing(DtNewCustomers.Rows(j).Item("Stk_ThirdGroupId")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_ThirdGroupId")))
                    command2.Parameters.AddWithValue("@Stk_CustCatId", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("Stk_CustCatID")) Or IsNothing(DtNewCustomers.Rows(j).Item("Stk_CustCatID")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_CustCatID")))
                    command2.Parameters.AddWithValue("@Stk_CustCurCode", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("Stk_CustCurCode")) Or IsNothing(DtNewCustomers.Rows(j).Item("Stk_CustCurCode")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_CustCurCode")))
                    command2.Parameters.AddWithValue("@Stk_CustPriceCode", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("Stk_CustPriceCode")) Or IsNothing(DtNewCustomers.Rows(j).Item("Stk_CustPriceCode")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_CustPriceCode")))
                    command2.Parameters.AddWithValue("@Stk_CustSalesList", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("Stk_CustSalesList")) Or IsNothing(DtNewCustomers.Rows(j).Item("Stk_CustSalesList")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_CustSalesList")))
                    command2.Parameters.AddWithValue("@Stk_CustBlocked", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_CustBlocked")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_CustBlocked")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_CustBlocked")))
                    command2.Parameters.AddWithValue("@Stk_CustApplyVat", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_CustApplyVat")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_CustApplyVat")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_CustApplyVat")))
                    command2.Parameters.AddWithValue("@Stk_CustDirectPost", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_CustDirectPost")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_CustDirectPost")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_CustDirectPost")))
                    command2.Parameters.AddWithValue("@Stk_CustGroupInPosting", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_CustGroupInPosting")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_CustGroupInPosting")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_CustGroupInPosting")))
                    command2.Parameters.AddWithValue("@STK_CustMarkUp", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_CustMarkUp")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_CustMarkUp")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_CustMarkUp")))
                    command2.Parameters.AddWithValue("@Stk_CustDisc1", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_CustDisc1")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_CustDisc1")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_CustDisc1")))
                    command2.Parameters.AddWithValue("@Stk_CustDisc2", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_CustDisc2")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_CustDisc2")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_CustDisc2")))
                    command2.Parameters.AddWithValue("@Stk_CustRetailCredit", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_CustRetailCredit")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_CustRetailCredit")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_CustRetailCredit")))
                    command2.Parameters.AddWithValue("@Stk_CustAppearInRetail", 1)
                    command2.Parameters.AddWithValue("@Stk_CustLimit", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_CustLimit")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_CustLimit")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_CustLimit")))
                    command2.Parameters.AddWithValue("@Stk_CustLimitAllCmp", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_CustLimitAllCmp")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_CustLimitAllCmp")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_CustLimitAllCmp")))
                    command2.Parameters.AddWithValue("@Stk_CustLimitAllLedger", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_CustLimitAllLedger")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_CustLimitAllLedger")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_CustLimitAllLedger")))
                    command2.Parameters.AddWithValue("@Stk_CustTerms", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_CustTerms")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_CustTerms")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_CustTerms")))
                    command2.Parameters.AddWithValue("@Stk_CustDeliver1", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_CustDeliver1")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_CustDeliver1")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_CustDeliver1")))
                    command2.Parameters.AddWithValue("@Stk_CustDeliver2", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_CustDeliver2")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_CustDeliver2")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_CustDeliver2")))
                    command2.Parameters.AddWithValue("@Stk_CustDeliver3", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_CustDeliver3")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_CustDeliver3")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_CustDeliver3")))
                    command2.Parameters.AddWithValue("@Stk_SupCatId", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_SupCatID")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_SupCatID")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_SupCatID")))
                    command2.Parameters.AddWithValue("@Stk_SupCurCode", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("Stk_SupCurCode")) Or IsNothing(DtNewCustomers.Rows(j).Item("Stk_SupCurCode")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_SupCurCode")))
                    command2.Parameters.AddWithValue("@Stk_SupPriceCode", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_SupPriceCode")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_SupPriceCode")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_SupPriceCode")))
                    command2.Parameters.AddWithValue("@Stk_SupDirectPost", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_SupDirectPost")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_SupDirectPost")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_SupDirectPost")))
                    command2.Parameters.AddWithValue("@Stk_SupGroupInPosting", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_SupGroupInPosting")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_SupGroupInPosting")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_SupGroupInPosting")))
                    command2.Parameters.AddWithValue("@Stk_SupApplyVat", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_SupApplyVat")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_SupApplyVat")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_SupApplyVat")))
                    command2.Parameters.AddWithValue("@Stk_Suplimit", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_SupLimit")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_SupLimit")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_SupLimit")))
                    command2.Parameters.AddWithValue("@Stk_SupLimitAllCmp", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_SupLimitAllCmp")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_SupLimitAllCmp")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_SupLimitAllCmp")))
                    command2.Parameters.AddWithValue("@Stk_SupLimitAllLedger", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_SupLimitAllLedger")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_SupLimitAllLedger")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_SupLimitAllLedger")))
                    command2.Parameters.AddWithValue("@Stk_SupTerms", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_SupTerms")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_SupTerms")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_SupTerms")))
                    command2.Parameters.AddWithValue("@Stk_SupBlocked", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_SupBlocked")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_SupBlocked")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_SupBlocked")))
                    command2.Parameters.AddWithValue("@Stk_SalCatId", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_SalCatID")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_SalCatID")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_SalCatID")))
                    command2.Parameters.AddWithValue("@Stk_SalCommission", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_SalCommission")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_SalCommission")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_SalCommission")))
                    command2.Parameters.AddWithValue("@Stk_SalSpervisorCom", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_SalSpervisorCom")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_SalSpervisorCom")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_SalSpervisorCom")))
                    command2.Parameters.AddWithValue("@Stk_SalBlocked", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_SalBlocked")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_SalBlocked")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_SalBlocked")))
                    command2.Parameters.AddWithValue("@Stk_CustPoints", IIf(IsNothing(DtNewCustomers.Rows(j).Item("Stk_CustPoints")) Or IsDBNull(DtNewCustomers.Rows(j).Item("Stk_CustPoints")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_CustPoints")))
                    command2.Parameters.AddWithValue("@BankLimit", 0)
                    command2.Parameters.AddWithValue("@Stk_PostToThirdid", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("Stk_PostToThirdID")) Or IsNothing(DtNewCustomers.Rows(j).Item("Stk_PostToThirdID")), DBNull.Value, DtNewCustomers.Rows(j).Item("Stk_PostToThirdID")))
                    command2.Parameters.AddWithValue("@DeliveryTerms", IIf(IsNothing(DtNewCustomers.Rows(j).Item("DeliveryTerms")) Or IsDBNull(DtNewCustomers.Rows(j).Item("DeliveryTerms")), DBNull.Value, DtNewCustomers.Rows(j).Item("DeliveryTerms")))
                    command2.Parameters.AddWithValue("@PaymentTerms", IIf(IsNothing(DtNewCustomers.Rows(j).Item("PaymentTerms")) Or IsDBNull(DtNewCustomers.Rows(j).Item("PaymentTerms")), DBNull.Value, DtNewCustomers.Rows(j).Item("PaymentTerms")))
                    command2.Parameters.AddWithValue("@OperMess", IIf(IsNothing(DtNewCustomers.Rows(j).Item("OperMess")) Or IsDBNull(DtNewCustomers.Rows(j).Item("OperMess")), DBNull.Value, DtNewCustomers.Rows(j).Item("OperMess")))
                    command2.Parameters.AddWithValue("@collector2id", IIf(IsDBNull(DtNewCustomers.Rows(j).Item("Collector2ID")) Or IsNothing(DtNewCustomers.Rows(j).Item("Collector2ID")), DBNull.Value, DtNewCustomers.Rows(j).Item("Collector2ID")))
                    sqls += CommandAsSql(command2)
                Next
                If sqls <> "" Then
                    Dim transaction As SqlTransaction = Nothing
                    Dim transcommand As SqlCommand = BoCnx.CreateCommand()
                    If BoCnx.State = ConnectionState.Closed Then
                        BoCnx.Open()
                    End If
                    transaction = BoCnx.BeginTransaction("SampleTransaction")
                    transcommand.Connection = BoCnx
                    transcommand.Transaction = transaction
                    transcommand.CommandText = sqls
                    transcommand.CommandType = CommandType.Text
                    Try
                        transcommand.ExecuteNonQuery()
                        transaction.Commit()
                        sqls = ""
                        DtNewCustomers.Dispose()
                        DtNewCustomers = Nothing
                        Dim sqlcom As New SqlCommand("Delete From sacthirdExtrab1es", FrmLogin.objcon.con)
                        If FrmLogin.objcon.con.State = ConnectionState.Closed Then
                            FrmLogin.objcon.con.Open()
                        End If
                        sqlcom.ExecuteNonQuery()
                        sqlcom = New SqlCommand("Delete From sacthirdPartyA", FrmLogin.objcon.con)
                        If FrmLogin.objcon.con.State = ConnectionState.Closed Then
                            FrmLogin.objcon.con.Open()
                        End If
                        sqlcom.ExecuteNonQuery()
                        sqlcom.Dispose()
                        Utilities.WriteToText("InsertCustomerInBO: ", "Successfully Inserted In Back Office")
                    Catch ex As Exception
                        Utilities.WriteToText("InsertCustomerInBO Commit Type Failed Due To : ", ex.GetType().ToString)
                        Utilities.WriteToText("InsertCustomerInBO Commit Message Failed Due To : ", ex.Message)
                        Dim ClsLog As New ClsLogs
                        ClsLog._BackOffice = ""
                        ClsLog._PosCode = ""
                        ClsLog._FunctionN = "InsertCustomersInBO"
                        ClsLog._Desc = ex.Message
                        ClsLog._Sql = sqls
                        ClsLog.WriteToTable(FrmLogin.objcon.con)
                        Try
                            transaction.Rollback()
                        Catch ex2 As Exception
                            Utilities.WriteToText("InsertCustomerInBO Rollback Type Failed Due To : ", ex2.GetType().ToString)
                            Utilities.WriteToText("InsertCustomerInBO Rollback Message Failed Due To : ", ex2.Message)
                        End Try
                    End Try
                End If
            Catch ex As Exception
                Utilities.WriteToText("InsertCustomerInBO Failed Due To: ", ex.Message)
            End Try
        Catch ex As Exception
            Utilities.WriteToText("InsertCustomerInBO Failed Due To: ", ex.Message)
        End Try
    End Sub
    Public Sub SaveThirdExtraInBo(ByVal thirdid As Integer, ByVal dt As DataTable, ByVal i As Integer, ByVal Con As SqlConnection)
        Try
            Dim ClsThirdExtra As New ClsThirdExtra
            ClsThirdExtra._ThirdId = thirdid
            ClsThirdExtra._CollectorId = dt.Rows(i).Item("CollectorID")
            ClsThirdExtra._collector2id = IIf(IsDBNull(dt.Rows(i).Item("Collector2ID")) Or IsNothing(dt.Rows(i).Item("Collector2ID")), DBNull.Value, dt.Rows(i).Item("Collector2ID"))
            ClsThirdExtra._SalesManId = IIf(IsDBNull(dt.Rows(i).Item("SalesManID")) Or IsNothing(dt.Rows(i).Item("SalesManID")), DBNull.Value, dt.Rows(i).Item("SalesManID"))
            ClsThirdExtra._Stk_ThirdGroupid = IIf(IsDBNull(dt.Rows(i).Item("Stk_ThirdGroupId")) Or IsNothing(dt.Rows(i).Item("Stk_ThirdGroupId")), DBNull.Value, dt.Rows(i).Item("Stk_ThirdGroupId"))
            ClsThirdExtra._Stk_PostToThirdid = IIf(IsDBNull(dt.Rows(i).Item("Stk_PostToThirdID")) Or IsNothing(dt.Rows(i).Item("Stk_PostToThirdID")), DBNull.Value, dt.Rows(i).Item("Stk_PostToThirdID"))
            ClsThirdExtra._Stk_CustCatId = IIf(IsDBNull(dt.Rows(i).Item("Stk_CustCatID")) Or IsNothing(dt.Rows(i).Item("Stk_CustCatID")), DBNull.Value, dt.Rows(i).Item("Stk_CustCatID"))
            ClsThirdExtra._Stk_CustPriceCode = IIf(IsDBNull(dt.Rows(i).Item("Stk_CustPriceCode")) Or IsNothing(dt.Rows(i).Item("Stk_CustPriceCode")), DBNull.Value, dt.Rows(i).Item("Stk_CustPriceCode"))
            ClsThirdExtra._Stk_CustSalesList = IIf(IsDBNull(dt.Rows(i).Item("Stk_CustSalesList")) Or IsNothing(dt.Rows(i).Item("Stk_CustSalesList")), DBNull.Value, dt.Rows(i).Item("Stk_CustSalesList"))
            ClsThirdExtra._Stk_CustCurCode = IIf(IsDBNull(dt.Rows(i).Item("Stk_CustCurCode")) Or IsNothing(dt.Rows(i).Item("Stk_CustCurCode")), DBNull.Value, dt.Rows(i).Item("Stk_CustCurCode"))
            ClsThirdExtra._Stk_CustAppearInRetail = 1
            ClsThirdExtra._Stk_CustApplyVat = dt.Rows(i).Item("Stk_CustApplyVat")
            ClsThirdExtra._Stk_CustBlocked = dt.Rows(i).Item("Stk_CustBlocked")
            ClsThirdExtra._Stk_CustDirectPost = dt.Rows(i).Item("Stk_CustDirectPost")
            ClsThirdExtra._Stk_CustGroupInPosting = dt.Rows(i).Item("Stk_CustGroupInPosting")
            ClsThirdExtra._STK_CustMarkUp = dt.Rows(i).Item("Stk_CustMarkUp")
            ClsThirdExtra._Stk_CustDisc1 = dt.Rows(i).Item("Stk_CustDisc1")
            ClsThirdExtra._Stk_CustDisc2 = dt.Rows(i).Item("Stk_CustDisc2")
            ClsThirdExtra._Stk_CustLimit = dt.Rows(i).Item("Stk_CustLimit")
            ClsThirdExtra._Stk_CustTerms = dt.Rows(i).Item("Stk_CustTerms")
            ClsThirdExtra._Stk_CustPoints = dt.Rows(i).Item("Stk_CustPoints")
            ClsThirdExtra._Stk_CustRetailCredit = dt.Rows(i).Item("Stk_CustRetailCredit")
            ClsThirdExtra._Stk_CustLimitAllCmp = dt.Rows(i).Item("Stk_CustLimitAllCmp")
            ClsThirdExtra._Stk_CustLimitAllLedger = dt.Rows(i).Item("Stk_CustLimitAllLedger")
            ClsThirdExtra._PaymentTerms = dt.Rows(i).Item("PaymentTerms")
            ClsThirdExtra._DeliveryTerms = dt.Rows(i).Item("DeliveryTerms")
            ClsThirdExtra._OperMess = dt.Rows(i).Item("OperMess")

            ClsThirdExtra._Stk_SupApplyVat = dt.Rows(i).Item("Stk_SupApplyVat")
            ClsThirdExtra._Stk_SupBlocked = dt.Rows(i).Item("Stk_SupBlocked")
            ClsThirdExtra._Stk_SupDirectPost = dt.Rows(i).Item("Stk_SupDirectPost")
            ClsThirdExtra._Stk_SupGroupInPosting = dt.Rows(i).Item("Stk_SupGroupInPosting")
            ClsThirdExtra._Stk_SupCatId = dt.Rows(i).Item("Stk_SupCatID")
            ClsThirdExtra._Stk_SupPriceCode = dt.Rows(i).Item("Stk_SupPriceCode")
            ClsThirdExtra._Stk_SupCurCode = IIf(IsDBNull(dt.Rows(i).Item("Stk_SupCurCode")) Or IsNothing(dt.Rows(i).Item("Stk_SupCurCode")), DBNull.Value, dt.Rows(i).Item("Stk_SupCurCode"))
            ClsThirdExtra._Stk_SupLimitAllCmp = dt.Rows(i).Item("Stk_SupLimitAllCmp")
            ClsThirdExtra._Stk_SupLimitAllLedger = dt.Rows(i).Item("Stk_SupLimitAllLedger")
            ClsThirdExtra._Stk_Suplimit = dt.Rows(i).Item("Stk_SupLimit")
            ClsThirdExtra._Stk_SupTerms = dt.Rows(i).Item("Stk_SupTerms")
            ClsThirdExtra._Stk_SalBlocked = dt.Rows(i).Item("Stk_SalBlocked")
            ClsThirdExtra._Stk_SalCatId = dt.Rows(i).Item("Stk_SalCatID")
            ClsThirdExtra._Stk_SalCommission = dt.Rows(i).Item("Stk_SalCommission")
            ClsThirdExtra._Stk_SalSpervisorCom = dt.Rows(i).Item("Stk_SalSpervisorCom")
            ClsThirdExtra._Stk_CustDeliver1 = dt.Rows(i).Item("Stk_CustDeliver1")
            ClsThirdExtra._Stk_CustDeliver2 = dt.Rows(i).Item("Stk_CustDeliver2")
            ClsThirdExtra._Stk_CustDeliver3 = dt.Rows(i).Item("Stk_CustDeliver3")
            ClsThirdExtra.ThirdExtraBoToPOS(Con)
        Catch ex As Exception
            Utilities.WriteToText("SaveThirdExtraInBo Failed Due To: ", ex.Message)
        End Try
    End Sub
    Public Sub InsertNewItemsControl()
        Dim WhsCode = ""
        Dim Sqls = ""
        Try
            Dim ClsPos As New ClsPOS
            Dim dt As New DataTable
            dt = ClsPos.GetPosConfig(FrmLogin.objcon.con)
            Dim ClsItemA As New ClsItemA
            Dim BoConxString = "Data Source ='" & FrmMainForm.BOServer & "';Initial Catalog='" & FrmMainForm.BODatabase & "';user ID='" & FrmMainForm.BOUser & "';password='" & FrmMainForm.BOPass & "'"
            Dim BoCnx As SqlConnection = New SqlConnection(BoConxString)
            Dim blnconnectionOpen1 = ConnStatus(BoCnx)
            If Not blnconnectionOpen1 Then ConnOpen(BoCnx)
            Try
                For i = 0 To dt.Rows.Count - 1

                    Sqls = ""
                    WhsCode = dt.Rows(i).Item("WhsCode")
                    Dim Pos = dt.Rows(i).Item("PosCode")
                    If PosIsInstalled(Pos) = False Then Continue For
                    Dim DtNewItems = ClsItemA.BoGetNewItemsControl(dt.Rows(i).Item("WhsCode"), BoCnx)
                    Dim blnconnectionOpen As Boolean = False
                    blnconnectionOpen = ConnStatus(BoCnx)
                    If Not blnconnectionOpen Then ConnOpen(BoCnx)
                    For j = 0 To DtNewItems.Rows.Count - 1
                        Dim command As SqlCommand = BoCnx.CreateCommand()
                        command.Connection = BoCnx
                        command.CommandText = "SpIv_InsertItemControl"
                        command.CommandType = CommandType.StoredProcedure
                        command.Parameters.AddWithValue("@Barcode", IIf(IsNothing(DtNewItems.Rows(j).Item("Barcode")) Or IsDBNull(DtNewItems.Rows(j).Item("Barcode")), DBNull.Value, DtNewItems.Rows(j).Item("Barcode")))
                        command.Parameters.AddWithValue("@WhsCode", IIf(IsNothing(dt.Rows(i).Item("WhsCode")) Or IsDBNull(dt.Rows(i).Item("WhsCode")), DBNull.Value, dt.Rows(i).Item("WhsCode")))
                        command.Parameters.AddWithValue("@MinQty", 0)
                        command.Parameters.AddWithValue("@MaxQty", 0)
                        command.Parameters.AddWithValue("@Blocked", False)
                        Sqls += CommandAsSql(command)

                    Next
                    If Sqls <> "" Then
                        Dim transaction As SqlTransaction = Nothing
                        If BoCnx.State = ConnectionState.Closed Then
                            BoCnx.Open()
                        End If
                        Dim transcommand As SqlCommand = BoCnx.CreateCommand()
                        transaction = BoCnx.BeginTransaction("SampleTransaction")
                        transcommand.Connection = BoCnx
                        transcommand.Transaction = transaction
                        transcommand.CommandText = Sqls
                        transcommand.CommandType = CommandType.Text
                        Try
                            transcommand.ExecuteNonQuery()
                            transaction.Commit()
                            Utilities.WriteToText("InsertNewItemsControl: In BackOffice ", "Successfully Inserted")
                        Catch ex As Exception
                            Utilities.WriteToText("InsertNewItemsControl: In BackOffice Commit Type Failed Due To : ", ex.GetType().ToString)
                            Utilities.WriteToText("InsertNewItemsControl: In BackOffice Commit Message Failed Due To : ", ex.Message)
                            Dim ClsLog As New ClsLogs
                            ClsLog._BackOffice = ""
                            ClsLog._PosCode = ""
                            ClsLog._FunctionN = "InsertNewItemsControlInBo"
                            ClsLog._Desc = ex.Message
                            ClsLog._Sql = Sqls
                            ClsLog.WriteToTable(FrmLogin.objcon.con)
                            Try
                                transaction.Rollback()
                            Catch ex2 As Exception
                                Utilities.WriteToText("InsertNewItemsControl: In BackOffice Rollback Type Failed Due To : ", ex2.GetType().ToString)
                                Utilities.WriteToText("InsertNewItemsControl: In BackOffice  Rollback Message Failed Due To : ", ex2.Message)
                            End Try
                        Finally
                            If BoCnx.State = ConnectionState.Open Then BoCnx.Close()
                        End Try
                    End If
                Next
            Catch ex As Exception
                Utilities.WriteToText("InsertNewItemsControl: In Back Office Failed Due to ", ex.Message)
            End Try
        Catch ex As Exception
            Utilities.WriteToText("InsertNewItemsControl: In Back Office Failed Due to ", ex.Message)
        End Try
    End Sub
    Public Sub GetWhsAdjustments()
        Dim Whs = ""
        Dim SqlS = ""
        Try
            Dim ClsPos As New ClsPOS
            Dim OperID As Integer
            Dim ClsOperationA As New ClsOperationA
            Dim dt As New DataTable
            dt = ClsPos.GetPosConfig(FrmLogin.objcon.con)
            Dim WhsCount = 0
            Dim OperIDOld As Integer = 0
            Dim OperIDNew As Integer = 0
            Dim Count As Integer = 0
            Dim con As SqlConnection
            Try
                For i = 0 To dt.Rows.Count - 1

                    SqlS = ""
                    Dim DtDeliveryOrders = ClsOperationA.GetWhsAdjustments(WhsAdjustment, dt.Rows(i).Item("WhsCode"), FrmLogin.objcon.con)
                    Whs = dt.Rows(i).Item("WhsCode")
                    Dim Pos = dt.Rows(i).Item("PosCode")
                    If PosIsInstalled(Pos) = False Then Continue For


                    Dim BoConxString = "Data Source ='" & FrmMainForm.BOServer & "';Initial Catalog='" & FrmMainForm.BODatabase & "';user ID='" & FrmMainForm.BOUser & "';password='" & FrmMainForm.BOPass & "'; Connection Timeout= 120"
                    Dim BoCnx As SqlConnection = New SqlConnection(BoConxString)

                    Dim blnconnectionOpen1 = ConnStatus(BoCnx)
                    If Not blnconnectionOpen1 Then ConnOpen(BoCnx)

                    Dim strconnection As String = "Data Source ='" & dt.Rows(i).Item("PosServer") & "';Initial Catalog='" & dt.Rows(i).Item("PosDatabase") & "';user ID='" & dt.Rows(i).Item("PosUser") & "';password='" & dt.Rows(i).Item("PosPass") & "';Connection Timeout = 320"
                    con = New SqlConnection(strconnection)

                    Dim IaStamp As String = GetItemsTimeStamp(Pos, FrmLogin.objcon.con)

                    Dim IbStamp As String = GetItemsBTimeStamp(Pos, FrmLogin.objcon.con)

                    If IaStamp <> GetMaxItemsTimeStamp(BoCnx) Then
                        Continue For
                    End If
                    If IbStamp <> GetMaxItemsBTimeStamp(BoCnx) Then
                        Continue For
                    End If

                    OperIDOld = 0
                    If DtDeliveryOrders.Rows.Count <> 0 Then
                        If con.State = ConnectionState.Closed Then
                            Try
                                con.Open()
                            Catch ex As Exception
                                Utilities.WriteToText("InsertWHSAdjustment: In POS: " & Whs, " Connection could not be established")
                                Exit Sub
                            End Try
                        End If
                        For j = 0 To DtDeliveryOrders.Rows.Count - 1
                            OperIDNew = DtDeliveryOrders.Rows(j).Item("OperId")
                            If OperIDNew <> OperIDOld Then
                                If Count = 0 Then
                                    Dim sqlcomm As New SqlCommand("select Sequence from sacsequence where SeqCode='invtype" & WhsAdjustment & "' and seqyear=" & Today.Year & "", con)
                                    If IsDBNull(sqlcomm.ExecuteScalar) Or IsNothing(sqlcomm.ExecuteScalar) Then
                                        Dim sqlc As New SqlCommand("insert into SacSequence (SeqCode,SeqYear,Companyid,Sequence) values ('invtype" &
                                                                   WhsAdjustment & "'," & Today.Year & ",1," & Today.Year & "000000)", con)

                                        sqlc.ExecuteNonQuery()
                                    End If
                                    sqlcomm = New SqlCommand("select Sequence from sacsequence where SeqCode='invtype" & WhsAdjustment & "' and seqyear=" & Today.Year & "", con)
                                    OperID = sqlcomm.ExecuteScalar + 1
                                Else
                                    OperID += 1
                                End If
                                Dim command As SqlCommand = con.CreateCommand()
                                command.CommandText = "SpIv_BODeliveryOrderAInsert"
                                command.CommandType = CommandType.StoredProcedure

                                command.Parameters.AddWithValue("@OperId", OperID)
                                command.Parameters.AddWithValue("@InvTypeId", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("InvTypeId")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("InvTypeId")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("InvTypeId")))
                                command.Parameters.AddWithValue("@OperDate", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("OperDate")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("OperDate")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("OperDate")))
                                command.Parameters.AddWithValue("@ActivationDate", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("ActivationDate")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("ActivationDate")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("ActivationDate")))
                                command.Parameters.AddWithValue("@ThirdId", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("ThirdId")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("ThirdId")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("ThirdId")))
                                command.Parameters.AddWithValue("@ThirdDesc", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("ThirdDesc")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("ThirdDesc")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("ThirdDesc")))
                                command.Parameters.AddWithValue("@SalesManId", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("SalesManId")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("SalesManId")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("SalesManId")))
                                command.Parameters.AddWithValue("@PosCode", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("PosCode")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("PosCode")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("PosCode")))
                                command.Parameters.AddWithValue("@WhsCode", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("WhsCode")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("WhsCode")), DBNull.Value, Whs))
                                command.Parameters.AddWithValue("@CurCode", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("CurCode")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("CurCode")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("CurCode")))
                                command.Parameters.AddWithValue("@Delivery1", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("Delivery1")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("Delivery1")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("Delivery1")))
                                command.Parameters.AddWithValue("@Delivery2", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("Delivery2")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("Delivery2")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("Delivery2")))
                                command.Parameters.AddWithValue("@Delivery3", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("Delivery3")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("Delivery3")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("Delivery3")))
                                command.Parameters.AddWithValue("@Posted", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("Posted")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("Posted")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("Posted")))
                                command.Parameters.AddWithValue("@TransId", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("TransId")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("TransId")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("TransId")))
                                command.Parameters.AddWithValue("@Status", 0)
                                command.Parameters.AddWithValue("@ApplyVat", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("ApplyVat")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("ApplyVat")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("ApplyVat")))
                                command.Parameters.AddWithValue("@Confirmed", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("Confirmed")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("Confirmed")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("Confirmed")))
                                command.Parameters.AddWithValue("@Closed", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("Closed")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("Closed")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("Closed")))
                                command.Parameters.AddWithValue("@Costed", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("Costed")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("Costed")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("Costed")))
                                command.Parameters.AddWithValue("@AvgCosted", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("AvgCosted")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("AvgCosted")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("AvgCosted")))
                                command.Parameters.AddWithValue("@RateFl", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("RateFl")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("RateFl")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("RateFl")))
                                command.Parameters.AddWithValue("@RateSl", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("RateSl")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("RateSl")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("RateSl")))
                                command.Parameters.AddWithValue("@RateVat", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("RateVat")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("RateVat")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("RateVat")))
                                command.Parameters.AddWithValue("@ManualRef", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("ManualRef")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("ManualRef")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("ManualRef")))
                                command.Parameters.AddWithValue("@RefDate", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("RefDate")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("RefDate")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("RefDate")))
                                command.Parameters.AddWithValue("@GrossAmt", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("GrossAmt")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("GrossAmt")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("GrossAmt")))
                                command.Parameters.AddWithValue("@Disc1Pct", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("Disc1Pct")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("Disc1Pct")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("Disc1Pct")))
                                command.Parameters.AddWithValue("@Disc1Amt", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("Disc1Amt")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("Disc1Amt")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("Disc1Amt")))
                                command.Parameters.AddWithValue("@Disc2Pct", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("Disc2Pct")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("Disc2Pct")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("Disc2Pct")))
                                command.Parameters.AddWithValue("@Disc2Amt", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("Disc2Amt")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("Disc2Amt")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("Disc2Amt")))
                                command.Parameters.AddWithValue("@ExtraChargeAmt", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("ExtraChargeAmt")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("ExtraChargeAmt")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("ExtraChargeAmt")))
                                command.Parameters.AddWithValue("@ExtraChargeVat", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("ExtraChargeVat")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("ExtraChargeVat")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("ExtraChargeVat")))
                                command.Parameters.AddWithValue("@AddDiscAmt", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("AddDiscAmt")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("AddDiscAmt")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("AddDiscAmt")))
                                command.Parameters.AddWithValue("@NetAmt", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("NetAmt")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("NetAmt")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("NetAmt")))
                                command.Parameters.AddWithValue("@VatAmt", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("VatAmt")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("VatAmt")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("VatAmt")))
                                command.Parameters.AddWithValue("@Notes", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("Notes")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("Notes")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("Notes")))
                                command.Parameters.AddWithValue("@Iuser", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("Iuser")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("Iuser")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("Iuser")))
                                command.Parameters.AddWithValue("@Idate", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("Idate")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("Idate")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("Idate")))
                                command.Parameters.AddWithValue("@UUser", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("UUser")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("UUser")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("UUser")))
                                command.Parameters.AddWithValue("@UDate", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("UDate")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("UDate")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("UDate")))
                                command.Parameters.AddWithValue("@Message", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("Message")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("Message")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("Message")))
                                command.Parameters.AddWithValue("@DeliveryTerms", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("DeliveryTerms")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("DeliveryTerms")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("DeliveryTerms")))
                                command.Parameters.AddWithValue("@PaymentTerms", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("PaymentTerms")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("PaymentTerms")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("PaymentTerms")))
                                command.Parameters.AddWithValue("@ContractId", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("ContractId")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("ContractId")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("ContractId")))
                                command.Parameters.AddWithValue("@ContractCode", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("ContractCode")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("ContractCode")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("ContractCode")))
                                command.Parameters.AddWithValue("@AssignToId", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("AssignToId")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("AssignToId")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("AssignToId")))
                                command.Parameters.AddWithValue("@MopTransID", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("MopTransID")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("MopTransID")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("MopTransID")))
                                command.Parameters.AddWithValue("@Gift", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("Gift")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("Gift")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("Gift")))
                                command.Parameters.AddWithValue("@GiftReturnDate", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("GiftReturnDate")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("GiftReturnDate")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("GiftReturnDate")))
                                command.Parameters.AddWithValue("@Seen", 1)
                                SqlS += CommandAsSql(command)

                                OperIDOld = DtDeliveryOrders.Rows(j).Item("OperId")
                                Count += 1
                            End If
                            Dim command1 As SqlCommand = con.CreateCommand()
                            command1.Connection = con
                            command1.CommandText = "SpIv_BODeliveryOrderBInsert"
                            command1.CommandType = CommandType.StoredProcedure
                            command1.Parameters.AddWithValue("@OperId", OperID)
                            command1.Parameters.AddWithValue("@InvTypeId", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("InvTypeId")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("InvTypeId")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("InvTypeId")))
                            command1.Parameters.AddWithValue("@LigneId", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("LigneId")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("LigneId")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("LigneId")))
                            command1.Parameters.AddWithValue("@ItemBId", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("ItemBId")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("ItemBId")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("ItemBId")))
                            command1.Parameters.AddWithValue("@ItemAid", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("ItemAid")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("ItemAid")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("ItemAid")))
                            command1.Parameters.AddWithValue("@BarCode", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("BarCode")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("BarCode")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("BarCode")))
                            command1.Parameters.AddWithValue("@ItemShDescription", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("ItemShDescription")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("ItemShDescription")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("ItemShDescription")))
                            command1.Parameters.AddWithValue("@WhsCode", Whs)
                            command1.Parameters.AddWithValue("@SizeCode", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("SizeCode")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("SizeCode")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("SizeCode")))
                            command1.Parameters.AddWithValue("@ColorCode", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("ColorCode")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("ColorCode")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("ColorCode")))
                            command1.Parameters.AddWithValue("@LigneDesc", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("LigneDesc")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("LigneDesc")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("LigneDesc")))
                            command1.Parameters.AddWithValue("@ReasonId", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("ReasonId")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("ReasonId")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("ReasonId")))
                            command1.Parameters.AddWithValue("@KitHead", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("KitHead")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("KitHead")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("KitHead")))
                            command1.Parameters.AddWithValue("@KitLink", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("KitLink")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("KitLink")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("KitLink")))
                            command1.Parameters.AddWithValue("@Up", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("Up")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("Up")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("Up")))
                            command1.Parameters.AddWithValue("@Qty", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("Qty")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("Qty")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("Qty")))
                            command1.Parameters.AddWithValue("@F_Qty", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("F_Qty")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("F_Qty")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("F_Qty")))
                            command1.Parameters.AddWithValue("@AltQty", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("AltQty")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("AltQty")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("AltQty")))
                            command1.Parameters.AddWithValue("@AltF_Qty", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("AltF_Qty")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("AltF_Qty")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("AltF_Qty")))
                            command1.Parameters.AddWithValue("@UOMCode", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("UOMCode")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("UOMCode")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("UOMCode")))
                            command1.Parameters.AddWithValue("@Factor", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("Factor")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("Factor")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("Factor")))
                            command1.Parameters.AddWithValue("@Sign", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("Sign")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("Sign")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("Sign")))
                            command1.Parameters.AddWithValue("@DiscPct", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("DiscPct")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("DiscPct")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("DiscPct")))
                            command1.Parameters.AddWithValue("@DiscAmt", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("DiscAmt")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("DiscAmt")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("DiscAmt")))
                            command1.Parameters.AddWithValue("@TotalLigne", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("TotalLigne")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("TotalLigne")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("TotalLigne")))
                            command1.Parameters.AddWithValue("@VatAmt", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("VatBAmt")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("VatBAmt")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("VatBAmt")))
                            command1.Parameters.AddWithValue("@VatPct", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("VatPct")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("VatPct")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("VatPct")))
                            command1.Parameters.AddWithValue("@HeadDisc", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("HeadDisc")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("HeadDisc")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("HeadDisc")))
                            command1.Parameters.AddWithValue("@CreditNote", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("CreditNote")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("CreditNote")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("CreditNote")))
                            command1.Parameters.AddWithValue("@DebitNote", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("DebitNote")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("DebitNote")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("DebitNote")))
                            command1.Parameters.AddWithValue("@QtyAffect", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("QtyAffect")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("QtyAffect")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("QtyAffect")))
                            command1.Parameters.AddWithValue("@AltQtyAffect", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("AltQtyAffect")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("AltQtyAffect")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("AltQtyAffect")))
                            command1.Parameters.AddWithValue("@QtyRemain", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("QtyRemain")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("QtyRemain")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("QtyRemain")))
                            command1.Parameters.AddWithValue("@F_QtyRemain", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("F_QtyRemain")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("F_QtyRemain")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("F_QtyRemain")))
                            command1.Parameters.AddWithValue("@AltQtyRemain", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("AltQtyRemain")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("AltQtyRemain")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("AltQtyRemain")))
                            command1.Parameters.AddWithValue("@F_AltQtyRemain", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("F_AltQtyRemain")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("F_AltQtyRemain")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("F_AltQtyRemain")))
                            command1.Parameters.AddWithValue("@UnitCost", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("UnitCost")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("UnitCost")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("UnitCost")))
                            command1.Parameters.AddWithValue("@UnitCostRateFl", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("UnitCostRateFl")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("UnitCostRateFl")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("UnitCostRateFl")))
                            command1.Parameters.AddWithValue("@UnitCostRateSl", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("UnitCostRateSl")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("UnitCostRateSl")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("UnitCostRateSl")))
                            command1.Parameters.AddWithValue("@AvgCost", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("AvgCost")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("AvgCost")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("AvgCost")))
                            command1.Parameters.AddWithValue("@Fl_AvgCost", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("Fl_AvgCost")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("Fl_AvgCost")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("Fl_AvgCost")))
                            command1.Parameters.AddWithValue("@Sl_AvgCost", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("Sl_AvgCost")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("Sl_AvgCost")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("Sl_AvgCost")))
                            command1.Parameters.AddWithValue("@QtyOnHand", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("QtyOnHand")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("QtyOnHand")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("QtyOnHand")))
                            command1.Parameters.AddWithValue("@CostingOrder", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("CostingOrder")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("CostingOrder")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("CostingOrder")))
                            command1.Parameters.AddWithValue("@UUser", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("UUser")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("UUser")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("UUser")))
                            command1.Parameters.AddWithValue("@Udate", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("Udate")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("Udate")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("Udate")))
                            command1.Parameters.AddWithValue("@InfoRef", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("InfoRef")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("InfoRef")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("InfoRef")))
                            command1.Parameters.AddWithValue("@ContractSubId", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("ContractSubId")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("ContractSubId")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("ContractSubId")))
                            command1.Parameters.AddWithValue("@ContractSubCode", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("ContractSubCode")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("ContractSubCode")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("ContractSubCode")))
                            command1.Parameters.AddWithValue("@lineorder", IIf(IsNothing(DtDeliveryOrders.Rows(j).Item("lineorder")) Or IsDBNull(DtDeliveryOrders.Rows(j).Item("lineorder")), DBNull.Value, DtDeliveryOrders.Rows(j).Item("lineorder")))
                            SqlS += CommandAsSql(command1)
                        Next
                        If SqlS <> "" Then
                            Dim transaction As SqlTransaction = Nothing
                            If con.State = ConnectionState.Closed Then
                                Try
                                    con.Open()
                                    Dim transcommand As SqlCommand = con.CreateCommand()
                                    transaction = con.BeginTransaction("SampleTransaction")
                                    ' Must assign both transaction object and connection
                                    ' to Command object for a pending local transaction.
                                    transcommand.Connection = con
                                    transcommand.Transaction = transaction
                                    transcommand.CommandText = SqlS
                                    transcommand.CommandType = CommandType.Text
                                    Try
                                        transcommand.ExecuteNonQuery()
                                        transaction.Commit()
                                        Dim sqlc As New SqlCommand(" update SacSequence set Sequence = " & OperID & " where SeqCode = 'invtype" & WhsAdjustment & "' and seqyear = " & Today.Year, con)
                                        If con.State = ConnectionState.Closed Then
                                            con.Open()
                                        End If
                                        sqlc.ExecuteNonQuery()
                                        sqlc = New SqlCommand("update IvOperationC1es set seen = 1 where WhsCode ='" & Whs & "' and invtypeid = " & WhsAdjustment, FrmLogin.objcon.con)
                                        If FrmLogin.objcon.con.State = ConnectionState.Closed Then
                                            FrmLogin.objcon.con.Open()
                                        End If
                                        sqlc.ExecuteNonQuery()
                                        Utilities.WriteToText("InsertWhsAdj In POS: " & Whs & ": ", "Successfully Inserted")
                                    Catch ex As Exception
                                        Utilities.WriteToText("InsertWhsAdj In POS: " & Whs & " Commit Type Failed Due To : ", ex.GetType().ToString)
                                        Utilities.WriteToText("InsertWhsAdj In POS: " & Whs & " Commit Message Failed Due To : ", ex.Message)
                                        Dim ClsLog As New ClsLogs
                                        ClsLog._BackOffice = ""
                                        ClsLog._PosCode = Whs
                                        ClsLog._FunctionN = "InsertWhsAdj"
                                        ClsLog._Desc = ex.Message
                                        ClsLog._Sql = SqlS
                                        ClsLog.WriteToTable(FrmLogin.objcon.con)
                                        Try
                                            transaction.Rollback()
                                        Catch ex2 As Exception
                                            Utilities.WriteToText("InsertWhsAdj In POS: " & Whs & " Rollback Type Failed Due To : ", ex.GetType().ToString)
                                            Utilities.WriteToText("InsertWhsAdj In POS: " & Whs & " Rollback Message Failed Due To : ", ex.Message)
                                        End Try
                                    Finally
                                        con.Close()
                                    End Try
                                Catch ex As Exception
                                    Utilities.WriteToText("InsertWhsAdj In POS: " & Whs, " Connection could not be established")
                                End Try
                            Else
                                Dim transcommand As SqlCommand = con.CreateCommand()
                                transaction = con.BeginTransaction("SampleTransaction")
                                transcommand.Connection = con
                                transcommand.Transaction = transaction
                                transcommand.CommandText = SqlS
                                transcommand.CommandType = CommandType.Text
                                Try
                                    transcommand.ExecuteNonQuery()
                                    transaction.Commit()
                                    Dim sqlc As New SqlCommand(" update SacSequence set Sequence = " & OperID & " where SeqCode = 'invtype" & WhsAdjustment & "' and seqyear = " & Today.Year, con)
                                    If con.State = ConnectionState.Closed Then
                                        con.Open()
                                    End If
                                    sqlc.ExecuteNonQuery()
                                    sqlc = New SqlCommand("update IvOperationC1es set seen = 1 where WhsCode ='" & Whs & "' and invtypeid = " & WhsAdjustment, FrmLogin.objcon.con)
                                    If FrmLogin.objcon.con.State = ConnectionState.Closed Then
                                        FrmLogin.objcon.con.Open()
                                    End If
                                    sqlc.ExecuteNonQuery()
                                    Utilities.WriteToText("InsertWhsAdj In POS: " & Whs & ": ", "Successfully Inserted")
                                Catch ex As Exception
                                    Utilities.WriteToText("InsertWhsAdj In POS: " & Whs & " Commit Type Failed Due To : ", ex.GetType().ToString)
                                    Utilities.WriteToText("InsertWhsAdj In POS: " & Whs & " Commit Message Failed Due To : ", ex.Message)
                                    Dim ClsLog As New ClsLogs
                                    ClsLog._BackOffice = ""
                                    ClsLog._PosCode = Whs
                                    ClsLog._FunctionN = "InsertWhsAdj"
                                    ClsLog._Desc = ex.Message
                                    ClsLog._Sql = SqlS
                                    ClsLog.WriteToTable(FrmLogin.objcon.con)
                                    Try
                                        transaction.Rollback()
                                    Catch ex2 As Exception
                                        Utilities.WriteToText("InsertWhsAdj In POS: " & Whs & " Rollback Type Failed Due To : ", ex.GetType().ToString)
                                        Utilities.WriteToText("InsertWhsAdj In POS: " & Whs & " Rollback Message Failed Due To : ", ex.Message)
                                    End Try
                                Finally
                                    con.Close()
                                End Try
                            End If
                        End If
                    End If
                Next
            Catch ex As Exception
                Utilities.WriteToText("InsertWhsAdj in WHS:  " & Whs & "Failed Due To: ", ex.Message)
            End Try
        Catch ex As Exception
            Utilities.WriteToText("InsertWhsAdj in WHS:  " & Whs & "Failed Due To: ", ex.Message)
        End Try
    End Sub
    Public Shared Function ParameterValueForSQL(sp As SqlParameter) As [String]
        Dim retval As [String] = ""

        Select Case sp.SqlDbType
            Case SqlDbType.[Char], SqlDbType.NChar, SqlDbType.NText, SqlDbType.NVarChar, SqlDbType.Text, SqlDbType.Time,
             SqlDbType.VarChar, SqlDbType.Xml, SqlDbType.[Date], SqlDbType.DateTime, SqlDbType.DateTime2, SqlDbType.DateTimeOffset
                retval = "'" + sp.Value.ToString().Replace("'", "''") + "'"
                Exit Select

            Case SqlDbType.Bit
                retval = If((sp.Value.ToBooleanOrDefault(False)), "1", "0")
                Exit Select
            Case Else

                retval = sp.Value.ToString().Replace("'", "''")
                Exit Select
        End Select

        Return retval
    End Function
    Public Shared Function CommandAsSql(sc As SqlCommand) As [String]
        Dim sql As New StringBuilder()
        Dim FirstParam As [Boolean] = True
        sql.AppendLine("use " + sc.Connection.Database + ";")
        Select Case sc.CommandType
            Case CommandType.StoredProcedure
                For Each sp As SqlParameter In sc.Parameters
                    If (sp.Direction = ParameterDirection.InputOutput) OrElse (sp.Direction = ParameterDirection.Output) Then
                        sql.Append("declare " + sp.ParameterName + vbTab + sp.SqlDbType.ToString() + vbTab & "= ")


                        sql.AppendLine((If((sp.Direction = ParameterDirection.Output), "null", sp.Value())) + ";")
                    End If
                Next

                sql.AppendLine("exec [" + sc.CommandText + "]")

                For Each sp As SqlParameter In sc.Parameters
                    If sp.Direction <> ParameterDirection.ReturnValue Then
                        sql.Append(If((FirstParam), vbTab, vbTab & ", "))

                        If FirstParam Then
                            FirstParam = False
                        End If

                        If sp.Direction = ParameterDirection.Input Then
                            Dim v As New Object
                            If IsDBNull(CObj(sp.Value)) Then
                                v = "NULL"
                            ElseIf IsNothing(CObj(sp.Value)) Then
                                v = "NULL"
                            Else
                                v = sp.Value()
                            End If
                            If CStr(v) = "NULL" Then
                                sql.AppendLine(CStr(sp.ParameterName + " = " + CStr(v)))
                            Else
                                If TypeOf (CObj(v)) Is DateTime Then
                                    sql.AppendLine(CStr(sp.ParameterName + " = " + "'" + CDate(v).ToString("yyyyMMdd")) + "'")
                                Else
                                    sql.AppendLine(CStr(sp.ParameterName + " = " + "'" + CStr(v)) + "'")
                                End If
                            End If
                        Else

                            sql.AppendLine(sp.ParameterName + " = " + sp.ParameterName + " output")
                        End If
                    End If
                Next
                sql.AppendLine(";")

                For Each sp As SqlParameter In sc.Parameters
                    If (sp.Direction = ParameterDirection.InputOutput) OrElse (sp.Direction = ParameterDirection.Output) Then
                        sql.AppendLine("select '" + sp.ParameterName + "' = convert(varchar, " + sp.ParameterName + ");")
                    End If
                Next
                Exit Select
            Case CommandType.Text
                sql.AppendLine(sc.CommandText)
                Exit Select
        End Select

        Return sql.ToString()
    End Function
    Public Shared Function ExportCommandAsSql(sc As SqlCommand) As [String]
        Dim sql As New StringBuilder()
        Dim FirstParam As [Boolean] = True

        Select Case sc.CommandType
            Case CommandType.StoredProcedure
                For Each sp As SqlParameter In sc.Parameters
                    If (sp.Direction = ParameterDirection.InputOutput) OrElse (sp.Direction = ParameterDirection.Output) Then
                        sql.Append("declare " + sp.ParameterName + vbTab + sp.SqlDbType.ToString() + vbTab & "= ")


                        sql.AppendLine((If((sp.Direction = ParameterDirection.Output), "null", sp.Value())) + ";")
                    End If
                Next

                sql.AppendLine("exec [" + sc.CommandText + "]")

                For Each sp As SqlParameter In sc.Parameters
                    If sp.Direction <> ParameterDirection.ReturnValue Then
                        sql.Append(If((FirstParam), vbTab, vbTab & ", "))

                        If FirstParam Then
                            FirstParam = False
                        End If

                        If sp.Direction = ParameterDirection.Input Then
                            Dim v As New Object
                            If IsDBNull(CObj(sp.Value)) Then
                                v = "NULL"
                            ElseIf IsNothing(CObj(sp.Value)) Then
                                v = "NULL"
                            Else
                                v = sp.Value()
                            End If
                            If CStr(v) = "NULL" Then
                                sql.AppendLine(CStr(sp.ParameterName + " = " + CStr(v)))
                            Else
                                If TypeOf (CObj(v)) Is DateTime Then
                                    sql.AppendLine(CStr(sp.ParameterName + " = " + "'" + CDate(v).ToString("yyyyMMdd")) + "'")
                                Else
                                    sql.AppendLine(CStr(sp.ParameterName + " = " + "'" + CStr(v)) + "'")
                                End If
                            End If
                        Else

                            sql.AppendLine(sp.ParameterName + " = " + sp.ParameterName + " output")
                        End If
                    End If
                Next
                sql.AppendLine(";")

                For Each sp As SqlParameter In sc.Parameters
                    If (sp.Direction = ParameterDirection.InputOutput) OrElse (sp.Direction = ParameterDirection.Output) Then
                        sql.AppendLine("select '" + sp.ParameterName + "' = convert(varchar, " + sp.ParameterName + ");")
                    End If
                Next
                Exit Select
            Case CommandType.Text
                sql.AppendLine(sc.CommandText)
                Exit Select
        End Select

        Return sql.ToString()
    End Function
     'Private Sub ToolStripMenuItem4_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem4.Click
    '    Try
    '        Cursor.Current = Cursors.WaitCursor
    '        Dim ClsBrand As New ClsBrand
    '        Dim BoConxString = "Data Source ='" & FrmMainForm.BOServer & "';Initial Catalog='" & FrmMainForm.BODatabase & "';user ID='" & FrmMainForm.BOUser & "';password='" & FrmMainForm.BOPass & "'"
    '        Dim BoCnx As SqlConnection = New SqlConnection(BoConxString)
    '        Dim blnconnectionOpen1 = ConnStatus(BoCnx)
    '        If Not blnconnectionOpen1 Then ConnOpen(BoCnx)

    '        Dim DtBrands = ClsBrand.GetNewBrands(BoCnx)

    '        Dim Count As Integer = 0
    '        Dim SqlS = ""
    '        Dim con As New SqlConnection
    '        For j = 0 To DtBrands.Rows.Count - 1
    '            Dim command As SqlCommand = con.CreateCommand()
    '            command.Connection = con
    '            command.CommandText = "SpRt_InsertNewBrand"
    '            command.CommandType = CommandType.StoredProcedure
    '            command.Parameters.AddWithValue("@BrandCode", IIf(IsNothing(DtBrands.Rows(j).Item("BrandCode")) Or IsDBNull(DtBrands.Rows(j).Item("BrandCode")), DBNull.Value, DtBrands.Rows(j).Item("BrandCode")))
    '            command.Parameters.AddWithValue("@Description", IIf(IsNothing(DtBrands.Rows(j).Item("Description")) Or IsDBNull(DtBrands.Rows(j).Item("Description")), DBNull.Value, DtBrands.Rows(j).Item("Description")))
    '            command.Parameters.AddWithValue("@AltDescription", IIf(IsNothing(DtBrands.Rows(j).Item("AltDescription")) Or IsDBNull(DtBrands.Rows(j).Item("AltDescription")), DBNull.Value, DtBrands.Rows(j).Item("AltDescription")))
    '            SqlS += ExportCommandAsSql(command)
    '        Next
    '        Dim ClsType As New ClsType
    '        Dim DtTypes = ClsType.GetNewTypes(BoCnx)
    '        For j = 0 To DtTypes.Rows.Count - 1
    '            Dim command As SqlCommand = con.CreateCommand()
    '            command.Connection = con
    '            command.CommandText = "SpRt_InsertNewType"
    '            command.CommandType = CommandType.StoredProcedure
    '            command.Parameters.AddWithValue("@TypeCode", IIf(IsNothing(DtTypes.Rows(j).Item("TypeCode")) Or IsDBNull(DtTypes.Rows(j).Item("TypeCode")), DBNull.Value, DtTypes.Rows(j).Item("TypeCode")))
    '            command.Parameters.AddWithValue("@Description", IIf(IsNothing(DtTypes.Rows(j).Item("Description")) Or IsDBNull(DtTypes.Rows(j).Item("Description")), DBNull.Value, DtTypes.Rows(j).Item("Description")))
    '            command.Parameters.AddWithValue("@AltDescription", IIf(IsNothing(DtTypes.Rows(j).Item("AltDescription")) Or IsDBNull(DtTypes.Rows(j).Item("AltDescription")), DBNull.Value, DtTypes.Rows(j).Item("AltDescription")))
    '            SqlS += ExportCommandAsSql(command)
    '        Next
    '        Dim ClsCategory As New ClsCategory
    '        Dim DtCategories = ClsCategory.GetNewCategories(BoCnx)
    '        For j = 0 To DtCategories.Rows.Count - 1
    '            Dim command As SqlCommand = con.CreateCommand()
    '            command.Connection = con
    '            command.CommandText = "SpRt_InsertNewCategory"
    '            command.CommandType = CommandType.StoredProcedure
    '            command.Parameters.AddWithValue("@CategoryCode", IIf(IsNothing(DtCategories.Rows(j).Item("CategoryCode")) Or IsDBNull(DtCategories.Rows(j).Item("CategoryCode")), DBNull.Value, DtCategories.Rows(j).Item("CategoryCode")))
    '            command.Parameters.AddWithValue("@Description", IIf(IsNothing(DtCategories.Rows(j).Item("Description")) Or IsDBNull(DtCategories.Rows(j).Item("Description")), DBNull.Value, DtCategories.Rows(j).Item("Description")))
    '            command.Parameters.AddWithValue("@AltDescription", IIf(IsNothing(DtCategories.Rows(j).Item("AltDescription")) Or IsDBNull(DtCategories.Rows(j).Item("AltDescription")), DBNull.Value, DtCategories.Rows(j).Item("AltDescription")))
    '            SqlS += ExportCommandAsSql(command)
    '        Next
    '        Dim ClsItemA As New ClsItemA
    '        Dim ItemIdNew As String = ""
    '        Dim ItemIDOld As String = ""
    '        Dim DtNewItems = ClsItemA.BoInitNewPosItems(BoCnx)
    '        For j = 0 To DtNewItems.Rows.Count - 1
    '            ItemIdNew = DtNewItems.Rows(j).Item("ItemAID")
    '            If ItemIdNew <> ItemIDOld Then
    '                Dim command As SqlCommand = con.CreateCommand()
    '                command.Connection = con
    '                command.CommandText = "SpIv_BOItemAInsert"
    '                command.CommandType = CommandType.StoredProcedure
    '                command.Parameters.AddWithValue("@ItemAid", IIf(IsNothing(DtNewItems.Rows(j).Item("ItemAid")) Or IsDBNull(DtNewItems.Rows(j).Item("ItemAid")), DBNull.Value, DtNewItems.Rows(j).Item("ItemAid")))
    '                command.Parameters.AddWithValue("@ItemCode", IIf(IsNothing(DtNewItems.Rows(j).Item("ItemCode")) Or IsDBNull(DtNewItems.Rows(j).Item("ItemCode")), DBNull.Value, DtNewItems.Rows(j).Item("ItemCode")))
    '                command.Parameters.AddWithValue("@CurCode", IIf(IsNothing(DtNewItems.Rows(j).Item("CurCode")) Or IsDBNull(DtNewItems.Rows(j).Item("CurCode")), DBNull.Value, DtNewItems.Rows(j).Item("CurCode")))
    '                command.Parameters.AddWithValue("@ShDescription", IIf(IsNothing(DtNewItems.Rows(j).Item("ShDescription")) Or IsDBNull(DtNewItems.Rows(j).Item("ShDescription")), DBNull.Value, DtNewItems.Rows(j).Item("ShDescription")))
    '                command.Parameters.AddWithValue("@Description", IIf(IsNothing(DtNewItems.Rows(j).Item("Description")) Or IsDBNull(DtNewItems.Rows(j).Item("Description")), DBNull.Value, DtNewItems.Rows(j).Item("Description")))
    '                command.Parameters.AddWithValue("@AltShDescription", IIf(IsNothing(DtNewItems.Rows(j).Item("AltShDescription")) Or IsDBNull(DtNewItems.Rows(j).Item("AltShDescription")), DBNull.Value, DtNewItems.Rows(j).Item("AltShDescription")))
    '                command.Parameters.AddWithValue("@AltDescription", IIf(IsNothing(DtNewItems.Rows(j).Item("AltDescription")) Or IsDBNull(DtNewItems.Rows(j).Item("AltDescription")), DBNull.Value, DtNewItems.Rows(j).Item("AltDescription")))
    '                command.Parameters.AddWithValue("@UOMCode", IIf(IsNothing(DtNewItems.Rows(j).Item("UOMCode")) Or IsDBNull(DtNewItems.Rows(j).Item("UOMCode")), DBNull.Value, DtNewItems.Rows(j).Item("UOMCode")))
    '                command.Parameters.AddWithValue("@SupplierId", IIf(IsNothing(DtNewItems.Rows(j).Item("SupplierId")) Or IsDBNull(DtNewItems.Rows(j).Item("SupplierId")), DBNull.Value, DtNewItems.Rows(j).Item("SupplierId")))
    '                command.Parameters.AddWithValue("@CategoryCode", IIf(IsNothing(DtNewItems.Rows(j).Item("CategoryCode")) Or IsDBNull(DtNewItems.Rows(j).Item("CategoryCode")), DBNull.Value, DtNewItems.Rows(j).Item("CategoryCode")))
    '                command.Parameters.AddWithValue("@TypeCode", IIf(IsNothing(DtNewItems.Rows(j).Item("TypeCode")) Or IsDBNull(DtNewItems.Rows(j).Item("TypeCode")), DBNull.Value, DtNewItems.Rows(j).Item("TypeCode")))
    '                command.Parameters.AddWithValue("@BrandCode", IIf(IsNothing(DtNewItems.Rows(j).Item("BrandCode")) Or IsDBNull(DtNewItems.Rows(j).Item("BrandCode")), DBNull.Value, DtNewItems.Rows(j).Item("BrandCode")))
    '                command.Parameters.AddWithValue("@CustomId", IIf(IsNothing(DtNewItems.Rows(j).Item("CustomId")) Or IsDBNull(DtNewItems.Rows(j).Item("CustomId")), DBNull.Value, DtNewItems.Rows(j).Item("CustomId")))
    '                command.Parameters.AddWithValue("@VatId", IIf(IsNothing(DtNewItems.Rows(j).Item("VatId")) Or IsDBNull(DtNewItems.Rows(j).Item("VatId")), DBNull.Value, DtNewItems.Rows(j).Item("VatId")))
    '                command.Parameters.AddWithValue("@BaseUom", IIf(IsNothing(DtNewItems.Rows(j).Item("BaseUom")) Or IsDBNull(DtNewItems.Rows(j).Item("BaseUom")), DBNull.Value, DtNewItems.Rows(j).Item("BaseUom")))
    '                command.Parameters.AddWithValue("@Factor", IIf(IsNothing(DtNewItems.Rows(j).Item("Factor")) Or IsDBNull(DtNewItems.Rows(j).Item("Factor")), DBNull.Value, DtNewItems.Rows(j).Item("Factor")))
    '                command.Parameters.AddWithValue("@NbPages", IIf(IsNothing(DtNewItems.Rows(j).Item("NbPages")) Or IsDBNull(DtNewItems.Rows(j).Item("NbPages")), DBNull.Value, DtNewItems.Rows(j).Item("NbPages")))
    '                command.Parameters.AddWithValue("@AltUom", IIf(IsNothing(DtNewItems.Rows(j).Item("AltUom")) Or IsDBNull(DtNewItems.Rows(j).Item("AltUom")), DBNull.Value, DtNewItems.Rows(j).Item("AltUom")))
    '                command.Parameters.AddWithValue("@ItemAPrice", IIf(IsNothing(DtNewItems.Rows(j).Item("ItemAPrice")) Or IsDBNull(DtNewItems.Rows(j).Item("ItemAPrice")), DBNull.Value, DtNewItems.Rows(j).Item("ItemAPrice")))
    '                command.Parameters.AddWithValue("@ProfitMargin", IIf(IsNothing(DtNewItems.Rows(j).Item("ProfitMargin")) Or IsDBNull(DtNewItems.Rows(j).Item("ProfitMargin")), DBNull.Value, DtNewItems.Rows(j).Item("ProfitMargin")))
    '                command.Parameters.AddWithValue("@MinimQty", IIf(IsNothing(DtNewItems.Rows(j).Item("MinimQty")) Or IsDBNull(DtNewItems.Rows(j).Item("MinimQty")), DBNull.Value, DtNewItems.Rows(j).Item("MinimQty")))
    '                command.Parameters.AddWithValue("@Increase", IIf(IsNothing(DtNewItems.Rows(j).Item("Increase")) Or IsDBNull(DtNewItems.Rows(j).Item("Increase")), DBNull.Value, DtNewItems.Rows(j).Item("Increase")))
    '                command.Parameters.AddWithValue("@AddFinal", IIf(IsNothing(DtNewItems.Rows(j).Item("AddFinal")) Or IsDBNull(DtNewItems.Rows(j).Item("AddFinal")), DBNull.Value, DtNewItems.Rows(j).Item("AddFinal")))
    '                command.Parameters.AddWithValue("@IncluedInBudget", IIf(IsNothing(DtNewItems.Rows(j).Item("IncluedInBudget")) Or IsDBNull(DtNewItems.Rows(j).Item("IncluedInBudget")), DBNull.Value, DtNewItems.Rows(j).Item("IncluedInBudget")))
    '                command.Parameters.AddWithValue("@Blocked", IIf(IsNothing(DtNewItems.Rows(j).Item("Blocked")) Or IsDBNull(DtNewItems.Rows(j).Item("Blocked")), DBNull.Value, DtNewItems.Rows(j).Item("Blocked")))
    '                command.Parameters.AddWithValue("@Idle", IIf(IsNothing(DtNewItems.Rows(j).Item("Idle")) Or IsDBNull(DtNewItems.Rows(j).Item("Idle")), DBNull.Value, DtNewItems.Rows(j).Item("Idle")))
    '                command.Parameters.AddWithValue("@Consignment", IIf(IsNothing(DtNewItems.Rows(j).Item("Consignment")) Or IsDBNull(DtNewItems.Rows(j).Item("Consignment")), DBNull.Value, DtNewItems.Rows(j).Item("Consignment")))
    '                command.Parameters.AddWithValue("@Discountable", IIf(IsNothing(DtNewItems.Rows(j).Item("Discountable")) Or IsDBNull(DtNewItems.Rows(j).Item("Discountable")), DBNull.Value, DtNewItems.Rows(j).Item("Discountable")))
    '                command.Parameters.AddWithValue("@KitItem", IIf(IsNothing(DtNewItems.Rows(j).Item("KitItem")) Or IsDBNull(DtNewItems.Rows(j).Item("KitItem")), DBNull.Value, DtNewItems.Rows(j).Item("KitItem")))
    '                command.Parameters.AddWithValue("@ServiceItem", IIf(IsNothing(DtNewItems.Rows(j).Item("ServiceItem")) Or IsDBNull(DtNewItems.Rows(j).Item("ServiceItem")), DBNull.Value, DtNewItems.Rows(j).Item("ServiceItem")))

    '                command.Parameters.AddWithValue("@UseLot", IIf(IsNothing(DtNewItems.Rows(j).Item("UseLot")) Or IsDBNull(DtNewItems.Rows(j).Item("UseLot")), DBNull.Value, DtNewItems.Rows(j).Item("UseLot")))
    '                command.Parameters.AddWithValue("@UseExpiry", IIf(IsNothing(DtNewItems.Rows(j).Item("UseExpiry")) Or IsDBNull(DtNewItems.Rows(j).Item("UseExpiry")), DBNull.Value, DtNewItems.Rows(j).Item("UseExpiry")))
    '                command.Parameters.AddWithValue("@UseSerial", IIf(IsNothing(DtNewItems.Rows(j).Item("UseSerial")) Or IsDBNull(DtNewItems.Rows(j).Item("UseSerial")), DBNull.Value, DtNewItems.Rows(j).Item("UseSerial")))
    '                command.Parameters.AddWithValue("@ProtectReservedQty", IIf(IsNothing(DtNewItems.Rows(j).Item("ProtectReservedQty")) Or IsDBNull(DtNewItems.Rows(j).Item("ProtectReservedQty")), DBNull.Value, DtNewItems.Rows(j).Item("ProtectReservedQty")))
    '                command.Parameters.AddWithValue("@Iuser", IIf(IsNothing(DtNewItems.Rows(j).Item("Iuser")) Or IsDBNull(DtNewItems.Rows(j).Item("Iuser")), DBNull.Value, DtNewItems.Rows(j).Item("Iuser")))
    '                command.Parameters.AddWithValue("@IDate", IIf(IsNothing(DtNewItems.Rows(j).Item("IDate")) Or IsDBNull(DtNewItems.Rows(j).Item("IDate")), DBNull.Value, DtNewItems.Rows(j).Item("IDate")))
    '                command.Parameters.AddWithValue("@UUser", IIf(IsNothing(DtNewItems.Rows(j).Item("UUser")) Or IsDBNull(DtNewItems.Rows(j).Item("UUser")), DBNull.Value, DtNewItems.Rows(j).Item("UUser")))
    '                command.Parameters.AddWithValue("@UDate", IIf(IsNothing(DtNewItems.Rows(j).Item("UDate")) Or IsDBNull(DtNewItems.Rows(j).Item("UDate")), DBNull.Value, DtNewItems.Rows(j).Item("UDate")))
    '                command.Parameters.AddWithValue("@PostQty", IIf(IsNothing(DtNewItems.Rows(j).Item("PostQty")) Or IsDBNull(DtNewItems.Rows(j).Item("PostQty")), DBNull.Value, DtNewItems.Rows(j).Item("PostQty")))
    '                command.Parameters.AddWithValue("@AvgCost", IIf(IsNothing(DtNewItems.Rows(j).Item("AvgCost")) Or IsDBNull(DtNewItems.Rows(j).Item("AvgCost")), DBNull.Value, DtNewItems.Rows(j).Item("AvgCost")))
    '                command.Parameters.AddWithValue("@Fl_AvgCost", IIf(IsNothing(DtNewItems.Rows(j).Item("Fl_AvgCost")) Or IsDBNull(DtNewItems.Rows(j).Item("Fl_AvgCost")), DBNull.Value, DtNewItems.Rows(j).Item("Fl_AvgCost")))
    '                command.Parameters.AddWithValue("@Sl_AvgCost", IIf(IsNothing(DtNewItems.Rows(j).Item("Sl_AvgCost")) Or IsDBNull(DtNewItems.Rows(j).Item("Sl_AvgCost")), DBNull.Value, DtNewItems.Rows(j).Item("Fl_AvgCost")))
    '                command.Parameters.AddWithValue("@LastPurch", IIf(IsNothing(DtNewItems.Rows(j).Item("LastPurch")) Or IsDBNull(DtNewItems.Rows(j).Item("LastPurch")), DBNull.Value, DtNewItems.Rows(j).Item("LastPurch")))
    '                command.Parameters.AddWithValue("@Fl_LastPurch", IIf(IsNothing(DtNewItems.Rows(j).Item("Fl_LastPurch")) Or IsDBNull(DtNewItems.Rows(j).Item("Fl_LastPurch")), DBNull.Value, DtNewItems.Rows(j).Item("Fl_LastPurch")))
    '                command.Parameters.AddWithValue("@Sl_LastPurch", IIf(IsNothing(DtNewItems.Rows(j).Item("Sl_LastPurch")) Or IsDBNull(DtNewItems.Rows(j).Item("Sl_LastPurch")), DBNull.Value, DtNewItems.Rows(j).Item("Sl_LastPurch")))
    '                command.Parameters.AddWithValue("@LastUnitCost", IIf(IsNothing(DtNewItems.Rows(j).Item("LastUnitCost")) Or IsDBNull(DtNewItems.Rows(j).Item("LastUnitCost")), DBNull.Value, DtNewItems.Rows(j).Item("LastUnitCost")))
    '                command.Parameters.AddWithValue("@Fl_LastUnitCost", IIf(IsNothing(DtNewItems.Rows(j).Item("Fl_LastUnitCost")) Or IsDBNull(DtNewItems.Rows(j).Item("Fl_LastUnitCost")), DBNull.Value, DtNewItems.Rows(j).Item("Fl_LastUnitCost")))
    '                command.Parameters.AddWithValue("@Sl_LastUnitCost", IIf(IsNothing(DtNewItems.Rows(j).Item("Sl_LastUnitCost")) Or IsDBNull(DtNewItems.Rows(j).Item("Sl_LastUnitCost")), DBNull.Value, DtNewItems.Rows(j).Item("Sl_LastUnitCost")))
    '                command.Parameters.AddWithValue("@AllowSell", IIf(IsNothing(DtNewItems.Rows(j).Item("AllowSell")) Or IsDBNull(DtNewItems.Rows(j).Item("AllowSell")), DBNull.Value, DtNewItems.Rows(j).Item("AllowSell")))
    '                command.Parameters.AddWithValue("@CostType", IIf(IsNothing(DtNewItems.Rows(j).Item("CostType")) Or IsDBNull(DtNewItems.Rows(j).Item("CostType")), DBNull.Value, DtNewItems.Rows(j).Item("CostType")))
    '                command.Parameters.AddWithValue("@StartYear", IIf(IsNothing(DtNewItems.Rows(j).Item("StartYear")) Or IsDBNull(DtNewItems.Rows(j).Item("StartYear")), DBNull.Value, DtNewItems.Rows(j).Item("StartYear")))
    '                SqlS += ExportCommandAsSql(command)
    '                ItemIDOld = DtNewItems.Rows(j).Item("ItemAid")
    '            End If
    '            Dim command1 As SqlCommand = con.CreateCommand()
    '            ' Start a local transaction
    '            command1.Connection = con
    '            command1.CommandText = "SpIv_BOItemBInsert"
    '            command1.CommandType = CommandType.StoredProcedure
    '            command1.Parameters.AddWithValue("@ItemBid", IIf(IsNothing(DtNewItems.Rows(j).Item("ItemBid")) Or IsDBNull(DtNewItems.Rows(j).Item("ItemBid")), DBNull.Value, DtNewItems.Rows(j).Item("ItemBid")))
    '            command1.Parameters.AddWithValue("@ItemAId", IIf(IsNothing(DtNewItems.Rows(j).Item("ItemAId")) Or IsDBNull(DtNewItems.Rows(j).Item("ItemAId")), DBNull.Value, DtNewItems.Rows(j).Item("ItemAId")))
    '            command1.Parameters.AddWithValue("@BarCode", IIf(IsNothing(DtNewItems.Rows(j).Item("BarCode")) Or IsDBNull(DtNewItems.Rows(j).Item("BarCode")), DBNull.Value, DtNewItems.Rows(j).Item("BarCode")))
    '            command1.Parameters.AddWithValue("@SizeCode", IIf(IsNothing(DtNewItems.Rows(j).Item("SizeCode")) Or IsDBNull(DtNewItems.Rows(j).Item("SizeCode")), DBNull.Value, DtNewItems.Rows(j).Item("SizeCode")))
    '            command1.Parameters.AddWithValue("@ColorCode", IIf(IsNothing(DtNewItems.Rows(j).Item("ColorCode")) Or IsDBNull(DtNewItems.Rows(j).Item("ColorCode")), DBNull.Value, DtNewItems.Rows(j).Item("ColorCode")))
    '            command1.Parameters.AddWithValue("@UOMCode", IIf(IsNothing(DtNewItems.Rows(j).Item("UOMCode")) Or IsDBNull(DtNewItems.Rows(j).Item("UOMCode")), DBNull.Value, DtNewItems.Rows(j).Item("UOMCode")))
    '            command1.Parameters.AddWithValue("@Factor", IIf(IsNothing(DtNewItems.Rows(j).Item("Factor")) Or IsDBNull(DtNewItems.Rows(j).Item("Factor")), DBNull.Value, DtNewItems.Rows(j).Item("Factor")))
    '            command1.Parameters.AddWithValue("@ItemPrice", IIf(IsNothing(DtNewItems.Rows(j).Item("ItemPrice")) Or IsDBNull(DtNewItems.Rows(j).Item("ItemPrice")), DBNull.Value, DtNewItems.Rows(j).Item("ItemPrice")))
    '            command1.Parameters.AddWithValue("@ProfitMargin", IIf(IsNothing(DtNewItems.Rows(j).Item("ProfitMargin")) Or IsDBNull(DtNewItems.Rows(j).Item("ProfitMargin")), DBNull.Value, DtNewItems.Rows(j).Item("ProfitMargin")))
    '            command1.Parameters.AddWithValue("@UUser", IIf(IsNothing(DtNewItems.Rows(j).Item("UUser")) Or IsDBNull(DtNewItems.Rows(j).Item("UUser")), DBNull.Value, DtNewItems.Rows(j).Item("UUser")))
    '            command1.Parameters.AddWithValue("@Udate", IIf(IsNothing(DtNewItems.Rows(j).Item("Udate")) Or IsDBNull(DtNewItems.Rows(j).Item("Udate")), DBNull.Value, DtNewItems.Rows(j).Item("Udate")))
    '            SqlS += ExportCommandAsSql(command1)
    '        Next
    '        Dim ClsPriceList As New ClsPriceList
    '        Dim DtPriceList = ClsPriceList.GetChangedPriceList(PriceList, BoCnx)
    '        For j = 0 To DtPriceList.Rows.Count - 1
    '            Dim command As SqlCommand = con.CreateCommand()
    '            command.Connection = con
    '            command.CommandText = "SpIv_BoInsertToPriceList"
    '            command.CommandType = CommandType.StoredProcedure
    '            command.Parameters.AddWithValue("@ListCode", IIf(IsNothing(DtPriceList.Rows(j).Item("ListCode")) Or IsDBNull(DtPriceList.Rows(j).Item("ListCode")), DBNull.Value, DtPriceList.Rows(j).Item("ListCode")))
    '            command.Parameters.AddWithValue("@ItemAid", IIf(IsNothing(DtPriceList.Rows(j).Item("ItemAid")) Or IsDBNull(DtPriceList.Rows(j).Item("ItemAid")), DBNull.Value, DtPriceList.Rows(j).Item("ItemAid")))
    '            command.Parameters.AddWithValue("@ItemBid", IIf(IsNothing(DtPriceList.Rows(j).Item("ItemBid")) Or IsDBNull(DtPriceList.Rows(j).Item("ItemBid")), DBNull.Value, DtPriceList.Rows(j).Item("ItemBid")))
    '            command.Parameters.AddWithValue("@DiscPct", IIf(IsNothing(DtPriceList.Rows(j).Item("DiscPct")) Or IsDBNull(DtPriceList.Rows(j).Item("DiscPct")), DBNull.Value, DtPriceList.Rows(j).Item("DiscPct")))
    '            command.Parameters.AddWithValue("@Price", IIf(IsNothing(DtPriceList.Rows(j).Item("Price")) Or IsDBNull(DtPriceList.Rows(j).Item("Price")), DBNull.Value, DtPriceList.Rows(j).Item("Price")))
    '            command.Parameters.AddWithValue("@PromoPrice", IIf(IsNothing(DtPriceList.Rows(j).Item("PromoPrice")) Or IsDBNull(DtPriceList.Rows(j).Item("PromoPrice")), DBNull.Value, DtPriceList.Rows(j).Item("PromoPrice")))
    '            command.Parameters.AddWithValue("@Iuser", IIf(IsNothing(DtPriceList.Rows(j).Item("Iuser")) Or IsDBNull(DtPriceList.Rows(j).Item("Iuser")), DBNull.Value, DtPriceList.Rows(j).Item("Iuser")))
    '            command.Parameters.AddWithValue("@Uuser", IIf(IsNothing(DtPriceList.Rows(j).Item("Uuser")) Or IsDBNull(DtPriceList.Rows(j).Item("Uuser")), DBNull.Value, DtPriceList.Rows(j).Item("Uuser")))
    '            command.Parameters.AddWithValue("@LastTonPrice", IIf(IsNothing(DtPriceList.Rows(j).Item("LastTonPrice")) Or IsDBNull(DtPriceList.Rows(j).Item("LastTonPrice")), DBNull.Value, DtPriceList.Rows(j).Item("LastTonPrice")))
    '            command.Parameters.AddWithValue("@LastMargin", IIf(IsNothing(DtPriceList.Rows(j).Item("LastMargin")) Or IsDBNull(DtPriceList.Rows(j).Item("LastMargin")), DBNull.Value, DtPriceList.Rows(j).Item("LastMargin")))
    '            command.Parameters.AddWithValue("@PriceBuiltOn", IIf(IsNothing(DtPriceList.Rows(j).Item("PriceBuiltOn")) Or IsDBNull(DtPriceList.Rows(j).Item("PriceBuiltOn")), DBNull.Value, DtPriceList.Rows(j).Item("PriceBuiltOn")))
    '            command.Parameters.AddWithValue("@changed", IIf(IsNothing(DtPriceList.Rows(j).Item("Changed")) Or IsDBNull(DtPriceList.Rows(j).Item("Changed")), 0, DtPriceList.Rows(j).Item("Changed")))
    '            SqlS += ExportCommandAsSql(command)
    '        Next
    '        WriteToText(SqlS)
    '        MessageBox.Show("Export Done", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    '    Cursor.Current = Cursors.Default
    'End Sub
    Private Sub PriceListWorker_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles PriceListWorker.DoWork
        Try
            If Sync = 0 Then
                Exit Sub
            End If
            GetChangedPriceList1()
        Catch ex As Exception
            Utilities.WriteToText("Sending Operations From BgWorker POS Control Failed Due To: ", ex.Message)
        End Try
    End Sub



#Region "Navigation"
    Private Sub DelDiffNavItem_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles DelDiffNavItem.LinkClicked
        Try
            For Each f As Form In Application.OpenForms
                If TypeOf f Is FrmDelDiff Then
                    f.Activate()
                    Return
                End If
            Next
            FrmDelDiff.MdiParent = Me
            FrmDelDiff.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ItemQtyControl_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles ItemQtyControl.LinkClicked
        Try
            For Each f As Form In Application.OpenForms
                If TypeOf f Is FrmItemControl Then
                    f.Activate()
                    Return
                End If
            Next
            FrmItemControl.MdiParent = Me
            FrmItemControl.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub WhsAdjustments_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles WhsAdjustments.LinkClicked
        Try
            For Each f As Form In Application.OpenForms
                If TypeOf f Is FrmAdjustment Then
                    f.Activate()
                    Return
                End If
            Next
            FrmAdjustment.MdiParent = Me
            FrmAdjustment.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub LogsBarItem_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles LogsBarItem.LinkClicked
        Try
            For Each f As Form In Application.OpenForms
                If TypeOf f Is FrmLogs Then
                    f.Activate()
                    Return
                End If
            Next
            FrmLogs.MdiParent = Me
            FrmLogs.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub POSBarItem_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles POSBarItem.LinkClicked
        Try
            For Each f As Form In Application.OpenForms
                If TypeOf f Is FrmPOS Then
                    f.Activate()
                    Return
                End If
            Next
            FrmPOS.MdiParent = Me
            FrmPOS.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub IntraData_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles IntraData.LinkClicked
        Try
            For Each f As Form In Application.OpenForms
                If TypeOf f Is FrmIntraData Then
                    f.Activate()
                    Return
                End If
            Next
            FrmIntraData.MdiParent = Me
            FrmIntraData.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Receipts_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles Receipts.LinkClicked
        Try
            For Each f As Form In Application.OpenForms
                If TypeOf f Is FrmReceipts Then
                    f.Activate()
                    Return
                End If
            Next
            FrmReceipts.MdiParent = Me
            FrmReceipts.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DirectQueryToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DirectQueryToolStripMenuItem.Click
        Try
            For Each f As Form In Application.OpenForms
                If TypeOf f Is frmDirectQuery Then
                    f.Activate()
                    Return
                End If
            Next
            frmDirectQuery.MdiParent = Me
            frmDirectQuery.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DirectUpdateToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DirectUpdateToolStripMenuItem.Click
        Try
            For Each f As Form In Application.OpenForms
                If TypeOf f Is FrmDirectUpdate Then
                    f.Activate()
                    Return
                End If
            Next
            FrmDirectUpdate.MdiParent = Me
            FrmDirectUpdate.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub BackUpToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BackUpToolStripMenuItem.Click
        Try
            For Each f As Form In Application.OpenForms
                If TypeOf f Is FrmBackup Then
                    f.Activate()
                    Return
                End If
            Next
            FrmBackup.MdiParent = Me
            FrmBackup.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub BuildToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BuildToolStripMenuItem.Click
        Try
            For Each f As Form In Application.OpenForms
                If TypeOf f Is FrmBuild Then
                    f.Activate()
                    Return
                End If
            Next
            FrmBuild.MdiParent = Me
            FrmBuild.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CalculatorToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CalculatorToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("calc")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub LogsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LogsToolStripMenuItem.Click
        Try
            For Each f As Form In Application.OpenForms
                If TypeOf f Is FrmLogs Then
                    f.Activate()
                    Return
                End If
            Next
            FrmLogs.MdiParent = Me
            FrmLogs.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub AboutBusinessPackToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AboutBusinessPackToolStripMenuItem.Click
        AboutUS.ShowDialog()
    End Sub
    Private Sub DeliveryDiscrepancyToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DeliveryDiscrepancyToolStripMenuItem.Click
        Try
            For Each f As Form In Application.OpenForms
                If TypeOf f Is FrmRepDeliveryDiscrepancy Then
                    f.Activate()
                    Return
                End If
            Next
            FrmRepDeliveryDiscrepancy.MdiParent = Me
            FrmRepDeliveryDiscrepancy.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ItemControlToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ItemControlToolStripMenuItem.Click
        Try
            For Each f As Form In Application.OpenForms
                If TypeOf f Is FrmRepItemControl Then
                    f.Activate()
                    Return
                End If
            Next
            FrmRepItemControl.MdiParent = Me
            FrmRepItemControl.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub TileToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TileToolStripMenuItem.Click
        If Me.MdiChildren.Length = 0 Then
            Exit Sub
        End If
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub
    Private Sub TileVerticallyToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TileVerticallyToolStripMenuItem.Click
        If Me.MdiChildren.Length = 0 Then
            Exit Sub
        End If
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub
    Private Sub ArrangeIconeToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ArrangeIconeToolStripMenuItem.Click
        If Me.MdiChildren.Length = 0 Then
            Exit Sub
        End If
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub
    Private Sub CascadeToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CascadeToolStripMenuItem.Click
        If Me.MdiChildren.Length = 0 Then
            Exit Sub
        End If
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub
    Private Sub btnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirst.Click
        If Me.MdiChildren.Length = 0 Then
            Exit Sub
        End If
        Try
            DirectCast(Me.ActiveMdiChild, Procedures).FirstRecord()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnprevious.Click
        If Me.MdiChildren.Length = 0 Then
            Exit Sub
        End If
        Try
            DirectCast(Me.ActiveMdiChild, Procedures).PreviousRecord()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnext.Click
        If Me.MdiChildren.Length = 0 Then
            Exit Sub
        End If
        Try
            DirectCast(Me.ActiveMdiChild, Procedures).nextRecord()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLast.Click
        If Me.MdiChildren.Length = 0 Then
            Exit Sub
        End If
        Try
            DirectCast(Me.ActiveMdiChild, Procedures).lastRecord()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DeleteToolStrip_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles DeleteToolStrip.ItemClick
        If Me.MdiChildren.Length = 0 Then
            Exit Sub
        End If
        Try
            DirectCast(Me.ActiveMdiChild, Procedures).DeleteRecord()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub NewToolStrip_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles NewToolStrip.ItemClick
        If Me.MdiChildren.Length = 0 Then
            Exit Sub
        End If
        Try
            If DirectCast(Me.ActiveMdiChild, Procedures).NewRecord() = False Then
                Exit Sub
            End If
            DirectCast(Me.ActiveMdiChild, Procedures).FillDefault()
            DirectCast(Me.ActiveMdiChild, Procedures).MenuLockUnlock(True, True)
            DirectCast(Me.ActiveMdiChild, Procedures).LockUnlockMe()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub EditToolStrip_ItemClick_1(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles EditToolStrip.ItemClick
        If Me.MdiChildren.Length = 0 Then
            Exit Sub
        End If
        Try
            If DirectCast(Me.ActiveMdiChild, Procedures).EditRecord() = False Then
                Exit Sub
            End If
            DirectCast(Me.ActiveMdiChild, Procedures).MenuLockUnlock(True, True)
            DirectCast(Me.ActiveMdiChild, Procedures).LockUnlockMe()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub UndoToolStrip_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles UndoToolStrip.ItemClick
        If Me.MdiChildren.Length = 0 Then
            Exit Sub
        End If
        Try
            If DirectCast(Me.ActiveMdiChild, Procedures).cancel() = False Then
                Exit Sub
            End If
            DirectCast(Me.ActiveMdiChild, Procedures).MenuLockUnlock(False, False)
            DirectCast(Me.ActiveMdiChild, Procedures).LockUnlockMe()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SaveToolStrip_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles SaveToolStrip.ItemClick
        If Me.MdiChildren.Length = 0 Then
            Exit Sub
        End If
        Try
            If DirectCast(Me.ActiveMdiChild, Procedures).Save() = False Then
                Exit Sub
            End If
            DirectCast(Me.ActiveMdiChild, Procedures).MenuLockUnlock(False, False)
            DirectCast(Me.ActiveMdiChild, Procedures).LockUnlockMe()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SearchToolStrip_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles SearchToolStrip.ItemClick
        If Me.MdiChildren.Length = 0 Then
            Exit Sub
        End If
        Try
            DirectCast(Me.ActiveMdiChild, Procedures).Search()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub RefreshToolStrip_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles RefreshToolStrip.ItemClick
        If Me.MdiChildren.Length = 0 Then
            Exit Sub
        End If
        Try
            DirectCast(Me.ActiveMdiChild, Procedures).Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CloseToolStrip_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles CloseToolStrip.ItemClick
        If Me.MdiChildren.Length = 0 Then
            Exit Sub
        End If
        Try
            DirectCast(Me.ActiveMdiChild, Procedures).close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub PrintToolStrip_ItemClick_1(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles PrintToolStrip.ItemClick
        If Me.MdiChildren.Length = 0 Then
            Exit Sub
        End If
        Try
            DirectCast(Me.ActiveMdiChild, Procedures).print()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub FindToolstrip_ItemClick_1(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles FindToolstrip.ItemClick
        If Me.MdiChildren.Length = 0 Then
            Exit Sub
        End If
        Try
            DirectCast(Me.ActiveMdiChild, Procedures).find()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub FirstToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FirstToolStripMenuItem.Click
        If Me.MdiChildren.Length = 0 Then
            Exit Sub
        End If
        Try
            DirectCast(Me.ActiveMdiChild, Procedures).FirstRecord()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub PreviousToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreviousToolStripMenuItem.Click
        If Me.MdiChildren.Length = 0 Then
            Exit Sub
        End If
        Try
            DirectCast(Me.ActiveMdiChild, Procedures).PreviousRecord()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub NextToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NextToolStripMenuItem.Click
        If Me.MdiChildren.Length = 0 Then
            Exit Sub
        End If
        Try
            DirectCast(Me.ActiveMdiChild, Procedures).nextRecord()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub LastToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LastToolStripMenuItem.Click
        If Me.MdiChildren.Length = 0 Then
            Exit Sub
        End If
        Try
            DirectCast(Me.ActiveMdiChild, Procedures).lastRecord()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub NewToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        If Me.MdiChildren.Length = 0 Then
            Exit Sub
        End If
        Try
            If DirectCast(Me.ActiveMdiChild, Procedures).NewRecord() = False Then
                Exit Sub
            End If
            DirectCast(Me.ActiveMdiChild, Procedures).FillDefault()
            DirectCast(Me.ActiveMdiChild, Procedures).MenuLockUnlock(True, True)
            DirectCast(Me.ActiveMdiChild, Procedures).LockUnlockMe()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub EditToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        If Me.MdiChildren.Length = 0 Then
            Exit Sub
        End If
        Try
            If DirectCast(Me.ActiveMdiChild, Procedures).EditRecord() = False Then
                Exit Sub
            End If
            DirectCast(Me.ActiveMdiChild, Procedures).MenuLockUnlock(True, True)
            DirectCast(Me.ActiveMdiChild, Procedures).LockUnlockMe()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SaveToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        If Me.MdiChildren.Length = 0 Then
            Exit Sub
        End If
        Try
            If DirectCast(Me.ActiveMdiChild, Procedures).Save() = False Then
                Exit Sub
            End If
            DirectCast(Me.ActiveMdiChild, Procedures).MenuLockUnlock(False, False)
            DirectCast(Me.ActiveMdiChild, Procedures).LockUnlockMe()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub UndoToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UndoToolStripMenuItem.Click
        If Me.MdiChildren.Length = 0 Then
            Exit Sub
        End If
        Try
            If DirectCast(Me.ActiveMdiChild, Procedures).cancel() = False Then
                Exit Sub
            End If
            DirectCast(Me.ActiveMdiChild, Procedures).MenuLockUnlock(False, False)
            DirectCast(Me.ActiveMdiChild, Procedures).LockUnlockMe()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DeleteToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        If Me.MdiChildren.Length = 0 Then
            Exit Sub
        End If
        Try
            DirectCast(Me.ActiveMdiChild, Procedures).DeleteRecord()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub FindToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindToolStripMenuItem.Click
        If Me.MdiChildren.Length = 0 Then
            Exit Sub
        End If
        Try
            DirectCast(Me.ActiveMdiChild, Procedures).find()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub BrowseToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BrowseToolStripMenuItem.Click
        If Me.MdiChildren.Length = 0 Then
            Exit Sub
        End If
        Try
            DirectCast(Me.ActiveMdiChild, Procedures).Search()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub RefreshToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshToolStripMenuItem.Click
        If Me.MdiChildren.Length = 0 Then
            Exit Sub
        End If
        Try
            DirectCast(Me.ActiveMdiChild, Procedures).Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub PrintToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        If Me.MdiChildren.Length = 0 Then
            Exit Sub
        End If
        Try
            DirectCast(Me.ActiveMdiChild, Procedures).print()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CloseToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        If Me.MdiChildren.Length = 0 Then
            Exit Sub
        End If
        Try
            DirectCast(Me.ActiveMdiChild, Procedures).close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub PrinterSetupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrinterSetupToolStripMenuItem.Click
        PrintDialog1.ShowDialog()
    End Sub
    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub
    Private Sub ToolStripMenuItem7_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem7.Click
        FrmWorkStationDefaults.ShowDialog()
    End Sub
    Private Sub Operations_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles Operations.LinkClicked
        Try
            For Each f As Form In Application.OpenForms
                If TypeOf f Is FrmTouchInvoice Then
                    f.Activate()
                    Return
                End If
            Next
            FrmTouchInvoice.MdiParent = Me
            FrmTouchInvoice.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region
#Region "GetParameters"
    Public Sub GetSync()
        Try
            FrmMainForm.Sync = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "Sync", "Sync").ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub GetSales()
        Try
            FrmMainForm.SalesReturn = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "SalesReturn", "SalesReturn").ToString
            FrmMainForm.SalesOrder = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "SalesOrder", "SalesOrder").ToString
            FrmMainForm.SalesInvoice = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "SalesInvoice", "SalesInvoice").ToString
            FrmMainForm.WhsAdjustment = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "WhsAdjustment", "WhsAdjustment").ToString
            FrmMainForm.Opening = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "Opening", "Opening").ToString
            FrmMainForm.PurchaseID = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "PurchaseID", "PurchaseID").ToString
            FrmMainForm.PostDatedCode = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "PostDatedCode", "PostDatedCode").ToString
            FrmMainForm.TransferWhs = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "TransferWhs", "TransferWhs").ToString
            FrmMainForm.TransferToWhs = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "TransfertoWhs", "TransfertoWhs").ToString
            FrmMainForm.TransferFromWHs = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "TransferFromWHs", "TransferFromWHs").ToString
            FrmMainForm.SupplierID = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "SupplierID", "SupplierID").ToString
            FrmMainForm.TransferFromdb = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "TransferFromdb", "TransferFromdb").ToString
            FrmMainForm.Transfertodb = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "Transfertodb", "Transfertodb").ToString

            FrmMainForm.SalesFromDb = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "SalesFromDB", "SalesFromDB").ToString
            FrmMainForm.PurchaseInDb = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "PurchaseInDb", "PurchaseInDb").ToString
            FrmMainForm.SalesIndB = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "SalesIndb", "SalesIndb").ToString
            FrmMainForm.PurchaseWhs = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "PurchaseWhs", "PurchaseWhs").ToString
            FrmMainForm.PurchasePriceList = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "PurchasePricelist", "PurchasePricelist").ToString
            FrmMainForm.SalesWhs = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "SalesWhs", "SalesWhs").ToString
            FrmMainForm.SalesCustomer = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "SalesCustomer", "SalesCustomer").ToString
            FrmMainForm.TabletPos = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "TabletPos", "TabletPos").ToString

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub GetCurCode()
        Try
            FrmMainForm.CurCode = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "CurCode", "CurCode").ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub GetBOConf()
        Try
            FrmMainForm.BOServer = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "BOServer", "BOServer").ToString
            FrmMainForm.BODatabase = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "BODatabase", "BODatabase").ToString
            FrmMainForm.BOUser = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "BOUser", "BOUser").ToString
            FrmMainForm.BOPass = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "BOPass", "BOPass").ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub GetDeliveryOrder()
        Try
            FrmMainForm.DeliveryOrder = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "DeliveryOrder", "DeliveryOrder").ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub GetPriceList()
        Try
            FrmMainForm.PriceList = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "PriceList", "PriceList").ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub GetAccCode()
        Try
            FrmMainForm.AccCode = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "AccCode", "AccCode").ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub GetSalesManID()
        Try
            FrmMainForm.salesmanid = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "SalesManID", "SalesManID").ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub GetDefaultCustomer()
        Try
            FrmMainForm.DefaultCustomer = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "DefaultCustomer", "DefaultCustomer").ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub GetParameters()
        Try
            Dim sqlcomm As New SqlCommand("Sp_getgeneralparam", FrmLogin.objcon.con)
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@cmp", 1)
            sqlcomm.Parameters.AddWithValue("@type", 1)
            Dim blnconnectionOpen = ConnStatus(FrmLogin.objcon.con)
            If Not blnconnectionOpen Then ConnOpen(FrmLogin.objcon.con)
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(sqlcomm)
            da.Fill(ds, "Parameters")
            QtyDecimals = ds.Tables("Parameters").Rows(0).Item("QtyDecimals")
            UPDecimals = ds.Tables("Parameters").Rows(0).Item("UPDecimals")
            UseColor = ds.Tables("Parameters").Rows(0).Item("UseColor")
            UseSize = ds.Tables("Parameters").Rows(0).Item("UseSize")
            ReportPath = ds.Tables("Parameters").Rows(0).Item("ReportPath")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region
End Class