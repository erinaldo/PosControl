Public Class FrmWorkStationDefaults

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub FrmParameters_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Workstation Defaults <" & My.Application.Info.Version.ToString & ">"
        txtTabletPos.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "TabletPOS", "TabletPOS").ToString
        txtPostDatedCode.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "PostDatedCode", "PostDatedCode").ToString
        txtSalesManID.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "SalesManID", "SalesManID").ToString
        txtDCustomer.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "DefaultCustomer", "DefaultCustomer").ToString
        txtAccCode.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "AccCode", "AccCode").ToString()
        txtCurCode.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "CurCode", "CurCode").ToString()
        txtPriceList.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "PriceList", "PriceList").ToString()
        txtDeliveryOrder.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "DeliveryOrder", "DeliveryOrder").ToString()
        txtBOServer.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "BOServer", "BOServer").ToString()
        txtBODatabase.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "BODatabase", "BODatabase").ToString()
        txtBOUser.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "BOUser", "BOUser").ToString()
        txtBOPass.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "BOPass", "BOPass").ToString()
        txtSync.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "Sync", "Sync").ToString()
        txtReturn.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "SalesReturn", "SalesReturn").ToString
        txtSales.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "SalesInvoice", "SalesInvoice").ToString
        txtOrder.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "SalesOrder", "SalesOrder").ToString
        txtWHSAdjustment.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "WHSAdjustment", "WHSAdjustment").ToString
        txtOpening.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "Opening", "Opening").ToString
        txtPurchaseID.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "PurchaseID", "PurchaseID").ToString

        txtTransferFromDB.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "TransferFromDb", "TransferFromDb").ToString
        txtTransferToDB.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "TransferToDb", "TransferToDb").ToString
        txtTransferFromWHS.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "TransferFromWhs", "TransferFromWhs").ToString
        txtSupplierId.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "SupplierID", "SupplierID").ToString
        txtTransferWhs.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "TransferWhs", "TransferWhs").ToString
        txtTransferToWhs.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "TransferToWhs", "TransferToWhs").ToString


        txtSalesFromDB.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "SalesFromDB", "SalesFromDB").ToString
        txtPurchaseInDb.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "PurchaseInDb", "PurchaseInDb").ToString
        txtSalesInDb.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "SalesIndb", "SalesIndb").ToString
        txtPurchaseWhs.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "PurchaseWhs", "PurchaseWhs").ToString
        txtPurchasePricelist.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "PurchasePricelist", "PurchasePricelist").ToString
        txtSalesWhs.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "SalesWhs", "SalesWhs").ToString
        txtSalesCustomer.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "SalesCustomer", "SalesCustomer").ToString
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        My.Computer.Registry.CurrentUser.CreateSubKey("POSControl\Settings")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\POSControl\Settings", "PostDatedCode", txtPostDatedCode.Text)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\POSControl\Settings", "SalesManID", txtSalesManID.Text)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\POSControl\Settings", "TabletPOS", txtTabletPos.Text)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\POSControl\Settings", "DefaultCustomer", txtDCustomer.Text)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\POSControl\Settings", "Opening", txtOpening.Text)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\POSControl\Settings", "Sync", txtSync.Text)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\POSControl\Settings", "PriceList", txtPriceList.Text)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\POSControl\Settings", "AccCode", txtAccCode.Text)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\POSControl\Settings", "CurCode", txtCurCode.Text)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\POSControl\Settings", "DeliveryOrder", txtDeliveryOrder.Text)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\POSControl\Settings", "BOServer", txtBOServer.Text)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\POSControl\Settings", "BODatabase", txtBODatabase.Text)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\POSControl\Settings", "BOUser", txtBOUser.Text)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\POSControl\Settings", "BOPass", txtBOPass.Text)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\POSControl\Settings", "SalesReturn", txtReturn.Text)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\POSControl\Settings", "SalesInvoice", txtSales.Text)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\POSControl\Settings", "SalesOrder", txtOrder.Text)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\POSControl\Settings", "WHSAdjustment", txtWHSAdjustment.Text)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\POSControl\Settings", "PurchaseID", txtPurchaseID.Text)

        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\POSControl\Settings", "TransferFromDb", txtTransferFromDB.Text)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\POSControl\Settings", "TransferToDb", txtTransferToDB.Text)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\POSControl\Settings", "TransferFromWhs", txtTransferFromWHS.Text)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\POSControl\Settings", "SupplierID", txtSupplierId.Text)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\POSControl\Settings", "TransferWhs", txtTransferWhs.Text)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\POSControl\Settings", "TransferToWhs", txtTransferToWhs.Text)


        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\POSControl\Settings", "SalesFromDB", txtSalesFromDB.Text)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\POSControl\Settings", "PurchaseInDb", txtPurchaseInDb.Text)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\POSControl\Settings", "SalesIndb", txtSalesInDb.Text)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\POSControl\Settings", "PurchaseWhs", txtPurchaseWhs.Text)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\POSControl\Settings", "PurchasePricelist", txtPurchasePricelist.Text)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\POSControl\Settings", "SalesWhs", txtSalesWhs.Text)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\POSControl\Settings", "SalesCustomer", txtSalesCustomer.Text)

        FrmMainForm.PostDatedCode = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "PostDatedCode", "PostDatedCode").ToString
        FrmMainForm.PurchaseID = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "PurchaseID", "PurchaseID").ToString
        FrmMainForm.TabletPos = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "TabletPos", "TabletPos").ToString
        FrmMainForm.SalesReturn = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "SalesReturn", "SalesReturn").ToString
        FrmMainForm.SalesInvoice = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "SalesInvoice", "SalesInvoice").ToString
        FrmMainForm.SalesOrder = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "SalesOrder", "SalesOrder").ToString
        FrmMainForm.WhsAdjustment = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "WhsAdjustment", "WhsAdjustment").ToString
        FrmMainForm.AccCode = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "AccCode", "AccCode").ToString
        FrmMainForm.DefaultCustomer = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "DefaultCustomer", "DefaultCustomer").ToString
        FrmMainForm.salesmanid = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "SalesManID", 0).ToString
        FrmMainForm.CurCode = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "CurCode", 0).ToString
        FrmMainForm.PriceList = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "PriceList", "PriceList").ToString
        FrmMainForm.DeliveryOrder = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "DeliveryOrder", "DeliveryOrder").ToString
        FrmMainForm.BOServer = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "BOServer", "BOServer").ToString
        FrmMainForm.BODatabase = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "BODatabase", "BODatabase").ToString
        FrmMainForm.BOUser = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "BOUser", "BOUser").ToString
        FrmMainForm.BOPass = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "BOPass", "BOPass").ToString
        FrmMainForm.Sync = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "Sync", "Sync").ToString
        FrmMainForm.Opening = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "Opening", "Opening").ToString

        FrmMainForm.TransferFromDb = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "TransferFromDb", "TransferFromDb").ToString
        FrmMainForm.TransferToDb = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "TransferToDb", "TransferToDb").ToString
        FrmMainForm.TransferFromWhs = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "TransferFromWhs", "TransferFromWhs").ToString
        FrmMainForm.SupplierID = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "SupplierID", "SupplierID").ToString
        FrmMainForm.TransferWhs = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "TransferWhs", "TransferWhs").ToString
        FrmMainForm.TransferToWhs = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "TransferToWhs", "TransferToWhs").ToString

        FrmMainForm.SalesFromDB = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "SalesFromDB", "SalesFromDB").ToString
        FrmMainForm.PurchaseInDb = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "PurchaseInDb", "PurchaseInDb").ToString
        FrmMainForm.SalesIndb = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "SalesIndb", "SalesIndb").ToString
        FrmMainForm.PurchaseWhs = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "PurchaseWhs", "PurchaseWhs").ToString
        FrmMainForm.PurchasePricelist = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "PurchasePricelist", "PurchasePricelist").ToString
        FrmMainForm.SalesWhs = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "SalesWhs", "SalesWhs").ToString
        FrmMainForm.SalesCustomer = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\POSControl\Settings", "SalesCustomer", "SalesCustomer").ToString

        If FrmMainForm.Sync = 0 Then
            FrmMainForm.Timer1.Interval = 10000 * 60000
        Else
            FrmMainForm.Timer1.Interval = FrmMainForm.Sync * 60000
        End If
    End Sub
End Class