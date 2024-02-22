Public Class frm_Logon
    Dim dbAdapter, dbAdapter_SystemData As OleDb.OleDbDataAdapter
    Dim dbDataSet, dbDataSet_SystemData As New DataSet
    Private Sub frm_Logon_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        tbox_UserId.Focus()
    End Sub
    Private Sub Close_Form()
        dbDataSet.Clear()
        dbDataSet.Tables.Clear()
    End Sub

    'All command actions 
    Private Sub cmd_Exit_Click() Handles cmd_Exit.Click
        tbox_UserId.Text = ""
        tbox_Password.Text = ""
        If Me.Text = "Logon" Then 'Stop program
            
            Call Close_Form()
            End
        Else 'Close form
            Me.Close()
        End If
    End Sub
    Private Sub cmd_OK_Click(sender As Object, e As EventArgs) Handles cmd_OK.Click, cmd_OK.DoubleClick
        If IsDBNull(tbox_UserId) Or Trim(tbox_UserId.Text) = "" Then

            frm_Message.Text = "5:1:5:1:1:Enter User Name"
            frm_Message.ShowDialog()
            tbox_UserId.Focus()
            Exit Sub
        End If

        If IsDBNull(tbox_Password) Or Trim(tbox_Password.Text) = "" Then
            frm_Message.Text = "5:1:6:1:1:Password must be Entered"
            frm_Message.ShowDialog()
            tbox_Password.Focus()
            Exit Sub
        End If

        'Open Users database to check userid & password validity
        Dim strSQL As String
        strSQL = "SELECT UserName,UserPassword From Users ORDER BY UserName;"
        dbDataSet.Clear()
        dbDataSet.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter.Fill(dbDataSet, "Logon")
        gbl_DstConnect.Close()

        'Check for valid id & password
        Dim booPass As Boolean = False
        For inc = 0 To dbDataSet.Tables("Logon").Rows.Count - 1
            If dbDataSet.Tables("Logon").Rows(inc).Item(0) = Trim(tbox_UserId.Text) Then
                If dbDataSet.Tables("Logon").Rows(inc).Item(1) = Trim(tbox_Password.Text) Then booPass = True : Exit For
            End If
        Next

        If booPass = False Then
            frm_Message.Text = "5:1:10:1:1:Invalid data Entries"
            frm_Message.ShowDialog()
            tbox_UserId.Text = ""
            tbox_Password.Text = ""
            tbox_UserId.Focus()
            Exit Sub
        Else

            'Clear entries
            tbox_UserId.Text = ""
            tbox_Password.Text = ""

            If frm_Main.Text = "" Then 'Log on requested from initial startup of program
                dbDataSet_SystemData.Clear()
                dbDataSet_SystemData.Tables.Clear()
                gbl_DstConnect.Open()
                dbAdapter_SystemData = New OleDb.OleDbDataAdapter("SELECT CompanyName FROM System", gbl_DstConnect)
                dbAdapter_SystemData.Fill(dbDataSet_SystemData, "System")
                gbl_DstConnect.Close()
                frm_Main.Text = dbDataSet_SystemData.Tables("System").Rows(0).Item(0)
                Me.Close()
                Exit Sub
            End If

            Select Case Trim(Me.Text)
                Case Is = "Logon to enter logon editor"
                    Me.Close()
                    frm_LogonEdit.ShowDialog()
                Case Is = "Logon to enter System Setup"
                    Me.Close()
                    frm_SystemSetup.ShowDialog()
            End Select
        End If
    End Sub


    'All texbox handlers
    Private Sub tbox_UserId_GotFocus(sender As Object, e As EventArgs) Handles tbox_UserId.GotFocus, tbox_Password.GotFocus
        sender.BackColor = (Color.FromArgb(255, 255, 192))
    End Sub
    Private Sub tbox_UserId_LostFocus(sender As Object, e As EventArgs) Handles tbox_UserId.LostFocus, tbox_Password.LostFocus
        sender.BackColor = Color.White
    End Sub
    Private Sub Tbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbox_UserId.KeyPress, tbox_Password.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            If Trim(tbox_UserId.Text) <> "" And Trim(tbox_Password.Text) <> "" Then cmd_OK.PerformClick()
            Select Case sender.Name
                Case tbox_UserId.Name : tbox_Password.Focus()
                Case tbox_Password.Name : tbox_UserId.Focus()
            End Select
        End If
    End Sub

End Class