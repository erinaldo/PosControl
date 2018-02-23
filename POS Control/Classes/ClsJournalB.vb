Imports System.Data.SqlClient
Imports ConnectionSQL
Public Class ClsJournalB
    Dim da As New SqlDataAdapter
#Region "Fields"
    Public _P1 As Integer
    Public _P2 As Integer
    Public _P3 As Integer
    Public _P4 As String
    Public _P5 As String
    Public _P6 As Object
    Public _P7 As Object
    Public _P8 As Integer
    Public _P9 As Object
    Public _P10 As Object
    Public _P11 As String
    Public _P12 As String
    Public _P13 As Double
    Public _P14 As Double
    Public _P15 As Double
    Public _P16 As Double
    Public _P17 As String
    Public _P18 As Object
    Public _P19 As Object
    Public _P20 As Object
    Public _P21 As Object
    Public _P22 As String
    Public _P23 As DateTime
    Public _P24 As String
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
    Public Property P2() As Integer
        Get
            Return _P2
        End Get
        Set(ByVal Value As Integer)
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
    Public Property P5() As String
        Get
            Return _P5
        End Get
        Set(ByVal Value As String)
            _P5 = Value
        End Set
    End Property
    Public Property P6() As String
        Get
            Return _P6
        End Get
        Set(ByVal Value As String)
            _P6 = Value
        End Set
    End Property
    Public Property P7() As String
        Get
            Return _P7
        End Get
        Set(ByVal Value As String)
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
    Public Property P9() As Integer
        Get
            Return _P9
        End Get
        Set(ByVal Value As Integer)
            _P9 = Value
        End Set
    End Property
    Public Property P10() As String
        Get
            Return _P10
        End Get
        Set(ByVal Value As String)
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
    Public Property P13() As Double
        Get
            Return _P13
        End Get
        Set(ByVal Value As Double)
            _P13 = Value
        End Set
    End Property
    Public Property P14() As Double
        Get
            Return _P14
        End Get
        Set(ByVal Value As Double)
            _P14 = Value
        End Set
    End Property
    Public Property P15() As Double
        Get
            Return _P15
        End Get
        Set(ByVal Value As Double)
            _P15 = Value
        End Set
    End Property
    Public Property P16() As Double
        Get
            Return _P16
        End Get
        Set(ByVal Value As Double)
            _P16 = Value
        End Set
    End Property
    Public Property P17() As String
        Get
            Return _P17
        End Get
        Set(ByVal Value As String)
            _P17 = Value
        End Set
    End Property
    Public Property P18() As DateTime
        Get
            Return _P18
        End Get
        Set(ByVal Value As DateTime)
            _P18 = Value
        End Set
    End Property
    Public Property P19() As String
        Get
            Return _P19
        End Get
        Set(ByVal Value As String)
            _P19 = Value
        End Set
    End Property
    Public Property P20() As String
        Get
            Return _P20
        End Get
        Set(ByVal Value As String)
            _P20 = Value
        End Set
    End Property
    Public Property P21() As String
        Get
            Return _P21
        End Get
        Set(ByVal Value As String)
            _P21 = Value
        End Set
    End Property
    Public Property P22() As String
        Get
            Return _P22
        End Get
        Set(ByVal Value As String)
            _P22 = Value
        End Set
    End Property
    Public Property P23() As DateTime
        Get
            Return _P23
        End Get
        Set(ByVal Value As DateTime)
            _P23 = Value
        End Set
    End Property
    Public Property P24() As String
        Get
            Return _P24
        End Get
        Set(ByVal Value As String)
            _P24 = Value
        End Set
    End Property
