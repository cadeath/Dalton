<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain2))
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.ofd_db = New System.Windows.Forms.OpenFileDialog()
        Me.pbLoading = New System.Windows.Forms.ProgressBar()
        Me.btnFix = New System.Windows.Forms.Button()
        Me.txtDB = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSys = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(9, 101)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(31, 13)
        Me.lblStatus.TabIndex = 9
        Me.lblStatus.Text = "IDLE"
        '
        'ofd_db
        '
        Me.ofd_db.Filter = "Database|*.FDB"
        Me.ofd_db.Title = "Browse"
        '
        'pbLoading
        '
        Me.pbLoading.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pbLoading.Location = New System.Drawing.Point(0, 124)
        Me.pbLoading.Name = "pbLoading"
        Me.pbLoading.Size = New System.Drawing.Size(282, 17)
        Me.pbLoading.TabIndex = 8
        '
        'btnFix
        '
        Me.btnFix.Location = New System.Drawing.Point(197, 91)
        Me.btnFix.Name = "btnFix"
        Me.btnFix.Size = New System.Drawing.Size(75, 23)
        Me.btnFix.TabIndex = 2
        Me.btnFix.Text = "Fix"
        Me.btnFix.UseVisualStyleBackColor = True
        '
        'txtDB
        '
        Me.txtDB.Location = New System.Drawing.Point(12, 65)
        Me.txtDB.Name = "txtDB"
        Me.txtDB.Size = New System.Drawing.Size(260, 20)
        Me.txtDB.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Database"
        '
        'txtSys
        '
        Me.txtSys.Location = New System.Drawing.Point(9, 25)
        Me.txtSys.Name = "txtSys"
        Me.txtSys.Size = New System.Drawing.Size(260, 20)
        Me.txtSys.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "SysCode"
        '
        'frmMain2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(282, 141)
        Me.Controls.Add(Me.txtSys)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.pbLoading)
        Me.Controls.Add(Me.btnFix)
        Me.Controls.Add(Me.txtDB)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMain2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fixer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents ofd_db As System.Windows.Forms.OpenFileDialog
    Friend WithEvents pbLoading As System.Windows.Forms.ProgressBar
    Friend WithEvents btnFix As System.Windows.Forms.Button
    Friend WithEvents txtDB As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSys As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
