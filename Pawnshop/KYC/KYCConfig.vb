Module KYCConfig

    Friend LOAD_CACHE As Boolean = False
    Friend listBarangay As List(Of String)
    Friend listCity As List(Of String)
    Friend listProvince As List(Of String)
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
        Dim mySql As String

        mySql = "SELECT DISTINCT BRGY1 AS ""BRGY"" FROM KYC_CUSTOMERS "
        mySql &= vbCrLf & "UNION"
        mySql &= vbCrLf & "SELECT DISTINCT BRGY2 FROM KYC_CUSTOMERS"
        listBarangay = New List(Of String)
        listBarangay.AddRange(AddList(mySql, "BRGY"))

        mySql = "SELECT DISTINCT CITY1 AS ""CITY"" FROM KYC_CUSTOMERS "
        mySql &= vbCrLf & "UNION"
        mySql &= vbCrLf & "SELECT DISTINCT CITY2 FROM KYC_CUSTOMERS"
        listCity = New List(Of String)
        listCity.AddRange(AddList(mySql, "CITY"))

        mySql = "SELECT DISTINCT PROVINCE1 AS ""PROVINCE"" FROM KYC_CUSTOMERS "
        mySql &= vbCrLf & "UNION"
        mySql &= vbCrLf & "SELECT DISTINCT PROVINCE2 FROM KYC_CUSTOMERS"
        listProvince = New List(Of String)
        listProvince.AddRange(AddList(mySql, "PROVINCE"))

        mySql = "SELECT DISTINCT ZIP1 AS ""ZIP"" FROM KYC_CUSTOMERS "
        mySql &= vbCrLf & "UNION"
        mySql &= vbCrLf & "SELECT DISTINCT ZIP2 FROM KYC_CUSTOMERS"
        listZip = New List(Of String)
        listZip.AddRange(AddList(mySql, "ZIP"))

        LOAD_CACHE = True
        Console.WriteLine("Cache already loaded...")
    End Sub

    Private Function AddList(mySql As String, colName As String) As Array
        Dim lst As New List(Of String)
        Dim ds As DataSet

        ds = LoadSQL(mySql)
        If ds.Tables(0).Rows.Count = 0 Then Return {""}

        For Each dr As DataRow In ds.Tables(0).Rows
            lst.Add(dr(colName))
        Next

        Return lst.ToArray
    End Function


    Private Sub Create_Tables()

    End Sub

    Private Sub MigrateClients_Info()

    End Sub

End Module
