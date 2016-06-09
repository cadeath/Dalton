Imports System.Data.Odbc
Public Class frmUserManagement

    Private selectedUser As New ComputerUser
    Private moduleName As String = "User Management"
    Private Function PasswordPolicy() As Boolean
        If txtPass1.Text.Length >= 4 And txtPass1.Text.Length <= 8 Then
            Return True
        End If
        MsgBox("Password must be atleast 4 characters but not more than 8 characters", MsgBoxStyle.Critical, moduleName)
        Return False
    End Function

    Private Sub frmUserManagement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tmp As New ComputerUser
        tmp.CreateAdministrator()

        ClearFields()
        LoadActive()
        CheckAuthorization()
        txtUser.Focus()
    End Sub
    Private Sub CheckAuthorization()
        With POSuser
            btnAdd.Enabled = .canUserManage
        End With
    End Sub
    Private Sub LoadUser()
        If lvUsers.SelectedItems.Count = 0 Then Exit Sub

        Dim tmpUser As New ComputerUser

        Dim idx As Integer = lvUsers.FocusedItem.Tag
        With selectedUser
            .LoadUser(idx)
            txtUser.Text = .UserName
            txtFullname.Text = .FullName
        End With

        LoadPrivilege()
    End Sub

    Private Sub LoadActive(Optional ByVal mySql As String = "SELECT * FROM tbl_gamit ORDER BY Username ASC")
        Dim ds As DataSet
        ds = LoadSQL(mySql)

        lvUsers.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim posUser As New ComputerUser
            posUser.LoadUserByRow(dr)
            AddItem(posUser)

        Next
    End Sub

    Private Sub AddItem(ByVal usr As ComputerUser)
        Dim lv As ListViewItem = lvUsers.Items.Add(usr.UserName)
        lv.SubItems.Add(usr.FullName)
        lv.SubItems.Add(usr.Level)
        lv.Tag = usr.UserID
    End Sub

    Private Sub ClearFields()
        txtUser.Text = ""
        txtFullname.Text = ""
        txtPass1.Text = ""
        txtPass2.Text = ""
        chkEnAll.Checked = False
        chkSuAll.Checked = False
        chkMaAll.Checked = False
        chkSpAll.Checked = False
        chkPawn.Checked = False
        chkCM.Checked = False
        chkMT.Checked = False
        chkIns.Checked = False
        chkLay.Checked = False
        chkDB.Checked = False
        chkPOS.Checked = False
        chkCIO.Checked = False
        chkAppraiser.Checked = False
        chkEL.Checked = False
        chkJE.Checked = False
        chkCC.Checked = False
        chkBU.Checked = False
        chkR1.Checked = False
        chkR2.Checked = False
        chkR3.Checked = False
        chkR4.Checked = False
        chkVUM.Checked = False
        chkVR.Checked = False
        chkOS.Checked = False
        chkUM.Checked = False
        chkUR.Checked = False
        chkUS.Checked = False
        chkBorrowings.Checked = False
        chkResetPassword.Checked = False
        chkCashInBank.Checked = False
        chkCashOutBank.Checked = False
        chkVoid.Checked = False
        chkPullOut.Checked = False
        chkMigrate.Checked = False
        chkPrivilege.Checked = False

        btnAdd.Text = "&Add"
    End Sub

    Private Function Privileger() As String
        Dim priv As String = ""
        'Encoder
        priv &= IIf(chkPawn.Checked, 1, 0)
        priv &= IIf(chkCM.Checked, 1, 0)
        priv &= IIf(chkMT.Checked, 1, 0)
        priv &= IIf(chkIns.Checked, 1, 0)
        priv &= IIf(chkLay.Checked, 1, 0)
        priv &= IIf(chkDB.Checked, 1, 0)
        priv &= IIf(chkPOS.Checked, 1, 0)
        priv &= IIf(chkCIO.Checked, 1, 0)
        priv &= IIf(chkAppraiser.Checked, 1, 0)
        priv &= "|"

        'Supervisor
        Dim listChk() As CheckBox = {chkEL, chkJE, chkCC, chkBU, chkR1, chkR2, chkR3, chkR4, chkVUM, chkVR, chkOS}
        For Each e In listChk
            priv &= IIf(e.Checked, 1, 0)

        Next
        priv &= "|"

        'Manager
        listChk = {chkUM, chkUR, chkUS, chkBorrowings, chkResetPassword}
        For Each e In listChk
            priv &= IIf(e.Checked, 1, 0)

        Next
        priv &= "|"

        'Special
        listChk = {chkCashInBank, chkCashOutBank, chkVoid, chkPullOut, chkMigrate, chkPrivilege}
        For Each e In listChk
            priv &= IIf(e.Checked, 1, 0)
        Next

        Return priv

    End Function

    Private Sub LoadPrivilege()
        If selectedUser.Privilege = "PDuNxp8S9q0=" Then
            chkEnAll.Checked = True : chkSuAll.Checked = True
            chkMaAll.Checked = True : chkSpAll.Checked = True

            tbPrivileges.Enabled = False
            Exit Sub
        End If
        tbPrivileges.Enabled = True
        Dim privParts() As String = selectedUser.Privilege.Split("|")

        For y As Integer = 0 To privParts.Count - 1
            For x As Integer = 0 To privParts(y).Length - 1
                Dim chkList() As CheckBox = {}
                Select Case y
                    Case 0 'Encoder
                        chkList = {chkPawn, chkCM, chkMT, chkIns, chkLay, chkDB, chkPOS, chkCIO, chkAppraiser}
                        Console.WriteLine("Encoder Length: " & privParts(y).Length)
                    Case 1 'Supervisor
                        chkList = {chkEL, chkJE, chkCC, chkBU, chkR1, chkR2, chkR3, chkR4, chkVUM, chkVR, chkOS}
                        Console.WriteLine("Supervisor Length: " & privParts(y).Length)
                    Case 2 'Manager
                        chkList = {chkUM, chkUR, chkUS, chkBorrowings, chkResetPassword}
                        Console.WriteLine("Manager Length: " & privParts(y).Length)
                    Case 3 'Special
                        chkList = {chkCashInBank, chkCashOutBank, chkVoid, chkPullOut, chkMigrate, chkPrivilege}
                        Console.WriteLine("Special Length: " & privParts(y).Length)
                End Select

                chkList(x).Checked = IIf(privParts(y).Substring(x, 1) = "1", True, False)
            Next
        Next

    End Sub

