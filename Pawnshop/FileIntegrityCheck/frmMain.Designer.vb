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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblFileURL = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtHash = New System.Windows.Forms.TextBox()
        Me.btnHash = New System.Windows.Forms.Button()
        Me.txtCompare = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCompare = New System.Windows.Forms.Button()
        Me.ofdFile = New System.Windows.Forms.OpenFileDialog()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(117, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(181, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "File URL (double click the bar below)"
        '
        'lblFileURL
        '
        Me.lblFileURL.BackColor = System.Drawing.Color.White
        Me.lblFileURL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFileURL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFileURL.Location = New System.Drawing.Point(120, 18)
        Me.lblFileURL.Name = "lblFileURL"
        Me.lblFileURL.Size = New System.Drawing.Size(377, 25)
        Me.lblFileURL.TabIndex = 1
        Me.lblFileURL.Text = "F:\cadeath\Documents\GitHub\Dalton\Pawnshop"
        Me.lblFileURL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(117, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Hash Value"
        '
        'txtHash
        '
        Me.txtHash.BackColor = System.Drawing.Color.White
        Me.txtHash.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHash.Location = New System.Drawing.Point(120, 66)
        Me.txtHash.Name = "txtHash"
        Me.txtHash.ReadOnly = True
        Me.txtHash.Size = New System.Drawing.Size(377, 22)
        Me.txtHash.TabIndex = 1
        Me.txtHash.Text = " Dim fileStream As FileStream = File.OpenRead(file_name)"
        '
        'btnHash
        '
        Me.btnHash.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHash.Location = New System.Drawing.Point(12, 5)
        Me.btnHash.Name = "btnHash"
        Me.btnHash.Size = New System.Drawing.Size(99, 83)
        Me.btnHash.TabIndex = 0
        Me.btnHash.Text = "HASH"
        Me.btnHash.UseVisualStyleBackColor = True
        '
        'txtCompare
        '
        Me.txtCompare.BackColor = System.Drawing.Color.White
        Me.txtCompare.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCompare.Location = New System.Drawing.Point(12, 115)
        Me.txtCompare.Name = "txtCompare"
        Me.txtCompare.Size = New System.Drawing.Size(386, 22)
        Me.txtCompare.TabIndex = 2
        Me.txtCompare.Text = " Dim fileStream As FileStream = File.OpenRead(file_name)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Hash Compare"
        '
        'btnCompare
        '
        Me.btnCompare.Location = New System.Drawing.Point(404, 107)
        Me.btnCompare.Name = "btnCompare"
        Me.btnCompare.Size = New System.Drawing.Size(94, 38)
        Me.btnCompare.TabIndex = 3
        Me.btnCompare.Text = "Compare"
        Me.btnCompare.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(510, 155)
        Me.Controls.Add(Me.btnCompare)
        Me.Controls.Add(Me.txtCompare)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnHash)
        Me.Controls.Add(Me.txtHash)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblFileURL)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MIS - File Integrity Check"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblFileURL As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtHash As System.Windows.Forms.TextBox
    Friend WithEvents btnHash As System.Windows.Forms.Button
    Friend WithEvents txtCompare As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnCompare As System.Windows.Forms.Button
    Friend WithEvents ofdFile As System.Windows.Forms.OpenFileDialog

End Class
