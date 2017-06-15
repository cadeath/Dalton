Imports System.Threading
' USE README-DEVELOPER TO USE THIS PROPERLY.
' Version
' 1.2
' - AutoSelect Added
' 1.1.1
' - Enhance Auto Search Form
' 1.1
' - Auto Search Form

Public Class frmClientNew
    Friend AccessType As String = ""
    Private IsKYCRequired As Boolean = IIf(GetOption("KYCRequired") = "Yes", True, False)

    Dim fromOtherForm As Boolean = False
    Friend GetCustomer As Customer
    Dim frmOrig As formSwitch.FormName
    ''' <summary>
    ''' load Customer information to the listview.
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
            th = New Thread(AddressOf LoadCustomer)
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
    ''' <param name="cus"></param>
    ''' <remarks></remarks>
    Private Sub AddItem(ByVal cus As Customer)
        Dim lv As ListViewItem = lvCustomer.Items.Add(cus.CustomerID)
        lv.SubItems.Add(String.Format("{0}, {1} {2}", cus.LastName, cus.FirstName, cus.MiddleName))
        lv.SubItems.Add(String.Format("{0} {1} {2}", cus.PresentStreet, cus.PresentBarangay, cus.PresentCity))

        For Each Ph As PhoneNumber In cus.CustomersPhone
            If Ph.isPrimary = True Then
                lv.SubItems.Add(Ph.PhoneNumber)
            End If
        Next

        For Each Ph As PhoneNumber In cus.CustomersPhone
            lv.SubItems.Add(Ph.PhoneNumber)
            Exit For
        Next

        If cus.iSDumper = True Then lv.BackColor = Color.YellowGreen

        lv.ImageKey = "imgMale"
        If cus.Sex = 0 Then
            lv.ImageKey = "imgFemale"
        End If
    End Sub
    ''' <summary>
    ''' this method will clear the textbox and the listview items.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearField()
        txtSearch.Text = ""
        lvCustomer.Items.Clear()
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
    Friend Sub LoadCustomer()
        'On Error Resume Next

        If lvCustomer.InvokeRequired Then
            lvCustomer.Invoke(New LoadClient_delegate(AddressOf LoadCustomer))
        Else
            lvCustomer.Enabled = False
            lvCustomer.BackColor = Color.White
            btnView.Enabled = False
            txtSearch.ReadOnly = True
            btnSearch.Enabled = False

            Me.Enabled = False

            Dim mySql As String = String.Format("SELECT FIRST 10 * FROM {0} ORDER BY LastName ASC, FirstName ASC", CUSTOMER_TABLE)
            Dim ds As DataSet = LoadSQL(mySql, CUSTOMER_TABLE)

            lvCustomer.Items.Clear()
            For Each pawner As DataRow In ds.Tables(0).Rows
                Dim tmpCustomer As New Customer
                tmpCustomer.Load_CustomerByID(pawner.Item("ID"))
                AddItem(tmpCustomer)

                Application.DoEvents()
            Next

            lvCustomer.Enabled = True
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
    '''
    ''' 
    ''' <summary>
    ''' This button will show client information in the client form.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        If lvCustomer.SelectedItems.Count <= 0 Then Exit Sub

        Dim cusID As Integer
        cusID = lvCustomer.FocusedItem.Text
        Console.WriteLine("CustomerID : " & cusID)

        Dim tmpCus As New Customer
        tmpCus.Load_CustomerByID(cusID)


        frmCustomer_KYC.Show()
        frmCustomer_KYC.LoadClientInForm(tmpCus)
    End Sub

    ''' <summary>
    ''' doubleclick specific data in the listview and show thier information in the client form.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lvClient_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvCustomer.DoubleClick
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
        frmCustomer_KYC.btnHistory.Visible = False
        frmCustomer_KYC.Show()
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
            MsgBox("3 Characters Below Not Allowed.", MsgBoxStyle.Exclamation, "Customer Search")
        Else

            Dim secured_str As String = txtSearch.Text
            secured_str = DreadKnight(secured_str)
            Dim strWords As String() = secured_str.Split(New Char() {" "c})
            Dim name As String

            Dim src As String = secured_str
            Dim mySql As String = "SELECT * FROM CUSTOMER_VIEW " & vbCrLf
            mySql &= " WHERE "
            mySql &= String.Format("UPPER(BRGY1) LIKE UPPER('%{0}%') OR " & vbCrLf, src)
            mySql &= String.Format("UPPER(CITY1) LIKE UPPER('%{0}%') OR " & vbCrLf, src)
            mySql &= String.Format("UPPER(BRGY2) LIKE UPPER('%{0}%') OR " & vbCrLf, src)
            mySql &= String.Format("UPPER(CITY2) LIKE UPPER('%{0}%') OR " & vbCrLf, src)
            For Each name In strWords
                mySql &= vbCr & " UPPER(LastName ||' '|| FirstName ||' '|| MIDNAME) LIKE UPPER('%" & name & "%') and "
                mySql &= vbCr & "UPPER(FirstName ||' '|| MIDNAME ||' '|| LastName) LIKE UPPER('%" & name & "%') and "
                If name Is strWords.Last Then
                    mySql &= vbCr & " UPPER(FirstName ||' '|| LastName ||' '|| MIDNAME) LIKE UPPER('%" & name & "%') "
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

            lvCustomer.Items.Clear()
            For Each CustomerRow As DataRow In ds.Tables(0).Rows
                Dim tmpCustomer As New Customer
                tmpCustomer.Load_CustomerByID(CustomerRow.Item(0))
                AddItem(tmpCustomer)
            Next

            MsgBox(MaxRow & " result found", MsgBoxStyle.Information, "Search Customer")
            lvCustomer.Items(0).Focused = True
        End If
    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        If lvCustomer.Items.Count = 0 Then Exit Sub

        If lvCustomer.SelectedItems.Count = 0 Then
            lvCustomer.Items(0).Focused = True
        End If

        Dim idx As Integer = CInt(lvCustomer.FocusedItem.Text)
        GetCustomer = New Customer
        GetCustomer.Load_CustomerByID(idx)

        If IsKYCRequired Then
            If GetCustomer.CImage = "" Then
                MsgBox("This customer's information is required to update.", _
                       MsgBoxStyle.Information, "Information")
                btnView.PerformClick() : Exit Sub
            End If
        End If

        If GetCustomer.iSDumper = True Then MsgBox("This is to inform you that this person is a " & vbCrLf & _
          "DUMPER!", MsgBoxStyle.Exclamation, "DUMPER ALERT")

        formSwitch.ReloadFormFromSearch(frmOrig, GetCustomer)

        Me.Close()
    End Sub

    Friend Sub AutoSelect(ByVal cus As Customer)
        If Not fromOtherForm Then
            txtSearch.Text = cus.FirstName
            Exit Sub
        End If

        formSwitch.ReloadFormFromSearch(frmOrig, cus)
        Me.Close()
    End Sub

    Private Sub lvCustomer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvCustomer.KeyPress
        If isEnter(e) Then
            If fromOtherForm Then
                btnSelect.PerformClick()
            Else
                btnView.PerformClick()
            End If
        End If
    End Sub

    Private Sub lvClient_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvCustomer.SelectedIndexChanged

    End Sub

    Private Sub verification()
        If AccountRule.HasPrivilege("Client Management") = "Read Only" Then
            btnAdd.Enabled = False
        End If
    End Sub
End Class