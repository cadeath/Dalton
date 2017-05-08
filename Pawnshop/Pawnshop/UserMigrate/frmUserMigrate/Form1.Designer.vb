<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.ofd = New System.Windows.Forms.OpenFileDialog()
        Me.tmr = New System.Windows.Forms.Timer(Me.components)
        Me.bg = New System.ComponentModel.BackgroundWorker()
        Me.SFD = New System.Windows.Forms.SaveFileDialog()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.pbMigrate = New System.Windows.Forms.ProgressBar()
        Me.btnMigrate = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtPath = New frmUserMigrate.watermark()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.lblPercent = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofd
        '
        Me.ofd.Filter = "Database |*.FDB"
        '
        'tmr
        '
        '
        'bg
        '
        '
        'SFD
        '
        Me.SFD.Filter = "CIR File |*.cir"
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.lblStatus)
        Me.TabPage1.Controls.Add(Me.pbMigrate)
        Me.TabPage1.Controls.Add(Me.btnMigrate)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.lblPercent)
        Me.TabPage1.Controls.Add(Me.btnExit)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(537, 189)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "User Migrate"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblStatus.Location = New System.Drawing.Point(13, 87)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(119, 26)
        Me.lblStatus.TabIndex = 23
        Me.lblStatus.Text = "Steps: 1. Create tables" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "           2. Migrating data"
        '
        'pbMigrate
        '
        Me.pbMigrate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbMigrate.Location = New System.Drawing.Point(0, 169)
        Me.pbMigrate.Name = "pbMigrate"
        Me.pbMigrate.Size = New System.Drawing.Size(541, 23)
        Me.pbMigrate.TabIndex = 16
        '
        'btnMigrate
        '
        Me.btnMigrate.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnMigrate.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMigrate.Location = New System.Drawing.Point(337, 88)
        Me.btnMigrate.Name = "btnMigrate"
        Me.btnMigrate.Size = New System.Drawing.Size(87, 52)
        Me.btnMigrate.TabIndex = 20
        Me.btnMigrate.Text = "Migrate Now "
        Me.btnMigrate.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtPath)
        Me.GroupBox1.Controls.Add(Me.btnBrowse)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.GroupBox1.Location = New System.Drawing.Point(10, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(502, 60)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Path"
        '
        'txtPath
        '
        Me.txtPath.Location = New System.Drawing.Point(6, 20)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.ReadOnly = True
        Me.txtPath.Size = New System.Drawing.Size(439, 23)
        Me.txtPath.TabIndex = 19
        Me.txtPath.WatermarkColor = System.Drawing.Color.Gray
        Me.txtPath.WatermarkText = "Path"
        '
        'btnBrowse
        '
        Me.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnBrowse.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowse.Location = New System.Drawing.Point(451, 20)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(45, 34)
        Me.btnBrowse.TabIndex = 18
        Me.btnBrowse.Text = ". . ."
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'lblPercent
        '
        Me.lblPercent.AutoSize = True
        Me.lblPercent.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblPercent.Location = New System.Drawing.Point(1, 136)
        Me.lblPercent.Name = "lblPercent"
        Me.lblPercent.Size = New System.Drawing.Size(36, 13)
        Me.lblPercent.TabIndex = 22
        Me.lblPercent.Text = "0.00%"
        '
        'btnExit
        '
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(430, 87)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(82, 53)
        Me.btnExit.TabIndex = 21
        Me.btnExit.Text = "Close >>>"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(8, 13)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(545, 215)
        Me.TabControl1.TabIndex = 19
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(562, 242)
        Me.Controls.Add(Me.TabControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "User Migrate"
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofd As System.Windows.Forms.OpenFileDialog
    Friend WithEvents tmr As System.Windows.Forms.Timer
    Friend WithEvents bg As System.ComponentModel.BackgroundWorker
    Friend WithEvents SFD As System.Windows.Forms.SaveFileDialog
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents pbMigrate As System.Windows.Forms.ProgressBar
    Friend WithEvents btnMigrate As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPath As frmUserMigrate.watermark
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents lblPercent As System.Windows.Forms.Label
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl

End Class
