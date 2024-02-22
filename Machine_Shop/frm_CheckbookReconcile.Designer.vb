<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_CheckbookReconcile
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
        Me.colDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTransaction = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colChkno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPayee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCategory = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colMemo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCleared = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewComboBoxColumn1 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewComboBoxColumn2 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.DebitClear = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DebitDate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DebitChkno = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DebitPayee = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DebitAmount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.CreditClear = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CreditDate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CreditChkno = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CreditPayee = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CreditAmount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lbl_PaymentAndChecks = New System.Windows.Forms.Label()
        Me.lbl_AllDeposits = New System.Windows.Forms.Label()
        Me.fra_Statement1 = New System.Windows.Forms.GroupBox()
        Me.lbl_StatementTop = New System.Windows.Forms.Label()
        Me.fra_Statement2 = New System.Windows.Forms.GroupBox()
        Me.lbl_Message1 = New System.Windows.Forms.Label()
        Me.tbox_StartBalance = New System.Windows.Forms.TextBox()
        Me.tbox_StatementDate = New System.Windows.Forms.MaskedTextBox()
        Me.tbox_EndBalance = New System.Windows.Forms.TextBox()
        Me.cmd_Cancel = New System.Windows.Forms.Button()
        Me.cmd_Proceed = New System.Windows.Forms.Button()
        Me.lbl_FormSplit = New System.Windows.Forms.Label()
        Me.lbl_InterestTop = New System.Windows.Forms.Label()
        Me.fra_ServiceCharge = New System.Windows.Forms.GroupBox()
        Me.tbox_ServiceDate = New System.Windows.Forms.MaskedTextBox()
        Me.tbox_ServiceCharge = New System.Windows.Forms.TextBox()
        Me.lbl_ServiceDate = New System.Windows.Forms.Label()
        Me.lbl_ServiceCharge = New System.Windows.Forms.Label()
        Me.fra_Interest = New System.Windows.Forms.GroupBox()
        Me.tbox_InterestDate = New System.Windows.Forms.MaskedTextBox()
        Me.tbox_InterestEarned = New System.Windows.Forms.TextBox()
        Me.lbl_InterestDate = New System.Windows.Forms.Label()
        Me.lbl_InterestEarned = New System.Windows.Forms.Label()
        Me.lbl_StatementDate = New System.Windows.Forms.Label()
        Me.lbl_EndingBalance = New System.Windows.Forms.Label()
        Me.Label_StartBalance = New System.Windows.Forms.Label()
        Me.lbl_SelectedValue1 = New System.Windows.Forms.Label()
        Me.lbl_SelectedValueDebit = New System.Windows.Forms.Label()
        Me.lbl_DebitItems = New System.Windows.Forms.Label()
        Me.lbl_TotalItems1 = New System.Windows.Forms.Label()
        Me.lbl_CreditItems = New System.Windows.Forms.Label()
        Me.lbl_TotalItems2 = New System.Windows.Forms.Label()
        Me.lbl_SelectedValueCredit = New System.Windows.Forms.Label()
        Me.lbl_SelectedValue2 = New System.Windows.Forms.Label()
        Me.lbl_SelectedCountDebit = New System.Windows.Forms.Label()
        Me.lbl_SelectedCount1 = New System.Windows.Forms.Label()
        Me.lbl_SelectedCountCredit = New System.Windows.Forms.Label()
        Me.lbl_SelectedCount2 = New System.Windows.Forms.Label()
        Me.lbl_ClearedBalance = New System.Windows.Forms.Label()
        Me.Label_ClearedBalance = New System.Windows.Forms.Label()
        Me.lbl_EndBalance = New System.Windows.Forms.Label()
        Me.Label_EndBalance = New System.Windows.Forms.Label()
        Me.lbl_Difference = New System.Windows.Forms.Label()
        Me.Label_Difference = New System.Windows.Forms.Label()
        Me.cmd_Finish = New System.Windows.Forms.Button()
        Me.cmd_Abort = New System.Windows.Forms.Button()
        Me.fra_Statement1.SuspendLayout()
        Me.fra_Statement2.SuspendLayout()
        Me.fra_ServiceCharge.SuspendLayout()
        Me.fra_Interest.SuspendLayout()
        Me.SuspendLayout()
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
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn1.HeaderText = "Date"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 66
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 66
        '
        'DataGridViewComboBoxColumn1
        '
        Me.DataGridViewComboBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewComboBoxColumn1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.DataGridViewComboBoxColumn1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.DataGridViewComboBoxColumn1.HeaderText = "Transactions"
        Me.DataGridViewComboBoxColumn1.MinimumWidth = 80
        Me.DataGridViewComboBoxColumn1.Name = "DataGridViewComboBoxColumn1"
        Me.DataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewComboBoxColumn1.Width = 80
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn2.HeaderText = "Chkno"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 50
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 50
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn3.HeaderText = "Payee"
        Me.DataGridViewTextBoxColumn3.MinimumWidth = 208
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 208
        '
        'DataGridViewComboBoxColumn2
        '
        Me.DataGridViewComboBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewComboBoxColumn2.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.DataGridViewComboBoxColumn2.HeaderText = "Category"
        Me.DataGridViewComboBoxColumn2.MinimumWidth = 106
        Me.DataGridViewComboBoxColumn2.Name = "DataGridViewComboBoxColumn2"
        Me.DataGridViewComboBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewComboBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewComboBoxColumn2.Width = 106
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn4.HeaderText = "Memo"
        Me.DataGridViewTextBoxColumn4.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn5.HeaderText = "Amount"
        Me.DataGridViewTextBoxColumn5.MinimumWidth = 70
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 70
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn6.HeaderText = "Balance"
        Me.DataGridViewTextBoxColumn6.MinimumWidth = 90
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 90
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewCheckBoxColumn1.HeaderText = "Cleared"
        Me.DataGridViewCheckBoxColumn1.MinimumWidth = 50
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewCheckBoxColumn1.Width = 50
        '
        'ListView1
        '
        Me.ListView1.CheckBoxes = True
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.DebitClear, Me.DebitDate, Me.DebitChkno, Me.DebitPayee, Me.DebitAmount})
        Me.ListView1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.Location = New System.Drawing.Point(15, 40)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(493, 500)
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'DebitClear
        '
        Me.DebitClear.Text = "C"
        Me.DebitClear.Width = 19
        '
        'DebitDate
        '
        Me.DebitDate.Text = "Date"
        Me.DebitDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.DebitDate.Width = 83
        '
        'DebitChkno
        '
        Me.DebitChkno.Text = "Chkno"
        Me.DebitChkno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DebitPayee
        '
        Me.DebitPayee.Text = "Payee"
        Me.DebitPayee.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.DebitPayee.Width = 230
        '
        'DebitAmount
        '
        Me.DebitAmount.Text = "Amount"
        Me.DebitAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.DebitAmount.Width = 80
        '
        'ListView2
        '
        Me.ListView2.CheckBoxes = True
        Me.ListView2.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.CreditClear, Me.CreditDate, Me.CreditChkno, Me.CreditPayee, Me.CreditAmount})
        Me.ListView2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView2.Location = New System.Drawing.Point(525, 40)
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(493, 500)
        Me.ListView2.TabIndex = 1
        Me.ListView2.UseCompatibleStateImageBehavior = False
        Me.ListView2.View = System.Windows.Forms.View.Details
        '
        'CreditClear
        '
        Me.CreditClear.Text = "C"
        Me.CreditClear.Width = 19
        '
        'CreditDate
        '
        Me.CreditDate.Text = "Date"
        Me.CreditDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.CreditDate.Width = 83
        '
        'CreditChkno
        '
        Me.CreditChkno.Text = "Chkno"
        Me.CreditChkno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CreditPayee
        '
        Me.CreditPayee.Text = "Payee"
        Me.CreditPayee.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.CreditPayee.Width = 230
        '
        'CreditAmount
        '
        Me.CreditAmount.Text = "Amount"
        Me.CreditAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.CreditAmount.Width = 80
        '
        'lbl_PaymentAndChecks
        '
        Me.lbl_PaymentAndChecks.AutoSize = True
        Me.lbl_PaymentAndChecks.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_PaymentAndChecks.ForeColor = System.Drawing.Color.DarkGreen
        Me.lbl_PaymentAndChecks.Location = New System.Drawing.Point(25, 21)
        Me.lbl_PaymentAndChecks.Name = "lbl_PaymentAndChecks"
        Me.lbl_PaymentAndChecks.Size = New System.Drawing.Size(167, 15)
        Me.lbl_PaymentAndChecks.TabIndex = 2
        Me.lbl_PaymentAndChecks.Text = "All Payments and Checks"
        '
        'lbl_AllDeposits
        '
        Me.lbl_AllDeposits.AutoSize = True
        Me.lbl_AllDeposits.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_AllDeposits.ForeColor = System.Drawing.Color.DarkGreen
        Me.lbl_AllDeposits.Location = New System.Drawing.Point(535, 21)
        Me.lbl_AllDeposits.Name = "lbl_AllDeposits"
        Me.lbl_AllDeposits.Size = New System.Drawing.Size(83, 15)
        Me.lbl_AllDeposits.TabIndex = 3
        Me.lbl_AllDeposits.Text = "All Deposits"
        '
        'fra_Statement1
        '
        Me.fra_Statement1.BackColor = System.Drawing.Color.Teal
        Me.fra_Statement1.Controls.Add(Me.lbl_StatementTop)
        Me.fra_Statement1.Controls.Add(Me.fra_Statement2)
        Me.fra_Statement1.Location = New System.Drawing.Point(289, 110)
        Me.fra_Statement1.Margin = New System.Windows.Forms.Padding(2)
        Me.fra_Statement1.Name = "fra_Statement1"
        Me.fra_Statement1.Padding = New System.Windows.Forms.Padding(2)
        Me.fra_Statement1.Size = New System.Drawing.Size(472, 366)
        Me.fra_Statement1.TabIndex = 5
        Me.fra_Statement1.TabStop = False
        Me.fra_Statement1.Visible = False
        '
        'lbl_StatementTop
        '
        Me.lbl_StatementTop.BackColor = System.Drawing.Color.Teal
        Me.lbl_StatementTop.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_StatementTop.ForeColor = System.Drawing.Color.White
        Me.lbl_StatementTop.Location = New System.Drawing.Point(0, 0)
        Me.lbl_StatementTop.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_StatementTop.Name = "lbl_StatementTop"
        Me.lbl_StatementTop.Size = New System.Drawing.Size(472, 26)
        Me.lbl_StatementTop.TabIndex = 7
        Me.lbl_StatementTop.Text = "Statement Information"
        Me.lbl_StatementTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'fra_Statement2
        '
        Me.fra_Statement2.BackColor = System.Drawing.Color.AliceBlue
        Me.fra_Statement2.Controls.Add(Me.lbl_Message1)
        Me.fra_Statement2.Controls.Add(Me.tbox_StartBalance)
        Me.fra_Statement2.Controls.Add(Me.tbox_StatementDate)
        Me.fra_Statement2.Controls.Add(Me.tbox_EndBalance)
        Me.fra_Statement2.Controls.Add(Me.cmd_Cancel)
        Me.fra_Statement2.Controls.Add(Me.cmd_Proceed)
        Me.fra_Statement2.Controls.Add(Me.lbl_FormSplit)
        Me.fra_Statement2.Controls.Add(Me.lbl_InterestTop)
        Me.fra_Statement2.Controls.Add(Me.fra_ServiceCharge)
        Me.fra_Statement2.Controls.Add(Me.fra_Interest)
        Me.fra_Statement2.Controls.Add(Me.lbl_StatementDate)
        Me.fra_Statement2.Controls.Add(Me.lbl_EndingBalance)
        Me.fra_Statement2.Controls.Add(Me.Label_StartBalance)
        Me.fra_Statement2.Location = New System.Drawing.Point(11, 4)
        Me.fra_Statement2.Margin = New System.Windows.Forms.Padding(2)
        Me.fra_Statement2.Name = "fra_Statement2"
        Me.fra_Statement2.Padding = New System.Windows.Forms.Padding(2)
        Me.fra_Statement2.Size = New System.Drawing.Size(450, 349)
        Me.fra_Statement2.TabIndex = 0
        Me.fra_Statement2.TabStop = False
        '
        'lbl_Message1
        '
        Me.lbl_Message1.ForeColor = System.Drawing.Color.DarkRed
        Me.lbl_Message1.Location = New System.Drawing.Point(5, 331)
        Me.lbl_Message1.Name = "lbl_Message1"
        Me.lbl_Message1.Size = New System.Drawing.Size(440, 13)
        Me.lbl_Message1.TabIndex = 21
        Me.lbl_Message1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbox_StartBalance
        '
        Me.tbox_StartBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_StartBalance.Location = New System.Drawing.Point(138, 37)
        Me.tbox_StartBalance.Margin = New System.Windows.Forms.Padding(2)
        Me.tbox_StartBalance.Name = "tbox_StartBalance"
        Me.tbox_StartBalance.Size = New System.Drawing.Size(100, 23)
        Me.tbox_StartBalance.TabIndex = 20
        '
        'tbox_StatementDate
        '
        Me.tbox_StatementDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_StatementDate.Location = New System.Drawing.Point(299, 58)
        Me.tbox_StatementDate.Margin = New System.Windows.Forms.Padding(2)
        Me.tbox_StatementDate.Mask = "00/00/0000"
        Me.tbox_StatementDate.Name = "tbox_StatementDate"
        Me.tbox_StatementDate.Size = New System.Drawing.Size(72, 22)
        Me.tbox_StatementDate.TabIndex = 19
        Me.tbox_StatementDate.ValidatingType = GetType(Date)
        '
        'tbox_EndBalance
        '
        Me.tbox_EndBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_EndBalance.Location = New System.Drawing.Point(138, 65)
        Me.tbox_EndBalance.Margin = New System.Windows.Forms.Padding(2)
        Me.tbox_EndBalance.Name = "tbox_EndBalance"
        Me.tbox_EndBalance.Size = New System.Drawing.Size(100, 23)
        Me.tbox_EndBalance.TabIndex = 12
        '
        'cmd_Cancel
        '
        Me.cmd_Cancel.BackColor = System.Drawing.Color.SeaShell
        Me.cmd_Cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Cancel.Location = New System.Drawing.Point(333, 297)
        Me.cmd_Cancel.Margin = New System.Windows.Forms.Padding(2)
        Me.cmd_Cancel.Name = "cmd_Cancel"
        Me.cmd_Cancel.Size = New System.Drawing.Size(79, 28)
        Me.cmd_Cancel.TabIndex = 11
        Me.cmd_Cancel.Text = "Cancel"
        Me.cmd_Cancel.UseVisualStyleBackColor = False
        '
        'cmd_Proceed
        '
        Me.cmd_Proceed.BackColor = System.Drawing.Color.SeaShell
        Me.cmd_Proceed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Proceed.Location = New System.Drawing.Point(238, 297)
        Me.cmd_Proceed.Margin = New System.Windows.Forms.Padding(2)
        Me.cmd_Proceed.Name = "cmd_Proceed"
        Me.cmd_Proceed.Size = New System.Drawing.Size(79, 28)
        Me.cmd_Proceed.TabIndex = 10
        Me.cmd_Proceed.Text = "Proceed"
        Me.cmd_Proceed.UseVisualStyleBackColor = False
        '
        'lbl_FormSplit
        '
        Me.lbl_FormSplit.Location = New System.Drawing.Point(19, 193)
        Me.lbl_FormSplit.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_FormSplit.Name = "lbl_FormSplit"
        Me.lbl_FormSplit.Size = New System.Drawing.Size(412, 16)
        Me.lbl_FormSplit.TabIndex = 9
        '
        'lbl_InterestTop
        '
        Me.lbl_InterestTop.Location = New System.Drawing.Point(19, 102)
        Me.lbl_InterestTop.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_InterestTop.Name = "lbl_InterestTop"
        Me.lbl_InterestTop.Size = New System.Drawing.Size(412, 16)
        Me.lbl_InterestTop.TabIndex = 8
        '
        'fra_ServiceCharge
        '
        Me.fra_ServiceCharge.BackColor = System.Drawing.Color.GhostWhite
        Me.fra_ServiceCharge.Controls.Add(Me.tbox_ServiceDate)
        Me.fra_ServiceCharge.Controls.Add(Me.tbox_ServiceCharge)
        Me.fra_ServiceCharge.Controls.Add(Me.lbl_ServiceDate)
        Me.fra_ServiceCharge.Controls.Add(Me.lbl_ServiceCharge)
        Me.fra_ServiceCharge.Location = New System.Drawing.Point(22, 204)
        Me.fra_ServiceCharge.Margin = New System.Windows.Forms.Padding(2)
        Me.fra_ServiceCharge.Name = "fra_ServiceCharge"
        Me.fra_ServiceCharge.Padding = New System.Windows.Forms.Padding(2)
        Me.fra_ServiceCharge.Size = New System.Drawing.Size(405, 79)
        Me.fra_ServiceCharge.TabIndex = 4
        Me.fra_ServiceCharge.TabStop = False
        '
        'tbox_ServiceDate
        '
        Me.tbox_ServiceDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_ServiceDate.Location = New System.Drawing.Point(119, 46)
        Me.tbox_ServiceDate.Margin = New System.Windows.Forms.Padding(2)
        Me.tbox_ServiceDate.Mask = "00/00/0000"
        Me.tbox_ServiceDate.Name = "tbox_ServiceDate"
        Me.tbox_ServiceDate.Size = New System.Drawing.Size(72, 22)
        Me.tbox_ServiceDate.TabIndex = 20
        Me.tbox_ServiceDate.ValidatingType = GetType(Date)
        '
        'tbox_ServiceCharge
        '
        Me.tbox_ServiceCharge.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_ServiceCharge.Location = New System.Drawing.Point(119, 16)
        Me.tbox_ServiceCharge.Margin = New System.Windows.Forms.Padding(2)
        Me.tbox_ServiceCharge.Name = "tbox_ServiceCharge"
        Me.tbox_ServiceCharge.Size = New System.Drawing.Size(80, 23)
        Me.tbox_ServiceCharge.TabIndex = 16
        '
        'lbl_ServiceDate
        '
        Me.lbl_ServiceDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ServiceDate.Location = New System.Drawing.Point(12, 48)
        Me.lbl_ServiceDate.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_ServiceDate.Name = "lbl_ServiceDate"
        Me.lbl_ServiceDate.Size = New System.Drawing.Size(110, 17)
        Me.lbl_ServiceDate.TabIndex = 2
        Me.lbl_ServiceDate.Text = "Service Date:"
        Me.lbl_ServiceDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_ServiceCharge
        '
        Me.lbl_ServiceCharge.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ServiceCharge.Location = New System.Drawing.Point(12, 19)
        Me.lbl_ServiceCharge.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_ServiceCharge.Name = "lbl_ServiceCharge"
        Me.lbl_ServiceCharge.Size = New System.Drawing.Size(110, 17)
        Me.lbl_ServiceCharge.TabIndex = 1
        Me.lbl_ServiceCharge.Text = "Service Charge:"
        Me.lbl_ServiceCharge.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'fra_Interest
        '
        Me.fra_Interest.BackColor = System.Drawing.Color.GhostWhite
        Me.fra_Interest.Controls.Add(Me.tbox_InterestDate)
        Me.fra_Interest.Controls.Add(Me.tbox_InterestEarned)
        Me.fra_Interest.Controls.Add(Me.lbl_InterestDate)
        Me.fra_Interest.Controls.Add(Me.lbl_InterestEarned)
        Me.fra_Interest.Location = New System.Drawing.Point(22, 114)
        Me.fra_Interest.Margin = New System.Windows.Forms.Padding(2)
        Me.fra_Interest.Name = "fra_Interest"
        Me.fra_Interest.Padding = New System.Windows.Forms.Padding(2)
        Me.fra_Interest.Size = New System.Drawing.Size(405, 79)
        Me.fra_Interest.TabIndex = 3
        Me.fra_Interest.TabStop = False
        '
        'tbox_InterestDate
        '
        Me.tbox_InterestDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_InterestDate.Location = New System.Drawing.Point(119, 46)
        Me.tbox_InterestDate.Margin = New System.Windows.Forms.Padding(2)
        Me.tbox_InterestDate.Mask = "00/00/0000"
        Me.tbox_InterestDate.Name = "tbox_InterestDate"
        Me.tbox_InterestDate.Size = New System.Drawing.Size(72, 22)
        Me.tbox_InterestDate.TabIndex = 20
        Me.tbox_InterestDate.ValidatingType = GetType(Date)
        '
        'tbox_InterestEarned
        '
        Me.tbox_InterestEarned.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_InterestEarned.Location = New System.Drawing.Point(119, 16)
        Me.tbox_InterestEarned.Margin = New System.Windows.Forms.Padding(2)
        Me.tbox_InterestEarned.Name = "tbox_InterestEarned"
        Me.tbox_InterestEarned.Size = New System.Drawing.Size(80, 23)
        Me.tbox_InterestEarned.TabIndex = 13
        '
        'lbl_InterestDate
        '
        Me.lbl_InterestDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_InterestDate.Location = New System.Drawing.Point(12, 48)
        Me.lbl_InterestDate.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_InterestDate.Name = "lbl_InterestDate"
        Me.lbl_InterestDate.Size = New System.Drawing.Size(110, 17)
        Me.lbl_InterestDate.TabIndex = 2
        Me.lbl_InterestDate.Text = "Interest Date:"
        Me.lbl_InterestDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_InterestEarned
        '
        Me.lbl_InterestEarned.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_InterestEarned.Location = New System.Drawing.Point(12, 19)
        Me.lbl_InterestEarned.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_InterestEarned.Name = "lbl_InterestEarned"
        Me.lbl_InterestEarned.Size = New System.Drawing.Size(110, 17)
        Me.lbl_InterestEarned.TabIndex = 1
        Me.lbl_InterestEarned.Text = "Interest Earned:"
        Me.lbl_InterestEarned.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_StatementDate
        '
        Me.lbl_StatementDate.AutoSize = True
        Me.lbl_StatementDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_StatementDate.Location = New System.Drawing.Point(282, 39)
        Me.lbl_StatementDate.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_StatementDate.Name = "lbl_StatementDate"
        Me.lbl_StatementDate.Size = New System.Drawing.Size(106, 17)
        Me.lbl_StatementDate.TabIndex = 2
        Me.lbl_StatementDate.Text = "Statement Date"
        Me.lbl_StatementDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_EndingBalance
        '
        Me.lbl_EndingBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_EndingBalance.Location = New System.Drawing.Point(20, 68)
        Me.lbl_EndingBalance.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_EndingBalance.Name = "lbl_EndingBalance"
        Me.lbl_EndingBalance.Size = New System.Drawing.Size(121, 17)
        Me.lbl_EndingBalance.TabIndex = 1
        Me.lbl_EndingBalance.Text = "Ending Balance:"
        Me.lbl_EndingBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label_StartBalance
        '
        Me.Label_StartBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_StartBalance.Location = New System.Drawing.Point(20, 39)
        Me.Label_StartBalance.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label_StartBalance.Name = "Label_StartBalance"
        Me.Label_StartBalance.Size = New System.Drawing.Size(121, 17)
        Me.Label_StartBalance.TabIndex = 0
        Me.Label_StartBalance.Text = "Starting Balance:"
        Me.Label_StartBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_SelectedValue1
        '
        Me.lbl_SelectedValue1.AutoSize = True
        Me.lbl_SelectedValue1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_SelectedValue1.Location = New System.Drawing.Point(319, 543)
        Me.lbl_SelectedValue1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_SelectedValue1.Name = "lbl_SelectedValue1"
        Me.lbl_SelectedValue1.Size = New System.Drawing.Size(107, 17)
        Me.lbl_SelectedValue1.TabIndex = 6
        Me.lbl_SelectedValue1.Text = "Selected Value:"
        '
        'lbl_SelectedValueDebit
        '
        Me.lbl_SelectedValueDebit.AutoSize = True
        Me.lbl_SelectedValueDebit.BackColor = System.Drawing.Color.White
        Me.lbl_SelectedValueDebit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_SelectedValueDebit.Location = New System.Drawing.Point(423, 543)
        Me.lbl_SelectedValueDebit.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_SelectedValueDebit.Name = "lbl_SelectedValueDebit"
        Me.lbl_SelectedValueDebit.Size = New System.Drawing.Size(16, 17)
        Me.lbl_SelectedValueDebit.TabIndex = 7
        Me.lbl_SelectedValueDebit.Text = "0"
        '
        'lbl_DebitItems
        '
        Me.lbl_DebitItems.AutoSize = True
        Me.lbl_DebitItems.BackColor = System.Drawing.Color.White
        Me.lbl_DebitItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_DebitItems.Location = New System.Drawing.Point(103, 543)
        Me.lbl_DebitItems.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_DebitItems.Name = "lbl_DebitItems"
        Me.lbl_DebitItems.Size = New System.Drawing.Size(16, 17)
        Me.lbl_DebitItems.TabIndex = 9
        Me.lbl_DebitItems.Text = "0"
        '
        'lbl_TotalItems1
        '
        Me.lbl_TotalItems1.AutoSize = True
        Me.lbl_TotalItems1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_TotalItems1.Location = New System.Drawing.Point(25, 543)
        Me.lbl_TotalItems1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_TotalItems1.Name = "lbl_TotalItems1"
        Me.lbl_TotalItems1.Size = New System.Drawing.Size(81, 17)
        Me.lbl_TotalItems1.TabIndex = 8
        Me.lbl_TotalItems1.Text = "Total Items:"
        '
        'lbl_CreditItems
        '
        Me.lbl_CreditItems.AutoSize = True
        Me.lbl_CreditItems.BackColor = System.Drawing.Color.White
        Me.lbl_CreditItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_CreditItems.Location = New System.Drawing.Point(613, 543)
        Me.lbl_CreditItems.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_CreditItems.Name = "lbl_CreditItems"
        Me.lbl_CreditItems.Size = New System.Drawing.Size(16, 17)
        Me.lbl_CreditItems.TabIndex = 13
        Me.lbl_CreditItems.Text = "0"
        '
        'lbl_TotalItems2
        '
        Me.lbl_TotalItems2.AutoSize = True
        Me.lbl_TotalItems2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_TotalItems2.Location = New System.Drawing.Point(535, 543)
        Me.lbl_TotalItems2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_TotalItems2.Name = "lbl_TotalItems2"
        Me.lbl_TotalItems2.Size = New System.Drawing.Size(81, 17)
        Me.lbl_TotalItems2.TabIndex = 12
        Me.lbl_TotalItems2.Text = "Total Items:"
        '
        'lbl_SelectedValueCredit
        '
        Me.lbl_SelectedValueCredit.AutoSize = True
        Me.lbl_SelectedValueCredit.BackColor = System.Drawing.Color.White
        Me.lbl_SelectedValueCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_SelectedValueCredit.Location = New System.Drawing.Point(933, 543)
        Me.lbl_SelectedValueCredit.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_SelectedValueCredit.Name = "lbl_SelectedValueCredit"
        Me.lbl_SelectedValueCredit.Size = New System.Drawing.Size(16, 17)
        Me.lbl_SelectedValueCredit.TabIndex = 11
        Me.lbl_SelectedValueCredit.Text = "0"
        '
        'lbl_SelectedValue2
        '
        Me.lbl_SelectedValue2.AutoSize = True
        Me.lbl_SelectedValue2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_SelectedValue2.Location = New System.Drawing.Point(829, 543)
        Me.lbl_SelectedValue2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_SelectedValue2.Name = "lbl_SelectedValue2"
        Me.lbl_SelectedValue2.Size = New System.Drawing.Size(107, 17)
        Me.lbl_SelectedValue2.TabIndex = 10
        Me.lbl_SelectedValue2.Text = "Selected Value:"
        '
        'lbl_SelectedCountDebit
        '
        Me.lbl_SelectedCountDebit.AutoSize = True
        Me.lbl_SelectedCountDebit.BackColor = System.Drawing.Color.White
        Me.lbl_SelectedCountDebit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_SelectedCountDebit.Location = New System.Drawing.Point(265, 543)
        Me.lbl_SelectedCountDebit.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_SelectedCountDebit.Name = "lbl_SelectedCountDebit"
        Me.lbl_SelectedCountDebit.Size = New System.Drawing.Size(16, 17)
        Me.lbl_SelectedCountDebit.TabIndex = 15
        Me.lbl_SelectedCountDebit.Text = "0"
        '
        'lbl_SelectedCount1
        '
        Me.lbl_SelectedCount1.AutoSize = True
        Me.lbl_SelectedCount1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_SelectedCount1.Location = New System.Drawing.Point(160, 543)
        Me.lbl_SelectedCount1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_SelectedCount1.Name = "lbl_SelectedCount1"
        Me.lbl_SelectedCount1.Size = New System.Drawing.Size(108, 17)
        Me.lbl_SelectedCount1.TabIndex = 14
        Me.lbl_SelectedCount1.Text = "Selected Count:"
        '
        'lbl_SelectedCountCredit
        '
        Me.lbl_SelectedCountCredit.AutoSize = True
        Me.lbl_SelectedCountCredit.BackColor = System.Drawing.Color.White
        Me.lbl_SelectedCountCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_SelectedCountCredit.Location = New System.Drawing.Point(775, 543)
        Me.lbl_SelectedCountCredit.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_SelectedCountCredit.Name = "lbl_SelectedCountCredit"
        Me.lbl_SelectedCountCredit.Size = New System.Drawing.Size(16, 17)
        Me.lbl_SelectedCountCredit.TabIndex = 17
        Me.lbl_SelectedCountCredit.Text = "0"
        '
        'lbl_SelectedCount2
        '
        Me.lbl_SelectedCount2.AutoSize = True
        Me.lbl_SelectedCount2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_SelectedCount2.Location = New System.Drawing.Point(670, 543)
        Me.lbl_SelectedCount2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_SelectedCount2.Name = "lbl_SelectedCount2"
        Me.lbl_SelectedCount2.Size = New System.Drawing.Size(108, 17)
        Me.lbl_SelectedCount2.TabIndex = 16
        Me.lbl_SelectedCount2.Text = "Selected Count:"
        '
        'lbl_ClearedBalance
        '
        Me.lbl_ClearedBalance.AutoSize = True
        Me.lbl_ClearedBalance.BackColor = System.Drawing.Color.White
        Me.lbl_ClearedBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ClearedBalance.Location = New System.Drawing.Point(928, 591)
        Me.lbl_ClearedBalance.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_ClearedBalance.Name = "lbl_ClearedBalance"
        Me.lbl_ClearedBalance.Size = New System.Drawing.Size(0, 17)
        Me.lbl_ClearedBalance.TabIndex = 19
        '
        'Label_ClearedBalance
        '
        Me.Label_ClearedBalance.AutoSize = True
        Me.Label_ClearedBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_ClearedBalance.Location = New System.Drawing.Point(815, 591)
        Me.Label_ClearedBalance.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label_ClearedBalance.Name = "Label_ClearedBalance"
        Me.Label_ClearedBalance.Size = New System.Drawing.Size(116, 17)
        Me.Label_ClearedBalance.TabIndex = 18
        Me.Label_ClearedBalance.Text = "Cleared Balance:"
        '
        'lbl_EndBalance
        '
        Me.lbl_EndBalance.AutoSize = True
        Me.lbl_EndBalance.BackColor = System.Drawing.Color.White
        Me.lbl_EndBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_EndBalance.Location = New System.Drawing.Point(928, 615)
        Me.lbl_EndBalance.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_EndBalance.Name = "lbl_EndBalance"
        Me.lbl_EndBalance.Size = New System.Drawing.Size(0, 17)
        Me.lbl_EndBalance.TabIndex = 21
        '
        'Label_EndBalance
        '
        Me.Label_EndBalance.AutoSize = True
        Me.Label_EndBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_EndBalance.Location = New System.Drawing.Point(820, 615)
        Me.Label_EndBalance.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label_EndBalance.Name = "Label_EndBalance"
        Me.Label_EndBalance.Size = New System.Drawing.Size(111, 17)
        Me.Label_EndBalance.TabIndex = 20
        Me.Label_EndBalance.Text = "Ending Balance:"
        '
        'lbl_Difference
        '
        Me.lbl_Difference.AutoSize = True
        Me.lbl_Difference.BackColor = System.Drawing.Color.White
        Me.lbl_Difference.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Difference.Location = New System.Drawing.Point(928, 641)
        Me.lbl_Difference.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_Difference.Name = "lbl_Difference"
        Me.lbl_Difference.Size = New System.Drawing.Size(0, 17)
        Me.lbl_Difference.TabIndex = 23
        '
        'Label_Difference
        '
        Me.Label_Difference.AutoSize = True
        Me.Label_Difference.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Difference.Location = New System.Drawing.Point(854, 641)
        Me.Label_Difference.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label_Difference.Name = "Label_Difference"
        Me.Label_Difference.Size = New System.Drawing.Size(77, 17)
        Me.Label_Difference.TabIndex = 22
        Me.Label_Difference.Text = "Difference:"
        '
        'cmd_Finish
        '
        Me.cmd_Finish.BackColor = System.Drawing.Color.SeaShell
        Me.cmd_Finish.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Finish.Location = New System.Drawing.Point(695, 641)
        Me.cmd_Finish.Margin = New System.Windows.Forms.Padding(2)
        Me.cmd_Finish.Name = "cmd_Finish"
        Me.cmd_Finish.Size = New System.Drawing.Size(80, 28)
        Me.cmd_Finish.TabIndex = 25
        Me.cmd_Finish.Text = "Finish"
        Me.cmd_Finish.UseVisualStyleBackColor = False
        '
        'cmd_Abort
        '
        Me.cmd_Abort.BackColor = System.Drawing.Color.SeaShell
        Me.cmd_Abort.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Abort.Location = New System.Drawing.Point(598, 641)
        Me.cmd_Abort.Margin = New System.Windows.Forms.Padding(2)
        Me.cmd_Abort.Name = "cmd_Abort"
        Me.cmd_Abort.Size = New System.Drawing.Size(80, 28)
        Me.cmd_Abort.TabIndex = 24
        Me.cmd_Abort.Text = "Abort"
        Me.cmd_Abort.UseVisualStyleBackColor = False
        '
        'frm_CheckbookReconcile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1034, 681)
        Me.Controls.Add(Me.cmd_Finish)
        Me.Controls.Add(Me.cmd_Abort)
        Me.Controls.Add(Me.lbl_Difference)
        Me.Controls.Add(Me.Label_Difference)
        Me.Controls.Add(Me.lbl_EndBalance)
        Me.Controls.Add(Me.Label_EndBalance)
        Me.Controls.Add(Me.lbl_ClearedBalance)
        Me.Controls.Add(Me.Label_ClearedBalance)
        Me.Controls.Add(Me.lbl_SelectedCountCredit)
        Me.Controls.Add(Me.lbl_SelectedCount2)
        Me.Controls.Add(Me.lbl_SelectedCountDebit)
        Me.Controls.Add(Me.lbl_SelectedCount1)
        Me.Controls.Add(Me.lbl_CreditItems)
        Me.Controls.Add(Me.lbl_TotalItems2)
        Me.Controls.Add(Me.lbl_SelectedValueCredit)
        Me.Controls.Add(Me.lbl_SelectedValue2)
        Me.Controls.Add(Me.lbl_DebitItems)
        Me.Controls.Add(Me.lbl_TotalItems1)
        Me.Controls.Add(Me.lbl_SelectedValueDebit)
        Me.Controls.Add(Me.lbl_SelectedValue1)
        Me.Controls.Add(Me.fra_Statement1)
        Me.Controls.Add(Me.lbl_AllDeposits)
        Me.Controls.Add(Me.lbl_PaymentAndChecks)
        Me.Controls.Add(Me.ListView2)
        Me.Controls.Add(Me.ListView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_CheckbookReconcile"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Checkbook Reconcile"
        Me.fra_Statement1.ResumeLayout(False)
        Me.fra_Statement2.ResumeLayout(False)
        Me.fra_Statement2.PerformLayout()
        Me.fra_ServiceCharge.ResumeLayout(False)
        Me.fra_ServiceCharge.PerformLayout()
        Me.fra_Interest.ResumeLayout(False)
        Me.fra_Interest.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents colDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTransaction As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colChkno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPayee As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCategory As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colMemo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCleared As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn2 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents DebitClear As System.Windows.Forms.ColumnHeader
    Friend WithEvents DebitDate As System.Windows.Forms.ColumnHeader
    Friend WithEvents DebitChkno As System.Windows.Forms.ColumnHeader
    Friend WithEvents DebitPayee As System.Windows.Forms.ColumnHeader
    Friend WithEvents DebitAmount As System.Windows.Forms.ColumnHeader
    Friend WithEvents ListView2 As System.Windows.Forms.ListView
    Friend WithEvents CreditClear As System.Windows.Forms.ColumnHeader
    Friend WithEvents CreditDate As System.Windows.Forms.ColumnHeader
    Friend WithEvents CreditChkno As System.Windows.Forms.ColumnHeader
    Friend WithEvents CreditPayee As System.Windows.Forms.ColumnHeader
    Friend WithEvents CreditAmount As System.Windows.Forms.ColumnHeader
    Friend WithEvents lbl_PaymentAndChecks As System.Windows.Forms.Label
    Friend WithEvents lbl_AllDeposits As System.Windows.Forms.Label
    Friend WithEvents fra_Statement1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_StatementTop As System.Windows.Forms.Label
    Friend WithEvents fra_Statement2 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_FormSplit As System.Windows.Forms.Label
    Friend WithEvents lbl_InterestTop As System.Windows.Forms.Label
    Friend WithEvents fra_ServiceCharge As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_ServiceDate As System.Windows.Forms.Label
    Friend WithEvents lbl_ServiceCharge As System.Windows.Forms.Label
    Friend WithEvents fra_Interest As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_InterestDate As System.Windows.Forms.Label
    Friend WithEvents lbl_InterestEarned As System.Windows.Forms.Label
    Friend WithEvents lbl_StatementDate As System.Windows.Forms.Label
    Friend WithEvents lbl_EndingBalance As System.Windows.Forms.Label
    Friend WithEvents Label_StartBalance As System.Windows.Forms.Label
    Friend WithEvents cmd_Cancel As System.Windows.Forms.Button
    Friend WithEvents cmd_Proceed As System.Windows.Forms.Button
    Friend WithEvents tbox_EndBalance As System.Windows.Forms.TextBox
    Friend WithEvents tbox_ServiceCharge As System.Windows.Forms.TextBox
    Friend WithEvents tbox_InterestEarned As System.Windows.Forms.TextBox
    Friend WithEvents lbl_SelectedValue1 As System.Windows.Forms.Label
    Friend WithEvents lbl_SelectedValueDebit As System.Windows.Forms.Label
    Friend WithEvents lbl_DebitItems As System.Windows.Forms.Label
    Friend WithEvents lbl_TotalItems1 As System.Windows.Forms.Label
    Friend WithEvents lbl_CreditItems As System.Windows.Forms.Label
    Friend WithEvents lbl_TotalItems2 As System.Windows.Forms.Label
    Friend WithEvents lbl_SelectedValueCredit As System.Windows.Forms.Label
    Friend WithEvents lbl_SelectedValue2 As System.Windows.Forms.Label
    Friend WithEvents lbl_SelectedCountDebit As System.Windows.Forms.Label
    Friend WithEvents lbl_SelectedCount1 As System.Windows.Forms.Label
    Friend WithEvents lbl_SelectedCountCredit As System.Windows.Forms.Label
    Friend WithEvents lbl_SelectedCount2 As System.Windows.Forms.Label
    Friend WithEvents lbl_ClearedBalance As System.Windows.Forms.Label
    Friend WithEvents Label_ClearedBalance As System.Windows.Forms.Label
    Friend WithEvents lbl_EndBalance As System.Windows.Forms.Label
    Friend WithEvents Label_EndBalance As System.Windows.Forms.Label
    Friend WithEvents lbl_Difference As System.Windows.Forms.Label
    Friend WithEvents Label_Difference As System.Windows.Forms.Label
    Friend WithEvents cmd_Finish As System.Windows.Forms.Button
    Friend WithEvents cmd_Abort As System.Windows.Forms.Button
    Friend WithEvents tbox_StatementDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents tbox_ServiceDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents tbox_InterestDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents tbox_StartBalance As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Message1 As System.Windows.Forms.Label
End Class
