Imports System.IO
Imports System.Drawing.Imaging
Imports System.Threading

Public Class frmCustomerImage
    Private SRC As String = Application.StartupPath & "\ClientImage"
    Dim dgvImageColumn As New DataGridViewImageColumn
    Dim dgTextbox As New DataGridViewTextBoxColumn
    Dim dgTextbox1 As New DataGridViewTextBoxColumn

    Dim imgArray As String()

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Dim ms As New MemoryStream
        Dim img As Bitmap
        img = dgCustImage.CurrentRow.Cells(0).Value
        img.Save(ms, ImageFormat.Jpeg)
        frmCustomer_KYC.ClientImage.Image = Image.FromStream(ms)
        frmCustomer_KYC.FlName = dgCustImage.CurrentRow.Cells(2).Value
        frmCustomer_KYC.notNewPic = False
        Me.Close()
    End Sub

    Private Sub frmCustomerImage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgColumns()

        Dim th As Thread
        th = New Thread(AddressOf AddImage)
        th.Start()
    End Sub

    Private Sub dgCustImage_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgCustImage.DoubleClick
            btnSelect.PerformClick()
    End Sub


    Private Delegate Sub addBar_callback()

    Private Sub AddImage()
        If Not File.Exists(SRC) Then Exit Sub

        Dim hashValue As String

        Dim img As Image
        Dim i As Integer = 0

        If dgCustImage.InvokeRequired Then
            dgCustImage.Invoke(New addBar_callback(AddressOf AddImage))
        Else
            For Each imges In Directory.GetFiles(SRC)

                i += 1
                Dim subString As String = imges.Substring(imges.LastIndexOf("\"c)).Trim("\")
                hashValue = subString & "|" & GetFileMD5(imges)


                Dim mysql As String = "SELECT CLIENT_IMG FROM " & CUSTOMER_TABLE & " WHERE CLIENT_IMG  = '" & hashValue & "'"
                Dim ds As DataSet = LoadSQL(mysql, CUSTOMER_TABLE)

                img = Image.FromFile(imges)

                If ds.Tables(CUSTOMER_TABLE).Rows.Count = 0 Then
                    dgCustImage.Rows.Add(img, "Image # " & i, imges.Substring(imges.LastIndexOf("\"c)).Trim("\"))
                End If

                Application.DoEvents()
            Next
        End If
    End Sub


    Private Sub dgColumns()
        With dgvImageColumn
            .HeaderText = "Image"
            .ImageLayout = DataGridViewImageCellLayout.Zoom
        End With

        With dgTextbox
            .HeaderText = "#"
        End With

        With dgTextbox1
            .HeaderText = "StringName"
        End With

        With dgCustImage
            .Columns.Add(dgvImageColumn)
            .RowTemplate.Height = 110
            .AllowUserToAddRows = False
            .ColumnHeadersHeightSizeMode = False
            .AutoSize = False
            .Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable

            .Columns.Add(dgTextbox)
            Dim column As DataGridViewColumn = .Columns(1)
            column.Width = 200 

            .Columns.Add(dgTextbox1)
            Dim column1 As DataGridViewColumn = .Columns(2)
            column1.Width = 0 
        End With
    End Sub

    Private Sub dgCustImage_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgCustImage.KeyPress
        If isEnter(e) Then btnSelect.PerformClick()
    End Sub
End Class