Imports System.Drawing.Printing
Public Class frm_InvoiceSearch

    'Database related
    Dim dbAdapter, dbAdapter_SystemData As OleDb.OleDbDataAdapter
    Dim dbDataSet, dbDataSet_SystemData As New DataSet
    Dim strSQL As String

    'Form controls related
    Dim opt_Search(6) As RadioButton
    Dim lbl_ItemNum(3) As Label
    Dim lbl_POItem(3) As Label
    Dim lbl_DrawNum(3) As Label
    Dim lbl_DrawRev(3) As Label
    Dim lbl_ExtendedPrice(3) As Label
    Dim lbl_QtyOrdered(3) As Label
    Dim lbl_QtyShipped(3) As Label
    Dim lbl_DescripA(3) As Label
    Dim lbl_DescripB(3) As Label
    Dim lbl_DescripC(3) As Label
    Dim lbl_MaterialHeat(3) As Label
    Dim lbl_Price(3) As Label

    'Data related
    Dim booCorrection, booInvoice As Boolean 'BooInvoice = true ( form set to invoice ),BooInvoice = false ( form set to purchase order )
    Dim ShipVia, Agent, Terms As String
    Dim DiscountAmt, Freight, SubTotal As Single
    Dim DiscountDays, RecordCount, intMessage As Integer

    'Print report Related
    Private WithEvents PrintForms As PrintDocument
    Declare Function GetDeviceCaps% Lib "GDI32" (ByVal hDC%, ByVal nIndex%)
    Private SystemPrinter, Image_Path, InvImage As String
    Private PageNumber, Buffer As Integer
    Private InvoBrush As New SolidBrush(Color.Black)
    Private FillBrush As New SolidBrush(Color.Lavender)

    'All form related events
    Private Sub frm_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated
        Call AddControls()
        Call FormValues()
    End Sub
    Private Sub frm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.Location = New Point((Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2, frm_Main.Top + 65)
        tbox_SearchMasked.SetBounds(40, 63, 72, 20)
        opt_Search(0).Checked = True
        tbox_Search.Focus()
    End Sub
    Private Sub Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        dbDataSet.Clear()
        dbDataSet.Tables.Clear()
        dbDataSet_SystemData.Clear()
        dbDataSet_SystemData.Tables.Clear()
        Me.Dispose()
    End Sub
    Private Sub AddControls() 'Add date and quantity controls

        Dim int_Top As Integer
        Dim i As Integer

        'Create array of radio buttons in frame search criteria
        int_Top = 63
        For i = 0 To 6
            opt_Search(i) = New RadioButton
            With opt_Search(i)
                .Name = "opt_Search"
                Select Case i
                    Case 0 : .Text = "Invoice Number"
                    Case 1 : .Text = "Purchase Order"
                    Case 2 : .Text = "Drawing No."
                    Case 3 : .Text = "Material Heat"
                    Case 4 : .Text = "Lot Id"
                    Case 5 : .Text = "Invoice Date"
                    Case 6 : .Text = "Ship Date"
                End Select
                .Tag = i
                .Font = New Font("Microsoft Sans Serif", 8, FontStyle.Regular)
                .TextAlign = ContentAlignment.MiddleLeft
                .BackColor = Color.PapayaWhip
                .ForeColor = Color.Green
                .Visible = True
                .SetBounds(32, int_Top + 23, 100, 17)
                fra_SearchCriteria.Controls.Add(opt_Search(i))
                AddHandler .CheckedChanged, AddressOf opt_CheckedChanged
            End With
            int_Top = int_Top + 23
        Next

        'Create array of controls in frame information
        int_Top = 377 '427
        For i = 0 To 2
            int_Top = int_Top + 18
            lbl_ItemNum(i) = New Label
            lbl_POItem(i) = New Label
            lbl_DrawNum(i) = New Label
            lbl_DrawRev(i) = New Label
            lbl_ExtendedPrice(i) = New Label
            lbl_QtyOrdered(i) = New Label
            lbl_QtyShipped(i) = New Label
            lbl_DescripA(i) = New Label
            lbl_DescripB(i) = New Label
            lbl_DescripC(i) = New Label
            lbl_MaterialHeat(i) = New Label
            lbl_Price(i) = New Label

            With lbl_ItemNum(i)
                .Name = "lbl_ItemNum"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(21, int_Top, 32, 14)
                fra_InvoiceDisplay.Controls.Add(lbl_ItemNum(i))
            End With

            With lbl_POItem(i)
                .Name = "lbl_POItem"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(64, int_Top, 32, 14)
                fra_InvoiceDisplay.Controls.Add(lbl_POItem(i))
            End With

            With lbl_DrawNum(i)
                .Name = "lbl_DrawNum"
                .Tag = i             
                .Visible = False
                fra_InvoiceDisplay.Controls.Add(lbl_DrawNum(i))
            End With

            With lbl_DrawRev(i)
                .Name = "lbl_DrawRev"
                .Tag = i
                .Visible = False
                fra_InvoiceDisplay.Controls.Add(lbl_DrawRev(i))
            End With

            With lbl_QtyOrdered(i)
                .Name = "lbl_QtyOrdered"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(107, int_Top, 54, 14)
                fra_InvoiceDisplay.Controls.Add(lbl_QtyOrdered(i))
            End With

            With lbl_QtyShipped(i)
                .Name = "lbl_QtyShipped"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(172, int_Top, 54, 14)
                fra_InvoiceDisplay.Controls.Add(lbl_QtyShipped(i))
            End With

            With lbl_DescripA(i)
                .Name = "lbl_DescripA"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(237, int_Top, 320, 14)
                fra_InvoiceDisplay.Controls.Add(lbl_DescripA(i))
            End With

            int_Top = int_Top + 18
            With lbl_DescripB(i)
                .Name = "lbl_DescripB"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(237, int_Top, 320, 14)
                fra_InvoiceDisplay.Controls.Add(lbl_DescripB(i))
            End With

            int_Top = int_Top + 18
            With lbl_DescripC(i)
                .Name = "lbl_DescripC"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(237, int_Top, 320, 14)
                fra_InvoiceDisplay.Controls.Add(lbl_DescripC(i))
            End With

            int_Top = int_Top + 18
            With lbl_MaterialHeat(i)
                .Name = "lbl_MaterialHeat"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .Text = "Material Heat ="
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = False
                .SetBounds(233, int_Top, 320, 14)
                fra_InvoiceDisplay.Controls.Add(lbl_MaterialHeat(i))
            End With

            With lbl_Price(i)
                .Name = "lbl_Price"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(568, int_Top, 90, 14)
                fra_InvoiceDisplay.Controls.Add(lbl_Price(i))
            End With

            With lbl_ExtendedPrice(i)
                .Name = "lbl_ExtendedPrice"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(669, int_Top, 94, 14)
                fra_InvoiceDisplay.Controls.Add(lbl_ExtendedPrice(i))
            End With

        Next
    End Sub
    Private Sub FormValues()

        'Titles and Image of invoice:
        image_Path = Microsoft.VisualBasic.Left(Application.StartupPath, Len(Application.StartupPath) - 9) & "\Images\"
        InvImage = image_Path + "GammaLogo.png"

        If (System.IO.File.Exists(InvImage)) Then 'Draw Logo image
            PictureBox1.Image = Image.FromFile(InvImage)
        End If

        'Retrieve system values
        strSQL = "SELECT CompanyAddress,CompanyCity,CompanyState,CompanyZipCode,CompanyPhone,Terms,ShipVia,Agent1,SystemPrinter,Buffer FROM System;"
        dbDataSet_SystemData.Clear()
        dbDataSet_SystemData.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter_SystemData = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter_SystemData.Fill(dbDataSet_SystemData, "SystemData")
        gbl_DstConnect.Close()

        Dim Comp_City, Comp_State, Comp_ZipCode As String
        lbl_CompanyAddress.Text = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(0) 'Company Address
        Comp_City = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(1) 'Company City
        Comp_State = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(2) 'Company State
        Comp_ZipCode = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(3) 'Company ZipCode
        lbl_CompanyCity.Text = Comp_City & "  " & Comp_State & "  " & Comp_ZipCode
        lbl_CompanyPhone.Text = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(4) 'Company Phone
        Terms = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(5) 'Payment terms
        ShipVia = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(6) 'Ship Via
        Agent = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(7) 'Primary inspection agent
        SystemPrinter = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(8) 'System printer name
        Buffer = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(9) 'Printer buffer
    End Sub
    Private Sub ClearData()
        lbl_InvoiceNumber.Text = ""
        lbl_SoldToName.Text = ""
        lbl_SoldToAddress.Text = ""
        lbl_SoldToState.Text = ""
        lbl_ShipToName.Text = ""
        lbl_ShiptoAddress.Text = ""
        lbl_ShipToState.Text = ""
        lbl_PurchaseOrder.Text = ""
        lbl_InvoiceDate.Text = ""
        lbl_DateShipped.Text = ""
        lbl_ShipVia.Text = ""
        lbl_Terms.Text = ""
        lbl_Discount.Text = ""
        lbl_DiscountMessage.Visible = False

        For intStep = 0 To 2
            lbl_ItemNum(intStep).Text = ""
            lbl_ItemNum(intStep).Visible = False
            lbl_POItem(intStep).Text = ""
            lbl_POItem(intStep).Visible = False
            lbl_DrawNum(intStep).Text = ""
            lbl_DrawRev(intStep).Text = ""
            lbl_QtyOrdered(intStep).Text = ""
            lbl_QtyOrdered(intStep).Visible = False
            lbl_QtyShipped(intStep).Text = ""
            lbl_QtyShipped(intStep).Visible = False
            lbl_DescripA(intStep).Text = ""
            lbl_DescripA(intStep).Visible = False
            lbl_DescripB(intStep).Text = ""
            lbl_DescripB(intStep).Visible = False
            lbl_DescripC(intStep).Text = ""
            lbl_DescripC(intStep).Visible = False
            lbl_MaterialHeat(intStep).Text = ""
            lbl_MaterialHeat(intStep).Visible = False
            lbl_Price(intStep).Text = ""
            lbl_Price(intStep).Visible = False
            lbl_ExtendedPrice(intStep).Text = ""
            lbl_ExtendedPrice(intStep).Visible = False
        Next

        lbl_SubTotal.Text = ""
        lbl_Total.Text = ""

    End Sub
    Private Sub DataFill() 'Fill form with data pertaining to listbox selection

        Call ClearData() 'Clear form of all data

        strSQL = "SELECT Id,Customers.CustCode,Company,Address,City,State,ZipCode,BCompany,BAddress,BCity,BState,BZipcode,InvoiceNumber,InvoiceItem," _
             & "InvoiceDate,PurchaseOrder,POItem,DrawingNumber,DrawingRevision,ShipDate,QtyOrdered,QtyShip,DescripA,DescripB,DescripC,Price,Invoice.Freight," _
             & "MaterialHeat,Discount,DiscountDays,Invoice.ShipVia FROM Invoice INNER JOIN Customers ON Invoice.CustCode = Customers.CustCode "

        If Microsoft.VisualBasic.Left(Trim(Listbox_Search.SelectedItem), 8) <> "Lot Id =" Then
            strSQL = strSQL & "WHERE InvoiceNumber = " & Listbox_Search.SelectedItem & " ORDER BY InvoiceItem;"
            booInvoice = True
        Else
            strSQL = strSQL & "WHERE Id = " & Mid(Trim(Listbox_Search.SelectedItem), 10) & ";"
            booInvoice = False
        End If

        dbDataSet.Clear()
        dbDataSet.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter.Fill(dbDataSet, "Display")
        gbl_DstConnect.Close()
        RecordCount = dbDataSet.Tables("Display").Rows.Count()
        If RecordCount > 3 Then RecordCount = 3

        If dbDataSet.Tables("Display").Rows.Count() > 0 Then

            Dim strCity, strState, strZipcode As String
            Dim sngPrice As Single

            'Form fill data
            If booInvoice = True Then
                Label_InvoiceNumber.Text = "invoice No:"
                Label_InvoiceLarge.SetBounds(504, 92, 135, 42)
                Label_InvoiceLarge.Text = "invoice"
                If Not IsDBNull(dbDataSet.Tables("Display").Rows(0).Item(12)) Then 'Invoice number
                    lbl_InvoiceNumber.Text = Trim(dbDataSet.Tables("Display").Rows(0).Item(12))
                End If
            Else
                Label_InvoiceNumber.Text = "Lot Id:"
                Label_InvoiceLarge.SetBounds(430, 92, 282, 42)
                Label_InvoiceLarge.Text = "Purchase Order"
                If Not IsDBNull(dbDataSet.Tables("Display").Rows(0).Item(0)) Then 'Lot Id
                    lbl_InvoiceNumber.Text = Trim(dbDataSet.Tables("Display").Rows(0).Item(0))
                End If
            End If

            If Not IsDBNull(dbDataSet.Tables("Display").Rows(0).Item(2)) Then 'Sold to name
                lbl_SoldToName.Text = Trim(dbDataSet.Tables("Display").Rows(0).Item(2))
            End If

            If Not IsDBNull(dbDataSet.Tables("Display").Rows(0).Item(3)) Then 'Sold to address
                lbl_SoldToAddress.Text = Trim(dbDataSet.Tables("Display").Rows(0).Item(3))
            End If

            If Not IsDBNull(dbDataSet.Tables("Display").Rows(0).Item(4)) Then 'Sold to city
                strCity = Trim(dbDataSet.Tables("Display").Rows(0).Item(4))
            Else : strCity = "" : End If

            If Not IsDBNull(dbDataSet.Tables("Display").Rows(0).Item(5)) Then 'Sold to state
                strState = Trim(dbDataSet.Tables("Display").Rows(0).Item(5))
            Else : strState = "" : End If

            If Not IsDBNull(dbDataSet.Tables("Display").Rows(0).Item(6)) Then 'Sold to zipcode
                strZipcode = Trim(dbDataSet.Tables("Display").Rows(0).Item(6))
            Else : strZipcode = "" : End If
            lbl_SoldToState.Text = strCity & "  " & strState & "  " & strZipcode

            If Not IsDBNull(dbDataSet.Tables("Display").Rows(0).Item(7)) Then 'Ship to name
                lbl_ShipToName.Text = Trim(dbDataSet.Tables("Display").Rows(0).Item(7))
            End If

            If Not IsDBNull(dbDataSet.Tables("Display").Rows(0).Item(8)) Then 'Ship to address
                lbl_ShiptoAddress.Text = Trim(dbDataSet.Tables("Display").Rows(0).Item(8))
            End If

            If Not IsDBNull(dbDataSet.Tables("Display").Rows(0).Item(9)) Then 'Ship to city
                strCity = Trim(dbDataSet.Tables("Display").Rows(0).Item(9))
            Else : strCity = "" : End If

            If Not IsDBNull(dbDataSet.Tables("Display").Rows(0).Item(10)) Then 'Ship to state
                strState = Trim(dbDataSet.Tables("Display").Rows(0).Item(10))
            Else : strState = "" : End If

            If Not IsDBNull(dbDataSet.Tables("Display").Rows(0).Item(11)) Then 'Ship to zipcode
                strZipcode = Trim(dbDataSet.Tables("Display").Rows(0).Item(11))
            Else : strZipcode = "" : End If
            lbl_ShipToState.Text = strCity & "  " & strState & "  " & strZipcode

            If Not IsDBNull(dbDataSet.Tables("Display").Rows(0).Item(14)) Then 'Invoice date
                lbl_InvoiceDate.Text = dbDataSet.Tables("Display").Rows(0).Item(14)
            End If

            If Not IsDBNull(dbDataSet.Tables("Display").Rows(0).Item(15)) Then 'Purchase order number
                lbl_PurchaseOrder.Text = Trim(dbDataSet.Tables("Display").Rows(0).Item(15))
            End If

            If Not IsDBNull(dbDataSet.Tables("Display").Rows(0).Item(19)) Then 'Date shipped
                lbl_DateShipped.Text = dbDataSet.Tables("Display").Rows(0).Item(19)
            End If

            If Not IsDBNull(dbDataSet.Tables("Display").Rows(0).Item(30)) Then 'ShipVia
                lbl_ShipVia.Text = Trim(dbDataSet.Tables("Display").Rows(0).Item(30))
            End If

            If booInvoice = True Then
                lbl_Terms.Text = Terms 'Terms
            End If

            If Not IsDBNull(dbDataSet.Tables("Display").Rows(0).Item(28)) Then 'Discount
                If dbDataSet.Tables("Display").Rows(0).Item(28) <> 0 Then
                    DiscountAmt = dbDataSet.Tables("Display").Rows(0).Item(28)
                    DiscountDays = dbDataSet.Tables("Display").Rows(0).Item(29)
                    lbl_Discount.Text = "Yes"
                    lbl_DiscountMessage.Text = DiscountAmt & "% Discount if paid within " & DiscountDays & " days"
                    lbl_DiscountMessage.Visible = True
                End If
            End If

            SubTotal = 0
            Freight = 0
            Dim intTop As Integer = 350 '400
            For intStep = 0 To RecordCount - 1

                intTop = intTop + 40 'Space between items

                lbl_ItemNum(intStep).Top = intTop
                lbl_ItemNum(intStep).Text = intStep + 1
                lbl_ItemNum(intStep).Visible = True

                If Not IsDBNull(dbDataSet.Tables("Display").Rows(intStep).Item(16)) Then 'Purchase order line item number
                    lbl_POItem(intStep).Top = intTop
                    lbl_POItem(intStep).Text = Trim(dbDataSet.Tables("Display").Rows(intStep).Item(16))
                    lbl_POItem(intStep).Visible = True
                End If

                If Not IsDBNull(dbDataSet.Tables("Display").Rows(intStep).Item(17)) Then 'Drawing number
                    lbl_DrawNum(intStep).Text = Trim(dbDataSet.Tables("Display").Rows(intStep).Item(17))
                End If

                If Not IsDBNull(dbDataSet.Tables("Display").Rows(intStep).Item(18)) Then 'Drawing revision
                    lbl_DrawRev(intStep).Text = Trim(dbDataSet.Tables("Display").Rows(intStep).Item(18))
                End If

                If Not IsDBNull(dbDataSet.Tables("Display").Rows(intStep).Item(20)) Then 'Quantity ordered
                    lbl_QtyOrdered(intStep).Top = intTop
                    lbl_QtyOrdered(intStep).Text = Trim(dbDataSet.Tables("Display").Rows(intStep).Item(20))
                    lbl_QtyOrdered(intStep).Visible = True
                End If

                If Not IsDBNull(dbDataSet.Tables("Display").Rows(intStep).Item(21)) Then 'Quantity shipped
                    lbl_QtyShipped(intStep).Top = intTop
                    lbl_QtyShipped(intStep).Text = Trim(dbDataSet.Tables("Display").Rows(intStep).Item(21))
                    lbl_QtyShipped(intStep).Visible = True
                End If

                If Not IsDBNull(dbDataSet.Tables("Display").Rows(intStep).Item(22)) Then 'Description line 1
                    lbl_DescripA(intStep).Top = intTop
                    lbl_DescripA(intStep).Text = Trim(dbDataSet.Tables("Display").Rows(intStep).Item(22))
                    lbl_DescripA(intStep).Visible = True
                End If

                If Not IsDBNull(dbDataSet.Tables("Display").Rows(intStep).Item(23)) Then 'Description line 2
                    lbl_DescripB(intStep).Text = Trim(dbDataSet.Tables("Display").Rows(intStep).Item(23))
                    If lbl_DescripB(intStep).Text <> "" Then
                        intTop = intTop + 18
                        lbl_DescripB(intStep).Top = intTop
                        lbl_DescripB(intStep).Visible = True
                    End If
                End If

                If Not IsDBNull(dbDataSet.Tables("Display").Rows(intStep).Item(24)) Then 'Description line 3
                    lbl_DescripC(intStep).Text = Trim(dbDataSet.Tables("Display").Rows(intStep).Item(24))
                    If lbl_DescripC(intStep).Text <> "" Then
                        intTop = intTop + 18
                        lbl_DescripC(intStep).Top = intTop
                        lbl_DescripC(intStep).Visible = True
                    End If
                End If

                If Not IsDBNull(dbDataSet.Tables("Display").Rows(intStep).Item(27)) Then 'Material Heat line 4
                    If dbDataSet.Tables("Display").Rows(intStep).Item(27) <> "" Then
                        intTop = intTop + 18
                        lbl_MaterialHeat(intStep).Top = intTop
                        lbl_MaterialHeat(intStep).Text = "Material Heat = " & Trim(dbDataSet.Tables("Display").Rows(intStep).Item(27)) & "   " & "Lot Id = " & Trim(dbDataSet.Tables("Display").Rows(intStep).Item(0))
                        lbl_MaterialHeat(intStep).Visible = True
                    End If
                End If

                If Not IsDBNull(dbDataSet.Tables("Display").Rows(intStep).Item(25)) Then 'Item 1, Unit Price
                    sngPrice = Trim(dbDataSet.Tables("Display").Rows(intStep).Item(25))
                    lbl_Price(intStep).Top = intTop : lbl_ExtendedPrice(intStep).Top = intTop
                    lbl_Price(intStep).Text = FormatCurrency(sngPrice)
                    lbl_Price(intStep).Visible = True
                    If lbl_QtyOrdered(intStep).Text <> "" Or lbl_QtyShipped(intStep).Text <> "" Then
                        Dim ExtendedPrice As Single
                        If lbl_QtyShipped(intStep).Text <> "" Then
                            ExtendedPrice = sngPrice * Convert.ToInt32(lbl_QtyShipped(intStep).Text)
                        Else
                            ExtendedPrice = sngPrice * Convert.ToInt32(lbl_QtyOrdered(intStep).Text)
                        End If
                        SubTotal = SubTotal + ExtendedPrice
                        lbl_ExtendedPrice(intStep).Text = FormatCurrency(ExtendedPrice)
                        lbl_ExtendedPrice(intStep).Visible = True
                    End If
                End If

                If Not IsDBNull(dbDataSet.Tables("Display").Rows(intStep).Item(26)) Then 'Freight
                    Freight = Freight + dbDataSet.Tables("Display").Rows(intStep).Item(26)
                End If

            Next
            If SubTotal <> 0 Then
                lbl_SubTotal.Text = FormatCurrency(SubTotal)
                lbl_Freight.Text = FormatCurrency(Freight)
                SubTotal = SubTotal + Freight
                lbl_Total.Text = FormatCurrency(SubTotal)
            End If
        End If

        If Microsoft.VisualBasic.Left(Trim(Listbox_Search.SelectedItem), 6) = "Lot Id" Then
            cmd_PrintInvoice.Text = "      Print       Purchase Order"
            cmd_PrintInvoice.Enabled = True
            cmd_PrintPackingSlip.Enabled = False
            cmd_PrintCertificate.Enabled = False
        Else
            cmd_PrintInvoice.Text = "     Print       Invoice"
            cmd_PrintInvoice.Enabled = True
            cmd_PrintPackingSlip.Enabled = True
            cmd_PrintCertificate.Enabled = True
        End If
        opt_Preview.Enabled = True
    End Sub
    Private Sub ListBox_Search_Click() Handles Listbox_Search.Click, Listbox_Search.DoubleClick
        If Listbox_Search.Items.Count = 0 Then Exit Sub
        Call DataFill()
    End Sub
    Private Sub PrintForms_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintForms.PrintPage

        'Setup hard margins for printer
        Dim hDC As IntPtr = e.Graphics.GetHdc()
        Dim CurrentX, CurrentY, CurrentX1, CurrentX2, CurrentX3, TextX, TextY, TextLen As Integer
        Dim HardX1, HardX2, HardY1, HardY2, HardWidth, HardHeight As Integer
        Dim Font As Font
        Dim Text As String
        Dim points() As Point
        Dim border, fill As Rectangle
        Dim blackPen As New Pen(Color.Black, 1)

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

        Select Case PageNumber
            Case 1, 2

                'Print large invoice text: & label "Invoice no:" 
                If PageNumber = 1 Then
                    If booInvoice = True Then
                        Font = New Font("Arial", 12, FontStyle.Bold)
                        e.Graphics.DrawString("Invoice No:", Font, InvoBrush, HardX1 + 630, HardY1 + 20)
                        Font = New Font("Swis721 BlkOul BT", 32, FontStyle.Regular)
                        e.Graphics.DrawString("invoice", Font, InvoBrush, HardX1 + 500, HardY1 + 70)
                    Else
                        Font = New Font("Arial", 12, FontStyle.Bold)
                        e.Graphics.DrawString("Lot Id:", Font, InvoBrush, HardX1 + 670, HardY1 + 20)
                        Font = New Font("Swis721 BlkOul BT", 26, FontStyle.Regular)
                        e.Graphics.DrawString("Purchase Order", Font, InvoBrush, HardX1 + 460, HardY1 + 70)
                    End If
                Else
                    Font = New Font("Swis721 BlkOul BT", 32, FontStyle.Regular) ' Font
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

                    If PageNumber = 1 Then 'Invoice
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
                e.Graphics.DrawString(lbl_CompanyAddress.Text, Font, InvoBrush, CurrentX, CurrentY) 'Print company address
                CurrentY = CurrentY + Font.Height
                e.Graphics.DrawString(lbl_CompanyCity.Text, Font, InvoBrush, CurrentX, CurrentY) 'Print company city, state, zipcode
                Font = New Font("Ariel", 10, FontStyle.Regular)
                CurrentY = CurrentY + Font.Height + 4
                e.Graphics.DrawString(lbl_CompanyPhone.Text, Font, InvoBrush, CurrentX + 27, CurrentY) 'Print company phone

                'Print invoice number
                e.Graphics.DrawString(lbl_InvoiceNumber.Text, Font, InvoBrush, HardX1 + 727, HardY1 + 22)

                'Print Sold To & Ship to data
                CurrentY = HardY1 + 252
                e.Graphics.DrawString(lbl_SoldToName.Text, Font, InvoBrush, HardX1 + 96, CurrentY) 'Sold to 
                e.Graphics.DrawString(lbl_ShipToName.Text, Font, InvoBrush, HardX1 + 506, CurrentY) 'Ship to 
                CurrentY = CurrentY + Font.Height + 3
                e.Graphics.DrawString(lbl_SoldToAddress.Text, Font, InvoBrush, HardX1 + 96, CurrentY) 'Sold to address
                e.Graphics.DrawString(lbl_ShiptoAddress.Text, Font, InvoBrush, HardX1 + 506, CurrentY) 'Ship to address
                CurrentY = CurrentY + Font.Height + 3
                e.Graphics.DrawString(lbl_SoldToState.Text, Font, InvoBrush, HardX1 + 96, CurrentY) 'Sold to city, state, zipcode
                e.Graphics.DrawString(lbl_ShipToState.Text, Font, InvoBrush, HardX1 + 506, CurrentY) 'Ship to city, state, zipcode

                'Print purchase order number
                CurrentY = HardY1 + 368
                Text = lbl_PurchaseOrder.Text
                TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 38 + (172 - TextLen) / 2, CurrentY)

                'Print invoice date
                Text = lbl_InvoiceDate.Text
                TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 210 + (125 - TextLen) / 2, CurrentY)

                'Print date shipped
                Text = lbl_DateShipped.Text
                TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 335 + (125 - TextLen) / 2, CurrentY)

                'Print shipped via
                Text = lbl_ShipVia.Text
                TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 460 + (134 - TextLen) / 2, CurrentY)

                'Print terms
                If booInvoice = True Then
                    Text = lbl_Terms.Text
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                    e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 594 + (124 - TextLen) / 2, CurrentY)
                End If

                'Print discount
                If PageNumber = 1 Then If lbl_Discount.Text = "Yes" Then e.Graphics.DrawString("Yes", Font, InvoBrush, HardX1 + 727, CurrentY)

                'Print lower form data
                CurrentY = HardY1 + 453 '4th line + 30
                For intStep = 0 To RecordCount - 1

                    'Print item number
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(intStep, Font).Width)
                    e.Graphics.DrawString(intStep + 1, Font, InvoBrush, HardX1 + (50 - TextLen) / 2, CurrentY)

                    'Print purchase order line item number
                    Text = lbl_POItem(intStep).Text
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(intStep, Font).Width)
                    e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 50 + (50 - TextLen) / 2, CurrentY)

                    'Print Qty ordered
                    Text = lbl_QtyOrdered(intStep).Text
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                    e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 100 + (70 - TextLen) / 2, CurrentY)

                    'Print Qty shipped
                    Text = lbl_QtyShipped(intStep).Text
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                    e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 170 + (70 - TextLen) / 2, CurrentY)

                    'Print description line 1
                    Text = lbl_DescripA(intStep).Text
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                    e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 240 + (350 - TextLen) / 2, CurrentY)

                    'Print description line 2
                    If lbl_DescripB(intStep).Text <> "" Then
                        Text = lbl_DescripB(intStep).Text
                        CurrentY = CurrentY + Font.Height + 3
                        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                        e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 240 + (350 - TextLen) / 2, CurrentY)
                    End If

                    'Print description line 3
                    If lbl_DescripC(intStep).Text <> "" Then
                        Text = lbl_DescripC(intStep).Text
                        CurrentY = CurrentY + Font.Height + 3
                        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                        e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 240 + (350 - TextLen) / 2, CurrentY)
                    End If

                    'Print Material heat with lot id
                    If lbl_MaterialHeat(intStep).Visible = True Then
                        Text = lbl_MaterialHeat(intStep).Text
                        CurrentY = CurrentY + Font.Height + 3
                        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                        e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 240 + (350 - TextLen) / 2, CurrentY)
                    End If

                    If PageNumber = 1 Then
                        'Print unit price
                        Text = lbl_Price(intStep).Text
                        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                        e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 590 + (100 - TextLen) / 2, CurrentY)

                        'Print extended price
                        Text = lbl_ExtendedPrice(intStep).Text
                        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                        e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 690 + (110 - TextLen) / 2, CurrentY)
                    End If
                    CurrentY = CurrentY + 45
                Next
                If PageNumber = 1 Then
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

                    If lbl_Discount.Text = "Yes" Then
                        Text = DiscountAmt & "% Discount if paid within " & DiscountDays & " days"
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
                e.Graphics.DrawString(lbl_CompanyAddress.Text, Font, InvoBrush, CurrentX, CurrentY) 'Print company address
                CurrentY = CurrentY + Font.Height
                e.Graphics.DrawString(lbl_CompanyCity.Text, Font, InvoBrush, CurrentX, CurrentY) 'Print company city, state, zipcode
                Font = New Font("Ariel", 10, FontStyle.Regular)
                CurrentY = CurrentY + Font.Height + 4
                e.Graphics.DrawString(lbl_CompanyPhone.Text, Font, InvoBrush, CurrentX + 27, CurrentY) 'Print company phone

                'Print Subject data
                Font = New Font("Arial", 12, FontStyle.Regular)
                e.Graphics.DrawString(lbl_InvoiceDate.Text, Font, InvoBrush, HardX1 + 687, HardY1 + 20)
                e.Graphics.DrawString(lbl_SoldToName.Text, Font, InvoBrush, HardX1 + 92, HardY1 + 305) 'Print company name
                e.Graphics.DrawString("Incomming Inspection", Font, InvoBrush, HardX1 + 103, HardY1 + 340) 'Print data incoming inspection
                e.Graphics.DrawString(lbl_InvoiceNumber.Text, Font, InvoBrush, HardX1 + 268, HardY1 + 375) 'Print data invoice number
                e.Graphics.DrawString(lbl_PurchaseOrder.Text, Font, InvoBrush, HardX1 + 296, HardY1 + 397) 'Print data purchase order number

                'Test if there are multiple items on this invoice
                CurrentX1 = HardX1 + 280 : CurrentX2 = HardX1 + 282 : CurrentX3 = HardX1 + 246 : CurrentY = HardY1 + 485

                For intstep = 0 To RecordCount - 1
                    'Print data drawing number
                    If intstep = 0 Then Text = lbl_DrawNum(intstep).Text Else Text = " , " & lbl_DrawNum(intstep).Text
                    e.Graphics.DrawString(Text, Font, InvoBrush, CurrentX1, HardY1 + 419)
                    CurrentX1 = CurrentX1 + Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width) - 9

                    'Print data quantity shipped
                    If intstep = 0 Then Text = lbl_QtyShipped(intstep).Text Else Text = " , " & lbl_QtyShipped(intstep).Text
                    e.Graphics.DrawString(Text, Font, InvoBrush, CurrentX2, HardY1 + 441)
                    CurrentX2 = CurrentX2 + Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width) - 9

                    'Print data drawing rev
                    If intstep = 0 Then Text = lbl_DrawRev(intstep).Text Else Text = " , " & lbl_DrawRev(intstep).Text
                    e.Graphics.DrawString(Text, Font, InvoBrush, CurrentX3, HardY1 + 463)
                    CurrentX3 = CurrentX3 + Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width) - 9

                    'Print description line 1
                    If RecordCount > 1 Then Text = "Item (" & intstep + 1 & ") :  " & lbl_DescripA(intstep).Text Else Text = lbl_DescripA(intstep).Text
                    e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 237, CurrentY)
                    If RecordCount > 1 Then CurrentX = HardX1 + 309 Else CurrentX = HardX1 + 237

                    'Print description line 2
                    Text = lbl_DescripB(intstep).Text
                    If Text <> "" Then
                        CurrentY = CurrentY + Font.Height + 3
                        e.Graphics.DrawString(Text, Font, InvoBrush, CurrentX, CurrentY)
                    End If

                    'Print description line 3
                    Text = lbl_DescripC(intstep).Text
                    If Text <> "" Then
                        CurrentY = CurrentY + Font.Height + 3
                        e.Graphics.DrawString(Text, Font, InvoBrush, CurrentX, CurrentY)
                    End If

                    'Print Material heat with lot id
                    If lbl_MaterialHeat(intstep).Visible = True Then
                        Text = lbl_MaterialHeat(intstep).Text
                        CurrentY = CurrentY + Font.Height + 3
                        e.Graphics.DrawString(Text, Font, InvoBrush, CurrentX, CurrentY)
                    End If

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
                e.Graphics.DrawString(Agent, Font, InvoBrush, HardX1 + 490, CurrentY)
                CurrentY = CurrentY + Font.Height + 3
                e.Graphics.DrawString("Quality Control Manager", Font, InvoBrush, HardX1 + 490, CurrentY)

        End Select

        PageNumber += 1
        e.HasMorePages = PageNumber <= 1

    End Sub

    'All command actions
    Private Sub cmd_Search_Click(sender As Object, e As EventArgs) Handles cmd_Search.Click
        If tbox_Search.Visible = True And tbox_Search.Text = "" Then Exit Sub
        If tbox_SearchMasked.Visible = True And tbox_SearchMasked.Text = "  /  /" Then Exit Sub

        Dim strSearch, strHold As String
        Dim intSpace As Integer = 0

        Listbox_Search.Items.Clear() 'Clear listbox of all items
        strSQL = "SELECT Id,InvoiceNumber,InvoiceDate FROM Invoice "

        'Find selected option
        Dim intStep As Integer
        For intStep = 0 To 6
            If opt_Search(intStep).Checked = True Then Exit For
        Next

        Select Case intStep
            Case 0
                'Find invoice number, and include all invoices, invoiced the same day for related searches
                strSQL = strSQL & "WHERE InvoiceNumber = " & Trim(tbox_Search.Text) & ";" 'Invoice number
                dbDataSet.Clear()
                dbDataSet.Tables.Clear()
                gbl_DstConnect.Open()
                dbAdapter = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
                dbAdapter.Fill(dbDataSet, "DateFind")
                gbl_DstConnect.Close()
                If dbDataSet.Tables("DateFind").Rows.Count() > 0 Then
                    If Not IsDBNull(dbDataSet.Tables("DateFind").Rows(0).Item(2)) Then 'Invoice date
                        Dim datLookup As Date = dbDataSet.Tables("DateFind").Rows(0).Item(2)
                        strSQL = "SELECT Id,InvoiceNumber FROM Invoice WHERE InvoiceDate = #" & datLookup & "# ORDER BY InvoiceNumber;" 'Invoice date
                    End If
                End If
            Case 1 'Purchase order 
                strSearch = Trim(tbox_Search.Text)
                '  intSpace = InStr(strSearch, " ")
                ' If intSpace > 0 Then
                ' strHold = Mid(strSearch, intSpace + 1, Len(strSearch) - intSpace)
                ' strSearch = Microsoft.VisualBasic.Left(strSearch, intSpace - 1)
                ' strSQL = strSQL & "WHERE PurchaseOrder = '" & strSearch & "' AND POItem = " & CInt(Int(strHold)) & " ORDER BY InvoiceNumber;"
                ' Else
                strSQL = strSQL & "WHERE PurchaseOrder = '" & strSearch & "' ORDER BY InvoiceNumber;"
                ' End If
            Case 2 'Drawing number
                strSearch = Trim(tbox_Search.Text)
                intSpace = InStr(strSearch, " ")
                If intSpace > 0 Then
                    strHold = Mid(strSearch, intSpace + 1, Len(strSearch) - intSpace)
                    strSearch = Microsoft.VisualBasic.Left(strSearch, intSpace - 1)
                    strSQL = strSQL & "WHERE DrawingNumber = '" & strSearch & "' AND DrawingRevision = '" & strHold & "' ORDER BY InvoiceNumber;"
                Else
                    strSQL = strSQL & "WHERE DrawingNumber = '" & strSearch & "' ORDER BY InvoiceNumber;"
                End If
            Case 3 : strSQL = strSQL & "WHERE MaterialHeat = '" & Trim(tbox_Search.Text) & "' ORDER BY InvoiceNumber;" 'Material heat
            Case 4 : strSQL = strSQL & "WHERE Id = " & Trim(tbox_Search.Text) & ";" 'Lot Id
            Case 5 : strSQL = strSQL & "WHERE InvoiceDate = #" & Trim(tbox_SearchMasked.Text) & "# ORDER BY InvoiceNumber;" 'Invoice date
            Case 6 : strSQL = strSQL & "WHERE ShipDate = #" & Trim(tbox_SearchMasked.Text) & "# ORDER BY InvoiceNumber;" 'Ship date
        End Select

        dbDataSet.Clear()
        dbDataSet.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter.Fill(dbDataSet, "ListboxFill")
        gbl_DstConnect.Close()

        If dbDataSet.Tables("ListboxFill").Rows.Count() > 0 Then

            Dim varhold, lastEntry As Object
            Dim inc, listboxSize As Integer
            Dim buffer As String = ""
            If dbDataSet.Tables("ListboxFill").Rows.Count() <= 30 Then listboxSize = 26 Else listboxSize = 20

            lastEntry = Nothing
            For inc = 0 To dbDataSet.Tables("ListboxFill").Rows.Count - 1
                varhold = dbDataSet.Tables("ListboxFill").Rows(inc).Item(1) 'Invoice Number
                If IsDBNull(varhold) Then varhold = "" Else varhold = Replace(varhold, "^", "'")

                If varhold <> "" Then 'Records that have been invoiced
                    If varhold <> lastEntry Then lastEntry = varhold Else varhold = "" 'Test for repeat invoice number on seperate items
                Else 'Records not invoiced ( Purchase Orders )
                    varhold = "Lot Id = " & dbDataSet.Tables("ListboxFill").Rows(inc).Item(0) 'Id Number
                End If

                'Add data to listbox ( centered )
                If varhold <> "" Then
                    intSpace = (listboxSize - Len(varhold)) / 2
                    buffer = ""
                    For i = 1 To intSpace
                        buffer = buffer & " "
                    Next
                    varhold = buffer & varhold
                    Listbox_Search.Items.Add(varhold)
                End If
            Next

            'Select item in listbox
            If intStep = 0 Then 'Select item in a list of all invoices,invoiced on the same day
                For i As Integer = 0 To Listbox_Search.Items.Count - 1
                    If (Listbox_Search.Items(i).ToString.Contains(Trim(tbox_Search.Text))) Then
                        Listbox_Search.SetSelected(i, True)
                        Exit For
                    End If
                Next
            Else
                Listbox_Search.SelectedIndex = 0
            End If

            Call DataFill()
            lbl_Message1.Text = "Listed invoices are all invoices, invoiced on the same day of the searched entry"
        Else 'No data found related to search
            frm_Message.Text = "8:1:0:8:3:No records were found to meet the search criteria"
            frm_Message.ShowDialog()
            Listbox_Search.Items.Clear() 'Clear listbox of all items
            Call ClearData() 'Clear form of all data
            tbox_Search.Text = ""
            tbox_Search.Focus()
        End If
    End Sub
    Private Sub cmd_Exit_Click(sender As Object, e As EventArgs) Handles cmd_Exit.Click
        Me.Close()
        Exit Sub
    End Sub
    Private Sub cmd_Print_Click(sender As Object, e As EventArgs) Handles cmd_PrintInvoice.Click, cmd_PrintPackingSlip.Click, cmd_PrintCertificate.Click
        If lbl_InvoiceNumber.Text = "" Then Exit Sub
        Select Case sender.name
            Case "cmd_PrintInvoice" : PageNumber = 1
            Case "cmd_PrintPackingSlip" : PageNumber = 2
            Case "cmd_PrintCertificate" : PageNumber = 3
        End Select
        If opt_Preview.Checked = True Then
            PrintForms = New PrintDocument
            PrintPreviewDialog1.Document = PrintForms
            PrintPreviewDialog1.ShowDialog()
        Else
            PrintForms = New PrintDocument
            PrintForms.PrinterSettings.PrinterName = SystemPrinter
            PrintForms.Print()
        End If
        opt_Preview.Checked = False
    End Sub
    Private Sub opt_CheckedChanged(sender As Object, e As EventArgs)
        Listbox_Search.Items.Clear() 'Clear listbox of all items
        Call ClearData() 'Clear form of all data     
        cmd_PrintInvoice.Enabled = False
        cmd_PrintPackingSlip.Enabled = False
        cmd_PrintCertificate.Enabled = False
        opt_Preview.Enabled = False
        If sender.tag <= 4 Then
            tbox_Search.Visible = True
            tbox_SearchMasked.Visible = False
            tbox_Search.Text = ""
            tbox_Search.Focus()
        Else
            tbox_Search.Visible = False
            tbox_SearchMasked.Visible = True
            tbox_SearchMasked.Text = ""
            tbox_SearchMasked.Focus()
        End If      
    End Sub


    'All texbox handlers
    Private Sub tbox_Search_GotFocus(sender As Object, e As EventArgs) Handles tbox_Search.GotFocus, tbox_SearchMasked.GotFocus
        sender.BackColor = (Color.FromArgb(255, 255, 192))
        If tbox_Search.Visible = True Then sender.CharacterCasing = CharacterCasing.Upper
    End Sub
    Private Sub tbox_Search_LostFocus(sender As Object, e As EventArgs) Handles tbox_Search.LostFocus, tbox_SearchMasked.LostFocus
        sender.BackColor = Color.White
    End Sub
    Private Sub tbox_Search_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbox_Search.KeyPress, tbox_SearchMasked.KeyPress
        If sender.Text = "" Or booCorrection = True Then Exit Sub

        If e.KeyChar = ChrW(Keys.Return) Then
            If opt_Search(0).Checked = True Or opt_Search(4).Checked = True Then
                If Not IsNumeric(sender.Text) Then
                    booCorrection = True
                    frm_Message.Text = "8:1:0:1:3:Invalid Entry --- Numerical entries are only allowed"
                    frm_Message.ShowDialog()
                    sender.text = ""
                    sender.Focus()
                    booCorrection = False
                    Exit Sub
                End If
            End If
            If opt_Search(5).Checked = True Or opt_Search(6).Checked = True Then
                If IsDate(sender.Text) = False And sender.Text <> "  /  /" Then
                    sender.BackColor = Color.Aqua
                    booCorrection = True
                    frm_Message.Text = "8:1:0:1:3:Data entry must be a date, Please enter a valid date"
                    frm_Message.ShowDialog()
                    sender.text = ""
                    sender.Focus()
                    booCorrection = False
                    Exit Sub
                End If
            End If
            cmd_Search.PerformClick()
        End If
    End Sub


    'All mouse movement and mouse over messages
    Private Sub tbox_SearchMasked_MouseClick(sender As Object, e As MouseEventArgs) Handles tbox_SearchMasked.MouseClick
        sender.SelectionStart = 0
    End Sub
    Private Sub ListBox1_MouseEnter(sender As Object, e As EventArgs) Handles Listbox_Search.MouseEnter
        Listbox_Search.Focus()
    End Sub
    Private Sub fra_MouseMove(sender As Object, e As EventArgs) Handles fra_List.MouseMove, fra_SearchCriteria.MouseMove, fra_InvoiceDisplay.MouseMove, fra_InvoiceDisplay.MouseMove 'Clear message
        intMessage = 0
        If lbl_Message1.Text = "Listed invoices are all invoices, invoiced on the same day of the searched entry" Then
            If sender.name <> "fra_SearchCriteria" Then Call MouseMessages()
        Else
            Call MouseMessages()
        End If
    End Sub
    Private Sub All_MouseHover(sender As Object, e As EventArgs) Handles Listbox_Search.MouseHover, cmd_Search.MouseHover, tbox_Search.MouseHover
        Select Case sender.name
            Case "Listbox_Search" : intMessage = 1
            Case "opt_InvoiceNumber" : intMessage = 2
            Case "opt_PurchaseOrder" : intMessage = 3
            Case "opt_DrawNumber" : intMessage = 4
            Case "opt_MaterialHeat" : intMessage = 5
            Case "opt_LotId" : intMessage = 6
            Case "opt_InvoiceDate" : intMessage = 7
            Case "opt_ShipDate" : intMessage = 8
            Case "cmd_Search" : intMessage = 9
            Case "cmd_Print" : intMessage = 10
            Case "tbox_Search" : intMessage = 11
        End Select
        Call MouseMessages()
    End Sub
    Private Sub MouseMessages()
        Select Case intMessage
            Case 0 : lbl_Message1.Text = "" : lbl_Message2.Text = "" 'Clear messages from screen
            Case 1 : lbl_Message1.Text = "Select invoice number from list to view in form"
            Case 2 : lbl_Message1.Text = "Select this option to locate an individual invoice"
            Case 3 : lbl_Message1.Text = "Select this option to locate all invoices sharing the same purchase order"
            Case 4 : lbl_Message1.Text = "Select this option to locate all invoices sharing the same drawing number"
                lbl_Message2.Text = "Adding drawing revision will refine search to only the selected revision"
            Case 5 : lbl_Message1.Text = "Select this option to locate all invoices sharing the same Material Heat"
            Case 6 : lbl_Message1.Text = "Select this option to locate the invoice sharing the selected lot Id"
            Case 7 : lbl_Message1.Text = "Select this option to locate all invoices sharing the same invoice date"
            Case 8 : lbl_Message1.Text = "Select this option to locate all invoices sharing the same shipping date"
            Case 9 : lbl_Message1.Text = "Press this button to start a search on the entered Search Criteria"
            Case 10 : lbl_Message1.Text = "Press this button to print a copy of the invoice form"
            Case 11 : lbl_Message1.Text = "Enter the data to be used for the selected search"
        End Select
    End Sub


End Class