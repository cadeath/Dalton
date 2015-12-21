Imports Microsoft.Office.Interop

Public Class frmExtractor
    Enum ExtractType As Integer
        Expiry = 0
        JournalEntry = 1
    End Enum
    Friend FormType As ExtractType = ExtractType.Expiry

    Private Sub txtPath_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPath.DoubleClick
        sfdPath.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        Dim result As DialogResult = sfdPath.ShowDialog

        If Not result = Windows.Forms.DialogResult.OK Then
            Return
        End If
        txtPath.Text = sfdPath.FileName
    End Sub

    Private Sub frmExtractor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FormInit()
        'Load Path
        txtPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
    End Sub

    Private Sub FormInit()
        Select Case FormType
            Case ExtractType.Expiry
                Console.WriteLine("Expiry Type Activated")
                sfdPath.FileName = String.Format("ROX{0}.xls", Now.ToString("MMddyyyy"))  'BranchCode + Date
                Me.Text &= " - Expiry"
            Case ExtractType.JournalEntry
                Console.WriteLine("Journal Entry Type Activated")
                sfdPath.FileName = String.Format("JRNL{0}ROX.xls", Now.ToString("yyyyMMdd")) 'JRNL + Date + BranchCode
                Me.Text &= " - Journal Entry"
        End Select
    End Sub

    Private Sub btnExtract_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExtract.Click
        If txtPath.Text = "" Then Exit Sub

        If FormType = ExtractType.Expiry Then
            ExtractExpiry()
        End If
    End Sub

    Private Sub ExtractJournalEntry()
        Dim sd As Date = MonCalendar.SelectionStart
        Dim ed As Date = MonCalendar.SelectionEnd

        Dim mySql As String = "SELECT * FROM "
    End Sub

    Private Sub ExtractExpiry()
        Dim sd As Date = MonCalendar.SelectionStart
        Dim ed As Date = MonCalendar.SelectionEnd

        Dim mySql As String = "SELECT * FROM EXPIRY_LIST"
        mySql &= vbCr & " WHERE "
        mySql &= vbCr & String.Format("EXPIRYDATE BETWEEN '{0}' AND '{1}'", sd.ToShortDateString, ed.ToShortDateString)

        Dim ds_expiry As DataSet = LoadSQL(mySql)

        'Load Excel
        Dim oXL As New Excel.Application
        Dim oWB As Excel.Workbook
        Dim oSheet As Excel.Worksheet

        oWB = oXL.Workbooks.Open(Application.StartupPath & "/doc/ExpiryFormat.xls")
        oSheet = oWB.Worksheets(1)

        Console.WriteLine("Entry found " & ds_expiry.Tables(0).Rows.Count)
        Dim rid As Integer = 2

        pbLoading.Maximum = ds_expiry.Tables(0).Rows.Count
        pbLoading.Value = 0
        While rid < ds_expiry.Tables(0).Rows.Count
            With ds_expiry.Tables(0).Rows(rid)
                oSheet.Cells(rid, 1).value = .Item("PawnID").ToString
                oSheet.Cells(rid, 2).value = .Item("PawnTicket").ToString
                oSheet.Cells(rid, 3).value = .Item("LoanDate").ToString 'TransDate
                oSheet.Cells(rid, 4).value = .Item("FirstName").ToString & _
                    " " & .Item("LastName").ToString 'Pawner
                oSheet.Cells(rid, 5).value = ds_expiry.Tables(0).Rows(rid).Item("Addr_Street").ToString & _
                    " " & ds_expiry.Tables(0).Rows(rid).Item("Addr_Brgy").ToString 'Addr1
                oSheet.Cells(rid, 6).value = .Item("Addr_City").ToString 'Addr2
                oSheet.Cells(rid, 7).value = .Item("Addr_Province").ToString 'Addr3
                oSheet.Cells(rid, 8).value = .Item("Addr_Zip").ToString 'Zip
                oSheet.Cells(rid, 9).value = .Item("ItemType").ToString 'ItemType
                oSheet.Cells(rid, 10).value = .Item("Grams").ToString 'Grams
                oSheet.Cells(rid, 11).value = "1" 'NoPCS
                oSheet.Cells(rid, 12).value = .Item("Description").ToString 'DESC1
                'oSheet.Cells(rid, 13).value = .Item("PawnTicket").ToString 'DESC2
                'oSheet.Cells(rid, 14).value = .Item("PawnTicket").ToString 'DESC3
                'oSheet.Cells(rid, 15).value = .Item("PawnTicket").ToString 'DESC4
                oSheet.Cells(rid, 16).value = "0" 'NOMONTH
                oSheet.Cells(rid, 17).value = .Item("MATUDATE").ToString 'MATUDATE
                oSheet.Cells(rid, 18).value = .Item("EXPIRYDATE").ToString 'EXPIDATE
                oSheet.Cells(rid, 19).value = .Item("AUCTIONDATE").ToString 'AUCTDATE
                'oSheet.Cells(rid, 20).value = .Item("Interest").ToString 'INT_RATE
                oSheet.Cells(rid, 21).value = .Item("Appraisal").ToString 'APPRAISAL
                oSheet.Cells(rid, 22).value = .Item("Principal").ToString 'PRINCIPAL
                oSheet.Cells(rid, 23).value = .Item("Interest").ToString 'INT_AMOUNT
                oSheet.Cells(rid, 24).value = .Item("ServiceCharge").ToString 'SRV_CHARGE
                oSheet.Cells(rid, 25).value = .Item("Evat").ToString 'VAT
                'oSheet.Cells(rid, 26).value = .Item("PawnTicket").ToString 'DOC_STAMP
                oSheet.Cells(rid, 27).value = .Item("NetAmount").ToString 'NET_AMOUNT
                oSheet.Cells(rid, 28).value = .Item("Username").ToString 'USER
                oSheet.Cells(rid, 29).value = .Item("Status").ToString 'STATUS
                'oSheet.Cells(rid, 30).value = .Item("PawnTicket").ToString 'NEW NUM
                oSheet.Cells(rid, 31).value = .Item("OLDTICKET").ToString 'OLD NUM
                oSheet.Cells(rid, 32).value = .Item("ORNUM").ToString 'RCT NO
                'oSheet.Cells(rid, 33).value = .Item("PawnTicket").ToString 'CLOSE DATE
                'oSheet.Cells(rid, 34).value = .Item("PawnTicket").ToString 'TRANSFER_DATE
                'oSheet.Cells(rid, 35).value = .Item("PawnTicket").ToString 'DATE_CREATED
                'oSheet.Cells(rid, 36).value = .Item("PawnTicket").ToString 'CANCEL
                'oSheet.Cells(rid, 37).value = .Item("PawnTicket").ToString 'DATE CANCEL
                'oSheet.Cells(rid, 38).value = .Item("PawnTicket").ToString 'ISBEGBAL
                oSheet.Cells(rid, 39).value = "'" & .Item("PHONE1").ToString 'PHONE_NO
                oSheet.Cells(rid, 40).value = .Item("BIRTHDAY").ToString 'BIRTHDAY
                oSheet.Cells(rid, 41).value = .Item("SEX").ToString 'SEX
                oSheet.Cells(rid, 42).value = .Item("KARAT").ToString 'KARAT
                oSheet.Cells(rid, 43).value = .Item("KARAT").ToString 'KARAT1
                oSheet.Cells(rid, 44).value = .Item("GRAMS").ToString 'GRAMS1
                oSheet.Cells(rid, 45).value = .Item("APPRAISAL").ToString 'APPRAISAL1
                'oSheet.Cells(rid, 46).value = .Item("PawnTicket").ToString 'APPRAISEDBY1
                'oSheet.Cells(rid, 47).value = .Item("PawnTicket").ToString 'DATE_REAPPRAISAL1
                oSheet.Cells(rid, 48).value = .Item("Category").ToString 'ITEMDESC
                'oSheet.Cells(rid, 49).value = .Item("PawnTicket").ToString 'ESKIE
            End With

            rid += 1
            AddProgress()
            Application.DoEvents()
        End While

        Dim verified_url As String
        Console.WriteLine("Split Count: " & txtPath.Text.Split(".").Count)
        If txtPath.Text.Split(".").Count > 1 Then
            If txtPath.Text.Split(".")(1).Length = 3 Then
                verified_url = txtPath.Text
            Else
                verified_url = txtPath.Text & "/" & sfdPath.FileName
            End If
        Else
            verified_url = txtPath.Text & "/" & sfdPath.FileName
        End If

        
        oWB.SaveAs(verified_url)
        oSheet = Nothing
        oWB.Close(False)
        oWB = Nothing
        oXL.Quit()
        oXL = Nothing

        MsgBox("Data Saved", MsgBoxStyle.Information)
        Me.Close()
    End Sub

    Private Sub AddProgress()
        pbLoading.Value += 1
    End Sub

    Private Function RandomString() As String
        Dim KeyGen As RandomKeyGenerator

        KeyGen = New RandomKeyGenerator
        KeyGen.KeyNumbers = "0123456789"
        KeyGen.KeyChars = 6

        Return KeyGen.Generate()
    End Function

End Class