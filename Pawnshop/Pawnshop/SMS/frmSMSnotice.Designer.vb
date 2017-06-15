<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSMSnotice
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
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"151543", "Eskie Maquilang", "092579775595", "Ring", "1000"}, -1)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSMSnotice))
        Me.lvExpiry = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.btnChange = New System.Windows.Forms.Button()
        Me.chkAll = New System.Windows.Forms.CheckBox()
        Me.btnView = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lvExpiry
        '
        Me.lvExpiry.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvExpiry.CheckBoxes = True
        Me.lvExpiry.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7})
        Me.lvExpiry.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvExpiry.FullRowSelect = True
        Me.lvExpiry.GridLines = True
        ListViewItem1.StateImageIndex = 0
        Me.lvExpiry.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1})
        Me.lvExpiry.Location = New System.Drawing.Point(12, 33)
        Me.lvExpiry.Name = "lvExpiry"
        Me.lvExpiry.Size = New System.Drawing.Size(776, 225)
        Me.lvExpiry.TabIndex = 1
        Me.lvExpiry.UseCompatibleStateImageBehavior = False
        Me.lvExpiry.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "PawnTicket"
        Me.ColumnHeader1.Width = 96
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Customer"
        Me.ColumnHeader2.Width = 187
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Contact"
        Me.ColumnHeader3.Width = 118
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Item Class"
        Me.ColumnHeader4.Width = 100
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Principal"
        Me.ColumnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader5.Width = 83
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Expiry Date"
        Me.ColumnHeader6.Width = 84
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Auction Date"
        Me.ColumnHeader7.Width = 95
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(713, 264)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 40)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSend
        '
        Me.btnSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSend.Location = New System.Drawing.Point(632, 264)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(75, 40)
        Me.btnSend.TabIndex = 4
        Me.btnSend.Text = "&Send"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'btnChange
        '
        Me.btnChange.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnChange.Location = New System.Drawing.Point(12, 264)
        Me.btnChange.Name = "btnChange"
        Me.btnChange.Size = New System.Drawing.Size(86, 40)
        Me.btnChange.TabIndex = 2
        Me.btnChange.Text = "&Change Num"
        Me.btnChange.UseVisualStyleBackColor = True
        '
        'chkAll
        '
        Me.chkAll.AutoSize = True
        Me.chkAll.Location = New System.Drawing.Point(12, 12)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(70, 17)
        Me.chkAll.TabIndex = 0
        Me.chkAll.Text = "Select All"
        Me.chkAll.UseVisualStyleBackColor = True
        '
        'btnView
        '
        Me.btnView.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnView.Location = New System.Drawing.Point(104, 264)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(86, 40)
        Me.btnView.TabIndex = 3
        Me.btnView.Text = "&View"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'frmSMSnotice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(802, 314)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.chkAll)
        Me.Controls.Add(Me.btnChange)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.lvExpiry)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmSMSnotice"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Expiry Notification"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvExpiry As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents btnChange As System.Windows.Forms.Button
    Friend WithEvents chkAll As System.Windows.Forms.CheckBox
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnView As System.Windows.Forms.Button
End Class
