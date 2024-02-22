Module Module1

    'Global Variables
    Public gbl_SqlConnect As OleDbConnection = New OleDbConnection
    Public gbl_DstConnect As New OleDb.OleDbConnection

    Public MessageResult As Boolean 'Used to return message results
    Public gbl_dbPath As String 'Variable to hold company name, and database path
    Public gbl_StringName As String 'Variable to transfer printer/path name from printer/path dialog boxes
    Public Sub DbConnection()

        Dim dbProvider, dbSource As String
        Try
            gbl_dbPath = Left(Application.StartupPath, Len(Application.StartupPath) - 9) & "\DataBase\Database.Mdb"
            dbProvider = "Provider=Microsoft.Jet.OLEDB.4.0;"
            dbSource = "Data Source =" & gbl_dbPath
            gbl_DstConnect.ConnectionString = dbProvider & dbSource
            gbl_SqlConnect.ConnectionString = dbProvider & dbSource
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Sub Menu_Validate()
        Dim dbAdapter As OleDb.OleDbDataAdapter
        Dim dbDataSet As New DataSet
        Dim strSql As String

        'Test for Employees on record
        strSql = "SELECT LastName FROM Employees"
        dbDataSet.Clear()
        dbDataSet.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter.Fill(dbDataSet, "EmployeeCheck")
        gbl_DstConnect.Close()
        If dbDataSet.Tables("EmployeeCheck").Rows.Count = 0 Then Call EnableMenus(0, False) 'Disable all employee related menus

        'Test for Customers on record
        strSql = "SELECT Company FROM Customers"
        dbDataSet.Clear()
        dbDataSet.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter = New OleDb.OleDbDataAdapter(strSql, gbl_DstConnect)
        dbAdapter.Fill(dbDataSet, "CustomerCheck")
        gbl_DstConnect.Close()
        If dbDataSet.Tables("CustomerCheck").Rows.Count = 0 Then Call EnableMenus(1, False) 'Disable all customer related menus

    End Sub
    Public Sub EnableMenus(intSelect As Integer, blnStatus As Boolean)
        Select Case intSelect
            Case 0
                frm_Main.EmployeeDirectoryToolStripMenuItem.Enabled = blnStatus
                frm_Main.EmployeeReportToolStripMenuItem.Enabled = blnStatus
                frm_Main.Payroll_Menu.Enabled = blnStatus
            Case 1
                frm_Main.CustomerDirectoryToolStripMenuItem.Enabled = blnStatus
                frm_Main.CustomerReportToolStripMenuItem.Enabled = blnStatus
                frm_Main.WorkSchedule_Menu.Enabled = blnStatus
                frm_Main.Income_Menu.Enabled = blnStatus
                frm_Main.Inventory_Menu.Enabled = blnStatus
        End Select
    End Sub
    Public Function NumWords(ByVal nAmount As String, Optional ByVal wAmount As String = vbNullString, Optional ByVal nSet As Object = Nothing) As String

        'Let's make sure entered value is numeric
        If Not IsNumeric(nAmount) Then Return "Please enter numeric values only."

        Dim tempDecValue As String = String.Empty
        If InStr(nAmount, ".") Then tempDecValue = nAmount.Substring(nAmount.IndexOf("."))
        nAmount = Replace(nAmount, tempDecValue, String.Empty)

        Try
            Dim intAmount As Long = nAmount
            If intAmount > 0 Then
                nSet = IIf((intAmount.ToString.Trim.Length / 3) > (CLng(intAmount.ToString.Trim.Length / 3)), CLng(intAmount.ToString.Trim.Length / 3) + 1, CLng(intAmount.ToString.Trim.Length / 3))
                Dim eAmount As Long = Microsoft.VisualBasic.Left(intAmount.ToString.Trim, (intAmount.ToString.Trim.Length - ((nSet - 1) * 3)))
                Dim multiplier As Long = 10 ^ (((nSet - 1) * 3))

                Dim Ones() As String = {"", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine"}
                Dim Teens() As String = {"", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"}
                Dim Tens() As String = {"", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"}
                Dim HMBT() As String = {"", "", "Thousand", "Million", "Billion", "Trillion", "Quadrillion", "Quintillion"}

                intAmount = eAmount

                Dim nHundred As Integer = intAmount \ 100
                intAmount = intAmount Mod 100
                Dim nTen As Integer = intAmount \ 10
                intAmount = intAmount Mod 10
                Dim nOne As Integer = intAmount \ 1

                If nHundred > 0 Then wAmount = wAmount & Ones(nHundred) & " Hundred " 'This is for hundreds                
                If nTen > 0 Then 'This is for tens and teens
                    If nTen = 1 And nOne > 0 Then 'This is for teens 
                        wAmount = wAmount & Teens(nOne) & " "
                    Else 'This is for tens, 10 to 90
                        wAmount = wAmount & Tens(nTen) & IIf(nOne > 0, "-", " ")
                        If nOne > 0 Then wAmount = wAmount & Ones(nOne) & " "
                    End If
                Else 'This is for ones, 1 to 9
                    If nOne > 0 Then wAmount = wAmount & Ones(nOne) & " "
                End If
                wAmount = wAmount & HMBT(nSet) & " "
                wAmount = NumWords(CStr(CLng(nAmount) - (eAmount * multiplier)).Trim & tempDecValue, wAmount, nSet - 1)
            Else
                If InStr(tempDecValue, ".") Then
                    tempDecValue = tempDecValue.Substring(tempDecValue.IndexOf(".") + 1)
                    If Len(tempDecValue) = 1 Then tempDecValue = tempDecValue & "0"
                Else : tempDecValue = "00" : End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error Encountered: " & ex.Message, "Convert Numbers To Words", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return "!#ERROR_ENCOUNTERED"
        End Try

        'Trap null values
        If IsNothing(wAmount) = True Then wAmount = "Zero"
        wAmount = IIf(InStr(wAmount.Trim.ToLower, "dollars"), wAmount.Trim, wAmount.Trim & " & " & tempDecValue & "/100 Dollars")
        Return wAmount
    End Function
    Public Function AlphaNumeric(strInputText As String) As Boolean
        Dim intCounter As Integer
        Dim strCompare, strInput As String
        AlphaNumeric = False
        For intCounter = 1 To Len(strInputText)
            strCompare = Mid$(strInputText, intCounter, 1)
            strInput = Mid$(strInputText, intCounter + 1, Len(strInputText))
            If strCompare Like ("[A-Z]") Or strCompare Like ("[a-z]") Then AlphaNumeric = True Else AlphaNumeric = False : Exit Function
        Next intCounter
    End Function
    Public Function DefaultPrinterName() As String
        Dim oPS As New System.Drawing.Printing.PrinterSettings

        Try
            DefaultPrinterName = oPS.PrinterName
        Catch ex As System.Exception
            DefaultPrinterName = ""
        Finally
            oPS = Nothing
        End Try
    End Function

End Module