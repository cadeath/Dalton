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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.pbUpdate = New System.Windows.Forms.ProgressBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(78, 44)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'pbUpdate
        '
        Me.pbUpdate.Location = New System.Drawing.Point(12, 62)
        Me.pbUpdate.Name = "pbUpdate"
        Me.pbUpdate.Size = New System.Drawing.Size(400, 16)
        Me.pbUpdate.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(96, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(318, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "IDLE"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(426, 91)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pbUpdate)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Main"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents pbUpdate As System.Windows.Forms.ProgressBar
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
