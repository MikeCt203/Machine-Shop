Imports System.Drawing.Printing
Public Class frm_PaymentSchedule

    'Database related
    Dim dbAdapter, dbAdapter_SystemData As OleDb.OleDbDataAdapter
    Dim dbDataSet, dbDataSet_SystemData As New DataSet
    Dim strSQL As String

    'Form controls related
    Dim lbl_CustomerName(1) As Label
    Dim lbl_InvoiceNumber(1) As Label
    Dim lbl_PurchaseOrder(1) As Label
    Dim lbl_POItem(1) As Label
    Dim lbl_DrawNumber(1) As Label
    Dim lbl_PaymentAmt(1) As Label
    Dim lbl_DueDate(1) As Label
    Dim lbl_LateDays(1) As Label
    Dim lbl_Phone(1) As Label

    'Data related
    Dim DataArray(8, 1) As Object 'Array to hold all data
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

        strSQL = "SELECT Company,InvoiceNumber,PurchaseOrder,POItem ,DrawingNumber,QtyShip,Price,Invoice.Freight,DueDate,BPhone " _
            & "FROM Invoice INNER JOIN Customers ON Invoice.CustCode = Customers.CustCode " _
            & "WHERE PaidDate Is Null AND InvoiceDate Is Not Null ORDER BY ShipDate,Company,PurchaseOrder,DrawingNumber;"
        dbDataSet.Clear()
        dbDataSet.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter.Fill(dbDataSet, "View")
        gbl_DstConnect.Close()
        RecordCount = dbDataSet.Tables("View").Rows.Count()
        ReDim DataArray(RecordCount, 9)

        If RecordCount <= 40 Then
            cmd_PrintAll.Visible = False
            cmd_Exit.Top = 77
            fra_SearchCriteria.Height = 140
            fra_Pages.Visible = False
            lbl_Page.Visible = False
        End If

        'Retrieve system values
        strSQL = "SELECT CompanyName,SystemPrinter,Buffer,DueDays FROM System;"
        dbDataSet_SystemData.Clear()
        dbDataSet_SystemData.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter_SystemData = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter_SystemData.Fill(dbDataSet_SystemData, "SystemData")
        gbl_DstConnect.Close()

        Label_Company.Text = Replace(dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(0), "&", "&&") 'Company Name 
        SystemPrinter = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(1) 'System printer name
        Buffer = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(2) 'Printer buffer
        DueDays = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(3) 'Due Days for payment

        Call ArrayFill()
        Call CalculateTotals()
        Call AddControls()
        D_Page = 1
        Call FormFill()
    End Sub
    Private Sub CalculateTotals()

        Dim Total, LateTotal As Single
        Total = 0 : LateTotal = 0

        For intStep = 0 To RecordCount - 1
            Total = Total + DataArray(intStep, 5)
            If DataArray(intStep, 6) <> "" Then
                If Now.Date > Convert.ToDateTime(DataArray(intStep, 6)) Then LateTotal = LateTotal + DataArray(intStep, 5)
            End If
        Next

        Label_HeaderDates.Text = DataArray(0, 6) & " ---------------- " & DataArray(RecordCount - 1, 6) 'Header dates
        lbl_TotalOrders.Text = RecordCount
        lbl_TotalPayments.Text = FormatCurrency(Total)
        lbl_LatePayments.Text = FormatCurrency(LateTotal)

    End Sub
    Private Sub Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        dbDataSet.Clear()
        dbDataSet.Tables.Clear()
        dbDataSet_SystemData.Clear()
        dbDataSet_SystemData.Tables.Clear()
        Me.Dispose()
    End Sub
    Private Sub AddControls() 'Add date and quantity controls

        Dim int_Top, Rows, i As Integer
        If RecordCount >= 40 Then Rows = 39 Else Rows = RecordCount - 1

        ReDim lbl_CustomerName(Rows)
        ReDim lbl_InvoiceNumber(Rows)
        ReDim lbl_PurchaseOrder(Rows)
        ReDim lbl_POItem(Rows)
        ReDim lbl_DrawNumber(Rows)
        ReDim lbl_DueDate(Rows)
        ReDim lbl_PaymentAmt(Rows)
        ReDim lbl_DueDate(Rows)
        ReDim lbl_LateDays(Rows)
        ReDim lbl_Phone(Rows)
      
        'Create array of controls in frame information
        int_Top = 168

        For i = 0 To 39
            int_Top = int_Top + 16
            lbl_CustomerName(i) = New Label
            lbl_InvoiceNumber(i) = New Label
            lbl_PurchaseOrder(i) = New Label
            lbl_POItem(i) = New Label
            lbl_DrawNumber(i) = New Label
            lbl_PaymentAmt(i) = New Label
            lbl_DueDate(i) = New Label
            lbl_LateDays(i) = New Label
            lbl_Phone(i) = New Label


            With lbl_CustomerName(i)
                .Name = "lbl_CustomerName"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(16, int_Top, 191, 15)
                fra_PaymentSchedule.Controls.Add(lbl_CustomerName(i))
            End With

            With lbl_InvoiceNumber(i)
                .Name = "lbl_InvoiceNumber"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(208, int_Top, 52, 15)
                fra_PaymentSchedule.Controls.Add(lbl_InvoiceNumber(i))
            End With

            With lbl_PurchaseOrder(i)
                .Name = "lbl_PurchaseOrder"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(261, int_Top, 119, 15)
                fra_PaymentSchedule.Controls.Add(lbl_PurchaseOrder(i))
            End With

            With lbl_POItem(i)
                .Name = "lbl_POItem"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(381, int_Top, 23, 15)
                fra_PaymentSchedule.Controls.Add(lbl_POItem(i))
            End With

            With lbl_DrawNumber(i)
                .Name = "lbl_DrawNumber"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(406, int_Top, 103, 15)
                fra_PaymentSchedule.Controls.Add(lbl_DrawNumber(i))
            End With

            With lbl_PaymentAmt(i)
                .Name = "lbl_PaymentAmt"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(510, int_Top, 69, 15)
                fra_PaymentSchedule.Controls.Add(lbl_PaymentAmt(i))
            End With

            With lbl_DueDate(i)
                .Name = "lbl_DueDate"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(580, int_Top, 64, 15)
                fra_PaymentSchedule.Controls.Add(lbl_DueDate(i))
            End With

            With lbl_LateDays(i)
                .Name = "lbl_LateDays"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(647, int_Top, 31, 15)
                fra_PaymentSchedule.Controls.Add(lbl_LateDays(i))
            End With

            With lbl_Phone(i)
                .Name = "lbl_Phone"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(679, int_Top, 89, 15)
                fra_PaymentSchedule.Controls.Add(lbl_Phone(i))
            End With
            If i = RecordCount - 1 Then Exit For
        Next
    End Sub
    Private Sub ArrayFill() 'Fill Array with data   

        For intStep = 0 To RecordCount - 1
            If Not IsDBNull(dbDataSet.Tables("View").Rows(intStep).Item(0)) Then 'Company Name
                DataArray(intStep, 0) = StrConv(LCase(Trim(dbDataSet.Tables("View").Rows(intStep).Item(0))), VbStrConv.ProperCase)
            Else : DataArray(intStep, 0) = "" : End If

            If Not IsDBNull(dbDataSet.Tables("View").Rows(intStep).Item(1)) Then 'Invoice Number
                DataArray(intStep, 1) = Trim(dbDataSet.Tables("View").Rows(intStep).Item(1))
            Else : DataArray(intStep, 1) = "" : End If

            If Not IsDBNull(dbDataSet.Tables("View").Rows(intStep).Item(2)) Then 'Purchase Order
                DataArray(intStep, 2) = Trim(dbDataSet.Tables("View").Rows(intStep).Item(2))
            Else : DataArray(intStep, 2) = "" : End If

            If Not IsDBNull(dbDataSet.Tables("View").Rows(intStep).Item(3)) Then 'Purchase Order line item number
                DataArray(intStep, 3) = Trim(dbDataSet.Tables("View").Rows(intStep).Item(3))
            Else : DataArray(intStep, 3) = "" : End If

            If Not IsDBNull(dbDataSet.Tables("View").Rows(intStep).Item(4)) Then 'Drawing Number
                DataArray(intStep, 4) = Trim(dbDataSet.Tables("View").Rows(intStep).Item(4))
            Else : DataArray(intStep, 4) = "" : End If

            If Not IsDBNull(dbDataSet.Tables("View").Rows(intStep).Item(5)) And Not IsDBNull(dbDataSet.Tables("View").Rows(intStep).Item(6)) Then 'Quantity * price 
                DataArray(intStep, 5) = dbDataSet.Tables("View").Rows(intStep).Item(5) * dbDataSet.Tables("View").Rows(intStep).Item(6)
                If Not IsDBNull(dbDataSet.Tables("View").Rows(intStep).Item(7)) Then 'Freight
                    DataArray(intStep, 5) = DataArray(intStep, 5) + Trim(dbDataSet.Tables("View").Rows(intStep).Item(7))
                End If
            Else : DataArray(intStep, 5) = 0 : End If

            If Not IsDBNull(dbDataSet.Tables("View").Rows(intStep).Item(8)) And dbDataSet.Tables("View").Rows(intStep).Item(8).ToString <> "#12/12/1212#" Then 'Due Date
                DataArray(intStep, 6) = FormatDateTime(DateAdd(DateInterval.Day, DueDays, dbDataSet.Tables("View").Rows(intStep).Item(8)), DateFormat.ShortDate)
                If Now.Date > DataArray(intStep, 6) Then DataArray(intStep, 7) = Math.Abs(DateDiff(DateInterval.Day, Now.Date, DataArray(intStep, 6)))
            Else : DataArray(intStep, 6) = "" : DataArray(intStep, 7) = 0 : End If

            If Not IsDBNull(dbDataSet.Tables("View").Rows(intStep).Item(9)) Then 'Phone number
                DataArray(intStep, 8) = Trim(dbDataSet.Tables("View").Rows(intStep).Item(9))
            Else : DataArray(intStep, 8) = "" : End If
        Next
    End Sub
    Private Sub FormFill() 'Fill form with data pertaining to listbox selection

        Dim Row As Integer = (D_Page - 1) * 40
        Dim intStep As Integer

        'Form fill data
        lbl_Page.Text = "Page " & D_Page
        For intStep = 0 To 39
            lbl_CustomerName(intStep).Text = StrConv(LCase(DataArray(Row, 0)), VbStrConv.ProperCase)
            lbl_InvoiceNumber(intStep).Text = DataArray(Row, 1)
            lbl_PurchaseOrder(intStep).Text = DataArray(Row, 2)
            lbl_POItem(intStep).Text = DataArray(Row, 3)
            lbl_DrawNumber(intStep).Text = DataArray(Row, 4)
            lbl_PaymentAmt(intStep).Text = FormatCurrency(DataArray(Row, 5))
            lbl_DueDate(intStep).Text = DataArray(Row, 6)
            lbl_LateDays(intStep).Text = DataArray(Row, 7)
            If DataArray(Row, 7) <> 0 Then
                lbl_DueDate(intStep).ForeColor = Color.Brown
                lbl_LateDays(intStep).ForeColor = Color.Brown
            Else
                lbl_DueDate(intStep).ForeColor = System.Drawing.SystemColors.ControlText
                lbl_LateDays(intStep).ForeColor = System.Drawing.SystemColors.ControlText
            End If
            lbl_Phone(intStep).Text = DataArray(Row, 8)

            If Row = RecordCount - 1 Then Exit For
            Row = Row + 1
        Next

        'Clear remaining rows on not full page
        If intStep < 39 And RecordCount > 40 Then
            Dim intStep1 As Integer = intStep + 1
            For intStep = intStep1 To 39
                lbl_CustomerName(intStep).Text = ""
                lbl_InvoiceNumber(intStep).Text = ""
                lbl_PurchaseOrder(intStep).Text = ""
                lbl_POItem(intStep).Text = ""
                lbl_DrawNumber(intStep).Text = ""
                lbl_PaymentAmt(intStep).Text = ""
                lbl_DueDate(intStep).Text = ""
                lbl_LateDays(intStep).Text = ""
                lbl_Phone(intStep).Text = ""
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

        Font = New Font("Swis721 BlkOul BT", 21, FontStyle.Regular) 'Print title Payment Schedule
        e.Graphics.DrawString("Payment Schedule", Font, BlackBrush, HardX1 + 243, HardY1 + 24)

        Font = New Font("Ariel", 18, FontStyle.Regular) 'Print Workschedule Dates
        Text = Label_HeaderDates.Text
        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
        TextX = HardX1 + (HardWidth - TextLen) / 2
        e.Graphics.DrawString(Text, Font, BlackBrush, TextX, HardY1 + 107)

        Font = New Font("Arial", 9, FontStyle.Bold)
        Text = Label_Orders.Text 'Print label total orders
        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
        TextX = HardX1 + 713 - TextLen
        e.Graphics.DrawString(Text, Font, BlackBrush, TextX, HardY1 + 135) 'Print Total Orders

        Text = Label_TotalPayments.Text 'Print label total payments
        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
        TextX = HardX1 + 713 - TextLen
        e.Graphics.DrawString(Text, Font, BlackBrush, TextX, HardY1 + 151) 'Print Total Orders

        Text = Label_LatePayments.Text 'Print label late payments
        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
        TextX = HardX1 + 713 - TextLen
        e.Graphics.DrawString(Text, Font, BlackBrush, TextX, HardY1 + 167) 'Print Total Orders

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

            Text = "Customer Name"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = HardX1 + (204 - TextLen) / 2
            TextY = CurrentY + 16
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY) 'Print Customer Name

            CurrentX = HardX1 + 204
            points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 862)} '1st upper vertical line
            e.Graphics.DrawLines(the_pen, points)

            Text = "Invoice"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (60 - TextLen) / 2
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY - 15) 'Print label Invoice

            Text = "Number"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (60 - TextLen) / 2
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY) 'Print label Number

            CurrentX = HardX1 + 264
            points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 862)} '2nd upper vertical line
            e.Graphics.DrawLines(the_pen, points)

            Text = "P.O."
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (115 - TextLen) / 2 '111
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY - 15) 'Print label P.O.

            Text = "Number"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (115 - TextLen) / 2 '111
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY) 'Print label Number

            CurrentX = HardX1 + 379 '375
            points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 862)} '3rd upper vertical line
            e.Graphics.DrawLines(the_pen, points)

            Text = "PO" 'P.O.
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + 1 + (29 - TextLen) / 2 '33
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY - 15) 'Print P.O.

            Text = "N0"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (29 - TextLen) / 2 '33
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY) 'Print label No

            CurrentX = HardX1 + 408
            points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 862)} '4th upper vertical line
            e.Graphics.DrawLines(the_pen, points)

            Text = "Drawing"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (111 - TextLen) / 2
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY - 15) 'Print label Drawing

            Text = "Number"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (111 - TextLen) / 2
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY) 'Print label Number

            CurrentX = HardX1 + 519
            points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 862)} '5th upper vertical line
            e.Graphics.DrawLines(the_pen, points)

            Text = "Payment"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (74 - TextLen) / 2
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY - 15) 'Print label Drawing

            Text = "Amount"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (74 - TextLen) / 2
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY) 'Print label Number

            CurrentX = HardX1 + 593
            points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 862)} '6th upper vertical line
            e.Graphics.DrawLines(the_pen, points)

            Text = "Due"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (77 - TextLen) / 2
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY - 15) 'Print label Due

            Text = "Date"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (77 - TextLen) / 2
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY) 'Print label Date

            CurrentX = HardX1 + 670
            points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 862)} '7th upper vertical line
            e.Graphics.DrawLines(the_pen, points)

            Text = "Late"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (36 - TextLen) / 2
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY - 15) 'Print label Due

            Text = "Day"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (36 - TextLen) / 2
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY) 'Print label date

            CurrentX = HardX1 + 706
            points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 862)} '8th upper vertical line
            e.Graphics.DrawLines(the_pen, points)

            Text = "Phone"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (96 - TextLen) / 2
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY - 15) 'Print label Phone

            Text = "Number"
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            TextX = CurrentX + (96 - TextLen) / 2
            e.Graphics.DrawString(Text, Font, BlackBrush, TextX, TextY) 'Print label Number

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

        Font = New Font("Arial", 9, FontStyle.Regular)
        Text = lbl_TotalOrders.Text 'Print label total orders
        TextX = HardX1 + 714
        e.Graphics.DrawString(Text, Font, FlagBrush, TextX, HardY1 + 135) 'Print Total Orders

        Text = lbl_TotalPayments.Text 'Print label total payments
        TextX = HardX1 + 714
        e.Graphics.DrawString(Text, Font, FlagBrush, TextX, HardY1 + 151) 'Print Total Orders

        Text = lbl_LatePayments.Text 'Print label late payments
        TextX = HardX1 + 714
        e.Graphics.DrawString(Text, Font, FlagBrush, TextX, HardY1 + 167) 'Print Total Orders

        Font = New Font("Ariel", 8, FontStyle.Regular)
        For intStep = 0 To 39

            'Print company name
            Text = DataArray(P_Line, 0)
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + (204 - TextLen) / 2, CurrentY)

            'Print invoice number
            Text = DataArray(P_Line, 1)
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 204 + (60 - TextLen) / 2, CurrentY)

            'Print purchase order
            Text = DataArray(P_Line, 2)
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 264 + (115 - TextLen) / 2, CurrentY) '264   111

            'Print purchase order line number
            Text = DataArray(P_Line, 3)
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 379 + (29 - TextLen) / 2, CurrentY) '375  33

            'Print drawing number
            Text = DataArray(P_Line, 4)
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 408 + (111 - TextLen) / 2, CurrentY)

            'Print payment amount
            Text = FormatCurrency(DataArray(P_Line, 5))
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 519 + (74 - TextLen) / 2, CurrentY)

            'Print due date
            Text = DataArray(P_Line, 6)
            If DataArray(P_Line, 7) > 0 Then brush = FlagBrush Else brush = BlackBrush
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            e.Graphics.DrawString(Text, Font, brush, HardX1 + 593 + (77 - TextLen) / 2, CurrentY)

            'Print late day
            Text = DataArray(P_Line, 7)
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            e.Graphics.DrawString(Text, Font, brush, HardX1 + 670 + (36 - TextLen) / 2, CurrentY)

            'Print phone number
            Text = DataArray(P_Line, 8)
            TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
            e.Graphics.DrawString(Text, Font, BlackBrush, HardX1 + 706 + (96 - TextLen) / 2, CurrentY)

            If P_Line = RecordCount - 1 Then Exit For
            P_Line = P_Line + 1
            CurrentY = CurrentY + 20
        Next

        P_Page += 1
        e.HasMorePages = P_Page <= Pages

    End Sub

    Private Sub Label_Rev_Click(sender As Object, e As EventArgs) Handles Label_Rev.Click

    End Sub
End Class