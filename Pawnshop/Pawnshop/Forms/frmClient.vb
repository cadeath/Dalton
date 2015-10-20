Imports System.Threading

<<<<<<< HEAD
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub lvClient_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvClient.SelectedIndexChanged

    End Sub
=======
Public Class frmClient

    Private Sub frmClient_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim th As Thread
        th = New Thread(AddressOf LoadClients)
        th.Start()

        ClearField()
        txtSearch.Focus()
    End Sub

    Private Sub ClearField()
        txtSearch.Text = ""
        lvClient.Items.Clear()
    End Sub

    Private Delegate Sub LoadClient_delegate()
    Private Sub LoadClients()
        If lvClient.InvokeRequired Then
            lvClient.Invoke(New LoadClient_delegate(AddressOf LoadClients))
        Else
            lvClient.Enabled = False
            lvClient.BackColor = Color.White

            Dim tbl As String = "TBLCLIENT"
            Dim mySql As String = String.Format("SELECT * FROM {0} ORDER BY LastName ASC, FirstName ASC", tbl)
            Dim ds As DataSet = LoadSQL(mySql, tbl)

            lvClient.Items.Clear()
            For Each pawner As DataRow In ds.Tables(0).Rows
                With pawner
                    Dim lv As ListViewItem = lvClient.Items.Add(.Item("ClientID"))
                    lv.SubItems.Add(String.Format("{0}, {1} {2}", .Item("LastName"), .Item("FirstName"), .Item("MiddleName")))
                    lv.SubItems.Add(String.Format("{0} {1} {2}", .Item("Addr_Street"), .Item("Addr_Brgy"), .Item("Addr_City")))
                    lv.SubItems.Add(.Item("Phone1"))
                    lv.ImageKey = "imgMale"
                    If .Item("Sex") = "F" Then
                        lv.ImageKey = "imgFemale"
                    End If
                End With
            Next

            lvClient.Enabled = True
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub txtSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If isEnter(e) Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged

    End Sub

    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        Dim clientID As Integer
        clientID = lvClient.FocusedItem.Text
        Console.WriteLine("ClientID : " & clientID)

        frmClientInformation.Show()
        frmClientInformation.LoadClient(clientID)
    End Sub

    Private Sub lvClient_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvClient.DoubleClick
        btnView.PerformClick()
    End Sub

    Private Sub lvClient_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvClient.SelectedIndexChanged

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        frmClientInformation.Show()
    End Sub
>>>>>>> refs/remotes/origin/master
End Class