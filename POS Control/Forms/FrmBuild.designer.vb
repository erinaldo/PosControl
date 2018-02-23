<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBuild
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBuild))
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtquery = New DevExpress.XtraEditors.TextEdit()
        Me.txtPath = New DevExpress.XtraEditors.TextEdit()
        Me.CBQuery = New DevExpress.XtraEditors.CheckEdit()
        Me.btnGetValues = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.txtquery.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPath.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CBQuery.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(2, 26)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(56, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Table Name"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(2, 62)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(22, 13)
        Me.LabelControl2.TabIndex = 1
        Me.LabelControl2.Text = "Path"
        '
        'txtquery
        '
        Me.txtquery.Location = New System.Drawing.Point(64, 18)
        Me.txtquery.Name = "txtquery"
        Me.txtquery.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtquery.Properties.Appearance.Options.UseFont = True
        Me.txtquery.Properties.AutoHeight = False
        Me.txtquery.Size = New System.Drawing.Size(225, 31)
        Me.txtquery.TabIndex = 2
        '
        'txtPath
        '
        Me.txtPath.Location = New System.Drawing.Point(46, 55)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.txtPath.Properties.Appearance.Options.UseFont = True
        Me.txtPath.Properties.AutoHeight = False
        Me.txtPath.Size = New System.Drawing.Size(259, 31)
        Me.txtPath.TabIndex = 3
        '
        'CBQuery
        '
        Me.CBQuery.Location = New System.Drawing.Point(295, 24)
        Me.CBQuery.Name = "CBQuery"
        Me.CBQuery.Properties.Caption = "Query"
        Me.CBQuery.Size = New System.Drawing.Size(56, 19)
        Me.CBQuery.TabIndex = 4
        '
        'btnGetValues
        '
        Me.btnGetValues.Location = New System.Drawing.Point(356, 12)
        Me.btnGetValues.Name = "btnGetValues"
        Me.btnGetValues.Size = New System.Drawing.Size(75, 45)
        Me.btnGetValues.TabIndex = 5
        Me.btnGetValues.Text = "Get Values"
        '
        'FrmBuild
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(443, 92)
        Me.Controls.Add(Me.btnGetValues)
        Me.Controls.Add(Me.CBQuery)
        Me.Controls.Add(Me.txtPath)
        Me.Controls.Add(Me.txtquery)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "FrmBuild"
        Me.Text = "Build"
        CType(Me.txtquery.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPath.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CBQuery.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtquery As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPath As DevExpress.XtraEditors.TextEdit
    Friend WithEvents CBQuery As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents btnGetValues As DevExpress.XtraEditors.SimpleButton
End Class
