Imports System.Text.RegularExpressions
Imports System.Text

Public Class dev_Parse
    Private SMSHash As New Hashtable
    Private Sub btnParse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnParse.Click
        Parser(txtParse.Text)
    End Sub

    Private Sub Parser(ByVal StrText As String)
        Dim pattern As String = "\[.*?\]"
        Dim strParse As String, strTrim As String
        Dim mc As System.Text.RegularExpressions.MatchCollection
        ' Dim m As System.Text.RegularExpressions.Match

        Dim regx As New System.Text.RegularExpressions.Regex(pattern)

        If Regex.IsMatch(StrText, pattern) Then
            mc = regx.Matches(StrText)
            For index As Integer = 0 To mc.Count - 1
                'Nagkuha ug Text Fields
                Console.WriteLine("Parse String: " & mc(index).Value.Substring(0, mc(index).Value.IndexOf(":")).Trim({"["c}))
                strParse = mc(index).Value.Substring(0, mc(index).Value.IndexOf(":")).Trim({"["c})

                'Nagkuha ug Fields Information
                Console.WriteLine("Trim String: " & mc(index).Value.Substring(mc(index).Value.IndexOf(":") + 1).Trim({"]"c}))
                strTrim = mc(index).Value.Substring(mc(index).Value.IndexOf(":") + 1).Trim({"]"c}).Trim({" "c})

                If Not isValidKey(strParse) Then Exit Sub

                SMSHash.Add(strParse, strTrim)
            Next
        End If

        If SMSHash.Count = 0 Then Exit Sub

        Dim mysql As String = "Select * from SmsRegister"
        Dim ds As DataSet = LoadSQL(mysql, "SmsRegister")
        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables("SmsRegister").NewRow
        With dsNewRow
            .Item("Fname") = SMSHash("FNAME")
            .Item("Lname") = SMSHash("LNAME")
            .Item("Mname") = SMSHash("MNAME")
            .Item("SMSNumber") = SMSHash("NUMBER")
        End With
        ds.Tables("SmsRegister").Rows.Add(dsNewRow)
        SaveEntry(ds)

        MsgBox("Success")
        SMSHash.Clear()
    End Sub


    Private Function isValidKey(ByVal Keys As String) As Boolean
        Dim KeysCollection() As String = {"FNAME", "MNAME", "LNAME", "NUMBER"}

        If KeysCollection.Contains(Keys) Then Return True

        Return False
    End Function

End Class