Public Class dev_Menu_SalesInventory

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmInventory.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        frmImport_IMD.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        frmExtractor.FormType = frmExtractor.ExtractType.JournalEntry
        frmExtractor.Show()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        frmExtractor.FormType = frmExtractor.ExtractType.PTUFile
        frmExtractor.Show()
    End Sub
End Class