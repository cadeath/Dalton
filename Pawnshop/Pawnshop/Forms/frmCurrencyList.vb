Imports System.Data.Odbc
Public Class frmCurrencyList
    Dim conn As OdbcConnection
    Dim cmd As OdbcCommand
    Dim da As OdbcDataAdapter

    Dim itemcoll(100) As String

    Dim mOtherForm As Boolean = False
    Dim frmOrig As formSwitch.FormName
    Dim ds As New DataSet

    Friend Sub SearchSelect(ByVal src As String, ByVal formOrigin As formSwitch.FormName)
        mOtherForm = True
        btnSelect.Visible = True
        txtSearch.Text = src
        frmOrig = formOrigin
    End Sub
    'Friend Sub Loadcurrency()


    '    If lvCurrency.InvokeRequired Then
    '        lvCurrency.Invoke(New LoadallCurrency(AddressOf Loadcurrency))
    '    Else
    '        lvCurrency.Enabled = False
    '        lvCurrency.BackColor = Color.White
    '        btnView.Enabled = False
    '        txtSearch.ReadOnly = True
    '        btnSearch.Enabled = False

    '        Me.Enabled = False

    '        Dim tbl As String = "TBLCURRENCY"
    '        Dim mySql As String = String.Format("SELECT * FROM  TBLCURRENCY ORDER BY CURRENCY ASC", tbl)
    '        Dim ds As DataSet = LoadSQL(mySql, tbl)

    '        lvCurrency.Items.Clear()
    '        For Each pawner As DataRow In ds.Tables(0).Rows
    '            Dim tmpCurrency As New Currency
    '            tmpCurrency.LoadCurrency(pawner.Item("CURRENCYID"))
    '            AddItem(tmpCurrency)

    '            Application.DoEvents()
    '        Next

    '        lvCurrency.Enabled = True
    '        btnView.Enabled = True
    '        txtSearch.ReadOnly = False
    '        btnSearch.Enabled = True

    '        Me.Enabled = True
    '    End If
    'End Sub
    Friend Sub LoadActivecurrency(Optional ByVal mySql As String = "SELECT * FROM TBLCURRENCY WHERE DENOMINATION ='1' ORDER BY CURRENCYID")
        Dim ds As DataSet
        ds = LoadSQL(mySql)
        lvCurrency.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim tmpCurrency As New Currency
            tmpCurrency.LoadCurrencyByRow(dr)
            AddItem(tmpCurrency)
        Next
    End Sub
    Private Sub frmCurrencyList_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
     
        LoadActivecurrency()
        txtSearch.Focus()

        txtSearch.Text = IIf(txtSearch.Text <> "", txtSearch.Text, "")
        If txtSearch.Text <> "" Then
            btnSearch.PerformClick()
        End If
    End Sub
    Private Sub AddItem(ByVal d As Currency)
        Dim lv As ListViewItem = lvCurrency.Items.Add(d.CURRENCYID)
        lv.SubItems.Add(d.CURRENCY)
        lv.SubItems.Add(d.SYMBOL)
        lv.SubItems.Add(d.DENOMINATION)
        lv.SubItems.Add(d.RATE)
    End Sub
    Private Sub btnSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click
        If txtSearch.Text = "" Then Exit Sub
        Dim mySql As String = "SELECT * FROM TBLCURRENCY WHERE "
        If IsNumeric(txtSearch.Text) Then
            mySql &= "CURRENCYID = " & txtSearch.Text
        Else
            mySql &= String.Format("UPPER(CURRENCY) LIKE UPPER('%{0}%') OR ", txtSearch.Text)
            mySql &= String.Format("UPPER(SYMBOL) LIKE UPPER('%{0}%') OR ", txtSearch.Text)
        End If
        LoadActivecurrency(mySql)
    End Sub

    Private Sub ClearField()
        txtSearch.Text = ""
        lvCurrency.Items.Clear()
    End Sub


    Private Sub txtSearch_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If isEnter(e) Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub lvCurrency_DoubleClick(sender As System.Object, e As System.EventArgs) Handles lvCurrency.DoubleClick
        If Not mOtherForm Then
            btnView.PerformClick()
        Else
            btnSelect.PerformClick()
        End If
    End Sub
#Region "Connection"
    Public Sub dbOpen()
        conStr = "DRIVER=Firebird/InterBase(r) driver;User=" & fbUser & ";Password=" & fbPass & ";Database=" & dbName & ";"

        con = New OdbcConnection(conStr)
        Try
            con.Open()
        Catch ex As Exception
            con.Dispose()
            Log_Report(ex.Message.ToString)
            Log_Report(String.Format("User: {0}", fbUser))
            Log_Report(String.Format("Database: {0}", dbName))
            Exit Sub
        End Try
    End Sub
    Friend Function LoadSQL(ByVal mySql As String, Optional ByVal tblName As String = "QuickSQL") As DataSet
        dbOpen() 'open the database.

        Dim da As OdbcDataAdapter
        Dim ds As New DataSet, fillData As String = tblName
        Try
            da = New OdbcDataAdapter(mySql, con)
            da.Fill(ds, fillData)
        Catch ex As Exception
            Console.WriteLine(">>>>>" & mySql)
            MsgBox(ex.ToString)
            Log_Report("LoadSQL - " & ex.ToString)
            ds = Nothing
        End Try

        dbClose()

        Return ds
    End Function
    Friend Function LoadSQL_byDataReader(ByVal mySql As String) As OdbcDataReader
        Dim myCom As OdbcCommand = New OdbcCommand(mySql, ReaderCon)
        Dim reader As OdbcDataReader = myCom.ExecuteReader()

        Return reader
    End Function

#End Region

    Private Sub btnView_Click(sender As System.Object, e As System.EventArgs) Handles btnView.Click
        If lvCurrency.SelectedItems.Count = 0 Then Exit Sub

        Dim id As Integer = lvCurrency.FocusedItem.Tag
        Console.WriteLine("ID: " & id)
        Dim tmpLoadcur As New Currency
        tmpLoadcur.LoadCurrencydata(id)

        frmmoneyexchange.Show()
        frmmoneyexchange.Loadcurrencyy(tmpLoadcur)
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs)
        Me.Close()
    End Sub
End Class