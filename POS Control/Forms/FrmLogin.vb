Imports System.Data.SqlClient
Imports ConnectionSQL
Public Class FrmLogin
    Inherits DevExpress.XtraEditors.XtraForm
    Public Shared db As String
    Public Shared server As String
    Public Shared user As String
    Public Shared pass As String
    Public Shared groupname As String
    Public objcon As New ConnSQL
    Private Sub btnlogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlogin.Click
        Try
            If txtUsername.Text.Length = 0 Then
                MessageBox.Show("Username Is A Required Field", "Username Empty", MessageBoxButtons.OK)
                txtUsername.Focus()
                Exit Sub
            End If
            If txtserver.Text.Length = 0 Then
                MessageBox.Show("Server Is A Required Field", "Server Empty", MessageBoxButtons.OK)
                txtserver.Focus()
                Exit Sub
            End If
            If txtdatabase.Text.Length = 0 Then
                MessageBox.Show("Database Is A Required Field", "Database Empty", MessageBoxButtons.OK)
                txtdatabase.Focus()
                Exit Sub
            End If
            user = txtUsername.Text
            pass = txtpassword.Text
            server = txtserver.Text
            db = txtdatabase.Text
            If (CBSaveSettings.Checked) Then
                WriteOut()
            End If
            Dim strselect As String = "SELECT groupname FROM SacUsers WHERE username = '" + user + "'"
            objcon = New ConnSQL
            Dim cmd As New SqlCommand(strselect)
            Dim blnconnectionOpen As Boolean
            blnconnectionOpen = ConnStatus(objcon.con)
            If Not blnconnectionOpen Then ConnOpen(objcon.con)
            cmd.Connection = objcon.con
            Dim rdr = cmd.ExecuteReader
            If rdr.Read Then
               rdr.Close()
                FrmMainForm.Show()
                Me.Close()
                Exit Sub
            Else
                rdr.Close()
                MessageBox.Show("Invalid Username Or Password!", "Login Denied", MessageBoxButtons.OK)
                txtUsername.ResetText()
                txtpassword.ResetText()
                txtUsername.Focus()
                CBSaveSettings.Enabled = True
            End If
            'If rdr.Read Then
            '    groupname = rdr.Item(0)
            '    Dim strselect1 As String = "SELECT active FROM sacgroup WHERE groupname='" + groupname + "'"
            '    Dim cmd1 As New SqlCommand(strselect1)
            '    cmd1.Connection = objcon.con
            '    rdr.Close()
            '    Dim rdr1 = cmd1.ExecuteReader()
            '    If rdr1.Read Then
            '        Dim active = rdr1.Item(0)
            '        If active = True Then
            '            rdr1.Close()
            '            Me.Visible = False
            '            frmMainForm.Show()
            '            Me.Close()
            '        Else
            '            MessageBox.Show("Group Not Active", "Error", MessageBoxButtons.OK)
            '            rdr1.Close()
            '            Exit Sub
            '        End If
            '    End If
            '    Exit Sub
            'Else
            '    rdr.Close()
            '    MessageBox.Show("Invalid Username Or Password!", "Login Denied", MessageBoxButtons.OK)
            '    txtusername.ResetText()
            '    txtpassword.ResetText()
            '    txtusername.Focus()
            '    CBSaveSettings.Enabled = True
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub WriteOut()
        Try
            My.Computer.Registry.CurrentUser.CreateSubKey("PosControl\Settings")
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\PosControl\Settings", "Username", txtUsername.Text)
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\PosControl\Settings", "Database", txtdatabase.Text)
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\PosControl\Settings", "Server", txtserver.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub read()
        Try
            txtUsername.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\PosControl\Settings", "Username", "Username").ToString
            txtserver.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\PosControl\Settings", "Server", "Server").ToString
            txtdatabase.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\PosControl\Settings", "Database", "Database").ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FrmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Login " & String.Format("V {0}", My.Application.Info.Version.ToString)
        DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "DevExpress Style"
        Try
            If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\PosControl\Settings", "Username", Nothing) Is Nothing Then
                Exit Sub
            Else
                read()
                txtpassword.Select()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        End
    End Sub

    Private Sub txtpassword_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtpassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnlogin.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub
End Class
