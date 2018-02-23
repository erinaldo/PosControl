<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmItemControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmItemControl))
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.CmbWhs = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.txtdesc = New DevExpress.XtraEditors.TextEdit()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Barcode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Description = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColorCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SizeCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MinQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MaxQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Blocked = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CbBlocked = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        CType(Me.CmbWhs.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtdesc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CbBlocked, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "WhsCode"
        '
        'CmbWhs
        '
        Me.CmbWhs.Location = New System.Drawing.Point(85, 9)
        Me.CmbWhs.Name = "CmbWhs"
        Me.CmbWhs.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CmbWhs.Size = New System.Drawing.Size(151, 20)
        Me.CmbWhs.TabIndex = 1
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(317, 45)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(68, 13)
        Me.LabelControl7.TabIndex = 20
        Me.LabelControl7.Text = "By Description"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(14, 45)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(61, 13)
        Me.LabelControl6.TabIndex = 19
        Me.LabelControl6.Text = "Choose Item"
        '
        'txtdesc
        '
        Me.txtdesc.Location = New System.Drawing.Point(101, 42)
        Me.txtdesc.Name = "txtdesc"
        Me.txtdesc.Size = New System.Drawing.Size(197, 20)
        Me.txtdesc.TabIndex = 18
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(12, 68)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CbBlocked})
        Me.GridControl1.Size = New System.Drawing.Size(811, 229)
        Me.GridControl1.TabIndex = 3
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Barcode, Me.Description, Me.ColorCode, Me.SizeCode, Me.MinQty, Me.MaxQty, Me.Blocked})
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.MultiSelect = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'Barcode
        '
        Me.Barcode.Caption = "Barcode"
        Me.Barcode.Name = "Barcode"
        Me.Barcode.OptionsColumn.AllowEdit = False
        Me.Barcode.Visible = True
        Me.Barcode.VisibleIndex = 0
        '
        'Description
        '
        Me.Description.Caption = "Description"
        Me.Description.Name = "Description"
        Me.Description.OptionsColumn.AllowEdit = False
        Me.Description.Visible = True
        Me.Description.VisibleIndex = 1
        '
        'ColorCode
        '
        Me.ColorCode.Caption = "ColorCode"
        Me.ColorCode.Name = "ColorCode"
        Me.ColorCode.OptionsColumn.AllowEdit = False
        Me.ColorCode.Visible = True
        Me.ColorCode.VisibleIndex = 2
        '
        'SizeCode
        '
        Me.SizeCode.Caption = "SizeCode"
        Me.SizeCode.Name = "SizeCode"
        Me.SizeCode.OptionsColumn.AllowEdit = False
        Me.SizeCode.Visible = True
        Me.SizeCode.VisibleIndex = 3
        '
        'MinQty
        '
        Me.MinQty.Caption = "MinQty"
        Me.MinQty.Name = "MinQty"
        Me.MinQty.Visible = True
        Me.MinQty.VisibleIndex = 4
        '
        'MaxQty
        '
        Me.MaxQty.Caption = "MaxQty"
        Me.MaxQty.Name = "MaxQty"
        Me.MaxQty.Visible = True
        Me.MaxQty.VisibleIndex = 5
        '
        'Blocked
        '
        Me.Blocked.Caption = "Blocked"
        Me.Blocked.ColumnEdit = Me.CbBlocked
        Me.Blocked.Name = "Blocked"
        Me.Blocked.Visible = True
        Me.Blocked.VisibleIndex = 6
        '
        'CbBlocked
        '
        Me.CbBlocked.AutoHeight = False
        Me.CbBlocked.Caption = "Blocked"
        Me.CbBlocked.Name = "CbBlocked"
        '
        'FrmItemControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(835, 309)
        Me.Controls.Add(Me.LabelControl7)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.txtdesc)
        Me.Controls.Add(Me.CmbWhs)
        Me.Controls.Add(Me.LabelControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmItemControl"
        Me.Text = "Item Control"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.CmbWhs.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtdesc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CbBlocked, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout

End Sub
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CmbWhs As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtdesc As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Barcode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Description As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MinQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MaxQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColorCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SizeCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Blocked As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CbBlocked As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
End Class
