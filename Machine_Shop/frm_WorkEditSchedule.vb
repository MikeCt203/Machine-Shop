Imports System.Drawing.Printing
Public Class frm_WorkEditSchedule

    'Database related
    Dim dbAdapter, dbAdapter_SystemData, dbAdapter_Misc As OleDb.OleDbDataAdapter
    Dim dbDataSet, dbDataSet_SystemData, dbDataSet_Misc As New DataSet
    Dim strSQL As String

    'Form controls related
    Dim lbl_Item(1) As Label
    Dim lbl_Company(1) As Label
    Dim tbox_PurchaseOrder(1) As TextBox
    Dim tbox_POItem(1) As TextBox
    Dim tbox_DrawNumber(1) As TextBox
    Dim tbox_DrawRev(1) As TextBox
    Dim tbox_OrderDate(1) As MaskedTextBox
    Dim tbox_DueDate(1) As MaskedTextBox
    Dim lbl_ShipDate(1) As Label
    Dim tbox_QtyOrder(1) As TextBox
    Dim tbox_Price(1) As TextBox
    Dim lbl_TotalPrice(1) As Label
    Dim lbl_Inventory(1) As Label
    Dim lbl_Surplus(1) As Label
    Dim lbl_ID(1) As Label
    Dim lbl_CustCode(1) As Label
    Dim opt_Select(8) As RadioButton

    'Misc
    Dim SaveArray(1) As Integer 'Array to hold collection of edited items
    Dim varInitialEntry, Company As String 'Used to compare texbox entries
    Dim RecordCount, PurOrderCount, InvoiceCount As Integer 'RecordCount = all purchase order not invoiced
    Dim intMessage As Integer 'Variable used in the mouse over event to show different messages
    Dim booCorrection As Boolean = False
    Dim booEdit, booFormView, booInitial, booChange As Boolean

    'Print report Related
    Declare Function GetDeviceCaps% Lib "GDI32" (ByVal hDC%, ByVal nIndex%)
    Private WithEvents PrintForms As PrintDocument
    Private Pages, PrintRow, PageNumber, Buffer As Integer
    Private SystemPrinter, InvImage As String
    Dim FirstDate, LastDate As Date
    Private InvoBrush As New SolidBrush(Color.Black)

    'All form related events
    Private Sub frm_Load(sender As Object, e As EventArgs) Handles Me.Load
        booEdit = False
        Call AddOptions()
        booInitial = True
        opt_Select(0).Checked = True 'Fill recordset with data

        If RecordCount = 0 Then
            frm_Message.Text = "11:1:0:10:2:There are no purchase orders to schedule at this time"
            frm_Message.ShowDialog()
            Me.Close()
            Exit Sub
        End If

        ReDim SaveArray(RecordCount - 1)
        booInitial = False

        'Set red and blue line limits
        HScroll_BlueLine.Minimum = 1
        HScroll_RedLine.Maximum = RecordCount + 8
        HScroll_BlueLine.Maximum = RecordCount + 9
        HScroll_RedLine.SmallChange = 1
        HScroll_BlueLine.SmallChange = 1
        HScroll_RedLine.LargeChange = 10
        HScroll_BlueLine.LargeChange = 10
        HScroll_RedLine.Value = 0
        HScroll_BlueLine.Value = 1

        'Set page scroll limits if needed
        If RecordCount > 25 Then
            Me.Width = 1414 '1468
            Label_Banner2.Width = 1381 '1435
            fra_Edits.Width = 391 '445
            lbl_Message1.Left = 5
            lbl_Message2.Left = 5
            fra_CmdButtons.Left = 38 '65
            VScrollBar1.Visible = True
            VScrollBar1.Enabled = True
            VScrollBar1.Minimum = 0
            VScrollBar1.Maximum = RecordCount - 25
            VScrollBar1.SmallChange = 1
            VScrollBar1.LargeChange = 1
        Else
            Me.Width = 1399 '1453
            Label_Banner2.Width = 1366 '1420
            fra_Edits.Width = 376 '430
            VScrollBar1.Visible = False
            lbl_Message1.Left = 2
            lbl_Message1.Left = 372
            lbl_Message2.Left = 2
            lbl_Message1.Width = 372
            fra_CmdButtons.Left = 4 '58
        End If

        Call AddControls()
        Call FormFill()
        Call CalculateTotals()
        Call HScrollTotal()
        Call cmd_ActionReset()

        FirstDate = tbox_DueDate(0).Text
        LastDate = tbox_DueDate(RecordCount - 1).Text
    End Sub
    Private Sub frm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.Text = "Customer's Work Schedule                                                                                                                                           Date: " & Now.Date

        'Retrieve system values
        strSQL = "SELECT CompanyName,SystemPrinter,Buffer FROM System;"
        dbDataSet_SystemData.Clear()
        dbDataSet_SystemData.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter_SystemData = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter_SystemData.Fill(dbDataSet_SystemData, "SystemData")
        gbl_DstConnect.Close()

        Company = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(0) 'Company Name 
        SystemPrinter = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(1) 'System printer name
        Buffer = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(2) 'Printer buffer
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
    Private Sub opt_CheckedChanged(sender As Object, e As EventArgs)
        If sender.checked = False Then Exit Sub 'Do nothing on the unchecking of an option
        Cursor.Current = Cursors.WaitCursor
        EnableOperations(False)

        strSQL = "SELECT Id,Invoice.CustCode,Company,PurchaseOrder,POItem,DrawingNumber,DrawingRevision,OrderDate,DueDate,QtyOrdered,Price,PreShipDays " _
                 & "FROM Invoice INNER JOIN Customers ON Invoice.CustCode = Customers.CustCode " _
                 & "Where InvoiceDate is Null "

        Select Case sender.tag
            Case 0 : strSQL = strSQL & "ORDER BY Duedate,Company,PurchaseOrder,DrawingNumber;"
            Case 1 : strSQL = strSQL & "ORDER BY OrderDate,Company,PurchaseOrder,DrawingNumber;"
            Case 2 : strSQL = strSQL & "ORDER BY Company,PurchaseOrder,DrawingNumber,Duedate;"
            Case 3 : strSQL = strSQL & "ORDER BY PurchaseOrder,DrawingNumber,Duedate;"
            Case 4 : strSQL = strSQL & "ORDER BY DrawingNumber,Duedate;"
            Case 5 : strSQL = strSQL & "ORDER BY DrawingRevision,DrawingNumber,Duedate;"
            Case 6 : strSQL = strSQL & "ORDER BY QtyOrdered,DrawingNumber;"
            Case 7 : strSQL = strSQL & "ORDER BY Price,DrawingNumber;"
        End Select

        dbDataSet.Clear()
        dbDataSet.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter.Fill(dbDataSet, "Data")
        gbl_DstConnect.Close()
        RecordCount = dbDataSet.Tables("Data").Rows.Count()
        If RecordCount = 0 Then Exit Sub

        If booInitial = False Then
            Call ScrollReset()
            Call FormFill()
        End If
        EnableOperations(True)
    End Sub
    Private Sub AddOptions()
        'Create array of radiobuttons in frame options
        For i = 0 To 7
            opt_Select(i) = New RadioButton
            With opt_Select(i)
                .Name = "opt_Select"
                If i = 0 Then .Text = "Due Date" : .SetBounds(13, 16, 99, 17)
                If i = 1 Then .Text = "Order Date" : .SetBounds(13, 40, 99, 17)
                If i = 2 Then .Text = "Customer Name" : .SetBounds(13, 64, 99, 17)
                If i = 3 Then .Text = "Purchase Order" : .SetBounds(13, 88, 99, 17)
                If i = 4 Then .Text = "Drawing No." : .SetBounds(123, 16, 99, 17)
                If i = 5 Then .Text = "Drawing Rev" : .SetBounds(123, 40, 99, 17)
                If i = 6 Then .Text = "Quantity's" : .SetBounds(123, 64, 99, 17)
                If i = 7 Then .Text = "Item Price" : .SetBounds(123, 88, 99, 17)
                .Tag = i
                .Visible = True
                fra_Options.Controls.Add(opt_Select(i))
                AddHandler .CheckedChanged, AddressOf opt_CheckedChanged
            End With
        Next
    End Sub
    Private Sub AddControls() 'Add date and quantity controls

        Dim intTop As Integer
        Dim i As Integer

        ReDim lbl_Item(RecordCount)
        ReDim lbl_Company(RecordCount)
        ReDim tbox_PurchaseOrder(RecordCount)
        ReDim tbox_POItem(RecordCount)
        ReDim tbox_DrawNumber(RecordCount)
        ReDim tbox_DrawRev(RecordCount)
        ReDim tbox_OrderDate(RecordCount)
        ReDim tbox_DueDate(RecordCount)
        ReDim lbl_ShipDate(RecordCount)
        ReDim tbox_QtyOrder(RecordCount)
        ReDim tbox_Price(RecordCount)
        ReDim lbl_TotalPrice(RecordCount)
        ReDim lbl_Inventory(RecordCount)
        ReDim lbl_Surplus(RecordCount)
        ReDim lbl_ID(RecordCount)
        ReDim lbl_CustCode(RecordCount)

        'Create array of controls in frame information
        intTop = -6
        For i = 0 To RecordCount - 1
            intTop = intTop + 25
            lbl_Item(i) = New Label
            lbl_ID(i) = New Label
            lbl_Company(i) = New Label
            tbox_PurchaseOrder(i) = New TextBox
            tbox_POItem(i) = New TextBox
            tbox_DrawNumber(i) = New TextBox
            tbox_DrawRev(i) = New TextBox
            tbox_OrderDate(i) = New MaskedTextBox
            tbox_DueDate(i) = New MaskedTextBox
            lbl_ShipDate(i) = New Label
            tbox_QtyOrder(i) = New TextBox
            tbox_Price(i) = New TextBox
            lbl_TotalPrice(i) = New Label
            lbl_Inventory(i) = New Label
            lbl_Surplus(i) = New Label
            lbl_ID(i) = New Label
            lbl_CustCode(i) = New Label

            With lbl_ID(i)
                .Name = "lbl_ID"
                .Tag = i
                .Visible = False
                fra_Information.Controls.Add(lbl_ID(i))
            End With

            With lbl_CustCode(i)
                .Name = "lbl_CustCode"
                .Tag = i
                .Visible = False
                fra_Information.Controls.Add(lbl_CustCode(i))
            End With

            With lbl_Item(i)
                .Name = "lbl_Item"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .Visible = True
                .SetBounds(15, intTop, 25, 20)
                fra_Information.Controls.Add(lbl_Item(i))
            End With

            With lbl_Company(i)
                .Name = "lbl_Company"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .Visible = True
                .SetBounds(55, intTop, 191, 20)
                fra_Information.Controls.Add(lbl_Company(i))
            End With

            With tbox_PurchaseOrder(i)
                .Name = "tbox_PurchaseOrder"
                .Tag = i
                .Enabled = False
                .BackColor = Color.White
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(261, intTop, 150, 20)
                fra_Information.Controls.Add(tbox_PurchaseOrder(i))
                AddHandler .GotFocus, AddressOf tbox_GotFocus
                AddHandler .LostFocus, AddressOf tbox_LostFocus
                AddHandler .TextChanged, AddressOf tbox_TextChanged
                AddHandler .KeyPress, AddressOf tbox_KeyPress
            End With

            With tbox_POItem(i)
                .Name = "tbox_POItem"
                .Tag = i
                .Enabled = False
                .BackColor = Color.White
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BorderStyle = BorderStyle.None
                .MaxLength = 2
                .Visible = True
                .SetBounds(426, intTop, 40, 20)
                fra_Information.Controls.Add(tbox_POItem(i))
                AddHandler .GotFocus, AddressOf tbox_GotFocus
                AddHandler .LostFocus, AddressOf tbox_LostFocus
                AddHandler .TextChanged, AddressOf tbox_TextChanged
                AddHandler .KeyPress, AddressOf tbox_KeyPress
                AddHandler .MouseHover, AddressOf All_MouseHover
            End With

            With tbox_DrawNumber(i)
                .Name = "tbox_DrawNumber"
                .Tag = i
                .Enabled = False
                .BackColor = Color.White
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(481, intTop, 125, 20)
                fra_Information.Controls.Add(tbox_DrawNumber(i))
                AddHandler .GotFocus, AddressOf tbox_GotFocus
                AddHandler .LostFocus, AddressOf tbox_LostFocus
                AddHandler .TextChanged, AddressOf tbox_TextChanged
                AddHandler .KeyPress, AddressOf tbox_KeyPress
            End With

            With tbox_DrawRev(i)
                .Name = "tbox_DrawRev"
                .Tag = i
                .Enabled = False
                .BackColor = Color.White
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BorderStyle = BorderStyle.None
                .MaxLength = 2
                .Visible = True
                .SetBounds(621, intTop, 40, 20)
                fra_Information.Controls.Add(tbox_DrawRev(i))
                AddHandler .GotFocus, AddressOf tbox_GotFocus
                AddHandler .LostFocus, AddressOf tbox_LostFocus
                AddHandler .TextChanged, AddressOf tbox_TextChanged
                AddHandler .KeyPress, AddressOf tbox_KeyPress
            End With

            With tbox_OrderDate(i)
                .Name = "tbox_OrderDate"
                .Tag = i
                .Enabled = False
                .BackColor = Color.White
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BorderStyle = BorderStyle.None
                .Mask = ("##/##/####")
                .Visible = True
                .SetBounds(676, intTop, 70, 20)
                fra_Information.Controls.Add(tbox_OrderDate(i))
                AddHandler .GotFocus, AddressOf tbox_GotFocus
                AddHandler .LostFocus, AddressOf tbox_LostFocus
                AddHandler .TextChanged, AddressOf tbox_TextChanged
                AddHandler .KeyPress, AddressOf tbox_KeyPress
                AddHandler .MouseClick, AddressOf tbox_MouseClick
            End With

            With tbox_DueDate(i)
                .Name = "tbox_DueDate"
                .Tag = i
                .Enabled = False
                .BackColor = Color.White
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BorderStyle = BorderStyle.None
                .Mask = ("##/##/####")
                .Visible = True
                .SetBounds(761, intTop, 70, 20)
                fra_Information.Controls.Add(tbox_DueDate(i))
                AddHandler .GotFocus, AddressOf tbox_GotFocus
                AddHandler .LostFocus, AddressOf tbox_LostFocus
                AddHandler .TextChanged, AddressOf tbox_TextChanged
                AddHandler .KeyPress, AddressOf tbox_KeyPress
                AddHandler .MouseClick, AddressOf tbox_MouseClick
            End With

            With lbl_ShipDate(i)
                .Name = "lbl_ShipDate"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .Visible = True
                .SetBounds(846, intTop, 70, 20)
                fra_Information.Controls.Add(lbl_ShipDate(i))
            End With

            With tbox_QtyOrder(i)
                .Name = "tbox_QtyOrder"
                .Tag = i
                .Enabled = False
                .BackColor = Color.White
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(931, intTop, 65, 20)
                fra_Information.Controls.Add(tbox_QtyOrder(i))
                AddHandler .GotFocus, AddressOf tbox_GotFocus
                AddHandler .LostFocus, AddressOf tbox_LostFocus
                AddHandler .TextChanged, AddressOf tbox_TextChanged
                AddHandler .KeyPress, AddressOf tbox_KeyPress
            End With

            With tbox_Price(i)
                .Name = "tbox_Price"
                .Tag = i
                .Enabled = False
                .BackColor = Color.White
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(1011, intTop, 70, 20)
                fra_Information.Controls.Add(tbox_Price(i))
                AddHandler .GotFocus, AddressOf tbox_GotFocus
                AddHandler .LostFocus, AddressOf tbox_LostFocus
                AddHandler .TextChanged, AddressOf tbox_TextChanged
                AddHandler .KeyPress, AddressOf tbox_KeyPress
            End With

            With lbl_TotalPrice(i)
                .Name = "lbl_TotalPrice"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .Visible = True
                .SetBounds(1096, intTop, 80, 20)
                fra_Information.Controls.Add(lbl_TotalPrice(i))
            End With

            With lbl_Inventory(i)
                .Name = "lbl_Inventory"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .Visible = True
                .SetBounds(1191, intTop, 75, 20)
                fra_Information.Controls.Add(lbl_Inventory(i))
            End With

            With lbl_Surplus(i)
                .Name = "lbl_Surplus"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .Visible = True
                .SetBounds(1281, intTop, 65, 20)
                fra_Information.Controls.Add(lbl_Surplus(i))
            End With

        Next
        fra_Information.Height = intTop + 30
    End Sub
    Private Sub FormFill() 'Fill form with data pertaining to listbox selection

        'Fill form with data
        Dim ShipDays As Integer
        For intStep = 0 To RecordCount - 1

            lbl_Item(intStep).Text = intStep + 1 'Item number
            lbl_ID(intStep).Text = Trim(dbDataSet.Tables("Data").Rows(intStep).Item(0))

            If Not IsDBNull(dbDataSet.Tables("Data").Rows(intStep).Item(1)) Then 'Custcode
                lbl_CustCode(intStep).Text = Trim(dbDataSet.Tables("Data").Rows(intStep).Item(1))
            Else : lbl_CustCode(intStep).Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("Data").Rows(intStep).Item(2)) Then 'Company Name
                lbl_Company(intStep).Text = StrConv(LCase(Trim(dbDataSet.Tables("Data").Rows(intStep).Item(2))), VbStrConv.ProperCase)
            Else : lbl_Company(intStep).Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("Data").Rows(intStep).Item(3)) Then 'Purchase Order
                tbox_PurchaseOrder(intStep).Text = Trim(dbDataSet.Tables("Data").Rows(intStep).Item(3))
            Else : tbox_PurchaseOrder(intStep).Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("Data").Rows(intStep).Item(4)) Then 'Purchase Order line item number
                tbox_POItem(intStep).Text = Trim(dbDataSet.Tables("Data").Rows(intStep).Item(4))
            Else : tbox_POItem(intStep).Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("Data").Rows(intStep).Item(5)) Then 'Drawing Number
                tbox_DrawNumber(intStep).Text = Trim(dbDataSet.Tables("Data").Rows(intStep).Item(5))
            Else : tbox_DrawNumber(intStep).Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("Data").Rows(intStep).Item(6)) Then 'Drawing Revision
                tbox_DrawRev(intStep).Text = Trim(dbDataSet.Tables("Data").Rows(intStep).Item(6))
            Else : tbox_DrawRev(intStep).Text = "" : End If


            If Not IsDBNull(dbDataSet.Tables("Data").Rows(intStep).Item(7)) And dbDataSet.Tables("Data").Rows(intStep).Item(7).ToString <> "#12/12/1212#" Then 'Order Date
                tbox_OrderDate(intStep).Text = Format(dbDataSet.Tables("Data").Rows(intStep).Item(7), "MM/dd/yyyy")
            Else : tbox_OrderDate(intStep).Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("Data").Rows(intStep).Item(8)) And dbDataSet.Tables("Data").Rows(intStep).Item(8).ToString <> "#12/12/1212#" Then 'Due Date
                tbox_DueDate(intStep).Text = Format(dbDataSet.Tables("Data").Rows(intStep).Item(8), "MM/dd/yyyy")
                If Not IsDBNull(dbDataSet.Tables("Data").Rows(intStep).Item(11)) Then 'Pre Ship Days
                    ShipDays = 0 - Trim(dbDataSet.Tables("Data").Rows(intStep).Item(11))
                    lbl_ShipDate(intStep).Text = Format(DateAdd("d", ShipDays, tbox_DueDate(intStep).Text), "MM/dd/yyyy") 'Ship Date
                Else : lbl_ShipDate(intStep).Text = tbox_DueDate(intStep).Text : End If
                If lbl_ShipDate(intStep).Text <= Now.Date Then lbl_ShipDate(intStep).ForeColor = Color.DarkGreen
            Else : tbox_DueDate(intStep).Text = "" : lbl_ShipDate(intStep).Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("Data").Rows(intStep).Item(9)) Then 'Quantity Ordered
                tbox_QtyOrder(intStep).Text = Trim(dbDataSet.Tables("Data").Rows(intStep).Item(9))
            Else : tbox_QtyOrder(intStep).Text = "" : End If

            'Locate inventory for line item
            If lbl_CustCode(intStep).Text <> "" And tbox_DrawNumber(intStep).Text <> "" And tbox_DrawRev(intStep).Text <> "" Then
                Call Inventory(intStep)
            Else
                lbl_Inventory(intStep).Text = "0" 'Inventory
                lbl_Surplus(intStep).Text = "0" 'Surplus
            End If

            If Not IsDBNull(dbDataSet.Tables("Data").Rows(intStep).Item(10)) Then 'Price
                tbox_Price(intStep).Text = FormatCurrency(Trim(dbDataSet.Tables("Data").Rows(intStep).Item(10)))
            Else : tbox_Price(intStep).Text = "" : End If

            If tbox_Price(intStep).Text <> "" And tbox_QtyOrder(intStep).Text <> "" Then
                lbl_TotalPrice(intStep).Text = FormatCurrency(tbox_Price(intStep).Text * tbox_QtyOrder(intStep).Text) 'Total Price
            End If

        Next
    End Sub
    Private Sub Inventory(row As Integer)

        strSQL = "SELECT DrawNumber,Revision,Quantity FROM Inventory WHERE CustCode = " & lbl_CustCode(row).Text & " And " _
               & "DrawNumber = '" & tbox_DrawNumber(row).Text & "' And Revision = '" & tbox_DrawRev(row).Text & "'"
        dbDataSet_Misc.Clear()
        dbDataSet_Misc.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter_Misc.Fill(dbDataSet_Misc, "Inventory")
        gbl_DstConnect.Close()

        lbl_Inventory(row).Text = "" 'Inventory
        lbl_Surplus(row).Text = "" 'Surplus

        If dbDataSet_Misc.Tables("Inventory").Rows.Count > 0 Then 'Inventory found for drawing number
            If row > 0 Then
                For i = row - 1 To 0 Step -1 'Check if previous entries used some of the inventory
                    If tbox_DrawNumber(i).Text = tbox_DrawNumber(row).Text Then 'Previous order with same item found
                        If lbl_Surplus(i).Text > 0 Then lbl_Inventory(row).Text = lbl_Surplus(i).Text Else lbl_Inventory(row).Text = "0"
                        lbl_Surplus(row).Text = lbl_Surplus(i).Text - tbox_QtyOrder(row).Text
                        Exit For
                    End If
                Next
                If lbl_Surplus(row).Text = "" Then 'No previous entries found
                    lbl_Inventory(row).Text = Trim(dbDataSet_Misc.Tables("Inventory").Rows(0).Item(2))
                    lbl_Surplus(row).Text = lbl_Inventory(row).Text - tbox_QtyOrder(row).Text
                End If
            Else '1st row ( no previous entries )
                lbl_Inventory(row).Text = Trim(dbDataSet_Misc.Tables("Inventory").Rows(0).Item(2))
                lbl_Surplus(row).Text = lbl_Inventory(row).Text - tbox_QtyOrder(row).Text
            End If

            'Set color to inventory text
            Dim Inventory As Integer = Convert.ToDecimal(lbl_Inventory(row).Text)
            Select Case Inventory
                Case Is = 0 : lbl_Inventory(row).ForeColor = Color.Black
                Case Is >= tbox_QtyOrder(row).Text : lbl_Inventory(row).ForeColor = Color.DarkGreen 'Show positive inventory green
                Case Is < tbox_QtyOrder(row).Text
                    If lbl_Inventory(row).Text > 0 Then
                        lbl_Inventory(row).ForeColor = Color.Blue 'Show not enough inventory Blue  
                    Else
                        lbl_Inventory(row).ForeColor = Color.Black 'Show not enough inventory Blue 
                    End If
            End Select

            'Set color to surplus/deficit text
            Select Case lbl_Surplus(row).Text
                Case Is >= 0 : lbl_Surplus(row).ForeColor = Color.Black 'Show positive surplus black
                Case Is < 0 : lbl_Surplus(row).ForeColor = Color.Red 'Show negative surplus red
            End Select

        Else
            lbl_Inventory(row).Text = "0" : lbl_Inventory(row).ForeColor = Color.Black 'Inventory
            lbl_Surplus(row).Text = "0" : lbl_Surplus(row).ForeColor = Color.Black 'Surplus
        End If
    End Sub
    Private Sub VScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles VScrollBar1.Scroll
        fra_Information.Top = -13 - (VScrollBar1.Value * 25)
    End Sub
    Private Sub CalculateTotals()
        Dim Total As Single = 0
        For intStep = 0 To RecordCount - 1
            If tbox_Price(intStep).Text <> "" And tbox_QtyOrder(intStep).Text <> "" Then
                Total = Total + tbox_Price(intStep).Text * tbox_QtyOrder(intStep).Text
            End If
        Next
        lbl_TotalValue.Text = FormatCurrency(Total)
        lbl_TotalOrders.Text = RecordCount
    End Sub   
    Private Sub EnableEdits(blnStatus As Boolean)
        For intStep = 0 To RecordCount - 1
            tbox_PurchaseOrder(intStep).Enabled = blnStatus
            tbox_PurchaseOrder(intStep).Enabled = blnStatus
            tbox_POItem(intStep).Enabled = blnStatus
            tbox_DrawNumber(intStep).Enabled = blnStatus
            tbox_DrawRev(intStep).Enabled = blnStatus
            tbox_OrderDate(intStep).Enabled = blnStatus
            tbox_DueDate(intStep).Enabled = blnStatus
            tbox_QtyOrder(intStep).Enabled = blnStatus
            tbox_Price(intStep).Enabled = blnStatus         
        Next
    End Sub
    Private Sub EnableOperations(blnStatus As Boolean)
        fra_Scrollbars.Enabled = blnStatus
        fra_Options.Enabled = blnStatus
        fra_Edits.Enabled = blnStatus
        VScrollBar1.Enabled = blnStatus
    End Sub
    Private Sub ClearSaveArray()
        For i = 0 To UBound(SaveArray) 'Reinitialize all elements of SaveArray back to -1
            If SaveArray(i) = -1 Then Exit For
            SaveArray(i) = -1
        Next
    End Sub
    Private Sub Restore()

        'Resore changed data to form data
        Dim row As Integer
        Dim ShipDays As Integer
        For intStep = 0 To UBound(SaveArray)
            If SaveArray(intStep) = -1 Then Exit For
            row = SaveArray(intStep)


            If Not IsDBNull(dbDataSet.Tables("Data").Rows(row).Item(3)) Then 'Purchase Order
                tbox_PurchaseOrder(row).Text = Trim(dbDataSet.Tables("Data").Rows(row).Item(3))
            Else : tbox_PurchaseOrder(row).Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("Data").Rows(row).Item(4)) Then 'Purchase Order line item number
                tbox_POItem(row).Text = Trim(dbDataSet.Tables("Data").Rows(row).Item(4))
            Else : tbox_POItem(row).Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("Data").Rows(row).Item(5)) Then 'Drawing Number
                tbox_DrawNumber(row).Text = Trim(dbDataSet.Tables("Data").Rows(row).Item(5))
            Else : tbox_DrawNumber(row).Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("Data").Rows(row).Item(6)) Then 'Drawing Revision
                tbox_DrawRev(row).Text = Trim(dbDataSet.Tables("Data").Rows(row).Item(6))
            Else : tbox_DrawRev(row).Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("Data").Rows(row).Item(7)) And dbDataSet.Tables("Data").Rows(row).Item(7).ToString <> "#12/12/1212#" Then 'Order Date
                tbox_OrderDate(row).Text = Format(dbDataSet.Tables("Data").Rows(row).Item(7), "MM/dd/yyyy")
            Else : tbox_OrderDate(row).Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("Data").Rows(row).Item(8)) And dbDataSet.Tables("Data").Rows(row).Item(8).ToString <> "#12/12/1212#" Then 'Due Date
                tbox_DueDate(row).Text = Format(dbDataSet.Tables("Data").Rows(row).Item(8), "MM/dd/yyyy")
                If Not IsDBNull(dbDataSet.Tables("Data").Rows(row).Item(11)) Then 'Pre Ship Days
                    ShipDays = 0 - Trim(dbDataSet.Tables("Data").Rows(row).Item(11))
                    lbl_ShipDate(row).Text = Format(DateAdd("d", ShipDays, tbox_DueDate(row).Text), "MM/dd/yyyy") 'Ship Date
                Else : lbl_ShipDate(row).Text = tbox_DueDate(row).Text : End If
                If lbl_ShipDate(intStep).Text <= Now.Date Then lbl_ShipDate(intStep).ForeColor = Color.DarkGreen
            Else : tbox_DueDate(row).Text = "" : lbl_ShipDate(row).Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("Data").Rows(row).Item(9)) Then 'Quantity Ordered
                tbox_QtyOrder(row).Text = Trim(dbDataSet.Tables("Data").Rows(row).Item(9))
            Else : tbox_QtyOrder(row).Text = "" : End If

            'Locate inventory for line item
            If lbl_CustCode(row).Text <> "" And tbox_DrawNumber(row).Text <> "" And tbox_DrawRev(row).Text <> "" Then
                strSQL = "SELECT DrawNumber,Revision,Quantity FROM Inventory WHERE CustCode = " & lbl_CustCode(row).Text & " And " _
                       & "DrawNumber = '" & tbox_DrawNumber(row).Text & "' And Revision = '" & tbox_DrawRev(row).Text & "'"
                dbDataSet_Misc.Clear()
                dbDataSet_Misc.Tables.Clear()
                gbl_DstConnect.Open()
                dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
                dbAdapter_Misc.Fill(dbDataSet_Misc, "Inventory")
                gbl_DstConnect.Close()

                If dbDataSet_Misc.Tables("Inventory").Rows.Count > 0 Then
                    lbl_Inventory(row).Text = Trim(dbDataSet_Misc.Tables("Inventory").Rows(0).Item(2))
                    lbl_Surplus(row).Text = lbl_Inventory(row).Text - tbox_QtyOrder(row).Text
                    If lbl_Surplus(row).Text < 0 Then lbl_Surplus(row).Text = 0
                Else
                    lbl_Inventory(row).Text = "0" 'Inventory
                    lbl_Surplus(row).Text = "0" 'Surplus
                End If
            Else
                lbl_Inventory(row).Text = "0" 'Inventory
                lbl_Surplus(row).Text = "0" 'Surplus
            End If

            If Not IsDBNull(dbDataSet.Tables("Data").Rows(row).Item(10)) Then 'Price
                tbox_Price(row).Text = FormatCurrency(Trim(dbDataSet.Tables("Data").Rows(row).Item(10)))
            Else : tbox_Price(row).Text = "" : End If

            If tbox_Price(row).Text <> "" And tbox_QtyOrder(row).Text <> "" Then
                lbl_TotalPrice(row).Text = FormatCurrency(tbox_Price(row).Text * tbox_QtyOrder(row).Text) 'Total Price
            End If
        Next
        Call CalculateTotals()
        Call HScrollTotal()
    End Sub

    'All scroll handlers
    Private Sub ScrollReset()
        VScrollBar1.Value = 0 'Reset vertical scroll to zero so first items show on startup
        HScroll_RedLine.Value = 0 'Reset red horizontal scroll bar to startup position
        Call HScroll_RedLine_Scroll()
        HScroll_BlueLine.Value = 1 'Reset blue horizontal scroll bar to startup position
        Call HScroll_BlueLine_Scroll()
    End Sub
    Private Sub HScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles HScroll_RedLine.Scroll, HScroll_BlueLine.Scroll
        Select Case sender.name
            Case "HScroll_RedLine" : Call HScroll_RedLine_Scroll()
            Case "HScroll_BlueLine" : Call HScroll_BlueLine_Scroll()
        End Select
        Call HScrollTotal()
    End Sub
    Private Sub HScroll_RedLine_Scroll()
        Line_Red.Y1 = 25 * HScroll_RedLine.Value
        Line_Red.Y2 = 25 * HScroll_RedLine.Value

        'Red line cannot pass blue line
        If HScroll_RedLine.Value >= HScroll_BlueLine.Value Then
            HScroll_BlueLine.Value = HScroll_RedLine.Value + 1
            Line_Blue.Y1 = 25 * HScroll_BlueLine.Value
            Line_Blue.Y2 = 25 * HScroll_BlueLine.Value
        End If
    End Sub
    Private Sub HScroll_BlueLine_Scroll()
        Line_Blue.Y1 = 25 * HScroll_BlueLine.Value
        Line_Blue.Y2 = 25 * HScroll_BlueLine.Value

        'Blue line cannot pass blue line
        If HScroll_BlueLine.Value <= HScroll_RedLine.Value Then
            HScroll_RedLine.Value = HScroll_BlueLine.Value - 1
            Line_Red.Y1 = 25 * HScroll_RedLine.Value
            Line_Red.Y2 = 25 * HScroll_RedLine.Value
        End If

    End Sub
    Private Sub HScrollTotal()

        Dim intStep As Integer
        Dim ccyRedLineTotal As Single = 0
        Dim ccyBlueLineTotal As Single = 0

        intStep = 0
        If HScroll_RedLine.Value > 1 Then 'Skip redline total if redline at zero
            For intStep = 0 To HScroll_RedLine.Value - 1 'Calculate total value of orders above red line
                ccyRedLineTotal = ccyRedLineTotal + lbl_TotalPrice(intStep).Text
            Next
        Else : ccyRedLineTotal = 0
        End If

        intStep = 0
        For intStep = 0 To HScroll_BlueLine.Value - 1 'Calculate total value of orders above blue line
            ccyBlueLineTotal = ccyBlueLineTotal + lbl_TotalPrice(intStep).Text
        Next

        lbl_LineValue.Text = FormatCurrency(ccyBlueLineTotal - ccyRedLineTotal)
        lbl_LineOrders.Text = HScroll_BlueLine.Value - HScroll_RedLine.Value
    End Sub

    'All command actions ( Edit,Restore,Exit,Invoice/Print,Next )
    Private Sub cmd_Actions_Click(sender As Object, e As EventArgs) Handles cmd_1.Click, cmd_2.Click, cmd_3.Click, cmd_Print.Click
        If Cursor.Current = Cursors.WaitCursor Then Exit Sub
        On Error GoTo goActionErr

        'Hide mouse messages
        lbl_Message1.Text = ""

        Cursor.Current = Cursors.WaitCursor
        Select Case sender.text
            Case "Cancel"
                booEdit = False
                EnableEdits(False) 'Disable form editing 
                If cmd_1.Text = "Restore" Then Call Restore() 'Restore form only if changed
                cmd_Print.Enabled = True
                Call ClearSaveArray()
                Call cmd_ActionReset()
                fra_Options.Enabled = True

            Case "Edit"
                booEdit = True
                EnableEdits(True) 'Enable form editing
                cmd_1.Enabled = False
                cmd_2.Text = "Cancel"
                cmd_2.Enabled = True
                cmd_Print.Enabled = False
                fra_Options.Enabled = False
                tbox_PurchaseOrder(0).Focus()
                Call ClearSaveArray()

            Case "Exit"
                Cursor.Current = Cursors.Default
                Me.Close()
                Exit Sub

            Case "Print"
                Pages = Math.Ceiling(RecordCount / 40)
                PageNumber = 1
                PrintForms = New PrintDocument
                PrintForms.PrinterSettings.PrinterName = SystemPrinter
                PrintForms.Print()

            Case "Restore"
                booEdit = False
                Call Restore()
                Call ClearSaveArray()
                cmd_1.Text = "Edit"
                cmd_1.Enabled = False
                cmd_2.Enabled = False
                cmd_2.Text = "Cancel"
                cmd_2.Enabled = True
                cmd_3.Text = "Exit"
                booEdit = True

            Case "Save"

                'Validate changed edits
                For i = 0 To UBound(SaveArray)
                    If SaveArray(i) = -1 Then Exit For

                    If Trim(tbox_PurchaseOrder(SaveArray(i)).Text) = "" Then
                        tbox_PurchaseOrder(SaveArray(i)).BackColor = Color.Aqua
                        frm_Message.Text = "11:1:0:1:2:Items Purchase Order number must be entered to continue"
                        frm_Message.ShowDialog()
                        tbox_PurchaseOrder(SaveArray(i)).BackColor = Color.White
                        tbox_PurchaseOrder(SaveArray(i)).Focus()
                        Exit Sub
                    End If

                    If Trim(tbox_DrawNumber(SaveArray(i)).Text) = "" Then
                        tbox_DrawNumber(SaveArray(i)).BackColor = Color.Aqua
                        frm_Message.Text = "11:1:0:1:2:Items Drawing number must be entered to continue"
                        frm_Message.ShowDialog()
                        tbox_DrawNumber(SaveArray(i)).BackColor = Color.White
                        tbox_DrawNumber(SaveArray(i)).Focus()
                        Exit Sub
                    End If

                    If Trim(tbox_OrderDate(SaveArray(i)).Text) = "/  /" Then
                        tbox_OrderDate(SaveArray(i)).BackColor = Color.Aqua
                        frm_Message.Text = "11:1:0:1:2:Items Order date must be entered to continue"
                        frm_Message.ShowDialog()
                        tbox_OrderDate(SaveArray(i)).BackColor = Color.White
                        tbox_OrderDate(SaveArray(i)).Focus()
                        Exit Sub
                    End If

                    Dim str1 As String = Trim(tbox_DrawNumber(SaveArray(i)).Text)
                    If Trim(tbox_DueDate(SaveArray(i)).Text) = "/  /" Then
                        tbox_DueDate(SaveArray(i)).BackColor = Color.Aqua
                        frm_Message.Text = "11:1:0:1:2:Items Due date must be entered to continue"
                        frm_Message.ShowDialog()
                        tbox_DueDate(SaveArray(i)).BackColor = Color.White
                        tbox_DueDate(SaveArray(i)).Focus()
                        Exit Sub
                    End If

                    If Trim(tbox_QtyOrder(SaveArray(i)).Text) = "" Or Trim(tbox_QtyOrder(SaveArray(i)).Text) = "0" Then
                        tbox_QtyOrder(SaveArray(i)).BackColor = Color.Aqua
                        frm_Message.Text = "11:1:0:1:2:Items Quantity must be entered to continue"
                        frm_Message.ShowDialog()
                        tbox_QtyOrder(SaveArray(i)).BackColor = Color.White
                        tbox_QtyOrder(SaveArray(i)).Focus()
                        Exit Sub
                    End If

                    If Trim(tbox_Price(SaveArray(i)).Text) = "" Then
                        tbox_Price(SaveArray(i)).BackColor = Color.Aqua
                        frm_Message.Text = "11:1:0:1:2:Items Price must be entered to continue"
                        frm_Message.ShowDialog()
                        tbox_Price(SaveArray(i)).BackColor = Color.White
                        tbox_Price(SaveArray(i)).Focus()
                        Exit Sub
                    End If
                Next

                Dim Selected As Integer
                For Selected = 0 To 7
                    If opt_Select(Selected).Checked = True Then opt_Select(Selected).Checked = False : Exit For
                Next

                'Save changed edits
                Dim Price As Single
                For i = 0 To UBound(SaveArray)

                    If SaveArray(i) = -1 Then Exit For

                    strSQL = "SELECT ID,PurchaseOrder,POItem,DrawingNumber,DrawingRevision,OrderDate,DueDate,QtyOrdered,Price " _
                           & "FROM Invoice where ID = " & lbl_ID(SaveArray(i)).Text & ";"
                    dbDataSet_Misc.Clear()
                    dbDataSet_Misc.Tables.Clear()
                    gbl_DstConnect.Open()
                    dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
                    dbAdapter_Misc.Fill(dbDataSet_Misc, "DataSave")
                    gbl_DstConnect.Close()

                    If dbDataSet_Misc.Tables("DataSave").Rows.Count() > 0 Then
                        Dim cb0 As New OleDb.OleDbCommandBuilder(dbAdapter_Misc)
                        dbDataSet_Misc.Tables("DataSave").Rows(0).Item(1) = Trim(tbox_PurchaseOrder(SaveArray(i)).Text)
                        If Trim(tbox_POItem(SaveArray(i)).Text) <> "" And Trim(tbox_POItem(SaveArray(i)).Text) <> "0" Then
                            dbDataSet_Misc.Tables("DataSave").Rows(0).Item(2) = Convert.ToInt32(Trim(tbox_POItem(SaveArray(i)).Text))
                        Else : dbDataSet_Misc.Tables("DataSave").Rows(0).Item(2) = DBNull.Value : End If
                        dbDataSet_Misc.Tables("DataSave").Rows(0).Item(3) = Trim(tbox_DrawNumber(SaveArray(i)).Text)
                        dbDataSet_Misc.Tables("DataSave").Rows(0).Item(4) = Trim(tbox_DrawRev(SaveArray(i)).Text)
                        dbDataSet_Misc.Tables("DataSave").Rows(0).Item(5) = tbox_OrderDate(SaveArray(i)).Text
                        dbDataSet_Misc.Tables("DataSave").Rows(0).Item(6) = tbox_DueDate(SaveArray(i)).Text
                        dbDataSet_Misc.Tables("DataSave").Rows(0).Item(7) = Convert.ToInt32(Trim(tbox_QtyOrder(SaveArray(i)).Text))
                        Price = Trim(tbox_Price(SaveArray(i)).Text)
                        dbDataSet_Misc.Tables("DataSave").Rows(0).Item(8) = Price
                        dbAdapter_Misc.Update(dbDataSet_Misc, "DataSave")
                        cb0 = Nothing
                    End If
                Next
                booEdit = False
                EnableEdits(False)
                opt_Select(Selected).Checked = True
                Call cmd_ActionReset()
                cmd_Print.Enabled = True
                Call ClearSaveArray()
                cmd_Print.Enabled = True

        End Select
        Cursor.Current = Cursors.Default
        Exit Sub
