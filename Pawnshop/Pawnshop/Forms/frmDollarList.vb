Public Class frmDollarList

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    ''' <summary>
    ''' call the clearfields method.
    ''' call the loadActive method.
    ''' authorization.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmDollarList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearFields()
        LoadActive()
        txtSearch.Focus()

        'Authorization
        With POSuser
            btnVoid.Enabled = .canVoid
        End With
    End Sub
    ''' <summary>
    ''' clear the text field and combobox.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearFields()
        txtSearch.Text = ""
        lvDollar.Items.Clear()
    End Sub
    ''' <summary>
    ''' Load the dollar value to combobox.
    ''' </summary>
    ''' <param name="mySql"></param>
    ''' <remarks></remarks>
    Friend Sub LoadActive(Optional ByVal mySql As String = "SELECT * FROM tblDollar WHERE status= 'A' ORDER BY DOLLARID DESC")
        Dim ds As DataSet
        ds = LoadSQL(mySql)

        lvDollar.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim tmpDollar As New DollarTransaction
            tmpDollar.LoadDollarByRow(dr)

            AddItem(tmpDollar)
        Next
    End Sub
    ''' <summary>
    ''' Add item into listview.
    ''' </summary>
    ''' <param name="dl"></param>
    ''' <remarks></remarks>
    Private Sub AddItem(ByVal dl As DollarTransaction)
        Dim lv As ListViewItem = lvDollar.Items.Add(dl.DollarID)
        lv.SubItems.Add(dl.TransactionDate)
        lv.SubItems.Add(dl.Denomination)
        lv.SubItems.Add(dl.CurrentRate)
        lv.SubItems.Add(dl.NetAmount)
        If Not dl.Customer Is Nothing Then
            lv.SubItems.Add(dl.CustomersName)
        End If

        lv.Tag = dl.DollarID
        If dl.Status <> "A" Then lv.BackColor = Color.LightGray
        Console.WriteLine(lv.Tag & ": " & dl.CustomersName)
    End Sub
    ''' <summary>
    ''' doubleclick data in listview to view the information.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lvDollar_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvDollar.DoubleClick
        btnView.PerformClick()
    End Sub
    ''' <summary>
    ''' This button will allow to void transaction.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnVoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoid.Click
        If lvDollar.SelectedItems.Count = 0 Then Exit Sub

        Dim tmpLoad As New DollarTransaction
        Dim id As Integer = lvDollar.FocusedItem.Tag
        tmpLoad.LoadDollar(id)

        Dim ans = InputBox("What is your reason for VOIDING", "Voiding transactions")
        If ans.Length <= 10 Then MsgBox("Please input valid reason", MsgBoxStyle.Critical) : Exit Sub

        If CurrentDate.Date <> tmpLoad.TransactionDate Then
            MsgBox("You cannot void transactions in a DIFFERENT date", MsgBoxStyle.Critical)
            Exit Sub
        End If

        tmpLoad.VoidTransaction(ans)

        Dim amt As Double = tmpLoad.NetAmount
        'TODO:  For Voiding Transaction, JournalEntries must be void too.
        '       Use field STATUS with a value 0 to make it INACTIVE.

        MsgBox("Transaction #" & tmpLoad.DollarID & " void.", MsgBoxStyle.Information)
        LoadActive()
    End Sub
    ''' <summary>
    ''' This button will search the information of a client.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If txtSearch.Text = "" Then Exit Sub

        Dim mySql As String = "SELECT * FROM tblDollar WHERE "
        If IsNumeric(txtSearch.Text) Then
            mySql &= "DollarID = " & txtSearch.Text
        Else
            mySql &= String.Format("UPPER(Fullname) LIKE UPPER('%{0}%') OR ", txtSearch.Text)
            mySql &= String.Format("UPPER(Denomination) LIKE UPPER('%{0}%') OR ", txtSearch.Text)
            mySql &= String.Format("UPPER(Serial) LIKE UPPER('%{0}%')", txtSearch.Text)
        End If

        LoadActive(mySql)
    End Sub
    ''' <summary>
    ''' This keypress will go to search client information form.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If isEnter(e) Then
            btnSearch.PerformClick()
        End If
    End Sub
    ''' <summary>
    ''' This button will load the dollar value.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        If lvDollar.SelectedItems.Count = 0 Then Exit Sub

        Dim id As Integer = lvDollar.FocusedItem.Tag
        Console.WriteLine("ID: " & id)
        Dim tmpLoad As New DollarTransaction
        tmpLoad.LoadDollar(id)

        frmDollorSimple.Show()
        frmDollorSimple.LoadDollar(tmpLoad)
    End Sub

    Private Sub lvDollar_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvDollar.SelectedIndexChanged

    End Sub
End Class