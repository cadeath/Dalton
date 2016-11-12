Imports totp

Public Class diagOTP

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim mod_name As String = ""

        If FormType = OTPType.UserManagement Then
            mod_name = "User Management"

        ElseIf FormType = OTPType.Settings Then
            mod_name = "Settings"

        ElseIf FormType = OTPType.VoidInsurance Then
            mod_name = "Void Insurance"

        ElseIf FormType = OTPType.VoidPawning Then
            mod_name = "Void Pawning"

        ElseIf FormType = OTPType.VoidBranchToBranch Then
            mod_name = "Void Branch To Branch"

        ElseIf FormType = OTPType.VoidMoneyTransfer Then
            mod_name = "Void Money Transfer"

        ElseIf FormType = OTPType.VoidMoneyExchange Then
            mod_name = "Void Money Exchange"

        ElseIf FormType = OTPType.VoidCashInOut Then
            mod_name = "Void Cash In/Out"

        ElseIf FormType = OTPType.Pullout Then
            mod_name = "PullOut"

        End If

        If otp.VerifyPIN(txtPIN.Text, mod_name) Then
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
                frmPawnItem.VoidPawning()
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