<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class diagTime
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.monCal = New System.Windows.Forms.MonthCalendar()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbHourly = New System.Windows.Forms.RadioButton()
        Me.rbTransaction = New System.Windows.Forms.RadioButton()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Date"
        '
        'monCal
        '
        Me.monCal.Location = New System.Drawing.Point(15, 31)
        Me.monCal.MaxSelectionCount = 1
        Me.monCal.Name = "monCal"
        Me.monCal.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnGenerate)
        Me.GroupBox1.Controls.Add(Me.rbTransaction)
        Me.GroupBox1.Controls.Add(Me.rbHourly)
        Me.GroupBox1.Location = New System.Drawing.Point(254, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(180, 184)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Type"
        '
        'rbHourly
        '
        Me.rbHourly.AutoSize = True
        Me.rbHourly.Checked = True
        Me.rbHourly.Location = New System.Drawing.Point(27, 33)
        Me.rbHourly.Name = "rbHourly"
        Me.rbHourly.Size = New System.Drawing.Size(55, 17)
        Me.rbHourly.TabIndex = 0
        Me.rbHourly.TabStop = True
        Me.rbHourly.Text = "Hourly"
        Me.rbHourly.UseVisualStyleBackColor = True
        '
        'rbTransaction
        '
        Me.rbTransaction.AutoSize = True
        Me.rbTransaction.Location = New System.Drawing.Point(27, 56)
        Me.rbTransaction.Name = "rbTransaction"
        Me.rbTransaction.Size = New System.Drawing.Size(127, 17)
        Me.rbTransaction.TabIndex = 1
        Me.rbTransaction.Text = "Transaction Summary"
        Me.rbTransaction.UseVisualStyleBackColor = True
        '
        'btnGenerate
        '
        Me.btnGenerate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerate.Location = New System.Drawing.Point(48, 118)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(95, 45)
        Me.btnGenerate.TabIndex = 2
        Me.btnGenerate.Text = "&Generate"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'diagTime
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(446, 205)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.monCal)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "diagTime"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Time Report"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents monCal As System.Windows.Forms.MonthCalendar
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents rbTransaction As System.Windows.Forms.RadioButton
    Friend WithEvents rbHourly As System.Windows.Forms.RadioButton
End Class
