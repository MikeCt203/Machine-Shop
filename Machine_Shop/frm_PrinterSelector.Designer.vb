<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_PrinterSelector
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
        Me.Listbox_InstalledPrinters = New System.Windows.Forms.ListBox()
        Me.lbl_PleaseSelect = New System.Windows.Forms.Label()
        Me.cmd_Cancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Listbox_InstalledPrinters
        '
        Me.Listbox_InstalledPrinters.FormattingEnabled = True
        Me.Listbox_InstalledPrinters.Location = New System.Drawing.Point(12, 12)
        Me.Listbox_InstalledPrinters.Name = "Listbox_InstalledPrinters"
        Me.Listbox_InstalledPrinters.Size = New System.Drawing.Size(193, 147)
        Me.Listbox_InstalledPrinters.TabIndex = 1
        '
        'lbl_PleaseSelect
        '
        Me.lbl_PleaseSelect.AutoSize = True
        Me.lbl_PleaseSelect.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_PleaseSelect.ForeColor = System.Drawing.Color.DarkGreen
        Me.lbl_PleaseSelect.Location = New System.Drawing.Point(17, 170)
        Me.lbl_PleaseSelect.Name = "lbl_PleaseSelect"
        Me.lbl_PleaseSelect.Size = New System.Drawing.Size(182, 15)
        Me.lbl_PleaseSelect.TabIndex = 2
        Me.lbl_PleaseSelect.Text = "Please click to selected a printer"
        '
        'cmd_Cancel
        '
        Me.cmd_Cancel.BackColor = System.Drawing.Color.MintCream
        Me.cmd_Cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Cancel.Location = New System.Drawing.Point(221, 22)
        Me.cmd_Cancel.Name = "cmd_Cancel"
        Me.cmd_Cancel.Size = New System.Drawing.Size(64, 56)
        Me.cmd_Cancel.TabIndex = 3
        Me.cmd_Cancel.Text = "Cancel"
        Me.cmd_Cancel.UseVisualStyleBackColor = False
        '
        'frm_PrinterSelector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(299, 201)
        Me.Controls.Add(Me.cmd_Cancel)
        Me.Controls.Add(Me.lbl_PleaseSelect)
        Me.Controls.Add(Me.Listbox_InstalledPrinters)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_PrinterSelector"
        Me.Text = "Printer Selector"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Listbox_InstalledPrinters As ListBox
    Friend WithEvents lbl_PleaseSelect As Label
    Friend WithEvents cmd_Cancel As Button
End Class
