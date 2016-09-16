Public Class frm_PanelYesNo

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim tmpResult As String = ""
        If rbYes.Checked Then
            tmpResult = "Yes"
        ElseIf rbNo.Checked Then
            tmpResult = "No"
        End If

        With dev_NewPawning.lvItem
            .SelectedItems(0).SubItems(3).Text = tmpResult
        End With
        
    End Sub

End Class