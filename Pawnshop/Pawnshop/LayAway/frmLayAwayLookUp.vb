Public Class frmLayAwayLookUp

    Private Sub frmLayAwayLookUp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearFields()
    End Sub

    Private Sub ClearFields()
        lvLayAway.Items.Clear()
    End Sub

    Friend Sub LoadInfo(Optional ByVal Search As String = "")
        Dim mysql As String
        If Search <> "" Then
            mysql = "Select LY.LAYID, LY.DOCDATE, C.CLIENTID, C.FIRSTNAME || ' ' || C.LASTNAME || ' ' || C.SUFFIX AS FULLNAME, "
            mysql &= "C.ADDR_STREET || ' ' || C.ADDR_CITY || ' ' || C.ADDR_PROVINCE || ' ' || C.ADDR_ZIP as FULLADDRESS, "
            mysql &= "C.PHONE1 AS CONTACTNUMBER, C.BIRTHDAY, "
            mysql &= "LY.ITEMCODE, ITM.DESCRIPTION , LY.PRICE, LY.STATUS, LYL.DOCDATE AS DATEPAYMENT, LYL.AMOUNT, "
            mysql &= "LY.BALANCE, LYL.STATUS AS LINESTATUS, LYL.PENALTY "
            mysql &= "From TBLLAYAWAY LY "
            mysql &= "INNER JOIN TBLCLIENT C ON C.CLIENTID = LY.CUSTOMERID "
            mysql &= "INNER JOIN TBLLAYLINES LYL ON LYL.LAYID = LY.LAYID "
            mysql &= "INNER JOIN ITEMMASTER ITM ON ITM.ITEMCODE = LY.ITEMCODE "
            mysql &= "WHERE LYL.STATUS <> 'V' "
            mysql &= "AND (FULLNAME = '" & Search & "' OR LY.ITEMCODE = '" & Search & "')"
        Else
            mysql = "Select FIRST 50 LY.LAYID, LY.DOCDATE, C.CLIENTID, C.FIRSTNAME || ' ' || C.LASTNAME || ' ' || C.SUFFIX AS FULLNAME, "
            mysql &= "C.ADDR_STREET || ' ' || C.ADDR_CITY || ' ' || C.ADDR_PROVINCE || ' ' || C.ADDR_ZIP as FULLADDRESS, "
            mysql &= "C.PHONE1 AS CONTACTNUMBER, C.BIRTHDAY, "
            mysql &= "LY.ITEMCODE, ITM.DESCRIPTION , LY.PRICE, LY.STATUS, LYL.DOCDATE AS DATEPAYMENT, LYL.AMOUNT, "
            mysql &= "LY.BALANCE, LYL.STATUS AS LINESTATUS, LYL.PENALTY "
            mysql &= "From TBLLAYAWAY LY "
            mysql &= "INNER JOIN TBLCLIENT C ON C.CLIENTID = LY.CUSTOMERID "
            mysql &= "INNER JOIN TBLLAYLINES LYL ON LYL.LAYID = LY.LAYID "
            mysql &= "INNER JOIN ITEMMASTER ITM ON ITM.ITEMCODE = LY.ITEMCODE "
            mysql &= "WHERE LYL.STATUS <> 'V' "
        End If

        Dim ds As DataSet = LoadSQL(mysql)

        For Each dr In ds.Tables(0).Rows()
            AddlvItems(dr)
        Next

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

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        frmLayAway.Show()
        Me.Close()
    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        If lvLayAway.SelectedItems.Count = 0 Then Exit Sub
        Dim idx As Integer = lvLayAway.FocusedItem.Tag
        frmLayAway.Show()
        frmLayAway.LoadExistInfo(idx)
        Me.Close()
    End Sub
End Class