<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLogs
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLogs))
        Me.TreeList1 = New DevExpress.XtraTreeList.TreeList()
        Me.RichEditControl1 = New DevExpress.XtraRichEdit.RichEditControl()
        CType(Me.TreeList1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TreeList1
        '
        Me.TreeList1.Dock = System.Windows.Forms.DockStyle.Left
        Me.TreeList1.Location = New System.Drawing.Point(0, 0)
        Me.TreeList1.Name = "TreeList1"
        Me.TreeList1.OptionsBehavior.Editable = False
        Me.TreeList1.Size = New System.Drawing.Size(341, 413)
        Me.TreeList1.TabIndex = 0
        '
        'RichEditControl1
        '
        Me.RichEditControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichEditControl1.EnableToolTips = True
        Me.RichEditControl1.Location = New System.Drawing.Point(341, 0)
        Me.RichEditControl1.Name = "RichEditControl1"
        Me.RichEditControl1.Options.Bookmarks.AllowNameResolution = False
        Me.RichEditControl1.ReadOnly = True
        Me.RichEditControl1.Size = New System.Drawing.Size(379, 413)
        Me.RichEditControl1.TabIndex = 1
        Me.RichEditControl1.Text = "Please Select The Log You Want To Load"
        '
        'FrmLogs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(720, 413)
        Me.Controls.Add(Me.RichEditControl1)
        Me.Controls.Add(Me.TreeList1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmLogs"
        Me.Text = "Logs"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.TreeList1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TreeList1 As DevExpress.XtraTreeList.TreeList
    Friend WithEvents RichEditControl1 As DevExpress.XtraRichEdit.RichEditControl
End Class
