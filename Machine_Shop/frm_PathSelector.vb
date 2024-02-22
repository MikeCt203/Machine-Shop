Public Class frm_PathSelector
    Dim FormWidth, FormHeight As Integer
    Dim booForm As Boolean = False

    Private Sub frm_PathSelector_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Size = New Size(FormWidth, FormHeight)
        Me.Top = (Screen.PrimaryScreen.Bounds.Height - Me.Height) / 2
        Me.Left = ((Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2) * 0.975




        Dim Pdf_Path As Object = 0
        Pdf_Path = gbl_StringName
        Dim SaveFileDialog As New SaveFileDialog

        If IsDBNull(Pdf_Path) Then
            SaveFileDialog.InitialDirectory = "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}"
        Else
            If System.IO.Directory.Exists(Pdf_Path) Then
                SaveFileDialog.InitialDirectory = Pdf_Path
            Else
                SaveFileDialog.InitialDirectory = "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}"
            End If
        End If

        If Me.Text = "Pdf" Then
            SaveFileDialog.Filter = "All Files (*.pdf)|*.pdf"
            SaveFileDialog.Title = "Pdf folder path search"
            SaveFileDialog.FileName = ".pdf"
        Else
            SaveFileDialog.Filter = "All Files (*.mdb)|*.mdb"
            SaveFileDialog.Title = "Backup folder path search"
            SaveFileDialog.FileName = ".mdb"
        End If

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            Dim intCount As Integer = InStrRev(FileName, "\", -1)
            gbl_StringName = LSet(FileName, intCount - 1)
        End If
        Me.Close()
    End Sub

    Private Sub frm_PathSelector_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        If booForm = False Then
            FormWidth = Me.Width
            FormHeight = Me.Height
            booForm = True
        End If
    End Sub
End Class