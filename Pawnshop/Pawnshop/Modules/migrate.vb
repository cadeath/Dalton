Imports Microsoft.Office.Interop

Module migrate
    Private mySql As String = String.Empty

    Friend Function ifSex(ByVal str As String) As Boolean
        If Not IsNumeric(str) Then str = str.ToLower
        Select Case str
            Case 0 : Return True
            Case 1 : Return True
            Case "f" : Return True
            Case "m" : Return True
        End Select

        Return False
    End Function

    Friend Function dbSex(ByVal str As String) As Integer
        If IsNumeric(str) Then Return str
        Select Case str
            Case "f" : Return 0
            Case "m" : Return 1
        End Select

        Return 0
    End Function

    Friend Function dbZip(ByVal str As String) As Integer
        If Not IsNumeric(str) Then Return Nothing
        If str = "" Then Return Nothing
        Return str
    End Function

    Friend Function ifPhone(ByVal str As String) As Boolean
        If Not IsNumeric(str) Then Return False

        '09257977559
        If str.Substring(0, 2) = "09" And str.Length = 11 Then Return True
        '+639257977559
        If str.Substring(0, 4) = "+639" And str.Length = 13 Then Return True
        '9257977559
        If str.Substring(0, 1) = "9" And str.Length = 10 Then Return True

        Return False
    End Function

    Friend Function ifItemType(ByVal str As String) As Boolean
        mySql = "SELECT * FROM tblClass WHERE Type = '" & str & "'"
        Dim ds As DataSet = LoadSQL(mySql)
        If ds.Tables(0).Rows.Count = 0 Then Return False
        Return True
    End Function

    Friend Sub ImportTemplate(ByVal url As String)
        Dim fillData As String = "tblPawn"
        Dim oXL As New Excel.Application
        If oXL Is Nothing Then MessageBox.Show("Excel is not properly installed!!") : Exit Sub

        Dim oWB As Excel.Workbook
        Dim oSheet As Excel.Worksheet
        Try
            oWB = oXL.Workbooks.Open(url)
            oSheet = oWB.Sheets(1)
            Dim MaxEntries As Integer
            With oSheet
                MaxEntries = oSheet.Cells(.Rows.Count, 1).End(Excel.XlDirection.xlUp).row
            End With

            Dim fname As String, lname As String
            For ent As Integer = 1 To MaxEntries - 1
                fname = oSheet.Cells(ent, 1).value
                lname = oSheet.Cells(ent, 2).value
                'Client
                Dim ds As DataSet = SearchClient(fname, lname)
                If ds.Tables("tblClient").Rows.Count = 0 Then
                    Dim migratePawner As New Client
                    With migratePawner
                        .FirstName = fname
                        .LastName = lname
                        .Suffix = oSheet.Cells(ent, 3).value
                        .AddressSt = oSheet.Cells(ent, 4).value
                        .AddressBrgy = oSheet.Cells(ent, 5).value
                        .AddressCity = oSheet.Cells(ent, 6).value
                        .AddressProvince = oSheet.Cells(ent, 7).value
                        .ZipCode = oSheet.Cells(ent, 8).value
                    End With
                End If
            Next

            oWB.Close()
            Console.WriteLine("Excel Closed")
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        End Try
        

        'Quit
        oSheet = Nothing
        oWB = Nothing
        oXL.Quit()
        oXL = Nothing

    End Sub

    Private Function SearchClient(ByVal fname As String, ByVal lname As String) As DataSet
        mySql = "SELECT * FROM tblClient "
        mySql &= String.Format("WHERE fname LIKE '%{0}%' AND lname LIKE '%{1}%'", fname, lname)

        Dim ds As DataSet = LoadSQL(mySql, "tblClient")
        Return ds
    End Function
End Module
