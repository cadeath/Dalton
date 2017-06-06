Public Class frmFixAceLayaway
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
    Private Sub frmFixAceLayaway_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadPath()
    End Sub

    Private Sub btnFix_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFix.Click
        Disable(1)
        Try

            FixLayAwayBalance("NGB 000003264", 1356)
            FixLayAwayBalance("PGC 000001648", 790)

            MsgBox("Successfull", MsgBoxStyle.Information, "Fixer")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Disable(0)
    End Sub

    Private Sub FixLayAwayBalance(ByVal itmCode As String, ByVal balance As Double)
        Dim mysql As String = "Select * From tblLayAway Where ItemCode = '" & itmCode & "'"
        Dim fillData As String = "tblLayAway"
        Dim ds As DataSet = LoadSQL(mysql, fillData)

        If ds.Tables(0).Rows.Count = 0 Then MsgBox("ItemCode " & itmCode & " Not Found!", MsgBoxStyle.Critical, "Error")

        With ds.Tables(0).Rows(0)
            .Item("Balance") = balance
        End With
        SaveEntry(ds, False)
    End Sub
End Class