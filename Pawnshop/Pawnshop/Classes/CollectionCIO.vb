Public Class CollectionCIO
    Inherits System.Collections.CollectionBase

    Public ReadOnly Property Item(ByVal index As Integer) As CashInOutTransaction
        Get
            ' The appropriate item is retrieved from the List object and 
            ' explicitly cast to the Widget type, then returned to the 
            ' caller.
            Return CType(List.Item(index), CashInOutTransaction)
        End Get
    End Property

    Public Sub Add(ByVal cio As CashInOutTransaction)
        ' Invokes Add method of the List object to add a widget.
        List.Add(cio)
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
End Class
