Imports System.Drawing.Printing
Public Class frm_InvoicePaid

    'Database related
    Dim dbAdapter, dbAdapter_SystemData As OleDb.OleDbDataAdapter
    Dim dbDataSet, dbDataSet_SystemData As New DataSet
    Dim strSQL As String

    'Form controls related
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
    Dim booCorrection, booInvoice As Boolean 'BooInvoice = true ( form set to invoice ),BooInvoice = false ( form set to purchase order 
    Dim ShipVia, Agent, Terms As String
    Dim ListCount, RecordCount, UndoNum, DiscountDays, intMessage, intlookup As Integer
    Dim DiscountAmt, Freight, SubTotal As Single
    Dim Undo(0, 3) As String

    'Print report Related
    Private WithEvents PrintForms As PrintDocument
    Declare Function GetDeviceCaps% Lib "GDI32" (ByVal hDC%, ByVal nIndex%)
    Private image_Path, InvImage As String
    Private InvoBrush As New SolidBrush(Color.Black)
    Private FillBrush As New SolidBrush(Color.Lavender)


    'All form related events
    Private Sub frm_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated
        Call AddControls()
        Call FormValues()
    End Sub
    Private Sub frm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Me.Location = New Point((Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2, frm_Main.Top + 65)
        UndoNum = -1
        Call ListboxFill()
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

        'Create array of controls in frame information
        int_Top = 377
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
        strSQL = "SELECT CompanyAddress,CompanyCity,CompanyState,CompanyZipCode,CompanyPhone,Terms,ShipVia,Agent1 FROM System;"
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

    End Sub
    Private Sub ListboxFill()

        Listbox_UnPaid.Items.Clear() 'Clear listbox of all items
        strSQL = "SELECT DISTINCT InvoiceNumber FROM Invoice WHERE InvoiceNumber Is Not Null AND PaidDate Is Null ORDER BY InvoiceNumber;"

        dbDataSet.Clear()
        dbDataSet.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter.Fill(dbDataSet, "ListboxFill")
        gbl_DstConnect.Close()
        ListCount = dbDataSet.Tables("ListboxFill").Rows.Count()

        If ListCount > 0 Then
            If UndoNum = -1 Then ReDim Undo(ListCount - 1, 3)
            Dim inc, intSpace, ListboxSize As Integer
            Dim buffer, strHold As String
            If dbDataSet.Tables("ListboxFill").Rows.Count() <= 30 Then ListboxSize = 26 Else ListboxSize = 20
            For inc = 0 To dbDataSet.Tables("ListboxFill").Rows.Count - 1

                If Not IsDBNull(dbDataSet.Tables("ListboxFill").Rows(inc).Item(0)) Then 'Invoice number
                    strHold = Trim(dbDataSet.Tables("ListboxFill").Rows(inc).Item(0))

                    'Add data to listbox ( centered )
                    If strHold <> "" Then
                        intSpace = (ListboxSize - Len(strHold)) / 2
                        buffer = ""
                        For i = 1 To intSpace
                            buffer = buffer & " "
                        Next
                        strHold = buffer & strHold
                        Listbox_UnPaid.Items.Add(strHold)
                    End If
                End If
            Next
            Listbox_UnPaid.SelectedIndex = intlookup
            Call DataFill()
        Else 'No data found 
            frm_Message.Text = "10:1:0:35:5:All invoices on record have been paid, Press OK to close this application"
            frm_Message.ShowDialog()
            Listbox_UnPaid.Items.Clear() 'Clear listbox of all items
            Call ClearData() 'Clear form of all data
            Me.Close()
        End If

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

        If Microsoft.VisualBasic.Left(Trim(Listbox_UnPaid.SelectedItem), 8) <> "Lot Id =" Then
            strSQL = strSQL & "WHERE InvoiceNumber = " & Listbox_UnPaid.SelectedItem & " ORDER BY InvoiceItem;"
            booInvoice = True
        Else
            strSQL = strSQL & "WHERE Id = " & Mid(Trim(Listbox_UnPaid.SelectedItem), 10) & ";"
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
            Dim intTop As Integer = 350
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

    End Sub
    Private Sub ListBox_Search_Click() Handles Listbox_UnPaid.Click
        If Listbox_UnPaid.Items.Count = 0 Then Exit Sub
        Call DataFill()
    End Sub
    Private Sub ListBox_Search_DoubleClick() Handles Listbox_UnPaid.DoubleClick
        If Listbox_UnPaid.Items.Count = 0 Then Exit Sub
        Call DataFill()
        cmd_InvoicePaid.PerformClick()
    End Sub


    'All command actions
    Private Sub cmd_Click(sender As Object, e As EventArgs) Handles cmd_InvoicePaid.Click, cmd_Undo.Click, cmd_Exit.Click

        Select Case sender.name
            Case "cmd_Exit"
                Me.Close()
                Exit Sub
            Case "cmd_InvoicePaid"
                intlookup = Listbox_UnPaid.SelectedIndex
                strSQL = "SELECT Id,PaidDate FROM Invoice WHERE InvoiceNumber = " & Trim(Listbox_UnPaid.SelectedItem) & " ORDER BY Id;"
                dbDataSet.Clear()
                dbDataSet.Tables.Clear()
                gbl_DstConnect.Open()
                dbAdapter = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
                dbAdapter.Fill(dbDataSet, "PaidData")
                gbl_DstConnect.Close()

                If dbDataSet.Tables("PaidData").Rows.Count() > 0 Then

                    'Store mark paid record data before deletion
                    UndoNum = UndoNum + 1
                    Undo(UndoNum, 0) = Trim(Listbox_UnPaid.SelectedItem)
                    For intStep = 1 To dbDataSet.Tables("PaidData").Rows.Count()
                        Undo(UndoNum, intStep) = Trim(dbDataSet.Tables("PaidData").Rows(intStep - 1).Item(0))
                    Next

                    'Mark invoice paid in database
                    Dim cb0 As New OleDb.OleDbCommandBuilder(dbAdapter)
                    For intStep = 0 To dbDataSet.Tables("PaidData").Rows.Count() - 1
                        dbDataSet.Tables("PaidData").Rows(intStep).Item(1) = Now.Date
                    Next
                    dbAdapter.Update(dbDataSet, "PaidData")
                    cb0 = Nothing
                    cmd_Undo.Enabled = True
                    Call ListboxFill()
                End If

            Case "cmd_Undo"
                If Undo(0, 0) = Nothing Then Exit Sub 'Exit if no saves left

                strSQL = "SELECT Id,PaidDate FROM Invoice WHERE InvoiceNumber = " & Undo(UndoNum, 0) & " ORDER BY Id;"
                dbDataSet.Clear()
                dbDataSet.Tables.Clear()
                gbl_DstConnect.Open()
                dbAdapter = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
                dbAdapter.Fill(dbDataSet, "PaidUndo")
                gbl_DstConnect.Close()

                If dbDataSet.Tables("PaidUndo").Rows.Count() > 0 Then

                    'Mark invoice un-paid in database
                    Dim cb1 As New OleDb.OleDbCommandBuilder(dbAdapter)
                    For i = 0 To dbDataSet.Tables("PaidUndo").Rows.Count() - 1
                        dbDataSet.Tables("PaidUndo").Rows(i).Item(1) = DBNull.Value
                    Next
                    dbAdapter.Update(dbDataSet, "PaidUndo")
                    cb1 = Nothing

                    'Clear last invoice marked paid data from Undo array
                    For i = 0 To 3
                        Undo(UndoNum, i) = Nothing
                    Next
                    UndoNum = UndoNum - 1
                    If UndoNum = -1 Then cmd_Undo.Enabled = False
                    Call ListboxFill()
                End If
        End Select

    End Sub


    'All mouse movement and mouse over messages
    Private Sub ListBox1_MouseEnter(sender As Object, e As EventArgs) Handles Listbox_UnPaid.MouseEnter
        Listbox_UnPaid.Focus()
    End Sub
    Private Sub fra_MouseMove() Handles fra_List.MouseMove, fra_Commands.MouseMove, fra_InvoiceDisplay.MouseMove, fra_InvoiceDisplay.MouseMove 'Clear message
        intMessage = 0
        Call MouseMessages()
    End Sub
    Private Sub All_MouseHover(sender As Object, e As EventArgs) Handles Listbox_UnPaid.MouseHover, cmd_InvoicePaid.MouseHover, cmd_Undo.MouseHover
        Select Case sender.name
            Case "Listbox_Search" : intMessage = 1
            Case "cmd_InvoicePaid" : intMessage = 2
            Case "cmd_Undo" : intMessage = 3
        End Select
        Call MouseMessages()
    End Sub
    Private Sub MouseMessages()
        Select Case intMessage
            Case 0 : lbl_Message1.Text = "" : lbl_Message2.Text = "" 'Clear messages from screen
            Case 1
                lbl_Message1.Text = "Select the invoice number from the which list to be marked paid"
                lbl_Message2.Text = "Double clicking on the invoice number will mark the item paid"
            Case 2 : lbl_Message1.Text = "Pressing this button will mark the selected invoice paid"
            Case 3 : lbl_Message1.Text = "This button will reinstate the last invoice to not paid"
        End Select
    End Sub

   
End Class