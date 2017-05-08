Public Class frmCashCount

    Dim fillData As String = "tblCashCount"
    Friend isClosing As Boolean = False
    Friend AccessType As String = ""

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmCashCount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtCurDate.Text = CurrentDate.ToLongDateString
        ClearFields()
        verification()
    End Sub

    Private Sub ComputeTotal()
        Dim tot As Double = 0
        tot += CDbl(lbl1c.Text.Substring(1))
        tot += CDbl(lbl5c.Text.Substring(1))
        tot += CDbl(lbl10c.Text.Substring(1))
        tot += CDbl(lbl25c.Text.Substring(1))
        tot += CDbl(lbl1.Text.Substring(1))
        tot += CDbl(lbl5.Text.Substring(1))
        tot += CDbl(lbl10.Text.Substring(1))
        tot += CDbl(lbl20.Text.Substring(1))
        tot += CDbl(lbl50.Text.Substring(1))
        tot += CDbl(lbl100.Text.Substring(1))
        tot += CDbl(lbl200.Text.Substring(1))
        tot += CDbl(lbl500.Text.Substring(1))
        tot += CDbl(lbl1000.Text.Substring(1))

        txtTotal.Text = String.Format("Php {0:#,###.00}", tot)
    End Sub

    Private Sub ClearFields()
        txt1c.Text = "" : lbl1c.Text = "P 0.00"
        txt5c.Text = "" : lbl5c.Text = "P 0.00"
        txt10c.Text = "" : lbl10c.Text = "P 0.00"
        txt25c.Text = "" : lbl25c.Text = "P 0.00"
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
        If txt.Text = "" Then txt.Text = ""

        Dim tmp As Double = 0
        If IsNumeric(txt.Text) Then
            tmp = CDbl(txt.Text)
        Else
            Exit Sub
        End If

        Dim lbl As Label
        Select Case amt
            Case 0.01 : lbl = lbl1c
            Case 0.25 : lbl = lbl25c
            Case 0.05 : lbl = lbl5c
            Case 0.1 : lbl = lbl10c
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

        lbl.Text = "P " & tmp * amt

        ComputeTotal()
    End Sub

#Region "KeyPress"

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

    Private Sub txt5c_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt5c.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub txt5c_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt5c.KeyUp
        ComputeMe(txt5c, 0.05)
    End Sub

    Private Sub txt1c_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt1c.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub txt1c_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt1c.KeyUp
        ComputeMe(txt1c, 0.01)
    End Sub

    Private Sub txt10c_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt10c.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub txt10c_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt10c.KeyUp
        ComputeMe(txt10c, 0.1)
    End Sub

    Private Sub txt25c_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt25c.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub txt25c_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt25c.KeyUp
        ComputeMe(txt25c, 0.25)
    End Sub