goActionErr:
        MsgBox(Err.Description)
        Exit Sub
    End Sub
    Private Sub cmd_ActionReset()
        cmd_1.Text = "Edit"
        cmd_1.Enabled = True
        ' cmd_1.Image = My.Resources.Resources._New
        cmd_2.Text = "Cancel"
        cmd_2.Enabled = False
        ' cmd_2.Image = My.Resources.Resources._Cancel
        cmd_3.Text = "Exit"
        ' cmd_3.Image = My.Resources.Resources._Exit
    End Sub
    Private Sub PrintForms_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintForms.PrintPage

        'Setup hard margins for printer
        Dim hDC As IntPtr = e.Graphics.GetHdc()
        Dim CurrentX, CurrentY, TextX, TextY, TextLen As Integer
        Dim HardX1, HardX2, HardY1, HardY2, HardWidth, HardHeight As Integer
        Dim Font As Font
        Dim Text As String
        Dim points() As Point
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

        Font = New Font("Swis721 BlkOul BT", 21, FontStyle.Regular) 'Print Work Schedule
        e.Graphics.DrawString("Work Schedule", Font, InvoBrush, HardX1 + 280, HardY1 + 24)

        Font = New Font("Ariel", 18, FontStyle.Regular) 'Print Workschedule Dates
        Text = FirstDate & " ---------------- " & LastDate
        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
        TextX = HardX1 + (HardWidth - TextLen) / 2
        e.Graphics.DrawString(Text, Font, InvoBrush, TextX, HardY1 + 107)

        'Print Lower form graphics
        Font = New Font("Arial", 9, FontStyle.Bold)
        Using the_pen As New Pen(Color.Black, 1)
            points = {New Point(HardX1, HardY1), New Point(HardX2, HardY1), New Point(HardX2, HardY2), New Point(HardX1, HardY2)} 'Outside rectangle
            e.Graphics.DrawPolygon(the_pen, points)

            points = {New Point(HardX1, HardY1 + 187), New Point(HardX2, HardY1 + 187)} '1st horzontal Line
            e.Graphics.DrawLines(the_pen, points)

            CurrentY = HardY1 + 190
            points = {New Point(HardX1, CurrentY), New Point(HardX2, CurrentY)} '2nd horzontal Line
            e.Graphics.DrawLines(the_pen, points)

            Text = "Item"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = HardX1 + (38 - TextLen) / 2
            TextY = CurrentY + 17
            e.Graphics.DrawString(Text, Font, InvoBrush, TextX, TextY) 'Print label Item

            CurrentX = HardX1 + 38
            points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 862)} '1st upper vertical line
            e.Graphics.DrawLines(the_pen, points)

            Text = "Customer Name"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (214 - TextLen) / 2 '274
            e.Graphics.DrawString(Text, Font, InvoBrush, TextX, TextY) 'Print label Customer Name

            CurrentX = HardX1 + 252 '312
            points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 862)} '2nd upper vertical line
            e.Graphics.DrawLines(the_pen, points)

            Text = "P.O."
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (174 - TextLen) / 2 '114
            e.Graphics.DrawString(Text, Font, InvoBrush, TextX, TextY - 15) 'Print label P.O.

            Text = "Number"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (174 - TextLen) / 2 '114
            e.Graphics.DrawString(Text, Font, InvoBrush, TextX, TextY) 'Print label Number

            CurrentX = HardX1 + 426
            points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 862)} '3rd upper vertical line
            e.Graphics.DrawLines(the_pen, points)

            Text = "P.O."
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + 1 + (42 - TextLen) / 2
            e.Graphics.DrawString(Text, Font, InvoBrush, TextX, TextY - 15) 'Print P.O.

            Text = "N0"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (42 - TextLen) / 2
            e.Graphics.DrawString(Text, Font, InvoBrush, TextX, TextY) 'Print label No

            CurrentX = HardX1 + 468
            points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 862)} '4th upper vertical line
            e.Graphics.DrawLines(the_pen, points)

            Text = "Drawing"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (114 - TextLen) / 2
            e.Graphics.DrawString(Text, Font, InvoBrush, TextX, TextY - 15) 'Print label Drawing

            Text = "Number"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (114 - TextLen) / 2
            e.Graphics.DrawString(Text, Font, InvoBrush, TextX, TextY) 'Print label Number

            CurrentX = HardX1 + 582
            points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 862)} '5th upper vertical line
            e.Graphics.DrawLines(the_pen, points)

            Text = "Drawing"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (62 - TextLen) / 2
            e.Graphics.DrawString(Text, Font, InvoBrush, TextX, TextY - 15) 'Print label Drawing

            Text = "Rev"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (62 - TextLen) / 2
            e.Graphics.DrawString(Text, Font, InvoBrush, TextX, TextY) 'Print label Number

            CurrentX = HardX1 + 644
            points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 862)} '6th upper vertical line
            e.Graphics.DrawLines(the_pen, points)

            Text = "Qty"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (82 - TextLen) / 2
            e.Graphics.DrawString(Text, Font, InvoBrush, TextX, TextY - 15) 'Print label Drawing

            Text = "Ordered"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (82 - TextLen) / 2
            e.Graphics.DrawString(Text, Font, InvoBrush, TextX, TextY) 'Print label Number

            CurrentX = HardX1 + 726
            points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 862)} '7th upper vertical line
            e.Graphics.DrawLines(the_pen, points)

            Text = "Due"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (78 - TextLen) / 2
            e.Graphics.DrawString(Text, Font, InvoBrush, TextX, TextY - 15) 'Print label Due

            Text = "Date"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (78 - TextLen) / 2
            e.Graphics.DrawString(Text, Font, InvoBrush, TextX, TextY) 'Print label date

            points = {New Point(HardX1, CurrentY + 31), New Point(HardX2, CurrentY + 31)} '3rd horzontal Line
            e.Graphics.DrawLines(the_pen, points)

        End Using ' the_pen 

        'Fill form with data
        CurrentY = HardY1 + 230

        If RecordCount > 40 Then 'Print page number
            Text = "Page " & PageNumber
            e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 735, HardY1 + 12)
        End If

        Font = New Font("Ariel", 26, FontStyle.Regular) 'Print Company Name
        Text = Company
        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
        TextX = HardX1 + (HardWidth - TextLen) / 2
        e.Graphics.DrawString(Text, Font, InvoBrush, TextX, HardY1 + 60)

        Dim Retract As Integer = 0
        If PageNumber = 1 Then PrintRow = 0
        Dim PageEnd As Integer = PrintRow + 39
        Font = New Font("Ariel", 9, FontStyle.Regular)
        For intStep = PrintRow To PageEnd

            'Print item number
            Text = lbl_Item(intStep).Text
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + (38 - TextLen) / 2, CurrentY)

            'Print company name
            Text = lbl_Company(intStep).Text
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 40 + (214 - TextLen) / 2, CurrentY) '274

            'Print purchase order
            Text = tbox_PurchaseOrder(intStep).Text
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 253 + (174 - TextLen) / 2, CurrentY) '312  (114

            'Print purchase order line number
            Text = tbox_POItem(intStep).Text
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 428 + (42 - TextLen) / 2, CurrentY)

            'Print drawing number
            Text = tbox_DrawNumber(intStep).Text
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 468 + (114 - TextLen) / 2, CurrentY)

            'Print drawing rev
            Text = tbox_DrawRev(intStep).Text
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 582 + (62 - TextLen) / 2, CurrentY)

            'Print quantity ordered
            Text = tbox_QtyOrder(intStep).Text
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 644 + (82 - TextLen) / 2, CurrentY)

            'Print due date
            Text = tbox_DueDate(intStep).Text
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 726 + (78 - TextLen) / 2, CurrentY)

            PrintRow = PrintRow + 1
            If PrintRow = RecordCount Then Exit For
            CurrentY = CurrentY + 20
        Next

        PageNumber += 1
        e.HasMorePages = PageNumber <= Pages
        If PageNumber > Pages Then PageNumber = 1 'Resets page count on print after dialog view of document

    End Sub


    'All control handlers
    Private Sub tbox_GotFocus(sender As Object, e As EventArgs)
        If booEdit = False Then Exit Sub
        varInitialEntry = Trim(sender.Text)
        sender.BackColor = (Color.FromArgb(255, 255, 192))
        If sender.name = "tbox_PurchaseOrder" Or sender.name = "tbox_DrawNumber" Or sender.name = "tbox_DrawRev" Then sender.CharacterCasing = CharacterCasing.Upper
    End Sub
    Private Sub tbox_LostFocus(sender As Object, e As EventArgs)
        If booEdit = False Then Exit Sub
        If sender.text = varInitialEntry Or booCorrection = True Then sender.BackColor = Color.White : Exit Sub

        'On textbox changes save list of items edited for quick saves and restores
        Select Case sender.name
            Case "tbox_PurchaseOrder", "tbox_POItem", "tbox_DrawNumber", "tbox_DrawRev", "tbox_OrderDate", "tbox_DueDate", "tbox_QtyOrder", "tbox_Price"
                If booChange = True Then 'On textbox changes save list of items edited for quick saves and restores
                    Dim wey As Integer = UBound(SaveArray)
                    For i = 0 To UBound(SaveArray)
                        If SaveArray(i) = sender.tag Then Exit For 'Index of changed data was previously saved
                        If SaveArray(i) = -1 Then SaveArray(i) = sender.tag : Exit For 'All unused elements of SaveArray were initialized to -1, (-1 then equals first unused element found)
                    Next
                    booChange = False
                End If
        End Select

        Select Case sender.Name
            Case "tbox_POItem", "tbox_QtyOrder", "tbox_Price"
                If sender.Text <> "" Then
                    If Not IsNumeric(sender.Text) Then
                        booCorrection = True
                        frm_Message.Text = "11:1:0:1:3:Invalid Entry --- Numerical entries are only allowed"
                        frm_Message.ShowDialog()
                        sender.text = ""
                        sender.Focus()
                        booCorrection = False
                        Exit Sub
                    End If
                    If sender.name = "tbox_QtyOrder" Or sender.name = "tbox_Price" Then
                        lbl_TotalPrice(sender.tag).Text = FormatCurrency(tbox_QtyOrder(sender.tag).Text * tbox_Price(sender.tag).Text)
                        Call CalculateTotals()
                        Call HScrollTotal()
                    End If
                End If
            Case "tbox_DrawNumber", "tbox_DrawRev"
                If sender.text <> "" Then 'Test entry for only letters
                    If sender.name = "tbox_DrawRev" Then
                        For i = 0 To sender.text.Length - 1
                            If Not UCase(sender.text(i)) Like "[ABCDEFGHIJKLMNOPQRSTUVWXYZ]" Then
                                booCorrection = True
                                frm_Message.Text = "11:1:0:1:2:Drawing Revisions can only contain letters"
                                frm_Message.ShowDialog()
                                sender.text = ""
                                sender.Focus()
                                booCorrection = False
                                Exit For
                            End If
                        Next
                    End If
                    Call Inventory(sender.tag) 'Locate inventory for new drawing number or revision change
                End If
            Case "tbox_OrderDate", "tbox_DueDate"
                If IsDate(sender.Text) = False And sender.Text <> "  /  /" Then
                    sender.BackColor = Color.Aqua
                    booCorrection = True
                    frm_Message.Text = "11:1:0:1:3:The date entered is not a valid date, Please enter a valid date"
                    frm_Message.ShowDialog()
                    sender.text = ""
                    sender.Focus()
                    booCorrection = False
                    Exit Sub
                End If
                If sender.name = "tbox_DueDate" Then
                    If tbox_DueDate(sender.tag).Text <> "  /  /" Then
                        If Not IsDBNull(dbDataSet.Tables("Data").Rows(sender.tag).Item(11)) Then 'Adjust ship date with pre ship days if used
                            Dim ShipDays As Integer = 0 - Trim(dbDataSet.Tables("Data").Rows(sender.tag).Item(11))
                            lbl_ShipDate(sender.tag).Text = Format(DateAdd("d", ShipDays, tbox_DueDate(sender.tag).Text), "MM/dd/yyyy")
                        Else : lbl_ShipDate(sender.tag).Text = tbox_DueDate(sender.tag).Text : End If
                    Else : lbl_ShipDate(sender.tag).Text = "" : End If
                End If
        End Select
        sender.BackColor = Color.White
    End Sub
    Private Sub tbox_TextChanged(sender As Object, e As EventArgs)
        If booEdit = False Then Exit Sub
        cmd_1.Text = "Restore"
        cmd_1.Enabled = True
        cmd_3.Text = "Save"
        booChange = True
        '  cmd_3.Image = My.Resources.Resources.Save
    End Sub
    Private Sub tbox_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Return) Then
            Select Case sender.name
                Case "tbox_PurchaseOrder" : tbox_POItem(sender.tag).Focus()
                Case "tbox_POItem" : tbox_DrawNumber(sender.tag).Focus()
                Case "tbox_DrawNumber" : tbox_DrawRev(sender.tag).Focus()
                Case "tbox_DrawRev" : tbox_OrderDate(sender.tag).Focus()
                Case "tbox_OrderDate" : tbox_DueDate(sender.tag).Focus()
                Case "tbox_DueDate" : tbox_QtyOrder(sender.tag).Focus()
                Case "tbox_QtyOrder" : tbox_Price(sender.tag).Focus()
                Case "tbox_Price"
                    If VScrollBar1.Visible = True Then
                        If sender.tag = RecordCount - 1 Then
                            tbox_PurchaseOrder(sender.tag - 24).Focus()
                        Else
                            If sender.tag = VScrollBar1.Value + 24 Then
                                tbox_PurchaseOrder(sender.tag - 24).Focus()
                            Else
                                tbox_PurchaseOrder(sender.tag + 1).Focus()
                            End If
                        End If
                    Else
                        If sender.tag = RecordCount - 1 Then tbox_PurchaseOrder(0).Focus() Else tbox_PurchaseOrder(sender.tag + 1).Focus()
                    End If
            End Select
        End If
    End Sub
    

    'All mouse movement and mouse over messages
    Private Sub tbox_MouseClick(sender As Object, e As EventArgs)
        If sender.Text = "  /  /" Then sender.SelectionStart = 0
    End Sub
    Private Sub fra_MouseMove() Handles fra_Information.MouseMove, fra_Information.MouseMove, fra_Options.MouseMove, fra_Scrollbars.MouseMove, fra_Edits.MouseMove, fra_CmdButtons.MouseMove 'Clear message
        intMessage = 0
        Call MouseMessages()
    End Sub
    Private Sub All_MouseHover(sender As Object, e As EventArgs) Handles VScrollBar1.MouseHover, HScroll_RedLine.MouseHover, HScroll_BlueLine.MouseHover, cmd_1.MouseHover, cmd_2.MouseHover, cmd_3.MouseHover, cmd_Print.MouseHover
        Select Case sender.name
            Case "VScrollBar1" : intMessage = 1
            Case "HScroll_RedLine", "HScroll_BlueLine" : intMessage = 2
            Case "opt_DueDate" : intMessage = 3
            Case "opt_OrderDate" : intMessage = 4
            Case "opt_CustomerName" : intMessage = 5
            Case "opt_PurchaseOrder" : intMessage = 6
            Case "opt_DrawingNumber" : intMessage = 7
            Case "opt_DrawingRev" : intMessage = 8
            Case "opt_Quantity" : intMessage = 9
            Case "opt_ItemPrice" : intMessage = 10
            Case "cmd_1", "cmd_2", "cmd_3" : intMessage = 11
            Case "cmd_Print" : intMessage = 12
            Case "tbox_POItem" : intMessage = 13
        End Select
        Call MouseMessages()
    End Sub
    Private Sub MouseMessages()

        'Messages
        Select Case intMessage
            Case 0 : lbl_Message1.Text = "" : lbl_Message2.Text = "" 'Clear messages from screen
            Case 1 : lbl_Message1.Text = "All orders not shown. Scroll down to view all items"
            Case 2
                lbl_Message1.Text = "Scroll the Red and Blue lines to add the values and count"
                lbl_Message2.Text = "the number of all orders between the two lines"
            Case 3
                lbl_Message1.Text = "Select this option to sort purchase order"
                lbl_Message2.Text = "by items Due date"
            Case 4
                lbl_Message1.Text = "Select this option to sort purchase order"
                lbl_Message2.Text = "by items Order date"
            Case 5
                lbl_Message1.Text = "Select this option to sort purchase order"
                lbl_Message2.Text = "by items Customers Name"
            Case 6
                lbl_Message1.Text = "Select this option to sort purchase order"
                lbl_Message2.Text = "by items Purchase Order number"
            Case 7
                lbl_Message1.Text = "Select this option to sort purchase order"
                lbl_Message2.Text = "by items Drawing number"
            Case 8
                lbl_Message1.Text = "Select this option to sort purchase order"
                lbl_Message2.Text = "by items Drawing Revision"
            Case 9 : lbl_Message1.Text = "Select this option to sort purchase order by Quantity"
            Case 10 : lbl_Message1.Text = "Select this option to sort purchase order by Price"
            Case 11
                lbl_Message1.Text = "Use these buttons to edit the data"
                lbl_Message2.Text = ""
            Case 12
                lbl_Message1.Text = "Use this button to print a Work Schedule"
                lbl_Message2.Text = "base on the screen display"
            Case 13 : lbl_Message1.Text = "Line item number on Customer Purchase order"
        End Select
    End Sub

End Class