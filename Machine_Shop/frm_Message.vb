Public Class frm_Message
    Dim FormIndex, ButtonIndex, TitleIndex, MessageIndex, LineTop, LineBottom, cmd_ActionSpace As Integer
    Dim Message As String

    Private Sub frm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim WarningArray() As String = Me.Text.Split(":")
        FormIndex = Convert.ToInt32(WarningArray(0))
        ButtonIndex = Convert.ToInt32(WarningArray(1))
        TitleIndex = Convert.ToInt32(WarningArray(2))
        LineTop = Convert.ToInt32(WarningArray(3))
        LineBottom = Convert.ToInt32(WarningArray(4))
        lbl_Message2.Text = WarningArray(5)
        Call WarningMessage()
    End Sub
    Private Sub WarningMessage()

        Select Case TitleIndex
            Case 0 : Me.Text = ""
            Case 1 : Me.Text = "                                        * * S Y S T E M   I N I T I A L I Z E * *" 'Main/SystemSetup
            Case 2 : Me.Text = "                                         * * D A T A B A S E   B A C K U P * *"  'Main
            Case 3 : Me.Text = "                                           * * D A T A B A S E   E R R O R * *" 'Main
            Case 4 : Me.Text = "              * * Auto Logon Error * *" 'LogonEdit
            Case 5 : Me.Text = "            * * User ID Error * *" 'Logon
            Case 6 : Me.Text = "         * * Password Error * *" 'Logon
            Case 7 : Me.Text = "                  * * User ID Error * *" 'LogonEdit
            Case 8 : Me.Text = "                * * Password Error * *" 'LogonEdit
            Case 9 : Me.Text = "                   *  W A R N I N G  *" 'LogonEdit
            Case 10 : Me.Text = "    * * E N T R Y   D E N I E D * *" 'Logon
        End Select

        Select Case LineTop
            Case 0 : lbl_Message1.Text = ""
            Case 1 : lbl_Message1.Text = "*  *  W A R N I N G  *  *"
            Case 2 : lbl_Message1.Text = "*  *  *  C O N F O R M A T I O N  *  *  *"
            Case 3 : lbl_Message1.Text = "User ID and Password must"
            Case 4 : lbl_Message1.Text = "Are you sure you want to"
            Case 5 : lbl_Message1.Text = "Certification restriction will not allow the highlighted records to be invoiced"
            Case 6 : lbl_Message1.Text = "Customer has special shipping arrangements"
            Case 7 : lbl_Message1.Text = "*  *  *  *  Did all the forms print correctly  *  *  *  *"
            Case 8 : lbl_Message1.Text = "*  *  * Search Error *  *  *"
            Case 9 : lbl_Message1.Text = "*  *  *  S A V E D   D A T A  *  *  *"
            Case 10 : lbl_Message1.Text = "*  *  * N O  P U R C H A S E  O R D E R S  O N  R E C O R D *  *  *"
            Case 11 : lbl_Message1.Text = "*  *  *  Multiple customers share the same drawing number  *  *  *"
            Case 12 : lbl_Message1.Text = "*  *  * Customer Code Error *  *  *"
            Case 13 : lbl_Message1.Text = "* * There are no drawings numbers on file for this customer * *"
            Case 14 : lbl_Message1.Text = "*  *  * D U P L I C A T E   W A R N I N G  *  *  *"
            Case 15 : lbl_Message1.Text = "* * *  I N V E N T O R Y  W A S  N O T   U P D A T E D  * * *"
            Case 16 : lbl_Message1.Text = "*  *  *  S E A R C H   F A I L U R E  *  *  *"
            Case 17 : lbl_Message1.Text = "*  *  *  R O W   D E L E T I O N   E R R O R  *  *  *"
            Case 18 : lbl_Message1.Text = "*  *  *  S U C C E S S  *  *  *"
            Case 19 : lbl_Message1.Text = "*  *  *  M O D I F I C A T I O N   E R R O R  *  *  *"
            Case 20 : lbl_Message1.Text = "*  *  *  D A T E   E R R O R *  *  *"
            Case 21 : lbl_Message1.Text = "*  *  *  T R A N S A C T I O N   E R R O R *  *  *"
            Case 22 : lbl_Message1.Text = "*  *  *  C H E C K   N U M B E R   E R R O R *  *  *"
            Case 23 : lbl_Message1.Text = "*  *  *  P A Y E E   N A M E   E R R O R *  *  *"
            Case 24 : lbl_Message1.Text = "*  *  *  C A T E G O R Y   S E L E C T I O N   E R R O R *  *  *"
            Case 25 : lbl_Message1.Text = "*  *  *  A M O U N T   E R R O R *  *  *"
            Case 26 : lbl_Message1.Text = "*  *  *  S A M E  C H E C K  N U M B E R  *  *  *"
            Case 27 : lbl_Message1.Text = "*  *  *  C A T E G O R Y   E N T R Y   E R R O R *  *  *"
            Case 28 : lbl_Message1.Text = "*  *  *  R E C O N C I L E   E R R O R  *  *  *"
            Case 29 : lbl_Message1.Text = "*  *  *  S A V E  D A T A  E R R O R  *  *  *"
            Case 30 : lbl_Message1.Text = "*  *  *  I N S U F F I C E N T   F U N D S  *  *  *"
            Case 31 : lbl_Message1.Text = "*  *  *  T E M P O R A R Y  C H A N G E S  F O U N D  *  *  *"
            Case 32 : lbl_Message1.Text = "*  *  *  P R I N T E R  S E T U P  *  *  *"
            Case 33 : lbl_Message1.Text = "*  *  *  P R I N T  V E R I F I C A T I O N  *  *  *"
            Case 34 : lbl_Message1.Text = "*  *  *  P R I N T  F A I L U R E  *  *  *"
            Case 35 : lbl_Message1.Text = "*  *  *  A L L  I N V O I C E S  A R E  P A I D  *  *  *"
        End Select

        Select Case LineBottom
            Case 0 : lbl_Message3.Text = ""
            Case 1 : lbl_Message3.Text = "*************************************"
            Case 2 : lbl_Message3.Text = "* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *"
            Case 3 : lbl_Message3.Text = "* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *"
            Case 4 : lbl_Message3.Text = "* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *"
            Case 5 : lbl_Message3.Text = "* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *"
            Case 6 : lbl_Message3.Text = "User must first set up a logon name with password"
            Case 7 : lbl_Message3.Text = "All stored records for the running of the business will be permanently erased from system"
            Case 8 : lbl_Message3.Text = "Press Exit to end program or Continue to complete setup"
            Case 9 : lbl_Message3.Text = "Please check before possibly starting a new file on the same employee"
            Case 10 : lbl_Message3.Text = "All open transactions must be closed, to delete customer from database"
            Case 11 : lbl_Message3.Text = "Press Cancel and uncheck active to hide customer and retain all related invoiced data"
            Case 12 : lbl_Message3.Text = "Please check before possibly starting a new file on the same company."
            Case 13 : lbl_Message3.Text = "Automatic Logon to be turned off"
            Case 14 : lbl_Message3.Text = "Please check before possibly starting a new file on the same payee."
        End Select

        'Msgbox size and location 
        cmd_ActionSpace = 36 'Default space between cmd_Action Buttons
        cmd_Action1.Size = New Size(86, 25) 'Default size of cmd_Action button 1
        cmd_Action2.Size = New Size(86, 25) 'Default size of cmd_Action button 2
        Me.StartPosition = FormStartPosition.Manual
        Me.ControlBox = False
        Select Case FormIndex

            Case 0 'Main form                
                Me.Top = (Screen.PrimaryScreen.Bounds.Height - Me.Height) / 2
                Me.Left = (Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2
                Call Lbl_MessageData(1)

            Case 1 'System Setup form
                Me.Top = frm_SystemSetup.Top - 130
                Me.Left = frm_SystemSetup.Left + 10
                'Me.Left = frm_SystemSetup.Left + ((frm_SystemSetup.Width - Me.Width) / 2)
                Call Lbl_MessageData(2)

            Case 2 'Employee form
                Me.Top = frm_Employees.Top + 220
                Me.Left = frm_Employees.Left + 621
                Call Lbl_MessageData(1)

            Case 3 'Customer form
                Me.Top = frm_Customer.Top + 278
                Me.Left = frm_Customer.Left + 416
                Call Lbl_MessageData(3)

            Case 4 'LogonEdit form
                Me.Top = frm_LogonEdit.Top + 61
                Me.Left = frm_LogonEdit.Left + 33
                Call Lbl_MessageData(4)

            Case 5 'Logon form
                Me.Top = frm_Logon.Top + 53
                Me.Left = frm_Logon.Left + 27
                Call Lbl_MessageData(5)

            Case 6 'Customer's Purchase order form
                Me.Top = frm_PurchaseOrders.Top + 246
                Me.Left = frm_PurchaseOrders.Left + ((frm_PurchaseOrders.Width - Me.Width) / 2)
                Call Lbl_MessageData(3)

            Case 7 'Invoice Order form
                Dim str1 As String = Microsoft.VisualBasic.Left(frm_InvoiceOrder.Text, 28)
                If Microsoft.VisualBasic.Left(frm_InvoiceOrder.Text, 28) = "Customers Invoice Orders ( S" Then
                    Me.Top = frm_InvoiceOrder.Top + ((frm_InvoiceOrder.Height - Me.Height) / 2)
                Else
                    Me.Top = frm_InvoiceOrder.Top + frm_InvoiceOrder.Height + 10
                End If
                Me.Left = frm_InvoiceOrder.Left + ((frm_InvoiceOrder.Width - Me.Width) / 2)
                Call Lbl_MessageData(3)

            Case 8 'Invoice Search order form
                Me.Top = frm_InvoiceSearch.Top + 450
                Me.Left = frm_InvoiceSearch.Left + 306
                Call Lbl_MessageData(3)

            Case 9 'Invoice reorder form
                Me.Top = frm_InvoiceReorder.Top + 240 '540
                Me.Left = frm_InvoiceReorder.Left + 287  '297
                Call Lbl_MessageData(3)

            Case 10 'Invoice paid form
                Me.Top = frm_InvoicePaid.Top + 295
                Me.Left = frm_InvoicePaid.Left + 298
                Call Lbl_MessageData(3)

            Case 11 'Work edit schedule form
                Me.Top = (frm_WorkEditSchedule.Top + ((frm_WorkEditSchedule.Height - Me.Height) / 2)) - 20
                Me.Left = frm_WorkEditSchedule.Left + ((frm_WorkEditSchedule.Width - Me.Width) / 2)
                Call Lbl_MessageData(3)

            Case 12 'Drawing History Report
                Me.Top = frm_DrawingHistory.Top + ((frm_DrawingHistory.Height - Me.Height) / 2)
                Me.Left = frm_DrawingHistory.Left + 408
                Call Lbl_MessageData(3)

            Case 13 'Inventory
                Me.Top = frm_Inventory.Top + ((frm_Inventory.Height - Me.Height) / 2)
                Me.Left = frm_Inventory.Left + 266
                Call Lbl_MessageData(3)

            Case 14 'Checkbook (Banking)
                Me.Top = frm_Checkbook.Top + ((frm_Checkbook.Height - Me.Height) / 2)
                Me.Left = frm_Checkbook.Left + 266
                Call Lbl_MessageData(3)

            Case 15 'Checkbook (Checks)
                Me.Top = frm_CheckbookChecks.Top + 191
                Me.Left = frm_CheckbookChecks.Left + 168
                Call Lbl_MessageData(3)

            Case 16 'Checkbook (Deposits)
                Me.Top = frm_CheckbookDepositsATM.Top + 140
                Me.Left = frm_CheckbookDepositsATM.Left + 160
                Call Lbl_MessageData(3)

            Case 17 'Checkbook (Reconcile)
                Me.Top = frm_CheckbookReconcile.Top + 9
                Me.Left = frm_CheckbookReconcile.Left + ((frm_CheckbookReconcile.Width - Me.Width) / 2)
                Call Lbl_MessageData(3)

            Case 18 'Payroll
                Me.Top = frm_Payroll.Top + 220
                Me.Left = frm_Payroll.Left + 299
                Call Lbl_MessageData(3)

            Case 19 'Payee editor
                Me.Top = frm_PayeeEditor.Top + 200
                Me.Left = frm_PayeeEditor.Left + ((frm_PayeeEditor.Width - Me.Width) / 2)
                Call Lbl_MessageData(3)

            Case 20 'Employee directory
                Me.Top = frm_EmployeeDirectory.Top + ((frm_EmployeeDirectory.Height - Me.Height) / 2)
                Me.Left = frm_EmployeeDirectory.Left + ((frm_EmployeeDirectory.Width - Me.Width) / 2)
                Call Lbl_MessageData(3)

            Case 21 'Customer directory
                Me.Top = frm_CustomerDirectory.Top + ((frm_CustomerDirectory.Height - Me.Height) / 2)
                Me.Left = frm_CustomerDirectory.Left + ((frm_CustomerDirectory.Width - Me.Width) / 2)
                Call Lbl_MessageData(3)

        End Select

        'Message setup colors
        Dim Color1, Color2, Color3 As Color
        Select Case FormIndex
            Case 0, 1, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 16, 17, 19 : Color1 = Color.FromArgb(255, 255, 192) 'Yellow frame
            Case 2, 3, 15, 18 : Color1 = Color.MediumTurquoise
            Case 20 : Color1 = Color.FromArgb(220, 255, 255) 'Not used but saved as something different
        End Select
        Color2 = Color.FromArgb(255, 192, 192)
        Color3 = Color.Red
        Me.BackColor = Color1
        lbl_Top.BackColor = Color1
        fra_Msgbox.BackColor = Color2
        lbl_Message1.BackColor = Color2
        lbl_Message2.BackColor = Color2
        lbl_Message3.BackColor = Color2
        cmd_Action1.BackColor = Color3
        cmd_Action2.BackColor = Color3

        'Message setup buttons
        Select Case ButtonIndex
            Case 1 'One button
                cmd_Action1.Left = (fra_Msgbox.Width - cmd_Action1.Width) / 2
                cmd_Action2.Visible = False
                cmd_Action3.Visible = False
                cmd_Action4.Visible = False
            Case Else 'Two button
                cmd_Action1.Left = (fra_Msgbox.Width / 2) - (cmd_Action1.Width + cmd_ActionSpace)
                cmd_Action2.Visible = True
                cmd_Action2.Left = (fra_Msgbox.Width / 2) + cmd_ActionSpace
                cmd_Action3.Visible = False
                cmd_Action4.Visible = False
        End Select

        'Message setup button messages
        Select Case ButtonIndex
            Case 1 'One button
                cmd_Action1.Text = "Ok"
            Case 2 'Two button Yes/No 
                cmd_Action1.Text = "Yes"
                cmd_Action2.Text = "No"
            Case 3 ''Two button Delete/Cancel
                cmd_Action1.Text = "Delete"
                cmd_Action2.Text = "Cancel"
            Case 4 'Two button Exit/Continue
                cmd_Action1.Text = "Exit"
                cmd_Action2.Text = "Continue"
            Case 5 'Two button Clear Refills/Cancel
                cmd_Action1.Text = "Clear refills"
                cmd_Action2.Text = "Cancel"
            Case 6 'Two button Print/Cancel
                cmd_Action1.Text = "Print"
                cmd_Action2.Text = "Cancel"
            Case 7 'Two button Accept/Cancel
                cmd_Action1.Text = "Accept"
                cmd_Action2.Text = "Cancel"
            Case 8 'Two button Ok/Cancel
                cmd_Action1.Text = "Ok"
                cmd_Action2.Text = "Cancel"
            Case 9 'Two button Continue/Cancel
                cmd_Action1.Text = "Continue"
                cmd_Action2.Text = "Cancel"
        End Select

    End Sub
    Private Sub Lbl_MessageData(index As Integer)
        Select Case index
            Case 1
                If FormIndex = 0 Then
                    Me.FormBorderStyle = 2
                    Me.Size = New Size(468, 166) 'Form size
                    fra_Msgbox.SetBounds(15, 9, 418, 100) 'Frame location - size
                    lbl_Top.SetBounds(10, 0, 428, 15)
                    cmd_Action1.Top = 64
                    cmd_Action2.Top = 64
                Else
                    Me.FormBorderStyle = 0 'Frameless 
                    Me.Size = New Size(547, 153) 'Form size      New Size(547, 124) 
                    fra_Msgbox.SetBounds(15, 9, 518, 129) 'Frame location - size 
                    lbl_Top.SetBounds(10, 0, 528, 15)
                    cmd_Action1.Top = 74
                    cmd_Action2.Top = 74
                End If
                lbl_Message1.SetBounds(5, 12, fra_Msgbox.Width - 10, 17)
                lbl_Message2.SetBounds(5, 28, fra_Msgbox.Width - 10, 17)
                lbl_Message3.SetBounds(5, 45, fra_Msgbox.Width - 10, 17)
               
            Case 2
                frm_SystemSetup.Height = 440
                Me.FormBorderStyle = 0
                Me.Size = New Size(575, 129)
                fra_Msgbox.SetBounds(9, 1, 558, 120)
                lbl_Top.SetBounds(5, 0, Me.Width - 10, 7)
                lbl_Message1.SetBounds(5, 18, fra_Msgbox.Width - 10, 17)
                lbl_Message2.SetBounds(5, 38, fra_Msgbox.Width - 10, 17)
                lbl_Message3.SetBounds(5, 55, fra_Msgbox.Width - 10, 17)
                cmd_Action1.Top = 80
                cmd_Action2.Top = 80
            Case 3
                Me.FormBorderStyle = 5 'Frameless 
                Me.Size = New Size(547, 153) 'Form size
                fra_Msgbox.SetBounds(15, 9, 518, 129) 'Frame location - size
                lbl_Top.SetBounds(5, 0, Me.Width - 10, 15)
                lbl_Message1.SetBounds(5, 12, fra_Msgbox.Width - 10, 17)
                lbl_Message2.SetBounds(5, 32, fra_Msgbox.Width - 10, 17)
                lbl_Message3.SetBounds(5, 53, fra_Msgbox.Width - 10, 17)
                cmd_Action1.Top = 78
                cmd_Action2.Top = 78
            Case 4
                Me.FormBorderStyle = 5
                Me.Size = New Size(238, 150)
                fra_Msgbox.SetBounds(7, 0, 208, 104)
                lbl_Top.SetBounds(5, 0, Me.Width - 10, 8)
                lbl_Message1.SetBounds(5, 14, fra_Msgbox.Width - 10, 17)
                lbl_Message2.SetBounds(5, 30, fra_Msgbox.Width - 10, 17)
                lbl_Message3.SetBounds(5, 46, fra_Msgbox.Width - 10, 17)
                If ButtonIndex = 3 Then cmd_Action1.Size = New Size(64, 25) : cmd_Action2.Size = New Size(64, 25)
                cmd_ActionSpace = 18
                cmd_Action1.Top = 68
                cmd_Action2.Top = 68
            Case 5
                Me.FormBorderStyle = 5
                Me.Size = New Size(198, 130)
                fra_Msgbox.SetBounds(7, 0, 168, 84)
                lbl_Top.SetBounds(5, 0, Me.Width - 10, 8)
                lbl_Message1.SetBounds(6, 10, fra_Msgbox.Width - 10, 17)
                lbl_Message2.SetBounds(5, 25, fra_Msgbox.Width - 10, 17)
                lbl_Message3.SetBounds(5, 41, fra_Msgbox.Width - 10, 17)
                If ButtonIndex = 3 Then cmd_Action1.Size = New Size(64, 25) : cmd_Action2.Size = New Size(64, 25)
                cmd_Action1.Top = 53
        End Select
    End Sub
    Private Sub cmd_Click(sender As Object, e As EventArgs) Handles cmd_Action1.Click, cmd_Action2.Click, cmd_Action3.Click, cmd_Action4.Click
        If FormIndex = 1 Then frm_SystemSetup.Height = 513
        If ButtonIndex = 1 Then Me.Close() : Me.Dispose() : Exit Sub
        If sender.name = "cmd_Action1" Then MessageResult = True Else MessageResult = False
        Me.Close()
        Me.Dispose()
        Exit Sub
    End Sub

End Class