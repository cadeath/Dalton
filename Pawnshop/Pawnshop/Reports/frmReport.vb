Imports Microsoft.Reporting.WinForms
Public Class frmReport

    Private Sub frmReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Friend Sub ReportInit(ByVal mySql As String, ByVal dsName As String, ByVal rptUrl As String, ByVal addPara As Dictionary(Of String, String))
        Dim ds As DataSet = LoadSQL(mySql, dsName)

        Console.WriteLine("SQL: " & mySql)
        Console.WriteLine("Max: " & ds.Tables(dsName).Rows.Count)
        With rv_display
            .ProcessingMode = ProcessingMode.Local
            .LocalReport.ReportPath = rptUrl
            .LocalReport.DataSources.Clear()

            .LocalReport.DataSources.Add(New ReportDataSource(dsName, ds.Tables(dsName)))
            Dim myPara As New ReportParameter
            myPara.Name = "txtUsername"
            If POSuser.UserName Is Nothing Then POSuser.UserName = "Sample Eskie"
            myPara.Values.Add(POSuser.UserName)
            rv_display.LocalReport.SetParameters(New ReportParameter() {myPara})
            If Not addPara Is Nothing Then
                For Each nPara In addPara
                    Dim tmpPara As New ReportParameter
                    tmpPara.Name = nPara.Key
                    tmpPara.Values.Add(nPara.Value)
                    .LocalReport.SetParameters(New ReportParameter() {tmpPara})
                Next
            End If


            .RefreshReport()
        End With
    End Sub
End Class