Module Client_Seed

    Private FirstName() As String = {"Eskie Cirrus", "James", "Eskie Sirius"}
    Private MaidenName() As String = {"Dingal", "", "Dingal"}
    Private LastName() As String = {"Maquilang", "Fearful", "Maquilang"}
    Private Brgy() As String = {"Lagao", "", "Ambot"}
    Private Cities() As String = {"General Santos City", "Davao City", "Cebu City"}
    Private Birthday() As Date = {#11/7/1986#, #10/1/1990#, #5/17/1990#}

    Sub Populate()
        For i As Integer = 0 To FirstName.Count - 1

            Dim newClient As New Client
            With newClient
                .FirstName = FirstName(i)
                .MiddleName = MaidenName(i)
                .LastName = LastName(i)
                .AddressBrgy = Brgy(i)
                .AddressCity = Cities(i)
                .Birthday = Birthday(i)

                .SaveClient()
            End With
        Next
    End Sub

End Module
