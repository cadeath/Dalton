Imports System.IO
Public Class Form1

    Dim mysql As String = String.Empty
    Dim old_tabl As String = "tbl_gamit"
    Dim tbluserNEW As String = "tbl_user_default"
    Dim tbluserHist As String = "tbluser_history"

    Dim user_defaultID As Integer = 0
    Dim userHistID As Integer = 0

    Dim s_USER As New Sys_user
    Dim save_Upriv As New User_rule

    Dim dsPrivilege As New DataSet
    Dim PRIVILEGE_FROM_OLD_TABLE As String

    Dim PRIV_ht As New Hashtable
    Dim privileges As String = ""
    Dim accessType As String = ""

    Dim src As String = AppDomain.CurrentDomain.BaseDirectory & "W3W1LH4CKU.FDB" 'DB
    Dim priv_path As String = AppDomain.CurrentDomain.BaseDirectory & "privilege.anoisim" 'Privilege
    Private privCount As Integer = 0

    Private Sub LoadPath()
        Dim readValue = My.Computer.Registry.GetValue(
    "HKEY_LOCAL_MACHINE\Software\cdt-S0ft\Pawnshop", "InstallPath", Nothing)

        Dim path As String = readValue & "\W3W1LH4CKU.FDB"


        If File.Exists(path) Then
            database.dbName = path
            txtPath.Text = path
        Else
            MsgBox("No Database found.", MsgBoxStyle.Critical, "Error")
            '    database.dbName = src
            '    txtPath.Text = src
        End If
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblPercent.Visible = False
        LoadPath()
        System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
    End Sub
   
    Private Sub DisableField(ByVal st As Boolean)
        btnMigrate.Enabled = st
        btnExit.Enabled = st
        btnBrowse.Enabled = st
    End Sub

    Private Sub btnMigrate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMigrate.Click
        If txtPath.Text = "" Then Exit Sub
        If ifTblExist("TBL_USER_DEFAULT") Then Exit Sub
        DisableField(False)
        tmr.Start()
    End Sub

    Private Sub save_privilege()
        mysql = "SELECT * FROM " & old_tabl & " ORDER BY USERID ASC"
        Dim ds As DataSet = LoadSQL(mysql, old_tabl)
        Dim isGrtrThan34 As Boolean = False

        For Each dr As DataRow In ds.Tables(0).Rows
            If dr.Item("PRIVILEGE") = "PDuNxp8S9q0=" Then Continue For
            Dim iCountStr As String = dr.Item("PRIVILEGE")

            If iCountStr.Length <> "34" Then
                isGrtrThan34 = True : Exit For
            End If
        Next

        If Not isGrtrThan34 Then
            For Each Line As String In File.ReadLines(priv_path)
                If Line = "StockOut" Or Line = "Return" Then Continue For
                With save_Upriv
                    If Line = "" Then
                        Exit For
                    End If
                    .Privilege_Type = Line
                    .adpri_Save(Line)
                End With
            Next
        Else
            For Each Line As String In File.ReadLines(priv_path)
                With save_Upriv
                    If Line = "" Then
                        Exit For
                    End If
                    .Privilege_Type = Line
                    .adpri_Save(Line)
                End With
            Next
        End If

        Console.WriteLine("Successfully saved." & "Thank you")
    End Sub

    Private Sub User_Migrate()
        s_USER.CreateAdministrator()

        mysql = "SELECT * FROM " & old_tabl & " ORDER BY USERID ASC"
        Dim ds As DataSet = LoadSQL(mysql, old_tabl)

        If ds.Tables(0).Rows.Count = 0 Then DisableField(True) : Exit Sub
        Dim tblID As String = ""

        Dim iCount As Integer = ds.Tables(0).Rows.Count
        For Each dr As DataRow In ds.Tables(0).Rows
            tblID = dr.Item("USERID")
            privileges = dr.Item("PRIVILEGE")
            If dr.Item("Username") = "POSadmin" Then Continue For

            With s_USER
                .ID = dr.Item("USERID")

                .USERNAME = dr.Item("Username")

                .FIRSTNAME = dr.Item("Fullname")

                If dr.Item("Username") = "POSadmin" Then
                    .LASTNAME = ""
                Else
                    .LASTNAME = "Not define"
                End If

                .USERPASS = dr.Item("Userpass")

                .GENDER = "No Gen"

                .BIRTHDAY = "01/01/1992"

                If IsDBNull(dr.Item("EncoderID")) Then
                    .EncoderID = 0
                Else
                    .EncoderID = dr.Item("EncoderID")
                End If

                If IsDBNull(dr.Item("LastLogin")) Then
                    .LastLogin = "01/01/0001"
                Else
                    .LastLogin = dr.Item("LastLogin")
                End If

                If dr.Item("Status") = 1 Then
                    .PASSWORD_AGE = Now.AddDays(90)

                    .PASSWORD_EXPIRY = Now.AddDays(30)
                    .ISEXPIRED = 1
                    .COUNTER = 30
                Else
                    .PASSWORD_AGE = "01/01/0001"

                    .PASSWORD_EXPIRY = "01/01/0001"
                    .ISEXPIRED = 0
                    .COUNTER = 0
                End If

                If dr.Item("Username") = "POSadmin" Then
                    .USERTYPE = "Admin"
                Else
                    .FAILEDATTEMPNUM = 3
                    .FAILEDATTEMPSTAT = "Enable"
                    .USERTYPE = "User"
                End If

                .UserStatus = dr.Item("Status")

                .add_USER()

                If privileges.Length = "34" Then
                    For Each Line As String In File.ReadLines(priv_path)
                        If Line = "StockOut" Or Line = "Return" Then Continue For
                        .USERID = dr.Item("USERID")
                        .PRIVILEGE_TYPE = Line
                        .ACCESSTYPE = GetPrivilege()

                        .Save_Privilege(dr.Item("USERID"), False)
                    Next
                Else
                    For Each Line As String In File.ReadLines(priv_path)
                        If Line = "StockOut" Or Line = "Return" Then Continue For
                        .USERID = dr.Item("USERID")
                        .PRIVILEGE_TYPE = Line
                        .ACCESSTYPE = GetPrivilege()

                        .Save_Privilege(dr.Item("USERID"), False)
                    Next
                End If


            End With

            PRIVILEGE_FROM_OLD_TABLE = dr.Item("Privilege")

            pbMigrate.Maximum = iCount
            pbMigrate.Value = pbMigrate.Value + 1
            Application.DoEvents()
            lblPercent.Text = String.Format("{0}%", ((pbMigrate.Value / pbMigrate.Maximum) * 100).ToString("F2"))

        Next

        mysql = "CREATE TRIGGER BI_tbl_user_default_USERID FOR tbl_user_default "
        mysql &= vbCrLf & "ACTIVE BEFORE INSERT "
        mysql &= vbCrLf & "POSITION 0 "
        mysql &= vbCrLf & "AS "
        mysql &= vbCrLf & "BEGIN "
        mysql &= vbCrLf & "  IF (NEW.USERID IS NULL) THEN "
        mysql &= vbCrLf & "      NEW.USERID = GEN_ID(tbl_user_default_USERID_GEN, " & tblID + 1 & "); "
        mysql &= vbCrLf & "END; "
        RunCommand(mysql)

        mysql = "SELECT USERLINE_ID FROM TBL_USERLINE ORDER BY USERLINE_ID ASC"
        Dim ds1 As DataSet = LoadSQL(mysql, "TBL_USERLINE")
        Dim iCnt As Integer = ds1.Tables(0).Rows.Count

        mysql = "CREATE TRIGGER BI_TBL_USERLINE_USERLINE_ID FOR TBL_USERLINE "
        mysql &= vbCrLf & "ACTIVE BEFORE INSERT "
        mysql &= vbCrLf & "POSITION 0 "
        mysql &= vbCrLf & "AS "
        mysql &= vbCrLf & "BEGIN "
        mysql &= vbCrLf & "  IF (NEW.USERLINE_ID IS NULL) THEN "
        mysql &= vbCrLf & "      NEW.USERLINE_ID = GEN_ID(TBL_USERLINE_USERLINE_ID_GEN, " & tblID + 1 & "); "
        mysql &= vbCrLf & "END; "
        RunCommand(mysql)


        If MsgBox("Successfully Migrated", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, _
            "Migrating...") = MsgBoxResult.Ok Then pbMigrate.Minimum = 0 : pbMigrate.Value = 0 : lblPercent.Text = "0.00%"
        DisableField(True)

    End Sub

    Private Function GetPrivilege() As String
        Console.WriteLine(privileges)
        For Each Chr As Char In privileges
            If Chr = "|" Then
                privileges = privileges.Remove(0, 1)
                On Error Resume Next
            Else
                If Chr = "1" Then
                    accessType = "Full Access"

                    privileges = privileges.Remove(0, 1)
                    Console.WriteLine(privileges)
                    Console.WriteLine(privileges.Length)

                    Return accessType
                Else
                    accessType = "No Access"

                    privileges = privileges.Remove(0, 1)
                    Console.WriteLine(privileges)
                    Console.WriteLine(privileges.Length)

                    Return accessType
                End If

            End If
        Next

        Return accessType
    End Function

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        ofd.ShowDialog()
    End Sub

    Private Sub ofd_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ofd.FileOk
        database.dbName = ofd.FileName
        txtPath.Text = ofd.FileName

        '  Load_Privilege()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        End
    End Sub

    Private Sub bg_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bg.DoWork
        Me.Cursor = Cursors.WaitCursor
        lblStatus.Text = "Creating tables to your database" & vbCrLf & "Please wait. . ."

        DisableField(False)
        User_rule_mod.Create_User_Rule_Table()
        User_rule_mod.Create_User_table()
        User_rule_mod.Create_User_history()
        User_rule_mod.Create_User_LINE()
        lblPercent.Visible = True
        lblStatus.Text = "Migrating Data" & vbCrLf & "Do not exit the application!!!"
        save_privilege()
        User_Migrate()

     
    End Sub

    Private Sub tmr_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr.Tick
        tmr.Stop()
        bg.RunWorkerAsync()
    End Sub

    Private Sub bg_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bg.RunWorkerCompleted
        Console.WriteLine("Successfully creating tables.")
        txtPath.Text = ""
        lblStatus.Text = "Migrate completed."
        Me.Cursor = Cursors.Default
    End Sub

    'Private Sub Load_Privilege()
    '    If Not autopatch.ifTblExist("TBL_USERRULE") Then
    '        Exit Sub
    '    End If

    '    mysql = "SELECT * FROM TBL_USERRULE"
    '    Dim ds As DataSet = LoadSQL(mysql, "TBL_USERRULE")

    '    For Each dr As DataRow In ds.Tables(0).Rows
    '        DataGridView1.Rows.Add(dr.Item("UserRule_ID"), dr.Item("Privilege_type"))
    '    Next
    'End Sub

    'Private Sub DataGridView1_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs)
    '    Dim CurrentRow As Integer = e.RowIndex
    '    DataGridView1.Rows(CurrentRow).Cells(0).Value = CurrentRow + 1
    'End Sub

   

    'Private Sub SFD_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SFD.FileOk
    '    Dim ans As DialogResult = MsgBox("Do you want to save this?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
    '    If ans = Windows.Forms.DialogResult.No Then Exit Sub

    '    Dim fn As String = SFD.FileName : Me.DataGridView1.AllowUserToAddRows = False

    '    dgridViewTods(DataGridView1)

    '    ExportConfig(fn, dsPrivilege)
    '    DataGridView1.Rows.Clear() : MsgBox("Data Exported", MsgBoxStyle.Information)
    'End Sub


    Sub ExportConfig(ByVal url As String, ByVal serialDS As DataSet)
        'If System.IO.File.Exists(url) Then System.IO.File.Delete(url)

        Dim fsEsk As New System.IO.FileStream(url, IO.FileMode.CreateNew)
        Dim esk As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
        esk.Serialize(fsEsk, serialDS)
        fsEsk.Close()
    End Sub


    Private Function dgridViewTods(ByVal dgv As DataGridView) As DataSet

        Try
            ' Add Table
            dsPrivilege.Tables.Add("tbl_userRule")

            ' Add Columns
            Dim col As DataColumn
            For Each dgvCol As DataGridViewColumn In dgv.Columns
                col = New DataColumn(dgvCol.Name)
                dsPrivilege.Tables("tbl_userRule").Columns.Add(col)
            Next

           
            'Add Rows from the datagridview
            Dim row As DataRow
            For i As Integer = 0 To dgv.Rows.Count - 1
                row = dsPrivilege.Tables("tbl_userRule").Rows.Add
                For Each column As DataGridViewColumn In dgv.Columns
                    row.Item(column.Index) = dgv.Rows.Item(i).Cells(column.Index).Value
                Next
            Next

            Return dsPrivilege

        Catch ex As Exception

            MsgBox("CRITICAL ERROR : Exception caught while converting dataGridView to DataSet (dgvtods).. " & Chr(10) & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Sub btnCreateCir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' If dsPrivilege.Tables.Count < 1 Then MsgBox("No Module Found!", MsgBoxStyle.Critical) : Exit Sub
        SFD.ShowDialog()
    End Sub

    'Private Sub removecell()

    '    Dim mtCell As Integer = 0
    '    Dim row As DataGridViewRow = New DataGridViewRow()
    '    For rowNo As Integer = DataGridView1.Rows.Count - 2 To 0 Step -1
    '        row = DataGridView1.Rows(rowNo)
    '        Try
    '            For j = 0 To row.Cells.Count - 2
    '                If row.Cells(j).Value Is Nothing OrElse row.Cells(j).Value Is DBNull.Value Then
    '                    mtCell += 1
    '                End If
    '            Next
    '            If mtCell = row.Cells.Count - 1 Then 'I understand that you want to delete the row ONLY if all its cells are null 
    '                DataGridView1.Rows.RemoveAt(rowNo)
    '            End If
    '            mtCell = 0
    '        Catch ex As Exception
    '            Exit For
    '        End Try
    '    Next rowNo
    'End Sub

    'Private Sub btnUpdatePrivilete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    System.IO.File.WriteAllText(priv_path, "")

    '    Using sw As StreamWriter = File.AppendText(priv_path)
    '        For Each row As DataGridViewRow In dgPrivFromTextfile.Rows
    '            sw.WriteLine(row.Cells(0).Value)
    '        Next
    '        sw.Close()
    '    End Using

    '    DataGridView1.Rows.Clear()
    '    loadPriv_FromTextfile2()

    '    MsgBox("Successfully Updated.", MsgBoxStyle.Information, "Update")
    'End Sub

    '    Private Sub loadPriv_FromTextfile()
    '        Dim rowvalue As String
    '        Dim cellvalue(20) As String
    '        Dim streamReader As IO.StreamReader = New IO.StreamReader(priv_path)
    '        While streamReader.Peek() <> -1
    '            rowvalue = streamReader.ReadLine()

    '            If rowvalue = "" Then
    '                GoTo nextLineTOdo
    '            End If

    '            cellvalue = rowvalue.Split(","c) 'check what is ur separator


    '            dgPrivFromTextfile.Rows.Add(cellvalue)
    'nextLineTOdo:
    '        End While
    '        streamReader.Close()
    '    End Sub

    '    Private Sub loadPriv_FromTextfile2()
    '        Dim i As Integer = 0
    '        Dim rowvalue As String
    '        Dim streamReader As IO.StreamReader = New IO.StreamReader(priv_path)
    '        While streamReader.Peek() <> -1
    '            rowvalue = streamReader.ReadLine()

    '            If rowvalue = "" Then
    '                GoTo nextLineTOdo
    '            End If
    '            i += 1
    '            DataGridView1.Rows.Add(i, rowvalue)

    'nextLineTOdo:
    '        End While
    '        streamReader.Close()
    '    End Sub


End Class
