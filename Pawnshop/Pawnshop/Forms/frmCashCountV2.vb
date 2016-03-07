Public Class frmCashCountV2

    Friend isClosing As Boolean = False

    Private Sub frmCashCountV2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ClearFields()
        Load_Money()
        lblCurrent.Text = CurrentDate.ToLongDateString
    End Sub

    Private Sub Load_Money()
        'BILLS
        Dim fillData As String = "tblMaintenance"
        Dim mySql As String = "SELECT * FROM " & fillData
        mySql &= " WHERE OPT_VALUES = 'Bill'"
        mySql &= " ORDER BY ID ASC"

        Dim ds As New DataSet
        ds = LoadSQL(mySql)
        lvCashCount.Items.Clear()

        For Each dr As DataRow In ds.Tables(0).Rows
            lvCashCount.Items.Add(dr.Item("OPT_KEYS"))
        Next

        'COINS
        mySql = "SELECT * FROM " & fillData
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
        DigitOnly(e)
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
        For i = 0 To lvCashCount.Items.Count - 1
            If lvCashCount.SelectedItems(i).Text = lblAmount.Text Then
                Dim lv As ListViewItem = lvCashCount.SelectedItems(i)
                lv.SubItems.Add(txtCount.Text)
                Exit For
            End If
        Next

        txtCount.Text = ""
        lvCashCount.Focus()
    End Sub

    Private Sub lvCashCount_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles lvCashCount.KeyPress
        If isEnter(e) Then
            lvCashCount_DoubleClick(sender, e)
        End If
    End Sub

    Private Function Compute_CashCount() As Double
        Dim amt As Double
        Dim Total_CashCount As Double

        For i As Integer = 0 To lvCashCount.Items.Count - 1


            If lvCashCount.SelectedItems(i).Text.Contains("P") Then
                amt = CDbl(lvCashCount.SelectedItems(i).Text.Replace("P", ""))
            End If
            If lvCashCount.SelectedItems(i).Text.Contains("c") Then
                amt = CDbl(lvCashCount.SelectedItems(i).Text.Replace("c", ""))
                amt = amt / 100
            End If

            Total_CashCount = +amt
        Next

        Return Total_CashCount
    End Function

    Private Sub btnPost_Click(sender As System.Object, e As System.EventArgs) Handles btnPost.Click



        If isClosing Then
            'mod_system.CloseStore(total)
            frmMain.dateSet = False
            frmMain.doSegregate = False
        End If
    End Sub
End Class