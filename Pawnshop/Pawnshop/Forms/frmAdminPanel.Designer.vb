﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.grpAddItem = New System.Windows.Forms.GroupBox()
        Me.cbotxtSchemename = New System.Windows.Forms.ComboBox()
        Me.lblPrintLayout = New System.Windows.Forms.Label()
        Me.rdbNo = New System.Windows.Forms.RadioButton()
        Me.rdbYes = New System.Windows.Forms.RadioButton()
        Me.lblRenewable = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.lblClassification = New System.Windows.Forms.Label()
        Me.txtPrintLayout = New Pawnshop.watermark()
        Me.txtDescription = New Pawnshop.watermark()
        Me.txtCategory = New Pawnshop.watermark()
        Me.txtClassification = New Pawnshop.watermark()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboSchemename = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.rbNo = New System.Windows.Forms.RadioButton()
        Me.rbYes = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSearch1 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtSearch1 = New Pawnshop.watermark()
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
        Me.lblModname = New System.Windows.Forms.GroupBox()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.chkSelectAll = New System.Windows.Forms.CheckBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.lvModule = New System.Windows.Forms.ListView()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.cmbModuleName = New System.Windows.Forms.ComboBox()
        Me.lblModuleName = New System.Windows.Forms.Label()
        Me.txtReferenceNumber = New Pawnshop.watermark()
        Me.lblReferenceNumber = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New Pawnshop.watermark()
        Me.grpSearch = New System.Windows.Forms.GroupBox()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.SFD = New System.Windows.Forms.SaveFileDialog()
        Me.oFd = New System.Windows.Forms.OpenFileDialog()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.lblDateStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.grpAddItem.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgSpecs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.lblModname.SuspendLayout()
        Me.grpSearch.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpAddItem
        '
        Me.grpAddItem.BackColor = System.Drawing.Color.Gainsboro
        Me.grpAddItem.Controls.Add(Me.cbotxtSchemename)
        Me.grpAddItem.Controls.Add(Me.lblPrintLayout)
        Me.grpAddItem.Controls.Add(Me.rdbNo)
        Me.grpAddItem.Controls.Add(Me.rdbYes)
        Me.grpAddItem.Controls.Add(Me.lblRenewable)
        Me.grpAddItem.Controls.Add(Me.lblDescription)
        Me.grpAddItem.Controls.Add(Me.lblCategory)
        Me.grpAddItem.Controls.Add(Me.lblClassification)
        Me.grpAddItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpAddItem.ForeColor = System.Drawing.SystemColors.MenuText
        Me.grpAddItem.Location = New System.Drawing.Point(6, 72)
        Me.grpAddItem.Name = "grpAddItem"
        Me.grpAddItem.Size = New System.Drawing.Size(362, 342)
        Me.grpAddItem.TabIndex = 0
        Me.grpAddItem.TabStop = False
        Me.grpAddItem.Text = "Item Information"
        '
        'cbotxtSchemename
        '
        Me.cbotxtSchemename.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbotxtSchemename.FormattingEnabled = True
        Me.cbotxtSchemename.Location = New System.Drawing.Point(105, 287)
        Me.cbotxtSchemename.Name = "cbotxtSchemename"
        Me.cbotxtSchemename.Size = New System.Drawing.Size(250, 24)
        Me.cbotxtSchemename.TabIndex = 6
        '
        'lblPrintLayout
        '
        Me.lblPrintLayout.AutoSize = True
        Me.lblPrintLayout.Location = New System.Drawing.Point(22, 229)
        Me.lblPrintLayout.Name = "lblPrintLayout"
        Me.lblPrintLayout.Size = New System.Drawing.Size(77, 16)
        Me.lblPrintLayout.TabIndex = 8
        Me.lblPrintLayout.Text = "Print Layout"
        '
        'rdbNo
        '
        Me.rdbNo.AutoSize = True
        Me.rdbNo.Location = New System.Drawing.Point(160, 188)
        Me.rdbNo.Name = "rdbNo"
        Me.rdbNo.Size = New System.Drawing.Size(44, 20)
        Me.rdbNo.TabIndex = 4
        Me.rdbNo.Text = "No"
        Me.rdbNo.UseVisualStyleBackColor = True
        '
        'rdbYes
        '
        Me.rdbYes.AutoSize = True
        Me.rdbYes.Checked = True
        Me.rdbYes.Location = New System.Drawing.Point(104, 188)
        Me.rdbYes.Name = "rdbYes"
        Me.rdbYes.Size = New System.Drawing.Size(50, 20)
        Me.rdbYes.TabIndex = 3
        Me.rdbYes.TabStop = True
        Me.rdbYes.Text = "Yes"
        Me.rdbYes.UseVisualStyleBackColor = True
        '
        'lblRenewable
        '
        Me.lblRenewable.AutoSize = True
        Me.lblRenewable.Location = New System.Drawing.Point(11, 190)
        Me.lblRenewable.Name = "lblRenewable"
        Me.lblRenewable.Size = New System.Drawing.Size(87, 16)
        Me.lblRenewable.TabIndex = 6
        Me.lblRenewable.Text = "IsRenewable"
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Location = New System.Drawing.Point(22, 106)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(76, 16)
        Me.lblDescription.TabIndex = 4
        Me.lblDescription.Text = "Description"
        '
        'lblCategory
        '
        Me.lblCategory.AutoSize = True
        Me.lblCategory.Location = New System.Drawing.Point(37, 70)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(63, 16)
        Me.lblCategory.TabIndex = 2
        Me.lblCategory.Text = "Category"
        '
        'lblClassification
        '
        Me.lblClassification.AutoSize = True
        Me.lblClassification.Location = New System.Drawing.Point(12, 30)
        Me.lblClassification.Name = "lblClassification"
        Me.lblClassification.Size = New System.Drawing.Size(87, 16)
        Me.lblClassification.TabIndex = 0
        Me.lblClassification.Text = "Classification"
        '
        'txtPrintLayout
        '
        Me.txtPrintLayout.BackColor = System.Drawing.Color.White
        Me.txtPrintLayout.Location = New System.Drawing.Point(113, 204)
        Me.txtPrintLayout.Multiline = True
        Me.txtPrintLayout.Name = "txtPrintLayout"
        Me.txtPrintLayout.Size = New System.Drawing.Size(228, 91)
        Me.txtPrintLayout.TabIndex = 9
        Me.txtPrintLayout.WatermarkColor = System.Drawing.Color.Gray
        Me.txtPrintLayout.WatermarkText = "[Classname][Specs]"
        '
        'txtDescription
        '
        Me.txtDescription.BackColor = System.Drawing.Color.White
        Me.txtDescription.Location = New System.Drawing.Point(113, 79)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(228, 92)
        Me.txtDescription.TabIndex = 4
        Me.txtDescription.WatermarkColor = System.Drawing.Color.Gray
        Me.txtDescription.WatermarkText = "Description"
        '
        'txtCategory
        '
        Me.txtCategory.BackColor = System.Drawing.Color.White
        Me.txtCategory.Location = New System.Drawing.Point(113, 51)
        Me.txtCategory.Name = "txtCategory"
        Me.txtCategory.Size = New System.Drawing.Size(228, 22)
        Me.txtCategory.TabIndex = 3
        Me.txtCategory.WatermarkColor = System.Drawing.Color.Gray
        Me.txtCategory.WatermarkText = "Category"
        '
        'txtClassification
        '
        Me.txtClassification.BackColor = System.Drawing.Color.White
        Me.txtClassification.Location = New System.Drawing.Point(113, 24)
        Me.txtClassification.Name = "txtClassification"
        Me.txtClassification.Size = New System.Drawing.Size(228, 22)
        Me.txtClassification.TabIndex = 0
        Me.txtClassification.WatermarkColor = System.Drawing.Color.Gray
        Me.txtClassification.WatermarkText = "Clasification"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 16)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Category"
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
        Me.GroupBox3.Controls.Add(Me.Label2)
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Clasification"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSearch1)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtSearch1)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1129, 64)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Search"
        '
        'btnSearch1
        '
        Me.btnSearch1.Location = New System.Drawing.Point(1027, 21)
        Me.btnSearch1.Name = "btnSearch1"
        Me.btnSearch1.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch1.TabIndex = 16
        Me.btnSearch1.Text = "Search"
        Me.btnSearch1.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 16)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Search"
        '
        'txtSearch1
        '
        Me.txtSearch1.BackColor = System.Drawing.Color.White
        Me.txtSearch1.Location = New System.Drawing.Point(73, 21)
        Me.txtSearch1.Name = "txtSearch1"
        Me.txtSearch1.Size = New System.Drawing.Size(948, 22)
        Me.txtSearch1.TabIndex = 14
        Me.txtSearch1.WatermarkColor = System.Drawing.Color.Gray
        Me.txtSearch1.WatermarkText = "Search"
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
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle5
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
        Me.DataGridViewComboBoxColumn1.Items.AddRange(New Object() {"String", "Numeric", "Integer", "String", "Double", "Integer", "Boolean"})
        Me.DataGridViewComboBoxColumn1.Name = "DataGridViewComboBoxColumn1"
        Me.DataGridViewComboBoxColumn1.Width = 113
        '
        'DataGridViewComboBoxColumn2
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewComboBoxColumn2.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewComboBoxColumn2.FillWeight = 72.58589!
        Me.DataGridViewComboBoxColumn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DataGridViewComboBoxColumn2.HeaderText = "Layout"
        Me.DataGridViewComboBoxColumn2.Items.AddRange(New Object() {"TextBox", "MultiLine", "Yes/No", "TextBox", "MultiLine", "Yes/No"})
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
        Me.DataGridViewComboBoxColumn3.Items.AddRange(New Object() {"True", "False", "True", "False"})
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
        Me.TabPage2.Controls.Add(Me.lblModname)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1143, 433)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Export Config"
        '
        'lblModname
        '
        Me.lblModname.Controls.Add(Me.lblCount)
        Me.lblModname.Controls.Add(Me.chkSelectAll)
        Me.lblModname.Controls.Add(Me.btnBrowse)
        Me.lblModname.Controls.Add(Me.lvModule)
        Me.lblModname.Controls.Add(Me.btnExport)
        Me.lblModname.Controls.Add(Me.cmbModuleName)
        Me.lblModname.Controls.Add(Me.lblModuleName)
        Me.lblModname.Controls.Add(Me.txtReferenceNumber)
        Me.lblModname.Controls.Add(Me.lblReferenceNumber)
        Me.lblModname.Location = New System.Drawing.Point(13, 3)
        Me.lblModname.Name = "lblModname"
        Me.lblModname.Size = New System.Drawing.Size(1134, 427)
        Me.lblModname.TabIndex = 1
        Me.lblModname.TabStop = False
        '
        'lblCount
        '
        Me.lblCount.AutoSize = True
        Me.lblCount.Location = New System.Drawing.Point(117, 402)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(42, 16)
        Me.lblCount.TabIndex = 10
        Me.lblCount.Text = "Count"
        '
        'chkSelectAll
        '
        Me.chkSelectAll.AutoSize = True
        Me.chkSelectAll.Location = New System.Drawing.Point(17, 402)
        Me.chkSelectAll.Name = "chkSelectAll"
        Me.chkSelectAll.Size = New System.Drawing.Size(83, 20)
        Me.chkSelectAll.TabIndex = 8
        Me.chkSelectAll.Text = "Select All"
        Me.chkSelectAll.UseVisualStyleBackColor = True
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(972, 391)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(75, 34)
        Me.btnBrowse.TabIndex = 7
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'lvModule
        '
        Me.lvModule.FullRowSelect = True
        Me.lvModule.GridLines = True
        Me.lvModule.Location = New System.Drawing.Point(10, 81)
        Me.lvModule.Name = "lvModule"
        Me.lvModule.Size = New System.Drawing.Size(1118, 304)
        Me.lvModule.TabIndex = 6
        Me.lvModule.UseCompatibleStateImageBehavior = False
        Me.lvModule.View = System.Windows.Forms.View.Details
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(1053, 391)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(75, 34)
        Me.btnExport.TabIndex = 5
        Me.btnExport.Text = "Export"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'cmbModuleName
        '
        Me.cmbModuleName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbModuleName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbModuleName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbModuleName.FormattingEnabled = True
        Me.cmbModuleName.Items.AddRange(New Object() {"Money Transfer", "Branch", "Cash", "Item", "Rate", "Currency"})
        Me.cmbModuleName.Location = New System.Drawing.Point(106, 41)
        Me.cmbModuleName.Name = "cmbModuleName"
        Me.cmbModuleName.Size = New System.Drawing.Size(207, 24)
        Me.cmbModuleName.TabIndex = 4
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
        'txtReferenceNumber
        '
        Me.txtReferenceNumber.Location = New System.Drawing.Point(106, 13)
        Me.txtReferenceNumber.Name = "txtReferenceNumber"
        Me.txtReferenceNumber.Size = New System.Drawing.Size(207, 22)
        Me.txtReferenceNumber.TabIndex = 2
        Me.txtReferenceNumber.WatermarkColor = System.Drawing.Color.Gray
        Me.txtReferenceNumber.WatermarkText = "Reference No."
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
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(1048, 16)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 33)
        Me.btnSearch.TabIndex = 8
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.BackColor = System.Drawing.Color.White
        Me.txtSearch.Location = New System.Drawing.Point(9, 21)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(1023, 22)
        Me.txtSearch.TabIndex = 0
        Me.txtSearch.WatermarkColor = System.Drawing.Color.Gray
        Me.txtSearch.WatermarkText = "Search . . ."
        '
        'grpSearch
        '
        Me.grpSearch.Controls.Add(Me.txtSearch)
        Me.grpSearch.Controls.Add(Me.btnSearch)
        Me.grpSearch.Controls.Add(Me.lblSearch)
        Me.grpSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpSearch.Location = New System.Drawing.Point(6, 6)
        Me.grpSearch.Name = "grpSearch"
        Me.grpSearch.Size = New System.Drawing.Size(1129, 60)
        Me.grpSearch.TabIndex = 4
        Me.grpSearch.TabStop = False
        Me.grpSearch.Text = "Search"
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Location = New System.Drawing.Point(0, 0)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(51, 16)
        Me.lblSearch.TabIndex = 0
        Me.lblSearch.Text = "Search"
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
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblDateStatus})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 476)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(1166, 22)
        Me.StatusStrip.TabIndex = 13
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'lblDateStatus
        '
        Me.lblDateStatus.BackColor = System.Drawing.Color.Gray
        Me.lblDateStatus.Name = "lblDateStatus"
        Me.lblDateStatus.Size = New System.Drawing.Size(31, 17)
        Me.lblDateStatus.Text = "Date"
        '
        'frmAdminPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1166, 498)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frmAdminPanel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Admin Panel"
        Me.grpAddItem.ResumeLayout(False)
        Me.grpAddItem.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgSpecs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.lblModname.ResumeLayout(False)
        Me.lblModname.PerformLayout()
        Me.grpSearch.ResumeLayout(False)
        Me.grpSearch.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents grpAddItem As System.Windows.Forms.GroupBox
    Friend WithEvents rdbNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdbYes As System.Windows.Forms.RadioButton
    Friend WithEvents lblRenewable As System.Windows.Forms.Label
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents lblCategory As System.Windows.Forms.Label
    Friend WithEvents lblClassification As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents grpSearch As System.Windows.Forms.GroupBox
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents lblModname As System.Windows.Forms.GroupBox
    Friend WithEvents lblReferenceNumber As System.Windows.Forms.Label
    Friend WithEvents lblModuleName As System.Windows.Forms.Label
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents cmbModuleName As System.Windows.Forms.ComboBox

    Friend WithEvents dgSpecification As System.Windows.Forms.DataGridView
    Friend WithEvents lblPrintLayout As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lvModule As System.Windows.Forms.ListView
    Friend WithEvents SFD As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents oFd As System.Windows.Forms.OpenFileDialog
    Friend WithEvents dgSpecs As System.Windows.Forms.DataGridView
    Friend WithEvents txtReferenceNumber As Pawnshop.watermark
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn2 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn3 As System.Windows.Forms.DataGridViewComboBoxColumn


    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboSchemename As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents rbNo As System.Windows.Forms.RadioButton
    Friend WithEvents rbYes As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label


    Friend WithEvents cbotxtSchemename As System.Windows.Forms.ComboBox

    Friend WithEvents chkSelectAll As System.Windows.Forms.CheckBox
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents lblDateStatus As System.Windows.Forms.ToolStripStatusLabel

    Friend WithEvents txtPrintLayout As Pawnshop.watermark
    Friend WithEvents txtDescription As Pawnshop.watermark
    Friend WithEvents txtCategory As Pawnshop.watermark
    Friend WithEvents txtClassification As Pawnshop.watermark
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtSearch As Pawnshop.watermark
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtSearch1 As Pawnshop.watermark
    Friend WithEvents btnSearch1 As System.Windows.Forms.Button


End Class
