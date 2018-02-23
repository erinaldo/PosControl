Imports System.Data.SqlClient
Imports ConnectionSQL
Public Class ClsItemA
#Region "Fields"
    Public _ItemAid As Integer
    Public _ItemCode As String
    Public _CurCode As String
    Public _ShDescription As String
    Public _Description As String
    Public _AltShDescription As String
    Public _AltDescription As String
    Public _UOMCode As String
    Public _SupplierId As Integer
    Public _CategoryCode As String
    Public _TypeCode As String
    Public _BrandCode As String
    Public _CustomId As Integer
    Public _VatId As Integer
    Public _BaseUom As String
    Public _Factor As Double
    Public _AltUom As String
    Public _ItemAPrice As Double
    Public _ProfitMargin As Double
    Public _MinimQty As Double
    Public _Increase As Double
    Public _AddFinal As Double
    Public _IncluedInBudget As Integer
    Public _Blocked As Integer
    Public _Idle As Integer
    Public _Consignment As Integer
    Public _Discountable As Integer
    Public _KitItem As Integer
    Public _ServiceItem As Integer
    Public _UseLot As Integer
    Public _UseExpiry As Integer
    Public _UseSerial As Integer
    Public _ProtectReservedQty As Integer
    Public _Iuser As String
    Public _IDate As DateTime
    Public _UUser As String
    Public _UDate As DateTime
    Public _PostQty As Double
    Public _AvgCost As Double
    Public _Fl_AvgCost As Double
    Public _Sl_AvgCost As Double
    Public _LastPurch As Double
    Public _Fl_LastPurch As Double
    Public _Sl_LastPurch As Double
    Public _LastUnitCost As Double
    Public _Fl_LastUnitCost As Double
    Public _Sl_LastUnitCost As Double
    Public _AllowSell As Integer
    Public _CostType As Integer
    Public _StartYear As Integer
