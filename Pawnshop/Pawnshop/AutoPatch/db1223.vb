Module db1223
        Const ALLOWABLE_VERSION As String = "1.2.2.2"
        Const LATEST_VERSION As String = "1.2.2.3"
    Private selectedUser As New ComputerUser
    Sub PatchUp()
        If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub

        Try

            DefaultAppraiser()

            Database_Update(LATEST_VERSION)
            Log_Report("SYSTEM PATCHED UP FROM 1.2.2.2 TO 1.2.2.3")
        Catch ex As Exception
            Log_Report("[1.2.2.3]" & ex.ToString)
        End Try
    End Sub
    Enum priv_set As Integer
        Encoder = 0
        Supervisor = 1
        Manager = 2
        Special = 3
    End Enum

    Friend Function AddPriv(ByVal setNum As priv_set, Optional ByVal val As Integer = 111111111) As String
       
        If selectedUser.Privilege Is Nothing Then Return "?"

        Dim PrivList() As String = selectedUser.Privilege.Split("|")
        PrivList(setNum) = val
        Return String.Join("|", PrivList)
    End Function

    Private Sub DefaultAppraiser()
        Dim filldata As String = "tbl_Gamit"
        Dim mySql2 As String = "SELECT * FROM tbl_Gamit WHERE PRIVILEGE <> 'PDuNxp8S9q0='"
        Dim ds2 As DataSet = LoadSQL(mySql2, filldata)

        For Each dsNewRow As DataRow In ds2.Tables(filldata).Rows
            With dsNewRow
                Dim tmpUserID As String = dsNewRow.Item("USERID")
                selectedUser.LoadUser(tmpUserID)
                Dim mySql As String = "SELECT * FROM tbl_Gamit WHERE PRIVILEGE <> 'PDuNxp8S9q0=' AND USERID = '" & tmpUserID & "'"
                Dim ds As DataSet = LoadSQL(mySql, filldata)

                ds.Tables(filldata).Rows(0).Item("PRIVILEGE") = AddPriv(priv_set.Encoder)
                SaveEntry(ds, False)
            End With
        Next
    End Sub

End Module
