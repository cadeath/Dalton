' Changelog
' v1.3 11/19/15
'  - CommandPrompt Added
' v1.2 11/6/15
'  - Added ESK File
' v1.1 10/20/15
'  - Added decimal . in DigitOnly
'  - Added isMoney

Module mod_system

#Region "Global Variables"
    Public DEV_MODE As Boolean = True

    Public CurrentDate As Date = Now
    Public POSuser As New ComputerUser
    Public UserID As Integer = POSuser.UserID
    Public BranchCode As String = GetOption("BranchCode")
    Public branchName As String = GetOption("BranchName")
    Public AREACODE As String = GetOption("BranchArea")
    Public REVOLVING_FUND As String = GetOption("RevolvingFund")

    Friend isAuthorized As Boolean = False
    Public backupPath As String = "."

    Friend advanceInterestDays As Integer = 30
    Friend MaintainBal As Double = GetOption("MaintainingBalance")
    Friend InitialBal As Double = 0
    Friend RepDep As Double = 0
    Friend DollarRate As Double = 48
    Friend RequirementLevel As Integer = 1
    Friend dailyID As Integer = 1

#End Region

#Region "Store"
    Private storeDB As String = "tblDaily"

    Friend Function OpenStore() As Boolean
        If MaintainBal = 0 Then
            Dim ans As MsgBoxResult = _
                MsgBox("Maintaining Balance is Zero(0)" + vbCrLf + "Are you sure you want to open the store?", _
                       MsgBoxStyle.Information + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2)
            If ans = MsgBoxResult.No Then Return False
        End If

        Dim mySql As String = "SELECT * FROM " & storeDB
        mySql &= String.Format(" WHERE currentDate = '{0}'", CurrentDate.ToString("MM/dd/yyyy"))
        Dim ds As DataSet = LoadSQL(mySql, storeDB)

        ' Do not allow previous date to OPEN if closed.
        If ds.Tables(storeDB).Rows.Count = 1 Then
            If ds.Tables(storeDB).Rows(0).Item("Status") = 0 Then
                MsgBox("You cannot select to open a previous date", MsgBoxStyle.Critical)
            Else
                MsgBox("Error in OPENING STORE", MsgBoxStyle.Critical)
            End If
            Return False
        End If

        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(storeDB).NewRow
        With dsNewRow
            .Item("CurrentDate") = CurrentDate
            .Item("MaintainBal") = MaintainBal
            .Item("InitialBal") = InitialBal
            .Item("RepDep") = RepDep
            '.Item("CashCount")'No CashCount on OPENING
            .Item("Status") = 1
            .Item("SystemInfo") = Now
            .Item("Openner") = UserID
        End With
        ds.Tables(storeDB).Rows.Add(dsNewRow)

        database.SaveEntry(ds)
        Console.WriteLine("Store is now OPEN!")

        Return True
    End Function

    Friend Function LoadLastOpening() As DataSet
        Dim mySql As String = "SELECT * FROM tblDaily ORDER BY ID DESC"
        Dim ds As DataSet = LoadSQL(mySql)

        Return ds
    End Function

    Friend Sub LoadCurrentDate()
        Dim mySql As String = "SELECT * FROM " & storeDB
        mySql &= String.Format(" WHERE Status = 1")
        Dim ds As DataSet = LoadSQL(mySql)

        If ds.Tables(0).Rows.Count = 1 Then
            CurrentDate = ds.Tables(0).Rows(0).Item("CurrentDate")
            dailyID = ds.Tables(0).Rows(0).Item("ID")
            frmMain.dateSet = True
        Else
            frmMain.dateSet = False
        End If
    End Sub

    Friend Function AutoSegregate() As Boolean
        Console.WriteLine("Entering segregation module")
        Dim mySql As String = "SELECT * FROM tblPawn WHERE AuctionDate < '" & CurrentDate.Date & "' AND (Status = 'L' OR Status = 'R')"
        Dim ds As DataSet = LoadSQL(mySql, "tblPawn")

        If ds.Tables(0).Rows.Count = 0 Then Return True

        Console.WriteLine("Segregating...")
        For Each dr As DataRow In ds.Tables("tblPawn").Rows
            Dim tmpPawnItem As New PawnTicket
            tmpPawnItem.LoadTicketInRow(dr)
            tmpPawnItem.Status = "S"
            tmpPawnItem.SaveTicket(False)
            Console.WriteLine("PT: " & tmpPawnItem.PawnTicket)
        Next

        Console.WriteLine("Segregation complete")
        Return True
    End Function

    Friend Sub CloseStore(ByVal cc As Double)
        Dim mySql As String = "SELECT * FROM " & storeDB
        mySql &= String.Format(" WHERE currentDate = '{0}'", CurrentDate.ToString("MM/dd/yyyy"))
        Dim ds As DataSet = LoadSQL(mySql, storeDB)

        If ds.Tables(storeDB).Rows.Count = 1 Then
            With ds.Tables(storeDB).Rows(0)
                .Item("CashCount") = cc
                .Item("Status") = 0
                .Item("Closer") = POSuser.UserID
            End With

            database.SaveEntry(ds, False)

            'Get the "Balance(as per computation)"
            Dim AsPerComputation As Double = 0
            AsPerComputation += InitialBal 'Add Beginning
            Dim tmpDS As New DataSet
            mySql = "SELECT TRANSDATE, TRANSNAME, SUM(DEBIT) AS DEBIT, SUM(CREDIT) AS CREDIT, CCNAME "
            mySql &= "FROM JOURNAL_ENTRIES WHERE "
            mySql &= String.Format("TRANSDATE = '{0}'", CurrentDate.ToShortDateString)
            mySql &= " AND DEBIT <> 0 AND TRANSNAME = 'Revolving Fund' "
            mySql &= " GROUP BY TRANSDATE, TRANSNAME, CCNAME"
            tmpDS = LoadSQL(mySql)
            For Each dr As DataRow In tmpDS.Tables(0).Rows
                AsPerComputation += dr.Item("DEBIT")
            Next

            tmpDS = New DataSet
            mySql = "SELECT TRANSDATE, TRANSNAME, SUM(DEBIT) AS DEBIT, SUM(CREDIT) AS CREDIT, CCNAME "
            mySql &= "FROM JOURNAL_ENTRIES WHERE "
            mySql &= String.Format("TRANSDATE = '{0}'", CurrentDate.ToShortDateString)
            mySql &= " AND CREDIT <> 0 AND TRANSNAME = 'Revolving Fund' "
            mySql &= " GROUP BY TRANSDATE, TRANSNAME, CCNAME"
            tmpDS = LoadSQL(mySql)
            For Each dr As DataRow In tmpDS.Tables(0).Rows
                AsPerComputation -= dr.Item("CREDIT")
            Next

            Console.WriteLine(">>>>>>> Computation: " & AsPerComputation.ToString("Php #,#00.00"))

            If AsPerComputation <> cc Then
                Dim tmpOverShort As Double = cc - AsPerComputation
                'tmpOverShort = Math.Abs(tmpOverShort)
                If AsPerComputation < cc Then
                    'Overage
                    AddJournal(tmpOverShort, "Debit", "Revolving Fund", , "CASH COUNT", False)
                    AddJournal(tmpOverShort, "Credit", "Cashier's Overage(Shortage)", , , False)
                Else
                    'Shortage
                    tmpOverShort = Math.Abs(tmpOverShort)
                    AddJournal(tmpOverShort, "Debit", "Cashier's Overage(Shortage)", , , False)
                    AddJournal(tmpOverShort, "Credit", "Revolving Fund", , "CASH COUNT", False)
                End If
            End If

            UpdateOptions("CurrentBalance", cc)
            MsgBox("Thank you! Take care and God bless", MsgBoxStyle.Information)
        Else
            MsgBox("Error in closing store" + vbCr + "Contact your IT Department", MsgBoxStyle.Critical)
        End If
    End Sub
