Public Class frmFileGen

    Private Sub frmFileGen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Main()
        LoadFiles()
    End Sub

    Private Sub LoadFiles()
        cboConfig.Items.Clear()
        For Each conf In configList
            cboConfig.Items.Add(conf)
        Next
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If cboConfig.Text = "" Then Exit Sub
        Dim mySql As String, ds As New DataSet

        Select Case cboConfig.Text
            Case configList(0)
                mySql = "SELECT * FROM tblCash"
                ds = LoadSQL(mySql, "tblCash")
                ExportConfig(txtPath.Text, ds)
                Console.WriteLine("File Created at " & txtPath.Text)
                MsgBox("Configuration Exported", MsgBoxStyle.Information)
                Exit Select
        End Select
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        If Not sfdConfig.ShowDialog = Windows.Forms.DialogResult.OK Then Exit Sub
        Dim fileSave As String = sfdConfig.FileName
        txtPath.Text = fileSave
    End Sub
End Class