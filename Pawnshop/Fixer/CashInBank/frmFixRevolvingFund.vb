Public Class frmFixRevolvingFund
    Const DBPATH As String = "\W3W1LH4CKU.FDB"
    Private AccountCode As String = String.Empty

    Private Sub btnFix_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFix.Click
        Disable(1)
        Try
            FixRevolvingFund()

            MsgBox("Account Code: " & AccountCode & " Succesful Updated", MsgBoxStyle.Information, "System")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "E R R O R")
        End Try
        Disable(0)
    End Sub

    Private Sub Disable(ByVal st As Boolean)
        btnFix.Enabled = Not st
    End Sub

    Private Sub LoadPath()
        Dim readValue = My.Computer.Registry.GetValue(
    "HKEY_LOCAL_MACHINE\Software\cdt-S0ft\Pawnshop", "InstallPath", Nothing)

        Dim firebird As String = readValue & DBPATH
        database.dbName = firebird
        txtData.Text = firebird
    End Sub

    Private Sub frmFixRevolvingFund_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadPath()
    End Sub

    Private Sub FixRevolvingFund()
        Dim Branch As String = GetOption("BranchCode")

        Select Case Branch
            Case "AL1"
                AccountCode = "_SYS00000000054"
            Case "AL2"
                AccountCode = "_SYS00000000055"
            Case "CAG"
                AccountCode = "_SYS00000000059"
            Case "CO1"
                AccountCode = "_SYS00000000061"
            Case "CO2"
                AccountCode = "_SYS00000000062"
            Case "CO3"
                AccountCode = "_SYS00000000063"
            Case "CO4"
                AccountCode = "_SYS00000000064"
            Case "DI1"
                AccountCode = "_SYS00000000065"
            Case "DI2"
                AccountCode = "_SYS00000000066"
            Case "GAM"
                AccountCode = "_SYS00000000067"
            Case "GAI"
                AccountCode = "_SYS00000000068"
            Case "GLA"
                AccountCode = "_SYS00000000069"
            Case "ISU"
                AccountCode = "_SYS00000000070"
            Case "IS2"
                AccountCode = "_SYS00000000071"
            Case "JCA"
                AccountCode = "_SYS00000000072"
            Case "TAC"
                AccountCode = "_SYS00000000092"
            Case "TC2"
                AccountCode = "_SYS00000000074"
            Case "PIK"
                AccountCode = "_SYS00000000077"
            Case "KAB"
                AccountCode = "_SYS00000000079"
            Case "KIA"
                AccountCode = "_SYS00000000080"
            Case "KID"
                AccountCode = "_SYS00000000081"
            Case "MID"
                AccountCode = "_SYS00000000082"
            Case "PEN"
                AccountCode = "_SYS00000000083"
            Case "PIO"
                AccountCode = "_SYS00000000084"
            Case "PMA"
                AccountCode = "_SYS00000000085"
            Case "POL"
                AccountCode = "_SYS00000000086"
            Case "ROG"
                AccountCode = "_SYS00000000087"
            Case "ROX"
                AccountCode = "_SYS00000000088"
            Case "SNP"
                AccountCode = "_SYS00000000089"
            Case "SRA"
                AccountCode = "_SYS00000000090"
            Case "SUR"
                AccountCode = "_SYS00000000091"
            Case "ACE"
                AccountCode = "_SYS00000000093"
            Case "UHA"
                AccountCode = "_SYS00000000094"
            Case "GAK"
                AccountCode = "_SYS00000000680"
            Case "GAP"
                AccountCode = "_SYS00000000681"
            Case "PGN"
                AccountCode = "_SYS00000000784"
            Case "ESP"
                AccountCode = "_SYS00000000880"
            Case "LEB"
                AccountCode = "_SYS00000000947"
            Case "KAL"
                AccountCode = "_SYS00000000948"
            Case "MAI"
                AccountCode = "_SYS00000000997"
            Case "MLA"
                AccountCode = "_SYS00000001064"
            Case "SHA"
                AccountCode = "_SYS00000001079"
            Case "AWA"
                AccountCode = "_SYS00000001080"
            Case "MAL"
                AccountCode = "_SYS00000001111"
            Case "SUB"
                AccountCode = "_SYS00000001122"
            Case Else
                MsgBox(Branch & " Not Found!", MsgBoxStyle.Critical, "ERROR PLEASE CONTACT MIS Dept") : Exit Sub
        End Select

        InsertSAPCount(AccountCode)
    End Sub

    Private Sub InsertSAPCount(ByVal SAPCode As String)
        Dim mySql As String = "SELECT * FROM tblCash WHERE TRANSNAME = 'Revolving Fund'"
        Dim fillData As String = "tblCash"
        Dim ds As DataSet = LoadSQL(mySql, fillData)
        ds.Tables(0).Rows(0).Item("SAPACCOUNT") = SAPCode
        database.SaveEntry(ds, False)

        Console.WriteLine("Revolving Fund Added")
    End Sub
End Class