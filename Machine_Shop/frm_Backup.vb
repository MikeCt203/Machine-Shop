Public Class frm_Backup
    Dim dbAdapter As OleDb.OleDbDataAdapter
    Dim dbDataSet As New DataSet
    Dim strSQL As String

    Dim FormWidth, FormHeight As Integer
    Dim booForm As Boolean = False

    Private Sub frm_Backup_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Size = New Size(FormWidth, FormHeight)
        Me.Top = (Screen.PrimaryScreen.Bounds.Height - Me.Height) / 2
        Me.Left = ((Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2) * 0.975

        'Retrieve setup information
        strSQL = "SELECT BackupPath,Id FROM System"
        dbDataSet.Clear()
        dbDataSet.Tables.Clear()
        gbl_DstConnect.Open()
        dbAdapter = New OleDb.OleDbDataAdapter(strSQL, gbl_DstConnect)
        dbAdapter.Fill(dbDataSet, "BackupPath")
        gbl_DstConnect.Close()


        'Test for previous backup path
        Dim Backup_Path As Object = 0
        Dim SaveFileDialog As New SaveFileDialog
        Backup_Path = dbDataSet.Tables("BackupPath").Rows(0).Item(0) 'Backup_Path
        If IsDBNull(Backup_Path) Then
            SaveFileDialog.InitialDirectory = "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}"
        Else
            If System.IO.Directory.Exists(Backup_Path) Then
                SaveFileDialog.InitialDirectory = Backup_Path
            Else
                SaveFileDialog.InitialDirectory = "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}"
            End If
        End If

        Dim strDate As String = Replace(Format(Now, "short Date"), "/", "_")
        SaveFileDialog.Filter = "All Files (*.mdb)|*.mdb"
        SaveFileDialog.Title = "Backup"
        SaveFileDialog.FileName = "Database " & strDate

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            Dim intCount As Integer = InStrRev(FileName, "\", -1)
            Dim strPath As String = LSet(FileName, intCount - 1)

            'Update database with backup location if changed
            Cursor.Current = Cursors.WaitCursor
            Dim PathUpdate As Boolean = False
            If Not IsDBNull(Backup_Path) Then
                If strPath <> Backup_Path Then PathUpdate = True
            Else : PathUpdate = True : End If

            If PathUpdate = True Then
                Dim dbBuild As New OleDb.OleDbCommandBuilder(dbAdapter)
                dbDataSet.Tables("BackupPath").Rows(0).Item(30) = strPath
                dbAdapter.Update(dbDataSet, "BackupPath")
            End If

            Try
                My.Computer.FileSystem.CopyFile(gbl_dbPath, FileName, True) 'Backup database
            Catch ex As Exception
                frm_Message.Text = "0:1:3:1:2:Error occured during Backup, Backup not complete"
                frm_Message.ShowDialog()
                Exit Sub
            End Try

            'Validate backup
            If System.IO.File.Exists(FileName) Then
                frm_Message.Text = "0:1:2:2:2:Backup of database in directory ( " & Replace(strPath, ":", "") & " ) is complete"
                frm_Message.ShowDialog()
            Else
                frm_Message.Text = "0:1:3:1:2:Error occured during Backup, Backup not complete"
                frm_Message.ShowDialog()
            End If
            Cursor.Current = Cursors.Default
        End If
        Me.Close()
    End Sub

    Private Sub frm_Backup_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        If booForm = False Then
            FormWidth = Me.Width
            FormHeight = Me.Height
            booForm = True
        End If
    End Sub

End Class