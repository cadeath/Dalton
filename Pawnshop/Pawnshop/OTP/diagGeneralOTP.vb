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

    Enum OTPType As Integer
        UserManagement = 0
        Settings = 1
        VoidInsurance = 2
        VoidPawning = 3
        VoidBranchToBranch = 4
        VoidMoneyTransfer = 5
        VoidMoneyExchange = 6
        VoidCashInOut = 7
        Pullout = 8
        VoidSales = 9
    End Enum

    Friend FormType As OTPType = OTPType.UserManagement
    Private Sub OTPGenerate()
        Select Case FormType
            Case OTPType.UserManagement
                frmUserManagement.AddUserManagement()
            Case OTPType.Settings
                frmSettings.UpdateSetting()
            Case OTPType.VoidInsurance
                frmInsurance.VoidInsurance()
            Case OTPType.VoidPawning
                frmPawningItemNew.VoidPawning()
            Case OTPType.VoidBranchToBranch
                frmBorrowBrowse.VoidBorrowing()
            Case OTPType.VoidMoneyTransfer
                frmMTlist.VoidMoneyTransfer()
            Case OTPType.VoidMoneyExchange
                frmDollarList.VoidMoneyExchange()
            Case OTPType.VoidCashInOut
                frmCIO_List.VoidCIO()
            Case OTPType.Pullout
                qryPullOut.Show()
            Case OTPType.VoidSales
                frmPrint.Void()
        End Select
    End Sub

End Class