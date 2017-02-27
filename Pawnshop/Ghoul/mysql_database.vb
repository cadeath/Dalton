Imports MySQL.Data.MySqlClient

Module mysql_database

    Friend DB_SERVER As String = "192.164.0.188" 'mrfaust.hopto.org
    Friend DB_PORT As Integer = 3306
    Friend DATABASE As String = "newdb"
    Friend USER As String = "root"
    Friend PASSWORD As String = ""

    Friend WEB_SERVER As String = "192.164.0.188"
    Friend WEB_PORT As Integer = 8000

    Friend conMySql As MySqlConnection
    Private conStr As String

    Private _ERR1 As String = "Unable to connect to any of the specified MySQL hosts"

    Friend Function HTTP_SERVER(ByVal uri As String) As String
        Dim tPort As String = ""

        If WEB_PORT <> 80 Then tPort = ":" & WEB_PORT

        Return "http://" & WEB_SERVER & tPort & "/" & uri
    End Function

    Friend Function mySqlDBopen() As Boolean
        conStr = String.Format("SERVER={4};DATABASE={0};PORT={1};USER={2};PASSWORD={3}", DATABASE, DB_PORT, USER, PASSWORD, DB_SERVER)
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
