Public Class frmUserManagement

    Dim Save_userRule As New User_rule

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
        User_rule_mod.Create_User_table()
        User_rule_mod.Create_User_history()

        Dim result As DialogResult = MsgBox("Do you want save this account?", MsgBoxStyle.YesNo, "Adding Account")
        If result = vbNo Then
            Exit Sub
        End If



        MsgBox("Account successfully added.", MsgBoxStyle.Information, "Adding Account")
    End Sub

    Private Function IsValid() As Boolean
        If txtUsername.Text = "" Then txtUsername.Focus() : Return False
        If txtFirstname.Text = "" Then txtFirstname.Focus() : Return False
        If txtMiddlename.Text = "" Then txtMiddlename.Focus() : Return False
        If txtLastname.Text = "" Then txtLastname.Focus() : Return False
        If txtPassword.Text = "" Then txtPassword.Focus() : Return False
        If txtPasword1.Text = "" Then txtPasword1.Focus() : Return False
        If txtEmailaddress.Text = "" Then txtEmailaddress.Focus() : Return False
        If txtContactnumber.Text = "" Then txtContactnumber.Focus() : Return False
        If txtContactnumber.TextLength < 11 Then MsgBox("Contact Number is not less than 11 digit.") : txtContactnumber.Focus() : Return False
        If rbFemale.Checked = False And rbMale.Checked = False Then MsgBox("Select gender type", MsgBoxStyle.Information, "") : Return False
        If txtPassword.Text <> txtPasword1.Text Then MsgBox("Password not matched!", MsgBoxStyle.Critical, "Warning") & _ 
          : txtPassword.Focus() : Return False

    End Function
End Class
