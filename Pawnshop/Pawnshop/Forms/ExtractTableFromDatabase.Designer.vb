<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExtractTableFromDatabase
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
        Me.btnRemitanceExtract = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnDollarExtract = New System.Windows.Forms.Button()
        Me.MonCalendar = New System.Windows.Forms.MonthCalendar()
        Me.pbLoading = New System.Windows.Forms.ProgressBar()
        Me.btnPawnExtract = New System.Windows.Forms.Button()
        Me.sfdPath = New System.Windows.Forms.SaveFileDialog()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(129, 193)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(230, 24)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Path (Double Click to change)"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtPath
        '
        Me.txtPath.BackColor = System.Drawing.Color.White
        Me.txtPath.Location = New System.Drawing.Point(132, 170)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.ReadOnly = True
        Me.txtPath.Size = New System.Drawing.Size(224, 20)
        Me.txtPath.TabIndex = 21
        '
        'btnRemitanceExtract
        '
        Me.btnRemitanceExtract.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemitanceExtract.Location = New System.Drawing.Point(7, 170)
        Me.btnRemitanceExtract.Name = "btnRemitanceExtract"
        Me.btnRemitanceExtract.Size = New System.Drawing.Size(110, 40)
        Me.btnRemitanceExtract.TabIndex = 20
        Me.btnRemitanceExtract.Text = "Extract Remitance"
        Me.btnRemitanceExtract.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(7, 115)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(110, 52)
        Me.Button2.TabIndex = 19
        Me.Button2.Text = "Extract Insurance"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(7, 66)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(110, 45)
        Me.Button1.TabIndex = 18
        Me.Button1.Text = "Extract Borrowings"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnDollarExtract
        '
        Me.btnDollarExtract.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDollarExtract.Location = New System.Drawing.Point(7, 36)
        Me.btnDollarExtract.Name = "btnDollarExtract"
        Me.btnDollarExtract.Size = New System.Drawing.Size(110, 29)
        Me.btnDollarExtract.TabIndex = 17
        Me.btnDollarExtract.Text = "Extract Dollar"
        Me.btnDollarExtract.UseVisualStyleBackColor = True
        '
        'MonCalendar
        '
        Me.MonCalendar.Location = New System.Drawing.Point(129, 5)
        Me.MonCalendar.MaxSelectionCount = 365
        Me.MonCalendar.Name = "MonCalendar"
        Me.MonCalendar.TabIndex = 16
        '
        'pbLoading
        '
        Me.pbLoading.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pbLoading.Location = New System.Drawing.Point(0, 239)
        Me.pbLoading.Name = "pbLoading"
        Me.pbLoading.Size = New System.Drawing.Size(361, 23)
        Me.pbLoading.TabIndex = 15
        '
        'btnPawnExtract
        '
        Me.btnPawnExtract.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPawnExtract.Location = New System.Drawing.Point(7, 5)
        Me.btnPawnExtract.Name = "btnPawnExtract"
        Me.btnPawnExtract.Size = New System.Drawing.Size(110, 29)
        Me.btnPawnExtract.TabIndex = 14
        Me.btnPawnExtract.Text = "Extract Pawn"
        Me.btnPawnExtract.UseVisualStyleBackColor = True
        '
        'sfdPath
        '
        Me.sfdPath.DefaultExt = "xls"
        Me.sfdPath.Filter = "Excel File 2003|*.xls"
        '
        'ExtractTableInDatabase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(361, 262)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPath)
        Me.Controls.Add(Me.btnRemitanceExtract)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnDollarExtract)
        Me.Controls.Add(Me.MonCalendar)
        Me.Controls.Add(Me.pbLoading)
        Me.Controls.Add(Me.btnPawnExtract)
        Me.Name = "ExtractTableInDatabase"
        Me.Text = "Extract Table From Database"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents btnRemitanceExtract As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnDollarExtract As System.Windows.Forms.Button
    Friend WithEvents MonCalendar As System.Windows.Forms.MonthCalendar
    Friend WithEvents pbLoading As System.Windows.Forms.ProgressBar
    Friend WithEvents btnPawnExtract As System.Windows.Forms.Button
    Friend WithEvents sfdPath As System.Windows.Forms.SaveFileDialog
End Class
