<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUserManagement
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
        Me.tbControl = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkShowPassword = New System.Windows.Forms.CheckBox()
        Me.btnCreateAccount = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rbMale = New System.Windows.Forms.RadioButton()
        Me.rbFemale = New System.Windows.Forms.RadioButton()
        Me.txtBirthday = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgRulePrivilege = New System.Windows.Forms.DataGridView()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.btnCancelAP = New System.Windows.Forms.Button()
        Me.btnSaveAP = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.lvUserList = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtPasword1 = New UserManagementEnhancement.watermark()
        Me.txtContactnumber = New UserManagementEnhancement.watermark()
        Me.txtEmailaddress = New UserManagementEnhancement.watermark()
        Me.txtPassword = New UserManagementEnhancement.watermark()
        Me.txtLastname = New UserManagementEnhancement.watermark()
        Me.txtMiddlename = New UserManagementEnhancement.watermark()
        Me.txtFirstname = New UserManagementEnhancement.watermark()
        Me.txtUsername = New UserManagementEnhancement.watermark()
        Me.tbControl.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgRulePrivilege, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbControl
        '
        Me.tbControl.Controls.Add(Me.TabPage1)
        Me.tbControl.Controls.Add(Me.TabPage2)
        Me.tbControl.Controls.Add(Me.TabPage3)
        Me.tbControl.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbControl.Location = New System.Drawing.Point(12, 11)
        Me.tbControl.Name = "tbControl"
        Me.tbControl.Padding = New System.Drawing.Point(20, 10)
        Me.tbControl.SelectedIndex = 0
        Me.tbControl.Size = New System.Drawing.Size(732, 503)
        Me.tbControl.TabIndex = 5
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.lvUserList)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 39)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(724, 460)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Registration"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtPasword1)
        Me.GroupBox1.Controls.Add(Me.txtContactnumber)
        Me.GroupBox1.Controls.Add(Me.txtEmailaddress)
        Me.GroupBox1.Controls.Add(Me.txtPassword)
        Me.GroupBox1.Controls.Add(Me.txtLastname)
        Me.GroupBox1.Controls.Add(Me.txtMiddlename)
        Me.GroupBox1.Controls.Add(Me.txtFirstname)
        Me.GroupBox1.Controls.Add(Me.txtUsername)
        Me.GroupBox1.Controls.Add(Me.chkShowPassword)
        Me.GroupBox1.Controls.Add(Me.btnCreateAccount)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.rbMale)
        Me.GroupBox1.Controls.Add(Me.rbFemale)
        Me.GroupBox1.Controls.Add(Me.txtBirthday)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(284, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(434, 435)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sign Up"
        '
        'chkShowPassword
        '
        Me.chkShowPassword.AutoSize = True
        Me.chkShowPassword.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkShowPassword.Location = New System.Drawing.Point(279, 180)
        Me.chkShowPassword.Name = "chkShowPassword"
        Me.chkShowPassword.Size = New System.Drawing.Size(134, 21)
        Me.chkShowPassword.TabIndex = 6
        Me.chkShowPassword.Text = "Show Password"
        Me.chkShowPassword.UseVisualStyleBackColor = True
        '
        'btnCreateAccount
        '
        Me.btnCreateAccount.BackColor = System.Drawing.Color.White
        Me.btnCreateAccount.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreateAccount.Location = New System.Drawing.Point(217, 389)
        Me.btnCreateAccount.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnCreateAccount.Name = "btnCreateAccount"
        Me.btnCreateAccount.Size = New System.Drawing.Size(202, 37)
        Me.btnCreateAccount.TabIndex = 12
        Me.btnCreateAccount.Text = "Create Account"
        Me.btnCreateAccount.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(17, 344)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 22)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Gender"
        '
        'rbMale
        '
        Me.rbMale.AutoSize = True
        Me.rbMale.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbMale.Location = New System.Drawing.Point(249, 343)
        Me.rbMale.Name = "rbMale"
        Me.rbMale.Size = New System.Drawing.Size(62, 23)
        Me.rbMale.TabIndex = 11
        Me.rbMale.TabStop = True
        Me.rbMale.Text = "Male"
        Me.rbMale.UseVisualStyleBackColor = True
        '
        'rbFemale
        '
        Me.rbFemale.AutoSize = True
        Me.rbFemale.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbFemale.Location = New System.Drawing.Point(145, 343)
        Me.rbFemale.Name = "rbFemale"
        Me.rbFemale.Size = New System.Drawing.Size(82, 23)
        Me.rbFemale.TabIndex = 10
        Me.rbFemale.TabStop = True
        Me.rbFemale.Text = "Female"
        Me.rbFemale.UseVisualStyleBackColor = True
        '
        'txtBirthday
        '
        Me.txtBirthday.CalendarMonthBackground = System.Drawing.Color.White
        Me.txtBirthday.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBirthday.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtBirthday.Location = New System.Drawing.Point(101, 294)
        Me.txtBirthday.Name = "txtBirthday"
        Me.txtBirthday.Size = New System.Drawing.Size(318, 29)
        Me.txtBirthday.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 296)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 22)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Birthday"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.Silver
        Me.TabPage2.Controls.Add(Me.dgRulePrivilege)
        Me.TabPage2.Controls.Add(Me.btnCancel)
        Me.TabPage2.Controls.Add(Me.btnSave)
        Me.TabPage2.Location = New System.Drawing.Point(4, 39)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(724, 460)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Privilege"
        '
        'dgRulePrivilege
        '
        Me.dgRulePrivilege.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgRulePrivilege.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4})
        Me.dgRulePrivilege.Location = New System.Drawing.Point(6, 6)
        Me.dgRulePrivilege.Name = "dgRulePrivilege"
        Me.dgRulePrivilege.RowHeadersVisible = False
        Me.dgRulePrivilege.Size = New System.Drawing.Size(712, 405)
        Me.dgRulePrivilege.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.White
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(575, 417)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(144, 37)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.White
        Me.btnSave.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(427, 417)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(144, 37)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "Save rules"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.btnCancelAP)
        Me.TabPage3.Controls.Add(Me.btnSaveAP)
        Me.TabPage3.Controls.Add(Me.GroupBox2)
        Me.TabPage3.Location = New System.Drawing.Point(4, 39)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(724, 460)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Add Privilege"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'btnCancelAP
        '
        Me.btnCancelAP.BackColor = System.Drawing.Color.White
        Me.btnCancelAP.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelAP.Location = New System.Drawing.Point(462, 202)
        Me.btnCancelAP.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnCancelAP.Name = "btnCancelAP"
        Me.btnCancelAP.Size = New System.Drawing.Size(102, 37)
        Me.btnCancelAP.TabIndex = 7
        Me.btnCancelAP.Text = "Cancel"
        Me.btnCancelAP.UseVisualStyleBackColor = False
        '
        'btnSaveAP
        '
        Me.btnSaveAP.BackColor = System.Drawing.Color.White
        Me.btnSaveAP.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveAP.Location = New System.Drawing.Point(356, 202)
        Me.btnSaveAP.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnSaveAP.Name = "btnSaveAP"
        Me.btnSaveAP.Size = New System.Drawing.Size(102, 37)
        Me.btnSaveAP.TabIndex = 6
        Me.btnSaveAP.Text = "Save"
        Me.btnSaveAP.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(129, 70)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(431, 126)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'Column1
        '
        Me.Column1.HeaderText = "Privilege Type"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 220
        '
        'Column2
        '
        Me.Column2.HeaderText = "No Access"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 160
        '
        'Column3
        '
        Me.Column3.HeaderText = "Read Only"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 160
        '
        'Column4
        '
        Me.Column4.HeaderText = "Full Access"
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 160
        '
        'lvUserList
        '
        Me.lvUserList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lvUserList.FullRowSelect = True
        Me.lvUserList.GridLines = True
        Me.lvUserList.Location = New System.Drawing.Point(3, 18)
        Me.lvUserList.Name = "lvUserList"
        Me.lvUserList.Size = New System.Drawing.Size(275, 421)
        Me.lvUserList.TabIndex = 1
        Me.lvUserList.UseCompatibleStateImageBehavior = False
        Me.lvUserList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "#"
        Me.ColumnHeader1.Width = 31
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Name"
        Me.ColumnHeader2.Width = 239
        '
        'txtPasword1
        '
        Me.txtPasword1.Location = New System.Drawing.Point(21, 178)
        Me.txtPasword1.Name = "txtPasword1"
        Me.txtPasword1.Size = New System.Drawing.Size(245, 29)
        Me.txtPasword1.TabIndex = 5
        Me.txtPasword1.UseSystemPasswordChar = True
        Me.txtPasword1.WatermarkColor = System.Drawing.Color.Gray
        Me.txtPasword1.WatermarkText = "Re-enter password"
        '
        'txtContactnumber
        '
        Me.txtContactnumber.Location = New System.Drawing.Point(21, 253)
        Me.txtContactnumber.MaxLength = 13
        Me.txtContactnumber.Name = "txtContactnumber"
        Me.txtContactnumber.Size = New System.Drawing.Size(398, 29)
        Me.txtContactnumber.TabIndex = 8
        Me.txtContactnumber.WatermarkColor = System.Drawing.Color.Gray
        Me.txtContactnumber.WatermarkText = "Contact Number"
        '
        'txtEmailaddress
        '
        Me.txtEmailaddress.Location = New System.Drawing.Point(21, 213)
        Me.txtEmailaddress.Name = "txtEmailaddress"
        Me.txtEmailaddress.Size = New System.Drawing.Size(398, 29)
        Me.txtEmailaddress.TabIndex = 7
        Me.txtEmailaddress.WatermarkColor = System.Drawing.Color.Gray
        Me.txtEmailaddress.WatermarkText = "Email Address"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(21, 141)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(398, 29)
        Me.txtPassword.TabIndex = 4
        Me.txtPassword.UseSystemPasswordChar = True
        Me.txtPassword.WatermarkColor = System.Drawing.Color.Gray
        Me.txtPassword.WatermarkText = "Password"
        '
        'txtLastname
        '
        Me.txtLastname.Location = New System.Drawing.Point(21, 104)
        Me.txtLastname.Name = "txtLastname"
        Me.txtLastname.Size = New System.Drawing.Size(398, 29)
        Me.txtLastname.TabIndex = 3
        Me.txtLastname.WatermarkColor = System.Drawing.Color.Gray
        Me.txtLastname.WatermarkText = "Lastname"
        '
        'txtMiddlename
        '
        Me.txtMiddlename.Location = New System.Drawing.Point(228, 66)
        Me.txtMiddlename.Name = "txtMiddlename"
        Me.txtMiddlename.Size = New System.Drawing.Size(191, 29)
        Me.txtMiddlename.TabIndex = 2
        Me.txtMiddlename.WatermarkColor = System.Drawing.Color.Gray
        Me.txtMiddlename.WatermarkText = "Middlename"
        '
        'txtFirstname
        '
        Me.txtFirstname.Location = New System.Drawing.Point(21, 66)
        Me.txtFirstname.Name = "txtFirstname"
        Me.txtFirstname.Size = New System.Drawing.Size(201, 29)
        Me.txtFirstname.TabIndex = 1
        Me.txtFirstname.WatermarkColor = System.Drawing.Color.Gray
        Me.txtFirstname.WatermarkText = "Firstname"
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(21, 28)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(398, 29)
        Me.txtUsername.TabIndex = 0
        Me.txtUsername.WatermarkColor = System.Drawing.Color.Gray
        Me.txtUsername.WatermarkText = "Username"
        '
        'frmUserManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(750, 527)
        Me.Controls.Add(Me.tbControl)
        Me.Name = "frmUserManagement"
        Me.Text = "User Management"
        Me.tbControl.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgRulePrivilege, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbControl As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkShowPassword As System.Windows.Forms.CheckBox
    Friend WithEvents btnCreateAccount As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rbMale As System.Windows.Forms.RadioButton
    Friend WithEvents rbFemale As System.Windows.Forms.RadioButton
    Friend WithEvents txtBirthday As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dgRulePrivilege As System.Windows.Forms.DataGridView
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents btnCancelAP As System.Windows.Forms.Button
    Friend WithEvents btnSaveAP As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPasword1 As UserManagementEnhancement.watermark
    Friend WithEvents txtContactnumber As UserManagementEnhancement.watermark
    Friend WithEvents txtEmailaddress As UserManagementEnhancement.watermark
    Friend WithEvents txtPassword As UserManagementEnhancement.watermark
    Friend WithEvents txtLastname As UserManagementEnhancement.watermark
    Friend WithEvents txtMiddlename As UserManagementEnhancement.watermark
    Friend WithEvents txtFirstname As UserManagementEnhancement.watermark
    Friend WithEvents txtUsername As UserManagementEnhancement.watermark
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents lvUserList As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader

End Class
