Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Threading
Imports System.Net.Sockets

Module Ghoul

    Const BUFFER_SIZE As Integer = 1024
    Const RECONNECT_MIN As Integer = 60 * 10
    Const RECONNECT_MAX As Integer = 60 * 30
    Const LOCK_FILE As String = "tOlYLguYQMM="

    Dim Ghoul As New TcpClient
    Dim MrFaustHome As String = "192.164.0.126"
    Dim MrFaustEntrance As Integer = 2236

    Dim CurrentCmd As String = ""
    Dim SEND_INFO As String = String.Format(">INIT:{0}|{1}", BranchCode, branchName)

    Dim rc_timer As New System.Timers.Timer

#Region "ERRORS"
    Const NO_CONNECTION As String = "No connection could be made because the target machine"
    Const DISPOSED_ISSUE As String = "Cannot access a disposed object"
    Const CONNECT_ATTEMPT As String = "A connection attempt failed because the connected party did not properly respond"
#End Region

    Sub GhoulConnect()

        Try
            ' if Existing, don't connect
            If System.IO.File.Exists(DecryptString(LOCK_FILE)) Then
                Dim line As String
                Using reader As StreamReader = New StreamReader(DecryptString(LOCK_FILE))
                    line = reader.ReadLine
                End Using

                If line Is Nothing Then
                    DontConnect()
                    Exit Sub
                ElseIf line.Substring(0, 1) = ":" Then
                    Dim newHome As String, newDoor As String
                    newHome = DecryptString(line.Substring(1)).Split(":")(0)
                    newDoor = DecryptString(line.Substring(1)).Split(":")(1)

                    Ghoul = New TcpClient
                    Ghoul.Connect(newHome, newDoor)
                ElseIf line.Length > 0 Then
                    DontConnect()
                    Exit Sub
                Else
                    DontConnect()
                    Exit Sub
                End If
            Else
                Ghoul = New TcpClient
                Ghoul.Connect(MrFaustHome, MrFaustEntrance)
            End If

            ClientLog("Connected to " & MrFaustHome)

            rc_timer.Enabled = False
            Dim th As New Thread(AddressOf do_events)
            th.Start()

        Catch ex As Exception
            If ex.ToString.Contains(NO_CONNECTION) Then
                ClientLog("Mr Faust is not yet home...")
            ElseIf ex.ToString.Contains(DISPOSED_ISSUE) Then
                ClientLog("No object, no dispose")
            ElseIf ex.ToString.Contains(CONNECT_ATTEMPT) Then
                ClientLog("It looks like... Different...")
            Else
                ClientLog(ex.ToString)
                Die()
                Exit Sub
            End If
            Die()

            startTimer()
        End Try
    End Sub

    Private Sub DontConnect()
        rc_timer.Enabled = False
    End Sub

    Private Sub startTimer()
        Dim randTime As Double = GetRand(RECONNECT_MIN, RECONNECT_MAX) * 1000

        rc_timer = New System.Timers.Timer(randTime)
        AddHandler rc_timer.Elapsed, New System.Timers.ElapsedEventHandler(AddressOf handlerTimer)
        rc_timer.Enabled = True
    End Sub

    Private Sub handlerTimer()
        GhoulConnect()
        rc_timer.Enabled = False
    End Sub

    Private Sub Die()
        On Error Resume Next

        Ghoul.GetStream.Close()
        Ghoul.Close()
    End Sub

    Private Sub do_events()
        ' SENDING BRANCH INFORMATION
        Dim ns As NetworkStream = Ghoul.GetStream
        Dim sendBytes() As Byte = Encoding.ASCII.GetBytes(SEND_INFO)
        ns.Write(sendBytes, 0, sendBytes.Length)
        ns.Flush()

        While True

            Try

                ns = Ghoul.GetStream
                Dim inBytes(BUFFER_SIZE - 1) As Byte
                Dim byteRead As Integer = 0
                Dim onReceived As String = ""

                Do
                    byteRead = ns.Read(inBytes, 0, BUFFER_SIZE)
                    onReceived = String.Concat(onReceived, Encoding.ASCII.GetString(inBytes, 0, byteRead))
                    Thread.Sleep(100)
                Loop While ns.DataAvailable

                Dim resp As String = ParseCommand(onReceived)
                If resp = "REJECT" Then
                    Die()
                    Exit Sub
                End If

                Select Case resp
                    Case "REJECT"
                        Die()
                        Exit Sub
                    Case "CLOSE"
                        Die()

                        startTimer()
                        Exit Sub
                    Case Else
                        sendBytes = Encoding.ASCII.GetBytes(resp)
                        ns.Write(sendBytes, 0, sendBytes.Length)
                        ns.Flush()
                End Select

            Catch ex As Exception
                If ex.ToString.Contains(DISPOSED_ISSUE) Then
                    Die()
                    Exit Sub
                End If
                ClientLog(ex.ToString)
            End Try

        End While
    End Sub

    Private Function ParseCommand(ByVal str As String) As String
        If str.Substring(0, 1) <> ">" Then
            ' TODO:
            ' LOG INTRUDERS HERE
            ClientLog("INTRUDER " & Ghoul.Client.RemoteEndPoint.ToString)

            Return "REJECT"
        End If

        If str.Contains(":") Then
            Select Case str.Split(":")(0).Substring(1)
                Case "CC" '>CC:1/1/2016
                    If CurrentCmd = str Then Return "CLOSE"
                    CurrentCmd = str

                    Dim answer As String
                    answer = str & "=" & Get_CashCount(str.Split(":")(1))

                    Return answer
            End Select
        End If

        If str = ">CLOSE" Then
            Return "CLOSE"
        End If

        Return "CLOSE"
    End Function

    Private Function Get_CashCount(ByVal dt As Date) As String
        Dim mySql As String
        mySql = "SELECT TRANSDATE, TRANSNAME, "
        mySql &= vbCrLf & "	SUM(DEBIT) AS DEBIT, SUM(CREDIT) AS CREDIT, "
        mySql &= vbCrLf & "    SUM(DEBIT) + SUM(CREDIT) AS KUPIT, CCNAME"
        mySql &= vbCrLf & "FROM JOURNAL_ENTRIES"
        mySql &= vbCrLf & String.Format("WHERE TRANSDATE = '{0}' AND TRANSNAME = 'Revolving Fund' and TODISPLAY = 1", dt.ToString("M/d/yy"))
        mySql &= vbCrLf & "GROUP BY TRANSDATE, TRANSNAME, CCNAME"

        ClientLog(mySql)
        Dim ds As DataSet = LoadSQL(mySql)

        Dim ccList As New List(Of String)
        For Each dr As DataRow In ds.Tables(0).Rows
            ccList.Add(String.Format("{0}:{1}", dr("CCNAME"), dr("KUPIT")))
        Next

        ClientLog(String.Join("|", ccList))

        Return String.Join("|", ccList)
    End Function


    Private Sub ClientLog(ByVal str As String)
        Dim res As String = String.Format("[{0}] CLIENT:{1}", Now(), str)
        Console.WriteLine(res)
    End Sub

    Private Function GetRand(ByVal min As Integer, ByVal max As Integer) As Integer
        Dim randomInt As Integer
        Dim myRand As New Random
        randomInt = myRand.Next(min, max)

        ClientLog("randomInt: " & randomInt)
        Return randomInt
    End Function


End Module
