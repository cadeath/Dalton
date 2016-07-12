Public Class dev_runCmd

    Private Sub btnRun_Click(sender As System.Object, e As System.EventArgs) Handles btnRun.Click
        RunCommand(txtSQL.Text)
        MsgBox("Executed", MsgBoxStyle.Information)
        txtSQL.Text = ""
    End Sub
End Class