Imports System.IO
Imports System.Drawing.Imaging

Public Class frmCustomerImage
    Private SRC As String = Application.StartupPath & "\ClientImage"
    Dim dgvImageColumn As New DataGridViewImageColumn

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Dim ms As New MemoryStream
        Dim img As Bitmap
        img = dgCustImage.CurrentRow.Cells(0).Value
        img.Save(ms, ImageFormat.Jpeg)
        frmCustomer_KYC.ClientImage.Image = Image.FromStream(ms)
        Me.Close()
    End Sub

    Private Sub frmCustomerImage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddImage()
    End Sub

    Private Sub dgCustImage_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgCustImage.DoubleClick
        btnSelect.PerformClick()
    End Sub

    Private Sub AddImage()

        With dgvImageColumn
            .HeaderText = "Image"
            .ImageLayout = DataGridViewImageCellLayout.Zoom
        End With

        With dgCustImage
            .Columns.Add(dgvImageColumn)
            .RowTemplate.Height = 110
            .AllowUserToAddRows = False
        End With

        Dim img As Image

        For Each LogFile In Directory.GetFiles(SRC)
            img = Image.FromFile(LogFile)
            dgCustImage.Rows.Add(img)
        Next

    End Sub
End Class