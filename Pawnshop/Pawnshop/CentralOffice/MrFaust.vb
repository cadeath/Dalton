Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Timers
Imports System.Threading


Module MrFaust

    Const PING_URI As String = "ping"

    Const DELAY_MIN_MINUTES As Integer = 1
    Const DELAY_MAX_MINUTES As Integer = 5

    Friend Sub CheckList()
        Dim th_ping As New Thread(AddressOf do_ping)
        th_ping.Start()
    End Sub

    Private Sub CommandParsing(ByVal cmd As String)
        Select Case cmd
            Case "OK"
                Exit Sub
        End Select
    End Sub

#Region "PING"
    Dim ping_delay As Timers.Timer
    Dim delay As Integer

    Private Sub start_ping()
        delay = GetRand(DELAY_MIN_MINUTES, DELAY_MAX_MINUTES)
        delay = delay * 60 * 1000

        Console.WriteLine("Ping wait: " & delay / 1000 / 60)
        ping_delay = New Timers.Timer
        ping_delay.Interval = delay
        AddHandler ping_delay.Elapsed, New ElapsedEventHandler(AddressOf ping_now)
        ping_delay.Enabled = True
    End Sub

    Private Sub ping_now(ByVal obj As Object, ByVal e As EventArgs)
        Dim th As New Thread(AddressOf do_ping)
        th.Start()
    End Sub

    Private Sub do_ping()
        If Not ping_delay Is Nothing Then ping_delay.Enabled = False
        CommandParsing(Ping)
        start_ping()
    End Sub

    Private Function Ping() As String
        Dim data As Byte() = Encoding.UTF8.GetBytes("code=" & BranchCode)

        Dim respond As String = SendRequest(mysql_database.HTTP_SERVER(PING_URI), data, "application/x-www-form-urlencoded", "POST")

        Console.WriteLine("Respond: " & respond)
        Return respond
    End Function
#End Region
    Private Function GetRand(ByVal min As Integer, ByVal max As Integer) As Integer
        Dim randomInt As Integer
        Dim myRand As New Random
        randomInt = myRand.Next(min, max)
        Return randomInt
    End Function

    Private Function SendRequest(ByVal uri As String, ByVal jsonDataBytes As Byte(), ByVal contentType As String, ByVal method As String) As String
        Dim req As WebRequest = WebRequest.Create(uri)
        req.ContentType = contentType
        req.Method = method
        req.ContentLength = jsonDataBytes.Length


        Dim stream = req.GetRequestStream()
        stream.Write(jsonDataBytes, 0, jsonDataBytes.Length)
        stream.Close()

        Dim response = req.GetResponse().GetResponseStream()

        Dim reader As New StreamReader(response)
        Dim res = reader.ReadToEnd()
        reader.Close()
        response.Close()

        Return res
    End Function
End Module
