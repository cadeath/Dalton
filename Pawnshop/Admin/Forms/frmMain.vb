Public Class frmMain

    Private Sub tsbtnCashInOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnCashInOut.Click
        'frmCashInOut.Show()
        LoadChild(frmCashInOut)
    End Sub

    Private Sub tsbtnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnExport.Click
        'frmFileGen.Show()
        LoadChild(frmFileGen)
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub LoadChild(ByVal frm As Form)
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub tsbtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnExit.Click
        End
    End Sub
End Class
