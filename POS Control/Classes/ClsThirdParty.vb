Imports System.Data.SqlClient
Imports ConnectionSQL
Public Class ThirdPartySettings
    Public ThirdId As Integer
    Public Name As String
    Public ShortName As String
    Public Title As String
    Public AltName As String
    Public AltShortName As String
    Public ManualRef As String
    Public CountryId As Object
    Public AreaId As Object
    Public SisterCompany As Boolean
    Public Address As String
    Public Phone1 As String
    Public Phone2 As String
    Public Phone3 As String
    Public Fax As String
    Public POBOX As String
    Public Email As String
    Public Site As String
    Public ShowInPayable As Boolean
    Public ShowInReceivable As Boolean
    Public ShowInEmployee As Boolean
    Public Blocked As Boolean
    Public ContactName As String
    Public ContactMail As String
    Public ContactPhone As String
    Public Notes As String
    Public VatREG As String
    Public iUser As String
    Public idate As DateTime
    Public Uuser As String
    Public Udate As DateTime
    Public address2 As String
    Public address3 As String
    Public address4 As String
    Public address5 As String
    Public ThirdFinNb As String
    Public bank1 As String
    Public bank As String
    Public bank2 As String
    Public bank3 As String
    Public bank4 As String
    Public bank5 As String
    Public bank6 As String
    Public bank7 As String
    Public bank8 As String
    Public bank9 As String
    Public bank10 As String
    Public bank11 As String
    Public Updated As Boolean
End Class
Public Class ClsThirdParty
    Dim da As New SqlDataAdapter
    Public Shared ds As New DataSet
    Public Shared i As Integer
#Region "Fields"
    Public _ThirdId As Integer
    Public _Name As String
    Public _ShortName As String
    Public _Title As String
    Public _AltName As String
    Public _AltShortName As String
    Public _ManualRef As String
    Public _CountryId As Object
    Public _AreaId As Object
    Public _SisterCompany As Boolean
    Public _Address As String
    Public _Phone1 As String
    Public _Phone2 As String
    Public _Phone3 As String
    Public _Fax As String
    Public _POBOX As String
    Public _Email As String
    Public _Site As String
    Public _ShowInPayable As Boolean
    Public _ShowInReceivable As Boolean
    Public _ShowInEmployee As Boolean
    Public _Blocked As Boolean
    Public _ContactName As String
    Public _ContactMail As String
    Public _ContactPhone As String
    Public _Notes As String
    Public _VatREG As String
    Public _iUser As String
    Public _idate As DateTime
    Public _Uuser As String
    Public _Udate As DateTime
    Public _address2 As String
    Public _address3 As String
    Public _address4 As String
    Public _address5 As String
    Public _ThirdFinNb As String
    Public _bank1 As String
    Public _bank As String
    Public _bank2 As String
    Public _bank3 As String
    Public _bank4 As String
    Public _bank5 As String
    Public _bank6 As String
    Public _bank7 As String
    Public _bank8 As String
    Public _bank9 As String
    Public _bank10 As String
    Public _bank11 As String
    Public _Updated As Boolean
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
    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(ByVal Value As String)
            _Name = Value
        End Set
    End Property
    Public Property ShortName() As String
        Get
            Return _ShortName
        End Get
        Set(ByVal Value As String)
            _ShortName = Value
        End Set
    End Property
    Public Property Title() As String
        Get
            Return _Title
        End Get
        Set(ByVal Value As String)
            _Title = Value
        End Set
    End Property
    Public Property AltName() As String
        Get
            Return _AltName
        End Get
        Set(ByVal Value As String)
            _AltName = Value
        End Set
    End Property
    Public Property AltShortName() As String
        Get
            Return _AltShortName
        End Get
        Set(ByVal Value As String)
            _AltShortName = Value
        End Set
    End Property
    Public Property ManualRef() As String
        Get
            Return _ManualRef
        End Get
        Set(ByVal Value As String)
            _ManualRef = Value
        End Set
    End Property
    Public Property CountryId() As Integer
        Get
            Return _CountryId
        End Get
        Set(ByVal Value As Integer)
            _CountryId = Value
        End Set
    End Property
    Public Property AreaId() As Integer
        Get
            Return _AreaId
        End Get
        Set(ByVal Value As Integer)
            _AreaId = Value
        End Set
    End Property
    Public Property SisterCompany() As Boolean
        Get
            Return _SisterCompany
        End Get
        Set(ByVal Value As Boolean)
            _SisterCompany = Value
        End Set
    End Property
    Public Property Address() As String
        Get
            Return _Address
        End Get
        Set(ByVal Value As String)
            _Address = Value
        End Set
    End Property
    Public Property Phone1() As String
        Get
            Return _Phone1
        End Get
        Set(ByVal Value As String)
            _Phone1 = Value
        End Set
    End Property
    Public Property Phone2() As String
        Get
            Return _Phone2
        End Get
        Set(ByVal Value As String)
            _Phone2 = Value
        End Set
    End Property
    Public Property Phone3() As String
        Get
            Return _Phone3
        End Get
        Set(ByVal Value As String)
            _Phone3 = Value
        End Set
    End Property
    Public Property Fax() As String
        Get
            Return _Fax
        End Get
        Set(ByVal Value As String)
            _Fax = Value
        End Set
    End Property
    Public Property POBOX() As String
        Get
            Return _POBOX
        End Get
        Set(ByVal Value As String)
            _POBOX = Value
        End Set
    End Property
    Public Property Email() As String
        Get
            Return _Email
        End Get
        Set(ByVal Value As String)
            _Email = Value
        End Set
    End Property
    Public Property Site() As String
        Get
            Return _Site
        End Get
        Set(ByVal Value As String)
            _Site = Value
        End Set
    End Property
    Public Property ShowInPayable() As Boolean
        Get
            Return _ShowInPayable
        End Get
        Set(ByVal Value As Boolean)
            _ShowInPayable = Value
        End Set
    End Property
    Public Property ShowInReceivable() As Boolean
        Get
            Return _ShowInReceivable
        End Get
        Set(ByVal Value As Boolean)
            _ShowInReceivable = Value
        End Set
    End Property
    Public Property ShowInEmployee() As Boolean
        Get
            Return _ShowInEmployee
        End Get
        Set(ByVal Value As Boolean)
            _ShowInEmployee = Value
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
    Public Property ContactName() As String
        Get
            Return _ContactName
        End Get
        Set(ByVal Value As String)
            _ContactName = Value
        End Set
    End Property
    Public Property ContactMail() As String
        Get
            Return _ContactMail
        End Get
        Set(ByVal Value As String)
            _ContactMail = Value
        End Set
    End Property
    Public Property ContactPhone() As String
        Get
            Return _ContactPhone
        End Get
        Set(ByVal Value As String)
            _ContactPhone = Value
        End Set
    End Property
    Public Property Notes() As String
        Get
            Return _Notes
        End Get
        Set(ByVal Value As String)
            _Notes = Value
        End Set
    End Property
    Public Property VatREG() As String
        Get
            Return _VatREG
        End Get
        Set(ByVal Value As String)
            _VatREG = Value
        End Set
    End Property
    Public Property iUser() As String
        Get
            Return _iUser
        End Get
        Set(ByVal Value As String)
            _iUser = Value
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
    Public Property Uuser() As String
        Get
            Return _Uuser
        End Get
        Set(ByVal Value As String)
            _Uuser = Value
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
    Public Property address2() As String
        Get
            Return _address2
        End Get
        Set(ByVal Value As String)
            _address2 = Value
        End Set
    End Property
    Public Property address3() As String
        Get
            Return _address3
        End Get
        Set(ByVal Value As String)
            _address3 = Value
        End Set
    End Property
    Public Property address4() As String
        Get
            Return _address4
        End Get
        Set(ByVal Value As String)
            _address4 = Value
        End Set
    End Property
    Public Property address5() As String
        Get
            Return _address5
        End Get
        Set(ByVal Value As String)
            _address5 = Value
        End Set
    End Property
    Public Property ThirdFinNb() As String
        Get
            Return _ThirdFinNb
        End Get
        Set(ByVal Value As String)
            _ThirdFinNb = Value
        End Set
    End Property
    Public Property bank1() As String
        Get
            Return _bank1
        End Get
        Set(ByVal Value As String)
            _bank1 = Value
        End Set
    End Property
    Public Property bank() As String
        Get
            Return _bank
        End Get
        Set(ByVal Value As String)
            _bank = Value
        End Set
    End Property
    Public Property bank2() As String
        Get
            Return _bank2
        End Get
        Set(ByVal Value As String)
            _bank2 = Value
        End Set
    End Property
    Public Property bank11() As String
        Get
            Return _bank11
        End Get
        Set(ByVal Value As String)
            _bank11 = Value
        End Set
    End Property
    Public Property bank3() As String
        Get
            Return _bank3
        End Get
        Set(ByVal Value As String)
            _bank3 = Value
        End Set
    End Property
    Public Property bank4() As String
        Get
            Return _bank4
        End Get
        Set(ByVal Value As String)
            _bank4 = Value
        End Set
    End Property
    Public Property bank5() As String
        Get
            Return _bank5
        End Get
        Set(ByVal Value As String)
            _bank5 = Value
        End Set
    End Property
    Public Property bank6() As String
        Get
            Return _bank6
        End Get
        Set(ByVal Value As String)
            _bank6 = Value
        End Set
    End Property
    Public Property bank7() As String
        Get
            Return _bank7
        End Get
        Set(ByVal Value As String)
            _bank7 = Value
        End Set
    End Property
    Public Property bank8() As String
        Get
            Return _bank8
        End Get
        Set(ByVal Value As String)
            _bank8 = Value
        End Set
    End Property
    Public Property bank9() As String
        Get
            Return _bank9
        End Get
        Set(ByVal Value As String)
            _bank9 = Value
        End Set
    End Property
    Public Property bank10() As String
        Get
            Return _bank10
        End Get
        Set(ByVal Value As String)
            _bank10 = Value
        End Set
    End Property
    Public Property Updated() As Boolean
        Get
            Return _Updated
        End Get
        Set(ByVal Value As Boolean)
            _Updated = Value
        End Set
    End Property
