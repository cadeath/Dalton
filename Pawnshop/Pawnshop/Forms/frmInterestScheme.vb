
Public Class frmInterestScheme
    Dim SelectedScheme As InterestScheme

    Dim SchemeModify As New InterestScheme

    Friend Sub LoadSchemeList(ByVal sc As InterestScheme)
        If sc.SchemeName = "" Then Exit Sub

        txtSchemeName.Text = sc.SchemeName
        txtDescription.Text = sc.Description

        SelectedScheme = sc

        reaDOnlyTrue()
        btnSave.Enabled = False
        btnUpdate.Enabled = True
        txtSchemeName.Enabled = False
        txtDescription.Enabled = False
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtSchemeName.Text = "" Then txtSchemeName.Focus()
        If txtDescription.Text = "" Then txtDescription.Focus()
        If lvIntscheme.Items.Count <= 0 Then Exit Sub

        Dim ans As DialogResult = MsgBox("Do you want to save this transaction?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        If ans = Windows.Forms.DialogResult.No Then Exit Sub


        Dim SchemeSave As New InterestScheme
        Dim IntSchemeLines As New IntScheme_Lines

        With SchemeSave
            .SchemeName = txtSchemeName.Text
            .Description = txtDescription.Text
        End With


        For Each item As ListViewItem In lvIntscheme.Items
            Dim SchemeInterest As New Scheme_Interest
            With SchemeInterest
                .DayFrom = item.SubItems(1).Text
                .DayTo = item.SubItems(2).Text
                .Interest = item.SubItems(3).Text
                .Penalty = item.SubItems(4).Text
                .Remarks = item.SubItems(5).Text
            End With
            IntSchemeLines.Add(SchemeInterest)
        Next

        SchemeSave.SchemeDetails = IntSchemeLines
        SchemeSave.SaveScheme()

        MsgBox("Transaction Saved", MsgBoxStyle.Information)
        clearfields()
        lvIntscheme.Items.Clear()
        txtSchemeName.Text = ""
        txtDescription.Text = ""
    End Sub



    Friend Sub clearfields()
        txtDayFrom.Text = ""
        txtDayTo.Text = ""
        txtInterest.Text = ""
        txtPenalty.Text = ""
        txtRemarks.Text = ""
    End Sub

    Private Sub reaDOnlyTrue()
        txtDayFrom.ReadOnly = True
        txtDayTo.ReadOnly = True
        txtInterest.ReadOnly = True
        txtPenalty.ReadOnly = True
        txtRemarks.ReadOnly = True
    End Sub

    Friend Sub reaDOnlyFalse()
        txtDayFrom.ReadOnly = False
        txtDayTo.ReadOnly = False
        txtInterest.ReadOnly = False
        txtPenalty.ReadOnly = False
        txtRemarks.ReadOnly = False
    End Sub

    Private Function isValid() As Boolean

        If txtDayFrom.Text = "" Then txtDayFrom.Focus() : Return False
        If txtDayTo.Text = "" Then txtDayTo.Focus() : Return False
        If txtInterest.Text = "" Then txtInterest.Focus() : Return False
        If txtPenalty.Text = "" Then txtPenalty.Focus() : Return False
        If txtRemarks.Text = "" Then txtRemarks.Focus() : Return False

        Return True
    End Function


    Private Sub txtDayTo_KeyPress_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDayTo.KeyPress
        DigitOnly(e)
    End Sub

    'Private Sub txtRemarks_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRemarks.KeyDown
    '    If e.KeyCode = Keys.Enter Then
    '        If Label9.Text = "Update".ToString Then
    '            btnAdd.PerformClick()
    '        ElseIf Label9.Text = "Modify" Then
    '            btnUpdateScheme.PerformClick()
    '        End If
    '    End If
    'End Sub

    'Private Sub txtInterest_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtInterest.KeyPress
    '    DigitOnly(e)
    'End Sub

    'Private Sub txtPenalty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPenalty.KeyPress
    '    DigitOnly(e)
    'End Sub

    Private Sub txtSearch_KeyDown_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()
        End If
    End Sub

    

        'Private Sub frmInterestScheme_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '    clearfields()
        '    lvIntscheme.Items.Clear()
        '    txtSchemeName.Text = ""
        '    txtDescription.Text = ""
        'End Sub

    End Sub
    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If txtSchemeName.Text = "" Then txtSchemeName.Focus()
        If txtDescription.Text = "" Then txtDescription.Focus()
        If lvIntscheme.Items.Count <= 0 Then Exit Sub

        If btnUpdate.Text = "&Update".ToString Then
            btnUpdate.Text = "&Modify".ToString
            reaDOnlyFalse()

            txtSchemeName.Enabled = True
            txtDescription.Enabled = True
            Exit Sub
        End If

        Dim ans As DialogResult = MsgBox("Do you want to Update this Scheme?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        If ans = Windows.Forms.DialogResult.No Then Exit Sub


        Dim IntSchemeLines As New IntScheme_Lines
        SchemeModify.SchemeID = frmInterestSchemeList.lblSchemeID.Text

        SchemeModify.SchemeName = txtSchemeName.Text
        SchemeModify.Description = txtDescription.Text
        SchemeModify.Update()

        For Each item As ListViewItem In lvIntscheme.Items
            Dim SchemeInterest As New Scheme_Interest

            With SchemeInterest
                .schemeInterestID = item.Text
                .DayFrom = item.SubItems(1).Text
                .DayTo = item.SubItems(2).Text
                .Interest = item.SubItems(3).Text
                .Penalty = item.SubItems(4).Text
                .Remarks = item.SubItems(5).Text


                SchemeInterest.schemeInterestID = .SchemeID
                SchemeInterest.SchemeID = SchemeModify.SchemeID
            End With
            SchemeInterest.Update()
        Next

        MsgBox("Scheme Updated", MsgBoxStyle.Information)

        btnSave.Enabled = True
        clearfields()
        lvIntscheme.Items.Clear()
        txtSchemeName.Text = ""
        txtDescription.Text = ""
        btnAdd.Enabled = True

    End Sub

    Private Sub btnClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnAdd_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If Not isValid() Then Exit Sub

        Dim List1 As ListViewItem
        List1 = Me.lvIntscheme.Items.Add(0)
        List1.SubItems.Add(Me.txtDayFrom.Text)
        List1.SubItems.Add(Me.txtDayTo.Text)
        List1.SubItems.Add(Me.txtInterest.Text)
        List1.SubItems.Add(Me.txtPenalty.Text)
        List1.SubItems.Add(Me.txtRemarks.Text)
        clearfields()
    End Sub




    Private Sub btnUpdateScheme_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateScheme.Click
        If Not isValid() Then Exit Sub
        lvIntscheme.SelectedItems(0).SubItems(1).Text = txtDayFrom.Text
        lvIntscheme.SelectedItems(0).SubItems(2).Text = txtDayTo.Text
        lvIntscheme.SelectedItems(0).SubItems(3).Text = txtInterest.Text
        lvIntscheme.SelectedItems(0).SubItems(4).Text = txtPenalty.Text
        lvIntscheme.SelectedItems(0).SubItems(5).Text = txtRemarks.Text
        clearfields()
        Label9.Text = "Update"
        btnAdd.Enabled = True
    End Sub



    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If lvIntscheme.SelectedItems.Count <= 0 Then Exit Sub
        lvIntscheme.Items.RemoveAt(lvIntscheme.SelectedIndices(0))
        For Each item As ListViewItem In lvIntscheme.SelectedItems
            item.Remove()
        Next
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim secured_str As String = txtSearch.Text
        secured_str = DreadKnight(secured_str)

        frmInterestSchemeList.Show()

        frmInterestSchemeList.txtSearch.Text = Me.txtSearch.Text.ToString
        frmInterestSchemeList.btnSearch.PerformClick()

        btnUpdate.Text = "&Update".ToString
        btnUpdate.Enabled = True
        lvIntscheme.Items.Clear()
        txtDescription.Clear()
        txtSchemeName.Clear()
        clearfields()
    End Sub

    Private Sub lvIntscheme_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvIntscheme.DoubleClick
        With lvIntscheme
            txtDayFrom.Text = .SelectedItems(0).SubItems(1).Text
            txtDayTo.Text = .SelectedItems(0).SubItems(2).Text
            txtInterest.Text = .SelectedItems(0).SubItems(3).Text
            txtPenalty.Text = .SelectedItems(0).SubItems(4).Text
            txtRemarks.Text = .SelectedItems(0).SubItems(5).Text
        End With
        Label9.Text = "Modify"
        btnAdd.Enabled = False
    End Sub

    Private Sub btnUpdateScheme_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateScheme.Click
        If Not isValid() Then Exit Sub
        lvIntscheme.SelectedItems(0).SubItems(1).Text = txtDayFrom.Text
        lvIntscheme.SelectedItems(0).SubItems(2).Text = txtDayTo.Text
        lvIntscheme.SelectedItems(0).SubItems(3).Text = txtInterest.Text
        lvIntscheme.SelectedItems(0).SubItems(4).Text = txtPenalty.Text
        lvIntscheme.SelectedItems(0).SubItems(5).Text = txtRemarks.Text
        clearfields()
        Label9.Text = "Update"
    End Sub


    Private Sub txtDayFrom_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDayFrom.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub txtDayTo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDayTo.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub txtInterest_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtInterest.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub txtPenalty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPenalty.KeyPress
        DigitOnly(e)
    End Sub


    Private Sub frmInterestScheme_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clearfields()
        txtSchemeName.Text = ""
        txtDescription.Text = ""
        txtSearch.Text = ""
        btnUpdate.Enabled = False


        'lvIntscheme.Columns.Item(0).Width = 0
        'lvIntscheme.Columns.Remove(lvIntscheme.Columns(0))
    End Sub


    Private Sub txtRemarks_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRemarks.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Label9.Text = "Update".ToString Then
                btnAdd.PerformClick()
            ElseIf Label9.Text = "Modify" Then
                btnUpdateScheme.PerformClick()
            End If
        End If
    End Sub

End Class