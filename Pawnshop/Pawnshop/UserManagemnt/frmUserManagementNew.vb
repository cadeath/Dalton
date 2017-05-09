Public Class frmUserManagementNew
    Dim Save_userRule As New User_rule
    Dim Save_user As New Sys_user
    Dim Add_user_Privilege As New Sys_user
    Dim Failed_attmp As New Sys_user
    Dim Load_Failed As New Sys_user

    Dim priv_list As New List(Of String)()

    Dim privilege_chunk As New TextBox
    Dim i As Integer
    Dim tmpID As Integer
    Friend AccessType As String = ""
    Dim isLoading As Boolean = False

    Enum MODULES
        LOAD = 0
        SEARCH = 1
    End Enum

    Private Sub frmUserManagementNew_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtUsername.Focus()
        ChkInactivateUser.Visible = False
        lblStatus.Visible = False
        lblUserType.Visible = False

        Load_Privileges(False)
        Load_users()
        Load_ALL_users()
        Verification()
        LoadAccntValidation()
    End Sub

    Private Sub Load_users()
        Dim s_user As New Sys_user

        Dim mysql As String = "SELECT * FROM TBL_USER_DEFAULT WHERE STATUS <> 0"
        Dim ds As DataSet = LoadSQL(mysql, "TBL_DEFAULT_USER")

        If ds.Tables(0).Rows.Count = 0 Then Exit Sub

        lvUserList.Items.Clear()
        With s_user
            For Each dr As DataRow In ds.Tables(0).Rows
                .Users(dr.Item("USERID"))
                Dim lv As ListViewItem = lvUserList.Items.Add(.ID)
                lv.SubItems.Add(.FIRSTNAME & " " + .MIDDLENAME & " " + .LASTNAME)
            Next
        End With

    End Sub

    Private Sub Load_Privileges(ByVal IS_UPDATE As Boolean)

        If IS_UPDATE = False Then
            Dim mysql As String = "SELECT * FROM TBL_USERRULE ORDER BY USERRULE_ID"
            Dim ds As DataSet = LoadSQL(mysql, "TBL_USERRULE")

            Try
                dgRulePrivilege.Rows.Clear()
                For Each dr As DataRow In ds.Tables(0).Rows
                    dgRulePrivilege.Rows.Add(dr.Item("USERRULE_ID"), dr.Item("Privilege_Type"))
                Next
            Catch ex As Exception

            End Try
        Else
            Populate_to_txtFields()
            Load_priv_Main_table()
        End If

    End Sub


    Private Sub Load_priv_Main_table()
        Dim mysql As String = "SELECT * FROM TBL_USERRULE ORDER BY USERRULE_ID"
        Dim ds As DataSet = LoadSQL(mysql, "TBL_USERRULE")
        Dim ds1 As DataSet
        If ds.Tables(0).Rows.Count = 0 Then Exit Sub

        For Each dr As DataRow In ds.Tables(0).Rows
            If i = 0 Then
                Dim mysql1 As String = "SELECT * FROM TBL_USERLINE WHERE PRIVILEGE_TYPE ='" & dr.Item("PRIVILEGE_TYPE") _
                                       & "' AND USERID =" & lvUserList.FocusedItem.Text & ""
                ds1 = LoadSQL(mysql1, "TBL_USERLINE")
            Else
                Dim mysql1 As String = "SELECT * FROM TBL_USERLINE WHERE PRIVILEGE_TYPE ='" & dr.Item("PRIVILEGE_TYPE") _
                                      & "' AND USERID =" & lvALL_USER_LIST.FocusedItem.Text & ""
                ds1 = LoadSQL(mysql1, "TBL_USERLINE")
            End If



            If ds1.Tables(0).Rows.Count = 0 Then
                dgRulePrivilege.Rows.Add(0, dr.Item("Privilege_Type"))
            Else
                On Error Resume Next
            End If
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

    Public Function ValidateEmail(ByVal strCheck As String) As Boolean
        Try
            Dim vEmailAddress As New System.Net.Mail.MailAddress(strCheck)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Private Sub btnCreateAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateAccount.Click
        If btnCreateAccount.Text = "&Create Account" Then
            Save()
        ElseIf btnCreateAccount.Text = "&Edit" Then
            btnCreateAccount.Text = "&Update"
            GroupBox2.Enabled = True
            GroupBox1.Enabled = True : isLoading = False
            dgRulePrivilege.Enabled = True : Exit Sub
        Else
            update_user()
        End If
    End Sub


    Private Sub Save()
        If Not IsValid() Then Exit Sub

        Dim result As DialogResult = MsgBox("Do you want save this account?", MsgBoxStyle.YesNo, "Saving Account")
        If result = vbNo Then Exit Sub
        Dim num As String = txtContactnumber.Text
        num = num.Replace("-", "")

        With Save_user
            .USERNAME = txtUsername.Text
            .FIRSTNAME = UppercaseFirstLetter(txtFirstname.Text)
            .MIDDLENAME = UppercaseFirstLetter(txtMiddlename.Text)
            .LASTNAME = UppercaseFirstLetter(txtLastname.Text)

            tmpPassword = EncryptString(txtPassword.Text)

            .USERPASS = txtPassword.Text
            .EMAIL_ADDRESS = txtEmailaddress.Text
            .CONTACTNO = num
            .BIRTHDAY = txtBirthday.Text

            .GENDER = IIf(rbMale.Checked, rbMale.Text, rbFemale.Text)
            .AGE = GetCurrentAge(txtBirthday.Text)

            PASSWORD_AGE_COUNT = txtPasswordAge.Text


            If CHKISEXPIRED.Checked = True Then
                PASSWORD_EXPIRY_COUNT = txtAddDays.Text
                .COUNTER = txtAddDays.Text
                .ISEXPIRED = 1
            Else
                .COUNTER = 0
                .ISEXPIRED = 0
            End If

            If txtFailedAttemp.Text = "" Then
                .FAILEDATTEMPNUM = 0
            Else
                .FAILEDATTEMPNUM = txtFailedAttemp.Text
            End If

            .FAILEDATTEMPSTAT = IIf(chkFailedAttemp.Checked, "Enable", "Disable")
            .USERTYPE = "User"
        End With

        If CHKISEXPIRED.Checked = True Then
            If Not Save_user.add_USER() Then
                Exit Sub
            End If
        Else
            If Not Save_user.add_USER(False) Then
                Exit Sub
            End If
        End If

        With Save_user
            For Each row As DataGridViewRow In dgRulePrivilege.Rows
                .PRIVILEGE_TYPE = row.Cells(1).Value
                .ACCESSTYPE = row.Cells(2).Value

                If .PRIVILEGE_TYPE = "" Then Exit For
                .Save_Privilege()
            Next
        End With

        Load_users()
        Load_ALL_users()
        ClearFields("")
        MsgBox("Account successfully saved.", MsgBoxStyle.Information, "Saving Account")
    End Sub

    Private Sub update_user()
        If Not IsValid() Then Exit Sub

        Dim result As DialogResult = MsgBox("Do you want update this account?", MsgBoxStyle.YesNo, "Updating Account")
        If result = vbNo Then Exit Sub
        Dim num As String = txtContactnumber.Text
        num = num.Replace("-", "")

        With Save_user
            If i = 0 Then
                .ID = tmpID
            Else
                .ID = tmpID
            End If
            .USERNAME = txtUsername.Text
            .FIRSTNAME = UppercaseFirstLetter(txtFirstname.Text)
            .MIDDLENAME = UppercaseFirstLetter(txtMiddlename.Text)
            .LASTNAME = UppercaseFirstLetter(txtLastname.Text)

            If txtPassword.Text <> "" Then
                tmpPassword = EncryptString(txtPassword.Text)
            End If

            .USERPASS = txtPassword.Text
            .EMAIL_ADDRESS = txtEmailaddress.Text
            .CONTACTNO = num
            .BIRTHDAY = txtBirthday.Text

            .GENDER = IIf(rbMale.Checked, rbMale.Text, rbFemale.Text)

            .AGE = GetCurrentAge(txtBirthday.Text)

            PASSWORD_AGE_COUNT = txtPasswordAge.Text

            If CHKISEXPIRED.Checked = True Then
                PASSWORD_EXPIRY_COUNT = IIf(txtAddDays.Text, txtAddDays.Text, 0)
                .COUNTER = txtAddDays.Text
                .ISEXPIRED = 1
            Else
                .COUNTER = 0
                .ISEXPIRED = 0
            End If

            If ChkInactivateUser.Checked = True Then
                .UserStatus = 0
            Else
                .UserStatus = 1
            End If

            .COUNTER = txtAddDays.Text

            If txtFailedAttemp.Text = "" Then
                .FAILEDATTEMPNUM = 0
            Else
                .FAILEDATTEMPNUM = txtFailedAttemp.Text
            End If

            .FAILEDATTEMPSTAT = IIf(chkFailedAttemp.Checked, "Enable", "Disable")

        End With

        If CHKISEXPIRED.Checked = True Then
            If Not Save_user.Update_USER() Then
                Exit Sub
            End If
        Else
            If Not Save_user.Update_USER(False) Then
                Exit Sub
            End If
        End If

        With Save_user
            For Each row As DataGridViewRow In dgRulePrivilege.Rows
                .PRIVILEGE_TYPE = row.Cells(1).Value
                .ACCESSTYPE = row.Cells(2).Value
                .Update_Privilege(row.Cells(0).Value)
            Next
        End With

        Load_users()
        Load_ALL_users()
        ClearFields("")
        AccountRule.LOAD_USER_RULES()
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

        If lblUserType.Text <> "User Type: Admin" Or lblUserType.Text = "" Then
            If txtLastname.Text = "" Then txtLastname.Focus() : Return False
        End If

        If btnCreateAccount.Text <> "&Create Account" Then

            If txtPassword.Text <> "" Then
                If txtPassword.Text <> txtPasword1.Text Then MsgBox("Password not matched!", MsgBoxStyle.Exclamation, "Warning") _
        : txtPassword.Focus() : Return False

                If txtPassword.TextLength < 6 Then MsgBox("Password atleast 6 or above combinations.", _
               MsgBoxStyle.Critical, "Error") : txtPassword.Focus() : Return False
            End If
        Else

            If txtPassword.Text = "" Then txtPassword.Focus() : Return False
            If txtPasword1.Text = "" Then txtPasword1.Focus() : Return False
            If txtPassword.TextLength < 6 Then MsgBox("Password atleast 6 or above combinations.", _
                MsgBoxStyle.Critical, "Error") : txtPassword.Focus() : Return False

            If txtPassword.Text <> txtPasword1.Text Then MsgBox("Password not matched!", MsgBoxStyle.Exclamation, "Warning") _
        : txtPassword.Focus() : Return False

        End If

        If lvUserList.SelectedItems.Count = 0 Then
            If txtEmailaddress.Text = "" Then txtEmailaddress.Focus() : tbControl.SelectedTab = TabPage1 : Return False

            If Not ValidateEmail(txtEmailaddress.Text) Then txtEmailaddress.Focus() : tbControl.SelectedTab = TabPage1 _
          : MsgBox("Email is not valid!", MsgBoxStyle.Critical, "Error") : Return False

            If txtContactnumber.Text = "" Then txtContactnumber.Focus() : Return False

            If txtContactnumber.Text <> "" Then
                If txtContactnumber.TextLength < 11 Then MsgBox("Contact Number is not less than 11 digit.", _
                    MsgBoxStyle.Exclamation, "Warning") : txtContactnumber.Focus() : Return False
            End If
        End If

        If rbFemale.Checked = False And rbMale.Checked = False Then MsgBox("Select gender type", MsgBoxStyle.Exclamation, "Warning") : Return False

        If txtPassword.Text <> txtPasword1.Text Then MsgBox("Password not matched!", MsgBoxStyle.Exclamation, "Warning") _
           : txtPassword.Focus() : Return False

        If lblUserType.Text <> "User Type: Admin" Or lblUserType.Text = "" Then

            If GetCurrentAge(txtBirthday.Text) < 18 Then MsgBox("Age must be 18 and above.", MsgBoxStyle.Exclamation, "Warning") : Return False

            If dgRulePrivilege.Rows.Count = 0 Then Return False

            For Each row As DataGridViewRow In dgRulePrivilege.Rows
                If row.Cells(2).Value = "" Then tbControl.SelectedTab = TabPage2 : Return False
            Next

            If txtAddDays.Text = 0 Then tbControl.SelectedTab = TabPage3 : txtAddDays.Focus() : Return False
            If txtPasswordAge.Text = 0 Then tbControl.SelectedTab = TabPage3 : txtPasswordAge.Focus() : Return False
            If txtFailedAttemp.Text = 0 Then tbControl.SelectedTab = TabPage3 : txtFailedAttemp.Focus() : Return False
        End If

        If CHKISEXPIRED.Checked = True Then
            If txtAddDays.Text = "" Then tbControl.SelectedTab = TabPage3 : txtAddDays.Focus() : Return False
        End If

        If chkPasswrdAge.Checked = True Then
            If txtPasswordAge.Text = "" Then tbControl.SelectedTab = TabPage3 : txtPasswordAge.Focus() : Return False
        End If

        If chkFailedAttemp.Checked = True Then
            If txtFailedAttemp.Text = "" Then tbControl.SelectedTab = TabPage3 : txtFailedAttemp.Focus() : Return False
        End If

        Return True
    End Function


    Private Sub lvUserList_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvUserList.DoubleClick
        i = MODULES.LOAD
        Load_Privileges(True)
    End Sub

    Private Sub Populate_to_txtFields()
        Dim user As New Sys_user
        isLoading = True
        With user
            If i = 0 Then
                .Users(lvUserList.FocusedItem.Text)
                tmpID = lvUserList.FocusedItem.Text
            Else
                .Users(lvALL_USER_LIST.FocusedItem.Text)
                tmpID = lvALL_USER_LIST.FocusedItem.Text
            End If

            txtUsername.Text = .USERNAME
            txtFirstname.Text = .FIRSTNAME
            txtMiddlename.Text = .MIDDLENAME
            txtLastname.Text = .LASTNAME
            txtEmailaddress.Text = .EMAIL_ADDRESS
            txtContactnumber.Text = .CONTACTNO
            txtBirthday.Text = .BIRTHDAY

            If .GENDER = "Male" Then
                rbMale.Checked = True
            Else
                rbFemale.Checked = True
            End If

            If .PASSWORD_EXPIRY = "01/01/0001" Then
                CHKISEXPIRED.Checked = False
            Else
                CHKISEXPIRED.Checked = True
                txtPasswordAge.Text = Date_Calculation(.PASSWORD_EXPIRY)
            End If

            If .PASSWORD_AGE = "01/01/0001" Then
                chkPasswrdAge.Checked = False
                txtPasswordAge.Text = 0
            Else
                chkPasswrdAge.Checked = True
                txtPasswordAge.Text = Date_Calculation(.PASSWORD_AGE)
            End If

            If .ISEXPIRED = 1 Then
                CHKISEXPIRED.Checked = True
            Else
                CHKISEXPIRED.Checked = False
            End If

            lblStatus.Visible = True
            lblUserType.Visible = True
            If .UserStatus = 0 Then
                lblStatus.Text = "User Status: Inactive"
                ChkInactivateUser.Checked = True
            Else
                lblStatus.Text = "User Status: Active"
                ChkInactivateUser.Checked = False
            End If

            If .USERTYPE = "Admin" Then lblUserType.Text = "User Type: " & .USERTYPE
            If .USERTYPE = "User" Then lblUserType.Text = "User Type: " & .USERTYPE

            txtAddDays.Text = .COUNTER
            txtFailedAttemp.Text = .FAILEDATTEMPNUM

            If .FAILEDATTEMPNUM > 0 Then
                chkFailedAttemp.Checked = True
            Else
                chkFailedAttemp.Checked = False
            End If

            'Global variable
            SYSTEM_USERID = .ID
            tmpPassword = .USERPASS

            dgRulePrivilege.Rows.Clear()
            .LOAD_USERLINE_ROWS(.ID)
        End With

        ChkInactivateUser.Visible = True

        btnCreateAccount.Text = "&Edit"
        GroupBox1.Enabled = False
        GroupBox2.Enabled = False
        dgRulePrivilege.Enabled = False
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

        txtAddDays.Text = str
        txtPasswordAge.Text = str
        txtFailedAttemp.Text = str

        CHKISEXPIRED.Checked = False
        ChkInactivateUser.Visible = False

        GroupBox1.Enabled = True
        GroupBox2.Enabled = True

        dgRulePrivilege.Enabled = True
        lblStatus.Visible = False
        lblUserType.Visible = False

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


    Private Sub CHKISEXPIRED_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKISEXPIRED.CheckedChanged
        IS_EXPIRE()
    End Sub


    Private Sub IS_EXPIRE()
        If isLoading Then Exit Sub
        If CHKISEXPIRED.Checked = False Then
            txtAddDays.Text = 0
            txtAddDays.Enabled = False : Exit Sub
        End If
        txtAddDays.Enabled = True
        txtAddDays.Text = ""
    End Sub

    Private Sub txtSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If isEnter(e) Then
            Load_ALL_users()
        End If
    End Sub

    Private Sub Load_ALL_users()
        Dim ds As DataSet
        Dim s_user As New Sys_user

        If txtSearch.Text <> "" Then
            Dim mysql As String = "SELECT * FROM TBL_USER_DEFAULT US WHERE UPPER(US.FIRSTNAME) LIKE UPPER('%" & txtSearch.Text & "%')"
            ds = LoadSQL(mysql, "TBL_DEFAULT_USER")
        Else
            Dim mysql As String = "SELECT * FROM TBL_USER_DEFAULT WHERE STATUS <> 0"
            ds = LoadSQL(mysql, "TBL_DEFAULT_USER")
        End If

        lvALL_USER_LIST.Items.Clear()
        With s_user
            For Each dr As DataRow In ds.Tables(0).Rows
                .Users(dr.Item("USERID"))
                Dim lv As ListViewItem = lvALL_USER_LIST.Items.Add(.ID)
                Dim email As String = .EMAIL_ADDRESS
                lv.SubItems.Add(.FIRSTNAME & " " + .MIDDLENAME & " " + .LASTNAME)
                lv.SubItems.Add(email)
            Next
            txtSearch.Text = Nothing
        End With

    End Sub

    Private Sub lvALL_USER_LIST_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvALL_USER_LIST.DoubleClick
        i = MODULES.SEARCH
        Load_Privileges(True)
        Load_ALL_users()
        tbControl.SelectedTab = TabPage1
    End Sub


    Private Sub txtFailedAttemp_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFailedAttemp.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub chkPasswrdAge_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPasswrdAge.CheckedChanged
        If isLoading Then Exit Sub
        If chkPasswrdAge.Checked = False Then
            txtPasswordAge.Text = 0
            txtPasswordAge.Enabled = False : Exit Sub
        End If
        txtPasswordAge.Enabled = True
        txtPasswordAge.Text = ""
    End Sub

    Private Sub chkFailedAttemp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFailedAttemp.CheckedChanged
        If isLoading Then Exit Sub
        If chkFailedAttemp.Checked = False Then
            txtFailedAttemp.Text = 0
            txtFailedAttemp.Enabled = False : Exit Sub
        End If
        txtFailedAttemp.Enabled = True
        txtFailedAttemp.Text = ""
    End Sub

    Private Sub Verification()
        If AccessType = "Read Only" Then
            btnCreateAccount.Enabled = False
        End If
    End Sub

    Private Sub LoadAccntValidation()
        txtAddDays.Text = GetOption("AccountExpiry")
        txtPasswordAge.Text = GetOption("PasswordExpiry")
        txtFailedAttemp.Text = GetOption("FailedAttempt")
    End Sub

    Private Sub chkGetDefaultVal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGetDefaultVal.CheckedChanged
        LoadAccntValidation()
    End Sub
End Class