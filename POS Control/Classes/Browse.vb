Imports System.Data.SqlClient
Imports ConnectionSQL
Module Browse
    Public ds As New DataSet
    Dim da As New SqlDataAdapter
    Public source1 As New BindingSource()
    Public dtable As New DataTable
    Public Function GetOrderItems(ByVal Desc As String, ByVal con As SqlConnection) As DataTable
        Try
            Dim blnconnectionOpen As Boolean
            Dim dt As New DataTable
            Dim SqlQuery As String = String.Empty
            SqlQuery = " select ia.ItemAid,ia.ShDescription,ib.Barcode,ia.ItemCode,ib.SizeCode,ib.ColorCode,ia.NbPages,ia.Description,isnull(ic.MinQty,0) as MinQty,isnull(ic.MaxQty,0) as MaxQty,isnull(SUM(iob.QtyAffect * iob.SIGN),0) as Qty "
            SqlQuery = SqlQuery & " from IvItemA1Es ia join IvItemB1es ib on ib.itemaid = ia.itemaid "
            SqlQuery = SqlQuery & " left join IvOperationB1Es iob on ia.ItemAid=iob.ItemAid and ib.Barcode=iob.Barcode"
            SqlQuery = SqlQuery & " left join IvItemControl ic on ic.Barcode=iob.Barcode and ic.Barcode=ib.Barcode "
            SqlQuery = SqlQuery & "  where ia.Description like '%" & Desc & "%'"
            SqlQuery = SqlQuery & " Group by ia.ItemCode,ib.Barcode,ia.ItemAid,ia.ShDescription,ib.SizeCode,ib.ColorCode,ia.NbPages,ia.Description,ic.MinQty,ic.MaxQty"
            Dim sqlcomm As New SqlCommand(SqlQuery, con)
           da = New SqlDataAdapter(sqlcomm)
            dt.Clear()
            blnconnectionOpen = ConnStatus(con)
            If Not blnconnectionOpen Then ConnOpen(con)
            da.Fill(dt)
            Return dt
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Public Function GetItemsControl(ByVal Desc As String, ByVal WhsCode As String, ByVal con As SqlConnection) As DataTable
        Try
            Dim blnconnectionOpen As Boolean
            Dim dt As New DataTable
            Dim SqlQuery As String = String.Empty
            SqlQuery = " select ia.ItemAid,ia.ItemCode,ia.Description "
            SqlQuery = SqlQuery + " from IvItemA1es ia"
            SqlQuery = SqlQuery & " where ia.AllowSell = 1 "
            SqlQuery = SqlQuery & "  and ia.Description like '%" & Desc & "%' order by ia.Description"
            Dim sqlcomm As New SqlCommand(SqlQuery, con)
            da = New SqlDataAdapter(sqlcomm)
            dt.Clear()
            blnconnectionOpen = ConnStatus(con)
            If Not blnconnectionOpen Then ConnOpen(con)
            da.Fill(dt)
            Return dt
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Public Function GetAdjustmentItems(ByVal Desc As String, ByVal con As SqlConnection) As DataTable
        Try
            Dim blnconnectionOpen As Boolean
            Dim dt As New DataTable
            Dim SqlQuery As String = String.Empty
            SqlQuery = " select ia.ItemAID,ib.ItemBID,ib.Barcode,ia.Description,ia.ShDescription,ia.UOMCode,ib.ColorCode,ib.SizeCode, 0 as Qty "
            SqlQuery = SqlQuery + " from IvItemA1es ia join IvItemB1es ib on ib.Itemaid = ia.ItemAid "
            SqlQuery = SqlQuery & " where ia.AllowSell = 1 "
            SqlQuery = SqlQuery & "  and ia.Description like '%" & Desc & "%'"
            Dim sqlcomm As New SqlCommand(SqlQuery, con)
            da = New SqlDataAdapter(sqlcomm)
            dt.Clear()
            blnconnectionOpen = ConnStatus(con)
            If Not blnconnectionOpen Then ConnOpen(con)
            da.Fill(dt)
            Return dt
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

End Module
