Imports System.Data.Odbc
Imports Microsoft.Reporting.WinForms

Public Class dev_print

    Private Sub dev_print_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        For Each tmpPrinterName In Printing.PrinterSettings.InstalledPrinters
            cboPrinter.Items.Add(tmpPrinterName)
        Next
    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        Dim autoPrintPT As Reporting

        Dim printerName As String = cboPrinter.Text
        Dim report As LocalReport = New LocalReport
        autoPrintPT = New Reporting

        Dim mySql As String, dsName As String = "dsPawnTicket"
        
        Dim ds As DataSet = LoadSQL(mySql, dsName)
    End Sub

    Private Sub Load_ID()

    End Sub
End Class