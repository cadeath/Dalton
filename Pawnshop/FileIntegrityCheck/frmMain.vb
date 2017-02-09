Public Class frmMain

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearFields()
    End Sub

    Private Sub ClearFields()
        lblFileURL.Text = ""
        txtCompare.Text = ""
        txtHash.Text = ""
    End Sub

    Private Sub btnHash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHash.Click
        If lblFileURL.Text = "" Then Exit Sub

        txtHash.Text = security.GetFileMD5(lblFileURL.Text)
    End Sub

    Private Sub lblFileURL_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblFileURL.DoubleClick
        ofdFile.ShowDialog()
        Dim fileName As String = ofdFile.FileName
        If fileName = "" Then Exit Sub

        lblFileURL.Text = fileName
    End Sub

    Private Sub btnCompare_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompare.Click
        If txtHash.Text = txtCompare.Text Then
            MsgBox("FILE HASH VALUE AND COMPARE HASH IS THE SAME.", MsgBoxStyle.Information, "ORIGINAL")
        Else
            MsgBox("NOT THE SAME", MsgBoxStyle.Critical, "INVALID")
        End If
    End Sub
End Class
