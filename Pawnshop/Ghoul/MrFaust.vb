Imports System.Text
Imports System.Timers
Imports System.Threading

Module MrFaust

    Const PING_URI As String = "ping"

    Const DELAY_MIN_MINUTES As Integer = 10
    Const DELAY_MAX_MINUTES As Integer = 30

    Friend Sub CheckList()
        Dim th_ping As New Thread(AddressOf do_ping)
        th_ping.Start()

        While True
            System.Threading.Thread.Sleep(3000)
        End While
    End Sub

    Private Sub CommandParsing(ByVal cmd As String)
        If cmd = "OK" Then Exit Sub
        If cmd = "CLOSE" Then Console.WriteLine("Connection closed...")
        If Not cmd.Contains(":") Then Exit Sub

        Dim Code As String = cmd.Split(":")(0)
        Select Case Code
            Case "CCDATE" 'CashCount Date
                cmdFunctions.do_ccSave(cmd.Split(":")(1))
        End Select
    End Sub

#Region "PING"
    Dim ping_delay As Timers.Timer
    Dim delay As Integer

    Private Sub start_ping()
        delay = GetRand(DELAY_MIN_MINUTES, DELAY_MAX_MINUTES)
        delay = delay * 1000 '* 60 'for the Minutes

        Console.WriteLine("Ping wait: " & delay / 1000 & "s")
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

End Module
