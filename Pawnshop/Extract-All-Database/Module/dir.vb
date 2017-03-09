Imports System
Imports System.IO
Imports System.Collections
Public Class dir
    Public Overloads Shared Sub Main(ByVal args() As String)
        Dim path As String
        For Each path In args
            If File.Exists(path) Then

                ProcessFile(path)
            Else
                If Directory.Exists(path) Then

                    ProcessDirectory(path)
                Else
                    Console.WriteLine("{0} is not a valid file or directory.", path)
                End If
            End If
        Next path
    End Sub


    Public Shared Sub ProcessDirectory(ByVal targetDirectory As String)
        Dim fileEntries As String() = Directory.GetFiles(targetDirectory)
        Dim fileName As String


        For Each fileName In fileEntries
            ProcessFile(fileName)

        Next fileName
        Dim subdirectoryEntries As String() = Directory.GetDirectories(targetDirectory)
        Dim subdirectory As String

        For Each subdirectory In subdirectoryEntries
            ProcessDirectory(subdirectory)
        Next subdirectory

    End Sub

    Public Shared Sub ProcessFile(ByVal path As String)
        Console.WriteLine("Processed file '{0}'.", path)
        If path.Contains(".rar") = True Then
            On Error Resume Next
        Else
            Dim lv As ListViewItem = frmDatabseExtractor.LV_DBList.Items.Add(path)
        End If
    End Sub


    Friend Function new_loan(ByVal sDate As Date, ByVal enDate As Date) As String

        Dim NewLoan As String
        NewLoan = "SELECT" & _
        " P.PAWNID, P.PAWNTICKET, P.LOANDATE, P.MATUDATE, P.EXPIRYDATE, P.AUCTIONDATE," & _
        " C.FIRSTNAME || ' ' || C.LASTNAME || ' ' || " & _
        " CASE WHEN C.SUFFIX is Null THEN '' ELSE C.SUFFIX END AS CLIENT, C.PHONE1 AS CONTACTNUMBER," & _
        " C.ADDR_STREET || ' ' || C.ADDR_BRGY || ' ' || C.ADDR_CITY || ' ' || C.ADDR_PROVINCE || ' ' || C.ADDR_ZIP as FULLADDRESS," & _
        " ITM.ITEMCLASS, CLASS.ITEMCATEGORY, P.DESCRIPTION, " & _
        " P.OLDTICKET, P.ORNUM, P.ORDATE, P.PRINCIPAL, P.DELAYINTEREST, P.ADVINT, P.SERVICECHARGE, " & _
        " P.NETAMOUNT, P.RENEWDUE, P.REDEEMDUE, P.APPRAISAL,P.PENALTY, " & _
        " P.STATUS, ITM.WITHDRAWDATE, USR.USERNAME AS APPRAISER " & _
        " FROM OPT P " & _
        " INNER JOIN TBLCLIENT C " & _
        " ON P.CLIENTID = C.CLIENTID " & _
        " INNER JOIN OPI ITM " & _
        " ON ITM.PAWNITEMID = P.PAWNITEMID " & _
        " INNER JOIN TBLITEM CLASS " & _
        " ON CLASS.ITEMID = ITM.ITEMID " & _
        " LEFT JOIN TBL_GAMIT USR " & _
        " ON USR.USERID = P.APPRAISERID" & _
        String.Format(" WHERE P.LOANDATE BETWEEN '{0}' AND '{1}'", sDate.ToShortDateString, enDate.ToShortDateString) & _
        " AND P.STATUS ='L' OR P.STATUS = 'R'"

        Return NewLoan
    End Function

    Friend Function Vault(ByVal d1 As Date) As String
        Dim d As Date = d.ToShortDateString

        Dim sql_vault = "SELECT * FROM (" & _
        "	SELECT *   FROM PAWN_LIST   WHERE Status = 'L'" & _
        "	AND LOANDATE <= '" & d & "'" & _
        "	UNION" & _
        "	SELECT *   FROM PAWN_LIST WHERE Status = 'R' " & _
        "	AND LOANDATE <= '" & d & "'" & _
        "	UNION" & _
        "	SELECT *   FROM PAWN_LIST WHERE Status = '0'" & _
        "	AND LOANDATE <= '" & d & "' AND ORDATE > '" & d & "'" & _
        "	UNION" & _
        "	SELECT *   FROM PAWN_LIST WHERE Status = 'X'" & _
        "	AND LOANDATE <= '" & d & "' AND ORDATE > '" & d & "'" & _
        "	UNION" & _
        "	SELECT *   FROM PAWN_LIST WHERE Status = 'S'" & _
        " AND LOANDATE <= '" & d & "'" & _
        "	UNION" & _
        "	SELECT * FROM PAWN_LIST WHERE Status = 'W' AND LOANDATE <= '" & d & "'" & _
        " AND WITHDRAWDATE >= '" & d & "'" & _
        ")  ORDER BY PAWNTICKET ASC"

        Return sql_vault
    End Function
End Class '
