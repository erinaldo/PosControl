Imports System.Data.SqlClient
Imports ConnectionSQL
Public Class ClsItemB
#Region "Fields"
    Public _ItemBid As Integer
    Public _ItemAId As Integer
    Public _BarCode As String
    Public _SizeCode As String
    Public _ColorCode As String
    Public _UOMCode As String
    Public _Factor As Double
    Public _ItemPrice As Double
    Public _ProfitMargin As Double
    Public _Udate As DateTime
    Public _UUSer As String
#End Region
#Region "Properties"
    Public Property ItemBid() As Integer
        Get
            Return _ItemBid
        End Get
        Set(ByVal Value As Integer)
            _ItemBid = Value
        End Set
    End Property
    Public Property ItemAid() As Integer
        Get
            Return _ItemAId
        End Get
        Set(ByVal Value As Integer)
            _ItemAId = Value
        End Set
    End Property
    Public Property BarCode() As String
        Get
            Return _BarCode
        End Get
        Set(ByVal Value As String)
            _BarCode = Value
        End Set
    End Property
    Public Property SizeCode() As String
        Get
            Return _SizeCode
        End Get
        Set(ByVal Value As String)
            _SizeCode = Value
        End Set
    End Property
    Public Property ColorCode() As String
        Get
            Return _ColorCode
        End Get
        Set(ByVal Value As String)
            _ColorCode = Value
        End Set
    End Property
    Public Property UOMCode() As String
        Get
            Return _UOMCode
        End Get
        Set(ByVal Value As String)
            _UOMCode = Value
        End Set
    End Property
    Public Property Factor() As Double
        Get
            Return _Factor
        End Get
        Set(ByVal Value As Double)
            _Factor = Value
        End Set
    End Property
    Public Property ItemPrice() As Double
        Get
            Return _ItemPrice
        End Get
        Set(ByVal Value As Double)
            _ItemPrice = Value
        End Set
    End Property
    Public Property ProfitMargin() As Double
        Get
            Return _ProfitMargin
        End Get
        Set(ByVal Value As Double)
            _ProfitMargin = Value
        End Set
    End Property
    Public Property UUSer() As String
        Get
            Return _UUSer
        End Get
        Set(ByVal Value As String)
            _UUSer = Value
        End Set
    End Property
    Public Property Udate() As DateTime
        Get
            Return _Udate
        End Get
        Set(ByVal Value As DateTime)
            _Udate = Value
        End Set
    End Property
#End Region
#Region "Methods"
    Dim da As New SqlDataAdapter
    Public Sub BoInsertItemB(ByVal con As SqlConnection)
        Try
            Dim blnconnectionOpen As Boolean
            Dim Sqlcom As New SqlCommand("SpIv_BOItemAInsert", con)
            Sqlcom.CommandType = CommandType.StoredProcedure
            Sqlcom.Parameters.AddWithValue("@ItemAid", _ItemAId)
            Sqlcom.Parameters.AddWithValue("@ItemBid", _ItemBid)
            Sqlcom.Parameters.AddWithValue("@BarCode", IIf(IsDBNull(_BarCode) Or IsNothing(_BarCode) Or _BarCode = String.Empty, "", _BarCode))
            Sqlcom.Parameters.AddWithValue("@SizeCode", IIf(IsDBNull(_SizeCode) Or IsNothing(_SizeCode) Or _SizeCode = String.Empty, "", _SizeCode))
            Sqlcom.Parameters.AddWithValue("@ColorCode", IIf(IsDBNull(_ColorCode) Or IsNothing(_ColorCode) Or _ColorCode = String.Empty, "", _ColorCode))
            Sqlcom.Parameters.AddWithValue("@UOMCode", IIf(IsDBNull(_UOMCode) Or IsNothing(_UOMCode) Or _UOMCode = String.Empty, "", _UOMCode))
            Sqlcom.Parameters.AddWithValue("@Factor", IIf(IsDBNull(_Factor) Or IsNothing(_Factor), 0, _Factor))
            Sqlcom.Parameters.AddWithValue("@UOMCode", IIf(IsDBNull(_UOMCode) Or IsNothing(_UOMCode) Or _UOMCode = String.Empty, "", _UOMCode))
            Sqlcom.Parameters.AddWithValue("@ItemPrice", IIf(IsDBNull(_ItemPrice) Or IsNothing(_ItemPrice), 0, _ItemPrice))
            Sqlcom.Parameters.AddWithValue("@ProfitMargin", IIf(IsDBNull(_ProfitMargin) Or IsNothing(_ProfitMargin), 0, _ProfitMargin))
            Sqlcom.Parameters.AddWithValue("@UUser", IIf(IsDBNull(_UUSer) Or IsNothing(_UUSer) Or _UUSer = String.Empty, "", _UUSer))
            Sqlcom.Parameters.AddWithValue("@uDate", IIf(IsDBNull(_Udate) Or IsNothing(_Udate), Today.Date, _Udate))
            blnconnectionOpen = ConnStatus(con)
            If Not blnconnectionOpen Then ConnOpen(con)
            Sqlcom.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Function BoGetNewItems(ByVal tStamp As String, ByVal con As SqlConnection) As DataTable
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("SpIv_BoGetNewItemsB", con)
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@tstamp", tStamp)
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

#End Region
End Class
