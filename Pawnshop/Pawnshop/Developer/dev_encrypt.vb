Public Class dev_encrypt

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        lblENC.Text = EncryptKarat(TextBox1.Text)
    End Sub

    Function EncryptKarat(ByVal str As String) As String

        Dim tmpENC As String = "", subStr As String = ""
        For cnt As Integer = 0 To str.Length - 1
            Select Case str.Substring(cnt, 1)
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
            tmpENC &= subStr
        Next

        Return tmpENC
    End Function
End Class