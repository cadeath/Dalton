Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Threading

Module cmdFunctions

    Public Sub BranchUpdated()
        Dim data As Byte() = Encoding.UTF8.GetBytes("branch=" & BranchCode)

        Dim respond As String = SendRequest(mysql_database.HTTP_SERVER("sent"), data, "application/x-www-form-urlencoded", "POST")

        Console.WriteLine("Respond: " & respond)
    End Sub

#Region "Cash Count"
    Friend Sub do_ccSave(ByVal dt As Date)
        Dim ds As DataSet = Load_CC(dt)

        Dim th As Thread
        th = New Thread(Sub() save_ccData(dt, ds))
        th.Start()
    End Sub

    Private Sub save_ccData(ByVal dt As Date, ByVal dsCC As DataSet)
        Console.WriteLine(">>Saving to Server")

        mySqlDBopen()

        Dim mySql As String = "SELECT * FROM cashcounts "
        mySql &= vbCrLf & String.Format("WHERE ccdate = '{0}' AND branch_code = '{1}'", dt.ToString("M/d/yy"), BranchCode)
        Console.WriteLine("SQL: " & mySql)

        Dim dsName As String = "cashcounts"
        Dim ds As DataSet = LoadMySQL(mySql, dsName)

        Dim dsNewRow As DataRow
        For Each dr As DataRow In dsCC.Tables(0).Rows
            dsNewRow = ds.Tables(dsName).NewRow
            With dsNewRow
                .Item("branch_code") = BranchCode
                .Item("ccdate") = dt
                .Item("ccname") = dr("ccname")
                .Item("amount") = dr("kupit")
                .Item("created_at") = Now()
                .Item("updated_at") = Now()
            End With
            ds.Tables(dsName).Rows.Add(dsNewRow)
        Next
        mysql_database.SaveEntry_mySql(ds)

        mySqlDBclose()

        BranchUpdated()
    End Sub

    Private Function Load_CC(ByVal dt As Date) As DataSet
        Dim mySql As String
        mySql = "SELECT TRANSDATE, TRANSNAME, "
        mySql &= vbCrLf & "	SUM(DEBIT) AS DEBIT, SUM(CREDIT) AS CREDIT, "
        mySql &= vbCrLf & "    SUM(DEBIT) + SUM(CREDIT) AS KUPIT, CCNAME"
        mySql &= vbCrLf & "FROM JOURNAL_ENTRIES"
        mySql &= vbCrLf & String.Format("WHERE TRANSDATE = '{0}' AND TRANSNAME = 'Revolving Fund' and TODISPLAY = 1", dt.ToString("M/d/yy"))
        mySql &= vbCrLf & "GROUP BY TRANSDATE, TRANSNAME, CCNAME"

        Dim ds As DataSet = LoadSQL(mySql)
        For Each dr As DataRow In ds.Tables(0).Rows
            Console.WriteLine(String.Format("NAME: {0}|AMT: {1}", dr("ccname"), dr("kupit")))
        Next

        Return ds
    End Function
#End Region

#Region "System Functions"
    Public Function GetRand(ByVal min As Integer, ByVal max As Integer) As Integer
        Dim randomInt As Integer
        Dim myRand As New Random
        randomInt = myRand.Next(min, max)
        Return randomInt
    End Function

    Public Function SendRequest(ByVal uri As String, ByVal jsonDataBytes As Byte(), ByVal contentType As String, ByVal method As String) As String
        Dim req As WebRequest = WebRequest.Create(uri)
        req.ContentType = contentType
        req.Method = method
        req.ContentLength = jsonDataBytes.Length


        Dim stream = req.GetRequestStream()
        stream.Write(jsonDataBytes, 0, jsonDataBytes.Length)
        stream.Close()

        Dim response = req.GetResponse().GetResponseStream()

        Dim reader As New StreamReader(response)
        Dim res = reader.ReadToEnd()
        reader.Close()
        response.Close()

        Return res
    End Function
#End Region

End Module
