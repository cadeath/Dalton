Public Class frmSalesStockOut

    Private CURRENT_NUM As Integer = GetOption("STONum")

    Protected m_Branch As String = ""
    Protected m_Particulars As String = ""

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        m_Branch = ""
        m_Particulars = ""

        Me.Close()
    End Sub

    Public Overloads Function ShowDialog(ByVal EnteredText() As String) As DialogResult
        Me.ShowDialog()

        EnteredText(0) = m_Branch
        EnteredText(1) = m_Particulars

        Return Me.DialogResult
    End Function

    Private Sub ClearFields()
        txtBranch.Text = ""
        txtControl.Text = ""
        txtParticular.Text = ""

        Load_ControlNum()
    End Sub

    Private Sub Load_ControlNum()
        txtControl.Text = CURRENT_NUM.ToString("STO#000000")
    End Sub

    Private Sub btnAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccept.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK

        m_Branch = txtBranch.Text
        m_Particulars = txtParticular.Text

        Me.Close()
    End Sub

    Private Sub frmSalesStockOut_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearFields()
        Load_ControlNum()
    End Sub
End Class