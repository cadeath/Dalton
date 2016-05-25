<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DollarTransction
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
        Me.monCal = New System.Windows.Forms.MonthCalendar()
        Me.cbmCurrency = New System.Windows.Forms.ComboBox()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.cboMonthlyDaily = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'monCal
        '
        Me.monCal.Location = New System.Drawing.Point(11, 11)
        Me.monCal.Name = "monCal"
        Me.monCal.TabIndex = 0
        '
        'cbmCurrency
        '
        Me.cbmCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbmCurrency.FormattingEnabled = True
        Me.cbmCurrency.Location = New System.Drawing.Point(12, 182)
        Me.cbmCurrency.Name = "cbmCurrency"
        Me.cbmCurrency.Size = New System.Drawing.Size(227, 21)
        Me.cbmCurrency.TabIndex = 1
        '
        'btnGenerate
        '
        Me.btnGenerate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerate.Location = New System.Drawing.Point(68, 235)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(125, 38)
        Me.btnGenerate.TabIndex = 2
        Me.btnGenerate.Text = "&Generate"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'cboMonthlyDaily
        '
        Me.cboMonthlyDaily.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMonthlyDaily.FormattingEnabled = True
        Me.cboMonthlyDaily.Items.AddRange(New Object() {"Monthly", "Daily"})
        Me.cboMonthlyDaily.Location = New System.Drawing.Point(12, 208)
        Me.cboMonthlyDaily.Name = "cboMonthlyDaily"
        Me.cboMonthlyDaily.Size = New System.Drawing.Size(114, 21)
        Me.cboMonthlyDaily.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(132, 211)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Monthly/Daily"
        '
        'DollarTransction
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(248, 275)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboMonthlyDaily)
        Me.Controls.Add(Me.btnGenerate)
        Me.Controls.Add(Me.cbmCurrency)
        Me.Controls.Add(Me.monCal)
        Me.Name = "DollarTransction"
        Me.Text = "Dollar Transction"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents monCal As System.Windows.Forms.MonthCalendar
    Friend WithEvents cbmCurrency As System.Windows.Forms.ComboBox
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents cboMonthlyDaily As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
