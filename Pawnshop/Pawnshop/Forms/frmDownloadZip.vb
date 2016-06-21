Imports System.Net
Imports System.IO
Imports Shell32
Imports System.Data.Odbc
Public Class frmDownloadZip
    Private Sub Downloader()
        Dim ZipLocation As String = My.Application.Info.DirectoryPath & "\honor.zip"
        Dim ZipUrl As String = "C:\Users\MIS JunMar\Downloads\try\honor.zip"
        'sample url "https:\\www.colorado.edu/conflict/peace/download/peace.zip"
        Dim webUri = New Uri(ZipUrl)
        Using client As New WebClient
            'ProgressBar1.Value = ProgressBar1.Minimum
            Try
                client.DownloadFile(webUri, ZipLocation)
                'ProgressBar1.Value = ProgressBar1.Maximum
                MessageBox.Show("Zip file Downloaded Successfully")
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            client.Dispose()
        End Using
    End Sub
    Private Sub DOSCommandExtract()
        Dim ZipLocation2 As String = " ""C:\Users\MIS JunMar\Downloads\try\honor.zip"" "
        Dim ZipExtracted2 As String = " ""C:\Users\MIS JunMar\Downloads\try\nirc"" "
        Dim Zlocation As String = "C:\Program Files\WinRAR\winrar.exe"
        Using p1 As New Process
            p1.StartInfo.FileName = Zlocation
            p1.StartInfo.Arguments = " x " & ZipLocation2 & " *.* " & ZipExtracted2
            Try
                p1.Start()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            'p1.WaitForExit()
        End Using
    End Sub
    'Private Sub Extractor()
    '    Dim ZipFile As String = My.Application.Info.DirectoryPath & "\honor.zip"
    '    Dim ZipLocation As String = My.Application.Info.DirectoryPath
    '    Dim Shell As Shell32.IShellDispatch
    '    Dim ShellFolder As Shell32.Folder

    '    If File.Exists(ZipFile) Then
    '        Shell = CType(CreateObject("Shell.Application"), IShellDispatch2)
    '        If Not Directory.Exists(ZipLocation) Then Directory.CreateDirectory(ZipLocation)
    '        ShellFolder = Shell.NameSpace(ZipLocation)
    '        If ShellFolder IsNot Nothing Then
    '            ShellFolder.CopyHere(Shell.NameSpace(ZipFile).Items)
    '        End If
    '        MessageBox.Show("Successfully Extracted")
    '    End If
    'End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        txtTime.Text = Date.Now.ToString("MMMM dd, yyyy hh:mm:ss")   
    End Sub
    Private Sub DownloadSave()
        Dim mysql As String = "SELECT * FROM ", filldata As String = "TBLDOWNLOADZIP"
        Dim ds As DataSet = LoadSQL(mysql & filldata, filldata)

        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(filldata).NewRow
        With dsNewRow
            .Item("TRANSDATE") = dtpSetDateDownload.Text
        End With
        ds.Tables(filldata).Rows.Add(dsNewRow)

        database.SaveEntry(ds)
        MsgBox("Save")
    End Sub
    'Private Sub CheckSetDate()
    '    dbOpen()
    '    Dim mysql As String = "SELECT * FROM TBLDOWNLOADZIP WHERE TRANSDATE "
    '    Dim cmd As OdbcCommand = New OdbcCommand(mysql, con)
    '    Using reader As OdbcDataReader = cmd.ExecuteReader()
    '        If reader.HasRows Then
    '        End If
    '        dbClose()
    '    End Using
    'End Sub
    Private Sub txtTime_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTime.TextChanged
        If txtTime.Text = dtpSetDateDownload.Text Then
            MessageBox.Show("Okey")
            'Downloader()
        End If
        If txtTime.Text = dtpDateExtract.Text Then
            'DOSCommandExtract()
            MsgBox("Okey Pud")
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        DOSCommandExtract()
    End Sub
End Class
