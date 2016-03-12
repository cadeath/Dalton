Module web_ads

    Private WithEvents _adsDisplay As WebBrowser
    Public Property AdsDisplay() As WebBrowser
        Get
            Return _adsDisplay
        End Get
        Set(ByVal value As WebBrowser)
            _adsDisplay = value
        End Set
    End Property


    Sub Ads_Initialization()
        Dim adsPath As String = "file:///" & Application.StartupPath() & "\ads.html"
        _adsDisplay.Visible = False
        _adsDisplay.Navigate(adsPath)
    End Sub

    Private Sub AdsDisplay_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles _adsDisplay.DocumentCompleted
        AdsDisplay.Visible = False
    End Sub

    Private Sub do_incognito()

    End Sub

End Module
