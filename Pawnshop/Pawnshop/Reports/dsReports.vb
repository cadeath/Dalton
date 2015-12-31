Partial Class dsReports
    Partial Class dsCCcoinsDataTable

        Private Sub dsCCcoinsDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.DenominationColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

End Class
