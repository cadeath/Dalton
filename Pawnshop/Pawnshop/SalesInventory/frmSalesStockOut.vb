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
        cboLocation.Text = ""
        txtControl.Text = ""
        txtParticular.Text = ""

        Load_ControlNum()
    End Sub

    Friend Sub Add_ControlNum()
        CURRENT_NUM += 1
        UpdateOptions("STONum", CURRENT_NUM)
    End Sub

    Private Sub Load_ControlNum()
        CURRENT_NUM = GetOption("STONum")
        txtControl.Text = CURRENT_NUM.ToString("000000")
    End Sub

    Private Sub btnAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccept.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
            m_Branch = cboLocation.Text
            m_Particulars = txtParticular.Text
        Me.Close()
    End Sub

    Private Sub frmSalesStockOut_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearFields()
        Load_ControlNum()
        LoadBranches()
    End Sub

    Private Sub LoadBranches()
        Dim mySql As String = "SELECT * FROM tblBranches WHERE SAPCode <> '" & BranchCode & "'"
        Dim ds As DataSet = LoadSQL(mySql)
        Dim MaxCount As Integer = ds.Tables(0).Rows.Count

        cboLocation.Items.Add("PTU")
        cboLocation.Items.Add("01")
        Dim str(MaxCount - 1) As String
        For cnt As Integer = 0 To MaxCount - 1
            str(cnt) = ds.Tables(0).Rows(cnt).Item("BranchName")
        Next
        cboLocation.Items.AddRange(str)
    End Sub
End Class