#Region "SelectAll"

    Private Sub SelectAll(ByVal tab As TabPage)
        Dim tabStat As Boolean

        Console.WriteLine("Tab Selected: " & tab.Text)
        Select Case tab.Text
            Case "Encoder"
                tabStat = chkEnAll.Checked
                chkPawn.Checked = tabStat
                chkCM.Checked = tabStat
                chkMT.Checked = tabStat
                chkIns.Checked = tabStat
                chkLay.Checked = tabStat
                chkDB.Checked = tabStat
                chkPOS.Checked = tabStat
                chkCIO.Checked = tabStat
                chkAppraiser.Checked = tabStat
            Case "Supervisor"
                tabStat = chkSuAll.Checked
                chkEL.Checked = tabStat
                chkJE.Checked = tabStat
                chkCC.Checked = tabStat
                chkBU.Checked = tabStat
                chkVUM.Checked = tabStat
                chkVR.Checked = tabStat
                chkOS.Checked = tabStat
                chkR1.Checked = tabStat
                chkR2.Checked = tabStat
                chkR3.Checked = tabStat
                chkR4.Checked = tabStat
            Case "Manager"
                tabStat = chkMaAll.Checked
                chkUM.Checked = tabStat
                chkUR.Checked = tabStat
                chkUS.Checked = tabStat
                chkBorrowings.Checked = tabStat
                chkResetPassword.Checked = tabStat
            Case "Special"
                tabStat = chkSpAll.Checked
                chkCashInBank.Checked = tabStat
                chkCashOutBank.Checked = tabStat
                chkVoid.Checked = tabStat
                chkPullOut.Checked = tabStat
                chkMigrate.Checked = tabStat
                chkPrivilege.Checked = tabStat

        End Select
    End Sub

    Private Sub chkEnAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEnAll.CheckedChanged
        SelectAll(tbEncoder)
    End Sub

    Private Sub chkSuAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSuAll.CheckedChanged
        SelectAll(tbSupervisor)
    End Sub

    Private Sub chkMaAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMaAll.CheckedChanged
        SelectAll(tbManager)
    End Sub

    Private Sub chkSpAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSpAll.CheckedChanged
        SelectAll(tbSpecial)
    End Sub
