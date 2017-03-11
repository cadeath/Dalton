<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDatabseExtractor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDatabseExtractor))
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnExtract = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LVQuery = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtQuery = New Extract_All_Database.watermark()
        Me.LV_DBList = New System.Windows.Forms.ListView()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FBD = New System.Windows.Forms.FolderBrowserDialog()
        Me.SFD = New System.Windows.Forms.SaveFileDialog()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.ToolCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtSource = New Extract_All_Database.watermark()
        Me.GroupBox1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(557, 14)
        Me.btnBrowse.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(40, 30)
        Me.btnBrowse.TabIndex = 0
        Me.btnBrowse.Text = ". . ."
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Browse"
        '
        'btnExtract
        '
        Me.btnExtract.Location = New System.Drawing.Point(472, 366)
        Me.btnExtract.Name = "btnExtract"
        Me.btnExtract.Size = New System.Drawing.Size(126, 26)
        Me.btnExtract.TabIndex = 3
        Me.btnExtract.Text = "Extract"
        Me.btnExtract.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LVQuery)
        Me.GroupBox1.Controls.Add(Me.txtQuery)
        Me.GroupBox1.Controls.Add(Me.LV_DBList)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 48)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(583, 315)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'LVQuery
        '
        Me.LVQuery.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.LVQuery.FullRowSelect = True
        Me.LVQuery.GridLines = True
        Me.LVQuery.Location = New System.Drawing.Point(10, 14)
        Me.LVQuery.Name = "LVQuery"
        Me.LVQuery.Size = New System.Drawing.Size(565, 133)
        Me.LVQuery.TabIndex = 9
        Me.LVQuery.UseCompatibleStateImageBehavior = False
        Me.LVQuery.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Extract Type"
        Me.ColumnHeader1.Width = 120
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Default Query"
        Me.ColumnHeader2.Width = 479
        '
        'txtQuery
        '
        Me.txtQuery.Location = New System.Drawing.Point(9, 153)
        Me.txtQuery.Multiline = True
        Me.txtQuery.Name = "txtQuery"
        Me.txtQuery.Size = New System.Drawing.Size(565, 156)
        Me.txtQuery.TabIndex = 8
        Me.txtQuery.WatermarkColor = System.Drawing.Color.Gray
        Me.txtQuery.WatermarkText = "Query here . . ."
        '
        'LV_DBList
        '
        Me.LV_DBList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4})
        Me.LV_DBList.FullRowSelect = True
        Me.LV_DBList.GridLines = True
        Me.LV_DBList.Location = New System.Drawing.Point(420, 253)
        Me.LV_DBList.Name = "LV_DBList"
        Me.LV_DBList.Size = New System.Drawing.Size(155, 46)
        Me.LV_DBList.TabIndex = 7
        Me.LV_DBList.UseCompatibleStateImageBehavior = False
        Me.LV_DBList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Database List"
        Me.ColumnHeader4.Width = 568
        '
        'SFD
        '
        Me.SFD.Filter = "Excel WorkBook|*.xls"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(1, 373)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(46, 16)
        Me.lblStatus.TabIndex = 7
        Me.lblStatus.Text = "Status"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.AutoSize = False
        Me.StatusStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProgressBar1, Me.ToolCount})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 394)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(609, 25)
        Me.StatusStrip1.TabIndex = 8
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.AutoSize = False
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(300, 19)
        '
        'ToolCount
        '
        Me.ToolCount.Name = "ToolCount"
        Me.ToolCount.Size = New System.Drawing.Size(40, 20)
        Me.ToolCount.Text = "Count"
        '
        'txtSource
        '
        Me.txtSource.Location = New System.Drawing.Point(64, 18)
        Me.txtSource.Name = "txtSource"
        Me.txtSource.Size = New System.Drawing.Size(487, 22)
        Me.txtSource.TabIndex = 2
        Me.txtSource.WatermarkColor = System.Drawing.Color.Gray
        Me.txtSource.WatermarkText = "Source Path . . ."
        '
        'frmDatabseExtractor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(609, 419)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnExtract)
        Me.Controls.Add(Me.txtSource)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnBrowse)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmDatabseExtractor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Database Extractor"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSource As Extract_All_Database.watermark
    Friend WithEvents btnExtract As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LVQuery As System.Windows.Forms.ListView
    Friend WithEvents txtQuery As Extract_All_Database.watermark
    Friend WithEvents LV_DBList As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents FBD As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents SFD As System.Windows.Forms.SaveFileDialog
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ToolStripProgressBar

End Class
