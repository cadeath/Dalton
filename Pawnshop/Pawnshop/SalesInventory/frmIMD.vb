Public Class frmIMD

    Private Selected_Item As cItemData

    Private Sub frmIMD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearFields()
    End Sub

    Private Sub ClearFields()
        txtCode.Text = ""
        txtDescription.Text = ""
        chkHold.Checked = False
        cboCat.Text = ""
        cboCat.Items.Clear()
        cboSubCat.Text = ""
        cboSubCat.Items.Clear()
        txtUoM.Text = ""
        txtPrice.Text = ""
        txtSale.Text = ""
        txtDev.Text = "0"
        txtRemarks.Text = ""

        Load_Categories()
    End Sub

    Private Function isVerified() As Boolean
        Dim ver As Boolean = True

        If txtCode.Text = "" Then ver = False : txtCode.Focus()
        If txtSale.Text = "" Then txtSale.Text = 0
        If txtPrice.Text = "" Then txtPrice.Text = 0
        If txtDev.Text = "" Then txtDev.Text = 0

        Return ver
    End Function

    Friend Sub Load_ItemData(ByVal itm As cItemData)
        ClearFields()
        txtCode.Enabled = False 'Disable Item Code

        txtCode.Text = itm.ItemCode
        txtDescription.Text = itm.Description
        chkHold.Checked = itm.onHold
        cboCat.Text = itm.Category
        cboSubCat.Text = itm.SubCategory
        txtUoM.Text = itm.UnitOfMeasure
        txtPrice.Text = itm.UnitPrice.ToString("#,#00.00")
        chkInv.Checked = itm.isInventoriable
        txtSale.Text = itm.SalePrice.ToString("#,#00.00")
        'txtDev.Text = itm.MinimumDeviation
        chkSales.Checked = itm.isSaleable
        txtRemarks.Text = itm.Comments

        Selected_Item = itm
    End Sub

    Private Sub Save_ItemMasterData()
        If Not Selected_Item Is Nothing Then
            With Selected_Item
                .Description = txtDescription.Text
                .onHold = chkHold.Checked
                .Category = cboCat.Text
                .SubCategory = cboSubCat.Text
                .UnitofMeasure = txtUoM.Text
                .UnitPrice = txtPrice.Text
                .isInventoriable = chkInv.Checked
                .SalePrice = txtSale.Text
                '.MinimumDeviation = txtDev.Text
                .isSaleable = chkSales.Checked
                '.Remarks = txtRemarks.Text

                .Save_ItemData()
                MsgBox(.ItemCode & " is now updated", MsgBoxStyle.Information, "Item Master Data")

                'frmPLU.RefreshList(Selected_Item.ItemCode)
                Me.Close()
                Exit Sub
            End With
        End If

        If Not isVerified() Then
            Exit Sub
        End If

        Dim mySql As String = String.Format("SELECT * FROM ITEMMASTER WHERE ITEMCODE = '{0}'", DreadKnight(txtCode.Text))
        Dim ds As DataSet = LoadSQL(mySql)
        If ds.Tables(0).Rows.Count >= 1 Then
            MsgBox("Item Code already existed", MsgBoxStyle.Critical, "Invalid Code")
            Exit Sub
        End If
        Dim newItem As New cItemData

        Try
            With newItem
                .ItemCode = txtCode.Text
                .Description = txtDescription.Text
                .Category = cboCat.Text
                .SubCategory = cboSubCat.Text
                .UnitofMeasure = txtUoM.Text
                .UnitPrice = txtPrice.Text
                .SalePrice = txtSale.Text
                '.MinimumDeviation = txtDev.Text
                .Comments = txtRemarks.Text

                .onHold = chkHold.Checked
                .isInventoriable = chkInv.Checked
                .isSaleable = chkSales.Checked

                .Save_ItemData()

                MsgBox("Item Posted", MsgBoxStyle.Information)
            End With
        Catch ex As Exception
            MsgBox("Failed to SAVE the ITEM", MsgBoxStyle.Critical)
            Log_Report("IMD - " & ex.ToString)
        End Try

    End Sub

    Private Sub Load_Categories()
        Dim mySql As String = "SELECT DISTINCT CATEGORIES FROM ITEMMASTER ORDER BY CATEGORIES ASC"
        Dim ds As DataSet = LoadSQL(mySql)

        cboCat.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            cboCat.Items.Add(dr("CATEGORIES"))
        Next

        mySql = "SELECT DISTINCT SUBCAT FROM ITEMMASTER ORDER BY SUBCAT ASC"
        ds = LoadSQL(mySql)

        cboSubCat.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            cboSubCat.Items.Add(dr("SUBCAT"))
        Next
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Save_ItemMasterData()
        ClearFields()
        txtCode.Focus()
    End Sub

    Private Sub txtPrice_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrice.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub txtDev_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDev.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub txtSale_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSale.KeyPress
        DigitOnly(e)
    End Sub
End Class
