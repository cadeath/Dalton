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
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.tbPrivileges = New System.Windows.Forms.TabControl()
        Me.tbEncoder = New System.Windows.Forms.TabPage()
        Me.CheckBox17 = New System.Windows.Forms.CheckBox()
        Me.CheckBox8 = New System.Windows.Forms.CheckBox()
        Me.CheckBox7 = New System.Windows.Forms.CheckBox()
        Me.CheckBox6 = New System.Windows.Forms.CheckBox()
        Me.CheckBox5 = New System.Windows.Forms.CheckBox()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.tbSupervisor = New System.Windows.Forms.TabPage()
        Me.CheckBox21 = New System.Windows.Forms.CheckBox()
        Me.CheckBox20 = New System.Windows.Forms.CheckBox()
        Me.CheckBox18 = New System.Windows.Forms.CheckBox()
        Me.CheckBox16 = New System.Windows.Forms.CheckBox()
        Me.CheckBox15 = New System.Windows.Forms.CheckBox()
        Me.CheckBox14 = New System.Windows.Forms.CheckBox()
        Me.CheckBox13 = New System.Windows.Forms.CheckBox()
        Me.CheckBox12 = New System.Windows.Forms.CheckBox()
        Me.CheckBox11 = New System.Windows.Forms.CheckBox()
        Me.CheckBox10 = New System.Windows.Forms.CheckBox()
        Me.CheckBox9 = New System.Windows.Forms.CheckBox()
        Me.tbManager = New System.Windows.Forms.TabPage()
        Me.CheckBox24 = New System.Windows.Forms.CheckBox()
        Me.CheckBox23 = New System.Windows.Forms.CheckBox()
        Me.CheckBox22 = New System.Windows.Forms.CheckBox()
        Me.CheckBox19 = New System.Windows.Forms.CheckBox()
        Me.CheckBox25 = New System.Windows.Forms.CheckBox()
        Me.tbSpecial = New System.Windows.Forms.TabPage()
        Me.CheckBox26 = New System.Windows.Forms.CheckBox()
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
        Me.lvUsers.Name = "lvUsers"
        Me.lvUsers.Size = New System.Drawing.Size(275, 265)
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
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(392, 11)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(233, 20)
        Me.TextBox1.TabIndex = 4
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(392, 37)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(233, 20)
        Me.TextBox2.TabIndex = 5
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(392, 63)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox3.Size = New System.Drawing.Size(178, 20)
        Me.TextBox3.TabIndex = 6
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(576, 63)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox4.Size = New System.Drawing.Size(178, 20)
        Me.TextBox4.TabIndex = 7
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(679, 258)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "&Edit"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(598, 258)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "&Add"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'tbPrivileges
        '
        Me.tbPrivileges.Controls.Add(Me.tbEncoder)
        Me.tbPrivileges.Controls.Add(Me.tbSupervisor)
        Me.tbPrivileges.Controls.Add(Me.tbManager)
        Me.tbPrivileges.Controls.Add(Me.tbSpecial)
        Me.tbPrivileges.Location = New System.Drawing.Point(296, 89)
        Me.tbPrivileges.Name = "tbPrivileges"
        Me.tbPrivileges.SelectedIndex = 0
        Me.tbPrivileges.Size = New System.Drawing.Size(458, 163)
        Me.tbPrivileges.TabIndex = 10
        '
        'tbEncoder
        '
        Me.tbEncoder.Controls.Add(Me.CheckBox17)
        Me.tbEncoder.Controls.Add(Me.CheckBox8)
        Me.tbEncoder.Controls.Add(Me.CheckBox7)
        Me.tbEncoder.Controls.Add(Me.CheckBox6)
        Me.tbEncoder.Controls.Add(Me.CheckBox5)
        Me.tbEncoder.Controls.Add(Me.CheckBox4)
        Me.tbEncoder.Controls.Add(Me.CheckBox3)
        Me.tbEncoder.Controls.Add(Me.CheckBox2)
        Me.tbEncoder.Controls.Add(Me.CheckBox1)
        Me.tbEncoder.Location = New System.Drawing.Point(4, 22)
        Me.tbEncoder.Name = "tbEncoder"
        Me.tbEncoder.Padding = New System.Windows.Forms.Padding(3)
        Me.tbEncoder.Size = New System.Drawing.Size(450, 137)
        Me.tbEncoder.TabIndex = 0
        Me.tbEncoder.Text = "Encoder"
        Me.tbEncoder.UseVisualStyleBackColor = True
        '
        'CheckBox17
        '
        Me.CheckBox17.AutoSize = True
        Me.CheckBox17.Location = New System.Drawing.Point(374, 114)
        Me.CheckBox17.Name = "CheckBox17"
        Me.CheckBox17.Size = New System.Drawing.Size(70, 17)
        Me.CheckBox17.TabIndex = 8
        Me.CheckBox17.Text = "Select All"
        Me.CheckBox17.UseVisualStyleBackColor = True
        '
        'CheckBox8
        '
        Me.CheckBox8.AutoSize = True
        Me.CheckBox8.Location = New System.Drawing.Point(187, 58)
        Me.CheckBox8.Name = "CheckBox8"
        Me.CheckBox8.Size = New System.Drawing.Size(84, 17)
        Me.CheckBox8.TabIndex = 7
        Me.CheckBox8.Text = "Cash In/Out"
        Me.CheckBox8.UseVisualStyleBackColor = True
        '
        'CheckBox7
        '
        Me.CheckBox7.AutoSize = True
        Me.CheckBox7.Location = New System.Drawing.Point(187, 35)
        Me.CheckBox7.Name = "CheckBox7"
        Me.CheckBox7.Size = New System.Drawing.Size(48, 17)
        Me.CheckBox7.TabIndex = 6
        Me.CheckBox7.Text = "POS"
        Me.CheckBox7.UseVisualStyleBackColor = True
        '
        'CheckBox6
        '
        Me.CheckBox6.AutoSize = True
        Me.CheckBox6.Location = New System.Drawing.Point(187, 12)
        Me.CheckBox6.Name = "CheckBox6"
        Me.CheckBox6.Size = New System.Drawing.Size(88, 17)
        Me.CheckBox6.TabIndex = 5
        Me.CheckBox6.Text = "Dollar Buying"
        Me.CheckBox6.UseVisualStyleBackColor = True
        '
        'CheckBox5
        '
        Me.CheckBox5.AutoSize = True
        Me.CheckBox5.Location = New System.Drawing.Point(13, 104)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(62, 17)
        Me.CheckBox5.TabIndex = 4
        Me.CheckBox5.Text = "Layway"
        Me.CheckBox5.UseVisualStyleBackColor = True
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Location = New System.Drawing.Point(13, 81)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(73, 17)
        Me.CheckBox4.TabIndex = 3
        Me.CheckBox4.Text = "Insurance"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(13, 58)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(100, 17)
        Me.CheckBox3.TabIndex = 2
        Me.CheckBox3.Text = "Money Transfer"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(13, 35)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(117, 17)
        Me.CheckBox2.TabIndex = 1
        Me.CheckBox2.Text = "Client Management"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(13, 12)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(67, 17)
        Me.CheckBox1.TabIndex = 0
        Me.CheckBox1.Text = "Pawning"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'tbSupervisor
        '
        Me.tbSupervisor.Controls.Add(Me.CheckBox25)
        Me.tbSupervisor.Controls.Add(Me.CheckBox21)
        Me.tbSupervisor.Controls.Add(Me.CheckBox20)
        Me.tbSupervisor.Controls.Add(Me.CheckBox18)
        Me.tbSupervisor.Controls.Add(Me.CheckBox16)
        Me.tbSupervisor.Controls.Add(Me.CheckBox15)
        Me.tbSupervisor.Controls.Add(Me.CheckBox14)
        Me.tbSupervisor.Controls.Add(Me.CheckBox13)
        Me.tbSupervisor.Controls.Add(Me.CheckBox12)
        Me.tbSupervisor.Controls.Add(Me.CheckBox11)
        Me.tbSupervisor.Controls.Add(Me.CheckBox10)
        Me.tbSupervisor.Controls.Add(Me.CheckBox9)
        Me.tbSupervisor.Location = New System.Drawing.Point(4, 22)
        Me.tbSupervisor.Name = "tbSupervisor"
        Me.tbSupervisor.Padding = New System.Windows.Forms.Padding(3)
        Me.tbSupervisor.Size = New System.Drawing.Size(450, 137)
        Me.tbSupervisor.TabIndex = 1
        Me.tbSupervisor.Text = "Supervisor"
        Me.tbSupervisor.UseVisualStyleBackColor = True
        '
        'CheckBox21
        '
        Me.CheckBox21.AutoSize = True
        Me.CheckBox21.Location = New System.Drawing.Point(237, 35)
        Me.CheckBox21.Name = "CheckBox21"
        Me.CheckBox21.Size = New System.Drawing.Size(80, 17)
        Me.CheckBox21.TabIndex = 11
        Me.CheckBox21.Text = "View Rates"
        Me.CheckBox21.UseVisualStyleBackColor = True
        '
        'CheckBox20
        '
        Me.CheckBox20.AutoSize = True
        Me.CheckBox20.Location = New System.Drawing.Point(237, 12)
        Me.CheckBox20.Name = "CheckBox20"
        Me.CheckBox20.Size = New System.Drawing.Size(139, 17)
        Me.CheckBox20.TabIndex = 10
        Me.CheckBox20.Text = "View User Management"
        Me.CheckBox20.UseVisualStyleBackColor = True
        '
        'CheckBox18
        '
        Me.CheckBox18.AutoSize = True
        Me.CheckBox18.Location = New System.Drawing.Point(374, 114)
        Me.CheckBox18.Name = "CheckBox18"
        Me.CheckBox18.Size = New System.Drawing.Size(70, 17)
        Me.CheckBox18.TabIndex = 9
        Me.CheckBox18.Text = "Select All"
        Me.CheckBox18.UseVisualStyleBackColor = True
        '
        'CheckBox16
        '
        Me.CheckBox16.AutoSize = True
        Me.CheckBox16.Location = New System.Drawing.Point(145, 81)
        Me.CheckBox16.Name = "CheckBox16"
        Me.CheckBox16.Size = New System.Drawing.Size(63, 17)
        Me.CheckBox16.TabIndex = 8
        Me.CheckBox16.Text = "Reports"
        Me.CheckBox16.UseVisualStyleBackColor = True
        '
        'CheckBox15
        '
        Me.CheckBox15.AutoSize = True
        Me.CheckBox15.Location = New System.Drawing.Point(145, 58)
        Me.CheckBox15.Name = "CheckBox15"
        Me.CheckBox15.Size = New System.Drawing.Size(63, 17)
        Me.CheckBox15.TabIndex = 7
        Me.CheckBox15.Text = "Reports"
        Me.CheckBox15.UseVisualStyleBackColor = True
        '
        'CheckBox14
        '
        Me.CheckBox14.AutoSize = True
        Me.CheckBox14.Location = New System.Drawing.Point(145, 35)
        Me.CheckBox14.Name = "CheckBox14"
        Me.CheckBox14.Size = New System.Drawing.Size(63, 17)
        Me.CheckBox14.TabIndex = 6
        Me.CheckBox14.Text = "Reports"
        Me.CheckBox14.UseVisualStyleBackColor = True
        '
        'CheckBox13
        '
        Me.CheckBox13.AutoSize = True
        Me.CheckBox13.Location = New System.Drawing.Point(145, 12)
        Me.CheckBox13.Name = "CheckBox13"
        Me.CheckBox13.Size = New System.Drawing.Size(63, 17)
        Me.CheckBox13.TabIndex = 5
        Me.CheckBox13.Text = "Reports"
        Me.CheckBox13.UseVisualStyleBackColor = True
        '
        'CheckBox12
        '
        Me.CheckBox12.AutoSize = True
        Me.CheckBox12.Location = New System.Drawing.Point(13, 81)
        Me.CheckBox12.Name = "CheckBox12"
        Me.CheckBox12.Size = New System.Drawing.Size(63, 17)
        Me.CheckBox12.TabIndex = 4
        Me.CheckBox12.Text = "Backup"
        Me.CheckBox12.UseVisualStyleBackColor = True
        '
        'CheckBox11
        '
        Me.CheckBox11.AutoSize = True
        Me.CheckBox11.Location = New System.Drawing.Point(13, 58)
        Me.CheckBox11.Name = "CheckBox11"
        Me.CheckBox11.Size = New System.Drawing.Size(81, 17)
        Me.CheckBox11.TabIndex = 3
        Me.CheckBox11.Text = "Cash Count"
        Me.CheckBox11.UseVisualStyleBackColor = True
        '
        'CheckBox10
        '
        Me.CheckBox10.AutoSize = True
        Me.CheckBox10.Location = New System.Drawing.Point(13, 35)
        Me.CheckBox10.Name = "CheckBox10"
        Me.CheckBox10.Size = New System.Drawing.Size(95, 17)
        Me.CheckBox10.TabIndex = 2
        Me.CheckBox10.Text = "Journal Entries"
        Me.CheckBox10.UseVisualStyleBackColor = True
        '
        'CheckBox9
        '
        Me.CheckBox9.AutoSize = True
        Me.CheckBox9.Location = New System.Drawing.Point(13, 12)
        Me.CheckBox9.Name = "CheckBox9"
        Me.CheckBox9.Size = New System.Drawing.Size(73, 17)
        Me.CheckBox9.TabIndex = 1
        Me.CheckBox9.Text = "Expiry List"
        Me.CheckBox9.UseVisualStyleBackColor = True
        '
        'tbManager
        '
        Me.tbManager.Controls.Add(Me.CheckBox24)
        Me.tbManager.Controls.Add(Me.CheckBox23)
        Me.tbManager.Controls.Add(Me.CheckBox22)
        Me.tbManager.Controls.Add(Me.CheckBox19)
        Me.tbManager.Location = New System.Drawing.Point(4, 22)
        Me.tbManager.Name = "tbManager"
        Me.tbManager.Padding = New System.Windows.Forms.Padding(3)
        Me.tbManager.Size = New System.Drawing.Size(450, 137)
        Me.tbManager.TabIndex = 2
        Me.tbManager.Text = "Manager"
        Me.tbManager.UseVisualStyleBackColor = True
        '
        'CheckBox24
        '
        Me.CheckBox24.AutoSize = True
        Me.CheckBox24.Location = New System.Drawing.Point(374, 114)
        Me.CheckBox24.Name = "CheckBox24"
        Me.CheckBox24.Size = New System.Drawing.Size(70, 17)
        Me.CheckBox24.TabIndex = 10
        Me.CheckBox24.Text = "Select All"
        Me.CheckBox24.UseVisualStyleBackColor = True
        '
        'CheckBox23
        '
        Me.CheckBox23.AutoSize = True
        Me.CheckBox23.Location = New System.Drawing.Point(13, 58)
        Me.CheckBox23.Name = "CheckBox23"
        Me.CheckBox23.Size = New System.Drawing.Size(64, 17)
        Me.CheckBox23.TabIndex = 4
        Me.CheckBox23.Text = "Settings"
        Me.CheckBox23.UseVisualStyleBackColor = True
        '
        'CheckBox22
        '
        Me.CheckBox22.AutoSize = True
        Me.CheckBox22.Location = New System.Drawing.Point(13, 35)
        Me.CheckBox22.Name = "CheckBox22"
        Me.CheckBox22.Size = New System.Drawing.Size(92, 17)
        Me.CheckBox22.TabIndex = 3
        Me.CheckBox22.Text = "Update Rates"
        Me.CheckBox22.UseVisualStyleBackColor = True
        '
        'CheckBox19
        '
        Me.CheckBox19.AutoSize = True
        Me.CheckBox19.Location = New System.Drawing.Point(13, 12)
        Me.CheckBox19.Name = "CheckBox19"
        Me.CheckBox19.Size = New System.Drawing.Size(113, 17)
        Me.CheckBox19.TabIndex = 2
        Me.CheckBox19.Text = "User Management"
        Me.CheckBox19.UseVisualStyleBackColor = True
        '
        'CheckBox25
        '
        Me.CheckBox25.AutoSize = True
        Me.CheckBox25.Location = New System.Drawing.Point(237, 58)
        Me.CheckBox25.Name = "CheckBox25"
        Me.CheckBox25.Size = New System.Drawing.Size(80, 17)
        Me.CheckBox25.TabIndex = 12
        Me.CheckBox25.Text = "Open Store"
        Me.CheckBox25.UseVisualStyleBackColor = True
        '
        'tbSpecial
        '
        Me.tbSpecial.Controls.Add(Me.CheckBox26)
        Me.tbSpecial.Location = New System.Drawing.Point(4, 22)
        Me.tbSpecial.Name = "tbSpecial"
        Me.tbSpecial.Padding = New System.Windows.Forms.Padding(3)
        Me.tbSpecial.Size = New System.Drawing.Size(450, 137)
        Me.tbSpecial.TabIndex = 3
        Me.tbSpecial.Text = "Special"
        Me.tbSpecial.UseVisualStyleBackColor = True
        '
        'CheckBox26
        '
        Me.CheckBox26.AutoSize = True
        Me.CheckBox26.Location = New System.Drawing.Point(13, 12)
        Me.CheckBox26.Name = "CheckBox26"
        Me.CheckBox26.Size = New System.Drawing.Size(96, 17)
        Me.CheckBox26.TabIndex = 3
        Me.CheckBox26.Text = "Cash In (Bank)"
        Me.CheckBox26.UseVisualStyleBackColor = True
        '
        'frmUserManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(767, 289)
        Me.Controls.Add(Me.tbPrivileges)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
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
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents tbPrivileges As System.Windows.Forms.TabControl
    Friend WithEvents tbEncoder As System.Windows.Forms.TabPage
    Friend WithEvents tbSupervisor As System.Windows.Forms.TabPage
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox5 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox7 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox6 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox8 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox9 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox10 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox12 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox11 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox16 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox15 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox14 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox13 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox17 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox18 As System.Windows.Forms.CheckBox
    Friend WithEvents tbManager As System.Windows.Forms.TabPage
    Friend WithEvents CheckBox19 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox20 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox21 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox23 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox22 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox24 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox25 As System.Windows.Forms.CheckBox
    Friend WithEvents tbSpecial As System.Windows.Forms.TabPage
    Friend WithEvents CheckBox26 As System.Windows.Forms.CheckBox
End Class
