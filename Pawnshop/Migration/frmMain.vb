Imports Microsoft.Office.Interop

Public Class frmMain

    Const LOANTABLE As String = "T_PS_TICKET"
    Dim EXCEL_HEADERS As String() = _
        {"ID", "TICKET_NO", "TRANSDATE", "NAME", "ADDRESS1", "ADDRESS2", "ADDRESS3", _
         "ZIP_CODE", "ITEMTYPE", "GRAMS", "NOPCS", "DESC1", "DESC2", "DESC3", "DESC4", "NOMONTH", _
         "MATU_DATE", "EXPI_DATE", "AUCT_DATE", "INT_RATE", "APPRAISAL", "PRINCIPAL", "INT_AMOUNT", _
         "SRV_CHARGE", "VAT_AMOUNT", "DOC_STAMP", "NET_AMOUNT", "USERNAME", "STATUS", "NEW_NO", "OLD_NO", "RCT_NO", _
         "CLOSE_DATE", "TRANSFER_DATE", "DATE_CREATED", "CANCEL_BY", "DATE_CANCEL", "ISBEGBAL", "PHONE_NO", _
         "BIRTH_DATE", "SEX", "KARAT", "KARAT1", "GRAMS1", "APPRAISAL1", "APPRAISEDBY1", "DATE_REAPPRAISAL1", "ITEMDESC"}


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
        Dim ds As DataSet, mySql As String
        Dim total_extracted As Integer = 0

        mySql = "SELECT * FROM " & LOANTABLE
        mySql &= " WHERE STATUS = 'A'"

        ds = LoadSQL(mySql)
        DeveloperConsole("Entries >> " & ds.Tables(0).Rows.Count)

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
        Application.DoEvents()
        mySql = "SELECT * FROM " & LOANTABLE
        mySql &= String.Format(" WHERE STATUS = 'T' AND AUCT_DATE > '{0}'", pullDate.SelectionStart.ToString("MM/dd/yyyy"))
        ds = LoadSQL(mySql)
        pbLoading.Maximum = ds.Tables(0).Rows.Count
        total_extracted += pbLoading.Maximum
        Status("ENTRIES: " & pbLoading.Maximum)
        Application.DoEvents()

        'Adding Data
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

        Me.Enabled = True
        pbLoading.Visible = False
        Status(total_extracted & " EXTRACTED.")
    End Sub

    Private Sub DeveloperConsole(str As String)
        Console.WriteLine(String.Format("[{0}]", Now.ToString("HH:mm:ss")) & str)
    End Sub
End Class
