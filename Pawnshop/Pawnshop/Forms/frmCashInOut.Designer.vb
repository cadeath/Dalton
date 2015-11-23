<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCashInOut
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCashInOut))
        Me.lblTrans = New System.Windows.Forms.Label()
        Me.btnCashIn = New System.Windows.Forms.Button()
        Me.btnPost = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.txtParticulars = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboTransactions = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCashOut = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.btnVoid = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblTrans
        '
        Me.lblTrans.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTrans.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTrans.Location = New System.Drawing.Point(283, 15)
        Me.lblTrans.Name = "lblTrans"
        Me.lblTrans.Size = New System.Drawing.Size(244, 25)
        Me.lblTrans.TabIndex = 0
        Me.lblTrans.Text = "Cash IN"
        Me.lblTrans.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCashIn
        '
        Me.btnCashIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCashIn.Location = New System.Drawing.Point(12, 12)
        Me.btnCashIn.Name = "btnCashIn"
        Me.btnCashIn.Size = New System.Drawing.Size(88, 34)
        Me.btnCashIn.TabIndex = 0
        Me.btnCashIn.Text = "Cash In"
        Me.btnCashIn.UseVisualStyleBackColor = True
        '
        'btnPost
        '
        Me.btnPost.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPost.Location = New System.Drawing.Point(345, 222)
        Me.btnPost.Name = "btnPost"
        Me.btnPost.Size = New System.Drawing.Size(88, 29)
        Me.btnPost.TabIndex = 5
        Me.btnPost.Text = "&Post"
        Me.btnPost.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(439, 222)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 29)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'txtParticulars
        '
        Me.txtParticulars.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtParticulars.Location = New System.Drawing.Point(96, 110)
        Me.txtParticulars.Multiline = True
        Me.txtParticulars.Name = "txtParticulars"
        Me.txtParticulars.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtParticulars.Size = New System.Drawing.Size(431, 106)
        Me.txtParticulars.TabIndex = 4
        Me.txtParticulars.Text = resources.GetString("txtParticulars.Text")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 110)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 18)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Particulars"
        '
        'cboTransactions
        '
        Me.cboTransactions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTransactions.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTransactions.FormattingEnabled = True
        Me.cboTransactions.Location = New System.Drawing.Point(141, 52)
        Me.cboTransactions.Name = "cboTransactions"
        Me.cboTransactions.Size = New System.Drawing.Size(386, 26)
        Me.cboTransactions.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 18)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Transaction Type"
        '
        'btnCashOut
        '
        Me.btnCashOut.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCashOut.Location = New System.Drawing.Point(106, 12)
        Me.btnCashOut.Name = "btnCashOut"
        Me.btnCashOut.Size = New System.Drawing.Size(88, 34)
        Me.btnCashOut.TabIndex = 1
        Me.btnCashOut.Text = "Cash Out"
        Me.btnCashOut.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 18)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Amount"
        '
        'txtAmount
        '
        Me.txtAmount.Location = New System.Drawing.Point(96, 84)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(199, 20)
        Me.txtAmount.TabIndex = 3
        '
        'btnVoid
        '
        Me.btnVoid.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVoid.Location = New System.Drawing.Point(12, 222)
        Me.btnVoid.Name = "btnVoid"
        Me.btnVoid.Size = New System.Drawing.Size(88, 29)
        Me.btnVoid.TabIndex = 19
        Me.btnVoid.Text = "&Void"
        Me.btnVoid.UseVisualStyleBackColor = True
        '
        'frmCashInOut
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(539, 262)
        Me.Controls.Add(Me.btnVoid)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCashOut)
        Me.Controls.Add(Me.btnPost)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtParticulars)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboTransactions)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnCashIn)
        Me.Controls.Add(Me.lblTrans)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmCashInOut"
        Me.Text = "Cash In"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTrans As System.Windows.Forms.Label
    Friend WithEvents btnCashIn As System.Windows.Forms.Button
    Friend WithEvents btnPost As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents txtParticulars As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboTransactions As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnCashOut As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents btnVoid As System.Windows.Forms.Button
End Class
