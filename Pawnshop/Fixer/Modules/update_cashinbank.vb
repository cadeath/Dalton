''' <summary>
''' MAY 11, 2016
''' Branches with different CASH IN BANK SAP CODE
''' should be updated using this patch program.
''' </summary>
''' <remarks></remarks>
Module update_cashinbank

    Private TBLNAME As String = "TBLCASH"

    Friend Sub UpdateCashInBank(sys As String)
        Dim mySql As String = _
            "SELECT * FROM " & TBLNAME
        Dim ds As DataSet

        mySql &= " WHERE "
    End Sub

End Module