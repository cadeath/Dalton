Public Class frmLayawayCashOffsetting
    Const DBPATH As String = "\W3W1LH4CKU.FDB"

    Private Sub LoadPath()
        Dim readValue = My.Computer.Registry.GetValue(
    "HKEY_LOCAL_MACHINE\Software\cdt-S0ft\Pawnshop", "InstallPath", Nothing)

        Dim firebird As String = readValue & DBPATH
        database.dbName = firebird
        txtDB.Text = firebird
    End Sub

    Private Sub Disable(ByVal st As Boolean)
        btnFix.Enabled = Not st
    End Sub
    Private Sub frmLayawayCashOffsetting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadPath()
    End Sub

    Private Sub btnFix_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFix.Click
        Disable(1)
        LayawayCashOffsetting()
        Disable(0)
    End Sub

    Private Sub LayawayCashOffsetting()
        Dim mysql As String = "Select * From tblCash Where Category = 'LAY-AWAY PAYMENTS' and Transname = 'Cash Offsetting Account'"
        Dim fillData As String = "tblCash"
        Dim ds As DataSet = LoadSQL(mysql, fillData)
        If ds.Tables(0).Rows.Count = 0 Then
            Dim dsNewRow As DataRow
            dsNewRow = ds.Tables(fillData).NewRow
            With dsNewRow
                .Item("Type") = "Receipt"
                .Item("Category") = "LAY-AWAY PAYMENTS"
                .Item("Transname") = "Cash Offsetting Account"
                .Item("SapAccount") = "_SYS00000001003"
                .Item("Onhold") = 0
            End With
            ds.Tables(fillData).Rows.Add(dsNewRow)
            SaveEntry(ds)
        Else
            ds.Tables(0).Rows(0).Item("SapAccount") = "_SYS00000001003"
            SaveEntry(ds, False)
        End If
        MsgBox("Successfuly Fix!", MsgBoxStyle.Information, "System Data")
    End Sub
End Class