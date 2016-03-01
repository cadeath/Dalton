Public Class frmMain

    Private ds As DataSet
    Private mySql As String
    Private fillData As String

    Private Sub btnCharges_Click(sender As System.Object, e As System.EventArgs) Handles btnCharges.Click
        fillData = "tblCharge"
        mySql = "SELECT * FROM " & fillData
        mySql &= " ORDER BY ID ASC"

        ds = LoadSQL(mySql, fillData)
        dgvPawnshop.DataSource = ds.Tables(fillData)
    End Sub

    Private Sub btnBranch_Click(sender As System.Object, e As System.EventArgs) Handles btnBranch.Click
        fillData = "tblBranches"
        mySql = "SELECT * FROM " & fillData
        mySql &= " ORDER BY BranchID ASC"

        ds = LoadSQL(mySql, fillData)
        dgvPawnshop.DataSource = ds.Tables(fillData)
    End Sub

    Private Sub tsbtnExport_Click(sender As System.Object, e As System.EventArgs) Handles tsbtnExport.Click
        If dgvPawnshop.DataSource Is Nothing Then Exit Sub
        sfdConfig.ShowDialog()
    End Sub

    Private Sub sfdConfig_FileOk(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles sfdConfig.FileOk
        Dim fn As String = sfdConfig.FileName
        ExportConfig(fn, ds)
    End Sub

    Private Sub ofdConfig_FileOk(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles ofdConfig.FileOk
        Dim fn As String = ofdConfig.FileName
        dgvPawnshop.DataSource = FileChecker(fn)
    End Sub

    Private Sub tsbtnConfig_Click(sender As System.Object, e As System.EventArgs) Handles tsbtnConfig.Click
        ofdConfig.ShowDialog()
    End Sub

    Private Sub tsbtnSave_Click(sender As System.Object, e As System.EventArgs) Handles tsbtnSave.Click
        database.SaveEntry(ds)
        MsgBox("Entry Saved", MsgBoxStyle.Information)
        dgvPawnshop.DataSource = Nothing
    End Sub
End Class
