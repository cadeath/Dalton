Public Class frmClient

    Private Sub frmClient_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub LoadClients()
        Dim tbl As String = "TBLCLIENT"
        Dim mySql As String = String.Format("SELECT * FROM {0} ORDER BY LastName ASC, FirstName ASC", tbl)
        Dim ds As DataSet = LoadSQL(mySql, tbl)

        lvClient.Clear()
        For Each pawner As DataRow In ds.Tables(0).Rows
            With pawner
                lvClient.Items.Add(.Item("ClientID"))
                lvClient.Items.Add(.Item("ClientID"))
            End With
        Next
    End Sub
End Class