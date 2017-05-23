Public Class frmDiscount
    Private DiscountItm As cItemData

    Friend Sub LoadItem(ByVal itm As cItemData)
        With itm
            txtSalePrice.Text = .SalePrice
            txtItemCode.Text = .ItemCode
            txtDescription.Text = .Description
        End With
        DiscountItm = itm

    End Sub

    Private Sub frmDiscount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtDiscount.Clear()
        txtTotal.Clear()
    End Sub

    Private Sub txtDiscount_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDiscount.KeyUp
        ComputeDiscount()
    End Sub

    Private Sub ComputeDiscount()
        Dim i As Double, subTotal As Double
        If txtDiscount.Text = "" Then Exit Sub
        i = (Val(txtDiscount.Text) / 100)
        subTotal = Val(txtSalePrice.Text) * i
        txtTotal.Text = Val(txtSalePrice.Text) - subTotal
    End Sub

    Private Sub txtDiscount_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiscount.KeyPress
        DigitOnly(e)
        If isEnter(e) Then
            btnDiscount.PerformClick()
        End If
    End Sub

    Private Sub btnDiscount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDiscount.Click

        Dim NewOtp As New ClassOtp("Discount", diagGeneralOTP.txtPIN.Text, DiscountItm.ItemCode)
        TransactionVoidSave("Discount", POSuser.UserID, POSuser.UserID, DiscountItm.ItemCode)

        With DiscountItm
            .Discount = txtDiscount.Text
            .SalePrice = txtTotal.Text
        End With

        frmSales.AddItem(DiscountItm)
        frmSales.ClearSearch()
        Me.Close()
    End Sub
End Class