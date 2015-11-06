Public Class frmInsuranceList

    Private Sub frmInsuranceList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Private Delegate Sub LoadClient_delegate()
    Friend Sub LoadClients()
        If lvClient.InvokeRequired Then
            lvClient.Invoke(New LoadClient_delegate(AddressOf LoadClients))
        Else
            lvClient.Enabled = False
            lvClient.BackColor = Color.White

            Dim tbl As String = "TBLINSURANCE"
            Dim tbl2 As String = "TBLCLIENT"
            Dim mySql As String = String.Format("SELECT * FROM {0} ORDER BY LastName ASC, FirstName ASC", tbl)
            Dim ds As DataSet = LoadSQL(mySql, tbl)

            lvClient.Items.Clear()
            For Each pawner As DataRow In ds.Tables(0).Rows
                Dim tmpClient As New Client
                tmpClient.LoadClient(pawner.Item("ClientID"))
                'AddItem(tmpClient)
            Next

            lvClient.Enabled = True
        End If
    End Sub
End Class