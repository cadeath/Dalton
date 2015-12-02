Public Class frmCashInOut2

    Dim cashInCat As Hashtable
    Dim ciTrans() As Hashtable
    Dim cashOutCat As Hashtable
    Dim coTrans() As Hashtable
    Dim selectedType As String = "Receipt"

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPost.Click

    End Sub

    Private Sub frmCashInOut2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearFields()
        LoadTables()
        cashInSetup()
    End Sub

    Private Sub UpdateCategory(ByVal ht As Hashtable)
        cboCat.Items.Clear()
        For Each el As DictionaryEntry In ht
            cboCat.Items.Add(el.Value)
        Next
    End Sub

    Private Sub UpdateTransaction(ByVal ht As Hashtable)
        cboTrans.Items.Clear()
        For Each el As DictionaryEntry In ht
            cboTrans.Items.Add(el.Value)
        Next
    End Sub

    Private Sub cashInSetup() Handles btnCashIn.Click
        On Error Resume Next

        cboCat.Items.Clear()
        UpdateCategory(cashInCat)
        cboCat.SelectedIndex = 0

        cboTrans.Items.Clear()
        UpdateTransaction(ciTrans(0))
        cboTrans.SelectedIndex = 0

        selectedType = "Receipt"
    End Sub

    Private Sub ClearFields()
        cboCat.Items.Clear()
        cboTrans.Items.Clear()
        txtAmt.Text = ""
        txtParticulars.Text = ""
        lvDetails.Items.Clear()
    End Sub

    Private Sub LoadTables()
        Dim mySql As String, ds As DataSet, fillData As String = "tblCash"

        'Load Categories
        mySql = "SELECT DISTINCT Category FROM " & fillData
        mySql &= String.Format(" WHERE Type = '{0}'", selectedType)
        ds = LoadSQL(mySql, fillData)

        cashInCat = New Hashtable
        Dim cnt As Integer = 0
        For Each dr As DataRow In ds.Tables(fillData).Rows
            cashInCat.Add(cnt, dr.Item("Category")) : cnt += 1
        Next

        ds.Clear()
        mySql = "SELECT DISTINCT Category FROM " & fillData
        mySql &= " WHERE Type = 'Disbursement'"
        ds = LoadSQL(mySql, fillData)
        cashOutCat = New Hashtable
        cnt = 0
        For Each dr As DataRow In ds.Tables(fillData).Rows
            cashOutCat.Add(cnt, dr.Item("Category")) : cnt += 1
        Next

        'Load Transaction Names
        Dim MaxRow As Integer = 0, tmpType As String = "Receipt"
        cnt = 0
        ReDim ciTrans(cashInCat.Count - 1)
        For Each el As DictionaryEntry In cashInCat
            mySql = "SELECT * FROM " & fillData
            mySql &= String.Format(" WHERE TYPE = '{0}' AND CATEGORY = '{1}'", tmpType, el.Value)
            ds.Clear()
            ds = LoadSQL(mySql, fillData)
            MaxRow = ds.Tables(fillData).Rows.Count - 1
            ciTrans(cnt) = New Hashtable
            For Each dr As DataRow In ds.Tables(fillData).Rows
                ciTrans(cnt).Add(dr.Item("CashID"), dr.Item("TransName"))
            Next
            cnt += 1
        Next

        tmpType = "Disbursement"
        cnt = 0
        ReDim coTrans(cashOutCat.Count - 1)
        For Each el As DictionaryEntry In cashOutCat
            mySql = "SELECT * FROM " & fillData
            mySql &= String.Format(" WHERE TYPE = '{0}' AND CATEGORY = '{1}'", tmpType, el.Value)
            ds.Clear()
            ds = LoadSQL(mySql, fillData)
            MaxRow = ds.Tables(fillData).Rows.Count - 1
            coTrans(cnt) = New Hashtable
            For Each dr As DataRow In ds.Tables(fillData).Rows
                coTrans(cnt).Add(dr.Item("CashID"), dr.Item("TransName"))
            Next
            cnt += 1
        Next

        'Display
        cnt = 0
        For Each el As DictionaryEntry In cashInCat
            Console.WriteLine(el.Value & "=========================")
            For Each y As DictionaryEntry In ciTrans(cnt)
                Console.WriteLine(y.Value)
            Next
            cnt += 1
        Next
        Console.WriteLine("------======================= ===============-----------")
        cnt = 0
        For Each el As DictionaryEntry In cashOutCat
            Console.WriteLine(el.Value & "=========================")
            For Each y As DictionaryEntry In coTrans(cnt)
                Console.WriteLine(y.Value)
            Next
            cnt += 1
        Next
    End Sub

    Private Sub cboCat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCat.SelectedIndexChanged
        Dim idx As Integer = cboCat.SelectedIndex
        Dim selectHT As New Hashtable

        Select Case selectedType
            Case "Receipt"
                selectHT = ciTrans(idx)
            Case "Disbursement"
                selectHT = coTrans(idx)
        End Select

        UpdateTransaction(selectHT)
        cboTrans.SelectedIndex = 0
    End Sub

    Private Sub btnCashOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCashOut.Click
        On Error Resume Next

        cboCat.Items.Clear()
        UpdateCategory(cashOutCat)
        cboCat.SelectedIndex = 0

        cboTrans.Items.Clear()
        UpdateTransaction(coTrans(0))
        cboTrans.SelectedIndex = 0

        selectedType = "Disbursement"
    End Sub
End Class