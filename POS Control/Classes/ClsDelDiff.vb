Imports System.Data.SqlClient
Imports ConnectionSQL
Public Class DelDiffSettings
    Public LineID As Integer
    Public OperID As Integer
    Public PosCode As String
    Public WhsCode As String
    Public Barcode As String
    Public Description As String
    Public Size As String
    Public Color As String
    Public Qty As Decimal
    Public QtyAffected As Decimal
    Public iUser As String
    Public iDate As DateTime
    Public uUser As String
    Public uDate As DateTime
    Public Cleared As Boolean
End Class
Public Class ClsDelDiff
#Region "Fields"
    Public _LineID As Integer
    Public _OperID As Integer
    Public _PosCode As String
    Public _WhsCode As String
    Public _Barcode As String
    Public _Description As String
    Public _Size As String
    Public _Color As String
    Public _Qty As Decimal
    Public _QtyAffected As Decimal
    Public _iUser As String
    Public _iDate As DateTime
    Public _uUser As String
    Public _uDate As DateTime
    Public _Cleared As Boolean
#End Region
#Region "Properties"
    Public Property LineID() As Integer
        Get
            Return _LineID
        End Get
        Set(ByVal Value As Integer)
            _LineID = Value
        End Set
    End Property
    Public Property OperID() As Integer
        Get
            Return _OperID
        End Get
        Set(ByVal Value As Integer)
            _OperID = Value
        End Set
    End Property
    Public Property PosCode() As String
        Get
            Return _PosCode
        End Get
        Set(ByVal Value As String)
            _PosCode = Value
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
    Public Property Barcode() As String
        Get
            Return _Barcode
        End Get
        Set(ByVal Value As String)
            _Barcode = Value
        End Set
    End Property
    Public Property Size() As String
        Get
            Return _Size
        End Get
        Set(ByVal Value As String)
            _Size = Value
        End Set
    End Property
    Public Property Color() As String
        Get
            Return _Color
        End Get
        Set(ByVal Value As String)
            _Color = Value
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
    Public Property iUser() As String
        Get
            Return _iUser
        End Get
        Set(ByVal Value As String)
            _iUser = Value
        End Set
    End Property
    Public Property uUser() As String
        Get
            Return _uUser
        End Get
        Set(ByVal Value As String)
            _uUser = Value
        End Set
    End Property
    Public Property Qty() As Decimal
        Get
            Return _Qty
        End Get
        Set(ByVal Value As Decimal)
            _Qty = Value
        End Set
    End Property
    Public Property QtyAffected() As Decimal
        Get
            Return _QtyAffected
        End Get
        Set(ByVal Value As Decimal)
            _QtyAffected = Value
        End Set
    End Property
    Public Property iDate() As DateTime
        Get
            Return _iDate
        End Get
        Set(ByVal Value As DateTime)
            _iDate = Value
        End Set
    End Property
    Public Property uDate() As DateTime
        Get
            Return _uDate
        End Get
        Set(ByVal Value As DateTime)
            _uDate = Value
        End Set
    End Property
    Public Property Cleared() As Boolean
        Get
            Return _Cleared
        End Get
        Set(ByVal Value As Boolean)
            _Cleared = Value
        End Set
    End Property
