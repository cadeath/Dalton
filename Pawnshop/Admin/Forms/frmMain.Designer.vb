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
        Me.tsbtnCashInOut = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbtnExit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsbtnCashInOut
        '
        Me.tsbtnCashInOut.Image = CType(resources.GetObject("tsbtnCashInOut.Image"), System.Drawing.Image)
        Me.tsbtnCashInOut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbtnCashInOut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnCashInOut.Name = "tsbtnCashInOut"
        Me.tsbtnCashInOut.Size = New System.Drawing.Size(72, 83)
        Me.tsbtnCashInOut.Text = "CashIn/Out"
        Me.tsbtnCashInOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 86)
        '
        'tsbtnExport
        '
        Me.tsbtnExport.Image = CType(resources.GetObject("tsbtnExport.Image"), System.Drawing.Image)
        Me.tsbtnExport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbtnExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnExport.Name = "tsbtnExport"
        Me.tsbtnExport.Size = New System.Drawing.Size(83, 83)
        Me.tsbtnExport.Text = "Export Config"
        Me.tsbtnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbtnCashInOut, Me.ToolStripSeparator1, Me.tsbtnExport, Me.tsbtnExit})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(675, 86)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbtnExit
        '
        Me.tsbtnExit.Image = CType(resources.GetObject("tsbtnExit.Image"), System.Drawing.Image)
        Me.tsbtnExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbtnExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnExit.Name = "tsbtnExit"
        Me.tsbtnExit.Size = New System.Drawing.Size(68, 83)
        Me.tsbtnExit.Text = "E&xit"
        Me.tsbtnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(675, 372)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Main"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsbtnCashInOut As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtnExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbtnExit As System.Windows.Forms.ToolStripButton

End Class
