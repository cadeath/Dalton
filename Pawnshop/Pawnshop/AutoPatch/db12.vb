Module db12
    Const ALLOWABLE_VERSION As String = "1.0.13"
    Const LATEST_VERSION As String = "1.2"

    Sub PatchUp()
        Try
            If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub

            Dim mySql As String = "SELECT DAYFROM, DAYTO, ITEMTYPE, INTEREST, PENALTY, REMARKS FROM TBLINT"
            Dim ds As DataSet = LoadSQL(mySql)
            Dim INT_HASH As String = GetMD5(ds)
            
            frmPawnItem.Storing_Hash(INT_HASH)

            Database_Update(LATEST_VERSION)
            Log_Report("SYSTEM PATCHED UP TO " & LATEST_VERSION)
        Catch ex As Exception
            Log_Report(ex.ToString)
        End Try
    End Sub
End Module