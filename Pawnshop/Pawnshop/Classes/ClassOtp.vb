Public Class ClassOtp
    Private fillData As String = "tblOtp"
    Private mySql As String = "SELECT * FROM "

#Region "Properties and Variables"
    Private _id As Integer
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _pin As Integer
    Public Property pin() As Integer
        Get
            Return _pin
        End Get
        Set(ByVal value As Integer)
            _pin = value
        End Set
    End Property
    Private _MOD_NAME As String
    Public Property MOD_NAME() As String
        Get
            Return _MOD_NAME
        End Get
        Set(ByVal value As String)
            _MOD_NAME = value
        End Set
    End Property
#End Region

    Sub New(ByVal ModName As String, ByVal PIN As Integer)

        mySql = "SELECT * FROM " & fillData
        mySql &= String.Format(" WHERE PIN = '{0}'", PIN)

        Dim ds As DataSet = LoadSQL(mySql, fillData)
        If ds.Tables(0).Rows.Count = 0 Then
            Dim dsNewRow As DataRow
            dsNewRow = ds.Tables(fillData).NewRow
            With dsNewRow
                .Item("PIN") = PIN
                .Item("Mod_name") = ModName
                .Item("USERID") = POSuser.UserID
            End With
            ds.Tables(fillData).Rows.Add(dsNewRow)
            database.SaveEntry(ds)

            Console.WriteLine("Entry saved")
        End If
    End Sub


    'Public Sub SaveOtp()
    '    Dim ds As DataSet = LoadSQL(mySql & fillData, fillData)

    '    Dim dsNewRow As DataRow
    '    dsNewRow = ds.Tables(fillData).NewRow
    '    With dsNewRow
    '        .Item("PIN") = _pin
    '        .Item("MOD_NAME") = mod_name
    '        '.Item("ADD_TIME") = 
    '        .Item("USERID") = POSuser.UserID
    '    End With
    '    ds.Tables(fillData).Rows.Add(dsNewRow)
    '    database.SaveEntry(ds)
    'End Sub
End Class
