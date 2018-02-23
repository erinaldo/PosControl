Imports System.Data.SqlClient
Imports ConnectionSQL
Public Class ThirdExtraSettings
    Public ThirdId As Integer
    Public CollectorId As Object
    Public SalesManId As Object
    Public Stk_ThirdGroupid As Object
    Public Stk_CustCatId As Object
    Public Stk_CustCurCode As Object
    Public Stk_CustPriceCode As Object
    Public Stk_CustSalesList As Object
    Public Stk_CustBlocked As Integer
    Public Stk_CustApplyVat As Integer
    Public Stk_CustDirectPost As Integer
    Public Stk_CustGroupInPosting As Integer
    Public STK_CustMarkUp As Decimal
    Public Stk_CustDisc1 As Decimal
    Public Stk_CustDisc2 As Decimal
    Public Stk_CustRetailCredit As Integer
    Public Stk_CustAppearInRetail As Integer
    Public Stk_CustLimit As Decimal
    Public Stk_CustLimitAllCmp As Integer
    Public Stk_CustLimitAllLedger As Integer
    Public Stk_CustTerms As Integer
    Public Stk_CustDeliver1 As String
    Public Stk_CustDeliver2 As String
    Public Stk_CustDeliver3 As String
    Public Stk_SupCatId As Object
    Public Stk_SupCurCode As Object
    Public Stk_SupPriceCode As Object
    Public Stk_SupDirectPost As Integer
    Public Stk_SupGroupInPosting As Integer
    Public Stk_SupApplyVat As Integer
    Public Stk_Suplimit As Integer
    Public Stk_SupLimitAllCmp As Integer
    Public Stk_SupLimitAllLedger As Integer
    Public Stk_SupTerms As Integer
    Public Stk_SupBlocked As Integer
    Public Stk_SalCatId As Object
    Public Stk_SalCommission As Decimal
    Public Stk_SalSpervisorCom As Decimal
    Public Stk_SalBlocked As Integer
    Public Stk_CustPoints As Integer
    Public BankLimit As Decimal
    Public Stk_PostToThirdid As Object
    Public DeliveryTerms As String
    Public PaymentTerms As String
    Public OperMess As String
    Public collector2id As Integer
End Class
Public Class ClsThirdExtra
#Region "Fields"
    Public _ThirdId As Integer
    Public _CollectorId As Object
    Public _SalesManId As Object
    Public _Stk_ThirdGroupid As Object
    Public _Stk_CustCatId As Object
    Public _Stk_CustCurCode As Object
    Public _Stk_CustPriceCode As Object
    Public _Stk_CustSalesList As Object
    Public _Stk_CustBlocked As Integer
    Public _Stk_CustApplyVat As Integer
    Public _Stk_CustDirectPost As Integer
    Public _Stk_CustGroupInPosting As Integer
    Public _STK_CustMarkUp As Decimal
    Public _Stk_CustDisc1 As Decimal
    Public _Stk_CustDisc2 As Decimal
    Public _Stk_CustRetailCredit As Integer
    Public _Stk_CustAppearInRetail As Integer
    Public _Stk_CustLimit As Decimal
    Public _Stk_CustLimitAllCmp As Integer
    Public _Stk_CustLimitAllLedger As Integer
    Public _Stk_CustTerms As Integer
    Public _Stk_CustDeliver1 As String
    Public _Stk_CustDeliver2 As String
    Public _Stk_CustDeliver3 As String
    Public _Stk_SupCatId As Object
    Public _Stk_SupCurCode As Object
    Public _Stk_SupPriceCode As Object
    Public _Stk_SupDirectPost As Integer
    Public _Stk_SupGroupInPosting As Integer
    Public _Stk_SupApplyVat As Integer
    Public _Stk_Suplimit As Integer
    Public _Stk_SupLimitAllCmp As Integer
    Public _Stk_SupLimitAllLedger As Integer
    Public _Stk_SupTerms As Integer
    Public _Stk_SupBlocked As Integer
    Public _Stk_SalCatId As Object
    Public _Stk_SalCommission As Decimal
    Public _Stk_SalSpervisorCom As Decimal
    Public _Stk_SalBlocked As Integer
    Public _Stk_CustPoints As Integer
    Public _BankLimit As Decimal
    Public _Stk_PostToThirdid As Object
    Public _DeliveryTerms As String
    Public _PaymentTerms As String
    Public _OperMess As String
    Public _collector2id As Object
