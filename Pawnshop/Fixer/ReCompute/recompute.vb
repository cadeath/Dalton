Module recompute

    Private pawnCompute As PawningDalton
    Private mySql As String

    Private Const PAWNING As String = "TBLPAWN"

    Friend Sub Validate()
        Dim ds As DataSet
        Dim pbMax As Integer = 0
        Dim LogStr As String = ""

        'DPJ PAWNSHOP NEW LOAN, NOT REMANTIC
        mySql = "SELECT * FROM " & PAWNING
        mySql &= " STATUS = 'L' AND ADVINT <> 0"

        ds = LoadSQL(mySql, PAWNING)
        pbMax = ds.Tables(PAWNING).Rows.Count
        frmRecompute.pbLoading.Maximum = pbMax

        For Each dr As DataRow In ds.Tables(PAWNING).Rows
            pawnCompute = New PawningDalton(dr("principal"), dr("ITEMTYPE"), dr("LOANDATE"), dr("MATUDATE"), True)

            'Verifying Amount Saved
            LogStr = "PT# " & String.Format("{0:000000}", dr("PAWNTICKET"))
            With pawnCompute
                'NETAMOUNT
                If .NetAmount <> dr("NETAMOUNT") Then
                    LogStr &= String.Format("|Php {0:#,##0.00} should be {1:#,##0.00}.", dr("NETAMOUNT"), .NetAmount)
                    dr("NETAMOUNT") = .NetAmount
                End If

                'ADVANCE INTEREST
                If .AdvanceInterest <> dr("ADVINT") Then
                    LogStr &= String.Format("|Php {0:#,##0.00} should be {1:#,##0.00}.", dr("ADVINT"), .AdvanceInterest)
                    dr("ADVINT") = .AdvanceInterest
                End If

                'SERVICE CHARGE
                If .ServiceCharge <> dr("SERVICECHARGE") Then
                    LogStr &= String.Format("|Php {0:#,##0.00} should be {1:#,##0.00}.", dr("SERVICECHARGE"), .ServiceCharge)
                    dr("SERVICECHARGE") = .ServiceCharge
                End If

                'MUST BE ZERO (0) FOR NEW LOAN
                Dim colNames() As String = {"INTEREST", "PENALTY", "RENEWDUE", "REDEEMDUE"}
                For Each colName In colNames
                    If dr(colName) <> 0 Then
                        LogStr &= String.Format("|{0} has Php {1:#,##0.00}. It should be 0", colName, dr(colName))
                        dr(colName) = 0
                    End If
                Next
            End With
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
