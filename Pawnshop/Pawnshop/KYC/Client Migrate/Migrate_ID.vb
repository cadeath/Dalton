Public Class Migrate_ID
    Inherits System.Collections.CollectionBase

    Public ReadOnly Property Item(ByVal index As Integer) As MigrateIdentificationCard
        Get
            ' The appropriate item is retrieved from the List object and 
            ' explicitly cast to the Widget type, then returned to the 
            ' caller.
            Return CType(List.Item(index), MigrateIdentificationCard)
        End Get
    End Property

    Public Sub Add(ByVal IDCard As MigrateIdentificationCard)
        ' Invokes Add method of the List object to add a widget.
        List.Add(IDCard)
    End Sub

    Public Sub Remove(ByVal index As Integer)
        ' Check to see if there is a widget at the supplied index.
        If index > Count - 1 Or index < 0 Then
            ' If no widget exists, a messagebox is shown and the operation is 
            ' cancelled.
            System.Windows.Forms.MessageBox.Show("Index not valid!")
        Else
            ' Invokes the RemoveAt method of the List object.
            List.RemoveAt(index)
        End If
    End Sub

    Public ReadOnly Property byID(ByVal id As Integer) As MigrateIdentificationCard
        Get
            For Each CustID As MigrateIdentificationCard In Me.List
                If CustID.ID = id Then
                    Return CustID
                End If
            Next

            Return Nothing
        End Get
    End Property
End Class