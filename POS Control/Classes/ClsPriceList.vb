Imports System.Data.SqlClient
Imports ConnectionSQL
Public Class ClsPriceList
#Region "Fields"
    Public _ListCode As Object
    Public _ItemAid As Integer
    Public _ItemBid As Integer
    Public _DiscPct As Object
    Public _Price As Object
    Public _PromoPrice As Object
    Public _Iuser As Object
    Public _Idate As Object
    Public _Uuser As Object
    Public _Udate As Object
    Public _LastTonPrice As Object
    Public _LastMargin As Object
    Public _PriceBuiltOn As Object
    Public _Changed As Integer
#End Region
#Region "Properties"
    Public Property ListCode() As String
        Get
            Return _ListCode
        End Get
        Set(ByVal Value As String)
            _ListCode = Value
        End Set
    End Property
    Public Property ItemAid() As Integer
        Get
            Return _ItemAid
        End Get
        Set(ByVal Value As Integer)
            _ItemAid = Value
        End Set
    End Property
    Public Property ItemBid() As Integer
        Get
            Return _ItemBid
        End Get
        Set(ByVal Value As Integer)
            _ItemBid = Value
        End Set
    End Property
    Public Property DiscPct() As Double
        Get
            Return _DiscPct
        End Get
        Set(ByVal Value As Double)
            _DiscPct = Value
        End Set
    End Property
    Public Property Price() As Double
        Get
            Return _Price
        End Get
        Set(ByVal Value As Double)
            _Price = Value
        End Set
    End Property
    Public Property PromoPrice() As Double
        Get
            Return _PromoPrice
        End Get
        Set(ByVal Value As Double)
            _PromoPrice = Value
        End Set
    End Property
    Public Property Iuser() As String
        Get
            Return _Iuser
        End Get
        Set(ByVal Value As String)
            _Iuser = Value
        End Set
    End Property
    Public Property Uuser() As String
        Get
            Return _Uuser
        End Get
        Set(ByVal Value As String)
            _Uuser = Value
        End Set
    End Property
    Public Property idate() As DateTime
        Get
            Return _idate
        End Get
        Set(ByVal Value As DateTime)
            _idate = Value
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
    Public Property LastTonPrice() As Double
        Get
            Return _LastTonPrice
        End Get
        Set(ByVal Value As Double)
            _LastTonPrice = Value
        End Set
    End Property
    Public Property LastMargin() As Double
        Get
            Return _LastMargin
        End Get
        Set(ByVal Value As Double)
            _LastMargin = Value
        End Set
    End Property
    Public Property PriceBuiltOn() As Double
        Get
            Return _PriceBuiltOn
        End Get
        Set(ByVal Value As Double)
            _PriceBuiltOn = Value
        End Set
    End Property
    Public Property Changed() As Double
        Get
            Return _Changed
        End Get
        Set(ByVal Value As Double)
            _Changed = Value
        End Set
    End Property
#End Region
    Dim da As New SqlDataAdapter
#Region "Methods"
    Function GetPriceList(ByVal con As SqlConnection) As DataTable
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("Select ListCode,Description from IvPriceList1Es ", con)
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
    Public Function GetChangedPriceList(ByVal PlStamp As String, ByVal PriceList As String, ByVal con As SqlConnection) As DataTable
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("SpIv_BoGetPriceListChanged", con)
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@Pricelist", PriceList)
            sqlcomm.Parameters.AddWithValue("@PrStamp", PlStamp)
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
    Public Sub InsertToPriceList(ByVal con As SqlConnection)
        Try
            Dim blnconnectionOpen As Boolean
            Dim Sqlcom As New SqlCommand("SpIv_BoInsertToPriceList", con)
            Sqlcom.CommandType = CommandType.StoredProcedure
            Sqlcom.Parameters.AddWithValue("@ListCode", IIf(IsNothing(_ListCode) Or IsDBNull(_ListCode), DBNull.Value, _ListCode))
            Sqlcom.Parameters.AddWithValue("@ItemAid", IIf(IsNothing(_ItemAid) Or IsDBNull(_ItemAid), DBNull.Value, _ItemAid))
            Sqlcom.Parameters.AddWithValue("@ItemBid", IIf(IsNothing(_ItemBid) Or IsDBNull(_ItemBid), DBNull.Value, _ItemBid))
            Sqlcom.Parameters.AddWithValue("@DiscPct", IIf(IsNothing(_DiscPct) Or IsDBNull(_DiscPct), DBNull.Value, _DiscPct))
            Sqlcom.Parameters.AddWithValue("@Price", IIf(IsNothing(_Price) Or IsDBNull(_Price), DBNull.Value, _Price))
            Sqlcom.Parameters.AddWithValue("@PromoPrice", IIf(IsNothing(_PromoPrice) Or IsDBNull(_PromoPrice), DBNull.Value, _PromoPrice))
            Sqlcom.Parameters.AddWithValue("@Iuser", IIf(IsNothing(_Iuser) Or IsDBNull(_Iuser), DBNull.Value, _Iuser))
            Sqlcom.Parameters.AddWithValue("@Idate", IIf(IsNothing(_Idate) Or IsDBNull(_Idate), DBNull.Value, _Idate))
            Sqlcom.Parameters.AddWithValue("@Uuser", IIf(IsNothing(_Uuser) Or IsDBNull(_Uuser), DBNull.Value, _Uuser))
            Sqlcom.Parameters.AddWithValue("@Udate", IIf(IsNothing(_Udate) Or IsDBNull(_Udate), DBNull.Value, _Udate))
            Sqlcom.Parameters.AddWithValue("@LastTonPrice", IIf(IsNothing(_LastTonPrice) Or IsDBNull(_LastTonPrice), DBNull.Value, _LastTonPrice))
            Sqlcom.Parameters.AddWithValue("@LastMargin", IIf(IsNothing(_LastMargin) Or IsDBNull(_LastMargin), DBNull.Value, _LastMargin))
            Sqlcom.Parameters.AddWithValue("@PriceBuiltOn", IIf(IsNothing(_PriceBuiltOn) Or IsDBNull(_PriceBuiltOn), DBNull.Value, _PriceBuiltOn))
            Sqlcom.Parameters.AddWithValue("@changed", IIf(IsNothing(_Changed) Or IsDBNull(_Changed), 0, _Changed))
            blnconnectionOpen = ConnStatus(con)
            If Not blnconnectionOpen Then ConnOpen(con)
            Sqlcom.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Function BoInitNewPOSPriceList(ByVal PriceList As String, ByVal con As SqlConnection) As DataTable
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("SpRt_InitNewPosPriceList", con)
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@Pricelist", PriceList)
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