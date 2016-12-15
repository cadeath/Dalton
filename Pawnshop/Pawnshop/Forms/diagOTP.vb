Imports totp

Public Class diagOTP

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
       
        If otp.VerifyPIN(txtPIN.Text) Then
            Me.Close()
            OTPGenerate()
        Else
            MsgBox("INVALID PIN", MsgBoxStyle.Critical)
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
    End Enum

    Friend FormType As OTPType = OTPType.UserManagement
    Friend Sub OTPGenerate()
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
        End Select
    End Sub

    Private Sub diagOTP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtPIN.Text = ""
    End Sub

    Private Sub txtPIN_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPIN.KeyPress
        If isEnter(e) Then btnSubmit.PerformClick()
    End Sub
End Class