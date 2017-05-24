Public Class frmDollarList
    'Private OTPDisable As Boolean = IIf(GetOption("OTP") = "YES", True, False)

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
        If frmmoneyexchange.AccessType <> "Full Access" Then
            btnVoid.Enabled = False
        Else
            btnVoid.Enabled = True
        End If
    End Sub
    ''' <summary>
    ''' clear the text field and listview
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearFields()
        txtSearch.Text = ""
        lvDollar.Items.Clear()
    End Sub
    ''' <summary>
    ''' Load the dollar value to listview.
    ''' </summary>
    ''' <param name="mySql"></param>
    ''' <remarks></remarks>
    Friend Sub LoadActive(Optional ByVal mySql As String = "SELECT FIRST 50 * FROM tblDollar WHERE status= 'A' ORDER BY DOLLARID DESC")
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
        lv.SubItems.Add(dl.TransactionDate.ToString("MMM dd, yyyy"))
        lv.SubItems.Add(dl.Denomination)
        lv.SubItems.Add(String.Format("{0:#,##0.00}", dl.CurrentRate))
        lv.SubItems.Add(String.Format("{0:#,##0.00}", dl.NetAmount))
        lv.SubItems.Add(dl.CustomersName)
        lv.SubItems.Add(dl.CURRENCY)
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
        'If Not OTPDisable Then
        '    diagOTP.FormType = diagOTP.OTPType.VoidMoneyExchange
        '    If Not CheckOTP() Then Exit Sub
        'Else
        '    VoidMoneyExchange()
        'End If

        OTPVoiding_Initialization()

        If Not isOTPOn("Voiding") Then
            diagGeneralOTP.GeneralOTP = OtpSettings
            diagGeneralOTP.TopMost = True
            diagGeneralOTP.ShowDialog()
            If Not diagGeneralOTP.isValid Then
                Exit Sub
            Else
                VoidMoneyExchange()
            End If
        Else
            VoidMoneyExchange()
        End If
    End Sub
    Friend Sub VoidMoneyExchange()
        Dim tmpLoad As New DollarTransaction
        Dim id As Integer = lvDollar.FocusedItem.Tag
        tmpLoad.LoadDollar(id)

        Dim ans = InputBox("What is your reason for VOIDING", "Voiding transactions")
        If ans.Length <= 10 Then MsgBox("Please input valid reason", MsgBoxStyle.Critical) : Exit Sub

        If CurrentDate.Date <> tmpLoad.TransactionDate Then
            MsgBox("You cannot void transactions in a DIFFERENT date", MsgBoxStyle.Critical)
            Exit Sub
        End If
        Dim filldata As String = "TBLDOLLAR"
        Dim mysql As String = "SELECT * FROM " & filldata & " WHERE DOLLARID = '" & id & "'"
        Dim ds As DataSet = LoadSQL(mysql)
        Dim tmpEncoderID As Integer
        tmpEncoderID = ds.Tables(0).Rows(0).Item("UserId")

        Dim NewOtp As New ClassOtp("VOID DOLLAR", diagGeneralOTP.txtPIN.Text, "DollarID# " & id)
        TransactionVoidSave("DOLLAR BUYING", tmpEncoderID, SystemUser.ID, "DollarID# " & id & " " & ans)
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
        If txtSearch.Text.Length <= 3 Then
            MsgBox("3 Characters Below Not Allowed.", MsgBoxStyle.Exclamation, "Client Search")
        Else
            Dim secured_str As String = txtSearch.Text
            secured_str = DreadKnight(secured_str)

            Dim mySql As String = "SELECT * FROM tblDollar WHERE "
            If IsNumeric(secured_str) Then
                mySql &= "DollarID = " & secured_str
            Else : mySql &= String.Format("UPPER(Fullname) LIKE UPPER('%{0}%') OR ", secured_str)
                mySql &= String.Format("UPPER(Denomination) LIKE UPPER('%{0}%') OR ", secured_str)
                mySql &= String.Format("UPPER(Serial) LIKE UPPER('%{0}%') OR ", secured_str)
                mySql &= String.Format("UPPER(CURRENCY) LIKE UPPER('%{0}%')", secured_str)
            End If
            Dim ds As DataSet = LoadSQL(mySql)
            Console.WriteLine("SQL: " & mySql)
            Dim MaxRow As Integer = ds.Tables(0).Rows.Count
            'lvCIO.Items.Clear()
            If MaxRow <= 0 Then
                MsgBox("Query not found", MsgBoxStyle.Information)
                txtSearch.SelectAll()
                lvDollar.Items.Clear()
                Exit Sub
            End If
            MsgBox(MaxRow & " result found", MsgBoxStyle.Information, "Search Currency")
            LoadActive(mySql)
        End If
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
        frmmoneyexchange.Show()
        frmmoneyexchange.LoadTransDollar(tmpLoad)
    End Sub

    Private Sub lvDollar_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles lvDollar.MouseClick
        Dim tmpLoad As New DollarTransaction
        Dim id As Integer = lvDollar.FocusedItem.Tag
        tmpLoad.LoadDollar(id)
        lblDollarID.Text = id
    End Sub
End Class