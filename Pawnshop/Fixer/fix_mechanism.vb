Imports Microsoft.Office.Interop

Module fix_mechanism
    Private mySql As String = ""
    Private fillData As String = ""
    Private ds As DataSet

    Friend Const FULL_DESCRIPTION As Integer = 16
    Friend Const PAWNTICKET As Integer = 13
    Friend Const PAWNTICKET_import As Integer = 2

    Function getClientID(ByVal firstName As String, ByVal lastName As String) As Integer
        mySql = "SELECT * FROM tblClient"
        mySql &= String.Format(" WHERE FIRSTNAME = '{0}' AND LASTNAME = '{1}'", firstName, lastName)

        ds = LoadSQL(mySql)
        If ds.Tables(0).Rows.Count = 0 Then
            Return 0
        End If

        Return ds.Tables(0).Rows(0).Item("ClientID")
    End Function

    Sub SetupDatabase()
        database.dbName = frmMain.txtDB.Text
    End Sub

    Sub No_Description()
        Dim oXL As New Excel.Application
        If oXL Is Nothing Then MessageBox.Show("Excel is not properly installed!!") : Exit Sub
        SetupDatabase()

        Dim MaxEntries As Integer
        Dim oWB As Excel.Workbook
        Dim oSheet As Excel.Worksheet
        Dim ExcelFile As String = frmMain.txtImport.Text
        Dim FixClient As Integer = 0

        oWB = oXL.Workbooks.Open(ExcelFile)
        oSheet = oWB.Sheets(1)

        With oSheet
            MaxEntries = oSheet.Cells(.Rows.Count, 1).End(Excel.XlDirection.xlUp).row
        End With

        If oSheet.Cells(1, FULL_DESCRIPTION).value <> "FULL_DESCRIPTION" Then
            Status_Display("FULL_DESCRIPTION not found.")
            Exit Sub
        End If
        Status_Display("0/" & MaxEntries)
        For iEnt As Integer = 2 To MaxEntries
            Dim Item_Description As String, pt As Integer
            Item_Description = oSheet.Cells(iEnt, FULL_DESCRIPTION).value
            pt = oSheet.Cells(iEnt, PAWNTICKET_import).value
            mySql = "SELECT * FROM TBLPAWN WHERE PAWNTICKET = " & pt
            fillData = "tblPawn"
            ds = LoadSQL(mySql, fillData)

            Status_Display(iEnt & "/" & MaxEntries)
            If ds.Tables(0).Rows.Count = 0 Then Console.WriteLine("PT# " & pt & " not found.") : Continue For
            If Not IsDBNull(ds.Tables(0).Rows(0).Item("Description")) Then Continue For

            ds.Tables(0).Rows(0).Item("Description") = Item_Description
            database.SaveEntry(ds, False)

            FixClient += 1
            Console.WriteLine("PT#" & pt & " description changed")
        Next

        MsgBox(FixClient & " entries fixed.", MsgBoxStyle.Information)
    End Sub

    Sub Status_Display(ByVal stat As String)
        frmMain.lblRef.Text = stat
        Application.DoEvents()
    End Sub
End Module