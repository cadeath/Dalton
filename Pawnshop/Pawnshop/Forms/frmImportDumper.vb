Imports Microsoft.Office.Interop
Public Class frmImportDumper

    Private Sub frmImportDumper_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.TopMost = True
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        ofdIMportDumper.ShowDialog()
        lblPath.Text = ofdIMportDumper.FileName
    End Sub

    'Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
    '        If lblPath.Text = "File not yet" Then Exit Sub

    '        Dim filename As String = lblPath.Text
    '        Dim oXL As New Excel.Application
    '        Dim oWB As Excel.Workbook
    '        Dim oSheet As Excel.Worksheet

    '        oWB = oXL.Workbooks.Open(fileName)
    '        oSheet = oWB.Worksheets(1)

    '        Dim MaxColumn As Integer = oSheet.Cells(1, oSheet.Columns.Count).End(Excel.XlDirection.xlToLeft).column
    '        Dim MaxEntries As Integer = oSheet.Cells(oSheet.Rows.Count, 1).End(Excel.XlDirection.xlUp).row

    '        Dim checkHeaders(MaxColumn) As String
    '        For cnt As Integer = 0 To MaxColumn - 1
    '            checkHeaders(cnt) = oSheet.Cells(1, cnt + 1).value
    '        Next : checkHeaders(MaxColumn) = oWB.Worksheets(1).name


    '        For cnt = 2 To MaxEntries
    '            Dim mysql As String = "SELECT C.CLIENTID, C.FIRSTNAME || ' ' || C.LASTNAME || ' ' || "
    '            mysql &= " CASE WHEN C.SUFFIX is Null THEN '' ELSE C.SUFFIX END AS CLIENT, C.PHONE1 AS CONTACTNUMBER "
    '            mysql &= " FROM TBLCLIENT C C WHERE "
    '            mysql &= "(C.FIRSTNAME || ' ' || C.LASTNAME || ' ' || "
    '            mysql &= "CASE WHEN C.SUFFIX is Null THEN '' ELSE C.SUFFIX END) = '" & oSheet.Cells(cnt, 1).Value & "'"
    '            mysql &= " AND BIRTHDAY = '" & oSheet.Cells(cnt, 2).value & "'"


    '            Dim ds As DataSet = LoadSQL(mysql, "TBLCLIENT")

    '            If ds.Tables(0).Rows.Count = 0 Then
    '                Dim drNewrow As DataRow
    '                drNewrow = ds.Tables(0).NewRow
    '                With drNewrow
    '                    .Item("FirstName") = _firstName
    '                    .Item("MiddleName") = _middleName
    '                    .Item("LastName") = _lastName
    '                    .Item("Suffix") = _suffixName
    '                    .Item("Addr_Street") = _addrSt
    '                    .Item("Addr_Brgy") = _addrBrgy
    '                    .Item("Addr_City") = _addrCity
    '                    .Item("Addr_Province") = _addrProvince
    '                    .Item("Addr_Zip") = _addrZip
    '                    .Item("Sex") = _gender
    '                    .Item("Birthday") = _bday
    '                    .Item("Phone1") = _cp1
    '                    .Item("Phone2") = _cp2
    '                    .Item("Phone3") = _phone
    '                    .Item("Phone_Others") = _otherNum
    '                    .Item("IsDumper") = 1
    '                End With
    '            End If

    '        Next
    '        Me.Enabled = True

    'unloadObj:
    '        'Memory Unload
    '        oSheet = Nothing
    '        oWB = Nothing
    '        oXL.Quit()
    '        oXL = Nothing

    '        MsgBox("Item Loaded", MsgBoxStyle.Information)
    '    End Sub


End Class