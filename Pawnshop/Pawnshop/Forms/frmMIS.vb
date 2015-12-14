﻿Imports Microsoft.Office.Interop

Public Class frmMIS

    Private Sub frmMIS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearFields()
        btnImport.Focus()
    End Sub

    Private Sub ClearFields()
        txtImportPath.Text = "D:\cadeath\Documents\RPS\sampleImport.xlsx"
    End Sub

    Private Sub CreateLOG()
        If lvImportResult.Items.Count <= 0 Then Exit Sub

        Dim fileName As String = "importLog-" & Now.ToString("yyyyMMdd-mm") & ".txt"
        Dim url As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\" & fileName
        If System.IO.File.Exists(url) Then System.IO.File.Delete(url)
        System.IO.File.Create(url).Dispose()

        Dim objWriter As New System.IO.StreamWriter(url, True)
        objWriter.WriteLine("Extracting " & txtImportPath.Text)
        For Each lv As ListViewItem In lvImportResult.Items
            objWriter.WriteLine("Ln " & lv.Text & " - " & lv.SubItems(1).Text)
        Next

        objWriter.Close()
    End Sub

    Friend Sub AddReport(ByVal ln As Integer, ByVal desc As String)
        Dim lv As ListViewItem = lvImportResult.Items.Add(ln)
        lv.SubItems.Add(desc)
    End Sub

    Private Sub ofdImport_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ofdImport.FileOk
        txtImportPath.Text = ofdImport.FileName
    End Sub

    Private Sub btnImportBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportBrowse.Click
        ofdImport.ShowDialog()
    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        ImportTemplate(txtImportPath.Text)
        CreateLOG()
    End Sub

    Friend Sub AddProgress()
        Dim th As Threading.Thread
        th = New Threading.Thread(AddressOf doAddProgress)
        th.Start()
    End Sub

    Private Delegate Sub doAddProgress_delegate()
    Private Sub doAddProgress()
        If pbData.InvokeRequired Then
            Dim d As New doAddProgress_delegate(AddressOf doAddProgress)
            pbData.Invoke(d)
        Else
            pbData.Value += 1
        End If
    End Sub

    Friend Sub fileLoading(ByVal max As Integer)
        If max = 0 Then
            pbData.Visible = False
            Me.Enabled = True
        Else
            pbData.Value = 0
            pbData.Maximum = max
            pbData.Visible = True
            Me.Enabled = False
        End If
    End Sub

#Region "Migrate"
    Friend Sub ImportTemplate(ByVal url As String)
        Dim fillData As String = "tblPawn", importCnt As Int64 = 0
        Dim oXL As New Excel.Application
        If oXL Is Nothing Then MessageBox.Show("Excel is not properly installed!!") : Exit Sub

        Dim MaxEntries As Integer
        Dim oWB As Excel.Workbook
        Dim oSheet As Excel.Worksheet
        Try
            oWB = oXL.Workbooks.Open(url)
            oSheet = oWB.Sheets(1)
            With oSheet
                MaxEntries = oSheet.Cells(.Rows.Count, 1).End(Excel.XlDirection.xlUp).row
            End With

            Dim fname As String, lname As String, pt As String
            fileLoading(MaxEntries)

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
                        .LoadLastEntry()
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
                            .Status = "L"

                            .SaveTicket()
                        End With
                        Console.WriteLine("PT# " & pt & " saved.")
                        importCnt += 1
                    Else
                        LogReport(ent, "Duplicate PT# at column " & colIdx)
                    End If
                Catch ex As Exception
                    Console.WriteLine("Error in PT# " & pt)
                    Console.WriteLine("Line Number : " & ent)
                    Console.WriteLine("Column Number : " & colIdx + 1)
                    Console.WriteLine(ex.ToString)
                    LogReport(ent, "Please check column number " & colIdx)
                    GoTo nextLoop
                End Try
nextLoop:
                doAddProgress()
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

            fileLoading(0)
            Exit Sub
        End Try


        'Quit
        oSheet = Nothing
        oWB = Nothing
        oXL.Quit()
        oXL = Nothing

        MsgBox("Data imported " & importCnt, MsgBoxStyle.Information, "Done")
        fileLoading(0)
    End Sub

    Private Sub LogReport(ByVal ln As Integer, ByVal desc As String)
        AddReport(ln, desc)
    End Sub
#End Region

End Class