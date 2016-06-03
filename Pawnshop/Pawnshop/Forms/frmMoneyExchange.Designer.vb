<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmmoneyexchange
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmmoneyexchange))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.buttonSearch = New System.Windows.Forms.Button()
        Me.txtCurrency = New System.Windows.Forms.TextBox()
        Me.txtDenomination = New System.Windows.Forms.TextBox()
        Me.symbol = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSymbol = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txRate = New System.Windows.Forms.TextBox()
        Me.label = New System.Windows.Forms.Label()
        Me.txtTotalAmount = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnsearch = New System.Windows.Forms.Button()
        Me.txtSerial = New System.Windows.Forms.TextBox()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnsave = New System.Windows.Forms.Button()
        Me.btnBrowse = New System.Windows.Forms.Button()

        Me.btnModify = New System.Windows.Forms.Button()
        Me.btnSearch1 = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
<<<<<<< HEAD
        Me.txtDenomination1 = New System.Windows.Forms.TextBox()
        Me.txtRate = New System.Windows.Forms.TextBox()
        Me.txtCurrency1 = New System.Windows.Forms.TextBox()

        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtRate = New System.Windows.Forms.TextBox()
        Me.txtCashID = New System.Windows.Forms.TextBox()
        Me.txtDenomination1 = New System.Windows.Forms.TextBox()
        Me.txtSymbol1 = New System.Windows.Forms.TextBox()
        Me.txtCurrency1 = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape3 = New Microsoft.VisualBasic.PowerPacks.LineShape()
