<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
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
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtStockOutNum = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtReturnNum = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtCashInvoice = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtMRNum = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtMENum = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtOR = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtInsurance = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtBorrow = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtPawnTicket = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtBranchAddr = New System.Windows.Forms.TextBox()
        Me.lblSAP02 = New System.Windows.Forms.Label()
        Me.txtCustomerCode = New System.Windows.Forms.TextBox()
        Me.txtCashInBank = New System.Windows.Forms.TextBox()
        Me.lblSAP01 = New System.Windows.Forms.Label()
        Me.txtRevolving = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtArea = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtBal = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.printerOR = New System.Windows.Forms.ComboBox()
        Me.printerPT = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(231, 415)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(85, 37)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(136, 415)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(81, 37)
        Me.btnUpdate.TabIndex = 2
        Me.btnUpdate.Text = "&Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(308, 398)
        Me.TabControl1.TabIndex = 5
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(300, 372)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Control Number"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(300, 372)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Branch"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtStockOutNum)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.txtReturnNum)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txtCashInvoice)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txtMRNum)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtMENum)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtOR)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtInsurance)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtBorrow)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtPawnTicket)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(230, 282)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Next Control Number"
        '
        'txtStockOutNum
        '
        Me.txtStockOutNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStockOutNum.Location = New System.Drawing.Point(124, 246)
        Me.txtStockOutNum.Name = "txtStockOutNum"
        Me.txtStockOutNum.Size = New System.Drawing.Size(100, 22)
        Me.txtStockOutNum.TabIndex = 29
        Me.txtStockOutNum.Text = "35"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(6, 249)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(93, 16)
        Me.Label17.TabIndex = 30
        Me.Label17.Text = "StockOut Num"
        '
        'txtReturnNum
        '
        Me.txtReturnNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReturnNum.Location = New System.Drawing.Point(124, 215)
        Me.txtReturnNum.Name = "txtReturnNum"
        Me.txtReturnNum.Size = New System.Drawing.Size(100, 22)
        Me.txtReturnNum.TabIndex = 27
        Me.txtReturnNum.Text = "35"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(6, 221)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(78, 16)
        Me.Label15.TabIndex = 28
        Me.Label15.Text = "Return Num"
        '
        'txtCashInvoice
        '
        Me.txtCashInvoice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCashInvoice.Location = New System.Drawing.Point(124, 187)
        Me.txtCashInvoice.Name = "txtCashInvoice"
        Me.txtCashInvoice.Size = New System.Drawing.Size(100, 22)
        Me.txtCashInvoice.TabIndex = 6
        Me.txtCashInvoice.Text = "35"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(6, 190)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(51, 16)
        Me.Label14.TabIndex = 26
        Me.Label14.Text = "Invoice"
        '
        'txtMRNum
        '
        Me.txtMRNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMRNum.Location = New System.Drawing.Point(124, 159)
        Me.txtMRNum.Name = "txtMRNum"
        Me.txtMRNum.Size = New System.Drawing.Size(100, 22)
        Me.txtMRNum.TabIndex = 5
        Me.txtMRNum.Text = "35"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 162)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 16)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "MR Num"
        '
        'txtMENum
        '
        Me.txtMENum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMENum.Location = New System.Drawing.Point(124, 131)
        Me.txtMENum.Name = "txtMENum"
        Me.txtMENum.Size = New System.Drawing.Size(100, 22)
        Me.txtMENum.TabIndex = 4
        Me.txtMENum.Text = "20"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 134)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 16)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "ME Num"
        '
        'txtOR
        '
        Me.txtOR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOR.Location = New System.Drawing.Point(124, 47)
        Me.txtOR.Name = "txtOR"
        Me.txtOR.Size = New System.Drawing.Size(100, 22)
        Me.txtOR.TabIndex = 1
        Me.txtOR.Text = "133"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 16)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "OR Number"
        '
        'txtInsurance
        '
        Me.txtInsurance.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInsurance.Location = New System.Drawing.Point(124, 103)
        Me.txtInsurance.Name = "txtInsurance"
        Me.txtInsurance.Size = New System.Drawing.Size(100, 22)
        Me.txtInsurance.TabIndex = 3
        Me.txtInsurance.Text = "35"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 109)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(66, 16)
        Me.Label12.TabIndex = 18
        Me.Label12.Text = "Insurance"
        '
        'txtBorrow
        '
        Me.txtBorrow.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBorrow.Location = New System.Drawing.Point(124, 75)
        Me.txtBorrow.Name = "txtBorrow"
        Me.txtBorrow.Size = New System.Drawing.Size(100, 22)
        Me.txtBorrow.TabIndex = 2
        Me.txtBorrow.Text = "20"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(6, 81)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(75, 16)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "Borrowings"
        '
        'txtPawnTicket
        '
        Me.txtPawnTicket.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPawnTicket.Location = New System.Drawing.Point(124, 19)
        Me.txtPawnTicket.Name = "txtPawnTicket"
        Me.txtPawnTicket.Size = New System.Drawing.Size(100, 22)
        Me.txtPawnTicket.TabIndex = 0
        Me.txtPawnTicket.Text = "133"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(6, 23)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(81, 16)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "Pawn Ticket"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.txtBranchAddr)
        Me.GroupBox2.Controls.Add(Me.lblSAP02)
        Me.GroupBox2.Controls.Add(Me.txtCustomerCode)
        Me.GroupBox2.Controls.Add(Me.txtCashInBank)
        Me.GroupBox2.Controls.Add(Me.lblSAP01)
        Me.GroupBox2.Controls.Add(Me.txtRevolving)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtArea)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtName)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtBal)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtCode)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(275, 338)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Branch"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(6, 283)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(104, 16)
        Me.Label16.TabIndex = 24
        Me.Label16.Text = "Branch Address"
        '
        'txtBranchAddr
        '
        Me.txtBranchAddr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBranchAddr.Location = New System.Drawing.Point(5, 302)
        Me.txtBranchAddr.Name = "txtBranchAddr"
        Me.txtBranchAddr.Size = New System.Drawing.Size(249, 22)
        Me.txtBranchAddr.TabIndex = 23
        Me.txtBranchAddr.Text = "Head Office"
        '
        'lblSAP02
        '
        Me.lblSAP02.AutoSize = True
        Me.lblSAP02.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSAP02.Location = New System.Drawing.Point(7, 230)
        Me.lblSAP02.Name = "lblSAP02"
        Me.lblSAP02.Size = New System.Drawing.Size(101, 16)
        Me.lblSAP02.TabIndex = 22
        Me.lblSAP02.Text = "Customer Code"
        '
        'txtCustomerCode
        '
        Me.txtCustomerCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomerCode.Location = New System.Drawing.Point(6, 249)
        Me.txtCustomerCode.Name = "txtCustomerCode"
        Me.txtCustomerCode.Size = New System.Drawing.Size(249, 22)
        Me.txtCustomerCode.TabIndex = 21
        Me.txtCustomerCode.Text = "10000"
        '
        'txtCashInBank
        '
        Me.txtCashInBank.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCashInBank.Location = New System.Drawing.Point(6, 199)
        Me.txtCashInBank.Name = "txtCashInBank"
        Me.txtCashInBank.Size = New System.Drawing.Size(252, 22)
        Me.txtCashInBank.TabIndex = 19
        Me.txtCashInBank.Text = "10000"
        '
        'lblSAP01
        '
        Me.lblSAP01.AutoSize = True
        Me.lblSAP01.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSAP01.Location = New System.Drawing.Point(6, 180)
        Me.lblSAP01.Name = "lblSAP01"
        Me.lblSAP01.Size = New System.Drawing.Size(86, 16)
        Me.lblSAP01.TabIndex = 20
        Me.lblSAP01.Text = "Cash in Bank"
        '
        'txtRevolving
        '
        Me.txtRevolving.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRevolving.Location = New System.Drawing.Point(6, 151)
        Me.txtRevolving.Name = "txtRevolving"
        Me.txtRevolving.Size = New System.Drawing.Size(252, 22)
        Me.txtRevolving.TabIndex = 4
        Me.txtRevolving.Text = "10000"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 132)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 16)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Revolving Fund"
        '
        'txtArea
        '
        Me.txtArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArea.Location = New System.Drawing.Point(99, 72)
        Me.txtArea.Name = "txtArea"
        Me.txtArea.Size = New System.Drawing.Size(159, 22)
        Me.txtArea.TabIndex = 2
        Me.txtArea.Text = "GSC"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 16)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Branch Area"
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(99, 44)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(159, 22)
        Me.txtName.TabIndex = 1
        Me.txtName.Text = "GENSAN ROXAS"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 16)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Branch Name"
        '
        'txtBal
        '
        Me.txtBal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBal.Location = New System.Drawing.Point(99, 100)
        Me.txtBal.Name = "txtBal"
        Me.txtBal.Size = New System.Drawing.Size(159, 22)
        Me.txtBal.TabIndex = 3
        Me.txtBal.Text = "10000"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 103)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 16)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Maintaining"
        '
        'txtCode
        '
        Me.txtCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCode.Location = New System.Drawing.Point(99, 16)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(100, 22)
        Me.txtCode.TabIndex = 0
        Me.txtCode.Text = "ROX"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 16)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Code"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.GroupBox3)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(300, 372)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Printer"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.printerOR)
        Me.GroupBox3.Controls.Add(Me.printerPT)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(279, 155)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Printer Settings"
        '
        'printerOR
        '
        Me.printerOR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.printerOR.FormattingEnabled = True
        Me.printerOR.Location = New System.Drawing.Point(20, 98)
        Me.printerOR.Name = "printerOR"
        Me.printerOR.Size = New System.Drawing.Size(234, 21)
        Me.printerOR.TabIndex = 20
        '
        'printerPT
        '
        Me.printerPT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.printerPT.FormattingEnabled = True
        Me.printerPT.Location = New System.Drawing.Point(20, 44)
        Me.printerPT.Name = "printerPT"
        Me.printerPT.Size = New System.Drawing.Size(234, 21)
        Me.printerPT.TabIndex = 19
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(17, 72)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(98, 16)
        Me.Label13.TabIndex = 18
        Me.Label13.Text = "Official Receipt"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(17, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 16)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Pawn Ticket"
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(328, 460)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtStockOutNum As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtReturnNum As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtCashInvoice As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtMRNum As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtMENum As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtOR As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtInsurance As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtBorrow As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtPawnTicket As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtBranchAddr As System.Windows.Forms.TextBox
    Friend WithEvents lblSAP02 As System.Windows.Forms.Label
    Friend WithEvents txtCustomerCode As System.Windows.Forms.TextBox
    Friend WithEvents txtCashInBank As System.Windows.Forms.TextBox
    Friend WithEvents lblSAP01 As System.Windows.Forms.Label
    Friend WithEvents txtRevolving As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtArea As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtBal As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents printerOR As System.Windows.Forms.ComboBox
    Friend WithEvents printerPT As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