#End Region
#Region "Properties"
    Public Property ThirdId() As Integer
        Get
            Return _ThirdId
        End Get
        Set(ByVal Value As Integer)
            _ThirdId = Value
        End Set
    End Property
    Public Property CollectorId() As Integer
        Get
            Return _CollectorId
        End Get
        Set(ByVal Value As Integer)
            _CollectorId = Value
        End Set
    End Property
    Public Property Collector2ID() As Integer
        Get
            Return _collector2id
        End Get
        Set(ByVal Value As Integer)
            _collector2id = Value
        End Set
    End Property
    Public Property SalesManId() As Integer
        Get
            Return _SalesManId
        End Get
        Set(ByVal Value As Integer)
            _SalesManId = Value
        End Set
    End Property
    Public Property Stk_ThirdGroupid() As Integer
        Get
            Return _Stk_ThirdGroupid
        End Get
        Set(ByVal Value As Integer)
            _Stk_ThirdGroupid = Value
        End Set
    End Property
    Public Property Stk_CustCatId() As Integer
        Get
            Return _Stk_CustCatId
        End Get
        Set(ByVal Value As Integer)
            _Stk_CustCatId = Value
        End Set
    End Property
    Public Property Stk_CustCurCode() As String
        Get
            Return _Stk_CustCurCode
        End Get
        Set(ByVal Value As String)
            _Stk_CustCurCode = Value
        End Set
    End Property
    Public Property Stk_CustPriceCode() As String
        Get
            Return _Stk_CustPriceCode
        End Get
        Set(ByVal Value As String)
            _Stk_CustPriceCode = Value
        End Set
    End Property
    Public Property Stk_CustSalesList() As String
        Get
            Return _Stk_CustSalesList
        End Get
        Set(ByVal Value As String)
            _Stk_CustSalesList = Value
        End Set
    End Property
    Public Property Stk_CustBlocked() As Integer
        Get
            Return _Stk_CustBlocked
        End Get
        Set(ByVal Value As Integer)
            _Stk_CustBlocked = Value
        End Set
    End Property
    Public Property Stk_CustApplyVat() As Integer
        Get
            Return _Stk_CustApplyVat
        End Get
        Set(ByVal Value As Integer)
            _Stk_CustApplyVat = Value
        End Set
    End Property
    Public Property Stk_CustDirectPost() As Integer
        Get
            Return _Stk_CustDirectPost
        End Get
        Set(ByVal Value As Integer)
            _Stk_CustDirectPost = Value
        End Set
    End Property
    Public Property Stk_CustGroupInPosting() As Integer
        Get
            Return _Stk_CustGroupInPosting
        End Get
        Set(ByVal Value As Integer)
            _Stk_CustGroupInPosting = Value
        End Set
    End Property
    Public Property STK_CustMarkUp() As Decimal
        Get
            Return _STK_CustMarkUp
        End Get
        Set(ByVal Value As Decimal)
            _STK_CustMarkUp = Value
        End Set
    End Property
    Public Property Stk_CustDisc1() As Decimal
        Get
            Return _Stk_CustDisc1
        End Get
        Set(ByVal Value As Decimal)
            _Stk_CustDisc1 = Value
        End Set
    End Property
    Public Property Stk_CustDisc2() As Decimal
        Get
            Return _Stk_CustDisc2
        End Get
        Set(ByVal Value As Decimal)
            _Stk_CustDisc2 = Value
        End Set
    End Property
    Public Property Stk_CustRetailCredit() As Integer
        Get
            Return _Stk_CustRetailCredit
        End Get
        Set(ByVal Value As Integer)
            _Stk_CustRetailCredit = Value
        End Set
    End Property
    Public Property Stk_CustAppearInRetail() As Integer
        Get
            Return _Stk_CustAppearInRetail
        End Get
        Set(ByVal Value As Integer)
            _Stk_CustAppearInRetail = Value
        End Set
    End Property
    Public Property Stk_CustLimit() As Integer
        Get
            Return _Stk_CustLimit
        End Get
        Set(ByVal Value As Integer)
            _Stk_CustLimit = Value
        End Set
    End Property
    Public Property Stk_CustLimitAllCmp() As Integer
        Get
            Return _Stk_CustLimitAllCmp
        End Get
        Set(ByVal Value As Integer)
            _Stk_CustLimitAllCmp = Value
        End Set
    End Property
    Public Property Stk_CustLimitAllLedger() As Integer
        Get
            Return _Stk_CustLimitAllLedger
        End Get
        Set(ByVal Value As Integer)
            _Stk_CustLimitAllLedger = Value
        End Set
    End Property
    Public Property Stk_CustTerms() As Integer
        Get
            Return _Stk_CustTerms
        End Get
        Set(ByVal Value As Integer)
            _Stk_CustTerms = Value
        End Set
    End Property
    Public Property Stk_CustDeliver1() As String
        Get
            Return _Stk_CustDeliver1
        End Get
        Set(ByVal Value As String)
            _Stk_CustDeliver1 = Value
        End Set
    End Property
    Public Property Stk_CustDeliver2() As String
        Get
            Return _Stk_CustDeliver2
        End Get
        Set(ByVal Value As String)
            _Stk_CustDeliver2 = Value
        End Set
    End Property
    Public Property Stk_CustDeliver3() As String
        Get
            Return _Stk_CustDeliver3
        End Get
        Set(ByVal Value As String)
            _Stk_CustDeliver3 = Value
        End Set
    End Property
    Public Property Stk_SupCatId() As Integer
        Get
            Return _Stk_SupCatId
        End Get
        Set(ByVal Value As Integer)
            _Stk_SupCatId = Value
        End Set
    End Property
    Public Property Stk_SupCurCode() As String
        Get
            Return _Stk_SupCurCode
        End Get
        Set(ByVal Value As String)
            _Stk_SupCurCode = Value
        End Set
    End Property
    Public Property Stk_SupPriceCode() As String
        Get
            Return _Stk_SupPriceCode
        End Get
        Set(ByVal Value As String)
            _Stk_SupPriceCode = Value
        End Set
    End Property
    Public Property Stk_SupDirectPost() As Integer
        Get
            Return _Stk_SupDirectPost
        End Get
        Set(ByVal Value As Integer)
            _Stk_SupDirectPost = Value
        End Set
    End Property
    Public Property Stk_SupGroupInPosting() As Integer
        Get
            Return _Stk_SupGroupInPosting
        End Get
        Set(ByVal Value As Integer)
            _Stk_SupGroupInPosting = Value
        End Set
    End Property
    Public Property Stk_SupApplyVat() As Integer
        Get
            Return _Stk_SupApplyVat
        End Get
        Set(ByVal Value As Integer)
            _Stk_SupApplyVat = Value
        End Set
    End Property
    Public Property Stk_Suplimit() As Integer
        Get
            Return _Stk_Suplimit
        End Get
        Set(ByVal Value As Integer)
            _Stk_Suplimit = Value
        End Set
    End Property
    Public Property Stk_SupLimitAllCmp() As Integer
        Get
            Return _Stk_SupLimitAllCmp
        End Get
        Set(ByVal Value As Integer)
            _Stk_SupLimitAllCmp = Value
        End Set
    End Property
    Public Property Stk_SupLimitAllLedger() As Integer
        Get
            Return _Stk_SupLimitAllLedger
        End Get
        Set(ByVal Value As Integer)
            _Stk_SupLimitAllLedger = Value
        End Set
    End Property
    Public Property Stk_SupTerms() As Integer
        Get
            Return _Stk_SupTerms
        End Get
        Set(ByVal Value As Integer)
            _Stk_SupTerms = Value
        End Set
    End Property
    Public Property Stk_SupBlocked() As Integer
        Get
            Return _Stk_SupBlocked
        End Get
        Set(ByVal Value As Integer)
            _Stk_SupBlocked = Value
        End Set
    End Property
    Public Property Stk_SalCatId() As Integer
        Get
            Return Stk_SalCatId
        End Get
        Set(ByVal Value As Integer)
            _Stk_SalCatId = Value
        End Set
    End Property
    Public Property Stk_SalCommission() As Decimal
        Get
            Return _Stk_SalCommission
        End Get
        Set(ByVal Value As Decimal)
            _Stk_SalCommission = Value
        End Set
    End Property
    Public Property Stk_SalSpervisorCom() As Decimal
        Get
            Return _Stk_SalSpervisorCom
        End Get
        Set(ByVal Value As Decimal)
            _Stk_SalSpervisorCom = Value
        End Set
    End Property
    Public Property Stk_SalBlocked() As Integer
        Get
            Return _Stk_SalBlocked
        End Get
        Set(ByVal Value As Integer)
            _Stk_SalBlocked = Value
        End Set
    End Property
    Public Property Stk_CustPoints() As Integer
        Get
            Return _Stk_CustPoints
        End Get
        Set(ByVal Value As Integer)
            _Stk_CustPoints = Value
        End Set
    End Property
    Public Property BankLimit() As Decimal
        Get
            Return _BankLimit
        End Get
        Set(ByVal Value As Decimal)
            _BankLimit = Value
        End Set
    End Property
    Public Property Stk_PostToThirdid() As Integer
        Get
            Return _Stk_PostToThirdid
        End Get
        Set(ByVal Value As Integer)
            _Stk_PostToThirdid = Value
        End Set
    End Property
    Public Property DeliveryTerms() As String
        Get
            Return _DeliveryTerms
        End Get
        Set(ByVal Value As String)
            _DeliveryTerms = Value
        End Set
    End Property
    Public Property PaymentTerms() As String
        Get
            Return _PaymentTerms
        End Get
        Set(ByVal Value As String)
            _PaymentTerms = Value
        End Set
    End Property
    Public Property OperMess() As String
        Get
            Return _OperMess
        End Get
        Set(ByVal Value As String)
            _OperMess = Value
        End Set
    End Property
