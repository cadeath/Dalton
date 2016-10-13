<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Extract
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnBrowseData = New System.Windows.Forms.Button()
        Me.btnBrowseSave = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lbTableName = New System.Windows.Forms.ListBox()
        Me.txtHeader = New System.Windows.Forms.TextBox()
        Me.txtSavePath = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtQuery = New System.Windows.Forms.TextBox()
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.btnExtract = New System.Windows.Forms.Button()
        Me.ofd = New System.Windows.Forms.OpenFileDialog()
        Me.sfdPath = New System.Windows.Forms.SaveFileDialog()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.fbdBackup = New System.Windows.Forms.FolderBrowserDialog()
        Me.pbProgress = New System.Windows.Forms.ProgressBar()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Database"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnBrowseData)
        Me.GroupBox1.Controls.Add(Me.btnBrowseSave)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.lbTableName)
        Me.GroupBox1.Controls.Add(Me.txtHeader)
        Me.GroupBox1.Controls.Add(Me.txtSavePath)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtQuery)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtPath)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(641, 208)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Extract To Excel"
        '
        'btnBrowseData
        '
        Me.btnBrowseData.Location = New System.Drawing.Point(348, 22)
        Me.btnBrowseData.Name = "btnBrowseData"
        Me.btnBrowseData.Size = New System.Drawing.Size(40, 21)
        Me.btnBrowseData.TabIndex = 10
        Me.btnBrowseData.Text = "..."
        Me.btnBrowseData.UseVisualStyleBackColor = True
        '
        'btnBrowseSave
        '
        Me.btnBrowseSave.Location = New System.Drawing.Point(348, 54)
        Me.btnBrowseSave.Name = "btnBrowseSave"
        Me.btnBrowseSave.Size = New System.Drawing.Size(40, 21)
        Me.btnBrowseSave.TabIndex = 8
        Me.btnBrowseSave.Text = "..."
        Me.btnBrowseSave.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(398, 19)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(131, 24)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Display Table Names"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lbTableName
        '
        Me.lbTableName.FormattingEnabled = True
        Me.lbTableName.Location = New System.Drawing.Point(398, 52)
        Me.lbTableName.Name = "lbTableName"
        Me.lbTableName.Size = New System.Drawing.Size(237, 121)
        Me.lbTableName.TabIndex = 6
        '
        'txtHeader
        '
        Me.txtHeader.Location = New System.Drawing.Point(398, 182)
        Me.txtHeader.Name = "txtHeader"
        Me.txtHeader.Size = New System.Drawing.Size(237, 20)
        Me.txtHeader.TabIndex = 9
        '
        'txtSavePath
        '
        Me.txtSavePath.Location = New System.Drawing.Point(65, 54)
        Me.txtSavePath.Name = "txtSavePath"
        Me.txtSavePath.ReadOnly = True
        Me.txtSavePath.Size = New System.Drawing.Size(277, 20)
        Me.txtSavePath.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Save Path"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Query"
        '
        'txtQuery
        '
        Me.txtQuery.Location = New System.Drawing.Point(65, 81)
        Me.txtQuery.Multiline = True
        Me.txtQuery.Name = "txtQuery"
        Me.txtQuery.Size = New System.Drawing.Size(327, 117)
        Me.txtQuery.TabIndex = 3
        '
        'txtPath
        '
        Me.txtPath.Location = New System.Drawing.Point(65, 23)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.ReadOnly = True
        Me.txtPath.Size = New System.Drawing.Size(277, 20)
        Me.txtPath.TabIndex = 0
        '
        'btnExtract
        '
        Me.btnExtract.Location = New System.Drawing.Point(319, 220)
        Me.btnExtract.Name = "btnExtract"
        Me.btnExtract.Size = New System.Drawing.Size(81, 36)
        Me.btnExtract.TabIndex = 3
        Me.btnExtract.Text = "Extract"
        Me.btnExtract.UseVisualStyleBackColor = True
        '
        'ofd
        '
        Me.ofd.Filter = "Data | *.fdb"
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(532, 220)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(114, 36)
        Me.btnUpdate.TabIndex = 7
        Me.btnUpdate.Text = "Update Header"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'fbdBackup
        '
        Me.fbdBackup.SelectedPath = "C:\"
        '
        'pbProgress
        '
        Me.pbProgress.Location = New System.Drawing.Point(12, 227)
        Me.pbProgress.Name = "pbProgress"
        Me.pbProgress.Size = New System.Drawing.Size(301, 23)
        Me.pbProgress.TabIndex = 8
        '
        'Extract
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(658, 262)
        Me.Controls.Add(Me.pbProgress)
        Me.Controls.Add(Me.btnExtract)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnUpdate)
        Me.Name = "Extract"
        Me.Text = "Extractor"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtQuery As System.Windows.Forms.TextBox
    Friend WithEvents btnExtract As System.Windows.Forms.Button
    Friend WithEvents ofd As System.Windows.Forms.OpenFileDialog
    Friend WithEvents sfdPath As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtSavePath As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbTableName As System.Windows.Forms.ListBox
    Friend WithEvents txtHeader As System.Windows.Forms.TextBox
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnBrowseSave As System.Windows.Forms.Button
    Friend WithEvents fbdBackup As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents btnBrowseData As System.Windows.Forms.Button
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents pbProgress As System.Windows.Forms.ProgressBar
End Class
