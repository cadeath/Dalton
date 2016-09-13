Imports System.Data.Odbc
Public Class frmAdminPanel
    Dim rbYes As Integer
    Dim rbNo As Integer

    Private ItemSave As Item
    Private ItemModify As Item

    Private SpecModify As Item
    Private SpecSave As Item
    Dim ds As New DataSet

    Friend SelectedItem As Item 'Holds Item

    Private lockForm As Boolean = False
    Dim fromOtherForm As Boolean = False
    Dim frmOrig As formSwitch.FormName

    Private ItemList As Item

    Private Sub frmAdminPanel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clearfields()


    End Sub

    'Friend Sub LoadItemList(ByVal it As Item)
    '    If it.Classification = "" Then Exit Sub
    '    ' Display select buttons
    '    txtClassifiction.Text = it.Classification
    '    txtCategory.Text = it.Category
    '    txtDescription.Text = it.Description
    '    If it.Renewable = "Yes" Then
    '        rdbYes.Checked = True
    '    Else
    '        rdbNo.Checked = True
    '    End If

    '    SelectedItem = it
    '    LockFields(True)
    'End Sub

    Private Sub LockFields(ByVal st As Boolean)
        lockForm = st
        txtCategory.ReadOnly = st
        txtClassifiction.ReadOnly = st
        txtDescription.ReadOnly = st
        txtPrintLayout.ReadOnly = st
        If rdbYes.Checked = True Then
            rdbYes.Enabled = st
        Else
            rdbNo.Checked = True
            rdbNo.Enabled = st
        End If

        If st Then
            btnUpdate.Text = "&Update"
        Else
            btnUpdate.Text = "&Modify"
        End If
    End Sub

    Friend Sub LoadItemall(ByVal it As Item)
        txtClassifiction.Text = String.Format(it.Classification)
        txtCategory.Text = String.Format(it.Category)
        txtDescription.Text = String.Format(it.Description)

        If it.Renewable = "1" Then
            rdbYes.Checked = True
        Else
            rdbNo.Checked = True
        End If
        txtPrintLayout.Text = String.Format(it.PrintLayout)

        ItemList = it
    End Sub

    Private Sub clearfields()
        txtCategory.Text = ""
        txtClassifiction.Text = ""
        txtDescription.Text = ""
        txtPrintLayout.Text = ""
        txtSearch.Text = ""
        txtReferenceNumber.Text = ""
        cmbModuleName.Text = ""
        dgSpecification.Rows.Clear()
    End Sub



    Private Sub rdbYes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbYes.CheckedChanged
        rbYes = 1
    End Sub

    Private Sub rdbNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbNo.CheckedChanged
        rbNo = 0
    End Sub
    Private Function isValid() As Boolean
        If txtClassifiction.Text = "" Then txtClassifiction.Focus() : Return False
        If txtCategory.Text = "" Then txtCategory.Focus() : Return False
        Return True
    End Function



    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Not isValid() Then Exit Sub

        Dim ans As DialogResult = MsgBox("Do you want to save this transaction?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

        ItemSave = New Item
        With ItemSave
            .Classification = txtClassifiction.Text
            .Category = txtCategory.Text
            .Description = txtDescription.Text
            .DateCreated = CurrentDate
            If rdbYes.Checked = True Then
                .Renewable = rbYes
            Else
                .Renewable = rbNo
            End If

            .PrintLayout = txtPrintLayout.Text

            .SaveItem()
        End With



        For Each row As DataGridViewRow In dgSpecification.Rows
            SpecSave = New Item
            With SpecSave

                .ShortCode = row.Cells(0).Value
                .SpecName = row.Cells(1).Value
                .SpecType = row.Cells(2).Value
                .Layout = row.Cells(3).Value
                .UnitofMeasure = row.Cells(4).Value

                If .SpecName Is Nothing Or .SpecType Is Nothing _
                    Or .ShortCode Is Nothing Or .Layout Is Nothing Then
                    Exit For
                Else
                    .SaveSpecification()
                End If
            End With

        Next
        MsgBox("Transaction Saved", MsgBoxStyle.Information)
        clearfields()

    End Sub


    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If Not isValid() Then Exit Sub
        If btnUpdate.Text = "Update" Then
            btnUpdate.Text = "&Modify"
        End If

        Dim ans As DialogResult = MsgBox("Do you want to Update this transaction?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

        ItemModify = New Item
        With ItemModify
            .Classification = txtClassifiction.Text
            .Category = txtCategory.Text
            .Description = txtDescription.Text
            .DateUpdated = CurrentDate
            If rdbYes.Checked = True Then
                .Renewable = rbYes
            Else
                .Renewable = rbNo
            End If

            .PrintLayout = txtPrintLayout.Text
            .ModifyItem()
        End With

        For Each row As DataGridViewRow In dgSpecification.Rows
            SpecSave = New Item
            With SpecSave

                .ShortCode = row.Cells(0).Value
                .SpecName = row.Cells(1).Value
                .SpecType = row.Cells(2).Value
                .Layout = row.Cells(3).Value
                .UnitofMeasure = row.Cells(4).Value

                If .SpecName Is Nothing Or .SpecType Is Nothing _
                    Or .ShortCode Is Nothing Or .Layout Is Nothing Then
                    Exit For
                Else
                    .ModifySpec()
                End If
            End With

        Next
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim secured_str As String = txtSearch.Text
        secured_str = DreadKnight(secured_str)
        frmItemList.SearchSelect(secured_str, FormName.frmAdminPanel)
        frmItemList.Show()
        frmItemList.txtSearch.Text = Me.txtSearch.Text.ToString
        frmItemList.btnSearch.PerformClick()
        frmItemList.Show()
    End Sub


    Private Sub searchbutton()
        If txtSearch.Text = "" Then Exit Sub
        Dim secured_str As String = txtSearch.Text
        secured_str = DreadKnight(secured_str)
    End Sub

    Private Sub disabled()
        txtCategory.ReadOnly = True
        txtClassifiction.ReadOnly = True
        txtDescription.ReadOnly = True
        txtPrintLayout.ReadOnly = True
        rdbNo.Enabled = False
        rdbYes.Enabled = False

    End Sub
   
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' dgSpecification.Rows.Clear()
        Dim da As New OdbcDataAdapter
        Dim mySql As String = "SELECT SHORT_CODE,SPECNAME,SPECTYPE,SPECLAYOUT,UOM FROM tbl_SPecification WHERE ItemID = '" & frmItemList.lblItemID.Text & "'"
        Console.WriteLine("SQL: " & mySql)
        Dim ds As DataSet = LoadSQL(mySql)
        Dim dt As New DataTable

        dt = ds.Tables(0)
     
        For Each dr As DataRow In dt.Rows
            dgSpecification.Rows.Add(dr(0), dr(1), dr(2), dr(3), dr(4))
        Next
        Dim i As Integer = (0)

        disabled()
        For a As Integer = 0 To dgSpecification.Rows.Count - 1
            dgSpecification.Rows(a).ReadOnly = True
        Next
    End Sub
End Class