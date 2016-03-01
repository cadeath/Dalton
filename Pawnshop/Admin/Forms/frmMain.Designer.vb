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
        Me.dgvPawnshop = New System.Windows.Forms.DataGridView()
        Me.btnCharges = New System.Windows.Forms.Button()
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsbtnSave = New System.Windows.Forms.ToolStripButton()
        Me.tsbtnExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnConfig = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.btnBranch = New System.Windows.Forms.Button()
        Me.sfdConfig = New System.Windows.Forms.SaveFileDialog()
        Me.ofdConfig = New System.Windows.Forms.OpenFileDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        CType(Me.dgvPawnshop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvPawnshop
        '
        Me.dgvPawnshop.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPawnshop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPawnshop.Location = New System.Drawing.Point(128, 28)
        Me.dgvPawnshop.Name = "dgvPawnshop"
        Me.dgvPawnshop.Size = New System.Drawing.Size(679, 377)
        Me.dgvPawnshop.TabIndex = 0
        '
        'btnCharges
        '
        Me.btnCharges.Location = New System.Drawing.Point(12, 28)
        Me.btnCharges.Name = "btnCharges"
        Me.btnCharges.Size = New System.Drawing.Size(110, 51)
        Me.btnCharges.TabIndex = 1
        Me.btnCharges.Text = "Money Transfer"
        Me.btnCharges.UseVisualStyleBackColor = True
        '
        'tsMenu
        '
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbtnSave, Me.tsbtnExport, Me.ToolStripSeparator1, Me.tsbtnConfig, Me.ToolStripButton1})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(819, 25)
        Me.tsMenu.TabIndex = 2
        Me.tsMenu.Text = "ToolStrip1"
        '
        'tsbtnSave
        '
        Me.tsbtnSave.Image = CType(resources.GetObject("tsbtnSave.Image"), System.Drawing.Image)
        Me.tsbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnSave.Name = "tsbtnSave"
        Me.tsbtnSave.Size = New System.Drawing.Size(51, 22)
        Me.tsbtnSave.Text = "&Save"
        '
        'tsbtnExport
        '
        Me.tsbtnExport.Image = CType(resources.GetObject("tsbtnExport.Image"), System.Drawing.Image)
        Me.tsbtnExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnExport.Name = "tsbtnExport"
        Me.tsbtnExport.Size = New System.Drawing.Size(60, 22)
        Me.tsbtnExport.Text = "&Export"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsbtnConfig
        '
        Me.tsbtnConfig.Image = CType(resources.GetObject("tsbtnConfig.Image"), System.Drawing.Image)
        Me.tsbtnConfig.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnConfig.Name = "tsbtnConfig"
        Me.tsbtnConfig.Size = New System.Drawing.Size(109, 22)
        Me.tsbtnConfig.Text = "Config Checker"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        '
        'btnBranch
        '
        Me.btnBranch.Location = New System.Drawing.Point(12, 85)
        Me.btnBranch.Name = "btnBranch"
        Me.btnBranch.Size = New System.Drawing.Size(110, 51)
        Me.btnBranch.TabIndex = 3
        Me.btnBranch.Text = "Branch"
        Me.btnBranch.UseVisualStyleBackColor = True
        '
        'sfdConfig
        '
        Me.sfdConfig.Filter = "System Update|*.cir"
        '
        'ofdConfig
        '
        Me.ofdConfig.FileName = "sytem"
        Me.ofdConfig.Filter = "System Update|*.cir"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "sytem"
        Me.OpenFileDialog1.Filter = "System Update|*.cir"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(819, 417)
        Me.Controls.Add(Me.btnBranch)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.btnCharges)
        Me.Controls.Add(Me.dgvPawnshop)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.Text = "Main"
        CType(Me.dgvPawnshop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvPawnshop As System.Windows.Forms.DataGridView
    Friend WithEvents btnCharges As System.Windows.Forms.Button
    Friend WithEvents tsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbtnExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnBranch As System.Windows.Forms.Button
    Friend WithEvents sfdConfig As System.Windows.Forms.SaveFileDialog
    Friend WithEvents tsbtnConfig As System.Windows.Forms.ToolStripButton
    Friend WithEvents ofdConfig As System.Windows.Forms.OpenFileDialog
    Friend WithEvents tsbtnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog

End Class
