Public Class frmUserInfor
    Private Sub btnCreateAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateAccount.Click
        If Not IsValid() Then Exit Sub

        Dim num As String = txtContactnumber.Text
        num = num.Replace("-", "")

        With selected_USEr
            .FIRSTNAME = UppercaseFirstLetter(txtFirstname.Text)
            .MIDDLENAME = UppercaseFirstLetter(txtMiddlename.Text)
            .LASTNAME = UppercaseFirstLetter(txtLastname.Text)
            .EMAIL_ADDRESS = txtEmailaddress.Text
            .CONTACTNO = num
            .BIRTHDAY = txtBirthday.Text
            .GENDER = IIf(rbMale.Checked, rbMale.Text, rbFemale.Text)
            .AGE = GetCurrentAge(txtBirthday.Text)
            .UserProUpdate()
        End With

        MsgBox("Profile successfully updated.", MsgBoxStyle.Information, "Update")
        frmMainnEW.NotYetLogin() : frmLogin.Show()
        Me.Close()
    End Sub


    Private Function IsValid() As Boolean
        If txtFirstname.Text = "" Then txtFirstname.Focus() : Return False
        If txtLastname.Text = "" Then txtLastname.Focus() : Return False

        If txtEmailaddress.Text = "" Then txtEmailaddress.Focus() : Return False

        If Not ValidateEmail(txtEmailaddress.Text) Then txtEmailaddress.Focus() _
                : MsgBox("Email is not valid!", MsgBoxStyle.Critical, "Error") : Return False

        If rbFemale.Checked = False And rbMale.Checked = False Then MsgBox("Select gender type", MsgBoxStyle.Exclamation, "Warning") : Return False
        If GetCurrentAge(txtBirthday.Text) < 18 Then MsgBox("Age must be 18 and above.", MsgBoxStyle.Exclamation, "Warning") : Return False
        Return True
    End Function


    Public Function ValidateEmail(ByVal strCheck As String) As Boolean
        Try
            Dim vEmailAddress As New System.Net.Mail.MailAddress(strCheck)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
End Class