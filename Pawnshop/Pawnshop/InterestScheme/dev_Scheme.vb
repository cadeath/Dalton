Public Class dev_Scheme

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Load_Scheme_Data()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim mySql As String = "SELECT * FROM TBLINTSCHEMES"
        Dim ds As DataSet = LoadSQL(mySql)

        For Each dr As DataRow In ds.Tables(0).Rows



        Next
    End Sub
End Class