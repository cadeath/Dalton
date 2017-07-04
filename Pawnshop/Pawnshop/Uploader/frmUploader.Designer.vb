<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUploader
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
        Me.tcUploader = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.txtPathSMT = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnBrowseSMT = New System.Windows.Forms.Button()
        Me.btnImportSMT = New System.Windows.Forms.Button()
        Me.ofdUploader = New System.Windows.Forms.OpenFileDialog()
        Me.tcUploader.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcUploader
        '
        Me.tcUploader.Controls.Add(Me.TabPage1)
        Me.tcUploader.Controls.Add(Me.TabPage2)
        Me.tcUploader.Location = New System.Drawing.Point(12, 12)
        Me.tcUploader.Name = "tcUploader"
        Me.tcUploader.SelectedIndex = 0
        Me.tcUploader.Size = New System.Drawing.Size(503, 140)
        Me.tcUploader.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btnImportSMT)
        Me.TabPage1.Controls.Add(Me.btnBrowseSMT)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.txtPathSMT)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(495, 114)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Smart Money Fee Uploader"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(495, 212)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Under Constraction"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'txtPathSMT
        '
        Me.txtPathSMT.Location = New System.Drawing.Point(9, 28)
        Me.txtPathSMT.Name = "txtPathSMT"
        Me.txtPathSMT.ReadOnly = True
        Me.txtPathSMT.Size = New System.Drawing.Size(429, 20)
        Me.txtPathSMT.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "File Path"
        '
        'btnBrowseSMT
        '
        Me.btnBrowseSMT.Location = New System.Drawing.Point(444, 26)
        Me.btnBrowseSMT.Name = "btnBrowseSMT"
        Me.btnBrowseSMT.Size = New System.Drawing.Size(45, 23)
        Me.btnBrowseSMT.TabIndex = 2
        Me.btnBrowseSMT.Text = ". . ."
        Me.btnBrowseSMT.UseVisualStyleBackColor = True
        '
        'btnImportSMT
        '
        Me.btnImportSMT.Location = New System.Drawing.Point(418, 67)
        Me.btnImportSMT.Name = "btnImportSMT"
        Me.btnImportSMT.Size = New System.Drawing.Size(71, 23)
        Me.btnImportSMT.TabIndex = 3
        Me.btnImportSMT.Text = "&Import"
        Me.btnImportSMT.UseVisualStyleBackColor = True
        '
        'ofdUploader
        '
        Me.ofdUploader.Filter = "Excel 2003|*.xls|Excel 2007|*.xlsx"
        '
        'frmUploader
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(521, 159)
        Me.Controls.Add(Me.tcUploader)
        Me.Name = "frmUploader"
        Me.Text = "Excel File Uploader"
        Me.tcUploader.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tcUploader As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents btnImportSMT As System.Windows.Forms.Button
    Friend WithEvents btnBrowseSMT As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPathSMT As System.Windows.Forms.TextBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ofdUploader As System.Windows.Forms.OpenFileDialog
End Class
