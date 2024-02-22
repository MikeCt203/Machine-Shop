Public Class frm_Employees

    Dim dbAdapter, dbAdapter_SystemData, dbAdapter_Misc As OleDb.OleDbDataAdapter
    Dim dbDataSet, dbDataSet_SystemData, dbDataSet_Misc As New DataSet
    Dim strSQL As String

    Dim ListArray(1, 1) As Integer 'Used to link dataset to listbox selection
    Dim EditNew As Integer '0 = no process, 1 = edit in process, 2 = new in process
    Dim booDataChecked As Boolean = True 'T = data change is from a controled process
    Dim booActives As Boolean 'T = active entries found in database
    Dim booNameCheck As Boolean 'T = Test for repeat of name has been done
    Dim intTotalRecords, AutoNum As Integer
    Dim strInitEntry, strBenefits, strNotes, strVacaNotes As String 'Variables to hold initial entries of textboxes to test for change
    Dim intLookup As Integer 'Used to locate edited / new saved record in listbox
    Dim intMessage As Integer 'Variable used in the mouse over event to show different messages
    Dim booCorrection As Boolean = False

    'All form related events
    Private Sub frm_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated
        Call Actives()
    End Sub
    Private Sub frm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.Text = "Employees Information                                                                                                                Date: " & Now.Date

        'Retrieve Social Security limits and last check number
        strSQL = "SELECT CompanyName,SocSecLimit,SocSecPercent,MedicarePercent,VacaTrackYears,VacaWaitPeriod FROM System;"
        dbDataSet_SystemData.Clear()
        dbDataSet_SystemData.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter_SystemData = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter_SystemData.Fill(dbDataSet_SystemData, "SystemData")
        gbl_DstConnect.Close()

        If booActives = True Then opt_Active.Checked = True Else opt_NonActive.Checked = True
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
    Private Sub Actives() 'Check if there are active particpants in the database
        strSQL = "SELECT ID FROM Employees Where Active = True"
        dbDataSet_Misc.Clear()
        dbDataSet_Misc.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter_Misc.Fill(dbDataSet_Misc, "Actives")
        gbl_DstConnect.Close()
        If dbDataSet_Misc.Tables("Actives").Rows.Count = 0 Then booActives = False Else booActives = True

    End Sub
    Private Sub Opt_Active_CheckedChanged() Handles opt_Active.CheckedChanged, opt_NonActive.CheckedChanged 'Index recordset based on selected option button
        If opt_Active.Checked = True And booActives = False Then 'No active partipants to show
            frm_Message.Text = "2:1:0:1:3:There are no employees on record to show"
            frm_Message.ShowDialog()
            opt_NonActive.Checked = True
            Exit Sub
        End If
        If opt_Active.Checked = True Then ListData(True) Else ListData(False)
    End Sub
    Private Sub ListData(booActive As Boolean)
        If booActive = True Then
            strSQL = "SELECT ID,LastName,FirstName FROM Employees Where Active = True ORDER BY LastName,FirstName;"
        Else
            strSQL = "SELECT ID,LastName,FirstName FROM Employees ORDER BY LastName,FirstName;"
        End If

        Call ClearData()
        dbDataSet_Misc.Clear()
        dbDataSet_Misc.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter_Misc.Fill(dbDataSet_Misc, "Employees")
        gbl_DstConnect.Close()
        intTotalRecords = dbDataSet_Misc.Tables("Employees").Rows.Count
        ReDim ListArray(0 To intTotalRecords - 1, 1)

        ListBox1.Items.Clear()
        If intTotalRecords = 0 Then 'No employees found, allow only new employees, disable listbox and hide option active button 
            ListBox1.Enabled = False
            cmd_Edit.Enabled = False  'Disable edit button
            cmd_DeleteCancel.Enabled = False 'Disable cancel button

            'Open empty recordset for new records to be added to since employees cannot be selected from listbox1
            strSQL = "SELECT ID,Active,LastName,FirstName,BirthDate,SocSecurity,Address,City,State,ZipCode,Phone,Emergency,Email,Notes,StartDate,StartSalary, " _
                 & "Salary,LastRaiseDate,LastRaiseAmt,Benefits,VacaYear1,VacaDays1,VacaUsed1,VacaYear2,VacaDays2,VacaUsed2,VacaYear3,VacaDays3,VacaUsed3, " _
                 & "WorkHours,FedTax,StateTax,Misc,PayTotal,FedTaxTotal,StateTaxTotal,SocSecTotal,MiscTotal FROM Employees;"
            dbDataSet.Clear()
            dbDataSet.Tables.Clear()
            gbl_DstConnect.Open()
            dbAdapter = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
            dbAdapter.Fill(dbDataSet, "Employees")
            gbl_DstConnect.Close()

            frm_Message.Text = "2:1:0:1:3:There are no records on file to view, [New] is the only operation allowed"
            frm_Message.ShowDialog()
        Else 'Fill listbox with data

            Dim varhold As Object
            Dim inc As Integer
            Dim strName As String

            For inc = 0 To dbDataSet_Misc.Tables("Employees").Rows.Count - 1

                ListArray(inc, 0) = inc 'Listbox index

                varhold = dbDataSet_Misc.Tables("Employees").Rows(inc).Item(0) 'ID
                If IsDBNull(varhold) Then varhold = ""
                ListArray(inc, 1) = Trim(varhold)

                varhold = dbDataSet_Misc.Tables("Employees").Rows(inc).Item(1) 'LastName
                If IsDBNull(varhold) Then varhold = "" Else varhold = Replace(varhold, "^", "'")
                strName = Trim(varhold)

                varhold = dbDataSet_Misc.Tables("Employees").Rows(inc).Item(2) 'FirstName
                If IsDBNull(varhold) Then varhold = "" Else varhold = Replace(varhold, "^", "'")
                strName = strName + " " + Trim(varhold)
                ListBox1.Items.Add(strName)
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

            opt_Active.Enabled = True
            opt_NonActive.Enabled = True
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

        strSQL = "SELECT ID,Active,LastName,FirstName,BirthDate,SocSecurity,Address,City,State,ZipCode,Phone,Emergency,Email,Salary,WorkHours,FedTax,StateTax,Misc, " _
                     & "PayTotal,FedTaxTotal,StateTaxTotal,SocSecTotal,MiscTotal,StartDate,StartSalary,LastRaiseDate,LastRaiseAmt,Benefits,Notes,VacaStartDate, " _
                     & "VacaYear1,VacaDays1,VacaUsed1,VacaYear2,VacaDays2,VacaUsed2,VacaYear3,VacaDays3,VacaUsed3,VacaNotes FROM Employees WHERE ID = " & intLookup & ";"
        dbDataSet.Clear()
        dbDataSet.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter.Fill(dbDataSet, "Selected")
        gbl_DstConnect.Close()

        'Form fill data
        booDataChecked = True 'Textbox data changes with pre_processed data
        Dim StartDateHide As Boolean = False 'False =  hide vacation start date

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(0)) Then 'ID
            lbl_ID.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(0))
        Else : lbl_ID.Text = "" : End If

        If dbDataSet.Tables("Selected").Rows(0).Item(1) = False Then cbx_Active.Checked = False Else cbx_Active.Checked = True 'Active

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(2)) Then : tbox_LastName.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(2)) 'LastName
        Else : tbox_LastName.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(3)) Then 'FirstName
            tbox_FirstName.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(3))
        Else : tbox_FirstName.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(4)) And dbDataSet.Tables("Selected").Rows(0).Item(4).ToString <> "#12/12/1212#" Then 'BirthDate
            tbox_BirthDate.Text = Format(dbDataSet.Tables("Selected").Rows(0).Item(4), "MM/dd/yyyy")
        Else : tbox_BirthDate.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(5)) Then 'SocSecurity
            tbox_SocSecurity.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(5))
        Else : tbox_SocSecurity.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(6)) Then 'Address
            tbox_Address.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(6))
        Else : tbox_Address.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(7)) Then 'City
            tbox_City.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(7))
        Else : tbox_City.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(8)) Then 'State
            tbox_State.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(8))
        Else : tbox_State.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(9)) Then 'Zipcode
            tbox_ZipCode.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(9))
        Else : tbox_ZipCode.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(10)) Then 'Phone
            tbox_Phone.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(10))
        Else : tbox_Phone.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(11)) Then 'Emergency Phone
            tbox_Emergency.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(11))
        Else : tbox_Emergency.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(12)) Then 'Email
            tbox_Email.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(12))
        Else : tbox_Email.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(13)) Then 'Salary
            tbox_Salary.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(13))
        Else : tbox_Salary.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(14)) Then 'Normal week work hours
            tbox_WeekHours.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(14))
        Else : tbox_WeekHours.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(15)) Then 'Normal week federal taxes
            tbox_WeekFedTax.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(15))
        Else : tbox_WeekFedTax.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(16)) Then 'Normal week state taxes
            tbox_WeekStateTax.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(16))
        Else : tbox_WeekStateTax.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(17)) Then 'Normal week misc deductions
            tbox_WeekMisc.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(17))
        Else : tbox_WeekMisc.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(18)) Then 'Pay total for year
            lbl_YearEarnings.Text = FormatCurrency(Trim(dbDataSet.Tables("Selected").Rows(0).Item(18)), 2)
        Else : lbl_YearEarnings.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(19)) Then 'Federal tax total for year
            lbl_YearFederalTax.Text = FormatCurrency(Trim(dbDataSet.Tables("Selected").Rows(0).Item(19)), 2)
        Else : lbl_YearFederalTax.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(20)) Then 'State tax total for year
            lbl_YearStateTax.Text = FormatCurrency(Trim(dbDataSet.Tables("Selected").Rows(0).Item(20)), 2)
        Else : lbl_YearStateTax.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(21)) Then 'Soc Security total for year
            lbl_YearSocSecurity.Text = FormatCurrency(Trim(dbDataSet.Tables("Selected").Rows(0).Item(21)), 2)
        Else : lbl_YearSocSecurity.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(22)) Then 'Misc deductions total for year
            lbl_YearMisc.Text = FormatCurrency(Trim(dbDataSet.Tables("Selected").Rows(0).Item(22)), 2)
        Else : lbl_YearMisc.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(23)) And dbDataSet.Tables("Selected").Rows(0).Item(23).ToString <> "#12/12/1212#" Then 'StartDate
            tbox_StartDate.Text = Format(dbDataSet.Tables("Selected").Rows(0).Item(23), "MM/dd/yyyy")
        Else : tbox_StartDate.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(24)) Then 'StartSalary
            tbox_StartSalary.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(24))
        Else : tbox_StartSalary.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(25)) And dbDataSet.Tables("Selected").Rows(0).Item(25).ToString <> "#12/12/1212#" Then 'Last raise date
            tbox_RaiseDate.Text = Format(dbDataSet.Tables("Selected").Rows(0).Item(25), "MM/dd/yyyy")
        Else : tbox_RaiseDate.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(26)) Then 'RaiseAmount
            tbox_RaiseAmount.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(26))
        Else : tbox_RaiseAmount.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(27)) Then 'Benefits
            tbox_Benefits.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(27))
        Else : tbox_Benefits.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(28)) Then 'Notes
            tbox_Notes.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(28))
        Else : tbox_Notes.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(29)) And dbDataSet.Tables("Selected").Rows(0).Item(29).ToString <> "#12/12/1212#" Then 'Vacation start date
            tbox_VacaStartDate.Text = Format(dbDataSet.Tables("Selected").Rows(0).Item(29), "MM/dd/yyyy")
        Else : tbox_VacaStartDate.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(30)) And dbDataSet.Tables("Selected").Rows(0).Item(30).ToString <> "#12/12/1212#" Then 'Vacation Year 1
            lbl_VacaYear1.Text = Year(dbDataSet.Tables("Selected").Rows(0).Item(30))
        Else : lbl_VacaYear1.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(31)) Then 'Vacation days issued Year 1
            lbl_VacaDaysIssued1.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(31))
        Else : lbl_VacaDaysIssued1.Text = "" : StartDateHide = True : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(32)) Then 'Vacation days used Year 1
            tbox_VacaDaysUsed1.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(32))
        Else : tbox_VacaDaysUsed1.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(33)) And dbDataSet.Tables("Selected").Rows(0).Item(33).ToString <> "#12/12/1212#" Then 'Vacation Year 2
            lbl_VacaYear2.Text = Year(dbDataSet.Tables("Selected").Rows(0).Item(33))
        Else : lbl_VacaYear2.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(34)) Then 'Vacation days issued Year 2
            lbl_VacaDaysIssued2.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(34))
        Else : lbl_VacaDaysIssued2.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(35)) Then 'Vacation days used Year 2
            tbox_VacaDaysUsed2.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(35))
        Else : tbox_VacaDaysUsed2.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(36)) And dbDataSet.Tables("Selected").Rows(0).Item(36).ToString <> "#12/12/1212#" Then 'Vacation Year 3
            lbl_VacaYear3.Text = Year(dbDataSet.Tables("Selected").Rows(0).Item(36))
        Else : lbl_VacaYear3.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(37)) Then 'Vacation days issued Year 3
            lbl_VacadaysIssued3.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(37))
        Else : lbl_VacadaysIssued3.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(38)) Then 'Vacation days used Year 3
            tbox_VacaDaysUsed3.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(38))
        Else : tbox_VacaDaysUsed3.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(39)) Then 'Vacation Notes
            tbox_VacationNotes.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(39))
        Else : tbox_VacationNotes.Text = "" : End If

        lbl_StartDate1.Visible = StartDateHide
        lbl_StartDate2.Visible = StartDateHide
        tbox_VacaStartDate.Visible = StartDateHide
        Call Calculate_SocSecurity()
        booDataChecked = False
    End Sub
    Private Sub Calculate_SocSecurity() 'Calculate social security payments
        If tbox_Salary.Text = "" Or tbox_WeekHours.Text = "" Or lbl_YearEarnings.Text = "" Then Exit Sub

        Dim YearEarnings As Double = lbl_YearEarnings.Text
        Dim SocSec_Taxed As Double = 0
        Dim TotalPayment As Double = 0
        Dim Salary As Double = Convert.ToDouble(tbox_Salary.Text)
        Dim Hours As Integer = Convert.ToInt32(tbox_WeekHours.Text)
        Dim SocSecurityLimit As Single = FormatCurrency(dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(1))
        Dim SocSecPercent As Single = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(2)
        Dim MedicarePercent As Single = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(3)

        'Calculate paycheck ( overtime )
        If Hours > 40 Then
            TotalPayment = (Salary * 40) + ((Salary * 1.5) * (Hours - 40))
        Else
            TotalPayment = Salary * Hours
        End If

        'Calculate social security
        If YearEarnings + TotalPayment <= SocSecurityLimit Then SocSec_Taxed = TotalPayment
        If YearEarnings <= SocSecurityLimit And YearEarnings + TotalPayment > SocSecurityLimit Then SocSec_Taxed = SocSecurityLimit - YearEarnings
        lbl_WeekSocSecurity.Text = FormatNumber((SocSec_Taxed * SocSecPercent) + (TotalPayment * MedicarePercent), 2)

    End Sub
    Private Sub ClearData() 'Clear form of all data
        cbx_Active.Checked = False
        lbl_ID.Text = ""
        tbox_LastName.Text = ""
        tbox_FirstName.Text = ""
        tbox_BirthDate.Text = ""
        tbox_SocSecurity.Text = ""
        tbox_Address.Text = ""
        tbox_City.Text = ""
        tbox_State.Text = ""
        tbox_ZipCode.Text = ""
        tbox_Phone.Text = ""
        tbox_Emergency.Text = ""
        tbox_Email.Text = ""
        tbox_Salary.Text = ""
        tbox_WeekHours.Text = ""
        tbox_WeekFedTax.Text = ""
        tbox_WeekStateTax.Text = ""
        lbl_WeekSocSecurity.Text = ""
        tbox_WeekMisc.Text = ""
        lbl_YearEarnings.Text = ""
        lbl_YearFederalTax.Text = ""
        lbl_YearStateTax.Text = ""
        lbl_YearSocSecurity.Text = ""
        lbl_YearMisc.Text = ""
        tbox_StartDate.Text = ""
        tbox_StartSalary.Text = ""
        tbox_RaiseDate.Text = ""
        tbox_RaiseAmount.Text = ""
        tbox_Benefits.Text = ""
        tbox_Notes.Text = ""
        tbox_VacaStartDate.Text = ""
        lbl_VacaYear1.Text = ""
        lbl_VacaYear2.Text = ""
        lbl_VacaYear3.Text = ""
        lbl_VacaDaysIssued1.Text = ""
        lbl_VacaDaysIssued2.Text = ""
        lbl_VacadaysIssued3.Text = ""
        tbox_VacaDaysUsed1.Text = ""
        tbox_VacaDaysUsed2.Text = ""
        tbox_VacaDaysUsed3.Text = ""
        tbox_VacationNotes.Text = ""
    End Sub
    Private Sub EnableEdits(blnStatus As Boolean)
        tbox_FirstName.Enabled = blnStatus
        tbox_LastName.Enabled = blnStatus
        tbox_BirthDate.Enabled = blnStatus
        tbox_SocSecurity.Enabled = blnStatus
        cbx_Active.Enabled = blnStatus
        tbox_Address.Enabled = blnStatus
        tbox_City.Enabled = blnStatus
        tbox_State.Enabled = blnStatus
        tbox_ZipCode.Enabled = blnStatus
        tbox_Phone.Enabled = blnStatus
        tbox_Emergency.Enabled = blnStatus
        tbox_Email.Enabled = blnStatus
        tbox_Salary.Enabled = blnStatus
        tbox_WeekHours.Enabled = blnStatus
        tbox_WeekFedTax.Enabled = blnStatus
        tbox_WeekStateTax.Enabled = blnStatus
        tbox_WeekMisc.Enabled = blnStatus
        tbox_StartDate.Enabled = blnStatus
        tbox_StartSalary.Enabled = blnStatus
        tbox_RaiseDate.Enabled = blnStatus
        tbox_RaiseAmount.Enabled = blnStatus
        tbox_Benefits.Enabled = blnStatus
        tbox_Notes.Enabled = blnStatus
        tbox_VacaStartDate.Enabled = blnStatus
        tbox_VacaDaysUsed1.Enabled = blnStatus
        tbox_VacaDaysUsed2.Enabled = blnStatus
        tbox_VacaDaysUsed3.Enabled = blnStatus
        tbox_VacationNotes.Enabled = blnStatus
    End Sub


    'All command actions ( Edit,New/Restore,DeleteCancel,Exit/Save )
    Private Sub cmd_Edit_Click() Handles cmd_Edit.Click

        If tbox_FirstName.Text = "" Then Exit Sub
        EditNew = 1 'Set variable to edit on save
        ListBox1.Enabled = False
        opt_Active.Enabled = False
        opt_NonActive.Enabled = False
        Call EnableEdits(True)

        cmd_Edit.Enabled = False
        cmd_NewRestore.Enabled = False
        cmd_NewRestore.Text = "Restore"
        cmd_NewRestore.Image = My.Resources.Resources.Restore
        cmd_DeleteCancel.Text = "Cancel"
        cmd_DeleteCancel.Image = My.Resources.Resources.Cancel
        tbox_LastName.Focus()
    End Sub
    Private Sub cmd_NewRestore_Click(sender As Object, e As EventArgs) Handles cmd_NewRestore.Click
        Call ClearData()
        If cmd_NewRestore.Text = "New" Then
            EditNew = 2 'Set variable to new for save
            ListBox1.Enabled = False
            ListBox1.SelectedIndex = -1
            opt_Active.Enabled = False
            opt_NonActive.Enabled = False

            Call EnableEdits(True)
            If AutoNum <> 0 Then lbl_ID.Text = AutoNum + 1 'Show new ID only if autonum established from previous entry

            tbox_StartDate.Text = Format(Now.Date, "MM/dd/yyyy")
            tbox_VacaStartDate.Text = Format(Now.Date.AddMonths(dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(5)), "MM/dd/yyyy")

            booNameCheck = False
            tbox_LastName.Focus()

            cmd_Edit.Enabled = False  'Disable edit button
            cmd_NewRestore.Enabled = False  'Disable new/restore button
            cmd_DeleteCancel.Text = "Cancel"
            cmd_DeleteCancel.Image = My.Resources.Resources.Cancel
            cmd_DeleteCancel.Enabled = True
            cmd_DeleteCancel.Enabled = True
            cmd_ExitSave.Text = "Save"
            cmd_ExitSave.Image = My.Resources.Resources.Save
            cmd_ExitSave.Enabled = False  'Hide exit/save button
        Else
            Call DataFill() 'Replace original values from recordset
        End If
    End Sub
    Private Sub cmd_DeleteCancel_Click(sender As Object, e As EventArgs) Handles cmd_DeleteCancel.Click
        If cmd_DeleteCancel.Text = "Delete" Then

            frm_Message.Text = "2:2:0:1:3:Are you sure you want to delete all records of this employee"
            frm_Message.ShowDialog()
            If MessageResult = True Then

                'Delete selection
                strSQL = "SELECT ID FROM Employees WHERE ID = " & lbl_ID.Text & ";"
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
                If intTotalRecords = 0 Then Call EnableMenus(0, False) 'Disable all employee related menus

                Call Actives() 'Test if last active employee deleted
                If opt_Active.Checked = True And booActives = True Then ListData(True) Else ListData(False)
            End If
        ElseIf cmd_DeleteCancel.Text = "Cancel" Then
            Call EnableEdits(False)
            Call ClearData() 'Clear all entries
            Call FileOperationReset()
            If intTotalRecords <> 0 Then 'Allow listbox operations only if records found
                ListBox1.Visible = True
                ListBox1.Enabled = True
                opt_Active.Enabled = True
                opt_NonActive.Enabled = True
                If EditNew = 2 Then
                    EditNew = 0
                    If opt_Active.Checked = True And booActives = True Then ListData(True) Else ListData(False)
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
        If Trim(tbox_FirstName.Text) = "" Then
            tbox_FirstName.BackColor = Color.Aqua
            frm_Message.Text = "2:1:0:1:3:Employee's First Name must be Entered"
            frm_Message.ShowDialog()
            tbox_FirstName.BackColor = Color.White
            tbox_FirstName.Focus()
            Exit Sub
        End If
        If Trim(tbox_LastName.Text) = "" Then
            tbox_LastName.BackColor = Color.Aqua
            frm_Message.Text = "2:1:0:1:3:Employee's Last Name must be Entered"
            frm_Message.ShowDialog()
            tbox_LastName.BackColor = Color.White
            tbox_LastName.Focus()
            Exit Sub
        End If

        If tbox_Phone.Text <> "" Then
            If Len(tbox_Phone.Text) <> 10 Then
                tbox_Phone.BackColor = Color.Aqua
                frm_Message.Text = "2:1:0:1:3:The employee's phone number must be empty or complete to continue"
                frm_Message.ShowDialog()
                tbox_Phone.BackColor = Color.White
                tbox_Phone.Focus()
                Exit Sub
            End If
        End If

        If tbox_Emergency.Text <> "" Then
            If Len(tbox_Emergency.Text) <> 10 Then
                tbox_Emergency.BackColor = Color.Aqua
                frm_Message.Text = "2:1:0:1:3:The employee's emergency phone number must be empty or complete to continue"
                frm_Message.ShowDialog()
                tbox_Emergency.BackColor = Color.White
                tbox_Emergency.Focus()
                Exit Sub
            End If
        End If

        'Make form checkbox and option buttons ready for save 
        Dim strSocSecurity As String
        Dim booSelectionActive As Boolean
        If cbx_Active.Checked = True Then booSelectionActive = True Else booSelectionActive = False
        If tbox_SocSecurity.Text = "   -  -" Then strSocSecurity = "" Else strSocSecurity = tbox_SocSecurity.Text
        If tbox_StartDate.Text = "  /  /" Then tbox_StartDate.Text = Format(Now.Date, "MM/dd/yyyy")
        If tbox_VacaStartDate.Text = "  /  /" Then tbox_VacaStartDate.Text = Format(Now.Date.AddMonths(dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(5)), "MM/dd/yyyy")

        'Save form to database
        Dim cb0 As New OleDb.OleDbCommandBuilder(dbAdapter)
        If EditNew = 1 Then 'Save on edits changes
            dbDataSet.Tables("Selected").Rows(0).Item(1) = booSelectionActive
            dbDataSet.Tables("Selected").Rows(0).Item(2) = Trim(tbox_LastName.Text)
            dbDataSet.Tables("Selected").Rows(0).Item(3) = Trim(tbox_FirstName.Text)
            If tbox_BirthDate.Text <> "  /  /" Then : dbDataSet.Tables("Selected").Rows(0).Item(4) = tbox_BirthDate.Text
            Else : dbDataSet.Tables("Selected").Rows(0).Item(4) = DBNull.Value : End If
            dbDataSet.Tables("Selected").Rows(0).Item(5) = Trim(strSocSecurity)
            dbDataSet.Tables("Selected").Rows(0).Item(6) = Trim(tbox_Address.Text)
            dbDataSet.Tables("Selected").Rows(0).Item(7) = Trim(tbox_City.Text)
            dbDataSet.Tables("Selected").Rows(0).Item(8) = Trim(tbox_State.Text)
            dbDataSet.Tables("Selected").Rows(0).Item(9) = Trim(tbox_ZipCode.Text)
            If tbox_Phone.Text <> "" Then : dbDataSet.Tables("Selected").Rows(0).Item(10) = String.Format("{0:(###)###-####}", Long.Parse(Trim(tbox_Phone.Text)))
            Else : dbDataSet.Tables("Selected").Rows(0).Item(10) = DBNull.Value : End If
            If tbox_Emergency.Text <> "" Then : dbDataSet.Tables("Selected").Rows(0).Item(11) = String.Format("{0:(###)###-####}", Long.Parse(Trim(tbox_Emergency.Text)))
            Else : dbDataSet.Tables("Selected").Rows(0).Item(11) = DBNull.Value : End If
            dbDataSet.Tables("Selected").Rows(0).Item(12) = Trim(tbox_Email.Text)
            If Trim(tbox_Salary.Text) <> "" And Trim(tbox_Salary.Text) <> "0" Then : dbDataSet.Tables("Selected").Rows(0).Item(13) = Trim(tbox_Salary.Text)
            Else : dbDataSet.Tables("Selected").Rows(0).Item(13) = DBNull.Value : End If
            If Trim(tbox_WeekHours.Text) <> "" And Trim(tbox_WeekHours.Text) <> "0" Then : dbDataSet.Tables("Selected").Rows(0).Item(14) = Trim(tbox_WeekHours.Text)
            Else : dbDataSet.Tables("Selected").Rows(0).Item(14) = DBNull.Value : End If
            If Trim(tbox_WeekFedTax.Text) <> "" And Trim(tbox_WeekFedTax.Text) <> "0" Then : dbDataSet.Tables("Selected").Rows(0).Item(15) = Trim(tbox_WeekFedTax.Text)
            Else : dbDataSet.Tables("Selected").Rows(0).Item(15) = DBNull.Value : End If
            If Trim(tbox_WeekStateTax.Text) <> "" And Trim(tbox_WeekStateTax.Text) <> "0" Then : dbDataSet.Tables("Selected").Rows(0).Item(16) = Trim(tbox_WeekStateTax.Text)
            Else : dbDataSet.Tables("Selected").Rows(0).Item(16) = DBNull.Value : End If
            If Trim(tbox_WeekMisc.Text) <> "" And Trim(tbox_WeekMisc.Text) <> "0" Then : dbDataSet.Tables("Selected").Rows(0).Item(17) = Trim(tbox_WeekMisc.Text)
            Else : dbDataSet.Tables("Selected").Rows(0).Item(17) = DBNull.Value : End If
            If tbox_StartDate.Text <> "  /  /" Then : dbDataSet.Tables("Selected").Rows(0).Item(23) = tbox_StartDate.Text
            Else : dbDataSet.Tables("Selected").Rows(0).Item(23) = DBNull.Value : End If
            If Trim(tbox_StartSalary.Text) <> "" And Trim(tbox_StartSalary.Text) <> "0" Then : dbDataSet.Tables("Selected").Rows(0).Item(24) = Trim(tbox_StartSalary.Text)
            Else : dbDataSet.Tables("Selected").Rows(0).Item(24) = DBNull.Value : End If
            If tbox_RaiseDate.Text <> "  /  /" Then : dbDataSet.Tables("Selected").Rows(0).Item(25) = tbox_RaiseDate.Text
            Else : dbDataSet.Tables("Selected").Rows(0).Item(25) = DBNull.Value : End If
            If Trim(tbox_RaiseAmount.Text) <> "" And Trim(tbox_RaiseAmount.Text) <> "0" Then : dbDataSet.Tables("Selected").Rows(0).Item(26) = Trim(tbox_RaiseAmount.Text)
            Else : dbDataSet.Tables("Selected").Rows(0).Item(26) = DBNull.Value : End If
            dbDataSet.Tables("Selected").Rows(0).Item(27) = Trim(tbox_Benefits.Text)
            dbDataSet.Tables("Selected").Rows(0).Item(28) = Trim(tbox_Notes.Text)
            If tbox_VacaStartDate.Text <> "  /  /" Then : dbDataSet.Tables("Selected").Rows(0).Item(29) = tbox_VacaStartDate.Text
            Else : dbDataSet.Tables("Selected").Rows(0).Item(29) = DBNull.Value : End If
            If Trim(tbox_VacaDaysUsed1.Text) <> "" And Trim(tbox_VacaDaysUsed1.Text) <> "0" Then : dbDataSet.Tables("Selected").Rows(0).Item(32) = Trim(tbox_VacaDaysUsed1.Text)
            Else : dbDataSet.Tables("Selected").Rows(0).Item(32) = DBNull.Value : End If
            If Trim(tbox_VacaDaysUsed2.Text) <> "" And Trim(tbox_VacaDaysUsed2.Text) <> "0" Then : dbDataSet.Tables("Selected").Rows(0).Item(35) = Trim(tbox_VacaDaysUsed2.Text)
            Else : dbDataSet.Tables("Selected").Rows(0).Item(35) = DBNull.Value : End If
            If Trim(tbox_VacaDaysUsed3.Text) <> "" And Trim(tbox_VacaDaysUsed3.Text) <> "0" Then : dbDataSet.Tables("Selected").Rows(0).Item(38) = Trim(tbox_VacaDaysUsed3.Text)
            Else : dbDataSet.Tables("Selected").Rows(0).Item(38) = DBNull.Value : End If
            dbDataSet.Tables("Selected").Rows(0).Item(39) = Trim(tbox_VacationNotes.Text)
            dbAdapter.Update(dbDataSet, "Selected")
            intLookup = lbl_ID.Text

        ElseIf EditNew = 2 Then 'Save new additions to database table
            Dim dsNewRow As DataRow
            dsNewRow = dbDataSet.Tables("Selected").NewRow()
            dsNewRow.Item("Active") = booSelectionActive
            dsNewRow.Item("LastName") = Trim(tbox_LastName.Text)
            dsNewRow.Item("FirstName") = Trim(tbox_FirstName.Text)
            If tbox_BirthDate.Text = "  /  /" Then dsNewRow.Item("BirthDate") = DBNull.Value Else dsNewRow.Item("BirthDate") = tbox_BirthDate.Text
            dsNewRow.Item("SocSecurity") = Trim(strSocSecurity)
            dsNewRow.Item("Address") = Trim(tbox_Address.Text)
            dsNewRow.Item("City") = Trim(tbox_City.Text)
            dsNewRow.Item("State") = Trim(tbox_State.Text)
            dsNewRow.Item("ZipCode") = Trim(tbox_ZipCode.Text)
            If tbox_Phone.Text <> "" Then dsNewRow.Item("Phone") = String.Format("{0:(###)###-####}", Long.Parse(Trim(tbox_Phone.Text)))
            If tbox_Emergency.Text <> "" Then dsNewRow.Item("Emergency") = String.Format("{0:(###)###-####}", Long.Parse(Trim(tbox_Emergency.Text)))
            dsNewRow.Item("Email") = Trim(tbox_Email.Text)
            If Trim(tbox_Salary.Text) = "" Or Trim(tbox_Salary.Text) = "0" Then dsNewRow.Item("Salary") = DBNull.Value Else dsNewRow.Item("Salary") = Trim(tbox_Salary.Text)
            If Trim(tbox_WeekHours.Text) = "" Or Trim(tbox_WeekHours.Text) = "0" Then dsNewRow.Item("WorkHours") = DBNull.Value Else dsNewRow.Item("WorkHours") = Trim(tbox_WeekHours.Text)
            If Trim(tbox_WeekFedTax.Text) = "" Or Trim(tbox_WeekFedTax.Text) = "0" Then dsNewRow.Item("FedTax") = DBNull.Value Else dsNewRow.Item("FedTax") = Trim(tbox_WeekFedTax.Text)
            If Trim(tbox_WeekStateTax.Text) = "" Or Trim(tbox_WeekStateTax.Text) = "0" Then dsNewRow.Item("StateTax") = DBNull.Value Else dsNewRow.Item("StateTax") = Trim(tbox_WeekStateTax.Text)
            If Trim(tbox_WeekMisc.Text) = "" Or Trim(tbox_WeekMisc.Text) = "0" Then dsNewRow.Item("Misc") = DBNull.Value Else dsNewRow.Item("Misc") = Trim(tbox_WeekMisc.Text)
            If tbox_StartDate.Text = "  /  /" Then dsNewRow.Item("StartDate") = DBNull.Value Else dsNewRow.Item("StartDate") = tbox_StartDate.Text
            If Trim(tbox_StartSalary.Text) = "" Or Trim(tbox_StartSalary.Text) = "0" Then dsNewRow.Item("StartSalary") = DBNull.Value Else dsNewRow.Item("StartSalary") = Trim(tbox_StartSalary.Text)
            If tbox_RaiseDate.Text = "  /  /" Then dsNewRow.Item("LastRaiseDate") = DBNull.Value Else dsNewRow.Item("LastRaiseDate") = tbox_RaiseDate.Text
            If Trim(tbox_RaiseAmount.Text) = "" Or Trim(tbox_RaiseAmount.Text) = "0" Then dsNewRow.Item("LastRaiseAmt") = DBNull.Value Else dsNewRow.Item("LastRaiseAmt") = Trim(tbox_RaiseAmount.Text)
            dsNewRow.Item("Benefits") = Trim(tbox_Benefits.Text)
            dsNewRow.Item("Notes") = Trim(tbox_Notes.Text)
            If tbox_VacaStartDate.Text = "  /  /" Then dsNewRow.Item("VacaStartDate") = DBNull.Value Else dsNewRow.Item("VacaStartDate") = tbox_VacaStartDate.Text
            If Trim(tbox_VacaDaysUsed1.Text) = "" Or Trim(tbox_VacaDaysUsed1.Text) = "0" Then dsNewRow.Item("VacaUsed1") = DBNull.Value Else dsNewRow.Item("VacaUsed1") = Trim(tbox_VacaDaysUsed1.Text)
            If Trim(tbox_VacaDaysUsed2.Text) = "" Or Trim(tbox_VacaDaysUsed2.Text) = "0" Then dsNewRow.Item("VacaUsed2") = DBNull.Value Else dsNewRow.Item("VacaUsed2") = Trim(tbox_VacaDaysUsed2.Text)
            If Trim(tbox_VacaDaysUsed3.Text) = "" Or Trim(tbox_VacaDaysUsed3.Text) = "0" Then dsNewRow.Item("VacaUsed3") = DBNull.Value Else dsNewRow.Item("VacaUsed3") = Trim(tbox_VacaDaysUsed3.Text)
            dsNewRow.Item("VacaNotes") = Trim(tbox_VacationNotes.Text)
            dbDataSet.Tables("Selected").Rows.Add(dsNewRow)
            dbAdapter.Update(dbDataSet, "Selected")
            intTotalRecords = intTotalRecords + 1
            If intTotalRecords = 1 Then Call EnableMenus(0, True) 'Enable all employee related menus

            'If first saved new record, update autonum with ID of saved record
            If AutoNum = 0 Then
                strSQL = "SELECT ID FROM Employees ORDER by ID DESC;"
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

        If booSelectionActive = True Then booActives = True : opt_Active.Enabled = True
        opt_NonActive.Enabled = True
        ListBox1.Visible = True

        'Fill listbox with entries pertaining to active/all selection
        If opt_Active.Checked = True Then ListData(True) Else ListData(False)
        EditNew = 0 'Edit/new record reset
        ListBox1.Visible = True
        ListBox1.Enabled = True
        ListBox1.Focus()
        Call EnableEdits(False)
        Call FileOperationReset()

        'Select saved customer if in selected active/all selection
        If opt_Active.Checked = True And booSelectionActive = False Then ListBox1.SelectedIndex = 0 : intLookup = ListArray(0, 1)
        Call DataFill()
        Exit Sub
