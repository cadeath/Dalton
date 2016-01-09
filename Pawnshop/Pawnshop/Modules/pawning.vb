Module pawning

    Function DisplayDescription(ByVal type As String, ByVal desc As String) As String

        Select Case type
            Case "JWL"

        End Select

        Return desc
    End Function

    Private Function Encrypt(ByVal amount As Integer) As String
        Dim intStr As String = amount, newStr As String = ""

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
                Case "10" : subStr = "N"
            End Select

            newStr &= subStr
        Next

        Return newStr
    End Function

End Module
