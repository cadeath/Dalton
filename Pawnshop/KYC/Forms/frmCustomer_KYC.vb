Public Class frmCustomer

    Friend ALLOW_MINORS As Boolean = True

    Const BLOCK_AGE As Integer = 7
    Const NOT_MINOR As Integer = 18

    Friend REQUIRED_ID As Boolean = False
    Private CustomerPhones As New Collections_Phone
    Private CustomerIDs As New Collections_ID

    Private Sub frmCustomer_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CACHE_MANAGEMENT()
        ClearFields()

        Populate()
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Function FormVerification() As Boolean
        Dim errMsg As String = "Please fillup the form completely"

        ' AGE VALIDATION ============================================
        Dim possible_age As Integer = (Now.Year - dtpBday.Value.Year)

        If ALLOW_MINORS Then
            If possible_age <= BLOCK_AGE Then
                Console.WriteLine("TOO YOUNG")
                Return False
            End If
        Else
            If possible_age < NOT_MINOR Then
                Console.WriteLine("NO MINOR IS ALLOWED")
                Return False
            End If
        End If
        ' END - AGE VALIDATION ======================================

        If Trim(txtFName.Text) = "" Or Trim(txtLName.Text) = "" Then
            MsgBox(errMsg, MsgBoxStyle.OkOnly, "KYC - Customer Information")
            Return False
        End If

        If Trim(cboBrgy1.Text) = "" Or Trim(cboCity1.Text) = "" Or Trim(cboProv1.Text) = "" Then
            MsgBox(errMsg, MsgBoxStyle.OkOnly, "KYC - Customer Information")
            Return False
        End If

        If Trim(cboBrgy2.Text) = "" Or Trim(cboCity2.Text) = "" Or Trim(cboProv2.Text) = "" Then
            MsgBox(errMsg, MsgBoxStyle.OkOnly, "KYC - Customer Information")
            Return False
        End If

        If Trim(txtNationality.Text) = "" Then
            MsgBox(errMsg, MsgBoxStyle.OkOnly, "KYC - Customer Information")
            Return False
        End If

        If Trim(txtWork.Text) = "" Or Trim(txtSrcFund.Text) = "" Then
            MsgBox(errMsg, MsgBoxStyle.OkOnly, "KYC - Customer Information")
            Return False
        End If

        If lvID.Items.Count = 0 And REQUIRED_ID Then
            MsgBox(errMsg, MsgBoxStyle.OkOnly, "KYC - Customer Information")
            Return False
        End If

        Return True
    End Function

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If Not FormVerification() Then Exit Sub

        Dim NewCustomer As New Customer
        With NewCustomer
            .FirstName = txtFName.Text
            .MiddleName = txtMName.Text
            .LastName = txtLName.Text

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

            AutoSetPrimary_Phone() 'If no PRIMARY for PHONE

            .CustomersPhone = CustomerPhones
            .CustomersIDs = CustomerIDs
            .Save()

        End With
    End Sub

    Private Sub ClearFields()
        txtFName.Text = ""
        txtMName.Text = ""
        txtLName.Text = ""

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
    End Sub

    ' TODO: JUNMAR
    ' Please provide phone number verification
    ' You might copy it in our existing client
    ' management module.
    Private Sub btnPlus_Click(sender As System.Object, e As System.EventArgs) Handles btnPlus.Click
        If txtPhone.Text = "" Then Exit Sub

        Add_Phone(txtPhone.Text)
        lstPhone.Items.Add(txtPhone.Text)
        txtPhone.Text = ""
    End Sub

    Private Sub btnNega_Click(sender As System.Object, e As System.EventArgs) Handles btnNega.Click
        lstPhone.Items.Remove(lstPhone.SelectedItem)
        Remove_Phone(lstPhone.SelectedItem)
    End Sub

    Private Sub btnTest_Click(sender As System.Object, e As System.EventArgs) Handles btnTest.Click
        'AddCustomer()
        'Console.WriteLine("Saved")
        'ModifyInfo()

        Console.WriteLine("In the Collection:")
        'For Each ph As PhoneNumber In CustomerPhones
        '    Console.WriteLine(ph.PhoneNumber & " - " & ph.isPrimary)
        'Next
        For Each id As IdentificationCard In CustomerIDs
            Console.WriteLine(String.Format("{0} >> {1} - {2}", id.IDType, id.IDNumber, id.isPrimary))
        Next
    End Sub

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

        Dim compID As New IdentificationCard
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

    Private Sub lblTheSame_DoubleClick(sender As Object, e As System.EventArgs) Handles lblTheSame.DoubleClick
        txtSt2.Text = txtSt1.Text
        cboBrgy2.Text = cboBrgy1.Text
        cboCity2.Text = cboCity1.Text
        cboProv2.Text = cboProv2.Text
        cboZip2.Text = cboZip1.Text
    End Sub

    Private Sub load_Customer(cl As Customer)
        ClearFields()
        txtFName.Text = cl.FirstName
        txtMName.Text = cl.MiddleName
        txtLName.Text = cl.LastName

        txtSt1.Text = cl.PresentStreet
        cboBrgy1.Text = cl.PresentBarangay
    End Sub

    Enum FormRule As Integer
        ViewEntry = 0
        NewEntry = 1
        EditEntry = 2
    End Enum
    Public Overloads Function ShowDialog(ByVal returnValue As String, ByVal arr As Customer, frmType As FormRule) As DialogResult
        load_Customer(arr)

        Me.ShowDialog()
        If frmType = FormRule.ViewEntry Then _
            returnValue = "OK"

        Return Me.DialogResult
    End Function

    Private Sub btnSetPri_Click(sender As System.Object, e As System.EventArgs) Handles btnSetPri.Click
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

    Private Sub txtPhone_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPhone.KeyPress
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

    Private Sub Add_Phone(num As String, Optional isPrimary As Boolean = False)
        If isPrimary Then clearPhonePrimary()
        num = removePriFunction(num)

        Dim newPhone As New PhoneNumber
        newPhone.PhoneNumber = num
        newPhone.isPrimary = isPrimary

        CustomerPhones.Add(newPhone)
    End Sub

    ' if not required, remove
    Private Sub Edit_Phone(origin As String, newnum As String, Optional isPrimary As Boolean = False)
        If isPrimary Then clearPhonePrimary()

        For Each ph As PhoneNumber In CustomerPhones
            If origin = ph.PhoneNumber Then
                ph.PhoneNumber = newnum
                ph.isPrimary = isPrimary
            End If
        Next
    End Sub

    Private Sub SetPrimary_Phone(num As String)
        num = removePriFunction(num)
        clearPhonePrimary()

        For Each ph As PhoneNumber In CustomerPhones
            If num = ph.PhoneNumber Then
                ph.isPrimary = True
            End If
        Next
    End Sub

    Private Sub Remove_Phone(num As String)
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

    Private Function removePriFunction(str As String) As String
        Return str.Replace("[P]", "")
    End Function