goActionErr:
        MsgBox(Err.Description)
        Exit Sub
    End Sub
    Private Sub cmd_DeleteVacaDays_Click(sender As Object, e As EventArgs) Handles cmd_DeleteVacaDays.Click
        If Trim(tbox_VacaDaysDelete.Text) = "" Then Exit Sub

        frm_Message.Text = "2:2:0:1:3:Are you sure you want to delete vacation time from this employee"
        frm_Message.ShowDialog()

        If MessageResult = True Then 'Answer = yes

            Dim BooVaca As Boolean = True
            Dim YearDays1, YearDays2, YearDays3, BalanceDays, DeletedDays As Integer
            YearDays1 = Convert.ToInt32(lbl_VacaDaysIssued1.Text) - Convert.ToInt32(tbox_VacaDaysUsed1.Text)
            YearDays2 = Convert.ToInt32(lbl_VacaDaysIssued2.Text) - Convert.ToInt32(tbox_VacaDaysUsed2.Text)
            YearDays3 = Convert.ToInt32(lbl_VacadaysIssued3.Text) - Convert.ToInt32(tbox_VacaDaysUsed3.Text)
            BalanceDays = Convert.ToInt32(tbox_VacaDaysDelete.Text)

            Select Case dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(4)
                Case 1 : If tbox_VacaDaysDelete.Text > YearDays1 Then BooVaca = False
                Case 2 : If tbox_VacaDaysDelete.Text > YearDays1 + YearDays2 Then BooVaca = False
                Case 3 : If tbox_VacaDaysDelete.Text > YearDays1 + YearDays2 + YearDays3 Then BooVaca = False
            End Select

            'Test for insufficent days accumulated for this amount of vacation time
            If BooVaca = False Then frm_Message.Text = "2:9:0:1:3:There are insufficent days accumulated for this amount of vacation time" : frm_Message.ShowDialog()
            If MessageResult = True Then 'Continue

                Dim cb0 As New OleDb.OleDbCommandBuilder(dbAdapter)

                'Take days away from year 3 if available 
                If dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(4) = 3 And YearDays3 > 0 Then
                    If BalanceDays > YearDays3 Then DeletedDays = YearDays3 Else DeletedDays = BalanceDays
                    BalanceDays = BalanceDays - DeletedDays
                    tbox_VacaDaysUsed3.Text = tbox_VacaDaysUsed3.Text + DeletedDays
                    dbDataSet.Tables("Selected").Rows(0).Item(38) = tbox_VacaDaysUsed3.Text
                End If

                'Take days away from year 2 if available
                If dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(4) >= 2 And YearDays2 > 0 And BalanceDays > 0 Then
                    If BalanceDays > YearDays2 Then DeletedDays = YearDays2 Else DeletedDays = BalanceDays
                    BalanceDays = BalanceDays - DeletedDays
                    tbox_VacaDaysUsed2.Text = tbox_VacaDaysUsed2.Text + DeletedDays
                    dbDataSet.Tables("Selected").Rows(0).Item(35) = tbox_VacaDaysUsed2.Text
                End If

                'Take days away from year 1 if available
                If dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(4) >= 1 And YearDays1 > 0 And BalanceDays > 0 Then
                    tbox_VacaDaysUsed1.Text = tbox_VacaDaysUsed1.Text + BalanceDays
                    dbDataSet.Tables("Selected").Rows(0).Item(32) = tbox_VacaDaysUsed1.Text
                End If

                dbAdapter.Update(dbDataSet, "Selected")
            End If
        End If
        tbox_VacaDaysDelete.Text = ""

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
    Private Sub tbox_GotFocus(sender As Object, e As EventArgs) Handles tbox_FirstName.GotFocus, tbox_LastName.GotFocus, tbox_BirthDate.GotFocus, tbox_SocSecurity.GotFocus, tbox_Address.GotFocus, tbox_City.GotFocus, tbox_State.GotFocus, tbox_ZipCode.GotFocus, tbox_Phone.GotFocus, tbox_Emergency.GotFocus, tbox_Email.GotFocus, tbox_Salary.GotFocus, tbox_WeekHours.GotFocus, tbox_WeekFedTax.GotFocus, tbox_WeekStateTax.GotFocus, tbox_WeekMisc.GotFocus, tbox_StartDate.GotFocus, tbox_StartSalary.GotFocus, tbox_RaiseDate.GotFocus, tbox_RaiseAmount.GotFocus, tbox_Benefits.GotFocus, tbox_Notes.GotFocus, tbox_VacaDaysUsed1.GotFocus, tbox_VacaDaysUsed2.GotFocus, tbox_VacaDaysUsed3.GotFocus, tbox_VacationNotes.GotFocus, tbox_VacaDaysDelete.GotFocus, tbox_VacaStartDate.GotFocus
        Select Case sender.Name
            Case "tbox_Benefits"
                If Trim(sender.Text) <> "" Then strBenefits = Trim(tbox_Benefits.Text)
                tbox_Benefits.SelectionStart = Len(Trim(tbox_Benefits.Text))
            Case "tbox_Notes"
                If Trim(tbox_Notes.Text) <> "" Then strNotes = Trim(tbox_Notes.Text)
                tbox_Notes.SelectionStart = Len(Trim(tbox_Notes.Text))
            Case "tbox_VacationNotes"
                If Trim(tbox_VacationNotes.Text) <> "" Then strVacaNotes = Trim(tbox_VacationNotes.Text)
                tbox_VacationNotes.SelectionStart = Len(Trim(tbox_VacationNotes.Text))
        End Select
        strInitEntry = Trim(sender.Text)
        sender.BackColor = (Color.FromArgb(255, 255, 192))
    End Sub
    Private Sub tbox_LostFocus(sender As Object, e As EventArgs) Handles tbox_FirstName.LostFocus, tbox_LastName.LostFocus, tbox_BirthDate.LostFocus, tbox_SocSecurity.LostFocus, tbox_Address.LostFocus, tbox_City.LostFocus, tbox_State.LostFocus, tbox_ZipCode.LostFocus, tbox_Phone.LostFocus, tbox_Emergency.LostFocus, tbox_Email.LostFocus, tbox_Salary.LostFocus, tbox_WeekHours.LostFocus, tbox_WeekFedTax.LostFocus, tbox_WeekStateTax.LostFocus, tbox_WeekMisc.LostFocus, tbox_StartDate.LostFocus, tbox_StartSalary.LostFocus, tbox_RaiseDate.LostFocus, tbox_RaiseAmount.LostFocus, tbox_Benefits.LostFocus, tbox_Notes.LostFocus, tbox_VacaDaysUsed1.LostFocus, tbox_VacaDaysUsed2.LostFocus, tbox_VacaDaysUsed3.LostFocus, tbox_VacationNotes.LostFocus, tbox_VacaDaysDelete.LostFocus, tbox_VacaStartDate.LostFocus
        If booCorrection = True Then sender.BackColor = Color.White : Exit Sub

        Select Case sender.Name
            Case "tbox_FirstName", "tbox_LastName"
                If EditNew = 2 And booNameCheck = False And tbox_FirstName.Text <> "" And tbox_LastName.Text <> "" Then Call NameCheck() 'Check for repeat of same name
            Case "tbox_BirthDate", "tbox_StartDate", "tbox_RaiseDate", "tbox_VacaStartDate"
                If IsDate(sender.Text) = False And sender.Text <> "  /  /" Then
                    sender.BackColor = Color.Aqua
                    booCorrection = True
                    frm_Message.Text = "2:1:0:1:3:The date entered is not valid, Please enter a valid date"
                    frm_Message.ShowDialog()
                    sender.text = ""
                    sender.Focus()
                    booCorrection = False
                    Exit Sub
                End If
            Case "tbox_Salary", "tbox_WeekHours", "tbox_WeekFedTax", "tbox_WeekStateTax", "tbox_WeekSocSecurity", "tbox_WeekMisc", "tbox_StartSalary", "tbox_RaiseAmount", "tbox_VacaDaysUsed1", "tbox_VacaDaysUsed2", "tbox_VacaDaysUsed3", "tbox_VacaDaysDelete"
                If sender.Text <> "" Then
                    If Not IsNumeric(sender.Text) Then
                        booCorrection = True
                        frm_Message.Text = "2:1:0:1:3:Invalid Entry --- Numerical entries are only allowed"
                        frm_Message.ShowDialog()
                        sender.text = ""
                        sender.Focus()
                        booCorrection = False
                        Exit Sub
                    End If
                End If
                If sender.text <> strInitEntry And tbox_Salary.Text <> "" And tbox_WeekHours.Text <> "" Then Call Calculate_SocSecurity()

            Case "tbox_State"
                If AlphaNumeric(sender.text) = False Then
                    booCorrection = True
                    frm_Message.Text = "2:1:0:1:3:Invalid Entry --- Only letters allow for state abbreviations"
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
    Private Sub tbox_TextChanged(sender As Object, e As EventArgs) Handles tbox_FirstName.TextChanged, tbox_LastName.TextChanged, tbox_BirthDate.TextChanged, tbox_SocSecurity.TextChanged, tbox_Address.TextChanged, tbox_City.TextChanged, tbox_State.TextChanged, tbox_ZipCode.TextChanged, tbox_Phone.TextChanged, tbox_Emergency.TextChanged, tbox_Email.TextChanged, tbox_Salary.TextChanged, tbox_WeekHours.TextChanged, tbox_WeekFedTax.TextChanged, tbox_WeekStateTax.TextChanged, tbox_WeekMisc.TextChanged, tbox_StartDate.TextChanged, tbox_StartSalary.TextChanged, tbox_RaiseDate.TextChanged, tbox_RaiseAmount.TextChanged, tbox_Benefits.TextChanged, tbox_Notes.TextChanged, tbox_VacaDaysUsed1.TextChanged, tbox_VacaDaysUsed2.TextChanged, tbox_VacaDaysUsed3.TextChanged, tbox_VacationNotes.TextChanged, tbox_VacaDaysDelete.TextChanged, tbox_VacaStartDate.TextChanged
        If sender.name = "tbox_VacaDaysDelete" Then cmd_DeleteVacaDays.Enabled = True
        If booDataChecked = True Or EditNew = 0 Then Exit Sub 'Skip if pre_processed data
        Select Case sender.Name
            Case "tbox_FirstName", "tbox_LastName", "tbox_City", "tbox_State"
                If Trim(sender.Text) <> "" Then 'Capitalize first letter of entry
                    booDataChecked = True
                    If Len(Trim(sender.Text)) = 1 Then
                        sender.Text = StrConv(Trim(sender.Text), vbUpperCase)
                        sender.SelectionStart = 2
                    End If
                    booDataChecked = False
                End If
            Case "tbox_Benefits"
                If Len(sender.text) = Len(strBenefits) + 2 Then Exit Sub
            Case "tbox_Notes"
                If Len(sender.text) = Len(strNotes) + 2 Then Exit Sub
            Case "tbox_VacationNotes"
                If Len(sender.text) = Len(strVacaNotes) + 2 Then Exit Sub
        End Select
        Call EditSave()
    End Sub
    Private Sub tbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbox_FirstName.KeyPress, tbox_LastName.KeyPress, tbox_BirthDate.KeyPress, tbox_SocSecurity.KeyPress, tbox_Address.KeyPress, tbox_City.KeyPress, tbox_State.KeyPress, tbox_ZipCode.KeyPress, tbox_Phone.KeyPress, tbox_Emergency.KeyPress, tbox_Email.KeyPress, tbox_Salary.KeyPress, tbox_WeekHours.KeyPress, tbox_WeekFedTax.KeyPress, tbox_WeekStateTax.KeyPress, tbox_WeekMisc.KeyPress, tbox_StartDate.KeyPress, tbox_StartSalary.KeyPress, tbox_RaiseDate.KeyPress, tbox_RaiseAmount.KeyPress, tbox_Benefits.KeyPress, tbox_Notes.KeyPress, tbox_VacaDaysUsed1.KeyPress, tbox_VacaDaysUsed2.KeyPress, tbox_VacaDaysUsed3.KeyPress, tbox_VacationNotes.KeyPress, tbox_VacaDaysDelete.KeyPress, tbox_VacaStartDate.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            Select Case sender.Name
                Case "tbox_LastName" : tbox_FirstName.Focus()
                Case "tbox_FirstName" : tbox_BirthDate.Focus()
                Case "tbox_BirthDate" : tbox_SocSecurity.Focus()
                Case "tbox_SocSecurity" : tbox_Address.Focus()
                Case "tbox_Address" : tbox_City.Focus()
                Case "tbox_City" : tbox_State.Focus()
                Case "tbox_State" : tbox_ZipCode.Focus()
                Case "tbox_ZipCode" : tbox_Phone.Focus()
                Case "tbox_Phone" : tbox_Emergency.Focus()
                Case "tbox_Emergency" : tbox_Email.Focus()
                Case "tbox_Email" : tbox_LastName.Focus()
                Case "tbox_Salary" : tbox_WeekHours.Focus()
                Case "tbox_WeekHours" : tbox_WeekFedTax.Focus()
                Case "tbox_WeekFedTax" : tbox_WeekStateTax.Focus()
                Case "tbox_WeekStateTax" : tbox_WeekMisc.Focus()
                Case "tbox_WeekMisc" : tbox_Salary.Focus()
                Case "tbox_StartDate" : tbox_StartSalary.Focus()
                Case "tbox_StartSalary" : tbox_RaiseDate.Focus()
                Case "tbox_RaiseDate" : tbox_RaiseAmount.Focus()
                Case "tbox_RaiseAmount" : tbox_StartDate.Focus()
                Case "tbox_Benefits" : tbox_Notes.Focus()
                Case "tbox_Notes" : tbox_LastName.Focus()
                Case "tbox_VacaStartDate" : tbox_VacaDaysUsed1.Focus()
                Case "tbox_VacaDaysUsed1" : tbox_VacaDaysUsed2.Focus()
                Case "tbox_VacaDaysUsed2" : tbox_VacaDaysUsed3.Focus()
                Case "tbox_VacaDaysUsed3" : tbox_VacationNotes.Focus()
                Case "tbox_VacationNotes" : tbox_VacaStartDate.Focus()
                Case "tbox_VacaDaysDelete" : ListBox1.Focus()
            End Select
        End If
    End Sub
    Private Sub cbx_Active_CheckedChanged(sender As Object, e As EventArgs) Handles cbx_Active.CheckedChanged
        If EditNew <> 0 Then Call EditSave()
    End Sub
    Private Sub tbox_Date_MouseClick(sender As Object, e As MouseEventArgs) Handles tbox_BirthDate.MouseClick, tbox_StartDate.MouseClick, tbox_RaiseDate.MouseClick, tbox_SocSecurity.MouseClick, tbox_Phone.MouseClick, tbox_Emergency.MouseClick, tbox_ZipCode.MouseClick, tbox_VacaStartDate.MouseClick
        If sender.text = "  /  /" Or sender.Text = "   -  -" Or sender.text = "" Then sender.SelectionStart = 0
    End Sub


    'Handler sub routines
    Private Sub NameCheck()
        strSQL = "SELECT FirstName,LastName FROM Employees WHERE UCase(FirstName) = '" & UCase(Trim(tbox_FirstName.Text)) & "'" & "" _
        & " AND UCase(LastName) = '" & UCase(Trim(tbox_LastName.Text)) & "';"
        dbDataSet_Misc.Clear()
        dbDataSet_Misc.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter_Misc.Fill(dbDataSet_Misc, "NameCheck")
        gbl_DstConnect.Close()
        If dbDataSet_Misc.Tables("NameCheck").Rows.Count > 0 Then
            If dbDataSet_Misc.Tables("NameCheck").Rows.Count = 1 Then
                frm_Message.Text = "2:1:0:1:9:There is 1 other employee on file with the same first and last name"
            Else
                frm_Message.Text = "2:1:0:1:9:There are " & dbDataSet_Misc.Tables("NameCheck").Rows.Count & " other employees on file with the same first and last name"
            End If
            booNameCheck = True
            frm_Message.ShowDialog()
        End If
    End Sub
    Private Sub EditSave()
        If EditNew = 1 Then cmd_NewRestore.Enabled = True
        cmd_ExitSave.Text = "Save"
        cmd_ExitSave.Image = My.Resources.Resources.Save
        cmd_ExitSave.Enabled = True
    End Sub


    'All mouse movement and mouse over messages
    Private Sub ListBox1_MouseEnter(sender As Object, e As EventArgs) Handles ListBox1.MouseEnter
        ListBox1.Focus()
    End Sub
    Private Sub fra_MouseMove() Handles fra_List.MouseMove, fra_Contacts.MouseMove, fra_Income.MouseMove, fra_History.MouseMove, fra_Vacation.MouseMove 'Clear message
        intMessage = 0
        Call MouseMessages()
    End Sub
    Private Sub tbox_MouseHover(sender As Object, e As EventArgs) Handles ListBox1.MouseHover, cbx_Active.MouseHover, tbox_Emergency.MouseHover, tbox_Salary.MouseHover, tbox_WeekHours.MouseHover, tbox_WeekFedTax.MouseHover, tbox_WeekStateTax.MouseHover, lbl_WeekSocSecurity.MouseHover, tbox_WeekMisc.MouseHover, tbox_StartDate.MouseHover, tbox_StartSalary.MouseHover, tbox_RaiseDate.MouseHover, tbox_RaiseAmount.MouseHover, tbox_VacaDaysUsed1.MouseHover, tbox_VacaDaysUsed2.MouseHover, tbox_VacaDaysUsed3.MouseHover, tbox_VacaStartDate.MouseHover, tbox_VacaDaysDelete.MouseHover, cmd_DeleteVacaDays.MouseHover, lbl_YearEarnings.MouseHover, lbl_YearFederalTax.MouseHover, lbl_YearStateTax.MouseHover, lbl_YearSocSecurity.MouseHover, lbl_YearMisc.MouseHover
        Select Case sender.name
            Case "ListBox1" : intMessage = 1
            Case "cbx_Active" : intMessage = 2
            Case "tbox_Emergency" : intMessage = 3
            Case "tbox_Salary" : intMessage = 4
            Case "tbox_WeekHours" : intMessage = 5
            Case "tbox_WeekFedTax" : intMessage = 6
            Case "tbox_WeekStateTax" : intMessage = 7
            Case "lbl_WeekSocSecurity" : intMessage = 8
            Case "tbox_WeekMisc" : intMessage = 9
            Case "tbox_StartDate" : intMessage = 10
            Case "tbox_StartSalary" : intMessage = 11
            Case "tbox_RaiseDate" : intMessage = 12
            Case "tbox_RaiseAmount" : intMessage = 13
            Case "tbox_VacaDaysUsed1", "tbox_VacaDaysUsed2", "tbox_VacaDaysUsed3" : intMessage = 14
            Case "tbox_VacaStartDate" : intMessage = 15
            Case "tbox_VacaDaysDelete" : intMessage = 16
            Case "cmd_DeleteVacaDays" : intMessage = 17
            Case "lbl_YearEarnings" : intMessage = 18
            Case "lbl_YearFederalTax" : intMessage = 19
            Case "lbl_YearStateTax" : intMessage = 20
            Case "lbl_YearSocSecurity" : intMessage = 21
            Case "lbl_YearMisc" : intMessage = 22
        End Select
        Call MouseMessages()
    End Sub
    Private Sub MouseMessages()
        Select Case intMessage
            Case 0 : lbl_Message.Text = "" 'Clear message from screen
            Case 1 : lbl_Message.Text = "Select employee name from list to view and edit all employees information"
            Case 2 : lbl_Message.Text = "Removing the check from this box will elimate the employee from the active list"
            Case 3 : lbl_Message.Text = "Enter phone number for emergency contact"
            Case 4 : lbl_Message.Text = "Enter Salary in dollars per hours"
            Case 5 : lbl_Message.Text = "Enter the normal total hours worked each week"
            Case 6 : lbl_Message.Text = "Enter the amount of Federal taxes removed from the weekly paycheck"
            Case 7 : lbl_Message.Text = "Enter the amount of State taxes removed from the weekly paycheck"
            Case 8 : lbl_Message.Text = "Calculated Social Security and Medicare payments removed from the weekly paycheck"
            Case 9 : lbl_Message.Text = "Enter the amount of Misc Deductions removed from the weekly paycheck"
            Case 10 : lbl_Message.Text = "Enter the date employee started working"
            Case 11 : lbl_Message.Text = "Enter the salary per hour the employee started working at"
            Case 12 : lbl_Message.Text = "Enter the date employee was giving his last raise"
            Case 13 : lbl_Message.Text = "Enter the raise amount the employee received during his last raise"
            Case 14 : lbl_Message.Text = "Enter the total amount of used vacation days for the selected year"
            Case 15 : lbl_Message.Text = "This date shows when this employee is eligible for paid vacation time"
            Case 16 : lbl_Message.Text = "Enter the amount of vacation days you want removed from employees vacation time"
            Case 17 : lbl_Message.Text = "Press this to execute the deletion of vacation days from employees vacation time"
            Case 18 : lbl_Message.Text = "Total of all earning for the year " & Year(Now.Date)
            Case 19 : lbl_Message.Text = "Total of all Federal tax payments made for the year " & Year(Now.Date)
            Case 20 : lbl_Message.Text = "Total of all State tax payments made for the year " & Year(Now.Date)
            Case 21 : lbl_Message.Text = "Total of all Social Security and Medicare payments made for the year " & Year(Now.Date)
            Case 22 : lbl_Message.Text = "Total of all Miscellaneous deductions made in the year " & Year(Now.Date)
        End Select
    End Sub

   
End Class