>>>>>>> refs/remotes/origin/money-exchange
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Currency"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.buttonSearch)
        Me.GroupBox1.Controls.Add(Me.txtCurrency)
        Me.GroupBox1.Controls.Add(Me.txtDenomination)
        Me.GroupBox1.Controls.Add(Me.symbol)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtSymbol)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txRate)
        Me.GroupBox1.Controls.Add(Me.label)
        Me.GroupBox1.Controls.Add(Me.txtTotalAmount)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 0)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'buttonSearch
        '
        Me.buttonSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.buttonSearch.Location = New System.Drawing.Point(308, 15)
        Me.buttonSearch.Name = "buttonSearch"
        Me.buttonSearch.Size = New System.Drawing.Size(75, 30)
        Me.buttonSearch.TabIndex = 16
        Me.buttonSearch.Text = "Search"
        Me.buttonSearch.UseVisualStyleBackColor = True
        '
        'txtCurrency
        '
        Me.txtCurrency.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCurrency.Location = New System.Drawing.Point(81, 16)
        Me.txtCurrency.Name = "txtCurrency"
        Me.txtCurrency.Size = New System.Drawing.Size(221, 26)
        Me.txtCurrency.TabIndex = 15
        '
        'txtDenomination
        '
        Me.txtDenomination.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDenomination.Location = New System.Drawing.Point(163, 151)
        Me.txtDenomination.Name = "txtDenomination"
        Me.txtDenomination.Size = New System.Drawing.Size(120, 26)
        Me.txtDenomination.TabIndex = 14
        '
        'symbol
        '
        Me.symbol.AutoSize = True
        Me.symbol.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.symbol.Location = New System.Drawing.Point(20, 197)
        Me.symbol.Name = "symbol"
        Me.symbol.Size = New System.Drawing.Size(0, 20)
        Me.symbol.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(159, 128)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(108, 20)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Denomination"
        '
        'txtSymbol
        '
        Me.txtSymbol.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSymbol.Location = New System.Drawing.Point(81, 48)
        Me.txtSymbol.Name = "txtSymbol"
        Me.txtSymbol.ReadOnly = True
        Me.txtSymbol.Size = New System.Drawing.Size(221, 26)
        Me.txtSymbol.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 20)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Symbol"
        '
        'txRate
        '
        Me.txRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txRate.Location = New System.Drawing.Point(41, 151)
        Me.txRate.Name = "txRate"
        Me.txRate.Size = New System.Drawing.Size(116, 26)
        Me.txRate.TabIndex = 6
        '
        'label
        '
        Me.label.AutoSize = True
        Me.label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label.Location = New System.Drawing.Point(39, 128)
        Me.label.Name = "label"
        Me.label.Size = New System.Drawing.Size(44, 20)
        Me.label.TabIndex = 5
        Me.label.Text = "Rate"
        '
        'txtTotalAmount
        '
        Me.txtTotalAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalAmount.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.txtTotalAmount.Location = New System.Drawing.Point(163, 190)
        Me.txtTotalAmount.Name = "txtTotalAmount"
        Me.txtTotalAmount.ReadOnly = True
        Me.txtTotalAmount.Size = New System.Drawing.Size(134, 26)
        Me.txtTotalAmount.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(17, 194)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(140, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Total Amount Php:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(422, 21)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(43, 16)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Serial"
        '
        'btnsearch
        '
        Me.btnsearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsearch.Location = New System.Drawing.Point(699, 48)
        Me.btnsearch.Name = "btnsearch"
        Me.btnsearch.Size = New System.Drawing.Size(71, 24)
        Me.btnsearch.TabIndex = 15
        Me.btnsearch.Text = "Search"
        Me.btnsearch.UseVisualStyleBackColor = True
        '
        'txtSerial
        '
        Me.txtSerial.Location = New System.Drawing.Point(467, 18)
        Me.txtSerial.Name = "txtSerial"
        Me.txtSerial.Size = New System.Drawing.Size(185, 22)
<<<<<<< HEAD
        Me.txtSerial.TabIndex = 0
=======
        Me.txtSerial.TabIndex = 4
>>>>>>> refs/remotes/origin/money-exchange
        Me.txtSerial.Text = "ANOISIMEILLE"
        '
        'TxtName
        '
        Me.TxtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtName.Location = New System.Drawing.Point(466, 50)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(230, 22)
<<<<<<< HEAD
        Me.TxtName.TabIndex = 1
=======
        Me.TxtName.TabIndex = 5
>>>>>>> refs/remotes/origin/money-exchange
        Me.TxtName.Text = "ELLIE MISIONA"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(419, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Name"
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(638, 106)
        Me.btnCancel.Name = "btnCancel"
<<<<<<< HEAD
        Me.btnCancel.Size = New System.Drawing.Size(107, 25)
        Me.btnCancel.TabIndex = 1
=======
        Me.btnCancel.Size = New System.Drawing.Size(82, 26)
        Me.btnCancel.TabIndex = 7
>>>>>>> refs/remotes/origin/money-exchange
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnsave
        '
        Me.btnsave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsave.Location = New System.Drawing.Point(552, 106)
        Me.btnsave.Name = "btnsave"
<<<<<<< HEAD
        Me.btnsave.Size = New System.Drawing.Size(119, 25)
        Me.btnsave.TabIndex = 0
=======
        Me.btnsave.Size = New System.Drawing.Size(82, 26)
        Me.btnsave.TabIndex = 6
>>>>>>> refs/remotes/origin/money-exchange
        Me.btnsave.Text = "&Save"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'btnBrowse
        '
        Me.btnBrowse.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowse.Location = New System.Drawing.Point(466, 106)
        Me.btnBrowse.Name = "btnBrowse"
<<<<<<< HEAD
        Me.btnBrowse.Size = New System.Drawing.Size(112, 26)
        Me.btnBrowse.TabIndex = 2
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GroupBox4.Controls.Add(Me.btnModify)
        Me.GroupBox4.Controls.Add(Me.btnSearch1)
        Me.GroupBox4.Controls.Add(Me.txtCashID)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.txtSymbol1)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.txtDenomination1)
        Me.GroupBox4.Controls.Add(Me.txtRate)
        Me.GroupBox4.Controls.Add(Me.txtCurrency1)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(7, 10)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(407, 150)
        Me.GroupBox4.TabIndex = 6
        Me.GroupBox4.TabStop = False
        '
        'txtCashID
        '
        Me.txtCashID.Location = New System.Drawing.Point(273, 78)
        Me.txtCashID.Name = "txtCashID"
        Me.txtCashID.ReadOnly = True
        Me.txtCashID.Size = New System.Drawing.Size(16, 22)
        Me.txtCashID.TabIndex = 12
        Me.txtCashID.Visible = False
=======
        Me.btnBrowse.Size = New System.Drawing.Size(82, 26)
        Me.btnBrowse.TabIndex = 8
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'btnModify
        '
        Me.btnModify.Location = New System.Drawing.Point(218, 105)
        Me.btnModify.Name = "btnModify"
        Me.btnModify.Size = New System.Drawing.Size(59, 23)
        Me.btnModify.TabIndex = 14
        Me.btnModify.Text = "&Modify"
        Me.btnModify.UseVisualStyleBackColor = True
        '
        'btnSearch1
        '
        Me.btnSearch1.Location = New System.Drawing.Point(312, 14)
        Me.btnSearch1.Name = "btnSearch1"
        Me.btnSearch1.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch1.TabIndex = 13
        Me.btnSearch1.Text = "Search"
        Me.btnSearch1.UseVisualStyleBackColor = True
>>>>>>> refs/remotes/origin/money-exchange
        '
        'Label10
        '
        Me.Label10.AutoSize = True
<<<<<<< HEAD
        Me.Label10.Location = New System.Drawing.Point(38, 51)
=======
        Me.Label10.Location = New System.Drawing.Point(38, 45)
>>>>>>> refs/remotes/origin/money-exchange
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 16)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Symbol"
        '
