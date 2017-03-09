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
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnExtract = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LVQuery = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LV_DBList = New System.Windows.Forms.ListView()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FBD = New System.Windows.Forms.FolderBrowserDialog()
        Me.SFD = New System.Windows.Forms.SaveFileDialog()
        Me.monCal = New System.Windows.Forms.MonthCalendar()
        Me.txtQuery = New Extract_All_Database.watermark()
        Me.txtSource = New Extract_All_Database.watermark()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(419, 11)
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
        Me.btnExtract.Location = New System.Drawing.Point(536, 273)
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
        Me.GroupBox1.Location = New System.Drawing.Point(14, 48)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(454, 307)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'LVQuery
        '
        Me.LVQuery.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.LVQuery.FullRowSelect = True
        Me.LVQuery.GridLines = True
        Me.LVQuery.Location = New System.Drawing.Point(12, 14)
        Me.LVQuery.Name = "LVQuery"
        Me.LVQuery.Size = New System.Drawing.Size(427, 162)
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LV_DBList)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 522)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(101, 58)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        '
        'LV_DBList
        '
        Me.LV_DBList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4})
        Me.LV_DBList.FullRowSelect = True
        Me.LV_DBList.GridLines = True
        Me.LV_DBList.Location = New System.Drawing.Point(6, 13)
        Me.LV_DBList.Name = "LV_DBList"
        Me.LV_DBList.Size = New System.Drawing.Size(216, 149)
        Me.LV_DBList.TabIndex = 7
        Me.LV_DBList.UseCompatibleStateImageBehavior = False
        Me.LV_DBList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Database List"
        Me.ColumnHeader4.Width = 482
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(477, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Select Date:"
        '
        'SFD
        '
        Me.SFD.Filter = "CSV|*.csv"
        '
        'monCal
        '
        Me.monCal.Location = New System.Drawing.Point(480, 99)
        Me.monCal.Name = "monCal"
        Me.monCal.TabIndex = 11
        '
        'txtQuery
        '
        Me.txtQuery.Location = New System.Drawing.Point(12, 182)
        Me.txtQuery.Multiline = True
        Me.txtQuery.Name = "txtQuery"
        Me.txtQuery.Size = New System.Drawing.Size(427, 115)
        Me.txtQuery.TabIndex = 8
        Me.txtQuery.WatermarkColor = System.Drawing.Color.Gray
        Me.txtQuery.WatermarkText = "Query here . . ."
        '
        'txtSource
        '
        Me.txtSource.Location = New System.Drawing.Point(64, 18)
        Me.txtSource.Name = "txtSource"
        Me.txtSource.Size = New System.Drawing.Size(350, 22)
        Me.txtSource.TabIndex = 2
        Me.txtSource.WatermarkColor = System.Drawing.Color.Gray
        Me.txtSource.WatermarkText = "Source Path . . ."
        '
        'frmDatabseExtractor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(717, 371)
        Me.Controls.Add(Me.monCal)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnExtract)
        Me.Controls.Add(Me.txtSource)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnBrowse)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmDatabseExtractor"
        Me.Text = "Database Extractor"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
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
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents LV_DBList As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents FBD As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents SFD As System.Windows.Forms.SaveFileDialog
    Friend WithEvents monCal As System.Windows.Forms.MonthCalendar

End Class
