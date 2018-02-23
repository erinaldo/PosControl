Imports System.Data.SqlClient
Imports ConnectionSQL
Public Class ClsOperationB
#Region "Fields"
    Public _P1 As Integer
    Public _P2 As Integer
    Public _P3 As Integer
    Public _P4 As Integer
    Public _P5 As Integer
    Public _P6 As String
    Public _P7 As String
    Public _P8 As String
    Public _P9 As Object
    Public _P10 As Object
    Public _PosCode As String
    Public _P11 As String
    Public _P12 As Object
    Public _P13 As Integer
    Public _P14 As Integer
    Public _P15 As Double
    Public _P16 As Double
    Public _P17 As Double
    Public _P18 As Double
    Public _P19 As Double
    Public _P20 As String
    Public _P21 As Double
    Public _P22 As Integer
    Public _P23 As Double
    Public _P24 As Double
    Public _P25 As Double
    Public _P26 As Double
    Public _P27 As Double
    Public _P28 As Double
    Public _P29 As Double
    Public _P30 As Double
    Public _P31 As Double
    Public _P32 As Double
    Public _P33 As Double
    Public _P34 As Double
    Public _P35 As Object
    Public _P36 As Object
    Public _P37 As Object
    Public _P38 As String
    Public _P39 As Object
    Public _P40 As Object
    Public _P41 As Object
    Public _P42 As Object
    Public _P43 As Integer
    Public _P44 As Object
    Public _P45 As Object
#End Region
#Region "Properties"
    Public Property PosCode() As String
        Get
            Return _PosCode
        End Get
        Set(ByVal Value As String)
            _PosCode = Value
        End Set
    End Property
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
    Public Property P4() As Integer
        Get
            Return _P4
        End Get
        Set(ByVal Value As Integer)
            _P4 = Value
        End Set
    End Property
    Public Property P5() As Integer
        Get
            Return _P5
        End Get
        Set(ByVal Value As Integer)
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
    Public Property P8() As String
        Get
            Return _P8
        End Get
        Set(ByVal Value As String)
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
    Public Property P12() As Integer
        Get
            Return _P12
        End Get
        Set(ByVal Value As Integer)
            _P12 = Value
        End Set
    End Property
    Public Property P13() As Integer
        Get
            Return _P13
        End Get
        Set(ByVal Value As Integer)
            _P13 = Value
        End Set
    End Property
    Public Property P14() As Integer
        Get
            Return _P14
        End Get
        Set(ByVal Value As Integer)
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
    Public Property P17() As Double
        Get
            Return _P17
        End Get
        Set(ByVal Value As Double)
            _P17 = Value
        End Set
    End Property
    Public Property P18() As Double
        Get
            Return _P18
        End Get
        Set(ByVal Value As Double)
            _P18 = Value
        End Set
    End Property
    Public Property P19() As Double
        Get
            Return _P19
        End Get
        Set(ByVal Value As Double)
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
    Public Property P21() As Double
        Get
            Return _P21
        End Get
        Set(ByVal Value As Double)
            _P21 = Value
        End Set
    End Property
    Public Property P22() As Integer
        Get
            Return _P22
        End Get
        Set(ByVal Value As Integer)
            _P22 = Value
        End Set
    End Property
    Public Property P23() As Double
        Get
            Return _P23
        End Get
        Set(ByVal Value As Double)
            _P23 = Value
        End Set
    End Property
    Public Property P24() As Double
        Get
            Return _P24
        End Get
        Set(ByVal Value As Double)
            _P24 = Value
        End Set
    End Property
    Public Property P25() As Double
        Get
            Return _P25
        End Get
        Set(ByVal Value As Double)
            _P25 = Value
        End Set
    End Property
    Public Property P26() As Double
        Get
            Return _P26
        End Get
        Set(ByVal Value As Double)
            _P26 = Value
        End Set
    End Property
    Public Property P27() As Double
        Get
            Return _P27
        End Get
        Set(ByVal Value As Double)
            _P27 = Value
        End Set
    End Property
    Public Property P28() As Double
        Get
            Return _P28
        End Get
        Set(ByVal Value As Double)
            _P28 = Value
        End Set
    End Property
    Public Property P29() As Double
        Get
            Return _P29
        End Get
        Set(ByVal Value As Double)
            _P29 = Value
        End Set
    End Property
    Public Property P30() As Double
        Get
            Return _P30
        End Get
        Set(ByVal Value As Double)
            _P30 = Value
        End Set
    End Property
    Public Property P31() As Double
        Get
            Return _P31
        End Get
        Set(ByVal Value As Double)
            _P31 = Value
        End Set
    End Property
    Public Property P32() As Double
        Get
            Return _P32
        End Get
        Set(ByVal Value As Double)
            _P32 = Value
        End Set
    End Property
    Public Property P33() As Double
        Get
            Return _P33
        End Get
        Set(ByVal Value As Double)
            _P33 = Value
        End Set
    End Property
    Public Property P34() As Double
        Get
            Return _P34
        End Get
        Set(ByVal Value As Double)
            _P34 = Value
        End Set
    End Property
    Public Property P35() As Integer
        Get
            Return _P35
        End Get
        Set(ByVal Value As Integer)
            _P35 = Value
        End Set
    End Property
    Public Property P36() As Integer
        Get
            Return _P36
        End Get
        Set(ByVal Value As Integer)
            _P36 = Value
        End Set
    End Property
    Public Property P37() As Integer
        Get
            Return _P37
        End Get
        Set(ByVal Value As Integer)
            _P37 = Value
        End Set
    End Property
    Public Property P38() As String
        Get
            Return _P38
        End Get
        Set(ByVal Value As String)
            _P38 = Value
        End Set
    End Property
    Public Property P39() As DateTime
        Get
            Return _P39
        End Get
        Set(ByVal Value As DateTime)
            _P39 = Value
        End Set
    End Property
    Public Property P40() As String
        Get
            Return _P40
        End Get
        Set(ByVal Value As String)
            _P40 = Value
        End Set
    End Property
    Public Property P41() As Integer
        Get
            Return _P41
        End Get
        Set(ByVal Value As Integer)
            _P41 = Value
        End Set
    End Property
    Public Property P42() As String
        Get
            Return _P42
        End Get
        Set(ByVal Value As String)
            _P42 = Value
        End Set
    End Property
    Public Property P43() As Integer
        Get
            Return _P43
        End Get
        Set(ByVal Value As Integer)
            _P43 = Value
        End Set
    End Property
    Public Property P44() As Double
        Get
            Return _P44
        End Get
        Set(ByVal Value As Double)
            _P44 = Value
        End Set
    End Property
    Public Property P45() As Double
        Get
            Return _P45
        End Get
        Set(ByVal Value As Double)
            _P45 = Value
        End Set
    End Property
