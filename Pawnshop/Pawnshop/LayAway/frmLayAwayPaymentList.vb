Public Class frmLayAwayPaymentList

    Friend Sub LoadListPayment(ByVal Item As String)
        Dim mysql As String = "Select LY.LAYID, C.CLIENTID, C.FIRSTNAME || ' ' || C.LASTNAME || ' ' || C.SUFFIX AS FULLNAME, "
        mysql &= "LY.ITEMCODE , ITM.DESCRIPTION, LY.PRICE, LY.STATUS, LYL.PAYMENTDATE, LYL.AMOUNT, "
        mysql &= "LY.BALANCE, LYL.STATUS AS LINESTATUS, LYL.PENALTY, LYL.CONTROLNUM, LYL.LINESID "
        mysql &= "From TBLLAYAWAY LY "
        mysql &= "INNER JOIN TBLCLIENT C ON C.CLIENTID = LY.CUSTOMERID "
        mysql &= "INNER JOIN TBLLAYLINES LYL ON LYL.LAYID = LY.LAYID "
        mysql &= "INNER JOIN ITEMMASTER ITM ON ITM.ITEMCODE = LY.ITEMCODE "
        mysql &= "WHERE LYL.STATUS <> 0 AND UPPER(LY.ITEMCODE) = UPPER('" & Item & "')"
        Dim ds As DataSet = LoadSQL(mysql)
        For Each dr In ds.Tables(0).Rows
            AddList(dr)
        Next
        If ds.Tables(0).Rows.Count <> 0 Then lblDesc.Text = ds.Tables(0).Rows(0).Item("Description")
    End Sub

    Private Sub AddList(ByVal dr As DataRow)
        With dr
            Dim lv As ListViewItem = lvPayment.Items.Add(.Item("CONTROLNUM"))

            lv.SubItems.Add(.Item("PAYMENTDATE"))
            lv.SubItems.Add(.Item("FULLNAME"))
            lv.SubItems.Add(.Item("AMOUNT"))
            lv.SubItems.Add(.Item("PENALTY"))
            lv.Tag = .Item("LINESID")
        End With
    End Sub

    Private Sub frmLayAwayPaymentList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lvPayment.Items.Clear()
    End Sub

    Private Sub btnVoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoid.Click
        If lvPayment.SelectedItems.Count = 0 Then Exit Sub
        If Not OTPDisable Then
            diagOTP.FormType = diagOTP.OTPType.VoidLayPayment
            If Not CheckOTP() Then Exit Sub
        Else
            VoidLayPayments()
        End If

    End Sub

    Friend Sub VoidLayPayments()
        If POSuser.canVoid Then

        End If
        Dim idx As Integer = lvPayment.FocusedItem.Tag
        Dim ans As DialogResult = MsgBox("Do You Want To Void This Transaction?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

        Dim laylines As New LayAwayLines
        laylines.LoadByID(idx)

        If laylines.PaymentDate <> CurrentDate.ToShortDateString Then
            MsgBox("You Cannot Void Transaction in a Different Date", MsgBoxStyle.Critical)
            Exit Sub
        End If

        laylines.VoidLayPayment()
        MsgBox("Transaction Voided", MsgBoxStyle.Information)
        Me.Close()
    End Sub
End Class