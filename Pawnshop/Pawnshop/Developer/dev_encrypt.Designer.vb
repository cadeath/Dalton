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
        Me.btnHash = New System.Windows.Forms.Button()
        Me.lblHash = New System.Windows.Forms.Label()
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
        'btnHash
        '
        Me.btnHash.Location = New System.Drawing.Point(12, 61)
        Me.btnHash.Name = "btnHash"
        Me.btnHash.Size = New System.Drawing.Size(94, 48)
        Me.btnHash.TabIndex = 3
        Me.btnHash.Text = "TABLE HASH"
        Me.btnHash.UseVisualStyleBackColor = True
        '
        'lblHash
        '
        Me.lblHash.AutoSize = True
        Me.lblHash.Location = New System.Drawing.Point(9, 112)
        Me.lblHash.Name = "lblHash"
        Me.lblHash.Size = New System.Drawing.Size(24, 13)
        Me.lblHash.TabIndex = 4
        Me.lblHash.Text = "Idle"
        '
        'dev_encrypt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(219, 138)
        Me.Controls.Add(Me.lblHash)
        Me.Controls.Add(Me.btnHash)
        Me.Controls.Add(Me.lblENC)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox1)
        Me.Name = "dev_encrypt"
        Me.Text = "dev_encrypt"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblENC As System.Windows.Forms.Label
    Friend WithEvents btnHash As System.Windows.Forms.Button
    Friend WithEvents lblHash As System.Windows.Forms.Label
End Class