#End Region

    Public Function CommandPrompt(ByVal app As String, ByVal args As String) As String
        Dim oProcess As New Process()
        Dim oStartInfo As New ProcessStartInfo(app, args)
        oStartInfo.UseShellExecute = False
        oStartInfo.RedirectStandardOutput = True
        oStartInfo.WindowStyle = ProcessWindowStyle.Hidden
        oStartInfo.CreateNoWindow = True
        oProcess.StartInfo = oStartInfo

        oProcess.Start()

        Dim sOutput As String
        Using oStreamReader As System.IO.StreamReader = oProcess.StandardOutput
            sOutput = oStreamReader.ReadToEnd()
        End Using

        Return sOutput
    End Function

    Friend Sub CreateEsk(ByVal url As String, ByVal data As Hashtable)
        If System.IO.File.Exists(url) Then System.IO.File.Delete(url)

        Dim fsEsk As New System.IO.FileStream(url, IO.FileMode.CreateNew)
        Dim refNum As String, transDate As String, branchCode As String, amount As Double, remarks As String
        Dim checkSum As String

        With data
            refNum = data(0) '0 - as RefNum
            transDate = data(1) 'transDate
            branchCode = data(2) 'branchCode
            amount = data(3) 'Amount
            remarks = data(4) 'Remarks
        End With
        checkSum = HashString(refNum & transDate & branchCode & amount & remarks)
        data.Add(5, checkSum) 'CheckSum

        Dim esk As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
        esk.Serialize(fsEsk, data)
        fsEsk.Close()
    End Sub

    Friend Function LoadEsk(ByVal url) As Hashtable
        If Not System.IO.File.Exists(url) Then Return Nothing

        Dim fsEsk As New System.IO.FileStream(url, IO.FileMode.Open)
        Dim bf As New Runtime.Serialization.Formatters.Binary.BinaryFormatter

        Dim hashTable As New Hashtable
        Try
            hashTable = bf.Deserialize(fsEsk)
        Catch ex As Exception
            Console.WriteLine("It seems the file is being tampered.")
            Return Nothing
        End Try
        fsEsk.Close()

        Dim isValid As Boolean = False
        If hashTable(5) = security.HashString(hashTable(0) & hashTable(1) & hashTable(2) & hashTable(3) & hashTable(4)) Then
            isValid = True
        End If

        If isValid Then Return hashTable
        Return Nothing
    End Function

    ''' <summary>
    ''' Function use to input only numbers
    ''' </summary>
    ''' <param name="e">Keypress Event</param>
    ''' <remarks>Use the Keypress Event when calling this function</remarks>
    Friend Function DigitOnly(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Console.WriteLine("char: " & e.KeyChar & " -" & Char.IsDigit(e.KeyChar))
        If e.KeyChar <> ControlChars.Back Then
            e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".")
        End If

        Return Not (Char.IsDigit(e.KeyChar))
    End Function

    Friend Function checkNumeric(ByVal txt As TextBox) As Boolean
        If IsNumeric(txt.Text) Then
            Return True
        End If

        Return False
    End Function

    Friend Function DreadKnight(ByVal str As String, Optional ByVal special As String = Nothing) As String
        str = str.Replace("'", "''")
        str = str.Replace("""", """""")

        If special <> Nothing Then
            str = str.Replace(special, "")
        End If

        Return str
    End Function

    ''' <summary>
    ''' Identify if the KeyPress is enter
    ''' </summary>
    ''' <param name="e">KeyPressEventArgs</param>
    ''' <returns>Boolean</returns>
    Friend Function isEnter(ByVal e As KeyPressEventArgs) As Boolean
        If Asc(e.KeyChar) = 13 Then
            Return True
        End If
        Return False
    End Function

    Friend Function GetCurrentAge(ByVal dob As Date) As Integer
        Dim age As Integer
        age = Today.Year - dob.Year
        If (dob > Today.AddYears(-age)) Then age -= 1
        Return age
    End Function

    ''' <summary>
    ''' Use to verify entry
    ''' </summary>
    ''' <param name="txtBox">TextBox of the Money</param>
    ''' <returns>Boolean</returns>
    Friend Function isMoney(ByVal txtBox As TextBox) As Boolean
        Dim isGood As Boolean = False

        If Double.TryParse(txtBox.Text, 0.0) Then
            isGood = True
        End If

        Return isGood
    End Function

    Friend Function GetFirstDate(ByVal curDate As Date) As Date
        Dim firstDay = DateSerial(curDate.Year, curDate.Month, 1)
        Return firstDay
    End Function

    Friend Function GetLastDate(ByVal curDate As Date) As Date
        Dim original As DateTime = curDate  ' The date you want to get the last day of the month for
        Dim lastOfMonth As DateTime = original.Date.AddDays(-(original.Day - 1)).AddMonths(1).AddDays(-1)

        Return lastOfMonth
    End Function
End Module
