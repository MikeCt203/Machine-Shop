Imports System.Drawing.Printing
Public Class frm_InvoiceReorder

    'Database related
    Dim dbAdapter, dbAdapter_SystemData, dbAdapter_Misc As OleDb.OleDbDataAdapter
    Dim dbDataSet, dbDataSet_SystemData, dbDataSet_Misc As New DataSet
    Dim strSQL As String

    'Form controls related
    Dim lbl_ItemNum(3) As Label
    Dim lbl_ExtendedPrice(3) As Label
    Dim tbox_POItem(3) As TextBox
    Dim lbl_DrawNum(3) As Label
    Dim lbl_DrawRev(3) As Label
    Dim tbox_QtyOrdered(3) As TextBox
    Dim tbox_QtyShipped(3) As TextBox
    Dim tbox_DescripA(3) As TextBox
    Dim tbox_DescripB(3) As TextBox
    Dim tbox_DescripC(3) As TextBox
    Dim lbl_MaterialHeat(3) As Label
    Dim tbox_MaterialHeat(3) As TextBox
    Dim lbl_LotId(3) As Label
    Dim tbox_Price(3) As TextBox

    'Data related
    Dim booCorrection, booDataChecked, booRestore As Boolean
    Dim ShipVia, Agent, Terms, strInitEntry As String
    Dim DiscountAmt, Freight, SubTotal As Double
    Dim DiscountDays, ItemCount, intMessage As Integer

    'Print report Related
    Private WithEvents PrintForms As PrintDocument
    Declare Function GetDeviceCaps% Lib "GDI32" (ByVal hDC%, ByVal nIndex%)
    Private SystemPrinter, Image_Path, InvImage, PdfPrinter, PdfPath As String
    Private PageNumber, Buffer As Integer
    Private Pages As Boolean 'True = print multiple forms
    Private InvoBrush As New SolidBrush(Color.Black)
    Private FillBrush As New SolidBrush(Color.Lavender)

    'All form related events
    Public Sub New()
        booDataChecked = True 'Added to stop editsave from changing form on initial startup with masked edit boxes
        InitializeComponent() 'This call is required by the designer
    End Sub
    Private Sub frm_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated
        Call AddControls()
        Call FormValues()
    End Sub
    Private Sub frm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.Location = New Point((Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2, frm_Main.Top + 64)
        Call EnableEdits(False)
        tbox_Search.Focus()
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
    Private Sub AddControls() 'Add date and quantity controls

        Dim int_Top As Integer
        Dim i As Integer

        'Create array of controls in frame information
        int_Top = 427
        For i = 0 To 2
            int_Top = int_Top + 18
            tbox_POItem(i) = New TextBox
            lbl_DrawNum(i) = New Label
            lbl_DrawRev(i) = New Label
            lbl_ExtendedPrice(i) = New Label
            tbox_QtyOrdered(i) = New TextBox
            tbox_QtyShipped(i) = New TextBox
            tbox_DescripA(i) = New TextBox
            tbox_DescripB(i) = New TextBox
            tbox_DescripC(i) = New TextBox
            lbl_MaterialHeat(i) = New Label
            tbox_MaterialHeat(i) = New TextBox
            lbl_LotId(i) = New Label
            tbox_Price(i) = New TextBox
            lbl_ItemNum(i) = New Label

            With lbl_ItemNum(i)
                .Name = "lbl_ItemNum"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(21, int_Top, 32, 14)
                fra_InvoiceDisplay.Controls.Add(lbl_ItemNum(i))
            End With

            With tbox_POItem(i)
                .Name = "tbox_POItem"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(64, int_Top, 32, 14)
                fra_InvoiceDisplay.Controls.Add(tbox_POItem(i))
                AddHandler .GotFocus, AddressOf tbox_GotFocus
                AddHandler .LostFocus, AddressOf tbox_LostFocus
                AddHandler .TextChanged, AddressOf tbox_TextChanged
                AddHandler .KeyPress, AddressOf tbox_KeyPress
                AddHandler .MouseHover, AddressOf All_MouseHover
            End With

            With lbl_DrawNum(i)
                .Name = "lbl_DrawNum"
                .Tag = i
                .Visible = False
                fra_InvoiceDisplay.Controls.Add(lbl_DrawNum(i))
            End With

            With lbl_DrawRev(i)
                .Name = "lbl_DrawRev"
                .Tag = i
                .Visible = False
                fra_InvoiceDisplay.Controls.Add(lbl_DrawRev(i))
            End With

            With tbox_QtyOrdered(i)
                .Name = "tbox_QtyOrdered"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(107, int_Top, 54, 14)
                fra_InvoiceDisplay.Controls.Add(tbox_QtyOrdered(i))
                AddHandler .GotFocus, AddressOf tbox_GotFocus
                AddHandler .LostFocus, AddressOf tbox_LostFocus
                AddHandler .TextChanged, AddressOf tbox_TextChanged
                AddHandler .KeyPress, AddressOf tbox_KeyPress
                AddHandler .MouseHover, AddressOf All_MouseHover
            End With

            With tbox_QtyShipped(i)
                .Name = "tbox_QtyShipped"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(172, int_Top, 54, 14)
                fra_InvoiceDisplay.Controls.Add(tbox_QtyShipped(i))
                AddHandler .GotFocus, AddressOf tbox_GotFocus
                AddHandler .LostFocus, AddressOf tbox_LostFocus
                AddHandler .TextChanged, AddressOf tbox_TextChanged
                AddHandler .KeyPress, AddressOf tbox_KeyPress
                AddHandler .MouseHover, AddressOf All_MouseHover
            End With

            With tbox_DescripA(i)
                .Name = "tbox_DescripA"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(237, int_Top, 320, 14)
                fra_InvoiceDisplay.Controls.Add(tbox_DescripA(i))
                AddHandler .GotFocus, AddressOf tbox_GotFocus
                AddHandler .LostFocus, AddressOf tbox_LostFocus
                AddHandler .TextChanged, AddressOf tbox_TextChanged
                AddHandler .KeyPress, AddressOf tbox_KeyPress
                AddHandler .MouseHover, AddressOf All_MouseHover
            End With

            int_Top = int_Top + 18
            With tbox_DescripB(i)
                .Name = "tbox_DescripB"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(237, int_Top, 320, 14)
                fra_InvoiceDisplay.Controls.Add(tbox_DescripB(i))
                AddHandler .GotFocus, AddressOf tbox_GotFocus
                AddHandler .LostFocus, AddressOf tbox_LostFocus
                AddHandler .TextChanged, AddressOf tbox_TextChanged
                AddHandler .KeyPress, AddressOf tbox_KeyPress
                AddHandler .MouseHover, AddressOf All_MouseHover
            End With

            int_Top = int_Top + 18
            With tbox_DescripC(i)
                .Name = "tbox_DescripC"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(237, int_Top, 320, 14)
                fra_InvoiceDisplay.Controls.Add(tbox_DescripC(i))
                AddHandler .GotFocus, AddressOf tbox_GotFocus
                AddHandler .LostFocus, AddressOf tbox_LostFocus
                AddHandler .TextChanged, AddressOf tbox_TextChanged
                AddHandler .KeyPress, AddressOf tbox_KeyPress
                AddHandler .MouseHover, AddressOf All_MouseHover
            End With

            int_Top = int_Top + 18
            With lbl_MaterialHeat(i)
                .Name = "lbl_MaterialHeat"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .Text = "Material Heat ="
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = False
                .SetBounds(237, int_Top, 91, 14)
                fra_InvoiceDisplay.Controls.Add(lbl_MaterialHeat(i))
            End With

            With tbox_MaterialHeat(i)
                .Name = "tbox_MaterialHeat"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(347, int_Top, 100, 14)
                fra_InvoiceDisplay.Controls.Add(tbox_MaterialHeat(i))
                AddHandler .GotFocus, AddressOf tbox_GotFocus
                AddHandler .LostFocus, AddressOf tbox_LostFocus
                AddHandler .TextChanged, AddressOf tbox_TextChanged
                AddHandler .KeyPress, AddressOf tbox_KeyPress
                AddHandler .MouseHover, AddressOf All_MouseHover
            End With

            With lbl_LotId(i)
                .Name = "lbl_LotId"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .Text = "Lot Id ="
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = False
                .SetBounds(457, int_Top, 100, 14)
                fra_InvoiceDisplay.Controls.Add(lbl_LotId(i))
            End With

            With tbox_Price(i)
                .Name = "tbox_Price"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(568, int_Top, 90, 14)
                fra_InvoiceDisplay.Controls.Add(tbox_Price(i))
                AddHandler .GotFocus, AddressOf tbox_GotFocus
                AddHandler .LostFocus, AddressOf tbox_LostFocus
                AddHandler .TextChanged, AddressOf tbox_TextChanged
                AddHandler .KeyPress, AddressOf tbox_KeyPress
                AddHandler .MouseHover, AddressOf All_MouseHover
            End With

            With lbl_ExtendedPrice(i)
                .Name = "lbl_ExtendedPrice"
                .Tag = i
                .Font = New Font("Ariel", 9, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .BorderStyle = BorderStyle.None
                .Visible = True
                .SetBounds(669, int_Top, 94, 14)
                fra_InvoiceDisplay.Controls.Add(lbl_ExtendedPrice(i))
            End With

        Next
    End Sub
    Private Sub FormValues() 'Titles and Image of invoice:

        booDataChecked = True

        'Titles and Image of invoice:
        image_Path = Microsoft.VisualBasic.Left(Application.StartupPath, Len(Application.StartupPath) - 9) & "\Images\"
        InvImage = image_Path + "GammaLogo.png"

        If (System.IO.File.Exists(InvImage)) Then 'Draw Logo image
            PictureBox1.Image = Image.FromFile(InvImage)
        End If

        'Retrieve system values
        strSQL = "SELECT CompanyAddress,CompanyCity,CompanyState,CompanyZipCode,CompanyPhone,Terms,Agent1," _
               & "SystemPrinter,Buffer,DiscountAmount,DiscountDays,ReInvoicePaid,PdfPrinter,PdfPath FROM System;"
        dbDataSet_SystemData.Clear()
        dbDataSet_SystemData.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter_SystemData = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter_SystemData.Fill(dbDataSet_SystemData, "SystemData")
        gbl_DstConnect.Close()

        Dim Comp_City, Comp_State, Comp_ZipCode As String
        lbl_CompanyAddress.Text = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(0) 'Company Address
        Comp_City = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(1) 'Company City
        Comp_State = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(2) 'Company State
        Comp_ZipCode = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(3) 'Company ZipCode
        lbl_CompanyCity.Text = Comp_City & "  " & Comp_State & "  " & Comp_ZipCode
        lbl_CompanyPhone.Text = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(4) 'Company Phone
        tbox_Terms.Text = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(5) 'Payment terms
        Agent = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(6) 'Primary inspection agent
        SystemPrinter = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(7) 'System printer name
        Buffer = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(8) 'Printer buffer

        'Allow pdf printing only if system variable set up
        If Not IsDBNull(dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(12)) Then 'Pdf printer 
            PdfPrinter = Trim(dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(12))
        Else : chk_PdfFile.Enabled = False : End If
        If Not IsDBNull(dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(13)) Then 'Pdf file location
            PdfPath = Trim(dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(13))
        Else : chk_PdfFile.Enabled = False : End If

        booDataChecked = False
    End Sub
    Private Sub ClearData()
        tbox_CustCode.Text = ""
        tbox_CustCode.Visible = False
        Label_EnterCustcode.Visible = False
        lbl_InvoiceNumber.Text = ""
        tbox_SoldToName.Text = ""
        tbox_SoldToAddress.Text = ""
        tbox_SoldToState.Text = ""
        tbox_ShipToName.Text = ""
        tbox_ShipToAddress.Text = ""
        tbox_ShipToState.Text = ""
        tbox_PurchaseOrder.Text = ""
        tbox_InvoiceDate.Text = ""
        tbox_DateShipped.Text = ""
        tbox_ShipVia.Text = ""
        tbox_Terms.Text = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(5)
        cbx_Discount.Checked = False
        lbl_DiscountMessage.Visible = False

        For intStep = 0 To 2
            lbl_ItemNum(intStep).Text = ""
            lbl_ItemNum(intStep).Visible = False
            tbox_POItem(intStep).Text = ""
            tbox_POItem(intStep).Visible = False
            lbl_DrawNum(intStep).Text = ""
            lbl_DrawRev(intStep).Text = ""
            tbox_QtyOrdered(intStep).Text = ""
            tbox_QtyOrdered(intStep).Visible = False
            tbox_QtyShipped(intStep).Text = ""
            tbox_QtyShipped(intStep).Visible = False
            tbox_DescripA(intStep).Text = ""
            tbox_DescripA(intStep).Visible = False
            tbox_DescripB(intStep).Text = ""
            tbox_DescripB(intStep).Visible = False
            tbox_DescripC(intStep).Text = ""
            tbox_DescripC(intStep).Visible = False
            If booRestore = False Then
                lbl_MaterialHeat(intStep).Visible = False
                tbox_MaterialHeat(intStep).Text = ""
                tbox_MaterialHeat(intStep).Visible = False
                lbl_LotId(intStep).Text = ""
                lbl_LotId(intStep).Visible = False
            Else
                tbox_MaterialHeat(intStep).Text = ""
            End If
            tbox_Price(intStep).Text = ""
            tbox_Price(intStep).Visible = False
            lbl_ExtendedPrice(intStep).Text = ""
            lbl_ExtendedPrice(intStep).Visible = False
        Next

        lbl_SubTotal.Text = ""
        lbl_Total.Text = ""
        Call EnablePrint(False)
    End Sub
    Private Sub DataFill() 'Fill form with data pertaining to listbox selection
        booDataChecked = True

        Dim sngPrice, Freight, SubTotal As Single
        Call ClearData() 'Clear form of all data

        strSQL = "SELECT Id,CustCode,InvoiceNumber,InvoiceDate,PurchaseOrder,POItem,DrawingNumber,DrawingRevision,ShipDate," _
                    & "QtyOrdered,QtyShip,DescripA,DescripB,DescripC,Price,Freight,Discount,DiscountDays,ShipVia,MaterialHeat," _
                    & "PaidDate FROM Invoice WHERE InvoiceNumber = " & Trim(tbox_Search.Text) & " ORDER BY InvoiceItem;"

        dbDataSet.Clear()
        dbDataSet.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter.Fill(dbDataSet, "InvoiceData")
        gbl_DstConnect.Close()
        ItemCount = dbDataSet.Tables("InvoiceData").Rows.Count()
        If ItemCount > 3 Then ItemCount = 3

        If dbDataSet.Tables("InvoiceData").Rows.Count() > 0 Then

            If Not IsDBNull(dbDataSet.Tables("InvoiceData").Rows(0).Item(1)) Then 'CustCode
                tbox_CustCode.Text = Trim(dbDataSet.Tables("InvoiceData").Rows(0).Item(1))
                Call CompanyFill(tbox_CustCode.Text)
            End If

            'Form fill data
            If Not IsDBNull(dbDataSet.Tables("InvoiceData").Rows(0).Item(2)) Then 'Invoice number
                lbl_InvoiceNumber.Text = Trim(dbDataSet.Tables("InvoiceData").Rows(0).Item(2))
            Else : lbl_InvoiceNumber.Text = "Error" : End If

            If Not IsDBNull(dbDataSet.Tables("InvoiceData").Rows(0).Item(4)) Then 'Purchase order
                tbox_PurchaseOrder.Text = Trim(dbDataSet.Tables("InvoiceData").Rows(0).Item(4))
            End If

            If Not IsDBNull(dbDataSet.Tables("InvoiceData").Rows(0).Item(3)) And dbDataSet.Tables("InvoiceData").Rows(0).Item(3).ToString <> "#12/12/1212#" Then 'Invoice date
                tbox_InvoiceDate.Text = Format(dbDataSet.Tables("InvoiceData").Rows(0).Item(3), "MM/dd/yyyy")
            End If

            If Not IsDBNull(dbDataSet.Tables("InvoiceData").Rows(0).Item(8)) And dbDataSet.Tables("InvoiceData").Rows(0).Item(5).ToString <> "#12/12/1212#" Then 'Date shipped
                tbox_DateShipped.Text = Format(dbDataSet.Tables("InvoiceData").Rows(0).Item(8), "MM/dd/yyyy")
            End If

            If Not IsDBNull(dbDataSet.Tables("InvoiceData").Rows(0).Item(18)) Then 'ShipVia
                tbox_ShipVia.Text = Trim(dbDataSet.Tables("InvoiceData").Rows(0).Item(18))
            End If

            If Not IsDBNull(dbDataSet.Tables("InvoiceData").Rows(0).Item(16)) Then 'Discount
                If dbDataSet.Tables("InvoiceData").Rows(0).Item(16) <> 0 Then
                    DiscountAmt = dbDataSet.Tables("InvoiceData").Rows(0).Item(16)
                    DiscountDays = dbDataSet.Tables("InvoiceData").Rows(0).Item(17)
                    cbx_Discount.Checked = True
                    lbl_DiscountMessage.Text = DiscountAmt & "% Discount if paid within " & DiscountDays & " days"
                    lbl_DiscountMessage.Visible = True
                End If
            End If

            SubTotal = 0
            Freight = 0
            Dim intTop As Integer = 400
            For intStep = 0 To ItemCount - 1

                intTop = intTop + 40 'Space between items

                lbl_ItemNum(intStep).Top = intTop
                lbl_ItemNum(intStep).Text = intStep + 1
                lbl_ItemNum(intStep).Visible = True

                If Not IsDBNull(dbDataSet.Tables("InvoiceData").Rows(intStep).Item(5)) Then 'Purchase order line item
                    tbox_POItem(intStep).Top = intTop
                    tbox_POItem(intStep).Text = Trim(dbDataSet.Tables("InvoiceData").Rows(intStep).Item(5))
                    tbox_POItem(intStep).Visible = True
                End If

                If Not IsDBNull(dbDataSet.Tables("InvoiceData").Rows(intStep).Item(6)) Then 'Drawing number
                    lbl_DrawNum(intStep).Text = Trim(dbDataSet.Tables("InvoiceData").Rows(intStep).Item(6))
                End If

                If Not IsDBNull(dbDataSet.Tables("InvoiceData").Rows(intStep).Item(7)) Then 'Drawing revision
                    lbl_DrawRev(intStep).Text = Trim(dbDataSet.Tables("InvoiceData").Rows(intStep).Item(7))
                End If

                If Not IsDBNull(dbDataSet.Tables("InvoiceData").Rows(intStep).Item(9)) Then 'Quantity ordered
                    tbox_QtyOrdered(intStep).Top = intTop
                    tbox_QtyOrdered(intStep).Text = Trim(dbDataSet.Tables("InvoiceData").Rows(intStep).Item(9))
                    tbox_QtyOrdered(intStep).Visible = True
                End If

                If Not IsDBNull(dbDataSet.Tables("InvoiceData").Rows(intStep).Item(10)) Then 'Quantity shipped
                    tbox_QtyShipped(intStep).Top = intTop
                    tbox_QtyShipped(intStep).Text = Trim(dbDataSet.Tables("InvoiceData").Rows(intStep).Item(10))
                    tbox_QtyShipped(intStep).Visible = True
                End If

                If Not IsDBNull(dbDataSet.Tables("InvoiceData").Rows(intStep).Item(11)) Then 'Description line 1
                    tbox_DescripA(intStep).Top = intTop
                    tbox_DescripA(intStep).Text = Trim(dbDataSet.Tables("InvoiceData").Rows(intStep).Item(11))
                    tbox_DescripA(intStep).Visible = True
                End If

                If Not IsDBNull(dbDataSet.Tables("InvoiceData").Rows(intStep).Item(12)) Then 'Description line 2
                    intTop = intTop + 18
                    tbox_DescripB(intStep).Top = intTop
                    tbox_DescripB(intStep).Text = Trim(dbDataSet.Tables("InvoiceData").Rows(intStep).Item(12))
                    tbox_DescripB(intStep).Visible = True
                End If

                If Not IsDBNull(dbDataSet.Tables("InvoiceData").Rows(intStep).Item(13)) Then 'Description line 3
                    intTop = intTop + 18
                    tbox_DescripC(intStep).Top = intTop
                    tbox_DescripC(intStep).Text = Trim(dbDataSet.Tables("InvoiceData").Rows(intStep).Item(13))
                    tbox_DescripC(intStep).Visible = True
                End If

                If Not IsDBNull(dbDataSet.Tables("InvoiceData").Rows(intStep).Item(19)) Then 'Material Heat line 4
                    intTop = intTop + 18
                    If booRestore = False Then
                        tbox_MaterialHeat(intStep).Text = Trim(dbDataSet.Tables("InvoiceData").Rows(intStep).Item(19))
                        lbl_LotId(intStep).Text = "Lot Id = " & Trim(dbDataSet.Tables("InvoiceData").Rows(intStep).Item(0))

                        'Calculate length of texbox trimed to hold string
                        Dim g As Graphics = Label1.CreateGraphics
                        Dim s As SizeF
                        s = g.MeasureString(tbox_MaterialHeat(intStep).Text, tbox_MaterialHeat(intStep).Font)
                        Dim tboxWidth As Integer = s.Width + 2
                        s = g.MeasureString(lbl_LotId(intStep).Text, lbl_LotId(intStep).Font)
                        Dim lblwidth As Integer = s.Width + 2
                        Dim StringLength As Integer = lbl_MaterialHeat(intStep).Width + tboxWidth + lblwidth
                        Dim CenterStartPos As Integer = 232 + ((331 - StringLength - 6) / 2)
                        lbl_MaterialHeat(intStep).SetBounds(CenterStartPos, intTop, 91, 14)
                        tbox_MaterialHeat(intStep).SetBounds(CenterStartPos + lbl_MaterialHeat(intStep).Width - 3, intTop + 1, tboxWidth, 14)
                        tbox_MaterialHeat(intStep).BorderStyle = BorderStyle.None
                        lbl_LotId(intStep).SetBounds(CenterStartPos + lbl_MaterialHeat(intStep).Width + tbox_MaterialHeat(intStep).Width + 5, intTop, lblwidth, 14)
                        lbl_MaterialHeat(intStep).Visible = True
                        tbox_MaterialHeat(intStep).Visible = True
                        lbl_LotId(intStep).Visible = True
                    Else
                        tbox_MaterialHeat(intStep).Text = Trim(dbDataSet.Tables("InvoiceData").Rows(intStep).Item(16))
                    End If
                End If

                If Not IsDBNull(dbDataSet.Tables("InvoiceData").Rows(intStep).Item(14)) Then 'Item 1, Unit Price
                    sngPrice = Trim(dbDataSet.Tables("InvoiceData").Rows(intStep).Item(14))
                    tbox_Price(intStep).Top = intTop : lbl_ExtendedPrice(intStep).Top = intTop
                    tbox_Price(intStep).Text = FormatCurrency(sngPrice)
                    lbl_ExtendedPrice(intStep).Text = FormatCurrency(sngPrice * Convert.ToInt32(tbox_QtyShipped(intStep).Text))
                    SubTotal = SubTotal + (sngPrice * Convert.ToInt32(tbox_QtyShipped(intStep).Text))
                    tbox_Price(intStep).Visible = True
                    lbl_ExtendedPrice(intStep).Visible = True
                End If

                If Not IsDBNull(dbDataSet.Tables("InvoiceData").Rows(intStep).Item(15)) Then 'Freight
                    Freight = Freight + Trim(dbDataSet.Tables("InvoiceData").Rows(intStep).Item(15))
                End If

            Next

            lbl_SubTotal.Text = FormatCurrency(SubTotal)
            tbox_Freight.Text = FormatCurrency(Freight)
            SubTotal = SubTotal + Freight
            lbl_Total.Text = FormatCurrency(SubTotal)
            cmd_Action1.Enabled = True
            Call EnablePrint(True)

        Else 'No data found related to search
            frm_Message.Text = "9:1:0:8:3:No records were found to meet the search criteria"
            frm_Message.ShowDialog()
            tbox_Search.Text = ""
            tbox_Search.Focus()
        End If
        booDataChecked = False
    End Sub
    Private Sub CompanyFill(Locate As Integer)

        Dim strCity, strState, strZipcode As String

        strSQL = "SELECT CustCode,Company,Address,City,State,ZipCode,BCompany,BAddress,BCity,BState,BZipcode " _
                 & "FROM Customers WHERE CustCode = " & Locate & ";"
        dbDataSet_Misc.Clear()
        dbDataSet_Misc.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter_Misc = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter_Misc.Fill(dbDataSet_Misc, "CompanyData")
        gbl_DstConnect.Close()
        If dbDataSet_Misc.Tables("CompanyData").Rows.Count() > 0 Then

            If Not IsDBNull(dbDataSet_Misc.Tables("CompanyData").Rows(0).Item(1)) Then 'Sold to name
                tbox_SoldToName.Text = Trim(dbDataSet_Misc.Tables("CompanyData").Rows(0).Item(1))
            End If

            If Not IsDBNull(dbDataSet_Misc.Tables("CompanyData").Rows(0).Item(2)) Then 'Sold to address
                tbox_SoldToAddress.Text = Trim(dbDataSet_Misc.Tables("CompanyData").Rows(0).Item(2))
            End If

            If Not IsDBNull(dbDataSet_Misc.Tables("CompanyData").Rows(0).Item(3)) Then 'Sold to city
                strCity = Trim(dbDataSet_Misc.Tables("CompanyData").Rows(0).Item(3))
            Else : strCity = "" : End If

            If Not IsDBNull(dbDataSet_Misc.Tables("CompanyData").Rows(0).Item(4)) Then 'Sold to state
                strState = Trim(dbDataSet_Misc.Tables("CompanyData").Rows(0).Item(4))
            Else : strState = "" : End If

            If Not IsDBNull(dbDataSet_Misc.Tables("CompanyData").Rows(0).Item(5)) Then 'Sold to zipcode
                strZipcode = Trim(dbDataSet_Misc.Tables("CompanyData").Rows(0).Item(5))
            Else : strZipcode = "" : End If
            tbox_SoldToState.Text = strCity & "  " & strState & "  " & strZipcode

            If Not IsDBNull(dbDataSet_Misc.Tables("CompanyData").Rows(0).Item(6)) Then 'Ship to name
                tbox_ShipToName.Text = Trim(dbDataSet_Misc.Tables("CompanyData").Rows(0).Item(6))
            End If

            If Not IsDBNull(dbDataSet_Misc.Tables("CompanyData").Rows(0).Item(7)) Then 'Ship to address
                tbox_ShipToAddress.Text = Trim(dbDataSet_Misc.Tables("CompanyData").Rows(0).Item(7))
            End If

            If Not IsDBNull(dbDataSet_Misc.Tables("CompanyData").Rows(0).Item(8)) Then 'Ship to city
                strCity = Trim(dbDataSet_Misc.Tables("CompanyData").Rows(0).Item(8))
            Else : strCity = "" : End If

            If Not IsDBNull(dbDataSet_Misc.Tables("CompanyData").Rows(0).Item(9)) Then 'Ship to state
                strState = Trim(dbDataSet_Misc.Tables("CompanyData").Rows(0).Item(9))
            Else : strState = "" : End If

            If Not IsDBNull(dbDataSet_Misc.Tables("CompanyData").Rows(0).Item(10)) Then 'Ship to zipcode
                strZipcode = Trim(dbDataSet_Misc.Tables("CompanyData").Rows(0).Item(10))
            Else : strZipcode = "" : End If
            tbox_ShipToState.Text = strCity & "  " & strState & "  " & strZipcode
        End If

    End Sub
    Private Sub EnablePrint(blnStatus As Boolean)
        cmd_PrintInvoice.Enabled = blnStatus
        cmd_PrintPackingSlip.Enabled = blnStatus
        cmd_PrintCertificate.Enabled = blnStatus
        cmd_PrintAll.Enabled = blnStatus
    End Sub
    Private Sub EnableEdits(blnStatus As Boolean)
        booDataChecked = True
        tbox_SoldToName.Enabled = blnStatus
        tbox_SoldToAddress.Enabled = blnStatus
        tbox_SoldToState.Enabled = blnStatus
        tbox_ShipToName.Enabled = blnStatus
        tbox_ShipToAddress.Enabled = blnStatus
        tbox_ShipToState.Enabled = blnStatus
        tbox_PurchaseOrder.Enabled = blnStatus
        tbox_InvoiceDate.Enabled = blnStatus
        tbox_DateShipped.Enabled = blnStatus
        tbox_ShipVia.Enabled = blnStatus
        tbox_Terms.Enabled = blnStatus
        cbx_Discount.Enabled = blnStatus
        tbox_Freight.Enabled = blnStatus
        For intStep = 0 To 2
            tbox_POItem(intStep).Enabled = blnStatus
            tbox_QtyOrdered(intStep).Enabled = blnStatus
            tbox_QtyShipped(intStep).Enabled = blnStatus
            tbox_DescripA(intStep).Enabled = blnStatus
            tbox_DescripB(intStep).Enabled = blnStatus
            tbox_DescripC(intStep).Enabled = blnStatus
            tbox_MaterialHeat(intStep).Enabled = blnStatus
            If blnStatus = True Then
                lbl_MaterialHeat(intStep).ForeColor = Color.FromKnownColor(KnownColor.ControlText)
                lbl_LotId(intStep).ForeColor = Color.FromKnownColor(KnownColor.ControlText)
            Else
                lbl_MaterialHeat(intStep).ForeColor = Color.FromKnownColor(KnownColor.ControlDarkDark)
                lbl_LotId(intStep).ForeColor = Color.FromKnownColor(KnownColor.ControlDarkDark)
            End If
            tbox_Price(intStep).Enabled = blnStatus
            lbl_ExtendedPrice(intStep).Enabled = blnStatus
        Next
        booDataChecked = False
    End Sub
    Private Sub MaterialHeatEdit()
        For intStep = 0 To ItemCount - 1
            Dim intTop As Integer = tbox_MaterialHeat(intStep).Top
            Dim g As Graphics = Label1.CreateGraphics
            Dim s As SizeF
            s = g.MeasureString(lbl_LotId(intStep).Text, lbl_LotId(intStep).Font)
            Dim lblwidth As Integer = s.Width + 2
            tbox_MaterialHeat(intStep).Width = 100
            Dim StringLength As Integer = lbl_MaterialHeat(intStep).Width + tbox_MaterialHeat(intStep).Width + lblwidth + 5
            Dim CenterStartPos As Integer = 211 + ((330 - StringLength) / 2)
            lbl_MaterialHeat(intStep).Left = CenterStartPos
            tbox_MaterialHeat(intStep).Location = New Point(CenterStartPos + lbl_MaterialHeat(intStep).Width, intTop - 2)
            tbox_MaterialHeat(intStep).BorderStyle = BorderStyle.Fixed3D
            lbl_LotId(intStep).Left = CenterStartPos + lbl_MaterialHeat(intStep).Width + tbox_MaterialHeat(intStep).Width + 5
        Next

    End Sub
    Private Sub PrintForms_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintForms.PrintPage

        'Setup hard margins for printer
        Dim hDC As IntPtr = e.Graphics.GetHdc()
        Dim CurrentX, CurrentY, CurrentX1, CurrentX2, CurrentX3, TextX, TextY, TextLen As Integer
        Dim HardX1, HardX2, HardY1, HardY2, HardWidth, HardHeight As Integer
        Dim Font As Font
        Dim Text As String
        Dim points() As Point
        Dim border, fill As Rectangle
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

        Select Case PageNumber
            Case 1, 2

                'Print large invoice text: & label "Invoice no:" 
                If PageNumber = 1 Then
                    Font = New Font("Arial", 12, FontStyle.Bold)
                    e.Graphics.DrawString("Invoice No:", Font, InvoBrush, HardX1 + 630, HardY1 + 20)
                    Font = New Font("Swis721 BlkOul BT", 32, FontStyle.Regular)
                    e.Graphics.DrawString("invoice", Font, InvoBrush, HardX1 + 500, HardY1 + 70)
                Else
                    Font = New Font("Swis721 BlkOul BT", 32, FontStyle.Regular) ' Font
                    e.Graphics.DrawString("Packing List", Font, InvoBrush, HardX1 + 460, HardY1 + 70)
                End If

                'Print labels Sold To & Ship To
                Font = New Font("Arial", 12, FontStyle.Bold)
                e.Graphics.DrawString("Sold To:", Font, InvoBrush, HardX1 + 20, HardY1 + 250)
                e.Graphics.DrawString("Ship To:", Font, InvoBrush, HardX1 + 430, HardY1 + 250)

                'Print Lower form graphics
                Font = New Font("Arial", 9, FontStyle.Bold)
                Using the_pen As New Pen(Color.Black, 1)
                    points = {New Point(HardX1, HardY1), New Point(HardX2, HardY1), New Point(HardX2, HardY2), New Point(HardX1, HardY2)} 'Outside rectangle
                    e.Graphics.DrawPolygon(the_pen, points)

                    CurrentY = HardY1 + 343
                    points = {New Point(HardX1, CurrentY), New Point(HardX2, CurrentY)} '1st horzontal Line
                    e.Graphics.DrawLines(the_pen, points)

                    fill = New Rectangle(HardX1 + 1, CurrentY, HardWidth - 2, 20) ' Create rectangle for background fill 1st area
                    e.Graphics.FillRectangle(FillBrush, fill) 'Fill rectangle with background color 1st area

                    CurrentX = HardX1 + 38
                    points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 45)} '1st upper vertical line
                    e.Graphics.DrawLines(the_pen, points)

                    Text = "Purchase Order No"
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                    TextX = CurrentX + (172 - TextLen) / 2
                    TextY = CurrentY + 2
                    e.Graphics.DrawString(Text, Font, InvoBrush, TextX, TextY) 'Print label Purchase order no

                    CurrentX = CurrentX + 172
                    points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 45)} '2nd upper vertical line
                    e.Graphics.DrawLines(the_pen, points)

                    Text = "Invoice Date"
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                    TextX = CurrentX + (125 - TextLen) / 2
                    e.Graphics.DrawString(Text, Font, InvoBrush, TextX, TextY) 'Print label Invoice date

                    CurrentX = CurrentX + 125
                    points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 45)} '3rd upper vertical line
                    e.Graphics.DrawLines(the_pen, points)

                    Text = "Date Shipped"
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                    TextX = CurrentX + (125 - TextLen) / 2
                    e.Graphics.DrawString(Text, Font, InvoBrush, TextX, TextY) 'Print label date shipped

                    CurrentX = CurrentX + 125
                    points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 45)} '4th upper vertical line
                    e.Graphics.DrawLines(the_pen, points)

                    Text = "Ship Via"
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                    TextX = CurrentX + (134 - TextLen) / 2
                    e.Graphics.DrawString(Text, Font, InvoBrush, TextX, TextY) 'Print label ship via

                    CurrentX = CurrentX + 134
                    points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 45)} '5th upper vertical line
                    e.Graphics.DrawLines(the_pen, points)

                    Text = "Terms"
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                    TextX = CurrentX + (124 - TextLen) / 2
                    e.Graphics.DrawString(Text, Font, InvoBrush, TextX, TextY) 'Print label terms

                    CurrentX = CurrentX + 124
                    points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 45)} '6th upper vertical line
                    e.Graphics.DrawLines(the_pen, points)

                    Text = "Disc."
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                    TextX = CurrentX + (46 - TextLen) / 2
                    e.Graphics.DrawString(Text, Font, InvoBrush, TextX, TextY) 'Print label Discount

                    CurrentX = CurrentX + 46
                    points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 45)} '7th upper vertical line
                    e.Graphics.DrawLines(the_pen, points)

                    points = {New Point(HardX1, CurrentY + 20), New Point(HardX2, CurrentY + 20)} '2nd horzontal Line
                    e.Graphics.DrawLines(the_pen, points)

                    CurrentY = HardY1 + 388 '3rd horizontal line
                    points = {New Point(HardX1, CurrentY), New Point(HardX2, CurrentY)} '3rd horzontal Line
                    e.Graphics.DrawLines(the_pen, points)

                    fill = New Rectangle(HardX1 + 1, CurrentY, HardWidth - 2, 35) ' Create rectangle for background fill 2nd area
                    e.Graphics.FillRectangle(FillBrush, fill) 'Fill rectangle with background color 2nd area

                    Text = "Item"
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                    TextX = HardX1 + (50 - TextLen) / 2
                    TextY = CurrentY + 18
                    e.Graphics.DrawString(Text, Font, InvoBrush, TextX + 2, TextY) 'Print label invoice item number

                    CurrentX = HardX1 + 50
                    points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 525)} '1st lower vertical line
                    e.Graphics.DrawLines(the_pen, points)

                    Text = "PO"
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                    TextX = CurrentX + (50 - TextLen) / 2
                    TextY = CurrentY + 3
                    e.Graphics.DrawString(Text, Font, InvoBrush, TextX + 4, TextY) 'Print PO

                    Text = "Item"
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                    TextX = CurrentX + (50 - TextLen) / 2
                    TextY = CurrentY + 18
                    e.Graphics.DrawString(Text, Font, InvoBrush, TextX + 2, TextY) 'Print label purchase order item number

                    CurrentX = CurrentX + 50
                    points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 525)} '2nd lower vertical line
                    e.Graphics.DrawLines(the_pen, points)

                    Text = "Qty"
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                    TextX = CurrentX + (70 - TextLen) / 2
                    TextY = CurrentY + 3
                    e.Graphics.DrawString(Text, Font, InvoBrush, TextX + 1, TextY) 'Print Qty

                    Text = "Ordered"
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                    TextX = CurrentX + (70 - TextLen) / 2
                    TextY = CurrentY + 18
                    e.Graphics.DrawString(Text, Font, InvoBrush, TextX + 1, TextY) 'Print Ordered

                    CurrentX = CurrentX + 70
                    points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 525)} '3rd lower vertical line
                    e.Graphics.DrawLines(the_pen, points)

                    Text = "Qty"
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                    TextX = CurrentX + (70 - TextLen) / 2
                    TextY = CurrentY + 3
                    e.Graphics.DrawString(Text, Font, InvoBrush, TextX + 2, TextY) 'Print Qty

                    Text = "Shipped"
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                    TextX = CurrentX + (70 - TextLen) / 2
                    TextY = CurrentY + 18
                    e.Graphics.DrawString(Text, Font, InvoBrush, TextX + 3, TextY) 'Print Shipped

                    CurrentX = CurrentX + 70
                    points = {New Point(CurrentX, CurrentY), New Point(CurrentX, CurrentY + 525)} '4th lower vertical line
                    e.Graphics.DrawLines(the_pen, points)

                    Text = "Description"
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                    TextX = CurrentX + (350 - TextLen) / 2
                    e.Graphics.DrawString(Text, Font, InvoBrush, TextX + 2, TextY) 'Print Description

                    CurrentX = CurrentX + 350
                    points = {New Point(CurrentX, CurrentY), New Point(CurrentX, HardY2)} '5th lower vertical line
                    e.Graphics.DrawLines(the_pen, points)

                    Text = "Unit Price"
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                    TextX = CurrentX + (100 - TextLen) / 2
                    e.Graphics.DrawString(Text, Font, InvoBrush, TextX + 2, TextY) 'Print unit price

                    CurrentX = CurrentX + 100
                    points = {New Point(CurrentX, CurrentY), New Point(CurrentX, HardY2)} '6th lower vertical line
                    e.Graphics.DrawLines(the_pen, points)

                    Text = "Extended Price"
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                    TextX = CurrentX + (112 - TextLen) / 2
                    e.Graphics.DrawString(Text, Font, InvoBrush, TextX + 2, TextY) 'Print extended price

                    points = {New Point(HardX1, CurrentY + 35), New Point(HardX2, CurrentY + 35)} '4th horzontal Line
                    e.Graphics.DrawLines(the_pen, points)

                    CurrentY = HardY1 + 913 'CurrentY = 5th horizontal line
                    points = {New Point(HardX1, CurrentY), New Point(HardX2, CurrentY)} '5th horzontal Line
                    e.Graphics.DrawLines(the_pen, points)

                    CurrentY = HardY1 + 938 'CurrentY = 6th horzontal Line
                    points = {New Point(HardX1 + 590, CurrentY), New Point(HardX2, CurrentY)} '6th horzontal Line
                    e.Graphics.DrawLines(the_pen, points)

                    CurrentY = HardY2 - 48 'CurrentY = 7th horzontal Line
                    points = {New Point(HardX1 + 590, HardY2 - 48), New Point(HardX2, CurrentY)} '7th horzontal Line
                    e.Graphics.DrawLines(the_pen, points)

                    If PageNumber = 1 Then 'Invoice
                        Text = "Sub Total"
                        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                        TextX = HardX1 + 688 - TextLen
                        e.Graphics.DrawString(Text, Font, InvoBrush, TextX, HardY1 + 919) 'Print label sub total

                        Text = "Misc. Charges"
                        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                        TextX = HardX1 + 688 - TextLen
                        e.Graphics.DrawString(Text, Font, InvoBrush, TextX, HardY1 + 948) 'Print label misc. charges 

                        Text = "Sales Tax"
                        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                        TextX = HardX1 + 688 - TextLen
                        e.Graphics.DrawString(Text, Font, InvoBrush, TextX, HardY1 + 965) 'Print label sales tax

                        Text = "Freight"
                        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                        TextX = HardX1 + 688 - TextLen
                        e.Graphics.DrawString(Text, Font, InvoBrush, TextX, HardY1 + 982) 'Print label freight 

                        Text = "Total"
                        Font = New Font("Arial", 11, FontStyle.Bold)
                        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                        TextX = HardX1 + 688 - TextLen
                        e.Graphics.DrawString(Text, Font, InvoBrush, TextX, HardY1 + 1024) 'Print label total

                        Text = "Thank You"
                        Font = New Font("Edwardian Script ITC", 22, FontStyle.Regular)
                        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                        TextX = HardX1 + 545 - TextLen
                        TextY = CurrentY + 5
                        e.Graphics.DrawString(Text, Font, InvoBrush, TextX, TextY) 'Print label total
                    Else 'Packing list
                        Text = "Packing List"
                        Font = New Font("Arial", 48, FontStyle.Regular)
                        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                        Dim textHeight = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Height)
                        e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + (560 - TextLen) / 2, HardY2 - 105) 'Print label packing list
                    End If
                End Using ' the_pen 

                'Fill form with data
                If (System.IO.File.Exists(InvImage)) Then 'Draw Logo image
                    Dim oInvImage As Bitmap = New Bitmap(InvImage)
                    e.Graphics.DrawImage(oInvImage, HardX1 + 30, HardY1 + 25)
                End If

                'Print Company data under logo
                CurrentX = HardX1 + 233 : CurrentY = HardY1 + 123
                Font = New Font("Microsoft Sans Serif", 12, FontStyle.Regular)
                e.Graphics.DrawString(lbl_CompanyAddress.Text, Font, InvoBrush, CurrentX, CurrentY) 'Print company address
                CurrentY = CurrentY + Font.Height
                e.Graphics.DrawString(lbl_CompanyCity.Text, Font, InvoBrush, CurrentX, CurrentY) 'Print company city, state, zipcode
                Font = New Font("Ariel", 10, FontStyle.Regular)
                CurrentY = CurrentY + Font.Height + 4
                e.Graphics.DrawString(lbl_CompanyPhone.Text, Font, InvoBrush, CurrentX + 27, CurrentY) 'Print company phone

                'Print invoice number
                e.Graphics.DrawString(lbl_InvoiceNumber.Text, Font, InvoBrush, HardX1 + 727, HardY1 + 22)

                'Print Sold To & Ship to data
                CurrentY = HardY1 + 252
                e.Graphics.DrawString(tbox_SoldToName.Text, Font, InvoBrush, HardX1 + 96, CurrentY) 'Sold to 
                e.Graphics.DrawString(tbox_ShipToName.Text, Font, InvoBrush, HardX1 + 506, CurrentY) 'Ship to 
                CurrentY = CurrentY + Font.Height + 3
                e.Graphics.DrawString(tbox_SoldToAddress.Text, Font, InvoBrush, HardX1 + 96, CurrentY) 'Sold to address
                e.Graphics.DrawString(tbox_ShipToAddress.Text, Font, InvoBrush, HardX1 + 506, CurrentY) 'Ship to address
                CurrentY = CurrentY + Font.Height + 3
                e.Graphics.DrawString(tbox_SoldToState.Text, Font, InvoBrush, HardX1 + 96, CurrentY) 'Sold to city, state, zipcode
                e.Graphics.DrawString(tbox_ShipToState.Text, Font, InvoBrush, HardX1 + 506, CurrentY) 'Ship to city, state, zipcode

                'Print purchase order number
                CurrentY = HardY1 + 368
                Text = tbox_PurchaseOrder.Text
                TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 38 + (172 - TextLen) / 2, CurrentY)

                'Print invoice date
                Text = tbox_InvoiceDate.Text
                TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 210 + (125 - TextLen) / 2, CurrentY)

                'Print date shipped
                Text = tbox_DateShipped.Text
                TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 335 + (125 - TextLen) / 2, CurrentY)

                'Print shipped via
                Text = tbox_ShipVia.Text
                TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 460 + (134 - TextLen) / 2, CurrentY)

                'Print terms
                Text = tbox_Terms.Text
                TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 594 + (124 - TextLen) / 2, CurrentY)

                'Print discount
                If PageNumber = 1 Then If cbx_Discount.Checked = True Then e.Graphics.DrawString("Yes", Font, InvoBrush, HardX1 + 727, CurrentY)

                'Print lower form data
                CurrentY = HardY1 + 453 '4th line + 30
                For intStep = 0 To ItemCount - 1

                    'Print item number
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(intStep, Font).Width)
                    e.Graphics.DrawString(intStep + 1, Font, InvoBrush, HardX1 + (50 - TextLen) / 2, CurrentY)

                    'Print purchase order line item number
                    Text = tbox_POItem(intStep).Text
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(intStep, Font).Width)
                    e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 50 + (50 - TextLen) / 2, CurrentY)

                    'Print Qty ordered
                    Text = tbox_QtyOrdered(intStep).Text
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                    e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 100 + (70 - TextLen) / 2, CurrentY)

                    'Print Qty shipped
                    Text = tbox_QtyShipped(intStep).Text
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                    e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 170 + (70 - TextLen) / 2, CurrentY)

                    'Print description line 1
                    Text = tbox_DescripA(intStep).Text
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                    e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 240 + (350 - TextLen) / 2, CurrentY)

                    'Print description line 2
                    If tbox_DescripB(intStep).Text <> "" Then
                        Text = tbox_DescripB(intStep).Text
                        CurrentY = CurrentY + Font.Height + 3
                        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                        e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 240 + (350 - TextLen) / 2, CurrentY)
                    End If

                    'Print description line 3
                    If tbox_DescripC(intStep).Text <> "" Then
                        Text = tbox_DescripC(intStep).Text
                        CurrentY = CurrentY + Font.Height + 3
                        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                        e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 240 + (350 - TextLen) / 2, CurrentY)
                    End If

                    'Print Material heat with lot id
                    If tbox_MaterialHeat(intStep).Visible = True Then
                        Text = lbl_MaterialHeat(intStep).Text & " " & tbox_MaterialHeat(intStep).Text & "   " & lbl_LotId(intStep).Text
                        CurrentY = CurrentY + Font.Height + 3
                        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                        e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 243 + (350 - TextLen) / 2, CurrentY)
                    End If

                    If PageNumber = 1 Then
                        'Print unit price
                        Text = tbox_Price(intStep).Text
                        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                        e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 590 + (100 - TextLen) / 2, CurrentY)

                        'Print extended price
                        Text = lbl_ExtendedPrice(intStep).Text
                        TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                        e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 690 + (110 - TextLen) / 2, CurrentY)
                    End If
                    CurrentY = CurrentY + 45
                Next
                If PageNumber = 1 Then
                    'Print sale amount
                    Text = FormatCurrency(lbl_SubTotal.Text)
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                    e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 690 + (110 - TextLen) / 2, HardY1 + 919)

                    'Print freight
                    Text = FormatCurrency(tbox_Freight.Text)
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                    e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 690 + (110 - TextLen) / 2, HardY1 + 982)

                    'Print total
                    Text = FormatCurrency(lbl_Total.Text)
                    TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                    e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 690 + (110 - TextLen) / 2, HardY1 + 1024)

                    If cbx_Discount.Checked = True Then
                        Text = DiscountAmt & "% Discount if paid within " & DiscountDays & " days"
                        e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 150, HardY1 + 975)
                    End If
                End If
            Case 3

                'Create rectangle for border
                border = New Rectangle(HardX1, HardY1, HardWidth, HardHeight)
                e.Graphics.DrawRectangle(blackPen, border)

                'Print label date
                Font = New Font("Arial", 12, FontStyle.Bold)
                e.Graphics.DrawString("Date:", Font, InvoBrush, HardX1 + 640, HardY1 + 20)

                'Print labels Certificate of compliance
                Text = "Certificate of Compliance"
                Font = New Font("Arial", 18, FontStyle.Bold)
                TextLen = Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width)
                e.Graphics.DrawString(Text, Font, InvoBrush, (HardWidth - TextLen) / 2, HardY1 + 250)

                'Print line under Certificate of compliance
                Text = "***************************************************"
                Font = New Font("Arial", 12, FontStyle.Bold)
                e.Graphics.DrawString(Text, Font, InvoBrush, 232, HardY1 + 277)
                e.Graphics.DrawString("To:", Font, InvoBrush, HardX1 + 60, HardY1 + 305) 'Print label to:
                e.Graphics.DrawString("Attn:", Font, InvoBrush, HardX1 + 60, HardY1 + 340) 'Print label attn:
                e.Graphics.DrawString("Subject:  Invoice Number:", Font, InvoBrush, HardX1 + 60, HardY1 + 375) 'Print label subject Invoice no
                e.Graphics.DrawString("Purchase Order No:", Font, InvoBrush, HardX1 + 134, HardY1 + 397) 'Print label purchase order number
                e.Graphics.DrawString("Drawing Number:", Font, InvoBrush, HardX1 + 134, HardY1 + 419) 'Print label drawing number
                e.Graphics.DrawString("Quantity Shipped:", Font, InvoBrush, HardX1 + 134, HardY1 + 441) 'Print label quantity shipped
                e.Graphics.DrawString("Drawing Rev:", Font, InvoBrush, HardX1 + 134, HardY1 + 463) 'Print label drawing rev
                e.Graphics.DrawString("Description:", Font, InvoBrush, HardX1 + 134, HardY1 + 485) 'Print label description

                'Fill form with data
                If (System.IO.File.Exists(InvImage)) Then 'Draw Logo image
                    Dim oInvImage As Bitmap = New Bitmap(InvImage)
                    e.Graphics.DrawImage(oInvImage, HardX1 + 30, HardY1 + 25)
                End If

                'Print Company data under logo
                CurrentX = HardX1 + 233 : CurrentY = HardY1 + 123
                Font = New Font("Microsoft Sans Serif", 12, FontStyle.Regular)
                e.Graphics.DrawString(lbl_CompanyAddress.Text, Font, InvoBrush, CurrentX, CurrentY) 'Print company address
                CurrentY = CurrentY + Font.Height
                e.Graphics.DrawString(lbl_CompanyCity.Text, Font, InvoBrush, CurrentX, CurrentY) 'Print company city, state, zipcode
                Font = New Font("Ariel", 10, FontStyle.Regular)
                CurrentY = CurrentY + Font.Height + 4
                e.Graphics.DrawString(lbl_CompanyPhone.Text, Font, InvoBrush, CurrentX + 27, CurrentY) 'Print company phone

                'Print Subject data
                Font = New Font("Arial", 12, FontStyle.Regular)
                e.Graphics.DrawString(tbox_InvoiceDate.Text, Font, InvoBrush, HardX1 + 687, HardY1 + 20)
                e.Graphics.DrawString(tbox_SoldToName.Text, Font, InvoBrush, HardX1 + 92, HardY1 + 305) 'Print company name
                e.Graphics.DrawString("Incomming Inspection", Font, InvoBrush, HardX1 + 103, HardY1 + 340) 'Print data incoming inspection
                e.Graphics.DrawString(lbl_InvoiceNumber.Text, Font, InvoBrush, HardX1 + 268, HardY1 + 375) 'Print data invoice number
                e.Graphics.DrawString(tbox_PurchaseOrder.Text, Font, InvoBrush, HardX1 + 296, HardY1 + 397) 'Print data purchase order number

                'Test if there are multiple items on this invoice
                CurrentX1 = HardX1 + 280 : CurrentX2 = HardX1 + 282 : CurrentX3 = HardX1 + 246 : CurrentY = HardY1 + 485

                For intstep = 0 To ItemCount - 1
                    'Print data drawing number
                    If intstep = 0 Then Text = lbl_DrawNum(intstep).Text Else Text = " , " & lbl_DrawNum(intstep).Text
                    e.Graphics.DrawString(Text, Font, InvoBrush, CurrentX1, HardY1 + 419)
                    CurrentX1 = CurrentX1 + Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width) - 9

                    'Print data quantity shipped
                    If intstep = 0 Then Text = tbox_QtyShipped(intstep).Text Else Text = " , " & tbox_QtyShipped(intstep).Text
                    e.Graphics.DrawString(Text, Font, InvoBrush, CurrentX2, HardY1 + 441)
                    CurrentX2 = CurrentX2 + Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width) - 9

                    'Print data drawing rev
                    If intstep = 0 Then Text = lbl_DrawRev(intstep).Text Else Text = " , " & lbl_DrawRev(intstep).Text
                    e.Graphics.DrawString(Text, Font, InvoBrush, CurrentX3, HardY1 + 463)
                    CurrentX3 = CurrentX3 + Convert.ToInt32(e.Graphics.MeasureString(Text, Font).Width) - 9

                    'Print description line 1
                    If ItemCount > 1 Then Text = "Item (" & intstep + 1 & ") :  " & tbox_DescripA(intstep).Text Else Text = tbox_DescripA(intstep).Text
                    e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 237, CurrentY)
                    If ItemCount > 1 Then CurrentX = HardX1 + 309 Else CurrentX = HardX1 + 237

                    'Print description line 2
                    Text = tbox_DescripB(intstep).Text
                    If Text <> "" Then
                        CurrentY = CurrentY + Font.Height + 3
                        e.Graphics.DrawString(Text, Font, InvoBrush, CurrentX, CurrentY)
                    End If

                    'Print description line 3
                    Text = tbox_DescripC(intstep).Text
                    If Text <> "" Then
                        CurrentY = CurrentY + Font.Height + 3
                        e.Graphics.DrawString(Text, Font, InvoBrush, CurrentX, CurrentY)
                    End If

                    'Print Material heat with lot id
                    If tbox_MaterialHeat(intstep).Visible = True Then
                        Text = lbl_MaterialHeat(intstep).Text & " " & tbox_MaterialHeat(intstep).Text & "   " & lbl_LotId(intstep).Text
                        CurrentY = CurrentY + Font.Height + 3
                        e.Graphics.DrawString(Text, Font, InvoBrush, CurrentX, CurrentY)
                    End If

                    CurrentY = CurrentY + 30
                Next

                'Print Certificate of compliance statement
                CurrentY = CurrentY + 40
                Font = New Font("Arial", 12, FontStyle.Bold)
                Text = "We hereby certify that the above mentioned parts and quantities are"
                e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 145, CurrentY)
                Text = "in conformance with the specifications and requirements called for on the"
                CurrentY = CurrentY + Font.Height + 3
                e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 102, CurrentY)
                Text = "drawing pertaining to the subject order."
                CurrentY = CurrentY + Font.Height + 3
                e.Graphics.DrawString(Text, Font, InvoBrush, HardX1 + 102, CurrentY)

                'Print Signature statement
                CurrentY = CurrentY + 60
                e.Graphics.DrawString("Very truly yours,", Font, InvoBrush, HardX1 + 490, CurrentY)
                CurrentY = CurrentY + 60
                e.Graphics.DrawString(Agent, Font, InvoBrush, HardX1 + 490, CurrentY)
                CurrentY = CurrentY + Font.Height + 3
                e.Graphics.DrawString("Quality Control Manager", Font, InvoBrush, HardX1 + 490, CurrentY)

        End Select
        If Pages = False Then Exit Sub
        PageNumber += 1
        e.HasMorePages = PageNumber <= 3

    End Sub


    'All control actions
    Private Sub cmd_Search_Click(sender As Object, e As EventArgs) Handles cmd_Search.Click
        If tbox_Search.Text = "" Then Exit Sub
        cmd_Search.Enabled = False
        booRestore = False
        Call DataFill()
    End Sub
    Private Sub cmd_Action_Click(sender As Object, e As EventArgs) Handles cmd_Action1.Click, cmd_Action2.Click, cmd_Action3.Click
        On Error GoTo goActionErr

        Select Case sender.Text
            Case "Edit"

                'Test if invoice allowed to be edited
                If Not IsDBNull(dbDataSet.Tables("InvoiceData").Rows(0).Item(20)) Then 'Invoice showing has been paid
                    If dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(11) = False Then 'System set to not allow Paid invoices to be re-invoiced
                        frm_Message.Text = "9:1:0:1:2:Paid invoices are not allow to be changed"
                        frm_Message.ShowDialog()
                        Exit Sub
                    End If
                End If

                tbox_Search.Enabled = False
                Call EnableEdits(True)
                Call EnablePrint(False)
                Call MaterialHeatEdit()
                cmd_Action1.Enabled = False
                cmd_Action2.Enabled = True
                cmd_Search.Enabled = False
                cbx_ChangeCustomer.Checked = False
                cbx_ChangeCustomer.Visible = True
                cbx_ChangeCustomer.Focus()
            Case "Cancel"
                booRestore = False
                Call DataFill()
                cmd_Action1.Text = "Edit"
                cmd_Action1.Enabled = True
                cmd_Action2.Enabled = False
                cmd_Action3.Text = "Exit"
                Call EnableEdits(False)
                Call EnablePrint(True)
                tbox_Search.Enabled = True
                cmd_Search.Enabled = True
                cbx_ChangeCustomer.Visible = False
                tbox_Search.Focus()
            Case "Restore"
                booRestore = True
                Call DataFill()
                tbox_Terms.Text = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(5) 'Payment terms
                cbx_ChangeCustomer.Visible = True
                cmd_Action1.Enabled = False
                cmd_Action3.Text = "Exit"
            Case "Save"

                'Validate entries      
                If Trim(tbox_PurchaseOrder.Text) = "" Then
                    tbox_PurchaseOrder.BackColor = Color.Aqua
                    frm_Message.Text = "9:1:0:1:2:Purchase Order number must be entered"
                    frm_Message.ShowDialog()
                    tbox_PurchaseOrder.BackColor = (Color.FromArgb(255, 255, 192))
                    tbox_PurchaseOrder.Focus()
                    Exit Sub
                End If
                If tbox_InvoiceDate.Text = "  /  /" Then
                    tbox_InvoiceDate.BackColor = Color.Aqua
                    frm_Message.Text = "9:1:0:1:2:Invoice Date must be entered"
                    frm_Message.ShowDialog()
                    tbox_InvoiceDate.BackColor = (Color.FromArgb(255, 255, 192))
                    tbox_InvoiceDate.Focus()
                    tbox_InvoiceDate.SelectionStart = 0
                    Exit Sub
                End If
                If tbox_DateShipped.Text = "  /  /" Then
                    tbox_DateShipped.BackColor = Color.Aqua
                    frm_Message.Text = "9:1:0:1:2:Date Shipped must be entered"
                    frm_Message.ShowDialog()
                    tbox_DateShipped.BackColor = (Color.FromArgb(255, 255, 192))
                    tbox_DateShipped.Focus()
                    tbox_DateShipped.SelectionStart = 0
                    Exit Sub
                End If
                If Trim(tbox_Terms.Text) = "" Then
                    tbox_Terms.BackColor = Color.Aqua
                    frm_Message.Text = "9:1:0:1:2:Terms must be entered"
                    frm_Message.ShowDialog()
                    tbox_Terms.BackColor = (Color.FromArgb(255, 255, 192))
                    tbox_Terms.Focus()
                    Exit Sub
                End If
                If Trim(tbox_QtyOrdered(0).Text) = "" Then
                    tbox_QtyOrdered(0).BackColor = Color.Aqua
                    frm_Message.Text = "9:1:0:1:3:Item Quantity Ordered must be entered for all items listed"
                    frm_Message.ShowDialog()
                    tbox_QtyOrdered(0).BackColor = (Color.FromArgb(255, 255, 192))
                    tbox_QtyOrdered(0).Focus()
                    Exit Sub
                End If
                If Trim(tbox_QtyShipped(0).Text) = "" Then
                    tbox_QtyShipped(0).BackColor = Color.Aqua
                    frm_Message.Text = "9:1:0:1:3:Item Quantity Shipped must be entered for all items listed"
                    frm_Message.ShowDialog()
                    tbox_QtyShipped(0).BackColor = (Color.FromArgb(255, 255, 192))
                    tbox_QtyShipped(0).Focus()
                    Exit Sub
                End If
                If Trim(tbox_DescripA(0).Text) = "" Then
                    tbox_DescripA(0).BackColor = Color.Aqua
                    frm_Message.Text = "9:1:0:1:3:Item Description line 1 must be entered for all items listed"
                    frm_Message.ShowDialog()
                    tbox_DescripA(0).BackColor = (Color.FromArgb(255, 255, 192))
                    tbox_DescripA(0).Focus()
                    Exit Sub
                End If
                If Trim(tbox_Price(0).Text) = "" Then
                    tbox_Price(0).BackColor = Color.Aqua
                    frm_Message.Text = "9:1:0:1:3:Item Price must be entered for all items listed"
                    frm_Message.ShowDialog()
                    tbox_Price(0).BackColor = (Color.FromArgb(255, 255, 192))
                    tbox_Price(0).Focus()
                    Exit Sub
                End If

                'Save form to database              
                Dim sngAmt As Double
                Dim intStep As Integer
                For intStep = 0 To ItemCount - 1
                    Dim cb0 As New OleDb.OleDbCommandBuilder(dbAdapter)
                    dbDataSet.Tables("InvoiceData").Rows(intStep).Item(1) = tbox_CustCode.Text 'Custcode

                    If tbox_InvoiceDate.Text <> "  /  /" Then : dbDataSet.Tables("InvoiceData").Rows(intStep).Item(3) = tbox_InvoiceDate.Text 'Invoice date
                    Else : dbDataSet.Tables("InvoiceData").Rows(intStep).Item(3) = DBNull.Value : End If
                    dbDataSet.Tables("InvoiceData").Rows(intStep).Item(4) = Trim(tbox_PurchaseOrder.Text) 'Purchase order
                    If tbox_POItem(intStep).Text <> "" Then dbDataSet.Tables("InvoiceData").Rows(intStep).Item(5) = tbox_POItem(intStep).Text 'Purchase order line item number
                    If tbox_DateShipped.Text <> "  /  /" Then : dbDataSet.Tables("InvoiceData").Rows(intStep).Item(8) = tbox_DateShipped.Text 'Ship date
                    Else : dbDataSet.Tables("InvoiceData").Rows(intStep).Item(8) = DBNull.Value : End If
                    dbDataSet.Tables("InvoiceData").Rows(intStep).Item(9) = tbox_QtyOrdered(intStep).Text 'Quantity ordered
                    dbDataSet.Tables("InvoiceData").Rows(intStep).Item(10) = tbox_QtyShipped(intStep).Text 'Quantity shipped
                    dbDataSet.Tables("InvoiceData").Rows(intStep).Item(11) = tbox_DescripA(intStep).Text 'Description line 1
                    If tbox_DescripB(intStep).Text <> "" Then dbDataSet.Tables("InvoiceData").Rows(intStep).Item(12) = tbox_DescripB(intStep).Text 'Description line 2
                    If tbox_DescripC(intStep).Text <> "" Then dbDataSet.Tables("InvoiceData").Rows(intStep).Item(13) = tbox_DescripC(intStep).Text 'Description line 3
                    sngAmt = Convert.ToDouble(System.Text.RegularExpressions.Regex.Replace(tbox_Price(intStep).Text, "[$,]", "")) 'Convert price
                    dbDataSet.Tables("InvoiceData").Rows(intStep).Item(14) = sngAmt 'Price
                    If intStep = 0 And tbox_Freight.Text <> "" Then 'Add freight only to one item on invoice
                        sngAmt = Convert.ToDouble(System.Text.RegularExpressions.Regex.Replace(tbox_Freight.Text, "[$,]", "")) 'Convert freight
                        dbDataSet.Tables("InvoiceData").Rows(intStep).Item(15) = sngAmt 'Freight
                    Else 'Freight handled on first item, delete any other freight if original invoice had freight on individual items
                        dbDataSet.Tables("InvoiceData").Rows(intStep).Item(15) = DBNull.Value
                    End If
                    If cbx_Discount.Checked = True Then
                        dbDataSet.Tables("InvoiceData").Rows(intStep).Item(16) = DiscountAmt 'Discount amount
                        dbDataSet.Tables("InvoiceData").Rows(intStep).Item(17) = DiscountAmt 'Discount days
                    Else
                        dbDataSet.Tables("InvoiceData").Rows(intStep).Item(16) = DBNull.Value
                        dbDataSet.Tables("InvoiceData").Rows(intStep).Item(17) = DBNull.Value
                    End If
                    dbDataSet.Tables("InvoiceData").Rows(intStep).Item(18) = tbox_ShipVia.Text 'Ship via
                    If tbox_MaterialHeat(intStep).Text <> "" Then dbDataSet.Tables("InvoiceData").Rows(intStep).Item(19) = tbox_MaterialHeat(intStep).Text 'Material heat
                    dbAdapter.Update(dbDataSet, "InvoiceData")
                    cb0 = Nothing
                Next

                'Show save completed
                frm_Message.Text = "9:1:0:9:2:All changes have been saved successfuly"
                frm_Message.ShowDialog()

                booRestore = False
                Call DataFill()
                cmd_Action1.Text = "Edit"
                cmd_Action1.Enabled = True
                cmd_Action2.Enabled = False
                cmd_Action3.Text = "Exit"
                Call EnableEdits(False)
                Call EnablePrint(True)
                cbx_ChangeCustomer.Visible = False
            Case "Exit"
                Me.Close()
        End Select
        Exit Sub
