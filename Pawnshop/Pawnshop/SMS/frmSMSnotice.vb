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

        Dim id As Integer = ExpiryCache.Rows(idx).Item("clientID")
        Dim cl As New Client
        cl.LoadClient(id)
        cl.Cellphone1 = updatedNumber(0)
        cl.ModifyClient()
        lvExpiry.Items(idx).SubItems(2).Text = cleanup_contact(cl)

        MsgBox("Number Updated", MsgBoxStyle.Information)
    End Sub

    Private Sub lvExpiry_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvExpiry.DoubleClick
        btnChange.PerformClick()
    End Sub

    Private Sub chkAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAll.CheckedChanged
        For Each lv As ListViewItem In lvExpiry.Items
            lv.Checked = chkAll.Checked
        Next
    End Sub

    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        displayStatus(String.Format("Sending Messages to {0} client{1}", lvExpiry.CheckedItems.Count, IIf(lvExpiry.CheckedItems.Count > 1, "s", "")))
    End Sub

    Private Sub displayStatus(ByVal str As String)
        frmMain.statusStrip.Items("tssOthers").Text = str
    End Sub

    Private Sub do_MassTexting()

    End Sub
End Class