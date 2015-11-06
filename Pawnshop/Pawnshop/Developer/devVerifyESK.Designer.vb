<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class devVerifyESK
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
        Me.rtbValue = New System.Windows.Forms.RichTextBox()
        Me.txtURL = New System.Windows.Forms.TextBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.btnCheck = New System.Windows.Forms.Button()
        Me.ofdESK = New System.Windows.Forms.OpenFileDialog()
        Me.SuspendLayout()
        '
        'rtbValue
        '
        Me.rtbValue.Location = New System.Drawing.Point(12, 12)
        Me.rtbValue.Name = "rtbValue"
        Me.rtbValue.Size = New System.Drawing.Size(236, 204)
        Me.rtbValue.TabIndex = 0
        Me.rtbValue.Text = ""
        '
        'txtURL
        '
        Me.txtURL.Location = New System.Drawing.Point(12, 232)
        Me.txtURL.Name = "txtURL"
        Me.txtURL.Size = New System.Drawing.Size(195, 20)
        Me.txtURL.TabIndex = 1
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(213, 230)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(35, 23)
        Me.btnBrowse.TabIndex = 0
        Me.btnBrowse.Text = "..."
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'btnCheck
        '
        Me.btnCheck.Location = New System.Drawing.Point(173, 259)
        Me.btnCheck.Name = "btnCheck"
        Me.btnCheck.Size = New System.Drawing.Size(75, 23)
        Me.btnCheck.TabIndex = 1
        Me.btnCheck.Text = "Check"
        Me.btnCheck.UseVisualStyleBackColor = True
        '
        'ofdESK
        '
        Me.ofdESK.FileName = "OpenFileDialog1"
        Me.ofdESK.Filter = "Borrowing File|*.esk"
        '
        'devVerifyESK
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(505, 291)
        Me.Controls.Add(Me.btnCheck)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.txtURL)
        Me.Controls.Add(Me.rtbValue)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "devVerifyESK"
        Me.Text = "devVerifyESK"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rtbValue As System.Windows.Forms.RichTextBox
    Friend WithEvents txtURL As System.Windows.Forms.TextBox
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents btnCheck As System.Windows.Forms.Button
    Friend WithEvents ofdESK As System.Windows.Forms.OpenFileDialog
End Class