goActionErr:
        MsgBox(Err.Description)
        Exit Sub

    End Sub
    Private Sub Checkbox_CheckedChanged(sender As Object, e As EventArgs) Handles cbx_ChangeCustomer.CheckedChanged, cbx_Discount.CheckedChanged
        If booDataChecked = True Then Exit Sub
        Select Case sender.name
            Case "cbx_ChangeCustomer"
                If cbx_ChangeCustomer.Checked = False Then Exit Sub
                cbx_ChangeCustomer.Visible = False
                cbx_ChangeCustomer.Checked = False
                Label_EnterCustcode.Location = New Point(34, 237)
                Label_EnterCustcode.Visible = True
                tbox_CustCode.Visible = True
                tbox_CustCode.Focus()
            Case "cbx_Discount"
                If sender.checked = True Then
                    If Not IsDBNull(dbDataSet.Tables("InvoiceData").Rows(0).Item(13)) Then 'Discount
                        If dbDataSet.Tables("InvoiceData").Rows(0).Item(13) <> 0 Then
                            DiscountAmt = dbDataSet.Tables("InvoiceData").Rows(0).Item(13) 'Saved Discount amount from past
                            DiscountDays = dbDataSet.Tables("InvoiceData").Rows(0).Item(14) 'Saved Discount days from past                           
                        End If
                    Else
                        DiscountAmt = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(9) 'Default discount amount
                        DiscountDays = dbDataSet_SystemData.Tables("SystemData").Rows(0).Item(10) 'Default Discount days 
                    End If
                    cbx_Discount.Checked = True
                    lbl_DiscountMessage.Text = DiscountAmt & "% Discount if paid within " & DiscountDays & " days"
                    lbl_DiscountMessage.Visible = True
                Else
                    lbl_DiscountMessage.Visible = False
                End If
                Call EditSave()
        End Select
    End Sub
    Private Sub cmd_Print_Click(sender As Object, e As EventArgs) Handles cmd_PrintInvoice.Click, cmd_PrintPackingSlip.Click, cmd_PrintCertificate.Click, cmd_PrintAll.Click
        If lbl_InvoiceNumber.Text = "" Then Exit Sub
        Pages = False
        Dim FormType As String = ""
        Select Case sender.name
            Case "cmd_PrintInvoice" : PageNumber = 1 : FormType = "Invoice"
            Case "cmd_PrintPackingSlip" : PageNumber = 2 : FormType = "PackSlip"
            Case "cmd_PrintCertificate" : PageNumber = 3 : FormType = "Certs"
            Case "cmd_PrintAll" : PageNumber = 1 : FormType = "Invoice_Pkg" : Pages = True
        End Select
        If chk_PdfFile.Checked = True Then

            PrintForms = New PrintDocument
            PrintForms.PrinterSettings.PrinterName = PdfPrinter
            PrintForms.PrinterSettings.PrintToFile = True
            PrintForms.PrinterSettings.PrintFileName = PdfPath & "\" & lbl_InvoiceNumber.Text & "_" & FormType & ".pdf"
            PrintForms.Print()

            'Open printer dialog ( Preview)
            ' PrintForms = New PrintDocument
            ' PrintPreviewDialog1.Document = PrintForms
            ' PrintPreviewDialog1.ShowDialog()

            'Print to Microsoft XPS Document Writer
            ' PrintForms = New PrintDocument
            ' PrintForms.PrinterSettings.PrinterName = "Microsoft XPS Document Writer"
            ' PrintForms.PrinterSettings.PrintToFile = True
            ' PrintForms.PrinterSettings.PrintFileName = "C:\Users\MikeL\Desktop\test.xps"
            ' PrintForms.Print()

            'Print to Microsoft Print to PDF
            ' PrintForms = New PrintDocument
            ' PrintForms.PrinterSettings.PrinterName = "Microsoft Print to PDF"
            ' PrintForms.PrinterSettings.PrintToFile = True
            ' PrintForms.PrinterSettings.PrintFileName = "C:\Users\MikeL\Desktop\test1.pdf"
            ' PrintForms.Print()
        Else
            'Print to system printer 
            PrintForms = New PrintDocument
            PrintForms.PrinterSettings.PrintToFile = False
            PrintForms.PrinterSettings.PrinterName = SystemPrinter
            PrintForms.Print()
        End If
    End Sub


    'All texbox handlers
    Private Sub tbox_GotFocus(sender As Object, e As EventArgs) Handles tbox_Search.GotFocus, tbox_CustCode.GotFocus, tbox_SoldToName.GotFocus, tbox_SoldToAddress.GotFocus, tbox_SoldToState.GotFocus, tbox_ShipToName.GotFocus, tbox_ShipToAddress.GotFocus, tbox_ShipToState.GotFocus, tbox_PurchaseOrder.GotFocus, tbox_InvoiceDate.GotFocus, tbox_DateShipped.GotFocus, tbox_ShipVia.GotFocus, tbox_Terms.GotFocus, tbox_Freight.GotFocus
        If booDataChecked = True Then Exit Sub
        strInitEntry = Trim(sender.Text)
        sender.BackColor = (Color.FromArgb(255, 255, 192))
    End Sub
    Private Sub tbox_LostFocus(sender As Object, e As EventArgs) Handles tbox_Search.LostFocus, tbox_CustCode.LostFocus, tbox_SoldToName.LostFocus, tbox_SoldToAddress.LostFocus, tbox_SoldToState.LostFocus, tbox_ShipToName.LostFocus, tbox_ShipToAddress.LostFocus, tbox_ShipToState.LostFocus, tbox_PurchaseOrder.LostFocus, tbox_InvoiceDate.LostFocus, tbox_DateShipped.LostFocus, tbox_ShipVia.LostFocus, tbox_Terms.LostFocus, tbox_Freight.LostFocus
        sender.BackColor = Color.White
        ' If booDataChecked = True Or booCorrection = True Or cmd_Edit2.Focus Then Exit Sub 'Exit on cancel
        If booDataChecked = True Or booCorrection = True Then Exit Sub

        Select Case sender.name
            Case "tbox_Search", "tbox_CustCode", "tbox_POItem", "tbox_QtyOrdered", "tbox_QtyShipped", "tbox_Price", "tbox_Freight"
                If sender.Text <> "" And sender.Text <> strInitEntry Then
                    If Not IsNumeric(sender.Text) Then
                        booCorrection = True
                        frm_Message.Text = "9:1:0:1:3:Invalid Entry --- Numerical entries are only allowed"
                        frm_Message.ShowDialog()
                        sender.text = ""
                        sender.Focus()
                        booCorrection = False
                        Exit Sub
                    Else
                        If sender.name = "tbox_Search" Then
                            cmd_Search.PerformClick()
                        ElseIf sender.name = "tbox_CustCode" Then
                            Call EditSave()
                            Call CompanyFill(Trim(tbox_CustCode.Text))
                            Label_EnterCustcode.Visible = False
                            tbox_CustCode.Visible = False
                            cbx_ChangeCustomer.Checked = False
                            tbox_CustCode.Visible = False
                            cbx_ChangeCustomer.Visible = True
                            cbx_ChangeCustomer.Focus()
                        ElseIf sender.name = "tbox_Price" Or sender.name = "tbox_Freight" Then
                            booCorrection = True
                            sender.text = FormatCurrency(sender.text)
                            booCorrection = False
                        End If
                    End If
                End If

                'Recalculate and format quantity/price change on form
                If sender.name = "tbox_QtyShipped" Or sender.name = "tbox_Price" Or sender.name = "tbox_Freight" Then
                    If Trim(tbox_QtyShipped(sender.tag).Text) <> "" And Trim(tbox_Price(sender.tag).Text) <> "" Then 'Skip if missing any needed values
                        If sender.name = "tbox_QtyShipped" Or sender.name = "tbox_Price" Then
                            lbl_ExtendedPrice(sender.tag).Text = FormatCurrency(tbox_QtyShipped(sender.tag).Text * tbox_Price(sender.tag).Text)
                        End If
                        SubTotal = 0
                        For i = 0 To 2
                            If lbl_ExtendedPrice(i).Text <> "" Then
                                SubTotal = SubTotal + Convert.ToDouble(System.Text.RegularExpressions.Regex.Replace(lbl_ExtendedPrice(i).Text, "[$,]", ""))
                            End If
                        Next
                        If sender.name = "tbox_Freight" Then tbox_Freight.Text = FormatCurrency(tbox_Freight.Text)
                        lbl_SubTotal.Text = FormatCurrency(SubTotal)
                        lbl_Total.Text = FormatCurrency(SubTotal + tbox_Freight.Text)
                    End If
                End If

            Case "tbox_InvoiceDate", "tbox_DateShipped"
                If IsDate(sender.Text) = False And sender.Text <> "  /  /" Then
                    sender.BackColor = Color.Aqua
                    booCorrection = True
                    frm_Message.Text = "9:1:0:1:3:Data entry must be a date, Please enter a valid date"
                    frm_Message.ShowDialog()
                    sender.text = "  /  /"
                    sender.Focus()
                    sender.SelectionStart = 0
                    booCorrection = False
                    Exit Sub
                End If
        End Select
    End Sub
    Private Sub tbox_TextChanged(sender As Object, e As EventArgs) Handles tbox_Search.TextChanged, tbox_CustCode.TextChanged, tbox_SoldToName.TextChanged, tbox_SoldToAddress.TextChanged, tbox_SoldToState.TextChanged, tbox_ShipToName.TextChanged, tbox_ShipToAddress.TextChanged, tbox_ShipToState.TextChanged, tbox_PurchaseOrder.TextChanged, tbox_InvoiceDate.TextChanged, tbox_DateShipped.TextChanged, tbox_ShipVia.TextChanged, tbox_Terms.TextChanged, tbox_Freight.TextChanged
        If booDataChecked = True Then Exit Sub
        cmd_Search.Enabled = True
        If sender.name <> "tbox_Search" Then Call EditSave()
    End Sub
    Private Sub tbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbox_Search.KeyPress, tbox_CustCode.KeyPress, tbox_SoldToName.KeyPress, tbox_SoldToAddress.KeyPress, tbox_SoldToState.KeyPress, tbox_ShipToName.KeyPress, tbox_ShipToAddress.KeyPress, tbox_ShipToState.KeyPress, tbox_PurchaseOrder.KeyPress, tbox_InvoiceDate.KeyPress, tbox_DateShipped.KeyPress, tbox_ShipVia.KeyPress, tbox_Terms.KeyPress, tbox_Freight.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            Select Case sender.name
                Case "tbox_SoldToName" : tbox_SoldToAddress.Focus()
                Case "tbox_SoldToAddress" : tbox_SoldToState.Focus()
                Case "tbox_SoldToState" : tbox_ShipToName.Focus()
                Case "tbox_ShipToName" : tbox_ShipToAddress.Focus()
                Case "tbox_ShipToAddress" : tbox_ShipToState.Focus()
                Case "tbox_ShipToState" : tbox_PurchaseOrder.Focus()
                Case "tbox_PurchaseOrder" : tbox_InvoiceDate.Focus()
                Case "tbox_InvoiceDate" : tbox_DateShipped.Focus()
                Case "tbox_DateShipped" : tbox_ShipVia.Focus()
                Case "tbox_ShipVia" : tbox_Terms.Focus()
                Case "tbox_Terms" : tbox_POItem(0).Focus()
                Case "tbox_POItem" : tbox_QtyOrdered(0).Focus()
                Case "tbox_QtyOrdered" : tbox_QtyShipped(sender.tag).Focus()
                Case "tbox_QtyShipped" : tbox_DescripA(sender.tag).Focus()
                Case "tbox_DescripA"
                    If tbox_DescripB(sender.tag).Text <> "" Then
                        tbox_DescripB(sender.tag).Focus()
                    Else
                        If tbox_DescripC(sender.tag).Text <> "" Then
                            tbox_DescripC(sender.tag).Focus()
                        Else
                            If tbox_MaterialHeat(sender.tag).Text <> "" Then
                                tbox_MaterialHeat(sender.tag).Focus()
                            Else
                                tbox_Price(sender.tag).Focus()
                            End If
                        End If
                    End If
                Case "tbox_DescripB"
                    If tbox_DescripC(sender.tag).Text <> "" Then
                        tbox_DescripC(sender.tag).Focus()
                    Else
                        If tbox_MaterialHeat(sender.tag).Text <> "" Then
                            tbox_MaterialHeat(sender.tag).Focus()
                        Else
                            tbox_Price(sender.tag).Focus()
                        End If
                    End If
                Case "tbox_DescripC"
                    If tbox_MaterialHeat(sender.tag).Text <> "" Then
                        tbox_MaterialHeat(sender.tag).Focus()
                    Else
                        tbox_Price(sender.tag).Focus()
                    End If
                Case "tbox_MaterialHeat" : tbox_Price(sender.tag).Focus()
                Case "tbox_Price"
                    If sender.tag = 2 Then
                        tbox_Freight.Focus()
                    Else
                        If tbox_QtyOrdered(sender.tag + 1).Text <> "" Then
                            tbox_QtyOrdered(sender.tag + 1).Focus()
                        Else
                            tbox_Freight.Focus()
                        End If
                    End If
                Case "tbox_Freight" : tbox_SoldToName.Focus()
                Case "tbox_Search" : If sender.text <> "" Then cmd_Action3.Focus() : tbox_Search.Focus()
                Case "tbox_CustCode" : If sender.text <> "" Then cmd_Action3.Focus() : tbox_CustCode.Focus()
            End Select
        End If
    End Sub
    Private Sub EditSave()
        cmd_Action1.Text = "Restore"
        cmd_Action1.Enabled = True
        cmd_Action3.Text = "Save"
        ' cmd_Edit3.Image = My.Resources.Resources.Save
    End Sub


    'All mouse movement and mouse over messages
    Private Sub tbox_MouseClick(sender As Object, e As MouseEventArgs) Handles tbox_InvoiceDate.MouseClick, tbox_DateShipped.MouseClick
        If sender.text = "  /  /" Then sender.SelectionStart = 0
    End Sub
    Private Sub fra_MouseMove() Handles fra_SearchCriteria.MouseMove, fra_InvoiceDisplay.MouseMove, fra_InvoiceDisplay.MouseMove 'Clear message
        intMessage = 0
        Call MouseMessages()
    End Sub
    Private Sub All_MouseHover(sender As Object, e As EventArgs) Handles cmd_Search.MouseHover, cmd_PrintInvoice.MouseHover, cmd_PrintPackingSlip.MouseHover, cmd_PrintCertificate.MouseHover, cmd_PrintAll.MouseHover, tbox_Search.MouseHover
        Select Case sender.name
            Case "Listbox_Search" : intMessage = 1
            Case "opt_InvoiceNumber" : intMessage = 2
            Case "opt_PurchaseOrder" : intMessage = 3
            Case "opt_DrawNumber" : intMessage = 4
            Case "opt_MaterialHeat" : intMessage = 5
            Case "opt_LotId" : intMessage = 6
            Case "opt_InvoiceDate" : intMessage = 7
            Case "opt_ShipDate" : intMessage = 8
            Case "cmd_Search" : intMessage = 9
            Case "cmd_Print" : intMessage = 10
            Case "tbox_Search" : intMessage = 11
        End Select
        Call MouseMessages()
    End Sub
    Private Sub MouseMessages()
        Select Case intMessage
            Case 0 : lbl_Message1.Text = "" : lbl_Message2.Text = "" 'Clear messages from screen
            Case 1 : lbl_Message1.Text = "Select invoice number from list to view in form"
            Case 2 : lbl_Message1.Text = "Select this option to locate an individual invoice"
            Case 3 : lbl_Message1.Text = "Select this option to locate all invoices sharing the same purchase order"
            Case 4 : lbl_Message1.Text = "Select this option to locate all invoices sharing the same drawing number"
                lbl_Message2.Text = "Adding drawing revision will refine search to only the selected revision"
            Case 5 : lbl_Message1.Text = "Select this option to locate all invoices sharing the same Material Heat"
            Case 6 : lbl_Message1.Text = "Select this option to locate the invoice sharing the selected lot Id"
            Case 7 : lbl_Message1.Text = "Select this option to locate all invoices sharing the same invoice date"
            Case 8 : lbl_Message1.Text = "Select this option to locate all invoices sharing the same shipping date"
            Case 9 : lbl_Message1.Text = "Press this button to start a search on the entered Search Criteria"
            Case 10 : lbl_Message1.Text = "Press this button to print a copy of the invoice form"
            Case 11 : lbl_Message1.Text = "Enter the data to be used for the selected search"
        End Select
    End Sub

End Class