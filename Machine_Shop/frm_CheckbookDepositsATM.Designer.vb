<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_CheckbookDepositsATM
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
        Me.lbl_Date = New System.Windows.Forms.Label()
        Me.lbl_HeaderName = New System.Windows.Forms.Label()
        Me.lbl_HeaderAddress = New System.Windows.Forms.Label()
        Me.lbl_HeaderCity = New System.Windows.Forms.Label()
        Me.lbl_HeaderPhone = New System.Windows.Forms.Label()
        Me.tbox_Date = New System.Windows.Forms.MaskedTextBox()
        Me.fra_Transaction = New System.Windows.Forms.GroupBox()
        Me.lbl_Category = New System.Windows.Forms.Label()
        Me.lbl_Memo = New System.Windows.Forms.Label()
        Me.lbl_TotalValue = New System.Windows.Forms.Label()
        Me.lbl_Total = New System.Windows.Forms.Label()
        Me.lbl_LineNo = New System.Windows.Forms.Label()
        Me.lbl_Amount = New System.Windows.Forms.Label()
        Me.lbl_TransactionName = New System.Windows.Forms.Label()
        Me.ListBox_Names = New System.Windows.Forms.ListBox()
        Me.lbl_TransactionTop = New System.Windows.Forms.Label()
        Me.cmd_Cancel = New System.Windows.Forms.Button()
        Me.cmd_Submit = New System.Windows.Forms.Button()
        Me.fra_TaxCategory = New System.Windows.Forms.GroupBox()
        Me.lbl_TaxCategoryTop = New System.Windows.Forms.Label()
        Me.fra_Transaction.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_Date
        '
        Me.lbl_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Date.Location = New System.Drawing.Point(616, 27)
        Me.lbl_Date.Name = "lbl_Date"
        Me.lbl_Date.Size = New System.Drawing.Size(91, 21)
        Me.lbl_Date.TabIndex = 3
        Me.lbl_Date.Text = "Date"
        Me.lbl_Date.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lbl_HeaderName
        '
        Me.lbl_HeaderName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_HeaderName.Location = New System.Drawing.Point(53, 27)
        Me.lbl_HeaderName.Name = "lbl_HeaderName"
        Me.lbl_HeaderName.Size = New System.Drawing.Size(360, 20)
        Me.lbl_HeaderName.TabIndex = 4
        Me.lbl_HeaderName.Text = "Company"
        Me.lbl_HeaderName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_HeaderAddress
        '
        Me.lbl_HeaderAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_HeaderAddress.Location = New System.Drawing.Point(113, 49)
        Me.lbl_HeaderAddress.Name = "lbl_HeaderAddress"
        Me.lbl_HeaderAddress.Size = New System.Drawing.Size(240, 20)
        Me.lbl_HeaderAddress.TabIndex = 5
        Me.lbl_HeaderAddress.Text = "Address"
        Me.lbl_HeaderAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_HeaderCity
        '
        Me.lbl_HeaderCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_HeaderCity.Location = New System.Drawing.Point(113, 71)
        Me.lbl_HeaderCity.Name = "lbl_HeaderCity"
        Me.lbl_HeaderCity.Size = New System.Drawing.Size(240, 20)
        Me.lbl_HeaderCity.TabIndex = 6
        Me.lbl_HeaderCity.Text = "City, State, ZipCode"
        Me.lbl_HeaderCity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_HeaderPhone
        '
        Me.lbl_HeaderPhone.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_HeaderPhone.Location = New System.Drawing.Point(113, 94)
        Me.lbl_HeaderPhone.Name = "lbl_HeaderPhone"
        Me.lbl_HeaderPhone.Size = New System.Drawing.Size(240, 20)
        Me.lbl_HeaderPhone.TabIndex = 7
        Me.lbl_HeaderPhone.Text = "Phone"
        Me.lbl_HeaderPhone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbox_Date
        '
        Me.tbox_Date.AllowPromptAsInput = False
        Me.tbox_Date.BackColor = System.Drawing.Color.White
        Me.tbox_Date.Font = New System.Drawing.Font("SansSerif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.tbox_Date.Location = New System.Drawing.Point(619, 52)
        Me.tbox_Date.Margin = New System.Windows.Forms.Padding(4)
        Me.tbox_Date.Mask = "00/00/0000"
        Me.tbox_Date.Name = "tbox_Date"
        Me.tbox_Date.Size = New System.Drawing.Size(89, 23)
        Me.tbox_Date.TabIndex = 33
        Me.tbox_Date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbox_Date.ValidatingType = GetType(Date)
        '
        'fra_Transaction
        '
        Me.fra_Transaction.BackColor = System.Drawing.Color.White
        Me.fra_Transaction.Controls.Add(Me.lbl_Category)
        Me.fra_Transaction.Controls.Add(Me.lbl_Memo)
        Me.fra_Transaction.Controls.Add(Me.lbl_TotalValue)
        Me.fra_Transaction.Controls.Add(Me.lbl_Total)
        Me.fra_Transaction.Controls.Add(Me.lbl_LineNo)
        Me.fra_Transaction.Controls.Add(Me.lbl_Amount)
        Me.fra_Transaction.Controls.Add(Me.lbl_TransactionName)
        Me.fra_Transaction.Controls.Add(Me.ListBox_Names)
        Me.fra_Transaction.Location = New System.Drawing.Point(15, 132)
        Me.fra_Transaction.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.fra_Transaction.Name = "fra_Transaction"
        Me.fra_Transaction.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.fra_Transaction.Size = New System.Drawing.Size(816, 301)
        Me.fra_Transaction.TabIndex = 36
        Me.fra_Transaction.TabStop = False
        '
        'lbl_Category
        '
        Me.lbl_Category.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Category.Location = New System.Drawing.Point(293, 20)
        Me.lbl_Category.Name = "lbl_Category"
        Me.lbl_Category.Size = New System.Drawing.Size(110, 18)
        Me.lbl_Category.TabIndex = 15
        Me.lbl_Category.Text = "Category"
        Me.lbl_Category.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Memo
        '
        Me.lbl_Memo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Memo.Location = New System.Drawing.Point(421, 20)
        Me.lbl_Memo.Name = "lbl_Memo"
        Me.lbl_Memo.Size = New System.Drawing.Size(185, 18)
        Me.lbl_Memo.TabIndex = 14
        Me.lbl_Memo.Text = "Memo"
        Me.lbl_Memo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_TotalValue
        '
        Me.lbl_TotalValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_TotalValue.Location = New System.Drawing.Point(718, 42)
        Me.lbl_TotalValue.Name = "lbl_TotalValue"
        Me.lbl_TotalValue.Size = New System.Drawing.Size(84, 17)
        Me.lbl_TotalValue.TabIndex = 13
        Me.lbl_TotalValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Total
        '
        Me.lbl_Total.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Total.Location = New System.Drawing.Point(718, 20)
        Me.lbl_Total.Name = "lbl_Total"
        Me.lbl_Total.Size = New System.Drawing.Size(84, 18)
        Me.lbl_Total.TabIndex = 12
        Me.lbl_Total.Text = "Total"
        Me.lbl_Total.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_LineNo
        '
        Me.lbl_LineNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_LineNo.Location = New System.Drawing.Point(10, 20)
        Me.lbl_LineNo.Name = "lbl_LineNo"
        Me.lbl_LineNo.Size = New System.Drawing.Size(34, 18)
        Me.lbl_LineNo.TabIndex = 9
        Me.lbl_LineNo.Text = "No"
        Me.lbl_LineNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Amount
        '
        Me.lbl_Amount.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Amount.Location = New System.Drawing.Point(620, 20)
        Me.lbl_Amount.Name = "lbl_Amount"
        Me.lbl_Amount.Size = New System.Drawing.Size(80, 18)
        Me.lbl_Amount.TabIndex = 2
        Me.lbl_Amount.Text = "Amount"
        Me.lbl_Amount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_TransactionName
        '
        Me.lbl_TransactionName.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_TransactionName.Location = New System.Drawing.Point(56, 20)
        Me.lbl_TransactionName.Name = "lbl_TransactionName"
        Me.lbl_TransactionName.Size = New System.Drawing.Size(220, 18)
        Me.lbl_TransactionName.TabIndex = 1
        Me.lbl_TransactionName.Text = "Received From"
        Me.lbl_TransactionName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ListBox_Names
        '
        Me.ListBox_Names.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox_Names.FormattingEnabled = True
        Me.ListBox_Names.ItemHeight = 16
        Me.ListBox_Names.Location = New System.Drawing.Point(784, 10)
        Me.ListBox_Names.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ListBox_Names.Name = "ListBox_Names"
        Me.ListBox_Names.Size = New System.Drawing.Size(24, 4)
        Me.ListBox_Names.TabIndex = 0
        Me.ListBox_Names.Visible = False
        '
        'lbl_TransactionTop
        '
        Me.lbl_TransactionTop.Location = New System.Drawing.Point(10, 132)
        Me.lbl_TransactionTop.Name = "lbl_TransactionTop"
        Me.lbl_TransactionTop.Size = New System.Drawing.Size(825, 6)
        Me.lbl_TransactionTop.TabIndex = 37
        '
        'cmd_Cancel
        '
        Me.cmd_Cancel.BackColor = System.Drawing.Color.LightCyan
        Me.cmd_Cancel.Location = New System.Drawing.Point(662, 100)
        Me.cmd_Cancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmd_Cancel.Name = "cmd_Cancel"
        Me.cmd_Cancel.Size = New System.Drawing.Size(73, 28)
        Me.cmd_Cancel.TabIndex = 41
        Me.cmd_Cancel.Text = "Cancel"
        Me.cmd_Cancel.UseVisualStyleBackColor = False
        '
        'cmd_Submit
        '
        Me.cmd_Submit.BackColor = System.Drawing.Color.LightCyan
        Me.cmd_Submit.Location = New System.Drawing.Point(751, 100)
        Me.cmd_Submit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmd_Submit.Name = "cmd_Submit"
        Me.cmd_Submit.Size = New System.Drawing.Size(73, 28)
        Me.cmd_Submit.TabIndex = 40
        Me.cmd_Submit.Text = "Submit"
        Me.cmd_Submit.UseVisualStyleBackColor = False
        '
        'fra_TaxCategory
        '
        Me.fra_TaxCategory.BackColor = System.Drawing.Color.Cornsilk
        Me.fra_TaxCategory.Location = New System.Drawing.Point(15, 434)
        Me.fra_TaxCategory.Name = "fra_TaxCategory"
        Me.fra_TaxCategory.Size = New System.Drawing.Size(816, 89)
        Me.fra_TaxCategory.TabIndex = 42
        Me.fra_TaxCategory.TabStop = False
        '
        'lbl_TaxCategoryTop
        '
        Me.lbl_TaxCategoryTop.Location = New System.Drawing.Point(11, 434)
        Me.lbl_TaxCategoryTop.Name = "lbl_TaxCategoryTop"
        Me.lbl_TaxCategoryTop.Size = New System.Drawing.Size(825, 6)
        Me.lbl_TaxCategoryTop.TabIndex = 43
        '
        'frm_CheckbookDepositsATM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(846, 538)
        Me.Controls.Add(Me.lbl_TaxCategoryTop)
        Me.Controls.Add(Me.fra_TaxCategory)
        Me.Controls.Add(Me.cmd_Cancel)
        Me.Controls.Add(Me.cmd_Submit)
        Me.Controls.Add(Me.lbl_TransactionTop)
        Me.Controls.Add(Me.fra_Transaction)
        Me.Controls.Add(Me.tbox_Date)
        Me.Controls.Add(Me.lbl_HeaderPhone)
        Me.Controls.Add(Me.lbl_HeaderCity)
        Me.Controls.Add(Me.lbl_HeaderAddress)
        Me.Controls.Add(Me.lbl_HeaderName)
        Me.Controls.Add(Me.lbl_Date)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_CheckbookDepositsATM"
        Me.Text = "ATM Withdrawls"
        Me.fra_Transaction.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_Date As System.Windows.Forms.Label
    Friend WithEvents lbl_HeaderName As System.Windows.Forms.Label
    Friend WithEvents lbl_HeaderAddress As System.Windows.Forms.Label
    Friend WithEvents lbl_HeaderCity As System.Windows.Forms.Label
    Friend WithEvents lbl_HeaderPhone As System.Windows.Forms.Label
    Public WithEvents tbox_Date As System.Windows.Forms.MaskedTextBox
    Friend WithEvents fra_Transaction As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_TransactionTop As System.Windows.Forms.Label
    Friend WithEvents cmd_Cancel As System.Windows.Forms.Button
    Friend WithEvents cmd_Submit As System.Windows.Forms.Button
    Friend WithEvents ListBox_Names As System.Windows.Forms.ListBox
    Friend WithEvents lbl_LineNo As System.Windows.Forms.Label
    Friend WithEvents lbl_Amount As System.Windows.Forms.Label
    Friend WithEvents lbl_TransactionName As System.Windows.Forms.Label
    Friend WithEvents lbl_TotalValue As System.Windows.Forms.Label
    Friend WithEvents lbl_Total As System.Windows.Forms.Label
    Friend WithEvents lbl_Memo As System.Windows.Forms.Label
    Friend WithEvents lbl_Category As System.Windows.Forms.Label
    Friend WithEvents fra_TaxCategory As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_TaxCategoryTop As System.Windows.Forms.Label
End Class
