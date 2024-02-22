Public Class frm_Customer
    Dim dbAdapter, dbAdapter_Misc As OleDb.OleDbDataAdapter
    Dim dbDataSet, dbDataSet_Misc As New DataSet
    Dim strSQL As String

    Dim lbl_OrderYear(9) As Label
    Dim lbl_OrdersReceived(9) As Label
    Dim lbl_ValueReceived(9) As Label
    Dim lbl_OrdersShip(9) As Label
    Dim lbl_ValueShip(9) As Label
    Dim lbl_IncomePercent(9) As Label

    Dim ListArray(1, 1) As Integer 'Used to link dataset to listbox selection
    Dim EditNew As Integer '0 = no process, 1 = edit in process, 2 = new in process
    Dim booDataChecked As Boolean = True 'T = data change is from a controled process
    Dim booActives As Boolean 'T = active entries found in database
    Dim booNameCheck, booCorrection As Boolean 'T = Test for repeat of name has been done
    Dim intTotalRecords, AutoNum As Integer
    Dim strInitEntry, strNotes As String 'Variables to hold initial entries of textboxes to test for change
    Dim intLookup As Integer 'Used to locate edited / new saved record in listbox
    Dim intMessage As Integer 'Variable used in the mouse over event to show different messages

    'All form related events
    Private Sub frm_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated
        Call Actives()
    End Sub
    Private Sub frm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.Text = "Customers Information                                                                                                                Date: " & Now.Date
        If booActives = True Then opt_Active.Checked = True Else opt_NonActive.Checked = True
    End Sub
    Private Sub Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        dbDataSet.Clear()
        dbDataSet.Tables.Clear()
        dbDataSet_Misc.Clear()
        dbDataSet_Misc.Tables.Clear()
        Me.Dispose()
    End Sub
    Private Sub Actives() 'Check if there are active particpants in the database
        strSQL = "SELECT CustCode FROM Customers Where Active = True"
        dbDataSet_Misc.Clear()
        dbDataSet_Misc.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter_Misc.Fill(dbDataSet_Misc, "Actives")
        gbl_DstConnect.Close()
        If dbDataSet_Misc.Tables("Actives").Rows.Count = 0 Then booActives = False Else booActives = True

    End Sub
    Private Sub Opt_Active_CheckedChanged() Handles opt_Active.CheckedChanged, opt_NonActive.CheckedChanged 'Index recordset based on selected option button
        If opt_Active.Checked = True And booActives = False Then 'No active partipants to show
            frm_Message.Text = "3:1:0:1:3:There are no active customers on record to show"
            frm_Message.ShowDialog()
            opt_NonActive.Checked = True
            Exit Sub
        End If
        If opt_Active.Checked = True Then ListData(True) Else ListData(False)
    End Sub
    Private Sub ListData(booActive As Boolean)
        If booActive = True Then
            strSQL = "SELECT CustCode,Company FROM Customers Where Active = True ORDER BY Company;"
        Else
            strSQL = "SELECT CustCode,Company FROM Customers ORDER BY Company;"
        End If

        Call ClearData()
        dbDataSet_Misc.Clear()
        dbDataSet_Misc.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter_Misc.Fill(dbDataSet_Misc, "Customers")
        gbl_DstConnect.Close()
        intTotalRecords = dbDataSet_Misc.Tables("Customers").Rows.Count
        ReDim ListArray(0 To intTotalRecords - 1, 1)

        ListBox1.Items.Clear()
        If intTotalRecords = 0 Then 'No customers found, allow only new customers, disable listbox and hide option active button 
            ListBox1.Enabled = False
            cmd_Edit.Enabled = False  'Disable edit button
            cmd_DeleteCancel.Enabled = False 'Disable cancel button

            'Open empty recordset for new records to be added to since customers cannot be selected from listbox1
            strSQL = "SELECT CustCode,Active,Company,Contact,Address,City,State,ZipCode,Phone,PhoneCell,Email, " _
                   & "BCompany,BContact,BAddress,BCity,BState,BZipCode,BPhone,BPhoneCell,BEmail, " _
                   & "Certification,Freight,FreightAccount,FreightWebSite,PreShipDays,Notes FROM Customers;"
            dbDataSet.Clear()
            dbDataSet.Tables.Clear()
            gbl_DstConnect.Open()
            dbAdapter = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
            dbAdapter.Fill(dbDataSet, "Customers")
            gbl_DstConnect.Close()

            frm_Message.Text = "3:1:0:1:3:There are no records on file to view, [New] is the only operation allowed"
            frm_Message.ShowDialog()
        Else 'Fill listbox with data

            Dim varhold As Object
            Dim inc As Integer

            For inc = 0 To dbDataSet_Misc.Tables("Customers").Rows.Count - 1

                ListArray(inc, 0) = inc 'Listbox index

                varhold = dbDataSet_Misc.Tables("Customers").Rows(inc).Item(0) 'CustCode
                If IsDBNull(varhold) Then varhold = ""
                ListArray(inc, 1) = Trim(varhold)

                varhold = dbDataSet_Misc.Tables("Customers").Rows(inc).Item(1) 'CompanyName
                If IsDBNull(varhold) Then varhold = "" Else varhold = Replace(varhold, "^", "'")
                ListBox1.Items.Add(varhold)
            Next

            'Select name in listbox if possible, if listdata called after save operation
            Dim Num1 As Integer
            If EditNew = 0 Then
                ListBox1.SelectedIndex = 0
                intLookup = ListArray(ListBox1.SelectedIndex, 1)
            Else
                For intStep1 = 0 To UBound(ListArray, 1)
                    Num1 = ListArray(intStep1, 1)
                    If ListArray(intStep1, 1) = intLookup Then
                        ListBox1.SelectedIndex = ListArray(intStep1, 0)
                        Exit For
                    End If
                    If intStep1 = UBound(ListArray, 1) Then ListBox1.SelectedIndex = 0
                Next
            End If

            opt_Active.Enabled = True
            opt_NonActive.Enabled = True
            Call DataFill()
        End If

    End Sub
    Private Sub ListBox1_Click() Handles ListBox1.Click, ListBox1.DoubleClick
        cmd_Edit.Enabled = True  'Show Edit button
        cmd_DeleteCancel.Enabled = True   'Show delete/cancel button
        intLookup = ListArray(ListBox1.SelectedIndex, 1)
        Call ClearData()
        Call DataFill()
    End Sub
    Private Sub DataFill() 'Fill form with data pertaining to listbox selection

        strSQL = "SELECT CustCode,Active,Company,Contact,Address,City,State,ZipCode,Phone,PhoneCell,Email," _
               & "BCompany,BContact,BAddress,BCity,BState,BZipCode,BPhone,BPhoneCell,BEmail," _
               & "Certification,Freight,FreightAccount,ShipVia,FreightWebSite,PreShipDays,Notes FROM Customers WHERE CustCode = " & intLookup & ";"
        dbDataSet.Clear()
        dbDataSet.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter.Fill(dbDataSet, "Selected")
        gbl_DstConnect.Close()

        'Form fill data
        booDataChecked = True 'Textbox data changes with pre_processed data

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(0)) Then 'CustCode
            lbl_CustCode.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(0))
        Else : lbl_CustCode.Text = "" : End If

        If dbDataSet.Tables("Selected").Rows(0).Item(1) = False Then cbx_Active.Checked = False Else cbx_Active.Checked = True 'Active

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(2)) Then 'CompanyName
            tbox_Company1.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(2))
        Else : tbox_Company1.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(3)) Then 'Company contact
            tbox_Contact1.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(3))
        Else : tbox_Contact1.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(4)) Then 'Address
            tbox_Address1.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(4))
        Else : tbox_Address1.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(5)) Then 'City
            tbox_City1.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(5))
        Else : tbox_City1.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(6)) Then 'State
            tbox_State1.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(6))
        Else : tbox_State1.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(7)) Then 'Zipcode
            tbox_ZipCode1.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(7))
        Else : tbox_ZipCode1.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(8)) Then 'Phone
            tbox_Phone1.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(8))
        Else : tbox_Phone1.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(9)) Then 'Cell Phone
            tbox_PhoneCell1.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(9))
        Else : tbox_PhoneCell1.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(10)) Then 'Email
            tbox_Email1.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(10))
        Else : tbox_Email1.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(11)) Then 'Company Billing Name
            tbox_Company2.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(11))
        Else : tbox_Company2.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(12)) Then 'Company Billing contact
            tbox_Contact2.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(12))
        Else : tbox_Contact2.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(13)) Then 'Billing Address
            tbox_Address2.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(13))
        Else : tbox_Address2.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(14)) Then 'Billing City
            tbox_City2.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(14))
        Else : tbox_City2.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(15)) Then 'Billing State
            tbox_State2.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(15))
        Else : tbox_State2.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(16)) Then 'Billing Zipcode
            tbox_ZipCode2.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(16))
        Else : tbox_ZipCode2.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(17)) Then 'Billing Phone
            tbox_Phone2.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(17))
        Else : tbox_Phone2.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(18)) Then 'Billing Cell Phone
            tbox_PhoneCell2.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(18))
        Else : tbox_PhoneCell2.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(19)) Then 'Billing Email
            tbox_Email2.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(19))
        Else : tbox_Email2.Text = "" : End If

        If dbDataSet.Tables("Selected").Rows(0).Item(20) = True Then cbx_Certification.Checked = True Else cbx_Certification.Checked = False 'Certification option 

        If dbDataSet.Tables("Selected").Rows(0).Item(21) = True Then cbx_Freight.Checked = True Else cbx_Freight.Checked = False 'Freight option 

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(22)) Then 'Freight account number
            tbox_FreightAccount.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(22))
        Else : tbox_FreightAccount.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(23)) Then 'Shiping method ( Fedex,UPS )
            tbox_ShipVia.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(23))
        Else : tbox_ShipVia.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(24)) Then 'Freight Web Site
            tbox_FreightWebSite.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(24))
        Else : tbox_FreightWebSite.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(25)) Then 'Pre Ship Days
            tbox_PreShip.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(25))
        Else : tbox_PreShip.Text = 0 : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(26)) Then 'Notes
            tbox_Notes.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(26))
        Else : tbox_Notes.Text = "" : End If

        strSQL = "SELECT OrderDate FROM Invoice Where CustCode = " & lbl_CustCode.Text & " ORDER by OrderDate DESC;"
        dbDataSet_Misc.Clear()
        dbDataSet_Misc.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter_Misc.Fill(dbDataSet_Misc, "LastOrder")
        gbl_DstConnect.Close()
        If dbDataSet_Misc.Tables("LastOrder").Rows.Count <> 0 Then
            If Not IsDBNull(dbDataSet_Misc.Tables("LastOrder").Rows(0).Item(0)) And dbDataSet_Misc.Tables("LastOrder").Rows(0).Item(0).ToString <> "#12/12/1212#" Then 'Last order date
                lbl_LastOrder.Text = dbDataSet_Misc.Tables("LastOrder").Rows(0).Item(0) : cmd_Calculate.Enabled = True
            Else : lbl_LastOrder.Text = "None" : cmd_Calculate.Enabled = False : End If
        End If

        booDataChecked = False
    End Sub
    Private Sub CalculateHistory()

        'Test for records on file to generate report from
        If lbl_LastOrder.Text = "" Then
            frm_Message.Text = "3:1:0:1:3:There are no records on file to generate a history report from"
            frm_Message.ShowDialog()
            Exit Sub
        End If

        cmd_Calculate.Enabled = False
        Cursor.Current = Cursors.WaitCursor

        Dim intStep1, intStep2, intQty, OrderYears, ShipYears, ExitYears As Integer
        If lbl_OrderYear(0) Is Nothing Then Call AddControls() 'Add labels if first time

        Dim OrderDate As Date = Convert.ToDateTime(lbl_LastOrder.Text) 'Convert string to date
        Dim strYearStart As String = New DateTime(OrderDate.Year, 1, 1) 'Calculate first day of year as string
        Dim datYearStart As Date = Convert.ToDateTime(strYearStart) 'Convert first day of year( string) to date
        Dim strYearStop As String = datYearStart.AddYears(1) 'Add one year from date
        Dim datYearStop As Date = Convert.ToDateTime(strYearStop) 'Convert next year(string) to date
        Dim ItemPrice, TotalPrice, YearTotal As Single

        'Calculate total of distinct years (OrderDate) for selected customer
        strSQL = "SELECT DISTINCT YEAR(OrderDate) FROM Invoice Where CustCode = " & lbl_CustCode.Text & ";"
        dbDataSet_Misc.Clear()
        dbDataSet_Misc.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter_Misc.Fill(dbDataSet_Misc, "CountYears")
        gbl_DstConnect.Close()
        OrderYears = dbDataSet_Misc.Tables("CountYears").Rows.Count

        'Calculate total of distinct years (ShipDate) for selected customer
        strSQL = "SELECT DISTINCT YEAR(ShipDate) FROM Invoice Where CustCode = " & lbl_CustCode.Text & ";"
        dbDataSet_Misc.Clear()
        dbDataSet_Misc.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter_Misc.Fill(dbDataSet_Misc, "CountYears")
        gbl_DstConnect.Close()
        ShipYears = dbDataSet_Misc.Tables("CountYears").Rows.Count
        If OrderYears >= ShipYears Then ExitYears = OrderYears Else ExitYears = ShipYears 'Set ExitYears to the larger of the two table counts

        Dim Fail As Integer = 0
        For intStep1 = 0 To 9
            If intStep1 <> 0 Then
                strYearStart = datYearStart.AddYears(-1) : datYearStart = Convert.ToDateTime(strYearStart)
                strYearStop = datYearStop.AddYears(-1) : datYearStop = Convert.ToDateTime(strYearStop)
            End If

            'Calculate total shipped income for selected year
            strSQL = "SELECT QtyShip,QtyOrdered,price FROM Invoice Where ShipDate >= #" & datYearStart & "# AND ShipDate < #" & datYearStop & "#;"
            dbDataSet_Misc.Clear()
            dbDataSet_Misc.Tables.Clear()
            gbl_DstConnect.Open()
            dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
            dbAdapter_Misc.Fill(dbDataSet_Misc, "YearTotal")
            gbl_DstConnect.Close()
            YearTotal = 0
            If dbDataSet_Misc.Tables("YearTotal").Rows.Count <> 0 Then
                For intStep2 = 0 To dbDataSet_Misc.Tables("YearTotal").Rows.Count - 1

                    If Not IsDBNull(dbDataSet_Misc.Tables("YearTotal").Rows(intStep2).Item(0)) Then 'Quantity shipped
                        intQty = Trim(dbDataSet_Misc.Tables("YearTotal").Rows(intStep2).Item(0))
                    Else
                        If Not IsDBNull(dbDataSet_Misc.Tables("YearTotal").Rows(intStep2).Item(1)) Then 'Quantity ordered
                            intQty = Trim(dbDataSet_Misc.Tables("YearTotal").Rows(intStep2).Item(1))
                        Else : intQty = 0 : End If
                    End If

                    If Not IsDBNull(dbDataSet_Misc.Tables("YearTotal").Rows(intStep2).Item(2)) Then 'Price
                        ItemPrice = Trim(dbDataSet_Misc.Tables("YearTotal").Rows(intStep2).Item(2))
                    Else : ItemPrice = 0 : End If

                    YearTotal = YearTotal + (intQty * ItemPrice)
                Next
            End If

            'Calculate order count and order value for selected year
            strSQL = "SELECT QtyShip,QtyOrdered,price FROM Invoice Where CustCode = " & lbl_CustCode.Text & " AND OrderDate >= #" & datYearStart & "# AND OrderDate < #" & datYearStop & "#;"
            dbDataSet_Misc.Clear()
            dbDataSet_Misc.Tables.Clear()
            gbl_DstConnect.Open()
            dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
            dbAdapter_Misc.Fill(dbDataSet_Misc, "History")
            gbl_DstConnect.Close()
            TotalPrice = 0
            If dbDataSet_Misc.Tables("History").Rows.Count <> 0 Then
                For intStep2 = 0 To dbDataSet_Misc.Tables("History").Rows.Count - 1

                    If Not IsDBNull(dbDataSet_Misc.Tables("History").Rows(intStep2).Item(0)) Then 'Quantity shipped
                        intQty = Trim(dbDataSet_Misc.Tables("History").Rows(intStep2).Item(0))
                    Else
                        If Not IsDBNull(dbDataSet_Misc.Tables("History").Rows(intStep2).Item(1)) Then 'Quantity ordered
                            intQty = Trim(dbDataSet_Misc.Tables("History").Rows(intStep2).Item(1))
                        Else : intQty = 0 : End If
                    End If

                    If Not IsDBNull(dbDataSet_Misc.Tables("History").Rows(intStep2).Item(2)) Then 'Price
                        ItemPrice = Trim(dbDataSet_Misc.Tables("History").Rows(intStep2).Item(2))
                    Else : ItemPrice = 0 : End If

                    TotalPrice = TotalPrice + (intQty * ItemPrice)
                Next
                lbl_OrdersReceived(intStep1).Text = dbDataSet_Misc.Tables("History").Rows.Count 'Fill orders received label for selected year
            End If
            If TotalPrice <> 0 Then lbl_ValueReceived(intStep1).Text = FormatCurrency(TotalPrice) 'Fill orders received value label for selected year

            'Calculate shipped count and shipped value for selected year
            strSQL = "SELECT QtyShip,price FROM Invoice Where CustCode = " & lbl_CustCode.Text & " AND ShipDate >= #" & datYearStart & "# AND ShipDate < #" & datYearStop & "#;"
            dbDataSet_Misc.Clear()
            dbDataSet_Misc.Tables.Clear()
            gbl_DstConnect.Open()
            dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
            dbAdapter_Misc.Fill(dbDataSet_Misc, "History")
            gbl_DstConnect.Close()
            TotalPrice = 0
            If dbDataSet_Misc.Tables("History").Rows.Count <> 0 Then
                For intStep2 = 0 To dbDataSet_Misc.Tables("History").Rows.Count - 1

                    If Not IsDBNull(dbDataSet_Misc.Tables("History").Rows(intStep2).Item(0)) Then 'Quantity shipped
                        intQty = Trim(dbDataSet_Misc.Tables("History").Rows(intStep2).Item(0))
                    Else : intQty = 0 : End If

                    If Not IsDBNull(dbDataSet_Misc.Tables("History").Rows(intStep2).Item(1)) Then 'Price
                        ItemPrice = Trim(dbDataSet_Misc.Tables("History").Rows(intStep2).Item(1))
                    Else : ItemPrice = 0 : End If

                    TotalPrice = TotalPrice + (intQty * ItemPrice)
                Next
                lbl_OrdersShip(intStep1).Text = dbDataSet_Misc.Tables("History").Rows.Count 'Fill orders shipped label for selected year
            End If
            If TotalPrice <> 0 Then lbl_ValueShip(intStep1).Text = FormatCurrency(TotalPrice) 'Fill orders shipped value label for selected year

            Do 'Test for incomplete data line and skip line or fill in incomplete line with zero's for clarity (loop used only for quick exit)

                If lbl_OrdersReceived(intStep1).Text <> "" And lbl_OrdersShip(intStep1).Text <> "" Then 'Normal full line of data, Add year value
                    lbl_OrderYear(intStep1).Text = Format(datYearStart, "yyyy")
                    lbl_IncomePercent(intStep1).Text = FormatPercent((TotalPrice / YearTotal), 2)
                    Exit Do
                End If

                If lbl_OrdersReceived(intStep1).Text = "" And lbl_OrdersShip(intStep1).Text = "" Then intStep1 = intStep1 - 1 : Fail = Fail + 1 : Exit Do 'Empty line of data, Skip all

                If lbl_OrdersReceived(intStep1).Text = "" And lbl_OrdersShip(intStep1).Text <> "" Then 'Incomplete line of data (OrderShip),Add year value and zero for clarity
                    lbl_OrderYear(intStep1).Text = Format(datYearStart, "yyyy")
                    lbl_OrdersReceived(intStep1).Text = "0"
                    lbl_ValueReceived(intStep1).Text = "$0.00"
                    lbl_IncomePercent(intStep1).Text = FormatPercent((TotalPrice / YearTotal), 2)
                    Exit Do
                End If

                If lbl_OrdersReceived(intStep1).Text <> "" And lbl_OrdersShip(intStep1).Text = "" Then 'Incomplete line of data (OrderReceived),Add year value and zero for clarity
                    lbl_OrderYear(intStep1).Text = Format(datYearStart, "yyyy")
                    lbl_OrdersShip(intStep1).Text = "0"
                    lbl_ValueShip(intStep1).Text = "$0.00"
                    lbl_IncomePercent(intStep1).Text = FormatPercent((TotalPrice / YearTotal), 2)
                    Exit Do
                End If
            Loop

            If intStep1 = ExitYears - 1 Then Exit For 'Exit when all data searched
            If Fail = 25 Then Exit For 'Exit if in perpectual loop
        Next
        Cursor.Current = Cursors.Default
    End Sub
    Private Sub AddControls() 'Add history related controls
        Dim int_Top As Integer
        Dim i As Integer

        'Create array of controls in frame order history
        int_Top = 80
        For i = 0 To 9
            int_Top = int_Top + 20

            lbl_OrderYear(i) = New Label
            lbl_OrdersReceived(i) = New Label
            lbl_ValueReceived(i) = New Label
            lbl_OrdersShip(i) = New Label
            lbl_ValueShip(i) = New Label
            lbl_IncomePercent(i) = New Label

            With lbl_OrderYear(i)
                .Name = "lbl_OrderYear"
                .Tag = i
                .Font = New Font("Ariel", 8.25, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .Visible = True
                .SetBounds(25, int_Top, 31, 14)
                fra_OrderHistory.Controls.Add(lbl_OrderYear(i))
                AddHandler .MouseHover, AddressOf lbl_History_MouseHover
            End With

            With lbl_OrdersReceived(i)
                .Name = "lbl_OrdersReceived"
                .Tag = i
                .Font = New Font("Ariel", 8.25, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .Visible = True
                .SetBounds(63, int_Top, 52, 14)
                fra_OrderHistory.Controls.Add(lbl_OrdersReceived(i))
                AddHandler .MouseHover, AddressOf lbl_History_MouseHover
            End With

            With lbl_ValueReceived(i)
                .Name = "lbl_ValueReceived"
                .Tag = i
                .Font = New Font("Ariel", 8.25, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .Visible = True
                .SetBounds(117, int_Top, 78, 14)
                fra_OrderHistory.Controls.Add(lbl_ValueReceived(i))
                AddHandler .MouseHover, AddressOf lbl_History_MouseHover
            End With

            With lbl_OrdersShip(i)
                .Name = "lbl_OrdersShip"
                .Tag = i
                .Font = New Font("Ariel", 8.25, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .Visible = True
                .SetBounds(197, int_Top, 52, 14)
                fra_OrderHistory.Controls.Add(lbl_OrdersShip(i))
                AddHandler .MouseHover, AddressOf lbl_History_MouseHover
            End With

            With lbl_ValueShip(i)
                .Name = "lbl_ValueShip"
                .Tag = i
                .Font = New Font("Ariel", 8.25, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .Visible = True
                .SetBounds(251, int_Top, 78, 14)
                fra_OrderHistory.Controls.Add(lbl_ValueShip(i))
                AddHandler .MouseHover, AddressOf lbl_History_MouseHover
            End With

            With lbl_IncomePercent(i)
                .Name = "lbl_IncomePercent"
                .Tag = i
                .Font = New Font("Ariel", 8.25, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .Visible = True
                .SetBounds(334, int_Top, 52, 14)
                fra_OrderHistory.Controls.Add(lbl_IncomePercent(i))
                AddHandler .MouseHover, AddressOf lbl_History_MouseHover
            End With

            'Show 1st line, option medication selection 
            If i = 0 Then
                lbl_OrderYear(0).Visible = True
            End If
        Next
    End Sub
    Private Sub ClearData() 'Clear form of all data
        cbx_Active.Checked = False
        lbl_CustCode.Text = ""
        tbox_Company1.Text = ""
        tbox_Contact1.Text = ""
        tbox_Address1.Text = ""
        tbox_City1.Text = ""
        tbox_State1.Text = ""
        tbox_ZipCode1.Text = ""
        tbox_Phone1.Text = ""
        tbox_PhoneCell1.Text = ""
        tbox_Email1.Text = ""
        tbox_Company2.Text = ""
        tbox_Contact2.Text = ""
        tbox_Address2.Text = ""
        tbox_City2.Text = ""
        tbox_State2.Text = ""
        tbox_ZipCode2.Text = ""
        tbox_Phone2.Text = ""
        tbox_PhoneCell2.Text = ""
        tbox_Email2.Text = ""
        cbx_Freight.Checked = False
        tbox_FreightAccount.Text = ""
        tbox_ShipVia.Text = ""
        tbox_PreShip.Text = ""
        tbox_FreightWebSite.Text = ""
        tbox_Notes.Text = ""
        lbl_LastOrder.Text = ""

        If lbl_OrderYear(0) IsNot Nothing Then
            For intStep1 = 0 To 9
                lbl_OrderYear(intStep1).Text = ""
                lbl_OrdersReceived(intStep1).Text = ""
                lbl_ValueReceived(intStep1).Text = ""
                lbl_OrdersShip(intStep1).Text = ""
                lbl_ValueShip(intStep1).Text = ""
                lbl_IncomePercent(intStep1).Text = ""
            Next
        End If
        cmd_Calculate.Enabled = True

    End Sub
    Private Sub EnableEdits(blnStatus As Boolean)
        cbx_Active.Enabled = blnStatus
        tbox_Company1.Enabled = blnStatus
        tbox_Contact1.Enabled = blnStatus
        tbox_Phone1.Enabled = blnStatus
        tbox_PhoneCell1.Enabled = blnStatus
        tbox_Email1.Enabled = blnStatus
        btn_BillingCopy.Enabled = blnStatus
        tbox_Address1.Enabled = blnStatus
        tbox_City1.Enabled = blnStatus
        tbox_State1.Enabled = blnStatus
        tbox_ZipCode1.Enabled = blnStatus
        tbox_Company2.Enabled = blnStatus
        tbox_Contact2.Enabled = blnStatus
        tbox_Address2.Enabled = blnStatus
        tbox_City2.Enabled = blnStatus
        tbox_State2.Enabled = blnStatus
        tbox_ZipCode2.Enabled = blnStatus
        tbox_Phone2.Enabled = blnStatus
        tbox_PhoneCell2.Enabled = blnStatus
        tbox_Email2.Enabled = blnStatus
        cbx_Freight.Enabled = blnStatus
        If cbx_Freight.Checked = True Then tbox_FreightAccount.Enabled = blnStatus : tbox_ShipVia.Enabled = blnStatus
        tbox_PreShip.Enabled = blnStatus
        cbx_Certification.Enabled = blnStatus
        tbox_FreightWebSite.Enabled = blnStatus
        tbox_Notes.Enabled = blnStatus
    End Sub


    'All command actions ( Edit,New/Restore,DeleteCancel,Exit/Save )
    Private Sub cmd_Edit_Click() Handles cmd_Edit.Click

        If tbox_Company1.Text = "" Then Exit Sub
        EditNew = 1 'Set variable to edit on save
        ListBox1.Enabled = False
        opt_Active.Enabled = False
        opt_NonActive.Enabled = False
        Call EnableEdits(True)

        cmd_Edit.Enabled = False
        cmd_NewRestore.Enabled = False
        cmd_NewRestore.Text = "Restore"
        cmd_NewRestore.Image = My.Resources.Resources.Restore
        cmd_DeleteCancel.Text = "Cancel"
        cmd_DeleteCancel.Image = My.Resources.Resources.Cancel
        tbox_Company1.Focus()
    End Sub
    Private Sub cmd_NewRestore_Click(sender As Object, e As EventArgs) Handles cmd_NewRestore.Click
        Call ClearData()
        If cmd_NewRestore.Text = "New" Then
            EditNew = 2 'Set variable to new for save
            ListBox1.Enabled = False
            ListBox1.SelectedIndex = -1
            opt_Active.Enabled = False
            opt_NonActive.Enabled = False

            Call EnableEdits(True)
            If AutoNum <> 0 Then lbl_CustCode.Text = AutoNum + 1 'Show new CustCode only if autonum established from previous entry

            booNameCheck = False
            tbox_Company1.Focus()

            cmd_Edit.Enabled = False  'Disable edit button
            cmd_NewRestore.Enabled = False  'Disable new/restore button
            cmd_DeleteCancel.Text = "Cancel"
            cmd_DeleteCancel.Image = My.Resources.Resources.Cancel
            cmd_DeleteCancel.Enabled = True
            cmd_DeleteCancel.Enabled = True
            cmd_ExitSave.Text = "Save"
            cmd_ExitSave.Image = My.Resources.Resources.Save
            cmd_ExitSave.Enabled = False  'Hide exit/save button
        Else 'Restore
            cmd_NewRestore.Enabled = False  'Disable new/restore button
            Call DataFill() 'Replace original values from recordset
        End If
    End Sub
    Private Sub cmd_DeleteCancel_Click(sender As Object, e As EventArgs) Handles cmd_DeleteCancel.Click
        If cmd_DeleteCancel.Text = "Delete" Then

            'Test if any unfinished invoice data is related to customer being deleted
            strSQL = "SELECT Id FROM Invoice WHERE CustCode = " & lbl_CustCode.Text & " AND isNull(PaidDate);"
            dbDataSet_Misc.Clear()
            dbDataSet_Misc.Tables.Clear()
            gbl_DstConnect.Open()
            dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
            dbAdapter_Misc.Fill(dbDataSet_Misc, "Delete")
            gbl_DstConnect.Close()
            If dbDataSet_Misc.Tables("Delete").Rows.Count <> 0 Then 'Unfinished invoice data found 
                frm_Message.Text = "3:1:0:1:10:Deletion canceled. This customer has open unfinished invoice transactions in process"
                frm_Message.ShowDialog()
                Exit Sub
            End If

            'Confirm deletion before continuing
            frm_Message.Text = "3:3:0:1:11:Pressing Delete will remove the customer and all related invoiced data"
            frm_Message.ShowDialog()
            If MessageResult = True Then

                'Delete all invoices related to customer from Invoice table
                strSQL = "SELECT Id FROM Invoice WHERE CustCode = " & lbl_CustCode.Text & ";"
                dbDataSet_Misc.Clear()
                dbDataSet_Misc.Tables.Clear()
                gbl_DstConnect.Open()
                dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
                dbAdapter_Misc.Fill(dbDataSet_Misc, "Delete")
                gbl_DstConnect.Close()
                If dbDataSet_Misc.Tables("Delete").Rows.Count <> 0 Then 'Related invoice data found
                    Dim cb1 As New OleDb.OleDbCommandBuilder(dbAdapter_Misc)
                    For i = 0 To dbDataSet_Misc.Tables("Delete").Rows.Count - 1
                        dbDataSet_Misc.Tables("Delete").Rows(i).Delete()
                    Next
                    dbAdapter_Misc.Update(dbDataSet_Misc, "Delete")
                    cb1 = Nothing
                End If

                'Delete customer from customer table
                strSQL = "SELECT CustCode FROM Customers WHERE CustCode = " & lbl_CustCode.Text & ";"
                dbDataSet_Misc.Clear()
                dbDataSet_Misc.Tables.Clear()
                gbl_DstConnect.Open()
                dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
                dbAdapter_Misc.Fill(dbDataSet_Misc, "Delete")
                gbl_DstConnect.Close()

                Dim cb2 As New OleDb.OleDbCommandBuilder(dbAdapter_Misc)
                dbDataSet_Misc.Tables("Delete").Rows(0).Delete()
                dbAdapter_Misc.Update(dbDataSet_Misc, "Delete")
                cb2 = Nothing
                intTotalRecords = intTotalRecords - 1
                If intTotalRecords = 0 Then Call EnableMenus(1, False) 'Disable all customer related menus

                Call Actives() 'Test if last active customer deleted
                If opt_Active.Checked = True And booActives = True Then ListData(True) Else ListData(False)
            End If

        ElseIf cmd_DeleteCancel.Text = "Cancel" Then
            Call EnableEdits(False)
            Call ClearData() 'Clear all entries
            Call FileOperationReset()
            If intTotalRecords <> 0 Then 'Allow listbox operations only if records found
                ListBox1.Visible = True
                ListBox1.Enabled = True
                opt_Active.Enabled = True
                opt_NonActive.Enabled = True
                If EditNew = 2 Then
                    EditNew = 0
                    If opt_Active.Checked = True And booActives = True Then ListData(True) Else ListData(False)
                Else
                    EditNew = 0
                    Call ListBox1_Click()
                End If
            End If
            ListBox1.Focus()
        End If
    End Sub
    Private Sub cmd_ExitSave_Click(sender As Object, e As EventArgs) Handles cmd_ExitSave.Click
        If cmd_ExitSave.Text = "Exit" Then Me.Close() : Exit Sub

        On Error GoTo goActionErr

        'Validate entries
        If Trim(tbox_Company1.Text) = "" Then
            tbox_Company1.BackColor = Color.Aqua
            frm_Message.Text = "3:1:0:1:3:The company's Name must be Entered"
            frm_Message.ShowDialog()
            tbox_Company1.BackColor = Color.White
            tbox_Company1.Focus()
            Exit Sub
        End If

        If tbox_Phone1.Text <> "" Then
            If Len(tbox_Phone1.Text) <> 10 Then
                tbox_Phone1.BackColor = Color.Aqua
                frm_Message.Text = "3:1:0:1:3:The customer's phone number must be empty or complete to continue"
                frm_Message.ShowDialog()
                tbox_Phone1.BackColor = Color.White
                tbox_Phone1.Focus()
                Exit Sub
            End If
        End If

        If tbox_PhoneCell1.Text <> "" Then
            If Len(tbox_PhoneCell1.Text) <> 10 Then
                tbox_PhoneCell1.BackColor = Color.Aqua
                frm_Message.Text = "3:1:0:1:3:The customer's cell phone number must be empty or complete to continue"
                frm_Message.ShowDialog()
                tbox_PhoneCell1.BackColor = Color.White
                tbox_PhoneCell1.Focus()
                Exit Sub
            End If
        End If

        If tbox_Phone2.Text <> "" Then
            If Len(tbox_Phone2.Text) <> 10 Then
                tbox_Phone2.BackColor = Color.Aqua
                frm_Message.Text = "3:1:0:1:3:The customer's billing phone number must be empty or complete to continue"
                frm_Message.ShowDialog()
                tbox_Phone2.BackColor = Color.White
                tbox_Phone2.Focus()
                Exit Sub
            End If
        End If

        If tbox_PhoneCell2.Text <> "" Then
            If Len(tbox_PhoneCell2.Text) <> 10 Then
                tbox_PhoneCell2.BackColor = Color.Aqua
                frm_Message.Text = "3:1:0:1:3:The customer's billing cell phone number must be empty or complete to continue"
                frm_Message.ShowDialog()
                tbox_PhoneCell2.BackColor = Color.White
                tbox_PhoneCell2.Focus()
                Exit Sub
            End If
        End If
        'Make form checkbox and option buttons ready for save 
        Dim booActive, booCertification, booFreight As Boolean
        If cbx_Active.Checked = True Then booActive = True Else booActive = False
        If cbx_Certification.Checked = True Then booCertification = True Else booCertification = False
        If cbx_Freight.Checked = True Then booFreight = True Else booFreight = False

        'Save form to database
        Dim cb0 As New OleDb.OleDbCommandBuilder(dbAdapter)
        If EditNew = 1 Then 'Save on edits changes
            dbDataSet.Tables("Selected").Rows(0).Item(1) = booActive
            dbDataSet.Tables("Selected").Rows(0).Item(2) = Trim(tbox_Company1.Text)
            dbDataSet.Tables("Selected").Rows(0).Item(3) = Trim(tbox_Contact1.Text)
            dbDataSet.Tables("Selected").Rows(0).Item(4) = Trim(tbox_Address1.Text)
            dbDataSet.Tables("Selected").Rows(0).Item(5) = Trim(tbox_City1.Text)
            dbDataSet.Tables("Selected").Rows(0).Item(6) = Trim(tbox_State1.Text)
            dbDataSet.Tables("Selected").Rows(0).Item(7) = Trim(tbox_ZipCode1.Text)
            If Trim(tbox_Phone1.Text) <> "" Then dbDataSet.Tables("Selected").Rows(0).Item(8) = String.Format("{0:(###)###-####}", Long.Parse(Trim(tbox_Phone1.Text)))
            If Trim(tbox_PhoneCell1.Text) <> "" Then dbDataSet.Tables("Selected").Rows(0).Item(9) = String.Format("{0:(###)###-####}", Long.Parse(Trim(tbox_PhoneCell1.Text)))
            dbDataSet.Tables("Selected").Rows(0).Item(10) = Trim(tbox_Email1.Text)
            dbDataSet.Tables("Selected").Rows(0).Item(11) = Trim(tbox_Company2.Text)
            dbDataSet.Tables("Selected").Rows(0).Item(12) = Trim(tbox_Contact2.Text)
            dbDataSet.Tables("Selected").Rows(0).Item(13) = Trim(tbox_Address2.Text)
            dbDataSet.Tables("Selected").Rows(0).Item(14) = Trim(tbox_City2.Text)
            dbDataSet.Tables("Selected").Rows(0).Item(15) = Trim(tbox_State2.Text)
            dbDataSet.Tables("Selected").Rows(0).Item(16) = Trim(tbox_ZipCode2.Text)
            If Trim(tbox_Phone2.Text) <> "" Then dbDataSet.Tables("Selected").Rows(0).Item(17) = String.Format("{0:(###)###-####}", Long.Parse(Trim(tbox_Phone2.Text)))
            If Trim(tbox_PhoneCell2.Text) <> "" Then dbDataSet.Tables("Selected").Rows(0).Item(18) = String.Format("{0:(###)###-####}", Long.Parse(Trim(tbox_PhoneCell2.Text)))
            dbDataSet.Tables("Selected").Rows(0).Item(19) = Trim(tbox_Email2.Text)
            dbDataSet.Tables("Selected").Rows(0).Item(20) = booCertification
            dbDataSet.Tables("Selected").Rows(0).Item(21) = booFreight
            dbDataSet.Tables("Selected").Rows(0).Item(22) = Trim(tbox_FreightAccount.Text)
            dbDataSet.Tables("Selected").Rows(0).Item(23) = Trim(tbox_ShipVia.Text)
            dbDataSet.Tables("Selected").Rows(0).Item(24) = Trim(tbox_FreightWebSite.Text)
            If Trim(tbox_PreShip.Text) <> "" Then dbDataSet.Tables("Selected").Rows(0).Item(25) = Trim(tbox_PreShip.Text)
            dbDataSet.Tables("Selected").Rows(0).Item(26) = Trim(tbox_Notes.Text)
            dbAdapter.Update(dbDataSet, "Selected")
            intLookup = lbl_CustCode.Text

        ElseIf EditNew = 2 Then 'Save new additions to database table
            Dim dsNewRow As DataRow
            dsNewRow = dbDataSet.Tables("Selected").NewRow()
            dsNewRow.Item("Active") = booActive
            dsNewRow.Item("Company") = Trim(tbox_Company1.Text)
            dsNewRow.Item("Contact") = Trim(tbox_Contact1.Text)
            dsNewRow.Item("Address") = Trim(tbox_Address1.Text)
            dsNewRow.Item("City") = Trim(tbox_City1.Text)
            dsNewRow.Item("State") = Trim(tbox_State1.Text)
            dsNewRow.Item("ZipCode") = Trim(tbox_ZipCode1.Text)
            If Trim(tbox_Phone1.Text) <> "" Then dsNewRow.Item("Phone") = String.Format("{0:(###)###-####}", Long.Parse(Trim(tbox_Phone1.Text)))
            If Trim(tbox_PhoneCell1.Text) <> "" Then dsNewRow.Item("PhoneCell") = String.Format("{0:(###)###-####}", Long.Parse(Trim(tbox_PhoneCell1.Text)))
            dsNewRow.Item("Email") = Trim(tbox_Email1.Text)
            dsNewRow.Item("BCompany") = Trim(tbox_Company2.Text)
            dsNewRow.Item("BContact") = Trim(tbox_Contact2.Text)
            dsNewRow.Item("BAddress") = Trim(tbox_Address2.Text)
            dsNewRow.Item("BCity") = Trim(tbox_City2.Text)
            dsNewRow.Item("BState") = Trim(tbox_State2.Text)
            dsNewRow.Item("BZipCode") = Trim(tbox_ZipCode2.Text)
            If Trim(tbox_Phone2.Text) <> "" Then dsNewRow.Item("BPhone") = String.Format("{0:(###)###-####}", Long.Parse(Trim(tbox_Phone2.Text)))
            If Trim(tbox_PhoneCell2.Text) <> "" Then dsNewRow.Item("BPhoneCell") = String.Format("{0:(###)###-####}", Long.Parse(Trim(tbox_PhoneCell2.Text)))
            dsNewRow.Item("BEmail") = Trim(tbox_Email2.Text)
            dsNewRow.Item("Certification") = booCertification
            dsNewRow.Item("Freight") = booFreight
            dsNewRow.Item("FreightAccount") = Trim(tbox_FreightAccount.Text)
            dsNewRow.Item("ShipVia") = Trim(tbox_ShipVia.Text)
            dsNewRow.Item("FreightWebSite") = Trim(tbox_FreightWebSite.Text)
            If Trim(tbox_PreShip.Text) <> "" Then dsNewRow.Item("PreShipDays") = Trim(tbox_PreShip.Text)
            dsNewRow.Item("Notes") = Trim(tbox_Notes.Text)
            dbDataSet.Tables("Selected").Rows.Add(dsNewRow)
            dbAdapter.Update(dbDataSet, "Selected")
            intTotalRecords = intTotalRecords + 1
            If intTotalRecords = 1 Then Call EnableMenus(1, True) 'Enable all customer related menus

            'If first saved new record, update autonum with CustCode of saved record
            If AutoNum = 0 Then
                strSQL = "SELECT CustCode FROM Customers ORDER by CustCode DESC;"
                dbDataSet_Misc.Clear()
                dbDataSet_Misc.Tables.Clear()
                gbl_DstConnect.Open()
                dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
                dbAdapter_Misc.Fill(dbDataSet_Misc, "AutoNum")
                gbl_DstConnect.Close()
                AutoNum = dbDataSet_Misc.Tables("AutoNum").Rows(0).Item(0)
            Else
                AutoNum = AutoNum + 1
            End If
            intLookup = AutoNum
        End If
        cb0 = Nothing

        If booActive = True Then booActives = True : opt_Active.Enabled = True
        opt_NonActive.Enabled = True
        ListBox1.Visible = True

        'Fill listbox with entries pertaining to active/all selection
        If opt_Active.Checked = True Then ListData(True) Else ListData(False)
        EditNew = 0 'Edit/new record reset
        ListBox1.Visible = True
        ListBox1.Enabled = True
        ListBox1.Focus()
        Call EnableEdits(False)
        Call FileOperationReset()

        'Select saved customer if in selected active/all selection
        If opt_Active.Checked = True And booActive = False Then ListBox1.SelectedIndex = 0 : intLookup = ListArray(0, 1)
        Call DataFill()
        Exit Sub
goActionErr:
        MsgBox(Err.Description)
        Exit Sub
    End Sub
    Private Sub FileOperationReset()
        cmd_Edit.Enabled = True   'View Edit button
        cmd_NewRestore.Text = "New"
        cmd_NewRestore.Image = My.Resources.Resources._New
        cmd_NewRestore.Enabled = True   'View new button
        cmd_DeleteCancel.Text = "Delete"
        cmd_DeleteCancel.Image = My.Resources.Resources.Delete
        If intTotalRecords = 0 Then cmd_DeleteCancel.Enabled = False Else cmd_DeleteCancel.Enabled = True
        cmd_DeleteCancel.Enabled = True   'View delete button
        cmd_ExitSave.Text = "Exit"
        cmd_ExitSave.Image = My.Resources.Resources._Exit
        cmd_ExitSave.Enabled = True   'View exit button
    End Sub
    Private Sub cmd_Calculate_Click(sender As Object, e As EventArgs) Handles cmd_Calculate.Click
        Call CalculateHistory()
    End Sub

    'All texbox handlers
    Private Sub tbox_GotFocus(sender As Object, e As EventArgs) Handles tbox_Company1.GotFocus, tbox_Contact1.GotFocus, tbox_Phone1.GotFocus, tbox_PhoneCell1.GotFocus, tbox_Email1.GotFocus, tbox_Address1.GotFocus, tbox_City1.GotFocus, tbox_State1.GotFocus, tbox_ZipCode1.GotFocus, tbox_Company2.GotFocus, tbox_Contact2.GotFocus, tbox_Phone2.GotFocus, tbox_PhoneCell2.GotFocus, tbox_Email2.GotFocus, tbox_Address2.GotFocus, tbox_City2.GotFocus, tbox_State2.GotFocus, tbox_ZipCode2.GotFocus, tbox_FreightAccount.GotFocus, tbox_PreShip.GotFocus, tbox_ShipVia.GotFocus, tbox_FreightWebSite.GotFocus, tbox_Notes.GotFocus
        If sender.Name = "tbox_Notes" And Trim(sender.Text) <> "" Then
            strNotes = Trim(sender.Text)
            sender.SelectionStart = Len(Trim(sender.Text))
        End If
        strInitEntry = Trim(sender.Text)
        sender.BackColor = (Color.FromArgb(255, 255, 192))
    End Sub
    Private Sub tbox_LostFocus(sender As Object, e As EventArgs) Handles tbox_Company1.LostFocus, tbox_Contact1.LostFocus, tbox_Phone1.LostFocus, tbox_PhoneCell1.LostFocus, tbox_Email1.LostFocus, tbox_Address1.LostFocus, tbox_City1.LostFocus, tbox_State1.LostFocus, tbox_ZipCode1.LostFocus, tbox_Company2.LostFocus, tbox_Contact2.LostFocus, tbox_Phone2.LostFocus, tbox_PhoneCell2.LostFocus, tbox_Email2.LostFocus, tbox_Address2.LostFocus, tbox_City2.LostFocus, tbox_State2.LostFocus, tbox_ZipCode2.LostFocus, tbox_FreightAccount.LostFocus, tbox_PreShip.LostFocus, tbox_ShipVia.LostFocus, tbox_FreightWebSite.LostFocus, tbox_Notes.LostFocus
        If EditNew = 2 And booNameCheck = False And sender.Name = "tbox_Company1" Then Call NameCheck() 'Check for repeat of same name
        sender.BackColor = Color.White
        If booCorrection = True Then Exit Sub

        If sender.text <> "" Then
            Select Case sender.name
                Case "tbox_PreShip"
                    If Not IsNumeric(sender.Text) Then
                        booCorrection = True
                        frm_Message.Text = "3:1:0:1:3:Invalid Entry --- Numerical entries are only allowed"
                        frm_Message.ShowDialog()
                        sender.text = ""
                        sender.Focus()
                        booCorrection = False
                        Exit Sub
                    End If

                Case "tbox_State1", "tbox_State2"
                    If AlphaNumeric(sender.text) = False Then
                        booCorrection = True
                        frm_Message.Text = "3:1:0:1:3:Invalid Entry --- Only letters allow for state abbreviations"
                        frm_Message.ShowDialog()
                        sender.text = ""
                        sender.Focus()
                        booCorrection = False
                        Exit Sub
                    Else
                        If Trim(sender.Text) <> "" Then 'Capitalize first letter of entry
                            booCorrection = True
                            sender.Text = StrConv(sender.Text, VbStrConv.ProperCase)
                            booCorrection = False
                        End If
                    End If
            End Select
        End If

    End Sub
    Private Sub tbox_TextChanged(sender As Object, e As EventArgs) Handles tbox_Company1.TextChanged, tbox_Contact1.TextChanged, tbox_Phone1.TextChanged, tbox_PhoneCell1.TextChanged, tbox_Email1.TextChanged, tbox_Address1.TextChanged, tbox_City1.TextChanged, tbox_State1.TextChanged, tbox_ZipCode1.TextChanged, tbox_Company2.TextChanged, tbox_Contact2.TextChanged, tbox_Phone2.TextChanged, tbox_PhoneCell2.TextChanged, tbox_Email2.TextChanged, tbox_Address2.TextChanged, tbox_City2.TextChanged, tbox_State2.TextChanged, tbox_ZipCode2.TextChanged, tbox_FreightAccount.TextChanged, tbox_PreShip.TextChanged, tbox_ShipVia.TextChanged, tbox_FreightWebSite.TextChanged, tbox_Notes.TextChanged
        If booDataChecked = True Or EditNew = 0 Then Exit Sub 'Skip if pre_processed data
        Select Case sender.Name
            Case "tbox_Company1", "tbox_Company2", "tbox_Contact1", "tbox_Contact1", "tbox_City1", "tbox_City2", "tbox_State1", "tbox_State2"
                If Trim(sender.Text) <> "" Then 'Capitalize first letter of entry
                    If Len(Trim(sender.Text)) = 1 Then
                        sender.Text = StrConv(Trim(sender.Text), vbUpperCase)
                        sender.SelectionStart = 2
                    End If
                End If
            Case "tbox_Notes"
                If Len(sender.text) = Len(strNotes) + 2 Then Exit Sub
        End Select
        Call EditSave()
    End Sub
    Private Sub tbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbox_Company1.KeyPress, tbox_Contact1.KeyPress, tbox_Phone1.KeyPress, tbox_PhoneCell1.KeyPress, tbox_Email1.KeyPress, tbox_Address1.KeyPress, tbox_City1.KeyPress, tbox_State1.KeyPress, tbox_ZipCode1.KeyPress, tbox_Company2.KeyPress, tbox_Contact2.KeyPress, tbox_Phone2.KeyPress, tbox_PhoneCell2.KeyPress, tbox_Email2.KeyPress, tbox_Address2.KeyPress, tbox_City2.KeyPress, tbox_State2.KeyPress, tbox_ZipCode2.KeyPress, tbox_FreightAccount.KeyPress, tbox_PreShip.KeyPress, tbox_ShipVia.KeyPress, tbox_FreightWebSite.KeyPress, tbox_Notes.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            Select Case sender.Name
                Case "tbox_Company1" : tbox_Contact1.Focus()
                Case "tbox_Contact1" : tbox_Phone1.Focus()
                Case "tbox_Phone1" : tbox_PhoneCell1.Focus()
                Case "tbox_PhoneCell1" : tbox_Email1.Focus()
                Case "tbox_Email1" : tbox_Address1.Focus()
                Case "tbox_Address1" : tbox_City1.Focus()
                Case "tbox_City1" : tbox_State1.Focus()
                Case "tbox_State1" : tbox_ZipCode1.Focus()
                Case "tbox_ZipCode1" : tbox_Company2.Focus()
                Case "tbox_Company2" : tbox_Contact2.Focus()
                Case "tbox_Contact2" : tbox_Phone2.Focus()
                Case "tbox_Phone2" : tbox_PhoneCell2.Focus()
                Case "tbox_PhoneCell2" : tbox_Email2.Focus()
                Case "tbox_Email2" : tbox_Address2.Focus()
                Case "tbox_Address2" : tbox_City2.Focus()
                Case "tbox_City2" : tbox_State2.Focus()
                Case "tbox_State2" : tbox_ZipCode2.Focus()
                Case "tbox_ZipCode2" : tbox_PreShip.Focus()
                Case "tbox_PreShip" : If cbx_Freight.Checked = True Then tbox_FreightAccount.Focus() Else tbox_FreightWebSite.Focus()
                Case "tbox_FreightAccount" : tbox_ShipVia.Focus()
                Case "tbox_ShipVia" : tbox_FreightWebSite.Focus()
                Case "tbox_FreightWebSite" : tbox_Notes.Focus()
                Case "tbox_Notes" : tbox_Company1.Focus()
            End Select
        End If
    End Sub
    Private Sub cbx_CheckedChanged(sender As Object, e As EventArgs) Handles cbx_Active.CheckedChanged, cbx_Freight.CheckedChanged, cbx_Certification.CheckedChanged
        If EditNew = 0 Then Exit Sub
        If cbx_Freight.Checked = True Then
            tbox_ShipVia.Enabled = True
            tbox_FreightAccount.Enabled = True
            tbox_FreightAccount.Focus()
        Else
            tbox_ShipVia.Enabled = False
            tbox_FreightAccount.Enabled = False
        End If
        Call EditSave()
    End Sub
    Private Sub tbox_Date_MouseClick(sender As Object, e As MouseEventArgs) Handles tbox_Phone1.MouseClick, tbox_PhoneCell1.MouseClick, tbox_Phone2.MouseClick, tbox_PhoneCell2.MouseClick, tbox_ZipCode1.MouseClick, tbox_ZipCode2.MouseClick
        If sender.text = "" Then sender.SelectionStart = 0
    End Sub
    Private Sub btn_BillingCopy_CheckedChanged(sender As Object, e As EventArgs) Handles btn_BillingCopy.CheckedChanged
        If sender.checked = True Then
            tbox_Company2.Text = tbox_Company1.Text
            tbox_Contact2.Text = tbox_Contact1.Text
            tbox_Address2.Text = tbox_Address1.Text
            tbox_City2.Text = tbox_City1.Text
            tbox_State2.Text = tbox_State1.Text
            tbox_ZipCode2.Text = tbox_ZipCode1.Text
            tbox_Phone2.Text = tbox_Phone1.Text
            tbox_PhoneCell2.Text = tbox_PhoneCell1.Text
            tbox_Email2.Text = tbox_Email1.Text
            sender.checked = False
        End If
    End Sub

    'Handler sub routines
    Private Sub NameCheck()

        'Create string with and without a period at the end of the company name for company name lookup
        Dim str1, str2 As String
        str1 = UCase(Trim(tbox_Company1.Text))
        If Microsoft.VisualBasic.Right(str1, 1) <> "." Then
            str2 = str1 & "."
        Else
            str2 = str1
            str1 = str1.Substring(0, str1.Length - 1)
        End If

        Dim booRepeat As Boolean = False
        For i = 1 To 2
            Select Case i
                Case Is = 1 : strSQL = "SELECT Company FROM Customers WHERE Ucase(Company) = '" & str1 & "';"
                Case Is = 2 : strSQL = "SELECT Company FROM Customers WHERE Ucase(Company) = '" & str2 & "';"
            End Select
            dbDataSet_Misc.Clear()
            dbDataSet_Misc.Tables.Clear()
            gbl_DstConnect.Open()
            dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
            dbAdapter_Misc.Fill(dbDataSet_Misc, "NameCheck")
            gbl_DstConnect.Close()
            If dbDataSet_Misc.Tables("NameCheck").Rows.Count > 0 Then booRepeat = True : Exit For
        Next

        If booRepeat = True Then
            If dbDataSet_Misc.Tables("NameCheck").Rows.Count = 1 Then
                frm_Message.Text = "3:1:0:1:12:There is 1 other company on file with the same name"
            Else
                frm_Message.Text = "3:1:0:1:12:There are " & dbDataSet_Misc.Tables("NameCheck").Rows.Count & " other companies on file with the same name"
            End If
            booNameCheck = True
            frm_Message.ShowDialog()
        End If
    End Sub
    Private Sub EditSave()
        If booDataChecked = True Then Exit Sub
        If EditNew = 1 Then cmd_NewRestore.Enabled = True
        cmd_ExitSave.Text = "Save"
        cmd_ExitSave.Image = My.Resources.Resources.Save
        cmd_ExitSave.Enabled = True
    End Sub

    'All mouse movement and mouse over messages
    Private Sub ListBox1_MouseEnter(sender As Object, e As EventArgs) Handles ListBox1.MouseEnter
        ListBox1.Focus()
    End Sub
    Private Sub fra_MouseMove() Handles fra_List.MouseMove, fra_Company.MouseMove, fra_BillingAddress.MouseMove, fra_OrderHistory.MouseMove, fra_Options.MouseMove 'Clear message
        intMessage = 0
        Call MouseMessages()
    End Sub
    Private Sub tbox_MouseHover(sender As Object, e As EventArgs) Handles ListBox1.MouseHover, cbx_Active.MouseHover, btn_BillingCopy.MouseHover, tbox_FreightAccount.MouseHover, tbox_PreShip.MouseHover, tbox_ShipVia.MouseHover, tbox_FreightWebSite.MouseHover, cmd_Calculate.MouseHover, cbx_Freight.MouseHover, cbx_Certification.MouseHover
        Select Case sender.name
            Case "ListBox1" : intMessage = 1
            Case "cbx_Active" : intMessage = 2
            Case "btn_BillingCopy" : intMessage = 3
            Case "cbx_Freight" : intMessage = 4
            Case "tbox_PreShip" : intMessage = 5
            Case "tbox_FreightAccount" : intMessage = 6
            Case "tbox_ShipVia" : intMessage = 7
            Case "tbox_FreightWebSite" : intMessage = 8
            Case "cbx_Certification" : intMessage = 9
            Case "cmd_Calculate" : intMessage = 10
        End Select
        Call MouseMessages()
    End Sub
    Private Sub lbl_History_MouseHover(sender As Object, e As EventArgs) 'Show message for labels years
        Select Case sender.name
            Case "lbl_OrderYear" : intMessage = 11
            Case "lbl_OrdersReceived" : intMessage = 12
            Case "lbl_ValueReceived" : intMessage = 13
            Case "lbl_OrdersShip" : intMessage = 14
            Case "lbl_ValueShip" : intMessage = 15
            Case "lbl_IncomePercent" : intMessage = 16
        End Select
        Call MouseMessages()
    End Sub
    Private Sub MouseMessages()
        Select Case intMessage
            Case 0 : lbl_Message.Text = "" 'Clear message from screen
            Case 1 : lbl_Message.Text = "Select customer name from list to view and edit all customers information"
            Case 2 : lbl_Message.Text = "Removing the check from this box will elimate the customer from the active list"
            Case 3 : lbl_Message.Text = "Press this button to copy the company information into the billing information"
            Case 4 : lbl_Message.Text = "Check this box if customer pays for freight"
            Case 5 : lbl_Message.Text = "Enter the number of days before the due date an item can be shipped"
            Case 6 : lbl_Message.Text = "Enter Customers shipping account number if used with shipping"
            Case 7 : lbl_Message.Text = "Enter shipping company if different from default method"
            Case 8 : lbl_Message.Text = "Enter Website address associated with customers shipping"
            Case 9 : lbl_Message.Text = "Checking this box, will enforces all invoices to have material certification"
            Case 10 : lbl_Message.Text = "Press this button to calculate customers order history"
            Case 11 : lbl_Message.Text = "Year that customer placed orders"
            Case 12 : lbl_Message.Text = "Number of orders received in the year of this line"
            Case 13 : lbl_Message.Text = "Value of all orders received in the year of this line"
            Case 14 : lbl_Message.Text = "Number of orders shipped in the year of this line"
            Case 15 : lbl_Message.Text = "Value of all orders shipped in the year of this line"
            Case 16 : lbl_Message.Text = "Percentage this company contributed to the total income shipped for all companies this year"
        End Select
    End Sub

End Class