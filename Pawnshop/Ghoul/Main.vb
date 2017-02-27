Module Main

    Public DIS_FOLDER As String

    Sub Main()
        Initialization()

        MrFaust.CheckList()
        'cmdFunctions.do_ccSave(#2/1/2017#)
    End Sub

    Private Sub Initialization()
        DIS_FOLDER = LoadPath()
        database.dbName = DIS_FOLDER & "\W3W1LH4CKU.FDB"
        'database.dbName = "F:\cadeath\Desktop\Migration\DALTON\B4\SHA\W3W1LH4CKU.FDB"
    End Sub

    ''' <summary>
    ''' Load the default InstallPath of DIS
    ''' </summary>
    ''' <returns>String</returns>
    ''' <remarks></remarks>
    Private Function LoadPath() As String
        Dim readValue = My.Computer.Registry.GetValue(
    "HKEY_LOCAL_MACHINE\Software\cdt-S0ft\Pawnshop", "InstallPath", Nothing)

        Return readValue
    End Function
End Module
