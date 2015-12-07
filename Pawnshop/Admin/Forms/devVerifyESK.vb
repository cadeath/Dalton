

Public Class devVerifyESK

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        If ofdESK.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub

        txtURL.Text = ofdESK.FileName
    End Sub

    Private Sub btnCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheck.Click
        ESKload()
    End Sub

    Private Sub ExecuteBorrowings()
        Dim ht As New Hashtable
        ht = LoadBorrowing(txtURL.Text)
        If ht Is Nothing Then Exit Sub


    End Sub

    Private Function LoadBorrowing(ByVal url As String) As Hashtable
        If System.IO.File.Exists(txtURL.Text) = False Then Return Nothing

        Dim fs As New System.IO.FileStream(txtURL.Text, IO.FileMode.Open)
        Dim bf As New Runtime.Serialization.Formatters.Binary.BinaryFormatter()

        Dim hashTable As New Hashtable
        Try
            hashTable = bf.Deserialize(fs)
        Catch ex As Exception
            Console.WriteLine("It seems the file is being tampered.")
            fs.Close()
            Return Nothing
        End Try
        fs.Close()

        Dim isValid As Boolean = False
        If hashTable(5) = _
            security.HashString( _
                hashTable(0) & hashTable(1) & _
                hashTable(2) & hashTable(3) & _
                hashTable(4)) Then
            isValid = True
        Else
            isValid = False
        End If

        If isValid Then Return hashTable
        Return Nothing
    End Function

    Private Function GetIntegrity(ByVal hx As Hashtable) As Boolean
        Dim xStr As String = security.HashString(hx(0) & hx(1) & hx(2) & hx(3) & hx(4))
        If hx(5) = xStr Then
            Return True
        Else
            Return False
        End If
    End Function

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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim file As String = "D:\cadeath\Desktop\xSample.esk"
        Dim ht As New Hashtable
        With ht
            .Add(0, txtRef.Text) 'RefNum
            .Add(1, txtDate.Text) 'TransDate
            .Add(2, txtCode.Text) 'BranchCode
            .Add(3, txtAmnt.Text) 'Amount
            .Add(4, txtRemarks.Text) 'Remarks
        End With

        CreateEsk(file, ht)
        MsgBox("DONE")
    End Sub

    Private Sub CreateEsk(ByVal url As String, ByVal data As Hashtable)
        If System.IO.File.Exists(url) Then System.IO.File.Delete(url)

        Dim fsEsk As New System.IO.FileStream(url, IO.FileMode.CreateNew)
        Dim refNum As String, transDate As String, branchCode As String, amount As Double, remarks As String
        Dim checkSum As String

        With data
            refNum = data(0) '0 - as RefNum
            transDate = data(1) 'transDate
            branchCode = data(2) 'branchCode
            amount = data(3) 'Amount
            remarks = data(4) 'Remarks
        End With
        checkSum = HashString(refNum & transDate & branchCode & amount & remarks)
        data.Add(5, checkSum) 'CheckSum

        Dim esk As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
        esk.Serialize(fsEsk, data)
        fsEsk.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If exportFile.ImportConfig(txtURL.Text) Is Nothing Then
            MsgBox("FAILED", MsgBoxStyle.Critical)
        Else
            MsgBox("Success", MsgBoxStyle.Information)
        End If
    End Sub
End Class