#End Region
#Region "Methods"
    Public Sub OperationBInsert(ByVal con As SqlConnection)
        Try
            Dim blnconnectionOpen As Boolean = False
            Try
                Dim sqlcomm As New SqlCommand("spRs_OpertaionBInsert", con)
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
                sqlcomm.Parameters.AddWithValue("@p25", IIf(IsNothing(_P25) Or IsDBNull(_P25), DBNull.Value, _P25))
                sqlcomm.Parameters.AddWithValue("@p26", IIf(IsNothing(_P26) Or IsDBNull(_P26), DBNull.Value, _P26))
                sqlcomm.Parameters.AddWithValue("@p27", IIf(IsNothing(_P27) Or IsDBNull(_P27), DBNull.Value, _P27))
                sqlcomm.Parameters.AddWithValue("@p28", IIf(IsNothing(_P28) Or IsDBNull(_P28), DBNull.Value, _P28))
                sqlcomm.Parameters.AddWithValue("@p29", IIf(IsNothing(_P29) Or IsDBNull(_P29), DBNull.Value, _P29))
                sqlcomm.Parameters.AddWithValue("@p30", IIf(IsNothing(_P30) Or IsDBNull(_P30), DBNull.Value, _P30))
                sqlcomm.Parameters.AddWithValue("@p31", IIf(IsNothing(_P31) Or IsDBNull(_P31), DBNull.Value, _P31))
                sqlcomm.Parameters.AddWithValue("@p32", IIf(IsNothing(_P32) Or IsDBNull(_P32), DBNull.Value, _P32))
                sqlcomm.Parameters.AddWithValue("@p33", IIf(IsNothing(_P33) Or IsDBNull(_P33), DBNull.Value, _P33))
                sqlcomm.Parameters.AddWithValue("@p34", IIf(IsNothing(_P34) Or IsDBNull(_P34), DBNull.Value, _P34))
                sqlcomm.Parameters.AddWithValue("@p35", IIf(IsNothing(_P35) Or IsDBNull(_P35), DBNull.Value, _P35))
                sqlcomm.Parameters.AddWithValue("@p36", IIf(IsNothing(_P36) Or IsDBNull(_P36), DBNull.Value, _P36))
                sqlcomm.Parameters.AddWithValue("@p37", IIf(IsNothing(_P37) Or IsDBNull(_P37), DBNull.Value, _P37))
                sqlcomm.Parameters.AddWithValue("@p38", IIf(IsNothing(_P38) Or IsDBNull(_P38), DBNull.Value, _P38))
                sqlcomm.Parameters.AddWithValue("@p39", IIf(IsNothing(_P38) Or IsDBNull(_P39), DBNull.Value, _P39))
                sqlcomm.Parameters.AddWithValue("@p40", IIf(IsNothing(_P40) Or IsDBNull(_P40), DBNull.Value, _P40))
                sqlcomm.Parameters.AddWithValue("@p41", IIf(IsNothing(_P41) Or IsDBNull(_P41), DBNull.Value, _P41))
                sqlcomm.Parameters.AddWithValue("@p42", IIf(IsNothing(_P42) Or IsDBNull(_P42), DBNull.Value, _P42))
                sqlcomm.Parameters.AddWithValue("@p43", IIf(IsNothing(_P43) Or IsDBNull(_P43), DBNull.Value, _P43))
                sqlcomm.Parameters.AddWithValue("@p44", IIf(IsNothing(_P44) Or IsDBNull(_P44), DBNull.Value, _P44))
                sqlcomm.Parameters.AddWithValue("@p45", IIf(IsNothing(_P45) Or IsDBNull(_P45), DBNull.Value, _P45))
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
    Public Sub OperationDInsert(ByVal con As SqlConnection)
        Try
            Dim blnconnectionOpen As Boolean = False
            Try
                Dim sqlcomm As New SqlCommand("spRs_OpertaionDInsert", con)
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
                sqlcomm.Parameters.AddWithValue("@PosCode", IIf(IsNothing(_PosCode) Or IsDBNull(_PosCode), DBNull.Value, _PosCode))
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
                sqlcomm.Parameters.AddWithValue("@p25", IIf(IsNothing(_P25) Or IsDBNull(_P25), DBNull.Value, _P25))
                sqlcomm.Parameters.AddWithValue("@p26", IIf(IsNothing(_P26) Or IsDBNull(_P26), DBNull.Value, _P26))
                sqlcomm.Parameters.AddWithValue("@p27", IIf(IsNothing(_P27) Or IsDBNull(_P27), DBNull.Value, _P27))
                sqlcomm.Parameters.AddWithValue("@p28", IIf(IsNothing(_P28) Or IsDBNull(_P28), DBNull.Value, _P28))
                sqlcomm.Parameters.AddWithValue("@p29", IIf(IsNothing(_P29) Or IsDBNull(_P29), DBNull.Value, _P29))
                sqlcomm.Parameters.AddWithValue("@p30", IIf(IsNothing(_P30) Or IsDBNull(_P30), DBNull.Value, _P30))
                sqlcomm.Parameters.AddWithValue("@p31", IIf(IsNothing(_P31) Or IsDBNull(_P31), DBNull.Value, _P31))
                sqlcomm.Parameters.AddWithValue("@p32", IIf(IsNothing(_P32) Or IsDBNull(_P32), DBNull.Value, _P32))
                sqlcomm.Parameters.AddWithValue("@p33", IIf(IsNothing(_P33) Or IsDBNull(_P33), DBNull.Value, _P33))
                sqlcomm.Parameters.AddWithValue("@p34", IIf(IsNothing(_P34) Or IsDBNull(_P34), DBNull.Value, _P34))
                sqlcomm.Parameters.AddWithValue("@p35", IIf(IsNothing(_P35) Or IsDBNull(_P35), DBNull.Value, _P35))
                sqlcomm.Parameters.AddWithValue("@p36", IIf(IsNothing(_P36) Or IsDBNull(_P36), DBNull.Value, _P36))
                sqlcomm.Parameters.AddWithValue("@p37", IIf(IsNothing(_P37) Or IsDBNull(_P37), DBNull.Value, _P37))
                sqlcomm.Parameters.AddWithValue("@p38", IIf(IsNothing(_P38) Or IsDBNull(_P38), DBNull.Value, _P38))
                sqlcomm.Parameters.AddWithValue("@p39", IIf(IsNothing(_P38) Or IsDBNull(_P39), DBNull.Value, _P39))
                sqlcomm.Parameters.AddWithValue("@p40", IIf(IsNothing(_P40) Or IsDBNull(_P40), DBNull.Value, _P40))
                sqlcomm.Parameters.AddWithValue("@p41", IIf(IsNothing(_P41) Or IsDBNull(_P41), DBNull.Value, _P41))
                sqlcomm.Parameters.AddWithValue("@p42", IIf(IsNothing(_P42) Or IsDBNull(_P42), DBNull.Value, _P42))
                sqlcomm.Parameters.AddWithValue("@p43", IIf(IsNothing(_P43) Or IsDBNull(_P43), DBNull.Value, _P43))
                sqlcomm.Parameters.AddWithValue("@p44", IIf(IsNothing(_P44) Or IsDBNull(_P44), DBNull.Value, _P44))
                sqlcomm.Parameters.AddWithValue("@p45", IIf(IsNothing(_P45) Or IsDBNull(_P45), DBNull.Value, _P45))
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
    Public Function OperationBGet(ByVal opId As Integer, ByVal invtypeid As Integer, ByVal POSCode As String, ByVal con As SqlConnection) As DataTable
        Try
            Dim blnconnectionOpen As Boolean = False
            Dim da As New SqlDataAdapter
            Dim sqlcomm As New SqlCommand("SpRt_BoOperationsBGet", con)
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@operID", opId)
            sqlcomm.Parameters.AddWithValue("@invTypeID", invtypeid)
            sqlcomm.Parameters.AddWithValue("@PosCode", POSCode)
            blnconnectionOpen = ConnStatus(con)
            If Not blnconnectionOpen Then ConnOpen(con)
            Dim dt As New DataTable
            da = New SqlDataAdapter(sqlcomm)
            da.Fill(dt)
            Return dt
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Public Sub OperationBUpdate(ByVal con As SqlConnection)
        Try
            Dim blnconnectionOpen As Boolean = False
            Try
                Dim sqlcomm As New SqlCommand("spRs_UpdateOperB", con)
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
