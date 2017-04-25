Imports System.IO
Public Class frmCustomerImage
    Private SRC As String = Application.StartupPath & "\ClientImage"
    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click

    End Sub

    Private Sub frmCustomerImage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim img As New DataGridViewImageColumn()

        For Each LogFile In Directory.GetFiles(SRC)
            Dim inImg As Image = Image.FromFile(SRC)

            img.Image = inImg
            DataGridView1.Columns.Add(img)
            'img.HeaderText = "Image"
            'img.Name = "img"
        Next
        
    End Sub
End Class