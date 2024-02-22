<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_PaymentSchedule
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_PaymentSchedule))
        Me.Label_Top = New System.Windows.Forms.Label()
        Me.fra_SearchCriteria = New System.Windows.Forms.GroupBox()
        Me.cmd_PrintAll = New System.Windows.Forms.Button()
        Me.cmd_Print = New System.Windows.Forms.Button()
        Me.cmd_Exit = New System.Windows.Forms.Button()
        Me.Label_Top1 = New System.Windows.Forms.Label()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.Label_Company = New System.Windows.Forms.Label()
        Me.Label_CustomerName = New System.Windows.Forms.Label()
        Me.Lbl_PaymentSchedule = New System.Windows.Forms.Label()
        Me.Label_HeaderDates = New System.Windows.Forms.Label()
        Me.Label_PO1 = New System.Windows.Forms.Label()
        Me.Label_PO2 = New System.Windows.Forms.Label()
        Me.Label_Drawing1 = New System.Windows.Forms.Label()
        Me.Label_Drawing2 = New System.Windows.Forms.Label()
        Me.Label_Due = New System.Windows.Forms.Label()
        Me.Label_Number3 = New System.Windows.Forms.Label()
        Me.Label_Date = New System.Windows.Forms.Label()
        Me.Label_Rev = New System.Windows.Forms.Label()
        Me.Label_Number2 = New System.Windows.Forms.Label()
        Me.Label_Num = New System.Windows.Forms.Label()
        Me.fra_PaymentSchedule = New System.Windows.Forms.GroupBox()
        Me.lbl_Page = New System.Windows.Forms.Label()
        Me.Label_TotalPayments = New System.Windows.Forms.Label()
        Me.lbl_LatePayments = New System.Windows.Forms.Label()
        Me.lbl_TotalPayments = New System.Windows.Forms.Label()
        Me.Label_LatePayments = New System.Windows.Forms.Label()
        Me.lbl_TotalOrders = New System.Windows.Forms.Label()
        Me.Label_Orders = New System.Windows.Forms.Label()
        Me.Label_Number1 = New System.Windows.Forms.Label()
        Me.Label_Invoice = New System.Windows.Forms.Label()
        Me.Label_Phone = New System.Windows.Forms.Label()
        Me.Label_Number4 = New System.Windows.Forms.Label()
        Me.Label_Days = New System.Windows.Forms.Label()
        Me.Label_Late = New System.Windows.Forms.Label()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape6 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape5 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape4 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape3 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineRectangleBottom = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineRectangleRight = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineRectangleLeft = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineRectangleTop = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineMidVert6 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineMidVert5 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineHorz3 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineHorz2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineHorz1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.fra_Pages = New System.Windows.Forms.GroupBox()
        Me.cmd_Previous = New System.Windows.Forms.Button()
        Me.Label_Pages = New System.Windows.Forms.Label()
        Me.cmd_Next = New System.Windows.Forms.Button()
        Me.Label_Banner2 = New System.Windows.Forms.Label()
        Me.fra_SearchCriteria.SuspendLayout()
        Me.fra_PaymentSchedule.SuspendLayout()
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
        Me.Label_Company.Location = New System.Drawing.Point(22, 65)
        Me.Label_Company.Name = "Label_Company"
        Me.Label_Company.Size = New System.Drawing.Size(560, 40)
        Me.Label_Company.TabIndex = 0
        Me.Label_Company.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_CustomerName
        '
        Me.Label_CustomerName.BackColor = System.Drawing.Color.White
        Me.Label_CustomerName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_CustomerName.Location = New System.Drawing.Point(16, 165)
        Me.Label_CustomerName.Name = "Label_CustomerName"
        Me.Label_CustomerName.Size = New System.Drawing.Size(191, 15)
        Me.Label_CustomerName.TabIndex = 158
        Me.Label_CustomerName.Text = "Customer Name"
        Me.Label_CustomerName.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Lbl_PaymentSchedule
        '
        Me.Lbl_PaymentSchedule.AutoSize = True
        Me.Lbl_PaymentSchedule.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_PaymentSchedule.Location = New System.Drawing.Point(168, 27)
        Me.Lbl_PaymentSchedule.Name = "Lbl_PaymentSchedule"
        Me.Lbl_PaymentSchedule.Size = New System.Drawing.Size(259, 33)
        Me.Lbl_PaymentSchedule.TabIndex = 160
        Me.Lbl_PaymentSchedule.Text = "Payment Schedule"
        '
        'Label_HeaderDates
        '
        Me.Label_HeaderDates.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_HeaderDates.Location = New System.Drawing.Point(72, 110)
        Me.Label_HeaderDates.Name = "Label_HeaderDates"
        Me.Label_HeaderDates.Size = New System.Drawing.Size(445, 27)
        Me.Label_HeaderDates.TabIndex = 161
        Me.Label_HeaderDates.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_PO1
        '
        Me.Label_PO1.BackColor = System.Drawing.Color.White
        Me.Label_PO1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_PO1.Location = New System.Drawing.Point(261, 150)
        Me.Label_PO1.Name = "Label_PO1"
        Me.Label_PO1.Size = New System.Drawing.Size(119, 15)
        Me.Label_PO1.TabIndex = 163
        Me.Label_PO1.Text = "P.O."
        Me.Label_PO1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_PO2
        '
        Me.Label_PO2.BackColor = System.Drawing.Color.White
        Me.Label_PO2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_PO2.Location = New System.Drawing.Point(381, 150)
        Me.Label_PO2.Name = "Label_PO2"
        Me.Label_PO2.Size = New System.Drawing.Size(24, 15)
        Me.Label_PO2.TabIndex = 164
        Me.Label_PO2.Text = "PO"
        Me.Label_PO2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Drawing1
        '
        Me.Label_Drawing1.BackColor = System.Drawing.Color.White
        Me.Label_Drawing1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Drawing1.Location = New System.Drawing.Point(406, 150)
        Me.Label_Drawing1.Name = "Label_Drawing1"
        Me.Label_Drawing1.Size = New System.Drawing.Size(103, 15)
        Me.Label_Drawing1.TabIndex = 165
        Me.Label_Drawing1.Text = "Drawing"
        Me.Label_Drawing1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Drawing2
        '
        Me.Label_Drawing2.BackColor = System.Drawing.Color.White
        Me.Label_Drawing2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Drawing2.Location = New System.Drawing.Point(510, 150)
        Me.Label_Drawing2.Name = "Label_Drawing2"
        Me.Label_Drawing2.Size = New System.Drawing.Size(69, 15)
        Me.Label_Drawing2.TabIndex = 166
        Me.Label_Drawing2.Text = "Payment"
        Me.Label_Drawing2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Due
        '
        Me.Label_Due.BackColor = System.Drawing.Color.White
        Me.Label_Due.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Due.Location = New System.Drawing.Point(580, 150)
        Me.Label_Due.Name = "Label_Due"
        Me.Label_Due.Size = New System.Drawing.Size(64, 15)
        Me.Label_Due.TabIndex = 168
        Me.Label_Due.Text = "Due"
        Me.Label_Due.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Number3
        '
        Me.Label_Number3.BackColor = System.Drawing.Color.White
        Me.Label_Number3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Number3.Location = New System.Drawing.Point(406, 165)
        Me.Label_Number3.Name = "Label_Number3"
        Me.Label_Number3.Size = New System.Drawing.Size(103, 15)
        Me.Label_Number3.TabIndex = 169
        Me.Label_Number3.Text = "Number"
        Me.Label_Number3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Date
        '
        Me.Label_Date.BackColor = System.Drawing.Color.White
        Me.Label_Date.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Date.Location = New System.Drawing.Point(580, 165)
        Me.Label_Date.Name = "Label_Date"
        Me.Label_Date.Size = New System.Drawing.Size(64, 15)
        Me.Label_Date.TabIndex = 170
        Me.Label_Date.Text = "Date"
        Me.Label_Date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Rev
        '
        Me.Label_Rev.BackColor = System.Drawing.Color.White
        Me.Label_Rev.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Rev.Location = New System.Drawing.Point(510, 165)
        Me.Label_Rev.Name = "Label_Rev"
        Me.Label_Rev.Size = New System.Drawing.Size(69, 15)
        Me.Label_Rev.TabIndex = 172
        Me.Label_Rev.Text = "Amount"
        Me.Label_Rev.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Number2
        '
        Me.Label_Number2.BackColor = System.Drawing.Color.White
        Me.Label_Number2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Number2.Location = New System.Drawing.Point(261, 165)
        Me.Label_Number2.Name = "Label_Number2"
        Me.Label_Number2.Size = New System.Drawing.Size(119, 15)
        Me.Label_Number2.TabIndex = 173
        Me.Label_Number2.Text = "Number"
        Me.Label_Number2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Num
        '
        Me.Label_Num.BackColor = System.Drawing.Color.White
        Me.Label_Num.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Num.Location = New System.Drawing.Point(381, 165)
        Me.Label_Num.Name = "Label_Num"
        Me.Label_Num.Size = New System.Drawing.Size(23, 15)
        Me.Label_Num.TabIndex = 175
        Me.Label_Num.Text = "No"
        Me.Label_Num.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'fra_PaymentSchedule
        '
        Me.fra_PaymentSchedule.BackColor = System.Drawing.Color.White
        Me.fra_PaymentSchedule.Controls.Add(Me.lbl_Page)
        Me.fra_PaymentSchedule.Controls.Add(Me.Label_TotalPayments)
        Me.fra_PaymentSchedule.Controls.Add(Me.lbl_LatePayments)
        Me.fra_PaymentSchedule.Controls.Add(Me.lbl_TotalPayments)
        Me.fra_PaymentSchedule.Controls.Add(Me.Label_LatePayments)
        Me.fra_PaymentSchedule.Controls.Add(Me.lbl_TotalOrders)
        Me.fra_PaymentSchedule.Controls.Add(Me.Label_Orders)
        Me.fra_PaymentSchedule.Controls.Add(Me.Label_Number1)
        Me.fra_PaymentSchedule.Controls.Add(Me.Label_Invoice)
        Me.fra_PaymentSchedule.Controls.Add(Me.Label_Phone)
        Me.fra_PaymentSchedule.Controls.Add(Me.Label_Number4)
        Me.fra_PaymentSchedule.Controls.Add(Me.Label_Days)
        Me.fra_PaymentSchedule.Controls.Add(Me.Label_Late)
        Me.fra_PaymentSchedule.Controls.Add(Me.Label_Num)
        Me.fra_PaymentSchedule.Controls.Add(Me.Label_Number2)
        Me.fra_PaymentSchedule.Controls.Add(Me.Label_Rev)
        Me.fra_PaymentSchedule.Controls.Add(Me.Label_Date)
        Me.fra_PaymentSchedule.Controls.Add(Me.Label_Number3)
        Me.fra_PaymentSchedule.Controls.Add(Me.Label_Due)
        Me.fra_PaymentSchedule.Controls.Add(Me.Label_Drawing2)
        Me.fra_PaymentSchedule.Controls.Add(Me.Label_Drawing1)
        Me.fra_PaymentSchedule.Controls.Add(Me.Label_PO2)
        Me.fra_PaymentSchedule.Controls.Add(Me.Label_PO1)
        Me.fra_PaymentSchedule.Controls.Add(Me.Label_HeaderDates)
        Me.fra_PaymentSchedule.Controls.Add(Me.Lbl_PaymentSchedule)
        Me.fra_PaymentSchedule.Controls.Add(Me.Label_CustomerName)
        Me.fra_PaymentSchedule.Controls.Add(Me.Label_Company)
        Me.fra_PaymentSchedule.Controls.Add(Me.ShapeContainer1)
        Me.fra_PaymentSchedule.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fra_PaymentSchedule.Location = New System.Drawing.Point(170, 8)
        Me.fra_PaymentSchedule.Name = "fra_PaymentSchedule"
        Me.fra_PaymentSchedule.Size = New System.Drawing.Size(785, 848)
        Me.fra_PaymentSchedule.TabIndex = 89
        Me.fra_PaymentSchedule.TabStop = False
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
        'Label_TotalPayments
        '
        Me.Label_TotalPayments.AutoSize = True
        Me.Label_TotalPayments.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_TotalPayments.Location = New System.Drawing.Point(584, 108)
        Me.Label_TotalPayments.Name = "Label_TotalPayments"
        Me.Label_TotalPayments.Size = New System.Drawing.Size(100, 15)
        Me.Label_TotalPayments.TabIndex = 198
        Me.Label_TotalPayments.Text = "Total Payments :"
        '
        'lbl_LatePayments
        '
        Me.lbl_LatePayments.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_LatePayments.ForeColor = System.Drawing.Color.Brown
        Me.lbl_LatePayments.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.lbl_LatePayments.Location = New System.Drawing.Point(680, 123)
        Me.lbl_LatePayments.Name = "lbl_LatePayments"
        Me.lbl_LatePayments.Size = New System.Drawing.Size(80, 14)
        Me.lbl_LatePayments.TabIndex = 197
        Me.lbl_LatePayments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_TotalPayments
        '
        Me.lbl_TotalPayments.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_TotalPayments.ForeColor = System.Drawing.Color.Brown
        Me.lbl_TotalPayments.Location = New System.Drawing.Point(680, 108)
        Me.lbl_TotalPayments.Name = "lbl_TotalPayments"
        Me.lbl_TotalPayments.Size = New System.Drawing.Size(80, 14)
        Me.lbl_TotalPayments.TabIndex = 196
        Me.lbl_TotalPayments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label_LatePayments
        '
        Me.Label_LatePayments.AutoSize = True
        Me.Label_LatePayments.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_LatePayments.Location = New System.Drawing.Point(586, 123)
        Me.Label_LatePayments.Name = "Label_LatePayments"
        Me.Label_LatePayments.Size = New System.Drawing.Size(98, 15)
        Me.Label_LatePayments.TabIndex = 195
        Me.Label_LatePayments.Text = " Late Payments:"
        '
        'lbl_TotalOrders
        '
        Me.lbl_TotalOrders.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_TotalOrders.ForeColor = System.Drawing.Color.Brown
        Me.lbl_TotalOrders.Location = New System.Drawing.Point(680, 93)
        Me.lbl_TotalOrders.Name = "lbl_TotalOrders"
        Me.lbl_TotalOrders.Size = New System.Drawing.Size(80, 14)
        Me.lbl_TotalOrders.TabIndex = 194
        Me.lbl_TotalOrders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label_Orders
        '
        Me.Label_Orders.AutoSize = True
        Me.Label_Orders.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Orders.Location = New System.Drawing.Point(601, 93)
        Me.Label_Orders.Name = "Label_Orders"
        Me.Label_Orders.Size = New System.Drawing.Size(81, 15)
        Me.Label_Orders.TabIndex = 193
        Me.Label_Orders.Text = "Total orders :"
        '
        'Label_Number1
        '
        Me.Label_Number1.BackColor = System.Drawing.Color.White
        Me.Label_Number1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Number1.Location = New System.Drawing.Point(208, 165)
        Me.Label_Number1.Name = "Label_Number1"
        Me.Label_Number1.Size = New System.Drawing.Size(52, 15)
        Me.Label_Number1.TabIndex = 192
        Me.Label_Number1.Text = "Number"
        Me.Label_Number1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Invoice
        '
        Me.Label_Invoice.BackColor = System.Drawing.Color.White
        Me.Label_Invoice.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Invoice.Location = New System.Drawing.Point(208, 150)
        Me.Label_Invoice.Name = "Label_Invoice"
        Me.Label_Invoice.Size = New System.Drawing.Size(52, 15)
        Me.Label_Invoice.TabIndex = 191
        Me.Label_Invoice.Text = "Invoice"
        Me.Label_Invoice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Phone
        '
        Me.Label_Phone.BackColor = System.Drawing.Color.White
        Me.Label_Phone.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Phone.Location = New System.Drawing.Point(679, 150)
        Me.Label_Phone.Name = "Label_Phone"
        Me.Label_Phone.Size = New System.Drawing.Size(89, 15)
        Me.Label_Phone.TabIndex = 189
        Me.Label_Phone.Text = "Phone"
        Me.Label_Phone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Number4
        '
        Me.Label_Number4.BackColor = System.Drawing.Color.White
        Me.Label_Number4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Number4.Location = New System.Drawing.Point(679, 165)
        Me.Label_Number4.Name = "Label_Number4"
        Me.Label_Number4.Size = New System.Drawing.Size(89, 15)
        Me.Label_Number4.TabIndex = 184
        Me.Label_Number4.Text = "Number"
        Me.Label_Number4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Days
        '
        Me.Label_Days.BackColor = System.Drawing.Color.White
        Me.Label_Days.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Days.Location = New System.Drawing.Point(647, 165)
        Me.Label_Days.Name = "Label_Days"
        Me.Label_Days.Size = New System.Drawing.Size(31, 15)
        Me.Label_Days.TabIndex = 183
        Me.Label_Days.Text = "Day"
        Me.Label_Days.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Late
        '
        Me.Label_Late.BackColor = System.Drawing.Color.White
        Me.Label_Late.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Late.Location = New System.Drawing.Point(646, 150)
        Me.Label_Late.Name = "Label_Late"
        Me.Label_Late.Size = New System.Drawing.Size(32, 15)
        Me.Label_Late.TabIndex = 182
        Me.Label_Late.Text = "Late"
        Me.Label_Late.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(3, 16)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape6, Me.LineShape5, Me.LineShape4, Me.LineShape3, Me.LineShape2, Me.LineShape1, Me.LineRectangleBottom, Me.LineRectangleRight, Me.LineRectangleLeft, Me.LineRectangleTop, Me.LineMidVert6, Me.LineMidVert5, Me.LineHorz3, Me.LineHorz2, Me.LineHorz1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(779, 829)
        Me.ShapeContainer1.TabIndex = 1
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape6
        '
        Me.LineShape6.Name = "LineShape6"
        Me.LineShape6.X1 = 204
        Me.LineShape6.X2 = 204
        Me.LineShape6.Y1 = 133
        Me.LineShape6.Y2 = 815
        '
        'LineShape5
        '
        Me.LineShape5.Name = "LineShape5"
        Me.LineShape5.X1 = 675
        Me.LineShape5.X2 = 675
        Me.LineShape5.Y1 = 133
        Me.LineShape5.Y2 = 815
        '
        'LineShape4
        '
        Me.LineShape4.Name = "LineShape4"
        Me.LineShape4.X1 = 641
        Me.LineShape4.X2 = 641
        Me.LineShape4.Y1 = 133
        Me.LineShape4.Y2 = 815
        '
        'LineShape3
        '
        Me.LineShape3.Name = "LineShape3"
        Me.LineShape3.X1 = 576
        Me.LineShape3.X2 = 576
        Me.LineShape3.Y1 = 133
        Me.LineShape3.Y2 = 815
        '
        'LineShape2
        '
        Me.LineShape2.Name = "LineShape2"
        Me.LineShape2.X1 = 402
        Me.LineShape2.X2 = 402
        Me.LineShape2.Y1 = 133
        Me.LineShape2.Y2 = 815
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 377
        Me.LineShape1.X2 = 377
        Me.LineShape1.Y1 = 133
        Me.LineShape1.Y2 = 815
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
        'LineMidVert6
        '
        Me.LineMidVert6.Name = "LineMidVert6"
        Me.LineMidVert6.X1 = 506
        Me.LineMidVert6.X2 = 506
        Me.LineMidVert6.Y1 = 133
        Me.LineMidVert6.Y2 = 815
        '
        'LineMidVert5
        '
        Me.LineMidVert5.Name = "LineMidVert5"
        Me.LineMidVert5.X1 = 257
        Me.LineMidVert5.X2 = 257
        Me.LineMidVert5.Y1 = 133
        Me.LineMidVert5.Y2 = 815
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
        'frm_PaymentSchedule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(969, 869)
        Me.Controls.Add(Me.Label_Banner2)
        Me.Controls.Add(Me.fra_Pages)
        Me.Controls.Add(Me.Label_Top1)
        Me.Controls.Add(Me.fra_SearchCriteria)
        Me.Controls.Add(Me.Label_Top)
        Me.Controls.Add(Me.fra_PaymentSchedule)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_PaymentSchedule"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Payment Schedule"
        Me.fra_SearchCriteria.ResumeLayout(False)
        Me.fra_PaymentSchedule.ResumeLayout(False)
        Me.fra_PaymentSchedule.PerformLayout()
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
    Friend WithEvents Label_CustomerName As System.Windows.Forms.Label
    Friend WithEvents Lbl_PaymentSchedule As System.Windows.Forms.Label
    Friend WithEvents Label_HeaderDates As System.Windows.Forms.Label
    Friend WithEvents Label_PO1 As System.Windows.Forms.Label
    Friend WithEvents Label_PO2 As System.Windows.Forms.Label
    Friend WithEvents Label_Drawing1 As System.Windows.Forms.Label
    Friend WithEvents Label_Drawing2 As System.Windows.Forms.Label
    Friend WithEvents Label_Due As System.Windows.Forms.Label
    Friend WithEvents Label_Number3 As System.Windows.Forms.Label
    Friend WithEvents Label_Date As System.Windows.Forms.Label
    Friend WithEvents Label_Rev As System.Windows.Forms.Label
    Friend WithEvents Label_Number2 As System.Windows.Forms.Label
    Friend WithEvents Label_Num As System.Windows.Forms.Label
    Friend WithEvents fra_PaymentSchedule As System.Windows.Forms.GroupBox
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape4 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape3 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape2 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineRectangleBottom As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineRectangleRight As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineRectangleLeft As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineRectangleTop As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineMidVert6 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineMidVert5 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineHorz3 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineHorz2 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineHorz1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents Label_Phone As System.Windows.Forms.Label
    Friend WithEvents Label_Number4 As System.Windows.Forms.Label
    Friend WithEvents Label_Days As System.Windows.Forms.Label
    Friend WithEvents Label_Late As System.Windows.Forms.Label
    Friend WithEvents LineShape5 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents Label_Number1 As System.Windows.Forms.Label
    Friend WithEvents Label_Invoice As System.Windows.Forms.Label
    Friend WithEvents LineShape6 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents Label_TotalPayments As System.Windows.Forms.Label
    Friend WithEvents Label_LatePayments As System.Windows.Forms.Label
    Friend WithEvents lbl_TotalOrders As System.Windows.Forms.Label
    Friend WithEvents Label_Orders As System.Windows.Forms.Label
    Friend WithEvents lbl_LatePayments As System.Windows.Forms.Label
    Friend WithEvents lbl_TotalPayments As System.Windows.Forms.Label
    Friend WithEvents fra_Pages As System.Windows.Forms.GroupBox
    Friend WithEvents cmd_Previous As System.Windows.Forms.Button
    Friend WithEvents Label_Pages As System.Windows.Forms.Label
    Friend WithEvents cmd_Next As System.Windows.Forms.Button
    Friend WithEvents Label_Banner2 As System.Windows.Forms.Label
    Friend WithEvents lbl_Page As System.Windows.Forms.Label
    Friend WithEvents cmd_PrintAll As System.Windows.Forms.Button
End Class
