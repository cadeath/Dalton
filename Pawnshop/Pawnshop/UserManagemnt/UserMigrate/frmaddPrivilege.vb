Public Class frmaddPrivilege
    Dim uRule As New User_rule
    Dim Priv As Sys_user

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If txtPrivilegeType.Text = "" Or cboAccessType.Text = "" Then Exit Sub
        Dim i As Integer = lvPrivilegeType.Items.Count
        lvPrivilegeType.Items.Add(txtPrivilegeType.Text)
        lvPrivilegeType.Items(i).SubItems.Add(cboAccessType.Text)
        txtPrivilegeType.Text = "" : cboAccessType.SelectedItem = Nothing
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If lvPrivilegeType.SelectedItems.Count = 0 Then Exit Sub
        lvPrivilegeType.SelectedItems(0).Remove()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If lvPrivilegeType.Items.Count = 0 Then Exit Sub
        Dim mssage As DialogResult = MsgBox("Do you want to save?", MsgBoxStyle.YesNo, "Question")
        If mssage = vbNo Then Exit Sub

        For Each privilege As ListViewItem In lvPrivilegeType.Items
            uRule.Privilege_Type = privilege.Text
            uRule.adpri_Save(privilege.Text)

            Priv = New Sys_user
            Priv.AutoAddPrivilege(privilege.Text, privilege.SubItems(1).Text)
        Next

        MsgBox("Successfully saved.", MsgBoxStyle.Information, "Save")
        lvPrivilegeType.Items.Clear()
        txtPrivilegeType.Text = "" : cboAccessType.SelectedItem = Nothing
    End Sub


    Private Sub txtPrivilegeType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrivilegeType.KeyPress
        If isEnter(e) Then cboAccessType.Focus()
    End Sub


    Private Sub cboAccessType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboAccessType.KeyPress
        If isEnter(e) Then btnAdd.PerformClick()
    End Sub
End Class