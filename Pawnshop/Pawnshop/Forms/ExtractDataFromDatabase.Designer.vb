<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExtractDataFromDatabase
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
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.MonCalendar = New System.Windows.Forms.MonthCalendar()
        Me.sfdPath = New System.Windows.Forms.SaveFileDialog()
        Me.fbdBackup = New System.Windows.Forms.FolderBrowserDialog()
        Me.txtpath1 = New System.Windows.Forms.TextBox()
        Me.rbmonthly = New System.Windows.Forms.RadioButton()
        Me.btnExtract = New System.Windows.Forms.Button()
        Me.rbDaily = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblextracting = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtPath
        '
        Me.txtPath.BackColor = System.Drawing.Color.White
        Me.txtPath.Location = New System.Drawing.Point(12, 38)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.ReadOnly = True
        Me.txtPath.Size = New System.Drawing.Size(222, 20)
        Me.txtPath.TabIndex = 30
        '
        'MonCalendar
        '
        Me.MonCalendar.Location = New System.Drawing.Point(7, 67)
        Me.MonCalendar.MaxSelectionCount = 365
        Me.MonCalendar.Name = "MonCalendar"
        Me.MonCalendar.TabIndex = 25
        '
        'sfdPath
        '
        Me.sfdPath.DefaultExt = "xls"
        Me.sfdPath.Filter = "Excel File 2003|*.xls"
        '
        'fbdBackup
        '
        Me.fbdBackup.SelectedPath = "C:\"
        '
        'txtpath1
        '
        Me.txtpath1.BackColor = System.Drawing.Color.White
        Me.txtpath1.Location = New System.Drawing.Point(12, 12)
        Me.txtpath1.Name = "txtpath1"
        Me.txtpath1.ReadOnly = True
        Me.txtpath1.Size = New System.Drawing.Size(222, 20)
        Me.txtpath1.TabIndex = 32
        '
        'rbmonthly
        '
        Me.rbmonthly.AutoSize = True
        Me.rbmonthly.Location = New System.Drawing.Point(88, 26)
        Me.rbmonthly.Name = "rbmonthly"
        Me.rbmonthly.Size = New System.Drawing.Size(62, 17)
        Me.rbmonthly.TabIndex = 36
        Me.rbmonthly.Text = "Monthly"
        Me.rbmonthly.UseVisualStyleBackColor = True
        '
        'btnExtract
        '
        Me.btnExtract.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExtract.Location = New System.Drawing.Point(25, 69)
        Me.btnExtract.Name = "btnExtract"
        Me.btnExtract.Size = New System.Drawing.Size(120, 26)
        Me.btnExtract.TabIndex = 34
        Me.btnExtract.Text = "Extract"
        Me.btnExtract.UseVisualStyleBackColor = True
        '
        'rbDaily
        '
        Me.rbDaily.AutoSize = True
        Me.rbDaily.Checked = True
        Me.rbDaily.Location = New System.Drawing.Point(25, 26)
        Me.rbDaily.Name = "rbDaily"
        Me.rbDaily.Size = New System.Drawing.Size(48, 17)
        Me.rbDaily.TabIndex = 35
        Me.rbDaily.TabStop = True
        Me.rbDaily.Text = "Daily"
        Me.rbDaily.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbDaily)
        Me.GroupBox1.Controls.Add(Me.btnExtract)
        Me.GroupBox1.Controls.Add(Me.rbmonthly)
        Me.GroupBox1.Location = New System.Drawing.Point(246, 55)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(160, 119)
        Me.GroupBox1.TabIndex = 37
        Me.GroupBox1.TabStop = False
        '
        'lblextracting
        '
        Me.lblextracting.AutoSize = True
        Me.lblextracting.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblextracting.Location = New System.Drawing.Point(246, 198)
        Me.lblextracting.Name = "lblextracting"
        Me.lblextracting.Size = New System.Drawing.Size(49, 16)
        Me.lblextracting.TabIndex = 38
        Me.lblextracting.Text = "Label1"
        '
        'ExtractDataFromDatabase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(417, 249)
        Me.Controls.Add(Me.lblextracting)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtpath1)
        Me.Controls.Add(Me.txtPath)
        Me.Controls.Add(Me.MonCalendar)
        Me.Name = "ExtractDataFromDatabase"
        Me.Text = "Extract Data From Datbase"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents MonCalendar As System.Windows.Forms.MonthCalendar
    Friend WithEvents sfdPath As System.Windows.Forms.SaveFileDialog
    Friend WithEvents fbdBackup As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents txtpath1 As System.Windows.Forms.TextBox
    Friend WithEvents rbmonthly As System.Windows.Forms.RadioButton
    Friend WithEvents btnExtract As System.Windows.Forms.Button
    Friend WithEvents rbDaily As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblextracting As System.Windows.Forms.Label
End Class
