
Imports Microsoft.Office.Interop
Module mod_sys
    Public PASSWORD_AGE_COUNT As Integer = 0
    Public PASSWORD_EXPIRY_COUNT As Integer = 0
    Public SYSTEM_USERID As Integer = 0
    Public tmpPassword As String = ""

    Public selected_USEr As New Sys_user
    Public UType As String = ""
    Public FullName As String = ""

    Public IDX As Integer = 0
    Public AccountRule As New User_Line_RULES

    Function UppercaseFirstLetter(ByVal val As String) As String
        ' Test for nothing or empty.
        If String.IsNullOrEmpty(val) Then
            Return val
        End If

        ' Convert to character array.
        Dim array() As Char = val.ToCharArray

        ' Uppercase first character.
        array(0) = Char.ToUpper(array(0))

        ' Return new string.
        Return New String(array)
    End Function

    Function Date_Calculation(ByVal EXPIRATE_DATE As Date) As Integer
        Dim ValidDate As Date = CDate(EXPIRATE_DATE)
        Dim date1 As New System.DateTime(ValidDate.Year, ValidDate.Month, ValidDate.Day)

        Dim Diff1 As System.TimeSpan = date1.Subtract(Now)

        Dim TotRemDays = (Int(Diff1.TotalDays))
        Return TotRemDays
    End Function
End Module
