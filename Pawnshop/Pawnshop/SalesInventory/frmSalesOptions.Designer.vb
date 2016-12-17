<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSalesOptions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSalesOptions))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSTO = New System.Windows.Forms.Button()
        Me.btnIMD = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnPTU = New System.Windows.Forms.Button()
        Me.btnRePrint = New System.Windows.Forms.Button()
        Me.monCal = New System.Windows.Forms.MonthCalendar()
        Me.btnInventory = New System.Windows.Forms.Button()
        Me.btnSaleReport = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSTO)
        Me.GroupBox1.Controls.Add(Me.btnIMD)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(234, 105)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Incoming"
        '
        'btnSTO
        '
        Me.btnSTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSTO.Location = New System.Drawing.Point(123, 28)
        Me.btnSTO.Name = "btnSTO"
        Me.btnSTO.Size = New System.Drawing.Size(85, 57)
        Me.btnSTO.TabIndex = 1
        Me.btnSTO.Text = "Stock Transfer In"
        Me.btnSTO.UseVisualStyleBackColor = True
        '
        'btnIMD
        '
        Me.btnIMD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIMD.Location = New System.Drawing.Point(20, 28)
        Me.btnIMD.Name = "btnIMD"
        Me.btnIMD.Size = New System.Drawing.Size(85, 57)
        Me.btnIMD.TabIndex = 0
        Me.btnIMD.Text = "Item Master Data"
        Me.btnIMD.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnPTU)
        Me.GroupBox2.Controls.Add(Me.btnRePrint)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 123)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(234, 105)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Export"
        '
        'btnPTU
        '
        Me.btnPTU.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPTU.Location = New System.Drawing.Point(123, 28)
        Me.btnPTU.Name = "btnPTU"
        Me.btnPTU.Size = New System.Drawing.Size(85, 57)
        Me.btnPTU.TabIndex = 1
        Me.btnPTU.Text = "Sales File"
        Me.btnPTU.UseVisualStyleBackColor = True
        '
        'btnRePrint
        '
        Me.btnRePrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRePrint.Location = New System.Drawing.Point(20, 28)
        Me.btnRePrint.Name = "btnRePrint"
        Me.btnRePrint.Size = New System.Drawing.Size(85, 57)
        Me.btnRePrint.TabIndex = 0
        Me.btnRePrint.Text = "Sales &List"
        Me.btnRePrint.UseVisualStyleBackColor = True
        '
        'monCal
        '
        Me.monCal.Location = New System.Drawing.Point(258, 18)
        Me.monCal.Name = "monCal"
        Me.monCal.TabIndex = 2
        '
        'btnInventory
        '
        Me.btnInventory.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInventory.Location = New System.Drawing.Point(400, 192)
        Me.btnInventory.Name = "btnInventory"
        Me.btnInventory.Size = New System.Drawing.Size(85, 36)
        Me.btnInventory.TabIndex = 3
        Me.btnInventory.Text = "&Inventory"
        Me.btnInventory.UseVisualStyleBackColor = True
        '
        'btnSaleReport
        '
        Me.btnSaleReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaleReport.Location = New System.Drawing.Point(258, 192)
        Me.btnSaleReport.Name = "btnSaleReport"
        Me.btnSaleReport.Size = New System.Drawing.Size(109, 36)
        Me.btnSaleReport.TabIndex = 4
        Me.btnSaleReport.Text = "&Sales Report"
        Me.btnSaleReport.UseVisualStyleBackColor = True
        '
        'frmSalesOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(500, 241)
        Me.Controls.Add(Me.btnSaleReport)
        Me.Controls.Add(Me.btnInventory)
        Me.Controls.Add(Me.monCal)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmSalesOptions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Options"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSTO As System.Windows.Forms.Button
    Friend WithEvents btnIMD As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnPTU As System.Windows.Forms.Button
    Friend WithEvents btnRePrint As System.Windows.Forms.Button
    Friend WithEvents monCal As System.Windows.Forms.MonthCalendar
    Friend WithEvents btnInventory As System.Windows.Forms.Button
    Friend WithEvents btnSaleReport As System.Windows.Forms.Button
End Class
