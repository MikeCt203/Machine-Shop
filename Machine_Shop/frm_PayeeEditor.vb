Public Class frm_PayeeEditor
    Dim dbAdapter, dbAdapter_Misc As OleDb.OleDbDataAdapter
    Dim dbDataSet, dbDataSet_Misc As New DataSet
    Dim strSQL As String

    Dim opt_Category(17) As RadioButton
    Dim ListArray(1, 1) As Integer 'Used to link dataset to listbox selection
    Dim EditNew As Integer '0 = no process, 1 = edit in process, 2 = new in process
    Dim booDataChecked As Boolean = True 'T = data change is from a controled process
    Dim booNameCheck, booCorrection As Boolean 'T = Test for repeat of name has been done
    Dim intTotalRecords, AutoNum, OptionSelect As Integer
    Dim strInitEntry, strNotes As String 'Variables to hold initial entries of textboxes to test for change
    Dim intLookup As Integer 'Used to locate edited / new saved record in listbox
    Dim intMessage As Integer 'Variable used in the mouse over event to show different messages

    'All form related events  
    Private Sub frm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Call AddControls()
        Call ListData()
    End Sub
    Private Sub Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        dbDataSet.Clear()
        dbDataSet.Tables.Clear()
        dbDataSet_Misc.Clear()
        dbDataSet_Misc.Tables.Clear()
        Me.Dispose()
    End Sub 
    Private Sub ListData()

        Call ClearData()
        strSQL = "SELECT Id,Payto FROM CheckPayee ORDER BY Payto;"
        dbDataSet_Misc.Clear()
        dbDataSet_Misc.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter_Misc.Fill(dbDataSet_Misc, "PayeeList")
        gbl_DstConnect.Close()
        intTotalRecords = dbDataSet_Misc.Tables("PayeeList").Rows.Count
        ReDim ListArray(0 To intTotalRecords - 1, 1)

        ListBox1.Items.Clear()
        If intTotalRecords = 0 Then 'No customers found, allow only new customers, disable listbox and hide option active button = 0
            ListBox1.Enabled = False
            cmd_Edit.Enabled = False  'Disable edit button
            cmd_DeleteCancel.Enabled = False 'Disable cancel button
            frm_Message.Text = "19:1:0:1:3:There are no records on file to view, [New] is the only operation allowed"
            frm_Message.ShowDialog()
        Else 'Fill listbox with data

            Dim varhold As Object
            Dim inc As Integer

            For inc = 0 To dbDataSet_Misc.Tables("PayeeList").Rows.Count - 1

                ListArray(inc, 0) = inc 'Listbox index

                varhold = dbDataSet_Misc.Tables("PayeeList").Rows(inc).Item(0) 'Id
                If IsDBNull(varhold) Then varhold = ""
                ListArray(inc, 1) = Trim(varhold)

                varhold = dbDataSet_Misc.Tables("PayeeList").Rows(inc).Item(1) 'Payee Name
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

        strSQL = "SELECT Id,Payto,Address,City,State,ZipCode,Category FROM CheckPayee WHERE Id = " & intLookup & ";"
        dbDataSet.Clear()
        dbDataSet.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter.Fill(dbDataSet, "Payee")
        gbl_DstConnect.Close()

        'Form fill data
        booDataChecked = True 'Textbox data changes with pre_processed data

        If Not IsDBNull(dbDataSet.Tables("Payee").Rows(0).Item(1)) Then 'Payee Name
            tbox_Payee.Text = Trim(dbDataSet.Tables("Payee").Rows(0).Item(1))
        Else : tbox_Payee.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Payee").Rows(0).Item(2)) Then 'Address
            tbox_Address.Text = Trim(dbDataSet.Tables("Payee").Rows(0).Item(2))
        Else : tbox_Address.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Payee").Rows(0).Item(3)) Then 'City
            tbox_City.Text = Trim(dbDataSet.Tables("Payee").Rows(0).Item(3))
        Else : tbox_City.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Payee").Rows(0).Item(4)) Then 'State
            tbox_State.Text = Trim(dbDataSet.Tables("Payee").Rows(0).Item(4))
        Else : tbox_State.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Payee").Rows(0).Item(5)) Then 'ZipCode
            tbox_ZipCode.Text = Trim(dbDataSet.Tables("Payee").Rows(0).Item(5))
        Else : tbox_ZipCode.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Payee").Rows(0).Item(6)) Then 'Category
            opt_Category(dbDataSet.Tables("Payee").Rows(0).Item(6)).Checked = True
            OptionSelect = dbDataSet.Tables("Payee").Rows(0).Item(6)
        Else : opt_Category(17).Checked = True : OptionSelect = 17 : End If

        booDataChecked = False
    End Sub
    Private Sub AddControls() 'Add category controls
        Dim int_Top, int_Left As Integer
        Dim i As Integer

        'Create array of radio buttons for category selection  ( option buttons in Category frame)
        strSQL = "SELECT Category FROM TaxCategorys ORDER BY Id;"
        dbDataSet_Misc.Clear()
        dbDataSet_Misc.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter_Misc.Fill(dbDataSet_Misc, "Categorys")
        gbl_DstConnect.Close()

        int_Left = 8
        int_Top = 3
        For i = 0 To 17

            'Locate radio buttions
            int_Top = int_Top + 31
            If int_Top = 220 Then int_Top = 34
            If i = 6 Or i = 12 Then int_Left = int_Left + 126

            opt_Category(i) = New RadioButton
            With opt_Category(i)
                .Name = "opt_Category"
                .Tag = i
                ' .Enabled = False
                .Font = New Font("Ariel", 8, FontStyle.Regular)
                If i <= 16 Then .Text = dbDataSet_Misc.Tables("Categorys").Rows(i).Item(0) Else .Text = "None" 'Category
                .BackColor = System.Drawing.SystemColors.Control
                .SetBounds(int_Left, int_Top, 113, 21)
                fra_Category.Controls.Add(opt_Category(i))
                AddHandler .Click, AddressOf opt_Click
                AddHandler .CheckedChanged, AddressOf opt_CheckedChanged
                AddHandler .MouseHover, AddressOf All_MouseHover
            End With
        Next
    End Sub
    Private Sub ClearData() 'Clear form of all data
        tbox_Payee.Text = ""
        tbox_Address.Text = ""
        tbox_City.Text = ""
        tbox_State.Text = ""
        tbox_ZipCode.Text = ""
    End Sub
    Private Sub EnableEdits(blnStatus As Boolean)
        tbox_Payee.Enabled = blnStatus
        tbox_Address.Enabled = blnStatus
        tbox_City.Enabled = blnStatus
        tbox_State.Enabled = blnStatus
        tbox_ZipCode.Enabled = blnStatus
    End Sub
    Private Sub opt_Click(sender As Object, e As EventArgs)
        If tbox_Payee.Enabled = False Then opt_Category(OptionSelect).Checked = True Else OptionSelect = sender.tag
    End Sub
    Private Sub opt_CheckedChanged(sender As Object, e As EventArgs)
        If tbox_Payee.Enabled = True Then Call EditSave()
    End Sub


    'All command actions ( Edit,New/Restore,DeleteCancel,Exit/Save )
    Private Sub cmd_Edit_Click() Handles cmd_Edit.Click

        If tbox_Payee.Text = "" Then Exit Sub
        EditNew = 1 'Set variable to edit on save
        ListBox1.Enabled = False
        Call EnableEdits(True)

        cmd_Edit.Enabled = False
        cmd_NewRestore.Enabled = False
        cmd_NewRestore.Text = "Restore"
        cmd_NewRestore.Image = My.Resources.Resources.Restore
        cmd_DeleteCancel.Text = "Cancel"
        cmd_DeleteCancel.Image = My.Resources.Resources.Cancel
        tbox_Payee.Focus()
    End Sub
    Private Sub cmd_NewRestore_Click(sender As Object, e As EventArgs) Handles cmd_NewRestore.Click
        Call ClearData()
        If cmd_NewRestore.Text = "New" Then
            EditNew = 2 'Set variable to new for save
            ListBox1.Enabled = False
            ListBox1.SelectedIndex = -1

            Call EnableEdits(True)
            booNameCheck = False
            opt_Category(17).Checked = True
            tbox_Payee.Focus()

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

            'Confirm deletion before continuing
            frm_Message.Text = "19:3:0:1:3:Pressing [ Delete ] will remove the payee from the database"
            frm_Message.ShowDialog()
            If MessageResult = True Then

                'Delete payee from CheckPayee table
                strSQL = "SELECT Id FROM CheckPayee WHERE Id = " & intLookup & ";"
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
                Call ListData()
            End If

        ElseIf cmd_DeleteCancel.Text = "Cancel" Then
            Call EnableEdits(False)
            Call ClearData() 'Clear all entries
            Call FileOperationReset()
            If intTotalRecords <> 0 Then 'Allow listbox operations only if records found
                ListBox1.Visible = True
                ListBox1.Enabled = True

                If EditNew = 2 Then
                    EditNew = 0
                    Call ListData()
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
        If Trim(tbox_Payee.Text) = "" Then
            tbox_Payee.BackColor = Color.Aqua
            frm_Message.Text = "19:1:0:1:3:The payees Name must be Entered"
            frm_Message.ShowDialog()
            tbox_Payee.BackColor = Color.White
            tbox_Payee.Focus()
            Exit Sub
        End If

        Dim booPass As Boolean = False
        Dim optIndex As Integer
        For optIndex = 0 To 17 'Check if category selected
            If opt_Category(optIndex).Checked = True Then booPass = True : Exit For
        Next
        If booPass = False Or optIndex = 17 Then
            frm_Message.Text = "19:1:0:1:3:Please select a Category to continue, None is not a valid option"
            frm_Message.ShowDialog()
            Exit Sub
        End If

        'Save form to database
        Dim cb0 As New OleDb.OleDbCommandBuilder(dbAdapter)
        If EditNew = 1 Then 'Save on edits changes
            dbDataSet.Tables("Payee").Rows(0).Item(1) = Trim(tbox_Payee.Text)
            dbDataSet.Tables("Payee").Rows(0).Item(2) = Trim(tbox_Address.Text)
            dbDataSet.Tables("Payee").Rows(0).Item(3) = Trim(tbox_City.Text)
            dbDataSet.Tables("Payee").Rows(0).Item(4) = Trim(tbox_State.Text)
            dbDataSet.Tables("Payee").Rows(0).Item(5) = Trim(tbox_ZipCode.Text)
            dbDataSet.Tables("Payee").Rows(0).Item(6) = optIndex
            dbAdapter.Update(dbDataSet, "Payee")

        ElseIf EditNew = 2 Then 'Save new additions to database table
            Dim dsNewRow As DataRow
            dsNewRow = dbDataSet.Tables("Payee").NewRow()
            dsNewRow.Item("Payto") = Trim(tbox_Payee.Text)
            dsNewRow.Item("Address") = Trim(tbox_Address.Text)
            dsNewRow.Item("City") = Trim(tbox_City.Text)
            dsNewRow.Item("State") = Trim(tbox_State.Text)
            dsNewRow.Item("ZipCode") = Trim(tbox_ZipCode.Text)
            dsNewRow.Item("Category") = optIndex
            dbDataSet.Tables("Payee").Rows.Add(dsNewRow)
            dbAdapter.Update(dbDataSet, "Payee")
            intTotalRecords = intTotalRecords + 1

            'If first saved new record, update autonum with CustCode of saved record
            If AutoNum = 0 Then
                strSQL = "SELECT Id FROM CheckPayee ORDER by Id DESC;"
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

        ListBox1.Visible = True

        'Fill listbox with entries pertaining to active/all selection
        Call ListData()
        ListBox1.Visible = True
        ListBox1.Enabled = True
        ListBox1.Focus()
        Call EnableEdits(False)
        Call FileOperationReset()

        EditNew = 0 'Edit/new record reset
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


    'All texbox handlers
    Private Sub tbox_GotFocus(sender As Object, e As EventArgs) Handles tbox_Payee.GotFocus, tbox_Address.GotFocus, tbox_City.GotFocus, tbox_State.GotFocus, tbox_ZipCode.GotFocus
        strInitEntry = Trim(sender.Text)
        sender.BackColor = (Color.FromArgb(255, 255, 192))
    End Sub
    Private Sub tbox_LostFocus(sender As Object, e As EventArgs) Handles tbox_Payee.LostFocus, tbox_Address.LostFocus, tbox_City.LostFocus, tbox_State.LostFocus, tbox_ZipCode.LostFocus
        If EditNew = 2 And booNameCheck = False And sender.Name = "tbox_Payee" Then Call NameCheck() 'Check for repeat of same name
        sender.BackColor = Color.White
        If booCorrection = True Then Exit Sub

        If sender.Name = "tbox_State" And Trim(sender.text) <> "" Then
            If AlphaNumeric(sender.text) = False Then
                booCorrection = True
                frm_Message.Text = "19:1:0:1:3:Invalid Entry --- Only letters allow for state abbreviations"
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
        End If
    End Sub
    Private Sub tbox_TextChanged(sender As Object, e As EventArgs) Handles tbox_Payee.TextChanged, tbox_Address.TextChanged, tbox_City.TextChanged, tbox_State.TextChanged, tbox_ZipCode.TextChanged
        If booDataChecked = True Or EditNew = 0 Then Exit Sub 'Skip if pre_processed data
        Select Case sender.Name
            Case "tbox_Payee", "tbox_City"
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
    Private Sub tbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbox_Payee.KeyPress, tbox_Address.KeyPress, tbox_City.KeyPress, tbox_State.KeyPress, tbox_ZipCode.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            Select Case sender.Name
                Case "tbox_Payee" : tbox_Address.Focus()
                Case "tbox_Address" : tbox_City.Focus()
                Case "tbox_City" : tbox_State.Focus()
                Case "tbox_State" : tbox_ZipCode.Focus()
                Case "tbox_ZipCode" : tbox_Payee.Focus()
            End Select
        End If
    End Sub
    Private Sub tbox_Date_MouseClick(sender As Object, e As MouseEventArgs) Handles tbox_ZipCode.MouseClick
        If sender.text = "" Then sender.SelectionStart = 0
    End Sub


    'Handler sub routines
    Private Sub NameCheck()

        'Create string with and without a period at the end of the company name for payee name lookup
        Dim str1, str2 As String
        str1 = UCase(Trim(tbox_Payee.Text))
        If Microsoft.VisualBasic.Right(str1, 1) <> "." Then
            str2 = str1 & "."
        Else
            str2 = str1
            str1 = str1.Substring(0, str1.Length - 1)
        End If

        Dim booRepeat As Boolean = False
        For i = 1 To 2
            Select Case i
                Case Is = 1 : strSQL = "SELECT Payto FROM CheckPayee WHERE UCase(Payto) = '" & str1 & "';"
                Case Is = 2 : strSQL = "SELECT Payto FROM CheckPayee WHERE UCase(Payto) = '" & str2 & "';"
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
                frm_Message.Text = "19:1:0:1:14:There is 1 other payee on file with the same name"
            Else
                frm_Message.Text = "19:1:0:1:14:There are " & dbDataSet_Misc.Tables("NameCheck").Rows.Count & " other payees on file with the same name"
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
    Private Sub fra_MouseMove() Handles fra_List.MouseMove, fra_PayeeInfo.MouseMove, fra_Category.MouseMove 'Clear message
        intMessage = 0
        Call MouseMessages()
    End Sub
    Private Sub All_MouseHover(sender As Object, e As EventArgs) Handles ListBox1.MouseHover
        Select Case sender.name
            Case "ListBox1" : intMessage = 1
            Case "opt_Category" : intMessage = 2
        End Select
        Call MouseMessages()
    End Sub
    Private Sub MouseMessages()
        Select Case intMessage
            Case 0 : lbl_Message.Text = "" 'Clear message from screen
            Case 1 : lbl_Message.Text = "Select payee name from list to view and edit all payees information"
            Case 2 : lbl_Message.Text = "Select the category that applies to this payee"
        End Select
    End Sub

End Class