Module db1224
    Const ALLOWABLE_VERSION As String = "1.2.2.3"
    Const LATEST_VERSION As String = "1.2.2.4"
    Private selectedUser As New ComputerUser
    Private filldata As String = "tbl_Gamit"
    Sub PatchUp()
        If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub
        Try
            RemoveReports() 'Remove Audit Report

            Database_Update(LATEST_VERSION)
            Log_Report("SYSTEM PATCHED UP FROM 1.2.2.2 TO 1.2.2.3")
        Catch ex As Exception
            Log_Report("[1.2.2.3]" & ex.ToString)
        End Try
    End Sub
    Private Function RemovePriv(ByVal setNum As priv_set) As String

        If selectedUser.Privilege Is Nothing Then Return "?"

        Dim PrivList() As String = selectedUser.Privilege.Split("|")
        Dim strSubstring As String
        strSubstring = PrivList(setNum)
        If strSubstring.Substring(7, 1) = "1" Then Mid(strSubstring, 8, 1) = 0

        PrivList(setNum) = strSubstring
        Return String.Join("|", PrivList)
    End Function

    Private Sub RemoveReports()

        Dim mySql2 As String = "SELECT * FROM tbl_Gamit WHERE PRIVILEGE <> 'PDuNxp8S9q0='"
        mySql2 &= " AND PRIVILEGE <> '111111111|11111111111|11111|111111'"
        Dim ds2 As DataSet = LoadSQL(mySql2, filldata)

        For Each dsNewRow2 As DataRow In ds2.Tables(filldata).Rows
            With dsNewRow2
                Dim tmpUserID As String = dsNewRow2.Item("USERID")
                selectedUser.LoadUser(tmpUserID)

                Dim mySql As String = "SELECT * FROM tbl_Gamit WHERE PRIVILEGE <> 'PDuNxp8S9q0=' AND USERID = '" & tmpUserID & "'"
                Dim ds As DataSet = LoadSQL(mySql, filldata)

                ds.Tables(filldata).Rows(0).Item("PRIVILEGE") = RemovePriv(priv_set.Supervisor)
                SaveEntry(ds, False)
            End With
        Next
    End Sub
End Module
