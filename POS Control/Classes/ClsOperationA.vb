Imports System.Data.SqlClient
Imports ConnectionSQL
Public Class OpASettings
    Public OperId As Integer
    Public OperDate As DateTime
    Public ThirdId As Object
    Public ThirdDesc As Object
    Public Closed As Integer
    Public SalesManID As Object
    Public GrossAmt As Double
    Public Disc1Pct As Double
    Public Disc1Amt As Double
    Public AddDiscAmt As Double
    Public VatAmt As Double
    Public NetAmt As Double
    Public MopTransId As Object
    Public Gift As Boolean
    Public GiftReturnDate As Object
End Class
Public Class ClsOperationA
    Public ds As New DataSet
    Dim da As New SqlDataAdapter
    Public i As Integer
#Region "Fields"
    Public _P1 As Integer
    Public _P2 As Integer
    Public _P3 As DateTime
    Public _P4 As DateTime
    Public _P5 As Object
    Public _P6 As String
    Public _P7 As Object
    Public _P8 As Object
    Public _P9 As Object
    Public _P10 As Object
    Public _P11 As Object
    Public _P12 As Object
    Public _P13 As String
    Public _P14 As String
    Public _P15 As String
    Public _P16 As Integer
    Public _P17 As Integer
    Public _P18 As Integer
    Public _P19 As Integer
    Public _P20 As Integer
    Public _P21 As Double
    Public _P22 As Double
    Public _P23 As Double
    Public _P24 As String
    Public _P25 As DateTime
    Public _P26 As Double
    Public _P27 As Double
    Public _P28 As Double
    Public _P29 As Double
    Public _P30 As Double
    Public _P31 As Double
    Public _P32 As Double
    Public _P33 As Double
    Public _P34 As Double
    Public _P35 As Double
    Public _P36 As String
    Public _P37 As String
    Public _P38 As String
    Public _P39 As DateTime
    Public _P40 As Object
    Public _P41 As Object
    Public _P42 As Object
    Public _P43 As Object
    Public _P44 As Integer
    Public _P45 As Integer
    Public _P46 As Double
    Public _P47 As Double
    Public _P48 As Double
    Public _P49 As Double
    Public _P50 As Double
    Public _P51 As Double
    Public _P52 As Object
    Public _P53 As Object
    Public _P54 As Object
    Public _Gift As Boolean
    Public _GiftReturnDate As DateTime
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
    Public Property P3() As DateTime
        Get
            Return _P3
        End Get
        Set(ByVal Value As DateTime)
            _P3 = Value
        End Set
    End Property
    Public Property P4() As DateTime
        Get
            Return _P4
        End Get
        Set(ByVal Value As DateTime)
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
    Public Property P7() As Integer
        Get
            Return _P7
        End Get
        Set(ByVal Value As Integer)
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
    Public Property P12() As String
        Get
            Return _P12
        End Get
        Set(ByVal Value As String)
            _P12 = Value
        End Set
    End Property
    Public Property P13() As String
        Get
            Return _P13
        End Get
        Set(ByVal Value As String)
            _P13 = Value
        End Set
    End Property
    Public Property P14() As String
        Get
            Return _P14
        End Get
        Set(ByVal Value As String)
            _P14 = Value
        End Set
    End Property
    Public Property P15() As String
        Get
            Return _P15
        End Get
        Set(ByVal Value As String)
            _P15 = Value
        End Set
    End Property
    Public Property P16() As Integer
        Get
            Return _P16
        End Get
        Set(ByVal Value As Integer)
            _P16 = Value
        End Set
    End Property
    Public Property P17() As Integer
        Get
            Return _P17
        End Get
        Set(ByVal Value As Integer)
            _P17 = Value
        End Set
    End Property
    Public Property P18() As Integer
        Get
            Return _P18
        End Get
        Set(ByVal Value As Integer)
            _P18 = Value
        End Set
    End Property
    Public Property P19() As Integer
        Get
            Return _P19
        End Get
        Set(ByVal Value As Integer)
            _P19 = Value
        End Set
    End Property
    Public Property P20() As Integer
        Get
            Return _P20
        End Get
        Set(ByVal Value As Integer)
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
    Public Property P22() As Double
        Get
            Return _P22
        End Get
        Set(ByVal Value As Double)
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
    Public Property P24() As String
        Get
            Return _P24
        End Get
        Set(ByVal Value As String)
            _P24 = Value
        End Set
    End Property
    Public Property P25() As DateTime
        Get
            Return _P25
        End Get
        Set(ByVal Value As DateTime)
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
    Public Property P35() As Double
        Get
            Return _P35
        End Get
        Set(ByVal Value As Double)
            _P35 = Value
        End Set
    End Property
    Public Property P36() As String
        Get
            Return _P36
        End Get
        Set(ByVal Value As String)
            _P36 = Value
        End Set
    End Property
    Public Property P37() As String
        Get
            Return _P37
        End Get
        Set(ByVal Value As String)
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
    Public Property P40() As Integer
        Get
            Return _P40
        End Get
        Set(ByVal Value As Integer)
            _P40 = Value
        End Set
    End Property
    Public Property P41() As String
        Get
            Return _P41
        End Get
        Set(ByVal Value As String)
            _P41 = Value
        End Set
    End Property
    Public Property P42() As Integer
        Get
            Return _P42
        End Get
        Set(ByVal Value As Integer)
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
    Public Property P44() As Integer
        Get
            Return _P44
        End Get
        Set(ByVal Value As Integer)
            _P44 = Value
        End Set
    End Property
    Public Property P45() As Integer
        Get
            Return _P45
        End Get
        Set(ByVal Value As Integer)
            _P45 = Value
        End Set
    End Property
    Public Property P46() As Double
        Get
            Return _P46
        End Get
        Set(ByVal Value As Double)
            _P46 = Value
        End Set
    End Property
    Public Property P47() As Double
        Get
            Return _P47
        End Get
        Set(ByVal Value As Double)
            _P47 = Value
        End Set
    End Property
    Public Property P48() As Double
        Get
            Return _P48
        End Get
        Set(ByVal Value As Double)
            _P48 = Value
        End Set
    End Property
    Public Property P49() As Double
        Get
            Return _P49
        End Get
        Set(ByVal Value As Double)
            _P49 = Value
        End Set
    End Property
    Public Property P50() As Double
        Get
            Return _P50
        End Get
        Set(ByVal Value As Double)
            _P50 = Value
        End Set
    End Property
    Public Property P51() As Double
        Get
            Return _P51
        End Get
        Set(ByVal Value As Double)
            _P51 = Value
        End Set
    End Property
    Public Property P52() As Integer
        Get
            Return _P52
        End Get
        Set(ByVal Value As Integer)
            _P52 = Value
        End Set
    End Property
    Public Property P53() As Integer
        Get
            Return _P53
        End Get
        Set(ByVal Value As Integer)
            _P53 = Value
        End Set
    End Property
    Public Property P54() As Integer
        Get
            Return _P54
        End Get
        Set(ByVal Value As Integer)
            _P54 = Value
        End Set
    End Property
    Public Property Gift() As Boolean
        Get
            Return _Gift
        End Get
        Set(ByVal Value As Boolean)
            _Gift = Value
        End Set
    End Property
    Public Property GiftReturnDate() As DateTime
        Get
            Return _GiftReturnDate
        End Get
        Set(ByVal Value As DateTime)
            _GiftReturnDate = Value
        End Set
    End Property
