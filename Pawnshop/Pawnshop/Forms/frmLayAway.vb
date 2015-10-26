Public Class frmLayAway

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnItem.Click
        frmItemLookUp.Show()
    End Sub
End Class