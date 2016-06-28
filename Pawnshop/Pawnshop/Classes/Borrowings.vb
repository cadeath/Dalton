Public Class Borrowings

    Private fillData As String = "tblBorrow"
    Private mySql As String = String.Empty

#Region "Variables"
    Private _borrowID As Integer
    Public Property BorrowID() As Integer
        Get
            Return _borrowID
        End Get
        Set(ByVal value As Integer)
            _borrowID = value
        End Set
    End Property

    Private _refNum As String
    Public Property ReferenceNumber() As String
        Get
            Return _refNum
        End Get
        Set(ByVal value As String)
            _refNum = value
        End Set
    End Property

    Private _transDate As Date
    Public Property TransactionDate() As Date
        Get
            Return _transDate
        End Get
        Set(ByVal value As Date)
            _transDate = value
        End Set
    End Property

    Private _branchCode As String
    Public Property BranchCode() As String
        Get
            Return _branchCode
        End Get
        Set(ByVal value As String)
            _branchCode = value
        End Set
    End Property

    Private _branchName As String
    Public Property BranchName() As String
        Get
            Return _branchName
        End Get
        Set(ByVal value As String)
            _branchName = value
        End Set
    End Property

    Private _amount As Double
    Public Property Amount() As Double
        Get
            Return _amount
        End Get
        Set(ByVal value As Double)
            _amount = value
        End Set
    End Property

    Private _remarks As String
    Public Property Remarks() As String
        Get
            Return _remarks
        End Get
        Set(ByVal value As String)
            _remarks = value
        End Set
    End Property

    Private _status As String
    Public Property Status() As String
        Get
            Return _status
        End Get
        Set(ByVal value As String)
            _status = value
        End Set
    End Property

    Private _encoderID As String
    Public Property EncoderID() As String
        Get
            Return _encoderID
        End Get
        Set(ByVal value As String)
            _encoderID = value
        End Set
    End Property
#End Region

#Region "Procedure"
    Public Sub SaveBorrowings()
        mySql = "SELECT * FROM " & fillData
        Dim ds As DataSet = LoadSQL(mySql, fillData)

        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(fillData).NewRow
        With dsNewRow
            .Item("RefNum") = _refNum
            .Item("TransDate") = _transDate
            .Item("BranchCode") = _branchCode
            .Item("BranchName") = _branchName
            .Item("Amount") = _amount
            .Item("Remarks") = _remarks
            .Item("Status") = _status
            .Item("EncoderID") = _encoderID
            .Item("SystemInfo") = Now
        End With
        ds.Tables(fillData).Rows.Add(dsNewRow)
        database.SaveEntry(ds)
    End Sub

    Public Sub LoadBorrow(ByVal id As Integer)
        mySql = "SELECT * FROM " & fillData & " WHERE BRWID = " & id
        Dim ds As DataSet = LoadSQL(mySql)

        For Each dr As DataRow In ds.Tables(0).Rows
            LoadBorrowByRow(dr)
        Next
    End Sub

    Public Sub LoadBorrowByRow(ByVal dr As DataRow)
        With dr
            _borrowID = .Item("BrwID")
            _refNum = .Item("RefNum")
            _transDate = .Item("TransDate")
            _branchCode = .Item("BranchCode")
            _branchName = .Item("BranchName")
            _amount = .Item("Amount")
            _remarks = .Item("Remarks")
            _status = .Item("Status")
            _encoderID = .Item("EncoderID")
        End With
        Console.WriteLine(String.Format("[loaded] Borrowing ID {0} loaded", _borrowID))
    End Sub

    Public Sub VoidBorrowings()
        mySql = "SELECT * FROM " & fillData & " WHERE brwID = " & _borrowID
        Dim ds As DataSet = LoadSQL(mySql, fillData)
        ds.Tables(0).Rows(0).Item("Status") = "V" & ds.Tables(0).Rows(0).Item("Status")
        Dim MoDName As String = "BORROWINGS"
        Dim BORROWINGID As Integer = frmBorrowBrowse.LBLBORROWINGID.Text
        database.SaveEntry(ds, False)

        RemoveJournal(transID:=BORROWINGID, TransType:=MoDName)
        RemoveDailyTimeLog(BORROWINGID, MoDName)
        Console.WriteLine(String.Format("Transaction {0} void.", _borrowID))
    End Sub

    Public Function LastIDNumber() As Single
        Dim mySql As String = "SELECT * FROM tblBorrow ORDER BY BrwID DESC"
        Dim ds As DataSet = LoadSQL(mySql)

        If ds.Tables(0).Rows.Count = 0 Then
            Return 0
        End If
        Return ds.Tables(0).Rows(0).Item("BrwID")
    End Function

#End Region
End Class