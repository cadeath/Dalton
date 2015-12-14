Imports Microsoft.Reporting.WinForms
Public Class frmReport

    Private Sub frmReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Friend Sub ReportInit(ByVal mySql As String, ByVal dsName As String, ByVal rptUrl As String)
        Dim ds As DataSet = LoadSQL(mySql, dsName)

        Console.WriteLine("SQL: " & mySql)
        Console.WriteLine("Max: " & ds.Tables(dsName).Rows.Count)
        With rv_display
            .ProcessingMode = ProcessingMode.Local
            .LocalReport.ReportPath = rptUrl
            .LocalReport.DataSources.Clear()

            .LocalReport.DataSources.Add(New ReportDataSource(dsName, ds.Tables(dsName)))
            .RefreshReport()
        End With
    End Sub
End Class