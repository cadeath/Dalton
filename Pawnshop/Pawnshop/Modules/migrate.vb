Imports Microsoft.Office.Interop

Module migrate
    Private mySql As String = String.Empty

    Friend Function ifSex(ByVal str As String) As Boolean
        If Not IsNumeric(str) Then str = str.ToLower
        Select Case str
            Case 0 : Return True
            Case 1 : Return True
            Case "f" : Return True
            Case "m" : Return True
        End Select

        Return False
    End Function

    Friend Function dbSex(ByVal str As String) As Integer
        If IsNumeric(str) Then Return str
        Select Case str
            Case "f" : Return 0
            Case "m" : Return 1
        End Select

        Return 0
    End Function

    Friend Function ifPhone(ByVal str As String) As Boolean
        If Not IsNumeric(str) Then Return False

        '09257977559
        If str.Substring(0, 2) = "09" And str.Length = 11 Then Return True
        '+639257977559
        If str.Substring(0, 4) = "+639" And str.Length = 13 Then Return True
        '9257977559
        If str.Substring(0, 1) = "9" And str.Length = 10 Then Return True

        Return False
    End Function

    Friend Function ifItemType(ByVal str As String) As Boolean
        mySql = "SELECT * FROM tblClass WHERE Type = '" & str & "'"
        Dim ds As DataSet = LoadSQL(mySql)
        If ds.Tables(0).Rows.Count = 0 Then Return False
        Return True
    End Function

    Friend _catID As Integer
    Friend Function isClass(ByVal desc As String) As Boolean
        mySql = "SELECT * FROM tblClass WHERE Category = '" & desc & "'"
        Dim ds As DataSet = LoadSQL(mySql)
        If ds.Tables(0).Rows.Count = 0 Then Return False

        _catID = ds.Tables(0).Rows(0).Item("ClassID")
        Return True
    End Function

    Friend Function ifStatus(ByVal str As String) As Boolean
        On Error Resume Next

        Select Case str.ToUpper
            Case "A" : Return True
            Case "T" : Return True
        End Select

        Return False
    End Function

    Friend Function SearchClient(ByVal fname As String, ByVal lname As String) As DataSet
        mySql = "SELECT * FROM tblClient "
        mySql &= String.Format("WHERE FirstName LIKE '%{0}%' AND LastName LIKE '%{1}%'", fname, lname)

        Dim ds As DataSet = LoadSQL(mySql, "tblClient")
        Return ds
    End Function

    Friend Function isDuplication(ByVal pt As Int64) As Boolean
        Console.WriteLine("Checking PT " & pt)
        mySql = "SELECT * FROM tblPawn "
        mySql &= "WHERE PawnTicket = " & pt
        Dim ds As DataSet = LoadSQL(mySql)
        If ds.Tables(0).Rows.Count = 0 Then Return False

        Return True
    End Function
End Module