#End Region

#Region "ID Collections"
    Private Sub AutoSetPrimary_IDs()
        For Each id As IdentificationCard In CustomerIDs
            If id.isPrimary Then
                Exit Sub
            End If
        Next

        CustomerIDs.Item(0).SetPrimary()
    End Sub

    Private Sub Add_ID(typ As String, refNum As String, Optional isPrimary As Boolean = False)
        Dim newID As New IdentificationCard
        newID.IDType = typ
        newID.IDNumber = refNum
        newID.isPrimary = isPrimary

        CustomerIDs.Add(newID)
    End Sub

    Private Sub SetPrimary_ID(index As Integer)
        clearIDPrimary()
        CustomerIDs.Item(index).isPrimary = True
    End Sub

    Private Sub Remove_ID(index As Integer)
        CustomerIDs.Remove(index)
    End Sub

    Private Sub clearIDPrimary()
        For Each nopri As IdentificationCard In CustomerIDs
            nopri.isPrimary = False
        Next
    End Sub
#End Region

    Private Sub Populate()
        Dim type As String() = {"PASSPORT", "DRIVER", "VOTERS"}
        Dim number() As String = {"NUMBER1", "NUMBER2", "NUMBER3", "NUMBER4", "NUMBER5"}

        For cnt As Integer = 0 To number.Count - 1
            Dim tmpID As New IdentificationCard
            tmpID.IDType = type(rndInt(0, 2))
            tmpID.IDNumber = number(cnt)
            CustomerIDs.Add(tmpID)

            Dim lv As ListViewItem = lvID.Items.Add(tmpID.IDType)
            lv.SubItems.Add(tmpID.IDNumber)
        Next
    End Sub

    Private Function rndInt(min As Integer, max As Integer) As Integer
        Return CInt(Math.Ceiling(Rnd() * max)) + min
    End Function

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        Dim lv As ListViewItem = lvID.Items.Add(cboType.Text)
        lv.SubItems.Add(txtIDNum.Text)

        Add_ID(cboType.Text, txtIDNum.Text)

        cboType.SelectedIndex = 0
        txtIDNum.Text = ""
    End Sub

    Private Sub btnRemove_Click(sender As System.Object, e As System.EventArgs) Handles btnRemove.Click
        If lvID.SelectedItems.Count = 0 Then Exit Sub
        Dim idx As Integer = lvID.FocusedItem.Index

        lvID.FocusedItem.Remove()
        Remove_ID(idx)
    End Sub
End Class