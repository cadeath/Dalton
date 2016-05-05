<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCashInOut2
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
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"1", "TICKETING", "Ticketing Fund Account", "1000"}, -1)
        Me.btnCashIn = New System.Windows.Forms.Button()
        Me.btnCashOut = New System.Windows.Forms.Button()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.gpTrans = New System.Windows.Forms.GroupBox()
        Me.cboTrans = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboCat = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.txtParticulars = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtAmt = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lvDetails = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnPost = New System.Windows.Forms.Button()
        Me.btnInvIn = New System.Windows.Forms.Button()
        Me.btnBDOCashOut = New System.Windows.Forms.Button()
        Me.webAds = New System.Windows.Forms.WebBrowser()
        Me.gpTrans.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCashIn
        '
        Me.btnCashIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCashIn.Location = New System.Drawing.Point(12, 12)
        Me.btnCashIn.Name = "btnCashIn"
        Me.btnCashIn.Size = New System.Drawing.Size(84, 60)
        Me.btnCashIn.TabIndex = 0
        Me.btnCashIn.Text = "Cash In"
        Me.btnCashIn.UseVisualStyleBackColor = True
        '
        'btnCashOut
        '
        Me.btnCashOut.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCashOut.Location = New System.Drawing.Point(12, 83)
        Me.btnCashOut.Name = "btnCashOut"
        Me.btnCashOut.Size = New System.Drawing.Size(84, 60)
        Me.btnCashOut.TabIndex = 1
        Me.btnCashOut.Text = "Cash Out"
        Me.btnCashOut.UseVisualStyleBackColor = True
        '
        'btnBrowse
        '
        Me.btnBrowse.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowse.Location = New System.Drawing.Point(12, 481)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(84, 37)
        Me.btnBrowse.TabIndex = 2
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'gpTrans
        '
        Me.gpTrans.Controls.Add(Me.cboTrans)
        Me.gpTrans.Controls.Add(Me.Label2)
        Me.gpTrans.Controls.Add(Me.cboCat)
        Me.gpTrans.Controls.Add(Me.Label1)
        Me.gpTrans.Location = New System.Drawing.Point(102, 12)
        Me.gpTrans.Name = "gpTrans"
        Me.gpTrans.Size = New System.Drawing.Size(746, 91)
        Me.gpTrans.TabIndex = 3
        Me.gpTrans.TabStop = False
        Me.gpTrans.Text = "Transaction"
        '
        'cboTrans
        '
        Me.cboTrans.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTrans.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTrans.FormattingEnabled = True
        Me.cboTrans.Location = New System.Drawing.Point(113, 48)
        Me.cboTrans.Name = "cboTrans"
        Me.cboTrans.Size = New System.Drawing.Size(428, 24)
        Me.cboTrans.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(21, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 18)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Transaction"
        '
        'cboCat
        '
        Me.cboCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCat.FormattingEnabled = True
        Me.cboCat.Location = New System.Drawing.Point(113, 18)
        Me.cboCat.Name = "cboCat"
        Me.cboCat.Size = New System.Drawing.Size(245, 24)
        Me.cboCat.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Category"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnRemove)
        Me.GroupBox2.Controls.Add(Me.btnAdd)
        Me.GroupBox2.Controls.Add(Me.txtParticulars)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtAmt)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(102, 109)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(746, 106)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Input"
        '
        'btnRemove
        '
        Me.btnRemove.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemove.Location = New System.Drawing.Point(419, 59)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(84, 37)
        Me.btnRemove.TabIndex = 3
        Me.btnRemove.Text = "&Remove"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(419, 16)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(84, 37)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.Text = "&Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'txtParticulars
        '
        Me.txtParticulars.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtParticulars.Location = New System.Drawing.Point(113, 40)
        Me.txtParticulars.Multiline = True
        Me.txtParticulars.Name = "txtParticulars"
        Me.txtParticulars.Size = New System.Drawing.Size(300, 56)
        Me.txtParticulars.TabIndex = 1
        Me.txtParticulars.Text = "0.00"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 18)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Particulars"
        '
        'txtAmt
        '
        Me.txtAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmt.Location = New System.Drawing.Point(113, 12)
        Me.txtAmt.Name = "txtAmt"
        Me.txtAmt.Size = New System.Drawing.Size(97, 22)
        Me.txtAmt.TabIndex = 0
        Me.txtAmt.Text = "0.00"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 18)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Amount"
        '
        'lvDetails
        '
        Me.lvDetails.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.lvDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvDetails.FullRowSelect = True
        Me.lvDetails.GridLines = True
        Me.lvDetails.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1})
        Me.lvDetails.Location = New System.Drawing.Point(102, 221)
        Me.lvDetails.MultiSelect = False
        Me.lvDetails.Name = "lvDetails"
        Me.lvDetails.Size = New System.Drawing.Size(746, 254)
        Me.lvDetails.TabIndex = 0
        Me.lvDetails.UseCompatibleStateImageBehavior = False
        Me.lvDetails.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "#"
        Me.ColumnHeader1.Width = 34
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Category"
        Me.ColumnHeader2.Width = 95
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Transaction Name"
        Me.ColumnHeader3.Width = 237
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Amount"
        Me.ColumnHeader4.Width = 96
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Particulars"
        Me.ColumnHeader5.Width = 206
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(764, 481)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(84, 37)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnPost
        '
        Me.btnPost.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPost.Location = New System.Drawing.Point(674, 481)
        Me.btnPost.Name = "btnPost"
        Me.btnPost.Size = New System.Drawing.Size(84, 37)
        Me.btnPost.TabIndex = 1
        Me.btnPost.Text = "&Post"
        Me.btnPost.UseVisualStyleBackColor = True
        '
        'btnInvIn
        '
        Me.btnInvIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInvIn.Location = New System.Drawing.Point(12, 155)
        Me.btnInvIn.Name = "btnInvIn"
        Me.btnInvIn.Size = New System.Drawing.Size(84, 60)
        Me.btnInvIn.TabIndex = 5
        Me.btnInvIn.Text = "Smart Money Inventory In"
        Me.btnInvIn.UseVisualStyleBackColor = True
        '
        'btnBDOCashOut
        '
        Me.btnBDOCashOut.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBDOCashOut.Location = New System.Drawing.Point(12, 221)
        Me.btnBDOCashOut.Name = "btnBDOCashOut"
        Me.btnBDOCashOut.Size = New System.Drawing.Size(84, 60)
        Me.btnBDOCashOut.TabIndex = 6
        Me.btnBDOCashOut.Text = "BDO ATM CashOut"
        Me.btnBDOCashOut.UseVisualStyleBackColor = True
        '
        'webAds
        '
        Me.webAds.Location = New System.Drawing.Point(103, 417)
        Me.webAds.MinimumSize = New System.Drawing.Size(20, 20)
        Me.webAds.Name = "webAds"
        Me.webAds.ScrollBarsEnabled = False
        Me.webAds.Size = New System.Drawing.Size(329, 56)
        Me.webAds.TabIndex = 7
        '
        'frmCashInOut2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(860, 530)
        Me.Controls.Add(Me.btnBDOCashOut)
        Me.Controls.Add(Me.btnInvIn)
        Me.Controls.Add(Me.btnPost)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.lvDetails)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.gpTrans)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.btnCashOut)
        Me.Controls.Add(Me.btnCashIn)
        Me.Controls.Add(Me.webAds)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmCashInOut2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cash In"
        Me.gpTrans.ResumeLayout(False)
        Me.gpTrans.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCashIn As System.Windows.Forms.Button
    Friend WithEvents btnCashOut As System.Windows.Forms.Button
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents gpTrans As System.Windows.Forms.GroupBox
    Friend WithEvents cboTrans As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboCat As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtParticulars As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lvDetails As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnPost As System.Windows.Forms.Button
    Friend WithEvents btnInvIn As System.Windows.Forms.Button
    Friend WithEvents btnBDOCashOut As System.Windows.Forms.Button
    Friend WithEvents webAds As System.Windows.Forms.WebBrowser
End Class
