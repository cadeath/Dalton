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
            If tmpPawnID >= 1568 Then MsgBox(tmpPawnID)
            Dim tmpItemType As String = dr.Item("ItemType")
            Dim tmpIntcheckSum As String
            If Not IsDBNull(dr.Item("int_checksum")) Then tmpIntcheckSum = dr.Item("int_checksum")
            Dim tmpSchemeID As String = GetInt(tmpItemType, tmpIntcheckSum)

            Dim mysql2 As String = "Select * from OPI where PawnItemID = '" & tmpPawnID & "'"
            Dim filldata2 As String = "OPI"
            Dim ds2 As DataSet = LoadSQL(mysql2, filldata2)
            Dim FinalSchemeID As Integer = 0

            'With Early Redeem
            If tmpSchemeID = "0.030" And tmpIntcheckSum = "2UeDR8f2bFX1c+rsLG8v7g==" Then
                FinalSchemeID = 6

            ElseIf tmpSchemeID = "0.040" And tmpIntcheckSum = "2UeDR8f2bFX1c+rsLG8v7g==" Then
                FinalSchemeID = 7

            ElseIf tmpSchemeID = "0.050" And tmpIntcheckSum = "2UeDR8f2bFX1c+rsLG8v7g==" Then
                FinalSchemeID = 8

            ElseIf tmpSchemeID = "0.030" And tmpIntcheckSum = "aWFXwwYbqLmins1KPvmmIw==" Then
                FinalSchemeID = 6

            ElseIf tmpSchemeID = "0.050" And tmpIntcheckSum = "aWFXwwYbqLmins1KPvmmIw" Then
                FinalSchemeID = 8

            ElseIf tmpSchemeID = "0.060" And tmpIntcheckSum = "aWFXwwYbqLmins1KPvmmIw" Then
                FinalSchemeID = 9

            ElseIf tmpSchemeID = "0.050" And tmpIntcheckSum = "w4p+Hj+9pc/U1EYpf8ffA==" Then
                FinalSchemeID = 8

            ElseIf tmpSchemeID = "0.060" And tmpIntcheckSum = "w4p+Hj+9pc/U1EYpf8ffA==" Then
                FinalSchemeID = 9
                'Without Early Redeem
            ElseIf tmpSchemeID = "0.050" And tmpIntcheckSum = "6zixr/PwMkDjdRTSktCeJA==" Then
                FinalSchemeID = 3

            ElseIf tmpSchemeID = "0.060" And tmpIntcheckSum = "6zixr/PwMkDjdRTSktCeJA==" Then
                FinalSchemeID = 4

            ElseIf tmpSchemeID = "0.070" And tmpIntcheckSum = "6zixr/PwMkDjdRTSktCeJA==" Then
                FinalSchemeID = 5

            ElseIf tmpSchemeID = "0.040" And tmpIntcheckSum = "H8o+NbYmV80tU9Zsk+3Vag==" Then
                FinalSchemeID = 2

            ElseIf tmpSchemeID = "0.050" And tmpIntcheckSum = "H8o+NbYmV80tU9Zsk+3Vag==" Then
                FinalSchemeID = 3

            ElseIf tmpSchemeID = "0.060" And tmpIntcheckSum = "H8o+NbYmV80tU9Zsk+3Vag==" Then
                FinalSchemeID = 4

            ElseIf tmpSchemeID = "0.070" And tmpIntcheckSum = "H8o+NbYmV80tU9Zsk+3Vag==" Then
                FinalSchemeID = 5

            ElseIf tmpSchemeID = "0.030" And tmpIntcheckSum = "THnOlQUa3C8IMnha27YfsQ==" Then
                FinalSchemeID = 1

            ElseIf tmpSchemeID = "0.050" And tmpIntcheckSum = "THnOlQUa3C8IMnha27YfsQ==" Then
                FinalSchemeID = 3

            ElseIf tmpSchemeID = "0.060" And tmpIntcheckSum = "THnOlQUa3C8IMnha27YfsQ==" Then
                FinalSchemeID = 4

            ElseIf tmpSchemeID = "0.070" And tmpIntcheckSum = "THnOlQUa3C8IMnha27YfsQ==" Then
                FinalSchemeID = 5

            Else
                FinalSchemeID = 99
            End If
            ds2.Tables(filldata2).Rows(0).Item("Scheme_ID") = FinalSchemeID
            database.SaveEntry(ds2, False)
        Next
        MsgBox("Success")
    End Sub

    Public Function GetInt(ByVal ItemType As String, ByVal CheckSum As String)

        Dim mySql As String = "Select * from tblint_history where checksum = '" & CheckSum & "' and itemtype = '" & ItemType & "' and dayfrom = '8'"
        Dim ds As DataSet = LoadSQL(mySql)

        If ds.Tables(0).Rows.Count = 0 Then
            Return 0
        End If
        Return ds.Tables(0).Rows(0).Item("Interest")

    End Function
End Class