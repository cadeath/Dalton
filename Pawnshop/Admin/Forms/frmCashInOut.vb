Public Class frmCashInOut

    Dim isDisplaying As Boolean = False
    Dim catReceipt As Hashtable
    Dim catDisburse As Hashtable

    Private mySql As String, fillData As String = "tblCash"
    Private ds As DataSet

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        LoadCategories()
        'Me.Close()
    End Sub

    Private Sub frmCashInOut_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearFields()
        LoadCategories()
        LoadAccounts()
        LockFields(1)
    End Sub

    Private Sub LoadCategories()
        catReceipt = LoadHashtable("Receipt")
        catDisburse = LoadHashtable("Disbursement")
    End Sub

    Private Sub LoadSubCat()
        cboCat.Items.Clear()
        Select Case cboType.Text
            Case "Receipt"
                For Each el As DictionaryEntry In catReceipt
                    cboCat.Items.Add(el.Value)
                Next
            Case "Disbursement"
                For Each el As DictionaryEntry In catDisburse
                    cboCat.Items.Add(el.Value)
                Next
        End Select
    End Sub

    Private Function LoadHashtable(ByVal type As String)
        mySql = "SELECT DISTINCT Category FROM " & fillData & _
            " WHERE Type = '" & type & "' ORDER BY Category ASC"
        ds = New DataSet
        ds = LoadSQL(mySql, fillData)

        Dim ht As New Hashtable
        Dim cnt As Integer = 0
        For Each dr As DataRow In ds.Tables(0).Rows
            ht.Add(cnt, dr.Item("Category"))
            cnt += 1
        Next

        Return ht
    End Function

    Private Sub LoadAccounts()
        mySql = "SELECT * FROM " & fillData
        mySql &= " ORDER BY Type DESC, Category ASC"

        If Not IsNothing(ds) Then ds.Clear()
        ds = LoadSQL(mySql)

        lvAccnt.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim tmpCio As New CashInOut
            tmpCio.LoadCashInOutByRow(dr)
            AddItem(tmpCio)
        Next
    End Sub

    Private Sub LockFields(ByVal st As Boolean)
        cboType.Enabled = Not st
        cboCat.Enabled = Not st
        chkHold.Enabled = Not st
        txtTransName.Enabled = Not st
        txtRemarks.Enabled = Not st
        txtSAP.Enabled = Not st
        'btnModify.Enabled = Not st
    End Sub

    Private Sub ClearFields()
        cboType.SelectedIndex = 0
        cboCat.Items.Clear()
        cboCat.Text = ""
        txtTransName.Text = ""
        txtSAP.Text = ""
        txtRemarks.Text = ""
        chkHold.Checked = False
    End Sub

    Private Sub AddItem(ByVal cio As CashInOut)
        Dim lv As ListViewItem = lvAccnt.Items.Add(cio.CashID)
        lv.SubItems.Add(cio.Type)
        lv.SubItems.Add(cio.Category)
        lv.SubItems.Add(cio.TransactionName)
        lv.SubItems.Add(cio.SAPCode)
        lv.SubItems.Add(cio.Remarks)
        lv.SubItems.Add(IIf(cio.onHold = True, "True", "False"))
        If cio.onHold = True Then lv.BackColor = Color.LightGray
    End Sub

    Private Function isValid() As Boolean
        If cboType.SelectedIndex = -1 Then cboType.Focus() : Return False
        If cboCat.Text = "" Then cboCat.Focus() : Return False
        If txtTransName.Text = "" Then txtTransName.Focus() : Return False
        If txtSAP.Text = "" Then MsgBox("Must have a SAP Code", MsgBoxStyle.Critical) : txtSAP.Focus() : Return False

        Return True
    End Function

    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPost.Click
        Select Case btnPost.Text
            Case "&New"
                btnPost.Text = "&Add"
                LockFields(0)
                ClearFields()
            Case "&Add"
                If Not isValid() Then Exit Sub

                Dim addCIO As New CashInOut
                With addCIO
                    .Type = cboType.Text
                    .Category = cboCat.Text
                    .TransactionName = txtTransName.Text
                    .SAPCode = txtSAP.Text
                    .Remarks = txtRemarks.Text

                    .Save()
                End With
                MsgBox("Services Added", MsgBoxStyle.Information)

                ClearFields()
                LockFields(1)
                LoadAccounts()
                btnPost.Text = "&New"
        End Select
    End Sub

    Private Sub lvAccnt_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvAccnt.DoubleClick
        Dim id As Integer = lvAccnt.FocusedItem.Index
        LoadCIO(lvAccnt.Items(id).Text)
    End Sub

    Private Sub LoadCIO(ByVal id As Integer)
        Dim tmpCio As New CashInOut
        tmpCio.LoadCashInOutInfo(id)

        cboType.Text = tmpCio.Type
        cboCat.Text = tmpCio.Category
        txtTransName.Text = tmpCio.TransactionName
        txtSAP.Text = tmpCio.SAPCode
        txtRemarks.Text = txtRemarks.Text
        chkHold.Checked = tmpCio.onHold

        isDisplaying = True

        'Enabling Buttons
        btnModify.Enabled = isDisplaying
    End Sub

    Private Sub btnModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModify.Click
        If btnModify.Text = "&Modify" Then
            LockFields(0)

            btnModify.Text = "&Cancel"
            btnPost.Text = "&Save"
        Else
            LockFields(1)
            btnModify.Text = "&Modify"
            btnPost.Text = "&New"
        End If
    End Sub

    Private Sub cboType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboType.SelectedIndexChanged
        If Not cboCat.Text = "" Then LoadSubCat()
    End Sub
End Class