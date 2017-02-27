Imports System.Windows.Forms

Public Class frmGhoul

    Private Sub frmGhoul_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Minimized

        Main.Main()
    End Sub

    Private Sub frmGhoul_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        If Me.WindowState = FormWindowState.Minimized Then
            Me.WindowState = FormWindowState.Minimized
            Me.Visible = False
            Me.ni.Visible = True
        End If
    End Sub

    Private Sub ni_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ni.Click
        Me.Visible = True
        Me.WindowState = FormWindowState.Normal
        Me.ni.Visible = False
    End Sub
End Class