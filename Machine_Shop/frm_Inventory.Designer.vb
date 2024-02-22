<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Inventory
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Inventory))
        Me.VScrollBar1 = New System.Windows.Forms.VScrollBar()
        Me.Label_Due = New System.Windows.Forms.Label()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.Label_Line = New System.Windows.Forms.Label()
        Me.fra_Edits = New System.Windows.Forms.GroupBox()
        Me.cmd_2 = New System.Windows.Forms.Button()
        Me.cmd_3 = New System.Windows.Forms.Button()
        Me.cmd_1 = New System.Windows.Forms.Button()
        Me.lbl_Message2 = New System.Windows.Forms.Label()
        Me.lbl_Message1 = New System.Windows.Forms.Label()
        Me.Label_LineOQ = New System.Windows.Forms.Label()
        Me.Label_ItemDelete = New System.Windows.Forms.Label()
        Me.Label_ItemOriginal = New System.Windows.Forms.Label()
        Me.Label_LineItem = New System.Windows.Forms.Label()
        Me.Label_Item = New System.Windows.Forms.Label()
        Me.Label_Banner1 = New System.Windows.Forms.Label()
        Me.fra_Navigation = New System.Windows.Forms.GroupBox()
        Me.lbl_Header = New System.Windows.Forms.Label()
        Me.fra_Information = New System.Windows.Forms.GroupBox()
        Me.Label_Banner = New System.Windows.Forms.Label()
        Me.Label_Quantity1 = New System.Windows.Forms.Label()
        Me.Label_LineQ = New System.Windows.Forms.Label()
        Me.Label_Rev = New System.Windows.Forms.Label()
        Me.Label_LineRev = New System.Windows.Forms.Label()
        Me.Label_Drawing = New System.Windows.Forms.Label()
        Me.Label_Number = New System.Windows.Forms.Label()
        Me.Label_LineDN = New System.Windows.Forms.Label()
        Me.Label_CustomerName = New System.Windows.Forms.Label()
        Me.Label_LineCN = New System.Windows.Forms.Label()
        Me.fra_New = New System.Windows.Forms.GroupBox()
        Me.lbl_CustomerName = New System.Windows.Forms.Label()
        Me.lbl_DrawingNumber = New System.Windows.Forms.Label()
        Me.lbl_DrawingRev = New System.Windows.Forms.Label()
        Me.lbl_ItemNo = New System.Windows.Forms.Label()
        Me.tbox_Quantity = New System.Windows.Forms.TextBox()
        Me.tbox_CustCode = New System.Windows.Forms.TextBox()
        Me.lbl_New = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.fra_Selection = New System.Windows.Forms.GroupBox()
        Me.Label_Selection1 = New System.Windows.Forms.Label()
        Me.Label_Selection2 = New System.Windows.Forms.Label()
        Me.Label_LineSelection = New System.Windows.Forms.Label()
        Me.Listbox = New System.Windows.Forms.ListBox()
        Me.fra_Edits.SuspendLayout()
        Me.fra_New.SuspendLayout()
        Me.fra_Selection.SuspendLayout()
        Me.SuspendLayout()
        '
        'VScrollBar1
        '
        Me.VScrollBar1.Location = New System.Drawing.Point(924, 61)
        Me.VScrollBar1.Name = "VScrollBar1"
        Me.VScrollBar1.Size = New System.Drawing.Size(19, 701)
        Me.VScrollBar1.TabIndex = 159
        Me.VScrollBar1.Visible = False
        '
        'Label_Due
        '
        Me.Label_Due.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Due.Location = New System.Drawing.Point(825, 13)
        Me.Label_Due.Name = "Label_Due"
        Me.Label_Due.Size = New System.Drawing.Size(70, 16)
        Me.Label_Due.TabIndex = 180
        Me.Label_Due.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        'Label_Line
        '
        Me.Label_Line.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Line.Location = New System.Drawing.Point(490, 13)
        Me.Label_Line.Name = "Label_Line"
        Me.Label_Line.Size = New System.Drawing.Size(40, 16)
        Me.Label_Line.TabIndex = 217
        Me.Label_Line.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'fra_Edits
        '
        Me.fra_Edits.BackColor = System.Drawing.Color.Bisque
        Me.fra_Edits.Controls.Add(Me.cmd_2)
        Me.fra_Edits.Controls.Add(Me.cmd_3)
        Me.fra_Edits.Controls.Add(Me.cmd_1)
        Me.fra_Edits.Controls.Add(Me.lbl_Message2)
        Me.fra_Edits.Controls.Add(Me.lbl_Message1)
        Me.fra_Edits.Location = New System.Drawing.Point(135, 766)
        Me.fra_Edits.Name = "fra_Edits"
        Me.fra_Edits.Size = New System.Drawing.Size(290, 108)
        Me.fra_Edits.TabIndex = 225
        Me.fra_Edits.TabStop = False
        '
        'cmd_2
        '
        Me.cmd_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_2.Image = Global.Machine_Shop.My.Resources.Resources._New
        Me.cmd_2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_2.Location = New System.Drawing.Point(112, 48)
        Me.cmd_2.Name = "cmd_2"
        Me.cmd_2.Size = New System.Drawing.Size(66, 50)
        Me.cmd_2.TabIndex = 230
        Me.cmd_2.Text = "New"
        Me.cmd_2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmd_2.UseVisualStyleBackColor = True
        '
        'cmd_3
        '
        Me.cmd_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_3.Image = Global.Machine_Shop.My.Resources.Resources._Exit
        Me.cmd_3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_3.Location = New System.Drawing.Point(188, 48)
        Me.cmd_3.Name = "cmd_3"
        Me.cmd_3.Size = New System.Drawing.Size(66, 50)
        Me.cmd_3.TabIndex = 229
        Me.cmd_3.Text = "Exit"
        Me.cmd_3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmd_3.UseVisualStyleBackColor = True
        '
        'cmd_1
        '
        Me.cmd_1.Enabled = False
        Me.cmd_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_1.Image = Global.Machine_Shop.My.Resources.Resources.Edit
        Me.cmd_1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_1.Location = New System.Drawing.Point(36, 48)
        Me.cmd_1.Name = "cmd_1"
        Me.cmd_1.Size = New System.Drawing.Size(66, 50)
        Me.cmd_1.TabIndex = 228
        Me.cmd_1.Text = "Edit"
        Me.cmd_1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmd_1.UseVisualStyleBackColor = True
        '
        'lbl_Message2
        '
        Me.lbl_Message2.BackColor = System.Drawing.Color.Bisque
        Me.lbl_Message2.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_Message2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Message2.ForeColor = System.Drawing.Color.Red
        Me.lbl_Message2.Location = New System.Drawing.Point(7, 27)
        Me.lbl_Message2.Name = "lbl_Message2"
        Me.lbl_Message2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_Message2.Size = New System.Drawing.Size(276, 16)
        Me.lbl_Message2.TabIndex = 216
        Me.lbl_Message2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Message1
        '
        Me.lbl_Message1.BackColor = System.Drawing.Color.Bisque
        Me.lbl_Message1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Message1.ForeColor = System.Drawing.Color.Red
        Me.lbl_Message1.Location = New System.Drawing.Point(7, 11)
        Me.lbl_Message1.Name = "lbl_Message1"
        Me.lbl_Message1.Size = New System.Drawing.Size(276, 16)
        Me.lbl_Message1.TabIndex = 227
        Me.lbl_Message1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_LineOQ
        '
        Me.Label_LineOQ.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_LineOQ.Location = New System.Drawing.Point(825, 46)
        Me.Label_LineOQ.Name = "Label_LineOQ"
        Me.Label_LineOQ.Size = New System.Drawing.Size(80, 10)
        Me.Label_LineOQ.TabIndex = 231
        Me.Label_LineOQ.Tag = ""
        Me.Label_LineOQ.Text = "--------------"
        Me.Label_LineOQ.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label_ItemDelete
        '
        Me.Label_ItemDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_ItemDelete.Location = New System.Drawing.Point(830, 35)
        Me.Label_ItemDelete.Name = "Label_ItemDelete"
        Me.Label_ItemDelete.Size = New System.Drawing.Size(70, 16)
        Me.Label_ItemDelete.TabIndex = 232
        Me.Label_ItemDelete.Text = "Delete"
        Me.Label_ItemDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_ItemOriginal
        '
        Me.Label_ItemOriginal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_ItemOriginal.Location = New System.Drawing.Point(830, 18)
        Me.Label_ItemOriginal.Name = "Label_ItemOriginal"
        Me.Label_ItemOriginal.Size = New System.Drawing.Size(70, 16)
        Me.Label_ItemOriginal.TabIndex = 233
        Me.Label_ItemOriginal.Text = "Item"
        Me.Label_ItemOriginal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_LineItem
        '
        Me.Label_LineItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_LineItem.Location = New System.Drawing.Point(155, 46)
        Me.Label_LineItem.Name = "Label_LineItem"
        Me.Label_LineItem.Size = New System.Drawing.Size(50, 10)
        Me.Label_LineItem.TabIndex = 234
        Me.Label_LineItem.Text = "--------"
        Me.Label_LineItem.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label_Item
        '
        Me.Label_Item.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Item.Location = New System.Drawing.Point(160, 35)
        Me.Label_Item.Name = "Label_Item"
        Me.Label_Item.Size = New System.Drawing.Size(40, 16)
        Me.Label_Item.TabIndex = 235
        Me.Label_Item.Text = "Item"
        Me.Label_Item.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Banner1
        '
        Me.Label_Banner1.Location = New System.Drawing.Point(133, 55)
        Me.Label_Banner1.Name = "Label_Banner1"
        Me.Label_Banner1.Size = New System.Drawing.Size(1030, 2)
        Me.Label_Banner1.TabIndex = 223
        '
        'fra_Navigation
        '
        Me.fra_Navigation.Location = New System.Drawing.Point(11, 50)
        Me.fra_Navigation.Name = "fra_Navigation"
        Me.fra_Navigation.Size = New System.Drawing.Size(114, 823)
        Me.fra_Navigation.TabIndex = 237
        Me.fra_Navigation.TabStop = False
        '
        'lbl_Header
        '
        Me.lbl_Header.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Header.ForeColor = System.Drawing.Color.Indigo
        Me.lbl_Header.Location = New System.Drawing.Point(11, 32)
        Me.lbl_Header.Name = "lbl_Header"
        Me.lbl_Header.Size = New System.Drawing.Size(114, 23)
        Me.lbl_Header.TabIndex = 238
        Me.lbl_Header.Text = "Customers"
        Me.lbl_Header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'fra_Information
        '
        Me.fra_Information.BackColor = System.Drawing.Color.White
        Me.fra_Information.Location = New System.Drawing.Point(135, 55)
        Me.fra_Information.Name = "fra_Information"
        Me.fra_Information.Size = New System.Drawing.Size(790, 708)
        Me.fra_Information.TabIndex = 239
        Me.fra_Information.TabStop = False
        '
        'Label_Banner
        '
        Me.Label_Banner.Location = New System.Drawing.Point(130, 55)
        Me.Label_Banner.Name = "Label_Banner"
        Me.Label_Banner.Size = New System.Drawing.Size(800, 6)
        Me.Label_Banner.TabIndex = 240
        '
        'Label_Quantity1
        '
        Me.Label_Quantity1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Quantity1.Location = New System.Drawing.Point(735, 35)
        Me.Label_Quantity1.Name = "Label_Quantity1"
        Me.Label_Quantity1.Size = New System.Drawing.Size(70, 16)
        Me.Label_Quantity1.TabIndex = 242
        Me.Label_Quantity1.Text = "Quantity"
        Me.Label_Quantity1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_LineQ
        '
        Me.Label_LineQ.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_LineQ.Location = New System.Drawing.Point(730, 46)
        Me.Label_LineQ.Name = "Label_LineQ"
        Me.Label_LineQ.Size = New System.Drawing.Size(80, 10)
        Me.Label_LineQ.TabIndex = 241
        Me.Label_LineQ.Tag = ""
        Me.Label_LineQ.Text = "--------------"
        Me.Label_LineQ.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label_Rev
        '
        Me.Label_Rev.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Rev.Location = New System.Drawing.Point(670, 35)
        Me.Label_Rev.Name = "Label_Rev"
        Me.Label_Rev.Size = New System.Drawing.Size(40, 16)
        Me.Label_Rev.TabIndex = 244
        Me.Label_Rev.Text = "Rev"
        Me.Label_Rev.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_LineRev
        '
        Me.Label_LineRev.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_LineRev.Location = New System.Drawing.Point(665, 46)
        Me.Label_LineRev.Name = "Label_LineRev"
        Me.Label_LineRev.Size = New System.Drawing.Size(50, 10)
        Me.Label_LineRev.TabIndex = 243
        Me.Label_LineRev.Tag = ""
        Me.Label_LineRev.Text = "--------------"
        Me.Label_LineRev.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label_Drawing
        '
        Me.Label_Drawing.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Drawing.Location = New System.Drawing.Point(520, 18)
        Me.Label_Drawing.Name = "Label_Drawing"
        Me.Label_Drawing.Size = New System.Drawing.Size(125, 16)
        Me.Label_Drawing.TabIndex = 236
        Me.Label_Drawing.Text = "Drawing"
        Me.Label_Drawing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Number
        '
        Me.Label_Number.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Number.Location = New System.Drawing.Point(520, 35)
        Me.Label_Number.Name = "Label_Number"
        Me.Label_Number.Size = New System.Drawing.Size(125, 16)
        Me.Label_Number.TabIndex = 235
        Me.Label_Number.Text = "Number"
        Me.Label_Number.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_LineDN
        '
        Me.Label_LineDN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_LineDN.Location = New System.Drawing.Point(515, 46)
        Me.Label_LineDN.Name = "Label_LineDN"
        Me.Label_LineDN.Size = New System.Drawing.Size(135, 10)
        Me.Label_LineDN.TabIndex = 234
        Me.Label_LineDN.Tag = ""
        Me.Label_LineDN.Text = "-------------------------"
        Me.Label_LineDN.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label_CustomerName
        '
        Me.Label_CustomerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_CustomerName.Location = New System.Drawing.Point(225, 35)
        Me.Label_CustomerName.Name = "Label_CustomerName"
        Me.Label_CustomerName.Size = New System.Drawing.Size(270, 16)
        Me.Label_CustomerName.TabIndex = 246
        Me.Label_CustomerName.Text = "Customer Name"
        Me.Label_CustomerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_LineCN
        '
        Me.Label_LineCN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_LineCN.Location = New System.Drawing.Point(220, 46)
        Me.Label_LineCN.Name = "Label_LineCN"
        Me.Label_LineCN.Size = New System.Drawing.Size(280, 10)
        Me.Label_LineCN.TabIndex = 245
        Me.Label_LineCN.Tag = ""
        Me.Label_LineCN.Text = "------------------------------------------------------"
        Me.Label_LineCN.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'fra_New
        '
        Me.fra_New.BackColor = System.Drawing.Color.Bisque
        Me.fra_New.Controls.Add(Me.lbl_CustomerName)
        Me.fra_New.Controls.Add(Me.lbl_DrawingNumber)
        Me.fra_New.Controls.Add(Me.lbl_DrawingRev)
        Me.fra_New.Controls.Add(Me.lbl_ItemNo)
        Me.fra_New.Controls.Add(Me.tbox_Quantity)
        Me.fra_New.Controls.Add(Me.tbox_CustCode)
        Me.fra_New.Controls.Add(Me.lbl_New)
        Me.fra_New.Controls.Add(Me.Label5)
        Me.fra_New.Controls.Add(Me.Label4)
        Me.fra_New.Controls.Add(Me.Label3)
        Me.fra_New.Controls.Add(Me.Label2)
        Me.fra_New.Controls.Add(Me.Label1)
        Me.fra_New.Location = New System.Drawing.Point(423, 766)
        Me.fra_New.Name = "fra_New"
        Me.fra_New.Size = New System.Drawing.Size(501, 108)
        Me.fra_New.TabIndex = 247
        Me.fra_New.TabStop = False
        Me.fra_New.Visible = False
        '
        'lbl_CustomerName
        '
        Me.lbl_CustomerName.BackColor = System.Drawing.Color.White
        Me.lbl_CustomerName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_CustomerName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbl_CustomerName.Location = New System.Drawing.Point(112, 54)
        Me.lbl_CustomerName.Name = "lbl_CustomerName"
        Me.lbl_CustomerName.Size = New System.Drawing.Size(270, 20)
        Me.lbl_CustomerName.TabIndex = 14
        Me.lbl_CustomerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_DrawingNumber
        '
        Me.lbl_DrawingNumber.BackColor = System.Drawing.Color.White
        Me.lbl_DrawingNumber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_DrawingNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbl_DrawingNumber.Location = New System.Drawing.Point(112, 80)
        Me.lbl_DrawingNumber.Name = "lbl_DrawingNumber"
        Me.lbl_DrawingNumber.Size = New System.Drawing.Size(125, 20)
        Me.lbl_DrawingNumber.TabIndex = 13
        Me.lbl_DrawingNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_DrawingRev
        '
        Me.lbl_DrawingRev.BackColor = System.Drawing.Color.White
        Me.lbl_DrawingRev.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_DrawingRev.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbl_DrawingRev.Location = New System.Drawing.Point(342, 80)
        Me.lbl_DrawingRev.Name = "lbl_DrawingRev"
        Me.lbl_DrawingRev.Size = New System.Drawing.Size(40, 20)
        Me.lbl_DrawingRev.TabIndex = 12
        Me.lbl_DrawingRev.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_ItemNo
        '
        Me.lbl_ItemNo.AutoSize = True
        Me.lbl_ItemNo.Location = New System.Drawing.Point(371, 26)
        Me.lbl_ItemNo.Name = "lbl_ItemNo"
        Me.lbl_ItemNo.Size = New System.Drawing.Size(0, 13)
        Me.lbl_ItemNo.TabIndex = 11
        Me.lbl_ItemNo.Visible = False
        '
        'tbox_Quantity
        '
        Me.tbox_Quantity.BackColor = System.Drawing.Color.White
        Me.tbox_Quantity.Enabled = False
        Me.tbox_Quantity.Location = New System.Drawing.Point(227, 28)
        Me.tbox_Quantity.Name = "tbox_Quantity"
        Me.tbox_Quantity.Size = New System.Drawing.Size(70, 20)
        Me.tbox_Quantity.TabIndex = 10
        '
        'tbox_CustCode
        '
        Me.tbox_CustCode.BackColor = System.Drawing.Color.White
        Me.tbox_CustCode.Location = New System.Drawing.Point(112, 28)
        Me.tbox_CustCode.Name = "tbox_CustCode"
        Me.tbox_CustCode.Size = New System.Drawing.Size(30, 20)
        Me.tbox_CustCode.TabIndex = 6
        '
        'lbl_New
        '
        Me.lbl_New.AutoSize = True
        Me.lbl_New.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_New.ForeColor = System.Drawing.Color.DarkOliveGreen
        Me.lbl_New.Location = New System.Drawing.Point(10, 7)
        Me.lbl_New.Name = "lbl_New"
        Me.lbl_New.Size = New System.Drawing.Size(78, 18)
        Me.lbl_New.TabIndex = 5
        Me.lbl_New.Text = "New Item"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(178, 31)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Quantity:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(270, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Drawing Rev:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Drawing Number:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Customer Name:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(30, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Customer Code:"
        '
        'fra_Selection
        '
        Me.fra_Selection.Controls.Add(Me.Label_Selection1)
        Me.fra_Selection.Controls.Add(Me.Label_Selection2)
        Me.fra_Selection.Controls.Add(Me.Label_LineSelection)
        Me.fra_Selection.Controls.Add(Me.Listbox)
        Me.fra_Selection.Location = New System.Drawing.Point(954, 12)
        Me.fra_Selection.Name = "fra_Selection"
        Me.fra_Selection.Size = New System.Drawing.Size(200, 860)
        Me.fra_Selection.TabIndex = 252
        Me.fra_Selection.TabStop = False
        '
        'Label_Selection1
        '
        Me.Label_Selection1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Selection1.Location = New System.Drawing.Point(-5, 6)
        Me.Label_Selection1.Name = "Label_Selection1"
        Me.Label_Selection1.Size = New System.Drawing.Size(210, 16)
        Me.Label_Selection1.TabIndex = 254
        Me.Label_Selection1.Text = "Rev"
        Me.Label_Selection1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Selection2
        '
        Me.Label_Selection2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Selection2.Location = New System.Drawing.Point(-5, 23)
        Me.Label_Selection2.Name = "Label_Selection2"
        Me.Label_Selection2.Size = New System.Drawing.Size(210, 16)
        Me.Label_Selection2.TabIndex = 253
        Me.Label_Selection2.Text = "Customer Selection"
        Me.Label_Selection2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_LineSelection
        '
        Me.Label_LineSelection.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_LineSelection.Location = New System.Drawing.Point(-5, 34)
        Me.Label_LineSelection.Name = "Label_LineSelection"
        Me.Label_LineSelection.Size = New System.Drawing.Size(210, 15)
        Me.Label_LineSelection.TabIndex = 252
        Me.Label_LineSelection.Tag = ""
        Me.Label_LineSelection.Text = "----------------------------"
        Me.Label_LineSelection.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Listbox
        '
        Me.Listbox.FormattingEnabled = True
        Me.Listbox.Location = New System.Drawing.Point(0, 50)
        Me.Listbox.Name = "Listbox"
        Me.Listbox.Size = New System.Drawing.Size(200, 810)
        Me.Listbox.TabIndex = 249
        Me.Listbox.Visible = False
        '
        'frm_Inventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Bisque
        Me.ClientSize = New System.Drawing.Size(1164, 886)
        Me.Controls.Add(Me.fra_Selection)
        Me.Controls.Add(Me.fra_New)
        Me.Controls.Add(Me.Label_CustomerName)
        Me.Controls.Add(Me.Label_LineCN)
        Me.Controls.Add(Me.Label_Drawing)
        Me.Controls.Add(Me.Label_Number)
        Me.Controls.Add(Me.Label_Rev)
        Me.Controls.Add(Me.Label_LineDN)
        Me.Controls.Add(Me.Label_LineRev)
        Me.Controls.Add(Me.Label_Quantity1)
        Me.Controls.Add(Me.Label_LineQ)
        Me.Controls.Add(Me.Label_Banner)
        Me.Controls.Add(Me.fra_Information)
        Me.Controls.Add(Me.lbl_Header)
        Me.Controls.Add(Me.fra_Navigation)
        Me.Controls.Add(Me.Label_Item)
        Me.Controls.Add(Me.Label_LineItem)
        Me.Controls.Add(Me.Label_ItemOriginal)
        Me.Controls.Add(Me.Label_ItemDelete)
        Me.Controls.Add(Me.Label_LineOQ)
        Me.Controls.Add(Me.fra_Edits)
        Me.Controls.Add(Me.Label_Banner1)
        Me.Controls.Add(Me.Label_Line)
        Me.Controls.Add(Me.Label_Due)
        Me.Controls.Add(Me.VScrollBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Inventory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Inventory"
        Me.fra_Edits.ResumeLayout(False)
        Me.fra_New.ResumeLayout(False)
        Me.fra_New.PerformLayout()
        Me.fra_Selection.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fra_Selector As System.Windows.Forms.GroupBox
    Friend WithEvents Label_Due As System.Windows.Forms.Label
    Protected Friend WithEvents VScrollBar1 As System.Windows.Forms.VScrollBar
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents Label_Line As System.Windows.Forms.Label
    Friend WithEvents fra_Edits As System.Windows.Forms.GroupBox
    Public WithEvents lbl_Message2 As System.Windows.Forms.Label
    Friend WithEvents lbl_Message1 As System.Windows.Forms.Label
    Friend WithEvents Label_LineOQ As System.Windows.Forms.Label
    Friend WithEvents Label_ItemDelete As System.Windows.Forms.Label
    Friend WithEvents Label_ItemOriginal As System.Windows.Forms.Label
    Friend WithEvents Label_LineItem As System.Windows.Forms.Label
    Friend WithEvents Label_Item As System.Windows.Forms.Label
    Friend WithEvents Label_Banner1 As System.Windows.Forms.Label
    Friend WithEvents fra_Navigation As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_Header As System.Windows.Forms.Label
    Friend WithEvents fra_Information As System.Windows.Forms.GroupBox
    Friend WithEvents Label_Banner As System.Windows.Forms.Label
    Friend WithEvents Label_Quantity1 As System.Windows.Forms.Label
    Friend WithEvents Label_LineQ As System.Windows.Forms.Label
    Friend WithEvents Label_Rev As System.Windows.Forms.Label
    Friend WithEvents Label_LineRev As System.Windows.Forms.Label
    Friend WithEvents Label_Drawing As System.Windows.Forms.Label
    Friend WithEvents Label_Number As System.Windows.Forms.Label
    Friend WithEvents Label_LineDN As System.Windows.Forms.Label
    Friend WithEvents Label_CustomerName As System.Windows.Forms.Label
    Friend WithEvents Label_LineCN As System.Windows.Forms.Label
    Friend WithEvents fra_New As System.Windows.Forms.GroupBox
    Friend WithEvents tbox_CustCode As System.Windows.Forms.TextBox
    Friend WithEvents lbl_New As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbox_Quantity As System.Windows.Forms.TextBox
    Friend WithEvents lbl_ItemNo As System.Windows.Forms.Label
    Friend WithEvents fra_Selection As System.Windows.Forms.GroupBox
    Friend WithEvents Label_Selection1 As System.Windows.Forms.Label
    Friend WithEvents Label_Selection2 As System.Windows.Forms.Label
    Friend WithEvents Label_LineSelection As System.Windows.Forms.Label
    Friend WithEvents Listbox As System.Windows.Forms.ListBox
    Friend WithEvents lbl_DrawingRev As System.Windows.Forms.Label
    Friend WithEvents lbl_CustomerName As System.Windows.Forms.Label
    Friend WithEvents lbl_DrawingNumber As System.Windows.Forms.Label
    Friend WithEvents cmd_2 As System.Windows.Forms.Button
    Friend WithEvents cmd_3 As System.Windows.Forms.Button
    Friend WithEvents cmd_1 As System.Windows.Forms.Button
End Class
