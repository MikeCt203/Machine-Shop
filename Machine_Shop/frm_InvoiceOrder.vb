Imports System.Drawing.Printing
Public Class frm_InvoiceOrder

    'Database related
    Dim dbAdapter, dbAdapter_SystemData, dbAdapter_Misc As OleDb.OleDbDataAdapter
    Dim dbDataSet, dbDataSet_SystemData, dbDataSet_Misc As New DataSet
    Dim strSQL As String

    'Data related
    Dim Company_Name, Company_Address, Company_City, Company_State, Company_ZipCode As String
    Dim Company_Phone, Company_Email, Agent1, Agent2, ShipVia, Terms, Agent As String
    Dim LastInvoice, Discount_Days, Duedays As Integer
    Dim Discount_Amount As Single

    'Form controls related
    Dim tbox_Selector(1) As TextBox
    Dim lbl_Company(1) As Label
    Dim lbl_PurchaseOrder(1) As Label
    Dim lbl_POItem(1) As Label
    Dim lbl_DrawNumber(1) As Label
    Dim lbl_DrawRev(1) As Label
    Dim lbl_QtyOrder(1) As Label
    Dim lbl_DueDate(1) As Label
    Dim lbl_Price(1) As Label
    Dim lbl_TotalPrice(1) As Label
    Dim tbox_QtyShip(1) As TextBox
    Dim tbox_ShipDate(1) As MaskedTextBox
    Dim tbox_ShipVia(1) As TextBox
    Dim tbox_Freight(1) As TextBox
    Dim tbox_MaterialHeat(1) As TextBox
    Dim lbl_ID(1) As Label
    Dim cbx_Discount(1) As CheckBox
    Dim cbx_Freight(1) As CheckBox
    Dim cbx_Certification(1) As CheckBox
    Dim lbl_CustCode(1) As Label

    'Misc
    Dim InvoArray(1, 33) As Object 'Array to hold selected invoices
    Dim FreightMessageArray(9) As Integer 'Array to hold customer freight message warnings indicator
    Dim varInitialEntry As String 'Used to compare texbox entries
    Dim RecordCount, PurOrderCount, InvoiceCount As Integer 'RecordCount = all purchase order not invoiced, PurOrderCount is all purchase order selected, InvoiceCount = total number of invoices
    Dim intMessage As Integer 'Variable used in the mouse over event to show different messages
    Dim booCorrection As Boolean = False
    Dim booDataChecked, booFormView As Boolean

    'Print report Related
    Declare Function GetDeviceCaps% Lib "GDI32" (ByVal hDC%, ByVal nIndex%)
    Private WithEvents PrintForms As PrintDocument
    Private PageNumber, Buffer As Integer
    Private SystemPrinter, InvImage As String
    Private InvoBrush As New SolidBrush(Color.Black)
    Private FillBrush As New SolidBrush(Color.Lavender)


    'All form related events
    Private Sub frm_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated

        strSQL = "SELECT Invoice.CustCode,Company,PurchaseOrder,DrawingNumber,DrawingRevision,QtyOrdered,DueDate,Price,Customers.Freight," _
             & "Customers.ShipVia,Certification,MaterialHeat,Id,POItem FROM Customers INNER JOIN Invoice ON Customers.CustCode = Invoice.CustCode " _
             & "Where InvoiceDate is Null ORDER BY Duedate,Company,PurchaseOrder,DrawingNumber;"
        dbDataSet.Clear()
        dbDataSet.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter.Fill(dbDataSet, "View")
        gbl_DstConnect.Close()
        RecordCount = dbDataSet.Tables("View").Rows.Count()

        Call SystemValues()
        booFormView = True : Call FormChange()
        Call AddControls()
        Call DataFill()

    End Sub
    Private Sub SystemValues()

        'Titles and Image of invoice:
        Dim image_Path As String
        image_Path = Microsoft.VisualBasic.Left(Application.StartupPath, Len(Application.StartupPath) - 9) & "\Images\"
        InvImage = image_Path + "GammaLogo.png"

        'Retrieve system values
        strSQL = "SELECT CompanyName,CompanyAddress,CompanyCity,CompanyState,CompanyZipCode,CompanyPhone,CompanyEmail,LastInvoice," _
         & "DiscountDays,DiscountAmount,Terms,DueDays,ShipVia,Agent1,Agent2,SystemPrinter,Buffer,Id FROM System;"
        dbDataSet_SystemData.Clear()
        dbDataSet_SystemData.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter_SystemData = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter_SystemData.Fill(dbDataSet_SystemData, "SystemData")
        gbl_DstConnect.Close()
       
        Company_Name = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(0) 'Company Name
        Company_Address = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(1) 'Company Address
        Company_City = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(2) 'Company City
        Company_State = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(3) 'Company State
        Company_ZipCode = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(4) 'Company ZipCode
        Company_Phone = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(5) 'Company Phone
        Company_Email = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(6) 'Company Email
        LastInvoice = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(7) 'Last Invoice Number
        Discount_Days = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(8) 'Discount Days on payment
        Discount_Amount = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(9) 'Discount amount offered
        Terms = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(10) 'Payment terms
        Duedays = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(11) 'Due Days for payment
        ShipVia = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(12) 'Ship Via
        Agent1 = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(13) 'Primary inspection agent
        If Not IsDBNull(dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(14)) Then 'Secondary inspection agent
            Agent2 = Trim(dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(14))
        Else : Agent2 = "" : End If
        SystemPrinter = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(15) 'System printer name
        Buffer = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(16) 'Printer buffer
    End Sub
    Private Sub Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        dbDataSet.Clear()
        dbDataSet.Tables.Clear()
        dbDataSet_SystemData.Clear()
        dbDataSet_SystemData.Tables.Clear()
        dbDataSet_Misc.Clear()
        dbDataSet_Misc.Tables.Clear()
        Me.Dispose()
    End Sub
    Private Sub FormChange()

        fra_Information.Top = -2
        If VScrollBar1.Visible = True Then VScrollBar1.Value = 0

        fra_Information.Height = 35 + ((RecordCount - 1) * 25)
        If booFormView = True Then 'View and select mode
            Me.Text = "Customers Invoice Orders ( Selection )                                                        Date: " & Now.Date
            fra_Information.Width = 872
            fra_Invoice.Width = fra_Information.Width
            lbl_TopBanner.Width = fra_Information.Width + 3
            Label_Quantity2.Left = 978
            Label_Shipped.Left = 978
            cmd_1.Text = "Next"
            cmd_1.Enabled = False
            cmd_2.Visible = False
            cmd_Exit.Left = 96

            If RecordCount > 20 Then
                VScrollBar1.Left = 881
                VScrollBar1.Visible = True
                VScrollBar1.Maximum = RecordCount - 11
                Me.Height = 650
                Me.Width = 926
                fra_Invoice.Height = 507
                Line_Bottom.X2 = 882
                Line_Bottom.Visible = True
                fra_Commands.Width = fra_Information.Width + 17
                fra_Commands.Top = 546
            Else
                VScrollBar1.Visible = False
                Me.Height = 151 + (RecordCount * 25)
                Me.Width = 907
                fra_Invoice.Height = 33 + ((RecordCount - 1) * 25)
                fra_Commands.Top = fra_Invoice.Height + 38
                fra_Commands.Width = fra_Information.Width
            End If
        Else 'Invoice & edit mode
            Me.Visible = False
            Me.Text = "Customers Invoice Orders ( Processing )                                                                                                                                             Date: " & Now.Date
            fra_Information.Width = 1415
            fra_Invoice.Width = fra_Information.Width
            lbl_TopBanner.Width = fra_Information.Width + 3
            lbl_Message1.SetBounds(302, 24, 828, 14)
            lbl_Message2.Visible = False
            Label_Quantity2.Left = 879
            Label_Shipped.Left = 879
            lbl_TopBanner.Text = lbl_TopBanner.Text & "___________________________________________________________________________________________"

            cmd_1.Text = "Invoice"
            cmd_1.Enabled = True
            cmd_2.Text = "Edit"
            cmd_2.Left = 96
            cmd_2.Visible = True
            cmd_2.Enabled = True
            cmd_Exit.Left = 177

            If PurOrderCount > 20 Then
                VScrollBar1.Left = 1424
                VScrollBar1.Visible = True
                VScrollBar1.Maximum = PurOrderCount - 11
                Me.Height = 650
                Me.Width = 1470
                fra_Invoice.Height = 507
                Line_Bottom.Y1 = 542
                Line_Bottom.Y2 = 542
                Line_Bottom.X2 = 1425
                Line_Bottom.Visible = True
                fra_Commands.Width = fra_Information.Width + 17
                fra_Commands.Top = 546
                fra_Information.Top = -2
                VScrollBar1.Value = 0
            Else
                VScrollBar1.Visible = False
                fra_Invoice.Height = 35 + ((PurOrderCount - 1) * 25)
                fra_Information.Height = fra_Invoice.Height + 2
                Me.Height = 151 + (PurOrderCount * 25)
                Me.Width = 1451
                fra_Commands.Top = fra_Invoice.Height + 38
                fra_Commands.Width = fra_Information.Width
            End If
            Me.Left = (frm_Main.Width - Me.Width) / 2
            Me.Visible = True
        End If

    End Sub
    Private Sub AddControls() 'Add date and quantity controls

        Dim int_Top As Integer
        Dim i As Integer

        ReDim tbox_Selector(RecordCount)
        ReDim lbl_Company(RecordCount)
        ReDim lbl_PurchaseOrder(RecordCount)
        ReDim lbl_POItem(RecordCount)
        ReDim lbl_DrawNumber(RecordCount)
        ReDim lbl_DrawRev(RecordCount)
        ReDim lbl_QtyOrder(RecordCount)
        ReDim lbl_DueDate(RecordCount)
        ReDim lbl_Price(RecordCount)
        ReDim lbl_TotalPrice(RecordCount)
        ReDim tbox_QtyShip(RecordCount)
        ReDim tbox_ShipDate(RecordCount)
        ReDim tbox_ShipVia(RecordCount)
        ReDim tbox_Freight(RecordCount)
        ReDim tbox_MaterialHeat(RecordCount)
        ReDim lbl_ID(RecordCount)
        ReDim cbx_Discount(RecordCount)
        ReDim cbx_Freight(RecordCount)
        ReDim cbx_Certification(RecordCount)
        ReDim lbl_CustCode(RecordCount)

        'Create array of controls in frame information
        int_Top = -13
        For i = 0 To RecordCount - 1
            int_Top = int_Top + 25
            tbox_Selector(i) = New TextBox
            lbl_ID(i) = New Label
            lbl_Company(i) = New Label
            lbl_PurchaseOrder(i) = New Label
            lbl_POItem(i) = New Label
            lbl_DrawNumber(i) = New Label
            lbl_DrawRev(i) = New Label
            lbl_QtyOrder(i) = New Label
            lbl_DueDate(i) = New Label
            lbl_Price(i) = New Label
            tbox_QtyShip(i) = New TextBox
            tbox_ShipDate(i) = New MaskedTextBox
            tbox_ShipVia(i) = New TextBox
            lbl_TotalPrice(i) = New Label
            tbox_Freight(i) = New TextBox
            tbox_MaterialHeat(i) = New TextBox
            lbl_ID(i) = New Label
            cbx_Discount(i) = New CheckBox
            cbx_Freight(i) = New CheckBox
            cbx_Certification(i) = New CheckBox
            lbl_CustCode(i) = New Label

            With tbox_Selector(i)
                .Name = "tbox_Selector"
                .Tag = i
                .Enabled = True
                .BackColor = Color.White
                .Font = New Font("Ariel", 8, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .Visible = True
                .SetBounds(15, int_Top - 3, 20, 20)
                fra_Information.Controls.Add(tbox_Selector(i))
                AddHandler .GotFocus, AddressOf tbox_GotFocus
                AddHandler .LostFocus, AddressOf tbox_LostFocus
                AddHandler .TextChanged, AddressOf tbox_TextChanged
                AddHandler .KeyPress, AddressOf tbox_KeyPress
                AddHandler .MouseHover, AddressOf All_MouseHover
            End With

            With lbl_Company(i)
                .Name = "lbl_Company"
                .Tag = i
                .Font = New Font("Ariel", 8, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .Visible = True
                .SetBounds(48, int_Top, 185, 20)
                fra_Information.Controls.Add(lbl_Company(i))
            End With

            With lbl_PurchaseOrder(i)
                .Name = "lbl_PurchaseOrder"
                .Tag = i
                .Font = New Font("Ariel", 8, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .Visible = True
                .SetBounds(246, int_Top, 128, 20)
                fra_Information.Controls.Add(lbl_PurchaseOrder(i))
            End With

            With lbl_POItem(i)
                .Name = "lbl_POItem"
                .Tag = i
                .Visible = False
                .SetBounds(370, int_Top, 5, 20)
                fra_Information.Controls.Add(lbl_POItem(i))
            End With

            With lbl_DrawNumber(i)
                .Name = "lbl_DrawNumber"
                .Tag = i
                .Font = New Font("Ariel", 8, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .Visible = True
                .SetBounds(387, int_Top, 110, 20)
                fra_Information.Controls.Add(lbl_DrawNumber(i))
            End With

            With lbl_DrawRev(i)
                .Name = "lbl_DrawRev"
                .Tag = i
                .Font = New Font("Ariel", 8, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .Visible = True
                .SetBounds(510, int_Top, 55, 20)
                fra_Information.Controls.Add(lbl_DrawRev(i))
            End With

            With lbl_QtyOrder(i)
                .Name = "lbl_QtyOrder"
                .Tag = i
                .Font = New Font("Ariel", 8, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .Visible = True
                .SetBounds(578, int_Top, 50, 20)
                fra_Information.Controls.Add(lbl_QtyOrder(i))
            End With

            With lbl_DueDate(i)
                .Name = "lbl_DueDate"
                .Tag = i
                .Font = New Font("Ariel", 8, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .Visible = True
                .SetBounds(641, int_Top, 67, 20)
                fra_Information.Controls.Add(lbl_DueDate(i))
            End With

            With lbl_Price(i)
                .Name = "lbl_Price"
                .Tag = i
                .Font = New Font("Ariel", 8, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .Visible = True
                .SetBounds(721, int_Top, 60, 20)
                fra_Information.Controls.Add(lbl_Price(i))
            End With

            With lbl_TotalPrice(i)
                .Name = "lbl_TotalPrice"
                .Tag = i
                .Font = New Font("Ariel", 8, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .Visible = True
                .SetBounds(794, int_Top, 65, 20)
                fra_Information.Controls.Add(lbl_TotalPrice(i))
            End With

            With tbox_QtyShip(i)
                .Name = "tbox_QtyShip"
                .Tag = i
                .Enabled = False
                .BackColor = Color.White
                .ForeColor = Color.Blue
                .Font = New Font("Ariel", 8, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .Visible = True
                .SetBounds(872, int_Top, 50, 20)
                fra_Information.Controls.Add(tbox_QtyShip(i))
                AddHandler .GotFocus, AddressOf tbox_GotFocus
                AddHandler .LostFocus, AddressOf tbox_LostFocus
                AddHandler .TextChanged, AddressOf tbox_TextChanged
                AddHandler .KeyPress, AddressOf tbox_KeyPress
            End With

            With tbox_ShipDate(i)
                .Name = "tbox_ShipDate"
                .Tag = i
                .Enabled = False
                .BackColor = Color.White
                .Font = New Font("Ariel", 8, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .Mask = ("##/##/####")
                .Visible = True
                .SetBounds(935, int_Top, 67, 20)
                fra_Information.Controls.Add(tbox_ShipDate(i))
                AddHandler .GotFocus, AddressOf tbox_GotFocus
                AddHandler .LostFocus, AddressOf tbox_LostFocus
                AddHandler .TextChanged, AddressOf tbox_TextChanged
                AddHandler .KeyPress, AddressOf tbox_KeyPress
                AddHandler .MouseClick, AddressOf tbox_MouseClick
            End With

            With tbox_ShipVia(i)
                .Name = "tbox_ShipVia"
                .Tag = i
                .Enabled = False
                .BackColor = Color.White
                .Font = New Font("Ariel", 8, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .Visible = True
                .SetBounds(1015, int_Top, 107, 20)
                fra_Information.Controls.Add(tbox_ShipVia(i))
                AddHandler .GotFocus, AddressOf tbox_GotFocus
                AddHandler .LostFocus, AddressOf tbox_LostFocus
                AddHandler .TextChanged, AddressOf tbox_TextChanged
                AddHandler .KeyPress, AddressOf tbox_KeyPress
            End With

            With tbox_Freight(i)
                .Name = "tbox_Freight"
                .Tag = i
                .Enabled = False
                .BackColor = Color.White
                .Font = New Font("Ariel", 8, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .Visible = True
                .SetBounds(1135, int_Top, 45, 20)
                fra_Information.Controls.Add(tbox_Freight(i))
                AddHandler .GotFocus, AddressOf tbox_GotFocus
                AddHandler .LostFocus, AddressOf tbox_LostFocus
                AddHandler .TextChanged, AddressOf tbox_TextChanged
                AddHandler .KeyPress, AddressOf tbox_KeyPress
            End With

            With tbox_MaterialHeat(i)
                .Name = "tbox_MaterialHeat"
                .Tag = i
                .Enabled = False
                .BackColor = Color.White
                .Font = New Font("Ariel", 8, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .Visible = True
                .SetBounds(1193, int_Top, 100, 20)
                fra_Information.Controls.Add(tbox_MaterialHeat(i))
                AddHandler .GotFocus, AddressOf tbox_GotFocus
                AddHandler .LostFocus, AddressOf tbox_LostFocus
                AddHandler .TextChanged, AddressOf tbox_TextChanged
                AddHandler .KeyPress, AddressOf tbox_KeyPress
            End With

            With lbl_ID(i)
                .Name = "lbl_ID"
                .Tag = i
                .Visible = False 'True
                .SetBounds(1306, int_Top, 45, 20)
                fra_Information.Controls.Add(lbl_ID(i))
            End With

            With cbx_Discount(i)
                .Name = "cbx_Discount"
                .Tag = i
                .Enabled = False
                .Visible = True
                .SetBounds(1378, int_Top + 3, 15, 14) '1184,15 is good
                fra_Information.Controls.Add(cbx_Discount(i))
                AddHandler .Click, AddressOf cbx_Discount_Click
                AddHandler .MouseHover, AddressOf All_MouseHover
            End With

            With cbx_Freight(i)
                .Name = "cbx_Freight"
                .Tag = i
                .Visible = False
                fra_Information.Controls.Add(cbx_Freight(i))
            End With

            With cbx_Certification(i)
                .Name = "cbx_Certification"
                .Tag = i
                .Visible = False
                fra_Information.Controls.Add(cbx_Certification(i))
            End With

            With lbl_CustCode(i)
                .Name = "lbl_CustCode"
                .Tag = i
                .Visible = False
                fra_Information.Controls.Add(lbl_CustCode(i))
            End With

        Next
    End Sub
    Private Sub DataFill() 'Fill form with data pertaining to listbox selection

        booDataChecked = True
        For intStep = 0 To RecordCount - 1

            'Form fill data
            If Not IsDBNull(dbDataSet.Tables("View").Rows(intStep).Item(0)) Then 'CustCode
                lbl_CustCode(intStep).Text = Trim(dbDataSet.Tables("View").Rows(intStep).Item(0))
            Else : lbl_CustCode(intStep).Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("View").Rows(intStep).Item(1)) Then 'Company Name
                lbl_Company(intStep).Text = Trim(dbDataSet.Tables("View").Rows(intStep).Item(1))
            Else : lbl_Company(intStep).Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("View").Rows(intStep).Item(2)) Then 'Purchase Order
                lbl_PurchaseOrder(intStep).Text = Trim(dbDataSet.Tables("View").Rows(intStep).Item(2))
            Else : lbl_PurchaseOrder(intStep).Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("View").Rows(intStep).Item(3)) Then 'Drawing Number
                lbl_DrawNumber(intStep).Text = Trim(dbDataSet.Tables("View").Rows(intStep).Item(3))
            Else : lbl_DrawNumber(intStep).Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("View").Rows(intStep).Item(4)) Then 'Drawing Revision
                lbl_DrawRev(intStep).Text = Trim(dbDataSet.Tables("View").Rows(intStep).Item(4))
            Else : lbl_DrawRev(intStep).Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("View").Rows(intStep).Item(5)) Then 'Quantity Ordered
                lbl_QtyOrder(intStep).Text = Trim(dbDataSet.Tables("View").Rows(intStep).Item(5))
            Else : lbl_QtyOrder(intStep).Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("View").Rows(intStep).Item(6)) And dbDataSet.Tables("View").Rows(intStep).Item(6).ToString <> "#12/12/1212#" Then 'Due Date
                lbl_DueDate(intStep).Text = FormatDateTime(dbDataSet.Tables("View").Rows(intStep).Item(6), DateFormat.ShortDate)
            Else : lbl_DueDate(intStep).Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("View").Rows(intStep).Item(7)) Then 'Price
                lbl_Price(intStep).Text = FormatCurrency(Trim(dbDataSet.Tables("View").Rows(intStep).Item(7)))
            Else : lbl_Price(intStep).Text = "" : End If

            lbl_TotalPrice(intStep).Text = FormatCurrency(lbl_Price(intStep).Text * lbl_QtyOrder(intStep).Text) 'Total Price
            tbox_QtyShip(intStep).Text = lbl_QtyOrder(intStep).Text 'Quantity shipped
            tbox_ShipDate(intStep).Text = Format(Now.Date, "MM/dd/yyyy")

            If dbDataSet.Tables("View").Rows(intStep).Item(8) = False Then cbx_Freight(intStep).Checked = False Else cbx_Freight(intStep).Checked = True 'Freight

            If Not IsDBNull(dbDataSet.Tables("View").Rows(intStep).Item(9)) Then 'ShipVia
                tbox_ShipVia(intStep).Text = Trim(dbDataSet.Tables("View").Rows(intStep).Item(9))
            Else : tbox_ShipVia(intStep).Text = ShipVia : End If

            If dbDataSet.Tables("View").Rows(intStep).Item(10) = False Then cbx_Certification(intStep).Checked = False Else cbx_Certification(intStep).Checked = True 'Certification

            If Not IsDBNull(dbDataSet.Tables("View").Rows(intStep).Item(11)) Then 'Material Heat
                tbox_MaterialHeat(intStep).Text = Trim(dbDataSet.Tables("View").Rows(intStep).Item(11))
            Else : tbox_MaterialHeat(intStep).Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("View").Rows(intStep).Item(12)) Then 'Id
                lbl_ID(intStep).Text = Trim(dbDataSet.Tables("View").Rows(intStep).Item(12))
            Else : lbl_ID(intStep).Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("View").Rows(intStep).Item(13)) Then 'Purchase Order line item number
                lbl_POItem(intStep).Text = Trim(dbDataSet.Tables("View").Rows(intStep).Item(13))
            Else : lbl_POItem(intStep).Text = "" : End If

        Next
        booDataChecked = False

    End Sub
    Private Sub VScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles VScrollBar1.Scroll
        fra_Information.Top = -2 - (VScrollBar1.Value * 25)
    End Sub
    Private Sub Datasave() 'Mark all selected purchase orders as invoiced

        On Error GoTo goActionErr

        Dim InvoNumber As Integer
        Dim FreightCharge As Single

        'Save selected items as invoiced
        For intStep = 0 To PurOrderCount - 1

            strSQL = "SELECT Id,InvoiceNumber,InvoiceDate,ShipDate,QtyShip,Discount,DiscountDays,Freight," _
                       & "ShipVia,MaterialHeat,InvoiceItem,POItem FROM Invoice Where Id = " & InvoArray(intStep, 18) & ";"
            dbDataSet_Misc.Clear()
            dbDataSet_Misc.Tables.Clear()
            gbl_DstConnect.Open()
            dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
            dbAdapter_Misc.Fill(dbDataSet_Misc, "DataSave")
            gbl_DstConnect.Close()

            Dim cb0 As New OleDb.OleDbCommandBuilder(dbAdapter_Misc)

            If intStep = 0 Then
                InvoNumber = InvoArray(intStep, 32)
            Else
                If InvoArray(intStep, 32) <> Nothing Then InvoNumber = InvoArray(intStep, 32) 'Update invoice number only if different ( multiple items on same invoice)
            End If
            dbDataSet_Misc.Tables("DataSave").Rows(0).Item(1) = InvoNumber 'Invoice Number
            If InvoArray(intStep, 11) = Now.Date Then
                dbDataSet_Misc.Tables("DataSave").Rows(0).Item(2) = Now.Date 'Invoiced Date
            Else
                dbDataSet_Misc.Tables("DataSave").Rows(0).Item(2) = InvoArray(intStep, 11) 'Ship date
            End If
            dbDataSet_Misc.Tables("DataSave").Rows(0).Item(3) = InvoArray(intStep, 11) 'Ship date
            dbDataSet_Misc.Tables("DataSave").Rows(0).Item(4) = InvoArray(intStep, 10) 'Qty Shipped
            If InvoArray(intStep, 16) = True Then
                dbDataSet_Misc.Tables("DataSave").Rows(0).Item(5) = Discount_Amount 'Discount
                dbDataSet_Misc.Tables("DataSave").Rows(0).Item(6) = Discount_Days 'Discount Days
            End If
            If InvoArray(intStep, 13) <> "" Then
                FreightCharge = InvoArray(intStep, 13)
                dbDataSet_Misc.Tables("DataSave").Rows(0).Item(7) = FreightCharge 'Freight charges
            End If
            If InvoArray(intStep, 12) <> "" Then dbDataSet_Misc.Tables("DataSave").Rows(0).Item(8) = InvoArray(intStep, 12) 'ShipVia
            If InvoArray(intStep, 17) <> "" Then dbDataSet_Misc.Tables("DataSave").Rows(0).Item(9) = InvoArray(intStep, 17) 'Material Heat
            dbDataSet_Misc.Tables("DataSave").Rows(0).Item(10) = InvoArray(intStep, 33) 'Invoice item number
            If InvoArray(intStep, 3) <> "" Then dbDataSet_Misc.Tables("DataSave").Rows(0).Item(11) = InvoArray(intStep, 3) 'Purchase order line item number
            dbAdapter_Misc.Update(dbDataSet_Misc, "DataSave")
            cb0 = Nothing
        Next

        'Update Inventory with shipped items
        Dim intQty As Integer
        For intStep = 0 To PurOrderCount - 1
            strSQL = "SELECT Id,Quantity FROM Inventory Where Custcode = " & InvoArray(intStep, 22) & " AND " _
                   & "DrawNumber = '" & InvoArray(intStep, 4) & "' AND Revision = '" & InvoArray(intStep, 5) & "';"
            dbDataSet_Misc.Clear()
            dbDataSet_Misc.Tables.Clear()
            gbl_DstConnect.Open()
            dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
            dbAdapter_Misc.Fill(dbDataSet_Misc, "Inventory")
            gbl_DstConnect.Close()
            Dim inty As Integer = dbDataSet_Misc.Tables("Inventory").Rows.Count()

            If dbDataSet_Misc.Tables("Inventory").Rows.Count() = 1 Then
                If Not IsDBNull(dbDataSet_Misc.Tables("Inventory").Rows(0).Item(1)) Then 'Quantity
                    intQty = Trim(dbDataSet_Misc.Tables("Inventory").Rows(0).Item(1)) - InvoArray(intStep, 10)
                Else : intQty = 0 : End If

                Dim cb0 As New OleDb.OleDbCommandBuilder(dbAdapter_Misc)
                dbDataSet_Misc.Tables("Inventory").Rows(0).Item(1) = intQty 'New adjusted inventory count
                dbAdapter_Misc.Update(dbDataSet_Misc, "Inventory")
                cb0 = Nothing
            Else
                frm_Message.Text = "7:1:0:15:3:Item " & intStep + 1 & " was not found in inventory, inventory could not be updated for this item"
                frm_Message.ShowDialog()
            End If
        Next

        'Update last invoice number in system database
        LastInvoice = InvoNumber
        Dim cb1 As New OleDb.OleDbCommandBuilder(dbAdapter_SystemData)
        dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(7) = InvoNumber 'Last invoice number
        dbAdapter_SystemData.Update(dbDataSet_SystemData, "SystemData")
        cb1 = Nothing
        Me.Close()
        Exit Sub
goActionErr:
        MsgBox(Err.Description)
        Exit Sub
    End Sub
    Private Sub PrintForms_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintForms.PrintPage

        'Setup hard margins for printer
        Static SelectForm, p_row As Integer
        Dim hDC As IntPtr = e.Graphics.GetHdc()
        Dim CurrentX, CurrentY, CurrentX1, CurrentX2, CurrentX3, TextX, TextY, TextLen As Integer
        Dim HardX1, HardX2, HardY1, HardY2, HardWidth, HardHeight As Integer
        Dim Font As Font
        Dim Text As String
        Dim points() As Point
        Dim border, fill As Rectangle
        Dim blackPen As New Pen(Color.Black, 1)
        Dim booMulti As Boolean = False

        HardX1 = GetDeviceCaps(hDC.ToInt64, 112)
        HardY1 = GetDeviceCaps(hDC.ToInt64, 113)
        e.Graphics.ReleaseHdc(hDC)
        HardX1 = (HardX1 * 100.0) / e.Graphics.DpiX
        HardY1 = (HardY1 * 100.0) / e.Graphics.DpiY
        HardX2 = HardX1 + (e.PageBounds.Width - Buffer)
        HardWidth = e.PageBounds.Width - Buffer
        HardHeight = e.PageBounds.Height - Buffer
        HardY2 = HardY1 + (e.PageBounds.Height - Buffer)
        CurrentX = HardX1
        CurrentY = HardY1

        'Draw Invoice form
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit

        If PageNumber = 1 Then p_row = 0 : SelectForm = 1
        Select Case SelectForm
            Case 1, 2
                'Print large invoice text:
                Font = New Font("Swis721 BlkOul BT", 32, FontStyle.Regular) ' Font
                If SelectForm = 1 Then
                    e.Graphics.DrawString("invoice", Font, InvoBrush, HardX1 + 500, HardY1 + 70)

                    'Print label "Invoice no:"        
                    Font = New Font("Arial", 12, FontStyle.Bold)
                    e.Graphics.DrawString("Invoice No:", Font, InvoBrush, HardX1 + 630, HardY1 + 20)
                Else
                    e.Graphics.DrawString("Packing List", Font, InvoBrush, HardX1 + 460, HardY1 + 70)
                End If

                'Print labels Sold To & Ship To
                Font = New Font("Arial", 12, FontStyle.Bold)
                e.Graphics.DrawString("Sold To:", Font, InvoBrush, HardX1 + 20, HardY1 + 250)
                e.Graphics.DrawString("Ship To:", Font, InvoBrush, HardX1 + 430, HardY1 + 250)

                'Print Lower form graphics
                Font = New Font("Arial", 9, FontStyle.Bold)
                Using the_pen As New Pen(Color.Black, 1)

                    points = {New Point(HardX1, HardY1), New Point(HardX2, HardY1), New Point(HardX2, HardY2), New Point(HardX1, HardY2)} 'Outside rectangle
                    e.Graphics.DrawPolygon(the_pen, points)

                    CurrentY = HardY1 + 343
                    points = {New Point(HardX1, CurrentY), New Point(HardX2, CurrentY)} '1st horzontal Line
                    e.Graphics.DrawLines(the_pen, points)

                    fill = New Rectangle(HardX1 + 1, CurrentY, HardWidth - 2, 20) ' Create rectangle for background fill 1st area
                    e.Graphics.FillRectangle(FillBrush, fill) 'Fill rectangle with background color 1st area

                    CurrentX = HardX1 + 38
                    points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 45)} '1st upper vertical line
                    e.Graphics.DrawLines(the_pen, points)

                    Text = "Purchase Order No"
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                    TextX = CurrentX + (172 - TextLen) / 2
                    TextY = CurrentY + 2
                    e.Graphics.DrawString(Text, Font, InvoBrush, TextX, TextY) 'Print label Purchase order no

                    CurrentX = CurrentX + 172
                    points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 45)} '2nd upper vertical line
                    e.Graphics.DrawLines(the_pen, points)

                    Text = "Invoice Date"
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                    TextX = CurrentX + (125 - TextLen) / 2
                    e.Graphics.DrawString(Text, Font, InvoBrush, TextX, TextY) 'Print label Invoice date

                    CurrentX = CurrentX + 125
                    points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 45)} '3rd upper vertical line
                    e.Graphics.DrawLines(the_pen, points)

                    Text = "Date Shipped"
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                    TextX = CurrentX + (125 - TextLen) / 2
                    e.Graphics.DrawString(Text, Font, InvoBrush, TextX, TextY) 'Print label date shipped

                    CurrentX = CurrentX + 125
                    points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 45)} '4th upper vertical line
                    e.Graphics.DrawLines(the_pen, points)

                    Text = "Ship Via"
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                    TextX = CurrentX + (134 - TextLen) / 2
                    e.Graphics.DrawString(Text, Font, InvoBrush, TextX, TextY) 'Print label ship via

                    CurrentX = CurrentX + 134
                    points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 45)} '5th upper vertical line
                    e.Graphics.DrawLines(the_pen, points)

                    Text = "Terms"
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                    TextX = CurrentX + (124 - TextLen) / 2
                    e.Graphics.DrawString(Text, Font, InvoBrush, TextX, TextY) 'Print label terms

                    CurrentX = CurrentX + 124
                    points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 45)} '6th upper vertical line
                    e.Graphics.DrawLines(the_pen, points)

                    Text = "Disc."
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                    TextX = CurrentX + (46 - TextLen) / 2
                    e.Graphics.DrawString(Text, Font, InvoBrush, TextX, TextY) 'Print label Discount

                    CurrentX = CurrentX + 46
                    points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 45)} '7th upper vertical line
                    e.Graphics.DrawLines(the_pen, points)

                    points = {New Point(HardX1, CurrentY + 20), New Point(HardX2, CurrentY + 20)} '2nd horzontal Line
                    e.Graphics.DrawLines(the_pen, points)

                    CurrentY = HardY1 + 388 '3rd horizontal line
                    points = {New Point(HardX1, CurrentY), New Point(HardX2, CurrentY)} '3rd horzontal Line
                    e.Graphics.DrawLines(the_pen, points)

                    fill = New Rectangle(HardX1 + 1, CurrentY, HardWidth - 2, 35) ' Create rectangle for background fill 2nd area
                    e.Graphics.FillRectangle(FillBrush, fill) 'Fill rectangle with background color 2nd area

                    Text = "Item"
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                    TextX = HardX1 + (50 - TextLen) / 2
                    TextY = CurrentY + 18
                    e.Graphics.DrawString(Text, Font, InvoBrush, TextX + 2, TextY) 'Print label invoice item number

                    CurrentX = HardX1 + 50
                    points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 525)} '1st lower vertical line
                    e.Graphics.DrawLines(the_pen, points)

                    Text = "PO"
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                    TextX = CurrentX + (50 - TextLen) / 2
                    TextY = CurrentY + 3
                    e.Graphics.DrawString(Text, Font, InvoBrush, TextX + 4, TextY) 'Print PO

                    Text = "Item"
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                    TextX = CurrentX + (50 - TextLen) / 2
                    TextY = CurrentY + 18
                    e.Graphics.DrawString(Text, Font, InvoBrush, TextX + 2, TextY) 'Print label purchase order item number

                    CurrentX = CurrentX + 50
                    points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 525)} '2nd lower vertical line
                    e.Graphics.DrawLines(the_pen, points)

                    Text = "Qty"
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                    TextX = CurrentX + (70 - TextLen) / 2
                    TextY = CurrentY + 3
                    e.Graphics.DrawString(Text, Font, InvoBrush, TextX + 1, TextY) 'Print Qty

                    Text = "Ordered"
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                    TextX = CurrentX + (70 - TextLen) / 2
                    TextY = CurrentY + 18
                    e.Graphics.DrawString(Text, Font, InvoBrush, TextX + 1, TextY) 'Print Ordered

                    CurrentX = CurrentX + 70
                    points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 525)} '3rd lower vertical line
                    e.Graphics.DrawLines(the_pen, points)

                    Text = "Qty"
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                    TextX = CurrentX + (70 - TextLen) / 2
                    TextY = CurrentY + 3
                    e.Graphics.DrawString(Text, Font, InvoBrush, TextX + 2, TextY) 'Print Qty

                    Text = "Shipped"
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                    TextX = CurrentX + (70 - TextLen) / 2
                    TextY = CurrentY + 18
                    e.Graphics.DrawString(Text, Font, InvoBrush, TextX + 3, TextY) 'Print Shipped

                    CurrentX = CurrentX + 70
                    points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 525)} '4th lower vertical line
                    e.Graphics.DrawLines(the_pen, points)

                    Text = "Description"
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                    TextX = CurrentX + (350 - TextLen) / 2
                    e.Graphics.DrawString(Text, Font, InvoBrush, TextX + 2, TextY) 'Print Description

                    CurrentX = CurrentX + 350
                    points = {New Point(CurrentX, CurrentY), New Point(CurrentX, HardY2)} '5th lower vertical line
                    e.Graphics.DrawLines(the_pen, points)

                    Text = "Unit Price"
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                    TextX = CurrentX + (100 - TextLen) / 2
                    e.Graphics.DrawString(Text, Font, InvoBrush, TextX + 2, TextY) 'Print unit price

                    CurrentX = CurrentX + 100
                    points = {New Point(CurrentX, CurrentY), New Point(CurrentX, HardY2)} '6th lower vertical line
                    e.Graphics.DrawLines(the_pen, points)

                    Text = "Extended Price"
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                    TextX = CurrentX + (112 - TextLen) / 2
                    e.Graphics.DrawString(Text, Font, InvoBrush, TextX + 2, TextY) 'Print extended price

                    points = {New Point(HardX1, CurrentY + 35), New Point(HardX2, CurrentY + 35)} '4th horzontal Line
                    e.Graphics.DrawLines(the_pen, points)

                    CurrentY = HardY1 + 913 'CurrentY = 5th horizontal line
                    points = {New Point(HardX1, CurrentY), New Point(HardX2, CurrentY)} '5th horzontal Line
                    e.Graphics.DrawLines(the_pen, points)

                    CurrentY = HardY1 + 938 'CurrentY = 6th horzontal Line
                    points = {New Point(HardX1 + 590, CurrentY), New Point(HardX2, CurrentY)} '6th horzontal Line
                    e.Graphics.DrawLines(the_pen, points)

                    CurrentY = HardY2 - 48 'CurrentY = 7th horzontal Line
                    points = {New Point(HardX1 + 590, HardY2 - 48), New Point(HardX2, CurrentY)} '7th horzontal Line
                    e.Graphics.DrawLines(the_pen, points)

                    If SelectForm = 1 Then 'Invoice
                        Text = "Sub Total"
                        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                        TextX = HardX1 + 688 - TextLen
                        e.Graphics.DrawString(Text, Font, InvoBrush, TextX, HardY1 + 919) 'Print label sub total

                        Text = "Misc. Charges"
                        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                        TextX = HardX1 + 688 - TextLen
                        e.Graphics.DrawString(Text, Font, InvoBrush, TextX, HardY1 + 948) 'Print label misc. charges 

                        Text = "Sales Tax"
                        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                        TextX = HardX1 + 688 - TextLen
                        e.Graphics.DrawString(Text, Font, InvoBrush, TextX, HardY1 + 965) 'Print label sales tax

                        Text = "Freight"
                        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                        TextX = HardX1 + 688 - TextLen
                        e.Graphics.DrawString(Text, Font, InvoBrush, TextX, HardY1 + 982) 'Print label freight 

                        Text = "Total"
                        Font = New Font("Arial", 11, FontStyle.Bold)
                        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                        TextX = HardX1 + 688 - TextLen
                        e.Graphics.DrawString(Text, Font, InvoBrush, TextX, HardY1 + 1024) 'Print label total

                        Text = "Thank You"
                        Font = New Font("Edwardian Script ITC", 22, FontStyle.Regular)
                        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                        TextX = HardX1 + 545 - TextLen
                        TextY = CurrentY + 5
                        e.Graphics.DrawString(Text, Font, InvoBrush, TextX, TextY) 'Print label total
                    Else 'Packing list
                        Text = "Packing List"
                        Font = New Font("Arial", 48, FontStyle.Regular)
                        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                        Dim textHeight = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Height)
                        e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + (560 - TextLen) / 2, HardY2 - 105) 'Print label packing list
                    End If

                End Using ' the_pen 

                'Fill form with data
                If (System.IO.File.Exists(InvImage)) Then 'Draw Logo image
                    Dim oInvImage As Bitmap = New Bitmap(InvImage)
                    e.Graphics.DrawImage(oInvImage, HardX1 + 30, HardY1 + 25)
                End If

                'Print Company data under logo
                CurrentX = HardX1 + 233 : CurrentY = HardY1 + 123
                Font = New Font("Microsoft Sans Serif", 12, FontStyle.Regular)
                e.Graphics.DrawString(Company_Address, Font, InvoBrush, CurrentX, CurrentY) 'Print company address
                CurrentY = CurrentY + Font.Height
                e.Graphics.DrawString(Company_City & "  " & Company_State & "  " & Company_ZipCode, Font, InvoBrush, CurrentX, CurrentY) 'Print company city, state, zipcode
                Font = New Font("Ariel", 10, FontStyle.Regular)
                CurrentY = CurrentY + Font.Height + 4
                e.Graphics.DrawString(Company_Phone, Font, InvoBrush, CurrentX + 27, CurrentY) 'Print company phone

                'Print invoice number
                e.Graphics.DrawString(InvoArray(P_row, 32), Font, InvoBrush, HardX1 + 727, HardY1 + 22)

                'Print Sold To & Ship to data
                CurrentY = HardY1 + 252
                e.Graphics.DrawString(InvoArray(P_row, 27), Font, InvoBrush, HardX1 + 96, CurrentY) 'Sold to 
                e.Graphics.DrawString(InvoArray(P_row, 1), Font, InvoBrush, HardX1 + 506, CurrentY) 'Ship to 
                CurrentY = CurrentY + Font.Height + 3
                e.Graphics.DrawString(InvoArray(P_row, 28), Font, InvoBrush, HardX1 + 96, CurrentY) 'Sold to address
                e.Graphics.DrawString(InvoArray(P_row, 23), Font, InvoBrush, HardX1 + 506, CurrentY) 'Ship to address
                CurrentY = CurrentY + Font.Height + 3
                e.Graphics.DrawString(InvoArray(P_row, 29) & "  " & InvoArray(P_row, 30) & "  " & InvoArray(P_row, 31), Font, InvoBrush, HardX1 + 96, CurrentY) 'Sold to city, state, zipcode
                e.Graphics.DrawString(InvoArray(P_row, 24) & "  " & InvoArray(P_row, 25) & "  " & InvoArray(P_row, 26), Font, InvoBrush, HardX1 + 506, CurrentY) 'Ship to city, state, zipcode

                'Print purchase order number
                CurrentY = HardY1 + 368
                Text = InvoArray(P_row, 2)
                TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 40 + (172 - TextLen) / 2, CurrentY)

                'Print invoice date
                If InvoArray(p_row, 11) = Now.Date Then Text = Now.Date Else Text = InvoArray(p_row, 11)
                TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 212 + (125 - TextLen) / 2, CurrentY)

                'Print date shipped
                Text = InvoArray(p_row, 11)
                TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 337 + (125 - TextLen) / 2, CurrentY)

                'Print shipped via
                Text = InvoArray(p_row, 12)
                TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 462 + (134 - TextLen) / 2, CurrentY)

                'Print terms
                Text = Terms
                TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 596 + (124 - TextLen) / 2, CurrentY)

                'Print discount
                If SelectForm = 1 Then If InvoArray(p_row, 16) = True Then e.Graphics.DrawString("Yes", Font, InvoBrush, HardX1 + 727, CurrentY)

                'Print lower form data
                CurrentY = HardY1 + 453 '4th line + 30
                Dim SubTotal As Single = 0
                Dim Freight As Single = 0
                Dim Retract As Integer = 0
                For intstep = 1 To 3

                    'Print item number
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(intstep, Font).Width)
                    e.Graphics.DrawString(intstep, Font, InvoBrush, HardX1 + (50 - TextLen) / 2, CurrentY)

                    'Print purchase order line item number
                    Text = InvoArray(p_row, 3)
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(intstep, Font).Width)
                    e.Graphics.DrawString(intstep, Font, InvoBrush, HardX1 + 50 + (50 - TextLen) / 2, CurrentY)

                    'Print Qty ordered
                    Text = InvoArray(p_row, 6)
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                    e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 100 + (70 - TextLen) / 2, CurrentY)

                    'Print Qty shipped
                    Text = InvoArray(p_row, 10)
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                    e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 170 + (70 - TextLen) / 2, CurrentY)

                    'Print description line 1
                    Text = InvoArray(p_row, 19)
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                    e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 240 + (350 - TextLen) / 2, CurrentY)

                    'Print description line 2
                    Text = InvoArray(p_row, 20)
                    If Text <> "" Then
                        CurrentY = CurrentY + Font.Height + 3
                        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                        e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 240 + (350 - TextLen) / 2, CurrentY)
                    End If

                    'Print description line 3
                    Text = InvoArray(p_row, 21)
                    If Text <> "" Then
                        CurrentY = CurrentY + Font.Height + 3
                        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                        e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 240 + (350 - TextLen) / 2, CurrentY)
                    End If

                    'Print Material heat with lot id
                    If InvoArray(p_row, 17) <> "" Then
                        Text = "Material Heat = " & InvoArray(p_row, 17) & "   " & "Lot Id = " & InvoArray(p_row, 18)
                        CurrentY = CurrentY + Font.Height + 3
                        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                        e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 240 + (350 - TextLen) / 2, CurrentY)
                    End If

                    If SelectForm = 1 Then
                        'Print unit price
                        Text = InvoArray(p_row, 8)
                        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                        e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 590 + (100 - TextLen) / 2, CurrentY)

                        'Print extended price
                        Text = InvoArray(p_row, 9)
                        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                        e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 690 + (110 - TextLen) / 2, CurrentY)

                        'Calculate running totals
                        SubTotal = SubTotal + InvoArray(p_row, 9)
                        If InvoArray(p_row, 13) <> "" Then Freight = Freight + InvoArray(p_row, 13)

                    End If
                    If p_row = PurOrderCount Then p_row = p_row - Retract : Exit For
                    If InvoArray(p_row + 1, 0) = InvoArray(p_row, 0) Then p_row = p_row + 1 : Retract = Retract + 1 Else p_row = p_row - Retract : Exit For
                    CurrentY = CurrentY + 45
                Next

                If SelectForm = 1 Then
                    'Print sale amount
                    Text = FormatCurrency(SubTotal)
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                    e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 690 + (110 - TextLen) / 2, HardY1 + 919)

                    'Print freight
                    Text = FormatCurrency(Freight)
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                    e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 690 + (110 - TextLen) / 2, HardY1 + 982)

                    'Print total
                    Text = FormatCurrency(SubTotal + Freight)
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                    e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 690 + (110 - TextLen) / 2, HardY1 + 1024)

                    If InvoArray(p_row, 16) = True Then
                        Text = Discount_Amount & "% Discount if paid within " & Discount_Days & " days"
                        e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 150, HardY1 + 975)
                    End If
                End If

            Case 3
                'Create rectangle for border
                border = New Rectangle(HardX1, HardY1, HardWidth, HardHeight)
                e.Graphics.DrawRectangle(blackPen, border)

                'Print label date
                Font = New Font("Arial", 12, FontStyle.Bold)
                e.Graphics.DrawString("Date:", Font, InvoBrush, HardX1 + 640, HardY1 + 20)

                'Print labels Certificate of compliance
                Text = "Certificate of Compliance"
                Font = New Font("Arial", 18, FontStyle.Bold)
                TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                e.Graphics.DrawString(Text, Font, InvoBrush, (HardWidth - TextLen) / 2, HardY1 + 250)

                'Print line under Certificate of compliance
                Text = "***************************************************"
                Font = New Font("Arial", 12, FontStyle.Bold)
                e.Graphics.DrawString(Text, Font, InvoBrush, 232, HardY1 + 277)
                e.Graphics.DrawString("To:", Font, InvoBrush, HardX1 + 60, HardY1 + 305) 'Print label to:
                e.Graphics.DrawString("Attn:", Font, InvoBrush, HardX1 + 60, HardY1 + 340) 'Print label attn:
                e.Graphics.DrawString("Subject:  Invoice Number:", Font, InvoBrush, HardX1 + 60, HardY1 + 375) 'Print label subject Invoice no
                e.Graphics.DrawString("Purchase Order No:", Font, InvoBrush, HardX1 + 134, HardY1 + 397) 'Print label purchase order number

                e.Graphics.DrawString("Drawing Number:", Font, InvoBrush, HardX1 + 134, HardY1 + 419) 'Print label drawing number
                e.Graphics.DrawString("Quantity Shipped:", Font, InvoBrush, HardX1 + 134, HardY1 + 441) 'Print label quantity shipped
                e.Graphics.DrawString("Drawing Rev:", Font, InvoBrush, HardX1 + 134, HardY1 + 463) 'Print label drawing rev
                e.Graphics.DrawString("Description:", Font, InvoBrush, HardX1 + 134, HardY1 + 485) 'Print label description

                'Fill form with data
                If (System.IO.File.Exists(InvImage)) Then 'Draw Logo image
                    Dim oInvImage As Bitmap = New Bitmap(InvImage)
                    e.Graphics.DrawImage(oInvImage, HardX1 + 30, HardY1 + 25)
                End If

                'Print Company data under logo
                CurrentX = HardX1 + 233 : CurrentY = HardY1 + 123
                Font = New Font("Microsoft Sans Serif", 12, FontStyle.Regular)
                e.Graphics.DrawString(Company_Address, Font, InvoBrush, CurrentX, CurrentY) 'Print company address
                CurrentY = CurrentY + Font.Height
                e.Graphics.DrawString(Company_City & "  " & Company_State & "  " & Company_ZipCode, Font, InvoBrush, CurrentX, CurrentY) 'Print company city, state, zipcode
                Font = New Font("Ariel", 10, FontStyle.Regular)
                CurrentY = CurrentY + Font.Height + 4
                e.Graphics.DrawString(Company_Phone, Font, InvoBrush, CurrentX + 27, CurrentY) 'Print company phone

                'Print data
                Font = New Font("Arial", 12, FontStyle.Regular)
                If InvoArray(p_row, 11) = Now.Date Then Text = Now.Date Else Text = InvoArray(p_row, 11)
                e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 687, HardY1 + 20)
                e.Graphics.DrawString(InvoArray(p_row, 1), Font, InvoBrush, HardX1 + 92, HardY1 + 305) 'Print company name
                e.Graphics.DrawString("Incomming Inspection", Font, InvoBrush, HardX1 + 103, HardY1 + 340) 'Print data incoming inspection
                e.Graphics.DrawString(InvoArray(p_row, 32), Font, InvoBrush, HardX1 + 268, HardY1 + 375) 'Print data invoice number
                e.Graphics.DrawString(InvoArray(p_row, 2), Font, InvoBrush, HardX1 + 296, HardY1 + 397) 'Print data purchase order number

                'Test if there are multiple items on this invoice
                If InvoArray(p_row + 1, 0) = InvoArray(p_row, 0) Then booMulti = True
                CurrentX1 = HardX1 + 280 : CurrentX2 = HardX1 + 282 : CurrentX3 = HardX1 + 246 : CurrentY = HardY1 + 485
                For intstep = 1 To 3

                    'Print data drawing number
                    If intstep = 1 Then Text = InvoArray(p_row, 4) Else Text = " , " & InvoArray(p_row, 4)
                    e.Graphics.DrawString(Text, Font, InvoBrush, CurrentX1, HardY1 + 419)
                    CurrentX1 = CurrentX1 + Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width) - 9

                    'Print data quantity shipped
                    If intstep = 1 Then Text = InvoArray(p_row, 10) Else Text = " , " & InvoArray(p_row, 10)
                    e.Graphics.DrawString(Text, Font, InvoBrush, CurrentX2, HardY1 + 441)
                    CurrentX2 = CurrentX2 + Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width) - 9

                    'Print data drawing rev
                    If intstep = 1 Then Text = InvoArray(p_row, 5) Else Text = " , " & InvoArray(p_row, 5)
                    e.Graphics.DrawString(Text, Font, InvoBrush, CurrentX3, HardY1 + 463)
                    CurrentX3 = CurrentX3 + Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width) - 9

                    'Print description line 1
                    If booMulti = True Then Text = "Item (" & intstep & ") :  " & InvoArray(p_row, 19) Else Text = InvoArray(p_row, 19)
                    e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 237, CurrentY)
                    If booMulti = True Then CurrentX = HardX1 + 309 Else CurrentX = HardX1 + 237

                    'Print description line 2
                    Text = InvoArray(p_row, 20)
                    If Text <> "" Then
                        CurrentY = CurrentY + Font.Height + 3
                        e.Graphics.DrawString(Text, Font, InvoBrush, CurrentX, CurrentY)
                    End If

                    'Print description line 3
                    Text = InvoArray(p_row, 21)
                    If Text <> "" Then
                        CurrentY = CurrentY + Font.Height + 3
                        e.Graphics.DrawString(Text, Font, InvoBrush, CurrentX, CurrentY)
                    End If

                    'Print Material heat with lot id
                    If InvoArray(p_row, 17) <> "" Then
                        Text = "Material Heat = " & InvoArray(p_row, 17) & "   " & "Lot Id = " & InvoArray(p_row, 18)
                        CurrentY = CurrentY + Font.Height + 3
                        e.Graphics.DrawString(Text, Font, InvoBrush, CurrentX, CurrentY)
                    End If

                    If p_row = PurOrderCount Then Exit For
                    If InvoArray(p_row + 1, 0) = InvoArray(p_row, 0) Then p_row = p_row + 1 Else Exit For
                    CurrentY = CurrentY + 30
                Next

                'Print Certificate of compliance statement
                CurrentY = CurrentY + 40
                Font = New Font("Arial", 12, FontStyle.Bold)
                Text = "We hereby certify that the above mentioned parts and quantities are"
                e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 145, CurrentY)
                Text = "in conformance with the specifications and requirements called for on the"
                CurrentY = CurrentY + Font.Height + 3
                e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 102, CurrentY)
                Text = "drawing pertaining to the subject order."
                CurrentY = CurrentY + Font.Height + 3
                e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 102, CurrentY)

                'Print Signature statement
                CurrentY = CurrentY + 60
                e.Graphics.DrawString("Very truly yours,", Font, InvoBrush, HardX1 + 490, CurrentY)
                CurrentY = CurrentY + 60
                e.Graphics.DrawString(Agent1, Font, InvoBrush, HardX1 + 490, CurrentY)
                CurrentY = CurrentY + Font.Height + 3
                e.Graphics.DrawString("Quality Control Manager", Font, InvoBrush, HardX1 + 490, CurrentY)
                SelectForm = 0 'Last form ( Certificate ) printed, reset to print invoice on next page
                p_row = p_row + 1 'Last form printed,advance to next purchase order item
        End Select

        SelectForm = SelectForm + 1
        PageNumber += 1
        e.HasMorePages = PageNumber <= InvoiceCount * 3 'Three different form per each invoiced item ( Invoice,Packing Slip,Certification )

    End Sub


    'All command actions ( Edit,Restore,Exit,Invoice/Print,Next )
    Private Sub cmd_Actions_Click(sender As Object, e As EventArgs) Handles cmd_Exit.Click, cmd_1.Click, cmd_2.Click
        If Cursor.Current = Cursors.WaitCursor Then Exit Sub

        'Hide mouse messages
        lbl_Message1.Text = ""

        Cursor.Current = Cursors.WaitCursor
        Select Case sender.text

            Case Is = "Edit"
                'Enable form for editing
                For intStep = 0 To PurOrderCount - 1
                    tbox_QtyShip(intStep).Enabled = True
                    tbox_ShipDate(intStep).Enabled = True
                    tbox_ShipVia(intStep).Enabled = True
                    tbox_Freight(intStep).Enabled = True
                    tbox_MaterialHeat(intStep).Enabled = True
                    cbx_Discount(intStep).Enabled = True
                Next
                cmd_2.Text = "Restore"
                cmd_2.Left = 96
                cmd_2.Visible = True
                cmd_2.Enabled = False
                cmd_Exit.Left = 177

            Case Is = "Exit"
                Cursor.Current = Cursors.Default
                Me.Close()
                Exit Sub

            Case Is = "Invoice"

                'Check selected records for missing data
                For intStep = 0 To PurOrderCount - 1
                    If tbox_QtyShip(intStep).Text = "" Then
                        frm_Message.Text = "7:1:0:1:3:Quantity Shipped must be entered to proceed with invoicing"
                        frm_Message.ShowDialog()
                        tbox_QtyShip(intStep).Focus()
                        Exit Sub
                    End If
                    If tbox_ShipDate(intStep).Text = "  /  /" Then
                        frm_Message.Text = "7:1:0:1:3:A valid shipping date must be entered to proceed with invoicing"
                        frm_Message.ShowDialog()
                        tbox_ShipDate(intStep).Focus()
                        Exit Sub
                    End If
                Next

                'Update Invoice array with any edited changes and check selected purchase orders for certification restrictions
                Dim PassCount As Integer = 0
                Dim booPass As Boolean = True
                For intStep = 0 To PurOrderCount - 1
                    InvoArray(intStep, 10) = tbox_QtyShip(intStep).Text
                    InvoArray(intStep, 13) = tbox_Freight(intStep).Text
                    InvoArray(intStep, 11) = tbox_ShipDate(intStep).Text
                    InvoArray(intStep, 12) = tbox_ShipVia(intStep).Text
                    InvoArray(intStep, 17) = tbox_MaterialHeat(intStep).Text

                    If cbx_Certification(intStep).Checked = True And tbox_MaterialHeat(intStep).Text = "" Then
                        tbox_MaterialHeat(intStep).BackColor = Color.Aqua 'Highlight problem records
                        PassCount = PassCount + 1
                        booPass = False
                    End If
                Next

                'Set up print option dialog or error messages
                If booPass = False Then 'Material certs missing
                    If PassCount = PurOrderCount Then 'All records missing material certs
                        frm_Message.Text = "7:1:0:1:3:Certification restriction will not allow the highlighted records to be invoiced"
                        frm_Message.ShowDialog()
                    Else 'Only some records missing material certs
                        frm_Message.Text = "7:2:0:5:3:Press Yes to proceed with invoicing of all other records?"
                        frm_Message.ShowDialog()
                    End If
                    For intStep = 0 To PurOrderCount - 1 'Remove all highlighted records
                        tbox_MaterialHeat(intStep).BackColor = Color.White
                    Next
                    If PassCount = PurOrderCount Then Exit Sub
                    If MessageResult = True Then frm_Message.Text = "7:8:0:32:3:Load paper in printer and press OK when ready" : frm_Message.ShowDialog()
                Else
                    frm_Message.Text = "7:8:0:32:3:Load paper in printer and press OK when ready" : frm_Message.ShowDialog()
                End If

                PageNumber = 1
                If MessageResult = True Then 'Ok
                    PrintForms = New PrintDocument
                    PrintForms.PrinterSettings.PrinterName = SystemPrinter
                    PrintForms.Print()
                Else : Exit Sub : End If

                'Check for correct printing
                frm_Message.Text = "7:2:0:7:3:Press Yes to save purchase orders as invoiced, No to print again"
                frm_Message.ShowDialog()
                If MessageResult = True Then Call Datasave()

            Case Is = "Next"
                'Test for no selections
                Dim booPass As Boolean = False
                For intStep = 0 To RecordCount - 1
                    If tbox_Selector(intStep).Text <> "" And tbox_Selector(intStep).Text <> "0" Then booPass = True : Exit For
                Next
                If booPass = False Then
                    Cursor.Current = Cursors.Default
                    frm_Message.Text = "7:1:0:1:3:Selections must be made before continuing"
                    frm_Message.ShowDialog()
                    Exit Sub
                End If

                'Show and preselect inspection agent only if secondary inspection agent is present
                If Agent2 <> "" Then
                    opt_Agent1.Visible = True : opt_Agent2.Visible = True
                    opt_Agent1.Checked = True
                End If

                'Clear freight warning message indicators for new session
                For intStep = 0 To 9
                    FreightMessageArray(intStep) = Nothing
                Next

                'Count selected items and record numbers used for selection ( Records list of all numbers used )
                Dim NumberHold(RecordCount), Hold As Integer
                Dim booMatch As Boolean
                InvoiceCount = 0
                PurOrderCount = 0
                For intStep = 0 To RecordCount - 1
                    If tbox_Selector(intStep).Text <> "" Then
                        PurOrderCount = PurOrderCount + 1
                        If InvoiceCount = 0 Then 'First number found
                            NumberHold(InvoiceCount) = tbox_Selector(intStep).Text
                            InvoiceCount = InvoiceCount + 1
                        Else 'Test if new number is a match of a previous found number
                            booMatch = False
                            For i = 0 To InvoiceCount
                                If tbox_Selector(intStep).Text = NumberHold(i) Then booMatch = True
                            Next
                            If booMatch = False Then 'New number found
                                NumberHold(InvoiceCount) = tbox_Selector(intStep).Text
                                InvoiceCount = InvoiceCount + 1
                            End If
                        End If
                    End If
                Next

                Do 'Arrange stored number in numerical order
                    booPass = True
                    For intStep = 0 To InvoiceCount - 1
                        If intStep < InvoiceCount - 1 Then
                            If NumberHold(intStep) > NumberHold(intStep + 1) Then
                                Hold = NumberHold(intStep + 1)
                                NumberHold(intStep + 1) = NumberHold(intStep)
                                NumberHold(intStep) = Hold
                                booPass = False
                            End If
                        End If
                        If intStep = InvoiceCount - 1 And booPass = True Then Exit Do
                    Next
                Loop

                'Fill array with adjusted selected data ( Numerical Order )
                Dim count, row, ReNum As Integer
                row = 0 : ReNum = 0
                ReDim InvoArray(PurOrderCount, 33)
                For intStep1 = 0 To InvoiceCount - 1 'Step thru all numbers in NumberHold array
                    count = 0
                    ReNum = ReNum + 1
                    For intStep2 = 0 To RecordCount - 1 'Step thru all purchase orders
                        If tbox_Selector(intStep2).Text <> "" Then
                            If tbox_Selector(intStep2).Text = NumberHold(intStep1) Then
                                InvoArray(row, 0) = ReNum
                                InvoArray(row, 1) = lbl_Company(intStep2).Text
                                InvoArray(row, 2) = lbl_PurchaseOrder(intStep2).Text
                                InvoArray(row, 3) = lbl_POItem(intStep2).Text
                                InvoArray(row, 4) = lbl_DrawNumber(intStep2).Text
                                InvoArray(row, 5) = lbl_DrawRev(intStep2).Text
                                InvoArray(row, 6) = lbl_QtyOrder(intStep2).Text
                                InvoArray(row, 7) = lbl_DueDate(intStep2).Text
                                InvoArray(row, 8) = lbl_Price(intStep2).Text
                                InvoArray(row, 9) = lbl_TotalPrice(intStep2).Text
                                InvoArray(row, 10) = tbox_QtyShip(intStep2).Text
                                InvoArray(row, 11) = tbox_ShipDate(intStep2).Text
                                If tbox_ShipVia(intStep2).Text <> "" Then InvoArray(row, 12) = tbox_ShipVia(intStep2).Text Else InvoArray(row, 12) = ShipVia
                                If cbx_Freight(intStep2).Checked = True Then InvoArray(row, 14) = True Else InvoArray(row, 14) = False
                                If cbx_Certification(intStep2).Checked = True Then InvoArray(row, 15) = True Else InvoArray(row, 15) = False
                                'If cbx_Discount(intStep2).Checked = True Then InvoArray(row, 16) = True Else InvoArray(row, 16) = False
                                InvoArray(row, 17) = tbox_MaterialHeat(intStep2).Text
                                InvoArray(row, 18) = lbl_ID(intStep2).Text

                                'Retreive description data for selected items
                                strSQL = "SELECT DescripA,DescripB,DescripC FROM Invoice Where ID = " & lbl_ID(intStep2).Text & ";"
                                dbDataSet_Misc.Clear()
                                dbDataSet_Misc.Tables.Clear()
                                gbl_DstConnect.Open()
                                dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
                                dbAdapter_Misc.Fill(dbDataSet_Misc, "Descrip")
                                gbl_DstConnect.Close()
                                If dbDataSet_Misc.Tables("Descrip").Rows.Count > 0 Then

                                    If Not IsDBNull(dbDataSet_Misc.Tables("Descrip").Rows(0).Item(0)) Then 'DescripA
                                        InvoArray(row, 19) = Trim(dbDataSet_Misc.Tables("Descrip").Rows(0).Item(0))
                                    Else : InvoArray(row, 19) = "" : End If

                                    If Not IsDBNull(dbDataSet_Misc.Tables("Descrip").Rows(0).Item(1)) Then 'DescripB
                                        InvoArray(row, 20) = Trim(dbDataSet_Misc.Tables("Descrip").Rows(0).Item(1))
                                    Else : InvoArray(row, 20) = "" : End If

                                    If Not IsDBNull(dbDataSet_Misc.Tables("Descrip").Rows(0).Item(2)) Then 'DescripC
                                        InvoArray(row, 21) = Trim(dbDataSet_Misc.Tables("Descrip").Rows(0).Item(2))
                                    Else : InvoArray(row, 21) = "" : End If

                                End If

                                InvoArray(row, 22) = lbl_CustCode(intStep2).Text
                                If count = 0 Then 'Retreive billing and shiping data only for once for each new invoice
                                    strSQL = "SELECT Address,City,State,ZipCode,BCompany,BAddress,BCity,BState,BZipCode " _
                                             & "FROM Customers Where CustCode = " & lbl_CustCode(intStep2).Text & ";"
                                    dbDataSet_Misc.Clear()
                                    dbDataSet_Misc.Tables.Clear()
                                    gbl_DstConnect.Open()
                                    dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
                                    dbAdapter_Misc.Fill(dbDataSet_Misc, "CompData")
                                    gbl_DstConnect.Close()
                                    If dbDataSet_Misc.Tables("CompData").Rows.Count > 0 Then

                                        If Not IsDBNull(dbDataSet_Misc.Tables("CompData").Rows(0).Item(0)) Then 'Address
                                            InvoArray(row, 23) = Trim(dbDataSet_Misc.Tables("CompData").Rows(0).Item(0))
                                        Else : InvoArray(row, 23) = "" : End If

                                        If Not IsDBNull(dbDataSet_Misc.Tables("CompData").Rows(0).Item(1)) Then 'City
                                            InvoArray(row, 24) = Trim(dbDataSet_Misc.Tables("CompData").Rows(0).Item(1))
                                        Else : InvoArray(row, 24) = "" : End If

                                        If Not IsDBNull(dbDataSet_Misc.Tables("CompData").Rows(0).Item(2)) Then 'State
                                            InvoArray(row, 25) = Trim(dbDataSet_Misc.Tables("CompData").Rows(0).Item(2))
                                        Else : InvoArray(row, 25) = "" : End If

                                        If Not IsDBNull(dbDataSet_Misc.Tables("CompData").Rows(0).Item(3)) Then 'Zipcode
                                            InvoArray(row, 26) = Trim(dbDataSet_Misc.Tables("CompData").Rows(0).Item(3))
                                        Else : InvoArray(row, 26) = "" : End If

                                        If Not IsDBNull(dbDataSet_Misc.Tables("CompData").Rows(0).Item(4)) Then 'Billing company
                                            InvoArray(row, 27) = Trim(dbDataSet_Misc.Tables("CompData").Rows(0).Item(4))
                                        Else : InvoArray(row, 27) = "" : End If

                                        If Not IsDBNull(dbDataSet_Misc.Tables("CompData").Rows(0).Item(5)) Then 'Billing Address
                                            InvoArray(row, 28) = Trim(dbDataSet_Misc.Tables("CompData").Rows(0).Item(5))
                                        Else : InvoArray(row, 28) = "" : End If

                                        If Not IsDBNull(dbDataSet_Misc.Tables("CompData").Rows(0).Item(6)) Then 'Billing City
                                            InvoArray(row, 29) = Trim(dbDataSet_Misc.Tables("CompData").Rows(0).Item(6))
                                        Else : InvoArray(row, 29) = "" : End If

                                        If Not IsDBNull(dbDataSet_Misc.Tables("CompData").Rows(0).Item(7)) Then 'Billing State
                                            InvoArray(row, 30) = Trim(dbDataSet_Misc.Tables("CompData").Rows(0).Item(7))
                                        Else : InvoArray(row, 30) = "" : End If

                                        If Not IsDBNull(dbDataSet_Misc.Tables("CompData").Rows(0).Item(8)) Then 'Billing zipcode
                                            InvoArray(row, 31) = Trim(dbDataSet_Misc.Tables("CompData").Rows(0).Item(8))
                                        Else : InvoArray(row, 31) = "" : End If

                                        LastInvoice = LastInvoice + 1
                                        InvoArray(row, 32) = LastInvoice

                                    End If
                                End If
                                InvoArray(row, 33) = count + 1 'Item number
                                row = row + 1
                                count = count + 1 : If count = 3 Then Exit For 'All records for selection number found
                            End If
                        End If
                    Next
                Next

                'Fill form wth adjusted data
                For intStep = 0 To PurOrderCount - 1
                    tbox_Selector(intStep).Text = InvoArray(intStep, 0)
                    tbox_Selector(intStep).Enabled = False
                    lbl_Company(intStep).Text = InvoArray(intStep, 1)
                    lbl_PurchaseOrder(intStep).Text = InvoArray(intStep, 2)
                    lbl_POItem(intStep).Text = InvoArray(intStep, 3)
                    lbl_DrawNumber(intStep).Text = InvoArray(intStep, 4)
                    lbl_DrawRev(intStep).Text = InvoArray(intStep, 5)
                    lbl_QtyOrder(intStep).Text = InvoArray(intStep, 6)
                    lbl_DueDate(intStep).Text = InvoArray(intStep, 7)
                    lbl_Price(intStep).Text = InvoArray(intStep, 8)
                    lbl_TotalPrice(intStep).Text = InvoArray(intStep, 9)
                    tbox_QtyShip(intStep).Text = InvoArray(intStep, 10)
                    tbox_ShipDate(intStep).Text = InvoArray(intStep, 11)
                    tbox_ShipVia(intStep).Text = InvoArray(intStep, 12)
                    If InvoArray(intStep, 14) = True Then cbx_Freight(intStep).Checked = True Else cbx_Freight(intStep).Checked = False
                    If InvoArray(intStep, 15) = True Then cbx_Certification(intStep).Checked = True Else cbx_Certification(intStep).Checked = False
                    tbox_MaterialHeat(intStep).Text = InvoArray(intStep, 17)
                    lbl_ID(intStep).Text = InvoArray(intStep, 18)
                    lbl_CustCode(intStep).Text = InvoArray(intStep, 22)
                Next

                'Hide all unused controls
                For intStep = PurOrderCount To RecordCount - 1
                    tbox_Selector(intStep).Visible = False
                    lbl_Company(intStep).Visible = False
                    lbl_PurchaseOrder(intStep).Visible = False
                    lbl_DrawNumber(intStep).Visible = False
                    lbl_DrawRev(intStep).Visible = False
                    lbl_QtyOrder(intStep).Visible = False
                    lbl_DueDate(intStep).Visible = False
                    lbl_Price(intStep).Visible = False
                    lbl_TotalPrice(intStep).Visible = False
                    tbox_QtyShip(intStep).Visible = False
                    tbox_ShipDate(intStep).Visible = False
                    tbox_ShipVia(intStep).Visible = False
                    tbox_Freight(intStep).Visible = False
                    cbx_Discount(intStep).Visible = False
                Next
                booFormView = False : Call FormChange()

            Case Is = "Restore"

                'Restored original data to form
                For intStep = 0 To PurOrderCount - 1
                    tbox_QtyShip(intStep).Text = InvoArray(intStep, 10)
                    tbox_ShipDate(intStep).Text = InvoArray(intStep, 11)
                    tbox_ShipVia(intStep).Text = InvoArray(intStep, 12)
                    tbox_Freight(intStep).Text = ""
                    tbox_MaterialHeat(intStep).Text = InvoArray(intStep, 17)
                    cbx_Discount(intStep).Checked = False
                Next
                cmd_2.Enabled = False
        End Select
        Cursor.Current = Cursors.Default
    End Sub


    'All control handlers
    Private Sub tbox_GotFocus(sender As Object, e As EventArgs)
        varInitialEntry = Trim(sender.Text)
        sender.BackColor = (Color.FromArgb(255, 255, 192))
        If sender.name = "tbox_MaterialHeat" Then sender.CharacterCasing = CharacterCasing.Upper
    End Sub
    Private Sub tbox_LostFocus(sender As Object, e As EventArgs)
        If sender.text = varInitialEntry Or booCorrection = True Then sender.BackColor = Color.White : Exit Sub

        Select Case sender.Name
            Case "tbox_Selector", "tbox_QtyShip", "tbox_Freight"
                If sender.Text <> "" Then
                    If Not IsNumeric(sender.Text) Then
                        booCorrection = True
                        frm_Message.Text = "7:1:0:1:3:Invalid Entry --- Numerical entries are only allowed"
                        frm_Message.ShowDialog()
                        sender.text = ""
                        sender.Focus()
                        booCorrection = False
                        Exit Sub
                    End If
                    If sender.name = "tbox_Selector" Then
                        Dim intCount As Integer = 0
                        For intStep = 0 To RecordCount - 1
                            If tbox_Selector(intStep).Text = sender.text Then
                                If intStep <> sender.tag And lbl_PurchaseOrder(sender.tag).Text <> lbl_PurchaseOrder(intStep).Text Then 'Purchase order mismatch
                                    booCorrection = True
                                    frm_Message.Text = "7:1:0:1:3:Same numbers must share the same Purchase Order number"
                                    frm_Message.ShowDialog()
                                    sender.text = ""
                                    sender.Focus()
                                    booCorrection = False
                                    Exit Sub
                                End If
                                intCount = intCount + 1
                            End If
                            If intCount > 3 Then 'No more then 3 items can be invoiced on the same form
                                booCorrection = True
                                frm_Message.Text = "7:1:0:1:3:No more then 3 items can be invoiced on a single form"
                                frm_Message.ShowDialog()
                                sender.text = ""
                                sender.Focus()
                                booCorrection = False
                                Exit Sub
                            End If
                        Next
                    End If
                    If sender.name = "tbox_Freight" Then tbox_Freight(sender.tag).Text = FormatCurrency(tbox_Freight(sender.tag).Text)
                End If
            Case "tbox_ShipDate"
                If IsDate(sender.Text) = False And sender.Text <> "  /  /" Then
                    sender.BackColor = Color.Aqua
                    booCorrection = True
                    frm_Message.Text = "7:1:0:1:3:The date entered is not valid, Please enter a valid date"
                    frm_Message.ShowDialog()
                    sender.text = "  /  /"
                    tbox_ShipDate(sender.tag).Focus()
                    tbox_ShipDate(sender.tag).SelectionStart = 0
                    booCorrection = False
                    Exit Sub
                End If
        End Select
        sender.BackColor = Color.White
    End Sub
    Private Sub tbox_TextChanged(sender As Object, e As EventArgs)
        If booDataChecked = True Then Exit Sub 'Skip if pre_processed data or freight message already been shown once
        If sender.name = "tbox_Freight" Then
            'Test if customer has special freight arrangements
            If InvoArray(sender.tag, 14) = True Then
                'Test for freight warning on the same customer
                For intstep = 0 To 9
                    If FreightMessageArray(intstep) = InvoArray(sender.tag, 22) Then cmd_1.Enabled = True : cmd_2.Enabled = True : Exit Sub
                Next
                'Show warning message and record customer for repeat changes on same customer
                For intstep = 0 To 9
                    If FreightMessageArray(intstep) = Nothing Then FreightMessageArray(intstep) = InvoArray(sender.tag, 22) : Exit For
                Next
                booDataChecked = True
                sender.text = ""
                frm_Message.Text = "7:1:0:6:3:This message will not appear again for this customer during this session"
                frm_Message.ShowDialog()
                booDataChecked = False
            End If
        End If
        cmd_1.Enabled = True
        cmd_2.Enabled = True
    End Sub
    Private Sub tbox_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Return) Then
            Select Case sender.name
                Case "tbox_Selector"
                    If VScrollBar1.Visible = False Then
                        If tbox_Selector(sender.tag + 1) Is Nothing Then tbox_Selector(0).Focus() Else tbox_Selector(sender.Tag + 1).Focus()
                    Else
                        If sender.tag < VScrollBar1.Maximum + 10 Then
                            tbox_Selector(sender.Tag + 1).Focus()
                            If tbox_Selector(sender.tag).Location.Y >= 487 Then
                                If VScrollBar1.Value <= VScrollBar1.Maximum - 10 Then
                                    VScrollBar1.Value = VScrollBar1.Value + 1
                                    fra_Information.Top = fra_Information.Top - 25
                                End If
                            End If
                        Else
                            fra_Information.Top = -2
                            VScrollBar1.Value = 0
                            tbox_Selector(0).Focus()
                        End If
                    End If
                Case "tbox_QtyShip"
                    If VScrollBar1.Visible = False Then
                        If sender.tag < PurOrderCount - 1 Then tbox_QtyShip(sender.Tag + 1).Focus() Else tbox_ShipDate(0).Focus()
                    Else
                        If sender.tag < VScrollBar1.Value Then tbox_QtyShip(VScrollBar1.Value).Focus()
                        If sender.tag >= VScrollBar1.Value And sender.tag < VScrollBar1.Value + 19 Then tbox_QtyShip(sender.Tag + 1).Focus() Else tbox_ShipDate(VScrollBar1.Value).Focus()
                    End If
                Case "tbox_ShipDate" : tbox_ShipVia(sender.Tag).Focus()
                    If VScrollBar1.Visible = False Then
                        If sender.tag < PurOrderCount - 1 Then tbox_ShipDate(sender.Tag + 1).Focus() Else tbox_ShipVia(0).Focus()
                    Else
                        If sender.tag < VScrollBar1.Value Then tbox_ShipDate(VScrollBar1.Value).Focus()
                        If sender.tag >= VScrollBar1.Value And sender.tag < VScrollBar1.Value + 19 Then tbox_ShipDate(sender.Tag + 1).Focus() Else tbox_ShipVia(VScrollBar1.Value).Focus()
                    End If
                Case "tbox_ShipVia"
                    If VScrollBar1.Visible = False Then
                        If sender.tag < PurOrderCount - 1 Then tbox_ShipVia(sender.Tag + 1).Focus() Else tbox_Freight(0).Focus()
                    Else
                        If sender.tag < VScrollBar1.Value Then tbox_ShipVia(VScrollBar1.Value).Focus()
                        If sender.tag >= VScrollBar1.Value And sender.tag < VScrollBar1.Value + 19 Then tbox_ShipVia(sender.Tag + 1).Focus() Else tbox_Freight(VScrollBar1.Value).Focus()
                    End If
                Case "tbox_Freight"
                    If VScrollBar1.Visible = False Then
                        If sender.tag < PurOrderCount - 1 Then tbox_Freight(sender.Tag + 1).Focus() Else tbox_MaterialHeat(0).Focus()
                    Else
                        If sender.tag < VScrollBar1.Value Then tbox_Freight(VScrollBar1.Value).Focus()
                        If sender.tag >= VScrollBar1.Value And sender.tag < VScrollBar1.Value + 19 Then tbox_Freight(sender.Tag + 1).Focus() Else tbox_MaterialHeat(VScrollBar1.Value).Focus()
                    End If
                Case "tbox_MaterialHeat"
                    If VScrollBar1.Visible = False Then
                        If sender.tag < PurOrderCount - 1 Then tbox_MaterialHeat(sender.Tag + 1).Focus() Else tbox_QtyShip(0).Focus()
                    Else
                        If sender.tag < VScrollBar1.Value Then tbox_MaterialHeat(VScrollBar1.Value).Focus()
                        If sender.tag >= VScrollBar1.Value And sender.tag < VScrollBar1.Value + 19 Then tbox_MaterialHeat(sender.Tag + 1).Focus() Else tbox_QtyShip(VScrollBar1.Value).Focus()
                    End If
            End Select
        End If
    End Sub
    Private Sub cbx_Discount_Click(sender As Object, e As EventArgs)
        If booCorrection = True Then Exit Sub
        booCorrection = True
        Dim booStatus As Boolean
        If sender.Checked = True Then booStatus = True Else booStatus = False
        For intStep = 0 To PurOrderCount - 1
            If InvoArray(intStep, 0) = InvoArray(sender.tag, 0) Then
                cbx_Discount(intStep).Checked = booStatus
                InvoArray(intStep, 16) = booStatus
            End If
        Next
        booCorrection = False
    End Sub
    Private Sub opt_Agent_CheckedChanged(sender As Object, e As EventArgs) Handles opt_Agent1.CheckedChanged, opt_Agent2.CheckedChanged
        If opt_Agent1.Checked = True Then Agent = Agent1 Else Agent = Agent2

    End Sub


    'All mouse movement and mouse over messages
    Private Sub tbox_MouseClick(sender As Object, e As MouseEventArgs)
        If sender.text = "  /  /" Then sender.SelectionStart = 0
    End Sub
    Private Sub fra_MouseMove() Handles fra_Commands.MouseMove, fra_Invoice.MouseMove, fra_Information.MouseMove 'Clear message
        intMessage = 0
        Call MouseMessages()
    End Sub
    Private Sub All_MouseHover(sender As Object, e As EventArgs) Handles cmd_1.MouseHover, cmd_2.MouseHover, VScrollBar1.MouseHover, opt_Agent1.MouseHover, opt_Agent2.MouseHover
        Select Case sender.name
            Case "tbox_Selector" : intMessage = 1
            Case "VScrollBar1" : intMessage = 2
            Case "cmd_1"
                If sender.text = "Next" Then intMessage = 3
                If sender.text = "Invoice" Then intMessage = 4
            Case "cmd_2"
                If sender.text = "Edit" Then intMessage = 5
                If sender.text = "Restore" Then intMessage = 6
            Case "opt_Agent1" : intMessage = 7
            Case "opt_Agent2" : intMessage = 8
            Case "cbx_Discount" : intMessage = 9
        End Select
        Call MouseMessages()
    End Sub
    Private Sub MouseMessages()

        'Messages locations & visibility

        If booFormView = True Then 'Short form
            If intMessage = 1 Then
                lbl_Message1.SetBounds(185, 16, 663, 14)
                lbl_Message2.SetBounds(185, 33, 663, 14)
                lbl_Message2.Visible = True
            Else
                lbl_Message1.SetBounds(185, 24, 663, 14)
                lbl_Message2.Visible = False
            End If
        End If

        'Messages
        Select Case intMessage
            Case 0 : lbl_Message1.Text = "" : lbl_Message2.Text = "" 'Clear messages from screen
            Case 1 : lbl_Message1.Text = "Enter numbers corresponding to the order that you want the items to be invoiced"
                lbl_Message2.Text = "The same number can be entered up to 3 times, to invoice items on the same invoice that share a common purchase order number"
            Case 2 : lbl_Message1.Text = "All purchase orders not shown. Scroll down to view all items"
            Case 3 : lbl_Message1.Text = "Press [ Next ] after all items to be invoiced have been selected"
            Case 4 : lbl_Message1.Text = "Press [ Invoice ] after all edits and selections have been completed"
            Case 5 : lbl_Message1.Text = "Press [ Edit ] to make changes to the existing data"
            Case 6 : lbl_Message1.Text = "Press [ Restore ] to remove all changes made while editing data"
            Case 7 : lbl_Message1.Text = "Select primary agent if the primary agent will sign the Certificate Of Compliance"
            Case 8 : lbl_Message1.Text = "Select secondary agent if the secondary agent will sign the Certificate Of Compliance"
            Case 9 : lbl_Message1.Text = "Check discount if a discount is to be offered for this purchase order"
        End Select
    End Sub
End Class