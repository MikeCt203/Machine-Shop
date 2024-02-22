Imports System.Drawing.Printing
Public Class frm_PrinterSelector
    Private Sub frm_printers_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Location
        Me.Top = frm_SystemSetup.Top - 130
        Me.Left = frm_SystemSetup.Left + ((frm_SystemSetup.Width - Me.Width) / 2)

        'Fill listbox with list of all system printers
        Dim pkInstalledPrinters As String

        ' Find all printers installed
        For Each pkInstalledPrinters In
            PrinterSettings.InstalledPrinters
            Listbox_InstalledPrinters.Items.Add(pkInstalledPrinters)
        Next pkInstalledPrinters

        'Set the Listbox to the first printer in the list
        Listbox_InstalledPrinters.SelectedIndex = 0

    End Sub

    Private Sub Listbox_InstalledPrinters_DoubleClick(sender As Object, e As EventArgs) Handles Listbox_InstalledPrinters.DoubleClick
        gbl_StringName = Listbox_InstalledPrinters.SelectedItem
        IsNothing(Me)
        Me.Close()
    End Sub

    Private Sub cmd_Cancel_Click(sender As Object, e As EventArgs) Handles cmd_Cancel.Click
        Me.Close()
    End Sub
End Class