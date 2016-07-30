Module db1223
        Const ALLOWABLE_VERSION As String = "1.2.2.2"
        Const LATEST_VERSION As String = "1.2.2.3"
    Private selectedUser As New ComputerUser
    Private filldata As String = "tbl_Gamit"

    Sub PatchUp()
        If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub
        Try
            DefaultAppraiser()
            DefaultResetPassword()
            DefaultPrivilege()

            RemoveReports()

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

    Private Function AddPriv(ByVal setNum As priv_set, ByVal val As Integer) As String

        If selectedUser.Privilege Is Nothing Then Return "?"

        Dim PrivList() As String = selectedUser.Privilege.Split("|")
        Dim strRemove As String
        strRemove = PrivList(setNum).Substring(0, PrivList(setNum).Length - 1)

        strRemove &= val
        PrivList(setNum) = strRemove
        Return String.Join("|", PrivList)
    End Function

    ''' <summary>
    ''' By Default, Appraiser sila tanan
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DefaultAppraiser()

        Dim mySql2 As String = "SELECT * FROM tbl_Gamit WHERE PRIVILEGE <> 'PDuNxp8S9q0='"
        Dim ds2 As DataSet = LoadSQL(mySql2, filldata)

        For Each dsNewRow As DataRow In ds2.Tables(filldata).Rows
            With dsNewRow
                Dim tmpUserID As String = dsNewRow.Item("USERID")
                selectedUser.LoadUser(tmpUserID)
                Dim mySql As String = "SELECT * FROM tbl_Gamit WHERE PRIVILEGE <> 'PDuNxp8S9q0=' AND USERID = '" & tmpUserID & "'"
                Dim ds As DataSet = LoadSQL(mySql, filldata)

                ds.Tables(filldata).Rows(0).Item("PRIVILEGE") = AddPriv(priv_set.Encoder, 1)
                SaveEntry(ds, False)
            End With
        Next
    End Sub
   
    Private Sub DefaultResetPassword()
        Dim mySql2 As String = "SELECT * FROM tbl_Gamit WHERE PRIVILEGE <> 'PDuNxp8S9q0='"
        mySql2 &= " AND PRIVILEGE = '111111111|11111111111|11110|111110'"
        Dim ds2 As DataSet = LoadSQL(mySql2, filldata)

        For Each dsNewRow As DataRow In ds2.Tables(filldata).Rows
            With dsNewRow
                Dim tmpUserID As String = dsNewRow.Item("USERID")
                selectedUser.LoadUser(tmpUserID)
                Dim mySql As String = "SELECT * FROM tbl_Gamit WHERE PRIVILEGE <> 'PDuNxp8S9q0=' AND USERID = '" & tmpUserID & "'"
                Dim ds As DataSet = LoadSQL(mySql, filldata)

                ds.Tables(filldata).Rows(0).Item("PRIVILEGE") = AddPriv(priv_set.Manager, 1)
                SaveEntry(ds, False)
            End With
                Next
    End Sub

    Private Sub DefaultPrivilege()
        Dim mySql2 As String = "SELECT * FROM tbl_Gamit WHERE PRIVILEGE <> 'PDuNxp8S9q0='"
        mySql2 &= " AND PRIVILEGE = '111111111|11111111111|11111|111110'"
        Dim ds2 As DataSet = LoadSQL(mySql2, filldata)

        For Each dsNewRow As DataRow In ds2.Tables(filldata).Rows
            With dsNewRow
                Dim tmpUserID As String = dsNewRow.Item("USERID")
                selectedUser.LoadUser(tmpUserID)
                Dim mySql As String = "SELECT * FROM tbl_Gamit WHERE PRIVILEGE <> 'PDuNxp8S9q0=' AND USERID = '" & tmpUserID & "'"
                Dim ds As DataSet = LoadSQL(mySql, filldata)

                ds.Tables(filldata).Rows(0).Item("PRIVILEGE") = AddPriv(priv_set.Special, 1)
                SaveEntry(ds, False)
            End With
        Next
    End Sub

    Private Function RemovePriv(ByVal setNum As priv_set, ByVal val As String) As String

        If selectedUser.Privilege Is Nothing Then Return "?"

        Dim PrivList() As String = selectedUser.Privilege.Split("|")
        Dim strRemove As String
        strRemove = PrivList(setNum).Substring(0, PrivList(setNum).Length - 7)

        strRemove &= val
        PrivList(setNum) = strRemove
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

                ds.Tables(filldata).Rows(0).Item("PRIVILEGE") = RemovePriv(priv_set.Supervisor, "0001111")
                SaveEntry(ds, False)
            End With
        Next
    End Sub
End Module
