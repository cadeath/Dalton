Module recompute

    Private pawnCompute As PawningDalton
    Private mySql As String

    Private Const PAWNING As String = "TBLPAWN"

    Friend Sub Validate()
        Dim ds As DataSet
        Dim pbMax As Integer = 0, errCnt As Integer = 0, hasError As Boolean = False
        Dim LogStr As String = ""

        database.dbName = frmRecompute.txtDB.Text

        'DPJ PAWNSHOP NEW LOAN, NOT REMANTIC
        mySql = "SELECT * FROM " & PAWNING
        mySql &= " WHERE STATUS = 'L' AND ADVINT <> 0"

        mySql = "SELECT * FROM " & PAWNING
        mySql &= " WHERE STATUS = 'Z'"

        ds = LoadSQL(mySql, PAWNING)
        pbMax = ds.Tables(PAWNING).Rows.Count
        frmRecompute.pbLoading.Maximum = pbMax
        frmRecompute.pbLoading.Value = 0

        StatusUpdate(String.Format("0/{0}", frmRecompute.pbLoading.Maximum))

        'NEW LOAN
        For Each dr As DataRow In ds.Tables(PAWNING).Rows
            pawnCompute = New PawningDalton(dr("PRINCIPAL"), dr("ITEMTYPE"), dr("LOANDATE"), dr("MATUDATE"), True)

            'Verifying Amount Saved
            LogStr = "PT# " & String.Format("{0:000000}", dr("PAWNTICKET"))
            With pawnCompute
                'NETAMOUNT
                If Math.Round(.NetAmount, 2) <> Math.Round(dr("NETAMOUNT"), 2) Then
                    LogStr &= String.Format("|NetAmount - Php {0} should be {1}.", dr("NETAMOUNT"), .NetAmount)
                    dr("NETAMOUNT") = .NetAmount
                    hasError = True
                End If

                'ADVANCE INTEREST
                If Math.Round(.AdvanceInterest, 2) <> Math.Round(dr("ADVINT"), 2) Then
                    LogStr &= String.Format("|AdvInt - Php {0} should be {1}.", dr("ADVINT"), .AdvanceInterest)
                    dr("ADVINT") = .AdvanceInterest
                    hasError = True
                End If

                'SERVICE CHARGE
                If Math.Round(.ServiceCharge, 2) <> Math.Round(dr("SERVICECHARGE"), 2) Then
                    LogStr &= String.Format("|ServiceCharge - Php {0} should be {1}.", dr("SERVICECHARGE"), .ServiceCharge)
                    dr("SERVICECHARGE") = .ServiceCharge
                    hasError = True
                End If

                'MUST BE ZERO (0) FOR NEW LOAN
                Dim colNames() As String = {"INTEREST", "PENALTY", "RENEWDUE", "REDEEMDUE"}
                For Each colName In colNames
                    If dr(colName) <> 0 Then
                        LogStr &= String.Format("|{0} has Php {1}. It should be 0", colName, dr(colName))
                        dr(colName) = 0
                        hasError = True
                    End If
                Next
            End With

            If hasError Then
                Log_Report(LogStr)
                errCnt += 1
            End If
            hasError = False

            Try
                frmRecompute.pbLoading.Value += 1
                StatusUpdate(String.Format("{0}/{1}", frmRecompute.pbLoading.Value, frmRecompute.pbLoading.Maximum))
                Application.DoEvents()
            Catch ex As Exception
                Log_Report(ex.ToString)
            End Try
        Next
        If ds.Tables(0).Rows.Count > 0 Then _
            database.SaveEntry(ds, False)
        'END - NEW LOAN


        ' REMANTIC RENEWAL
        mySql = "SELECT * FROM " & PAWNING
        mySql &= " WHERE"
        mySql &= " (STATUS = '0' OR STATUS = 'R')"
        mySql &= " AND ADVINT <> 0"
        ds.Clear()
        ds = LoadSQL(mySql, PAWNING)

        pbMax = ds.Tables(PAWNING).Rows.Count
        frmRecompute.pbLoading.Maximum = pbMax
        frmRecompute.pbLoading.Value = 0

        For Each dr As DataRow In ds.Tables(PAWNING).Rows
            pawnCompute = New PawningDalton(dr("PRINCIPAL"), dr("ITEMTYPE"), dr("ORDATE"), dr("MATUDATE"), False)

            'Verifying Amount Saved
            LogStr = "PT# " & String.Format("{0:000000}", dr("PAWNTICKET"))
            With pawnCompute
                'RENEW DUE
                If (Math.Round(.RenewDue, 2) <> Math.Round(dr("RENEWDUE"), 2) And dr("STATUS") = "0") Then
                    LogStr &= String.Format("|RenewDue - Php {0} should be {1}.", dr("RENEWDUE"), .RenewDue)
                    dr("RENEWDUE") = .RenewDue
                    hasError = True
                End If

                If (dr("RENEWDUE") > 0 And dr("STATUS") = "R") Then
                    LogStr &= String.Format("|RenewDue - Php {0} should be {1}.", dr("RENEWDUE"), .RenewDue)
                    dr("RENEWDUE") = 0
                    hasError = True
                End If

                'INTEREST
                If Math.Round(.Interest, 2) <> Math.Round(dr("INTEREST"), 2) Then
                    LogStr &= String.Format("|Interest - Php {0} should be {1}.", dr("INTEREST"), .Interest)
                    dr("INTEREST") = .Interest
                    hasError = True
                End If

                'PENALTY
                If Math.Round(.Penalty, 2) <> Math.Round(dr("PENALTY"), 2) Then
                    LogStr &= String.Format("|Penalty - Php {0} should be {1}.", dr("PENALTY"), .Penalty)
                    dr("PENALTY") = .Penalty
                    hasError = True
                End If

                'SERVICE CHARGE
                If Math.Round(.ServiceCharge, 2) <> Math.Round(dr("SERVICECHARGE"), 2) Then
                    LogStr &= String.Format("|ServiceCharge - Php {0} should be {1}.", dr("SERVICECHARGE"), .ServiceCharge)
                    dr("SERVICECHARGE") = .ServiceCharge
                    hasError = True
                End If

                'MUST BE ZERO (0) FOR RENEWAL
                Dim colNames() As String = {"ADVINT", "REDEEMDUE"}
                For Each colName In colNames
                    If dr(colName) <> 0 Then
                        LogStr &= String.Format("|{0} has Php {1}. It should be 0", colName, dr(colName))
                        dr(colName) = 0
                        hasError = True
                    End If
                Next
            End With

            If hasError Then
                Log_Report(LogStr)
                errCnt += 1
            End If
            hasError = False

            Try
                frmRecompute.pbLoading.Value += 1
                StatusUpdate(String.Format("{0}/{1}", frmRecompute.pbLoading.Value, frmRecompute.pbLoading.Maximum))
                Application.DoEvents()
            Catch ex As Exception
                Log_Report(ex.ToString)
            End Try
        Next
        If ds.Tables(0).Rows.Count > 0 Then _
            database.SaveEntry(ds, False)
        ' END - RENEWAL REMANTIC

        MsgBox(errCnt & " error found.", MsgBoxStyle.Information)
    End Sub

    Private Sub StatusUpdate(ByVal str As String)
        frmRecompute.lblStatus.Text = str
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
        Console.WriteLine("Recorded")
    End Sub
#End Region
End Module
