Public Class frmInsuranceList
    Private fromOtherForm As Boolean = False
    Private frmOrig As formSwitch.FormName
    Private Coi As Insurance

    Private Sub frmInsuranceList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ClearFields()
        'LoadInsurance()
        lvInsurance.Items.Clear()

        If Not fromOtherForm Then ClearFields() : txtSearch.Focus()
        txtSearch.Text = IIf(txtSearch.Text <> "", txtSearch.Text, "")
        If txtSearch.Text <> "" Then
            btnSearch.PerformClick()
        Else
            LoadInsurance()
        End If

    End Sub

    Friend Sub SearchSelect(ByVal src As String, ByVal frmOrigin As formSwitch.FormName)
        fromOtherForm = True
        txtSearch.Text = src
        frmOrig = frmOrigin
    End Sub

    ''' <summary>
    ''' this method load the information of a client
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadInsurance()

        Dim mySql As String = "SELECT FIRST 50 * FROM tblInsurance WHERE Status LIKE 'A' ORDER BY TRANSDATE DESC"

        Dim ds As DataSet = LoadSQL(mySql)

        For Each ins In ds.Tables(0).Rows
            Dim loadInsu As New Insurance
            loadInsu.LoadByRow(ins)
            AddItem(loadInsu)
        Next
    End Sub
    ''' <summary>
    ''' This method will add item to listview.
    ''' </summary>
    ''' <param name="ins"></param>
    ''' <remarks></remarks>
    Private Sub AddItem(ByVal ins As Insurance)
        Dim lv As ListViewItem = lvInsurance.Items.Add(ins.COInumber)
        lv.SubItems.Add(ins.TransactionDate)
        lv.SubItems.Add(ins.ClientName)
        lv.SubItems.Add(ins.ValidDate)
        lv.SubItems.Add(ins.TicketNum)
        lv.Tag = ins.ID
        If ins.Status = "V" Then lv.BackColor = Color.LightGray
    End Sub
    ''' <summary>
    ''' This method will clear the textfield and listview.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearFields()
        txtSearch.Text = ""
        lvInsurance.Items.Clear()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    ''' <summary>
    ''' This button will view the client information from client management form to certificate of insurance form.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        If Not lvInsurance.SelectedItems.Count > 0 Then Exit Sub

        Dim idx As Integer = lvInsurance.FocusedItem.Tag
        'frmInsurance.LoadInsurance(idx)
        'Me.Close()
        Coi = New Insurance
        Coi.LoadInsurance(idx)
        formSwitch.ReloadFormFromInsurance(frmOrig, Coi)
        Me.Close()
    End Sub
    ''' <summary>
    ''' This button allow to search the client information.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If txtSearch.Text.Length <= 3 Then
            MsgBox("3 Characters Below Not Allowed.", MsgBoxStyle.Exclamation, "Client Search")
        Else
            Dim secured_str As String = txtSearch.Text
            secured_str = DreadKnight(secured_str)

            Dim mySql As String = "SELECT * FROM tblInsurance WHERE "
            If IsNumeric(txtSearch.Text) Then mySql &= "COINO = " & secured_str & " OR "
            mySql &= String.Format("LOWER(CLIENTNAME) LIKE LOWER('%{0}%')", secured_str)

            Console.WriteLine(mySql)
            lvInsurance.Items.Clear()
            Dim ds As DataSet = LoadSQL(mySql)
            For Each ins In ds.Tables(0).Rows
                Dim loadInsu As New Insurance
                loadInsu.LoadByRow(ins)
                AddItem(loadInsu)
            Next

            MsgBox(ds.Tables(0).Rows.Count & " item found.", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub txtSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If isEnter(e) Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub lvInsurance_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvInsurance.DoubleClick
        btnView.PerformClick()
    End Sub

    Private Sub lvInsurance_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles lvInsurance.MouseClick
        If lvInsurance.SelectedItems.Count = 0 Then Exit Sub

        Dim idx As Integer = lvInsurance.FocusedItem.Tag
        Dim tmpMT As New Insurance
        lbltransID.Text = idx
    End Sub
End Class