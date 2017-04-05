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
End Class