Imports System.IO

Public Class frmInventory
    Dim GrandTotal As Double = 0
    Dim ExistingSTO As Integer = 0

    Dim STONum As Integer = 0
    Dim WhsCode As String
    Dim STODate As Date
    Dim DocID As Integer = 0

    Dim STOFile As New DataSet

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub STOFile_Init()
        Dim dt As New DataTable
        dt.Columns.Add("ItemCode")
        dt.Columns.Add("Description")
        dt.Columns.Add("Category")
        dt.Columns.Add("UoM")
        dt.Columns.Add("Stocks")
        dt.Columns.Add("Price")
        dt.Columns.Add("STO")

        STOFile.Clear()
        STOFile.Tables.Add(dt)
    End Sub

    Private Sub AddToDataset(ByVal lvItem As ListViewItem)
        Dim dsNewRow As DataRow
        dsNewRow = STOFile.Tables(0).NewRow
        With dsNewRow
            .Item("ITEMCODE") = lvItem.Text
            .Item("DESCRIPTION") = lvItem.SubItems(1).Text
            .Item("CATEGORY") = lvItem.SubItems(2).Text
            .Item("UOM") = lvItem.SubItems(3).Text
            .Item("STOCKS") = lvItem.SubItems(4).Text
            .Item("PRICE") = lvItem.SubItems(5).Text
            .Item("STO") = CInt(lvItem.SubItems(6).Text)
        End With
        STOFile.Tables(0).Rows.Add(dsNewRow)
    End Sub

    Private Function isSTOExisting(ByVal stono As Integer) As Boolean
        Dim mySql As String = "SELECT * FROM INV WHERE DOCNUM = " & stono
        Dim ds As DataSet = LoadSQL(mySql)

        If ds.Tables(0).Rows.Count >= 1 Then
            ExistingSTO = stono
            Return True
        End If

        Return False
    End Function

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Dim ptuFile As String
        Dim vText As String, vstring(-1) As String
        Dim idx As Integer = 1, tmpDocID As Integer = 0

        ofdInv.ShowDialog()
        ptuFile = ofdInv.FileName
        If ptuFile = "" Then
            Exit Sub
        End If

        ClearFields()
        STOFile_Init()

        ' LOADING PTU FILE
        Using rvsr As New StreamReader(ptuFile)
            While rvsr.Peek <> -1
                vText = rvsr.ReadLine
                vstring = vText.Split({vbTab}, StringSplitOptions.RemoveEmptyEntries)
                If vstring.Count <> 6 Then
                    GoTo FAILED_VER
                End If

                If idx > 1 Then
                    'EXCLUDE HEADERS
                    Dim invItem As New cItem(cItem.DocumentType.GoodsReceipt)
                    With invItem
                        .ItemCode = vstring(0)
                        .Description = vstring(1)
                        .Qty = vstring(2)
                        .Remarks = String.Format("STO# {0:000000}", CInt(vstring(4)))
                        .Load_ItemCode()
                    End With

                    'Document Verification
                    'Only the WhsCode and the Date are being extracted
                    If WhsCode = "" Then
                        WhsCode = vstring(3)
                    Else
                        If WhsCode <> vstring(3) Then
                            'Possible Tampering
                            GoTo FAILED_VER
                        End If
                    End If

                    If STODate = Nothing Then
                        STODate = DateTime.Parse(vstring(5)).ToString("MM/dd/yyyy")
                    Else
                        If STODate.ToString("MM/dd/yyyy") <> DateTime.Parse(vstring(5)).ToString("MM/dd/yyyy") Then
                            GoTo FAILED_VER
                        End If
                    End If

                    If Not IsNumeric(vstring(4)) Then
                        GoTo FAILED_VER
                    End If

                    If Not invItem.hasLoaded Then
                        MsgBox(String.Format("ItemCode {0} is not found in the Master Data", invItem.ItemCode), MsgBoxStyle.Critical)
                        GoTo FAILED_VER
                    End If

                    If lblWHS.Text <> "" Then
                        lblWHS.Text = WhsCode
                        lblSTODate.Text = STODate
                    End If

                    If Not isSTOExisting(vstring(4)) Then
                        tmpDocID += 1

                        STONum = vstring(4)
                        invItem.DocID = STONum
                        AddItem(invItem, STONum)
                    End If
                End If

                idx += 1
            End While
        End Using

        ' Displaying Other information
        lblWHS.Text = WhsCode
        lblSTODate.Text = STODate
        lblFilename.Text = ofdInv.FileName

        Dim sortedRows As DataRow()
        sortedRows = STOFile.Tables(0).Select("", "STO ASC")

        For Each dr As DataRow In sortedRows
            Console.WriteLine(dr.Item("ITEMCODE") & " - " & dr.Item("STO"))
        Next

        Exit Sub
