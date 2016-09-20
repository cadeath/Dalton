Public Class frmInterestScheme

  
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtSchemeName.Text = "" Then txtSchemeName.Focus()
        'If txtDescription.Text = "" Then txtDescription.Focus()
        'If lvIntScheme.Items.Count <= 0 Then Exit Sub

        Dim ans As DialogResult = MsgBox("Do you want to save this transaction?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

      
        'ItemClass = txtSchemeName.Text
        'Category = txtDescription.Text


        'ItemSave.Description = txtDayFrom.Text
        'ItemSave.PrintLayout = txtDayTo.Text
        'ItemSave.PrintLayout = txtInterest.Text
        'ItemSave.created_at = txtPenalty.Text
        'ItemSave.PrintLayout = txtRemarks.Text


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
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If txtSchemeName.Text = "" Then txtSchemeName.Focus()
        If txtDescription.Text = "" Then txtDescription.Focus()
        If lvIntScheme.Items.Count <= 0 Then Exit Sub

        If btnUpdate.Text = "&Update".ToString Then
            btnUpdate.Text = "&Modify".ToString
            reaDOnlyFalse()
            Exit Sub
        End If


        Dim ans As DialogResult = MsgBox("Do you want to Update this transaction?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

      
        'ItemClass = txtSchemeName.Text
        'Category = txtDescription.Text


        'ItemSave.Description = txtDayFrom.Text
        'ItemSave.PrintLayout = txtDayTo.Text
        'ItemSave.PrintLayout = txtInterest.Text
        'ItemSave.created_at = txtPenalty.Text
        'ItemSave.PrintLayout = txtRemarks.Text

        MsgBox("Transaction Updated", MsgBoxStyle.Information)
        btnSave.Enabled = True
        clearfields()
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
        Dim idx As Integer = lvIntScheme.FocusedItem.Index
        lvIntScheme.Items(idx).Remove()

        For cnt As Integer = 0 To lvIntScheme.Items.Count - 1
            lvIntScheme.Items(cnt).Text = cnt + 1
        Next
    End Sub

End Class