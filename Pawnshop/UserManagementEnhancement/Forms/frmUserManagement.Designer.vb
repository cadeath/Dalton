﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgRulePrivilege = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.lvUserList = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtPasword1 = New UserManagementEnhancement.watermark()
        Me.txtContactnumber = New UserManagementEnhancement.watermark()
        Me.txtEmailaddress = New UserManagementEnhancement.watermark()
        Me.txtPassword = New UserManagementEnhancement.watermark()
        Me.txtLastname = New UserManagementEnhancement.watermark()
        Me.txtMiddlename = New UserManagementEnhancement.watermark()
        Me.txtFirstname = New UserManagementEnhancement.watermark()
        Me.txtUsername = New UserManagementEnhancement.watermark()
        Me.chkShowPassword = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rbMale = New System.Windows.Forms.RadioButton()
        Me.rbFemale = New System.Windows.Forms.RadioButton()
        Me.txtBirthday = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancell = New System.Windows.Forms.Button()
        Me.btnCreateAccount = New System.Windows.Forms.Button()
        Me.tbControl = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.ChkInactivateUser = New System.Windows.Forms.CheckBox()
        Me.txtPasswordAge = New UserManagementEnhancement.watermark()
        Me.txtAddDays = New UserManagementEnhancement.watermark()
        Me.CHKISEXPIRED = New System.Windows.Forms.CheckBox()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lvALL_USER_LIST = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSearch = New UserManagementEnhancement.watermark()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.btnSaveSettings = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtFailedAttemp = New UserManagementEnhancement.watermark()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.rbEnable = New System.Windows.Forms.RadioButton()
        Me.rbDisable = New System.Windows.Forms.RadioButton()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgRulePrivilege, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tbControl.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.Silver
        Me.TabPage2.Controls.Add(Me.dgRulePrivilege)
        Me.TabPage2.Location = New System.Drawing.Point(4, 39)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(724, 414)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Access"
        '
        'dgRulePrivilege
        '
        Me.dgRulePrivilege.AllowUserToAddRows = False
        Me.dgRulePrivilege.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgRulePrivilege.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3})
        Me.dgRulePrivilege.Location = New System.Drawing.Point(135, 5)
        Me.dgRulePrivilege.Name = "dgRulePrivilege"
        Me.dgRulePrivilege.RowHeadersVisible = False
        Me.dgRulePrivilege.Size = New System.Drawing.Size(433, 402)
        Me.dgRulePrivilege.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.HeaderText = "#"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 30
        '
        'Column2
        '
        Me.Column2.HeaderText = "PRIVILEGE TYPE"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 220
        '
        'Column3
        '
        Me.Column3.HeaderText = "ACCESS TYPE"
        Me.Column3.Items.AddRange(New Object() {"Full Access", "Read Only", "No Access"})
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 180
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.lvUserList)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 39)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(724, 414)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "User Information"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'lvUserList
        '
        Me.lvUserList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lvUserList.FullRowSelect = True
        Me.lvUserList.GridLines = True
        Me.lvUserList.Location = New System.Drawing.Point(3, 18)
        Me.lvUserList.Name = "lvUserList"
        Me.lvUserList.Size = New System.Drawing.Size(275, 368)
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
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.rbMale)
        Me.GroupBox1.Controls.Add(Me.rbFemale)
        Me.GroupBox1.Controls.Add(Me.txtBirthday)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(284, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(434, 380)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sign Up"
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
        'btnCancell
        '
        Me.btnCancell.BackColor = System.Drawing.Color.White
        Me.btnCancell.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancell.Location = New System.Drawing.Point(538, 474)
        Me.btnCancell.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnCancell.Name = "btnCancell"
        Me.btnCancell.Size = New System.Drawing.Size(202, 37)
        Me.btnCancell.TabIndex = 19
        Me.btnCancell.Text = "&Cancel"
        Me.btnCancell.UseVisualStyleBackColor = False
        '
        'btnCreateAccount
        '
        Me.btnCreateAccount.BackColor = System.Drawing.Color.White
        Me.btnCreateAccount.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreateAccount.Location = New System.Drawing.Point(332, 474)
        Me.btnCreateAccount.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnCreateAccount.Name = "btnCreateAccount"
        Me.btnCreateAccount.Size = New System.Drawing.Size(202, 37)
        Me.btnCreateAccount.TabIndex = 12
        Me.btnCreateAccount.Text = "&Create Account"
        Me.btnCreateAccount.UseVisualStyleBackColor = False
        '
        'tbControl
        '
        Me.tbControl.Controls.Add(Me.TabPage1)
        Me.tbControl.Controls.Add(Me.TabPage2)
        Me.tbControl.Controls.Add(Me.TabPage3)
        Me.tbControl.Controls.Add(Me.TabPage4)
        Me.tbControl.Controls.Add(Me.TabPage5)
        Me.tbControl.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbControl.Location = New System.Drawing.Point(12, 11)
        Me.tbControl.Name = "tbControl"
        Me.tbControl.Padding = New System.Drawing.Point(20, 10)
        Me.tbControl.SelectedIndex = 0
        Me.tbControl.Size = New System.Drawing.Size(732, 457)
        Me.tbControl.TabIndex = 5
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.GroupBox2)
        Me.TabPage3.Location = New System.Drawing.Point(4, 39)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(724, 414)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Validation"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox2.Controls.Add(Me.lblStatus)
        Me.GroupBox2.Controls.Add(Me.ChkInactivateUser)
        Me.GroupBox2.Controls.Add(Me.txtPasswordAge)
        Me.GroupBox2.Controls.Add(Me.txtAddDays)
        Me.GroupBox2.Controls.Add(Me.CHKISEXPIRED)
        Me.GroupBox2.Location = New System.Drawing.Point(175, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(390, 402)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(13, 195)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(77, 16)
        Me.lblStatus.TabIndex = 8
        Me.lblStatus.Text = "User Status"
        '
        'ChkInactivateUser
        '
        Me.ChkInactivateUser.AutoSize = True
        Me.ChkInactivateUser.Location = New System.Drawing.Point(12, 163)
        Me.ChkInactivateUser.Name = "ChkInactivateUser"
        Me.ChkInactivateUser.Size = New System.Drawing.Size(152, 20)
        Me.ChkInactivateUser.TabIndex = 3
        Me.ChkInactivateUser.Text = "Disable this account?"
        Me.ChkInactivateUser.UseVisualStyleBackColor = True
        '
        'txtPasswordAge
        '
        Me.txtPasswordAge.BackColor = System.Drawing.SystemColors.Window
        Me.txtPasswordAge.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPasswordAge.Location = New System.Drawing.Point(12, 128)
        Me.txtPasswordAge.Name = "txtPasswordAge"
        Me.txtPasswordAge.Size = New System.Drawing.Size(368, 29)
        Me.txtPasswordAge.TabIndex = 2
        Me.txtPasswordAge.WatermarkColor = System.Drawing.Color.Gray
        Me.txtPasswordAge.WatermarkText = "Enter number days password's expiration"
        '
        'txtAddDays
        '
        Me.txtAddDays.BackColor = System.Drawing.SystemColors.Window
        Me.txtAddDays.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddDays.Location = New System.Drawing.Point(12, 93)
        Me.txtAddDays.Name = "txtAddDays"
        Me.txtAddDays.Size = New System.Drawing.Size(368, 29)
        Me.txtAddDays.TabIndex = 1
        Me.txtAddDays.WatermarkColor = System.Drawing.Color.Gray
        Me.txtAddDays.WatermarkText = "Enter number of days to inactive account"
        '
        'CHKISEXPIRED
        '
        Me.CHKISEXPIRED.AutoSize = True
        Me.CHKISEXPIRED.Checked = True
        Me.CHKISEXPIRED.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKISEXPIRED.Location = New System.Drawing.Point(12, 67)
        Me.CHKISEXPIRED.Name = "CHKISEXPIRED"
        Me.CHKISEXPIRED.Size = New System.Drawing.Size(162, 20)
        Me.CHKISEXPIRED.TabIndex = 0
        Me.CHKISEXPIRED.Text = "Is account will expired?"
        Me.CHKISEXPIRED.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.Label4)
        Me.TabPage4.Controls.Add(Me.lvALL_USER_LIST)
        Me.TabPage4.Controls.Add(Me.Label3)
        Me.TabPage4.Controls.Add(Me.txtSearch)
        Me.TabPage4.Location = New System.Drawing.Point(4, 39)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(724, 414)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Find User"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(284, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(153, 14)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Double Click to Edit Information"
        '
        'lvALL_USER_LIST
        '
        Me.lvALL_USER_LIST.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.lvALL_USER_LIST.FullRowSelect = True
        Me.lvALL_USER_LIST.Location = New System.Drawing.Point(9, 64)
        Me.lvALL_USER_LIST.Name = "lvALL_USER_LIST"
        Me.lvALL_USER_LIST.Size = New System.Drawing.Size(709, 344)
        Me.lvALL_USER_LIST.TabIndex = 2
        Me.lvALL_USER_LIST.UseCompatibleStateImageBehavior = False
        Me.lvALL_USER_LIST.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "#"
        Me.ColumnHeader3.Width = 41
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Name"
        Me.ColumnHeader4.Width = 350
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Email Address"
        Me.ColumnHeader5.Width = 305
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Search"
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(61, 18)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(657, 22)
        Me.txtSearch.TabIndex = 1
        Me.txtSearch.WatermarkColor = System.Drawing.Color.Gray
        Me.txtSearch.WatermarkText = "Search . . ."
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.rbDisable)
        Me.TabPage5.Controls.Add(Me.rbEnable)
        Me.TabPage5.Controls.Add(Me.Label6)
        Me.TabPage5.Controls.Add(Me.btnSaveSettings)
        Me.TabPage5.Controls.Add(Me.Label5)
        Me.TabPage5.Controls.Add(Me.txtFailedAttemp)
        Me.TabPage5.Location = New System.Drawing.Point(4, 39)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(724, 414)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Settings"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'btnSaveSettings
        '
        Me.btnSaveSettings.BackColor = System.Drawing.Color.White
        Me.btnSaveSettings.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveSettings.Location = New System.Drawing.Point(570, 361)
        Me.btnSaveSettings.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnSaveSettings.Name = "btnSaveSettings"
        Me.btnSaveSettings.Size = New System.Drawing.Size(140, 37)
        Me.btnSaveSettings.TabIndex = 20
        Me.btnSaveSettings.Text = "&Save Settings"
        Me.btnSaveSettings.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(107, 16)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "# of failed attemp"
        '
        'txtFailedAttemp
        '
        Me.txtFailedAttemp.BackColor = System.Drawing.SystemColors.Window
        Me.txtFailedAttemp.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFailedAttemp.Location = New System.Drawing.Point(130, 33)
        Me.txtFailedAttemp.Name = "txtFailedAttemp"
        Me.txtFailedAttemp.Size = New System.Drawing.Size(223, 26)
        Me.txtFailedAttemp.TabIndex = 7
        Me.txtFailedAttemp.WatermarkColor = System.Drawing.Color.Gray
        Me.txtFailedAttemp.WatermarkText = "Enter number of failed attemp"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 76)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(179, 16)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Enable/Disable Failed Attemp"
        '
        'rbEnable
        '
        Me.rbEnable.AutoSize = True
        Me.rbEnable.Location = New System.Drawing.Point(206, 76)
        Me.rbEnable.Name = "rbEnable"
        Me.rbEnable.Size = New System.Drawing.Size(66, 20)
        Me.rbEnable.TabIndex = 23
        Me.rbEnable.TabStop = True
        Me.rbEnable.Text = "Enable"
        Me.rbEnable.UseVisualStyleBackColor = True
        '
        'rbDisable
        '
        Me.rbDisable.AutoSize = True
        Me.rbDisable.Location = New System.Drawing.Point(284, 76)
        Me.rbDisable.Name = "rbDisable"
        Me.rbDisable.Size = New System.Drawing.Size(69, 20)
        Me.rbDisable.TabIndex = 24
        Me.rbDisable.TabStop = True
        Me.rbDisable.Text = "Disable"
        Me.rbDisable.UseVisualStyleBackColor = True
        '
        'frmUserManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(754, 527)
        Me.Controls.Add(Me.btnCancell)
        Me.Controls.Add(Me.tbControl)
        Me.Controls.Add(Me.btnCreateAccount)
        Me.Name = "frmUserManagement"
        Me.Text = "User Management"
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgRulePrivilege, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tbControl.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dgRulePrivilege As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents btnCancell As System.Windows.Forms.Button
    Friend WithEvents lvUserList As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPasword1 As UserManagementEnhancement.watermark
    Friend WithEvents txtContactnumber As UserManagementEnhancement.watermark
    Friend WithEvents txtEmailaddress As UserManagementEnhancement.watermark
    Friend WithEvents txtPassword As UserManagementEnhancement.watermark
    Friend WithEvents txtLastname As UserManagementEnhancement.watermark
    Friend WithEvents txtMiddlename As UserManagementEnhancement.watermark
    Friend WithEvents txtFirstname As UserManagementEnhancement.watermark
    Friend WithEvents txtUsername As UserManagementEnhancement.watermark
    Friend WithEvents chkShowPassword As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rbMale As System.Windows.Forms.RadioButton
    Friend WithEvents rbFemale As System.Windows.Forms.RadioButton
    Friend WithEvents txtBirthday As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCreateAccount As System.Windows.Forms.Button
    Friend WithEvents tbControl As System.Windows.Forms.TabControl
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPasswordAge As UserManagementEnhancement.watermark
    Friend WithEvents txtAddDays As UserManagementEnhancement.watermark
    Friend WithEvents CHKISEXPIRED As System.Windows.Forms.CheckBox
    Friend WithEvents ChkInactivateUser As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lvALL_USER_LIST As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtSearch As UserManagementEnhancement.watermark
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents txtFailedAttemp As UserManagementEnhancement.watermark
    Friend WithEvents btnSaveSettings As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents rbDisable As System.Windows.Forms.RadioButton
    Friend WithEvents rbEnable As System.Windows.Forms.RadioButton
    Friend WithEvents Label6 As System.Windows.Forms.Label

End Class