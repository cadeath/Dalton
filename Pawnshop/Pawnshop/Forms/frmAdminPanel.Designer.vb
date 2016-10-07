<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdminPanel
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboSchemename = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPrintLayout = New System.Windows.Forms.TextBox()
        Me.rbNo = New System.Windows.Forms.RadioButton()
        Me.rbYes = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.txtCategory = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtClassification = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.dgSpecs = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewComboBoxColumn1 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DataGridViewComboBoxColumn2 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewComboBoxColumn3 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.lvModule = New System.Windows.Forms.ListView()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.cmbModuleName = New System.Windows.Forms.ComboBox()
        Me.lblModuleName = New System.Windows.Forms.Label()
        Me.lblReferenceNumber = New System.Windows.Forms.Label()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.SFD = New System.Windows.Forms.SaveFileDialog()
        Me.oFd = New System.Windows.Forms.OpenFileDialog()
        Me.txtReferenceNumber = New Pawnshop.watermark()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgSpecs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(901, 394)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 33)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(982, 394)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 33)
        Me.btnUpdate.TabIndex = 3
        Me.btnUpdate.Text = "&Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1151, 462)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Gainsboro
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.dgSpecs)
        Me.TabPage1.Controls.Add(Me.btnClose)
        Me.TabPage1.Controls.Add(Me.btnSave)
        Me.TabPage1.Controls.Add(Me.btnUpdate)
        Me.TabPage1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1143, 433)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Item"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.cboSchemename)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.txtPrintLayout)
        Me.GroupBox3.Controls.Add(Me.rbNo)
        Me.GroupBox3.Controls.Add(Me.rbYes)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.txtDescription)
        Me.GroupBox3.Controls.Add(Me.txtCategory)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.txtClassification)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 76)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(362, 351)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Item Information"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 326)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 16)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Interest Scheme"
        '
        'cboSchemename
        '
        Me.cboSchemename.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSchemename.FormattingEnabled = True
        Me.cboSchemename.Location = New System.Drawing.Point(113, 318)
        Me.cboSchemename.Name = "cboSchemename"
        Me.cboSchemename.Size = New System.Drawing.Size(228, 24)
        Me.cboSchemename.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 207)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 16)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Print Layout"
        '
        'txtPrintLayout
        '
        Me.txtPrintLayout.Location = New System.Drawing.Point(113, 204)
        Me.txtPrintLayout.Multiline = True
        Me.txtPrintLayout.Name = "txtPrintLayout"
        Me.txtPrintLayout.Size = New System.Drawing.Size(228, 91)
        Me.txtPrintLayout.TabIndex = 9
        '
        'rbNo
        '
        Me.rbNo.AutoSize = True
        Me.rbNo.Location = New System.Drawing.Point(234, 178)
        Me.rbNo.Name = "rbNo"
        Me.rbNo.Size = New System.Drawing.Size(44, 20)
        Me.rbNo.TabIndex = 8
        Me.rbNo.Text = "No"
        Me.rbNo.UseVisualStyleBackColor = True
        '
        'rbYes
        '
        Me.rbYes.AutoSize = True
        Me.rbYes.Checked = True
        Me.rbYes.Location = New System.Drawing.Point(113, 178)
        Me.rbYes.Name = "rbYes"
        Me.rbYes.Size = New System.Drawing.Size(50, 20)
        Me.rbYes.TabIndex = 7
        Me.rbYes.TabStop = True
        Me.rbYes.Text = "Yes"
        Me.rbYes.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 178)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Is Renewable"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Description"
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(113, 79)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(228, 92)
        Me.txtDescription.TabIndex = 4
        '
        'txtCategory
        '
        Me.txtCategory.Location = New System.Drawing.Point(113, 51)
        Me.txtCategory.Name = "txtCategory"
        Me.txtCategory.Size = New System.Drawing.Size(228, 22)
        Me.txtCategory.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Category"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Clasification"
        '
        'txtClassification
        '
        Me.txtClassification.Location = New System.Drawing.Point(113, 24)
        Me.txtClassification.Name = "txtClassification"
        Me.txtClassification.Size = New System.Drawing.Size(228, 22)
        Me.txtClassification.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSearch)
        Me.GroupBox1.Controls.Add(Me.txtSearch)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1129, 64)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Search"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(1038, 20)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(6, 21)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(1026, 22)
        Me.txtSearch.TabIndex = 0
        '
        'dgSpecs
        '
        Me.dgSpecs.AllowUserToDeleteRows = False
        Me.dgSpecs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgSpecs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSpecs.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewComboBoxColumn1, Me.DataGridViewComboBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewComboBoxColumn3})
        Me.dgSpecs.Location = New System.Drawing.Point(374, 76)
        Me.dgSpecs.Name = "dgSpecs"
        Me.dgSpecs.RowHeadersVisible = False
        Me.dgSpecs.RowHeadersWidth = 20
        Me.dgSpecs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgSpecs.Size = New System.Drawing.Size(761, 316)
        Me.dgSpecs.TabIndex = 1
        '
        'Column1
        '
        Me.Column1.HeaderText = "ID"
        Me.Column1.Name = "Column1"
        Me.Column1.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewTextBoxColumn1.FillWeight = 71.31783!
        Me.DataGridViewTextBoxColumn1.HeaderText = "Short Code"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 120
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.FillWeight = 120.9694!
        Me.DataGridViewTextBoxColumn2.HeaderText = "Specification Name"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 164
        '
        'DataGridViewComboBoxColumn1
        '
        Me.DataGridViewComboBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewComboBoxColumn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DataGridViewComboBoxColumn1.HeaderText = "Specification Type"
        Me.DataGridViewComboBoxColumn1.Items.AddRange(New Object() {"String", "Double", "Integer", "Boolean"})
        Me.DataGridViewComboBoxColumn1.Name = "DataGridViewComboBoxColumn1"
        Me.DataGridViewComboBoxColumn1.Width = 113
        '
        'DataGridViewComboBoxColumn2
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewComboBoxColumn2.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewComboBoxColumn2.FillWeight = 72.58589!
        Me.DataGridViewComboBoxColumn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DataGridViewComboBoxColumn2.HeaderText = "Layout"
        Me.DataGridViewComboBoxColumn2.Items.AddRange(New Object() {"TextBox", "MultiLine", "Yes/No"})
        Me.DataGridViewComboBoxColumn2.Name = "DataGridViewComboBoxColumn2"
        Me.DataGridViewComboBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewComboBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewComboBoxColumn2.Width = 118
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.FillWeight = 126.1294!
        Me.DataGridViewTextBoxColumn3.HeaderText = "Unit of Measure"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 142
        '
        'DataGridViewComboBoxColumn3
        '
        Me.DataGridViewComboBoxColumn3.FillWeight = 108.9974!
        Me.DataGridViewComboBoxColumn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DataGridViewComboBoxColumn3.HeaderText = "Is Required"
        Me.DataGridViewComboBoxColumn3.Items.AddRange(New Object() {"True", "False"})
        Me.DataGridViewComboBoxColumn3.Name = "DataGridViewComboBoxColumn3"
        Me.DataGridViewComboBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewComboBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewComboBoxColumn3.Width = 101
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(1061, 394)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 33)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.Gainsboro
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1143, 433)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Export Config"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtReferenceNumber)
        Me.GroupBox2.Controls.Add(Me.btnBrowse)
        Me.GroupBox2.Controls.Add(Me.lvModule)
        Me.GroupBox2.Controls.Add(Me.btnExport)
        Me.GroupBox2.Controls.Add(Me.cmbModuleName)
        Me.GroupBox2.Controls.Add(Me.lblModuleName)
        Me.GroupBox2.Controls.Add(Me.lblReferenceNumber)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1134, 427)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(972, 402)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowse.TabIndex = 7
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'lvModule
        '
        Me.lvModule.FullRowSelect = True
        Me.lvModule.GridLines = True
        Me.lvModule.Location = New System.Drawing.Point(10, 82)
        Me.lvModule.Name = "lvModule"
        Me.lvModule.Size = New System.Drawing.Size(1118, 314)
        Me.lvModule.TabIndex = 6
        Me.lvModule.UseCompatibleStateImageBehavior = False
        Me.lvModule.View = System.Windows.Forms.View.Details
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(1053, 402)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(75, 23)
        Me.btnExport.TabIndex = 5
        Me.btnExport.Text = "Export"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'cmbModuleName
        '
        Me.cmbModuleName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbModuleName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbModuleName.FormattingEnabled = True
        Me.cmbModuleName.Items.AddRange(New Object() {"Money Transfer", "Branch", "Cash", "Item Class", "Rate", "Currency"})
        Me.cmbModuleName.Location = New System.Drawing.Point(106, 41)
        Me.cmbModuleName.Name = "cmbModuleName"
        Me.cmbModuleName.Size = New System.Drawing.Size(207, 24)
        Me.cmbModuleName.TabIndex = 4
        Me.cmbModuleName.Text = "Module Name"
        '
        'lblModuleName
        '
        Me.lblModuleName.AutoSize = True
        Me.lblModuleName.Location = New System.Drawing.Point(7, 44)
        Me.lblModuleName.Name = "lblModuleName"
        Me.lblModuleName.Size = New System.Drawing.Size(93, 16)
        Me.lblModuleName.TabIndex = 3
        Me.lblModuleName.Text = "Module Name"
        '
        'lblReferenceNumber
        '
        Me.lblReferenceNumber.AutoSize = True
        Me.lblReferenceNumber.Location = New System.Drawing.Point(7, 16)
        Me.lblReferenceNumber.Name = "lblReferenceNumber"
        Me.lblReferenceNumber.Size = New System.Drawing.Size(95, 16)
        Me.lblReferenceNumber.TabIndex = 0
        Me.lblReferenceNumber.Text = "Reference No."
        '
        'lblSearch
        '
        Me.lblSearch.Location = New System.Drawing.Point(0, 0)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(100, 23)
        Me.lblSearch.TabIndex = 0
        '
        'SFD
        '
        Me.SFD.Filter = "CIR File |*.cir"
        '
        'oFd
        '
        Me.oFd.FileName = "OpenFileDialog1"
        Me.oFd.Filter = "CIR File |*.cir"
        '
        'txtReferenceNumber
        '
        Me.txtReferenceNumber.Location = New System.Drawing.Point(106, 13)
        Me.txtReferenceNumber.Name = "txtReferenceNumber"
        Me.txtReferenceNumber.Size = New System.Drawing.Size(207, 22)
        Me.txtReferenceNumber.TabIndex = 2
        Me.txtReferenceNumber.WatermarkColor = System.Drawing.Color.Gray
        Me.txtReferenceNumber.WatermarkText = "Reference No."
        '
        'frmAdminPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1166, 478)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frmAdminPanel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Admin Panel"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgSpecs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblReferenceNumber As System.Windows.Forms.Label
    Friend WithEvents lblModuleName As System.Windows.Forms.Label
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents cmbModuleName As System.Windows.Forms.ComboBox
    Friend WithEvents lblPrintLayout As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lvModule As System.Windows.Forms.ListView
    Friend WithEvents SFD As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents oFd As System.Windows.Forms.OpenFileDialog
    Friend WithEvents dgSpecs As System.Windows.Forms.DataGridView
    Friend WithEvents txtReferenceNumber As Pawnshop.watermark

    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn2 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn3 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboSchemename As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPrintLayout As System.Windows.Forms.TextBox
    Friend WithEvents rbNo As System.Windows.Forms.RadioButton
    Friend WithEvents rbYes As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtCategory As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtClassification As System.Windows.Forms.TextBox

End Class
