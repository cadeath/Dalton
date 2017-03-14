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

    Private Sub FormState(ByVal st As Boolean)
        lvExpiry.Enabled = st
        btnAll.Enabled = st
        btnCancel.Enabled = st
        btnSend.Enabled = st
    End Sub

    Private Delegate Sub do_display_callback()
    Private Sub do_display()
        If lvExpiry.InvokeRequired Then
            lvExpiry.Invoke(New do_display_callback(AddressOf do_display))
        Else
            If ExpiryCache.Rows.Count <= 0 Then Exit Sub

            Me.Hide()
            FormState(False)
            For Each dr As DataRow In ExpiryCache.Rows
                Dim pawner As New Client
                pawner.LoadClient(dr("CLIENTID"))
                Dim principal As Double = dr("PRINCIPAL")

                Dim lv As ListViewItem = lvExpiry.Items.Add(dr("PAWNTICKET"))
                lv.SubItems.Add(dr("CLIENT"))
                lv.SubItems.Add(cleanup_contact(pawner))
                lv.SubItems.Add(dr("ITEMCLASS"))
                lv.SubItems.Add(principal.ToString("#,##0.00"))

                Application.DoEvents()
            Next
            FormState(True)
            Me.Show()
        End If
    End Sub

    Private Sub lvExpiry_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvExpiry.DoubleClick
        Dim idx As Integer = lvExpiry.FocusedItem.Index

    End Sub
End Class