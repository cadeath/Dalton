Module Scheme_Load

    Sub Load_Scheme_Data()

        Dim test_scheme As InterestScheme
        Dim tmpInt As Scheme_Interest
        Dim tmpDetails As IntScheme_Lines

        Dim schemeName As String() = {"3% Interest", "3% with Early Redemption"}
        Dim description As String() = {"3%", "early redeem"}

        Dim schemeID_01 As Integer() = {1, 1}
        Dim dayFrom_01 As Integer() = {1, 34}
        Dim dayTo_01 As Integer() = {33, 64}
        Dim int_01 As Double() = {0.03, 0.06}
        Dim pen_01 As Double() = {0, 0.02}
        Dim remarks_01 As String() = {"3% Interest, 0 penalty", "6% Interest, 2% penalty"}

        test_scheme = New InterestScheme
        test_scheme.SchemeName = schemeName(0)
        test_scheme.Description = description(0)

        tmpInt = New Scheme_Interest
        tmpDetails = New IntScheme_Lines
        tmpInt.DayFrom = dayFrom_01(0)
        tmpInt.DayTo = dayTo_01(0)
        tmpInt.Interest = int_01(0)
        tmpInt.Penalty = pen_01(0)
        tmpInt.Remarks = remarks_01(0)
        tmpDetails.Add(tmpInt)

        tmpInt = New Scheme_Interest
        tmpInt.DayFrom = dayFrom_01(1)
        tmpInt.DayTo = dayTo_01(1)
        tmpInt.Interest = int_01(1)
        tmpInt.Penalty = pen_01(1)
        tmpInt.Remarks = remarks_01(1)
        tmpDetails.Add(tmpInt)

        test_scheme.SchemeDetails = tmpDetails
        test_scheme.SaveScheme()

        Dim dayFrom_02 As Integer() = {1, 4}
        Dim dayTo_02 As Integer() = {3, 5}
        Dim int_02 As Double() = {0.01, 0.025}
        Dim pen_02 As Double() = {0, 0.0}
        Dim remarks_02 As String() = {"1% Interest Early Redeem", "2.5%"}

        test_scheme = New InterestScheme
        test_scheme.SchemeName = schemeName(1)
        test_scheme.Description = description(1)

        tmpInt = New Scheme_Interest
        tmpDetails = New IntScheme_Lines
        tmpInt.DayFrom = dayFrom_01(1)
        tmpInt.DayTo = dayTo_01(1)
        tmpInt.Interest = int_01(1)
        tmpInt.Penalty = pen_01(1)
        tmpInt.Remarks = remarks_01(1)
        tmpDetails.Add(tmpInt)

        test_scheme.SchemeDetails = tmpDetails
        test_scheme.SaveScheme()

    End Sub

End Module
