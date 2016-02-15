<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class qrySequence
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
        Me.rbInsurance = New System.Windows.Forms.RadioButton()
        Me.rbBorrowing = New System.Windows.Forms.RadioButton()
        Me.rbMT = New System.Windows.Forms.RadioButton()
        Me.rbPawning = New System.Windows.Forms.RadioButton()
        Me.monCal = New System.Windows.Forms.MonthCalendar()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbInsurance)
        Me.GroupBox1.Controls.Add(Me.rbBorrowing)
        Me.GroupBox1.Controls.Add(Me.rbMT)
        Me.GroupBox1.Controls.Add(Me.rbPawning)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(157, 224)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Module"
        '
        'rbInsurance
        '
        Me.rbInsurance.AutoSize = True
        Me.rbInsurance.Location = New System.Drawing.Point(17, 88)
        Me.rbInsurance.Name = "rbInsurance"
        Me.rbInsurance.Size = New System.Drawing.Size(72, 17)
        Me.rbInsurance.TabIndex = 5
        Me.rbInsurance.Text = "Insurance"
        Me.rbInsurance.UseVisualStyleBackColor = True
        Me.rbInsurance.Visible = False
        '
        'rbBorrowing
        '
        Me.rbBorrowing.AutoSize = True
        Me.rbBorrowing.Location = New System.Drawing.Point(17, 65)
        Me.rbBorrowing.Name = "rbBorrowing"
        Me.rbBorrowing.Size = New System.Drawing.Size(77, 17)
        Me.rbBorrowing.TabIndex = 4
        Me.rbBorrowing.Text = "Borrowings"
        Me.rbBorrowing.UseVisualStyleBackColor = True
        Me.rbBorrowing.Visible = False
        '
        'rbMT
        '
        Me.rbMT.AutoSize = True
        Me.rbMT.Location = New System.Drawing.Point(17, 42)
        Me.rbMT.Name = "rbMT"
        Me.rbMT.Size = New System.Drawing.Size(99, 17)
        Me.rbMT.TabIndex = 3
        Me.rbMT.Text = "Money Transfer"
        Me.rbMT.UseVisualStyleBackColor = True
        '
        'rbPawning
        '
        Me.rbPawning.AutoSize = True
        Me.rbPawning.Checked = True
        Me.rbPawning.Location = New System.Drawing.Point(17, 19)
        Me.rbPawning.Name = "rbPawning"
        Me.rbPawning.Size = New System.Drawing.Size(66, 17)
        Me.rbPawning.TabIndex = 2
        Me.rbPawning.TabStop = True
        Me.rbPawning.Text = "Pawning"
        Me.rbPawning.UseVisualStyleBackColor = True
        '
        'monCal
        '
        Me.monCal.Location = New System.Drawing.Point(181, 18)
        Me.monCal.Name = "monCal"
        Me.monCal.TabIndex = 1
        '
        'btnGenerate
        '
        Me.btnGenerate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerate.Location = New System.Drawing.Point(246, 192)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(101, 44)
        Me.btnGenerate.TabIndex = 2
        Me.btnGenerate.Text = "&Generate"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'qrySequence
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(426, 246)
        Me.Controls.Add(Me.btnGenerate)
        Me.Controls.Add(Me.monCal)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "qrySequence"
        Me.Text = "Sequence"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbInsurance As System.Windows.Forms.RadioButton
    Friend WithEvents rbBorrowing As System.Windows.Forms.RadioButton
    Friend WithEvents rbMT As System.Windows.Forms.RadioButton
    Friend WithEvents rbPawning As System.Windows.Forms.RadioButton
    Friend WithEvents monCal As System.Windows.Forms.MonthCalendar
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
End Class
