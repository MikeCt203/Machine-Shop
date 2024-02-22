<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Checkbook
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.colDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTransaction = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colChkno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPayee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCategory = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colMemo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCleared = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.fra_Transactions = New System.Windows.Forms.GroupBox()
        Me.lbl_Transaction = New System.Windows.Forms.Label()
        Me.fra_Options = New System.Windows.Forms.GroupBox()
        Me.lbl_FraFindTop = New System.Windows.Forms.Label()
        Me.lbl_FraTop = New System.Windows.Forms.Label()
        Me.lbl_Find = New System.Windows.Forms.Label()
        Me.cbx_Transaction = New System.Windows.Forms.ComboBox()
        Me.cbx_Category = New System.Windows.Forms.ComboBox()
        Me.DateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.tbox_Date1 = New System.Windows.Forms.MaskedTextBox()
        Me.tbox_Payee = New System.Windows.Forms.MaskedTextBox()
        Me.Label_Date = New System.Windows.Forms.Label()
        Me.Label_Transaction = New System.Windows.Forms.Label()
        Me.Label_Chkno = New System.Windows.Forms.Label()
        Me.tbox_Date2 = New System.Windows.Forms.MaskedTextBox()
        Me.Label_Payee = New System.Windows.Forms.Label()
        Me.Label_Category = New System.Windows.Forms.Label()
        Me.Label_Memo = New System.Windows.Forms.Label()
        Me.tbox_Memo = New System.Windows.Forms.MaskedTextBox()
        Me.Label_Amount = New System.Windows.Forms.Label()
        Me.tbox_Chkno1 = New System.Windows.Forms.TextBox()
        Me.tbox_Chkno2 = New System.Windows.Forms.TextBox()
        Me.tbox_Amount1 = New System.Windows.Forms.TextBox()
        Me.tbox_Amount2 = New System.Windows.Forms.TextBox()
        Me.fra_Search = New System.Windows.Forms.GroupBox()
        Me.cmd_SearchClose = New System.Windows.Forms.Button()
        Me.cmd_Search = New System.Windows.Forms.Button()
        Me.tbox_AmountCriteria2 = New System.Windows.Forms.TextBox()
        Me.tbox_AmountCriteria1 = New System.Windows.Forms.TextBox()
        Me.tbox_ChknoCriteria2 = New System.Windows.Forms.TextBox()
        Me.tbox_ChknoCriteria1 = New System.Windows.Forms.TextBox()
        Me.tbox_DateCriteria2 = New System.Windows.Forms.TextBox()
        Me.tbox_DateCriteria1 = New System.Windows.Forms.TextBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.lbl_Message = New System.Windows.Forms.Label()
        Me.fra_Criteria = New System.Windows.Forms.GroupBox()
        Me.lbl_CriteriaTop = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fra_Search.SuspendLayout()
        Me.fra_Criteria.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDate, Me.colTransaction, Me.colChkno, Me.colPayee, Me.colCategory, Me.colMemo, Me.colAmount, Me.colBalance, Me.colCleared})
        Me.DataGridView1.Location = New System.Drawing.Point(15, 16)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 25
        Me.DataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGridView1.Size = New System.Drawing.Size(864, 574)
        Me.DataGridView1.TabIndex = 0
        '
        'colDate
        '
        Me.colDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colDate.HeaderText = "Date"
        Me.colDate.MinimumWidth = 66
        Me.colDate.Name = "colDate"
        Me.colDate.Width = 66
        '
        'colTransaction
        '
        Me.colTransaction.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colTransaction.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.colTransaction.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.colTransaction.HeaderText = "Transactions"
        Me.colTransaction.MinimumWidth = 80
        Me.colTransaction.Name = "colTransaction"
        Me.colTransaction.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colTransaction.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colTransaction.Width = 80
        '
        'colChkno
        '
        Me.colChkno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colChkno.HeaderText = "Chkno"
        Me.colChkno.MinimumWidth = 50
        Me.colChkno.Name = "colChkno"
        Me.colChkno.Width = 50
        '
        'colPayee
        '
        Me.colPayee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colPayee.HeaderText = "Payee"
        Me.colPayee.MinimumWidth = 208
        Me.colPayee.Name = "colPayee"
        Me.colPayee.Width = 208
        '
        'colCategory
        '
        Me.colCategory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colCategory.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.colCategory.HeaderText = "Category"
        Me.colCategory.MinimumWidth = 106
        Me.colCategory.Name = "colCategory"
        Me.colCategory.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colCategory.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colCategory.Width = 106
        '
        'colMemo
        '
        Me.colMemo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colMemo.HeaderText = "Memo"
        Me.colMemo.MinimumWidth = 100
        Me.colMemo.Name = "colMemo"
        '
        'colAmount
        '
        Me.colAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colAmount.HeaderText = "Amount"
        Me.colAmount.MinimumWidth = 70
        Me.colAmount.Name = "colAmount"
        Me.colAmount.Width = 70
        '
        'colBalance
        '
        Me.colBalance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colBalance.HeaderText = "Balance"
        Me.colBalance.MinimumWidth = 90
        Me.colBalance.Name = "colBalance"
        Me.colBalance.Width = 90
        '
        'colCleared
        '
        Me.colCleared.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colCleared.HeaderText = "Cleared"
        Me.colCleared.MinimumWidth = 50
        Me.colCleared.Name = "colCleared"
        Me.colCleared.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colCleared.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colCleared.Width = 50
        '
        'fra_Transactions
        '
        Me.fra_Transactions.BackColor = System.Drawing.Color.PapayaWhip
        Me.fra_Transactions.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fra_Transactions.Location = New System.Drawing.Point(892, 8)
        Me.fra_Transactions.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.fra_Transactions.Name = "fra_Transactions"
        Me.fra_Transactions.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.fra_Transactions.Size = New System.Drawing.Size(128, 257)
        Me.fra_Transactions.TabIndex = 3
        Me.fra_Transactions.TabStop = False
        '
        'lbl_Transaction
        '
        Me.lbl_Transaction.Location = New System.Drawing.Point(885, 3)
        Me.lbl_Transaction.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_Transaction.Name = "lbl_Transaction"
        Me.lbl_Transaction.Size = New System.Drawing.Size(138, 12)
        Me.lbl_Transaction.TabIndex = 4
        '
        'fra_Options
        '
        Me.fra_Options.BackColor = System.Drawing.Color.PapayaWhip
        Me.fra_Options.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fra_Options.Location = New System.Drawing.Point(892, 335)
        Me.fra_Options.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.fra_Options.Name = "fra_Options"
        Me.fra_Options.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.fra_Options.Size = New System.Drawing.Size(128, 256)
        Me.fra_Options.TabIndex = 5
        Me.fra_Options.TabStop = False
        '
        'lbl_FraFindTop
        '
        Me.lbl_FraFindTop.Location = New System.Drawing.Point(885, 331)
        Me.lbl_FraFindTop.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_FraFindTop.Name = "lbl_FraFindTop"
        Me.lbl_FraFindTop.Size = New System.Drawing.Size(138, 12)
        Me.lbl_FraFindTop.TabIndex = 6
        '
        'lbl_FraTop
        '
        Me.lbl_FraTop.Location = New System.Drawing.Point(10, 590)
        Me.lbl_FraTop.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_FraTop.Name = "lbl_FraTop"
        Me.lbl_FraTop.Size = New System.Drawing.Size(1015, 10)
        Me.lbl_FraTop.TabIndex = 8
        Me.lbl_FraTop.Visible = False
        '
        'lbl_Find
        '
        Me.lbl_Find.AutoSize = True
        Me.lbl_Find.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Find.Location = New System.Drawing.Point(6, 11)
        Me.lbl_Find.Name = "lbl_Find"
        Me.lbl_Find.Size = New System.Drawing.Size(34, 16)
        Me.lbl_Find.TabIndex = 0
        Me.lbl_Find.Text = "Find"
        Me.lbl_Find.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbx_Transaction
        '
        Me.cbx_Transaction.BackColor = System.Drawing.SystemColors.Window
        Me.cbx_Transaction.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbx_Transaction.FormattingEnabled = True
        Me.cbx_Transaction.Items.AddRange(New Object() {"", "Check", "ATM", "Deposit", "Misc Charges", "Misc Additions", "Interest"})
        Me.cbx_Transaction.Location = New System.Drawing.Point(153, 35)
        Me.cbx_Transaction.Name = "cbx_Transaction"
        Me.cbx_Transaction.Size = New System.Drawing.Size(103, 23)
        Me.cbx_Transaction.TabIndex = 3
        Me.cbx_Transaction.TabStop = False
        '
        'cbx_Category
        '
        Me.cbx_Category.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbx_Category.FormattingEnabled = True
        Me.cbx_Category.Location = New System.Drawing.Point(594, 35)
        Me.cbx_Category.MaxDropDownItems = 4
        Me.cbx_Category.Name = "cbx_Category"
        Me.cbx_Category.Size = New System.Drawing.Size(124, 23)
        Me.cbx_Category.TabIndex = 7
        Me.cbx_Category.TabStop = False
        '
        'DateTimePicker
        '
        Me.DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker.Location = New System.Drawing.Point(10, 36)
        Me.DateTimePicker.Name = "DateTimePicker"
        Me.DateTimePicker.Size = New System.Drawing.Size(21, 21)
        Me.DateTimePicker.TabIndex = 7
        Me.DateTimePicker.TabStop = False
        Me.DateTimePicker.Visible = False
        '
        'tbox_Date1
        '
        Me.tbox_Date1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_Date1.Location = New System.Drawing.Point(70, 35)
        Me.tbox_Date1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.tbox_Date1.Mask = "00/00/0000"
        Me.tbox_Date1.Name = "tbox_Date1"
        Me.tbox_Date1.Size = New System.Drawing.Size(68, 21)
        Me.tbox_Date1.TabIndex = 0
        Me.tbox_Date1.ValidatingType = GetType(Date)
        '
        'tbox_Payee
        '
        Me.tbox_Payee.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_Payee.Location = New System.Drawing.Point(379, 35)
        Me.tbox_Payee.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.tbox_Payee.Name = "tbox_Payee"
        Me.tbox_Payee.Size = New System.Drawing.Size(200, 21)
        Me.tbox_Payee.TabIndex = 6
        Me.tbox_Payee.TabStop = False
        '
        'Label_Date
        '
        Me.Label_Date.AutoSize = True
        Me.Label_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Date.Location = New System.Drawing.Point(82, 15)
        Me.Label_Date.Name = "Label_Date"
        Me.Label_Date.Size = New System.Drawing.Size(33, 15)
        Me.Label_Date.TabIndex = 13
        Me.Label_Date.Text = "Date"
        Me.Label_Date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Transaction
        '
        Me.Label_Transaction.AutoSize = True
        Me.Label_Transaction.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Transaction.Location = New System.Drawing.Point(163, 15)
        Me.Label_Transaction.Name = "Label_Transaction"
        Me.Label_Transaction.Size = New System.Drawing.Size(71, 15)
        Me.Label_Transaction.TabIndex = 14
        Me.Label_Transaction.Text = "Transaction"
        Me.Label_Transaction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Chkno
        '
        Me.Label_Chkno.AutoSize = True
        Me.Label_Chkno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Chkno.Location = New System.Drawing.Point(304, 15)
        Me.Label_Chkno.Name = "Label_Chkno"
        Me.Label_Chkno.Size = New System.Drawing.Size(42, 15)
        Me.Label_Chkno.TabIndex = 15
        Me.Label_Chkno.Text = "Chkno"
        Me.Label_Chkno.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbox_Date2
        '
        Me.tbox_Date2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_Date2.Location = New System.Drawing.Point(70, 63)
        Me.tbox_Date2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.tbox_Date2.Mask = "00/00/0000"
        Me.tbox_Date2.Name = "tbox_Date2"
        Me.tbox_Date2.Size = New System.Drawing.Size(68, 21)
        Me.tbox_Date2.TabIndex = 2
        Me.tbox_Date2.TabStop = False
        Me.tbox_Date2.ValidatingType = GetType(Date)
        Me.tbox_Date2.Visible = False
        '
        'Label_Payee
        '
        Me.Label_Payee.AutoSize = True
        Me.Label_Payee.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Payee.Location = New System.Drawing.Point(458, 15)
        Me.Label_Payee.Name = "Label_Payee"
        Me.Label_Payee.Size = New System.Drawing.Size(41, 15)
        Me.Label_Payee.TabIndex = 23
        Me.Label_Payee.Text = "Payee"
        Me.Label_Payee.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Category
        '
        Me.Label_Category.AutoSize = True
        Me.Label_Category.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Category.Location = New System.Drawing.Point(628, 15)
        Me.Label_Category.Name = "Label_Category"
        Me.Label_Category.Size = New System.Drawing.Size(55, 15)
        Me.Label_Category.TabIndex = 24
        Me.Label_Category.Text = "Category"
        Me.Label_Category.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Memo
        '
        Me.Label_Memo.AutoSize = True
        Me.Label_Memo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Memo.Location = New System.Drawing.Point(787, 15)
        Me.Label_Memo.Name = "Label_Memo"
        Me.Label_Memo.Size = New System.Drawing.Size(43, 15)
        Me.Label_Memo.TabIndex = 26
        Me.Label_Memo.Text = "Memo"
        Me.Label_Memo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbox_Memo
        '
        Me.tbox_Memo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_Memo.Location = New System.Drawing.Point(733, 35)
        Me.tbox_Memo.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.tbox_Memo.Name = "tbox_Memo"
        Me.tbox_Memo.Size = New System.Drawing.Size(152, 21)
        Me.tbox_Memo.TabIndex = 8
        Me.tbox_Memo.TabStop = False
        '
        'Label_Amount
        '
        Me.Label_Amount.AutoSize = True
        Me.Label_Amount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Amount.Location = New System.Drawing.Point(929, 15)
        Me.Label_Amount.Name = "Label_Amount"
        Me.Label_Amount.Size = New System.Drawing.Size(49, 15)
        Me.Label_Amount.TabIndex = 34
        Me.Label_Amount.Text = "Amount"
        Me.Label_Amount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbox_Chkno1
        '
        Me.tbox_Chkno1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_Chkno1.Location = New System.Drawing.Point(296, 35)
        Me.tbox_Chkno1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.tbox_Chkno1.Name = "tbox_Chkno1"
        Me.tbox_Chkno1.Size = New System.Drawing.Size(68, 21)
        Me.tbox_Chkno1.TabIndex = 4
        Me.tbox_Chkno1.TabStop = False
        '
        'tbox_Chkno2
        '
        Me.tbox_Chkno2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_Chkno2.Location = New System.Drawing.Point(296, 63)
        Me.tbox_Chkno2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.tbox_Chkno2.Name = "tbox_Chkno2"
        Me.tbox_Chkno2.Size = New System.Drawing.Size(68, 21)
        Me.tbox_Chkno2.TabIndex = 5
        Me.tbox_Chkno2.TabStop = False
        Me.tbox_Chkno2.Visible = False
        '
        'tbox_Amount1
        '
        Me.tbox_Amount1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_Amount1.Location = New System.Drawing.Point(925, 35)
        Me.tbox_Amount1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.tbox_Amount1.Name = "tbox_Amount1"
        Me.tbox_Amount1.Size = New System.Drawing.Size(68, 21)
        Me.tbox_Amount1.TabIndex = 9
        Me.tbox_Amount1.TabStop = False
        '
        'tbox_Amount2
        '
        Me.tbox_Amount2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_Amount2.Location = New System.Drawing.Point(925, 63)
        Me.tbox_Amount2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.tbox_Amount2.Name = "tbox_Amount2"
        Me.tbox_Amount2.Size = New System.Drawing.Size(68, 21)
        Me.tbox_Amount2.TabIndex = 10
        Me.tbox_Amount2.TabStop = False
        Me.tbox_Amount2.Visible = False
        '
        'fra_Search
        '
        Me.fra_Search.BackColor = System.Drawing.Color.AliceBlue
        Me.fra_Search.Controls.Add(Me.cmd_SearchClose)
        Me.fra_Search.Controls.Add(Me.cmd_Search)
        Me.fra_Search.Controls.Add(Me.tbox_AmountCriteria2)
        Me.fra_Search.Controls.Add(Me.tbox_AmountCriteria1)
        Me.fra_Search.Controls.Add(Me.tbox_ChknoCriteria2)
        Me.fra_Search.Controls.Add(Me.tbox_ChknoCriteria1)
        Me.fra_Search.Controls.Add(Me.tbox_DateCriteria2)
        Me.fra_Search.Controls.Add(Me.tbox_DateCriteria1)
        Me.fra_Search.Controls.Add(Me.ListBox1)
        Me.fra_Search.Controls.Add(Me.tbox_Amount2)
        Me.fra_Search.Controls.Add(Me.tbox_Amount1)
        Me.fra_Search.Controls.Add(Me.tbox_Chkno2)
        Me.fra_Search.Controls.Add(Me.tbox_Chkno1)
        Me.fra_Search.Controls.Add(Me.Label_Amount)
        Me.fra_Search.Controls.Add(Me.tbox_Memo)
        Me.fra_Search.Controls.Add(Me.Label_Memo)
        Me.fra_Search.Controls.Add(Me.Label_Category)
        Me.fra_Search.Controls.Add(Me.Label_Payee)
        Me.fra_Search.Controls.Add(Me.tbox_Date2)
        Me.fra_Search.Controls.Add(Me.Label_Chkno)
        Me.fra_Search.Controls.Add(Me.Label_Transaction)
        Me.fra_Search.Controls.Add(Me.Label_Date)
        Me.fra_Search.Controls.Add(Me.tbox_Payee)
        Me.fra_Search.Controls.Add(Me.tbox_Date1)
        Me.fra_Search.Controls.Add(Me.DateTimePicker)
        Me.fra_Search.Controls.Add(Me.cbx_Category)
        Me.fra_Search.Controls.Add(Me.cbx_Transaction)
        Me.fra_Search.Controls.Add(Me.lbl_Find)
        Me.fra_Search.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fra_Search.Location = New System.Drawing.Point(15, 596)
        Me.fra_Search.Name = "fra_Search"
        Me.fra_Search.Size = New System.Drawing.Size(1005, 152)
        Me.fra_Search.TabIndex = 10
        Me.fra_Search.TabStop = False
        Me.fra_Search.Visible = False
        '
        'cmd_SearchClose
        '
        Me.cmd_SearchClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_SearchClose.Location = New System.Drawing.Point(915, 115)
        Me.cmd_SearchClose.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cmd_SearchClose.Name = "cmd_SearchClose"
        Me.cmd_SearchClose.Size = New System.Drawing.Size(80, 26)
        Me.cmd_SearchClose.TabIndex = 63
        Me.cmd_SearchClose.TabStop = False
        Me.cmd_SearchClose.Text = "Close"
        Me.cmd_SearchClose.UseVisualStyleBackColor = True
        '
        'cmd_Search
        '
        Me.cmd_Search.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Search.Location = New System.Drawing.Point(10, 115)
        Me.cmd_Search.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cmd_Search.Name = "cmd_Search"
        Me.cmd_Search.Size = New System.Drawing.Size(80, 26)
        Me.cmd_Search.TabIndex = 62
        Me.cmd_Search.TabStop = False
        Me.cmd_Search.Text = "Search"
        Me.cmd_Search.UseVisualStyleBackColor = True
        Me.cmd_Search.Visible = False
        '
        'tbox_AmountCriteria2
        '
        Me.tbox_AmountCriteria2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_AmountCriteria2.Location = New System.Drawing.Point(900, 64)
        Me.tbox_AmountCriteria2.Name = "tbox_AmountCriteria2"
        Me.tbox_AmountCriteria2.Size = New System.Drawing.Size(20, 20)
        Me.tbox_AmountCriteria2.TabIndex = 61
        Me.tbox_AmountCriteria2.TabStop = False
        Me.tbox_AmountCriteria2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbox_AmountCriteria2.Visible = False
        '
        'tbox_AmountCriteria1
        '
        Me.tbox_AmountCriteria1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_AmountCriteria1.Location = New System.Drawing.Point(900, 36)
        Me.tbox_AmountCriteria1.Name = "tbox_AmountCriteria1"
        Me.tbox_AmountCriteria1.Size = New System.Drawing.Size(20, 20)
        Me.tbox_AmountCriteria1.TabIndex = 60
        Me.tbox_AmountCriteria1.TabStop = False
        Me.tbox_AmountCriteria1.Text = "="
        Me.tbox_AmountCriteria1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbox_ChknoCriteria2
        '
        Me.tbox_ChknoCriteria2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_ChknoCriteria2.Location = New System.Drawing.Point(271, 64)
        Me.tbox_ChknoCriteria2.Name = "tbox_ChknoCriteria2"
        Me.tbox_ChknoCriteria2.Size = New System.Drawing.Size(20, 20)
        Me.tbox_ChknoCriteria2.TabIndex = 59
        Me.tbox_ChknoCriteria2.TabStop = False
        Me.tbox_ChknoCriteria2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbox_ChknoCriteria2.Visible = False
        '
        'tbox_ChknoCriteria1
        '
        Me.tbox_ChknoCriteria1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_ChknoCriteria1.Location = New System.Drawing.Point(271, 36)
        Me.tbox_ChknoCriteria1.Name = "tbox_ChknoCriteria1"
        Me.tbox_ChknoCriteria1.Size = New System.Drawing.Size(20, 20)
        Me.tbox_ChknoCriteria1.TabIndex = 58
        Me.tbox_ChknoCriteria1.TabStop = False
        Me.tbox_ChknoCriteria1.Text = "="
        Me.tbox_ChknoCriteria1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbox_DateCriteria2
        '
        Me.tbox_DateCriteria2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_DateCriteria2.Location = New System.Drawing.Point(45, 64)
        Me.tbox_DateCriteria2.Name = "tbox_DateCriteria2"
        Me.tbox_DateCriteria2.Size = New System.Drawing.Size(20, 20)
        Me.tbox_DateCriteria2.TabIndex = 57
        Me.tbox_DateCriteria2.TabStop = False
        Me.tbox_DateCriteria2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbox_DateCriteria2.Visible = False
        '
        'tbox_DateCriteria1
        '
        Me.tbox_DateCriteria1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_DateCriteria1.Location = New System.Drawing.Point(45, 36)
        Me.tbox_DateCriteria1.Name = "tbox_DateCriteria1"
        Me.tbox_DateCriteria1.Size = New System.Drawing.Size(20, 20)
        Me.tbox_DateCriteria1.TabIndex = 56
        Me.tbox_DateCriteria1.TabStop = False
        Me.tbox_DateCriteria1.Text = "="
        Me.tbox_DateCriteria1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 15
        Me.ListBox1.Location = New System.Drawing.Point(379, 56)
        Me.ListBox1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(200, 4)
        Me.ListBox1.TabIndex = 53
        Me.ListBox1.TabStop = False
        Me.ListBox1.Visible = False
        '
        'lbl_Message
        '
        Me.lbl_Message.BackColor = System.Drawing.Color.MintCream
        Me.lbl_Message.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Message.Location = New System.Drawing.Point(110, 715)
        Me.lbl_Message.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_Message.Name = "lbl_Message"
        Me.lbl_Message.Size = New System.Drawing.Size(814, 19)
        Me.lbl_Message.TabIndex = 53
        Me.lbl_Message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'fra_Criteria
        '
        Me.fra_Criteria.BackColor = System.Drawing.Color.NavajoWhite
        Me.fra_Criteria.Controls.Add(Me.lbl_CriteriaTop)
        Me.fra_Criteria.Location = New System.Drawing.Point(15, 749)
        Me.fra_Criteria.Name = "fra_Criteria"
        Me.fra_Criteria.Size = New System.Drawing.Size(1005, 30)
        Me.fra_Criteria.TabIndex = 55
        Me.fra_Criteria.TabStop = False
        '
        'lbl_CriteriaTop
        '
        Me.lbl_CriteriaTop.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_CriteriaTop.Location = New System.Drawing.Point(-5, 0)
        Me.lbl_CriteriaTop.Name = "lbl_CriteriaTop"
        Me.lbl_CriteriaTop.Size = New System.Drawing.Size(1017, 6)
        Me.lbl_CriteriaTop.TabIndex = 6
        '
        'frm_Checkbook
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1034, 787)
        Me.Controls.Add(Me.fra_Criteria)
        Me.Controls.Add(Me.lbl_Message)
        Me.Controls.Add(Me.lbl_FraTop)
        Me.Controls.Add(Me.fra_Search)
        Me.Controls.Add(Me.lbl_FraFindTop)
        Me.Controls.Add(Me.fra_Options)
        Me.Controls.Add(Me.lbl_Transaction)
        Me.Controls.Add(Me.fra_Transactions)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Checkbook"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Checkbook"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fra_Search.ResumeLayout(False)
        Me.fra_Search.PerformLayout()
        Me.fra_Criteria.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents fra_Transactions As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_Transaction As System.Windows.Forms.Label
    Friend WithEvents colDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTransaction As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colChkno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPayee As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCategory As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colMemo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCleared As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents fra_Options As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_FraFindTop As System.Windows.Forms.Label
    Friend WithEvents lbl_FraTop As System.Windows.Forms.Label
    Friend WithEvents lbl_Find As System.Windows.Forms.Label
    Friend WithEvents cbx_Transaction As System.Windows.Forms.ComboBox
    Friend WithEvents cbx_Category As System.Windows.Forms.ComboBox
    Friend WithEvents DateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents tbox_Date1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents tbox_Payee As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label_Date As System.Windows.Forms.Label
    Friend WithEvents Label_Transaction As System.Windows.Forms.Label
    Friend WithEvents Label_Chkno As System.Windows.Forms.Label
    Friend WithEvents tbox_Date2 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label_Payee As System.Windows.Forms.Label
    Friend WithEvents Label_Category As System.Windows.Forms.Label
    Friend WithEvents Label_Memo As System.Windows.Forms.Label
    Friend WithEvents tbox_Memo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label_Amount As System.Windows.Forms.Label
    Friend WithEvents tbox_Chkno1 As System.Windows.Forms.TextBox
    Friend WithEvents tbox_Chkno2 As System.Windows.Forms.TextBox
    Friend WithEvents tbox_Amount1 As System.Windows.Forms.TextBox
    Friend WithEvents tbox_Amount2 As System.Windows.Forms.TextBox
    Friend WithEvents fra_Search As System.Windows.Forms.GroupBox
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents lbl_Message As System.Windows.Forms.Label
    Friend WithEvents fra_Criteria As System.Windows.Forms.GroupBox
    Friend WithEvents tbox_DateCriteria2 As System.Windows.Forms.TextBox
    Friend WithEvents tbox_DateCriteria1 As System.Windows.Forms.TextBox
    Friend WithEvents lbl_CriteriaTop As System.Windows.Forms.Label
    Friend WithEvents tbox_ChknoCriteria2 As System.Windows.Forms.TextBox
    Friend WithEvents tbox_ChknoCriteria1 As System.Windows.Forms.TextBox
    Friend WithEvents tbox_AmountCriteria2 As System.Windows.Forms.TextBox
    Friend WithEvents tbox_AmountCriteria1 As System.Windows.Forms.TextBox
    Friend WithEvents cmd_SearchClose As System.Windows.Forms.Button
    Friend WithEvents cmd_Search As System.Windows.Forms.Button
End Class
