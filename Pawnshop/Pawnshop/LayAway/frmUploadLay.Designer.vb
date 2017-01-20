<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUploadLay
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
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"ITM 00001", "1/2/2017", "4/2/2017", "15000", "6400", "1", "ROBIN PADODOT"}, -1)
        Me.lvLayAway = New System.Windows.Forms.ListView()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.lblFilename = New System.Windows.Forms.Label()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.ofdIMD = New System.Windows.Forms.OpenFileDialog()
        Me.btnAddCustomer = New System.Windows.Forms.Button()
        Me.ItemCode = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LayAwayDate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ForfeitDate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Price = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Balance = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CustomerName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'lvLayAway
        '
        Me.lvLayAway.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvLayAway.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ItemCode, Me.LayAwayDate, Me.ForfeitDate, Me.Price, Me.Balance, Me.ID, Me.CustomerName})
        Me.lvLayAway.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvLayAway.FullRowSelect = True
        Me.lvLayAway.GridLines = True
        Me.lvLayAway.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1})
        Me.lvLayAway.Location = New System.Drawing.Point(5, 68)
        Me.lvLayAway.Name = "lvLayAway"
        Me.lvLayAway.Size = New System.Drawing.Size(797, 396)
        Me.lvLayAway.TabIndex = 2
        Me.lvLayAway.UseCompatibleStateImageBehavior = False
        Me.lvLayAway.View = System.Windows.Forms.View.Details
        '
        'btnBrowse
        '
        Me.btnBrowse.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowse.Location = New System.Drawing.Point(5, 31)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(75, 31)
        Me.btnBrowse.TabIndex = 3
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'lblFilename
        '
        Me.lblFilename.AutoSize = True
        Me.lblFilename.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFilename.Location = New System.Drawing.Point(5, 12)
        Me.lblFilename.Name = "lblFilename"
        Me.lblFilename.Size = New System.Drawing.Size(64, 16)
        Me.lblFilename.TabIndex = 4
        Me.lblFilename.Text = "Filename"
        '
        'btnImport
        '
        Me.btnImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImport.Location = New System.Drawing.Point(598, 470)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(75, 31)
        Me.btnImport.TabIndex = 5
        Me.btnImport.Text = "&Import"
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'ofdIMD
        '
        Me.ofdIMD.Filter = "Excel 2003|*.xls|Excel 2007|*.xlsx"
        '
        'btnAddCustomer
        '
        Me.btnAddCustomer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddCustomer.Location = New System.Drawing.Point(688, 470)
        Me.btnAddCustomer.Name = "btnAddCustomer"
        Me.btnAddCustomer.Size = New System.Drawing.Size(114, 31)
        Me.btnAddCustomer.TabIndex = 6
        Me.btnAddCustomer.Text = "&Add Customer"
        Me.btnAddCustomer.UseVisualStyleBackColor = True
        '
        'ItemCode
        '
        Me.ItemCode.Text = "ItemCode"
        Me.ItemCode.Width = 87
        '
        'LayAwayDate
        '
        Me.LayAwayDate.Text = "LayAway Date"
        Me.LayAwayDate.Width = 104
        '
        'ForfeitDate
        '
        Me.ForfeitDate.Text = "Forfeit Date"
        Me.ForfeitDate.Width = 96
        '
        'Price
        '
        Me.Price.Text = "Price"
        Me.Price.Width = 123
        '
        'Balance
        '
        Me.Balance.Text = "Balance"
        Me.Balance.Width = 131
        '
        'ID
        '
        Me.ID.Text = "ID"
        Me.ID.Width = 53
        '
        'CustomerName
        '
        Me.CustomerName.Text = "CustomerName"
        Me.CustomerName.Width = 195
        '
        'frmUploadLay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(814, 513)
        Me.Controls.Add(Me.btnAddCustomer)
        Me.Controls.Add(Me.btnImport)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.lblFilename)
        Me.Controls.Add(Me.lvLayAway)
        Me.Name = "frmUploadLay"
        Me.Text = "Layaway"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvLayAway As System.Windows.Forms.ListView
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents lblFilename As System.Windows.Forms.Label
    Friend WithEvents btnImport As System.Windows.Forms.Button
    Friend WithEvents ofdIMD As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnAddCustomer As System.Windows.Forms.Button
    Friend WithEvents ItemCode As System.Windows.Forms.ColumnHeader
    Friend WithEvents LayAwayDate As System.Windows.Forms.ColumnHeader
    Friend WithEvents ForfeitDate As System.Windows.Forms.ColumnHeader
    Friend WithEvents Price As System.Windows.Forms.ColumnHeader
    Friend WithEvents Balance As System.Windows.Forms.ColumnHeader
    Friend WithEvents ID As System.Windows.Forms.ColumnHeader
    Friend WithEvents CustomerName As System.Windows.Forms.ColumnHeader
End Class