#End Region

    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPost.Click
        Dim ans As DialogResult = MsgBox("Do you want to POST this cash count?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)

        If ans = Windows.Forms.DialogResult.No Then Exit Sub
        Dim total As Double
        'Console.WriteLine(">>" & CDbl(lbl25c.Text.Substring(2)))
        total = CDbl(lbl1c.Text.Substring(2)) + CDbl(lbl5c.Text.Substring(2)) + CDbl(lbl10c.Text.Substring(2)) + CDbl(lbl25c.Text.Substring(2)) + CDbl(lbl1.Text.Substring(2)) + CDbl(lbl5.Text.Substring(2)) + CDbl(lbl10.Text.Substring(2))
        total += CDbl(lbl20.Text.Substring(2)) + CDbl(lbl50.Text.Substring(2)) + CDbl(lbl100.Text.Substring(2)) + CDbl(lbl200.Text.Substring(2)) + CDbl(lbl500.Text.Substring(2)) + CDbl(lbl1000.Text.Substring(2))

        SaveCashCount()
        UpdateCashCount(total)
        MsgBox("Transaction Posted", MsgBoxStyle.Information)
        Console.WriteLine("CashCount >> Php " & total)
        If isClosing Then
            mod_system.CloseStore(total)
            frmMain.dateSet = False
            frmMain.doSegregate = False
        End If
        Me.Close()
    End Sub

    Private Sub UpdateCashCount(ByVal total As Double)
        Dim mySql As String = "SELECT * FROM tblDaily "
        mySql &= String.Format("WHERE ID = {0} ", dailyID)
        Dim ds As DataSet = LoadSQL(mySql, "tblDaily")

        ds.Tables("tblDaily").Rows(0).Item("CashCount") = total
        database.SaveEntry(ds, False)
        Console.WriteLine("CashCount data updated")
    End Sub

    Private Sub SaveCashCount()
        On Error Resume Next

        Dim mySql As String = "SELECT * FROM " & fillData
        mySql &= String.Format(" WHERE DailyID = {0} AND Status = 1", dailyID)
        Dim ds As DataSet = LoadSQL(mySql, fillData)
        Dim denoCnt As Integer = 0, denoValue As Double = 0, deno As String = ""
        Dim denoType As String = ""

        For Each dr As DataRow In ds.Tables(fillData).Rows
            dr.Item("Status") = 0
        Next
        If ds.Tables(fillData).Rows.Count > 0 Then database.SaveEntry(ds, False)

        For cnt As Integer = 0 To 12 '13 Denominations
            denoCnt = 0 : denoValue = 0
            Select Case cnt
                Case 0 : deno = "1c" : denoCnt = CInt(txt1c.Text) : denoValue = CDbl(lbl1c.Text.Substring(2)) : denoType = "COIN"
                Case 1 : deno = "5c" : denoCnt = CInt(txt5c.Text) : denoValue = CDbl(lbl5c.Text.Substring(2)) : denoType = "COIN"
                Case 2 : deno = "10c" : denoCnt = CInt(txt10c.Text) : denoValue = CDbl(lbl10c.Text.Substring(2)) : denoType = "COIN"
                Case 3 : deno = "25c" : denoCnt = CInt(txt25c.Text) : denoValue = CDbl(lbl25c.Text.Substring(2)) : denoType = "COIN"
                Case 4 : deno = "P1" : denoCnt = CInt(txt1.Text) : denoValue = CDbl(lbl1.Text.Substring(2)) : denoType = "COIN"
                Case 5 : deno = "P5" : denoCnt = CInt(txt5.Text) : denoValue = CDbl(lbl5.Text.Substring(2)) : denoType = "COIN"
                Case 6 : deno = "P10" : denoCnt = CInt(txt10.Text) : denoValue = CDbl(lbl10.Text.Substring(2)) : denoType = "COIN"
                Case 7 : deno = "P20" : denoCnt = CInt(txt20.Text) : denoValue = CDbl(lbl20.Text.Substring(2)) : denoType = "BILL"
                Case 8 : deno = "P50" : denoCnt = CInt(txt50.Text) : denoValue = CDbl(lbl50.Text.Substring(2)) : denoType = "BILL"
                Case 9 : deno = "P100" : denoCnt = CInt(txt100.Text) : denoValue = CDbl(lbl100.Text.Substring(2)) : denoType = "BILL"
                Case 10 : deno = "P200" : denoCnt = CInt(txt200.Text) : denoValue = CDbl(lbl200.Text.Substring(2)) : denoType = "BILL"
                Case 11 : deno = "P500" : denoCnt = CInt(txt500.Text) : denoValue = CDbl(lbl500.Text.Substring(2)) : denoType = "BILL"
                Case 12 : deno = "P1000" : denoCnt = CInt(txt1000.Text) : denoValue = CDbl(lbl1000.Text.Substring(2)) : denoType = "BILL"
            End Select

            If Not denoCnt = 0 Then
                Dim dsNewRow As DataRow
                dsNewRow = ds.Tables(fillData).NewRow
                With dsNewRow
                    .Item("DailyID") = dailyID
                    .Item("Denomination") = deno
                    .Item("Cnt") = denoCnt
                    .Item("Total") = denoValue
                    .Item("EncoderID") = UserID
                    .Item("SystemTime") = Now
                    .Item("Status") = 1
                    .Item("MoneyType") = denoType
                End With
                ds.Tables(fillData).Rows.Add(dsNewRow)
                database.SaveEntry(ds)
            End If
        Next

    End Sub

    Private Sub verification()
        If AccessType = "Read Only" Then
            btnPost.Enabled = False
        End If
    End Sub
End Class