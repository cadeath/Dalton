<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMassDiscount
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
        Dim ListViewItem5 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"CEL 00003", "SAMSUNG J1", "CELLPHONE", "1500"}, -1)
        Dim ListViewItem6 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"CEL 00003", "SAMSUNG J1", "CELLPHONE", "1500", "45"}, -1)
        Me.lvItem = New System.Windows.Forms.ListView()
        Me.ItemCode = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Description = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Category = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SalePrice = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtSearchCode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.lvDiscount = New System.Windows.Forms.ListView()
        Me.disItemCode = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.disDescription = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.disCategory = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.disSalePrice = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.disCount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnOnePull = New System.Windows.Forms.Button()
        Me.btnAllPull = New System.Windows.Forms.Button()
        Me.btnSearchItem = New System.Windows.Forms.Button()
        Me.txtSearchItem = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnAddDiscount = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lvItem
        '
        Me.lvItem.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ItemCode, Me.Description, Me.Category, Me.SalePrice})
        Me.lvItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvItem.FullRowSelect = True
        Me.lvItem.GridLines = True
        Me.lvItem.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem5})
        Me.lvItem.Location = New System.Drawing.Point(12, 48)
        Me.lvItem.MultiSelect = False
        Me.lvItem.Name = "lvItem"
        Me.lvItem.Size = New System.Drawing.Size(440, 358)
        Me.lvItem.TabIndex = 5
        Me.lvItem.UseCompatibleStateImageBehavior = False
        Me.lvItem.View = System.Windows.Forms.View.Details
        '
        'ItemCode
        '
        Me.ItemCode.Text = "Item Code"
        Me.ItemCode.Width = 80
        '
        'Description
        '
        Me.Description.Text = "Description"
        Me.Description.Width = 187
        '
        'Category
        '
        Me.Category.Text = "Category"
        Me.Category.Width = 95
        '
        'SalePrice
        '
        Me.SalePrice.Text = "SalePrice"
        Me.SalePrice.Width = 79
        '
        'txtSearchCode
        '
        Me.txtSearchCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearchCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchCode.Location = New System.Drawing.Point(61, 14)
        Me.txtSearchCode.Name = "txtSearchCode"
        Me.txtSearchCode.Size = New System.Drawing.Size(310, 21)
        Me.txtSearchCode.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 15)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Search"
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(377, 9)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 33)
        Me.btnSearch.TabIndex = 8
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Location = New System.Drawing.Point(927, 412)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 33)
        Me.btnOK.TabIndex = 10
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'lvDiscount
        '
        Me.lvDiscount.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.disItemCode, Me.disDescription, Me.disCategory, Me.disSalePrice, Me.disCount})
        Me.lvDiscount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvDiscount.FullRowSelect = True
        Me.lvDiscount.GridLines = True
        Me.lvDiscount.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem6})
        Me.lvDiscount.Location = New System.Drawing.Point(515, 48)
        Me.lvDiscount.MultiSelect = False
        Me.lvDiscount.Name = "lvDiscount"
        Me.lvDiscount.Size = New System.Drawing.Size(487, 358)
        Me.lvDiscount.TabIndex = 17
        Me.lvDiscount.UseCompatibleStateImageBehavior = False
        Me.lvDiscount.View = System.Windows.Forms.View.Details
        '
        'disItemCode
        '
        Me.disItemCode.Text = "Item Code"
        Me.disItemCode.Width = 80
        '
        'disDescription
        '
        Me.disDescription.Text = "Description"
        Me.disDescription.Width = 145
        '
        'disCategory
        '
        Me.disCategory.Text = "Category"
        Me.disCategory.Width = 95
        '
        'disSalePrice
        '
        Me.disSalePrice.Text = "SalePrice"
        Me.disSalePrice.Width = 79
        '
        'disCount
        '
        Me.disCount.Text = "% Discount"
        Me.disCount.Width = 82
        '
        'btnOnePull
        '
        Me.btnOnePull.Location = New System.Drawing.Point(458, 215)
        Me.btnOnePull.Name = "btnOnePull"
        Me.btnOnePull.Size = New System.Drawing.Size(51, 48)
        Me.btnOnePull.TabIndex = 19
        Me.btnOnePull.Text = ">"
        Me.btnOnePull.UseVisualStyleBackColor = True
        '
        'btnAllPull
        '
        Me.btnAllPull.Location = New System.Drawing.Point(458, 121)
        Me.btnAllPull.Name = "btnAllPull"
        Me.btnAllPull.Size = New System.Drawing.Size(51, 48)
        Me.btnAllPull.TabIndex = 18
        Me.btnAllPull.Text = ">>"
        Me.btnAllPull.UseVisualStyleBackColor = True
        '
        'btnSearchItem
        '
        Me.btnSearchItem.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearchItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearchItem.Location = New System.Drawing.Point(924, 9)
        Me.btnSearchItem.Name = "btnSearchItem"
        Me.btnSearchItem.Size = New System.Drawing.Size(75, 33)
        Me.btnSearchItem.TabIndex = 22
        Me.btnSearchItem.Text = "Search"
        Me.btnSearchItem.UseVisualStyleBackColor = True
        '
        'txtSearchItem
        '
        Me.txtSearchItem.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearchItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchItem.Location = New System.Drawing.Point(625, 14)
        Me.txtSearchItem.Name = "txtSearchItem"
        Me.txtSearchItem.Size = New System.Drawing.Size(293, 21)
        Me.txtSearchItem.TabIndex = 21
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(514, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 15)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Search Item Code"
        '
        'btnAddDiscount
        '
        Me.btnAddDiscount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddDiscount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddDiscount.Location = New System.Drawing.Point(517, 412)
        Me.btnAddDiscount.Name = "btnAddDiscount"
        Me.btnAddDiscount.Size = New System.Drawing.Size(118, 33)
        Me.btnAddDiscount.TabIndex = 23
        Me.btnAddDiscount.Text = "&Add Discount"
        Me.btnAddDiscount.UseVisualStyleBackColor = True
        '
        'frmMassDiscount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1011, 450)
        Me.Controls.Add(Me.btnAddDiscount)
        Me.Controls.Add(Me.btnSearchItem)
        Me.Controls.Add(Me.txtSearchItem)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnOnePull)
        Me.Controls.Add(Me.btnAllPull)
        Me.Controls.Add(Me.lvDiscount)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtSearchCode)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lvItem)
        Me.Name = "frmMassDiscount"
        Me.Text = "Discount Form"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvItem As System.Windows.Forms.ListView
    Friend WithEvents ItemCode As System.Windows.Forms.ColumnHeader
    Friend WithEvents Description As System.Windows.Forms.ColumnHeader
    Friend WithEvents Category As System.Windows.Forms.ColumnHeader
    Friend WithEvents SalePrice As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtSearchCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents lvDiscount As System.Windows.Forms.ListView
    Friend WithEvents disItemCode As System.Windows.Forms.ColumnHeader
    Friend WithEvents disDescription As System.Windows.Forms.ColumnHeader
    Friend WithEvents disCategory As System.Windows.Forms.ColumnHeader
    Friend WithEvents disSalePrice As System.Windows.Forms.ColumnHeader
    Friend WithEvents disCount As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnOnePull As System.Windows.Forms.Button
    Friend WithEvents btnAllPull As System.Windows.Forms.Button
    Friend WithEvents btnSearchItem As System.Windows.Forms.Button
    Friend WithEvents txtSearchItem As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnAddDiscount As System.Windows.Forms.Button
End Class
