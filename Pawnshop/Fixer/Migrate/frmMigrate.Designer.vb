<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMigrate
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblPercent = New System.Windows.Forms.Label()
        Me.pbProgressBar = New System.Windows.Forms.ProgressBar()
        Me.btnFix = New System.Windows.Forms.Button()
        Me.txtData = New System.Windows.Forms.TextBox()
        Me.oFd = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblPercent)
        Me.GroupBox1.Controls.Add(Me.pbProgressBar)
        Me.GroupBox1.Controls.Add(Me.btnFix)
        Me.GroupBox1.Controls.Add(Me.txtData)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(302, 90)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Database"
        '
        'lblPercent
        '
        Me.lblPercent.AutoSize = True
        Me.lblPercent.BackColor = System.Drawing.Color.Transparent
        Me.lblPercent.ForeColor = System.Drawing.Color.Black
        Me.lblPercent.Location = New System.Drawing.Point(101, 72)
        Me.lblPercent.Name = "lblPercent"
        Me.lblPercent.Size = New System.Drawing.Size(36, 13)
        Me.lblPercent.TabIndex = 2
        Me.lblPercent.Text = "0.00%"
        '
        'pbProgressBar
        '
        Me.pbProgressBar.Location = New System.Drawing.Point(6, 46)
        Me.pbProgressBar.Maximum = 3000
        Me.pbProgressBar.Name = "pbProgressBar"
        Me.pbProgressBar.Size = New System.Drawing.Size(209, 23)
        Me.pbProgressBar.TabIndex = 1
        '
        'btnFix
        '
        Me.btnFix.Location = New System.Drawing.Point(221, 46)
        Me.btnFix.Name = "btnFix"
        Me.btnFix.Size = New System.Drawing.Size(75, 23)
        Me.btnFix.TabIndex = 0
        Me.btnFix.Text = "Fix"
        Me.btnFix.UseVisualStyleBackColor = True
        '
        'txtData
        '
        Me.txtData.Location = New System.Drawing.Point(6, 15)
        Me.txtData.Name = "txtData"
        Me.txtData.ReadOnly = True
        Me.txtData.Size = New System.Drawing.Size(290, 20)
        Me.txtData.TabIndex = 1
        '
        'oFd
        '
        Me.oFd.Filter = "Data File |*.fdb"
        '
        'frmMigrate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(310, 96)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmMigrate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Migration"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnFix As System.Windows.Forms.Button
    Friend WithEvents pbProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents lblPercent As System.Windows.Forms.Label
    Friend WithEvents txtData As System.Windows.Forms.TextBox
    Friend WithEvents oFd As System.Windows.Forms.OpenFileDialog
End Class
