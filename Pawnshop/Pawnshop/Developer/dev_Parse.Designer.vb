<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dev_Parse
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
        Me.txtParse = New System.Windows.Forms.TextBox()
        Me.btnParse = New System.Windows.Forms.Button()
        Me.lvParse = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'txtParse
        '
        Me.txtParse.Location = New System.Drawing.Point(12, 12)
        Me.txtParse.Multiline = True
        Me.txtParse.Name = "txtParse"
        Me.txtParse.Size = New System.Drawing.Size(597, 78)
        Me.txtParse.TabIndex = 0
        '
        'btnParse
        '
        Me.btnParse.Location = New System.Drawing.Point(629, 12)
        Me.btnParse.Name = "btnParse"
        Me.btnParse.Size = New System.Drawing.Size(75, 23)
        Me.btnParse.TabIndex = 1
        Me.btnParse.Text = "P&arse"
        Me.btnParse.UseVisualStyleBackColor = True
        '
        'lvParse
        '
        Me.lvParse.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.lvParse.GridLines = True
        Me.lvParse.Location = New System.Drawing.Point(12, 96)
        Me.lvParse.Name = "lvParse"
        Me.lvParse.Size = New System.Drawing.Size(597, 154)
        Me.lvParse.TabIndex = 2
        Me.lvParse.UseCompatibleStateImageBehavior = False
        Me.lvParse.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Key"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Value"
        Me.ColumnHeader2.Width = 123
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Complete Message"
        Me.ColumnHeader3.Width = 407
        '
        'dev_Parse
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(717, 262)
        Me.Controls.Add(Me.lvParse)
        Me.Controls.Add(Me.btnParse)
        Me.Controls.Add(Me.txtParse)
        Me.Name = "dev_Parse"
        Me.Text = "dev_Parse"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtParse As System.Windows.Forms.TextBox
    Friend WithEvents btnParse As System.Windows.Forms.Button
    Friend WithEvents lvParse As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
End Class
