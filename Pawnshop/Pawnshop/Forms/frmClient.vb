Imports System.Threading
' USE README-DEVELOPER TO USE THIS PROPERLY.
' Version
' 1.2
' - AutoSelect Added
' 1.1.1
' - Enhance Auto Search Form
' 1.1
' - Auto Search Form

Public Class frmClient
    Friend AccessType As String = ""
    Dim fromOtherForm As Boolean = False
    Friend GetClient As Client
    Dim frmOrig As formSwitch.FormName
    ''' <summary>
    ''' load client information to the listview.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmClient_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.TopMost = True
        web_ads.AdsDisplay = webAds
        web_ads.Ads_Initialization()

        If Not fromOtherForm Then ClearField()

        If txtSearch.Text = "" Then
            Dim th As Thread
            th = New Thread(AddressOf LoadClients)
            th.Start()
        End If

        If Not fromOtherForm Then
            txtSearch.Focus()
        End If
        txtSearch.Text = IIf(txtSearch.Text <> "", txtSearch.Text, "")
        If txtSearch.Text <> "" Then
            btnSearch.PerformClick()
        End If

        verification()
    End Sub
    ''' <summary>
    ''' this method will set listview columns
    ''' </summary>
    ''' <param name="cl"></param>
    ''' <remarks></remarks>
    Private Sub AddItem(ByVal cl As Client)
        Dim lv As ListViewItem = lvClient.Items.Add(cl.ID)
        lv.SubItems.Add(String.Format("{0}, {1} {2}", cl.LastName, cl.FirstName, cl.MiddleName))
        lv.SubItems.Add(String.Format("{0} {1} {2}", cl.AddressSt, cl.AddressBrgy, cl.AddressCity))
        lv.SubItems.Add(cl.Cellphone1)
        lv.ImageKey = "imgMale"
        If cl.Sex = 0 Then
            lv.ImageKey = "imgFemale"
        End If
        If cl.IsDumper = True Then lv.BackColor = Color.YellowGreen

    End Sub
    ''' <summary>
    ''' this method will clear the textbox and the listview items.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearField()
        txtSearch.Text = ""
        lvClient.Items.Clear()
    End Sub

    Friend Sub SearchSelect(ByVal src As String, ByVal frmOrigin As formSwitch.FormName)
        fromOtherForm = True
        btnSelect.Visible = True
        txtSearch.Text = src
        frmOrig = frmOrigin
    End Sub

    ''' <summary>
    ''' This method load all client information and show to the listview.
    ''' </summary>
    ''' <remarks></remarks>
    Private Delegate Sub LoadClient_delegate()
    Friend Sub LoadClients()
        'On Error Resume Next

        If lvClient.InvokeRequired Then
            lvClient.Invoke(New LoadClient_delegate(AddressOf LoadClients))
        Else
            lvClient.Enabled = False
            lvClient.BackColor = Color.White
            btnView.Enabled = False
            txtSearch.ReadOnly = True
            btnSearch.Enabled = False

            Me.Enabled = False

            Dim tbl As String = "TBLCLIENT"
            Dim mySql As String = String.Format("SELECT FIRST 100 * FROM {0} ORDER BY LastName ASC, FirstName ASC", tbl)
            Dim ds As DataSet = LoadSQL(mySql, tbl)

            lvClient.Items.Clear()
            For Each pawner As DataRow In ds.Tables(0).Rows
                Dim tmpClient As New Client
                tmpClient.LoadClient(pawner.Item("ClientID"))
                AddItem(tmpClient)

                Application.DoEvents()
            Next

            lvClient.Enabled = True
            btnView.Enabled = True
            txtSearch.ReadOnly = False
            btnSearch.Enabled = True

            Me.Enabled = True
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    ''' <summary>
    ''' This keypress perform search when you press enter.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If isEnter(e) Then
            btnSearch.PerformClick()
        End If
    End Sub

    ''' <summary>
    ''' This button will show client information in the client form.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        If lvClient.SelectedItems.Count <= 0 Then Exit Sub

        Dim clientID As Integer
        clientID = lvClient.FocusedItem.Text
        Console.WriteLine("ClientID : " & clientID)

        Dim tmpCl As New Client
        tmpCl.LoadClient(clientID)

        frmClientInformation.Show()
        frmClientInformation.LoadClientInForm(tmpCl)
        frmClientInformation.btnSelect.Visible = False
    End Sub
    ''' <summary>
    ''' doubleclick specific data in the listview and show thier information in the client form.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lvClient_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvClient.DoubleClick
        If Not fromOtherForm Then
            btnView.PerformClick()
        Else
            btnSelect.PerformClick()
        End If
    End Sub
    ''' <summary>
    ''' This button will show the frmclientinformation.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        frmClientInformation.Show()

    End Sub

    ''' <summary>
    ''' This button will search the specific client information.
    ''' Load the information to the listview.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If txtSearch.Text.Length <= 3 Then
            MsgBox("3 Characters Below Not Allowed.", MsgBoxStyle.Exclamation, "Client Search")
        Else
      
        Dim secured_str As String = txtSearch.Text
        secured_str = DreadKnight(secured_str)
        Dim strWords As String() = secured_str.Split(New Char() {" "c})
        Dim name As String

        Dim src As String = secured_str
        Dim mySql As String = "SELECT * FROM VIEW_CLIENT " & vbCrLf
        mySql &= " WHERE "
        mySql &= String.Format("UPPER(Addr_Brgy) LIKE UPPER('%{0}%') OR " & vbCrLf, src)
        mySql &= String.Format("UPPER(Addr_City) LIKE UPPER('%{0}%') OR " & vbCrLf, src)
        mySql &= String.Format("Phone1 LIKE '%{0}%' OR " & vbCrLf, src)
        mySql &= String.Format("Phone2 LIKE '%{0}%' OR " & vbCrLf, src)
        mySql &= String.Format("Phone_Others LIKE '%{0}%' OR" & vbCrLf, src)
        For Each name In strWords
            mySql &= vbCr & " UPPER(LastName ||' '|| FirstName ||' '|| MiddleName) LIKE UPPER('%" & name & "%') and "
            mySql &= vbCr & "UPPER(FirstName ||' '|| MiddleName ||' '|| LastName) LIKE UPPER('%" & name & "%') and "
            If name Is strWords.Last Then
                mySql &= vbCr & " UPPER(FirstName ||' '|| LastName ||' '|| MiddleName) LIKE UPPER('%" & name & "%') "
                Exit For
            End If
        Next
        mySql &= "ORDER BY LastName ASC, FirstName ASC"

        Console.WriteLine("SQL: " & mySql)
        Dim ds As DataSet = LoadSQL(mySql)
        Dim MaxRow As Integer = ds.Tables(0).Rows.Count
        If MaxRow <= 0 Then
            MsgBox("No result found", MsgBoxStyle.Critical)
            txtSearch.SelectAll()
            Exit Sub
        End If

        lvClient.Items.Clear()
        For Each clientRow As DataRow In ds.Tables(0).Rows
            Dim tmpClient As New Client
            tmpClient.LoadClientByRow(clientRow)
            AddItem(tmpClient)
        Next

        MsgBox(MaxRow & " result found", MsgBoxStyle.Information, "Search Client")
            lvClient.Items(0).Focused = True
        End If
    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        If lvClient.Items.Count = 0 Then Exit Sub

        If lvClient.SelectedItems.Count = 0 Then
            lvClient.Items(0).Focused = True
        End If

        Dim idx As Integer = CInt(lvClient.FocusedItem.Text)
        GetClient = New Client
        GetClient.LoadClient(idx)


        If GetClient.IsDumper = True Then MsgBox("This is to inform you that this person is a " & vbCrLf & _
            "DUMPER!", MsgBoxStyle.Exclamation, "DUMPER ALERT")

        'formSwitch.ReloadFormFromSearch(frmOrig, GetClient)

        Me.Close()
    End Sub

    Friend Sub AutoSelect(ByVal cl As Client)
        If Not fromOtherForm Then
            txtSearch.Text = cl.FirstName
            Exit Sub
        End If

        'formSwitch.ReloadFormFromSearch(frmOrig, cl)
        Me.Close()
    End Sub

    Private Sub lvClient_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvClient.KeyPress
        If isEnter(e) Then
            If fromOtherForm Then
                btnSelect.PerformClick()
            Else
                btnView.PerformClick()
            End If
        End If
    End Sub

    Private Sub verification()
        If AccountRule.HasPrivilege("Client Management") = "Read Only" Then
            btnAdd.Enabled = False
        End If
    End Sub

    Private Sub lvClient_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvClient.SelectedIndexChanged

    End Sub
End Class