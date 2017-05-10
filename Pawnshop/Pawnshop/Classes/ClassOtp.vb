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

    Private _remarks As String
    Public Property Remarks() As String
        Get
            Return _remarks
        End Get
        Set(ByVal value As String)
            _remarks = value
        End Set
    End Property

#End Region

    Sub New(ByVal ModName As String, ByVal PIN As Integer, Optional ByVal Remarks As String = "", Optional ByVal MultipleOtp As Boolean = False)

        mySql = "SELECT * FROM " & fillData
        mySql &= String.Format(" WHERE PIN = '{0}'", PIN)

        Dim ds As DataSet = LoadSQL(mySql, fillData)
        If MultipleOtp = False Then
            If ds.Tables(0).Rows.Count = 0 Then
                Dim dsNewRow As DataRow
                dsNewRow = ds.Tables(fillData).NewRow
                With dsNewRow
                    .Item("PIN") = PIN
                    .Item("Mod_name") = ModName
                    .Item("USERID") = SystemUser.ID
                    .Item("Remarks") = Remarks
                End With
                ds.Tables(fillData).Rows.Add(dsNewRow)
                database.SaveEntry(ds)
                Console.WriteLine("Entry saved")
            Else
                AddTimelyLogs("OTP PIN", ModName & " DUPLICATE PIN", , False, "PIN# " & PIN, )
            End If
        Else
            Dim dsNewRow As DataRow
            dsNewRow = ds.Tables(fillData).NewRow
            With dsNewRow
                .Item("PIN") = PIN
                .Item("Mod_name") = ModName
                .Item("USERID") = SystemUser.ID
                .Item("Remarks") = Remarks
            End With
            ds.Tables(fillData).Rows.Add(dsNewRow)
            database.SaveEntry(ds)
        End If
    End Sub

End Class
