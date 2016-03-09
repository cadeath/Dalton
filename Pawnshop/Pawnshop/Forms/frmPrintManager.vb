Imports System.Data.Odbc

Public Class frmPrintManager

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmPrintManager_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ClearFields()
        Load_PawnItems()
    End Sub

    Private Sub ClearFields()
        txtSearch.Text = ""
        lvPawnItems.Items.Clear()
    End Sub

    Private Sub Load_PawnItems()
        Console.WriteLine("Loading PawnItems...")
        Dim mySql As String, dbCon As String


        dbOpen() : dbClose()
        dbCon = database.conStr

        mySql = "SELECT * FROM PAWNING WHERE STATUS <> 'VOID';"
        lvPawnItems.Items.Clear()


        Dim myCon As New OdbcConnection(dbCon)
        Dim myCmd As New OdbcCommand(mySql, myCon)
        Try
            myCon.Open()

            Dim myReader As OdbcDataReader = myCmd.ExecuteReader
            While myReader.Read
                Dim lv As ListViewItem = lvPawnItems.Items.Add(myReader("PAWNTICKET").ToString)
                lv.SubItems.Add(myReader("DESCRIPTION").ToString)
                lv.SubItems.Add(myReader("ITEMTYPE").ToString)
            End While

        Catch ex As Exception
            myCon.Dispose()
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
            Exit Sub
        End Try
        myCon.Close()
    End Sub
End Class