<<<<<<< HEAD
        'txtSymbol1
        '
        Me.txtSymbol1.Location = New System.Drawing.Point(92, 48)
        Me.txtSymbol1.Name = "txtSymbol1"
        Me.txtSymbol1.ReadOnly = True
        Me.txtSymbol1.Size = New System.Drawing.Size(230, 22)
        Me.txtSymbol1.TabIndex = 11
        Me.txtSymbol1.Text = "USD"
        '
=======
>>>>>>> refs/remotes/origin/money-exchange
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(3, 76)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(91, 16)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Denomination"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
<<<<<<< HEAD
        Me.Label8.Location = New System.Drawing.Point(55, 112)
=======
        Me.Label8.Location = New System.Drawing.Point(55, 106)
>>>>>>> refs/remotes/origin/money-exchange
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 16)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Rate"
        '
<<<<<<< HEAD
        'txtDenomination1
        '
        Me.txtDenomination1.Location = New System.Drawing.Point(93, 78)
        Me.txtDenomination1.Name = "txtDenomination1"
        Me.txtDenomination1.Size = New System.Drawing.Size(176, 22)
        Me.txtDenomination1.TabIndex = 1
        Me.txtDenomination1.Text = "1"
        '
        'txtRate
        '
        Me.txtRate.Location = New System.Drawing.Point(92, 110)
        Me.txtRate.Name = "txtRate"
        Me.txtRate.Size = New System.Drawing.Size(94, 22)
        Me.txtRate.TabIndex = 2
        Me.txtRate.Text = "46.51"
        '
        'txtCurrency1
        '
        Me.txtCurrency1.Location = New System.Drawing.Point(91, 19)
        Me.txtCurrency1.Name = "txtCurrency1"
        Me.txtCurrency1.Size = New System.Drawing.Size(231, 22)
        Me.txtCurrency1.TabIndex = 0
        Me.txtCurrency1.Text = "US DOLLAR"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(30, 21)
=======
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(30, 15)
>>>>>>> refs/remotes/origin/money-exchange
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 16)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Currency"
        '
        'btnCalculate
        '
<<<<<<< HEAD
        Me.btnCalculate.Location = New System.Drawing.Point(287, 19)
        Me.btnCalculate.Name = "btnCalculate"
        Me.btnCalculate.Size = New System.Drawing.Size(92, 25)
        Me.btnCalculate.TabIndex = 0
=======
        Me.btnCalculate.Location = New System.Drawing.Point(279, 179)
        Me.btnCalculate.Name = "btnCalculate"
        Me.btnCalculate.Size = New System.Drawing.Size(77, 25)
        Me.btnCalculate.TabIndex = 3
