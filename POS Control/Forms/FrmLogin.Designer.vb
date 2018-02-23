<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLogin
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLogin))
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtUsername = New DevExpress.XtraEditors.TextEdit()
        Me.txtpassword = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.txtdatabase = New DevExpress.XtraEditors.TextEdit()
        Me.txtserver = New DevExpress.XtraEditors.TextEdit()
        Me.btnlogin = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.CBSaveSettings = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.txtUsername.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtpassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtdatabase.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtserver.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CBSaveSettings.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(5, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(48, 13)
        Me.LabelControl1.TabIndex = 24
        Me.LabelControl1.Text = "Username"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(5, 45)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl2.TabIndex = 25
        Me.LabelControl2.Text = "Password"
        '
        'txtUsername
        '
        Me.txtUsername.EnterMoveNextControl = True
        Me.txtUsername.Location = New System.Drawing.Point(76, 12)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(257, 20)
        Me.txtUsername.TabIndex = 26
        '
        'txtpassword
        '
        Me.txtpassword.EditValue = ""
        Me.txtpassword.EnterMoveNextControl = True
        Me.txtpassword.Location = New System.Drawing.Point(76, 42)
        Me.txtpassword.Name = "txtpassword"
        Me.txtpassword.Properties.UseSystemPasswordChar = True
        Me.txtpassword.Size = New System.Drawing.Size(257, 20)
        Me.txtpassword.TabIndex = 27
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(5, 77)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl4.TabIndex = 28
        Me.LabelControl4.Text = "Database"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(5, 112)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(32, 13)
        Me.LabelControl3.TabIndex = 29
        Me.LabelControl3.Text = "Server"
        '
        'txtdatabase
        '
        Me.txtdatabase.EditValue = ""
        Me.txtdatabase.EnterMoveNextControl = True
        Me.txtdatabase.Location = New System.Drawing.Point(76, 74)
        Me.txtdatabase.Name = "txtdatabase"
        Me.txtdatabase.Size = New System.Drawing.Size(257, 20)
        Me.txtdatabase.TabIndex = 30
        '
        'txtserver
        '
        Me.txtserver.EditValue = ""
        Me.txtserver.EnterMoveNextControl = True
        Me.txtserver.Location = New System.Drawing.Point(76, 109)
        Me.txtserver.Name = "txtserver"
        Me.txtserver.Size = New System.Drawing.Size(257, 20)
        Me.txtserver.TabIndex = 31
        '
        'btnlogin
        '
        Me.btnlogin.Location = New System.Drawing.Point(209, 160)
        Me.btnlogin.Name = "btnlogin"
        Me.btnlogin.Size = New System.Drawing.Size(59, 31)
        Me.btnlogin.TabIndex = 32
        Me.btnlogin.Text = "Login"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(274, 160)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(59, 31)
        Me.btnClose.TabIndex = 33
        Me.btnClose.Text = "Close"
        '
        'CBSaveSettings
        '
        Me.CBSaveSettings.Location = New System.Drawing.Point(245, 135)
        Me.CBSaveSettings.Name = "CBSaveSettings"
        Me.CBSaveSettings.Properties.Caption = "Save Settings"
        Me.CBSaveSettings.Size = New System.Drawing.Size(88, 19)
        Me.CBSaveSettings.TabIndex = 34
        Me.CBSaveSettings.ToolTip = "Save Settings For Login"
        '
        'FrmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(338, 197)
        Me.Controls.Add(Me.CBSaveSettings)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnlogin)
        Me.Controls.Add(Me.txtserver)
        Me.Controls.Add(Me.txtdatabase)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.txtpassword)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmLogin"
        Me.Text = "Login"
        CType(Me.txtUsername.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtpassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtdatabase.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtserver.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CBSaveSettings.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtUsername As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtpassword As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtdatabase As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtserver As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnlogin As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents CBSaveSettings As DevExpress.XtraEditors.CheckEdit
End Class
