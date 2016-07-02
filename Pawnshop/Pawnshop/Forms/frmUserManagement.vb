Public Class frmUserManagement

    Private selectedUser As New ComputerUser
    Private moduleName As String = "User Management"
    Private OTPSwitch As Boolean = IIf(GetOption("OTP") = "YES", True, False)

    Private Sub frmUserManagement_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DoubleClick
        ClearFields()
    End Sub

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
    End Sub

    Private Sub CheckAuthorization()
        With POSuser
            btnAdd.Enabled = .canUserManage
        End With
    End Sub

    Private Sub LoadUser()
        If lvUsers.SelectedItems.Count = 0 Then Exit Sub

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

        lvUsers.Items.Clear()

        chkEnAll.Checked = False
        chkSuAll.Checked = False
        chkMaAll.Checked = False
        chkSpAll.Checked = False

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
        priv &= "|"

        'Supervisor
        Dim listChk() As CheckBox = {chkEL, chkJE, chkCC, chkBU, chkR1, chkR2, chkR3, chkR4, chkVUM, chkVR, chkOS}
        For Each e In listChk
            priv &= IIf(e.Checked, 1, 0)
        Next
        priv &= "|"

        'Manager
        listChk = {chkUM, chkUR, chkUS, chkBorrowings}
        For Each e In listChk
            priv &= IIf(e.Checked, 1, 0)
        Next
        priv &= "|"

        'Special
        listChk = {chkCashInBank, chkCashOutBank, chkVoid, chkPullOut, chkMigrate}
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
                        chkList = {chkPawn, chkCM, chkMT, chkIns, chkLay, chkDB, chkPOS, chkCIO}
                        Console.WriteLine("Encoder Length: " & privParts(y).Length)
                    Case 1 'Supervisor
                        chkList = {chkEL, chkJE, chkCC, chkBU, chkR1, chkR2, chkR3, chkR4, chkVUM, chkVR, chkOS}
                        Console.WriteLine("Supervisor Length: " & privParts(y).Length)
                    Case 2 'Manager
                        chkList = {chkUM, chkUR, chkUS, chkBorrowings}
                        Console.WriteLine("Manager Length: " & privParts(y).Length)
                    Case 3 'Special
                        chkList = {chkCashInBank, chkCashOutBank, chkVoid, chkPullOut, chkMigrate}
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
            Case "Special"
                tabStat = chkSpAll.Checked
                chkCashInBank.Checked = tabStat
                chkCashOutBank.Checked = tabStat
                chkVoid.Checked = tabStat
                chkPullOut.Checked = tabStat
                chkMigrate.Checked = tabStat
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
    Private Function CheckOTP() As Boolean
        diagOTP.Show()
        diagOTP.TopMost = True
        Return False
        Return True
    End Function
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If Not OTPSwitch Then
            diagOTP.FormType = diagOTP.OTPType.UserManagement
            If Not CheckOTP() Then Exit Sub
        Else
            AddUserManagement()
        End If
    End Sub
    Friend Sub AddUserManagement()
        If Not PasswordPolicy() Then Exit Sub
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
        End If

        ClearFields()
        LoadActive()
    End Sub
    Private Sub lvUsers_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvUsers.DoubleClick
        LoadUser()
        EditMode()
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

End Class