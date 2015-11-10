<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewloan
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
        Me.grpPawner = New System.Windows.Forms.GroupBox()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtBDay = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtPawner = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grpItem = New System.Windows.Forms.GroupBox()
        Me.cboKarat = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtGrams = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboCategory = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboItemtype = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDesc = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpTicket = New System.Windows.Forms.GroupBox()
        Me.txtNticket = New System.Windows.Forms.TextBox()
        Me.lblNticket = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.lblNet = New System.Windows.Forms.Label()
        Me.txtPrincipal = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtAppraisal = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Auction = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Expiry = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Maturity = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LoanDate = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtTicket = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cboAppraiser = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnVoid = New System.Windows.Forms.Button()
        Me.grpReceipt = New System.Windows.Forms.GroupBox()
        Me.txtPenalty = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtRedeemDue = New System.Windows.Forms.TextBox()
        Me.lblRedeemDue = New System.Windows.Forms.Label()
        Me.txtAppr = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.txtRefNo = New System.Windows.Forms.TextBox()
        Me.txtRenewDue = New System.Windows.Forms.TextBox()
        Me.lblRenewDue = New System.Windows.Forms.Label()
        Me.txtEvat = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtSrvChrg = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtDelayInt = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtOverDue = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.lblTranstype = New System.Windows.Forms.Label()
        Me.btnRenew = New System.Windows.Forms.Button()
        Me.btnRedeem = New System.Windows.Forms.Button()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblVOID = New System.Windows.Forms.Label()
        Me.grpPawner.SuspendLayout()
        Me.grpItem.SuspendLayout()
        Me.grpTicket.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.grpReceipt.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpPawner
        '
        Me.grpPawner.Controls.Add(Me.lblAge)
        Me.grpPawner.Controls.Add(Me.txtPhone)
        Me.grpPawner.Controls.Add(Me.Label16)
        Me.grpPawner.Controls.Add(Me.txtBDay)
        Me.grpPawner.Controls.Add(Me.Label15)
        Me.grpPawner.Controls.Add(Me.txtAddress)
        Me.grpPawner.Controls.Add(Me.Label3)
        Me.grpPawner.Controls.Add(Me.btnSearch)
        Me.grpPawner.Controls.Add(Me.txtPawner)
        Me.grpPawner.Controls.Add(Me.Label2)
        Me.grpPawner.Location = New System.Drawing.Point(12, 37)
        Me.grpPawner.Name = "grpPawner"
        Me.grpPawner.Size = New System.Drawing.Size(479, 181)
        Me.grpPawner.TabIndex = 0
        Me.grpPawner.TabStop = False
        Me.grpPawner.Text = "Pawner's Information"
        '
        'lblAge
        '
        Me.lblAge.AutoSize = True
        Me.lblAge.Location = New System.Drawing.Point(398, 114)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(16, 13)
        Me.lblAge.TabIndex = 20
        Me.lblAge.Text = " - "
        '
        'txtPhone
        '
        Me.txtPhone.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPhone.Location = New System.Drawing.Point(141, 140)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.ReadOnly = True
        Me.txtPhone.Size = New System.Drawing.Size(250, 22)
        Me.txtPhone.TabIndex = 4
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(5, 143)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(122, 16)
        Me.Label16.TabIndex = 19
        Me.Label16.Text = "Contact Number:"
        '
        'txtBDay
        '
        Me.txtBDay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBDay.Location = New System.Drawing.Point(142, 109)
        Me.txtBDay.Name = "txtBDay"
        Me.txtBDay.ReadOnly = True
        Me.txtBDay.Size = New System.Drawing.Size(250, 22)
        Me.txtBDay.TabIndex = 3
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(6, 112)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(74, 16)
        Me.Label15.TabIndex = 17
        Me.Label15.Text = "Birthdate:"
        '
        'txtAddress
        '
        Me.txtAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress.Location = New System.Drawing.Point(142, 39)
        Me.txtAddress.Multiline = True
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.ReadOnly = True
        Me.txtAddress.Size = New System.Drawing.Size(250, 66)
        Me.txtAddress.TabIndex = 2
        Me.txtAddress.Text = "Eskie Cirrus James Maquilang"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 16)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Full Address:"
        '
        'btnSearch
        '
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Location = New System.Drawing.Point(398, 13)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtPawner
        '
        Me.txtPawner.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPawner.Location = New System.Drawing.Point(142, 13)
        Me.txtPawner.Name = "txtPawner"
        Me.txtPawner.ReadOnly = True
        Me.txtPawner.Size = New System.Drawing.Size(250, 22)
        Me.txtPawner.TabIndex = 0
        Me.txtPawner.Text = "Eskie Cirrus James Maquilang"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Name:"
        '
        'grpItem
        '
        Me.grpItem.Controls.Add(Me.cboKarat)
        Me.grpItem.Controls.Add(Me.Label7)
        Me.grpItem.Controls.Add(Me.txtGrams)
        Me.grpItem.Controls.Add(Me.Label4)
        Me.grpItem.Controls.Add(Me.cboCategory)
        Me.grpItem.Controls.Add(Me.Label6)
        Me.grpItem.Controls.Add(Me.cboItemtype)
        Me.grpItem.Controls.Add(Me.Label5)
        Me.grpItem.Controls.Add(Me.txtDesc)
        Me.grpItem.Controls.Add(Me.Label1)
        Me.grpItem.Location = New System.Drawing.Point(12, 218)
        Me.grpItem.Name = "grpItem"
        Me.grpItem.Size = New System.Drawing.Size(479, 176)
        Me.grpItem.TabIndex = 1
        Me.grpItem.TabStop = False
        Me.grpItem.Text = "Pawned Item Information"
        '
        'cboKarat
        '
        Me.cboKarat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboKarat.Enabled = False
        Me.cboKarat.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboKarat.FormattingEnabled = True
        Me.cboKarat.Items.AddRange(New Object() {"10", "12", "14", "16", "18", "20", "21", "22", "24"})
        Me.cboKarat.Location = New System.Drawing.Point(349, 143)
        Me.cboKarat.Name = "cboKarat"
        Me.cboKarat.Size = New System.Drawing.Size(124, 21)
        Me.cboKarat.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(285, 148)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 16)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "Karat:"
        '
        'txtGrams
        '
        Me.txtGrams.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGrams.Location = New System.Drawing.Point(142, 145)
        Me.txtGrams.Name = "txtGrams"
        Me.txtGrams.ReadOnly = True
        Me.txtGrams.Size = New System.Drawing.Size(124, 22)
        Me.txtGrams.TabIndex = 3
        Me.txtGrams.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 148)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 16)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Grams:"
        '
        'cboCategory
        '
        Me.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCategory.Enabled = False
        Me.cboCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Location = New System.Drawing.Point(142, 47)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(124, 21)
        Me.cboCategory.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 16)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Category:"
        '
        'cboItemtype
        '
        Me.cboItemtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboItemtype.Enabled = False
        Me.cboItemtype.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboItemtype.FormattingEnabled = True
        Me.cboItemtype.Items.AddRange(New Object() {"APP", "CEL", "JWL", "BIG"})
        Me.cboItemtype.Location = New System.Drawing.Point(142, 21)
        Me.cboItemtype.Name = "cboItemtype"
        Me.cboItemtype.Size = New System.Drawing.Size(124, 21)
        Me.cboItemtype.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 16)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Item Type:"
        '
        'txtDesc
        '
        Me.txtDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesc.Location = New System.Drawing.Point(142, 72)
        Me.txtDesc.Multiline = True
        Me.txtDesc.Name = "txtDesc"
        Me.txtDesc.ReadOnly = True
        Me.txtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDesc.Size = New System.Drawing.Size(331, 69)
        Me.txtDesc.TabIndex = 2
        Me.txtDesc.Text = "AAAAAAAAAAAAAAAAAAAAAAAAA"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 16)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Description:"
        '
        'grpTicket
        '
        Me.grpTicket.Controls.Add(Me.txtNticket)
        Me.grpTicket.Controls.Add(Me.lblNticket)
        Me.grpTicket.Controls.Add(Me.txtTotal)
        Me.grpTicket.Controls.Add(Me.lblNet)
        Me.grpTicket.Controls.Add(Me.txtPrincipal)
        Me.grpTicket.Controls.Add(Me.Label14)
        Me.grpTicket.Controls.Add(Me.txtAppraisal)
        Me.grpTicket.Controls.Add(Me.Label13)
        Me.grpTicket.Controls.Add(Me.Auction)
        Me.grpTicket.Controls.Add(Me.Label10)
        Me.grpTicket.Controls.Add(Me.Expiry)
        Me.grpTicket.Controls.Add(Me.Label9)
        Me.grpTicket.Controls.Add(Me.Maturity)
        Me.grpTicket.Controls.Add(Me.Label8)
        Me.grpTicket.Controls.Add(Me.LoanDate)
        Me.grpTicket.Controls.Add(Me.Label11)
        Me.grpTicket.Controls.Add(Me.txtTicket)
        Me.grpTicket.Controls.Add(Me.Label12)
        Me.grpTicket.Location = New System.Drawing.Point(508, 37)
        Me.grpTicket.Name = "grpTicket"
        Me.grpTicket.Size = New System.Drawing.Size(265, 282)
        Me.grpTicket.TabIndex = 6
        Me.grpTicket.TabStop = False
        Me.grpTicket.Text = "Ticket Information"
        '
        'txtNticket
        '
        Me.txtNticket.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNticket.Location = New System.Drawing.Point(133, 41)
        Me.txtNticket.Name = "txtNticket"
        Me.txtNticket.ReadOnly = True
        Me.txtNticket.Size = New System.Drawing.Size(113, 22)
        Me.txtNticket.TabIndex = 1
        '
        'lblNticket
        '
        Me.lblNticket.AutoSize = True
        Me.lblNticket.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNticket.Location = New System.Drawing.Point(5, 44)
        Me.lblNticket.Name = "lblNticket"
        Me.lblNticket.Size = New System.Drawing.Size(83, 16)
        Me.lblNticket.TabIndex = 46
        Me.lblNticket.Text = "Old Ticket:"
        '
        'txtTotal
        '
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(133, 250)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(113, 22)
        Me.txtTotal.TabIndex = 7
        '
        'lblNet
        '
        Me.lblNet.AutoSize = True
        Me.lblNet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNet.Location = New System.Drawing.Point(6, 253)
        Me.lblNet.Name = "lblNet"
        Me.lblNet.Size = New System.Drawing.Size(91, 16)
        Me.lblNet.TabIndex = 42
        Me.lblNet.Text = "Net Amount:"
        '
        'txtPrincipal
        '
        Me.txtPrincipal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrincipal.Location = New System.Drawing.Point(133, 200)
        Me.txtPrincipal.Name = "txtPrincipal"
        Me.txtPrincipal.ReadOnly = True
        Me.txtPrincipal.Size = New System.Drawing.Size(113, 22)
        Me.txtPrincipal.TabIndex = 6
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(6, 203)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(73, 16)
        Me.Label14.TabIndex = 36
        Me.Label14.Text = "Principal:"
        '
        'txtAppraisal
        '
        Me.txtAppraisal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAppraisal.Location = New System.Drawing.Point(133, 175)
        Me.txtAppraisal.Name = "txtAppraisal"
        Me.txtAppraisal.ReadOnly = True
        Me.txtAppraisal.Size = New System.Drawing.Size(113, 22)
        Me.txtAppraisal.TabIndex = 5
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(6, 178)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 16)
        Me.Label13.TabIndex = 34
        Me.Label13.Text = "Appraisal:"
        '
        'Auction
        '
        Me.Auction.Enabled = False
        Me.Auction.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Auction.Location = New System.Drawing.Point(133, 134)
        Me.Auction.Name = "Auction"
        Me.Auction.Size = New System.Drawing.Size(113, 20)
        Me.Auction.TabIndex = 15
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(6, 134)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 16)
        Me.Label10.TabIndex = 31
        Me.Label10.Text = "Auction Date:"
        '
        'Expiry
        '
        Me.Expiry.Enabled = False
        Me.Expiry.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Expiry.Location = New System.Drawing.Point(133, 112)
        Me.Expiry.Name = "Expiry"
        Me.Expiry.Size = New System.Drawing.Size(113, 20)
        Me.Expiry.TabIndex = 14
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 112)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(92, 16)
        Me.Label9.TabIndex = 29
        Me.Label9.Text = "Expiry Date:"
        '
        'Maturity
        '
        Me.Maturity.Enabled = False
        Me.Maturity.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Maturity.Location = New System.Drawing.Point(133, 89)
        Me.Maturity.Name = "Maturity"
        Me.Maturity.Size = New System.Drawing.Size(113, 20)
        Me.Maturity.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 89)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(103, 16)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "Maturity Date:"
        '
        'LoanDate
        '
        Me.LoanDate.Enabled = False
        Me.LoanDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.LoanDate.Location = New System.Drawing.Point(133, 67)
        Me.LoanDate.Name = "LoanDate"
        Me.LoanDate.Size = New System.Drawing.Size(113, 20)
        Me.LoanDate.TabIndex = 12
        Me.LoanDate.Value = New Date(2015, 10, 15, 0, 0, 0, 0)
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(6, 67)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(83, 16)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "Loan Date:"
        '
        'txtTicket
        '
        Me.txtTicket.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTicket.Location = New System.Drawing.Point(133, 18)
        Me.txtTicket.Name = "txtTicket"
        Me.txtTicket.ReadOnly = True
        Me.txtTicket.Size = New System.Drawing.Size(113, 22)
        Me.txtTicket.TabIndex = 0
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 21)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(79, 16)
        Me.Label12.TabIndex = 15
        Me.Label12.Text = "Ticket No."
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cboAppraiser)
        Me.GroupBox4.Controls.Add(Me.Label19)
        Me.GroupBox4.Location = New System.Drawing.Point(508, 320)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(265, 74)
        Me.GroupBox4.TabIndex = 7
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Appraiser"
        '
        'cboAppraiser
        '
        Me.cboAppraiser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAppraiser.Enabled = False
        Me.cboAppraiser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAppraiser.FormattingEnabled = True
        Me.cboAppraiser.Location = New System.Drawing.Point(9, 35)
        Me.cboAppraiser.Name = "cboAppraiser"
        Me.cboAppraiser.Size = New System.Drawing.Size(237, 21)
        Me.cboAppraiser.TabIndex = 8
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(6, 16)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(96, 16)
        Me.Label19.TabIndex = 2
        Me.Label19.Text = "Appraise by:"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(11, 405)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(74, 35)
        Me.btnSave.TabIndex = 30
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(91, 405)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(74, 35)
        Me.btnClose.TabIndex = 31
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnVoid
        '
        Me.btnVoid.Enabled = False
        Me.btnVoid.Location = New System.Drawing.Point(968, 403)
        Me.btnVoid.Name = "btnVoid"
        Me.btnVoid.Size = New System.Drawing.Size(74, 35)
        Me.btnVoid.TabIndex = 33
        Me.btnVoid.Text = "&Void"
        Me.btnVoid.UseVisualStyleBackColor = True
        '
        'grpReceipt
        '
        Me.grpReceipt.Controls.Add(Me.txtPenalty)
        Me.grpReceipt.Controls.Add(Me.Label18)
        Me.grpReceipt.Controls.Add(Me.txtRedeemDue)
        Me.grpReceipt.Controls.Add(Me.lblRedeemDue)
        Me.grpReceipt.Controls.Add(Me.txtAppr)
        Me.grpReceipt.Controls.Add(Me.Label21)
        Me.grpReceipt.Controls.Add(Me.dtpDate)
        Me.grpReceipt.Controls.Add(Me.txtRefNo)
        Me.grpReceipt.Controls.Add(Me.txtRenewDue)
        Me.grpReceipt.Controls.Add(Me.lblRenewDue)
        Me.grpReceipt.Controls.Add(Me.txtEvat)
        Me.grpReceipt.Controls.Add(Me.Label23)
        Me.grpReceipt.Controls.Add(Me.txtSrvChrg)
        Me.grpReceipt.Controls.Add(Me.Label24)
        Me.grpReceipt.Controls.Add(Me.txtDelayInt)
        Me.grpReceipt.Controls.Add(Me.Label25)
        Me.grpReceipt.Controls.Add(Me.txtOverDue)
        Me.grpReceipt.Controls.Add(Me.Label26)
        Me.grpReceipt.Controls.Add(Me.Label28)
        Me.grpReceipt.Controls.Add(Me.Label29)
        Me.grpReceipt.Location = New System.Drawing.Point(779, 37)
        Me.grpReceipt.Name = "grpReceipt"
        Me.grpReceipt.Size = New System.Drawing.Size(260, 357)
        Me.grpReceipt.TabIndex = 13
        Me.grpReceipt.TabStop = False
        Me.grpReceipt.Text = "Receipt Information"
        '
        'txtPenalty
        '
        Me.txtPenalty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPenalty.Location = New System.Drawing.Point(133, 189)
        Me.txtPenalty.Name = "txtPenalty"
        Me.txtPenalty.ReadOnly = True
        Me.txtPenalty.Size = New System.Drawing.Size(113, 22)
        Me.txtPenalty.TabIndex = 26
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(4, 192)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(64, 16)
        Me.Label18.TabIndex = 52
        Me.Label18.Text = "Penalty:"
        '
        'txtRedeemDue
        '
        Me.txtRedeemDue.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRedeemDue.Location = New System.Drawing.Point(133, 290)
        Me.txtRedeemDue.Name = "txtRedeemDue"
        Me.txtRedeemDue.ReadOnly = True
        Me.txtRedeemDue.Size = New System.Drawing.Size(113, 22)
        Me.txtRedeemDue.TabIndex = 30
        '
        'lblRedeemDue
        '
        Me.lblRedeemDue.AutoSize = True
        Me.lblRedeemDue.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRedeemDue.Location = New System.Drawing.Point(6, 293)
        Me.lblRedeemDue.Name = "lblRedeemDue"
        Me.lblRedeemDue.Size = New System.Drawing.Size(103, 16)
        Me.lblRedeemDue.TabIndex = 50
        Me.lblRedeemDue.Text = "Redeem Due:"
        '
        'txtAppr
        '
        Me.txtAppr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAppr.Location = New System.Drawing.Point(132, 65)
        Me.txtAppr.Name = "txtAppr"
        Me.txtAppr.ReadOnly = True
        Me.txtAppr.Size = New System.Drawing.Size(113, 22)
        Me.txtAppr.TabIndex = 21
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(5, 66)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(79, 16)
        Me.Label21.TabIndex = 48
        Me.Label21.Text = "Appraisal:"
        '
        'dtpDate
        '
        Me.dtpDate.Enabled = False
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDate.Location = New System.Drawing.Point(132, 42)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(113, 20)
        Me.dtpDate.TabIndex = 20
        '
        'txtRefNo
        '
        Me.txtRefNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRefNo.Location = New System.Drawing.Point(132, 17)
        Me.txtRefNo.Name = "txtRefNo"
        Me.txtRefNo.ReadOnly = True
        Me.txtRefNo.Size = New System.Drawing.Size(113, 22)
        Me.txtRefNo.TabIndex = 19
        '
        'txtRenewDue
        '
        Me.txtRenewDue.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRenewDue.Location = New System.Drawing.Point(133, 265)
        Me.txtRenewDue.Name = "txtRenewDue"
        Me.txtRenewDue.ReadOnly = True
        Me.txtRenewDue.Size = New System.Drawing.Size(113, 22)
        Me.txtRenewDue.TabIndex = 29
        '
        'lblRenewDue
        '
        Me.lblRenewDue.AutoSize = True
        Me.lblRenewDue.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRenewDue.Location = New System.Drawing.Point(6, 268)
        Me.lblRenewDue.Name = "lblRenewDue"
        Me.lblRenewDue.Size = New System.Drawing.Size(91, 16)
        Me.lblRenewDue.TabIndex = 42
        Me.lblRenewDue.Text = "Renew Due:"
        '
        'txtEvat
        '
        Me.txtEvat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEvat.Location = New System.Drawing.Point(133, 239)
        Me.txtEvat.Name = "txtEvat"
        Me.txtEvat.ReadOnly = True
        Me.txtEvat.Size = New System.Drawing.Size(113, 22)
        Me.txtEvat.TabIndex = 28
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(6, 242)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(50, 16)
        Me.Label23.TabIndex = 40
        Me.Label23.Text = "E-Vat:"
        '
        'txtSrvChrg
        '
        Me.txtSrvChrg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSrvChrg.Location = New System.Drawing.Point(133, 215)
        Me.txtSrvChrg.Name = "txtSrvChrg"
        Me.txtSrvChrg.ReadOnly = True
        Me.txtSrvChrg.Size = New System.Drawing.Size(113, 22)
        Me.txtSrvChrg.TabIndex = 27
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(6, 218)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(119, 16)
        Me.Label24.TabIndex = 38
        Me.Label24.Text = "Service Charge:"
        '
        'txtDelayInt
        '
        Me.txtDelayInt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDelayInt.Location = New System.Drawing.Point(133, 164)
        Me.txtDelayInt.Name = "txtDelayInt"
        Me.txtDelayInt.ReadOnly = True
        Me.txtDelayInt.Size = New System.Drawing.Size(113, 22)
        Me.txtDelayInt.TabIndex = 25
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(6, 165)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(126, 16)
        Me.Label25.TabIndex = 36
        Me.Label25.Text = "Delayed Interest:"
        '
        'txtOverDue
        '
        Me.txtOverDue.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOverDue.Location = New System.Drawing.Point(133, 139)
        Me.txtOverDue.Name = "txtOverDue"
        Me.txtOverDue.ReadOnly = True
        Me.txtOverDue.Size = New System.Drawing.Size(113, 22)
        Me.txtOverDue.TabIndex = 24
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(6, 140)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(117, 16)
        Me.Label26.TabIndex = 34
        Me.Label26.Text = "Days Over Due:"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(5, 41)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(103, 16)
        Me.Label28.TabIndex = 27
        Me.Label28.Text = "Receipt Date:"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(5, 18)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(90, 16)
        Me.Label29.TabIndex = 17
        Me.Label29.Text = "Receipt No:"
        '
        'lblTranstype
        '
        Me.lblTranstype.AutoSize = True
        Me.lblTranstype.Font = New System.Drawing.Font("Segoe UI", 26.25!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                        Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTranstype.ForeColor = System.Drawing.Color.Red
        Me.lblTranstype.Location = New System.Drawing.Point(12, 9)
        Me.lblTranstype.Name = "lblTranstype"
        Me.lblTranstype.Size = New System.Drawing.Size(0, 47)
        Me.lblTranstype.TabIndex = 14
        '
        'btnRenew
        '
        Me.btnRenew.Location = New System.Drawing.Point(508, 403)
        Me.btnRenew.Name = "btnRenew"
        Me.btnRenew.Size = New System.Drawing.Size(102, 35)
        Me.btnRenew.TabIndex = 34
        Me.btnRenew.Text = "&Renew"
        Me.btnRenew.UseVisualStyleBackColor = True
        '
        'btnRedeem
        '
        Me.btnRedeem.Location = New System.Drawing.Point(616, 403)
        Me.btnRedeem.Name = "btnRedeem"
        Me.btnRedeem.Size = New System.Drawing.Size(102, 35)
        Me.btnRedeem.TabIndex = 35
        Me.btnRedeem.Text = "R&edeem"
        Me.btnRedeem.UseVisualStyleBackColor = True
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(18, 9)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(101, 25)
        Me.lblTitle.TabIndex = 36
        Me.lblTitle.Text = "Pawning"
        '
        'lblVOID
        '
        Me.lblVOID.AutoSize = True
        Me.lblVOID.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVOID.ForeColor = System.Drawing.Color.DarkRed
        Me.lblVOID.Location = New System.Drawing.Point(822, 405)
        Me.lblVOID.Name = "lblVOID"
        Me.lblVOID.Size = New System.Drawing.Size(217, 25)
        Me.lblVOID.TabIndex = 38
        Me.lblVOID.Text = "NEW PT#99999999"
        Me.lblVOID.Visible = False
        '
        'frmNewloan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(1054, 446)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.btnRedeem)
        Me.Controls.Add(Me.btnRenew)
        Me.Controls.Add(Me.lblTranstype)
        Me.Controls.Add(Me.grpReceipt)
        Me.Controls.Add(Me.btnVoid)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.grpTicket)
        Me.Controls.Add(Me.grpItem)
        Me.Controls.Add(Me.grpPawner)
        Me.Controls.Add(Me.lblVOID)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmNewloan"
        Me.Text = "New Loan"
        Me.grpPawner.ResumeLayout(False)
        Me.grpPawner.PerformLayout()
        Me.grpItem.ResumeLayout(False)
        Me.grpItem.PerformLayout()
        Me.grpTicket.ResumeLayout(False)
        Me.grpTicket.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.grpReceipt.ResumeLayout(False)
        Me.grpReceipt.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpPawner As System.Windows.Forms.GroupBox
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtPawner As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grpItem As System.Windows.Forms.GroupBox
    Friend WithEvents cboKarat As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtGrams As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboCategory As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboItemtype As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grpTicket As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtTicket As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents lblNet As System.Windows.Forms.Label
    Friend WithEvents txtPrincipal As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtAppraisal As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Auction As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Expiry As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Maturity As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents LoanDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnVoid As System.Windows.Forms.Button
    Friend WithEvents txtNticket As System.Windows.Forms.TextBox
    Friend WithEvents lblNticket As System.Windows.Forms.Label
    Friend WithEvents grpReceipt As System.Windows.Forms.GroupBox
    Friend WithEvents txtPenalty As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtRedeemDue As System.Windows.Forms.TextBox
    Friend WithEvents lblRedeemDue As System.Windows.Forms.Label
    Friend WithEvents txtAppr As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtRefNo As System.Windows.Forms.TextBox
    Friend WithEvents txtRenewDue As System.Windows.Forms.TextBox
    Friend WithEvents lblRenewDue As System.Windows.Forms.Label
    Friend WithEvents txtEvat As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtSrvChrg As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtDelayInt As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtOverDue As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents lblTranstype As System.Windows.Forms.Label
    Friend WithEvents txtPhone As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtBDay As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cboAppraiser As System.Windows.Forms.ComboBox
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents btnRenew As System.Windows.Forms.Button
    Friend WithEvents btnRedeem As System.Windows.Forms.Button
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblVOID As System.Windows.Forms.Label
End Class
