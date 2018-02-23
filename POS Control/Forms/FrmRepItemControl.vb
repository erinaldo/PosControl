Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient

Public Class FrmRepItemControl
    Implements Procedures
    Dim BoConxString = "Data Source ='" & FrmMainForm.BOServer & "';Initial Catalog='" & FrmMainForm.BODatabase & "';user ID='" & FrmMainForm.BOUser & "';password='" & FrmMainForm.BOPass & "'"
    Dim BoCnx As SqlConnection = New SqlConnection(BoConxString)
    Private Sub FrmRepItemControl_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        MenuLockUnlock(False, False)
    End Sub
    Private Sub FrmRepItemControl_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            GetPOS()
            FillItems()
            CmbWHS.EditValue = "All"
            RgCleared.EditValue = -1
            CmbItems.EditValue = 0
            Me.Text = "Item Control Report <" & My.Application.Info.Version.ToString & ">"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub FillItems()
        Try
            Dim SqlCom As New SqlCommand("Select ItemAID,Description From IvItemA1ES where AllowSell = 1 order by Description", BoCnx)
            Dim dt As New DataTable
            If BoCnx.State = ConnectionState.Closed Then
                BoCnx.Open()
            End If
            Dim da As New SqlDataAdapter(SqlCom)
            da.Fill(dt)
            Dim row As DataRow = dt.NewRow
            row("ItemAID") = "0"
            row("Description") = "All"
            dt.Rows.InsertAt(row, 0)
            CmbItems.Properties.DisplayMember = "Description"
            CmbItems.Properties.ValueMember = "ItemAID"
            CmbItems.Properties.DataSource = dt
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub GetPOS()
        Try
            Dim ClsPOS As New ClsPOS
            Dim dt As New DataTable
            dt = ClsPOS.FillWHS(BoCnx)
            Dim row As DataRow = dt.NewRow
            row("WhsCode") = "All"
            row("Description") = "All"
            dt.Rows.InsertAt(row, 0)
            CmbWHS.Properties.DisplayMember = "Description"
            CmbWHS.Properties.ValueMember = "WhsCode"
            CmbWHS.Properties.DataSource = dt
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Function cancel() As Object Implements Procedures.cancel
        Return False
    End Function

    Public Sub close1() Implements Procedures.close
        Me.Close()
    End Sub

    Public Sub DeleteRecord() Implements Procedures.DeleteRecord
        Exit Sub
    End Sub

    Public Function EditRecord() As Object Implements Procedures.EditRecord
        Return False
    End Function

    Public Sub FillDefault() Implements Procedures.FillDefault
        Exit Sub
    End Sub

    Public Sub find() Implements Procedures.find
        Exit Sub
    End Sub

    Public Sub FirstRecord() Implements Procedures.FirstRecord
        Exit Sub
    End Sub

    Public Sub lastRecord() Implements Procedures.lastRecord
        Exit Sub
    End Sub

    Public Sub LockUnlockMe() Implements Procedures.LockUnlockMe
        Exit Sub
    End Sub

    Public Sub MenuLockUnlock(ByVal Adding As Boolean, ByVal Editing As Boolean) Implements Procedures.MenuLockUnlock
        Try
            If Adding = True Or Editing = True Then
                FrmMainForm.btnFirst.Enabled = False
                FrmMainForm.FirstToolStripMenuItem.Enabled = False
                FrmMainForm.btnnext.Enabled = False
                FrmMainForm.NextToolStripMenuItem.Enabled = False
                FrmMainForm.btnLast.Enabled = False
                FrmMainForm.LastToolStripMenuItem.Enabled = False
                FrmMainForm.btnprevious.Enabled = False
                FrmMainForm.PreviousToolStripMenuItem.Enabled = False
                FrmMainForm.NewToolStrip.Enabled = False
                FrmMainForm.NewToolStripMenuItem.Enabled = False
                FrmMainForm.EditToolStrip.Enabled = False
                FrmMainForm.EditToolStripMenuItem.Enabled = False
                FrmMainForm.SaveToolStrip.Enabled = True
                FrmMainForm.SaveToolStripMenuItem.Enabled = True
                FrmMainForm.UndoToolStrip.Enabled = True
                FrmMainForm.UndoToolStripMenuItem.Enabled = True
                FrmMainForm.FindToolstrip.Enabled = False
                FrmMainForm.FindToolStripMenuItem.Enabled = False
                FrmMainForm.DeleteToolStrip.Enabled = False
                FrmMainForm.DeleteToolStripMenuItem.Enabled = False
                FrmMainForm.SearchToolStrip.Enabled = False
                FrmMainForm.BrowseToolStripMenuItem.Enabled = False
                FrmMainForm.RefreshToolStrip.Enabled = False
                FrmMainForm.RefreshToolStripMenuItem.Enabled = False
                FrmMainForm.PrintToolStrip.Enabled = False
                FrmMainForm.PrintToolStripMenuItem.Enabled = False
                FrmMainForm.CloseToolStrip.Enabled = False
                FrmMainForm.CloseToolStripMenuItem.Enabled = False
            Else
                FrmMainForm.btnFirst.Enabled = True
                FrmMainForm.FirstToolStripMenuItem.Enabled = True
                FrmMainForm.btnnext.Enabled = True
                FrmMainForm.NextToolStripMenuItem.Enabled = True
                FrmMainForm.btnLast.Enabled = True
                FrmMainForm.LastToolStripMenuItem.Enabled = True
                FrmMainForm.btnprevious.Enabled = True
                FrmMainForm.PreviousToolStripMenuItem.Enabled = True
                FrmMainForm.NewToolStrip.Enabled = True
                FrmMainForm.NewToolStripMenuItem.Enabled = True
                FrmMainForm.EditToolStrip.Enabled = True
                FrmMainForm.EditToolStripMenuItem.Enabled = True
                FrmMainForm.SaveToolStrip.Enabled = False
                FrmMainForm.SaveToolStripMenuItem.Enabled = False
                FrmMainForm.UndoToolStrip.Enabled = False
                FrmMainForm.UndoToolStripMenuItem.Enabled = False
                FrmMainForm.FindToolstrip.Enabled = True
                FrmMainForm.FindToolStripMenuItem.Enabled = True
                FrmMainForm.DeleteToolStrip.Enabled = True
                FrmMainForm.DeleteToolStripMenuItem.Enabled = True
                FrmMainForm.SearchToolStrip.Enabled = True
                FrmMainForm.BrowseToolStripMenuItem.Enabled = True
                FrmMainForm.RefreshToolStrip.Enabled = True
                FrmMainForm.RefreshToolStripMenuItem.Enabled = True
                FrmMainForm.PrintToolStrip.Enabled = True
                FrmMainForm.PrintToolStripMenuItem.Enabled = True
                FrmMainForm.CloseToolStrip.Enabled = True
                FrmMainForm.CloseToolStripMenuItem.Enabled = True
                'getpriv()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function NewRecord() As Object Implements Procedures.NewRecord
        Return False
    End Function

    Public Sub nextRecord() Implements Procedures.nextRecord
        Exit Sub
    End Sub

    Public Sub PreviousRecord() Implements Procedures.PreviousRecord
        Exit Sub
    End Sub
    Public Sub print() Implements Procedures.print
        Try
            Dim sqlcom As New SqlCommand("select ReportName from SacReports where ReportCode='RtItemControl'", BoCnx)
            If BoCnx.State = ConnectionState.Closed Then
                BoCnx.Open()
            End If
            Dim ReportName As String = IIf(IsDBNull(sqlcom.ExecuteScalar) Or IsNothing(sqlcom.ExecuteScalar), "", sqlcom.ExecuteScalar)
            Try
                Dim FrmReport = New FrmReportViewer
                Dim cryRpt As New ReportDocument
                FrmReport.Text = "Print Item Control"
                Dim crParameterFieldDefinitions As ParameterFieldDefinitions
                Dim crParameterFieldDefinitions1 As ParameterFieldDefinitions
                Dim crParameterFieldDefinitions2 As ParameterFieldDefinitions

                Dim crParameterFieldDefinition As ParameterFieldDefinition
                Dim crParameterFieldDefinition1 As ParameterFieldDefinition
                Dim crParameterFieldDefinition2 As ParameterFieldDefinition

                Dim crParameterValues As New ParameterValues()
                Dim crParameterValues1 As New ParameterValues()
                Dim crParameterValues2 As New ParameterValues()

                Dim crParameterDiscreteValue As New ParameterDiscreteValue()
                Dim crParameterDiscreteValue1 As New ParameterDiscreteValue()
                Dim crParameterDiscreteValue2 As New ParameterDiscreteValue()

                crParameterValues.Clear()
                crParameterValues1.Clear()
                crParameterValues2.Clear()
                cryRpt.Load(FrmMainForm.ReportPath + ReportName)
                Dim crtableLogoninfos As New TableLogOnInfos
                Dim crtableLogoninfo As New TableLogOnInfo
                Dim crConnectionInfo As New ConnectionInfo
                Dim CrTables As Tables
                Dim CrTable As Table

                With crConnectionInfo
                    .ServerName = FrmMainForm.BOServer
                    .DatabaseName = FrmMainForm.BODatabase
                    .UserID = FrmMainForm.BOUser
                    .Password = FrmMainForm.BOPass
                End With

                CrTables = cryRpt.Database.Tables
                For Each CrTable In CrTables
                    crtableLogoninfo = CrTable.LogOnInfo
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo
                    CrTable.ApplyLogOnInfo(crtableLogoninfo)
                Next
                crParameterDiscreteValue.Value = CmbWHS.EditValue
                crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFieldDefinitions("@WhsCode")
                crParameterValues = crParameterFieldDefinition.CurrentValues


                crParameterDiscreteValue1.Value = RgCleared.EditValue
                crParameterFieldDefinitions1 = cryRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition1 = crParameterFieldDefinitions1("@Status")
                crParameterValues1 = crParameterFieldDefinition1.CurrentValues

                crParameterDiscreteValue2.Value = CmbItems.EditValue
                crParameterFieldDefinitions2 = cryRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition2 = crParameterFieldDefinitions2("@ItemAID")
                crParameterValues2 = crParameterFieldDefinition2.CurrentValues

                crParameterValues.Add(crParameterDiscreteValue)
                crParameterValues1.Add(crParameterDiscreteValue1)
                crParameterValues2.Add(crParameterDiscreteValue2)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
                crParameterFieldDefinition1.ApplyCurrentValues(crParameterValues1)
                crParameterFieldDefinition2.ApplyCurrentValues(crParameterValues2)
                FrmReport.CrystalReportViewer1.ReportSource = cryRpt
                FrmReport.CrystalReportViewer1.Refresh()
                FrmReport.Show()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub Refresh1() Implements Procedures.Refresh
        Exit Sub
    End Sub

    Public Function Save() As Object Implements Procedures.Save
        Return False
    End Function

    Public Sub Search() Implements Procedures.Search
        Exit Sub
    End Sub
End Class