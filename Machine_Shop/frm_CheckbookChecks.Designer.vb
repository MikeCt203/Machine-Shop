<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_CheckbookChecks
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
        Me.lbl_CheckNo = New System.Windows.Forms.Label()
        Me.lbl_CheckNumber = New System.Windows.Forms.Label()
        Me.lbl_Date = New System.Windows.Forms.Label()
        Me.lbl_HeaderName = New System.Windows.Forms.Label()
        Me.lbl_HeaderAddress = New System.Windows.Forms.Label()
        Me.lbl_HeaderCity = New System.Windows.Forms.Label()
        Me.lbl_HeaderPhone = New System.Windows.Forms.Label()
        Me.lbl_Payto = New System.Windows.Forms.Label()
        Me.tbox_Payto = New System.Windows.Forms.TextBox()
        Me.lbl_Address = New System.Windows.Forms.Label()
        Me.tbox_Street = New System.Windows.Forms.TextBox()
        Me.tbox_City = New System.Windows.Forms.TextBox()
        Me.lbl_City = New System.Windows.Forms.Label()
        Me.tbox_State = New System.Windows.Forms.TextBox()
        Me.lbl_State = New System.Windows.Forms.Label()
        Me.lbl_ZipCode = New System.Windows.Forms.Label()
        Me.tbox_Memo = New System.Windows.Forms.TextBox()
        Me.lbl_Memo = New System.Windows.Forms.Label()
        Me.tbox_ZipCode = New System.Windows.Forms.MaskedTextBox()
        Me.tbox_Date = New System.Windows.Forms.MaskedTextBox()
        Me.Listbox_Payto = New System.Windows.Forms.ListBox()
        Me.lbl_Street = New System.Windows.Forms.Label()
        Me.fra_TaxCategory = New System.Windows.Forms.GroupBox()
        Me.lbl_fraTaxCategory = New System.Windows.Forms.Label()
        Me.fra_Documentation = New System.Windows.Forms.GroupBox()
        Me.lbl_Percent = New System.Windows.Forms.Label()
        Me.lbl_Discount = New System.Windows.Forms.Label()
        Me.lbl_Paid = New System.Windows.Forms.Label()
        Me.lbl_Amounts1 = New System.Windows.Forms.Label()
        Me.lbl_Amounts2 = New System.Windows.Forms.Label()
        Me.lbl_Invoice3 = New System.Windows.Forms.Label()
        Me.lbl_Dates = New System.Windows.Forms.Label()
        Me.lbl_Invoice2 = New System.Windows.Forms.Label()
        Me.lbl_Numbers = New System.Windows.Forms.Label()
        Me.lbl_Invoice1 = New System.Windows.Forms.Label()
        Me.lbl_No = New System.Windows.Forms.Label()
        Me.lbl_Item = New System.Windows.Forms.Label()
        Me.lbl_DocumentHeader = New System.Windows.Forms.Label()
        Me.cmd_Cancel = New System.Windows.Forms.Button()
        Me.cmd_Action = New System.Windows.Forms.Button()
        Me.cmd_Clear = New System.Windows.Forms.Button()
        Me.Panel_MsgBox = New System.Windows.Forms.Panel()
        Me.fra_Panel = New System.Windows.Forms.GroupBox()
        Me.lbl_PanelFrameTop = New System.Windows.Forms.Label()
        Me.fra_Msgbox = New System.Windows.Forms.GroupBox()
        Me.cmd_Action2 = New System.Windows.Forms.Button()
        Me.cmd_Action1 = New System.Windows.Forms.Button()
        Me.lbl_Message3 = New System.Windows.Forms.Label()
        Me.lbl_Message1 = New System.Windows.Forms.Label()
        Me.lbl_Message2 = New System.Windows.Forms.Label()
        Me.fra_Documentation.SuspendLayout()
        Me.Panel_MsgBox.SuspendLayout()
        Me.fra_Panel.SuspendLayout()
        Me.fra_Msgbox.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_CheckNo
        '
        Me.lbl_CheckNo.AutoSize = True
        Me.lbl_CheckNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_CheckNo.Location = New System.Drawing.Point(710, 6)
        Me.lbl_CheckNo.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_CheckNo.Name = "lbl_CheckNo"
        Me.lbl_CheckNo.Size = New System.Drawing.Size(73, 17)
        Me.lbl_CheckNo.TabIndex = 0
        Me.lbl_CheckNo.Text = "Check No:"
        '
        'lbl_CheckNumber
        '
        Me.lbl_CheckNumber.AutoSize = True
        Me.lbl_CheckNumber.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.lbl_CheckNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_CheckNumber.Location = New System.Drawing.Point(785, 6)
        Me.lbl_CheckNumber.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_CheckNumber.Name = "lbl_CheckNumber"
        Me.lbl_CheckNumber.Size = New System.Drawing.Size(0, 17)
        Me.lbl_CheckNumber.TabIndex = 2
        Me.lbl_CheckNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_Date
        '
        Me.lbl_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Date.Location = New System.Drawing.Point(510, 6)
        Me.lbl_Date.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_Date.Name = "lbl_Date"
        Me.lbl_Date.Size = New System.Drawing.Size(68, 17)
        Me.lbl_Date.TabIndex = 3
        Me.lbl_Date.Text = "Date"
        Me.lbl_Date.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lbl_HeaderName
        '
        Me.lbl_HeaderName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_HeaderName.Location = New System.Drawing.Point(40, 6)
        Me.lbl_HeaderName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_HeaderName.Name = "lbl_HeaderName"
        Me.lbl_HeaderName.Size = New System.Drawing.Size(270, 16)
        Me.lbl_HeaderName.TabIndex = 4
        Me.lbl_HeaderName.Text = "Company"
        Me.lbl_HeaderName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_HeaderAddress
        '
        Me.lbl_HeaderAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_HeaderAddress.Location = New System.Drawing.Point(85, 22)
        Me.lbl_HeaderAddress.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_HeaderAddress.Name = "lbl_HeaderAddress"
        Me.lbl_HeaderAddress.Size = New System.Drawing.Size(180, 16)
        Me.lbl_HeaderAddress.TabIndex = 5
        Me.lbl_HeaderAddress.Text = "Address"
        Me.lbl_HeaderAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_HeaderCity
        '
        Me.lbl_HeaderCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_HeaderCity.Location = New System.Drawing.Point(85, 39)
        Me.lbl_HeaderCity.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_HeaderCity.Name = "lbl_HeaderCity"
        Me.lbl_HeaderCity.Size = New System.Drawing.Size(180, 16)
        Me.lbl_HeaderCity.TabIndex = 6
        Me.lbl_HeaderCity.Text = "City, State, ZipCode"
        Me.lbl_HeaderCity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_HeaderPhone
        '
        Me.lbl_HeaderPhone.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_HeaderPhone.Location = New System.Drawing.Point(85, 55)
        Me.lbl_HeaderPhone.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_HeaderPhone.Name = "lbl_HeaderPhone"
        Me.lbl_HeaderPhone.Size = New System.Drawing.Size(180, 16)
        Me.lbl_HeaderPhone.TabIndex = 7
        Me.lbl_HeaderPhone.Text = "Phone"
        Me.lbl_HeaderPhone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Payto
        '
        Me.lbl_Payto.AutoSize = True
        Me.lbl_Payto.Font = New System.Drawing.Font("SansSerif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.lbl_Payto.Location = New System.Drawing.Point(42, 95)
        Me.lbl_Payto.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_Payto.Name = "lbl_Payto"
        Me.lbl_Payto.Size = New System.Drawing.Size(130, 16)
        Me.lbl_Payto.TabIndex = 8
        Me.lbl_Payto.Text = "Pay to the order of:"
        '
        'tbox_Payto
        '
        Me.tbox_Payto.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_Payto.Location = New System.Drawing.Point(173, 92)
        Me.tbox_Payto.Margin = New System.Windows.Forms.Padding(2)
        Me.tbox_Payto.Name = "tbox_Payto"
        Me.tbox_Payto.Size = New System.Drawing.Size(268, 23)
        Me.tbox_Payto.TabIndex = 9
        '
        'lbl_Address
        '
        Me.lbl_Address.AutoSize = True
        Me.lbl_Address.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Address.Location = New System.Drawing.Point(42, 130)
        Me.lbl_Address.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_Address.Name = "lbl_Address"
        Me.lbl_Address.Size = New System.Drawing.Size(108, 17)
        Me.lbl_Address.TabIndex = 10
        Me.lbl_Address.Text = "Mailing Address"
        '
        'tbox_Street
        '
        Me.tbox_Street.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_Street.Location = New System.Drawing.Point(205, 127)
        Me.tbox_Street.Margin = New System.Windows.Forms.Padding(2)
        Me.tbox_Street.Name = "tbox_Street"
        Me.tbox_Street.Size = New System.Drawing.Size(226, 23)
        Me.tbox_Street.TabIndex = 11
        '
        'tbox_City
        '
        Me.tbox_City.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_City.Location = New System.Drawing.Point(205, 162)
        Me.tbox_City.Margin = New System.Windows.Forms.Padding(2)
        Me.tbox_City.Name = "tbox_City"
        Me.tbox_City.Size = New System.Drawing.Size(99, 23)
        Me.tbox_City.TabIndex = 13
        '
        'lbl_City
        '
        Me.lbl_City.AutoSize = True
        Me.lbl_City.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_City.Location = New System.Drawing.Point(167, 165)
        Me.lbl_City.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_City.Name = "lbl_City"
        Me.lbl_City.Size = New System.Drawing.Size(35, 17)
        Me.lbl_City.TabIndex = 12
        Me.lbl_City.Text = "City:"
        '
        'tbox_State
        '
        Me.tbox_State.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_State.Location = New System.Drawing.Point(357, 162)
        Me.tbox_State.Margin = New System.Windows.Forms.Padding(2)
        Me.tbox_State.Name = "tbox_State"
        Me.tbox_State.Size = New System.Drawing.Size(24, 23)
        Me.tbox_State.TabIndex = 15
        '
        'lbl_State
        '
        Me.lbl_State.AutoSize = True
        Me.lbl_State.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_State.Location = New System.Drawing.Point(310, 165)
        Me.lbl_State.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_State.Name = "lbl_State"
        Me.lbl_State.Size = New System.Drawing.Size(45, 17)
        Me.lbl_State.TabIndex = 14
        Me.lbl_State.Text = "State:"
        '
        'lbl_ZipCode
        '
        Me.lbl_ZipCode.AutoSize = True
        Me.lbl_ZipCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ZipCode.Location = New System.Drawing.Point(389, 165)
        Me.lbl_ZipCode.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_ZipCode.Name = "lbl_ZipCode"
        Me.lbl_ZipCode.Size = New System.Drawing.Size(65, 17)
        Me.lbl_ZipCode.TabIndex = 16
        Me.lbl_ZipCode.Text = "ZipCode:"
        '
        'tbox_Memo
        '
        Me.tbox_Memo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_Memo.Location = New System.Drawing.Point(17, 223)
        Me.tbox_Memo.Margin = New System.Windows.Forms.Padding(2)
        Me.tbox_Memo.Name = "tbox_Memo"
        Me.tbox_Memo.Size = New System.Drawing.Size(137, 23)
        Me.tbox_Memo.TabIndex = 29
        '
        'lbl_Memo
        '
        Me.lbl_Memo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Memo.Location = New System.Drawing.Point(17, 204)
        Me.lbl_Memo.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_Memo.Name = "lbl_Memo"
        Me.lbl_Memo.Size = New System.Drawing.Size(137, 17)
        Me.lbl_Memo.TabIndex = 28
        Me.lbl_Memo.Text = "Memo"
        Me.lbl_Memo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'tbox_ZipCode
        '
        Me.tbox_ZipCode.AllowPromptAsInput = False
        Me.tbox_ZipCode.BackColor = System.Drawing.Color.White
        Me.tbox_ZipCode.Font = New System.Drawing.Font("SansSerif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.tbox_ZipCode.Location = New System.Drawing.Point(455, 162)
        Me.tbox_ZipCode.Mask = "00000-9999"
        Me.tbox_ZipCode.Name = "tbox_ZipCode"
        Me.tbox_ZipCode.Size = New System.Drawing.Size(72, 23)
        Me.tbox_ZipCode.SkipLiterals = False
        Me.tbox_ZipCode.TabIndex = 32
        Me.tbox_ZipCode.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'tbox_Date
        '
        Me.tbox_Date.AllowPromptAsInput = False
        Me.tbox_Date.BackColor = System.Drawing.Color.White
        Me.tbox_Date.Font = New System.Drawing.Font("SansSerif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.tbox_Date.Location = New System.Drawing.Point(505, 22)
        Me.tbox_Date.Mask = "00/00/0000"
        Me.tbox_Date.Name = "tbox_Date"
        Me.tbox_Date.Size = New System.Drawing.Size(78, 23)
        Me.tbox_Date.TabIndex = 33
        Me.tbox_Date.ValidatingType = GetType(Date)
        '
        'Listbox_Payto
        '
        Me.Listbox_Payto.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Listbox_Payto.FormattingEnabled = True
        Me.Listbox_Payto.ItemHeight = 17
        Me.Listbox_Payto.Location = New System.Drawing.Point(500, 92)
        Me.Listbox_Payto.Margin = New System.Windows.Forms.Padding(2)
        Me.Listbox_Payto.Name = "Listbox_Payto"
        Me.Listbox_Payto.Size = New System.Drawing.Size(20, 4)
        Me.Listbox_Payto.Sorted = True
        Me.Listbox_Payto.TabIndex = 34
        Me.Listbox_Payto.Visible = False
        '
        'lbl_Street
        '
        Me.lbl_Street.AutoSize = True
        Me.lbl_Street.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Street.Location = New System.Drawing.Point(154, 130)
        Me.lbl_Street.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_Street.Name = "lbl_Street"
        Me.lbl_Street.Size = New System.Drawing.Size(50, 17)
        Me.lbl_Street.TabIndex = 35
        Me.lbl_Street.Text = "Street:"
        '
        'fra_TaxCategory
        '
        Me.fra_TaxCategory.BackColor = System.Drawing.Color.Cornsilk
        Me.fra_TaxCategory.Location = New System.Drawing.Point(14, 255)
        Me.fra_TaxCategory.Margin = New System.Windows.Forms.Padding(2)
        Me.fra_TaxCategory.Name = "fra_TaxCategory"
        Me.fra_TaxCategory.Padding = New System.Windows.Forms.Padding(2)
        Me.fra_TaxCategory.Size = New System.Drawing.Size(817, 115)
        Me.fra_TaxCategory.TabIndex = 36
        Me.fra_TaxCategory.TabStop = False
        '
        'lbl_fraTaxCategory
        '
        Me.lbl_fraTaxCategory.Location = New System.Drawing.Point(10, 254)
        Me.lbl_fraTaxCategory.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_fraTaxCategory.Name = "lbl_fraTaxCategory"
        Me.lbl_fraTaxCategory.Size = New System.Drawing.Size(827, 6)
        Me.lbl_fraTaxCategory.TabIndex = 37
        '
        'fra_Documentation
        '
        Me.fra_Documentation.BackColor = System.Drawing.Color.Ivory
        Me.fra_Documentation.Controls.Add(Me.lbl_Percent)
        Me.fra_Documentation.Controls.Add(Me.lbl_Discount)
        Me.fra_Documentation.Controls.Add(Me.lbl_Paid)
        Me.fra_Documentation.Controls.Add(Me.lbl_Amounts1)
        Me.fra_Documentation.Controls.Add(Me.lbl_Amounts2)
        Me.fra_Documentation.Controls.Add(Me.lbl_Invoice3)
        Me.fra_Documentation.Controls.Add(Me.lbl_Dates)
        Me.fra_Documentation.Controls.Add(Me.lbl_Invoice2)
        Me.fra_Documentation.Controls.Add(Me.lbl_Numbers)
        Me.fra_Documentation.Controls.Add(Me.lbl_Invoice1)
        Me.fra_Documentation.Controls.Add(Me.lbl_No)
        Me.fra_Documentation.Controls.Add(Me.lbl_Item)
        Me.fra_Documentation.Location = New System.Drawing.Point(14, 377)
        Me.fra_Documentation.Margin = New System.Windows.Forms.Padding(2)
        Me.fra_Documentation.Name = "fra_Documentation"
        Me.fra_Documentation.Padding = New System.Windows.Forms.Padding(2)
        Me.fra_Documentation.Size = New System.Drawing.Size(817, 150)
        Me.fra_Documentation.TabIndex = 38
        Me.fra_Documentation.TabStop = False
        Me.fra_Documentation.Visible = False
        '
        'lbl_Percent
        '
        Me.lbl_Percent.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Percent.Location = New System.Drawing.Point(698, 31)
        Me.lbl_Percent.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_Percent.Name = "lbl_Percent"
        Me.lbl_Percent.Size = New System.Drawing.Size(80, 18)
        Me.lbl_Percent.TabIndex = 1
        Me.lbl_Percent.Text = "Percent"
        Me.lbl_Percent.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lbl_Discount
        '
        Me.lbl_Discount.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Discount.Location = New System.Drawing.Point(698, 15)
        Me.lbl_Discount.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_Discount.Name = "lbl_Discount"
        Me.lbl_Discount.Size = New System.Drawing.Size(80, 16)
        Me.lbl_Discount.TabIndex = 10
        Me.lbl_Discount.Text = "Discount"
        Me.lbl_Discount.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lbl_Paid
        '
        Me.lbl_Paid.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Paid.Location = New System.Drawing.Point(560, 31)
        Me.lbl_Paid.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_Paid.Name = "lbl_Paid"
        Me.lbl_Paid.Size = New System.Drawing.Size(80, 18)
        Me.lbl_Paid.TabIndex = 9
        Me.lbl_Paid.Text = "Paid"
        Me.lbl_Paid.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lbl_Amounts1
        '
        Me.lbl_Amounts1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Amounts1.Location = New System.Drawing.Point(560, 15)
        Me.lbl_Amounts1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_Amounts1.Name = "lbl_Amounts1"
        Me.lbl_Amounts1.Size = New System.Drawing.Size(80, 16)
        Me.lbl_Amounts1.TabIndex = 8
        Me.lbl_Amounts1.Text = "Amounts"
        Me.lbl_Amounts1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lbl_Amounts2
        '
        Me.lbl_Amounts2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Amounts2.Location = New System.Drawing.Point(417, 31)
        Me.lbl_Amounts2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_Amounts2.Name = "lbl_Amounts2"
        Me.lbl_Amounts2.Size = New System.Drawing.Size(80, 18)
        Me.lbl_Amounts2.TabIndex = 7
        Me.lbl_Amounts2.Text = "Amounts"
        Me.lbl_Amounts2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lbl_Invoice3
        '
        Me.lbl_Invoice3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Invoice3.Location = New System.Drawing.Point(417, 15)
        Me.lbl_Invoice3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_Invoice3.Name = "lbl_Invoice3"
        Me.lbl_Invoice3.Size = New System.Drawing.Size(80, 16)
        Me.lbl_Invoice3.TabIndex = 6
        Me.lbl_Invoice3.Text = "Invoice"
        Me.lbl_Invoice3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lbl_Dates
        '
        Me.lbl_Dates.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Dates.Location = New System.Drawing.Point(274, 31)
        Me.lbl_Dates.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_Dates.Name = "lbl_Dates"
        Me.lbl_Dates.Size = New System.Drawing.Size(80, 18)
        Me.lbl_Dates.TabIndex = 5
        Me.lbl_Dates.Text = "Dates"
        Me.lbl_Dates.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lbl_Invoice2
        '
        Me.lbl_Invoice2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Invoice2.Location = New System.Drawing.Point(274, 15)
        Me.lbl_Invoice2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_Invoice2.Name = "lbl_Invoice2"
        Me.lbl_Invoice2.Size = New System.Drawing.Size(80, 16)
        Me.lbl_Invoice2.TabIndex = 4
        Me.lbl_Invoice2.Text = "Invoice"
        Me.lbl_Invoice2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lbl_Numbers
        '
        Me.lbl_Numbers.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Numbers.Location = New System.Drawing.Point(131, 31)
        Me.lbl_Numbers.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_Numbers.Name = "lbl_Numbers"
        Me.lbl_Numbers.Size = New System.Drawing.Size(80, 18)
        Me.lbl_Numbers.TabIndex = 3
        Me.lbl_Numbers.Text = "Numbers"
        Me.lbl_Numbers.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lbl_Invoice1
        '
        Me.lbl_Invoice1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Invoice1.Location = New System.Drawing.Point(131, 15)
        Me.lbl_Invoice1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_Invoice1.Name = "lbl_Invoice1"
        Me.lbl_Invoice1.Size = New System.Drawing.Size(80, 16)
        Me.lbl_Invoice1.TabIndex = 2
        Me.lbl_Invoice1.Text = "Invoice"
        Me.lbl_Invoice1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lbl_No
        '
        Me.lbl_No.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_No.Location = New System.Drawing.Point(9, 31)
        Me.lbl_No.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_No.Name = "lbl_No"
        Me.lbl_No.Size = New System.Drawing.Size(80, 18)
        Me.lbl_No.TabIndex = 1
        Me.lbl_No.Text = "No"
        Me.lbl_No.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lbl_Item
        '
        Me.lbl_Item.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Item.Location = New System.Drawing.Point(9, 15)
        Me.lbl_Item.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_Item.Name = "lbl_Item"
        Me.lbl_Item.Size = New System.Drawing.Size(80, 17)
        Me.lbl_Item.TabIndex = 0
        Me.lbl_Item.Text = "Item"
        Me.lbl_Item.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lbl_DocumentHeader
        '
        Me.lbl_DocumentHeader.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_DocumentHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lbl_DocumentHeader.Location = New System.Drawing.Point(10, 376)
        Me.lbl_DocumentHeader.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_DocumentHeader.Name = "lbl_DocumentHeader"
        Me.lbl_DocumentHeader.Size = New System.Drawing.Size(827, 8)
        Me.lbl_DocumentHeader.TabIndex = 39
        Me.lbl_DocumentHeader.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmd_Cancel
        '
        Me.cmd_Cancel.BackColor = System.Drawing.Color.LightCyan
        Me.cmd_Cancel.Location = New System.Drawing.Point(487, 223)
        Me.cmd_Cancel.Margin = New System.Windows.Forms.Padding(2)
        Me.cmd_Cancel.Name = "cmd_Cancel"
        Me.cmd_Cancel.Size = New System.Drawing.Size(55, 23)
        Me.cmd_Cancel.TabIndex = 41
        Me.cmd_Cancel.Text = "Cancel"
        Me.cmd_Cancel.UseVisualStyleBackColor = False
        '
        'cmd_Action
        '
        Me.cmd_Action.BackColor = System.Drawing.Color.LightCyan
        Me.cmd_Action.Location = New System.Drawing.Point(559, 223)
        Me.cmd_Action.Margin = New System.Windows.Forms.Padding(2)
        Me.cmd_Action.Name = "cmd_Action"
        Me.cmd_Action.Size = New System.Drawing.Size(55, 23)
        Me.cmd_Action.TabIndex = 40
        Me.cmd_Action.Text = "Next"
        Me.cmd_Action.UseVisualStyleBackColor = False
        '
        'cmd_Clear
        '
        Me.cmd_Clear.Location = New System.Drawing.Point(450, 92)
        Me.cmd_Clear.Margin = New System.Windows.Forms.Padding(2)
        Me.cmd_Clear.Name = "cmd_Clear"
        Me.cmd_Clear.Size = New System.Drawing.Size(40, 22)
        Me.cmd_Clear.TabIndex = 43
        Me.cmd_Clear.Text = "Clear"
        Me.cmd_Clear.UseVisualStyleBackColor = True
        '
        'Panel_MsgBox
        '
        Me.Panel_MsgBox.BackColor = System.Drawing.Color.Black
        Me.Panel_MsgBox.Controls.Add(Me.fra_Panel)
        Me.Panel_MsgBox.Location = New System.Drawing.Point(125, 546)
        Me.Panel_MsgBox.Name = "Panel_MsgBox"
        Me.Panel_MsgBox.Size = New System.Drawing.Size(547, 153)
        Me.Panel_MsgBox.TabIndex = 45
        Me.Panel_MsgBox.Visible = False
        '
        'fra_Panel
        '
        Me.fra_Panel.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.fra_Panel.Controls.Add(Me.lbl_PanelFrameTop)
        Me.fra_Panel.Controls.Add(Me.fra_Msgbox)
        Me.fra_Panel.Location = New System.Drawing.Point(4, 4)
        Me.fra_Panel.Name = "fra_Panel"
        Me.fra_Panel.Size = New System.Drawing.Size(539, 145)
        Me.fra_Panel.TabIndex = 0
        Me.fra_Panel.TabStop = False
        '
        'lbl_PanelFrameTop
        '
        Me.lbl_PanelFrameTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lbl_PanelFrameTop.Location = New System.Drawing.Point(0, 0)
        Me.lbl_PanelFrameTop.Name = "lbl_PanelFrameTop"
        Me.lbl_PanelFrameTop.Size = New System.Drawing.Size(543, 11)
        Me.lbl_PanelFrameTop.TabIndex = 22
        '
        'fra_Msgbox
        '
        Me.fra_Msgbox.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.fra_Msgbox.Controls.Add(Me.cmd_Action2)
        Me.fra_Msgbox.Controls.Add(Me.cmd_Action1)
        Me.fra_Msgbox.Controls.Add(Me.lbl_Message3)
        Me.fra_Msgbox.Controls.Add(Me.lbl_Message1)
        Me.fra_Msgbox.Controls.Add(Me.lbl_Message2)
        Me.fra_Msgbox.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fra_Msgbox.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fra_Msgbox.Location = New System.Drawing.Point(12, 5)
        Me.fra_Msgbox.Name = "fra_Msgbox"
        Me.fra_Msgbox.Padding = New System.Windows.Forms.Padding(0)
        Me.fra_Msgbox.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fra_Msgbox.Size = New System.Drawing.Size(516, 129)
        Me.fra_Msgbox.TabIndex = 21
        Me.fra_Msgbox.TabStop = False
        '
        'cmd_Action2
        '
        Me.cmd_Action2.BackColor = System.Drawing.Color.Red
        Me.cmd_Action2.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmd_Action2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Action2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmd_Action2.Location = New System.Drawing.Point(281, 78)
        Me.cmd_Action2.Name = "cmd_Action2"
        Me.cmd_Action2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmd_Action2.Size = New System.Drawing.Size(86, 25)
        Me.cmd_Action2.TabIndex = 7
        Me.cmd_Action2.Tag = ""
        Me.cmd_Action2.Text = "Cancel"
        Me.cmd_Action2.UseVisualStyleBackColor = False
        '
        'cmd_Action1
        '
        Me.cmd_Action1.BackColor = System.Drawing.Color.Red
        Me.cmd_Action1.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmd_Action1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Action1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmd_Action1.Location = New System.Drawing.Point(150, 78)
        Me.cmd_Action1.Name = "cmd_Action1"
        Me.cmd_Action1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmd_Action1.Size = New System.Drawing.Size(86, 25)
        Me.cmd_Action1.TabIndex = 3
        Me.cmd_Action1.Text = "OK"
        Me.cmd_Action1.UseVisualStyleBackColor = False
        '
        'lbl_Message3
        '
        Me.lbl_Message3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbl_Message3.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_Message3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Message3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_Message3.Location = New System.Drawing.Point(5, 53)
        Me.lbl_Message3.Name = "lbl_Message3"
        Me.lbl_Message3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_Message3.Size = New System.Drawing.Size(508, 14)
        Me.lbl_Message3.TabIndex = 6
        Me.lbl_Message3.Text = "* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *" & _
    " * * * * * * * * * * *"
        Me.lbl_Message3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lbl_Message1
        '
        Me.lbl_Message1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbl_Message1.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_Message1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Message1.ForeColor = System.Drawing.Color.Red
        Me.lbl_Message1.Location = New System.Drawing.Point(5, 12)
        Me.lbl_Message1.Name = "lbl_Message1"
        Me.lbl_Message1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_Message1.Size = New System.Drawing.Size(508, 17)
        Me.lbl_Message1.TabIndex = 5
        Me.lbl_Message1.Text = "*  *  *  P R I N T E R  S E T U P  *  *  *"
        Me.lbl_Message1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lbl_Message2
        '
        Me.lbl_Message2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbl_Message2.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_Message2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Message2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_Message2.Location = New System.Drawing.Point(5, 32)
        Me.lbl_Message2.Name = "lbl_Message2"
        Me.lbl_Message2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_Message2.Size = New System.Drawing.Size(508, 17)
        Me.lbl_Message2.TabIndex = 4
        Me.lbl_Message2.Text = "Load checks in printer and press [OK] when ready"
        Me.lbl_Message2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frm_CheckbookChecks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(846, 709)
        Me.Controls.Add(Me.Panel_MsgBox)
        Me.Controls.Add(Me.cmd_Clear)
        Me.Controls.Add(Me.cmd_Cancel)
        Me.Controls.Add(Me.cmd_Action)
        Me.Controls.Add(Me.lbl_DocumentHeader)
        Me.Controls.Add(Me.fra_Documentation)
        Me.Controls.Add(Me.lbl_fraTaxCategory)
        Me.Controls.Add(Me.fra_TaxCategory)
        Me.Controls.Add(Me.lbl_Street)
        Me.Controls.Add(Me.Listbox_Payto)
        Me.Controls.Add(Me.tbox_Date)
        Me.Controls.Add(Me.tbox_ZipCode)
        Me.Controls.Add(Me.tbox_Memo)
        Me.Controls.Add(Me.lbl_Memo)
        Me.Controls.Add(Me.lbl_ZipCode)
        Me.Controls.Add(Me.tbox_State)
        Me.Controls.Add(Me.lbl_State)
        Me.Controls.Add(Me.tbox_City)
        Me.Controls.Add(Me.lbl_City)
        Me.Controls.Add(Me.tbox_Street)
        Me.Controls.Add(Me.lbl_Address)
        Me.Controls.Add(Me.tbox_Payto)
        Me.Controls.Add(Me.lbl_Payto)
        Me.Controls.Add(Me.lbl_HeaderPhone)
        Me.Controls.Add(Me.lbl_HeaderCity)
        Me.Controls.Add(Me.lbl_HeaderAddress)
        Me.Controls.Add(Me.lbl_HeaderName)
        Me.Controls.Add(Me.lbl_Date)
        Me.Controls.Add(Me.lbl_CheckNumber)
        Me.Controls.Add(Me.lbl_CheckNo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_CheckbookChecks"
        Me.Text = "     Checks"
        Me.fra_Documentation.ResumeLayout(False)
        Me.Panel_MsgBox.ResumeLayout(False)
        Me.fra_Panel.ResumeLayout(False)
        Me.fra_Msgbox.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_CheckNo As System.Windows.Forms.Label
    Friend WithEvents lbl_CheckNumber As System.Windows.Forms.Label
    Friend WithEvents lbl_Date As System.Windows.Forms.Label
    Friend WithEvents lbl_HeaderName As System.Windows.Forms.Label
    Friend WithEvents lbl_HeaderAddress As System.Windows.Forms.Label
    Friend WithEvents lbl_HeaderCity As System.Windows.Forms.Label
    Friend WithEvents lbl_HeaderPhone As System.Windows.Forms.Label
    Friend WithEvents lbl_Payto As System.Windows.Forms.Label
    Friend WithEvents tbox_Payto As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Address As System.Windows.Forms.Label
    Friend WithEvents tbox_Street As System.Windows.Forms.TextBox
    Friend WithEvents tbox_City As System.Windows.Forms.TextBox
    Friend WithEvents lbl_City As System.Windows.Forms.Label
    Friend WithEvents tbox_State As System.Windows.Forms.TextBox
    Friend WithEvents lbl_State As System.Windows.Forms.Label
    Friend WithEvents lbl_ZipCode As System.Windows.Forms.Label
    Friend WithEvents tbox_Memo As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Memo As System.Windows.Forms.Label
    Public WithEvents tbox_ZipCode As System.Windows.Forms.MaskedTextBox
    Public WithEvents tbox_Date As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Listbox_Payto As System.Windows.Forms.ListBox
    Friend WithEvents lbl_Street As System.Windows.Forms.Label
    Friend WithEvents fra_TaxCategory As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_fraTaxCategory As System.Windows.Forms.Label
    Friend WithEvents fra_Documentation As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_DocumentHeader As System.Windows.Forms.Label
    Friend WithEvents lbl_Percent As System.Windows.Forms.Label
    Friend WithEvents lbl_Discount As System.Windows.Forms.Label
    Friend WithEvents lbl_Paid As System.Windows.Forms.Label
    Friend WithEvents lbl_Amounts1 As System.Windows.Forms.Label
    Friend WithEvents lbl_Amounts2 As System.Windows.Forms.Label
    Friend WithEvents lbl_Invoice3 As System.Windows.Forms.Label
    Friend WithEvents lbl_Dates As System.Windows.Forms.Label
    Friend WithEvents lbl_Invoice2 As System.Windows.Forms.Label
    Friend WithEvents lbl_Numbers As System.Windows.Forms.Label
    Friend WithEvents lbl_Invoice1 As System.Windows.Forms.Label
    Friend WithEvents lbl_No As System.Windows.Forms.Label
    Friend WithEvents lbl_Item As System.Windows.Forms.Label
    Friend WithEvents cmd_Cancel As System.Windows.Forms.Button
    Friend WithEvents cmd_Action As System.Windows.Forms.Button
    Friend WithEvents cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Panel_MsgBox As System.Windows.Forms.Panel
    Friend WithEvents fra_Panel As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_PanelFrameTop As System.Windows.Forms.Label
    Public WithEvents fra_Msgbox As System.Windows.Forms.GroupBox
    Public WithEvents cmd_Action1 As System.Windows.Forms.Button
    Public WithEvents lbl_Message3 As System.Windows.Forms.Label
    Public WithEvents lbl_Message1 As System.Windows.Forms.Label
    Public WithEvents lbl_Message2 As System.Windows.Forms.Label
    Public WithEvents cmd_Action2 As System.Windows.Forms.Button
End Class
