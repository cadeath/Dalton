Imports System.IO

Public Class frmMain2

    Const DBFD As String = "W3W1LH4CKU.FDB"

    Private Sub btnUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdate.Click
        If txtDIR.Text = "" Then Exit Sub

        mod_system.dbName = txtDIR.Text & "\" & DBFD
        Dim mySql As String = "SELECT * FROM tblMaintenance WHERE OPT_KEYS = 'BDOCommissionRate'"
        Dim fillData As String = "tblMaintenance"

        Dim line As String
        ' Create new StreamReader instance with Using block.
        Using reader As StreamReader = New StreamReader("bdo")
            ' Read one line from file
            line = reader.ReadLine
        End Using

        Dim bdoRate As Double = line
        Dim ds As DataSet = LoadSQL(mySql, fillData)
        ds.Tables(fillData).Rows(0).Item("OPT_VALUES") = bdoRate
        mod_system.SaveEntry(ds, False)
        MsgBox("DB Updated", MsgBoxStyle.Information)
    End Sub
End Class