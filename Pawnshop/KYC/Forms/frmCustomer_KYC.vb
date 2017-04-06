Public Class frmCustomer

    Friend ALLOW_MINORS As Boolean = True

    Const BLOCK_AGE As Integer = 7
    Const NOT_MINOR As Integer = 18

    Friend REQUIRED_ID As Boolean = False

    Private CustomerPhones As Collections_Phone

    Private Sub frmCustomer_Click(sender As Object, e As System.EventArgs) Handles Me.Click

    End Sub

    Private Sub frmCustomer_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CACHE_MANAGEMENT()

        ClearFields()
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    ' TODO:
    ' Don't allow to continue if REQUIRED_ID is TRUE but no ID
    ' Unfill asterisk signs
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

        If Trim(txtFName.Text) = "" Then
            MsgBox(errMsg, MsgBoxStyle.OkOnly, "KYC - Customer Information")
            Return False
        End If

        If Trim(txtLName.Text) = "" Then
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

    Private Sub btnPlus_Click(sender As System.Object, e As System.EventArgs) Handles btnPlus.Click
        If txtPhone.Text = "" Then Exit Sub

        lstPhone.Items.Add(txtPhone.Text)
        txtPhone.Text = ""
    End Sub

    Private Sub btnNega_Click(sender As System.Object, e As System.EventArgs) Handles btnNega.Click
        lstPhone.Items.Remove(lstPhone.SelectedItem)
    End Sub

    Private Sub btnTest_Click(sender As System.Object, e As System.EventArgs) Handles btnTest.Click
        AddCustomer()
        Console.WriteLine("Saved")
        ModifyInfo()
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
        Dim str As String = lstPhone.SelectedItems.Item(0)
    End Sub
End Class