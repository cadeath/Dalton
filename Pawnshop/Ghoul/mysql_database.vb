Imports MySQL.Data.MySqlClient

Module mysql_database

    Private _dbServer As String = Configure.DB_SERVER
    Friend _dbPort As Integer = Configure.DB_PORT
    Friend _dbName As String = Configure.DATABASE
    Friend _user As String = Configure.USER
    Friend _password As String = Configure.PASSWORD

    Friend _webServer As String = Configure.WEB_SERVER
    Friend _webPort As Integer = Configure.WEB_PORT

    Friend conMySql As MySqlConnection
    Private conStr As String

    Private _ERR1 As String = "Unable to connect to any of the specified MySQL hosts"

    Friend Function HTTP_SERVER(ByVal uri As String) As String
        Dim tPort As String = ""

        If _webPort <> 80 Then tPort = ":" & _webPort

        Return "http://" & _webServer & tPort & "/" & uri
    End Function

    Friend Function mySqlDBopen() As Boolean
        conStr = String.Format("SERVER={0};DATABASE={1};PORT={2};USER={3};PASSWORD={4}", _dbServer, _dbName, _dbPort, _user, _password)
        conMySql = New MySqlConnection
        conMySql.ConnectionString = conStr

        Try
            conMySql.Open()
        Catch ex As Exception
            If ex.ToString.Contains(_ERR1) Then
                Log_Report("Client is Down")
            Else
                Log_Report(ex.ToString)
            End If

            Return False
        End Try

        Return True
    End Function

    Friend Sub mySqlDBclose()
        conMySql.Close()
    End Sub

    Friend Function LoadMySQL(ByVal mySql As String, Optional ByVal dsName As String = "mySqltable") As DataSet
        Dim da As MySqlDataAdapter
        Dim ds As New DataSet

        Try
            If Not mySqlDBopen() Then Return Nothing

            da = New MySqlDataAdapter(mySql, conMySql)
            da.Fill(ds, dsName)
        Catch ex As Exception
            ds = Nothing
        End Try
        mySqlDBclose()

        Return ds
    End Function

    Friend Function SaveEntry_mySql(ByVal dsEntry As DataSet, Optional ByVal isNew As Boolean = True) As Boolean
        If dsEntry Is Nothing Then Return False

        If Not mySqlDBopen() Then Return False

        Dim da As MySqlDataAdapter
        Dim ds As New DataSet, mySql As String, dsName As String
        ds = dsEntry

        For Each dsTbl As DataTable In dsEntry.Tables
            dsName = dsTbl.TableName
            mySql = "SELECT * FROM " & dsName
            If Not isNew Then
                Dim colName As String = dsTbl.Columns(0).ColumnName
                Dim idx As Integer = dsTbl.Rows(0).Item(0)
                mySql &= String.Format(" WHERE {0} = {1}", colName, idx)
            End If

            da = New MySqlDataAdapter(mySql, conMySql)
            Dim cb As New MySqlCommandBuilder(da)
            da.Update(ds, dsName)
        Next

        mySqlDBclose()

        Return True
    End Function
End Module