#End Region
#Region "Properties"
    Public Property ItemAid() As Integer
        Get
            Return _ItemAid
        End Get
        Set(ByVal Value As Integer)
            _ItemAid = Value
        End Set
    End Property
    Public Property ItemCode() As String
        Get
            Return _ItemCode
        End Get
        Set(ByVal Value As String)
            _ItemCode = Value
        End Set
    End Property
    Public Property CurCode() As String
        Get
            Return _CurCode
        End Get
        Set(ByVal Value As String)
            _CurCode = Value
        End Set
    End Property
    Public Property ShDescription() As String
        Get
            Return _ShDescription
        End Get
        Set(ByVal Value As String)
            _ShDescription = Value
        End Set
    End Property
    Public Property Description() As String
        Get
            Return _Description
        End Get
        Set(ByVal Value As String)
            _Description = Value
        End Set
    End Property
    Public Property AltShDescription() As String
        Get
            Return _AltShDescription
        End Get
        Set(ByVal Value As String)
            _AltShDescription = Value
        End Set
    End Property
    Public Property AltDescription() As String
        Get
            Return _AltDescription
        End Get
        Set(ByVal Value As String)
            _AltDescription = Value
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
    Public Property SupplierId() As Integer
        Get
            Return _SupplierId
        End Get
        Set(ByVal Value As Integer)
            _SupplierId = Value
        End Set
    End Property
    Public Property CategoryCode() As String
        Get
            Return _CategoryCode
        End Get
        Set(ByVal Value As String)
            _CategoryCode = Value
        End Set
    End Property
    Public Property TypeCode() As String
        Get
            Return _TypeCode
        End Get
        Set(ByVal Value As String)
            _TypeCode = Value
        End Set
    End Property
    Public Property BrandCode() As String
        Get
            Return _BrandCode
        End Get
        Set(ByVal Value As String)
            _BrandCode = Value
        End Set
    End Property
    Public Property CustomId() As Integer
        Get
            Return _CustomId
        End Get
        Set(ByVal Value As Integer)
            _CustomId = Value
        End Set
    End Property
    Public Property VatId() As Integer
        Get
            Return _VatId
        End Get
        Set(ByVal Value As Integer)
            _VatId = Value
        End Set
    End Property
    Public Property BaseUom() As String
        Get
            Return _BaseUom
        End Get
        Set(ByVal Value As String)
            _BaseUom = Value
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
    Public Property AltUom() As String
        Get
            Return _AltUom
        End Get
        Set(ByVal Value As String)
            _AltUom = Value
        End Set
    End Property
    Public Property ItemAPrice() As Double
        Get
            Return _ItemAPrice
        End Get
        Set(ByVal Value As Double)
            _ItemAPrice = Value
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
    Public Property MinimQty() As Double
        Get
            Return _MinimQty
        End Get
        Set(ByVal Value As Double)
            _MinimQty = Value
        End Set
    End Property
    Public Property Increase() As Double
        Get
            Return _Increase
        End Get
        Set(ByVal Value As Double)
            _Increase = Value
        End Set
    End Property
    Public Property AddFinal() As Double
        Get
            Return _AddFinal
        End Get
        Set(ByVal Value As Double)
            _AddFinal = Value
        End Set
    End Property
    Public Property IncluedInBudget() As Integer
        Get
            Return _IncluedInBudget
        End Get
        Set(ByVal Value As Integer)
            _IncluedInBudget = Value
        End Set
    End Property
    Public Property Blocked() As Integer
        Get
            Return _Blocked
        End Get
        Set(ByVal Value As Integer)
            _Blocked = Value
        End Set
    End Property
    Public Property Idle() As Integer
        Get
            Return _Idle
        End Get
        Set(ByVal Value As Integer)
            _Idle = Value
        End Set
    End Property
    Public Property Consignment() As Integer
        Get
            Return _Consignment
        End Get
        Set(ByVal Value As Integer)
            _Consignment = Value
        End Set
    End Property
    Public Property Discountable() As Integer
        Get
            Return _Discountable
        End Get
        Set(ByVal Value As Integer)
            _Discountable = Value
        End Set
    End Property
    Public Property KitItem() As Integer
        Get
            Return _KitItem
        End Get
        Set(ByVal Value As Integer)
            _KitItem = Value
        End Set
    End Property
    Public Property ServiceItem() As Integer
        Get
            Return _ServiceItem
        End Get
        Set(ByVal Value As Integer)
            _ServiceItem = Value
        End Set
    End Property
    Public Property UseLot() As Integer
        Get
            Return _UseLot
        End Get
        Set(ByVal Value As Integer)
            _UseLot = Value
        End Set
    End Property
    Public Property UseExpiry() As Integer
        Get
            Return _UseExpiry
        End Get
        Set(ByVal Value As Integer)
            _UseExpiry = Value
        End Set
    End Property
    Public Property UseSerial() As Integer
        Get
            Return _UseSerial
        End Get
        Set(ByVal Value As Integer)
            _UseSerial = Value
        End Set
    End Property
    Public Property ProtectReservedQty() As Integer
        Get
            Return _ProtectReservedQty
        End Get
        Set(ByVal Value As Integer)
            _ProtectReservedQty = Value
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
    Public Property IDate() As DateTime
        Get
            Return _IDate
        End Get
        Set(ByVal Value As DateTime)
            _IDate = Value
        End Set
    End Property
    Public Property UDate() As DateTime
        Get
            Return _UDate
        End Get
        Set(ByVal Value As DateTime)
            _UDate = Value
        End Set
    End Property
    Public Property Uuser() As String
        Get
            Return _UUser
        End Get
        Set(ByVal Value As String)
            _UUser = Value
        End Set
    End Property
    Public Property PostQty() As Double
        Get
            Return _PostQty
        End Get
        Set(ByVal Value As Double)
            _PostQty = Value
        End Set
    End Property
    Public Property AvgCost() As Double
        Get
            Return _AvgCost
        End Get
        Set(ByVal Value As Double)
            _AvgCost = Value
        End Set
    End Property
    Public Property Fl_AvgCost() As Double
        Get
            Return _Fl_AvgCost
        End Get
        Set(ByVal Value As Double)
            _Fl_AvgCost = Value
        End Set
    End Property
    Public Property Sl_AvgCost() As Double
        Get
            Return _Sl_AvgCost
        End Get
        Set(ByVal Value As Double)
            _Sl_AvgCost = Value
        End Set
    End Property
    Public Property LastPurch() As Double
        Get
            Return _LastPurch
        End Get
        Set(ByVal Value As Double)
            _LastPurch = Value
        End Set
    End Property
    Public Property Fl_LastPurch() As Double
        Get
            Return _Fl_LastPurch
        End Get
        Set(ByVal Value As Double)
            _Fl_LastPurch = Value
        End Set
    End Property
    Public Property Sl_LastPurch() As Double
        Get
            Return _Sl_LastPurch
        End Get
        Set(ByVal Value As Double)
            _Sl_LastPurch = Value
        End Set
    End Property
    Public Property LastUnitCost() As Double
        Get
            Return _LastUnitCost
        End Get
        Set(ByVal Value As Double)
            _LastUnitCost = Value
        End Set
    End Property
    Public Property Fl_LastUnitCost() As Double
        Get
            Return _Fl_LastUnitCost
        End Get
        Set(ByVal Value As Double)
            _Fl_LastUnitCost = Value
        End Set
    End Property
    Public Property Sl_LastUnitCost() As Double
        Get
            Return _Sl_LastUnitCost
        End Get
        Set(ByVal Value As Double)
            _Sl_LastUnitCost = Value
        End Set
    End Property
    Public Property AllowSell() As Integer
        Get
            Return _AllowSell
        End Get
        Set(ByVal Value As Integer)
            _AllowSell = Value
        End Set
    End Property
    Public Property CostType() As Integer
        Get
            Return _CostType
        End Get
        Set(ByVal Value As Integer)
            _CostType = Value
        End Set
    End Property
    Public Property StartYear() As Integer
        Get
            Return _StartYear
        End Get
        Set(ByVal Value As Integer)
            _StartYear = Value
        End Set
    End Property
