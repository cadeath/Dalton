Public Class frmBackup

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmBackup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadFiles()
        LoadBackupSetup()
    End Sub

    Private Sub LoadBackupSetup()
        Dim bkSwitch As String
        bkSwitch = GetOption("BkTag")

        txtPath1.ReadOnly = IIf(bkSwitch.Substring(0, 1) = "1", False, True)
        txtPath2.ReadOnly = IIf(bkSwitch.Substring(1, 1) = "1", False, True)
        txtPath3.ReadOnly = IIf(bkSwitch.Substring(2, 1) = "1", False, True)

        chkPath1.Enabled = IIf(bkSwitch.Substring(0, 1) = "1", True, False)
        chkPath2.Enabled = IIf(bkSwitch.Substring(1, 1) = "1", True, False)
        chkPath3.Enabled = IIf(bkSwitch.Substring(2, 1) = "1", True, False)
        chkPath1.Checked = IIf(bkSwitch.Split("|")(1).Substring(0, 1) = "1", True, False)
        chkPath2.Checked = IIf(bkSwitch.Split("|")(1).Substring(1, 1) = "1", True, False)
        chkPath3.Checked = IIf(bkSwitch.Split("|")(1).Substring(2, 1) = "1", True, False)

        txtPath1.Text = GetOption("Bk1Path")
        txtPath2.Text = GetOption("Bk2Path")
        txtPath3.Text = GetOption("Bk3Path")
    End Sub

    Private Sub LoadFiles()
        lstFileList.Items.Clear()

        Dim di As New IO.DirectoryInfo(backupPath)
        Dim diar1 As IO.FileInfo() = di.GetFiles()
        Dim dra As IO.FileInfo

        For Each dra In diar1
            If dra.Extension = ".rar" Then
                lstFileList.Items.Add(dra)
            End If
        Next
    End Sub

    Private Sub btnExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExecute.Click

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

    End Sub

    Private Sub btnBrowseFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseFile.Click
        Process.Start(backupPath)
    End Sub
End Class