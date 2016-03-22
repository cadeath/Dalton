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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtUrl = New System.Windows.Forms.TextBox()
        Me.btnExtract = New System.Windows.Forms.Button()
        Me.pbLoading = New System.Windows.Forms.ProgressBar()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.pullDate = New System.Windows.Forms.MonthCalendar()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ofdFirebird = New System.Windows.Forms.OpenFileDialog()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Path:"
        '
        'txtUrl
        '
        Me.txtUrl.Location = New System.Drawing.Point(12, 25)
        Me.txtUrl.Name = "txtUrl"
        Me.txtUrl.Size = New System.Drawing.Size(224, 20)
        Me.txtUrl.TabIndex = 1
        Me.txtUrl.Text = "D:\cadeath\Documents\RPS\Database\Dalton Cagampang.FDB"
        '
        'btnExtract
        '
        Me.btnExtract.Location = New System.Drawing.Point(15, 262)
        Me.btnExtract.Name = "btnExtract"
        Me.btnExtract.Size = New System.Drawing.Size(88, 34)
        Me.btnExtract.TabIndex = 3
        Me.btnExtract.Text = "&Extract"
        Me.btnExtract.UseVisualStyleBackColor = True
        '
        'pbLoading
        '
        Me.pbLoading.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pbLoading.Location = New System.Drawing.Point(0, 320)
        Me.pbLoading.Name = "pbLoading"
        Me.pbLoading.Size = New System.Drawing.Size(248, 16)
        Me.pbLoading.TabIndex = 4
        Me.pbLoading.Visible = False
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(9, 304)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(24, 13)
        Me.lblStatus.TabIndex = 5
        Me.lblStatus.Text = "Idle"
        '
        'pullDate
        '
        Me.pullDate.Location = New System.Drawing.Point(12, 87)
        Me.pullDate.Name = "pullDate"
        Me.pullDate.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Last Pullout Date"
        '
        'ofdFirebird
        '
        Me.ofdFirebird.FileName = "Database"
        Me.ofdFirebird.Filter = "Firebird|*.FDB"
        Me.ofdFirebird.Title = "Migrate"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(248, 336)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.pullDate)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.pbLoading)
        Me.Controls.Add(Me.btnExtract)
        Me.Controls.Add(Me.txtUrl)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Database Extractor"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtUrl As System.Windows.Forms.TextBox
    Friend WithEvents btnExtract As System.Windows.Forms.Button
    Friend WithEvents pbLoading As System.Windows.Forms.ProgressBar
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents pullDate As System.Windows.Forms.MonthCalendar
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ofdFirebird As System.Windows.Forms.OpenFileDialog

End Class
