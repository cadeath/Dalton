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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.MonCalendar = New System.Windows.Forms.MonthCalendar()
        Me.sfdPath = New System.Windows.Forms.SaveFileDialog()
        Me.fbdBackup = New System.Windows.Forms.FolderBrowserDialog()
        Me.txtpath1 = New System.Windows.Forms.TextBox()
        Me.btnExtract = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(37, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(152, 24)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Path (DoubleClick to change)"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtPath
        '
        Me.txtPath.BackColor = System.Drawing.Color.White
        Me.txtPath.Location = New System.Drawing.Point(10, 51)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.ReadOnly = True
        Me.txtPath.Size = New System.Drawing.Size(207, 20)
        Me.txtPath.TabIndex = 30
        '
        'MonCalendar
        '
        Me.MonCalendar.Location = New System.Drawing.Point(7, 11)
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
        Me.txtpath1.Location = New System.Drawing.Point(10, 24)
        Me.txtpath1.Name = "txtpath1"
        Me.txtpath1.ReadOnly = True
        Me.txtpath1.Size = New System.Drawing.Size(207, 20)
        Me.txtpath1.TabIndex = 32
        '
        'btnExtract
        '
        Me.btnExtract.Location = New System.Drawing.Point(57, 91)
        Me.btnExtract.Name = "btnExtract"
        Me.btnExtract.Size = New System.Drawing.Size(121, 23)
        Me.btnExtract.TabIndex = 34
        Me.btnExtract.Text = "Extract"
        Me.btnExtract.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtpath1)
        Me.GroupBox1.Controls.Add(Me.btnExtract)
        Me.GroupBox1.Controls.Add(Me.txtPath)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 182)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(227, 122)
        Me.GroupBox1.TabIndex = 35
        Me.GroupBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(34, 178)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 36
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ExtractDataFromDatabase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(246, 339)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MonCalendar)
        Me.Name = "ExtractDataFromDatabase"
        Me.Text = "Extract Data From Datbase"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents MonCalendar As System.Windows.Forms.MonthCalendar
    Friend WithEvents sfdPath As System.Windows.Forms.SaveFileDialog
    Friend WithEvents fbdBackup As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents txtpath1 As System.Windows.Forms.TextBox
    Friend WithEvents btnExtract As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
