Public Class frmSettings

    Private Sub frmSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearFields()
    End Sub

    Private Sub ClearFields()
        txtCode.Text = GetOption("BranchCode")
        txtName.Text = GetOption("BranchName")
        txtArea.Text = GetOption("BranchArea")
        txtBal.Text = GetOption("MaitainingBalance")
        txtOR.Text = GetOption("ORLastNum")
        txtBorrow.Text = GetOption("BorrowingLastNum")
        txtInsurance.Text = GetOption("InsuranceLastNum")
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        UpdateOptions("BranchCode", txtCode.Text)
        UpdateOptions("BranchName", txtName.Text)
        UpdateOptions("BranchArea", txtArea.Text)
        UpdateOptions("MaintainingBalance", txtBal.Text)
        UpdateOptions("CurrentBalance", txtBal.Text)
        UpdateOptions("ORLastNum", txtOR.Text)
        UpdateOptions("BorrowingLastNum", txtBorrow.Text)
        UpdateOptions("InsuranceLastNum", txtInsurance.Text)

        MsgBox("New Branch has been setup", MsgBoxStyle.Information)
        Me.Close()
    End Sub

    Private Sub txtBal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBal.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub txtOR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOR.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub txtBorrow_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBorrow.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub txtInsurance_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtInsurance.KeyPress
        DigitOnly(e)
    End Sub
End Class