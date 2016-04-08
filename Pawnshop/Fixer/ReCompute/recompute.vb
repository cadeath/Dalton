Module recompute

    Private pawnCompute As PawningDalton
    Private mySql As String

    Private Const PAWNING As String = "TBLPAWN"

    Friend Sub Validate()
        Dim ds As DataSet
        Dim pbMax As Integer = 0
        mySql = "SELECT * FROM " & PAWNING
        mySql &= " STATUS = 'L'"

        ds = LoadSQL(mySql)
        pbMax = ds.Tables(0).Rows.Count
        frmRecompute.pbLoading.Maximum = pbMax

        For Each dr As DataRow In ds.Tables(0).Rows
            pawnCompute = New PawningDalton(dr("principal"), dr("ITEMTYPE"), dr("LOANDATE"), dr("MATUDATE"), False)
        Next
    End Sub


#Region "Log Module"
    Const LOG_FILE As String = "-log.txt"
    Private Sub CreateLog()
        Dim fsEsk As New System.IO.FileStream(Now.ToString("MMddyyyy") & LOG_FILE, IO.FileMode.CreateNew)
        fsEsk.Close()
    End Sub

    Friend Sub Log_Report(ByVal str As String)
        If Not System.IO.File.Exists(Now.ToString("MMddyyyy") & LOG_FILE) Then CreateLog()

        Dim recorded_log As String = _
            String.Format("[{0}] " & str, Now.ToString("MM/dd/yyyy HH:mm:ss"))

        Dim fs As New System.IO.FileStream(Now.ToString("MMddyyyy") & LOG_FILE, IO.FileMode.Append, IO.FileAccess.Write)
        Dim fw As New System.IO.StreamWriter(fs)
        fw.WriteLine(recorded_log)
        fw.Close()
        fs.Close()
        Console.WriteLine("Recored")
    End Sub
#End Region
End Module
