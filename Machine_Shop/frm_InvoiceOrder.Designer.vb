<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_InvoiceOrder
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_InvoiceOrder))
        Me.VScrollBar1 = New System.Windows.Forms.VScrollBar()
        Me.lbl_TopBanner = New System.Windows.Forms.Label()
        Me.Label_Drawing = New System.Windows.Forms.Label()
        Me.Label_Revision = New System.Windows.Forms.Label()
        Me.Label_Item = New System.Windows.Forms.Label()
        Me.Label_TotalPrice = New System.Windows.Forms.Label()
        Me.Label_Price = New System.Windows.Forms.Label()
        Me.Label_ShipDate = New System.Windows.Forms.Label()
        Me.Label_DueDate = New System.Windows.Forms.Label()
        Me.Label_Quanty1 = New System.Windows.Forms.Label()
        Me.Label_Ordered = New System.Windows.Forms.Label()
        Me.Label_DrawNum = New System.Windows.Forms.Label()
        Me.Label_PO = New System.Windows.Forms.Label()
        Me.Label_Customers = New System.Windows.Forms.Label()
        Me.fra_Invoice = New System.Windows.Forms.GroupBox()
        Me.fra_Information = New System.Windows.Forms.GroupBox()
        Me.Label_Select = New System.Windows.Forms.Label()
        Me.Label_ShipVia = New System.Windows.Forms.Label()
        Me.Label_Freight = New System.Windows.Forms.Label()
        Me.Label_Discount = New System.Windows.Forms.Label()
        Me.Label_MaterialHeat = New System.Windows.Forms.Label()
        Me.Label_LotID = New System.Windows.Forms.Label()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.Line_Bottom = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.fra_Commands = New System.Windows.Forms.GroupBox()
        Me.lbl_Message2 = New System.Windows.Forms.Label()
        Me.lbl_Message1 = New System.Windows.Forms.Label()
        Me.opt_Agent2 = New System.Windows.Forms.RadioButton()
        Me.opt_Agent1 = New System.Windows.Forms.RadioButton()
        Me.cmd_2 = New System.Windows.Forms.Button()
        Me.cmd_Exit = New System.Windows.Forms.Button()
        Me.cmd_1 = New System.Windows.Forms.Button()
        Me.Label_Quantity2 = New System.Windows.Forms.Label()
        Me.Label_Shipped = New System.Windows.Forms.Label()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.fra_Invoice.SuspendLayout()
        Me.fra_Commands.SuspendLayout()
        Me.SuspendLayout()
        '
        'VScrollBar1
        '
        Me.VScrollBar1.Location = New System.Drawing.Point(1424, 41)
        Me.VScrollBar1.Name = "VScrollBar1"
        Me.VScrollBar1.Size = New System.Drawing.Size(19, 503)
        Me.VScrollBar1.TabIndex = 159
        '
        'lbl_TopBanner
        '
        Me.lbl_TopBanner.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lbl_TopBanner.Location = New System.Drawing.Point(9, 3)
        Me.lbl_TopBanner.Name = "lbl_TopBanner"
        Me.lbl_TopBanner.Size = New System.Drawing.Size(1443, 38)
        Me.lbl_TopBanner.TabIndex = 176
        Me.lbl_TopBanner.Text = "_________________________________________________________________________________" & _
    "_______________________________________________________________"
        Me.lbl_TopBanner.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label_Drawing
        '
        Me.Label_Drawing.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Drawing.Location = New System.Drawing.Point(521, 2)
        Me.Label_Drawing.Name = "Label_Drawing"
        Me.Label_Drawing.Size = New System.Drawing.Size(55, 19)
        Me.Label_Drawing.TabIndex = 190
        Me.Label_Drawing.Text = "Drawing"
        Me.Label_Drawing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Revision
        '
        Me.Label_Revision.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Revision.Location = New System.Drawing.Point(521, 21)
        Me.Label_Revision.Name = "Label_Revision"
        Me.Label_Revision.Size = New System.Drawing.Size(55, 15)
        Me.Label_Revision.TabIndex = 189
        Me.Label_Revision.Text = "Revision"
        Me.Label_Revision.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Item
        '
        Me.Label_Item.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Item.Location = New System.Drawing.Point(731, 2)
        Me.Label_Item.Name = "Label_Item"
        Me.Label_Item.Size = New System.Drawing.Size(60, 19)
        Me.Label_Item.TabIndex = 188
        Me.Label_Item.Text = "Item"
        Me.Label_Item.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_TotalPrice
        '
        Me.Label_TotalPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_TotalPrice.Location = New System.Drawing.Point(804, 21)
        Me.Label_TotalPrice.Name = "Label_TotalPrice"
        Me.Label_TotalPrice.Size = New System.Drawing.Size(65, 15)
        Me.Label_TotalPrice.TabIndex = 187
        Me.Label_TotalPrice.Text = "Total Price"
        Me.Label_TotalPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Price
        '
        Me.Label_Price.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Price.Location = New System.Drawing.Point(731, 21)
        Me.Label_Price.Name = "Label_Price"
        Me.Label_Price.Size = New System.Drawing.Size(60, 15)
        Me.Label_Price.TabIndex = 186
        Me.Label_Price.Text = "Price"
        Me.Label_Price.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_ShipDate
        '
        Me.Label_ShipDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_ShipDate.Location = New System.Drawing.Point(945, 21)
        Me.Label_ShipDate.Name = "Label_ShipDate"
        Me.Label_ShipDate.Size = New System.Drawing.Size(67, 15)
        Me.Label_ShipDate.TabIndex = 185
        Me.Label_ShipDate.Text = "Ship Date"
        Me.Label_ShipDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_DueDate
        '
        Me.Label_DueDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_DueDate.Location = New System.Drawing.Point(651, 21)
        Me.Label_DueDate.Name = "Label_DueDate"
        Me.Label_DueDate.Size = New System.Drawing.Size(67, 15)
        Me.Label_DueDate.TabIndex = 184
        Me.Label_DueDate.Text = "Due Date"
        Me.Label_DueDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Quanty1
        '
        Me.Label_Quanty1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Quanty1.Location = New System.Drawing.Point(586, 2)
        Me.Label_Quanty1.Name = "Label_Quanty1"
        Me.Label_Quanty1.Size = New System.Drawing.Size(56, 19)
        Me.Label_Quanty1.TabIndex = 181
        Me.Label_Quanty1.Text = "Quantity"
        Me.Label_Quanty1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Ordered
        '
        Me.Label_Ordered.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Ordered.Location = New System.Drawing.Point(586, 21)
        Me.Label_Ordered.Name = "Label_Ordered"
        Me.Label_Ordered.Size = New System.Drawing.Size(56, 15)
        Me.Label_Ordered.TabIndex = 180
        Me.Label_Ordered.Text = "Ordered"
        Me.Label_Ordered.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_DrawNum
        '
        Me.Label_DrawNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_DrawNum.Location = New System.Drawing.Point(397, 21)
        Me.Label_DrawNum.Name = "Label_DrawNum"
        Me.Label_DrawNum.Size = New System.Drawing.Size(110, 15)
        Me.Label_DrawNum.TabIndex = 179
        Me.Label_DrawNum.Text = "Drawing Numbers"
        Me.Label_DrawNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_PO
        '
        Me.Label_PO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_PO.Location = New System.Drawing.Point(257, 21)
        Me.Label_PO.Name = "Label_PO"
        Me.Label_PO.Size = New System.Drawing.Size(128, 15)
        Me.Label_PO.TabIndex = 178
        Me.Label_PO.Text = "Purchase Orders"
        Me.Label_PO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Customers
        '
        Me.Label_Customers.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Customers.Location = New System.Drawing.Point(58, 21)
        Me.Label_Customers.Name = "Label_Customers"
        Me.Label_Customers.Size = New System.Drawing.Size(185, 15)
        Me.Label_Customers.TabIndex = 177
        Me.Label_Customers.Text = "Customers"
        Me.Label_Customers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'fra_Invoice
        '
        Me.fra_Invoice.Controls.Add(Me.fra_Information)
        Me.fra_Invoice.Location = New System.Drawing.Point(10, 35)
        Me.fra_Invoice.Name = "fra_Invoice"
        Me.fra_Invoice.Size = New System.Drawing.Size(1415, 510)
        Me.fra_Invoice.TabIndex = 121
        Me.fra_Invoice.TabStop = False
        '
        'fra_Information
        '
        Me.fra_Information.Location = New System.Drawing.Point(0, -2)
        Me.fra_Information.Name = "fra_Information"
        Me.fra_Information.Size = New System.Drawing.Size(1415, 512)
        Me.fra_Information.TabIndex = 121
        Me.fra_Information.TabStop = False
        '
        'Label_Select
        '
        Me.Label_Select.AutoSize = True
        Me.Label_Select.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Select.Location = New System.Drawing.Point(16, 21)
        Me.Label_Select.Name = "Label_Select"
        Me.Label_Select.Size = New System.Drawing.Size(41, 15)
        Me.Label_Select.TabIndex = 192
        Me.Label_Select.Text = "Select"
        Me.Label_Select.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_ShipVia
        '
        Me.Label_ShipVia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_ShipVia.Location = New System.Drawing.Point(1024, 21)
        Me.Label_ShipVia.Name = "Label_ShipVia"
        Me.Label_ShipVia.Size = New System.Drawing.Size(107, 15)
        Me.Label_ShipVia.TabIndex = 186
        Me.Label_ShipVia.Text = "Ship Via"
        Me.Label_ShipVia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Freight
        '
        Me.Label_Freight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Freight.Location = New System.Drawing.Point(1144, 21)
        Me.Label_Freight.Name = "Label_Freight"
        Me.Label_Freight.Size = New System.Drawing.Size(45, 15)
        Me.Label_Freight.TabIndex = 186
        Me.Label_Freight.Text = "Freight"
        Me.Label_Freight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Discount
        '
        Me.Label_Discount.AutoSize = True
        Me.Label_Discount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Discount.Location = New System.Drawing.Point(1367, 21)
        Me.Label_Discount.Name = "Label_Discount"
        Me.Label_Discount.Size = New System.Drawing.Size(55, 15)
        Me.Label_Discount.TabIndex = 187
        Me.Label_Discount.Text = "Discount"
        Me.Label_Discount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_MaterialHeat
        '
        Me.Label_MaterialHeat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_MaterialHeat.Location = New System.Drawing.Point(1202, 21)
        Me.Label_MaterialHeat.Name = "Label_MaterialHeat"
        Me.Label_MaterialHeat.Size = New System.Drawing.Size(100, 15)
        Me.Label_MaterialHeat.TabIndex = 188
        Me.Label_MaterialHeat.Text = "Material Heat"
        Me.Label_MaterialHeat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_LotID
        '
        Me.Label_LotID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_LotID.Location = New System.Drawing.Point(1315, 21)
        Me.Label_LotID.Name = "Label_LotID"
        Me.Label_LotID.Size = New System.Drawing.Size(45, 15)
        Me.Label_LotID.TabIndex = 188
        Me.Label_LotID.Text = "Lot Id"
        Me.Label_LotID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.Line_Bottom})
        Me.ShapeContainer1.Size = New System.Drawing.Size(1464, 612)
        Me.ShapeContainer1.TabIndex = 191
        Me.ShapeContainer1.TabStop = False
        '
        'Line_Bottom
        '
        Me.Line_Bottom.BorderColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Line_Bottom.Name = "Line_Bottom"
        Me.Line_Bottom.Visible = False
        Me.Line_Bottom.X1 = 10
        Me.Line_Bottom.X2 = 1425
        Me.Line_Bottom.Y1 = 542
        Me.Line_Bottom.Y2 = 542
        '
        'fra_Commands
        '
        Me.fra_Commands.Controls.Add(Me.lbl_Message2)
        Me.fra_Commands.Controls.Add(Me.lbl_Message1)
        Me.fra_Commands.Controls.Add(Me.opt_Agent2)
        Me.fra_Commands.Controls.Add(Me.opt_Agent1)
        Me.fra_Commands.Controls.Add(Me.cmd_2)
        Me.fra_Commands.Controls.Add(Me.cmd_Exit)
        Me.fra_Commands.Controls.Add(Me.cmd_1)
        Me.fra_Commands.Location = New System.Drawing.Point(10, 546)
        Me.fra_Commands.Name = "fra_Commands"
        Me.fra_Commands.Size = New System.Drawing.Size(1432, 57)
        Me.fra_Commands.TabIndex = 197
        Me.fra_Commands.TabStop = False
        '
        'lbl_Message2
        '
        Me.lbl_Message2.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_Message2.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_Message2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Message2.ForeColor = System.Drawing.Color.Red
        Me.lbl_Message2.Location = New System.Drawing.Point(302, 33)
        Me.lbl_Message2.Name = "lbl_Message2"
        Me.lbl_Message2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_Message2.Size = New System.Drawing.Size(663, 14)
        Me.lbl_Message2.TabIndex = 205
        Me.lbl_Message2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Message1
        '
        Me.lbl_Message1.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_Message1.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_Message1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Message1.ForeColor = System.Drawing.Color.Red
        Me.lbl_Message1.Location = New System.Drawing.Point(302, 16)
        Me.lbl_Message1.Name = "lbl_Message1"
        Me.lbl_Message1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_Message1.Size = New System.Drawing.Size(557, 14)
        Me.lbl_Message1.TabIndex = 204
        Me.lbl_Message1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'opt_Agent2
        '
        Me.opt_Agent2.AutoSize = True
        Me.opt_Agent2.Location = New System.Drawing.Point(1305, 23)
        Me.opt_Agent2.Name = "opt_Agent2"
        Me.opt_Agent2.Size = New System.Drawing.Size(107, 17)
        Me.opt_Agent2.TabIndex = 203
        Me.opt_Agent2.TabStop = True
        Me.opt_Agent2.Text = "Secondary Agent"
        Me.opt_Agent2.UseVisualStyleBackColor = True
        Me.opt_Agent2.Visible = False
        '
        'opt_Agent1
        '
        Me.opt_Agent1.AutoSize = True
        Me.opt_Agent1.Location = New System.Drawing.Point(1195, 23)
        Me.opt_Agent1.Name = "opt_Agent1"
        Me.opt_Agent1.Size = New System.Drawing.Size(90, 17)
        Me.opt_Agent1.TabIndex = 202
        Me.opt_Agent1.TabStop = True
        Me.opt_Agent1.Text = "Primary Agent"
        Me.opt_Agent1.UseVisualStyleBackColor = True
        Me.opt_Agent1.Visible = False
        '
        'cmd_2
        '
        Me.cmd_2.Enabled = False
        Me.cmd_2.Location = New System.Drawing.Point(96, 16)
        Me.cmd_2.Name = "cmd_2"
        Me.cmd_2.Size = New System.Drawing.Size(66, 30)
        Me.cmd_2.TabIndex = 198
        Me.cmd_2.Text = "Restore"
        Me.cmd_2.UseVisualStyleBackColor = True
        '
        'cmd_Exit
        '
        Me.cmd_Exit.Location = New System.Drawing.Point(177, 16)
        Me.cmd_Exit.Name = "cmd_Exit"
        Me.cmd_Exit.Size = New System.Drawing.Size(66, 30)
        Me.cmd_Exit.TabIndex = 197
        Me.cmd_Exit.Text = "Exit"
        Me.cmd_Exit.UseVisualStyleBackColor = True
        '
        'cmd_1
        '
        Me.cmd_1.Location = New System.Drawing.Point(15, 16)
        Me.cmd_1.Name = "cmd_1"
        Me.cmd_1.Size = New System.Drawing.Size(66, 30)
        Me.cmd_1.TabIndex = 196
        Me.cmd_1.Text = "Next"
        Me.cmd_1.UseVisualStyleBackColor = True
        '
        'Label_Quantity2
        '
        Me.Label_Quantity2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Quantity2.Location = New System.Drawing.Point(879, 3)
        Me.Label_Quantity2.Name = "Label_Quantity2"
        Me.Label_Quantity2.Size = New System.Drawing.Size(55, 19)
        Me.Label_Quantity2.TabIndex = 199
        Me.Label_Quantity2.Text = "Quantity"
        Me.Label_Quantity2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Shipped
        '
        Me.Label_Shipped.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Shipped.Location = New System.Drawing.Point(879, 21)
        Me.Label_Shipped.Name = "Label_Shipped"
        Me.Label_Shipped.Size = New System.Drawing.Size(55, 15)
        Me.Label_Shipped.TabIndex = 198
        Me.Label_Shipped.Text = "Shipped"
        Me.Label_Shipped.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        'frm_InvoiceOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1464, 612)
        Me.Controls.Add(Me.Label_Quantity2)
        Me.Controls.Add(Me.Label_Shipped)
        Me.Controls.Add(Me.fra_Commands)
        Me.Controls.Add(Me.Label_LotID)
        Me.Controls.Add(Me.Label_MaterialHeat)
        Me.Controls.Add(Me.Label_Discount)
        Me.Controls.Add(Me.Label_Freight)
        Me.Controls.Add(Me.Label_ShipVia)
        Me.Controls.Add(Me.Label_Select)
        Me.Controls.Add(Me.Label_Drawing)
        Me.Controls.Add(Me.Label_Revision)
        Me.Controls.Add(Me.Label_Item)
        Me.Controls.Add(Me.Label_TotalPrice)
        Me.Controls.Add(Me.Label_Price)
        Me.Controls.Add(Me.Label_ShipDate)
        Me.Controls.Add(Me.Label_DueDate)
        Me.Controls.Add(Me.Label_Quanty1)
        Me.Controls.Add(Me.Label_Ordered)
        Me.Controls.Add(Me.Label_DrawNum)
        Me.Controls.Add(Me.Label_PO)
        Me.Controls.Add(Me.Label_Customers)
        Me.Controls.Add(Me.lbl_TopBanner)
        Me.Controls.Add(Me.VScrollBar1)
        Me.Controls.Add(Me.fra_Invoice)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_InvoiceOrder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Invoice Customers"
        Me.fra_Invoice.ResumeLayout(False)
        Me.fra_Commands.ResumeLayout(False)
        Me.fra_Commands.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents fra_Selector As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_TopBanner As System.Windows.Forms.Label
    Friend WithEvents Label_Drawing As System.Windows.Forms.Label
    Friend WithEvents Label_Revision As System.Windows.Forms.Label
    Friend WithEvents Label_Item As System.Windows.Forms.Label
    Friend WithEvents Label_TotalPrice As System.Windows.Forms.Label
    Friend WithEvents Label_Price As System.Windows.Forms.Label
    Friend WithEvents Label_ShipDate As System.Windows.Forms.Label
    Friend WithEvents Label_DueDate As System.Windows.Forms.Label
    Friend WithEvents Label_Quanty1 As System.Windows.Forms.Label
    Friend WithEvents Label_Ordered As System.Windows.Forms.Label
    Friend WithEvents Label_DrawNum As System.Windows.Forms.Label
    Friend WithEvents Label_PO As System.Windows.Forms.Label
    Friend WithEvents Label_Customers As System.Windows.Forms.Label
    Friend WithEvents fra_Invoice As System.Windows.Forms.GroupBox
    Friend WithEvents fra_Information As System.Windows.Forms.GroupBox
    Friend WithEvents Label_Select As System.Windows.Forms.Label
    Friend WithEvents Label_ShipVia As System.Windows.Forms.Label
    Friend WithEvents Label_Freight As System.Windows.Forms.Label
    Friend WithEvents Label_Discount As System.Windows.Forms.Label
    Friend WithEvents Label_MaterialHeat As System.Windows.Forms.Label
    Friend WithEvents Label_LotID As System.Windows.Forms.Label
    Protected Friend WithEvents VScrollBar1 As System.Windows.Forms.VScrollBar
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents Line_Bottom As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents fra_Commands As System.Windows.Forms.GroupBox
    Friend WithEvents cmd_2 As System.Windows.Forms.Button
    Friend WithEvents cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents cmd_1 As System.Windows.Forms.Button
    Friend WithEvents Label_Quantity2 As System.Windows.Forms.Label
    Friend WithEvents Label_Shipped As System.Windows.Forms.Label
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents opt_Agent2 As System.Windows.Forms.RadioButton
    Friend WithEvents opt_Agent1 As System.Windows.Forms.RadioButton
    Public WithEvents lbl_Message1 As System.Windows.Forms.Label
    Public WithEvents lbl_Message2 As System.Windows.Forms.Label
End Class
