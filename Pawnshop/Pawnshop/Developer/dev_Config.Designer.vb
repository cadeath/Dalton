<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dev_Config
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
        Me.sfdCIR = New System.Windows.Forms.SaveFileDialog()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.ofdCIR = New System.Windows.Forms.OpenFileDialog()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'sfdCIR
        '
        Me.sfdCIR.Filter = "CIR File|*.cir"
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(12, 12)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(75, 36)
        Me.btnExport.TabIndex = 0
        Me.btnExport.Text = "&Export"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'ofdCIR
        '
        Me.ofdCIR.Filter = "CIR File|*.cir"
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(12, 54)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(75, 36)
        Me.btnLoad.TabIndex = 1
        Me.btnLoad.Text = "&Load"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'dev_Config
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(444, 188)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.btnExport)
        Me.Name = "dev_Config"
        Me.Text = "dev_Config"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents sfdCIR As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents ofdCIR As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnLoad As System.Windows.Forms.Button
End Class
