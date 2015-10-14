Public Class Client

#Region "Variables"
    Enum Gender As Integer : Male = 1 : Female = 0 : End Enum

    Private _firstName As String = String.Empty
    Private _middleName As String = String.Empty
    Private _lastName As String = String.Empty
    Private _suffixName As String = String.Empty

    Private _addrSt As String = String.Empty
    Private _addrBrgy As String = String.Empty
    Private _addrCity As String = String.Empty
    Private _addrProvince As String = String.Empty
    Private _addrZip As String = String.Empty

    Private _gender As Gender = Gender.Male
    Private _bday As Date

    Private _cp1 As String = String.Empty
    Private _cp2 As String = String.Empty
    Private _phone As String = String.Empty
    Private _otherNum As String = String.Empty
#End Region

#Region "Properties"
    Public Property FirstName As String
        Set(ByVal value As String)
            _firstName = value
        End Set
        Get
            Return _firstName
        End Get
    End Property
#End Region
End Class
