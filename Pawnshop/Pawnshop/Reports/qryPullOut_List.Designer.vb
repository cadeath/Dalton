<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class qryPullOut_List
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
        Me.cboClass = New System.Windows.Forms.ComboBox()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.monCalendar = New System.Windows.Forms.MonthCalendar()
        Me.SuspendLayout()
        '
        'cboClass
        '
        Me.cboClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboClass.FormattingEnabled = True
        Me.cboClass.Location = New System.Drawing.Point(9, 180)
        Me.cboClass.Name = "cboClass"
        Me.cboClass.Size = New System.Drawing.Size(223, 21)
        Me.cboClass.TabIndex = 8
        '
        'btnGenerate
        '
        Me.btnGenerate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerate.Location = New System.Drawing.Point(77, 207)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(88, 49)
        Me.btnGenerate.TabIndex = 7
        Me.btnGenerate.Text = "&Generate"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'monCalendar
        '
        Me.monCalendar.Location = New System.Drawing.Point(9, 7)
        Me.monCalendar.Name = "monCalendar"
        Me.monCalendar.TabIndex = 6
        '
        'qryPullOut_List
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(243, 260)
        Me.Controls.Add(Me.cboClass)
        Me.Controls.Add(Me.btnGenerate)
        Me.Controls.Add(Me.monCalendar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "qryPullOut_List"
        Me.Text = "Item Pullout"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cboClass As System.Windows.Forms.ComboBox
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents monCalendar As System.Windows.Forms.MonthCalendar
End Class
