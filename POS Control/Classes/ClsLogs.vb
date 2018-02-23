Imports System.Data.SqlClient
Public Class LogSettings
    Public LogID As Integer
    Public PosCode As String
    Public BackOffice As String
    Public FunctionN As String
    Public Sql As String
    Public Desc As String
    Public iDate As DateTime
    Public Cleared As Boolean
End Class
Public Class ClsLogs
#Region "Fields"
    Public _LogID As Integer
    Public _PosCode As String
    Public _BackOffice As String
    Public _FunctionN As String
    Public _Desc As String
    Public _Sql As String
    Public _iDate As DateTime
    Public _Cleared As Boolean
#End Region
#Region "Properties"
    Public Property LogID() As Integer
        Get
            Return _LogID
        End Get
        Set(ByVal value As Integer)
            _LogID = value
        End Set
    End Property
    Public Property PosCode() As String
        Get
            Return _PosCode
        End Get
        Set(ByVal value As String)
            _PosCode = value
        End Set
    End Property
    Public Property Backoffice() As String
        Get
            Return _BackOffice
        End Get
        Set(ByVal value As String)
            _BackOffice = value
        End Set
    End Property
    Public Property FunctionN() As String
        Get
            Return _FunctionN
        End Get
        Set(ByVal value As String)
            _FunctionN = value
        End Set
    End Property
    Public Property Desc() As String
        Get
            Return _Desc
        End Get
        Set(ByVal value As String)
            _Desc = value
        End Set
    End Property
    Public Property iDate() As DateTime
        Get
            Return _iDate
        End Get
        Set(ByVal value As DateTime)
            _iDate = value
        End Set
    End Property
    Public Property Cleared() As Boolean
        Get
            Return _Cleared
        End Get
        Set(ByVal value As Boolean)
            _Cleared = value
        End Set
    End Property
    Public Property SQL() As String
        Get
            Return _Sql
        End Get
        Set(ByVal value As String)
            _Sql = value
        End Set
    End Property
#End Region
#Region "Methods"
    Public Sub WriteToTable(ByVal Con As SqlConnection)
        Try
            Dim SqlCom As New SqlCommand("SpRt_InsertLog", Con)
            SqlCom.CommandType = CommandType.StoredProcedure
            SqlCom.Parameters.AddWithValue("@POSCode", _PosCode)
            SqlCom.Parameters.AddWithValue("@BackOffice", _BackOffice)
            SqlCom.Parameters.AddWithValue("@FunctionName", _FunctionN)
            SqlCom.Parameters.AddWithValue("@Description", _Desc)
            SqlCom.Parameters.AddWithValue("@SQL", _Sql)
            SqlCom.Parameters.AddWithValue("@iDate", Format(Now, "dd/MM/yyyy hh:mm"))
            If Con.State = ConnectionState.Closed Then
                Con.Open()
            End If
            SqlCom.ExecuteNonQuery()
        Catch e As Exception
        End Try
    End Sub
#End Region
End Class
