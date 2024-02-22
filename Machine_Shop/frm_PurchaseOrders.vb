Public Class frm_PurchaseOrders
    Dim dbAdapter, dbAdapter_Misc As OleDb.OleDbDataAdapter
    Dim dbDataSet, dbDataSet_Misc As New DataSet
    Dim strSQL As String

    Dim tbox_LineItems(11) As TextBox
    Dim tbox_DueDates(11) As MaskedTextBox
    Dim tbox_Quantitys(11) As TextBox
    Dim ListArray(1, 1) As Integer 'Used to link dataset to listbox selection
    Dim LastSelect(4) As String 'Used to record last listbox selection on all four listboxes
    Dim EditNew As Integer '0 = no process, 1 = edit in process, 2 = new in process
    Dim cmdArray(4) As Boolean 'Array to hold command action button status
    Dim intLookup As Integer 'Used to locate edited / new saved record in listbox
    Dim intMessage As Integer 'Variable used in the mouse over event to show different messages
    Dim intLineItem As Integer 'Variable to count purchase order line items
    Dim booCorrection As Boolean = False
    Dim booRepeat, booDataChecked, booListbox As Boolean 'Used for repeat po on same purchase order number, Data pre checked, drawing number listbox show

    'All form related events
    Private Sub frm_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated
        Call AddControls()
        Call FormChange(0)
    End Sub
    Private Sub frm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.Text = "Customers Purchase Orders                                                                Date: " & Now.Date
        cmd_Edit.Enabled = False
        cmd_DeleteCancel.Enabled = False
        booListbox = False 'Listbox drawing number search not showing
        Call CustomerListFill(0)
    End Sub
    Private Sub Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call LastSelectClear()
        dbDataSet.Clear()
        dbDataSet.Tables.Clear()
        dbDataSet_Misc.Clear()
        dbDataSet_Misc.Tables.Clear()
        Me.Dispose()
    End Sub
    Private Sub LastSelectClear()
        For i = 1 To 4
            LastSelect(i) = ""
        Next
    End Sub
    Private Sub AddControls() 'Add date and quantity controls
        Dim int_Top As Integer
        Dim i As Integer

        'Create array of controls in frame order history
        int_Top = 22
        For i = 0 To 11
            int_Top = int_Top + 33

            tbox_LineItems(i) = New TextBox
            tbox_DueDates(i) = New MaskedTextBox
            tbox_Quantitys(i) = New TextBox

            With tbox_LineItems(i)
                .Name = "tbox_LineItems"
                .Tag = i
                .Enabled = True
                .BackColor = Color.White
                .MaxLength = 2
                .Font = New Font("Ariel", 8, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .Visible = True
                .SetBounds(55, int_Top, 32, 20)
                fra_MultipleEntry.Controls.Add(tbox_LineItems(i))
                AddHandler .GotFocus, AddressOf tbox_MultiDates_GotFocus
                AddHandler .LostFocus, AddressOf tbox_MultiDates_LostFocus
                AddHandler .KeyPress, AddressOf tbox_MultiDates_KeyPress
            End With

            With tbox_DueDates(i)
                .Name = "tbox_DueDates"
                .Tag = i
                .Enabled = True
                .BackColor = Color.White
                .Font = New Font("Ariel", 8, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .Mask = ("##/##/####")
                .Visible = True
                .SetBounds(110, int_Top, 67, 20)
                fra_MultipleEntry.Controls.Add(tbox_DueDates(i))
                AddHandler .GotFocus, AddressOf tbox_MultiDates_GotFocus
                AddHandler .LostFocus, AddressOf tbox_MultiDates_LostFocus
                AddHandler .KeyPress, AddressOf tbox_MultiDates_KeyPress
                AddHandler .MouseClick, AddressOf tbox_MultiDates_MouseClick
            End With

            With tbox_Quantitys(i)
                .Name = "tbox_Quantitys"
                .Tag = i
                .Enabled = True
                .BackColor = Color.White
                .Font = New Font("Ariel", 8, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .Visible = True
                .SetBounds(200, int_Top, 58, 20)
                fra_MultipleEntry.Controls.Add(tbox_Quantitys(i))
                AddHandler .GotFocus, AddressOf tbox_MultiDates_GotFocus
                AddHandler .LostFocus, AddressOf tbox_MultiDates_LostFocus
                AddHandler .KeyPress, AddressOf tbox_MultiDates_KeyPress
            End With
        Next
    End Sub
    Private Sub ListBox_Click(sender As Object, e As EventArgs) Handles Listbox_Customers.Click, ListBox_PurchaseOrders.Click, ListBox_DrawNumbers.Click, ListBox_DueDates.Click
        If sender.SelectedItem = Nothing Then Exit Sub
        If EditNew = 0 Then
            Select Case sender.name
                Case "Listbox_Customers" : If sender.SelectedItem = LastSelect(1) Then Exit Sub Else LastSelect(1) = sender.SelectedItem : Call Search(1)
                Case "ListBox_PurchaseOrders" : If sender.SelectedItem = LastSelect(2) Then Exit Sub Else LastSelect(2) = sender.SelectedItem : Call Search(2)
                Case "ListBox_DrawNumbers" : If sender.SelectedItem = LastSelect(3) Then Exit Sub Else LastSelect(3) = sender.SelectedItem : Call Search(3)
                Case "ListBox_DueDates" : If sender.SelectedItem = LastSelect(4) Then Exit Sub Else LastSelect(4) = sender.SelectedItem : Call Search(4)
            End Select
            cmd_Edit.Enabled = True
            cmd_DeleteCancel.Enabled = True

        Else
            lbl_CustCode.Text = ListArray(Listbox_Customers.SelectedIndex, 1)
            lbl_OrderDate.Text = Format(Now, "MM/dd/yyyy")
            lbl_Company.Text = Listbox_Customers.SelectedItem
            Call EnableEdits(True)
            tbox_PurchaseOrder.Focus()
        End If

    End Sub
    Private Sub Search(List As Integer)

        Dim varhold, varhold1, varhold2 As Object
        Dim inc As Integer

        If List = 1 Then 'Fill PurchaseOrder listbox with all distinct purchase order number related to selected customer
            ListBox_PurchaseOrders.Items.Clear() 'Clear purchase order listbox
            strSQL = "SELECT Customers.CustCode,Company,PurchaseOrder,DrawingNumber,DrawingRevision,OrderDate,DueDate,QtyOrdered," _
                   & "DescripA,DescripB,DescripC,Price,Id,MaterialHeat,POItem FROM Customers INNER JOIN Invoice ON Customers.CustCode = Invoice.CustCode " _
                   & "Where Customers.CustCode = " & ListArray(Listbox_Customers.SelectedIndex, 1) & " AND InvoiceDate is Null ORDER BY PurchaseOrder,drawingNumber,DueDate;"
            dbDataSet.Clear()
            dbDataSet.Tables.Clear()
            gbl_DstConnect.Open()
            dbAdapter = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
            dbAdapter.Fill(dbDataSet, "View")
            gbl_DstConnect.Close()
            varhold1 = ""
            If dbDataSet.Tables("View").Rows.Count <> 0 Then
                For inc = 0 To dbDataSet.Tables("View").Rows.Count - 1
                    varhold = dbDataSet.Tables("View").Rows(inc).Item(2) 'Purchase order numbers
                    If IsDBNull(varhold) Then varhold = "" Else varhold = Replace(varhold, "^", "'")
                    If inc = 0 Then
                        ListBox_PurchaseOrders.Items.Add(varhold) : varhold1 = varhold
                    Else
                        If varhold <> varhold1 Then ListBox_PurchaseOrders.Items.Add(varhold) : varhold1 = varhold
                    End If
                Next
                ListBox_PurchaseOrders.SelectedIndex = 0 'PreSelect first item in purchase order listbox 
            End If
        End If

        If List = 1 Or List = 2 Then 'Fill DrawingNumber listbox with all distinct drawing numbers related to selected purchase order
            ListBox_DrawNumbers.Items.Clear() 'Clear draw number listbox
            varhold1 = ""
            For inc = 0 To dbDataSet.Tables("View").Rows.Count - 1
                varhold = dbDataSet.Tables("View").Rows(inc).Item(2) 'Purchase order numbers
                If IsDBNull(varhold) Then varhold = "" Else varhold = Replace(varhold, "^", "'")
                If varhold = ListBox_PurchaseOrders.SelectedItem Then
                    varhold = dbDataSet.Tables("View").Rows(inc).Item(3) 'Drawing numbers
                    If IsDBNull(varhold) Then varhold = "" Else varhold = Replace(varhold, "^", "'")
                    If inc = 0 Then
                        ListBox_DrawNumbers.Items.Add(varhold) : varhold1 = varhold
                    Else
                        If varhold <> varhold1 Then ListBox_DrawNumbers.Items.Add(varhold) : varhold1 = varhold
                    End If
                End If
            Next
            ListBox_DrawNumbers.SelectedIndex = 0 'PreSelect first item in Draw number listbox 
        End If

        If List >= 1 And List <= 3 Then 'Fill DueDates listbox with all distinct dueDates related to selected customer,purchase order and drawing number
            ListBox_DueDates.Items.Clear() 'Clear due date listbox
            varhold1 = ""
            For inc = 0 To dbDataSet.Tables("View").Rows.Count - 1
                varhold = dbDataSet.Tables("View").Rows(inc).Item(2) 'Purchase order numbers
                If IsDBNull(varhold) Then varhold = "" Else varhold = Replace(varhold, "^", "'")
                varhold1 = dbDataSet.Tables("View").Rows(inc).Item(3) 'Drawing numbers
                If IsDBNull(varhold1) Then varhold1 = "" Else varhold1 = Replace(varhold1, "^", "'")
                If varhold = ListBox_PurchaseOrders.SelectedItem And varhold1 = ListBox_DrawNumbers.SelectedItem Then
                    varhold = dbDataSet.Tables("View").Rows(inc).Item(6) 'Due Dates
                    If IsDBNull(varhold) Then varhold = "" Else varhold = Replace(varhold, "^", "'")
                    If inc = 0 Then
                        ListBox_DueDates.Items.Add(varhold) : varhold1 = varhold
                    Else
                        If varhold <> varhold1 Then ListBox_DueDates.Items.Add(varhold) : varhold1 = varhold
                    End If
                End If
            Next
            ListBox_DueDates.SelectedIndex = 0 'PreSelect first item in DueDates listbox 
        End If

        If List >= 1 And List <= 4 Then
            'Search for row number of selected search
            For Me.intLookup = 0 To dbDataSet.Tables("View").Rows.Count - 1
                varhold = dbDataSet.Tables("View").Rows(Me.intLookup).Item(2) 'Purchase order numbers
                If IsDBNull(varhold) Then varhold = "" Else varhold = Replace(varhold, "^", "'")
                varhold1 = dbDataSet.Tables("View").Rows(Me.intLookup).Item(3) 'Drawing numbers
                If IsDBNull(varhold1) Then varhold1 = "" Else varhold1 = Replace(varhold1, "^", "'")
                varhold2 = dbDataSet.Tables("View").Rows(Me.intLookup).Item(6) 'Due Dates
                If IsDBNull(varhold2) Then varhold2 = "" Else varhold2 = Replace(varhold2, "^", "'")
                If varhold = ListBox_PurchaseOrders.SelectedItem And varhold1 = ListBox_DrawNumbers.SelectedItem And varhold2 = ListBox_DueDates.SelectedItem Then Exit For
            Next
        End If

        'Enable PurchaseOrder,DrawNumber,DueDate listboxes
        Call ListboxEnable(True, True)
        Call DataFill()
    End Sub
    Private Sub ListboxEnable(blnStatus As Boolean, blnStatus1 As Boolean)
        Listbox_Customers.Enabled = blnStatus
        ListBox_PurchaseOrders.Enabled = blnStatus1
        ListBox_DrawNumbers.Enabled = blnStatus1
        ListBox_DueDates.Enabled = blnStatus1
    End Sub
    Private Sub DataFill() 'Fill form with data pertaining to listbox selection

        'Form fill data
        booDataChecked = True
        If Not IsDBNull(dbDataSet.Tables("View").Rows(intLookup).Item(0)) Then 'CustCode
            lbl_CustCode.Text = Trim(dbDataSet.Tables("View").Rows(intLookup).Item(0))
        Else : lbl_CustCode.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("View").Rows(intLookup).Item(1)) Then 'Company name
            lbl_Company.Text = Trim(dbDataSet.Tables("View").Rows(intLookup).Item(1))
        Else : lbl_Company.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("View").Rows(intLookup).Item(2)) Then 'Purchase Order
            tbox_PurchaseOrder.Text = Trim(dbDataSet.Tables("View").Rows(intLookup).Item(2))
        Else : tbox_PurchaseOrder.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("View").Rows(intLookup).Item(3)) Then 'Drawing Number
            tbox_DrawNumber.Text = Trim(dbDataSet.Tables("View").Rows(intLookup).Item(3))
        Else : tbox_DrawNumber.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("View").Rows(intLookup).Item(4)) Then 'Drawing Revision
            tbox_DrawRev.Text = Trim(dbDataSet.Tables("View").Rows(intLookup).Item(4))
        Else : tbox_DrawRev.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("View").Rows(intLookup).Item(5)) And dbDataSet.Tables("View").Rows(intLookup).Item(5).ToString <> "#12/12/1212#" Then 'Order date
            lbl_OrderDate.Text = Format(dbDataSet.Tables("View").Rows(intLookup).Item(5), "MM/dd/yyyy")
        Else : lbl_OrderDate.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("View").Rows(intLookup).Item(6)) And dbDataSet.Tables("View").Rows(intLookup).Item(6).ToString <> "#12/12/1212#" Then 'Due date
            tbox_DueDate.Text = Format(dbDataSet.Tables("View").Rows(intLookup).Item(6), "MM/dd/yyyy")
        Else : tbox_DueDate.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("View").Rows(intLookup).Item(7)) Then 'Quantity
            tbox_Quantity.Text = Trim(dbDataSet.Tables("View").Rows(intLookup).Item(7))
        Else : tbox_Quantity.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("View").Rows(intLookup).Item(8)) Then 'Description line 1
            tbox_Description1.Text = Trim(dbDataSet.Tables("View").Rows(intLookup).Item(8))
        Else : tbox_Description1.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("View").Rows(intLookup).Item(9)) Then 'Description line 2
            tbox_Description2.Text = Trim(dbDataSet.Tables("View").Rows(intLookup).Item(9))
        Else : tbox_Description2.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("View").Rows(intLookup).Item(10)) Then 'Description line 3
            tbox_Description3.Text = Trim(dbDataSet.Tables("View").Rows(intLookup).Item(10))
        Else : tbox_Description3.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("View").Rows(intLookup).Item(11)) Then 'Price
            tbox_Price.Text = FormatCurrency(Trim(dbDataSet.Tables("View").Rows(intLookup).Item(11)))
        Else : tbox_Price.Text = "" : End If
        lbl_TotalPrice.Text = FormatCurrency(tbox_Price.Text * tbox_Quantity.Text)

        lbl_Identifier.Text = Trim(dbDataSet.Tables("View").Rows(intLookup).Item(12)) 'Id

        If Not IsDBNull(dbDataSet.Tables("View").Rows(intLookup).Item(13)) Then 'Material Heat number
            tbox_MaterialHeat.Text = Trim(dbDataSet.Tables("View").Rows(intLookup).Item(13))
        Else : tbox_MaterialHeat.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("View").Rows(intLookup).Item(14)) Then 'Purchase order line item number
            tbox_LineItem.Text = Trim(dbDataSet.Tables("View").Rows(intLookup).Item(14))
        Else : tbox_LineItem.Text = "" : End If
        booDataChecked = False
    End Sub
    Private Sub ClearData(blnStatus As Boolean) 'Clear form of all data
        If blnStatus = True Then
            lbl_CustCode.Text = ""
            lbl_OrderDate.Text = ""
            lbl_Company.Text = ""
            tbox_PurchaseOrder.Text = ""
        End If
        tbox_DrawNumber.Text = ""
        tbox_DrawRev.Text = ""
        tbox_LineItem.Text = ""
        tbox_DueDate.Text = ""
        tbox_Quantity.Text = ""
        tbox_Description1.Text = ""
        tbox_Description2.Text = ""
        tbox_Description3.Text = ""
        tbox_Price.Text = ""
        lbl_TotalPrice.Text = ""
        tbox_MaterialHeat.Text = ""
        lbl_Identifier.Text = ""
        cbx_MultiDueDate.Checked = False
        cbx_MultiQuantity.Checked = False
        opt_AutoFill.Visible = False
        For intStep1 = 0 To 11
            tbox_LineItems(intStep1).Text = ""
            tbox_DueDates(intStep1).Text = ""
            tbox_Quantitys(intStep1).Text = ""
        Next
    End Sub
    Private Sub ListboxClear(blnStatus As Boolean) 'Clear all listbox
        If blnStatus = True Then Listbox_Customers.Items.Clear()
        ListBox_PurchaseOrders.Items.Clear()
        ListBox_DrawNumbers.Items.Clear()
        ListBox_DueDates.Items.Clear()
    End Sub
    Private Sub EnableEdits(blnStatus As Boolean)
        tbox_PurchaseOrder.Enabled = blnStatus
        tbox_DrawNumber.Enabled = blnStatus
        tbox_DrawRev.Enabled = blnStatus
        tbox_LineItem.Enabled = blnStatus
        tbox_DueDate.Enabled = blnStatus
        tbox_Quantity.Enabled = blnStatus
        tbox_Description1.Enabled = blnStatus
        tbox_Description2.Enabled = blnStatus
        tbox_Description3.Enabled = blnStatus
        tbox_Price.Enabled = blnStatus
        tbox_MaterialHeat.Enabled = blnStatus
        If cbx_MultiDueDate.Visible = True Then
            cbx_MultiDueDate.Enabled = blnStatus
            cbx_MultiQuantity.Enabled = blnStatus
        End If
    End Sub
    Private Sub Opt_Active_CheckedChanged() Handles opt_Active.CheckedChanged, opt_NonActive.CheckedChanged 'Index recordset based on selected option button
        If opt_Active.Checked = True Then CustomerListFill(1) Else CustomerListFill(2)
    End Sub
    Private Sub CustomerListFill(intSelect As Integer) 'Fill listbox customer with company name relavent to selected task

        Call ListboxClear(True)
        Call ClearData(True)

        Select Case intSelect
            Case 0 'Find all customers that have open purchase orders (Customers by default to meet requirements must be active )
                strSQL = "SELECT Distinct Company,Customers.CustCode FROM Customers INNER JOIN Invoice ON Customers.CustCode = Invoice.CustCode WHERE InvoiceNumber Is Null ORDER BY Company;"
                opt_Active.Enabled = False : opt_NonActive.Enabled = False
                Call ListboxEnable(True, False)
            Case 1
                strSQL = "SELECT Company,CustCode FROM Customers Where Active = True ORDER BY Company;"
                opt_Active.Enabled = True : opt_NonActive.Enabled = True
                ListboxEnable(True, False)
            Case 2
                strSQL = "SELECT Company,CustCode FROM Customers ORDER BY Company;"
                opt_Active.Enabled = True : opt_NonActive.Enabled = True
                ListboxEnable(True, False)
        End Select

        dbDataSet_Misc.Clear()
        dbDataSet_Misc.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter_Misc.Fill(dbDataSet_Misc, "Customers")
        gbl_DstConnect.Close()

        If dbDataSet_Misc.Tables("Customers").Rows.Count <> 0 Then
            ReDim ListArray(0 To dbDataSet_Misc.Tables("Customers").Rows.Count - 1, 1)
            Dim varhold As Object
            Dim inc As Integer
            For inc = 0 To dbDataSet_Misc.Tables("Customers").Rows.Count - 1

                ListArray(inc, 0) = inc 'Listbox index

                varhold = dbDataSet_Misc.Tables("Customers").Rows(inc).Item(0) 'CompanyName
                If IsDBNull(varhold) Then varhold = "" Else varhold = Replace(varhold, "^", "'")
                Listbox_Customers.Items.Add(varhold)

                varhold = dbDataSet_Misc.Tables("Customers").Rows(inc).Item(1) 'CustCode
                If IsDBNull(varhold) Then varhold = ""
                ListArray(inc, 1) = Trim(varhold)

            Next
        Else 'No data found
            Select Case intSelect
                Case 0 : frm_Message.Text = "6:1:0:1:4:There are no open purchase orders on file to view, New is the only operation allowed"
                Case 1 : frm_Message.Text = "6:1:0:1:2:There are no active customers on record to show"
                Case 2 : frm_Message.Text = "6:1:0:1:2:There are no customers on record to show"
            End Select
            frm_Message.ShowDialog()
        End If

    End Sub
    Private Sub cbx_Multi_CheckedChanged(sender As Object, e As EventArgs) Handles cbx_MultiDueDate.CheckedChanged, cbx_MultiQuantity.CheckedChanged
        Select Case sender.name
            Case "cbx_MultiDueDate"
                If sender.Checked = False Then cbx_MultiQuantity.Checked = False : tbox_LineItem.Enabled = True : tbox_DueDate.Enabled = True : Call FormChange(0)
                If sender.Checked = True And cbx_MultiQuantity.Checked = False Then tbox_LineItem.Enabled = False : tbox_DueDate.Enabled = False : Call FormChange(1)
                If tbox_LineItem.Text <> "" Then tbox_LineItems(0).Text = tbox_LineItem.Text : tbox_LineItem.Text = ""
                If tbox_DueDate.Text <> "  /  /" Then tbox_DueDates(0).Text = tbox_DueDate.Text : tbox_DueDate.Text = ""
            Case "cbx_MultiQuantity"
                If sender.Checked = False And cbx_MultiDueDate.Checked = False Then tbox_LineItem.Enabled = True : tbox_DueDate.Enabled = True : tbox_Quantity.Enabled = True : Call FormChange(0)
                If sender.Checked = False And cbx_MultiDueDate.Checked = True Then tbox_LineItem.Enabled = True : tbox_Quantity.Enabled = True : Call FormChange(1)
                If sender.Checked = True Then tbox_LineItem.Enabled = False : tbox_DueDate.Enabled = False : tbox_Quantity.Enabled = False : Call FormChange(2)
                If tbox_LineItem.Text <> "" Then tbox_LineItems(0).Text = tbox_LineItem.Text : tbox_LineItem.Text = ""
                If tbox_DueDate.Text <> "  /  /" Then tbox_DueDates(0).Text = tbox_DueDate.Text : tbox_DueDate.Text = ""
                If tbox_Quantity.Text <> "" Then tbox_Quantitys(0).Text = tbox_Quantity.Text : tbox_Quantity.Text = ""
        End Select
    End Sub
    Private Sub FormChange(s As Integer)
        Select Case s
            Case 0 'No multiples
                cmd_Search.Left = 660
                lbl_Multiples.Visible = False
                fra_MultipleEntry.Visible = False
                ListBox_PurchaseOrders.Left = 360
                ListBox_DrawNumbers.Left = 360
                ListBox_DueDates.Left = 360
                lbl_PurchaseOrders.Left = 360
                lbl_DrawingNumbers.Left = 360
                lbl_DueDates.Left = 360
                fra_Information.Width = 517 '497
                Me.Width = 839 '809
            Case 1 'Multiple DueDates
                cmd_Search.Left = 879 '824
                fra_MultipleEntry.Size = New Size(199, 464) '144,464
                lbl_Multiples.SetBounds(387, 23, 146, 16) '(387, 23, 91, 16)
                lbl_Multiples.Text = "Multiple Dates"
                lbl_Multiples.Visible = True
                lbl_Quantitys.Visible = False
                fra_MultipleEntry.Visible = True
                ListBox_PurchaseOrders.Left = 578
                ListBox_DrawNumbers.Left = 578
                ListBox_DueDates.Left = 578
                lbl_PurchaseOrders.Left = 578
                lbl_DrawingNumbers.Left = 578
                lbl_DueDates.Left = 578
                fra_Information.Width = 735 '715
                Me.Width = 1047 '1027
            Case 2 'Multiple DueDate and Quantities
                cmd_Search.Left = 969 ' 914
                cbx_MultiDueDate.Checked = True
                fra_MultipleEntry.Size = New Size(290, 464)
                lbl_Multiples.SetBounds(446, 23, 153, 16)
                lbl_Multiples.Text = "Multiple Entries"
                lbl_Multiples.Visible = True
                lbl_Quantitys.Visible = True
                fra_MultipleEntry.Visible = True
                ListBox_PurchaseOrders.Left = 668
                ListBox_DrawNumbers.Left = 668
                ListBox_DueDates.Left = 668
                lbl_PurchaseOrders.Left = 668
                lbl_DrawingNumbers.Left = 668
                lbl_DueDates.Left = 668
                fra_Information.Width = 825 '805
                Me.Width = 1137 '1117
        End Select
        Me.Left = (Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2
    End Sub
    Private Sub ListBox_DN_Search_Click() Handles ListBox_DN_Search.Click
        booDataChecked = True
        tbox_DrawNumber.Text = ListBox_DN_Search.SelectedItem
        Listbox_DNShow(False)
        booDataChecked = False
        opt_AutoFill.Visible = True
        opt_AutoFill.PerformClick()
        tbox_DrawRev.Focus()
    End Sub
    Private Sub Listbox_DNShow(blnStatus As Boolean)
        booListbox = blnStatus
        ListBox_DN_Search.Visible = blnStatus

        'Record command action button status
        If blnStatus = True Then
            If cmd_Edit.Enabled = True Then cmdArray(0) = True Else cmdArray(0) = False
            If cmd_NewRestore.Enabled = True Then cmdArray(1) = True Else cmdArray(1) = False
            If cmd_DeleteCancel.Enabled = True Then cmdArray(2) = True Else cmdArray(2) = False
            If cmd_ExitSave.Enabled = True Then cmdArray(3) = True Else cmdArray(3) = False
            If cmd_RepeatSave.Enabled = True Then cmdArray(4) = True Else cmdArray(4) = False
            cmd_Edit.Enabled = False
            cmd_NewRestore.Enabled = False
            If cmd_DeleteCancel.Text = "Delete" Then cmd_DeleteCancel.Enabled = False
            cmd_ExitSave.Enabled = False
            cmd_RepeatSave.Enabled = False
            blnStatus = False
        Else
            If cmdArray(0) = True Then cmd_Edit.Enabled = True
            If cmdArray(1) = True Then cmd_NewRestore.Enabled = True
            If cmdArray(2) = True Then cmd_DeleteCancel.Enabled = True
            If cmdArray(3) = True Then cmd_ExitSave.Enabled = True
            If cmdArray(4) = True Then cmd_RepeatSave.Enabled = True
            blnStatus = True
        End If
        tbox_PurchaseOrder.Enabled = blnStatus
        tbox_DrawRev.Enabled = blnStatus
        tbox_LineItem.Enabled = blnStatus
        tbox_DueDate.Enabled = blnStatus
        tbox_Quantity.Enabled = blnStatus
        tbox_Description1.Enabled = blnStatus
        tbox_Description2.Enabled = blnStatus
        tbox_Description3.Enabled = blnStatus
        tbox_Price.Enabled = blnStatus
        tbox_MaterialHeat.Enabled = blnStatus
        opt_AutoFill.Enabled = blnStatus
        cbx_MultiDueDate.Enabled = blnStatus
        cbx_MultiQuantity.Enabled = blnStatus
    End Sub


    'All command actions ( Edit,New/Restore,DeleteCancel,Exit/Save )
    Private Sub cmd_Edit_Click() Handles cmd_Edit.Click

        If tbox_PurchaseOrder.Text = "" Then Exit Sub
        EditNew = 1 'Set variable to edit on save
        Call ListboxEnable(False, False)
        Call EnableEdits(True)
        opt_Active.Enabled = False
        opt_NonActive.Enabled = False

        cmd_Edit.Enabled = False
        cmd_NewRestore.Enabled = False
        cmd_NewRestore.Text = "Restore"
        cmd_NewRestore.Image = My.Resources.Resources.Restore
        cmd_DeleteCancel.Text = "Cancel"
        cmd_DeleteCancel.Image = My.Resources.Resources.Cancel
        tbox_PurchaseOrder.Focus()
    End Sub
    Private Sub cmd_NewRestore_Click(sender As Object, e As EventArgs) Handles cmd_NewRestore.Click

        If cmd_NewRestore.Text = "New" Then
            EditNew = 2 'Set variable to new for save

            'Store listbox selected item before new was pressed (Original selection )
            Dim CustItem As String = ""
            Dim CustIndex As Integer = Listbox_Customers.SelectedIndex
            If CustIndex <> -1 Then CustItem = Listbox_Customers.SelectedItem

            cbx_MultiDueDate.Visible = True
            cbx_MultiQuantity.Visible = True
            opt_Active.Checked = True
            If opt_Active.Checked = True Then Call CustomerListFill(1) Else opt_Active.Checked = True

            cmd_Edit.Enabled = False  'Disable edit button
            cmd_NewRestore.Enabled = False  'Disable new/restore button
            cmd_DeleteCancel.Text = "Cancel"
            cmd_DeleteCancel.Image = My.Resources.Resources.Cancel
            cmd_DeleteCancel.Enabled = True
            cmd_DeleteCancel.Enabled = True
            cmd_ExitSave.Text = "Save"
            cmd_ExitSave.Image = My.Resources.Resources.Save
            cmd_ExitSave.Enabled = False  'Hide exit/save button
            intLineItem = 1
            tbox_LineItem.Text = intLineItem

            'If possible select the same customer that was viewed previosly
            If CustIndex <> -1 Then
                Listbox_Customers.SelectedIndex = Listbox_Customers.FindString(CustItem)
                lbl_CustCode.Text = ListArray(Listbox_Customers.SelectedIndex, 1)
                lbl_OrderDate.Text = Format(Now, "MM/dd/yyyy")
                lbl_Company.Text = Listbox_Customers.SelectedItem
                Call EnableEdits(True)
                tbox_PurchaseOrder.Focus()
            Else
                Listbox_Customers.SelectedIndex = -1
            End If

        Else
            Call DataFill() 'Replace original values from recordset
            cmd_Edit.Enabled = False
            cmd_NewRestore.Enabled = False
            cmd_ExitSave.Enabled = False
            cmd_RepeatSave.Visible = False
        End If
    End Sub
    Private Sub cmd_DeleteCancel_Click(sender As Object, e As EventArgs) Handles cmd_DeleteCancel.Click
        If cmd_DeleteCancel.Text = "Delete" Then

            'Confirm deletion before continuing
            frm_Message.Text = "6:3:0:1:2:Delete This Record"
            frm_Message.ShowDialog()
            If MessageResult = True Then

                'Store listbox selections before deletion
                Dim listCust, listPO, listDraw As String
                listCust = Listbox_Customers.SelectedItem
                listPO = ListBox_PurchaseOrders.SelectedItem
                listDraw = ListBox_DrawNumbers.SelectedItem

                'Locate selected record in simple record ( No Joins )
                Dim intID As Integer = dbDataSet.Tables("View").Rows(intLookup).Item(12) 'Locate Id of record to be deleted
                strSQL = "SELECT Id FROM Invoice Where Id = " & intID & ";"
                dbDataSet_Misc.Clear()
                dbDataSet_Misc.Tables.Clear()
                gbl_DstConnect.Open()
                dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
                dbAdapter_Misc.Fill(dbDataSet_Misc, "Delete")
                gbl_DstConnect.Close()

                'Delete selected purchase order
                Dim cb1 As New OleDb.OleDbCommandBuilder(dbAdapter_Misc)
                dbDataSet_Misc.Tables("Delete").Rows(0).Delete()
                dbAdapter_Misc.Update(dbDataSet_Misc, "Delete")
                cb1 = Nothing

                Call CustomerListFill(0) 'Fill listbox customers with updated customers with open purchase orders

                'Reset as many listbox selections back to previous selections
                Dim Pos As Integer
                Pos = Listbox_Customers.FindString(listCust) 'Customer
                If Pos <> -1 Then Listbox_Customers.SelectedIndex = Pos Else Listbox_Customers.SelectedIndex = 0
                Call Search(1)

                Pos = ListBox_PurchaseOrders.FindString(listPO) 'Purchase orders
                If Pos <> -1 Then ListBox_PurchaseOrders.SelectedIndex = Pos Else ListBox_PurchaseOrders.SelectedIndex = 0
                Call Search(2)

                Pos = ListBox_DrawNumbers.FindString(listDraw) 'Drawing numbers
                If Pos <> -1 Then ListBox_DrawNumbers.SelectedIndex = Pos Else ListBox_DrawNumbers.SelectedIndex = 0
                Call Search(3)

                Exit Sub
            End If

        ElseIf cmd_DeleteCancel.Text = "Cancel" Then
            ListBox_DN_Search.Visible = False
            booListbox = False
            Call EnableEdits(False)
            Select Case EditNew
                Case 1
                    Call DataFill() 'Replace original values from recordset
                    Call FileOperationReset()
                    Call ListboxEnable(True, True)
                Case 2
                    Call ClearData(True)
                    Call CustomerListFill(0)
                    Call LastSelectClear()
                    Call FileOperationReset()
                    cmd_Edit.Enabled = False
                    cmd_DeleteCancel.Enabled = False
                    cbx_MultiDueDate.Visible = False
                    cbx_MultiQuantity.Visible = False
            End Select
            EditNew = 0
            Listbox_Customers.Focus()
        End If
    End Sub
    Private Sub cmd_ExitSave_Click(sender As Object, e As EventArgs) Handles cmd_ExitSave.Click
        If cmd_ExitSave.Text = "Exit" Then Me.Close() : Exit Sub

        On Error GoTo goActionErr

        'Validate entries
        If Trim(tbox_PurchaseOrder.Text) = "" Then
            tbox_PurchaseOrder.BackColor = Color.Aqua
            frm_Message.Text = "6:1:0:1:2:Purchase Order must be Entered to Continue"
            frm_Message.ShowDialog()
            tbox_PurchaseOrder.BackColor = Color.White
            tbox_PurchaseOrder.Focus()
            booRepeat = False
            Exit Sub
        End If

        If Trim(tbox_DrawNumber.Text) = "" Then
            tbox_DrawNumber.BackColor = Color.Aqua
            frm_Message.Text = "6:1:0:1:2:Drawing Number must be Entered to Continue"
            frm_Message.ShowDialog()
            tbox_DrawNumber.BackColor = Color.White
            tbox_DrawNumber.Focus()
            booRepeat = False
            Exit Sub
        End If

        If cbx_MultiDueDate.Checked = False Then
            If Trim(tbox_LineItem.Text) = "" Then
                tbox_LineItem.BackColor = Color.Aqua
                frm_Message.Text = "6:1:0:1:2:Line items must be Entered to Continue"
                frm_Message.ShowDialog()
                tbox_LineItem.BackColor = Color.White
                tbox_LineItem.Focus()
                booRepeat = False
                Exit Sub
            End If
            If Trim(tbox_DueDate.Text) = "/  /" Then
                tbox_DueDate.BackColor = Color.Aqua
                frm_Message.Text = "6:1:0:1:2:Due Date must be Entered to Continue"
                frm_Message.ShowDialog()
                tbox_DueDate.BackColor = Color.White
                tbox_DueDate.Focus()
                booRepeat = False
                Exit Sub
            End If
        Else
            If Trim(tbox_LineItems(0).Text) = "" Then
                tbox_LineItems(0).BackColor = Color.Aqua
                frm_Message.Text = "6:1:0:1:2:Line items must be Entered to Continue"
                frm_Message.ShowDialog()
                tbox_LineItems(0).BackColor = Color.White
                tbox_LineItems(0).Focus()
                booRepeat = False
                Exit Sub
            End If
            If Trim(tbox_DueDates(0).Text) = "/  /" Then
                tbox_DueDates(0).BackColor = Color.Aqua
                frm_Message.Text = "6:1:0:1:2:Due Date must be Entered to Continue"
                frm_Message.ShowDialog()
                tbox_DueDates(0).BackColor = Color.White
                tbox_DueDates(0).Focus()
                booRepeat = False
                Exit Sub
            End If
        End If

        If cbx_MultiQuantity.Checked = False Then
            If Trim(tbox_Quantity.Text) = "" Then
                tbox_Quantity.BackColor = Color.Aqua
                frm_Message.Text = "6:1:0:1:2:Quantity must be Entered to Continue"
                frm_Message.ShowDialog()
                tbox_Quantity.BackColor = Color.White
                tbox_Quantity.Focus()
                booRepeat = False
                Exit Sub
            End If
        Else
            If Trim(tbox_Quantitys(0).Text) = "" Then
                tbox_Quantitys(0).BackColor = Color.Aqua
                frm_Message.Text = "6:1:0:1:2:Quantity must be Entered to Continue"
                frm_Message.ShowDialog()
                tbox_Quantitys(0).BackColor = Color.White
                tbox_Quantitys(0).Focus()
                booRepeat = False
                Exit Sub
            End If
        End If

        If Trim(tbox_Price.Text) = "" Then
            tbox_Price.BackColor = Color.Aqua
            frm_Message.Text = "6:1:0:1:2:Price must be Entered to Continue"
            frm_Message.ShowDialog()
            tbox_Price.BackColor = Color.White
            tbox_Price.Focus()
            booRepeat = False
            Exit Sub
        End If

        'Test for purchase order line items not matching multiDates if multiDates selected
        Dim intStep As Integer
        If cbx_MultiDueDate.Checked = True Then
            For intStep = 0 To 11
                If tbox_DueDates(intStep).Text <> "  /  /" And Trim(tbox_LineItems(intStep).Text) = "" Or tbox_LineItems(intStep).Text <> "" And tbox_DueDates(intStep).Text = "  /  /" Then
                    tbox_LineItems(intStep).BackColor = Color.Aqua
                    tbox_DueDates(intStep).BackColor = Color.Aqua
                    frm_Message.Text = "6:1:0:1:3:Purchase order line items do not match multi date entries"
                    frm_Message.ShowDialog()
                    tbox_LineItems(intStep).BackColor = Color.White
                    tbox_DueDates(intStep).BackColor = Color.White
                    tbox_LineItems(intStep).Focus()
                    booRepeat = False
                    Exit Sub
                End If
            Next
        End If

        'Test for multiQuantitys not matching multiDates if multiQuantitys selected
        If cbx_MultiQuantity.Checked = True Then
            For intStep = 0 To 11
                If tbox_DueDates(intStep).Text <> "  /  /" And Trim(tbox_Quantitys(intStep).Text) = "" Or Trim(tbox_Quantitys(intStep).Text) <> "" And tbox_DueDates(intStep).Text = "  /  /" Then
                    tbox_Quantitys(intStep).BackColor = Color.Aqua
                    frm_Message.Text = "6:1:0:1:3:With Multi Quantitys checked, quantitys must match all due date entries"
                    frm_Message.ShowDialog()
                    tbox_Quantitys(intStep).BackColor = Color.White
                    tbox_Quantitys(intStep).Focus()
                    booRepeat = False
                    Exit Sub
                End If
            Next
        End If

        'Test for repeat of same line item number in this order
        If cbx_MultiDueDate.Checked = True Then
            For intStep1 = 0 To 11
                For intStep2 = intStep1 + 1 To 11
                    If tbox_LineItems(intStep1).Text <> "" Or tbox_LineItems(intStep2).Text <> "" Then
                        If tbox_LineItems(intStep1).Text = tbox_LineItems(intStep2).Text Then
                            tbox_LineItems(intStep2).BackColor = Color.Aqua
                            frm_Message.Text = "6:1:0:1:3:Purchase orders with multiple orders can not share the same line item numbers"
                            frm_Message.ShowDialog()
                            tbox_LineItems(intStep2).BackColor = Color.White
                            tbox_LineItems(intStep2).Focus()
                            booRepeat = False
                            Exit Sub
                        End If
                    End If
                Next
            Next
        End If

        'Test for repeat of same line item number with same customer and purchase order number in database ( Only on new record )
        If EditNew = 2 Then
            If cbx_MultiDueDate.Checked = False Then tbox_LineItems(0).Text = tbox_LineItem.Text
            strSQL = "SELECT POItem FROM Invoice Where CustCode = " & lbl_CustCode.Text & " AND PurchaseOrder = '" & Trim(tbox_PurchaseOrder.Text) & "' ORDER BY POItem;"
            dbDataSet_Misc.Clear()
            dbDataSet_Misc.Tables.Clear()
            gbl_DstConnect.Open()
            dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
            dbAdapter_Misc.Fill(dbDataSet_Misc, "Items")
            gbl_DstConnect.Close()
            If dbDataSet_Misc.Tables("items").Rows.Count <> 0 Then
                Dim SkipWarning As Boolean = False
                Dim LineItemMax As Integer = 0
                For intStep1 = 0 To dbDataSet_Misc.Tables("items").Rows.Count - 1 'Scroll thru all previous records
                    If Not IsDBNull(dbDataSet_Misc.Tables("items").Rows(intStep1).Item(0)) Then 'POItem
                        If dbDataSet_Misc.Tables("items").Rows(intStep1).Item(0) > LineItemMax Then LineItemMax = dbDataSet_Misc.Tables("items").Rows(intStep1).Item(0) 'Replace lineItemMax with the highest line item number
                        For intStep2 = 0 To 11 'Test previous record line item number against all new line item number looking for a match
                            If Trim(dbDataSet_Misc.Tables("items").Rows(intStep1).Item(0)) = Trim(tbox_LineItems(intStep2).Text) And SkipWarning = False Then
                                tbox_LineItems(intStep2).BackColor = Color.Aqua
                                frm_Message.Text = "6:9:0:1:5:There is another record on file with the same Customer, P.O.number and line item number"
                                frm_Message.ShowDialog()
                                If MessageResult = True Then
                                    SkipWarning = True
                                Else
                                    tbox_LineItems(intStep2).BackColor = Color.White
                                    tbox_LineItems(intStep2).Focus()
                                    booRepeat = False
                                    Exit Sub
                                End If
                            End If
                            If cbx_MultiDueDate.Checked = False Then Exit For
                        Next
                    End If
                Next
                If SkipWarning = True Then 'Replace all new line item number with new valid line item numbers
                    If cbx_MultiDueDate.Checked = False Then
                        tbox_LineItem.Text = LineItemMax + 1
                    Else
                        For i = 0 To 11
                            If Trim(tbox_LineItems(i).Text) <> "" Then
                                LineItemMax = LineItemMax + 1
                                tbox_LineItems(i).Text = LineItemMax
                            Else : Exit For : End If
                        Next
                    End If
                End If
            End If
        End If

        Dim sngPrice As Single = tbox_Price.Text

        'Locate selected record in simple record ( No Joins )
        Select Case EditNew
            Case 1 'Locate Id of selected (viewed) record that is being edited
                Dim intID As Integer = dbDataSet.Tables("View").Rows(intLookup).Item(12)
                strSQL = "SELECT Id,CustCode,PurchaseOrder,DrawingNumber,DrawingRevision,OrderDate,DueDate,QtyOrdered," _
                       & "DescripA,DescripB,DescripC,Price,MaterialHeat,POItem FROM Invoice Where Id = " & intID & ";"
            Case 2 'Create a dataset that records can be added to
                strSQL = "SELECT Id,CustCode,PurchaseOrder,DrawingNumber,DrawingRevision,OrderDate,DueDate,QtyOrdered," _
                       & "DescripA,DescripB,DescripC,Price,MaterialHeat,PoItem FROM Invoice"
        End Select
        dbDataSet_Misc.Clear()
        dbDataSet_Misc.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter_Misc.Fill(dbDataSet_Misc, "Selected")
        gbl_DstConnect.Close()

        'Save data to database
        Select Case EditNew
            Case 1 'Save on edits changes
                Dim cb0 As New OleDb.OleDbCommandBuilder(dbAdapter_Misc)
                dbDataSet_Misc.Tables("Selected").Rows(0).Item(1) = lbl_CustCode.Text
                dbDataSet_Misc.Tables("Selected").Rows(0).Item(2) = Trim(tbox_PurchaseOrder.Text)
                dbDataSet_Misc.Tables("Selected").Rows(0).Item(3) = Trim(tbox_DrawNumber.Text)
                dbDataSet_Misc.Tables("Selected").Rows(0).Item(4) = Trim(tbox_DrawRev.Text)
                dbDataSet_Misc.Tables("Selected").Rows(0).Item(5) = lbl_OrderDate.Text
                dbDataSet_Misc.Tables("Selected").Rows(0).Item(6) = Trim(tbox_DueDate.Text)
                dbDataSet_Misc.Tables("Selected").Rows(0).Item(7) = Trim(tbox_Quantity.Text)
                dbDataSet_Misc.Tables("Selected").Rows(0).Item(8) = Trim(tbox_Description1.Text)
                dbDataSet_Misc.Tables("Selected").Rows(0).Item(9) = Trim(tbox_Description2.Text)
                dbDataSet_Misc.Tables("Selected").Rows(0).Item(10) = Trim(tbox_Description3.Text)
                dbDataSet_Misc.Tables("Selected").Rows(0).Item(11) = sngPrice
                dbDataSet_Misc.Tables("Selected").Rows(0).Item(12) = Trim(tbox_MaterialHeat.Text)
                dbDataSet_Misc.Tables("Selected").Rows(0).Item(13) = Trim(tbox_LineItem.Text)
                dbAdapter_Misc.Update(dbDataSet_Misc, "Selected")
                cb0 = Nothing
            Case 2 'Save new additions to database table
                For intStep = 0 To 11
                    If cbx_MultiDueDate.Checked = False Or cbx_MultiDueDate.Checked = True And tbox_LineItems(intStep).Text <> "" Then 'After 1st save, save only if line item number valid
                        Dim cb1 As New OleDb.OleDbCommandBuilder(dbAdapter_Misc)
                        Dim dsNewRow As DataRow
                        dsNewRow = dbDataSet_Misc.Tables("Selected").NewRow()
                        dsNewRow.Item("CustCode") = lbl_CustCode.Text
                        dsNewRow.Item("PurchaseOrder") = Trim(tbox_PurchaseOrder.Text)
                        dsNewRow.Item("DrawingNumber") = Trim(tbox_DrawNumber.Text)
                        dsNewRow.Item("DrawingRevision") = Trim(tbox_DrawRev.Text)
                        dsNewRow.Item("OrderDate") = lbl_OrderDate.Text
                        If cbx_MultiDueDate.Checked = False Then
                            dsNewRow.Item("POItem") = Trim(tbox_LineItem.Text)
                            dsNewRow.Item("DueDate") = Trim(tbox_DueDate.Text)
                        Else
                            dsNewRow.Item("POItem") = Trim(tbox_LineItems(intStep).Text)
                            dsNewRow.Item("DueDate") = Trim(tbox_DueDates(intStep).Text)
                        End If
                        If cbx_MultiQuantity.Checked = False Then
                            dsNewRow.Item("QtyOrdered") = Trim(tbox_Quantity.Text)
                        Else
                            dsNewRow.Item("QtyOrdered") = Trim(tbox_Quantitys(intStep).Text)
                        End If
                        dsNewRow.Item("DescripA") = Trim(tbox_Description1.Text)
                        dsNewRow.Item("DescripB") = Trim(tbox_Description2.Text)
                        dsNewRow.Item("DescripC") = Trim(tbox_Description3.Text)
                        dsNewRow.Item("Price") = sngPrice
                        dsNewRow.Item("MaterialHeat") = Trim(tbox_MaterialHeat.Text)
                        dbDataSet_Misc.Tables("Selected").Rows.Add(dsNewRow)
                        dbAdapter_Misc.Update(dbDataSet_Misc, "Selected")
                        cb1 = Nothing
                        If cbx_MultiDueDate.Checked = False Then Exit For 'No multiples ( only one new record )
                    End If
                Next
        End Select

        'On new purchase order, check if customer selected from all customers is set to active
        If EditNew = 2 And opt_NonActive.Checked = True Then
            strSQL = "SELECT CustCode,Active FROM Customers WHERE CustCode = " & lbl_CustCode.Text & ";"
            dbDataSet_Misc.Clear()
            dbDataSet_Misc.Tables.Clear()
            gbl_DstConnect.Open()
            dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
            dbAdapter_Misc.Fill(dbDataSet_Misc, "ActiveCheck")
            gbl_DstConnect.Close()
            If dbDataSet_Misc.Tables("ActiveCheck").Rows.Count <> 0 Then
                If dbDataSet_Misc.Tables("ActiveCheck").Rows(0).Item(1) = False Then 'New purchase order from non active customer
                    Dim cb2 As New OleDb.OleDbCommandBuilder(dbAdapter_Misc)
                    dbDataSet_Misc.Tables("ActiveCheck").Rows(0).Item(1) = True
                    dbAdapter_Misc.Update(dbDataSet_Misc, "ActiveCheck")
                    cb2 = Nothing
                End If
            End If
        End If

        'Store saved vitals before form clear
        Dim listCust, listPO, listDraw As String
        Dim ListDate As Date
        listCust = lbl_Company.Text
        listPO = Trim(tbox_PurchaseOrder.Text)
        listDraw = Trim(tbox_DrawNumber.Text)
        If cbx_MultiDueDate.Checked = False Then ListDate = Trim(tbox_DueDate.Text) Else ListDate = Trim(tbox_DueDates(0).Text)
        Call LastSelectClear()

        If booRepeat = True And EditNew = 2 Then
            Call ClearData(False)
            booRepeat = False
            cmd_ExitSave.Text = "Exit"
            cmd_ExitSave.Image = My.Resources.Resources._Exit
            cmd_ExitSave.Enabled = True   'View exit button
            cmd_RepeatSave.Visible = False
            intLineItem = intLineItem + 1
            tbox_LineItem.Text = intLineItem
            tbox_DrawNumber.Focus()
        Else
            EditNew = 0
            cbx_MultiDueDate.Visible = False
            cbx_MultiQuantity.Visible = False
            Call EnableEdits(False)
            Call FileOperationReset()
            Call CustomerListFill(0) 'Fill listbox_customers with updated customers with open purchase orders

            'Locate saved data in recordset
            Dim Pos As Integer
            Pos = Listbox_Customers.FindString(listCust) 'Customer
            If Pos <> -1 Then Listbox_Customers.SelectedIndex = Pos Else Listbox_Customers.SelectedIndex = 0
            Call Search(1)

            Pos = ListBox_PurchaseOrders.FindString(listPO) 'Purchase orders
            If Pos <> -1 Then ListBox_PurchaseOrders.SelectedIndex = Pos Else ListBox_PurchaseOrders.SelectedIndex = 0
            Call Search(2)

            Pos = ListBox_DrawNumbers.FindString(listDraw) 'Drawing numbers
            If Pos <> -1 Then ListBox_DrawNumbers.SelectedIndex = Pos Else ListBox_DrawNumbers.SelectedIndex = 0
            Call Search(3)

            Pos = ListBox_DueDates.FindString(ListDate) 'Due dates
            If Pos <> -1 Then ListBox_DueDates.SelectedIndex = Pos Else ListBox_DueDates.SelectedIndex = 0
            Call Search(4)
        End If

        Exit Sub
goActionErr:
        MsgBox(Err.Description)
        Exit Sub
    End Sub
    Private Sub cmd_RepeatSave_Click(sender As Object, e As EventArgs) Handles cmd_RepeatSave.Click
        booRepeat = True
        cmd_ExitSave.PerformClick()
    End Sub
    Private Sub FileOperationReset()
        cmd_Edit.Enabled = True   'View Edit button
        cmd_NewRestore.Text = "New"
        cmd_NewRestore.Image = My.Resources.Resources._New
        cmd_NewRestore.Enabled = True   'View new button
        cmd_DeleteCancel.Text = "Delete"
        cmd_DeleteCancel.Image = My.Resources.Resources.Delete
        cmd_DeleteCancel.Enabled = True   'View delete button
        cmd_ExitSave.Text = "Exit"
        cmd_ExitSave.Image = My.Resources.Resources._Exit
        cmd_ExitSave.Enabled = True   'View exit button
        cmd_RepeatSave.Visible = False
    End Sub
    Private Sub opt_AutoFill_Click(sender As Object, e As EventArgs) Handles opt_AutoFill.Click
        If opt_AutoFill.Checked = False Then Exit Sub
        opt_AutoFill.Checked = False

        strSQL = "SELECT DrawingRevision,DescripA,DescripB,DescripC,Price FROM Invoice " _
      & "Where CustCode = " & lbl_CustCode.Text & " AND DrawingNumber = '" & Trim(tbox_DrawNumber.Text) & "' ORDER BY OrderDate DESC ;"

        dbDataSet_Misc.Clear()
        dbDataSet_Misc.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter_Misc.Fill(dbDataSet_Misc, "AutoFill")
        gbl_DstConnect.Close()
        If dbDataSet_Misc.Tables("AutoFill").Rows.Count <> 0 Then
            booDataChecked = True
            If Not IsDBNull(dbDataSet_Misc.Tables("AutoFill").Rows(0).Item(0)) Then 'Drawing Revision
                tbox_DrawRev.Text = Trim(dbDataSet_Misc.Tables("AutoFill").Rows(0).Item(0))
            Else : tbox_DrawRev.Text = "" : End If

            If Not IsDBNull(dbDataSet_Misc.Tables("AutoFill").Rows(0).Item(1)) Then 'Description line 1
                tbox_Description1.Text = Trim(dbDataSet_Misc.Tables("AutoFill").Rows(0).Item(1))
            Else : tbox_Description1.Text = "" : End If

            If Not IsDBNull(dbDataSet_Misc.Tables("AutoFill").Rows(0).Item(2)) Then 'Description line 2
                tbox_Description2.Text = Trim(dbDataSet_Misc.Tables("AutoFill").Rows(0).Item(2))
            Else : tbox_Description2.Text = "" : End If

            If Not IsDBNull(dbDataSet_Misc.Tables("AutoFill").Rows(0).Item(3)) Then 'Description line 3
                tbox_Description3.Text = Trim(dbDataSet_Misc.Tables("AutoFill").Rows(0).Item(3))
            Else : tbox_Description3.Text = "" : End If

            If Not IsDBNull(dbDataSet_Misc.Tables("AutoFill").Rows(0).Item(4)) Then 'Price
                tbox_Price.Text = FormatCurrency(Trim(dbDataSet_Misc.Tables("AutoFill").Rows(0).Item(4)))
            Else : tbox_Price.Text = "" : End If
            booDataChecked = False
            tbox_LineItem.Focus()
        Else
            booCorrection = True
            frm_Message.Text = "6:1:0:1:3:There where no past records on file with this Drawing Number to autofill from"
            frm_Message.ShowDialog()
            tbox_DrawRev.Text = ""
            tbox_Description1.Text = ""
            tbox_Description2.Text = ""
            tbox_Description3.Text = ""
            tbox_Quantity.Text = ""
            tbox_Price.Text = ""
            lbl_TotalPrice.Text = ""
            tbox_DrawRev.Focus()
            booCorrection = False
        End If

    End Sub

    'All texbox handlers
    Private Sub tbox_GotFocus(sender As Object, e As EventArgs) Handles tbox_PurchaseOrder.GotFocus, tbox_DrawNumber.GotFocus, tbox_DrawRev.GotFocus, tbox_LineItem.GotFocus, tbox_DueDate.GotFocus, tbox_Quantity.GotFocus, tbox_Description1.GotFocus, tbox_Description2.GotFocus, tbox_Description3.GotFocus, tbox_Price.GotFocus, tbox_MaterialHeat.GotFocus
        sender.BackColor = (Color.FromArgb(255, 255, 192))
        Select Case sender.name
            Case "tbox_PurchaseOrder", "tbox_DrawNumber", "tbox_DrawRev", "tbox_MaterialHeat"
                sender.CharacterCasing = CharacterCasing.Upper
        End Select
    End Sub
    Private Sub tbox_LostFocus(sender As Object, e As EventArgs) Handles tbox_PurchaseOrder.LostFocus, tbox_DrawNumber.LostFocus, tbox_DrawRev.LostFocus, tbox_LineItem.LostFocus, tbox_DueDate.LostFocus, tbox_Quantity.LostFocus, tbox_Description1.LostFocus, tbox_Description2.LostFocus, tbox_Description3.LostFocus, tbox_Price.LostFocus, tbox_MaterialHeat.LostFocus
        If booCorrection = True Or booDataChecked = True Then sender.BackColor = Color.White : Exit Sub
        Select Case sender.Name
            Case "tbox_DrawRev"
                If sender.text <> "" Then 'Test entry for only letters
                    For i = 0 To sender.text.Length - 1
                        If Not UCase(sender.text(i)) Like "[A-Z]" Then
                            booCorrection = True
                            frm_Message.Text = "6:1:0:1:2:Drawing Rev can only be letters"
                            frm_Message.ShowDialog()
                            sender.text = ""
                            sender.Focus()
                            booCorrection = False
                            Exit For
                        End If
                    Next
                End If
            Case "tbox_DueDate"
                If IsDate(sender.Text) = False And sender.Text <> "  /  /" Then
                    sender.BackColor = Color.Aqua
                    booCorrection = True
                    frm_Message.Text = "6:1:0:1:3:The date entered is not valid, Please enter a valid date"
                    frm_Message.ShowDialog()
                    sender.text = ""
                    sender.Focus()
                    booCorrection = False
                    Exit Sub
                End If
            Case "tbox_Quantity", "tbox_Price", "tbox_LineItem"
                If sender.Text <> "" Then
                    If Not IsNumeric(sender.Text) Then
                        booCorrection = True
                        frm_Message.Text = "6:1:0:1:3:Invalid Entry --- Numerical entries are only allowed"
                        frm_Message.ShowDialog()
                        lbl_TotalPrice.Text = ""
                        sender.text = ""
                        sender.Focus()
                        booCorrection = False
                        Exit Sub
                    Else
                        Select Case sender.name
                            Case "tbox_Quantity" : If IsNumeric(tbox_Price.Text) Then lbl_TotalPrice.Text = FormatCurrency(tbox_Price.Text * tbox_Quantity.Text)
                            Case "tbox_Price"
                                tbox_Price.Text = FormatCurrency(tbox_Price.Text)
                                If IsNumeric(tbox_Quantity.Text) Then lbl_TotalPrice.Text = FormatCurrency(tbox_Price.Text * tbox_Quantity.Text)
                        End Select
                    End If
                Else : lbl_TotalPrice.Text = "" : End If
        End Select
        sender.BackColor = Color.White
    End Sub
    Private Sub tbox_TextChanged(sender As Object, e As EventArgs) Handles tbox_PurchaseOrder.TextChanged, tbox_DrawNumber.TextChanged, tbox_DrawRev.TextChanged, tbox_LineItem.TextChanged, tbox_DueDate.TextChanged, tbox_Quantity.TextChanged, tbox_Description1.TextChanged, tbox_Description2.TextChanged, tbox_Description3.TextChanged, tbox_Price.TextChanged, tbox_MaterialHeat.TextChanged
        If EditNew = 0 Or booDataChecked = True Then Exit Sub 'Skip if pre_processed data  
        If sender.name = "tbox_DrawNumber" And tbox_DrawNumber.Text <> "" Then

            'Fill listbox drawing number with old drawing numbers matching entry and customer
            strSQL = "SELECT Distinct DrawingNumber FROM Invoice Where CustCode = " & lbl_CustCode.Text & " AND " _
                   & "DrawingNumber LIKE '" & Trim(tbox_DrawNumber.Text) & "%" & "' ORDER BY DrawingNumber;"
            dbDataSet_Misc.Clear()
            dbDataSet_Misc.Tables.Clear()
            gbl_DstConnect.Open()
            dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
            dbAdapter_Misc.Fill(dbDataSet_Misc, "DrawNumber")
            gbl_DstConnect.Close()
            If dbDataSet_Misc.Tables("DrawNumber").Rows.Count >= 1 Then 'Records found  
                If booListbox = False Then Listbox_DNShow(True)
                ListBox_DN_Search.Items.Clear()

                Dim num As Integer
                For num = 0 To dbDataSet_Misc.Tables("DrawNumber").Rows.Count - 1
                    ListBox_DN_Search.Items.Add(dbDataSet_Misc.Tables("DrawNumber").Rows(num).Item(0))
                Next
                If num > 16 Then num = 16
                ListBox_DN_Search.Height = num * 19
            Else
                Listbox_DNShow(False)
            End If
        End If

        Call EditSave()
    End Sub 
    Private Sub tbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbox_PurchaseOrder.KeyPress, tbox_DrawNumber.KeyPress, tbox_DrawRev.KeyPress, tbox_LineItem.KeyPress, tbox_DueDate.KeyPress, tbox_Quantity.KeyPress, tbox_Description1.KeyPress, tbox_Description2.KeyPress, tbox_Description3.KeyPress, tbox_Price.KeyPress, tbox_MaterialHeat.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            Select Case sender.Name
                Case "tbox_PurchaseOrder" : tbox_DrawNumber.Focus()
                Case "tbox_DrawNumber" : tbox_DrawRev.Focus() : If tbox_DrawNumber.Text <> "" Then opt_AutoFill.Visible = True
                Case "tbox_DrawRev" : tbox_LineItem.Focus()
                Case "tbox_LineItem" : If cbx_MultiDueDate.Checked = False Then tbox_DueDate.Focus() Else tbox_LineItems(0).Focus()
                Case "tbox_DueDate" : tbox_Quantity.Focus()
                Case "tbox_Quantity" : tbox_Description1.Focus()
                Case "tbox_Description1" : tbox_Description2.Focus()
                Case "tbox_Description2" : tbox_Description3.Focus()
                Case "tbox_Description3" : tbox_Price.Focus()
                Case "tbox_Price" : tbox_MaterialHeat.Focus()
                Case "tbox_MaterialHeat" : tbox_PurchaseOrder.Focus()
            End Select
        End If
    End Sub
    Private Sub tbox_MultiDates_GotFocus(sender As Object, e As EventArgs)
        sender.BackColor = (Color.FromArgb(255, 255, 192))
    End Sub
    Private Sub tbox_MultiDates_LostFocus(sender As Object, e As EventArgs)
        If booCorrection = True Then sender.BackColor = Color.White : Exit Sub

        Select Case sender.Name
            Case "tbox_DueDates"
                If IsDate(sender.Text) = False And sender.Text <> "  /  /" Then
                    sender.BackColor = Color.Aqua
                    booCorrection = True
                    frm_Message.Text = "6:1:0:1:3:The date entered is not valid, Please enter a valid date"
                    frm_Message.ShowDialog()
                    sender.text = ""
                    sender.Focus()
                    booCorrection = False
                    Exit Sub
                End If
            Case "tbox_LineItems", "tbox_Quantitys"
                If sender.Text <> "" Then
                    If Not IsNumeric(sender.Text) Then
                        booCorrection = True
                        frm_Message.Text = "6:1:0:1:3:Invalid Entry --- Numerical entries are only allowed"
                        frm_Message.ShowDialog()
                        sender.text = ""
                        sender.Focus()
                        booCorrection = False
                        Exit Sub
                    End If
                End If
        End Select
        sender.BackColor = Color.White
    End Sub
    Private Sub tbox_MultiDates_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Return) Then
            If cbx_MultiQuantity.Checked = True Then 'Dates and quantitys 
                Select Case sender.Name
                    Case "tbox_LineItems" : tbox_DueDates(sender.tag).Focus()
                    Case "tbox_DueDates" : tbox_Quantitys(sender.tag).Focus()
                    Case "tbox_Quantitys" : If sender.tag < 11 Then tbox_LineItems(sender.tag + 1).Focus() Else tbox_Description1.Focus()
                End Select
            Else 'Only dates 
                Select Case sender.Name
                    Case "tbox_LineItems" : tbox_DueDates(sender.tag).Focus()
                    Case "tbox_DueDates" : If sender.tag < 11 Then tbox_LineItems(sender.tag + 1).Focus() Else tbox_Quantity.Focus()
                End Select
            End If
        End If
    End Sub
    Private Sub tbox_MultiDates_MouseClick(sender As Object, e As EventArgs) Handles tbox_DueDate.MouseClick
        If sender.Text = "  /  /" Then sender.SelectionStart = 0
    End Sub

    'Handler sub routines
    Private Sub EditSave()
        If booListbox = True Then Exit Sub
        If EditNew = 1 Then cmd_NewRestore.Enabled = True
        cmd_ExitSave.Text = "Save"
        cmd_ExitSave.Image = My.Resources.Resources.Save
        cmd_ExitSave.Enabled = True
        If EditNew = 2 Then cmd_RepeatSave.Visible = True
    End Sub

    'All mouse movement and mouse over messages
    Private Sub ListBox1_MouseEnter(sender As Object, e As EventArgs) Handles Listbox_Customers.MouseEnter
        Listbox_Customers.Focus()
    End Sub
    Private Sub fra_MouseMove() Handles fra_List.MouseMove, fra_Information.MouseMove, fra_MultipleEntry.MouseMove 'Clear message
        intMessage = 0
        Call MouseMessages()
    End Sub
    Private Sub tbox_MouseHover(sender As Object, e As EventArgs) Handles Listbox_Customers.MouseHover, ListBox_PurchaseOrders.MouseHover, ListBox_DrawNumbers.MouseHover, ListBox_DueDates.MouseHover, cbx_MultiDueDate.MouseHover, cbx_MultiQuantity.MouseHover, tbox_MaterialHeat.MouseHover, lbl_Identifier.MouseHover
        Select Case sender.name
            Case "Listbox_Customers" : intMessage = 1
            Case "ListBox_PurchaseOrders" : intMessage = 2
            Case "ListBox_DrawNumbers" : intMessage = 3
            Case "ListBox_DueDates" : intMessage = 4
            Case "cbx_MultiDueDate" : intMessage = 5
            Case "cbx_MultiQuantity" : intMessage = 6
            Case "tbox_MaterialHeat" : intMessage = 7
            Case "lbl_Identifier" : intMessage = 8
        End Select
        Call MouseMessages()
    End Sub
    Private Sub MouseMessages()
        Select Case intMessage
            Case 0 : lbl_Message.Text = "" 'Clear message from screen
            Case 1
                Select Case EditNew
                    Case 0 : lbl_Message.Text = "Select customers name to start search for viewing customer's purchase orders"
                    Case 2 : lbl_Message.Text = "Select the customers name from the list to be used to enter a new purchase order"
                End Select
            Case 2 : lbl_Message.Text = "Select purchase order number to narrow search"
            Case 3 : lbl_Message.Text = "Select drawing number to narrow search"
            Case 4 : lbl_Message.Text = "Select due date to finalize search"
            Case 5 : lbl_Message.Text = "Check this box if there's multiple due dates for the same item"
            Case 6 : lbl_Message.Text = "Check this box if the multiple due dates have varied quantitys"
            Case 7 : lbl_Message.Text = "Enter the heat number form the Material Certificate that the item was manufactured from"
            Case 8 : lbl_Message.Text = "Use this unique number to reference this purchase order to the certificate heat number"
        End Select
    End Sub


End Class