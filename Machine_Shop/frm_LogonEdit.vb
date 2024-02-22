Public Class frm_LogonEdit
    Dim dbAdapter As OleDb.OleDbDataAdapter
    Dim dbDataSet As New DataSet

    Dim strSQL As String
    Dim EditNew, inc, intRestore, intSelectedRecord, intTotalRecords As Integer

    'All form related events
    Private Sub frm_Activated() Handles Me.Activated
        If frm_Main.AutoLogon.Checked = True Then chk_AutoLogon.Checked = True 'Mark Automatic Logon checkbox with a check
    End Sub
    Private Sub frm_Load() Handles Me.Load

        Me.Text = "*** Password Edit ***"
        Call EnableEdits(False)
        EditNew = 0
        EnableNavigation(False) 'Disable navigation buttons

        strSQL = "SELECT Id,UserName,UserPassword From Users ORDER BY Id;"
        dbDataSet.Clear()
        dbDataSet.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter.Fill(dbDataSet, "Users")
        gbl_DstConnect.Close()

        intTotalRecords = dbDataSet.Tables("Users").Rows.Count
        Select Case intTotalRecords
            Case Is <= 2 'No additional records found
                inc = 1
                Textbox_Clear()
                cmd_Edit.Enabled = False 'Disable Edit button
                cmd_DeleteCancel.Enabled = False 'Disable delete button
                chk_AutoLogon.Checked = True
            Case Is >= 3
                inc = 2
                Call ShowRecords()
        End Select
        If intTotalRecords >= 4 Then EnableNavigation(True) 'Enable navigation buttons

    End Sub
    Private Sub Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        dbDataSet.Clear()
        dbDataSet.Tables.Clear()
    End Sub
    Private Sub ShowRecords()

        If Not IsDBNull(dbDataSet.Tables("Users").Rows(inc).Item(1)) Then 'UserName
            tbox_UserId.Text = Trim(dbDataSet.Tables("Users").Rows(inc).Item(1))
        Else : tbox_UserId.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Users").Rows(inc).Item(2)) Then 'UserPassword
            tbox_Password.Text = Trim(dbDataSet.Tables("Users").Rows(inc).Item(2))
        Else : tbox_Password.Text = "" : End If

    End Sub
    Public Sub EnableNavigation(blnStatus As Boolean)

        If intTotalRecords < 3 Then blnStatus = False 'Disable navigation request if only one record to view

        'Disable navigation buttons
        cmd_Previous.Enabled = blnStatus
        cmd_Next.Enabled = blnStatus

    End Sub
    Private Sub FileOperationReset()

        cmd_Edit.Image = My.Resources.Resources.Edit
        cmd_NewRestore.Image = My.Resources.Resources._New
        cmd_DeleteCancel.Image = My.Resources.Resources.Delete
        cmd_ExitSave.Image = My.Resources.Resources._Exit

        cmd_Edit.Text = "Edit"
        cmd_NewRestore.Text = "New"
        cmd_DeleteCancel.Text = "Delete"
        cmd_ExitSave.Text = "Exit"

        cmd_Edit.Enabled = True   'View Edit button
        cmd_NewRestore.Enabled = True   'View new button
        cmd_DeleteCancel.Enabled = True   'View delete button
        cmd_ExitSave.Enabled = True   'View exit button
    End Sub
    Private Sub Textbox_Clear()
        tbox_UserId.Text = ""
        tbox_Password.Text = ""
    End Sub
   
    'All command actions ( Edit,New/Restore,DeleteCancel,Exit/Save )
    Private Sub cmd_Previous_Click() Handles cmd_Previous.Click
        If inc > 2 Then inc = inc - 1 : ShowRecords()
    End Sub
    Private Sub cmd_Next_Click() Handles cmd_Next.Click
        If inc < intTotalRecords - 1 Then inc = inc + 1 : ShowRecords()
    End Sub
    Private Sub cmd_Edit_Click() Handles cmd_Edit.Click 'Edit records
        EditNew = 1

        cmd_NewRestore.Image = My.Resources.Resources.Restore
        cmd_DeleteCancel.Image = My.Resources.Resources.Cancel
        cmd_ExitSave.Image = My.Resources.Resources.Save

        cmd_NewRestore.Text = "Restore"
        cmd_DeleteCancel.Text = "Cancel"
        cmd_ExitSave.Text = "Save"

        cmd_Edit.Enabled = False
        cmd_NewRestore.Enabled = False
        cmd_DeleteCancel.Enabled = True
        cmd_ExitSave.Enabled = False

        Call EnableEdits(True)
        EnableNavigation(False) 'Enable navigation buttons
        tbox_UserId.Focus()
    End Sub
    Private Sub cmd_NewRestore_Click() Handles cmd_NewRestore.Click 'New/Restore records
        If cmd_NewRestore.Text = "New" Then
            EditNew = 2

            cmd_DeleteCancel.Image = My.Resources.Resources.Cancel
            cmd_ExitSave.Image = My.Resources.Resources.Save

            cmd_DeleteCancel.Text = "Cancel"
            cmd_ExitSave.Text = "Save"

            cmd_Edit.Enabled = False  'Enable edit button
            cmd_NewRestore.Enabled = False  'Enable new button
            cmd_DeleteCancel.Enabled = True   'View cancel button
            cmd_ExitSave.Enabled = True

            Call EnableEdits(True)
            EnableNavigation(False)
            Textbox_Clear()
            tbox_UserId.Focus()

        ElseIf cmd_NewRestore.Text = "Restore" Then 'Replace original values from recordset
            ShowRecords()
            cmd_NewRestore.Enabled = False
            tbox_UserId.Focus()
        End If
    End Sub
    Private Sub cmd_DeleteCancel_Click() Handles cmd_DeleteCancel.Click 'Delete/Cancel records
        If cmd_DeleteCancel.Text = "Delete" Then

            frm_Message.Text = "4:3:9:4:1:Delete this record"
            frm_Message.ShowDialog()
            If MessageResult = True Then 'Delete record from users table

                Dim cb As New OleDb.OleDbCommandBuilder(dbAdapter)
                dbDataSet.Tables("Users").Rows(inc).Delete()
                dbAdapter.Update(dbDataSet, "Users")
                intTotalRecords = intTotalRecords - 1 : If intTotalRecords <= 3 Then EnableNavigation(False) 'Subtract record from record total
                inc = inc - 1 : If inc = 1 Then If intTotalRecords > 2 Then inc = inc + 1 Else Textbox_Clear()

                Select Case intTotalRecords
                    Case Is <= 2 'No user names and passwords saved
                        Textbox_Clear() 'Show empty textboxes when there is no user names and passwords saved
                        chk_AutoLogon.Checked = True 'Enter check mark into autologon check box
                        cmd_Edit.Enabled = False   'Enable Edit button
                        cmd_DeleteCancel.Enabled = False   'Enable delete button
                        cmd_ExitSave.Enabled = True   'Enable exit button
                    Case Is >= 3
                        ShowRecords()
                        FileOperationReset()
                End Select
                If intTotalRecords >= 4 Then EnableNavigation(True) 'Enable navigation buttons
            End If

        ElseIf cmd_DeleteCancel.Text = "Cancel" Then
            EditNew = 0

            If intTotalRecords <= 2 Then 'Show empty textboxes when there is no user names and passwords saved

                cmd_NewRestore.Image = My.Resources.Resources._New
                cmd_ExitSave.Image = My.Resources.Resources._Exit

                cmd_NewRestore.Text = "New"
                cmd_ExitSave.Text = "Exit"

                cmd_Edit.Enabled = False
                cmd_NewRestore.Enabled = True
                cmd_DeleteCancel.Enabled = False
                cmd_ExitSave.Enabled = True
                Textbox_Clear()
            Else
                If intTotalRecords > 3 Then EnableNavigation(True)
                ShowRecords()
                FileOperationReset()
            End If
            Call EnableEdits(False)
        End If
    End Sub
    Private Sub cmd_ExitSave_Click() Handles cmd_ExitSave.Click 'Exit/Save records
        If cmd_ExitSave.Text = "Exit" Then Me.Close() : Exit Sub

        'Validate entries
        If IsDBNull(tbox_UserId.Text) Or Trim(tbox_UserId.Text) = "" Then
            tbox_UserId.Focus()
            frm_Message.Text = "4:1:7:1:1:User Name must be Entered"
            frm_Message.ShowDialog()
            tbox_UserId.Focus()
            Exit Sub
        End If

        If IsDBNull(tbox_Password.Text) Or Trim(tbox_Password.Text) = "" Then
            frm_Message.Text = "4:1:8:1:1:Password must be Entered"
            frm_Message.ShowDialog()
            tbox_Password.Focus()
            Exit Sub
        End If

        'Test for duplicate userid (duplicate allowed on edit of same original record)
        Dim i As Integer
        For i = 2 To intTotalRecords - 1
            If tbox_UserId.Text = Trim(dbDataSet.Tables("Users").Rows(i).Item(1)) Then
                If EditNew = 1 And inc = i And tbox_UserId.Text = Trim(dbDataSet.Tables("Users").Rows(inc).Item(1)) Then
                    Exit For 'Same userid allowed on edit of original record
                End If
                frm_Message.Text = "4:1:7:1:1:User name is invalid"
                frm_Message.ShowDialog()
                tbox_UserId.Focus()
                Exit Sub
            End If
        Next

        'Test for duplicate password(duplicate allowed on edit of same original record)
        For i = 2 To intTotalRecords - 1
            If tbox_Password.Text = Trim(dbDataSet.Tables("Users").Rows(i).Item(2)) Then
                If EditNew = 1 And inc = i And tbox_Password.Text = Trim(dbDataSet.Tables("Users").Rows(inc).Item(2)) Then
                    Exit For 'Same password allowed on edit of original record
                End If
                frm_Message.Text = "4:1:8:1:1:Password is invalid"
                frm_Message.ShowDialog()
                tbox_Password.Focus()
                Exit Sub
            End If
        Next

        'Build sql string for save operation
        Dim dbBuild As New OleDb.OleDbCommandBuilder(dbAdapter)
        If EditNew = 1 Then 'Edit existing record
            dbDataSet.Tables("Users").Rows(inc).Item(1) = tbox_UserId.Text
            dbDataSet.Tables("Users").Rows(inc).Item(2) = tbox_Password.Text
        ElseIf EditNew = 2 Then 'Insert new record
            Dim dsNewRow As DataRow
            dsNewRow = dbDataSet.Tables("Users").NewRow()
            dsNewRow.Item("UserName") = tbox_UserId.Text
            dsNewRow.Item("UserPassword") = tbox_Password.Text
            dbDataSet.Tables("Users").Rows.Add(dsNewRow)
            inc = inc + 1
            intTotalRecords = intTotalRecords + 1 'Add record to record total
        End If
        dbAdapter.Update(dbDataSet, "Users")

        'ReSequence dataset with new data
        strSQL = "SELECT Id,UserName,UserPassword From Users ORDER BY Id;"
        dbDataSet.Clear()
        dbDataSet.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter.Fill(dbDataSet, "Users")
        gbl_DstConnect.Close()

        'Locate new/updated record in dataset
        For i = 2 To intTotalRecords - 1
            If dbDataSet.Tables("Users").Rows(i).Item(1) = tbox_Password.Text Then Exit For
        Next

        Call ShowRecords()
        Call EnableEdits(False)
        Call FileOperationReset()
        If intTotalRecords > 3 Then EnableNavigation(True)
        EditNew = 0 'Edit/new record reset
    End Sub   
    Private Sub chk_AutoLogon_Click1() Handles chk_AutoLogon.Click

        If chk_AutoLogon.Checked = False Then
            If intTotalRecords <= 2 Then
                chk_AutoLogon.Checked = True 'Reset autologon back on, There are no userids or passwords in database
                frm_Message.Text = "4:1:4:3:13:be entered first before allowing"
                frm_Message.ShowDialog()
            Else
                frm_Main.AutoLogon.Checked = False
                Dim dbBuild As New OleDb.OleDbCommandBuilder(dbAdapter)
                dbDataSet.Tables("Users").Rows(0).Item(2) = "AutoLogonNo"
                dbAdapter.Update(dbDataSet, "Users")
            End If
        Else
            frm_Main.AutoLogon.Checked = True
            Dim dbBuild As New OleDb.OleDbCommandBuilder(dbAdapter)
            dbDataSet.Tables("Users").Rows(0).Item(2) = "AutoLogonYes"
            dbAdapter.Update(dbDataSet, "Users")
        End If

    End Sub
    Private Sub EnableEdits(blnStatus As Boolean)
        tbox_UserId.Enabled = blnStatus
        tbox_Password.Enabled = blnStatus
    End Sub
   
    'All texbox handlers
    Private Sub Tbox_GotFocus(sender As Object, e As EventArgs) Handles tbox_UserId.GotFocus, tbox_Password.GotFocus
        sender.BackColor = (Color.FromArgb(255, 255, 192))
    End Sub
    Private Sub Tbox_LostFocus(sender As Object, e As EventArgs) Handles tbox_UserId.LostFocus, tbox_Password.LostFocus
        sender.BackColor = Color.White
    End Sub
    Private Sub Tbox_TextChanged() Handles tbox_UserId.TextChanged, tbox_Password.TextChanged
        If EditNew = 1 Then
            cmd_NewRestore.Enabled = True
            cmd_ExitSave.Enabled = True
        End If
    End Sub
    Private Sub Tbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbox_UserId.KeyPress, tbox_Password.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            Select Case DirectCast(sender, TextBox).Name
                Case tbox_UserId.Name : tbox_Password.Focus()
                Case tbox_Password.Name : tbox_UserId.Focus()
            End Select
        End If
    End Sub

End Class