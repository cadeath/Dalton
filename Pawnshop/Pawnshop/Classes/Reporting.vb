' Eskie Cirrus James Maquilang
' revised 2
' - add delay in generating name
' revised 1
' - add random filename
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
    Private Fname As String

    Public Function CreateStream(ByVal name As String, _
       ByVal fileNameExtension As String, _
       ByVal encoding As Encoding, ByVal mimeType As String, _
       ByVal willSeek As Boolean) As Stream

        Dim tmpPath As String = System.IO.Path.GetTempPath()
        'Dim tmpFile As String = name + "." + fileNameExtension
        Dim tmpFile As String = GetRandomString(5) + "." + fileNameExtension

        Fname = tmpPath & tmpFile
        Console.WriteLine("Generating: " & Fname)

        Dim stream As Stream = _
            New FileStream(Fname, FileMode.Create)
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
        Console.WriteLine("Device Info:")
        Console.WriteLine(deviceInfo)

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

    Private Function GetRandomString(ByVal max As Integer) As String
        Dim s As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
        Dim r As New Random
        Dim sb As New StringBuilder
        For i As Integer = 1 To 8
            Dim idx As Integer = r.Next(0, 35)
            sb.Append(s.Substring(idx, 1))
        Next

        'Delay for next random value
        Threading.Thread.Sleep(1000)
        Return sb.ToString
    End Function

End Class