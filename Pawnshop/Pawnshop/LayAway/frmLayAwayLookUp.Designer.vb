<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLayAwayLookUp
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
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"00001", "Robin Padodot", "ITM0001", "Cellphone / no screen", "15000", "10000"}, -1)
        Me.grpLayAway = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtPawner = New System.Windows.Forms.TextBox()
        Me.lvClient = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.grpLayAway.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpLayAway
        '
        Me.grpLayAway.Controls.Add(Me.Label1)
        Me.grpLayAway.Controls.Add(Me.btnSearch)
        Me.grpLayAway.Controls.Add(Me.txtPawner)
        Me.grpLayAway.Location = New System.Drawing.Point(12, 12)
        Me.grpLayAway.Name = "grpLayAway"
        Me.grpLayAway.Size = New System.Drawing.Size(479, 62)
        Me.grpLayAway.TabIndex = 5
        Me.grpLayAway.TabStop = False
        Me.grpLayAway.Text = "Search Lay Away"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(95, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 3
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(398, 23)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 2
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtPawner
        '
        Me.txtPawner.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPawner.Location = New System.Drawing.Point(6, 24)
        Me.txtPawner.Name = "txtPawner"
        Me.txtPawner.Size = New System.Drawing.Size(386, 22)
        Me.txtPawner.TabIndex = 1
        '
        'lvClient
        '
        Me.lvClient.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvClient.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6})
        Me.lvClient.FullRowSelect = True
        Me.lvClient.GridLines = True
        Me.lvClient.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem2})
        Me.lvClient.Location = New System.Drawing.Point(12, 80)
        Me.lvClient.Name = "lvClient"
        Me.lvClient.Size = New System.Drawing.Size(762, 267)
        Me.lvClient.TabIndex = 9
        Me.lvClient.UseCompatibleStateImageBehavior = False
        Me.lvClient.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 72
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Customer's Name"
        Me.ColumnHeader2.Width = 123
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "ItemCode"
        Me.ColumnHeader3.Width = 108
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Description"
        Me.ColumnHeader4.Width = 228
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Price"
        Me.ColumnHeader5.Width = 114
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(620, 353)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(74, 35)
        Me.btnSave.TabIndex = 12
        Me.btnSave.Text = "&Select"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.Location = New System.Drawing.Point(700, 353)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(74, 35)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "&Close"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Balance"
        Me.ColumnHeader6.Width = 112
        '
        'frmLayAwayLookUp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(786, 395)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.lvClient)
        Me.Controls.Add(Me.grpLayAway)
        Me.MaximumSize = New System.Drawing.Size(802, 433)
        Me.MinimumSize = New System.Drawing.Size(802, 433)
        Me.Name = "frmLayAwayLookUp"
        Me.Text = "Search Lay Away Plan Agreement"
        Me.grpLayAway.ResumeLayout(False)
        Me.grpLayAway.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpLayAway As System.Windows.Forms.GroupBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtPawner As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lvClient As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
End Class
