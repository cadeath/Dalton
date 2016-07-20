<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Extract_tableTo_excel
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
        Me.btnPawnExtract = New System.Windows.Forms.Button()
        Me.pbLoading = New System.Windows.Forms.ProgressBar()
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.sfdPath = New System.Windows.Forms.SaveFileDialog()
        Me.MonCalendar = New System.Windows.Forms.MonthCalendar()
        Me.btnDollarExtract = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnPawnExtract
        '
        Me.btnPawnExtract.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPawnExtract.Location = New System.Drawing.Point(12, 12)
        Me.btnPawnExtract.Name = "btnPawnExtract"
        Me.btnPawnExtract.Size = New System.Drawing.Size(110, 29)
        Me.btnPawnExtract.TabIndex = 0
        Me.btnPawnExtract.Text = "Extract Pawn"
        Me.btnPawnExtract.UseVisualStyleBackColor = True
        '
        'pbLoading
        '
        Me.pbLoading.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pbLoading.Location = New System.Drawing.Point(0, 227)
        Me.pbLoading.Name = "pbLoading"
        Me.pbLoading.Size = New System.Drawing.Size(370, 23)
        Me.pbLoading.TabIndex = 5
        '
        'txtPath
        '
        Me.txtPath.BackColor = System.Drawing.Color.White
        Me.txtPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPath.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.txtPath.Location = New System.Drawing.Point(134, 200)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.ReadOnly = True
        Me.txtPath.Size = New System.Drawing.Size(227, 21)
        Me.txtPath.TabIndex = 6
        Me.txtPath.Text = "Path Here . . ."
        '
        'sfdPath
        '
        Me.sfdPath.DefaultExt = "xls"
        Me.sfdPath.Filter = "Excel File 2003|*.xls"
        '
        'MonCalendar
        '
        Me.MonCalendar.Location = New System.Drawing.Point(134, 12)
        Me.MonCalendar.MaxSelectionCount = 365
        Me.MonCalendar.Name = "MonCalendar"
        Me.MonCalendar.TabIndex = 7
        '
        'btnDollarExtract
        '
        Me.btnDollarExtract.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDollarExtract.Location = New System.Drawing.Point(12, 43)
        Me.btnDollarExtract.Name = "btnDollarExtract"
        Me.btnDollarExtract.Size = New System.Drawing.Size(110, 29)
        Me.btnDollarExtract.TabIndex = 8
        Me.btnDollarExtract.Text = "Extract Dollar"
        Me.btnDollarExtract.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(12, 73)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(110, 45)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "Extract Borrowings"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(12, 122)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(110, 52)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "Extract Insurance"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(12, 177)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(110, 40)
        Me.Button3.TabIndex = 11
        Me.Button3.Text = "Extract Remitance"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Extract_tableTo_excel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(370, 250)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnDollarExtract)
        Me.Controls.Add(Me.MonCalendar)
        Me.Controls.Add(Me.txtPath)
        Me.Controls.Add(Me.pbLoading)
        Me.Controls.Add(Me.btnPawnExtract)
        Me.Name = "Extract_tableTo_excel"
        Me.Text = "Extract To excel"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnPawnExtract As System.Windows.Forms.Button
    Friend WithEvents pbLoading As System.Windows.Forms.ProgressBar
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents sfdPath As System.Windows.Forms.SaveFileDialog
    Friend WithEvents MonCalendar As System.Windows.Forms.MonthCalendar
    Friend WithEvents btnDollarExtract As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