#End Region
#Region "Methods"
    Dim da As New SqlDataAdapter
    Public Function BoGetNewItems(ByVal tStamp As String, ByVal con As SqlConnection) As DataTable
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("SpIv_BoGetNewItems", con)
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
    Public Sub BoInsertItemA(ByVal con As SqlConnection)
        Try
            Dim blnconnectionOpen As Boolean
            Dim Sqlcom As New SqlCommand("SpIv_BOItemAInsert", con)
            Sqlcom.CommandType = CommandType.StoredProcedure
            Sqlcom.Parameters.AddWithValue("@ItemAid", _ItemAid)
            Sqlcom.Parameters.AddWithValue("@ItemCode", IIf(IsDBNull(_ItemCode) Or IsNothing(_ItemCode) Or _ItemCode = String.Empty, "", _ItemCode))
            Sqlcom.Parameters.AddWithValue("@CurCode", IIf(IsDBNull(_CurCode) Or IsNothing(_CurCode) Or _CurCode = String.Empty, "", _CurCode))
            Sqlcom.Parameters.AddWithValue("@ShDescription", IIf(IsDBNull(_ShDescription) Or IsNothing(_ShDescription) Or _ShDescription = String.Empty, "", _ShDescription))
            Sqlcom.Parameters.AddWithValue("@Description", IIf(IsDBNull(_Description) Or IsNothing(_Description) Or _Description = String.Empty, "", _Description))
            Sqlcom.Parameters.AddWithValue("@AltShDescription", IIf(IsDBNull(_AltShDescription) Or IsNothing(_AltShDescription) Or _AltShDescription = String.Empty, "", _AltShDescription))
            Sqlcom.Parameters.AddWithValue("@AltDescription", IIf(IsDBNull(_AltDescription) Or IsNothing(_AltDescription) Or _AltDescription = String.Empty, "", _AltDescription))
            Sqlcom.Parameters.AddWithValue("@UOMCode", IIf(IsDBNull(_UOMCode) Or IsNothing(_UOMCode) Or _UOMCode = String.Empty, "", _UOMCode))
            Sqlcom.Parameters.AddWithValue("@SupplierId", IIf(IsDBNull(_SupplierId) Or IsNothing(_SupplierId), "", _SupplierId))
            Sqlcom.Parameters.AddWithValue("@CategoryCode", IIf(IsDBNull(_CategoryCode) Or IsNothing(_CategoryCode) Or _CategoryCode = String.Empty, "", _CategoryCode))
            Sqlcom.Parameters.AddWithValue("@TypeCode", IIf(IsDBNull(_TypeCode) Or IsNothing(_TypeCode) Or _TypeCode = String.Empty, "", _TypeCode))
            Sqlcom.Parameters.AddWithValue("@BrandCode", IIf(IsDBNull(_BrandCode) Or IsNothing(_BrandCode) Or _BrandCode = String.Empty, "", _BrandCode))
            Sqlcom.Parameters.AddWithValue("@CustomId", IIf(IsDBNull(_CustomId) Or IsNothing(_CustomId), "", _CustomId))
            Sqlcom.Parameters.AddWithValue("@VatId", IIf(IsDBNull(_VatId) Or IsNothing(_VatId), "", _VatId))
            Sqlcom.Parameters.AddWithValue("@BaseUom", IIf(IsDBNull(_BaseUom) Or IsNothing(_BaseUom) Or _BaseUom = String.Empty, "", _BaseUom))
            Sqlcom.Parameters.AddWithValue("@Factor", IIf(IsDBNull(_Factor) Or IsNothing(_Factor), "", _Factor))
            Sqlcom.Parameters.AddWithValue("@AltUom", IIf(IsDBNull(_AltUom) Or IsNothing(_AltUom) Or _AltUom = String.Empty, "", _AltUom))
            Sqlcom.Parameters.AddWithValue("@ItemAPrice", IIf(IsDBNull(_ItemAPrice) Or IsNothing(_ItemAPrice), "", _ItemAPrice))
            Sqlcom.Parameters.AddWithValue("@ProfitMargin", IIf(IsDBNull(_ProfitMargin) Or IsNothing(_ProfitMargin), "", _ProfitMargin))
            Sqlcom.Parameters.AddWithValue("@MinimQty", IIf(IsDBNull(_MinimQty) Or IsNothing(_MinimQty), "", _MinimQty))
            Sqlcom.Parameters.AddWithValue("@Increase", IIf(IsDBNull(_Increase) Or IsNothing(_Increase), "", _Increase))
            Sqlcom.Parameters.AddWithValue("@AddFinal", IIf(IsDBNull(_AddFinal) Or IsNothing(_AddFinal), "", _AddFinal))
            Sqlcom.Parameters.AddWithValue("@IncluedInBudget", IIf(IsDBNull(_IncluedInBudget) Or IsNothing(_IncluedInBudget), "", _IncluedInBudget))
            Sqlcom.Parameters.AddWithValue("@Blocked", IIf(IsDBNull(_Blocked) Or IsNothing(_Blocked), "", _Blocked))
            Sqlcom.Parameters.AddWithValue("@Idle", IIf(IsDBNull(_Idle) Or IsNothing(_Idle), "", _Idle))
            Sqlcom.Parameters.AddWithValue("@Consignment", IIf(IsDBNull(_Consignment) Or IsNothing(_Consignment), "", _Consignment))
            Sqlcom.Parameters.AddWithValue("@Discountable", IIf(IsDBNull(_Discountable) Or IsNothing(_Discountable), "", _Discountable))
            Sqlcom.Parameters.AddWithValue("@KitItem", IIf(IsDBNull(_KitItem) Or IsNothing(_KitItem), "", _KitItem))
            Sqlcom.Parameters.AddWithValue("@ServiceItem", IIf(IsDBNull(_ServiceItem) Or IsNothing(_ServiceItem), "", _ServiceItem))
            Sqlcom.Parameters.AddWithValue("@UseLot", IIf(IsDBNull(_UseLot) Or IsNothing(_UseLot), "", _UseLot))
            Sqlcom.Parameters.AddWithValue("@UseExpiry", IIf(IsDBNull(_UseExpiry) Or IsNothing(_UseExpiry), "", _UseExpiry))
            Sqlcom.Parameters.AddWithValue("@UseSerial", IIf(IsDBNull(_UseSerial) Or IsNothing(_UseSerial), "", _UseSerial))
            Sqlcom.Parameters.AddWithValue("@ProtectReservedQty", IIf(IsDBNull(_ProtectReservedQty) Or IsNothing(_ProtectReservedQty), "", _ProtectReservedQty))
            Sqlcom.Parameters.AddWithValue("@Iuser", IIf(IsDBNull(_Iuser) Or IsNothing(_Iuser) Or _Iuser = String.Empty, "", _Iuser))
            Sqlcom.Parameters.AddWithValue("@IDate", IIf(IsDBNull(_IDate) Or IsNothing(_IDate), Today.Date, _IDate))
            Sqlcom.Parameters.AddWithValue("@uuser", IIf(IsDBNull(_UUser) Or IsNothing(_UUser) Or _UUser = String.Empty, "", _UUser))
            Sqlcom.Parameters.AddWithValue("@uDate", IIf(IsDBNull(_UDate) Or IsNothing(_UDate), Today.Date, _UDate))
            Sqlcom.Parameters.AddWithValue("@PostQty", IIf(IsDBNull(_PostQty) Or IsNothing(_PostQty), "", _PostQty))
            Sqlcom.Parameters.AddWithValue("@AvgCost", IIf(IsDBNull(_AvgCost) Or IsNothing(_AvgCost), "", _AvgCost))
            Sqlcom.Parameters.AddWithValue("@Fl_AvgCost", IIf(IsDBNull(_Fl_AvgCost) Or IsNothing(_Fl_AvgCost), "", _Fl_AvgCost))
            Sqlcom.Parameters.AddWithValue("@Sl_AvgCost", IIf(IsDBNull(_Sl_AvgCost) Or IsNothing(_Sl_AvgCost), "", _Sl_AvgCost))
            Sqlcom.Parameters.AddWithValue("@LastPurch", IIf(IsDBNull(_LastPurch) Or IsNothing(_LastPurch), "", _LastPurch))
            Sqlcom.Parameters.AddWithValue("@Fl_LastPurch", IIf(IsDBNull(_Fl_LastPurch) Or IsNothing(_Fl_LastPurch), "", _Fl_LastPurch))
            Sqlcom.Parameters.AddWithValue("@Sl_LastPurch", IIf(IsDBNull(_Sl_LastPurch) Or IsNothing(_Sl_LastPurch), "", _Sl_LastPurch))
            Sqlcom.Parameters.AddWithValue("@LastUnitCost", IIf(IsDBNull(_LastUnitCost) Or IsNothing(_LastUnitCost), "", _LastUnitCost))
            Sqlcom.Parameters.AddWithValue("@Fl_LastUnitCost", IIf(IsDBNull(_Fl_LastUnitCost) Or IsNothing(_Fl_LastUnitCost), "", _Fl_LastUnitCost))
            Sqlcom.Parameters.AddWithValue("@Sl_LastUnitCost", IIf(IsDBNull(_Sl_LastUnitCost) Or IsNothing(_Sl_LastUnitCost), "", _Sl_LastUnitCost))
            Sqlcom.Parameters.AddWithValue("@AllowSell", IIf(IsDBNull(_AllowSell) Or IsNothing(_AllowSell), "", _AllowSell))
            Sqlcom.Parameters.AddWithValue("@CostType", IIf(IsDBNull(_CostType) Or IsNothing(_CostType), "", _CostType))
            Sqlcom.Parameters.AddWithValue("@StartYear", IIf(IsDBNull(_StartYear) Or IsNothing(_StartYear), "", _StartYear))
            blnconnectionOpen = ConnStatus(con)
            If Not blnconnectionOpen Then ConnOpen(con)
            Sqlcom.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub BoUpdateItemA(ByVal con As SqlConnection)
        Try
            Dim blnconnectionOpen As Boolean
            Dim Sqlcom As New SqlCommand("SpIv_BOItemAInsert", con)
            Sqlcom.CommandType = CommandType.StoredProcedure
            Sqlcom.Parameters.AddWithValue("@ItemAid", _ItemAid)
            Sqlcom.Parameters.AddWithValue("@ItemCode", IIf(IsDBNull(_ItemCode) Or IsNothing(_ItemCode) Or _ItemCode = String.Empty, "", _ItemCode))
            Sqlcom.Parameters.AddWithValue("@CurCode", IIf(IsDBNull(_CurCode) Or IsNothing(_CurCode) Or _CurCode = String.Empty, "", _CurCode))
            Sqlcom.Parameters.AddWithValue("@ShDescription", IIf(IsDBNull(_ShDescription) Or IsNothing(_ShDescription) Or _ShDescription = String.Empty, "", _ShDescription))
            Sqlcom.Parameters.AddWithValue("@Description", IIf(IsDBNull(_Description) Or IsNothing(_Description) Or _Description = String.Empty, "", _Description))
            Sqlcom.Parameters.AddWithValue("@AltShDescription", IIf(IsDBNull(_AltShDescription) Or IsNothing(_AltShDescription) Or _AltShDescription = String.Empty, "", _AltShDescription))
            Sqlcom.Parameters.AddWithValue("@AltDescription", IIf(IsDBNull(_AltDescription) Or IsNothing(_AltDescription) Or _AltDescription = String.Empty, "", _AltDescription))
            Sqlcom.Parameters.AddWithValue("@UOMCode", IIf(IsDBNull(_UOMCode) Or IsNothing(_UOMCode) Or _UOMCode = String.Empty, "", _UOMCode))
            Sqlcom.Parameters.AddWithValue("@SupplierId", IIf(IsDBNull(_SupplierId) Or IsNothing(_SupplierId), "", _SupplierId))
            Sqlcom.Parameters.AddWithValue("@CategoryCode", IIf(IsDBNull(_CategoryCode) Or IsNothing(_CategoryCode) Or _CategoryCode = String.Empty, "", _CategoryCode))
            Sqlcom.Parameters.AddWithValue("@TypeCode", IIf(IsDBNull(_TypeCode) Or IsNothing(_TypeCode) Or _TypeCode = String.Empty, "", _TypeCode))
            Sqlcom.Parameters.AddWithValue("@BrandCode", IIf(IsDBNull(_BrandCode) Or IsNothing(_BrandCode) Or _BrandCode = String.Empty, "", _BrandCode))
            Sqlcom.Parameters.AddWithValue("@CustomId", IIf(IsDBNull(_CustomId) Or IsNothing(_CustomId), "", _CustomId))
            Sqlcom.Parameters.AddWithValue("@VatId", IIf(IsDBNull(_VatId) Or IsNothing(_VatId), "", _VatId))
            Sqlcom.Parameters.AddWithValue("@BaseUom", IIf(IsDBNull(_BaseUom) Or IsNothing(_BaseUom) Or _BaseUom = String.Empty, "", _BaseUom))
            Sqlcom.Parameters.AddWithValue("@Factor", IIf(IsDBNull(_Factor) Or IsNothing(_Factor), "", _Factor))
            Sqlcom.Parameters.AddWithValue("@AltUom", IIf(IsDBNull(_AltUom) Or IsNothing(_AltUom) Or _AltUom = String.Empty, "", _AltUom))
            Sqlcom.Parameters.AddWithValue("@ItemAPrice", IIf(IsDBNull(_ItemAPrice) Or IsNothing(_ItemAPrice), "", _ItemAPrice))
            Sqlcom.Parameters.AddWithValue("@ProfitMargin", IIf(IsDBNull(_ProfitMargin) Or IsNothing(_ProfitMargin), "", _ProfitMargin))
            Sqlcom.Parameters.AddWithValue("@MinimQty", IIf(IsDBNull(_MinimQty) Or IsNothing(_MinimQty), "", _MinimQty))
            Sqlcom.Parameters.AddWithValue("@Increase", IIf(IsDBNull(_Increase) Or IsNothing(_Increase), "", _Increase))
            Sqlcom.Parameters.AddWithValue("@AddFinal", IIf(IsDBNull(_AddFinal) Or IsNothing(_AddFinal), "", _AddFinal))
            Sqlcom.Parameters.AddWithValue("@IncluedInBudget", IIf(IsDBNull(_IncluedInBudget) Or IsNothing(_IncluedInBudget), "", _IncluedInBudget))
            Sqlcom.Parameters.AddWithValue("@Blocked", IIf(IsDBNull(_Blocked) Or IsNothing(_Blocked), "", _Blocked))
            Sqlcom.Parameters.AddWithValue("@Idle", IIf(IsDBNull(_Idle) Or IsNothing(_Idle), "", _Idle))
            Sqlcom.Parameters.AddWithValue("@Consignment", IIf(IsDBNull(_Consignment) Or IsNothing(_Consignment), "", _Consignment))
            Sqlcom.Parameters.AddWithValue("@Discountable", IIf(IsDBNull(_Discountable) Or IsNothing(_Discountable), "", _Discountable))
            Sqlcom.Parameters.AddWithValue("@KitItem", IIf(IsDBNull(_KitItem) Or IsNothing(_KitItem), "", _KitItem))
            Sqlcom.Parameters.AddWithValue("@ServiceItem", IIf(IsDBNull(_ServiceItem) Or IsNothing(_ServiceItem), "", _ServiceItem))
            Sqlcom.Parameters.AddWithValue("@UseLot", IIf(IsDBNull(_UseLot) Or IsNothing(_UseLot), "", _UseLot))
            Sqlcom.Parameters.AddWithValue("@UseExpiry", IIf(IsDBNull(_UseExpiry) Or IsNothing(_UseExpiry), "", _UseExpiry))
            Sqlcom.Parameters.AddWithValue("@UseSerial", IIf(IsDBNull(_UseSerial) Or IsNothing(_UseSerial), "", _UseSerial))
            Sqlcom.Parameters.AddWithValue("@ProtectReservedQty", IIf(IsDBNull(_ProtectReservedQty) Or IsNothing(_ProtectReservedQty), "", _ProtectReservedQty))
            Sqlcom.Parameters.AddWithValue("@Iuser", IIf(IsDBNull(_Iuser) Or IsNothing(_Iuser) Or _Iuser = String.Empty, "", _Iuser))
            Sqlcom.Parameters.AddWithValue("@IDate", IIf(IsDBNull(_IDate) Or IsNothing(_IDate), Today.Date, _IDate))
            Sqlcom.Parameters.AddWithValue("@uuser", IIf(IsDBNull(_UUser) Or IsNothing(_UUser) Or _UUser = String.Empty, "", _UUser))
            Sqlcom.Parameters.AddWithValue("@uDate", IIf(IsDBNull(_UDate) Or IsNothing(_UDate), Today.Date, _UDate))
            Sqlcom.Parameters.AddWithValue("@PostQty", IIf(IsDBNull(_PostQty) Or IsNothing(_PostQty), "", _PostQty))
            Sqlcom.Parameters.AddWithValue("@AvgCost", IIf(IsDBNull(_AvgCost) Or IsNothing(_AvgCost), "", _AvgCost))
            Sqlcom.Parameters.AddWithValue("@Fl_AvgCost", IIf(IsDBNull(_Fl_AvgCost) Or IsNothing(_Fl_AvgCost), "", _Fl_AvgCost))
            Sqlcom.Parameters.AddWithValue("@Sl_AvgCost", IIf(IsDBNull(_Sl_AvgCost) Or IsNothing(_Sl_AvgCost), "", _Sl_AvgCost))
            Sqlcom.Parameters.AddWithValue("@LastPurch", IIf(IsDBNull(_LastPurch) Or IsNothing(_LastPurch), "", _LastPurch))
            Sqlcom.Parameters.AddWithValue("@Fl_LastPurch", IIf(IsDBNull(_Fl_LastPurch) Or IsNothing(_Fl_LastPurch), "", _Fl_LastPurch))
            Sqlcom.Parameters.AddWithValue("@Sl_LastPurch", IIf(IsDBNull(_Sl_LastPurch) Or IsNothing(_Sl_LastPurch), "", _Sl_LastPurch))
            Sqlcom.Parameters.AddWithValue("@LastUnitCost", IIf(IsDBNull(_LastUnitCost) Or IsNothing(_LastUnitCost), "", _LastUnitCost))
            Sqlcom.Parameters.AddWithValue("@Fl_LastUnitCost", IIf(IsDBNull(_Fl_LastUnitCost) Or IsNothing(_Fl_LastUnitCost), "", _Fl_LastUnitCost))
            Sqlcom.Parameters.AddWithValue("@Sl_LastUnitCost", IIf(IsDBNull(_Sl_LastUnitCost) Or IsNothing(_Sl_LastUnitCost), "", _Sl_LastUnitCost))
            Sqlcom.Parameters.AddWithValue("@AllowSell", IIf(IsDBNull(_AllowSell) Or IsNothing(_AllowSell), "", _AllowSell))
            Sqlcom.Parameters.AddWithValue("@CostType", IIf(IsDBNull(_CostType) Or IsNothing(_CostType), "", _CostType))
            Sqlcom.Parameters.AddWithValue("@StartYear", IIf(IsDBNull(_StartYear) Or IsNothing(_StartYear), "", _StartYear))
            blnconnectionOpen = ConnStatus(con)
            If Not blnconnectionOpen Then ConnOpen(con)
            Sqlcom.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Function BoInitNewPosItemsA(ByVal con As SqlConnection) As DataTable
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim SqlQuery = "Select ItemAid,ItemCode,CurCode,ShDescription,Description,AltShDescription,UOMCode,SupplierId,CategoryCode,"
            SqlQuery = SqlQuery & "TypeCode,BrandCode,CustomId,VatId,BaseUOM,Factor,AltUom,ItemAPrice,ProfitMargin,MinimQty,"
            SqlQuery = SqlQuery & "Increase,AddFinal,Blocked,Idle,AllowReturn,AllowSell,NbPages"
            Dim sqlcomm As New SqlCommand("Select * from ivitema1es where AllowSell = 1", con)
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
    Public Function BoInitNewPosItemsB(ByVal con As SqlConnection) As DataTable
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("Select ib.* from IvItemB1ES ib Join IvItemA1es ia on ib.ItemAId = ia.ItemAid where ia.AllowSell = 1", con)
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
    Public Function BoGetItemsQty(ByVal Whscode As String, ByVal con As SqlConnection) As DataTable
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("SpIv_BoGetWhsQty", con)
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("WhsCode", Whscode)
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
    Public Function BoGetNewItemsControl(ByVal WhsCode As String, ByVal con As SqlConnection) As DataTable
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim Sql = "select distinct ib.Barcode from IvItemB1ES ib join IvItemA1ES ia on ia.ItemAID = ib.ItemAID"
            Sql = Sql + " where ia.AllowSell = 1 and  ib.BarCode not in (select ic.BarCode from IvItemControl ic where whscode='"
            Sql = Sql + WhsCode + "')"
            Dim sqlcomm As New SqlCommand(Sql, con)
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