#End Region
#Region "Methods"
    Dim ds As New DataSet
    Public Shared i As Integer
    Public Sub InsertDelDiff(ByVal Con As SqlConnection)
        Try
            Dim blnconnectionOpen As Boolean
            Dim Sqlcom As New SqlCommand("SpRt_InsertDelDiff", Con)
            Sqlcom.CommandType = CommandType.StoredProcedure
            Sqlcom.Parameters.AddWithValue("@OperID", _OperID)
            Sqlcom.Parameters.AddWithValue("@PosCode", _PosCode)
            Sqlcom.Parameters.AddWithValue("@WhsCode", _WhsCode)
            Sqlcom.Parameters.AddWithValue("@Barcode", _Barcode)
            Sqlcom.Parameters.AddWithValue("@Description", _Description)
            Sqlcom.Parameters.AddWithValue("@Size", _Size)
            Sqlcom.Parameters.AddWithValue("@color", _Color)
            Sqlcom.Parameters.AddWithValue("@Qty", _Qty)
            Sqlcom.Parameters.AddWithValue("@QtyAffected", _QtyAffected)
            Sqlcom.Parameters.AddWithValue("@iUser", _iUser)
            Sqlcom.Parameters.AddWithValue("@iDate", _iDate)
            Sqlcom.Parameters.AddWithValue("@Cleared", _Cleared)
            blnconnectionOpen = ConnStatus(Con)
            If Not blnconnectionOpen Then ConnOpen(Con)
            Sqlcom.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub GetDelDiff(ByVal con As SqlConnection)
        Try
            Dim blnconnectionOpen As Boolean
            Dim sqlcom As New SqlCommand("SpRt_GetDelDiff", con)
            sqlcom.CommandType = CommandType.StoredProcedure
            Dim da As New SqlDataAdapter(sqlcom)
            ds.Clear()
            blnconnectionOpen = ConnStatus(con)
            If Not blnconnectionOpen Then ConnOpen(con)
            da.Fill(ds, "DelDiff")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Function GetLastDelDiff(ByRef vErr As String) As DelDiffSettings
        Try
            Dim DelDiffSettings As New DelDiffSettings
            If ds.Tables("DelDiff").Rows.Count = 0 Then
                DelDiffSettings = Nothing
                vErr = "No Discrepancies To Load"
                Return DelDiffSettings
                Exit Function
            End If
            i = ds.Tables("DelDiff").Rows.Count - 1
            DelDiffSettings.LineID = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("LineID").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("LineID").ToString), _
                                     String.Empty, ds.Tables("DelDiff").Rows(i)("LineID").ToString)
            DelDiffSettings.OperID = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("OperId").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("OperId").ToString), _
                                     String.Empty, ds.Tables("DelDiff").Rows(i)("OperId").ToString)
            DelDiffSettings.PosCode = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("PosCode").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("PosCode").ToString), _
                                    "", ds.Tables("DelDiff").Rows(i)("PosCode").ToString)
            DelDiffSettings.Barcode = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("Barcode").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("Barcode").ToString), _
                                     "", ds.Tables("DelDiff").Rows(i)("Barcode").ToString)
            DelDiffSettings.WhsCode = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("WhsCode").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("WhsCode").ToString), _
                                     "", ds.Tables("DelDiff").Rows(i)("WhsCode").ToString)
            DelDiffSettings.Description = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("Description").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("Description").ToString), _
                                     "", ds.Tables("DelDiff").Rows(i)("Description").ToString)
            DelDiffSettings.Size = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("Size").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("Size").ToString), _
                                     "", ds.Tables("DelDiff").Rows(i)("Size").ToString)
            DelDiffSettings.Color = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("Color").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("Color").ToString), _
                                     "", ds.Tables("DelDiff").Rows(i)("Color").ToString)
            DelDiffSettings.Qty = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("Qty").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("Qty").ToString), _
                                     0, ds.Tables("DelDiff").Rows(i)("Qty").ToString)
            DelDiffSettings.QtyAffected = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("QtyAffected").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("QtyAffected").ToString), _
                                     0, ds.Tables("DelDiff").Rows(i)("QtyAffected").ToString)
            DelDiffSettings.iUser = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("iUser").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("iUser").ToString), _
                                     Today.Date, ds.Tables("DelDiff").Rows(i)("iUser").ToString)
            Return DelDiffSettings
        Catch ex As Exception
            vErr = ex.Message
        End Try
    End Function
    Public Function GetFirstDelDiff(ByRef vErr As String) As DelDiffSettings
        Try
            Dim DelDiffSettings As New DelDiffSettings
            If ds.Tables("DelDiff").Rows.Count = 0 Then
                DelDiffSettings = Nothing
                vErr = "No Discrepancies To Load"
                Return DelDiffSettings
                Exit Function
            End If
            i = 0
            DelDiffSettings.LineID = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("LineID").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("LineID").ToString), _
                         String.Empty, ds.Tables("DelDiff").Rows(i)("LineID").ToString)
            DelDiffSettings.OperID = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("OperId").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("OperId").ToString), _
                                     String.Empty, ds.Tables("DelDiff").Rows(i)("OperId").ToString)
            DelDiffSettings.PosCode = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("PosCode").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("PosCode").ToString), _
                                    "", ds.Tables("DelDiff").Rows(i)("PosCode").ToString)
            DelDiffSettings.Barcode = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("Barcode").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("Barcode").ToString), _
                                     "", ds.Tables("DelDiff").Rows(i)("Barcode").ToString)
            DelDiffSettings.WhsCode = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("WhsCode").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("WhsCode").ToString), _
                                     "", ds.Tables("DelDiff").Rows(i)("WhsCode").ToString)
            DelDiffSettings.Description = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("Description").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("Description").ToString), _
                                     "", ds.Tables("DelDiff").Rows(i)("Description").ToString)
            DelDiffSettings.Size = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("Size").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("Size").ToString), _
                                     "", ds.Tables("DelDiff").Rows(i)("Size").ToString)
            DelDiffSettings.Color = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("Color").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("Color").ToString), _
                                     "", ds.Tables("DelDiff").Rows(i)("Color").ToString)
            DelDiffSettings.Qty = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("Qty").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("Qty").ToString), _
                                     0, ds.Tables("DelDiff").Rows(i)("Qty").ToString)
            DelDiffSettings.QtyAffected = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("QtyAffected").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("QtyAffected").ToString), _
                                     0, ds.Tables("DelDiff").Rows(i)("QtyAffected").ToString)
            DelDiffSettings.iUser = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("iUser").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("iUser").ToString), _
                                     Today.Date, ds.Tables("DelDiff").Rows(i)("iUser").ToString)
            Return DelDiffSettings
        Catch ex As Exception
            vErr = ex.Message
        End Try
    End Function
    Public Function GetNextDelDiff(ByRef vErr As String) As DelDiffSettings
        Try
            Dim DelDiffSettings As New DelDiffSettings
            If ds.Tables("DelDiff").Rows.Count = 0 Then
                DelDiffSettings = Nothing
                vErr = "No Discrepancies To Load"
                Return DelDiffSettings
                Exit Function
            End If
            If (i < ds.Tables("DelDiff").Rows.Count - 1) Then
                i = i + 1
                DelDiffSettings.LineID = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("LineID").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("LineID").ToString), _
                         String.Empty, ds.Tables("DelDiff").Rows(i)("LineID").ToString)
                DelDiffSettings.OperID = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("OperId").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("OperId").ToString), _
                                         String.Empty, ds.Tables("DelDiff").Rows(i)("OperId").ToString)
                DelDiffSettings.PosCode = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("PosCode").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("PosCode").ToString), _
                                        "", ds.Tables("DelDiff").Rows(i)("PosCode").ToString)
                DelDiffSettings.Barcode = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("Barcode").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("Barcode").ToString), _
                                         "", ds.Tables("DelDiff").Rows(i)("Barcode").ToString)
                DelDiffSettings.WhsCode = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("WhsCode").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("WhsCode").ToString), _
                                         "", ds.Tables("DelDiff").Rows(i)("WhsCode").ToString)
                DelDiffSettings.Description = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("Description").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("Description").ToString), _
                                         "", ds.Tables("DelDiff").Rows(i)("Description").ToString)
                DelDiffSettings.Size = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("Size").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("Size").ToString), _
                                         "", ds.Tables("DelDiff").Rows(i)("Size").ToString)
                DelDiffSettings.Color = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("Color").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("Color").ToString), _
                                         "", ds.Tables("DelDiff").Rows(i)("Color").ToString)
                DelDiffSettings.Qty = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("Qty").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("Qty").ToString), _
                                         0, ds.Tables("DelDiff").Rows(i)("Qty").ToString)
                DelDiffSettings.QtyAffected = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("QtyAffected").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("QtyAffected").ToString), _
                                         0, ds.Tables("DelDiff").Rows(i)("QtyAffected").ToString)
                DelDiffSettings.iUser = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("iUser").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("iUser").ToString), _
                                         Today.Date, ds.Tables("DelDiff").Rows(i)("iUser").ToString)
                Return DelDiffSettings
            Else
                DelDiffSettings.LineID = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("LineID").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("LineID").ToString), _
                         String.Empty, ds.Tables("DelDiff").Rows(i)("LineID").ToString)
                DelDiffSettings.OperID = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("OperId").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("OperId").ToString), _
                                         String.Empty, ds.Tables("DelDiff").Rows(i)("OperId").ToString)
                DelDiffSettings.PosCode = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("PosCode").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("PosCode").ToString), _
                                        "", ds.Tables("DelDiff").Rows(i)("PosCode").ToString)
                DelDiffSettings.Barcode = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("Barcode").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("Barcode").ToString), _
                                         "", ds.Tables("DelDiff").Rows(i)("Barcode").ToString)
                DelDiffSettings.WhsCode = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("WhsCode").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("WhsCode").ToString), _
                                         "", ds.Tables("DelDiff").Rows(i)("WhsCode").ToString)
                DelDiffSettings.Description = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("Description").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("Description").ToString), _
                                         "", ds.Tables("DelDiff").Rows(i)("Description").ToString)
                DelDiffSettings.Size = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("Size").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("Size").ToString), _
                                         "", ds.Tables("DelDiff").Rows(i)("Size").ToString)
                DelDiffSettings.Color = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("Color").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("Color").ToString), _
                                         "", ds.Tables("DelDiff").Rows(i)("Color").ToString)
                DelDiffSettings.Qty = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("Qty").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("Qty").ToString), _
                                         0, ds.Tables("DelDiff").Rows(i)("Qty").ToString)
                DelDiffSettings.QtyAffected = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("QtyAffected").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("QtyAffected").ToString), _
                                         0, ds.Tables("DelDiff").Rows(i)("QtyAffected").ToString)
                DelDiffSettings.iUser = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("iUser").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("iUser").ToString), _
                                         Today.Date, ds.Tables("DelDiff").Rows(i)("iUser").ToString)
                Return DelDiffSettings
            End If
        Catch ex As Exception
            vErr = ex.Message
        End Try
    End Function
    Public Function GetPrevInvoiceHeader(ByRef vErr As String) As DelDiffSettings
        Try
            Dim DelDiffSettings As New DelDiffSettings
            If ds.Tables("DelDiff").Rows.Count = 0 Then
                DelDiffSettings = Nothing
                vErr = "No Discrepancies To Load"
                Return DelDiffSettings
                Exit Function
            End If
            If (i > ds.Tables("DelDiff").Rows.Count - 1 Or i <> 0) Then
                i = i - 1
                DelDiffSettings.LineID = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("LineID").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("LineID").ToString), _
                         String.Empty, ds.Tables("DelDiff").Rows(i)("LineID").ToString)
                DelDiffSettings.OperID = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("OperId").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("OperId").ToString), _
                                         String.Empty, ds.Tables("DelDiff").Rows(i)("OperId").ToString)
                DelDiffSettings.PosCode = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("PosCode").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("PosCode").ToString), _
                                        "", ds.Tables("DelDiff").Rows(i)("PosCode").ToString)
                DelDiffSettings.Barcode = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("Barcode").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("Barcode").ToString), _
                                         "", ds.Tables("DelDiff").Rows(i)("Barcode").ToString)
                DelDiffSettings.WhsCode = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("WhsCode").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("WhsCode").ToString), _
                                         "", ds.Tables("DelDiff").Rows(i)("WhsCode").ToString)
                DelDiffSettings.Description = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("Description").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("Description").ToString), _
                                         "", ds.Tables("DelDiff").Rows(i)("Description").ToString)
                DelDiffSettings.Size = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("Size").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("Size").ToString), _
                                         "", ds.Tables("DelDiff").Rows(i)("Size").ToString)
                DelDiffSettings.Color = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("Color").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("Color").ToString), _
                                         "", ds.Tables("DelDiff").Rows(i)("Color").ToString)
                DelDiffSettings.Qty = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("Qty").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("Qty").ToString), _
                                         0, ds.Tables("DelDiff").Rows(i)("Qty").ToString)
                DelDiffSettings.QtyAffected = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("QtyAffected").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("QtyAffected").ToString), _
                                         0, ds.Tables("DelDiff").Rows(i)("QtyAffected").ToString)
                DelDiffSettings.iUser = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("iUser").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("iUser").ToString), _
                                         Today.Date, ds.Tables("DelDiff").Rows(i)("iUser").ToString)
                Return DelDiffSettings
            Else
                DelDiffSettings.LineID = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("LineID").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("LineID").ToString), _
                         String.Empty, ds.Tables("DelDiff").Rows(i)("LineID").ToString)
                DelDiffSettings.OperID = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("OperId").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("OperId").ToString), _
                                         String.Empty, ds.Tables("DelDiff").Rows(i)("OperId").ToString)
                DelDiffSettings.PosCode = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("PosCode").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("PosCode").ToString), _
                                        "", ds.Tables("DelDiff").Rows(i)("PosCode").ToString)
                DelDiffSettings.Barcode = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("Barcode").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("Barcode").ToString), _
                                         "", ds.Tables("DelDiff").Rows(i)("Barcode").ToString)
                DelDiffSettings.WhsCode = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("WhsCode").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("WhsCode").ToString), _
                                         "", ds.Tables("DelDiff").Rows(i)("WhsCode").ToString)
                DelDiffSettings.Description = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("Description").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("Description").ToString), _
                                         "", ds.Tables("DelDiff").Rows(i)("Description").ToString)
                DelDiffSettings.Size = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("Size").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("Size").ToString), _
                                         "", ds.Tables("DelDiff").Rows(i)("Size").ToString)
                DelDiffSettings.Color = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("Color").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("Color").ToString), _
                                         "", ds.Tables("DelDiff").Rows(i)("Color").ToString)
                DelDiffSettings.Qty = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("Qty").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("Qty").ToString), _
                                         0, ds.Tables("DelDiff").Rows(i)("Qty").ToString)
                DelDiffSettings.QtyAffected = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("QtyAffected").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("QtyAffected").ToString), _
                                         0, ds.Tables("DelDiff").Rows(i)("QtyAffected").ToString)
                DelDiffSettings.iUser = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("iUser").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("iUser").ToString), _
                                         Today.Date, ds.Tables("DelDiff").Rows(i)("iUser").ToString)
                Return DelDiffSettings
            End If
        Catch ex As Exception
            vErr = ex.Message
        End Try
    End Function
    Public Function GetCurrentRecord(ByVal Index As Integer, ByRef vErr As String) As DelDiffSettings
        Try
            Dim DelDiffSettings As New DelDiffSettings
            If ds.Tables("DelDiff").Rows.Count = 0 Then
                DelDiffSettings = Nothing
                vErr = "No Discrepancies To Load"
                Return DelDiffSettings
                Exit Function
            End If
            i = Index
            DelDiffSettings.LineID = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("LineID").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("LineID").ToString), _
                          String.Empty, ds.Tables("DelDiff").Rows(i)("LineID").ToString)
            DelDiffSettings.OperID = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("OperId").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("OperId").ToString), _
                                     String.Empty, ds.Tables("DelDiff").Rows(i)("OperId").ToString)
            DelDiffSettings.PosCode = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("PosCode").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("PosCode").ToString), _
                                    "", ds.Tables("DelDiff").Rows(i)("PosCode").ToString)
            DelDiffSettings.Barcode = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("Barcode").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("Barcode").ToString), _
                                     "", ds.Tables("DelDiff").Rows(i)("Barcode").ToString)
            DelDiffSettings.WhsCode = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("WhsCode").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("WhsCode").ToString), _
                                     "", ds.Tables("DelDiff").Rows(i)("WhsCode").ToString)
            DelDiffSettings.Description = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("Description").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("Description").ToString), _
                                     "", ds.Tables("DelDiff").Rows(i)("Description").ToString)
            DelDiffSettings.Size = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("Size").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("Size").ToString), _
                                     "", ds.Tables("DelDiff").Rows(i)("Size").ToString)
            DelDiffSettings.Color = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("Color").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("Color").ToString), _
                                     "", ds.Tables("DelDiff").Rows(i)("Color").ToString)
            DelDiffSettings.Qty = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("Qty").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("Qty").ToString), _
                                     0, ds.Tables("DelDiff").Rows(i)("Qty").ToString)
            DelDiffSettings.QtyAffected = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("QtyAffected").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("QtyAffected").ToString), _
                                     0, ds.Tables("DelDiff").Rows(i)("QtyAffected").ToString)
            DelDiffSettings.iUser = IIf(IsDBNull(ds.Tables("DelDiff").Rows(i)("iUser").ToString) Or IsNothing(ds.Tables("DelDiff").Rows(i)("iUser").ToString), _
                                     Today.Date, ds.Tables("DelDiff").Rows(i)("iUser").ToString)
            Return DelDiffSettings
        Catch ex As Exception
            vErr = ex.Message
        End Try
    End Function
    Public Function FillDelDiff(ByVal con As SqlConnection) As DataTable
        Try
            Dim blnconnectionOpen As Boolean
            Dim sqlcom As New SqlCommand("SpRt_GetDelDiff", con)
            sqlcom.CommandType = CommandType.StoredProcedure
            Dim da As New SqlDataAdapter(sqlcom)
            Dim dt As New DataTable
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
