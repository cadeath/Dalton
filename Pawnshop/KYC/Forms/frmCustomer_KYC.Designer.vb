<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCustomer_KYC
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
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"GSIS", "544489G15SD"}, -1)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCustomer_KYC))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFName = New System.Windows.Forms.TextBox()
        Me.txtMName = New System.Windows.Forms.TextBox()
        Me.txtLName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpBasic = New System.Windows.Forms.TabPage()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.lstPhone = New System.Windows.Forms.ListBox()
        Me.btnSetPri = New System.Windows.Forms.Button()
        Me.txtWork = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cboGender = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.rbHigh = New System.Windows.Forms.RadioButton()
        Me.rbNormal = New System.Windows.Forms.RadioButton()
        Me.rbLow = New System.Windows.Forms.RadioButton()
        Me.txtSrcFund = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.btnNega = New System.Windows.Forms.Button()
        Me.btnPlus = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtNationality = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cboZip2 = New System.Windows.Forms.ComboBox()
        Me.cboProv2 = New System.Windows.Forms.ComboBox()
        Me.cboCity2 = New System.Windows.Forms.ComboBox()
        Me.cboBrgy2 = New System.Windows.Forms.ComboBox()
        Me.txtSt2 = New System.Windows.Forms.TextBox()
        Me.lblTheSame = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboZip1 = New System.Windows.Forms.ComboBox()
        Me.cboProv1 = New System.Windows.Forms.ComboBox()
        Me.cboCity1 = New System.Windows.Forms.ComboBox()
        Me.cboBrgy1 = New System.Windows.Forms.ComboBox()
        Me.txtSt1 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtBdayPlace = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpBday = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tpID = New System.Windows.Forms.TabPage()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnPrimary = New System.Windows.Forms.Button()
        Me.lvID = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtIDNum = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.cboType = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCamera = New System.Windows.Forms.Button()
        Me.grpCusPic = New System.Windows.Forms.GroupBox()
        Me.ClientImage = New System.Windows.Forms.PictureBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtSuffix = New System.Windows.Forms.TextBox()
        Me.btnHistory = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.tpBasic.SuspendLayout()
        Me.tpID.SuspendLayout()
        Me.grpCusPic.SuspendLayout()
        CType(Me.ClientImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Customer"
        '
        'txtFName
        '
        Me.txtFName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFName.Location = New System.Drawing.Point(15, 30)
        Me.txtFName.Name = "txtFName"
        Me.txtFName.Size = New System.Drawing.Size(246, 22)
        Me.txtFName.TabIndex = 0
        Me.txtFName.Text = "Eskie Cirrus James"
        '
        'txtMName
        '
        Me.txtMName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMName.Location = New System.Drawing.Point(268, 30)
        Me.txtMName.Name = "txtMName"
        Me.txtMName.Size = New System.Drawing.Size(176, 22)
        Me.txtMName.TabIndex = 1
        Me.txtMName.Text = "Eskie Cirrus James"
        '
        'txtLName
        '
        Me.txtLName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLName.Location = New System.Drawing.Point(450, 30)
        Me.txtLName.Name = "txtLName"
        Me.txtLName.Size = New System.Drawing.Size(176, 22)
        Me.txtLName.TabIndex = 2
        Me.txtLName.Text = "Eskie Cirrus James"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(246, 18)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "First Name *"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(268, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(179, 18)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Middle Name"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(447, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(179, 18)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Last Name *"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tpBasic)
        Me.TabControl1.Controls.Add(Me.tpID)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(12, 76)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(712, 367)
        Me.TabControl1.TabIndex = 4
        '
        'tpBasic
        '
        Me.tpBasic.Controls.Add(Me.lblAge)
        Me.tpBasic.Controls.Add(Me.txtPhone)
        Me.tpBasic.Controls.Add(Me.lstPhone)
        Me.tpBasic.Controls.Add(Me.btnSetPri)
        Me.tpBasic.Controls.Add(Me.txtWork)
        Me.tpBasic.Controls.Add(Me.Label18)
        Me.tpBasic.Controls.Add(Me.cboGender)
        Me.tpBasic.Controls.Add(Me.Label25)
        Me.tpBasic.Controls.Add(Me.Label22)
        Me.tpBasic.Controls.Add(Me.rbHigh)
        Me.tpBasic.Controls.Add(Me.rbNormal)
        Me.tpBasic.Controls.Add(Me.rbLow)
        Me.tpBasic.Controls.Add(Me.txtSrcFund)
        Me.tpBasic.Controls.Add(Me.Label21)
        Me.tpBasic.Controls.Add(Me.btnNega)
        Me.tpBasic.Controls.Add(Me.btnPlus)
        Me.tpBasic.Controls.Add(Me.Label20)
        Me.tpBasic.Controls.Add(Me.txtNationality)
        Me.tpBasic.Controls.Add(Me.Label19)
        Me.tpBasic.Controls.Add(Me.Label13)
        Me.tpBasic.Controls.Add(Me.Label14)
        Me.tpBasic.Controls.Add(Me.Label15)
        Me.tpBasic.Controls.Add(Me.Label16)
        Me.tpBasic.Controls.Add(Me.Label17)
        Me.tpBasic.Controls.Add(Me.cboZip2)
        Me.tpBasic.Controls.Add(Me.cboProv2)
        Me.tpBasic.Controls.Add(Me.cboCity2)
        Me.tpBasic.Controls.Add(Me.cboBrgy2)
        Me.tpBasic.Controls.Add(Me.txtSt2)
        Me.tpBasic.Controls.Add(Me.lblTheSame)
        Me.tpBasic.Controls.Add(Me.Label12)
        Me.tpBasic.Controls.Add(Me.Label11)
        Me.tpBasic.Controls.Add(Me.Label10)
        Me.tpBasic.Controls.Add(Me.Label9)
        Me.tpBasic.Controls.Add(Me.Label8)
        Me.tpBasic.Controls.Add(Me.cboZip1)
        Me.tpBasic.Controls.Add(Me.cboProv1)
        Me.tpBasic.Controls.Add(Me.cboCity1)
        Me.tpBasic.Controls.Add(Me.cboBrgy1)
        Me.tpBasic.Controls.Add(Me.txtSt1)
        Me.tpBasic.Controls.Add(Me.Label7)
        Me.tpBasic.Controls.Add(Me.txtBdayPlace)
        Me.tpBasic.Controls.Add(Me.Label6)
        Me.tpBasic.Controls.Add(Me.dtpBday)
        Me.tpBasic.Controls.Add(Me.Label5)
        Me.tpBasic.Location = New System.Drawing.Point(4, 25)
        Me.tpBasic.Name = "tpBasic"
        Me.tpBasic.Padding = New System.Windows.Forms.Padding(3)
        Me.tpBasic.Size = New System.Drawing.Size(704, 338)
        Me.tpBasic.TabIndex = 0
        Me.tpBasic.Text = "Basic Information"
        Me.tpBasic.UseVisualStyleBackColor = True
        '
        'lblAge
        '
        Me.lblAge.AutoSize = True
        Me.lblAge.Location = New System.Drawing.Point(127, 172)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(31, 16)
        Me.lblAge.TabIndex = 42
        Me.lblAge.Text = "N/A"
        '
        'txtPhone
        '
        Me.txtPhone.Location = New System.Drawing.Point(16, 227)
        Me.txtPhone.MaxLength = 13
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(150, 22)
        Me.txtPhone.TabIndex = 13
        '
        'lstPhone
        '
        Me.lstPhone.FormattingEnabled = True
        Me.lstPhone.ItemHeight = 16
        Me.lstPhone.Items.AddRange(New Object() {"ELLIE GWAPO", "ELLIE GWAPO", "ELLIE GWAPO", "ELLIE GWAPO"})
        Me.lstPhone.Location = New System.Drawing.Point(16, 253)
        Me.lstPhone.Name = "lstPhone"
        Me.lstPhone.Size = New System.Drawing.Size(150, 68)
        Me.lstPhone.TabIndex = 29
        '
        'btnSetPri
        '
        Me.btnSetPri.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetPri.Location = New System.Drawing.Point(178, 286)
        Me.btnSetPri.Name = "btnSetPri"
        Me.btnSetPri.Size = New System.Drawing.Size(29, 23)
        Me.btnSetPri.TabIndex = 15
        Me.btnSetPri.Text = "P"
        Me.btnSetPri.UseVisualStyleBackColor = True
        '
        'txtWork
        '
        Me.txtWork.Location = New System.Drawing.Point(213, 230)
        Me.txtWork.Name = "txtWork"
        Me.txtWork.Size = New System.Drawing.Size(176, 22)
        Me.txtWork.TabIndex = 16
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(212, 213)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(213, 16)
        Me.Label18.TabIndex = 41
        Me.Label18.Text = "Nature of Work/Business/Position*"
        '
        'cboGender
        '
        Me.cboGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGender.FormattingEnabled = True
        Me.cboGender.Items.AddRange(New Object() {"Male", "Female"})
        Me.cboGender.Location = New System.Drawing.Point(479, 230)
        Me.cboGender.Name = "cboGender"
        Me.cboGender.Size = New System.Drawing.Size(121, 24)
        Me.cboGender.TabIndex = 18
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(478, 213)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(53, 16)
        Me.Label25.TabIndex = 39
        Me.Label25.Text = "Gender"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(422, 291)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(46, 16)
        Me.Label22.TabIndex = 38
        Me.Label22.Text = "Profile"
        '
        'rbHigh
        '
        Me.rbHigh.AutoSize = True
        Me.rbHigh.Location = New System.Drawing.Point(558, 308)
        Me.rbHigh.Name = "rbHigh"
        Me.rbHigh.Size = New System.Drawing.Size(59, 20)
        Me.rbHigh.TabIndex = 19
        Me.rbHigh.TabStop = True
        Me.rbHigh.Text = "HIGH"
        Me.rbHigh.UseVisualStyleBackColor = True
        '
        'rbNormal
        '
        Me.rbNormal.AutoSize = True
        Me.rbNormal.Location = New System.Drawing.Point(481, 308)
        Me.rbNormal.Name = "rbNormal"
        Me.rbNormal.Size = New System.Drawing.Size(83, 20)
        Me.rbNormal.TabIndex = 18
        Me.rbNormal.Text = "NORMAL"
        Me.rbNormal.UseVisualStyleBackColor = True
        '
        'rbLow
        '
        Me.rbLow.AutoSize = True
        Me.rbLow.Checked = True
        Me.rbLow.Location = New System.Drawing.Point(425, 307)
        Me.rbLow.Name = "rbLow"
        Me.rbLow.Size = New System.Drawing.Size(56, 20)
        Me.rbLow.TabIndex = 19
        Me.rbLow.TabStop = True
        Me.rbLow.Text = "LOW"
        Me.rbLow.UseVisualStyleBackColor = True
        '
        'txtSrcFund
        '
        Me.txtSrcFund.Location = New System.Drawing.Point(213, 269)
        Me.txtSrcFund.Name = "txtSrcFund"
        Me.txtSrcFund.Size = New System.Drawing.Size(178, 22)
        Me.txtSrcFund.TabIndex = 17
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(211, 253)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(103, 16)
        Me.Label21.TabIndex = 33
        Me.Label21.Text = "Source of Fund*"
        '
        'btnNega
        '
        Me.btnNega.Location = New System.Drawing.Point(178, 256)
        Me.btnNega.Name = "btnNega"
        Me.btnNega.Size = New System.Drawing.Size(29, 23)
        Me.btnNega.TabIndex = 30
        Me.btnNega.Text = "-"
        Me.btnNega.UseVisualStyleBackColor = True
        '
        'btnPlus
        '
        Me.btnPlus.Location = New System.Drawing.Point(178, 227)
        Me.btnPlus.Name = "btnPlus"
        Me.btnPlus.Size = New System.Drawing.Size(29, 23)
        Me.btnPlus.TabIndex = 14
        Me.btnPlus.Text = "+"
        Me.btnPlus.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(16, 193)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(104, 16)
        Me.Label20.TabIndex = 29
        Me.Label20.Text = "Contact Number"
        '
        'txtNationality
        '
        Me.txtNationality.Location = New System.Drawing.Point(465, 170)
        Me.txtNationality.Name = "txtNationality"
        Me.txtNationality.Size = New System.Drawing.Size(208, 22)
        Me.txtNationality.TabIndex = 12
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(463, 154)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(79, 16)
        Me.Label19.TabIndex = 26
        Me.Label19.Text = "Nationality *"
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(594, 125)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(81, 18)
        Me.Label13.TabIndex = 25
        Me.Label13.Text = "Zip Code"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(458, 122)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(119, 18)
        Me.Label14.TabIndex = 24
        Me.Label14.Text = "Province *"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(317, 122)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(121, 18)
        Me.Label15.TabIndex = 23
        Me.Label15.Text = "City *"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(171, 122)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(121, 18)
        Me.Label16.TabIndex = 22
        Me.Label16.Text = "Barangay *"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(20, 122)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(121, 18)
        Me.Label17.TabIndex = 21
        Me.Label17.Text = "Street"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cboZip2
        '
        Me.cboZip2.FormattingEnabled = True
        Me.cboZip2.Location = New System.Drawing.Point(594, 98)
        Me.cboZip2.Name = "cboZip2"
        Me.cboZip2.Size = New System.Drawing.Size(81, 24)
        Me.cboZip2.TabIndex = 9
        '
        'cboProv2
        '
        Me.cboProv2.FormattingEnabled = True
        Me.cboProv2.Location = New System.Drawing.Point(454, 98)
        Me.cboProv2.Name = "cboProv2"
        Me.cboProv2.Size = New System.Drawing.Size(134, 24)
        Me.cboProv2.TabIndex = 8
        '
        'cboCity2
        '
        Me.cboCity2.FormattingEnabled = True
        Me.cboCity2.Location = New System.Drawing.Point(313, 98)
        Me.cboCity2.Name = "cboCity2"
        Me.cboCity2.Size = New System.Drawing.Size(135, 24)
        Me.cboCity2.TabIndex = 7
        '
        'cboBrgy2
        '
        Me.cboBrgy2.FormattingEnabled = True
        Me.cboBrgy2.Location = New System.Drawing.Point(164, 98)
        Me.cboBrgy2.Name = "cboBrgy2"
        Me.cboBrgy2.Size = New System.Drawing.Size(140, 24)
        Me.cboBrgy2.TabIndex = 6
        '
        'txtSt2
        '
        Me.txtSt2.Location = New System.Drawing.Point(16, 99)
        Me.txtSt2.Name = "txtSt2"
        Me.txtSt2.Size = New System.Drawing.Size(138, 22)
        Me.txtSt2.TabIndex = 5
        '
        'lblTheSame
        '
        Me.lblTheSame.AutoSize = True
        Me.lblTheSame.Location = New System.Drawing.Point(14, 80)
        Me.lblTheSame.Name = "lblTheSame"
        Me.lblTheSame.Size = New System.Drawing.Size(428, 16)
        Me.lblTheSame.TabIndex = 15
        Me.lblTheSame.Text = "Permanent Address (Double Click here if it is the same with the Present)"
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(591, 49)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(81, 18)
        Me.Label12.TabIndex = 14
        Me.Label12.Text = "Zip Code"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(467, 49)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(119, 18)
        Me.Label11.TabIndex = 13
        Me.Label11.Text = "Province *"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(315, 49)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(121, 18)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "City *"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(175, 48)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(121, 18)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Barangay *"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(20, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(121, 18)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Street"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cboZip1
        '
        Me.cboZip1.FormattingEnabled = True
        Me.cboZip1.Location = New System.Drawing.Point(592, 25)
        Me.cboZip1.Name = "cboZip1"
        Me.cboZip1.Size = New System.Drawing.Size(81, 24)
        Me.cboZip1.TabIndex = 4
        '
        'cboProv1
        '
        Me.cboProv1.FormattingEnabled = True
        Me.cboProv1.Location = New System.Drawing.Point(454, 25)
        Me.cboProv1.Name = "cboProv1"
        Me.cboProv1.Size = New System.Drawing.Size(132, 24)
        Me.cboProv1.TabIndex = 3
        '
        'cboCity1
        '
        Me.cboCity1.FormattingEnabled = True
        Me.cboCity1.Location = New System.Drawing.Point(312, 24)
        Me.cboCity1.Name = "cboCity1"
        Me.cboCity1.Size = New System.Drawing.Size(136, 24)
        Me.cboCity1.TabIndex = 2
        '
        'cboBrgy1
        '
        Me.cboBrgy1.FormattingEnabled = True
        Me.cboBrgy1.Location = New System.Drawing.Point(160, 24)
        Me.cboBrgy1.Name = "cboBrgy1"
        Me.cboBrgy1.Size = New System.Drawing.Size(144, 24)
        Me.cboBrgy1.TabIndex = 1
        '
        'txtSt1
        '
        Me.txtSt1.Location = New System.Drawing.Point(16, 25)
        Me.txtSt1.Name = "txtSt1"
        Me.txtSt1.Size = New System.Drawing.Size(138, 22)
        Me.txtSt1.TabIndex = 0
        Me.txtSt1.Text = "ELLIE GWAPO"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(108, 16)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Present Address"
        '
        'txtBdayPlace
        '
        Me.txtBdayPlace.Location = New System.Drawing.Point(201, 170)
        Me.txtBdayPlace.Name = "txtBdayPlace"
        Me.txtBdayPlace.Size = New System.Drawing.Size(260, 22)
        Me.txtBdayPlace.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(200, 154)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 16)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Birthplace"
        '
        'dtpBday
        '
        Me.dtpBday.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBday.Location = New System.Drawing.Point(16, 170)
        Me.dtpBday.Name = "dtpBday"
        Me.dtpBday.Size = New System.Drawing.Size(108, 22)
        Me.dtpBday.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 154)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 16)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Birthday *"
        '
        'tpID
        '
        Me.tpID.Controls.Add(Me.btnRemove)
        Me.tpID.Controls.Add(Me.btnAdd)
        Me.tpID.Controls.Add(Me.btnPrimary)
        Me.tpID.Controls.Add(Me.lvID)
        Me.tpID.Controls.Add(Me.txtIDNum)
        Me.tpID.Controls.Add(Me.Label24)
        Me.tpID.Controls.Add(Me.cboType)
        Me.tpID.Controls.Add(Me.Label23)
        Me.tpID.Location = New System.Drawing.Point(4, 25)
        Me.tpID.Name = "tpID"
        Me.tpID.Padding = New System.Windows.Forms.Padding(3)
        Me.tpID.Size = New System.Drawing.Size(704, 338)
        Me.tpID.TabIndex = 1
        Me.tpID.Text = "Identification"
        Me.tpID.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(597, 172)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(85, 38)
        Me.btnRemove.TabIndex = 5
        Me.btnRemove.Text = "&Remove"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(597, 128)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(85, 38)
        Me.btnAdd.TabIndex = 4
        Me.btnAdd.Text = "&Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnPrimary
        '
        Me.btnPrimary.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrimary.Location = New System.Drawing.Point(597, 79)
        Me.btnPrimary.Name = "btnPrimary"
        Me.btnPrimary.Size = New System.Drawing.Size(85, 43)
        Me.btnPrimary.TabIndex = 3
        Me.btnPrimary.Text = "Set as Primary"
        Me.btnPrimary.UseVisualStyleBackColor = True
        '
        'lvID
        '
        Me.lvID.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lvID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvID.FullRowSelect = True
        Me.lvID.GridLines = True
        Me.lvID.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1})
        Me.lvID.Location = New System.Drawing.Point(9, 70)
        Me.lvID.Name = "lvID"
        Me.lvID.Size = New System.Drawing.Size(582, 262)
        Me.lvID.TabIndex = 2
        Me.lvID.UseCompatibleStateImageBehavior = False
        Me.lvID.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "TYPE"
        Me.ColumnHeader1.Width = 263
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "NUMBER"
        Me.ColumnHeader2.Width = 235
        '
        'txtIDNum
        '
        Me.txtIDNum.Location = New System.Drawing.Point(88, 44)
        Me.txtIDNum.Name = "txtIDNum"
        Me.txtIDNum.Size = New System.Drawing.Size(503, 22)
        Me.txtIDNum.TabIndex = 1
        Me.txtIDNum.Text = "AG5D150G5"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(6, 45)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(75, 16)
        Me.Label24.TabIndex = 2
        Me.Label24.Text = "ID Number:"
        '
        'cboType
        '
        Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType.FormattingEnabled = True
        Me.cboType.Items.AddRange(New Object() {"Passport", "Driver's License", "PRC ID", "NBI Clearance", "Police Clearance", "Postal ID", "Voter's ID", "Brgy Certification", "GSIS", "SSS", "Senior Citizen Card", "OWWA ID", "OFW ID", "Seaman's Book", "Alien Cretification/Immigrant Certification of Registration", "AFP ID", "HDMF ID", "NCWDP", "DSWD Certification", "Integrated Bar of the Philippines ID", "Company ID under BSP, SEC or IC"})
        Me.cboType.Location = New System.Drawing.Point(88, 13)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(503, 24)
        Me.cboType.TabIndex = 0
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(6, 14)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(43, 16)
        Me.Label23.TabIndex = 0
        Me.Label23.Text = "Type:"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(810, 443)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(90, 46)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(714, 444)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(90, 45)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCamera
        '
        Me.btnCamera.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCamera.Location = New System.Drawing.Point(30, 152)
        Me.btnCamera.Name = "btnCamera"
        Me.btnCamera.Size = New System.Drawing.Size(114, 37)
        Me.btnCamera.TabIndex = 0
        Me.btnCamera.Text = "Open Camera"
        Me.btnCamera.UseVisualStyleBackColor = True
        '
        'grpCusPic
        '
        Me.grpCusPic.Controls.Add(Me.ClientImage)
        Me.grpCusPic.Controls.Add(Me.btnCamera)
        Me.grpCusPic.Location = New System.Drawing.Point(724, 98)
        Me.grpCusPic.Name = "grpCusPic"
        Me.grpCusPic.Size = New System.Drawing.Size(171, 201)
        Me.grpCusPic.TabIndex = 14
        Me.grpCusPic.TabStop = False
        Me.grpCusPic.Text = "Customer Picture"
        '
        'ClientImage
        '
        Me.ClientImage.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientImage.Location = New System.Drawing.Point(6, 17)
        Me.ClientImage.Name = "ClientImage"
        Me.ClientImage.Size = New System.Drawing.Size(159, 129)
        Me.ClientImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ClientImage.TabIndex = 11
        Me.ClientImage.TabStop = False
        '
        'Label26
        '
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(577, 55)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(179, 18)
        Me.Label26.TabIndex = 16
        Me.Label26.Text = "Suffix"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtSuffix
        '
        Me.txtSuffix.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSuffix.Location = New System.Drawing.Point(632, 30)
        Me.txtSuffix.Name = "txtSuffix"
        Me.txtSuffix.Size = New System.Drawing.Size(92, 22)
        Me.txtSuffix.TabIndex = 3
        Me.txtSuffix.Text = "Jr"
        '
        'btnHistory
        '
        Me.btnHistory.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHistory.Location = New System.Drawing.Point(4, 445)
        Me.btnHistory.Name = "btnHistory"
        Me.btnHistory.Size = New System.Drawing.Size(90, 45)
        Me.btnHistory.TabIndex = 17
        Me.btnHistory.Text = "&History"
        Me.btnHistory.UseVisualStyleBackColor = True
        '
        'frmCustomer_KYC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(907, 493)
        Me.Controls.Add(Me.btnHistory)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.txtSuffix)
        Me.Controls.Add(Me.grpCusPic)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtLName)
        Me.Controls.Add(Me.txtMName)
        Me.Controls.Add(Me.txtFName)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmCustomer_KYC"
        Me.Text = "Customer Information"
        Me.TabControl1.ResumeLayout(False)
        Me.tpBasic.ResumeLayout(False)
        Me.tpBasic.PerformLayout()
        Me.tpID.ResumeLayout(False)
        Me.tpID.PerformLayout()
        Me.grpCusPic.ResumeLayout(False)
        CType(Me.ClientImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFName As System.Windows.Forms.TextBox
    Friend WithEvents txtMName As System.Windows.Forms.TextBox
    Friend WithEvents txtLName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpBasic As System.Windows.Forms.TabPage
    Friend WithEvents tpID As System.Windows.Forms.TabPage
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtBdayPlace As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpBday As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSt1 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboZip1 As System.Windows.Forms.ComboBox
    Friend WithEvents cboProv1 As System.Windows.Forms.ComboBox
    Friend WithEvents cboCity1 As System.Windows.Forms.ComboBox
    Friend WithEvents cboBrgy1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cboZip2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboProv2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboCity2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboBrgy2 As System.Windows.Forms.ComboBox
    Friend WithEvents txtSt2 As System.Windows.Forms.TextBox
    Friend WithEvents lblTheSame As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtNationality As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents btnNega As System.Windows.Forms.Button
    Friend WithEvents btnPlus As System.Windows.Forms.Button
    Friend WithEvents txtSrcFund As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents rbHigh As System.Windows.Forms.RadioButton
    Friend WithEvents rbNormal As System.Windows.Forms.RadioButton
    Friend WithEvents rbLow As System.Windows.Forms.RadioButton
    Friend WithEvents lvID As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtIDNum As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents cboType As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents btnPrimary As System.Windows.Forms.Button
    Friend WithEvents cboGender As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents txtWork As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents btnSetPri As System.Windows.Forms.Button
    Friend WithEvents txtPhone As System.Windows.Forms.TextBox
    Friend WithEvents lstPhone As System.Windows.Forms.ListBox
    Friend WithEvents btnCamera As System.Windows.Forms.Button
    Friend WithEvents grpCusPic As System.Windows.Forms.GroupBox
    Friend WithEvents ClientImage As System.Windows.Forms.PictureBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtSuffix As System.Windows.Forms.TextBox
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents btnHistory As System.Windows.Forms.Button

End Class
