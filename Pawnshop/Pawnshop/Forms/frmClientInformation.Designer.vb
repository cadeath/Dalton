<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClientInformation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmClientInformation))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboProv = New System.Windows.Forms.ComboBox()
        Me.cboCity = New System.Windows.Forms.ComboBox()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.dtpBday = New System.Windows.Forms.DateTimePicker()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cboGender = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtZip = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtBrgy = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtStreet = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSuffix = New System.Windows.Forms.TextBox()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.txtMiddleName = New System.Windows.Forms.TextBox()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtOthers = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtTele = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtCP2 = New System.Windows.Forms.TextBox()
        Me.txtCP1 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.grpID = New System.Windows.Forms.GroupBox()
        Me.btnIDModify = New System.Windows.Forms.Button()
        Me.btnIDSelect = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtRef = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cboIDtype = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lvID = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnSelect = New System.Windows.Forms.Button()
        Me.webAds = New System.Windows.Forms.WebBrowser()
        Me.btnHistory = New System.Windows.Forms.Button()
        Me.grpDumper = New System.Windows.Forms.GroupBox()
        Me.chkDumper = New System.Windows.Forms.CheckBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.btnImportDumper = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.grpID.SuspendLayout()
        Me.grpDumper.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboProv)
        Me.GroupBox1.Controls.Add(Me.cboCity)
        Me.GroupBox1.Controls.Add(Me.lblAge)
        Me.GroupBox1.Controls.Add(Me.dtpBday)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.cboGender)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtZip)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtBrgy)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtStreet)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtSuffix)
        Me.GroupBox1.Controls.Add(Me.txtLastName)
        Me.GroupBox1.Controls.Add(Me.txtMiddleName)
        Me.GroupBox1.Controls.Add(Me.txtFirstName)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(545, 249)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Basic Information"
        '
        'cboProv
        '
        Me.cboProv.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboProv.FormattingEnabled = True
        Me.cboProv.Location = New System.Drawing.Point(364, 126)
        Me.cboProv.Name = "cboProv"
        Me.cboProv.Size = New System.Drawing.Size(165, 24)
        Me.cboProv.TabIndex = 7
        Me.cboProv.Text = "South Cotabato"
        '
        'cboCity
        '
        Me.cboCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCity.FormattingEnabled = True
        Me.cboCity.Location = New System.Drawing.Point(85, 126)
        Me.cboCity.Name = "cboCity"
        Me.cboCity.Size = New System.Drawing.Size(270, 24)
        Me.cboCity.TabIndex = 6
        Me.cboCity.Text = "General Santos City"
        '
        'lblAge
        '
        Me.lblAge.AutoSize = True
        Me.lblAge.Location = New System.Drawing.Point(433, 222)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(27, 13)
        Me.lblAge.TabIndex = 23
        Me.lblAge.Text = "N/A"
        '
        'dtpBday
        '
        Me.dtpBday.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpBday.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBday.Location = New System.Drawing.Point(301, 217)
        Me.dtpBday.Name = "dtpBday"
        Me.dtpBday.Size = New System.Drawing.Size(120, 22)
        Me.dtpBday.TabIndex = 10
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(227, 219)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(73, 16)
        Me.Label17.TabIndex = 22
        Me.Label17.Text = "Birthday: "
        '
        'cboGender
        '
        Me.cboGender.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboGender.FormattingEnabled = True
        Me.cboGender.Items.AddRange(New Object() {"Male", "Female"})
        Me.cboGender.Location = New System.Drawing.Point(85, 216)
        Me.cboGender.Name = "cboGender"
        Me.cboGender.Size = New System.Drawing.Size(121, 24)
        Me.cboGender.TabIndex = 9
        Me.cboGender.Text = "Male"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(6, 217)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(63, 16)
        Me.Label15.TabIndex = 20
        Me.Label15.Text = "Gender:"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(82, 194)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(81, 13)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "Zip Code"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtZip
        '
        Me.txtZip.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtZip.Location = New System.Drawing.Point(85, 169)
        Me.txtZip.MaxLength = 5
        Me.txtZip.Name = "txtZip"
        Me.txtZip.Size = New System.Drawing.Size(78, 22)
        Me.txtZip.TabIndex = 8
        Me.txtZip.Text = "9500"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(361, 153)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(168, 13)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Province"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(79, 153)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(276, 13)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "City/Municipal City"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(361, 112)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(168, 13)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Barangay"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtBrgy
        '
        Me.txtBrgy.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBrgy.Location = New System.Drawing.Point(364, 87)
        Me.txtBrgy.Name = "txtBrgy"
        Me.txtBrgy.Size = New System.Drawing.Size(165, 22)
        Me.txtBrgy.TabIndex = 5
        Me.txtBrgy.Text = "Lagao"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(79, 112)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(276, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Rm/Bldg/Street && Village"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtStreet
        '
        Me.txtStreet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStreet.Location = New System.Drawing.Point(82, 87)
        Me.txtStreet.Name = "txtStreet"
        Me.txtStreet.Size = New System.Drawing.Size(273, 22)
        Me.txtStreet.TabIndex = 4
        Me.txtStreet.Text = "153 Acacia St. Balite"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 90)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 16)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Address:"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(463, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 14)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Suffix"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(361, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 14)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Last Name"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(256, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 14)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Middle Name"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(62, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(188, 14)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "First Name"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtSuffix
        '
        Me.txtSuffix.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSuffix.Location = New System.Drawing.Point(466, 22)
        Me.txtSuffix.Name = "txtSuffix"
        Me.txtSuffix.Size = New System.Drawing.Size(35, 22)
        Me.txtSuffix.TabIndex = 3
        Me.txtSuffix.Text = "III"
        Me.txtSuffix.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtLastName
        '
        Me.txtLastName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastName.Location = New System.Drawing.Point(361, 22)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(99, 22)
        Me.txtLastName.TabIndex = 2
        Me.txtLastName.Text = "Maquilang"
        '
        'txtMiddleName
        '
        Me.txtMiddleName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMiddleName.Location = New System.Drawing.Point(256, 22)
        Me.txtMiddleName.Name = "txtMiddleName"
        Me.txtMiddleName.Size = New System.Drawing.Size(99, 22)
        Me.txtMiddleName.TabIndex = 1
        Me.txtMiddleName.Text = "Dingal"
        '
        'txtFirstName
        '
        Me.txtFirstName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFirstName.Location = New System.Drawing.Point(65, 22)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(185, 22)
        Me.txtFirstName.TabIndex = 0
        Me.txtFirstName.Text = "Eskie Cirrus James"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Name:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.txtOthers)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txtTele)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.txtCP2)
        Me.GroupBox2.Controls.Add(Me.txtCP1)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 267)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(545, 112)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Contact Information"
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(308, 93)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(168, 16)
        Me.Label16.TabIndex = 33
        Me.Label16.Text = "Other Number"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtOthers
        '
        Me.txtOthers.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOthers.Location = New System.Drawing.Point(311, 68)
        Me.txtOthers.Name = "txtOthers"
        Me.txtOthers.Size = New System.Drawing.Size(165, 22)
        Me.txtOthers.TabIndex = 14
        Me.txtOthers.Text = "@cadeath"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(123, 93)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(168, 16)
        Me.Label14.TabIndex = 31
        Me.Label14.Text = "Telephone (with 3 digit area code)"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtTele
        '
        Me.txtTele.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTele.Location = New System.Drawing.Point(126, 68)
        Me.txtTele.Name = "txtTele"
        Me.txtTele.Size = New System.Drawing.Size(165, 22)
        Me.txtTele.TabIndex = 13
        Me.txtTele.Text = "083-878-1533"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(123, 49)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(353, 16)
        Me.Label13.TabIndex = 29
        Me.Label13.Text = "Cellphone Numbers"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtCP2
        '
        Me.txtCP2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCP2.Location = New System.Drawing.Point(311, 21)
        Me.txtCP2.Name = "txtCP2"
        Me.txtCP2.Size = New System.Drawing.Size(165, 22)
        Me.txtCP2.TabIndex = 12
        Me.txtCP2.Text = "0920-255-2350"
        '
        'txtCP1
        '
        Me.txtCP1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCP1.Location = New System.Drawing.Point(126, 24)
        Me.txtCP1.Name = "txtCP1"
        Me.txtCP1.Size = New System.Drawing.Size(165, 22)
        Me.txtCP1.TabIndex = 11
        Me.txtCP1.Text = "0922-684-7559"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 27)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(114, 16)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "Phone Number:"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(868, 376)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(84, 40)
        Me.btnCancel.TabIndex = 24
        Me.btnCancel.Text = "&Close"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(778, 376)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(84, 40)
        Me.btnSave.TabIndex = 22
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'grpID
        '
        Me.grpID.Controls.Add(Me.btnIDModify)
        Me.grpID.Controls.Add(Me.btnIDSelect)
        Me.grpID.Controls.Add(Me.btnAdd)
        Me.grpID.Controls.Add(Me.txtRemarks)
        Me.grpID.Controls.Add(Me.Label20)
        Me.grpID.Controls.Add(Me.txtRef)
        Me.grpID.Controls.Add(Me.Label19)
        Me.grpID.Controls.Add(Me.cboIDtype)
        Me.grpID.Controls.Add(Me.Label18)
        Me.grpID.Controls.Add(Me.lvID)
        Me.grpID.Location = New System.Drawing.Point(563, 15)
        Me.grpID.Name = "grpID"
        Me.grpID.Size = New System.Drawing.Size(389, 274)
        Me.grpID.TabIndex = 5
        Me.grpID.TabStop = False
        Me.grpID.Text = "ID List"
        '
        'btnIDModify
        '
        Me.btnIDModify.Location = New System.Drawing.Point(86, 243)
        Me.btnIDModify.Name = "btnIDModify"
        Me.btnIDModify.Size = New System.Drawing.Size(75, 23)
        Me.btnIDModify.TabIndex = 26
        Me.btnIDModify.Text = "&Edit"
        Me.btnIDModify.UseVisualStyleBackColor = True
        Me.btnIDModify.Visible = False
        '
        'btnIDSelect
        '
        Me.btnIDSelect.Location = New System.Drawing.Point(308, 243)
        Me.btnIDSelect.Name = "btnIDSelect"
        Me.btnIDSelect.Size = New System.Drawing.Size(75, 23)
        Me.btnIDSelect.TabIndex = 20
        Me.btnIDSelect.Text = "&Select"
        Me.btnIDSelect.UseVisualStyleBackColor = True
        Me.btnIDSelect.Visible = False
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(9, 243)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 19
        Me.btnAdd.Text = "&Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'txtRemarks
        '
        Me.txtRemarks.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemarks.Location = New System.Drawing.Point(86, 69)
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(273, 22)
        Me.txtRemarks.TabIndex = 17
        Me.txtRemarks.Text = "MMMMM"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(6, 75)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(74, 16)
        Me.Label20.TabIndex = 25
        Me.Label20.Text = "Remarks:"
        '
        'txtRef
        '
        Me.txtRef.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRef.Location = New System.Drawing.Point(86, 44)
        Me.txtRef.Name = "txtRef"
        Me.txtRef.Size = New System.Drawing.Size(273, 22)
        Me.txtRef.TabIndex = 16
        Me.txtRef.Text = "XXX-XXXXXXXXX-1000"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(6, 47)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(44, 16)
        Me.Label19.TabIndex = 23
        Me.Label19.Text = "Ref #"
        '
        'cboIDtype
        '
        Me.cboIDtype.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboIDtype.FormattingEnabled = True
        Me.cboIDtype.Items.AddRange(New Object() {"Voter's ID", "SSS", "Phil Health", "Postal ID", "Company ID", "Driver's License", "Others"})
        Me.cboIDtype.Location = New System.Drawing.Point(86, 14)
        Me.cboIDtype.Name = "cboIDtype"
        Me.cboIDtype.Size = New System.Drawing.Size(136, 24)
        Me.cboIDtype.TabIndex = 15
        Me.cboIDtype.Text = "Voter's ID"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(6, 19)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(67, 16)
        Me.Label18.TabIndex = 1
        Me.Label18.Text = "ID Type:"
        '
        'lvID
        '
        Me.lvID.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.lvID.FullRowSelect = True
        Me.lvID.Location = New System.Drawing.Point(6, 99)
        Me.lvID.MultiSelect = False
        Me.lvID.Name = "lvID"
        Me.lvID.Size = New System.Drawing.Size(377, 138)
        Me.lvID.TabIndex = 18
        Me.lvID.UseCompatibleStateImageBehavior = False
        Me.lvID.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Type"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Ref #"
        Me.ColumnHeader2.Width = 198
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Remarks"
        Me.ColumnHeader3.Width = 102
        '
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(688, 376)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(84, 40)
        Me.btnSelect.TabIndex = 21
        Me.btnSelect.Text = "Sele&ct"
        Me.btnSelect.UseVisualStyleBackColor = True
        Me.btnSelect.Visible = False
        '
        'webAds
        '
        Me.webAds.Location = New System.Drawing.Point(570, 226)
        Me.webAds.MinimumSize = New System.Drawing.Size(20, 20)
        Me.webAds.Name = "webAds"
        Me.webAds.ScrollBarsEnabled = False
        Me.webAds.Size = New System.Drawing.Size(258, 62)
        Me.webAds.TabIndex = 25
        '
        'btnHistory
        '
        Me.btnHistory.Location = New System.Drawing.Point(563, 376)
        Me.btnHistory.Name = "btnHistory"
        Me.btnHistory.Size = New System.Drawing.Size(84, 40)
        Me.btnHistory.TabIndex = 26
        Me.btnHistory.Text = "&History"
        Me.btnHistory.UseVisualStyleBackColor = True
        '
        'grpDumper
        '
        Me.grpDumper.Controls.Add(Me.chkDumper)
        Me.grpDumper.Controls.Add(Me.Label21)
        Me.grpDumper.Location = New System.Drawing.Point(12, 382)
        Me.grpDumper.Name = "grpDumper"
        Me.grpDumper.Size = New System.Drawing.Size(545, 40)
        Me.grpDumper.TabIndex = 27
        Me.grpDumper.TabStop = False
        '
        'chkDumper
        '
        Me.chkDumper.AutoSize = True
        Me.chkDumper.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDumper.Location = New System.Drawing.Point(94, 16)
        Me.chkDumper.Name = "chkDumper"
        Me.chkDumper.Size = New System.Drawing.Size(95, 20)
        Me.chkDumper.TabIndex = 35
        Me.chkDumper.Text = "Is Dumper?"
        Me.chkDumper.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(6, 16)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(82, 16)
        Me.Label21.TabIndex = 34
        Me.Label21.Text = "Is Dumper:"
        '
        'btnImportDumper
        '
        Me.btnImportDumper.Location = New System.Drawing.Point(868, 326)
        Me.btnImportDumper.Name = "btnImportDumper"
        Me.btnImportDumper.Size = New System.Drawing.Size(84, 40)
        Me.btnImportDumper.TabIndex = 28
        Me.btnImportDumper.Text = "&Import Client"
        Me.btnImportDumper.UseVisualStyleBackColor = True
        '
        'frmClientInformation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(964, 428)
        Me.Controls.Add(Me.btnImportDumper)
        Me.Controls.Add(Me.grpDumper)
        Me.Controls.Add(Me.btnHistory)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.grpID)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.webAds)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmClientInformation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Client"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.grpID.ResumeLayout(False)
        Me.grpID.PerformLayout()
        Me.grpDumper.ResumeLayout(False)
        Me.grpDumper.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSuffix As System.Windows.Forms.TextBox
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents txtMiddleName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtStreet As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtBrgy As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtZip As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtTele As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtCP2 As System.Windows.Forms.TextBox
    Friend WithEvents txtCP1 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboGender As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtOthers As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents dtpBday As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents grpID As System.Windows.Forms.GroupBox
    Friend WithEvents lvID As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cboIDtype As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtRef As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnIDSelect As System.Windows.Forms.Button
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents btnSelect As System.Windows.Forms.Button
    Friend WithEvents btnIDModify As System.Windows.Forms.Button
    Friend WithEvents cboCity As System.Windows.Forms.ComboBox
    Friend WithEvents cboProv As System.Windows.Forms.ComboBox
    Friend WithEvents webAds As System.Windows.Forms.WebBrowser
    Friend WithEvents btnHistory As System.Windows.Forms.Button
    Friend WithEvents grpDumper As System.Windows.Forms.GroupBox
    Friend WithEvents chkDumper As System.Windows.Forms.CheckBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents btnImportDumper As System.Windows.Forms.Button
End Class
