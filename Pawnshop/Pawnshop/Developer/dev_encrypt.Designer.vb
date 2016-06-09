<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dev_encrypt
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
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblENC = New System.Windows.Forms.Label()
        Me.txtSQL = New System.Windows.Forms.TextBox()
        Me.btnHash = New System.Windows.Forms.Button()
        Me.txtHash = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(12, 12)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = "12"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(118, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lblENC
        '
        Me.lblENC.AutoSize = True
        Me.lblENC.Location = New System.Drawing.Point(12, 35)
        Me.lblENC.Name = "lblENC"
        Me.lblENC.Size = New System.Drawing.Size(39, 13)
        Me.lblENC.TabIndex = 2
        Me.lblENC.Text = "Label1"
        '
        'txtSQL
        '
        Me.txtSQL.Location = New System.Drawing.Point(15, 51)
        Me.txtSQL.Name = "txtSQL"
        Me.txtSQL.Size = New System.Drawing.Size(275, 20)
        Me.txtSQL.TabIndex = 3
        '
        'btnHash
        '
        Me.btnHash.Location = New System.Drawing.Point(296, 49)
        Me.btnHash.Name = "btnHash"
        Me.btnHash.Size = New System.Drawing.Size(75, 23)
        Me.btnHash.TabIndex = 4
        Me.btnHash.Text = "HASH"
        Me.btnHash.UseVisualStyleBackColor = True
        '
        'txtHash
        '
        Me.txtHash.Location = New System.Drawing.Point(15, 77)
        Me.txtHash.Multiline = True
        Me.txtHash.Name = "txtHash"
        Me.txtHash.Size = New System.Drawing.Size(356, 132)
        Me.txtHash.TabIndex = 5
        '
        'dev_encrypt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 220)
        Me.Controls.Add(Me.txtHash)
        Me.Controls.Add(Me.btnHash)
        Me.Controls.Add(Me.txtSQL)
        Me.Controls.Add(Me.lblENC)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "dev_encrypt"
        Me.Text = "dev_encrypt"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblENC As System.Windows.Forms.Label
    Friend WithEvents txtSQL As System.Windows.Forms.TextBox
    Friend WithEvents btnHash As System.Windows.Forms.Button
    Friend WithEvents txtHash As System.Windows.Forms.TextBox
End Class
