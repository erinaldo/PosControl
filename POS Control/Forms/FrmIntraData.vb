Imports System.Data.SqlClient
Imports ConnectionSQL
Imports System.Text

Public Class FrmIntraData
    Implements Procedures
    Dim CurCode As String
    Private Sub FrmIntraData_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        MenuLockUnlock(False, False)
    End Sub
    Private Sub FrmIntraData_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Intra Data <" & My.Application.Info.Version.ToString & ">"
        lblFrom.Text = "From: " & FrmMainForm.TransferFromdb
        CBWhs.Text = "Whs Code = " & FrmMainForm.PurchaseWhs
        lblto.Text = "To: " & FrmMainForm.Transfertodb
        DtpCriteriaFrom.EditValue = Today.Date
        dtpCriteriaTill.EditValue = Today.Date
        dtptransferfrom.EditValue = Today.Date
        dtptransfertill.EditValue = Today.Date
    End Sub
    Private Sub btnSendTransfers_Click(sender As System.Object, e As System.EventArgs) Handles btnSendTransfers.Click
        Try
            If BackgroundWorker1.IsBusy = True Or BackgroundWorker2.IsBusy = True Then
                Exit Sub
            End If
            If MessageBox.Show("Are you sure?", "BusinessPack", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
            ProgressBarControl1.EditValue = 0
            ProgressBarControl1.Visible = True
            BackgroundWorker1.RunWorkerAsync()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Shared Function ParameterValueForSQL(sp As SqlParameter) As [String]
        Dim retval As [String] = ""

        Select Case sp.SqlDbType
            Case SqlDbType.[Char], SqlDbType.NChar, SqlDbType.NText, SqlDbType.NVarChar, SqlDbType.Text, SqlDbType.Time, _
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
    Private Sub btnGenerate_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerate.Click
        If BackgroundWorker1.IsBusy = True Or BackgroundWorker2.IsBusy = True Then
            Exit Sub
        End If
        If MessageBox.Show("Are you sure?", "BusinessPack", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
        ProgressBarControl1.EditValue = 0
        ProgressBarControl1.Visible = True
        BackgroundWorker2.RunWorkerAsync()
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
    Public Sub GetPriceList()
        Try
            Dim SalesFromDbCnxString = "Data Source ='" & FrmMainForm.BOServer & "';Initial Catalog='" & FrmMainForm.SalesFromDb & "';user ID='" & FrmMainForm.BOUser & "';password='" & FrmMainForm.BOPass & "'; Connection TimeOut = 0"
            Dim SalesFromDbCnx As SqlConnection = New SqlConnection(SalesFromDbCnxString)
            Dim SqlCom As New SqlCommand("Delete from IvPriceListB1es where listcode='" & FrmMainForm.PurchasePriceList & "'", SalesFromDbCnx)
            If SalesFromDbCnx.State = ConnectionState.Closed Then
                SalesFromDbCnx.Open()
            End If
            SqlCom.ExecuteNonQuery()


            Dim clsPriceList As New ClsPriceList
            Dim BoConxString = "Data Source ='" & FrmMainForm.BOServer & "';Initial Catalog='" & FrmMainForm.SalesIndB & "';user ID='" & FrmMainForm.BOUser & "';password='" & FrmMainForm.BOPass & "'; Connection TimeOut = 0"
            Dim BoCnx As SqlConnection = New SqlConnection(BoConxString)
            Dim blnconnectionOpen1 = ConnStatus(BoCnx)
            If Not blnconnectionOpen1 Then ConnOpen(BoCnx)
            Dim Sqlstring = " select ListCode,ItemAid,ItemBid,DiscPct,Price, PromoPrice from IvPriceListB1ES where ListCode='" & FrmMainForm.PurchasePriceList & "'"
            SqlCom = New SqlCommand(Sqlstring, BoCnx)
            Dim da As New SqlDataAdapter(SqlCom)
            Dim DtPriceList As New DataTable
            da.Fill(DtPriceList)
            If DtPriceList.Rows.Count = 0 Then
                Exit Sub
            End If
            
            Dim transaction As SqlTransaction = Nothing

            Dim transcommand As SqlCommand = SalesFromDbCnx.CreateCommand()
            transaction = SalesFromDbCnx.BeginTransaction("SampleTransaction")
            Dim bulkcopy As New SqlBulkCopy(SalesFromDbCnx, SqlBulkCopyOptions.Default, transaction)
            bulkcopy.DestinationTableName = "IvPriceListB1ES"
            transcommand.Connection = SalesFromDbCnx
            Try
                For Each i As DataColumn In DtPriceList.Columns
                    bulkcopy.ColumnMappings.Add(i.ColumnName, i.ColumnName)
                Next
                bulkcopy.WriteToServer(DtPriceList)
                transaction.Commit()
                DtPriceList.Dispose()
                DtPriceList = Nothing
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim BoConxString = "Data Source ='" & FrmMainForm.BOServer & "';Initial Catalog='" & FrmMainForm.TransferFromdb & "';user ID='" & FrmMainForm.BOUser & "';password='" & FrmMainForm.BOPass & "'"
        Dim BoCnx As SqlConnection = New SqlConnection(BoConxString)
        Dim blnconnectionOpen1 = ConnStatus(BoCnx)
        If Not blnconnectionOpen1 Then ConnOpen(BoCnx)
        Dim Operid As Integer
        Dim SqlS = ""
        Try
            Dim SqlString = "Select IvB.* From " & FrmMainForm.TransferFromdb & "..IvOperationB1Es IvB "
            SqlString = SqlString & " Join IvItemA1ES Ia on Ia.ItemAid = IvB.ItemAid "
            SqlString = SqlString & " Join IvOperation1ES IvA on Iva.OperID = IvB.OperID and Iva.InvTypeID = IvB.InvTypeID "
            SqlString = SqlString & " where Ia.SupplierID = " & FrmMainForm.SupplierID & " And IvB.InvTypeID = " & FrmMainForm.DeliveryOrder
            SqlString = SqlString & " and IvB.WhsCode = '" & FrmMainForm.TransferFromWHs & "' and IvB.LigneId < 5000"
            SqlString = SqlString & " and isnull(IvB.InfoRef2,0) <> 1"
            SqlString = SqlString & " and Iva.OperDate >= '" & dtptransferfrom.DateTime.Date.ToString("yyyyMMdd") & "' and Iva.OperDate <= '" & dtptransfertill.DateTime.Date.ToString("yyyyMMdd") & "'"
            Dim sqlCom As New SqlCommand(SqlString, BoCnx)
            sqlCom.CommandTimeout = 0
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter(sqlCom)
            BackgroundWorker1.ReportProgress(10)
            da.Fill(dt)
            If dt.Rows.Count = 0 Then
                MessageBox.Show("Nothing To Transfer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                BackgroundWorker1.ReportProgress(100)
                Exit Sub
            End If
            If dt.Rows.Count >= 4999 Then
                MessageBox.Show("Number of rows is greater than 5000, please decrease the time interval", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                BackgroundWorker1.ReportProgress(100)
                Exit Sub
            End If
            If dt.Rows.Count > 0 Then
                Dim strconnection As String = "Data Source ='" & FrmMainForm.BOServer & "';Initial Catalog='" & FrmMainForm.Transfertodb & "';user ID='" & FrmMainForm.BOUser & "';password='" & FrmMainForm.BOPass & "'"
                Dim con = New SqlConnection(strconnection)
                If con.State = ConnectionState.Closed Then
                    Try
                        con.Open()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End Try
                End If
                Dim sqlcomm As New SqlCommand("select Sequence from sacsequence where SeqCode='invtype" & FrmMainForm.DeliveryOrder & "' and seqyear=" & Today.Year & "", con)
                If IsDBNull(sqlcomm.ExecuteScalar) Or IsNothing(sqlcomm.ExecuteScalar) Then
                    Dim sqlc As New SqlCommand("insert into SacSequence (SeqCode,SeqYear,Companyid,Sequence) values ('invtype" & _
                                           FrmMainForm.DeliveryOrder & "'," & Today.Year & ",1," & Today.Year & "000000)", con)
                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If
                    sqlc.ExecuteNonQuery()
                End If
                sqlcomm = New SqlCommand("select Sequence from sacsequence where SeqCode='invtype" & FrmMainForm.DeliveryOrder & "' and seqyear=" & Today.Year & "", con)
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If
                Operid = sqlcomm.ExecuteScalar + 1
                Dim command As SqlCommand = con.CreateCommand()
                command.Connection = con

                command.CommandText = "SpIv_BODeliveryOrderAInsert"
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.AddWithValue("@OperId", Operid)
                command.Parameters.AddWithValue("@InvTypeId", FrmMainForm.DeliveryOrder)
                command.Parameters.AddWithValue("@OperDate", Today.Date)
                command.Parameters.AddWithValue("@ActivationDate", Today.Date)
                command.Parameters.AddWithValue("@ThirdId", DBNull.Value)
                command.Parameters.AddWithValue("@ThirdDesc", "")
                command.Parameters.AddWithValue("@SalesManId", DBNull.Value)
                command.Parameters.AddWithValue("@PosCode", DBNull.Value)
                command.Parameters.AddWithValue("@WhsCode", FrmMainForm.TransferWhs)
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
                SqlS += CommandAsSql(command)
                BackgroundWorker1.ReportProgress(20)
                Dim lineid = 0
                For j = 0 To dt.Rows.Count - 1
                    lineid += 1
                    Dim command1 As SqlCommand = con.CreateCommand()
                    ' Start a local transaction
                    command1.Connection = con
                    command1.CommandText = "SpIv_BODeliveryOrderBInsert"
                    command1.CommandType = CommandType.StoredProcedure
                    command1.Parameters.AddWithValue("@OperId", Operid)
                    command1.Parameters.AddWithValue("@InvTypeId", FrmMainForm.DeliveryOrder)
                    command1.Parameters.AddWithValue("@LigneId", lineid)
                    command1.Parameters.AddWithValue("@ItemBId", IIf(IsNothing(dt.Rows(j).Item("ItemBId")) Or IsDBNull(dt.Rows(j).Item("ItemBId")), DBNull.Value, dt.Rows(j).Item("ItemBId")))
                    command1.Parameters.AddWithValue("@ItemAid", IIf(IsNothing(dt.Rows(j).Item("ItemAid")) Or IsDBNull(dt.Rows(j).Item("ItemAid")), DBNull.Value, dt.Rows(j).Item("ItemAid")))
                    command1.Parameters.AddWithValue("@BarCode", IIf(IsNothing(dt.Rows(j).Item("BarCode")) Or IsDBNull(dt.Rows(j).Item("BarCode")), DBNull.Value, dt.Rows(j).Item("BarCode")))
                    command1.Parameters.AddWithValue("@ItemShDescription", IIf(IsNothing(dt.Rows(j).Item("ItemShDescription")) Or IsDBNull(dt.Rows(j).Item("ItemShDescription")), DBNull.Value, dt.Rows(j).Item("ItemShDescription")))
                    command1.Parameters.AddWithValue("@WhsCode", FrmMainForm.TransferWhs)
                    command1.Parameters.AddWithValue("@SizeCode", IIf(IsNothing(dt.Rows(j).Item("SizeCode")) Or IsDBNull(dt.Rows(j).Item("SizeCode")), DBNull.Value, dt.Rows(j).Item("SizeCode")))
                    command1.Parameters.AddWithValue("@ColorCode", IIf(IsNothing(dt.Rows(j).Item("ColorCode")) Or IsDBNull(dt.Rows(j).Item("ColorCode")), DBNull.Value, dt.Rows(j).Item("ColorCode")))
                    command1.Parameters.AddWithValue("@LigneDesc", IIf(IsNothing(dt.Rows(j).Item("LigneDesc")) Or IsDBNull(dt.Rows(j).Item("LigneDesc")), DBNull.Value, dt.Rows(j).Item("LigneDesc")))
                    command1.Parameters.AddWithValue("@ReasonId", DBNull.Value)
                    command1.Parameters.AddWithValue("@KitHead", 0)
                    command1.Parameters.AddWithValue("@KitLink", 0)
                    command1.Parameters.AddWithValue("@Up", 0)
                    command1.Parameters.AddWithValue("@Qty", IIf(IsNothing(dt.Rows(j).Item("Qty")) Or IsDBNull(dt.Rows(j).Item("Qty")), DBNull.Value, dt.Rows(j).Item("Qty")))
                    command1.Parameters.AddWithValue("@F_Qty", 0)
                    command1.Parameters.AddWithValue("@AltQty", 0)
                    command1.Parameters.AddWithValue("@AltF_Qty", 0)
                    command1.Parameters.AddWithValue("@UOMCode", IIf(IsNothing(dt.Rows(j).Item("UOMCode")) Or IsDBNull(dt.Rows(j).Item("UOMCode")), DBNull.Value, dt.Rows(j).Item("UOMCode")))
                    command1.Parameters.AddWithValue("@Factor", IIf(IsNothing(dt.Rows(j).Item("Factor")) Or IsDBNull(dt.Rows(j).Item("Factor")), DBNull.Value, dt.Rows(j).Item("Factor")))
                    command1.Parameters.AddWithValue("@Sign", -1)
                    command1.Parameters.AddWithValue("@DiscPct", 0)
                    command1.Parameters.AddWithValue("@DiscAmt", 0)
                    command1.Parameters.AddWithValue("@TotalLigne", 0)
                    command1.Parameters.AddWithValue("@VatAmt", 0)
                    command1.Parameters.AddWithValue("@VatPct", 0)
                    command1.Parameters.AddWithValue("@HeadDisc", 0)
                    command1.Parameters.AddWithValue("@CreditNote", DBNull.Value)
                    command1.Parameters.AddWithValue("@DebitNote", DBNull.Value)
                    command1.Parameters.AddWithValue("@QtyAffect", IIf(IsNothing(dt.Rows(j).Item("Qty")) Or IsDBNull(dt.Rows(j).Item("Qty")), DBNull.Value, dt.Rows(j).Item("Qty")))
                    command1.Parameters.AddWithValue("@AltQtyAffect", 0)
                    command1.Parameters.AddWithValue("@QtyRemain", 0)
                    command1.Parameters.AddWithValue("@F_QtyRemain", 0)
                    command1.Parameters.AddWithValue("@AltQtyRemain", 0)
                    command1.Parameters.AddWithValue("@F_AltQtyRemain", 0)
                    command1.Parameters.AddWithValue("@UnitCost", DBNull.Value)
                    command1.Parameters.AddWithValue("@UnitCostRateFl", DBNull.Value)
                    command1.Parameters.AddWithValue("@UnitCostRateSl", DBNull.Value)
                    command1.Parameters.AddWithValue("@AvgCost", DBNull.Value)
                    command1.Parameters.AddWithValue("@Fl_AvgCost", DBNull.Value)
                    command1.Parameters.AddWithValue("@Sl_AvgCost", DBNull.Value)
                    command1.Parameters.AddWithValue("@QtyOnHand", DBNull.Value)
                    command1.Parameters.AddWithValue("@CostingOrder", DBNull.Value)
                    command1.Parameters.AddWithValue("@UUser", FrmLogin.user)
                    command1.Parameters.AddWithValue("@Udate", Today.Date)
                    command1.Parameters.AddWithValue("@InfoRef", "")
                    command1.Parameters.AddWithValue("@ContractSubId", DBNull.Value)
                    command1.Parameters.AddWithValue("@ContractSubCode", DBNull.Value)
                    command1.Parameters.AddWithValue("@lineorder", lineid)
                    SqlS += CommandAsSql(command1)
                    BackgroundWorker1.ReportProgress(30)
                Next
                BackgroundWorker1.ReportProgress(50)
                lineid = 5000
                For j = 0 To dt.Rows.Count - 1
                    lineid += 1
                    Dim command1 As SqlCommand = con.CreateCommand()
                    ' Start a local transaction
                    command1.Connection = con
                    command1.CommandText = "SpIv_BODeliveryOrderBInsert"
                    command1.CommandType = CommandType.StoredProcedure
                    command1.Parameters.AddWithValue("@OperId", Operid)
                    command1.Parameters.AddWithValue("@InvTypeId", FrmMainForm.DeliveryOrder)
                    command1.Parameters.AddWithValue("@LigneId", lineid)
                    command1.Parameters.AddWithValue("@ItemBId", IIf(IsNothing(dt.Rows(j).Item("ItemBId")) Or IsDBNull(dt.Rows(j).Item("ItemBId")), DBNull.Value, dt.Rows(j).Item("ItemBId")))
                    command1.Parameters.AddWithValue("@ItemAid", IIf(IsNothing(dt.Rows(j).Item("ItemAid")) Or IsDBNull(dt.Rows(j).Item("ItemAid")), DBNull.Value, dt.Rows(j).Item("ItemAid")))
                    command1.Parameters.AddWithValue("@BarCode", IIf(IsNothing(dt.Rows(j).Item("BarCode")) Or IsDBNull(dt.Rows(j).Item("BarCode")), DBNull.Value, dt.Rows(j).Item("BarCode")))
                    command1.Parameters.AddWithValue("@ItemShDescription", IIf(IsNothing(dt.Rows(j).Item("ItemShDescription")) Or IsDBNull(dt.Rows(j).Item("ItemShDescription")), DBNull.Value, dt.Rows(j).Item("ItemShDescription")))
                    command1.Parameters.AddWithValue("@WhsCode", FrmMainForm.TransferToWhs)
                    command1.Parameters.AddWithValue("@SizeCode", IIf(IsNothing(dt.Rows(j).Item("SizeCode")) Or IsDBNull(dt.Rows(j).Item("SizeCode")), DBNull.Value, dt.Rows(j).Item("SizeCode")))
                    command1.Parameters.AddWithValue("@ColorCode", IIf(IsNothing(dt.Rows(j).Item("ColorCode")) Or IsDBNull(dt.Rows(j).Item("ColorCode")), DBNull.Value, dt.Rows(j).Item("ColorCode")))
                    command1.Parameters.AddWithValue("@LigneDesc", IIf(IsNothing(dt.Rows(j).Item("LigneDesc")) Or IsDBNull(dt.Rows(j).Item("LigneDesc")), DBNull.Value, dt.Rows(j).Item("LigneDesc")))
                    command1.Parameters.AddWithValue("@ReasonId", DBNull.Value)
                    command1.Parameters.AddWithValue("@KitHead", 0)
                    command1.Parameters.AddWithValue("@KitLink", 0)
                    command1.Parameters.AddWithValue("@Up", 0)
                    command1.Parameters.AddWithValue("@Qty", IIf(IsNothing(dt.Rows(j).Item("Qty")) Or IsDBNull(dt.Rows(j).Item("Qty")), DBNull.Value, dt.Rows(j).Item("Qty")))
                    command1.Parameters.AddWithValue("@F_Qty", 0)
                    command1.Parameters.AddWithValue("@AltQty", 0)
                    command1.Parameters.AddWithValue("@AltF_Qty", 0)
                    command1.Parameters.AddWithValue("@UOMCode", IIf(IsNothing(dt.Rows(j).Item("UOMCode")) Or IsDBNull(dt.Rows(j).Item("UOMCode")), DBNull.Value, dt.Rows(j).Item("UOMCode")))
                    command1.Parameters.AddWithValue("@Factor", IIf(IsNothing(dt.Rows(j).Item("Factor")) Or IsDBNull(dt.Rows(j).Item("Factor")), DBNull.Value, dt.Rows(j).Item("Factor")))
                    command1.Parameters.AddWithValue("@Sign", 1)
                    command1.Parameters.AddWithValue("@DiscPct", 0)
                    command1.Parameters.AddWithValue("@DiscAmt", 0)
                    command1.Parameters.AddWithValue("@TotalLigne", 0)
                    command1.Parameters.AddWithValue("@VatAmt", 0)
                    command1.Parameters.AddWithValue("@VatPct", 0)
                    command1.Parameters.AddWithValue("@HeadDisc", 0)
                    command1.Parameters.AddWithValue("@CreditNote", DBNull.Value)
                    command1.Parameters.AddWithValue("@DebitNote", DBNull.Value)
                    command1.Parameters.AddWithValue("@QtyAffect", IIf(IsNothing(dt.Rows(j).Item("Qty")) Or IsDBNull(dt.Rows(j).Item("Qty")), DBNull.Value, dt.Rows(j).Item("Qty")))
                    command1.Parameters.AddWithValue("@AltQtyAffect", 0)
                    command1.Parameters.AddWithValue("@QtyRemain", 0)
                    command1.Parameters.AddWithValue("@F_QtyRemain", 0)
                    command1.Parameters.AddWithValue("@AltQtyRemain", 0)
                    command1.Parameters.AddWithValue("@F_AltQtyRemain", 0)
                    command1.Parameters.AddWithValue("@UnitCost", DBNull.Value)
                    command1.Parameters.AddWithValue("@UnitCostRateFl", DBNull.Value)
                    command1.Parameters.AddWithValue("@UnitCostRateSl", DBNull.Value)
                    command1.Parameters.AddWithValue("@AvgCost", DBNull.Value)
                    command1.Parameters.AddWithValue("@Fl_AvgCost", DBNull.Value)
                    command1.Parameters.AddWithValue("@Sl_AvgCost", DBNull.Value)
                    command1.Parameters.AddWithValue("@QtyOnHand", DBNull.Value)
                    command1.Parameters.AddWithValue("@CostingOrder", DBNull.Value)
                    command1.Parameters.AddWithValue("@UUser", FrmLogin.user)
                    command1.Parameters.AddWithValue("@Udate", Today.Date)
                    command1.Parameters.AddWithValue("@InfoRef", "")
                    command1.Parameters.AddWithValue("@ContractSubId", DBNull.Value)
                    command1.Parameters.AddWithValue("@ContractSubCode", DBNull.Value)
                    command1.Parameters.AddWithValue("@lineorder", lineid)
                    SqlS += CommandAsSql(command1)
                    BackgroundWorker1.ReportProgress(60)
                Next
                BackgroundWorker1.ReportProgress(80)
                If SqlS <> "" Then
                    Dim transaction As SqlTransaction = Nothing
                    If con.State = ConnectionState.Closed Then
                        con.Open()
                    End If
                    Dim transcommand As SqlCommand = con.CreateCommand()
                    transaction = con.BeginTransaction("SampleTransaction")
                    ' Must assign both transaction object and connection
                    ' to Command object for a pending local transaction.
                    transcommand.Connection = con
                    transcommand.Transaction = transaction
                    transcommand.CommandText = SqlS
                    transcommand.CommandType = CommandType.Text
                    transcommand.CommandTimeout = 0
                    Try
                        transcommand.ExecuteNonQuery()
                        transaction.Commit()
                        Dim sqlc As New SqlCommand(" update SacSequence set Sequence = " & Operid & " where SeqCode = 'invtype" & FrmMainForm.DeliveryOrder & "' and seqyear = " & Today.Year, con)
                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If
                        sqlc.ExecuteNonQuery()
                        sqlc = New SqlCommand(" update IvOperation1Es set WhsToCode = '" & FrmMainForm.TransferToWhs & "' where invtypeid = " & FrmMainForm.DeliveryOrder & " and operid = " & Operid, con)
                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If
                        sqlc.ExecuteNonQuery()


                        Dim Sqltext = " update IvB set InfoRef2 = 1  From IvOperationB1ES IvB join IvOperation1ES IvA on IvA.InvTypeID = IvB.InvTypeID and IvA.OperID = IvB.OperID "
                        Sqltext = Sqltext & " where IvA.invtypeid=" & FrmMainForm.DeliveryOrder
                        Sqltext = Sqltext & " and IvA.OperDate >= '" & dtptransferfrom.DateTime.Date.ToString("yyyyMMdd") & "'"
                        Sqltext = Sqltext & " and IvA.OperDate <= '" & dtptransfertill.DateTime.Date.ToString("yyyyMMdd") & "'"
                        sqlc = New SqlCommand(Sqltext, BoCnx)
                        If BoCnx.State = ConnectionState.Closed Then
                            BoCnx.Open()
                        End If
                        sqlc.ExecuteNonQuery()
                        MessageBox.Show("Done", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        BackgroundWorker1.ReportProgress(100)
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        BackgroundWorker1.ReportProgress(0)
                        Try
                            transaction.Rollback()
                        Catch ex2 As Exception
                            MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            BackgroundWorker1.ReportProgress(0)
                        End Try
                    Finally
                        con.Close()
                    End Try
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            BackgroundWorker1.ReportProgress(0)
        End Try
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As System.Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        ProgressBarControl1.EditValue = e.ProgressPercentage
    End Sub

    Public Sub SendDataToTempTable()
        Try
            Dim BoConxString = "Data Source ='" & FrmMainForm.BOServer & "';Initial Catalog='" & FrmMainForm.SalesFromDb & "';user ID='" & FrmMainForm.BOUser & "';password='" & FrmMainForm.BOPass & "'"
            Dim BoCnx As SqlConnection = New SqlConnection(BoConxString)
            Dim blnconnectionOpen1 = ConnStatus(BoCnx)
            If Not blnconnectionOpen1 Then ConnOpen(BoCnx)

            Dim TableCreateStr = " drop table IvOperationBTransfer "

            Dim SqlCom As New SqlCommand(TableCreateStr, BoCnx)
            SqlCom.ExecuteNonQuery()

            TableCreateStr = " Create Table IvOperationBTransfer ( "
            TableCreateStr = TableCreateStr + " LigneID int, "
            TableCreateStr = TableCreateStr + " ItemBID int, "
            TableCreateStr = TableCreateStr + " ItemAID int, "
            TableCreateStr = TableCreateStr + " BarCode varchar(20), "
            TableCreateStr = TableCreateStr + " ItemShDescription varchar(50), "
            TableCreateStr = TableCreateStr + " WhsCode varchar(5), "
            TableCreateStr = TableCreateStr + " SizeCode varchar(5), "
            TableCreateStr = TableCreateStr + " ColorCode varchar(10), "
            TableCreateStr = TableCreateStr + " LigneDesc varchar(200), "
            TableCreateStr = TableCreateStr + " Up numeric(18, 5), "
            TableCreateStr = TableCreateStr + " Qty numeric(18, 3), "
            TableCreateStr = TableCreateStr + " UOMCode varchar(5), "
            TableCreateStr = TableCreateStr + " Factor numeric(18, 3), "
            TableCreateStr = TableCreateStr + " Sign int, "
            TableCreateStr = TableCreateStr + " TotalLigne numeric(18, 3), "
            TableCreateStr = TableCreateStr + " VatAmt numeric(18, 3), "
            TableCreateStr = TableCreateStr + " VatPct numeric(6, 3), "
            TableCreateStr = TableCreateStr + " QtyAffect numeric(18, 3), "
            TableCreateStr = TableCreateStr + " LineOrder int )"

            SqlCom = New SqlCommand(TableCreateStr, BoCnx)
            SqlCom.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BackgroundWorker2_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        GetPriceList()
        BackgroundWorker2.ReportProgress(10)
        SendDataToTempTable()
        BackgroundWorker2.ReportProgress(15)

        Dim BoConxString = "Data Source ='" & FrmMainForm.BOServer & "';Initial Catalog='" & FrmMainForm.SalesFromDb & "';user ID='" & FrmMainForm.BOUser & "';password='" & FrmMainForm.BOPass & "'; Connection Timeout = 0"
        Dim BoCnx As SqlConnection = New SqlConnection(BoConxString)
        Dim blnconnectionOpen1 = ConnStatus(BoCnx)
        If Not blnconnectionOpen1 Then ConnOpen(BoCnx)


        Dim da As New SqlDataAdapter
        Dim Operid As Integer
        Dim datet = Today.Date
        Dim TransCode As Object
        Dim ToPost = ""
        Dim AffectRem = ""
        Dim SignAffect = ""
        Dim InvType = ""
        Dim Gross As Double = 0
        Dim VatAmt As Double = 0
        Dim SqlS = ""
        Try
            Dim SqlString = ""
            SqlString = SqlString & " Insert Into IvOperationBTransfer (LigneID,ItemBID,ItemAID,BarCode,ItemShDescription,"
            SqlString = SqlString & " WhsCode, SizeCode, ColorCode, LigneDesc, Up, Qty, UOMCode, Factor, Sign) "
            SqlString = SqlString & " Select ROW_NUMBER() over(Order by IvB.ItemBID) as 'LigneId', IvB.ItemBID, IvB.ItemAID, IvB.BarCode, IvB.ItemShDescription,"
            SqlString = SqlString & "'" & FrmMainForm.PurchaseWhs & "' as 'WhsCode', "
            SqlString = SqlString & " IvB.SizeCode, IvB.ColorCode, IvB.LigneDesc, IvP.PromoPrice as 'Up', sum(IvB.Qty)as 'Qty' ,"
            SqlString = SqlString & " IvB.UOMCode, IvB.Factor, 1 as Sign "
            SqlString = SqlString & " From " & FrmMainForm.SalesFromDb & "..IvOperationB1Es IvB"
            SqlString = SqlString & " Join IvOperation1Es IvA on Iva.OperID = IvB.OperID and IvB.InvTypeId= IvA.InvTypeId "
            SqlString = SqlString & " Join IvItemA1ES Ia on Ia.ItemAid = IvB.ItemAid "
            SqlString = SqlString & " Join IvPriceListb1Es IvP on IvP.ItemAid = Ia.ItemAid "
            SqlString = SqlString & " where Ia.SupplierID = " & FrmMainForm.SupplierID & " And IvB.InvTypeID = " & FrmMainForm.SalesInvoice
            If CBWhs.Checked = True Then
                SqlString = SqlString & " and IvA.WhsCode = '" & FrmMainForm.PurchaseWhs & "' and IvP.ListCode='" & FrmMainForm.PurchasePriceList & "'"
            Else
                SqlString = SqlString & " and IvA.WhsCode <> '" & FrmMainForm.PurchaseWhs & "' and IvP.ListCode='" & FrmMainForm.PurchasePriceList & "'"
            End If
            SqlString = SqlString & " and isnull(IvB.InfoRef2,0) <> 1 "
            SqlString = SqlString & " and IvA.ActivationDate >= '" & DtpCriteriaFrom.DateTime.Date.ToString("yyyyMMdd") & "'"
            SqlString = SqlString & " and IvA.ActivationDate <= '" & dtpCriteriaTill.DateTime.Date.ToString("yyyyMMdd") & "'"
            SqlString = SqlString & " group by IvB.BarCode,IvB.ItemBID, IvB.ItemAID, IvB.ItemShDescription, "
            SqlString = SqlString & " IvB.SizeCode, IvB.ColorCode, IvB.LigneDesc, "
            SqlString = SqlString & " IvB.UOMCode, IvB.Factor,IvP.PromoPrice "

            Dim sqlCom As New SqlCommand(SqlString, BoCnx)
            sqlCom.ExecuteNonQuery()

            SqlString = ""
            SqlString = " Update IvOperationBTransfer set QtyAffect = Qty , "
            SqlString = SqlString & " TotalLigne = ( Up * Qty) "
            SqlString = SqlString & " , VatAmt = Up * Qty *0.11 "
            SqlString = SqlString & " , VatPct = 11 "
            SqlString = SqlString & " , LineOrder = LigneID "
            sqlCom = New SqlCommand(SqlString, BoCnx)
            sqlCom.ExecuteNonQuery()

            BackgroundWorker2.ReportProgress(30)
            SqlString = ""

            SqlString = " Select * from IvOperationBTransfer "
            Dim dt As New DataTable
            sqlCom = New SqlCommand(SqlString, BoCnx)
            blnconnectionOpen1 = ConnStatus(BoCnx)
            If Not blnconnectionOpen1 Then ConnOpen(BoCnx)
            da = New SqlDataAdapter(sqlCom)
            da.Fill(dt)
            BackgroundWorker2.ReportProgress(35)
            If dt.Rows.Count > 0 Then

                sqlCom = New SqlCommand("Select CurCode from IvPriceList1ES where ListCode='" & FrmMainForm.PurchasePriceList & "'", BoCnx)
                blnconnectionOpen1 = ConnStatus(BoCnx)
                If Not blnconnectionOpen1 Then ConnOpen(BoCnx)
                CurCode = sqlCom.ExecuteScalar

                sqlCom = New SqlCommand("select SignAffect,AffectRemainQty,ToPost,TransCode from ivinvoicetype1es where InvTypeID = " & FrmMainForm.PurchaseID, BoCnx)
                blnconnectionOpen1 = ConnStatus(BoCnx)
                If Not blnconnectionOpen1 Then ConnOpen(BoCnx)
                Dim dtParameters As New DataTable
                da = New SqlDataAdapter(sqlCom)
                da.Fill(dtParameters)
                TransCode = IIf(IsNothing(dtParameters.Rows(0).Item("TransCode")) Or IsDBNull(dtParameters.Rows(0).Item("TransCode")), DBNull.Value, dtParameters.Rows(0).Item("TransCode"))
                ToPost = dtParameters.Rows(0).Item("ToPost").ToString
                AffectRem = dtParameters.Rows(0).Item("AffectRemainQty").ToString
                SignAffect = dtParameters.Rows(0).Item("SignAffect").ToString
                Dim clsOpa As New ClsOperationA
                If ToPost = 1 Then
                    InvType = TransCode
                Else
                    InvType = "invtype" & FrmMainForm.PurchaseID
                End If

                sqlCom = New SqlCommand("select Sequence from sacsequence where SeqCode='" & InvType & "' and seqyear=" & Today.Year & "", BoCnx)
                blnconnectionOpen1 = ConnStatus(BoCnx)
                If Not blnconnectionOpen1 Then ConnOpen(BoCnx)
                If IsDBNull(sqlCom.ExecuteScalar) Or IsNothing(sqlCom.ExecuteScalar) Then
                    Dim sqlc As New SqlCommand("insert into SacSequence (SeqCode,SeqYear,Companyid,Sequence) values ('" &
                                           InvType & "'," & Today.Year & ",1," & Today.Year & "000000)", BoCnx)
                    sqlc.ExecuteNonQuery()
                End If
                sqlCom = New SqlCommand("select Sequence from sacsequence where SeqCode='" & InvType & "' and seqyear=" & Today.Year & "", BoCnx)
                blnconnectionOpen1 = ConnStatus(BoCnx)
                If Not blnconnectionOpen1 Then ConnOpen(BoCnx)
                Operid = sqlCom.ExecuteScalar + 1


                Dim command As SqlCommand = BoCnx.CreateCommand()
                command.Connection = BoCnx
                command.CommandText = "spRs_OpertaionAInsert"
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.AddWithValue("@p1", Operid)
                command.Parameters.AddWithValue("@p2", FrmMainForm.PurchaseID)
                command.Parameters.AddWithValue("@p3", IIf(IsNothing(datet) Or IsDBNull(datet), DBNull.Value, datet))
                command.Parameters.AddWithValue("@p4", IIf(IsNothing(datet) Or IsDBNull(datet), DBNull.Value, datet))
                command.Parameters.AddWithValue("@p5", FrmMainForm.SupplierID)
                sqlCom = New SqlCommand("select ShortName from SacThirdParty where thirdid=" & FrmMainForm.SupplierID & "", BoCnx)
                blnconnectionOpen1 = ConnStatus(BoCnx)
                If Not blnconnectionOpen1 Then ConnOpen(BoCnx)
                Dim desc As String = sqlCom.ExecuteScalar
                command.Parameters.AddWithValue("@p6", desc)
                command.Parameters.AddWithValue("@p7", DBNull.Value)
                command.Parameters.AddWithValue("@p8", DBNull.Value)
                command.Parameters.AddWithValue("@p9", FrmMainForm.PurchaseWhs)
                command.Parameters.AddWithValue("@p10", DBNull.Value)
                command.Parameters.AddWithValue("@p11", CurCode)
                command.Parameters.AddWithValue("@p12", DBNull.Value)
                command.Parameters.AddWithValue("@p13", "")
                command.Parameters.AddWithValue("@p14", "")
                command.Parameters.AddWithValue("@p15", "")
                command.Parameters.AddWithValue("@p16", 0)
                command.Parameters.AddWithValue("@p17", 0)
                command.Parameters.AddWithValue("@p18", 1)
                command.Parameters.AddWithValue("@p19", 1)
                command.Parameters.AddWithValue("@p20", 1)
                sqlCom = New SqlCommand("Sp_GetHelpRates", BoCnx)
                sqlCom.CommandType = CommandType.StoredProcedure
                sqlCom.Parameters.AddWithValue("@Cmp", 1)
                sqlCom.Parameters.AddWithValue("@date1", DateTime.Today.ToString("yyyyMMdd"))
                sqlCom.Parameters.AddWithValue("@cur", CurCode)
                blnconnectionOpen1 = ConnStatus(BoCnx)
                If Not blnconnectionOpen1 Then ConnOpen(BoCnx)
                Dim dsRates As New DataSet
                dsRates.Clear()
                da = New SqlDataAdapter(sqlCom)
                da.Fill(dsRates, "Rates")
                command.Parameters.AddWithValue("@p21", dsRates.Tables("Rates").Rows(0).Item("SalesRate"))
                command.Parameters.AddWithValue("@p22", dsRates.Tables("Rates").Rows(0).Item("SalesslRate"))
                command.Parameters.AddWithValue("@p23", dsRates.Tables("Rates").Rows(0).Item("VatRate"))
                command.Parameters.AddWithValue("@p24", String.Empty)
                command.Parameters.AddWithValue("@p25", DateTime.Today)

                SqlString = " Select Sum (QtyAffect * Up) as Gross, Sum(VatAmt) as VatAmt from IvOperationBTransfer "
                sqlCom = New SqlCommand(SqlString, BoCnx)
                blnconnectionOpen1 = ConnStatus(BoCnx)
                If Not blnconnectionOpen1 Then ConnOpen(BoCnx)
                da = New SqlDataAdapter(sqlCom)
                Dim dtGros As New DataTable
                da.Fill(dtGros)
                Gross = dtGros.Rows(0).Item("Gross")
                VatAmt = dtGros.Rows(0).Item("VatAmt")
                command.Parameters.AddWithValue("@p26", IIf(IsDBNull(Gross) Or IsNothing(Gross), 0, Gross))

                command.Parameters.AddWithValue("@p27", 0) 'Disc1PCT
                command.Parameters.AddWithValue("@p28", 0)
                command.Parameters.AddWithValue("@p29", 0)
                command.Parameters.AddWithValue("@p30", 0)
                command.Parameters.AddWithValue("@p31", 0)
                command.Parameters.AddWithValue("@p32", 0)
                command.Parameters.AddWithValue("@p33", 0)
                command.Parameters.AddWithValue("@p34", IIf(IsDBNull(Gross) Or IsNothing(Gross), 0, Gross))
                command.Parameters.AddWithValue("@p35", IIf(IsDBNull(VatAmt) Or IsNothing(VatAmt), 0, Math.Round(VatAmt, 2)))
                command.Parameters.AddWithValue("@p36", "")
                command.Parameters.AddWithValue("@p37", FrmLogin.user)
                command.Parameters.AddWithValue("@p38", FrmLogin.user)
                command.Parameters.AddWithValue("@p39", DateTime.Today)
                command.Parameters.AddWithValue("@p40", DBNull.Value)
                command.Parameters.AddWithValue("@p41", DBNull.Value)
                command.Parameters.AddWithValue("@p42", DBNull.Value)
                command.Parameters.AddWithValue("@p43", DBNull.Value)
                command.Parameters.AddWithValue("@p44", 0)
                command.Parameters.AddWithValue("@p45", 0)
                command.Parameters.AddWithValue("@p46", 0)
                command.Parameters.AddWithValue("@p47", 0)
                command.Parameters.AddWithValue("@p48", 0)
                command.Parameters.AddWithValue("@p49", 0)
                command.Parameters.AddWithValue("@p50", 0)
                command.Parameters.AddWithValue("@p51", 0)
                command.Parameters.AddWithValue("@p52", DBNull.Value)
                command.Parameters.AddWithValue("@p53", DBNull.Value)
                command.Parameters.AddWithValue("@p54", DBNull.Value)
                SqlS += CommandAsSql(command)
                BackgroundWorker2.ReportProgress(40)
                Dim AmtRnd = "0"

                If dsRates.Tables("Rates").Rows(0).Item("decimals") = 1 Then
                    AmtRnd = "0.0"
                ElseIf dsRates.Tables("Rates").Rows(0).Item("decimals") = 2 Then
                    AmtRnd = "0.00"
                ElseIf dsRates.Tables("Rates").Rows(0).Item("decimals") = 3 Then
                    AmtRnd = "0.000"
                End If

                SqlString = ""

                For i = 0 To dt.Rows.Count - 1
                    Dim command1 As SqlCommand = BoCnx.CreateCommand()
                    command1.Connection = BoCnx
                    command1.CommandText = "spRs_OpertaionBInsert"
                    command1.CommandType = CommandType.StoredProcedure
                    command1.Parameters.AddWithValue("@p1", Operid)
                    command1.Parameters.AddWithValue("@p2", FrmMainForm.PurchaseID)
                    command1.Parameters.AddWithValue("@p3", dt.Rows(i).Item("LigneId"))
                    command1.Parameters.AddWithValue("@p4", dt.Rows(i).Item("ItembId"))
                    command1.Parameters.AddWithValue("@p5", dt.Rows(i).Item("Itemaid"))
                    command1.Parameters.AddWithValue("@p6", dt.Rows(i).Item("barcode"))
                    command1.Parameters.AddWithValue("@p7", dt.Rows(i).Item("itemshdescription"))
                    command1.Parameters.AddWithValue("@p8", FrmMainForm.PurchaseWhs)
                    command1.Parameters.AddWithValue("@p9", dt.Rows(i).Item("SizeCode"))
                    command1.Parameters.AddWithValue("@p10", dt.Rows(i).Item("ColorCode"))
                    command1.Parameters.AddWithValue("@p11", dt.Rows(i).Item("itemshdescription"))
                    command1.Parameters.AddWithValue("@p12", DBNull.Value)
                    command1.Parameters.AddWithValue("@p13", 0)
                    command1.Parameters.AddWithValue("@p14", 0)
                    command1.Parameters.AddWithValue("@p15", Format(Math.Abs(dt.Rows(i).Item("Up")), AmtRnd))
                    command1.Parameters.AddWithValue("@p16", dt.Rows(i).Item("QtyAffect"))
                    command1.Parameters.AddWithValue("@p17", 0)
                    command1.Parameters.AddWithValue("@p18", 0)
                    command1.Parameters.AddWithValue("@p19", 0)
                    command1.Parameters.AddWithValue("@p20", dt.Rows(i).Item("uomcode"))
                    command1.Parameters.AddWithValue("@p21", 1)
                    command1.Parameters.AddWithValue("@p22", SignAffect)
                    command1.Parameters.AddWithValue("@p23", 0)
                    command1.Parameters.AddWithValue("@p24", 0)
                    Dim TotalLigne As Decimal = 0
                    TotalLigne = dt.Rows(i).Item("TotalLigne")
                    command1.Parameters.AddWithValue("@p25", TotalLigne)
                    command1.Parameters.AddWithValue("@p26", dt.Rows(i).Item("VatAmt"))
                    command1.Parameters.AddWithValue("@p27", 10)
                    command1.Parameters.AddWithValue("@p28", 0)
                    command1.Parameters.AddWithValue("@p29", dt.Rows(i).Item("QtyAffect"))
                    command1.Parameters.AddWithValue("@p30", 0)
                    If AffectRem = 1 Then
                        command1.Parameters.AddWithValue("@p31", dt.Rows(i).Item("QtyAffect"))
                    Else
                        command1.Parameters.AddWithValue("@p31", 0)
                    End If
                    command1.Parameters.AddWithValue("@p32", 0)
                    command1.Parameters.AddWithValue("@p33", 0)
                    command1.Parameters.AddWithValue("@p34", 0)
                    command1.Parameters.AddWithValue("@p35", DBNull.Value)
                    command1.Parameters.AddWithValue("@p36", DBNull.Value)
                    command1.Parameters.AddWithValue("@p37", DBNull.Value)
                    command1.Parameters.AddWithValue("@p38", FrmLogin.user)
                    command1.Parameters.AddWithValue("@p39", DateTime.Today)
                    command1.Parameters.AddWithValue("@p40", "")
                    command1.Parameters.AddWithValue("@p41", DBNull.Value)
                    command1.Parameters.AddWithValue("@p42", DBNull.Value)
                    command1.Parameters.AddWithValue("@p43", dt.Rows(i).Item("LineOrder"))
                    command1.Parameters.AddWithValue("@p44", DBNull.Value)
                    command1.Parameters.AddWithValue("@p45", DBNull.Value)
                    SqlS += CommandAsSql(command1)
                Next
                BackgroundWorker2.ReportProgress(46)
                If SqlS <> "" Then
                    If BoCnx.State = ConnectionState.Closed Then
                        BoCnx.Open()
                    End If
                    Dim transaction As SqlTransaction = Nothing
                    Dim transcommand As SqlCommand = BoCnx.CreateCommand()
                    transaction = BoCnx.BeginTransaction("SampleTransaction")
                    transcommand.Connection = BoCnx
                    transcommand.Transaction = transaction
                    transcommand.CommandText = SqlS
                    transcommand.CommandType = CommandType.Text
                    Try
                        transcommand.ExecuteNonQuery()
                        transaction.Commit()
                        BackgroundWorker2.ReportProgress(70)
                        sqlCom = New SqlCommand("update sacsequence set Sequence=" & Operid & " where SeqCode='" & InvType & "' and seqyear=" & Today.Year & "", BoCnx)
                        blnconnectionOpen1 = ConnStatus(BoCnx)
                        If Not blnconnectionOpen1 Then ConnOpen(BoCnx)
                        sqlCom.ExecuteNonQuery()
                        Dim Sqltext = " update IvB set InfoRef2 = 1  From IvOperationB1ES IvB join IvOperation1ES IvA on IvA.InvTypeID = IvB.InvTypeID and IvA.OperID = IvB.OperID "
                        Sqltext = Sqltext & " where IvA.invtypeid=" & FrmMainForm.SalesInvoice
                        Sqltext = Sqltext & " and IvA.ActivationDate >= '" & DtpCriteriaFrom.DateTime.Date.ToString("yyyyMMdd") & "'"
                        Sqltext = Sqltext & " and IvA.ActivationDate <= '" & dtpCriteriaTill.DateTime.Date.ToString("yyyyMMdd") & "'"
                        sqlCom = New SqlCommand(Sqltext, BoCnx)
                        blnconnectionOpen1 = ConnStatus(BoCnx)
                        If Not blnconnectionOpen1 Then ConnOpen(BoCnx)
                        sqlCom.ExecuteNonQuery()

                    Catch ex As Exception
                        MessageBox.Show("Message exctype: " & ex.Message, "Error")
                        Try
                            transaction.Rollback()
                        Catch ex2 As Exception
                            MessageBox.Show("Rollback msg: " & ex2.Message)
                        End Try
                    End Try
                End If
                SqlS = ""

                BoConxString = "Data Source ='" & FrmMainForm.BOServer & "';Initial Catalog='" & FrmMainForm.SalesIndB & "';user ID='" & FrmMainForm.BOUser & "';password='" & FrmMainForm.BOPass & "'; Connection TimeOut = 0"
                BoCnx = New SqlConnection(BoConxString)

                sqlCom = New SqlCommand("select SignAffect,AffectRemainQty,ToPost,TransCode from ivinvoicetype1es where InvTypeID = " & FrmMainForm.SalesInvoice, BoCnx)
                blnconnectionOpen1 = ConnStatus(BoCnx)
                If Not blnconnectionOpen1 Then ConnOpen(BoCnx)
                dtParameters = New DataTable
                da = New SqlDataAdapter(sqlCom)
                da.Fill(dtParameters)
                TransCode = IIf(IsNothing(dtParameters.Rows(0).Item("TransCode")) Or IsDBNull(dtParameters.Rows(0).Item("TransCode")), DBNull.Value, dtParameters.Rows(0).Item("TransCode"))
                ToPost = dtParameters.Rows(0).Item("ToPost").ToString
                AffectRem = dtParameters.Rows(0).Item("AffectRemainQty").ToString
                SignAffect = dtParameters.Rows(0).Item("SignAffect").ToString
                InvType = ""
                clsOpa = New ClsOperationA
                If ToPost = 1 Then
                    InvType = TransCode
                Else
                    InvType = "invtype" & FrmMainForm.SalesInvoice
                End If

                sqlCom = New SqlCommand("select Sequence from sacsequence where SeqCode='" & InvType & "' and seqyear=" & Today.Year & "", BoCnx)
                blnconnectionOpen1 = ConnStatus(BoCnx)
                If Not blnconnectionOpen1 Then ConnOpen(BoCnx)
                If IsDBNull(sqlCom.ExecuteScalar) Or IsNothing(sqlCom.ExecuteScalar) Then
                    Dim sqlc As New SqlCommand("insert into SacSequence (SeqCode,SeqYear,Companyid,Sequence) values ('" &
                                           InvType & "'," & Today.Year & ",1," & Today.Year & "000000)", BoCnx)
                    sqlc.ExecuteNonQuery()
                End If
                sqlCom = New SqlCommand("select Sequence from sacsequence where SeqCode='" & InvType & "' and seqyear=" & Today.Year & "", BoCnx)
                blnconnectionOpen1 = ConnStatus(BoCnx)
                If Not blnconnectionOpen1 Then ConnOpen(BoCnx)
                Operid = sqlCom.ExecuteScalar + 1
                command = New SqlCommand
                command = BoCnx.CreateCommand()
                command.Connection = BoCnx
                command.CommandText = "spRs_OpertaionAInsert"
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.AddWithValue("@p1", Operid)
                command.Parameters.AddWithValue("@p2", FrmMainForm.SalesInvoice)
                command.Parameters.AddWithValue("@p3", IIf(IsNothing(datet) Or IsDBNull(datet), DBNull.Value, datet))
                command.Parameters.AddWithValue("@p4", IIf(IsNothing(datet) Or IsDBNull(datet), DBNull.Value, datet))
                command.Parameters.AddWithValue("@p5", FrmMainForm.SalesCustomer)
                sqlCom = New SqlCommand("select ShortName from SacThirdParty where thirdid=" & FrmMainForm.SalesCustomer & "", BoCnx)
                blnconnectionOpen1 = ConnStatus(BoCnx)
                If Not blnconnectionOpen1 Then ConnOpen(BoCnx)
                desc = sqlCom.ExecuteScalar
                command.Parameters.AddWithValue("@p6", desc)
                command.Parameters.AddWithValue("@p7", DBNull.Value)
                command.Parameters.AddWithValue("@p8", DBNull.Value)
                command.Parameters.AddWithValue("@p9", FrmMainForm.SalesWhs)
                command.Parameters.AddWithValue("@p10", DBNull.Value)
                command.Parameters.AddWithValue("@p11", CurCode)
                command.Parameters.AddWithValue("@p12", DBNull.Value)
                command.Parameters.AddWithValue("@p13", "")
                command.Parameters.AddWithValue("@p14", "")
                command.Parameters.AddWithValue("@p15", "")
                command.Parameters.AddWithValue("@p16", 0)
                command.Parameters.AddWithValue("@p17", 0)
                command.Parameters.AddWithValue("@p18", 1)
                command.Parameters.AddWithValue("@p19", 1)
                command.Parameters.AddWithValue("@p20", 1)
                sqlCom = New SqlCommand("Sp_GetHelpRates", BoCnx)
                sqlCom.CommandType = CommandType.StoredProcedure
                sqlCom.Parameters.AddWithValue("@Cmp", 1)
                sqlCom.Parameters.AddWithValue("@date1", DateTime.Today.ToString("yyyyMMdd"))
                sqlCom.Parameters.AddWithValue("@cur", CurCode)
                blnconnectionOpen1 = ConnStatus(BoCnx)
                If Not blnconnectionOpen1 Then ConnOpen(BoCnx)
                dsRates = New DataSet
                dsRates.Clear()
                da = New SqlDataAdapter(sqlCom)
                da.Fill(dsRates, "Rates")

                command.Parameters.AddWithValue("@p21", dsRates.Tables("Rates").Rows(0).Item("SalesRate"))
                command.Parameters.AddWithValue("@p22", dsRates.Tables("Rates").Rows(0).Item("SalesslRate"))
                command.Parameters.AddWithValue("@p23", dsRates.Tables("Rates").Rows(0).Item("VatRate"))
                command.Parameters.AddWithValue("@p24", String.Empty)
                command.Parameters.AddWithValue("@p25", DateTime.Today)
                command.Parameters.AddWithValue("@p26", IIf(IsDBNull(Gross) Or IsNothing(Gross), 0, Gross))
                command.Parameters.AddWithValue("@p27", 0) 'Disc1PCT
                command.Parameters.AddWithValue("@p28", 0)
                command.Parameters.AddWithValue("@p29", 0)
                command.Parameters.AddWithValue("@p30", 0)
                command.Parameters.AddWithValue("@p31", 0)
                command.Parameters.AddWithValue("@p32", 0)
                command.Parameters.AddWithValue("@p33", 0)
                command.Parameters.AddWithValue("@p34", IIf(IsDBNull(Gross) Or IsNothing(Gross), 0, Gross))
                command.Parameters.AddWithValue("@p35", IIf(IsDBNull(VatAmt) Or IsNothing(VatAmt), 0, VatAmt))
                command.Parameters.AddWithValue("@p36", "")
                command.Parameters.AddWithValue("@p37", FrmLogin.user)
                command.Parameters.AddWithValue("@p38", FrmLogin.user)
                command.Parameters.AddWithValue("@p39", DateTime.Today)
                command.Parameters.AddWithValue("@p40", DBNull.Value)
                command.Parameters.AddWithValue("@p41", DBNull.Value)
                command.Parameters.AddWithValue("@p42", DBNull.Value)
                command.Parameters.AddWithValue("@p43", DBNull.Value)
                command.Parameters.AddWithValue("@p44", 0)
                command.Parameters.AddWithValue("@p45", 0)
                command.Parameters.AddWithValue("@p46", 0)
                command.Parameters.AddWithValue("@p47", 0)
                command.Parameters.AddWithValue("@p48", 0)
                command.Parameters.AddWithValue("@p49", 0)
                command.Parameters.AddWithValue("@p50", 0)
                command.Parameters.AddWithValue("@p51", 0)
                command.Parameters.AddWithValue("@p52", DBNull.Value)
                command.Parameters.AddWithValue("@p53", DBNull.Value)
                command.Parameters.AddWithValue("@p54", DBNull.Value)
                SqlS += CommandAsSql(command)

                AmtRnd = "0"

                If dsRates.Tables("Rates").Rows(0).Item("decimals") = 1 Then
                    AmtRnd = "0.0"
                ElseIf dsRates.Tables("Rates").Rows(0).Item("decimals") = 2 Then
                    AmtRnd = "0.00"
                ElseIf dsRates.Tables("Rates").Rows(0).Item("decimals") = 3 Then
                    AmtRnd = "0.000"
                End If

                For i = 0 To dt.Rows.Count - 1
                    Dim command4 As SqlCommand = BoCnx.CreateCommand()
                    command4.Connection = BoCnx
                    command4.CommandText = "spRs_OpertaionBInsert"
                    command4.CommandType = CommandType.StoredProcedure
                    command4.Parameters.AddWithValue("@p1", Operid)
                    command4.Parameters.AddWithValue("@p2", FrmMainForm.SalesInvoice)
                    command4.Parameters.AddWithValue("@p3", dt.Rows(i).Item("LigneId"))
                    command4.Parameters.AddWithValue("@p4", dt.Rows(i).Item("ItembId"))
                    command4.Parameters.AddWithValue("@p5", dt.Rows(i).Item("Itemaid"))
                    command4.Parameters.AddWithValue("@p6", dt.Rows(i).Item("barcode"))

                    command4.Parameters.AddWithValue("@p7", dt.Rows(i).Item("itemshdescription"))
                    command4.Parameters.AddWithValue("@p8", FrmMainForm.SalesWhs)
                    command4.Parameters.AddWithValue("@p9", dt.Rows(i).Item("SizeCode"))
                    command4.Parameters.AddWithValue("@p10", dt.Rows(i).Item("ColorCode"))
                    command4.Parameters.AddWithValue("@p11", dt.Rows(i).Item("itemshdescription"))
                    command4.Parameters.AddWithValue("@p12", DBNull.Value)
                    command4.Parameters.AddWithValue("@p13", 0)
                    command4.Parameters.AddWithValue("@p14", 0)
                    command4.Parameters.AddWithValue("@p15", Format(Math.Abs(dt.Rows(i).Item("Up")), AmtRnd))
                    command4.Parameters.AddWithValue("@p16", dt.Rows(i).Item("QtyAffect"))
                    command4.Parameters.AddWithValue("@p17", 0)
                    command4.Parameters.AddWithValue("@p18", 0)
                    command4.Parameters.AddWithValue("@p19", 0)
                    command4.Parameters.AddWithValue("@p20", dt.Rows(i).Item("uomcode"))
                    command4.Parameters.AddWithValue("@p21", 1)
                    command4.Parameters.AddWithValue("@p22", SignAffect)
                    command4.Parameters.AddWithValue("@p23", 0)
                    command4.Parameters.AddWithValue("@p24", 0)

                    Dim TotalLigne As Decimal = 0
                    TotalLigne = dt.Rows(i).Item("TotalLigne")
                    command4.Parameters.AddWithValue("@p25", TotalLigne)
                    command4.Parameters.AddWithValue("@p26", dt.Rows(i).Item("VatAmt"))

                    command4.Parameters.AddWithValue("@p27", 10)

                    command4.Parameters.AddWithValue("@p28", 0)
                    command4.Parameters.AddWithValue("@p29", dt.Rows(i).Item("QtyAffect"))
                    command4.Parameters.AddWithValue("@p30", 0)
                    If AffectRem = 1 Then
                        command4.Parameters.AddWithValue("@p31", dt.Rows(i).Item("QtyAffect"))
                    Else
                        command4.Parameters.AddWithValue("@p31", 0)
                    End If
                    command4.Parameters.AddWithValue("@p32", 0)
                    command4.Parameters.AddWithValue("@p33", 0)
                    command4.Parameters.AddWithValue("@p34", 0)
                    command4.Parameters.AddWithValue("@p35", DBNull.Value)
                    command4.Parameters.AddWithValue("@p36", DBNull.Value)
                    command4.Parameters.AddWithValue("@p37", DBNull.Value)
                    command4.Parameters.AddWithValue("@p38", FrmLogin.user)
                    command4.Parameters.AddWithValue("@p39", DateTime.Today)
                    command4.Parameters.AddWithValue("@p40", "")
                    command4.Parameters.AddWithValue("@p41", DBNull.Value)
                    command4.Parameters.AddWithValue("@p42", DBNull.Value)
                    command4.Parameters.AddWithValue("@p43", dt.Rows(i).Item("LineOrder"))
                    command4.Parameters.AddWithValue("@p44", DBNull.Value)
                    command4.Parameters.AddWithValue("@p45", DBNull.Value)

                    SqlS += CommandAsSql(command4)

                Next
                BackgroundWorker2.ReportProgress(85)
                If SqlS <> "" Then
                    If BoCnx.State = ConnectionState.Closed Then
                        BoCnx.Open()
                    End If
                    Dim transaction As SqlTransaction = Nothing
                    Dim transcommand As SqlCommand = BoCnx.CreateCommand()
                    transaction = BoCnx.BeginTransaction("SampleTransaction")

                    transcommand.Connection = BoCnx
                    transcommand.Transaction = transaction
                    transcommand.CommandText = SqlS
                    transcommand.CommandType = CommandType.Text
                    Try
                        transcommand.ExecuteNonQuery()
                        transaction.Commit()
                        BackgroundWorker2.ReportProgress(95)
                        sqlCom = New SqlCommand("update sacsequence set Sequence=" & Operid & " where SeqCode='" & InvType & "' and seqyear=" & Today.Year & "", BoCnx)
                        blnconnectionOpen1 = ConnStatus(BoCnx)
                        If Not blnconnectionOpen1 Then ConnOpen(BoCnx)
                        sqlCom.ExecuteNonQuery()
                        BackgroundWorker2.ReportProgress(100)
                        MsgBox("DONE")
                        SqlS = ""
                        SqlString = ""
                        sqlCom.Dispose()
                        dt.Dispose()
                        ds.Dispose()
                        dsRates.Dispose()
                        dtParameters.Dispose()
                        dtGros.Dispose()
                    Catch ex As Exception
                        MessageBox.Show("Message exctypr: " & ex.Message, "Error")
                        Try
                            transaction.Rollback()
                        Catch ex2 As Exception
                            MessageBox.Show("Rollback msg: " & ex2.Message)
                        End Try
                    End Try
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BackgroundWorker2_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker2.ProgressChanged
        ProgressBarControl1.EditValue = e.ProgressPercentage
    End Sub
End Class