#End Region
#Region "Methods"
    Public Sub OperationAInsert(ByVal con As SqlConnection)
        Try
            Dim blnconnectionOpen As Boolean = False
            Try
                Dim sqlcomm As New SqlCommand("spRs_OpertaionAInsert", con)
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
                sqlcomm.Parameters.AddWithValue("@p46", IIf(IsNothing(_P46) Or IsDBNull(_P46), DBNull.Value, _P46))
                sqlcomm.Parameters.AddWithValue("@p47", IIf(IsNothing(_P47) Or IsDBNull(_P47), DBNull.Value, _P47))
                sqlcomm.Parameters.AddWithValue("@p48", IIf(IsNothing(_P48) Or IsDBNull(_P48), DBNull.Value, _P48))
                sqlcomm.Parameters.AddWithValue("@p49", IIf(IsNothing(_P49) Or IsDBNull(_P49), DBNull.Value, _P49))
                sqlcomm.Parameters.AddWithValue("@p50", IIf(IsNothing(_P50) Or IsDBNull(_P50), DBNull.Value, _P50))
                sqlcomm.Parameters.AddWithValue("@p51", IIf(IsNothing(_P51) Or IsDBNull(_P51), DBNull.Value, _P51))
                sqlcomm.Parameters.AddWithValue("@p52", IIf(IsNothing(_P52) Or IsDBNull(_P52), DBNull.Value, _P52))
                sqlcomm.Parameters.AddWithValue("@p53", IIf(IsNothing(_P53) Or IsDBNull(_P53), DBNull.Value, _P53))
                sqlcomm.Parameters.AddWithValue("@p54", IIf(IsNothing(_P54) Or IsDBNull(_P54), DBNull.Value, _P54))
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
    Sub getInvoices(ByVal InvTypeID As Integer, ByVal PosCode As String, ByVal DateOperFrom As String, ByVal DateOperTill As String, ByVal con As SqlConnection)
        Try
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("SpRt_BoOperationsGet", con)
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@invtypeid", InvTypeID)
            sqlcomm.Parameters.AddWithValue("@PosCode", PosCode)
            sqlcomm.Parameters.AddWithValue("@DateOperf", DateOperFrom)
            sqlcomm.Parameters.AddWithValue("@DateOpert", DateOperTill)
            da = New SqlDataAdapter(sqlcomm)
            ds.Clear()
            blnconnectionOpen = ConnStatus(con)
            If Not blnconnectionOpen Then ConnOpen(con)
            da.Fill(ds, "InvoiceHeader")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Function GetLastInvoiceHeader(ByRef vErr As String) As OpASettings
        Try
            Dim OpASettings As New OpASettings
            If ds.Tables("InvoiceHeader").Rows.Count = 0 Then
                OpASettings = Nothing
                vErr = "No Invoices To Load"
                Return OpASettings
                Exit Function
            End If
            i = ds.Tables("InvoiceHeader").Rows.Count - 1
            OpASettings.OperId = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("OperId").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("OperId").ToString), _
                                     String.Empty, ds.Tables("InvoiceHeader").Rows(i)("OperId").ToString)
            OpASettings.OperDate = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("OperDate").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("OperDate").ToString), _
                                    Today.Date, ds.Tables("InvoiceHeader").Rows(i)("OperDate").ToString)
            OpASettings.ThirdId = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("ThirdID").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("ThirdID").ToString), _
                                     Nothing, ds.Tables("InvoiceHeader").Rows(i)("ThirdID").ToString)
            OpASettings.ThirdDesc = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("ThirdDesc").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("ThirdDesc").ToString), _
                                     Nothing, ds.Tables("InvoiceHeader").Rows(i)("ThirdDesc").ToString)
            OpASettings.SalesManID = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("SalesManID").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("SalesManID").ToString), _
                                     Nothing, ds.Tables("InvoiceHeader").Rows(i)("SalesManID").ToString)
            OpASettings.Closed = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("Closed").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("Closed").ToString),
                                     0, ds.Tables("InvoiceHeader").Rows(i)("Closed").ToString)
            OpASettings.GrossAmt = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("GrossAmt").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("GrossAmt").ToString),
                                     0, ds.Tables("InvoiceHeader").Rows(i)("GrossAmt").ToString)
            OpASettings.AddDiscAmt = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("AddDiscAmt").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("AddDiscAmt").ToString),
                                     0, ds.Tables("InvoiceHeader").Rows(i)("AddDiscAmt").ToString)
            OpASettings.Disc1Pct = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("Disc1Pct").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("Disc1Pct").ToString), _
                                     0, ds.Tables("InvoiceHeader").Rows(i)("Disc1Pct").ToString)
            OpASettings.Disc1Amt = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("Disc1Amt").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("Disc1Amt").ToString), _
                                     0, ds.Tables("InvoiceHeader").Rows(i)("Disc1Amt").ToString)
            OpASettings.VatAmt = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("VatAmt").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("VatAmt").ToString), _
                                     0, ds.Tables("InvoiceHeader").Rows(i)("VatAmt").ToString)
            OpASettings.NetAmt = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("NetAmt").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("NetAmt").ToString), _
                                     0, ds.Tables("InvoiceHeader").Rows(i)("NetAmt").ToString)
            OpASettings.MopTransId = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("MopTransId").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("MopTransId").ToString) Or String.IsNullOrEmpty(ds.Tables("InvoiceHeader").Rows(i)("MopTransId").ToString), _
                                     0, ds.Tables("InvoiceHeader").Rows(i)("MopTransId").ToString)
            OpASettings.Gift = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("Gift").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("Gift").ToString) Or String.IsNullOrEmpty(ds.Tables("InvoiceHeader").Rows(i)("Gift").ToString), _
                                     0, ds.Tables("InvoiceHeader").Rows(i)("Gift").ToString)
            OpASettings.GiftReturnDate = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("GiftReturnDate").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("GiftReturnDate").ToString) Or String.IsNullOrEmpty(ds.Tables("InvoiceHeader").Rows(i)("GiftReturnDate").ToString), _
                                     DBNull.Value, ds.Tables("InvoiceHeader").Rows(i)("GiftReturnDate"))
            Return OpASettings
        Catch ex As Exception
            vErr = ex.Message
        End Try
    End Function
    Public Function GetFirstInvoiceHeader(ByRef vErr As String) As OpASettings
        Try
            Dim OpASettings As New OpASettings
            If ds.Tables("InvoiceHeader").Rows.Count = 0 Then
                OpASettings = Nothing
                vErr = "No Invoices To Load"
                Return OpASettings
                Exit Function
            End If
            i = 0
            OpASettings.OperId = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("OperId").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("OperId").ToString), _
                                     String.Empty, ds.Tables("InvoiceHeader").Rows(i)("OperId").ToString)
            OpASettings.OperDate = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("OperDate").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("OperDate").ToString), _
                                    Today.Date, ds.Tables("InvoiceHeader").Rows(i)("OperDate").ToString)
            OpASettings.ThirdId = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("ThirdID").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("ThirdID").ToString), _
                                     Nothing, ds.Tables("InvoiceHeader").Rows(i)("ThirdID").ToString)
            OpASettings.ThirdDesc = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("ThirdDesc").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("ThirdDesc").ToString), _
                                     Nothing, ds.Tables("InvoiceHeader").Rows(i)("ThirdDesc").ToString)
            OpASettings.SalesManID = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("SalesManID").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("SalesManID").ToString),
                                     Nothing, ds.Tables("InvoiceHeader").Rows(i)("SalesManID").ToString)
            OpASettings.AddDiscAmt = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("AddDiscAmt").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("AddDiscAmt").ToString),
                                     0, ds.Tables("InvoiceHeader").Rows(i)("AddDiscAmt").ToString)
            OpASettings.Closed = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("Closed").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("Closed").ToString),
                                     0, ds.Tables("InvoiceHeader").Rows(i)("Closed").ToString)
            OpASettings.GrossAmt = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("GrossAmt").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("GrossAmt").ToString),
                                     0, ds.Tables("InvoiceHeader").Rows(i)("GrossAmt").ToString)
            OpASettings.Disc1Pct = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("Disc1Pct").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("Disc1Pct").ToString), _
                                     0, ds.Tables("InvoiceHeader").Rows(i)("Disc1Pct").ToString)
            OpASettings.Disc1Amt = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("Disc1Amt").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("Disc1Amt").ToString), _
                                     0, ds.Tables("InvoiceHeader").Rows(i)("Disc1Amt").ToString)
            OpASettings.VatAmt = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("VatAmt").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("VatAmt").ToString), _
                                     0, ds.Tables("InvoiceHeader").Rows(i)("VatAmt").ToString)
            OpASettings.NetAmt = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("NetAmt").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("NetAmt").ToString), _
                                     0, ds.Tables("InvoiceHeader").Rows(i)("NetAmt").ToString)
            OpASettings.MopTransId = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("MopTransId").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("MopTransId").ToString) Or String.IsNullOrEmpty(ds.Tables("InvoiceHeader").Rows(i)("MopTransId").ToString), _
                                     0, ds.Tables("InvoiceHeader").Rows(i)("MopTransId").ToString)
            OpASettings.Gift = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("Gift").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("Gift").ToString) Or String.IsNullOrEmpty(ds.Tables("InvoiceHeader").Rows(i)("Gift").ToString), _
                                     0, ds.Tables("InvoiceHeader").Rows(i)("Gift").ToString)
            OpASettings.GiftReturnDate = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("GiftReturnDate").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("GiftReturnDate").ToString) Or String.IsNullOrEmpty(ds.Tables("InvoiceHeader").Rows(i)("GiftReturnDate").ToString), _
                                     DBNull.Value, ds.Tables("InvoiceHeader").Rows(i)("GiftReturnDate"))
            Return OpASettings
        Catch ex As Exception
            vErr = ex.Message
        End Try
    End Function
    Public Function GetNextInvoiceHeader(ByRef vErr As String) As OpASettings
        Try
            Dim OpASettings As New OpASettings
            If ds.Tables("InvoiceHeader").Rows.Count = 0 Then
                OpASettings = Nothing
                vErr = "No Invoices To Load"
                Return OpASettings
                Exit Function
            End If
            If (i < ds.Tables("InvoiceHeader").Rows.Count - 1) Then
                i = i + 1
                OpASettings.OperId = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("OperId").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("OperId").ToString), _
                                    String.Empty, ds.Tables("InvoiceHeader").Rows(i)("OperId").ToString)
                OpASettings.OperDate = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("OperDate").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("OperDate").ToString), _
                                        Today.Date, ds.Tables("InvoiceHeader").Rows(i)("OperDate").ToString)
                OpASettings.ThirdId = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("ThirdID").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("ThirdID").ToString), _
                                         Nothing, ds.Tables("InvoiceHeader").Rows(i)("ThirdID").ToString)
                OpASettings.ThirdDesc = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("ThirdDesc").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("ThirdDesc").ToString),
                                         Nothing, ds.Tables("InvoiceHeader").Rows(i)("ThirdDesc").ToString)
                OpASettings.Closed = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("Closed").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("Closed").ToString),
                                     0, ds.Tables("InvoiceHeader").Rows(i)("Closed").ToString)
                OpASettings.SalesManID = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("SalesManID").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("SalesManID").ToString), _
                                         Nothing, ds.Tables("InvoiceHeader").Rows(i)("SalesManID").ToString)
                OpASettings.GrossAmt = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("GrossAmt").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("GrossAmt").ToString), _
                                         0, ds.Tables("InvoiceHeader").Rows(i)("GrossAmt").ToString)
                OpASettings.Disc1Pct = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("Disc1Pct").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("Disc1Pct").ToString), _
                                         0, ds.Tables("InvoiceHeader").Rows(i)("Disc1Pct").ToString)
                OpASettings.Disc1Amt = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("Disc1Amt").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("Disc1Amt").ToString), _
                                         0, ds.Tables("InvoiceHeader").Rows(i)("Disc1Amt").ToString)
                OpASettings.VatAmt = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("VatAmt").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("VatAmt").ToString),
                                         0, ds.Tables("InvoiceHeader").Rows(i)("VatAmt").ToString)
                OpASettings.AddDiscAmt = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("AddDiscAmt").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("AddDiscAmt").ToString),
                                     0, ds.Tables("InvoiceHeader").Rows(i)("AddDiscAmt").ToString)
                OpASettings.NetAmt = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("NetAmt").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("NetAmt").ToString), _
                                         0, ds.Tables("InvoiceHeader").Rows(i)("NetAmt").ToString)
                OpASettings.MopTransId = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("MopTransId").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("MopTransId").ToString) Or String.IsNullOrEmpty(ds.Tables("InvoiceHeader").Rows(i)("MopTransId").ToString), _
                                         0, ds.Tables("InvoiceHeader").Rows(i)("MopTransId").ToString)
                OpASettings.Gift = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("Gift").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("Gift").ToString) Or String.IsNullOrEmpty(ds.Tables("InvoiceHeader").Rows(i)("Gift").ToString), _
                                         0, ds.Tables("InvoiceHeader").Rows(i)("Gift").ToString)
                OpASettings.GiftReturnDate = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("GiftReturnDate").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("GiftReturnDate").ToString) Or String.IsNullOrEmpty(ds.Tables("InvoiceHeader").Rows(i)("GiftReturnDate").ToString), _
                                         DBNull.Value, ds.Tables("InvoiceHeader").Rows(i)("GiftReturnDate"))
                Return OpASettings
            Else
                OpASettings.OperId = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("OperId").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("OperId").ToString), _
                   String.Empty, ds.Tables("InvoiceHeader").Rows(i)("OperId").ToString)
                OpASettings.OperDate = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("OperDate").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("OperDate").ToString), _
                                            Today.Date, ds.Tables("InvoiceHeader").Rows(i)("OperDate").ToString)
                OpASettings.ThirdId = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("ThirdID").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("ThirdID").ToString), _
                                         Nothing, ds.Tables("InvoiceHeader").Rows(i)("ThirdID").ToString)
                OpASettings.ThirdDesc = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("ThirdDesc").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("ThirdDesc").ToString),
                                         Nothing, ds.Tables("InvoiceHeader").Rows(i)("ThirdDesc").ToString)
                OpASettings.AddDiscAmt = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("AddDiscAmt").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("AddDiscAmt").ToString),
                                     0, ds.Tables("InvoiceHeader").Rows(i)("AddDiscAmt").ToString)
                OpASettings.SalesManID = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("SalesManID").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("SalesManID").ToString),
                                         Nothing, ds.Tables("InvoiceHeader").Rows(i)("SalesManID").ToString)
                OpASettings.Closed = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("Closed").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("Closed").ToString),
                                     0, ds.Tables("InvoiceHeader").Rows(i)("Closed").ToString)
                OpASettings.GrossAmt = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("GrossAmt").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("GrossAmt").ToString), _
                                         0, ds.Tables("InvoiceHeader").Rows(i)("GrossAmt").ToString)
                OpASettings.Disc1Pct = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("Disc1Pct").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("Disc1Pct").ToString), _
                                         0, ds.Tables("InvoiceHeader").Rows(i)("Disc1Pct").ToString)
                OpASettings.Disc1Amt = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("Disc1Amt").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("Disc1Amt").ToString), _
                                         0, ds.Tables("InvoiceHeader").Rows(i)("Disc1Amt").ToString)
                OpASettings.VatAmt = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("VatAmt").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("VatAmt").ToString), _
                                         0, ds.Tables("InvoiceHeader").Rows(i)("VatAmt").ToString)
                OpASettings.NetAmt = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("NetAmt").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("NetAmt").ToString), _
                                     0, ds.Tables("InvoiceHeader").Rows(i)("NetAmt").ToString)
                OpASettings.MopTransId = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("MopTransId").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("MopTransId").ToString) Or String.IsNullOrEmpty(ds.Tables("InvoiceHeader").Rows(i)("MopTransId").ToString), _
                                         0, ds.Tables("InvoiceHeader").Rows(i)("MopTransId").ToString)
                OpASettings.Gift = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("Gift").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("Gift").ToString) Or String.IsNullOrEmpty(ds.Tables("InvoiceHeader").Rows(i)("Gift").ToString), _
                                         0, ds.Tables("InvoiceHeader").Rows(i)("Gift").ToString)
                OpASettings.GiftReturnDate = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("GiftReturnDate").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("GiftReturnDate").ToString) Or String.IsNullOrEmpty(ds.Tables("InvoiceHeader").Rows(i)("GiftReturnDate").ToString), _
                                         DBNull.Value, ds.Tables("InvoiceHeader").Rows(i)("GiftReturnDate"))
                Return OpASettings
            End If
        Catch ex As Exception
            vErr = ex.Message
        End Try
    End Function
    Public Function GetPrevInvoiceHeader(ByRef vErr As String) As OpASettings
        Try
            Dim OpASettings As New OpASettings
            If ds.Tables("InvoiceHeader").Rows.Count = 0 Then
                OpASettings = Nothing
                vErr = "No Invoices To Load"
                Return OpASettings
                Exit Function
            End If
            If (i > ds.Tables("InvoiceHeader").Rows.Count - 1 Or i <> 0) Then
                i = i - 1
                OpASettings.OperId = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("OperId").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("OperId").ToString), _
                                    String.Empty, ds.Tables("InvoiceHeader").Rows(i)("OperId").ToString)
                OpASettings.OperDate = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("OperDate").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("OperDate").ToString), _
                                        Today.Date, ds.Tables("InvoiceHeader").Rows(i)("OperDate").ToString)
                OpASettings.ThirdId = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("ThirdID").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("ThirdID").ToString),
                                         Nothing, ds.Tables("InvoiceHeader").Rows(i)("ThirdID").ToString)
                OpASettings.Closed = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("Closed").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("Closed").ToString),
                                     0, ds.Tables("InvoiceHeader").Rows(i)("Closed").ToString)
                OpASettings.AddDiscAmt = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("AddDiscAmt").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("AddDiscAmt").ToString),
                                     0, ds.Tables("InvoiceHeader").Rows(i)("AddDiscAmt").ToString)
                OpASettings.ThirdDesc = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("ThirdDesc").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("ThirdDesc").ToString), _
                                         Nothing, ds.Tables("InvoiceHeader").Rows(i)("ThirdDesc").ToString)
                OpASettings.SalesManID = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("SalesManID").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("SalesManID").ToString), _
                                         Nothing, ds.Tables("InvoiceHeader").Rows(i)("SalesManID").ToString)
                OpASettings.GrossAmt = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("GrossAmt").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("GrossAmt").ToString), _
                                         0, ds.Tables("InvoiceHeader").Rows(i)("GrossAmt").ToString)
                OpASettings.Disc1Pct = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("Disc1Pct").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("Disc1Pct").ToString), _
                                         0, ds.Tables("InvoiceHeader").Rows(i)("Disc1Pct").ToString)
                OpASettings.Disc1Amt = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("Disc1Amt").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("Disc1Amt").ToString), _
                                         0, ds.Tables("InvoiceHeader").Rows(i)("Disc1Amt").ToString)
                OpASettings.VatAmt = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("VatAmt").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("VatAmt").ToString), _
                                         0, ds.Tables("InvoiceHeader").Rows(i)("VatAmt").ToString)
                OpASettings.NetAmt = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("NetAmt").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("NetAmt").ToString), _
                                         0, ds.Tables("InvoiceHeader").Rows(i)("NetAmt").ToString)
                OpASettings.MopTransId = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("MopTransId").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("MopTransId").ToString) Or String.IsNullOrEmpty(ds.Tables("InvoiceHeader").Rows(i)("MopTransId").ToString), _
                                         0, ds.Tables("InvoiceHeader").Rows(i)("MopTransId").ToString)
                OpASettings.Gift = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("Gift").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("Gift").ToString) Or String.IsNullOrEmpty(ds.Tables("InvoiceHeader").Rows(i)("Gift").ToString), _
                                         0, ds.Tables("InvoiceHeader").Rows(i)("Gift").ToString)
                OpASettings.GiftReturnDate = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("GiftReturnDate").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("GiftReturnDate").ToString) Or String.IsNullOrEmpty(ds.Tables("InvoiceHeader").Rows(i)("GiftReturnDate").ToString), _
                                         DBNull.Value, ds.Tables("InvoiceHeader").Rows(i)("GiftReturnDate"))
                Return OpASettings
            Else
                OpASettings.OperId = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("OperId").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("OperId").ToString), _
                   String.Empty, ds.Tables("InvoiceHeader").Rows(i)("OperId").ToString)
                OpASettings.OperDate = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("OperDate").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("OperDate").ToString),
                                            Today.Date, ds.Tables("InvoiceHeader").Rows(i)("OperDate").ToString)
                OpASettings.AddDiscAmt = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("AddDiscAmt").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("AddDiscAmt").ToString),
                                     0, ds.Tables("InvoiceHeader").Rows(i)("AddDiscAmt").ToString)
                OpASettings.ThirdId = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("ThirdID").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("ThirdID").ToString), _
                                         Nothing, ds.Tables("InvoiceHeader").Rows(i)("ThirdID").ToString)
                OpASettings.ThirdDesc = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("ThirdDesc").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("ThirdDesc").ToString), _
                                         Nothing, ds.Tables("InvoiceHeader").Rows(i)("ThirdDesc").ToString)
                OpASettings.SalesManID = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("SalesManID").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("SalesManID").ToString),
                                         Nothing, ds.Tables("InvoiceHeader").Rows(i)("SalesManID").ToString)
                OpASettings.Closed = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("Closed").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("Closed").ToString),
                                     0, ds.Tables("InvoiceHeader").Rows(i)("Closed").ToString)
                OpASettings.GrossAmt = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("GrossAmt").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("GrossAmt").ToString), _
                                         0, ds.Tables("InvoiceHeader").Rows(i)("GrossAmt").ToString)
                OpASettings.Disc1Pct = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("Disc1Pct").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("Disc1Pct").ToString), _
                                         0, ds.Tables("InvoiceHeader").Rows(i)("Disc1Pct").ToString)
                OpASettings.Disc1Amt = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("Disc1Amt").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("Disc1Amt").ToString), _
                                         0, ds.Tables("InvoiceHeader").Rows(i)("Disc1Amt").ToString)
                OpASettings.VatAmt = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("VatAmt").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("VatAmt").ToString), _
                                         0, ds.Tables("InvoiceHeader").Rows(i)("VatAmt").ToString)
                OpASettings.NetAmt = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("NetAmt").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("NetAmt").ToString), _
                                     0, ds.Tables("InvoiceHeader").Rows(i)("NetAmt").ToString)
                OpASettings.MopTransId = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("MopTransId").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("MopTransId").ToString) Or String.IsNullOrEmpty(ds.Tables("InvoiceHeader").Rows(i)("MopTransId").ToString), _
                                         0, ds.Tables("InvoiceHeader").Rows(i)("MopTransId").ToString)
                OpASettings.Gift = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("Gift").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("Gift").ToString) Or String.IsNullOrEmpty(ds.Tables("InvoiceHeader").Rows(i)("Gift").ToString), _
                                         0, ds.Tables("InvoiceHeader").Rows(i)("Gift").ToString)
                OpASettings.GiftReturnDate = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("GiftReturnDate").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("GiftReturnDate").ToString) Or String.IsNullOrEmpty(ds.Tables("InvoiceHeader").Rows(i)("GiftReturnDate").ToString), _
                                        DBNull.Value, ds.Tables("InvoiceHeader").Rows(i)("GiftReturnDate"))
                Return OpASettings
            End If
        Catch ex As Exception
            vErr = ex.Message
        End Try
    End Function
    Public Function GetCurrentRecord(ByVal Index As Integer, ByRef vErr As String) As OpASettings
        Try
            Dim OpASettings As New OpASettings
            If ds.Tables("InvoiceHeader").Rows.Count = 0 Then
                OpASettings = Nothing
                vErr = "No Invoices To Load"
                Return OpASettings
                Exit Function
            End If
            i = Index
            OpASettings.OperId = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("OperId").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("OperId").ToString), _
                                String.Empty, ds.Tables("InvoiceHeader").Rows(i)("OperId").ToString)
            OpASettings.OperDate = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("OperDate").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("OperDate").ToString), _
                                    Today.Date, ds.Tables("InvoiceHeader").Rows(i)("OperDate").ToString)
            OpASettings.ThirdId = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("ThirdID").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("ThirdID").ToString),
                                     Nothing, ds.Tables("InvoiceHeader").Rows(i)("ThirdID").ToString)
            OpASettings.Closed = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("Closed").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("Closed").ToString),
                                     0, ds.Tables("InvoiceHeader").Rows(i)("Closed").ToString)
            OpASettings.ThirdDesc = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("ThirdDesc").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("ThirdDesc").ToString), _
                                     Nothing, ds.Tables("InvoiceHeader").Rows(i)("ThirdDesc").ToString)
            OpASettings.SalesManID = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("SalesManID").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("SalesManID").ToString), _
                                     Nothing, ds.Tables("InvoiceHeader").Rows(i)("SalesManID").ToString)
            OpASettings.GrossAmt = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("GrossAmt").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("GrossAmt").ToString), _
                                     0, ds.Tables("InvoiceHeader").Rows(i)("GrossAmt").ToString)
            OpASettings.Disc1Pct = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("Disc1Pct").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("Disc1Pct").ToString), _
                                     0, ds.Tables("InvoiceHeader").Rows(i)("Disc1Pct").ToString)
            OpASettings.Disc1Amt = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("Disc1Amt").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("Disc1Amt").ToString), _
                                     0, ds.Tables("InvoiceHeader").Rows(i)("Disc1Amt").ToString)
            OpASettings.AddDiscAmt = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("AddDiscAmt").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("AddDiscAmt").ToString),
                                     0, ds.Tables("InvoiceHeader").Rows(i)("AddDiscAmt").ToString)
            OpASettings.VatAmt = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("VatAmt").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("VatAmt").ToString),
                                     0, ds.Tables("InvoiceHeader").Rows(i)("VatAmt").ToString)
            OpASettings.NetAmt = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("NetAmt").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("NetAmt").ToString), _
                                     0, ds.Tables("InvoiceHeader").Rows(i)("NetAmt").ToString)
            OpASettings.MopTransId = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("MopTransId").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("MopTransId").ToString) Or String.IsNullOrEmpty(ds.Tables("InvoiceHeader").Rows(i)("MopTransId").ToString), _
                                     0, ds.Tables("InvoiceHeader").Rows(i)("MopTransId").ToString)
            OpASettings.Gift = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("Gift").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("Gift").ToString) Or String.IsNullOrEmpty(ds.Tables("InvoiceHeader").Rows(i)("Gift").ToString), _
                                     0, ds.Tables("InvoiceHeader").Rows(i)("Gift").ToString)
            OpASettings.GiftReturnDate = IIf(IsDBNull(ds.Tables("InvoiceHeader").Rows(i)("GiftReturnDate").ToString) Or IsNothing(ds.Tables("InvoiceHeader").Rows(i)("GiftReturnDate").ToString) Or String.IsNullOrEmpty(ds.Tables("InvoiceHeader").Rows(i)("GiftReturnDate").ToString), _
                                     DBNull.Value, ds.Tables("InvoiceHeader").Rows(i)("GiftReturnDate"))
            Return OpASettings

        Catch ex As Exception
            vErr = ex.Message
        End Try
    End Function
    Public Sub UpdateOperationGift(ByVal InvTypeID As Integer, ByVal Days As Integer, ByVal OperID As Integer, ByVal con As SqlConnection)
        Try
            Dim blnconnectionOpen As Boolean = False
            Dim sqlcomm As New SqlCommand("SpIv_SetOperationGift", con)
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@OperID", OperID)
            sqlcomm.Parameters.AddWithValue("@InvTypeID", InvTypeID)
            sqlcomm.Parameters.AddWithValue("@Days", Days)
            blnconnectionOpen = ConnStatus(con)
            If Not blnconnectionOpen Then ConnOpen(con)
            sqlcomm.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub UpdateOperationA(ByVal OperID As Integer, ByVal PosCode As String, _
ByVal InvTypeID As Integer, ByVal GrossAmt As Decimal, _
ByVal Disc1Pct As Decimal, ByVal Disc1Amt As Decimal, _
ByVal NetAmt As Decimal, ByVal VatAmt As Decimal, ByVal con As SqlConnection)
        Try
            Dim blnconnectionOpen As Boolean = False
            Dim sqlcomm As New SqlCommand("SpRt_BoOperationAUpdate", con)
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@operId", IIf(IsNothing(OperID) Or IsDBNull(OperID), DBNull.Value, OperID))
            sqlcomm.Parameters.AddWithValue("@PosCode", IIf(IsNothing(PosCode) Or IsDBNull(PosCode), DBNull.Value, PosCode))
            sqlcomm.Parameters.AddWithValue("@InvTypeID", IIf(IsNothing(InvTypeID) Or IsDBNull(InvTypeID), DBNull.Value, InvTypeID))
            sqlcomm.Parameters.AddWithValue("@GrossAmt", IIf(IsNothing(GrossAmt) Or IsDBNull(GrossAmt), DBNull.Value, GrossAmt))
            sqlcomm.Parameters.AddWithValue("@Disc1Pct", IIf(IsNothing(Disc1Pct) Or IsDBNull(Disc1Pct), DBNull.Value, Disc1Pct))
            sqlcomm.Parameters.AddWithValue("@Disc1Amt", IIf(IsNothing(Disc1Amt) Or IsDBNull(Disc1Amt), DBNull.Value, Disc1Amt))
            sqlcomm.Parameters.AddWithValue("@NetAmt", IIf(IsNothing(NetAmt) Or IsDBNull(NetAmt), DBNull.Value, NetAmt))
            sqlcomm.Parameters.AddWithValue("@VatAmt", IIf(IsNothing(VatAmt) Or IsDBNull(VatAmt), DBNull.Value, VatAmt))
            blnconnectionOpen = ConnStatus(con)
            If Not blnconnectionOpen Then ConnOpen(con)
            sqlcomm.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub UpdateOperationB(ByVal OperID As Integer, ByVal PosCode As String, _
                                ByVal InvTypeID As Integer, ByVal LigneID As Integer, ByVal UP As Decimal, _
                                ByVal Qty As Decimal, ByVal TotalLigne As Decimal, _
                                ByVal VatAmt As Decimal, ByVal con As SqlConnection)
        Try
            Dim blnconnectionOpen As Boolean = False
            Dim sqlcomm As New SqlCommand("SpRt_BoOperationBUpdate", con)
            sqlcomm.CommandType = CommandType.StoredProcedure
            sqlcomm.Parameters.AddWithValue("@operId", IIf(IsNothing(OperID) Or IsDBNull(OperID), DBNull.Value, OperID))
            sqlcomm.Parameters.AddWithValue("@PosCode", IIf(IsNothing(PosCode) Or IsDBNull(PosCode), DBNull.Value, PosCode))
            sqlcomm.Parameters.AddWithValue("@LigneID", IIf(IsNothing(LigneID) Or IsDBNull(LigneID), DBNull.Value, LigneID))
            sqlcomm.Parameters.AddWithValue("@InvTypeID", IIf(IsNothing(InvTypeID) Or IsDBNull(InvTypeID), DBNull.Value, InvTypeID))
            sqlcomm.Parameters.AddWithValue("@UP", IIf(IsNothing(UP) Or IsDBNull(UP), DBNull.Value, UP))
            sqlcomm.Parameters.AddWithValue("@Qty", IIf(IsNothing(Qty) Or IsDBNull(Qty), DBNull.Value, Qty))
            sqlcomm.Parameters.AddWithValue("@TotalLigne", IIf(IsNothing(TotalLigne) Or IsDBNull(TotalLigne), DBNull.Value, TotalLigne))
            sqlcomm.Parameters.AddWithValue("@VatAmt", IIf(IsNothing(VatAmt) Or IsDBNull(VatAmt), DBNull.Value, VatAmt))
            blnconnectionOpen = ConnStatus(con)
            If Not blnconnectionOpen Then ConnOpen(con)
            sqlcomm.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Function GetDeliveryOrders(ByVal InvTypeID As Integer, ByVal WhsCode As String, ByVal Con As SqlConnection) As DataTable
        Try
            Try
                Dim blnconnectionOpen As Boolean
                Dim sqlcomm As New SqlCommand("SpIv_BoGetDeliveryOrders", Con)
                sqlcomm.CommandType = CommandType.StoredProcedure
                sqlcomm.Parameters.AddWithValue("@invtypeid", InvTypeID)
                sqlcomm.Parameters.AddWithValue("@WhsCode", WhsCode)
                da = New SqlDataAdapter(sqlcomm)
                Dim dt As New DataTable
                blnconnectionOpen = ConnStatus(Con)
                If Not blnconnectionOpen Then ConnOpen(Con)
                da.Fill(dt)
                Return dt
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Public Function GetWhsAdjustments(ByVal InvTypeID As Integer, ByVal WhsCode As String, ByVal Con As SqlConnection) As DataTable
        Try
            Try
                Dim blnconnectionOpen As Boolean
                Dim sqlcomm As New SqlCommand("SpIv_BoGetWhsAdjustments", Con)
                sqlcomm.CommandType = CommandType.StoredProcedure
                sqlcomm.Parameters.AddWithValue("@invtypeid", InvTypeID)
                sqlcomm.Parameters.AddWithValue("@WhsCode", WhsCode)
                da = New SqlDataAdapter(sqlcomm)
                Dim dt As New DataTable
                blnconnectionOpen = ConnStatus(Con)
                If Not blnconnectionOpen Then ConnOpen(Con)
                da.Fill(dt)
                Return dt
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Public Sub OperationCInsert(ByVal con As SqlConnection)
        Try
            Dim blnconnectionOpen As Boolean = False
            Try
                Dim sqlcomm As New SqlCommand("spRs_OpertaionCInsert", con)
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
                sqlcomm.Parameters.AddWithValue("@p46", IIf(IsNothing(_P46) Or IsDBNull(_P46), DBNull.Value, _P46))
                sqlcomm.Parameters.AddWithValue("@p47", IIf(IsNothing(_P47) Or IsDBNull(_P47), DBNull.Value, _P47))
                sqlcomm.Parameters.AddWithValue("@p48", IIf(IsNothing(_P48) Or IsDBNull(_P48), DBNull.Value, _P48))
                sqlcomm.Parameters.AddWithValue("@p49", IIf(IsNothing(_P49) Or IsDBNull(_P49), DBNull.Value, _P49))
                sqlcomm.Parameters.AddWithValue("@p50", IIf(IsNothing(_P50) Or IsDBNull(_P50), DBNull.Value, _P50))
                sqlcomm.Parameters.AddWithValue("@p51", IIf(IsNothing(_P51) Or IsDBNull(_P51), DBNull.Value, _P51))
                sqlcomm.Parameters.AddWithValue("@p52", IIf(IsNothing(_P52) Or IsDBNull(_P52), DBNull.Value, _P52))
                sqlcomm.Parameters.AddWithValue("@p53", IIf(IsNothing(_P53) Or IsDBNull(_P53), DBNull.Value, _P53))
                sqlcomm.Parameters.AddWithValue("@p54", IIf(IsNothing(_P54) Or IsDBNull(_P54), DBNull.Value, _P54))
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
