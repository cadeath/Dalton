﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSampleExtract
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
        Me.btnBrowseData = New System.Windows.Forms.Button()
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.fbdBackup = New System.Windows.Forms.FolderBrowserDialog()
        Me.txtExtract = New System.Windows.Forms.Button()
        Me.txtQuery = New System.Windows.Forms.TextBox()
        Me.pbProgress = New System.Windows.Forms.ProgressBar()
        Me.sfdPath = New System.Windows.Forms.SaveFileDialog()
        Me.ofd = New System.Windows.Forms.OpenFileDialog()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.lbTableName = New System.Windows.Forms.ListBox()
        Me.txtHeader = New System.Windows.Forms.TextBox()
        Me.btnBrowseSave = New System.Windows.Forms.Button()
        Me.txtSavePath = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnBrowseData
        '
        Me.btnBrowseData.Location = New System.Drawing.Point(295, 11)
        Me.btnBrowseData.Name = "btnBrowseData"
        Me.btnBrowseData.Size = New System.Drawing.Size(40, 21)
        Me.btnBrowseData.TabIndex = 11
        Me.btnBrowseData.Text = "..."
        Me.btnBrowseData.UseVisualStyleBackColor = True
        '
        'txtPath
        '
        Me.txtPath.Location = New System.Drawing.Point(12, 12)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.ReadOnly = True
        Me.txtPath.Size = New System.Drawing.Size(277, 20)
        Me.txtPath.TabIndex = 12
        '
        'fbdBackup
        '
        Me.fbdBackup.SelectedPath = "C:\"
        '
        'txtExtract
        '
        Me.txtExtract.Location = New System.Drawing.Point(270, 226)
        Me.txtExtract.Name = "txtExtract"
        Me.txtExtract.Size = New System.Drawing.Size(65, 23)
        Me.txtExtract.TabIndex = 13
        Me.txtExtract.Text = "OK"
        Me.txtExtract.UseVisualStyleBackColor = True
        '
        'txtQuery
        '
        Me.txtQuery.Location = New System.Drawing.Point(12, 72)
        Me.txtQuery.Multiline = True
        Me.txtQuery.Name = "txtQuery"
        Me.txtQuery.Size = New System.Drawing.Size(323, 148)
        Me.txtQuery.TabIndex = 14
        '
        'pbProgress
        '
        Me.pbProgress.Location = New System.Drawing.Point(12, 226)
        Me.pbProgress.Name = "pbProgress"
        Me.pbProgress.Size = New System.Drawing.Size(250, 23)
        Me.pbProgress.TabIndex = 15
        '
        'ofd
        '
        Me.ofd.Filter = "Data | *.fdb"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(341, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(131, 24)
        Me.Button2.TabIndex = 16
        Me.Button2.Text = "Edit Header"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(475, 213)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(114, 36)
        Me.btnUpdate.TabIndex = 18
        Me.btnUpdate.Text = "Update Header"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'lbTableName
        '
        Me.lbTableName.FormattingEnabled = True
        Me.lbTableName.Location = New System.Drawing.Point(341, 45)
        Me.lbTableName.Name = "lbTableName"
        Me.lbTableName.Size = New System.Drawing.Size(248, 121)
        Me.lbTableName.TabIndex = 17
        '
        'txtHeader
        '
        Me.txtHeader.Location = New System.Drawing.Point(341, 175)
        Me.txtHeader.Name = "txtHeader"
        Me.txtHeader.Size = New System.Drawing.Size(248, 20)
        Me.txtHeader.TabIndex = 19
        '
        'btnBrowseSave
        '
        Me.btnBrowseSave.Location = New System.Drawing.Point(295, 45)
        Me.btnBrowseSave.Name = "btnBrowseSave"
        Me.btnBrowseSave.Size = New System.Drawing.Size(40, 21)
        Me.btnBrowseSave.TabIndex = 21
        Me.btnBrowseSave.Text = "..."
        Me.btnBrowseSave.UseVisualStyleBackColor = True
        '
        'txtSavePath
        '
        Me.txtSavePath.Location = New System.Drawing.Point(12, 45)
        Me.txtSavePath.Name = "txtSavePath"
        Me.txtSavePath.ReadOnly = True
        Me.txtSavePath.Size = New System.Drawing.Size(277, 20)
        Me.txtSavePath.TabIndex = 20
        '
        'frmSampleExtract
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(595, 260)
        Me.Controls.Add(Me.btnBrowseSave)
        Me.Controls.Add(Me.txtSavePath)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.lbTableName)
        Me.Controls.Add(Me.txtHeader)
        Me.Controls.Add(Me.pbProgress)
        Me.Controls.Add(Me.txtQuery)
        Me.Controls.Add(Me.txtExtract)
        Me.Controls.Add(Me.txtPath)
        Me.Controls.Add(Me.btnBrowseData)
        Me.Name = "frmSampleExtract"
        Me.Text = "frmSampleExtract"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnBrowseData As System.Windows.Forms.Button
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents fbdBackup As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents txtExtract As System.Windows.Forms.Button
    Friend WithEvents txtQuery As System.Windows.Forms.TextBox
    Friend WithEvents pbProgress As System.Windows.Forms.ProgressBar
    Friend WithEvents sfdPath As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ofd As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents lbTableName As System.Windows.Forms.ListBox
    Friend WithEvents txtHeader As System.Windows.Forms.TextBox
    Friend WithEvents btnBrowseSave As System.Windows.Forms.Button
    Friend WithEvents txtSavePath As System.Windows.Forms.TextBox
End Class
