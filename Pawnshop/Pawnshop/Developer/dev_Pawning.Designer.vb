<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dev_Pawning
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
        Me.rbDPJ = New System.Windows.Forms.RadioButton()
        Me.rbRemantic = New System.Windows.Forms.RadioButton()
        Me.loanDate = New System.Windows.Forms.MonthCalendar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMatu = New System.Windows.Forms.TextBox()
        Me.txtExpiry = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtAuction = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboType = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPrincipal = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDaysOver = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtInt = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtSC = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtPenalty = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtRedeemDue = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtRenewDue = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtNetAmount = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnCompute = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.current = New System.Windows.Forms.MonthCalendar()
        Me.txtAdvInt = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbDPJ)
        Me.GroupBox1.Controls.Add(Me.rbRemantic)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(210, 53)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "New Item"
        '
        'rbDPJ
        '
        Me.rbDPJ.AutoSize = True
        Me.rbDPJ.Checked = True
        Me.rbDPJ.Location = New System.Drawing.Point(108, 19)
        Me.rbDPJ.Name = "rbDPJ"
        Me.rbDPJ.Size = New System.Drawing.Size(82, 17)
        Me.rbDPJ.TabIndex = 1
        Me.rbDPJ.TabStop = True
        Me.rbDPJ.Text = "DPJ System"
        Me.rbDPJ.UseVisualStyleBackColor = True
        '
        'rbRemantic
        '
        Me.rbRemantic.AutoSize = True
        Me.rbRemantic.Location = New System.Drawing.Point(6, 19)
        Me.rbRemantic.Name = "rbRemantic"
        Me.rbRemantic.Size = New System.Drawing.Size(70, 17)
        Me.rbRemantic.TabIndex = 0
        Me.rbRemantic.Text = "Remantic"
        Me.rbRemantic.UseVisualStyleBackColor = True
        '
        'loanDate
        '
        Me.loanDate.Location = New System.Drawing.Point(257, 105)
        Me.loanDate.Name = "loanDate"
        Me.loanDate.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(254, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Loan Date"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(504, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Maturity Date"
        '
        'txtMatu
        '
        Me.txtMatu.Location = New System.Drawing.Point(507, 33)
        Me.txtMatu.Name = "txtMatu"
        Me.txtMatu.ReadOnly = True
        Me.txtMatu.Size = New System.Drawing.Size(162, 20)
        Me.txtMatu.TabIndex = 4
        '
        'txtExpiry
        '
        Me.txtExpiry.Location = New System.Drawing.Point(507, 77)
        Me.txtExpiry.Name = "txtExpiry"
        Me.txtExpiry.ReadOnly = True
        Me.txtExpiry.Size = New System.Drawing.Size(162, 20)
        Me.txtExpiry.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(504, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Expiry Date"
        '
        'txtAuction
        '
        Me.txtAuction.Location = New System.Drawing.Point(507, 122)
        Me.txtAuction.Name = "txtAuction"
        Me.txtAuction.ReadOnly = True
        Me.txtAuction.Size = New System.Drawing.Size(162, 20)
        Me.txtAuction.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(504, 106)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Auction Date"
        '
        'cboType
        '
        Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType.FormattingEnabled = True
        Me.cboType.Items.AddRange(New Object() {"APP", "JWL", "CEL", "BIG"})
        Me.cboType.Location = New System.Drawing.Point(507, 168)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(118, 21)
        Me.cboType.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(505, 152)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Item Class"
        '
        'txtPrincipal
        '
        Me.txtPrincipal.Location = New System.Drawing.Point(508, 211)
        Me.txtPrincipal.Name = "txtPrincipal"
        Me.txtPrincipal.Size = New System.Drawing.Size(162, 20)
        Me.txtPrincipal.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(505, 195)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Principal"
        '
        'txtDaysOver
        '
        Me.txtDaysOver.Location = New System.Drawing.Point(743, 33)
        Me.txtDaysOver.Name = "txtDaysOver"
        Me.txtDaysOver.ReadOnly = True
        Me.txtDaysOver.Size = New System.Drawing.Size(162, 20)
        Me.txtDaysOver.TabIndex = 16
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(740, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Days Over Due"
        '
        'txtInt
        '
        Me.txtInt.Location = New System.Drawing.Point(743, 74)
        Me.txtInt.Name = "txtInt"
        Me.txtInt.ReadOnly = True
        Me.txtInt.Size = New System.Drawing.Size(162, 20)
        Me.txtInt.TabIndex = 18
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(740, 58)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Interest"
        '
        'txtSC
        '
        Me.txtSC.Location = New System.Drawing.Point(743, 152)
        Me.txtSC.Name = "txtSC"
        Me.txtSC.ReadOnly = True
        Me.txtSC.Size = New System.Drawing.Size(162, 20)
        Me.txtSC.TabIndex = 22
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(740, 136)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 13)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Service Charge"
        '
        'txtPenalty
        '
        Me.txtPenalty.Location = New System.Drawing.Point(743, 111)
        Me.txtPenalty.Name = "txtPenalty"
        Me.txtPenalty.ReadOnly = True
        Me.txtPenalty.Size = New System.Drawing.Size(162, 20)
        Me.txtPenalty.TabIndex = 20
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(740, 95)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 13)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Penalty"
        '
        'txtRedeemDue
        '
        Me.txtRedeemDue.Location = New System.Drawing.Point(743, 250)
        Me.txtRedeemDue.Name = "txtRedeemDue"
        Me.txtRedeemDue.ReadOnly = True
        Me.txtRedeemDue.Size = New System.Drawing.Size(162, 20)
        Me.txtRedeemDue.TabIndex = 26
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(740, 234)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 13)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "Redeem Due"
        '
        'txtRenewDue
        '
        Me.txtRenewDue.Location = New System.Drawing.Point(743, 209)
        Me.txtRenewDue.Name = "txtRenewDue"
        Me.txtRenewDue.ReadOnly = True
        Me.txtRenewDue.Size = New System.Drawing.Size(162, 20)
        Me.txtRenewDue.TabIndex = 24
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(740, 193)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 13)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "Renew Due"
        '
        'txtNetAmount
        '
        Me.txtNetAmount.Location = New System.Drawing.Point(508, 250)
        Me.txtNetAmount.Name = "txtNetAmount"
        Me.txtNetAmount.ReadOnly = True
        Me.txtNetAmount.Size = New System.Drawing.Size(162, 20)
        Me.txtNetAmount.TabIndex = 28
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(505, 234)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(63, 13)
        Me.Label13.TabIndex = 27
        Me.Label13.Text = "Net Amount"
        '
        'btnCompute
        '
        Me.btnCompute.Location = New System.Drawing.Point(921, 12)
        Me.btnCompute.Name = "btnCompute"
        Me.btnCompute.Size = New System.Drawing.Size(143, 62)
        Me.btnCompute.TabIndex = 29
        Me.btnCompute.Text = "COMPUTE"
        Me.btnCompute.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(9, 83)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(47, 13)
        Me.Label14.TabIndex = 31
        Me.Label14.Text = "Today is"
        '
        'current
        '
        Me.current.Location = New System.Drawing.Point(12, 105)
        Me.current.Name = "current"
        Me.current.TabIndex = 30
        '
        'txtAdvInt
        '
        Me.txtAdvInt.Location = New System.Drawing.Point(911, 152)
        Me.txtAdvInt.Name = "txtAdvInt"
        Me.txtAdvInt.ReadOnly = True
        Me.txtAdvInt.Size = New System.Drawing.Size(85, 20)
        Me.txtAdvInt.TabIndex = 33
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(908, 136)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(88, 13)
        Me.Label15.TabIndex = 32
        Me.Label15.Text = "Advance Interest"
        '
        'dev_Pawning
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1076, 283)
        Me.Controls.Add(Me.txtAdvInt)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.current)
        Me.Controls.Add(Me.btnCompute)
        Me.Controls.Add(Me.txtNetAmount)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtRedeemDue)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtRenewDue)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtSC)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtPenalty)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtInt)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtDaysOver)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtPrincipal)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboType)
        Me.Controls.Add(Me.txtAuction)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtExpiry)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtMatu)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.loanDate)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "dev_Pawning"
        Me.Text = "dev_Pawning"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbDPJ As System.Windows.Forms.RadioButton
    Friend WithEvents rbRemantic As System.Windows.Forms.RadioButton
    Friend WithEvents loanDate As System.Windows.Forms.MonthCalendar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMatu As System.Windows.Forms.TextBox
    Friend WithEvents txtExpiry As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtAuction As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboType As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPrincipal As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDaysOver As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtInt As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtSC As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtPenalty As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtRedeemDue As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtRenewDue As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtNetAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnCompute As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents current As System.Windows.Forms.MonthCalendar
    Friend WithEvents txtAdvInt As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
End Class
