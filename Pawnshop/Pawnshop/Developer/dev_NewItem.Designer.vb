<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dev_NewItem
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
        Me.btnPop = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnPop
        '
        Me.btnPop.Location = New System.Drawing.Point(12, 12)
        Me.btnPop.Name = "btnPop"
        Me.btnPop.Size = New System.Drawing.Size(84, 46)
        Me.btnPop.TabIndex = 0
        Me.btnPop.Text = "POPULATE"
        Me.btnPop.UseVisualStyleBackColor = True
        '
        'dev_NewItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(563, 323)
        Me.Controls.Add(Me.btnPop)
        Me.Name = "dev_NewItem"
        Me.Text = "dev_NewItem"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnPop As System.Windows.Forms.Button
End Class
