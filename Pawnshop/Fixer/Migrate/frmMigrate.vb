Public Class frmMigrate
    Const DBPATH As String = "\W3W1LH4CKU.FDB"

#Region "Old"
    Private Sub UpdateScheme()
        Try
            Dim mysql As String = "Select * from tblPawn"
            Dim filldata As String = "tblPawn"
            Dim ds As DataSet = LoadSQL(mysql, filldata)

            For Each dr As DataRow In ds.Tables(0).Rows
                Dim tmpPawnID As String = dr.Item("PawnID")
                Dim tmpItemType As String = dr.Item("ItemType")
                Dim tmpIntcheckSum As String
                If Not IsDBNull(dr.Item("int_checksum")) Then tmpIntcheckSum = dr.Item("int_checksum")

                Dim tmpSchemeID As String = GetInt(tmpItemType, tmpIntcheckSum)

                Dim mysql2 As String = "Select * from OPI where PawnItemID = '" & tmpPawnID & "'"
                Dim filldata2 As String = "OPI"
                Dim ds2 As DataSet = LoadSQL(mysql2, filldata2)
                ds2.Tables(filldata2).Rows(0).Item("Scheme_ID") = tmpSchemeID
                database.SaveEntry(ds2, False)

                pbProgressBar.Value = pbProgressBar.Value + 1
                Application.DoEvents()
                lblPercent.Text = String.Format("{0}%", ((pbProgressBar.Value / pbProgressBar.Maximum) * 100).ToString("F2"))

            Next
            If MsgBox("Successful", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, _
                 "Migrating...") = MsgBoxResult.Ok Then pbProgressBar.Maximum = 0
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
#End Region

    Private Sub UpdateScheme2()
        'Try
        Dim mysql As String = "SELECT  P.PAWNTICKET, P.LOANDATE, P.MATUDATE, P.EXPIRYDATE, P.AUCTIONDATE, P.CLIENTID, "
        mysql &= "CASE  WHEN P.ITEMTYPE = 'JWL' AND (P.DESCRIPTION = Null OR P.DESCRIPTION = '') THEN  "
        mysql &= "CLASS.CATEGORY || ' ' || ROUND(P.GRAMS,2) || 'G ' || P.KARAT || 'K' "
        mysql &= " ELSE P.DESCRIPTION END AS Description,  "
        mysql &= "P.ORNUM, P.ORDATE, P.OLDTICKET, P.NETAMOUNT, P.RENEWDUE, P.REDEEMDUE, P.APPRAISAL, P.PRINCIPAL,  "
        mysql &= "P.INTEREST, P.ADVINT, P.SERVICECHARGE,P.PENALTY, P.ITEMTYPE, CLASS.CATEGORY, P.GRAMS, P.KARAT, "
        mysql &= "P.STATUS, P.PULLOUT, P.INT_CHECKSUM, P.KARAT AS PAWNKARAT, P.GRAMS AS PAWNGRAMS "
        mysql &= "FROM TBLPAWN P LEFT JOIN TBLCLASS CLASS ON CLASS.CLASSID = P.CATID "
        Dim ds As DataSet = LoadSQL(mysql)

        For Each dr As DataRow In ds.Tables(0).Rows
            'Migrate
            Dim MigPt As Integer = dr.Item("PawnTicket")
            Dim MigOldPt As Integer = dr.Item("OldTicket")
            Dim MigCategory As String = dr.Item("Category")
            Dim MigItemType As String = dr.Item("ItemType")
            Dim MigKarat As String = dr.Item("PAWNKARAT")
            Dim MigGrams As String = dr.Item("PAWNGRAMS")
            Dim MigDiscription As String = dr.Item("Description")
            Dim MigCheckSum As String
            If Not IsDBNull(dr.Item("int_checksum")) Then MigCheckSum = dr.Item("int_checksum")

            'Search in OPT
            Dim sqlOpt As String = "Select * from OPT where OldTicket = " & MigPt
            Dim DsOpt As DataSet = LoadSQL(sqlOpt, "OPT")

            If DsOpt.Tables(0).Rows.Count > 0 Then
                sqlOpt = "Select * from OPT"
                DsOpt.Clear()
                DsOpt = LoadSQL(sqlOpt, "OPT")
                Dim dsNewRow As DataRow
                dsNewRow = DsOpt.Tables("OPT").NewRow
                With dsNewRow
                    '.Item("PawnTicket") = PTNew
                    .Item("OldTicket") = MigPt
                End With
                DsOpt.Tables("OPT").Rows.Add(dsNewRow)
                database.SaveEntry(DsOpt)

            Else
                Dim sqlOpi As String = "Select * from OPI"
                Dim DsOpi As DataSet = LoadSQL(sqlOpi, "OPI")

                Dim dsNewRow As DataRow
                dsNewRow = DsOpi.Tables("OPI").NewRow
                With dsNewRow
                    .Item("ItemID") = GetClass(MigCategory, ItemClass.ID)
                    .Item("ItemClass") = GetClass(MigCategory, ItemClass.Name)
                    .Item("Scheme_ID") = GetInt(MigItemType, MigCheckSum)
                End With
                DsOpi.Tables("OPI").Rows.Add(dsNewRow)
                database.SaveEntry(DsOpi)

                Dim sqlPi1 As String = "Select * from PI1"
                Dim DsPi1 As DataSet = LoadSQL(sqlPi1, "PI1")
                dsNewRow = DsPi1.Tables("PI1").NewRow

                Dim specsName As String() = {"GRAMS", "KARAT", "DESCRIPTION"}
                Dim specsType As String() = {"INTEGER", "INTEGER", "STRING"}
                If MigItemType = "JWL" Then
                    For i As Integer = 0 To 2
                        With dsNewRow
                            .Item("SpecsName") = specsName(i)
                            .Item("SpecsType") = specsType(i)
                            If "GRAMS" = specsName(i) Then
                                .Item("SpecsValue") = MigGrams
                            ElseIf "KARAT" = specsName(i) Then
                                .Item("SpecsValue") = MigKarat
                            Else
                                .Item("SpecsValue") = MigDiscription
                            End If
                            .Item("PawnItemID") = GetLastID()
                            DsPi1.Tables("PI1").Rows.Add(dsNewRow)
                        End With
                        database.SaveEntry(DsPi1)
                    Next
                Else
                    With dsNewRow
                        .Item("SpecsName") = specsName(3)
                        .Item("SpecsType") = specsType(3)
                        .Item("SpecsValue") = MigDiscription
                        .Item("PawnItemID") = GetLastID()
                    End With
                    DsPi1.Tables("PI1").Rows.Add(dsNewRow)
                    database.SaveEntry(DsPi1)
                End If

                DsPi1.Tables("PI1").Rows.Add(dsNewRow)
                database.SaveEntry(DsPi1)


                sqlOpt = "Select * from OPT"
                DsOpt.Clear()
                DsOpt = LoadSQL(sqlOpt, "OPT")

                dsNewRow = DsOpt.Tables("OPT").NewRow
                With dsNewRow
                    .Item("PAWNTICKET") = MigPt
                    .Item("PawnItemID") = GetLastID()
                End With
                DsOpt.Tables("OPT").Rows.Add(dsNewRow)
                database.SaveEntry(DsOpt)
            End If



            pbProgressBar.Value = pbProgressBar.Value + 1
            Application.DoEvents()
            lblPercent.Text = String.Format("{0}%", ((pbProgressBar.Value / pbProgressBar.Maximum) * 100).ToString("F2"))

        Next
        If MsgBox("Successful", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, _
             "Migrating...") = MsgBoxResult.Ok Then pbProgressBar.Maximum = 0
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical)
        'End Try
    End Sub

    Enum ItemClass As Integer
        ID = 0
        Name = 1
    End Enum

    Private Function GetClass(ByVal Item As String, ByVal TYPE As ItemClass)
        Dim strItem As String, mysql As String, ds As DataSet
        If Item = "HOME APP-SMALL" Then
            strItem = "HOME APPLIANCES"
        ElseIf Item = "MOTORCYCLE" Then
            strItem = "MOTOR"
        ElseIf Item = "HOME APP-BIG" Then
            strItem = "BIG APPLIANCES"
        ElseIf Item = "CAMERA" Then
            strItem = "COMPACT CAMERA"
        Else
            strItem = Item
        End If
        mysql = "Select * from tblItem where ItemCLass = '" & strItem & "'"
        ds = LoadSQL(mysql, "tblItem")
        Select Case TYPE
            Case ItemClass.ID
                Return ds.Tables(0).Rows(0).Item("ItemID")

            Case ItemClass.Name
                Return ds.Tables(0).Rows(0).Item("ItemClass")

        End Select
        Return strItem
    End Function

    Private Function GetLastID() As Single
        Dim mySql As String = "SELECT * FROM OPI ORDER BY PawnItemID DESC"
        Dim ds As DataSet = LoadSQL(mySql)

        If ds.Tables(0).Rows.Count = 0 Then
            Return 0
        End If
        Return ds.Tables(0).Rows(0).Item("PawnItemID")
    End Function

    Private Function GetInt(ByVal ItemType As String, ByVal CheckSum As String)

        Dim mySql As String = "Select * from tblint_history where checksum = '" & CheckSum & "' and itemtype = '" & ItemType & "' and dayfrom = '34'"
        Dim ds As DataSet = LoadSQL(mySql)

        If ds.Tables(0).Rows.Count = 0 Then
            Return 0
        End If
        Dim tmpInt As String = ds.Tables(0).Rows(0).Item("Interest")
        tmpInt = tmpInt / 2
        Return GetScheme(tmpInt, CheckSum, ItemType)

    End Function

    Private Function GetScheme(ByVal Int As String, ByVal checksum As String, ByVal ItemType As String)
        Dim mySql As String = "Select * from tblint_history where checksum = '" & checksum & "' and Itemtype = '" & ItemType & "' Rows 1"
        Dim ds As DataSet = LoadSQL(mySql)
        Dim isEarlyRedeem As Boolean = False
        Dim tmpID As String

        If ds.Tables(0).Rows(0).Item("Remarks") = "Early Redemption" Then isEarlyRedeem = True
        If isEarlyRedeem = False Then

            If Int = "0.03" Then
                tmpID = 1
            ElseIf Int = "0.04" Then
                tmpID = 2
            ElseIf Int = "0.05" Then
                tmpID = 3
            ElseIf Int = "0.06" Then
                tmpID = 4
            ElseIf Int = "0.07" Then
                tmpID = 5
            End If
        ElseIf isEarlyRedeem = True Then

            If Int = "0.03" Then
                tmpID = 6
            ElseIf Int = "0.04" Then
                tmpID = 7
            ElseIf Int = "0.05" Then
                tmpID = 8
            ElseIf Int = "0.06" Then
                tmpID = 9
            ElseIf Int = "0.07" Then
                tmpID = 10
            End If
        Else
            tmpID = 99
        End If

        Return tmpID
    End Function

    Private Sub frmMigrate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            LoadPath()
            Dim mysql As String = "Select * from tblPawn"
            Dim filldata As String = "tblPawn"
            Dim ds As DataSet = LoadSQL(mysql, filldata)

            Dim tmpMax As Integer = ds.Tables(0).Rows.Count
            pbProgressBar.Minimum = 0
            pbProgressBar.Maximum = tmpMax
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnFix_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFix.Click
        UpdateScheme2()
    End Sub

    Private Sub LoadPath()
        Dim readValue = My.Computer.Registry.GetValue(
    "HKEY_LOCAL_MACHINE\Software\cdt-S0ft\Pawnshop", "InstallPath", Nothing)

        Dim firebird As String = readValue & DBPATH
        database.dbName = firebird
        txtData.Text = firebird
    End Sub
End Class