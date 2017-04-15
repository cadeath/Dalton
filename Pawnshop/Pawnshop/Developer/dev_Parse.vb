Imports System.Text.RegularExpressions
Imports System.Text

Public Class dev_Parse

    Private SMSHash As New Hashtable
    Private pattern As String = "\[.*?\]"
    Private strParse As String, strTrim As String
    Private mc As System.Text.RegularExpressions.MatchCollection

    Private Sub btnParse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnParse.Click
        Parser(txtParse.Text)
    End Sub

    Private Function Parser(ByVal StrText As String) As ArrayList
        Dim regx As New System.Text.RegularExpressions.Regex(pattern)
        Dim strArray As New ArrayList
        If Regex.IsMatch(StrText, pattern) Then
            mc = regx.Matches(StrText) 'Check kong pila ang bracket
            For index As Integer = 0 To mc.Count - 1 ' Count sa Bracket
                'Nagkuha ug Text Fields
                strParse = mc(index).Value.Substring(0, mc(index).Value.IndexOf(":")).Trim({"["c})
                Console.WriteLine("Fields " & strParse)

                'Nagkuha ug Fields Information
                strTrim = mc(index).Value.Substring(mc(index).Value.IndexOf(":") + 1).Trim({"]"c}).Trim({" "c})
                Console.WriteLine("Value " & strTrim)

                If Not isValidKey(strParse) Then Exit Function

                'SMSHash.Add(strParse, strTrim)
                strArray.Add(strParse)
                strArray.Add(strTrim)
            Next
        End If

        'If SMSHash.Count = 0 Then Exit Sub

        'Dim mysql As String = "Select * from SmsRegister"
        'Dim ds As DataSet = LoadSQL(mysql, "SmsRegister")
        'Dim dsNewRow As DataRow
        'dsNewRow = ds.Tables("SmsRegister").NewRow
        'With dsNewRow
        '    .Item("Fname") = SMSHash("FNAME")
        '    .Item("Lname") = SMSHash("LNAME")
        '    .Item("Mname") = SMSHash("MNAME")
        '    .Item("SMSNumber") = SMSHash("NUMBER")
        'End With
        'ds.Tables("SmsRegister").Rows.Add(dsNewRow)
        'SaveEntry(ds)

        'MsgBox("Success")
        'SMSHash.Clear()
        Return strArray
    End Function


    Private Function isValidKey(ByVal Keys As String) As Boolean
        Dim KeysCollection() As String = {"FNAME", "MNAME", "LNAME", "NUMBER", "REG_KEY"}

        If KeysCollection.Contains(Keys) Then Return True

        Return False
    End Function

End Class