<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class qryMoneyTransfer
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
        Me.rbCebuana = New System.Windows.Forms.RadioButton()
        Me.rbWestern = New System.Windows.Forms.RadioButton()
        Me.rbPeraPadala = New System.Windows.Forms.RadioButton()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.chkPay = New System.Windows.Forms.CheckBox()
        Me.chkSend = New System.Windows.Forms.CheckBox()
        Me.monCal = New System.Windows.Forms.MonthCalendar()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbCebuana)
        Me.GroupBox1.Controls.Add(Me.rbWestern)
        Me.GroupBox1.Controls.Add(Me.rbPeraPadala)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(160, 97)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Service Names"
        '
        'rbCebuana
        '
        Me.rbCebuana.AutoSize = True
        Me.rbCebuana.Location = New System.Drawing.Point(6, 65)
        Me.rbCebuana.Name = "rbCebuana"
        Me.rbCebuana.Size = New System.Drawing.Size(68, 17)
        Me.rbCebuana.TabIndex = 5
        Me.rbCebuana.Text = "Cebuana"
        Me.rbCebuana.UseVisualStyleBackColor = True
        '
        'rbWestern
        '
        Me.rbWestern.AutoSize = True
        Me.rbWestern.Location = New System.Drawing.Point(6, 42)
        Me.rbWestern.Name = "rbWestern"
        Me.rbWestern.Size = New System.Drawing.Size(96, 17)
        Me.rbWestern.TabIndex = 4
        Me.rbWestern.Text = "Western Union"
        Me.rbWestern.UseVisualStyleBackColor = True
        '
        'rbPeraPadala
        '
        Me.rbPeraPadala.AutoSize = True
        Me.rbPeraPadala.Checked = True
        Me.rbPeraPadala.Location = New System.Drawing.Point(6, 19)
        Me.rbPeraPadala.Name = "rbPeraPadala"
        Me.rbPeraPadala.Size = New System.Drawing.Size(83, 17)
        Me.rbPeraPadala.TabIndex = 3
        Me.rbPeraPadala.TabStop = True
        Me.rbPeraPadala.Text = "Pera Padala"
        Me.rbPeraPadala.UseVisualStyleBackColor = True
        '
        'btnGenerate
        '
        Me.btnGenerate.Location = New System.Drawing.Point(248, 192)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(96, 44)
        Me.btnGenerate.TabIndex = 2
        Me.btnGenerate.Text = "&Generate"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'chkPay
        '
        Me.chkPay.AutoSize = True
        Me.chkPay.Enabled = False
        Me.chkPay.Location = New System.Drawing.Point(18, 118)
        Me.chkPay.Name = "chkPay"
        Me.chkPay.Size = New System.Drawing.Size(64, 17)
        Me.chkPay.TabIndex = 3
        Me.chkPay.Text = "Pay Out"
        Me.chkPay.UseVisualStyleBackColor = True
        '
        'chkSend
        '
        Me.chkSend.AutoSize = True
        Me.chkSend.Enabled = False
        Me.chkSend.Location = New System.Drawing.Point(18, 141)
        Me.chkSend.Name = "chkSend"
        Me.chkSend.Size = New System.Drawing.Size(71, 17)
        Me.chkSend.TabIndex = 4
        Me.chkSend.Text = "Send Out"
        Me.chkSend.UseVisualStyleBackColor = True
        '
        'monCal
        '
        Me.monCal.Location = New System.Drawing.Point(184, 18)
        Me.monCal.MaxSelectionCount = 1
        Me.monCal.Name = "monCal"
        Me.monCal.TabIndex = 5
        '
        'qryMoneyTransfer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(425, 251)
        Me.Controls.Add(Me.monCal)
        Me.Controls.Add(Me.chkSend)
        Me.Controls.Add(Me.chkPay)
        Me.Controls.Add(Me.btnGenerate)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "qryMoneyTransfer"
        Me.Text = "Monthly - Money Transfer"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbCebuana As System.Windows.Forms.RadioButton
    Friend WithEvents rbWestern As System.Windows.Forms.RadioButton
    Friend WithEvents rbPeraPadala As System.Windows.Forms.RadioButton
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents chkPay As System.Windows.Forms.CheckBox
    Friend WithEvents chkSend As System.Windows.Forms.CheckBox
    Friend WithEvents monCal As System.Windows.Forms.MonthCalendar
End Class
