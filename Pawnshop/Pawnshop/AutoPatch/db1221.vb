Module db1221

    Const ALLOWABLE_VERSION As String = "1.2.2"
    Const LATEST_VERSION As String = "1.2.2.1"
    Private selectedUser As New ComputerUser

    Enum priv_set As Integer
        Encoder = 0
        Supervisor = 1
        Manager = 2
        Special = 3
    End Enum

    Sub PatchUp()
        If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub

        Try
            Dim mySql As String
            mySql = "CREATE TABLE TBLOTP ( "
            mySql &= vbCrLf & "  OTPID BIGINT NOT NULL, "
            mySql &= vbCrLf & "  PIN VARCHAR(15),"
            mySql &= vbCrLf & "  MOD_NAME VARCHAR(26) NOT NULL,"
            mySql &= vbCrLf & "  ADD_TIME TIMESTAMP DEFAULT CURRENT_TIMESTAMP(0) NOT NULL,"
            mySql &= vbCrLf & "  USERID SMALLINT NOT NULL);"

            RunCommand(mySql)
            AutoIncrement_ID("TBLOTP", "OTPID")

            DefaultAppraiser()

            Database_Update(LATEST_VERSION)
            Log_Report("SYSTEM PATCHED UP FROM 1.2.2 TO 1.2.2.1")
        Catch ex As Exception
            Log_Report("[1.2.2.1]" & ex.ToString)
        End Try
    End Sub

    Friend Function AddPriv(ByVal setNum As priv_set, Optional ByVal val As Integer = 111111111) As String

        If selectedUser.Privilege Is Nothing Then Return "?"

        Dim PrivList() As String = selectedUser.Privilege.Split("|")
        PrivList(setNum) = val
        Return String.Join("|", PrivList)
    End Function

    Private Sub DefaultAppraiser()
        selectedUser.LoadUser(3)
        Dim mySql As String = "SELECT * FROM tbl_Gamit WHERE PRIVILEGE <> 'PDuNxp8S9q0='"
        Dim filldata As String = "tbl_Gamit"
        Dim ds As DataSet = LoadSQL(mySql, filldata)

        For Each dsNewRow As DataRow In ds.Tables(filldata).Rows
            With dsNewRow
                dsNewRow.Item("PRIVILEGE") = AddPriv(priv_set.Encoder)
            End With
            SaveEntry(ds, False)
        Next
    End Sub


End Module
