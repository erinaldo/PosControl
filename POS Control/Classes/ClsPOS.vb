Imports System.Data.SqlClient
Imports ConnectionSQL
Public Class PosConf
    Public POSCode As String
    Public WhsCode As String
    Public Server As String
    Public Database As String
    Public User As String
    Public Password As String
    Public ThirdID As Integer
    Public SalesManID As Integer
End Class
Public Class ClsPOS
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet
    Public Shared i As Integer
#Region "Fields"
    Public _POSCode As String
    Public _Server As String
    Public _WhsCode As String
    Public _Database As String
    Public _User As String
    Public _Password As String
    Public _ThirdID As Integer
    Public _ThirdDesc As String
    Public _SalesManID As Integer
#End Region
#Region "Properties"
    Public Property SalesManID() As Integer
        Get
            Return _SalesManID
        End Get
        Set(ByVal Value As Integer)
            _SalesManID = Value
        End Set
    End Property
    Public Property POSCode() As String
        Get
            Return _POSCode
        End Get
        Set(ByVal Value As String)
            _POSCode = Value
        End Set
    End Property
    Public Property ThirdDesc() As String
        Get
            Return _ThirdDesc
        End Get
        Set(ByVal Value As String)
            _ThirdDesc = Value
        End Set
    End Property
    Public Property ThirdID() As Integer
        Get
            Return _ThirdID
        End Get
        Set(ByVal Value As Integer)
            _ThirdID = Value
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
    Public Property Server() As String
        Get
            Return _Server
        End Get
        Set(ByVal Value As String)
            _Server = Value
        End Set
    End Property
    Public Property Database() As String
        Get
            Return _Database
        End Get
        Set(ByVal Value As String)
            _Database = Value
        End Set
    End Property
    Public Property User() As String
        Get
            Return _User
        End Get
        Set(ByVal Value As String)
            _User = Value
        End Set
    End Property
    Public Property Password() As String
        Get
            Return _Password
        End Get
        Set(ByVal Value As String)
            _Password = Value
        End Set
    End Property
