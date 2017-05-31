<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReadTableHash
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReadTableHash))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.brnBrowse = New System.Windows.Forms.Button()
        Me.lvData = New System.Windows.Forms.ListView()
        Me.txtQuery = New System.Windows.Forms.TextBox()
        Me.btnRead = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtHash = New System.Windows.Forms.TextBox()
        Me.btnMatch = New System.Windows.Forms.Button()
        Me.txtMatch = New System.Windows.Forms.TextBox()
        Me.ofd = New System.Windows.Forms.OpenFileDialog()
        Me.fbdBackup = New System.Windows.Forms.FolderBrowserDialog()
        Me.chkOnly = New System.Windows.Forms.CheckBox()
        Me.pbProcess = New System.Windows.Forms.ProgressBar()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtPath)
        Me.GroupBox1.Controls.Add(Me.brnBrowse)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(375, 84)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txtPath
        '
        Me.txtPath.Location = New System.Drawing.Point(6, 19)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.ReadOnly = True
        Me.txtPath.Size = New System.Drawing.Size(308, 20)
        Me.txtPath.TabIndex = 1
        '
        'brnBrowse
        '
        Me.brnBrowse.Location = New System.Drawing.Point(320, 17)
        Me.brnBrowse.Name = "brnBrowse"
        Me.brnBrowse.Size = New System.Drawing.Size(43, 23)
        Me.brnBrowse.TabIndex = 0
        Me.brnBrowse.Text = " . . ."
        Me.brnBrowse.UseVisualStyleBackColor = True
        '
        'lvData
        '
        Me.lvData.FullRowSelect = True
        Me.lvData.GridLines = True
        Me.lvData.Location = New System.Drawing.Point(12, 102)
        Me.lvData.Name = "lvData"
        Me.lvData.Size = New System.Drawing.Size(771, 258)
        Me.lvData.TabIndex = 1
        Me.lvData.UseCompatibleStateImageBehavior = False
        Me.lvData.View = System.Windows.Forms.View.Details
        '
        'txtQuery
        '
        Me.txtQuery.Location = New System.Drawing.Point(393, 18)
        Me.txtQuery.Multiline = True
        Me.txtQuery.Name = "txtQuery"
        Me.txtQuery.Size = New System.Drawing.Size(301, 78)
        Me.txtQuery.TabIndex = 2
        '
        'btnRead
        '
        Me.btnRead.Location = New System.Drawing.Point(700, 18)
        Me.btnRead.Name = "btnRead"
        Me.btnRead.Size = New System.Drawing.Size(83, 30)
        Me.btnRead.TabIndex = 2
        Me.btnRead.Text = "R&ead"
        Me.btnRead.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtHash)
        Me.GroupBox2.Controls.Add(Me.btnMatch)
        Me.GroupBox2.Controls.Add(Me.txtMatch)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 366)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(771, 58)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Hash Value"
        '
        'txtHash
        '
        Me.txtHash.Location = New System.Drawing.Point(13, 19)
        Me.txtHash.Name = "txtHash"
        Me.txtHash.ReadOnly = True
        Me.txtHash.Size = New System.Drawing.Size(362, 20)
        Me.txtHash.TabIndex = 5
        '
        'btnMatch
        '
        Me.btnMatch.Location = New System.Drawing.Point(688, 13)
        Me.btnMatch.Name = "btnMatch"
        Me.btnMatch.Size = New System.Drawing.Size(77, 30)
        Me.btnMatch.TabIndex = 4
        Me.btnMatch.Text = "&Match"
        Me.btnMatch.UseVisualStyleBackColor = True
        '
        'txtMatch
        '
        Me.txtMatch.Location = New System.Drawing.Point(381, 19)
        Me.txtMatch.Name = "txtMatch"
        Me.txtMatch.Size = New System.Drawing.Size(301, 20)
        Me.txtMatch.TabIndex = 3
        '
        'ofd
        '
        Me.ofd.Filter = "Data | *.fdb"
        '
        'fbdBackup
        '
        Me.fbdBackup.SelectedPath = "C:\"
        '
        'chkOnly
        '
        Me.chkOnly.AutoSize = True
        Me.chkOnly.Checked = True
        Me.chkOnly.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkOnly.Location = New System.Drawing.Point(702, 54)
        Me.chkOnly.Name = "chkOnly"
        Me.chkOnly.Size = New System.Drawing.Size(77, 17)
        Me.chkOnly.TabIndex = 4
        Me.chkOnly.Text = "Fields Only"
        Me.chkOnly.UseVisualStyleBackColor = True
        '
        'pbProcess
        '
        Me.pbProcess.Location = New System.Drawing.Point(12, 427)
        Me.pbProcess.Name = "pbProcess"
        Me.pbProcess.Size = New System.Drawing.Size(771, 23)
        Me.pbProcess.TabIndex = 5
        '
        'frmReadTableHash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(787, 452)
        Me.Controls.Add(Me.pbProcess)
        Me.Controls.Add(Me.chkOnly)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnRead)
        Me.Controls.Add(Me.txtQuery)
        Me.Controls.Add(Me.lvData)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmReadTableHash"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Read & Hash Table"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents brnBrowse As System.Windows.Forms.Button
    Friend WithEvents lvData As System.Windows.Forms.ListView
    Friend WithEvents txtQuery As System.Windows.Forms.TextBox
    Friend WithEvents btnRead As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ofd As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnMatch As System.Windows.Forms.Button
    Friend WithEvents txtMatch As System.Windows.Forms.TextBox
    Friend WithEvents fbdBackup As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents txtHash As System.Windows.Forms.TextBox
    Friend WithEvents chkOnly As System.Windows.Forms.CheckBox
    Friend WithEvents pbProcess As System.Windows.Forms.ProgressBar
End Class
