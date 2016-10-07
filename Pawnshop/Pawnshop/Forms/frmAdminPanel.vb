Imports System.Data.Odbc
Public Class frmAdminPanel
    Private mySql As String
    Private fillData As String
    Private SpecSave As ItemSpecs
    Dim ds As New DataSet

    Private Scheme As Hashtable
    Private SelectedItem As ItemClass

    Dim fromOtherForm As Boolean = False
    Dim frmOrig As formSwitch.FormName

    Private Sub frmAdminPanel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clearfields()
        txtClassification.Focus()

        LoadScheme()
    End Sub

    Friend Sub Load_ItemSpecification(ByVal Item As ItemClass)
        SelectedItem = Item
        txtClassification.Text = Item.ClassName
        txtCategory.Text = Item.Category
        txtDescription.Text = Item.Description
        txtPrintLayout.Text = Item.PrintLayout
        cboSchemename.Text = GetSchemeByID(Item.InterestScheme.SchemeID)

        If Item.isRenewable = "True" Then
            rbYes.Checked = True
            rbNo.Checked = False
        Else
            rbYes.Checked = False
            rbNo.Checked = True
        End If
        LoadSpec(Item.ID)
        btnUpdate.Enabled = True
    End Sub

    Friend Sub LoadSpec(ByVal ID As Integer)
        Dim da As New OdbcDataAdapter
        Dim mySql As String = "SELECT * FROM TBLSPECS WHERE ItemID = '" & ID & "'"
        Console.WriteLine("SQL: " & mySql)
        Dim ds As DataSet = LoadSQL(mySql)
        Dim dr As DataRow

        dgSpecs.Rows.Clear()
        For Each dr In ds.Tables(0).Rows
            AddItemSpecs(dr)
        Next
        reaDOnlyTrue()
        For a As Integer = 0 To dgSpecs.Rows.Count - 1
            dgSpecs.Rows(a).ReadOnly = True
        Next
        btnSave.Enabled = False
    End Sub

    Private Sub AddItemSpecs(ByVal ItemSpecs As DataRow)
        Dim tmpItem As New ItemSpecs
        tmpItem.LoadItemSpecs_row(ItemSpecs)
        dgSpecs.Rows.Add(tmpItem.SpecID, tmpItem.ShortCode, tmpItem.SpecName, tmpItem.SpecType.ToString, tmpItem.SpecLayout.ToString, tmpItem.UnitOfMeasure, tmpItem.isRequired.ToString)
    End Sub

    Private Sub LoadScheme()
        Dim mySql As String = "SELECT * FROM TBLINTSCHEMES"
        Dim ds As DataSet = LoadSQL(mySql)

        Scheme = New Hashtable
        cboSchemename.Items.Clear()
        Dim tmpName As String, tmpID As Integer

        For Each dr As DataRow In ds.Tables(0).Rows
            With dr
                tmpID = .Item("schemeID")
                tmpName = .Item("SCHEMENAME")
            End With
            Scheme.Add(tmpID, tmpName)
            cboSchemename.Items.Add(tmpName)
        Next

    End Sub

    Private Function GetSchemeByID(ByVal id As Integer) As String
        For Each el As DictionaryEntry In Scheme
            If el.Key = id Then
                Return el.Value
            End If
        Next
        Return "N/A"
    End Function

    Private Function GetSchemeID(ByVal name As String) As Integer
        For Each el As DictionaryEntry In Scheme
            If el.Value = name Then
                Return el.Key
            End If
        Next

        Return 0
    End Function

    Friend Sub clearfields()
        txtCategory.Text = ""
        txtClassification.Text = ""
        txtDescription.Text = ""
        txtPrintLayout.Text = ""
        txtSearch.Text = ""
        txtReferenceNumber.Text = ""
        cmbModuleName.Text = ""
        dgSpecs.Rows.Clear()
        btnUpdate.Enabled = False
        cboSchemename.Items.Clear()

    End Sub

    Private Function isValid() As Boolean

        If txtClassification.Text = "" Then txtClassification.Focus() : Return False
        If txtCategory.Text = "" Then txtCategory.Focus() : Return False

        If txtDescription.Text = "" Then txtDescription.Focus() : Return False
        If txtPrintLayout.Text = "" Then txtPrintLayout.Focus() : Return False
        If dgSpecs.CurrentCell.Value Is Nothing Then dgSpecs.Focus() : Return False
        If cboSchemename.Text = "" Then cboSchemename.Focus() : Return False
        Return True
    End Function

    Private Sub dgSpecs_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If btnUpdate.Text = "&Modify" Then
            If e.KeyCode = Keys.Enter Then
                btnUpdate.PerformClick()
            End If
        Else
            btnSave.PerformClick()
        End If
    End Sub

    Private Sub btnSave_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Not isValid() Then Exit Sub

        Dim ans As DialogResult = MsgBox("Do you want to save this transaction?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

        Dim ItemSave As New ItemClass
        Dim ColItemsSpecs As New CollectionItemSpecs

        With ItemSave
            .Category = txtCategory.Text
            .Description = txtDescription.Text
            .ClassName = txtClassification.Text

            If rbYes.Checked Then
                .isRenewable = 1
            Else
                .isRenewable = 0
            End If

            .PrintLayout = txtPrintLayout.Text
            .created_at = CurrentDate

            .InterestScheme.SchemeID = GetSchemeID(cboSchemename.Text)

        End With


        For Each row As DataGridViewRow In dgSpecs.Rows
            SpecSave = New ItemSpecs
            With SpecSave
                .ShortCode = row.Cells(1).Value
                .SpecName = row.Cells(2).Value
                .SpecType = row.Cells(3).Value
                .SpecLayout = row.Cells(4).Value
                .UnitOfMeasure = row.Cells(5).Value
                .isRequired = row.Cells(6).Value

                If .SpecName Is Nothing Or .SpecType Is Nothing _
                    Or .ShortCode Is Nothing Or .SpecLayout Is Nothing Then
                    Exit For
                End If
            End With
            SpecSave.SaveSpecs()
            ColItemsSpecs.Add(SpecSave)
        Next

        ItemSave.ItemSpecifications = ColItemsSpecs
        ItemSave.Save_ItemClass()

        MsgBox("Transaction Saved", MsgBoxStyle.Information)
        clearfields()
        LoadScheme()
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If Not isValid() Then Exit Sub

        If btnUpdate.Text = "&Update".ToString Then
            btnUpdate.Text = "&Modify".ToString
            reaDOnlyFalse()
            LoadScheme()
            Exit Sub
        End If

        Dim ans As DialogResult = MsgBox("Do you want to Update this transaction?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

        Dim ColItemsSpecs As New CollectionItemSpecs
        Dim ItemModify As New ItemClass


        With ItemModify
            .Category = txtCategory.Text
            .Description = txtDescription.Text
            .updated_at = CurrentDate
            .ID = SelectedItem.ID

            If rbYes.Checked Then
                .isRenewable = 1
            Else
                .isRenewable = 0
            End If
            .PrintLayout = txtPrintLayout.Text
            .InterestScheme.SchemeID = GetSchemeID(cboSchemename.Text)
        End With

        Dim SpecModify As New ItemSpecs
        For Each row As DataGridViewRow In dgSpecs.Rows

            With SpecModify
                .SpecID = row.Cells(0).Value
                .ShortCode = row.Cells(1).Value
                .SpecName = row.Cells(2).Value
                .SpecType = row.Cells(3).Value
                .SpecLayout = row.Cells(4).Value
                .UnitOfMeasure = row.Cells(5).Value
                .isRequired = row.Cells(6).Value

                If .SpecName Is Nothing Or .SpecType Is Nothing _
                    Or .ShortCode Is Nothing Or .SpecLayout Is Nothing Then
                    Exit For
                End If

            End With
            SpecModify.ItemID = SelectedItem.ID
            SpecModify.UpdateSpecs()
            ColItemsSpecs.Add(SpecModify)
        Next

        ItemModify.ItemSpecifications = ColItemsSpecs
        ItemModify.Update()

        MsgBox("Transaction Updated", MsgBoxStyle.Information)
        btnSave.Enabled = True
        btnUpdate.Text = "&Update"
        clearfields()
        LoadScheme()
    End Sub

    Private Sub btnClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSearch_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim secured_str As String = txtSearch.Text
        secured_str = DreadKnight(secured_str)
        frmItemList.SearchSelect(secured_str, FormName.frmPawningV2_SpecsValue)
        frmItemList.Show()
    End Sub

    '"""""""""""""""""""""""""""""export"""""""""""""""""""""""""""""""""""""""
    Private Sub ReadOnlyTrue()
        txtCategory.ReadOnly = True
        txtClassification.ReadOnly = True
        txtDescription.ReadOnly = True
        txtPrintLayout.ReadOnly = True
        cboSchemename.Enabled = False
        rbNo.Enabled = False
        rbYes.Enabled = False
        For a As Integer = 0 To dgSpecs.Rows.Count - 1
            dgSpecs.Rows(a).ReadOnly = True
        Next
    End Sub

    Friend Sub ReadOnlyFalse()
        txtCategory.ReadOnly = False
        ' txtClassifiction.ReadOnly = False
        txtDescription.ReadOnly = False
        txtPrintLayout.ReadOnly = False
        cboSchemename.Enabled = True
        rbNo.Enabled = True
        rbYes.Enabled = True
        For a As Integer = 0 To dgSpecs.Rows.Count - 1
            dgSpecs.Rows(a).ReadOnly = False
        Next
    End Sub

    Private Sub txtSearch_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()
        End If
    End Sub

    '"""""""""""""""""""""""""""""export""""""""""""""""""""""""""""""""""""""""
    Private Sub cmbModuleName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbModuleName.SelectedIndexChanged
        If cmbModuleName.Text = "" And cmbModuleName.Visible Then Exit Sub

        If cmbModuleName.Visible Then
            Select Case cmbModuleName.Text
                Case "Money Transfer"
                    ExportModType = ModuleType.MoneyTransfer
                Case "Branch"
                    ExportModType = ModuleType.Branch
                Case "Cash"
                    ExportModType = ModuleType.Cash
                Case "Item Class"
                    ExportModType = ModuleType.ItemClass
                Case "Rate"
                    ExportModType = ModuleType.Rate
                Case "Currency"
                    ExportModType = ModuleType.Currency
            End Select
        End If
        GenerateModule()
        lvModule.View = View.Details
        lvModule.CheckBoxes = True
        lvModule.Columns(1).DisplayIndex = lvModule.Columns.Count - 1
       
    End Sub

    Enum ModuleType As Integer
        MoneyTransfer = 0
        Branch = 1
        Cash = 2
        ItemClass = 3
        Rate = 4
        Currency = 5
    End Enum

    Friend ExportModType As ModuleType = ModuleType.MoneyTransfer

    Private Sub GenerateModule()
        Select Case ExportModType
            Case ModuleType.MoneyTransfer
                ModCharge()
            Case ModuleType.Branch
                ModBranches()
            Case ModuleType.Cash
                Modcash()
            Case ModuleType.ItemClass
                ModClass()
            Case ModuleType.Rate
                ModRate()
            Case ModuleType.Currency
                ModCurrency()
        End Select
    End Sub

#Region "Procedures"
   
    Private Sub ModBranches()
        fillData = "tblBranches"
        mySql = "SELECT * FROM " & fillData
        mySql &= " ORDER BY BranchID ASC"

        ds = LoadSQL(mySql, fillData)

        lvModule.Columns.Clear()
        lvModule.Items.Clear()

        Me.lvModule.Columns.Add("BRANCHID")
        Me.lvModule.Columns.Add("Column2", "BRANCHNAME")
        Me.lvModule.Columns.Add("Column3", "SAPCODE")
        Me.lvModule.Columns.Add("Column4", "SAPCODE2")

        For i = 0 To ds.Tables(0).Rows.Count - 1
            Dim str1 As String = ds.Tables(0).Rows(i)("BRANCHID").ToString
            Dim str2 As String = ds.Tables(0).Rows(i)("BRANCHNAME").ToString
            Dim str3 As String = ds.Tables(0).Rows(i)("SAPCODE").ToString
            Dim str4 As String = ds.Tables(0).Rows(i)("SAPCODE2").ToString


            Dim lvi As New ListViewItem
            lvi.Text = str1
            lvi.SubItems.AddRange(New String() {str2, str3, str4})
            lvModule.Items.Add(lvi)
        Next


       
    End Sub

    Private Sub Modcash()
       
        fillData = "tblCash"
        mySql = "SELECT * FROM " & fillData
        mySql &= " WHERE CashID <> 0"
        mySql &= " ORDER BY CashID ASC"

        ds = LoadSQL(mySql, fillData)

        lvModule.Columns.Clear()
        lvModule.Items.Clear()

        Me.lvModule.Columns.Add("CASHID")
        Me.lvModule.Columns.Add("Column2", "TYPE")
        Me.lvModule.Columns.Add("Column3", "CATEGORY")
        Me.lvModule.Columns.Add("Column4", "TRANSNAME")
        Me.lvModule.Columns.Add("Column5", "SAPACCOUNT")
        Me.lvModule.Columns.Add("Column6", "REMARKS")
        Me.lvModule.Columns.Add("Column7", "ONHOLD")

        For i = 0 To ds.Tables(0).Rows.Count - 1
            Dim str1 As String = ds.Tables(0).Rows(i)("CASHID").ToString
            Dim str2 As String = ds.Tables(0).Rows(i)("TYPE").ToString
            Dim str3 As String = ds.Tables(0).Rows(i)("CATEGORY").ToString
            Dim str4 As String = ds.Tables(0).Rows(i)("TRANSNAME").ToString
            Dim str5 As String = ds.Tables(0).Rows(i)("SAPACCOUNT").ToString
            Dim str6 As String = ds.Tables(0).Rows(i)("REMARKS").ToString
            Dim str7 As String = ds.Tables(0).Rows(i)("ONHOLD").ToString

            Dim lvi As New ListViewItem
            lvi.Text = str1
            lvi.SubItems.AddRange(New String() {str2, str3, str4, str5, str6, str7})
            lvModule.Items.Add(lvi)

        Next
    End Sub

    Private Sub ModCharge()
        fillData = "tblCharge"
        mySql = "SELECT ID,TYPE,AMOUNT,CHARGE FROM " & fillData
        mySql &= " ORDER BY ID ASC"

        ds = LoadSQL(mySql, fillData)

        lvModule.Columns.Clear()
        lvModule.Items.Clear()

        Me.lvModule.Columns.Add("ID")
        Me.lvModule.Columns.Add("Column2", "TYPE")
        Me.lvModule.Columns.Add("Column3", "AMOUNT")
        Me.lvModule.Columns.Add("Column4", "CHARGE")

        For i = 0 To ds.Tables(0).Rows.Count - 1
            Dim str1 As String = ds.Tables(0).Rows(i)("ID").ToString
            Dim str2 As String = ds.Tables(0).Rows(i)("TYPE").ToString
            Dim str3 As String = ds.Tables(0).Rows(i)("AMOUNT").ToString
            Dim str4 As String = ds.Tables(0).Rows(i)("CHARGE").ToString

            Dim lvi As New ListViewItem
            lvi.Text = str1
            lvi.SubItems.AddRange(New String() {str2, str3, str4})
            lvModule.Items.Add(lvi)
        Next

    End Sub

    Private Sub ModClass()
        fillData = "tblClass"
        mySql = "SELECT CLASSID,TYPE,CATEGORY,RENEWABLE FROM " & fillData
        mySql &= " ORDER BY ClassID ASC"

        ds = LoadSQL(mySql, fillData)
        lvModule.Columns.Clear()
        lvModule.Items.Clear()

        Me.lvModule.Columns.Add("CLASSID")
        Me.lvModule.Columns.Add("Column2", "TYPE")
        Me.lvModule.Columns.Add("Column3", "CATEGORY")
        Me.lvModule.Columns.Add("Column4", "RENEWABLE")

        For i = 0 To ds.Tables(0).Rows.Count - 1
            Dim str1 As String = ds.Tables(0).Rows(i)("CLASSID").ToString
            Dim str2 As String = ds.Tables(0).Rows(i)("TYPE").ToString
            Dim str3 As String = ds.Tables(0).Rows(i)("CATEGORY").ToString
            Dim str4 As String = ds.Tables(0).Rows(i)("RENEWABLE").ToString

            Dim lvi As New ListViewItem
            lvi.Text = str1
            lvi.SubItems.AddRange(New String() {str2, str3, str4})
            lvModule.Items.Add(lvi)
        Next

    End Sub

    Private Sub ModRate()
        fillData = "TBLINT"
        mySql = "SELECT INTID,DAYFROM,DAYTO,ITEMTYPE,INTEREST,PENALTY,REMARKS FROM " & fillData
        mySql &= " ORDER BY IntID ASC"

        ds = LoadSQL(mySql, fillData)
        lvModule.Columns.Clear()
        lvModule.Items.Clear()

        Me.lvModule.Columns.Add("INTID")
        Me.lvModule.Columns.Add("Column2", "DAYFROM")
        Me.lvModule.Columns.Add("Column3", "DAYTO")
        Me.lvModule.Columns.Add("Column4", "ITEMTYPE")
        Me.lvModule.Columns.Add("Column4", "INTEREST")
        Me.lvModule.Columns.Add("Column4", "PENALTY")
        Me.lvModule.Columns.Add("Column4", "REMARKS")

        For i = 0 To ds.Tables(0).Rows.Count - 1
            Dim str1 As String = ds.Tables(0).Rows(i)("INTID").ToString
            Dim str2 As String = ds.Tables(0).Rows(i)("DAYFROM").ToString
            Dim str3 As String = ds.Tables(0).Rows(i)("DAYTO").ToString
            Dim str4 As String = ds.Tables(0).Rows(i)("ITEMTYPE").ToString
            Dim str5 As String = ds.Tables(0).Rows(i)("INTEREST").ToString
            Dim str6 As String = ds.Tables(0).Rows(i)("PENALTY").ToString
            Dim str7 As String = ds.Tables(0).Rows(i)("REMARKS").ToString


            Dim lvi As New ListViewItem
            lvi.Text = str1
            lvi.SubItems.AddRange(New String() {str2, str3, str4, str5, str6, str7})
            lvModule.Items.Add(lvi)
        Next
    End Sub

    Private Sub ModCurrency()
        fillData = "tblCurrency"
        mySql = "SELECT CURRENCYID,CURRENCY,SYMBOL,RATE,CASHID FROM " & fillData
        mySql &= " ORDER BY CurrencyID ASC"

        ds = LoadSQL(mySql, fillData)
        lvModule.Columns.Clear()
        lvModule.Items.Clear()

        Me.lvModule.Columns.Add("CURRENCYID")
        Me.lvModule.Columns.Add("Column2", "CURRENCY")
        Me.lvModule.Columns.Add("Column3", "SYMBOL")
        Me.lvModule.Columns.Add("Column4", "RATE")
        Me.lvModule.Columns.Add("Column4", "CASHID")
      
        For i = 0 To ds.Tables(0).Rows.Count - 1

            Dim str1 As String = ds.Tables(0).Rows(i)("CURRENCYID").ToString
            Dim str2 As String = ds.Tables(0).Rows(i)("CURRENCY").ToString
            Dim str3 As String = ds.Tables(0).Rows(i)("SYMBOL").ToString
            Dim str4 As String = ds.Tables(0).Rows(i)("RATE").ToString
            Dim str5 As String = ds.Tables(0).Rows(i)("CASHID").ToString

            Dim lvi As New ListViewItem
            lvi.Text = str1
            lvi.SubItems.AddRange(New String() {str2, str3, str4, str5})
            lvModule.Items.Add(lvi)
        Next
    End Sub

#End Region

    Private Sub SFD_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim fn As String = SFD.FileName
        ExportConfig(fn, ds)
    End Sub

    Private Sub oFd_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim fn As String = oFd.FileName

        ShowDataInLvw(FileChecker(fn), lvModule)

    End Sub
  
    Sub ExportConfig(ByVal url As String, ByVal serialDS As DataSet)
        If System.IO.File.Exists(url) Then System.IO.File.Delete(url)

        Dim fsEsk As New System.IO.FileStream(url, IO.FileMode.CreateNew)
        Dim esk As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
        esk.Serialize(fsEsk, serialDS)
        fsEsk.Close()
    End Sub

    Function FileChecker(ByVal url As String) As DataTable
        Dim fs As New System.IO.FileStream(url, IO.FileMode.Open)
        Dim bf As New Runtime.Serialization.Formatters.Binary.BinaryFormatter()

        Dim serialDS As DataSet
        Try
            serialDS = bf.Deserialize(fs)
        Catch ex As Exception
            MsgBox("It seems the file is being tampered.", MsgBoxStyle.Critical)
            fs.Close()
            Return Nothing
        End Try
        fs.Close()

        Return serialDS.Tables(0)
    End Function

    Private Sub ShowDataInLvw(ByVal data As DataTable, ByVal lvw As ListView)
        lvw.View = View.Details
        lvw.GridLines = True
        lvw.Columns.Clear()
        lvw.Items.Clear()
        For Each col As DataColumn In data.Columns
            lvw.Columns.Add(col.ToString)
        Next
        For Each row As DataRow In data.Rows
            Dim lst As ListViewItem
            lst = lvw.Items.Add(If(row(0) IsNot Nothing, row(0).ToString, ""))
            For i As Integer = 1 To data.Columns.Count - 1
                lst.SubItems.Add(If(row(i) IsNot Nothing, row(i).ToString, ""))
            Next
        Next
    End Sub

    Private Sub cmbModuleName_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbModuleName.SelectedIndexChanged
        If cmbModuleName.Text = "" And cmbModuleName.Visible Then Exit Sub

        If cmbModuleName.Visible Then
            Select Case cmbModuleName.Text
                Case "Money Transfer"
                    ExportModType = ModuleType.MoneyTransfer
                Case "Branch"
                    ExportModType = ModuleType.Branch
                Case "Cash"
                    ExportModType = ModuleType.Cash
                Case "Item Class"
                    ExportModType = ModuleType.ItemClass
                Case "Rate"
                    ExportModType = ModuleType.Rate
                Case "Currency"
                    ExportModType = ModuleType.Currency
            End Select
        End If
        GenerateModule()
        lvModule.View = View.Details
        lvModule.CheckBoxes = True
        lvModule.Columns(1).DisplayIndex = lvModule.Columns.Count - 1
    End Sub

    Private Sub btnExport_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        If txtReferenceNumber.Text = "" Or cmbModuleName.Text = "" Then Exit Sub
        SFD.ShowDialog()

        MsgBox("Data Exported", MsgBoxStyle.Information)
        txtReferenceNumber.Text = ""
        cmbModuleName.SelectedItem = Nothing

        lvModule.Columns.Clear()
        lvModule.Items.Clear()
    End Sub

    Private Sub btnBrowse_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        oFd.ShowDialog()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmItemList.Show()
    End Sub
End Class