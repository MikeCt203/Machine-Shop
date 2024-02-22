<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Payroll
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
        Me.fra_SocSecurityLimits = New System.Windows.Forms.GroupBox()
        Me.cmd_Action1 = New System.Windows.Forms.Button()
        Me.tbox_MedicarePercent = New System.Windows.Forms.TextBox()
        Me.tbox_SocSecPercent = New System.Windows.Forms.TextBox()
        Me.tbox_SocSecWageLimit = New System.Windows.Forms.TextBox()
        Me.label_MedicarePercent = New System.Windows.Forms.Label()
        Me.label_SocSecPercent = New System.Windows.Forms.Label()
        Me.label_SocSecLimit = New System.Windows.Forms.Label()
        Me.fra_PrintPaychecks = New System.Windows.Forms.GroupBox()
        Me.cmd_PrintIndividual = New System.Windows.Forms.Button()
        Me.cmd_PrintAll = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.tbox_PayCheckDate = New System.Windows.Forms.MaskedTextBox()
        Me.Label_PayCheckDate = New System.Windows.Forms.Label()
        Me.fra_ContactInfo = New System.Windows.Forms.GroupBox()
        Me.lbl_Address = New System.Windows.Forms.Label()
        Me.lbl_State = New System.Windows.Forms.Label()
        Me.lbl_City = New System.Windows.Forms.Label()
        Me.lbl_Email = New System.Windows.Forms.Label()
        Me.lbl_ZipCode = New System.Windows.Forms.Label()
        Me.lbl_Emergency = New System.Windows.Forms.Label()
        Me.lbl_Phone = New System.Windows.Forms.Label()
        Me.label_Emergency = New System.Windows.Forms.Label()
        Me.label_State = New System.Windows.Forms.Label()
        Me.label_EMail = New System.Windows.Forms.Label()
        Me.label_Phone = New System.Windows.Forms.Label()
        Me.label_ZipCode = New System.Windows.Forms.Label()
        Me.label_City = New System.Windows.Forms.Label()
        Me.label_Address = New System.Windows.Forms.Label()
        Me.fra_List = New System.Windows.Forms.GroupBox()
        Me.lbl_Listbox = New System.Windows.Forms.Label()
        Me.fra_Listbox1 = New System.Windows.Forms.GroupBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.opt_NonActive = New System.Windows.Forms.RadioButton()
        Me.opt_Active = New System.Windows.Forms.RadioButton()
        Me.fra_Contacts = New System.Windows.Forms.GroupBox()
        Me.lbl_SocSecurity = New System.Windows.Forms.Label()
        Me.lbl_FirstName = New System.Windows.Forms.Label()
        Me.lbl_LastName = New System.Windows.Forms.Label()
        Me.lbl_BirthDate = New System.Windows.Forms.Label()
        Me.cbx_Active = New System.Windows.Forms.CheckBox()
        Me.Label_ID = New System.Windows.Forms.Label()
        Me.lbl_ID = New System.Windows.Forms.Label()
        Me.label_SocSecurity = New System.Windows.Forms.Label()
        Me.label_Active = New System.Windows.Forms.Label()
        Me.label_Lastname = New System.Windows.Forms.Label()
        Me.label_FirstName = New System.Windows.Forms.Label()
        Me.label_BirthDate = New System.Windows.Forms.Label()
        Me.lbl_Message = New System.Windows.Forms.Label()
        Me.fra_Income = New System.Windows.Forms.GroupBox()
        Me.cmd_Action0 = New System.Windows.Forms.Button()
        Me.lbl_VacaYear3 = New System.Windows.Forms.Label()
        Me.lbl_VacaYear2 = New System.Windows.Forms.Label()
        Me.lbl_VacaYear1 = New System.Windows.Forms.Label()
        Me.lbl_VacaUsed1 = New System.Windows.Forms.Label()
        Me.lbl_VacaUsed2 = New System.Windows.Forms.Label()
        Me.lbl_VacaUsed3 = New System.Windows.Forms.Label()
        Me.lbl_VacaIssued3 = New System.Windows.Forms.Label()
        Me.lbl_VacaIssued2 = New System.Windows.Forms.Label()
        Me.lbl_VacaIssued1 = New System.Windows.Forms.Label()
        Me.Label_DaysUsed = New System.Windows.Forms.Label()
        Me.Label_DaysIssued = New System.Windows.Forms.Label()
        Me.Label_VacationData = New System.Windows.Forms.Label()
        Me.Label_Year = New System.Windows.Forms.Label()
        Me.cmd_ClearAdjustments = New System.Windows.Forms.Button()
        Me.label_Adjusted = New System.Windows.Forms.Label()
        Me.label_Original = New System.Windows.Forms.Label()
        Me.lbl_WeekSocSecurityTemp = New System.Windows.Forms.Label()
        Me.lbl_WeekSocSecurity = New System.Windows.Forms.Label()
        Me.lbl_WeekMisc = New System.Windows.Forms.Label()
        Me.lbl_WeekHours = New System.Windows.Forms.Label()
        Me.lbl_WeekStateTax = New System.Windows.Forms.Label()
        Me.lbl_WeekFedTax = New System.Windows.Forms.Label()
        Me.lbl_Salary = New System.Windows.Forms.Label()
        Me.lbl_YearMisc = New System.Windows.Forms.Label()
        Me.lbl_YearSocSecurity = New System.Windows.Forms.Label()
        Me.lbl_YearStateTax = New System.Windows.Forms.Label()
        Me.lbl_YearFederalTax = New System.Windows.Forms.Label()
        Me.lbl_YearEarnings = New System.Windows.Forms.Label()
        Me.label_YearMisc = New System.Windows.Forms.Label()
        Me.label_YearSocSecurity = New System.Windows.Forms.Label()
        Me.label_YearStateTax = New System.Windows.Forms.Label()
        Me.label_YearFederalTax = New System.Windows.Forms.Label()
        Me.label_YearEarnings = New System.Windows.Forms.Label()
        Me.label_PaycheckTotals = New System.Windows.Forms.Label()
        Me.tbox_WeekMiscTemp = New System.Windows.Forms.TextBox()
        Me.tbox_WeekStateTaxTemp = New System.Windows.Forms.TextBox()
        Me.tbox_WeekFedTaxTemp = New System.Windows.Forms.TextBox()
        Me.tbox_SalaryTemp = New System.Windows.Forms.TextBox()
        Me.label_SocialSecurity = New System.Windows.Forms.Label()
        Me.tbox_WeekHoursTemp = New System.Windows.Forms.TextBox()
        Me.label_MiscFunds = New System.Windows.Forms.Label()
        Me.label_StateTax = New System.Windows.Forms.Label()
        Me.label_FederalTax = New System.Windows.Forms.Label()
        Me.label_Hours = New System.Windows.Forms.Label()
        Me.label_Salary = New System.Windows.Forms.Label()
        Me.cmd_Action3 = New System.Windows.Forms.Button()
        Me.cmd_Action2 = New System.Windows.Forms.Button()
        Me.fra_SocSecurityLimits.SuspendLayout()
        Me.fra_PrintPaychecks.SuspendLayout()
        Me.fra_ContactInfo.SuspendLayout()
        Me.fra_List.SuspendLayout()
        Me.fra_Listbox1.SuspendLayout()
        Me.fra_Contacts.SuspendLayout()
        Me.fra_Income.SuspendLayout()
        Me.SuspendLayout()
        '
        'fra_SocSecurityLimits
        '
        Me.fra_SocSecurityLimits.BackColor = System.Drawing.SystemColors.Control
        Me.fra_SocSecurityLimits.Controls.Add(Me.cmd_Action1)
        Me.fra_SocSecurityLimits.Controls.Add(Me.tbox_MedicarePercent)
        Me.fra_SocSecurityLimits.Controls.Add(Me.tbox_SocSecPercent)
        Me.fra_SocSecurityLimits.Controls.Add(Me.tbox_SocSecWageLimit)
        Me.fra_SocSecurityLimits.Controls.Add(Me.label_MedicarePercent)
        Me.fra_SocSecurityLimits.Controls.Add(Me.label_SocSecPercent)
        Me.fra_SocSecurityLimits.Controls.Add(Me.label_SocSecLimit)
        Me.fra_SocSecurityLimits.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.fra_SocSecurityLimits.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.fra_SocSecurityLimits.Location = New System.Drawing.Point(575, 15)
        Me.fra_SocSecurityLimits.Name = "fra_SocSecurityLimits"
        Me.fra_SocSecurityLimits.Padding = New System.Windows.Forms.Padding(0)
        Me.fra_SocSecurityLimits.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fra_SocSecurityLimits.Size = New System.Drawing.Size(310, 140)
        Me.fra_SocSecurityLimits.TabIndex = 110
        Me.fra_SocSecurityLimits.TabStop = False
        Me.fra_SocSecurityLimits.Text = "Social Security Limits"
        '
        'cmd_Action1
        '
        Me.cmd_Action1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_Action1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Action1.Image = Global.Machine_Shop.My.Resources.Resources.Edit_2
        Me.cmd_Action1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_Action1.Location = New System.Drawing.Point(242, 67)
        Me.cmd_Action1.Margin = New System.Windows.Forms.Padding(2)
        Me.cmd_Action1.Name = "cmd_Action1"
        Me.cmd_Action1.Size = New System.Drawing.Size(53, 47)
        Me.cmd_Action1.TabIndex = 93
        Me.cmd_Action1.Tag = "1"
        Me.cmd_Action1.Text = "Edit"
        Me.cmd_Action1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmd_Action1.UseVisualStyleBackColor = True
        '
        'tbox_MedicarePercent
        '
        Me.tbox_MedicarePercent.AcceptsReturn = True
        Me.tbox_MedicarePercent.BackColor = System.Drawing.Color.White
        Me.tbox_MedicarePercent.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_MedicarePercent.Enabled = False
        Me.tbox_MedicarePercent.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_MedicarePercent.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbox_MedicarePercent.Location = New System.Drawing.Point(195, 97)
        Me.tbox_MedicarePercent.MaxLength = 0
        Me.tbox_MedicarePercent.Name = "tbox_MedicarePercent"
        Me.tbox_MedicarePercent.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbox_MedicarePercent.Size = New System.Drawing.Size(40, 20)
        Me.tbox_MedicarePercent.TabIndex = 92
        '
        'tbox_SocSecPercent
        '
        Me.tbox_SocSecPercent.AcceptsReturn = True
        Me.tbox_SocSecPercent.BackColor = System.Drawing.Color.White
        Me.tbox_SocSecPercent.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_SocSecPercent.Enabled = False
        Me.tbox_SocSecPercent.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_SocSecPercent.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbox_SocSecPercent.Location = New System.Drawing.Point(195, 67)
        Me.tbox_SocSecPercent.MaxLength = 0
        Me.tbox_SocSecPercent.Name = "tbox_SocSecPercent"
        Me.tbox_SocSecPercent.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbox_SocSecPercent.Size = New System.Drawing.Size(40, 20)
        Me.tbox_SocSecPercent.TabIndex = 91
        '
        'tbox_SocSecWageLimit
        '
        Me.tbox_SocSecWageLimit.AcceptsReturn = True
        Me.tbox_SocSecWageLimit.BackColor = System.Drawing.Color.White
        Me.tbox_SocSecWageLimit.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_SocSecWageLimit.Enabled = False
        Me.tbox_SocSecWageLimit.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_SocSecWageLimit.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbox_SocSecWageLimit.Location = New System.Drawing.Point(195, 38)
        Me.tbox_SocSecWageLimit.MaxLength = 0
        Me.tbox_SocSecWageLimit.Name = "tbox_SocSecWageLimit"
        Me.tbox_SocSecWageLimit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbox_SocSecWageLimit.Size = New System.Drawing.Size(101, 20)
        Me.tbox_SocSecWageLimit.TabIndex = 89
        '
        'label_MedicarePercent
        '
        Me.label_MedicarePercent.BackColor = System.Drawing.SystemColors.Control
        Me.label_MedicarePercent.Cursor = System.Windows.Forms.Cursors.Default
        Me.label_MedicarePercent.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_MedicarePercent.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.label_MedicarePercent.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.label_MedicarePercent.Location = New System.Drawing.Point(9, 100)
        Me.label_MedicarePercent.Name = "label_MedicarePercent"
        Me.label_MedicarePercent.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label_MedicarePercent.Size = New System.Drawing.Size(184, 16)
        Me.label_MedicarePercent.TabIndex = 77
        Me.label_MedicarePercent.Text = "Medicare Tax Percentage:"
        Me.label_MedicarePercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'label_SocSecPercent
        '
        Me.label_SocSecPercent.BackColor = System.Drawing.SystemColors.Control
        Me.label_SocSecPercent.Cursor = System.Windows.Forms.Cursors.Default
        Me.label_SocSecPercent.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_SocSecPercent.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.label_SocSecPercent.Location = New System.Drawing.Point(9, 71)
        Me.label_SocSecPercent.Name = "label_SocSecPercent"
        Me.label_SocSecPercent.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label_SocSecPercent.Size = New System.Drawing.Size(184, 14)
        Me.label_SocSecPercent.TabIndex = 74
        Me.label_SocSecPercent.Text = "Social Security Tax Percentage:"
        Me.label_SocSecPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'label_SocSecLimit
        '
        Me.label_SocSecLimit.AutoEllipsis = True
        Me.label_SocSecLimit.BackColor = System.Drawing.SystemColors.Control
        Me.label_SocSecLimit.Cursor = System.Windows.Forms.Cursors.Default
        Me.label_SocSecLimit.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_SocSecLimit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.label_SocSecLimit.Location = New System.Drawing.Point(9, 41)
        Me.label_SocSecLimit.Name = "label_SocSecLimit"
        Me.label_SocSecLimit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label_SocSecLimit.Size = New System.Drawing.Size(184, 14)
        Me.label_SocSecLimit.TabIndex = 71
        Me.label_SocSecLimit.Text = "Social Security Wage Base Limit:"
        Me.label_SocSecLimit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'fra_PrintPaychecks
        '
        Me.fra_PrintPaychecks.BackColor = System.Drawing.SystemColors.Control
        Me.fra_PrintPaychecks.Controls.Add(Me.cmd_PrintIndividual)
        Me.fra_PrintPaychecks.Controls.Add(Me.cmd_PrintAll)
        Me.fra_PrintPaychecks.Controls.Add(Me.DateTimePicker1)
        Me.fra_PrintPaychecks.Controls.Add(Me.tbox_PayCheckDate)
        Me.fra_PrintPaychecks.Controls.Add(Me.Label_PayCheckDate)
        Me.fra_PrintPaychecks.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fra_PrintPaychecks.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.fra_PrintPaychecks.Location = New System.Drawing.Point(575, 165)
        Me.fra_PrintPaychecks.Name = "fra_PrintPaychecks"
        Me.fra_PrintPaychecks.Padding = New System.Windows.Forms.Padding(0)
        Me.fra_PrintPaychecks.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fra_PrintPaychecks.Size = New System.Drawing.Size(310, 194)
        Me.fra_PrintPaychecks.TabIndex = 109
        Me.fra_PrintPaychecks.TabStop = False
        Me.fra_PrintPaychecks.Text = "Print Paychecks"
        '
        'cmd_PrintIndividual
        '
        Me.cmd_PrintIndividual.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_PrintIndividual.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_PrintIndividual.Image = Global.Machine_Shop.My.Resources.Resources.printer_2
        Me.cmd_PrintIndividual.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_PrintIndividual.Location = New System.Drawing.Point(28, 113)
        Me.cmd_PrintIndividual.Margin = New System.Windows.Forms.Padding(2)
        Me.cmd_PrintIndividual.Name = "cmd_PrintIndividual"
        Me.cmd_PrintIndividual.Size = New System.Drawing.Size(170, 52)
        Me.cmd_PrintIndividual.TabIndex = 95
        Me.cmd_PrintIndividual.Text = "Print Individual "
        Me.cmd_PrintIndividual.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_PrintIndividual.UseVisualStyleBackColor = True
        '
        'cmd_PrintAll
        '
        Me.cmd_PrintAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_PrintAll.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_PrintAll.Image = Global.Machine_Shop.My.Resources.Resources.printer_2
        Me.cmd_PrintAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_PrintAll.Location = New System.Drawing.Point(28, 46)
        Me.cmd_PrintAll.Margin = New System.Windows.Forms.Padding(2)
        Me.cmd_PrintAll.Name = "cmd_PrintAll"
        Me.cmd_PrintAll.Size = New System.Drawing.Size(170, 52)
        Me.cmd_PrintAll.TabIndex = 94
        Me.cmd_PrintAll.Text = "Print All       "
        Me.cmd_PrintAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_PrintAll.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(247, 102)
        Me.DateTimePicker1.Margin = New System.Windows.Forms.Padding(2)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(16, 22)
        Me.DateTimePicker1.TabIndex = 86
        '
        'tbox_PayCheckDate
        '
        Me.tbox_PayCheckDate.AllowPromptAsInput = False
        Me.tbox_PayCheckDate.BackColor = System.Drawing.Color.White
        Me.tbox_PayCheckDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_PayCheckDate.Location = New System.Drawing.Point(221, 75)
        Me.tbox_PayCheckDate.Mask = "00/00/0000"
        Me.tbox_PayCheckDate.Name = "tbox_PayCheckDate"
        Me.tbox_PayCheckDate.Size = New System.Drawing.Size(68, 21)
        Me.tbox_PayCheckDate.TabIndex = 85
        Me.tbox_PayCheckDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbox_PayCheckDate.ValidatingType = GetType(Date)
        '
        'Label_PayCheckDate
        '
        Me.Label_PayCheckDate.BackColor = System.Drawing.SystemColors.Control
        Me.Label_PayCheckDate.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label_PayCheckDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_PayCheckDate.ForeColor = System.Drawing.Color.Green
        Me.Label_PayCheckDate.Location = New System.Drawing.Point(224, 42)
        Me.Label_PayCheckDate.Name = "Label_PayCheckDate"
        Me.Label_PayCheckDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label_PayCheckDate.Size = New System.Drawing.Size(62, 32)
        Me.Label_PayCheckDate.TabIndex = 84
        Me.Label_PayCheckDate.Text = "PayCheck  Date"
        Me.Label_PayCheckDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'fra_ContactInfo
        '
        Me.fra_ContactInfo.BackColor = System.Drawing.SystemColors.Control
        Me.fra_ContactInfo.Controls.Add(Me.lbl_Address)
        Me.fra_ContactInfo.Controls.Add(Me.lbl_State)
        Me.fra_ContactInfo.Controls.Add(Me.lbl_City)
        Me.fra_ContactInfo.Controls.Add(Me.lbl_Email)
        Me.fra_ContactInfo.Controls.Add(Me.lbl_ZipCode)
        Me.fra_ContactInfo.Controls.Add(Me.lbl_Emergency)
        Me.fra_ContactInfo.Controls.Add(Me.lbl_Phone)
        Me.fra_ContactInfo.Controls.Add(Me.label_Emergency)
        Me.fra_ContactInfo.Controls.Add(Me.label_State)
        Me.fra_ContactInfo.Controls.Add(Me.label_EMail)
        Me.fra_ContactInfo.Controls.Add(Me.label_Phone)
        Me.fra_ContactInfo.Controls.Add(Me.label_ZipCode)
        Me.fra_ContactInfo.Controls.Add(Me.label_City)
        Me.fra_ContactInfo.Controls.Add(Me.label_Address)
        Me.fra_ContactInfo.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.fra_ContactInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.fra_ContactInfo.Location = New System.Drawing.Point(240, 165)
        Me.fra_ContactInfo.Name = "fra_ContactInfo"
        Me.fra_ContactInfo.Padding = New System.Windows.Forms.Padding(0)
        Me.fra_ContactInfo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fra_ContactInfo.Size = New System.Drawing.Size(314, 194)
        Me.fra_ContactInfo.TabIndex = 108
        Me.fra_ContactInfo.TabStop = False
        Me.fra_ContactInfo.Text = "Information"
        '
        'lbl_Address
        '
        Me.lbl_Address.BackColor = System.Drawing.Color.White
        Me.lbl_Address.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Address.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_Address.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Address.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_Address.Location = New System.Drawing.Point(90, 25)
        Me.lbl_Address.Name = "lbl_Address"
        Me.lbl_Address.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_Address.Size = New System.Drawing.Size(206, 17)
        Me.lbl_Address.TabIndex = 109
        Me.lbl_Address.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_State
        '
        Me.lbl_State.BackColor = System.Drawing.Color.White
        Me.lbl_State.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_State.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_State.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_State.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_State.Location = New System.Drawing.Point(273, 52)
        Me.lbl_State.Name = "lbl_State"
        Me.lbl_State.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_State.Size = New System.Drawing.Size(23, 17)
        Me.lbl_State.TabIndex = 108
        Me.lbl_State.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_City
        '
        Me.lbl_City.BackColor = System.Drawing.Color.White
        Me.lbl_City.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_City.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_City.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_City.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_City.Location = New System.Drawing.Point(90, 52)
        Me.lbl_City.Name = "lbl_City"
        Me.lbl_City.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_City.Size = New System.Drawing.Size(94, 17)
        Me.lbl_City.TabIndex = 107
        Me.lbl_City.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_Email
        '
        Me.lbl_Email.BackColor = System.Drawing.Color.White
        Me.lbl_Email.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Email.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_Email.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Email.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_Email.Location = New System.Drawing.Point(90, 160)
        Me.lbl_Email.Name = "lbl_Email"
        Me.lbl_Email.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_Email.Size = New System.Drawing.Size(206, 17)
        Me.lbl_Email.TabIndex = 106
        Me.lbl_Email.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_ZipCode
        '
        Me.lbl_ZipCode.BackColor = System.Drawing.Color.White
        Me.lbl_ZipCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_ZipCode.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_ZipCode.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ZipCode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_ZipCode.Location = New System.Drawing.Point(90, 80)
        Me.lbl_ZipCode.Name = "lbl_ZipCode"
        Me.lbl_ZipCode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_ZipCode.Size = New System.Drawing.Size(65, 17)
        Me.lbl_ZipCode.TabIndex = 105
        Me.lbl_ZipCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_Emergency
        '
        Me.lbl_Emergency.BackColor = System.Drawing.Color.White
        Me.lbl_Emergency.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Emergency.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_Emergency.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Emergency.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_Emergency.Location = New System.Drawing.Point(90, 133)
        Me.lbl_Emergency.Name = "lbl_Emergency"
        Me.lbl_Emergency.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_Emergency.Size = New System.Drawing.Size(79, 17)
        Me.lbl_Emergency.TabIndex = 104
        Me.lbl_Emergency.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_Phone
        '
        Me.lbl_Phone.BackColor = System.Drawing.Color.White
        Me.lbl_Phone.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Phone.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_Phone.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Phone.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_Phone.Location = New System.Drawing.Point(90, 106)
        Me.lbl_Phone.Name = "lbl_Phone"
        Me.lbl_Phone.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_Phone.Size = New System.Drawing.Size(79, 17)
        Me.lbl_Phone.TabIndex = 103
        Me.lbl_Phone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'label_Emergency
        '
        Me.label_Emergency.BackColor = System.Drawing.SystemColors.Control
        Me.label_Emergency.Cursor = System.Windows.Forms.Cursors.Default
        Me.label_Emergency.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_Emergency.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.label_Emergency.Location = New System.Drawing.Point(7, 135)
        Me.label_Emergency.Name = "label_Emergency"
        Me.label_Emergency.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label_Emergency.Size = New System.Drawing.Size(80, 14)
        Me.label_Emergency.TabIndex = 102
        Me.label_Emergency.Text = "Emergency:"
        Me.label_Emergency.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'label_State
        '
        Me.label_State.AutoSize = True
        Me.label_State.BackColor = System.Drawing.SystemColors.Control
        Me.label_State.Cursor = System.Windows.Forms.Cursors.Default
        Me.label_State.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_State.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.label_State.Location = New System.Drawing.Point(240, 54)
        Me.label_State.Name = "label_State"
        Me.label_State.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label_State.Size = New System.Drawing.Size(35, 14)
        Me.label_State.TabIndex = 63
        Me.label_State.Text = "State:"
        '
        'label_EMail
        '
        Me.label_EMail.AutoSize = True
        Me.label_EMail.BackColor = System.Drawing.SystemColors.Control
        Me.label_EMail.Cursor = System.Windows.Forms.Cursors.Default
        Me.label_EMail.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_EMail.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.label_EMail.Location = New System.Drawing.Point(7, 162)
        Me.label_EMail.Name = "label_EMail"
        Me.label_EMail.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label_EMail.Size = New System.Drawing.Size(82, 14)
        Me.label_EMail.TabIndex = 62
        Me.label_EMail.Text = "E-Mail Address:"
        Me.label_EMail.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'label_Phone
        '
        Me.label_Phone.BackColor = System.Drawing.SystemColors.Control
        Me.label_Phone.Cursor = System.Windows.Forms.Cursors.Default
        Me.label_Phone.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_Phone.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.label_Phone.Location = New System.Drawing.Point(7, 108)
        Me.label_Phone.Name = "label_Phone"
        Me.label_Phone.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label_Phone.Size = New System.Drawing.Size(80, 14)
        Me.label_Phone.TabIndex = 61
        Me.label_Phone.Text = "Phone Number:"
        Me.label_Phone.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'label_ZipCode
        '
        Me.label_ZipCode.BackColor = System.Drawing.SystemColors.Control
        Me.label_ZipCode.Cursor = System.Windows.Forms.Cursors.Default
        Me.label_ZipCode.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_ZipCode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.label_ZipCode.Location = New System.Drawing.Point(7, 81)
        Me.label_ZipCode.Name = "label_ZipCode"
        Me.label_ZipCode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label_ZipCode.Size = New System.Drawing.Size(80, 14)
        Me.label_ZipCode.TabIndex = 60
        Me.label_ZipCode.Text = "Zip Code:"
        Me.label_ZipCode.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'label_City
        '
        Me.label_City.BackColor = System.Drawing.SystemColors.Control
        Me.label_City.Cursor = System.Windows.Forms.Cursors.Default
        Me.label_City.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_City.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.label_City.Location = New System.Drawing.Point(7, 54)
        Me.label_City.Name = "label_City"
        Me.label_City.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label_City.Size = New System.Drawing.Size(80, 14)
        Me.label_City.TabIndex = 59
        Me.label_City.Text = "City:"
        Me.label_City.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'label_Address
        '
        Me.label_Address.AutoSize = True
        Me.label_Address.BackColor = System.Drawing.SystemColors.Control
        Me.label_Address.Cursor = System.Windows.Forms.Cursors.Default
        Me.label_Address.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_Address.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.label_Address.Location = New System.Drawing.Point(7, 27)
        Me.label_Address.Name = "label_Address"
        Me.label_Address.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label_Address.Size = New System.Drawing.Size(83, 14)
        Me.label_Address.TabIndex = 58
        Me.label_Address.Text = "Street Address:"
        Me.label_Address.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'fra_List
        '
        Me.fra_List.BackColor = System.Drawing.SystemColors.Control
        Me.fra_List.Controls.Add(Me.lbl_Listbox)
        Me.fra_List.Controls.Add(Me.fra_Listbox1)
        Me.fra_List.Controls.Add(Me.opt_NonActive)
        Me.fra_List.Controls.Add(Me.opt_Active)
        Me.fra_List.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fra_List.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fra_List.Location = New System.Drawing.Point(20, 15)
        Me.fra_List.Name = "fra_List"
        Me.fra_List.Padding = New System.Windows.Forms.Padding(0)
        Me.fra_List.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fra_List.Size = New System.Drawing.Size(201, 700)
        Me.fra_List.TabIndex = 105
        Me.fra_List.TabStop = False
        '
        'lbl_Listbox
        '
        Me.lbl_Listbox.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Listbox.ForeColor = System.Drawing.Color.Green
        Me.lbl_Listbox.Location = New System.Drawing.Point(20, 14)
        Me.lbl_Listbox.Name = "lbl_Listbox"
        Me.lbl_Listbox.Size = New System.Drawing.Size(160, 16)
        Me.lbl_Listbox.TabIndex = 100
        Me.lbl_Listbox.Text = "Employees"
        Me.lbl_Listbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'fra_Listbox1
        '
        Me.fra_Listbox1.BackColor = System.Drawing.Color.White
        Me.fra_Listbox1.Controls.Add(Me.ListBox1)
        Me.fra_Listbox1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fra_Listbox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fra_Listbox1.Location = New System.Drawing.Point(20, 34)
        Me.fra_Listbox1.Name = "fra_Listbox1"
        Me.fra_Listbox1.Padding = New System.Windows.Forms.Padding(0)
        Me.fra_Listbox1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fra_Listbox1.Size = New System.Drawing.Size(160, 620)
        Me.fra_Listbox1.TabIndex = 70
        Me.fra_Listbox1.TabStop = False
        '
        'ListBox1
        '
        Me.ListBox1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 14
        Me.ListBox1.Location = New System.Drawing.Point(0, 0)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(160, 620)
        Me.ListBox1.TabIndex = 0
        '
        'opt_NonActive
        '
        Me.opt_NonActive.AutoSize = True
        Me.opt_NonActive.BackColor = System.Drawing.SystemColors.Control
        Me.opt_NonActive.Cursor = System.Windows.Forms.Cursors.Default
        Me.opt_NonActive.Enabled = False
        Me.opt_NonActive.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opt_NonActive.ForeColor = System.Drawing.Color.Green
        Me.opt_NonActive.Location = New System.Drawing.Point(144, 667)
        Me.opt_NonActive.Name = "opt_NonActive"
        Me.opt_NonActive.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.opt_NonActive.Size = New System.Drawing.Size(37, 18)
        Me.opt_NonActive.TabIndex = 37
        Me.opt_NonActive.Text = "All"
        Me.opt_NonActive.UseVisualStyleBackColor = False
        '
        'opt_Active
        '
        Me.opt_Active.AutoSize = True
        Me.opt_Active.BackColor = System.Drawing.SystemColors.Control
        Me.opt_Active.Cursor = System.Windows.Forms.Cursors.Default
        Me.opt_Active.Enabled = False
        Me.opt_Active.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opt_Active.ForeColor = System.Drawing.Color.Green
        Me.opt_Active.Location = New System.Drawing.Point(21, 667)
        Me.opt_Active.Name = "opt_Active"
        Me.opt_Active.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.opt_Active.Size = New System.Drawing.Size(111, 18)
        Me.opt_Active.TabIndex = 35
        Me.opt_Active.Text = "Active Employees"
        Me.opt_Active.UseVisualStyleBackColor = False
        '
        'fra_Contacts
        '
        Me.fra_Contacts.BackColor = System.Drawing.SystemColors.Control
        Me.fra_Contacts.Controls.Add(Me.lbl_SocSecurity)
        Me.fra_Contacts.Controls.Add(Me.lbl_FirstName)
        Me.fra_Contacts.Controls.Add(Me.lbl_LastName)
        Me.fra_Contacts.Controls.Add(Me.lbl_BirthDate)
        Me.fra_Contacts.Controls.Add(Me.cbx_Active)
        Me.fra_Contacts.Controls.Add(Me.Label_ID)
        Me.fra_Contacts.Controls.Add(Me.lbl_ID)
        Me.fra_Contacts.Controls.Add(Me.label_SocSecurity)
        Me.fra_Contacts.Controls.Add(Me.label_Active)
        Me.fra_Contacts.Controls.Add(Me.label_Lastname)
        Me.fra_Contacts.Controls.Add(Me.label_FirstName)
        Me.fra_Contacts.Controls.Add(Me.label_BirthDate)
        Me.fra_Contacts.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.fra_Contacts.ForeColor = System.Drawing.Color.Green
        Me.fra_Contacts.Location = New System.Drawing.Point(240, 15)
        Me.fra_Contacts.Name = "fra_Contacts"
        Me.fra_Contacts.Padding = New System.Windows.Forms.Padding(0)
        Me.fra_Contacts.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fra_Contacts.Size = New System.Drawing.Size(314, 140)
        Me.fra_Contacts.TabIndex = 104
        Me.fra_Contacts.TabStop = False
        Me.fra_Contacts.Text = "Employee"
        '
        'lbl_SocSecurity
        '
        Me.lbl_SocSecurity.BackColor = System.Drawing.Color.White
        Me.lbl_SocSecurity.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_SocSecurity.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_SocSecurity.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_SocSecurity.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_SocSecurity.Location = New System.Drawing.Point(90, 106)
        Me.lbl_SocSecurity.Name = "lbl_SocSecurity"
        Me.lbl_SocSecurity.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_SocSecurity.Size = New System.Drawing.Size(69, 17)
        Me.lbl_SocSecurity.TabIndex = 87
        Me.lbl_SocSecurity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_FirstName
        '
        Me.lbl_FirstName.BackColor = System.Drawing.Color.White
        Me.lbl_FirstName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_FirstName.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_FirstName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_FirstName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_FirstName.Location = New System.Drawing.Point(90, 52)
        Me.lbl_FirstName.Name = "lbl_FirstName"
        Me.lbl_FirstName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_FirstName.Size = New System.Drawing.Size(99, 17)
        Me.lbl_FirstName.TabIndex = 86
        Me.lbl_FirstName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_LastName
        '
        Me.lbl_LastName.BackColor = System.Drawing.Color.White
        Me.lbl_LastName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_LastName.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_LastName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_LastName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_LastName.Location = New System.Drawing.Point(90, 25)
        Me.lbl_LastName.Name = "lbl_LastName"
        Me.lbl_LastName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_LastName.Size = New System.Drawing.Size(99, 17)
        Me.lbl_LastName.TabIndex = 85
        Me.lbl_LastName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_BirthDate
        '
        Me.lbl_BirthDate.BackColor = System.Drawing.Color.White
        Me.lbl_BirthDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_BirthDate.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_BirthDate.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_BirthDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_BirthDate.Location = New System.Drawing.Point(90, 80)
        Me.lbl_BirthDate.Name = "lbl_BirthDate"
        Me.lbl_BirthDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_BirthDate.Size = New System.Drawing.Size(66, 17)
        Me.lbl_BirthDate.TabIndex = 84
        Me.lbl_BirthDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbx_Active
        '
        Me.cbx_Active.BackColor = System.Drawing.SystemColors.Control
        Me.cbx_Active.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbx_Active.Enabled = False
        Me.cbx_Active.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbx_Active.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cbx_Active.Location = New System.Drawing.Point(257, 43)
        Me.cbx_Active.Name = "cbx_Active"
        Me.cbx_Active.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbx_Active.Size = New System.Drawing.Size(20, 20)
        Me.cbx_Active.TabIndex = 18
        Me.cbx_Active.UseVisualStyleBackColor = False
        '
        'Label_ID
        '
        Me.Label_ID.AutoSize = True
        Me.Label_ID.BackColor = System.Drawing.SystemColors.Control
        Me.Label_ID.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label_ID.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_ID.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label_ID.Location = New System.Drawing.Point(233, 84)
        Me.Label_ID.Name = "Label_ID"
        Me.Label_ID.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label_ID.Size = New System.Drawing.Size(65, 14)
        Me.Label_ID.TabIndex = 83
        Me.Label_ID.Text = "Employee ID"
        Me.Label_ID.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lbl_ID
        '
        Me.lbl_ID.BackColor = System.Drawing.Color.White
        Me.lbl_ID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_ID.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_ID.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ID.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_ID.Location = New System.Drawing.Point(247, 105)
        Me.lbl_ID.Name = "lbl_ID"
        Me.lbl_ID.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_ID.Size = New System.Drawing.Size(34, 17)
        Me.lbl_ID.TabIndex = 82
        Me.lbl_ID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'label_SocSecurity
        '
        Me.label_SocSecurity.BackColor = System.Drawing.SystemColors.Control
        Me.label_SocSecurity.Cursor = System.Windows.Forms.Cursors.Default
        Me.label_SocSecurity.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_SocSecurity.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.label_SocSecurity.Location = New System.Drawing.Point(7, 108)
        Me.label_SocSecurity.Name = "label_SocSecurity"
        Me.label_SocSecurity.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label_SocSecurity.Size = New System.Drawing.Size(80, 14)
        Me.label_SocSecurity.TabIndex = 69
        Me.label_SocSecurity.Text = "Soc Security:"
        Me.label_SocSecurity.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'label_Active
        '
        Me.label_Active.AutoSize = True
        Me.label_Active.BackColor = System.Drawing.SystemColors.Control
        Me.label_Active.Cursor = System.Windows.Forms.Cursors.Default
        Me.label_Active.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_Active.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.label_Active.Location = New System.Drawing.Point(245, 27)
        Me.label_Active.Name = "label_Active"
        Me.label_Active.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label_Active.Size = New System.Drawing.Size(38, 14)
        Me.label_Active.TabIndex = 65
        Me.label_Active.Text = "Active"
        Me.label_Active.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'label_Lastname
        '
        Me.label_Lastname.BackColor = System.Drawing.SystemColors.Control
        Me.label_Lastname.Cursor = System.Windows.Forms.Cursors.Default
        Me.label_Lastname.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_Lastname.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.label_Lastname.Location = New System.Drawing.Point(7, 27)
        Me.label_Lastname.Name = "label_Lastname"
        Me.label_Lastname.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label_Lastname.Size = New System.Drawing.Size(80, 14)
        Me.label_Lastname.TabIndex = 32
        Me.label_Lastname.Text = "Last Name:"
        Me.label_Lastname.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'label_FirstName
        '
        Me.label_FirstName.BackColor = System.Drawing.SystemColors.Control
        Me.label_FirstName.Cursor = System.Windows.Forms.Cursors.Default
        Me.label_FirstName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_FirstName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.label_FirstName.Location = New System.Drawing.Point(7, 54)
        Me.label_FirstName.Name = "label_FirstName"
        Me.label_FirstName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label_FirstName.Size = New System.Drawing.Size(80, 14)
        Me.label_FirstName.TabIndex = 31
        Me.label_FirstName.Text = "First Name:"
        Me.label_FirstName.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'label_BirthDate
        '
        Me.label_BirthDate.BackColor = System.Drawing.SystemColors.Control
        Me.label_BirthDate.Cursor = System.Windows.Forms.Cursors.Default
        Me.label_BirthDate.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_BirthDate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.label_BirthDate.Location = New System.Drawing.Point(7, 81)
        Me.label_BirthDate.Name = "label_BirthDate"
        Me.label_BirthDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label_BirthDate.Size = New System.Drawing.Size(80, 14)
        Me.label_BirthDate.TabIndex = 30
        Me.label_BirthDate.Text = "Birth Date:"
        Me.label_BirthDate.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl_Message
        '
        Me.lbl_Message.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_Message.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_Message.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Message.ForeColor = System.Drawing.Color.Red
        Me.lbl_Message.Location = New System.Drawing.Point(389, 673)
        Me.lbl_Message.Name = "lbl_Message"
        Me.lbl_Message.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_Message.Size = New System.Drawing.Size(496, 40)
        Me.lbl_Message.TabIndex = 111
        Me.lbl_Message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'fra_Income
        '
        Me.fra_Income.BackColor = System.Drawing.SystemColors.Control
        Me.fra_Income.Controls.Add(Me.cmd_Action0)
        Me.fra_Income.Controls.Add(Me.lbl_VacaYear3)
        Me.fra_Income.Controls.Add(Me.lbl_VacaYear2)
        Me.fra_Income.Controls.Add(Me.lbl_VacaYear1)
        Me.fra_Income.Controls.Add(Me.lbl_VacaUsed1)
        Me.fra_Income.Controls.Add(Me.lbl_VacaUsed2)
        Me.fra_Income.Controls.Add(Me.lbl_VacaUsed3)
        Me.fra_Income.Controls.Add(Me.lbl_VacaIssued3)
        Me.fra_Income.Controls.Add(Me.lbl_VacaIssued2)
        Me.fra_Income.Controls.Add(Me.lbl_VacaIssued1)
        Me.fra_Income.Controls.Add(Me.Label_DaysUsed)
        Me.fra_Income.Controls.Add(Me.Label_DaysIssued)
        Me.fra_Income.Controls.Add(Me.Label_VacationData)
        Me.fra_Income.Controls.Add(Me.Label_Year)
        Me.fra_Income.Controls.Add(Me.cmd_ClearAdjustments)
        Me.fra_Income.Controls.Add(Me.label_Adjusted)
        Me.fra_Income.Controls.Add(Me.label_Original)
        Me.fra_Income.Controls.Add(Me.lbl_WeekSocSecurityTemp)
        Me.fra_Income.Controls.Add(Me.lbl_WeekSocSecurity)
        Me.fra_Income.Controls.Add(Me.lbl_WeekMisc)
        Me.fra_Income.Controls.Add(Me.lbl_WeekHours)
        Me.fra_Income.Controls.Add(Me.lbl_WeekStateTax)
        Me.fra_Income.Controls.Add(Me.lbl_WeekFedTax)
        Me.fra_Income.Controls.Add(Me.lbl_Salary)
        Me.fra_Income.Controls.Add(Me.lbl_YearMisc)
        Me.fra_Income.Controls.Add(Me.lbl_YearSocSecurity)
        Me.fra_Income.Controls.Add(Me.lbl_YearStateTax)
        Me.fra_Income.Controls.Add(Me.lbl_YearFederalTax)
        Me.fra_Income.Controls.Add(Me.lbl_YearEarnings)
        Me.fra_Income.Controls.Add(Me.label_YearMisc)
        Me.fra_Income.Controls.Add(Me.label_YearSocSecurity)
        Me.fra_Income.Controls.Add(Me.label_YearStateTax)
        Me.fra_Income.Controls.Add(Me.label_YearFederalTax)
        Me.fra_Income.Controls.Add(Me.label_YearEarnings)
        Me.fra_Income.Controls.Add(Me.label_PaycheckTotals)
        Me.fra_Income.Controls.Add(Me.tbox_WeekMiscTemp)
        Me.fra_Income.Controls.Add(Me.tbox_WeekStateTaxTemp)
        Me.fra_Income.Controls.Add(Me.tbox_WeekFedTaxTemp)
        Me.fra_Income.Controls.Add(Me.tbox_SalaryTemp)
        Me.fra_Income.Controls.Add(Me.label_SocialSecurity)
        Me.fra_Income.Controls.Add(Me.tbox_WeekHoursTemp)
        Me.fra_Income.Controls.Add(Me.label_MiscFunds)
        Me.fra_Income.Controls.Add(Me.label_StateTax)
        Me.fra_Income.Controls.Add(Me.label_FederalTax)
        Me.fra_Income.Controls.Add(Me.label_Hours)
        Me.fra_Income.Controls.Add(Me.label_Salary)
        Me.fra_Income.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fra_Income.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.fra_Income.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.fra_Income.Location = New System.Drawing.Point(240, 370)
        Me.fra_Income.Name = "fra_Income"
        Me.fra_Income.Padding = New System.Windows.Forms.Padding(0)
        Me.fra_Income.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fra_Income.Size = New System.Drawing.Size(645, 284)
        Me.fra_Income.TabIndex = 114
        Me.fra_Income.TabStop = False
        Me.fra_Income.Text = "Temporary Adjustment"
        '
        'cmd_Action0
        '
        Me.cmd_Action0.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_Action0.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Action0.Image = Global.Machine_Shop.My.Resources.Resources.Edit_2
        Me.cmd_Action0.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_Action0.Location = New System.Drawing.Point(310, 143)
        Me.cmd_Action0.Margin = New System.Windows.Forms.Padding(2)
        Me.cmd_Action0.Name = "cmd_Action0"
        Me.cmd_Action0.Size = New System.Drawing.Size(53, 45)
        Me.cmd_Action0.TabIndex = 142
        Me.cmd_Action0.Tag = "0"
        Me.cmd_Action0.Text = "Edit"
        Me.cmd_Action0.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmd_Action0.UseVisualStyleBackColor = True
        '
        'lbl_VacaYear3
        '
        Me.lbl_VacaYear3.BackColor = System.Drawing.Color.White
        Me.lbl_VacaYear3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_VacaYear3.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_VacaYear3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_VacaYear3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_VacaYear3.Location = New System.Drawing.Point(428, 115)
        Me.lbl_VacaYear3.Name = "lbl_VacaYear3"
        Me.lbl_VacaYear3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_VacaYear3.Size = New System.Drawing.Size(34, 17)
        Me.lbl_VacaYear3.TabIndex = 141
        Me.lbl_VacaYear3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_VacaYear3.Visible = False
        '
        'lbl_VacaYear2
        '
        Me.lbl_VacaYear2.BackColor = System.Drawing.Color.White
        Me.lbl_VacaYear2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_VacaYear2.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_VacaYear2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_VacaYear2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_VacaYear2.Location = New System.Drawing.Point(428, 88)
        Me.lbl_VacaYear2.Name = "lbl_VacaYear2"
        Me.lbl_VacaYear2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_VacaYear2.Size = New System.Drawing.Size(34, 17)
        Me.lbl_VacaYear2.TabIndex = 140
        Me.lbl_VacaYear2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_VacaYear2.Visible = False
        '
        'lbl_VacaYear1
        '
        Me.lbl_VacaYear1.BackColor = System.Drawing.Color.White
        Me.lbl_VacaYear1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_VacaYear1.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_VacaYear1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_VacaYear1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_VacaYear1.Location = New System.Drawing.Point(428, 61)
        Me.lbl_VacaYear1.Name = "lbl_VacaYear1"
        Me.lbl_VacaYear1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_VacaYear1.Size = New System.Drawing.Size(34, 17)
        Me.lbl_VacaYear1.TabIndex = 139
        Me.lbl_VacaYear1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_VacaYear1.Visible = False
        '
        'lbl_VacaUsed1
        '
        Me.lbl_VacaUsed1.BackColor = System.Drawing.Color.White
        Me.lbl_VacaUsed1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_VacaUsed1.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_VacaUsed1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_VacaUsed1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_VacaUsed1.Location = New System.Drawing.Point(583, 61)
        Me.lbl_VacaUsed1.Name = "lbl_VacaUsed1"
        Me.lbl_VacaUsed1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_VacaUsed1.Size = New System.Drawing.Size(22, 17)
        Me.lbl_VacaUsed1.TabIndex = 138
        Me.lbl_VacaUsed1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl_VacaUsed1.Visible = False
        '
        'lbl_VacaUsed2
        '
        Me.lbl_VacaUsed2.BackColor = System.Drawing.Color.White
        Me.lbl_VacaUsed2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_VacaUsed2.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_VacaUsed2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_VacaUsed2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_VacaUsed2.Location = New System.Drawing.Point(583, 88)
        Me.lbl_VacaUsed2.Name = "lbl_VacaUsed2"
        Me.lbl_VacaUsed2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_VacaUsed2.Size = New System.Drawing.Size(22, 17)
        Me.lbl_VacaUsed2.TabIndex = 137
        Me.lbl_VacaUsed2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl_VacaUsed2.Visible = False
        '
        'lbl_VacaUsed3
        '
        Me.lbl_VacaUsed3.BackColor = System.Drawing.Color.White
        Me.lbl_VacaUsed3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_VacaUsed3.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_VacaUsed3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_VacaUsed3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_VacaUsed3.Location = New System.Drawing.Point(583, 115)
        Me.lbl_VacaUsed3.Name = "lbl_VacaUsed3"
        Me.lbl_VacaUsed3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_VacaUsed3.Size = New System.Drawing.Size(22, 17)
        Me.lbl_VacaUsed3.TabIndex = 136
        Me.lbl_VacaUsed3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl_VacaUsed3.Visible = False
        '
        'lbl_VacaIssued3
        '
        Me.lbl_VacaIssued3.BackColor = System.Drawing.Color.White
        Me.lbl_VacaIssued3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_VacaIssued3.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_VacaIssued3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_VacaIssued3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_VacaIssued3.Location = New System.Drawing.Point(508, 115)
        Me.lbl_VacaIssued3.Name = "lbl_VacaIssued3"
        Me.lbl_VacaIssued3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_VacaIssued3.Size = New System.Drawing.Size(22, 17)
        Me.lbl_VacaIssued3.TabIndex = 135
        Me.lbl_VacaIssued3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl_VacaIssued3.Visible = False
        '
        'lbl_VacaIssued2
        '
        Me.lbl_VacaIssued2.BackColor = System.Drawing.Color.White
        Me.lbl_VacaIssued2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_VacaIssued2.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_VacaIssued2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_VacaIssued2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_VacaIssued2.Location = New System.Drawing.Point(508, 88)
        Me.lbl_VacaIssued2.Name = "lbl_VacaIssued2"
        Me.lbl_VacaIssued2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_VacaIssued2.Size = New System.Drawing.Size(22, 17)
        Me.lbl_VacaIssued2.TabIndex = 134
        Me.lbl_VacaIssued2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl_VacaIssued2.Visible = False
        '
        'lbl_VacaIssued1
        '
        Me.lbl_VacaIssued1.BackColor = System.Drawing.Color.White
        Me.lbl_VacaIssued1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_VacaIssued1.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_VacaIssued1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_VacaIssued1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_VacaIssued1.Location = New System.Drawing.Point(508, 61)
        Me.lbl_VacaIssued1.Name = "lbl_VacaIssued1"
        Me.lbl_VacaIssued1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_VacaIssued1.Size = New System.Drawing.Size(22, 17)
        Me.lbl_VacaIssued1.TabIndex = 133
        Me.lbl_VacaIssued1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl_VacaIssued1.Visible = False
        '
        'Label_DaysUsed
        '
        Me.Label_DaysUsed.BackColor = System.Drawing.SystemColors.Control
        Me.Label_DaysUsed.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label_DaysUsed.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_DaysUsed.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label_DaysUsed.Location = New System.Drawing.Point(562, 41)
        Me.Label_DaysUsed.Name = "Label_DaysUsed"
        Me.Label_DaysUsed.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label_DaysUsed.Size = New System.Drawing.Size(64, 14)
        Me.Label_DaysUsed.TabIndex = 132
        Me.Label_DaysUsed.Text = "Days Used"
        Me.Label_DaysUsed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label_DaysUsed.Visible = False
        '
        'Label_DaysIssued
        '
        Me.Label_DaysIssued.AutoSize = True
        Me.Label_DaysIssued.BackColor = System.Drawing.SystemColors.Control
        Me.Label_DaysIssued.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label_DaysIssued.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_DaysIssued.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label_DaysIssued.Location = New System.Drawing.Point(488, 41)
        Me.Label_DaysIssued.Name = "Label_DaysIssued"
        Me.Label_DaysIssued.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label_DaysIssued.Size = New System.Drawing.Size(67, 14)
        Me.Label_DaysIssued.TabIndex = 131
        Me.Label_DaysIssued.Text = "Days Issued"
        Me.Label_DaysIssued.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label_DaysIssued.Visible = False
        '
        'Label_VacationData
        '
        Me.Label_VacationData.AutoSize = True
        Me.Label_VacationData.BackColor = System.Drawing.SystemColors.Control
        Me.Label_VacationData.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label_VacationData.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_VacationData.ForeColor = System.Drawing.Color.Green
        Me.Label_VacationData.Location = New System.Drawing.Point(482, 15)
        Me.Label_VacationData.Name = "Label_VacationData"
        Me.Label_VacationData.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label_VacationData.Size = New System.Drawing.Size(82, 15)
        Me.Label_VacationData.TabIndex = 130
        Me.Label_VacationData.Text = "Vacation Data"
        Me.Label_VacationData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label_VacationData.Visible = False
        '
        'Label_Year
        '
        Me.Label_Year.BackColor = System.Drawing.SystemColors.Control
        Me.Label_Year.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label_Year.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Year.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label_Year.Location = New System.Drawing.Point(412, 41)
        Me.Label_Year.Name = "Label_Year"
        Me.Label_Year.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label_Year.Size = New System.Drawing.Size(64, 14)
        Me.Label_Year.TabIndex = 129
        Me.Label_Year.Text = "Year"
        Me.Label_Year.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label_Year.Visible = False
        '
        'cmd_ClearAdjustments
        '
        Me.cmd_ClearAdjustments.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_ClearAdjustments.Location = New System.Drawing.Point(310, 33)
        Me.cmd_ClearAdjustments.Margin = New System.Windows.Forms.Padding(2)
        Me.cmd_ClearAdjustments.Name = "cmd_ClearAdjustments"
        Me.cmd_ClearAdjustments.Size = New System.Drawing.Size(53, 20)
        Me.cmd_ClearAdjustments.TabIndex = 128
        Me.cmd_ClearAdjustments.Text = "Clear"
        Me.cmd_ClearAdjustments.UseVisualStyleBackColor = True
        '
        'label_Adjusted
        '
        Me.label_Adjusted.AutoSize = True
        Me.label_Adjusted.BackColor = System.Drawing.SystemColors.Control
        Me.label_Adjusted.Cursor = System.Windows.Forms.Cursors.Default
        Me.label_Adjusted.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_Adjusted.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.label_Adjusted.Location = New System.Drawing.Point(246, 14)
        Me.label_Adjusted.Name = "label_Adjusted"
        Me.label_Adjusted.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label_Adjusted.Size = New System.Drawing.Size(58, 14)
        Me.label_Adjusted.TabIndex = 127
        Me.label_Adjusted.Text = "Temporary"
        Me.label_Adjusted.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'label_Original
        '
        Me.label_Original.BackColor = System.Drawing.SystemColors.Control
        Me.label_Original.Cursor = System.Windows.Forms.Cursors.Default
        Me.label_Original.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_Original.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.label_Original.Location = New System.Drawing.Point(188, 14)
        Me.label_Original.Name = "label_Original"
        Me.label_Original.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label_Original.Size = New System.Drawing.Size(44, 14)
        Me.label_Original.TabIndex = 126
        Me.label_Original.Text = "Original"
        Me.label_Original.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_WeekSocSecurityTemp
        '
        Me.lbl_WeekSocSecurityTemp.BackColor = System.Drawing.Color.White
        Me.lbl_WeekSocSecurityTemp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_WeekSocSecurityTemp.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_WeekSocSecurityTemp.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_WeekSocSecurityTemp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_WeekSocSecurityTemp.Location = New System.Drawing.Point(250, 143)
        Me.lbl_WeekSocSecurityTemp.Name = "lbl_WeekSocSecurityTemp"
        Me.lbl_WeekSocSecurityTemp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_WeekSocSecurityTemp.Size = New System.Drawing.Size(48, 17)
        Me.lbl_WeekSocSecurityTemp.TabIndex = 125
        Me.lbl_WeekSocSecurityTemp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_WeekSocSecurity
        '
        Me.lbl_WeekSocSecurity.BackColor = System.Drawing.Color.White
        Me.lbl_WeekSocSecurity.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_WeekSocSecurity.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_WeekSocSecurity.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_WeekSocSecurity.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_WeekSocSecurity.Location = New System.Drawing.Point(188, 143)
        Me.lbl_WeekSocSecurity.Name = "lbl_WeekSocSecurity"
        Me.lbl_WeekSocSecurity.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_WeekSocSecurity.Size = New System.Drawing.Size(44, 17)
        Me.lbl_WeekSocSecurity.TabIndex = 124
        Me.lbl_WeekSocSecurity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_WeekMisc
        '
        Me.lbl_WeekMisc.BackColor = System.Drawing.Color.White
        Me.lbl_WeekMisc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_WeekMisc.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_WeekMisc.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_WeekMisc.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_WeekMisc.Location = New System.Drawing.Point(188, 170)
        Me.lbl_WeekMisc.Name = "lbl_WeekMisc"
        Me.lbl_WeekMisc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_WeekMisc.Size = New System.Drawing.Size(44, 17)
        Me.lbl_WeekMisc.TabIndex = 123
        Me.lbl_WeekMisc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_WeekHours
        '
        Me.lbl_WeekHours.BackColor = System.Drawing.Color.White
        Me.lbl_WeekHours.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_WeekHours.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_WeekHours.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_WeekHours.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_WeekHours.Location = New System.Drawing.Point(188, 62)
        Me.lbl_WeekHours.Name = "lbl_WeekHours"
        Me.lbl_WeekHours.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_WeekHours.Size = New System.Drawing.Size(44, 17)
        Me.lbl_WeekHours.TabIndex = 122
        Me.lbl_WeekHours.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_WeekStateTax
        '
        Me.lbl_WeekStateTax.BackColor = System.Drawing.Color.White
        Me.lbl_WeekStateTax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_WeekStateTax.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_WeekStateTax.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_WeekStateTax.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_WeekStateTax.Location = New System.Drawing.Point(188, 116)
        Me.lbl_WeekStateTax.Name = "lbl_WeekStateTax"
        Me.lbl_WeekStateTax.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_WeekStateTax.Size = New System.Drawing.Size(44, 17)
        Me.lbl_WeekStateTax.TabIndex = 121
        Me.lbl_WeekStateTax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_WeekFedTax
        '
        Me.lbl_WeekFedTax.BackColor = System.Drawing.Color.White
        Me.lbl_WeekFedTax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_WeekFedTax.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_WeekFedTax.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_WeekFedTax.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_WeekFedTax.Location = New System.Drawing.Point(188, 90)
        Me.lbl_WeekFedTax.Name = "lbl_WeekFedTax"
        Me.lbl_WeekFedTax.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_WeekFedTax.Size = New System.Drawing.Size(44, 17)
        Me.lbl_WeekFedTax.TabIndex = 120
        Me.lbl_WeekFedTax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_Salary
        '
        Me.lbl_Salary.BackColor = System.Drawing.Color.White
        Me.lbl_Salary.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Salary.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_Salary.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Salary.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_Salary.Location = New System.Drawing.Point(188, 35)
        Me.lbl_Salary.Name = "lbl_Salary"
        Me.lbl_Salary.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_Salary.Size = New System.Drawing.Size(44, 17)
        Me.lbl_Salary.TabIndex = 119
        Me.lbl_Salary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_YearMisc
        '
        Me.lbl_YearMisc.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_YearMisc.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_YearMisc.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_YearMisc.ForeColor = System.Drawing.Color.Black
        Me.lbl_YearMisc.Location = New System.Drawing.Point(435, 250)
        Me.lbl_YearMisc.Name = "lbl_YearMisc"
        Me.lbl_YearMisc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_YearMisc.Size = New System.Drawing.Size(75, 14)
        Me.lbl_YearMisc.TabIndex = 117
        Me.lbl_YearMisc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_YearSocSecurity
        '
        Me.lbl_YearSocSecurity.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_YearSocSecurity.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_YearSocSecurity.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_YearSocSecurity.ForeColor = System.Drawing.Color.Black
        Me.lbl_YearSocSecurity.Location = New System.Drawing.Point(331, 250)
        Me.lbl_YearSocSecurity.Name = "lbl_YearSocSecurity"
        Me.lbl_YearSocSecurity.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_YearSocSecurity.Size = New System.Drawing.Size(75, 14)
        Me.lbl_YearSocSecurity.TabIndex = 116
        Me.lbl_YearSocSecurity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_YearStateTax
        '
        Me.lbl_YearStateTax.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_YearStateTax.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_YearStateTax.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_YearStateTax.ForeColor = System.Drawing.Color.Black
        Me.lbl_YearStateTax.Location = New System.Drawing.Point(227, 250)
        Me.lbl_YearStateTax.Name = "lbl_YearStateTax"
        Me.lbl_YearStateTax.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_YearStateTax.Size = New System.Drawing.Size(75, 14)
        Me.lbl_YearStateTax.TabIndex = 115
        Me.lbl_YearStateTax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_YearFederalTax
        '
        Me.lbl_YearFederalTax.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_YearFederalTax.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_YearFederalTax.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_YearFederalTax.ForeColor = System.Drawing.Color.Black
        Me.lbl_YearFederalTax.Location = New System.Drawing.Point(123, 250)
        Me.lbl_YearFederalTax.Name = "lbl_YearFederalTax"
        Me.lbl_YearFederalTax.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_YearFederalTax.Size = New System.Drawing.Size(75, 14)
        Me.lbl_YearFederalTax.TabIndex = 114
        Me.lbl_YearFederalTax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_YearEarnings
        '
        Me.lbl_YearEarnings.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_YearEarnings.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_YearEarnings.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_YearEarnings.ForeColor = System.Drawing.Color.Black
        Me.lbl_YearEarnings.Location = New System.Drawing.Point(19, 250)
        Me.lbl_YearEarnings.Name = "lbl_YearEarnings"
        Me.lbl_YearEarnings.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_YearEarnings.Size = New System.Drawing.Size(75, 14)
        Me.lbl_YearEarnings.TabIndex = 113
        Me.lbl_YearEarnings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'label_YearMisc
        '
        Me.label_YearMisc.BackColor = System.Drawing.SystemColors.Control
        Me.label_YearMisc.Cursor = System.Windows.Forms.Cursors.Default
        Me.label_YearMisc.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_YearMisc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.label_YearMisc.Location = New System.Drawing.Point(435, 230)
        Me.label_YearMisc.Name = "label_YearMisc"
        Me.label_YearMisc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label_YearMisc.Size = New System.Drawing.Size(75, 14)
        Me.label_YearMisc.TabIndex = 112
        Me.label_YearMisc.Text = "Miscelleous"
        Me.label_YearMisc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'label_YearSocSecurity
        '
        Me.label_YearSocSecurity.BackColor = System.Drawing.SystemColors.Control
        Me.label_YearSocSecurity.Cursor = System.Windows.Forms.Cursors.Default
        Me.label_YearSocSecurity.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_YearSocSecurity.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.label_YearSocSecurity.Location = New System.Drawing.Point(331, 230)
        Me.label_YearSocSecurity.Name = "label_YearSocSecurity"
        Me.label_YearSocSecurity.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label_YearSocSecurity.Size = New System.Drawing.Size(75, 14)
        Me.label_YearSocSecurity.TabIndex = 111
        Me.label_YearSocSecurity.Text = "Soc. Security"
        Me.label_YearSocSecurity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'label_YearStateTax
        '
        Me.label_YearStateTax.BackColor = System.Drawing.SystemColors.Control
        Me.label_YearStateTax.Cursor = System.Windows.Forms.Cursors.Default
        Me.label_YearStateTax.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_YearStateTax.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.label_YearStateTax.Location = New System.Drawing.Point(227, 230)
        Me.label_YearStateTax.Name = "label_YearStateTax"
        Me.label_YearStateTax.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label_YearStateTax.Size = New System.Drawing.Size(75, 14)
        Me.label_YearStateTax.TabIndex = 110
        Me.label_YearStateTax.Text = "State Tax"
        Me.label_YearStateTax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'label_YearFederalTax
        '
        Me.label_YearFederalTax.BackColor = System.Drawing.SystemColors.Control
        Me.label_YearFederalTax.Cursor = System.Windows.Forms.Cursors.Default
        Me.label_YearFederalTax.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_YearFederalTax.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.label_YearFederalTax.Location = New System.Drawing.Point(123, 230)
        Me.label_YearFederalTax.Name = "label_YearFederalTax"
        Me.label_YearFederalTax.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label_YearFederalTax.Size = New System.Drawing.Size(75, 14)
        Me.label_YearFederalTax.TabIndex = 109
        Me.label_YearFederalTax.Text = "Federal Tax"
        Me.label_YearFederalTax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'label_YearEarnings
        '
        Me.label_YearEarnings.BackColor = System.Drawing.SystemColors.Control
        Me.label_YearEarnings.Cursor = System.Windows.Forms.Cursors.Default
        Me.label_YearEarnings.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_YearEarnings.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.label_YearEarnings.Location = New System.Drawing.Point(19, 230)
        Me.label_YearEarnings.Name = "label_YearEarnings"
        Me.label_YearEarnings.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label_YearEarnings.Size = New System.Drawing.Size(75, 14)
        Me.label_YearEarnings.TabIndex = 108
        Me.label_YearEarnings.Text = "Year Earnings"
        Me.label_YearEarnings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'label_PaycheckTotals
        '
        Me.label_PaycheckTotals.AutoSize = True
        Me.label_PaycheckTotals.BackColor = System.Drawing.SystemColors.Control
        Me.label_PaycheckTotals.Cursor = System.Windows.Forms.Cursors.Default
        Me.label_PaycheckTotals.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_PaycheckTotals.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.label_PaycheckTotals.Location = New System.Drawing.Point(183, 203)
        Me.label_PaycheckTotals.Name = "label_PaycheckTotals"
        Me.label_PaycheckTotals.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label_PaycheckTotals.Size = New System.Drawing.Size(155, 14)
        Me.label_PaycheckTotals.TabIndex = 107
        Me.label_PaycheckTotals.Text = "Paycheck yearly totals to date:"
        Me.label_PaycheckTotals.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbox_WeekMiscTemp
        '
        Me.tbox_WeekMiscTemp.AcceptsReturn = True
        Me.tbox_WeekMiscTemp.BackColor = System.Drawing.Color.White
        Me.tbox_WeekMiscTemp.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_WeekMiscTemp.Enabled = False
        Me.tbox_WeekMiscTemp.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_WeekMiscTemp.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbox_WeekMiscTemp.Location = New System.Drawing.Point(250, 169)
        Me.tbox_WeekMiscTemp.MaxLength = 0
        Me.tbox_WeekMiscTemp.Name = "tbox_WeekMiscTemp"
        Me.tbox_WeekMiscTemp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbox_WeekMiscTemp.Size = New System.Drawing.Size(48, 20)
        Me.tbox_WeekMiscTemp.TabIndex = 106
        Me.tbox_WeekMiscTemp.WordWrap = False
        '
        'tbox_WeekStateTaxTemp
        '
        Me.tbox_WeekStateTaxTemp.AcceptsReturn = True
        Me.tbox_WeekStateTaxTemp.BackColor = System.Drawing.Color.White
        Me.tbox_WeekStateTaxTemp.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_WeekStateTaxTemp.Enabled = False
        Me.tbox_WeekStateTaxTemp.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_WeekStateTaxTemp.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbox_WeekStateTaxTemp.Location = New System.Drawing.Point(250, 115)
        Me.tbox_WeekStateTaxTemp.MaxLength = 0
        Me.tbox_WeekStateTaxTemp.Name = "tbox_WeekStateTaxTemp"
        Me.tbox_WeekStateTaxTemp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbox_WeekStateTaxTemp.Size = New System.Drawing.Size(48, 20)
        Me.tbox_WeekStateTaxTemp.TabIndex = 104
        '
        'tbox_WeekFedTaxTemp
        '
        Me.tbox_WeekFedTaxTemp.AcceptsReturn = True
        Me.tbox_WeekFedTaxTemp.BackColor = System.Drawing.Color.White
        Me.tbox_WeekFedTaxTemp.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_WeekFedTaxTemp.Enabled = False
        Me.tbox_WeekFedTaxTemp.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_WeekFedTaxTemp.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbox_WeekFedTaxTemp.Location = New System.Drawing.Point(250, 88)
        Me.tbox_WeekFedTaxTemp.MaxLength = 0
        Me.tbox_WeekFedTaxTemp.Name = "tbox_WeekFedTaxTemp"
        Me.tbox_WeekFedTaxTemp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbox_WeekFedTaxTemp.Size = New System.Drawing.Size(48, 20)
        Me.tbox_WeekFedTaxTemp.TabIndex = 103
        '
        'tbox_SalaryTemp
        '
        Me.tbox_SalaryTemp.AcceptsReturn = True
        Me.tbox_SalaryTemp.BackColor = System.Drawing.Color.White
        Me.tbox_SalaryTemp.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_SalaryTemp.Enabled = False
        Me.tbox_SalaryTemp.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_SalaryTemp.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbox_SalaryTemp.Location = New System.Drawing.Point(250, 34)
        Me.tbox_SalaryTemp.MaxLength = 0
        Me.tbox_SalaryTemp.Name = "tbox_SalaryTemp"
        Me.tbox_SalaryTemp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbox_SalaryTemp.Size = New System.Drawing.Size(48, 20)
        Me.tbox_SalaryTemp.TabIndex = 5
        '
        'label_SocialSecurity
        '
        Me.label_SocialSecurity.AutoSize = True
        Me.label_SocialSecurity.BackColor = System.Drawing.SystemColors.Control
        Me.label_SocialSecurity.Cursor = System.Windows.Forms.Cursors.Default
        Me.label_SocialSecurity.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_SocialSecurity.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.label_SocialSecurity.Location = New System.Drawing.Point(14, 145)
        Me.label_SocialSecurity.Name = "label_SocialSecurity"
        Me.label_SocialSecurity.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label_SocialSecurity.Size = New System.Drawing.Size(179, 14)
        Me.label_SocialSecurity.TabIndex = 102
        Me.label_SocialSecurity.Text = "Soc. Security - Medicare payments:"
        Me.label_SocialSecurity.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbox_WeekHoursTemp
        '
        Me.tbox_WeekHoursTemp.AcceptsReturn = True
        Me.tbox_WeekHoursTemp.BackColor = System.Drawing.Color.White
        Me.tbox_WeekHoursTemp.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_WeekHoursTemp.Enabled = False
        Me.tbox_WeekHoursTemp.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_WeekHoursTemp.ForeColor = System.Drawing.Color.Black
        Me.tbox_WeekHoursTemp.Location = New System.Drawing.Point(250, 61)
        Me.tbox_WeekHoursTemp.MaxLength = 0
        Me.tbox_WeekHoursTemp.Name = "tbox_WeekHoursTemp"
        Me.tbox_WeekHoursTemp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbox_WeekHoursTemp.Size = New System.Drawing.Size(48, 20)
        Me.tbox_WeekHoursTemp.TabIndex = 6
        '
        'label_MiscFunds
        '
        Me.label_MiscFunds.BackColor = System.Drawing.SystemColors.Control
        Me.label_MiscFunds.Cursor = System.Windows.Forms.Cursors.Default
        Me.label_MiscFunds.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_MiscFunds.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.label_MiscFunds.Location = New System.Drawing.Point(16, 172)
        Me.label_MiscFunds.Name = "label_MiscFunds"
        Me.label_MiscFunds.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label_MiscFunds.Size = New System.Drawing.Size(171, 14)
        Me.label_MiscFunds.TabIndex = 62
        Me.label_MiscFunds.Text = "Misc Funds withheld per week:"
        Me.label_MiscFunds.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'label_StateTax
        '
        Me.label_StateTax.BackColor = System.Drawing.SystemColors.Control
        Me.label_StateTax.Cursor = System.Windows.Forms.Cursors.Default
        Me.label_StateTax.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_StateTax.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.label_StateTax.Location = New System.Drawing.Point(16, 118)
        Me.label_StateTax.Name = "label_StateTax"
        Me.label_StateTax.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label_StateTax.Size = New System.Drawing.Size(171, 14)
        Me.label_StateTax.TabIndex = 61
        Me.label_StateTax.Text = "State Taxes withheld per week:"
        Me.label_StateTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'label_FederalTax
        '
        Me.label_FederalTax.BackColor = System.Drawing.SystemColors.Control
        Me.label_FederalTax.Cursor = System.Windows.Forms.Cursors.Default
        Me.label_FederalTax.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_FederalTax.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.label_FederalTax.Location = New System.Drawing.Point(16, 91)
        Me.label_FederalTax.Name = "label_FederalTax"
        Me.label_FederalTax.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label_FederalTax.Size = New System.Drawing.Size(171, 14)
        Me.label_FederalTax.TabIndex = 60
        Me.label_FederalTax.Text = "Federal Taxes withheld per week:"
        Me.label_FederalTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'label_Hours
        '
        Me.label_Hours.BackColor = System.Drawing.SystemColors.Control
        Me.label_Hours.Cursor = System.Windows.Forms.Cursors.Default
        Me.label_Hours.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_Hours.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.label_Hours.Location = New System.Drawing.Point(16, 64)
        Me.label_Hours.Name = "label_Hours"
        Me.label_Hours.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label_Hours.Size = New System.Drawing.Size(171, 14)
        Me.label_Hours.TabIndex = 59
        Me.label_Hours.Text = "Normal hours worked per week:"
        Me.label_Hours.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'label_Salary
        '
        Me.label_Salary.BackColor = System.Drawing.SystemColors.Control
        Me.label_Salary.Cursor = System.Windows.Forms.Cursors.Default
        Me.label_Salary.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_Salary.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.label_Salary.Location = New System.Drawing.Point(16, 37)
        Me.label_Salary.Name = "label_Salary"
        Me.label_Salary.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label_Salary.Size = New System.Drawing.Size(171, 14)
        Me.label_Salary.TabIndex = 58
        Me.label_Salary.Text = "Salary ........  Dollars per hour:"
        Me.label_Salary.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmd_Action3
        '
        Me.cmd_Action3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_Action3.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Action3.Image = Global.Machine_Shop.My.Resources.Resources._Exit
        Me.cmd_Action3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_Action3.Location = New System.Drawing.Point(321, 667)
        Me.cmd_Action3.Margin = New System.Windows.Forms.Padding(2)
        Me.cmd_Action3.Name = "cmd_Action3"
        Me.cmd_Action3.Size = New System.Drawing.Size(50, 48)
        Me.cmd_Action3.TabIndex = 144
        Me.cmd_Action3.Tag = "3"
        Me.cmd_Action3.Text = "Exit"
        Me.cmd_Action3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmd_Action3.UseVisualStyleBackColor = True
        '
        'cmd_Action2
        '
        Me.cmd_Action2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_Action2.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Action2.Image = Global.Machine_Shop.My.Resources.Resources.Cancel
        Me.cmd_Action2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_Action2.Location = New System.Drawing.Point(258, 667)
        Me.cmd_Action2.Margin = New System.Windows.Forms.Padding(2)
        Me.cmd_Action2.Name = "cmd_Action2"
        Me.cmd_Action2.Size = New System.Drawing.Size(50, 48)
        Me.cmd_Action2.TabIndex = 143
        Me.cmd_Action2.Tag = "2"
        Me.cmd_Action2.Text = "Cancel"
        Me.cmd_Action2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmd_Action2.UseVisualStyleBackColor = True
        '
        'frm_Payroll
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(905, 734)
        Me.Controls.Add(Me.cmd_Action3)
        Me.Controls.Add(Me.cmd_Action2)
        Me.Controls.Add(Me.fra_Income)
        Me.Controls.Add(Me.fra_SocSecurityLimits)
        Me.Controls.Add(Me.fra_PrintPaychecks)
        Me.Controls.Add(Me.fra_ContactInfo)
        Me.Controls.Add(Me.fra_List)
        Me.Controls.Add(Me.fra_Contacts)
        Me.Controls.Add(Me.lbl_Message)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Payroll"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Employees Payroll"
        Me.fra_SocSecurityLimits.ResumeLayout(False)
        Me.fra_SocSecurityLimits.PerformLayout()
        Me.fra_PrintPaychecks.ResumeLayout(False)
        Me.fra_PrintPaychecks.PerformLayout()
        Me.fra_ContactInfo.ResumeLayout(False)
        Me.fra_ContactInfo.PerformLayout()
        Me.fra_List.ResumeLayout(False)
        Me.fra_List.PerformLayout()
        Me.fra_Listbox1.ResumeLayout(False)
        Me.fra_Contacts.ResumeLayout(False)
        Me.fra_Contacts.PerformLayout()
        Me.fra_Income.ResumeLayout(False)
        Me.fra_Income.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents fra_SocSecurityLimits As System.Windows.Forms.GroupBox
    Public WithEvents label_SocSecPercent As System.Windows.Forms.Label
    Public WithEvents label_SocSecLimit As System.Windows.Forms.Label
    Public WithEvents fra_PrintPaychecks As System.Windows.Forms.GroupBox
    Public WithEvents fra_ContactInfo As System.Windows.Forms.GroupBox
    Public WithEvents label_State As System.Windows.Forms.Label
    Public WithEvents label_EMail As System.Windows.Forms.Label
    Public WithEvents label_Phone As System.Windows.Forms.Label
    Public WithEvents label_ZipCode As System.Windows.Forms.Label
    Public WithEvents label_City As System.Windows.Forms.Label
    Public WithEvents label_Address As System.Windows.Forms.Label
    Public WithEvents fra_List As System.Windows.Forms.GroupBox
    Public WithEvents fra_Listbox1 As System.Windows.Forms.GroupBox
    Public WithEvents opt_NonActive As System.Windows.Forms.RadioButton
    Public WithEvents opt_Active As System.Windows.Forms.RadioButton
    Public WithEvents fra_Contacts As System.Windows.Forms.GroupBox
    Public WithEvents cbx_Active As System.Windows.Forms.CheckBox
    Public WithEvents Label_ID As System.Windows.Forms.Label
    Public WithEvents lbl_ID As System.Windows.Forms.Label
    Public WithEvents label_SocSecurity As System.Windows.Forms.Label
    Public WithEvents label_Active As System.Windows.Forms.Label
    Public WithEvents label_Lastname As System.Windows.Forms.Label
    Public WithEvents label_FirstName As System.Windows.Forms.Label
    Public WithEvents label_BirthDate As System.Windows.Forms.Label
    Public WithEvents lbl_Message As System.Windows.Forms.Label
    Friend WithEvents lbl_Listbox As System.Windows.Forms.Label
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Public WithEvents label_MedicarePercent As System.Windows.Forms.Label
    Public WithEvents label_Emergency As System.Windows.Forms.Label
    Public WithEvents fra_Income As System.Windows.Forms.GroupBox
    Public WithEvents tbox_SalaryTemp As System.Windows.Forms.TextBox
    Public WithEvents label_SocialSecurity As System.Windows.Forms.Label
    Public WithEvents tbox_WeekHoursTemp As System.Windows.Forms.TextBox
    Public WithEvents label_MiscFunds As System.Windows.Forms.Label
    Public WithEvents label_StateTax As System.Windows.Forms.Label
    Public WithEvents label_FederalTax As System.Windows.Forms.Label
    Public WithEvents label_Hours As System.Windows.Forms.Label
    Public WithEvents label_Salary As System.Windows.Forms.Label
    Public WithEvents lbl_YearMisc As System.Windows.Forms.Label
    Public WithEvents lbl_YearSocSecurity As System.Windows.Forms.Label
    Public WithEvents lbl_YearStateTax As System.Windows.Forms.Label
    Public WithEvents lbl_YearFederalTax As System.Windows.Forms.Label
    Public WithEvents lbl_YearEarnings As System.Windows.Forms.Label
    Public WithEvents label_YearMisc As System.Windows.Forms.Label
    Public WithEvents label_YearSocSecurity As System.Windows.Forms.Label
    Public WithEvents label_YearStateTax As System.Windows.Forms.Label
    Public WithEvents label_YearFederalTax As System.Windows.Forms.Label
    Public WithEvents label_YearEarnings As System.Windows.Forms.Label
    Public WithEvents label_PaycheckTotals As System.Windows.Forms.Label
    Public WithEvents tbox_WeekMiscTemp As System.Windows.Forms.TextBox
    Public WithEvents tbox_WeekStateTaxTemp As System.Windows.Forms.TextBox
    Public WithEvents tbox_WeekFedTaxTemp As System.Windows.Forms.TextBox
    Public WithEvents lbl_BirthDate As Label
    Public WithEvents lbl_ZipCode As Label
    Public WithEvents lbl_Emergency As Label
    Public WithEvents lbl_Phone As Label
    Public WithEvents lbl_Address As Label
    Public WithEvents lbl_State As Label
    Public WithEvents lbl_City As Label
    Public WithEvents lbl_Email As Label
    Public WithEvents lbl_SocSecurity As Label
    Public WithEvents lbl_FirstName As Label
    Public WithEvents lbl_LastName As Label
    Public WithEvents lbl_WeekSocSecurityTemp As Label
    Public WithEvents lbl_WeekSocSecurity As Label
    Public WithEvents lbl_WeekMisc As Label
    Public WithEvents lbl_WeekHours As Label
    Public WithEvents lbl_WeekStateTax As Label
    Public WithEvents lbl_WeekFedTax As Label
    Public WithEvents lbl_Salary As Label
    Public WithEvents label_Adjusted As Label
    Public WithEvents label_Original As Label
    Public WithEvents tbox_MedicarePercent As TextBox
    Public WithEvents tbox_SocSecPercent As TextBox
    Public WithEvents tbox_SocSecWageLimit As TextBox
    Public WithEvents Label_PayCheckDate As System.Windows.Forms.Label
    Public WithEvents tbox_PayCheckDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmd_ClearAdjustments As System.Windows.Forms.Button
    Public WithEvents lbl_VacaYear3 As System.Windows.Forms.Label
    Public WithEvents lbl_VacaYear2 As System.Windows.Forms.Label
    Public WithEvents lbl_VacaYear1 As System.Windows.Forms.Label
    Public WithEvents lbl_VacaUsed1 As System.Windows.Forms.Label
    Public WithEvents lbl_VacaUsed2 As System.Windows.Forms.Label
    Public WithEvents lbl_VacaUsed3 As System.Windows.Forms.Label
    Public WithEvents lbl_VacaIssued3 As System.Windows.Forms.Label
    Public WithEvents lbl_VacaIssued2 As System.Windows.Forms.Label
    Public WithEvents lbl_VacaIssued1 As System.Windows.Forms.Label
    Public WithEvents Label_DaysUsed As System.Windows.Forms.Label
    Public WithEvents Label_DaysIssued As System.Windows.Forms.Label
    Public WithEvents Label_VacationData As System.Windows.Forms.Label
    Public WithEvents Label_Year As System.Windows.Forms.Label
    Friend WithEvents cmd_Action1 As System.Windows.Forms.Button
    Friend WithEvents cmd_Action0 As System.Windows.Forms.Button
    Friend WithEvents cmd_Action2 As System.Windows.Forms.Button
    Friend WithEvents cmd_Action3 As System.Windows.Forms.Button
    Friend WithEvents cmd_PrintAll As System.Windows.Forms.Button
    Friend WithEvents cmd_PrintIndividual As System.Windows.Forms.Button
End Class
