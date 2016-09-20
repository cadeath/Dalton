Module Scheme_Load

    Sub Load_Scheme()

        Dim schemeName As String() = {"3% Interest", "3% with Early Redemption"}
        Dim description As String() = {"3%", "early redeem"}

        Dim schemeID_01 As Integer() = {1, 1}
        Dim dayFrom_01 As Integer() = {1, 34}
        Dim dayTo_01 As Integer() = {33, 64}
        Dim int_01 As Double() = {0.03, 0.06}
        Dim pen_01 As Double() = {0, 0.02}
        Dim remarks_01 As String() = {"3% Interest, 0 penalty", "6% Interest, 2% penalty"}

    End Sub

End Module
