Imports System.Drawing.Printing
Public Class frm_Inventory

    'Database related
    Dim dbAdapter, dbAdapter_Misc As OleDb.OleDbDataAdapter
    Dim dbDataSet, dbDataSet_Misc As New DataSet
    Dim strSQL As String

    'Form controls related
    Dim cmd_Button(1) As Button
    Dim lbl_Item(35) As Label
    Dim lbl_Company(35) As Label
    Dim lbl_DrawNumber(35) As Label
    Dim tbox_DrawRev(35) As TextBox
    Dim lbl_OriginalRev(35) As Label
    Dim tbox_Qty(35) As TextBox
    Dim lbl_OriginalQty(35) As Label
    Dim opt_Delete(35) As RadioButton
    Dim lbl_ID(35) As Label

    'Misc
    Dim ButCust_Array(1, 1) As Object 'Array to hold CustCodes and company names for cmd_Button(Company)
    Dim ButDraw_Array(0) As Integer 'Array to hold index of searched drawings within InventoryAll_Array
    Dim InventoryAll_Array(0, 0) As Object 'Array to hold all inventory for data selected customer
    Dim Inventory_Array(1, 4) As Object 'Array to hold inventory for a selected group 
    Dim SaveArray(0, 3) As Object 'Array to hold collection of edited items 0 = id, 1 = DrawRev, 2 = qty, 3 = item number
    Dim intCompany, EditNew, Row, LastButton, LastRow, List, DataCount, SaveCount As Integer 'intCompany = variable to hold selected company custcode
    Dim strCompany, strSearch, varInitialEntry As String 'Variable to hold selected company name
    Dim booDataChecked As Boolean 'True = record deletion in process
    Dim intMessage As Integer 'Variable used in the mouse over event to show different messages

    'All form related events
    Private Sub frm_Inventory_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Call Invoice_Update(booInvoiceUpdate) 'Check if invoicing of shipped parts needs to be excepted
        Call AddControls()
        Me.Width = 955
        EditNew = 0
        LastButton = 0
        DataCount = 0
        SaveCount = -1
    End Sub
    Private Sub frm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.Location = New Point((Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2, frm_Main.Top + 65)
        Me.Text = "Inventory                                                                                                          Date: " & Now.Date
        Call Company_Button_Labeler()
    End Sub
    Private Sub Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        dbDataSet.Clear()
        dbDataSet.Tables.Clear()
        dbDataSet_Misc.Clear()
        dbDataSet_Misc.Tables.Clear()
        Me.Dispose()
    End Sub
    Private Sub AddControls() 'Add date and quantity controls

        Dim intTop As Integer
        Dim i As Integer

        'Create array of controls in frame information
        intTop = -11
        For i = 0 To 35
            intTop = intTop + 20
            lbl_Item(i) = New Label
            lbl_Company(i) = New Label
            lbl_DrawNumber(i) = New Label
            tbox_DrawRev(i) = New TextBox
            lbl_OriginalRev(i) = New Label
            tbox_Qty(i) = New TextBox
            lbl_OriginalQty(i) = New Label
            opt_Delete(i) = New RadioButton
            lbl_ID(i) = New Label

            With lbl_Item(i)
                .Name = "lbl_Item"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .Visible = True
                .SetBounds(24, intTop, 40, 15)
                fra_Information.Controls.Add(lbl_Item(i))
            End With

            With lbl_Company(i)
                .Name = "lbl_Company"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .Visible = True
                .SetBounds(89, intTop, 270, 15)
                fra_Information.Controls.Add(lbl_Company(i))
            End With

            With lbl_DrawNumber(i)
                .Name = "lbl_DrawNumber"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .Visible = True
                .SetBounds(384, intTop, 125, 15)
                fra_Information.Controls.Add(lbl_DrawNumber(i))
            End With

            With tbox_DrawRev(i)
                .Name = "tbox_DrawRev"
                .Tag = i
                .Enabled = False
                .BackColor = Color.White
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(534, intTop, 40, 15)
                fra_Information.Controls.Add(tbox_DrawRev(i))
                AddHandler .GotFocus, AddressOf tbox_GotFocus
                AddHandler .LostFocus, AddressOf tbox_LostFocus
                AddHandler .TextChanged, AddressOf tbox_TextChanged
                AddHandler .KeyPress, AddressOf tbox_KeyPress
                AddHandler .MouseHover, AddressOf All_MouseHover
            End With

            With lbl_OriginalRev(i)
                .Name = "lbl_OriginalRev"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .Visible = True
                .SetBounds(580, intTop, 25, 15)
                fra_Information.Controls.Add(lbl_OriginalRev(i))
            End With

            With tbox_Qty(i)
                .Name = "tbox_Qty"
                .Tag = i
                .Enabled = False
                .BackColor = Color.White
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(599, intTop, 70, 15)
                fra_Information.Controls.Add(tbox_Qty(i))
                AddHandler .GotFocus, AddressOf tbox_GotFocus
                AddHandler .LostFocus, AddressOf tbox_LostFocus
                AddHandler .TextChanged, AddressOf tbox_TextChanged
                AddHandler .KeyPress, AddressOf tbox_KeyPress
                AddHandler .MouseHover, AddressOf All_MouseHover
            End With

            With lbl_OriginalQty(i)
                .Name = "lbl_OriginalQty"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .Visible = False
                .SetBounds(694, intTop, 70, 15)
                fra_Information.Controls.Add(lbl_OriginalQty(i))
            End With

            With opt_Delete(i)
                .Name = "opt_Delete"
                .Tag = i
                .Visible = False
                .SetBounds(723, intTop, 14, 15)
                fra_Information.Controls.Add(opt_Delete(i))
                AddHandler .CheckedChanged, AddressOf opt_DeleteRow
                AddHandler .MouseHover, AddressOf All_MouseHover
            End With

            With lbl_ID(i)
                .Name = "lbl_ID"
                .Tag = i
                .Visible = False
                fra_Information.Controls.Add(lbl_ID(i))
            End With

        Next
    End Sub
    Private Sub Company_Button_Labeler()

        On Error GoTo goActionErr

        'Unload all previous loaded buttons
        If Not IsNothing(cmd_Button(0)) Then
            For inc = 0 To UBound(cmd_Button)
                fra_Navigation.Controls.Remove(cmd_Button(inc))
            Next
            ReDim cmd_Button(0)
            ReDim ButCust_Array(0, 0)
            ReDim ButDraw_Array(0)
            If EditNew <> 3 Then LastButton = 0
        End If

        'Create list of companys names with inventory in stock
        strSQL = "SELECT Distinct Inventory.Custcode, Company " _
             & "FROM Inventory INNER JOIN Customers ON Inventory.CustCode = Customers.CustCode " _
             & "ORDER BY Company;"
        dbDataSet_Misc.Clear()
        dbDataSet_Misc.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter_Misc.Fill(dbDataSet_Misc, "cmd_CompName")
        gbl_DstConnect.Close()
        Dim intTop As Integer = -30

        If dbDataSet_Misc.Tables("cmd_CompName").Rows.Count() > 0 Then
            ReDim cmd_Button(dbDataSet_Misc.Tables("cmd_CompName").Rows.Count() - 1)
            ReDim ButCust_Array(dbDataSet_Misc.Tables("cmd_CompName").Rows.Count() - 1, 1)
            Dim strFitName As String
            lbl_Header.Text = "Customers"
            For inc As Integer = 0 To dbDataSet_Misc.Tables("cmd_CompName").Rows.Count() - 1

                If Not IsDBNull(dbDataSet_Misc.Tables("cmd_CompName").Rows(inc).Item(0)) Then 'Company name
                    ButCust_Array(inc, 0) = dbDataSet_Misc.Tables("cmd_CompName").Rows(inc).Item(0)
                    ButCust_Array(inc, 1) = Trim(dbDataSet_Misc.Tables("cmd_CompName").Rows(inc).Item(1))
                    strFitName = ButCust_Array(inc, 1)
                    Call Button_Labeler_Name_Fit(strFitName)

                    'Button locations 
                    intTop = intTop + 47

                    cmd_Button(inc) = New Button
                    With cmd_Button(inc)
                        .Name = "cmd_Button"
                        .Text = Trim(strFitName)
                        .Tag = inc
                        .Font = New Font("Ariel", 7, FontStyle.Regular)
                        .ForeColor = Color.Maroon
                        .BackColor = Color.AliceBlue
                        .SetBounds(6, intTop, 102, 38)
                        .Visible = True
                        fra_Navigation.Controls.Add(cmd_Button(inc))
                        AddHandler .Click, AddressOf CmdButton_Click
                        AddHandler .MouseHover, AddressOf All_MouseHover
                    End With
                End If
            Next
        Else
            frm_Message.Text = "13:1:0:1:3:There are no files on record, New is the only operation allowed"
            frm_Message.ShowDialog()
            Exit Sub
        End If

        Exit Sub
goActionErr:
        MsgBox(Err.Description)
        Exit Sub
    End Sub
    Private Sub Button_Labeler_Name_Fit(strFitName)

        Dim intFirstSpace As Integer
        Dim intSecondSpace As Integer
        Dim intThirdSpace As Integer
        Dim intFourthSpace As Integer

        'Test for simple short name that will fit on Button
        If Len(Trim(strFitName)) < 11 Then Exit Sub

        'Test for long name with no spaces (abbreviate name)
        intFirstSpace = InStr(1, strFitName, " ", 1)
        If intFirstSpace = 0 Then
            strFitName = Microsoft.VisualBasic.Left(Trim(strFitName), 10)
            Exit Sub
        End If

        'Test for long name with spaces
        intSecondSpace = InStr(intFirstSpace + 1, strFitName, " ", 1)
        If intSecondSpace > intFirstSpace And intSecondSpace < 11 Then
            intThirdSpace = InStr(intSecondSpace + 1, strFitName, " ", 1)
            If intThirdSpace > intSecondSpace And intThirdSpace < 11 Then
                intFourthSpace = InStr(intThirdSpace + 1, strFitName, " ", 1)
                If intFourthSpace > intThirdSpace And intFourthSpace < 11 Then
                    strFitName = Microsoft.VisualBasic.Left(Trim(strFitName), intFourthSpace)
                    Exit Sub
                Else
                    strFitName = Microsoft.VisualBasic.Left(Trim(strFitName), intThirdSpace)
                    Exit Sub
                End If
            Else
                strFitName = Microsoft.VisualBasic.Left(Trim(strFitName), intSecondSpace)
                Exit Sub
            End If
        Else
            strFitName = Microsoft.VisualBasic.Left(Trim(strFitName), intFirstSpace)
            Exit Sub
        End If

    End Sub 
    Private Sub ArrayFill_1() 'Fill InventoryAll array with all inventory associated with selected customer

        strSQL = "SELECT DrawNumber,Revision,Quantity,Id,CustCode FROM Inventory " _
               & "Where Custcode = " & intCompany & " ORDER BY DrawNumber,Revision;"
        dbDataSet.Clear()
        dbDataSet.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter.Fill(dbDataSet, "InventoryAll")
        gbl_DstConnect.Close()
        ReDim InventoryAll_Array(dbDataSet.Tables("InventoryAll").Rows.Count() - 1, 3)

        For intStep = 0 To UBound(InventoryAll_Array)
            If Not IsDBNull(dbDataSet.Tables("InventoryAll").Rows(intStep).Item(0)) Then 'Drawing Number
                InventoryAll_Array(intStep, 0) = Trim(dbDataSet.Tables("InventoryAll").Rows(intStep).Item(0))
            Else : InventoryAll_Array(intStep, 0) = "" : End If

            If Not IsDBNull(dbDataSet.Tables("InventoryAll").Rows(intStep).Item(1)) Then 'Drawing Revision
                InventoryAll_Array(intStep, 1) = Trim(dbDataSet.Tables("InventoryAll").Rows(intStep).Item(1))
            Else : InventoryAll_Array(intStep, 1) = "" : End If

            If Not IsDBNull(dbDataSet.Tables("InventoryAll").Rows(intStep).Item(2)) Then 'Quantity
                InventoryAll_Array(intStep, 2) = Trim(dbDataSet.Tables("InventoryAll").Rows(intStep).Item(2))
            Else : InventoryAll_Array(intStep, 2) = "" : End If

            If Not IsDBNull(dbDataSet.Tables("InventoryAll").Rows(intStep).Item(3)) Then 'Id
                InventoryAll_Array(intStep, 3) = dbDataSet.Tables("InventoryAll").Rows(intStep).Item(3)
            Else : InventoryAll_Array(intStep, 3) = "" : End If
        Next

    End Sub
    Private Sub ArrayFill_2(ButtonSelect As Integer) 'Fill Inventory array with all inventory associated with selected customer and drawing group

        Dim inc, Start As Integer
        inc = 0
        If lbl_Header.Text = "Customers" Then
            Start = 0 : DataCount = UBound(InventoryAll_Array)
            ReDim Inventory_Array(DataCount, 5)
            ReDim SaveArray(DataCount, 3)
        Else
            Start = ButDraw_Array(ButtonSelect) : DataCount = (ButDraw_Array(ButtonSelect + 1) - ButDraw_Array(ButtonSelect)) - 1
            ReDim Inventory_Array(DataCount, 5)
            ReDim SaveArray(DataCount, 3)
        End If

        For intStep = Start To Start + DataCount
            Inventory_Array(inc, 0) = InventoryAll_Array(intStep, 0) 'Drawing Number
            Inventory_Array(inc, 1) = InventoryAll_Array(intStep, 1) 'Drawing Revision
            Inventory_Array(inc, 2) = InventoryAll_Array(intStep, 2) 'Quantity
            Inventory_Array(inc, 3) = InventoryAll_Array(intStep, 3) 'Id
            inc = inc + 1
        Next

    End Sub
    Private Sub OptionDelete(blnstatus As Boolean)
        For i = 0 To Math.Min(34, DataCount)
            If blnstatus = True Then
                lbl_OriginalQty(i).Visible = False
                opt_Delete(i).Visible = True
            Else
                opt_Delete(i).Visible = False
                lbl_OriginalQty(i).Visible = True
            End If
        Next
    End Sub
    Private Sub DrawingDivide() 'Seperates large group of drawing numbers into smaller groups if needed

        'Unload all previous loaded buttons
        Dim inc As Integer
        If Not IsNothing(cmd_Button(0)) Then
            For inc = 0 To UBound(cmd_Button)
                fra_Navigation.Controls.Remove(cmd_Button(inc))
            Next
            ReDim cmd_Button(0)
            ReDim ButCust_Array(0, 0)
            ReDim ButDraw_Array(0)
            If EditNew <> 3 Then LastButton = 0
        End If

        'Find drawing numbers with inventory
        Dim strOldStart, strNewStart, strDrawNum, strDrawingNumber, strButtonName As String
        Dim intNewDash, intOldDash, intTop, intCount As Integer
        strOldStart = "" : strButtonName = ""
        intOldDash = 0
        intTop = -30
        intCount = 0

        For inc = 0 To UBound(InventoryAll_Array)

            'Test new entry for new drawing number group
            strDrawNum = InventoryAll_Array(inc, 0)
            strNewStart = Microsoft.VisualBasic.Left(Trim(strDrawNum), 1) 'Record first digit of drawing number
            intNewDash = InStr(1, strDrawNum, "-", 1)
            If strNewStart <> strOldStart Or intNewDash <> intOldDash Then 'New drawing number group found
                intOldDash = intNewDash 'Reset variable for next search

                'Test for dash found in drawing number
                If intNewDash > 0 Then
                    strButtonName = Microsoft.VisualBasic.Left(Trim(strDrawNum), intNewDash)
                Else
                    strButtonName = strDrawNum
                End If
                strDrawingNumber = strDrawNum
            Else
                strDrawingNumber = ""
            End If

            'Load button with new drawing number found
            If strDrawingNumber <> "" Then

                'Button locations 
                intTop = intTop + 47

                ButDraw_Array(intCount) = inc
                cmd_Button(intCount) = New Button
                With cmd_Button(intCount)
                    .Name = "cmd_Button"
                    .Text = Trim(strDrawNum)
                    .Tag = intCount
                    .Font = New Font("Ariel", 7, FontStyle.Regular)
                    .BackColor = Color.AliceBlue
                    .SetBounds(6, intTop, 102, 38)
                    .Visible = True
                    fra_Navigation.Controls.Add(cmd_Button(intCount))
                    AddHandler .Click, AddressOf CmdButton_Click
                End With
                intCount = intCount + 1
                ReDim Preserve cmd_Button(intCount)
                ReDim Preserve ButDraw_Array(intCount)
            End If
            strOldStart = strNewStart
        Next
        ButDraw_Array(intCount) = UBound(InventoryAll_Array) + 1 'Save index of last row of data to button array

        'Load extra [Back] button to return to Company Names
        intTop = intTop + 47
        cmd_Button(intCount) = New Button
        With cmd_Button(intCount)
            .Name = "cmd_Button"
            .Text = "CUSTOMERS"
            .Tag = intCount
            .Font = New Font("Ariel", 7, FontStyle.Regular)
            .BackColor = Color.AliceBlue
            .ForeColor = Color.Maroon
            .SetBounds(6, intTop, 102, 38)
            .Visible = True
            fra_Navigation.Controls.Add(cmd_Button(intCount))
            AddHandler .Click, AddressOf CmdButton_Click
        End With
        lbl_Header.Text = "Drawings"
        cmd_Button(1).Focus()

    End Sub
    Private Sub FormFill() 'Fill form with data pertaining to listbox selection

        Dim intStep As Integer
        booDataChecked = True

        'Ajust page and set page scroll limits if needed
        If UBound(Inventory_Array) > 35 Then 'Vscrollbar visible
            If Listbox.Visible Then
                fra_Selection.Left = 954
                If List = 1 Then Me.Width = 1184
                If List = 2 Then Me.Width = 1080
                If List = 3 Then Me.Width = 1036
            Else : Me.Width = 974 : End If
            fra_New.Width = 520
            VScrollBar1.Visible = True
            VScrollBar1.Minimum = 0
            VScrollBar1.Maximum = UBound(Inventory_Array) - 34
            VScrollBar1.SmallChange = 1
            VScrollBar1.LargeChange = 1
        Else
            If Listbox.Visible Then
                fra_Selection.Left = 935
                If List = 1 Then Me.Width = 1163
                If List = 2 Then Me.Width = 1061
                If List = 3 Then Me.Width = 1017
            Else : Me.Width = 955 : End If
            fra_New.Width = 501
            VScrollBar1.Visible = False
        End If
        Me.Left = (Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2 'Erase me if this does not center the form after frm width change ( Erase this message if all works )

        'Form fill data
        For intStep = 0 To 34
            If Row <= DataCount Then
                lbl_Item(intStep).Text = Row + 1
                lbl_Company(intStep).Text = strCompany
                lbl_DrawNumber(intStep).Text = Inventory_Array(Row, 0)
                tbox_DrawRev(intStep).Text = Inventory_Array(Row, 1)
                tbox_Qty(intStep).Text = Inventory_Array(Row, 2)
                lbl_ID(intStep).Text = Inventory_Array(Row, 3)
                lbl_OriginalRev(intStep).Text = Inventory_Array(Row, 4)
                lbl_OriginalQty(intStep).Text = Inventory_Array(Row, 5)

            Else
                lbl_Item(intStep).Text = ""
                lbl_Company(intStep).Text = ""
                lbl_DrawNumber(intStep).Text = ""
                tbox_DrawRev(intStep).Text = ""
                tbox_Qty(intStep).Text = ""
                lbl_OriginalRev(intStep).Text = ""
                lbl_OriginalQty(intStep).Text = ""
                lbl_OriginalQty(intStep).Visible = False
                opt_Delete(intStep).Visible = False
                lbl_ID(intStep).Text = ""
            End If
            Row = Row + 1
        Next

        If EditNew <> 2 Then cmd_1.Enabled = True 'Allow edit button only if New not in proccess
        booDataChecked = False
    End Sub
    Private Sub ClearData()
        For intStep = 0 To Math.Min(34, DataCount)
            lbl_Item(intStep).Text = ""
            lbl_Company(intStep).Text = ""
            lbl_DrawNumber(intStep).Text = ""
            tbox_DrawRev(intStep).Text = ""
            tbox_Qty(intStep).Text = ""
            If Label_ItemDelete.Text = "Quantity" Then lbl_OriginalQty(intStep).Text = "" Else opt_Delete(intStep).Visible = False
            lbl_ID(intStep).Text = ""
        Next
    End Sub
    Private Sub ClearNewData()
        booDataChecked = True
        tbox_CustCode.Text = ""
        lbl_CustomerName.Text = ""
        lbl_DrawingNumber.Text = ""
        lbl_DrawingRev.Text = ""
        tbox_Quantity.Text = ""
        booDataChecked = False
    End Sub
    Private Sub EnableEdits(blnStatus As Boolean)
        For intStep = 0 To Math.Min(34, DataCount)
            tbox_DrawRev(intStep).Enabled = blnStatus
            tbox_Qty(intStep).Enabled = blnStatus
        Next
        If blnStatus = True Then fra_Navigation.Enabled = False Else fra_Navigation.Enabled = True
    End Sub
    Private Sub VScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles VScrollBar1.Scroll
        Row = VScrollBar1.Value : Call FormFill()
    End Sub
    Private Sub Listbox_Fill() 'Fill listbox with data 

        Listbox.Items.Clear() 'Clear listbox

        If List = 1 Then
            strSQL = "SELECT Distinct Customers.CustCode,Company FROM Customers INNER JOIN Invoice ON Customers.CustCode = Invoice.CustCode ORDER BY Company;"
            Label_Selection1.Text = ""
            Label_Selection2.Text = "Customer Selection"
            Label_Selection1.Width = 210
            Label_Selection2.Width = 210
            Label_LineSelection.Width = 210
            Listbox.Width = 200
            fra_Selection.Width = 200
            If VScrollBar1.Visible Then Me.Width = 1184 : fra_Selection.Left = 954 Else Me.Width = 1163 : fra_Selection.Left = 935
        End If
        If List = 2 Then
            strSQL = "SELECT DISTINCT DrawingNumber FROM Invoice WHERE Custcode = " & tbox_CustCode.Text & " ORDER BY DrawingNumber;"
            Label_Selection1.Text = "Drawing"
            Label_Selection2.Text = "Selection"
            Label_Selection1.Width = 106
            Label_Selection2.Width = 106
            Label_LineSelection.Width = 1066
            Listbox.Width = 96
            fra_Selection.Width = 96
            If VScrollBar1.Visible Then Me.Width = 1080 : fra_Selection.Left = 954 Else Me.Width = 1061 : fra_Selection.Left = 935
        End If
        If List = 3 Then
            strSQL = "SELECT DISTINCT DrawingRevision FROM Invoice WHERE Custcode = " & tbox_CustCode.Text & " AND " _
            & "DrawingNumber = '" & lbl_DrawingNumber.Text & "' ORDER BY DrawingRevision;"
            Label_Selection1.Text = "Rev"
            Label_Selection2.Text = "Select"
            Label_Selection1.Width = 62
            Label_Selection2.Width = 62
            Label_LineSelection.Width = 62
            Listbox.Width = 52
            fra_Selection.Width = 52
            If VScrollBar1.Visible Then Me.Width = 1036 : fra_Selection.Left = 954 Else Me.Width = 1017 : fra_Selection.Left = 935
        End If
        Me.Left = (Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2 'Erase me if this does not center the form after frm width change ( Erase this message if all works )

        dbDataSet_Misc.Clear()
        dbDataSet_Misc.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter_Misc.Fill(dbDataSet_Misc, "DropData")
        gbl_DstConnect.Close()

        If dbDataSet_Misc.Tables("DropData").Rows.Count <> 0 Then
            Dim intStep As Integer
            For intStep = 0 To dbDataSet_Misc.Tables("DropData").Rows.Count - 1

                If List = 1 Then
                    Dim strCustCode, strCustomer As String
                    If Not IsDBNull(dbDataSet_Misc.Tables("DropData").Rows(intStep).Item(0)) Then 'Custcode
                        strCustCode = Trim(dbDataSet_Misc.Tables("DropData").Rows(intStep).Item(0))
                    Else : strCustCode = "" : End If

                    If Not IsDBNull(dbDataSet_Misc.Tables("DropData").Rows(intStep).Item(1)) Then 'Customer name
                        strCustomer = Trim(dbDataSet_Misc.Tables("DropData").Rows(intStep).Item(1))
                    Else : strCustomer = "" : End If

                    Select Case Len(strCustCode)
                        Case 1 : strCustCode = strCustCode & "  "
                        Case 2 : strCustCode = strCustCode & ""
                    End Select
                    Listbox.Items.Add(strCustCode & " - " & StrConv(LCase(Trim(strCustomer)), VbStrConv.ProperCase))
                Else
                    If Not IsDBNull(dbDataSet_Misc.Tables("DropData").Rows(intStep).Item(0)) Then 'List data
                        Listbox.Items.Add(Trim(dbDataSet_Misc.Tables("DropData").Rows(intStep).Item(0)))
                    End If
                End If
            Next
        End If

    End Sub
    Private Sub Datasave() 'Mark all selected purchase orders as invoiced

        On Error GoTo goActionErr

        'Validate entries on new entry
        If EditNew = 2 Then
            If tbox_CustCode.Text = "" Or tbox_CustCode.Text = "0" Then
                tbox_CustCode.BackColor = Color.Aqua
                frm_Message.Text = "13:1:0:1:3:Customer's code must be entered to continue"
                frm_Message.ShowDialog()
                tbox_CustCode.BackColor = Color.White
                tbox_CustCode.Focus()
                Exit Sub
            End If

            If Trim(lbl_CustomerName.Text) = "" Then
                lbl_CustomerName.BackColor = Color.Aqua
                frm_Message.Text = "13:1:0:1:3:The Customers Name must be Entered"
                frm_Message.ShowDialog()
                lbl_CustomerName.BackColor = Color.White
                lbl_CustomerName.Focus()
                Exit Sub
            End If

            If Trim(lbl_DrawingNumber.Text) = "" Then
                lbl_DrawingNumber.BackColor = Color.Aqua
                frm_Message.Text = "13:1:0:1:3:Drawing number must be Entered"
                frm_Message.ShowDialog()
                lbl_DrawingNumber.BackColor = Color.White
                lbl_DrawingNumber.Focus()
                Exit Sub
            End If
        End If

        'Save changed on edits of data
        If EditNew = 1 Then
            For i = 0 To SaveCount

                strSQL = "SELECT Id,Revision,Quantity FROM Inventory where ID = " & SaveArray(i, 0) & ";"
                dbDataSet_Misc.Clear()
                dbDataSet_Misc.Tables.Clear()
                gbl_DstConnect.Open()
                dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
                dbAdapter_Misc.Fill(dbDataSet_Misc, "DataSave")
                gbl_DstConnect.Close()

                If dbDataSet_Misc.Tables("DataSave").Rows.Count() > 0 Then
                    Dim cb0 As New OleDb.OleDbCommandBuilder(dbAdapter_Misc)
                    If Not IsNothing(SaveArray(i, 1)) Then dbDataSet_Misc.Tables("DataSave").Rows(0).Item(1) = SaveArray(i, 1)   
                    If Not IsNothing(SaveArray(i, 2)) Then
                        dbDataSet_Misc.Tables("DataSave").Rows(0).Item(2) = SaveArray(i, 2)
                    Else : dbDataSet_Misc.Tables("DataSave").Rows(0).Item(2) = 0 : End If
                    dbAdapter_Misc.Update(dbDataSet_Misc, "DataSave")
                    cb0 = Nothing
                    Inventory_Array(SaveArray(i, 3) - 1, 4) = "" 'Delete original revision from inventory_array
                    Inventory_Array(SaveArray(i, 3) - 1, 5) = "" 'Delete original quantity from inventory_array
                End If
            Next
            EnableEdits(False)

        ElseIf EditNew = 2 Then 'Save new additions to database table

            'Check for duplicate of same item
            strSQL = "SELECT ID FROM Inventory Where Custcode = " & tbox_CustCode.Text & " AND " _
                   & "DrawNumber = '" & lbl_DrawingNumber.Text & "' AND Revision = '" & lbl_DrawingRev.Text & "' ;"
            dbDataSet_Misc.Clear()
            dbDataSet_Misc.Tables.Clear()
            gbl_DstConnect.Open()
            dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
            dbAdapter_Misc.Fill(dbDataSet_Misc, "Duplicate")
            gbl_DstConnect.Close()

            If dbDataSet_Misc.Tables("Duplicate").Rows.Count() > 0 Then
                frm_Message.Text = "13:1:0:14:3:The item entered is already in inventory. Duplicates not allowed"
                frm_Message.ShowDialog()
                Call ClearNewData()
                Listbox.Visible = False
                fra_New.Visible = False
                Call cmd_ActionReset()
                EditNew = 0
                Exit Sub
            End If

            strSQL = "SELECT CustCode,DrawNumber,Revision,Quantity,Id FROM Inventory"
            dbDataSet_Misc.Clear()
            dbDataSet_Misc.Tables.Clear()
            gbl_DstConnect.Open()
            dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
            dbAdapter_Misc.Fill(dbDataSet_Misc, "NewData")
            gbl_DstConnect.Close()

            Dim cb0 As New OleDb.OleDbCommandBuilder(dbAdapter_Misc)
            Dim dsNewRow As DataRow
            dsNewRow = dbDataSet_Misc.Tables("NewData").NewRow()
            dsNewRow.Item("Custcode") = Trim(tbox_CustCode.Text)
            dsNewRow.Item("DrawNumber") = Trim(lbl_DrawingNumber.Text)
            If Trim(lbl_DrawingRev.Text) = "" Then dsNewRow.Item("Revision") = DBNull.Value Else dsNewRow.Item("Revision") = Trim(lbl_DrawingRev.Text)
            If Trim(tbox_Quantity.Text) = "" Or Trim(tbox_Quantity.Text) = "0" Then dsNewRow.Item("Quantity") = DBNull.Value Else dsNewRow.Item("Quantity") = Trim(tbox_Quantity.Text)
            dbDataSet_Misc.Tables("NewData").Rows.Add(dsNewRow)
            dbAdapter_Misc.Update(dbDataSet_Misc, "NewData")
            cb0 = Nothing

            strSearch = Trim(Microsoft.VisualBasic.Left(lbl_DrawingNumber.Text, 4))
            strCompany = lbl_CustomerName.Text
            intCompany = tbox_CustCode.Text
            Call ClearNewData()
            Listbox.Visible = False
            fra_New.Visible = False
        End If

        'Update screen with all changes
        If lbl_Item(0).Text <> "" Then LastRow = lbl_Item(0).Text - 1
        Call UpdateScreen()
        Call cmd_ActionReset()

        Exit Sub
goActionErr:
        MsgBox(Err.Description)
        Exit Sub
    End Sub
    Private Sub UpdateScreen()
        Select Case EditNew
            Case 1 'Edit recordset quantitys
                Call ArrayFill_1() 'Upate InventoryAll array
                Call ArrayFill_2(LastButton) 'Upate Inventory array
                cmd_Button(LastButton).BackColor = Color.LightGoldenrodYellow
                Row = LastRow : Call FormFill() 'Fill screen with updated data
            Case 2 'Add new records to recordset
                Call ArrayFill_1() 'Upate InventoryAll array
                If dbDataSet.Tables("InventoryAll").Rows.Count() > 35 Then
                    Call DrawingDivide()
                    For i = 0 To UBound(cmd_Button) - 1
                        If strSearch >= Trim(Microsoft.VisualBasic.Left(cmd_Button(i).Text, 4)) And strSearch < Trim(Microsoft.VisualBasic.Left(cmd_Button(i + 1).Text, 4)) Then
                            cmd_Button(i).BackColor = Color.LightGoldenrodYellow
                            cmd_Button(i).PerformClick()
                            Exit For
                        End If
                    Next
                    fra_Selection.Left = 954
                    Row = LastRow : Call FormFill() 'Fill screen with updated data
                Else
                    Call Company_Button_Labeler()
                    For i = 0 To UBound(ButCust_Array)
                        If intCompany = ButCust_Array(i, 0) Then cmd_Button(i).PerformClick()
                    Next
                    fra_Selection.Left = 954
                    Row = 0 : Call FormFill() 'Fill screen with updated data
                End If
            Case 3 'Normal deletetion of record from recordset ( Not last record )
                Call ArrayFill_1() 'Upate InventoryAll array
                If lbl_Header.Text = "Drawings" Then Call DrawingDivide() 'Update ButDraw_array with changes related to deletion of item
                Call ArrayFill_2(LastButton) 'Upate Inventory array
                cmd_Button(LastButton).BackColor = Color.LightGoldenrodYellow
                Row = LastRow : Call FormFill() 'Fill screen with updated data
            Case 4 'Deletion of customers last record from recordset
                Call ClearData()
                Call ArrayFill_1() 'Upate InventoryAll array
                Call Company_Button_Labeler()
            Case 5 'Deletion of last record for drawing number group from recordset
                Call ClearData()
                Call ArrayFill_1() 'Upate InventoryAll array
                Call DrawingDivide()
        End Select
        EditNew = 0
    End Sub


    'All command actions ( Edit,New/Restore,DeleteCancel,Exit/Save )
    Private Sub cmd_Actions_Click(sender As Object, e As EventArgs) Handles cmd_1.Click, cmd_2.Click, cmd_3.Click
        If Cursor.Current = Cursors.WaitCursor Then Exit Sub

        'Hide mouse messages
        lbl_Message1.Text = ""

        Cursor.Current = Cursors.WaitCursor
        Select Case sender.text
            Case "Cancel"
                EditNew = 0
                If VScrollBar1.Visible = True Then Me.Width = 974 Else Me.Width = 955
                Me.Left = (Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2 'Erase me if this does not center the form after frm width change ( Erase this message if all works )
                Listbox.Visible = False
                EnableEdits(False) 'Disable form editing 
                If Label_ItemDelete.Text = "Quantity" Then Call Restore()
                booDataChecked = False
                fra_New.Visible = False
                If lbl_Item(0).Text <> "" Then Call OptionDelete(True)
                Call cmd_ActionReset()

            Case "Edit"
                EditNew = 1
                EnableEdits(True) 'Enable form editing
                cmd_1.Enabled = False
                cmd_2.Text = "Cancel"
                cmd_2.Image = My.Resources.Resources.Cancel
                cmd_2.Enabled = True
                Call OptionDelete(False)
                Array.Clear(SaveArray, 0, SaveArray.Length)
                Label_ItemOriginal.Text = "Original"
                Label_ItemDelete.Text = "Quantity"
                tbox_Qty(0).Focus()

            Case "Exit"
                Cursor.Current = Cursors.Default
                Me.Close()
                Exit Sub

            Case "New"
                EditNew = 2
                List = 1 : Call Listbox_Fill()
                Listbox.Visible = True
                Call ClearNewData()
                fra_New.Visible = True
                cmd_1.Enabled = False
                cmd_2.Text = "Cancel"
                cmd_2.Image = My.Resources.Resources.Cancel
                cmd_2.Enabled = True
                tbox_CustCode.Focus()

            Case "Restore"
                Call Restore()
                Array.Clear(SaveArray, 0, SaveArray.Length)
                cmd_1.Text = "Edit"
                cmd_1.Image = My.Resources.Resources.Edit
                cmd_1.Enabled = False
                cmd_2.Text = "Cancel"
                cmd_2.Image = My.Resources.Resources.Cancel
                cmd_2.Enabled = True
                cmd_3.Text = "Exit"
                cmd_3.Image = My.Resources.Resources._Exit
                tbox_Qty(0).Focus()

            Case "Save"
                Call Datasave()
                Call OptionDelete(True)

        End Select
        Cursor.Current = Cursors.Default
    End Sub
    Private Sub CmdButton_Click(sender As Object, e As EventArgs)

        'Test for back caption on button if company name's not on labels
        If cmd_Button(sender.tag).Text = "CUSTOMERS" Then
            Call Company_Button_Labeler()
            Call ClearData()
            cmd_1.Enabled = False 'Disable editing
            Exit Sub
        End If

        'Change selected button color 
        cmd_Button(LastButton).BackColor = Color.AliceBlue
        LastButton = sender.tag

        Dim ButtonCall As Integer
        If lbl_Header.Text = "Customers" Then 'Company names on buttons
            intCompany = ButCust_Array(sender.tag, 0) 'Record customer info of search
            strCompany = ButCust_Array(sender.tag, 1)
            Call ClearData()
            Call ArrayFill_1()
            If UBound(ButCust_Array) = 0 Then Call OptionDelete(True)
            If dbDataSet.Tables("InventoryAll").Rows.Count() > 35 Then
                Call DrawingDivide()
                ButtonCall = 0
                cmd_Button(ButtonCall).BackColor = Color.LightGoldenrodYellow
            Else
                cmd_Button(sender.tag).BackColor = Color.LightGoldenrodYellow
            End If
        Else
            ButtonCall = sender.tag
            cmd_Button(ButtonCall).BackColor = Color.LightGoldenrodYellow
        End If

        Call ArrayFill_2(ButtonCall)
        Call OptionDelete(True)
        VScrollBar1.Value = 0
        Row = 0 : Call FormFill()

    End Sub
    Private Sub opt_DeleteRow(sender As Object, e As EventArgs)
        If opt_Delete(sender.tag).Checked = False Then Exit Sub

        lbl_Item(sender.tag).ForeColor = Color.Red
        lbl_Company(sender.tag).ForeColor = Color.Red
        lbl_DrawNumber(sender.tag).ForeColor = Color.Red
        tbox_DrawRev(sender.tag).ForeColor = Color.Red

        frm_Message.Text = "13:2:0:1:3:Are you sure you want to delete this item from Inventory"
        frm_Message.ShowDialog()
        If MessageResult = True Then

            'Delete selection from database
            strSQL = "SELECT ID FROM Inventory WHERE ID = " & lbl_ID(sender.tag).Text & ";"
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

            'Update screen with all changes
            If DataCount > 0 Then 'Last record was not deleted
                EditNew = 3 'Normal delete
            Else
                If lbl_Header.Text = "Customers" Then EditNew = 4 Else EditNew = 5 '4 = Customers last record deleted, 5 = Last item in drawing number group deleted
            End If
            LastRow = lbl_Item(0).Text - 1
            Call UpdateScreen()

        End If

        lbl_Item(sender.tag).ForeColor = System.Drawing.SystemColors.ControlText
        lbl_Company(sender.tag).ForeColor = System.Drawing.SystemColors.ControlText
        lbl_DrawNumber(sender.tag).ForeColor = System.Drawing.SystemColors.ControlText
        tbox_DrawRev(sender.tag).ForeColor = System.Drawing.SystemColors.ControlText
        opt_Delete(sender.tag).Checked = False


    End Sub
    Private Sub ListBox_Select(sender As Object, e As EventArgs) Handles Listbox.DoubleClick, Listbox.KeyPress
        Dim Visible As Boolean = True
        booDataChecked = True
        Select Case List
            Case 1
                tbox_CustCode.Text = Trim(Microsoft.VisualBasic.Left(Listbox.SelectedItem, 3))
                lbl_CustomerName.Text = Trim(Mid(Listbox.SelectedItem, 6))
                List = 2 : Call Listbox_Fill()
            Case 2
                lbl_DrawingNumber.Text = Listbox.SelectedItem
                List = 3 : Call Listbox_Fill()
                If Listbox.Items.Count = 0 Then
                    Visible = False
                    cmd_3.Text = "Save"
                    cmd_3.Image = My.Resources.Resources.Save
                    tbox_Quantity.Enabled = True
                    tbox_Quantity.Focus()
                End If
            Case 3
                lbl_DrawingRev.Text = Listbox.SelectedItem
                cmd_3.Text = "Save"
                cmd_3.Image = My.Resources.Resources.Save
                tbox_Quantity.Enabled = True
                tbox_Quantity.Focus()
                Visible = False
        End Select

        If Visible = False Then
            Listbox.Visible = False
            If VScrollBar1.Visible Then
                Me.Width = 974
            Else
                Me.Width = 955
            End If
            Me.Left = (Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2 'Erase me if this does not center the form after frm width change ( Erase this message if all works )
        End If
        booDataChecked = False
    End Sub
    Private Sub cmd_ActionReset()
        cmd_1.Text = "Edit"
        cmd_1.Image = My.Resources.Resources.Edit
        If lbl_Item(0).Text <> "" Then cmd_1.Enabled = True Else cmd_1.Enabled = False 'Allow edit only if screen filled with data
        cmd_2.Text = "New"
        cmd_2.Image = My.Resources.Resources._New
        cmd_2.Enabled = True
        cmd_3.Text = "Exit"
        cmd_3.Image = My.Resources.Resources._Exit
        cmd_3.Enabled = True
        Label_ItemOriginal.Text = "Item"
        Label_ItemDelete.Text = "Delete"
    End Sub
    Private Sub Restore()
        For intStep = 0 To Math.Min(34, UBound(Inventory_Array)) 'Restore original values to screen
            If lbl_OriginalRev(intStep).Text <> "" Then
                tbox_DrawRev(intStep).Text = lbl_OriginalRev(intStep).Text
                lbl_OriginalRev(intStep).Text = ""
            End If
            If lbl_OriginalQty(intStep).Text <> "" Then
                tbox_Qty(intStep).Text = lbl_OriginalQty(intStep).Text
                lbl_OriginalQty(intStep).Text = ""
            End If
        Next
    End Sub


    'All control handlers
    Private Sub tbox_GotFocus(sender As Object, e As EventArgs) Handles tbox_CustCode.GotFocus, tbox_Quantity.GotFocus
        If EditNew = 0 Then Exit Sub
        varInitialEntry = Trim(sender.Text)
        If sender.name = "tbox_DrawRev" Then sender.CharacterCasing = CharacterCasing.Upper
        sender.BackColor = (Color.FromArgb(255, 255, 192))
    End Sub
    Private Sub tbox_LostFocus(sender As Object, e As EventArgs) Handles tbox_CustCode.LostFocus, tbox_Quantity.LostFocus
        If EditNew = 0 Or booDataChecked = True Or sender.text = varInitialEntry Then sender.BackColor = Color.White : Exit Sub
        Select Case sender.Name
            Case "tbox_DrawRev"
                If sender.text <> "" Then
                    For i = 0 To sender.text.Length - 1
                        If Not UCase(sender.text(i)) Like "[A-Z]" Then 'Test entry for only letters
                            booDataChecked = True
                            frm_Message.Text = "13:1:0:1:2:Invalid Entry --- alphabet letter entries are only allowed"
                            frm_Message.ShowDialog()
                            sender.text = ""
                            sender.Focus()
                            booDataChecked = False
                            Exit For
                        End If
                    Next
                End If
            Case "tbox_Qty", "tbox_Quantity", "tbox_CustCode"
                If sender.Text <> "" Then
                    If Not IsNumeric(sender.Text) Then 'Check for numerical entry
                        booDataChecked = True
                        frm_Message.Text = "13:1:0:1:3:Invalid Entry --- Numerical entries are only allowed"
                        frm_Message.ShowDialog()
                        If sender.name = "tbox_Qty" Then
                            sender.text = lbl_OriginalQty(sender.tag).Text
                            lbl_OriginalQty(sender.tag).Text = ""
                        Else
                            sender.text = ""
                        End If
                        sender.Focus()
                        booDataChecked = False
                        Exit Sub
                    Else
                        If sender.name = "tbox_CustCode" And sender.text <> varInitialEntry Then 'Custcode change, delete all previous entries
                            booDataChecked = True
                            lbl_DrawingNumber.Text = ""
                            lbl_DrawingRev.Text = ""
                            tbox_Quantity.Text = ""
                            tbox_Quantity.Enabled = False
                            booDataChecked = False
                            Listbox.Visible = True
                            cmd_3.Text = "Exit"
                            cmd_3.Image = My.Resources.Resources._Exit
                        Else
                            If tbox_CustCode.Text <> "" And lbl_DrawingNumber.Text <> "" Then
                                cmd_3.Text = "Save"
                                cmd_3.Image = My.Resources.Resources.Save
                            End If
                        End If
                    End If
                End If
        End Select

        'Lookup custcode and fill in customer name
        If sender.name = "tbox_CustCode" And sender.text <> "" Then

            strSQL = "SELECT Company FROM Customers WHERE Custcode = " & tbox_CustCode.Text & ";"
            dbDataSet_Misc.Clear()
            dbDataSet_Misc.Tables.Clear()
            gbl_DstConnect.Open()
            dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
            dbAdapter_Misc.Fill(dbDataSet_Misc, "CustomerData")
            gbl_DstConnect.Close()

            If dbDataSet_Misc.Tables("CustomerData").Rows.Count() > 0 Then
                If Not IsDBNull(dbDataSet_Misc.Tables("CustomerData").Rows(0).Item(0)) Then
                    lbl_CustomerName.Text = Trim(dbDataSet_Misc.Tables("CustomerData").Rows(0).Item(0))
                End If
                List = 2 : Call Listbox_Fill()
                If Listbox.Items.Count = 0 Then
                    frm_Message.Text = "13:1:0:13:3:Inventory can not be tracked for a customer that have not placed an order"
                    frm_Message.ShowDialog()
                    booDataChecked = True
                    tbox_CustCode.Text = ""
                    lbl_CustomerName.Text = ""
                    booDataChecked = False
                    List = 1 : Call Listbox_Fill()
                    tbox_CustCode.Focus()
                    Exit Sub
                End If
            Else
                booDataChecked = True
                frm_Message.Text = "13:1:0:12:3:There are no customers associated with this customer code"
                frm_Message.ShowDialog()
                tbox_CustCode.Text = ""
                tbox_CustCode.Focus()
                booDataChecked = False
                Exit Sub
            End If
        End If

        'Update inventory array with changes
        If EditNew = 1 And VScrollBar1.Enabled = False Then
            Inventory_Array(lbl_Item(sender.tag).Text - 1, 2) = sender.text
            SaveCount = SaveCount + 1
            SaveArray(SaveCount, 0) = lbl_ID(sender.tag).Text 'Save record id
            SaveArray(SaveCount, 1) = tbox_DrawRev(sender.tag).Text 'Save new drawing revision
            SaveArray(SaveCount, 2) = tbox_Qty(sender.tag).Text 'Save new quantity
            SaveArray(SaveCount, 3) = lbl_Item(sender.tag).Text 'Save item number
            VScrollBar1.Enabled = True
            cmd_1.Text = "Restore"
            cmd_1.Image = My.Resources.Resources.Restore
            cmd_1.Enabled = True
        End If
        sender.BackColor = Color.White
    End Sub
    Private Sub tbox_TextChanged(sender As Object, e As EventArgs) Handles tbox_CustCode.TextChanged, tbox_Quantity.TextChanged
        If booDataChecked = True Or EditNew <> 1 Then Exit Sub

        VScrollBar1.Enabled = False
        Select Case sender.name
            Case "tbox_DrawRev"
                If lbl_OriginalRev(sender.tag).Text = "" Then
                    lbl_OriginalRev(sender.tag).Text = varInitialEntry
                    Inventory_Array(lbl_Item(sender.tag).Text - 1, 4) = varInitialEntry 'Update inventory array with original drawing revision data
                End If
            Case "tbox_Qty"
                If lbl_OriginalQty(sender.tag).Text = "" Then
                    lbl_OriginalQty(sender.tag).Text = varInitialEntry
                    Inventory_Array(lbl_Item(sender.tag).Text - 1, 5) = varInitialEntry 'Update inventory array with original quantity data
                End If
        End Select
        cmd_3.Text = "Save"
        cmd_3.Image = My.Resources.Resources.Save

    End Sub
    Private Sub tbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbox_CustCode.KeyPress, tbox_Quantity.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            Select Case sender.name
                Case "tbox_DrawRev" : tbox_Qty(sender.tag).Focus()
                    If VScrollBar1.Visible = True Then
                        If sender.tag < 34 Then tbox_DrawRev(sender.tag + 1).Focus() Else tbox_DrawRev(0).Focus()
                    Else
                        If UBound(Inventory_Array) = 0 Then
                            cmd_2.Focus()
                        Else
                            If sender.tag < UBound(Inventory_Array) Then tbox_DrawRev(sender.tag + 1).Focus() Else tbox_DrawRev(0).Focus()
                        End If
                    End If
                Case "tbox_Qty"
                    If VScrollBar1.Visible = True Then
                        If sender.tag < 34 Then tbox_Qty(sender.tag + 1).Focus() Else tbox_Qty(0).Focus()
                    Else
                        If UBound(Inventory_Array) = 0 Then
                            cmd_2.Focus()
                        Else
                            If sender.tag < UBound(Inventory_Array) Then tbox_Qty(sender.tag + 1).Focus() Else tbox_Qty(0).Focus()
                        End If
                    End If
                Case "tbox_CustCode"
                    If tbox_Quantity.Enabled = True Then tbox_Quantity.Focus() Else cmd_3.Focus()
                Case "tbox_Quantity" : tbox_CustCode.Focus()
            End Select
        End If
    End Sub


    'All mouse movement and mouse over messages
    Private Sub fra_MouseMove() Handles fra_Information.MouseMove, fra_New.MouseMove, fra_Edits.MouseMove 'Clear message
        intMessage = 0
        Call MouseMessages()
    End Sub
    Private Sub All_MouseHover(sender As Object, e As EventArgs) Handles VScrollBar1.MouseHover, tbox_CustCode.MouseHover, lbl_CustomerName.MouseHover, lbl_DrawingNumber.MouseHover, lbl_DrawingRev.MouseHover, tbox_Quantity.MouseHover, Listbox.MouseHover
        Select Case sender.name
            Case "VScrollBar1" : intMessage = 1
            Case "cmd_Button" : intMessage = 2
            Case "opt_Delete" : intMessage = 3
            Case "tbox_Qty" : intMessage = 4
            Case "cmd_1" : intMessage = 5
            Case "cmd_2" : intMessage = 6
            Case "cmd_3" : intMessage = 7
            Case "tbox_CustCode" : intMessage = 8
            Case "lbl_DrawingNumber" : intMessage = 9
            Case "tbox_DrawingRev" : intMessage = 10
            Case "tbox_Quantity" : intMessage = 11
            Case "Listbox" : intMessage = 12
        End Select
        Call MouseMessages()
    End Sub
    Private Sub MouseMessages()

        Select Case intMessage
            Case 0 : lbl_Message1.Text = "" : lbl_Message2.Text = "" 'Clear messages from screen
            Case 1 : lbl_Message1.Text = "All orders not shown. Scroll down to view all items"
            Case 2
                lbl_Message1.Text = "Press these buttons to view all"
                If lbl_Header.Text = "Customers" Then
                    lbl_Message2.Text = "Inventory for the customer listed on the button"
                Else
                    lbl_Message2.Text = "Inventory for the listed drawing number group"
                End If
            Case 3
                lbl_Message1.Text = "Press this button to delete"
                lbl_Message2.Text = "This item from the customers inventory"
            Case 4
                lbl_Message1.Text = "Change this entry to update the"
                lbl_Message2.Text = "amount of items stored in customers inventory "
            Case 5
                If cmd_1.Text = "Edit" Then
                    lbl_Message1.Text = "Press this button to allow the"
                    lbl_Message2.Text = "editing of the amount of Customer inventory"
                Else
                    lbl_Message1.Text = "Press this button to restore all edits"
                    lbl_Message2.Text = "back to the original amounts before changes"
                End If
            Case 6
                If cmd_2.Text = "New" Then
                    lbl_Message1.Text = "Press this button to add a new"
                    lbl_Message2.Text = "Drawing Number into the Customer's inventory"
                Else
                    lbl_Message1.Text = "Press this button to cancel all actions"
                End If
            Case 7
                If cmd_3.Text = "Exit" Then
                    lbl_Message1.Text = "Press this button to exit"
                Else
                    lbl_Message1.Text = "Press this button to save"
                    lbl_Message2.Text = "all entered data into the database"
                End If
            Case 8
                If Label_Selection2.Text = "Customer Selection" Then
                    lbl_Message1.Text = "Enter the Custcode of the customer being added"
                    lbl_Message2.Text = "or select the customer from the list on the right"
                End If
            Case 9
                If Label_Selection2.Text = "Selection" Then
                    lbl_Message1.Text = "Select the Drawing Number by clicking"
                    lbl_Message2.Text = "on the drawing number from the list on the right"
                End If
            Case 10
                If Label_Selection2.Text = "Select" Then
                    lbl_Message1.Text = "Select the Drawing Revision by clicking"
                    lbl_Message2.Text = "on the drawing revision from the list on the right"
                End If
            Case 11 : lbl_Message1.Text = "Enter the amount in Customer's Inventory"
            Case 12
                Select Case Label_Selection2.Text
                    Case Is = "Customer Selection"
                        lbl_Message1.Text = "Double click on the Customer's"
                        lbl_Message2.Text = "name to enter it in the form below"
                    Case Is = "Selection"
                        lbl_Message1.Text = "Double click on the Customer's Drawing"
                        lbl_Message2.Text = "number to enter it in the form below"
                    Case Is = "Selection"
                        lbl_Message1.Text = "Double click on the Customer's Drawing"
                        lbl_Message2.Text = "Revision to enter it in the form below"
                End Select
        End Select
    End Sub

End Class