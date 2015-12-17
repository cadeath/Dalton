Public Class frmExtractor
    Enum ExtractType As Integer
        Expiry = 0
        JournalEntry = 1
    End Enum
    Friend FormType As ExtractType = ExtractType.Expiry

    Private Sub txtPath_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPath.DoubleClick
        sfdPath.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        Dim result As DialogResult = sfdPath.ShowDialog

        If Not result = Windows.Forms.DialogResult.OK Then
            Return
        End If
        txtPath.Text = sfdPath.FileName
    End Sub

    Private Sub frmExtractor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FormInit()
        'Load Path
        txtPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
    End Sub

    Private Sub FormInit()
        Select Case FormType
            Case ExtractType.Expiry
                Console.WriteLine("Expiry Type Activated")
                sfdPath.FileName = String.Format("ROX{0}.xls", Now.ToString("MMddyyyy"))  'BranchCode + Date
                Me.Text &= " - Expiry"
            Case ExtractType.JournalEntry
                Console.WriteLine("Journal Entry Type Activated")
                sfdPath.FileName = String.Format("JRNL{0}ROX.xls", Now.ToString("yyyyMMdd")) 'JRNL + Date + BranchCode
                Me.Text &= " - Journal Entry"
        End Select
    End Sub

    Private Sub btnExtract_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExtract.Click

    End Sub

    Private Sub ExtractExpiry()
        Dim fillData As String = "tblPawn"
        Dim mySql As String = "SELECT * FROM " & fillData
        mySql &= ""
    End Sub

End Class