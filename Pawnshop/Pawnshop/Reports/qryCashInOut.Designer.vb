<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class qryCashInOut
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
        Me.cboCategory = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.monCal = New System.Windows.Forms.MonthCalendar()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.chkIN = New System.Windows.Forms.CheckBox()
        Me.chkOUT = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'cboCategory
        '
        Me.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Location = New System.Drawing.Point(12, 55)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(227, 21)
        Me.cboCategory.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Filter"
        '
        'monCal
        '
        Me.monCal.Location = New System.Drawing.Point(12, 88)
        Me.monCal.MaxSelectionCount = 1
        Me.monCal.Name = "monCal"
        Me.monCal.TabIndex = 2
        '
        'btnGenerate
        '
        Me.btnGenerate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerate.Location = New System.Drawing.Point(12, 262)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(91, 34)
        Me.btnGenerate.TabIndex = 3
        Me.btnGenerate.Text = "Generate"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(148, 262)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(91, 34)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'chkIN
        '
        Me.chkIN.AutoSize = True
        Me.chkIN.Checked = True
        Me.chkIN.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIN.Location = New System.Drawing.Point(12, 12)
        Me.chkIN.Name = "chkIN"
        Me.chkIN.Size = New System.Drawing.Size(62, 17)
        Me.chkIN.TabIndex = 5
        Me.chkIN.Text = "Cash In"
        Me.chkIN.UseVisualStyleBackColor = True
        '
        'chkOUT
        '
        Me.chkOUT.AutoSize = True
        Me.chkOUT.Location = New System.Drawing.Point(80, 12)
        Me.chkOUT.Name = "chkOUT"
        Me.chkOUT.Size = New System.Drawing.Size(70, 17)
        Me.chkOUT.TabIndex = 6
        Me.chkOUT.Text = "Cash Out"
        Me.chkOUT.UseVisualStyleBackColor = True
        '
        'qryCashInOut
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(251, 307)
        Me.Controls.Add(Me.chkOUT)
        Me.Controls.Add(Me.chkIN)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnGenerate)
        Me.Controls.Add(Me.monCal)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboCategory)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "qryCashInOut"
        Me.Text = "Cash In/Out Summary"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboCategory As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents monCal As System.Windows.Forms.MonthCalendar
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents chkIN As System.Windows.Forms.CheckBox
    Friend WithEvents chkOUT As System.Windows.Forms.CheckBox
End Class
