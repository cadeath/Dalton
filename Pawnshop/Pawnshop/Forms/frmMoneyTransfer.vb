Public Class frmMoneyTransfer

    Enum FormType As Integer
        Send = 1
        Receive = 0
    End Enum

    Private _formTrans As FormType

    Private Sub frmMoneyTransfer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FormInit(FormType.Send)
    End Sub

    Private Sub FormInit(ByVal transType As FormType)
        _formTrans = transType

        Select Case transType
            Case FormType.Send
                gpSend.Visible = True
                gpReceive.Visible = False
            Case FormType.Receive
                'gpSend.Visible = False
                gpReceive.Visible = True
        End Select
    End Sub

    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        FormInit(FormType.Send)
    End Sub

    Private Sub btnReceive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReceive.Click
        FormInit(FormType.Receive)
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        frmMTlist.Show()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class