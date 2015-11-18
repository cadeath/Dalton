Public Class frmBackup

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmBackup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadFiles()
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
End Class