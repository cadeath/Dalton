Imports System.Data.Odbc
Public Class frmAdminPanel
    Private mySql As String
    Private fillData As String

    Dim rbYes As Integer
    Dim rbNo As Integer

    Private SpecSave As ItemSpecs
    Dim ds As New DataSet

    Friend SelectedItem As ItemClass
    Friend SelectedItemSpecs As ItemSpecs

    Dim fromOtherForm As Boolean = False
    Dim frmOrig As formSwitch.FormName

    Private ItemList As ItemClass

    Private Sub frmAdminPanel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clearfields()
    End Sub

    Friend Sub LoadItemList(ByVal it As ItemClass)
        If it.ItemClass = "" Then Exit Sub

        txtClassifiction.Text = it.ItemClass
        txtCategory.Text = it.Category
        txtDescription.Text = it.Description

        If it.isRenewable = 1 Then
            rdbYes.Checked = True
        Else
            rdbNo.Checked = True
        End If

        txtPrintLayout.Text = it.PrintLayout

        Dim id As Integer = it.ID
        SelectedItem = it

        reaDOnlyTrue()
        btnSave.Enabled = False
        btnUpdate.Enabled = True
    End Sub

    Friend Sub LoadItemall(ByVal it As ItemClass)
        txtClassifiction.Text = String.Format(it.ItemClass)
        txtCategory.Text = String.Format(it.Category)
        txtDescription.Text = String.Format(it.Description)

        If it.isRenewable = "1" Then
            rdbYes.Checked = True
        Else
            rdbNo.Checked = True
        End If
        txtPrintLayout.Text = String.Format(it.PrintLayout)

        ItemList = it

    End Sub

    Friend Sub clearfields()
        txtCategory.Text = ""
        txtClassifiction.Text = ""
        txtDescription.Text = ""
        txtPrintLayout.Text = ""
        txtSearch.Text = ""
        txtReferenceNumber.Text = ""
        cmbModuleName.Text = ""
        dgSpecs.Rows.Clear()
        btnUpdate.Enabled = False

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

        If txtDescription.Text = "" Then txtDescription.Focus() : Return False
        If txtPrintLayout.Text = "" Then txtPrintLayout.Focus() : Return False

        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Not isValid() Then Exit Sub

        Dim ans As DialogResult = MsgBox("Do you want to save this transaction?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

        Dim ItemSave As New ItemClass
        Dim ColItemsSpecs As New CollectionItemSpecs

        ItemSave.ItemClass = txtClassifiction.Text
        ItemSave.Category = txtCategory.Text
        ItemSave.Description = txtDescription.Text

        If rdbYes.Checked = True Then
            ItemSave.isRenewable = rbYes
        Else
            ItemSave.isRenewable = rbNo
        End If

        ItemSave.PrintLayout = txtPrintLayout.Text
        ItemSave.created_at = CurrentDate


        ' ItemSave.RenewalCount = ItemSave.RenewalCount + 1

        For Each row As DataGridViewRow In dgSpecs.Rows
            SpecSave = New ItemSpecs
            With SpecSave
                .ShortCode = row.Cells(0).Value
                .SpecName = row.Cells(1).Value
                .SpecType = row.Cells(2).Value
                .SpecLayout = row.Cells(3).Value
                .UnitOfMeasure = row.Cells(4).Value
                .isRequired = row.Cells(5).Value


                If .SpecName Is Nothing Or .SpecType Is Nothing _
                    Or .ShortCode Is Nothing Or .SpecLayout Is Nothing Then
                    Exit For
                End If
            End With

            ColItemsSpecs.Add(SpecSave)
        Next

        ItemSave.ItemSpecifications = ColItemsSpecs
        ItemSave.SaveItem()

        MsgBox("Transaction Saved", MsgBoxStyle.Information)
        clearfields()

    End Sub
   

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If Not isValid() Then Exit Sub

        If btnUpdate.Text = "&Update".ToString Then
            btnUpdate.Text = "&Modify".ToString
            reaDOnlyFalse()
            Exit Sub
        End If


        Dim ans As DialogResult = MsgBox("Do you want to Update this transaction?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

        Dim ColItemsSpecs As New CollectionItemSpecs
        Dim ItemModify As New ItemClass
        ItemModify.ID = txtItemID.Text
        ItemModify.ItemClass = txtClassifiction.Text
        ItemModify.Category = txtCategory.Text
        ItemModify.Description = txtDescription.Text
        ItemModify.updated_at = CurrentDate
        If rdbYes.Checked = True Then
            ItemModify.isRenewable = rbYes
        Else
            ItemModify.isRenewable = rbNo
        End If

        ItemModify.PrintLayout = txtPrintLayout.Text

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
            SpecModify.UpdateSpecs()
            ' ColItemsSpecs.Add(SpecModify)
        Next

        'ItemModify.ItemSpecifications = ColItemsSpecs
        ItemModify.Update()

        MsgBox("Transaction Updated", MsgBoxStyle.Information)
        btnSave.Enabled = True
        clearfields()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Dim secured_str As String = txtSearch.Text
        secured_str = DreadKnight(secured_str)

        frmItemList.Show()

        frmItemList.txtSearch.Text = Me.txtSearch.Text.ToString
        frmItemList.btnSearch.PerformClick()

        btnUpdate.Text = "&Update".ToString
        btnUpdate.Enabled = True
        txtSearch.Clear()
        dgSpecs.Rows.Clear()
        clearfields()
    End Sub


    Private Sub searchbutton()
        If txtSearch.Text = "" Then Exit Sub
        Dim secured_str As String = txtSearch.Text
        secured_str = DreadKnight(secured_str)
    End Sub

    Private Sub reaDOnlyTrue()
        txtCategory.ReadOnly = True
        txtClassifiction.ReadOnly = True
        txtDescription.ReadOnly = True
        txtPrintLayout.ReadOnly = True
        rdbNo.Enabled = False
        rdbYes.Enabled = False
        For a As Integer = 0 To dgSpecs.Rows.Count - 1
            dgSpecs.Rows(a).ReadOnly = True
        Next
    End Sub

    Friend Sub reaDOnlyFalse()
        txtCategory.ReadOnly = False
        txtClassifiction.ReadOnly = False
        txtDescription.ReadOnly = False
        txtPrintLayout.ReadOnly = False
        rdbNo.Enabled = True
        rdbYes.Enabled = True
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
            AddItem(dr)
        Next
            ' Dim i As Integer = (0)

            reaDOnlyTrue()

        For a As Integer = 0 To dgSpecs.Rows.Count - 1
            dgSpecs.Rows(a).ReadOnly = True
        Next
            btnSave.Enabled = False
    End Sub

    Private Sub AddItem(ByVal cio As DataRow)
        Dim tmpItem As New ItemSpecs
        tmpItem.LoadItemSpecs_row(cio)
        dgSpecs.Rows.Add(tmpItem.SpecID, tmpItem.ShortCode, tmpItem.SpecName, tmpItem.SpecType.ToString, tmpItem.SpecLayout.ToString, tmpItem.UnitOfMeasure, tmpItem.isRequired.ToString)
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

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        If txtReferenceNumber.Text = "" Or cmbModuleName.Text = "" Then Exit Sub
        SFD.ShowDialog()

        MsgBox("Data Exported", MsgBoxStyle.Information)

        txtReferenceNumber.Text = ""
        cmbModuleName.SelectedItem = Nothing

        lvModule.Columns.Clear()
        lvModule.Items.Clear()

        
    End Sub

    Private Sub SFD_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SFD.FileOk
        Dim fn As String = SFD.FileName
        ExportConfig(fn, ds)
    End Sub


    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        oFd.ShowDialog()
    End Sub

    Private Sub oFd_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles oFd.FileOk
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


End Class