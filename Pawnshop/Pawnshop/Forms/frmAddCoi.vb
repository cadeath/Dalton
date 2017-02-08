Public Class frmAddCoi

    Private Sub frmAddCoi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Friend Sub LoadCoi(ByVal Coi As Insurance)
        For Each lv As ListViewItem In lvCoi.Items
            If lv.SubItems.text.Contains(Coi.COInumber) Then

            End If
        Next
        With Coi

            Dim lv As ListViewItem = lvCoi.Items.Add(.COInumber)
            lv.SubItems.Add(.ClientName)
            lv.Tag = .COInumber
        End With
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim secured_str As String = txtSearch.Text
        secured_str = DreadKnight(secured_str)
        frmInsuranceList.SearchSelect(secured_str, FormName.Coi)
        frmInsuranceList.Show()
    End Sub
End Class