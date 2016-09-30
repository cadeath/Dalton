Public Class frm_PanelYesNo
    Friend retID As Integer = 0

    Private Sub rbYes_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles rbYes.KeyPress, rbNo.KeyPress
        If isEnter(e) Then
            btnSubmit.PerformClick()
        End If
    End Sub

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim tmpResult As String = ""
        If rbYes.Checked Then
            tmpResult = "Yes"
        ElseIf rbNo.Checked Then
            tmpResult = "No"
        End If

        frmPawningItemNew.DisplayValue(tmpResult, retID)
        Me.Close()
    End Sub
End Class