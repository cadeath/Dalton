Public Class frmCashCountV2
    Const MOD_NAME As String = "CASHCOUNT"
    Dim fillData As String = "tblCashCount"

    Friend isClosing As Boolean = False
    Private Currency_Denomination As New Hashtable
    Private Deno_Count As Integer = 0

    Private Sub frmCashCountV2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ClearFields()
        Load_Money()
        Load_Denomination()
        lblCurrent.Text = CurrentDate.ToLongDateString
    End Sub

    Private Sub Load_Denomination()
        Dim mySql As String = "SELECT * FROM tblMaintenance "
        Dim type As String = "WHERE OPT_VALUES = 'Bill'"
        Dim i As Integer = 0

        Dim ds As New DataSet
        Currency_Denomination.Clear()
        ds = LoadSQL(mySql & type)
        For Each dr As DataRow In ds.Tables(0).Rows
            Currency_Denomination.Add(dr.Item("OPT_KEYS"), dr.Item("OPT_VALUES"))
            i += 1
        Next

        type = "WHERE OPT_VALUES = 'Coin'"
        ds = LoadSQL(mySql & type)
        For Each dr As DataRow In ds.Tables(0).Rows
            Currency_Denomination.Add(dr.Item("OPT_KEYS"), dr.Item("OPT_VALUES"))
            i += 1
        Next

        Deno_Count = i
    End Sub

    Private Sub Load_Money()
        'BILLS
        Dim tblName As String = "tblMaintenance"
        Dim mySql As String = "SELECT * FROM " & tblName
        mySql &= " WHERE OPT_VALUES = 'Bill'"
        mySql &= " ORDER BY ID ASC"

        Dim ds As New DataSet
        ds = LoadSQL(mySql)
        lvCashCount.Items.Clear()

        For Each dr As DataRow In ds.Tables(0).Rows
            lvCashCount.Items.Add(dr.Item("OPT_KEYS"))
        Next

        'COINS
        mySql = "SELECT * FROM " & tblName
        mySql &= " WHERE OPT_VALUES = 'Coin'"
        mySql &= " ORDER BY ID ASC"
        ds = LoadSQL(mySql)

        For Each dr As DataRow In ds.Tables(0).Rows
            lvCashCount.Items.Add(dr.Item("OPT_KEYS"))
        Next
    End Sub

    Private Sub ClearFields()
        lvCashCount.Items.Clear()
        lblAmount.Text = "Idle"
        txtCount.Text = ""
    End Sub

    Private Sub txtCount_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCount.KeyPress
        DigitOnly(e, True)
        If isEnter(e) Then
            btnUpdate.PerformClick()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub lvCashCount_DoubleClick(sender As Object, e As System.EventArgs) Handles lvCashCount.DoubleClick
        lblAmount.Text = lvCashCount.FocusedItem.Text
        txtCount.Focus()
    End Sub

    Private Sub btnUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdate.Click
        If lvCashCount.SelectedItems.Count <= 0 Then Exit Sub

        For i = 0 To lvCashCount.Items.Count - 1
            If lvCashCount.Items(i).Text = lblAmount.Text Then
                Dim lv As ListViewItem = _
                    lvCashCount.Items(i)
                If lv.SubItems.Count = 1 Then
                    lv.SubItems.Add(txtCount.Text)
                Else
                    lvCashCount.Items(i).SubItems(1).Text = txtCount.Text
                End If
                Exit For
            End If
        Next

        txtCount.Text = ""
        lvCashCount.Focus()
    End Sub

    Private Sub lvCashCount_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvCashCount.KeyDown
        If e.KeyCode = Keys.Delete Then
            If lvCashCount.SelectedItems.Count = 0 Then Exit Sub
            If lvCashCount.SelectedItems(0).SubItems.Count = 1 Then Exit Sub

            lvCashCount.SelectedItems(0).SubItems(1).Text = ""
        End If
    End Sub

    Private Sub lvCashCount_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles lvCashCount.KeyPress


        If isEnter(e) And lvCashCount.SelectedItems.Count > 0 Then
            lvCashCount_DoubleClick(sender, e)
        End If
    End Sub

    Private Function Compute_CashCount() As Double
        Dim amt As Double
        Dim Total_CashCount As Double

        For i As Integer = 0 To lvCashCount.Items.Count - 1

            If lvCashCount.Items(i).SubItems.Count > 1 Then
                If lvCashCount.Items(i).SubItems(1).Text = "" Then _
                    Continue For

                If lvCashCount.Items(i).Text.Contains("P") Then
                    amt = CDbl(lvCashCount.Items(i).Text.Replace("P", ""))
                    amt = amt * CInt(lvCashCount.Items(i).SubItems(1).Text)
                End If
                If lvCashCount.Items(i).Text.Contains("c") Then
                    amt = CDbl(lvCashCount.Items(i).Text.Replace("c", ""))
                    amt = amt / 100
                    amt = amt * CInt(lvCashCount.Items(i).SubItems(1).Text)
                End If

                Total_CashCount += amt
            End If

        Next

        Console.WriteLine("TOTAL >>>> " & Total_CashCount)
        Return Total_CashCount
    End Function

    Private Sub btnPost_Click(sender As System.Object, e As System.EventArgs) Handles btnPost.Click
        Dim ans As DialogResult = MsgBox("Do you want to POST this cash count?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

        Dim total As Double = Compute_CashCount()
        SaveCashCount()

        If isClosing Then
            mod_system.CloseStore(total)
            frmMain.dateSet = False
            frmMain.doSegregate = False

            AddTimelyLogs(MOD_NAME, "AMOUNT TODAY IS Php " & total.ToString("#,##0.00"), False)
        End If
        Me.Close()
    End Sub

    Private Sub SaveCashCount()
        Dim mySql As String = "SELECT * FROM " & fillData
        mySql &= String.Format(" WHERE DailyID = {0} AND Status = 1", dailyID)
        Dim ds As DataSet = LoadSQL(mySql, fillData)
        Dim denoCnt As Integer = 0, denoValue As Double = 0, deno As String = ""
        Dim denoType As String = ""

        For Each dr As DataRow In ds.Tables(fillData).Rows
            dr.Item("Status") = 0
        Next
        If ds.Tables(fillData).Rows.Count > 0 Then database.SaveEntry(ds, False)

        For cnt As Integer = 0 To lvCashCount.Items.Count - 1
            denoCnt = 0 : denoValue = 0

            deno = lvCashCount.Items(cnt).Text
            If lvCashCount.Items(cnt).SubItems.Count = 1 Then _
                Continue For
            If lvCashCount.Items(cnt).SubItems(1).Text = "" Then _
                Continue For

            denoCnt = CInt(lvCashCount.Items(cnt).SubItems(1).Text)

            If Not denoCnt = 0 Then
                denoType = Currency_Denomination.Item(deno)

                If deno.Contains("P") Then
                    denoValue = CDbl(deno.Replace("P", "")) * denoCnt
                Else
                    denoValue = (CDbl(deno.Replace("c", "")) / 100) * denoCnt
                End If

                Dim dsNewRow As DataRow
                dsNewRow = ds.Tables(fillData).NewRow
                With dsNewRow
                    .Item("DailyID") = dailyID
                    .Item("Denomination") = deno
                    .Item("Cnt") = denoCnt
                    .Item("Total") = denoValue
                    .Item("EncoderID") = UserID
                    .Item("SystemTime") = Now
                    .Item("Status") = 1
                    .Item("MoneyType") = denoType.ToUpper
                End With
                ds.Tables(fillData).Rows.Add(dsNewRow)
                database.SaveEntry(ds)
            End If
        Next
    End Sub

    Private Sub UpdateCashCount(ByVal total As Double)
        Dim mySql As String = "SELECT * FROM tblDaily "
        mySql &= String.Format("WHERE ID = {0} ", dailyID)
        Dim ds As DataSet = LoadSQL(mySql, "tblDaily")

        ds.Tables("tblDaily").Rows(0).Item("CashCount") = total
        database.SaveEntry(ds, False)
        Console.WriteLine("CashCount data updated")
    End Sub

End Class