Public Class frm_SystemSetup
    Dim dbAdapter, dbAdapter_Bal, dbAdapter_Misc As OleDb.OleDbDataAdapter
    Dim dbDataSet, dbDataSet_Bal, dbDataSet_Misc As New DataSet

    Dim tbox_TaxCategory(17) As TextBox
    Dim RestoreArray(6) As Boolean
    Dim strSQL As String
    Dim strInitEntry As String 'Variables to hold initial entry of textboxe startbalance
    Dim EditNew, intClearSystem, intSelect As Integer
    Dim booCorrection, booDataChecked, booCategory, booPass As Boolean
    Dim intMessage As Integer 'Variable used in the mouse over event to show different messages

    Private Sub frm_Load() Handles Me.Load

        'Retrieve setup information
        strSQL = "SELECT SetupLogon,CompanyName,CompanyRep,CompanyAddress,CompanyCity,CompanyState,CompanyZipCode,CompanyPhone,CompanyEmail,CompanyWebsite," _
               & "ShipVia,Terms,DiscountDays,DiscountAmount,DueDays,LastInvoice,ReInvoicePaid,Agent1,Agent2,CheckbookStartBalance,CheckbookLastCheck," _
               & "CheckbookReconDate,CheckbookReconBalance,SocSecLimit,SocSecPercent,MedicarePercent,VacaWaitPeriod,VacaStart,VacaAddDays,VacaStop," _
               & "VacaTrackYears,SystemPrinter,PdfPrinter,PdfPath,BackupPath,Buffer,ImageWidth,ImageHeight,NewYear,Id FROM System;"
        dbDataSet.Clear()
        dbDataSet.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter.Fill(dbDataSet, "SystemSetup")
        gbl_DstConnect.Close()

        If dbDataSet.Tables("SystemSetup").Rows.Count = 0 Then 'No database found
            frm_Message.Text = "0:1:1:1:2:System setup database missing,   Operations must be aborted"
            frm_Message.ShowDialog()
            Me.Close()
            End
        Else
            'Retrieve checkbook balance
            strSQL = "SELECT Balance from Banking ORDER BY Id;"
            dbDataSet_Misc.Clear()
            dbDataSet_Misc.Tables.Clear()
            gbl_DstConnect.Open()
            dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
            dbAdapter_Misc.Fill(dbDataSet_Misc, "EndBalance")
            gbl_DstConnect.Close()
            lbl_CheckbookBalance.Text = dbDataSet_Misc.Tables(0)(dbDataSet_Misc.Tables(0).Rows.Count - 1)("Balance")

            'Retrieve category information
            strSQL = "SELECT Id, Category from TaxCategorys"
            dbDataSet_Misc.Clear()
            dbDataSet_Misc.Tables.Clear()
            gbl_DstConnect.Open()
            dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
            dbAdapter_Misc.Fill(dbDataSet_Misc, "TaxCategorys")
            gbl_DstConnect.Close()
            Call AddControls() 'Add category textboxes
            ShowRecords(-1)
            intClearSystem = 0 'Reset [System Clear] password attempt counter ( only three tries allowed )
            booCorrection = False

            If frm_Main.Text = "" Then 'System not initialized (Allow only initial system setup)
                cmd_ClearSystem.Visible = False
                opt_SetupLogonYes.Enabled = False
                opt_SetupLogonNo.Enabled = False
            End If

        End If
    End Sub
    Private Sub form_Close()
        dbDataSet.Clear()
        dbDataSet.Tables.Clear()
        dbDataSet_Misc.Clear()
        dbDataSet_Misc.Tables.Clear()
        Me.Dispose()
    End Sub
    Private Sub AddControls() 'Add history related controls
        Dim int_Top As Integer = 1
        Dim int_Left As Integer = 27

        'Create array of controls in tab Tax Category's
        For i = 0 To 17
            If i = 9 Then int_Top = 1 : int_Left = 203
            int_Top = int_Top + 30

            tbox_TaxCategory(i) = New TextBox
            With tbox_TaxCategory(i)
                .Name = "tbox_TaxCategory"
                .Tag = i
                .Enabled = False
                .Font = New Font("Ariel", 8.25, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Left
                .MaxLength = 18
                .Visible = True
                .SetBounds(int_Left, int_Top, 110, 21)
                fra_TaxCategorys.Controls.Add(tbox_TaxCategory(i))
                AddHandler .GotFocus, AddressOf Tbox_GotFocus
                AddHandler .LostFocus, AddressOf Tbox_LostFocus
                AddHandler .TextChanged, AddressOf Tbox_TextChanged
                AddHandler .KeyPress, AddressOf Tbox_KeyPress
                AddHandler .MouseHover, AddressOf All_MouseHover
            End With

        Next
    End Sub
    Private Sub ShowRecords(ShowIndex As Integer)

        'Form fill data
        booDataChecked = True 'Textbox data changes with pre_processed data

        'General tab
        If ShowIndex < 0 Or ShowIndex = 0 Then
            If dbDataSet.Tables("SystemSetup").Rows(0).Item(0) = False Then opt_SetupLogonYes.Checked = False Else opt_SetupLogonYes.Checked = True 'Setup_logon state

            If Not IsDBNull(dbDataSet.Tables("SystemSetup").Rows(0).Item(1)) Then 'Company name
                tbox_CompanyName.Text = Trim(dbDataSet.Tables("SystemSetup").Rows(0).Item(1))
            Else : tbox_CompanyName.Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("SystemSetup").Rows(0).Item(2)) Then 'Company rep
                tbox_CompanyRep.Text = Trim(dbDataSet.Tables("SystemSetup").Rows(0).Item(2))
            Else : tbox_CompanyRep.Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("SystemSetup").Rows(0).Item(3)) Then 'Company address
                tbox_CompanyAddress.Text = Trim(dbDataSet.Tables("SystemSetup").Rows(0).Item(3))
            Else : tbox_CompanyAddress.Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("SystemSetup").Rows(0).Item(4)) Then 'Company city
                tbox_CompanyCity.Text = Trim(dbDataSet.Tables("SystemSetup").Rows(0).Item(4))
            Else : tbox_CompanyCity.Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("SystemSetup").Rows(0).Item(5)) Then 'Company state
                tbox_CompanyState.Text = Trim(dbDataSet.Tables("SystemSetup").Rows(0).Item(5))
            Else : tbox_CompanyState.Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("SystemSetup").Rows(0).Item(6)) Then 'Company zipcode
                tbox_CompanyZipCode.Text = Trim(dbDataSet.Tables("SystemSetup").Rows(0).Item(6))
            Else : tbox_CompanyZipCode.Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("SystemSetup").Rows(0).Item(7)) Then 'Company phone
                tbox_CompanyPhone.Text = Trim(dbDataSet.Tables("SystemSetup").Rows(0).Item(7))
            Else : tbox_CompanyPhone.Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("SystemSetup").Rows(0).Item(8)) Then 'Company email
                tbox_CompanyEmail.Text = Trim(dbDataSet.Tables("SystemSetup").Rows(0).Item(8))
            Else : tbox_CompanyEmail.Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("SystemSetup").Rows(0).Item(9)) Then 'Company website
                tbox_CompanyWebsite.Text = Trim(dbDataSet.Tables("SystemSetup").Rows(0).Item(9))
            Else : tbox_CompanyWebsite.Text = "" : End If
        End If

        'Invoice tab
        If ShowIndex < 0 Or ShowIndex = 1 Then
            If Not IsDBNull(dbDataSet.Tables("SystemSetup").Rows(0).Item(10)) Then 'Default shipping message
                tbox_ShipVia.Text = Trim(dbDataSet.Tables("SystemSetup").Rows(0).Item(10))
            Else : tbox_ShipVia.Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("SystemSetup").Rows(0).Item(11)) Then 'Payment terms
                tbox_Terms.Text = Trim(dbDataSet.Tables("SystemSetup").Rows(0).Item(11))
            Else : tbox_Terms.Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("SystemSetup").Rows(0).Item(12)) Then 'Discount days offered
                tbox_DiscountDays.Text = Trim(dbDataSet.Tables("SystemSetup").Rows(0).Item(12))
            Else : tbox_DiscountDays.Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("SystemSetup").Rows(0).Item(13)) Then 'Discount amount offered
                tbox_DiscountPercent.Text = Trim(dbDataSet.Tables("SystemSetup").Rows(0).Item(13))
            Else : tbox_DiscountPercent.Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("SystemSetup").Rows(0).Item(14)) Then 'Payment due days
                tbox_DueDays.Text = Trim(dbDataSet.Tables("SystemSetup").Rows(0).Item(14))
            Else : tbox_DueDays.Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("SystemSetup").Rows(0).Item(15)) Then 'Last invoice number
                tbox_LastInvoice.Text = Trim(dbDataSet.Tables("SystemSetup").Rows(0).Item(15))
            Else : tbox_LastInvoice.Text = "" : End If

            If dbDataSet.Tables("SystemSetup").Rows(0).Item(16) = False Then cbx_ReInvoice.Checked = False Else cbx_ReInvoice.Checked = True 'Re-invoice yes/no

            If Not IsDBNull(dbDataSet.Tables("SystemSetup").Rows(0).Item(17)) Then 'Primary inspection agent
                tbox_PrimaryAgent.Text = Trim(dbDataSet.Tables("SystemSetup").Rows(0).Item(17))
            Else : tbox_PrimaryAgent.Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("SystemSetup").Rows(0).Item(18)) Then 'Secondary inspection agent
                tbox_SecondaryAgent.Text = Trim(dbDataSet.Tables("SystemSetup").Rows(0).Item(18))
            Else : tbox_SecondaryAgent.Text = "" : End If

        End If

        'Checkbook tab
        If ShowIndex < 0 Or ShowIndex = 2 Then
            If Not IsDBNull(dbDataSet.Tables("SystemSetup").Rows(0).Item(19)) Then 'Checkbook start balance
                tbox_StartBalance.Text = FormatNumber((dbDataSet.Tables("SystemSetup").Rows(0).Item(19)), 2)
            Else : tbox_StartBalance.Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("SystemSetup").Rows(0).Item(20)) Then 'Checkbook last check number
                tbox_LastCheck.Text = Trim(dbDataSet.Tables("SystemSetup").Rows(0).Item(20))
            Else : tbox_LastCheck.Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("SystemSetup").Rows(0).Item(21)) And dbDataSet.Tables("SystemSetup").Rows(0).Item(21).ToString <> "#12/12/1212#" Then 'Checkbook last reconcile date
                tbox_ReconcileDate.Text = Format(dbDataSet.Tables("SystemSetup").Rows(0).Item(21), "MM/dd/yyyy")
            Else : tbox_ReconcileDate.Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("SystemSetup").Rows(0).Item(22)) Then 'Checkbook last reconcile balance
                tbox_ReconcileBalance.Text = FormatNumber(dbDataSet.Tables("SystemSetup").Rows(0).Item(22), 2)
            Else : tbox_ReconcileBalance.Text = "" : End If
        End If

        'Tax catagory tab
        If ShowIndex < 0 Or ShowIndex = 3 Then
            For i = 0 To 17
                If Not IsDBNull(dbDataSet_Misc.Tables("TaxCategorys").Rows(i).Item(1)) Then 'Tax category
                    tbox_TaxCategory(i).Text = Trim(dbDataSet_Misc.Tables("TaxCategorys").Rows(i).Item(1))
                Else : tbox_TaxCategory(i).Text = "" : End If
            Next
        End If

        'Payroll & Vacation tab
        If ShowIndex < 0 Or ShowIndex = 4 Then
            If Not IsDBNull(dbDataSet.Tables("SystemSetup").Rows(0).Item(23)) Then 'Social security base limit
                tbox_SocSecBaseLimit.Text = Trim(dbDataSet.Tables("SystemSetup").Rows(0).Item(23))
            Else : tbox_SocSecBaseLimit.Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("SystemSetup").Rows(0).Item(24)) Then 'Social security percent
                tbox_SocSecPercent.Text = Trim(dbDataSet.Tables("SystemSetup").Rows(0).Item(24))
            Else : tbox_SocSecPercent.Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("SystemSetup").Rows(0).Item(25)) Then 'Medicare percent
                tbox_MedicarePercent.Text = Trim(dbDataSet.Tables("SystemSetup").Rows(0).Item(25))
            Else : tbox_MedicarePercent.Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("SystemSetup").Rows(0).Item(26)) Then 'Vacation wait period
                tbox_VacaWaitPeriod.Text = Trim(dbDataSet.Tables("SystemSetup").Rows(0).Item(26))
            Else : tbox_VacaWaitPeriod.Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("SystemSetup").Rows(0).Item(27)) Then 'Vacation starting amount of day
                tbox_VacaStart.Text = Trim(dbDataSet.Tables("SystemSetup").Rows(0).Item(27))
            Else : tbox_VacaStart.Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("SystemSetup").Rows(0).Item(28)) Then 'Vacation days added per year
                tbox_VacaAddDays.Text = Trim(dbDataSet.Tables("SystemSetup").Rows(0).Item(28))
            Else : tbox_VacaAddDays.Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("SystemSetup").Rows(0).Item(29)) Then 'Vacation maxium amount of days
                tbox_VacaStop.Text = Trim(dbDataSet.Tables("SystemSetup").Rows(0).Item(29))
            Else : tbox_VacaStop.Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("SystemSetup").Rows(0).Item(30)) Then 'Vacation years tracked
                Select Case dbDataSet.Tables("SystemSetup").Rows(0).Item(30)
                    Case 1 : opt_TrackYears1.Checked = True
                    Case 2 : opt_TrackYears2.Checked = True
                    Case 3 : opt_TrackYears3.Checked = True
                End Select
            Else : opt_TrackYears3.Checked = True : End If

        End If

        'Misc tab
        If ShowIndex < 0 Or ShowIndex = 6 Then
            If Not IsDBNull(dbDataSet.Tables("SystemSetup").Rows(0).Item(31)) Then 'System printer name
                tbox_PrinterName.Text = Trim(dbDataSet.Tables("SystemSetup").Rows(0).Item(31))
            Else : tbox_PrinterName.Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("SystemSetup").Rows(0).Item(32)) Then 'System PDF printer name
                tbox_PdfPrinterName.Text = Trim(dbDataSet.Tables("SystemSetup").Rows(0).Item(32))
            Else : tbox_PdfPrinterName.Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("SystemSetup").Rows(0).Item(33)) Then 'Path where pdf files will be stored
                tbox_PdfPath.Text = Trim(dbDataSet.Tables("SystemSetup").Rows(0).Item(33))
            Else : tbox_PdfPath.Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("SystemSetup").Rows(0).Item(34)) Then 'Default backup path
                tbox_BackupPath.Text = Trim(dbDataSet.Tables("SystemSetup").Rows(0).Item(34))
            Else : tbox_BackupPath.Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("SystemSetup").Rows(0).Item(35)) Then 'Printer form buffer
                tbox_PrinterBuffer.Text = Trim(dbDataSet.Tables("SystemSetup").Rows(0).Item(35))
            Else : tbox_PrinterBuffer.Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("SystemSetup").Rows(0).Item(36)) Then 'Form image width
                tbox_ImageWidth.Text = Trim(dbDataSet.Tables("SystemSetup").Rows(0).Item(36))
            Else : tbox_ImageWidth.Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("SystemSetup").Rows(0).Item(37)) Then 'Form image height
                tbox_ImageHeight.Text = Trim(dbDataSet.Tables("SystemSetup").Rows(0).Item(37))
            Else : tbox_ImageHeight.Text = "" : End If

        End If
        booDataChecked = False

    End Sub
    Public Sub EnableEdits(blnStatus As Boolean)
        tbox_CompanyName.Enabled = blnStatus
        tbox_CompanyRep.Enabled = blnStatus
        tbox_CompanyAddress.Enabled = blnStatus
        tbox_CompanyCity.Enabled = blnStatus
        tbox_CompanyState.Enabled = blnStatus
        tbox_CompanyZipCode.Enabled = blnStatus
        tbox_CompanyPhone.Enabled = blnStatus
        tbox_CompanyEmail.Enabled = blnStatus
        tbox_CompanyWebsite.Enabled = blnStatus

        tbox_ShipVia.Enabled = blnStatus
        tbox_Terms.Enabled = blnStatus
        tbox_DiscountDays.Enabled = blnStatus
        tbox_DiscountPercent.Enabled = blnStatus
        tbox_DueDays.Enabled = blnStatus
        tbox_LastInvoice.Enabled = blnStatus
        cbx_ReInvoice.Enabled = blnStatus
        tbox_PrimaryAgent.Enabled = blnStatus
        tbox_SecondaryAgent.Enabled = blnStatus

        tbox_StartBalance.Enabled = blnStatus
        tbox_LastCheck.Enabled = blnStatus
        tbox_ReconcileDate.Enabled = blnStatus
        tbox_ReconcileBalance.Enabled = blnStatus

        For i = 0 To 17
            tbox_TaxCategory(i).Enabled = blnStatus
        Next
        cmd_CategoryDefaults.Enabled = blnStatus

        tbox_SocSecBaseLimit.Enabled = blnStatus
        tbox_SocSecPercent.Enabled = blnStatus
        tbox_MedicarePercent.Enabled = blnStatus

        tbox_VacaWaitPeriod.Enabled = blnStatus
        tbox_VacaStart.Enabled = blnStatus
        tbox_VacaAddDays.Enabled = blnStatus
        tbox_VacaStop.Enabled = blnStatus
        opt_TrackYears1.Enabled = blnStatus
        opt_TrackYears2.Enabled = blnStatus
        opt_TrackYears3.Enabled = blnStatus

        tbox_PrinterName.Enabled = blnStatus
        tbox_PdfPrinterName.Enabled = blnStatus
        tbox_PdfPath.Enabled = blnStatus
        tbox_BackupPath.Enabled = blnStatus
        tbox_PrinterBuffer.Enabled = blnStatus
        tbox_ImageWidth.Enabled = blnStatus
        tbox_ImageHeight.Enabled = blnStatus
        cmd_MiscDefaults.Enabled = blnStatus

    End Sub
    Private Sub Validate_Save()

        Dim msgIncomplete As String = "1:4:0:1:5:All entries necessary for this page of system data is incomplete. Entry will not be allowed"
        booPass = True

        'Validate entries general tab
        Me.TabControl.SelectedIndex = 0
        If Trim(tbox_CompanyName.Text) = "" Then
            booPass = False
            If frm_Main.Text = "" Then
                frm_Message.Text = msgIncomplete
            Else : frm_Message.Text = "1:4:0:1:4:The company's name must be entered before entry into the system will be allowed" : End If
            tbox_CompanyName.Focus()
            Exit Sub
        End If

        If Trim(tbox_CompanyAddress.Text) = "" Then
            booPass = False
            If frm_Main.Text = "" Then
                frm_Message.Text = msgIncomplete
            Else : frm_Message.Text = "1:4:0:1:4:The company's address must be entered before entry into the system will be allowed" : End If
            tbox_CompanyAddress.Focus()
            Exit Sub
        End If

        If Trim(tbox_CompanyCity.Text) = "" Then
            booPass = False
            If frm_Main.Text = "" Then
                frm_Message.Text = msgIncomplete
            Else : frm_Message.Text = "1:4:0:1:4:The company's city must be entered before entry into the system will be allowed" : End If
            tbox_CompanyCity.Focus()
            Exit Sub
        End If

        If Trim(tbox_CompanyState.Text) = "" Then
            booPass = False
            If frm_Main.Text = "" Then
                frm_Message.Text = msgIncomplete
            Else : frm_Message.Text = "1:4:0:1:4:The company's state must be entered before entry into the system will be allowed" : End If
            tbox_CompanyState.Focus()
            Exit Sub
        End If

        If Trim(tbox_CompanyZipCode.Text) = "" Then
            booPass = False
            If frm_Main.Text = "" Then
                frm_Message.Text = msgIncomplete
            Else : frm_Message.Text = "1:4:0:1:4:The company's Phone zipcode must be entered before entry into the system will be allowed" : End If
            tbox_CompanyZipCode.Focus()
            Exit Sub
        End If

        If Trim(tbox_CompanyPhone.Text) = "" Then
            booPass = False
            If frm_Main.Text = "" Then
                frm_Message.Text = msgIncomplete
            Else : frm_Message.Text = "1:4:0:1:4:The company's phone number must be entered before entry into the system will be allowed" : End If
            tbox_CompanyPhone.Focus()
        End If

        If Trim(tbox_CompanyEmail.Text) = "" Then
            booPass = False
            If frm_Main.Text = "" Then
                frm_Message.Text = msgIncomplete
            Else : frm_Message.Text = "1:4:0:1:4:The company's email address must be entered before entry into the system will be allowed" : End If
            tbox_CompanyEmail.Focus()
            Exit Sub
        End If

        'Validate entries Invoice tab
        Me.TabControl.SelectedIndex = 1
        If Trim(tbox_ShipVia.Text) = "" Then
            booPass = False
            If frm_Main.Text = "" Then
                frm_Message.Text = msgIncomplete
            Else : frm_Message.Text = "1:4:0:1:4:Default shipping message must be entered before entry into the system will be allowed" : End If
            tbox_ShipVia.Focus()
            Exit Sub
        End If

        If Trim(tbox_Terms.Text) = "" Then
            booPass = False
            If frm_Main.Text = "" Then
                frm_Message.Text = msgIncomplete
            Else : frm_Message.Text = "1:4:0:1:3:Terms message must be entered before entry into the system will be allowed" : End If
            tbox_Terms.Focus()
            Exit Sub
        End If

        If Trim(tbox_DiscountDays.Text) = "" Then
            booPass = False
            If frm_Main.Text = "" Then
                frm_Message.Text = msgIncomplete
            Else : frm_Message.Text = "1:4:0:1:5:Amount of days for terms message must be entered before entry into the system will be allowed" : End If
            tbox_DiscountDays.Focus()
            Exit Sub
        End If

        If Trim(tbox_DiscountPercent.Text) = "" Then
            booPass = False
            If frm_Main.Text = "" Then
                frm_Message.Text = msgIncomplete
            Else : frm_Message.Text = "1:4:0:1:4:Discount percentage must be entered before entry into the system will be allowed" : End If
            tbox_DiscountPercent.Focus()
            Exit Sub
        End If

        If Trim(tbox_DueDays.Text) = "" Or Trim(tbox_DueDays.Text) = "0" Then
            booPass = False
            If frm_Main.Text = "" Then
                frm_Message.Text = msgIncomplete
            Else : frm_Message.Text = "1:4:0:1:5:Discount time period in days must be entered before entry into the system will be allowed" : End If
            tbox_DueDays.Focus()
            Exit Sub
        End If

        If Trim(tbox_LastInvoice.Text) = "" Or Trim(tbox_LastInvoice.Text) = "0" Then
            booPass = False
            If frm_Main.Text = "" Then
                frm_Message.Text = msgIncomplete
            Else : frm_Message.Text = "1:4:0:1:4:Last invoice number must be entered before entry into the system will be allowed" : End If
            tbox_LastInvoice.Focus()
            Exit Sub
        End If

        If Trim(tbox_PrimaryAgent.Text) = "" Then
            booPass = False
            If frm_Main.Text = "" Then
                frm_Message.Text = msgIncomplete
            Else : frm_Message.Text = "1:4:0:1:5:Primary inspection agent must be entered before entry into the system will be allowed" : End If
            tbox_PrimaryAgent.Focus()
            Exit Sub
        End If

        'Validate entries Checkbook tab
        Me.TabControl.SelectedIndex = 2
        If Trim(tbox_StartBalance.Text) = "" Then
            booPass = False
            If frm_Main.Text = "" Then
                frm_Message.Text = msgIncomplete
            Else : frm_Message.Text = "1:4:0:1:4:Checkbook start balance must be entered before entry into the system will be allowed" : End If
            tbox_LastCheck.Focus()
            Exit Sub
        End If

        If Trim(tbox_LastCheck.Text) = "" Then
            booPass = False
            If frm_Main.Text = "" Then
                frm_Message.Text = msgIncomplete
            Else : frm_Message.Text = "1:4:0:1:4:Last check number must be entered before entry into the system will be allowed" : End If
            tbox_LastCheck.Focus()
            Exit Sub
        End If

        'Validate entries Tax category tab
        Me.TabControl.SelectedIndex = 3
        If booCategory = True Then
            For i = 0 To 17
                If Trim(tbox_TaxCategory(i).Text) = "" Then
                    booPass = False
                    If frm_Main.Text = "" Then
                        frm_Message.Text = msgIncomplete
                    Else : frm_Message.Text = "1:4:0:1:4:An entry for all 18 categories must be entered before entry into the system will be allowed" : End If
                    tbox_TaxCategory(i).Focus()
                    Exit Sub
                End If
            Next
        End If

        'Validate entries Payroll & Vacation tab
        Me.TabControl.SelectedIndex = 4
        If Trim(tbox_SocSecBaseLimit.Text) = "" Or tbox_SocSecBaseLimit.Text = "0" Then
            booPass = False
            If frm_Main.Text = "" Then
                frm_Message.Text = msgIncomplete
            Else : frm_Message.Text = "1:4:0:1:5:Social Security wage base limit must be entered before entry into the system will be allowed" : End If
            tbox_SocSecBaseLimit.Focus()
            Exit Sub
        End If

        If Trim(tbox_SocSecPercent.Text) = "" Or tbox_SocSecPercent.Text = "0" Then
            booPass = False
            If frm_Main.Text = "" Then
                frm_Message.Text = msgIncomplete
            Else : frm_Message.Text = "1:4:0:1:5:Social Security tax percent must be entered before entry into the system will be allowed" : End If
            tbox_SocSecPercent.Focus()
            Exit Sub
        End If

        If Trim(tbox_MedicarePercent.Text) = "" Or tbox_MedicarePercent.Text = "0" Then
            booPass = False
            If frm_Main.Text = "" Then
                frm_Message.Text = msgIncomplete
            Else : frm_Message.Text = "1:4:0:1:5:Medicare tax percent must be entered before entry into the system will be allowed" : End If
            tbox_MedicarePercent.Focus()
            Exit Sub
        End If

        If Trim(tbox_VacaWaitPeriod.Text) = "" Then
            booPass = False
            If frm_Main.Text = "" Then
                frm_Message.Text = msgIncomplete
            Else : frm_Message.Text = "1:4:0:1:5:Months before paid vacation allowed must be entered before entry into the system will be allowed" : End If
            tbox_VacaWaitPeriod.Focus()
            Exit Sub
        End If

        If Trim(tbox_VacaStart.Text) = "" Or tbox_VacaStart.Text = "0" Then
            booPass = False
            If frm_Main.Text = "" Then
                frm_Message.Text = msgIncomplete
            Else : frm_Message.Text = "1:4:0:1:5:Days offered at start of paid vacations must be entered before entry into the system will be allowed" : End If
            tbox_VacaStart.Focus()
            Exit Sub
        End If

        If Trim(tbox_VacaAddDays.Text) = "" Or Trim(tbox_VacaAddDays.Text) = "0" Then
            booPass = False
            If frm_Main.Text = "" Then
                frm_Message.Text = msgIncomplete
            Else : frm_Message.Text = "1:4:0:1:5:Days to add with increase in vacation must be entered before entry into the system will be allowed" : End If
            tbox_VacaAddDays.Focus()
            Exit Sub
        End If

        If Trim(tbox_VacaStop.Text) = "" Or Trim(tbox_VacaStop.Text) = "0" Then
            booPass = False
            If frm_Main.Text = "" Then
                frm_Message.Text = msgIncomplete
            Else : frm_Message.Text = "1:4:0:1:5:Maximum vacation days allowed must be entered before entry into the system will be allowed" : End If
            tbox_VacaStop.Focus()
            Exit Sub
        End If

        'Validate entries Misc tab
        Me.TabControl.SelectedIndex = 6
        If Trim(tbox_PrinterName.Text) = "" Then
            booPass = False
            If frm_Main.Text = "" Then
                frm_Message.Text = msgIncomplete
            Else : frm_Message.Text = "1:4:0:1:5:Printer name used to print forms must be entered before entry into the system will be allowed" : End If
            tbox_PrinterName.Focus()
            Exit Sub
        End If

        If Trim(tbox_PrinterBuffer.Text) = "" Or Trim(tbox_PrinterBuffer.Text) = "0" Then
            booPass = False
            If frm_Main.Text = "" Then
                frm_Message.Text = msgIncomplete
            Else : frm_Message.Text = "1:4:0:1:5:Printer buffer to center print on form must be entered before entry into the system will be allowed" : End If
            tbox_PrinterBuffer.Focus()
            Exit Sub
        End If

        If Trim(tbox_ImageWidth.Text) = "" Or Trim(tbox_ImageWidth.Text) = "0" Then
            booPass = False
            If frm_Main.Text = "" Then
                frm_Message.Text = msgIncomplete
            Else : frm_Message.Text = "1:4:0:1:5:Image width for all forms must be entered before entry into the system will be allowed" : End If
            tbox_ImageWidth.Focus()
            Exit Sub
        End If

        If Trim(tbox_ImageHeight.Text) = "" Or Trim(tbox_ImageHeight.Text) = "0" Then
            booPass = False
            If frm_Main.Text = "" Then
                frm_Message.Text = msgIncomplete
            Else : frm_Message.Text = "1:4:0:1:5:Image height for all forms must be entered before entry into the system will be allowed" : End If
            tbox_ImageHeight.Focus()
            Exit Sub
        End If

    End Sub
    Private Sub RecalculateView(blnStatus As Boolean)
        label_CheckbookBalance.Visible = blnStatus
        lbl_CheckbookBalance.Visible = blnStatus
        cmd_ReCalculate.Visible = blnStatus
        lbl_Progress.Visible = blnStatus
    End Sub

    'Command actions
    Private Sub cmd_EditCancel_Click() Handles cmd_EditCancel.Click

        If cmd_EditCancel.Text = "Edit" Then
            EditNew = 1
            cmd_EditCancel.Text = "Cancel"
            cmd_Restore.Enabled = False 'Hide restore button
            cmd_ExitSave.Enabled = False 'Hide exit button
            opt_SetupLogonYes.Enabled = False
            opt_SetupLogonNo.Enabled = False
            cmd_ClearSystem.Visible = False
            Call EnableEdits(True)
            Call SetFocus()
        Else
            EditNew = 0
            ShowRecords(-2)
            Call EnableEdits(False)
            cmd_EditCancel.Text = "Edit"
            cmd_Restore.Enabled = False
            cmd_ExitSave.Text = "Exit"
            cmd_ExitSave.Enabled = True
            opt_SetupLogonYes.Enabled = True
            opt_SetupLogonNo.Enabled = True
            If frm_Main.Text <> "" Then cmd_ClearSystem.Visible = True
            RecalculateView(False) 'Hide all form reference to balance recalculations
        End If

    End Sub
    Private Sub cmd_Restore_Click() Handles cmd_Restore.Click
        ShowRecords(TabControl.SelectedIndex) 'Resore only the tab that is open
        RestoreArray(TabControl.SelectedIndex) = False 'Turn restore off for this tab
        cmd_Restore.Enabled = False
        cmd_ExitSave.Text = "Exit"
        RecalculateView(False) 'Hide all form reference to balance recalculations
        Call SetFocus()
    End Sub
    Private Sub cmd_ExitSave_Click(sender As Object, e As EventArgs) Handles cmd_ExitSave.Click

        If cmd_ExitSave.Text = "Exit" Then
            Me.Hide()
            Call Validate_Save() 'Check for all neccesary data for program to run
            If booPass = True Then
                Me.Close()
            Else
                Me.Show()
                frm_Message.ShowDialog() 'All entries necessary for this page of system data is incomplete. Entry will not be allowed"
                If MessageResult = True Then 'Form close
                    Call form_Close()
                    End
                Else 'Continue with system setup
                    If frm_Main.Text <> "" Then
                        opt_SetupLogonYes.Enabled = True
                        opt_SetupLogonNo.Enabled = True
                        cmd_ClearSystem.Visible = True
                    End If
                End If
            End If

        Else 'Save data

            'Make form checkbox and option buttons ready for save 
            Dim booSetupLogon, booReinvoice As Boolean
            If opt_SetupLogonYes.Checked = True Then booSetupLogon = True Else booSetupLogon = False
            If cbx_ReInvoice.Checked = True Then booReinvoice = True Else booReinvoice = False
            Dim rButton As RadioButton = fra_Vacation.Controls.OfType(Of RadioButton)().FirstOrDefault(Function(r) r.Checked = True)
            Dim VacaTrackYears As Integer = rButton.Tag

            'Save form to database
            Dim cb0 As New OleDb.OleDbCommandBuilder(dbAdapter)
            dbDataSet.Tables("SystemSetup").Rows(0).Item(0) = booSetupLogon 'General Tab
            If Trim(tbox_CompanyName.Text) <> "" Then
                dbDataSet.Tables("SystemSetup").Rows(0).Item(1) = Trim(tbox_CompanyName.Text)
            Else : dbDataSet.Tables("SystemSetup").Rows(0).Item(1) = DBNull.Value : End If
            If Trim(tbox_CompanyRep.Text) <> "" Then
                dbDataSet.Tables("SystemSetup").Rows(0).Item(2) = Trim(tbox_CompanyRep.Text)
            Else : dbDataSet.Tables("SystemSetup").Rows(0).Item(2) = DBNull.Value : End If
            If Trim(tbox_CompanyAddress.Text) <> "" Then
                dbDataSet.Tables("SystemSetup").Rows(0).Item(3) = Trim(tbox_CompanyAddress.Text)
            Else : dbDataSet.Tables("SystemSetup").Rows(0).Item(3) = DBNull.Value : End If
            If Trim(tbox_CompanyCity.Text) <> "" Then
                dbDataSet.Tables("SystemSetup").Rows(0).Item(4) = Trim(tbox_CompanyCity.Text)
            Else : dbDataSet.Tables("SystemSetup").Rows(0).Item(4) = DBNull.Value : End If
            If Trim(tbox_CompanyState.Text) <> "" Then
                dbDataSet.Tables("SystemSetup").Rows(0).Item(5) = Trim(tbox_CompanyState.Text)
            Else : dbDataSet.Tables("SystemSetup").Rows(0).Item(5) = DBNull.Value : End If
            If Trim(tbox_CompanyZipCode.Text) <> "" Then
                dbDataSet.Tables("SystemSetup").Rows(0).Item(6) = Trim(tbox_CompanyZipCode.Text)
            Else : dbDataSet.Tables("SystemSetup").Rows(0).Item(6) = DBNull.Value : End If
            If Trim(tbox_CompanyPhone.Text) <> "" Then
                dbDataSet.Tables("SystemSetup").Rows(0).Item(7) = String.Format("{0:(###)###-####}", Long.Parse(Trim(tbox_CompanyPhone.Text)))
            Else : dbDataSet.Tables("SystemSetup").Rows(0).Item(7) = DBNull.Value : End If
            If Trim(tbox_CompanyEmail.Text) <> "" Then
                dbDataSet.Tables("SystemSetup").Rows(0).Item(8) = Trim(tbox_CompanyEmail.Text)
            Else : dbDataSet.Tables("SystemSetup").Rows(0).Item(8) = DBNull.Value : End If
            If Trim(tbox_CompanyWebsite.Text) <> "" Then
                dbDataSet.Tables("SystemSetup").Rows(0).Item(9) = Trim(tbox_CompanyWebsite.Text)
            Else : dbDataSet.Tables("SystemSetup").Rows(0).Item(9) = DBNull.Value : End If

            If Trim(tbox_ShipVia.Text) <> "" Then 'Invoice Tab
                dbDataSet.Tables("SystemSetup").Rows(0).Item(10) = Trim(tbox_ShipVia.Text)
            Else : dbDataSet.Tables("SystemSetup").Rows(0).Item(10) = DBNull.Value : End If
            If Trim(tbox_Terms.Text) <> "" Then
                dbDataSet.Tables("SystemSetup").Rows(0).Item(11) = Trim(tbox_Terms.Text)
            Else : dbDataSet.Tables("SystemSetup").Rows(0).Item(11) = DBNull.Value : End If
            If Trim(tbox_DiscountDays.Text) <> "" And Trim(tbox_DiscountDays.Text) <> "0" Then
                dbDataSet.Tables("SystemSetup").Rows(0).Item(12) = tbox_DiscountDays.Text
            Else : dbDataSet.Tables("SystemSetup").Rows(0).Item(12) = DBNull.Value : End If
            If Trim(tbox_DiscountPercent.Text) <> "" And Trim(tbox_DiscountPercent.Text) <> "0" Then
                dbDataSet.Tables("SystemSetup").Rows(0).Item(13) = tbox_DiscountPercent.Text
            Else : dbDataSet.Tables("SystemSetup").Rows(0).Item(13) = DBNull.Value : End If
            If Trim(tbox_DueDays.Text) <> "" And Trim(tbox_DueDays.Text) <> "0" Then
                dbDataSet.Tables("SystemSetup").Rows(0).Item(14) = tbox_DueDays.Text
            Else : dbDataSet.Tables("SystemSetup").Rows(0).Item(14) = DBNull.Value : End If
            If Trim(tbox_LastInvoice.Text) <> "" And Trim(tbox_LastInvoice.Text) <> "0" Then
                dbDataSet.Tables("SystemSetup").Rows(0).Item(15) = tbox_LastInvoice.Text
            Else : dbDataSet.Tables("SystemSetup").Rows(0).Item(15) = DBNull.Value : End If
            dbDataSet.Tables("SystemSetup").Rows(0).Item(16) = booReinvoice
            If Trim(tbox_PrimaryAgent.Text) <> "" Then
                dbDataSet.Tables("SystemSetup").Rows(0).Item(17) = Trim(tbox_PrimaryAgent.Text)
            Else : dbDataSet.Tables("SystemSetup").Rows(0).Item(17) = DBNull.Value : End If
            If Trim(tbox_SecondaryAgent.Text) <> "" Then
                dbDataSet.Tables("SystemSetup").Rows(0).Item(18) = Trim(tbox_SecondaryAgent.Text)
            Else : dbDataSet.Tables("SystemSetup").Rows(0).Item(18) = DBNull.Value : End If

            If Trim(tbox_StartBalance.Text) <> "" Then 'Checkbook Tab
                dbDataSet.Tables("SystemSetup").Rows(0).Item(19) = tbox_StartBalance.Text
            Else : dbDataSet.Tables("SystemSetup").Rows(0).Item(19) = 0 : End If
            If Trim(tbox_LastCheck.Text) <> "" Then
                dbDataSet.Tables("SystemSetup").Rows(0).Item(20) = tbox_LastCheck.Text
            Else : dbDataSet.Tables("SystemSetup").Rows(0).Item(20) = 0 : End If
            If tbox_ReconcileDate.Text <> "  /  /" Then
                dbDataSet.Tables("SystemSetup").Rows(0).Item(21) = tbox_ReconcileDate.Text
            Else : dbDataSet.Tables("SystemSetup").Rows(0).Item(21) = DBNull.Value : End If
            If Trim(tbox_ReconcileBalance.Text) <> "" And Trim(tbox_ReconcileBalance.Text) <> "0" Then
                dbDataSet.Tables("SystemSetup").Rows(0).Item(22) = Trim(tbox_ReconcileBalance.Text)
            Else : dbDataSet.Tables("SystemSetup").Rows(0).Item(22) = DBNull.Value : End If

            If Trim(tbox_SocSecBaseLimit.Text) <> "" And Trim(tbox_SocSecBaseLimit.Text) <> "0" Then 'Payroll & Vacation Tab
                dbDataSet.Tables("SystemSetup").Rows(0).Item(23) = tbox_SocSecBaseLimit.Text
            Else : dbDataSet.Tables("SystemSetup").Rows(0).Item(23) = DBNull.Value : End If
            If Trim(tbox_SocSecPercent.Text) <> "" And Trim(tbox_SocSecPercent.Text) <> "0" Then
                dbDataSet.Tables("SystemSetup").Rows(0).Item(24) = tbox_SocSecPercent.Text
            Else : dbDataSet.Tables("SystemSetup").Rows(0).Item(24) = DBNull.Value : End If
            If Trim(tbox_MedicarePercent.Text) <> "" And Trim(tbox_MedicarePercent.Text) <> "0" Then
                dbDataSet.Tables("SystemSetup").Rows(0).Item(25) = tbox_MedicarePercent.Text
            Else : dbDataSet.Tables("SystemSetup").Rows(0).Item(25) = DBNull.Value : End If
            If Trim(tbox_VacaWaitPeriod.Text) <> "" And Trim(tbox_VacaWaitPeriod.Text) <> "0" Then
                dbDataSet.Tables("SystemSetup").Rows(0).Item(26) = tbox_VacaWaitPeriod.Text
            Else : dbDataSet.Tables("SystemSetup").Rows(0).Item(26) = DBNull.Value : End If
            If Trim(tbox_VacaStart.Text) <> "" And Trim(tbox_VacaStart.Text) <> "0" Then
                dbDataSet.Tables("SystemSetup").Rows(0).Item(27) = tbox_VacaStart.Text
            Else : dbDataSet.Tables("SystemSetup").Rows(0).Item(27) = DBNull.Value : End If
            If Trim(tbox_VacaAddDays.Text) <> "" And Trim(tbox_VacaAddDays.Text) <> "0" Then
                dbDataSet.Tables("SystemSetup").Rows(0).Item(28) = tbox_VacaAddDays.Text
            Else : dbDataSet.Tables("SystemSetup").Rows(0).Item(28) = DBNull.Value : End If
            If Trim(tbox_VacaStop.Text) <> "" And Trim(tbox_VacaStop.Text) <> "0" Then
                dbDataSet.Tables("SystemSetup").Rows(0).Item(29) = tbox_VacaStop.Text
            Else : dbDataSet.Tables("SystemSetup").Rows(0).Item(29) = DBNull.Value : End If
            dbDataSet.Tables("SystemSetup").Rows(0).Item(30) = VacaTrackYears

            If Trim(tbox_PrinterName.Text) <> "" Then 'Misc Tab
                dbDataSet.Tables("SystemSetup").Rows(0).Item(31) = Trim(tbox_PrinterName.Text)
            Else : dbDataSet.Tables("SystemSetup").Rows(0).Item(31) = DBNull.Value : End If
            If Trim(tbox_PdfPrinterName.Text) <> "" Then
                dbDataSet.Tables("SystemSetup").Rows(0).Item(32) = tbox_PdfPrinterName.Text
            Else : dbDataSet.Tables("SystemSetup").Rows(0).Item(32) = DBNull.Value : End If
            If Trim(tbox_PdfPath.Text) <> "" Then
                dbDataSet.Tables("SystemSetup").Rows(0).Item(33) = tbox_PdfPath.Text
            Else : dbDataSet.Tables("SystemSetup").Rows(0).Item(33) = DBNull.Value : End If
            If Trim(tbox_BackupPath.Text) <> "" Then
                dbDataSet.Tables("SystemSetup").Rows(0).Item(34) = Trim(tbox_BackupPath.Text)
            Else : dbDataSet.Tables("SystemSetup").Rows(0).Item(34) = DBNull.Value : End If
            If Trim(tbox_PrinterBuffer.Text) <> "" And Trim(tbox_PrinterBuffer.Text) <> "0" Then
                dbDataSet.Tables("SystemSetup").Rows(0).Item(35) = tbox_PrinterBuffer.Text
            Else : dbDataSet.Tables("SystemSetup").Rows(0).Item(35) = DBNull.Value : End If
            If Trim(tbox_ImageWidth.Text) <> "" And Trim(tbox_ImageWidth.Text) <> "0" Then
                dbDataSet.Tables("SystemSetup").Rows(0).Item(36) = tbox_ImageWidth.Text
            Else : dbDataSet.Tables("SystemSetup").Rows(0).Item(36) = DBNull.Value : End If
            If Trim(tbox_ImageHeight.Text) <> "" And Trim(tbox_ImageHeight.Text) <> "0" Then
                dbDataSet.Tables("SystemSetup").Rows(0).Item(37) = tbox_ImageHeight.Text
            Else : dbDataSet.Tables("SystemSetup").Rows(0).Item(37) = DBNull.Value : End If          
            dbAdapter.Update(dbDataSet, "SystemSetup")
            cb0 = Nothing

            'Tax category tab
            If booCategory = True Then
                    For i = 0 To 17
                        Dim cb1 As New OleDb.OleDbCommandBuilder(dbAdapter_Misc)
                        dbDataSet_Misc.Tables("TaxCategorys").Rows(i).Item(1) = Trim(tbox_TaxCategory(i).Text)
                        cb1 = Nothing
                    Next
                End If

                If frm_Main.Text = "" Then
                    frm_Main.Text = Trim(tbox_CompanyName.Text) 'Update new company name om main screen to ( Establish system data complete )
                    Call Menu_Validate() 'Check for neccesary files need for specific programs ( Menus )
                Else
                    RecalculateView(False) 'Hide all form reference to balance recalculations
                End If

                EditNew = 0
                Call EnableEdits(False)
                cmd_EditCancel.Text = "Edit"
                cmd_Restore.Enabled = False
                cmd_ExitSave.Text = "Exit"

            End If
    End Sub
    Private Sub cmd_ClearSystem_Click() Handles cmd_ClearSystem.Click

        If intClearSystem = 2 Then Exit Sub 'allow only 2 tries

        If lbl_ClearSystem.Visible = False Then
            lbl_ClearSystem.Visible = True
            tbox_ClearSystem.Visible = True
            tbox_ClearSystem.Focus()
            Exit Sub
        End If

        If tbox_ClearSystem.Text <> "Enter Code System Clear" Then
            lbl_ClearSystem.Visible = False
            tbox_ClearSystem.Visible = False
            tbox_ClearSystem.Text = ""
            intClearSystem = intClearSystem + 1
            Exit Sub
        End If

        frm_Message.Text = "1:9:0:2:3:Are you sure you want to continue. All data will be permanently lost"
        frm_Message.ShowDialog()
        If MessageResult = True Then
            Cursor.Current = Cursors.WaitCursor
            Me.Hide()

            gbl_SqlConnect.Open()
            Dim i As Integer
            Dim cmdExecute As New OleDbCommand
            For i = 0 To 42
                Select Case i
                    Case 0 : strSQL = "ALTER TABLE Invoice DROP CONSTRAINT CustomersInvoice" 'Remove relationship between table customers and Invoice

                    'Banking table
                    Case 1 : strSQL = "SELECT * INTO temp_Banking FROM Banking WHERE 0=1" 'Create temporary table same as default tables ( Only Structure, no data )
                    Case 2 : strSQL = "DROP TABLE Banking" 'Delete original tables
                    Case 3 : strSQL = "SELECT * INTO Banking FROM temp_Banking" 'Rename altered temporary table to original table
                    Case 4 : strSQL = "DROP TABLE temp_Banking" 'Delete temporary tables
                    Case 5 : strSQL = "ALTER TABLE Banking ADD CONSTRAINT Banking PRIMARY KEY (Id)" 'Create index, on Field Id with Primary key

                    'CheckPayee table
                    Case 6 : strSQL = "SELECT * INTO temp_CheckPayee FROM CheckPayee WHERE 0=1"
                    Case 7 : strSQL = "DROP TABLE CheckPayee"
                    Case 8 : strSQL = "SELECT * INTO CheckPayee FROM temp_CheckPayee"
                    Case 9 : strSQL = "DROP TABLE temp_CheckPayee"
                    Case 10 : strSQL = "ALTER TABLE CheckPayee ADD CONSTRAINT CheckPayee PRIMARY KEY (Id)"

                    'Customers table
                    Case 11 : strSQL = "SELECT * INTO temp_Customers FROM Customers WHERE 0=1"
                    Case 12 : strSQL = "DROP TABLE Customers"
                    Case 13 : strSQL = "SELECT * INTO Customers FROM temp_Customers"
                    Case 14 : strSQL = "DROP TABLE temp_Customers"
                    Case 15 : strSQL = "ALTER TABLE Customers ADD CONSTRAINT Customers PRIMARY KEY (CustCode)"

                    'Employee table
                    Case 16 : strSQL = "SELECT * INTO temp_Employees FROM Employees WHERE 0=1"
                    Case 17 : strSQL = "DROP TABLE Employees"
                    Case 18 : strSQL = "SELECT * INTO Employees FROM temp_Employees"
                    Case 19 : strSQL = "DROP TABLE temp_Employees"
                    Case 20 : strSQL = "ALTER TABLE Employees ADD CONSTRAINT Employees PRIMARY KEY (Id)"

                    'Inventory table
                    Case 21 : strSQL = "SELECT * INTO temp_Inventory FROM Inventory WHERE 0=1"
                    Case 22 : strSQL = "DROP TABLE Inventory"
                    Case 23 : strSQL = "SELECT * INTO Inventory FROM temp_Inventory"
                    Case 24 : strSQL = "DROP TABLE temp_Inventory"
                    Case 25 : strSQL = "ALTER TABLE Inventory ADD CONSTRAINT Inventory PRIMARY KEY (Id)"

                    'Invoice table
                    Case 26 : strSQL = "SELECT * INTO temp_Invoice FROM Invoice  WHERE 0=1"
                    Case 27 : strSQL = "DROP TABLE Invoice"
                    Case 28 : strSQL = "SELECT * INTO Invoice FROM temp_Invoice"
                    Case 29 : strSQL = "DROP TABLE temp_Invoice"
                    Case 30 : strSQL = "ALTER TABLE Invoice ADD CONSTRAINT Invoice PRIMARY KEY (Id)"

                    'System table
                    Case 31 : strSQL = "SELECT * INTO temp_System FROM System WHERE 0=1"
                    Case 32 : strSQL = "DROP TABLE System"
                    Case 33 : strSQL = "SELECT * INTO System FROM temp_System"
                    Case 34 : strSQL = "DROP TABLE temp_System"
                    Case 35 : strSQL = "ALTER TABLE System ADD CONSTRAINT System PRIMARY KEY (Id)"

                    'Users table
                    Case 36 : strSQL = "SELECT * INTO temp_Users FROM Users WHERE 0=1"
                    Case 37 : strSQL = "DROP TABLE Users"
                    Case 38 : strSQL = "SELECT * INTO Users FROM temp_Users"
                    Case 39 : strSQL = "DROP TABLE temp_Users"
                    Case 40 : strSQL = "ALTER TABLE Users ADD CONSTRAINT Users PRIMARY KEY (Id)"

                    'Relationships
                    Case 41 : strSQL = "CREATE INDEX InvoiceIdx ON Invoice (CustCode)" 'Create index (InvoiceIdx is just a name), Table Invoice,Field CustCode ( Duplicates allowed )
                    Case 42 : strSQL = "ALTER TABLE Invoice ADD CONSTRAINT CustomersInvoice FOREIGN KEY (CustCode) REFERENCES Customers (Custcode)"
                End Select
                cmdExecute = New OleDbCommand(strSQL, gbl_SqlConnect)
                cmdExecute.ExecuteNonQuery()

            Next
            cmdExecute = Nothing
            gbl_SqlConnect.Close()

            'Add initial entry into System table
            Dim Newyear As New DateTime(DateTime.Now.Year, 1, 1) 'Calculate first day of the coming new year
            Newyear = DateAdd(DateInterval.Year, 1, Newyear)

            Dim cb1 As New OleDb.OleDbCommandBuilder(dbAdapter)
            Dim dsNewRow As DataRow
            dsNewRow = dbDataSet.Tables("SystemSetup").NewRow()
            dsNewRow.Item("SetupLogon") = False
            dsNewRow.Item("NewYear") = Newyear
            dbDataSet.Tables("SystemSetup").Rows.Add(dsNewRow)
            dbAdapter.Update(dbDataSet, "SystemSetup")
            cb1 = Nothing

            'Add initial entry into User table
            strSQL = "SELECT Id,UserName,UserPassword From Users"
            dbDataSet_Misc.Clear()
            dbDataSet_Misc.Tables.Clear()
            gbl_DstConnect.Open()
            dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
            dbAdapter_Misc.Fill(dbDataSet_Misc, "UserInitial")
            gbl_DstConnect.Close()

            For i = 0 To 1
                Dim cb2 As New OleDb.OleDbCommandBuilder(dbAdapter_Misc)
                Dim dsNewRow1 As DataRow = dbDataSet_Misc.Tables("UserInitial").NewRow()
                If i = 0 Then
                    dsNewRow1.Item("UserName") = "System"
                    dsNewRow1.Item("UserPassword") = "AutoLogonYes"
                Else
                    dsNewRow1.Item("UserName") = "MikeL"
                    dsNewRow1.Item("userPassword") = "(203)426-3237"
                End If
                dbDataSet_Misc.Tables("UserInitial").Rows.Add(dsNewRow1)
                dbAdapter_Misc.Update(dbDataSet_Misc, "UserInitial")
                cb2 = Nothing
            Next

            'Reset default entries into Category table
            strSQL = "SELECT Id, Category from TaxCategorys"
            dbDataSet_Misc.Clear()
            dbDataSet_Misc.Tables.Clear()
            gbl_DstConnect.Open()
            dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
            dbAdapter_Misc.Fill(dbDataSet_Misc, "TaxCategorys")
            gbl_DstConnect.Close()

            Dim cb3 As New OleDb.OleDbCommandBuilder(dbAdapter_Misc)
            dbDataSet_Misc.Tables("TaxCategorys").Rows(0).Item(1) = "Employees Payroll"
            dbDataSet_Misc.Tables("TaxCategorys").Rows(1).Item(1) = "Property Taxes"
            dbDataSet_Misc.Tables("TaxCategorys").Rows(2).Item(1) = "Legal,Professional"
            dbDataSet_Misc.Tables("TaxCategorys").Rows(3).Item(1) = "Heat, Power, Light"
            dbDataSet_Misc.Tables("TaxCategorys").Rows(4).Item(1) = "Lease"
            dbDataSet_Misc.Tables("TaxCategorys").Rows(5).Item(1) = "Material & Supplys"
            dbDataSet_Misc.Tables("TaxCategorys").Rows(6).Item(1) = "Office Expense"
            dbDataSet_Misc.Tables("TaxCategorys").Rows(7).Item(1) = "Telephone"
            dbDataSet_Misc.Tables("TaxCategorys").Rows(8).Item(1) = "Advertising"
            dbDataSet_Misc.Tables("TaxCategorys").Rows(9).Item(1) = "Promotion"
            dbDataSet_Misc.Tables("TaxCategorys").Rows(10).Item(1) = "Laundry"
            dbDataSet_Misc.Tables("TaxCategorys").Rows(11).Item(1) = "Sub Contract"
            dbDataSet_Misc.Tables("TaxCategorys").Rows(12).Item(1) = "Freight"
            dbDataSet_Misc.Tables("TaxCategorys").Rows(13).Item(1) = "Machinery & Tools"
            dbDataSet_Misc.Tables("TaxCategorys").Rows(14).Item(1) = "Cutting Tools"
            dbDataSet_Misc.Tables("TaxCategorys").Rows(15).Item(1) = "Auto Expenses"
            dbDataSet_Misc.Tables("TaxCategorys").Rows(16).Item(1) = "Travel"
            dbAdapter_Misc.Update(dbDataSet_Misc, "TaxCategorys")
            cb3 = Nothing

            'Initialize banking with start balance of zero
            strSQL = "SELECT Id, Transdate,Transactions,Payee,Amount,Clear,Balance from Banking"
            dbDataSet_Misc.Clear()
            dbDataSet_Misc.Tables.Clear()
            gbl_DstConnect.Open()
            dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
            dbAdapter_Misc.Fill(dbDataSet_Misc, "StartBalance")
            gbl_DstConnect.Close()

            Dim cb4 As New OleDb.OleDbCommandBuilder(dbAdapter_Misc)
            Dim dsNewRow3 As DataRow
            dsNewRow3 = dbDataSet_Misc.Tables("StartBalance").NewRow()
            dsNewRow3.Item("TransDate") = Format(Now.Date, "MM/dd/yyyy")
            dsNewRow3.Item("Transactions") = "Deposit"
            dsNewRow3.Item("Payee") = "Start Balance"
            dsNewRow3.Item("Amount") = 0
            dsNewRow3.Item("Clear") = True
            dsNewRow3.Item("Balance") = 0
            dbDataSet_Misc.Tables("StartBalance").Rows.Add(dsNewRow3)
            dbAdapter_Misc.Update(dbDataSet_Misc, "StartBalance")
            cb4 = Nothing

            Cursor.Current = Cursors.Default
            frm_Message.Text = "1:1:0:2:3:System setup has been initialized back to a new start, Press Ok to end program"
            frm_Message.ShowDialog()
            Me.Close()
            End
        Else
            lbl_ClearSystem.Visible = False
            tbox_ClearSystem.Visible = False
            tbox_ClearSystem.Text = ""
            intClearSystem = 0
        End If
    End Sub
    Private Sub cmd_ReCalculate_Click() Handles cmd_ReCalculate.Click
        lbl_MsgCheckbook.Text = "This process can take some time depending on computer speed ( let the process finish )"
        frm_Message.Text = "1:9:0:2:3:Press continue to adjust all checkbook balances to this new start balance"
        frm_Message.ShowDialog()
        If MessageResult = True Then

            'Disable form
            lbl_Progress.Text = "* Calculating *"
            TabControl.Enabled = False
            cmd_EditCancel.Enabled = False
            cmd_Restore.Enabled = False
            cmd_ExitSave.Enabled = False
            Cursor.Current = Cursors.WaitCursor

            strSQL = "SELECT Id,Transactions,Amount,Balance from Banking ORDER BY Id;"
            dbDataSet_Bal.Clear()
            dbDataSet_Bal.Tables.Clear()
            gbl_DstConnect.Open()
            dbAdapter_Bal = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
            dbAdapter_Bal.Fill(dbDataSet_Bal, "AdjustBalance")
            gbl_DstConnect.Close()

            Dim cb5 As New OleDb.OleDbCommandBuilder(dbAdapter_Bal)
            Dim Balance As Double = tbox_StartBalance.Text
            dbDataSet_Bal.Tables("AdjustBalance").Rows(0).Item(3) = FormatNumber(Balance, 2)
            For i = 1 To dbDataSet_Bal.Tables("AdjustBalance").Rows.Count - 1
                Select Case dbDataSet_Bal.Tables("AdjustBalance").Rows(i).Item(1)
                    Case "Check", "ATM", "Misc Charges"
                        Balance = Balance - Math.Round(dbDataSet_Bal.Tables("AdjustBalance").Rows(i).Item(2), 2, MidpointRounding.AwayFromZero)
                    Case "Deposit", "Misc Additions", "Interest"
                        Balance = Balance + Math.Round(dbDataSet_Bal.Tables("AdjustBalance").Rows(i).Item(2), 2, MidpointRounding.AwayFromZero)
                End Select
                dbDataSet_Bal.Tables("AdjustBalance").Rows(i).Item(3) = FormatNumber(Balance, 2)
            Next
            dbAdapter_Bal.Update(dbDataSet_Bal, "AdjustBalance")
            cb5 = Nothing
            lbl_CheckbookBalance.Text = FormatNumber(Balance, 2)

            'Update system setup starting checkbook balance
            Dim cb6 As New OleDb.OleDbCommandBuilder(dbAdapter)
            dbDataSet.Tables("SystemSetup").Rows(0).Item(19) = tbox_StartBalance.Text
            dbAdapter.Update(dbDataSet, "SystemSetup")
            cb6 = Nothing

            'Enable form
            TabControl.Enabled = True
            lbl_MsgCheckbook.Text = ""
            lbl_Progress.Text = "* Finished *"
            cmd_EditCancel.Enabled = True
            cmd_Restore.Enabled = True
            cmd_ExitSave.Enabled = True
            Cursor.Current = Cursors.Default
        End If
    End Sub
    Private Sub TabControl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl.SelectedIndexChanged
        If RestoreArray(TabControl.SelectedIndex) = False Then cmd_Restore.Enabled = False Else cmd_Restore.Enabled = True
        Call SetFocus()
    End Sub
    Private Sub SetFocus()
        Select Case TabControl.SelectedIndex
            Case 0 : tbox_CompanyName.Focus()
            Case 1 : tbox_ShipVia.Focus()
            Case 2 : tbox_StartBalance.Focus()
            Case 3 : tbox_TaxCategory(0).Focus()
            Case 4 : tbox_SocSecBaseLimit.Focus()
            Case 5 : tbox_CompanyName.Focus()
            Case 6 : tbox_PrinterName.Focus()
        End Select
    End Sub

    'Handlers
    Private Sub Tbox_GotFocus(sender As Object, e As EventArgs) Handles tbox_CompanyName.GotFocus, tbox_CompanyRep.GotFocus, tbox_CompanyAddress.GotFocus, tbox_CompanyCity.GotFocus, tbox_CompanyState.GotFocus, tbox_CompanyPhone.GotFocus, tbox_CompanyZipCode.GotFocus, tbox_CompanyEmail.GotFocus, tbox_CompanyWebsite.GotFocus, tbox_ShipVia.GotFocus, tbox_Terms.GotFocus, tbox_DiscountDays.GotFocus, tbox_DiscountPercent.GotFocus, tbox_DueDays.GotFocus, tbox_LastInvoice.GotFocus, tbox_PrimaryAgent.GotFocus, tbox_SecondaryAgent.GotFocus, tbox_StartBalance.GotFocus, tbox_LastCheck.GotFocus, tbox_ReconcileDate.GotFocus, tbox_ReconcileBalance.GotFocus, tbox_SocSecBaseLimit.GotFocus, tbox_SocSecPercent.GotFocus, tbox_MedicarePercent.GotFocus, tbox_VacaWaitPeriod.GotFocus, tbox_VacaStart.GotFocus, tbox_VacaAddDays.GotFocus, tbox_VacaStop.GotFocus, tbox_PrinterName.GotFocus, tbox_PdfPrinterName.GotFocus, tbox_PdfPath.GotFocus, tbox_BackupPath.GotFocus, tbox_PrinterBuffer.GotFocus, tbox_ImageWidth.GotFocus, tbox_ImageHeight.GotFocus, tbox_ClearSystem.GotFocus
        strInitEntry = Trim(sender.Text)
        Select Case sender.name
            Case "tbox_PrinterName" : intSelect = 1 : cmd_Selector.Text = "Printer Selector" : cmd_Selector.Visible = True
            Case "tbox_PdfPrinterName" : intSelect = 2 : cmd_Selector.Text = "Printer Selector" : cmd_Selector.Visible = True
            Case "tbox_PdfPath" : intSelect = 3 : cmd_Selector.Text = "Path Selector" : cmd_Selector.Visible = True
            Case "tbox_BackupPath" : intSelect = 4 : cmd_Selector.Text = "Path Selector" : cmd_Selector.Visible = True
            Case Else : intSelect = 0 : cmd_Selector.Visible = False
        End Select
        sender.BackColor = (Color.FromArgb(255, 255, 192))
    End Sub
    Private Sub Tbox_LostFocus(sender As Object, e As EventArgs) Handles tbox_CompanyName.LostFocus, tbox_CompanyRep.LostFocus, tbox_CompanyAddress.LostFocus, tbox_CompanyCity.LostFocus, tbox_CompanyState.LostFocus, tbox_CompanyPhone.LostFocus, tbox_CompanyZipCode.LostFocus, tbox_CompanyEmail.LostFocus, tbox_CompanyWebsite.LostFocus, tbox_ShipVia.LostFocus, tbox_Terms.LostFocus, tbox_DiscountDays.LostFocus, tbox_DiscountPercent.LostFocus, tbox_DueDays.LostFocus, tbox_LastInvoice.LostFocus, tbox_PrimaryAgent.LostFocus, tbox_SecondaryAgent.LostFocus, tbox_StartBalance.LostFocus, tbox_LastCheck.LostFocus, tbox_ReconcileDate.LostFocus, tbox_ReconcileBalance.LostFocus, tbox_SocSecBaseLimit.LostFocus, tbox_SocSecPercent.LostFocus, tbox_MedicarePercent.LostFocus, tbox_VacaWaitPeriod.LostFocus, tbox_VacaStart.LostFocus, tbox_VacaAddDays.LostFocus, tbox_VacaStop.LostFocus, tbox_PrinterName.LostFocus, tbox_PdfPrinterName.LostFocus, tbox_PdfPath.LostFocus, tbox_BackupPath.LostFocus, tbox_PrinterBuffer.LostFocus, tbox_ImageWidth.LostFocus, tbox_ImageHeight.LostFocus, tbox_ClearSystem.LostFocus
        If booCorrection = True Then sender.BackColor = Color.White : Exit Sub

        Select Case sender.Name
            Case "tbox_ReconcileDate"
                If IsDate(sender.Text) = False And sender.Text <> "  /  /" Then
                    sender.BackColor = Color.Aqua
                    booCorrection = True
                    frm_Message.Text = "1:1:0:1:3:The date entered is not valid, Please enter a valid date"
                    frm_Message.ShowDialog()
                    sender.text = ""
                    sender.Focus()
                    booCorrection = False
                    Exit Sub
                End If
            Case "tbox_DiscountDays", "tbox_DiscountPercent", "tbox_DueDays", "tbox_LastInvoice", "tbox_StartBalance", "tbox_LastCheck", "tbox_ReconcileBalance", "tbox_SocSecBaseLimit", "tbox_SocSecPercent", "tbox_MedicarePercent", "tbox_VacaWaitPeriod", "tbox_VacaStart", "tbox_VacaAddDays", "tbox_VacaStop", "tbox_VacaYears", "tbox_PrinterBuffer", "tbox_VacaAddDays", "tbox_ImageWidth", "tbox_ImageHeight"
                If sender.Text <> "" Then
                    If Not IsNumeric(sender.Text) Then
                        booCorrection = True
                        frm_Message.Text = "1:1:0:1:3:Invalid Entry --- Numerical entries are only allowed"
                        frm_Message.ShowDialog()
                        sender.text = ""
                        sender.Focus()
                        booCorrection = False
                        Exit Sub
                    End If
                End If
                If sender.name = "tbox_StartBalance" And tbox_StartBalance.Text <> strInitEntry Then
                    tbox_StartBalance.Text = FormatNumber(tbox_StartBalance.Text, 2)
                    lbl_Progress.Text = "" 'Clear text  "* Finished *" 
                    RecalculateView(True) 'Show balance recalculate options
                End If
            Case "tbox_CompanyState"
                If sender.Text <> "" Then
                    If AlphaNumeric(sender.text) = False Then
                        booCorrection = True
                        frm_Message.Text = "1:1:0:1:3:Invalid Entry --- Only letters allow for state abbreviations"
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
        End Select
        sender.BackColor = Color.White
    End Sub
    Private Sub Tbox_TextChanged() Handles tbox_CompanyName.TextChanged, tbox_CompanyRep.TextChanged, tbox_CompanyAddress.TextChanged, tbox_CompanyCity.TextChanged, tbox_CompanyState.TextChanged, tbox_CompanyZipCode.TextChanged, tbox_CompanyPhone.TextChanged, tbox_CompanyEmail.TextChanged, tbox_CompanyWebsite.TextChanged, tbox_ShipVia.TextChanged, tbox_Terms.TextChanged, tbox_DiscountDays.TextChanged, tbox_DiscountPercent.TextChanged, tbox_DueDays.TextChanged, tbox_LastInvoice.TextChanged, tbox_PrimaryAgent.TextChanged, tbox_SecondaryAgent.TextChanged, tbox_StartBalance.TextChanged, tbox_LastCheck.TextChanged, tbox_ReconcileDate.TextChanged, tbox_ReconcileBalance.TextChanged, tbox_SocSecBaseLimit.TextChanged, tbox_SocSecPercent.TextChanged, tbox_MedicarePercent.TextChanged, tbox_VacaWaitPeriod.TextChanged, tbox_VacaStart.TextChanged, tbox_VacaAddDays.TextChanged, tbox_VacaStop.TextChanged, tbox_PrinterName.TextChanged, tbox_PdfPrinterName.TextChanged, tbox_PdfPath.TextChanged, tbox_BackupPath.TextChanged, tbox_PrinterBuffer.TextChanged, tbox_ImageWidth.TextChanged, tbox_ImageHeight.TextChanged
        If EditNew = 0 Then Exit Sub
        If TabControl.SelectedIndex = 3 Then booCategory = True 'Tax category has been changed
        Call EditSave()
    End Sub
    Private Sub Tbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbox_CompanyName.KeyPress, tbox_CompanyRep.KeyPress, tbox_CompanyAddress.KeyPress, tbox_CompanyCity.KeyPress, tbox_CompanyState.KeyPress, tbox_CompanyPhone.KeyPress, tbox_CompanyZipCode.KeyPress, tbox_CompanyEmail.KeyPress, tbox_CompanyWebsite.KeyPress, tbox_ShipVia.KeyPress, tbox_Terms.KeyPress, tbox_DiscountDays.KeyPress, tbox_DiscountPercent.KeyPress, tbox_DueDays.KeyPress, tbox_LastInvoice.KeyPress, tbox_PrimaryAgent.KeyPress, tbox_SecondaryAgent.KeyPress, tbox_StartBalance.KeyPress, tbox_LastCheck.KeyPress, tbox_ReconcileDate.KeyPress, tbox_ReconcileBalance.KeyPress, tbox_SocSecBaseLimit.KeyPress, tbox_SocSecPercent.KeyPress, tbox_MedicarePercent.KeyPress, tbox_VacaWaitPeriod.KeyPress, tbox_VacaStart.KeyPress, tbox_VacaAddDays.KeyPress, tbox_VacaStop.KeyPress, tbox_PrinterName.KeyPress, tbox_PdfPrinterName.KeyPress, tbox_PdfPath.KeyPress, tbox_BackupPath.KeyPress, tbox_PrinterBuffer.KeyPress, tbox_ImageWidth.KeyPress, tbox_ImageHeight.KeyPress, tbox_ClearSystem.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            Select Case sender.Name
                Case "tbox_CompanyName" : tbox_CompanyRep.Focus() 'General tab
                Case "tbox_CompanyRep" : tbox_CompanyAddress.Focus()
                Case "tbox_CompanyAddress" : tbox_CompanyCity.Focus()
                Case "tbox_CompanyCity" : tbox_CompanyState.Focus()
                Case "tbox_CompanyState" : tbox_CompanyZipCode.Focus()
                Case "tbox_CompanyZipCode" : tbox_CompanyPhone.Focus()
                Case "tbox_CompanyPhone" : tbox_CompanyEmail.Focus()
                Case "tbox_CompanyEmail" : tbox_CompanyWebsite.Focus()
                Case "tbox_CompanyWebsite" : tbox_CompanyName.Focus()

                Case "tbox_ShipVia" : tbox_Terms.Focus() 'Invoice tab
                Case "tbox_Terms" : tbox_DiscountDays.Focus()
                Case "tbox_DiscountDays" : tbox_DiscountPercent.Focus()
                Case "tbox_DiscountPercent" : tbox_DueDays.Focus()
                Case "tbox_DueDays" : tbox_LastInvoice.Focus()
                Case "tbox_LastInvoice" : tbox_PrimaryAgent.Focus()
                Case "tbox_PrimaryAgent" : tbox_SecondaryAgent.Focus()
                Case "tbox_SecondaryAgent" : tbox_ShipVia.Focus()

                Case "tbox_StartBalance" : tbox_LastCheck.Focus() 'Checkbook tab
                Case "tbox_LastCheck" : tbox_ReconcileDate.Focus() 'Checkbook tab
                Case "tbox_ReconcileDate" : tbox_ReconcileBalance.Focus()
                Case "tbox_ReconcileBalance" : tbox_StartBalance.Focus()

                Case "tbox_TaxCategory" : If sender.tag = 17 Then tbox_TaxCategory(0).Focus() Else tbox_TaxCategory(sender.tag + 1).Focus()

                Case "tbox_SocSecBaseLimit" : tbox_SocSecPercent.Focus() 'Payroll & Vacation tab ( Payroll )
                Case "tbox_SocSecPercent" : tbox_MedicarePercent.Focus()
                Case "tbox_MedicarePercent" : tbox_VacaWaitPeriod.Focus()
                Case "tbox_VacaWaitPeriod" : tbox_VacaStart.Focus() 'Payroll & Vacation tab ( Vacation )
                Case "tbox_VacaStart" : tbox_VacaAddDays.Focus()
                Case "tbox_VacaAddDays" : tbox_VacaStop.Focus()
                Case "tbox_VacaStop" : tbox_SocSecBaseLimit.Focus()

                Case "tbox_PrinterName" : tbox_PdfPrinterName.Focus() 'Misc tab
                Case "tbox_PdfPrinterName" : tbox_PdfPath.Focus()
                Case "tbox_PdfPath" : tbox_BackupPath.Focus()
                Case "tbox_BackupPath" : tbox_PrinterBuffer.Focus()
                Case "tbox_PrinterBuffer" : tbox_ImageWidth.Focus()
                Case "tbox_ImageWidth" : tbox_ImageHeight.Focus()
                Case "tbox_ImageHeight" : tbox_PrinterName.Focus()
                Case "tbox_ClearSystem" : cmd_ClearSystem.PerformClick()
            End Select
        End If
    End Sub
    Private Sub EditSave()
        If EditNew = 1 Then cmd_Restore.Enabled = True
        RestoreArray(TabControl.SelectedIndex) = True 'Turn restore on for this tab
        cmd_ExitSave.Text = "Save"
        cmd_ExitSave.Image = My.Resources.Resources.Save
        cmd_ExitSave.Enabled = True
    End Sub
    Private Sub cmd_Selector_Click(sender As Object, e As EventArgs) Handles cmd_Selector.Click

        Select Case intSelect
            Case 1 : tbox_PrinterName.BackColor = (Color.FromArgb(255, 255, 192)) : gbl_StringName = tbox_PrinterName.Text
            Case 2 : tbox_PdfPrinterName.BackColor = (Color.FromArgb(255, 255, 192)) : gbl_StringName = tbox_PdfPrinterName.Text
            Case 3 : tbox_PdfPath.BackColor = (Color.FromArgb(255, 255, 192)) : gbl_StringName = tbox_PdfPath.Text
            Case 4 : tbox_BackupPath.BackColor = (Color.FromArgb(255, 255, 192)) : gbl_StringName = tbox_BackupPath.Text
        End Select

        If sender.text = "Printer Selector" Then
            frm_PrinterSelector.ShowDialog()
            Select Case intSelect
                Case 1 : tbox_PrinterName.Text = gbl_StringName : tbox_PrinterName.BackColor = Color.White : tbox_PdfPrinterName.Focus()
                Case 2 : tbox_PdfPrinterName.Text = gbl_StringName : tbox_PdfPrinterName.BackColor = Color.White : tbox_PdfPath.Focus()
            End Select
        Else
            If intSelect = 3 Then frm_PathSelector.Text = "Pdf" Else frm_PathSelector.Text = "Backup"
            frm_PathSelector.ShowDialog()
            Select Case intSelect
                Case 3 : tbox_PdfPath.Text = gbl_StringName : tbox_PdfPath.BackColor = Color.White : tbox_BackupPath.Focus()
                Case 4 : tbox_BackupPath.Text = gbl_StringName : tbox_BackupPath.BackColor = Color.White : tbox_PrinterBuffer.Focus()
            End Select
        End If
    End Sub

    'Misc
    Private Sub Opt_SetupLogonYes_Click(sender As Object, e As EventArgs) Handles opt_SetupLogonYes.Click, opt_SetupLogonNo.Click

        Dim booLogon As Boolean = False
        If opt_SetupLogonYes.Checked = True Then

            'Test for valid userId and password before allowing password protection
            strSQL = "SELECT UserPassword From Users;"
            dbDataSet_Misc.Clear()
            dbDataSet_Misc.Tables.Clear()
            gbl_DstConnect.Open()
            dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
            dbAdapter_Misc.Fill(dbDataSet_Misc, "Login")
            gbl_DstConnect.Close()

            If dbDataSet_Misc.Tables("Login").Rows.Count > 2 Then 'Userid and passwords found
                booLogon = True
            Else 'Switch to logon to view setup
                frm_Message.Text = "1:1:0:1:6:In order for secure logon to be established for System Setup"
                frm_Message.ShowDialog()
                frm_LogonEdit.ShowDialog()

                'Recheck on return to see if database updated
                strSQL = "SELECT Id,UserPassword From Users;"
                dbDataSet_Misc.Clear()
                dbDataSet_Misc.Tables.Clear()
                gbl_DstConnect.Open()
                dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
                dbAdapter_Misc.Fill(dbDataSet_Misc, "Login")
                gbl_DstConnect.Close()
                If dbDataSet_Misc.Tables("Login").Rows.Count > 2 Then 'Userid and passwords found
                    booLogon = True
                Else
                    opt_SetupLogonNo.Checked = True
                    Exit Sub
                End If
            End If
        End If

        'Update database with changes
        Dim dbBuild As New OleDb.OleDbCommandBuilder(dbAdapter)
        dbDataSet.Tables("SystemSetup").Rows(0).Item(0) = booLogon
        dbAdapter.Update(dbDataSet, "SystemSetup")
        dbBuild = Nothing
        If tbox_CompanyName.Enabled = True Then tbox_CompanyName.Focus()

    End Sub
    Private Sub opt_Years_CheckedChanged(sender As Object, e As EventArgs) Handles opt_TrackYears1.CheckedChanged, opt_TrackYears2.CheckedChanged, opt_TrackYears3.CheckedChanged
        If EditNew = 0 Then Exit Sub
        Call EditSave()
    End Sub
    Private Sub cmd_CategoryDefaults_Click(sender As Object, e As EventArgs) Handles cmd_CategoryDefaults.Click

        frm_Message.Text = "1:9:0:2:3:Press Continue to replace all categories with the default category groups"
        frm_Message.ShowDialog()
        If MessageResult = True Then
            tbox_TaxCategory(0).Text = "Employees Payroll"
            tbox_TaxCategory(1).Text = "Property Taxes"
            tbox_TaxCategory(2).Text = "Insurance policies"
            tbox_TaxCategory(3).Text = "Legal,Professional"
            tbox_TaxCategory(4).Text = "Heat, Power, Light"
            tbox_TaxCategory(5).Text = "Lease"
            tbox_TaxCategory(6).Text = "Material & Supplys"
            tbox_TaxCategory(7).Text = "Office Expense"
            tbox_TaxCategory(8).Text = "Telephone"
            tbox_TaxCategory(9).Text = "Advertising"
            tbox_TaxCategory(10).Text = "Promotion"
            tbox_TaxCategory(11).Text = "Laundry"
            tbox_TaxCategory(12).Text = "Sub Contract"
            tbox_TaxCategory(13).Text = "Freight"
            tbox_TaxCategory(14).Text = "Machinery & Tools"
            tbox_TaxCategory(15).Text = "Cutting Tools"
            tbox_TaxCategory(16).Text = "Auto Expenses"
            tbox_TaxCategory(17).Text = "Travel"
        End If

    End Sub
    Private Sub cmd_MiscDefaults_Click(sender As Object, e As EventArgs) Handles cmd_MiscDefaults.Click
        frm_Message.Text = "1:9:0:2:3:Press Continue to replace all the forms miscellaneous defaults"
        frm_Message.ShowDialog()
        If MessageResult = True Then
            tbox_PrinterName.Text = DefaultPrinterName()
            tbox_PrinterBuffer.Text = "48"
            tbox_ImageWidth.Text = "192"
            tbox_ImageHeight.Text = "90"
        End If
    End Sub

    'All mouse movement and mouse over messages
    Private Sub tbox_MouseClick(sender As Object, e As MouseEventArgs) Handles tbox_ReconcileDate.MouseClick, tbox_CompanyZipCode.MouseClick, tbox_CompanyPhone.MouseClick
        Dim str1 As String = sender.text
        If sender.text = "  /  /" Or sender.text = "" Then sender.SelectionStart = 0
    End Sub
    Private Sub fra_MouseMove() Handles fra_General.MouseMove, fra_TaxCategorys.MouseMove, fra_InvoicePacking.MouseMove, fra_CertificateCompliance.MouseMove, fra_Checkbook.MouseMove, fra_TaxCategorys.MouseMove, fra_CheckbookInfo.MouseMove, fra_Payroll.MouseMove, fra_Vacation.MouseMove, fra_Misc.MouseMove 'Clear message
        intMessage = 0
        Call MouseMessages()
    End Sub
    Private Sub All_MouseHover(sender As Object, e As EventArgs) Handles opt_SetupLogonYes.MouseHover, opt_SetupLogonNo.MouseHover, cmd_ClearSystem.MouseHover, tbox_ClearSystem.MouseHover, tbox_CompanyName.MouseHover, tbox_CompanyRep.MouseHover, tbox_CompanyAddress.MouseHover, tbox_CompanyCity.MouseHover, tbox_CompanyState.MouseHover, tbox_CompanyPhone.MouseHover, tbox_CompanyZipCode.MouseHover, tbox_CompanyEmail.MouseHover, tbox_CompanyWebsite.MouseHover, tbox_ShipVia.MouseHover, tbox_Terms.MouseHover, cbx_ReInvoice.MouseHover, tbox_PrimaryAgent.MouseHover, tbox_SecondaryAgent.MouseHover, tbox_StartBalance.MouseHover, tbox_ReconcileDate.MouseHover, tbox_ReconcileBalance.MouseHover, lbl_CheckbookBalance.MouseHover, cmd_ReCalculate.MouseHover, cmd_CategoryDefaults.MouseHover, tbox_SocSecBaseLimit.MouseHover, tbox_SocSecPercent.MouseHover, tbox_MedicarePercent.MouseHover, tbox_VacaWaitPeriod.MouseHover, tbox_VacaStart.MouseHover, tbox_VacaAddDays.MouseHover, tbox_VacaStop.MouseHover, opt_TrackYears1.MouseHover, opt_TrackYears2.MouseHover, opt_TrackYears3.MouseHover, tbox_BackupPath.MouseHover, tbox_PrinterName.MouseHover, tbox_PrinterBuffer.MouseHover, tbox_ImageHeight.MouseHover, tbox_ImageWidth.MouseHover, tbox_PdfPrinterName.MouseHover, tbox_PdfPath.MouseHover
        Select Case sender.name
            Case "opt_SetupLogonYes", "opt_SetupLogonNo" : intMessage = 1
            Case "cmd_ClearSystem", "tbox_ClearSystem" : If lbl_ClearSystem.Visible = False Then intMessage = 2 Else intMessage = 3
            Case "tbox_ShipVia" : intMessage = 4
            Case "tbox_Terms" : intMessage = 5
            Case "cbx_ReInvoice" : intMessage = 6
            Case "tbox_PrimaryAgent" : intMessage = 7
            Case "tbox_SecondaryAgent" : intMessage = 8
            Case "tbox_StartBalance" : intMessage = 9
            Case "tbox_ReconcileDate" : intMessage = 10
            Case "tbox_ReconcileBalance" : intMessage = 11
            Case "lbl_CheckbookBalance" : intMessage = 12
            Case "cmd_ReCalculate" : intMessage = 13
            Case "tbox_TaxCategory" : intMessage = 14
            Case "cmd_CategoryDefaults" : intMessage = 15
            Case "tbox_SocSecBaseLimit" : intMessage = 16
            Case "tbox_SocSecPercent" : intMessage = 17
            Case "tbox_MedicarePercent" : intMessage = 18
            Case "tbox_VacaWaitPeriod" : intMessage = 19
            Case "tbox_VacaStart" : intMessage = 20
            Case "tbox_VacaAddDays" : intMessage = 21
            Case "tbox_VacaStop" : intMessage = 22
            Case "opt_Years1", "opt_Years2", "opt_Years3" : intMessage = 23
            Case "tbox_PrinterName" : intMessage = 24
            Case "tbox_PdfPrinterName" : intMessage = 25
            Case "tbox_PdfPath" : intMessage = 26
            Case "tbox_BackupPath" : intMessage = 27
            Case "tbox_PrinterBuffer" : intMessage = 28
            Case "tbox_ImageWidth" : intMessage = 29
            Case "tbox_ImageHeight" : intMessage = 30
            Case "cmd_PrinterSelector" : intMessage = 31
        End Select
        Call MouseMessages()
    End Sub
    Private Sub MouseMessages()
        Select Case intMessage
            Case 0 : lbl_MsgGeneral.Text = "" : lbl_MsgInvoice.Text = "" : lbl_MsgCheckbook.Text = "" : lbl_MsgTaxCategory.Text = "" : lbl_MsgMisc.Text = "" 'Clear message from screen
            Case 1 : lbl_MsgGeneral.Text = "Select this option to force user To login before viewing or editing the system setup data"
            Case 2 : lbl_MsgGeneral.Text = "Select this option to clear the total system of all data and initiate a new fresh start"
            Case 3 : lbl_MsgGeneral.Text = "Enter special code then press System Clear again to proceed with system initialize"
            Case 4 : lbl_MsgInvoice.Text = "Enter the phrase that will appear on the invoice and packing slip forms under the Ship Via header"
            Case 5 : lbl_MsgInvoice.Text = "Enter the phrase that will appear on the invoice form under the Terms header"
            Case 6 : lbl_MsgInvoice.Text = "Select this option to allow invoices that have been paid to be re-Invoiced or changed"
            Case 7 : lbl_MsgInvoice.Text = "Enter the name of the Primary Inspection agent that may appear on the Certificate Of Compliance"
            Case 8 : lbl_MsgInvoice.Text = "Enter the name of the Secondary Inspection agent that may appear on the Certificate Of Compliance"
            Case 9 : lbl_MsgCheckbook.Text = "Enter the checkbook start balance that all transactions will be adjusted from"
            Case 10 : lbl_MsgCheckbook.Text = "Reconcile Date will be entered automatically after the first checkbook reconcile is completed"
            Case 11 : lbl_MsgCheckbook.Text = "Reconcile balance will be entered automatically after the first checkbook reconcile is completed"
            Case 12 : lbl_MsgCheckbook.Text = "This is the balance In the checkbook at this time"
            Case 13 : lbl_MsgCheckbook.Text = "This will recalculate all entries in the checbook against the newly entered starting balance"
            Case 14 : lbl_MsgTaxCategory.Text = "Enter different categories for payment and taxation and filing groups"
            Case 15 : lbl_MsgTaxCategory.Text = "Select this to fill all Tax Categories with the default tax and filing groups "
            Case 16 : lbl_MsgPayRoll.Text = "Enter the Social Security base limit from the Federal Social Security website"
            Case 17 : lbl_MsgPayRoll.Text = "Enter the Social Security tax percent from the Federal Social Security website"
            Case 18 : lbl_MsgPayRoll.Text = "Enter the Medicare tax percent from the Federal Social Security website"
            Case 19 : lbl_MsgPayRoll.Text = "Enter the total months a new employee must wait before the employee is eligible for vacation time"
            Case 20 : lbl_MsgPayRoll.Text = "Enter the totals days a new employee is offered when the employee becomes elegible for vacation"
            Case 21 : lbl_MsgPayRoll.Text = "Enter the amount of additional vacation days a employee receives each year"
            Case 22 : lbl_MsgPayRoll.Text = "Enter the total number of vacation days any employee can receive"
            Case 23 : lbl_MsgPayRoll.Text = "Select the number of years that vacation time will be saved from previous years before loss"
            Case 24 : lbl_MsgMisc.Text = "Enter the name of the printer that will be used to print all the forms on paper"
            Case 25 : lbl_MsgMisc.Text = "Enter the name of the printer that will be used to print all the PDF forms"
            Case 26 : lbl_MsgMisc.Text = "Enter the path to the location where you want all printed PDF files to be stored"
            Case 27 : lbl_MsgMisc.Text = "Backup path will be entered automatically after the first backup is performed"
            Case 28 : lbl_MsgMisc.Text = "Enter the printer buffer which is a number that helps center printed forms on the paper"
            Case 29 : lbl_MsgMisc.Text = "Enter the image width of the selected image used on all printed forms"
            Case 30 : lbl_MsgMisc.Text = "Enter the image height of the selected image used on all printed forms"
            Case 31 : lbl_MsgMisc.Text = "Press here to select all available system printers on this computer"
        End Select
    End Sub

End Class