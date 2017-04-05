Public Class frmOTPManager
    Private strcode As String
    Private strAppname As String

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        If Not isValid() Then MsgBox("Please check the fields", MsgBoxStyle.Critical, "Error") : Exit Sub

        If rbInventory.Checked = True Then
            strcode = "OTPInventory"
            strAppname = "Dalton - Inventory"

        ElseIf rbPullout.Checked = True Then
            strcode = "OTPItemPullOut"
            strAppname = "Dalton - OTP Item PullOut"

        ElseIf rbSettings.Checked Then
            strcode = "OTPSettings"
            strAppname = "Dalton - OTP Settings"

        ElseIf rbStockout.Checked = True Then
            strcode = "OTPStockOut"
            strAppname = "Dalton - Stock Out"

        ElseIf rbUserManagement.Checked = True Then
            strcode = "OTPUser"
            strAppname = "Dalton - OTP User Management"

        ElseIf rbVoiding.Checked = True Then
            strcode = "OTPVoiding"
            strAppname = "Dalton - OTP Voiding"

        End If

        SetOTP(txtEmail.Text, strAppname, strcode)
    End Sub

    Private Sub SetOTP(ByVal Email As String, ByVal AppName As String, ByVal Code As String)
        With OtpSettings
            .Setup(Email)
            .AppName = AppName
            .SecretCode = Code
        End With

        txtManual.Text = OtpSettings.ManualCode
        txtQRURL.Text = OtpSettings.QRCode_URL
    End Sub

    Private Function isValid() As Boolean
        If txtEmail.Text = "" Then Return False
        If Not (txtEmail.Text.Contains("@") And txtEmail.Text.Contains(".")) Then Return False
        If strcode = String.Empty OrElse strAppname = String.Empty Then Return False

        Return True
    End Function

    Private Sub frmOTPManager_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cleartext()
    End Sub

    Private Sub Cleartext()
        txtEmail.Clear()
        txtManual.Clear()
        txtQRURL.Clear()
    End Sub
End Class