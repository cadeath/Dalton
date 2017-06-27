Public Class frmOpenStore

    Dim isDisable As Boolean = DEV_MODE
    Friend AccessType As String = ""

    Private Sub frmOpenStore_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMoney()

        Verification()
        Console.WriteLine("Initial: " & InitialBal)
        Console.WriteLine("Maintain: " & MaintainBal)
    End Sub

    Private Sub LoadMoney()
        txtMaintaining.Text = MaintainBal
        InitialBal = GetOption("CurrentBalance")
        Dim repDep As Double = InitialBal - MaintainBal
        txtRepDep.Text = CDbl(MaintainBal) - CDbl(InitialBal)
        txtMaintaining.Text = String.Format("P {0:#,##0.00}", CDbl(GetOption("MaintainingBalance")))
        txtInitial.Text = String.Format("P {0:#,##0.00}", InitialBal)
        If repDep < 0 Then txtRepDep.ForeColor = Color.Red
        txtRepDep.Text = String.Format("P {0:#,##0.00} ", Math.Abs(repDep)) & IIf(repDep > 0, "[Deposit]", "[Replenish]")
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetup.Click
        If Not isDisable Then If frmMainV2.dateSet Then MsgBox("Please execute closing", MsgBoxStyle.Critical) : Exit Sub
        Dim ans As DialogResult = _
            MsgBox("TODAY IS: " & vbCrLf & dtpCurrentDate.Value.ToString("MMM d, yyyy"), MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information, "Please CHECK")
        If Not ans = Windows.Forms.DialogResult.Yes Then
            Exit Sub
        End If

        If dtpCurrentDate.Value.ToShortDateString <> Now.Date.ToShortDateString Then
            ans = _
                MsgBox("It seems your SYSTEM DATE and CURRENT DATE didn't match" + vbCrLf + _
                       "Are you sure about this?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
            If ans = Windows.Forms.DialogResult.No Then Exit Sub
        End If

        CurrentDate = dtpCurrentDate.Value
        If isDisable Then
            frmMainV2.dateSet = True
            Me.Close()
            Exit Sub
        End If
        
        If mod_system.OpenStore() Then
            frmMainV2.dateSet = True
            dailyID = LoadLastOpening.Tables(0).Rows(0).Item("ID")

            AddTimelyLogs("OPENSTORE", String.Format("TIME IS {0} AND INITIAL IS Php {1:#,##0.00}", Now.ToShortTimeString, InitialBal), InitialBal, False, "OPEN BY " & SystemUser.FIRSTNAME & " " & SystemUser.LASTNAME, transid:=dailyID)
        Else
            Exit Sub
        End If

        If Not frmMainV2.dateSet Then
            ans = MsgBox("Do you want to execute backup procedure?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Daily Backup")
            If ans = Windows.Forms.DialogResult.Yes Then
                frmBackup.StartupExecute()
            End If
        End If

        Me.Close()

    End Sub

    Private Sub Verification()
        If AccessType = "Read Only" Then
            btnSetup.Enabled = False
        End If
    End Sub
End Class