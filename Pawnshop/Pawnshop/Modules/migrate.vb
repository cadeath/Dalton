Imports Microsoft.Office.Interop

Module migrate
    Private mySql As String = String.Empty

    Private Function ifSex(ByVal str As String) As Boolean
        If Not IsNumeric(str) Then str = str.ToLower
        Select Case str
            Case 0 : Return True
            Case 1 : Return True
            Case "f" : Return True
            Case "m" : Return True
        End Select

        Return False
    End Function

    Private Function dbSex(ByVal str As String) As Integer
        If IsNumeric(str) Then Return str
        Select Case str
            Case "f" : Return 0
            Case "m" : Return 1
        End Select

        Return 0
    End Function

    Private Function ifPhone(ByVal str As String) As Boolean
        If Not IsNumeric(str) Then Return False

        '09257977559
        If str.Substring(0, 2) = "09" And str.Length = 11 Then Return True
        '+639257977559
        If str.Substring(0, 4) = "+639" And str.Length = 13 Then Return True
        '9257977559
        If str.Substring(0, 1) = "9" And str.Length = 10 Then Return True

        Return False
    End Function

    Private Function ifItemType(ByVal str As String) As Boolean
        mySql = "SELECT * FROM tblClass WHERE Type = '" & str & "'"
        Dim ds As DataSet = LoadSQL(mySql)
        If ds.Tables(0).Rows.Count = 0 Then Return False
        Return True
    End Function

    Private _catID As Integer
    Private Function isClass(ByVal desc As String) As Boolean
        mySql = "SELECT * FROM tblClass WHERE Category = '" & desc & "'"
        Dim ds As DataSet = LoadSQL(mySql)
        If ds.Tables(0).Rows.Count = 0 Then Return False

        _catID = ds.Tables(0).Rows(0).Item("ClassID")
        Return True
    End Function

    Private Function ifStatus(ByVal str As String) As Boolean
        On Error Resume Next

        Select Case str.ToUpper
            Case "A" : Return True
            Case "T" : Return True
        End Select

        Return False
    End Function

    Friend Sub ImportTemplate(ByVal url As String)
        Dim fillData As String = "tblPawn", importCnt As Int64 = 0
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

            Dim fname As String, lname As String, pt As String
            For ent As Integer = 2 To MaxEntries - 1
                pt = "Line Num: " & ent - 1
                Dim colIdx As Integer = 0 : colIdx += 1
                Try
                    'Create Client
                    fname = oSheet.Cells(ent, 1).value : colIdx += 1
                    lname = oSheet.Cells(ent, 2).value : colIdx += 1
                    Dim ds As DataSet = SearchClient(fname, lname)
                    Dim migratePawner As New Client, isNew As Boolean = True
                    If ds.Tables(0).Rows.Count > 0 Then
                        migratePawner.LoadClientByRow(ds.Tables(0).Rows(0))
                        isNew = False
                    End If
                    With migratePawner
                        .FirstName = fname
                        .LastName = lname
                        .Suffix = oSheet.Cells(ent, 3).value : colIdx += 1
                        .AddressSt = IIf(oSheet.Cells(ent, 4).value = "", "", oSheet.Cells(ent, 4).value) : colIdx += 1
                        .AddressBrgy = IIf(oSheet.Cells(ent, 5).value = "", "", oSheet.Cells(ent, 5).value) : colIdx += 1
                        .AddressCity = IIf(oSheet.Cells(ent, 6).value = "", "", oSheet.Cells(ent, 6).value) : colIdx += 1
                        .AddressProvince = IIf(oSheet.Cells(ent, 7).value = "", "", oSheet.Cells(ent, 7).value) : colIdx += 1
                        .ZipCode = IIf(oSheet.Cells(ent, 8).value = "", "", oSheet.Cells(ent, 8).value) : colIdx += 1
                        If ifSex(oSheet.Cells(ent, 9).value) Then .Sex = dbSex(oSheet.Cells(ent, 9).value) : colIdx += 1
                        If IsDate(oSheet.Cells(ent, 10).value) Then .Birthday = oSheet.Cells(ent, 10).value : colIdx += 1
                        If ifPhone(oSheet.Cells(ent, 11).value) Then .Cellphone1 = oSheet.Cells(ent, 11).value : colIdx += 1
                        If ifPhone(oSheet.Cells(ent, 12).value) Then .Cellphone1 = oSheet.Cells(ent, 12).value : colIdx += 1

                        If isNew Then
                            .SaveClient()
                        Else
                            .ModifyClient()
                        End If
                    End With


                    'Add PawnItem
                    If Not isDuplication(oSheet.Cells(ent, 13).value) Then
                        Dim migratePT As New PawnTicket
                        With migratePT
                            migratePT.Pawner = migratePawner
                            pt = oSheet.Cells(ent, 13).value : colIdx += 1
                            If IsNumeric(pt) Then
                                .PawnTicket = pt
                            Else
                                GoTo nextLoop
                            End If
                            If ifItemType(oSheet.Cells(ent, 14).value) Then
                                .ItemType = oSheet.Cells(ent, 14).value : colIdx += 1
                            Else
                                GoTo nextLoop
                            End If
                            If isClass(oSheet.Cells(ent, 15).value) Then
                                .CategoryID = _catID : colIdx += 1
                            Else
                                GoTo nextLoop
                            End If
                            If IsNumeric(oSheet.Cells(ent, 16).value) Then
                                .Grams = oSheet.Cells(ent, 16).value : colIdx += 1
                            Else
                                GoTo nextLoop
                            End If
                            If IsNumeric(oSheet.Cells(ent, 17).value) Then
                                .Karat = oSheet.Cells(ent, 17).value : colIdx += 1
                            Else
                                GoTo nextLoop
                            End If
                            .Description = oSheet.Cells(ent, 18).value : colIdx += 1
                            .LoanDate = oSheet.Cells(ent, 19).value : colIdx += 1
                            .MaturityDate = oSheet.Cells(ent, 20).value : colIdx += 1
                            .ExpiryDate = oSheet.Cells(ent, 21).value : colIdx += 1
                            .AuctionDate = oSheet.Cells(ent, 22).value : colIdx += 1
                            .Appraisal = oSheet.Cells(ent, 23).value : colIdx += 1
                            .Principal = oSheet.Cells(ent, 24).value : colIdx += 1
                            .Interest = oSheet.Cells(ent, 25).value : colIdx += 1
                            .ServiceCharge = oSheet.Cells(ent, 26).value : colIdx += 1
                            .NetAmount = oSheet.Cells(ent, 27).value : colIdx += 1
                            Dim oldPT As String = oSheet.Cells(ent, 28).value : colIdx += 1
                            If oldPT = "null" Then oldPT = ""
                            If IsNumeric(oldPT) Then .OldTicket = oldPT
                            .Status = oSheet.Cells(ent, 29).value : colIdx += 1

                            .SaveTicket()
                        End With
                        Console.WriteLine("PT# " & pt & " saved.")
                    End If
                Catch ex As Exception
                    Console.WriteLine("Error in PT# " & pt)
                    Console.WriteLine("Line Number : " & ent)
                    Console.WriteLine("Column Number : " & colIdx + 1)
                    Console.WriteLine(ex.ToString)
                    LogReport(ent, "Please check column number " & colIdx + 1)
                    GoTo nextLoop
                End Try
                importCnt += 1
