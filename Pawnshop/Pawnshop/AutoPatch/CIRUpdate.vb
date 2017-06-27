Imports System.Data.Odbc
Imports System.IO


Module CIRUpdate

    Private cirStr As String = "CIR files"
    Private path As String = Application.StartupPath & "\" & cirStr

    Dim lastIndex As String = ""

    Public Function AutoReadCIR() As Boolean
        If Not System.IO.Directory.Exists(path) Then Return False

        Dim counter = My.Computer.FileSystem.GetFiles(path)
        If CStr(counter.Count) = 0 Then Return False

        frmMain.Cursor = Cursors.WaitCursor

        For Each pth In Directory.GetFiles(path)
            If Not pth.Contains(".cir") Then Continue For
            Console.WriteLine(pth)

            updateRate.do_RateUpdate(pth)


              My.Computer.FileSystem.DeleteFile(pth)
        Next
        frmMainV2.Cursor = Cursors.Default

        Return True
    End Function

End Module
