Public Class frmUserManagement

    Dim Save_userRule As New User_rule
    Dim Save_user As New Sys_user
    Dim Add_user_Privilege As New Sys_user

    Dim priv_list As New List(Of String)()

    Dim privilege_chunk As New TextBox

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtUsername.Focus()
        If Not ifTblExist("TBL_USER_DEFAULT") Then
            Exit Sub
        End If
        Load_Privileges(False)
        Load_users()
    End Sub

    Private Sub Load_users()
        Dim s_user As New Sys_user

        lvUserList.Items.Clear()
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
        User_rule_mod.Create_User_Rule_Table()
        User_rule_mod.Create_User_LINE()
    End Sub

    Private Sub Load_Privileges(ByVal IS_UPDATE As Boolean)

        If IS_UPDATE = False Then
            Dim mysql As String = "SELECT * FROM TBL_USERRULE"
            Dim ds As DataSet = LoadSQL(mysql, "TBL_USERRULE")

            Try
                dgRulePrivilege.Rows.Clear()
                For Each dr As DataRow In ds.Tables(0).Rows
                    dgRulePrivilege.Rows.Add(dr.Item("Privilege_Type"), dr.Item("Access_Type"))
                Next
            Catch ex As Exception

            End Try
        Else
            Populate_to_txtFields()
        End If

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

    Private Function IsEmpty() As Boolean
        For Each rw As DataGridViewRow In dgRulePrivilege.Rows
            If rw.Cells(1).Value = "" Then MsgBox("Access Type must be filled up.", MsgBoxStyle.Exclamation, "Warning") : Return False
            If rw.Cells(0).Value = "" Then
                On Error Resume Next
            End If
        Next
        Return True
    End Function

    Private Sub btnCreateAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateAccount.Click

        If btnCreateAccount.Text = "&Create Account" Then
            Save()
        ElseIf btnCreateAccount.Text = "&Edit" Then
            btnCreateAccount.Text = "&Update"
            GroupBox1.Enabled = True
        Else
            update_user()
        End If

    End Sub


    Private Sub Save()
        If Not IsValid() Then Exit Sub

        Dim result As DialogResult = MsgBox("Do you want save this account?", MsgBoxStyle.YesNo, "Adding Account")
        If result = vbNo Then Exit Sub
        Dim num As String = txtContactnumber.Text
        num = num.Replace("-", "")

        Create()

        With Save_user
            .USERNAME = txtUsername.Text
            .FIRSTNAME = UppercaseFirstLetter(txtFirstname.Text)
            .MIDDLENAME = UppercaseFirstLetter(txtMiddlename.Text)
            .LASTNAME = UppercaseFirstLetter(txtLastname.Text)
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

        With Save_user
            For Each row As DataGridViewRow In dgRulePrivilege.Rows
                .USERID = .GETUSERID
                .PRIVILEGE_TYPE = row.Cells(1).Value
                .ACCESSTYPE = row.Cells(2).Value
                .Save_Privilege(row.Cells(0).Value)
            Next
        End With

            Load_users()
            ClearFields("")
            MsgBox("Account successfully added.", MsgBoxStyle.Information, "Adding Account")
    End Sub

    Private Sub update_user()
        If Not IsValid() Then Exit Sub

        Dim result As DialogResult = MsgBox("Do you want update this account?", MsgBoxStyle.YesNo, "Updating Account")
        If result = vbNo Then Exit Sub
        Dim num As String = txtContactnumber.Text
        num = num.Replace("-", "")

        With Save_user
            .USERNAME = txtUsername.Text
            .FIRSTNAME = UppercaseFirstLetter(txtFirstname.Text)
            .MIDDLENAME = UppercaseFirstLetter(txtMiddlename.Text)
            .LASTNAME = UppercaseFirstLetter(txtLastname.Text)
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

        If Not Save_user.Update_USER Then
            Exit Sub
        End If

        With Save_user
            For Each row As DataGridViewRow In dgRulePrivilege.Rows
                .USERID = .GETUSERID
                .PRIVILEGE_TYPE = row.Cells(1).Value
                .ACCESSTYPE = row.Cells(2).Value
                .Save_Privilege(row.Cells(0).Value)
            Next
        End With

        Load_users()
        ClearFields("")
        MsgBox("Account successfully updated.", MsgBoxStyle.Information, "Updating Account")
    End Sub


    Private Sub PhoneSeparator(ByVal PhoneField As TextBox, ByVal e As KeyPressEventArgs, Optional ByVal isPhone As Boolean = False)
        Dim charPos() As Integer = {}
        If PhoneField.Text = Nothing Then Return

        Select Case txtContactnumber.Text.Substring(0, 1)
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
            Select Case txtContactnumber.Text.Substring(0, 1)
                Case "0"
                    charPos = {3, 7}
                Case Else
                    charPos = {2, 6}
            End Select
        End If

        For Each pos In charPos
            If txtContactnumber.TextLength = pos And Not e.KeyChar = vbBack Then
                txtContactnumber.Text &= "-"
                txtContactnumber.SelectionStart = pos + 1
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

        If txtPassword.TextLength < 6 Then MsgBox("Password atleast 6 or above combinations.", MsgBoxStyle.Critical, "Error") : txtPassword.Focus() : Return False
        Return True

        For Each row As DataGridViewRow In dgRulePrivilege.Rows
            If row.Cells(2).Value = "" Then Exit Function
        Next
    End Function


    Private Sub lvUserList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvUserList.DoubleClick
        Load_Privileges(True)
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
            SYSTEM_USERID = .ID

            .LOAD_USERLINE_ROWS(SYSTEM_USERID)
        End With


        btnCreateAccount.Text = "&Edit"
        GroupBox1.Enabled = False
    End Sub

    Private Sub ClearFields(ByVal str As String)
        txtUsername.Text = str
        txtFirstname.Text = str
        txtMiddlename.Text = str
        txtLastname.Text = str
        txtPassword.Text = str
        txtPasword1.Text = str
        txtEmailaddress.Text = str
        txtContactnumber.Text = str
        txtBirthday.Text = Now.ToShortDateString
        rbFemale.Checked = False
        rbMale.Checked = False
        GroupBox1.Enabled = True
        btnCreateAccount.Text = "&Create Account"
        Load_Privileges(False)
    End Sub

    Private Sub btnCancell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancell.Click
        Dim result As DialogResult = MsgBox("Do you want to cancel?", MsgBoxStyle.YesNo, "Cancel")
        If result = vbNo Then
            Exit Sub
        End If
        ClearFields("")
    End Sub

   
   
 
End Class