#End Region
#Region "Methods"
    Public Sub JournalBInsert(ByVal con As SqlConnection)
        Try
            Dim blnconnectionOpen As Boolean = False
            Try
                Dim sqlcomm As New SqlCommand("spRs_AcJournalBInsert", con)
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
                sqlcomm.Parameters.AddWithValue("@p13", IIf(IsNothing(_P13) Or IsDBNull(_P13), DBNull.Value, _P13))
                sqlcomm.Parameters.AddWithValue("@p14", IIf(IsNothing(_P14) Or IsDBNull(_P14), DBNull.Value, _P14))
                sqlcomm.Parameters.AddWithValue("@p15", IIf(IsNothing(_P15) Or IsDBNull(_P15), DBNull.Value, _P15))
                sqlcomm.Parameters.AddWithValue("@p16", IIf(IsNothing(_P16) Or IsDBNull(_P16), DBNull.Value, _P16))
                sqlcomm.Parameters.AddWithValue("@p17", IIf(IsNothing(_P17) Or IsDBNull(_P17), DBNull.Value, _P17))
                sqlcomm.Parameters.AddWithValue("@p18", IIf(IsNothing(_P18) Or IsDBNull(_P18), DBNull.Value, _P18))
                sqlcomm.Parameters.AddWithValue("@p19", IIf(IsNothing(_P19) Or IsDBNull(_P19), DBNull.Value, _P19))
                sqlcomm.Parameters.AddWithValue("@p20", IIf(IsNothing(_P20) Or IsDBNull(_P20), DBNull.Value, _P20))
                sqlcomm.Parameters.AddWithValue("@p21", IIf(IsNothing(_P21) Or IsDBNull(_P21), DBNull.Value, _P21))
                sqlcomm.Parameters.AddWithValue("@p22", IIf(IsNothing(_P22) Or IsDBNull(_P22), DBNull.Value, _P22))
                sqlcomm.Parameters.AddWithValue("@p23", IIf(IsNothing(_P23) Or IsDBNull(_P23), DBNull.Value, _P23))
                sqlcomm.Parameters.AddWithValue("@p24", IIf(IsNothing(_P24) Or IsDBNull(_P24), DBNull.Value, _P24))
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
    Public Sub PostJournalBInsert(ByVal con As SqlConnection)
        Try
            Dim blnconnectionOpen As Boolean = False
            Try
                Dim sqlcomm As New SqlCommand("spRs_AcPostJournalBInsert", con)
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
                sqlcomm.Parameters.AddWithValue("@p13", IIf(IsNothing(_P13) Or IsDBNull(_P13), DBNull.Value, _P13))
                sqlcomm.Parameters.AddWithValue("@p14", IIf(IsNothing(_P14) Or IsDBNull(_P14), DBNull.Value, _P14))
                sqlcomm.Parameters.AddWithValue("@p15", IIf(IsNothing(_P15) Or IsDBNull(_P15), DBNull.Value, _P15))
                sqlcomm.Parameters.AddWithValue("@p16", IIf(IsNothing(_P16) Or IsDBNull(_P16), DBNull.Value, _P16))
                sqlcomm.Parameters.AddWithValue("@p17", IIf(IsNothing(_P17) Or IsDBNull(_P17), DBNull.Value, _P17))
                sqlcomm.Parameters.AddWithValue("@p18", IIf(IsNothing(_P18) Or IsDBNull(_P18), DBNull.Value, _P18))
                sqlcomm.Parameters.AddWithValue("@p19", IIf(IsNothing(_P19) Or IsDBNull(_P19), DBNull.Value, _P19))
                sqlcomm.Parameters.AddWithValue("@p20", IIf(IsNothing(_P20) Or IsDBNull(_P20), DBNull.Value, _P20))
                sqlcomm.Parameters.AddWithValue("@p21", IIf(IsNothing(_P21) Or IsDBNull(_P21), DBNull.Value, _P21))
                sqlcomm.Parameters.AddWithValue("@p22", IIf(IsNothing(_P22) Or IsDBNull(_P22), DBNull.Value, _P22))
                sqlcomm.Parameters.AddWithValue("@p23", IIf(IsNothing(_P23) Or IsDBNull(_P23), DBNull.Value, _P23))
                sqlcomm.Parameters.AddWithValue("@p24", IIf(IsNothing(_P24) Or IsDBNull(_P24), DBNull.Value, _P24))
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
    Public Sub BoJournalBInsert(ByVal PosCode As String, ByVal con As SqlConnection)
        Try
            Dim blnconnectionOpen As Boolean = False
            Try
                Dim sqlcomm As New SqlCommand("SpRt_BoRecieptsBInsert", con)
                sqlcomm.CommandType = CommandType.StoredProcedure
                sqlcomm.Parameters.AddWithValue("@p1", IIf(IsNothing(_P1) Or IsDBNull(_P1), DBNull.Value, _P1))
                sqlcomm.Parameters.AddWithValue("@p2", IIf(IsNothing(_P2) Or IsDBNull(_P2), DBNull.Value, _P2))
                sqlcomm.Parameters.AddWithValue("@PosCode", IIf(IsNothing(PosCode) Or IsDBNull(PosCode), DBNull.Value, PosCode))
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
                sqlcomm.Parameters.AddWithValue("@p13", IIf(IsNothing(_P13) Or IsDBNull(_P13), DBNull.Value, _P13))
                sqlcomm.Parameters.AddWithValue("@p14", IIf(IsNothing(_P14) Or IsDBNull(_P14), DBNull.Value, _P14))
                sqlcomm.Parameters.AddWithValue("@p15", IIf(IsNothing(_P15) Or IsDBNull(_P15), DBNull.Value, _P15))
                sqlcomm.Parameters.AddWithValue("@p16", IIf(IsNothing(_P16) Or IsDBNull(_P16), DBNull.Value, _P16))
                sqlcomm.Parameters.AddWithValue("@p17", IIf(IsNothing(_P17) Or IsDBNull(_P17), DBNull.Value, _P17))
                sqlcomm.Parameters.AddWithValue("@p18", IIf(IsNothing(_P18) Or IsDBNull(_P18), DBNull.Value, _P18))
                sqlcomm.Parameters.AddWithValue("@p19", IIf(IsNothing(_P19) Or IsDBNull(_P19), DBNull.Value, _P19))
                sqlcomm.Parameters.AddWithValue("@p20", IIf(IsNothing(_P20) Or IsDBNull(_P20), DBNull.Value, _P20))
                sqlcomm.Parameters.AddWithValue("@p21", IIf(IsNothing(_P21) Or IsDBNull(_P21), DBNull.Value, _P21))
                sqlcomm.Parameters.AddWithValue("@p22", IIf(IsNothing(_P22) Or IsDBNull(_P22), DBNull.Value, _P22))
                sqlcomm.Parameters.AddWithValue("@p23", IIf(IsNothing(_P23) Or IsDBNull(_P23), DBNull.Value, _P23))
                sqlcomm.Parameters.AddWithValue("@p24", IIf(IsNothing(_P24) Or IsDBNull(_P24), DBNull.Value, _P24))
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
    Public Function GetReciept(ByVal TransID As Integer, ByVal PosCode As String, ByVal con As SqlConnection) As DataTable
        Try
            Dim blnconnectionOpen As Boolean = False
            Dim sqlcomm As New SqlCommand("SpRt_BoRecieptsGet", con)
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@TransID", TransID)
            sqlcomm.Parameters.AddWithValue("@PosCode", PosCode)
            da = New SqlDataAdapter(sqlcomm)
            Dim dt As New DataTable
            da.Fill(dt)
            Return dt
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Public Sub UpdateReciept(ByVal TransID As Integer, ByVal POSCode As String, ByVal LigneID As Integer, _
                                  ByVal AccCode As String, ByVal AuxBCode As String, _
                                   ByVal CurCode As String, ByVal Amount As Decimal, _
                                   ByVal FL_Amount As Decimal, ByVal SL_Amount As Decimal, _
                                    ByVal CheckMaturity As DateTime, ByVal checkNbr As String, ByVal CheckBank As String, ByVal con As SqlConnection)
        Try
            Dim blnconnectionOpen As Boolean = False
            Dim sqlcomm As New SqlCommand("SpRt_BoRecieptsUpdate", con)
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@TransID", TransID)
            sqlcomm.Parameters.AddWithValue("@POSCode", POSCode)
            sqlcomm.Parameters.AddWithValue("@LigneID", LigneID)
            sqlcomm.Parameters.AddWithValue("@AccCode", AccCode)
            sqlcomm.Parameters.AddWithValue("@AuxBCode", AuxBCode)
            sqlcomm.Parameters.AddWithValue("@CurCode", CurCode)
            sqlcomm.Parameters.AddWithValue("@Amount", Amount)
            sqlcomm.Parameters.AddWithValue("@FL_Amount", FL_Amount)
            sqlcomm.Parameters.AddWithValue("@SL_Amount", SL_Amount)
            sqlcomm.Parameters.AddWithValue("@CheckMaturity", CheckMaturity)
            sqlcomm.Parameters.AddWithValue("@checkNbr", checkNbr)
            sqlcomm.Parameters.AddWithValue("@CheckBank", CheckBank)
            blnconnectionOpen = ConnStatus(con)
            If Not blnconnectionOpen Then ConnOpen(con)
            sqlcomm.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region
End Class
