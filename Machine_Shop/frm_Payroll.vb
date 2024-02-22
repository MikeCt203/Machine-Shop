Imports System.Drawing.Printing
Public Class frm_Payroll

    Dim dbAdapter, dbAdapter_SystemData, dbAdapter_Misc As OleDb.OleDbDataAdapter
    Dim dbDataSet, dbDataSet_SystemData, dbDataSet_Misc As New DataSet
    Dim strSQL As String

    Dim ListArray(1, 1) As Integer 'Used to link dataset to listbox selection
    Dim booActives As Boolean 'T = active entries found in database, T= temp social security edit
    Dim intTotalRecords, LastCheck As Integer
    Dim strInitEntry As String 'Variables to hold initial entries of textboxes to test for change
    Dim intLookup As Integer 'Used to locate edited / new saved record in listbox
    Dim intMessage As Integer 'Variable used in the mouse over event to show different messages
    Dim PayrollCategory As String 'Variable to hold payroll category name 
    Dim TotalPayment, NetPayment, BankBalance As Double
    Dim VacaChangeDate As Date

    'Print Related
    Private WithEvents prnDocument As PrintDocument
    Declare Function GetDeviceCaps% Lib "GDI32" (ByVal hDC%, ByVal nIndex%)    
    Private Buffer, CheckCount As Integer
    Private BlackBrush As New SolidBrush(Color.Black)
    Dim booPrint As Boolean = False 'False = at start of printing, check for checks loaded in printer ( Ask only once )
    Dim booPrintCancel As Boolean 'True = printing of cheks canceled


    'All form related events
    Private Sub frm_HandleCreated(sender As Object, e As EventArgs) Handles MyBase.HandleCreated
        Call Actives()
    End Sub
    Private Sub frm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.Text = "Employees Payroll                                                                                                  Date: " & Now.Date
        Me.Top = (My.Computer.Screen.WorkingArea.Height \ 2) - (Me.Height \ 2)
        Me.Left = (My.Computer.Screen.WorkingArea.Width \ 2) - (Me.Width \ 2)

        'Retrieve Social Security limits and last check number
        strSQL = "SELECT CompanyName,SocSecLimit,SocSecPercent,MedicarePercent,CheckbookLastCheck,VacaStart,VacaStop,VacaTrackYears,VacaAddDays,Id FROM System;"
        dbDataSet_SystemData.Clear()
        dbDataSet_SystemData.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter_SystemData = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter_SystemData.Fill(dbDataSet_SystemData, "SystemData")
        gbl_DstConnect.Close()
        If dbDataSet_SystemData.Tables("SystemData").Rows.Count = 1 Then
            tbox_SocSecWageLimit.Text = FormatCurrency(dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(1))
            tbox_SocSecPercent.Text = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(2)
            tbox_MedicarePercent.Text = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(3)
            LastCheck = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(4)
        End If

        'Retrieve category for payroll
        strSQL = "SELECT TOP 1 Category FROM TaxCategorys ORDER BY Id"
        dbDataSet_Misc.Clear()
        dbDataSet_Misc.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter_Misc.Fill(dbDataSet_Misc, "PayrollCategory")
        gbl_DstConnect.Close()
        If dbDataSet_Misc.Tables("PayrollCategory").Rows.Count = 1 Then PayrollCategory = dbDataSet_Misc.Tables("PayrollCategory").Rows(0).Item(0) Else PayrollCategory = "Error"

        'Retrieve checkbook balance
        strSQL = "SELECT TOP 1 Balance FROM Banking ORDER BY Id DESC"
        dbDataSet_Misc.Clear()
        dbDataSet_Misc.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter_Misc.Fill(dbDataSet_Misc, "Balance")
        gbl_DstConnect.Close()
        If dbDataSet_Misc.Tables("Balance").Rows.Count = 1 Then BankBalance = dbDataSet_Misc.Tables("Balance").Rows(0).Item(0)
        tbox_PayCheckDate.Text = Format(Now.Date, "MM/dd/yyyy")

        Call VacationUpdate() 'Update vacation times to present day
        If booActives = True Then opt_Active.Checked = True Else opt_NonActive.Checked = True
    End Sub
    Private Sub Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
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
    Private Sub VacationUpdate()

        strSQL = "SELECT VacaYear1,VacaDays1,VacaUsed1,VacaYear2,VacaDays2,VacaUsed2,VacaYear3,VacaDays3,VacaUsed3,VacaStartDate,Id FROM Employees Where Active = True"
        dbDataSet_Misc.Clear()
        dbDataSet_Misc.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter_Misc.Fill(dbDataSet_Misc, "VacaUpdate")
        gbl_DstConnect.Close()
        If dbDataSet_Misc.Tables("VacaUpdate").Rows.Count <> 0 Then   'Is there any employees
            Dim VacationDays As Integer
            For i = 0 To dbDataSet_Misc.Tables("VacaUpdate").Rows.Count - 1
                If Not IsDBNull(dbDataSet_Misc.Tables("VacaUpdate").Rows(i).Item(0)) Then 'Vacation year date 1
                    If dbDataSet_Misc.Tables("VacaUpdate").Rows(i).Item(0) <= Now.Date.AddYears(-1) Then 'New year begins for employee
                        Dim cb0 As New OleDb.OleDbCommandBuilder(dbAdapter_Misc)

                        If Not IsDBNull(dbDataSet_Misc.Tables("VacaUpdate").Rows(i).Item(5)) Then 'Vacation year used days 2
                            dbDataSet_Misc.Tables("VacaUpdate").Rows(i).Item(8) = dbDataSet_Misc.Tables("VacaUpdate").Rows(i).Item(5) 'Vacation year used days 3 = Vacation year used days 2
                        End If
                        If Not IsDBNull(dbDataSet_Misc.Tables("VacaUpdate").Rows(i).Item(4)) Then 'Vacation year issued days 2
                            dbDataSet_Misc.Tables("VacaUpdate").Rows(i).Item(7) = dbDataSet_Misc.Tables("VacaUpdate").Rows(i).Item(4) 'Vacation year days 3 = Vacation year days 2
                        End If
                        If Not IsDBNull(dbDataSet_Misc.Tables("VacaUpdate").Rows(i).Item(3)) Then 'Vacation year date 2
                            dbDataSet_Misc.Tables("VacaUpdate").Rows(i).Item(6) = dbDataSet_Misc.Tables("VacaUpdate").Rows(i).Item(3) 'Vacation year 3 = Vacation year 2
                        End If
                        If Not IsDBNull(dbDataSet_Misc.Tables("VacaUpdate").Rows(i).Item(2)) Then 'Vacation year used days 1
                            dbDataSet_Misc.Tables("VacaUpdate").Rows(i).Item(5) = dbDataSet_Misc.Tables("VacaUpdate").Rows(i).Item(2) 'Vacation year used days 2 = Vacation year used days 1
                        End If
                        If Not IsDBNull(dbDataSet_Misc.Tables("VacaUpdate").Rows(i).Item(1)) Then 'Vacation year issued days 1
                            dbDataSet_Misc.Tables("VacaUpdate").Rows(i).Item(4) = dbDataSet_Misc.Tables("VacaUpdate").Rows(i).Item(1) 'Vacation year days 2 = Vacation year days 1
                            VacationDays = dbDataSet_Misc.Tables("VacaUpdate").Rows(i).Item(1) + dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(8) 'Add addition days to last allowed vacation time 
                            If VacationDays > dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(6) Then VacationDays = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(6) 'Cap vacation day if over max
                        End If
                        If Not IsDBNull(dbDataSet_Misc.Tables("VacaUpdate").Rows(i).Item(0)) Then 'Vacation year date 1
                            dbDataSet_Misc.Tables("VacaUpdate").Rows(i).Item(3) = dbDataSet_Misc.Tables("VacaUpdate").Rows(i).Item(0) 'Vacation year 2 = Vacation year 1
                        End If
                        If Not IsDBNull(dbDataSet_Misc.Tables("VacaUpdate").Rows(i).Item(1)) Then 'Vacation year issued days 1
                            VacationDays = dbDataSet_Misc.Tables("VacaUpdate").Rows(i).Item(1) + dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(8) 'Add addition days to last allowed vacation time 
                            If VacationDays > dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(6) Then VacationDays = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(6) 'Cap vacation day if over max
                        End If

                        dbDataSet_Misc.Tables("VacaUpdate").Rows(i).Item(0) = dbDataSet_Misc.Tables("VacaUpdate").Rows(i).Item(0).addYears(1) 'Advance change date plus one year
                        dbDataSet_Misc.Tables("VacaUpdate").Rows(i).Item(1) = VacationDays 'Set new years vacation days
                        dbDataSet_Misc.Tables("VacaUpdate").Rows(i).Item(2) = 0 'Reset new year to no days used                     
                        dbAdapter_Misc.Update(dbDataSet_Misc, "VacaUpdate")
                        cb0 = Nothing
                    End If
                Else
                    If Now.Date >= dbDataSet_Misc.Tables("VacaUpdate").Rows(i).Item(9) Then 'Vacation wait period met ( initialize employee with default vacation time)
                        Dim cb1 As New OleDb.OleDbCommandBuilder(dbAdapter_Misc)
                        dbDataSet_Misc.Tables("VacaUpdate").Rows(i).Item(0) = dbDataSet_Misc.Tables("VacaUpdate").Rows(i).Item(9) 'Set first year to vacation start date
                        dbDataSet_Misc.Tables("VacaUpdate").Rows(i).Item(1) = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(5) 'Set first years vacation days to default start years
                        dbDataSet_Misc.Tables("VacaUpdate").Rows(i).Item(2) = 0
                        dbAdapter_Misc.Update(dbDataSet_Misc, "VacaUpdate")
                        cb1 = Nothing

                    End If
                End If
            Next
        End If
    End Sub
    Private Sub Opt_Active_CheckedChanged() Handles opt_Active.CheckedChanged, opt_NonActive.CheckedChanged 'Index recordset based on selected option button
        If opt_Active.Checked = True And booActives = False Then 'No active partipants to show
            frm_Message.Text = "18:1:0:1:3:There are no active customers on record to show"
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
        If intTotalRecords <> 0 Then 'Employees found 
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

            ListBox1.SelectedIndex = 0
            intLookup = ListArray(ListBox1.SelectedIndex, 1)
            opt_Active.Enabled = True
            opt_NonActive.Enabled = True
            Call DataFill()

        Else
            frm_Message.Text = "18:1:0:1:3:There are no employees on record to show"
            frm_Message.ShowDialog()
            Me.Close()
            Exit Sub
        End If

    End Sub
    Private Sub ListBox1_Click() Handles ListBox1.Click, ListBox1.DoubleClick
        intLookup = ListArray(ListBox1.SelectedIndex, 1)
        Call ClearData()
        Call DataFill()
    End Sub
    Private Sub DataFill() 'Fill form with data pertaining to listbox selection

        strSQL = "SELECT ID,Active,LastName,FirstName,BirthDate,SocSecurity,Address,City,State,ZipCode,Phone,Emergency,Email,Salary,WorkHours,FedTax,StateTax,Misc, " _
                     & "PayTotal,FedTaxTotal,StateTaxTotal,SocSecTotal,MiscTotal,TSalary,TWorkHours,TFedTax,TStateTax,TMisc,VacaYear1,VacaDays1,VacaUsed1,VacaYear2, " _
                     & "VacaDays2,VacaUsed2,VacaYear3,VacaDays3,VacaUsed3 FROM Employees WHERE ID = " & intLookup & ";"
        dbDataSet.Clear()
        dbDataSet.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter.Fill(dbDataSet, "Selected")
        gbl_DstConnect.Close()

        'Form fill data
        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(0)) Then 'ID
            lbl_ID.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(0))
        Else : lbl_ID.Text = "" : End If

        If dbDataSet.Tables("Selected").Rows(0).Item(1) = False Then cbx_Active.Checked = False Else cbx_Active.Checked = True 'Active

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(2)) Then : lbl_LastName.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(2)) 'LastName
        Else : lbl_LastName.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(3)) Then 'FirstName
            lbl_FirstName.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(3))
        Else : lbl_FirstName.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(4)) And dbDataSet.Tables("Selected").Rows(0).Item(4).ToString <> "#12/12/1212#" Then 'BirthDate
            lbl_BirthDate.Text = Format(dbDataSet.Tables("Selected").Rows(0).Item(4), "MM/dd/yyyy")
        Else : lbl_BirthDate.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(5)) Then 'SocSecurity
            lbl_SocSecurity.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(5))
        Else : lbl_SocSecurity.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(6)) Then 'Address
            lbl_Address.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(6))
        Else : lbl_Address.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(7)) Then 'City
            lbl_City.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(7))
        Else : lbl_City.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(8)) Then 'State
            lbl_State.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(8))
        Else : lbl_State.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(9)) Then 'Zipcode
            lbl_ZipCode.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(9))
        Else : lbl_ZipCode.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(10)) Then 'Phone
            lbl_Phone.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(10))
        Else : lbl_Phone.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(11)) Then 'Emergency Phone
            lbl_Emergency.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(11))
        Else : lbl_Emergency.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(12)) Then 'Email
            lbl_Email.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(12))
        Else : lbl_Email.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(13)) Then 'Salary
            lbl_Salary.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(13))
        Else : lbl_Salary.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(14)) Then 'Normal week work hours
            lbl_WeekHours.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(14))
        Else : lbl_WeekHours.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(15)) Then 'Normal week federal taxes
            lbl_WeekFedTax.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(15))
        Else : lbl_WeekFedTax.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(16)) Then 'Normal week state taxes
            lbl_WeekStateTax.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(16))
        Else : lbl_WeekStateTax.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(17)) Then 'Normal week misc deductions
            lbl_WeekMisc.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(17))
        Else : lbl_WeekMisc.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(18)) Then 'Pay total for year
            lbl_YearEarnings.Text = FormatCurrency(Trim(dbDataSet.Tables("Selected").Rows(0).Item(18)), 2)
        Else : lbl_YearEarnings.Text = "$0.00" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(19)) Then 'Federal tax total for year
            lbl_YearFederalTax.Text = FormatCurrency(Trim(dbDataSet.Tables("Selected").Rows(0).Item(19)), 2)
        Else : lbl_YearFederalTax.Text = "$0.00" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(20)) Then 'State tax total for year
            lbl_YearStateTax.Text = FormatCurrency(Trim(dbDataSet.Tables("Selected").Rows(0).Item(20)), 2)
        Else : lbl_YearStateTax.Text = "$0.00" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(21)) Then 'Soc Security total for year
            lbl_YearSocSecurity.Text = FormatCurrency(Trim(dbDataSet.Tables("Selected").Rows(0).Item(21)), 2)
        Else : lbl_YearSocSecurity.Text = "$0.00" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(22)) Then 'Misc deductions total for year
            lbl_YearMisc.Text = FormatCurrency(Trim(dbDataSet.Tables("Selected").Rows(0).Item(22)), 2)
        Else : lbl_YearMisc.Text = "$0.00" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(23)) Then 'Temporary Salary
            tbox_SalaryTemp.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(23))
        Else : tbox_SalaryTemp.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(24)) Then 'Temporary week work hours
            tbox_WeekHoursTemp.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(24))
        Else : tbox_WeekHoursTemp.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(25)) Then 'Temporaryl week federal taxes
            tbox_WeekFedTaxTemp.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(25))
        Else : tbox_WeekFedTaxTemp.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(26)) Then 'Temporary week state taxes
            tbox_WeekStateTaxTemp.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(26))
        Else : tbox_WeekStateTaxTemp.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(27)) Then 'Temporary week misc deductions
            tbox_WeekMiscTemp.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(27))
        Else : tbox_WeekMiscTemp.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(28)) Then 'Vacation year date 1
            lbl_VacaYear1.Text = Year(dbDataSet.Tables("Selected").Rows(0).Item(28))
            VacaChangeDate = dbDataSet.Tables("Selected").Rows(0).Item(28)
        Else : lbl_VacaYear1.Text = "" : VacaChangeDate = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(29)) Then 'Vacation year issued days 1
            lbl_VacaIssued1.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(29))
        Else : lbl_VacaIssued1.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(30)) Then 'Vacation year used days 1
            lbl_VacaUsed1.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(30))
        Else : lbl_VacaUsed1.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(31)) Then 'Vacation year date 2
            lbl_VacaYear2.Text = Year(dbDataSet.Tables("Selected").Rows(0).Item(31))
        Else : lbl_VacaYear2.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(32)) Then 'Vacation year issued days 2
            lbl_VacaIssued2.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(32))
        Else : lbl_VacaIssued2.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(33)) Then 'Vacation year used days 2
            lbl_VacaUsed2.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(33))
        Else : lbl_VacaUsed2.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(34)) Then 'Vacation year date 3
            lbl_VacaYear3.Text = Year(dbDataSet.Tables("Selected").Rows(0).Item(34))
        Else : lbl_VacaYear3.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(35)) Then 'Vacation year issued days 3
            lbl_VacaIssued3.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(35))
        Else : lbl_VacaIssued3.Text = "" : End If

        If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(36)) Then 'Vacation year used days 3
            lbl_VacaUsed3.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(36))
        Else : lbl_VacaUsed3.Text = "" : End If

        Call Calculate_SocSecurity()
    End Sub
    Private Sub Calculate_SocSecurity() 'Calculate social security payments

        If lbl_Salary.Text = "" Or lbl_WeekHours.Text = "" Or lbl_YearEarnings.Text = "" Then Exit Sub
        Dim YearEarnings As Double = lbl_YearEarnings.Text
        Dim SocSecurityLimit As Double = tbox_SocSecWageLimit.Text
        Dim SocSecPercent As Double = tbox_SocSecPercent.Text
        Dim MedicarePercent As Double = tbox_MedicarePercent.Text
        Dim SocSec_Taxed As Double = 0
        Dim Salary, SocSecAmt As Double
        Dim Hours As Integer

        For i = 0 To 1
            If i = 0 Then
                Hours = Convert.ToInt32(lbl_WeekHours.Text)
                Salary = Convert.ToDouble(lbl_Salary.Text)
            Else
                'Set up variables for temp
                If Trim(tbox_WeekHoursTemp.Text) = "" And Trim(tbox_SalaryTemp.Text) = "" And Trim(tbox_WeekFedTaxTemp.Text) = "" And Trim(tbox_WeekStateTaxTemp.Text) = "" And Trim(tbox_WeekMiscTemp.Text) = "" Then Exit Sub 'No temp entries
                If Trim(tbox_WeekHoursTemp.Text) = "" And Trim(tbox_SalaryTemp.Text) = "" Then lbl_WeekSocSecurityTemp.Text = lbl_WeekSocSecurity.Text : Exit Sub 'Same social security payment
                If tbox_WeekHoursTemp.Text <> "" Then Hours = Convert.ToSingle(tbox_WeekHoursTemp.Text) Else Hours = Convert.ToSingle(lbl_WeekHours.Text)
                If tbox_SalaryTemp.Text <> "" Then Salary = Convert.ToDouble(tbox_SalaryTemp.Text) Else Salary = Convert.ToDouble(lbl_Salary.Text)
            End If

            'Calculate paycheck ( overtime )
            If Hours > 40 Then
                TotalPayment = (Salary * 40) + ((Salary * 1.5) * (Hours - 40))
            Else
                TotalPayment = Salary * Hours
            End If

            'Calculate social security
            If YearEarnings + TotalPayment <= SocSecurityLimit Then SocSec_Taxed = TotalPayment
            If YearEarnings <= SocSecurityLimit And YearEarnings + TotalPayment > SocSecurityLimit Then SocSec_Taxed = SocSecurityLimit - YearEarnings
            SocSecAmt = FormatNumber((SocSec_Taxed * SocSecPercent) + (TotalPayment * MedicarePercent), 2)
            SocSecAmt = Math.Round(SocSecAmt, 2, MidpointRounding.AwayFromZero) 'Round amount to two decimal places
            If i = 0 Then lbl_WeekSocSecurity.Text = SocSecAmt Else lbl_WeekSocSecurityTemp.Text = SocSecAmt
        Next
    End Sub
    Private Sub ClearData() 'Clear form of all data
        cbx_Active.Checked = False
        lbl_ID.Text = ""
        lbl_LastName.Text = ""
        lbl_FirstName.Text = ""
        lbl_BirthDate.Text = ""
        lbl_SocSecurity.Text = ""
        lbl_Address.Text = ""
        lbl_City.Text = ""
        lbl_State.Text = ""
        lbl_ZipCode.Text = ""
        lbl_Phone.Text = ""
        lbl_Emergency.Text = ""
        lbl_Email.Text = ""
        lbl_Salary.Text = ""
        lbl_WeekHours.Text = ""
        lbl_WeekFedTax.Text = ""
        lbl_WeekStateTax.Text = ""
        lbl_WeekSocSecurity.Text = ""
        lbl_WeekMisc.Text = ""
        tbox_SalaryTemp.Text = ""
        tbox_WeekHoursTemp.Text = ""
        tbox_WeekFedTaxTemp.Text = ""
        tbox_WeekStateTaxTemp.Text = ""
        lbl_WeekSocSecurityTemp.Text = ""
        tbox_WeekMiscTemp.Text = ""
        lbl_YearEarnings.Text = ""
        lbl_YearFederalTax.Text = ""
        lbl_YearStateTax.Text = ""
        lbl_YearSocSecurity.Text = ""
        lbl_YearMisc.Text = ""
    End Sub
    Private Sub EnableEdits(Tag As Integer)
        Select Case Tag
            Case 0
                tbox_SalaryTemp.Enabled = True
                tbox_WeekHoursTemp.Enabled = True
                tbox_WeekFedTaxTemp.Enabled = True
                tbox_WeekStateTaxTemp.Enabled = True
                tbox_WeekMiscTemp.Enabled = True
                tbox_PayCheckDate.Enabled = False
                DateTimePicker1.Enabled = False
                cmd_ClearAdjustments.Enabled = False
            Case 1
                tbox_SocSecWageLimit.Enabled = True
                tbox_SocSecPercent.Enabled = True
                tbox_MedicarePercent.Enabled = True
                tbox_PayCheckDate.Enabled = False
                DateTimePicker1.Enabled = False
                cmd_ClearAdjustments.Enabled = False
            Case 2
                tbox_SalaryTemp.Enabled = False
                tbox_WeekHoursTemp.Enabled = False
                tbox_WeekFedTaxTemp.Enabled = False
                tbox_WeekStateTaxTemp.Enabled = False
                tbox_WeekMiscTemp.Enabled = False
                tbox_SocSecWageLimit.Enabled = False
                tbox_SocSecPercent.Enabled = False
                tbox_MedicarePercent.Enabled = False
                tbox_PayCheckDate.Enabled = True
                DateTimePicker1.Enabled = True
                cmd_ClearAdjustments.Enabled = True
        End Select
    End Sub
    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        tbox_PayCheckDate.Text = DateTimePicker1.Value.ToString("MM/dd/yyyy")
    End Sub
    Private Sub RestoreData()
        If tbox_SalaryTemp.Enabled = True Then
            tbox_SalaryTemp.ReadOnly = True
            If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(23)) Then 'Temporary Salary
                tbox_SalaryTemp.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(23))
            Else : tbox_SalaryTemp.Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(24)) Then 'Temporary week work hours
                tbox_WeekHoursTemp.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(24))
            Else : tbox_WeekHoursTemp.Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(25)) Then 'Temporaryl week federal taxes
                tbox_WeekFedTaxTemp.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(25))
            Else : tbox_WeekFedTaxTemp.Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(26)) Then 'Temporary week state taxes
                tbox_WeekStateTaxTemp.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(26))
            Else : tbox_WeekStateTaxTemp.Text = "" : End If

            If Not IsDBNull(dbDataSet.Tables("Selected").Rows(0).Item(27)) Then 'Temporary week misc deductions
                tbox_WeekMiscTemp.Text = Trim(dbDataSet.Tables("Selected").Rows(0).Item(27))
            Else : tbox_WeekMiscTemp.Text = "" : End If
            If tbox_SalaryTemp.Text <> "" And tbox_WeekHoursTemp.Text <> "" Then Call Calculate_SocSecurity() Else lbl_WeekSocSecurityTemp.Text = ""
            tbox_SalaryTemp.ReadOnly = False
        Else
            tbox_SocSecWageLimit.Text = FormatCurrency(dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(1))
            tbox_SocSecPercent.Text = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(2)
            tbox_MedicarePercent.Text = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(3)
        End If
    End Sub
    Private Sub SaveCheck()

        'Ready misc for database save
        Dim CheckDate As Date
        Dim SalaryTotal, FedTotal, StateTotal, SocSecTotal, MiscTotal As Double
        SalaryTotal = lbl_YearEarnings.Text + TotalPayment
        If tbox_PayCheckDate.Text = "  /  /" Then CheckDate = FormatDateTime(Now.Date) Else CheckDate = tbox_PayCheckDate.Text
        If tbox_WeekFedTaxTemp.Text <> "" Then FedTotal = dbDataSet.Tables("Selected").Rows(0).Item(19) + tbox_WeekFedTaxTemp.Text Else FedTotal = dbDataSet.Tables("Selected").Rows(0).Item(19) + lbl_WeekFedTax.Text
        If tbox_WeekStateTaxTemp.Text <> "" Then StateTotal = dbDataSet.Tables("Selected").Rows(0).Item(20) + tbox_WeekStateTaxTemp.Text Else StateTotal = dbDataSet.Tables("Selected").Rows(0).Item(20) + lbl_WeekStateTax.Text
        If lbl_WeekSocSecurityTemp.Text <> "" Then SocSecTotal = dbDataSet.Tables("Selected").Rows(0).Item(21) + lbl_WeekSocSecurityTemp.Text Else SocSecTotal = dbDataSet.Tables("Selected").Rows(0).Item(21) + lbl_WeekSocSecurity.Text
        If tbox_WeekMiscTemp.Text <> "" Then MiscTotal = dbDataSet.Tables("Selected").Rows(0).Item(22) + tbox_WeekMiscTemp.Text Else MiscTotal = dbDataSet.Tables("Selected").Rows(0).Item(22) + lbl_WeekMisc.Text
        NetPayment = Math.Round(NetPayment, 2, MidpointRounding.AwayFromZero) 'Round amount to two decimal places
        BankBalance = BankBalance - NetPayment
        LastCheck = LastCheck + 1

        'Save new check data to banking database
        strSQL = "Select Id,TransDate,Transactions,Chkno,Payee,Category,Memos,Amount,Balance,Clear,Documentation FROM Banking ORDER BY Id;"
        dbDataSet_Misc.Clear()
        dbDataSet_Misc.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter_Misc.Fill(dbDataSet_Misc, "Checks")
        gbl_DstConnect.Close()

        Dim cb0 As New OleDb.OleDbCommandBuilder(dbAdapter_Misc)
        Dim dsNewRow As DataRow
        dsNewRow = dbDataSet_Misc.Tables("Checks").NewRow()
        dsNewRow.Item("TransDate") = CheckDate
        dsNewRow.Item("Transactions") = "Check"
        dsNewRow.Item("Chkno") = LastCheck
        dsNewRow.Item("Payee") = lbl_FirstName.Text & " " & lbl_LastName.Text
        dsNewRow.Item("Category") = PayrollCategory
        dsNewRow.Item("Memos") = "Payroll"
        dsNewRow.Item("Amount") = NetPayment
        dsNewRow.Item("Balance") = BankBalance
        dsNewRow.Item("Clear") = False
        dbDataSet_Misc.Tables("Checks").Rows.Add(dsNewRow)
        dbAdapter_Misc.Update(dbDataSet_Misc, "Checks")
        cb0 = Nothing

        'Update all employee totals to employee database
        strSQL = "SELECT PayTotal,FedTaxTotal,StateTaxTotal,SocSecTotal,MiscTotal,Id FROM Employees WHERE ID = " & intLookup & ";"
        dbDataSet_Misc.Clear()
        dbDataSet_Misc.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter_Misc.Fill(dbDataSet_Misc, "EmployeeTotals")
        gbl_DstConnect.Close()

        Dim cb1 As New OleDb.OleDbCommandBuilder(dbAdapter_Misc)
        dbDataSet_Misc.Tables("EmployeeTotals").Rows(0).Item(0) = SalaryTotal
        dbDataSet_Misc.Tables("EmployeeTotals").Rows(0).Item(1) = FedTotal
        dbDataSet_Misc.Tables("EmployeeTotals").Rows(0).Item(2) = StateTotal
        dbDataSet_Misc.Tables("EmployeeTotals").Rows(0).Item(3) = SocSecTotal
        dbDataSet_Misc.Tables("EmployeeTotals").Rows(0).Item(4) = MiscTotal
        dbAdapter_Misc.Update(dbDataSet_Misc, "EmployeeTotals")
        intLookup = lbl_ID.Text
        cb1 = Nothing

        'Update system database
        Dim cb2 As New OleDb.OleDbCommandBuilder(dbAdapter_SystemData)
        dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(4) = LastCheck
        dbAdapter_SystemData.Update(dbDataSet_SystemData, "SystemData")
        cb2 = Nothing

    End Sub


    'All command actions ( Edit/Save,Cancel,Exit,Edit/Restore )
    Private Sub cmd_Action_Click(sender As Object, e As EventArgs) Handles cmd_Action1.Click, cmd_Action0.Click, cmd_Action2.Click, cmd_Action3.Click

        Select Case sender.text
            Case "Edit"
                If lbl_FirstName.Text = "" Then Exit Sub
                ListBox1.Enabled = False
                opt_Active.Enabled = False
                opt_NonActive.Enabled = False
                If sender.tag = 0 Then
                    Call EnableEdits(0)
                    cmd_Action0.Text = "Restore"
                    cmd_Action0.Image = My.Resources.Resources.Restore_3
                    cmd_Action0.Enabled = False
                    cmd_Action1.Enabled = False
                    tbox_SalaryTemp.Focus()
                Else
                    Call EnableEdits(1)
                    cmd_Action1.Text = "Restore"
                    cmd_Action1.Image = My.Resources.Resources.Restore_3
                    cmd_Action1.Enabled = False
                    cmd_Action0.Enabled = False
                    tbox_SocSecWageLimit.Focus()
                End If
                cmd_PrintAll.Enabled = False
                cmd_PrintIndividual.Enabled = False

            Case "Cancel"
                Call RestoreData()
                Call FileOperationReset()
                Call EnableEdits(2)
                opt_Active.Enabled = True
                opt_NonActive.Enabled = True
                ListBox1.Visible = True
                ListBox1.Enabled = True
                ListBox1.Focus()

            Case "Restore"
                Call RestoreData()
                cmd_Action1.Enabled = False
                cmd_Action3.Enabled = False

            Case "Save"

                'Validate entries
                If tbox_SocSecWageLimit.Enabled = True Then
                    If Trim(tbox_SocSecWageLimit.Text) = "" Or Trim(tbox_SocSecPercent.Text) = "" Or Trim(tbox_MedicarePercent.Text) = "" Then
                        frm_Message.Text = "18:1:0:29:5:All Social Security entries must be complete before Saving of data will be allowed"
                        frm_Message.ShowDialog()
                        Exit Sub
                    End If
                End If

                'Save form to database
                On Error GoTo goActionErr
                If tbox_SalaryTemp.Enabled = True Then
                    Dim cb0 As New OleDb.OleDbCommandBuilder(dbAdapter)
                    If Trim(tbox_SalaryTemp.Text) <> "" And Trim(tbox_SalaryTemp.Text) <> "0" Then : dbDataSet.Tables("Selected").Rows(0).Item(23) = Trim(tbox_SalaryTemp.Text) 'Salary Temp
                    Else : dbDataSet.Tables("Selected").Rows(0).Item(23) = DBNull.Value : End If
                    If Trim(tbox_WeekHoursTemp.Text) <> "" And Trim(tbox_WeekHoursTemp.Text) <> "0" Then : dbDataSet.Tables("Selected").Rows(0).Item(24) = Trim(tbox_WeekHoursTemp.Text) 'Work hours
                    Else : dbDataSet.Tables("Selected").Rows(0).Item(24) = DBNull.Value : End If
                    If Trim(tbox_WeekFedTaxTemp.Text) <> "" And Trim(tbox_WeekFedTaxTemp.Text) <> "0" Then : dbDataSet.Tables("Selected").Rows(0).Item(25) = Trim(tbox_WeekFedTaxTemp.Text) 'Fed Taxes
                    Else : dbDataSet.Tables("Selected").Rows(0).Item(25) = DBNull.Value : End If
                    If Trim(tbox_WeekStateTaxTemp.Text) <> "" And Trim(tbox_WeekStateTaxTemp.Text) <> "0" Then : dbDataSet.Tables("Selected").Rows(0).Item(26) = Trim(tbox_WeekStateTaxTemp.Text) 'State Taxes
                    Else : dbDataSet.Tables("Selected").Rows(0).Item(26) = DBNull.Value : End If
                    If Trim(tbox_WeekMiscTemp.Text) <> "" And Trim(tbox_WeekMiscTemp.Text) <> "0" Then : dbDataSet.Tables("Selected").Rows(0).Item(27) = Trim(tbox_WeekMiscTemp.Text) 'Misc
                    Else : dbDataSet.Tables("Selected").Rows(0).Item(27) = DBNull.Value : End If
                    dbAdapter.Update(dbDataSet, "Selected")
                    cb0 = Nothing
                Else
                    Dim cb1 As New OleDb.OleDbCommandBuilder(dbAdapter_SystemData)
                    dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(1) = Convert.ToSingle(Replace(tbox_SocSecWageLimit.Text, "$", "")) 'Social security wage base limit
                    dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(2) = Convert.ToSingle(Replace(tbox_SocSecPercent.Text, "%", "")) 'Social security percentage
                    dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(3) = Convert.ToSingle(Replace(tbox_MedicarePercent.Text, "%", "")) 'Medicare security percentage
                    dbAdapter_SystemData.Update(dbDataSet_SystemData, "SystemData")
                    cb1 = Nothing
                End If

                opt_Active.Enabled = True
                opt_NonActive.Enabled = True
                ListBox1.Visible = True
                ListBox1.Enabled = True
                ListBox1.Focus()
                Call EnableEdits(2)
                Call FileOperationReset()
                Exit Sub
