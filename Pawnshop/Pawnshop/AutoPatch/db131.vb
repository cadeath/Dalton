Module db131
    Const ALLOWABLE_VERSION As String = "1.3"
    Const LATEST_VERSION As String = "1.3.1"

    Private strSql As String

    Sub PatchUp()
        If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub
        Try

            AlterCLient()

            Database_Update(LATEST_VERSION)
            Log_Report(String.Format("SYSTEM PATCHED UP FROM {0} TO {1}", ALLOWABLE_VERSION, LATEST_VERSION))
        Catch ex As Exception
            Log_Report(String.Format("[{0}]" & ex.ToString, LATEST_VERSION))
        End Try
    End Sub

    Private Sub AlterCLient()
        Dim createViewClient As String
        Dim mysql As String = "ALTER TABLE TBLCLIENT ADD ISDUMPER VARCHAR(1) DEFAULT '0';"
        RunCommand(mysql)

        mysql = "DROP VIEW VIEW_CLIENT"
        RunCommand(mysql)

        createViewClient = "	CREATE VIEW VIEW_CLIENT(	"
        createViewClient &= vbCrLf & "	  CLIENTID,FIRSTNAME,MIDDLENAME,LASTNAME,SUFFIX,ADDR_STREET,ADDR_BRGY,ADDR_CITY,	"
        createViewClient &= vbCrLf & "	  ADDR_PROVINCE,ADDR_ZIP,SEX,BIRTHDAY,PHONE1,PHONE2,PHONE3,PHONE_OTHERS,ISDUMPER,IDTYPE,	"
        createViewClient &= vbCrLf & "	  REFNUM,ISSELECTED,REMARKS)	"
        createViewClient &= vbCrLf & "	AS	"
        createViewClient &= vbCrLf & "	SELECT cl.*, id.IDTYPE, id.REFNUM, id.ISSELECTED, id.REMARKS	"
        createViewClient &= vbCrLf & "	FROM TBLCLIENT cl	"
        createViewClient &= vbCrLf & "	LEFT JOIN TBLIDENTIFICATION id	"
        createViewClient &= vbCrLf & "	ON id.CLIENTID = cl.CLIENTID	"
        createViewClient &= vbCrLf & "	WHERE ID.isSelected = 1 OR ID.isSelected is Null;	"
        RunCommand(createViewClient)
    End Sub


End Module
