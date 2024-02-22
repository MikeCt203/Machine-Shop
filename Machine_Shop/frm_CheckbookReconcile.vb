Public Class frm_CheckbookReconcile

    Dim dbAdapter_Recon, dbAdapter_Debit, dbAdapter_Credit, dbAdapter_Misc As OleDb.OleDbDataAdapter
    Dim dbDataSet_Recon, dbDataSet_Debit, dbDataSet_Credit, dbDataSet_Misc As New DataSet
    Dim dbDataTable As New DataTable
    Dim strSQL As String

    Dim strInitEntry As String
    Dim StartBalance As Double
    Dim intMessage As Integer
    Dim booDataChecked As Boolean

    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        strSQL = "Select Id,CheckbookReconBalance,CheckbookReconDate FROM System;"
        dbDataSet_Recon.Clear()
        dbDataSet_Recon.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter_Recon = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter_Recon.Fill(dbDataSet_Recon, "Recon")
        gbl_DstConnect.Close()

        If Not IsDBNull(dbDataSet_Recon.Tables("Recon").Rows(0).Item(1)) Then 'Last reconciled balance
            tbox_StartBalance.Text = dbDataSet_Recon.Tables("Recon").Rows(0).Item(1)
        End If

        If Not IsDBNull(dbDataSet_Recon.Tables("Recon").Rows(0).Item(2)) Then 'Date
            Dim NewDate As Date = Format(dbDataSet_Recon.Tables("Recon").Rows(0).Item(2), "MM/dd/yyyy")
            tbox_StatementDate.Text = Format(NewDate.AddMonths(1), "MM/dd/yyyy")
        End If

        fra_Statement1.Visible = True
        cmd_Abort.Visible = False
        cmd_Finish.Visible = False
        Me.Show() 'Wait till form shows before focus set
        tbox_EndBalance.Focus()
    End Sub
    Private Sub Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        dbDataSet_Recon.Clear()
        dbDataSet_Recon.Tables.Clear()
        dbDataSet_Debit.Clear()
        dbDataSet_Debit.Tables.Clear()
        dbDataSet_Credit.Clear()
        dbDataSet_Credit.Tables.Clear()
        dbDataSet_Misc.Clear()
        dbDataSet_Misc.Tables.Clear()
        Me.Dispose()
    End Sub 
    Private Sub ListViewLoad()

        ListView1.SetBounds(15, 40, 493, 500)
        ListView2.SetBounds(525, 40, 493, 500)

        Dim Num As Integer
        Dim obj(6) As String
        Dim itm As ListViewItem

        'Add all Debits to listview1
        strSQL = "Select Id,TransDate,Transactions,Chkno,Payee,Amount,Balance,Clear FROM Banking " _
        & " WHERE (Transactions = '" & "Check" & "' OR Transactions = '" & "ATM" & "' OR Transactions = '" & "Misc Charges" & "') " _
        & " AND Clear = false ORDER BY Id;"

        dbDataSet_Debit.Clear()
        dbDataSet_Debit.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter_Debit = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter_Debit.Fill(dbDataSet_Debit, "Debit")
        gbl_DstConnect.Close()

        If dbDataSet_Debit.Tables("Debit").Rows.Count > 0 Then
            For intstep = 0 To dbDataSet_Debit.Tables("Debit").Rows.Count - 1
                If Not IsDBNull(dbDataSet_Debit.Tables("Debit").Rows(intstep).Item(1)) Then 'Date
                    obj(1) = Format(dbDataSet_Debit.Tables("Debit").Rows(intstep).Item(1), "MM/dd/yyyy")
                End If

                If Not IsDBNull(dbDataSet_Debit.Tables("Debit").Rows(intstep).Item(2)) Then 'Transactions
                    If dbDataSet_Debit.Tables("Debit").Rows(intstep).Item(2) = "ATM" Then obj(2) = "ATM" Else obj(2) = dbDataSet_Debit.Tables("Debit").Rows(intstep).Item(3).ToString 'Chkno or Atm
                Else : obj(2) = "" : End If

                If Not IsDBNull(dbDataSet_Debit.Tables("Debit").Rows(intstep).Item(4)) Then 'Payee
                    obj(3) = dbDataSet_Debit.Tables("Debit").Rows(intstep).Item(4)
                Else : obj(3) = "" : End If

                If Not IsDBNull(dbDataSet_Debit.Tables("Debit").Rows(intstep).Item(5)) Then 'Amount
                    obj(4) = FormatCurrency(dbDataSet_Debit.Tables("Debit").Rows(intstep).Item(5))
                Else : obj(4) = "" : End If
                itm = New ListViewItem(obj)
                ListView1.Items.Add(itm)
            Next
            lbl_DebitItems.Text = dbDataSet_Debit.Tables("Debit").Rows.Count 'Total number of listed debits items
        Else
            lbl_DebitItems.Text = 0
        End If

        'Test for any service charges 
        If tbox_ServiceCharge.Text <> "" Then
            obj(1) = tbox_ServiceDate.Text
            obj(2) = "" 'Chkno or Atm
            obj(3) = "Bank service charge" 'Payee
            obj(4) = tbox_ServiceCharge.Text 'Amount
            itm = New ListViewItem(obj)
            ListView1.Items.Add(itm)
            lbl_DebitItems.Text = lbl_DebitItems.Text + 1
            lbl_SelectedCountDebit.Text = 1
            Num = Convert.ToInt32(lbl_DebitItems.Text) - 1
            ListView1.Items(Num).Checked = True
        End If

        'Credit
        strSQL = "Select Id,TransDate,Transactions,Chkno,Payee,Amount,Balance,Clear FROM Banking " _
        & " WHERE (Transactions = '" & "Deposit" & "' OR Transactions = '" & "Misc Addittions" & "') " _
        & " AND Clear = false ORDER BY Id;"

        dbDataSet_Credit.Clear()
        dbDataSet_Credit.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter_Credit = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter_Credit.Fill(dbDataSet_Credit, "Credit")
        gbl_DstConnect.Close()

        If dbDataSet_Credit.Tables("Credit").Rows.Count > 0 Then
            For intstep = 0 To dbDataSet_Credit.Tables("Credit").Rows.Count - 1
                If Not IsDBNull(dbDataSet_Credit.Tables("Credit").Rows(intstep).Item(1)) Then 'Date
                    obj(1) = FormatDateTime(dbDataSet_Credit.Tables("Credit").Rows(intstep).Item(1), DateFormat.ShortDate)
                End If

                If Not IsDBNull(dbDataSet_Credit.Tables("Credit").Rows(intstep).Item(2)) Then 'Transactions
                    If dbDataSet_Credit.Tables("Credit").Rows(intstep).Item(2) = "ATM" Then obj(2) = "ATM" Else obj(2) = dbDataSet_Credit.Tables("Credit").Rows(intstep).Item(3).ToString 'Chkno or Atm
                Else : obj(2) = "" : End If

                If Not IsDBNull(dbDataSet_Credit.Tables("Credit").Rows(intstep).Item(4)) Then 'Payee
                    obj(3) = dbDataSet_Credit.Tables("Credit").Rows(intstep).Item(4)
                Else : obj(3) = "" : End If

                If Not IsDBNull(dbDataSet_Credit.Tables("Credit").Rows(intstep).Item(5)) Then 'Amount
                    obj(4) = FormatCurrency(dbDataSet_Credit.Tables("Credit").Rows(intstep).Item(5))
                Else : obj(4) = "" : End If
                itm = New ListViewItem(obj)
                ListView2.Items.Add(itm)
            Next
            lbl_CreditItems.Text = dbDataSet_Credit.Tables("Credit").Rows.Count
        Else
            lbl_CreditItems.Text = 0
        End If

        'Test for any service charges 
        If tbox_InterestEarned.Text <> "" Then
            obj(1) = tbox_InterestDate.Text
            obj(2) = "" 'Chkno or Atm
            obj(3) = "Bank interest" 'Payee
            obj(4) = tbox_InterestEarned.Text 'Amount
            itm = New ListViewItem(obj)
            ListView2.Items.Add(itm)
            lbl_CreditItems.Text = lbl_CreditItems.Text + 1
            lbl_SelectedCountCredit.Text = 1
            Num = Convert.ToInt32(lbl_CreditItems.Text) - 1
            ListView2.Items(Num).Checked = True
        End If

    End Sub
    Private Sub ListView_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles ListView1.ItemCheck, ListView2.ItemCheck
        If booDataChecked = True Then Exit Sub

        'Change color of selected row in listview
        If (e.NewValue = CheckState.Checked) Then
            sender.Items(e.Index).BackColor = Color.AntiqueWhite
        Else : sender.Items(e.Index).BackColor = System.Drawing.SystemColors.Window : End If

        'Calculate count and total value of selected items
        Dim Count, Top As Integer
        Dim TotValue As Double = 0.0
        Count = 0
        If sender.name = "ListView1" Then Top = Convert.ToInt32(lbl_DebitItems.Text) - 1 Else Top = Convert.ToInt32(lbl_CreditItems.Text) - 1
        For i = 0 To Top
            If sender.Items(i).BackColor = Color.AntiqueWhite Then Count = Count + 1 : TotValue += Double.Parse(FormatNumber(sender.Items(i).SubItems(4).Text))
        Next

        ' Output data
        If sender.name = "ListView1" Then 'Debit
            lbl_SelectedCountDebit.Text = Count
            lbl_SelectedValueDebit.Text = FormatCurrency(CType(TotValue, String))
            lbl_ClearedBalance.Text = FormatCurrency((StartBalance + lbl_SelectedValueCredit.Text) - lbl_SelectedValueDebit.Text)
        Else
            lbl_SelectedCountCredit.Text = Count
            lbl_SelectedValueCredit.Text = FormatCurrency(CType(TotValue, String))
            lbl_ClearedBalance.Text = FormatCurrency((StartBalance - lbl_SelectedValueDebit.Text) + lbl_SelectedValueCredit.Text)
        End If
        lbl_Difference.Text = Format(Math.Abs(lbl_ClearedBalance.Text - tbox_EndBalance.Text), "0.00")
    End Sub
    Private Sub cmd_ProceedClick(sender As Object, e As EventArgs) Handles cmd_Proceed.Click

        'Test for insufficient data before allowing proceed
        Dim intFocus As Integer = 0
        While True
            If tbox_StartBalance.Text = "" Then frm_Message.Text = "17:1:0:1:3:Opening balance must be entered to continue" : intFocus = 1 : Exit While
            If tbox_EndBalance.Text = "" Then frm_Message.Text = "17:1:0:1:3:Ending balance must be entered to continue" : intFocus = 2 : Exit While
            If tbox_StatementDate.Text = "  /  /" Then frm_Message.Text = "17:1:0:1:3:Statement date must be entered to continue" : intFocus = 3 : Exit While
            If tbox_InterestEarned.Text <> "" And tbox_InterestDate.Text = "  /  /" Then frm_Message.Text = "17:1:0:1:3:A date must be associated with the interest entered" : intFocus = 4 : Exit While
            If tbox_ServiceCharge.Text <> "" And tbox_ServiceDate.Text = "  /  /" Then frm_Message.Text = "17:1:0:1:3:A date must be associated with the service charge entered" : intFocus = 5 : Exit While
            Exit While
        End While
        If intFocus <> 0 Then
            frm_Message.ShowDialog()
            Select Case intFocus
                Case 1 : tbox_StartBalance.Focus()
                Case 2 : tbox_EndBalance.Focus()
                Case 3 : tbox_StatementDate.Focus()
                Case 4 : tbox_InterestDate.Focus()
                Case 5 : tbox_ServiceDate.Focus()
            End Select
            Exit Sub
        End If
        StartBalance = tbox_StartBalance.Text
        lbl_ClearedBalance.Text = FormatCurrency(StartBalance)
        lbl_EndBalance.Text = FormatCurrency(tbox_EndBalance.Text)
        lbl_Difference.Text = Format(Math.Abs(tbox_StartBalance.Text - tbox_EndBalance.Text), "0.00")
        fra_Statement1.Visible = False
        Call ListViewLoad()
        cmd_Abort.Visible = True
        cmd_Finish.Visible = True
    End Sub
    Private Sub cmd_CancelClick(sender As Object, e As EventArgs) Handles cmd_Cancel.Click
        Me.Close()
    End Sub
    Private Sub cmd_Finish_Click(sender As Object, e As EventArgs) Handles cmd_Finish.Click

        If lbl_ClearedBalance.Text = lbl_EndBalance.Text Then
            Cursor.Current = Cursors.WaitCursor

            'Save reconciled debit changes
            For i = 0 To dbDataSet_Debit.Tables("Debit").Rows.Count - 1
                If ListView1.Items(i).Checked = True Then
                    Dim cb0 As New OleDb.OleDbCommandBuilder(dbAdapter_Debit)
                    dbDataSet_Debit.Tables("Debit").Rows(i).Item(7) = True
                    dbAdapter_Debit.Update(dbDataSet_Debit, "Debit")
                    cb0 = Nothing
                End If
            Next

            'Save reconciled credit changes
            For i = 0 To dbDataSet_Credit.Tables("Credit").Rows.Count - 1
                If ListView2.Items(i).Checked = True Then
                    Dim cb1 As New OleDb.OleDbCommandBuilder(dbAdapter_Credit)
                    dbDataSet_Credit.Tables("Credit").Rows(i).Item(7) = True
                    dbAdapter_Credit.Update(dbDataSet_Credit, "Credit")
                    cb1 = Nothing
                End If
            Next

            'Test for service charges and interest adjustments
            If tbox_ServiceCharge.Text <> "" Or tbox_InterestEarned.Text <> "" Then
                strSQL = "Select Balance FROM Banking ORDER BY Id;"
                dbDataSet_Misc.Clear()
                dbDataSet_Misc.Tables.Clear()
                gbl_DstConnect.Open()
                dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
                dbAdapter_Misc.Fill(dbDataSet_Misc, "Balance")
                gbl_DstConnect.Close()

                'Retreive balance & selected category 
                Dim BankBalance As Double = dbDataSet_Misc.Tables("Balance").Rows(dbDataSet_Misc.Tables("Balance").Rows.Count - 1).Item(0)
                Dim Amount As Double

                'Test for any interest 
                If tbox_InterestEarned.Text <> "" Then  'Save interest database
                    Amount = Convert.ToDouble(FormatNumber(tbox_InterestEarned.Text))
                    BankBalance = BankBalance + Amount
                    Dim cb2 As New OleDb.OleDbCommandBuilder(dbAdapter_Credit)
                    Dim dsNewRow As DataRow
                    dsNewRow = dbDataSet_Credit.Tables("Credit").NewRow()
                    dsNewRow.Item("TransDate") = tbox_InterestDate.Text
                    dsNewRow.Item("Transactions") = "Interest"
                    dsNewRow.Item("Payee") = "Interest earned"
                    dsNewRow.Item("Amount") = Amount
                    dsNewRow.Item("Balance") = BankBalance
                    dsNewRow.Item("Clear") = True
                    dbDataSet_Credit.Tables("Credit").Rows.Add(dsNewRow)
                    dbAdapter_Credit.Update(dbDataSet_Credit, "Credit")
                    cb2 = Nothing
                End If

                'Test for any service charges 
                If tbox_ServiceCharge.Text <> "" Then  'Save service charge data to database
                    Amount = Convert.ToDouble(FormatNumber(tbox_ServiceCharge.Text))
                    BankBalance = BankBalance - Amount
                    Dim cb3 As New OleDb.OleDbCommandBuilder(dbAdapter_Debit)
                    Dim dsNewRow As DataRow
                    dsNewRow = dbDataSet_Debit.Tables("Debit").NewRow()
                    dsNewRow.Item("TransDate") = tbox_ServiceDate.Text
                    dsNewRow.Item("Transactions") = "Misc Charges"
                    dsNewRow.Item("Payee") = "Bank service charge"
                    dsNewRow.Item("Amount") = Amount
                    dsNewRow.Item("Balance") = BankBalance
                    dsNewRow.Item("Clear") = True
                    dbDataSet_Debit.Tables("Debit").Rows.Add(dsNewRow)
                    dbAdapter_Debit.Update(dbDataSet_Debit, "Debit")
                    cb3 = Nothing
                End If
            End If

            'Update system table
            Dim cb4 As New OleDb.OleDbCommandBuilder(dbAdapter_Recon)
            dbDataSet_Recon.Tables("Recon").Rows(0).Item(1) = Convert.ToDouble(FormatNumber(lbl_EndBalance.Text))
            dbDataSet_Recon.Tables("Recon").Rows(0).Item(2) = tbox_StatementDate.Text
            dbAdapter_Recon.Update(dbDataSet_Recon, "Recon")
            cb4 = Nothing
            Cursor.Current = Cursors.Default
            Call frm_Checkbook.DataGridViewRefresh() 'Update datagridview1  
            Me.Close()
        Else
            frm_Message.Text = "17:1:0:28:3:Cleared balance and Ending balance must be the same to allow saving results"
            frm_Message.ShowDialog()
        End If

    End Sub
    Private Sub cmd_Abort_Click(sender As Object, e As EventArgs) Handles cmd_Abort.Click
        Me.Close()
    End Sub

    'All Handlers
    Private Sub tbox_GotFocus(sender As Object, e As EventArgs) Handles tbox_StartBalance.GotFocus, tbox_EndBalance.GotFocus, tbox_StatementDate.GotFocus, tbox_InterestEarned.GotFocus, tbox_InterestDate.GotFocus, tbox_ServiceCharge.GotFocus, tbox_ServiceDate.GotFocus
        sender.BackColor = Color.FromArgb(255, 255, 192)
    End Sub
    Private Sub tbox_lostFocus(sender As Object, e As EventArgs) Handles tbox_StartBalance.LostFocus, tbox_EndBalance.LostFocus, tbox_StatementDate.LostFocus, tbox_InterestEarned.LostFocus, tbox_InterestDate.LostFocus, tbox_ServiceCharge.LostFocus, tbox_ServiceDate.LostFocus
        If booDataChecked = True Then sender.BackColor = Color.White : Exit Sub
        Select Case sender.name
            Case "tbox_StatementDate", "tbox_InterestDate", "tbox_ServiceDate"
                If IsDate(sender.Text) = False And sender.Text <> "  /  /" Then
                    sender.BackColor = Color.Aqua
                    booDataChecked = True
                    frm_Message.Text = "17:1:0:1:3:The date entered is not valid, Please enter a valid date"
                    frm_Message.ShowDialog()
                    sender.text = ""
                    sender.Focus()
                    booDataChecked = False
                    Exit Sub
                End If
            Case "tbox_StartBalance", "tbox_EndBalance", "tbox_InterestEarned", "tbox_ServiceCharge"
                If sender.text <> "" Then
                    If Not IsNumeric(sender.Text) Then
                        booDataChecked = True
                        frm_Message.Text = "17:1:0:1:3:Invalid Entry --- Numerical entries are only allowed"
                        frm_Message.ShowDialog()
                        sender.text = ""
                        sender.Focus()
                        booDataChecked = False
                        Exit Sub
                    End If
                    sender.text = FormatCurrency(sender.text, 2)
                    If sender.name = "tbox_InterestEarned" Then
                        If tbox_InterestDate.Text = "  /  /" Then tbox_InterestDate.Text = tbox_StatementDate.Text
                    End If
                    If sender.name = "tbox_ServiceCharge" Then
                        If tbox_InterestDate.Text <> "  /  /" And tbox_InterestDate.Text <> tbox_StatementDate.Text Then
                            tbox_ServiceDate.Text = tbox_InterestDate.Text
                        Else
                            tbox_ServiceDate.Text = tbox_StatementDate.Text
                        End If
                    End If
                End If
        End Select
        sender.BackColor = Color.White
    End Sub
    Private Sub tbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbox_StartBalance.KeyPress, tbox_EndBalance.KeyPress, tbox_StatementDate.KeyPress, tbox_InterestEarned.KeyPress, tbox_InterestDate.KeyPress, tbox_ServiceCharge.KeyPress, tbox_ServiceDate.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            Select Case sender.Name
                Case "tbox_StartBalance" : tbox_EndBalance.Focus()
                Case "tbox_EndBalance" : tbox_StatementDate.Focus()
                Case "tbox_StatementDate" : tbox_InterestEarned.Focus()
                Case "tbox_InterestEarned" : tbox_InterestDate.Focus()
                Case "tbox_InterestDate" : tbox_ServiceCharge.Focus()
                Case "tbox_ServiceCharge" : tbox_ServiceDate.Focus()
                Case "tbox_ServiceDate" : tbox_EndBalance.Focus()
            End Select
        End If
    End Sub

    'All mouse movement and mouse over messages
    Private Sub tbox_MouseClick(sender As Object, e As MouseEventArgs) Handles tbox_StatementDate.MouseClick, tbox_InterestDate.MouseClick, tbox_ServiceDate.MouseClick
        If sender.text = "  /  /" Then sender.SelectionStart = 0
    End Sub
    Private Sub fra_MouseMove() Handles fra_Statement2.MouseMove, fra_Interest.MouseMove, fra_ServiceCharge.MouseMove 'Clear message
        intMessage = 0
        Call MouseMessages()
    End Sub
    Private Sub All_MouseHover(sender As Object, e As EventArgs) Handles tbox_StartBalance.MouseHover, tbox_EndBalance.MouseHover, tbox_StatementDate.MouseHover, tbox_InterestEarned.MouseHover, tbox_InterestDate.MouseHover, tbox_ServiceCharge.MouseHover, tbox_ServiceDate.MouseHover
        Select Case sender.name
            Case "tbox_StartBalance" : intMessage = 1
            Case "tbox_EndBalance" : intMessage = 2
            Case "tbox_StatementDate" : intMessage = 3
            Case "tbox_InterestEarned" : intMessage = 4
            Case "tbox_InterestDate" : intMessage = 5
            Case "tbox_ServiceCharge" : intMessage = 6
            Case "tbox_ServiceDate" : intMessage = 7
        End Select
        Call MouseMessages()
    End Sub
    Private Sub MouseMessages()
        Select Case intMessage
            Case 0 : lbl_Message1.Text = "" 'Clear message from screen
            Case 1 : lbl_Message1.Text = "Enter the start balance found on the bank accounts monthly statement"
            Case 2 : lbl_Message1.Text = "Enter the end balance found on the bank accounts monthly statement"
            Case 3 : lbl_Message1.Text = "Enter the statement date found on the bank accounts monthly statement"
            Case 4 : lbl_Message1.Text = "Enter any interest earned found on the bank accounts monthly statement"
            Case 5 : lbl_Message1.Text = "Enter the date associated with this months interest earned."
            Case 6 : lbl_Message1.Text = "Enter any service charges found on the bank accounts monthly statement"
            Case 7 : lbl_Message1.Text = "Enter the date associated with this months service charges."
        End Select
    End Sub

End Class
