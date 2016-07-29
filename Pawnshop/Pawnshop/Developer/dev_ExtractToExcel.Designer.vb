<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dev_ExtractToExcel
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
        Me.sfdExcel = New System.Windows.Forms.SaveFileDialog()
        Me.SuspendLayout()
        '
        'btnExtract
        '
        Me.btnExtract.Location = New System.Drawing.Point(90, 12)
        Me.btnExtract.Name = "btnExtract"
        Me.btnExtract.Size = New System.Drawing.Size(162, 55)
        Me.btnExtract.TabIndex = 0
        Me.btnExtract.Text = "Extract"
        Me.btnExtract.UseVisualStyleBackColor = True
        '
        'sfdExcel
        '
        Me.sfdExcel.Filter = "Excel 2007|*.xlsx"
        Me.sfdExcel.Title = "Extract"
        '
        'dev_ExtractToExcel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(264, 82)
        Me.Controls.Add(Me.btnExtract)
        Me.Name = "dev_ExtractToExcel"
        Me.Text = "dev_ExtractToExcel"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnExtract As System.Windows.Forms.Button
    Friend WithEvents sfdExcel As System.Windows.Forms.SaveFileDialog
End Class