>>>>>>> refs/remotes/origin/money-exchange
        Me.btnCalculate.Text = "Calculate"
        Me.btnCalculate.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 181)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 16)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Total Amount:"
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.LightGray
        Me.txtTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotal.Location = New System.Drawing.Point(105, 181)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(172, 22)
        Me.txtTotal.TabIndex = 13
        Me.txtTotal.Text = "0.00"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(523, 159)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(153, 25)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "Dollar Buying"
        '
        'txtRate
        '
        Me.txtRate.Location = New System.Drawing.Point(94, 106)
        Me.txtRate.Name = "txtRate"
        Me.txtRate.Size = New System.Drawing.Size(120, 22)
        Me.txtRate.TabIndex = 2
        Me.txtRate.Text = "46.51"
        '
        'txtCashID
        '
        Me.txtCashID.Location = New System.Drawing.Point(217, 75)
        Me.txtCashID.Name = "txtCashID"
        Me.txtCashID.Size = New System.Drawing.Size(13, 22)
        Me.txtCashID.TabIndex = 12
        Me.txtCashID.Visible = False
        '
        'txtDenomination1
        '
        Me.txtDenomination1.Location = New System.Drawing.Point(94, 75)
        Me.txtDenomination1.Name = "txtDenomination1"
        Me.txtDenomination1.Size = New System.Drawing.Size(120, 22)
        Me.txtDenomination1.TabIndex = 1
        Me.txtDenomination1.Text = "1"
        '
        'txtSymbol1
        '
        Me.txtSymbol1.Location = New System.Drawing.Point(94, 47)
        Me.txtSymbol1.Name = "txtSymbol1"
        Me.txtSymbol1.Size = New System.Drawing.Size(120, 22)
        Me.txtSymbol1.TabIndex = 11
        Me.txtSymbol1.Text = "USD"
        '
        'txtCurrency1
        '
        Me.txtCurrency1.Location = New System.Drawing.Point(94, 15)
        Me.txtCurrency1.Name = "txtCurrency1"
        Me.txtCurrency1.Size = New System.Drawing.Size(214, 22)
        Me.txtCurrency1.TabIndex = 0
        Me.txtCurrency1.Text = "US DOLLAR"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnCancel)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.btnsave)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.btnBrowse)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtTotal)
        Me.GroupBox2.Controls.Add(Me.txtCurrency1)
        Me.GroupBox2.Controls.Add(Me.btnsearch)
        Me.GroupBox2.Controls.Add(Me.txtSymbol1)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtSerial)
        Me.GroupBox2.Controls.Add(Me.txtDenomination1)
        Me.GroupBox2.Controls.Add(Me.btnSearch1)
        Me.GroupBox2.Controls.Add(Me.txtCashID)
        Me.GroupBox2.Controls.Add(Me.TxtName)
        Me.GroupBox2.Controls.Add(Me.txtRate)
        Me.GroupBox2.Controls.Add(Me.btnCalculate)
        Me.GroupBox2.Controls.Add(Me.btnModify)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.ShapeContainer1)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(2, 14)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(780, 218)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(3, 18)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape3, Me.LineShape2, Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(774, 197)
        Me.ShapeContainer1.TabIndex = 16
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 402
        Me.LineShape1.X2 = 402
        Me.LineShape1.Y1 = -10
        Me.LineShape1.Y2 = 199
        '
        'LineShape2
        '
        Me.LineShape2.Name = "LineShape2"
        Me.LineShape2.X1 = -3
        Me.LineShape2.X2 = 401
        Me.LineShape2.Y1 = 137
        Me.LineShape2.Y2 = 137
        '
        'LineShape3
        '
        Me.LineShape3.Name = "LineShape3"
        Me.LineShape3.X1 = 403
        Me.LineShape3.X2 = 775
        Me.LineShape3.Y1 = 70
        Me.LineShape3.Y2 = 69
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(539, 180)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(153, 25)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "Dollar Buying"
        '
        'btnSearch1
        '
        Me.btnSearch1.Location = New System.Drawing.Point(326, 18)
        Me.btnSearch1.Name = "btnSearch1"
        Me.btnSearch1.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch1.TabIndex = 13
        Me.btnSearch1.Text = "Search"
        Me.btnSearch1.UseVisualStyleBackColor = True
        '
        'btnModify
        '
        Me.btnModify.Location = New System.Drawing.Point(192, 110)
        Me.btnModify.Name = "btnModify"
        Me.btnModify.Size = New System.Drawing.Size(75, 23)
        Me.btnModify.TabIndex = 14
        Me.btnModify.Text = "&Modify"
        Me.btnModify.UseVisualStyleBackColor = True
        '
        'frmmoneyexchange
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
<<<<<<< HEAD
        Me.ClientSize = New System.Drawing.Size(794, 233)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
=======
        Me.ClientSize = New System.Drawing.Size(794, 248)
>>>>>>> refs/remotes/origin/money-exchange
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(800, 500)
        Me.MinimumSize = New System.Drawing.Size(800, 32)
        Me.Name = "frmmoneyexchange"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Money Exchange"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnsearch As System.Windows.Forms.Button
    Friend WithEvents txtTotalAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txRate As System.Windows.Forms.TextBox
    Friend WithEvents label As System.Windows.Forms.Label
    Friend WithEvents txtSymbol As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents symbol As System.Windows.Forms.Label
    Friend WithEvents txtDenomination As System.Windows.Forms.TextBox
    Friend WithEvents txtCurrency As System.Windows.Forms.TextBox
    Friend WithEvents buttonSearch As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
<<<<<<< HEAD
    Friend WithEvents txtDenomination1 As System.Windows.Forms.TextBox
    Friend WithEvents txtRate As System.Windows.Forms.TextBox
    Friend WithEvents txtCurrency1 As System.Windows.Forms.TextBox
=======
>>>>>>> refs/remotes/origin/money-exchange
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtSerial As System.Windows.Forms.TextBox
    Friend WithEvents btnCalculate As System.Windows.Forms.Button
<<<<<<< HEAD
    Friend WithEvents txtCashID As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnModify As System.Windows.Forms.Button
    Friend WithEvents btnSearch1 As System.Windows.Forms.Button
=======
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnModify As System.Windows.Forms.Button
    Friend WithEvents btnSearch1 As System.Windows.Forms.Button
    Friend WithEvents txtRate As System.Windows.Forms.TextBox
    Friend WithEvents txtCashID As System.Windows.Forms.TextBox
    Friend WithEvents txtDenomination1 As System.Windows.Forms.TextBox
    Friend WithEvents txtSymbol1 As System.Windows.Forms.TextBox
    Friend WithEvents txtCurrency1 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape3 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape2 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
>>>>>>> refs/remotes/origin/money-exchange
End Class
