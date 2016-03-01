<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class qryLoan
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
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lstRegister = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'monCal
        '
        Me.monCal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.monCal.Location = New System.Drawing.Point(18, 64)
        Me.monCal.MaxSelectionCount = 1
        Me.monCal.Name = "monCal"
        Me.monCal.TabIndex = 1
        '
        'btnGenerate
        '
        Me.btnGenerate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerate.Location = New System.Drawing.Point(19, 255)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(103, 46)
        Me.btnGenerate.TabIndex = 2
        Me.btnGenerate.Text = "&Generate"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(128, 255)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(103, 46)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lstRegister
        '
        Me.lstRegister.FormattingEnabled = True
        Me.lstRegister.Items.AddRange(New Object() {"Loan Register - New Loan/Renew", "Loan Register - Redemption"})
        Me.lstRegister.Location = New System.Drawing.Point(18, 12)
        Me.lstRegister.Name = "lstRegister"
        Me.lstRegister.Size = New System.Drawing.Size(213, 43)
        Me.lstRegister.TabIndex = 4
        '
        'qryLoan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(248, 318)
        Me.Controls.Add(Me.lstRegister)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnGenerate)
        Me.Controls.Add(Me.monCal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "qryLoan"
        Me.Text = "Loan Register"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents monCal As System.Windows.Forms.MonthCalendar
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lstRegister As System.Windows.Forms.ListBox
End Class
