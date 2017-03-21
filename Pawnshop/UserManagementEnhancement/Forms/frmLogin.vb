Public Class frmLogin
    Dim user_Login As Sys_user
    Dim i As Integer = 0
    Dim Failed_attemp As String
    Dim isDisabled As String
    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        If txtUsername.Text = "" Or txtPassword.Text = "" Then Exit Sub
        Failed_attemp = GetOption("FailedAttempNum")

        If Failed_attemp = "" Then Exit Sub

        Dim uName As String = txtUsername.Text
        Dim pName As String = txtPassword.Text

        user_Login = New Sys_user

        If Not user_Login.CheckAccount_Expiration(uName, pName) Then Exit Sub 'Maximum days expiration

        If Not user_Login.EXPIRY_COUNTDOWN(uName, pName) Then Exit Sub 'Minimum days expiration

        If Not user_Login.LogUser(uName, pName) Then
            i += 1
            If i > Failed_attemp Then
                MsgBox("You reached the MAXIMUM attemp this is a recording." & vbCrLf & vbCrLf & "Your account temporarily locked.", MsgBoxStyle.Exclamation, "Locked")
                UpdateOptions("IsFailedAtemp", "Disable")
                Exit Sub
                Me.Close()
            End If
            MsgBox("Invalid username or password!", MsgBoxStyle.Exclamation, "Invalid") : Exit Sub
        End If

        MsgBox("Welcome, " & UppercaseFirstLetter(user_Login.USERNAME) & "", MsgBoxStyle.Information, "Login")
    End Sub


    Private Function ChkIf_reached_MaxAttemp() As Boolean
        isDisabled = GetOption("IsFailedAtemp")

        If isDisabled = "Disable" Then
            Return False
        End If
        Return True
    End Function


    Private Sub UpdateOptions(ByVal STR As String, ByVal val As String)
        Dim mysql As String = String.Format("SELECT * FROM TBLMAINTENANCE WHERE OPT_KEYS='{0}'", STR)
        Dim ds As DataSet = LoadSQL(mysql, "TBLMAINTENANCE")

        With ds.Tables(0).Rows(0)
            .Item("OPT_VALUES") = val
        End With
        database.SaveEntry(ds, False)
    End Sub

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not ChkIf_reached_MaxAttemp() Then MsgBox("You account is temporarily locked," _
            & vbCrLf & "please contact the system administrator for assistance!", MsgBoxStyle.Exclamation, "Locked") : Me.Close()
    End Sub
End Class