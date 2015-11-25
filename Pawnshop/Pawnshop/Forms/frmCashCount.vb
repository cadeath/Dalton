Public Class frmCashCount

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmCashCount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtCurDate.Text = CurrentDate.ToLongDateString
        ClearFields()
    End Sub

    Private Sub ClearFields()
        txt25c.Text = "" : lbl25c.Text = "P 0.00"
        txt50c.Text = "" : lbl50c.Text = "P 0.00"
        txt1.Text = "" : lbl1.Text = "P 0.00"
        txt5.Text = "" : lbl5.Text = "P 0.00"
        txt10.Text = "" : lbl10.Text = "P 0.00"
        txt20.Text = "" : lbl20.Text = "P 0.00"
        txt50.Text = "" : lbl50.Text = "P 0.00"
        txt100.Text = "" : lbl100.Text = "P 0.00"
        txt200.Text = "" : lbl200.Text = "P 0.00"
        txt500.Text = "" : lbl500.Text = "P 0.00"
        txt1000.Text = "" : lbl1000.Text = "P 0.00"
    End Sub

    ''' <summary>
    ''' Insert this to the KeyUp event
    ''' </summary>
    ''' <param name="txt"></param>
    ''' <param name="amt"></param>
    ''' <remarks></remarks>
    Private Sub ComputeMe(ByVal txt As TextBox, ByVal amt As Double)
        If txt.Text = "" Then Exit Sub
        Dim lbl As Label
        Select Case amt
            Case 0.25 : lbl = lbl25c
            Case 0.5 : lbl = lbl50c
            Case 1 : lbl = lbl1
            Case 5 : lbl = lbl5
            Case 10 : lbl = lbl10
            Case 20 : lbl = lbl20
            Case 50 : lbl = lbl50
            Case 100 : lbl = lbl100
            Case 200 : lbl = lbl200
            Case 500 : lbl = lbl500
            Case 1000 : lbl = lbl1000
            Case Else : lbl = Nothing
        End Select

        lbl.Text = "P " & CDbl(txt.Text) * amt
    End Sub

#Region "KeyPress"
    Private Sub txt25c_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt25c.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub txt25c_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt25c.KeyUp
        ComputeMe(txt25c, 0.25)
    End Sub

    Private Sub txt50c_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt50c.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub txt50c_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt50c.KeyUp
        ComputeMe(txt50c, 0.5)
    End Sub

    Private Sub txt1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt1.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub txt1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt1.KeyUp
        ComputeMe(txt1, 1)
    End Sub

    Private Sub txt5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt5.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub txt5_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt5.KeyUp
        ComputeMe(txt5, 5)
    End Sub

    Private Sub txt10_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt10.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub txt10_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt10.KeyUp
        ComputeMe(txt10, 10)
    End Sub

    Private Sub txt20_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt20.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub txt20_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt20.KeyUp
        ComputeMe(txt20, 20)
    End Sub

    Private Sub txt50_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt50.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub txt50_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt50.KeyUp
        ComputeMe(txt50, 50)
    End Sub

    Private Sub txt100_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt100.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub txt100_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt100.KeyUp
        ComputeMe(txt100, 100)
    End Sub

    Private Sub txt200_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt200.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub txt200_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt200.KeyUp
        ComputeMe(txt200, 200)
    End Sub

    Private Sub txt500_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt500.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub txt500_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt500.KeyUp
        ComputeMe(txt500, 500)
    End Sub

    Private Sub txt1000_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt1000.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub txt1000_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt1000.KeyUp
        ComputeMe(txt1000, 1000)
    End Sub
#End Region

    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPost.Click
        Dim ans As DialogResult = MsgBox("Do you want to POST this cash count?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)

        If ans = Windows.Forms.DialogResult.No Then Exit Sub
        Dim total As Double
        'Console.WriteLine(">>" & CDbl(lbl25c.Text.Substring(2)))
        total = CDbl(lbl25c.Text.Substring(2)) + CDbl(lbl50c.Text.Substring(2)) + CDbl(lbl1.Text.Substring(2)) + CDbl(lbl5.Text.Substring(2)) + CDbl(lbl10.Text.Substring(2)) + CDbl(lbl20.Text.Substring(2)) + CDbl(lbl50.Text.Substring(2))
        total += CDbl(lbl100.Text.Substring(2)) + CDbl(lbl200.Text.Substring(2)) + CDbl(lbl500.Text.Substring(2)) + CDbl(lbl1000.Text.Substring(2))

        Console.WriteLine("CashCount >>" & total)
        mod_system.CloseStore(total)
        frmMain.dateSet = False
        Me.Close()
    End Sub
End Class