<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCustomerImage
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCustomerImage))
        Me.dgCustImage = New System.Windows.Forms.DataGridView()
        Me.btnSelect = New System.Windows.Forms.Button()
        CType(Me.dgCustImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgCustImage
        '
        Me.dgCustImage.AllowUserToAddRows = False
        Me.dgCustImage.AllowUserToDeleteRows = False
        Me.dgCustImage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCustImage.Location = New System.Drawing.Point(12, 12)
        Me.dgCustImage.Name = "dgCustImage"
        Me.dgCustImage.ReadOnly = True
        Me.dgCustImage.RowHeadersVisible = False
        Me.dgCustImage.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCustImage.Size = New System.Drawing.Size(315, 372)
        Me.dgCustImage.TabIndex = 0
        '
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(233, 390)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(90, 33)
        Me.btnSelect.TabIndex = 1
        Me.btnSelect.Text = "&Selelct"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'frmCustomerImage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(335, 430)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.dgCustImage)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCustomerImage"
        Me.Text = "Customer Image"
        CType(Me.dgCustImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgCustImage As System.Windows.Forms.DataGridView
    Friend WithEvents btnSelect As System.Windows.Forms.Button
End Class
