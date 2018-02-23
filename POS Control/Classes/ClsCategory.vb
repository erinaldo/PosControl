Imports System.Data.SqlClient
Imports ConnectionSQL
Public Class CategorySettings
    Public CategoryCode As String
    Public Description As String
    Public AltDescription As String
    Public salesacc As String
    Public salesauxb As String
    Public purchacc As String
    Public PurchAuxb As String
    Public salesdiscacc As String
    Public salesdiscAuxb As String
    Public purchdiscacc As String
    Public PurchDiscAuxb As String
    Public iuser As String
    Public idate As DateTime
    Public uuser As String
    Public udate As DateTime
    Public NOVATsalesacc As String
    Public NOVATsalesauxb As String
    Public NOVATpurchacc As String
    Public NOVATPurchAuxb As String
    Public NOVATsalesdiscacc As String
    Public NOVATsalesdiscAuxb As String
    Public NOVATpurchdiscacc As String
    Public NOVATPurchDiscAuxb As String
    Public ExpAcc As String
    Public ExpAuxB As String
    Public ExpDiscAcc As String
    Public ExpDiscAuxb As String
    Public printlabel As Integer
End Class
Public Class ClsCategory
#Region "Fields"
    Public _CategoryCode As String
    Public _Description As String
    Public _AltDescription As String
    Public _salesacc As String
    Public _salesauxb As String
    Public _purchacc As String
    Public _PurchAuxb As String
    Public _salesdiscacc As String
    Public _salesdiscAuxb As String
    Public _purchdiscacc As String
    Public _PurchDiscAuxb As String
    Public _iuser As String
    Public _idate As DateTime
    Public _uuser As String
    Public _udate As DateTime
    Public _NOVATsalesacc As String
    Public _NOVATsalesauxb As String
    Public _NOVATpurchacc As String
    Public _NOVATPurchAuxb As String
    Public _NOVATsalesdiscacc As String
    Public _NOVATsalesdiscAuxb As String
    Public _NOVATpurchdiscacc As String
    Public _NOVATPurchDiscAuxb As String
    Public _ExpAcc As String
    Public _ExpAuxB As String
    Public _ExpDiscAcc As String
    Public _ExpDiscAuxb As String
    Public _printlabel As Integer
