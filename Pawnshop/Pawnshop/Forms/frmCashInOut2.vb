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

    End Sub

    Private Sub LoadTables()
        Dim mySql As String, ds As DataSet, fillData As String = "tblCash"

        'Load Categories
        mySql = "SELECT DISTINCT Category FROM " & fillData
        mySql &= String.Format(" WHERE Type = '{0}'", selectedType)
        ds = LoadSQL(mySql)

        cashInCat = New Hashtable
        Dim cnt As Integer = 0
        For Each dr As DataRow In ds.Tables(fillData).Rows
            cashInCat.Add(cnt, dr.Item("Category")) : cnt += 1
        Next

        ds.Clear()
        mySql = "SELECT DISTINCT Category FROM " & fillData
        mySql &= " WHERE Type = 'Disbursement'"
        ds = LoadSQL(mySql)
        cashOutCat = New Hashtable
        cnt = 0
        For Each dr As DataRow In ds.Tables(fillData).Rows
            cashInCat.Add(cnt, dr.Item("Category")) : cnt += 1
        Next

        'Load Transaction Names
        Dim MaxRow As Integer = 0, tmpType As String = "Receipt"
        cnt = 0
        For Each el As DictionaryEntry In cashInCat
            mySql = "SELECT * FROM " & fillData
            mySql &= String.Format(" WHERE TYPE = '{0}' AND CATEGORY = '{1}'", tmpType, el.Value)
            ds.Clear()
            ds = LoadSQL(mySql)
            MaxRow = ds.Tables(fillData).Rows.Count - 1
            ReDim ciTrans(MaxRow)
            For Each dr As DataRow In ds.Tables(fillData).Rows
                ciTrans(cnt).Add(dr.Item("CashID"), dr.Item("TransName"))
            Next
            cnt += 1
        Next
        tmpType = "Disbursement"

    End Sub

    Private Sub SaveHash(ByVal ht As Hashtable, ByVal ds As DataSet)

    End Sub
End Class