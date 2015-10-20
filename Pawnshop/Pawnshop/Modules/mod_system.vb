Module mod_system

    ''' <summary>
    ''' Function use to input only numbers
    ''' </summary>
    ''' <param name="e">Keypress Event</param>
    ''' <remarks>Use the Keypress Event when calling this function</remarks>
    Friend Function DigitOnly(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar <> ControlChars.Back Then
            e.Handled = Not (Char.IsDigit(e.KeyChar))
        End If
        Return Not (Char.IsDigit(e.KeyChar))
    End Function

    Friend Function DreadKnight(ByVal str As String, Optional ByVal special As String = Nothing) As String
        str = str.Replace("'", "\'")
        str = str.Replace("""", "\""")

        If special <> Nothing Then
            str = str.Replace(special, "")
        End If

        Return str
    End Function
End Module
