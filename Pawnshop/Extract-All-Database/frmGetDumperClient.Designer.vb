<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGetDumperClient
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
        Me.btnBrowseTemplate = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lvDatabaselist = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.txtCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.txtDBpath = New Extract_All_Database.watermark()
        Me.txtTemplatePath = New Extract_All_Database.watermark()
        Me.lvTemplateList = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtTemplatecount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnBrowseTemplate
        '
        Me.btnBrowseTemplate.Location = New System.Drawing.Point(407, 12)
        Me.btnBrowseTemplate.Name = "btnBrowseTemplate"
        Me.btnBrowseTemplate.Size = New System.Drawing.Size(44, 23)
        Me.btnBrowseTemplate.TabIndex = 0
        Me.btnBrowseTemplate.Text = ". . ."
        Me.btnBrowseTemplate.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(407, 41)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(44, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = ". . ."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lvDatabaselist
        '
        Me.lvDatabaselist.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.lvDatabaselist.Location = New System.Drawing.Point(12, 70)
        Me.lvDatabaselist.Name = "lvDatabaselist"
        Me.lvDatabaselist.Size = New System.Drawing.Size(205, 259)
        Me.lvDatabaselist.TabIndex = 6
        Me.lvDatabaselist.UseCompatibleStateImageBehavior = False
        Me.lvDatabaselist.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Database list"
        Me.ColumnHeader1.Width = 435
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.txtCount, Me.txtTemplatecount})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 379)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(457, 22)
        Me.StatusStrip1.TabIndex = 7
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'txtCount
        '
        Me.txtCount.Name = "txtCount"
        Me.txtCount.Size = New System.Drawing.Size(50, 17)
        Me.txtCount.Text = "Counter"
        '
        'btnGenerate
        '
        Me.btnGenerate.Location = New System.Drawing.Point(168, 335)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(120, 31)
        Me.btnGenerate.TabIndex = 8
        Me.btnGenerate.Text = "&Generate"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'txtDBpath
        '
        Me.txtDBpath.Location = New System.Drawing.Point(12, 44)
        Me.txtDBpath.Name = "txtDBpath"
        Me.txtDBpath.Size = New System.Drawing.Size(389, 20)
        Me.txtDBpath.TabIndex = 5
        Me.txtDBpath.WatermarkColor = System.Drawing.Color.Gray
        Me.txtDBpath.WatermarkText = "Database path"
        '
        'txtTemplatePath
        '
        Me.txtTemplatePath.Location = New System.Drawing.Point(12, 15)
        Me.txtTemplatePath.Name = "txtTemplatePath"
        Me.txtTemplatePath.Size = New System.Drawing.Size(389, 20)
        Me.txtTemplatePath.TabIndex = 4
        Me.txtTemplatePath.WatermarkColor = System.Drawing.Color.Gray
        Me.txtTemplatePath.WatermarkText = "Templete path"
        '
        'lvTemplateList
        '
        Me.lvTemplateList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2})
        Me.lvTemplateList.Location = New System.Drawing.Point(223, 70)
        Me.lvTemplateList.Name = "lvTemplateList"
        Me.lvTemplateList.Size = New System.Drawing.Size(222, 259)
        Me.lvTemplateList.TabIndex = 9
        Me.lvTemplateList.UseCompatibleStateImageBehavior = False
        Me.lvTemplateList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Template List"
        Me.ColumnHeader2.Width = 435
        '
        'txtTemplatecount
        '
        Me.txtTemplatecount.Name = "txtTemplatecount"
        Me.txtTemplatecount.Size = New System.Drawing.Size(57, 17)
        Me.txtTemplatecount.Text = "Template"
        '
        'frmGetDumperClient
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(457, 401)
        Me.Controls.Add(Me.lvTemplateList)
        Me.Controls.Add(Me.btnGenerate)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.lvDatabaselist)
        Me.Controls.Add(Me.txtDBpath)
        Me.Controls.Add(Me.txtTemplatePath)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnBrowseTemplate)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmGetDumperClient"
        Me.Text = "GetDumper Client"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnBrowseTemplate As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtTemplatePath As Extract_All_Database.watermark
    Friend WithEvents txtDBpath As Extract_All_Database.watermark
    Friend WithEvents lvDatabaselist As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents txtCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents lvTemplateList As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtTemplatecount As System.Windows.Forms.ToolStripStatusLabel
End Class