#End Region
#Region "Methods"
    Function FillWHS(ByVal con As SqlConnection) As DataTable
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("Select WhsCode,Description from IvWhs1ES order by WhsCode", con)
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
    Function FillPOS(ByVal con As SqlConnection) As DataTable
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("Select POSCode,Description from IvPos1ES order by POSCode", con)
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
    Public Function GetPosConfig(ByVal con As SqlConnection) As DataTable
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("Select * from PolyPosConf order by PosCode", con)
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
    Public Function GetWhsConfig(ByVal con As SqlConnection) As DataTable
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("Select WhsCode from PolyPosConf order by WhsCode", con)
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
    Public Sub FillPosConfig(ByVal con As SqlConnection)
        Try
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("Select * from PolyPosConf", con)
            da = New SqlDataAdapter(sqlcomm)
            ds.Clear()
            blnconnectionOpen = ConnStatus(con)
            If Not blnconnectionOpen Then ConnOpen(con)
            da.Fill(ds, "PosConf")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Function GetLastPOS(ByRef vErr As String) As PosConf
        Try
            Dim PosConf As New PosConf
            If ds.Tables("PosConf").Rows.Count = 0 Then
                PosConf = Nothing
                vErr = "No PosConf To Load"
                Return PosConf
                Exit Function
            End If
            i = ds.Tables("PosConf").Rows.Count - 1
            PosConf.POSCode = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("POSCode").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("POSCode").ToString), _
                                    Nothing, ds.Tables("PosConf").Rows(i)("POSCode").ToString)
            PosConf.Server = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("PosServer").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("PosServer").ToString), _
                                   "", ds.Tables("PosConf").Rows(i)("PosServer").ToString)
            PosConf.Database = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("PosDatabase").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("PosDatabase").ToString), _
                                     "", ds.Tables("PosConf").Rows(i)("PosDatabase").ToString)
            PosConf.User = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("PosUser").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("PosUser").ToString), _
                                     Nothing, ds.Tables("PosConf").Rows(i)("PosUser").ToString)
            PosConf.Password = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("PosPass").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("PosPass").ToString), _
                                     "", ds.Tables("PosConf").Rows(i)("PosPass").ToString)
            PosConf.WhsCode = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("WhsCode").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("WhsCode").ToString), _
                                     "", ds.Tables("PosConf").Rows(i)("WhsCode").ToString)
            PosConf.ThirdID = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("ThirdID").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("ThirdID").ToString), _
                                     "", ds.Tables("PosConf").Rows(i)("ThirdID").ToString)
            PosConf.SalesManID = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("SalesManID").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("SalesManID").ToString), _
                                      "", ds.Tables("PosConf").Rows(i)("SalesManID").ToString)
            Return PosConf
        Catch ex As Exception
            vErr = ex.Message
        End Try
    End Function
    Public Function GetFirstPOS(ByRef vErr As String) As PosConf
        Try
            Dim PosConf As New PosConf
            If ds.Tables("PosConf").Rows.Count = 0 Then
                PosConf = Nothing
                vErr = "No PosConf To Load"
                Return PosConf
                Exit Function
            End If
            i = 0
            PosConf.POSCode = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("POSCode").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("POSCode").ToString), _
                                    Nothing, ds.Tables("PosConf").Rows(i)("POSCode").ToString)
            PosConf.Server = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("PosServer").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("PosServer").ToString), _
                                   "", ds.Tables("PosConf").Rows(i)("PosServer").ToString)
            PosConf.Database = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("PosDatabase").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("PosDatabase").ToString), _
                                     "", ds.Tables("PosConf").Rows(i)("PosDatabase").ToString)
            PosConf.User = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("PosUser").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("PosUser").ToString), _
                                     Nothing, ds.Tables("PosConf").Rows(i)("PosUser").ToString)
            PosConf.Password = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("PosPass").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("PosPass").ToString), _
                                     "", ds.Tables("PosConf").Rows(i)("PosPass").ToString)
            PosConf.WhsCode = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("WhsCode").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("WhsCode").ToString), _
                                     "", ds.Tables("PosConf").Rows(i)("WhsCode").ToString)
            PosConf.ThirdID = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("ThirdID").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("ThirdID").ToString), _
                                     "", ds.Tables("PosConf").Rows(i)("ThirdID").ToString)
            PosConf.SalesManID = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("SalesManID").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("SalesManID").ToString), _
                                     "", ds.Tables("PosConf").Rows(i)("SalesManID").ToString)
            Return PosConf
        Catch ex As Exception
            vErr = ex.Message
        End Try
    End Function
    Public Function GetNextPOS(ByRef vErr As String) As PosConf
        Try
            Dim PosConf As New PosConf
            If ds.Tables("PosConf").Rows.Count = 0 Then
                PosConf = Nothing
                vErr = "No PosConf To Load"
                Return PosConf
                Exit Function
            End If
            If (i < ds.Tables("PosConf").Rows.Count - 1) Then
                i = i + 1
                PosConf.POSCode = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("POSCode").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("POSCode").ToString), _
                                        Nothing, ds.Tables("PosConf").Rows(i)("POSCode").ToString)
                PosConf.Server = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("PosServer").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("PosServer").ToString), _
                                       "", ds.Tables("PosConf").Rows(i)("PosServer").ToString)
                PosConf.Database = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("PosDatabase").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("PosDatabase").ToString), _
                                         "", ds.Tables("PosConf").Rows(i)("PosDatabase").ToString)
                PosConf.User = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("PosUser").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("PosUser").ToString), _
                                         Nothing, ds.Tables("PosConf").Rows(i)("PosUser").ToString)
                PosConf.Password = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("PosPass").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("PosPass").ToString), _
                                         "", ds.Tables("PosConf").Rows(i)("PosPass").ToString)
                PosConf.WhsCode = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("WhsCode").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("WhsCode").ToString), _
                                         "", ds.Tables("PosConf").Rows(i)("WhsCode").ToString)
                PosConf.ThirdID = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("ThirdID").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("ThirdID").ToString), _
                                         "", ds.Tables("PosConf").Rows(i)("ThirdID").ToString)
                PosConf.SalesManID = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("SalesManID").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("SalesManID").ToString), _
                                         "", ds.Tables("PosConf").Rows(i)("SalesManID").ToString)
                Return PosConf
            Else
                PosConf.POSCode = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("POSCode").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("POSCode").ToString), _
                                        Nothing, ds.Tables("PosConf").Rows(i)("POSCode").ToString)
                PosConf.Server = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("PosServer").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("PosServer").ToString), _
                                       "", ds.Tables("PosConf").Rows(i)("PosServer").ToString)
                PosConf.Database = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("PosDatabase").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("PosDatabase").ToString), _
                                         "", ds.Tables("PosConf").Rows(i)("PosDatabase").ToString)
                PosConf.User = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("PosUser").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("PosUser").ToString), _
                                         Nothing, ds.Tables("PosConf").Rows(i)("PosUser").ToString)
                PosConf.Password = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("PosPass").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("PosPass").ToString), _
                                         "", ds.Tables("PosConf").Rows(i)("PosPass").ToString)
                PosConf.WhsCode = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("WhsCode").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("WhsCode").ToString), _
                                         "", ds.Tables("PosConf").Rows(i)("WhsCode").ToString)
                PosConf.ThirdID = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("ThirdID").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("ThirdID").ToString), _
                                         "", ds.Tables("PosConf").Rows(i)("ThirdID").ToString)
                PosConf.SalesManID = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("SalesManID").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("SalesManID").ToString), _
                                         "", ds.Tables("PosConf").Rows(i)("SalesManID").ToString)
                Return PosConf
            End If
        Catch ex As Exception
            vErr = ex.Message
        End Try
    End Function
    Public Function GetPrevPOS(ByRef vErr As String) As PosConf
        Try
            Dim PosConf As New PosConf
            If ds.Tables("PosConf").Rows.Count = 0 Then
                PosConf = Nothing
                vErr = "No PosConf To Load"
                Return PosConf
                Exit Function
            End If
            If (i > ds.Tables("PosConf").Rows.Count - 1 Or i <> 0) Then
                i = i - 1
                PosConf.POSCode = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("POSCode").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("POSCode").ToString), _
                                        Nothing, ds.Tables("PosConf").Rows(i)("POSCode").ToString)
                PosConf.Server = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("PosServer").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("PosServer").ToString), _
                                       "", ds.Tables("PosConf").Rows(i)("PosServer").ToString)
                PosConf.Database = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("PosDatabase").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("PosDatabase").ToString), _
                                         "", ds.Tables("PosConf").Rows(i)("PosDatabase").ToString)
                PosConf.User = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("PosUser").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("PosUser").ToString), _
                                         Nothing, ds.Tables("PosConf").Rows(i)("PosUser").ToString)
                PosConf.Password = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("PosPass").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("PosPass").ToString), _
                                         "", ds.Tables("PosConf").Rows(i)("PosPass").ToString)
                PosConf.WhsCode = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("WhsCode").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("WhsCode").ToString), _
                                         "", ds.Tables("PosConf").Rows(i)("WhsCode").ToString)
                PosConf.ThirdID = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("ThirdID").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("ThirdID").ToString), _
                                         "", ds.Tables("PosConf").Rows(i)("ThirdID").ToString)
                PosConf.SalesManID = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("SalesManID").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("SalesManID").ToString), _
                                         "", ds.Tables("PosConf").Rows(i)("SalesManID").ToString)
                Return PosConf
            Else
                PosConf.POSCode = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("POSCode").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("POSCode").ToString), _
                                        Nothing, ds.Tables("PosConf").Rows(i)("POSCode").ToString)
                PosConf.Server = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("PosServer").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("PosServer").ToString), _
                                       "", ds.Tables("PosConf").Rows(i)("PosServer").ToString)
                PosConf.Database = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("PosDatabase").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("PosDatabase").ToString), _
                                         "", ds.Tables("PosConf").Rows(i)("PosDatabase").ToString)
                PosConf.User = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("PosUser").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("PosUser").ToString), _
                                         Nothing, ds.Tables("PosConf").Rows(i)("PosUser").ToString)
                PosConf.Password = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("PosPass").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("PosPass").ToString), _
                                         "", ds.Tables("PosConf").Rows(i)("PosPass").ToString)
                PosConf.WhsCode = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("WhsCode").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("WhsCode").ToString), _
                                         "", ds.Tables("PosConf").Rows(i)("WhsCode").ToString)
                PosConf.ThirdID = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("ThirdID").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("ThirdID").ToString), _
                                         "", ds.Tables("PosConf").Rows(i)("ThirdID").ToString)
                PosConf.SalesManID = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("SalesManID").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("SalesManID").ToString), _
                                         "", ds.Tables("PosConf").Rows(i)("SalesManID").ToString)
                Return PosConf
            End If
        Catch ex As Exception
            vErr = ex.Message
        End Try
    End Function
    Public Function GetCurrentRecord(ByVal Index As Integer, ByRef vErr As String) As PosConf
        Try
            Dim PosConf As New PosConf
            If ds.Tables("PosConf").Rows.Count = 0 Then
                PosConf = Nothing
                vErr = "No PosConf To Load"
                Return PosConf
                Exit Function
            End If
            i = Index
            PosConf.POSCode = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("POSCode").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("POSCode").ToString), _
                                    Nothing, ds.Tables("PosConf").Rows(i)("POSCode").ToString)
            PosConf.Server = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("PosServer").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("PosServer").ToString), _
                                   "", ds.Tables("PosConf").Rows(i)("PosServer").ToString)
            PosConf.Database = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("PosDatabase").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("PosDatabase").ToString), _
                                     "", ds.Tables("PosConf").Rows(i)("PosDatabase").ToString)
            PosConf.User = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("PosUser").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("PosUser").ToString), _
                                     Nothing, ds.Tables("PosConf").Rows(i)("PosUser").ToString)
            PosConf.Password = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("PosPass").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("PosPass").ToString), _
                                     "", ds.Tables("PosConf").Rows(i)("PosPass").ToString)
            PosConf.WhsCode = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("WhsCode").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("WhsCode").ToString), _
                                     "", ds.Tables("PosConf").Rows(i)("WhsCode").ToString)
            PosConf.ThirdID = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("ThirdID").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("ThirdID").ToString), _
                                     "", ds.Tables("PosConf").Rows(i)("ThirdID").ToString)
            PosConf.SalesManID = IIf(IsDBNull(ds.Tables("PosConf").Rows(i)("SalesManID").ToString) Or IsNothing(ds.Tables("PosConf").Rows(i)("SalesManID").ToString), _
                                     "", ds.Tables("PosConf").Rows(i)("SalesManID").ToString)
            Return PosConf
        Catch ex As Exception
            vErr = ex.Message
        End Try
    End Function
    Public Sub DeletePosConf(ByVal PosCode As String, ByVal Conn As SqlConnection)
        Try
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("delete from PolyPosConf where PosCode = '" & PosCode & "'", Conn)
            blnconnectionOpen = ConnStatus(Conn)
            If Not blnconnectionOpen Then ConnOpen(Conn)
            sqlcomm.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub SavePosConf(ByVal conn As SqlConnection)
        Try
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("SpRt_PosConfInsert", conn)
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@PosCode", _POSCode)
            sqlcomm.Parameters.AddWithValue("@WhsCode", _WhsCode)
            sqlcomm.Parameters.AddWithValue("@PosServer", _Server)
            sqlcomm.Parameters.AddWithValue("@PosUser", _User)
            sqlcomm.Parameters.AddWithValue("@PosDB", _Database)
            sqlcomm.Parameters.AddWithValue("@ThirdID", _ThirdID)
            sqlcomm.Parameters.AddWithValue("@SalesManID", _SalesManID)
            sqlcomm.Parameters.AddWithValue("@PosPass", _Password)
            blnconnectionOpen = ConnStatus(conn)
            If Not blnconnectionOpen Then ConnOpen(conn)
            sqlcomm.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub UpdatePosConf(ByVal con As SqlConnection)
        Try
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("SpRt_PosConfUpdate", con)
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@PosCode", _POSCode)
            sqlcomm.Parameters.AddWithValue("@PosServer", _Server)
            sqlcomm.Parameters.AddWithValue("@WhsCode", _WhsCode)
            sqlcomm.Parameters.AddWithValue("@PosUser", _User)
            sqlcomm.Parameters.AddWithValue("@PosDB", _Database)
            sqlcomm.Parameters.AddWithValue("@SalesManID", _SalesManID)
            sqlcomm.Parameters.AddWithValue("@ThirdID", _ThirdID)
            sqlcomm.Parameters.AddWithValue("@PosPass", _Password)
            blnconnectionOpen = ConnStatus(con)
            If Not blnconnectionOpen Then ConnOpen(con)
            sqlcomm.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region
End Class
