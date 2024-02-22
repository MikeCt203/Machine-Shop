Imports System.Data.OleDb
Public Class frm_Checkbook
    Dim dbAdapter, dbAdapter_Cat, dbAdapter_Misc As OleDb.OleDbDataAdapter
    Dim dbDataSet, dbDataSet_Cat, dbDataSet_Misc As New DataSet
    Dim dbDataTable As New DataTable
    Dim changes As DataSet
    Dim strSQL As String

    Dim cmd_Action(5) As Button
    Dim opt_Clear(6) As RadioButton
    Dim opt_Criteria(4) As RadioButton
    Dim EditArray(0) As Integer 'Array to hold index of changed rows in datagrid
    Dim booDataChecked, RowDelete As Boolean
    Dim intMessage As Integer
    Dim initialEntry, strFocus As String

    'Form Related
    Private Sub frm_Checkbook_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call FormData()
        Call DataGridForm()
        Call DataGridData()
        Call AddControls()
        RowDelete = False
    End Sub
    Private Sub Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        dbDataSet.Clear()
        dbDataSet.Tables.Clear()
        dbDataSet_Cat.Clear()
        dbDataSet_Cat.Tables.Clear()
        dbDataSet_Misc.Clear()
        dbDataSet_Misc.Tables.Clear()
        Me.Dispose()
    End Sub
    Private Sub FormData()
        Me.Size = New Size(1050, 662) '642
        lbl_Message.SetBounds(15, 597, 864, 19)
        lbl_Message.BackColor = Color.MintCream
        fra_Transactions.Location = New Point(892, 8)
        fra_Options.Location = New Point(892, 335)
        lbl_Transaction.Location = New Point(887, 3)
    End Sub
    Private Sub DataGridForm()

        With DataGridView1
            .SetBounds(15, 15, 864, 574)
            .RowTemplate.Height = 22
            .Font = New Font("Microsoft Sans Serif", 8, FontStyle.Regular)
            .ReadOnly = True

            'Center all column header text
            Dim dgvColumnHeaderStyle As New DataGridViewCellStyle()
            dgvColumnHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersDefaultCellStyle = dgvColumnHeaderStyle

            With colTransaction
                .MaxDropDownItems = 6
                .Items.Add("Check")
                .Items.Add("ATM")
                .Items.Add("Deposit")
                .Items.Add("Misc Additions")
                .Items.Add("Misc Charges")
                .Items.Add("Interest")
            End With

            strSQL = "SELECT Category FROM TaxCategorys ORDER BY Id;"
            dbDataSet_Cat.Clear()
            dbDataSet_Cat.Tables.Clear()
            gbl_DstConnect.Open()
            dbAdapter_Cat = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
            dbAdapter_Cat.Fill(dbDataSet_Cat, "Categorys")
            gbl_DstConnect.Close()

            If dbDataSet_Cat.Tables("Categorys").Rows.Count <> 0 Then
                With colCategory
                    .Items.Add("") 'Add blank first row (default value for error )
                    For i = 0 To dbDataSet_Cat.Tables("Categorys").Rows.Count - 1
                        If Not IsDBNull(dbDataSet_Cat.Tables("Categorys").Rows(i).Item(0)) Then 'Title
                            .Items.Add(Trim(dbDataSet_Cat.Tables("Categorys").Rows(i).Item(0)))
                        End If
                    Next
                End With
            Else
                frm_Message.Text = "14:1:0:27:3:There are no categories on record,categories must be set up to continue"
                frm_Message.ShowDialog()
                Me.Close()
                Exit Sub
            End If

            colAmount.DefaultCellStyle.Format = String.Format("c")
            colBalance.DefaultCellStyle.Format = String.Format("c")
        End With
    End Sub
    Private Sub DataGridData()

        strSQL = "Select TransDate,Transactions,Chkno,Payee,Category,Memos,Amount,Balance,Clear,Id FROM Banking ORDER by Id"
        Try
            gbl_DstConnect.Open()
            dbAdapter = New OleDbDataAdapter(strSQL, gbl_DstConnect)
            dbAdapter.Fill(dbDataSet)
            colDate.DataPropertyName = "TransDate"
            colTransaction.DataPropertyName = "Transactions"
            colChkno.DataPropertyName = "Chkno"
            colPayee.DataPropertyName = "Payee"
            colCategory.DataPropertyName = "Category"
            colMemo.DataPropertyName = "Memos"
            colAmount.DataPropertyName = "Amount"
            colBalance.DataPropertyName = "Balance"
            colCleared.DataPropertyName = "Clear"
            With DataGridView1
                .DataSource = dbDataSet.Tables(0)
                If .Rows.Count > 24 Then
                    .FirstDisplayedScrollingRowIndex = .Rows.Count - 1 'Scroll to end of records
                    .FirstDisplayedScrollingRowIndex = .FirstDisplayedScrollingRowIndex - 1
                End If
                .ClearSelection()
            End With
            gbl_DstConnect.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub AddControls() 'Add amount controls
        Dim int_Dim As Integer
        Dim str_Text As String = ""
     
        'Create array of controls ( option buttons in Find frame)
        For i = 0 To 6
            Select Case i
                Case 0 : int_Dim = 125
                Case 1 : int_Dim = 243
                Case 2 : int_Dim = 351
                Case 3 : int_Dim = 566
                Case 4 : int_Dim = 705
                Case 5 : int_Dim = 872
                Case 6 : int_Dim = 980
            End Select

            opt_Clear(i) = New RadioButton
            With opt_Clear(i)
                .Name = "opt_Clear"
                .Tag = i
                .BackColor = Color.AliceBlue
                .SetBounds(int_Dim, 17, 13, 14)
                fra_Search.Controls.Add(opt_Clear(i))
                AddHandler .CheckedChanged, AddressOf opt_ClearData
                AddHandler .MouseHover, AddressOf All_MouseHover
            End With
        Next

        'Create array of controls ( option buttons in Criteria frame)
        For i = 0 To 4
            Select Case i
                Case 0 : int_Dim = 10 : str_Text = "Equal to"
                Case 1 : int_Dim = 84 : str_Text = "Greater than"
                Case 2 : int_Dim = 178 : str_Text = "Greater than or Equal to"
                Case 3 : int_Dim = 326 : str_Text = "Less than"
                Case 4 : int_Dim = 407 : str_Text = "Less than or Equal to"
            End Select

            opt_Criteria(i) = New RadioButton
            With opt_Criteria(i)
                .Name = "opt_Criteria"
                .Text = str_Text
                .Tag = i
                .AutoSize = True
                .Location = New Point(int_Dim, 9)
                fra_Criteria.Controls.Add(opt_Criteria(i))
                AddHandler .Click, AddressOf opt_Criteria_Click
                AddHandler .MouseHover, AddressOf All_MouseHover
            End With
        Next

        'Create array of controls ( cmd buttons in transaction and option frame)
        For i = 0 To 5

            Select Case i
                Case 0 : int_Dim = 31 : str_Text = "Checks"
                Case 1 : int_Dim = 106 : str_Text = "ATM"
                Case 2 : int_Dim = 180 : str_Text = "Deposits"
                Case 3 : int_Dim = 31 : str_Text = "Search"
                Case 4 : int_Dim = 106 : str_Text = "Options"
                Case 5 : int_Dim = 180 : str_Text = "Exit"
            End Select

            cmd_Action(i) = New Button
            With cmd_Action(i)
                .Name = "cmd_Action"
                .Tag = i
                .BackColor = System.Drawing.SystemColors.Control
                .Text = str_Text
                .SetBounds(14, int_Dim, 100, 55)
                If i <= 2 Then fra_Transactions.Controls.Add(cmd_Action(i)) Else fra_Options.Controls.Add(cmd_Action(i))
                AddHandler .Click, AddressOf cmd_Click
                AddHandler .MouseHover, AddressOf All_MouseHover
            End With
        Next
    End Sub

    'Misc commands
    Private Sub cmd_Click(sender As Object, e As EventArgs)
        Select Case sender.tag
            Case 0
                If sender.text = "Checks" Then
                    lbl_Message.Visible = False
                    frm_CheckbookChecks.ShowDialog()
                    lbl_Message.Visible = True
                End If
                If sender.text = "Edit" Then
                    DataGridView1.ReadOnly = False
                    DataGridView1.Columns(7).ReadOnly = True
                    DataGridView1.Columns(8).ReadOnly = True
                    cmd_Action(0).Text = "Cancel"
                    cmd_Action(1).Enabled = False
                    cmd_Action(2).Enabled = False
                    cmd_Action(3).Enabled = False
                    cmd_Action(4).Enabled = False
                    Exit Sub
                End If
                If sender.text = "Cancel" Then
                    DataGridView1.ReadOnly = True
                    cmd_Action(0).Text = "Edit"
                    cmd_Action(1).Enabled = True
                    cmd_Action(3).Enabled = True
                    cmd_Action(4).Enabled = True
                    ' If DataGridView1.SelectedCells.Count <> 0 Then cmd_Action(1).Enabled = True
                End If
            Case 1
                If sender.text = "ATM" Then
                    lbl_Message.Visible = False
                    frm_CheckbookDepositsATM.Text = "ATM Withdrawls"
                    frm_CheckbookDepositsATM.ShowDialog()
                    lbl_Message.Visible = True
                End If

                If sender.text = "Delete / Void  Row" Then

                    If DataGridView1.SelectedCells.Count = 0 Then 'No cells selected
                        frm_Message.Text = "14:1:0:17:3:No rows have been selected, Row deletion cannot continue"
                        frm_Message.ShowDialog()
                        Exit Sub
                    End If

                    If DataGridView1.SelectedRows.Count = 0 Then 'Select full row if only cell selected
                        DataGridView1.Rows(DataGridView1.SelectedCells(0).RowIndex).Selected = True
                    End If

                    If DataGridView1.Rows(DataGridView1.SelectedCells(0).RowIndex).Cells(8).Value = True Then 'Previous cleared row warning
                        frm_Message.Text = "14:1:0:17:3:This row has been previously cleared, Deletion of this row not allowed"
                        frm_Message.ShowDialog()
                        DataGridView1.ClearSelection()
                        Exit Sub
                    Else
                        If DataGridView1.Rows(DataGridView1.SelectedCells(0).RowIndex).Cells(1).Value = "Check" Then
                            frm_Message.Text = "14:2:0:1:3:Are you sure you want to void this check in the Checkbook"
                        Else
                            frm_Message.Text = "14:2:0:1:3:Are you sure you want to delete this item from the Checkbook"
                        End If
                        frm_Message.ShowDialog()
                    End If

                    If MessageResult = True Then

                        'Update database 
                        strSQL = "Select Transactions,Payee,Memos,Amount,Balance,Clear,Id FROM Banking WHERE Id >= " & DataGridView1.Rows(DataGridView1.SelectedCells(0).RowIndex - 1).Cells(9).Value & " ORDER by Id"
                        dbDataSet_Misc.Clear()
                        dbDataSet_Misc.Tables.Clear()
                        gbl_DstConnect.Open()
                        dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
                        dbAdapter_Misc.Fill(dbDataSet_Misc, "UpdateBalance")
                        gbl_DstConnect.Close()

                        If dbDataSet_Misc.Tables("UpdateBalance").Rows.Count > 2 Then
                            Dim Balance As Double = dbDataSet_Misc.Tables("UpdateBalance").Rows(0).Item(4)
                            For i = 2 To dbDataSet_Misc.Tables("UpdateBalance").Rows.Count - 1

                                'Calculate balance
                                Select Case dbDataSet_Misc.Tables("UpdateBalance").Rows(i).Item(0)
                                    Case "Check", "ATM", "Misc Charges"
                                        Balance = Balance - dbDataSet_Misc.Tables("UpdateBalance").Rows(i).Item(3)
                                    Case "Deposit", "Misc Additions", "Interest"
                                        Balance = Balance + dbDataSet_Misc.Tables("UpdateBalance").Rows(i).Item(3)
                                End Select

                                'Update balance
                                Dim cb0 As New OleDb.OleDbCommandBuilder(dbAdapter_Misc)
                                dbDataSet_Misc.Tables("UpdateBalance").Rows(i).Item(4) = Balance
                                dbAdapter_Misc.Update(dbDataSet_Misc, "UpdateBalance")
                                cb0 = Nothing
                            Next
                        End If

                        If dbDataSet_Misc.Tables("UpdateBalance").Rows.Count > 1 Then
                            Dim cb1 As New OleDb.OleDbCommandBuilder(dbAdapter_Misc)
                            If DataGridView1.Rows(DataGridView1.SelectedCells(0).RowIndex).Cells(1).Value = "Check" Then 'Void selected row
                                dbDataSet_Misc.Tables("UpdateBalance").Rows(1).Item(1) = "Void" 'Payee
                                dbDataSet_Misc.Tables("UpdateBalance").Rows(1).Item(2) = "Void" 'Memo
                                dbDataSet_Misc.Tables("UpdateBalance").Rows(1).Item(3) = 0 'Amount
                                dbDataSet_Misc.Tables("UpdateBalance").Rows(1).Item(4) = DataGridView1.Rows(DataGridView1.SelectedCells(0).RowIndex - 1).Cells(7).Value 'Balance
                                dbDataSet_Misc.Tables("UpdateBalance").Rows(1).Item(5) = True 'Clear
                            Else 'Delete selected row
                                dbDataSet_Misc.Tables("UpdateBalance").Rows(1).Delete()
                            End If
                            dbAdapter_Misc.Update(dbDataSet_Misc, "UpdateBalance")
                            cb1 = Nothing
                        End If
                        Call DataGridViewRefresh()
                    End If
                    DataGridView1.ClearSelection()
                End If

            Case 2
                    If sender.text = "Deposits" Then
                        lbl_Message.Visible = False
                        frm_CheckbookDepositsATM.Text = "Deposits"
                        frm_CheckbookDepositsATM.ShowDialog()
                        lbl_Message.Visible = True
                    End If
                    If sender.text = "Save Changes" Then

                        'Check all changed rows for complete data
                        For i = 0 To UBound(EditArray)

                            If (String.IsNullOrEmpty(DataGridView1.Rows(EditArray(i)).Cells(0).Value.ToString())) Then 'Test for date entry
                                DataGridView1.Rows(EditArray(i)).Cells(0).Style.BackColor = Color.Aqua
                            frm_Message.Text = "14:1:0:20:3:A date must be entered, before any edits can be saved"
                                frm_Message.ShowDialog()
                                DataGridView1.Rows(EditArray(i)).Cells(0).Style.BackColor = Color.White
                                Exit Sub
                            End If

                            If (String.IsNullOrEmpty(DataGridView1.Rows(EditArray(i)).Cells(1).Value.ToString())) Then 'Test for transaction entry
                                DataGridView1.Rows(EditArray(i)).Cells(1).Style.BackColor = Color.Aqua
                            frm_Message.Text = "14:1:0:21:3:A transaction type must be entered before any saves on edits will be allowed"
                                frm_Message.ShowDialog()
                                DataGridView1.Rows(EditArray(i)).Cells(1).Style.BackColor = Color.White
                                Exit Sub
                            End If

                            Dim NewValue As String = DataGridView1.Rows(EditArray(i)).Cells(2).Value.ToString()

                            If (String.IsNullOrEmpty(DataGridView1.Rows(EditArray(i)).Cells(2).Value.ToString())) Then 'Test for check number entry empty
                                If DataGridView1.Rows(EditArray(i)).Cells(1).Value = "Check" Then
                                    DataGridView1.Rows(EditArray(i)).Cells(2).Style.BackColor = Color.Aqua
                                frm_Message.Text = "14:1:0:22:3:A check number must be entered on a check transaction"
                                    frm_Message.ShowDialog()
                                    DataGridView1.Rows(EditArray(i)).Cells(2).Style.BackColor = Color.White
                                    Exit Sub
                                End If
                            Else 'Check textbox not empty
                                If DataGridView1.Rows(EditArray(i)).Cells(1).Value <> "Check" Then
                                    NewValue = DataGridView1.Rows(EditArray(i)).Cells(1).Value
                                    DataGridView1.Rows(EditArray(i)).Cells(2).Style.BackColor = Color.Aqua
                                frm_Message.Text = "14:1:0:22:3:A check number entry is only allowed with on a check transaction"
                                    frm_Message.ShowDialog()
                                    DataGridView1.Rows(EditArray(i)).Cells(2).Style.BackColor = Color.White
                                    Exit Sub
                                End If
                            End If

                            If (String.IsNullOrEmpty(DataGridView1.Rows(EditArray(i)).Cells(3).Value.ToString())) Then 'Test for payee entry
                                If DataGridView1.Rows(EditArray(i)).Cells(1).Value = "Check" Or DataGridView1.Rows(EditArray(i)).Cells(1).Value = "ATM" Or DataGridView1.Rows(EditArray(i)).Cells(1).Value = "Deposit" Then
                                    DataGridView1.Rows(EditArray(i)).Cells(3).Style.BackColor = Color.Aqua
                                frm_Message.Text = "14:1:0:23:3:Payee name must be entered on a Check, ATM or Deposit transaction"
                                    frm_Message.ShowDialog()
                                    DataGridView1.Rows(EditArray(i)).Cells(3).Style.BackColor = Color.White
                                    Exit Sub
                                End If
                            End If

                            If (String.IsNullOrEmpty(DataGridView1.Rows(EditArray(i)).Cells(4).Value.ToString())) Then 'Test for category entry
                                If DataGridView1.Rows(EditArray(i)).Cells(1).Value = "Check" Or DataGridView1.Rows(EditArray(i)).Cells(1).Value = "ATM" Then
                                    DataGridView1.Rows(EditArray(i)).Cells(4).Style.BackColor = Color.Aqua
                                frm_Message.Text = "14:1:0:24:3:A category must be selected on this type of transaction"
                                    frm_Message.ShowDialog()
                                    DataGridView1.Rows(EditArray(i)).Cells(4).Style.BackColor = Color.White
                                    Exit Sub
                                End If
                            End If

                            If (String.IsNullOrEmpty(DataGridView1.Rows(EditArray(i)).Cells(6).Value.ToString())) Then 'Test for amount entry
                                DataGridView1.Rows(EditArray(i)).Cells(6).Style.BackColor = Color.Aqua
                            frm_Message.Text = "14:1:0:25:3:An amount must be entered before any saves on edits will be allowed"
                                frm_Message.ShowDialog()
                                DataGridView1.Rows(EditArray(i)).Cells(6).Style.BackColor = Color.White
                                Exit Sub
                            End If
                        Next

                        Try
                            Dim oledbCmdBuilder As New OleDbCommandBuilder(dbAdapter)
                            changes = dbDataSet.GetChanges()
                            If changes IsNot Nothing Then
                                dbAdapter.Update(dbDataSet.Tables(0))
                            End If
                            dbDataSet.AcceptChanges()
                            changes = Nothing
                            oledbCmdBuilder = Nothing
                            If RowDelete = False Then
                                DataGridView1.ClearSelection()
                            cmd_Action(2).Enabled = False 'Disable save button
                            frm_Message.Text = "14:1:0:18:3:All changes have been saved"
                                frm_Message.ShowDialog()
                                DataGridView1.ReadOnly = True
                                cmd_Action(0).Text = "Edit"
                                cmd_Action(1).Enabled = True
                                cmd_Action(3).Enabled = True
                                cmd_Action(4).Enabled = True
                            Else
                                RowDelete = False
                            End If
                        Catch ex As Exception
                            MsgBox(ex.ToString)
                        End Try
                    End If
            Case 3
                    If sender.text = "Search" Then
                        Me.Height = 802
                        lbl_Message.SetBounds(111, 715, 814, 19)
                        lbl_Message.BackColor = Color.AliceBlue
                        lbl_FraTop.Visible = True
                        fra_Search.Visible = True
                        fra_Transactions.Enabled = False
                        cmd_Action(3).Enabled = False
                        cmd_Action(4).Enabled = False
                        fra_Criteria.Visible = False
                        With cbx_Category
                            .Items.Add("")
                            For i = 0 To dbDataSet_Cat.Tables("Categorys").Rows.Count - 1
                                If Not IsDBNull(dbDataSet_Cat.Tables("Categorys").Rows(i).Item(0)) Then 'Title
                                    .Items.Add(Trim(dbDataSet_Cat.Tables("Categorys").Rows(i).Item(0)))
                                End If
                            Next
                        End With
                        cbx_Transaction.SelectedIndex = 0
                        cbx_Category.SelectedIndex = 0
                        opt_Criteria(0).Checked = True
                        tbox_Date1.Focus()
                    End If
                    If sender.text = "Reconcile Account" Then
                        lbl_Message.Visible = False
                        frm_CheckbookReconcile.ShowDialog()
                        lbl_Message.Visible = True
                    End If
            Case 4
                    If sender.text = "Options" Then
                        cmd_Action(0).Text = "Edit"
                        cmd_Action(1).Text = "Delete / Void  Row"
                        cmd_Action(2).Text = "Save Changes"
                        cmd_Action(2).Enabled = False
                        cmd_Action(3).Text = "Reconcile Account"
                        cmd_Action(4).Text = "Back"
                        Exit Sub
                    End If
                    If sender.text = "Back" Then
                        cmd_Action(0).Text = "Checks"
                        cmd_Action(1).Text = "ATM"
                        cmd_Action(1).Enabled = True
                        cmd_Action(2).Text = "Deposits"
                        cmd_Action(2).Enabled = True
                        cmd_Action(3).Text = "Search"
                        cmd_Action(4).Text = "Options"
                    End If
            Case 5
                    If sender.text = "Exit" Then
                        DataGridView1.ReadOnly = True
                        Me.Close()
                    End If
        End Select

    End Sub
    Private Sub cmd_Search_Click(sender As Object, e As EventArgs) Handles cmd_Search.Click

        If tbox_Date1.Text = "  /  /" And tbox_Date2.Text = "  /  /" And cbx_Transaction.Text = "" And tbox_Chkno1.Text = "" And tbox_Chkno2.Text = "" And tbox_Payee.Text = "" And cbx_Category.Text = "" And tbox_Memo.Text = "" And tbox_Amount1.Text = "" And tbox_Amount2.Text = "" Then
            Exit Sub 'No search data entered
        End If

        Dim amt1, amt2 As Double
        Dim strCriteria1 As String = ""
        Dim strCriteria2 As String = ""
        Dim Diff As Long
        Dim booEQ, booAND As Boolean

        'Test for valid search criteria with dates
        If tbox_Date1.Text <> "  /  /" And tbox_Date2.Text <> "  /  /" Then
            booEQ = True
            Dim DateHigh, DateLow As Date
            DateHigh = Nothing : DateLow = Nothing
            If tbox_DateCriteria1.Text = ">" Or tbox_DateCriteria1.Text = ">=" Then DateHigh = tbox_Date1.Text
            If tbox_DateCriteria1.Text = "<" Or tbox_DateCriteria1.Text = "<=" Then DateLow = tbox_Date1.Text
            If tbox_DateCriteria2.Text = ">" Or tbox_DateCriteria2.Text = ">=" Then DateHigh = tbox_Date2.Text
            If tbox_DateCriteria2.Text = "<" Or tbox_DateCriteria2.Text = "<=" Then DateLow = tbox_Date2.Text
            Diff = DateDiff(DateInterval.Day, DateHigh, DateLow)
            If Diff = 0 Then
                booEQ = False
                If InStr(tbox_DateCriteria1.Text, "=") = True Or InStr(tbox_DateCriteria2.Text, "=") = True Then booEQ = True
            End If
            If Diff < 0 Or booEQ = False Then
                frm_Message.Text = "14:1:0:1:3:Date criteria entered leave no possible search senario"
                frm_Message.ShowDialog()
                Exit Sub
            End If
        End If

        'Test for valid search criteria with check numbers
        If tbox_Chkno1.Text <> "" And tbox_Chkno2.Text <> "" Then
            booEQ = True
            amt1 = Nothing : amt2 = Nothing
            If tbox_ChknoCriteria1.Text = ">" Or tbox_ChknoCriteria1.Text = ">=" Then amt1 = tbox_Chkno1.Text
            If tbox_ChknoCriteria1.Text = "<" Or tbox_ChknoCriteria1.Text = "<=" Then amt2 = tbox_Chkno1.Text
            If tbox_ChknoCriteria2.Text = ">" Or tbox_ChknoCriteria2.Text = ">=" Then amt1 = tbox_Chkno2.Text
            If tbox_ChknoCriteria2.Text = "<" Or tbox_ChknoCriteria2.Text = "<=" Then amt2 = tbox_Chkno2.Text
            Diff = amt2 - amt1
            If Diff = 0 Then
                booEQ = False
                If InStr(tbox_ChknoCriteria1.Text, "=") = True Or InStr(tbox_ChknoCriteria2.Text, "=") = True Then booEQ = True
            End If
            If Diff < 0 Or booEQ = False Then
                frm_Message.Text = "14:1:0:1:3:Check number criteria entered leave no possible search senario"
                frm_Message.ShowDialog()
                Exit Sub
            End If
        End If

        'Test for valid search criteria with check amounts
        If tbox_Amount1.Text <> "" And tbox_Amount2.Text <> "" Then
            booEQ = True
            amt1 = Nothing : amt2 = Nothing
            If tbox_AmountCriteria1.Text = ">" Or tbox_AmountCriteria1.Text = ">=" Then amt1 = tbox_Amount1.Text
            If tbox_AmountCriteria1.Text = "<" Or tbox_AmountCriteria1.Text = "<=" Then amt2 = tbox_Amount1.Text
            If tbox_AmountCriteria2.Text = ">" Or tbox_AmountCriteria2.Text = ">=" Then amt1 = tbox_Amount2.Text
            If tbox_AmountCriteria2.Text = "<" Or tbox_AmountCriteria2.Text = "<=" Then amt2 = tbox_Amount2.Text
            Diff = amt2 - amt1
            If Diff = 0 Then
                booEQ = False
                If InStr(tbox_AmountCriteria1.Text, "=") = True Or InStr(tbox_AmountCriteria2.Text, "=") = True Then booEQ = True
            End If
            If Diff < 0 Or booEQ = False Then
                frm_Message.Text = "14:1:0:1:3:Check amount criteria entered leave no possible search senario"
                frm_Message.ShowDialog()
                Exit Sub
            End If
        End If

        'Build sql search criteria
        booAND = False
        strSQL = "Select TransDate,Transactions,Chkno,Payee,Category,Memos,Amount,Balance,Clear FROM Banking WHERE "

        'Test if dates found
        If tbox_Date1.Text <> "  /  /" Or tbox_Date2.Text <> "  /  /" Then
            booAND = True
            Dim Date1, Date2 As Date
            If tbox_Date1.Text <> "  /  /" Then Date1 = tbox_Date1.Text : strCriteria1 = tbox_DateCriteria1.Text Else Date1 = Nothing
            If tbox_Date2.Text <> "  /  /" Then Date2 = tbox_Date2.Text : strCriteria2 = tbox_DateCriteria2.Text Else Date2 = Nothing

            'Test for incorrect order of dates
            If tbox_Date2.Text <> "  /  /" And tbox_Date1.Text = "  /  /" Then
                strCriteria1 = strCriteria2
                Date1 = Date2 : Date2 = Nothing
            End If

            'Build sql string with date search criteria
            strSQL = strSQL & "TransDate " & strCriteria1 & " #" & Date1 & "#"
            If Date2 <> Nothing Then strSQL = strSQL & " AND TransDate " & strCriteria2 & " #" & Date2 & "#"
        End If

        'Test if transaction entry found
        If cbx_Transaction.Text <> "" Then
            If booAND = True Then strSQL = strSQL & " AND " 'Adjust sql string to add another criteria
            strSQL = strSQL & "Transactions = '" & cbx_Transaction.Text & "'"
            booAND = True
        End If

        'Test if check number found
        If Trim(tbox_Chkno1.Text) <> "" Or Trim(tbox_Chkno2.Text) <> "" Then
            If booAND = True Then strSQL = strSQL & " AND " 'Adjust sql string to add another criteria
            If Trim(tbox_Chkno1.Text) <> "" Then amt1 = Trim(tbox_Chkno1.Text) : strCriteria1 = tbox_ChknoCriteria1.Text Else amt1 = Nothing
            If Trim(tbox_Chkno2.Text) <> "" Then amt2 = Trim(tbox_Chkno2.Text) : strCriteria2 = tbox_ChknoCriteria2.Text Else amt2 = Nothing

            'Test for incorrect order of checks
            If Trim(tbox_Chkno2.Text) <> "" And Trim(tbox_Chkno1.Text) = "" Then
                strCriteria1 = strCriteria2
                amt1 = amt2 : amt2 = Nothing
            End If

            'Build sql string with check number search criteria
            strSQL = strSQL & "Chkno " & strCriteria1 & amt1
            If amt2 <> Nothing Then strSQL = strSQL & " AND Chkno " & strCriteria2 & amt2
            booAND = True
        End If

        'Test if Payee entry found
        If Trim(tbox_Payee.Text) <> "" Then
            If booAND = True Then strSQL = strSQL & " AND " 'Adjust sql string to add another criteria
            strSQL = strSQL & "Payee = '" & Trim(tbox_Payee.Text) & "'"
            booAND = True
        End If

        'Test if category entry found
        If cbx_Category.Text <> "" Then
            If booAND = True Then strSQL = strSQL & " AND " 'Adjust sql string to add another criteria
            strSQL = strSQL & "Category = '" & cbx_Category.Text & "'"
            booAND = True
        End If

        'Test if memo entry found
        If Trim(tbox_Memo.Text) <> "" Then
            If booAND = True Then strSQL = strSQL & " AND " 'Adjust sql string to add another criteria
            strSQL = strSQL & "Memos = '" & Trim(tbox_Memo.Text) & "'"
            booAND = True
        End If

        'Test if check amount found
        If Trim(tbox_Amount1.Text) <> "" Or Trim(tbox_Amount2.Text) <> "" Then
            If booAND = True Then strSQL = strSQL & " AND " 'Adjust sql string to add another criteria
            If Trim(tbox_Amount1.Text) <> "" Then amt1 = Trim(tbox_Amount1.Text) : strCriteria1 = tbox_AmountCriteria1.Text Else amt1 = Nothing
            If Trim(tbox_Amount2.Text) <> "" Then amt2 = Trim(tbox_Amount2.Text) : strCriteria2 = tbox_AmountCriteria2.Text Else amt2 = Nothing

            'Test for incorrect order of checks
            If Trim(tbox_Amount2.Text) <> "" And Trim(tbox_Amount1.Text) = "" Then
                strCriteria1 = strCriteria2
                amt1 = amt2 : amt2 = Nothing
            End If

            'Build sql string with check number search criteria
            strSQL = strSQL & "Amount " & strCriteria1 & amt1
            If amt2 <> Nothing Then strSQL = strSQL & " AND Amount " & strCriteria2 & amt2
        End If

        'Close sql string   
        strSQL = strSQL & " ;"

        Try
            dbDataSet.Clear()
            gbl_DstConnect.Close()
            gbl_DstConnect.Open()
            dbAdapter = New OleDbDataAdapter(strSQL, gbl_DstConnect)
            dbAdapter.Fill(dbDataSet)

            If dbDataSet.Tables(0).Rows.Count <> 0 Then
                DataGridView1.DataSource = dbDataSet.Tables(0)
                gbl_DstConnect.Close()
                cmd_Search.Visible = False
                DateTimePicker.Visible = False
            Else
                frm_Message.Text = "14:1:0:16:3:No matches found for the entered search criteria"
                frm_Message.ShowDialog()
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub cmd_SearchClose_Click_1(sender As Object, e As EventArgs) Handles cmd_SearchClose.Click

        lbl_FraTop.Visible = False
        fra_Search.Visible = False
        Me.Height = 642

        gbl_DstConnect.Close()
        Call DataGridViewRefresh()
        DataGridView1.ClearSelection()
        DateTimePicker.ResetText()

        'Clear all prior search data
        tbox_Date1.Text = ""
        tbox_Date2.Text = ""
        cbx_Transaction.Text = ""
        tbox_Chkno1.Text = ""
        tbox_Chkno2.Text = ""
        tbox_Payee.Text = ""
        cbx_Category.Text = ""
        tbox_Memo.Text = ""
        tbox_Amount1.Text = ""
        tbox_Amount2.Text = ""
        tbox_Date2.Text = ""
        tbox_Chkno2.Text = ""
        tbox_Amount2.Text = ""
        tbox_DateCriteria1.Text = "="
        tbox_ChknoCriteria1.Text = "="
        tbox_AmountCriteria1.Text = "="
        tbox_DateCriteria2.Text = ""
        tbox_ChknoCriteria2.Text = ""
        tbox_AmountCriteria2.Text = ""
        tbox_Date2.Visible = False
        tbox_Chkno2.Visible = False
        tbox_Amount2.Visible = False
        tbox_DateCriteria2.Visible = False
        tbox_ChknoCriteria2.Visible = False
        tbox_AmountCriteria2.Visible = False
        fra_Transactions.Enabled = True
        cmd_Action(3).Enabled = True
        cmd_Action(4).Enabled = True
        EnableEdits(True)
        ListBox1.Hide()
    End Sub
    Private Sub DateTimePicker_CloseUp(sender As Object, e As EventArgs) Handles DateTimePicker.CloseUp
        If DateTimePicker.Tag = 1 Then
            If tbox_DateCriteria1.Text = "=" Then
                DateTimePicker.Visible = False
                cbx_Transaction.Focus()
            Else
                'PreSelect 2nd criteria based on the selected first criteria
                Select Case tbox_DateCriteria1.Text
                    Case ">" : tbox_DateCriteria2.Text = "<="
                    Case ">=" : tbox_DateCriteria2.Text = "<"
                    Case "<" : tbox_DateCriteria2.Text = ">="
                    Case "<=" : tbox_DateCriteria2.Text = ">"
                End Select
                tbox_DateCriteria2.Visible = True
                tbox_Date2.Visible = True
                tbox_Date2.Focus()
            End If
        Else : DateTimePicker.Visible = False : cbx_Transaction.Focus() : End If
    End Sub
    Private Sub DateTimePicker_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker.ValueChanged
        booDataChecked = True
        If DateTimePicker.Tag = 1 Then tbox_Date1.Text = DateTimePicker.Value.ToString("MM/dd/yyyy") Else tbox_Date2.Text = DateTimePicker.Value.ToString("MM/dd/yyyy")
        booDataChecked = False
    End Sub
    Private Sub Listbox_DoubleClick() Handles listbox1.DoubleClick
        If listbox1.Width = 200 Then tbox_Payee.Text = listbox1.SelectedItem Else tbox_Memo.Text = listbox1.SelectedItem
        listbox1.Visible = False
        lbl_Message.Visible = True
        EnableEdits(True)
    End Sub
    Private Sub Listbox_Click() Handles listbox1.Click
        If listbox1.Width = 200 Then tbox_Payee.Text = listbox1.SelectedItem Else tbox_Memo.Text = listbox1.SelectedItem
        listbox1.Visible = False
        lbl_Message.Visible = True
        EnableEdits(True)
    End Sub
    Private Sub EnableEdits(blnStatus As Boolean)
        tbox_DateCriteria1.Enabled = blnStatus
        tbox_DateCriteria2.Enabled = blnStatus
        tbox_Date1.Enabled = blnStatus
        tbox_Date2.Enabled = blnStatus
        cbx_Transaction.Enabled = blnStatus
        tbox_ChknoCriteria1.Enabled = blnStatus
        tbox_ChknoCriteria2.Enabled = blnStatus
        tbox_Chkno1.Enabled = blnStatus
        tbox_Chkno2.Enabled = blnStatus
        tbox_Payee.Enabled = blnStatus
        tbox_Memo.Enabled = blnStatus
        cbx_Category.Enabled = blnStatus
        tbox_AmountCriteria1.Enabled = blnStatus
        tbox_AmountCriteria2.Enabled = blnStatus
        tbox_Amount1.Enabled = blnStatus
        tbox_Amount2.Enabled = blnStatus
        cmd_Search.Enabled = blnStatus
        For i = 0 To 6
            opt_Clear(i).Enabled = blnStatus
        Next
        cmd_Search.Enabled = blnStatus
    End Sub

    'Datagridview handlers
    Private Sub DataGridView1_CurrentCellChanged(sender As Object, e As EventArgs) Handles DataGridView1.CurrentCellChanged 'Check for cleared entries
        If booDataChecked = True Or DataGridView1.ReadOnly = True Then Exit Sub
        If DataGridView1.SelectedCells.Count <> 0 Then 'Cells selected
            Select Case DataGridView1.CurrentCell.ColumnIndex
                Case Is = 1, 6
                    ' If DataGridView1.CurrentCell.RowIndex = DataGridView1.Rows.Count - 1 Then Exit Sub 'Skip if new row selected
                    If DataGridView1.Rows(DataGridView1.SelectedCells(0).RowIndex).Cells(8).Value = True Then
                        DataGridView1.Rows(DataGridView1.SelectedCells(0).RowIndex).Cells(1).ReadOnly = True
                        frm_Message.Text = "14:1:0:19:3:This row has been previously cleared, This item can not be changed"
                        frm_Message.ShowDialog()
                    End If
            End Select
        End If
    End Sub
    Private Sub DataGridView1_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DataGridView1.CellBeginEdit
        If Not (String.IsNullOrEmpty(DataGridView1(e.ColumnIndex, e.RowIndex).Value.ToString())) Then initialEntry = DataGridView1(e.ColumnIndex, e.RowIndex).Value 'Record initial value only if cell contained data
    End Sub
    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit 'Update datagridview
        If (String.IsNullOrEmpty(DataGridView1(e.ColumnIndex, e.RowIndex).Value.ToString())) Then
            If IsDBNull(initialEntry) Then Exit Sub 'Exit if cell null and initial entry null

            'Initial entry deleted, add change to EditArray list
            Dim booNew As Boolean = True
            For i = 0 To UBound(EditArray)
                If e.RowIndex = EditArray(i) Then booNew = False : Exit For
            Next
            If booNew = True Then EditArray(EditArray.Count - 1) = e.RowIndex : ReDim Preserve EditArray(EditArray.Count)
            cmd_Action(2).Enabled = True
        Else
            If DataGridView1(e.ColumnIndex, e.RowIndex).Value <> initialEntry Then

                'Create list of all rows with data changed changed for save operation ( Test if row index previously recorded )
                Dim booNew As Boolean = True
                For i = 0 To UBound(EditArray)
                    If e.RowIndex = EditArray(i) Then booNew = False : Exit For
                Next
                If booNew = True Then EditArray(EditArray.Count - 1) = e.RowIndex : ReDim Preserve EditArray(EditArray.Count)

                Select Case DataGridView1.CurrentCell.ColumnIndex
                    Case 1, 6 'Transaction, amount
                        Dim str1 As Double = DataGridView1.Rows(e.RowIndex - 1).Cells(7).Value
                        Call UpdateBalance(e.RowIndex - 1) 'Update balance if needed
                    Case 2 'Chkno
                        If DataGridView1.Rows(e.RowIndex).Cells(1).FormattedValue.ToString = "Check" Then
                            Dim SearchCount As Integer = 0
                            Dim SearchCell(2) As Integer
                            For i = DataGridView1.RowCount - 1 To DataGridView1.CurrentCell.RowIndex - 500 Step -1 'Search from end of column to current cells index - 500
                                If DataGridView1.Rows(i).Cells(2).FormattedValue.ToString = DataGridView1.CurrentCell.FormattedValue.ToString.ToString Then 'Check if cells match
                                    SearchCount = SearchCount + 1
                                    SearchCell(SearchCount) = i
                                    If SearchCount = 2 Then 'Repeat check number found
                                        DataGridView1.Rows(SearchCell(1)).Cells(2).Style.BackColor = Color.Aqua
                                        DataGridView1.Rows(SearchCell(2)).Cells(2).Style.BackColor = Color.Aqua
                                        frm_Message.Text = "14:7:0:26:3:There is a check on file with the same check number"
                                        frm_Message.ShowDialog()
                                        If MessageResult = True Then DataGridView1(e.ColumnIndex, e.RowIndex).Value = Nothing
                                        DataGridView1.Rows(SearchCell(1)).Cells(2).Style.BackColor = Color.White
                                        DataGridView1.Rows(SearchCell(2)).Cells(2).Style.BackColor = Color.White
                                        If SearchCount = 2 Then Exit For
                                    End If
                                End If
                            Next
                        Else 'No data entry allowed in chkno if check not selected
                            frm_Message.Text = "14:1:0:22:3:A check number entry is only allowed with on a check transaction"
                            frm_Message.ShowDialog()
                            DataGridView1(e.ColumnIndex, e.RowIndex).Value = Nothing
                        End If
                    Case 4 'Category
                        If DataGridView1.Rows(e.RowIndex).Cells(1).FormattedValue.ToString = "Deposit" Or DataGridView1.Rows(e.RowIndex).Cells(1).FormattedValue.ToString = "Misc Additions" Or DataGridView1.Rows(e.RowIndex).Cells(1).FormattedValue.ToString = "Interest" Then
                            frm_Message.Text = "14:1:0:27:3:Category selection is only allowed with Checks, ATM, and Misc Charges"
                            frm_Message.ShowDialog()
                            DataGridView1(e.ColumnIndex, e.RowIndex).Value = Nothing
                        End If
                End Select
                cmd_Action(2).Enabled = True
            End If
        End If
    End Sub
    Private Sub DataGridView1_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError 'Test for incorrect data entries
        'Do not erase, needed to elimate error ?
    End Sub
    Private Sub DataGridView1_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles DataGridView1.CellValidating
        If DataGridView1.ReadOnly = True Or booDataChecked = True Or e.RowIndex = 0 Then Exit Sub 'Exit on switch options
        If e.FormattedValue.ToString = DataGridView1.CurrentCell.FormattedValue.ToString Or (String.IsNullOrEmpty(e.FormattedValue.ToString())) Then Exit Sub 'Exit on empty or same valued cell

        Select Case DataGridView1.CurrentCell.ColumnIndex
            Case Is = 0
                If IsDate(e.FormattedValue.ToString()) = False Then 'Test if date valid 
                    booDataChecked = True
                    frm_Message.Text = "14:1:0:1:3:The date entered is not valid, Please enter a valid date"
                    frm_Message.ShowDialog()
                    Dim cell As DataGridViewCell = CType(sender, DataGridView).Rows(e.RowIndex).Cells(e.ColumnIndex)
                    cell.Value = Nothing
                    e.Cancel = True
                    booDataChecked = False
                    Exit Sub
                End If
            Case Is = 2, 6
                If IsNumeric(e.FormattedValue.ToString()) = False Then 'Test if entry numerical 
                    booDataChecked = True
                    frm_Message.Text = "14:1:0:1:3:Invalid Entry --- Numerical entries are only allowed"
                    frm_Message.ShowDialog()
                    Dim cell As DataGridViewCell = CType(sender, DataGridView).Rows(e.RowIndex).Cells(e.ColumnIndex)
                    cell.Value = Nothing
                    e.Cancel = True
                    booDataChecked = False
                    Exit Sub
                End If

        End Select
    End Sub
    Private Sub UpdateBalance(row As Integer)

        Dim Balance As Double = DataGridView1.Rows(row).Cells(7).Value
        row = row + 1
        For i = row To DataGridView1.Rows.Count - 1
            Select Case DataGridView1.Rows(i).Cells(1).Value
                Case "Check", "ATM", "Misc Charges"
                    Balance = Balance - DataGridView1.Rows(i).Cells(6).Value
                Case "Deposit", "Misc Additions", "Interest"
                    Balance = Balance + DataGridView1.Rows(i).Cells(6).Value
            End Select
            DataGridView1.Rows(i).Cells(7).Value = Balance
        Next

    End Sub
    Public Sub DataGridViewRefresh() 'Refresh datagridview with all changes 

        strSQL = "Select TransDate,Transactions,Chkno,Payee,Category,Memos,Amount,Balance,Clear,Id FROM Banking"
        Try
            dbDataSet.Clear()
            gbl_DstConnect.Open()
            dbAdapter = New OleDbDataAdapter(strSQL, gbl_DstConnect)
            dbAdapter.Fill(dbDataSet)
            With DataGridView1
                .DataSource = dbDataSet.Tables(0)
                .FirstDisplayedScrollingRowIndex = .Rows.Count - 1 'Scroll to end of records
                .FirstDisplayedScrollingRowIndex = .FirstDisplayedScrollingRowIndex - 1
            End With
            gbl_DstConnect.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    'Textbox handlers
    Private Sub tbox_GotFocus(sender As Object, e As EventArgs) Handles tbox_DateCriteria1.GotFocus, tbox_DateCriteria2.GotFocus, tbox_Date1.GotFocus, tbox_Date2.GotFocus, cbx_Transaction.GotFocus, tbox_ChknoCriteria1.GotFocus, tbox_ChknoCriteria2.GotFocus, tbox_Chkno1.GotFocus, tbox_Chkno2.GotFocus, tbox_Payee.GotFocus, cbx_Category.GotFocus, tbox_Memo.GotFocus, tbox_AmountCriteria1.GotFocus, tbox_AmountCriteria2.GotFocus, tbox_Amount1.GotFocus, tbox_Amount2.GotFocus

        Dim strCriteria As String = ""
        Select Case sender.name
            Case "tbox_DateCriteria1" : strCriteria = tbox_DateCriteria1.Text
            Case "tbox_Date1" : strCriteria = "" : DateTimePicker.Tag = 1
            Case "tbox_DateCriteria2" : strCriteria = tbox_DateCriteria1.Text
            Case "tbox_Date2" : strCriteria = "" : DateTimePicker.Tag = 2
            Case "tbox_ChknoCriteria1" : strCriteria = tbox_ChknoCriteria1.Text
            Case "tbox_Chkno1" : strCriteria = ""
            Case "tbox_ChknoCriteria2" : strCriteria = tbox_ChknoCriteria1.Text
            Case "tbox_Chkno2" : strCriteria = ""
            Case "tbox_AmountCriteria1" : strCriteria = tbox_AmountCriteria1.Text
            Case "tbox_Amount1" : strCriteria = ""
            Case "tbox_AmountCriteria2" : strCriteria = tbox_AmountCriteria1.Text
            Case "tbox_Amount2" : strCriteria = ""
            Case Else : strCriteria = ""
        End Select

        If strCriteria <> "" Then
            Select Case sender.name
                Case "tbox_DateCriteria1", "tbox_DateCriteria2", "tbox_ChknoCriteria1", "tbox_ChknoCriteria2", "tbox_AmountCriteria1", "tbox_AmountCriteria2"
                    Me.Height = 825
                    fra_Criteria.Visible = True
                    Select Case sender.name
                        Case "tbox_DateCriteria1", "tbox_ChknoCriteria1", "tbox_AmountCriteria1"
                            For i = 0 To 4 : opt_Criteria(i).Enabled = True : Next
                        Case Else
                            Select Case strCriteria 'Limit 2nd criteria based on the selected first criteria
                                Case ">"
                                    opt_Criteria(0).Enabled = False
                                    opt_Criteria(1).Enabled = False
                                    opt_Criteria(2).Enabled = False
                                    opt_Criteria(3).Enabled = True
                                    opt_Criteria(4).Enabled = True
                                    opt_Criteria(4).Checked = True
                                Case ">=" : opt_Criteria(3).Checked = True
                                Case "<"
                                    opt_Criteria(0).Enabled = False
                                    opt_Criteria(1).Enabled = True
                                    opt_Criteria(2).Enabled = True
                                    opt_Criteria(3).Enabled = False
                                    opt_Criteria(4).Enabled = False
                                    opt_Criteria(2).Checked = True
                                Case "<=" : opt_Criteria(1).Checked = True
                            End Select
                    End Select
                Case Else
                    Me.Height = 802
                    fra_Criteria.Visible = False
            End Select

            'Select radio button to match textbox criteria
            booDataChecked = True
            Select Case sender.text
                Case "=" : opt_Criteria(0).Checked = True
                Case ">" : opt_Criteria(1).Checked = True
                Case ">=" : opt_Criteria(2).Checked = True
                Case "<" : opt_Criteria(3).Checked = True
                Case "<=" : opt_Criteria(4).Checked = True
            End Select
            booDataChecked = False
        Else
            fra_Criteria.Visible = False
        End If
        If sender.name = "tbox_Date1" Or sender.name = "tbox_Date2" Then DateTimePicker.Visible = True Else DateTimePicker.Visible = False

        tbox_DateCriteria1.BackColor = Color.White : tbox_DateCriteria2.BackColor = Color.White
        tbox_ChknoCriteria1.BackColor = Color.White : tbox_ChknoCriteria2.BackColor = Color.White
        tbox_AmountCriteria1.BackColor = Color.White : tbox_AmountCriteria2.BackColor = Color.White
        sender.BackColor = Color.FromArgb(255, 255, 192)
    End Sub
    Private Sub tbox_lostFocus(sender As Object, e As EventArgs) Handles tbox_Date1.LostFocus, tbox_Date2.LostFocus, cbx_Transaction.LostFocus, tbox_Chkno1.LostFocus, tbox_Chkno2.LostFocus, tbox_Payee.LostFocus, cbx_Category.LostFocus, tbox_Memo.LostFocus, tbox_Amount1.LostFocus, tbox_Amount2.LostFocus

        If booDataChecked = True Then Exit Sub

        Select Case sender.name
            Case "tbox_Date1", "tbox_Date2" 'Test for valid date
                If IsDate(sender.Text) = False And sender.Text <> "  /  /" Then
                    sender.BackColor = Color.Aqua
                    booDataChecked = True
                    frm_Message.Text = "14:1:0:1:3:The date entered is not valid, Please enter a valid date"
                    frm_Message.ShowDialog()
                    sender.text = ""
                    sender.Focus()
                    booDataChecked = False
                    Exit Sub
                Else
                    If tbox_Date1.Text <> "  /  /" And tbox_Date2.Text <> "  /  /" Then Exit Select
                    If tbox_Date1.Text <> "  /  /" Then
                        If tbox_DateCriteria1.Text = "=" Then
                            cbx_Transaction.Focus()
                        Else
                            'PreSelect 2nd criteria based on the selected first criteria
                            Select Case tbox_DateCriteria1.Text
                                Case ">" : tbox_Date2.Text = "<="
                                Case ">=" : tbox_Date2.Text = "<"
                                Case "<" : tbox_Date2.Text = ">="
                                Case "<=" : tbox_Date2.Text = ">"
                            End Select
                            tbox_DateCriteria2.Visible = True
                            tbox_Date2.Visible = True
                            tbox_Date2.Focus()
                        End If
                    End If
                End If

            Case "tbox_Chkno1", "tbox_Chkno2", "tbox_Amount1", "tbox_Amount2"
                If sender.text <> "" And Not IsNumeric(sender.Text) Then
                    booDataChecked = True
                    frm_Message.Text = "14:1:0:1:3:Invalid Entry --- Numerical entries are only allowed"
                    frm_Message.ShowDialog()
                    sender.text = ""
                    sender.Focus()
                    booDataChecked = False
                    Exit Sub
                Else
                    If sender.name = "tbox_Chkno1" Or sender.name = "tbox_Chkno2" Then
                        If tbox_Chkno1.Text <> "" And tbox_Chkno2.Text <> "" Then Exit Select
                        If tbox_Chkno1.Text <> "" Then
                            If tbox_ChknoCriteria1.Text = "=" Then
                                tbox_Payee.Focus()
                            Else
                                Select Case tbox_ChknoCriteria1.Text
                                    Case ">" : tbox_ChknoCriteria2.Text = "<="
                                    Case ">=" : tbox_ChknoCriteria2.Text = "<"
                                    Case "<" : tbox_ChknoCriteria2.Text = ">="
                                    Case "<=" : tbox_ChknoCriteria2.Text = ">"
                                End Select
                                tbox_ChknoCriteria2.Visible = True
                                tbox_Chkno2.Visible = True
                                tbox_Chkno2.Focus()
                            End If
                        End If
                    End If
                    If sender.name = "tbox_Amount1" Or sender.name = "tbox_Amount2" Then
                        If tbox_Amount1.Text <> "" And tbox_Amount2.Text <> "" Then Exit Select
                        If tbox_Amount1.Text <> "" Then
                            If tbox_Amount1.Text <> "" Then
                                If tbox_AmountCriteria1.Text = "=" Then
                                    tbox_Date1.Focus()
                                Else
                                    Select Case tbox_AmountCriteria1.Text
                                        Case ">" : tbox_AmountCriteria2.Text = "<="
                                        Case ">=" : tbox_AmountCriteria2.Text = "<"
                                        Case "<" : tbox_AmountCriteria2.Text = ">="
                                        Case "<=" : tbox_AmountCriteria2.Text = ">"
                                    End Select
                                    tbox_AmountCriteria2.Visible = True
                                    tbox_Amount2.Visible = True
                                    tbox_Amount2.Focus()
                                End If
                            End If
                        End If
                    End If
                End If
        End Select
        If sender.name = "tbox_Date1" Or sender.name = "tbox_Date2" Then DateTimePicker.Visible = True Else DateTimePicker.Visible = False
        sender.BackColor = Color.White
    End Sub
    Private Sub tbox_TextChanged(sender As Object, e As EventArgs) Handles tbox_Date1.TextChanged, tbox_Date2.TextChanged, cbx_Transaction.TextChanged, tbox_Chkno1.TextChanged, tbox_Chkno2.TextChanged, tbox_Payee.TextChanged, cbx_Category.TextChanged, tbox_Memo.TextChanged, tbox_Amount1.TextChanged, tbox_Amount2.TextChanged

        If tbox_Date1.Text = "  /  /" And tbox_Date2.Text = "  /  /" And cbx_Transaction.Text = "" And tbox_Chkno1.Text = "" And tbox_Chkno2.Text = "" And tbox_Payee.Text = "" And cbx_Category.Text = "" And tbox_Memo.Text = "" And tbox_Amount1.Text = "" And tbox_Amount2.Text = "" Then
            cmd_Search.Visible = False
        Else : cmd_Search.Visible = True : End If

        If booDataChecked = True Then Exit Sub 'Skip if pre_processed data
        Select Case sender.Name
            Case "tbox_Payee"
                EnableEdits(False)
                tbox_Payee.Enabled = True
                If Trim(sender.Text) <> "" Then 'Capitalize first letter of entry
                    If Len(Trim(sender.Text)) = 1 Then
                        booDataChecked = True
                        sender.Text = StrConv(Trim(sender.Text), vbUpperCase)
                        sender.SelectionStart = 2
                        booDataChecked = False
                    End If
                End If
                listbox1.SetBounds(379, 55, 200, 18)

                'Clear listboxes
                strSQL = "SELECT DISTINCT Payee FROM Banking WHERE Payee LIKE '" & Trim(tbox_Payee.Text) & "%" & "' ORDER BY Payee;"
                dbDataSet_Misc.Clear()
                dbDataSet_Misc.Tables.Clear()
                gbl_DstConnect.Open()
                dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
                dbAdapter_Misc.Fill(dbDataSet_Misc, "Payee")
                gbl_DstConnect.Close()
                If dbDataSet_Misc.Tables("Payee").Rows.Count > 1 Then 'Multiple records found  
                    listbox1.Items.Clear()
                    listbox1.Items.Add("")
                    Dim num As Integer
                    For num = 1 To dbDataSet_Misc.Tables("Payee").Rows.Count - 1
                        listbox1.Items.Add(dbDataSet_Misc.Tables("Payee").Rows(num).Item(0))
                    Next
                    lbl_Message.Visible = False
                    If num > 6 Then num = 6
                    listbox1.Height = num * 17
                    listbox1.Visible = True
                ElseIf dbDataSet_Misc.Tables("Payee").Rows.Count = 1 Then
                    tbox_Payee.Text = dbDataSet_Misc.Tables("Payee").Rows(0).Item(0)
                    listbox1.Visible = False
                    cbx_Category.Focus()
                End If

            Case "tbox_Memo"
                EnableEdits(False)
                tbox_Memo.Enabled = True
                ListBox1.SetBounds(733, 55, 152, 18)

                'Clear listboxes
                strSQL = "SELECT DISTINCT Memos FROM Banking WHERE Memos LIKE '" & Trim(tbox_Memo.Text) & "%" & "' ORDER BY Memos;"
                dbDataSet_Misc.Clear()
                dbDataSet_Misc.Tables.Clear()
                gbl_DstConnect.Open()
                dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
                dbAdapter_Misc.Fill(dbDataSet_Misc, "Memo")
                gbl_DstConnect.Close()
                If dbDataSet_Misc.Tables("Memo").Rows.Count > 1 Then 'Multiple records found  
                    ListBox1.Items.Clear()
                    ListBox1.Items.Add("")
                    Dim num As Integer
                    For num = 1 To dbDataSet_Misc.Tables("Memo").Rows.Count - 1
                        ListBox1.Items.Add(dbDataSet_Misc.Tables("Memo").Rows(num).Item(0))
                    Next
                    lbl_Message.Visible = False
                    If num > 6 Then num = 6
                    ListBox1.Height = num * 17
                    ListBox1.Visible = True
                ElseIf dbDataSet_Misc.Tables("Memo").Rows.Count = 1 Then
                    tbox_Memo.Text = dbDataSet_Misc.Tables("Memo").Rows(0).Item(0)
                    ListBox1.Visible = False
                    tbox_Amount1.Focus()
                End If
        End Select

    End Sub
    Private Sub tbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbox_DateCriteria1.KeyPress, tbox_DateCriteria2.KeyPress, tbox_Date1.KeyPress, tbox_Date2.KeyPress, cbx_Transaction.KeyPress, tbox_ChknoCriteria1.KeyPress, tbox_ChknoCriteria2.KeyPress, tbox_Chkno1.KeyPress, tbox_Chkno2.KeyPress, tbox_Payee.KeyPress, cbx_Category.KeyPress, tbox_Memo.KeyPress, tbox_AmountCriteria1.KeyPress, tbox_AmountCriteria2.KeyPress, tbox_Amount1.KeyPress, tbox_Amount2.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            Select Case sender.Name
                Case "tbox_DateCriteria1" : tbox_Date1.Focus()
                Case "tbox_DateCriteria2" : tbox_Date2.Focus()
                Case "tbox_Date1" : If tbox_Date2.Visible = True Then tbox_Date2.Focus() Else cbx_Transaction.Focus()
                Case "tbox_Date2" : cbx_Transaction.Focus()
                Case "cbx_Transaction" : tbox_Chkno1.Focus()
                Case "tbox_ChknoCriteria1" : tbox_Chkno1.Focus()
                Case "tbox_ChknoCriteria2" : tbox_Chkno2.Focus()
                Case "tbox_Chkno1" : If tbox_Chkno2.Visible = True Then tbox_Chkno2.Focus() Else tbox_Payee.Focus()
                Case "tbox_Chkno2" : tbox_Payee.Focus()
                Case "tbox_Payee" : cbx_Category.Focus()
                Case "cbx_Category" : tbox_Memo.Focus()
                Case "tbox_Memo" : tbox_Amount1.Focus()
                Case "tbox_AmountCriteria1" : tbox_Amount1.Focus()
                Case "tbox_AmountCriteria2" : tbox_Amount2.Focus()
                Case "tbox_Amount1" : If tbox_Amount2.Visible = True Then tbox_Amount2.Focus() Else tbox_Date1.Focus()
                Case "tbox_Amount2" : tbox_Date1.Focus()
            End Select
        End If

        'Block type entry into category combobox
        If sender.name = "cbx_Category" Then
            Select Case Asc(e.KeyChar)
                Case Keys.Back
                Case Else
                    e.Handled = True 'this blocks all other key inputs
            End Select
        End If

    End Sub
    Private Sub opt_ClearData(sender As Object, e As EventArgs)
        booDataChecked = True
        Select Case sender.tag
            Case 0
                tbox_Date1.Text = ""
                tbox_Date2.Text = ""
                tbox_DateCriteria1.Text = "="
                tbox_DateCriteria2.Visible = False
                tbox_Date2.Visible = False
                DateTimePicker.Visible = False
            Case 1 : cbx_Transaction.SelectedIndex = 0
            Case 2
                tbox_Chkno1.Text = ""
                tbox_Chkno2.Text = ""
                tbox_ChknoCriteria1.Text = "="
                tbox_ChknoCriteria2.Visible = False
                tbox_Chkno2.Visible = False
            Case 3 : tbox_Payee.Text = ""
            Case 4 : cbx_Category.SelectedIndex = 0
            Case 5 : tbox_Memo.Text = ""
            Case 6
                tbox_Amount1.Text = ""
                tbox_Amount2.Text = ""
                tbox_AmountCriteria1.Text = "="
                tbox_AmountCriteria2.Visible = False
                tbox_Amount2.Visible = False
        End Select
        sender.checked = False
        booDataChecked = False
    End Sub
    Private Sub opt_Criteria_Click(sender As Object, e As EventArgs)

        'Fill textbox with selected symbol and preSelect 2nd criteria based on the first criteria
        Dim strCriteria As String = ""
        Dim PreSelect As String = ""
        Select Case sender.tag
            Case 0 : strCriteria = "="
            Case 1 : strCriteria = ">" : PreSelect = "<="
            Case 2 : strCriteria = ">=" : PreSelect = "<"
            Case 3 : strCriteria = "<" : PreSelect = ">="
            Case 4 : strCriteria = "<=" : PreSelect = ">"
        End Select

        Select Case Color.FromArgb(255, 255, 192)
            Case tbox_DateCriteria1.BackColor : tbox_DateCriteria1.Text = strCriteria : tbox_DateCriteria2.Text = PreSelect
            Case tbox_DateCriteria2.BackColor : tbox_DateCriteria2.Text = strCriteria
            Case tbox_ChknoCriteria1.BackColor : tbox_ChknoCriteria1.Text = strCriteria : tbox_ChknoCriteria2.Text = PreSelect
            Case tbox_ChknoCriteria2.BackColor : tbox_ChknoCriteria2.Text = strCriteria
            Case tbox_AmountCriteria1.BackColor : tbox_AmountCriteria1.Text = strCriteria : tbox_AmountCriteria2.Text = PreSelect
            Case tbox_AmountCriteria2.BackColor : tbox_AmountCriteria2.Text = strCriteria
        End Select

        Select Case Color.FromArgb(255, 255, 192)
            Case tbox_DateCriteria1.BackColor, tbox_DateCriteria2.BackColor
                If sender.tag = 0 Then 'Option "="
                    tbox_Date2.Text = ""
                    tbox_Date2.Visible = False
                    tbox_DateCriteria2.Visible = False
                    If tbox_Date1.Text = "  /  /" Then tbox_Date1.Focus() Else cbx_Transaction.Focus()
                Else
                    If tbox_Date1.Text = "  /  /" Then
                        tbox_Date1.Focus()
                    Else
                        If tbox_Date2.Text = "  /  /" Then
                            tbox_DateCriteria2.Visible = True
                            tbox_Date2.Visible = True
                            tbox_Date2.Focus()
                        Else : cbx_Transaction.Focus() : End If
                    End If
                End If
            Case tbox_ChknoCriteria1.BackColor, tbox_ChknoCriteria2.BackColor
                If sender.tag = 0 Then 'Option "="
                    tbox_Chkno2.Text = ""
                    tbox_Chkno2.Visible = False
                    tbox_ChknoCriteria2.Visible = False
                    If tbox_Chkno1.Text = "" Then tbox_Chkno1.Focus() Else tbox_Payee.Focus()
                Else
                    If tbox_Chkno1.Text = "" Then
                        tbox_Chkno1.Focus()
                    Else
                        If tbox_Chkno2.Text = "" Then
                            tbox_ChknoCriteria2.Visible = True
                            tbox_Chkno2.Visible = True
                            tbox_Chkno2.Focus()
                        Else : tbox_Payee.Focus() : End If
                    End If
                End If
            Case tbox_AmountCriteria1.BackColor, tbox_AmountCriteria2.BackColor
                If sender.tag = 0 Then 'Option "="
                    tbox_Amount2.Text = ""
                    tbox_Amount2.Visible = False
                    tbox_AmountCriteria2.Visible = False
                    If tbox_Amount1.Text = "" Then tbox_Amount1.Focus() Else tbox_Date1.Focus()
                Else
                    If tbox_Amount1.Text = "" Then
                        tbox_Amount1.Focus()
                    Else
                        If tbox_Amount2.Text = "" Then
                            tbox_AmountCriteria2.Visible = True
                            tbox_Amount2.Visible = True
                            tbox_Amount2.Focus()
                        Else : tbox_Date1.Focus() : End If
                    End If
                End If
        End Select
        fra_Criteria.Visible = False
    End Sub
    Private Sub Combobox_Click(sender As Object, e As EventArgs) Handles cbx_Transaction.Click, cbx_Category.Click
        sender.DroppedDown = True
    End Sub

    'All mouse movement and mouse over messages
    Private Sub tbox_MouseClick(sender As Object, e As MouseEventArgs) Handles tbox_Date1.MouseClick, tbox_Date2.MouseClick
        If sender.text = "  /  /" Then sender.SelectionStart = 0
    End Sub
    Private Sub fra_MouseMove() Handles fra_Search.MouseMove, fra_Transactions.MouseMove, fra_Options.MouseMove 'Clear message
        intMessage = 0
        Call MouseMessages()
    End Sub
    Private Sub All_MouseHover(sender As Object, e As EventArgs) Handles DateTimePicker.MouseHover, tbox_DateCriteria1.MouseHover, tbox_DateCriteria2.MouseHover, tbox_Date1.MouseHover, tbox_Date2.MouseHover, cbx_Transaction.MouseHover, tbox_ChknoCriteria1.MouseHover, tbox_ChknoCriteria2.MouseHover, tbox_Chkno1.MouseHover, tbox_Chkno2.MouseHover, tbox_Payee.MouseHover, cbx_Category.MouseHover, tbox_Memo.MouseHover, tbox_AmountCriteria1.MouseHover, tbox_AmountCriteria2.MouseHover, tbox_Amount1.MouseHover, tbox_Amount2.MouseHover
        Select Case sender.name
            Case "VScrollBar1" : intMessage = 1
            Case "cmd_Action"
                Select Case sender.tag
                    Case 0 : If sender.text = "Checks" Then : intMessage = 2 : ElseIf sender.text = "Edit" Then : intMessage = 3 : Else : intMessage = 4 : End If
                    Case 1 : If sender.text = "ATM" Then intMessage = 5 Else intMessage = 6
                    Case 2 : If sender.text = "Deposits" Then intMessage = 7 Else intMessage = 8
                    Case 3 : If sender.text = "Search" Then intMessage = 9 Else intMessage = 10
                    Case 4 : If sender.text = "Options" Then intMessage = 11 Else intMessage = 12
                    Case 5 : intMessage = 13 'Exit
                End Select
            Case "opt_Clear"
                Select Case sender.tag
                    Case 0 : intMessage = 14
                    Case 1 : intMessage = 15
                    Case 2 : intMessage = 16
                    Case 3 : intMessage = 17
                    Case 4 : intMessage = 18
                    Case 5 : intMessage = 19
                    Case 6 : intMessage = 20
                End Select
            Case "DateTimePicker" : intMessage = 21
            Case "tbox_DateCriteria1", "tbox_DateCriteria2" : intMessage = 22
            Case "tbox_Date1", "tbox_Date2" : intMessage = 23
            Case "cbx_Transaction" : intMessage = 24
            Case "tbox_ChknoCriteria1", "tbox_ChknoCriteria2" : intMessage = 25
            Case "tbox_Chkno1", "tbox_Chkno2" : intMessage = 26
            Case "tbox_Payee" : intMessage = 27
            Case "cbx_Category" : intMessage = 28
            Case "tbox_Memo" : intMessage = 29
            Case "tbox_AmountCriteria1", "tbox_AmountCriteria2" : intMessage = 30
            Case "tbox_Amount1", "tbox_Amount2" : intMessage = 31
        End Select
        Call MouseMessages()
    End Sub
    Private Sub MouseMessages()
        Select Case intMessage
            Case 0 : lbl_Message.Text = "" 'Clear message from screen
            Case 1 : lbl_Message.Text = "Slide this to scroll thru the transactions in the checkbook "
            Case 2 : lbl_Message.Text = "Press this button to enter Checks into the checkbook system"
            Case 3 : lbl_Message.Text = "Press this button to Edit any transactions in the checkbook system"
            Case 4 : lbl_Message.Text = "Press this button to Cancel operations and return to main screen"
            Case 5 : lbl_Message.Text = "Press this button to enter ATM transactions into the checkbook system"
            Case 6 : lbl_Message.Text = "Press this button to Delete any rows from the checkbook system"
            Case 7 : lbl_Message.Text = "Press this button to enter Deposits into the checkbook system"
            Case 8 : lbl_Message.Text = "Press this button to Save the edits or any new transactions in the checkbook system"
            Case 9 : lbl_Message.Text = "Press this button to Search the checkbook for specific transactions"
            Case 10 : lbl_Message.Text = "Press this button to Reconcile the checkbook with the bank statment"
            Case 11 : lbl_Message.Text = "Press this button to view other Options available within checkbook system"
            Case 12 : lbl_Message.Text = "Press this button to return to the original option menu"
            Case 13 : lbl_Message.Text = "Press this button to Exit the checkbook program"
            Case 14 : lbl_Message.Text = "Press this button to clear all Dates from the checkbook search"
            Case 15 : lbl_Message.Text = "Press this button to clear all Transactions from the checkbook search"
            Case 16 : lbl_Message.Text = "Press this button to clear all Check Numbers from the checkbook search"
            Case 17 : lbl_Message.Text = "Press this button to clear all Payees from the checkbook search"""
            Case 18 : lbl_Message.Text = "Press this button to clear all Categorys from the checkbook search"
            Case 19 : lbl_Message.Text = "Press this button to clear all Memos from the checkbook search"
            Case 20 : lbl_Message.Text = "Press this button to clear all check Amounts from the checkbook search"
            Case 21 : lbl_Message.Text = "Click here to open the calendar for date selections"
            Case 22 : lbl_Message.Text = "Enter the search criteria for the associated date"
            Case 23 : lbl_Message.Text = "Enter the date to be associated with the search criteria"
            Case 24 : lbl_Message.Text = "Click here to open the transaction list for the selection of a transaction search"
            Case 25 : lbl_Message.Text = "Enter the search criteria for the associated check number"
            Case 26 : lbl_Message.Text = "Enter the check number to be associated with the search criteria"
            Case 27 : lbl_Message.Text = "Start typing the name of the payee, to assist in the selection of the available listed payees"
            Case 28 : lbl_Message.Text = "Click here to open the category list for the selection of a category search"
            Case 29 : lbl_Message.Text = "Start typing the memo, to assist in the selection of the available listed memos"
            Case 30 : lbl_Message.Text = "Enter the search criteria for the associated amount"
            Case 31 : lbl_Message.Text = "Enter the amount to be associated with the search criteria"
        End Select
    End Sub

End Class