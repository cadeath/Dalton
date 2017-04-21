Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Linq
Imports System.Text
Imports System.Runtime.Serialization
Imports System.Security.Cryptography
Imports System.Data.Odbc

Module mod_system

    Public con As OdbcConnection
    Public ReaderCon As OdbcConnection
    Friend dbName As String = ""
    Friend fbUser As String = "SYSDBA"
    Friend fbPass As String = "masterkey"
    Friend fbDataSet As New DataSet
    Friend conStr As String = String.Empty

    Friend Function SaveEntry(ByVal dsEntry As DataSet, Optional ByVal isNew As Boolean = True) As Boolean
        If dsEntry Is Nothing Then
            Return False
        End If

        dbOpen()

        Dim da As OdbcDataAdapter
        Dim ds As New DataSet, mySql As String, fillData As String
        ds = dsEntry

        'Save all tables in the dataset
        For Each dsTable As DataTable In dsEntry.Tables
            fillData = dsTable.TableName
            mySql = "SELECT * FROM " & fillData
            If Not isNew Then
                Dim colName As String = dsTable.Columns(0).ColumnName
                Dim idx As Integer = dsTable.Rows(0).Item(0)
                mySql &= String.Format(" WHERE {0} = {1}", colName, idx)

                Console.WriteLine("ModifySQL: " & mySql)
            End If

            da = New OdbcDataAdapter(mySql, con)
            Dim cb As New OdbcCommandBuilder(da) 'Required in Saving/Update to Database
            da.Update(ds, fillData)
        Next

        dbClose()
        Return True
    End Function

    Friend Sub RunCommand(ByVal sql As String)
        conStr = "DRIVER=Firebird/InterBase(r) driver;User=" & fbUser & ";Password=" & fbPass & ";Database=" & dbName & ";"
        con = New OdbcConnection(conStr)

        Dim cmd As OdbcCommand
        cmd = New OdbcCommand(sql, con)

        Try
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
            Log_Report(String.Format("[{0}] - ", sql) & ex.ToString)
            con.Dispose()
            Exit Sub
        End Try

        System.Threading.Thread.Sleep(1000)
    End Sub

    Friend Sub Database_Update(ByVal str As String)
        Dim mySql As String = "UPDATE tblMaintenance"
        mySql &= String.Format(" SET OPT_VALUES = '{0}' ", str)
        mySql &= "WHERE OPT_KEYS = 'DBVersion'"

        RunCommand(mySql)
    End Sub

    Friend Function ifTblExist(ByVal tblName As String) As Boolean
        Dim mySql As String
        mySql = "SELECT * FROM rdb$relations "
        mySql &= "WHERE "
        mySql &= String.Format("rdb$relation_name = '{0}'", tblName)

        Dim ds As DataSet = LoadSQL(mySql)
        If ds.Tables(0).Rows.Count = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Friend Function LoadSQL(ByVal mySql As String, Optional ByVal tblName As String = "QuickSQL") As DataSet
        dbOpen()

        Dim da As OdbcDataAdapter
        Dim ds As New DataSet, fillData As String = tblName
        Try
            da = New OdbcDataAdapter(mySql, con)
            da.Fill(ds, fillData)
        Catch ex As Exception
            Console.WriteLine(">>>>>" & mySql)
            MsgBox(ex.ToString)
            Log_Report("LoadSQL - " & ex.ToString)
            ds = Nothing
        End Try

        dbClose()

        Return ds
    End Function

    Public Sub dbOpen()
        conStr = "DRIVER=Firebird/InterBase(r) driver;User=" & fbUser & ";Password=" & fbPass & ";Database=" & dbName & ";"

        con = New OdbcConnection(conStr)
        Try
            con.Open()
        Catch ex As Exception
            con.Dispose()
            Exit Sub
        End Try
    End Sub

    Public Sub dbClose()
        con.Close()
    End Sub

#Region "Log Module"
    Const LOG_FILE As String = "syslog-update.txt"
    Private Sub CreateLog()
        Dim fsEsk As New System.IO.FileStream(LOG_FILE, IO.FileMode.CreateNew)
        fsEsk.Close()
    End Sub

    Friend Sub Log_Report(ByVal str As String)
        If Not System.IO.File.Exists(LOG_FILE) Then CreateLog()

        Dim recorded_log As String = _
            String.Format("[{0}] " & str, Now.ToString("MM/dd/yyyy HH:mm:ss"))

        Dim fs As New System.IO.FileStream(LOG_FILE, IO.FileMode.Append, IO.FileAccess.Write)
        Dim fw As New System.IO.StreamWriter(fs)
        fw.WriteLine(recorded_log)
        fw.Close()
        fs.Close()
        Console.WriteLine("Recorded")
    End Sub
#End Region

    Friend Sub AutoIncrement_ID(tbl As String, id As String)
        Dim GENERATOR As String
        GENERATOR = String.Format("CREATE GENERATOR {0}_{1}_GEN; ", tbl, id)
        RunCommand(GENERATOR)

        GENERATOR = String.Format("SET GENERATOR ""{0}_{1}_GEN"" TO 0;", tbl, id)
        RunCommand(GENERATOR)

        GENERATOR = String.Format("CREATE TRIGGER ""{0}_{1}_TRG"" FOR ""{0}""", tbl, id)
        GENERATOR &= vbCrLf & "ACTIVE BEFORE INSERT POSITION 0 AS"
        GENERATOR &= vbCrLf & "BEGIN"
        GENERATOR &= vbCrLf & String.Format("IF (NEW.""{1}"" IS NULL) THEN NEW.""{1}"" = GEN_ID(""{0}_{1}_GEN"", 1);", tbl, id)
        GENERATOR &= vbCrLf & "END;"
        RunCommand(GENERATOR)

    End Sub

    Friend Function GetMD5(ds As DataSet) As String
        Dim serialize As DataContractSerializer = New DataContractSerializer(GetType(DataSet))
        Dim MemoryStream As New MemoryStream
        Dim xmlW As XmlDictionaryWriter
        xmlW = XmlDictionaryWriter.CreateBinaryWriter(MemoryStream)
        serialize.WriteObject(MemoryStream, ds)

        Dim sd As Byte() = MemoryStream.ToArray
        Dim MD5 As New MD5CryptoServiceProvider
        Dim md5Byte As Byte() = MD5.ComputeHash(sd)

        Return Convert.ToBase64String(md5Byte)
    End Function

    Friend Sub SystemUpdate(str As String)
        frmMain.lblText.Text = str
        Application.DoEvents()
    End Sub

End Module