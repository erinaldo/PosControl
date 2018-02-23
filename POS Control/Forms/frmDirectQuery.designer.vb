<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDirectQuery
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDirectQuery))
        Me.btnPrintPreview = New DevExpress.XtraEditors.SimpleButton()
        Me.btnHTML = New DevExpress.XtraEditors.SimpleButton()
        Me.btntext = New DevExpress.XtraEditors.SimpleButton()
        Me.btnexcel = New DevExpress.XtraEditors.SimpleButton()
        Me.btnPDF = New DevExpress.XtraEditors.SimpleButton()
        Me.btnGet = New DevExpress.XtraEditors.SimpleButton()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.btnClear = New DevExpress.XtraEditors.SimpleButton()
        Me.btnopen = New DevExpress.XtraEditors.SimpleButton()
        Me.txtSQL = New DevExpress.XtraEditors.TextEdit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSQL.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnPrintPreview
        '
        Me.btnPrintPreview.Image = CType(resources.GetObject("btnPrintPreview.Image"), System.Drawing.Image)
        Me.btnPrintPreview.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnPrintPreview.Location = New System.Drawing.Point(294, 3)
        Me.btnPrintPreview.Name = "btnPrintPreview"
        Me.btnPrintPreview.Size = New System.Drawing.Size(76, 57)
        Me.btnPrintPreview.TabIndex = 21
        Me.btnPrintPreview.Text = "Print Preview"
        '
        'btnHTML
        '
        Me.btnHTML.Image = CType(resources.GetObject("btnHTML.Image"), System.Drawing.Image)
        Me.btnHTML.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnHTML.Location = New System.Drawing.Point(223, 3)
        Me.btnHTML.Name = "btnHTML"
        Me.btnHTML.Size = New System.Drawing.Size(54, 57)
        Me.btnHTML.TabIndex = 20
        Me.btnHTML.Text = "HTML"
        '
        'btntext
        '
        Me.btntext.Image = CType(resources.GetObject("btntext.Image"), System.Drawing.Image)
        Me.btntext.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btntext.Location = New System.Drawing.Point(152, 3)
        Me.btntext.Name = "btntext"
        Me.btntext.Size = New System.Drawing.Size(54, 57)
        Me.btntext.TabIndex = 19
        Me.btntext.Text = "Txt"
        '
        'btnexcel
        '
        Me.btnexcel.Image = CType(resources.GetObject("btnexcel.Image"), System.Drawing.Image)
        Me.btnexcel.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnexcel.Location = New System.Drawing.Point(83, 3)
        Me.btnexcel.Name = "btnexcel"
        Me.btnexcel.Size = New System.Drawing.Size(54, 57)
        Me.btnexcel.TabIndex = 18
        Me.btnexcel.Text = "Excel"
        '
        'btnPDF
        '
        Me.btnPDF.Image = CType(resources.GetObject("btnPDF.Image"), System.Drawing.Image)
        Me.btnPDF.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnPDF.Location = New System.Drawing.Point(12, 3)
        Me.btnPDF.Name = "btnPDF"
        Me.btnPDF.Size = New System.Drawing.Size(54, 57)
        Me.btnPDF.TabIndex = 17
        Me.btnPDF.Text = "PDF"
        '
        'btnGet
        '
        Me.btnGet.Location = New System.Drawing.Point(562, 12)
        Me.btnGet.Name = "btnGet"
        Me.btnGet.Size = New System.Drawing.Size(75, 48)
        Me.btnGet.TabIndex = 14
        Me.btnGet.Text = "Get"
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsFind.AlwaysVisible = True
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.RowHeight = 50
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(2, 110)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1012, 377)
        Me.GridControl1.TabIndex = 11
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(643, 12)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 47)
        Me.btnClear.TabIndex = 22
        Me.btnClear.Text = "Clear"
        '
        'btnopen
        '
        Me.btnopen.Image = CType(resources.GetObject("btnopen.Image"), System.Drawing.Image)
        Me.btnopen.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnopen.Location = New System.Drawing.Point(698, 65)
        Me.btnopen.Name = "btnopen"
        Me.btnopen.Size = New System.Drawing.Size(50, 39)
        Me.btnopen.TabIndex = 23
        Me.btnopen.ToolTip = "Open SQL File"
        '
        'txtSQL
        '
        Me.txtSQL.Location = New System.Drawing.Point(12, 66)
        Me.txtSQL.Name = "txtSQL"
        Me.txtSQL.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSQL.Properties.Appearance.Options.UseFont = True
        Me.txtSQL.Properties.AutoHeight = False
        Me.txtSQL.Size = New System.Drawing.Size(680, 38)
        Me.txtSQL.TabIndex = 64
        '
        'frmDirectQuery
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1014, 484)
        Me.Controls.Add(Me.txtSQL)
        Me.Controls.Add(Me.btnopen)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnPrintPreview)
        Me.Controls.Add(Me.btnHTML)
        Me.Controls.Add(Me.btntext)
        Me.Controls.Add(Me.btnexcel)
        Me.Controls.Add(Me.btnPDF)
        Me.Controls.Add(Me.btnGet)
        Me.Controls.Add(Me.GridControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDirectQuery"
        Me.Text = "Direct Query"
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSQL.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnPrintPreview As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnHTML As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btntext As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnexcel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnPDF As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnGet As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents btnClear As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnopen As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtSQL As DevExpress.XtraEditors.TextEdit
End Class
