Imports System.Drawing.Printing
Public Class frm_EmployeeDirectory

    'Database related
    Dim dbAdapter, dbAdapter_SystemData As OleDb.OleDbDataAdapter
    Dim dbDataSet, dbDataSet_SystemData As New DataSet
    Dim strSQL As String

    'Form controls related
    Dim lbl_LastName(1) As Label
    Dim lbl_FirstName(1) As Label
    Dim lbl_Address(1) As Label
    Dim lbl_City(1) As Label
    Dim lbl_State(1) As Label
    Dim lbl_Phone(1) As Label
    Dim lbl_EmergencyPhone(1) As Label

    'Data related
    Dim DataArray(1, 6) As Object 'Array to hold all data
    Dim RecordCount, DueDays, D_Page As Integer ' D_Page = Display page number

    'Print Related
    Private WithEvents PrintForms As PrintDocument
    Declare Function GetDeviceCaps% Lib "GDI32" (ByVal hDC%, ByVal nIndex%)
    Private Buffer, Pages, P_Page, P_Line As Integer 'Pages = total pages needed to print report, P_Page = print page number, P_Line is print item row number
    Private SystemPrinter As String
    Private brush As Brush
    Private BlackBrush As New SolidBrush(Color.Black)
    Private FlagBrush As New SolidBrush(Color.Brown)

    Private Sub frm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Me.Location = New Point((Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2, frm_Main.Top + 70)

        strSQL = "SELECT LastName,FirstName,Address,City,State,Phone,Emergency FROM Employees ORDER BY LastName;"
        dbDataSet.Clear()
        dbDataSet.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter.Fill(dbDataSet, "Data")
        gbl_DstConnect.Close()
        RecordCount = dbDataSet.Tables("Data").Rows.Count()
        ReDim DataArray(RecordCount, 6)

        If RecordCount = 0 Then
            frm_Message.Text = "20:1:0:1:3:There are employees on record to show"
            frm_Message.ShowDialog()
            Me.Close()
            Exit Sub
        End If

        If RecordCount <= 40 Then
            cmd_PrintAll.Visible = False
            cmd_Exit.Top = 77
            fra_SearchCriteria.Height = 140
            fra_Pages.Visible = False
            lbl_Page.Visible = False
        End If

        'Retrieve system variables
        strSQL = "SELECT CompanyName,SystemPrinter,Buffer FROM System;"
        dbDataSet_SystemData.Clear()
        dbDataSet_SystemData.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter_SystemData = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter_SystemData.Fill(dbDataSet_SystemData, "SystemData")
        gbl_DstConnect.Close()
        If dbDataSet_SystemData.Tables("SystemData").Rows.Count = 1 Then
            Label_Company.Text = Replace(dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(0), "&", "&&") 'Company Name 
            SystemPrinter = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(1) 'System printer name
            Buffer = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(2) 'Printer buffer
        End If
        Label_HeaderDates.Text = Now.Date 'Header dates

        Call ArrayFill()
        Call AddControls()
        D_Page = 1
        Call FormFill()
    End Sub
    Private Sub Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        dbDataSet.Clear()
        dbDataSet.Tables.Clear()
        dbDataSet_SystemData.Clear()
        dbDataSet_SystemData.Tables.Clear()
        Me.Dispose()
    End Sub
    Private Sub AddControls() 'Add date and quantity controls

        Dim int_Top, i, Count As Integer
        count = Math.Min(RecordCount - 1, 39)

        ReDim lbl_LastName(Count)
        ReDim lbl_FirstName(Count)
        ReDim lbl_Address(Count)
        ReDim lbl_City(Count)
        ReDim lbl_State(Count)
        ReDim lbl_Phone(Count)
        ReDim lbl_EmergencyPhone(Count)


        'Create array of controls in frame information
        int_Top = 168

        For i = 0 To Count
            int_Top = int_Top + 16
            lbl_LastName(i) = New Label
            lbl_FirstName(i) = New Label
            lbl_Address(i) = New Label
            lbl_City(i) = New Label
            lbl_State(i) = New Label
            lbl_Phone(i) = New Label
            lbl_EmergencyPhone(i) = New Label

            With lbl_LastName(i)
                .Name = "lbl_Lastname"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(16, int_Top, 124, 15)
                fra_EmployeeDirectory.Controls.Add(lbl_LastName(i))
            End With

            With lbl_FirstName(i)
                .Name = "lbl_Firstname"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(141, int_Top, 124, 15)
                fra_EmployeeDirectory.Controls.Add(lbl_FirstName(i))
            End With


            With lbl_Address(i)
                .Name = "lbl_Address"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(266, int_Top, 190, 15)
                fra_EmployeeDirectory.Controls.Add(lbl_Address(i))
            End With

            With lbl_City(i)
                .Name = "lbl_City"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(457, int_Top, 80, 15)
                fra_EmployeeDirectory.Controls.Add(lbl_City(i))
            End With

            With lbl_State(i)
                .Name = "lbl_State"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(538, int_Top, 40, 15)
                fra_EmployeeDirectory.Controls.Add(lbl_State(i))
            End With

            With lbl_Phone(i)
                .Name = "lbl_Phone"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(579, int_Top, 94, 15)
                fra_EmployeeDirectory.Controls.Add(lbl_Phone(i))
            End With

            With lbl_EmergencyPhone(i)
                .Name = "lbl_EmergencyPhone"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(674, int_Top, 94, 15)
                fra_EmployeeDirectory.Controls.Add(lbl_EmergencyPhone(i))
            End With
        Next
    End Sub
    Private Sub ArrayFill() 'Fill Array with data   

        For intStep = 0 To RecordCount - 1
            If Not IsDBNull(dbDataSet.Tables("Data").Rows(intStep).Item(0)) Then 'last Name
                DataArray(intStep, 0) = StrConv(LCase(Trim(dbDataSet.Tables("Data").Rows(intStep).Item(0))), VbStrConv.ProperCase)
            Else : DataArray(intStep, 0) = "" : End If

            If Not IsDBNull(dbDataSet.Tables("Data").Rows(intStep).Item(1)) Then 'First Name
                DataArray(intStep, 1) = StrConv(LCase(Trim(dbDataSet.Tables("Data").Rows(intStep).Item(1))), VbStrConv.ProperCase)
            Else : DataArray(intStep, 1) = "" : End If

            If Not IsDBNull(dbDataSet.Tables("Data").Rows(intStep).Item(2)) Then 'Street Adress
                DataArray(intStep, 2) = Trim(dbDataSet.Tables("Data").Rows(intStep).Item(2))
            Else : DataArray(intStep, 2) = "" : End If

            If Not IsDBNull(dbDataSet.Tables("Data").Rows(intStep).Item(3)) Then 'City
                DataArray(intStep, 3) = StrConv(LCase(Trim(dbDataSet.Tables("Data").Rows(intStep).Item(3))), VbStrConv.ProperCase)
            Else : DataArray(intStep, 3) = "" : End If

            If Not IsDBNull(dbDataSet.Tables("Data").Rows(intStep).Item(4)) Then 'State
                DataArray(intStep, 4) = StrConv(LCase(Trim(dbDataSet.Tables("Data").Rows(intStep).Item(4))), VbStrConv.ProperCase)
            Else : DataArray(intStep, 4) = "" : End If

            If Not IsDBNull(dbDataSet.Tables("Data").Rows(intStep).Item(5)) Then 'Contact Phone Number
                DataArray(intStep, 5) = Trim(dbDataSet.Tables("Data").Rows(intStep).Item(5))
            Else : DataArray(intStep, 5) = "" : End If

            If Not IsDBNull(dbDataSet.Tables("Data").Rows(intStep).Item(6)) Then 'EmergencyPhone Number
                DataArray(intStep, 6) = Trim(dbDataSet.Tables("Data").Rows(intStep).Item(6))
            Else : DataArray(intStep, 6) = "" : End If

        Next
    End Sub
    Private Sub FormFill() 'Fill form with data pertaining to listbox selection

        Dim Row As Integer = (D_Page - 1) * 40
        Dim intStep As Integer

        'Form fill data
        lbl_Page.Text = "Page " & D_Page
        For intStep = 0 To 39
            lbl_LastName(intStep).Text = DataArray(Row, 0)
            lbl_FirstName(intStep).Text = DataArray(Row, 1)
            lbl_Address(intStep).Text = DataArray(Row, 2)
            lbl_City(intStep).Text = DataArray(Row, 3)
            lbl_State(intStep).Text = DataArray(Row, 4)
            lbl_Phone(intStep).Text = DataArray(Row, 5)
            lbl_EmergencyPhone(intStep).Text = DataArray(Row, 6)
            If Row = RecordCount - 1 Then Exit For
            Row = Row + 1
        Next

        'Clear remaining rows on not full page
        If intStep < 39 And RecordCount > 40 Then
            Dim intStep1 As Integer = intStep + 1
            For intStep = intStep1 To 39
                lbl_LastName(intStep).Text = ""
                lbl_FirstName(intStep).Text = ""
                lbl_Address(intStep).Text = ""
                lbl_City(intStep).Text = ""
                lbl_State(intStep).Text = ""
                lbl_Phone(intStep).Text = ""
                lbl_EmergencyPhone(intStep).Text = ""
            Next
        End If

    End Sub
    Private Sub cmd_Click(sender As Object, e As EventArgs) Handles cmd_Print.Click, cmd_PrintAll.Click, cmd_Exit.Click, cmd_Next.Click, cmd_Previous.Click
        Select Case sender.name
            Case "cmd_Exit"
                Me.Close()
                Exit Sub

            Case "cmd_Print"
                Pages = 1 'Print only one page ( current page )
                P_Page = D_Page
                P_Line = (P_Page - 1) * 40
                PrintForms = New PrintDocument
                PrintForms.PrinterSettings.PrinterName = SystemPrinter
                PrintForms.Print()

            Case "cmd_PrintAll"
                Pages = Math.Ceiling(RecordCount / 40) 'Print all pages ( Total of pages needed )
                P_Page = 1
                P_Line = 0
                PrintForms = New PrintDocument
                PrintForms.PrinterSettings.PrinterName = SystemPrinter
                PrintForms.Print()

            Case "cmd_Next"
                D_Page = D_Page + 1
                If D_Page * 40 >= RecordCount Then cmd_Next.Enabled = False
                If D_Page > 1 Then cmd_Previous.Enabled = True
                Call FormFill()

            Case "cmd_Previous"
                D_Page = D_Page - 1
                If D_Page = 1 Then cmd_Previous.Enabled = False
                cmd_Next.Enabled = True
                Call FormFill()
        End Select
    End Sub
    Private Sub PrintForms_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintForms.PrintPage

        'Setup hard margins for printer
        Dim hDC As IntPtr = e.Graphics.GetHdc()
        Dim CurrentX, CurrentY, TextX, TextY, TextLen As Integer
        Dim HardX1, HardX2, HardY1, HardY2, HardWidth, HardHeight As Integer
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
        HardWidth = e.PageBounds.Width - Buffer
        HardHeight = e.PageBounds.Height - Buffer
        HardY2 = HardY1 + (e.PageBounds.Height - Buffer)
        CurrentX = HardX1
        CurrentY = HardY1

        'Draw Invoice form
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit

        Font = New Font("Swis721 BlkOul BT", 21, FontStyle.Regular) 'Print title Employee List
        e.Graphics.DrawString("Employee List", Font, BlackBrush, HardX1 + 281, HardY1 + 24)

        Font = New Font("Ariel", 18, FontStyle.Regular) 'Print Workschedule Dates
        Text = Label_HeaderDates.Text
        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
        TextX = HardX1 + (HardWidth - TextLen) / 2
        e.Graphics.DrawString(Text, Font, BlackBrush, TextX, HardY1 + 107)

        'Print Lower form graphics
        Font = New Font("Arial", 9, FontStyle.Bold)
        Using the_pen As New Pen(Color.Black, 1)
            points = {New Point(HardX1, HardY1), New Point(HardX2, HardY1), New Point(HardX2, HardY2), New Point(HardX1, HardY2)} 'Outside rectangle
            e.Graphics.DrawPolygon(the_pen, points)

            points = {New Point(HardX1, HardY1 + 187), New Point(HardX2, HardY1 + 187)} '1st horzontal Line
            e.Graphics.DrawLines(the_pen, points)

            CurrentY = HardY1 + 190
            points = {New Point(HardX1, CurrentY), New Point(HardX2, CurrentY)} '2nd horzontal Line
            e.Graphics.DrawLines(the_pen, points)

            Text = "Last Name"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = HardX1 + (132 - TextLen) / 2
            TextY = CurrentY + 16
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY) 'Print label Last Name

            CurrentX = HardX1 + 132
            points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 862)} '1st upper vertical line
            e.Graphics.DrawLines(the_pen, points)

            Text = "First Name"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (132 - TextLen) / 2
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY) 'Print label First Name

            CurrentX = HardX1 + 264
            points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 862)} '2nd upper vertical line
            e.Graphics.DrawLines(the_pen, points)

            Text = "Street Address"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (203 - TextLen) / 2
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY) 'Print label Street Address

            CurrentX = HardX1 + 467
            points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 862)} '3rd upper vertical line
            e.Graphics.DrawLines(the_pen, points)

            Text = "City"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (87 - TextLen) / 2
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY) 'Print label City

            CurrentX = HardX1 + 554
            points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 862)} '3rd upper vertical line
            e.Graphics.DrawLines(the_pen, points)

            Text = "State"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (44 - TextLen) / 2
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY) 'Print label State

            CurrentX = HardX1 + 598
            points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 862)} '3rd upper vertical line
            e.Graphics.DrawLines(the_pen, points)

            Text = "Contact"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + 1 + (102 - TextLen) / 2
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY - 15) 'Print Label Contact

            Text = "Phone No"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (102 - TextLen) / 2
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY) 'Print label Phone No

            CurrentX = HardX1 + 700
            points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 862)} '4th upper vertical line
            e.Graphics.DrawLines(the_pen, points)

            Text = "Emergency"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + 1 + (102 - TextLen) / 2
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY - 15) 'Print Label Emergency

            Text = "Phone No"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (102 - TextLen) / 2
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY) 'Print label Phone No

            points = {New Point(HardX1, CurrentY + 31), New Point(HardX2, CurrentY + 31)} '3rd horzontal Line
            e.Graphics.DrawLines(the_pen, points)

        End Using ' the_pen 

        'Fill form with data
        CurrentY = HardY1 + 230

        If RecordCount > 40 Then 'Print page number
            Text = "Page " & P_Page
            e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 735, HardY1 + 12)
        End If

        Font = New Font("Ariel", 26, FontStyle.Regular) 'Print Company Name
        Text = Replace(Label_Company.Text, "&&", "&")
        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
        TextX = HardX1 + (HardWidth - TextLen) / 2
        e.Graphics.DrawString(Text, Font, BlackBrush, TextX, HardY1 + 60)

        Font = New Font("Ariel", 8, FontStyle.Regular)
        For intStep = 0 To 39

            'Print Last Name
            Text = DataArray(P_Line, 0)
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + (132 - TextLen) / 2, CurrentY)

            'Print First Name
            Text = DataArray(P_Line, 1)
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 132 + (132 - TextLen) / 2, CurrentY)

            'Print Address
            Text = DataArray(P_Line, 2)
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 264 + (203 - TextLen) / 2, CurrentY)

            'Print City
            Text = DataArray(P_Line, 3)
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 467 + (87 - TextLen) / 2, CurrentY)

            'Print State
            Text = DataArray(P_Line, 4)
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 554 + (44 - TextLen) / 2, CurrentY)

            'Print Contact phone number
            Text = DataArray(P_Line, 5)
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 598 + (102 - TextLen) / 2, CurrentY)

            'Print Emergency phone number
            Text = DataArray(P_Line, 6)
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 700 + (102 - TextLen) / 2, CurrentY)

            If P_Line = RecordCount - 1 Then Exit For
            P_Line = P_Line + 1
            CurrentY = CurrentY + 20
        Next

        P_Page += 1
        e.HasMorePages = P_Page <= Pages

    End Sub
End Class