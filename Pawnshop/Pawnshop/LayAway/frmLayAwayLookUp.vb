Public Class frmLayAwayLookUp

    Private Sub frmLayAwayLookUp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearFields()
        LoadInfo()
    End Sub

    Private Sub ClearFields()
        lvLayAway.Items.Clear()
    End Sub

    Friend Sub LoadInfo(Optional ByVal Search As String = "")
        Dim mysql As String, Name As String
        Dim strWords As String() = Search.Split(New Char() {" "c})
        If Search <> "" Then
            mysql = "Select LY.LAYID, LY.DOCDATE, LY.FORFEITDATE, C.ID, C.FIRSTNAME || ' ' || C.LASTNAME || ' ' || CASE WHEN C.SUFFIX is Null THEN '' ELSE C.SUFFIX END AS FULLNAME, "
            mysql &= "LY.ITEMCODE, ITM.DESCRIPTION , LY.PRICE, LY.STATUS, "
            mysql &= "LY.BALANCE "
            mysql &= "From TBLLAYAWAY LY "
            mysql &= "INNER JOIN " & CUSTOMER_TABLE & " C ON C.ID = LY.CUSTOMERID "
            mysql &= "INNER JOIN ITEMMASTER ITM ON ITM.ITEMCODE = LY.ITEMCODE "
            mysql &= "WHERE LY.STATUS = '1' "
            mysql &= "AND  UPPER(LY.ITEMCODE) LIKE UPPER('%" & Search & "%') OR"

            For Each Name In strWords

                mysql &= vbCr & " UPPER(C.FIRSTNAME || ' ' || C.LASTNAME || ' ' || C.SUFFIX) LIKE UPPER('%" & Name & "%') and "
                If Name Is strWords.Last Then
                    mysql &= vbCr & " UPPER(C.FIRSTNAME || ' ' || C.LASTNAME || ' ' || C.SUFFIX) LIKE UPPER('%" & Name & "%') "
                    Exit For
                End If

            Next
        Else
            mysql = "Select First 50 LY.LAYID, LY.DOCDATE, LY.FORFEITDATE, C.ID, C.FIRSTNAME || ' ' || C.LASTNAME || ' ' || CASE WHEN C.SUFFIX is Null THEN '' ELSE C.SUFFIX END AS FULLNAME, "
            mysql &= "LY.ITEMCODE, ITM.DESCRIPTION , LY.PRICE, LY.STATUS, "
            mysql &= "LY.BALANCE "
            mysql &= "From TBLLAYAWAY LY "
            mysql &= "INNER JOIN " & CUSTOMER_TABLE & " C ON C.ID = LY.CUSTOMERID "
            mysql &= "INNER JOIN ITEMMASTER ITM ON ITM.ITEMCODE = LY.ITEMCODE "
            mysql &= "WHERE LY.STATUS = '1' AND LY.BALANCE <> 0 "
        End If
        Dim ds As DataSet = LoadSQL(mysql)
        lvLayAway.Items.Clear()

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
            Dim lv As ListViewItem = lvLayAway.Items.Add(.Item("LayID"))
            lv.SubItems.Add(.Item("DocDate"))
            lv.SubItems.Add(.Item("FORFEITDATE"))
            lv.SubItems.Add(.Item("FULLNAME"))
            lv.SubItems.Add(.Item("ITEMCODE"))
            lv.SubItems.Add(.Item("DESCRIPTION"))
            lv.SubItems.Add(.Item("PRICE"))
            lv.SubItems.Add(.Item("BALANCE"))
            lv.Tag = .Item("ITEMCODE")
            lv.Text = .Item("LayID")

            If .Item("BALANCE") = 0 Then lv.BackColor = Color.Red
            If .Item("Status") = "V" Then lv.BackColor = Color.Gray
        End With
    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        If lvLayAway.SelectedItems.Count = 0 Then Exit Sub
        If lvLayAway.FocusedItem.SubItems(6).Text = 0 Then Exit Sub

        Dim itmCode As String = lvLayAway.FocusedItem.Tag
            frmLayAway.Show()
            frmLayAway.LoadExistInfo(itmCode)
            Me.Close()
    End Sub

    Private Sub lvLayAway_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvLayAway.DoubleClick
        btnSelect.PerformClick()
    End Sub

    Private Sub btnVoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoid.Click
        If lvLayAway.SelectedItems.Count = 0 Then Exit Sub
        'If Not OTPDisable Then
        '    diagOTP.FormType = diagOTP.OTPType.VoidLayAway
        '    If Not CheckOTP() Then Exit Sub
        'Else
        '    VoidLayAway()
        'End If

        OTPVoiding_Initialization()

        If Not isOTPOn("Voiding") Then
            diagGeneralOTP.GeneralOTP = OtpSettings
            diagGeneralOTP.TopMost = True
            diagGeneralOTP.ShowDialog()
            If Not diagGeneralOTP.isValid Then
                Exit Sub
            Else
                VoidLayAway()
            End If
        Else
            VoidLayAway()
        End If


    End Sub

    Friend Sub VoidLayAway()
        Dim idx As Integer = lvLayAway.FocusedItem.Text

        Dim layAwy As New LayAway
        layAwy.LoadByID(idx)

        Dim ans As DialogResult = MsgBox("Do You Want To Void This Transaction?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

        If layAwy.DocDate <> CurrentDate.ToShortDateString Then
            MsgBox("You Cannot Void Transaction in a Different Date", MsgBoxStyle.Critical)
            Exit Sub
        End If

        layAwy.VoidLayAway()
        layAwy.ItemOnLayMode(layAwy.ItemCode, False)
        MsgBox("Transaction Voided", MsgBoxStyle.Information)
        Me.Close()
    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        frmUploadLay.Show()
    End Sub

    Private Sub txtSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If isEnter(e) Then
            btnSearch.PerformClick()
        End If
    End Sub
End Class