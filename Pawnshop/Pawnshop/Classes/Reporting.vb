' Eskie Cirrus James Maquilang
' revised
Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.Collections.Generic
Imports Microsoft.Reporting.WinForms

Public Class Reporting

    Implements IDisposable

    Public m_currentPageIndex As Integer
    Public m_streams As IList(Of Stream)

    Public Function CreateStream(ByVal name As String, _
       ByVal fileNameExtension As String, _
       ByVal encoding As Encoding, ByVal mimeType As String, _
       ByVal willSeek As Boolean) As Stream
        On Error Resume Next

        Dim tmpPath As String = System.IO.Path.GetTempPath()
        Dim tmpFile As String = name + "." + fileNameExtension

        If System.IO.File.Exists(tmpPath & tmpFile) Then System.IO.File.Delete(tmpPath & tmpFile)
        While System.IO.File.Exists(tmpPath & tmpFile)
            System.IO.File.Delete(tmpPath & tmpFile)
            Console.WriteLine("Please wait... Deleting...")
        End While
        Dim stream As Stream = _
            New FileStream(tmpPath & tmpFile, FileMode.Create)
        'New FileStream("C:\" + name + "." + fileNameExtension, FileMode.Create)

        m_streams.Add(stream)
        Return stream
    End Function

    Public Sub Export(ByVal report As LocalReport, Optional ByVal size As Dictionary(Of String, Double) = Nothing)
        Dim deviceInfo As String = _
          "<DeviceInfo>" + _
          "  <OutputFormat>EMF</OutputFormat>" + _
          "  <PageWidth>8.5in</PageWidth>" + _
          "  <PageHeight>11in</PageHeight>" + _
          "  <MarginTop>0.25in</MarginTop>" + _
          "  <MarginLeft>0.25in</MarginLeft>" + _
          "  <MarginRight>0.25in</MarginRight>" + _
          "  <MarginBottom>0.25in</MarginBottom>" + _
          "</DeviceInfo>"

        If Not size Is Nothing Then
            Console.WriteLine("Resizing Paper....")

            Dim paperWidth_in As String = size("width").ToString("0.00")
            Dim paperHeight_in As String = size("height").ToString("0.00")

            Console.WriteLine("Width: " & paperWidth_in)
            Console.WriteLine("Height: " & paperHeight_in)

            deviceInfo = _
          "<DeviceInfo>" + _
          "  <OutputFormat>EMF</OutputFormat>" + _
          "  <PageWidth>" + paperWidth_in + "in</PageWidth>" + _
          "  <PageHeight>" + paperHeight_in + "in</PageHeight>" + _
          "  <MarginTop>0.25in</MarginTop>" + _
          "  <MarginLeft>0.25in</MarginLeft>" + _
          "  <MarginRight>0.25in</MarginRight>" + _
          "  <MarginBottom>0.25in</MarginBottom>" + _
          "</DeviceInfo>"
        End If

        Dim warnings() As Warning = Nothing
        m_streams = New List(Of Stream)()
        report.Render("Image", deviceInfo, AddressOf CreateStream, warnings)
        Console.WriteLine(report.GetDefaultPageSettings.PaperSize)
        Console.WriteLine(report.GetDefaultPageSettings.Margins)

        Dim stream As Stream
        For Each stream In m_streams
            stream.Position = 0
        Next
    End Sub

    Public Sub PrintPage(ByVal sender As Object, ByVal ev As PrintPageEventArgs)

        Dim pageImage As New Metafile(m_streams(m_currentPageIndex))

        ev.Graphics.DrawImage(pageImage, ev.PageBounds)
        m_currentPageIndex += 1
        ev.HasMorePages = (m_currentPageIndex < m_streams.Count)
        Console.WriteLine("Num of Pages: " & m_streams.Count)

    End Sub

    Public Sub Print(Optional ByVal printerName As String = Nothing)

        'Const printerName As String = "Microsoft Office Document Image Writer"

        If m_streams Is Nothing OrElse m_streams.Count = 0 Then
            Return
        End If

        Dim printDoc As New PrintDocument()

        If Not printerName Is Nothing Then printDoc.PrinterSettings.PrinterName = printerName

        If Not printDoc.PrinterSettings.IsValid Then
            Dim msg As String = String.Format( _
                "Can't find printer ""{0}"".", printerName)
            Console.WriteLine(msg)
            Return
        End If

        AddHandler printDoc.PrintPage, AddressOf PrintPage
        printDoc.PrinterSettings.Duplex = Duplex.Horizontal
        printDoc.Print()

    End Sub

    Public Overloads Sub Dispose() Implements IDisposable.Dispose

        If Not (m_streams Is Nothing) Then
            Dim stream As Stream
            For Each stream In m_streams
                stream.Close()
            Next
            m_streams = Nothing
        End If

    End Sub

End Class