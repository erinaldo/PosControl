<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPOS
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPOS))
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.txtServer = New DevExpress.XtraEditors.TextEdit()
        Me.txtDB = New DevExpress.XtraEditors.TextEdit()
        Me.txtUser = New DevExpress.XtraEditors.TextEdit()
        Me.txtPass = New DevExpress.XtraEditors.TextEdit()
        Me.txtPOs = New DevExpress.XtraEditors.TextEdit()
        Me.BtnGenerate = New DevExpress.XtraEditors.SimpleButton()
        Me.lbl = New DevExpress.XtraEditors.LabelControl()
        Me.txtWHS = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.txtthirdid = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.txtSalesManID = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.btnRegenerate = New DevExpress.XtraEditors.SimpleButton()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.ProgressBarControl1 = New DevExpress.XtraEditors.ProgressBarControl()
        CType(Me.txtServer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDB.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUser.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPass.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPOs.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtWHS.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtthirdid.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSalesManID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 21)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(48, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "POS Code"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 82)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(32, 13)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "Server"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(12, 114)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl3.TabIndex = 3
        Me.LabelControl3.Text = "Database"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(12, 151)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(22, 13)
        Me.LabelControl4.TabIndex = 4
        Me.LabelControl4.Text = "User"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(12, 185)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl5.TabIndex = 5
        Me.LabelControl5.Text = "Password"
        '
        'txtServer
        '
        Me.txtServer.Location = New System.Drawing.Point(118, 79)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(176, 20)
        Me.txtServer.TabIndex = 2
        '
        'txtDB
        '
        Me.txtDB.Location = New System.Drawing.Point(118, 111)
        Me.txtDB.Name = "txtDB"
        Me.txtDB.Size = New System.Drawing.Size(176, 20)
        Me.txtDB.TabIndex = 3
        '
        'txtUser
        '
        Me.txtUser.Location = New System.Drawing.Point(118, 148)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(176, 20)
        Me.txtUser.TabIndex = 4
        '
        'txtPass
        '
        Me.txtPass.Location = New System.Drawing.Point(118, 182)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.Size = New System.Drawing.Size(176, 20)
        Me.txtPass.TabIndex = 5
        '
        'txtPOs
        '
        Me.txtPOs.Location = New System.Drawing.Point(118, 18)
        Me.txtPOs.Name = "txtPOs"
        Me.txtPOs.Size = New System.Drawing.Size(176, 20)
        Me.txtPOs.TabIndex = 0
        '
        'BtnGenerate
        '
        Me.BtnGenerate.Appearance.Options.UseTextOptions = True
        Me.BtnGenerate.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BtnGenerate.Location = New System.Drawing.Point(317, 252)
        Me.BtnGenerate.Name = "BtnGenerate"
        Me.BtnGenerate.Size = New System.Drawing.Size(75, 36)
        Me.BtnGenerate.TabIndex = 11
        Me.BtnGenerate.Text = "Generate POS"
        '
        'lbl
        '
        Me.lbl.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.Appearance.ForeColor = System.Drawing.Color.DarkRed
        Me.lbl.Location = New System.Drawing.Point(356, 211)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(106, 18)
        Me.lbl.TabIndex = 12
        Me.lbl.Text = "LabelControl6"
        '
        'txtWHS
        '
        Me.txtWHS.Location = New System.Drawing.Point(118, 47)
        Me.txtWHS.Name = "txtWHS"
        Me.txtWHS.Size = New System.Drawing.Size(176, 20)
        Me.txtWHS.TabIndex = 1
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(12, 50)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(51, 13)
        Me.LabelControl6.TabIndex = 13
        Me.LabelControl6.Text = "WHS Code"
        '
        'txtthirdid
        '
        Me.txtthirdid.Location = New System.Drawing.Point(118, 212)
        Me.txtthirdid.Name = "txtthirdid"
        Me.txtthirdid.Size = New System.Drawing.Size(176, 20)
        Me.txtthirdid.TabIndex = 15
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(12, 215)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl7.TabIndex = 14
        Me.LabelControl7.Text = "ThirdID"
        '
        'txtSalesManID
        '
        Me.txtSalesManID.Location = New System.Drawing.Point(118, 249)
        Me.txtSalesManID.Name = "txtSalesManID"
        Me.txtSalesManID.Size = New System.Drawing.Size(176, 20)
        Me.txtSalesManID.TabIndex = 19
        '
        'LabelControl9
        '
        Me.LabelControl9.Location = New System.Drawing.Point(12, 252)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(56, 13)
        Me.LabelControl9.TabIndex = 18
        Me.LabelControl9.Text = "SalesManID"
        '
        'btnRegenerate
        '
        Me.btnRegenerate.Appearance.Options.UseTextOptions = True
        Me.btnRegenerate.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.btnRegenerate.Location = New System.Drawing.Point(420, 252)
        Me.btnRegenerate.Name = "btnRegenerate"
        Me.btnRegenerate.Size = New System.Drawing.Size(75, 36)
        Me.btnRegenerate.TabIndex = 21
        Me.btnRegenerate.Text = "Regenerate?"
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        '
        'ProgressBarControl1
        '
        Me.ProgressBarControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBarControl1.Location = New System.Drawing.Point(12, 307)
        Me.ProgressBarControl1.Name = "ProgressBarControl1"
        Me.ProgressBarControl1.Properties.ShowTitle = True
        Me.ProgressBarControl1.Size = New System.Drawing.Size(573, 22)
        Me.ProgressBarControl1.TabIndex = 22
        Me.ProgressBarControl1.Visible = False
        '
        'FrmPOS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(597, 332)
        Me.Controls.Add(Me.ProgressBarControl1)
        Me.Controls.Add(Me.btnRegenerate)
        Me.Controls.Add(Me.txtSalesManID)
        Me.Controls.Add(Me.LabelControl9)
        Me.Controls.Add(Me.txtthirdid)
        Me.Controls.Add(Me.LabelControl7)
        Me.Controls.Add(Me.txtWHS)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.lbl)
        Me.Controls.Add(Me.BtnGenerate)
        Me.Controls.Add(Me.txtPOs)
        Me.Controls.Add(Me.txtPass)
        Me.Controls.Add(Me.txtUser)
        Me.Controls.Add(Me.txtDB)
        Me.Controls.Add(Me.txtServer)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmPOS"
        Me.Text = "POS"
        CType(Me.txtServer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDB.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUser.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPass.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPOs.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtWHS.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtthirdid.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSalesManID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtServer As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtDB As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtUser As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPass As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPOs As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BtnGenerate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtWHS As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtthirdid As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtSalesManID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnRegenerate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents ProgressBarControl1 As DevExpress.XtraEditors.ProgressBarControl
End Class
