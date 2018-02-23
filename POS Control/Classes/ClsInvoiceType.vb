Imports System.Data.SqlClient
Imports ConnectionSQL
Public Class ClsInvoiceType
    Dim da As New SqlDataAdapter
    Function FillInvoiceType(ByVal con As SqlConnection) As DataTable
        Try
            Dim dt As New DataTable
            Dim blnconnectionOpen As Boolean
            Dim sqlcomm As New SqlCommand("Select InvTypeID,InvoiceCode from IvInvoiceType1Es", con)
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
End Class