#End Region
#Region "Properties"
    Public Property CategoryCode() As String
        Get
            Return _CategoryCode
        End Get
        Set(ByVal Value As String)
            _CategoryCode = Value
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
    Public Property AltDescription() As String
        Get
            Return _AltDescription
        End Get
        Set(ByVal Value As String)
            _AltDescription = Value
        End Set
    End Property
    Public Property salesacc() As String
        Get
            Return _salesacc
        End Get
        Set(ByVal Value As String)
            _salesacc = Value
        End Set
    End Property
    Public Property salesauxb() As String
        Get
            Return _salesauxb
        End Get
        Set(ByVal Value As String)
            _salesauxb = Value
        End Set
    End Property
    Public Property purchacc() As String
        Get
            Return _purchacc
        End Get
        Set(ByVal Value As String)
            _purchacc = Value
        End Set
    End Property
    Public Property PurchAuxb() As String
        Get
            Return _PurchAuxb
        End Get
        Set(ByVal Value As String)
            _PurchAuxb = Value
        End Set
    End Property
    Public Property salesdiscacc() As String
        Get
            Return _salesdiscacc
        End Get
        Set(ByVal Value As String)
            _salesdiscacc = Value
        End Set
    End Property
    Public Property salesdiscAuxb() As String
        Get
            Return _salesdiscAuxb
        End Get
        Set(ByVal Value As String)
            _salesdiscAuxb = Value
        End Set
    End Property
    Public Property purchdiscacc() As String
        Get
            Return _purchdiscacc
        End Get
        Set(ByVal Value As String)
            _purchdiscacc = Value
        End Set
    End Property
    Public Property PurchDiscAuxb() As String
        Get
            Return _PurchDiscAuxb
        End Get
        Set(ByVal Value As String)
            _PurchDiscAuxb = Value
        End Set
    End Property
    Public Property iuser() As String
        Get
            Return _iuser
        End Get
        Set(ByVal Value As String)
            _iuser = Value
        End Set
    End Property
    Public Property uuser() As String
        Get
            Return _uuser
        End Get
        Set(ByVal Value As String)
            _uuser = Value
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
    Public Property udate() As DateTime
        Get
            Return _udate
        End Get
        Set(ByVal Value As DateTime)
            _udate = Value
        End Set
    End Property
    Public Property NOVATsalesacc() As String
        Get
            Return _NOVATsalesacc
        End Get
        Set(ByVal Value As String)
            _NOVATsalesacc = Value
        End Set
    End Property
    Public Property NOVATsalesauxb() As String
        Get
            Return _NOVATsalesauxb
        End Get
        Set(ByVal Value As String)
            _NOVATsalesauxb = Value
        End Set
    End Property
    Public Property NOVATpurchacc() As String
        Get
            Return _NOVATpurchacc
        End Get
        Set(ByVal Value As String)
            _NOVATpurchacc = Value
        End Set
    End Property
    Public Property NOVATPurchAuxb() As String
        Get
            Return _NOVATPurchAuxb
        End Get
        Set(ByVal Value As String)
            _NOVATPurchAuxb = Value
        End Set
    End Property
    Public Property NOVATsalesdiscacc() As String
        Get
            Return _NOVATsalesdiscacc
        End Get
        Set(ByVal Value As String)
            _NOVATsalesdiscacc = Value
        End Set
    End Property
    Public Property NOVATsalesdiscAuxb() As String
        Get
            Return _NOVATsalesdiscAuxb
        End Get
        Set(ByVal Value As String)
            _NOVATsalesdiscAuxb = Value
        End Set
    End Property
    Public Property NOVATpurchdiscacc() As String
        Get
            Return _NOVATpurchdiscacc
        End Get
        Set(ByVal Value As String)
            _NOVATpurchdiscacc = Value
        End Set
    End Property
    Public Property NOVATPurchDiscAuxb() As String
        Get
            Return _NOVATPurchDiscAuxb
        End Get
        Set(ByVal Value As String)
            _NOVATPurchDiscAuxb = Value
        End Set
    End Property
    Public Property ExpAcc() As String
        Get
            Return _ExpAcc
        End Get
        Set(ByVal Value As String)
            _ExpAcc = Value
        End Set
    End Property
    Public Property ExpAuxB() As String
        Get
            Return _ExpAuxB
        End Get
        Set(ByVal Value As String)
            _ExpAuxB = Value
        End Set
    End Property
    Public Property ExpDiscAcc() As String
        Get
            Return _ExpDiscAcc
        End Get
        Set(ByVal Value As String)
            _ExpDiscAcc = Value
        End Set
    End Property
    Public Property ExpDiscAuxb() As String
        Get
            Return _ExpDiscAuxb
        End Get
        Set(ByVal Value As String)
            _ExpDiscAuxb = Value
        End Set
    End Property
    Public Property PrintLabel() As Integer
        Get
            Return _printlabel
        End Get
        Set(ByVal Value As Integer)
            _printlabel = Value
        End Set
    End Property
#End Region
#Region "Methods"
    Dim da As New SqlDataAdapter
    Function GetNewCategories(ByVal tStamp As String, ByVal con As SqlConnection) As DataTable
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("SpRt_GetNewCategory", con)
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@CatStamp", tStamp)
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
    Function InitNewCategories(ByVal con As SqlConnection) As DataTable
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("SpRt_InitNewPosCategory", con)
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
    Public Sub InsertNewCategory(ByVal con As SqlConnection)
        Try
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("SpRt_InsertNewCategory", con)
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@CategoryCode", _CategoryCode)
            sqlcomm.Parameters.AddWithValue("@Description", _Description)
            sqlcomm.Parameters.AddWithValue("@AltDescription", _AltDescription)
            If Not blnconnectionOpen Then ConnOpen(con)
            sqlcomm.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region
End Class
