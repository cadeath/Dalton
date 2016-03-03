Imports Microsoft.Office.Interop

Public Class frmMain

    Private Sub ofdTemplate_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ofdTemplate.FileOk
        txtImport.Text = ofdTemplate.FileName
    End Sub

    Private Sub ofdFirebird_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ofdFirebird.FileOk
        txtDB.Text = ofdFirebird.FileName
    End Sub

    Private Sub SetupDatabase()
        database.dbName = txtDB.Text
    End Sub

    Private Sub btnFix_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFix.Click
        If Not System.IO.File.Exists(txtDB.Text) Then Exit Sub
        If Not System.IO.File.Exists(txtImport.Text) Then Exit Sub

        'MigrateIssue()
        btnFix.Enabled = False

        'No_Description()
        pg_incomplete_desc.do_fix(txtImport.Text, txtDB.Text)

        btnFix.Enabled = True
    End Sub

    Private Sub MigrateIssue()
        Dim oXL As New Excel.Application
        If oXL Is Nothing Then MessageBox.Show("Excel is not properly installed!!") : Exit Sub
        SetupDatabase()
        btnFix.Enabled = False

        Dim MaxEntries As Integer
        Dim oWB As Excel.Workbook
        Dim oSheet As Excel.Worksheet
        Dim ExcelFile As String = txtImport.Text
        Dim FixClient As Integer = 0

        oWB = oXL.Workbooks.Open(ExcelFile)
        oSheet = oWB.Sheets(1)

        With oSheet
            MaxEntries = oSheet.Cells(.Rows.Count, 1).End(Excel.XlDirection.xlUp).row
        End With

        Status_Display("0/" & MaxEntries)
        For iEnt As Integer = 2 To MaxEntries
            'Checking Client
            Dim colIdx As Integer = 0 : colIdx += 1
            Dim ds As New DataSet, mySql As String, pt As Integer
            Dim fname As String, lname As String, ClientID As Integer

            fname = oSheet.Cells(iEnt, 1).value
            lname = oSheet.Cells(iEnt, 2).value
            ClientID = getClientID(fname, lname)
            Status_Display(iEnt & "/" & MaxEntries)

            'Console.WriteLine(String.Format("{0} {1}|ID: {2}", fname, lname, ClientID))
            If ClientID = 0 Then Continue For 'Next Loop

            pt = CInt(oSheet.Cells(iEnt, PAWNTICKET).value)
            mySql = "SELECT * FROM tblPawn WHERE PAWNTICKET = " & pt
            ds = LoadSQL(mySql, "tblPawn")

            If ds.Tables(0).Rows(0).Item("ClientID") = ClientID Then Continue For
            ds.Tables(0).Rows(0).Item("ClientID") = ClientID
            Console.WriteLine(String.Format("PT#{0:000000} client changed.", pt))
            database.SaveEntry(ds, False)
            FixClient += 1
        Next

        'Quit
        oSheet = Nothing
        oWB = Nothing
        oXL.Quit()
        oXL = Nothing

        MsgBox(FixClient & " Client fixed.", MsgBoxStyle.Information)
        btnFix.Enabled = True
    End Sub

    Private Sub txtImport_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtImport.DoubleClick
        ofdTemplate.ShowDialog()
    End Sub

    Private Sub txtDB_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDB.DoubleClick
        ofdFirebird.ShowDialog()
    End Sub
End Class
