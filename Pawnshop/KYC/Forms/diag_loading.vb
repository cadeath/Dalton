Imports System.Threading

Public Class diag_loading

    Friend Sub Set_Bar(ByVal val As Integer)
        pbLoading.Maximum = val
    End Sub

    Friend Sub Reset_Bar()
        pbLoading.Value = 0
    End Sub

    Friend Sub Add_Bar()
        Dim th As Thread
        th = New Thread(AddressOf addBar)
        th.Start()
    End Sub

    Private Delegate Sub addBar_callback()
    Private Sub addBar()
        If pbLoading.InvokeRequired Then
            pbLoading.Invoke(New addBar_callback(AddressOf addBar))
        Else
            If pbLoading.Value < pbLoading.Maximum Then
                pbLoading.Value += 1
            End If
        End If
    End Sub

    Private Sub diag_loading_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TopMost = True
      
      
    End Sub

    Private Sub diag_loading_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Click
        Set_Bar(1000)
        Reset_Bar()
        For i As Integer = 0 To 1000
            Add_Bar()
        Next
    End Sub
End Class