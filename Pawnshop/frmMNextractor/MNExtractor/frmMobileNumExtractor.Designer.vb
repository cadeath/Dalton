<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMobileNumExtractor
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
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.lblPath = New System.Windows.Forms.Label()
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.btnExtract = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(367, 13)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(40, 23)
        Me.btnBrowse.TabIndex = 0
        Me.btnBrowse.Text = " . . ."
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'lblPath
        '
        Me.lblPath.AutoSize = True
        Me.lblPath.Location = New System.Drawing.Point(5, 18)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(89, 15)
        Me.lblPath.TabIndex = 1
        Me.lblPath.Text = "Database Path"
        '
        'txtPath
        '
        Me.txtPath.Location = New System.Drawing.Point(98, 14)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(261, 21)
        Me.txtPath.TabIndex = 2
        '
        'btnExtract
        '
        Me.btnExtract.Location = New System.Drawing.Point(327, 42)
        Me.btnExtract.Name = "btnExtract"
        Me.btnExtract.Size = New System.Drawing.Size(80, 23)
        Me.btnExtract.TabIndex = 3
        Me.btnExtract.Text = "&Extract"
        Me.btnExtract.UseVisualStyleBackColor = True
        '
        'frmMobileNumExtractor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ClientSize = New System.Drawing.Size(421, 70)
        Me.Controls.Add(Me.btnExtract)
        Me.Controls.Add(Me.txtPath)
        Me.Controls.Add(Me.lblPath)
        Me.Controls.Add(Me.btnBrowse)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmMobileNumExtractor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mobile Number Extractor"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents lblPath As System.Windows.Forms.Label
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents btnExtract As System.Windows.Forms.Button
End Class
