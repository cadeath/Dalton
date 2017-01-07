Public Class frmLayAway

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

    End Sub

    Private Sub frmLayAway_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearText()
    End Sub

    Private Sub ClearText()
        txtAddress.Clear()
        txtCustomer.Clear()
        txtItemCode.Clear()
        txtDescription.Clear()
        txtAmount.Clear()
        lblContact.Text = ""
        lblDOB.Text = ""
        lblCost.Text = ""
        lblPenalty.Text = ""
        lblBalance.Text = ""
    End Sub
End Class