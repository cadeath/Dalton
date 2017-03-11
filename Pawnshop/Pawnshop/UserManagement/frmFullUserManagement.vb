Public Class frmFullUserManagement

    Private Sub frmFullUserManagement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Load_Privileges()
    End Sub

   
   
    Private Sub chkShowPassword_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowPassword.CheckedChanged
        If chkShowPassword.Checked = True Then
            txtPassword.UseSystemPasswordChar = False
            txtPassword1.UseSystemPasswordChar = False
        Else
            txtPassword.UseSystemPasswordChar = True
            txtPassword1.UseSystemPasswordChar = True
        End If
    End Sub


    Private Sub Load_Privileges()
        Dim mysql As String = "SELECT * FROM TBL_USERRULE"
        Dim ds As DataSet = LoadSQL(mysql, "TBL_USERRULE")

        For Each dr As DataRow In ds.Tables(0).Rows
            If dr.Item("ACCESS_LEVEL") = "ENCODER" Then
                dgEncoder.Rows.Add(dr.Item("PRIVILEGE_TYPE"))

            ElseIf dr.Item("ACCESS_LEVEL") = "SUPERVISOR" Then
                dgSupervisor.Rows.Add(dr.Item("PRIVILEGE_TYPE"))

            ElseIf dr.Item("ACCESS_LEVEL") = "MANAGER" Then
                dgManager.Rows.Add(dr.Item("PRIVILEGE_TYPE"))

            Else
                dgSpecial.Rows.Add(dr.Item("PRIVILEGE_TYPE"))
            End If
        Next
    End Sub

  
  
End Class