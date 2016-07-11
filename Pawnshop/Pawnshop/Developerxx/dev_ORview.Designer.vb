<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dev_ORview
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
        Me.rv_display = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.btnView = New System.Windows.Forms.Button()
        Me.txtPAWNID = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'rv_display
        '
        Me.rv_display.Location = New System.Drawing.Point(12, 42)
        Me.rv_display.Name = "rv_display"
        Me.rv_display.Size = New System.Drawing.Size(563, 320)
        Me.rv_display.TabIndex = 0
        '
        'btnView
        '
        Me.btnView.Location = New System.Drawing.Point(118, 7)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(82, 29)
        Me.btnView.TabIndex = 1
        Me.btnView.Text = "View"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'txtPAWNID
        '
        Me.txtPAWNID.Location = New System.Drawing.Point(12, 12)
        Me.txtPAWNID.Name = "txtPAWNID"
        Me.txtPAWNID.Size = New System.Drawing.Size(100, 20)
        Me.txtPAWNID.TabIndex = 2
        Me.txtPAWNID.Text = "548"
        '
        'dev_ORview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(590, 374)
        Me.Controls.Add(Me.txtPAWNID)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.rv_display)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "dev_ORview"
        Me.Text = "dev_ORview"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rv_display As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents btnView As System.Windows.Forms.Button
    Friend WithEvents txtPAWNID As System.Windows.Forms.TextBox
End Class
