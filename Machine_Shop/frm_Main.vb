Imports System.Windows.Forms

Public Class frm_Main

    Dim dbAdapter, dbAdapter_SystemData, dbAdapter_Misc As OleDb.OleDbDataAdapter
    Dim dbDataSet, dbDataSet_SystemData, dbDataSet_Misc As New DataSet

    Private m_ChildFormNumber As Integer
    Dim strSQL As String

    Private Sub frm_Load(sender As Object, e As EventArgs) Handles Me.Load

        'Connect to database
        Call DbConnection()

        'Test for system setup initialized     
        strSQL = "SELECT SetupLogon,CompanyName,CompanyAddress,CompanyCity,CompanyState,CompanyZipCode,CompanyPhone,CompanyEmail," _
               & "ShipVia,Terms,DiscountDays,DiscountAmount,DueDays,LastInvoice,Agent1,CheckbookStartBalance,CheckbookLastCheck," _
               & "SocSecLimit,SocSecPercent,MedicarePercent,VacaWaitPeriod,VacaStart,VacaAddDays,VacaStop,VacaTrackYears," _
               & "SystemPrinter,Buffer,ImageWidth,ImageHeight,NewYear,BackupPath,Id FROM System;"
        dbDataSet_SystemData.Clear()
        dbDataSet_SystemData.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter_SystemData = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter_SystemData.Fill(dbDataSet_SystemData, "System")
        gbl_DstConnect.Close()
        Dim booInitialized As Boolean = True
        Dim varhold As Object
        For i = 1 To 29
            varhold = dbDataSet_SystemData.Tables("System").Rows(0).Item(i)
            Select Case VarType(varhold)
                Case VariantType.String : If varhold = "" Then booInitialized = False : Exit For
                Case Else : If IsDBNull(varhold) Then booInitialized = False : Exit For
            End Select
        Next

        'Test for tax categories complete
        If booInitialized = True Then
            strSQL = "Select Category from TaxCategorys"
            dbDataSet_Misc.Clear()
            dbDataSet_Misc.Tables.Clear()
            gbl_DstConnect.Open()
            dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
            dbAdapter_Misc.Fill(dbDataSet_Misc, "TaxCategorys")
            gbl_DstConnect.Close()

            For i = 0 To 17
                varhold = dbDataSet_Misc.Tables("TaxCategorys").Rows(i).Item(0)
                If IsDBNull(varhold) Then booInitialized = False : Exit For
            Next
        End If

        If booInitialized = True Then 'System initialized (yes)

            'Test for autologon
            strSQL = "Select UserPassword From Users ORDER BY Id;"
            dbDataSet.Clear()
            dbDataSet.Tables.Clear()
            gbl_DstConnect.Open()
            dbAdapter = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
            dbAdapter.Fill(dbDataSet, "AutoLogon")
            gbl_DstConnect.Close()

            If dbDataSet.Tables("AutoLogon").Rows(0).Item(0) = "AutoLogonYes" Then  'Autologon (yes)
                AutoLogon.Checked = True
                Dim FormTitle As String = Replace(dbDataSet_SystemData.Tables("System").Rows(0).Item(1), "&&", "&")
                Me.Text = FormTitle
            Else 'Autologon (no)
                frm_Logon.ShowDialog()
            End If

            Call Menu_Validate() 'Check for neccesary files need for specific programs ( Menus )
            If Now.Date >= dbDataSet_SystemData.Tables("System").Rows(0).Item(29).AddYears(1) Then Call NewYear() 'New year reached 

        Else 'System initialized (no)
            frm_Message.Text = "0:1:1:1:2:System must be Initialized before entry into program will be allowed"
            frm_Message.ShowDialog()
            Call frm_SystemSetup.ShowDialog()
            Call Menu_Validate()
        End If

    End Sub
    Private Sub Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call Close_Form()
    End Sub
    Private Sub Close_Form()
        dbDataSet.Clear()
        dbDataSet.Tables.Clear()
        dbAdapter = Nothing
        dbDataSet = Nothing
    End Sub
    Private Sub NewYear()

        'Reset employee's totals for new year
        strSQL = "SELECT PayTotal,FedTaxTotal,StateTaxTotal,SocSecTotal,MiscTotal,Id FROM Employees Where Active = True;"
        dbDataSet.Clear()
        dbDataSet.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter.Fill(dbDataSet, "EmployeeNewYear")
        gbl_DstConnect.Close()
        If dbDataSet.Tables("EmployeeNewYear").Rows.Count <> 0 Then
            For i = 0 To dbDataSet.Tables("EmployeeNewYear").Rows.Count - 1
                Dim cb0 As New OleDb.OleDbCommandBuilder(dbAdapter)
                dbDataSet.Tables("EmployeeNewYear").Rows(i).Item(0) = 0
                dbDataSet.Tables("EmployeeNewYear").Rows(i).Item(1) = 0
                dbDataSet.Tables("EmployeeNewYear").Rows(i).Item(2) = 0
                dbDataSet.Tables("EmployeeNewYear").Rows(i).Item(3) = 0
                dbDataSet.Tables("EmployeeNewYear").Rows(i).Item(4) = 0
                dbAdapter.Update(dbDataSet, "EmployeeNewYear")
                cb0 = Nothing
            Next
        End If

        'Reset system new year
        Dim cb1 As New OleDb.OleDbCommandBuilder(dbAdapter_SystemData)
        dbDataSet_SystemData.Tables("System").Rows(0).Item(29) = dbDataSet_SystemData.Tables("System").Rows(0).Item(29).AddYears(1)
        dbAdapter_SystemData.Update(dbDataSet_SystemData, "System")
        cb1 = Nothing

    End Sub

    'File tab
    Private Sub ExitToolsStripMenuItem_Click() Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub BackupToolStripMenuItem_Click() Handles BackUpToolStripMenuItem.Click
        frm_Backup.ShowDialog()
    End Sub

    'Employee tab
    Private Sub EmployeeInformationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmployeeInformationToolStripMenuItem.Click
        frm_Employees.ShowDialog()
    End Sub
    Private Sub EmployeeDirectoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmployeeDirectoryToolStripMenuItem.Click
        frm_EmployeeDirectory.ShowDialog()
    End Sub
    Private Sub EmployeeReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmployeeReportToolStripMenuItem.Click
        ' frm_EmployeeReport.ShowDialog()
    End Sub

    'Customer tab
    Private Sub CustomerInformationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomerInformationToolStripMenuItem.Click
        frm_Customer.ShowDialog()
    End Sub
    Private Sub CustomersDirectoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomerDirectoryToolStripMenuItem.Click
        frm_CustomerDirectory.ShowDialog()
    End Sub
    Private Sub CustomersReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomerReportToolStripMenuItem.Click
        ' frm_CustomerReport.ShowDialog()
    End Sub

    'Schedule tab
    Private Sub ScheduleToolStripMenuItem_Click() Handles WorkSchedule_Menu.Click
        frm_WorkEditSchedule.ShowDialog()
    End Sub

    'Income tab
    Private Sub POToolStripMenuItem_Click() Handles POToolStripMenuItem.Click
        frm_PurchaseOrders.ShowDialog()
    End Sub
    Private Sub InvoiceOrdersToolStripMenuItem_Click() Handles InvoiceOrdersToolStripMenuItem.Click
        frm_InvoiceOrder.ShowDialog()
    End Sub
    Private Sub InvoiceSearchToolStripMenuItem_Click() Handles InvoiceSearchToolStripMenuItem.Click
        frm_InvoiceSearch.ShowDialog()
    End Sub
    Private Sub InvoicePaidToolStripMenuItem_Click() Handles InvoicePaidToolStripMenuItem.Click
        frm_InvoicePaid.ShowDialog()
    End Sub
    Private Sub InvoiceReInvoiceToolStripMenuItem_Click() Handles InvoiceReInvoiceToolStripMenuItem.Click
        frm_InvoiceReorder.ShowDialog()
    End Sub
    Private Sub InvoicePaymentToolStripMenuItem_Click() Handles InvoicePaymentToolStripMenuItem.Click
        frm_PaymentSchedule.ShowDialog()
    End Sub
    Private Sub DrawingHistoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DrawingHistoryToolStripMenuItem.Click
        frm_DrawingHistory.ShowDialog()
    End Sub

    'Banking
    Private Sub Banking_Menu_Click(sender As Object, e As EventArgs) Handles Banking_Menu.Click
        frm_Checkbook.ShowDialog()
    End Sub

    'Payroll tab
    Private Sub PayrollToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Payroll_Menu.Click
        frm_Payroll.ShowDialog()
    End Sub

    'Inventory tab
    Private Sub Inventory_Menu_Click(sender As Object, e As EventArgs) Handles Inventory_Menu.Click
        frm_Inventory.ShowDialog()
    End Sub

    'List tab
    Private Sub PayeeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PayeeToolStripMenuItem.Click
        frm_PayeeEditor.ShowDialog()
    End Sub  

    'System setup tab
    Private Sub SystemSetupToolStripMenuItem_Click() Handles SystemSetupToolStripMenuItem.Click

        strSQL = "SELECT SetupLogon From System;"
        dbDataSet.Clear()
        dbDataSet.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter.Fill(dbDataSet, "SetupLogon")
        gbl_DstConnect.Close()

        'Check if logon established to enter setup form
        If dbDataSet.Tables("SetupLogon").Rows(0).Item(0) = True Then
            frm_Logon.Text = "                       Logon to enter System Setup"
            frm_Logon.ShowDialog()
        Else : frm_SystemSetup.ShowDialog() : End If

    End Sub

    'Logon tab
    Private Sub LogonOptionsToolStripMenuItem_Click() Handles LogonOptionsToolStripMenuItem.Click

        'Test for userId and password protection
        strSQL = "SELECT * From Users;"
        dbDataSet.Clear()
        dbDataSet.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter.Fill(dbDataSet, "Users")
        gbl_DstConnect.Close()

        'Check if logon established to enter logon editor
        If dbDataSet.Tables("Users").Rows.Count >= 3 Then 'Valid userId and password found
            frm_Logon.Text = "                        Logon to enter logon editor"
            frm_Logon.ShowDialog()
        Else : frm_LogonEdit.ShowDialog() : End If

    End Sub

    'Misc
    Private Sub cmd_FixDrawingRev_Click(sender As Object, e As EventArgs) Handles cmd_FixDrawingRev.Click 'Use this button to extract rev from custcode 7 and move it to collumn DrawingRevision

        Dim strOld, strDrawing, strRev As String
        Dim intTotalLenght, intSpace As Integer
        Dim intNum As Integer = 7
        strSQL = "SELECT ID,DrawingNumber,DrawingRevision FROM Invoice Where CustCode = " & intNum & ";"
        dbDataSet_Misc.Clear()
        dbDataSet_Misc.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter_Misc.Fill(dbDataSet_Misc, "Rev")
        gbl_DstConnect.Close()
        If dbDataSet_Misc.Tables("Rev").Rows.Count <> 0 Then
            For i = 0 To dbDataSet_Misc.Tables("Rev").Rows.Count - 1
                If Not IsDBNull(dbDataSet_Misc.Tables("Rev").Rows(i).Item(1)) Then 'Drawing Number
                    strOld = Trim(dbDataSet_Misc.Tables("Rev").Rows(i).Item(1))
                Else : strOld = "" : End If

                If strOld <> "" Then
                    intTotalLenght = Len(strOld)
                    intSpace = InStrRev(strOld, " ")
                    If intTotalLenght - intSpace <= 2 Then 'Seperate rev found
                        strDrawing = Microsoft.VisualBasic.Left(strOld, intSpace - 1)
                        strRev = Microsoft.VisualBasic.Right(strOld, intTotalLenght - intSpace)
                        Dim cb0 As New OleDb.OleDbCommandBuilder(dbAdapter_Misc)
                        dbDataSet_Misc.Tables("Rev").Rows(i).Item(1) = Trim(strDrawing)
                        dbDataSet_Misc.Tables("Rev").Rows(i).Item(2) = Trim(strRev)
                        dbAdapter_Misc.Update(dbDataSet_Misc, "Rev")
                    End If
                End If
                cmd_FixDrawingRev.Text = i
            Next

            cmd_FixDrawingRev.Text = "Finished"
        End If
    End Sub
End Class
