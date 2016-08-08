Imports Microsoft.Office.Interop
Imports System.Data.Odbc

Public Class dev_ExtractToExcel

    Private Sub btnExtract_Click(sender As System.Object, e As System.EventArgs) Handles btnExtract.Click
        sfdExcel.ShowDialog()
        If sfdExcel.FileName = "" Then Exit Sub

        btnExtract.Enabled = False

        Dim mySql As String = "SELECT * FROM (   SELECT *   FROM PAWNING   WHERE (Status = 'NEW' OR Status = 'RENEW')   AND LOANDATE <= '6/15/2016'   UNION   SELECT *   FROM PAWNING   WHERE (Status = 'RENEWED')   AND LOANDATE <= '6/15/2016' AND ORDATE > '6/15/2016'   UNION   SELECT *   FROM PAWNING   WHERE (Status = 'REDEEM')   AND LOANDATE <= '6/15/2016' AND ORDATE > '6/15/2016'   UNION   SELECT *   FROM PAWNING   WHERE (Status = 'SEGRE')   AND LOANDATE <= '6/15/2016' AND (PULLOUT > '6/15/2016' OR PULLOUT IS NULL)   UNION   SELECT *   FROM PAWNING   WHERE (Status = 'WITHDRAW')   AND LOANDATE <= '6/15/2016' AND PULLOUT > '6/15/2016' ) ORDER BY PAWNTICKET ASC"
        Dim ds As DataSet = LoadSQL(mySql)

        Dim headers() As String = _
            {"PAWNTICKET", "LOANDATE", "MATUDATE", "EXPIRYDATE", "AUCTIONDATE", "CLIENT", "FULLADDRESS", _
             "DESCRIPTION", "ORNUM", "ORDATE", "OLDTICKET", "NETAMOUNT", "RENEWDUE", "REDEEMDUE", "APPRAISAL", "PRINCIPAL", _
             "INTEREST", "ADVINT", "SERVICECHARGE", "PENALTY", "ITEMTYPE", "CATEGORY", "GRAMS", "KARAT", "STATUS", _
             "PULLOUT", "APPRAISER"}

        'Load Excel
        Dim oXL As New Excel.Application
        If oXL Is Nothing Then
            MessageBox.Show("Excel is not properly installed!!")
            Return
        End If

        Dim oWB As Excel.Workbook
        Dim oSheet As Excel.Worksheet

        oXL = CreateObject("Excel.Application")
        oXL.Visible = False

        oWB = oXL.Workbooks.Add
        oSheet = oWB.ActiveSheet
        oSheet.Name = "OUTSTANDING"

        ' HEADERS
        Dim cnt As Integer = 0
        For Each hr In headers
            cnt += 1 : oSheet.Cells(1, cnt).value = hr
        Next

        ' EXTRACTING
        Console.Write("Extracting")
        Dim rowCnt As Integer = 2
        For Each dr As DataRow In ds.Tables(0).Rows
            For colCnt As Integer = 0 To headers.Count - 1
                oSheet.Cells(rowCnt, colCnt + 1).value = dr(colCnt)
            Next
            rowCnt += 1

            Console.Write(".")
            Application.DoEvents()
        Next

        oWB.SaveAs(sfdExcel.FileName)
        oSheet = Nothing
        oWB.Close(False)
        oWB = Nothing
        oXL.Quit()
        oXL = Nothing


        btnExtract.Enabled = True
        MsgBox("Data Saved", MsgBoxStyle.Information)
    End Sub
End Class