Public Class frmMain

    Private Sub UserManagementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserManagementToolStripMenuItem.Click
        'If Users_Access.Verify_Access("Usermanagment") = "No Access" Then
        '    MsgBoxAuthoriation("You don't have access to User Management")
        '    Exit Sub
        'End If

        frmUserManagement.Show()
    End Sub

    Private Sub LoginToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoginToolStripMenuItem.Click
        frmLogin.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub MsgBoxAuthoriation(ByVal msg As String)
        MsgBox(msg, MsgBoxStyle.Critical, "Authorization Invalid")
    End Sub


    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

End Class