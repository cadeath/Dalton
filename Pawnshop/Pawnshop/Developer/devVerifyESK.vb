Public Class devVerifyESK

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        If ofdESK.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub

        txtURL.Text = ofdESK.FileName
    End Sub

    Private Sub btnCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheck.Click
        ESKload()
    End Sub

    Private Sub ESKload()
        If System.IO.File.Exists(txtURL.Text) = False Then Exit Sub

        Dim fs As New System.IO.FileStream(txtURL.Text, IO.FileMode.Open)
        Dim bf As New Runtime.Serialization.Formatters.Binary.BinaryFormatter()

        Dim hashTable As New Hashtable
        Try
            hashTable = bf.Deserialize(fs)
        Catch ex As Exception
            Console.WriteLine("It seems the file is being tampered.")
        End Try
        fs.Close()

        rtbValue.Text = "RefNu: " & hashTable(0) & vbCrLf
        rtbValue.AppendText("Date: " & hashTable(1) & vbCrLf)
        rtbValue.AppendText("Code: " & hashTable(2) & vbCrLf)
        rtbValue.AppendText("Amount: " & hashTable(3) & vbCrLf)
        rtbValue.AppendText("Remarks: " & hashTable(4) & vbCrLf)
        rtbValue.AppendText("HASH: " & hashTable(5) & vbCrLf)

        Dim isValid As Boolean = False
        If hashTable(5) = security.HashString(hashTable(0) & hashTable(1) & hashTable(2) & hashTable(3) & hashTable(4)) Then
            isValid = True
        Else
            isValid = False
        End If

        rtbValue.AppendText("Valid: " & isValid)
    End Sub

End Class