Public Class dev_Borrowings

    Private Sub btnGenerate_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerate.Click
        If Not sfdMoneyFile.ShowDialog = Windows.Forms.DialogResult.OK Then Exit Sub
        Dim file As String = sfdMoneyFile.FileName
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

    Private Sub dev_Borrowings_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtDate.Text = Now.Date.Date
    End Sub
End Class