Public Class frmUserManagement

    Dim Save_userRule As New User_rule
    Dim Save_user As New Sys_user


    Private Sub btnSaveAP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAP.Click
        'Dim adPriv_save As New User_rule

        'With adPriv_save
        '    .Privilege_Type = txtPrivilegeType.Text
        '    .Access_Level = txtAccessLevel.Text
        'End With

        'If Not adPriv_save.adpri_Save(txtPrivilegeType.Text) Then
        '    Exit Sub
        'End If

        'MsgBox("Successfully saved.", MsgBoxStyle.Information, "")
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtUsername.Focus()

        If Not ifTblExist("TBL_USER_DEFAULT") Then
            Create()
        End If
       
        Load_users()
    End Sub

    Private Sub Load_users()
        Dim s_user As New Sys_user

        With s_user
            For Each dr As DataRow In .dsUSEr.Tables(0).Rows
                .Users(dr.Item("USERID"))
                Dim lv As ListViewItem = lvUserList.Items.Add(.ID)
                lv.SubItems.Add(.FIRSTNAME & " " + .MIDDLENAME & " " + .LASTNAME)
            Next
        End With

    End Sub

    Private Sub Create()
        User_rule_mod.Create_User_table()
        User_rule_mod.Create_User_history()
    End Sub

    Private Sub Load_Privileges()
        Dim mysql As String = "SELECT * FROM TBL_USERRULE"
        Dim ds As DataSet = LoadSQL(mysql, "TBL_USERRULE")

        For Each dr As DataRow In ds.Tables(0).Rows
            dgRulePrivilege.Rows.Add(dr.Item("PRIVILEGE_TYPE"))
        Next
    End Sub

    Private Sub chkShowPassword_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowPassword.CheckedChanged
        If chkShowPassword.Checked = True Then
            txtPassword.UseSystemPasswordChar = False
            txtPasword1.UseSystemPasswordChar = False
        Else
            txtPassword.UseSystemPasswordChar = True
            txtPasword1.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim result As DialogResult = MsgBox("Do you want to save this privilege?", MsgBoxStyle.YesNo, "Save")
        If result = MsgBoxResult.No Then
            Exit Sub
        End If

        User_rule_mod.Create_User_Rule_Table()

        With Save_userRule
            For Each dg As DataGridViewRow In dgRulePrivilege.Rows
                .Privilege_Type = dg.Cells(0).Value
                If dg.Cells(1).Value = True Then
                    .Access_Type = True
                ElseIf dg.Cells(2).Value = True Then
                    .Access_Type = True
                Else
                    .Access_Type = True
                End If
                If .adpri_Save(dg.Cells(0).Value) Then
                    Console.WriteLine("Save.")
                End If
            Next
        End With


        MsgBox("Successfully Saved.", MsgBoxStyle.Information, "Save")
    End Sub

    Private Sub dgRulePrivilege_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgRulePrivilege.CellContentClick

    End Sub

    Private Sub btnCreateAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateAccount.Click
        If Not IsValid() Then Exit Sub

        Dim result As DialogResult = MsgBox("Do you want save this account?", MsgBoxStyle.YesNo, "Adding Account")
        If result = vbNo Then Exit Sub
        Dim num As String = txtContactnumber.Text
        num = num.Replace("-", "")

        Create()

        With Save_user
            .USERNAME = txtUsername.Text
            .FIRSTNAME = txtFirstname.Text
            .MIDDLENAME = txtMiddlename.Text
            .LASTNAME = txtLastname.Text
            .USERPASS = txtPassword.Text
            .EMAIL_ADDRESS = txtEmailaddress.Text
            .CONTACTNO = num
            .BIRTHDAY = txtBirthday.Text

            If rbFemale.Checked Then
                .GENDER = rbFemale.Text
            Else
                .GENDER = rbMale.Text
            End If
            .AGE = GetCurrentAge(txtBirthday.Text)
        End With

        If Not Save_user.add_USER Then
            Exit Sub
        End If

        MsgBox("Account successfully added.", MsgBoxStyle.Information, "Adding Account")
    End Sub

    Private Sub PhoneSeparator(ByVal PhoneField As TextBox, ByVal e As KeyPressEventArgs, Optional ByVal isPhone As Boolean = False)
        Dim charPos() As Integer = {}
        If PhoneField.Text = Nothing Then Return

        Select Case PhoneField.Text.Substring(0, 1)
            Case "0"
                charPos = {4, 8}
            Case "9"
                charPos = {3, 7} '922-797-7559
            Case "+"
                charPos = {3, 7, 11} '+63-919-797-7559
            Case "6"
                charPos = {2, 6, 10} '63-919-797-7559
        End Select
        If isPhone Then
            Select Case PhoneField.Text.Substring(0, 1)
                Case "0"
                    charPos = {3, 7}
                Case Else
                    charPos = {2, 6}
            End Select
        End If

        For Each pos In charPos
            If PhoneField.TextLength = pos And Not e.KeyChar = vbBack Then
                PhoneField.Text &= "-"
                PhoneField.SelectionStart = pos + 1
            End If
        Next
    End Sub

    Private Sub txtContactnumber_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtContactnumber.KeyPress
        DigitOnly(e)
        PhoneSeparator(txtContactnumber, e)
    End Sub

    Private Function IsValid() As Boolean

        If txtUsername.Text = "" Then txtUsername.Focus() : Return False
        If txtFirstname.Text = "" Then txtFirstname.Focus() : Return False
        If txtLastname.Text = "" Then txtLastname.Focus() : Return False
        If txtPassword.Text = "" Then txtPassword.Focus() : Return False
        If txtPasword1.Text = "" Then txtPasword1.Focus() : Return False
        If txtEmailaddress.Text = "" Then txtEmailaddress.Focus() : Return False

        If rbFemale.Checked = False And rbMale.Checked = False Then MsgBox("Select gender type", MsgBoxStyle.Exclamation, "Warning") : Return False

        If txtPassword.Text <> txtPasword1.Text Then MsgBox("Password not matched!", MsgBoxStyle.Exclamation, "Warning") _
           : txtPassword.Focus() : Return False

        If GetCurrentAge(txtBirthday.Text) < 18 Then MsgBox("Age must be 18 and above.", MsgBoxStyle.Exclamation, "Warning") : Return False

        If txtContactnumber.Text <> "" Then
            If txtContactnumber.TextLength < 11 Then MsgBox("Contact Number is not less than 11 digit.", MsgBoxStyle.Exclamation, "Warning") : txtContactnumber.Focus() : Return False
        Else
            Return True
        End If

        Return True
    End Function


    Private Sub lvUserList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvUserList.DoubleClick
        Populate_to_txtFields()
    End Sub

    Private Sub Populate_to_txtFields()
        Dim user As New Sys_user

        With user
            .Users(lvUserList.FocusedItem.Text)
            txtUsername.Text = .USERNAME
            txtFirstname.Text = .FIRSTNAME
            txtMiddlename.Text = .MIDDLENAME
            txtLastname.Text = .LASTNAME
            txtPassword.Text = DecryptString(.USERPASS)
            txtPasword1.Text = DecryptString(.USERPASS)
            txtEmailaddress.Text = .EMAIL_ADDRESS
            txtContactnumber.Text = .CONTACTNO
            txtBirthday.Text = .BIRTHDAY

            If .GENDER = "Male" Then
                rbMale.Checked = True
            Else
                rbFemale.Checked = True
            End If

        End With
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim count As Integer() = {1, 2, 3}
        Dim tmpuser As New Sys_user

        For Each c In count
            If Not tmpuser.Count_LOCKDOWN(c) Then

            Else
                On Error Resume Next
            End If

        Next
    End Sub
End Class
