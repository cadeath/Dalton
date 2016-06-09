<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class diagMT
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
        Me.chkSend = New System.Windows.Forms.CheckBox()
        Me.chkPay = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbALL = New System.Windows.Forms.RadioButton()
        Me.rbGPRS = New System.Windows.Forms.RadioButton()
        Me.rbCebuana = New System.Windows.Forms.RadioButton()
        Me.rbWestern = New System.Windows.Forms.RadioButton()
        Me.rbPeraPadala = New System.Windows.Forms.RadioButton()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkSend
        '
        Me.chkSend.AutoSize = True
        Me.chkSend.Checked = True
        Me.chkSend.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSend.Location = New System.Drawing.Point(101, 154)
        Me.chkSend.Name = "chkSend"
        Me.chkSend.Size = New System.Drawing.Size(71, 17)
        Me.chkSend.TabIndex = 7
        Me.chkSend.Text = "Send Out"
        Me.chkSend.UseVisualStyleBackColor = True
        '
        'chkPay
        '
        Me.chkPay.AutoSize = True
        Me.chkPay.Checked = True
        Me.chkPay.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPay.Location = New System.Drawing.Point(12, 154)
        Me.chkPay.Name = "chkPay"
        Me.chkPay.Size = New System.Drawing.Size(64, 17)
        Me.chkPay.TabIndex = 6
        Me.chkPay.Text = "Pay Out"
        Me.chkPay.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbALL)
        Me.GroupBox1.Controls.Add(Me.rbGPRS)
        Me.GroupBox1.Controls.Add(Me.rbCebuana)
        Me.GroupBox1.Controls.Add(Me.rbWestern)
        Me.GroupBox1.Controls.Add(Me.rbPeraPadala)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(160, 136)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Service Names"
        '
        'rbALL
        '
        Me.rbALL.AutoSize = True
        Me.rbALL.Location = New System.Drawing.Point(6, 111)
        Me.rbALL.Name = "rbALL"
        Me.rbALL.Size = New System.Drawing.Size(44, 17)
        Me.rbALL.TabIndex = 4
        Me.rbALL.Text = "ALL"
        Me.rbALL.UseVisualStyleBackColor = True
        '
        'rbGPRS
        '
        Me.rbGPRS.AutoSize = True
        Me.rbGPRS.Location = New System.Drawing.Point(6, 88)
        Me.rbGPRS.Name = "rbGPRS"
        Me.rbGPRS.Size = New System.Drawing.Size(55, 17)
        Me.rbGPRS.TabIndex = 3
        Me.rbGPRS.Text = "GPRS"
        Me.rbGPRS.UseVisualStyleBackColor = True
        '
        'rbCebuana
        '
        Me.rbCebuana.AutoSize = True
        Me.rbCebuana.Location = New System.Drawing.Point(6, 65)
        Me.rbCebuana.Name = "rbCebuana"
        Me.rbCebuana.Size = New System.Drawing.Size(68, 17)
        Me.rbCebuana.TabIndex = 2
        Me.rbCebuana.Text = "Cebuana"
        Me.rbCebuana.UseVisualStyleBackColor = True
        '
        'rbWestern
        '
        Me.rbWestern.AutoSize = True
        Me.rbWestern.Location = New System.Drawing.Point(6, 42)
        Me.rbWestern.Name = "rbWestern"
        Me.rbWestern.Size = New System.Drawing.Size(96, 17)
        Me.rbWestern.TabIndex = 1
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
        Me.rbPeraPadala.TabIndex = 0
        Me.rbPeraPadala.TabStop = True
        Me.rbPeraPadala.Text = "Pera Padala"
        Me.rbPeraPadala.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Location = New System.Drawing.Point(41, 180)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(107, 42)
        Me.btnOK.TabIndex = 8
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'diagMT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(184, 234)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.chkSend)
        Me.Controls.Add(Me.chkPay)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "diagMT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Money Transfer"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkSend As System.Windows.Forms.CheckBox
    Friend WithEvents chkPay As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbALL As System.Windows.Forms.RadioButton
    Friend WithEvents rbGPRS As System.Windows.Forms.RadioButton
    Friend WithEvents rbCebuana As System.Windows.Forms.RadioButton
    Friend WithEvents rbWestern As System.Windows.Forms.RadioButton
    Friend WithEvents rbPeraPadala As System.Windows.Forms.RadioButton
    Friend WithEvents btnOK As System.Windows.Forms.Button
End Class
