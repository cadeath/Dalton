<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClientMigrate
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
        Me.components = New System.ComponentModel.Container()
        Me.bgMigrate = New System.ComponentModel.BackgroundWorker()
        Me.lblPath = New System.Windows.Forms.Label()
        Me.btnMigrate = New System.Windows.Forms.Button()
        Me.tmrMigrate = New System.Windows.Forms.Timer(Me.components)
        Me.pBMigrate = New System.Windows.Forms.ProgressBar()
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.OFDMigrate = New System.Windows.Forms.OpenFileDialog()
        Me.SuspendLayout()
        '
        'bgMigrate
        '
        '
        'lblPath
        '
        Me.lblPath.AutoSize = True
        Me.lblPath.Location = New System.Drawing.Point(11, 11)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(29, 13)
        Me.lblPath.TabIndex = 0
        Me.lblPath.Text = "Path"
        '
        'btnMigrate
        '
        Me.btnMigrate.Location = New System.Drawing.Point(408, 43)
        Me.btnMigrate.Name = "btnMigrate"
        Me.btnMigrate.Size = New System.Drawing.Size(94, 26)
        Me.btnMigrate.TabIndex = 1
        Me.btnMigrate.Text = "Migrate Now"
        Me.btnMigrate.UseVisualStyleBackColor = True
        '
        'tmrMigrate
        '
        Me.tmrMigrate.Interval = 1000
        '
        'pBMigrate
        '
        Me.pBMigrate.Location = New System.Drawing.Point(-2, 72)
        Me.pBMigrate.Name = "pBMigrate"
        Me.pBMigrate.Size = New System.Drawing.Size(513, 23)
        Me.pBMigrate.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pBMigrate.TabIndex = 2
        '
        'txtPath
        '
        Me.txtPath.Location = New System.Drawing.Point(54, 9)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.ReadOnly = True
        Me.txtPath.Size = New System.Drawing.Size(348, 20)
        Me.txtPath.TabIndex = 3
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(5, 56)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(36, 13)
        Me.lblStatus.TabIndex = 4
        Me.lblStatus.Text = "0.00%"
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(408, 5)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(94, 26)
        Me.btnBrowse.TabIndex = 5
        Me.btnBrowse.Text = ". . . . . . ."
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'OFDMigrate
        '
        Me.OFDMigrate.FileName = "Database File"
        Me.OFDMigrate.Filter = "Database File |*.FDB"
        '
        'frmClientMigrate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(505, 93)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.txtPath)
        Me.Controls.Add(Me.pBMigrate)
        Me.Controls.Add(Me.btnMigrate)
        Me.Controls.Add(Me.lblPath)
        Me.Name = "frmClientMigrate"
        Me.Text = "Client Migrate"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bgMigrate As System.ComponentModel.BackgroundWorker
    Friend WithEvents lblPath As System.Windows.Forms.Label
    Friend WithEvents btnMigrate As System.Windows.Forms.Button
    Friend WithEvents tmrMigrate As System.Windows.Forms.Timer
    Friend WithEvents pBMigrate As System.Windows.Forms.ProgressBar
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents OFDMigrate As System.Windows.Forms.OpenFileDialog
End Class
