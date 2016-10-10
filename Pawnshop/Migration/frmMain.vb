﻿Imports Microsoft.Office.Interop

Public Class frmMain

    Const LOANTABLE As String = "T_PS_TICKET"
    Dim EXCEL_HEADERS As String() = _
        {"ID", "TICKET_NO", "TRANSDATE", "NAME", "ADDRESS1", "ADDRESS2", "ADDRESS3", _
         "ZIP_CODE", "ITEMTYPE", "GRAMS", "NOPCS", "DESC1", "DESC2", "DESC3", "DESC4", "NOMONTH", _
         "MATU_DATE", "EXPI_DATE", "AUCT_DATE", "INT_RATE", "APPRAISAL", "PRINCIPAL", "INT_AMOUNT", _
         "SRV_CHARGE", "VAT_AMOUNT", "DOC_STAMP", "NET_AMOUNT", "USERNAME", "STATUS", "NEW_NO", "OLD_NO", "RCT_NO", _
         "CLOSE_DATE", "TRANSFER_DATE", "DATE_CREATED", "CANCEL_BY", "DATE_CANCEL", "ISBEGBAL", "PHONE_NO", _
         "BIRTH_DATE", "SEX", "KARAT", "KARAT1", "GRAMS1", "APPRAISAL1", "APPRAISEDBY1", "DATE_REAPPRAISAL1", "ITEMDESC"}
    Dim IMPORT_TEMPLATE As String() = _
        {"First Name", "Last Name", "Suffix", "Street", "Barangay", "City", "Province", "Zip", _
         "Sex", "Birthday", "Phone1", "Phone2", "PT Number", "Item Type", "ItemDesc", "Grams", "Karat", _
         "Description", "Loan Date", "Maturity Date", "Expiry Date", "Auction Date", "Appraisal", _
         "Principal", "Interest", "ServiceCharge", "NetAmount", "OLD PT", "ADVINT"}
    Dim total_extracted As Integer = 0


    Private Sub AddProgress()
        pbLoading.Value += 1
    End Sub

    Private Sub Status(str As String)
        lblStatus.Text = str
    End Sub

    Private Sub btnExtract_Click(sender As System.Object, e As System.EventArgs) Handles btnExtract.Click
        pbLoading.Visible = True
        Me.Enabled = False

        database.dbName = txtUrl.Text
        Load_Remantic()
        Load_Dalton()

        Me.Enabled = True
        pbLoading.Visible = False
        Status(total_extracted & " EXTRACTED.")
    End Sub

    Private Sub Load_Remantic()
        Dim ds As DataSet, mySql As String

        mySql = "SELECT * FROM " & LOANTABLE
        mySql &= " WHERE STATUS = 'A'"
        'mySql &= " ROWS 50" 'Remove on FINAL

        Try
            ds = LoadSQL(mySql)
            DeveloperConsole("Entries >> " & ds.Tables(0).Rows.Count)
        Catch ex As Exception
            DeveloperConsole("Non Remantic")
            Exit Sub
        End Try

        'Load Excel Application
        Dim oXL As New Excel.Application
        If oXL Is Nothing Then MessageBox.Show("Excel is not properly installed!!") : Exit Sub
        Dim oWB As Excel.Workbook
        Dim oSheet As Excel.Worksheet
        DeveloperConsole("Loading Excel Application")

        'Create Excel File
        oXL = CreateObject("Excel.Application")
        oWB = oXL.Workbooks.Add
        oSheet = oWB.ActiveSheet
        DeveloperConsole("Creating Excel File")

        'Adding Header
        Dim sheetRow As Integer = 0
        For Each hd In EXCEL_HEADERS
            oSheet.Cells(1, sheetRow + 1).value = hd
            sheetRow += 1
        Next

        'Max Entries
        Dim st As String
        pbLoading.Maximum = ds.Tables(0).Rows.Count
        total_extracted += pbLoading.Maximum
        st = "ENTRIES: " & pbLoading.Maximum
        Status(st)
        Application.DoEvents()

        'Adding Data
        sheetRow = 2 : Dim tmpStr As String
        For Each dr As DataRow In ds.Tables(0).Rows
            For cnt As Integer = 1 To EXCEL_HEADERS.Count
                tmpStr = IIf(IsDBNull(dr.Item(cnt - 1)), "", dr.Item(cnt - 1))
                oSheet.Cells(sheetRow, cnt).value = tmpStr
            Next
            sheetRow += 1

            AddProgress()
            Status(String.Format("ENTRIES >>> {0}/{1} PT# {2}", sheetRow, pbLoading.Maximum, dr.Item("TICKET_NO")))
            Application.DoEvents()
        Next

        'Extracting Segregated List
        Status("Extracting EXPIRY LIST")
        DeveloperConsole("Generating Segregated List")
        Application.DoEvents()
        mySql = "SELECT * FROM " & LOANTABLE
        mySql &= String.Format(" WHERE STATUS = 'T' AND AUCT_DATE > '{0}'", pullDate.SelectionStart.ToString("MM/dd/yyyy"))
        ds = LoadSQL(mySql)
        pbLoading.Value = 0
        pbLoading.Maximum = ds.Tables(0).Rows.Count
        total_extracted += pbLoading.Maximum
        Status("ENTRIES: " & pbLoading.Maximum)
        Application.DoEvents()

        'EXTRACED - Adding Data
        DeveloperConsole("Extracted - Adding Data")
        tmpStr = ""
        For Each dr As DataRow In ds.Tables(0).Rows
            For cnt As Integer = 1 To EXCEL_HEADERS.Count
                tmpStr = IIf(IsDBNull(dr.Item(cnt - 1)), "", dr.Item(cnt - 1))
                oSheet.Cells(sheetRow, cnt).value = tmpStr
            Next
            sheetRow += 1

            AddProgress()
            Status(String.Format("ENTRIES >>> {0}/{1} PT# {2}", sheetRow, pbLoading.Maximum, dr.Item("TICKET_NO")))
            Application.DoEvents()
        Next

        'Save Excel
        oWB.SaveAs(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\EXTRACTEDDATA.xlsx")
        oSheet = Nothing
        oWB = Nothing
        oXL.Quit()
        oXL = Nothing
        DeveloperConsole("Excel Saved and Closed")
    End Sub

    Private Sub Load_Dalton()
        Dim ds As DataSet, mySql As String

        mySql = "SELECT "
        mySql &= "	C.FIRSTNAME, C.LASTNAME, C.SUFFIX, C.ADDR_STREET, C.ADDR_BRGY, C.ADDR_CITY, C.ADDR_PROVINCE, "
        mySql &= "    C.ADDR_ZIP, C.SEX, C.BIRTHDAY, C.PHONE1, C.PHONE2, P.PAWNTICKET, P.ITEMTYPE, ITMC.CATEGORY, "
        mySql &= "    P.GRAMS, P.KARAT, P.DESCRIPTION || ' BY: ' || USR.USERNAME AS DESCRIPTION, P.LOANDATE, P.MATUDATE, P.EXPIRYDATE, P.AUCTIONDATE, P.APPRAISAL, "
        mySql &= "    P.PRINCIPAL, (CASE WHEN P.INTEREST >= P.ADVINT THEN P.INTEREST - P.ADVINT ELSE P.INTEREST END) AS INTEREST, "
        mySql &= "    P.SERVICECHARGE, P.NETAMOUNT, P.OLDTICKET, P.ADVINT "
        mySql &= "FROM TBLPAWN P "
        mySql &= "  INNER JOIN TBLCLIENT C ON C.CLIENTID = P.CLIENTID "
        mySql &= "  INNER JOIN TBLCLASS ITMC ON ITMC.CLASSID = P.CATID "
        mySql &= "  INNER JOIN TBL_GAMIT USR ON USR.USERID = P.ENCODERID "
        mySql &= "WHERE "
        mySql &= "	P.STATUS = 'L' OR P.STATUS = 'R' OR P.STATUS = 'S' "
        mySql &= "ORDER BY "
        mySql &= "	P.PAWNTICKET ASC"

        Try
            ds = LoadSQL(mySql)
            DeveloperConsole("Entries >> " & ds.Tables(0).Rows.Count)
        Catch ex As Exception
            DeveloperConsole("Non Dalton")
            Exit Sub
        End Try

        'Load Excel Application
        Dim oXL As New Excel.Application
        If oXL Is Nothing Then MessageBox.Show("Excel is not properly installed!!") : Exit Sub
        Dim oWB As Excel.Workbook
        Dim oSheet As Excel.Worksheet
        DeveloperConsole("Loading Excel Application")

        'Create Excel File
        oXL = CreateObject("Excel.Application")
        oWB = oXL.Workbooks.Add
        oSheet = oWB.ActiveSheet
        DeveloperConsole("Creating Excel File")

        'Adding Header
        Dim sheetRow As Integer = 0
        For Each hd In IMPORT_TEMPLATE
            oSheet.Cells(1, sheetRow + 1).value = hd
            sheetRow += 1
        Next

        'Max Entries
        Dim st As String
        pbLoading.Maximum = ds.Tables(0).Rows.Count
        total_extracted += pbLoading.Maximum
        st = "ENTRIES: " & pbLoading.Maximum
        Status(st)
        Application.DoEvents()

        'Adding Data
        sheetRow = 2 : Dim tmpStr As String
        For Each dr As DataRow In ds.Tables(0).Rows
            For cnt As Integer = 1 To IMPORT_TEMPLATE.Count
                tmpStr = IIf(IsDBNull(dr.Item(cnt - 1)), "", dr.Item(cnt - 1))
                oSheet.Cells(sheetRow, cnt).value = tmpStr
            Next
            sheetRow += 1

            AddProgress()
            Status(String.Format("ENTRIES >>> {0}/{1} PT# {2}", sheetRow, pbLoading.Maximum, dr.Item("PAWNTICKET")))
            Application.DoEvents()
        Next

        'Save Excel
        oWB.SaveAs(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\NEW_EXTRACTED.xlsx")
        oSheet = Nothing
        oWB = Nothing
        oXL.Quit()
        oXL = Nothing
        DeveloperConsole("Excel Saved and Closed")
    End Sub

    Private Sub DeveloperConsole(str As String)
        Console.WriteLine(String.Format("[{0}]", Now.ToString("HH:mm:ss")) & str)
    End Sub

    Private Sub ofdFirebird_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ofdFirebird.FileOk
        txtUrl.Text = ofdFirebird.FileName
    End Sub

    Private Sub txtUrl_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUrl.DoubleClick
        ofdFirebird.ShowDialog()
    End Sub
End Class
