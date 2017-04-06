' Changelog
' 1.2 10/26/2015
'  - Fixing ID List
' 1.1 10/20/2015
'  - ComputerBirthday Added
'  - LockFields
Public Class frmClientInformation

    Private lockForm As Boolean = False
    Friend FormOrigin As Form
    Friend SelectedClient As Client 'Holds Client
    Private isNew As Boolean = True

    Private ClientIDs As New CollectionID
    ''' <summary>
    ''' call the clearfields method.
    ''' focus the cursor in txtFirstname textbox.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmClientInformation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TopMost = True
        frmClient.Enabled = False
        web_ads.AdsDisplay = webAds
        web_ads.Ads_Initialization()

        ClearFields()
        txtFirstName.Focus()

        If isReady() Then
            Console.WriteLine("Database connected")
        End If

        cboCity.Items.AddRange(GetDistinct("Addr_City"))
        cboProv.Items.AddRange(GetDistinct("Addr_Province"))
        'Populate()
    End Sub
    ''' <summary>
    ''' This method will select client specifically from the table.
    ''' </summary>
    ''' <param name="col"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetDistinct(ByVal col As String) As String()
        Dim mySql As String = "SELECT DISTINCT " & col & " FROM tblClient WHERE " & col & " <> '' ORDER BY " & col & " ASC"
        Dim ds As DataSet = LoadSQL(mySql)

        Dim MaxCount As Integer = ds.Tables(0).Rows.Count
        Dim str(MaxCount - 1) As String
        For cnt As Integer = 0 To MaxCount - 1
            Dim tmpStr As String = ds.Tables(0).Rows(cnt).Item(0)
            str(cnt) = tmpStr
        Next

        Return str
    End Function
    ''' <summary>
    ''' This method will able to load data to the textfields.
    ''' </summary>
    ''' <param name="cl"></param>
    ''' <remarks></remarks>
    Friend Sub LoadClientInForm(ByVal cl As Client)
        If cl.FirstName = "" Then Exit Sub

        ' Display select buttons
        btnIDSelect.Visible = True
        btnSelect.Visible = True

        txtFirstName.Text = cl.FirstName
        txtMiddleName.Text = cl.MiddleName
        txtLastName.Text = cl.LastName
        txtSuffix.Text = cl.Suffix

        txtStreet.Text = cl.AddressSt
        txtBrgy.Text = cl.AddressBrgy
        cboCity.Text = cl.AddressCity
        cboProv.Text = cl.AddressProvince
        txtZip.Text = cl.ZipCode

        cboGender.Text = IIf(cl.Sex = Client.Gender.Male, "Male", "Female")
        dtpBday.Value = IIf(cl.Birthday.Date > dtpBday.MinDate, cl.Birthday.Date, dtpBday.MinDate)

        txtCP1.Text = cl.Cellphone1
        txtCP2.Text = cl.Cellphone2
        txtTele.Text = cl.Telephone
        txtOthers.Text = cl.OtherNumber

        SelectedClient = cl

        LoadID(cl)
        ComputeBirthday()
        LockFields(True)
    End Sub
    ''' <summary>
    ''' This method will computer the birth day of the client.
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub ComputeBirthday()
        lblAge.Text = "N/A"
        lblAge.Text = GetCurrentAge(dtpBday.Value) & " years old"
    End Sub
    ''' <summary>
    ''' This method will disabled the textfield.
    ''' </summary>
    ''' <param name="st"></param>
    ''' <remarks></remarks>
    Private Sub LockFields(ByVal st As Boolean)
        lockForm = st

        Console.WriteLine(txtFirstName.BackColor)
        txtFirstName.ReadOnly = st
        'txtFirstName.BackColor = SystemColors.Window
        txtMiddleName.ReadOnly = st
        txtLastName.ReadOnly = st
        txtSuffix.ReadOnly = st

        txtStreet.ReadOnly = st
        txtBrgy.ReadOnly = st
        cboCity.Enabled = Not st
        cboProv.Enabled = Not st
        txtZip.ReadOnly = st

        cboGender.Enabled = Not st
        dtpBday.Enabled = Not st

        txtCP1.ReadOnly = st
        txtCP2.ReadOnly = st
        txtTele.ReadOnly = st
        txtOthers.ReadOnly = st

        cboIDtype.Enabled = Not st
        txtRef.ReadOnly = st
        txtRemarks.ReadOnly = st

        grpID.Enabled = Not st

        If st Then
            btnSave.Text = "&Modify"
        Else
            btnSave.Text = "&Save"
        End If
    End Sub

    ' Remove in Final
    ' This is to populate the form only
    ' For development purposes
    Private Sub Populate()
        txtFirstName.Text = "Jacob"
        txtMiddleName.Text = "X"
        txtLastName.Text = "Fyre"

        txtStreet.Text = "153 Acacia St. Balite"
        txtBrgy.Text = "Lagao"
        cboCity.Text = "General Santos City"
        cboProv.Text = "South Cotabato"
        txtZip.Text = "9500"

        cboGender.Text = "Male"
        dtpBday.Value = #11/7/1986#

        txtCP1.Text = "0922-684-7559"
    End Sub
    ''' <summary>
    ''' This method will able to clear the text fields.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearFields()
        txtFirstName.Text = ""
        txtMiddleName.Text = ""
        txtLastName.Text = ""
        txtSuffix.Text = ""

        txtStreet.Text = ""
        txtBrgy.Text = ""
        cboCity.Text = ""
        cboProv.Text = ""
        txtZip.Text = ""

        cboGender.DropDownStyle = ComboBoxStyle.DropDownList
        cboGender.Items.Clear()
        cboGender.Items.Add("Male")
        cboGender.Items.Add("Female")
        dtpBday.Value = Now

        txtCP1.Text = ""
        txtCP2.Text = ""
        txtTele.Text = ""
        txtOthers.Text = ""

        cboIDtype.DropDownStyle = ComboBoxStyle.DropDownList
        cboIDtype.SelectedIndex = -1
        txtRef.Text = ""
        txtRemarks.Text = ""
        lvID.Items.Clear()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    ''' <summary>
    ''' This keypress means only digit is allow to enter in this text field.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtZip_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtZip.KeyPress
        DigitOnly(e)
    End Sub

    ''' <summary>
    ''' This keypress is accept digit only and call the phoneSeparator method.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtCP1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCP1.KeyPress
        DigitOnly(e)
        PhoneSeparator(txtCP1, e)
    End Sub
    ''' <summary>
    ''' This keypress is accept digit only and call the phoneSeparator method.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtCP2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCP2.KeyPress
        DigitOnly(e)
        PhoneSeparator(txtCP2, e)
    End Sub
    ''' <summary>
    ''' This keypress is accept digit only and call the phoneSeparator method.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtTele_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTele.KeyPress
        DigitOnly(e)
        PhoneSeparator(txtTele, e, True)
    End Sub
    ''' <summary>
    ''' This function shows the requirements of the client.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function isValid() As Boolean
        If txtFirstName.Text = "" Then txtFirstName.Focus() : Return False
        If txtLastName.Text = "" Then txtLastName.Focus() : Return False

        If RequirementLevel = 2 Then
            If cboCity.Text = "" Then cboCity.Focus() : Return False
            If cboGender.Text = "" Then cboGender.Focus() : Return False
            If dtpBday.Value >= Now.Date Then dtpBday.Focus() : Return False
        End If

        If RequirementLevel >= 3 Then
            If lvID.Items.Count < 1 Then
                MsgBox("Must have atleast ONE Valid ID", MsgBoxStyle.Critical)
                Return False
            End If
        End If

        Return True
    End Function
    ''' <summary>
    ''' This button will update the client information.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If btnSave.Text = "&Modify" Then
            isNew = False
            LockFields(False)
            Exit Sub
        End If

        If Not isValid() Then Exit Sub

        Dim tmpClient As New Client
        If Not isNew Then tmpClient = SelectedClient

        With tmpClient
            .FirstName = txtFirstName.Text
            .MiddleName = txtMiddleName.Text
            .LastName = txtLastName.Text
            .Suffix = txtSuffix.Text

            .AddressSt = txtStreet.Text
            .AddressBrgy = txtBrgy.Text
            .AddressCity = cboCity.Text
            .AddressProvince = cboProv.Text
            .ZipCode = txtZip.Text

            .Sex = IIf(cboGender.Text = "Male", Client.Gender.Male, Client.Gender.Female)
            .Birthday = dtpBday.Value

            .Cellphone1 = txtCP1.Text
            .Cellphone2 = txtCP2.Text
            .Telephone = txtTele.Text
            .OtherNumber = txtOthers.Text

            If isNew Then
                .SaveClient()
                tmpClient.LoadLastEntry()
            Else
                .ModifyClient()
            End If
        End With

        SaveIDs(tmpClient)

        If isNew Then
            MsgBox("Entry Saved", MsgBoxStyle.Information)
        Else
            MsgBox("Entry Updated", MsgBoxStyle.Information)
        End If

        'frmClient.btnSearch.PerformClick()
        'tmpClient.LoadClient(tmpClient.ID)
        'frmClient.AutoSelect(tmpClient)
        Me.Close()
    End Sub
    ''' <summary>
    ''' This keypress will lock the dtpBday accept digit only.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dtpBday_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtpBday.KeyPress
        If lockForm Then
            e.Handled = True
        End If
    End Sub
    ''' <summary>
    ''' This value changed call the computeBirthday method.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dtpBday_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpBday.ValueChanged
        ComputeBirthday()
    End Sub
    ''' <summary>
    ''' This keypress accept digit only.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cboGender_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboGender.KeyPress
        If lockForm Then
            e.Handled = True
        End If
    End Sub

    ''' <summary>
    ''' ID Group===================
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If cboIDtype.Text = "" Or txtRef.Text = "" Then Exit Sub

        Dim tmpID As New IdentificationCard
        tmpID.IDType = cboIDtype.Text
        tmpID.ReferenceNumber = txtRef.Text
        tmpID.Remarks = txtRemarks.Text

        AddID(tmpID)
        ClearIDFields()
        cboIDtype.Focus()
    End Sub
    ''' <summary>
    ''' This method allow to add identification card of the client.
    ''' </summary>
    ''' <param name="cID"></param>
    ''' <remarks></remarks>
    Private Sub AddID(ByVal cID As IdentificationCard)
        Dim lv As ListViewItem = lvID.Items.Add(cID.IDType)
        lv.SubItems.Add(cID.ReferenceNumber)
        lv.SubItems.Add(cID.Remarks)

        If cID.isSelected Then
            lv.BackColor = Color.ForestGreen
        End If

        If Not SelectedClient Is Nothing Then
            cID.ClientID = SelectedClient.ID
        End If
        ClientIDs.Add(cID)
    End Sub

    Private Sub txtRef_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRef.KeyPress
        If isEnter(e) Then txtRemarks.Focus()
    End Sub

    Private Sub txtRemarks_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRemarks.KeyPress
        If isEnter(e) Then btnAdd.PerformClick()
    End Sub
    ''' <summary>
    ''' This method will clear the text fields and combobox.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearIDFields()
        cboIDtype.DroppedDown = True
        txtRef.Text = ""
        txtRemarks.Text = ""
    End Sub
    ''' <summary>
    ''' This method will load the identification card of a client.
    ''' </summary>
    ''' <param name="cl"></param>
    ''' <remarks></remarks>
    Private Sub LoadID(ByVal cl As Client)
        Dim mySql As String
        mySql = "SELECT * FROM tblIdentification WHERE clientID = " & cl.ID

        Dim ds As DataSet = LoadSQL(mySql)
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim tmpID As New IdentificationCard
            tmpID.LoadID(dr.Item("id"))

            AddID(tmpID)
        Next
    End Sub
    ''' <summary>
    ''' This method select the id of a client
    ''' </summary>
    ''' <param name="SelID"></param>
    ''' <remarks></remarks>
    Private Sub idSelected(ByVal SelID As IdentificationCard)
        SelID.Selected()
    End Sub
    ''' <summary>
    ''' This method will modify the Identification card of a client.
    ''' call the default id method.
    ''' </summary>
    ''' <param name="cl"></param>
    ''' <remarks></remarks>
    Private Sub SaveIDs(Optional ByVal cl As Client = Nothing)
        defaultID()

        Dim xIdx As Integer = 0
        For Each cID As IdentificationCard In ClientIDs
            If cID.ID = Nothing Then
                cID.ClientID = cl.ID
                'idSelected(cID)
                cID.Save()
            Else
                cID.Modify()
                Console.WriteLine("cID#: " & cID.ID)
            End If
            xIdx += 1
        Next
    End Sub
    ''' <summary>
    ''' This method will load the default identification of a client.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub defaultID()
        Dim hasSelected As Boolean = False, cnt As Integer = 0

        For Each lv As ListViewItem In lvID.Items
            If lv.BackColor = Color.ForestGreen Then
                hasSelected = True
            End If
        Next

        If Not hasSelected And lvID.Items.Count > 0 Then
            lvID.Items(0).BackColor = Color.ForestGreen
            ClientIDs.Item(0).Selected()
        End If
    End Sub

    Private Sub btnIDSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIDSelect.Click
        If lvID.SelectedItems.Count <= 0 Then Exit Sub

        Dim idx As Integer
        idx = lvID.FocusedItem.Index

        For cnt As Integer = 0 To lvID.Items.Count - 1
            Dim lv As ListViewItem = lvID.Items(cnt)
            lv.BackColor = System.Drawing.SystemColors.Window
            ClientIDs.Item(cnt).isSelected = False
        Next

        'ListViewItem Highlight
        lvID.FocusedItem.BackColor = Color.ForestGreen
        ClientIDs.Item(idx).Selected()
        'lvID.FocusedItem.Selected = True
    End Sub
    'END - ID Group===================
    ''' <summary>
    ''' This button will load the history of the client and load to the frmReport.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHistory.Click
        If Not txtFirstName.Enabled Then Exit Sub

        Dim mySql As String
        mySql = "SELECT C.CLIENTID, C.FIRSTNAME || ' ' || C.LASTNAME || ' ' || "
        mySql &= "CASE WHEN C.SUFFIX is Null THEN '' ELSE C.SUFFIX END AS FULLNAME, "
        mySql &= "C.ADDR_STREET || ' ' || C.ADDR_BRGY || ' ' || C.ADDR_CITY || ' ' ||  C.ADDR_PROVINCE AS ADDRESS, "
        mySql &= "C.BIRTHDAY, C.PHONE1, C.PHONE2, P.PAWNTICKET, CASE P.STATUS	WHEN '0' THEN 'RENEWED' "
        mySql &= "WHEN 'R' THEN 'RENEW' "
        mySql &= "WHEN 'L' THEN 'NEW LOAN' "
        mySql &= "WHEN 'V' THEN 'VOID' "
        mySql &= "WHEN 'X' THEN 'REDEEM' "
        mySql &= "WHEN 'S' THEN 'SEGRE' "
        mySql &= "WHEN 'W' THEN 'PULLOUT: ' || CAST(ITM.WITHDRAWDATE AS DATE)  ELSE 'STATUS ERROR' "
        mySql &= "END AS STATUS, P.DESCRIPTION, "
        mySql &= "CLASS.ITEMCATEGORY, ITM.ITEMCLASS, P.LOANDATE, P.PRINCIPAL, "
        mySql &= "P.NETAMOUNT, P.RENEWDUE, P.REDEEMDUE, P.PENALTY, USR.USERNAME as APPRAISER "
        mySql &= "FROM OPT P "
        mySql &= "LEFT JOIN TBLCLIENT C ON P.CLIENTID = C.CLIENTID "
        mySql &= "INNER JOIN OPI ITM ON ITM.PAWNITEMID = P.PAWNITEMID "
        mySql &= "INNER JOIN TBLITEM CLASS ON CLASS.ITEMID = ITM.ITEMID "
        mySql &= "LEFT JOIN TBL_GAMIT USR ON USR.USERID = P.APPRAISERID "
        mySql &= vbCrLf & "WHERE "
        mySql &= vbCrLf & " P.STATUS <> 'V' AND P.CLIENTID = " & SelectedClient.ID

        Console.WriteLine(mySql)

        Dim repPara As New Dictionary(Of String, String)
        repPara.Add("txtFullname", String.Format("{0} {1} {2}", txtFirstName.Text, txtLastName.Text, txtSuffix.Text))
        repPara.Add("txtBirthday", dtpBday.Text)
        repPara.Add("txtAddr", String.Format("{0} {1} {2} {3}", txtStreet.Text, txtBrgy.Text, cboCity.Text, cboProv.Text))
        repPara.Add("txtContact", String.Join(", ", txtCP1.Text, txtCP2.Text))

        frmReport.ReportInit(mySql, "dsHistory", "Reports\rpt_History.rdlc", repPara)
        frmReport.Show()
        frmReport.TopMost = True
    End Sub

    Private Sub frmClientInformation_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        frmClient.Enabled = True
    End Sub

   
End Class