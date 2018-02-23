Imports System.Data.SqlClient
Imports ConnectionSQL
Public Class ClsJournalA
#Region "Fields"
    Public _P1 As Integer
    Public _P2 As String
    Public _P3 As Integer
    Public _P4 As String
    Public _P5 As DateTime
    Public _P6 As DateTime
    Public _P7 As Integer
    Public _P8 As Integer
    Public _P9 As String
    Public _P10 As Integer
    Public _P11 As String
    Public _P12 As String
#End Region
#Region "Properties"
    Public Property P1() As Integer
        Get
            Return _P1
        End Get
        Set(ByVal Value As Integer)
            _P1 = Value
        End Set
    End Property
    Public Property P2() As String
        Get
            Return _P2
        End Get
        Set(ByVal Value As String)
            _P2 = Value
        End Set
    End Property
    Public Property P3() As Integer
        Get
            Return _P3
        End Get
        Set(ByVal Value As Integer)
            _P3 = Value
        End Set
    End Property
    Public Property P4() As String
        Get
            Return _P4
        End Get
        Set(ByVal Value As String)
            _P4 = Value
        End Set
    End Property
    Public Property P5() As DateTime
        Get
            Return _P5
        End Get
        Set(ByVal Value As DateTime)
            _P5 = Value
        End Set
    End Property
    Public Property P6() As DateTime
        Get
            Return _P6
        End Get
        Set(ByVal Value As DateTime)
            _P6 = Value
        End Set
    End Property
    Public Property P7() As Integer
        Get
            Return _P7
        End Get
        Set(ByVal Value As Integer)
            _P7 = Value
        End Set
    End Property
    Public Property P8() As Integer
        Get
            Return _P8
        End Get
        Set(ByVal Value As Integer)
            _P8 = Value
        End Set
    End Property
    Public Property P9() As String
        Get
            Return _P9
        End Get
        Set(ByVal Value As String)
            _P9 = Value
        End Set
    End Property
    Public Property P10() As Integer
        Get
            Return _P10
        End Get
        Set(ByVal Value As Integer)
            _P10 = Value
        End Set
    End Property
    Public Property P11() As String
        Get
            Return _P11
        End Get
        Set(ByVal Value As String)
            _P11 = Value
        End Set
    End Property
    Public Property P12() As String
        Get
            Return _P12
        End Get
        Set(ByVal Value As String)
            _P12 = Value
        End Set
    End Property
#End Region
#Region "Methods"
    Public Sub JournalAInsert(ByVal con As SqlConnection)
        Try
            Dim blnconnectionOpen As Boolean = False
            Try
                Dim sqlcomm As New SqlCommand("spRs_AcJournalAInsert", con)
                sqlcomm.CommandType = CommandType.StoredProcedure
                sqlcomm.Parameters.AddWithValue("@p1", IIf(IsNothing(_P1) Or IsDBNull(_P1), DBNull.Value, _P1))
                sqlcomm.Parameters.AddWithValue("@p2", IIf(IsNothing(_P2) Or IsDBNull(_P2), DBNull.Value, _P2))
                sqlcomm.Parameters.AddWithValue("@p3", IIf(IsNothing(_P3) Or IsDBNull(_P3), DBNull.Value, _P3))
                sqlcomm.Parameters.AddWithValue("@p4", IIf(IsNothing(_P4) Or IsDBNull(_P4), DBNull.Value, _P4))
                sqlcomm.Parameters.AddWithValue("@p5", IIf(IsNothing(_P5) Or IsDBNull(_P5), DBNull.Value, _P5))
                sqlcomm.Parameters.AddWithValue("@p6", IIf(IsNothing(_P6) Or IsDBNull(_P6), DBNull.Value, _P6))
                sqlcomm.Parameters.AddWithValue("@p7", IIf(IsNothing(_P7) Or IsDBNull(_P7), DBNull.Value, _P7))
                sqlcomm.Parameters.AddWithValue("@p8", IIf(IsNothing(_P8) Or IsDBNull(_P8), DBNull.Value, _P8))
                sqlcomm.Parameters.AddWithValue("@p9", IIf(IsNothing(_P9) Or IsDBNull(_P9), DBNull.Value, _P9))
                sqlcomm.Parameters.AddWithValue("@p10", IIf(IsNothing(_P10) Or IsDBNull(_P10), DBNull.Value, _P10))
                sqlcomm.Parameters.AddWithValue("@p11", IIf(IsNothing(_P11) Or IsDBNull(_P11), DBNull.Value, _P11))
                sqlcomm.Parameters.AddWithValue("@p12", IIf(IsNothing(_P12) Or IsDBNull(_P12), DBNull.Value, _P12))
                blnconnectionOpen = ConnStatus(con)
                If Not blnconnectionOpen Then ConnOpen(con)
                sqlcomm.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub PostJournalAInsert(ByVal con As SqlConnection)
        Try
            Dim blnconnectionOpen As Boolean = False
            Try
                Dim sqlcomm As New SqlCommand("spRs_AcPostJournalAInsert", con)
                sqlcomm.CommandType = CommandType.StoredProcedure
                sqlcomm.Parameters.AddWithValue("@p1", IIf(IsNothing(_P1) Or IsDBNull(_P1), DBNull.Value, _P1))
                sqlcomm.Parameters.AddWithValue("@p2", IIf(IsNothing(_P2) Or IsDBNull(_P2), DBNull.Value, _P2))
                sqlcomm.Parameters.AddWithValue("@p3", IIf(IsNothing(_P3) Or IsDBNull(_P3), DBNull.Value, _P3))
                sqlcomm.Parameters.AddWithValue("@p4", IIf(IsNothing(_P4) Or IsDBNull(_P4), DBNull.Value, _P4))
                sqlcomm.Parameters.AddWithValue("@p5", IIf(IsNothing(_P5) Or IsDBNull(_P5), DBNull.Value, _P5))
                sqlcomm.Parameters.AddWithValue("@p6", IIf(IsNothing(_P6) Or IsDBNull(_P6), DBNull.Value, _P6))
                sqlcomm.Parameters.AddWithValue("@p7", IIf(IsNothing(_P7) Or IsDBNull(_P7), DBNull.Value, _P7))
                sqlcomm.Parameters.AddWithValue("@p8", IIf(IsNothing(_P8) Or IsDBNull(_P8), DBNull.Value, _P8))
                sqlcomm.Parameters.AddWithValue("@p9", IIf(IsNothing(_P9) Or IsDBNull(_P9), DBNull.Value, _P9))
                sqlcomm.Parameters.AddWithValue("@p10", IIf(IsNothing(_P10) Or IsDBNull(_P10), DBNull.Value, _P10))
                sqlcomm.Parameters.AddWithValue("@p11", IIf(IsNothing(_P11) Or IsDBNull(_P11), DBNull.Value, _P11))
                sqlcomm.Parameters.AddWithValue("@p12", IIf(IsNothing(_P12) Or IsDBNull(_P12), DBNull.Value, _P12))
                blnconnectionOpen = ConnStatus(con)
                If Not blnconnectionOpen Then ConnOpen(con)
                sqlcomm.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region
End Class
