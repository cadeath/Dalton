' Changelog
' v1.1 10/20/2015
'  - ComputerBirthday Added
'  - LockFields
Public Class frmClientInformation

    Private lockForm As Boolean = False

    Private Sub frmClientInformation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearFields()
        txtFirstName.Focus()

        If isReady() Then
            Console.WriteLine("Database connected")
        End If

        Populate()
    End Sub

    Private Sub Populate()
        txtFirstName.Text = "Eskie Cirrus James"
        txtMiddleName.Text = "Dingal"
        txtLastName.Text = "Maquilang"

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
        Dim tmpClient As New Client
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

            '.Save()
        End With

        database.SaveEntry(tmpClient.DataSet)
        MsgBox("Entry Saved", MsgBoxStyle.Information)
    End Sub

    Private Sub txtCP1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCP1.TextChanged

    End Sub

    Private Sub txtFirstName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFirstName.TextChanged

    End Sub

    Private Sub lvID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvID.SelectedIndexChanged

    End Sub
End Class