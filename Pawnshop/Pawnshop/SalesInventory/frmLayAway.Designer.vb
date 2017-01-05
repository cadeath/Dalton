<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLayAway
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCustomerName = New System.Windows.Forms.TextBox()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.txtItemCode = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.btnAccept = New System.Windows.Forms.Button()
        Me.lblPenalty = New System.Windows.Forms.Label()
        Me.lblBalance = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtItemCode)
        Me.GroupBox1.Controls.Add(Me.txtAddress)
        Me.GroupBox1.Controls.Add(Me.txtCustomerName)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(383, 189)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(141, 18)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Customer Name: "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 18)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Address: "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 18)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "ItemCode: "
        '
        'txtCustomerName
        '
        Me.txtCustomerName.BackColor = System.Drawing.Color.White
        Me.txtCustomerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomerName.Location = New System.Drawing.Point(157, 15)
        Me.txtCustomerName.Name = "txtCustomerName"
        Me.txtCustomerName.ReadOnly = True
        Me.txtCustomerName.Size = New System.Drawing.Size(217, 22)
        Me.txtCustomerName.TabIndex = 4
        Me.txtCustomerName.Text = "Robin Padodot"
        '
        'txtAddress
        '
        Me.txtAddress.BackColor = System.Drawing.Color.White
        Me.txtAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress.Location = New System.Drawing.Point(157, 48)
        Me.txtAddress.Multiline = True
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.ReadOnly = True
        Me.txtAddress.Size = New System.Drawing.Size(217, 65)
        Me.txtAddress.TabIndex = 5
        Me.txtAddress.Text = "Madalas, Makita City"
        '
        'txtItemCode
        '
        Me.txtItemCode.BackColor = System.Drawing.Color.White
        Me.txtItemCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemCode.Location = New System.Drawing.Point(157, 119)
        Me.txtItemCode.Name = "txtItemCode"
        Me.txtItemCode.ReadOnly = True
        Me.txtItemCode.Size = New System.Drawing.Size(217, 22)
        Me.txtItemCode.TabIndex = 6
        Me.txtItemCode.Text = "ITM00001"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 195)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 18)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Penalty"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 226)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 18)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Balance"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 257)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 18)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Amout"
        '
        'txtAmount
        '
        Me.txtAmount.BackColor = System.Drawing.Color.White
        Me.txtAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmount.Location = New System.Drawing.Point(159, 256)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.ReadOnly = True
        Me.txtAmount.Size = New System.Drawing.Size(217, 22)
        Me.txtAmount.TabIndex = 7
        Me.txtAmount.Text = "15300"
        '
        'btnAccept
        '
        Me.btnAccept.Location = New System.Drawing.Point(301, 288)
        Me.btnAccept.Name = "btnAccept"
        Me.btnAccept.Size = New System.Drawing.Size(75, 33)
        Me.btnAccept.TabIndex = 10
        Me.btnAccept.Text = "&Accept"
        Me.btnAccept.UseVisualStyleBackColor = True
        '
        'lblPenalty
        '
        Me.lblPenalty.AutoSize = True
        Me.lblPenalty.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPenalty.Location = New System.Drawing.Point(156, 195)
        Me.lblPenalty.Name = "lblPenalty"
        Me.lblPenalty.Size = New System.Drawing.Size(35, 18)
        Me.lblPenalty.TabIndex = 11
        Me.lblPenalty.Text = "300"
        '
        'lblBalance
        '
        Me.lblBalance.AutoSize = True
        Me.lblBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBalance.Location = New System.Drawing.Point(156, 226)
        Me.lblBalance.Name = "lblBalance"
        Me.lblBalance.Size = New System.Drawing.Size(53, 18)
        Me.lblBalance.TabIndex = 12
        Me.lblBalance.Text = "15300"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(10, 150)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 18)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Description"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.White
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(157, 150)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(217, 22)
        Me.TextBox1.TabIndex = 8
        Me.TextBox1.Text = "Cellphone with no batt and screen"
        '
        'frmLayAway
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(390, 333)
        Me.Controls.Add(Me.lblBalance)
        Me.Controls.Add(Me.lblPenalty)
        Me.Controls.Add(Me.btnAccept)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmLayAway"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lay Away"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCustomerName As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtItemCode As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents btnAccept As System.Windows.Forms.Button
    Friend WithEvents lblPenalty As System.Windows.Forms.Label
    Friend WithEvents lblBalance As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
