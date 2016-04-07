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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtImport = New System.Windows.Forms.TextBox()
        Me.txtDB = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnFix = New System.Windows.Forms.Button()
        Me.ofdTemplate = New System.Windows.Forms.OpenFileDialog()
        Me.ofdFirebird = New System.Windows.Forms.OpenFileDialog()
        Me.lblRef = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Import"
        '
        'txtImport
        '
        Me.txtImport.Location = New System.Drawing.Point(12, 25)
        Me.txtImport.Name = "txtImport"
        Me.txtImport.Size = New System.Drawing.Size(197, 20)
        Me.txtImport.TabIndex = 1
        '
        'txtDB
        '
        Me.txtDB.Location = New System.Drawing.Point(12, 64)
        Me.txtDB.Name = "txtDB"
        Me.txtDB.Size = New System.Drawing.Size(197, 20)
        Me.txtDB.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Database"
        '
        'btnFix
        '
        Me.btnFix.Location = New System.Drawing.Point(132, 90)
        Me.btnFix.Name = "btnFix"
        Me.btnFix.Size = New System.Drawing.Size(75, 41)
        Me.btnFix.TabIndex = 4
        Me.btnFix.Text = "FIX"
        Me.btnFix.UseVisualStyleBackColor = True
        '
        'ofdTemplate
        '
        Me.ofdTemplate.FileName = "Template"
        Me.ofdTemplate.Filter = "Excel 2007|*.xlsx|Excel 2003|*.xls"
        '
        'ofdFirebird
        '
        Me.ofdFirebird.FileName = "Database"
        Me.ofdFirebird.Filter = "Database|*.fdb"
        '
        'lblRef
        '
        Me.lblRef.AutoSize = True
        Me.lblRef.Location = New System.Drawing.Point(12, 136)
        Me.lblRef.Name = "lblRef"
        Me.lblRef.Size = New System.Drawing.Size(24, 13)
        Me.lblRef.TabIndex = 5
        Me.lblRef.Text = "Idle"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(219, 158)
        Me.Controls.Add(Me.lblRef)
        Me.Controls.Add(Me.btnFix)
        Me.Controls.Add(Me.txtDB)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtImport)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Main"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtImport As System.Windows.Forms.TextBox
    Friend WithEvents txtDB As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnFix As System.Windows.Forms.Button
    Friend WithEvents ofdTemplate As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ofdFirebird As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblRef As System.Windows.Forms.Label

End Class