#End Region
#Region "Methods"
    Public Sub ThirdExtraInsert(ByVal Con As SqlConnection)
        Try
            Dim blnconnectionOpen As Boolean = False
            Dim Sqlcom As New SqlCommand("Sp_ThirdExtraInsert", Con)
            Sqlcom.CommandType = CommandType.StoredProcedure
            Sqlcom.Parameters.AddWithValue("@ThirdId", IIf(IsNothing(_ThirdId) Or IsDBNull(_ThirdId), DBNull.Value, _ThirdId))
            Sqlcom.Parameters.AddWithValue("@CollectorId", IIf(IsNothing(_CollectorId) Or IsDBNull(_CollectorId), DBNull.Value, _CollectorId))
            Sqlcom.Parameters.AddWithValue("@SalesManId", IIf(IsNothing(_SalesManId) Or IsDBNull(_SalesManId), DBNull.Value, _SalesManId))
            Sqlcom.Parameters.AddWithValue("@Stk_ThirdGroupid", IIf(IsNothing(_Stk_ThirdGroupid) Or IsDBNull(_Stk_ThirdGroupid), DBNull.Value, _Stk_ThirdGroupid))
            Sqlcom.Parameters.AddWithValue("@Stk_CustCatId", IIf(IsNothing(_Stk_CustCatId) Or IsDBNull(_Stk_CustCatId), DBNull.Value, _Stk_CustCatId))
            Sqlcom.Parameters.AddWithValue("@Stk_CustCurCode", IIf(IsNothing(_Stk_CustCurCode) Or IsDBNull(_Stk_CustCurCode), DBNull.Value, _Stk_CustCurCode))
            Sqlcom.Parameters.AddWithValue("@Stk_CustPriceCode", IIf(IsNothing(_Stk_CustPriceCode) Or IsDBNull(_Stk_CustPriceCode), DBNull.Value, _Stk_CustPriceCode))
            Sqlcom.Parameters.AddWithValue("@Stk_CustSalesList", IIf(IsNothing(_Stk_CustSalesList) Or IsDBNull(_Stk_CustSalesList), DBNull.Value, _Stk_CustSalesList))
            Sqlcom.Parameters.AddWithValue("@Stk_CustBlocked", IIf(IsNothing(_Stk_CustBlocked) Or IsDBNull(_Stk_CustBlocked), DBNull.Value, _Stk_CustBlocked))
            Sqlcom.Parameters.AddWithValue("@Stk_CustApplyVat", IIf(IsNothing(_Stk_CustApplyVat) Or IsDBNull(_Stk_CustApplyVat), DBNull.Value, _Stk_CustApplyVat))
            Sqlcom.Parameters.AddWithValue("@Stk_CustDirectPost", IIf(IsNothing(_Stk_CustDirectPost) Or IsDBNull(_Stk_CustDirectPost), DBNull.Value, _Stk_CustDirectPost))
            Sqlcom.Parameters.AddWithValue("@Stk_CustGroupInPosting", IIf(IsNothing(_Stk_CustGroupInPosting) Or IsDBNull(_Stk_CustGroupInPosting), DBNull.Value, _Stk_CustGroupInPosting))
            Sqlcom.Parameters.AddWithValue("@STK_CustMarkUp", IIf(IsNothing(_STK_CustMarkUp) Or IsDBNull(_STK_CustMarkUp), DBNull.Value, _STK_CustMarkUp))
            Sqlcom.Parameters.AddWithValue("@Stk_CustDisc1", IIf(IsNothing(_Stk_CustDisc1) Or IsDBNull(_Stk_CustDisc1), DBNull.Value, _Stk_CustDisc1))
            Sqlcom.Parameters.AddWithValue("@Stk_CustDisc2", IIf(IsNothing(_Stk_CustDisc2) Or IsDBNull(_Stk_CustDisc2), DBNull.Value, _Stk_CustDisc2))
            Sqlcom.Parameters.AddWithValue("@Stk_CustRetailCredit", IIf(IsNothing(_Stk_CustRetailCredit) Or IsDBNull(_Stk_CustRetailCredit), DBNull.Value, _Stk_CustRetailCredit))
            Sqlcom.Parameters.AddWithValue("@Stk_CustAppearInRetail", IIf(IsNothing(_Stk_CustAppearInRetail) Or IsDBNull(_Stk_CustAppearInRetail), DBNull.Value, _Stk_CustAppearInRetail))
            Sqlcom.Parameters.AddWithValue("@Stk_CustLimit", IIf(IsNothing(_Stk_CustLimit) Or IsDBNull(_Stk_CustLimit), DBNull.Value, _Stk_CustLimit))
            Sqlcom.Parameters.AddWithValue("@Stk_CustLimitAllCmp", IIf(IsNothing(_Stk_CustLimitAllCmp) Or IsDBNull(_Stk_CustLimitAllCmp), DBNull.Value, _Stk_CustLimitAllCmp))
            Sqlcom.Parameters.AddWithValue("@Stk_CustLimitAllLedger", IIf(IsNothing(_Stk_CustLimitAllLedger) Or IsDBNull(_Stk_CustLimitAllLedger), DBNull.Value, _Stk_CustLimitAllLedger))
            Sqlcom.Parameters.AddWithValue("@Stk_CustTerms", IIf(IsNothing(_Stk_CustTerms) Or IsDBNull(_Stk_CustTerms), DBNull.Value, _Stk_CustTerms))
            Sqlcom.Parameters.AddWithValue("@Stk_CustDeliver1", IIf(IsNothing(_Stk_CustDeliver1) Or IsDBNull(_Stk_CustDeliver1), DBNull.Value, _Stk_CustDeliver1))
            Sqlcom.Parameters.AddWithValue("@Stk_CustDeliver2", IIf(IsNothing(_Stk_CustDeliver2) Or IsDBNull(_Stk_CustDeliver2), DBNull.Value, _Stk_CustDeliver2))
            Sqlcom.Parameters.AddWithValue("@Stk_CustDeliver3", IIf(IsNothing(_Stk_CustDeliver3) Or IsDBNull(_Stk_CustDeliver3), DBNull.Value, _Stk_CustDeliver3))
            Sqlcom.Parameters.AddWithValue("@Stk_SupCatId", IIf(IsNothing(_Stk_SupCatId) Or IsDBNull(_Stk_SupCatId), DBNull.Value, _Stk_SupCatId))
            Sqlcom.Parameters.AddWithValue("@Stk_SupCurCode", IIf(IsNothing(_Stk_SupCurCode) Or IsDBNull(_Stk_SupCurCode), DBNull.Value, _Stk_SupCurCode))
            Sqlcom.Parameters.AddWithValue("@Stk_SupPriceCode", IIf(IsNothing(_Stk_SupPriceCode) Or IsDBNull(_Stk_SupPriceCode), DBNull.Value, _Stk_SupPriceCode))
            Sqlcom.Parameters.AddWithValue("@Stk_SupDirectPost", IIf(IsNothing(_Stk_SupDirectPost) Or IsDBNull(_Stk_SupDirectPost), DBNull.Value, _Stk_SupDirectPost))
            Sqlcom.Parameters.AddWithValue("@Stk_SupGroupInPosting", IIf(IsNothing(_Stk_SupGroupInPosting) Or IsDBNull(_Stk_SupGroupInPosting), DBNull.Value, _Stk_SupGroupInPosting))
            Sqlcom.Parameters.AddWithValue("@Stk_SupApplyVat", IIf(IsNothing(_Stk_SupApplyVat) Or IsDBNull(_Stk_SupApplyVat), DBNull.Value, _Stk_SupApplyVat))
            Sqlcom.Parameters.AddWithValue("@Stk_Suplimit", IIf(IsNothing(_Stk_Suplimit) Or IsDBNull(_Stk_Suplimit), DBNull.Value, _Stk_Suplimit))
            Sqlcom.Parameters.AddWithValue("@Stk_SupLimitAllCmp", IIf(IsNothing(_Stk_SupLimitAllCmp) Or IsDBNull(_Stk_SupLimitAllCmp), DBNull.Value, _Stk_SupLimitAllCmp))
            Sqlcom.Parameters.AddWithValue("@Stk_SupLimitAllLedger", IIf(IsNothing(_Stk_SupLimitAllLedger) Or IsDBNull(_Stk_SupLimitAllLedger), DBNull.Value, _Stk_SupLimitAllLedger))
            Sqlcom.Parameters.AddWithValue("@Stk_SupTerms", IIf(IsNothing(_Stk_SupTerms) Or IsDBNull(_Stk_SupTerms), DBNull.Value, _Stk_SupTerms))
            Sqlcom.Parameters.AddWithValue("@Stk_SupBlocked", IIf(IsNothing(_Stk_SupBlocked) Or IsDBNull(_Stk_SupBlocked), DBNull.Value, _Stk_SupBlocked))
            Sqlcom.Parameters.AddWithValue("@Stk_SalCatId", IIf(IsNothing(_Stk_SalCatId) Or IsDBNull(_Stk_SalCatId), DBNull.Value, _Stk_SalCatId))
            Sqlcom.Parameters.AddWithValue("@Stk_SalCommission", IIf(IsNothing(_Stk_SalCommission) Or IsDBNull(_Stk_SalCommission), DBNull.Value, _Stk_SalCommission))
            Sqlcom.Parameters.AddWithValue("@Stk_SalSpervisorCom", IIf(IsNothing(_Stk_SalSpervisorCom) Or IsDBNull(_Stk_SalSpervisorCom), DBNull.Value, _Stk_SalSpervisorCom))
            Sqlcom.Parameters.AddWithValue("@Stk_SalBlocked", IIf(IsNothing(_Stk_SalBlocked) Or IsDBNull(_Stk_SalBlocked), DBNull.Value, _Stk_SalBlocked))
            Sqlcom.Parameters.AddWithValue("@Stk_CustPoints", IIf(IsNothing(_Stk_CustPoints) Or IsDBNull(_Stk_CustPoints), DBNull.Value, _Stk_CustPoints))
            Sqlcom.Parameters.AddWithValue("@BankLimit", 0)
            Sqlcom.Parameters.AddWithValue("@Stk_PostToThirdid", IIf(IsNothing(_Stk_PostToThirdid) Or IsDBNull(_Stk_PostToThirdid), DBNull.Value, _Stk_PostToThirdid))
            Sqlcom.Parameters.AddWithValue("@DeliveryTerms", IIf(IsNothing(_DeliveryTerms) Or IsDBNull(_DeliveryTerms), DBNull.Value, _DeliveryTerms))
            Sqlcom.Parameters.AddWithValue("@PaymentTerms", IIf(IsNothing(_PaymentTerms) Or IsDBNull(_PaymentTerms), DBNull.Value, _PaymentTerms))
            Sqlcom.Parameters.AddWithValue("@OperMess", IIf(IsNothing(_OperMess) Or IsDBNull(_OperMess), DBNull.Value, _OperMess))
            Sqlcom.Parameters.AddWithValue("@collector2id", IIf(IsNothing(_collector2id) Or IsDBNull(_collector2id), DBNull.Value, _collector2id))
            blnconnectionOpen = ConnStatus(Con)
            If Not blnconnectionOpen Then ConnOpen(Con)
            Sqlcom.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub ThirdExtraUpdate(ByVal Con As SqlConnection)
        Try
            Dim blnconnectionOpen As Boolean = False
            Dim Sqlcom As New SqlCommand("Sp_ThirdExtraUpdate", Con)
            Sqlcom.CommandType = CommandType.StoredProcedure
            Sqlcom.Parameters.AddWithValue("@ThirdId", IIf(IsNothing(_ThirdId) Or IsDBNull(_ThirdId), DBNull.Value, _ThirdId))
            Sqlcom.Parameters.AddWithValue("@CollectorId", IIf(IsNothing(_CollectorId) Or IsDBNull(_CollectorId), DBNull.Value, _CollectorId))
            Sqlcom.Parameters.AddWithValue("@SalesManId", IIf(IsNothing(_SalesManId) Or IsDBNull(_SalesManId), DBNull.Value, _SalesManId))
            Sqlcom.Parameters.AddWithValue("@Stk_ThirdGroupid", IIf(IsNothing(_Stk_ThirdGroupid) Or IsDBNull(_Stk_ThirdGroupid), DBNull.Value, _Stk_ThirdGroupid))
            Sqlcom.Parameters.AddWithValue("@Stk_CustCatId", IIf(IsNothing(_Stk_CustCatId) Or IsDBNull(_Stk_CustCatId), DBNull.Value, _Stk_CustCatId))
            Sqlcom.Parameters.AddWithValue("@Stk_CustCurCode", IIf(IsNothing(_Stk_CustCurCode) Or IsDBNull(_Stk_CustCurCode), DBNull.Value, _Stk_CustCurCode))
            Sqlcom.Parameters.AddWithValue("@Stk_CustPriceCode", IIf(IsNothing(_Stk_CustPriceCode) Or IsDBNull(_Stk_CustPriceCode), DBNull.Value, _Stk_CustPriceCode))
            Sqlcom.Parameters.AddWithValue("@Stk_CustSalesList", IIf(IsNothing(_Stk_CustSalesList) Or IsDBNull(_Stk_CustSalesList), DBNull.Value, _Stk_CustSalesList))
            Sqlcom.Parameters.AddWithValue("@Stk_CustBlocked", IIf(IsNothing(_Stk_CustBlocked) Or IsDBNull(_Stk_CustBlocked), DBNull.Value, _Stk_CustBlocked))
            Sqlcom.Parameters.AddWithValue("@Stk_CustApplyVat", IIf(IsNothing(_Stk_CustApplyVat) Or IsDBNull(_Stk_CustApplyVat), DBNull.Value, _Stk_CustApplyVat))
            Sqlcom.Parameters.AddWithValue("@Stk_CustDirectPost", IIf(IsNothing(_Stk_CustDirectPost) Or IsDBNull(_Stk_CustDirectPost), DBNull.Value, _Stk_CustDirectPost))
            Sqlcom.Parameters.AddWithValue("@Stk_CustGroupInPosting", IIf(IsNothing(_Stk_CustGroupInPosting) Or IsDBNull(_Stk_CustGroupInPosting), DBNull.Value, _Stk_CustGroupInPosting))
            Sqlcom.Parameters.AddWithValue("@STK_CustMarkUp", IIf(IsNothing(_STK_CustMarkUp) Or IsDBNull(_STK_CustMarkUp), DBNull.Value, _STK_CustMarkUp))
            Sqlcom.Parameters.AddWithValue("@Stk_CustDisc1", IIf(IsNothing(_Stk_CustDisc1) Or IsDBNull(_Stk_CustDisc1), DBNull.Value, _Stk_CustDisc1))
            Sqlcom.Parameters.AddWithValue("@Stk_CustDisc2", IIf(IsNothing(_Stk_CustDisc2) Or IsDBNull(_Stk_CustDisc2), DBNull.Value, _Stk_CustDisc2))
            Sqlcom.Parameters.AddWithValue("@Stk_CustRetailCredit", IIf(IsNothing(_Stk_CustRetailCredit) Or IsDBNull(_Stk_CustRetailCredit), DBNull.Value, _Stk_CustRetailCredit))
            Sqlcom.Parameters.AddWithValue("@Stk_CustAppearInRetail", IIf(IsNothing(_Stk_CustAppearInRetail) Or IsDBNull(_Stk_CustAppearInRetail), DBNull.Value, _Stk_CustAppearInRetail))
            Sqlcom.Parameters.AddWithValue("@Stk_CustLimit", IIf(IsNothing(_Stk_CustLimit) Or IsDBNull(_Stk_CustLimit), DBNull.Value, _Stk_CustLimit))
            Sqlcom.Parameters.AddWithValue("@Stk_CustLimitAllCmp", IIf(IsNothing(_Stk_CustLimitAllCmp) Or IsDBNull(_Stk_CustLimitAllCmp), DBNull.Value, _Stk_CustLimitAllCmp))
            Sqlcom.Parameters.AddWithValue("@Stk_CustLimitAllLedger", IIf(IsNothing(_Stk_CustLimitAllLedger) Or IsDBNull(_Stk_CustLimitAllLedger), DBNull.Value, _Stk_CustLimitAllLedger))
            Sqlcom.Parameters.AddWithValue("@Stk_CustTerms", IIf(IsNothing(_Stk_CustTerms) Or IsDBNull(_Stk_CustTerms), DBNull.Value, _Stk_CustTerms))
            Sqlcom.Parameters.AddWithValue("@Stk_CustDeliver1", IIf(IsNothing(_Stk_CustDeliver1) Or IsDBNull(_Stk_CustDeliver1), DBNull.Value, _Stk_CustDeliver1))
            Sqlcom.Parameters.AddWithValue("@Stk_CustDeliver2", IIf(IsNothing(_Stk_CustDeliver2) Or IsDBNull(_Stk_CustDeliver2), DBNull.Value, _Stk_CustDeliver2))
            Sqlcom.Parameters.AddWithValue("@Stk_CustDeliver3", IIf(IsNothing(_Stk_CustDeliver3) Or IsDBNull(_Stk_CustDeliver3), DBNull.Value, _Stk_CustDeliver3))
            Sqlcom.Parameters.AddWithValue("@Stk_SupCatId", IIf(IsNothing(_Stk_SupCatId) Or IsDBNull(_Stk_SupCatId), DBNull.Value, _Stk_SupCatId))
            Sqlcom.Parameters.AddWithValue("@Stk_SupCurCode", IIf(IsNothing(_Stk_SupCurCode) Or IsDBNull(_Stk_SupCurCode), DBNull.Value, _Stk_SupCurCode))
            Sqlcom.Parameters.AddWithValue("@Stk_SupPriceCode", IIf(IsNothing(_Stk_SupPriceCode) Or IsDBNull(_Stk_SupPriceCode), DBNull.Value, _Stk_SupPriceCode))
            Sqlcom.Parameters.AddWithValue("@Stk_SupDirectPost", IIf(IsNothing(_Stk_SupDirectPost) Or IsDBNull(_Stk_SupDirectPost), DBNull.Value, _Stk_SupDirectPost))
            Sqlcom.Parameters.AddWithValue("@Stk_SupGroupInPosting", IIf(IsNothing(_Stk_SupGroupInPosting) Or IsDBNull(_Stk_SupGroupInPosting), DBNull.Value, _Stk_SupGroupInPosting))
            Sqlcom.Parameters.AddWithValue("@Stk_SupApplyVat", IIf(IsNothing(_Stk_SupApplyVat) Or IsDBNull(_Stk_SupApplyVat), DBNull.Value, _Stk_SupApplyVat))
            Sqlcom.Parameters.AddWithValue("@Stk_Suplimit", IIf(IsNothing(_Stk_Suplimit) Or IsDBNull(_Stk_Suplimit), DBNull.Value, _Stk_Suplimit))
            Sqlcom.Parameters.AddWithValue("@Stk_SupLimitAllCmp", IIf(IsNothing(_Stk_SupLimitAllCmp) Or IsDBNull(_Stk_SupLimitAllCmp), DBNull.Value, _Stk_SupLimitAllCmp))
            Sqlcom.Parameters.AddWithValue("@Stk_SupLimitAllLedger", IIf(IsNothing(_Stk_SupLimitAllLedger) Or IsDBNull(_Stk_SupLimitAllLedger), DBNull.Value, _Stk_SupLimitAllLedger))
            Sqlcom.Parameters.AddWithValue("@Stk_SupTerms", IIf(IsNothing(_Stk_SupTerms) Or IsDBNull(_Stk_SupTerms), DBNull.Value, _Stk_SupTerms))
            Sqlcom.Parameters.AddWithValue("@Stk_SupBlocked", IIf(IsNothing(_Stk_SupBlocked) Or IsDBNull(_Stk_SupBlocked), DBNull.Value, _Stk_SupBlocked))
            Sqlcom.Parameters.AddWithValue("@Stk_SalCatId", IIf(IsNothing(_Stk_SalCatId) Or IsDBNull(_Stk_SalCatId), DBNull.Value, _Stk_SalCatId))
            Sqlcom.Parameters.AddWithValue("@Stk_SalCommission", IIf(IsNothing(_Stk_SalCommission) Or IsDBNull(_Stk_SalCommission), DBNull.Value, _Stk_SalCommission))
            Sqlcom.Parameters.AddWithValue("@Stk_SalSpervisorCom", IIf(IsNothing(_Stk_SalSpervisorCom) Or IsDBNull(_Stk_SalSpervisorCom), DBNull.Value, _Stk_SalSpervisorCom))
            Sqlcom.Parameters.AddWithValue("@Stk_SalBlocked", IIf(IsNothing(_Stk_SalBlocked) Or IsDBNull(_Stk_SalBlocked), DBNull.Value, _Stk_SalBlocked))
            Sqlcom.Parameters.AddWithValue("@Stk_CustPoints", IIf(IsNothing(_Stk_CustPoints) Or IsDBNull(_Stk_CustPoints), DBNull.Value, _Stk_CustPoints))
            Sqlcom.Parameters.AddWithValue("@BankLimit", 0)
            Sqlcom.Parameters.AddWithValue("@Stk_PostToThirdid", IIf(IsNothing(_Stk_PostToThirdid) Or IsDBNull(_Stk_PostToThirdid), DBNull.Value, _Stk_PostToThirdid))
            Sqlcom.Parameters.AddWithValue("@DeliveryTerms", IIf(IsNothing(_DeliveryTerms) Or IsDBNull(_DeliveryTerms), DBNull.Value, _DeliveryTerms))
            Sqlcom.Parameters.AddWithValue("@PaymentTerms", IIf(IsNothing(_PaymentTerms) Or IsDBNull(_PaymentTerms), DBNull.Value, _PaymentTerms))
            Sqlcom.Parameters.AddWithValue("@OperMess", IIf(IsNothing(_OperMess) Or IsDBNull(_OperMess), DBNull.Value, _OperMess))
            Sqlcom.Parameters.AddWithValue("@collector2id", IIf(IsNothing(_collector2id) Or IsDBNull(_collector2id), DBNull.Value, _collector2id))
            blnconnectionOpen = ConnStatus(Con)
            If Not blnconnectionOpen Then ConnOpen(Con)
            Sqlcom.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub ThirdExtraBoToPOS(ByVal Con As SqlConnection)
        Try
            Dim blnconnectionOpen As Boolean = False
            Dim Sqlcom As New SqlCommand("Sp_ThirdExtraBoToPos", Con)
            Sqlcom.CommandType = CommandType.StoredProcedure
            Sqlcom.Parameters.AddWithValue("@ThirdId", IIf(IsNothing(_ThirdId) Or IsDBNull(_ThirdId), DBNull.Value, _ThirdId))
            Sqlcom.Parameters.AddWithValue("@CollectorId", IIf(IsNothing(_CollectorId) Or IsDBNull(_CollectorId), DBNull.Value, _CollectorId))
            Sqlcom.Parameters.AddWithValue("@SalesManId", IIf(IsNothing(_SalesManId) Or IsDBNull(_SalesManId), DBNull.Value, _SalesManId))
            Sqlcom.Parameters.AddWithValue("@Stk_ThirdGroupid", IIf(IsNothing(_Stk_ThirdGroupid) Or IsDBNull(_Stk_ThirdGroupid), DBNull.Value, _Stk_ThirdGroupid))
            Sqlcom.Parameters.AddWithValue("@Stk_CustCatId", IIf(IsNothing(_Stk_CustCatId) Or IsDBNull(_Stk_CustCatId), DBNull.Value, _Stk_CustCatId))
            Sqlcom.Parameters.AddWithValue("@Stk_CustCurCode", IIf(IsNothing(_Stk_CustCurCode) Or IsDBNull(_Stk_CustCurCode), DBNull.Value, _Stk_CustCurCode))
            Sqlcom.Parameters.AddWithValue("@Stk_CustPriceCode", IIf(IsNothing(_Stk_CustPriceCode) Or IsDBNull(_Stk_CustPriceCode), DBNull.Value, _Stk_CustPriceCode))
            Sqlcom.Parameters.AddWithValue("@Stk_CustSalesList", IIf(IsNothing(_Stk_CustSalesList) Or IsDBNull(_Stk_CustSalesList), DBNull.Value, _Stk_CustSalesList))
            Sqlcom.Parameters.AddWithValue("@Stk_CustBlocked", IIf(IsNothing(_Stk_CustBlocked) Or IsDBNull(_Stk_CustBlocked), DBNull.Value, _Stk_CustBlocked))
            Sqlcom.Parameters.AddWithValue("@Stk_CustApplyVat", IIf(IsNothing(_Stk_CustApplyVat) Or IsDBNull(_Stk_CustApplyVat), DBNull.Value, _Stk_CustApplyVat))
            Sqlcom.Parameters.AddWithValue("@Stk_CustDirectPost", IIf(IsNothing(_Stk_CustDirectPost) Or IsDBNull(_Stk_CustDirectPost), DBNull.Value, _Stk_CustDirectPost))
            Sqlcom.Parameters.AddWithValue("@Stk_CustGroupInPosting", IIf(IsNothing(_Stk_CustGroupInPosting) Or IsDBNull(_Stk_CustGroupInPosting), DBNull.Value, _Stk_CustGroupInPosting))
            Sqlcom.Parameters.AddWithValue("@STK_CustMarkUp", IIf(IsNothing(_STK_CustMarkUp) Or IsDBNull(_STK_CustMarkUp), DBNull.Value, _STK_CustMarkUp))
            Sqlcom.Parameters.AddWithValue("@Stk_CustDisc1", IIf(IsNothing(_Stk_CustDisc1) Or IsDBNull(_Stk_CustDisc1), DBNull.Value, _Stk_CustDisc1))
            Sqlcom.Parameters.AddWithValue("@Stk_CustDisc2", IIf(IsNothing(_Stk_CustDisc2) Or IsDBNull(_Stk_CustDisc2), DBNull.Value, _Stk_CustDisc2))
            Sqlcom.Parameters.AddWithValue("@Stk_CustRetailCredit", IIf(IsNothing(_Stk_CustRetailCredit) Or IsDBNull(_Stk_CustRetailCredit), DBNull.Value, _Stk_CustRetailCredit))
            Sqlcom.Parameters.AddWithValue("@Stk_CustAppearInRetail", IIf(IsNothing(_Stk_CustAppearInRetail) Or IsDBNull(_Stk_CustAppearInRetail), DBNull.Value, _Stk_CustAppearInRetail))
            Sqlcom.Parameters.AddWithValue("@Stk_CustLimit", IIf(IsNothing(_Stk_CustLimit) Or IsDBNull(_Stk_CustLimit), DBNull.Value, _Stk_CustLimit))
            Sqlcom.Parameters.AddWithValue("@Stk_CustLimitAllCmp", IIf(IsNothing(_Stk_CustLimitAllCmp) Or IsDBNull(_Stk_CustLimitAllCmp), DBNull.Value, _Stk_CustLimitAllCmp))
            Sqlcom.Parameters.AddWithValue("@Stk_CustLimitAllLedger", IIf(IsNothing(_Stk_CustLimitAllLedger) Or IsDBNull(_Stk_CustLimitAllLedger), DBNull.Value, _Stk_CustLimitAllLedger))
            Sqlcom.Parameters.AddWithValue("@Stk_CustTerms", IIf(IsNothing(_Stk_CustTerms) Or IsDBNull(_Stk_CustTerms), DBNull.Value, _Stk_CustTerms))
            Sqlcom.Parameters.AddWithValue("@Stk_CustDeliver1", IIf(IsNothing(_Stk_CustDeliver1) Or IsDBNull(_Stk_CustDeliver1), DBNull.Value, _Stk_CustDeliver1))
            Sqlcom.Parameters.AddWithValue("@Stk_CustDeliver2", IIf(IsNothing(_Stk_CustDeliver2) Or IsDBNull(_Stk_CustDeliver2), DBNull.Value, _Stk_CustDeliver2))
            Sqlcom.Parameters.AddWithValue("@Stk_CustDeliver3", IIf(IsNothing(_Stk_CustDeliver3) Or IsDBNull(_Stk_CustDeliver3), DBNull.Value, _Stk_CustDeliver3))
            Sqlcom.Parameters.AddWithValue("@Stk_SupCatId", IIf(IsNothing(_Stk_SupCatId) Or IsDBNull(_Stk_SupCatId), DBNull.Value, _Stk_SupCatId))
            Sqlcom.Parameters.AddWithValue("@Stk_SupCurCode", IIf(IsNothing(_Stk_SupCurCode) Or IsDBNull(_Stk_SupCurCode), DBNull.Value, _Stk_SupCurCode))
            Sqlcom.Parameters.AddWithValue("@Stk_SupPriceCode", IIf(IsNothing(_Stk_SupPriceCode) Or IsDBNull(_Stk_SupPriceCode), DBNull.Value, _Stk_SupPriceCode))
            Sqlcom.Parameters.AddWithValue("@Stk_SupDirectPost", IIf(IsNothing(_Stk_SupDirectPost) Or IsDBNull(_Stk_SupDirectPost), DBNull.Value, _Stk_SupDirectPost))
            Sqlcom.Parameters.AddWithValue("@Stk_SupGroupInPosting", IIf(IsNothing(_Stk_SupGroupInPosting) Or IsDBNull(_Stk_SupGroupInPosting), DBNull.Value, _Stk_SupGroupInPosting))
            Sqlcom.Parameters.AddWithValue("@Stk_SupApplyVat", IIf(IsNothing(_Stk_SupApplyVat) Or IsDBNull(_Stk_SupApplyVat), DBNull.Value, _Stk_SupApplyVat))
            Sqlcom.Parameters.AddWithValue("@Stk_Suplimit", IIf(IsNothing(_Stk_Suplimit) Or IsDBNull(_Stk_Suplimit), DBNull.Value, _Stk_Suplimit))
            Sqlcom.Parameters.AddWithValue("@Stk_SupLimitAllCmp", IIf(IsNothing(_Stk_SupLimitAllCmp) Or IsDBNull(_Stk_SupLimitAllCmp), DBNull.Value, _Stk_SupLimitAllCmp))
            Sqlcom.Parameters.AddWithValue("@Stk_SupLimitAllLedger", IIf(IsNothing(_Stk_SupLimitAllLedger) Or IsDBNull(_Stk_SupLimitAllLedger), DBNull.Value, _Stk_SupLimitAllLedger))
            Sqlcom.Parameters.AddWithValue("@Stk_SupTerms", IIf(IsNothing(_Stk_SupTerms) Or IsDBNull(_Stk_SupTerms), DBNull.Value, _Stk_SupTerms))
            Sqlcom.Parameters.AddWithValue("@Stk_SupBlocked", IIf(IsNothing(_Stk_SupBlocked) Or IsDBNull(_Stk_SupBlocked), DBNull.Value, _Stk_SupBlocked))
            Sqlcom.Parameters.AddWithValue("@Stk_SalCatId", IIf(IsNothing(_Stk_SalCatId) Or IsDBNull(_Stk_SalCatId), DBNull.Value, _Stk_SalCatId))
            Sqlcom.Parameters.AddWithValue("@Stk_SalCommission", IIf(IsNothing(_Stk_SalCommission) Or IsDBNull(_Stk_SalCommission), DBNull.Value, _Stk_SalCommission))
            Sqlcom.Parameters.AddWithValue("@Stk_SalSpervisorCom", IIf(IsNothing(_Stk_SalSpervisorCom) Or IsDBNull(_Stk_SalSpervisorCom), DBNull.Value, _Stk_SalSpervisorCom))
            Sqlcom.Parameters.AddWithValue("@Stk_SalBlocked", IIf(IsNothing(_Stk_SalBlocked) Or IsDBNull(_Stk_SalBlocked), DBNull.Value, _Stk_SalBlocked))
            Sqlcom.Parameters.AddWithValue("@Stk_CustPoints", IIf(IsNothing(_Stk_CustPoints) Or IsDBNull(_Stk_CustPoints), DBNull.Value, _Stk_CustPoints))
            Sqlcom.Parameters.AddWithValue("@BankLimit", 0)
            Sqlcom.Parameters.AddWithValue("@Stk_PostToThirdid", IIf(IsNothing(_Stk_PostToThirdid) Or IsDBNull(_Stk_PostToThirdid), DBNull.Value, _Stk_PostToThirdid))
            Sqlcom.Parameters.AddWithValue("@DeliveryTerms", IIf(IsNothing(_DeliveryTerms) Or IsDBNull(_DeliveryTerms), DBNull.Value, _DeliveryTerms))
            Sqlcom.Parameters.AddWithValue("@PaymentTerms", IIf(IsNothing(_PaymentTerms) Or IsDBNull(_PaymentTerms), DBNull.Value, _PaymentTerms))
            Sqlcom.Parameters.AddWithValue("@OperMess", IIf(IsNothing(_OperMess) Or IsDBNull(_OperMess), DBNull.Value, _OperMess))
            Sqlcom.Parameters.AddWithValue("@collector2id", IIf(IsNothing(_collector2id) Or IsDBNull(_collector2id), DBNull.Value, _collector2id))
            blnconnectionOpen = ConnStatus(Con)
            If Not blnconnectionOpen Then ConnOpen(Con)
            Sqlcom.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region
End Class
