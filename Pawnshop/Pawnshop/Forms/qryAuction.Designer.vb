<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class qryAuction
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
        Me.rbALL = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbJWL = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'monCal
        '
        Me.monCal.Location = New System.Drawing.Point(137, 10)
        Me.monCal.Name = "monCal"
        Me.monCal.TabIndex = 2
        '
        'btnGenerate
        '
        Me.btnGenerate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerate.Location = New System.Drawing.Point(137, 178)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(227, 28)
        Me.btnGenerate.TabIndex = 3
        Me.btnGenerate.Text = "Generate"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'rbALL
        '
        Me.rbALL.AutoSize = True
        Me.rbALL.Checked = True
        Me.rbALL.Location = New System.Drawing.Point(9, 19)
        Me.rbALL.Name = "rbALL"
        Me.rbALL.Size = New System.Drawing.Size(44, 17)
        Me.rbALL.TabIndex = 10
        Me.rbALL.TabStop = True
        Me.rbALL.Text = "ALL"
        Me.rbALL.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbALL)
        Me.GroupBox1.Controls.Add(Me.rbJWL)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 62)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(115, 73)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'rbJWL
        '
        Me.rbJWL.AutoSize = True
        Me.rbJWL.Location = New System.Drawing.Point(8, 48)
        Me.rbJWL.Name = "rbJWL"
        Me.rbJWL.Size = New System.Drawing.Size(47, 17)
        Me.rbJWL.TabIndex = 9
        Me.rbJWL.Text = "JWL"
        Me.rbJWL.UseVisualStyleBackColor = True
        '
        'qryAuction
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(372, 218)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnGenerate)
        Me.Controls.Add(Me.monCal)
        Me.Name = "qryAuction"
        Me.Text = "Auction Monthly Report"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents monCal As System.Windows.Forms.MonthCalendar
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents rbALL As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbJWL As System.Windows.Forms.RadioButton
End Class
