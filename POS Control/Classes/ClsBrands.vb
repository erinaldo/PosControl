Imports System.Data.SqlClient
Imports ConnectionSQL
Public Class BrandSettings
    Public BrandCode As String
    Public Description As String
    Public AltDescription As String
End Class
Public Class ClsBrand
#Region "Fields"
    Public _BrandCode As String
    Public _Description As String
    Public _AltDescription As String
#End Region
#Region "Properties"
    Public Property BrandCode() As String
        Get
            Return _BrandCode
        End Get
        Set(ByVal Value As String)
            _BrandCode = Value
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
#End Region
#Region "Methods"
    Dim da As New SqlDataAdapter
    Function GetNewBrands(ByVal tStamp As String, ByVal con As SqlConnection) As DataTable
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("SpRt_GetNewBrands", con)
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@BrandStamp", tStamp)
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
    Function InitNewBrands(ByVal con As SqlConnection) As DataTable
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("SpRt_InitNewPosBrand", con)
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
    Public Sub InsertNewBrand(ByVal con As SqlConnection)
        Try
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("SpRt_InsertNewBrand", con)
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@BrandCode", _BrandCode)
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
