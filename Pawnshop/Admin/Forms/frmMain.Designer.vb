<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.btnCashInOut = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnCashInOut
        '
        Me.btnCashInOut.Location = New System.Drawing.Point(12, 12)
        Me.btnCashInOut.Name = "btnCashInOut"
        Me.btnCashInOut.Size = New System.Drawing.Size(98, 41)
        Me.btnCashInOut.TabIndex = 0
        Me.btnCashInOut.Text = "Cash In/Out"
        Me.btnCashInOut.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(675, 372)
        Me.Controls.Add(Me.btnCashInOut)
        Me.Name = "frmMain"
        Me.Text = "Main"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCashInOut As System.Windows.Forms.Button

End Class
