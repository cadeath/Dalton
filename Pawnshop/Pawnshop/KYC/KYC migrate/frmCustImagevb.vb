Imports System.IO
Public Class frmCustImagevb
    Private SRC As String = Application.StartupPath & "\ClientImage"

    Private Sub frmCustImagevb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dgvImageColumn As New DataGridViewImageColumn
        dgvImageColumn.HeaderText = "Image"
        dgvImageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch
        DataGridView1.Columns.Add(dgvImageColumn)
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.RowTemplate.Height = 150

        Dim img1 As Image


        For Each IMGFILE In Directory.GetFiles(SRC)
            img1 = Image.FromFile(IMGFILE)
            DataGridView1.Rows.Add(img1)
        Next

    End Sub

End Class