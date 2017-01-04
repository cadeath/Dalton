<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSales
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"GAD 0120", "SAMPLE GAD ITEMS", "3", "1,000", "3,000"}, -1)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSales))
        Me.lvSale = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.lblMode = New System.Windows.Forms.Label()
        Me.lblCustomer = New System.Windows.Forms.Label()
        Me.tsButton = New System.Windows.Forms.ToolStrip()
        Me.tsbIMD = New System.Windows.Forms.ToolStripButton()
        Me.tsbPLU = New System.Windows.Forms.ToolStripButton()
        Me.tsbtnAuction = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbCustomer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbCash = New System.Windows.Forms.ToolStripButton()
        Me.tsbCheck = New System.Windows.Forms.ToolStripButton()
        Me.tsbRefund = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalesReturn = New System.Windows.Forms.ToolStripButton()
        Me.tsbtnOut = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbReceipt = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnOption = New System.Windows.Forms.ToolStripButton()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnPost = New System.Windows.Forms.Button()
        Me.lblNoVat = New System.Windows.Forms.Label()
        Me.tsbtnLay = New System.Windows.Forms.ToolStripButton()
        Me.tsButton.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvSale
        '
        Me.lvSale.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvSale.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.lvSale.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvSale.FullRowSelect = True
        Me.lvSale.GridLines = True
        Me.lvSale.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1})
        Me.lvSale.Location = New System.Drawing.Point(12, 38)
        Me.lvSale.Name = "lvSale"
        Me.lvSale.Size = New System.Drawing.Size(574, 341)
        Me.lvSale.TabIndex = 0
        Me.lvSale.UseCompatibleStateImageBehavior = False
        Me.lvSale.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ItemCode"
        Me.ColumnHeader1.Width = 76
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Description"
        Me.ColumnHeader2.Width = 174
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Qty"
        Me.ColumnHeader3.Width = 44
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Price"
        Me.ColumnHeader4.Width = 84
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Total"
        Me.ColumnHeader5.Width = 90
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(592, 292)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Total"
        '
        'lblTotal
        '
        Me.lblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(592, 317)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(286, 43)
        Me.lblTotal.TabIndex = 2
        Me.lblTotal.Text = "Php 9,999,999.99"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSearch
        '
        Me.lblSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearch.Location = New System.Drawing.Point(12, 394)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(48, 16)
        Me.lblSearch.TabIndex = 3
        Me.lblSearch.Text = "ITEM:"
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(88, 388)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(399, 31)
        Me.txtSearch.TabIndex = 4
        Me.txtSearch.Text = "DESCRIPTION"
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(493, 388)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(93, 31)
        Me.btnSearch.TabIndex = 5
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'lblMode
        '
        Me.lblMode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMode.Location = New System.Drawing.Point(592, 38)
        Me.lblMode.Name = "lblMode"
        Me.lblMode.Size = New System.Drawing.Size(286, 43)
        Me.lblMode.TabIndex = 6
        Me.lblMode.Text = "CASH"
        Me.lblMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCustomer
        '
        Me.lblCustomer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomer.Location = New System.Drawing.Point(592, 98)
        Me.lblCustomer.Name = "lblCustomer"
        Me.lblCustomer.Size = New System.Drawing.Size(286, 43)
        Me.lblCustomer.TabIndex = 8
        Me.lblCustomer.Text = "One-Time Customer"
        Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tsButton
        '
        Me.tsButton.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbIMD, Me.tsbPLU, Me.tsbtnAuction, Me.ToolStripSeparator1, Me.tsbCustomer, Me.ToolStripSeparator2, Me.tsbCash, Me.tsbCheck, Me.tsbRefund, Me.tsbtnLay, Me.tsbSalesReturn, Me.tsbtnOut, Me.ToolStripSeparator3, Me.tsbReceipt, Me.ToolStripSeparator4, Me.tsbtnOption})
        Me.tsButton.Location = New System.Drawing.Point(0, 0)
        Me.tsButton.Name = "tsButton"
        Me.tsButton.Size = New System.Drawing.Size(890, 25)
        Me.tsButton.TabIndex = 9
        Me.tsButton.Text = "tsButton"
        '
        'tsbIMD
        '
        Me.tsbIMD.Image = CType(resources.GetObject("tsbIMD.Image"), System.Drawing.Image)
        Me.tsbIMD.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbIMD.Name = "tsbIMD"
        Me.tsbIMD.Size = New System.Drawing.Size(49, 22)
        Me.tsbIMD.Text = "IMD"
        '
        'tsbPLU
        '
        Me.tsbPLU.Image = CType(resources.GetObject("tsbPLU.Image"), System.Drawing.Image)
        Me.tsbPLU.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPLU.Name = "tsbPLU"
        Me.tsbPLU.Size = New System.Drawing.Size(48, 22)
        Me.tsbPLU.Text = "PLU"
        '
        'tsbtnAuction
        '
        Me.tsbtnAuction.Image = CType(resources.GetObject("tsbtnAuction.Image"), System.Drawing.Image)
        Me.tsbtnAuction.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnAuction.Name = "tsbtnAuction"
        Me.tsbtnAuction.Size = New System.Drawing.Size(68, 22)
        Me.tsbtnAuction.Text = "RECALL"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsbCustomer
        '
        Me.tsbCustomer.Image = CType(resources.GetObject("tsbCustomer.Image"), System.Drawing.Image)
        Me.tsbCustomer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCustomer.Name = "tsbCustomer"
        Me.tsbCustomer.Size = New System.Drawing.Size(89, 22)
        Me.tsbCustomer.Text = "CUSTOMER"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tsbCash
        '
        Me.tsbCash.Image = CType(resources.GetObject("tsbCash.Image"), System.Drawing.Image)
        Me.tsbCash.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCash.Name = "tsbCash"
        Me.tsbCash.Size = New System.Drawing.Size(58, 22)
        Me.tsbCash.Text = "CASH"
        '
        'tsbCheck
        '
        Me.tsbCheck.Image = CType(resources.GetObject("tsbCheck.Image"), System.Drawing.Image)
        Me.tsbCheck.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCheck.Name = "tsbCheck"
        Me.tsbCheck.Size = New System.Drawing.Size(65, 22)
        Me.tsbCheck.Text = "CHECK"
        '
        'tsbRefund
        '
        Me.tsbRefund.Image = CType(resources.GetObject("tsbRefund.Image"), System.Drawing.Image)
        Me.tsbRefund.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRefund.Name = "tsbRefund"
        Me.tsbRefund.Size = New System.Drawing.Size(71, 22)
        Me.tsbRefund.Text = "REFUND"
        Me.tsbRefund.Visible = False
        '
        'tsbSalesReturn
        '
        Me.tsbSalesReturn.Image = CType(resources.GetObject("tsbSalesReturn.Image"), System.Drawing.Image)
        Me.tsbSalesReturn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalesReturn.Name = "tsbSalesReturn"
        Me.tsbSalesReturn.Size = New System.Drawing.Size(112, 22)
        Me.tsbSalesReturn.Text = "SALES RETURNS"
        '
        'tsbtnOut
        '
        Me.tsbtnOut.Image = CType(resources.GetObject("tsbtnOut.Image"), System.Drawing.Image)
        Me.tsbtnOut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnOut.Name = "tsbtnOut"
        Me.tsbtnOut.Size = New System.Drawing.Size(88, 22)
        Me.tsbtnOut.Text = "STOCKOUT"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'tsbReceipt
        '
        Me.tsbReceipt.Image = CType(resources.GetObject("tsbReceipt.Image"), System.Drawing.Image)
        Me.tsbReceipt.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbReceipt.Name = "tsbReceipt"
        Me.tsbReceipt.Size = New System.Drawing.Size(77, 22)
        Me.tsbReceipt.Text = "RECEIPTS"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnOption
        '
        Me.tsbtnOption.Image = CType(resources.GetObject("tsbtnOption.Image"), System.Drawing.Image)
        Me.tsbtnOption.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnOption.Name = "tsbtnOption"
        Me.tsbtnOption.Size = New System.Drawing.Size(77, 22)
        Me.tsbtnOption.Text = "OPTIONS"
        Me.tsbtnOption.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(773, 366)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(105, 50)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnPost
        '
        Me.btnPost.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPost.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPost.Location = New System.Drawing.Point(662, 366)
        Me.btnPost.Name = "btnPost"
        Me.btnPost.Size = New System.Drawing.Size(105, 50)
        Me.btnPost.TabIndex = 11
        Me.btnPost.Text = "Post"
        Me.btnPost.UseVisualStyleBackColor = True
        '
        'lblNoVat
        '
        Me.lblNoVat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNoVat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoVat.ForeColor = System.Drawing.Color.Red
        Me.lblNoVat.Location = New System.Drawing.Point(723, 292)
        Me.lblNoVat.Name = "lblNoVat"
        Me.lblNoVat.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblNoVat.Size = New System.Drawing.Size(147, 16)
        Me.lblNoVat.TabIndex = 12
        Me.lblNoVat.Text = "Php 99,99,99.00"
        '
        'tsbtnLay
        '
        Me.tsbtnLay.Image = CType(resources.GetObject("tsbtnLay.Image"), System.Drawing.Image)
        Me.tsbtnLay.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnLay.Name = "tsbtnLay"
        Me.tsbtnLay.Size = New System.Drawing.Size(82, 22)
        Me.tsbtnLay.Text = "LAYAWAY"
        '
        'frmSales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(890, 428)
        Me.Controls.Add(Me.lblNoVat)
        Me.Controls.Add(Me.btnPost)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.tsButton)
        Me.Controls.Add(Me.lblCustomer)
        Me.Controls.Add(Me.lblMode)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.lblSearch)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lvSale)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(545, 411)
        Me.Name = "frmSales"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sales"
        Me.tsButton.ResumeLayout(False)
        Me.tsButton.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvSale As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents lblMode As System.Windows.Forms.Label
    Friend WithEvents lblCustomer As System.Windows.Forms.Label
    Friend WithEvents tsButton As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbIMD As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbPLU As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbCustomer As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbCash As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbCheck As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnPost As System.Windows.Forms.Button
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbReceipt As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbRefund As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalesReturn As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblNoVat As System.Windows.Forms.Label
    Friend WithEvents tsbtnAuction As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtnOption As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtnOut As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtnLay As System.Windows.Forms.ToolStripButton
End Class
