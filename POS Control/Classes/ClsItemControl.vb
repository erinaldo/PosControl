Imports System.Data.SqlClient
Imports ConnectionSQL
Public Class ItemControlSettings
    Public WhsCode As String
    Public Barcode As String
    Public MinQty As Integer
    Public MaxQty As Integer
    Public Blocked As Boolean
End Class
Public Class ClsItemControl
#Region "Fields"
    Public _WhsCode As String
    Public _Barcode As String
    Public _MinQty As Integer
    Public _MaxQty As Integer
    Public _Blocked As Boolean
#End Region
#Region "Properties"
    Public Property MinQty() As Integer
        Get
            Return _MinQty
        End Get
        Set(ByVal Value As Integer)
            _MinQty = Value
        End Set
    End Property
    Public Property MaxQty() As Integer
        Get
            Return _MaxQty
        End Get
        Set(ByVal Value As Integer)
            _MaxQty = Value
        End Set
    End Property
    Public Property Blocked() As Boolean
        Get
            Return _Blocked
        End Get
        Set(ByVal Value As Boolean)
            _Blocked = Value
        End Set
    End Property
    Public Property Barcode() As String
        Get
            Return _Barcode
        End Get
        Set(ByVal Value As String)
            _Barcode = Value
        End Set
    End Property
    Public Property WhsCode() As String
        Get
            Return _WhsCode
        End Get
        Set(ByVal Value As String)
            _WhsCode = Value
        End Set
    End Property
#End Region
#Region "Methods"
    Dim da As New SqlDataAdapter
    Function GetItemControl(ByVal WhsCode As String, ByVal ItemAID As Integer, ByVal con As SqlConnection) As DataTable
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("SpIv_GetItemControl", con)
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@ItemAID", ItemAID)
            sqlcomm.Parameters.AddWithValue("@WhsCode", WhsCode)
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
    Public Sub UpdateItemContol(ByVal con As SqlConnection)
        Try
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("SpIv_InsertItemControl", con)
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@WhsCode", _WhsCode)
            sqlcomm.Parameters.AddWithValue("@Barcode", _Barcode)
            sqlcomm.Parameters.AddWithValue("@MinQty", _MinQty)
            sqlcomm.Parameters.AddWithValue("@MaxQty", _MaxQty)
            sqlcomm.Parameters.AddWithValue("@Blocked", _Blocked)
            blnconnectionOpen = ConnStatus(con)
            If Not blnconnectionOpen Then ConnOpen(con)
            sqlcomm.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region
End Class
