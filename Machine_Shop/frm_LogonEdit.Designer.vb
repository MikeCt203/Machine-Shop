<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_LogonEdit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_LogonEdit))
        Me.tbox_Password = New System.Windows.Forms.TextBox()
        Me.tbox_UserId = New System.Windows.Forms.TextBox()
        Me.lbl_Password = New System.Windows.Forms.Label()
        Me.lbl_UserID = New System.Windows.Forms.Label()
        Me.cmd_Next = New System.Windows.Forms.Button()
        Me.fra_LogonOutside = New System.Windows.Forms.GroupBox()
        Me.cmd_Previous = New System.Windows.Forms.Button()
        Me.chk_AutoLogon = New System.Windows.Forms.CheckBox()
        Me.fra_LogonInside = New System.Windows.Forms.GroupBox()
        Me.lbl_AutoLogon = New System.Windows.Forms.Label()
        Me.cmd_DeleteCancel = New System.Windows.Forms.Button()
        Me.cmd_NewRestore = New System.Windows.Forms.Button()
        Me.cmd_Edit = New System.Windows.Forms.Button()
        Me.cmd_ExitSave = New System.Windows.Forms.Button()
        Me.lbl_Line = New System.Windows.Forms.Label()
        Me.fra_LogonOutside.SuspendLayout()
        Me.fra_LogonInside.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbox_Password
        '
        Me.tbox_Password.AcceptsReturn = True
        Me.tbox_Password.BackColor = System.Drawing.Color.White
        Me.tbox_Password.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_Password.Enabled = False
        Me.tbox_Password.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_Password.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbox_Password.Location = New System.Drawing.Point(77, 57)
        Me.tbox_Password.MaxLength = 15
        Me.tbox_Password.Name = "tbox_Password"
        Me.tbox_Password.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbox_Password.Size = New System.Drawing.Size(80, 20)
        Me.tbox_Password.TabIndex = 2
        '
        'tbox_UserId
        '
        Me.tbox_UserId.AcceptsReturn = True
        Me.tbox_UserId.BackColor = System.Drawing.Color.White
        Me.tbox_UserId.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_UserId.Enabled = False
        Me.tbox_UserId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_UserId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbox_UserId.Location = New System.Drawing.Point(77, 20)
        Me.tbox_UserId.MaxLength = 15
        Me.tbox_UserId.Name = "tbox_UserId"
        Me.tbox_UserId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbox_UserId.Size = New System.Drawing.Size(80, 20)
        Me.tbox_UserId.TabIndex = 1
        '
        'lbl_Password
        '
        Me.lbl_Password.AutoSize = True
        Me.lbl_Password.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_Password.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_Password.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Password.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_Password.Location = New System.Drawing.Point(10, 59)
        Me.lbl_Password.Name = "lbl_Password"
        Me.lbl_Password.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_Password.Size = New System.Drawing.Size(66, 15)
        Me.lbl_Password.TabIndex = 5
        Me.lbl_Password.Text = "&Password:"
        Me.lbl_Password.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_UserID
        '
        Me.lbl_UserID.AutoSize = True
        Me.lbl_UserID.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_UserID.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_UserID.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_UserID.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_UserID.Location = New System.Drawing.Point(24, 22)
        Me.lbl_UserID.Name = "lbl_UserID"
        Me.lbl_UserID.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_UserID.Size = New System.Drawing.Size(52, 15)
        Me.lbl_UserID.TabIndex = 4
        Me.lbl_UserID.Text = "User ID:"
        Me.lbl_UserID.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmd_Next
        '
        Me.cmd_Next.BackColor = System.Drawing.SystemColors.Control
        Me.cmd_Next.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmd_Next.Enabled = False
        Me.cmd_Next.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Next.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmd_Next.Image = CType(resources.GetObject("cmd_Next.Image"), System.Drawing.Image)
        Me.cmd_Next.Location = New System.Drawing.Point(240, 97)
        Me.cmd_Next.Name = "cmd_Next"
        Me.cmd_Next.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmd_Next.Size = New System.Drawing.Size(44, 44)
        Me.cmd_Next.TabIndex = 13
        Me.cmd_Next.TabStop = False
        Me.cmd_Next.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmd_Next.UseVisualStyleBackColor = False
        '
        'fra_LogonOutside
        '
        Me.fra_LogonOutside.BackColor = System.Drawing.SystemColors.Control
        Me.fra_LogonOutside.Controls.Add(Me.cmd_Next)
        Me.fra_LogonOutside.Controls.Add(Me.cmd_Previous)
        Me.fra_LogonOutside.Controls.Add(Me.chk_AutoLogon)
        Me.fra_LogonOutside.Controls.Add(Me.fra_LogonInside)
        Me.fra_LogonOutside.Controls.Add(Me.lbl_AutoLogon)
        Me.fra_LogonOutside.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fra_LogonOutside.ForeColor = System.Drawing.Color.Blue
        Me.fra_LogonOutside.Location = New System.Drawing.Point(20, 15)
        Me.fra_LogonOutside.Name = "fra_LogonOutside"
        Me.fra_LogonOutside.Padding = New System.Windows.Forms.Padding(0)
        Me.fra_LogonOutside.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fra_LogonOutside.Size = New System.Drawing.Size(317, 164)
        Me.fra_LogonOutside.TabIndex = 13
        Me.fra_LogonOutside.TabStop = False
        '
        'cmd_Previous
        '
        Me.cmd_Previous.BackColor = System.Drawing.SystemColors.Control
        Me.cmd_Previous.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmd_Previous.Enabled = False
        Me.cmd_Previous.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Previous.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmd_Previous.Image = CType(resources.GetObject("cmd_Previous.Image"), System.Drawing.Image)
        Me.cmd_Previous.Location = New System.Drawing.Point(240, 30)
        Me.cmd_Previous.Name = "cmd_Previous"
        Me.cmd_Previous.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmd_Previous.Size = New System.Drawing.Size(44, 44)
        Me.cmd_Previous.TabIndex = 11
        Me.cmd_Previous.TabStop = False
        Me.cmd_Previous.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmd_Previous.UseVisualStyleBackColor = False
        '
        'chk_AutoLogon
        '
        Me.chk_AutoLogon.BackColor = System.Drawing.SystemColors.Control
        Me.chk_AutoLogon.Cursor = System.Windows.Forms.Cursors.Default
        Me.chk_AutoLogon.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_AutoLogon.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chk_AutoLogon.Location = New System.Drawing.Point(60, 140)
        Me.chk_AutoLogon.Name = "chk_AutoLogon"
        Me.chk_AutoLogon.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chk_AutoLogon.Size = New System.Drawing.Size(14, 14)
        Me.chk_AutoLogon.TabIndex = 7
        Me.chk_AutoLogon.TabStop = False
        Me.chk_AutoLogon.Text = "Automatic"
        Me.chk_AutoLogon.UseVisualStyleBackColor = False
        '
        'fra_LogonInside
        '
        Me.fra_LogonInside.BackColor = System.Drawing.SystemColors.Control
        Me.fra_LogonInside.Controls.Add(Me.tbox_Password)
        Me.fra_LogonInside.Controls.Add(Me.tbox_UserId)
        Me.fra_LogonInside.Controls.Add(Me.lbl_Password)
        Me.fra_LogonInside.Controls.Add(Me.lbl_UserID)
        Me.fra_LogonInside.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fra_LogonInside.ForeColor = System.Drawing.Color.Blue
        Me.fra_LogonInside.Location = New System.Drawing.Point(20, 30)
        Me.fra_LogonInside.Name = "fra_LogonInside"
        Me.fra_LogonInside.Padding = New System.Windows.Forms.Padding(0)
        Me.fra_LogonInside.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fra_LogonInside.Size = New System.Drawing.Size(180, 100)
        Me.fra_LogonInside.TabIndex = 3
        Me.fra_LogonInside.TabStop = False
        Me.fra_LogonInside.Text = "Users"
        '
        'lbl_AutoLogon
        '
        Me.lbl_AutoLogon.AutoSize = True
        Me.lbl_AutoLogon.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_AutoLogon.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_AutoLogon.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_AutoLogon.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_AutoLogon.Location = New System.Drawing.Point(80, 140)
        Me.lbl_AutoLogon.Name = "lbl_AutoLogon"
        Me.lbl_AutoLogon.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_AutoLogon.Size = New System.Drawing.Size(99, 15)
        Me.lbl_AutoLogon.TabIndex = 8
        Me.lbl_AutoLogon.Text = "Automatic Logon"
        '
        'cmd_DeleteCancel
        '
        Me.cmd_DeleteCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmd_DeleteCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmd_DeleteCancel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_DeleteCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmd_DeleteCancel.Image = Global.Machine_Shop.My.Resources.Resources.Delete
        Me.cmd_DeleteCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_DeleteCancel.Location = New System.Drawing.Point(184, 192)
        Me.cmd_DeleteCancel.Name = "cmd_DeleteCancel"
        Me.cmd_DeleteCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmd_DeleteCancel.Size = New System.Drawing.Size(64, 55)
        Me.cmd_DeleteCancel.TabIndex = 17
        Me.cmd_DeleteCancel.TabStop = False
        Me.cmd_DeleteCancel.Text = "Delete"
        Me.cmd_DeleteCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmd_DeleteCancel.UseVisualStyleBackColor = False
        '
        'cmd_NewRestore
        '
        Me.cmd_NewRestore.BackColor = System.Drawing.SystemColors.Control
        Me.cmd_NewRestore.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmd_NewRestore.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_NewRestore.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmd_NewRestore.Image = Global.Machine_Shop.My.Resources.Resources._New
        Me.cmd_NewRestore.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_NewRestore.Location = New System.Drawing.Point(109, 192)
        Me.cmd_NewRestore.Name = "cmd_NewRestore"
        Me.cmd_NewRestore.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmd_NewRestore.Size = New System.Drawing.Size(64, 55)
        Me.cmd_NewRestore.TabIndex = 16
        Me.cmd_NewRestore.TabStop = False
        Me.cmd_NewRestore.Text = "New"
        Me.cmd_NewRestore.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmd_NewRestore.UseVisualStyleBackColor = False
        '
        'cmd_Edit
        '
        Me.cmd_Edit.BackColor = System.Drawing.SystemColors.Control
        Me.cmd_Edit.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmd_Edit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Edit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmd_Edit.Image = Global.Machine_Shop.My.Resources.Resources.Edit
        Me.cmd_Edit.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_Edit.Location = New System.Drawing.Point(34, 192)
        Me.cmd_Edit.Name = "cmd_Edit"
        Me.cmd_Edit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmd_Edit.Size = New System.Drawing.Size(64, 55)
        Me.cmd_Edit.TabIndex = 15
        Me.cmd_Edit.TabStop = False
        Me.cmd_Edit.Text = "Edit"
        Me.cmd_Edit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmd_Edit.UseVisualStyleBackColor = False
        '
        'cmd_ExitSave
        '
        Me.cmd_ExitSave.BackColor = System.Drawing.SystemColors.Control
        Me.cmd_ExitSave.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmd_ExitSave.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_ExitSave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmd_ExitSave.Image = Global.Machine_Shop.My.Resources.Resources._Exit
        Me.cmd_ExitSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_ExitSave.Location = New System.Drawing.Point(259, 192)
        Me.cmd_ExitSave.Name = "cmd_ExitSave"
        Me.cmd_ExitSave.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmd_ExitSave.Size = New System.Drawing.Size(66, 55)
        Me.cmd_ExitSave.TabIndex = 14
        Me.cmd_ExitSave.TabStop = False
        Me.cmd_ExitSave.Text = "Exit"
        Me.cmd_ExitSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmd_ExitSave.UseVisualStyleBackColor = False
        '
        'lbl_Line
        '
        Me.lbl_Line.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lbl_Line.Location = New System.Drawing.Point(20, 15)
        Me.lbl_Line.Name = "lbl_Line"
        Me.lbl_Line.Size = New System.Drawing.Size(317, 7)
        Me.lbl_Line.TabIndex = 18
        '
        'frm_LogonEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(359, 261)
        Me.ControlBox = False
        Me.Controls.Add(Me.lbl_Line)
        Me.Controls.Add(Me.fra_LogonOutside)
        Me.Controls.Add(Me.cmd_DeleteCancel)
        Me.Controls.Add(Me.cmd_NewRestore)
        Me.Controls.Add(Me.cmd_Edit)
        Me.Controls.Add(Me.cmd_ExitSave)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "frm_LogonEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " * * *  Logon Edit  * * * "
        Me.fra_LogonOutside.ResumeLayout(False)
        Me.fra_LogonOutside.PerformLayout()
        Me.fra_LogonInside.ResumeLayout(False)
        Me.fra_LogonInside.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents tbox_Password As System.Windows.Forms.TextBox
    Public WithEvents tbox_UserId As System.Windows.Forms.TextBox
    Public WithEvents lbl_Password As System.Windows.Forms.Label
    Public WithEvents lbl_UserID As System.Windows.Forms.Label
    Public WithEvents cmd_Next As System.Windows.Forms.Button
    Public WithEvents fra_LogonOutside As System.Windows.Forms.GroupBox
    Public WithEvents cmd_Previous As System.Windows.Forms.Button
    Public WithEvents chk_AutoLogon As System.Windows.Forms.CheckBox
    Public WithEvents fra_LogonInside As System.Windows.Forms.GroupBox
    Public WithEvents cmd_DeleteCancel As System.Windows.Forms.Button
    Public WithEvents cmd_NewRestore As System.Windows.Forms.Button
    Public WithEvents cmd_Edit As System.Windows.Forms.Button
    Public WithEvents cmd_ExitSave As System.Windows.Forms.Button
    Public WithEvents lbl_AutoLogon As System.Windows.Forms.Label
    Friend WithEvents lbl_Line As System.Windows.Forms.Label
End Class
