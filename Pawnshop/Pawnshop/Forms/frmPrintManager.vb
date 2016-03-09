Imports System.Data.Odbc
Imports Microsoft.Reporting.WinForms

Public Class frmPrintManager

    Private ORNUMBER As Integer = GetOption("ORLastNum")
    Private PRINTER_OR As String = GetOption("PrinterOR")
    Private NUMCOPIES As Integer = 2

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

    Private Sub Load_PawnItems(Optional str As String = "")
        Console.WriteLine("Loading PawnItems...")
        Dim mySql As String, dbCon As String


        dbOpen() : dbClose()
        dbCon = database.conStr

        mySql = "SELECT * FROM PAWNING WHERE STATUS <> 'VOID'"
        If str <> "" Then
            Dim sanitize_str As String = str
            mySql &= String.Format(" AND PAWNTICKET LIKE '%{0}%'", sanitize_str)
        End If
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

        Dim copies As Integer = 0
        AssignOR()
        While copies < NUMCOPIES
            PrintOR()
            System.Threading.Thread.Sleep(1000)
            copies += 1
        End While
    End Sub

#Region "Procedures"

    Private Sub PrintOR()
        Dim autoPrintPT As Reporting

        Dim report As LocalReport = New LocalReport
        autoPrintPT = New Reporting

        Dim printerName As String = PRINTER_OR
        If Not canPrint(printerName) Then
            MsgBox("Unable to print" + vbCr + "Please check if the printer is online.", MsgBoxStyle.Critical, "PRINTER ERROR")
            Exit Sub
        End If

        Dim mySql As String, dsName As String = "dsPawn"
        mySql = "SELECT * FROM PRINT_PAWNING WHERE PAWNID = " & Selected_Item.PawnID

        Dim ds As DataSet = LoadSQL(mySql, dsName)
        report.ReportPath = "Reports\_layout03.rdlc"
        report.DataSources.Add(New ReportDataSource(dsName, ds.Tables(dsName)))

        ' HACK
        ' Get total due
        mySql = "SELECT * FROM TBLPAWN WHERE PAWNID = " & Selected_Item.PawnID
        Dim hackDs As DataSet = LoadSQL(mySql), total_due As Double = 0
        Dim st As String = hackDs.Tables(0).Rows(0).Item("STATUS")
        With hackDs.Tables(0).Rows(0)
            Select Case st
                Case "0", "R"
                    total_due = .Item("RENEWDUE")
                Case "X"
                    total_due = .Item("REDEEMDUE")
                Case "L"
                    total_due = .Item("NETAMOUNT")
                Case Else
                    MsgBox(st & " << WHAT STATUS IS THIS?", MsgBoxStyle.Critical, "STATUS UNKNOWN")
                    Exit Select
            End Select
        End With

        Dim addParameters As New Dictionary(Of String, String)
        addParameters.Add("txtPayment", "Payment INFORMATION here")
        addParameters.Add("dblTotalDue", total_due)

        If Not addParameters Is Nothing Then
            For Each nPara In addParameters
                Dim tmpPara As New ReportParameter
                tmpPara.Name = nPara.Key
                tmpPara.Values.Add(nPara.Value)
                report.SetParameters(New ReportParameter() {tmpPara})
                Console.WriteLine(String.Format("{0}: {1}", nPara.Key, nPara.Value))
            Next
        End If

        Dim paperSize As New Dictionary(Of String, Double)
        paperSize.Add("width", 8.5)
        paperSize.Add("height", 4.5) 'Changed 4.5 to 9

        autoPrintPT.Export(report, paperSize)
        autoPrintPT.m_currentPageIndex = 0
        autoPrintPT.Print(printerName)
    End Sub

    Private Sub AssignOR()
        Dim pt As Integer = lvPawnItems.SelectedItems(0).Text
        Dim mySql As String = "SELECT * FROM tblPAWN WHERE PAWNTICKET = " & pt, _
            fillData As String = "tblPAWN"
        Dim ds As New DataSet
        ds = LoadSQL(mySql, fillData)
        If ds.Tables(fillData).Rows.Count = 0 Then
            MsgBox("Pawnticket not found", MsgBoxStyle.Critical, "Database Error")
            Exit Sub
        End If

        Dim PawnID As Integer = ds.Tables(fillData).Rows(0).Item("PAWNID")

        Selected_Item = New PawnTicket
        Selected_Item.LoadTicket(PawnID)

        If ds.Tables(fillData).Rows(0).Item("ORNUM") = 0 Then
            ds.Tables(fillData).Rows(0).Item("ORNUM") = ORNUMBER
            database.SaveEntry(ds, False)

            NextORNum()
        End If
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

    Private Sub btnSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click
        Load_PawnItems(txtSearch.Text)
    End Sub
End Class