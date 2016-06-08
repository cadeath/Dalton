Public Class diagMT

    Friend st As Date, en As Date

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Not isValid() Then Exit Sub

        Dim reportType As String = ""
        If rbCebuana.Checked Then reportType = "Cebuana Llhuiller"
        If rbPeraPadala.Checked Then reportType = "Pera Padala"
        If rbWestern.Checked Then reportType = "Western Union"
        If rbGPRS.Checked Then reportType = "GPRS"

        Dim fillData As String, mySql As String
        fillData = "MONEY_TRANSFER"
        mySql = "SELECT * FROM " & fillData
        mySql &= String.Format(" WHERE TRANSDATE BETWEEN '{0}' AND '{1}'", st.ToShortDateString, en.ToShortDateString)

        If Not (rbGPRS.Checked Or rbWestern.Checked) And Not rbALL.Checked Then
            mySql &= String.Format("AND ServiceType = '{0}' ", reportType)
        Else
            mySql &= String.Format("AND ServiceType LIKE '{0}%' ", reportType)
        End If

        mySql &= PaySend_Filter()
        Console.WriteLine(mySql)

        'Parameters
        Dim rptPara As New Dictionary(Of String, String)
        rptPara.Add("txtMonthOf", "FOR THE MONTH OF " & st.ToString("MMMM yyyy"))
        rptPara.Add("branchName", branchName)

        frmReport.ReportInit(mySql, "dsMT", "Reports\rpt_Monthly_MT.rdlc", rptPara)
        frmReport.Show()
    End Sub

    Private Function isValid() As Boolean
        Return True
    End Function

    Private Function PaySend_Filter() As String
        Dim pay As String, send As String, tmp As String
        pay = "PAYOUT" & IIf(chkPay.Checked, " <> 0", " <= 0")
        send = "SENDOUT" & IIf(chkSend.Checked, " <> 0", " <= 0")

        tmp = String.Join(" OR ", pay, send)
        Return String.Format(" AND ({0})", tmp)
    End Function

    Private Sub CheckNoUncheck()
        If chkPay.Checked Then Exit Sub
        If chkSend.Checked Then Exit Sub

        chkPay.Checked = True
    End Sub

    Private Sub chkPay_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPay.CheckedChanged
        CheckNoUncheck()
    End Sub

    Private Sub chkSend_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSend.CheckedChanged
        CheckNoUncheck()
    End Sub

End Class