goActionErr:
                MsgBox(Err.Description)
                Exit Sub

            Case "Exit" : Me.Close() : Exit Sub
        End Select

    End Sub
    Private Sub cmd_ClearAdjustments_Click(sender As Object, e As EventArgs) Handles cmd_ClearAdjustments.Click

        If tbox_SalaryTemp.Enabled = True Then 'Clear texboxes only
            tbox_SalaryTemp.Text = ""
            tbox_WeekHoursTemp.Text = ""
            tbox_WeekFedTaxTemp.Text = ""
            tbox_WeekStateTaxTemp.Text = ""
            lbl_WeekSocSecurityTemp.Text = ""
            tbox_WeekMiscTemp.Text = ""
        Else
            frm_Message.Text = "18:2:0:1:3:Are you sure you want to delete all adjustments from the database"
            frm_Message.ShowDialog()

            If MessageResult = True Then
                tbox_SalaryTemp.Text = ""
                tbox_WeekHoursTemp.Text = ""
                tbox_WeekFedTaxTemp.Text = ""
                tbox_WeekStateTaxTemp.Text = ""
                lbl_WeekSocSecurityTemp.Text = ""
                tbox_WeekMiscTemp.Text = ""

                Dim cb0 As New OleDb.OleDbCommandBuilder(dbAdapter)
                dbDataSet.Tables("Selected").Rows(0).Item(23) = DBNull.Value 'Temporary Salary
                dbDataSet.Tables("Selected").Rows(0).Item(24) = DBNull.Value 'Temporary week work hours
                dbDataSet.Tables("Selected").Rows(0).Item(25) = DBNull.Value 'Temporaryl week federal taxes
                dbDataSet.Tables("Selected").Rows(0).Item(26) = DBNull.Value 'Temporary week state taxes
                dbDataSet.Tables("Selected").Rows(0).Item(27) = DBNull.Value 'Temporary week misc deductions
                dbAdapter.Update(dbDataSet, "Selected")
                cb0 = Nothing
            End If
        End If
    End Sub
    Private Sub FileOperationReset()
        cmd_Action0.Text = "Edit"
        cmd_Action0.Image = My.Resources.Resources.Edit_2
        cmd_Action0.Enabled = True   'View Edit button
        cmd_Action1.Text = "Edit"
        cmd_Action1.Image = My.Resources.Resources.Edit_2
        cmd_Action1.Enabled = True   'View Edit button
        cmd_Action3.Text = "Exit"
        cmd_Action3.Image = My.Resources.Resources._Exit
        cmd_Action3.Enabled = True   'View exit button
        cmd_PrintAll.Enabled = True
        cmd_PrintIndividual.Enabled = True
    End Sub


    'Print Related 
    Private Sub cmd_PayCheckPrint_Click(sender As Object, e As EventArgs) Handles cmd_PrintAll.Click, cmd_PrintIndividual.Click

        If sender.Name = "cmd_PrintIndividual" Then

            'Check for missing paycheck date 
            If tbox_PayCheckDate.Text = "  /  /" Then
                frm_Message.Text = "18:1:0:20:3:Paycheck date must be entered to continue"
                frm_Message.ShowDialog()
                tbox_PayCheckDate.BackColor = Color.White
                tbox_PayCheckDate.Focus()
                Exit Sub
            End If

            'Check for sufficent funds im checkbook
            If TotalPayment > BankBalance Then
                frm_Message.Text = "18:4:0:30:3:The Checkbook has insufficent funds to cash this check"
                frm_Message.ShowDialog()
                If MessageResult = True Then 'Exit
                    Me.Close()
                    Exit Sub
                End If
            End If

            'Check if any temporary changes found for employee
            If Trim(tbox_WeekFedTaxTemp.Text) <> "" Or Trim(tbox_WeekStateTaxTemp.Text) <> "" Or Trim(tbox_WeekMiscTemp.Text) <> "" Or Trim(lbl_WeekSocSecurityTemp.Text) <> "" Then
                frm_Message.Text = "18:2:0:31:3:Proceed with printing this employee's paycheck with temporary changes"
                frm_Message.ShowDialog()
                If MessageResult = False Then 'Clear temporary changes for this check only ( This time only ) 
                    tbox_SalaryTemp.Text = ""
                    tbox_WeekHoursTemp.Text = ""
                    tbox_WeekFedTaxTemp.Text = ""
                    tbox_WeekStateTaxTemp.Text = ""
                    lbl_WeekSocSecurityTemp.Text = ""
                    tbox_WeekMiscTemp.Text = ""
                    Call Calculate_SocSecurity()
                End If
            End If
            Do
                Call PrintCheck()
                If booPrintCancel = True Then Exit Sub
                frm_Message.Text = "18:2:0:33:3:Did the check print properly"
                frm_Message.ShowDialog()

                If MessageResult = True Then
                    Call SaveCheck()
                    Exit Sub
                Else
                    frm_Message.Text = "18:1:0:34:3:Correct issue with printer and press [OK] when ready"
                    frm_Message.ShowDialog()
                End If
            Loop

        Else 'cmd_PrintAll
            If opt_Active.Checked = False Then opt_Active.Checked = True
            For intStep = 0 To UBound(ListArray)
                ListBox1.SelectedIndex = intStep
                intLookup = ListArray(intStep, 1)
                Call ClearData()
                Call DataFill()

                'Check for sufficent funds im checkbook
                If TotalPayment > BankBalance Then
                    frm_Message.Text = "18:4:0:30:3:The Checkbook has insufficent funds to cash this check"
                    frm_Message.ShowDialog()
                    If MessageResult = True Then 'Exit
                        Me.Close()
                        Exit Sub
                    End If
                End If

                'Check if any temporary changes found for selected employee
                If Trim(tbox_WeekFedTaxTemp.Text) <> "" Or Trim(tbox_WeekStateTaxTemp.Text) <> "" Or Trim(tbox_WeekMiscTemp.Text) <> "" Or Trim(lbl_WeekSocSecurityTemp.Text) <> "" Then
                    frm_Message.Text = "18:2:0:31:3:Proceed with printing this employee's paycheck with temporary changes"
                    frm_Message.ShowDialog()
                    If MessageResult = False Then 'Clear temporary changes for this check only ( This time only ) 
                        tbox_SalaryTemp.Text = ""
                        tbox_WeekHoursTemp.Text = ""
                        tbox_WeekFedTaxTemp.Text = ""
                        tbox_WeekStateTaxTemp.Text = ""
                        lbl_WeekSocSecurityTemp.Text = ""
                        tbox_WeekMiscTemp.Text = ""
                        Call Calculate_SocSecurity()
                    End If
                End If

                Call PrintCheck()
                If booPrintCancel = True Then Exit Sub
                frm_Message.Text = "18:2:0:33:3:Did the check print properly"
                frm_Message.ShowDialog()

                If MessageResult = True Then
                    Call SaveCheck()
                Else
                    frm_Message.Text = "18:1:0:34:3:Correct issue with printer and press [OK] when ready"
                    frm_Message.ShowDialog()
                    intStep = intStep - 1
                End If
            Next
        End If

    End Sub
    Private Sub PrintCheck()
        'Show load check only on first check
        booPrintCancel = False
        If booPrint = False Then
            booPrint = True
            frm_Message.Text = "18:8:0:32:8:Load checks in printer and press [OK] when ready"
            frm_Message.ShowDialog()

            If MessageResult = True Then 'Ok
                prnDocument = New PrintDocument
                prnDocument.Print()
            Else
                booPrintCancel = True 'Cancel printing of check
                booPrint = False
                Exit Sub
            End If
        Else
            prnDocument = New PrintDocument
            prnDocument.Print()
        End If
    End Sub
    Private Sub prnDocument_PrintPage(sender As Object, e As PrintPageEventArgs) Handles prnDocument.PrintPage 'remove 1 at end of printform1

        'Setup hard margins for printer
        Dim hDC As IntPtr = e.Graphics.GetHdc()
        Dim HardX1, HardX2, HardY1, TextX, TextLen, SoftY, VacaDay1, VacaDay2, VacaDay3 As Integer
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
        VacaDay2 = 0
        VacaDay3 = 0

        'Print form graphics
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit
        Using the_pen As New Pen(Color.Black, 1)

            points = {New Point(HardX1, HardY1 + 35), New Point(HardX2, HardY1 + 35)} 'Upper section 1st horizontal Line
            e.Graphics.DrawLines(the_pen, points)

            points = {New Point(HardX1 + 70, HardY1 + 178), New Point(HardX1 + 270, HardY1 + 178)} 'Upper section 2nd horizontal Line_1
            e.Graphics.DrawLines(the_pen, points)

            SoftY = ((dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(7) - 1) * 15) + 148 'Adjust for vacation years shown on payslip
            points = {New Point(HardX1 + 475, HardY1 + SoftY), New Point(HardX1 + 675, HardY1 + SoftY)} 'Upper section 2nd horizontal Line_2
            e.Graphics.DrawLines(the_pen, points)

            points = {New Point(HardX1 + 30, HardY1 + 235), New Point(HardX1 + 170, HardY1 + 235)} 'Upper section 3rd horizontal Line_1
            e.Graphics.DrawLines(the_pen, points)

            points = {New Point(HardX1 + 220, HardY1 + 235), New Point(HardX1 + 360, HardY1 + 235)} 'Upper section 3rd horizontal Line_2
            e.Graphics.DrawLines(the_pen, points)

            points = {New Point(HardX1 + 410, HardY1 + 235), New Point(HardX1 + 550, HardY1 + 235)} 'Upper section 3rd horizontal Line_3
            e.Graphics.DrawLines(the_pen, points)

            points = {New Point(HardX1 + 600, HardY1 + 235), New Point(HardX1 + 740, HardY1 + 235)} 'Upper section 3rd horizontal Line_4
            e.Graphics.DrawLines(the_pen, points)

            points = {New Point(HardX1, HardY1 + 735), New Point(HardX2, HardY1 + 735)} 'Lower section 1st horizontal Line
            e.Graphics.DrawLines(the_pen, points)

            points = {New Point(HardX1 + 445, HardY1 + 852), New Point(HardX1 + 645, HardY1 + 852)} 'Lower section 2nd horizontal Line_1
            e.Graphics.DrawLines(the_pen, points)

        End Using 'The_pen

        'Fill upper form section Text
        Font = New Font("Arial", 9, FontStyle.Bold)

        Text = "Check No." 'Print label Check 
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 670, HardY1 + 8)

        Text = "Employee:"
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 60, HardY1 + 50) 'Print label Employee

        Text = "Pay Period:"
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 60, HardY1 + 65) 'Print label Pay Period

        Text = "Total Hours:"
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 480, HardY1 + 65) 'Print label Total Hours

        Text = "Total Pay:"
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 100, HardY1 + 100) 'Print label Total Pay

        Text = "Available Vacation Days"
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 510, HardY1 + 100) 'Print label Availabe Vacation Days

        Text = "Federal Tax:"
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 100, HardY1 + 115) 'Print label Federal Tax

        Text = "Vacation Change Date:"
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 470, HardY1 + 115) 'Print label Vacation Change Date

        Text = "State Tax:"
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 100, HardY1 + 130) 'Print label State Tax

        Text = "days left"
        e.Graphics.DrawString(Text, New Font("Arial", 9, FontStyle.Regular), BlackBrush, HardX1 + 585, HardY1 + 130) 'Print label days left ( Year 1 )

        Text = "Social Sec.:"
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 100, HardY1 + 145) 'Print label Total Pay

        If dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(7) >= 2 Then 'Show only if 2 or more years shown on payslip
            Text = "days left"
            e.Graphics.DrawString(Text, New Font("Arial", 9, FontStyle.Regular), BlackBrush, HardX1 + 585, HardY1 + 145) 'Print label days left ( Year 2 )
        End If

        Text = "Misc.:"
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 100, HardY1 + 160) 'Print label Misc

        If dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(7) = 3 Then 'Show only if 3 years shown on payslip
            Text = "days left"
            e.Graphics.DrawString(Text, New Font("Arial", 9, FontStyle.Regular), BlackBrush, HardX1 + 585, HardY1 + 160) 'Print label days left ( Year 3 )
        End If

        Text = "Net Pay:"
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 100, HardY1 + 180) 'Print label Net Pay

        SoftY = ((dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(7)) * 15) + 135 'Adjust for vacation years shown on payslip
        Text = "Total"
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 517, HardY1 + SoftY) 'Print label Total

        Text = "days left"
        e.Graphics.DrawString(Text, New Font("Arial", 9, FontStyle.Regular), BlackBrush, HardX1 + 585, HardY1 + SoftY) 'Print label days left ( Total )

        Text = "Total Earnings"
        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 53, HardY1 + 218) 'Print label Total Earnings

        Text = "Total Federal"
        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 248, HardY1 + 218) 'Print label Total Federal

        Text = "Total State"
        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 445, HardY1 + 218) 'Print label Total State

        Text = "Total Social Sec."
        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 617, HardY1 + 218) 'Print label Social Sec.

        'Fill lower form section Text)
        Text = "Check No." 'Print label Check 
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 670, HardY1 + 708)

        Text = "Pay Period:"
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 480, HardY1 + 745) 'Print label Pay Period

        Text = "Total Hours:"
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 480, HardY1 + 760) 'Print label Total Hours

        Text = "Total Pay:"
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 480, HardY1 + 775) 'Print label Total Pay

        Text = "Federal Tax:"
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 480, HardY1 + 790) 'Print label Federal Tax

        Text = "State Tax:"
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 480, HardY1 + 805) 'Print label State Tax

        Text = "Social Sec.:"
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 480, HardY1 + 820) 'Print label Total Pay

        Text = "Misc.:"
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 480, HardY1 + 835) 'Print label Misc

        Text = "Check No.:"
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 80, HardY1 + 855) 'Print label Check No.

        Text = "Net Pay:"
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 480, HardY1 + 855) 'Print label Net Pay

        Text = "Check Date:"
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 73, HardY1 + 870) 'Print label Check Date

        Text = "Check Amount:"
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 53, HardY1 + 885) 'Print label Check Amount

        Text = "To The"
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 106, HardY1 + 945) 'Print label To The

        Text = "Order"
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 106, HardY1 + 960) 'Print label Order

        Text = "Of"
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 106, HardY1 + 975) 'Print label Of

        'Check for any temporary adjustments to paycheck
        Dim Hours, FedTax, StateTax, SocSecAmt, MiscAmt As Double
        If tbox_WeekHoursTemp.Text <> "" Then Hours = tbox_WeekHoursTemp.Text Else Hours = lbl_WeekHours.Text
        If tbox_WeekFedTaxTemp.Text <> "" Then FedTax = tbox_WeekFedTaxTemp.Text Else FedTax = lbl_WeekFedTax.Text
        If tbox_WeekStateTaxTemp.Text <> "" Then StateTax = tbox_WeekStateTaxTemp.Text Else StateTax = lbl_WeekStateTax.Text
        If lbl_WeekSocSecurityTemp.Text <> "" Then SocSecAmt = lbl_WeekSocSecurityTemp.Text Else SocSecAmt = lbl_WeekSocSecurity.Text
        If tbox_WeekMiscTemp.Text <> "" Then MiscAmt = tbox_WeekMiscTemp.Text Else MiscAmt = lbl_WeekMisc.Text
        NetPayment = TotalPayment - (FedTax + StateTax + SocSecAmt + MiscAmt)

        'Fill upper form data
        Dim CompanyName As String = Replace(dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(0), "&&", "&")
        Text = CompanyName 'Print company name
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 40, HardY1 + 8)

        Text = LastCheck + 1 'Print check number
        Font = New Font("Ariel", 9, FontStyle.Regular)
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 735, HardY1 + 8)

        Text = lbl_FirstName.Text & " " & lbl_LastName.Text
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 136, HardY1 + 50) 'Print employee name

        Dim CheckDate As Date = tbox_PayCheckDate.Text
        Dim PayPeriod As String = CheckDate.AddDays(-6) & " to " & CheckDate
        e.Graphics.DrawString(PayPeriod, Font, BlackBrush, HardX1 + 136, HardY1 + 65) 'Print payment period

        If tbox_WeekHoursTemp.Text <> "" Then Text = tbox_WeekHoursTemp.Text Else Text = lbl_WeekHours.Text
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 560, HardY1 + 65) 'Print total hours worked

        Text = FormatCurrency(TotalPayment)
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 182, HardY1 + 100) 'Print Pay total

        Text = FormatCurrency(FedTax)
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 182, HardY1 + 115) 'Print weekly federal taxes

        Text = VacaChangeDate.AddYears(1)
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 610, HardY1 + 115) 'Print vacation change date

        Text = FormatCurrency(StateTax)
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 182, HardY1 + 130) 'Print weekly State taxes

        Text = lbl_VacaYear1.Text
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 520, HardY1 + 130) 'Print vacation year 1

        VacaDay1 = lbl_VacaIssued1.Text - lbl_VacaUsed1.Text
        TextLen = Convert.ToInt32(e.Graphics.MeasureString(VacaDay1, Font).Width)
        e.Graphics.DrawString(VacaDay1, Font, BlackBrush, (HardX1 + 578) - TextLen, HardY1 + 130) 'Print vacation year 1 days left

        Text = FormatCurrency(SocSecAmt)
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 182, HardY1 + 145) 'Print weekly Social Security payment

        If dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(7) >= 2 Then 'Show only if 2 or more years shown on payslip
            Text = lbl_VacaYear2.Text
            e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 520, HardY1 + 145) 'Print vacation year 2
            VacaDay2 = lbl_VacaIssued2.Text - lbl_VacaUsed2.Text
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(VacaDay2, Font).Width)
            e.Graphics.DrawString(VacaDay2, Font, BlackBrush, (HardX1 + 578) - TextLen, HardY1 + 145) 'Print vacation year 2 days left
        End If

        Text = FormatCurrency(MiscAmt)
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 182, HardY1 + 160) 'Print weekly Misc

        If dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(7) = 3 Then 'Show only if 3 years shown on payslip
            Text = lbl_VacaYear3.Text
            e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 520, HardY1 + 160) 'Print vacation year 3
            VacaDay3 = lbl_VacaIssued3.Text - lbl_VacaUsed3.Text
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(VacaDay3, Font).Width)
            e.Graphics.DrawString(VacaDay3, Font, BlackBrush, (HardX1 + 578) - TextLen, HardY1 + 160) 'Print vacation year 2 days left
        End If

        Text = FormatCurrency(NetPayment)
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 182, HardY1 + 180) 'Print Net Pay

        Text = VacaDay1 + VacaDay2 + VacaDay3
        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
        e.Graphics.DrawString(Text, Font, BlackBrush, (HardX1 + 578) - TextLen, HardY1 + SoftY) 'Print vacation days left

        Text = FormatCurrency(lbl_YearEarnings.Text + TotalPayment)
        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 100 - (TextLen / 2), HardY1 + 238) 'Print total year earnings

        Text = FormatCurrency(lbl_YearFederalTax.Text + FedTax)
        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 290 - (TextLen / 2), HardY1 + 238) 'Print total year federal taxes

        Text = FormatCurrency(lbl_YearStateTax.Text + StateTax)
        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 480 - (TextLen / 2), HardY1 + 238) 'Print total year state taxes

        Text = FormatCurrency(lbl_YearSocSecurity.Text + SocSecAmt)
        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 670 - (TextLen / 2), HardY1 + 238) 'Print total year social security payments

        'Fill middle form section with data
        Font = New Font("Ariel", 14, FontStyle.Bold)
        Text = LastCheck + 1  'Print check number
        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
        TextX = HardX2 - (65 + TextLen)
        e.Graphics.DrawString(Text, Font, BlackBrush, TextX, HardY1 + 354) 'HardY1 + 342)

        'Print date
        Font = New Font("Ariel", 9, FontStyle.Bold)
        Text = tbox_PayCheckDate.Text
        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 650 - (TextLen / 2), HardY1 + 427) '662

        Dim CheckWords As String = NumWords(Convert.ToString(NetPayment)) 'Convert check amount into words
        e.Graphics.DrawString(CheckWords, Font, BlackBrush, HardX1 + 40, HardY1 + 488)

        'Print amount (numeric)
        Text = FormatCurrency(NetPayment)
        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 710 - (TextLen / 2), HardY1 + 487) '722

        'Print payto line 1
        Text = lbl_FirstName.Text & " " & lbl_LastName.Text
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 65, HardY1 + 549)

        'Print payto line 1
        Text = lbl_Address.Text
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 65, HardY1 + 564)

        'Print payto line 1
        Text = lbl_City.Text & " " & lbl_State.Text & " " & lbl_ZipCode.Text
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 65, HardY1 + 579)

        'Fill lower form section with data
        Text = CompanyName 'Print company name
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 40, HardY1 + 708)

        Text = LastCheck + 1 'Print check number
        Font = New Font("Ariel", 9, FontStyle.Regular)
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 735, HardY1 + 708)

        e.Graphics.DrawString(PayPeriod, Font, BlackBrush, HardX1 + 560, HardY1 + 745) 'Print Payment Period
        e.Graphics.DrawString(Hours, Font, BlackBrush, HardX1 + 560, HardY1 + 760) 'Print Total Hours worked

        Text = FormatCurrency(TotalPayment)
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 560, HardY1 + 775) 'Print Total Pay amount

        Text = FormatCurrency(FedTax)
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 560, HardY1 + 790) 'Print Federal Tax amount

        Text = FormatCurrency(StateTax)
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 560, HardY1 + 805) 'Print State Tax

        Text = FormatCurrency(SocSecAmt)
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 560, HardY1 + 820) 'Print Social security payment

        Text = FormatCurrency(MiscAmt)
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 560, HardY1 + 835) 'Print Misc amount

        e.Graphics.DrawString(LastCheck + 1, Font, BlackBrush, HardX1 + 155, HardY1 + 855) 'Print Check number

        Text = FormatCurrency(NetPayment)
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 560, HardY1 + 855) 'Print Net Pay amount

        e.Graphics.DrawString(tbox_PayCheckDate.Text, Font, BlackBrush, HardX1 + 155, HardY1 + 870) 'Print Check Date

        Text = FormatCurrency(NetPayment) & "    " & CheckWords
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 155, HardY1 + 885) 'Print Check Amount ( Numerical & words )

        Text = lbl_FirstName.Text & " " & lbl_LastName.Text
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 155, HardY1 + 945) 'Print employees name

        e.Graphics.DrawString(lbl_Address.Text, Font, BlackBrush, HardX1 + 155, HardY1 + 960) 'Print employees street address

        Text = lbl_City.Text & " " & lbl_State.Text & " " & lbl_ZipCode.Text
        e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 155, HardY1 + 975) 'Print employees town, state, zipcode

        e.HasMorePages = False
    End Sub


    'All texbox  handlers
    Private Sub tbox_GotFocus(sender As Object, e As EventArgs) Handles tbox_SalaryTemp.GotFocus, tbox_WeekHoursTemp.GotFocus, tbox_WeekFedTaxTemp.GotFocus, tbox_WeekStateTaxTemp.GotFocus, tbox_WeekMiscTemp.GotFocus, tbox_SocSecWageLimit.GotFocus, tbox_SocSecPercent.GotFocus, tbox_MedicarePercent.GotFocus, tbox_PayCheckDate.GotFocus
        strInitEntry = Trim(sender.Text)
        sender.BackColor = (Color.FromArgb(255, 255, 192))
    End Sub
    Private Sub tbox_LostFocus(sender As Object, e As EventArgs) Handles tbox_SalaryTemp.LostFocus, tbox_WeekHoursTemp.LostFocus, tbox_WeekFedTaxTemp.LostFocus, tbox_WeekStateTaxTemp.LostFocus, tbox_WeekMiscTemp.LostFocus, tbox_SocSecWageLimit.LostFocus, tbox_SocSecPercent.LostFocus, tbox_MedicarePercent.LostFocus, tbox_PayCheckDate.LostFocus
        If tbox_SalaryTemp.ReadOnly = True Then sender.BackColor = Color.White : Exit Sub
        Select Case sender.Name
            Case "tbox_SalaryTemp", "tbox_WeekHoursTemp", "tbox_WeekFedTaxTemp", "tbox_WeekStateTaxTemp", "tbox_WeekMiscTemp", "tbox_SocSecWageLimit", "tbox_SocSecPercent", "tbox_MedicarePercent"
                If sender.Text <> "" Then
                    If Not IsNumeric(sender.Text) Then
                        tbox_SalaryTemp.ReadOnly = True
                        frm_Message.Text = "18:1:0:1:3:Invalid Entry --- Numerical entries are only allowed"
                        frm_Message.ShowDialog()
                        sender.text = ""
                        sender.Focus()
                        tbox_SalaryTemp.ReadOnly = False
                        Exit Sub
                    End If
                    If sender.text <= 0 Then tbox_SalaryTemp.ReadOnly = True : sender.text = "" : tbox_SalaryTemp.ReadOnly = False
                End If
                If sender.name = "tbox_SalaryTemp" Or sender.name = "tbox_WeekHoursTemp" Then
                    If tbox_SalaryTemp.Text <> "" Or tbox_WeekHoursTemp.Text <> "" Then Call Calculate_SocSecurity() Else lbl_WeekSocSecurityTemp.Text = ""
                End If
            Case "tbox_PayCheckDate"
                If IsDate(sender.Text) = False And sender.Text <> "  /  /" Then
                    sender.BackColor = Color.Aqua
                    tbox_SalaryTemp.ReadOnly = True
                    frm_Message.Text = "18:1:0:1:3:The date entered is not valid, Please enter a valid date"
                    frm_Message.ShowDialog()
                    sender.text = Format(Now.Date, "MM/dd/yyyy")
                    sender.Focus()
                    tbox_SalaryTemp.ReadOnly = False
                    Exit Sub
                End If
        End Select
        sender.BackColor = Color.White
    End Sub
    Private Sub tbox_TextChanged(sender As Object, e As EventArgs) Handles tbox_SalaryTemp.TextChanged, tbox_WeekHoursTemp.TextChanged, tbox_WeekFedTaxTemp.TextChanged, tbox_WeekStateTaxTemp.TextChanged, tbox_WeekMiscTemp.TextChanged, tbox_SocSecWageLimit.TextChanged, tbox_SocSecPercent.TextChanged, tbox_MedicarePercent.TextChanged
        If cmd_Action0.Text = "Restore" Then cmd_Action0.Enabled = True
        If cmd_Action1.Text = "Restore" Then cmd_Action1.Enabled = True
        If cmd_Action0.Text = "Restore" Or cmd_Action1.Text = "Restore" Then 'This keeps the exit button showing on initial startup
            cmd_Action3.Text = "Save"
            cmd_Action3.Image = My.Resources.Resources.Save
            cmd_Action3.Enabled = True
        End If
    End Sub
    Private Sub tbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbox_SalaryTemp.KeyPress, tbox_WeekHoursTemp.KeyPress, tbox_WeekFedTaxTemp.KeyPress, tbox_WeekStateTaxTemp.KeyPress, tbox_WeekMiscTemp.KeyPress, tbox_SocSecWageLimit.KeyPress, tbox_SocSecPercent.KeyPress, tbox_MedicarePercent.KeyPress, tbox_PayCheckDate.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            Select Case sender.Name
                Case "tbox_SalaryTemp" : tbox_WeekHoursTemp.Focus()
                Case "tbox_WeekHoursTemp" : tbox_WeekFedTaxTemp.Focus()
                Case "tbox_WeekFedTaxTemp" : tbox_WeekStateTaxTemp.Focus()
                Case "tbox_WeekStateTaxTemp" : tbox_WeekMiscTemp.Focus()
                Case "tbox_WeekMiscTemp" : tbox_SalaryTemp.Focus()
                Case "tbox_SocSecWageLimit" : tbox_SocSecPercent.Focus()
                Case "tbox_SocSecPercent" : tbox_MedicarePercent.Focus()
                Case "tbox_MedicarePercent" : tbox_SocSecWageLimit.Focus()
                Case "tbox_PayCheckDate" : DateTimePicker1.Focus()
            End Select
        End If
    End Sub


    'All mouse movement and mouse over messages
    Private Sub ListBox1_MouseEnter() Handles ListBox1.MouseEnter
        ListBox1.Focus()
    End Sub
    Private Sub fra_MouseMove(sender As Object, e As EventArgs) Handles fra_List.MouseMove, fra_Contacts.MouseMove, fra_ContactInfo.MouseMove, fra_Income.MouseMove, fra_SocSecurityLimits.MouseMove, fra_PrintPaychecks.MouseMove 'Clear message
        If sender.name = "fra_Income" Then intMessage = 23 Else intMessage = 0
        Call MouseMessages()
    End Sub
    Private Sub tbox_MouseHover(sender As Object, e As EventArgs) Handles ListBox1.MouseHover, tbox_SalaryTemp.MouseHover, tbox_WeekHoursTemp.MouseHover, tbox_WeekFedTaxTemp.MouseHover, tbox_WeekStateTaxTemp.MouseHover, lbl_WeekSocSecurityTemp.MouseHover, tbox_WeekMiscTemp.MouseHover, cmd_ClearAdjustments.MouseHover, cmd_Action0.MouseHover, tbox_SocSecWageLimit.MouseHover, tbox_SocSecPercent.MouseHover, tbox_MedicarePercent.MouseHover, cmd_Action1.MouseHover, cmd_PrintAll.MouseHover, cmd_PrintIndividual.MouseHover, tbox_PayCheckDate.MouseHover, DateTimePicker1.MouseHover, lbl_YearEarnings.MouseHover, lbl_YearFederalTax.MouseHover, lbl_YearStateTax.MouseHover, lbl_YearSocSecurity.MouseHover, lbl_YearMisc.MouseHover
        Select Case sender.name
            Case "ListBox1" : intMessage = 1
            Case "tbox_SalaryTemp" : intMessage = 2
            Case "tbox_WeekHoursTemp" : intMessage = 3
            Case "tbox_WeekFedTaxTemp" : intMessage = 4
            Case "tbox_WeekStateTaxTemp" : intMessage = 5
            Case "lbl_WeekSocSecurityTemp" : intMessage = 6
            Case "tbox_WeekMiscTemp" : intMessage = 7
            Case "cmd_ClearAdjustments" : intMessage = 8
            Case "cmd_Action0" : intMessage = 9
            Case "tbox_SocSecWageLimit" : intMessage = 10
            Case "tbox_SocSecPercent" : intMessage = 11
            Case "tbox_MedicarePercent" : intMessage = 12
            Case "cmd_Action1" : intMessage = 13
            Case "cmd_PrintAll" : intMessage = 14
            Case "cmd_PrintIndividual" : intMessage = 15
            Case "tbox_PayCheckDate" : intMessage = 16
            Case "DateTimePicker1" : intMessage = 17
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
            Case 1 : lbl_Message.Text = "Select employee's name from list to view or edit employees paycheck data"
            Case 2 : lbl_Message.Text = "Enter any temporary change to this employees salary if needed"
            Case 3 : lbl_Message.Text = "Enter any temporary change to the amount of hours this employee worked"
            Case 4 : lbl_Message.Text = "Enter the temporary amount of Federal taxes removed from this weeks paycheck"
            Case 5 : lbl_Message.Text = "Enter the temporary amount of State taxes removed from this weeks paycheck"
            Case 6 : lbl_Message.Text = "Calculated temporary Social Security and Medicare payments for this paycheck"
            Case 7 : lbl_Message.Text = "Enter the temporary amount of Misc Deductions removed from this weeks paycheck"
            Case 8 : lbl_Message.Text = "Press this button to remove any temporary saved changes"
            Case 9 : lbl_Message.Text = "Press this button to add or edit any temporary changes to this employee"
            Case 10 : lbl_Message.Text = "Enter the Social Security wage base limit"
            Case 11 : lbl_Message.Text = "Enter the Percentage of tax withheld on Social Security"
            Case 12 : lbl_Message.Text = "Enter the Percentage of tax withheld on Medicare"
            Case 13 : lbl_Message.Text = "Press this button to edit any Social Security or Medicare changes"
            Case 14 : lbl_Message.Text = "Press this button to print all employees paychecks"
            Case 15 : lbl_Message.Text = "Press this button to print only this employees paycheck"
            Case 16 : lbl_Message.Text = "Enter the date which you want printed on the paycheck"
            Case 17 : lbl_Message.Text = "Press this to open a calendar to help select Paycheck date"
            Case 18 : lbl_Message.Text = "Total of all earning for the year " & Year(Now.Date)
            Case 19 : lbl_Message.Text = "Total of all Federal tax payments made for the year " & Year(Now.Date)
            Case 20 : lbl_Message.Text = "Total of all State tax payments made for the year " & Year(Now.Date)
            Case 21 : lbl_Message.Text = "Total of all Social Security and Medicare payments made for the year " & Year(Now.Date)
            Case 22 : lbl_Message.Text = "Total of all Miscellaneous deductions made in the year " & Year(Now.Date)
            Case 23 : lbl_Message.Text = "Enter only the changes needed in the temporary edits, all textboxes do not need to be filled"
        End Select
    End Sub

End Class