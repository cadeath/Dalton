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

    Private Sub AddToSTO(ByVal inv As cItemData)

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

        ClearFields()
        STOFile_Init()

        ' LOADING PTU FILE
        Using rvsr As New StreamReader(ptuFile)
            While rvsr.Peek <> -1
                vText = rvsr.ReadLine
                vstring = vText.Split({vbTab}, StringSplitOptions.RemoveEmptyEntries)

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
    End Sub

    Private Sub Label3_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label3.DoubleClick
        SeedItemData.Populate2()
    End Sub

    Private Sub frmInventory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearFields()
    End Sub

    Private Sub ClearFields()
        lblFilename.Text = ""
        lblWHS.Text = ""
        lblSTODate.Text = ""

        lvInventory.Items.Clear()
    End Sub

    Private Sub btnAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccept.Click
        Create_Document()
    End Sub

    Private Sub Create_Document()
        Dim STONum As Integer = 0
        Dim mySql As String
        Dim ds As DataSet
        Dim dsNewRow As DataRow

        'For Each ht_ent As DictionaryEntry In ht_inv
        '    Dim invItem As cItem
        '    invItem = ht_ent.Value

        '    If STONum <> invItem.DocID Then
        '        STONum = invItem.DocID

        '        mySql = "SELECT * FROM INV WHERE DOCNUM = " & STONum
        '        ds = LoadSQL(mySql, "INV")

        '        dsNewRow = ds.Tables("INV").NewRow
        '        With dsNewRow
        '            .Item("DOCNUM") = STONum
        '            .Item("DOCDATE") = STODate
        '            .Item("PARTNER") = "Possible Head Office"
        '            .Item("REMARKS") = String.Format("Imported {0}", STODate.ToString("MMM/dd/yyyy"))
        '            .Item("REFNUM") = STONum
        '        End With
        '        ds.Tables("INV").Rows.Add(dsNewRow)
        '        database.SaveEntry(ds)

        '        mySql = "SELECT * FROM INV ORDER BY DOCID DESC ROWS 1"
        '        ds = LoadSQL(mySql)

        '        DocID = ds.Tables("INV").Rows(0).Item("DOCID")

        '    End If
        'Next

    End Sub
End Class