<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOTPManager
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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtQRURL = New System.Windows.Forms.TextBox()
        Me.txtManual = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.rbUserManagement = New System.Windows.Forms.RadioButton()
        Me.rbSettings = New System.Windows.Forms.RadioButton()
        Me.rbVoiding = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbStockout = New System.Windows.Forms.RadioButton()
        Me.rbPullout = New System.Windows.Forms.RadioButton()
        Me.rbInventory = New System.Windows.Forms.RadioButton()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtQRURL)
        Me.GroupBox3.Controls.Add(Me.txtManual)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.btnGenerate)
        Me.GroupBox3.Controls.Add(Me.txtEmail)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Location = New System.Drawing.Point(198, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(477, 167)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "One-Time Password"
        '
        'txtQRURL
        '
        Me.txtQRURL.BackColor = System.Drawing.Color.White
        Me.txtQRURL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQRURL.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtQRURL.Location = New System.Drawing.Point(98, 73)
        Me.txtQRURL.Name = "txtQRURL"
        Me.txtQRURL.ReadOnly = True
        Me.txtQRURL.Size = New System.Drawing.Size(373, 22)
        Me.txtQRURL.TabIndex = 6
        Me.txtQRURL.Text = "eskie@pgc-itdept.org"
        '
        'txtManual
        '
        Me.txtManual.BackColor = System.Drawing.Color.White
        Me.txtManual.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtManual.Location = New System.Drawing.Point(98, 48)
        Me.txtManual.Name = "txtManual"
        Me.txtManual.ReadOnly = True
        Me.txtManual.Size = New System.Drawing.Size(373, 22)
        Me.txtManual.TabIndex = 5
        Me.txtManual.Text = "eskie@pgc-itdept.org"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 78)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "URL:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Manual:"
        '
        'btnGenerate
        '
        Me.btnGenerate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerate.Location = New System.Drawing.Point(389, 111)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(82, 44)
        Me.btnGenerate.TabIndex = 2
        Me.btnGenerate.Text = "&Generate"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'txtEmail
        '
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(98, 20)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(373, 22)
        Me.txtEmail.TabIndex = 1
        Me.txtEmail.Text = "eskie@pgc-itdept.org"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Email Address"
        '
        'rbUserManagement
        '
        Me.rbUserManagement.AutoSize = True
        Me.rbUserManagement.Location = New System.Drawing.Point(6, 19)
        Me.rbUserManagement.Name = "rbUserManagement"
        Me.rbUserManagement.Size = New System.Drawing.Size(112, 17)
        Me.rbUserManagement.TabIndex = 7
        Me.rbUserManagement.TabStop = True
        Me.rbUserManagement.Text = "User Management"
        Me.rbUserManagement.UseVisualStyleBackColor = True
        '
        'rbSettings
        '
        Me.rbSettings.AutoSize = True
        Me.rbSettings.Location = New System.Drawing.Point(6, 42)
        Me.rbSettings.Name = "rbSettings"
        Me.rbSettings.Size = New System.Drawing.Size(63, 17)
        Me.rbSettings.TabIndex = 8
        Me.rbSettings.TabStop = True
        Me.rbSettings.Text = "Settigns"
        Me.rbSettings.UseVisualStyleBackColor = True
        '
        'rbVoiding
        '
        Me.rbVoiding.AutoSize = True
        Me.rbVoiding.Location = New System.Drawing.Point(6, 65)
        Me.rbVoiding.Name = "rbVoiding"
        Me.rbVoiding.Size = New System.Drawing.Size(60, 17)
        Me.rbVoiding.TabIndex = 9
        Me.rbVoiding.TabStop = True
        Me.rbVoiding.Text = "Voiding"
        Me.rbVoiding.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbInventory)
        Me.GroupBox1.Controls.Add(Me.rbPullout)
        Me.GroupBox1.Controls.Add(Me.rbStockout)
        Me.GroupBox1.Controls.Add(Me.rbUserManagement)
        Me.GroupBox1.Controls.Add(Me.rbVoiding)
        Me.GroupBox1.Controls.Add(Me.rbSettings)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(184, 167)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "OTP Module"
        '
        'rbStockout
        '
        Me.rbStockout.AutoSize = True
        Me.rbStockout.Location = New System.Drawing.Point(6, 88)
        Me.rbStockout.Name = "rbStockout"
        Me.rbStockout.Size = New System.Drawing.Size(68, 17)
        Me.rbStockout.TabIndex = 10
        Me.rbStockout.TabStop = True
        Me.rbStockout.Text = "Stockout"
        Me.rbStockout.UseVisualStyleBackColor = True
        '
        'rbPullout
        '
        Me.rbPullout.AutoSize = True
        Me.rbPullout.Location = New System.Drawing.Point(6, 111)
        Me.rbPullout.Name = "rbPullout"
        Me.rbPullout.Size = New System.Drawing.Size(57, 17)
        Me.rbPullout.TabIndex = 11
        Me.rbPullout.TabStop = True
        Me.rbPullout.Text = "Pullout"
        Me.rbPullout.UseVisualStyleBackColor = True
        '
        'rbInventory
        '
        Me.rbInventory.AutoSize = True
        Me.rbInventory.Location = New System.Drawing.Point(6, 134)
        Me.rbInventory.Name = "rbInventory"
        Me.rbInventory.Size = New System.Drawing.Size(69, 17)
        Me.rbInventory.TabIndex = 12
        Me.rbInventory.TabStop = True
        Me.rbInventory.Text = "Inventory"
        Me.rbInventory.UseVisualStyleBackColor = True
        '
        'frmOTPManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(687, 188)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Name = "frmOTPManager"
        Me.Text = "OTP Manager"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtQRURL As System.Windows.Forms.TextBox
    Friend WithEvents txtManual As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents rbUserManagement As System.Windows.Forms.RadioButton
    Friend WithEvents rbSettings As System.Windows.Forms.RadioButton
    Friend WithEvents rbVoiding As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbInventory As System.Windows.Forms.RadioButton
    Friend WithEvents rbPullout As System.Windows.Forms.RadioButton
    Friend WithEvents rbStockout As System.Windows.Forms.RadioButton
End Class
