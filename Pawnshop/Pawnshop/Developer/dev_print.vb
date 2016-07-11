Imports System.Data.Odbc
Imports Microsoft.Reporting.WinForms

Public Class dev_print

    Private pawnItem As New PawnTicket

    Private Sub dev_print_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        For Each tmpPrinterName In Printing.PrinterSettings.InstalledPrinters
            cboPrinter.Items.Add(tmpPrinterName)
        Next
        cboPrinter.SelectedIndex = 0

        Load_ID()
    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        PrintOR()
        System.Threading.Thread.Sleep(1000)
        PrintOR()
    End Sub

    Private Sub PrintOR()
        Dim autoPrintPT As Reporting

        Dim printerName As String = cboPrinter.Text
        Dim report As LocalReport = New LocalReport
        autoPrintPT = New Reporting

        Dim mySql As String, dsName As String = "dsPawn"
        mySql = "SELECT * FROM PRINT_PAWNING WHERE PAWNID = " & lstPT.SelectedItem.ToString

        Dim ds As DataSet = LoadSQL(mySql, dsName)
        report.ReportPath = "Reports\_layout03.rdlc"
        report.DataSources.Add(New ReportDataSource(dsName, ds.Tables(dsName)))

        ' HACK
        ' Get total due
        mySql = "SELECT * FROM TBLPAWN WHERE PAWNID = " & lstPT.SelectedItem.ToString
        Dim hackDs As DataSet = LoadSQL(mySql), total_due As Double = 0
        Dim st As String = hackDs.Tables(0).Rows(0).Item("STATUS")
        With hackDs.Tables(0).Rows(0)
            Select Case st
                Case "0", "R"
                    total_due = .Item("RENEWDUE")
                Case "X"
                    total_due = .Item("REDEEMDUE")
                Case "L"
                    total_due = .Item("NETAMOUNT")
                Case Else
                    MsgBox(st & " << WHAT STATUS IS THIS?", MsgBoxStyle.Critical, "STATUS UNKNOWN")
                    Exit Select
            End Select
        End With

        Dim addParameters As New Dictionary(Of String, String)
        addParameters.Add("txtPayment", "Payment INFORMATION here")
        addParameters.Add("dblTotalDue", total_due)

        If Not addParameters Is Nothing Then
            For Each nPara In addParameters
                Dim tmpPara As New ReportParameter
                tmpPara.Name = nPara.Key
                tmpPara.Values.Add(nPara.Value)
                report.SetParameters(New ReportParameter() {tmpPara})
                Console.WriteLine(String.Format("{0}: {1}", nPara.Key, nPara.Value))
            Next
        End If

        Dim paperSize As New Dictionary(Of String, Double)
        paperSize.Add("width", 8.5)
        paperSize.Add("height", 4.5) 'Changed 4.5 to 9

        autoPrintPT.Export(report, paperSize)
        autoPrintPT.m_currentPageIndex = 0
        autoPrintPT.Print(printerName)
    End Sub

    Private Sub Load_ID()
        Dim mySql As String = "SELECT * FROM TBLPAWN WHERE STATUS <> 'V' OR PULLOUT = '' ORDER BY PAWNID DESC"

        dbReaderOpen()

        Dim idReader As OdbcDataReader = LoadSQL_byDataReader(mySql)

        lstPT.Items.Clear()
        While idReader.Read
            lstPT.Items.Add(idReader("PAWNID"))
        End While


        dbReaderClose()
    End Sub
End Class