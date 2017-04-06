Imports System.Data.Odbc
Imports System.IO
Imports System.Text
Imports totp
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

    Dim SelectedScheme As InterestScheme

    Dim SchemeModify As New InterestScheme
    Private strcode As String
    Private strAppname As String

    Private Sub frmAdminPanel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clearfields()
        txtClassification.Focus()

        LoadScheme()
        LoadOTP()

        txtSchemeName.Text = ""
        txtDescription.Text = ""
        txtSearch.Text = ""
        btnUpdate.Enabled = False
        clearfields1() ''''''''''scheme
        btnRemove.Enabled = False
        btnUpdateScheme.Enabled = False
        btnEdit.Enabled = False
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

        SelectedItem = Item
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
        'txtSearch.Text = ""
        'txtReferenceNumber.Text = ""
        cboModuleName.Text = ""
        dgSpecs.Rows.Clear()
        btnUpdate.Enabled = False

        txtEmail.Clear()
        txtManual.Clear()
        txtQRURL.Clear()

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

    'Public Function IsDataGridViewEmpty(ByRef dataGridView As DataGridView) As Boolean
    '    Dim isEmpty As Boolean = True
    '    For Each row As DataGridViewRow In From row1 As DataGridViewRow In dataGridView.Rows _
    '    Where (From cell As DataGridViewCell In row1.Cells Where Not String.IsNullOrEmpty(cell.Value)).Any(Function(cell) _
    '    Not String.IsNullOrEmpty(Trim(cell.Value.ToString())))
    '        isEmpty = False
    '    Next
    '    Return isEmpty
    'End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If btnSave.Text = "&Save" Then
            SaveItems()
        Else
            ModifyItems()
        End If

    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If btnUpdate.Text = "&Edit" Then
            btnUpdate.Text = "&Cancel"
            btnSave.Enabled = True
            btnSave.Text = "&Update"

            ReadOnlyFalse()
            txtClassification.Enabled = False
        Else
            Dim ans As DialogResult = MsgBox("Do you want Cancel?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
            If ans = Windows.Forms.DialogResult.No Then Exit Sub
            btnUpdate.Text = "&Edit"
            btnSave.Enabled = False
            btnSave.Text = "&Save"
            Load_ItemSpecification(SelectedItem)
            ReadOnlyTrue()
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim secured_str As String = txtSearch.Text
        secured_str = DreadKnight(secured_str)
        frmItemList.SearchSelect(secured_str, FormName.frmPawningV2_SpecsValue)
        frmItemList.Show()
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
    Private Sub cboModuleName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboModuleName.SelectedIndexChanged
        If cboModuleName.Text = "" And cboModuleName.Visible Then Exit Sub
        If cboModuleName.Visible Then
            Select Case cboModuleName.Text
                Case "Money Transfer"
                    ExportModType = ModuleType.MoneyTransfer
                Case "Branch"
                    ExportModType = ModuleType.Branch
                Case "Cash"
                    ExportModType = ModuleType.Cash
                Case "Item"
                    ExportModType = ModuleType.ITEM
                Case "Interest"
                    ExportModType = ModuleType.Interest
                Case "Currency"
                    ExportModType = ModuleType.Currency

            End Select
        End If
        GenerateModule()
        'lvModule.View = View.Details
        'lvModule.CheckBoxes = True
        'lvModule.Columns(1).DisplayIndex = lvModule.Columns.Count - 1

    End Sub

    Enum ModuleType As Integer
        MoneyTransfer = 0
        Branch = 1
        Cash = 2
        ITEM = 3
        Interest = 4
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
            Case ModuleType.Interest
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
        'dgvPawnshop.DataSource = ds.Tables(fillData)
    End Sub

    Private Sub Modcash()
        fillData = "tblCash"
        mySql = "SELECT * FROM " & fillData
        mySql &= " ORDER BY CashID ASC"

        ds = LoadSQL(mySql, fillData)
        ' dgvPawnshop.DataSource = ds.Tables(fillData)
    End Sub

    Private Sub ModCharge()
        fillData = "tblCharge"
        mySql = "SELECT * FROM " & fillData
        mySql &= " ORDER BY ID ASC"

        ds = LoadSQL(mySql, fillData)
        'dgvPawnshop.DataSource = ds.Tables(fillData)
    End Sub

    Private Sub ModRate()
        mySql = "SELECT * FROM TBLINTSCHEMES"
        ds = LoadSQL(mySql, "TBLINTSCHEMES")
        mySql = "SELECT * FROM TBLINTSCHEME_DETAILS"
        Dim tblIntSchDetails As DataSet = LoadSQL(mySql, "TBLINTSCHEME_DETAILS")

        Dim otherTBL As New DataTable
        otherTBL = tblIntSchDetails.Tables("TBLINTSCHEME_DETAILS")
        ds.Tables.Add(otherTBL.Copy)
    End Sub

    Private Sub ModCurrency()

        fillData = "tblCurrency"
        mySql = "SELECT * FROM " & fillData
        mySql &= " ORDER BY CurrencyID ASC"

        ds = LoadSQL(mySql, fillData)
        'dgvPawnshop.DataSource = ds.Tables(fillData)
    End Sub

    Private Sub ModITEM()
        mySql = "SELECT * FROM tblItem"
        ds = LoadSQL(mySql, "tblItem")
        mySql = "SELECT * FROM tblSpecs"
        Dim tblIntSchDetails As DataSet = LoadSQL(mySql, "tblSpecs")

        Dim otherTBL As New DataTable
        otherTBL = tblIntSchDetails.Tables("tblSpecs")
        ds.Tables.Add(otherTBL.Copy)
    End Sub

#End Region

    Private Sub SFD_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SFD.FileOk
        Dim ans As DialogResult = MsgBox("Do you want to save this?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

        Dim fn As String = SFD.FileName
        ExportConfig(fn, ds)
        MsgBox("Data Exported", MsgBoxStyle.Information)
    End Sub

    Private Sub oFd_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles oFd.FileOk
        Dim fn As String = oFd.FileName
        FileChecker(fn)
        'dgPawnshop2.DataSource = FileChecker(fn)
    End Sub

    Sub ExportConfig(ByVal url As String, ByVal serialDS As DataSet)
        'If System.IO.File.Exists(url) Then System.IO.File.Delete(url)

        Dim fsEsk As New System.IO.FileStream(url, IO.FileMode.CreateNew)
        Dim esk As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
        esk.Serialize(fsEsk, serialDS)
        fsEsk.Close()
    End Sub

    Sub FileChecker(ByVal url As String)
        Dim fs As New System.IO.FileStream(url, IO.FileMode.Open)
        Dim bf As New Runtime.Serialization.Formatters.Binary.BinaryFormatter()

        Dim serialDS As DataSet
        Try
            serialDS = bf.Deserialize(fs)
        Catch ex As Exception
            MsgBox("It seems the file is being tampered.", MsgBoxStyle.Critical)
            fs.Close()
        End Try
        fs.Close()
        'Dim ds As DataSet = serialDS
        'dgvPawnshop.DataSource = ds.Tables(0)
        'dgPawnshop2.DataSource = ds.Tables(1)
    End Sub

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

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        'If txtReferenceNumber.Text = "" Then txtReferenceNumber.Focus() : Exit Sub
        'If cmbModuleName.Text = "" Then cmbModuleName.Focus() : Exit Sub
        'If lvModule.Items.Count <= 0 Then Exit Sub
        'If lblCount.Text = "Count: 0" Then Exit Sub

        'For Each item As ListViewItem In Me.lvModule.Items
        '    If item.Checked = False Then
        '        item.Remove()
        '    End If
        'Next

        'Console.WriteLine("Item Count: " & lvModule.Items.Count)

        'FromListView(dt, lvModule)

        'Dim path As String = String.Format("{1}{0}.dat", fn, str)
        'If Not File.Exists(path) Then
        '    Dim a As FileStream
        '    a = File.Create(path)
        '    a.Dispose()
        'End If

        'SFD.ShowDialog()



        'txtReferenceNumber.Text = ""
        'cmbModuleName.SelectedItem = Nothing

        'lvModule.Columns.Clear()
        'lvModule.Items.Clear()
        If ds.Tables.Count < 1 Then MsgBox("No Module Found!", MsgBoxStyle.Critical) : Exit Sub
        SFD.ShowDialog()
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
        'If txtRef.Text = Nothing Then
        '    Exit Sub
        'Else
        '    Dim Post_log As String = _
        '  String.Format("[{0}] ", Now.ToString("MM/dd/yyyy HH:mm:ss"))

        '    File.AppendAllText(path, "Date Exported: " & Post_log & vbCrLf & "Reference No: " & txtRef.Text & vbCrLf & _
        '                       "Module Name: " & cmbModuleName.Text & vbCrLf & "User: " & POSuser.UserName & vbCrLf)
        'End If
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        oFd.ShowDialog()

        'lvModule.View = View.Details
        'lvModule.CheckBoxes = True
        'lvModule.Columns(1).DisplayIndex = lvModule.Columns.Count - 1

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub ModifyItems()
        If Not isValid() Then Exit Sub

        ReadOnlyFalse()
        txtClassification.Enabled = False

        Dim ans As DialogResult = MsgBox("Do you want to Update Item Class?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

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
            .InterestScheme.SchemeID = GetSchemeID(cboSchemename.Text)
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
        clearfields()
        LoadScheme()
        btnUpdate.Text = "&Edit"
        btnSave.Text = "&Save"
    End Sub

    Private Sub SaveItems()
        If Not isValid() Then Exit Sub
        Dim ans As DialogResult = MsgBox("Do you want to save this Item Class?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

        Dim mySql As String = String.Format("SELECT * FROM tblItem WHERE ItemClass = '{0}'", txtClassification.Text)
        Dim ds As DataSet = LoadSQL(mySql, "TBLITEM")

        If ds.Tables(0).Rows.Count = 1 Then
            MsgBox("Class already existed", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim ItemSave As New ItemClass
        Dim ColItemsSpecs As New CollectionItemSpecs
        With ItemSave
            .ClassName = txtClassification.Text
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
            'SpecSave.SaveSpecs()
            ColItemsSpecs.Add(SpecSave)
        Next
        ItemSave.ItemSpecifications = ColItemsSpecs
        ItemSave.Save_ItemClass()

        MsgBox("Item Class Saved", MsgBoxStyle.Information)
        rdbNo.Checked = False
        txtClassification.Focus()
        clearfields()
    End Sub

    Private Sub cboSchemename_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSchemename.SelectedIndexChanged
        Console.WriteLine(GetSchemeID(cboSchemename.Text))
    End Sub
    '""""""""""""""""""""""""""""""""""""""""""""""""""scheme''''''''''''''""""""""""""""""""""


    Private Sub btnSearchScheme_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchScheme.Click

        Dim secured_str As String = txtsearchscheme.Text
        secured_str = DreadKnight(secured_str)
        frmInterestSchemeList.txtSearch.Text = Me.txtsearchscheme.Text.ToString
        frmInterestSchemeList.btnSearch.PerformClick()

        frmInterestSchemeList.SearchSelect(secured_str, FormName.frmPawningV2_InterestScheme)
        frmInterestSchemeList.Show()



        btnUpdate.Enabled = True
        btnEdit.Text = "&Edit"
        btnsavescheme.Text = "&Save"
        lvIntscheme.Items.Clear()
        txtDescription1.Text = ""
        txtSchemeName.Text = ""
        clearfields1()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If Not isValidsceheme() Then Exit Sub

        Dim List1 As ListViewItem
        List1 = Me.lvIntscheme.Items.Add(0)
        List1.SubItems.Add(Me.txtDayFrom.Text)
        List1.SubItems.Add(Me.txtDayTo.Text)
        List1.SubItems.Add(Me.txtInterest.Text)
        List1.SubItems.Add(Me.txtPenalty.Text)
        List1.SubItems.Add(Me.txtRemarks.Text)
        clearfields1()
        btnRemove.Enabled = True
    End Sub

    Private Sub btnUpdateScheme_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateScheme.Click

        Try
            If Not isValidsceheme() Then Exit Sub
            lvIntscheme.SelectedItems(0).SubItems(1).Text = txtDayFrom.Text
            lvIntscheme.SelectedItems(0).SubItems(2).Text = txtDayTo.Text
            lvIntscheme.SelectedItems(0).SubItems(3).Text = txtInterest.Text
            lvIntscheme.SelectedItems(0).SubItems(4).Text = txtPenalty.Text
            lvIntscheme.SelectedItems(0).SubItems(5).Text = txtRemarks.Text
        Catch ex As Exception
            MsgBox("Data you select has been removed.", MsgBoxStyle.Information)
        End Try

        clearfields1()
        Label18.Text = "Update"
        btnUpdateScheme.Enabled = False
        btnAdd.Enabled = True
        btnRemove.Enabled = True
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If lvIntscheme.SelectedItems.Count <= 0 Then Exit Sub
        lvIntscheme.Items.RemoveAt(lvIntscheme.SelectedIndices(0))
        For Each item As ListViewItem In lvIntscheme.SelectedItems
            item.Remove()
        Next
    End Sub

    Private Sub SaveSchemes()
        If txtSchemeName.Text = "" Then txtSchemeName.Focus()
        If txtDescription1.Text = "" Then txtDescription1.Focus()
        If lvIntscheme.Items.Count <= 0 Then Exit Sub

        Dim ans As DialogResult = MsgBox("Do you want to save this Scheme?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        If ans = Windows.Forms.DialogResult.No Then Exit Sub


        Dim SchemeSave As New InterestScheme
        Dim IntSchemeLines As New IntScheme_Lines

        With SchemeSave
            .SchemeName = txtSchemeName.Text
            .Description = txtDescription1.Text
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

        MsgBox("Scheme Saved", MsgBoxStyle.Information)
        btnsavescheme.Text = "&Save"
        btnEdit.Text = "&Edit"
        btnEdit.Enabled = False
        btnRemove.Enabled = False
        btnUpdateScheme.Enabled = False

        clearfields1()

        lvIntscheme.Items.Clear()
        txtSchemeName.Text = "" : txtSchemeName.Enabled = True
        txtDescription1.Text = "" : txtDescription1.Enabled = True

    End Sub

    Private Sub Modifyschemes()
        If txtSchemeName.Text = "" Then txtSchemeName.Focus()
        If txtDescription1.Text = "" Then txtDescription1.Focus()
        If lvIntscheme.Items.Count <= 0 Then Exit Sub

        Dim ans As DialogResult = MsgBox("Do you want to Update this Scheme?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        If ans = Windows.Forms.DialogResult.No Then Exit Sub


        Dim IntSchemeLines As New IntScheme_Lines
        SchemeModify.SchemeID = frmInterestSchemeList.lblSchemeID.Text

        SchemeModify.SchemeName = txtSchemeName.Text
        SchemeModify.Description = txtDescription1.Text
        SchemeModify.Update()

        For Each item As ListViewItem In lvIntscheme.Items
            Dim SchemeInterest As New Scheme_Interest


            With SchemeInterest
                .SchemeID = item.Text
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

        btnsavescheme.Text = "&Save"
        btnEdit.Text = "&Edit"
        btnsavescheme.Enabled = True
        btnEdit.Enabled = False
        btnAdd.Enabled = True
        btnRemove.Enabled = False
        btnUpdateScheme.Enabled = False

        clearfields1()

        lvIntscheme.Items.Clear()
        txtSchemeName.Text = "" : txtSchemeName.Enabled = True
        txtDescription1.Text = "" : txtDescription1.Enabled = True

    End Sub

    Private Sub btnClosescheme_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncLoseScheme.Click
        Me.Close()
    End Sub

    Friend Sub LoadSchemeList(ByVal sc As InterestScheme)
        If sc.SchemeName = "" Then Exit Sub

        txtSchemeName.Text = sc.SchemeName
        txtDescription1.Text = sc.Description

        SelectedScheme = sc

        reaDOnlyTruescheme()
        btnsavescheme.Enabled = False
        btnEdit.Enabled = True
        txtSchemeName.Enabled = False
        txtDescription1.Enabled = False
        btnUpdateScheme.Enabled = False
        btnAdd.Enabled = False
    End Sub


    Friend Sub clearfields1()
        txtDayFrom.Text = ""
        txtDayTo.Text = ""
        txtInterest.Text = ""
        txtPenalty.Text = ""
        txtRemarks.Text = ""
    End Sub

    Private Sub reaDOnlyTruescheme()
        txtDayFrom.ReadOnly = True
        txtDayTo.ReadOnly = True
        txtInterest.ReadOnly = True
        txtPenalty.ReadOnly = True
        txtRemarks.ReadOnly = True
    End Sub

    Friend Sub reaDOnlyFalseScheme()
        txtDayFrom.ReadOnly = False
        txtDayTo.ReadOnly = False
        txtInterest.ReadOnly = False
        txtPenalty.ReadOnly = False
        txtRemarks.ReadOnly = False
    End Sub

    Private Function isValidsceheme() As Boolean

        If txtDayFrom.Text = "" Then txtDayFrom.Focus() : Return False
        If txtDayTo.Text = "" Then txtDayTo.Focus() : Return False
        If txtInterest.Text = "" Then txtInterest.Focus() : Return False
        If txtPenalty.Text = "" Then txtPenalty.Focus() : Return False
        If txtRemarks.Text = "" Then txtRemarks.Focus() : Return False

        Return True
    End Function

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If btnEdit.Text = "&Edit" Then
            btnEdit.Text = "&Cancel"
            btnsavescheme.Enabled = True
            btnsavescheme.Text = "&Update"
            btnAdd.Enabled = True
            btnUpdateScheme.Enabled = True
            btnRemove.Enabled = True
            reaDOnlyFalseScheme()
        Else
            Dim ans As DialogResult = MsgBox("Do you want Cancel?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
            If ans = Windows.Forms.DialogResult.No Then Exit Sub
            btnEdit.Text = "&Edit"
            btnEdit.Enabled = False
            btnsavescheme.Enabled = False
            btnsavescheme.Text = "&Save"
            btnsavescheme.Enabled = True
            lvIntscheme.Items.Clear()
            txtDescription1.Text = "" : txtDescription1.Enabled = True
            txtSchemeName.Text = "" : txtSchemeName.Enabled = True
            btnUpdateScheme.Enabled = False
            btnRemove.Enabled = False
        End If
    End Sub

    Private Sub btnsavescheme_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsavescheme.Click
        If btnsavescheme.Text = "&Save" Then
            SaveSchemes()
        Else
            Modifyschemes()
        End If
    End Sub

    Private Sub txtsearchscheme_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtsearchscheme.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearchScheme.PerformClick()
        End If
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
            If Label18.Text = "Update".ToString Then
                btnAdd.PerformClick()
            ElseIf Label18.Text = "Modify" Then
                btnUpdateScheme.PerformClick()
            End If
        End If
    End Sub

    Private Sub lvIntscheme_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvIntscheme.DoubleClick
        With lvIntscheme
            txtDayFrom.Text = .SelectedItems(0).SubItems(1).Text
            txtDayTo.Text = .SelectedItems(0).SubItems(2).Text
            txtInterest.Text = .SelectedItems(0).SubItems(3).Text
            txtPenalty.Text = .SelectedItems(0).SubItems(4).Text
            txtRemarks.Text = .SelectedItems(0).SubItems(5).Text
        End With
        Label18.Text = "Modify"
        btnAdd.Enabled = False
        btnUpdateScheme.Enabled = True
        btnRemove.Enabled = False
    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        If Not isOTPValid() Then MsgBox("Please check the fields", MsgBoxStyle.Critical, "Error") : Exit Sub

        If strcode = String.Empty OrElse strAppname = String.Empty Then MsgBox("Please check the fields", MsgBoxStyle.Critical, "Error") : Exit Sub
        SetOTP(txtEmail.Text, strAppname, strcode)

    End Sub

    Private Sub SetOTP(ByVal Email As String, ByVal AppName As String, ByVal Code As String)
        Dim GenOTP As New OneTimePassword
        With GenOTP
            .Setup(Email)
            .AppName = AppName
            .SecretCode = Code
        End With

        txtManual.Text = GenOTP.ManualCode
        txtQRURL.Text = GenOTP.QRCode_URL
    End Sub

    Private Function isOTPValid() As Boolean
        If txtEmail.Text = "" Then Return False
        If Not (txtEmail.Text.Contains("@") And txtEmail.Text.Contains(".")) Then Return False
        Return True
    End Function

    Private Sub btnCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopy.Click
        If txtQRURL.Text = String.Empty Then Exit Sub
        Clipboard.SetText(txtQRURL.Text)
    End Sub

    Private Sub LoadOTP()
        Dim mysql As String = "Select * From OTPControl"
        Dim ds As DataSet = LoadSQL(mysql, "OTPControl")

        For Each dr In ds.Tables(0).Rows
            cboOTPMod.Items.Add(dr.item("ModName"))
        Next
    End Sub

    Private Sub cboOTPMod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOTPMod.SelectedIndexChanged
        Dim mysql As String = "Select * From OTPControl Where Modname = '" & cboOTPMod.Text & "'"
        Dim ds As DataSet = LoadSQL(mysql, "OTPControl")

        If ds.Tables(0).Rows(0).Item("Status") = 1 Then
            chbOnOff.Checked = True
        Else
            chbOnOff.Checked = False
        End If

        With ds.Tables(0).Rows(0)
            strAppname = .Item("AppName")
            strcode = .Item("OTPCode")
        End With
       
    End Sub

    Private Sub btnSwitch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSwitch.Click
        Dim mysql As String = "Select * From OTPControl Where ModName = '" & cboOTPMod.Text & "'"
        Dim ds As DataSet = LoadSQL(mysql, "OTPControl")

        With ds.Tables(0).Rows(0)
            If chbOnOff.Checked = True Then
                .Item("Status") = 1
            Else
                .Item("Status") = 0
            End If
        End With
        SaveEntry(ds, False)
        MsgBox(cboOTPMod.Text & " Switch " & IIf(chbOnOff.Checked = True, "On", "Off"), MsgBoxStyle.Information, "OTP Control")
    End Sub
End Class