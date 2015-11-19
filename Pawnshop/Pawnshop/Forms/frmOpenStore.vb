Public Class frmOpenStore

    Private Sub frmOpenStore_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetup.Click
        CurrentDate = dtpCurrentDate.Value
        Dim ans As DialogResult = MsgBox("TODAY IS: " & vbCrLf & dtpCurrentDate.Value.ToString("MMM d, yyyy"), MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information, "Please CHECK")
        If Not ans = Windows.Forms.DialogResult.Yes Then
            Exit Sub
        End If

        If Not frmMain.dateSet Then
            ans = MsgBox("Do you want to execute backup procedure?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Daily Backup")
            If ans = Windows.Forms.DialogResult.Yes Then
                frmBackup.StartupExecute()
            End If
        End If
        frmMain.dateSet = True

        Me.Close()
    End Sub
End Class