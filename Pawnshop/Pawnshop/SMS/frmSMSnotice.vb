Public Class frmSMSnotice
    Dim checkSwitch As Boolean = True
    Friend autoStart As Boolean = False

    Private Sub frmSMSnotice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Load_Expiry()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub Load_Expiry()
        lvExpiry.Items.Clear()

        Dim th As New Threading.Thread(AddressOf do_display)
        th.Start()
    End Sub

    Private Sub FormState(ByVal st As Boolean)
        lvExpiry.Enabled = st
        btnCancel.Enabled = st
        btnSend.Enabled = st
        btnChange.Enabled = st
    End Sub

    Private Delegate Sub do_display_callback()
    Private Sub do_display()
        If lvExpiry.InvokeRequired Then
            lvExpiry.Invoke(New do_display_callback(AddressOf do_display))
        Else
            If ExpiryCache.Rows.Count <= 0 Then Exit Sub

            If autoStart Then Me.Hide()
            FormState(False)
            For Each dr As DataRow In ExpiryCache.Rows
                Dim pawner As New Customer
                pawner.Load_CustomerByID(dr("ID"))
                Dim principal As Double = dr("PRINCIPAL")

                Dim lv As ListViewItem = lvExpiry.Items.Add(dr("PAWNTICKET"))
                lv.SubItems.Add(dr("CLIENT"))
                lv.SubItems.Add(cleanup_contact(pawner))
                lv.SubItems.Add(dr("ITEMCLASS"))
                lv.SubItems.Add(principal.ToString("#,##0.00"))
                lv.SubItems.Add(dr("EXPIRYDATE"))
                lv.SubItems.Add(dr("AUCTIONDATE"))

                Application.DoEvents()
            Next
            FormState(True)
            If autoStart Then Me.Show()
        End If
    End Sub

    Private Sub btnChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChange.Click
        If lvExpiry.SelectedItems.Count = 0 Then Exit Sub
        Dim idx As Integer = lvExpiry.FocusedItem.Index

        Dim updatedNumber(0) As String
        Dim passValue(1) As String
        passValue(0) = lvExpiry.Items(idx).SubItems(2).Text
        passValue(1) = lvExpiry.Items(idx).SubItems(1).Text
        If diagChangeNum.ShowDialog(updatedNumber, passValue) <> Windows.Forms.DialogResult.OK Then
            Exit Sub
        End If

        Dim id As Integer = ExpiryCache.Rows(idx).Item("ID")
        Dim cl As New Customer
        cl.Load_CustomerByID(id)

        cl.UpdatePhone(updatedNumber(0))
        'cl.Cellphone1 = updatedNumber(0)
        'cl.ModifyClient()
        lvExpiry.Items(idx).SubItems(2).Text = Indcleanup_contact(updatedNumber(0))

        MsgBox("Number Updated", MsgBoxStyle.Information)
    End Sub

    Private Sub lvExpiry_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvExpiry.DoubleClick
        btnView.PerformClick()
    End Sub

    Private Sub chkAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAll.CheckedChanged
        For Each lv As ListViewItem In lvExpiry.Items
            lv.Checked = chkAll.Checked
        Next
    End Sub

    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        If lvExpiry.CheckedItems.Count <= 0 Then Exit Sub

        For Each chk As ListViewItem In lvExpiry.CheckedItems
            If chk.SubItems(2).Text.Contains("INV") Then
                chk.Checked = False
                chk.BackColor = Color.MistyRose
            End If
        Next

        Dim msgCnt As Integer = lvExpiry.CheckedItems.Count
        Dim msg As String = String.Format("We will be sending {0} client{1}", msgCnt, IIf(msgCnt > 1, "s", "")) + vbCrLf + "Please confirm"
        If MsgBox(msg, MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Confirmation") = MsgBoxResult.No Then Exit Sub
        If msgCnt < 1 Then Exit Sub

        frmMain.displayStatus(String.Format("Sending Messages to {0} client{1}", msgCnt, IIf(msgCnt > 1, "s", "")))
        'Dim th As New Threading.Thread(AddressOf do_MassTexting)
        Dim th = New Threading.Thread(AddressOf do_MassTexting)
        th.SetApartmentState(Threading.ApartmentState.STA)
        th.Start()
        FormState(False)
    End Sub

    Private Delegate Sub doMassTexting_callback()
    Private Sub do_MassTexting()
        If lvExpiry.InvokeRequired Then
            lvExpiry.Invoke(New doMassTexting_callback(AddressOf do_MassTexting))
        Else
            Dim TextMessage As String = GetOption("SMS_MSG")
            Dim finalCnt As Integer = lvExpiry.CheckedItems.Count

            Me.Hide()
            For Each pawner As ListViewItem In lvExpiry.CheckedItems
                If pawner.SubItems(2).Text.Contains("INV") Then Continue For

                Dim dr As DataRow = ExpiryCache.Select("PAWNTICKET = " & pawner.Text)(0)
                Dim text_msg As String = MessageBuilder(TextMessage, dr)
                Dim remarks As String = "TESTING REMARKS"

                Console.WriteLine(pawner.SubItems(1).Text & ">" & pawner.SubItems(2).Text)
                Console.WriteLine("MSG: " & text_msg)

                remarks = smsUtil.SendSMS(pawner.SubItems(2).Text, MessageBuilder(TextMessage, dr))
                remarks = IIf(remarks.Contains("status=DeliveredToTerminal,"), "SENT", remarks)
                remarks = IIf(remarks.Contains("{deliveryReports=}"), "SENT", remarks)

                If remarks = "SENT" Then
                    Dim notified As New PawnTicket2
                    notified.Load_PawnTicket(pawner.Text)
                    notified.ConfirmNotification(text_msg, remarks)
                Else
                    If remarks.Contains("status=DeliveryImpossible,") Then
                        Log_Report(String.Format("FAILED TO SEND: PT#{0}", pawner.Text))
                    Else
                        Log_Report(String.Format("FAILED TO SEND: PT#{0} - {1}", pawner.Text, remarks))
                    End If

                End If

                finalCnt -= 1
                frmMain.displayStatus(String.Format("{2}... {0} recipient{1} remaining", finalCnt, IIf(finalCnt > 1, "s", ""), IIf(remarks = "SENT", "Sending", "Failed")))
                Application.DoEvents()
            Next

            frmMain.displayStatus("Sending Expiry List Completed")
            smsUtil.Load_Expiry()
            Me.Close()
        End If
    End Sub

    Private Sub btnView_Click(sender As System.Object, e As System.EventArgs) Handles btnView.Click
        If lvExpiry.SelectedItems.Count <> 1 Then Exit Sub

        diagQuickView_PT.Load_Pawnticket(lvExpiry.FocusedItem.Text)
        diagQuickView_PT.ShowDialog()
    End Sub

    Private Sub lvExpiry_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvExpiry.SelectedIndexChanged

    End Sub
End Class