<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLayAwayPaymentList
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
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"LAY#00001", "02/22/2147", "ROBIN PADODOT JR.", "20000", "200"}, -1)
        Me.lvPayment = New System.Windows.Forms.ListView()
        Me.controlnum = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.dateofpayment = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.customer = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.amount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.penalty = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lblDesc = New System.Windows.Forms.Label()
        Me.btnVoid = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lvPayment
        '
        Me.lvPayment.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.controlnum, Me.dateofpayment, Me.customer, Me.amount, Me.penalty})
        Me.lvPayment.FullRowSelect = True
        Me.lvPayment.GridLines = True
        Me.lvPayment.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1})
        Me.lvPayment.Location = New System.Drawing.Point(12, 46)
        Me.lvPayment.Name = "lvPayment"
        Me.lvPayment.Size = New System.Drawing.Size(668, 287)
        Me.lvPayment.TabIndex = 1
        Me.lvPayment.UseCompatibleStateImageBehavior = False
        Me.lvPayment.View = System.Windows.Forms.View.Details
        '
        'controlnum
        '
        Me.controlnum.Text = "ControlNumber"
        Me.controlnum.Width = 104
        '
        'dateofpayment
        '
        Me.dateofpayment.Text = "Date"
        Me.dateofpayment.Width = 100
        '
        'customer
        '
        Me.customer.Text = "Customer"
        Me.customer.Width = 259
        '
        'amount
        '
        Me.amount.Text = "Amount"
        Me.amount.Width = 100
        '
        'penalty
        '
        Me.penalty.Text = "Penalty"
        Me.penalty.Width = 100
        '
        'lblDesc
        '
        Me.lblDesc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDesc.BackColor = System.Drawing.Color.DimGray
        Me.lblDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDesc.ForeColor = System.Drawing.Color.White
        Me.lblDesc.Location = New System.Drawing.Point(9, 9)
        Me.lblDesc.Name = "lblDesc"
        Me.lblDesc.Size = New System.Drawing.Size(671, 28)
        Me.lblDesc.TabIndex = 2
        Me.lblDesc.Text = "I HAVE LIVED ONCE MORE"
        Me.lblDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnVoid
        '
        Me.btnVoid.Location = New System.Drawing.Point(605, 339)
        Me.btnVoid.Name = "btnVoid"
        Me.btnVoid.Size = New System.Drawing.Size(75, 33)
        Me.btnVoid.TabIndex = 16
        Me.btnVoid.Text = "&Void"
        Me.btnVoid.UseVisualStyleBackColor = True
        '
        'frmLayAwayPaymentList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 377)
        Me.Controls.Add(Me.btnVoid)
        Me.Controls.Add(Me.lblDesc)
        Me.Controls.Add(Me.lvPayment)
        Me.MaximumSize = New System.Drawing.Size(708, 415)
        Me.MinimumSize = New System.Drawing.Size(708, 415)
        Me.Name = "frmLayAwayPaymentList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Layaway Payment List"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lvPayment As System.Windows.Forms.ListView
    Friend WithEvents controlnum As System.Windows.Forms.ColumnHeader
    Friend WithEvents dateofpayment As System.Windows.Forms.ColumnHeader
    Friend WithEvents customer As System.Windows.Forms.ColumnHeader
    Friend WithEvents amount As System.Windows.Forms.ColumnHeader
    Friend WithEvents penalty As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblDesc As System.Windows.Forms.Label
    Friend WithEvents btnVoid As System.Windows.Forms.Button
End Class
