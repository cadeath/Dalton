<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAuditConsole
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAuditConsole))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnCCSheet = New System.Windows.Forms.Button()
        Me.btnCashCount = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboType = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnVault = New System.Windows.Forms.Button()
        Me.txtPrincipal = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MonVault = New System.Windows.Forms.MonthCalendar()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.chkZeroOut = New System.Windows.Forms.CheckBox()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.ofdINV_AD = New System.Windows.Forms.OpenFileDialog()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.lvItem = New System.Windows.Forms.ListView()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnCCSheet)
        Me.GroupBox1.Controls.Add(Me.btnCashCount)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(467, 105)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cash Count"
        '
        'btnCCSheet
        '
        Me.btnCCSheet.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCCSheet.Location = New System.Drawing.Point(144, 19)
        Me.btnCCSheet.Name = "btnCCSheet"
        Me.btnCCSheet.Size = New System.Drawing.Size(126, 69)
        Me.btnCCSheet.TabIndex = 4
        Me.btnCCSheet.Text = "Cash Count Sheet"
        Me.btnCCSheet.UseVisualStyleBackColor = True
        '
        'btnCashCount
        '
        Me.btnCashCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCashCount.Location = New System.Drawing.Point(12, 19)
        Me.btnCashCount.Name = "btnCashCount"
        Me.btnCashCount.Size = New System.Drawing.Size(126, 69)
        Me.btnCashCount.TabIndex = 3
        Me.btnCashCount.Text = "Cash Count"
        Me.btnCashCount.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboType)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.btnVault)
        Me.GroupBox2.Controls.Add(Me.txtPrincipal)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.MonVault)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 117)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(467, 220)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Vault Inventory"
        '
        'cboType
        '
        Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType.FormattingEnabled = True
        Me.cboType.Location = New System.Drawing.Point(254, 118)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(200, 21)
        Me.cboType.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(251, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 16)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Item Type"
        '
        'btnVault
        '
        Me.btnVault.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVault.Location = New System.Drawing.Point(370, 171)
        Me.btnVault.Name = "btnVault"
        Me.btnVault.Size = New System.Drawing.Size(84, 37)
        Me.btnVault.TabIndex = 10
        Me.btnVault.Text = "&View"
        Me.btnVault.UseVisualStyleBackColor = True
        '
        'txtPrincipal
        '
        Me.txtPrincipal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrincipal.Location = New System.Drawing.Point(254, 65)
        Me.txtPrincipal.Name = "txtPrincipal"
        Me.txtPrincipal.Size = New System.Drawing.Size(200, 22)
        Me.txtPrincipal.TabIndex = 9
        Me.txtPrincipal.Text = "0.00"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(251, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(203, 16)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Principal (Equal or Greater Than)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Vault as Of"
        '
        'MonVault
        '
        Me.MonVault.Location = New System.Drawing.Point(12, 46)
        Me.MonVault.Name = "MonVault"
        Me.MonVault.TabIndex = 6
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(6, 5)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(497, 371)
        Me.TabControl1.TabIndex = 6
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(489, 345)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Audit"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.GroupBox4)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(489, 345)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Inventory Adjustment"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chkZeroOut)
        Me.GroupBox4.Controls.Add(Me.btnImport)
        Me.GroupBox4.Controls.Add(Me.txtPath)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.btnBrowse)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(477, 83)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        '
        'chkZeroOut
        '
        Me.chkZeroOut.AutoSize = True
        Me.chkZeroOut.Location = New System.Drawing.Point(42, 52)
        Me.chkZeroOut.Name = "chkZeroOut"
        Me.chkZeroOut.Size = New System.Drawing.Size(115, 17)
        Me.chkZeroOut.TabIndex = 4
        Me.chkZeroOut.Text = "Inventory Zero Out"
        Me.chkZeroOut.UseVisualStyleBackColor = True
        '
        'btnImport
        '
        Me.btnImport.Location = New System.Drawing.Point(408, 48)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(63, 23)
        Me.btnImport.TabIndex = 3
        Me.btnImport.Text = "Import"
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'txtPath
        '
        Me.txtPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPath.Location = New System.Drawing.Point(42, 17)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.ReadOnly = True
        Me.txtPath.Size = New System.Drawing.Size(360, 22)
        Me.txtPath.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Path"
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(408, 17)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(63, 23)
        Me.btnBrowse.TabIndex = 0
        Me.btnBrowse.Text = ". . ."
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'ofdINV_AD
        '
        Me.ofdINV_AD.Filter = "Excel 2007|*.xlsx"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Controls.Add(Me.lvItem)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(489, 345)
        Me.TabPage2.TabIndex = 3
        Me.TabPage2.Text = "Audit Tracker"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'lvItem
        '
        Me.lvItem.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6})
        Me.lvItem.FullRowSelect = True
        Me.lvItem.GridLines = True
        Me.lvItem.Location = New System.Drawing.Point(3, 58)
        Me.lvItem.Name = "lvItem"
        Me.lvItem.Size = New System.Drawing.Size(483, 283)
        Me.lvItem.TabIndex = 0
        Me.lvItem.UseCompatibleStateImageBehavior = False
        Me.lvItem.View = System.Windows.Forms.View.Details
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtSearch)
        Me.GroupBox3.Controls.Add(Me.btnSearch)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(483, 49)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(402, 16)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 0
        Me.btnSearch.Text = "S&earch"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(6, 18)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(390, 20)
        Me.txtSearch.TabIndex = 1
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ItemCode"
        Me.ColumnHeader1.Width = 72
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Description"
        Me.ColumnHeader2.Width = 138
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Sold Date"
        Me.ColumnHeader3.Width = 68
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Price"
        Me.ColumnHeader4.Width = 63
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Qty"
        Me.ColumnHeader5.Width = 39
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Remarks"
        '
        'frmAuditConsole
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(508, 380)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmAuditConsole"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Audit Console"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCCSheet As System.Windows.Forms.Button
    Friend WithEvents btnCashCount As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents MonVault As System.Windows.Forms.MonthCalendar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPrincipal As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnVault As System.Windows.Forms.Button
    Friend WithEvents cboType As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnImport As System.Windows.Forms.Button
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents ofdINV_AD As System.Windows.Forms.OpenFileDialog
    Friend WithEvents chkZeroOut As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents lvItem As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
End Class
