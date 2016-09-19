Public Class dev_runCmd

    Private Sub btnRun_Click(sender As System.Object, e As System.EventArgs) Handles btnRun.Click
        'RunCommand(txtSQL.Text)
        MsgBox("Executed", MsgBoxStyle.Information)
        txtSQL.Text = ""

        Dim tmp As Double = 0
        tmp = 0.003

        txtSQL.Text = tmp
    End Sub
End Class