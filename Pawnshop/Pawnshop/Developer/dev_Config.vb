Public Class dev_Config

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        sfdCIR.ShowDialog()
        Interest_Config.Export_Config(sfdCIR.FileName)
    End Sub

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        ofdCIR.ShowDialog()
        Interest_Config.Load_Config(ofdCIR.FileName)
    End Sub
End Class