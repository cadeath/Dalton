<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dev_FileLoader
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
        Me.ofdPTU = New System.Windows.Forms.OpenFileDialog()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ofdPTU
        '
        Me.ofdPTU.Filter = "PTU File|*.ptu"
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(12, 12)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(78, 41)
        Me.btnLoad.TabIndex = 0
        Me.btnLoad.Text = "Load"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'dev_FileLoader
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(365, 149)
        Me.Controls.Add(Me.btnLoad)
        Me.Name = "dev_FileLoader"
        Me.Text = "File Loader"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofdPTU As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnLoad As System.Windows.Forms.Button
End Class
