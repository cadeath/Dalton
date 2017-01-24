Public Class frmLayAwayLookUp

    Private Sub frmLayAwayLookUp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearFields()
        LoadInfo()
    End Sub

    Private Sub ClearFields()
        lvLayAway.Items.Clear()
    End Sub

    Friend Sub LoadInfo(Optional ByVal Search As String = "")
        Dim mysql As String
        If Search <> "" Then
            mysql = "Select LY.LAYID, LY.DOCDATE, C.CLIENTID, C.FIRSTNAME || ' ' || C.LASTNAME || ' ' || C.SUFFIX AS FULLNAME, "
            mysql &= "LY.ITEMCODE, ITM.DESCRIPTION , LY.PRICE, LY.STATUS, "
            mysql &= "LY.BALANCE "
            mysql &= "From TBLLAYAWAY LY "
            mysql &= "INNER JOIN TBLCLIENT C ON C.CLIENTID = LY.CUSTOMERID "
            mysql &= "INNER JOIN ITEMMASTER ITM ON ITM.ITEMCODE = LY.ITEMCODE "
            mysql &= "WHERE LY.STATUS <> '0' "
            mysql &= "AND (FULLNAME = '" & Search & "' OR LY.ITEMCODE = '" & Search & "')"
        Else
            mysql = "Select First 50 LY.LAYID, LY.DOCDATE, C.CLIENTID, C.FIRSTNAME || ' ' || C.LASTNAME || ' ' || C.SUFFIX AS FULLNAME, "
            mysql &= "LY.ITEMCODE, ITM.DESCRIPTION , LY.PRICE, LY.STATUS, "
            mysql &= "LY.BALANCE "
            mysql &= "From TBLLAYAWAY LY "
            mysql &= "INNER JOIN TBLCLIENT C ON C.CLIENTID = LY.CUSTOMERID "
            mysql &= "INNER JOIN ITEMMASTER ITM ON ITM.ITEMCODE = LY.ITEMCODE "
            mysql &= "WHERE LY.STATUS <> '0'"
        End If
        Dim ds As DataSet = LoadSQL(mysql)

        For Each dr In ds.Tables(0).Rows()
            AddlvItems(dr)
        Next
        Dim rowCount As Integer = ds.Tables(0).Rows.Count
        If Search <> "" Then MsgBox(rowCount & " Found", MsgBoxStyle.Information, "Lay Away")
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim unsec_src As String = txtSearch.Text

        LoadInfo(DreadKnight(unsec_src))
    End Sub

    Private Sub AddlvItems(ByVal dr As DataRow)
        With dr
            Dim lv As ListViewItem = lvLayAway.Items.Add(.Item("DocDate"))

            lv.SubItems.Add(.Item("FULLNAME"))
            lv.SubItems.Add(.Item("ITEMCODE"))
            lv.SubItems.Add(.Item("DESCRIPTION"))
            lv.SubItems.Add(.Item("PRICE"))
            lv.SubItems.Add(.Item("BALANCE"))
            lv.Tag = .Item("LAYID")
        End With
    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        If lvLayAway.SelectedItems.Count = 0 Then Exit Sub
        Dim idx As Integer = lvLayAway.FocusedItem.Tag
        frmLayAway.Show()
        frmLayAway.LoadExistInfo(idx)
        Me.Close()
    End Sub

    Private Sub lvLayAway_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvLayAway.DoubleClick
        btnSelect.PerformClick()
    End Sub

    Private Sub btnVoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoid.Click
        If lvLayAway.SelectedItems.Count = 0 Then Exit Sub
        Dim idx As Integer = lvLayAway.FocusedItem.Tag

        Dim layAwy As New LayAway
        layAwy.LoadByID(idx)

        Dim ans As DialogResult = MsgBox("Do You Want To Void This Transaction?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

        If layAwy.DocDate <> CurrentDate.ToShortDateString Then
            MsgBox("You Cannot Void Transaction in a Different Date", MsgBoxStyle.Critical)
            Exit Sub
        End If

        layAwy.InActiveStatus()
        layAwy.ItemOnLayMode(layAwy.ItemCode, False)
        MsgBox("Transaction Voided", MsgBoxStyle.Information)
        Me.Close()
    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        frmUploadLay.Show()
    End Sub
End Class