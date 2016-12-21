Imports System.IO


Public Class dev_FileLoader

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        Dim ptuFile As String
        Dim vText As String
        Dim vstring(-1) As String

        ofdPTU.ShowDialog()
        ptuFile = ofdPTU.FileName


        Using rvsr As New StreamReader(ptuFile)
            While rvsr.Peek <> -1
                vText = rvsr.ReadLine
                vstring = vText.Split({vbTab}, StringSplitOptions.RemoveEmptyEntries)

                Console.WriteLine(String.Format("Item: {0}| Description: {1}", vstring(0), vstring(1)))
            End While
        End Using

    End Sub
End Class