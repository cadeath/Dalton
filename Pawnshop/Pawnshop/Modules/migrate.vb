Imports Microsoft.Office.Interop

Module migrate
    Private mySql As String = String.Empty
    ''' <summary>
    ''' This function declare str to hold the case information.
    ''' </summary>
    ''' <param name="str"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
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
    ''' <summary>
    ''' This function has case if user choose "f" it return to 0.
    ''' and if user choose "m" it return 1.
    ''' </summary>
    ''' <param name="str">str here hold the case data.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function dbSex(ByVal str As String) As Integer
        If IsNumeric(str) Then Return str
        Select Case str
            Case "f" : Return 0
            Case "m" : Return 1
        End Select

        Return 0
    End Function
    ''' <summary>
    ''' This function shows the selection of phone number choices.
    ''' </summary>
    ''' <param name="str"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
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
    ''' <summary>
    ''' This function will select all data from tblclass where the str is the parameter
    ''' only data shows if what str value.
    ''' </summary>
    ''' <param name="str">str is the parameter.</param>
    ''' <returns>it return true if dataset if not zero.</returns>
    ''' <remarks></remarks>
    Friend Function ifItemType(ByVal str As String) As Boolean
        mySql = "SELECT * FROM tblClass WHERE Type = '" & str & "'"
        Dim ds As DataSet = LoadSQL(mySql)
        If ds.Tables(0).Rows.Count = 0 Then Return False
        Return True
    End Function

    Friend _catID As Integer 'declare the _catID here as integer means it hold only digit.
    ''' <summary>
    ''' This function select all from tblclass.
    ''' Only data will shows if what value in a desc.
    ''' </summary>
    ''' <param name="desc">desc is the parameter.</param>
    ''' <returns>return true if the dataset if not zero.</returns>
    ''' <remarks></remarks>
    Friend Function isClass(ByVal desc As String) As Boolean
        mySql = "SELECT * FROM tblClass WHERE Category = '" & desc & "'"
        Dim ds As DataSet = LoadSQL(mySql)
        If ds.Tables(0).Rows.Count = 0 Then Return False

        _catID = ds.Tables(0).Rows(0).Item("ClassID")
        Return True
    End Function
    ''' <summary>
    ''' This function select the case.
    ''' </summary>
    ''' <param name="str">This str here is the parameter where hold the nonmodifiable value.</param>
    ''' <returns>return true if user select "A" and "T". And return false if these two are not choose.</returns>
    ''' <remarks></remarks>
    Friend Function ifStatus(ByVal str As String) As Boolean
        On Error Resume Next

        Select Case str.ToUpper
            Case "A" : Return True
            Case "T" : Return True
        End Select

        Return False
    End Function
    ''' <summary>
    ''' This function select all data from tblClient.
    ''' only data will show if name are to be called.
    ''' </summary>
    ''' <param name="fname">fname is the parameter of a name.</param>
    ''' <param name="lname">lname also paremeter of a name.</param>
    ''' <returns>return ds after reading every transaction.</returns>
    ''' <remarks></remarks>
    Friend Function SearchClient(ByVal fname As String, ByVal lname As String) As DataSet
        mySql = "SELECT * FROM tblClient "
        mySql &= String.Format("WHERE FirstName LIKE '%{0}%' AND LastName LIKE '%{1}%'", fname, lname)

        Dim ds As DataSet = LoadSQL(mySql, "tblClient")
        Return ds
    End Function
    ''' <summary>
    ''' This function shows if the ID of the client if already exists.
    ''' </summary>
    ''' <param name="pt">pt here is the paremeter it hold the id.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function isDuplication(ByVal pt As Int64) As Boolean
        Console.WriteLine("Checking PT " & pt)
        mySql = "SELECT * FROM tblPawn "
        mySql &= "WHERE PawnTicket = " & pt
        Dim ds As DataSet = LoadSQL(mySql)
        If ds.Tables(0).Rows.Count = 0 Then Return False

        Return True
    End Function
End Module
