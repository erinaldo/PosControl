Imports System.Data.SqlClient
Imports ConnectionSQL
Public Class ClsOrder
    Public Shared ds As New DataSet
    Dim da As New SqlDataAdapter
    Function GetFams(ByVal Status As Integer, ByVal First As Integer, ByVal Last As Integer, ByVal con As SqlConnection) As DataTable
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("SpRt_CategoryMain", con)
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@cmp", 1)
            sqlcomm.Parameters.AddWithValue("@Code", "")
            sqlcomm.Parameters.AddWithValue("@filter", "")
            sqlcomm.Parameters.AddWithValue("@and", "")
            sqlcomm.Parameters.AddWithValue("@status", Status)
            sqlcomm.Parameters.AddWithValue("@ext", "")
            sqlcomm.Parameters.AddWithValue("@first", First)
            sqlcomm.Parameters.AddWithValue("@last", Last)
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
    Function GetSubFams(ByVal Code As String, ByVal Status As Integer, ByVal First As Integer, ByVal Last As Integer, ByVal con As SqlConnection) As DataTable
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("SpRt_CategoryMain", con)
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@cmp", 1)
            sqlcomm.Parameters.AddWithValue("@Code", "")
            sqlcomm.Parameters.AddWithValue("@filter", "")
            sqlcomm.Parameters.AddWithValue("@and", " left(CategoryCode,3)='" & Code & "'")
            sqlcomm.Parameters.AddWithValue("@status", Status)
            sqlcomm.Parameters.AddWithValue("@ext", "")
            sqlcomm.Parameters.AddWithValue("@first", First)
            sqlcomm.Parameters.AddWithValue("@last", Last)
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
    Function GetCatss(ByVal Code As String, ByVal Status As Integer, ByVal First As Integer, ByVal Last As Integer, ByVal con As SqlConnection) As DataTable
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("SpRt_CategoryMain", con)
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@cmp", 1)
            sqlcomm.Parameters.AddWithValue("@Code", "")
            sqlcomm.Parameters.AddWithValue("@filter", "")
            sqlcomm.Parameters.AddWithValue("@and", " left(CategoryCode,6)='" & Code & "'")
            sqlcomm.Parameters.AddWithValue("@status", Status)
            sqlcomm.Parameters.AddWithValue("@ext", "")
            sqlcomm.Parameters.AddWithValue("@first", First)
            sqlcomm.Parameters.AddWithValue("@last", Last)
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
    Function GetItems(ByVal Code As String, ByVal First As Integer, ByVal Last As Integer, ByVal con As SqlConnection) As DataTable
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("spRt_ItemGetByCategory", con)
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@catcode", Code)
            sqlcomm.Parameters.AddWithValue("@first", First)
            sqlcomm.Parameters.AddWithValue("@last", Last)
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
    Function GetCustomers(ByVal con As SqlConnection) As DataTable
        Try
            Dim SqlQuery = "select sth.ThirdId,sth.name from SAcThirdParty sth,SacThirdExtra1Es ste"
            SqlQuery = SqlQuery & " where sth.ShowInReceivable=1 and sth.thirdid=ste.thirdid and stE.Stk_CustAppearInRetail=1"
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand(SqlQuery, con)
            'sqlcomm.Parameters.AddWithValue("@ItemAID", Code)
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
    Function GetSalesMan(ByVal con As SqlConnection) As DataTable
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("select ThirdId,name from SAcThirdParty where ShowInEmployee=1", con)
            'sqlcomm.Parameters.AddWithValue("@ItemAID", Code)
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
    Function GetAvailQty(ByVal BarCode As String, ByVal Whs As String, ByVal ItemCodeDesc As String, ByVal con As SqlConnection) As DataTable
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("SpIv_ItemAvailQty", con)
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@cmp", 1)
            sqlcomm.Parameters.AddWithValue("@BarCode", BarCode)
            sqlcomm.Parameters.AddWithValue("@Whs", Whs)
            sqlcomm.Parameters.AddWithValue("@ItemCodeDesc", ItemCodeDesc)
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
End Class
