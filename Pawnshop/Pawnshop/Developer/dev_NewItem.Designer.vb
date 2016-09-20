<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dev_NewItem
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
        Me.btnPop = New System.Windows.Forms.Button()
        Me.lsClass = New System.Windows.Forms.ListBox()
        Me.btnLoadClass = New System.Windows.Forms.Button()
        Me.lblID = New System.Windows.Forms.Label()
        Me.lblCLass = New System.Windows.Forms.Label()
        Me.lsSpecs = New System.Windows.Forms.ListBox()
        Me.txtCategory = New System.Windows.Forms.TextBox()
        Me.txtPrint = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.txtSpec = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnPop
        '
        Me.btnPop.Location = New System.Drawing.Point(12, 12)
        Me.btnPop.Name = "btnPop"
        Me.btnPop.Size = New System.Drawing.Size(84, 46)
        Me.btnPop.TabIndex = 0
        Me.btnPop.Text = "POPULATE"
        Me.btnPop.UseVisualStyleBackColor = True
        '
        'lsClass
        '
        Me.lsClass.FormattingEnabled = True
        Me.lsClass.Location = New System.Drawing.Point(115, 12)
        Me.lsClass.Name = "lsClass"
        Me.lsClass.Size = New System.Drawing.Size(120, 290)
        Me.lsClass.TabIndex = 1
        '
        'btnLoadClass
        '
        Me.btnLoadClass.Location = New System.Drawing.Point(12, 64)
        Me.btnLoadClass.Name = "btnLoadClass"
        Me.btnLoadClass.Size = New System.Drawing.Size(84, 46)
        Me.btnLoadClass.TabIndex = 2
        Me.btnLoadClass.Text = "CLASS"
        Me.btnLoadClass.UseVisualStyleBackColor = True
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Location = New System.Drawing.Point(252, 12)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(18, 13)
        Me.lblID.TabIndex = 3
        Me.lblID.Text = "ID"
        '
        'lblCLass
        '
        Me.lblCLass.AutoSize = True
        Me.lblCLass.Location = New System.Drawing.Point(252, 29)
        Me.lblCLass.Name = "lblCLass"
        Me.lblCLass.Size = New System.Drawing.Size(41, 13)
        Me.lblCLass.TabIndex = 4
        Me.lblCLass.Text = "CLASS"
        '
        'lsSpecs
        '
        Me.lsSpecs.FormattingEnabled = True
        Me.lsSpecs.Location = New System.Drawing.Point(255, 45)
        Me.lsSpecs.Name = "lsSpecs"
        Me.lsSpecs.Size = New System.Drawing.Size(120, 95)
        Me.lsSpecs.TabIndex = 5
        '
        'txtCategory
        '
        Me.txtCategory.Location = New System.Drawing.Point(255, 155)
        Me.txtCategory.Name = "txtCategory"
        Me.txtCategory.Size = New System.Drawing.Size(100, 20)
        Me.txtCategory.TabIndex = 6
        '
        'txtPrint
        '
        Me.txtPrint.Location = New System.Drawing.Point(255, 181)
        Me.txtPrint.Name = "txtPrint"
        Me.txtPrint.Size = New System.Drawing.Size(269, 20)
        Me.txtPrint.TabIndex = 7
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(449, 261)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(255, 235)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(269, 20)
        Me.txtCode.TabIndex = 10
        '
        'txtSpec
        '
        Me.txtSpec.Location = New System.Drawing.Point(255, 209)
        Me.txtSpec.Name = "txtSpec"
        Me.txtSpec.Size = New System.Drawing.Size(100, 20)
        Me.txtSpec.TabIndex = 9
        '
        'dev_NewItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(563, 323)
        Me.Controls.Add(Me.txtCode)
        Me.Controls.Add(Me.txtSpec)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtPrint)
        Me.Controls.Add(Me.txtCategory)
        Me.Controls.Add(Me.lsSpecs)
        Me.Controls.Add(Me.lblCLass)
        Me.Controls.Add(Me.lblID)
        Me.Controls.Add(Me.btnLoadClass)
        Me.Controls.Add(Me.lsClass)
        Me.Controls.Add(Me.btnPop)
        Me.Name = "dev_NewItem"
        Me.Text = "dev_NewItem"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnPop As System.Windows.Forms.Button
    Friend WithEvents lsClass As System.Windows.Forms.ListBox
    Friend WithEvents btnLoadClass As System.Windows.Forms.Button
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents lblCLass As System.Windows.Forms.Label
    Friend WithEvents lsSpecs As System.Windows.Forms.ListBox
    Friend WithEvents txtCategory As System.Windows.Forms.TextBox
    Friend WithEvents txtPrint As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents txtSpec As System.Windows.Forms.TextBox
End Class
