Imports System.Data.Odbc
Imports System.IO
Imports System.Text
Public Class frmAdminPanel
    Const fn As String = "\Post_Log.dat"
    Dim dt As New DataTable

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
        lblDateStatus.Text = CurrentDate.ToLongDateString & " " & Now.ToString("T")
        'String.Format("{0} ", Now.ToString("MM/dd/yyyy HH:mm:ss"))
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

    'Friend Sub LoadSpec(ByVal ID As Integer)
    '    Dim da As New OdbcDataAdapter
    '    Dim mySql As String = "SELECT * FROM TBLSPECS WHERE ItemID = '" & ID & "'"
    '    Console.WriteLine("SQL: " & mySql)
    '    Dim ds As DataSet = LoadSQL(mySql)
    '    Dim dr As DataRow

    '    dgSpecs.Rows.Clear()
    '    For Each dr In ds.Tables(0).Rows
    '        AddItemSpecs(dr)
    '    Next
    '    reaDOnlyTrue()
    '    For a As Integer = 0 To dgSpecs.Rows.Count - 1
    '        dgSpecs.Rows(a).ReadOnly = True
    '    Next
    '    btnSave.Enabled = False
    'End Sub

    'Private Sub AddItemSpecs(ByVal ItemSpecs As DataRow)
    '    Dim tmpItem As New ItemSpecs
    '    tmpItem.LoadItemSpecs_row(ItemSpecs)
    '    dgSpecs.Rows.Add(tmpItem.SpecID, tmpItem.ShortCode, tmpItem.SpecName, tmpItem.SpecType.ToString, tmpItem.SpecLayout.ToString, tmpItem.UnitOfMeasure, tmpItem.isRequired.ToString)
    'End Sub

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


    'Friend Sub LoadItemList(ByVal it As ItemClass)
      '  If it.ClassName = "" Then Exit Sub

   'End Sub


        'txtPrintLayout.Text = it.PrintLayout

    Friend Sub LoadItemList(ByVal it As ItemClass)


        If it.ClassName = "" Then Exit Sub
        txtClassification.Text = it.ClassName
        txtCategory.Text = it.Category
        txtDescription.Text = it.Description
        cbotxtSchemename.Text = GetSchemeByID(it.InterestScheme.SchemeID)

        If it.isRenewable = "True" Then
            rdbYes.Checked = True
            rdbNo.Checked = False
        Else
            rdbYes.Checked = False
            rdbNo.Checked = True
        End If

        txtPrintLayout.Text = it.PrintLayout
        cbotxtSchemename.Text = GetSchemeByID(it.InterestScheme.SchemeID)

        Dim id As Integer = it.ID
        SelectedItem = it

        ReadOnlyTrue()
        btnSave.Enabled = False
        btnUpdate.Enabled = True
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


    'Friend Sub LoadItemall(ByVal it As ItemClass)
    '    txtClassifiction.Text = String.Format(it.ItemClass)
    '    txtCategory.Text = String.Format(it.Category)
    '    txtDescription.Text = String.Format(it.Description)

    '    If it.isRenewable = "1" Then
    '        rdbYes.Checked = True
    '    Else
    '        rdbNo.Checked = True
    '    End If
    '    txtPrintLayout.Text = String.Format(it.PrintLayout)

    '    ItemList = it

    'End Sub

    Friend Sub clearfields()
        txtCategory.Text = ""
        txtClassification.Text = ""
        txtDescription.Text = ""
        txtPrintLayout.Text = ""
        'txtSearch.Text = ""
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

        If cbotxtSchemename.Text = "" Then cbotxtSchemename.Focus() : Return False
        If IsDataGridViewEmpty(dgSpecs) Then dgSpecs.Focus() : Return False
        Return True
    End Function

    Public Function IsDataGridViewEmpty(ByRef dataGridView As DataGridView) As Boolean
        Dim isEmpty As Boolean = True
        For Each row As DataGridViewRow In From row1 As DataGridViewRow In dataGridView.Rows _
        Where (From cell As DataGridViewCell In row1.Cells Where Not String.IsNullOrEmpty(cell.Value)).Any(Function(cell) _
        Not String.IsNullOrEmpty(Trim(cell.Value.ToString())))
            isEmpty = False
        Next
        Return isEmpty
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
        Dim ans As DialogResult = MsgBox("Do you want to save this Item Class?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

        Dim SchemeSID As New InterestScheme
        SchemeSID.LoadScheme(GetSchemeID(cbotxtSchemename.Text))

        Dim ItemSave As New ItemClass
        Dim ColItemsSpecs As New CollectionItemSpecs
        With ItemSave
            .ClassName = txtClassification.Text
            .Category = txtCategory.Text
            .Description = txtDescription.Text

            .InterestScheme = SchemeSID


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

            ColItemsSpecs.Add(SpecSave)
        Next
        ItemSave.ItemSpecifications = ColItemsSpecs
        ItemSave.Save_ItemClass()

        MsgBox("Item Class Saved", MsgBoxStyle.Information)
        rdbNo.Checked = False
        txtClassification.Focus()
        clearfields()
        LoadScheme()
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If Not isValid() Then Exit Sub

        If btnUpdate.Text = "&Update".ToString Then
            btnUpdate.Text = "&Modify".ToString
            reaDOnlyFalse()
            txtClassification.Enabled = False
            LoadScheme()
            Exit Sub
        End If
        Dim ans As DialogResult = MsgBox("Do you want to Update Item Class?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

        Dim SchemeSID As New InterestScheme
        SchemeSID.LoadScheme(GetSchemeID(cbotxtSchemename.Text))

        Dim ColItemsSpecs As New CollectionItemSpecs
        Dim ItemModify As New ItemClass
        With ItemModify
            .ClassName = txtClassification.Text
            .Category = txtCategory.Text
            .Description = txtDescription.Text
            .ID = SelectedItem.ID

            If rdbYes.Checked Then
                .isRenewable = 1
            Else
                .isRenewable = 0
            End If

            .PrintLayout = txtPrintLayout.Text

            .InterestScheme.SchemeID = GetSchemeID(cbotxtSchemename.Text)


            .updated_at = CurrentDate

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
        Next
        ItemModify.Update()

        MsgBox("Item Class Updated", MsgBoxStyle.Information)

        btnSave.Enabled = True

        rdbNo.Checked = False
        txtClassification.Focus()
        txtClassification.Enabled = True

        btnUpdate.Text = "&Update"
        rdbNo.Checked = False
        txtClassification.Focus()
        txtClassification.Enabled = True

        clearfields()
        LoadScheme()
    End Sub

    Private Sub btnClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub


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

        txtClassification.ReadOnly = False

        txtDescription.ReadOnly = False
        txtPrintLayout.ReadOnly = False
        cboSchemename.Enabled = True
        rbNo.Enabled = True
        rbYes.Enabled = True
        For a As Integer = 0 To dgSpecs.Rows.Count - 1
            dgSpecs.Rows(a).ReadOnly = False
        Next
    End Sub

    Friend Sub LoadSpec(ByVal ID As Integer)
        Dim da As New OdbcDataAdapter
        Dim mySql As String = "SELECT * FROM TBLSPECS WHERE ItemID = '" & ID & "'"
        Console.WriteLine("SQL: " & mySql)
        Dim ds As DataSet = LoadSQL(mySql)
        Dim dr As DataRow

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
        dgSpecs.Rows.Add(tmpItem.SpecID, tmpItem.ShortCode, _
                tmpItem.SpecName, tmpItem.SpecType.ToString, _
                tmpItem.SpecLayout.ToString, tmpItem.UnitOfMeasure, tmpItem.isRequired.ToString)
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
                Case "Item"
                    ExportModType = ModuleType.ITEM
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
        ITEM = 3
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
            Case ModuleType.ITEM
                ModITEM()
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



    'Private Sub ModClass()
    '    fillData = "tblClass"
    '    mySql = "SELECT CLASSID,TYPE,CATEGORY,RENEWABLE FROM " & fillData
    '    mySql &= " ORDER BY ClassID ASC"

    '    ds = LoadSQL(mySql, fillData)
    '    lvModule.Columns.Clear()
    '    lvModule.Items.Clear()

    '    Me.lvModule.Columns.Add("CLASSID")
    '    Me.lvModule.Columns.Add("Column2", "TYPE")
    '    Me.lvModule.Columns.Add("Column3", "CATEGORY")
    '    Me.lvModule.Columns.Add("Column4", "RENEWABLE")

    '    For i = 0 To ds.Tables(0).Rows.Count - 1
    '        Dim str1 As String = ds.Tables(0).Rows(i)("CLASSID").ToString
    '        Dim str2 As String = ds.Tables(0).Rows(i)("TYPE").ToString
    '        Dim str3 As String = ds.Tables(0).Rows(i)("CATEGORY").ToString
    '        Dim str4 As String = ds.Tables(0).Rows(i)("RENEWABLE").ToString

    '        Dim lvi As New ListViewItem
    '        lvi.Text = str1
    '        lvi.SubItems.AddRange(New String() {str2, str3, str4})
    '        lvModule.Items.Add(lvi)
    '    Next

    'End Sub

    Private Sub ModRate()

        mySql = "SELECT  D.IS_ID, I.SCHEMENAME, I.DESCRIPTION, D.DAYFROM, D.DAYTO, "
        mySql &= "D.INTEREST, D.PENALTY, D.REMARKS "
        mySql &= "FROM TBLINTSCHEMES I INNER JOIN TBLINTSCHEME_DETAILS D ON I.SCHEMEID = D.SCHEMEID "

        ds = LoadSQL(mySql)
        lvModule.Columns.Clear()
        lvModule.Items.Clear()

        Me.lvModule.Columns.Add("ID")
        Me.lvModule.Columns.Add("Column2", "Remarks")
        Me.lvModule.Columns.Add("Column3", "SchemeName")
        Me.lvModule.Columns.Add("Column4", "Description")
        Me.lvModule.Columns.Add("Column5", "DayFrom")
        Me.lvModule.Columns.Add("Column6", "DayTo")
        Me.lvModule.Columns.Add("Column7", "Interest")
        Me.lvModule.Columns.Add("Column8", "Penalty")

        For i = 0 To ds.Tables(0).Rows.Count - 1
            Dim str1 As String = ds.Tables(0).Rows(i)("Is_ID").ToString
            Dim str2 As String = ds.Tables(0).Rows(i)("SchemeName").ToString
            Dim str3 As String = ds.Tables(0).Rows(i)("Description").ToString
            Dim str4 As String = ds.Tables(0).Rows(i)("DayFrom").ToString
            Dim str5 As String = ds.Tables(0).Rows(i)("DayTo").ToString
            Dim str6 As String = ds.Tables(0).Rows(i)("Interest").ToString
            Dim str7 As String = ds.Tables(0).Rows(i)("Penalty").ToString
            Dim str8 As String = ds.Tables(0).Rows(i)("Remarks").ToString

            Dim lvi As New ListViewItem
            lvi.Text = str1
            lvi.SubItems.AddRange(New String() {str8, str2, str3, str4, str5, str6, str7})
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


    Private Sub ModITEM()

        mySql = "SELECT S.SPECSID, I.ITEMCLASS, I.ITEMCATEGORY, I.DESCRIPTION, I.ISRENEW, "
        mySql &= "I.ONHOLD, I.PRINT_LAYOUT, I.RENEWAL_CNT, I.SCHEME_ID, S.SPECSNAME, "
        mySql &= "S.SPECTYPE, S.UOM, S.SPECLAYOUT, S.SHORTCODE, S.ISREQUIRED, I.ITEMID "
        mySql &= "FROM TBLITEM I INNER JOIN TBLSPECS S ON S.ITEMID = I.ITEMID "

        ds = LoadSQL(mySql)
        lvModule.Columns.Clear()
        lvModule.Items.Clear()

        Me.lvModule.Columns.Add("Specsid")
        Me.lvModule.Columns.Add("Column2", "Isrequired")
        Me.lvModule.Columns.Add("Column3", "ITEMCLASS")
        Me.lvModule.Columns.Add("Column4", "ItemID")
        Me.lvModule.Columns.Add("Column5", "ITEMCATEGORY")
        Me.lvModule.Columns.Add("Column6", "DESCRIPTION")
        Me.lvModule.Columns.Add("Column7", "ISRENEW")
        Me.lvModule.Columns.Add("Column8", "Onhold")
        Me.lvModule.Columns.Add("Column9", "Print_layout")
        Me.lvModule.Columns.Add("Column10", "Renewal_cnt")
        Me.lvModule.Columns.Add("Column11", "Scheme_ID")
        Me.lvModule.Columns.Add("Column12", "Specsname")
        Me.lvModule.Columns.Add("Column13", "Spectype")
        Me.lvModule.Columns.Add("Column14", "UOM")
        Me.lvModule.Columns.Add("Column15", "Speclayout")
        Me.lvModule.Columns.Add("Column16", "Shortcode")

        For i = 0 To ds.Tables(0).Rows.Count - 1
            Dim str As String = ds.Tables(0).Rows(i)("Specsid").ToString
            Dim str2 As String = ds.Tables(0).Rows(i)("ITEMCLASS").ToString
            Dim str3 As String = ds.Tables(0).Rows(i)("ITEMCATEGORY").ToString
            Dim str4 As String = ds.Tables(0).Rows(i)("DESCRIPTION").ToString
            Dim str5 As String = ds.Tables(0).Rows(i)("ISRENEW").ToString
            Dim str6 As String = ds.Tables(0).Rows(i)("Onhold").ToString
            Dim str7 As String = ds.Tables(0).Rows(i)("Print_layout").ToString
            Dim str8 As String = ds.Tables(0).Rows(i)("Renewal_cnt").ToString
            Dim str9 As String = ds.Tables(0).Rows(i)("Scheme_ID").ToString
            Dim str10 As String = ds.Tables(0).Rows(i)("Specsname").ToString
            Dim str11 As String = ds.Tables(0).Rows(i)("Spectype").ToString
            Dim str12 As String = ds.Tables(0).Rows(i)("UOM").ToString
            Dim str13 As String = ds.Tables(0).Rows(i)("Speclayout").ToString
            Dim str14 As String = ds.Tables(0).Rows(i)("Shortcode").ToString
            Dim str15 As String = ds.Tables(0).Rows(i)("Isrequired").ToString
            Dim str16 As String = ds.Tables(0).Rows(i)("ItemID").ToString

            Dim lvi As New ListViewItem
            lvi.Text = str
            lvi.SubItems.AddRange(New String() {str15, str2, str16, str3, str4, str5, str6, str7, str8, str9, str10, str11, str12, str13, str14})
            lvModule.Items.Add(lvi)
        Next

    End Sub

#End Region

    Private Sub SFD_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SFD.FileOk
        Dim ans As DialogResult = MsgBox("Do you want to save this?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

        ds = New DataSet
        ds.Tables.Add(dt)

        Dim fn As String = SFD.FileName
        ExportConfig(fn, ds)
        MsgBox("Data Exported", MsgBoxStyle.Information)

        dt.Clear()
        ds.Tables.Clear()
        chkSelectAll.Checked = False
    End Sub

    Private Sub oFd_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles oFd.FileOk
        Dim fn As String = oFd.FileName

        ShowDataInLvw(FileChecker(fn), lvModule)
        MsgBox("Successfully Loaded", MsgBoxStyle.OkOnly, "Load")
        chkSelectAll.Checked = False
        dt.Clear()
        ds.Tables.Clear()
        chkSelectAll.Checked = False
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
                    ExportModType = ModuleType.ITEM
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

  
    Private Sub txtSearch_KeyDown_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        If txtReferenceNumber.Text = "" Then txtReferenceNumber.Focus() : Exit Sub
        If cmbModuleName.Text = "" Then cmbModuleName.Focus() : Exit Sub
        If lvModule.Items.Count <= 0 Then Exit Sub
        If lblCount.Text = "Count: 0" Then Exit Sub

        For Each item As ListViewItem In Me.lvModule.Items
            If item.Checked = False Then
                item.Remove()
            End If
        Next

        Console.WriteLine("Item Count: " & lvModule.Items.Count)

        FromListView(dt, lvModule)

        Dim path As String = String.Format("{1}{0}.dat", fn, str)
        If Not File.Exists(path) Then
            Dim a As FileStream
            a = File.Create(path)
            a.Dispose()
        End If

        SFD.ShowDialog()
        saveModname()

    End Sub
  
    Public Sub FromListView(ByVal table As DataTable, ByVal lvw As ListView)
        table.Clear()
        dt.Columns.Clear()
        dt.Rows.Clear()
        Dim columns = lvw.Columns.Count

        For Each column As ColumnHeader In lvw.Columns
            table.Columns.Add(column.Text)
        Next

        For Each item As ListViewItem In lvw.Items
            Dim cells = New Object(columns - 1) {}
            For i As VariantType = 0 To columns - 1
                cells(i) = item.SubItems(i).Text
            Next
            table.Rows.Add(cells)
        Next
    End Sub

    Private str As String = My.Computer.FileSystem.SpecialDirectories.Desktop
    Private path As String = String.Format("{1}{0}.dat", fn, str)

    Private Sub saveModname()
        If txtReferenceNumber.Text = Nothing Then
            Exit Sub
        Else
            Dim Post_log As String = _
          String.Format("[{0}] ", Now.ToString("MM/dd/yyyy HH:mm:ss"))

            File.AppendAllText(path, "Date Exported: " & Post_log & vbCrLf & "Reference No: " & txtReferenceNumber.Text & vbCrLf & _
                               "Module Name: " & cmbModuleName.Text & vbCrLf & "User: " & POSuser.UserName & vbCrLf)
        End If
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        oFd.ShowDialog()

        lvModule.View = View.Details
        lvModule.CheckBoxes = True
        lvModule.Columns(1).DisplayIndex = lvModule.Columns.Count - 1

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub chkSelectAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSelectAll.CheckedChanged
        If lvModule.Items.Count <= 0 Then Exit Sub
        If chkSelectAll.Checked = True Then
            For i = 0 To lvModule.Items.Count - 1
                lvModule.Items(i).Checked = True
            Next
        Else
            For i = 0 To lvModule.Items.Count - 1
                lvModule.Items(i).Checked = False
            Next
        End If
        lblCount.Text = "count: " & lvModule.CheckedItems.Count
    End Sub

    Private Sub lvModule_ItemChecked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles lvModule.ItemChecked
        lblCount.Text = "Count: " & lvModule.CheckedItems.Count
    End Sub

    Private Sub btnBrowse_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        oFd.ShowDialog()
    End Sub


    Private Sub btnSearch1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch1.Click
        Dim secured_str As String = txtSearch.Text
        secured_str = DreadKnight(secured_str)
        frmItemList.SearchSelect(secured_str, FormName.frmPawningV2_SpecsValue)
        frmItemList.Show()
    End Sub

    Private Sub txtSearch1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch1.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch1.PerformClick()
        End If
    End Sub
End Class