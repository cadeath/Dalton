Public Class frmLayAwayLookUp

    Private Sub frmLayAwayLookUp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearFields()
    End Sub

    Private Sub ClearFields()
        lvLayAway.Items.Clear()
    End Sub

    Friend Sub LoadInfo(Optional ByVal Search As String = "")
        Dim mysql As String = "Select LY.LAYID, LY.DOCDATE, C.CLIENTID, C.FIRSTNAME || ' ' || C.LASTNAME || ' ' || C.SUFFIX AS FULLNAME, "
        mysql &= "C.ADDR_STREET || ' ' || C.ADDR_CITY || ' ' || C.ADDR_PROVINCE || ' ' || C.ADDR_ZIP as FULLADDRESS, "
        mysql &= "C.PHONE1 AS CONTACTNUMBER, C.BIRTHDAY, "
        mysql &= "LY.ITEMCODE, ITM.DESCRIPTION , LY.PRICE, LY.STATUS, "
        mysql &= "LY.BALANCE "
        mysql &= "From TBLLAYAWAY LY "
        mysql &= "INNER JOIN TBLCLIENT C ON C.CLIENTID = LY.CUSTOMERID "
        mysql &= "INNER JOIN ITEMMASTER ITM ON ITM.ITEMCODE = LY.ITEMCODE "
        mysql &= "WHERE LY.STATUS <> '0' "
        If Search <> "" Then mysql &= "AND (FULLNAME = '" & Search & "' OR LY.ITEMCODE = '" & Search & "')"


        Dim ds As DataSet = LoadSQL(mysql)

        For Each dr In ds.Tables(0).Rows()
            AddlvItems(dr)
        Next
        Dim rowCount As Integer = ds.Tables(0).Rows.Count
        MsgBox(rowCount & " Found", MsgBoxStyle.Information, "Lay Away")
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
End Class