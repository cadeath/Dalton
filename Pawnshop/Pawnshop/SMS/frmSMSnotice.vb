Public Class frmSMSnotice

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

    Private Delegate Sub do_display_callback()
    Private Sub do_display()
        If lvExpiry.InvokeRequired Then
            lvExpiry.Invoke(New do_display_callback(AddressOf do_display))
        Else
            If ExpiryList.Count <= 0 Then Exit Sub

            For Each dr As DataRow In ExpiryCache.Rows
                Dim pawner As New Client
                pawner.LoadClient(dr("CLIENTID"))

                Dim lv As ListViewItem = lvExpiry.Items.Add(dr("PAWNTICKET"))
                lv.SubItems.Add(String.Format("{0} {1}", dr("FIRSTNAME"), dr("LASTNAME")))
                lv.SubItems.Add(cleanup_contact(pawner))
                lv.SubItems.Add(dr("ITEMCLASS"))
                lv.SubItems.Add(dr("PRINCIPAL"))

                Application.DoEvents()
            Next

            'For Each pt As PawnTicket2 In ExpiryList
            '    With pt
            '        Dim lv As ListViewItem = lvExpiry.Items.Add(.PawnTicket)
            '        lv.SubItems.Add(String.Format("{0} {1}", .Pawner.FirstName, .Pawner.LastName))
            '        lv.SubItems.Add(cleanup_contact(pt))
            '        lv.SubItems.Add(.PawnItem.ItemClass.ClassName)
            '        lv.SubItems.Add(.Principal.ToString("#,##0.00"))
            '    End With

            '    Application.DoEvents()
            'Next
        End If
    End Sub
End Class