<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMIS
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
        Me.ofdImport = New System.Windows.Forms.OpenFileDialog()
        Me.tbMIS = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txtShowPass = New System.Windows.Forms.TextBox()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnPassGetPass = New System.Windows.Forms.Button()
        Me.btnPassBrowse = New System.Windows.Forms.Button()
        Me.txtGenPass = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnRestoreLoad = New System.Windows.Forms.Button()
        Me.btnRestoreBrowse = New System.Windows.Forms.Button()
        Me.txtRestore = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btnImportBrowse = New System.Windows.Forms.Button()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.txtImportPath = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lvImportResult = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.pbData = New System.Windows.Forms.ProgressBar()
        Me.ofdBackup = New System.Windows.Forms.OpenFileDialog()
        Me.tbMIS.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofdImport
        '
        Me.ofdImport.DefaultExt = "Excel 2003|*.xls|Excel 2007|*.xlsx"
        Me.ofdImport.FileName = "Excel File"
        Me.ofdImport.Filter = "Excel 2003|*.xls|Excel 2007|*.xlsx"
        '
        'tbMIS
        '
        Me.tbMIS.Controls.Add(Me.TabPage1)
        Me.tbMIS.Controls.Add(Me.TabPage2)
        Me.tbMIS.Location = New System.Drawing.Point(9, 12)
        Me.tbMIS.Name = "tbMIS"
        Me.tbMIS.SelectedIndex = 0
        Me.tbMIS.Size = New System.Drawing.Size(571, 312)
        Me.tbMIS.TabIndex = 9
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtShowPass)
        Me.TabPage1.Controls.Add(Me.btnReset)
        Me.TabPage1.Controls.Add(Me.btnPassGetPass)
        Me.TabPage1.Controls.Add(Me.btnPassBrowse)
        Me.TabPage1.Controls.Add(Me.txtGenPass)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.btnRestoreLoad)
        Me.TabPage1.Controls.Add(Me.btnRestoreBrowse)
        Me.TabPage1.Controls.Add(Me.txtRestore)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(563, 286)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Database"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txtShowPass
        '
        Me.txtShowPass.Location = New System.Drawing.Point(16, 98)
        Me.txtShowPass.Name = "txtShowPass"
        Me.txtShowPass.Size = New System.Drawing.Size(235, 20)
        Me.txtShowPass.TabIndex = 21
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(455, 15)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(102, 52)
        Me.btnReset.TabIndex = 20
        Me.btnReset.Text = "Reset Password"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'btnPassGetPass
        '
        Me.btnPassGetPass.Location = New System.Drawing.Point(336, 70)
        Me.btnPassGetPass.Name = "btnPassGetPass"
        Me.btnPassGetPass.Size = New System.Drawing.Size(73, 22)
        Me.btnPassGetPass.TabIndex = 19
        Me.btnPassGetPass.Text = "&Password"
        Me.btnPassGetPass.UseVisualStyleBackColor = True
        '
        'btnPassBrowse
        '
        Me.btnPassBrowse.Location = New System.Drawing.Point(257, 70)
        Me.btnPassBrowse.Name = "btnPassBrowse"
        Me.btnPassBrowse.Size = New System.Drawing.Size(73, 22)
        Me.btnPassBrowse.TabIndex = 18
        Me.btnPassBrowse.Text = "Browse"
        Me.btnPassBrowse.UseVisualStyleBackColor = True
        '
        'txtGenPass
        '
        Me.txtGenPass.BackColor = System.Drawing.SystemColors.Window
        Me.txtGenPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGenPass.Location = New System.Drawing.Point(16, 70)
        Me.txtGenPass.Name = "txtGenPass"
        Me.txtGenPass.ReadOnly = True
        Me.txtGenPass.Size = New System.Drawing.Size(235, 22)
        Me.txtGenPass.TabIndex = 17
        Me.txtGenPass.Text = "C:\file.noEXT"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 54)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Get Password"
        '
        'btnRestoreLoad
        '
        Me.btnRestoreLoad.Location = New System.Drawing.Point(336, 25)
        Me.btnRestoreLoad.Name = "btnRestoreLoad"
        Me.btnRestoreLoad.Size = New System.Drawing.Size(73, 22)
        Me.btnRestoreLoad.TabIndex = 15
        Me.btnRestoreLoad.Text = "&Load"
        Me.btnRestoreLoad.UseVisualStyleBackColor = True
        '
        'btnRestoreBrowse
        '
        Me.btnRestoreBrowse.Location = New System.Drawing.Point(257, 25)
        Me.btnRestoreBrowse.Name = "btnRestoreBrowse"
        Me.btnRestoreBrowse.Size = New System.Drawing.Size(73, 22)
        Me.btnRestoreBrowse.TabIndex = 14
        Me.btnRestoreBrowse.Text = "Browse"
        Me.btnRestoreBrowse.UseVisualStyleBackColor = True
        '
        'txtRestore
        '
        Me.txtRestore.BackColor = System.Drawing.SystemColors.Window
        Me.txtRestore.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRestore.Location = New System.Drawing.Point(16, 25)
        Me.txtRestore.Name = "txtRestore"
        Me.txtRestore.ReadOnly = True
        Me.txtRestore.Size = New System.Drawing.Size(235, 22)
        Me.txtRestore.TabIndex = 13
        Me.txtRestore.Text = "C:\file.noEXT"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Restore"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.btnImportBrowse)
        Me.TabPage2.Controls.Add(Me.btnImport)
        Me.TabPage2.Controls.Add(Me.txtImportPath)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.lvImportResult)
        Me.TabPage2.Controls.Add(Me.pbData)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(563, 286)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Migration"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btnImportBrowse
        '
        Me.btnImportBrowse.Location = New System.Drawing.Point(404, 11)
        Me.btnImportBrowse.Name = "btnImportBrowse"
        Me.btnImportBrowse.Size = New System.Drawing.Size(73, 22)
        Me.btnImportBrowse.TabIndex = 14
        Me.btnImportBrowse.Text = "Browse"
        Me.btnImportBrowse.UseVisualStyleBackColor = True
        '
        'btnImport
        '
        Me.btnImport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImport.Location = New System.Drawing.Point(483, 8)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(75, 29)
        Me.btnImport.TabIndex = 13
        Me.btnImport.Text = "Import"
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'txtImportPath
        '
        Me.txtImportPath.BackColor = System.Drawing.SystemColors.Window
        Me.txtImportPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImportPath.Location = New System.Drawing.Point(70, 11)
        Me.txtImportPath.Name = "txtImportPath"
        Me.txtImportPath.ReadOnly = True
        Me.txtImportPath.Size = New System.Drawing.Size(328, 22)
        Me.txtImportPath.TabIndex = 12
        Me.txtImportPath.Text = "D:\cadeath\Documents\GitHub\Dalton\Pawnshop\Pawnshop\Import Template.xlsx"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(11, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 16)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Browse"
        '
        'lvImportResult
        '
        Me.lvImportResult.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lvImportResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvImportResult.FullRowSelect = True
        Me.lvImportResult.GridLines = True
        Me.lvImportResult.Location = New System.Drawing.Point(8, 43)
        Me.lvImportResult.Name = "lvImportResult"
        Me.lvImportResult.Size = New System.Drawing.Size(547, 207)
        Me.lvImportResult.TabIndex = 10
        Me.lvImportResult.UseCompatibleStateImageBehavior = False
        Me.lvImportResult.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Line Num"
        Me.ColumnHeader1.Width = 75
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Description"
        Me.ColumnHeader2.Width = 421
        '
        'pbData
        '
        Me.pbData.Location = New System.Drawing.Point(8, 256)
        Me.pbData.Name = "pbData"
        Me.pbData.Size = New System.Drawing.Size(547, 23)
        Me.pbData.TabIndex = 9
        Me.pbData.Visible = False
        '
        'ofdBackup
        '
        Me.ofdBackup.DefaultExt = "Pawnshop Backup|*.noEXT"
        Me.ofdBackup.FileName = "*.noEXT"
        Me.ofdBackup.Filter = "Pawnshop Backup|*.noEXT"
        '
        'frmMIS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 333)
        Me.Controls.Add(Me.tbMIS)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmMIS"
        Me.Text = "MIS CONTROL PANEL"
        Me.tbMIS.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofdImport As System.Windows.Forms.OpenFileDialog
    Friend WithEvents tbMIS As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnPassGetPass As System.Windows.Forms.Button
    Friend WithEvents btnPassBrowse As System.Windows.Forms.Button
    Friend WithEvents txtGenPass As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnRestoreLoad As System.Windows.Forms.Button
    Friend WithEvents btnRestoreBrowse As System.Windows.Forms.Button
    Friend WithEvents txtRestore As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnImportBrowse As System.Windows.Forms.Button
    Friend WithEvents btnImport As System.Windows.Forms.Button
    Friend WithEvents txtImportPath As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lvImportResult As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents pbData As System.Windows.Forms.ProgressBar
    Friend WithEvents txtShowPass As System.Windows.Forms.TextBox
    Friend WithEvents ofdBackup As System.Windows.Forms.OpenFileDialog
End Class