nextLoop:
            Next

            oWB.Close()
            Console.WriteLine("Excel Closed")
        Catch ex As Exception
            'Quit
            oSheet = Nothing
            oWB = Nothing
            oXL.Quit()
            oXL = Nothing
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
            Exit Sub
        End Try
        

        'Quit
        oSheet = Nothing
        oWB = Nothing
        oXL.Quit()
        oXL = Nothing

        MsgBox("Data imported " & importCnt, MsgBoxStyle.Information, "Done")
    End Sub

    Private Sub LogReport(ByVal ln As Integer, ByVal desc As String)
        frmMIS.AddReport(ln, desc)
    End Sub

    Private Function SearchClient(ByVal fname As String, ByVal lname As String) As DataSet
        mySql = "SELECT * FROM tblClient "
        mySql &= String.Format("WHERE FirstName LIKE '%{0}%' AND LastName LIKE '%{1}%'", fname, lname)

        Dim ds As DataSet = LoadSQL(mySql, "tblClient")
        Return ds
    End Function

    Private Function isDuplication(ByVal pt As Int64) As Boolean
        mySql = "SELECT * FROM tblPawn "
        mySql &= "WHERE PawnTicket = " & pt
        Dim ds As DataSet = LoadSQL(mySql)
        If ds.Tables(0).Rows.Count = 0 Then Return False

        Return True
    End Function
End Module
