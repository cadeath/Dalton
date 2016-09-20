Public Class frmInterestScheme

  
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Not isValid() Then Exit Sub
    End Sub

    Private Sub reaDOnlyTrue()
        txtDayFrom.ReadOnly = True
        txtDayTo.ReadOnly = True
        txtInterest.ReadOnly = True
        txtPenalty.ReadOnly = True
        txtRemarks.ReadOnly = True

        txtDescription.ReadOnly = True
        txtSchemeName.ReadOnly = True
    End Sub

    Friend Sub reaDOnlyFalse()
        txtDayFrom.ReadOnly = False
        txtDayTo.ReadOnly = False
        txtInterest.ReadOnly = False
        txtPenalty.ReadOnly = False
        txtRemarks.ReadOnly = False

        txtDescription.ReadOnly = False
        txtSchemeName.ReadOnly = False
    End Sub

    Private Function isValid() As Boolean

        If txtSchemeName.Text = "" Then txtSchemeName.Focus() : Return False
        If txtDescription.Text = "" Then txtDescription.Focus() : Return False

        If txtDayFrom.Text = "" Then txtDayFrom.Focus() : Return False
        If txtDayTo.Text = "" Then txtDayTo.Focus() : Return False
        If txtInterest.Text = "" Then txtInterest.Focus() : Return False
        If txtPenalty.Text = "" Then txtPenalty.Focus() : Return False
        If txtRemarks.Text = "" Then txtRemarks.Focus() : Return False

        Return True
    End Function

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class