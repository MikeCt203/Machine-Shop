<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Logon
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
        Me.fra_LogonOutside = New System.Windows.Forms.GroupBox()
        Me.cmd_OK = New System.Windows.Forms.Button()
        Me.fra_LogonInside = New System.Windows.Forms.GroupBox()
        Me.tbox_UserId = New System.Windows.Forms.TextBox()
        Me.tbox_Password = New System.Windows.Forms.TextBox()
        Me.lbl_UserID = New System.Windows.Forms.Label()
        Me.lbl_Password = New System.Windows.Forms.Label()
        Me.cmd_Exit = New System.Windows.Forms.Button()
        Me.fra_LogonOutside.SuspendLayout()
        Me.fra_LogonInside.SuspendLayout()
        Me.SuspendLayout()
        '
        'fra_LogonOutside
        '
        Me.fra_LogonOutside.BackColor = System.Drawing.SystemColors.Control
        Me.fra_LogonOutside.Controls.Add(Me.cmd_OK)
        Me.fra_LogonOutside.Controls.Add(Me.fra_LogonInside)
        Me.fra_LogonOutside.Controls.Add(Me.cmd_Exit)
        Me.fra_LogonOutside.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fra_LogonOutside.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fra_LogonOutside.Location = New System.Drawing.Point(20, 20)
        Me.fra_LogonOutside.Name = "fra_LogonOutside"
        Me.fra_LogonOutside.Padding = New System.Windows.Forms.Padding(0)
        Me.fra_LogonOutside.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fra_LogonOutside.Size = New System.Drawing.Size(267, 127)
        Me.fra_LogonOutside.TabIndex = 1
        Me.fra_LogonOutside.TabStop = False
        '
        'cmd_OK
        '
        Me.cmd_OK.BackColor = System.Drawing.SystemColors.Control
        Me.cmd_OK.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmd_OK.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_OK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmd_OK.Image = Global.Machine_Shop.My.Resources.Resources.OK
        Me.cmd_OK.Location = New System.Drawing.Point(194, 20)
        Me.cmd_OK.Name = "cmd_OK"
        Me.cmd_OK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmd_OK.Size = New System.Drawing.Size(57, 44)
        Me.cmd_OK.TabIndex = 1
        Me.cmd_OK.TabStop = False
        Me.cmd_OK.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmd_OK.UseVisualStyleBackColor = False
        '
        'fra_LogonInside
        '
        Me.fra_LogonInside.BackColor = System.Drawing.SystemColors.Control
        Me.fra_LogonInside.Controls.Add(Me.tbox_UserId)
        Me.fra_LogonInside.Controls.Add(Me.tbox_Password)
        Me.fra_LogonInside.Controls.Add(Me.lbl_UserID)
        Me.fra_LogonInside.Controls.Add(Me.lbl_Password)
        Me.fra_LogonInside.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fra_LogonInside.ForeColor = System.Drawing.Color.Blue
        Me.fra_LogonInside.Location = New System.Drawing.Point(17, 20)
        Me.fra_LogonInside.Name = "fra_LogonInside"
        Me.fra_LogonInside.Padding = New System.Windows.Forms.Padding(0)
        Me.fra_LogonInside.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fra_LogonInside.Size = New System.Drawing.Size(160, 90)
        Me.fra_LogonInside.TabIndex = 5
        Me.fra_LogonInside.TabStop = False
        Me.fra_LogonInside.Text = "Logon"
        '
        'tbox_UserId
        '
        Me.tbox_UserId.AcceptsReturn = True
        Me.tbox_UserId.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_UserId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_UserId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbox_UserId.Location = New System.Drawing.Point(77, 20)
        Me.tbox_UserId.MaxLength = 0
        Me.tbox_UserId.Name = "tbox_UserId"
        Me.tbox_UserId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbox_UserId.Size = New System.Drawing.Size(70, 20)
        Me.tbox_UserId.TabIndex = 1
        '
        'tbox_Password
        '
        Me.tbox_Password.AcceptsReturn = True
        Me.tbox_Password.BackColor = System.Drawing.SystemColors.Window
        Me.tbox_Password.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbox_Password.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbox_Password.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tbox_Password.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.tbox_Password.Location = New System.Drawing.Point(77, 54)
        Me.tbox_Password.MaxLength = 0
        Me.tbox_Password.Name = "tbox_Password"
        Me.tbox_Password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbox_Password.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbox_Password.Size = New System.Drawing.Size(70, 20)
        Me.tbox_Password.TabIndex = 2
        '
        'lbl_UserID
        '
        Me.lbl_UserID.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_UserID.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_UserID.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_UserID.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_UserID.Location = New System.Drawing.Point(8, 24)
        Me.lbl_UserID.Name = "lbl_UserID"
        Me.lbl_UserID.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_UserID.Size = New System.Drawing.Size(66, 15)
        Me.lbl_UserID.TabIndex = 7
        Me.lbl_UserID.Text = "&User ID:"
        Me.lbl_UserID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_Password
        '
        Me.lbl_Password.AutoSize = True
        Me.lbl_Password.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_Password.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_Password.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Password.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_Password.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl_Password.Location = New System.Drawing.Point(8, 56)
        Me.lbl_Password.Name = "lbl_Password"
        Me.lbl_Password.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_Password.Size = New System.Drawing.Size(66, 15)
        Me.lbl_Password.TabIndex = 6
        Me.lbl_Password.Text = "&Password:"
        Me.lbl_Password.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmd_Exit
        '
        Me.cmd_Exit.BackColor = System.Drawing.SystemColors.Control
        Me.cmd_Exit.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmd_Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmd_Exit.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Exit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmd_Exit.Image = Global.Machine_Shop.My.Resources.Resources.Exit1
        Me.cmd_Exit.Location = New System.Drawing.Point(194, 72)
        Me.cmd_Exit.Name = "cmd_Exit"
        Me.cmd_Exit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmd_Exit.Size = New System.Drawing.Size(57, 44)
        Me.cmd_Exit.TabIndex = 2
        Me.cmd_Exit.TabStop = False
        Me.cmd_Exit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmd_Exit.UseVisualStyleBackColor = False
        '
        'frm_Logon
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(309, 168)
        Me.ControlBox = False
        Me.Controls.Add(Me.fra_LogonOutside)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Logon"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Logon"
        Me.fra_LogonOutside.ResumeLayout(False)
        Me.fra_LogonInside.ResumeLayout(False)
        Me.fra_LogonInside.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents fra_LogonOutside As System.Windows.Forms.GroupBox
    Public WithEvents cmd_OK As System.Windows.Forms.Button
    Public WithEvents fra_LogonInside As System.Windows.Forms.GroupBox
    Public WithEvents tbox_UserId As System.Windows.Forms.TextBox
    Public WithEvents tbox_Password As System.Windows.Forms.TextBox
    Public WithEvents lbl_UserID As System.Windows.Forms.Label
    Public WithEvents lbl_Password As System.Windows.Forms.Label
    Public WithEvents cmd_Exit As System.Windows.Forms.Button
End Class
