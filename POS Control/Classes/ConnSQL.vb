Imports System.Data.SqlClient
Public Class ConnSQL
    Public strconnection As String = "Data Source ='" & FrmLogin.server & "';Initial Catalog='" & FrmLogin.db & "';user ID='" & FrmLogin.user & "';password='" & FrmLogin.pass & "'; Connection Timeout=0"
    Public con As SqlConnection = New SqlConnection(strconnection)
End Class
