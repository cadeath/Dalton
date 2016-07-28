Imports Microsoft.Office.Interop
Imports System.Data.Odbc

Public Class dev_ExtractToExcel

    Private Sub btnExtract_Click(sender As System.Object, e As System.EventArgs) Handles btnExtract.Click
        sfdExcel.ShowDialog()
        If sfdExcel.FileName = "" Then Exit Sub

        btnExtract.Enabled = False

        Dim mySql As String = "SELECT * FROM (   SELECT *   FROM PAWNING   WHERE (Status = 'NEW' OR Status = 'RENEW')   AND LOANDATE <= '6/15/2016'   UNION   SELECT *   FROM PAWNING   WHERE (Status = 'RENEWED')   AND LOANDATE <= '6/15/2016' AND ORDATE > '6/15/2016'   UNION   SELECT *   FROM PAWNING   WHERE (Status = 'REDEEM')   AND LOANDATE <= '6/15/2016' AND ORDATE > '6/15/2016'   UNION   SELECT *   FROM PAWNING   WHERE (Status = 'SEGRE')   AND LOANDATE <= '6/15/2016' AND (PULLOUT > '6/15/2016' OR PULLOUT IS NULL)   UNION   SELECT *   FROM PAWNING   WHERE (Status = 'WITHDRAW')   AND LOANDATE <= '6/15/2016' AND PULLOUT > '6/15/2016' ) ORDER BY PAWNTICKET ASC"

        Dim headers() As String = _
            {"PAWNTICKET", "LOANDATE", "MATUDATE", "EXPIRYDATE", "AUCTIONDATE", "CLIENT", "FULLADDRESS", _
             "DESCRIPTION", "ORNUM", "ORDATE", "OLDTICKET", "NETAMOUNT", "RENEWDUE", "REDEEMDUE", "APPRAISAL", "PRINCIPAL", _
             "INTEREST", "ADVINT", "SERVICECHARGE", "PENALTY", "ITEMTYPE", "CATEGORY", "GRAMS", "KARAT", "STATUS", _
             "PULLOUT", "APPRAISER"}
        ExtractToExcel(headers, mySql, sfdExcel.FileName)

        btnExtract.Enabled = True
        MsgBox("Data Saved", MsgBoxStyle.Information)
    End Sub
End Class