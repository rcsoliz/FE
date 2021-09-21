Public Class libControl

    Public Shared Sub limpiarTexto(ByRef form As Form)
        For Each ctrl In form.Controls
            If (TypeOf ctrl Is TextBox) Then
                ctrl.Text = String.Empty
                Continue For
            ElseIf (TypeOf ctrl Is MaskedTextBox) Then
                ctrl.Text = String.Empty
                Continue For
            ElseIf (TypeOf ctrl Is DataGridView) Then
                DirectCast(ctrl, DataGridView).DataSource = Nothing
                Continue For
            ElseIf (TypeOf ctrl Is ListBox) Then
                DirectCast(ctrl, ListBox).Items.Clear()
                Continue For
            End If
        Next
    End Sub

End Class
