<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class devMTCharge
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
        Me.txtNetAmount = New System.Windows.Forms.TextBox()
        Me.txtCharge = New System.Windows.Forms.TextBox()
        Me.cboType = New System.Windows.Forms.ComboBox()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.txtCommision = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtCommision)
        Me.GroupBox1.Controls.Add(Me.txtNetAmount)
        Me.GroupBox1.Controls.Add(Me.txtCharge)
        Me.GroupBox1.Controls.Add(Me.cboType)
        Me.GroupBox1.Controls.Add(Me.txtAmount)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(187, 201)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txtNetAmount
        '
        Me.txtNetAmount.Location = New System.Drawing.Point(6, 166)
        Me.txtNetAmount.Name = "txtNetAmount"
        Me.txtNetAmount.ReadOnly = True
        Me.txtNetAmount.Size = New System.Drawing.Size(168, 20)
        Me.txtNetAmount.TabIndex = 3
        '
        'txtCharge
        '
        Me.txtCharge.Location = New System.Drawing.Point(6, 127)
        Me.txtCharge.Name = "txtCharge"
        Me.txtCharge.ReadOnly = True
        Me.txtCharge.Size = New System.Drawing.Size(168, 20)
        Me.txtCharge.TabIndex = 2
        '
        'cboType
        '
        Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType.FormattingEnabled = True
        Me.cboType.Location = New System.Drawing.Point(6, 19)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(168, 21)
        Me.cboType.TabIndex = 1
        '
        'txtAmount
        '
        Me.txtAmount.Location = New System.Drawing.Point(6, 60)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(168, 20)
        Me.txtAmount.TabIndex = 0
        '
        'txtCommision
        '
        Me.txtCommision.Location = New System.Drawing.Point(6, 101)
        Me.txtCommision.Name = "txtCommision"
        Me.txtCommision.ReadOnly = True
        Me.txtCommision.Size = New System.Drawing.Size(168, 20)
        Me.txtCommision.TabIndex = 4
        '
        'devMTCharge
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(336, 218)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "devMTCharge"
        Me.Text = "Money Transfer Charge"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNetAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtCharge As System.Windows.Forms.TextBox
    Friend WithEvents cboType As System.Windows.Forms.ComboBox
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtCommision As System.Windows.Forms.TextBox
End Class
