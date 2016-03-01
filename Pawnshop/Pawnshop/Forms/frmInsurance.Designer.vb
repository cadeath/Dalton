<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInsurance
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInsurance))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtBirthdate = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtSenderID = New System.Windows.Forms.TextBox()
        Me.txtSenderIDNum = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSenderAddr = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtHolder = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.txtCoi = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtPT = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtpExpiry = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnVoid = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.txtBirthdate)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.txtSenderID)
        Me.GroupBox1.Controls.Add(Me.txtSenderIDNum)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtSenderAddr)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btnSearch)
        Me.GroupBox1.Controls.Add(Me.txtHolder)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI Symbol", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(1, 94)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(499, 193)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Policy Holder"
        '
        'txtBirthdate
        '
        Me.txtBirthdate.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBirthdate.Location = New System.Drawing.Point(120, 162)
        Me.txtBirthdate.Name = "txtBirthdate"
        Me.txtBirthdate.ReadOnly = True
        Me.txtBirthdate.Size = New System.Drawing.Size(296, 25)
        Me.txtBirthdate.TabIndex = 25
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label17.Location = New System.Drawing.Point(44, 160)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(66, 17)
        Me.Label17.TabIndex = 24
        Me.Label17.Text = "Birthday: "
        '
        'txtSenderID
        '
        Me.txtSenderID.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSenderID.Location = New System.Drawing.Point(120, 108)
        Me.txtSenderID.Name = "txtSenderID"
        Me.txtSenderID.ReadOnly = True
        Me.txtSenderID.Size = New System.Drawing.Size(296, 25)
        Me.txtSenderID.TabIndex = 4
        '
        'txtSenderIDNum
        '
        Me.txtSenderIDNum.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSenderIDNum.Location = New System.Drawing.Point(120, 134)
        Me.txtSenderIDNum.Name = "txtSenderIDNum"
        Me.txtSenderIDNum.ReadOnly = True
        Me.txtSenderIDNum.Size = New System.Drawing.Size(296, 25)
        Me.txtSenderIDNum.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label4.Location = New System.Drawing.Point(-1, 108)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 17)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "ID Information:"
        '
        'txtSenderAddr
        '
        Me.txtSenderAddr.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSenderAddr.Location = New System.Drawing.Point(121, 37)
        Me.txtSenderAddr.Multiline = True
        Me.txtSenderAddr.Name = "txtSenderAddr"
        Me.txtSenderAddr.ReadOnly = True
        Me.txtSenderAddr.Size = New System.Drawing.Size(296, 67)
        Me.txtSenderAddr.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label3.Location = New System.Drawing.Point(14, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 17)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Full Address:"
        '
        'btnSearch
        '
        Me.btnSearch.Enabled = False
        Me.btnSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSearch.Location = New System.Drawing.Point(438, 13)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(55, 23)
        Me.btnSearch.TabIndex = 2
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtHolder
        '
        Me.txtHolder.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHolder.Location = New System.Drawing.Point(120, 13)
        Me.txtHolder.Name = "txtHolder"
        Me.txtHolder.ReadOnly = True
        Me.txtHolder.Size = New System.Drawing.Size(296, 25)
        Me.txtHolder.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label2.Location = New System.Drawing.Point(52, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Name:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label7.Location = New System.Drawing.Point(47, 14)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 17)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "COI No:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label5.Location = New System.Drawing.Point(46, 113)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 17)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Amount:"
        '
        'txtAmount
        '
        Me.txtAmount.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmount.Location = New System.Drawing.Point(122, 114)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.ReadOnly = True
        Me.txtAmount.Size = New System.Drawing.Size(107, 25)
        Me.txtAmount.TabIndex = 8
        Me.txtAmount.Text = "20"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label1.Location = New System.Drawing.Point(8, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 17)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Current Date: "
        '
        'dtpDate
        '
        Me.dtpDate.Enabled = False
        Me.dtpDate.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDate.Location = New System.Drawing.Point(122, 35)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(108, 25)
        Me.dtpDate.TabIndex = 6
        '
        'txtCoi
        '
        Me.txtCoi.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCoi.Location = New System.Drawing.Point(120, 9)
        Me.txtCoi.Name = "txtCoi"
        Me.txtCoi.ReadOnly = True
        Me.txtCoi.Size = New System.Drawing.Size(108, 25)
        Me.txtCoi.TabIndex = 4
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox2.Controls.Add(Me.txtPT)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.dtpExpiry)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtCoi)
        Me.GroupBox2.Controls.Add(Me.dtpDate)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtAmount)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI Symbol", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.Desktop
        Me.GroupBox2.Location = New System.Drawing.Point(1, 299)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(499, 149)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Insurance Information"
        '
        'txtPT
        '
        Me.txtPT.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPT.Location = New System.Drawing.Point(121, 88)
        Me.txtPT.Name = "txtPT"
        Me.txtPT.Size = New System.Drawing.Size(108, 25)
        Me.txtPT.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label8.Location = New System.Drawing.Point(48, 93)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 17)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "Ref No:"
        '
        'dtpExpiry
        '
        Me.dtpExpiry.Enabled = False
        Me.dtpExpiry.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpExpiry.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpExpiry.Location = New System.Drawing.Point(122, 60)
        Me.dtpExpiry.Name = "dtpExpiry"
        Me.dtpExpiry.Size = New System.Drawing.Size(108, 25)
        Me.dtpExpiry.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label6.Location = New System.Drawing.Point(24, 60)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 17)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "Valid Until: "
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox3.Controls.Add(Me.btnBrowse)
        Me.GroupBox3.Controls.Add(Me.btnNew)
        Me.GroupBox3.Controls.Add(Me.btnVoid)
        Me.GroupBox3.Controls.Add(Me.btnClose)
        Me.GroupBox3.Controls.Add(Me.btnSave)
        Me.GroupBox3.Font = New System.Drawing.Font("Segoe UI Symbol", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(1, -1)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(499, 83)
        Me.GroupBox3.TabIndex = 28
        Me.GroupBox3.TabStop = False
        '
        'btnBrowse
        '
        Me.btnBrowse.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnBrowse.BackgroundImage = CType(resources.GetObject("btnBrowse.BackgroundImage"), System.Drawing.Image)
        Me.btnBrowse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnBrowse.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowse.ForeColor = System.Drawing.Color.Black
        Me.btnBrowse.Location = New System.Drawing.Point(180, 21)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(78, 55)
        Me.btnBrowse.TabIndex = 42
        Me.btnBrowse.Text = "&Browse"
        Me.btnBrowse.UseVisualStyleBackColor = False
        '
        'btnNew
        '
        Me.btnNew.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnNew.BackgroundImage = CType(resources.GetObject("btnNew.BackgroundImage"), System.Drawing.Image)
        Me.btnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnNew.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.ForeColor = System.Drawing.Color.Black
        Me.btnNew.Location = New System.Drawing.Point(24, 21)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(78, 55)
        Me.btnNew.TabIndex = 41
        Me.btnNew.Text = "&New"
        Me.btnNew.UseVisualStyleBackColor = False
        '
        'btnVoid
        '
        Me.btnVoid.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnVoid.BackgroundImage = CType(resources.GetObject("btnVoid.BackgroundImage"), System.Drawing.Image)
        Me.btnVoid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnVoid.Enabled = False
        Me.btnVoid.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnVoid.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVoid.ForeColor = System.Drawing.Color.Black
        Me.btnVoid.Location = New System.Drawing.Point(102, 21)
        Me.btnVoid.Name = "btnVoid"
        Me.btnVoid.Size = New System.Drawing.Size(78, 55)
        Me.btnVoid.TabIndex = 40
        Me.btnVoid.Text = "&Void"
        Me.btnVoid.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnClose.BackgroundImage = CType(resources.GetObject("btnClose.BackgroundImage"), System.Drawing.Image)
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnClose.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.Black
        Me.btnClose.Location = New System.Drawing.Point(338, 21)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(79, 55)
        Me.btnClose.TabIndex = 10
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnSave.BackgroundImage = CType(resources.GetObject("btnSave.BackgroundImage"), System.Drawing.Image)
        Me.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnSave.Enabled = False
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.Black
        Me.btnSave.Location = New System.Drawing.Point(257, 21)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(82, 55)
        Me.btnSave.TabIndex = 9
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'frmInsurance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(500, 451)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Name = "frmInsurance"
        Me.Text = "Certificate of Insurance"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtSenderID As System.Windows.Forms.TextBox
    Friend WithEvents txtSenderIDNum As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSenderAddr As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtHolder As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtCoi As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpExpiry As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnVoid As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtBirthdate As System.Windows.Forms.TextBox
    Friend WithEvents txtPT As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
