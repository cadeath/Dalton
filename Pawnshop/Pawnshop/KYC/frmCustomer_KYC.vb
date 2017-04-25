Imports System.IO

Public Class frmCustomer_KYC
    Friend ALLOW_MINORS As Boolean = True

    Const BLOCK_AGE As Integer = 7
    Const NOT_MINOR As Integer = 18

    Friend REQUIRED_ID As Boolean = False
    Private CustomerPhones As New Collections_Phone
    Private CustomerIDs As New Collections_ID

    Private SRC As String = Application.StartupPath & "\ClientImage"
    Dim FlName As String = "", Ext As String = ".EAM"

    Private lockForm As Boolean = False, IDX As Integer
    Friend FormOrigin As Form
    Friend SelectedCustomer As Customer 'Holds Customer
    Friend isNew As Boolean = True
    Private notNewPic As Boolean = True

    Private Sub frmCustomer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CACHE_MANAGEMENT()
        ClearFields()

        ' ELLIEPOPULATEINFO()
        'Populate()
    End Sub

    Friend Sub LoadClientInForm(ByVal cus As Customer)
        If cus.FirstName = "" Then Exit Sub

        IDX = cus.CustomerID
        txtFName.Text = cus.FirstName
        txtMName.Text = cus.MiddleName
        txtLName.Text = cus.LastName
        txtSuffix.Text = cus.Suffix

        txtSt1.Text = cus.PresentStreet
        cboBrgy1.Text = cus.PresentBarangay
        cboCity1.Text = cus.PresentCity
        cboProv1.Text = cus.PresentProvince
        cboZip1.Text = cus.PresentZipCode

        txtSt2.Text = cus.PermanentStreet
        cboBrgy2.Text = cus.PermanentBarangay
        cboCity2.Text = cus.PermanentCity
        cboProv2.Text = cus.PermanentProvince
        cboZip2.Text = cus.PermanentZipCode

        cboGender.Text = IIf(cus.Sex = 1, "Male", "Female")

        dtpBday.Value = IIf(cus.Birthday.Date > dtpBday.MinDate, cus.Birthday.Date, dtpBday.MinDate)
        txtBdayPlace.Text = cus.BirthPlace
        txtNationality.Text = cus.Nationality
        txtWork.Text = cus.NatureOfWork
        txtSrcFund.Text = cus.SourceOfFund

        'loading IDS

        For Each CUSIDNFTN In cus.CustomersIDs
            Dim ids As New NewIdentificationCard
            Dim lv As ListViewItem = lvID.Items.Add(CUSIDNFTN.IDType)
            lv.SubItems.Add(CUSIDNFTN.IDNumber)

            ids.ID = CUSIDNFTN.ID
            ids.CustomerID = CUSIDNFTN.CustomerID
            ids.IDType = CUSIDNFTN.IDType
            ids.IDNumber = CUSIDNFTN.IDNumber
            ids.isPrimary = IIf(CUSIDNFTN.isPrimary > 0, True, False)
            CustomerIDs.Add(ids)

            If CUSIDNFTN.isPrimary = True Then
                lv.BackColor = Color.Green
            End If
        Next


        ' loading Phones

        For Each phone In cus.CustomersPhone
            Dim ph As New PhoneNumber
            lstPhone.Items.Add(phone.PhoneNumber)

            ph.PhoneID = phone.PhoneID
            ph.CustomerID = phone.CustomerID
            ph.PhoneNumber = phone.PhoneNumber
            ph.isPrimary = IIf(phone.isPrimary > 0, True, False)
            CustomerPhones.Add(ph)
        Next

        ClientImage.Image = cus.CPUREIMAGE

        If cus.CImage = "" Then
            FlName = ""
        Else
            FlName = cus.CImage.Substring(0, cus.CImage.IndexOf("|"c))
        End If


        SelectedCustomer = cus

        ComputeBirthday()
        LockFields(False)
    End Sub

    Friend Sub ComputeBirthday()
        lblAge.Text = "N/A"
        lblAge.Text = GetCurrentAge(dtpBday.Value) & " years old"
    End Sub

    Private Sub LockFields(ByVal st As Boolean)
        lockForm = st

        Console.WriteLine(txtFName.BackColor)
        txtFName.ReadOnly = Not st
        txtMName.ReadOnly = Not st
        txtLName.ReadOnly = Not st
        txtSuffix.ReadOnly = Not st

        'tbID
        TabControl1.Enabled = st
        grpCusPic.Enabled = st

        If Not st Then
            btnSave.Text = "&Modify"
        Else
            btnSave.Text = "&Save"
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Function FormVerification() As Boolean
        Dim errMsg As String = "Please fillup the form completely"

        ' AGE VALIDATION ============================================
        Dim possible_age As Integer = (Now.Year - dtpBday.Value.Year)

        If ALLOW_MINORS Then
            If possible_age <= BLOCK_AGE Then
                Console.WriteLine("TOO YOUNG")
                TabControl1.SelectedTab = tpBasic
                Return False
            End If
        Else
            If possible_age < NOT_MINOR Then
                Console.WriteLine("NO MINOR IS ALLOWED")
                TabControl1.SelectedTab = tpBasic
                Return False
            End If
        End If
        ' END - AGE VALIDATION ======================================

        If Trim(txtFName.Text) = "" Or Trim(txtLName.Text) = "" Then
            TabControl1.SelectedTab = tpBasic
            MsgBox(errMsg, MsgBoxStyle.OkOnly, "KYC - Customer Information")
            Return False
        End If

        If Trim(cboBrgy1.Text) = "" Or Trim(cboCity1.Text) = "" Or Trim(cboProv1.Text) = "" Then
            TabControl1.SelectedTab = tpBasic
            MsgBox(errMsg, MsgBoxStyle.OkOnly, "KYC - Customer Information")
            Return False
        End If

        If Trim(cboBrgy2.Text) = "" Or Trim(cboCity2.Text) = "" Or Trim(cboProv2.Text) = "" Then
            TabControl1.SelectedTab = tpBasic
            MsgBox(errMsg, MsgBoxStyle.OkOnly, "KYC - Customer Information")
            Return False
        End If

        If Trim(txtNationality.Text) = "" Then
            TabControl1.SelectedTab = tpBasic : txtNationality.Focus()
            MsgBox(errMsg, MsgBoxStyle.OkOnly, "KYC - Customer Information")
            Return False
        End If

        If Trim(txtWork.Text) = "" Or Trim(txtSrcFund.Text) = "" Then
            TabControl1.SelectedTab = tpBasic
            MsgBox(errMsg, MsgBoxStyle.OkOnly, "KYC - Customer Information")
            Return False
        End If

        If lstPhone.Items.Count = 0 Then
            TabControl1.SelectedTab = tpBasic
            MsgBox(errMsg, MsgBoxStyle.OkOnly, "KYC - Customer Information")
            Return False
        End If

        If lvID.Items.Count = 0 Or REQUIRED_ID Then
            TabControl1.SelectedTab = tpID
            MsgBox(errMsg, MsgBoxStyle.OkOnly, "KYC - Customer Information")
            Return False
        End If

        If ClientImage.Image Is Nothing Then
            TabControl1.SelectedTab = tpBasic
            MsgBox(errMsg, MsgBoxStyle.OkOnly, "KYC - Customer Information") : Return False
        End If

        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If btnSave.Text = "&Modify" Then
            LockFields(True)
            isNew = False : Exit Sub
        End If

        If isNew Then
            SaveCustomer() : Exit Sub
        End If

        UpdateCustomer()
    End Sub

    Private Sub SaveCustomer()
        If Not FormVerification() Then Exit Sub

        If Not Directory.Exists(SRC) Then
            Directory.CreateDirectory(SRC)
        End If

