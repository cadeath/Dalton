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
                    End With

                    ht_inv.Add(idx, invItem)
                End If

                idx += 1
            End While
        End Using

        Console.WriteLine("awts")
        For Each ht As DictionaryEntry In ht_inv
            Dim tmp As cItem = ht.Value
            Console.WriteLine(String.Format("{0}: {1}", ht.Key, tmp.ItemCode))
        Next
    End Sub

    Private Sub frmInventory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub AddItem(ByVal inv As cItem)
        Dim lv As ListViewItem = lvInventory.Items.Add(inv.ItemCode)
        lv.SubItems.Add(inv.Description)
        lv.SubItems.Add(inv.Category)
    End Sub
End Class