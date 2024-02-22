Imports System.Drawing.Printing
Public Class frm_CheckbookChecks
    Dim dbAdapter, dbAdapter_SystemData, dbAdapter_Misc As OleDb.OleDbDataAdapter
    Dim dbDataSet, dbDataSet_SystemData, dbDataSet_Misc As New DataSet
    Dim strSQL As String
    Dim CheckNumber, ListSelect, Orig_Category As Integer
    Dim booCorrection, booDataChecked, booListbox As Boolean
    Dim strInitEntry As String
    Dim listArray(1) As Object 'Array to hold listbox checkname selection Id

    Dim lbl_ChkAmt(3) As Label
    Dim tbox_ChkAmt(3) As TextBox
    Dim opt_Category(17) As RadioButton
    Dim lbl_DocItem(3) As Label
    Dim tbox_DocInvoNum(3) As TextBox
    Dim tbox_DocInvoDate(3) As MaskedTextBox
    Dim lbl_DocAmt(3) As Label
    Dim lbl_DocPaidAmt(3) As Label
    Dim tbox_DocDiscount(3) As TextBox

    'Print Related
    Private WithEvents prnDocument As PrintDocument
    Declare Function GetDeviceCaps% Lib "GDI32" (ByVal hDC%, ByVal nIndex%)
    Dim CheckTotal As Double = 0
    Private Buffer, CheckCount As Integer
    Private BlackBrush As New SolidBrush(Color.Black)
    Dim booPrint As Boolean = False 'False = at start of printing, check for checks loaded in printer ( Ask only once )

    Private Sub frm_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated
        Call AddControls()
    End Sub
    Private Sub frm_Checks_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim strCity, strState, strZipCode As String
        Panel_MsgBox.Top = 160
        Panel_MsgBox.Left = 160
        Me.Size = New Size(862, 572)
        Me.Left = frm_Checkbook.Left + 24
        Me.Top = frm_Checkbook.Top + 50
        Listbox_Payto.SetBounds(173, 114, 268, 24)

        'Retrieve tax category data
        strSQL = "SELECT Id,Category FROM TaxCategorys ORDER BY Id;"
        dbDataSet_Misc.Clear()
        dbDataSet_Misc.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter_Misc.Fill(dbDataSet_Misc, "TaxCategory")
        gbl_DstConnect.Close()
        If dbDataSet_Misc.Tables("TaxCategory").Rows.Count <> 0 Then 'Records found 
            For i = 0 To dbDataSet_Misc.Tables("TaxCategory").Rows.Count - 1
                opt_Category(i).Text = dbDataSet_Misc.Tables("TaxCategory").Rows(i).Item(1)
            Next
        Else
            frm_Message.Text = "15:1:0:1:3:Tax categorys must be set up before check printing will be allowed"
            frm_Message.ShowDialog()
            Me.Close()
            Exit Sub
        End If

        'Retrieve system variables
        strSQL = "SELECT CompanyName,CompanyAddress,CompanyCity,CompanyState,CompanyZipCode,CompanyPhone,CheckbookLastCheck,Id FROM System;"
        dbDataSet_SystemData.Clear()
        dbDataSet_SystemData.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter_SystemData = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter_SystemData.Fill(dbDataSet_SystemData, "SystemData")
        gbl_DstConnect.Close()
        If dbDataSet_SystemData.Tables("SystemData").Rows.Count = 1 Then
            lbl_HeaderName.Text = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(0) 'Company Name
            lbl_HeaderAddress.Text = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(1) 'Company Address
            strCity = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(2) 'Company City
            strState = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(3) 'Company State
            strZipCode = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(4) 'Company ZipCode
            lbl_HeaderCity.Text = strCity & ", " & strState & ", " & strZipCode
            lbl_HeaderPhone.Text = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(5) 'Company Phone
            CheckNumber = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(6) + 1 'Checkbook Last Check number plus 1
        End If
        booDataChecked = True
        tbox_Date.Text = Format(Now.Date, "MM/dd/yyyy")
        lbl_CheckNumber.Text = CheckNumber
        booDataChecked = False
        Orig_Category = 0
        booListbox = False
        cmd_Clear.Visible = False
        tbox_Payto.Focus()

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
    Private Sub AddControls() 'Add amount controls
        Dim int_Top, int_Left As Integer
        Dim i As Integer

        'Create array of controls ( Amounts )
        int_Top = 57
        For i = 0 To 3
            int_Top = int_Top + 35

            lbl_ChkAmt(i) = New Label
            tbox_ChkAmt(i) = New TextBox

            With lbl_ChkAmt(i)
                .Name = "lbl_ChkAmt"
                .Tag = i
                .Font = New Font("Microsoft Sans Serif", 10, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Right
                .BackColor = System.Drawing.SystemColors.Control
                .BorderStyle = BorderStyle.None
                .Text = "Amount:"
                If i = 0 Then .Visible = True Else .Visible = False
                .SetBounds(654, int_Top, 60, 20)
                Me.Controls.Add(lbl_ChkAmt(i))
            End With

            With tbox_ChkAmt(i)
                .Name = "tbox_ChkAmt"
                .Tag = i
                .Enabled = True
                .BackColor = Color.White
                .Font = New Font("Microsoft Sans Serif", 10, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Left
                If i = 0 Then .Visible = True Else .Visible = False
                .SetBounds(715, int_Top - 3, 90, 27)
                Me.Controls.Add(tbox_ChkAmt(i))
                AddHandler .GotFocus, AddressOf tbox_GotFocus
                AddHandler .LostFocus, AddressOf tbox_lostFocus
                AddHandler .KeyPress, AddressOf tbox_KeyPress
            End With
        Next

        'Create array of controls ( Category frame)
        int_Left = 25
        int_Top = -13
        For i = 0 To 17

            int_Top = int_Top + 25
            opt_Category(i) = New RadioButton
            With opt_Category(i)
                .Name = "opt_Category"
                .Tag = i
                .Font = New Font("Microsoft Sans Serif", 7.8, FontStyle.Regular)
                .TextAlign = ContentAlignment.MiddleLeft
                .BackColor = Color.Cornsilk
                .SetBounds(int_Left, int_Top, 114, 21)
                fra_TaxCategory.Controls.Add(opt_Category(i))
            End With
            If int_Top = 87 Then int_Top = -13 : int_Left = int_Left + 169
        Next

        'Create array of controls ( Documentation frame )
        int_Top = 34
        For i = 0 To 3
            int_Top = int_Top + 21
            lbl_DocItem(i) = New Label
            tbox_DocInvoNum(i) = New TextBox
            tbox_DocInvoDate(i) = New MaskedTextBox
            lbl_DocAmt(i) = New Label
            lbl_DocPaidAmt(i) = New Label
            tbox_DocDiscount(i) = New TextBox

            With lbl_DocItem(i)
                .Name = "lbl_DocItem"
                .Tag = i
                .Font = New Font("Microsoft Sans Serif", 10, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.Ivory
                .BorderStyle = BorderStyle.None
                .Text = i + 1
                If i = 0 Then .Visible = True Else .Visible = False
                .SetBounds(9, int_Top, 80, 20)
                fra_Documentation.Controls.Add(lbl_DocItem(i))
            End With

            With tbox_DocInvoNum(i)
                .Name = "tbox_DocInvoNum"
                .Tag = i
                .Enabled = True
                .BackColor = Color.Ivory
                .BorderStyle = BorderStyle.None
                .Font = New Font("Microsoft Sans Serif", 10, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                If i = 0 Then .Visible = True Else .Visible = False
                .SetBounds(106, int_Top, 130, 27)
                fra_Documentation.Controls.Add(tbox_DocInvoNum(i))
                AddHandler .GotFocus, AddressOf tbox_GotFocus
                AddHandler .LostFocus, AddressOf tbox_lostFocus
                AddHandler .TextChanged, AddressOf tbox_TextChanged
                AddHandler .KeyPress, AddressOf tbox_KeyPress
            End With

            With tbox_DocInvoDate(i)
                .Name = "tbox_DocInvoDate"
                .Tag = i
                .Enabled = True
                .BackColor = Color.Ivory
                .BorderStyle = BorderStyle.None
                .Font = New Font("Microsoft Sans Serif", 10, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .Mask = ("##/##/####")
                If i = 0 Then .Visible = True Else .Visible = False
                .SetBounds(269, int_Top, 90, 27)
                fra_Documentation.Controls.Add(tbox_DocInvoDate(i))
                AddHandler .GotFocus, AddressOf tbox_GotFocus
                AddHandler .LostFocus, AddressOf tbox_lostFocus
                AddHandler .TextChanged, AddressOf tbox_TextChanged
                AddHandler .KeyPress, AddressOf tbox_KeyPress
                AddHandler .MouseClick, AddressOf tbox_MouseClick
            End With

            With lbl_DocAmt(i)
                .Name = "lbl_DocAmt"
                .Tag = i
                .Font = New Font("Microsoft Sans Serif", 10, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.Ivory
                .BorderStyle = BorderStyle.None
                If i = 0 Then .Visible = True Else .Visible = False
                .SetBounds(412, int_Top, 90, 20)
                fra_Documentation.Controls.Add(lbl_DocAmt(i))
            End With

            With lbl_DocPaidAmt(i)
                .Name = "lbl_DocPaidAmt"
                .Tag = i
                .Font = New Font("Microsoft Sans Serif", 10, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.Ivory
                .BorderStyle = BorderStyle.None
                If i = 0 Then .Visible = True Else .Visible = False
                .SetBounds(555, int_Top, 90, 20)
                fra_Documentation.Controls.Add(lbl_DocPaidAmt(i))
            End With

            With tbox_DocDiscount(i)
                .Name = "tbox_DocDiscount"
                .Tag = i
                .Enabled = True
                .BackColor = Color.Ivory
                .BorderStyle = BorderStyle.None
                .Font = New Font("Microsoft Sans Serif", 10, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .Text = 0
                If i = 0 Then .Visible = True Else .Visible = False
                .SetBounds(723, int_Top, 30, 27)
                fra_Documentation.Controls.Add(tbox_DocDiscount(i))
                AddHandler .GotFocus, AddressOf tbox_GotFocus
                AddHandler .LostFocus, AddressOf tbox_lostFocus
                AddHandler .TextChanged, AddressOf tbox_TextChanged
                AddHandler .KeyPress, AddressOf tbox_KeyPress
            End With

        Next
    End Sub
    Private Sub cmd_Cancel_Click(sender As Object, e As EventArgs) Handles cmd_Cancel.Click
        Me.Close() : Exit Sub
    End Sub
    Private Sub cmd_Clear_Click(sender As Object, e As EventArgs) Handles cmd_Clear.Click
        booDataChecked = True
        tbox_Payto.Text = ""
        tbox_Street.Text = ""
        tbox_City.Text = ""
        tbox_State.Text = ""
        tbox_ZipCode.Text = ""
        tbox_Memo.Text = ""
        opt_Category(Orig_Category).Checked = False
        booDataChecked = False
        ListSelect = 0
        cmd_Clear.Visible = False
        tbox_Payto.Focus()
    End Sub
    Private Sub cmd_Action_Click(sender As Object, e As EventArgs) Handles cmd_Action.Click
        If booDataChecked = True Then Exit Sub
        Select Case sender.text
            Case "Next"

                'Check for complete entries before advancing
                Dim intAlarm As Integer = 0
                Do While True
                    If tbox_Date.Text = "  /  /" Then intAlarm = 1 : Exit Do
                    If tbox_Payto.Text = "" Then intAlarm = 2 : Exit Do
                    If tbox_ChkAmt(0).Text = "" Then intAlarm = 3 : Exit Do
                    Dim booPass As Boolean = False
                    For i = 0 To 17 'Check if category selected
                        If opt_Category(i).Checked = True Then booPass = True : Exit For
                    Next
                    If booPass = False Then intAlarm = 4
                    Exit Do
                Loop
                If intAlarm = 0 Then 'Complete data
                    Printer_MsgBox(0) 'Ask if documentation needed                 
                Else
                    Select Case intAlarm
                        Case 1 : frm_Message.Text = "15:1:0:1:3:Date must be entered to continue"
                        Case 2 : frm_Message.Text = "15:1:0:1:3:Payto must be entered to continue"
                        Case 3 : frm_Message.Text = "15:1:0:1:3:Amount must be entered to continue"
                        Case 4 : frm_Message.Text = "15:1:0:1:3:Please select a Category to continue"
                    End Select
                    frm_Message.ShowDialog()
                    Select Case intAlarm
                        Case 1 : tbox_Date.Focus()
                        Case 2 : tbox_Payto.Focus()
                        Case 3 : tbox_ChkAmt(0).Focus()
                    End Select
                End If
            Case "Print"
                If booPrint = False Then
                    booPrint = True
                    Printer_MsgBox(1) '"Load checks in printer and press [OK] when ready"
                Else
                    Printer_MsgBox(1)
                    prnDocument = New PrintDocument
                    prnDocument.Print()
                End If
        End Select

    End Sub
    Private Sub Listbox_Payto_DoubleClick() Handles Listbox_Payto.DoubleClick

        ListSelect = listArray(Listbox_Payto.SelectedIndex) 'Record id of listbox selected item for future update

        booDataChecked = True
        tbox_Payto.Text = Listbox_Payto.SelectedItem
        If Not IsDBNull(dbDataSet.Tables("CheckName").Rows(Listbox_Payto.SelectedIndex).Item(2)) Then
            tbox_Street.Text = Trim(dbDataSet.Tables("CheckName").Rows(Listbox_Payto.SelectedIndex).Item(2)) 'Street address
        Else : tbox_Street.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("CheckName").Rows(Listbox_Payto.SelectedIndex).Item(3)) Then
            tbox_City.Text = Trim(dbDataSet.Tables("CheckName").Rows(Listbox_Payto.SelectedIndex).Item(3)) 'City
        Else : tbox_City.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("CheckName").Rows(Listbox_Payto.SelectedIndex).Item(4)) Then
            tbox_State.Text = Trim(dbDataSet.Tables("CheckName").Rows(Listbox_Payto.SelectedIndex).Item(4)) 'State
        Else : tbox_State.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("CheckName").Rows(Listbox_Payto.SelectedIndex).Item(5)) Then
            tbox_ZipCode.Text = Trim(dbDataSet.Tables("CheckName").Rows(Listbox_Payto.SelectedIndex).Item(5)) 'Zipcode
        Else : tbox_ZipCode.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("CheckName").Rows(Listbox_Payto.SelectedIndex).Item(6)) Then
            opt_Category(dbDataSet.Tables("CheckName").Rows(Listbox_Payto.SelectedIndex).Item(6)).Checked = True 'Category
            Orig_Category = Convert.ToInt32(dbDataSet.Tables("CheckName").Rows(Listbox_Payto.SelectedIndex).Item(6))
        End If

        ListboxShow(False)
        booDataChecked = False
        cmd_Clear.Visible = True
        tbox_ChkAmt(0).Focus()
    End Sub
    Private Sub ListboxShow(blnStatus As Boolean)
        Dim booStatus As Boolean
        If blnStatus = True Then booStatus = False Else booStatus = True
        tbox_Date.Enabled = booStatus
        lbl_Street.Visible = booStatus
        tbox_Street.Visible = booStatus
        lbl_City.Visible = booStatus
        tbox_City.Visible = booStatus
        lbl_State.Visible = booStatus
        tbox_State.Visible = booStatus
        lbl_ZipCode.Visible = booStatus
        tbox_ZipCode.Visible = booStatus
        lbl_Memo.Visible = booStatus
        tbox_Memo.Visible = booStatus
        For i = 0 To 3
            tbox_ChkAmt(i).Enabled = booStatus
        Next
        booListbox = blnStatus
        Listbox_Payto.Visible = blnStatus
    End Sub
    Private Sub SaveData()

        strSQL = "Select Id,TransDate,Transactions,Chkno,Payee,Category,Memos,Amount,Balance,Clear,Documentation FROM Banking ORDER BY Id;"
        dbDataSet_Misc.Clear()
        dbDataSet_Misc.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter_Misc.Fill(dbDataSet_Misc, "Checks")
        gbl_DstConnect.Close()

        'Retreive balance & selected category 
        Dim BankBalance As Double = dbDataSet_Misc.Tables("Checks").Rows(dbDataSet_Misc.Tables("Checks").Rows.Count - 1).Item(8) 'Was As Single
        Dim rButton As RadioButton = fra_TaxCategory.Controls.OfType(Of RadioButton)().FirstOrDefault(Function(r) r.Checked = True)
        CheckTotal = Math.Round(CheckTotal, 2, MidpointRounding.AwayFromZero) 'Round amount to two decimal places

        'Create documentation string if check has documentation
        Dim txt_Documentation As String = ""
        If fra_Documentation.Visible = True Then
            For i = 0 To 3
                txt_Documentation = txt_Documentation & "(" & lbl_DocItem(i).Text & ") Date " & tbox_DocInvoDate(i).Text & " , Invoice No " & tbox_DocInvoNum(i).Text & " , Amt " & lbl_DocAmt(i).Text & " - " & tbox_DocDiscount(i).Text & "% = " & lbl_DocPaidAmt(i).Text
                If i < 3 Then
                    If lbl_DocItem(i + 1).Visible = True Then txt_Documentation = txt_Documentation & "   " Else Exit For
                End If
            Next
        End If

        'Save new check data to database
        Dim cb0 As New OleDb.OleDbCommandBuilder(dbAdapter_Misc)
        Dim dsNewRow As DataRow
        dsNewRow = dbDataSet_Misc.Tables("Checks").NewRow()
        If tbox_Date.Text = "  /  /" Then dsNewRow.Item("TransDate") = DBNull.Value Else dsNewRow.Item("TransDate") = tbox_Date.Text
        dsNewRow.Item("Transactions") = "Check"
        dsNewRow.Item("Chkno") = Trim(lbl_CheckNumber.Text)
        dsNewRow.Item("Payee") = Trim(tbox_Payto.Text)
        dsNewRow.Item("Category") = rButton.Text
        dsNewRow.Item("Memos") = Trim(tbox_Memo.Text)
        dsNewRow.Item("Amount") = CheckTotal
        dsNewRow.Item("Balance") = BankBalance - CheckTotal
        dsNewRow.Item("Clear") = False
        If fra_Documentation.Visible = True Then dsNewRow.Item("Documentation") = txt_Documentation
        dbDataSet_Misc.Tables("Checks").Rows.Add(dsNewRow)
        dbAdapter_Misc.Update(dbDataSet_Misc, "Checks")
        cb0 = Nothing
      
        'Update system table
        Dim cb1 As New OleDb.OleDbCommandBuilder(dbAdapter_SystemData)
        dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(6) = Trim(lbl_CheckNumber.Text)
        dbAdapter_SystemData.Update(dbDataSet_SystemData, "SystemData")
        cb1 = Nothing

        'Update payee data
        strSQL = "SELECT Id,Payto,Address,City,State,ZipCode,Category FROM CheckPayee"
        If ListSelect <> 0 Then strSQL = strSQL & " WHERE Id = " & ListSelect & ";"
        dbDataSet.Clear()
        dbDataSet.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter.Fill(dbDataSet, "Update")
        gbl_DstConnect.Close()

        Dim cb2 As New OleDb.OleDbCommandBuilder(dbAdapter)
        If ListSelect <> 0 Then 'Update existing payee
            dbDataSet.Tables("Update").Rows(0).Item(1) = StrConv(Trim(tbox_Payto.Text), VbStrConv.ProperCase)
            dbDataSet.Tables("Update").Rows(0).Item(2) = StrConv(Trim(tbox_Street.Text), VbStrConv.ProperCase)
            dbDataSet.Tables("Update").Rows(0).Item(3) = StrConv(Trim(tbox_City.Text), VbStrConv.ProperCase)
            dbDataSet.Tables("Update").Rows(0).Item(4) = StrConv(Trim(tbox_State.Text), VbStrConv.ProperCase)
            dbDataSet.Tables("Update").Rows(0).Item(5) = Trim(tbox_ZipCode.Text)
            dbDataSet.Tables("Update").Rows(0).Item(6) = rButton.TabIndex
        Else 'Add new payee entry
            dsNewRow = dbDataSet.Tables("Update").NewRow()
            dsNewRow.Item("Payto") = StrConv(Trim(tbox_Payto.Text), VbStrConv.ProperCase)
            dsNewRow.Item("Address") = StrConv(Trim(tbox_Street.Text), VbStrConv.ProperCase)
            dsNewRow.Item("City") = StrConv(Trim(tbox_City.Text), VbStrConv.ProperCase)
            dsNewRow.Item("State") = StrConv(Trim(tbox_State.Text), VbStrConv.ProperCase)
            dsNewRow.Item("ZipCode") = Trim(tbox_ZipCode.Text)
            dsNewRow.Item("Category") = rButton.TabIndex
            dbDataSet.Tables("Update").Rows.Add(dsNewRow)
        End If
        dbAdapter.Update(dbDataSet, "Update")
        cb2 = Nothing
        ListSelect = 0

        'Update datagridview1
        Dim dt As DataTable = DirectCast(frm_Checkbook.DataGridView1.DataSource, DataTable)
        dt.Rows.Add(tbox_Date.Text, "Check", Trim(lbl_CheckNumber.Text), Trim(tbox_Payto.Text), rButton.Text, Trim(tbox_Memo.Text), CheckTotal, BankBalance - CheckTotal, False)
        frm_Checkbook.DataGridView1.FirstDisplayedScrollingRowIndex = frm_Checkbook.DataGridView1.FirstDisplayedScrollingRowIndex + 1

        'Reset form for new check entry
        cmd_Clear.PerformClick()
        CheckNumber = CheckNumber + 1
        lbl_CheckNumber.Text = CheckNumber
        CheckTotal = 0
        If fra_Documentation.Visible = True Then
            For i = 0 To 3
                tbox_DocInvoNum(i).Text = ""
                tbox_DocInvoDate(i).Text = ""
                lbl_DocAmt(i).Text = ""
                lbl_DocPaidAmt(i).Text = ""
                tbox_DocDiscount(i).Text = ""
                If i > 0 Then
                    lbl_DocItem(i).Visible = False
                    tbox_DocInvoNum(i).Visible = False
                    tbox_DocInvoDate(i).Visible = False
                    lbl_DocAmt(i).Visible = False
                    lbl_DocPaidAmt(i).Visible = False
                    tbox_DocDiscount(i).Visible = False
                End If
            Next
        End If
        For i = 0 To 3
            tbox_ChkAmt(i).Text = ""
            If i > 0 Then
                lbl_ChkAmt(i).Visible = False
                tbox_ChkAmt(i).Visible = False
            End If
        Next
        cmd_Action.Text = "Next"

        fra_Documentation.Visible = False
    End Sub


    'Print Related 
    Private Sub Printer_MsgBox(intSelect As Integer)
        Select Case intSelect
            Case 0
                lbl_Message1.Text = "*  *  *  D O C U M E N T A T I O N  *  *  *"
                lbl_Message2.Text = "Will this check need documentation"
                cmd_Action1.Text = "Yes"
                cmd_Action2.Text = "No"
            Case 1
                lbl_Message1.Text = "*  *  *  P R I N T E R  S E T U P  *  *  *"
                lbl_Message2.Text = "Load checks in printer and press [OK] when ready"
                cmd_Action1.Text = "OK"
                cmd_Action2.Text = "Cancel"
            Case 2
                lbl_Message1.Text = "*  *  *  P R I N T  F A I L U R E  *  *  *"
                lbl_Message2.Text = "Correct issue with printer and press [OK] when ready"
                cmd_Action1.Text = "OK"
                cmd_Action2.Text = "Cancel"
            Case 3
                lbl_Message1.Text = "*  *  *  P R I N T  V E R I F I C A T I O N  *  *  *"
                lbl_Message2.Text = "Did the check print properly"
                cmd_Action1.Text = "Yes"
                cmd_Action2.Text = "No"
        End Select
        Print_MsgBox_Enable(False)
        Panel_MsgBox.Visible = True 'Show message box
    End Sub
    Private Sub cmd_Printer_Click(sender As Object, e As EventArgs) Handles cmd_Action1.Click, cmd_Action2.Click
        Panel_MsgBox.Visible = False
        Print_MsgBox_Enable(True)
        Application.DoEvents() 'Wait for all process to complete before proceeding

        Select Case sender.text
            Case "OK"
                prnDocument = New PrintDocument
                prnDocument.Print()

            Case "Yes"
                Select Case lbl_Message1.Text
                    Case "*  *  *  D O C U M E N T A T I O N  *  *  *"
                        lbl_DocAmt(0).Text = tbox_ChkAmt(0).Text
                        lbl_DocPaidAmt(0).Text = tbox_ChkAmt(0).Text
                        For i = 1 To 3
                            If tbox_ChkAmt(i).Text <> "" Then
                                lbl_DocItem(i).Visible = True
                                tbox_DocInvoNum(i).Visible = True
                                tbox_DocInvoDate(i).Visible = True
                                lbl_DocAmt(i).Visible = True
                                lbl_DocAmt(i).Text = tbox_ChkAmt(i).Text
                                lbl_DocPaidAmt(i).Visible = True
                                lbl_DocPaidAmt(i).Text = tbox_ChkAmt(i).Text
                                tbox_DocDiscount(i).Visible = True
                            Else
                                Exit For
                            End If
                        Next
                        fra_Documentation.Visible = True
                        tbox_DocInvoNum(0).Focus()
                        cmd_Action.Text = "Print"

                    Case "*  *  *  P R I N T  V E R I F I C A T I O N  *  *  *"
                        Call SaveData()
                End Select

            Case "No"
                Select Case lbl_Message1.Text
                    Case "*  *  *  D O C U M E N T A T I O N  *  *  *"
                        If booPrint = False Then
                            booPrint = True
                            Printer_MsgBox(1) '"Load checks in printer and press [OK] when ready"
                        Else
                            cmd_Action.Text = "Print"
                        End If

                    Case "*  *  *  P R I N T  V E R I F I C A T I O N  *  *  *"
                        Printer_MsgBox(2) '"Correct issue with printer and press [OK] when ready"

                End Select
        End Select
    End Sub
    Private Sub prnDocument_EndPrint(sender As Object, e As EventArgs) Handles prnDocument.EndPrint
        Printer_MsgBox(3) '"Did the check print properly"
    End Sub
    Private Sub prnDocument_PrintPage(sender As Object, e As PrintPageEventArgs) Handles prnDocument.PrintPage 'remove 1 at end of printform1

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

        Font = New Font("Arial", 9, FontStyle.Bold)
        Using the_pen As New Pen(Color.Black, 1)

            'Print upper form section graphics
            If fra_Documentation.Visible = True Then
                CurrentY = HardY1 + 35
                points = {New Point(HardX1, CurrentY), New Point(HardX2, CurrentY)} '1st upper horizontal Line
                e.Graphics.DrawLines(the_pen, points)

                points = {New Point(HardX1, CurrentY + 26), New Point(HardX2, CurrentY + 26)} '2nd upper horizontal Line
                e.Graphics.DrawLines(the_pen, points)

                CurrentX = HardX1 + 32
                points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 160)} '1st upper vertical Line
                e.Graphics.DrawLines(the_pen, points)

                Text = "Invoice Number"
                TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                TextX = CurrentX + (126 - TextLen) / 2
                TextY = CurrentY + 5
                e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY) 'Print label Invoice Number

                CurrentX = HardX1 + 158
                points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 160)} '2nd upper vertical Line
                e.Graphics.DrawLines(the_pen, points)

                Text = "Invoice Date"
                TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                TextX = CurrentX + (106 - TextLen) / 2
                e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY) 'Print label Invoice Date

                CurrentX = HardX1 + 264
                points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 160)} '3rd upper vertical Line
                e.Graphics.DrawLines(the_pen, points)

                Text = "Invoice Amount"
                TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                TextX = CurrentX + (126 - TextLen) / 2
                e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY) 'Print label Invoice Amount

                CurrentX = HardX1 + 390
                points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 160)} '4th upper vertical Line
                e.Graphics.DrawLines(the_pen, points)

                Text = "Amount Paid"
                TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                TextX = CurrentX + (109 - TextLen) / 2
                e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY) 'Print label Amount Paid

                CurrentX = HardX1 + 499
                points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 160)} '5th upper vertical Line
                e.Graphics.DrawLines(the_pen, points)

                Text = "Discount Taken"
                TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                TextX = CurrentX + (126 - TextLen) / 2
                e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY) 'Print label Discount Taken

                CurrentX = HardX1 + 625
                points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 160)} '6th upper vertical Line
                e.Graphics.DrawLines(the_pen, points)

                Text = "Net Check Amount"
                TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                TextX = CurrentX + (145 - TextLen) / 2
                e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY) 'Print label Net Check Amount

                CurrentX = HardX1 + 770
                points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 160)} '7th upper vertical line
                e.Graphics.DrawLines(the_pen, points)

                'Print lower form section graphics
                CurrentY = HardY1 + 735
                points = {New Point(HardX1, CurrentY), New Point(HardX2, CurrentY)} '1st lower horizontal Line
                e.Graphics.DrawLines(the_pen, points)

                points = {New Point(HardX1, CurrentY + 26), New Point(HardX2, CurrentY + 26)} '2nd lower horizontal Line
                e.Graphics.DrawLines(the_pen, points)

                CurrentX = HardX1 + 32
                points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 125)} '1st lower vertical Line
                e.Graphics.DrawLines(the_pen, points)

                Text = "Invoice Number"
                TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                TextX = CurrentX + (126 - TextLen) / 2
                TextY = CurrentY + 5
                e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY) 'Print label Invoice Number

                CurrentX = HardX1 + 158
                points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 125)} '2nd lower vertical Line
                e.Graphics.DrawLines(the_pen, points)

                Text = "Invoice Date"
                TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                TextX = CurrentX + (106 - TextLen) / 2
                e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY) 'Print label Invoice Date

                CurrentX = HardX1 + 264
                points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 125)} '3rd lower vertical Line
                e.Graphics.DrawLines(the_pen, points)

                Text = "Invoice Amount"
                TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                TextX = CurrentX + (126 - TextLen) / 2
                e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY) 'Print label Invoice Amount

                CurrentX = HardX1 + 390
                points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 125)} '4th lower vertical Line
                e.Graphics.DrawLines(the_pen, points)

                Text = "Amount Paid"
                TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                TextX = CurrentX + (109 - TextLen) / 2
                e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY) 'Print label Amount Paid

                CurrentX = HardX1 + 499
                points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 125)} '5th lower vertical Line
                e.Graphics.DrawLines(the_pen, points)

                Text = "Discount Taken"
                TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                TextX = CurrentX + (126 - TextLen) / 2
                e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY) 'Print label Discount Taken

                CurrentX = HardX1 + 625
                points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 125)} '6th lower vertical Line
                e.Graphics.DrawLines(the_pen, points)

                Text = "Net Check Amount"
                TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                TextX = CurrentX + (145 - TextLen) / 2
                e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY) 'Print label Net Check Amount

                CurrentX = HardX1 + 770
                points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 125)} '7th lower vertical line
                e.Graphics.DrawLines(the_pen, points)
            End If

            CurrentX = HardX1 + 150
            Text = "Check No.:"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX - TextLen
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, HardY1 + 885) 'Print label Check No.

            Text = "Check Date:"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX - TextLen
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, HardY1 + 900) 'Print label Check Date

            Text = "Check Amount:"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX - TextLen
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, HardY1 + 915) 'Print label Check Amount

            Text = "To The"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX - TextLen
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, HardY1 + 945) 'Print label To The

            Text = "Order"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, HardY1 + 960) 'Print label Order

            Text = "Of"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, HardY1 + 975) 'Print label Of

        End Using 'the_pen 

        'Calculate check count and check amount total
        CheckCount = 0
        For i = 0 To 3
            If tbox_ChkAmt(i).Text <> "" Then
                CheckCount = i
                If fra_Documentation.Visible = False Then CheckTotal = CheckTotal + tbox_ChkAmt(i).Text Else CheckTotal = CheckTotal + lbl_DocPaidAmt(i).Text()
            Else : Exit For : End If
        Next

        'Fill upper form section with data
        Text = "Check No. " & lbl_CheckNumber.Text 'Print Check with check number
        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
        TextX = HardX2 - (60 + TextLen)
        e.Graphics.DrawString(Text, Font, BlackBrush, TextX, HardY1 + 8)

        CurrentY = HardY1 + 68
        Font = New Font("Ariel", 9, FontStyle.Regular)

        If fra_Documentation.Visible = True Then
            For intStep = 0 To CheckCount

                'Print Invoice number
                Text = tbox_DocInvoNum(intStep).Text
                TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 32 + (126 - TextLen) / 2, CurrentY)

                'Print invoice date
                Text = tbox_DocInvoDate(intStep).Text
                TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 158 + (106 - TextLen) / 2, CurrentY)

                'Print invoice amount
                Text = lbl_DocAmt(intStep).Text
                TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 264 + (126 - TextLen) / 2, CurrentY)

                'Print amount paid
                Text = lbl_DocPaidAmt(intStep).Text
                TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 390 + (109 - TextLen) / 2, CurrentY)

                'Print discount taken
                Text = tbox_DocDiscount(intStep).Text
                TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 499 + (126 - TextLen) / 2, CurrentY)

                'Print net check amount
                Text = lbl_DocPaidAmt(intStep).Text
                TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 625 + (145 - TextLen) / 2, CurrentY)

                If intStep < 3 Then If lbl_DocItem(intStep + 1).Visible = False Then Exit For
                CurrentY = CurrentY + 20
            Next
        End If

        'Fill middle form section with data
        Font = New Font("Ariel", 14, FontStyle.Bold)
        Text = lbl_CheckNumber.Text  'Print check number
        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
        TextX = HardX2 - (65 + TextLen)
        e.Graphics.DrawString(Text, Font, BlackBrush, TextX, HardY1 + 354) 'HardY1 + 342)

        'Print date
        Font = New Font("Ariel", 9, FontStyle.Bold)
        Text = tbox_Date.Text
        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 650 - (TextLen / 2), HardY1 + 427) '662

        Dim CheckWords As String = NumWords(Convert.ToString(CheckTotal)) 'Convert check amount into words
        e.Graphics.DrawString(CheckWords, Font, BlackBrush, HardX1 + 40, HardY1 + 488)

        'Print amount (numeric)
        Text = FormatCurrency(CheckTotal)
        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 710 - (TextLen / 2), HardY1 + 487) '722

        'Print payto line 1
        Text = tbox_Payto.Text
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 65, HardY1 + 549)

        'Print payto line 1
        Text = tbox_Street.Text
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 65, HardY1 + 564)

        'Print payto line 1
        Text = tbox_City.Text & " " & tbox_State.Text & " " & tbox_ZipCode.Text
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 65, HardY1 + 579)

        'Fill lower form section with data
        Text = "Check No. " & lbl_CheckNumber.Text 'Print Check with check number
        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
        TextX = HardX2 - (60 + TextLen)
        e.Graphics.DrawString(Text, Font, BlackBrush, TextX, HardY1 + 708)

        CurrentY = HardY1 + 772
        Font = New Font("Ariel", 9, FontStyle.Regular)

        If fra_Documentation.Visible = True Then
            For intStep = 0 To CheckCount
                'Print Invoice number
                Text = tbox_DocInvoNum(intStep).Text
                TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 32 + (126 - TextLen) / 2, CurrentY)

                'Print invoice date
                Text = tbox_DocInvoDate(intStep).Text
                TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 158 + (106 - TextLen) / 2, CurrentY)

                'Print invoice amount
                Text = lbl_DocAmt(intStep).Text
                TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 264 + (126 - TextLen) / 2, CurrentY)

                'Print amount paid
                Text = lbl_DocPaidAmt(intStep).Text
                TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 390 + (109 - TextLen) / 2, CurrentY)

                'Print discount taken
                Text = tbox_DocDiscount(intStep).Text
                TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 499 + (126 - TextLen) / 2, CurrentY)

                'Print net check amount
                Text = lbl_DocPaidAmt(intStep).Text
                TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 625 + (145 - TextLen) / 2, CurrentY)
                CurrentY = CurrentY + 20
            Next
        End If

        CurrentX = HardX1 + 155
        Text = lbl_CheckNumber.Text
        e.Graphics.DrawString(Text, Font, BlackBrush, CurrentX, HardY1 + 885)

        Text = tbox_Date.Text
        e.Graphics.DrawString(Text, Font, BlackBrush, CurrentX, HardY1 + 900)

        Text = FormatCurrency(CheckTotal) & "    " & CheckWords
        e.Graphics.DrawString(Text, Font, BlackBrush, CurrentX, HardY1 + 915)

        Text = tbox_Payto.Text
        e.Graphics.DrawString(Text, Font, BlackBrush, CurrentX, HardY1 + 945)

        Text = tbox_Street.Text
        e.Graphics.DrawString(Text, Font, BlackBrush, CurrentX, HardY1 + 960)

        Text = tbox_City.Text & " " & tbox_State.Text & " " & tbox_ZipCode.Text
        e.Graphics.DrawString(Text, Font, BlackBrush, CurrentX, HardY1 + 975)

        e.HasMorePages = False
    End Sub
    Private Sub Print_MsgBox_Enable(blnStatus As Boolean)
        fra_TaxCategory.Enabled = blnStatus
        fra_Documentation.Enabled = blnStatus
        cmd_Clear.Enabled = blnStatus
        If blnStatus = False Then blnStatus = True Else blnStatus = False
        tbox_Date.ReadOnly = blnStatus
        tbox_Payto.ReadOnly = blnStatus
        tbox_Street.ReadOnly = blnStatus
        tbox_State.ReadOnly = blnStatus
        tbox_City.ReadOnly = blnStatus
        tbox_State.ReadOnly = blnStatus
        tbox_ZipCode.ReadOnly = blnStatus
        tbox_Memo.ReadOnly = blnStatus
        For i = 0 To 3
            tbox_ChkAmt(i).ReadOnly = blnStatus
        Next

    End Sub


    'All texbox handlers
    Private Sub tbox_GotFocus(sender As Object, e As EventArgs) Handles tbox_Date.GotFocus, tbox_Payto.GotFocus, tbox_Street.GotFocus, tbox_City.GotFocus, tbox_State.GotFocus, tbox_City.GotFocus, tbox_State.GotFocus, tbox_ZipCode.GotFocus, tbox_Memo.GotFocus
        strInitEntry = Trim(sender.Text)
        Select Case sender.name
            Case "tbox_DocInvoNum", "tbox_DocInvoDate", "tbox_DocDiscount"
                sender.backcolor = Color.LightCyan
            Case Else
                sender.BackColor = Color.FromArgb(255, 255, 192)
        End Select
    End Sub
    Private Sub tbox_lostFocus(sender As Object, e As EventArgs) Handles tbox_Date.LostFocus, tbox_Payto.LostFocus, tbox_Street.LostFocus, tbox_City.LostFocus, tbox_State.LostFocus, tbox_ZipCode.LostFocus, tbox_Memo.LostFocus
        If booCorrection = True Then sender.BackColor = Color.White : Exit Sub
        Select Case sender.name
            Case "tbox_Date", "tbox_DocInvoDate"
                If IsDate(sender.Text) = False And sender.Text <> "  /  /" Then
                    sender.BackColor = Color.Aqua
                    booCorrection = True
                    frm_Message.Text = "15:1:0:1:3:The date entered is not valid, Please enter a valid date"
                    frm_Message.ShowDialog()
                    sender.text = ""
                    sender.Focus()
                    booCorrection = False
                    Exit Sub
                End If
            Case "tbox_ChkAmt", "tbox_DocDiscount"
                If sender.text <> "" Then
                    Dim DocPaidAmt As Double
                    If Not IsNumeric(sender.Text) Then
                        booCorrection = True
                        frm_Message.Text = "15:1:0:1:3:Invalid Entry --- Numerical entries are only allowed"
                        frm_Message.ShowDialog()
                        sender.text = ""
                        sender.Focus()
                        booCorrection = False
                        Exit Sub
                    End If
                    If sender.name = "tbox_ChkAmt" Then
                        sender.Text = FormatCurrency(sender.Text)
                        If fra_Documentation.Visible = True Then
                            lbl_DocAmt(sender.tag).Text = tbox_ChkAmt(sender.tag).Text
                            If tbox_DocDiscount(sender.tag).Text <> 0 Then
                                DocPaidAmt = lbl_DocAmt(sender.tag).Text - ((lbl_DocAmt(sender.tag).Text / 100) * tbox_DocDiscount(sender.tag).Text)
                                lbl_DocPaidAmt(sender.tag).Text = FormatCurrency(Math.Round(DocPaidAmt, 2, MidpointRounding.AwayFromZero)) 'Round amount to two decimal places
                            End If
                        End If
                        If sender.tag < 3 Then
                            lbl_ChkAmt(sender.tag + 1).Visible = True
                            tbox_ChkAmt(sender.tag + 1).Visible = True
                            tbox_ChkAmt(sender.tag + 1).Focus()
                        End If
                    Else
                        If tbox_DocDiscount(sender.tag).Text <> strInitEntry Then
                            tbox_DocDiscount(sender.tag).Text = FormatNumber(tbox_DocDiscount(sender.tag).Text, 1, TriState.True)
                            DocPaidAmt = lbl_DocAmt(sender.tag).Text - ((lbl_DocAmt(sender.tag).Text / 100) * tbox_DocDiscount(sender.tag).Text)
                            lbl_DocPaidAmt(sender.tag).Text = FormatCurrency(Math.Round(DocPaidAmt, 2, MidpointRounding.AwayFromZero)) 'Round amount to two decimal places
                        End If
                    End If
                End If

            Case "tbox_State"
                If AlphaNumeric(sender.text) = False Then
                    booCorrection = True
                    frm_Message.Text = "15:1:0:1:3:Invalid Entry --- Only letters allow for state abbreviations"
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
        sender.BackColor = Color.White
    End Sub
    Private Sub tbox_TextChanged(sender As Object, e As EventArgs) Handles tbox_Date.TextChanged, tbox_Payto.TextChanged, tbox_Street.TextChanged, tbox_City.TextChanged, tbox_ZipCode.TextChanged, tbox_Memo.TextChanged
        If booDataChecked = True Then Exit Sub 'Skip if pre_processed data
        Select Case sender.Name
            Case "tbox_Payto", "tbox_City", "tbox_State"
                If Trim(sender.Text) <> "" Then 'Capitalize first letter of entry
                    booDataChecked = True
                    If Len(Trim(sender.Text)) = 1 Then
                        sender.Text = StrConv(Trim(sender.Text), vbUpperCase)
                        sender.SelectionStart = 2
                    End If
                    booDataChecked = False
                End If
                If sender.name = "tbox_Payto" Then

                    'Clear listboxes
                    strSQL = "SELECT Id,Payto,Address,City,State,ZipCode,Category FROM CheckPayee WHERE Payto LIKE '" & Trim(tbox_Payto.Text) & "%" & "' ORDER BY Payto;"
                    dbDataSet.Clear()
                    dbDataSet.Tables.Clear()
                    gbl_DstConnect.Open()
                    dbAdapter = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
                    dbAdapter.Fill(dbDataSet, "CheckName")
                    gbl_DstConnect.Close()
                    If dbDataSet.Tables("CheckName").Rows.Count >= 1 Then 'Records found  
                        ReDim listArray(dbDataSet.Tables("CheckName").Rows.Count - 1)
                        If booListbox = False Then ListboxShow(True)
                        Listbox_Payto.Items.Clear()

                        Dim num As Integer
                        For num = 0 To dbDataSet.Tables("CheckName").Rows.Count - 1
                            listArray(num) = dbDataSet.Tables("CheckName").Rows(num).Item(0)
                            Listbox_Payto.Items.Add(dbDataSet.Tables("CheckName").Rows(num).Item(1))
                        Next
                        If num > 7 Then num = 7
                        Listbox_Payto.Height = num * 24
                    Else
                        ListboxShow(False)
                    End If
                End If
        End Select
    End Sub
    Private Sub tbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbox_Date.KeyPress, tbox_Payto.KeyPress, tbox_Street.KeyPress, tbox_City.KeyPress, tbox_State.KeyPress, tbox_ZipCode.KeyPress, tbox_Memo.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            Select Case sender.Name
                Case "tbox_Date" : tbox_Payto.Focus()
                Case "tbox_Payto" : tbox_Street.Focus()
                Case "tbox_Street" : tbox_City.Focus()
                Case "tbox_City" : tbox_State.Focus()
                Case "tbox_State" : tbox_ZipCode.Focus()
                Case "tbox_ZipCode" : tbox_Memo.Focus()
                Case "tbox_Memo" : tbox_ChkAmt(0).Focus()
                Case "tbox_ChkAmt"
                    Select Case sender.tag
                        Case 0 : If tbox_ChkAmt(1).Visible = True Then tbox_ChkAmt(1).Focus() Else tbox_Date.Focus()
                        Case 1 : If tbox_ChkAmt(2).Visible = True Then tbox_ChkAmt(2).Focus() Else tbox_Date.Focus()
                        Case 2 : If tbox_ChkAmt(3).Visible = True Then tbox_ChkAmt(3).Focus() Else tbox_Date.Focus()
                        Case 3 : tbox_Date.Focus()
                    End Select
                Case "tbox_DocInvoNum" : tbox_DocInvoDate(sender.tag).Focus()
                Case "tbox_DocInvoDate" : tbox_DocDiscount(sender.tag).Focus()
                Case "tbox_DocDiscount"                   
                    If sender.tag < 3 Then
                        If lbl_DocItem(sender.tag + 1).Visible = True Then tbox_DocInvoNum(sender.tag + 1).Focus() Else tbox_DocInvoNum(0).Focus()
                    Else : tbox_DocInvoNum(0).Focus() : End If
            End Select
        End If
    End Sub
    Private Sub tbox_KeyDown(sender As Object, e As KeyEventArgs) Handles tbox_Payto.KeyDown
        If e.KeyCode = Keys.Enter And Listbox_Payto.Items.Count = 1 Then
            Listbox_Payto.SetSelected(0, True)
            Call Listbox_Payto_DoubleClick()
        End If
    End Sub
    Private Sub tbox_MouseClick(sender As Object, e As MouseEventArgs) Handles tbox_ZipCode.MouseClick
        If sender.text = "  /  /" Or sender.Text = "     -" Or sender.text = "" Then sender.SelectionStart = 0
    End Sub

End Class