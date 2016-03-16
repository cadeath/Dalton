Module Fixing_Mlang

    Private _tblAffected(11) As Dictionary(Of String, Dictionary(Of String, String))

    Private Sub MLang_Initialization()
        Dim fieldNames As New Dictionary(Of String, String)
        fieldNames.Add("BRWID", "Integer")
        _tblAffected(0).Add("TBLBORROW", fieldNames)

        fieldNames.Clear()
        fieldNames.Add("CCID", "BIGINT")
        fieldNames.Add("DAILYID", "BIGINT")
        _tblAffected(1).Add("TBLCASHCOUNT", fieldNames)

        fieldNames.Clear()
        fieldNames.Add("TRANSID", "BIGINT")
        _tblAffected(2).Add("TBLCASHTRANS", fieldNames)

        fieldNames.Clear()
        fieldNames.Add("ID", "BIGINT")
        _tblAffected(3).Add("TBLCHARGE", fieldNames)

        fieldNames.Clear()
        fieldNames.Add("CLIENTID", "BIGINT")
        _tblAffected(4).Add("TBLCLIENT", fieldNames)

        fieldNames.Clear()
        fieldNames.Add("ID", "BIGINT")
        _tblAffected(5).Add("TBLDAILY", fieldNames)

        fieldNames.Clear()
        fieldNames.Add("DOLLARID", "BIGINT")
        _tblAffected(6).Add("TBLDOLLAR", fieldNames)

        fieldNames.Clear()
        fieldNames.Add("CLIENTID", "BIGINT")
        _tblAffected(7).Add("TBLIDENTIFICATION", fieldNames)

        fieldNames.Clear()
        fieldNames.Add("INSURANCEID", "BIGINT")
        fieldNames.Add("COINO", "BIGINT")
        fieldNames.Add("PAWNTICKET", "VARCHAR(30)")
        _tblAffected(8).Add("TBLINSURANCE", fieldNames)

        fieldNames.Clear()
        fieldNames.Add("JRL_ID", "BIGINT")
        _tblAffected(9).Add("TBLJOURNAL", fieldNames)

        fieldNames.Clear()
        fieldNames.Add("TRANID", "BIGINT")
        _tblAffected(10).Add("TBLMONEYTRANSFER", fieldNames)

        fieldNames.Clear()
        fieldNames.Add("PAWNID", "BIGINT")
        fieldNames.Add("PAWNTICKET", "BIGINT")
        fieldNames.Add("CLIENTID", "BIGINT")
        _tblAffected(11).Add("TBLPAWN", fieldNames)
    End Sub

    Sub Main()
        For Each tbl In _tblAffected

            Dim mySql As String
            mySql = ""

        Next
    End Sub

End Module