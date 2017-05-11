<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.btnStart = New System.Windows.Forms.Button()
        Me.pbUpdate = New System.Windows.Forms.ProgressBar()
        Me.lblUpdate = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnStart
        '
        Me.btnStart.BackColor = System.Drawing.Color.Tomato
        Me.btnStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStart.ForeColor = System.Drawing.Color.White
        Me.btnStart.Location = New System.Drawing.Point(12, 389)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(78, 44)
        Me.btnStart.TabIndex = 0
        Me.btnStart.Text = "&START"
        Me.btnStart.UseVisualStyleBackColor = False
        '
        'pbUpdate
        '
        Me.pbUpdate.Location = New System.Drawing.Point(12, 436)
        Me.pbUpdate.Name = "pbUpdate"
        Me.pbUpdate.Size = New System.Drawing.Size(775, 12)
        Me.pbUpdate.TabIndex = 1
        '
        'lblUpdate
        '
        Me.lblUpdate.BackColor = System.Drawing.Color.Transparent
        Me.lblUpdate.ForeColor = System.Drawing.Color.DeepSkyBlue
        Me.lblUpdate.Location = New System.Drawing.Point(469, 416)
        Me.lblUpdate.Name = "lblUpdate"
        Me.lblUpdate.Size = New System.Drawing.Size(318, 17)
        Me.lblUpdate.TabIndex = 2
        Me.lblUpdate.Text = "IDLE"
        Me.lblUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(800, 460)
        Me.Controls.Add(Me.lblUpdate)
        Me.Controls.Add(Me.pbUpdate)
        Me.Controls.Add(Me.btnStart)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dalton Integrated System"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents pbUpdate As System.Windows.Forms.ProgressBar
    Friend WithEvents lblUpdate As System.Windows.Forms.Label

End Class
