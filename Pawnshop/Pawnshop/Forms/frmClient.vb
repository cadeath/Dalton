Imports System.Threading

' Developer note
' to Use this form as auto search form
' use the Variable SearchStr to hold
' your search variable and use .show
' to display the form with result.
' eg:
'  frmClient.SearchStr = "Eskie"
'  frmClient.Show()
' Version
' 1.1
' - Auto Search Form

Public Class frmClient

    Friend SearchStr As String = ""

    Private Sub frmClient_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If SearchStr = "" Then
            Dim th As Thread
            th = New Thread(AddressOf LoadClients)
            th.Start()
        End If

        ClearField()
        txtSearch.Focus()
        txtSearch.Text = IIf(SearchStr <> "", SearchStr, "")
        If txtSearch.Text <> "" Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub AddItem(ByVal cl As Client)
        Dim lv As ListViewItem = lvClient.Items.Add(cl.ID)
        lv.SubItems.Add(String.Format("{0}, {1} {2}", cl.LastName, cl.FirstName, cl.MiddleName))
        lv.SubItems.Add(String.Format("{0} {1} {2}", cl.AddressSt, cl.AddressBrgy, cl.AddressCity))
        lv.SubItems.Add(cl.Cellphone1)
        lv.ImageKey = "imgMale"
        If cl.Sex = 0 Then
            lv.ImageKey = "imgFemale"
        End If
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
                Dim tmpClient As New Client
                tmpClient.LoadClient(pawner.Item("ClientID"))
                AddItem(tmpClient)
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

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If txtSearch.Text = "" Then Exit Sub

        txtSearch.SelectAll()

        Dim src As String = txtSearch.Text
        Dim mySql As String = "SELECT * FROM tblClient " & vbCrLf
        mySql &= " WHERE "
        mySql &= String.Format("UPPER(FirstName) LIKE UPPER('%{0}%') OR " & vbCrLf, src)
        mySql &= String.Format("UPPER(MiddleName) LIKE UPPER('%{0}%') OR " & vbCrLf, src)
        mySql &= String.Format("UPPER(LastName) LIKE UPPER('%{0}%') OR " & vbCrLf, src)
        mySql &= String.Format("UPPER(Addr_Brgy) LIKE UPPER('%{0}%') OR " & vbCrLf, src)
        mySql &= String.Format("UPPER(Addr_City) LIKE UPPER('%{0}%') OR " & vbCrLf, src)
        mySql &= String.Format("UPPER(Phone1) LIKE UPPER('%{0}%') OR " & vbCrLf, src)
        mySql &= String.Format("UPPER(Phone2) LIKE UPPER('%{0}%') OR " & vbCrLf, src)
        mySql &= String.Format("UPPER(Phone_Others) LIKE UPPER('%{0}%') " & vbCrLf, src)
        mySql &= "ORDER BY LastName ASC, FirstName ASC"

        Console.WriteLine("SQL: " & mySql)
        Dim ds As DataSet = LoadSQL(mySql)
        Dim MaxRow As Integer = ds.Tables(0).Rows.Count
        If MaxRow <= 0 Then
            Exit Sub
        End If

        lvClient.Items.Clear()
        For Each clientRow As DataRow In ds.Tables(0).Rows
            Dim tmpClient As New Client
            tmpClient.LoadClientByRow(clientRow)
            AddItem(tmpClient)
        Next

        MsgBox(MaxRow & " result found", MsgBoxStyle.Information, "Search Client")
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged

    End Sub
End Class