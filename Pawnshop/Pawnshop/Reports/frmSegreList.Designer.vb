<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSegreList
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
        Me.monCalendar = New System.Windows.Forms.MonthCalendar()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'monCalendar
        '
        Me.monCalendar.Location = New System.Drawing.Point(9, 18)
        Me.monCalendar.Name = "monCalendar"
        Me.monCalendar.TabIndex = 1
        '
        'btnGenerate
        '
        Me.btnGenerate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerate.Location = New System.Drawing.Point(83, 192)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(88, 49)
        Me.btnGenerate.TabIndex = 2
        Me.btnGenerate.Text = "&Generate"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'frmSegreList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(250, 256)
        Me.Controls.Add(Me.btnGenerate)
        Me.Controls.Add(Me.monCalendar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmSegreList"
        Me.Text = "Segregated List"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents monCalendar As System.Windows.Forms.MonthCalendar
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
End Class
