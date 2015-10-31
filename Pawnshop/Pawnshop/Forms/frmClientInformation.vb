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

    Private Sub frmClientInformation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearFields()
        txtFirstName.Focus()

        If isReady() Then
            Console.WriteLine("Database connected")
        End If

        'Populate()
    End Sub

    Friend Sub LoadClientInForm(ByVal cl As Client)
        ' Display select buttons
        btnIDSelect.Visible = True
        btnSelect.Visible = True

        txtFirstName.Text = cl.FirstName
        txtMiddleName.Text = cl.MiddleName
        txtLastName.Text = cl.LastName
        txtSuffix.Text = cl.Suffix

        txtStreet.Text = cl.AddressSt
        txtBrgy.Text = cl.AddressBrgy
        txtCity.Text = cl.AddressCity
        txtProvince.Text = cl.AddressProvince
        txtZip.Text = cl.ZipCode

        cboGender.Text = IIf(cl.Sex = Client.Gender.Male, "Male", "Female")
        dtpBday.Value = cl.Birthday

        txtCP1.Text = cl.Cellphone1
        txtCP2.Text = cl.Cellphone2
        txtTele.Text = cl.Telephone
        txtOthers.Text = cl.OtherNumber

        SelectedClient = cl

        LoadID(cl)
        ComputeBirthday()
        LockFields(True)
    End Sub

    Private Sub ReturnToOriginForm()
        FormOrigin.Show()
    End Sub

    Friend Sub ComputeBirthday()
        lblAge.Text = "N/A"
        lblAge.Text = GetCurrentAge(dtpBday.Value) & " years old"
    End Sub

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
        txtCity.ReadOnly = st
        txtProvince.ReadOnly = st
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
        txtCity.Text = "General Santos City"
        txtProvince.Text = "South Cotabato"
        txtZip.Text = "9500"

        cboGender.Text = "Male"
        dtpBday.Value = #11/7/1986#

        txtCP1.Text = "0922-684-7559"
    End Sub

    Private Sub ClearFields()
        txtFirstName.Text = ""
        txtMiddleName.Text = ""
        txtLastName.Text = ""
        txtSuffix.Text = ""

        txtStreet.Text = ""
        txtBrgy.Text = ""
        txtCity.Text = ""
        txtProvince.Text = ""
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

    Private Sub txtZip_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtZip.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub PhoneSeparator(ByVal PhoneField As TextBox, ByVal e As KeyPressEventArgs, Optional ByVal isPhone As Boolean = False)
        Dim charPos() As Integer = {}
        If PhoneField.Text = Nothing Then Return

        Select Case PhoneField.Text.Substring(0, 1)
            Case "0"
                charPos = {4, 8}
            Case "9"
                charPos = {3, 7} '922-797-7559
            Case "+"
                charPos = {3, 7, 11} '+63-919-797-7559
            Case "6"
                charPos = {2, 6, 10} '63-919-797-7559
        End Select
        If isPhone Then
            Select Case PhoneField.Text.Substring(0, 1)
                Case "0"
                    charPos = {3, 7}
                Case Else
                    charPos = {2, 6}
            End Select
        End If

        For Each pos In charPos
            If PhoneField.TextLength = pos And Not e.KeyChar = vbBack Then
                PhoneField.Text &= "-"
                PhoneField.SelectionStart = pos + 1
            End If
        Next
    End Sub

    Private Sub txtCP1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCP1.KeyPress
        DigitOnly(e)
        PhoneSeparator(txtCP1, e)
    End Sub

    Private Sub txtCP2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCP2.KeyPress
        DigitOnly(e)
        PhoneSeparator(txtCP2, e)
    End Sub

    Private Sub txtTele_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTele.KeyPress
        DigitOnly(e)
        PhoneSeparator(txtTele, e, True)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If btnSave.Text = "&Modify" Then
            isNew = False
            LockFields(False)

            Exit Sub
        End If
        If txtFirstName.Text = "" Or txtMiddleName.Text = "" Or txtLastName.Text = "" Then
            MsgBox("Please fill up information", MsgBoxStyle.Critical, "Empty Fields")
            Exit Sub
        End If

        Dim tmpClient As New Client
        If Not isNew Then tmpClient = SelectedClient

        With tmpClient
            .FirstName = txtFirstName.Text
            .MiddleName = txtMiddleName.Text
            .LastName = txtLastName.Text
            .Suffix = txtSuffix.Text

            .AddressSt = txtStreet.Text
            .AddressBrgy = txtBrgy.Text
            .AddressCity = txtCity.Text
            .AddressProvince = txtProvince.Text
            .ZipCode = txtZip.Text

            .Sex = IIf(cboGender.Text = "Male", Client.Gender.Male, Client.Gender.Female)
            .Birthday = dtpBday.Value

            .Cellphone1 = txtCP1.Text
            .Cellphone2 = txtCP2.Text
            .Telephone = txtTele.Text
            .OtherNumber = txtOthers.Text

            If isNew Then
                .SaveClient()

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


        frmClient.btnSearch.PerformClick()
        Me.Close()
    End Sub

    Private Sub dtpBday_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtpBday.KeyPress
        If lockForm Then
            e.Handled = True
        End If
    End Sub

    Private Sub dtpBday_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpBday.ValueChanged
        ComputeBirthday()
    End Sub

    Private Sub cboGender_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboGender.KeyPress
        If lockForm Then
            e.Handled = True
        End If
    End Sub

    'ID Group===================
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

    Private Sub AddID(ByVal cID As IdentificationCard)
        Dim lv As ListViewItem = lvID.Items.Add(cID.IDType)
        lv.SubItems.Add(cID.ReferenceNumber)
        lv.SubItems.Add(cID.Remarks)

        If cID.isSelected Then
            lv.BackColor = Color.ForestGreen
        End If

        cID.ClientID = SelectedClient.ID
        ClientIDs.Add(cID)
    End Sub

    Private Sub txtRef_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRef.KeyPress
        If isEnter(e) Then txtRemarks.Focus()
    End Sub

    Private Sub txtRemarks_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRemarks.KeyPress
        If isEnter(e) Then btnAdd.PerformClick()
    End Sub

    Private Sub cboIDtype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboIDtype.SelectedIndexChanged
        'If Not cboIDtype.DroppedDown And cboIDtype.Text <> "" Then txtRef.Focus()
    End Sub

    Private Sub ClearIDFields()
        cboIDtype.DroppedDown = True
        txtRef.Text = ""
        txtRemarks.Text = ""
    End Sub

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

    Private Sub idSelected(ByVal SelID As IdentificationCard)
        SelID.Selected()
    End Sub

    Private Sub SaveIDs(Optional ByVal cl As Client = Nothing)
        defaultID()

        Dim xIdx As Integer = 0
        For Each cID As IdentificationCard In ClientIDs
            If cID.ID = Nothing Then
                cID.ClientID = cl.ID
                cID.Save()
            Else
                cID.Modify()
                Console.WriteLine("cID#: " & cID.ID)
            End If
            xIdx += 1
        Next
    End Sub

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
End Class