Module ItemClass_Seed
    Private ClassName As String() = {"NETBOOK", "NOTEBOOK", "BRACELET", "RING"}
    Private Category As String() = {"GADGET", "GADGET", "JEWELRY", "JEWELRY"}
    Private Desc As String() = {"PORTABLE COMPUTER", "PORTABLE COMPUTER", "A JEWELRY", "A JEWELRY"}
    Private isRenew As Boolean() = {True, True, True, True}
    Private layout As String() = {"[ClassName] [serial]" & vbCrLf & "[desc]", "[ClassName] [serial]" & vbCrLf & "[desc]", "1 [ClassName] [G] [K:ENCRYPTED]", "1 [ClassName] [G] [K:ENCRYPTED]"}
    Private Interest As Double() = {0.04, 0.04, 0.03, 0.03}

    Public Sub Populate()

        Dim shortCodes As String()
        Dim specsName As String()
        Dim specsType As String()
        Dim specsLayout As String()
        Dim isReq As Boolean()

        For i As Integer = 0 To ClassName.Length - 1

            Dim tmpClass As New ItemClass
            With tmpClass
                .ItemClass = ClassName(i)
                .Category = Category(i)
                .Description = Desc(i)
                .isRenewable = isRenew(i)
                .PrintLayout = layout(i)
                .InterestRate = Interest(i)
            End With

            Select Case ClassName(i).ToUpper
                Case "NETBOOK"
                    shortCodes = {"serial", "desc"}
                    specsName = {"Serial", "Description"}
                    specsType = {"String", "String"}
                    specsLayout = {"TextBox", "MultiLine"}
                    isReq = {True, True}
                Case "NOTEBOOK"
                    shortCodes = {"serial", "desc"}
                    specsName = {"Serial", "Description"}
                    specsType = {"String", "String"}
                    specsLayout = {"TextBox", "MultiLine"}
                    isReq = {True, True}
                Case "BRACELET"
                    shortCodes = {"G", "K", "desc"}
                    specsName = {"Grams", "Karat", "Description"}
                    specsType = {"Double", "String", "String"}
                    specsLayout = {"TextBox", "Karat", "MultiLine"}
                    isReq = {True, True, False}
                Case "RING"
                    shortCodes = {"G", "K", "desc"}
                    specsName = {"Grams", "Karat", "Description"}
                    specsType = {"Double", "String", "String"}
                    specsLayout = {"TextBox", "Karat", "MultiLine"}
                    isReq = {True, True, False}
                Case Else
                    shortCodes = {}
                    specsName = {}
                    specsType = {}
                    specsLayout = {}
                    isReq = {}
            End Select

            Dim tmpSpecs As New CollectionItemSpecs
            For cnt As Integer = 0 To shortCodes.Length - 1

                Dim tmpSpec As New ItemSpecs
                With tmpSpec
                    .ShortCode = shortCodes(cnt)
                    .SpecName = specsName(cnt)
                    .SpecType = specsType(cnt)
                    .SpecLayout = specsLayout(cnt)
                    .isRequired = isReq(cnt)
                End With
                tmpSpecs.Add(tmpSpec)

            Next

            tmpClass.ItemSpecifications = tmpSpecs
            tmpClass.SaveItem()
        Next

    End Sub
End Module