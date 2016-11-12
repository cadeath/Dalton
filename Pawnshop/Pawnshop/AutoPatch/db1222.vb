Module db1222
    ''' <summary>
    ''' Modify Table tblPawn to include RENEWAL COUNTER
    ''' Modify Table tblClass to include RENEWAL COUNTER
    ''' </summary>
    ''' <remarks>Database Patch for tblPawn</remarks>
    Const ALLOWABLE_VERSION As String = "1.2.2.1"
    Const LATEST_VERSION As String = "1.2.2.2"

    Sub PatchUp()
        If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub

        Try

            Dim strBracket As String
            strBracket = "ALTER TABLE TBLMONEYTRANSFER ADD BRACKET NUMERIC(12, 2);"

            Dim strWestern As String
            strWestern = "update TBLMONEYTRANSFER set bracket = "
            strWestern &= "( SELECT C.AMOUNT AS BRACKET FROM TBLCHARGE C WHERE TBLMONEYTRANSFER.AMOUNT <= C.AMOUNT AND "
            strWestern &= "C.TYPE = 'western' ORDER BY C.AMOUNT ASC ROWS 1) "
            strWestern &= "WHERE TBLMONEYTRANSFER.SERVICETYPE = 'Western Union - Local'"

            Dim strWesternInlt As String
            strWesternInlt = "update TBLMONEYTRANSFER set bracket = "
            strWesternInlt &= "( SELECT C.AMOUNT AS BRACKET FROM TBLCHARGE C WHERE TBLMONEYTRANSFER.AMOUNT <= C.AMOUNT AND "
            strWesternInlt &= "C.TYPE = 'western - intl' ORDER BY C.AMOUNT ASC ROWS 1) "
            strWesternInlt &= "WHERE TBLMONEYTRANSFER.SERVICETYPE = 'Western Union - Intl'"

            Dim strPeraPadala As String
            strPeraPadala = "update TBLMONEYTRANSFER set bracket = "
            strPeraPadala &= "( SELECT C.AMOUNT AS BRACKET FROM TBLCHARGE C WHERE TBLMONEYTRANSFER.AMOUNT <= C.AMOUNT AND "
            strPeraPadala &= "C.TYPE = 'perapadala' ORDER BY C.AMOUNT ASC ROWS 1) "
            strPeraPadala &= "WHERE TBLMONEYTRANSFER.SERVICETYPE = 'Pera Padala'"

            Dim strPeraPadalaPmftc As String
            strPeraPadalaPmftc = "update TBLMONEYTRANSFER set bracket = "
            strPeraPadalaPmftc &= "( SELECT C.AMOUNT AS BRACKET FROM TBLCHARGE C WHERE TBLMONEYTRANSFER.AMOUNT <= C.AMOUNT AND "
            strPeraPadalaPmftc &= "C.TYPE = 'perapadalapmftc' ORDER BY C.AMOUNT ASC ROWS 1) "
            strPeraPadalaPmftc &= "WHERE TBLMONEYTRANSFER.SERVICETYPE = 'Pera Padala - PMFTC'"

            Dim strCebuana As String
            strCebuana = "update TBLMONEYTRANSFER set bracket = "
            strCebuana &= "( SELECT C.AMOUNT AS BRACKET FROM TBLCHARGE C WHERE TBLMONEYTRANSFER.AMOUNT <= C.AMOUNT AND "
            strCebuana &= "C.TYPE = 'cebuana' ORDER BY C.AMOUNT ASC ROWS 1) "
            strCebuana &= "WHERE TBLMONEYTRANSFER.SERVICETYPE = 'Cebuana Llhuiller'"

            Dim strGprs2Gprs As String
            strGprs2Gprs = "update TBLMONEYTRANSFER set bracket = "
            strGprs2Gprs &= "( SELECT C.AMOUNT AS BRACKET FROM TBLCHARGE C WHERE TBLMONEYTRANSFER.AMOUNT <= C.AMOUNT AND "
            strGprs2Gprs &= "C.TYPE = 'gprs to gprs' ORDER BY C.AMOUNT ASC ROWS 1) "
            strGprs2Gprs &= "WHERE TBLMONEYTRANSFER.SERVICETYPE = 'GPRS - GPRS to GPRS'"

            Dim strGprs2SmartMoney As String
            strGprs2SmartMoney = "update TBLMONEYTRANSFER set bracket = "
            strGprs2SmartMoney &= "( SELECT C.AMOUNT AS BRACKET FROM TBLCHARGE C WHERE TBLMONEYTRANSFER.AMOUNT <= C.AMOUNT AND "
            strGprs2SmartMoney &= "C.TYPE = 'gprs to smartmoney' ORDER BY C.AMOUNT ASC ROWS 1) "
            strGprs2SmartMoney &= "WHERE TBLMONEYTRANSFER.SERVICETYPE = 'GPRS - GPRS to Smart Money'"

            Dim strGprs2UCPBPNB As String
            strGprs2UCPBPNB = "update TBLMONEYTRANSFER set bracket = "
            strGprs2UCPBPNB &= "( SELECT C.AMOUNT AS BRACKET FROM TBLCHARGE C WHERE TBLMONEYTRANSFER.AMOUNT <= C.AMOUNT AND "
            strGprs2UCPBPNB &= "C.TYPE = 'gprs to bank-ucpbpnb' ORDER BY C.AMOUNT ASC ROWS 1) "
            strGprs2UCPBPNB &= "WHERE TBLMONEYTRANSFER.SERVICETYPE = 'GPRS - GPRS to BANK (UCPB/PNB)'"

            Dim strGprs2BDOChina As String
            strGprs2BDOChina = "update TBLMONEYTRANSFER set bracket = "
            strGprs2BDOChina &= "( SELECT C.AMOUNT AS BRACKET FROM TBLCHARGE C WHERE TBLMONEYTRANSFER.AMOUNT <= C.AMOUNT AND "
            strGprs2BDOChina &= "C.TYPE = 'gprs to bank-bdochina' ORDER BY C.AMOUNT ASC ROWS 1) "
            strGprs2BDOChina &= "WHERE TBLMONEYTRANSFER.SERVICETYPE = 'GPRS - GPRS to BANK (BDO/Chinabank)'"

            Dim strGprs2BankDBP As String
            strGprs2BankDBP = "update TBLMONEYTRANSFER set bracket = "
            strGprs2BankDBP &= "( SELECT C.AMOUNT AS BRACKET FROM TBLCHARGE C WHERE TBLMONEYTRANSFER.AMOUNT <= C.AMOUNT AND "
            strGprs2BankDBP &= "C.TYPE = 'gprs to dbp' ORDER BY C.AMOUNT ASC ROWS 1) "
            strGprs2BankDBP &= "WHERE TBLMONEYTRANSFER.SERVICETYPE = 'GPRS - GPRS to BANK (DBP)'"

            Dim strGprs2BankMetro As String
            strGprs2BankMetro = "update TBLMONEYTRANSFER set bracket = "
            strGprs2BankMetro &= "( SELECT C.AMOUNT AS BRACKET FROM TBLCHARGE C WHERE TBLMONEYTRANSFER.AMOUNT <= C.AMOUNT AND "
            strGprs2BankMetro &= "C.TYPE = 'gprs to metrobank' ORDER BY C.AMOUNT ASC ROWS 1) "
            strGprs2BankMetro &= "WHERE TBLMONEYTRANSFER.SERVICETYPE = 'GPRS - GPRS to BANK (MetroBank)'"

            Dim strGprs2MayLandBank As String
            strGprs2MayLandBank = "update TBLMONEYTRANSFER set bracket = "
            strGprs2MayLandBank &= "( SELECT C.AMOUNT AS BRACKET FROM TBLCHARGE C WHERE TBLMONEYTRANSFER.AMOUNT <= C.AMOUNT AND "
            strGprs2MayLandBank &= "C.TYPE = 'gprs to maylandbank' ORDER BY C.AMOUNT ASC ROWS 1) "
            strGprs2MayLandBank &= "WHERE TBLMONEYTRANSFER.SERVICETYPE = 'GPRS - GPRS to BANK (Maybank/LandBank)'"

            Dim strGprs2iRemit As String
            strGprs2iRemit = "update TBLMONEYTRANSFER set bracket = "
            strGprs2iRemit &= "( SELECT C.AMOUNT AS BRACKET FROM TBLCHARGE C WHERE TBLMONEYTRANSFER.AMOUNT <= C.AMOUNT AND "
            strGprs2iRemit &= "C.TYPE = 'iremit to gprs' ORDER BY C.AMOUNT ASC ROWS 1) "
            strGprs2iRemit &= "WHERE TBLMONEYTRANSFER.SERVICETYPE = 'GPRS - iREMIT to GPRS'"

            Dim strGprs2Transfast As String
            strGprs2Transfast = "update TBLMONEYTRANSFER set bracket = "
            strGprs2Transfast &= "( SELECT C.AMOUNT AS BRACKET FROM TBLCHARGE C WHERE TBLMONEYTRANSFER.AMOUNT <= C.AMOUNT AND "
            strGprs2Transfast &= "C.TYPE = 'nybptransfast to gprs' ORDER BY C.AMOUNT ASC ROWS 1) "
            strGprs2Transfast &= "WHERE TBLMONEYTRANSFER.SERVICETYPE = 'GPRS - NYBP/Transfast to GPRS'"

            Dim strGprs2Moneygram As String
            strGprs2Moneygram = "update TBLMONEYTRANSFER set bracket = "
            strGprs2Moneygram &= "( SELECT C.AMOUNT AS BRACKET FROM TBLCHARGE C WHERE TBLMONEYTRANSFER.AMOUNT <= C.AMOUNT AND "
            strGprs2Moneygram &= "C.TYPE = 'gprs to moneygram' ORDER BY C.AMOUNT ASC ROWS 1) "
            strGprs2Moneygram &= "WHERE TBLMONEYTRANSFER.SERVICETYPE = 'GPRS - GPRS to Moneygram'"

            


            RunCommand(strBracket)
            RunCommand(strWestern)
            RunCommand(strWesternInlt)
            RunCommand(strPeraPadala)
            RunCommand(strPeraPadalaPmftc)
            RunCommand(strCebuana)
            RunCommand(strGprs2Gprs)
            RunCommand(strGprs2SmartMoney)
            RunCommand(strGprs2UCPBPNB)
            RunCommand(strGprs2BDOChina)
            RunCommand(strGprs2BankDBP)
            RunCommand(strGprs2BankMetro)
            RunCommand(strGprs2MayLandBank)
            RunCommand(strGprs2iRemit)
            RunCommand(strGprs2Transfast)
            RunCommand(strGprs2Moneygram)


            '    Database_Update(LATEST_VERSION)
            '    Log_Report("SYSTEM PATCHED UP FROM 1.2.2.1 TO 1.2.2.2")
            'Catch ex As Exception
            '    Log_Report("[1.2.2.2]" & ex.ToString)

            Dim mySql As String = "ALTER TABLE TBLPAWN ADD RENEWALCNT SMALLINT DEFAULT '0' NOT NULL;"
            RunCommand(mySql) 'TBLPAWN RENEWAL COUNT

            mySql = "ALTER TABLE TBLCLASS ADD RENEWLIMIT SMALLINT DEFAULT '0' NOT NULL;"
            RunCommand(mySql) 'TBLCLASS RENEWAL LIMIT

            If DEV_MODE Then
                mySql = "UPDATE TBLCLASS SET RENEWABLE = 1, RENEWLIMIT = 5 WHERE TYPE='CEL'"
                RunCommand(mySql)
            End If

           

            Database_Update(LATEST_VERSION)
            Log_Report(String.Format("SYSTEM PATCHED UP FROM {0} TO {1}", ALLOWABLE_VERSION, LATEST_VERSION))
        Catch ex As Exception
            Log_Report(String.Format("[{0}]", LATEST_VERSION) & ex.ToString)

        End Try
    End Sub
End Module
