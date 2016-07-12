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
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.txtRef = New System.Windows.Forms.TextBox()
        Me.txtDate = New System.Windows.Forms.TextBox()
        Me.txtAmnt = New System.Windows.Forms.TextBox()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
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
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(254, 38)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(100, 20)
        Me.txtCode.TabIndex = 2
        Me.txtCode.Text = "ROX"
        '
        'txtRef
        '
        Me.txtRef.Location = New System.Drawing.Point(254, 12)
        Me.txtRef.Name = "txtRef"
        Me.txtRef.Size = New System.Drawing.Size(100, 20)
        Me.txtRef.TabIndex = 3
        Me.txtRef.Text = "ROG00012"
        '
        'txtDate
        '
        Me.txtDate.Location = New System.Drawing.Point(254, 64)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.Size = New System.Drawing.Size(100, 20)
        Me.txtDate.TabIndex = 4
        Me.txtDate.Text = "11/6/2015"
        '
        'txtAmnt
        '
        Me.txtAmnt.Location = New System.Drawing.Point(254, 90)
        Me.txtAmnt.Name = "txtAmnt"
        Me.txtAmnt.Size = New System.Drawing.Size(100, 20)
        Me.txtAmnt.TabIndex = 5
        Me.txtAmnt.Text = "2000"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(254, 116)
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(100, 20)
        Me.txtRemarks.TabIndex = 6
        Me.txtRemarks.Text = "SAMPLE GENERATE KEY"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(254, 142)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'devVerifyESK
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(505, 291)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.txtAmnt)
        Me.Controls.Add(Me.txtDate)
        Me.Controls.Add(Me.txtRef)
        Me.Controls.Add(Me.txtCode)
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
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents txtRef As System.Windows.Forms.TextBox
    Friend WithEvents txtDate As System.Windows.Forms.TextBox
    Friend WithEvents txtAmnt As System.Windows.Forms.TextBox
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
