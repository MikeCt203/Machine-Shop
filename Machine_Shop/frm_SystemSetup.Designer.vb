<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_SystemSetup
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
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.General = New System.Windows.Forms.TabPage()
        Me.fra_General = New System.Windows.Forms.GroupBox()
        Me.lbl_ClearSystem = New System.Windows.Forms.Label()
        Me.tbox_ClearSystem = New System.Windows.Forms.TextBox()
        Me.fra_CompanyInfo = New System.Windows.Forms.GroupBox()
        Me.tbox_CompanyZipCode = New System.Windows.Forms.MaskedTextBox()
        Me.tbox_CompanyPhone = New System.Windows.Forms.MaskedTextBox()
        Me.tbox_CompanyWebsite = New System.Windows.Forms.TextBox()
        Me.tbox_CompanyEmail = New System.Windows.Forms.TextBox()
        Me.tbox_CompanyState = New System.Windows.Forms.TextBox()
        Me.tbox_CompanyCity = New System.Windows.Forms.TextBox()
        Me.tbox_CompanyAddress = New System.Windows.Forms.TextBox()
        Me.tbox_CompanyRep = New System.Windows.Forms.TextBox()
        Me.lbl_CompanyWebsite = New System.Windows.Forms.Label()
        Me.lbl_CompanyEmail = New System.Windows.Forms.Label()
        Me.lbl_CompanyPhone = New System.Windows.Forms.Label()
        Me.lbl_CompanyZipCode = New System.Windows.Forms.Label()
        Me.lbl_CompanyState = New System.Windows.Forms.Label()
        Me.lbl_CompanyCity = New System.Windows.Forms.Label()
        Me.lbl_CompanyAddress = New System.Windows.Forms.Label()
        Me.lbl_CompanyRep = New System.Windows.Forms.Label()
        Me.tbox_CompanyName = New System.Windows.Forms.TextBox()
        Me.lbl_CompanyName = New System.Windows.Forms.Label()
        Me.cmd_ClearSystem = New System.Windows.Forms.Button()
        Me.opt_SetupLogonYes = New System.Windows.Forms.RadioButton()
        Me.opt_SetupLogonNo = New System.Windows.Forms.RadioButton()
        Me.lbl_SecureLogon = New System.Windows.Forms.Label()
        Me.lbl_MsgGeneral = New System.Windows.Forms.Label()
        Me.Invoice = New System.Windows.Forms.TabPage()
        Me.lbl_MsgInvoice = New System.Windows.Forms.Label()
        Me.fra_CertificateCompliance = New System.Windows.Forms.GroupBox()
        Me.tbox_SecondaryAgent = New System.Windows.Forms.TextBox()
        Me.lbl_SecondaryAgent = New System.Windows.Forms.Label()
        Me.tbox_PrimaryAgent = New System.Windows.Forms.TextBox()
        Me.lbl_PrimaryAgent = New System.Windows.Forms.Label()
        Me.fra_InvoicePacking = New System.Windows.Forms.GroupBox()
        Me.cbx_ReInvoice = New System.Windows.Forms.CheckBox()
        Me.lbl_Percent = New System.Windows.Forms.Label()
        Me.tbox_DiscountPercent = New System.Windows.Forms.TextBox()
        Me.tbox_DiscountDays = New System.Windows.Forms.TextBox()
        Me.tbox_LastInvoice = New System.Windows.Forms.TextBox()
        Me.tbox_DueDays = New System.Windows.Forms.TextBox()
        Me.tbox_Terms = New System.Windows.Forms.TextBox()
        Me.tbox_ShipVia = New System.Windows.Forms.TextBox()
        Me.lbl_LastInvoice = New System.Windows.Forms.Label()
        Me.lbl_DueDays = New System.Windows.Forms.Label()
        Me.lbl_DiscountPercent = New System.Windows.Forms.Label()
        Me.lbl_DiscountDays = New System.Windows.Forms.Label()
        Me.lbl_Terms = New System.Windows.Forms.Label()
        Me.lbl_ShipVia = New System.Windows.Forms.Label()
        Me.Checkbook = New System.Windows.Forms.TabPage()
        Me.lbl_MsgCheckbook = New System.Windows.Forms.Label()
        Me.fra_Checkbook = New System.Windows.Forms.GroupBox()
        Me.fra_CheckbookInfo = New System.Windows.Forms.GroupBox()
        Me.lbl_Progress = New System.Windows.Forms.Label()
        Me.lbl_CheckbookBalance = New System.Windows.Forms.Label()
        Me.label_CheckbookBalance = New System.Windows.Forms.Label()
        Me.cmd_ReCalculate = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.tbox_StartBalance = New System.Windows.Forms.TextBox()
        Me.tbox_ReconcileDate = New System.Windows.Forms.MaskedTextBox()
        Me.tbox_ReconcileBalance = New System.Windows.Forms.TextBox()
        Me.tbox_LastCheck = New System.Windows.Forms.TextBox()
        Me.lbl_ReconcileBalance = New System.Windows.Forms.Label()
        Me.lbl_ReconcileDate = New System.Windows.Forms.Label()
        Me.lbl_LastCheck = New System.Windows.Forms.Label()
        Me.TaxCategory = New System.Windows.Forms.TabPage()
        Me.fra_TaxCategorys = New System.Windows.Forms.GroupBox()
        Me.lbl_MsgTaxCategory = New System.Windows.Forms.Label()
        Me.cmd_CategoryDefaults = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Vacations = New System.Windows.Forms.TabPage()
        Me.lbl_MsgPayRoll = New System.Windows.Forms.Label()
        Me.fra_Payroll = New System.Windows.Forms.GroupBox()
        Me.tbox_MedicarePercent = New System.Windows.Forms.TextBox()
        Me.lbl_MedicarePercent = New System.Windows.Forms.Label()
        Me.tbox_SocSecPercent = New System.Windows.Forms.TextBox()
        Me.tbox_SocSecBaseLimit = New System.Windows.Forms.TextBox()
        Me.lbl_SocSecPercent = New System.Windows.Forms.Label()
        Me.lbl_SocSecBaseLimit = New System.Windows.Forms.Label()
        Me.fra_Vacation = New System.Windows.Forms.GroupBox()
        Me.opt_TrackYears3 = New System.Windows.Forms.RadioButton()
        Me.opt_TrackYears1 = New System.Windows.Forms.RadioButton()
        Me.opt_TrackYears2 = New System.Windows.Forms.RadioButton()
        Me.tbox_VacaStop = New System.Windows.Forms.TextBox()
        Me.lbl_VacaStop = New System.Windows.Forms.Label()
        Me.tbox_VacaAddDays = New System.Windows.Forms.TextBox()
        Me.lbl_VacaAddDays = New System.Windows.Forms.Label()
        Me.tbox_VacaStart = New System.Windows.Forms.TextBox()
        Me.tbox_VacaWaitPeriod = New System.Windows.Forms.TextBox()
        Me.lbl_VacaYears = New System.Windows.Forms.Label()
        Me.lbl_VacaStart = New System.Windows.Forms.Label()
        Me.lbl_VacaWaitPeriod = New System.Windows.Forms.Label()
        Me.Images = New System.Windows.Forms.TabPage()
        Me.Misc = New System.Windows.Forms.TabPage()
        Me.lbl_MsgMisc = New System.Windows.Forms.Label()
        Me.fra_Misc = New System.Windows.Forms.GroupBox()
        Me.cmd_Selector = New System.Windows.Forms.Button()
        Me.tbox_PdfPath = New System.Windows.Forms.TextBox()
        Me.lbl_PdfPath = New System.Windows.Forms.Label()
        Me.tbox_PdfPrinterName = New System.Windows.Forms.TextBox()
        Me.lbl_PdfPrinter = New System.Windows.Forms.Label()
        Me.tbox_PrinterName = New System.Windows.Forms.TextBox()
        Me.lbl_PrinterName = New System.Windows.Forms.Label()
        Me.cmd_MiscDefaults = New System.Windows.Forms.Button()
        Me.tbox_ImageHeight = New System.Windows.Forms.TextBox()
        Me.lbl_ImageHeight = New System.Windows.Forms.Label()
        Me.tbox_ImageWidth = New System.Windows.Forms.TextBox()
        Me.lbl_ImageWidth = New System.Windows.Forms.Label()
        Me.tbox_PrinterBuffer = New System.Windows.Forms.TextBox()
        Me.tbox_BackupPath = New System.Windows.Forms.TextBox()
        Me.lbl_PrinterBuffer = New System.Windows.Forms.Label()
        Me.lbl_BackupPath = New System.Windows.Forms.Label()
        Me.cmd_EditCancel = New System.Windows.Forms.Button()
        Me.cmd_Restore = New System.Windows.Forms.Button()
        Me.cmd_ExitSave = New System.Windows.Forms.Button()
        Me.TabControl.SuspendLayout()
        Me.General.SuspendLayout()
        Me.fra_General.SuspendLayout()
        Me.fra_CompanyInfo.SuspendLayout()
        Me.Invoice.SuspendLayout()
        Me.fra_CertificateCompliance.SuspendLayout()
        Me.fra_InvoicePacking.SuspendLayout()
        Me.Checkbook.SuspendLayout()
        Me.fra_Checkbook.SuspendLayout()
        Me.fra_CheckbookInfo.SuspendLayout()
        Me.TaxCategory.SuspendLayout()
        Me.fra_TaxCategorys.SuspendLayout()
        Me.Vacations.SuspendLayout()
        Me.fra_Payroll.SuspendLayout()
        Me.fra_Vacation.SuspendLayout()
        Me.Misc.SuspendLayout()
        Me.fra_Misc.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.General)
        Me.TabControl.Controls.Add(Me.Invoice)
        Me.TabControl.Controls.Add(Me.Checkbook)
        Me.TabControl.Controls.Add(Me.TaxCategory)
        Me.TabControl.Controls.Add(Me.Vacations)
        Me.TabControl.Controls.Add(Me.Images)
        Me.TabControl.Controls.Add(Me.Misc)
        Me.TabControl.Location = New System.Drawing.Point(18, 12)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(572, 379)
        Me.TabControl.TabIndex = 74
        '
        'General
        '
        Me.General.BackColor = System.Drawing.Color.FloralWhite
        Me.General.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.General.Controls.Add(Me.fra_General)
        Me.General.Controls.Add(Me.lbl_MsgGeneral)
        Me.General.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.General.ForeColor = System.Drawing.Color.Maroon
        Me.General.Location = New System.Drawing.Point(4, 22)
        Me.General.Name = "General"
        Me.General.Padding = New System.Windows.Forms.Padding(3)
        Me.General.Size = New System.Drawing.Size(564, 353)
        Me.General.TabIndex = 0
        Me.General.Text = "General"
        '
        'fra_General
        '
        Me.fra_General.Controls.Add(Me.lbl_ClearSystem)
        Me.fra_General.Controls.Add(Me.tbox_ClearSystem)
        Me.fra_General.Controls.Add(Me.fra_CompanyInfo)
        Me.fra_General.Controls.Add(Me.cmd_ClearSystem)
        Me.fra_General.Controls.Add(Me.opt_SetupLogonYes)
        Me.fra_General.Controls.Add(Me.opt_SetupLogonNo)
        Me.fra_General.Controls.Add(Me.lbl_SecureLogon)
        Me.fra_General.Location = New System.Drawing.Point(10, 4)
        Me.fra_General.Name = "fra_General"
        Me.fra_General.Size = New System.Drawing.Size(543, 312)
        Me.fra_General.TabIndex = 127
        Me.fra_General.TabStop = False
        '
        'lbl_ClearSystem
        '
        Me.lbl_ClearSystem.AutoSize = True
        Me.lbl_ClearSystem.Location = New System.Drawing.Point(444, 83)
        Me.lbl_ClearSystem.Name = "lbl_ClearSystem"
        Me.lbl_ClearSystem.Size = New System.Drawing.Size(60, 13)
        Me.lbl_ClearSystem.TabIndex = 108
        Me.lbl_ClearSystem.Text = "Enter Code"
        Me.lbl_ClearSystem.Visible = False
        '
        'tbox_ClearSystem
        '
        Me.tbox_ClearSystem.Location = New System.Drawing.Point(424, 100)
        Me.tbox_ClearSystem.Name = "tbox_ClearSystem"
        Me.tbox_ClearSystem.Size = New System.Drawing.Size(100, 20)
        Me.tbox_ClearSystem.TabIndex = 107
        Me.tbox_ClearSystem.Visible = False
        '
        'fra_CompanyInfo
        '
        Me.fra_CompanyInfo.Controls.Add(Me.tbox_CompanyZipCode)
        Me.fra_CompanyInfo.Controls.Add(Me.tbox_CompanyPhone)
        Me.fra_CompanyInfo.Controls.Add(Me.tbox_CompanyWebsite)
        Me.fra_CompanyInfo.Controls.Add(Me.tbox_CompanyEmail)
        Me.fra_CompanyInfo.Controls.Add(Me.tbox_CompanyState)
        Me.fra_CompanyInfo.Controls.Add(Me.tbox_CompanyCity)
        Me.fra_CompanyInfo.Controls.Add(Me.tbox_CompanyAddress)
        Me.fra_CompanyInfo.Controls.Add(Me.tbox_CompanyRep)
        Me.fra_CompanyInfo.Controls.Add(Me.lbl_CompanyWebsite)
        Me.fra_CompanyInfo.Controls.Add(Me.lbl_CompanyEmail)
        Me.fra_CompanyInfo.Controls.Add(Me.lbl_CompanyPhone)
        Me.fra_CompanyInfo.Controls.Add(Me.lbl_CompanyZipCode)
        Me.fra_CompanyInfo.Controls.Add(Me.lbl_CompanyState)
        Me.fra_CompanyInfo.Controls.Add(Me.lbl_CompanyCity)
        Me.fra_CompanyInfo.Controls.Add(Me.lbl_CompanyAddress)
        Me.fra_CompanyInfo.Controls.Add(Me.lbl_CompanyRep)
        Me.fra_CompanyInfo.Controls.Add(Me.tbox_CompanyName)
        Me.fra_CompanyInfo.Controls.Add(Me.lbl_CompanyName)
        Me.fra_CompanyInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fra_CompanyInfo.ForeColor = System.Drawing.Color.DarkGreen
        Me.fra_CompanyInfo.Location = New System.Drawing.Point(11, 10)
        Me.fra_CompanyInfo.Name = "fra_CompanyInfo"
        Me.fra_CompanyInfo.Size = New System.Drawing.Size(394, 266)
        Me.fra_CompanyInfo.TabIndex = 106
        Me.fra_CompanyInfo.TabStop = False
        Me.fra_CompanyInfo.Text = "Company Information"
        '
        'tbox_CompanyZipCode
        '
        Me.tbox_CompanyZipCode.AllowPromptAsInput = False
        Me.tbox_CompanyZipCode.BackColor = System.Drawing.Color.White
        Me.tbox_CompanyZipCode.Enabled = False
        Me.tbox_CompanyZipCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_CompanyZipCode.Location = New System.Drawing.Point(102, 141)
        Me.tbox_CompanyZipCode.Mask = "00000-9999"
        Me.tbox_CompanyZipCode.Name = "tbox_CompanyZipCode"
        Me.tbox_CompanyZipCode.Size = New System.Drawing.Size(73, 21)
        Me.tbox_CompanyZipCode.TabIndex = 93
        Me.tbox_CompanyZipCode.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'tbox_CompanyPhone
        '
        Me.tbox_CompanyPhone.AllowPromptAsInput = False
        Me.tbox_CompanyPhone.BackColor = System.Drawing.Color.White
        Me.tbox_CompanyPhone.Enabled = False
        Me.tbox_CompanyPhone.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_CompanyPhone.Location = New System.Drawing.Point(102, 169)
        Me.tbox_CompanyPhone.Mask = "(999) 000-0000"
        Me.tbox_CompanyPhone.Name = "tbox_CompanyPhone"
        Me.tbox_CompanyPhone.Size = New System.Drawing.Size(92, 21)
        Me.tbox_CompanyPhone.TabIndex = 94
        Me.tbox_CompanyPhone.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'tbox_CompanyWebsite
        '
        Me.tbox_CompanyWebsite.AcceptsReturn = True
        Me.tbox_CompanyWebsite.BackColor = System.Drawing.Color.White
        Me.tbox_CompanyWebsite.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_CompanyWebsite.Enabled = False
        Me.tbox_CompanyWebsite.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_CompanyWebsite.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbox_CompanyWebsite.Location = New System.Drawing.Point(102, 225)
        Me.tbox_CompanyWebsite.MaxLength = 0
        Me.tbox_CompanyWebsite.Name = "tbox_CompanyWebsite"
        Me.tbox_CompanyWebsite.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbox_CompanyWebsite.Size = New System.Drawing.Size(198, 21)
        Me.tbox_CompanyWebsite.TabIndex = 92
        Me.tbox_CompanyWebsite.TabStop = False
        '
        'tbox_CompanyEmail
        '
        Me.tbox_CompanyEmail.AcceptsReturn = True
        Me.tbox_CompanyEmail.BackColor = System.Drawing.Color.White
        Me.tbox_CompanyEmail.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_CompanyEmail.Enabled = False
        Me.tbox_CompanyEmail.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_CompanyEmail.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbox_CompanyEmail.Location = New System.Drawing.Point(102, 197)
        Me.tbox_CompanyEmail.MaxLength = 0
        Me.tbox_CompanyEmail.Name = "tbox_CompanyEmail"
        Me.tbox_CompanyEmail.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbox_CompanyEmail.Size = New System.Drawing.Size(198, 21)
        Me.tbox_CompanyEmail.TabIndex = 91
        Me.tbox_CompanyEmail.TabStop = False
        '
        'tbox_CompanyState
        '
        Me.tbox_CompanyState.AcceptsReturn = True
        Me.tbox_CompanyState.BackColor = System.Drawing.Color.White
        Me.tbox_CompanyState.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_CompanyState.Enabled = False
        Me.tbox_CompanyState.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_CompanyState.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbox_CompanyState.Location = New System.Drawing.Point(280, 113)
        Me.tbox_CompanyState.MaxLength = 0
        Me.tbox_CompanyState.Name = "tbox_CompanyState"
        Me.tbox_CompanyState.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbox_CompanyState.Size = New System.Drawing.Size(20, 21)
        Me.tbox_CompanyState.TabIndex = 90
        Me.tbox_CompanyState.TabStop = False
        Me.tbox_CompanyState.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbox_CompanyCity
        '
        Me.tbox_CompanyCity.AcceptsReturn = True
        Me.tbox_CompanyCity.BackColor = System.Drawing.Color.White
        Me.tbox_CompanyCity.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_CompanyCity.Enabled = False
        Me.tbox_CompanyCity.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_CompanyCity.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbox_CompanyCity.Location = New System.Drawing.Point(102, 113)
        Me.tbox_CompanyCity.MaxLength = 0
        Me.tbox_CompanyCity.Name = "tbox_CompanyCity"
        Me.tbox_CompanyCity.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbox_CompanyCity.Size = New System.Drawing.Size(130, 21)
        Me.tbox_CompanyCity.TabIndex = 89
        Me.tbox_CompanyCity.TabStop = False
        '
        'tbox_CompanyAddress
        '
        Me.tbox_CompanyAddress.AcceptsReturn = True
        Me.tbox_CompanyAddress.BackColor = System.Drawing.Color.White
        Me.tbox_CompanyAddress.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_CompanyAddress.Enabled = False
        Me.tbox_CompanyAddress.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_CompanyAddress.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbox_CompanyAddress.Location = New System.Drawing.Point(102, 85)
        Me.tbox_CompanyAddress.MaxLength = 0
        Me.tbox_CompanyAddress.Name = "tbox_CompanyAddress"
        Me.tbox_CompanyAddress.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbox_CompanyAddress.Size = New System.Drawing.Size(218, 21)
        Me.tbox_CompanyAddress.TabIndex = 88
        Me.tbox_CompanyAddress.TabStop = False
        '
        'tbox_CompanyRep
        '
        Me.tbox_CompanyRep.AcceptsReturn = True
        Me.tbox_CompanyRep.BackColor = System.Drawing.Color.White
        Me.tbox_CompanyRep.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_CompanyRep.Enabled = False
        Me.tbox_CompanyRep.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_CompanyRep.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbox_CompanyRep.Location = New System.Drawing.Point(102, 57)
        Me.tbox_CompanyRep.MaxLength = 0
        Me.tbox_CompanyRep.Name = "tbox_CompanyRep"
        Me.tbox_CompanyRep.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbox_CompanyRep.Size = New System.Drawing.Size(218, 21)
        Me.tbox_CompanyRep.TabIndex = 87
        Me.tbox_CompanyRep.TabStop = False
        '
        'lbl_CompanyWebsite
        '
        Me.lbl_CompanyWebsite.AutoSize = True
        Me.lbl_CompanyWebsite.BackColor = System.Drawing.Color.FloralWhite
        Me.lbl_CompanyWebsite.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_CompanyWebsite.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_CompanyWebsite.ForeColor = System.Drawing.Color.Blue
        Me.lbl_CompanyWebsite.Location = New System.Drawing.Point(31, 230)
        Me.lbl_CompanyWebsite.Name = "lbl_CompanyWebsite"
        Me.lbl_CompanyWebsite.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_CompanyWebsite.Size = New System.Drawing.Size(72, 15)
        Me.lbl_CompanyWebsite.TabIndex = 86
        Me.lbl_CompanyWebsite.Text = "Website url:"
        Me.lbl_CompanyWebsite.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_CompanyEmail
        '
        Me.lbl_CompanyEmail.AutoSize = True
        Me.lbl_CompanyEmail.BackColor = System.Drawing.Color.FloralWhite
        Me.lbl_CompanyEmail.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_CompanyEmail.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_CompanyEmail.ForeColor = System.Drawing.Color.Blue
        Me.lbl_CompanyEmail.Location = New System.Drawing.Point(13, 202)
        Me.lbl_CompanyEmail.Name = "lbl_CompanyEmail"
        Me.lbl_CompanyEmail.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_CompanyEmail.Size = New System.Drawing.Size(90, 15)
        Me.lbl_CompanyEmail.TabIndex = 85
        Me.lbl_CompanyEmail.Text = "Email Address:"
        Me.lbl_CompanyEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_CompanyPhone
        '
        Me.lbl_CompanyPhone.AutoSize = True
        Me.lbl_CompanyPhone.BackColor = System.Drawing.Color.FloralWhite
        Me.lbl_CompanyPhone.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_CompanyPhone.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_CompanyPhone.ForeColor = System.Drawing.Color.Blue
        Me.lbl_CompanyPhone.Location = New System.Drawing.Point(57, 174)
        Me.lbl_CompanyPhone.Name = "lbl_CompanyPhone"
        Me.lbl_CompanyPhone.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_CompanyPhone.Size = New System.Drawing.Size(46, 15)
        Me.lbl_CompanyPhone.TabIndex = 84
        Me.lbl_CompanyPhone.Text = "Phone:"
        Me.lbl_CompanyPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_CompanyZipCode
        '
        Me.lbl_CompanyZipCode.AutoSize = True
        Me.lbl_CompanyZipCode.BackColor = System.Drawing.Color.FloralWhite
        Me.lbl_CompanyZipCode.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_CompanyZipCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_CompanyZipCode.ForeColor = System.Drawing.Color.Blue
        Me.lbl_CompanyZipCode.Location = New System.Drawing.Point(46, 146)
        Me.lbl_CompanyZipCode.Name = "lbl_CompanyZipCode"
        Me.lbl_CompanyZipCode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_CompanyZipCode.Size = New System.Drawing.Size(57, 15)
        Me.lbl_CompanyZipCode.TabIndex = 83
        Me.lbl_CompanyZipCode.Text = "ZipCode:"
        Me.lbl_CompanyZipCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_CompanyState
        '
        Me.lbl_CompanyState.AutoSize = True
        Me.lbl_CompanyState.BackColor = System.Drawing.Color.FloralWhite
        Me.lbl_CompanyState.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_CompanyState.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_CompanyState.ForeColor = System.Drawing.Color.Blue
        Me.lbl_CompanyState.Location = New System.Drawing.Point(243, 118)
        Me.lbl_CompanyState.Name = "lbl_CompanyState"
        Me.lbl_CompanyState.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_CompanyState.Size = New System.Drawing.Size(38, 15)
        Me.lbl_CompanyState.TabIndex = 82
        Me.lbl_CompanyState.Text = "State:"
        Me.lbl_CompanyState.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_CompanyCity
        '
        Me.lbl_CompanyCity.AutoSize = True
        Me.lbl_CompanyCity.BackColor = System.Drawing.Color.FloralWhite
        Me.lbl_CompanyCity.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_CompanyCity.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_CompanyCity.ForeColor = System.Drawing.Color.Blue
        Me.lbl_CompanyCity.Location = New System.Drawing.Point(73, 118)
        Me.lbl_CompanyCity.Name = "lbl_CompanyCity"
        Me.lbl_CompanyCity.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_CompanyCity.Size = New System.Drawing.Size(30, 15)
        Me.lbl_CompanyCity.TabIndex = 81
        Me.lbl_CompanyCity.Text = "City:"
        Me.lbl_CompanyCity.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_CompanyAddress
        '
        Me.lbl_CompanyAddress.AutoSize = True
        Me.lbl_CompanyAddress.BackColor = System.Drawing.Color.FloralWhite
        Me.lbl_CompanyAddress.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_CompanyAddress.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_CompanyAddress.ForeColor = System.Drawing.Color.Blue
        Me.lbl_CompanyAddress.Location = New System.Drawing.Point(13, 90)
        Me.lbl_CompanyAddress.Name = "lbl_CompanyAddress"
        Me.lbl_CompanyAddress.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_CompanyAddress.Size = New System.Drawing.Size(90, 15)
        Me.lbl_CompanyAddress.TabIndex = 80
        Me.lbl_CompanyAddress.Text = "Street Address:"
        Me.lbl_CompanyAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_CompanyRep
        '
        Me.lbl_CompanyRep.AutoSize = True
        Me.lbl_CompanyRep.BackColor = System.Drawing.Color.FloralWhite
        Me.lbl_CompanyRep.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_CompanyRep.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_CompanyRep.ForeColor = System.Drawing.Color.Blue
        Me.lbl_CompanyRep.Location = New System.Drawing.Point(14, 62)
        Me.lbl_CompanyRep.Name = "lbl_CompanyRep"
        Me.lbl_CompanyRep.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_CompanyRep.Size = New System.Drawing.Size(89, 15)
        Me.lbl_CompanyRep.TabIndex = 79
        Me.lbl_CompanyRep.Text = "Company Rep:"
        Me.lbl_CompanyRep.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbox_CompanyName
        '
        Me.tbox_CompanyName.AcceptsReturn = True
        Me.tbox_CompanyName.BackColor = System.Drawing.Color.White
        Me.tbox_CompanyName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_CompanyName.Enabled = False
        Me.tbox_CompanyName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_CompanyName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbox_CompanyName.Location = New System.Drawing.Point(102, 29)
        Me.tbox_CompanyName.MaxLength = 0
        Me.tbox_CompanyName.Name = "tbox_CompanyName"
        Me.tbox_CompanyName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbox_CompanyName.Size = New System.Drawing.Size(234, 21)
        Me.tbox_CompanyName.TabIndex = 78
        Me.tbox_CompanyName.TabStop = False
        '
        'lbl_CompanyName
        '
        Me.lbl_CompanyName.AutoSize = True
        Me.lbl_CompanyName.BackColor = System.Drawing.Color.FloralWhite
        Me.lbl_CompanyName.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_CompanyName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_CompanyName.ForeColor = System.Drawing.Color.Blue
        Me.lbl_CompanyName.Location = New System.Drawing.Point(56, 34)
        Me.lbl_CompanyName.Name = "lbl_CompanyName"
        Me.lbl_CompanyName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_CompanyName.Size = New System.Drawing.Size(47, 15)
        Me.lbl_CompanyName.TabIndex = 77
        Me.lbl_CompanyName.Text = " Name:"
        Me.lbl_CompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmd_ClearSystem
        '
        Me.cmd_ClearSystem.BackColor = System.Drawing.SystemColors.Control
        Me.cmd_ClearSystem.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmd_ClearSystem.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_ClearSystem.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmd_ClearSystem.Location = New System.Drawing.Point(424, 18)
        Me.cmd_ClearSystem.Name = "cmd_ClearSystem"
        Me.cmd_ClearSystem.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmd_ClearSystem.Size = New System.Drawing.Size(100, 50)
        Me.cmd_ClearSystem.TabIndex = 105
        Me.cmd_ClearSystem.Text = "System Clear"
        Me.cmd_ClearSystem.UseVisualStyleBackColor = False
        '
        'opt_SetupLogonYes
        '
        Me.opt_SetupLogonYes.AutoSize = True
        Me.opt_SetupLogonYes.BackColor = System.Drawing.Color.FloralWhite
        Me.opt_SetupLogonYes.Cursor = System.Windows.Forms.Cursors.Default
        Me.opt_SetupLogonYes.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.opt_SetupLogonYes.ForeColor = System.Drawing.Color.Blue
        Me.opt_SetupLogonYes.Location = New System.Drawing.Point(278, 283)
        Me.opt_SetupLogonYes.Name = "opt_SetupLogonYes"
        Me.opt_SetupLogonYes.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.opt_SetupLogonYes.Size = New System.Drawing.Size(45, 19)
        Me.opt_SetupLogonYes.TabIndex = 88
        Me.opt_SetupLogonYes.Text = "Yes"
        Me.opt_SetupLogonYes.UseVisualStyleBackColor = False
        '
        'opt_SetupLogonNo
        '
        Me.opt_SetupLogonNo.AutoSize = True
        Me.opt_SetupLogonNo.BackColor = System.Drawing.Color.FloralWhite
        Me.opt_SetupLogonNo.Cursor = System.Windows.Forms.Cursors.Default
        Me.opt_SetupLogonNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opt_SetupLogonNo.ForeColor = System.Drawing.Color.Blue
        Me.opt_SetupLogonNo.Location = New System.Drawing.Point(329, 283)
        Me.opt_SetupLogonNo.Name = "opt_SetupLogonNo"
        Me.opt_SetupLogonNo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.opt_SetupLogonNo.Size = New System.Drawing.Size(41, 19)
        Me.opt_SetupLogonNo.TabIndex = 87
        Me.opt_SetupLogonNo.Text = "No"
        Me.opt_SetupLogonNo.UseVisualStyleBackColor = False
        '
        'lbl_SecureLogon
        '
        Me.lbl_SecureLogon.AutoSize = True
        Me.lbl_SecureLogon.BackColor = System.Drawing.Color.FloralWhite
        Me.lbl_SecureLogon.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_SecureLogon.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_SecureLogon.ForeColor = System.Drawing.Color.Blue
        Me.lbl_SecureLogon.Location = New System.Drawing.Point(48, 284)
        Me.lbl_SecureLogon.Name = "lbl_SecureLogon"
        Me.lbl_SecureLogon.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_SecureLogon.Size = New System.Drawing.Size(222, 15)
        Me.lbl_SecureLogon.TabIndex = 89
        Me.lbl_SecureLogon.Text = "Use secured logon for entry to this form"
        '
        'lbl_MsgGeneral
        '
        Me.lbl_MsgGeneral.BackColor = System.Drawing.Color.FloralWhite
        Me.lbl_MsgGeneral.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_MsgGeneral.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_MsgGeneral.ForeColor = System.Drawing.Color.Red
        Me.lbl_MsgGeneral.Location = New System.Drawing.Point(3, 325)
        Me.lbl_MsgGeneral.Name = "lbl_MsgGeneral"
        Me.lbl_MsgGeneral.Size = New System.Drawing.Size(556, 15)
        Me.lbl_MsgGeneral.TabIndex = 126
        Me.lbl_MsgGeneral.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Invoice
        '
        Me.Invoice.BackColor = System.Drawing.Color.FloralWhite
        Me.Invoice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Invoice.Controls.Add(Me.lbl_MsgInvoice)
        Me.Invoice.Controls.Add(Me.fra_CertificateCompliance)
        Me.Invoice.Controls.Add(Me.fra_InvoicePacking)
        Me.Invoice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Invoice.Location = New System.Drawing.Point(4, 22)
        Me.Invoice.Name = "Invoice"
        Me.Invoice.Size = New System.Drawing.Size(564, 353)
        Me.Invoice.TabIndex = 2
        Me.Invoice.Text = "Invoice"
        '
        'lbl_MsgInvoice
        '
        Me.lbl_MsgInvoice.BackColor = System.Drawing.Color.FloralWhite
        Me.lbl_MsgInvoice.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_MsgInvoice.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_MsgInvoice.ForeColor = System.Drawing.Color.Red
        Me.lbl_MsgInvoice.Location = New System.Drawing.Point(3, 327)
        Me.lbl_MsgInvoice.Name = "lbl_MsgInvoice"
        Me.lbl_MsgInvoice.Size = New System.Drawing.Size(556, 15)
        Me.lbl_MsgInvoice.TabIndex = 127
        Me.lbl_MsgInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'fra_CertificateCompliance
        '
        Me.fra_CertificateCompliance.Controls.Add(Me.tbox_SecondaryAgent)
        Me.fra_CertificateCompliance.Controls.Add(Me.lbl_SecondaryAgent)
        Me.fra_CertificateCompliance.Controls.Add(Me.tbox_PrimaryAgent)
        Me.fra_CertificateCompliance.Controls.Add(Me.lbl_PrimaryAgent)
        Me.fra_CertificateCompliance.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fra_CertificateCompliance.ForeColor = System.Drawing.Color.DarkGreen
        Me.fra_CertificateCompliance.Location = New System.Drawing.Point(16, 225)
        Me.fra_CertificateCompliance.Name = "fra_CertificateCompliance"
        Me.fra_CertificateCompliance.Size = New System.Drawing.Size(528, 94)
        Me.fra_CertificateCompliance.TabIndex = 104
        Me.fra_CertificateCompliance.TabStop = False
        Me.fra_CertificateCompliance.Text = "Certificate of Compliance Information"
        '
        'tbox_SecondaryAgent
        '
        Me.tbox_SecondaryAgent.AcceptsReturn = True
        Me.tbox_SecondaryAgent.BackColor = System.Drawing.Color.White
        Me.tbox_SecondaryAgent.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_SecondaryAgent.Enabled = False
        Me.tbox_SecondaryAgent.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_SecondaryAgent.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbox_SecondaryAgent.Location = New System.Drawing.Point(172, 58)
        Me.tbox_SecondaryAgent.MaxLength = 0
        Me.tbox_SecondaryAgent.Name = "tbox_SecondaryAgent"
        Me.tbox_SecondaryAgent.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbox_SecondaryAgent.Size = New System.Drawing.Size(218, 21)
        Me.tbox_SecondaryAgent.TabIndex = 87
        Me.tbox_SecondaryAgent.TabStop = False
        '
        'lbl_SecondaryAgent
        '
        Me.lbl_SecondaryAgent.AutoSize = True
        Me.lbl_SecondaryAgent.BackColor = System.Drawing.Color.FloralWhite
        Me.lbl_SecondaryAgent.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_SecondaryAgent.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_SecondaryAgent.ForeColor = System.Drawing.Color.Blue
        Me.lbl_SecondaryAgent.Location = New System.Drawing.Point(10, 62)
        Me.lbl_SecondaryAgent.Name = "lbl_SecondaryAgent"
        Me.lbl_SecondaryAgent.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_SecondaryAgent.Size = New System.Drawing.Size(162, 15)
        Me.lbl_SecondaryAgent.TabIndex = 79
        Me.lbl_SecondaryAgent.Text = "Secondary Inspection agent:"
        Me.lbl_SecondaryAgent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbox_PrimaryAgent
        '
        Me.tbox_PrimaryAgent.AcceptsReturn = True
        Me.tbox_PrimaryAgent.BackColor = System.Drawing.Color.White
        Me.tbox_PrimaryAgent.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_PrimaryAgent.Enabled = False
        Me.tbox_PrimaryAgent.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_PrimaryAgent.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbox_PrimaryAgent.Location = New System.Drawing.Point(156, 30)
        Me.tbox_PrimaryAgent.MaxLength = 0
        Me.tbox_PrimaryAgent.Name = "tbox_PrimaryAgent"
        Me.tbox_PrimaryAgent.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbox_PrimaryAgent.Size = New System.Drawing.Size(218, 21)
        Me.tbox_PrimaryAgent.TabIndex = 78
        Me.tbox_PrimaryAgent.TabStop = False
        '
        'lbl_PrimaryAgent
        '
        Me.lbl_PrimaryAgent.AutoSize = True
        Me.lbl_PrimaryAgent.BackColor = System.Drawing.Color.FloralWhite
        Me.lbl_PrimaryAgent.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_PrimaryAgent.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_PrimaryAgent.ForeColor = System.Drawing.Color.Blue
        Me.lbl_PrimaryAgent.Location = New System.Drawing.Point(10, 34)
        Me.lbl_PrimaryAgent.Name = "lbl_PrimaryAgent"
        Me.lbl_PrimaryAgent.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_PrimaryAgent.Size = New System.Drawing.Size(146, 15)
        Me.lbl_PrimaryAgent.TabIndex = 77
        Me.lbl_PrimaryAgent.Text = "Primary Inspection agent:"
        Me.lbl_PrimaryAgent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'fra_InvoicePacking
        '
        Me.fra_InvoicePacking.Controls.Add(Me.cbx_ReInvoice)
        Me.fra_InvoicePacking.Controls.Add(Me.lbl_Percent)
        Me.fra_InvoicePacking.Controls.Add(Me.tbox_DiscountPercent)
        Me.fra_InvoicePacking.Controls.Add(Me.tbox_DiscountDays)
        Me.fra_InvoicePacking.Controls.Add(Me.tbox_LastInvoice)
        Me.fra_InvoicePacking.Controls.Add(Me.tbox_DueDays)
        Me.fra_InvoicePacking.Controls.Add(Me.tbox_Terms)
        Me.fra_InvoicePacking.Controls.Add(Me.tbox_ShipVia)
        Me.fra_InvoicePacking.Controls.Add(Me.lbl_LastInvoice)
        Me.fra_InvoicePacking.Controls.Add(Me.lbl_DueDays)
        Me.fra_InvoicePacking.Controls.Add(Me.lbl_DiscountPercent)
        Me.fra_InvoicePacking.Controls.Add(Me.lbl_DiscountDays)
        Me.fra_InvoicePacking.Controls.Add(Me.lbl_Terms)
        Me.fra_InvoicePacking.Controls.Add(Me.lbl_ShipVia)
        Me.fra_InvoicePacking.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fra_InvoicePacking.ForeColor = System.Drawing.Color.DarkGreen
        Me.fra_InvoicePacking.Location = New System.Drawing.Point(16, 10)
        Me.fra_InvoicePacking.Name = "fra_InvoicePacking"
        Me.fra_InvoicePacking.Size = New System.Drawing.Size(528, 204)
        Me.fra_InvoicePacking.TabIndex = 103
        Me.fra_InvoicePacking.TabStop = False
        Me.fra_InvoicePacking.Text = "Invoice && Packing Slip Information"
        '
        'cbx_ReInvoice
        '
        Me.cbx_ReInvoice.AutoSize = True
        Me.cbx_ReInvoice.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbx_ReInvoice.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbx_ReInvoice.ForeColor = System.Drawing.Color.Blue
        Me.cbx_ReInvoice.Location = New System.Drawing.Point(304, 174)
        Me.cbx_ReInvoice.Name = "cbx_ReInvoice"
        Me.cbx_ReInvoice.Size = New System.Drawing.Size(208, 19)
        Me.cbx_ReInvoice.TabIndex = 98
        Me.cbx_ReInvoice.Text = "Allow Re-Invoice of Paid Invoices:"
        Me.cbx_ReInvoice.UseVisualStyleBackColor = True
        '
        'lbl_Percent
        '
        Me.lbl_Percent.AutoSize = True
        Me.lbl_Percent.BackColor = System.Drawing.Color.FloralWhite
        Me.lbl_Percent.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_Percent.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Percent.ForeColor = System.Drawing.Color.Blue
        Me.lbl_Percent.Location = New System.Drawing.Point(284, 118)
        Me.lbl_Percent.Name = "lbl_Percent"
        Me.lbl_Percent.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_Percent.Size = New System.Drawing.Size(49, 15)
        Me.lbl_Percent.TabIndex = 97
        Me.lbl_Percent.Text = "Percent"
        Me.lbl_Percent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbox_DiscountPercent
        '
        Me.tbox_DiscountPercent.AcceptsReturn = True
        Me.tbox_DiscountPercent.BackColor = System.Drawing.Color.White
        Me.tbox_DiscountPercent.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_DiscountPercent.Enabled = False
        Me.tbox_DiscountPercent.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_DiscountPercent.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbox_DiscountPercent.Location = New System.Drawing.Point(256, 113)
        Me.tbox_DiscountPercent.MaxLength = 0
        Me.tbox_DiscountPercent.Name = "tbox_DiscountPercent"
        Me.tbox_DiscountPercent.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbox_DiscountPercent.Size = New System.Drawing.Size(24, 21)
        Me.tbox_DiscountPercent.TabIndex = 96
        Me.tbox_DiscountPercent.TabStop = False
        Me.tbox_DiscountPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbox_DiscountDays
        '
        Me.tbox_DiscountDays.AcceptsReturn = True
        Me.tbox_DiscountDays.BackColor = System.Drawing.Color.White
        Me.tbox_DiscountDays.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_DiscountDays.Enabled = False
        Me.tbox_DiscountDays.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_DiscountDays.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbox_DiscountDays.Location = New System.Drawing.Point(322, 85)
        Me.tbox_DiscountDays.MaxLength = 0
        Me.tbox_DiscountDays.Name = "tbox_DiscountDays"
        Me.tbox_DiscountDays.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbox_DiscountDays.Size = New System.Drawing.Size(24, 21)
        Me.tbox_DiscountDays.TabIndex = 95
        Me.tbox_DiscountDays.TabStop = False
        Me.tbox_DiscountDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbox_LastInvoice
        '
        Me.tbox_LastInvoice.AcceptsReturn = True
        Me.tbox_LastInvoice.BackColor = System.Drawing.Color.White
        Me.tbox_LastInvoice.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_LastInvoice.Enabled = False
        Me.tbox_LastInvoice.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_LastInvoice.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbox_LastInvoice.Location = New System.Drawing.Point(131, 169)
        Me.tbox_LastInvoice.MaxLength = 0
        Me.tbox_LastInvoice.Name = "tbox_LastInvoice"
        Me.tbox_LastInvoice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbox_LastInvoice.Size = New System.Drawing.Size(70, 21)
        Me.tbox_LastInvoice.TabIndex = 92
        Me.tbox_LastInvoice.TabStop = False
        '
        'tbox_DueDays
        '
        Me.tbox_DueDays.AcceptsReturn = True
        Me.tbox_DueDays.BackColor = System.Drawing.Color.White
        Me.tbox_DueDays.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_DueDays.Enabled = False
        Me.tbox_DueDays.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_DueDays.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbox_DueDays.Location = New System.Drawing.Point(236, 141)
        Me.tbox_DueDays.MaxLength = 0
        Me.tbox_DueDays.Name = "tbox_DueDays"
        Me.tbox_DueDays.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbox_DueDays.Size = New System.Drawing.Size(24, 21)
        Me.tbox_DueDays.TabIndex = 91
        Me.tbox_DueDays.TabStop = False
        Me.tbox_DueDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbox_Terms
        '
        Me.tbox_Terms.AcceptsReturn = True
        Me.tbox_Terms.BackColor = System.Drawing.Color.White
        Me.tbox_Terms.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_Terms.Enabled = False
        Me.tbox_Terms.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_Terms.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbox_Terms.Location = New System.Drawing.Point(170, 57)
        Me.tbox_Terms.MaxLength = 0
        Me.tbox_Terms.Name = "tbox_Terms"
        Me.tbox_Terms.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbox_Terms.Size = New System.Drawing.Size(150, 21)
        Me.tbox_Terms.TabIndex = 89
        Me.tbox_Terms.TabStop = False
        '
        'tbox_ShipVia
        '
        Me.tbox_ShipVia.AcceptsReturn = True
        Me.tbox_ShipVia.BackColor = System.Drawing.Color.White
        Me.tbox_ShipVia.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_ShipVia.Enabled = False
        Me.tbox_ShipVia.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_ShipVia.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbox_ShipVia.Location = New System.Drawing.Point(166, 29)
        Me.tbox_ShipVia.MaxLength = 0
        Me.tbox_ShipVia.Name = "tbox_ShipVia"
        Me.tbox_ShipVia.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbox_ShipVia.Size = New System.Drawing.Size(120, 21)
        Me.tbox_ShipVia.TabIndex = 88
        Me.tbox_ShipVia.TabStop = False
        '
        'lbl_LastInvoice
        '
        Me.lbl_LastInvoice.AutoSize = True
        Me.lbl_LastInvoice.BackColor = System.Drawing.Color.FloralWhite
        Me.lbl_LastInvoice.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_LastInvoice.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_LastInvoice.ForeColor = System.Drawing.Color.Blue
        Me.lbl_LastInvoice.Location = New System.Drawing.Point(10, 174)
        Me.lbl_LastInvoice.Name = "lbl_LastInvoice"
        Me.lbl_LastInvoice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_LastInvoice.Size = New System.Drawing.Size(121, 15)
        Me.lbl_LastInvoice.TabIndex = 86
        Me.lbl_LastInvoice.Text = "Last Invoice number:"
        Me.lbl_LastInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_DueDays
        '
        Me.lbl_DueDays.AutoSize = True
        Me.lbl_DueDays.BackColor = System.Drawing.Color.FloralWhite
        Me.lbl_DueDays.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_DueDays.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_DueDays.ForeColor = System.Drawing.Color.Blue
        Me.lbl_DueDays.Location = New System.Drawing.Point(10, 146)
        Me.lbl_DueDays.Name = "lbl_DueDays"
        Me.lbl_DueDays.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_DueDays.Size = New System.Drawing.Size(226, 15)
        Me.lbl_DueDays.TabIndex = 85
        Me.lbl_DueDays.Text = "Total number of days till payment is due:"
        Me.lbl_DueDays.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_DiscountPercent
        '
        Me.lbl_DiscountPercent.AutoSize = True
        Me.lbl_DiscountPercent.BackColor = System.Drawing.Color.FloralWhite
        Me.lbl_DiscountPercent.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_DiscountPercent.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_DiscountPercent.ForeColor = System.Drawing.Color.Blue
        Me.lbl_DiscountPercent.Location = New System.Drawing.Point(10, 118)
        Me.lbl_DiscountPercent.Name = "lbl_DiscountPercent"
        Me.lbl_DiscountPercent.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_DiscountPercent.Size = New System.Drawing.Size(246, 15)
        Me.lbl_DiscountPercent.TabIndex = 84
        Me.lbl_DiscountPercent.Text = "Discount offered if quick payment term met :"
        Me.lbl_DiscountPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_DiscountDays
        '
        Me.lbl_DiscountDays.AutoSize = True
        Me.lbl_DiscountDays.BackColor = System.Drawing.Color.FloralWhite
        Me.lbl_DiscountDays.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_DiscountDays.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_DiscountDays.ForeColor = System.Drawing.Color.Blue
        Me.lbl_DiscountDays.Location = New System.Drawing.Point(10, 90)
        Me.lbl_DiscountDays.Name = "lbl_DiscountDays"
        Me.lbl_DiscountDays.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_DiscountDays.Size = New System.Drawing.Size(312, 15)
        Me.lbl_DiscountDays.TabIndex = 83
        Me.lbl_DiscountDays.Text = "Amount of days offered for payment to optain a discount:"
        Me.lbl_DiscountDays.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_Terms
        '
        Me.lbl_Terms.AutoSize = True
        Me.lbl_Terms.BackColor = System.Drawing.Color.FloralWhite
        Me.lbl_Terms.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_Terms.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Terms.ForeColor = System.Drawing.Color.Blue
        Me.lbl_Terms.Location = New System.Drawing.Point(10, 62)
        Me.lbl_Terms.Name = "lbl_Terms"
        Me.lbl_Terms.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_Terms.Size = New System.Drawing.Size(159, 15)
        Me.lbl_Terms.TabIndex = 81
        Me.lbl_Terms.Text = "Terms message on invoice:"
        Me.lbl_Terms.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_ShipVia
        '
        Me.lbl_ShipVia.AutoSize = True
        Me.lbl_ShipVia.BackColor = System.Drawing.Color.FloralWhite
        Me.lbl_ShipVia.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_ShipVia.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ShipVia.ForeColor = System.Drawing.Color.Blue
        Me.lbl_ShipVia.Location = New System.Drawing.Point(10, 34)
        Me.lbl_ShipVia.Name = "lbl_ShipVia"
        Me.lbl_ShipVia.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_ShipVia.Size = New System.Drawing.Size(156, 15)
        Me.lbl_ShipVia.TabIndex = 80
        Me.lbl_ShipVia.Text = "Default shipping message:"
        Me.lbl_ShipVia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Checkbook
        '
        Me.Checkbook.BackColor = System.Drawing.Color.FloralWhite
        Me.Checkbook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Checkbook.Controls.Add(Me.lbl_MsgCheckbook)
        Me.Checkbook.Controls.Add(Me.fra_Checkbook)
        Me.Checkbook.Location = New System.Drawing.Point(4, 22)
        Me.Checkbook.Name = "Checkbook"
        Me.Checkbook.Size = New System.Drawing.Size(564, 353)
        Me.Checkbook.TabIndex = 5
        Me.Checkbook.Text = "Checkbook"
        '
        'lbl_MsgCheckbook
        '
        Me.lbl_MsgCheckbook.BackColor = System.Drawing.Color.FloralWhite
        Me.lbl_MsgCheckbook.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_MsgCheckbook.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_MsgCheckbook.ForeColor = System.Drawing.Color.Red
        Me.lbl_MsgCheckbook.Location = New System.Drawing.Point(3, 325)
        Me.lbl_MsgCheckbook.Name = "lbl_MsgCheckbook"
        Me.lbl_MsgCheckbook.Size = New System.Drawing.Size(556, 15)
        Me.lbl_MsgCheckbook.TabIndex = 127
        Me.lbl_MsgCheckbook.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'fra_Checkbook
        '
        Me.fra_Checkbook.Controls.Add(Me.fra_CheckbookInfo)
        Me.fra_Checkbook.Location = New System.Drawing.Point(10, 4)
        Me.fra_Checkbook.Name = "fra_Checkbook"
        Me.fra_Checkbook.Size = New System.Drawing.Size(543, 312)
        Me.fra_Checkbook.TabIndex = 106
        Me.fra_Checkbook.TabStop = False
        '
        'fra_CheckbookInfo
        '
        Me.fra_CheckbookInfo.Controls.Add(Me.lbl_Progress)
        Me.fra_CheckbookInfo.Controls.Add(Me.lbl_CheckbookBalance)
        Me.fra_CheckbookInfo.Controls.Add(Me.label_CheckbookBalance)
        Me.fra_CheckbookInfo.Controls.Add(Me.cmd_ReCalculate)
        Me.fra_CheckbookInfo.Controls.Add(Me.Label19)
        Me.fra_CheckbookInfo.Controls.Add(Me.tbox_StartBalance)
        Me.fra_CheckbookInfo.Controls.Add(Me.tbox_ReconcileDate)
        Me.fra_CheckbookInfo.Controls.Add(Me.tbox_ReconcileBalance)
        Me.fra_CheckbookInfo.Controls.Add(Me.tbox_LastCheck)
        Me.fra_CheckbookInfo.Controls.Add(Me.lbl_ReconcileBalance)
        Me.fra_CheckbookInfo.Controls.Add(Me.lbl_ReconcileDate)
        Me.fra_CheckbookInfo.Controls.Add(Me.lbl_LastCheck)
        Me.fra_CheckbookInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fra_CheckbookInfo.ForeColor = System.Drawing.Color.DarkGreen
        Me.fra_CheckbookInfo.Location = New System.Drawing.Point(11, 10)
        Me.fra_CheckbookInfo.Name = "fra_CheckbookInfo"
        Me.fra_CheckbookInfo.Size = New System.Drawing.Size(520, 144)
        Me.fra_CheckbookInfo.TabIndex = 106
        Me.fra_CheckbookInfo.TabStop = False
        Me.fra_CheckbookInfo.Text = "Checkbook Information"
        '
        'lbl_Progress
        '
        Me.lbl_Progress.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Progress.ForeColor = System.Drawing.Color.Red
        Me.lbl_Progress.Location = New System.Drawing.Point(408, 100)
        Me.lbl_Progress.Name = "lbl_Progress"
        Me.lbl_Progress.Size = New System.Drawing.Size(90, 15)
        Me.lbl_Progress.TabIndex = 105
        Me.lbl_Progress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_CheckbookBalance
        '
        Me.lbl_CheckbookBalance.BackColor = System.Drawing.Color.White
        Me.lbl_CheckbookBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_CheckbookBalance.ForeColor = System.Drawing.Color.Black
        Me.lbl_CheckbookBalance.Location = New System.Drawing.Point(396, 44)
        Me.lbl_CheckbookBalance.Name = "lbl_CheckbookBalance"
        Me.lbl_CheckbookBalance.Size = New System.Drawing.Size(112, 22)
        Me.lbl_CheckbookBalance.TabIndex = 104
        Me.lbl_CheckbookBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_CheckbookBalance.Visible = False
        '
        'label_CheckbookBalance
        '
        Me.label_CheckbookBalance.AutoSize = True
        Me.label_CheckbookBalance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_CheckbookBalance.Location = New System.Drawing.Point(394, 27)
        Me.label_CheckbookBalance.Name = "label_CheckbookBalance"
        Me.label_CheckbookBalance.Size = New System.Drawing.Size(117, 15)
        Me.label_CheckbookBalance.TabIndex = 103
        Me.label_CheckbookBalance.Text = "Checkbook Balance"
        Me.label_CheckbookBalance.Visible = False
        '
        'cmd_ReCalculate
        '
        Me.cmd_ReCalculate.BackColor = System.Drawing.Color.Cornsilk
        Me.cmd_ReCalculate.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_ReCalculate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_ReCalculate.Location = New System.Drawing.Point(407, 72)
        Me.cmd_ReCalculate.Name = "cmd_ReCalculate"
        Me.cmd_ReCalculate.Size = New System.Drawing.Size(90, 23)
        Me.cmd_ReCalculate.TabIndex = 101
        Me.cmd_ReCalculate.Text = "Re_Calculate"
        Me.cmd_ReCalculate.UseVisualStyleBackColor = False
        Me.cmd_ReCalculate.Visible = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.FloralWhite
        Me.Label19.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Blue
        Me.Label19.Location = New System.Drawing.Point(10, 34)
        Me.Label19.Name = "Label19"
        Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label19.Size = New System.Drawing.Size(163, 15)
        Me.Label19.TabIndex = 100
        Me.Label19.Text = "Checkbook starting balance:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbox_StartBalance
        '
        Me.tbox_StartBalance.AcceptsReturn = True
        Me.tbox_StartBalance.BackColor = System.Drawing.Color.White
        Me.tbox_StartBalance.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_StartBalance.Enabled = False
        Me.tbox_StartBalance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_StartBalance.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbox_StartBalance.Location = New System.Drawing.Point(173, 29)
        Me.tbox_StartBalance.MaxLength = 0
        Me.tbox_StartBalance.Name = "tbox_StartBalance"
        Me.tbox_StartBalance.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbox_StartBalance.Size = New System.Drawing.Size(90, 21)
        Me.tbox_StartBalance.TabIndex = 99
        Me.tbox_StartBalance.TabStop = False
        '
        'tbox_ReconcileDate
        '
        Me.tbox_ReconcileDate.AllowPromptAsInput = False
        Me.tbox_ReconcileDate.BackColor = System.Drawing.Color.White
        Me.tbox_ReconcileDate.Enabled = False
        Me.tbox_ReconcileDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_ReconcileDate.Location = New System.Drawing.Point(197, 85)
        Me.tbox_ReconcileDate.Mask = "00/00/0000"
        Me.tbox_ReconcileDate.Name = "tbox_ReconcileDate"
        Me.tbox_ReconcileDate.Size = New System.Drawing.Size(67, 21)
        Me.tbox_ReconcileDate.TabIndex = 98
        Me.tbox_ReconcileDate.ValidatingType = GetType(Date)
        '
        'tbox_ReconcileBalance
        '
        Me.tbox_ReconcileBalance.AcceptsReturn = True
        Me.tbox_ReconcileBalance.BackColor = System.Drawing.Color.White
        Me.tbox_ReconcileBalance.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_ReconcileBalance.Enabled = False
        Me.tbox_ReconcileBalance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_ReconcileBalance.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbox_ReconcileBalance.Location = New System.Drawing.Point(230, 113)
        Me.tbox_ReconcileBalance.MaxLength = 0
        Me.tbox_ReconcileBalance.Name = "tbox_ReconcileBalance"
        Me.tbox_ReconcileBalance.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbox_ReconcileBalance.Size = New System.Drawing.Size(90, 21)
        Me.tbox_ReconcileBalance.TabIndex = 95
        Me.tbox_ReconcileBalance.TabStop = False
        '
        'tbox_LastCheck
        '
        Me.tbox_LastCheck.AcceptsReturn = True
        Me.tbox_LastCheck.BackColor = System.Drawing.Color.White
        Me.tbox_LastCheck.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_LastCheck.Enabled = False
        Me.tbox_LastCheck.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_LastCheck.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbox_LastCheck.Location = New System.Drawing.Point(200, 57)
        Me.tbox_LastCheck.MaxLength = 0
        Me.tbox_LastCheck.Name = "tbox_LastCheck"
        Me.tbox_LastCheck.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbox_LastCheck.Size = New System.Drawing.Size(60, 21)
        Me.tbox_LastCheck.TabIndex = 88
        Me.tbox_LastCheck.TabStop = False
        '
        'lbl_ReconcileBalance
        '
        Me.lbl_ReconcileBalance.AutoSize = True
        Me.lbl_ReconcileBalance.BackColor = System.Drawing.Color.FloralWhite
        Me.lbl_ReconcileBalance.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_ReconcileBalance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ReconcileBalance.ForeColor = System.Drawing.Color.Blue
        Me.lbl_ReconcileBalance.Location = New System.Drawing.Point(10, 118)
        Me.lbl_ReconcileBalance.Name = "lbl_ReconcileBalance"
        Me.lbl_ReconcileBalance.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_ReconcileBalance.Size = New System.Drawing.Size(220, 15)
        Me.lbl_ReconcileBalance.TabIndex = 83
        Me.lbl_ReconcileBalance.Text = "Balance after last checkbook reconcile:"
        Me.lbl_ReconcileBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_ReconcileDate
        '
        Me.lbl_ReconcileDate.AutoSize = True
        Me.lbl_ReconcileDate.BackColor = System.Drawing.Color.FloralWhite
        Me.lbl_ReconcileDate.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_ReconcileDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ReconcileDate.ForeColor = System.Drawing.Color.Blue
        Me.lbl_ReconcileDate.Location = New System.Drawing.Point(10, 90)
        Me.lbl_ReconcileDate.Name = "lbl_ReconcileDate"
        Me.lbl_ReconcileDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_ReconcileDate.Size = New System.Drawing.Size(187, 15)
        Me.lbl_ReconcileDate.TabIndex = 81
        Me.lbl_ReconcileDate.Text = "Date of last checkbook reconcile:"
        Me.lbl_ReconcileDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_LastCheck
        '
        Me.lbl_LastCheck.AutoSize = True
        Me.lbl_LastCheck.BackColor = System.Drawing.Color.FloralWhite
        Me.lbl_LastCheck.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_LastCheck.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_LastCheck.ForeColor = System.Drawing.Color.Blue
        Me.lbl_LastCheck.Location = New System.Drawing.Point(10, 62)
        Me.lbl_LastCheck.Name = "lbl_LastCheck"
        Me.lbl_LastCheck.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_LastCheck.Size = New System.Drawing.Size(190, 15)
        Me.lbl_LastCheck.TabIndex = 80
        Me.lbl_LastCheck.Text = "Last check number in checkbook:"
        Me.lbl_LastCheck.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TaxCategory
        '
        Me.TaxCategory.BackColor = System.Drawing.Color.FloralWhite
        Me.TaxCategory.Controls.Add(Me.fra_TaxCategorys)
        Me.TaxCategory.Location = New System.Drawing.Point(4, 22)
        Me.TaxCategory.Name = "TaxCategory"
        Me.TaxCategory.Size = New System.Drawing.Size(564, 353)
        Me.TaxCategory.TabIndex = 6
        Me.TaxCategory.Text = "Tax Categorys"
        '
        'fra_TaxCategorys
        '
        Me.fra_TaxCategorys.BackColor = System.Drawing.Color.FloralWhite
        Me.fra_TaxCategorys.Controls.Add(Me.lbl_MsgTaxCategory)
        Me.fra_TaxCategorys.Controls.Add(Me.cmd_CategoryDefaults)
        Me.fra_TaxCategorys.Controls.Add(Me.Label10)
        Me.fra_TaxCategorys.Controls.Add(Me.Label11)
        Me.fra_TaxCategorys.Controls.Add(Me.Label12)
        Me.fra_TaxCategorys.Controls.Add(Me.Label13)
        Me.fra_TaxCategorys.Controls.Add(Me.Label14)
        Me.fra_TaxCategorys.Controls.Add(Me.Label15)
        Me.fra_TaxCategorys.Controls.Add(Me.Label16)
        Me.fra_TaxCategorys.Controls.Add(Me.Label17)
        Me.fra_TaxCategorys.Controls.Add(Me.Label18)
        Me.fra_TaxCategorys.Controls.Add(Me.Label7)
        Me.fra_TaxCategorys.Controls.Add(Me.Label8)
        Me.fra_TaxCategorys.Controls.Add(Me.Label9)
        Me.fra_TaxCategorys.Controls.Add(Me.Label4)
        Me.fra_TaxCategorys.Controls.Add(Me.Label5)
        Me.fra_TaxCategorys.Controls.Add(Me.Label6)
        Me.fra_TaxCategorys.Controls.Add(Me.Label1)
        Me.fra_TaxCategorys.Controls.Add(Me.Label2)
        Me.fra_TaxCategorys.Controls.Add(Me.Label3)
        Me.fra_TaxCategorys.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fra_TaxCategorys.ForeColor = System.Drawing.Color.DarkGreen
        Me.fra_TaxCategorys.Location = New System.Drawing.Point(16, 10)
        Me.fra_TaxCategorys.Name = "fra_TaxCategorys"
        Me.fra_TaxCategorys.Size = New System.Drawing.Size(529, 326)
        Me.fra_TaxCategorys.TabIndex = 106
        Me.fra_TaxCategorys.TabStop = False
        Me.fra_TaxCategorys.Text = "Checkbook Tax Categories"
        '
        'lbl_MsgTaxCategory
        '
        Me.lbl_MsgTaxCategory.BackColor = System.Drawing.Color.FloralWhite
        Me.lbl_MsgTaxCategory.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_MsgTaxCategory.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_MsgTaxCategory.ForeColor = System.Drawing.Color.Red
        Me.lbl_MsgTaxCategory.Location = New System.Drawing.Point(6, 301)
        Me.lbl_MsgTaxCategory.Name = "lbl_MsgTaxCategory"
        Me.lbl_MsgTaxCategory.Size = New System.Drawing.Size(445, 15)
        Me.lbl_MsgTaxCategory.TabIndex = 125
        Me.lbl_MsgTaxCategory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmd_CategoryDefaults
        '
        Me.cmd_CategoryDefaults.Enabled = False
        Me.cmd_CategoryDefaults.Location = New System.Drawing.Point(456, 295)
        Me.cmd_CategoryDefaults.Name = "cmd_CategoryDefaults"
        Me.cmd_CategoryDefaults.Size = New System.Drawing.Size(65, 21)
        Me.cmd_CategoryDefaults.TabIndex = 118
        Me.cmd_CategoryDefaults.Text = "Defaults"
        Me.cmd_CategoryDefaults.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.FloralWhite
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(179, 186)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(24, 15)
        Me.Label10.TabIndex = 117
        Me.Label10.Text = "15:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.FloralWhite
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Blue
        Me.Label11.Location = New System.Drawing.Point(179, 156)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(24, 15)
        Me.Label11.TabIndex = 116
        Me.Label11.Text = "14:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.FloralWhite
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(179, 126)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(24, 15)
        Me.Label12.TabIndex = 115
        Me.Label12.Text = "13:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.FloralWhite
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Blue
        Me.Label13.Location = New System.Drawing.Point(179, 276)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(24, 15)
        Me.Label13.TabIndex = 111
        Me.Label13.Text = "18:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.FloralWhite
        Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(179, 246)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label14.Size = New System.Drawing.Size(24, 15)
        Me.Label14.TabIndex = 110
        Me.Label14.Text = "17:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.FloralWhite
        Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Blue
        Me.Label15.Location = New System.Drawing.Point(179, 216)
        Me.Label15.Name = "Label15"
        Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label15.Size = New System.Drawing.Size(24, 15)
        Me.Label15.TabIndex = 109
        Me.Label15.Text = "16:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.FloralWhite
        Me.Label16.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Blue
        Me.Label16.Location = New System.Drawing.Point(179, 96)
        Me.Label16.Name = "Label16"
        Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label16.Size = New System.Drawing.Size(24, 15)
        Me.Label16.TabIndex = 105
        Me.Label16.Text = "12:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.FloralWhite
        Me.Label17.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Blue
        Me.Label17.Location = New System.Drawing.Point(179, 66)
        Me.Label17.Name = "Label17"
        Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label17.Size = New System.Drawing.Size(24, 15)
        Me.Label17.TabIndex = 104
        Me.Label17.Text = "11:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.FloralWhite
        Me.Label18.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Blue
        Me.Label18.Location = New System.Drawing.Point(179, 36)
        Me.Label18.Name = "Label18"
        Me.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label18.Size = New System.Drawing.Size(24, 15)
        Me.Label18.TabIndex = 103
        Me.Label18.Text = "10:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.FloralWhite
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(10, 184)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(17, 15)
        Me.Label7.TabIndex = 99
        Me.Label7.Text = "6:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.FloralWhite
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(10, 154)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(17, 15)
        Me.Label8.TabIndex = 98
        Me.Label8.Text = "5:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FloralWhite
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(10, 124)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(17, 15)
        Me.Label9.TabIndex = 97
        Me.Label9.Text = "4:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FloralWhite
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(10, 274)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(17, 15)
        Me.Label4.TabIndex = 93
        Me.Label4.Text = "9:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FloralWhite
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(10, 244)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(17, 15)
        Me.Label5.TabIndex = 92
        Me.Label5.Text = "8:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FloralWhite
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(10, 214)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(17, 15)
        Me.Label6.TabIndex = 91
        Me.Label6.Text = "7:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FloralWhite
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(10, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(17, 15)
        Me.Label1.TabIndex = 83
        Me.Label1.Text = "3:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FloralWhite
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(10, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(17, 15)
        Me.Label2.TabIndex = 81
        Me.Label2.Text = "2:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FloralWhite
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(10, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(17, 15)
        Me.Label3.TabIndex = 80
        Me.Label3.Text = "1:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Vacations
        '
        Me.Vacations.BackColor = System.Drawing.Color.FloralWhite
        Me.Vacations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Vacations.Controls.Add(Me.lbl_MsgPayRoll)
        Me.Vacations.Controls.Add(Me.fra_Payroll)
        Me.Vacations.Controls.Add(Me.fra_Vacation)
        Me.Vacations.Location = New System.Drawing.Point(4, 22)
        Me.Vacations.Name = "Vacations"
        Me.Vacations.Size = New System.Drawing.Size(564, 353)
        Me.Vacations.TabIndex = 4
        Me.Vacations.Text = "Payroll & Vacations"
        '
        'lbl_MsgPayRoll
        '
        Me.lbl_MsgPayRoll.BackColor = System.Drawing.Color.FloralWhite
        Me.lbl_MsgPayRoll.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_MsgPayRoll.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_MsgPayRoll.ForeColor = System.Drawing.Color.Red
        Me.lbl_MsgPayRoll.Location = New System.Drawing.Point(3, 325)
        Me.lbl_MsgPayRoll.Name = "lbl_MsgPayRoll"
        Me.lbl_MsgPayRoll.Size = New System.Drawing.Size(556, 15)
        Me.lbl_MsgPayRoll.TabIndex = 128
        Me.lbl_MsgPayRoll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'fra_Payroll
        '
        Me.fra_Payroll.Controls.Add(Me.tbox_MedicarePercent)
        Me.fra_Payroll.Controls.Add(Me.lbl_MedicarePercent)
        Me.fra_Payroll.Controls.Add(Me.tbox_SocSecPercent)
        Me.fra_Payroll.Controls.Add(Me.tbox_SocSecBaseLimit)
        Me.fra_Payroll.Controls.Add(Me.lbl_SocSecPercent)
        Me.fra_Payroll.Controls.Add(Me.lbl_SocSecBaseLimit)
        Me.fra_Payroll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fra_Payroll.ForeColor = System.Drawing.Color.DarkGreen
        Me.fra_Payroll.Location = New System.Drawing.Point(16, 10)
        Me.fra_Payroll.Name = "fra_Payroll"
        Me.fra_Payroll.Size = New System.Drawing.Size(528, 120)
        Me.fra_Payroll.TabIndex = 106
        Me.fra_Payroll.TabStop = False
        Me.fra_Payroll.Text = "Payroll Information"
        '
        'tbox_MedicarePercent
        '
        Me.tbox_MedicarePercent.AcceptsReturn = True
        Me.tbox_MedicarePercent.BackColor = System.Drawing.Color.White
        Me.tbox_MedicarePercent.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_MedicarePercent.Enabled = False
        Me.tbox_MedicarePercent.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_MedicarePercent.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbox_MedicarePercent.Location = New System.Drawing.Point(157, 84)
        Me.tbox_MedicarePercent.MaxLength = 0
        Me.tbox_MedicarePercent.Name = "tbox_MedicarePercent"
        Me.tbox_MedicarePercent.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbox_MedicarePercent.Size = New System.Drawing.Size(44, 21)
        Me.tbox_MedicarePercent.TabIndex = 108
        Me.tbox_MedicarePercent.TabStop = False
        '
        'lbl_MedicarePercent
        '
        Me.lbl_MedicarePercent.AutoSize = True
        Me.lbl_MedicarePercent.BackColor = System.Drawing.Color.FloralWhite
        Me.lbl_MedicarePercent.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_MedicarePercent.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_MedicarePercent.ForeColor = System.Drawing.Color.Blue
        Me.lbl_MedicarePercent.Location = New System.Drawing.Point(10, 89)
        Me.lbl_MedicarePercent.Name = "lbl_MedicarePercent"
        Me.lbl_MedicarePercent.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_MedicarePercent.Size = New System.Drawing.Size(147, 15)
        Me.lbl_MedicarePercent.TabIndex = 107
        Me.lbl_MedicarePercent.Text = "Medicare Tax Percentage:"
        Me.lbl_MedicarePercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbox_SocSecPercent
        '
        Me.tbox_SocSecPercent.AcceptsReturn = True
        Me.tbox_SocSecPercent.BackColor = System.Drawing.Color.White
        Me.tbox_SocSecPercent.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_SocSecPercent.Enabled = False
        Me.tbox_SocSecPercent.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_SocSecPercent.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbox_SocSecPercent.Location = New System.Drawing.Point(187, 57)
        Me.tbox_SocSecPercent.MaxLength = 0
        Me.tbox_SocSecPercent.Name = "tbox_SocSecPercent"
        Me.tbox_SocSecPercent.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbox_SocSecPercent.Size = New System.Drawing.Size(44, 21)
        Me.tbox_SocSecPercent.TabIndex = 106
        Me.tbox_SocSecPercent.TabStop = False
        Me.tbox_SocSecPercent.Text = "0.0625"
        '
        'tbox_SocSecBaseLimit
        '
        Me.tbox_SocSecBaseLimit.AcceptsReturn = True
        Me.tbox_SocSecBaseLimit.BackColor = System.Drawing.Color.White
        Me.tbox_SocSecBaseLimit.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_SocSecBaseLimit.Enabled = False
        Me.tbox_SocSecBaseLimit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_SocSecBaseLimit.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbox_SocSecBaseLimit.Location = New System.Drawing.Point(197, 29)
        Me.tbox_SocSecBaseLimit.MaxLength = 0
        Me.tbox_SocSecBaseLimit.Name = "tbox_SocSecBaseLimit"
        Me.tbox_SocSecBaseLimit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbox_SocSecBaseLimit.Size = New System.Drawing.Size(84, 21)
        Me.tbox_SocSecBaseLimit.TabIndex = 88
        Me.tbox_SocSecBaseLimit.TabStop = False
        '
        'lbl_SocSecPercent
        '
        Me.lbl_SocSecPercent.AutoSize = True
        Me.lbl_SocSecPercent.BackColor = System.Drawing.Color.FloralWhite
        Me.lbl_SocSecPercent.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_SocSecPercent.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_SocSecPercent.ForeColor = System.Drawing.Color.Blue
        Me.lbl_SocSecPercent.Location = New System.Drawing.Point(10, 62)
        Me.lbl_SocSecPercent.Name = "lbl_SocSecPercent"
        Me.lbl_SocSecPercent.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_SocSecPercent.Size = New System.Drawing.Size(177, 15)
        Me.lbl_SocSecPercent.TabIndex = 81
        Me.lbl_SocSecPercent.Text = "Social Security Tax Percentage:"
        Me.lbl_SocSecPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_SocSecBaseLimit
        '
        Me.lbl_SocSecBaseLimit.AutoSize = True
        Me.lbl_SocSecBaseLimit.BackColor = System.Drawing.Color.FloralWhite
        Me.lbl_SocSecBaseLimit.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_SocSecBaseLimit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_SocSecBaseLimit.ForeColor = System.Drawing.Color.Blue
        Me.lbl_SocSecBaseLimit.Location = New System.Drawing.Point(10, 34)
        Me.lbl_SocSecBaseLimit.Name = "lbl_SocSecBaseLimit"
        Me.lbl_SocSecBaseLimit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_SocSecBaseLimit.Size = New System.Drawing.Size(187, 15)
        Me.lbl_SocSecBaseLimit.TabIndex = 80
        Me.lbl_SocSecBaseLimit.Text = "Social Security Wage Base Limit:"
        Me.lbl_SocSecBaseLimit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'fra_Vacation
        '
        Me.fra_Vacation.Controls.Add(Me.opt_TrackYears3)
        Me.fra_Vacation.Controls.Add(Me.opt_TrackYears1)
        Me.fra_Vacation.Controls.Add(Me.opt_TrackYears2)
        Me.fra_Vacation.Controls.Add(Me.tbox_VacaStop)
        Me.fra_Vacation.Controls.Add(Me.lbl_VacaStop)
        Me.fra_Vacation.Controls.Add(Me.tbox_VacaAddDays)
        Me.fra_Vacation.Controls.Add(Me.lbl_VacaAddDays)
        Me.fra_Vacation.Controls.Add(Me.tbox_VacaStart)
        Me.fra_Vacation.Controls.Add(Me.tbox_VacaWaitPeriod)
        Me.fra_Vacation.Controls.Add(Me.lbl_VacaYears)
        Me.fra_Vacation.Controls.Add(Me.lbl_VacaStart)
        Me.fra_Vacation.Controls.Add(Me.lbl_VacaWaitPeriod)
        Me.fra_Vacation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fra_Vacation.ForeColor = System.Drawing.Color.DarkGreen
        Me.fra_Vacation.Location = New System.Drawing.Point(16, 140)
        Me.fra_Vacation.Name = "fra_Vacation"
        Me.fra_Vacation.Size = New System.Drawing.Size(528, 175)
        Me.fra_Vacation.TabIndex = 105
        Me.fra_Vacation.TabStop = False
        Me.fra_Vacation.Text = "Vacation Information"
        '
        'opt_TrackYears3
        '
        Me.opt_TrackYears3.AutoSize = True
        Me.opt_TrackYears3.Enabled = False
        Me.opt_TrackYears3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opt_TrackYears3.ForeColor = System.Drawing.Color.Blue
        Me.opt_TrackYears3.Location = New System.Drawing.Point(367, 143)
        Me.opt_TrackYears3.Name = "opt_TrackYears3"
        Me.opt_TrackYears3.Size = New System.Drawing.Size(72, 19)
        Me.opt_TrackYears3.TabIndex = 113
        Me.opt_TrackYears3.TabStop = True
        Me.opt_TrackYears3.Tag = "3"
        Me.opt_TrackYears3.Text = "3   Years"
        Me.opt_TrackYears3.UseVisualStyleBackColor = True
        '
        'opt_TrackYears1
        '
        Me.opt_TrackYears1.AutoSize = True
        Me.opt_TrackYears1.Enabled = False
        Me.opt_TrackYears1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opt_TrackYears1.ForeColor = System.Drawing.Color.Blue
        Me.opt_TrackYears1.Location = New System.Drawing.Point(293, 143)
        Me.opt_TrackYears1.Name = "opt_TrackYears1"
        Me.opt_TrackYears1.Size = New System.Drawing.Size(32, 19)
        Me.opt_TrackYears1.TabIndex = 112
        Me.opt_TrackYears1.TabStop = True
        Me.opt_TrackYears1.Tag = "1"
        Me.opt_TrackYears1.Text = "1"
        Me.opt_TrackYears1.UseVisualStyleBackColor = True
        '
        'opt_TrackYears2
        '
        Me.opt_TrackYears2.AutoSize = True
        Me.opt_TrackYears2.Enabled = False
        Me.opt_TrackYears2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opt_TrackYears2.ForeColor = System.Drawing.Color.Blue
        Me.opt_TrackYears2.Location = New System.Drawing.Point(330, 143)
        Me.opt_TrackYears2.Name = "opt_TrackYears2"
        Me.opt_TrackYears2.Size = New System.Drawing.Size(32, 19)
        Me.opt_TrackYears2.TabIndex = 111
        Me.opt_TrackYears2.TabStop = True
        Me.opt_TrackYears2.Tag = "2"
        Me.opt_TrackYears2.Text = "2"
        Me.opt_TrackYears2.UseVisualStyleBackColor = True
        '
        'tbox_VacaStop
        '
        Me.tbox_VacaStop.AcceptsReturn = True
        Me.tbox_VacaStop.BackColor = System.Drawing.Color.White
        Me.tbox_VacaStop.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_VacaStop.Enabled = False
        Me.tbox_VacaStop.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_VacaStop.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbox_VacaStop.Location = New System.Drawing.Point(340, 113)
        Me.tbox_VacaStop.MaxLength = 0
        Me.tbox_VacaStop.Name = "tbox_VacaStop"
        Me.tbox_VacaStop.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbox_VacaStop.Size = New System.Drawing.Size(24, 21)
        Me.tbox_VacaStop.TabIndex = 110
        Me.tbox_VacaStop.TabStop = False
        Me.tbox_VacaStop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbl_VacaStop
        '
        Me.lbl_VacaStop.AutoSize = True
        Me.lbl_VacaStop.BackColor = System.Drawing.Color.FloralWhite
        Me.lbl_VacaStop.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_VacaStop.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_VacaStop.ForeColor = System.Drawing.Color.Blue
        Me.lbl_VacaStop.Location = New System.Drawing.Point(10, 118)
        Me.lbl_VacaStop.Name = "lbl_VacaStop"
        Me.lbl_VacaStop.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_VacaStop.Size = New System.Drawing.Size(330, 15)
        Me.lbl_VacaStop.TabIndex = 109
        Me.lbl_VacaStop.Text = "Maximum amount of vacation days a employee can receive:"
        Me.lbl_VacaStop.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbox_VacaAddDays
        '
        Me.tbox_VacaAddDays.AcceptsReturn = True
        Me.tbox_VacaAddDays.BackColor = System.Drawing.Color.White
        Me.tbox_VacaAddDays.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_VacaAddDays.Enabled = False
        Me.tbox_VacaAddDays.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_VacaAddDays.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbox_VacaAddDays.Location = New System.Drawing.Point(342, 85)
        Me.tbox_VacaAddDays.MaxLength = 0
        Me.tbox_VacaAddDays.Name = "tbox_VacaAddDays"
        Me.tbox_VacaAddDays.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbox_VacaAddDays.Size = New System.Drawing.Size(24, 21)
        Me.tbox_VacaAddDays.TabIndex = 108
        Me.tbox_VacaAddDays.TabStop = False
        Me.tbox_VacaAddDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbl_VacaAddDays
        '
        Me.lbl_VacaAddDays.AutoSize = True
        Me.lbl_VacaAddDays.BackColor = System.Drawing.Color.FloralWhite
        Me.lbl_VacaAddDays.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_VacaAddDays.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_VacaAddDays.ForeColor = System.Drawing.Color.Blue
        Me.lbl_VacaAddDays.Location = New System.Drawing.Point(10, 90)
        Me.lbl_VacaAddDays.Name = "lbl_VacaAddDays"
        Me.lbl_VacaAddDays.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_VacaAddDays.Size = New System.Drawing.Size(332, 15)
        Me.lbl_VacaAddDays.TabIndex = 107
        Me.lbl_VacaAddDays.Text = "Number of days offered with each increase in vacation time:"
        Me.lbl_VacaAddDays.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbox_VacaStart
        '
        Me.tbox_VacaStart.AcceptsReturn = True
        Me.tbox_VacaStart.BackColor = System.Drawing.Color.White
        Me.tbox_VacaStart.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_VacaStart.Enabled = False
        Me.tbox_VacaStart.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_VacaStart.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbox_VacaStart.Location = New System.Drawing.Point(335, 57)
        Me.tbox_VacaStart.MaxLength = 0
        Me.tbox_VacaStart.Name = "tbox_VacaStart"
        Me.tbox_VacaStart.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbox_VacaStart.Size = New System.Drawing.Size(24, 21)
        Me.tbox_VacaStart.TabIndex = 106
        Me.tbox_VacaStart.TabStop = False
        Me.tbox_VacaStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbox_VacaWaitPeriod
        '
        Me.tbox_VacaWaitPeriod.AcceptsReturn = True
        Me.tbox_VacaWaitPeriod.BackColor = System.Drawing.Color.White
        Me.tbox_VacaWaitPeriod.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_VacaWaitPeriod.Enabled = False
        Me.tbox_VacaWaitPeriod.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_VacaWaitPeriod.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbox_VacaWaitPeriod.Location = New System.Drawing.Point(344, 29)
        Me.tbox_VacaWaitPeriod.MaxLength = 0
        Me.tbox_VacaWaitPeriod.Name = "tbox_VacaWaitPeriod"
        Me.tbox_VacaWaitPeriod.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbox_VacaWaitPeriod.Size = New System.Drawing.Size(24, 21)
        Me.tbox_VacaWaitPeriod.TabIndex = 88
        Me.tbox_VacaWaitPeriod.TabStop = False
        Me.tbox_VacaWaitPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbl_VacaYears
        '
        Me.lbl_VacaYears.AutoSize = True
        Me.lbl_VacaYears.BackColor = System.Drawing.Color.FloralWhite
        Me.lbl_VacaYears.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_VacaYears.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_VacaYears.ForeColor = System.Drawing.Color.Blue
        Me.lbl_VacaYears.Location = New System.Drawing.Point(10, 146)
        Me.lbl_VacaYears.Name = "lbl_VacaYears"
        Me.lbl_VacaYears.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_VacaYears.Size = New System.Drawing.Size(283, 15)
        Me.lbl_VacaYears.TabIndex = 83
        Me.lbl_VacaYears.Text = "Number of years to track vacation time before loss:"
        Me.lbl_VacaYears.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_VacaStart
        '
        Me.lbl_VacaStart.AutoSize = True
        Me.lbl_VacaStart.BackColor = System.Drawing.Color.FloralWhite
        Me.lbl_VacaStart.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_VacaStart.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_VacaStart.ForeColor = System.Drawing.Color.Blue
        Me.lbl_VacaStart.Location = New System.Drawing.Point(10, 62)
        Me.lbl_VacaStart.Name = "lbl_VacaStart"
        Me.lbl_VacaStart.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_VacaStart.Size = New System.Drawing.Size(325, 15)
        Me.lbl_VacaStart.TabIndex = 81
        Me.lbl_VacaStart.Text = "Number of days offered at start of recieving paid vacations:"
        Me.lbl_VacaStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_VacaWaitPeriod
        '
        Me.lbl_VacaWaitPeriod.AutoSize = True
        Me.lbl_VacaWaitPeriod.BackColor = System.Drawing.Color.FloralWhite
        Me.lbl_VacaWaitPeriod.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_VacaWaitPeriod.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_VacaWaitPeriod.ForeColor = System.Drawing.Color.Blue
        Me.lbl_VacaWaitPeriod.Location = New System.Drawing.Point(10, 34)
        Me.lbl_VacaWaitPeriod.Name = "lbl_VacaWaitPeriod"
        Me.lbl_VacaWaitPeriod.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_VacaWaitPeriod.Size = New System.Drawing.Size(334, 15)
        Me.lbl_VacaWaitPeriod.TabIndex = 80
        Me.lbl_VacaWaitPeriod.Text = "Default number of months before paid vacation time offered:"
        Me.lbl_VacaWaitPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Images
        '
        Me.Images.BackColor = System.Drawing.Color.FloralWhite
        Me.Images.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Images.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Images.Location = New System.Drawing.Point(4, 22)
        Me.Images.Name = "Images"
        Me.Images.Padding = New System.Windows.Forms.Padding(3)
        Me.Images.Size = New System.Drawing.Size(564, 353)
        Me.Images.TabIndex = 1
        Me.Images.Text = "Images"
        '
        'Misc
        '
        Me.Misc.BackColor = System.Drawing.Color.FloralWhite
        Me.Misc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Misc.Controls.Add(Me.lbl_MsgMisc)
        Me.Misc.Controls.Add(Me.fra_Misc)
        Me.Misc.Location = New System.Drawing.Point(4, 22)
        Me.Misc.Name = "Misc"
        Me.Misc.Size = New System.Drawing.Size(564, 353)
        Me.Misc.TabIndex = 3
        Me.Misc.Text = "Misc"
        '
        'lbl_MsgMisc
        '
        Me.lbl_MsgMisc.BackColor = System.Drawing.Color.FloralWhite
        Me.lbl_MsgMisc.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_MsgMisc.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_MsgMisc.ForeColor = System.Drawing.Color.Red
        Me.lbl_MsgMisc.Location = New System.Drawing.Point(3, 327)
        Me.lbl_MsgMisc.Name = "lbl_MsgMisc"
        Me.lbl_MsgMisc.Size = New System.Drawing.Size(556, 15)
        Me.lbl_MsgMisc.TabIndex = 128
        Me.lbl_MsgMisc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'fra_Misc
        '
        Me.fra_Misc.Controls.Add(Me.cmd_Selector)
        Me.fra_Misc.Controls.Add(Me.tbox_PdfPath)
        Me.fra_Misc.Controls.Add(Me.lbl_PdfPath)
        Me.fra_Misc.Controls.Add(Me.tbox_PdfPrinterName)
        Me.fra_Misc.Controls.Add(Me.lbl_PdfPrinter)
        Me.fra_Misc.Controls.Add(Me.tbox_PrinterName)
        Me.fra_Misc.Controls.Add(Me.lbl_PrinterName)
        Me.fra_Misc.Controls.Add(Me.cmd_MiscDefaults)
        Me.fra_Misc.Controls.Add(Me.tbox_ImageHeight)
        Me.fra_Misc.Controls.Add(Me.lbl_ImageHeight)
        Me.fra_Misc.Controls.Add(Me.tbox_ImageWidth)
        Me.fra_Misc.Controls.Add(Me.lbl_ImageWidth)
        Me.fra_Misc.Controls.Add(Me.tbox_PrinterBuffer)
        Me.fra_Misc.Controls.Add(Me.tbox_BackupPath)
        Me.fra_Misc.Controls.Add(Me.lbl_PrinterBuffer)
        Me.fra_Misc.Controls.Add(Me.lbl_BackupPath)
        Me.fra_Misc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fra_Misc.ForeColor = System.Drawing.Color.DarkGreen
        Me.fra_Misc.Location = New System.Drawing.Point(16, 10)
        Me.fra_Misc.Name = "fra_Misc"
        Me.fra_Misc.Size = New System.Drawing.Size(528, 239)
        Me.fra_Misc.TabIndex = 105
        Me.fra_Misc.TabStop = False
        Me.fra_Misc.Text = "Misc Information"
        '
        'cmd_Selector
        '
        Me.cmd_Selector.BackColor = System.Drawing.Color.MintCream
        Me.cmd_Selector.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Selector.Location = New System.Drawing.Point(455, 29)
        Me.cmd_Selector.Name = "cmd_Selector"
        Me.cmd_Selector.Size = New System.Drawing.Size(60, 50)
        Me.cmd_Selector.TabIndex = 102
        Me.cmd_Selector.Text = "Path Selector"
        Me.cmd_Selector.UseVisualStyleBackColor = False
        Me.cmd_Selector.Visible = False
        '
        'tbox_PdfPath
        '
        Me.tbox_PdfPath.AcceptsReturn = True
        Me.tbox_PdfPath.BackColor = System.Drawing.Color.White
        Me.tbox_PdfPath.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_PdfPath.Enabled = False
        Me.tbox_PdfPath.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_PdfPath.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbox_PdfPath.Location = New System.Drawing.Point(149, 85)
        Me.tbox_PdfPath.MaxLength = 0
        Me.tbox_PdfPath.Name = "tbox_PdfPath"
        Me.tbox_PdfPath.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbox_PdfPath.Size = New System.Drawing.Size(365, 21)
        Me.tbox_PdfPath.TabIndex = 101
        Me.tbox_PdfPath.TabStop = False
        '
        'lbl_PdfPath
        '
        Me.lbl_PdfPath.AutoSize = True
        Me.lbl_PdfPath.BackColor = System.Drawing.Color.FloralWhite
        Me.lbl_PdfPath.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_PdfPath.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_PdfPath.ForeColor = System.Drawing.Color.Blue
        Me.lbl_PdfPath.Location = New System.Drawing.Point(10, 90)
        Me.lbl_PdfPath.Name = "lbl_PdfPath"
        Me.lbl_PdfPath.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_PdfPath.Size = New System.Drawing.Size(139, 15)
        Me.lbl_PdfPath.TabIndex = 100
        Me.lbl_PdfPath.Text = "Default path for pdf files:"
        Me.lbl_PdfPath.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbox_PdfPrinterName
        '
        Me.tbox_PdfPrinterName.AcceptsReturn = True
        Me.tbox_PdfPrinterName.BackColor = System.Drawing.Color.White
        Me.tbox_PdfPrinterName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_PdfPrinterName.Enabled = False
        Me.tbox_PdfPrinterName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_PdfPrinterName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbox_PdfPrinterName.Location = New System.Drawing.Point(202, 57)
        Me.tbox_PdfPrinterName.MaxLength = 0
        Me.tbox_PdfPrinterName.Name = "tbox_PdfPrinterName"
        Me.tbox_PdfPrinterName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbox_PdfPrinterName.Size = New System.Drawing.Size(243, 21)
        Me.tbox_PdfPrinterName.TabIndex = 98
        Me.tbox_PdfPrinterName.TabStop = False
        '
        'lbl_PdfPrinter
        '
        Me.lbl_PdfPrinter.AutoSize = True
        Me.lbl_PdfPrinter.BackColor = System.Drawing.Color.FloralWhite
        Me.lbl_PdfPrinter.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_PdfPrinter.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_PdfPrinter.ForeColor = System.Drawing.Color.Blue
        Me.lbl_PdfPrinter.Location = New System.Drawing.Point(10, 62)
        Me.lbl_PdfPrinter.Name = "lbl_PdfPrinter"
        Me.lbl_PdfPrinter.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_PdfPrinter.Size = New System.Drawing.Size(192, 15)
        Me.lbl_PdfPrinter.TabIndex = 97
        Me.lbl_PdfPrinter.Text = "Default system PDF printer name:"
        Me.lbl_PdfPrinter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbox_PrinterName
        '
        Me.tbox_PrinterName.AcceptsReturn = True
        Me.tbox_PrinterName.BackColor = System.Drawing.Color.White
        Me.tbox_PrinterName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_PrinterName.Enabled = False
        Me.tbox_PrinterName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_PrinterName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbox_PrinterName.Location = New System.Drawing.Point(175, 29)
        Me.tbox_PrinterName.MaxLength = 0
        Me.tbox_PrinterName.Name = "tbox_PrinterName"
        Me.tbox_PrinterName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbox_PrinterName.Size = New System.Drawing.Size(270, 21)
        Me.tbox_PrinterName.TabIndex = 96
        Me.tbox_PrinterName.TabStop = False
        '
        'lbl_PrinterName
        '
        Me.lbl_PrinterName.AutoSize = True
        Me.lbl_PrinterName.BackColor = System.Drawing.Color.FloralWhite
        Me.lbl_PrinterName.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_PrinterName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_PrinterName.ForeColor = System.Drawing.Color.Blue
        Me.lbl_PrinterName.Location = New System.Drawing.Point(10, 34)
        Me.lbl_PrinterName.Name = "lbl_PrinterName"
        Me.lbl_PrinterName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_PrinterName.Size = New System.Drawing.Size(165, 15)
        Me.lbl_PrinterName.TabIndex = 95
        Me.lbl_PrinterName.Text = "Default system printer name:"
        Me.lbl_PrinterName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmd_MiscDefaults
        '
        Me.cmd_MiscDefaults.BackColor = System.Drawing.Color.MintCream
        Me.cmd_MiscDefaults.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmd_MiscDefaults.Enabled = False
        Me.cmd_MiscDefaults.Location = New System.Drawing.Point(455, 198)
        Me.cmd_MiscDefaults.Name = "cmd_MiscDefaults"
        Me.cmd_MiscDefaults.Size = New System.Drawing.Size(60, 25)
        Me.cmd_MiscDefaults.TabIndex = 94
        Me.cmd_MiscDefaults.Text = "Defaults"
        Me.cmd_MiscDefaults.UseVisualStyleBackColor = False
        '
        'tbox_ImageHeight
        '
        Me.tbox_ImageHeight.AcceptsReturn = True
        Me.tbox_ImageHeight.BackColor = System.Drawing.Color.White
        Me.tbox_ImageHeight.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_ImageHeight.Enabled = False
        Me.tbox_ImageHeight.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_ImageHeight.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbox_ImageHeight.Location = New System.Drawing.Point(124, 197)
        Me.tbox_ImageHeight.MaxLength = 0
        Me.tbox_ImageHeight.Name = "tbox_ImageHeight"
        Me.tbox_ImageHeight.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbox_ImageHeight.Size = New System.Drawing.Size(35, 21)
        Me.tbox_ImageHeight.TabIndex = 93
        Me.tbox_ImageHeight.TabStop = False
        Me.tbox_ImageHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbl_ImageHeight
        '
        Me.lbl_ImageHeight.AutoSize = True
        Me.lbl_ImageHeight.BackColor = System.Drawing.Color.FloralWhite
        Me.lbl_ImageHeight.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_ImageHeight.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ImageHeight.ForeColor = System.Drawing.Color.Blue
        Me.lbl_ImageHeight.Location = New System.Drawing.Point(10, 202)
        Me.lbl_ImageHeight.Name = "lbl_ImageHeight"
        Me.lbl_ImageHeight.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_ImageHeight.Size = New System.Drawing.Size(114, 15)
        Me.lbl_ImageHeight.TabIndex = 92
        Me.lbl_ImageHeight.Text = "Form image height:"
        Me.lbl_ImageHeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbox_ImageWidth
        '
        Me.tbox_ImageWidth.AcceptsReturn = True
        Me.tbox_ImageWidth.BackColor = System.Drawing.Color.White
        Me.tbox_ImageWidth.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_ImageWidth.Enabled = False
        Me.tbox_ImageWidth.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_ImageWidth.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbox_ImageWidth.Location = New System.Drawing.Point(119, 169)
        Me.tbox_ImageWidth.MaxLength = 0
        Me.tbox_ImageWidth.Name = "tbox_ImageWidth"
        Me.tbox_ImageWidth.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbox_ImageWidth.Size = New System.Drawing.Size(35, 21)
        Me.tbox_ImageWidth.TabIndex = 91
        Me.tbox_ImageWidth.TabStop = False
        Me.tbox_ImageWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbl_ImageWidth
        '
        Me.lbl_ImageWidth.AutoSize = True
        Me.lbl_ImageWidth.BackColor = System.Drawing.Color.FloralWhite
        Me.lbl_ImageWidth.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_ImageWidth.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ImageWidth.ForeColor = System.Drawing.Color.Blue
        Me.lbl_ImageWidth.Location = New System.Drawing.Point(10, 174)
        Me.lbl_ImageWidth.Name = "lbl_ImageWidth"
        Me.lbl_ImageWidth.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_ImageWidth.Size = New System.Drawing.Size(109, 15)
        Me.lbl_ImageWidth.TabIndex = 90
        Me.lbl_ImageWidth.Text = "Form image width:"
        Me.lbl_ImageWidth.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbox_PrinterBuffer
        '
        Me.tbox_PrinterBuffer.AcceptsReturn = True
        Me.tbox_PrinterBuffer.BackColor = System.Drawing.Color.White
        Me.tbox_PrinterBuffer.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_PrinterBuffer.Enabled = False
        Me.tbox_PrinterBuffer.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_PrinterBuffer.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbox_PrinterBuffer.Location = New System.Drawing.Point(263, 141)
        Me.tbox_PrinterBuffer.MaxLength = 0
        Me.tbox_PrinterBuffer.Name = "tbox_PrinterBuffer"
        Me.tbox_PrinterBuffer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbox_PrinterBuffer.Size = New System.Drawing.Size(24, 21)
        Me.tbox_PrinterBuffer.TabIndex = 89
        Me.tbox_PrinterBuffer.TabStop = False
        Me.tbox_PrinterBuffer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbox_BackupPath
        '
        Me.tbox_BackupPath.AcceptsReturn = True
        Me.tbox_BackupPath.BackColor = System.Drawing.Color.White
        Me.tbox_BackupPath.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_BackupPath.Enabled = False
        Me.tbox_BackupPath.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_BackupPath.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbox_BackupPath.Location = New System.Drawing.Point(189, 113)
        Me.tbox_BackupPath.MaxLength = 0
        Me.tbox_BackupPath.Name = "tbox_BackupPath"
        Me.tbox_BackupPath.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbox_BackupPath.Size = New System.Drawing.Size(326, 21)
        Me.tbox_BackupPath.TabIndex = 88
        Me.tbox_BackupPath.TabStop = False
        '
        'lbl_PrinterBuffer
        '
        Me.lbl_PrinterBuffer.AutoSize = True
        Me.lbl_PrinterBuffer.BackColor = System.Drawing.Color.FloralWhite
        Me.lbl_PrinterBuffer.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_PrinterBuffer.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_PrinterBuffer.ForeColor = System.Drawing.Color.Blue
        Me.lbl_PrinterBuffer.Location = New System.Drawing.Point(10, 146)
        Me.lbl_PrinterBuffer.Name = "lbl_PrinterBuffer"
        Me.lbl_PrinterBuffer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_PrinterBuffer.Size = New System.Drawing.Size(253, 15)
        Me.lbl_PrinterBuffer.TabIndex = 81
        Me.lbl_PrinterBuffer.Text = "Printer buffer used to center printing on page:"
        Me.lbl_PrinterBuffer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_BackupPath
        '
        Me.lbl_BackupPath.AutoSize = True
        Me.lbl_BackupPath.BackColor = System.Drawing.Color.FloralWhite
        Me.lbl_BackupPath.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_BackupPath.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_BackupPath.ForeColor = System.Drawing.Color.Blue
        Me.lbl_BackupPath.Location = New System.Drawing.Point(10, 118)
        Me.lbl_BackupPath.Name = "lbl_BackupPath"
        Me.lbl_BackupPath.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_BackupPath.Size = New System.Drawing.Size(179, 15)
        Me.lbl_BackupPath.TabIndex = 80
        Me.lbl_BackupPath.Text = "Default path for system backup:"
        Me.lbl_BackupPath.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmd_EditCancel
        '
        Me.cmd_EditCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmd_EditCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmd_EditCancel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_EditCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmd_EditCancel.Image = Global.Machine_Shop.My.Resources.Resources.Edit
        Me.cmd_EditCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_EditCancel.Location = New System.Drawing.Point(298, 403)
        Me.cmd_EditCancel.Name = "cmd_EditCancel"
        Me.cmd_EditCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmd_EditCancel.Size = New System.Drawing.Size(74, 55)
        Me.cmd_EditCancel.TabIndex = 80
        Me.cmd_EditCancel.Text = "Edit"
        Me.cmd_EditCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmd_EditCancel.UseVisualStyleBackColor = False
        '
        'cmd_Restore
        '
        Me.cmd_Restore.BackColor = System.Drawing.SystemColors.Control
        Me.cmd_Restore.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmd_Restore.Enabled = False
        Me.cmd_Restore.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Restore.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmd_Restore.Image = Global.Machine_Shop.My.Resources.Resources.Restore
        Me.cmd_Restore.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_Restore.Location = New System.Drawing.Point(390, 403)
        Me.cmd_Restore.Name = "cmd_Restore"
        Me.cmd_Restore.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmd_Restore.Size = New System.Drawing.Size(74, 55)
        Me.cmd_Restore.TabIndex = 81
        Me.cmd_Restore.Text = "Restore"
        Me.cmd_Restore.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmd_Restore.UseVisualStyleBackColor = False
        '
        'cmd_ExitSave
        '
        Me.cmd_ExitSave.BackColor = System.Drawing.SystemColors.Control
        Me.cmd_ExitSave.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmd_ExitSave.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_ExitSave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmd_ExitSave.Image = Global.Machine_Shop.My.Resources.Resources._Exit
        Me.cmd_ExitSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_ExitSave.Location = New System.Drawing.Point(482, 403)
        Me.cmd_ExitSave.Name = "cmd_ExitSave"
        Me.cmd_ExitSave.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmd_ExitSave.Size = New System.Drawing.Size(74, 55)
        Me.cmd_ExitSave.TabIndex = 102
        Me.cmd_ExitSave.TabStop = False
        Me.cmd_ExitSave.Text = "Exit"
        Me.cmd_ExitSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmd_ExitSave.UseVisualStyleBackColor = False
        '
        'frm_SystemSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(605, 470)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmd_ExitSave)
        Me.Controls.Add(Me.cmd_Restore)
        Me.Controls.Add(Me.cmd_EditCancel)
        Me.Controls.Add(Me.TabControl)
        Me.ForeColor = System.Drawing.Color.Maroon
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_SystemSetup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "System Setup                    "
        Me.TabControl.ResumeLayout(False)
        Me.General.ResumeLayout(False)
        Me.fra_General.ResumeLayout(False)
        Me.fra_General.PerformLayout()
        Me.fra_CompanyInfo.ResumeLayout(False)
        Me.fra_CompanyInfo.PerformLayout()
        Me.Invoice.ResumeLayout(False)
        Me.fra_CertificateCompliance.ResumeLayout(False)
        Me.fra_CertificateCompliance.PerformLayout()
        Me.fra_InvoicePacking.ResumeLayout(False)
        Me.fra_InvoicePacking.PerformLayout()
        Me.Checkbook.ResumeLayout(False)
        Me.fra_Checkbook.ResumeLayout(False)
        Me.fra_CheckbookInfo.ResumeLayout(False)
        Me.fra_CheckbookInfo.PerformLayout()
        Me.TaxCategory.ResumeLayout(False)
        Me.fra_TaxCategorys.ResumeLayout(False)
        Me.fra_TaxCategorys.PerformLayout()
        Me.Vacations.ResumeLayout(False)
        Me.fra_Payroll.ResumeLayout(False)
        Me.fra_Payroll.PerformLayout()
        Me.fra_Vacation.ResumeLayout(False)
        Me.fra_Vacation.PerformLayout()
        Me.Misc.ResumeLayout(False)
        Me.fra_Misc.ResumeLayout(False)
        Me.fra_Misc.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl As System.Windows.Forms.TabControl
    Friend WithEvents Images As System.Windows.Forms.TabPage
    Friend WithEvents Invoice As System.Windows.Forms.TabPage
    Public WithEvents cmd_EditCancel As System.Windows.Forms.Button
    Public WithEvents cmd_Restore As System.Windows.Forms.Button
    Public WithEvents cmd_ExitSave As System.Windows.Forms.Button
    Friend WithEvents Misc As System.Windows.Forms.TabPage
    Friend WithEvents fra_InvoicePacking As System.Windows.Forms.GroupBox
    Public WithEvents tbox_LastInvoice As System.Windows.Forms.TextBox
    Public WithEvents tbox_DueDays As System.Windows.Forms.TextBox
    Public WithEvents tbox_Terms As System.Windows.Forms.TextBox
    Public WithEvents tbox_ShipVia As System.Windows.Forms.TextBox
    Public WithEvents lbl_LastInvoice As System.Windows.Forms.Label
    Public WithEvents lbl_DueDays As System.Windows.Forms.Label
    Public WithEvents lbl_DiscountPercent As System.Windows.Forms.Label
    Public WithEvents lbl_DiscountDays As System.Windows.Forms.Label
    Public WithEvents lbl_Terms As System.Windows.Forms.Label
    Public WithEvents lbl_ShipVia As System.Windows.Forms.Label
    Friend WithEvents fra_CertificateCompliance As System.Windows.Forms.GroupBox
    Public WithEvents tbox_SecondaryAgent As System.Windows.Forms.TextBox
    Public WithEvents lbl_SecondaryAgent As System.Windows.Forms.Label
    Public WithEvents tbox_PrimaryAgent As System.Windows.Forms.TextBox
    Public WithEvents lbl_PrimaryAgent As System.Windows.Forms.Label
    Public WithEvents lbl_Percent As System.Windows.Forms.Label
    Public WithEvents tbox_DiscountPercent As System.Windows.Forms.TextBox
    Public WithEvents tbox_DiscountDays As System.Windows.Forms.TextBox
    Friend WithEvents fra_Misc As System.Windows.Forms.GroupBox
    Public WithEvents tbox_PrinterBuffer As System.Windows.Forms.TextBox
    Public WithEvents tbox_BackupPath As System.Windows.Forms.TextBox
    Public WithEvents lbl_PrinterBuffer As System.Windows.Forms.Label
    Public WithEvents lbl_BackupPath As System.Windows.Forms.Label
    Friend WithEvents Vacations As System.Windows.Forms.TabPage
    Friend WithEvents fra_Vacation As System.Windows.Forms.GroupBox
    Public WithEvents tbox_VacaStop As System.Windows.Forms.TextBox
    Public WithEvents lbl_VacaStop As System.Windows.Forms.Label
    Public WithEvents tbox_VacaAddDays As System.Windows.Forms.TextBox
    Public WithEvents lbl_VacaAddDays As System.Windows.Forms.Label
    Public WithEvents tbox_VacaStart As System.Windows.Forms.TextBox
    Public WithEvents tbox_VacaWaitPeriod As System.Windows.Forms.TextBox
    Public WithEvents lbl_VacaYears As System.Windows.Forms.Label
    Public WithEvents lbl_VacaStart As System.Windows.Forms.Label
    Public WithEvents lbl_VacaWaitPeriod As System.Windows.Forms.Label
    Friend WithEvents Checkbook As System.Windows.Forms.TabPage
    Public WithEvents tbox_ImageHeight As System.Windows.Forms.TextBox
    Public WithEvents lbl_ImageHeight As System.Windows.Forms.Label
    Public WithEvents tbox_ImageWidth As System.Windows.Forms.TextBox
    Public WithEvents lbl_ImageWidth As System.Windows.Forms.Label
    Friend WithEvents cbx_ReInvoice As System.Windows.Forms.CheckBox
    Friend WithEvents opt_TrackYears3 As System.Windows.Forms.RadioButton
    Friend WithEvents opt_TrackYears1 As System.Windows.Forms.RadioButton
    Friend WithEvents opt_TrackYears2 As System.Windows.Forms.RadioButton
    Friend WithEvents fra_Payroll As System.Windows.Forms.GroupBox
    Public WithEvents tbox_SocSecPercent As System.Windows.Forms.TextBox
    Public WithEvents tbox_SocSecBaseLimit As System.Windows.Forms.TextBox
    Public WithEvents lbl_SocSecPercent As System.Windows.Forms.Label
    Public WithEvents lbl_SocSecBaseLimit As System.Windows.Forms.Label
    Public WithEvents tbox_MedicarePercent As System.Windows.Forms.TextBox
    Public WithEvents lbl_MedicarePercent As System.Windows.Forms.Label
    Friend WithEvents TaxCategory As System.Windows.Forms.TabPage
    Friend WithEvents fra_TaxCategorys As System.Windows.Forms.GroupBox
    Public WithEvents Label10 As System.Windows.Forms.Label
    Public WithEvents Label11 As System.Windows.Forms.Label
    Public WithEvents Label12 As System.Windows.Forms.Label
    Public WithEvents Label13 As System.Windows.Forms.Label
    Public WithEvents Label14 As System.Windows.Forms.Label
    Public WithEvents Label15 As System.Windows.Forms.Label
    Public WithEvents Label16 As System.Windows.Forms.Label
    Public WithEvents Label17 As System.Windows.Forms.Label
    Public WithEvents Label18 As System.Windows.Forms.Label
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmd_CategoryDefaults As System.Windows.Forms.Button
    Public WithEvents lbl_MsgTaxCategory As System.Windows.Forms.Label
    Public WithEvents lbl_MsgInvoice As System.Windows.Forms.Label
    Friend WithEvents General As System.Windows.Forms.TabPage
    Friend WithEvents fra_General As System.Windows.Forms.GroupBox
    Friend WithEvents fra_CompanyInfo As System.Windows.Forms.GroupBox
    Public WithEvents tbox_CompanyZipCode As System.Windows.Forms.MaskedTextBox
    Public WithEvents tbox_CompanyPhone As System.Windows.Forms.MaskedTextBox
    Public WithEvents tbox_CompanyWebsite As System.Windows.Forms.TextBox
    Public WithEvents tbox_CompanyEmail As System.Windows.Forms.TextBox
    Public WithEvents tbox_CompanyState As System.Windows.Forms.TextBox
    Public WithEvents tbox_CompanyCity As System.Windows.Forms.TextBox
    Public WithEvents tbox_CompanyAddress As System.Windows.Forms.TextBox
    Public WithEvents tbox_CompanyRep As System.Windows.Forms.TextBox
    Public WithEvents lbl_CompanyWebsite As System.Windows.Forms.Label
    Public WithEvents lbl_CompanyEmail As System.Windows.Forms.Label
    Public WithEvents lbl_CompanyPhone As System.Windows.Forms.Label
    Public WithEvents lbl_CompanyZipCode As System.Windows.Forms.Label
    Public WithEvents lbl_CompanyState As System.Windows.Forms.Label
    Public WithEvents lbl_CompanyCity As System.Windows.Forms.Label
    Public WithEvents lbl_CompanyAddress As System.Windows.Forms.Label
    Public WithEvents lbl_CompanyRep As System.Windows.Forms.Label
    Public WithEvents tbox_CompanyName As System.Windows.Forms.TextBox
    Public WithEvents lbl_CompanyName As System.Windows.Forms.Label
    Public WithEvents cmd_ClearSystem As System.Windows.Forms.Button
    Public WithEvents opt_SetupLogonYes As System.Windows.Forms.RadioButton
    Public WithEvents opt_SetupLogonNo As System.Windows.Forms.RadioButton
    Public WithEvents lbl_SecureLogon As System.Windows.Forms.Label
    Public WithEvents lbl_MsgGeneral As System.Windows.Forms.Label
    Friend WithEvents fra_Checkbook As System.Windows.Forms.GroupBox
    Public WithEvents lbl_MsgCheckbook As System.Windows.Forms.Label
    Friend WithEvents fra_CheckbookInfo As System.Windows.Forms.GroupBox
    Public WithEvents tbox_ReconcileDate As System.Windows.Forms.MaskedTextBox
    Public WithEvents tbox_ReconcileBalance As System.Windows.Forms.TextBox
    Public WithEvents tbox_LastCheck As System.Windows.Forms.TextBox
    Public WithEvents lbl_ReconcileBalance As System.Windows.Forms.Label
    Public WithEvents lbl_ReconcileDate As System.Windows.Forms.Label
    Public WithEvents lbl_LastCheck As System.Windows.Forms.Label
    Public WithEvents lbl_MsgPayRoll As System.Windows.Forms.Label
    Friend WithEvents cmd_MiscDefaults As System.Windows.Forms.Button
    Public WithEvents lbl_MsgMisc As System.Windows.Forms.Label
    Friend WithEvents lbl_ClearSystem As System.Windows.Forms.Label
    Friend WithEvents tbox_ClearSystem As System.Windows.Forms.TextBox
    Public WithEvents tbox_PrinterName As System.Windows.Forms.TextBox
    Public WithEvents lbl_PrinterName As System.Windows.Forms.Label
    Public WithEvents Label19 As Label
    Public WithEvents tbox_StartBalance As TextBox
    Friend WithEvents label_CheckbookBalance As System.Windows.Forms.Label
    Friend WithEvents cmd_ReCalculate As System.Windows.Forms.Button
    Friend WithEvents lbl_CheckbookBalance As System.Windows.Forms.Label
    Friend WithEvents lbl_Progress As System.Windows.Forms.Label
    Public WithEvents tbox_PdfPrinterName As TextBox
    Public WithEvents lbl_PdfPrinter As Label
    Public WithEvents tbox_PdfPath As System.Windows.Forms.TextBox
    Public WithEvents lbl_PdfPath As System.Windows.Forms.Label
    Friend WithEvents cmd_Selector As System.Windows.Forms.Button
End Class
