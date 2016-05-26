<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExtractDollarMonthlyDaily
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
        Me.MonCalendar = New System.Windows.Forms.MonthCalendar()
        Me.btnextract = New System.Windows.Forms.Button()
        Me.txtpath = New System.Windows.Forms.TextBox()
        Me.savepath = New System.Windows.Forms.SaveFileDialog()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.cboMonthlyDaily = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'MonCalendar
        '
        Me.MonCalendar.Location = New System.Drawing.Point(29, 18)
        Me.MonCalendar.Name = "MonCalendar"
        Me.MonCalendar.TabIndex = 0
        '
        'btnextract
        '
        Me.btnextract.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnextract.Location = New System.Drawing.Point(94, 241)
        Me.btnextract.Name = "btnextract"
        Me.btnextract.Size = New System.Drawing.Size(89, 27)
        Me.btnextract.TabIndex = 1
        Me.btnextract.Text = "Extract"
        Me.btnextract.UseVisualStyleBackColor = True
        '
        'txtpath
        '
        Me.txtpath.Location = New System.Drawing.Point(29, 188)
        Me.txtpath.Name = "txtpath"
        Me.txtpath.Size = New System.Drawing.Size(227, 20)
        Me.txtpath.TabIndex = 2
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(0, 274)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(283, 18)
        Me.ProgressBar1.TabIndex = 3
        '
        'cboMonthlyDaily
        '
        Me.cboMonthlyDaily.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMonthlyDaily.FormattingEnabled = True
        Me.cboMonthlyDaily.Items.AddRange(New Object() {"Daily", "Monthly"})
        Me.cboMonthlyDaily.Location = New System.Drawing.Point(29, 214)
        Me.cboMonthlyDaily.Name = "cboMonthlyDaily"
        Me.cboMonthlyDaily.Size = New System.Drawing.Size(227, 21)
        Me.cboMonthlyDaily.TabIndex = 4
        '
        'frmExtractDollarMonthlyDaily
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 293)
        Me.Controls.Add(Me.cboMonthlyDaily)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.txtpath)
        Me.Controls.Add(Me.btnextract)
        Me.Controls.Add(Me.MonCalendar)
        Me.Name = "frmExtractDollarMonthlyDaily"
        Me.Text = "Dollar Transaction"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MonCalendar As System.Windows.Forms.MonthCalendar
    Friend WithEvents btnextract As System.Windows.Forms.Button
    Friend WithEvents txtpath As System.Windows.Forms.TextBox
    Friend WithEvents savepath As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents cboMonthlyDaily As System.Windows.Forms.ComboBox
End Class
