Imports System.IO

Public Class frmInventory
    Dim ht_inv As New Hashtable

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Dim ptuFile As String
        Dim vText As String, vstring(-1) As String
        Dim idx As Integer = 1

        Dim WhsCode As String, STODate As Date

        ofdInv.ShowDialog()
        ptuFile = ofdInv.FileName


        ' LOADING PTU FILE
        Using rvsr As New StreamReader(ptuFile)
            While rvsr.Peek <> -1
                vText = rvsr.ReadLine
                vstring = vText.Split({vbTab}, StringSplitOptions.RemoveEmptyEntries)

                If idx > 1 Then
                    'EXCLUDE HEADERS
                    Dim invItem As New cItem(cItem.DocumentType.GoodsReceipt)
                    With invItem
                        .DocID = 1
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

                    AddItem(invItem, vstring(4))
                    ht_inv.Add(idx, invItem)
                End If

                idx += 1
            End While
        End Using

        For Each ht As DictionaryEntry In ht_inv
            Dim tmp As cItem = ht.Value
            Console.WriteLine(String.Format("{0}: {1}", ht.Key, tmp.ItemCode))
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
    End Sub

    Private Sub Label3_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label3.DoubleClick
        SeedItemData.Populate2()
    End Sub
End Class