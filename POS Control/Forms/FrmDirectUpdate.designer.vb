<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDirectUpdate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDirectUpdate))
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.CBQuery = New DevExpress.XtraEditors.CheckEdit()
        Me.btnGet = New DevExpress.XtraEditors.SimpleButton()
        Me.btnedit = New DevExpress.XtraEditors.SimpleButton()
        Me.btnsave = New DevExpress.XtraEditors.SimpleButton()
        Me.btnPDF = New DevExpress.XtraEditors.SimpleButton()
        Me.btnexcel = New DevExpress.XtraEditors.SimpleButton()
        Me.btntext = New DevExpress.XtraEditors.SimpleButton()
        Me.btnHTML = New DevExpress.XtraEditors.SimpleButton()
        Me.btnPrintPreview = New DevExpress.XtraEditors.SimpleButton()
        Me.txtSQL = New DevExpress.XtraEditors.TextEdit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CBQuery.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSQL.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(2, 108)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(963, 365)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsFind.AlwaysVisible = True
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.RowHeight = 50
        '
        'CBQuery
        '
        Me.CBQuery.Location = New System.Drawing.Point(500, 29)
        Me.CBQuery.Name = "CBQuery"
        Me.CBQuery.Properties.Caption = "Query"
        Me.CBQuery.Size = New System.Drawing.Size(56, 19)
        Me.CBQuery.TabIndex = 2
        '
        'btnGet
        '
        Me.btnGet.Location = New System.Drawing.Point(562, 12)
        Me.btnGet.Name = "btnGet"
        Me.btnGet.Size = New System.Drawing.Size(75, 47)
        Me.btnGet.TabIndex = 3
        Me.btnGet.Text = "Get"
        '
        'btnedit
        '
        Me.btnedit.Location = New System.Drawing.Point(643, 12)
        Me.btnedit.Name = "btnedit"
        Me.btnedit.Size = New System.Drawing.Size(75, 46)
        Me.btnedit.TabIndex = 4
        Me.btnedit.Text = "Edit"
        '
        'btnsave
        '
        Me.btnsave.Location = New System.Drawing.Point(643, 12)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(75, 47)
        Me.btnsave.TabIndex = 5
        Me.btnsave.Text = "Save"
        '
        'btnPDF
        '
        Me.btnPDF.Image = CType(resources.GetObject("btnPDF.Image"), System.Drawing.Image)
        Me.btnPDF.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnPDF.Location = New System.Drawing.Point(12, 2)
        Me.btnPDF.Name = "btnPDF"
        Me.btnPDF.Size = New System.Drawing.Size(54, 57)
        Me.btnPDF.TabIndex = 6
        Me.btnPDF.Text = "PDF"
        '
        'btnexcel
        '
        Me.btnexcel.Image = CType(resources.GetObject("btnexcel.Image"), System.Drawing.Image)
        Me.btnexcel.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnexcel.Location = New System.Drawing.Point(83, 2)
        Me.btnexcel.Name = "btnexcel"
        Me.btnexcel.Size = New System.Drawing.Size(54, 57)
        Me.btnexcel.TabIndex = 7
        Me.btnexcel.Text = "Excel"
        '
        'btntext
        '
        Me.btntext.Image = CType(resources.GetObject("btntext.Image"), System.Drawing.Image)
        Me.btntext.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btntext.Location = New System.Drawing.Point(152, 2)
        Me.btntext.Name = "btntext"
        Me.btntext.Size = New System.Drawing.Size(54, 57)
        Me.btntext.TabIndex = 8
        Me.btntext.Text = "Txt"
        '
        'btnHTML
        '
        Me.btnHTML.Image = CType(resources.GetObject("btnHTML.Image"), System.Drawing.Image)
        Me.btnHTML.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnHTML.Location = New System.Drawing.Point(223, 2)
        Me.btnHTML.Name = "btnHTML"
        Me.btnHTML.Size = New System.Drawing.Size(54, 57)
        Me.btnHTML.TabIndex = 9
        Me.btnHTML.Text = "HTML"
        '
        'btnPrintPreview
        '
        Me.btnPrintPreview.Image = CType(resources.GetObject("btnPrintPreview.Image"), System.Drawing.Image)
        Me.btnPrintPreview.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnPrintPreview.Location = New System.Drawing.Point(294, 2)
        Me.btnPrintPreview.Name = "btnPrintPreview"
        Me.btnPrintPreview.Size = New System.Drawing.Size(76, 57)
        Me.btnPrintPreview.TabIndex = 10
        Me.btnPrintPreview.Text = "Print Preview"
        '
        'txtSQL
        '
        Me.txtSQL.Location = New System.Drawing.Point(12, 65)
        Me.txtSQL.Name = "txtSQL"
        Me.txtSQL.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSQL.Properties.Appearance.Options.UseFont = True
        Me.txtSQL.Properties.AutoHeight = False
        Me.txtSQL.Size = New System.Drawing.Size(927, 38)
        Me.txtSQL.TabIndex = 65
        '
        'FrmDirectUpdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(965, 474)
        Me.Controls.Add(Me.txtSQL)
        Me.Controls.Add(Me.btnPrintPreview)
        Me.Controls.Add(Me.btnHTML)
        Me.Controls.Add(Me.btntext)
        Me.Controls.Add(Me.btnexcel)
        Me.Controls.Add(Me.btnPDF)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.btnedit)
        Me.Controls.Add(Me.btnGet)
        Me.Controls.Add(Me.CBQuery)
        Me.Controls.Add(Me.GridControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmDirectUpdate"
        Me.Text = "Direct Update"
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CBQuery.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSQL.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents CBQuery As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents btnGet As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnedit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnsave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnPDF As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnexcel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btntext As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnHTML As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnPrintPreview As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtSQL As DevExpress.XtraEditors.TextEdit
End Class
