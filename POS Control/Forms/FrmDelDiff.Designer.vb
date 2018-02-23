<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDelDiff
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
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDelDiff))
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LineID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.OperID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.WhsCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PosCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Description = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Barcode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Color = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Size = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Qty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.QtyAffected = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Clear = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BtnClear = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnClear, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridControl1
        '
        Me.GridControl1.Location = New System.Drawing.Point(2, 2)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.BtnClear})
        Me.GridControl1.Size = New System.Drawing.Size(758, 310)
        Me.GridControl1.TabIndex = 20
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.LineID, Me.OperID, Me.WhsCode, Me.PosCode, Me.Description, Me.Barcode, Me.Color, Me.Size, Me.Qty, Me.QtyAffected, Me.Clear})
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'LineID
        '
        Me.LineID.Caption = "LineID"
        Me.LineID.Name = "LineID"
        '
        'OperID
        '
        Me.OperID.Caption = "OperID"
        Me.OperID.Name = "OperID"
        Me.OperID.OptionsColumn.AllowEdit = False
        Me.OperID.Visible = True
        Me.OperID.VisibleIndex = 0
        '
        'WhsCode
        '
        Me.WhsCode.Caption = "WhsCode"
        Me.WhsCode.Name = "WhsCode"
        Me.WhsCode.OptionsColumn.AllowEdit = False
        Me.WhsCode.Visible = True
        Me.WhsCode.VisibleIndex = 1
        '
        'PosCode
        '
        Me.PosCode.Caption = "PosCode"
        Me.PosCode.Name = "PosCode"
        Me.PosCode.OptionsColumn.AllowEdit = False
        Me.PosCode.Visible = True
        Me.PosCode.VisibleIndex = 2
        '
        'Description
        '
        Me.Description.Caption = "Item Desc"
        Me.Description.Name = "Description"
        Me.Description.OptionsColumn.AllowEdit = False
        Me.Description.Visible = True
        Me.Description.VisibleIndex = 3
        '
        'Barcode
        '
        Me.Barcode.Caption = "Barcode"
        Me.Barcode.Name = "Barcode"
        Me.Barcode.OptionsColumn.AllowEdit = False
        Me.Barcode.Visible = True
        Me.Barcode.VisibleIndex = 4
        '
        'Color
        '
        Me.Color.Caption = "Color"
        Me.Color.Name = "Color"
        Me.Color.OptionsColumn.AllowEdit = False
        Me.Color.Visible = True
        Me.Color.VisibleIndex = 5
        '
        'Size
        '
        Me.Size.Caption = "Size"
        Me.Size.Name = "Size"
        Me.Size.OptionsColumn.AllowEdit = False
        Me.Size.Visible = True
        Me.Size.VisibleIndex = 6
        '
        'Qty
        '
        Me.Qty.Caption = "Qty"
        Me.Qty.Name = "Qty"
        Me.Qty.OptionsColumn.AllowEdit = False
        Me.Qty.Visible = True
        Me.Qty.VisibleIndex = 7
        '
        'QtyAffected
        '
        Me.QtyAffected.Caption = "QtyAffected"
        Me.QtyAffected.Name = "QtyAffected"
        Me.QtyAffected.OptionsColumn.AllowEdit = False
        Me.QtyAffected.Visible = True
        Me.QtyAffected.VisibleIndex = 8
        '
        'Clear
        '
        Me.Clear.Caption = "Clear"
        Me.Clear.ColumnEdit = Me.BtnClear
        Me.Clear.Name = "Clear"
        Me.Clear.Visible = True
        Me.Clear.VisibleIndex = 9
        '
        'BtnClear
        '
        Me.BtnClear.AutoHeight = False
        Me.BtnClear.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear, "Clear", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, True)})
        Me.BtnClear.Name = "BtnClear"
        Me.BtnClear.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'FrmDelDiff
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(763, 315)
        Me.Controls.Add(Me.GridControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmDelDiff"
        Me.Text = "Delivery Discrepancy <" & My.Application.Info.Version.ToString & "> View Mode"
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnClear, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LineID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents OperID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents WhsCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PosCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Description As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Barcode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Color As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Size As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Qty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents QtyAffected As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Clear As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BtnClear As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
End Class
