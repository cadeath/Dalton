<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUserInfor
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbFemale = New System.Windows.Forms.RadioButton()
        Me.rbMale = New System.Windows.Forms.RadioButton()
        Me.txtBirthday = New System.Windows.Forms.DateTimePicker()
        Me.txtContactnumber = New Pawnshop.watermark()
        Me.txtEmailaddress = New Pawnshop.watermark()
        Me.txtLastname = New Pawnshop.watermark()
        Me.txtMiddlename = New Pawnshop.watermark()
        Me.txtFirstname = New Pawnshop.watermark()
        Me.btnCreateAccount = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.rbFemale)
        Me.GroupBox1.Controls.Add(Me.rbMale)
        Me.GroupBox1.Controls.Add(Me.txtBirthday)
        Me.GroupBox1.Controls.Add(Me.txtContactnumber)
        Me.GroupBox1.Controls.Add(Me.txtEmailaddress)
        Me.GroupBox1.Controls.Add(Me.txtLastname)
        Me.GroupBox1.Controls.Add(Me.txtMiddlename)
        Me.GroupBox1.Controls.Add(Me.txtFirstname)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(436, 263)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Fill up "
        '
        'rbFemale
        '
        Me.rbFemale.AutoSize = True
        Me.rbFemale.Location = New System.Drawing.Point(116, 212)
        Me.rbFemale.Name = "rbFemale"
        Me.rbFemale.Size = New System.Drawing.Size(92, 26)
        Me.rbFemale.TabIndex = 9
        Me.rbFemale.TabStop = True
        Me.rbFemale.Text = "Female"
        Me.rbFemale.UseVisualStyleBackColor = True
        '
        'rbMale
        '
        Me.rbMale.AutoSize = True
        Me.rbMale.Location = New System.Drawing.Point(257, 214)
        Me.rbMale.Name = "rbMale"
        Me.rbMale.Size = New System.Drawing.Size(68, 26)
        Me.rbMale.TabIndex = 10
        Me.rbMale.TabStop = True
        Me.rbMale.Text = "Male"
        Me.rbMale.UseVisualStyleBackColor = True
        '
        'txtBirthday
        '
        Me.txtBirthday.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtBirthday.Location = New System.Drawing.Point(8, 171)
        Me.txtBirthday.Name = "txtBirthday"
        Me.txtBirthday.Size = New System.Drawing.Size(422, 29)
        Me.txtBirthday.TabIndex = 8
        '
        'txtContactnumber
        '
        Me.txtContactnumber.Location = New System.Drawing.Point(8, 136)
        Me.txtContactnumber.MaxLength = 13
        Me.txtContactnumber.Name = "txtContactnumber"
        Me.txtContactnumber.Size = New System.Drawing.Size(422, 29)
        Me.txtContactnumber.TabIndex = 7
        Me.txtContactnumber.WatermarkColor = System.Drawing.Color.Gray
        Me.txtContactnumber.WatermarkText = "Contact number"
        '
        'txtEmailaddress
        '
        Me.txtEmailaddress.Location = New System.Drawing.Point(8, 101)
        Me.txtEmailaddress.Name = "txtEmailaddress"
        Me.txtEmailaddress.Size = New System.Drawing.Size(422, 29)
        Me.txtEmailaddress.TabIndex = 6
        Me.txtEmailaddress.WatermarkColor = System.Drawing.Color.Gray
        Me.txtEmailaddress.WatermarkText = "Email Address : Ex. yourname@gmail.com"
        '
        'txtLastname
        '
        Me.txtLastname.Location = New System.Drawing.Point(6, 63)
        Me.txtLastname.Name = "txtLastname"
        Me.txtLastname.Size = New System.Drawing.Size(422, 29)
        Me.txtLastname.TabIndex = 3
        Me.txtLastname.WatermarkColor = System.Drawing.Color.Gray
        Me.txtLastname.WatermarkText = "Lastname"
        '
        'txtMiddlename
        '
        Me.txtMiddlename.Location = New System.Drawing.Point(224, 28)
        Me.txtMiddlename.Name = "txtMiddlename"
        Me.txtMiddlename.Size = New System.Drawing.Size(204, 29)
        Me.txtMiddlename.TabIndex = 2
        Me.txtMiddlename.WatermarkColor = System.Drawing.Color.Gray
        Me.txtMiddlename.WatermarkText = "Middlename"
        '
        'txtFirstname
        '
        Me.txtFirstname.Location = New System.Drawing.Point(6, 28)
        Me.txtFirstname.Name = "txtFirstname"
        Me.txtFirstname.Size = New System.Drawing.Size(212, 29)
        Me.txtFirstname.TabIndex = 1
        Me.txtFirstname.WatermarkColor = System.Drawing.Color.Gray
        Me.txtFirstname.WatermarkText = "Firstname"
        '
        'btnCreateAccount
        '
        Me.btnCreateAccount.BackColor = System.Drawing.Color.White
        Me.btnCreateAccount.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreateAccount.Location = New System.Drawing.Point(463, 75)
        Me.btnCreateAccount.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnCreateAccount.Name = "btnCreateAccount"
        Me.btnCreateAccount.Size = New System.Drawing.Size(156, 71)
        Me.btnCreateAccount.TabIndex = 10
        Me.btnCreateAccount.Text = "&Update Account"
        Me.btnCreateAccount.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 214)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 22)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Gender"
        '
        'frmUserInfor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.ClientSize = New System.Drawing.Size(642, 282)
        Me.Controls.Add(Me.btnCreateAccount)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmUserInfor"
        Me.Text = "Profile"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbFemale As System.Windows.Forms.RadioButton
    Friend WithEvents rbMale As System.Windows.Forms.RadioButton
    Friend WithEvents txtBirthday As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtContactnumber As Pawnshop.watermark
    Friend WithEvents txtEmailaddress As Pawnshop.watermark
    Friend WithEvents txtLastname As Pawnshop.watermark
    Friend WithEvents txtMiddlename As Pawnshop.watermark
    Friend WithEvents txtFirstname As Pawnshop.watermark
    Friend WithEvents btnCreateAccount As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
