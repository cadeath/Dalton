Imports totp

Public Class diagGeneralOTP
    Friend GeneralOTP As OneTimePassword
    Friend isCorrect As Boolean = False

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If Not IsNumeric(txtPIN.Text) Then Exit Sub
        If GeneralOTP.isCorrect(txtPIN.Text) Then
            isCorrect = True
        Else
            MsgBox("Invalid PIN", MsgBoxStyle.Information)
            txtPIN.SelectAll()
            Exit Sub
        End If

        Me.Close()
    End Sub

    Private Sub diagGeneralOTP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtPIN.Clear()
        txtPIN.Focus()
    End Sub

    Private Sub txtPIN_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPIN.KeyPress
        If isEnter(e) Then
            btnSubmit.PerformClick()
        End If
    End Sub
End Class