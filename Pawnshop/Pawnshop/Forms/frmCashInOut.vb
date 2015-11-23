Public Class frmCashInOut

    Dim cashIN As New Hashtable 'Receipt
    Dim cashOUT As New Hashtable 'DISBURSEMENT

    Private mainTransaction As Boolean = True 'True Cash IN|False Cash OUT
    Private fillData As String = "tblCashTrans"
    Friend isDisplay As Boolean = False

    Private Sub frmCashInOut_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearFields()
        CreateHashTable()
        LoadTransType()
    End Sub

    Private Sub ClearFields()
        cboTransactions.Items.Clear()
        txtAmount.Text = ""
        txtParticulars.Text = ""
    End Sub

    Private Sub CreateHashTable()
        Dim fillData As String = "tblCash"
        Dim mySql As String = "SELECT * FROM " & fillData
        Dim ds As DataSet

        'Receipt
        Dim tmpSql As String = mySql
        tmpSql &= " WHERE Type = 'RECEIPT' ORDER BY TransName ASC"
        ds = LoadSQL(tmpSql)
        Console.WriteLine("Receipt: " & ds.Tables(0).Rows.Count)

        Dim cnt As Integer = 0
        For Each dr As DataRow In ds.Tables(0).Rows
            cashIN.Add(cnt, dr.Item("TransName"))
            cnt += 1
        Next

        'Disbursement
        tmpSql = mySql
        tmpSql &= " WHERE Type = 'DISBURSEMENT' ORDER BY TransName ASC"
        ds = LoadSQL(tmpSql)

        cnt = 0
        For Each dr As DataRow In ds.Tables(0).Rows
            cashOUT.Add(cnt, dr.Item("TransName"))
            cnt += 1
        Next
    End Sub

    Private Sub LoadTransType()
        cboTransactions.Items.Clear()
        Dim switchHash As Hashtable
        If mainTransaction Then
            'Receipt
            switchHash = cashIN
        Else
            'Disbursement
            switchHash = cashOUT
        End If

        Dim cnt As Integer = 0
        For Each el As DictionaryEntry In switchHash
            cboTransactions.Items.Add(el.Value)
            cnt += 1
        Next

        cboTransactions.SelectedIndex = 0
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnCashIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCashIn.Click
        mainTransaction = True
        lblTrans.Text = "Cash Receipt"
        LoadTransType()
    End Sub

    Private Sub btnCashOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCashOut.Click
        mainTransaction = False
        lblTrans.Text = "Cash Disbursement"
        LoadTransType()
    End Sub

    Private Sub txtAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPost.Click
        If Not isReady() Then
            MsgBox("Unable to save transaction", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Save()
        MsgBox("Entry Saved", MsgBoxStyle.Information)
        ClearFields()
        btnCashIn.PerformClick()
    End Sub

    Private Function isReady() As Boolean
        If cboTransactions.Text = "" Then cboTransactions.Focus() : Return False
        If txtAmount.Text = "" Or CDbl(txtAmount.Text) = 0 Then txtAmount.Focus() : Return False
        If txtParticulars.Text = "" Then txtParticulars.Focus() : Return False

        Return True
    End Function

    Private Sub Save()
        Dim mySql As String = "SELECT * FROM " & fillData
        Dim ds As DataSet

        'Get Variables
        Dim cashID As Integer, tmpSQL As String
        tmpSQL = String.Format("SELECT * FROM tblCash WHERE TransName = '{0}' AND Type = '{1}'", cboTransactions.Text, IIf(mainTransaction, "RECEIPT", "DISBURSEMENT"))
        ds = LoadSQL(tmpSQL)
        cashID = ds.Tables(0).Rows(0).Item("CashID")

        ds.Clear()
        ds = LoadSQL(mySql, fillData)
        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(fillData).NewRow
        With dsNewRow
            .Item("CashID") = cashID
            .Item("Type") = IIf(mainTransaction, "RECEIPT", "DISBURSEMENT")
            .Item("TransName") = cboTransactions.Text
            .Item("Amount") = txtAmount.Text
            .Item("Remarks") = txtParticulars.Text
            .Item("TransDate") = CurrentDate
            .Item("EncoderID") = POSuser.UserID
            .Item("SystemInfo") = Now
        End With
        ds.Tables(fillData).Rows.Add(dsNewRow)

        database.SaveEntry(ds)
    End Sub

End Class