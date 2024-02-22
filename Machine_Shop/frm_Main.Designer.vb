<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Main))
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.File_Menu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BackUpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Employees_Menu = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmployeeInformationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmployeeDirectoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmployeeReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Customers_Menu = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomerInformationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomerDirectoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomerReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WorkSchedule_Menu = New System.Windows.Forms.ToolStripMenuItem()
        Me.Income_Menu = New System.Windows.Forms.ToolStripMenuItem()
        Me.POToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InvoiceOrdersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InvoiceSearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InvoiceReInvoiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InvoicePaidToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InvoicePaymentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DrawingHistoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Banking_Menu = New System.Windows.Forms.ToolStripMenuItem()
        Me.Payroll_Menu = New System.Windows.Forms.ToolStripMenuItem()
        Me.Inventory_Menu = New System.Windows.Forms.ToolStripMenuItem()
        Me.List_Menu = New System.Windows.Forms.ToolStripMenuItem()
        Me.PayeeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Site_Menu = New System.Windows.Forms.ToolStripMenuItem()
        Me.SystemSetupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogOn_Menu = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogonOptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AutoLogon = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.cmd_FixDrawingRev = New System.Windows.Forms.Button()
        Me.MenuStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.File_Menu, Me.Employees_Menu, Me.Customers_Menu, Me.WorkSchedule_Menu, Me.Income_Menu, Me.Banking_Menu, Me.Payroll_Menu, Me.Inventory_Menu, Me.List_Menu, Me.Site_Menu, Me.LogOn_Menu})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Padding = New System.Windows.Forms.Padding(9, 2, 0, 2)
        Me.MenuStrip.Size = New System.Drawing.Size(1218, 25)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'File_Menu
        '
        Me.File_Menu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator3, Me.BackUpToolStripMenuItem, Me.ToolStripSeparator4, Me.ExitToolStripMenuItem})
        Me.File_Menu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder
        Me.File_Menu.Name = "File_Menu"
        Me.File_Menu.Size = New System.Drawing.Size(39, 21)
        Me.File_Menu.Text = "&File"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(110, 6)
        '
        'BackUpToolStripMenuItem
        '
        Me.BackUpToolStripMenuItem.Image = CType(resources.GetObject("BackUpToolStripMenuItem.Image"), System.Drawing.Image)
        Me.BackUpToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.BackUpToolStripMenuItem.Name = "BackUpToolStripMenuItem"
        Me.BackUpToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.BackUpToolStripMenuItem.ShowShortcutKeys = False
        Me.BackUpToolStripMenuItem.Size = New System.Drawing.Size(113, 26)
        Me.BackUpToolStripMenuItem.Text = "&Backup"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(110, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(113, 26)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'Employees_Menu
        '
        Me.Employees_Menu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EmployeeInformationToolStripMenuItem, Me.EmployeeDirectoryToolStripMenuItem, Me.EmployeeReportToolStripMenuItem})
        Me.Employees_Menu.Name = "Employees_Menu"
        Me.Employees_Menu.Size = New System.Drawing.Size(83, 21)
        Me.Employees_Menu.Text = "Employees"
        '
        'EmployeeInformationToolStripMenuItem
        '
        Me.EmployeeInformationToolStripMenuItem.Name = "EmployeeInformationToolStripMenuItem"
        Me.EmployeeInformationToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.EmployeeInformationToolStripMenuItem.Text = "Employee's Information"
        '
        'EmployeeDirectoryToolStripMenuItem
        '
        Me.EmployeeDirectoryToolStripMenuItem.Name = "EmployeeDirectoryToolStripMenuItem"
        Me.EmployeeDirectoryToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.EmployeeDirectoryToolStripMenuItem.Text = "Employee's Directory"
        '
        'EmployeeReportToolStripMenuItem
        '
        Me.EmployeeReportToolStripMenuItem.Name = "EmployeeReportToolStripMenuItem"
        Me.EmployeeReportToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.EmployeeReportToolStripMenuItem.Text = "Employee's Report"
        '
        'Customers_Menu
        '
        Me.Customers_Menu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CustomerInformationToolStripMenuItem, Me.CustomerDirectoryToolStripMenuItem, Me.CustomerReportToolStripMenuItem})
        Me.Customers_Menu.Name = "Customers_Menu"
        Me.Customers_Menu.Size = New System.Drawing.Size(82, 21)
        Me.Customers_Menu.Text = "Customers"
        '
        'CustomerInformationToolStripMenuItem
        '
        Me.CustomerInformationToolStripMenuItem.Name = "CustomerInformationToolStripMenuItem"
        Me.CustomerInformationToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.CustomerInformationToolStripMenuItem.Text = "Customer's Information"
        '
        'CustomerDirectoryToolStripMenuItem
        '
        Me.CustomerDirectoryToolStripMenuItem.Name = "CustomerDirectoryToolStripMenuItem"
        Me.CustomerDirectoryToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.CustomerDirectoryToolStripMenuItem.Text = "Customer's Directory"
        '
        'CustomerReportToolStripMenuItem
        '
        Me.CustomerReportToolStripMenuItem.Name = "CustomerReportToolStripMenuItem"
        Me.CustomerReportToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.CustomerReportToolStripMenuItem.Text = "Customer's Report"
        '
        'WorkSchedule_Menu
        '
        Me.WorkSchedule_Menu.Name = "WorkSchedule_Menu"
        Me.WorkSchedule_Menu.Size = New System.Drawing.Size(106, 21)
        Me.WorkSchedule_Menu.Text = "Work Schedule"
        '
        'Income_Menu
        '
        Me.Income_Menu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.POToolStripMenuItem, Me.InvoiceOrdersToolStripMenuItem, Me.InvoiceSearchToolStripMenuItem, Me.InvoiceReInvoiceToolStripMenuItem, Me.InvoicePaidToolStripMenuItem, Me.InvoicePaymentToolStripMenuItem, Me.DrawingHistoryToolStripMenuItem})
        Me.Income_Menu.Name = "Income_Menu"
        Me.Income_Menu.Size = New System.Drawing.Size(62, 21)
        Me.Income_Menu.Text = "Income"
        '
        'POToolStripMenuItem
        '
        Me.POToolStripMenuItem.Name = "POToolStripMenuItem"
        Me.POToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.POToolStripMenuItem.Text = "Purchase Orders"
        '
        'InvoiceOrdersToolStripMenuItem
        '
        Me.InvoiceOrdersToolStripMenuItem.Name = "InvoiceOrdersToolStripMenuItem"
        Me.InvoiceOrdersToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.InvoiceOrdersToolStripMenuItem.Text = "Invoice Orders"
        '
        'InvoiceSearchToolStripMenuItem
        '
        Me.InvoiceSearchToolStripMenuItem.Name = "InvoiceSearchToolStripMenuItem"
        Me.InvoiceSearchToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.InvoiceSearchToolStripMenuItem.Text = "Invoice Search"
        '
        'InvoiceReInvoiceToolStripMenuItem
        '
        Me.InvoiceReInvoiceToolStripMenuItem.Name = "InvoiceReInvoiceToolStripMenuItem"
        Me.InvoiceReInvoiceToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.InvoiceReInvoiceToolStripMenuItem.Text = "Invoice Re-Invoice"
        '
        'InvoicePaidToolStripMenuItem
        '
        Me.InvoicePaidToolStripMenuItem.Name = "InvoicePaidToolStripMenuItem"
        Me.InvoicePaidToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.InvoicePaidToolStripMenuItem.Text = "Invoice Mark Paid"
        '
        'InvoicePaymentToolStripMenuItem
        '
        Me.InvoicePaymentToolStripMenuItem.Name = "InvoicePaymentToolStripMenuItem"
        Me.InvoicePaymentToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.InvoicePaymentToolStripMenuItem.Text = "Invoice Payment Schedule"
        '
        'DrawingHistoryToolStripMenuItem
        '
        Me.DrawingHistoryToolStripMenuItem.Name = "DrawingHistoryToolStripMenuItem"
        Me.DrawingHistoryToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.DrawingHistoryToolStripMenuItem.Text = "Drawing Number History"
        '
        'Banking_Menu
        '
        Me.Banking_Menu.Name = "Banking_Menu"
        Me.Banking_Menu.Size = New System.Drawing.Size(65, 21)
        Me.Banking_Menu.Text = "Banking"
        '
        'Payroll_Menu
        '
        Me.Payroll_Menu.Name = "Payroll_Menu"
        Me.Payroll_Menu.Size = New System.Drawing.Size(59, 21)
        Me.Payroll_Menu.Text = "Payroll"
        '
        'Inventory_Menu
        '
        Me.Inventory_Menu.Name = "Inventory_Menu"
        Me.Inventory_Menu.Size = New System.Drawing.Size(73, 21)
        Me.Inventory_Menu.Text = "Inventory"
        '
        'List_Menu
        '
        Me.List_Menu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PayeeToolStripMenuItem})
        Me.List_Menu.Name = "List_Menu"
        Me.List_Menu.Size = New System.Drawing.Size(39, 21)
        Me.List_Menu.Text = "List"
        '
        'PayeeToolStripMenuItem
        '
        Me.PayeeToolStripMenuItem.Name = "PayeeToolStripMenuItem"
        Me.PayeeToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.PayeeToolStripMenuItem.Text = "Checkbook Payees"
        '
        'Site_Menu
        '
        Me.Site_Menu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SystemSetupToolStripMenuItem})
        Me.Site_Menu.Name = "Site_Menu"
        Me.Site_Menu.Size = New System.Drawing.Size(41, 21)
        Me.Site_Menu.Text = "Site"
        '
        'SystemSetupToolStripMenuItem
        '
        Me.SystemSetupToolStripMenuItem.Name = "SystemSetupToolStripMenuItem"
        Me.SystemSetupToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.SystemSetupToolStripMenuItem.Text = "System Setup"
        '
        'LogOn_Menu
        '
        Me.LogOn_Menu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LogonOptionsToolStripMenuItem, Me.AutoLogon})
        Me.LogOn_Menu.Name = "LogOn_Menu"
        Me.LogOn_Menu.Size = New System.Drawing.Size(57, 21)
        Me.LogOn_Menu.Text = "Logon"
        '
        'LogonOptionsToolStripMenuItem
        '
        Me.LogonOptionsToolStripMenuItem.Name = "LogonOptionsToolStripMenuItem"
        Me.LogonOptionsToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.LogonOptionsToolStripMenuItem.Text = "Logon Options"
        '
        'AutoLogon
        '
        Me.AutoLogon.Name = "AutoLogon"
        Me.AutoLogon.Size = New System.Drawing.Size(163, 22)
        Me.AutoLogon.Text = "Auto Logon"
        '
        'StatusStrip
        '
        Me.StatusStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 676)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Padding = New System.Windows.Forms.Padding(1, 0, 20, 0)
        Me.StatusStrip.Size = New System.Drawing.Size(1218, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(39, 17)
        Me.ToolStripStatusLabel.Text = "Status"
        '
        'cmd_FixDrawingRev
        '
        Me.cmd_FixDrawingRev.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_FixDrawingRev.Location = New System.Drawing.Point(467, 333)
        Me.cmd_FixDrawingRev.Name = "cmd_FixDrawingRev"
        Me.cmd_FixDrawingRev.Size = New System.Drawing.Size(285, 33)
        Me.cmd_FixDrawingRev.TabIndex = 136
        Me.cmd_FixDrawingRev.Text = "Fix Revisions"
        Me.cmd_FixDrawingRev.UseVisualStyleBackColor = True
        Me.cmd_FixDrawingRev.Visible = False
        '
        'frm_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1218, 698)
        Me.Controls.Add(Me.cmd_FixDrawingRev)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frm_Main"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents File_Menu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BackUpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents Employees_Menu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents List_Menu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Site_Menu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogOn_Menu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SystemSetupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogonOptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AutoLogon As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Customers_Menu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Income_Menu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents POToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InvoiceOrdersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InvoiceSearchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InvoiceReInvoiceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InvoicePaidToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InvoicePaymentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WorkSchedule_Menu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DrawingHistoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EmployeeInformationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EmployeeDirectoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EmployeeReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CustomerInformationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CustomerDirectoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CustomerReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Inventory_Menu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Banking_Menu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Payroll_Menu As ToolStripMenuItem
    Friend WithEvents PayeeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmd_FixDrawingRev As System.Windows.Forms.Button
End Class
