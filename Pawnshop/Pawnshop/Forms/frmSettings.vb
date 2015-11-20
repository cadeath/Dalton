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
        UpdateOptions("ORLastNum", txtOR.Text)
        UpdateOptions("BorrowingLastNum", txtBorrow.Text)
        UpdateOptions("InsuranceLastNum", txtInsurance.Text)
    End Sub
End Class