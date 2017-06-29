Public Class diagLoadTrans
    Private LoadType As String = ""

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        If rbLoadWallet.Checked Then
            LoadType = "LOAD WALLET"
        ElseIf rbRemoteLoad.Checked Then
            LoadType = "REMOTE LOAD"
        ElseIf rbRemoteReceive.Checked Then
            LoadType = "REMOTE RECEIVE"
        End If
        Me.Close()
    End Sub

    Public Overloads Function ShowLoadType(ByVal EnteredText() As String) As DialogResult
        Me.ShowDialog()

        EnteredText(0) = LoadType

        Return Me.DialogResult
    End Function
End Class