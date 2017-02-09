Module pawning

    Function DisplayDescription(ByVal pt As PawnTicket) As String
        Dim desc As String = ""

        If pt.ItemType = "JWL" Then
            desc = String.Format("1 {0} {1}G APPROX {2}", GetCategoryByID(pt.CategoryID), pt.Grams, CompanyEncrypt(pt.Karat))
            desc &= vbCrLf & pt.Description
            desc &= vbCrLf & "Appraised by " & GetUsername(pt.AppraiserID)
        Else
            desc = pt.Description
            If desc = "" Then desc = "N/A"
            desc &= vbCrLf & "Appraised by " & GetUsername(pt.AppraiserID) 'BUG FIXED
        End If
        Return desc
    End Function

    Private Function GetUsername(ByVal id As Integer) As String
        Dim loadAppraiser As New ComputerUser
        loadAppraiser.LoadUser(id)

        Return loadAppraiser.UserName
    End Function

    Private Function GetCategoryByID(ByVal id As Integer) As String
        Dim mySql As String = "SELECT * FROM tblClass WHERE ClassID = " & id
        Dim ds As DataSet = LoadSQL(mySql)

        Return ds.Tables(0).Rows(0).Item("CATEGORY")
    End Function

    Friend Function CompanyEncrypt(ByVal karat As Integer) As String
        Dim intStr As String = karat, newStr As String = ""

        For cnt As Integer = 0 To intStr.Length - 1
            Dim subStr As String = intStr.Substring(cnt, 1)
            Select Case subStr
                Case "1" : subStr = "F"
                Case "2" : subStr = "U"
                Case "3" : subStr = "J"
                Case "4" : subStr = "I"
                Case "5" : subStr = "D"
                Case "6" : subStr = "A"
                Case "7" : subStr = "L"
                Case "8" : subStr = "T"
                Case "9" : subStr = "O"
                Case "0" : subStr = "N"
            End Select

            newStr &= subStr
        Next

        Return newStr
    End Function

End Module
