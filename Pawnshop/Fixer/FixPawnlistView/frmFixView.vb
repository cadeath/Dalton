Public Class frmFixView
    Const DBPATH As String = "\W3W1LH4CKU.FDB"

    Private Sub LoadPath()
        Dim readValue = My.Computer.Registry.GetValue(
    "HKEY_LOCAL_MACHINE\Software\cdt-S0ft\Pawnshop", "InstallPath", Nothing)

        Dim firebird As String = readValue & DBPATH
        database.dbName = firebird
        txtData.Text = firebird
    End Sub
    Private Sub frmFixView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadPath()
    End Sub

    Private Sub btnFix_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFix.Click
        Try
            Pawnlist()
            MsgBox("Successful")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "E R R O R")
        End Try

    End Sub
    Private Sub Pawnlist()
        Dim DropPawnView As String = "DROP VIEW PAWN_LIST;"
        RunCommand(DropPawnView)

        Dim Pawn_List As String
        Pawn_List = "CREATE VIEW PAWN_LIST("
        Pawn_List &= vbCrLf & "PAWNID, "
        Pawn_List &= vbCrLf & "PAWNTICKET, "
        Pawn_List &= vbCrLf & "LOANDATE, "
        Pawn_List &= vbCrLf & "MATUDATE, "
        Pawn_List &= vbCrLf & "EXPIRYDATE, "
        Pawn_List &= vbCrLf & "AUCTIONDATE, "
        Pawn_List &= vbCrLf & "CLIENT, "
        Pawn_List &= vbCrLf & "CONTACTNUMBER, "
        Pawn_List &= vbCrLf & "FULLADDRESS, "
        Pawn_List &= vbCrLf & "ITEMCLASS, "
        Pawn_List &= vbCrLf & "ITEMCATEGORY, "
        Pawn_List &= vbCrLf & "DESCRIPTION, "
        Pawn_List &= vbCrLf & "OLDTICKET, "
        Pawn_List &= vbCrLf & "ORNUM, "
        Pawn_List &= vbCrLf & "ORDATE, "
        Pawn_List &= vbCrLf & "PRINCIPAL, "
        Pawn_List &= vbCrLf & "DELAYINTEREST, "
        Pawn_List &= vbCrLf & "ADVINT, "
        Pawn_List &= vbCrLf & "SERVICECHARGE, "
        Pawn_List &= vbCrLf & "NETAMOUNT, "
        Pawn_List &= vbCrLf & "RENEWDUE, "
        Pawn_List &= vbCrLf & "REDEEMDUE, "
        Pawn_List &= vbCrLf & "APPRAISAL, "
        Pawn_List &= vbCrLf & "PENALTY, "
        Pawn_List &= vbCrLf & "STATUS, "
        Pawn_List &= vbCrLf & "WITHDRAWDATE, "
        Pawn_List &= vbCrLf & "APPRAISER) "
        Pawn_List &= vbCrLf & "AS "
        Pawn_List &= vbCrLf & "SELECT "
        Pawn_List &= vbCrLf & "P.PAWNID, P.PAWNTICKET, P.LOANDATE, P.MATUDATE, P.EXPIRYDATE, P.AUCTIONDATE, "
        Pawn_List &= vbCrLf & "C.FIRSTNAME || ' ' || C.LASTNAME || ' ' || "
        Pawn_List &= vbCrLf & "CASE WHEN C.SUFFIX is Null THEN '' ELSE C.SUFFIX END AS CLIENT, C.PHONE1 AS CONTACTNUMBER, "
        Pawn_List &= vbCrLf & "C.ADDR_STREET || ' ' || C.ADDR_CITY || ' ' || C.ADDR_PROVINCE || ' ' || C.ADDR_ZIP as FULLADDRESS, "
        Pawn_List &= vbCrLf & "ITM.ITEMCLASS, CLASS.ITEMCATEGORY, P.DESCRIPTION, "
        Pawn_List &= vbCrLf & "P.OLDTICKET, P.ORNUM, P.ORDATE, P.PRINCIPAL, P.DELAYINTEREST, P.ADVINT, P.SERVICECHARGE, "
        Pawn_List &= vbCrLf & "P.NETAMOUNT, P.RENEWDUE, P.REDEEMDUE, P.APPRAISAL,P.PENALTY, "
        Pawn_List &= vbCrLf & "P.STATUS, ITM.WITHDRAWDATE, USR.USERNAME AS APPRAISER "
        Pawn_List &= vbCrLf & "FROM OPT P "
        Pawn_List &= vbCrLf & "INNER JOIN TBLCLIENT C "
        Pawn_List &= vbCrLf & "ON P.CLIENTID = C.CLIENTID "
        Pawn_List &= vbCrLf & "INNER JOIN OPI ITM "
        Pawn_List &= vbCrLf & "ON ITM.PAWNITEMID = P.PAWNITEMID "
        Pawn_List &= vbCrLf & "INNER JOIN TBLITEM CLASS "
        Pawn_List &= vbCrLf & "ON CLASS.ITEMID = ITM.ITEMID "
        Pawn_List &= vbCrLf & "LEFT JOIN TBL_GAMIT USR "
        Pawn_List &= vbCrLf & "ON USR.USERID = P.APPRAISERID "
        RunCommand(Pawn_List)
    End Sub
End Class