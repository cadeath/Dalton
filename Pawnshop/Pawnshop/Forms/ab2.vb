Public NotInheritable Class ab2

    Private CREDITS As String

    Private Sub FullCredits()
        CREDITS = _
            vbCrLf & "BRANCHES: " & vbCrLf & _
"ROXAS - FROILYN" & vbCrLf & _
"JCAT - JEN" & vbCrLf & _
"PENDATUN - CAROL" & vbCrLf & _
"RELIEVER - ESTHER SINDOL" & vbCrLf & _
"RELIEVER - ANA LIEZEL VIGAFRIA" & vbCrLf & _
"***PRK MALAKAS - JOSE COLASTRE***" & vbCrLf
        CREDITS &= "===============" & vbCrLf & _
            "MIS:" & vbCrLf & _
            "JAYR, MAY2, FRANCES, JANDY, EMELYE" & vbCrLf & _
            "==================" & vbCrLf & _
            "SPECIAL THANKS TO" & vbCrLf & _
            "SIR DENNIS LARIBA, CPA" & vbCrLf & _
            "ALL RIGHTS RESERVED 2016"
        CREDITS &= vbCrLf & "=================="
        CREDITS &= vbCrLf & "DEVELOPER:"
        CREDITS &= vbCrLf & "JUNMAR, ELLIE"
        CREDITS &= vbCrLf & ""
        CREDITS &= vbCrLf & "DATABASE VERSION: " & DBVERSION
    End Sub

    Private Sub ab2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FullCredits()
        ' Set the title of the form.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("About {0}", ApplicationTitle)
        ' Initialize all of the text displayed on the About Box.
        ' TODO: Customize the application's assembly information in the "Application" pane of the project 
        '    properties dialog (under the "Project" menu).
        Me.LabelProductName.Text = My.Application.Info.ProductName
        Me.LabelVersion.Text = String.Format("Version {0}", My.Application.Info.Version.ToString)
        Me.LabelCopyright.Text = My.Application.Info.Copyright
        Me.LabelCompanyName.Text = My.Application.Info.CompanyName
        Me.TextBoxDescription.Text = My.Application.Info.Description & CREDITS
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class