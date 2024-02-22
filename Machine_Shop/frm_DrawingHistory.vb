Imports System.Drawing.Printing
Public Class frm_DrawingHistory
    Dim dbAdapter, dbAdapter_SystemData, dbAdapter_Misc As OleDb.OleDbDataAdapter
    Dim dbDataSet, dbDataSet_SystemData, dbDataSet_Misc As New DataSet
    Dim strSQL As String

    'Form controls related
    Dim lbl_InvoiceNumber(40) As Label
    Dim lbl_InvoiceDate(40) As Label
    Dim lbl_PurchaseOrder(40) As Label
    Dim lbl_POItem(40) As Label
    Dim lbl_DrawNumber(40) As Label
    Dim lbl_DrawRevision(40) As Label
    Dim lbl_Quantitys(40) As Label
    Dim lbl_Price(40) As Label
    Dim lbl_TotalPrice(40) As Label
    Dim lbl_MaterialHeat(40) As Label
    Dim lbl_ID(40) As Label

    'Data related
    Dim ListArray(1, 1) As Integer 'Used to link dataset to listbox selection
    Dim DataArray(1, 10) As Object 'Array to hold all data
    Dim LastSelect(4), LastSearch As String 'Used to record last listbox selection on all four listboxes
    Dim RecordCount, intMessage, D_Page As Integer 'Variable used in the mouse over event to show different messages

    'Print Related
    Private WithEvents PrintForms As PrintDocument
    Declare Function GetDeviceCaps% Lib "GDI32" (ByVal hDC%, ByVal nIndex%)
    Private Buffer, Pages, P_Page, P_Line As Integer 'Pages = total pages needed to print report, P_Page = print page number, P_Line is print item row number
    Private SystemPrinter As String
    Private brush As Brush
    Private BlackBrush As New SolidBrush(Color.Black)
    Private FlagBrush As New SolidBrush(Color.Maroon)

    'All form related events
    Private Sub frm_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated
        Call AddControls()
    End Sub
    Private Sub frm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.Location = New Point((Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2, frm_Main.Top + 65)
        Me.Text = "Drawing History Report    "

        'Retrieve system variables
        strSQL = "SELECT CompanyName,SystemPrinter,Buffer FROM System;"
        dbDataSet_SystemData.Clear()
        dbDataSet_SystemData.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter_SystemData = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter_SystemData.Fill(dbDataSet_SystemData, "SystemData")
        gbl_DstConnect.Close()
        If dbDataSet_SystemData.Tables("SystemData").Rows.Count = 1 Then
            Label_Company.Text = Replace(dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(0), "&&", "&") 'Company Name 
            SystemPrinter = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(1) 'System printer name
            Buffer = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(2) 'Printer buffer
        End If
        opt_Active.Checked = True
    End Sub
    Private Sub Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        For i = 1 To 4
            LastSelect(i) = ""
        Next
        dbDataSet.Clear()
        dbDataSet.Tables.Clear()
        dbDataSet_SystemData.Clear()
        dbDataSet_SystemData.Tables.Clear()
        dbDataSet_Misc.Clear()
        dbDataSet_Misc.Tables.Clear()
        Me.Dispose()
    End Sub
    Private Sub AddControls() 'Create array of controls in frame drawing history

        Dim int_Top, i As Integer
        int_Top = 188

        For i = 0 To 39
            int_Top = int_Top + 16
            lbl_InvoiceNumber(i) = New Label
            lbl_InvoiceDate(i) = New Label
            lbl_PurchaseOrder(i) = New Label
            lbl_POItem(i) = New Label
            lbl_DrawNumber(i) = New Label
            lbl_DrawRevision(i) = New Label
            lbl_Quantitys(i) = New Label
            lbl_Price(i) = New Label
            lbl_TotalPrice(i) = New Label
            lbl_MaterialHeat(i) = New Label
            lbl_ID(i) = New Label

            With lbl_InvoiceNumber(i)
                .Name = "lbl_InvoiceNumber"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(16, int_Top, 56, 15)
                fra_DrawingHistory.Controls.Add(lbl_InvoiceNumber(i))
            End With

            With lbl_InvoiceDate(i)
                .Name = "lbl_InvoiceDate"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(73, int_Top, 69, 15)
                fra_DrawingHistory.Controls.Add(lbl_InvoiceDate(i))
            End With

            With lbl_PurchaseOrder(i)
                .Name = "lbl_PurchaseOrder"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(143, int_Top, 130, 15)
                fra_DrawingHistory.Controls.Add(lbl_PurchaseOrder(i))
            End With

            With lbl_POItem(i)
                .Name = "lbl_POItem"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(274, int_Top, 24, 15)
                fra_DrawingHistory.Controls.Add(lbl_POItem(i))
            End With

            With lbl_DrawNumber(i)
                .Name = "lbl_DrawNumber"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(299, int_Top, 103, 15)
                fra_DrawingHistory.Controls.Add(lbl_DrawNumber(i))
            End With

            With lbl_DrawRevision(i)
                .Name = "lbl_DrawRevision"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(403, int_Top, 31, 15)
                fra_DrawingHistory.Controls.Add(lbl_DrawRevision(i))
            End With

            With lbl_Quantitys(i)
                .Name = "lbl_Quantitys"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(435, int_Top, 42, 15)
                fra_DrawingHistory.Controls.Add(lbl_Quantitys(i))
            End With

            With lbl_Price(i)
                .Name = "lbl_Price"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(478, int_Top, 69, 15)
                fra_DrawingHistory.Controls.Add(lbl_Price(i))
            End With

            With lbl_TotalPrice(i)
                .Name = "lbl_TotalPrice"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(548, int_Top, 69, 15)
                fra_DrawingHistory.Controls.Add(lbl_TotalPrice(i))
            End With

            With lbl_MaterialHeat(i)
                .Name = "lbl_MaterialHeat"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(618, int_Top, 102, 15)
                fra_DrawingHistory.Controls.Add(lbl_MaterialHeat(i))
            End With

            With lbl_ID(i)
                .Name = "lbl_ID"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(722, int_Top, 46, 15)
                fra_DrawingHistory.Controls.Add(lbl_ID(i))
            End With

        Next
    End Sub
    Private Sub Opt_Active_CheckedChanged() Handles opt_Active.CheckedChanged, opt_NonActive.CheckedChanged 'Index recordset based on selected option button
        If opt_Active.Checked = True Then CustomerListFill(0) Else CustomerListFill(1)
    End Sub
    Private Sub ClearScreen()
        Listbox_Customers.Items.Clear()
        ListBox_DrawNum.Items.Clear()
        ListBox_DrawRev.Items.Clear()
        ListBox_Quantity.Items.Clear()
        tbox_Search.Text = ""

        For intStep = 0 To 39
            lbl_InvoiceNumber(intStep).Text = ""
            lbl_InvoiceDate(intStep).Text = ""
            lbl_PurchaseOrder(intStep).Text = ""
            lbl_POItem(intStep).Text = ""
            lbl_DrawNumber(intStep).Text = ""
            lbl_DrawRevision(intStep).Text = ""
            lbl_Quantitys(intStep).Text = ""
            lbl_Price(intStep).Text = ""
            lbl_TotalPrice(intStep).Text = ""
            lbl_MaterialHeat(intStep).Text = ""
            lbl_ID(intStep).Text = ""
        Next
    End Sub
    Private Sub CustomerListFill(intSelect As Integer) 'Fill listbox customer with company name relavent to selected task

        Call ClearScreen()
        Select Case intSelect
            Case 0
                strSQL = "SELECT Company,CustCode FROM Customers Where Active = True ORDER BY Company;"
                opt_Active.Enabled = True : opt_NonActive.Enabled = True
                ListboxEnable(True, False)
            Case 1
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
                Case 0 : frm_Message.Text = "12:1:0:1:3:There are no active customers on record to show"
                Case 1 : frm_Message.Text = "12:1:0:1:3:There are no customers on record to show"
            End Select
            frm_Message.ShowDialog()
        End If

    End Sub
    Private Sub ArrayFill() 'Fill Array with data   

        strSQL = "SELECT InvoiceNumber,InvoiceDate,PurchaseOrder,POItem,DrawingNumber,DrawingRevision,QtyOrdered,Price,MaterialHeat,ID,DueDate " _
             & "FROM Invoice Where CustCode = " & ListArray(Listbox_Customers.SelectedIndex, 1) & " AND " _
             & "DrawingNumber = '" & ListBox_DrawNum.SelectedItem & "' "
        If ListBox_DrawRev.SelectedItem <> "ALL" Then strSQL = strSQL & "AND DrawingRevision = '" & ListBox_DrawRev.SelectedItem & "' "
        If ListBox_Quantity.SelectedItem <> "ALL" Then strSQL = strSQL & "AND QtyOrdered = " & ListBox_Quantity.SelectedItem & " "
        strSQL = strSQL & "ORDER BY DrawingRevision,QtyOrdered;"

        dbDataSet.Clear()
        dbDataSet.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter.Fill(dbDataSet, "View")
        gbl_DstConnect.Close()
        RecordCount = dbDataSet.Tables("View").Rows.Count
        ReDim DataArray(RecordCount, 11)

        If RecordCount <= 40 Then
            cmd_PrintAll.Enabled = False
            fra_Pages.Enabled = False
            lbl_Page.Visible = False
        Else
            cmd_PrintAll.Enabled = True
            cmd_Previous.Enabled = False
            cmd_Next.Enabled = True
            D_Page = 1
            fra_Pages.Enabled = True
            lbl_Page.Visible = True
        End If

        For intStep = 0 To RecordCount - 1
            If Not IsDBNull(dbDataSet.Tables("View").Rows(intStep).Item(0)) Then 'Invoice Number
                DataArray(intStep, 0) = Trim(dbDataSet.Tables("View").Rows(intStep).Item(0))
            Else : DataArray(intStep, 0) = "" : End If

            If Not IsDBNull(dbDataSet.Tables("View").Rows(intStep).Item(1)) And dbDataSet.Tables("View").Rows(intStep).Item(1).ToString <> "#12/12/1212#" Then 'Invoice Date
                DataArray(intStep, 1) = FormatDateTime(dbDataSet.Tables("View").Rows(intStep).Item(1), DateFormat.ShortDate)
            Else : DataArray(intStep, 1) = "" : End If

            If Not IsDBNull(dbDataSet.Tables("View").Rows(intStep).Item(2)) Then 'Purchase Order
                DataArray(intStep, 2) = Trim(dbDataSet.Tables("View").Rows(intStep).Item(2))
            Else : DataArray(intStep, 2) = "" : End If

            If Not IsDBNull(dbDataSet.Tables("View").Rows(intStep).Item(3)) Then 'Purchase Order line item number
                DataArray(intStep, 3) = Trim(dbDataSet.Tables("View").Rows(intStep).Item(3))
            Else : DataArray(intStep, 3) = "" : End If

            If Not IsDBNull(dbDataSet.Tables("View").Rows(intStep).Item(4)) Then 'Drawing Number
                DataArray(intStep, 4) = Trim(dbDataSet.Tables("View").Rows(intStep).Item(4))
            Else : DataArray(intStep, 4) = "" : End If

            If Not IsDBNull(dbDataSet.Tables("View").Rows(intStep).Item(5)) Then 'Drawing Revision
                DataArray(intStep, 5) = Trim(dbDataSet.Tables("View").Rows(intStep).Item(5))
            Else : DataArray(intStep, 5) = "" : End If

            If Not IsDBNull(dbDataSet.Tables("View").Rows(intStep).Item(6)) Then 'Quantity Ordered
                DataArray(intStep, 6) = Trim(dbDataSet.Tables("View").Rows(intStep).Item(6))
            Else : DataArray(intStep, 6) = 0 : End If

            If Not IsDBNull(dbDataSet.Tables("View").Rows(intStep).Item(7)) Then 'Price
                DataArray(intStep, 7) = Trim(dbDataSet.Tables("View").Rows(intStep).Item(7))
            Else : DataArray(intStep, 7) = 0 : End If

            If Not IsDBNull(dbDataSet.Tables("View").Rows(intStep).Item(8)) Then 'Material Heat
                DataArray(intStep, 8) = Trim(dbDataSet.Tables("View").Rows(intStep).Item(8))
            Else : DataArray(intStep, 8) = "" : End If

            If Not IsDBNull(dbDataSet.Tables("View").Rows(intStep).Item(9)) Then 'Lot Id
                DataArray(intStep, 9) = Trim(dbDataSet.Tables("View").Rows(intStep).Item(9))
            Else : DataArray(intStep, 9) = "" : End If

            If Not IsDBNull(dbDataSet.Tables("View").Rows(intStep).Item(10)) And dbDataSet.Tables("View").Rows(intStep).Item(10).ToString <> "#12/12/1212#" Then 'Due Date
                DataArray(intStep, 10) = FormatDateTime(dbDataSet.Tables("View").Rows(intStep).Item(10), DateFormat.ShortDate)
            Else : DataArray(intStep, 10) = "" : End If

            DataArray(intStep, 11) = DataArray(intStep, 6) * DataArray(intStep, 7)
        Next
    End Sub
    Private Sub FormFill() 'Fill form with data pertaining to listbox selection

        Dim FirstDate, LastDate As Date
        If ListBox_DrawRev.SelectedItem <> "ALL" Then
            tbox_Search.Text = DataArray(0, 4) & " " & DataArray(0, 5)
        Else : tbox_Search.Text = DataArray(0, 4) : End If

        If DataArray(0, 1) <> "" Then FirstDate = DataArray(0, 1) Else FirstDate = DataArray(0, 10)
        If DataArray(RecordCount - 1, 1) <> "" Then LastDate = DataArray(RecordCount - 1, 1) Else LastDate = DataArray(RecordCount - 1, 10)
        Label_HeaderDates.Text = FirstDate & " ---------------- " & LastDate 'Header dates
        fra_Print.Enabled = True

        Dim Row As Integer = (D_Page - 1) * 40
        Dim intStep As Integer

        'Form fill data
        lbl_Page.Text = "Page " & D_Page
        For intStep = 0 To 39
            If DataArray(Row, 0) <> "" Then
                lbl_InvoiceNumber(intStep).Text = DataArray(Row, 0)
                lbl_InvoiceDate(intStep).Text = DataArray(Row, 1)
                lbl_InvoiceNumber(intStep).ForeColor = System.Drawing.SystemColors.ControlText
                lbl_InvoiceDate(intStep).ForeColor = System.Drawing.SystemColors.ControlText
            Else
                lbl_InvoiceNumber(intStep).Text = "P.O."
                lbl_InvoiceDate(intStep).Text = DataArray(Row, 10)
                lbl_InvoiceNumber(intStep).ForeColor = Color.Maroon
                lbl_InvoiceDate(intStep).ForeColor = Color.Maroon
            End If
            lbl_PurchaseOrder(intStep).Text = DataArray(Row, 2)
            lbl_POItem(intStep).Text = DataArray(Row, 3)
            lbl_DrawNumber(intStep).Text = DataArray(Row, 4)
            lbl_DrawRevision(intStep).Text = DataArray(Row, 5)
            lbl_Quantitys(intStep).Text = DataArray(Row, 6)
            lbl_Price(intStep).Text = FormatCurrency(DataArray(Row, 7))
            lbl_TotalPrice(intStep).Text = FormatCurrency(DataArray(Row, 11))
            lbl_MaterialHeat(intStep).Text = DataArray(Row, 8)
            lbl_ID(intStep).Text = DataArray(Row, 9)
            If Row = RecordCount - 1 Then Exit For
            Row = Row + 1
        Next

        'Clear remaining rows on not full page
        If intStep < 39 Then
            Dim intStep1 As Integer = intStep + 1
            For intStep = intStep1 To 39
                lbl_InvoiceNumber(intStep).Text = ""
                lbl_InvoiceDate(intStep).Text = ""
                lbl_PurchaseOrder(intStep).Text = ""
                lbl_POItem(intStep).Text = ""
                lbl_DrawNumber(intStep).Text = ""
                lbl_DrawRevision(intStep).Text = ""
                lbl_Quantitys(intStep).Text = ""
                lbl_Price(intStep).Text = ""
                lbl_TotalPrice(intStep).Text = ""
                lbl_MaterialHeat(intStep).Text = ""
                lbl_ID(intStep).Text = ""
            Next
        End If

    End Sub
    Private Sub ListBox_Click(sender As Object, e As EventArgs) Handles Listbox_Customers.Click, ListBox_DrawNum.Click, ListBox_DrawRev.Click, ListBox_Quantity.Click
        If sender.SelectedItem = Nothing Then Exit Sub
        Select Case sender.name
            Case "Listbox_Customers" : If sender.SelectedItem = LastSelect(1) Then Exit Sub Else LastSelect(1) = sender.SelectedItem : tbox_Search.Text = "" : Call Search(1)
            Case "ListBox_DrawNum" : If sender.SelectedItem = LastSelect(2) Then Exit Sub Else LastSelect(2) = sender.SelectedItem : tbox_Search.Text = "" : Call Search(2)
            Case "ListBox_DrawRev" : If sender.SelectedItem = LastSelect(3) Then Exit Sub Else LastSelect(3) = sender.SelectedItem : tbox_Search.Text = "" : Call Search(3)
            Case "ListBox_Quantity" : If sender.SelectedItem = LastSelect(4) Then Exit Sub Else LastSelect(4) = sender.SelectedItem : Call Search(4)
        End Select
    End Sub
    Private Sub ListboxEnable(blnStatus As Boolean, blnStatus1 As Boolean)
        Listbox_Customers.Enabled = blnStatus
        ListBox_DrawNum.Enabled = blnStatus1
        ListBox_DrawRev.Enabled = blnStatus1
        ListBox_Quantity.Enabled = blnStatus1
    End Sub
    Private Sub Search(List As Integer)
        On Error GoTo goActionErr
        Dim inc As Integer
        If List = 1 Then 'Fill Drawing listbox with all distinct drawing number related to selected customer
            ListBox_DrawNum.Items.Clear() 'Clear purchase order listbox
            strSQL = "SELECT DISTINCT DrawingNumber FROM Invoice Where CustCode = " & ListArray(Listbox_Customers.SelectedIndex, 1) & " ORDER BY DrawingNumber;"
            dbDataSet.Clear()
            dbDataSet.Tables.Clear()
            gbl_DstConnect.Open()
            dbAdapter = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
            dbAdapter.Fill(dbDataSet, "Search")
            gbl_DstConnect.Close()
            If dbDataSet.Tables("Search").Rows.Count <> 0 Then
                For inc = 0 To dbDataSet.Tables("Search").Rows.Count - 1
                    If Not IsDBNull(dbDataSet.Tables("Search").Rows(inc).Item(0)) Then 'Drawing number
                        ListBox_DrawNum.Items.Add(Trim(dbDataSet.Tables("Search").Rows(inc).Item(0)))
                    End If
                Next
                ListBox_DrawNum.SelectedIndex = 0 'PreSelect first item in drawing number listbox 
            End If
        End If

        If List = 1 Or List = 2 Then 'Fill Drawingrevision listbox with all distinct drawing revision related to selected drawing number
            ListBox_DrawRev.Items.Clear() 'Clear draw revision listbox
            strSQL = "SELECT DISTINCT DrawingRevision FROM Invoice " _
                   & "Where CustCode = " & ListArray(Listbox_Customers.SelectedIndex, 1) & " AND " _
                   & "DrawingNumber = '" & ListBox_DrawNum.SelectedItem & "' ORDER BY DrawingRevision;"
            dbDataSet.Clear()
            dbDataSet.Tables.Clear()
            gbl_DstConnect.Open()
            dbAdapter = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
            dbAdapter.Fill(dbDataSet, "Search")
            gbl_DstConnect.Close()
            ListBox_DrawRev.Items.Add("ALL")
            If dbDataSet.Tables("Search").Rows.Count <> 0 Then
                For inc = 0 To dbDataSet.Tables("Search").Rows.Count - 1
                    If Not IsDBNull(dbDataSet.Tables("Search").Rows(inc).Item(0)) Then 'Drawing revision
                        ListBox_DrawRev.Items.Add(Trim(dbDataSet.Tables("Search").Rows(inc).Item(0)))
                    End If
                Next
                ListBox_DrawRev.SelectedIndex = 0 'PreSelect first item in drawing revision listbox
            End If
        End If

        If List >= 1 And List <= 3 Then 'Fill quantity listbox with all distinct quantity's related to selected customer, drawing number, revision
            ListBox_Quantity.Items.Clear() 'Clear quantity listbox
            strSQL = "SELECT DISTINCT QtyOrdered FROM Invoice " _
                   & "Where CustCode = " & ListArray(Listbox_Customers.SelectedIndex, 1) & " AND " _
                   & "DrawingNumber = '" & ListBox_DrawNum.SelectedItem & "' "
            If ListBox_DrawRev.SelectedItem <> "ALL" Then 'Drawing rev associated with drawing
                strSQL = strSQL & "AND DrawingRevision = '" & ListBox_DrawRev.SelectedItem & "' ORDER BY QtyOrdered;"
            Else 'No drawing revisions found for selected drawing
                strSQL = strSQL & "ORDER BY QtyOrdered;"
            End If
            dbDataSet.Clear()
            dbDataSet.Tables.Clear()
            gbl_DstConnect.Open()
            dbAdapter = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
            dbAdapter.Fill(dbDataSet, "Search")
            gbl_DstConnect.Close()
            ListBox_Quantity.Items.Add("ALL")
            If dbDataSet.Tables("Search").Rows.Count <> 0 Then
                For inc = 0 To dbDataSet.Tables("Search").Rows.Count - 1
                    If Not IsDBNull(dbDataSet.Tables("Search").Rows(inc).Item(0)) Then 'Quantity's
                        ListBox_Quantity.Items.Add(Trim(dbDataSet.Tables("Search").Rows(inc).Item(0)))
                    End If
                Next
                ListBox_Quantity.SelectedIndex = 0 'PreSelect first item in quantity listbox 
            End If
        End If

        'Fill screen wit data, Enable DrawNumber,DrawingRevision,Quantity listboxes
        Call ArrayFill()
        D_Page = 1
        Call FormFill()
        Call ListboxEnable(True, True)
        Exit Sub
goActionErr:
        MsgBox(Err.Description)
        Exit Sub

    End Sub
    Private Sub cmd_Search_Click(sender As Object, e As EventArgs) Handles cmd_Search.Click
        On Error GoTo goActionErr
        Dim strSearch, strHold As String
        Dim intSpace As Integer = 0

        ' Listbox_Search.Items.Clear() 'Clear listbox of all items
        strSQL = "SELECT DISTINCT Custcode FROM Invoice "

        strSearch = Trim(tbox_Search.Text)
        strHold = Nothing
        intSpace = InStr(strSearch, " ")
        If intSpace > 0 Then
            strHold = Mid(strSearch, intSpace + 1, Len(strSearch) - intSpace)
            strSearch = Microsoft.VisualBasic.Left(strSearch, intSpace - 1)
            strSQL = strSQL & "WHERE DrawingNumber = '" & strSearch & "' AND DrawingRevision = '" & strHold & "' ORDER BY CustCode;"
        Else
            strSQL = strSQL & "WHERE DrawingNumber = '" & strSearch & "' ORDER BY CustCode;"
        End If

        dbDataSet_Misc.Clear()
        dbDataSet_Misc.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter_Misc.Fill(dbDataSet_Misc, "Search")
        gbl_DstConnect.Close()

        If dbDataSet_Misc.Tables("Search").Rows.Count() > 0 Then
            Dim intLocate As Integer = dbDataSet_Misc.Tables("Search").Rows(0).Item(0)

            If dbDataSet_Misc.Tables("Search").Rows.Count() > 1 Then 'Multiple customers with same drawing number
                If intSpace = 0 Then
                    frm_Message.Text = "12:1:0:11:5:Try adding drawing rev after the drawing number to help defferentiate between them"
                    frm_Message.ShowDialog()
                    tbox_Search.Focus()
                Else
                    frm_Message.Text = "12:1:0:1:3:Multiple customers share the same drawing number, Text search cannot be used"
                    frm_Message.ShowDialog()
                    tbox_Search.Text = ""
                End If
                Exit Sub
            End If

            Dim inc As Integer
            Dim booFound As Boolean = False
            For inc = 0 To UBound(ListArray) 'Search present listbox_Customers (Active or All) for customer
                If ListArray(inc, 1) = intLocate Then booFound = True : Exit For
            Next

            If booFound = False Then 'Refill listbox_Customers with (All) customers and search again
                opt_NonActive.Checked = True
                For inc = 0 To UBound(ListArray)
                    If ListArray(inc, 1) = intLocate Then booFound = True : Exit For
                Next
            End If
            Listbox_Customers.SelectedIndex = inc

            ListBox_DrawNum.Items.Clear() 'Clear draw revision listbox
            strSQL = "SELECT DISTINCT DrawingNumber FROM Invoice Where CustCode = " & ListArray(Listbox_Customers.SelectedIndex, 1) & " ORDER BY DrawingNumber;"
            dbDataSet.Clear()
            dbDataSet.Tables.Clear()
            gbl_DstConnect.Open()
            dbAdapter = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
            dbAdapter.Fill(dbDataSet, "Search")
            gbl_DstConnect.Close()
            If dbDataSet.Tables("Search").Rows.Count <> 0 Then
                For inc = 0 To dbDataSet.Tables("Search").Rows.Count - 1
                    If Not IsDBNull(dbDataSet.Tables("Search").Rows(inc).Item(0)) Then 'Drawing number
                        ListBox_DrawNum.Items.Add(Trim(dbDataSet.Tables("Search").Rows(inc).Item(0)))
                    End If
                Next
                For inc = 0 To ListBox_DrawNum.Items.Count - 1 'Select drawing number in listbox_DrawNum 
                    If (ListBox_DrawNum.Items(inc).ToString.Contains(strSearch)) Then
                        ListBox_DrawNum.SelectedIndex = inc
                        Exit For
                    End If
                Next
            End If

            ListBox_DrawRev.Items.Clear() 'Clear draw revision listbox
            strSQL = "SELECT DISTINCT DrawingRevision FROM Invoice " _
                   & "Where CustCode = " & ListArray(Listbox_Customers.SelectedIndex, 1) & " AND " _
                   & "DrawingNumber = '" & ListBox_DrawNum.SelectedItem & "' ORDER BY DrawingRevision;"
            dbDataSet.Clear()
            dbDataSet.Tables.Clear()
            gbl_DstConnect.Open()
            dbAdapter = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
            dbAdapter.Fill(dbDataSet, "Search")
            gbl_DstConnect.Close()
            ListBox_DrawRev.Items.Add("ALL")
            If dbDataSet.Tables("Search").Rows.Count <> 0 Then
                For inc = 0 To dbDataSet.Tables("Search").Rows.Count - 1
                    If Not IsDBNull(dbDataSet.Tables("Search").Rows(inc).Item(0)) Then 'Drawing revision
                        ListBox_DrawRev.Items.Add(Trim(dbDataSet.Tables("Search").Rows(inc).Item(0)))
                    End If
                Next
                If intSpace > 0 Then 'Select drawing revision in listbox_DrawRev if drawing revision found
                    For inc = 0 To ListBox_DrawRev.Items.Count - 1
                        If (ListBox_DrawRev.Items(inc).ToString.Contains(strHold)) Then
                            ListBox_DrawRev.SelectedIndex = inc
                            Exit For
                        End If
                    Next
                Else
                    ListBox_DrawRev.SelectedIndex = 0 'Select "ALL" in listbox_DrawRev
                End If

            End If

            ListBox_Quantity.Items.Clear() 'Clear quantity listbox
            strSQL = "SELECT DISTINCT QtyOrdered FROM Invoice " _
                   & "Where CustCode = " & ListArray(Listbox_Customers.SelectedIndex, 1) & " AND " _
                   & "DrawingNumber = '" & ListBox_DrawNum.SelectedItem & "' "
            If ListBox_DrawRev.SelectedItem <> "ALL" Then 'Drawing rev associated with drawing
                strSQL = strSQL & "AND DrawingRevision = '" & ListBox_DrawRev.SelectedItem & "' ORDER BY QtyOrdered;"
            Else 'No drawing revisions found for selected drawing
                strSQL = strSQL & "ORDER BY QtyOrdered;"
            End If
            dbDataSet.Clear()
            dbDataSet.Tables.Clear()
            gbl_DstConnect.Open()
            dbAdapter = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
            dbAdapter.Fill(dbDataSet, "Search")
            gbl_DstConnect.Close()
            ListBox_Quantity.Items.Add("ALL")
            If dbDataSet.Tables("Search").Rows.Count <> 0 Then
                For inc = 0 To dbDataSet.Tables("Search").Rows.Count - 1
                    If Not IsDBNull(dbDataSet.Tables("Search").Rows(inc).Item(0)) Then 'Quantity's
                        ListBox_Quantity.Items.Add(Trim(dbDataSet.Tables("Search").Rows(inc).Item(0)))
                    End If
                Next
                ListBox_Quantity.SelectedIndex = 0 'PreSelect first item in quantity listbox 
            End If

            'Fill screen wit data, Enable DrawNumber,DrawingRevision,Quantity listboxes
            Call ArrayFill()
            D_Page = 1
            Call FormFill()
            Call ListboxEnable(True, True)

        Else 'No data found related to search
            frm_Message.Text = "12:1:0:8:3:No records were found to meet the search criteria"
            frm_Message.ShowDialog()
            tbox_Search.Text = ""
            tbox_Search.Focus()
        End If
        Exit Sub
goActionErr:
        MsgBox(Err.Description)
        Exit Sub
    End Sub
    Private Sub cmd_Click(sender As Object, e As EventArgs) Handles cmd_Exit.Click, cmd_Next.Click, cmd_Previous.Click, cmd_Print.Click, cmd_PrintAll.Click
        Select Case sender.name
            Case "cmd_Exit"
                Me.Close()
                Exit Sub

            Case "cmd_Print"
                Pages = 1 'Print only one page ( current page )
                P_Page = D_Page
                P_Line = (P_Page - 1) * 40
                '                PrintForms = New PrintDocument
                '                PrintPreviewDialog1.Document = PrintForms
                '                PrintPreviewDialog1.ShowDialog()
                PrintForms = New PrintDocument
                PrintForms.PrinterSettings.PrinterName = SystemPrinter
                PrintForms.Print()

            Case "cmd_PrintAll"
                Pages = Math.Ceiling(RecordCount / 40) 'Print all pages ( Total of pages needed )
                P_Page = 1
                P_Line = 0
                '                PrintForms = New PrintDocument
                '                PrintPreviewDialog1.Document = PrintForms
                '                PrintPreviewDialog1.ShowDialog()
                PrintForms = New PrintDocument
                PrintForms.PrinterSettings.PrinterName = SystemPrinter
                PrintForms.Print()

            Case "cmd_Next"
                D_Page = D_Page + 1
                If D_Page * 40 >= RecordCount Then cmd_Next.Enabled = False
                If D_Page > 1 Then cmd_Previous.Enabled = True
                Call FormFill()

            Case "cmd_Previous"
                D_Page = D_Page - 1
                If D_Page = 1 Then cmd_Previous.Enabled = False
                cmd_Next.Enabled = True
                Call FormFill()
        End Select
    End Sub
    Private Sub PrintForms_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintForms.PrintPage

        'Setup hard margins for printer
        Dim hDC As IntPtr = e.Graphics.GetHdc()
        Dim CurrentX, CurrentY, TextX, TextY, TextLen, TextLen1 As Integer
        Dim HardX1, HardX2, HardY1, HardY2, HardWidth, HardHeight As Integer
        Dim Font As Font
        Dim Text, Text1 As String
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

        Font = New Font("Swis721 BlkOul BT", 21, FontStyle.Regular) 'Print Drawing History
        e.Graphics.DrawString("Drawing History", Font, BlackBrush, HardX1 + 264, HardY1 + 24) 'Hardx1 + 280

        Font = New Font("Ariel", 18, FontStyle.Regular) 'Print Drawing History Dates
        Text = Label_HeaderDates.Text
        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
        TextX = HardX1 + (HardWidth - TextLen) / 2
        e.Graphics.DrawString(Text, Font, BlackBrush, TextX, HardY1 + 107)


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

            Text = "Invoice"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = HardX1 + (60 - TextLen) / 2 '62
            TextY = CurrentY + 16
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY - 15) 'Print Invoice

            Text = "Number"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (60 - TextLen) / 2 '62
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY) 'Print label Number

            CurrentX = HardX1 + 62
            points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 862)} '1st upper vertical line
            e.Graphics.DrawLines(the_pen, points)

            Text = "Invoice"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (73 - TextLen) / 2 '78
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY - 15) 'Print label Invoice

            Text = "Date"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (73 - TextLen) / 2 '77
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY) 'Print label Number

            CurrentX = HardX1 + 136 '139
            points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 862)} '2nd upper vertical line
            e.Graphics.DrawLines(the_pen, points)

            Text = "P.O."
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (138 - TextLen) / 2 '111
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY - 15) 'Print label P.O.

            Text = "Number"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (138 - TextLen) / 2
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY) 'Print label Number

            CurrentX = HardX1 + 276 '250
            points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 862)} '3rd upper vertical line
            e.Graphics.DrawLines(the_pen, points)

            Text = "P.O."
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + 1 + (26 - TextLen) / 2 '33
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY - 15) 'Print P.O.

            Text = "N0"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (26 - TextLen) / 2 '33
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY) 'Print label No

            CurrentX = HardX1 + 302 '283
            points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 862)} '4th upper vertical line
            e.Graphics.DrawLines(the_pen, points)

            Text = "Drawing"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (110 - TextLen) / 2 '111
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY - 15) 'Print label Drawing

            Text = "Number"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (110 - TextLen) / 2 '111
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY) 'Print label Number

            CurrentX = HardX1 + 413 '394
            points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 862)} '5th upper vertical line
            e.Graphics.DrawLines(the_pen, points)

            Text = "Rev"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (33 - TextLen) / 2 '36
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY) 'Print label Number

            CurrentX = HardX1 + 447 '430
            points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 862)} '6th upper vertical line
            e.Graphics.DrawLines(the_pen, points)

            Text = "Qty"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (45 - TextLen) / 2 '63
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY) 'Print label Number

            CurrentX = HardX1 + 493 '493
            points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 862)} '7th upper vertical line
            e.Graphics.DrawLines(the_pen, points)

            Text = "Item"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (73 - TextLen) / 2 '74
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY - 15) 'Print label Drawing

            Text = "Price"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (73 - TextLen) / 2 '74
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY) 'Print label Number

            CurrentX = HardX1 + 567 '567
            points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 862)} '8th upper vertical line
            e.Graphics.DrawLines(the_pen, points)

            Text = "Total"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (73 - TextLen) / 2 '74
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY - 15) 'Print label Due

            Text = "Price"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (73 - TextLen) / 2 '74
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY) 'Print label Date

            CurrentX = HardX1 + 642 '641
            points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 862)} '9th upper vertical line
            e.Graphics.DrawLines(the_pen, points)

            Text = "Material"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (109 - TextLen) / 2 '111
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY - 15) 'Print label Due

            Text = "Heat"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (109 - TextLen) / 2 '111
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY) 'Print label date

            CurrentX = HardX1 + 753 '752
            points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 862)} '10th upper vertical line
            e.Graphics.DrawLines(the_pen, points)

            Text = "Lot"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (49 - TextLen) / 2 '50
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY - 15) 'Print label Phone

            Text = "ID"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (49 - TextLen) / 2 '50
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY) 'Print label Number

            points = {New Point(HardX1, CurrentY + 31), New Point(HardX2, CurrentY + 31)} '3rd horzontal Line
            e.Graphics.DrawLines(the_pen, points)

        End Using ' the_pen 

        'Fill form with data
        CurrentY = HardY1 + 230

        If RecordCount > 40 Then 'Print page number
            Text = "Page " & P_Page
            e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 735, HardY1 + 12)
        End If

        Font = New Font("Ariel", 26, FontStyle.Regular) 'Print Company Name
        Text = Replace(Label_Company.Text, "&&", "&")
        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
        TextX = HardX1 + (HardWidth - TextLen) / 2
        e.Graphics.DrawString(Text, Font, BlackBrush, TextX, HardY1 + 60)

        Font = New Font("Ariel", 8, FontStyle.Regular)
        For intStep = 0 To 39

            'Print invoice number and invoice date
            If DataArray(P_Line, 0) <> "" Then
                Text = DataArray(P_Line, 0)
                Text1 = DataArray(P_Line, 1)
                brush = BlackBrush
            Else
                Text = "P.O."
                Text1 = DataArray(P_Line, 10)
                brush = FlagBrush
            End If
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextLen1 = Convert.ToInt32(e.Graphics.MeasureString(Text1, Font).Width)
            e.Graphics.DrawString(Text, Font, brush, HardX1 + (61 - TextLen) / 2, CurrentY) '62
            e.Graphics.DrawString(Text1, Font, brush, HardX1 + 61 + (75 - TextLen1) / 2, CurrentY) '62 + 77

            'Print purchase order number
            Text = DataArray(P_Line, 2)
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 138 + (139 - TextLen) / 2, CurrentY) '139 + 111

            'Print purchase order line number
            Text = DataArray(P_Line, 3)
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 276 + (26 - TextLen) / 2, CurrentY) '250 + 33

            'Print drawing number
            Text = DataArray(P_Line, 4)
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 304 + (110 - TextLen) / 2, CurrentY) '283 + 111

            'Print drawing revision
            Text = DataArray(P_Line, 5)
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 414 + (33 - TextLen) / 2, CurrentY) '394 + 36

            'Print quantity
            Text = DataArray(P_Line, 6)
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 447 + (45 - TextLen) / 2, CurrentY) '430 + 63

            'Print item price
            Text = FormatCurrency(DataArray(P_Line, 7))
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 494 + (73 - TextLen) / 2, CurrentY) '493 + 74

            'Print total price
            Text = FormatCurrency(DataArray(P_Line, 11))
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 569 + (73 - TextLen) / 2, CurrentY) '567 +74

            'Print material heat
            Text = DataArray(P_Line, 8)
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 644 + (109 - TextLen) / 2, CurrentY) '641 + 111

            'Print lot id
            Text = DataArray(P_Line, 9)
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 753 + (49 - TextLen) / 2, CurrentY) '752 +50

            If P_Line = RecordCount - 1 Then Exit For
            P_Line = P_Line + 1
            CurrentY = CurrentY + 20
        Next

        P_Page += 1
        e.HasMorePages = P_Page <= Pages

    End Sub

    'All texbox handlers
    Private Sub tbox_Search_GotFocus(sender As Object, e As EventArgs) Handles tbox_Search.GotFocus
        sender.BackColor = (Color.FromArgb(255, 255, 192))
        sender.CharacterCasing = CharacterCasing.Upper
    End Sub
    Private Sub tbox_Search_LostFocus(sender As Object, e As EventArgs) Handles tbox_Search.LostFocus
        sender.BackColor = Color.White
    End Sub
    Private Sub tbox_Search_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbox_Search.KeyPress
        If sender.Text = "" Then Exit Sub
        If e.KeyChar = ChrW(Keys.Return) Then cmd_Search.PerformClick()
    End Sub

    'All mouse movement and mouse over messages
    Private Sub ListBox1_MouseEnter(sender As Object, e As EventArgs) Handles Listbox_Customers.MouseEnter
        Listbox_Customers.Focus()
    End Sub
    Private Sub fra_MouseMove() Handles fra_DrawingHistory.MouseMove, fra_List2.MouseMove, fra_SearchCriteria.MouseMove, fra_Pages.MouseMove, fra_Print.MouseMove 'Clear message
        intMessage = 0
        Call MouseMessages()
    End Sub
    Private Sub tbox_MouseHover(sender As Object, e As EventArgs) Handles Listbox_Customers.MouseHover, ListBox_DrawNum.MouseHover, ListBox_DrawRev.MouseHover, ListBox_Quantity.MouseHover, opt_Active.MouseHover, opt_NonActive.MouseHover, tbox_Search.MouseHover, cmd_Search.MouseHover, cmd_Previous.MouseHover, cmd_Next.MouseHover, cmd_Print.MouseHover, cmd_PrintAll.MouseHover
        Select Case sender.name
            Case "Listbox_Customers" : intMessage = 1
            Case "ListBox_DrawNum" : intMessage = 2
            Case "ListBox_DrawRev" : intMessage = 3
            Case "ListBox_Quantity" : intMessage = 4
            Case "opt_Active" : intMessage = 5
            Case "opt_NonActive" : intMessage = 6
            Case "tbox_Search" : intMessage = 7
            Case "cmd_Search" : intMessage = 8
            Case "cmd_Previous" : intMessage = 9
            Case "cmd_Next" : intMessage = 9
            Case "cmd_Print" : intMessage = 10
            Case "cmd_PrintAll" : intMessage = 11
        End Select
        Call MouseMessages()
    End Sub
    Private Sub MouseMessages()
        Select Case intMessage
            Case 0 : lbl_Message.Text = "" 'Clear message from screen
            Case 1 : lbl_Message.Text = "Select customers name to start search for viewing Drawing Number History"
            Case 2 : lbl_Message.Text = "Select Drawing Number to narrow search"
            Case 3 : lbl_Message.Text = "Select Drawing Number Revision to narrow search"
            Case 4 : lbl_Message.Text = "Select Quantity's if needed to finalize search"
            Case 5 : lbl_Message.Text = "Select this option to show only Customers marked active"
            Case 6 : lbl_Message.Text = "Select this option to show all Customers"
            Case 7 : lbl_Message.Text = "Enter Drawing Number of item for text search"
            Case 8 : lbl_Message.Text = "Press this button to begin search on entered Drawing Number"
            Case 9 : lbl_Message.Text = "Report has multiple pages use these buttons to page thru all records"
            Case 10 : lbl_Message.Text = "Press this button to print a copy of the this page"
            Case 11 : lbl_Message.Text = "Press this button to print all pages of this report"
        End Select
    End Sub

End Class