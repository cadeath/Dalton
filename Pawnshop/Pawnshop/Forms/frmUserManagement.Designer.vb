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
        Me.lvUsers = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.txtFullname = New System.Windows.Forms.TextBox()
        Me.txtPass1 = New System.Windows.Forms.TextBox()
        Me.txtPass2 = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.tbPrivileges = New System.Windows.Forms.TabControl()
        Me.tbEncoder = New System.Windows.Forms.TabPage()
        Me.chkAppraiser = New System.Windows.Forms.CheckBox()
        Me.chkEnAll = New System.Windows.Forms.CheckBox()
        Me.chkCIO = New System.Windows.Forms.CheckBox()
        Me.chkPOS = New System.Windows.Forms.CheckBox()
        Me.chkDB = New System.Windows.Forms.CheckBox()
        Me.chkLay = New System.Windows.Forms.CheckBox()
        Me.chkIns = New System.Windows.Forms.CheckBox()
        Me.chkMT = New System.Windows.Forms.CheckBox()
        Me.chkCM = New System.Windows.Forms.CheckBox()
        Me.chkPawn = New System.Windows.Forms.CheckBox()
        Me.tbSupervisor = New System.Windows.Forms.TabPage()
        Me.chkReturn = New System.Windows.Forms.CheckBox()
        Me.chkStockOut = New System.Windows.Forms.CheckBox()
        Me.chkOS = New System.Windows.Forms.CheckBox()
        Me.chkVR = New System.Windows.Forms.CheckBox()
        Me.chkVUM = New System.Windows.Forms.CheckBox()
        Me.chkSuAll = New System.Windows.Forms.CheckBox()
        Me.chkR4 = New System.Windows.Forms.CheckBox()
        Me.chkR3 = New System.Windows.Forms.CheckBox()
        Me.chkR2 = New System.Windows.Forms.CheckBox()
        Me.chkR1 = New System.Windows.Forms.CheckBox()
        Me.chkBU = New System.Windows.Forms.CheckBox()
        Me.chkCC = New System.Windows.Forms.CheckBox()
        Me.chkJE = New System.Windows.Forms.CheckBox()
        Me.chkEL = New System.Windows.Forms.CheckBox()
        Me.tbManager = New System.Windows.Forms.TabPage()
        Me.chkResetPassword = New System.Windows.Forms.CheckBox()
        Me.chkBorrowings = New System.Windows.Forms.CheckBox()
        Me.chkMaAll = New System.Windows.Forms.CheckBox()
        Me.chkUS = New System.Windows.Forms.CheckBox()
        Me.chkUR = New System.Windows.Forms.CheckBox()
        Me.chkUM = New System.Windows.Forms.CheckBox()
        Me.tbSpecial = New System.Windows.Forms.TabPage()
        Me.chkEnableDisable = New System.Windows.Forms.CheckBox()
        Me.chkPrivilege = New System.Windows.Forms.CheckBox()
        Me.chkMigrate = New System.Windows.Forms.CheckBox()
        Me.chkPullOut = New System.Windows.Forms.CheckBox()
        Me.chkVoid = New System.Windows.Forms.CheckBox()
        Me.chkSpAll = New System.Windows.Forms.CheckBox()
        Me.chkCashOutBank = New System.Windows.Forms.CheckBox()
        Me.chkCashInBank = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbPrivileges.SuspendLayout()
        Me.tbEncoder.SuspendLayout()
        Me.tbSupervisor.SuspendLayout()
        Me.tbManager.SuspendLayout()
        Me.tbSpecial.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvUsers
        '
        Me.lvUsers.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.lvUsers.FullRowSelect = True
        Me.lvUsers.GridLines = True
        Me.lvUsers.Location = New System.Drawing.Point(12, 12)
        Me.lvUsers.MultiSelect = False
        Me.lvUsers.Name = "lvUsers"
        Me.lvUsers.Size = New System.Drawing.Size(275, 337)
        Me.lvUsers.TabIndex = 0
        Me.lvUsers.UseCompatibleStateImageBehavior = False
        Me.lvUsers.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Username"
        Me.ColumnHeader1.Width = 81
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Name"
        Me.ColumnHeader2.Width = 115
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Level"
        Me.ColumnHeader3.Width = 74
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(293, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Username"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(293, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Fullname"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(293, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Password"
        '
        'txtUser
        '
        Me.txtUser.Location = New System.Drawing.Point(392, 11)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(205, 20)
        Me.txtUser.TabIndex = 4
        '
        'txtFullname
        '
        Me.txtFullname.Location = New System.Drawing.Point(392, 37)
        Me.txtFullname.Name = "txtFullname"
        Me.txtFullname.Size = New System.Drawing.Size(205, 20)
        Me.txtFullname.TabIndex = 5
        '
        'txtPass1
        '
        Me.txtPass1.Location = New System.Drawing.Point(392, 63)
        Me.txtPass1.Name = "txtPass1"
        Me.txtPass1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPass1.Size = New System.Drawing.Size(205, 20)
        Me.txtPass1.TabIndex = 6
        '
        'txtPass2
        '
        Me.txtPass2.Location = New System.Drawing.Point(392, 89)
        Me.txtPass2.Name = "txtPass2"
        Me.txtPass2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPass2.Size = New System.Drawing.Size(205, 20)
        Me.txtPass2.TabIndex = 7
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(526, 326)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 8
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(445, 326)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 9
        Me.btnAdd.Text = "&Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'tbPrivileges
        '
        Me.tbPrivileges.Controls.Add(Me.tbEncoder)
        Me.tbPrivileges.Controls.Add(Me.tbSupervisor)
        Me.tbPrivileges.Controls.Add(Me.tbManager)
        Me.tbPrivileges.Controls.Add(Me.tbSpecial)
        Me.tbPrivileges.Location = New System.Drawing.Point(293, 115)
        Me.tbPrivileges.Name = "tbPrivileges"
        Me.tbPrivileges.SelectedIndex = 0
        Me.tbPrivileges.Size = New System.Drawing.Size(304, 205)
        Me.tbPrivileges.TabIndex = 10
        '
        'tbEncoder
        '
        Me.tbEncoder.Controls.Add(Me.chkAppraiser)
        Me.tbEncoder.Controls.Add(Me.chkEnAll)
        Me.tbEncoder.Controls.Add(Me.chkCIO)
        Me.tbEncoder.Controls.Add(Me.chkPOS)
        Me.tbEncoder.Controls.Add(Me.chkDB)
        Me.tbEncoder.Controls.Add(Me.chkLay)
        Me.tbEncoder.Controls.Add(Me.chkIns)
        Me.tbEncoder.Controls.Add(Me.chkMT)
        Me.tbEncoder.Controls.Add(Me.chkCM)
        Me.tbEncoder.Controls.Add(Me.chkPawn)
        Me.tbEncoder.Location = New System.Drawing.Point(4, 22)
        Me.tbEncoder.Name = "tbEncoder"
        Me.tbEncoder.Padding = New System.Windows.Forms.Padding(3)
        Me.tbEncoder.Size = New System.Drawing.Size(296, 179)
        Me.tbEncoder.TabIndex = 0
        Me.tbEncoder.Text = "Encoder"
        Me.tbEncoder.UseVisualStyleBackColor = True
        '
        'chkAppraiser
        '
        Me.chkAppraiser.AutoSize = True
        Me.chkAppraiser.Location = New System.Drawing.Point(153, 35)
        Me.chkAppraiser.Name = "chkAppraiser"
        Me.chkAppraiser.Size = New System.Drawing.Size(70, 17)
        Me.chkAppraiser.TabIndex = 9
        Me.chkAppraiser.Text = "Appraiser"
        Me.chkAppraiser.UseVisualStyleBackColor = True
        '
        'chkEnAll
        '
        Me.chkEnAll.AutoSize = True
        Me.chkEnAll.Location = New System.Drawing.Point(211, 150)
        Me.chkEnAll.Name = "chkEnAll"
        Me.chkEnAll.Size = New System.Drawing.Size(70, 17)
        Me.chkEnAll.TabIndex = 8
        Me.chkEnAll.Text = "Select All"
        Me.chkEnAll.UseVisualStyleBackColor = True
        '
        'chkCIO
        '
        Me.chkCIO.AutoSize = True
        Me.chkCIO.Location = New System.Drawing.Point(153, 12)
        Me.chkCIO.Name = "chkCIO"
        Me.chkCIO.Size = New System.Drawing.Size(84, 17)
        Me.chkCIO.TabIndex = 7
        Me.chkCIO.Text = "Cash In/Out"
        Me.chkCIO.UseVisualStyleBackColor = True
        '
        'chkPOS
        '
        Me.chkPOS.AutoSize = True
        Me.chkPOS.Location = New System.Drawing.Point(13, 150)
        Me.chkPOS.Name = "chkPOS"
        Me.chkPOS.Size = New System.Drawing.Size(48, 17)
        Me.chkPOS.TabIndex = 6
        Me.chkPOS.Text = "POS"
        Me.chkPOS.UseVisualStyleBackColor = True
        '
        'chkDB
        '
        Me.chkDB.AutoSize = True
        Me.chkDB.Location = New System.Drawing.Point(13, 127)
        Me.chkDB.Name = "chkDB"
        Me.chkDB.Size = New System.Drawing.Size(88, 17)
        Me.chkDB.TabIndex = 5
        Me.chkDB.Text = "Dollar Buying"
        Me.chkDB.UseVisualStyleBackColor = True
        '
        'chkLay
        '
        Me.chkLay.AutoSize = True
        Me.chkLay.Location = New System.Drawing.Point(13, 104)
        Me.chkLay.Name = "chkLay"
        Me.chkLay.Size = New System.Drawing.Size(62, 17)
        Me.chkLay.TabIndex = 4
        Me.chkLay.Text = "Layway"
        Me.chkLay.UseVisualStyleBackColor = True
        '
        'chkIns
        '
        Me.chkIns.AutoSize = True
        Me.chkIns.Location = New System.Drawing.Point(13, 81)
        Me.chkIns.Name = "chkIns"
        Me.chkIns.Size = New System.Drawing.Size(73, 17)
        Me.chkIns.TabIndex = 3
        Me.chkIns.Text = "Insurance"
        Me.chkIns.UseVisualStyleBackColor = True
        '
        'chkMT
        '
        Me.chkMT.AutoSize = True
        Me.chkMT.Location = New System.Drawing.Point(13, 58)
        Me.chkMT.Name = "chkMT"
        Me.chkMT.Size = New System.Drawing.Size(100, 17)
        Me.chkMT.TabIndex = 2
        Me.chkMT.Text = "Money Transfer"
        Me.chkMT.UseVisualStyleBackColor = True
        '
        'chkCM
        '
        Me.chkCM.AutoSize = True
        Me.chkCM.Location = New System.Drawing.Point(13, 35)
        Me.chkCM.Name = "chkCM"
        Me.chkCM.Size = New System.Drawing.Size(117, 17)
        Me.chkCM.TabIndex = 1
        Me.chkCM.Text = "Client Management"
        Me.chkCM.UseVisualStyleBackColor = True
        '
        'chkPawn
        '
        Me.chkPawn.AutoSize = True
        Me.chkPawn.Location = New System.Drawing.Point(13, 12)
        Me.chkPawn.Name = "chkPawn"
        Me.chkPawn.Size = New System.Drawing.Size(67, 17)
        Me.chkPawn.TabIndex = 0
        Me.chkPawn.Text = "Pawning"
        Me.chkPawn.UseVisualStyleBackColor = True
        '
        'tbSupervisor
        '
        Me.tbSupervisor.Controls.Add(Me.chkReturn)
        Me.tbSupervisor.Controls.Add(Me.chkStockOut)
        Me.tbSupervisor.Controls.Add(Me.chkOS)
        Me.tbSupervisor.Controls.Add(Me.chkVR)
        Me.tbSupervisor.Controls.Add(Me.chkVUM)
        Me.tbSupervisor.Controls.Add(Me.chkSuAll)
        Me.tbSupervisor.Controls.Add(Me.chkR4)
        Me.tbSupervisor.Controls.Add(Me.chkR3)
        Me.tbSupervisor.Controls.Add(Me.chkR2)
        Me.tbSupervisor.Controls.Add(Me.chkR1)
        Me.tbSupervisor.Controls.Add(Me.chkBU)
        Me.tbSupervisor.Controls.Add(Me.chkCC)
        Me.tbSupervisor.Controls.Add(Me.chkJE)
        Me.tbSupervisor.Controls.Add(Me.chkEL)
        Me.tbSupervisor.Location = New System.Drawing.Point(4, 22)
        Me.tbSupervisor.Name = "tbSupervisor"
        Me.tbSupervisor.Padding = New System.Windows.Forms.Padding(3)
        Me.tbSupervisor.Size = New System.Drawing.Size(296, 179)
        Me.tbSupervisor.TabIndex = 1
        Me.tbSupervisor.Text = "Supervisor"
        Me.tbSupervisor.UseVisualStyleBackColor = True
        '
        'chkReturn
        '
        Me.chkReturn.AutoSize = True
        Me.chkReturn.Location = New System.Drawing.Point(13, 127)
        Me.chkReturn.Name = "chkReturn"
        Me.chkReturn.Size = New System.Drawing.Size(58, 17)
        Me.chkReturn.TabIndex = 14
        Me.chkReturn.Text = "Return"
        Me.chkReturn.UseVisualStyleBackColor = True
        '
        'chkStockOut
        '
        Me.chkStockOut.AutoSize = True
        Me.chkStockOut.Location = New System.Drawing.Point(13, 104)
        Me.chkStockOut.Name = "chkStockOut"
        Me.chkStockOut.Size = New System.Drawing.Size(71, 17)
        Me.chkStockOut.TabIndex = 13
        Me.chkStockOut.Text = "StockOut"
        Me.chkStockOut.UseVisualStyleBackColor = True
        '
        'chkOS
        '
        Me.chkOS.AutoSize = True
        Me.chkOS.Location = New System.Drawing.Point(108, 127)
        Me.chkOS.Name = "chkOS"
        Me.chkOS.Size = New System.Drawing.Size(80, 17)
        Me.chkOS.TabIndex = 12
        Me.chkOS.Text = "Open Store"
        Me.chkOS.UseVisualStyleBackColor = True
        '
        'chkVR
        '
        Me.chkVR.AutoSize = True
        Me.chkVR.Location = New System.Drawing.Point(108, 104)
        Me.chkVR.Name = "chkVR"
        Me.chkVR.Size = New System.Drawing.Size(80, 17)
        Me.chkVR.TabIndex = 11
        Me.chkVR.Text = "View Rates"
        Me.chkVR.UseVisualStyleBackColor = True
        '
        'chkVUM
        '
        Me.chkVUM.AutoSize = True
        Me.chkVUM.Location = New System.Drawing.Point(108, 81)
        Me.chkVUM.Name = "chkVUM"
        Me.chkVUM.Size = New System.Drawing.Size(139, 17)
        Me.chkVUM.TabIndex = 10
        Me.chkVUM.Text = "View User Management"
        Me.chkVUM.UseVisualStyleBackColor = True
        '
        'chkSuAll
        '
        Me.chkSuAll.AutoSize = True
        Me.chkSuAll.Location = New System.Drawing.Point(211, 150)
        Me.chkSuAll.Name = "chkSuAll"
        Me.chkSuAll.Size = New System.Drawing.Size(70, 17)
        Me.chkSuAll.TabIndex = 9
        Me.chkSuAll.Text = "Select All"
        Me.chkSuAll.UseVisualStyleBackColor = True
        '
        'chkR4
        '
        Me.chkR4.AutoSize = True
        Me.chkR4.Location = New System.Drawing.Point(13, 150)
        Me.chkR4.Name = "chkR4"
        Me.chkR4.Size = New System.Drawing.Size(63, 17)
        Me.chkR4.TabIndex = 8
        Me.chkR4.Text = "Reports"
        Me.chkR4.UseVisualStyleBackColor = True
        '
        'chkR3
        '
        Me.chkR3.AutoSize = True
        Me.chkR3.Location = New System.Drawing.Point(108, 58)
        Me.chkR3.Name = "chkR3"
        Me.chkR3.Size = New System.Drawing.Size(181, 17)
        Me.chkR3.TabIndex = 7
        Me.chkR3.Text = "Outstanding Reports (Advanced)"
        Me.chkR3.UseVisualStyleBackColor = True
        '
        'chkR2
        '
        Me.chkR2.AutoSize = True
        Me.chkR2.Location = New System.Drawing.Point(108, 35)
        Me.chkR2.Name = "chkR2"
        Me.chkR2.Size = New System.Drawing.Size(179, 17)
        Me.chkR2.TabIndex = 6
        Me.chkR2.Text = "Segregated Reports (Advanced)"
        Me.chkR2.UseVisualStyleBackColor = True
        '
        'chkR1
        '
        Me.chkR1.AutoSize = True
        Me.chkR1.Location = New System.Drawing.Point(108, 12)
        Me.chkR1.Name = "chkR1"
        Me.chkR1.Size = New System.Drawing.Size(179, 17)
        Me.chkR1.TabIndex = 5
        Me.chkR1.Text = "Item Pullout Reports (Advanced)"
        Me.chkR1.UseVisualStyleBackColor = True
        '
        'chkBU
        '
        Me.chkBU.AutoSize = True
        Me.chkBU.Location = New System.Drawing.Point(13, 81)
        Me.chkBU.Name = "chkBU"
        Me.chkBU.Size = New System.Drawing.Size(63, 17)
        Me.chkBU.TabIndex = 4
        Me.chkBU.Text = "Backup"
        Me.chkBU.UseVisualStyleBackColor = True
        '
        'chkCC
        '
        Me.chkCC.AutoSize = True
        Me.chkCC.Location = New System.Drawing.Point(13, 58)
        Me.chkCC.Name = "chkCC"
        Me.chkCC.Size = New System.Drawing.Size(81, 17)
        Me.chkCC.TabIndex = 3
        Me.chkCC.Text = "Cash Count"
        Me.chkCC.UseVisualStyleBackColor = True
        '
        'chkJE
        '
        Me.chkJE.AutoSize = True
        Me.chkJE.Location = New System.Drawing.Point(13, 35)
        Me.chkJE.Name = "chkJE"
        Me.chkJE.Size = New System.Drawing.Size(95, 17)
        Me.chkJE.TabIndex = 2
        Me.chkJE.Text = "Journal Entries"
        Me.chkJE.UseVisualStyleBackColor = True
        '
        'chkEL
        '
        Me.chkEL.AutoSize = True
        Me.chkEL.Location = New System.Drawing.Point(13, 12)
        Me.chkEL.Name = "chkEL"
        Me.chkEL.Size = New System.Drawing.Size(73, 17)
        Me.chkEL.TabIndex = 1
        Me.chkEL.Text = "Expiry List"
        Me.chkEL.UseVisualStyleBackColor = True
        '
        'tbManager
        '
        Me.tbManager.Controls.Add(Me.chkResetPassword)
        Me.tbManager.Controls.Add(Me.chkBorrowings)
        Me.tbManager.Controls.Add(Me.chkMaAll)
        Me.tbManager.Controls.Add(Me.chkUS)
        Me.tbManager.Controls.Add(Me.chkUR)
        Me.tbManager.Controls.Add(Me.chkUM)
        Me.tbManager.Location = New System.Drawing.Point(4, 22)
        Me.tbManager.Name = "tbManager"
        Me.tbManager.Padding = New System.Windows.Forms.Padding(3)
        Me.tbManager.Size = New System.Drawing.Size(296, 179)
        Me.tbManager.TabIndex = 2
        Me.tbManager.Text = "Manager"
        Me.tbManager.UseVisualStyleBackColor = True
        '
        'chkResetPassword
        '
        Me.chkResetPassword.AutoSize = True
        Me.chkResetPassword.Location = New System.Drawing.Point(13, 104)
        Me.chkResetPassword.Name = "chkResetPassword"
        Me.chkResetPassword.Size = New System.Drawing.Size(103, 17)
        Me.chkResetPassword.TabIndex = 12
        Me.chkResetPassword.Text = "Reset Password"
        Me.chkResetPassword.UseVisualStyleBackColor = True
        '
        'chkBorrowings
        '
        Me.chkBorrowings.AutoSize = True
        Me.chkBorrowings.Location = New System.Drawing.Point(13, 81)
        Me.chkBorrowings.Name = "chkBorrowings"
        Me.chkBorrowings.Size = New System.Drawing.Size(78, 17)
        Me.chkBorrowings.TabIndex = 11
        Me.chkBorrowings.Text = "Borrowings"
        Me.chkBorrowings.UseVisualStyleBackColor = True
        '
        'chkMaAll
        '
        Me.chkMaAll.AutoSize = True
        Me.chkMaAll.Location = New System.Drawing.Point(211, 150)
        Me.chkMaAll.Name = "chkMaAll"
        Me.chkMaAll.Size = New System.Drawing.Size(70, 17)
        Me.chkMaAll.TabIndex = 10
        Me.chkMaAll.Text = "Select All"
        Me.chkMaAll.UseVisualStyleBackColor = True
        '
        'chkUS
        '
        Me.chkUS.AutoSize = True
        Me.chkUS.Location = New System.Drawing.Point(13, 58)
        Me.chkUS.Name = "chkUS"
        Me.chkUS.Size = New System.Drawing.Size(64, 17)
        Me.chkUS.TabIndex = 4
        Me.chkUS.Text = "Settings"
        Me.chkUS.UseVisualStyleBackColor = True
        '
        'chkUR
        '
        Me.chkUR.AutoSize = True
        Me.chkUR.Location = New System.Drawing.Point(13, 35)
        Me.chkUR.Name = "chkUR"
        Me.chkUR.Size = New System.Drawing.Size(92, 17)
        Me.chkUR.TabIndex = 3
        Me.chkUR.Text = "Update Rates"
        Me.chkUR.UseVisualStyleBackColor = True
        '
        'chkUM
        '
        Me.chkUM.AutoSize = True
        Me.chkUM.Location = New System.Drawing.Point(13, 12)
        Me.chkUM.Name = "chkUM"
        Me.chkUM.Size = New System.Drawing.Size(113, 17)
        Me.chkUM.TabIndex = 2
        Me.chkUM.Text = "User Management"
        Me.chkUM.UseVisualStyleBackColor = True
        '
        'tbSpecial
        '
        Me.tbSpecial.Controls.Add(Me.chkEnableDisable)
        Me.tbSpecial.Controls.Add(Me.chkPrivilege)
        Me.tbSpecial.Controls.Add(Me.chkMigrate)
        Me.tbSpecial.Controls.Add(Me.chkPullOut)
        Me.tbSpecial.Controls.Add(Me.chkVoid)
        Me.tbSpecial.Controls.Add(Me.chkSpAll)
        Me.tbSpecial.Controls.Add(Me.chkCashOutBank)
        Me.tbSpecial.Controls.Add(Me.chkCashInBank)
        Me.tbSpecial.Location = New System.Drawing.Point(4, 22)
        Me.tbSpecial.Name = "tbSpecial"
        Me.tbSpecial.Padding = New System.Windows.Forms.Padding(3)
        Me.tbSpecial.Size = New System.Drawing.Size(296, 179)
        Me.tbSpecial.TabIndex = 3
        Me.tbSpecial.Text = "Special"
        Me.tbSpecial.UseVisualStyleBackColor = True
        '
        'chkEnableDisable
        '
        Me.chkEnableDisable.AutoSize = True
        Me.chkEnableDisable.Enabled = False
        Me.chkEnableDisable.Location = New System.Drawing.Point(160, 35)
        Me.chkEnableDisable.Name = "chkEnableDisable"
        Me.chkEnableDisable.Size = New System.Drawing.Size(130, 17)
        Me.chkEnableDisable.TabIndex = 16
        Me.chkEnableDisable.Text = "Enable / Disable User"
        Me.chkEnableDisable.UseVisualStyleBackColor = True
        '
        'chkPrivilege
        '
        Me.chkPrivilege.AutoSize = True
        Me.chkPrivilege.Location = New System.Drawing.Point(160, 12)
        Me.chkPrivilege.Name = "chkPrivilege"
        Me.chkPrivilege.Size = New System.Drawing.Size(66, 17)
        Me.chkPrivilege.TabIndex = 15
        Me.chkPrivilege.Text = "Privilege"
        Me.chkPrivilege.UseVisualStyleBackColor = True
        '
        'chkMigrate
        '
        Me.chkMigrate.AutoSize = True
        Me.chkMigrate.Location = New System.Drawing.Point(13, 104)
        Me.chkMigrate.Name = "chkMigrate"
        Me.chkMigrate.Size = New System.Drawing.Size(61, 17)
        Me.chkMigrate.TabIndex = 14
        Me.chkMigrate.Text = "Migrate"
        Me.chkMigrate.UseVisualStyleBackColor = True
        '
        'chkPullOut
        '
        Me.chkPullOut.AutoSize = True
        Me.chkPullOut.Location = New System.Drawing.Point(13, 81)
        Me.chkPullOut.Name = "chkPullOut"
        Me.chkPullOut.Size = New System.Drawing.Size(63, 17)
        Me.chkPullOut.TabIndex = 13
        Me.chkPullOut.Text = "Pull Out"
        Me.chkPullOut.UseVisualStyleBackColor = True
        '
        'chkVoid
        '
        Me.chkVoid.AutoSize = True
        Me.chkVoid.Location = New System.Drawing.Point(13, 58)
        Me.chkVoid.Name = "chkVoid"
        Me.chkVoid.Size = New System.Drawing.Size(111, 17)
        Me.chkVoid.TabIndex = 12
        Me.chkVoid.Text = "Void Transactions"
        Me.chkVoid.UseVisualStyleBackColor = True
        '
        'chkSpAll
        '
        Me.chkSpAll.AutoSize = True
        Me.chkSpAll.Location = New System.Drawing.Point(211, 150)
        Me.chkSpAll.Name = "chkSpAll"
        Me.chkSpAll.Size = New System.Drawing.Size(70, 17)
        Me.chkSpAll.TabIndex = 11
        Me.chkSpAll.Text = "Select All"
        Me.chkSpAll.UseVisualStyleBackColor = True
        '
        'chkCashOutBank
        '
        Me.chkCashOutBank.AutoSize = True
        Me.chkCashOutBank.Location = New System.Drawing.Point(13, 35)
        Me.chkCashOutBank.Name = "chkCashOutBank"
        Me.chkCashOutBank.Size = New System.Drawing.Size(104, 17)
        Me.chkCashOutBank.TabIndex = 4
        Me.chkCashOutBank.Text = "Cash Out (Bank)"
        Me.chkCashOutBank.UseVisualStyleBackColor = True
        '
        'chkCashInBank
        '
        Me.chkCashInBank.AutoSize = True
        Me.chkCashInBank.Location = New System.Drawing.Point(13, 12)
        Me.chkCashInBank.Name = "chkCashInBank"
        Me.chkCashInBank.Size = New System.Drawing.Size(96, 17)
        Me.chkCashInBank.TabIndex = 3
        Me.chkCashInBank.Text = "Cash In (Bank)"
        Me.chkCashInBank.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(293, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 16)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Re-Type"
        '
        'frmUserManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(605, 357)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tbPrivileges)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.txtPass2)
        Me.Controls.Add(Me.txtPass1)
        Me.Controls.Add(Me.txtFullname)
        Me.Controls.Add(Me.txtUser)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lvUsers)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmUserManagement"
        Me.Text = "User Management"
        Me.tbPrivileges.ResumeLayout(False)
        Me.tbEncoder.ResumeLayout(False)
        Me.tbEncoder.PerformLayout()
        Me.tbSupervisor.ResumeLayout(False)
        Me.tbSupervisor.PerformLayout()
        Me.tbManager.ResumeLayout(False)
        Me.tbManager.PerformLayout()
        Me.tbSpecial.ResumeLayout(False)
        Me.tbSpecial.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvUsers As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtUser As System.Windows.Forms.TextBox
    Friend WithEvents txtFullname As System.Windows.Forms.TextBox
    Friend WithEvents txtPass1 As System.Windows.Forms.TextBox
    Friend WithEvents txtPass2 As System.Windows.Forms.TextBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents tbPrivileges As System.Windows.Forms.TabControl
    Friend WithEvents tbEncoder As System.Windows.Forms.TabPage
    Friend WithEvents tbSupervisor As System.Windows.Forms.TabPage
    Friend WithEvents chkPawn As System.Windows.Forms.CheckBox
    Friend WithEvents chkLay As System.Windows.Forms.CheckBox
    Friend WithEvents chkIns As System.Windows.Forms.CheckBox
    Friend WithEvents chkMT As System.Windows.Forms.CheckBox
    Friend WithEvents chkCM As System.Windows.Forms.CheckBox
    Friend WithEvents chkPOS As System.Windows.Forms.CheckBox
    Friend WithEvents chkDB As System.Windows.Forms.CheckBox
    Friend WithEvents chkCIO As System.Windows.Forms.CheckBox
    Friend WithEvents chkEL As System.Windows.Forms.CheckBox
    Friend WithEvents chkJE As System.Windows.Forms.CheckBox
    Friend WithEvents chkBU As System.Windows.Forms.CheckBox
    Friend WithEvents chkCC As System.Windows.Forms.CheckBox
    Friend WithEvents chkR4 As System.Windows.Forms.CheckBox
    Friend WithEvents chkR3 As System.Windows.Forms.CheckBox
    Friend WithEvents chkR2 As System.Windows.Forms.CheckBox
    Friend WithEvents chkR1 As System.Windows.Forms.CheckBox
    Friend WithEvents chkEnAll As System.Windows.Forms.CheckBox
    Friend WithEvents chkSuAll As System.Windows.Forms.CheckBox
    Friend WithEvents tbManager As System.Windows.Forms.TabPage
    Friend WithEvents chkUM As System.Windows.Forms.CheckBox
    Friend WithEvents chkVUM As System.Windows.Forms.CheckBox
    Friend WithEvents chkVR As System.Windows.Forms.CheckBox
    Friend WithEvents chkUS As System.Windows.Forms.CheckBox
    Friend WithEvents chkUR As System.Windows.Forms.CheckBox
    Friend WithEvents chkMaAll As System.Windows.Forms.CheckBox
    Friend WithEvents chkOS As System.Windows.Forms.CheckBox
    Friend WithEvents tbSpecial As System.Windows.Forms.TabPage
    Friend WithEvents chkCashInBank As System.Windows.Forms.CheckBox
    Friend WithEvents chkCashOutBank As System.Windows.Forms.CheckBox
    Friend WithEvents chkSpAll As System.Windows.Forms.CheckBox
    Friend WithEvents chkVoid As System.Windows.Forms.CheckBox
    Friend WithEvents chkBorrowings As System.Windows.Forms.CheckBox
    Friend WithEvents chkPullOut As System.Windows.Forms.CheckBox
    Friend WithEvents chkMigrate As System.Windows.Forms.CheckBox
    Friend WithEvents chkAppraiser As System.Windows.Forms.CheckBox
    Friend WithEvents chkResetPassword As System.Windows.Forms.CheckBox
    Friend WithEvents chkPrivilege As System.Windows.Forms.CheckBox
    Friend WithEvents chkEnableDisable As System.Windows.Forms.CheckBox
    Friend WithEvents chkReturn As System.Windows.Forms.CheckBox
    Friend WithEvents chkStockOut As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
