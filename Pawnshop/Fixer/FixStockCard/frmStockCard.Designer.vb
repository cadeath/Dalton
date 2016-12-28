<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStockCard
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnFix = New System.Windows.Forms.Button()
        Me.txtData = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnFix)
        Me.GroupBox1.Controls.Add(Me.txtData)
        Me.GroupBox1.Location = New System.Drawing.Point(1, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(302, 70)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Database"
        '
        'btnFix
        '
        Me.btnFix.Location = New System.Drawing.Point(221, 41)
        Me.btnFix.Name = "btnFix"
        Me.btnFix.Size = New System.Drawing.Size(75, 23)
        Me.btnFix.TabIndex = 0
        Me.btnFix.Text = "Fix"
        Me.btnFix.UseVisualStyleBackColor = True
        '
        'txtData
        '
        Me.txtData.Location = New System.Drawing.Point(6, 15)
        Me.txtData.Name = "txtData"
        Me.txtData.ReadOnly = True
        Me.txtData.Size = New System.Drawing.Size(290, 20)
        Me.txtData.TabIndex = 1
        '
        'frmStockCard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(306, 76)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmStockCard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fix Stock Card"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnFix As System.Windows.Forms.Button
    Friend WithEvents txtData As System.Windows.Forms.TextBox
End Class
