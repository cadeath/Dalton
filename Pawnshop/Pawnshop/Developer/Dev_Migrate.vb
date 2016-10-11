﻿Public Class Dev_Migrate

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        UpdateScheme()
    End Sub

    Private Sub UpdateScheme()
        Try
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
                ds2.Tables(filldata2).Rows(0).Item("Scheme_ID") = tmpSchemeID
                database.SaveEntry(ds2, False)
            Next
            MsgBox("Success")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
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
        Dim mySql As String = "Select * from tblint_history where checksum = '" & checksum & "' and Itemtype = '" & ItemType & "' and DayFrom = '1'"
        Dim ds As DataSet = LoadSQL(mySql)
        Dim isEarlyRedeem As Boolean = False
        Dim tmpID As String

        If ds.Tables(0).Rows(0).Item("Remarks") = "Early Redemption" Then isEarlyRedeem = True
        If isEarlyRedeem = False Then

            If Int = "0.03" Then
                tmpID = 1
            ElseIf Int = "0.04" Then
                tmpID = 2
            ElseIf Int = "0.05" Then
                tmpID = 3
            ElseIf Int = "0.06" Then
                tmpID = 4
            ElseIf Int = "0.07" Then
                tmpID = 5
            End If
        ElseIf isEarlyRedeem = True Then

            If Int = "0.03" Then
                tmpID = 6
            ElseIf Int = "0.04" Then
                tmpID = 7
            ElseIf Int = "0.05" Then
                tmpID = 8
            ElseIf Int = "0.06" Then
                tmpID = 9
            ElseIf Int = "0.07" Then
                tmpID = 10
            End If
        Else
            tmpID = 99
        End If

        Return tmpID
    End Function

End Class