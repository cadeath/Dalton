<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExtractor2
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
        Me.btnExtract = New System.Windows.Forms.Button()
        Me.MonCalendar = New System.Windows.Forms.MonthCalendar()
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkOld = New System.Windows.Forms.CheckBox()
        Me.pbLoading = New System.Windows.Forms.ProgressBar()
        Me.sfdPath = New System.Windows.Forms.SaveFileDialog()
        Me.cboExtractType = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'btnExtract
        '
        Me.btnExtract.Location = New System.Drawing.Point(12, 298)
        Me.btnExtract.Name = "btnExtract"
        Me.btnExtract.Size = New System.Drawing.Size(75, 41)
        Me.btnExtract.TabIndex = 2
        Me.btnExtract.Text = "Extract"
        Me.btnExtract.UseVisualStyleBackColor = True
        '
        'MonCalendar
        '
        Me.MonCalendar.Location = New System.Drawing.Point(18, 18)
        Me.MonCalendar.MaxSelectionCount = 365
        Me.MonCalendar.Name = "MonCalendar"
        Me.MonCalendar.TabIndex = 3
        '
        'txtPath
        '
        Me.txtPath.BackColor = System.Drawing.Color.White
        Me.txtPath.Location = New System.Drawing.Point(18, 183)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.ReadOnly = True
        Me.txtPath.Size = New System.Drawing.Size(227, 20)
        Me.txtPath.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(15, 206)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(230, 24)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Path (Double Click to change)"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'chkOld
        '
        Me.chkOld.AutoSize = True
        Me.chkOld.Checked = True
        Me.chkOld.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkOld.Enabled = False
        Me.chkOld.Location = New System.Drawing.Point(184, 322)
        Me.chkOld.Name = "chkOld"
        Me.chkOld.Size = New System.Drawing.Size(61, 17)
        Me.chkOld.TabIndex = 6
        Me.chkOld.Text = "Old File"
        Me.chkOld.UseVisualStyleBackColor = True
        '
        'pbLoading
        '
        Me.pbLoading.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pbLoading.Location = New System.Drawing.Point(0, 345)
        Me.pbLoading.Name = "pbLoading"
        Me.pbLoading.Size = New System.Drawing.Size(261, 15)
        Me.pbLoading.TabIndex = 7
        '
        'sfdPath
        '
        Me.sfdPath.DefaultExt = "xls"
        Me.sfdPath.Filter = "Excel File 2003|*.xls"
        '
        'cboExtractType
        '
        Me.cboExtractType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboExtractType.FormattingEnabled = True
        Me.cboExtractType.Location = New System.Drawing.Point(18, 233)
        Me.cboExtractType.Name = "cboExtractType"
        Me.cboExtractType.Size = New System.Drawing.Size(227, 28)
        Me.cboExtractType.TabIndex = 8
        '
        'frmExtractor2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(261, 360)
        Me.Controls.Add(Me.cboExtractType)
        Me.Controls.Add(Me.pbLoading)
        Me.Controls.Add(Me.chkOld)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPath)
        Me.Controls.Add(Me.MonCalendar)
        Me.Controls.Add(Me.btnExtract)
        Me.Name = "frmExtractor2"
        Me.Text = "frmExtractor2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnExtract As System.Windows.Forms.Button
    Friend WithEvents MonCalendar As System.Windows.Forms.MonthCalendar
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkOld As System.Windows.Forms.CheckBox
    Friend WithEvents pbLoading As System.Windows.Forms.ProgressBar
    Friend WithEvents sfdPath As System.Windows.Forms.SaveFileDialog
    Friend WithEvents cboExtractType As System.Windows.Forms.ComboBox
End Class
