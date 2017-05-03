Module ModCamera
    Dim prng As New Random
    Const minCH As Integer = 15 'minimum chars in random string
    Const maxCH As Integer = 20 'maximum chars in random string

    Const randCH As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"

    Public Const WM_Cap As Short = &H400S
    Public Const WM_Cap_Paki_CONNECT As Integer = WM_Cap + 10
    Public Const WM_Cap_Paki_DISCONNECT As Integer = WM_Cap + 11
    Public Const WM_Cap_EDIT_COPY As Integer = WM_Cap + 30
    Public Const WM_Cap_SET_PREVIEW As Integer = WM_Cap + 50
    Public Const WM_Cap_SET_PREVIEWRATE As Integer = WM_Cap + 52
    Public Const WM_Cap_SET_SCALE As Integer = WM_Cap + 53
    Public Const WS_CHILD As Integer = &H40000000
    Public Const WS_VISIBLE As Integer = &H10000000
    Public Const SWP_NOMOVE As Short = &H2S
    Public Const SWP_NOSIZE As Short = 1
    Public Const SWP_NOZORDER As Short = &H4S
    Public Const HWND_BOTTOM As Short = 1
    Public iDevice As Integer = 0
    Public hHwnd As Integer

    Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hWnd As Integer, ByVal Msg As Integer, ByVal wParam As Integer, ByRef RECT As Integer) As Integer
    Public Declare Function SetWindowPos Lib "user32" Alias "SetWindowPos" (ByVal hwnd As Integer, ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer
    Public Declare Function DestroyWindow Lib "user32" (ByVal hndw As Integer) As Boolean
    Public Declare Function capCreateCaptureWindowA Lib "avicap32.dll" (ByVal lpszWindowName As String, _
                                                                        ByVal dwStyle As Integer, ByVal x As Integer, _
                                                                        ByVal y As Integer, ByVal nWidth As Integer, _
                                                                        ByVal nHeight As Short, ByVal hWndParent As Integer, _
                                                                        ByVal nID As Integer) As Integer
    Public Declare Function capGetDriverDescriptionA Lib "avicap32.dll" (ByVal wDriver As Short, ByVal lpszName As String, ByVal cbName As Integer, ByVal lpszVer As String, ByVal cbVer As Integer) As Boolean


    Friend Sub OpenPreviewWindow()
        Dim iHeight As Integer = frmCustomer_KYC.ClientImage.Height
        Dim iWidth As Integer = frmCustomer_KYC.ClientImage.Width
        hHwnd = capCreateCaptureWindowA(iDevice, WS_VISIBLE Or WS_CHILD, 0, 0, 640, 480, frmCustomer_KYC.ClientImage.Handle.ToInt32, 0)
        If SendMessage(hHwnd, WM_Cap_Paki_CONNECT, iDevice, 0) Then
            SendMessage(hHwnd, WM_Cap_SET_SCALE, True, 0)
            SendMessage(hHwnd, WM_Cap_SET_PREVIEWRATE, 66, 0)
            SendMessage(hHwnd, WM_Cap_SET_PREVIEW, True, 0)
            SetWindowPos(hHwnd, HWND_BOTTOM, 0, 0, frmCustomer_KYC.ClientImage.Width, frmCustomer_KYC.ClientImage.Height, SWP_NOMOVE Or SWP_NOZORDER)
        Else
            DestroyWindow(hHwnd)
        End If
    End Sub

    Friend Sub OpenForSignature()
        Dim iHeight As Integer = frmCustomer_KYC.CLientSignature.Height
        Dim iWidth As Integer = frmCustomer_KYC.CLientSignature.Width
        hHwnd = capCreateCaptureWindowA(iDevice, WS_VISIBLE Or WS_CHILD, 0, 0, 640, 480, frmCustomer_KYC.CLientSignature.Handle.ToInt32, 0)
        If SendMessage(hHwnd, WM_Cap_Paki_CONNECT, iDevice, 0) Then
            SendMessage(hHwnd, WM_Cap_SET_SCALE, True, 0)
            SendMessage(hHwnd, WM_Cap_SET_PREVIEWRATE, 66, 0)
            SendMessage(hHwnd, WM_Cap_SET_PREVIEW, True, 0)
            SetWindowPos(hHwnd, HWND_BOTTOM, 0, 0, frmCustomer_KYC.CLientSignature.Width, frmCustomer_KYC.CLientSignature.Height, SWP_NOMOVE Or SWP_NOZORDER)
        Else
            DestroyWindow(hHwnd)
        End If
    End Sub

    Friend Sub ClosePreviewWindow()
        SendMessage(hHwnd, WM_Cap_Paki_DISCONNECT, iDevice, 0)
        DestroyWindow(hHwnd)
    End Sub


    Friend Function FileName() As String
        Dim sb As New System.Text.StringBuilder
        For i As Integer = 1 To prng.Next(minCH, maxCH + 1)
            sb.Append(randCH.Substring(prng.Next(0, randCH.Length), 1))
        Next
        Return sb.ToString()
    End Function
End Module
