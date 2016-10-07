Public Class Dev_Migrate

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        UpdateScheme()
    End Sub

    Private Sub UpdateScheme()

        Dim mysql As String = "Select * from tblPawn"
        Dim filldata As String = "tblPawn"
        Dim ds As DataSet = LoadSQL(mysql, filldata)

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim tmpPawnID As String = dr.Item("PawnID")
            Dim tmpItemType As String = dr.Item("ItemType")
            Dim tmpIntcheckSum As String
            If Not IsDBNull(dr.Item("int_checksum")) Then tmpIntcheckSum = dr.Item("int_checksum")
            Console.WriteLine("PawnID is : " & tmpPawnID & " ItemType is : " & tmpItemType & " Intchecksum is : " & tmpIntcheckSum)
            Dim tmpSchemeID As String = GetInt(tmpItemType, tmpIntcheckSum)

            Dim mysql2 As String = "Select * from OPI where PawnItemID = '" & tmpPawnID & "'"
            Dim filldata2 As String = "OPI"
            Dim ds2 As DataSet = LoadSQL(mysql2, filldata2)
            ' Dim FinalSchemeID As Integer = 0

            'With Early Redeem
            'If tmpSchemeID = "0.03" And tmpIntcheckSum = "2UeDR8f2bFX1c+rsLG8v7g==" Then
            '    FinalSchemeID = 6

            'ElseIf tmpSchemeID = "0.04" And tmpIntcheckSum = "2UeDR8f2bFX1c+rsLG8v7g==" Then
            '    FinalSchemeID = 7

            'ElseIf tmpSchemeID = "0.05" And tmpIntcheckSum = "2UeDR8f2bFX1c+rsLG8v7g==" Then
            '    FinalSchemeID = 8

            'ElseIf tmpSchemeID = "0.03" And tmpIntcheckSum = "aWFXwwYbqLmins1KPvmmIw==" Then
            '    FinalSchemeID = 6

            'ElseIf tmpSchemeID = "0.05" And tmpIntcheckSum = "aWFXwwYbqLmins1KPvmmIw==" Then
            '    FinalSchemeID = 8

            'ElseIf tmpSchemeID = "0.06" And tmpIntcheckSum = "aWFXwwYbqLmins1KPvmmIw==" Then
            '    FinalSchemeID = 9

            'ElseIf tmpSchemeID = "0.05" And tmpIntcheckSum = "Vw4p+Hj+9pc/U1EYpf8ffA==" Then
            '    FinalSchemeID = 8

            'ElseIf tmpSchemeID = "0.06" And tmpIntcheckSum = "Vw4p+Hj+9pc/U1EYpf8ffA==" Then
            '    FinalSchemeID = 9
            '    'Without Early Redeem
            'ElseIf tmpSchemeID = "0.05" And tmpIntcheckSum = "6zixr/PwMkDjdRTSktCeJA==" Then
            '    FinalSchemeID = 3

            'ElseIf tmpSchemeID = "0.06" And tmpIntcheckSum = "6zixr/PwMkDjdRTSktCeJA==" Then
            '    FinalSchemeID = 4

            'ElseIf tmpSchemeID = "0.07" And tmpIntcheckSum = "6zixr/PwMkDjdRTSktCeJA==" Then
            '    FinalSchemeID = 5

            'ElseIf tmpSchemeID = "0.04" And tmpIntcheckSum = "H8o+NbYmV80tU9Zsk+3Vag==" Then
            '    FinalSchemeID = 2

            'ElseIf tmpSchemeID = "0.05" And tmpIntcheckSum = "H8o+NbYmV80tU9Zsk+3Vag==" Then
            '    FinalSchemeID = 3

            'ElseIf tmpSchemeID = "0.06" And tmpIntcheckSum = "H8o+NbYmV80tU9Zsk+3Vag==" Then
            '    FinalSchemeID = 4

            'ElseIf tmpSchemeID = "0.07" And tmpIntcheckSum = "H8o+NbYmV80tU9Zsk+3Vag==" Then
            '    FinalSchemeID = 5

            'ElseIf tmpSchemeID = "0.03" And tmpIntcheckSum = "THnOlQUa3C8IMnha27YfsQ==" Then
            '    FinalSchemeID = 1

            'ElseIf tmpSchemeID = "0.05" And tmpIntcheckSum = "THnOlQUa3C8IMnha27YfsQ==" Then
            '    FinalSchemeID = 3

            'ElseIf tmpSchemeID = "0.06" And tmpIntcheckSum = "THnOlQUa3C8IMnha27YfsQ==" Then
            '    FinalSchemeID = 4

            'ElseIf tmpSchemeID = "0.07" And tmpIntcheckSum = "THnOlQUa3C8IMnha27YfsQ==" Then
            '    FinalSchemeID = 5

            'Else
            '    FinalSchemeID = 99
            'End If
            ds2.Tables(filldata2).Rows(0).Item("Scheme_ID") = tmpSchemeID
            database.SaveEntry(ds2, False)
        Next
        MsgBox("Success")
    End Sub

    Private Function GetInt(ByVal ItemType As String, ByVal CheckSum As String)

        Dim mySql As String = "Select * from tblint_history where checksum = '" & CheckSum & "' and itemtype = '" & ItemType & "' and dayfrom = '34'"
        Dim ds As DataSet = LoadSQL(mySql)

        If ds.Tables(0).Rows.Count = 0 Then
            Return 0
        End If
        Dim tmpInt As String = ds.Tables(0).Rows(0).Item("Interest")
        tmpInt = tmpInt / 2
        Return GetScheme(tmpInt, CheckSum, ItemType)

    End Function

    Private Function GetScheme(ByVal Int As String, ByVal checksum As String, ByVal ItemType As String)
        Dim mySql As String = "Select * from tblint_history where checksum = '" & checksum & "' and Itemtype = '" & ItemType & "'"
        Dim ds As DataSet = LoadSQL(mySql)
        Dim isEarlyRedeem As Boolean = False
        Dim tmpID As String
        If ds.Tables(0).Rows(0).Item("Remarks") = "Early Redemption" Then
            isEarlyRedeem = True
        Else
            isEarlyRedeem = False
        End If
        If isEarlyRedeem = False Then
            If Int = "0.03" Then
                tmpID = 1
            ElseIf Int = "0.04" Then
                tmpID = 2
            ElseIf Int = "0.05" Then
                tmpID = 3
            ElseIf Int = "0.06" Then
                tmpID = 4
            End If
        ElseIf isEarlyRedeem = True Then
            If Int = "0.03" Then
                tmpID = 5
            ElseIf Int = "0.04" Then
                tmpID = 6
            ElseIf Int = "0.05" Then
                tmpID = 7
            ElseIf Int = "0.06" Then
                tmpID = 8
            ElseIf Int = "0.07" Then
                tmpID = 9
            End If
        Else
            tmpID = 99
        End If
        Return tmpID
    End Function

End Class