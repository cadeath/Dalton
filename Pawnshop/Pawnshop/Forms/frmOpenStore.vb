Public Class frmOpenStore

    Dim isDisable As Boolean = DEV_MODE

    Private Sub frmOpenStore_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMoney()

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
        If Not isDisable Then If frmMain.dateSet Then MsgBox("Please execute closing", MsgBoxStyle.Critical) : Exit Sub
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
            frmMain.dateSet = True
            Me.Close()
            Exit Sub
        End If
        
        If mod_system.OpenStore() Then
            frmMain.dateSet = True
            dailyID = LoadLastOpening.Tables(0).Rows(0).Item("ID")

            AddTimelyLogs("OPENSTORE", String.Format("TIME IS {0} AND INITIAL IS Php {1:#,##0.00}", Now.ToShortTimeString, InitialBal), InitialBal, False, "OPEN BY " & POSuser.FullName, transid:=dailyID)
        Else
            Exit Sub
        End If

        If Not frmMain.dateSet Then
            ans = MsgBox("Do you want to execute backup procedure?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Daily Backup")
            If ans = Windows.Forms.DialogResult.Yes Then
                frmBackup.StartupExecute()
            End If
        End If

        Me.Close()

    End Sub
End Class