FAILED_VER:
        MsgBox("UNABLE TO LOAD STO FILE", MsgBoxStyle.Critical)
        ' TODO: JUNMAR
        ' Include LOG for possible tampering
    End Sub

    Private Sub AddItem(ByVal itm As cItem, ByVal STO As Integer)
        itm.Load_ItemCode()

        Dim lv As ListViewItem = lvInventory.Items.Add(itm.ItemCode)
        lv.SubItems.Add(itm.Description)
        lv.SubItems.Add(itm.Category)
        lv.SubItems.Add(itm.UnitofMeasure)
        lv.SubItems.Add(itm.Qty)
        lv.SubItems.Add(itm.SalePrice.ToString("#,#0.00"))
        lv.SubItems.Add(STO.ToString("00000000"))

        AddToDataset(lv)
    End Sub

    Private Sub Label3_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label3.DoubleClick
        SeedItemData.Populate2()
        Console.WriteLine("Populated")
    End Sub

    Private Sub frmInventory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearFields()
    End Sub

    Private Sub ClearFields()
        lblFilename.Text = "No file yet"
        lblWHS.Text = ""
        lblSTODate.Text = ""

        lvInventory.Items.Clear()
        STOFile.Clear()
    End Sub

    Private Sub btnAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccept.Click
        If Not lvInventory.Items.Count > 0 Then
            MsgBox("Nothing to accept" + vbCr + "Data already been uploaded", MsgBoxStyle.Information)
            Exit Sub
        End If

        Dim STONum As Integer = 0, DocID As Integer = 0
        Dim mySql As String
        Dim ds As DataSet
        Dim dsNewRow As DataRow

        Dim SortedDS As DataRow()
        SortedDS = STOFile.Tables(0).Select("", "STO ASC")

        For Each dr As DataRow In SortedDS

            ' Add Document
            If STONum <> dr.Item("STO") Then
                mySql = "SELECT * FROM INV ROWS 1"

                ds = LoadSQL(mySql, "INV")
                STONum = dr.Item("STO")

                dsNewRow = ds.Tables(0).NewRow
                With dsNewRow
                    .Item("DOCNUM") = STONum
                    .Item("DOCDATE") = STODate
                    .Item("PARTNER") = "HEAD OFFICE"
                    .Item("REFNUM") = STONum
                End With
                ds.Tables("INV").Rows.Add(dsNewRow)
                database.SaveEntry(ds)

                mySql = "SELECT * FROM INV ORDER BY DOCID DESC ROWS 1"
                ds = LoadSQL(mySql)
                DocID = ds.Tables(0).Rows(0).Item("DOCID")
            End If

            ' Add Document Lines
            mySql = "SELECT * FROM INVLINES ROWS 1"
            ds = LoadSQL(mySql, "INVLINES")
            dsNewRow = ds.Tables(0).NewRow
            With dsNewRow
                .Item("DOCID") = DocID
                .Item("ITEMCODE") = dr("ITEMCODE")
                .Item("DESCRIPTION") = dr("DESCRIPTION")
                .Item("QTY") = dr("STOCKS")
                .Item("UOM") = dr("UOM")
                .Item("REMARKS") = "UPLOADED DATED " & CurrentDate
            End With
            ds.Tables("INVLINES").Rows.Add(dsNewRow)
            database.SaveEntry(ds)
        Next

        MsgBox("STO File imported", MsgBoxStyle.Information)
        ClearFields()
    End Sub

End Class