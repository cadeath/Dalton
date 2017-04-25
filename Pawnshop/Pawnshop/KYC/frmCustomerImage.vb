Imports System.IO
Imports System.Drawing.Imaging

Public Class frmCustomerImage
    Private SRC As String = Application.StartupPath & "\ClientImage"
    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Dim ms As New MemoryStream
        Dim img As Bitmap
        img = dgCustImage.CurrentRow.Cells(0).Value
        img.Save(ms, ImageFormat.Jpeg)
        frmCustomer_KYC.ClientImage.Image = Image.FromStream(ms)
        Me.Close()
    End Sub

    Private Sub frmCustomerImage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim dgvImageColumn As New DataGridViewImageColumn

        dgvImageColumn.HeaderText = "Image"
        dgvImageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom

        dgCustImage.Columns.Add(dgvImageColumn)

        dgCustImage.RowTemplate.Height = 110

        dgCustImage.AllowUserToAddRows = False

        Dim img1 As Image

        For Each LogFile In Directory.GetFiles(SRC)
            img1 = Image.FromFile(LogFile)
            dgCustImage.Rows.Add(img1)
        Next

    End Sub

    Private Sub dgCustImage_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgCustImage.DoubleClick
        If isEnter(e) Then btnSelect.PerformClick()
    End Sub
End Class