﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_EmployeeDirectory
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_EmployeeDirectory))
        Me.Label_Top = New System.Windows.Forms.Label()
        Me.fra_SearchCriteria = New System.Windows.Forms.GroupBox()
        Me.cmd_PrintAll = New System.Windows.Forms.Button()
        Me.cmd_Print = New System.Windows.Forms.Button()
        Me.cmd_Exit = New System.Windows.Forms.Button()
        Me.Label_Top1 = New System.Windows.Forms.Label()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.Label_Company = New System.Windows.Forms.Label()
        Me.Label_LastName = New System.Windows.Forms.Label()
        Me.Lbl_PaymentSchedule = New System.Windows.Forms.Label()
        Me.Label_HeaderDates = New System.Windows.Forms.Label()
        Me.Label_Contact = New System.Windows.Forms.Label()
        Me.Label_StreetAddress = New System.Windows.Forms.Label()
        Me.Label_PhoneNo1 = New System.Windows.Forms.Label()
        Me.fra_EmployeeDirectory = New System.Windows.Forms.GroupBox()
        Me.Label_State = New System.Windows.Forms.Label()
        Me.Label_City = New System.Windows.Forms.Label()
        Me.Label_Emergency = New System.Windows.Forms.Label()
        Me.lbl_Page = New System.Windows.Forms.Label()
        Me.Label_FirstName = New System.Windows.Forms.Label()
        Me.Label_PhoneNo2 = New System.Windows.Forms.Label()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.Line_Vert4 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.Line_Vert5 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.Line_Vert1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.Line_Vert6 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.Line_Vert2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineRectangleBottom = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineRectangleRight = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineRectangleLeft = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineRectangleTop = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.Line_Vert3 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineHorz3 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineHorz2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineHorz1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.fra_Pages = New System.Windows.Forms.GroupBox()
        Me.cmd_Previous = New System.Windows.Forms.Button()
        Me.Label_Pages = New System.Windows.Forms.Label()
        Me.cmd_Next = New System.Windows.Forms.Button()
        Me.Label_Banner2 = New System.Windows.Forms.Label()
        Me.fra_SearchCriteria.SuspendLayout()
        Me.fra_EmployeeDirectory.SuspendLayout()
        Me.fra_Pages.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label_Top
        '
        Me.Label_Top.Location = New System.Drawing.Point(170, 4)
        Me.Label_Top.Name = "Label_Top"
        Me.Label_Top.Size = New System.Drawing.Size(785, 10)
        Me.Label_Top.TabIndex = 1
        '
        'fra_SearchCriteria
        '
        Me.fra_SearchCriteria.BackColor = System.Drawing.Color.PapayaWhip
        Me.fra_SearchCriteria.Controls.Add(Me.cmd_PrintAll)
        Me.fra_SearchCriteria.Controls.Add(Me.cmd_Print)
        Me.fra_SearchCriteria.Controls.Add(Me.cmd_Exit)
        Me.fra_SearchCriteria.ForeColor = System.Drawing.Color.Green
        Me.fra_SearchCriteria.Location = New System.Drawing.Point(16, 10)
        Me.fra_SearchCriteria.Name = "fra_SearchCriteria"
        Me.fra_SearchCriteria.Size = New System.Drawing.Size(137, 191)
        Me.fra_SearchCriteria.TabIndex = 129
        Me.fra_SearchCriteria.TabStop = False
        '
        'cmd_PrintAll
        '
        Me.cmd_PrintAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_PrintAll.Location = New System.Drawing.Point(23, 77)
        Me.cmd_PrintAll.Name = "cmd_PrintAll"
        Me.cmd_PrintAll.Size = New System.Drawing.Size(90, 42)
        Me.cmd_PrintAll.TabIndex = 147
        Me.cmd_PrintAll.Text = "Print All"
        Me.cmd_PrintAll.UseVisualStyleBackColor = True
        '
        'cmd_Print
        '
        Me.cmd_Print.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Print.Location = New System.Drawing.Point(23, 26)
        Me.cmd_Print.Name = "cmd_Print"
        Me.cmd_Print.Size = New System.Drawing.Size(90, 42)
        Me.cmd_Print.TabIndex = 137
        Me.cmd_Print.Text = "Print"
        Me.cmd_Print.UseVisualStyleBackColor = True
        '
        'cmd_Exit
        '
        Me.cmd_Exit.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Exit.Location = New System.Drawing.Point(23, 128)
        Me.cmd_Exit.Name = "cmd_Exit"
        Me.cmd_Exit.Size = New System.Drawing.Size(90, 42)
        Me.cmd_Exit.TabIndex = 146
        Me.cmd_Exit.Text = "Exit"
        Me.cmd_Exit.UseVisualStyleBackColor = True
        '
        'Label_Top1
        '
        Me.Label_Top1.Location = New System.Drawing.Point(10, 8)
        Me.Label_Top1.Name = "Label_Top1"
        Me.Label_Top1.Size = New System.Drawing.Size(145, 8)
        Me.Label_Top1.TabIndex = 130
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'Label_Company
        '
        Me.Label_Company.Font = New System.Drawing.Font("Arial", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Company.Location = New System.Drawing.Point(102, 65)
        Me.Label_Company.Name = "Label_Company"
        Me.Label_Company.Size = New System.Drawing.Size(580, 40)
        Me.Label_Company.TabIndex = 0
        Me.Label_Company.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_LastName
        '
        Me.Label_LastName.BackColor = System.Drawing.Color.White
        Me.Label_LastName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_LastName.Location = New System.Drawing.Point(16, 165)
        Me.Label_LastName.Name = "Label_LastName"
        Me.Label_LastName.Size = New System.Drawing.Size(124, 15)
        Me.Label_LastName.TabIndex = 158
        Me.Label_LastName.Text = "Last Name"
        Me.Label_LastName.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Lbl_PaymentSchedule
        '
        Me.Lbl_PaymentSchedule.AutoSize = True
        Me.Lbl_PaymentSchedule.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_PaymentSchedule.Location = New System.Drawing.Point(263, 27)
        Me.Lbl_PaymentSchedule.Name = "Lbl_PaymentSchedule"
        Me.Lbl_PaymentSchedule.Size = New System.Drawing.Size(271, 33)
        Me.Lbl_PaymentSchedule.TabIndex = 160
        Me.Lbl_PaymentSchedule.Text = "Employee Directory"
        '
        'Label_HeaderDates
        '
        Me.Label_HeaderDates.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_HeaderDates.Location = New System.Drawing.Point(162, 110)
        Me.Label_HeaderDates.Name = "Label_HeaderDates"
        Me.Label_HeaderDates.Size = New System.Drawing.Size(440, 27)
        Me.Label_HeaderDates.TabIndex = 161
        Me.Label_HeaderDates.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Contact
        '
        Me.Label_Contact.BackColor = System.Drawing.Color.White
        Me.Label_Contact.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Contact.Location = New System.Drawing.Point(579, 150)
        Me.Label_Contact.Name = "Label_Contact"
        Me.Label_Contact.Size = New System.Drawing.Size(94, 15)
        Me.Label_Contact.TabIndex = 166
        Me.Label_Contact.Text = "Contact"
        Me.Label_Contact.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_StreetAddress
        '
        Me.Label_StreetAddress.BackColor = System.Drawing.Color.White
        Me.Label_StreetAddress.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_StreetAddress.Location = New System.Drawing.Point(266, 165)
        Me.Label_StreetAddress.Name = "Label_StreetAddress"
        Me.Label_StreetAddress.Size = New System.Drawing.Size(190, 15)
        Me.Label_StreetAddress.TabIndex = 169
        Me.Label_StreetAddress.Text = "Street Address"
        Me.Label_StreetAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_PhoneNo1
        '
        Me.Label_PhoneNo1.BackColor = System.Drawing.Color.White
        Me.Label_PhoneNo1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_PhoneNo1.Location = New System.Drawing.Point(579, 165)
        Me.Label_PhoneNo1.Name = "Label_PhoneNo1"
        Me.Label_PhoneNo1.Size = New System.Drawing.Size(94, 15)
        Me.Label_PhoneNo1.TabIndex = 172
        Me.Label_PhoneNo1.Text = "Phone No"
        Me.Label_PhoneNo1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'fra_EmployeeDirectory
        '
        Me.fra_EmployeeDirectory.BackColor = System.Drawing.Color.White
        Me.fra_EmployeeDirectory.Controls.Add(Me.Label_State)
        Me.fra_EmployeeDirectory.Controls.Add(Me.Label_City)
        Me.fra_EmployeeDirectory.Controls.Add(Me.Label_Emergency)
        Me.fra_EmployeeDirectory.Controls.Add(Me.lbl_Page)
        Me.fra_EmployeeDirectory.Controls.Add(Me.Label_FirstName)
        Me.fra_EmployeeDirectory.Controls.Add(Me.Label_PhoneNo2)
        Me.fra_EmployeeDirectory.Controls.Add(Me.Label_PhoneNo1)
        Me.fra_EmployeeDirectory.Controls.Add(Me.Label_StreetAddress)
        Me.fra_EmployeeDirectory.Controls.Add(Me.Label_Contact)
        Me.fra_EmployeeDirectory.Controls.Add(Me.Label_HeaderDates)
        Me.fra_EmployeeDirectory.Controls.Add(Me.Lbl_PaymentSchedule)
        Me.fra_EmployeeDirectory.Controls.Add(Me.Label_LastName)
        Me.fra_EmployeeDirectory.Controls.Add(Me.Label_Company)
        Me.fra_EmployeeDirectory.Controls.Add(Me.ShapeContainer1)
        Me.fra_EmployeeDirectory.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fra_EmployeeDirectory.Location = New System.Drawing.Point(170, 8)
        Me.fra_EmployeeDirectory.Name = "fra_EmployeeDirectory"
        Me.fra_EmployeeDirectory.Size = New System.Drawing.Size(785, 848)
        Me.fra_EmployeeDirectory.TabIndex = 89
        Me.fra_EmployeeDirectory.TabStop = False
        '
        'Label_State
        '
        Me.Label_State.BackColor = System.Drawing.Color.White
        Me.Label_State.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_State.Location = New System.Drawing.Point(538, 165)
        Me.Label_State.Name = "Label_State"
        Me.Label_State.Size = New System.Drawing.Size(40, 15)
        Me.Label_State.TabIndex = 202
        Me.Label_State.Text = "State"
        Me.Label_State.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_City
        '
        Me.Label_City.BackColor = System.Drawing.Color.White
        Me.Label_City.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_City.Location = New System.Drawing.Point(457, 165)
        Me.Label_City.Name = "Label_City"
        Me.Label_City.Size = New System.Drawing.Size(80, 15)
        Me.Label_City.TabIndex = 201
        Me.Label_City.Text = "City"
        Me.Label_City.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Emergency
        '
        Me.Label_Emergency.BackColor = System.Drawing.Color.White
        Me.Label_Emergency.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Emergency.Location = New System.Drawing.Point(674, 150)
        Me.Label_Emergency.Name = "Label_Emergency"
        Me.Label_Emergency.Size = New System.Drawing.Size(94, 15)
        Me.Label_Emergency.TabIndex = 200
        Me.Label_Emergency.Text = "Emergency"
        Me.Label_Emergency.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Page
        '
        Me.lbl_Page.AutoSize = True
        Me.lbl_Page.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Page.Location = New System.Drawing.Point(707, 28)
        Me.lbl_Page.Name = "lbl_Page"
        Me.lbl_Page.Size = New System.Drawing.Size(46, 15)
        Me.lbl_Page.TabIndex = 199
        Me.lbl_Page.Text = "Page 1"
        '
        'Label_FirstName
        '
        Me.Label_FirstName.BackColor = System.Drawing.Color.White
        Me.Label_FirstName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_FirstName.Location = New System.Drawing.Point(141, 165)
        Me.Label_FirstName.Name = "Label_FirstName"
        Me.Label_FirstName.Size = New System.Drawing.Size(124, 15)
        Me.Label_FirstName.TabIndex = 192
        Me.Label_FirstName.Text = "First Name"
        Me.Label_FirstName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_PhoneNo2
        '
        Me.Label_PhoneNo2.BackColor = System.Drawing.Color.White
        Me.Label_PhoneNo2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_PhoneNo2.Location = New System.Drawing.Point(674, 165)
        Me.Label_PhoneNo2.Name = "Label_PhoneNo2"
        Me.Label_PhoneNo2.Size = New System.Drawing.Size(94, 15)
        Me.Label_PhoneNo2.TabIndex = 184
        Me.Label_PhoneNo2.Text = "Phone No"
        Me.Label_PhoneNo2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(3, 16)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.Line_Vert4, Me.Line_Vert5, Me.Line_Vert1, Me.Line_Vert6, Me.Line_Vert2, Me.LineRectangleBottom, Me.LineRectangleRight, Me.LineRectangleLeft, Me.LineRectangleTop, Me.Line_Vert3, Me.LineHorz3, Me.LineHorz2, Me.LineHorz1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(779, 829)
        Me.ShapeContainer1.TabIndex = 1
        Me.ShapeContainer1.TabStop = False
        '
        'Line_Vert4
        '
        Me.Line_Vert4.Name = "Line_Vert4"
        Me.Line_Vert4.X1 = 534
        Me.Line_Vert4.X2 = 534
        Me.Line_Vert4.Y1 = 133
        Me.Line_Vert4.Y2 = 815
        '
        'Line_Vert5
        '
        Me.Line_Vert5.Name = "Line_Vert5"
        Me.Line_Vert5.X1 = 575
        Me.Line_Vert5.X2 = 575
        Me.Line_Vert5.Y1 = 133
        Me.Line_Vert5.Y2 = 815
        '
        'Line_Vert1
        '
        Me.Line_Vert1.Name = "Line_Vert1"
        Me.Line_Vert1.X1 = 137
        Me.Line_Vert1.X2 = 137
        Me.Line_Vert1.Y1 = 133
        Me.Line_Vert1.Y2 = 815
        '
        'Line_Vert6
        '
        Me.Line_Vert6.Name = "Line_Vert6"
        Me.Line_Vert6.X1 = 670
        Me.Line_Vert6.X2 = 670
        Me.Line_Vert6.Y1 = 133
        Me.Line_Vert6.Y2 = 815
        '
        'Line_Vert2
        '
        Me.Line_Vert2.Name = "Line_Vert2"
        Me.Line_Vert2.X1 = 262
        Me.Line_Vert2.X2 = 262
        Me.Line_Vert2.Y1 = 133
        Me.Line_Vert2.Y2 = 815
        '
        'LineRectangleBottom
        '
        Me.LineRectangleBottom.Name = "LineRectangleBottom"
        Me.LineRectangleBottom.X1 = 12
        Me.LineRectangleBottom.X2 = 765
        Me.LineRectangleBottom.Y1 = 815
        Me.LineRectangleBottom.Y2 = 815
        '
        'LineRectangleRight
        '
        Me.LineRectangleRight.Name = "LineRectangleRight"
        Me.LineRectangleRight.X1 = 765
        Me.LineRectangleRight.X2 = 765
        Me.LineRectangleRight.Y1 = 5
        Me.LineRectangleRight.Y2 = 814
        '
        'LineRectangleLeft
        '
        Me.LineRectangleLeft.Name = "LineRectangleLeft"
        Me.LineRectangleLeft.X1 = 12
        Me.LineRectangleLeft.X2 = 12
        Me.LineRectangleLeft.Y1 = 5
        Me.LineRectangleLeft.Y2 = 814
        '
        'LineRectangleTop
        '
        Me.LineRectangleTop.Name = "LineRectangleTop"
        Me.LineRectangleTop.X1 = 12
        Me.LineRectangleTop.X2 = 765
        Me.LineRectangleTop.Y1 = 5
        Me.LineRectangleTop.Y2 = 5
        '
        'Line_Vert3
        '
        Me.Line_Vert3.Name = "Line_Vert3"
        Me.Line_Vert3.X1 = 453
        Me.Line_Vert3.X2 = 453
        Me.Line_Vert3.Y1 = 133
        Me.Line_Vert3.Y2 = 815
        '
        'LineHorz3
        '
        Me.LineHorz3.Name = "LineHorz3"
        Me.LineHorz3.X1 = 12
        Me.LineHorz3.X2 = 765
        Me.LineHorz3.Y1 = 164
        Me.LineHorz3.Y2 = 164
        '
        'LineHorz2
        '
        Me.LineHorz2.Name = "LineHorz2"
        Me.LineHorz2.X1 = 12
        Me.LineHorz2.X2 = 765
        Me.LineHorz2.Y1 = 133
        Me.LineHorz2.Y2 = 133
        '
        'LineHorz1
        '
        Me.LineHorz1.Name = "LineHorz1"
        Me.LineHorz1.X1 = 12
        Me.LineHorz1.X2 = 765
        Me.LineHorz1.Y1 = 130
        Me.LineHorz1.Y2 = 130
        '
        'fra_Pages
        '
        Me.fra_Pages.BackColor = System.Drawing.Color.PapayaWhip
        Me.fra_Pages.Controls.Add(Me.cmd_Previous)
        Me.fra_Pages.Controls.Add(Me.Label_Pages)
        Me.fra_Pages.Controls.Add(Me.cmd_Next)
        Me.fra_Pages.ForeColor = System.Drawing.Color.Green
        Me.fra_Pages.Location = New System.Drawing.Point(16, 211)
        Me.fra_Pages.Name = "fra_Pages"
        Me.fra_Pages.Size = New System.Drawing.Size(137, 102)
        Me.fra_Pages.TabIndex = 131
        Me.fra_Pages.TabStop = False
        '
        'cmd_Previous
        '
        Me.cmd_Previous.Enabled = False
        Me.cmd_Previous.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Previous.Image = Global.Machine_Shop.My.Resources.Resources.Previous
        Me.cmd_Previous.Location = New System.Drawing.Point(19, 44)
        Me.cmd_Previous.Name = "cmd_Previous"
        Me.cmd_Previous.Size = New System.Drawing.Size(40, 45)
        Me.cmd_Previous.TabIndex = 137
        Me.cmd_Previous.Text = "<--"
        Me.cmd_Previous.UseVisualStyleBackColor = True
        '
        'Label_Pages
        '
        Me.Label_Pages.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Pages.Location = New System.Drawing.Point(10, 16)
        Me.Label_Pages.Name = "Label_Pages"
        Me.Label_Pages.Size = New System.Drawing.Size(117, 24)
        Me.Label_Pages.TabIndex = 136
        Me.Label_Pages.Text = "Pages"
        Me.Label_Pages.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmd_Next
        '
        Me.cmd_Next.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Next.Image = Global.Machine_Shop.My.Resources.Resources._Next
        Me.cmd_Next.Location = New System.Drawing.Point(80, 44)
        Me.cmd_Next.Name = "cmd_Next"
        Me.cmd_Next.Size = New System.Drawing.Size(38, 45)
        Me.cmd_Next.TabIndex = 146
        Me.cmd_Next.UseVisualStyleBackColor = True
        '
        'Label_Banner2
        '
        Me.Label_Banner2.Location = New System.Drawing.Point(10, 209)
        Me.Label_Banner2.Name = "Label_Banner2"
        Me.Label_Banner2.Size = New System.Drawing.Size(145, 8)
        Me.Label_Banner2.TabIndex = 132
        '
        'frm_EmployeeDirectory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(969, 869)
        Me.Controls.Add(Me.Label_Banner2)
        Me.Controls.Add(Me.fra_Pages)
        Me.Controls.Add(Me.Label_Top1)
        Me.Controls.Add(Me.fra_SearchCriteria)
        Me.Controls.Add(Me.Label_Top)
        Me.Controls.Add(Me.fra_EmployeeDirectory)
        Me.Name = "frm_EmployeeDirectory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Employee Directory"
        Me.fra_SearchCriteria.ResumeLayout(False)
        Me.fra_EmployeeDirectory.ResumeLayout(False)
        Me.fra_EmployeeDirectory.PerformLayout()
        Me.fra_Pages.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label_Top As System.Windows.Forms.Label
    Friend WithEvents fra_SearchCriteria As System.Windows.Forms.GroupBox
    Friend WithEvents Label_Top1 As System.Windows.Forms.Label
    Friend WithEvents lbl_ItemNumber As System.Windows.Forms.Label
    Friend WithEvents cmd_Print As System.Windows.Forms.Button
    Friend WithEvents cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents Label_Company As System.Windows.Forms.Label
    Friend WithEvents Label_LastName As System.Windows.Forms.Label
    Friend WithEvents Lbl_PaymentSchedule As System.Windows.Forms.Label
    Friend WithEvents Label_HeaderDates As System.Windows.Forms.Label
    Friend WithEvents Label_Contact As System.Windows.Forms.Label
    Friend WithEvents Label_StreetAddress As System.Windows.Forms.Label
    Friend WithEvents Label_PhoneNo1 As System.Windows.Forms.Label
    Friend WithEvents fra_EmployeeDirectory As System.Windows.Forms.GroupBox
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents Line_Vert6 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents Line_Vert2 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineRectangleBottom As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineRectangleRight As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineRectangleLeft As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineRectangleTop As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents Line_Vert3 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineHorz3 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineHorz2 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineHorz1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents Label_PhoneNo2 As System.Windows.Forms.Label
    Friend WithEvents Label_FirstName As System.Windows.Forms.Label
    Friend WithEvents Line_Vert1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents fra_Pages As System.Windows.Forms.GroupBox
    Friend WithEvents cmd_Previous As System.Windows.Forms.Button
    Friend WithEvents Label_Pages As System.Windows.Forms.Label
    Friend WithEvents cmd_Next As System.Windows.Forms.Button
    Friend WithEvents Label_Banner2 As System.Windows.Forms.Label
    Friend WithEvents lbl_Page As System.Windows.Forms.Label
    Friend WithEvents cmd_PrintAll As System.Windows.Forms.Button
    Friend WithEvents Label_Emergency As System.Windows.Forms.Label
    Friend WithEvents Line_Vert5 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents Label_State As System.Windows.Forms.Label
    Friend WithEvents Label_City As System.Windows.Forms.Label
    Friend WithEvents Line_Vert4 As Microsoft.VisualBasic.PowerPacks.LineShape
End Class
