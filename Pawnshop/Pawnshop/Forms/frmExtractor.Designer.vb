<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExtractor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExtractor))
        Me.MonCalendar = New System.Windows.Forms.MonthCalendar()
        Me.btnExtract = New System.Windows.Forms.Button()
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pbLoading = New System.Windows.Forms.ProgressBar()
        Me.chkOld = New System.Windows.Forms.CheckBox()
        Me.sfdPath = New System.Windows.Forms.SaveFileDialog()
        Me.cboType = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'MonCalendar
        '
        Me.MonCalendar.Location = New System.Drawing.Point(21, 18)
        Me.MonCalendar.MaxSelectionCount = 365
        Me.MonCalendar.Name = "MonCalendar"
        Me.MonCalendar.TabIndex = 0
        '
        'btnExtract
        '
        Me.btnExtract.Location = New System.Drawing.Point(18, 285)
        Me.btnExtract.Name = "btnExtract"
        Me.btnExtract.Size = New System.Drawing.Size(75, 41)
        Me.btnExtract.TabIndex = 1
        Me.btnExtract.Text = "Extract"
        Me.btnExtract.UseVisualStyleBackColor = True
        '
        'txtPath
        '
        Me.txtPath.BackColor = System.Drawing.Color.White
        Me.txtPath.Location = New System.Drawing.Point(21, 192)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.ReadOnly = True
        Me.txtPath.Size = New System.Drawing.Size(224, 20)
        Me.txtPath.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(15, 215)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(230, 24)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Path (Double Click to change)"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pbLoading
        '
        Me.pbLoading.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pbLoading.Location = New System.Drawing.Point(0, 335)
        Me.pbLoading.Name = "pbLoading"
        Me.pbLoading.Size = New System.Drawing.Size(271, 15)
        Me.pbLoading.TabIndex = 4
        '
        'chkOld
        '
        Me.chkOld.AutoSize = True
        Me.chkOld.Checked = True
        Me.chkOld.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkOld.Enabled = False
        Me.chkOld.Location = New System.Drawing.Point(187, 309)
        Me.chkOld.Name = "chkOld"
        Me.chkOld.Size = New System.Drawing.Size(61, 17)
        Me.chkOld.TabIndex = 5
        Me.chkOld.Text = "Old File"
        Me.chkOld.UseVisualStyleBackColor = True
        '
        'sfdPath
        '
        Me.sfdPath.DefaultExt = "xls"
        Me.sfdPath.Filter = "Excel File 2003|*.xls"
        '
        'cboType
        '
        Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType.FormattingEnabled = True
        Me.cboType.Items.AddRange(New Object() {"Previous Data", "Latest Data", "All Data"})
        Me.cboType.Location = New System.Drawing.Point(21, 242)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(224, 21)
        Me.cboType.TabIndex = 6
        '
        'frmExtractor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(271, 350)
        Me.Controls.Add(Me.cboType)
        Me.Controls.Add(Me.chkOld)
        Me.Controls.Add(Me.pbLoading)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPath)
        Me.Controls.Add(Me.btnExtract)
        Me.Controls.Add(Me.MonCalendar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmExtractor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Extractor"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MonCalendar As System.Windows.Forms.MonthCalendar
    Friend WithEvents btnExtract As System.Windows.Forms.Button
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pbLoading As System.Windows.Forms.ProgressBar
    Friend WithEvents chkOld As System.Windows.Forms.CheckBox
    Friend WithEvents sfdPath As System.Windows.Forms.SaveFileDialog
    Friend WithEvents cboType As System.Windows.Forms.ComboBox
End Class
