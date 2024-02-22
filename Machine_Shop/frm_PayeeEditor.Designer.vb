<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_PayeeEditor
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
        Me.fra_List = New System.Windows.Forms.GroupBox()
        Me.lbl_Listbox = New System.Windows.Forms.Label()
        Me.fra_Listbox1 = New System.Windows.Forms.GroupBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.fra_PayeeInfo = New System.Windows.Forms.GroupBox()
        Me.tbox_Payee = New System.Windows.Forms.TextBox()
        Me.lbl_CompanyName1 = New System.Windows.Forms.Label()
        Me.tbox_Address = New System.Windows.Forms.TextBox()
        Me.tbox_City = New System.Windows.Forms.TextBox()
        Me.tbox_State = New System.Windows.Forms.TextBox()
        Me.tbox_ZipCode = New System.Windows.Forms.MaskedTextBox()
        Me.lbl_State = New System.Windows.Forms.Label()
        Me.lbl_ZipCode = New System.Windows.Forms.Label()
        Me.lbl_City = New System.Windows.Forms.Label()
        Me.lbl_Address = New System.Windows.Forms.Label()
        Me.cmd_ExitSave = New System.Windows.Forms.Button()
        Me.cmd_DeleteCancel = New System.Windows.Forms.Button()
        Me.cmd_NewRestore = New System.Windows.Forms.Button()
        Me.cmd_Edit = New System.Windows.Forms.Button()
        Me.lbl_Message = New System.Windows.Forms.Label()
        Me.fra_Category = New System.Windows.Forms.GroupBox()
        Me.fra_List.SuspendLayout()
        Me.fra_Listbox1.SuspendLayout()
        Me.fra_PayeeInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'fra_List
        '
        Me.fra_List.BackColor = System.Drawing.SystemColors.Control
        Me.fra_List.Controls.Add(Me.lbl_Listbox)
        Me.fra_List.Controls.Add(Me.fra_Listbox1)
        Me.fra_List.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fra_List.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fra_List.Location = New System.Drawing.Point(20, 15)
        Me.fra_List.Name = "fra_List"
        Me.fra_List.Padding = New System.Windows.Forms.Padding(0)
        Me.fra_List.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fra_List.Size = New System.Drawing.Size(250, 561)
        Me.fra_List.TabIndex = 106
        Me.fra_List.TabStop = False
        '
        'lbl_Listbox
        '
        Me.lbl_Listbox.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Listbox.ForeColor = System.Drawing.Color.Green
        Me.lbl_Listbox.Location = New System.Drawing.Point(45, 14)
        Me.lbl_Listbox.Name = "lbl_Listbox"
        Me.lbl_Listbox.Size = New System.Drawing.Size(160, 16)
        Me.lbl_Listbox.TabIndex = 100
        Me.lbl_Listbox.Text = "Payee"
        Me.lbl_Listbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'fra_Listbox1
        '
        Me.fra_Listbox1.BackColor = System.Drawing.Color.White
        Me.fra_Listbox1.Controls.Add(Me.ListBox1)
        Me.fra_Listbox1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fra_Listbox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fra_Listbox1.Location = New System.Drawing.Point(19, 34)
        Me.fra_Listbox1.Name = "fra_Listbox1"
        Me.fra_Listbox1.Padding = New System.Windows.Forms.Padding(0)
        Me.fra_Listbox1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fra_Listbox1.Size = New System.Drawing.Size(212, 510)
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
        Me.ListBox1.Size = New System.Drawing.Size(212, 508)
        Me.ListBox1.TabIndex = 0
        '
        'fra_PayeeInfo
        '
        Me.fra_PayeeInfo.BackColor = System.Drawing.SystemColors.Control
        Me.fra_PayeeInfo.Controls.Add(Me.tbox_Payee)
        Me.fra_PayeeInfo.Controls.Add(Me.lbl_CompanyName1)
        Me.fra_PayeeInfo.Controls.Add(Me.tbox_Address)
        Me.fra_PayeeInfo.Controls.Add(Me.tbox_City)
        Me.fra_PayeeInfo.Controls.Add(Me.tbox_State)
        Me.fra_PayeeInfo.Controls.Add(Me.tbox_ZipCode)
        Me.fra_PayeeInfo.Controls.Add(Me.lbl_State)
        Me.fra_PayeeInfo.Controls.Add(Me.lbl_ZipCode)
        Me.fra_PayeeInfo.Controls.Add(Me.lbl_City)
        Me.fra_PayeeInfo.Controls.Add(Me.lbl_Address)
        Me.fra_PayeeInfo.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.fra_PayeeInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.fra_PayeeInfo.Location = New System.Drawing.Point(300, 15)
        Me.fra_PayeeInfo.Name = "fra_PayeeInfo"
        Me.fra_PayeeInfo.Padding = New System.Windows.Forms.Padding(0)
        Me.fra_PayeeInfo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fra_PayeeInfo.Size = New System.Drawing.Size(375, 196)
        Me.fra_PayeeInfo.TabIndex = 109
        Me.fra_PayeeInfo.TabStop = False
        Me.fra_PayeeInfo.Text = "Payee Information"
        '
        'tbox_Payee
        '
        Me.tbox_Payee.AcceptsReturn = True
        Me.tbox_Payee.BackColor = System.Drawing.Color.White
        Me.tbox_Payee.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_Payee.Enabled = False
        Me.tbox_Payee.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_Payee.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbox_Payee.Location = New System.Drawing.Point(115, 33)
        Me.tbox_Payee.MaxLength = 0
        Me.tbox_Payee.Name = "tbox_Payee"
        Me.tbox_Payee.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbox_Payee.Size = New System.Drawing.Size(185, 20)
        Me.tbox_Payee.TabIndex = 86
        Me.tbox_Payee.TabStop = False
        '
        'lbl_CompanyName1
        '
        Me.lbl_CompanyName1.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_CompanyName1.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_CompanyName1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_CompanyName1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbl_CompanyName1.Location = New System.Drawing.Point(34, 37)
        Me.lbl_CompanyName1.Name = "lbl_CompanyName1"
        Me.lbl_CompanyName1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_CompanyName1.Size = New System.Drawing.Size(79, 13)
        Me.lbl_CompanyName1.TabIndex = 87
        Me.lbl_CompanyName1.Text = "Payee:"
        Me.lbl_CompanyName1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'tbox_Address
        '
        Me.tbox_Address.AcceptsReturn = True
        Me.tbox_Address.BackColor = System.Drawing.Color.White
        Me.tbox_Address.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_Address.Enabled = False
        Me.tbox_Address.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_Address.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbox_Address.Location = New System.Drawing.Point(115, 63)
        Me.tbox_Address.MaxLength = 0
        Me.tbox_Address.Name = "tbox_Address"
        Me.tbox_Address.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbox_Address.Size = New System.Drawing.Size(207, 20)
        Me.tbox_Address.TabIndex = 5
        '
        'tbox_City
        '
        Me.tbox_City.AcceptsReturn = True
        Me.tbox_City.BackColor = System.Drawing.Color.White
        Me.tbox_City.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_City.Enabled = False
        Me.tbox_City.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_City.ForeColor = System.Drawing.Color.Black
        Me.tbox_City.Location = New System.Drawing.Point(115, 93)
        Me.tbox_City.MaxLength = 0
        Me.tbox_City.Name = "tbox_City"
        Me.tbox_City.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbox_City.Size = New System.Drawing.Size(110, 20)
        Me.tbox_City.TabIndex = 6
        '
        'tbox_State
        '
        Me.tbox_State.AcceptsReturn = True
        Me.tbox_State.BackColor = System.Drawing.Color.White
        Me.tbox_State.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_State.Enabled = False
        Me.tbox_State.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_State.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbox_State.Location = New System.Drawing.Point(115, 124)
        Me.tbox_State.MaxLength = 0
        Me.tbox_State.Name = "tbox_State"
        Me.tbox_State.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbox_State.Size = New System.Drawing.Size(24, 20)
        Me.tbox_State.TabIndex = 7
        '
        'tbox_ZipCode
        '
        Me.tbox_ZipCode.AllowPromptAsInput = False
        Me.tbox_ZipCode.BackColor = System.Drawing.Color.White
        Me.tbox_ZipCode.Enabled = False
        Me.tbox_ZipCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_ZipCode.Location = New System.Drawing.Point(115, 154)
        Me.tbox_ZipCode.Mask = "00000-9999"
        Me.tbox_ZipCode.Name = "tbox_ZipCode"
        Me.tbox_ZipCode.Size = New System.Drawing.Size(66, 20)
        Me.tbox_ZipCode.TabIndex = 8
        Me.tbox_ZipCode.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'lbl_State
        '
        Me.lbl_State.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_State.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_State.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_State.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbl_State.Location = New System.Drawing.Point(34, 127)
        Me.lbl_State.Name = "lbl_State"
        Me.lbl_State.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_State.Size = New System.Drawing.Size(79, 13)
        Me.lbl_State.TabIndex = 63
        Me.lbl_State.Text = "State:"
        Me.lbl_State.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_ZipCode
        '
        Me.lbl_ZipCode.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_ZipCode.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_ZipCode.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ZipCode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbl_ZipCode.Location = New System.Drawing.Point(34, 157)
        Me.lbl_ZipCode.Name = "lbl_ZipCode"
        Me.lbl_ZipCode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_ZipCode.Size = New System.Drawing.Size(79, 14)
        Me.lbl_ZipCode.TabIndex = 60
        Me.lbl_ZipCode.Text = "Zip Code:"
        Me.lbl_ZipCode.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl_City
        '
        Me.lbl_City.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_City.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_City.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_City.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbl_City.Location = New System.Drawing.Point(34, 97)
        Me.lbl_City.Name = "lbl_City"
        Me.lbl_City.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_City.Size = New System.Drawing.Size(79, 14)
        Me.lbl_City.TabIndex = 59
        Me.lbl_City.Text = "City:"
        Me.lbl_City.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl_Address
        '
        Me.lbl_Address.AutoSize = True
        Me.lbl_Address.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_Address.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_Address.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Address.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbl_Address.Location = New System.Drawing.Point(34, 67)
        Me.lbl_Address.Name = "lbl_Address"
        Me.lbl_Address.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_Address.Size = New System.Drawing.Size(83, 14)
        Me.lbl_Address.TabIndex = 58
        Me.lbl_Address.Text = "Street Address:"
        Me.lbl_Address.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmd_ExitSave
        '
        Me.cmd_ExitSave.BackColor = System.Drawing.SystemColors.Control
        Me.cmd_ExitSave.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmd_ExitSave.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_ExitSave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmd_ExitSave.Image = Global.Machine_Shop.My.Resources.Resources._Exit
        Me.cmd_ExitSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_ExitSave.Location = New System.Drawing.Point(578, 526)
        Me.cmd_ExitSave.Name = "cmd_ExitSave"
        Me.cmd_ExitSave.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmd_ExitSave.Size = New System.Drawing.Size(67, 50)
        Me.cmd_ExitSave.TabIndex = 123
        Me.cmd_ExitSave.TabStop = False
        Me.cmd_ExitSave.Text = "Exit"
        Me.cmd_ExitSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmd_ExitSave.UseVisualStyleBackColor = False
        '
        'cmd_DeleteCancel
        '
        Me.cmd_DeleteCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmd_DeleteCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmd_DeleteCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_DeleteCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmd_DeleteCancel.Image = Global.Machine_Shop.My.Resources.Resources.Delete
        Me.cmd_DeleteCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_DeleteCancel.Location = New System.Drawing.Point(498, 526)
        Me.cmd_DeleteCancel.Name = "cmd_DeleteCancel"
        Me.cmd_DeleteCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmd_DeleteCancel.Size = New System.Drawing.Size(67, 50)
        Me.cmd_DeleteCancel.TabIndex = 122
        Me.cmd_DeleteCancel.TabStop = False
        Me.cmd_DeleteCancel.Text = "Delete"
        Me.cmd_DeleteCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmd_DeleteCancel.UseVisualStyleBackColor = False
        '
        'cmd_NewRestore
        '
        Me.cmd_NewRestore.BackColor = System.Drawing.SystemColors.Control
        Me.cmd_NewRestore.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmd_NewRestore.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_NewRestore.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmd_NewRestore.Image = Global.Machine_Shop.My.Resources.Resources._New
        Me.cmd_NewRestore.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_NewRestore.Location = New System.Drawing.Point(418, 526)
        Me.cmd_NewRestore.Name = "cmd_NewRestore"
        Me.cmd_NewRestore.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmd_NewRestore.Size = New System.Drawing.Size(67, 50)
        Me.cmd_NewRestore.TabIndex = 121
        Me.cmd_NewRestore.TabStop = False
        Me.cmd_NewRestore.Text = "New"
        Me.cmd_NewRestore.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmd_NewRestore.UseVisualStyleBackColor = False
        '
        'cmd_Edit
        '
        Me.cmd_Edit.BackColor = System.Drawing.SystemColors.Control
        Me.cmd_Edit.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmd_Edit.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Edit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmd_Edit.Image = Global.Machine_Shop.My.Resources.Resources.Edit
        Me.cmd_Edit.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_Edit.Location = New System.Drawing.Point(338, 526)
        Me.cmd_Edit.Name = "cmd_Edit"
        Me.cmd_Edit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmd_Edit.Size = New System.Drawing.Size(67, 50)
        Me.cmd_Edit.TabIndex = 120
        Me.cmd_Edit.TabStop = False
        Me.cmd_Edit.Text = "Edit"
        Me.cmd_Edit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmd_Edit.UseVisualStyleBackColor = False
        '
        'lbl_Message
        '
        Me.lbl_Message.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_Message.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_Message.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Message.ForeColor = System.Drawing.Color.Red
        Me.lbl_Message.Location = New System.Drawing.Point(285, 486)
        Me.lbl_Message.Name = "lbl_Message"
        Me.lbl_Message.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_Message.Size = New System.Drawing.Size(405, 16)
        Me.lbl_Message.TabIndex = 124
        Me.lbl_Message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'fra_Category
        '
        Me.fra_Category.BackColor = System.Drawing.SystemColors.Control
        Me.fra_Category.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.fra_Category.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.fra_Category.Location = New System.Drawing.Point(300, 236)
        Me.fra_Category.Name = "fra_Category"
        Me.fra_Category.Padding = New System.Windows.Forms.Padding(0)
        Me.fra_Category.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fra_Category.Size = New System.Drawing.Size(375, 229)
        Me.fra_Category.TabIndex = 125
        Me.fra_Category.TabStop = False
        Me.fra_Category.Text = "Category"
        '
        'frm_PayeeEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(699, 597)
        Me.Controls.Add(Me.fra_Category)
        Me.Controls.Add(Me.lbl_Message)
        Me.Controls.Add(Me.cmd_ExitSave)
        Me.Controls.Add(Me.cmd_DeleteCancel)
        Me.Controls.Add(Me.cmd_NewRestore)
        Me.Controls.Add(Me.cmd_Edit)
        Me.Controls.Add(Me.fra_PayeeInfo)
        Me.Controls.Add(Me.fra_List)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_PayeeEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Checkbook Payee Editor"
        Me.fra_List.ResumeLayout(False)
        Me.fra_Listbox1.ResumeLayout(False)
        Me.fra_PayeeInfo.ResumeLayout(False)
        Me.fra_PayeeInfo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents fra_List As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_Listbox As System.Windows.Forms.Label
    Public WithEvents fra_Listbox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Public WithEvents fra_PayeeInfo As System.Windows.Forms.GroupBox
    Public WithEvents tbox_Address As System.Windows.Forms.TextBox
    Public WithEvents tbox_City As System.Windows.Forms.TextBox
    Public WithEvents tbox_State As System.Windows.Forms.TextBox
    Public WithEvents tbox_ZipCode As System.Windows.Forms.MaskedTextBox
    Public WithEvents lbl_State As System.Windows.Forms.Label
    Public WithEvents lbl_ZipCode As System.Windows.Forms.Label
    Public WithEvents lbl_City As System.Windows.Forms.Label
    Public WithEvents lbl_Address As System.Windows.Forms.Label
    Public WithEvents cmd_ExitSave As System.Windows.Forms.Button
    Public WithEvents cmd_DeleteCancel As System.Windows.Forms.Button
    Public WithEvents cmd_NewRestore As System.Windows.Forms.Button
    Public WithEvents cmd_Edit As System.Windows.Forms.Button
    Public WithEvents lbl_Message As System.Windows.Forms.Label
    Public WithEvents tbox_Payee As System.Windows.Forms.TextBox
    Public WithEvents lbl_CompanyName1 As System.Windows.Forms.Label
    Public WithEvents fra_Category As System.Windows.Forms.GroupBox
End Class
