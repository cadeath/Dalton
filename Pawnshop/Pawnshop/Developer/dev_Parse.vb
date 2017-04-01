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
                Console.WriteLine("Trim String " & mc(index).Value.Substring(mc(index).Value.IndexOf(":")).Trim({"]"c}))
                strTrim = mc(index).Value.Substring(mc(index).Value.IndexOf(":")).Trim({"]"c})

                SMSHash.Add(strParse, strTrim)
            Next
            SaveSMS()
        End If

    End Sub

    Private Sub SaveSMS()
        'Dim mysql As String = "Select * from SmsRegister"
        'Dim ds As DataSet = LoadSQL(mysql, "SmsRegister")
        'Dim dsNewRow As DataRow
        'dsNewRow = ds.Tables("SmsRegister").NewRow
        'With dsNewRow
        '    .Item("Fname") = _userName
        '    .Item("Lname") = Encrypt(_password)
        '    .Item("Mname") = _fullName
        '    .Item("SMSNumber") = _fullName
        'End With
        'ds.Tables("SmsRegister").Rows.Add(dsNewRow)
        'SaveEntry(ds)

    End Sub
End Class