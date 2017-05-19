Imports System
Imports System.IO
Imports System.Collections
Public Class dir1
    Public Overloads Shared Sub Main(ByVal args() As String)
        Dim path As String
        For Each path In args
            If File.Exists(path) Then

                ProcessFile(path)
            Else
                If Directory.Exists(path) Then

                    ProcessDirectory(path)
                Else
                    Console.WriteLine("{0} is not a valid file or directory.", path)
                End If
            End If
        Next path
    End Sub


    Public Shared Sub ProcessDirectory(ByVal targetDirectory As String)
        If targetDirectory = "" Then Exit Sub
        Dim fileEntries As String() = Directory.GetFiles(targetDirectory)
        Dim fileName As String


        For Each fileName In fileEntries
            ProcessFile(fileName)

        Next fileName
        Dim subdirectoryEntries As String() = Directory.GetDirectories(targetDirectory)
        Dim subdirectory As String

        For Each subdirectory In subdirectoryEntries
            ProcessDirectory(subdirectory)
        Next subdirectory

    End Sub

    Public Shared Sub ProcessFile(ByVal path As String)
        If path.Contains(".FDB") = True Then
            Dim lv As ListViewItem = frmGetDumperClient.lvDatabaselist.Items.Add(path)
            Console.WriteLine("Processed file '{0}'.", path)
        Else
            On Error Resume Next
        End If
    End Sub

End Class '
