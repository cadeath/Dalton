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
        Me.rtbNote = New System.Windows.Forms.RichTextBox()
        Me.pb_load = New System.Windows.Forms.ProgressBar()
        Me.btnPatch = New System.Windows.Forms.Button()
        Me.lblText = New System.Windows.Forms.Label()
        Me.ofdDBName = New System.Windows.Forms.OpenFileDialog()
        Me.SuspendLayout()
        '
        'rtbNote
        '
        Me.rtbNote.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbNote.BackColor = System.Drawing.Color.White
        Me.rtbNote.Location = New System.Drawing.Point(12, 12)
        Me.rtbNote.Name = "rtbNote"
        Me.rtbNote.ReadOnly = True
        Me.rtbNote.Size = New System.Drawing.Size(249, 284)
        Me.rtbNote.TabIndex = 0
        Me.rtbNote.Text = ""
        '
        'pb_load
        '
        Me.pb_load.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pb_load.Location = New System.Drawing.Point(0, 361)
        Me.pb_load.Name = "pb_load"
        Me.pb_load.Size = New System.Drawing.Size(273, 15)
        Me.pb_load.TabIndex = 1
        '
        'btnPatch
        '
        Me.btnPatch.Location = New System.Drawing.Point(7, 302)
        Me.btnPatch.Name = "btnPatch"
        Me.btnPatch.Size = New System.Drawing.Size(90, 35)
        Me.btnPatch.TabIndex = 0
        Me.btnPatch.Text = "Patch"
        Me.btnPatch.UseVisualStyleBackColor = True
        '
        'lblText
        '
        Me.lblText.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblText.AutoSize = True
        Me.lblText.Location = New System.Drawing.Point(4, 343)
        Me.lblText.Name = "lblText"
        Me.lblText.Size = New System.Drawing.Size(31, 13)
        Me.lblText.TabIndex = 0
        Me.lblText.Text = "IDLE"
        '
        'ofdDBName
        '
        Me.ofdDBName.Filter = "FDB|*.FDB"
        '
        'frmMain
        '
        Me.AcceptButton = Me.btnPatch
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(273, 376)
        Me.Controls.Add(Me.lblText)
        Me.Controls.Add(Me.btnPatch)
        Me.Controls.Add(Me.pb_load)
        Me.Controls.Add(Me.rtbNote)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Patcher"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rtbNote As System.Windows.Forms.RichTextBox
    Friend WithEvents pb_load As System.Windows.Forms.ProgressBar
    Friend WithEvents btnPatch As System.Windows.Forms.Button
    Friend WithEvents lblText As System.Windows.Forms.Label
    Friend WithEvents ofdDBName As System.Windows.Forms.OpenFileDialog

End Class
