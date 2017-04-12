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

        Disable(1)
        Try
            Dim DropPawnView As String = "DROP VIEW PAWN_LIST;"
            RunCommand(DropPawnView)

            Dim createView As String

            createView = "CREATE VIEW PAWN_LIST("
            createView &= vbCrLf & "  PAWNID,  PAWNTICKET,  LOANDATE,  MATUDATE,  EXPIRYDATE,  AUCTIONDATE,"
            createView &= vbCrLf & "  CLIENTID,  CLIENT,  CONTACTNUMBER,  FULLADDRESS,"
            createView &= vbCrLf & "  ITEMCLASS,  ITEMCATEGORY,  DESCRIPTION,  OLDTICKET,  ORNUM,  ORDATE,"
            createView &= vbCrLf & "  PRINCIPAL,  DELAYINTEREST,  ADVINT,  SERVICECHARGE,"
            createView &= vbCrLf & "  NETAMOUNT,  RENEWDUE,  REDEEMDUE,  APPRAISAL,  PENALTY,"
            createView &= vbCrLf & "  STATUS,  WITHDRAWDATE,  APPRAISER,  SENT_NOTICE )"
            createView &= vbCrLf & "AS"
            createView &= vbCrLf & "SELECT "
            createView &= vbCrLf & "P.PAWNID, P.PAWNTICKET, P.LOANDATE, P.MATUDATE, P.EXPIRYDATE, P.AUCTIONDATE, "
            createView &= vbCrLf & "C.CLIENTID, C.FIRSTNAME || ' ' || C.LASTNAME || ' ' || "
            createView &= vbCrLf & "CASE WHEN C.SUFFIX is Null THEN '' ELSE C.SUFFIX END AS CLIENT, C.PHONE1 AS CONTACTNUMBER, "
            createView &= vbCrLf & "C.ADDR_STREET || ' ' || C.ADDR_BRGY || ' ' || C.ADDR_CITY || ' ' || C.ADDR_PROVINCE || ' ' || C.ADDR_ZIP as FULLADDRESS, "
            createView &= vbCrLf & "ITM.ITEMCLASS, CLASS.ITEMCATEGORY, P.DESCRIPTION, "
            createView &= vbCrLf & "P.OLDTICKET, P.ORNUM, P.ORDATE, P.PRINCIPAL, P.DELAYINTEREST, P.ADVINT, P.SERVICECHARGE, "
            createView &= vbCrLf & "P.NETAMOUNT, P.RENEWDUE, P.REDEEMDUE, P.APPRAISAL,P.PENALTY, "
            createView &= vbCrLf & "P.STATUS, ITM.WITHDRAWDATE, USR.USERNAME AS APPRAISER, P.SENT_NOTICE "
            createView &= vbCrLf & "FROM OPT P "
            createView &= vbCrLf & "INNER JOIN TBLCLIENT C "
            createView &= vbCrLf & "ON P.CLIENTID = C.CLIENTID "
            createView &= vbCrLf & "INNER JOIN OPI ITM "
            createView &= vbCrLf & "ON ITM.PAWNITEMID = P.PAWNITEMID "
            createView &= vbCrLf & "INNER JOIN TBLITEM CLASS "
            createView &= vbCrLf & "ON CLASS.ITEMID = ITM.ITEMID "
            createView &= vbCrLf & "LEFT JOIN TBL_GAMIT USR "
            createView &= vbCrLf & "ON USR.USERID = P.APPRAISERID;"
            RunCommand(createView)

            MsgBox("Successful", MsgBoxStyle.Information, "Fixing . . ")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Disable(0)
    End Sub

    Private Sub Disable(ByVal st As Boolean)
        btnFix.Enabled = Not st
    End Sub

End Class