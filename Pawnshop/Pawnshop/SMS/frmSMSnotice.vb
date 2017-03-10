Public Class frmSMSnotice

    Private Sub frmSMSnotice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub displayToListView(ByVal pt As Integer, ByVal name As String, ByVal num As String, ByVal itmclass As String, ByVal principal As Double)
        Dim lv As ListViewItem = lvExpiry.Items.Add(pt.ToString("0000000"))
        lv.SubItems.Add(name)
        lv.SubItems.Add(num)
        lv.SubItems.Add(itmclass)
        lv.SubItems.Add(principal.ToString("#,##0.00"))
    End Sub
End Class