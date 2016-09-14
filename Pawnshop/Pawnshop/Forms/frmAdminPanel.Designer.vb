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
        Me.grpAddItem = New System.Windows.Forms.GroupBox()
        Me.txtPrintLayout = New System.Windows.Forms.TextBox()
        Me.lblPrintLayout = New System.Windows.Forms.Label()
        Me.rdbNo = New System.Windows.Forms.RadioButton()
        Me.rdbYes = New System.Windows.Forms.RadioButton()
        Me.lblRenewable = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.txtCategory = New System.Windows.Forms.TextBox()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.txtClassifiction = New System.Windows.Forms.TextBox()
        Me.lblClassification = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.dgSpecification = New System.Windows.Forms.DataGridView()
        Me.grpSearch = New System.Windows.Forms.GroupBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lvModule = New System.Windows.Forms.ListView()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.cmbModuleName = New System.Windows.Forms.ComboBox()
        Me.lblModuleName = New System.Windows.Forms.Label()
        Me.txtReferenceNumber = New System.Windows.Forms.TextBox()
        Me.lblReferenceNumber = New System.Windows.Forms.Label()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.SFD = New System.Windows.Forms.SaveFileDialog()
        Me.oFd = New System.Windows.Forms.OpenFileDialog()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.grpAddItem.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgSpecification, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSearch.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpAddItem
        '
        Me.grpAddItem.BackColor = System.Drawing.Color.Gainsboro
        Me.grpAddItem.Controls.Add(Me.txtPrintLayout)
        Me.grpAddItem.Controls.Add(Me.lblPrintLayout)
        Me.grpAddItem.Controls.Add(Me.rdbNo)
        Me.grpAddItem.Controls.Add(Me.rdbYes)
        Me.grpAddItem.Controls.Add(Me.lblRenewable)
        Me.grpAddItem.Controls.Add(Me.txtDescription)
        Me.grpAddItem.Controls.Add(Me.lblDescription)
        Me.grpAddItem.Controls.Add(Me.txtCategory)
        Me.grpAddItem.Controls.Add(Me.lblCategory)
        Me.grpAddItem.Controls.Add(Me.txtClassifiction)
        Me.grpAddItem.Controls.Add(Me.lblClassification)
        Me.grpAddItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpAddItem.ForeColor = System.Drawing.SystemColors.MenuText
        Me.grpAddItem.Location = New System.Drawing.Point(6, 72)
        Me.grpAddItem.Name = "grpAddItem"
        Me.grpAddItem.Size = New System.Drawing.Size(362, 316)
        Me.grpAddItem.TabIndex = 0
        Me.grpAddItem.TabStop = False
        Me.grpAddItem.Text = "Item Information"
        '
        'txtPrintLayout
        '
        Me.txtPrintLayout.Location = New System.Drawing.Point(105, 236)
        Me.txtPrintLayout.Multiline = True
        Me.txtPrintLayout.Name = "txtPrintLayout"
        Me.txtPrintLayout.Size = New System.Drawing.Size(250, 68)
        Me.txtPrintLayout.TabIndex = 5
        Me.txtPrintLayout.Text = "Print Layout"
        '
        'lblPrintLayout
        '
        Me.lblPrintLayout.AutoSize = True
        Me.lblPrintLayout.Location = New System.Drawing.Point(23, 232)
        Me.lblPrintLayout.Name = "lblPrintLayout"
        Me.lblPrintLayout.Size = New System.Drawing.Size(77, 16)
        Me.lblPrintLayout.TabIndex = 8
        Me.lblPrintLayout.Text = "Print Layout"
        '
        'rdbNo
        '
        Me.rdbNo.AutoSize = True
        Me.rdbNo.Location = New System.Drawing.Point(159, 195)
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
        Me.rdbYes.Location = New System.Drawing.Point(105, 195)
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
        Me.lblRenewable.Location = New System.Drawing.Point(12, 196)
        Me.lblRenewable.Name = "lblRenewable"
        Me.lblRenewable.Size = New System.Drawing.Size(87, 16)
        Me.lblRenewable.TabIndex = 6
        Me.lblRenewable.Text = "IsRenewable"
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(105, 114)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(250, 71)
        Me.txtDescription.TabIndex = 2
        Me.txtDescription.Text = "Description"
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Location = New System.Drawing.Point(23, 114)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(76, 16)
        Me.lblDescription.TabIndex = 4
        Me.lblDescription.Text = "Description"
        '
        'txtCategory
        '
        Me.txtCategory.Location = New System.Drawing.Point(105, 71)
        Me.txtCategory.Name = "txtCategory"
        Me.txtCategory.Size = New System.Drawing.Size(250, 22)
        Me.txtCategory.TabIndex = 1
        Me.txtCategory.Text = "Category"
        '
        'lblCategory
        '
        Me.lblCategory.AutoSize = True
        Me.lblCategory.Location = New System.Drawing.Point(36, 77)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(63, 16)
        Me.lblCategory.TabIndex = 2
        Me.lblCategory.Text = "Category"
        '
        'txtClassifiction
        '
        Me.txtClassifiction.Location = New System.Drawing.Point(105, 30)
        Me.txtClassifiction.Name = "txtClassifiction"
        Me.txtClassifiction.Size = New System.Drawing.Size(250, 22)
        Me.txtClassifiction.TabIndex = 0
        Me.txtClassifiction.Text = "Classfication"
        '
        'lblClassification
        '
        Me.lblClassification.AutoSize = True
        Me.lblClassification.Location = New System.Drawing.Point(13, 34)
        Me.lblClassification.Name = "lblClassification"
        Me.lblClassification.Size = New System.Drawing.Size(87, 16)
        Me.lblClassification.TabIndex = 0
        Me.lblClassification.Text = "Classification"
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
        Me.TabControl1.TabIndex = 12
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Gainsboro
        Me.TabPage1.Controls.Add(Me.btnClose)
        Me.TabPage1.Controls.Add(Me.dgSpecification)
        Me.TabPage1.Controls.Add(Me.btnSave)
        Me.TabPage1.Controls.Add(Me.btnUpdate)
        Me.TabPage1.Controls.Add(Me.grpSearch)
        Me.TabPage1.Controls.Add(Me.grpAddItem)
        Me.TabPage1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1143, 433)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Item"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(1061, 394)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 33)
        Me.btnClose.TabIndex = 13
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'dgSpecification
        '
        Me.dgSpecification.AllowUserToDeleteRows = False
        Me.dgSpecification.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSpecification.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column3, Me.Column1, Me.Column2, Me.Column4, Me.Column5, Me.Column6})
        Me.dgSpecification.Location = New System.Drawing.Point(374, 79)
        Me.dgSpecification.Name = "dgSpecification"
        Me.dgSpecification.RowHeadersVisible = False
        Me.dgSpecification.RowHeadersWidth = 20
        Me.dgSpecification.Size = New System.Drawing.Size(761, 309)
        Me.dgSpecification.TabIndex = 1
        '
        'grpSearch
        '
        Me.grpSearch.Controls.Add(Me.btnSearch)
        Me.grpSearch.Controls.Add(Me.txtSearch)
        Me.grpSearch.Controls.Add(Me.lblSearch)
        Me.grpSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpSearch.Location = New System.Drawing.Point(6, 6)
        Me.grpSearch.Name = "grpSearch"
        Me.grpSearch.Size = New System.Drawing.Size(1129, 60)
        Me.grpSearch.TabIndex = 12
        Me.grpSearch.TabStop = False
        Me.grpSearch.Text = "Search"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(1048, 18)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 36)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(77, 21)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(965, 22)
        Me.txtSearch.TabIndex = 0
        Me.txtSearch.Text = "Search. . ."
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Location = New System.Drawing.Point(20, 23)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(51, 16)
        Me.lblSearch.TabIndex = 9
        Me.lblSearch.Text = "Search"
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
        Me.GroupBox2.Controls.Add(Me.btnBrowse)
        Me.GroupBox2.Controls.Add(Me.lvModule)
        Me.GroupBox2.Controls.Add(Me.btnExport)
        Me.GroupBox2.Controls.Add(Me.cmbModuleName)
        Me.GroupBox2.Controls.Add(Me.lblModuleName)
        Me.GroupBox2.Controls.Add(Me.txtReferenceNumber)
        Me.GroupBox2.Controls.Add(Me.lblReferenceNumber)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1134, 427)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
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
        'txtReferenceNumber
        '
        Me.txtReferenceNumber.Location = New System.Drawing.Point(106, 12)
        Me.txtReferenceNumber.Name = "txtReferenceNumber"
        Me.txtReferenceNumber.Size = New System.Drawing.Size(207, 22)
        Me.txtReferenceNumber.TabIndex = 1
        Me.txtReferenceNumber.Text = "Reference No."
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
        'Column3
        '
        Me.Column3.HeaderText = "Short Code"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 120
        '
        'Column1
        '
        Me.Column1.HeaderText = "Specification Name"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 160
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.Column2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Column2.HeaderText = "Specification Type"
        Me.Column2.Items.AddRange(New Object() {"String", "Double", "Integer", "Boolean", "", "", ""})
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 113
        '
        'Column4
        '
        Me.Column4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Column4.HeaderText = "Layout"
        Me.Column4.Items.AddRange(New Object() {"Textbox", "Multiline", "Yes/No"})
        Me.Column4.Name = "Column4"
        Me.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column4.Width = 120
        '
        'Column5
        '
        Me.Column5.HeaderText = "Unit of Measure"
        Me.Column5.Name = "Column5"
        Me.Column5.Width = 140
        '
        'Column6
        '
        Me.Column6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Column6.HeaderText = "Is Required"
        Me.Column6.Items.AddRange(New Object() {"Yes", "No"})
        Me.Column6.Name = "Column6"
        Me.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
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
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(972, 402)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowse.TabIndex = 7
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'frmAdminPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1166, 487)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frmAdminPanel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Admin Panel"
        Me.grpAddItem.ResumeLayout(False)
        Me.grpAddItem.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgSpecification, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSearch.ResumeLayout(False)
        Me.grpSearch.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpAddItem As System.Windows.Forms.GroupBox
    Friend WithEvents rdbNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdbYes As System.Windows.Forms.RadioButton
    Friend WithEvents lblRenewable As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents txtCategory As System.Windows.Forms.TextBox
    Friend WithEvents lblCategory As System.Windows.Forms.Label
    Friend WithEvents txtClassifiction As System.Windows.Forms.TextBox
    Friend WithEvents lblClassification As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents grpSearch As System.Windows.Forms.GroupBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblReferenceNumber As System.Windows.Forms.Label
    Friend WithEvents lblModuleName As System.Windows.Forms.Label
    Friend WithEvents txtReferenceNumber As System.Windows.Forms.TextBox
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents cmbModuleName As System.Windows.Forms.ComboBox
    Friend WithEvents dgSpecification As System.Windows.Forms.DataGridView
    Friend WithEvents txtPrintLayout As System.Windows.Forms.TextBox
    Friend WithEvents lblPrintLayout As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lvModule As System.Windows.Forms.ListView
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents SFD As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents oFd As System.Windows.Forms.OpenFileDialog
End Class
