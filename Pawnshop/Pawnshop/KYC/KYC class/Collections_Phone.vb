Public Class Collections_Phone
    Inherits System.Collections.CollectionBase

    Public ReadOnly Property Item(ByVal index As Integer) As PhoneNumber
        Get
            ' The appropriate item is retrieved from the List object and 
            ' explicitly cast to the Widget type, then returned to the 
            ' caller.
            Return CType(List.Item(index), PhoneNumber)
        End Get
    End Property

    Public Sub Add(ByVal IDCard As PhoneNumber)
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

    Public ReadOnly Property byID(id As Integer) As PhoneNumber
        Get
            For Each cp As PhoneNumber In Me.List
                If cp.PhoneID = id Then
                    Return cp
                End If
            Next

            Return Nothing
        End Get
    End Property
End Class
