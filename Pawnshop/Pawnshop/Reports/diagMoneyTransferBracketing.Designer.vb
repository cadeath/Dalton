<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class diagMoneyTransferBracketing
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
        Me.rbGPRS = New System.Windows.Forms.RadioButton()
        Me.rbPeraPadalapmftc = New System.Windows.Forms.RadioButton()
        Me.rbWesternIntl = New System.Windows.Forms.RadioButton()
        Me.rbCebuana = New System.Windows.Forms.RadioButton()
        Me.rbWestern = New System.Windows.Forms.RadioButton()
        Me.rbPeraPadala = New System.Windows.Forms.RadioButton()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.cboGrprs = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboGrprs)
        Me.GroupBox1.Controls.Add(Me.rbGPRS)
        Me.GroupBox1.Controls.Add(Me.rbPeraPadalapmftc)
        Me.GroupBox1.Controls.Add(Me.rbWesternIntl)
        Me.GroupBox1.Controls.Add(Me.rbCebuana)
        Me.GroupBox1.Controls.Add(Me.rbWestern)
        Me.GroupBox1.Controls.Add(Me.rbPeraPadala)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(160, 192)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Service Names"
        '
        'rbGPRS
        '
        Me.rbGPRS.AutoSize = True
        Me.rbGPRS.Location = New System.Drawing.Point(6, 134)
        Me.rbGPRS.Name = "rbGPRS"
        Me.rbGPRS.Size = New System.Drawing.Size(55, 17)
        Me.rbGPRS.TabIndex = 7
        Me.rbGPRS.Text = "GPRS"
        Me.rbGPRS.UseVisualStyleBackColor = True
        '
        'rbPeraPadalapmftc
        '
        Me.rbPeraPadalapmftc.AutoSize = True
        Me.rbPeraPadalapmftc.Location = New System.Drawing.Point(6, 42)
        Me.rbPeraPadalapmftc.Name = "rbPeraPadalapmftc"
        Me.rbPeraPadalapmftc.Size = New System.Drawing.Size(118, 17)
        Me.rbPeraPadalapmftc.TabIndex = 6
        Me.rbPeraPadalapmftc.Text = "Pera Padala - pmftc"
        Me.rbPeraPadalapmftc.UseVisualStyleBackColor = True
        '
        'rbWesternIntl
        '
        Me.rbWesternIntl.AutoSize = True
        Me.rbWesternIntl.Location = New System.Drawing.Point(6, 88)
        Me.rbWesternIntl.Name = "rbWesternIntl"
        Me.rbWesternIntl.Size = New System.Drawing.Size(119, 17)
        Me.rbWesternIntl.TabIndex = 5
        Me.rbWesternIntl.Text = "Western Union - Intl"
        Me.rbWesternIntl.UseVisualStyleBackColor = True
        '
        'rbCebuana
        '
        Me.rbCebuana.AutoSize = True
        Me.rbCebuana.Location = New System.Drawing.Point(6, 111)
        Me.rbCebuana.Name = "rbCebuana"
        Me.rbCebuana.Size = New System.Drawing.Size(68, 17)
        Me.rbCebuana.TabIndex = 2
        Me.rbCebuana.Text = "Cebuana"
        Me.rbCebuana.UseVisualStyleBackColor = True
        '
        'rbWestern
        '
        Me.rbWestern.AutoSize = True
        Me.rbWestern.Location = New System.Drawing.Point(6, 65)
        Me.rbWestern.Name = "rbWestern"
        Me.rbWestern.Size = New System.Drawing.Size(131, 17)
        Me.rbWestern.TabIndex = 1
        Me.rbWestern.Text = "Western Union - Local"
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
        Me.btnOK.Location = New System.Drawing.Point(42, 210)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(107, 42)
        Me.btnOK.TabIndex = 9
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'cboGrprs
        '
        Me.cboGrprs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGrprs.Enabled = False
        Me.cboGrprs.FormattingEnabled = True
        Me.cboGrprs.Items.AddRange(New Object() {"GPRS to GPRS", "GPRS to Smart Money,", "GPRS to BANK (UCPB/PNB)", "GPRS to BANK (BDO/Chinabank)", "GPRS to BANK (DBP)", "GPRS to BANK (MetroBank)", "GPRS to BANK (Maybank/LandBank)", "iREMIT to GPRS", "NYBP/Transfast to GPRS", "GPRS to Moneygram"})
        Me.cboGrprs.Location = New System.Drawing.Point(6, 157)
        Me.cboGrprs.Name = "cboGrprs"
        Me.cboGrprs.Size = New System.Drawing.Size(148, 21)
        Me.cboGrprs.TabIndex = 8
        '
        'diagMoneyTransferBracketing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(183, 261)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "diagMoneyTransferBracketing"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Money Transfer Bracketing"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbCebuana As System.Windows.Forms.RadioButton
    Friend WithEvents rbWestern As System.Windows.Forms.RadioButton
    Friend WithEvents rbPeraPadala As System.Windows.Forms.RadioButton
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents rbWesternIntl As System.Windows.Forms.RadioButton
    Friend WithEvents rbPeraPadalapmftc As System.Windows.Forms.RadioButton
    Friend WithEvents rbGPRS As System.Windows.Forms.RadioButton
    Friend WithEvents cboGrprs As System.Windows.Forms.ComboBox
End Class
