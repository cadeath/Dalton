Public Class frmOpenStore

    Private Sub frmOpenStore_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetup.Click
        CurrentDate = dtpCurrentDate.Value
        MsgBox("Today is" & vbCr & dtpCurrentDate.Value.ToString("MMM d, yyyy"), MsgBoxStyle.Information, "Current Date Set")
        frmMain.dateSet = True
        Me.Close()
    End Sub
End Class