Imports System.Data.Odbc
Imports Microsoft.Reporting.WinForms

Public Class frmPrintManager

    Private ORNUMBER As Integer = GetOption("ORLastNum")
    Private PRINTER_OR As String = GetOption("PrinterOR")

    Private Selected_Item As PawnTicket

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

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        If lvPawnItems.SelectedItems.Count = 0 Then Exit Sub

        AssignOR()

    End Sub

#Region "Procedures"
    Private Sub PrintOR()
        Dim autoPrintPT As Reporting

        Dim printerName As String = PRINTER_OR
        If Not canPrint(printerName) Then
            MsgBox("Unable to print" + vbCr + "Please check if the printer is online.", MsgBoxStyle.Critical, "PRINTER ERROR")
            Exit Sub
        End If

        Dim report As LocalReport = New LocalReport
        autoPrintPT = New Reporting
    End Sub

    Private Sub AssignOR()
        Dim pt As Integer = lvPawnItems.Items(0).Text
        Dim mySql As String = "SELECT * FROM tblPAWN WHERE PAWNTICKET = " & pt, _
            fillData As String = "tblPAWN"
        Dim ds As New DataSet
        ds = LoadSQL(mySql, fillData)
        If ds.Tables(fillData).Rows.Count = 0 Then
            MsgBox("Pawnticket not found", MsgBoxStyle.Critical, "Database Error")
            Exit Sub
        End If

        Selected_Item.LoadTicketInRow(ds.Tables(fillData).Rows(0))

        ds.Tables(fillData).Rows(0).Item("ORNUM") = ORNUMBER
        database.SaveEntry(ds, False)

        NextORNum()
    End Sub

    Private Sub NextORNum()
        ORNUMBER += 1
        UpdateOptions("ORLastNum", ORNUMBER)
    End Sub

    Private Function canPrint(ByVal printerName As String) As Boolean
        Try
            Dim printDocument As Drawing.Printing.PrintDocument = New Drawing.Printing.PrintDocument
            printDocument.PrinterSettings.PrinterName = printerName
            Return printDocument.PrinterSettings.IsValid
        Catch ex As Exception
            Return False
        End Try
    End Function
#End Region
End Class