Imports Microsoft.Office.Interop

Module pg_incomplete_desc

    Private Const FULL_DESCRIPTION As Integer = 2
    Private Const PAWNTICKET As Integer = 1

    Private mySql As String, fillData As String, ds As DataSet

    Friend Sub do_fix(src As String, dest As String)
        If Not System.IO.File.Exists(src) Then MsgBox(src & " not found.", MsgBoxStyle.Critical) : Exit Sub
        If Not System.IO.File.Exists(dest) Then MsgBox(dest & " not found.", MsgBoxStyle.Critical) : Exit Sub

        database.dbName = dest

        Dim oXL As New Excel.Application
        If oXL Is Nothing Then MessageBox.Show("Excel is not properly installed!!") : Exit Sub

        Dim MaxEntries As Integer
        Dim oWB As Excel.Workbook
        Dim oSheet As Excel.Worksheet
        Dim ExcelFile As String = src
        Dim FixClient As Integer = 0

        oWB = oXL.Workbooks.Open(ExcelFile)
        oSheet = oWB.Sheets(1)

        With oSheet
            MaxEntries = oSheet.Cells(.Rows.Count, 1).End(Excel.XlDirection.xlUp).row
        End With

        For iEnt As Integer = 2 To MaxEntries
            Dim Item_Description As String, pt As Integer
            Item_Description = oSheet.Cells(iEnt, FULL_DESCRIPTION).value
            pt = oSheet.Cells(iEnt, PAWNTICKET).value

            mySql = "SELECT * FROM TBLPAWN WHERE PAWNTICKET = " & pt
            fillData = "tblPawn"
            ds = LoadSQL(mySql, fillData)

            If ds.Tables(0).Rows.Count = 0 Then Console.WriteLine("PT# " & pt & " not found.") : Continue For
            'If Not IsDBNull(ds.Tables(0).Rows(0).Item("Description")) Then Continue For

            ds.Tables(0).Rows(0).Item("Description") = Item_Description
            database.SaveEntry(ds, False)

            FixClient += 1
            Status_Display(pt & " description changed")
        Next

        'Quit
        oSheet = Nothing
        oWB = Nothing
        oXL.Quit()
        oXL = Nothing

        MsgBox("Data patched up", MsgBoxStyle.Information)
    End Sub

    Private Sub Status_Display(ByVal stat As String)
        frmMain.lblRef.Text = stat
        Application.DoEvents()
    End Sub
End Module