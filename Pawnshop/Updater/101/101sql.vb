Module _101sql

    Sub Main()
        Change_LoanRegister_View()
        Developers_Note("Loan_Register updated.")

        Remove_Interest()
        Developers_Note("Interest Removed.")
    End Sub

    Private Sub Change_LoanRegister_View()
        Dim mySql As String

        'Phase 1
        mySql = "DROP VIEW LOAN_REGISTER"
        RunCommand(mySql)

        'Phase 2
        mySql = ""
        mySql &= "CREATE VIEW LOAN_REGISTER(" & vbCrLf
        mySql &= "  PAWNTICKET," & vbCrLf
        mySql &= "  PAWNER," & vbCrLf
        mySql &= "  ITEMTYPE," & vbCrLf
        mySql &= "  LOANDATE," & vbCrLf
        mySql &= "  MATUDATE," & vbCrLf
        mySql &= "  EXPIRYDATE," & vbCrLf
        mySql &= "  APPRAISAL," & vbCrLf
        mySql &= "  PRINCIPAL," & vbCrLf
        mySql &= "  INTEREST," & vbCrLf
        mySql &= "  SERVICECHARGE," & vbCrLf
        mySql &= "  NETAMOUNT," & vbCrLf
        mySql &= "  RENEWDUE," & vbCrLf
        mySql &= "  REDEEMDUE," & vbCrLf
        mySql &= "  ORDATE," & vbCrLf
        mySql &= "  USERNAME," & vbCrLf
        mySql &= "  STATUS)" & vbCrLf
        mySql &= "AS " & vbCrLf
        mySql &= "SELECT P.PawnTicket," & vbCrLf
        mySql &= "       C.FIRSTNAME || ' ' || C.LASTNAME AS PAWNER," & vbCrLf
        mySql &= "       P.ITEMTYPE," & vbCrLf
        mySql &= "       P.LOANDATE," & vbCrLf
        mySql &= "       P.MATUDATE," & vbCrLf
        mySql &= "       P.EXPIRYDATE," & vbCrLf
        mySql &= "       P.APPRAISAL," & vbCrLf
        mySql &= "       P.PRINCIPAL," & vbCrLf
        mySql &= "       P.INTEREST + P.ADVINT as INTEREST," & vbCrLf
        mySql &= "       P.SERVICECHARGE," & vbCrLf
        mySql &= "       P.NETAMOUNT," & vbCrLf
        mySql &= "       P.RENEWDUE," & vbCrLf 'RENEWDUE and REDEEMDUE 
        mySql &= "       P.REDEEMDUE," & vbCrLf
        mySql &= "       P.ORDATE," & vbCrLf
        mySql &= "       U.USERNAME," & vbCrLf
        mySql &= "       P.STATUS " & vbCrLf
        mySql &= "FROM tblPAWN P " & vbCrLf
        mySql &= "     INNER JOIN tblClient C on C.ClientID = P.ClientID" & vbCrLf
        mySql &= "     INNER JOIN tbl_Gamit U ON U.UserID = P.EncoderID;" & vbCrLf
        RunCommand(mySql)
    End Sub

    Private Sub Remove_Interest()
        Dim mySql As String
        mySql = "UPDATE tblPawn SET INTEREST = 0 WHERE STATUS = 'L'"
        RunCommand(mySql)
    End Sub
End Module
