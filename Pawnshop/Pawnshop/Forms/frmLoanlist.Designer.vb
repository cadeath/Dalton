<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLoanlist
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
        Me.lvClient = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'lvClient
        '
        Me.lvClient.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvClient.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6})
        Me.lvClient.FullRowSelect = True
        Me.lvClient.GridLines = True
        Me.lvClient.Location = New System.Drawing.Point(25, 25)
        Me.lvClient.Name = "lvClient"
        Me.lvClient.Size = New System.Drawing.Size(760, 351)
        Me.lvClient.TabIndex = 8
        Me.lvClient.UseCompatibleStateImageBehavior = False
        Me.lvClient.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Ticket Number"
        Me.ColumnHeader1.Width = 90
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Pawner's Name"
        Me.ColumnHeader2.Width = 215
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Item Description"
        Me.ColumnHeader3.Width = 138
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Principal"
        Me.ColumnHeader4.Width = 114
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Item Type"
        Me.ColumnHeader5.Width = 98
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Category"
        Me.ColumnHeader6.Width = 180
        '
        'frmLoanlist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(809, 429)
        Me.Controls.Add(Me.lvClient)
        Me.Name = "frmLoanlist"
        Me.Text = "Loan List"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lvClient As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
End Class
