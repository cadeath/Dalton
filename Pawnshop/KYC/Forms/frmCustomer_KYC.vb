Public Class frmCustomer

    Friend ALLOW_MINORS As Boolean = True

    Const BLOCK_AGE As Integer = 7
    Const NOT_MINOR As Integer = 18

    Private Sub frmCustomer_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ClearFields()
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Dim possible_age As Integer = (Now.Year - dtpBday.Value.Year)

        Console.WriteLine("AGE: " & possible_age)
        If ALLOW_MINORS Then
            If possible_age <= BLOCK_AGE Then
                Console.WriteLine("TOO YOUNG")
                Exit Sub
            End If
        Else
            If possible_age < NOT_MINOR Then
                Console.WriteLine("NO MINOR IS ALLOWED")
                Exit Sub
            End If
        End If

        Console.WriteLine("PASS")
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
        txtNationality.Text = ""
        cboGender.Text = "Female"
        txtSrcFund.Text = ""

        cboPhone.Items.Clear()
        rbLow.Checked = True

        'IDENTIFY
        cboType.SelectedIndex = 0
        txtIDNum.Text = ""
        lvID.Items.Clear()
    End Sub

    Private Sub btnPlus_Click(sender As System.Object, e As System.EventArgs) Handles btnPlus.Click
        If cboPhone.Text = "" Then Exit Sub

        cboPhone.Items.Add(cboPhone.Text)
        cboPhone.Text = ""
    End Sub

    Private Sub btnNega_Click(sender As System.Object, e As System.EventArgs) Handles btnNega.Click
        cboPhone.Items.Remove(cboPhone.SelectedItem)
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
        ' TODO:
        ' Load Customer Information in ReadOnly and Edit Ready Form
    End Sub

    Enum FormRule As Integer
        ViewEntry = 0
        NewEntry = 1
        EditEntry = 2
    End Enum
    Public Overloads Function ShowDialog(ByVal returnValue As String, ByVal arr As Customer, frmType As FormRule) As DialogResult
        'txtNewNumber.Text = IIf(arr(0).Contains("INV"), "", arr(0))
        'lblClient.Text = "Change Number for " & arr(1)

        load_Customer(arr)

        Me.ShowDialog()
        If frmType = FormRule.ViewEntry Then _
            returnValue = "OK"

        Return Me.DialogResult
    End Function
End Class