#End Region

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub CheckUsername()
        dbOpen()
        Dim mysql As String = "SELECT * FROM TBL_GAMIT WHERE UPPER(USERNAME) = UPPER('" & txtUser.Text & "')"
        Dim cmd As OdbcCommand = New OdbcCommand(mysql, con)
        Using reader As OdbcDataReader = cmd.ExecuteReader()
            If reader.HasRows Then
                ' User already exists
                Dim result As DialogResult
                result = MessageBox.Show("Username Already Exist!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                If result = DialogResult.OK Then
                    txtUser.Focus()
                End If
                con.Close()
                dbClose()
            End If
        End Using
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If Not PasswordPolicy() Then Exit Sub
        If txtUser.Text = "" And txtFullname.Text = "" Then Exit Sub

        If btnAdd.Text = "&Add" Then
            Console.WriteLine("Priv is " & Privileger())
            Dim tmpUser As New ComputerUser

            tmpUser.UserName = txtUser.Text
            tmpUser.Password = txtPass2.Text
            tmpUser.FullName = txtFullname.Text
            tmpUser.Privilege = Privileger()
            tmpUser.UpdatePrivilege()
            tmpUser.EncoderID = UserID

            tmpUser.SaveUser()
            MsgBox(tmpUser.UserName & " added", MsgBoxStyle.Information, moduleName)
            AddTimelyLogs(moduleName, "New User " & tmpUser.UserName & " Added", , , "By: " & POSuser.UserName)
        Else
            If EncryptString(txtPass1.Text) <> selectedUser.Password And txtPass2.Text = "" Then
                MsgBox("Please input the password before changing", MsgBoxStyle.Critical, moduleName)
                txtPass1.Focus()
                Exit Sub
            End If
            If txtPass1.Text <> txtPass2.Text And Not txtPass2.Text = "" Then
                MsgBox("Password is not MATCHED", MsgBoxStyle.Critical, moduleName)
                Exit Sub
            End If
            With selectedUser
                .FullName = txtFullname.Text
                .Password = txtPass1.Text
                .Privilege = Privileger()
                .UpdatePrivilege()
                .SaveUser(False)
            End With
            MsgBox(selectedUser.UserName & " updated", MsgBoxStyle.Information)
            AddTimelyLogs(moduleName, "User " & selectedUser.UserName & " Updated", , , "By: " & POSuser.UserName)
        End If

        ClearFields()
        LoadActive()
    End Sub

    Private Sub lvUsers_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvUsers.DoubleClick
        LoadUser()
        EditMode()
        ResetPassword()
        UserCanPrivilege()
    End Sub

    Private Sub SaveMode()
        btnAdd.Text = "&Add"
        txtUser.ReadOnly = False
    End Sub

    Private Sub EditMode()
        btnAdd.Text = "&Update"
        txtUser.ReadOnly = True
        txtPass1.Text = ""
        txtPass2.Text = ""
        txtPass1.Focus()
    End Sub
    Private Sub ResetPassword()
        If POSuser.canResetPassword Then
            txtPass1.Enabled = True
            txtPass2.Enabled = True
            txtPass1.Text = ""
            txtPass2.Text = ""
        Else
            txtPass1.Enabled = False
            txtPass2.Enabled = False
        End If
        txtPass1.Focus()
    End Sub
    Private Sub UserCanPrivilege()
        If POSuser.canAddPrivilege Then
            chkPawn.Enabled = True
            chkCM.Enabled = True
            chkMT.Enabled = True
            chkIns.Enabled = True
            chkLay.Enabled = True
            chkDB.Enabled = True
            chkPOS.Enabled = True
            chkCIO.Enabled = True
            chkAppraiser.Enabled = True
            chkEnAll.Enabled = True
            chkEL.Enabled = True
            chkJE.Enabled = True
            chkCC.Enabled = True
            chkBU.Enabled = True
            chkR1.Enabled = True
            chkR2.Enabled = True
            chkR3.Enabled = True
            chkR4.Enabled = True
            chkVUM.Enabled = True
            chkVR.Enabled = True
            chkOS.Enabled = True
            chkSuAll.Enabled = True
            chkUM.Enabled = True
            chkUR.Enabled = True
            chkUS.Enabled = True
            chkBorrowings.Enabled = True
            chkResetPassword.Enabled = True
            chkMaAll.Enabled = True
            chkCashInBank.Enabled = True
            chkCashOutBank.Enabled = True
            chkVoid.Enabled = True
            chkPullOut.Enabled = True
            chkMigrate.Enabled = True
            chkPrivilege.Enabled = True
            chkSuAll.Enabled = True
        Else
            chkPawn.Enabled = False
            chkCM.Enabled = False
            chkMT.Enabled = False
            chkIns.Enabled = False
            chkLay.Enabled = False
            chkDB.Enabled = False
            chkPOS.Enabled = False
            chkCIO.Enabled = False
            chkAppraiser.Enabled = False
            chkEnAll.Enabled = False
            chkEL.Enabled = False
            chkJE.Enabled = False
            chkCC.Enabled = False
            chkBU.Enabled = False
            chkR1.Enabled = False
            chkR2.Enabled = False
            chkR3.Enabled = False
            chkR4.Enabled = False
            chkVUM.Enabled = False
            chkVR.Enabled = False
            chkOS.Enabled = False
            chkSuAll.Enabled = False
            chkUM.Enabled = False
            chkUR.Enabled = False
            chkUS.Enabled = False
            chkBorrowings.Enabled = False
            chkResetPassword.Enabled = False
            chkMaAll.Enabled = False
            chkCashInBank.Enabled = False
            chkCashOutBank.Enabled = False
            chkVoid.Enabled = False
            chkPullOut.Enabled = False
            chkMigrate.Enabled = False
            chkPrivilege.Enabled = False
            chkSuAll.Enabled = False
        End If
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        ClearFields()
    End Sub

    Private Sub txtUser_PreviewKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles txtUser.PreviewKeyDown
        CheckUsername()
    End Sub
End Class