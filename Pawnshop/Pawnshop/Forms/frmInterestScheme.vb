Public Class frmInterestScheme
    Dim SelectedScheme As InterestScheme

    Dim SchemeModify As New InterestScheme

    Friend Sub LoadSchemeList(ByVal sc As InterestScheme)
        If sc.SchemeName = "" Then Exit Sub

        ' Dim id As Integer = sc.SchemeID
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
        If lvIntScheme.Items.Count <= 0 Then Exit Sub

        Dim ans As DialogResult = MsgBox("Do you want to save this transaction?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        If ans = Windows.Forms.DialogResult.No Then Exit Sub


        Dim SchemeSave As New InterestScheme
        Dim IntSchemeLines As New IntScheme_Lines

        With SchemeSave
            .SchemeName = txtSchemeName.Text
            .Description = txtDescription.Text
        End With


        For Each item As ListViewItem In lvIntScheme.Items
            Dim SchemeInterest As New Scheme_Interest
            With SchemeInterest
                .DayFrom = item.SubItems(0).Text
                .DayTo = item.SubItems(1).Text
                .Interest = item.SubItems(2).Text
                .Penalty = item.SubItems(3).Text
                .Remarks = item.SubItems(4).Text
            End With
            IntSchemeLines.Add(SchemeInterest)
        Next

        SchemeSave.SchemeDetails = IntSchemeLines
        SchemeSave.SaveScheme()

        MsgBox("Transaction Saved", MsgBoxStyle.Information)
        clearfields()
        lvIntScheme.Items.Clear()
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

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmInterestScheme_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clearfields()
        txtSchemeName.Text = ""
        txtDescription.Text = ""
        txtSearch.Text = ""
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If txtSchemeName.Text = "" Then txtSchemeName.Focus()
        If txtDescription.Text = "" Then txtDescription.Focus()
        If lvIntScheme.Items.Count <= 0 Then Exit Sub

        If btnUpdate.Text = "&Update".ToString Then
            btnUpdate.Text = "&Modify".ToString
            reaDOnlyFalse()
            txtSchemeName.Enabled = True
            txtDescription.Enabled = True
            Exit Sub
        End If

        Dim ans As DialogResult = MsgBox("Do you want to Update this transaction?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        If ans = Windows.Forms.DialogResult.No Then Exit Sub


        Dim IntSchemeLines As New IntScheme_Lines
        SchemeModify.SchemeID = frmInterestSchemeList.lblSchemeID.Text

        SchemeModify.SchemeName = txtSchemeName.Text
        SchemeModify.Description = txtDescription.Text
        SchemeModify.Update()

        For Each item As ListViewItem In lvIntScheme.Items
            Dim SchemeInterest As New Scheme_Interest
            SchemeInterest.schemeInterestID = frmInterestSchemeList.lblSchemeID.Text

            With SchemeInterest
                .DayFrom = item.SubItems(0).Text
                .DayTo = item.SubItems(1).Text
                .Interest = item.SubItems(2).Text
                .Penalty = item.SubItems(3).Text
                .Remarks = item.SubItems(4).Text
            End With

            SchemeInterest.Update()
        Next

        MsgBox("Transaction Updated", MsgBoxStyle.Information)
        btnSave.Enabled = True
        clearfields()
        lvIntScheme.Items.Clear()
        txtSchemeName.Text = ""
        txtDescription.Text = ""

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If Not isValid() Then Exit Sub

        Dim List1 As ListViewItem
        List1 = Me.lvIntScheme.Items.Add(Me.txtDayFrom.Text)
        List1.SubItems.Add(Me.txtDayTo.Text)
        List1.SubItems.Add(Me.txtInterest.Text)
        List1.SubItems.Add(Me.txtPenalty.Text)
        List1.SubItems.Add(Me.txtRemarks.Text)
        clearfields()
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

  
    Private Sub txtRemarks_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRemarks.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnAdd.PerformClick()
        End If
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If lvIntScheme.SelectedItems.Count <= 0 Then Exit Sub
        lvIntScheme.Items.RemoveAt(lvIntScheme.SelectedIndices(0))
        For Each item As ListViewItem In lvIntScheme.SelectedItems
            item.Remove()
        Next
    End Sub

   
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        'Dim secured_str As String = txtSearch.Text
        'secured_str = DreadKnight(secured_str)

        'frmItemList.Show()

        'frmItemList.txtSearch.Text = Me.txtSearch.Text.ToString
        'frmItemList.btnSearch.PerformClick()

        'btnUpdate.Text = "&Update".ToString
        'btnUpdate.Enabled = True
        'txtSearch.Clear()
        'lvIntScheme.Items.Clear()
        'txtDescription.Clear()
        'txtSchemeName.Clear()

        Dim secured_str As String = txtSearch.Text
        secured_str = DreadKnight(secured_str)

        frmInterestSchemeList.Show()

        frmInterestSchemeList.txtSearch.Text = Me.txtSearch.Text.ToString
        frmInterestSchemeList.btnSearch.PerformClick()

        btnUpdate.Text = "&Update".ToString
        btnUpdate.Enabled = True
        lvIntScheme.Items.Clear()
        txtDescription.Clear()
        txtSchemeName.Clear()

    End Sub

    Private Sub lvIntScheme_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvIntScheme.DoubleClick
        With lvIntScheme
            txtDayFrom.Text = .SelectedItems(0).Text
            txtDayTo.Text = .SelectedItems(0).SubItems(1).Text
            txtInterest.Text = .SelectedItems(0).SubItems(2).Text
            txtPenalty.Text = .SelectedItems(0).SubItems(3).Text
            txtRemarks.Text = .SelectedItems(0).SubItems(4).Text
        End With
    End Sub

    Private Sub txtSearch_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()
        End If
    End Sub
End Class