GenerateRandOmString:
        FlName = FileName()

        Dim NewCustomer As New Customer

        With NewCustomer
            .FirstName = txtFName.Text
            .MiddleName = txtMName.Text
            .LastName = txtLName.Text
            .Suffix = txtSuffix.Text

            .PresentStreet = txtSt1.Text
            .PresentBarangay = cboBrgy1.Text
            .PresentCity = cboCity1.Text
            .PresentProvince = cboProv1.Text
            .PresentZipCode = cboZip1.Text

            .PermanentStreet = txtSt2.Text
            .PermanentBarangay = cboBrgy2.Text
            .PermanentCity = cboCity2.Text
            .PermanentProvince = cboProv2.Text
            .PermanentZipCode = cboZip2.Text

            .Birthday = dtpBday.Value
            .BirthPlace = txtBdayPlace.Text
            .Nationality = txtNationality.Text
            .NatureOfWork = txtWork.Text
            .SourceOfFund = txtSrcFund.Text

            .Sex = IIf(cboGender.Text = "Male", 1, 0)
            If rbLow.Checked Then _
                .Rank = Customer.RankNumber.Low
            If rbNormal.Checked Then _
                .Rank = Customer.RankNumber.Medium
            If rbHigh.Checked Then _
                .Rank = Customer.RankNumber.High


            If Not .FindRanStrIfExists(SRC & "\" & FlName & Ext) Then
                GoTo GenerateRandOmString
            End If

            ClientImage.Image.Save(String.Format("{0}{1}{2}{3}", SRC, "\", FlName, Ext))
            .CImage = String.Format("{0}{1}{2}{3}", FlName, Ext, "|", GetFileMD5(SRC & "\" & FlName & Ext))

            AutoSetPrimary_Phone() 'If no PRIMARY for PHONE

            .CustomersPhone = CustomerPhones
            .CustomersIDs = CustomerIDs

            If Not .Save() Then
                Exit Sub
            End If
        End With

        MsgBox("Successfully saved.", MsgBoxStyle.Information, "Save")
        ClearFields()

        NewCustomer.Load_CustomerByID(NewCustomer.CustomerID)
        frmClientNew.AutoSelect(NewCustomer)
        Me.Close()
    End Sub

    Private Sub UpdateCustomer()
        If Not FormVerification() Then Exit Sub

        If Not Directory.Exists(SRC) Then
            Directory.CreateDirectory(SRC)
        End If

        Dim NewCustomer As New Customer

        With NewCustomer
            .CustomerID = IDX
            .FirstName = txtFName.Text
            .MiddleName = txtMName.Text
            .LastName = txtLName.Text
            .Suffix = txtSuffix.Text

            .PresentStreet = txtSt1.Text
            .PresentBarangay = cboBrgy1.Text
            .PresentCity = cboCity1.Text
            .PresentProvince = cboProv1.Text
            .PresentZipCode = cboZip1.Text

            .PermanentStreet = txtSt2.Text
            .PermanentBarangay = cboBrgy2.Text
            .PermanentCity = cboCity2.Text
            .PermanentProvince = cboProv2.Text
            .PermanentZipCode = cboZip2.Text

            .Birthday = dtpBday.Value
            .BirthPlace = txtBdayPlace.Text
            .Nationality = txtNationality.Text
            .NatureOfWork = txtWork.Text
            .SourceOfFund = txtSrcFund.Text

            .Sex = IIf(cboGender.Text = "Male", 1, 0)
            If rbLow.Checked Then _
                .Rank = Customer.RankNumber.Low
            If rbNormal.Checked Then _
                .Rank = Customer.RankNumber.Medium
            If rbHigh.Checked Then _
                .Rank = Customer.RankNumber.High

FLNME:
            If Not notNewPic Then
                If Not NewCustomer.FindRanStrIfExists(SRC & "\" & FlName) Then
                    FlName = FileName() : GoTo FLNME
                End If
            End If

            If Not notNewPic Then
                ClientImage.Image.Save(String.Format("{0}{1}{2}{3}", SRC, "\", FlName, Ext))
            End If


            If Not notNewPic Then
                .CImage = String.Format("{0}{1}{2}{3}", FlName, Ext, "|", GetFileMD5(SRC & "\" & FlName & Ext))
            Else
                .CImage = String.Format("{0}{1}{2}", FlName, "|", GetFileMD5(SRC & "\" & FlName))
            End If


            AutoSetPrimary_Phone() 'If no PRIMARY for PHONE

            .CustomersPhone = CustomerPhones
            .CustomersIDs = CustomerIDs

            If Not .Save() Then
                Exit Sub
            End If


        End With

        MsgBox("Successfully updated.", MsgBoxStyle.Information, "Update")

        ClearFields()
        NewCustomer.Load_CustomerByID(NewCustomer.CustomerID)
        frmClientNew.AutoSelect(NewCustomer)
        Me.Close()
    End Sub
    ''' <summary>
    ''' This method will separate the phone number.
    ''' </summary>
    ''' <param name="PhoneField"></param>
    ''' <param name="e"></param>
    ''' <param name="isPhone"></param>
    ''' <remarks></remarks>
    Friend Sub PhoneSeparator(ByVal PhoneField As TextBox, ByVal e As KeyPressEventArgs, Optional ByVal isPhone As Boolean = False)
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

    Private Sub ClearFields()
        txtFName.Text = ""
        txtMName.Text = ""
        txtLName.Text = ""
        txtSuffix.Text = ""

        'BASIC 
        txtSt1.Text = ""
        cboBrgy1.Text = ""
        cboCity1.Text = ""
        cboProv1.Text = ""
        cboZip1.Text = ""

        txtSt2.Text = ""
        cboBrgy2.Text = ""
        cboCity2.Text = ""
        cboProv2.Text = ""
        cboZip2.Text = ""

        dtpBday.Value = Now
        txtBdayPlace.Text = ""
        txtWork.Text = ""
        txtNationality.Text = "FILIPINO"
        cboGender.SelectedItem = 0
        Console.WriteLine(cboGender.Items.Count)
        txtSrcFund.Text = ""

        txtPhone.Text = ""
        lstPhone.Items.Clear()
        rbLow.Checked = True

        'IDENTIFY
        cboType.SelectedIndex = 0
        txtIDNum.Text = ""
        lvID.Items.Clear()

        cboBrgy1.Items.AddRange(listBarangay.ToArray)
        cboBrgy2.Items.AddRange(listBarangay.ToArray)

        cboCity1.Items.AddRange(listCity.ToArray)
        cboCity2.Items.AddRange(listCity.ToArray)

        cboProv1.Items.AddRange(listProvince.ToArray)
        cboProv2.Items.AddRange(listProvince.ToArray)

        cboZip1.Items.AddRange(listZip.ToArray)
        cboZip2.Items.AddRange(listZip.ToArray)
        ClientImage.Image = Nothing
        Call ClosePreviewWindow()
    End Sub

    ' TODO: JUNMAR
    ' Please provide phone number verification
    ' You might copy it in our existing client
    ' management module.
    Private Sub btnPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlus.Click
        If txtPhone.Text = "" Then Exit Sub
        If CLEANPHNO(txtPhone.Text).Length < 11 Then _
            MsgBox("Phone must not less than 11 digits.", MsgBoxStyle.Critical, "") : Exit Sub

        Add_Phone(CLEANPHNO(txtPhone.Text))
        lstPhone.Items.Add(CLEANPHNO(txtPhone.Text))
        txtPhone.Text = ""
    End Sub

    Private Function CLEANPHNO(ByVal PHONE As String) As String
        Dim PHNO As String = PHONE.Replace("-", "")
        Return PHNO
    End Function

    Private Sub btnNega_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNega.Click
        If lstPhone.SelectedItems.Count = 0 Then Exit Sub

        lstPhone.Items.Remove(lstPhone.SelectedItem)

        For Each Item As Object In lstPhone.SelectedItems
            Remove_Phone(Item.ToString)
        Next

    End Sub

    'Private Sub btnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTest.Click
    '    '  AddCustomer()
    '    ''Console.WriteLine("Saved")
    '    ' ModifyInfo()

    '    'Console.WriteLine("In the Collection:")
    '    'For Each ph As PhoneNumber In CustomerPhones
    '    '    Console.WriteLine(ph.PhoneNumber & " - " & ph.isPrimary)
    '    'Next
    '    'For Each id As IdentificationCard In CustomerIDs
    '    '    Console.WriteLine(String.Format("{0} >> {1} - {2}", id.IDType, id.IDNumber, id.isPrimary))
    '    'Next
    'End Sub

    Private Sub ModifyInfo()
        'Search Name
        Dim Eskie As New Customer
        Eskie.FindCustomerByName("Eskie")
        Eskie.Load_CustomerByID()

        Console.WriteLine(String.Format("{0} {1} is loaded.", Eskie.FirstName, Eskie.LastName))
        Dim newCP As New PhoneNumber
        newCP.PhoneNumber = "09226847559"
        newCP.CustomerID = Eskie.CustomerID
        newCP.SetPrimary()

        Eskie.CustomersPhone.Add(newCP)
        'EDIT
        Eskie.CustomersPhone.byID(2).PhoneNumber = "SUNCHANGE"

        Eskie.Save()

        For Each cp As PhoneNumber In Eskie.CustomersPhone
            Console.WriteLine("CP: " & cp.PhoneNumber)
        Next

    End Sub

    Private Sub AddCustomer()
        Dim test As New Customer
        test.FirstName = "Eskie"
        test.LastName = "Maquilang"
        test.PresentBarangay = "Lagao"
        test.PresentCity = "GSC"
        test.PresentProvince = "South Cotabato"
        test.PermanentBarangay = "Lagao"
        test.PermanentCity = "GSC"
        test.PermanentProvince = "South Cotabato"
        test.Nationality = "Filipino"
        test.Sex = Customer.Gender.Male
        test.NatureOfWork = "IT"
        test.SourceOfFund = "WORK"

        Dim compID As New NewIdentificationCard
        Dim globePlan As New PhoneNumber
        Dim sunPlan As New PhoneNumber

        compID.IDType = "Passport"
        compID.IDNumber = "PR 48194"
        compID.SetPrimary()

        globePlan.PhoneNumber = "09171263481"
        sunPlan.PhoneNumber = "09257977559"
        sunPlan.SetPrimary()

        Dim EskieIDs As New Collections_ID
        EskieIDs.Add(compID)

        Dim EskiePhones As New Collections_Phone
        EskiePhones.Add(globePlan)
        EskiePhones.Add(sunPlan)

        test.CustomersIDs = EskieIDs
        test.CustomersPhone = EskiePhones

        test.Save()
    End Sub

    Private Sub lblTheSame_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblTheSame.DoubleClick
        txtSt2.Text = txtSt1.Text
        cboBrgy2.Text = cboBrgy1.Text
        cboCity2.Text = cboCity1.Text
        cboProv2.Text = cboProv1.Text
        cboZip2.Text = cboZip1.Text
    End Sub

    Private Sub load_Customer(ByVal cl As Customer)
        ClearFields()
        txtFName.Text = cl.FirstName
        txtMName.Text = cl.MiddleName
        txtLName.Text = cl.LastName
        txtSuffix.Text = cl.Suffix

        txtSt1.Text = cl.PresentStreet
        cboBrgy1.Text = cl.PresentBarangay
    End Sub

    Enum FormRule As Integer
        ViewEntry = 0
        NewEntry = 1
        EditEntry = 2
    End Enum
    Public Overloads Function ShowDialog(ByVal returnValue As String, ByVal arr As Customer, ByVal frmType As FormRule) As DialogResult
        load_Customer(arr)

        Me.ShowDialog()
        If frmType = FormRule.ViewEntry Then _
            returnValue = "OK"

        Return Me.DialogResult
    End Function

    Private Sub btnSetPri_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetPri.Click
        If lstPhone.SelectedItems.Count = 0 Then Exit Sub
        Dim primaryNumber As String = lstPhone.SelectedItems.Item(0)
        Dim priIdx As Integer = lstPhone.SelectedIndex
        Dim idx As Integer = 0
        Dim ModifyStr As String = ""

        For Each str As String In lstPhone.Items
            If str.Contains("[P]") Then
                ModifyStr = str.Replace("[P]", "")
                idx = lstPhone.Items.IndexOf(str)
            End If
        Next

        If ModifyStr <> "" Then _
            lstPhone.Items(idx) = ModifyStr

        lstPhone.Items(priIdx) = primaryNumber & "[P]"
        SetPrimary_Phone(lstPhone.Items(priIdx))
    End Sub

    Private Sub txtPhone_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPhone.KeyPress
        PhoneSeparator(txtPhone, e)
        DigitOnly(e)

        If Asc(e.KeyChar) = 13 Then
            btnPlus.PerformClick()
        End If
    End Sub

#Region "Phone Collections"
    Private Sub AutoSetPrimary_Phone()
        For Each ph As PhoneNumber In CustomerPhones
            If ph.isPrimary Then
                Exit Sub
            End If
        Next

        CustomerPhones.Item(0).SetPrimary()
    End Sub

    Private Sub Add_Phone(ByVal num As String, Optional ByVal isPrimary As Boolean = False)
        If isPrimary Then clearPhonePrimary()
        num = removePriFunction(num)

        Dim newPhone As New PhoneNumber
        newPhone.PhoneNumber = num
        newPhone.isPrimary = isPrimary

        CustomerPhones.Add(newPhone)
    End Sub

    ' if not required, remove
    Private Sub Edit_Phone(ByVal origin As String, ByVal newnum As String, Optional ByVal isPrimary As Boolean = False)
        If isPrimary Then clearPhonePrimary()

        For Each ph As PhoneNumber In CustomerPhones
            If origin = ph.PhoneNumber Then
                ph.PhoneNumber = newnum
                ph.isPrimary = isPrimary
            End If
        Next
    End Sub

    Private Sub SetPrimary_Phone(ByVal num As String)
        num = removePriFunction(num)
        clearPhonePrimary()

        For Each ph As PhoneNumber In CustomerPhones
            If num = ph.PhoneNumber Then
                ph.isPrimary = True
            End If
        Next
    End Sub

    Private Sub Remove_Phone(ByVal num As String)
        num = removePriFunction(num)
        Dim idx As Integer = 0, found As Boolean = False

        For Each ph As PhoneNumber In CustomerPhones
            If num = ph.PhoneNumber Then
                found = True
                Exit For
            End If
            idx += 1
        Next

        If found Then CustomerPhones.Remove(idx)
    End Sub

    Private Sub clearPhonePrimary()
        For Each ph As PhoneNumber In CustomerPhones
            ph.isPrimary = False
        Next
    End Sub

    Private Function removePriFunction(ByVal str As String) As String
        Return str.Replace("[P]", "")
    End Function
#End Region

#Region "ID Collections"
    Private Sub AutoSetPrimary_IDs()
        For Each id As NewIdentificationCard In CustomerIDs
            If id.isPrimary Then
                Exit Sub
            End If
        Next

        CustomerIDs.Item(0).SetPrimary()
    End Sub

    Private Sub Add_ID(ByVal typ As String, ByVal refNum As String, Optional ByVal isPrimary As Boolean = False)
        Dim newID As New NewIdentificationCard
        newID.IDType = typ
        newID.IDNumber = refNum
        newID.isPrimary = isPrimary

        CustomerIDs.Add(newID)
    End Sub

    Private Sub SetPrimary_ID(ByVal index As Integer)
        clearIDPrimary()
        CustomerIDs.Item(index).isPrimary = True
    End Sub

    Private Sub Remove_ID(ByVal index As Integer)
        CustomerIDs.Remove(index)
    End Sub

    Private Sub clearIDPrimary()
        For Each nopri As NewIdentificationCard In CustomerIDs
            nopri.isPrimary = False
        Next
    End Sub
#End Region

    Private Sub Populate()
        Dim type As String() = {"PASSPORT", "DRIVER", "VOTERS"}
        Dim number() As String = {"NUMBER1", "NUMBER2", "NUMBER3", "NUMBER4", "NUMBER5"}

        For cnt As Integer = 0 To number.Count - 1
            Dim tmpID As New NewIdentificationCard
            tmpID.IDType = type(rndInt(0, 2))
            tmpID.IDNumber = number(cnt)
            CustomerIDs.Add(tmpID)

            Dim lv As ListViewItem = lvID.Items.Add(tmpID.IDType)
            lv.SubItems.Add(tmpID.IDNumber)
        Next
    End Sub

    Private Function rndInt(ByVal min As Integer, ByVal max As Integer) As Integer
        Return CInt(Math.Ceiling(Rnd() * max)) + min
    End Function

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim lv As ListViewItem = lvID.Items.Add(cboType.Text)
        lv.SubItems.Add(txtIDNum.Text)

        Add_ID(cboType.Text, txtIDNum.Text)

        cboType.SelectedIndex = 0
        txtIDNum.Text = ""
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If lvID.SelectedItems.Count = 0 Then Exit Sub
        Dim idx As Integer = lvID.FocusedItem.Index

        lvID.FocusedItem.Remove()
        Remove_ID(idx)
    End Sub

    Private Sub btnPrimary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrimary.Click
        If lvID.SelectedItems.Count = 0 Then Exit Sub
        Dim idx As Integer = lvID.FocusedItem.Index

        For Each lv As ListViewItem In lvID.Items
            lv.BackColor = Nothing
        Next

        SetPrimary_ID(idx)
        lvID.FocusedItem.BackColor = Color.ForestGreen
    End Sub

    Private Sub btnCamera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCamera.Click
        If ClientImage.Image Is Nothing Then
            GoTo nextLineTODO
        Else
            Dim result As DialogResult = MsgBox("Do you want capture again or change the picture?", MsgBoxStyle.YesNo, "Validation")
            If result = vbNo Then
                Exit Sub
            End If
        End If

nextLineTODO:
        If btnCamera.Text = "Open Camera" Then
            Call OpenPreviewWindow()
            btnCamera.Text = "Capture"
            ClientImage.Image = Nothing
        ElseIf btnCamera.Text = "Capture" Then
            Dim Data As IDataObject
            Dim Bmap As Image
            SendMessage(hHwnd, WM_Cap_EDIT_COPY, 0, 0)
            Data = Clipboard.GetDataObject()
            If Data.GetDataPresent(GetType(System.Drawing.Bitmap)) Then
                Bmap = CType(Data.GetData(GetType(System.Drawing.Bitmap)), Image)
                ClientImage.Image = Bmap
                Call ClosePreviewWindow()
            End If
            btnCamera.Text = "Open Camera"

            notNewPic = False : FlName = FileName()
            Call ClosePreviewWindow()
        End If
    End Sub
  

    Private Sub ELLIEPOPULATEINFO()

        txtFName.Text = "ELLIE"
        txtMName.Text = "ARDIENTE"
        txtLName.Text = "MISIONA"
        txtSt1.Text = "LABOS"
        cboBrgy1.Text = "CITY HEIGHTS"
        cboCity1.Text = "GENSAN"
        cboProv1.Text = "SOUTH COT."
        cboZip1.Text = "9500"

        txtSt2.Text = "LABOS"
        cboBrgy2.Text = "CITY HEIGHTS"
        cboCity2.Text = "GENSAN"
        cboProv2.Text = "SOUTH COT."
        cboZip2.Text = "9500"
        dtpBday.Text = "12/11/1992"
        txtWork.Text = "PROGRAMMER"
        txtSrcFund.Text = "WORK"
        cboGender.Text = "MALE"
        txtBdayPlace.Text = "Davao Del Sur"
    End Sub

    Private Sub btnHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHistory.Click
        If Not txtFName.Enabled Then Exit Sub

        Dim mySql As String
        mySql = "SELECT C.ID, C.FIRSTNAME || ' ' || C.LASTNAME || ' ' || "
        mySql &= "CASE WHEN C.SUFFIX is Null THEN '' ELSE C.SUFFIX END AS FULLNAME, "
        mySql &= "C.STREET1 || ' ' || C.BRGY1 || ' ' || C.CITY1 || ' ' ||  C.PROVINCE1 AS ADDRESS, "
        mySql &= "C.BIRTHDAY,"
        mySql &= "(SELECT (CASE WHEN (CHAR_LENGTH(PH.PHONENUMBER)=11)AND PH.ISPRIMARY = 1	"
        mySql &= "	THEN PH.PHONENUMBER WHEN (CHAR_LENGTH(PH.PHONENUMBER)=11) THEN PH.PHONENUMBER	"
        mySql &= "	ELSE NULL END)AS CONTACTNUMBER FROM KYC_PHONE PH LEFT JOIN KYC_CUSTOMERS CC ON CC.ID = PH.CUSTID "
        mySql &= "	WHERE CHAR_LENGTH(PH.PHONENUMBER)='11' AND PH.ISPRIMARY = 1	"
        mySql &= "	OR CHAR_LENGTH(PH.PHONENUMBER)=11 AND PH.CUSTID =CC.ID ORDER BY PH.ISPRIMARY DESC ROWS 1),	"
        mySql &= "P.PAWNTICKET, CASE P.STATUS	WHEN '0' THEN 'RENEWED' "
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
        mySql &= "LEFT JOIN " & CUSTOMER_TABLE & " C ON P.CLIENTID = C.ID "
        mySql &= "INNER JOIN OPI ITM ON ITM.PAWNITEMID = P.PAWNITEMID "
        mySql &= "INNER JOIN TBLITEM CLASS ON CLASS.ITEMID = ITM.ITEMID "
        mySql &= "LEFT JOIN TBL_GAMIT USR ON USR.USERID = P.APPRAISERID "
        mySql &= vbCrLf & "WHERE "
        mySql &= vbCrLf & " P.STATUS <> 'V' AND P.CLIENTID = " & SelectedCustomer.CustomerID

        Console.WriteLine(mySql)

        Dim repPara As New Dictionary(Of String, String)
        repPara.Add("txtFullname", String.Format("{0} {1} {2}", txtFName.Text, txtLName.Text, txtSuffix.Text))
        repPara.Add("txtBirthday", dtpBday.Text)
        repPara.Add("txtAddr", String.Format("{0} {1} {2} {3}", txtSt1.Text, cboBrgy1.Text, cboCity1.Text, cboProv1.Text))

        Dim TXT As New TextBox
        For Each Item As Object In lstPhone.Items
            TXT.AppendText(Item.ToString & "/")
        Next

        repPara.Add("txtContact", TXT.Text.TrimEnd("/", "/"))

        frmReport.ReportInit(mySql, "dsHistory", "Reports\rpt_History.rdlc", repPara)
        frmReport.Show()
        frmReport.TopMost = True
    End Sub

  
End Class