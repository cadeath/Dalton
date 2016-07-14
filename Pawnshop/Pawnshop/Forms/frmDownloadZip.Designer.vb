<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDownloadZip
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
        Me.components = New System.ComponentModel.Container()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.folderDlg = New System.Windows.Forms.FolderBrowserDialog()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.btnExecuteBatch = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.SuspendLayout()
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(12, 55)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(150, 28)
        Me.Button4.TabIndex = 9
        Me.Button4.Text = "Extract"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 7)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(150, 31)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Download"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(-2, 95)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(189, 23)
        Me.ProgressBar1.TabIndex = 12
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(12, 128)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(150, 23)
        Me.btnSave.TabIndex = 13
        Me.btnSave.Text = "Create Batch File"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(12, 269)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(150, 45)
        Me.RichTextBox1.TabIndex = 14
        Me.RichTextBox1.Text = ""
        '
        'btnExecuteBatch
        '
        Me.btnExecuteBatch.Location = New System.Drawing.Point(12, 157)
        Me.btnExecuteBatch.Name = "btnExecuteBatch"
        Me.btnExecuteBatch.Size = New System.Drawing.Size(150, 23)
        Me.btnExecuteBatch.TabIndex = 15
        Me.btnExecuteBatch.Text = "Execute"
        Me.btnExecuteBatch.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(12, 186)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(175, 23)
        Me.Button2.TabIndex = 16
        Me.Button2.Text = "Check if System is Running"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'frmDownloadZip
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(571, 331)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnExecuteBatch)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button4)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmDownloadZip"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Download Zip"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents folderDlg As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents btnExecuteBatch As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
End Class
