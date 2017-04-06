Module KYCConfig

    Friend LOAD_CACHE As Boolean = False
    Friend listBarangay As List(Of String)
    Friend listCity As List(Of String)
    Friend listZip As List(Of String)

    Friend Const CUSTOMER_TABLE As String = "KYC_CUSTOMERS"
    Friend Const CUSTOMER_ID As String = "KYC_ID"
    Friend Const CUSTOMER_PHONE As String = "KYC_PHONE"

    Friend Sub KYC_Initialization()
        Create_Tables()
        MigrateClients_Info()
    End Sub

    Friend Sub CACHE_MANAGEMENT()
        If LOAD_CACHE Then Exit Sub

        listBarangay = AddList("BRGY1")
        listBarangay.AddRange(AddList("BRGY2"))

        listCity = AddList("CITY1")
        listCity.AddRange(AddList("CITY2"))

        listZip = AddList("ZIP1")
        listZip.AddRange(AddList("ZIP2"))

        LOAD_CACHE = True
    End Sub

    Private Function AddList(colName As String) As List(Of String)
        Dim lst As New List(Of String)
        Dim mySql As String, ds As DataSet


        mySql = String.Format("SELECT DISTINCT {0} FROM {1} ORDER BY {0} ASC", colName, CUSTOMER_TABLE)
        ds = LoadSQL(mySql)

        For Each dr As DataRow In ds.Tables(0).Rows
            lst.Add(dr(colName))
        Next

        Return lst
    End Function


    Private Sub Create_Tables()

    End Sub

    Private Sub MigrateClients_Info()

    End Sub

End Module
