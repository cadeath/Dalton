<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class qryDate
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
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.cboReports = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'monCal
        '
        Me.monCal.Location = New System.Drawing.Point(10, 8)
        Me.monCal.Name = "monCal"
        Me.monCal.TabIndex = 0
        '
        'btnGenerate
        '
        Me.btnGenerate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerate.Location = New System.Drawing.Point(78, 209)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(92, 40)
        Me.btnGenerate.TabIndex = 1
        Me.btnGenerate.Text = "&Generate"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'cboReports
        '
        Me.cboReports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboReports.FormattingEnabled = True
        Me.cboReports.Items.AddRange(New Object() {"Schedule of Redeem and Renewal", "Schedule of Loan and Renewal", "Loan Register - New Loan and Renewal 2", "Money Transfer", "Money Transfer (BSP)", "Certificate of Insurance", "Dollar Buying", "Branch Borrowings", "Item Pullout", "Monthly Transaction Count Summary", "Monthly Renewal Break Down"})
        Me.cboReports.Location = New System.Drawing.Point(12, 182)
        Me.cboReports.Name = "cboReports"
        Me.cboReports.Size = New System.Drawing.Size(225, 21)
        Me.cboReports.TabIndex = 2
        '
        'qryDate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(245, 254)
        Me.Controls.Add(Me.cboReports)
        Me.Controls.Add(Me.btnGenerate)
        Me.Controls.Add(Me.monCal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "qryDate"
        Me.Text = "Date Range"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents monCal As System.Windows.Forms.MonthCalendar
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents cboReports As System.Windows.Forms.ComboBox
End Class
