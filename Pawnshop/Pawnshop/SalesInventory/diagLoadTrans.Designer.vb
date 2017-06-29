<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class diagLoadTrans
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.rbLoadWallet = New System.Windows.Forms.RadioButton()
        Me.rbRemoteReceive = New System.Windows.Forms.RadioButton()
        Me.rbRemoteLoad = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbRemoteLoad)
        Me.GroupBox1.Controls.Add(Me.rbRemoteReceive)
        Me.GroupBox1.Controls.Add(Me.rbLoadWallet)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(264, 104)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(192, 111)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'rbLoadWallet
        '
        Me.rbLoadWallet.AutoSize = True
        Me.rbLoadWallet.Checked = True
        Me.rbLoadWallet.Location = New System.Drawing.Point(6, 19)
        Me.rbLoadWallet.Name = "rbLoadWallet"
        Me.rbLoadWallet.Size = New System.Drawing.Size(82, 17)
        Me.rbLoadWallet.TabIndex = 0
        Me.rbLoadWallet.TabStop = True
        Me.rbLoadWallet.Text = "Load Wallet"
        Me.rbLoadWallet.UseVisualStyleBackColor = True
        '
        'rbRemoteReceive
        '
        Me.rbRemoteReceive.AutoSize = True
        Me.rbRemoteReceive.Location = New System.Drawing.Point(6, 42)
        Me.rbRemoteReceive.Name = "rbRemoteReceive"
        Me.rbRemoteReceive.Size = New System.Drawing.Size(165, 17)
        Me.rbRemoteReceive.TabIndex = 1
        Me.rbRemoteReceive.Text = "Load Wallet Remote Receive"
        Me.rbRemoteReceive.UseVisualStyleBackColor = True
        '
        'rbRemoteLoad
        '
        Me.rbRemoteLoad.AutoSize = True
        Me.rbRemoteLoad.Location = New System.Drawing.Point(6, 65)
        Me.rbRemoteLoad.Name = "rbRemoteLoad"
        Me.rbRemoteLoad.Size = New System.Drawing.Size(149, 17)
        Me.rbRemoteLoad.TabIndex = 2
        Me.rbRemoteLoad.Text = "Load Wallet Remote Load"
        Me.rbRemoteLoad.UseVisualStyleBackColor = True
        '
        'diagLoadTrans
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(269, 139)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "diagLoadTrans"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Load Wallet Type"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbLoadWallet As System.Windows.Forms.RadioButton
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents rbRemoteLoad As System.Windows.Forms.RadioButton
    Friend WithEvents rbRemoteReceive As System.Windows.Forms.RadioButton
End Class
