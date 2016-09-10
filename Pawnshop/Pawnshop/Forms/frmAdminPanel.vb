Imports System.Data.Odbc
Public Class frmAdminPanel
    Dim rbYes As Integer
    Dim rbNo As Integer

    Private ItemSave As Item
    Private ItemModify As Item

    Private SpecModify As Item
    Private SpecSave As Item
    Dim ds As New DataSet

    Private Sub frmAdminPanel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clearfields()


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
                    Or .ShortCode Is Nothing Or .Layout Is Nothing Or .UnitofMeasure Is Nothing Then
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

        Dim ans As DialogResult = MsgBox("Do you want to Update this transaction?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

        ItemModify = New Item
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
                    Or .ShortCode Is Nothing Or .Layout Is Nothing Or .UnitofMeasure Is Nothing Then
                    Exit For
                Else
                    .ModifySpec()
                End If
            End With

        Next
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        searchbutton()
    End Sub


    Private Sub searchbutton()

        If txtSearch.Text = "" Then Exit Sub
        Dim secured_str As String = txtSearch.Text
        secured_str = DreadKnight(secured_str)

        Dim mySql As String = "SELECT * FROM tbl_Item inner join TBL_Specification on tbl_Item.ItemID = TBL_Specification.ItemID WHERE ItemCategory = '" & secured_str & " '"
        ds = LoadSQL(mySql)
        txtClassifiction.Text = ds.Tables(0).Rows(0).Item(1)
        txtCategory.Text = ds.Tables(0).Rows(0).Item(1)
        txtDescription.Text = ds.Tables(0).Rows(0).Item(3)
        If ds.Tables(0).Rows(0).Item(7) = 1 Then
            rdbYes.Checked = True
        Else
            rdbNo.Checked = True
        End If
        txtPrintLayout.Text = ds.Tables(0).Rows(0).Item(9)


        Dim i As Integer
        With dgSpecification
            ' Write to cell (0,0)
            .Rows(i).Cells(0).Value = ds.Tables(0).Rows(0).Item(1)
            .Rows(i).Cells(1).Value = ds.Tables(0).Rows(0).Item(12)
            .Rows(i).Cells(2).Value = ds.Tables(0).Rows(0).Item(13)
            .Rows(i).Cells(3).Value = ds.Tables(0).Rows(0).Item(14)
            .Rows(i).Cells(4).Value = ds.Tables(0).Rows(0).Item(15)

        End With
        '10,11,12,13,14


    End Sub

   
End Class