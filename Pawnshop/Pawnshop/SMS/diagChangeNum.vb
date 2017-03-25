Public Class diagChangeNum

    Protected update_contact As String = ""

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        update_contact = ""

        Me.Close()
    End Sub

    Public Overloads Function ShowDialog(ByVal returnValue() As String, ByVal arr As String()) As DialogResult
        txtNewNumber.Text = IIf(arr(0).Contains("INV"), "", arr(0))
        lblClient.Text = "Change Number for " & arr(1)

        Me.ShowDialog()
        returnValue(0) = update_contact

        Return Me.DialogResult
    End Function

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        update_contact = txtNewNumber.Text

        Me.Close()
    End Sub

    Private Sub txtNewNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNewNumber.KeyPress
        DigitOnly(e)
        PhoneSeparator(txtNewNumber, e)
    End Sub
End Class