#End Region
#Region "Methods"
    Public Sub GetThirdParties(ByVal Con As SqlConnection)
        Dim Query = "select sth.Name,sth.ShortName,sth.Title,sth.ManualRef,sth.ThirdId,sth.AltName,sth.AltShortName,sth.sistercompany,sth.Blocked,sth.Phone1,sth.Phone2"
        Query += ",sth.phone3,sth.address,sth.address2,sth.address3,sth.address4,sth.address5,sth.fax,sth.pobox,sth.email,sth. site,sth.showinreceivable,sth.showinpayable"
        Query += ",sth.showinemployee,sth.contactname,sth.contactphone,sth.contactmail,sth.notes ,sth.countryid,sth.Areaid,sth.VATREG,sth.iuser,sth.idate,sth.uuser"
        Query += ",sth.udate,sth.thirdfinnb,sth.bank,sth.bank1,sth.bank2,sth.bank3,sth.bank4,sth.bank5,sth.bank6,sth.bank7,sth.bank8,sth.bank9,sth.bank10,sth.bank11  from SAcThirdParty sth,SacThirdExtra1Es ste"
        Query += " where stE.Stk_CustAppearInRetail=1 and ste.thirdid=sth.thirdid Order By Name "
        Try
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand(Query, Con)
            da = New SqlDataAdapter(sqlcomm)
            ds.Clear()
            blnconnectionOpen = ConnStatus(Con)
            If Not blnconnectionOpen Then ConnOpen(Con)
            da.Fill(ds, "ThirdParty")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Function GetLastThirdParty(ByRef vErr As String) As ThirdPartySettings
        Try
            Dim ThirdPartySettings As New ThirdPartySettings
            If ds.Tables("ThirdParty").Rows.Count = 0 Then
                ThirdPartySettings = Nothing
                vErr = "No ThirdParty To Load"
                Return ThirdPartySettings
                Exit Function
            End If
            i = ds.Tables("ThirdParty").Rows.Count - 1
            ThirdPartySettings.ThirdId = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ThirdID").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ThirdID").ToString), _
                                    Nothing, CInt(ds.Tables("ThirdParty").Rows(i)("ThirdID").ToString))
            ThirdPartySettings.Name = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Name").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Name").ToString), _
                                   "", ds.Tables("ThirdParty").Rows(i)("Name").ToString)
            ThirdPartySettings.ShortName = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ShortName").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ShortName").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("ShortName").ToString)
            ThirdPartySettings.Title = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Title").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Title").ToString), _
                                     Nothing, ds.Tables("ThirdParty").Rows(i)("Title").ToString)
            ThirdPartySettings.AltName = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("AltName").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("AltName").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("AltName").ToString)
            ThirdPartySettings.AltShortName = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("AltShortName").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("AltShortName").ToString), _
                                    "", ds.Tables("ThirdParty").Rows(i)("AltShortName").ToString)
            ThirdPartySettings.ManualRef = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ManualRef").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ManualRef").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("ManualRef").ToString)
            ThirdPartySettings.CountryId = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("CountryId").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("CountryId").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("CountryId").ToString), _
                                     Nothing, ds.Tables("ThirdParty").Rows(i)("CountryId").ToString)
            ThirdPartySettings.AreaId = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("AreaId").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("AreaId").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("AreaId").ToString), _
                                     Nothing, ds.Tables("ThirdParty").Rows(i)("AreaId").ToString)
            ThirdPartySettings.SisterCompany = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("SisterCompany").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("SisterCompany").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("SisterCompany").ToString), _
                                     False, ds.Tables("ThirdParty").Rows(i)("SisterCompany"))
            ThirdPartySettings.Address = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Address").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Address").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Address").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("Address").ToString)
            ThirdPartySettings.Phone1 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Phone1").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Phone1").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Phone1").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("Phone1").ToString)
            ThirdPartySettings.Phone2 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Phone2").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Phone2").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Phone2").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("Phone2").ToString)
            ThirdPartySettings.Phone3 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Phone3").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Phone3").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Phone3").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("Phone3").ToString)
            ThirdPartySettings.Fax = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Fax").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Fax").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Fax").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("Fax").ToString)
            ThirdPartySettings.POBOX = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("POBOX").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("POBOX").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("POBox").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("POBOX").ToString)
            ThirdPartySettings.Email = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Email").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Email").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Email").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("Email").ToString)
            ThirdPartySettings.Site = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Site").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Site").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Site").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("Site").ToString)
            ThirdPartySettings.ShowInPayable = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ShowInPayable").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ShowInPayable").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ShowInPayable").ToString), _
                                     False, ds.Tables("ThirdParty").Rows(i)("ShowInPayable"))
            ThirdPartySettings.ShowInReceivable = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ShowInReceivable").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ShowInReceivable").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ShowInReceivable").ToString), _
                                    False, ds.Tables("ThirdParty").Rows(i)("ShowInReceivable"))
            ThirdPartySettings.ShowInEmployee = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ShowInEmployee").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ShowInEmployee").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ShowInEmployee").ToString), _
                                     False, ds.Tables("ThirdParty").Rows(i)("ShowInEmployee"))
            ThirdPartySettings.Blocked = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Blocked").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Blocked").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Blocked").ToString), _
                                     False, ds.Tables("ThirdParty").Rows(i)("Blocked"))
            ThirdPartySettings.ContactName = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ContactName").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ContactName").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ContactName").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("ContactName").ToString)
            ThirdPartySettings.ContactMail = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ContactMail").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ContactMail").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ContactMail").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("ContactMail").ToString)
            ThirdPartySettings.ContactPhone = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ContactPhone").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ContactPhone").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ContactPhone").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("ContactPhone").ToString)
            ThirdPartySettings.Notes = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Notes").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Notes").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Notes").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("Notes").ToString)
            ThirdPartySettings.VatREG = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("VatREG").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("VatREG").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("VatREG").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("VatREG").ToString)
            ThirdPartySettings.iUser = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("iUser").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("iUser").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("iUser").ToString), _
                                     FrmLogin.user, ds.Tables("ThirdParty").Rows(i)("iUser").ToString)
            ThirdPartySettings.idate = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("idate").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("idate").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("idate").ToString), _
                                     Today.Date, ds.Tables("ThirdParty").Rows(i)("idate").ToString)
            ThirdPartySettings.Uuser = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Uuser").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Uuser").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Uuser").ToString), _
                                     FrmLogin.user, ds.Tables("ThirdParty").Rows(i)("Uuser").ToString)
            ThirdPartySettings.Udate = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Udate").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Udate").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Udate").ToString), _
                                     Today.Date, ds.Tables("ThirdParty").Rows(i)("Udate").ToString)
            ThirdPartySettings.address2 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("address2").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("address2").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("address2").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("address2").ToString)
            ThirdPartySettings.address3 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("address3").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("address3").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("address3").ToString), _
                                    "", ds.Tables("ThirdParty").Rows(i)("address3").ToString)
            ThirdPartySettings.address4 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("address4").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("address4").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("address4").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("address4").ToString)
            ThirdPartySettings.address5 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("address5").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("address5").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("address5").ToString), _
                                   "", ds.Tables("ThirdParty").Rows(i)("address5").ToString)
            ThirdPartySettings.ThirdFinNb = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ThirdFinNb").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ThirdFinNb").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ThirdFinNb").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("ThirdFinNb").ToString)
            ThirdPartySettings.bank1 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank1").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank1").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank1").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("bank1").ToString)
            ThirdPartySettings.bank = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("bank").ToString)
            ThirdPartySettings.bank2 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank2").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank2").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank2").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("bank2").ToString)
            ThirdPartySettings.bank3 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank3").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank3").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank3").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("bank3").ToString)
            ThirdPartySettings.bank4 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank4").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank4").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank4").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("bank4").ToString)
            ThirdPartySettings.bank5 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank5").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank5").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank5").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("bank5").ToString)
            ThirdPartySettings.bank6 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank6").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank6").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank6").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("bank6").ToString)
            ThirdPartySettings.bank7 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank7").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank7").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank7").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("bank7").ToString)
            ThirdPartySettings.bank8 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank8").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank8").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank8").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("bank8").ToString)
            ThirdPartySettings.bank9 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank9").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank9").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank9").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("bank9").ToString)
            ThirdPartySettings.bank10 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank10").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank10").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank10").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("bank10").ToString)
            ThirdPartySettings.bank11 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank11").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank11").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank11").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("bank11").ToString)
            Return ThirdPartySettings
        Catch ex As Exception
            vErr = ex.Message
        End Try
    End Function
    Public Function GetFirstThirdParty(ByRef vErr As String) As ThirdPartySettings
        Try
            Dim ThirdPartySettings As New ThirdPartySettings
            If ds.Tables("ThirdParty").Rows.Count = 0 Then
                ThirdPartySettings = Nothing
                vErr = "No ThirdParty To Load"
                Return ThirdPartySettings
                Exit Function
            End If
            i = 0
            ThirdPartySettings.ThirdId = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ThirdID").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ThirdID").ToString), _
                                    Nothing, CInt(ds.Tables("ThirdParty").Rows(i)("ThirdID").ToString))
            ThirdPartySettings.Name = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Name").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Name").ToString), _
                                   "", ds.Tables("ThirdParty").Rows(i)("Name").ToString)
            ThirdPartySettings.ShortName = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ShortName").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ShortName").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("ShortName").ToString)
            ThirdPartySettings.Title = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Title").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Title").ToString), _
                                     Nothing, ds.Tables("ThirdParty").Rows(i)("Title").ToString)
            ThirdPartySettings.AltName = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("AltName").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("AltName").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("AltName").ToString)
            ThirdPartySettings.AltShortName = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("AltShortName").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("AltShortName").ToString), _
                                    "", ds.Tables("ThirdParty").Rows(i)("AltShortName").ToString)
            ThirdPartySettings.ManualRef = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ManualRef").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ManualRef").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("ManualRef").ToString)
            ThirdPartySettings.CountryId = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("CountryId").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("CountryId").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("CountryId").ToString), _
                                     Nothing, ds.Tables("ThirdParty").Rows(i)("CountryId").ToString)
            ThirdPartySettings.AreaId = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("AreaId").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("AreaId").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("AreaId").ToString), _
                                     Nothing, ds.Tables("ThirdParty").Rows(i)("AreaId").ToString)
            ThirdPartySettings.SisterCompany = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("SisterCompany").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("SisterCompany").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("SisterCompany").ToString), _
                                     False, ds.Tables("ThirdParty").Rows(i)("SisterCompany"))
            ThirdPartySettings.Address = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Address").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Address").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Address").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("Address").ToString)
            ThirdPartySettings.Phone1 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Phone1").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Phone1").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Phone1").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("Phone1").ToString)
            ThirdPartySettings.Phone2 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Phone2").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Phone2").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Phone2").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("Phone2").ToString)
            ThirdPartySettings.Phone3 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Phone3").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Phone3").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Phone3").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("Phone3").ToString)
            ThirdPartySettings.Fax = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Fax").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Fax").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Fax").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("Fax").ToString)
            ThirdPartySettings.POBOX = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("POBOX").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("POBOX").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("POBox").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("POBOX").ToString)
            ThirdPartySettings.Email = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Email").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Email").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Email").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("Email").ToString)
            ThirdPartySettings.Site = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Site").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Site").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Site").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("Site").ToString)
            ThirdPartySettings.ShowInPayable = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ShowInPayable").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ShowInPayable").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ShowInPayable").ToString), _
                                     False, ds.Tables("ThirdParty").Rows(i)("ShowInPayable"))
            ThirdPartySettings.ShowInReceivable = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ShowInReceivable").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ShowInReceivable").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ShowInReceivable").ToString), _
                                    False, ds.Tables("ThirdParty").Rows(i)("ShowInReceivable"))
            ThirdPartySettings.ShowInEmployee = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ShowInEmployee").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ShowInEmployee").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ShowInEmployee").ToString), _
                                     False, ds.Tables("ThirdParty").Rows(i)("ShowInEmployee"))
            ThirdPartySettings.Blocked = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Blocked").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Blocked").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Blocked").ToString), _
                                     False, ds.Tables("ThirdParty").Rows(i)("Blocked"))
            ThirdPartySettings.ContactName = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ContactName").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ContactName").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ContactName").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("ContactName").ToString)
            ThirdPartySettings.ContactMail = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ContactMail").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ContactMail").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ContactMail").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("ContactMail").ToString)
            ThirdPartySettings.ContactPhone = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ContactPhone").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ContactPhone").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ContactPhone").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("ContactPhone").ToString)
            ThirdPartySettings.Notes = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Notes").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Notes").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Notes").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("Notes").ToString)
            ThirdPartySettings.VatREG = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("VatREG").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("VatREG").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("VatREG").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("VatREG").ToString)
            ThirdPartySettings.iUser = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("iUser").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("iUser").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("iUser").ToString), _
                                     FrmLogin.user, ds.Tables("ThirdParty").Rows(i)("iUser").ToString)
            ThirdPartySettings.idate = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("idate").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("idate").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("idate").ToString), _
                                     Today.Date, ds.Tables("ThirdParty").Rows(i)("idate").ToString)
            ThirdPartySettings.Uuser = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Uuser").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Uuser").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Uuser").ToString), _
                                     FrmLogin.user, ds.Tables("ThirdParty").Rows(i)("Uuser").ToString)
            ThirdPartySettings.Udate = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Udate").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Udate").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Udate").ToString), _
                                     Today.Date, ds.Tables("ThirdParty").Rows(i)("Udate").ToString)
            ThirdPartySettings.address2 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("address2").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("address2").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("address2").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("address2").ToString)
            ThirdPartySettings.address3 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("address3").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("address3").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("address3").ToString), _
                                    "", ds.Tables("ThirdParty").Rows(i)("address3").ToString)
            ThirdPartySettings.address4 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("address4").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("address4").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("address4").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("address4").ToString)
            ThirdPartySettings.address5 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("address5").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("address5").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("address5").ToString), _
                                   "", ds.Tables("ThirdParty").Rows(i)("address5").ToString)
            ThirdPartySettings.ThirdFinNb = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ThirdFinNb").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ThirdFinNb").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ThirdFinNb").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("ThirdFinNb").ToString)
            ThirdPartySettings.bank1 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank1").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank1").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank1").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("bank1").ToString)
            ThirdPartySettings.bank = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("bank").ToString)
            ThirdPartySettings.bank2 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank2").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank2").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank2").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("bank2").ToString)
            ThirdPartySettings.bank3 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank3").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank3").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank3").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("bank3").ToString)
            ThirdPartySettings.bank4 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank4").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank4").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank4").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("bank4").ToString)
            ThirdPartySettings.bank5 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank5").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank5").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank5").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("bank5").ToString)
            ThirdPartySettings.bank6 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank6").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank6").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank6").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("bank6").ToString)
            ThirdPartySettings.bank7 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank7").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank7").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank7").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("bank7").ToString)
            ThirdPartySettings.bank8 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank8").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank8").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank8").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("bank8").ToString)
            ThirdPartySettings.bank9 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank9").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank9").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank9").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("bank9").ToString)
            ThirdPartySettings.bank10 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank10").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank10").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank10").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("bank10").ToString)
            ThirdPartySettings.bank11 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank11").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank11").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank11").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("bank11").ToString)
            Return ThirdPartySettings
        Catch ex As Exception
            vErr = ex.Message
        End Try
    End Function
    Public Function GetNextThirdParty(ByRef vErr As String) As ThirdPartySettings
        Try
            Dim ThirdPartySettings As New ThirdPartySettings
            If ds.Tables("ThirdParty").Rows.Count = 0 Then
                ThirdPartySettings = Nothing
                vErr = "No ThirdParty To Load"
                Return ThirdPartySettings
                Exit Function
            End If
            If (i < ds.Tables("ThirdParty").Rows.Count - 1) Then
                i = i + 1
                ThirdPartySettings.ThirdId = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ThirdID").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ThirdID").ToString), _
                                        Nothing, CInt(ds.Tables("ThirdParty").Rows(i)("ThirdID").ToString))
                ThirdPartySettings.Name = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Name").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Name").ToString), _
                                       "", ds.Tables("ThirdParty").Rows(i)("Name").ToString)
                ThirdPartySettings.ShortName = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ShortName").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ShortName").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("ShortName").ToString)
                ThirdPartySettings.Title = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Title").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Title").ToString), _
                                         Nothing, ds.Tables("ThirdParty").Rows(i)("Title").ToString)
                ThirdPartySettings.AltName = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("AltName").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("AltName").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("AltName").ToString)
                ThirdPartySettings.AltShortName = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("AltShortName").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("AltShortName").ToString), _
                                        "", ds.Tables("ThirdParty").Rows(i)("AltShortName").ToString)
                ThirdPartySettings.ManualRef = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ManualRef").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ManualRef").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("ManualRef").ToString)
                ThirdPartySettings.CountryId = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("CountryId").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("CountryId").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("CountryId").ToString), _
                                         Nothing, ds.Tables("ThirdParty").Rows(i)("CountryId").ToString)
                ThirdPartySettings.AreaId = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("AreaId").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("AreaId").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("AreaId").ToString), _
                                         Nothing, ds.Tables("ThirdParty").Rows(i)("AreaId").ToString)
                ThirdPartySettings.SisterCompany = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("SisterCompany").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("SisterCompany").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("SisterCompany").ToString), _
                                         False, ds.Tables("ThirdParty").Rows(i)("SisterCompany"))
                ThirdPartySettings.Address = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Address").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Address").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Address").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("Address").ToString)
                ThirdPartySettings.Phone1 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Phone1").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Phone1").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Phone1").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("Phone1").ToString)
                ThirdPartySettings.Phone2 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Phone2").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Phone2").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Phone2").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("Phone2").ToString)
                ThirdPartySettings.Phone3 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Phone3").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Phone3").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Phone3").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("Phone3").ToString)
                ThirdPartySettings.Fax = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Fax").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Fax").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Fax").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("Fax").ToString)
                ThirdPartySettings.POBOX = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("POBOX").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("POBOX").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("POBox").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("POBOX").ToString)
                ThirdPartySettings.Email = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Email").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Email").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Email").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("Email").ToString)
                ThirdPartySettings.Site = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Site").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Site").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Site").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("Site").ToString)
                ThirdPartySettings.ShowInPayable = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ShowInPayable").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ShowInPayable").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ShowInPayable").ToString), _
                                         False, ds.Tables("ThirdParty").Rows(i)("ShowInPayable"))
                ThirdPartySettings.ShowInReceivable = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ShowInReceivable").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ShowInReceivable").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ShowInReceivable").ToString), _
                                        False, ds.Tables("ThirdParty").Rows(i)("ShowInReceivable"))
                ThirdPartySettings.ShowInEmployee = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ShowInEmployee").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ShowInEmployee").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ShowInEmployee").ToString), _
                                         False, ds.Tables("ThirdParty").Rows(i)("ShowInEmployee"))
                ThirdPartySettings.Blocked = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Blocked").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Blocked").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Blocked").ToString), _
                                         False, ds.Tables("ThirdParty").Rows(i)("Blocked"))
                ThirdPartySettings.ContactName = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ContactName").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ContactName").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ContactName").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("ContactName").ToString)
                ThirdPartySettings.ContactMail = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ContactMail").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ContactMail").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ContactMail").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("ContactMail").ToString)
                ThirdPartySettings.ContactPhone = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ContactPhone").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ContactPhone").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ContactPhone").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("ContactPhone").ToString)
                ThirdPartySettings.Notes = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Notes").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Notes").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Notes").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("Notes").ToString)
                ThirdPartySettings.VatREG = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("VatREG").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("VatREG").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("VatREG").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("VatREG").ToString)
                ThirdPartySettings.iUser = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("iUser").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("iUser").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("iUser").ToString), _
                                         FrmLogin.user, ds.Tables("ThirdParty").Rows(i)("iUser").ToString)
                ThirdPartySettings.idate = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("idate").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("idate").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("idate").ToString), _
                                         Today.Date, ds.Tables("ThirdParty").Rows(i)("idate").ToString)
                ThirdPartySettings.Uuser = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Uuser").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Uuser").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Uuser").ToString), _
                                         FrmLogin.user, ds.Tables("ThirdParty").Rows(i)("Uuser").ToString)
                ThirdPartySettings.Udate = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Udate").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Udate").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Udate").ToString), _
                                         Today.Date, ds.Tables("ThirdParty").Rows(i)("Udate").ToString)
                ThirdPartySettings.address2 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("address2").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("address2").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("address2").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("address2").ToString)
                ThirdPartySettings.address3 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("address3").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("address3").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("address3").ToString), _
                                        "", ds.Tables("ThirdParty").Rows(i)("address3").ToString)
                ThirdPartySettings.address4 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("address4").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("address4").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("address4").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("address4").ToString)
                ThirdPartySettings.address5 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("address5").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("address5").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("address5").ToString), _
                                       "", ds.Tables("ThirdParty").Rows(i)("address5").ToString)
                ThirdPartySettings.ThirdFinNb = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ThirdFinNb").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ThirdFinNb").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ThirdFinNb").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("ThirdFinNb").ToString)
                ThirdPartySettings.bank1 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank1").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank1").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank1").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("bank1").ToString)
                ThirdPartySettings.bank = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("bank").ToString)
                ThirdPartySettings.bank2 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank2").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank2").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank2").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("bank2").ToString)
                ThirdPartySettings.bank3 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank3").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank3").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank3").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("bank3").ToString)
                ThirdPartySettings.bank4 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank4").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank4").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank4").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("bank4").ToString)
                ThirdPartySettings.bank5 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank5").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank5").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank5").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("bank5").ToString)
                ThirdPartySettings.bank6 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank6").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank6").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank6").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("bank6").ToString)
                ThirdPartySettings.bank7 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank7").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank7").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank7").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("bank7").ToString)
                ThirdPartySettings.bank8 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank8").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank8").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank8").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("bank8").ToString)
                ThirdPartySettings.bank9 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank9").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank9").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank9").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("bank9").ToString)
                ThirdPartySettings.bank10 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank10").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank10").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank10").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("bank10").ToString)
                ThirdPartySettings.bank11 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank11").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank11").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank11").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("bank11").ToString)
                Return ThirdPartySettings
            Else
                ThirdPartySettings.ThirdId = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ThirdID").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ThirdID").ToString), _
                                        Nothing, CInt(ds.Tables("ThirdParty").Rows(i)("ThirdID").ToString))
                ThirdPartySettings.Name = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Name").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Name").ToString), _
                                       "", ds.Tables("ThirdParty").Rows(i)("Name").ToString)
                ThirdPartySettings.ShortName = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ShortName").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ShortName").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("ShortName").ToString)
                ThirdPartySettings.Title = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Title").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Title").ToString), _
                                         Nothing, ds.Tables("ThirdParty").Rows(i)("Title").ToString)
                ThirdPartySettings.AltName = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("AltName").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("AltName").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("AltName").ToString)
                ThirdPartySettings.AltShortName = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("AltShortName").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("AltShortName").ToString), _
                                        "", ds.Tables("ThirdParty").Rows(i)("AltShortName").ToString)
                ThirdPartySettings.ManualRef = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ManualRef").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ManualRef").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("ManualRef").ToString)
                ThirdPartySettings.CountryId = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("CountryId").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("CountryId").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("CountryId").ToString), _
                                         Nothing, ds.Tables("ThirdParty").Rows(i)("CountryId").ToString)
                ThirdPartySettings.AreaId = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("AreaId").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("AreaId").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("AreaId").ToString), _
                                         Nothing, ds.Tables("ThirdParty").Rows(i)("AreaId").ToString)
                ThirdPartySettings.SisterCompany = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("SisterCompany").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("SisterCompany").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("SisterCompany").ToString), _
                                         False, ds.Tables("ThirdParty").Rows(i)("SisterCompany"))
                ThirdPartySettings.Address = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Address").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Address").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Address").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("Address").ToString)
                ThirdPartySettings.Phone1 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Phone1").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Phone1").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Phone1").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("Phone1").ToString)
                ThirdPartySettings.Phone2 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Phone2").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Phone2").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Phone2").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("Phone2").ToString)
                ThirdPartySettings.Phone3 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Phone3").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Phone3").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Phone3").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("Phone3").ToString)
                ThirdPartySettings.Fax = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Fax").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Fax").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Fax").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("Fax").ToString)
                ThirdPartySettings.POBOX = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("POBOX").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("POBOX").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("POBox").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("POBOX").ToString)
                ThirdPartySettings.Email = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Email").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Email").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Email").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("Email").ToString)
                ThirdPartySettings.Site = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Site").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Site").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Site").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("Site").ToString)
                ThirdPartySettings.ShowInPayable = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ShowInPayable").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ShowInPayable").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ShowInPayable").ToString), _
                                         False, ds.Tables("ThirdParty").Rows(i)("ShowInPayable"))
                ThirdPartySettings.ShowInReceivable = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ShowInReceivable").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ShowInReceivable").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ShowInReceivable").ToString), _
                                        False, ds.Tables("ThirdParty").Rows(i)("ShowInReceivable"))
                ThirdPartySettings.ShowInEmployee = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ShowInEmployee").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ShowInEmployee").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ShowInEmployee").ToString), _
                                         False, ds.Tables("ThirdParty").Rows(i)("ShowInEmployee"))
                ThirdPartySettings.Blocked = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Blocked").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Blocked").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Blocked").ToString), _
                                         False, ds.Tables("ThirdParty").Rows(i)("Blocked"))
                ThirdPartySettings.ContactName = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ContactName").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ContactName").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ContactName").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("ContactName").ToString)
                ThirdPartySettings.ContactMail = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ContactMail").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ContactMail").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ContactMail").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("ContactMail").ToString)
                ThirdPartySettings.ContactPhone = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ContactPhone").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ContactPhone").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ContactPhone").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("ContactPhone").ToString)
                ThirdPartySettings.Notes = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Notes").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Notes").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Notes").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("Notes").ToString)
                ThirdPartySettings.VatREG = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("VatREG").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("VatREG").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("VatREG").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("VatREG").ToString)
                ThirdPartySettings.iUser = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("iUser").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("iUser").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("iUser").ToString), _
                                         FrmLogin.user, ds.Tables("ThirdParty").Rows(i)("iUser").ToString)
                ThirdPartySettings.idate = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("idate").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("idate").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("idate").ToString), _
                                         Today.Date, ds.Tables("ThirdParty").Rows(i)("idate").ToString)
                ThirdPartySettings.Uuser = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Uuser").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Uuser").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Uuser").ToString), _
                                         FrmLogin.user, ds.Tables("ThirdParty").Rows(i)("Uuser").ToString)
                ThirdPartySettings.Udate = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Udate").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Udate").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Udate").ToString), _
                                         Today.Date, ds.Tables("ThirdParty").Rows(i)("Udate").ToString)
                ThirdPartySettings.address2 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("address2").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("address2").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("address2").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("address2").ToString)
                ThirdPartySettings.address3 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("address3").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("address3").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("address3").ToString), _
                                        "", ds.Tables("ThirdParty").Rows(i)("address3").ToString)
                ThirdPartySettings.address4 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("address4").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("address4").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("address4").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("address4").ToString)
                ThirdPartySettings.address5 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("address5").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("address5").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("address5").ToString), _
                                       "", ds.Tables("ThirdParty").Rows(i)("address5").ToString)
                ThirdPartySettings.ThirdFinNb = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ThirdFinNb").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ThirdFinNb").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ThirdFinNb").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("ThirdFinNb").ToString)
                ThirdPartySettings.bank1 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank1").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank1").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank1").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("bank1").ToString)
                ThirdPartySettings.bank = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("bank").ToString)
                ThirdPartySettings.bank2 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank2").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank2").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank2").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("bank2").ToString)
                ThirdPartySettings.bank3 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank3").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank3").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank3").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("bank3").ToString)
                ThirdPartySettings.bank4 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank4").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank4").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank4").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("bank4").ToString)
                ThirdPartySettings.bank5 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank5").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank5").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank5").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("bank5").ToString)
                ThirdPartySettings.bank6 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank6").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank6").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank6").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("bank6").ToString)
                ThirdPartySettings.bank7 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank7").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank7").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank7").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("bank7").ToString)
                ThirdPartySettings.bank8 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank8").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank8").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank8").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("bank8").ToString)
                ThirdPartySettings.bank9 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank9").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank9").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank9").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("bank9").ToString)
                ThirdPartySettings.bank10 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank10").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank10").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank10").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("bank10").ToString)
                ThirdPartySettings.bank11 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank11").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank11").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank11").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("bank11").ToString)
                Return ThirdPartySettings
            End If
        Catch ex As Exception
            vErr = ex.Message
        End Try
    End Function
    Public Function GetPrevThirdParty(ByRef vErr As String) As ThirdPartySettings
        Try
            Dim ThirdPartySettings As New ThirdPartySettings
            If ds.Tables("ThirdParty").Rows.Count = 0 Then
                ThirdPartySettings = Nothing
                vErr = "No ThirdParty To Load"
                Return ThirdPartySettings
                Exit Function
            End If
            If (i > ds.Tables("ThirdParty").Rows.Count - 1 Or i <> 0) Then
                i = i - 1
                ThirdPartySettings.ThirdId = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ThirdID").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ThirdID").ToString), _
                                        Nothing, CInt(ds.Tables("ThirdParty").Rows(i)("ThirdID").ToString))
                ThirdPartySettings.Name = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Name").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Name").ToString), _
                                       "", ds.Tables("ThirdParty").Rows(i)("Name").ToString)
                ThirdPartySettings.ShortName = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ShortName").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ShortName").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("ShortName").ToString)
                ThirdPartySettings.Title = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Title").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Title").ToString), _
                                         Nothing, ds.Tables("ThirdParty").Rows(i)("Title").ToString)
                ThirdPartySettings.AltName = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("AltName").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("AltName").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("AltName").ToString)
                ThirdPartySettings.AltShortName = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("AltShortName").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("AltShortName").ToString), _
                                        "", ds.Tables("ThirdParty").Rows(i)("AltShortName").ToString)
                ThirdPartySettings.ManualRef = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ManualRef").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ManualRef").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("ManualRef").ToString)
                ThirdPartySettings.CountryId = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("CountryId").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("CountryId").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("CountryId").ToString), _
                                         Nothing, ds.Tables("ThirdParty").Rows(i)("CountryId").ToString)
                ThirdPartySettings.AreaId = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("AreaId").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("AreaId").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("AreaId").ToString), _
                                         Nothing, ds.Tables("ThirdParty").Rows(i)("AreaId").ToString)
                ThirdPartySettings.SisterCompany = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("SisterCompany").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("SisterCompany").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("SisterCompany").ToString), _
                                         False, ds.Tables("ThirdParty").Rows(i)("SisterCompany"))
                ThirdPartySettings.Address = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Address").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Address").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Address").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("Address").ToString)
                ThirdPartySettings.Phone1 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Phone1").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Phone1").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Phone1").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("Phone1").ToString)
                ThirdPartySettings.Phone2 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Phone2").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Phone2").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Phone2").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("Phone2").ToString)
                ThirdPartySettings.Phone3 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Phone3").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Phone3").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Phone3").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("Phone3").ToString)
                ThirdPartySettings.Fax = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Fax").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Fax").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Fax").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("Fax").ToString)
                ThirdPartySettings.POBOX = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("POBOX").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("POBOX").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("POBox").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("POBOX").ToString)
                ThirdPartySettings.Email = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Email").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Email").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Email").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("Email").ToString)
                ThirdPartySettings.Site = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Site").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Site").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Site").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("Site").ToString)
                ThirdPartySettings.ShowInPayable = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ShowInPayable").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ShowInPayable").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ShowInPayable").ToString), _
                                         False, ds.Tables("ThirdParty").Rows(i)("ShowInPayable"))
                ThirdPartySettings.ShowInReceivable = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ShowInReceivable").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ShowInReceivable").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ShowInReceivable").ToString), _
                                        False, ds.Tables("ThirdParty").Rows(i)("ShowInReceivable"))
                ThirdPartySettings.ShowInEmployee = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ShowInEmployee").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ShowInEmployee").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ShowInEmployee").ToString), _
                                         False, ds.Tables("ThirdParty").Rows(i)("ShowInEmployee"))
                ThirdPartySettings.Blocked = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Blocked").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Blocked").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Blocked").ToString), _
                                         False, ds.Tables("ThirdParty").Rows(i)("Blocked"))
                ThirdPartySettings.ContactName = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ContactName").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ContactName").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ContactName").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("ContactName").ToString)
                ThirdPartySettings.ContactMail = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ContactMail").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ContactMail").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ContactMail").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("ContactMail").ToString)
                ThirdPartySettings.ContactPhone = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ContactPhone").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ContactPhone").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ContactPhone").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("ContactPhone").ToString)
                ThirdPartySettings.Notes = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Notes").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Notes").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Notes").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("Notes").ToString)
                ThirdPartySettings.VatREG = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("VatREG").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("VatREG").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("VatREG").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("VatREG").ToString)
                ThirdPartySettings.iUser = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("iUser").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("iUser").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("iUser").ToString), _
                                         FrmLogin.user, ds.Tables("ThirdParty").Rows(i)("iUser").ToString)
                ThirdPartySettings.idate = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("idate").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("idate").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("idate").ToString), _
                                         Today.Date, ds.Tables("ThirdParty").Rows(i)("idate").ToString)
                ThirdPartySettings.Uuser = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Uuser").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Uuser").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Uuser").ToString), _
                                         FrmLogin.user, ds.Tables("ThirdParty").Rows(i)("Uuser").ToString)
                ThirdPartySettings.Udate = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Udate").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Udate").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Udate").ToString), _
                                         Today.Date, ds.Tables("ThirdParty").Rows(i)("Udate").ToString)
                ThirdPartySettings.address2 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("address2").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("address2").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("address2").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("address2").ToString)
                ThirdPartySettings.address3 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("address3").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("address3").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("address3").ToString), _
                                        "", ds.Tables("ThirdParty").Rows(i)("address3").ToString)
                ThirdPartySettings.address4 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("address4").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("address4").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("address4").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("address4").ToString)
                ThirdPartySettings.address5 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("address5").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("address5").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("address5").ToString), _
                                       "", ds.Tables("ThirdParty").Rows(i)("address5").ToString)
                ThirdPartySettings.ThirdFinNb = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ThirdFinNb").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ThirdFinNb").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ThirdFinNb").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("ThirdFinNb").ToString)
                ThirdPartySettings.bank1 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank1").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank1").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank1").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("bank1").ToString)
                ThirdPartySettings.bank = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("bank").ToString)
                ThirdPartySettings.bank2 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank2").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank2").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank2").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("bank2").ToString)
                ThirdPartySettings.bank3 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank3").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank3").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank3").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("bank3").ToString)
                ThirdPartySettings.bank4 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank4").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank4").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank4").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("bank4").ToString)
                ThirdPartySettings.bank5 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank5").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank5").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank5").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("bank5").ToString)
                ThirdPartySettings.bank6 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank6").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank6").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank6").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("bank6").ToString)
                ThirdPartySettings.bank7 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank7").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank7").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank7").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("bank7").ToString)
                ThirdPartySettings.bank8 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank8").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank8").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank8").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("bank8").ToString)
                ThirdPartySettings.bank9 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank9").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank9").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank9").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("bank9").ToString)
                ThirdPartySettings.bank10 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank10").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank10").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank10").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("bank10").ToString)
                ThirdPartySettings.bank11 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank11").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank11").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank11").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("bank11").ToString)
                Return ThirdPartySettings
            Else
                ThirdPartySettings.ThirdId = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ThirdID").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ThirdID").ToString), _
                                        Nothing, CInt(ds.Tables("ThirdParty").Rows(i)("ThirdID").ToString))
                ThirdPartySettings.Name = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Name").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Name").ToString), _
                                       "", ds.Tables("ThirdParty").Rows(i)("Name").ToString)
                ThirdPartySettings.ShortName = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ShortName").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ShortName").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("ShortName").ToString)
                ThirdPartySettings.Title = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Title").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Title").ToString), _
                                         Nothing, ds.Tables("ThirdParty").Rows(i)("Title").ToString)
                ThirdPartySettings.AltName = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("AltName").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("AltName").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("AltName").ToString)
                ThirdPartySettings.AltShortName = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("AltShortName").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("AltShortName").ToString), _
                                        "", ds.Tables("ThirdParty").Rows(i)("AltShortName").ToString)
                ThirdPartySettings.ManualRef = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ManualRef").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ManualRef").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("ManualRef").ToString)
                ThirdPartySettings.CountryId = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("CountryId").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("CountryId").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("CountryId").ToString), _
                                         Nothing, ds.Tables("ThirdParty").Rows(i)("CountryId").ToString)
                ThirdPartySettings.AreaId = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("AreaId").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("AreaId").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("AreaId").ToString), _
                                         Nothing, ds.Tables("ThirdParty").Rows(i)("AreaId").ToString)
                ThirdPartySettings.SisterCompany = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("SisterCompany").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("SisterCompany").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("SisterCompany").ToString), _
                                         False, ds.Tables("ThirdParty").Rows(i)("SisterCompany"))
                ThirdPartySettings.Address = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Address").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Address").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Address").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("Address").ToString)
                ThirdPartySettings.Phone1 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Phone1").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Phone1").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Phone1").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("Phone1").ToString)
                ThirdPartySettings.Phone2 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Phone2").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Phone2").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Phone2").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("Phone2").ToString)
                ThirdPartySettings.Phone3 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Phone3").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Phone3").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Phone3").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("Phone3").ToString)
                ThirdPartySettings.Fax = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Fax").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Fax").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Fax").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("Fax").ToString)
                ThirdPartySettings.POBOX = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("POBOX").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("POBOX").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("POBox").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("POBOX").ToString)
                ThirdPartySettings.Email = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Email").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Email").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Email").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("Email").ToString)
                ThirdPartySettings.Site = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Site").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Site").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Site").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("Site").ToString)
                ThirdPartySettings.ShowInPayable = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ShowInPayable").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ShowInPayable").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ShowInPayable").ToString), _
                                         False, ds.Tables("ThirdParty").Rows(i)("ShowInPayable"))
                ThirdPartySettings.ShowInReceivable = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ShowInReceivable").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ShowInReceivable").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ShowInReceivable").ToString), _
                                        False, ds.Tables("ThirdParty").Rows(i)("ShowInReceivable"))
                ThirdPartySettings.ShowInEmployee = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ShowInEmployee").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ShowInEmployee").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ShowInEmployee").ToString), _
                                         False, ds.Tables("ThirdParty").Rows(i)("ShowInEmployee"))
                ThirdPartySettings.Blocked = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Blocked").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Blocked").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Blocked").ToString), _
                                         False, ds.Tables("ThirdParty").Rows(i)("Blocked"))
                ThirdPartySettings.ContactName = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ContactName").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ContactName").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ContactName").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("ContactName").ToString)
                ThirdPartySettings.ContactMail = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ContactMail").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ContactMail").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ContactMail").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("ContactMail").ToString)
                ThirdPartySettings.ContactPhone = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ContactPhone").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ContactPhone").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ContactPhone").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("ContactPhone").ToString)
                ThirdPartySettings.Notes = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Notes").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Notes").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Notes").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("Notes").ToString)
                ThirdPartySettings.VatREG = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("VatREG").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("VatREG").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("VatREG").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("VatREG").ToString)
                ThirdPartySettings.iUser = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("iUser").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("iUser").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("iUser").ToString), _
                                         FrmLogin.user, ds.Tables("ThirdParty").Rows(i)("iUser").ToString)
                ThirdPartySettings.idate = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("idate").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("idate").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("idate").ToString), _
                                         Today.Date, ds.Tables("ThirdParty").Rows(i)("idate").ToString)
                ThirdPartySettings.Uuser = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Uuser").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Uuser").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Uuser").ToString), _
                                         FrmLogin.user, ds.Tables("ThirdParty").Rows(i)("Uuser").ToString)
                ThirdPartySettings.Udate = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Udate").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Udate").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Udate").ToString), _
                                         Today.Date, ds.Tables("ThirdParty").Rows(i)("Udate").ToString)
                ThirdPartySettings.address2 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("address2").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("address2").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("address2").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("address2").ToString)
                ThirdPartySettings.address3 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("address3").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("address3").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("address3").ToString), _
                                        "", ds.Tables("ThirdParty").Rows(i)("address3").ToString)
                ThirdPartySettings.address4 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("address4").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("address4").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("address4").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("address4").ToString)
                ThirdPartySettings.address5 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("address5").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("address5").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("address5").ToString), _
                                       "", ds.Tables("ThirdParty").Rows(i)("address5").ToString)
                ThirdPartySettings.ThirdFinNb = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ThirdFinNb").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ThirdFinNb").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ThirdFinNb").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("ThirdFinNb").ToString)
                ThirdPartySettings.bank1 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank1").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank1").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank1").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("bank1").ToString)
                ThirdPartySettings.bank = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("bank").ToString)
                ThirdPartySettings.bank2 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank2").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank2").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank2").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("bank2").ToString)
                ThirdPartySettings.bank3 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank3").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank3").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank3").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("bank3").ToString)
                ThirdPartySettings.bank4 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank4").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank4").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank4").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("bank4").ToString)
                ThirdPartySettings.bank5 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank5").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank5").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank5").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("bank5").ToString)
                ThirdPartySettings.bank6 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank6").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank6").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank6").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("bank6").ToString)
                ThirdPartySettings.bank7 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank7").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank7").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank7").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("bank7").ToString)
                ThirdPartySettings.bank8 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank8").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank8").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank8").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("bank8").ToString)
                ThirdPartySettings.bank9 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank9").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank9").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank9").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("bank9").ToString)
                ThirdPartySettings.bank10 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank10").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank10").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank10").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("bank10").ToString)
                ThirdPartySettings.bank11 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank11").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank11").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank11").ToString), _
                                         "", ds.Tables("ThirdParty").Rows(i)("bank11").ToString)
                Return ThirdPartySettings
            End If
        Catch ex As Exception
            vErr = ex.Message
        End Try
    End Function
    Public Function GetCurrentRecord(ByVal Index As Integer, ByRef vErr As String) As ThirdPartySettings
        Try
            Dim ThirdPartySettings As New ThirdPartySettings
            If ds.Tables("ThirdParty").Rows.Count = 0 Then
                ThirdPartySettings = Nothing
                vErr = "No ThirdParty To Load"
                Return ThirdPartySettings
                Exit Function
            End If
            i = Index
            ThirdPartySettings.ThirdId = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ThirdID").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ThirdID").ToString), _
                                    Nothing, CInt(ds.Tables("ThirdParty").Rows(i)("ThirdID").ToString))
            ThirdPartySettings.Name = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Name").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Name").ToString), _
                                   "", ds.Tables("ThirdParty").Rows(i)("Name").ToString)
            ThirdPartySettings.ShortName = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ShortName").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ShortName").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("ShortName").ToString)
            ThirdPartySettings.Title = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Title").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Title").ToString), _
                                     Nothing, ds.Tables("ThirdParty").Rows(i)("Title").ToString)
            ThirdPartySettings.AltName = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("AltName").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("AltName").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("AltName").ToString)
            ThirdPartySettings.AltShortName = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("AltShortName").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("AltShortName").ToString), _
                                    "", ds.Tables("ThirdParty").Rows(i)("AltShortName").ToString)
            ThirdPartySettings.ManualRef = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ManualRef").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ManualRef").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("ManualRef").ToString)
            ThirdPartySettings.CountryId = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("CountryId").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("CountryId").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("CountryId").ToString), _
                                     Nothing, ds.Tables("ThirdParty").Rows(i)("CountryId").ToString)
            ThirdPartySettings.AreaId = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("AreaId").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("AreaId").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("AreaId").ToString), _
                                     Nothing, ds.Tables("ThirdParty").Rows(i)("AreaId").ToString)
            ThirdPartySettings.SisterCompany = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("SisterCompany").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("SisterCompany").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("SisterCompany").ToString), _
                                     False, ds.Tables("ThirdParty").Rows(i)("SisterCompany"))
            ThirdPartySettings.Address = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Address").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Address").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Address").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("Address").ToString)
            ThirdPartySettings.Phone1 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Phone1").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Phone1").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Phone1").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("Phone1").ToString)
            ThirdPartySettings.Phone2 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Phone2").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Phone2").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Phone2").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("Phone2").ToString)
            ThirdPartySettings.Phone3 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Phone3").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Phone3").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Phone3").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("Phone3").ToString)
            ThirdPartySettings.Fax = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Fax").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Fax").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Fax").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("Fax").ToString)
            ThirdPartySettings.POBOX = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("POBOX").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("POBOX").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("POBox").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("POBOX").ToString)
            ThirdPartySettings.Email = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Email").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Email").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Email").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("Email").ToString)
            ThirdPartySettings.Site = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Site").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Site").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Site").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("Site").ToString)
            ThirdPartySettings.ShowInPayable = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ShowInPayable").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ShowInPayable").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ShowInPayable").ToString), _
                                     False, ds.Tables("ThirdParty").Rows(i)("ShowInPayable"))
            ThirdPartySettings.ShowInReceivable = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ShowInReceivable").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ShowInReceivable").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ShowInReceivable").ToString), _
                                    False, ds.Tables("ThirdParty").Rows(i)("ShowInReceivable"))
            ThirdPartySettings.ShowInEmployee = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ShowInEmployee").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ShowInEmployee").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ShowInEmployee").ToString), _
                                     False, ds.Tables("ThirdParty").Rows(i)("ShowInEmployee"))
            ThirdPartySettings.Blocked = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Blocked").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Blocked").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Blocked").ToString), _
                                     False, ds.Tables("ThirdParty").Rows(i)("Blocked"))
            ThirdPartySettings.ContactName = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ContactName").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ContactName").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ContactName").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("ContactName").ToString)
            ThirdPartySettings.ContactMail = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ContactMail").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ContactMail").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ContactMail").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("ContactMail").ToString)
            ThirdPartySettings.ContactPhone = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ContactPhone").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ContactPhone").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ContactPhone").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("ContactPhone").ToString)
            ThirdPartySettings.Notes = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Notes").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Notes").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Notes").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("Notes").ToString)
            ThirdPartySettings.VatREG = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("VatREG").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("VatREG").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("VatREG").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("VatREG").ToString)
            ThirdPartySettings.iUser = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("iUser").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("iUser").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("iUser").ToString), _
                                     FrmLogin.user, ds.Tables("ThirdParty").Rows(i)("iUser").ToString)
            ThirdPartySettings.idate = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("idate").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("idate").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("idate").ToString), _
                                     Today.Date, ds.Tables("ThirdParty").Rows(i)("idate").ToString)
            ThirdPartySettings.Uuser = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Uuser").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Uuser").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Uuser").ToString), _
                                     FrmLogin.user, ds.Tables("ThirdParty").Rows(i)("Uuser").ToString)
            ThirdPartySettings.Udate = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("Udate").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("Udate").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("Udate").ToString), _
                                     Today.Date, ds.Tables("ThirdParty").Rows(i)("Udate").ToString)
            ThirdPartySettings.address2 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("address2").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("address2").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("address2").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("address2").ToString)
            ThirdPartySettings.address3 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("address3").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("address3").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("address3").ToString), _
                                    "", ds.Tables("ThirdParty").Rows(i)("address3").ToString)
            ThirdPartySettings.address4 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("address4").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("address4").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("address4").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("address4").ToString)
            ThirdPartySettings.address5 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("address5").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("address5").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("address5").ToString), _
                                   "", ds.Tables("ThirdParty").Rows(i)("address5").ToString)
            ThirdPartySettings.ThirdFinNb = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("ThirdFinNb").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("ThirdFinNb").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("ThirdFinNb").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("ThirdFinNb").ToString)
            ThirdPartySettings.bank1 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank1").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank1").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank1").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("bank1").ToString)
            ThirdPartySettings.bank = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("bank").ToString)
            ThirdPartySettings.bank2 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank2").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank2").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank2").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("bank2").ToString)
            ThirdPartySettings.bank3 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank3").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank3").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank3").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("bank3").ToString)
            ThirdPartySettings.bank4 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank4").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank4").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank4").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("bank4").ToString)
            ThirdPartySettings.bank5 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank5").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank5").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank5").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("bank5").ToString)
            ThirdPartySettings.bank6 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank6").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank6").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank6").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("bank6").ToString)
            ThirdPartySettings.bank7 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank7").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank7").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank7").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("bank7").ToString)
            ThirdPartySettings.bank8 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank8").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank8").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank8").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("bank8").ToString)
            ThirdPartySettings.bank9 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank9").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank9").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank9").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("bank9").ToString)
            ThirdPartySettings.bank10 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank10").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank10").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank10").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("bank10").ToString)
            ThirdPartySettings.bank11 = IIf(IsDBNull(ds.Tables("ThirdParty").Rows(i)("bank11").ToString) Or IsNothing(ds.Tables("ThirdParty").Rows(i)("bank11").ToString) Or String.IsNullOrEmpty(ds.Tables("ThirdParty").Rows(i)("bank11").ToString), _
                                     "", ds.Tables("ThirdParty").Rows(i)("bank11").ToString)
            Return ThirdPartySettings

        Catch ex As Exception
            vErr = ex.Message
        End Try
    End Function
    Public Function GetSalesMan(ByVal Con As SqlConnection) As DataTable
        Try
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("select ThirdId,Name From SacThirdParty where ShowInEmployee=1 Order by Name", Con)
            da = New SqlDataAdapter(sqlcomm)
            Dim dt As New DataTable
            blnconnectionOpen = ConnStatus(Con)
            If Not blnconnectionOpen Then ConnOpen(Con)
            da.Fill(dt)
            Return dt
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Public Sub ThirdPartyInsert(ByVal Con As SqlConnection)
        Try
            Dim blnconnectionOpen As Boolean
            Dim Sqlcom As New SqlCommand("Sp_ThirdPartyInsert", Con)
            Sqlcom.CommandType = CommandType.StoredProcedure
            Sqlcom.Parameters.AddWithValue("@ThirdId", IIf(IsNothing(_ThirdId) Or IsDBNull(_ThirdId), DBNull.Value, _ThirdId))
            Sqlcom.Parameters.AddWithValue("@Name", IIf(IsNothing(_Name) Or IsDBNull(_Name), DBNull.Value, _Name))
            Sqlcom.Parameters.AddWithValue("@ShortName", IIf(IsNothing(_ShortName) Or IsDBNull(_ShortName), DBNull.Value, _ShortName))
            Sqlcom.Parameters.AddWithValue("@Title", IIf(IsNothing(_Title) Or IsDBNull(_Title), DBNull.Value, _Title))
            Sqlcom.Parameters.AddWithValue("@AltName", IIf(IsNothing(_AltName) Or IsDBNull(_AltName), DBNull.Value, _AltName))
            Sqlcom.Parameters.AddWithValue("@AltShortName", IIf(IsNothing(_AltShortName) Or IsDBNull(_AltShortName), DBNull.Value, _AltShortName))
            Sqlcom.Parameters.AddWithValue("@ManualRef", IIf(IsNothing(_ManualRef) Or IsDBNull(_ManualRef), DBNull.Value, _ManualRef))
            Sqlcom.Parameters.AddWithValue("@CountryId", IIf(IsNothing(_CountryId) Or IsDBNull(_CountryId), DBNull.Value, _CountryId))
            Sqlcom.Parameters.AddWithValue("@AreaId", IIf(IsNothing(_AreaId) Or IsDBNull(_AreaId), DBNull.Value, _AreaId))
            Sqlcom.Parameters.AddWithValue("@SisterCompany", IIf(IsNothing(_SisterCompany) Or IsDBNull(_SisterCompany), False, _SisterCompany))
            Sqlcom.Parameters.AddWithValue("@Address", IIf(IsNothing(_Address) Or IsDBNull(_Address), DBNull.Value, _Address))
            Sqlcom.Parameters.AddWithValue("@Address2", IIf(IsNothing(_address2) Or IsDBNull(_address2), DBNull.Value, _address2))
            Sqlcom.Parameters.AddWithValue("@Address3", IIf(IsNothing(_address3) Or IsDBNull(_address3), DBNull.Value, _address3))
            Sqlcom.Parameters.AddWithValue("@Address4", IIf(IsNothing(_address4) Or IsDBNull(_address4), DBNull.Value, _address4))
            Sqlcom.Parameters.AddWithValue("@Address5", IIf(IsNothing(_address5) Or IsDBNull(_address5), DBNull.Value, _address5))
            Sqlcom.Parameters.AddWithValue("@Phone1", IIf(IsNothing(_Phone1) Or IsDBNull(_Phone1), DBNull.Value, _Phone1))
            Sqlcom.Parameters.AddWithValue("@Phone2", IIf(IsNothing(_Phone2) Or IsDBNull(_Phone2), DBNull.Value, _Phone2))
            Sqlcom.Parameters.AddWithValue("@Phone3", IIf(IsNothing(_Phone3) Or IsDBNull(_Phone3), DBNull.Value, _Phone3))
            Sqlcom.Parameters.AddWithValue("@Fax", IIf(IsNothing(_Fax) Or IsDBNull(_Fax), DBNull.Value, _Fax))
            Sqlcom.Parameters.AddWithValue("@POBOX", IIf(IsNothing(_POBOX) Or IsDBNull(_POBOX), DBNull.Value, _POBOX))
            Sqlcom.Parameters.AddWithValue("@Email", IIf(IsNothing(_Email) Or IsDBNull(_Email), DBNull.Value, _Email))
            Sqlcom.Parameters.AddWithValue("@Site", IIf(IsNothing(_Site) Or IsDBNull(_Site), DBNull.Value, _Site))
            Sqlcom.Parameters.AddWithValue("@ShowInPayable", IIf(IsNothing(_ShowInPayable) Or IsDBNull(_ShowInPayable), False, _ShowInPayable))
            Sqlcom.Parameters.AddWithValue("@ShowInReceivable", IIf(IsNothing(_ShowInReceivable) Or IsDBNull(_ShowInReceivable), False, _ShowInReceivable))
            Sqlcom.Parameters.AddWithValue("@ShowInEmployee", IIf(IsNothing(_ShowInEmployee) Or IsDBNull(_ShowInEmployee), False, _ShowInEmployee))
            Sqlcom.Parameters.AddWithValue("@Blocked", IIf(IsNothing(_Blocked) Or IsDBNull(_Blocked), False, _Blocked))
            Sqlcom.Parameters.AddWithValue("@ContactName", IIf(IsNothing(_ContactName) Or IsDBNull(_ContactName), DBNull.Value, _ContactName))
            Sqlcom.Parameters.AddWithValue("@ContactMail", IIf(IsNothing(_ContactMail) Or IsDBNull(_ContactMail), DBNull.Value, _ContactMail))
            Sqlcom.Parameters.AddWithValue("@ContactPhone", IIf(IsNothing(_ContactPhone) Or IsDBNull(_ContactPhone), DBNull.Value, _ContactPhone))
            Sqlcom.Parameters.AddWithValue("@Notes", IIf(IsNothing(_Notes) Or IsDBNull(_Notes), DBNull.Value, _Notes))
            Sqlcom.Parameters.AddWithValue("@VatREG", IIf(IsNothing(_VatREG) Or IsDBNull(_VatREG), DBNull.Value, _VatREG))
            Sqlcom.Parameters.AddWithValue("@iUser", IIf(IsNothing(_iUser) Or IsDBNull(_iUser), DBNull.Value, _iUser))
            Sqlcom.Parameters.AddWithValue("@idate", Today.Date)
            Sqlcom.Parameters.AddWithValue("@ThirdFinNb", IIf(IsNothing(_ThirdFinNb) Or IsDBNull(_ThirdFinNb), DBNull.Value, _ThirdFinNb))
            Sqlcom.Parameters.AddWithValue("@bank1", IIf(IsNothing(_bank1) Or IsDBNull(_bank1), DBNull.Value, _bank1))
            Sqlcom.Parameters.AddWithValue("@bank", IIf(IsNothing(_bank) Or IsDBNull(_bank), DBNull.Value, _bank))
            Sqlcom.Parameters.AddWithValue("@bank2", IIf(IsNothing(_bank2) Or IsDBNull(_bank2), DBNull.Value, _bank2))
            Sqlcom.Parameters.AddWithValue("@bank3", IIf(IsNothing(_bank3) Or IsDBNull(_bank3), DBNull.Value, _bank3))
            Sqlcom.Parameters.AddWithValue("@bank4", IIf(IsNothing(_bank4) Or IsDBNull(_bank4), DBNull.Value, _bank4))
            Sqlcom.Parameters.AddWithValue("@bank5", IIf(IsNothing(_bank5) Or IsDBNull(_bank5), DBNull.Value, _bank5))
            Sqlcom.Parameters.AddWithValue("@bank6", IIf(IsNothing(_bank6) Or IsDBNull(_bank6), DBNull.Value, _bank6))
            Sqlcom.Parameters.AddWithValue("@bank7", IIf(IsNothing(_bank7) Or IsDBNull(_bank7), DBNull.Value, _bank7))
            Sqlcom.Parameters.AddWithValue("@bank8", IIf(IsNothing(_bank8) Or IsDBNull(_bank8), DBNull.Value, _bank8))
            Sqlcom.Parameters.AddWithValue("@bank9", IIf(IsNothing(_bank9) Or IsDBNull(_bank9), DBNull.Value, _bank9))
            Sqlcom.Parameters.AddWithValue("@bank10", IIf(IsNothing(_bank10) Or IsDBNull(_bank10), DBNull.Value, _bank10))
            Sqlcom.Parameters.AddWithValue("@bank11", IIf(IsNothing(_bank11) Or IsDBNull(_bank11), DBNull.Value, _bank11))
            blnconnectionOpen = ConnStatus(Con)
            If Not blnconnectionOpen Then ConnOpen(Con)
            Sqlcom.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub ThirdPartyUpdate(ByVal Con As SqlConnection)
        Try
            Dim blnconnectionOpen As Boolean
            Dim Sqlcom As New SqlCommand("Sp_ThirdPartyUpdate", Con)
            Sqlcom.CommandType = CommandType.StoredProcedure
            Sqlcom.Parameters.AddWithValue("@ThirdId", IIf(IsNothing(_ThirdId) Or IsDBNull(_ThirdId), DBNull.Value, _ThirdId))
            Sqlcom.Parameters.AddWithValue("@Name", IIf(IsNothing(_Name) Or IsDBNull(_Name), DBNull.Value, _Name))
            Sqlcom.Parameters.AddWithValue("@ShortName", IIf(IsNothing(_ShortName) Or IsDBNull(_ShortName), DBNull.Value, _ShortName))
            Sqlcom.Parameters.AddWithValue("@Title", IIf(IsNothing(_Title) Or IsDBNull(_Title), DBNull.Value, _Title))
            Sqlcom.Parameters.AddWithValue("@AltName", IIf(IsNothing(_AltName) Or IsDBNull(_AltName), DBNull.Value, _AltName))
            Sqlcom.Parameters.AddWithValue("@AltShortName", IIf(IsNothing(_AltShortName) Or IsDBNull(_AltShortName), DBNull.Value, _AltShortName))
            Sqlcom.Parameters.AddWithValue("@ManualRef", IIf(IsNothing(_ManualRef) Or IsDBNull(_ManualRef), DBNull.Value, _ManualRef))
            Sqlcom.Parameters.AddWithValue("@CountryId", IIf(IsNothing(_CountryId) Or IsDBNull(_CountryId), DBNull.Value, _CountryId))
            Sqlcom.Parameters.AddWithValue("@AreaId", IIf(IsNothing(_AreaId) Or IsDBNull(_AreaId), DBNull.Value, _AreaId))
            Sqlcom.Parameters.AddWithValue("@SisterCompany", IIf(IsNothing(_SisterCompany) Or IsDBNull(_SisterCompany), False, _SisterCompany))
            Sqlcom.Parameters.AddWithValue("@Address", IIf(IsNothing(_Address) Or IsDBNull(_Address), DBNull.Value, _Address))
            Sqlcom.Parameters.AddWithValue("@Address2", IIf(IsNothing(_address2) Or IsDBNull(_address2), DBNull.Value, _address2))
            Sqlcom.Parameters.AddWithValue("@Address3", IIf(IsNothing(_address3) Or IsDBNull(_address3), DBNull.Value, _address3))
            Sqlcom.Parameters.AddWithValue("@Address4", IIf(IsNothing(_address4) Or IsDBNull(_address4), DBNull.Value, _address4))
            Sqlcom.Parameters.AddWithValue("@Address5", IIf(IsNothing(_address5) Or IsDBNull(_address5), DBNull.Value, _address5))
            Sqlcom.Parameters.AddWithValue("@Phone1", IIf(IsNothing(_Phone1) Or IsDBNull(_Phone1), DBNull.Value, _Phone1))
            Sqlcom.Parameters.AddWithValue("@Phone2", IIf(IsNothing(_Phone2) Or IsDBNull(_Phone2), DBNull.Value, _Phone2))
            Sqlcom.Parameters.AddWithValue("@Phone3", IIf(IsNothing(_Phone3) Or IsDBNull(_Phone3), DBNull.Value, _Phone3))
            Sqlcom.Parameters.AddWithValue("@Fax", IIf(IsNothing(_Fax) Or IsDBNull(_Fax), DBNull.Value, _Fax))
            Sqlcom.Parameters.AddWithValue("@POBOX", IIf(IsNothing(_POBOX) Or IsDBNull(_POBOX), DBNull.Value, _POBOX))
            Sqlcom.Parameters.AddWithValue("@Email", IIf(IsNothing(_Email) Or IsDBNull(_Email), DBNull.Value, _Email))
            Sqlcom.Parameters.AddWithValue("@Site", IIf(IsNothing(_Site) Or IsDBNull(_Site), DBNull.Value, _Site))
            Sqlcom.Parameters.AddWithValue("@ShowInPayable", IIf(IsNothing(_ShowInPayable) Or IsDBNull(_ShowInPayable), False, _ShowInPayable))
            Sqlcom.Parameters.AddWithValue("@ShowInReceivable", IIf(IsNothing(_ShowInReceivable) Or IsDBNull(_ShowInReceivable), False, _ShowInReceivable))
            Sqlcom.Parameters.AddWithValue("@ShowInEmployee", IIf(IsNothing(_ShowInEmployee) Or IsDBNull(_ShowInEmployee), False, _ShowInEmployee))
            Sqlcom.Parameters.AddWithValue("@Blocked", IIf(IsNothing(_Blocked) Or IsDBNull(_Blocked), False, _Blocked))
            Sqlcom.Parameters.AddWithValue("@ContactName", IIf(IsNothing(_ContactName) Or IsDBNull(_ContactName), DBNull.Value, _ContactName))
            Sqlcom.Parameters.AddWithValue("@ContactMail", IIf(IsNothing(_ContactMail) Or IsDBNull(_ContactMail), DBNull.Value, _ContactMail))
            Sqlcom.Parameters.AddWithValue("@ContactPhone", IIf(IsNothing(_ContactPhone) Or IsDBNull(_ContactPhone), DBNull.Value, _ContactPhone))
            Sqlcom.Parameters.AddWithValue("@Notes", IIf(IsNothing(_Notes) Or IsDBNull(_Notes), DBNull.Value, _Notes))
            Sqlcom.Parameters.AddWithValue("@VatREG", IIf(IsNothing(_VatREG) Or IsDBNull(_VatREG), DBNull.Value, _VatREG))
            Sqlcom.Parameters.AddWithValue("@iUser", IIf(IsNothing(_iUser) Or IsDBNull(_iUser), DBNull.Value, _iUser))
            Sqlcom.Parameters.AddWithValue("@idate", Today.Date)
            Sqlcom.Parameters.AddWithValue("@ThirdFinNb", IIf(IsNothing(_ThirdFinNb) Or IsDBNull(_ThirdFinNb), DBNull.Value, _ThirdFinNb))
            Sqlcom.Parameters.AddWithValue("@bank1", IIf(IsNothing(_bank1) Or IsDBNull(_bank1), DBNull.Value, _bank1))
            Sqlcom.Parameters.AddWithValue("@bank", IIf(IsNothing(_bank) Or IsDBNull(_bank), DBNull.Value, _bank))
            Sqlcom.Parameters.AddWithValue("@bank2", IIf(IsNothing(_bank2) Or IsDBNull(_bank2), DBNull.Value, _bank2))
            Sqlcom.Parameters.AddWithValue("@bank3", IIf(IsNothing(_bank3) Or IsDBNull(_bank3), DBNull.Value, _bank3))
            Sqlcom.Parameters.AddWithValue("@bank4", IIf(IsNothing(_bank4) Or IsDBNull(_bank4), DBNull.Value, _bank4))
            Sqlcom.Parameters.AddWithValue("@bank5", IIf(IsNothing(_bank5) Or IsDBNull(_bank5), DBNull.Value, _bank5))
            Sqlcom.Parameters.AddWithValue("@bank6", IIf(IsNothing(_bank6) Or IsDBNull(_bank6), DBNull.Value, _bank6))
            Sqlcom.Parameters.AddWithValue("@bank7", IIf(IsNothing(_bank7) Or IsDBNull(_bank7), DBNull.Value, _bank7))
            Sqlcom.Parameters.AddWithValue("@bank8", IIf(IsNothing(_bank8) Or IsDBNull(_bank8), DBNull.Value, _bank8))
            Sqlcom.Parameters.AddWithValue("@bank9", IIf(IsNothing(_bank9) Or IsDBNull(_bank9), DBNull.Value, _bank9))
            Sqlcom.Parameters.AddWithValue("@bank10", IIf(IsNothing(_bank10) Or IsDBNull(_bank10), DBNull.Value, _bank10))
            Sqlcom.Parameters.AddWithValue("@bank11", IIf(IsNothing(_bank11) Or IsDBNull(_bank11), DBNull.Value, _bank11))
            Sqlcom.Parameters.AddWithValue("@Updated", IIf(IsNothing(_Updated) Or IsDBNull(_Updated), 0, _Updated))
            blnconnectionOpen = ConnStatus(Con)
            If Not blnconnectionOpen Then ConnOpen(Con)
            Sqlcom.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Function FillThirdParties(ByVal con As SqlConnection) As DataTable
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("Select ThirdId,Name from SacthirdParty", con)
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
    Public Function BoGetNewCustomers(ByVal con As SqlConnection) As DataTable
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("SpRt_BONewCustomersGet", con)
            sqlcomm.CommandType = CommandType.StoredProcedure
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

    Public Function BoToPosNewCustomers(ByVal Stamp As String, ByVal con As SqlConnection) As DataTable
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim SqlString = " Select * from SacThirdParty st join SacThirdExtra1ES se on st.ThirdID = se.ThirdID "
            SqlString = SqlString & " where se.Stk_CustAppearInRetail = 1 and st.ThirdStamp > " & Stamp
            Dim sqlcomm As New SqlCommand(SqlString, con)
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
    Public Sub ThirdPartyBoToPOS(ByVal Con As SqlConnection)
        Try
            Dim blnconnectionOpen As Boolean
            Dim Sqlcom As New SqlCommand("Sp_ThirdPartyBoToPos", Con)
            Sqlcom.CommandType = CommandType.StoredProcedure
            Sqlcom.Parameters.AddWithValue("@ThirdId", IIf(IsNothing(_ThirdId) Or IsDBNull(_ThirdId), DBNull.Value, _ThirdId))
            Sqlcom.Parameters.AddWithValue("@Name", IIf(IsNothing(_Name) Or IsDBNull(_Name), DBNull.Value, _Name))
            Sqlcom.Parameters.AddWithValue("@ShortName", IIf(IsNothing(_ShortName) Or IsDBNull(_ShortName), DBNull.Value, _ShortName))
            Sqlcom.Parameters.AddWithValue("@Title", IIf(IsNothing(_Title) Or IsDBNull(_Title), DBNull.Value, _Title))
            Sqlcom.Parameters.AddWithValue("@AltName", IIf(IsNothing(_AltName) Or IsDBNull(_AltName), DBNull.Value, _AltName))
            Sqlcom.Parameters.AddWithValue("@AltShortName", IIf(IsNothing(_AltShortName) Or IsDBNull(_AltShortName), DBNull.Value, _AltShortName))
            Sqlcom.Parameters.AddWithValue("@ManualRef", IIf(IsNothing(_ManualRef) Or IsDBNull(_ManualRef), DBNull.Value, _ManualRef))
            Sqlcom.Parameters.AddWithValue("@CountryId", IIf(IsNothing(_CountryId) Or IsDBNull(_CountryId), DBNull.Value, _CountryId))
            Sqlcom.Parameters.AddWithValue("@AreaId", IIf(IsNothing(_AreaId) Or IsDBNull(_AreaId), DBNull.Value, _AreaId))
            Sqlcom.Parameters.AddWithValue("@SisterCompany", IIf(IsNothing(_SisterCompany) Or IsDBNull(_SisterCompany), False, _SisterCompany))
            Sqlcom.Parameters.AddWithValue("@Address", IIf(IsNothing(_Address) Or IsDBNull(_Address), DBNull.Value, _Address))
            Sqlcom.Parameters.AddWithValue("@Address2", IIf(IsNothing(_address2) Or IsDBNull(_address2), DBNull.Value, _address2))
            Sqlcom.Parameters.AddWithValue("@Address3", IIf(IsNothing(_address3) Or IsDBNull(_address3), DBNull.Value, _address3))
            Sqlcom.Parameters.AddWithValue("@Address4", IIf(IsNothing(_address4) Or IsDBNull(_address4), DBNull.Value, _address4))
            Sqlcom.Parameters.AddWithValue("@Address5", IIf(IsNothing(_address5) Or IsDBNull(_address5), DBNull.Value, _address5))
            Sqlcom.Parameters.AddWithValue("@Phone1", IIf(IsNothing(_Phone1) Or IsDBNull(_Phone1), DBNull.Value, _Phone1))
            Sqlcom.Parameters.AddWithValue("@Phone2", IIf(IsNothing(_Phone2) Or IsDBNull(_Phone2), DBNull.Value, _Phone2))
            Sqlcom.Parameters.AddWithValue("@Phone3", IIf(IsNothing(_Phone3) Or IsDBNull(_Phone3), DBNull.Value, _Phone3))
            Sqlcom.Parameters.AddWithValue("@Fax", IIf(IsNothing(_Fax) Or IsDBNull(_Fax), DBNull.Value, _Fax))
            Sqlcom.Parameters.AddWithValue("@POBOX", IIf(IsNothing(_POBOX) Or IsDBNull(_POBOX), DBNull.Value, _POBOX))
            Sqlcom.Parameters.AddWithValue("@Email", IIf(IsNothing(_Email) Or IsDBNull(_Email), DBNull.Value, _Email))
            Sqlcom.Parameters.AddWithValue("@Site", IIf(IsNothing(_Site) Or IsDBNull(_Site), DBNull.Value, _Site))
            Sqlcom.Parameters.AddWithValue("@ShowInPayable", IIf(IsNothing(_ShowInPayable) Or IsDBNull(_ShowInPayable), False, _ShowInPayable))
            Sqlcom.Parameters.AddWithValue("@ShowInReceivable", IIf(IsNothing(_ShowInReceivable) Or IsDBNull(_ShowInReceivable), False, _ShowInReceivable))
            Sqlcom.Parameters.AddWithValue("@ShowInEmployee", IIf(IsNothing(_ShowInEmployee) Or IsDBNull(_ShowInEmployee), False, _ShowInEmployee))
            Sqlcom.Parameters.AddWithValue("@Blocked", IIf(IsNothing(_Blocked) Or IsDBNull(_Blocked), False, _Blocked))
            Sqlcom.Parameters.AddWithValue("@ContactName", IIf(IsNothing(_ContactName) Or IsDBNull(_ContactName), DBNull.Value, _ContactName))
            Sqlcom.Parameters.AddWithValue("@ContactMail", IIf(IsNothing(_ContactMail) Or IsDBNull(_ContactMail), DBNull.Value, _ContactMail))
            Sqlcom.Parameters.AddWithValue("@ContactPhone", IIf(IsNothing(_ContactPhone) Or IsDBNull(_ContactPhone), DBNull.Value, _ContactPhone))
            Sqlcom.Parameters.AddWithValue("@Notes", IIf(IsNothing(_Notes) Or IsDBNull(_Notes), DBNull.Value, _Notes))
            Sqlcom.Parameters.AddWithValue("@VatREG", IIf(IsNothing(_VatREG) Or IsDBNull(_VatREG), DBNull.Value, _VatREG))
            Sqlcom.Parameters.AddWithValue("@iUser", IIf(IsNothing(_iUser) Or IsDBNull(_iUser), DBNull.Value, _iUser))
            Sqlcom.Parameters.AddWithValue("@idate", Today.Date)
            Sqlcom.Parameters.AddWithValue("@ThirdFinNb", IIf(IsNothing(_ThirdFinNb) Or IsDBNull(_ThirdFinNb), DBNull.Value, _ThirdFinNb))
            Sqlcom.Parameters.AddWithValue("@bank1", IIf(IsNothing(_bank1) Or IsDBNull(_bank1), DBNull.Value, _bank1))
            Sqlcom.Parameters.AddWithValue("@bank", IIf(IsNothing(_bank) Or IsDBNull(_bank), DBNull.Value, _bank))
            Sqlcom.Parameters.AddWithValue("@bank2", IIf(IsNothing(_bank2) Or IsDBNull(_bank2), DBNull.Value, _bank2))
            Sqlcom.Parameters.AddWithValue("@bank3", IIf(IsNothing(_bank3) Or IsDBNull(_bank3), DBNull.Value, _bank3))
            Sqlcom.Parameters.AddWithValue("@bank4", IIf(IsNothing(_bank4) Or IsDBNull(_bank4), DBNull.Value, _bank4))
            Sqlcom.Parameters.AddWithValue("@bank5", IIf(IsNothing(_bank5) Or IsDBNull(_bank5), DBNull.Value, _bank5))
            Sqlcom.Parameters.AddWithValue("@bank6", IIf(IsNothing(_bank6) Or IsDBNull(_bank6), DBNull.Value, _bank6))
            Sqlcom.Parameters.AddWithValue("@bank7", IIf(IsNothing(_bank7) Or IsDBNull(_bank7), DBNull.Value, _bank7))
            Sqlcom.Parameters.AddWithValue("@bank8", IIf(IsNothing(_bank8) Or IsDBNull(_bank8), DBNull.Value, _bank8))
            Sqlcom.Parameters.AddWithValue("@bank9", IIf(IsNothing(_bank9) Or IsDBNull(_bank9), DBNull.Value, _bank9))
            Sqlcom.Parameters.AddWithValue("@bank10", IIf(IsNothing(_bank10) Or IsDBNull(_bank10), DBNull.Value, _bank10))
            Sqlcom.Parameters.AddWithValue("@bank11", IIf(IsNothing(_bank11) Or IsDBNull(_bank11), DBNull.Value, _bank11))
            blnconnectionOpen = ConnStatus(Con)
            If Not blnconnectionOpen Then ConnOpen(Con)
            Sqlcom.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Function BoInitNewPosCustomersA(ByVal con As SqlConnection) As DataTable
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("SpRt_InitNewPosCustomersA", con)
            sqlcomm.CommandType = CommandType.StoredProcedure
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
    Public Function BoInitNewPosCustomersB(ByVal con As SqlConnection) As DataTable
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("SpRt_InitNewPosCustomersB", con)
            sqlcomm.CommandType = CommandType.StoredProcedure
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
