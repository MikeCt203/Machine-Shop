Public Class frm_Deposits_ATM
    Dim dbAdapter, dbAdapter_Misc As OleDb.OleDbDataAdapter
    Dim dbDataSet, dbDataSet_Misc As New DataSet
    Dim strSQL As String
    Dim intAlarm, ListSelect, ActiveRow, row, CategoryCount, LineCount As Integer
    Dim booCorrection, booDataChecked, booListbox As Boolean
    Dim strInitEntry, sendername As String

    Dim lbl_No(11) As Label
    Dim tbox_TransactionName(11) As TextBox
    Dim tbox_Category(11) As TextBox
    Dim tbox_Amount(11) As TextBox
    Dim tbox_Memo(11) As TextBox
    Dim opt_Category(17) As RadioButton

    'Form sub routines
    Private Sub frm_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated
        If Me.Text = "Deposits" Then LineCount = 11 Else LineCount = 8
        Call AddControls()
    End Sub
    Private Sub frm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim strCity, strState, strZipCode As String
        Me.Size = New Size(862, 572)
        Me.Left = frm_Checkbook.Left + 24
        Me.Top = frm_Checkbook.Top + 46

        'Retrieve system variables
        lbl_HeaderName.Text = dbDataSet_System.Tables("System").Rows(0).Item(1) 'Company Name
        lbl_HeaderAddress.Text = dbDataSet_System.Tables("System").Rows(0).Item(2) 'Company Address
        strCity = dbDataSet_System.Tables("System").Rows(0).Item(3) 'Company City
        strState = dbDataSet_System.Tables("System").Rows(0).Item(4) 'Company State
        strZipCode = dbDataSet_System.Tables("System").Rows(0).Item(5) 'Company ZipCode
        lbl_HeaderCity.Text = strCity & ", " & strState & ", " & strZipCode
        lbl_HeaderPhone.Text = dbDataSet_System.Tables("System").Rows(0).Item(6) 'Company Phone

        booDataChecked = True
        tbox_Date.Text = Format(Today, "MM/dd/yyyy")
        If Me.Text = "Deposits" Then
            lbl_TransactionName.Text = "Received From"
            lbl_Category.Visible = False
            lbl_LineNo.SetBounds(20, 20, 34, 18)
            lbl_TransactionName.SetBounds(75, 20, 280, 18) '54
            lbl_Memo.SetBounds(385, 20, 185, 18)
            lbl_Amount.SetBounds(600, 20, 80, 18)
            lbl_Total.SetBounds(708, 20, 84, 18)
            lbl_TotalValue.SetBounds(708, 20, 84, 18)
            ListBox_Names.SetBounds(75, 20, 280, 18)
            fra_Transaction.Height = 391
            lbl_TaxCategoryTop.Visible = False
            fra_TaxCategory.Visible = False
        Else
            lbl_TransactionName.Text = "Creditor Name"
            lbl_LineNo.SetBounds(10, 20, 34, 18)
            lbl_TransactionName.SetBounds(54, 20, 220, 18)
            lbl_Category.SetBounds(291, 20, 110, 18)
            lbl_Memo.SetBounds(419, 20, 185, 18)
            lbl_Amount.SetBounds(621, 20, 80, 18)
            lbl_Total.SetBounds(718, 20, 84, 18)
            lbl_TotalValue.SetBounds(718, 42, 84, 18)
            ListBox_Names.SetBounds(54, 20, 220, 24)
            fra_Transaction.Height = 301

            strSQL = "SELECT Category FROM Tax_Categorys ORDER BY Id;"
            dbDataSet_Misc.Clear()
            dbDataSet_Misc.Tables.Clear()
            gbl_DstConnect.Open()
            dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
            dbAdapter_Misc.Fill(dbDataSet_Misc, "Category")
            gbl_DstConnect.Close()
            If dbDataSet_Misc.Tables("Category").Rows.Count <> 0 Then 'Records found  
                For i = 0 To 17
                    opt_Category(i).Text = dbDataSet_Misc.Tables("Category").Rows(i).Item(0)
                Next
            Else
                MessageArray(0) = 205
                frm_Message.ShowDialog()
                Me.Close()
                Exit Sub
            End If
        End If
        row = 0
        booDataChecked = False
        booListbox = False
        tbox_Date.Focus()

    End Sub
    Private Sub Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        dbDataSet.Clear()
        dbDataSet.Tables.Clear()
        dbDataSet_Misc.Clear()
        dbDataSet_Misc.Tables.Clear()
        Me.Dispose()
    End Sub
    Private Sub AddControls() 'Add amount controls
        Dim i, int_Top, int_Left As Integer

        'Create array of controls ( Documentation frame )
        int_Top = 15
        For i = 0 To LineCount
            int_Top = int_Top + 27
            lbl_No(i) = New Label
            tbox_TransactionName(i) = New TextBox
            If Me.Text = "ATM Withdrawls" Then tbox_Category(i) = New TextBox
            tbox_Memo(i) = New TextBox
            tbox_Amount(i) = New TextBox

            With lbl_No(i)
                .Name = "lbl_No"
                .Tag = i
                .Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Text = i + 1
                If i = 0 Then .Visible = True Else .Visible = False
                If Me.Text = "Deposits" Then .SetBounds(20, int_Top + 2, 34, 24) Else .SetBounds(10, int_Top + 2, 34, 24)
                fra_Transaction.Controls.Add(lbl_No(i))
            End With

            With tbox_TransactionName(i)
                .Name = "tbox_TransactionName"
                .Tag = i
                .Enabled = True
                .BackColor = Color.White
                .BorderStyle = BorderStyle.Fixed3D
                .Font = New Font("Microsoft Sans Serif", 10, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                If i = 0 Then .Visible = True Else .Visible = False
                If Me.Text = "Deposits" Then .SetBounds(75, int_Top, 280, 24) Else .SetBounds(54, int_Top, 220, 24)
                fra_Transaction.Controls.Add(tbox_TransactionName(i))
                AddHandler .GotFocus, AddressOf tbox_GotFocus
                AddHandler .LostFocus, AddressOf tbox_lostFocus
                AddHandler .TextChanged, AddressOf tbox_TextChanged
                AddHandler .KeyPress, AddressOf tbox_KeyPress
                AddHandler .MouseClick, AddressOf tbox_MouseClick
            End With

            If Me.Text = "ATM Withdrawls" Then
                With tbox_Category(i)
                    .Name = "tbox_Category"
                    .Tag = i
                    .Enabled = True
                    .ReadOnly = True
                    .BackColor = Color.White
                    .BorderStyle = BorderStyle.Fixed3D
                    .Font = New Font("Microsoft Sans Serif", 9, FontStyle.Regular)
                    .TextAlign = HorizontalAlignment.Center
                    If i = 0 Then .Visible = True Else .Visible = False
                    .SetBounds(291, int_Top + 1, 110, 24)
                    fra_Transaction.Controls.Add(tbox_Category(i))
                    AddHandler .GotFocus, AddressOf tbox_GotFocus
                    AddHandler .LostFocus, AddressOf tbox_lostFocus
                    AddHandler .KeyPress, AddressOf tbox_KeyPress
                    AddHandler .MouseClick, AddressOf tbox_MouseClick
                End With
            End If

            With tbox_Memo(i)
                .Name = "tbox_Memo"
                .Tag = i
                .Enabled = True
                .BackColor = Color.White
                .BorderStyle = BorderStyle.Fixed3D
                .Font = New Font("Microsoft Sans Serif", 10, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                If i = 0 Then .Visible = True Else .Visible = False
                If Me.Text = "Deposits" Then .SetBounds(383, int_Top, 185, 24) Else .SetBounds(419, int_Top, 185, 24)
                fra_Transaction.Controls.Add(tbox_Memo(i))
                AddHandler .GotFocus, AddressOf tbox_GotFocus
                AddHandler .LostFocus, AddressOf tbox_lostFocus
                AddHandler .TextChanged, AddressOf tbox_TextChanged
                AddHandler .KeyPress, AddressOf tbox_KeyPress
                AddHandler .MouseClick, AddressOf tbox_MouseClick
            End With

            With tbox_Amount(i)
                .Name = "tbox_Amount"
                .Tag = i
                .Enabled = True
                .BackColor = Color.White
                .BorderStyle = BorderStyle.Fixed3D
                .Font = New Font("Microsoft Sans Serif", 10, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                If i = 0 Then .Visible = True Else .Visible = False
                If Me.Text = "Deposits" Then .SetBounds(600, int_Top, 80, 24) Else .SetBounds(621, int_Top, 80, 24)
                fra_Transaction.Controls.Add(tbox_Amount(i))
                AddHandler .GotFocus, AddressOf tbox_GotFocus
                AddHandler .LostFocus, AddressOf tbox_lostFocus
                AddHandler .TextChanged, AddressOf tbox_TextChanged
                AddHandler .KeyPress, AddressOf tbox_KeyPress
                AddHandler .MouseClick, AddressOf tbox_MouseClick
            End With
        Next

        If Me.Text = "ATM Withdrawls" Then
            'Create array of controls ( Category frame)
            int_Left = 21
            int_Top = -10
            For i = 0 To 17
                int_Top = int_Top + 23
                opt_Category(i) = New RadioButton
                With opt_Category(i)
                    .Name = "opt_Category"
                    .Tag = i
                    .Font = New Font("Microsoft Sans Serif", 7.8, FontStyle.Regular)
                    .TextAlign = ContentAlignment.MiddleLeft
                    .BackColor = Color.Cornsilk
                    .SetBounds(int_Left, int_Top, 114, 21)
                    fra_TaxCategory.Controls.Add(opt_Category(i))
                    AddHandler .CheckedChanged, AddressOf RadioButton_CheckedChanged
                    AddHandler .Click, AddressOf RadioButton_Click
                End With
                If int_Top = 59 Then int_Top = -10 : int_Left = int_Left + 136
            Next
        End If
    End Sub
    Private Sub FormEnable(blnStatus As Boolean)
        tbox_Date.Enabled = blnStatus
        For i = 0 To LineCount
            If i <> ActiveRow Then tbox_TransactionName(i).Enabled = blnStatus
            If Me.Text = "ATM Withdrawls" Then tbox_Category(i).Enabled = blnStatus
            tbox_Memo(i).Enabled = blnStatus
            tbox_Amount(i).Enabled = blnStatus
        Next
        cmd_Submit.Enabled = blnStatus
    End Sub
    Private Sub OptionUpdate()
        booDataChecked = True
        If tbox_Category(ActiveRow).Text <> "" Then
            For i = 0 To 17
                If opt_Category(i).Text = tbox_Category(ActiveRow).Text Then opt_Category(i).Checked = True : Exit For
            Next
        Else
            For i = 0 To 17
                opt_Category(i).Checked = False
            Next
        End If
        booDataChecked = False
    End Sub
    Private Sub Save()

        strSQL = "Select Id,TransDate,Transactions,Payee,Category,Memos,Amount,Balance,Clear FROM Banking"
        dbDataSet_Misc.Clear()
        dbDataSet_Misc.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter_Misc.Fill(dbDataSet_Misc, "Transaction")
        gbl_DstConnect.Close()

        'Retreive balance 
        Dim TransAmount, BankBalance As Single
        BankBalance = dbDataSet_Misc.Tables("Transaction").Rows(dbDataSet_Misc.Tables("Transaction").Rows.Count - 1).Item(6)

        For intStep = 0 To LineCount 'Save deposits data to database
            If IsNumeric(tbox_Amount(intStep).Text) Then 'Test for numeric entry
                If tbox_Amount(intStep).Text > 0 Then 'Save only if positive number in amount 
                    Dim cb0 As New OleDb.OleDbCommandBuilder(dbAdapter_Misc)
                    Dim dsNewRow As DataRow
                    dsNewRow = dbDataSet_Misc.Tables("Transaction").NewRow()
                    If tbox_Date.Text = "  /  /" Then dsNewRow.Item("TransDate") = DBNull.Value Else dsNewRow.Item("TransDate") = tbox_Date.Text
                    TransAmount = Convert.ToSingle(Replace(tbox_Amount(intStep).Text, "$", ""))
                    If Me.Text = "Deposits" Then
                        dsNewRow.Item("Transactions") = "Deposit"
                        BankBalance = BankBalance + TransAmount
                    Else
                        dsNewRow.Item("Transactions") = "ATM"
                        dsNewRow.Item("Category") = Trim(tbox_Category(intStep).Text)
                        BankBalance = BankBalance - TransAmount
                    End If
                    dsNewRow.Item("Payee") = Trim(tbox_TransactionName(intStep).Text)
                    dsNewRow.Item("Memos") = Trim(tbox_Memo(intStep).Text)
                    dsNewRow.Item("Amount") = TransAmount
                    dsNewRow.Item("Balance") = BankBalance
                    dsNewRow.Item("Clear") = False
                    dbDataSet_Misc.Tables("Transaction").Rows.Add(dsNewRow)
                    dbAdapter_Misc.Update(dbDataSet_Misc, "Transaction")
                    cb0 = Nothing

                    'Update datagridview1
                    Dim dt As DataTable = DirectCast(frm_Checkbook.DataGridView1.DataSource, DataTable)
                    If Me.Text = "Deposits" Then
                        dt.Rows.Add(tbox_Date.Text, "Deposit", Nothing, Trim(tbox_TransactionName(intStep).Text), Nothing, Trim(tbox_Memo(intStep).Text), TransAmount, BankBalance, False)
                    Else
                        dt.Rows.Add(tbox_Date.Text, "ATM", Nothing, Trim(tbox_TransactionName(intStep).Text), Nothing, Trim(tbox_Memo(intStep).Text), TransAmount, BankBalance, False)
                    End If
                    frm_Checkbook.DataGridView1.FirstDisplayedScrollingRowIndex = frm_Checkbook.DataGridView1.FirstDisplayedScrollingRowIndex + 1
                End If
            End If
        Next
        Me.Close()

    End Sub

    'Action Controls
    Private Sub cmd_Cancel_Click(sender As Object, e As EventArgs) Handles cmd_Cancel.Click
        Me.Close() : Exit Sub
    End Sub
    Private Sub cmd_Submit_Click(sender As Object, e As EventArgs) Handles cmd_Submit.Click

        'Check for complete entries before save
        intAlarm = 0
        Dim booPass As Boolean = False
        For i = 0 To LineCount
            If tbox_Amount(i).Text <> "" Then
                If tbox_TransactionName(i).Text = "" Then intAlarm = 1
            End If
            If tbox_TransactionName(i).Text <> "" Then
                If tbox_Amount(i).Text = "" Then intAlarm = 2
            End If
            If tbox_Amount(i).Text <> "" And tbox_TransactionName(i).Text <> "" Then booPass = True
        Next

        If Me.Text = "Deposits" Then MessageArray(1) = 0 Else MessageArray(1) = 1
        Select Case intAlarm
            Case 0 'Complete data, save 
                If booPass = True Then
                    Call Save()
                Else
                    MessageArray(0) = 202 'No data entered to save
                    frm_Message.ShowDialog()
                End If
            Case 1 'Missing transaction name
                MessageArray(0) = 203
                frm_Message.ShowDialog()
            Case 2 'Missing amount
                MessageArray(0) = 204
                frm_Message.ShowDialog()
        End Select

    End Sub
    Private Sub ListBox_Names_DoubleClick(sender As Object, e As EventArgs) Handles ListBox_Names.DoubleClick
        booDataChecked = True
        tbox_TransactionName(ActiveRow).Text = Strings.StrConv(ListBox_Names.SelectedItem, VbStrConv.ProperCase)
        booDataChecked = False
        ListBox_Names.Visible = False
        FormEnable(True)
        If Me.Text = "Deposits" Then tbox_Amount(ActiveRow).Focus() Else tbox_Category(ActiveRow).Focus()
    End Sub
    Private Sub RadioButton_CheckedChanged(sender As Object, e As EventArgs)
        If booDataChecked = True Then Exit Sub
        tbox_Category(ActiveRow).Text = sender.text
    End Sub
    Private Sub RadioButton_Click(sender As Object, e As EventArgs)
        tbox_Amount(ActiveRow).Focus()
    End Sub
    
    'Textbox Handlers
    Private Sub tbox_GotFocus(sender As Object, e As EventArgs) Handles tbox_Date.GotFocus
        strInitEntry = Trim(sender.Text)
        ActiveRow = sender.tag
        sender.BackColor = Color.FromArgb(255, 255, 192)
    End Sub
    Private Sub tbox_lostFocus(sender As Object, e As EventArgs) Handles tbox_Date.LostFocus
        If booCorrection = True Then sender.BackColor = Color.White : Exit Sub
        Select Case sender.name
            Case "tbox_Date"
                If IsDate(sender.Text) = False And sender.Text <> "  /  /" Then
                    sender.BackColor = Color.Aqua
                    booCorrection = True
                    MessageArray(0) = 200
                    frm_Message.ShowDialog()
                    sender.text = ""
                    sender.Focus()
                    booCorrection = False
                    Exit Sub
                End If
            Case "tbox_Category"
                If tbox_Category(sender.tag).Text = "" Then
                    'ComboBox_Category.DroppedDown = False
                End If
            Case "tbox_Amount"
                If sender.text <> "" Then
                    If Not IsNumeric(sender.Text) Then
                        booCorrection = True
                        MessageArray(0) = 201
                        frm_Message.ShowDialog()
                        sender.text = ""
                        sender.Focus()
                        booCorrection = False
                        Exit Sub
                    End If
                    booDataChecked = True
                    sender.Text = FormatCurrency(sender.Text)
                    booDataChecked = False

                    If sender.tag > row Then row = sender.tag 'Adjust row to the highest used line number
                    Dim Amount, TotalAmount As Double
                    For i = 0 To LineCount
                        If tbox_Amount(i).Text = "" Then Amount = 0 Else Amount = tbox_Amount(i).Text
                        TotalAmount = TotalAmount + Amount
                    Next
                    lbl_TotalValue.Text = FormatCurrency(TotalAmount, 2)
                    lbl_Total.Top = tbox_Amount(row).Top - 22
                    lbl_TotalValue.Top = tbox_Amount(row).Top
                End If
        End Select
        sender.BackColor = Color.White
    End Sub
    Private Sub tbox_TextChanged(sender As Object, e As EventArgs) Handles tbox_Date.TextChanged
        If booDataChecked = True Then Exit Sub 'Skip if pre_processed data
        Select sender.name

            Case "tbox_TransactionName"
                If Trim(sender.Text) <> "" Then 'Capitalize first letter of entry
                    booDataChecked = True
                    If Len(Trim(sender.Text)) = 1 Then
                        sender.Text = StrConv(Trim(sender.Text), vbUpperCase)
                        sender.SelectionStart = 2
                    End If
                    booDataChecked = False
                End If

                'Fill dropdown listbox with proable entries
                If Me.Text = "Deposits" Then
                    strSQL = "SELECT Company FROM Customers WHERE company LIKE '" & Trim(tbox_TransactionName(sender.tag).Text) & "%" & "' ORDER BY Company;"
                Else
                    strSQL = "SELECT Payto FROM CheckPayee WHERE Payto LIKE '" & Trim(tbox_TransactionName(sender.tag).Text) & "%" & "' ORDER BY Payto;"
                End If
                dbDataSet_Misc.Clear()
                dbDataSet_Misc.Tables.Clear()
                gbl_DstConnect.Open()
                dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
                dbAdapter_Misc.Fill(dbDataSet_Misc, "ListboxNames")
                gbl_DstConnect.Close()
                If dbDataSet_Misc.Tables("ListboxNames").Rows.Count >= 1 Then 'Records found  
                    ListBox_Names.Items.Clear()
                    Dim num As Integer
                    For num = 0 To dbDataSet_Misc.Tables("ListboxNames").Rows.Count - 1
                        ListBox_Names.Items.Add(Strings.StrConv(dbDataSet_Misc.Tables("ListboxNames").Rows(num).Item(0), VbStrConv.ProperCase))
                    Next
                    ' ActiveRow = sender.tag
                    ListBox_Names.Top = tbox_TransactionName(sender.tag).Top + 20

                    'Calculate max size listbox dropdown amount for row
                    Dim max As Integer
                        Select Case sender.tag
                        Case 0 : If Me.Text = "Deposits" Then max = 20 Else max = 14
                        Case 1 : If Me.Text = "Deposits" Then max = 19 Else max = 12
                        Case 2 : If Me.Text = "Deposits" Then max = 16 Else max = 10
                        Case 3 : If Me.Text = "Deposits" Then max = 15 Else max = 9
                        Case 4 : If Me.Text = "Deposits" Then max = 13 Else max = 7
                        Case 5 : If Me.Text = "Deposits" Then max = 11 Else max = 5
                        Case 6 : If Me.Text = "Deposits" Then max = 10 Else max = 4
                        Case 7 : If Me.Text = "Deposits" Then max = 8 Else max = 2
                        Case 8 : If Me.Text = "Deposits" Then max = 6 Else max = 1
                        Case 9 : max = 5
                        Case 10 : max = 3
                        Case 11 : max = 1
                    End Select

                    If num > max Then num = max
                    If num = 1 Then ListBox_Names.Height = 21 Else ListBox_Names.Height = 21 + (num * 15)
                    FormEnable(False)
                    ListBox_Names.Visible = True
                Else
                    ListBox_Names.Visible = False
                End If
        End Select
    End Sub
    Private Sub tbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbox_Date.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            Select Case sender.Name
                Case "tbox_Date" : tbox_TransactionName(0).Focus()
                Case "tbox_TransactionName"
                    If Me.Text = "Deposits" Then tbox_Memo(sender.tag).Focus() Else tbox_Category(sender.tag).Focus()
                Case "tbox_Category" : tbox_Memo(sender.tag).Focus()
                Case "tbox_Memo" : tbox_Amount(sender.tag).Focus()
                Case "tbox_Amount"
                    If sender.tag < LineCount And sender.text <> "" Then
                        lbl_No(sender.tag + 1).Visible = True
                        tbox_TransactionName(sender.tag + 1).Visible = True
                        If Me.Text = "ATM Withdrawls" Then tbox_Category(sender.tag + 1).Visible = True
                        tbox_Memo(sender.tag + 1).Visible = True
                        tbox_Amount(sender.tag + 1).Visible = True
                        tbox_TransactionName(sender.tag + 1).Focus()
                        Call OptionUpdate()
                    Else : tbox_Date.Focus() : End If
            End Select
        End If
    End Sub
    Private Sub tbox_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter And ListBox_Names.Items.Count = 1 Then
            ListBox_Names.SetSelected(0, True)
        End If
    End Sub
    Private Sub tbox_MouseClick(sender As Object, e As MouseEventArgs) Handles tbox_Date.MouseClick
        If sender.text = "  /  /" Then sender.SelectionStart = 0
        If sender.name <> "tbox_Date" Then ActiveRow = sender.tag : Call OptionUpdate()
    End Sub
    
End Class