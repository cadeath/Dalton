<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRate
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
        Dim ListViewItem4 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"1", "Disbursement", "AUCTION REDEEM", "Sales - Auctioned Cellphones", "_SYS0000000001", "", "False"}, -1)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRate))
        Me.tcConfig = New System.Windows.Forms.TabControl()
        Me.tpRate = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.txtServiceRef = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lvAccnt = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtServicePath = New System.Windows.Forms.TextBox()
        Me.btnServiceBrowse = New System.Windows.Forms.Button()
        Me.btnServiceImport = New System.Windows.Forms.Button()
        Me.ofdESK = New System.Windows.Forms.OpenFileDialog()
        Me.tcConfig.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcConfig
        '
        Me.tcConfig.Controls.Add(Me.tpRate)
        Me.tcConfig.Controls.Add(Me.TabPage2)
        Me.tcConfig.Location = New System.Drawing.Point(12, 12)
        Me.tcConfig.Name = "tcConfig"
        Me.tcConfig.SelectedIndex = 0
        Me.tcConfig.Size = New System.Drawing.Size(1030, 436)
        Me.tcConfig.TabIndex = 0
        '
        'tpRate
        '
        Me.tpRate.Location = New System.Drawing.Point(4, 22)
        Me.tpRate.Name = "tpRate"
        Me.tpRate.Padding = New System.Windows.Forms.Padding(3)
        Me.tpRate.Size = New System.Drawing.Size(1022, 410)
        Me.tpRate.TabIndex = 0
        Me.tpRate.Text = "Pawnshop"
        Me.tpRate.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.btnServiceImport)
        Me.TabPage2.Controls.Add(Me.btnServiceBrowse)
        Me.TabPage2.Controls.Add(Me.txtServicePath)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.lvAccnt)
        Me.TabPage2.Controls.Add(Me.txtServiceRef)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1022, 410)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Services"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'txtServiceRef
        '
        Me.txtServiceRef.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtServiceRef.Location = New System.Drawing.Point(83, 11)
        Me.txtServiceRef.Name = "txtServiceRef"
        Me.txtServiceRef.ReadOnly = True
        Me.txtServiceRef.Size = New System.Drawing.Size(131, 22)
        Me.txtServiceRef.TabIndex = 1
        Me.txtServiceRef.Text = "0001"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ref# :"
        '
        'lvAccnt
        '
        Me.lvAccnt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvAccnt.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7})
        Me.lvAccnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvAccnt.FullRowSelect = True
        Me.lvAccnt.GridLines = True
        Me.lvAccnt.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem4})
        Me.lvAccnt.Location = New System.Drawing.Point(6, 48)
        Me.lvAccnt.MultiSelect = False
        Me.lvAccnt.Name = "lvAccnt"
        Me.lvAccnt.Size = New System.Drawing.Size(1010, 318)
        Me.lvAccnt.TabIndex = 0
        Me.lvAccnt.UseCompatibleStateImageBehavior = False
        Me.lvAccnt.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 34
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Type"
        Me.ColumnHeader2.Width = 114
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Category"
        Me.ColumnHeader3.Width = 139
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Transaction"
        Me.ColumnHeader4.Width = 228
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "SAP Account Code"
        Me.ColumnHeader5.Width = 130
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Remarks"
        Me.ColumnHeader6.Width = 153
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "onHold"
        Me.ColumnHeader7.Width = 75
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(20, 380)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 18)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Path :"
        '
        'txtServicePath
        '
        Me.txtServicePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtServicePath.Location = New System.Drawing.Point(84, 379)
        Me.txtServicePath.Name = "txtServicePath"
        Me.txtServicePath.ReadOnly = True
        Me.txtServicePath.Size = New System.Drawing.Size(292, 22)
        Me.txtServicePath.TabIndex = 1
        Me.txtServicePath.Text = "0001"
        '
        'btnServiceBrowse
        '
        Me.btnServiceBrowse.Image = CType(resources.GetObject("btnServiceBrowse.Image"), System.Drawing.Image)
        Me.btnServiceBrowse.Location = New System.Drawing.Point(382, 372)
        Me.btnServiceBrowse.Name = "btnServiceBrowse"
        Me.btnServiceBrowse.Size = New System.Drawing.Size(39, 34)
        Me.btnServiceBrowse.TabIndex = 2
        Me.btnServiceBrowse.UseVisualStyleBackColor = True
        '
        'btnServiceImport
        '
        Me.btnServiceImport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnServiceImport.Location = New System.Drawing.Point(427, 373)
        Me.btnServiceImport.Name = "btnServiceImport"
        Me.btnServiceImport.Size = New System.Drawing.Size(75, 33)
        Me.btnServiceImport.TabIndex = 3
        Me.btnServiceImport.Text = "&Import"
        Me.btnServiceImport.UseVisualStyleBackColor = True
        '
        'ofdESK
        '
        Me.ofdESK.Filter = "Config File|*.econ"
        '
        'frmRate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1054, 460)
        Me.Controls.Add(Me.tcConfig)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmRate"
        Me.Text = "Rate"
        Me.tcConfig.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tcConfig As System.Windows.Forms.TabControl
    Friend WithEvents tpRate As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents txtServiceRef As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lvAccnt As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtServicePath As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnServiceBrowse As System.Windows.Forms.Button
    Friend WithEvents btnServiceImport As System.Windows.Forms.Button
    Friend WithEvents ofdESK As System.Windows.Forms.OpenFileDialog
End Class
