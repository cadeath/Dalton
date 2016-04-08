<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRecompute
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDB = New System.Windows.Forms.TextBox()
        Me.btnFix = New System.Windows.Forms.Button()
        Me.pbLoading = New System.Windows.Forms.ProgressBar()
        Me.ofd_db = New System.Windows.Forms.OpenFileDialog()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Database"
        '
        'txtDB
        '
        Me.txtDB.Location = New System.Drawing.Point(12, 25)
        Me.txtDB.Name = "txtDB"
        Me.txtDB.Size = New System.Drawing.Size(260, 20)
        Me.txtDB.TabIndex = 1
        '
        'btnFix
        '
        Me.btnFix.Location = New System.Drawing.Point(197, 51)
        Me.btnFix.Name = "btnFix"
        Me.btnFix.Size = New System.Drawing.Size(75, 23)
        Me.btnFix.TabIndex = 2
        Me.btnFix.Text = "Fix"
        Me.btnFix.UseVisualStyleBackColor = True
        '
        'pbLoading
        '
        Me.pbLoading.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pbLoading.Location = New System.Drawing.Point(0, 84)
        Me.pbLoading.Name = "pbLoading"
        Me.pbLoading.Size = New System.Drawing.Size(284, 17)
        Me.pbLoading.TabIndex = 3
        '
        'ofd_db
        '
        Me.ofd_db.Filter = "Database|*.FDB"
        Me.ofd_db.Title = "Browse"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(9, 68)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(31, 13)
        Me.lblStatus.TabIndex = 4
        Me.lblStatus.Text = "IDLE"
        '
        'frmRecompute
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 101)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.pbLoading)
        Me.Controls.Add(Me.btnFix)
        Me.Controls.Add(Me.txtDB)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "frmRecompute"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Recompute"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDB As System.Windows.Forms.TextBox
    Friend WithEvents btnFix As System.Windows.Forms.Button
    Friend WithEvents pbLoading As System.Windows.Forms.ProgressBar
    Friend WithEvents ofd_db As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblStatus As System.Windows.Forms.Label
End Class
