<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSalesStockOut
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSalesStockOut))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtControl = New System.Windows.Forms.TextBox()
        Me.txtBranch = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtParticular = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnAccept = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "STO #"
        '
        'txtControl
        '
        Me.txtControl.BackColor = System.Drawing.Color.White
        Me.txtControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtControl.Location = New System.Drawing.Point(119, 12)
        Me.txtControl.Name = "txtControl"
        Me.txtControl.ReadOnly = True
        Me.txtControl.Size = New System.Drawing.Size(155, 22)
        Me.txtControl.TabIndex = 1
        Me.txtControl.Text = "000"
        '
        'txtBranch
        '
        Me.txtBranch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBranch.Location = New System.Drawing.Point(119, 40)
        Me.txtBranch.Name = "txtBranch"
        Me.txtBranch.Size = New System.Drawing.Size(155, 22)
        Me.txtBranch.TabIndex = 0
        Me.txtBranch.Text = "000"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 18)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "LOCATION: "
        '
        'txtParticular
        '
        Me.txtParticular.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtParticular.Location = New System.Drawing.Point(12, 89)
        Me.txtParticular.Multiline = True
        Me.txtParticular.Name = "txtParticular"
        Me.txtParticular.Size = New System.Drawing.Size(262, 68)
        Me.txtParticular.TabIndex = 1
        Me.txtParticular.Text = "000"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 18)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "PARTICULARS"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(199, 163)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 33)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnAccept
        '
        Me.btnAccept.Location = New System.Drawing.Point(118, 163)
        Me.btnAccept.Name = "btnAccept"
        Me.btnAccept.Size = New System.Drawing.Size(75, 33)
        Me.btnAccept.TabIndex = 2
        Me.btnAccept.Text = "&Accept"
        Me.btnAccept.UseVisualStyleBackColor = True
        '
        'frmSalesStockOut
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(288, 208)
        Me.Controls.Add(Me.btnAccept)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtParticular)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtBranch)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtControl)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmSalesStockOut"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock Out"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtControl As System.Windows.Forms.TextBox
    Friend WithEvents txtBranch As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtParticular As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnAccept As System.Windows.Forms.Button
End Class
