Imports System.Data.Odbc

Module database
    Public con As OdbcConnection
    Friend dbName As String = "W3W1LH4CKU.FDB"
    Friend fbUser As String = "SYSDBA"
    Friend fbPass As String = "masterkey"
    Friend fbDataSet As New DataSet
    Private conStr As String = String.Empty

    Private language() As String = _
        {"Connection error failed."}

    Public Sub dbOpen()
        conStr = "DRIVER=Firebird/InterBase(r) driver;User=" & fbUser & ";Password=" & fbPass & ";Database=" & dbName & ";"

        con = New OdbcConnection(conStr)
        Try
            con.Open()
        Catch ex As Exception
            con.Dispose()
            MsgBox(language(0) + vbCrLf + ex.Message.ToString, vbCritical, "Error")
            Exit Sub
        End Try
    End Sub

    Public Sub dbClose()
        con.Close()
    End Sub

    Friend Function isReady() As Boolean
        Dim ready As Boolean = False
        Try
            dbOpen()
            ready = True
        Catch ex As Exception
            Console.WriteLine("[ERROR] " & ex.Message.ToString)
            Return False
        End Try

        Return ready
    End Function

    ' Module 001
    Friend Function SaveEntry(ByVal dsEntry As DataSet) As Boolean
        dbOpen()

        Try
            Dim da As OdbcDataAdapter
            Dim ds As New DataSet, mySql As String, fillData As String
            ds = dsEntry

            'Save all tables in the dataset
            For Each dsTable As DataTable In dsEntry.Tables
                fillData = dsTable.TableName
                mySql = "SELECT * FROM " & fillData

                da = New OdbcDataAdapter(mySql, con)
                Dim cb As New OdbcCommandBuilder(da) 'Required in Saving to Database
                da.Update(ds, fillData)
            Next

            dbClose()

            Return True
        Catch ex As Exception
            MsgBox("[Module 001 - SaveEntry]" & vbCr & ex.Message.ToString, MsgBoxStyle.Critical, "Saving Failed")
            dbClose()
            Return False
        End Try
    End Function
End Module
