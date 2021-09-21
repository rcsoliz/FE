Public Class clsDatosAcceso : Inherits BaseDatos

#Region "[atributosGlobales]"

#End Region

#Region "[contrutor]"

    Protected Sub New(ByVal usuar As String, ByVal clav As String)
        MyBase.New()
        Call abrir_coneccion(usuar, clav)
    End Sub

#End Region

#Region "[metodos]"

    Public Function getAcceso(ByVal usuar As String, ByVal clav As String) As Boolean
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = Libreria.LibAcceso.getAcceso(usuar)
                comando.CommandText = consulta
                conector.Fill(dt)
                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows(0).Item("usrlogin")) Then
                        Return True
                    End If
                End If
            Catch ex As Exception
                set_error("Fallo en clsParFactura:: getAcceso " & consulta, ex.Message)
            End Try
            Return False
        End Using
    End Function

#End Region

End Class
