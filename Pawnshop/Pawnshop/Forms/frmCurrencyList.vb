﻿Imports System.Data.Odbc
Imports System.Threading
Public Class frmCurrencyList
    Dim mOtherForm As Boolean = False

    Dim frmOrig As formSwitch.FormName
    Dim ds As New DataSet
    Dim fillData As String = "TBLCURRENCY"
    Friend GetCurrency As Currency

    Friend Sub SearchSelect(ByVal src As String, ByVal formOrigin As formSwitch.FormName)
        mOtherForm = True
        btnSelect.Visible = True
        txtSearch.Text = src
        frmOrig = formOrigin
    End Sub
    
    Friend Sub LoadActivecurrency(Optional ByVal mySql As String = "SELECT * FROM TBLCURRENCY ORDER BY CURRENCYID ASC")
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

        ClearField()
        LoadActivecurrency()
        txtSearch.Focus()

        txtSearch.Text = IIf(txtSearch.Text <> "", txtSearch.Text, "")
        If txtSearch.Text <> "" Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub AddItem(ByVal dl As Currency)
        Dim lv As ListViewItem = lvCurrency.Items.Add(dl.CURRENCYID)
        lv.SubItems.Add(dl.CURRENCY)
        lv.SubItems.Add(dl.SYMBOL)
        lv.SubItems.Add(dl.RATE)
        lv.SubItems.Add(dl.CASHID)
    End Sub

    Private Sub btnSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click
        searchbutton()
    End Sub

    Private Sub searchbutton()
        If txtSearch.Text = "" Then Exit Sub
        Dim secured_str As String = txtSearch.Text
        secured_str = DreadKnight(secured_str)

        Dim mySql As String = "SELECT * FROM TBLCURRENCY WHERE "
        If IsNumeric(txtSearch.Text) Then
            mySql &= "CURRENCYID = " & txtSearch.Text

        Else : mySql &= String.Format("UPPER (CURRENCY) LIKE UPPER('%{0}%') OR ", secured_str)
            mySql &= String.Format("UPPER (SYMBOL) LIKE UPPER('%{0}%')", secured_str)
        End If
        Console.WriteLine("SQL: " & mySql)
        Dim ds As DataSet = LoadSQL(mySql)
        Dim MaxRow As Integer = ds.Tables(0).Rows.Count
        lvCurrency.Items.Clear()
        If MaxRow <= 0 Then
            Console.WriteLine("No Currency List Found")
            MsgBox("Query not found", MsgBoxStyle.Information)
            txtSearch.SelectAll()
            lvCurrency.Items.Clear()
            Exit Sub
        End If
        MsgBox(MaxRow & " result found", MsgBoxStyle.Information, "Search Currency")
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
        If mOtherForm Then
            btnSelect.PerformClick()
            Me.Hide()
        End If
    End Sub
    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btnSelect_Click(sender As System.Object, e As System.EventArgs) Handles btnSelect.Click
        If lvCurrency.Items.Count = 0 Then Exit Sub

        If lvCurrency.SelectedItems.Count = 0 Then
            lvCurrency.Items(0).Focused = True
        End If
        Dim idx As Integer = CInt(lvCurrency.FocusedItem.Text)
        GetCurrency = New Currency
        GetCurrency.LoadCurrencydata(idx)
        formSwitch.ReloadFormFromSearch1(frmOrig, GetCurrency)
        Me.Close()
    End Sub
    

    Private Sub txtSearch_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()
        End If
    End Sub

    Friend Sub AutoSelect1(ByVal cr As Currency)
        If Not mOtherForm Then
            txtSearch.Text = cr.CURRENCY
            Exit Sub
        End If
        formSwitch.ReloadFormFromSearch1(frmOrig, cr)
        Me.Close()
    End Sub

    Private Sub btnClose_Click_1(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub lvCurrency_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles lvCurrency.KeyDown
        If e.KeyCode = Keys.Enter Then
            If mOtherForm Then
                btnSelect.PerformClick()
            End If
        End If
    End Sub
End Class