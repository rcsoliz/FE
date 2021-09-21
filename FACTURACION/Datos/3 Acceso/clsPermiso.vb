Public Class clsPermiso : Inherits BaseDatos

#Region "[constructor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String)
        MyBase.New()
        Call abrir_coneccion(usuar, clav)
    End Sub

    Protected Sub New(ByVal dtConexio As DataTable)
        MyBase.New()
        Call abrir_coneccion(dtConexio)
    End Sub

#End Region

#Region "[metodos]"

    Protected Function allowAcces(ByVal columna As String, ByVal login As String) As Boolean
        Using dt As New DataTable
            Dim bandera As Boolean = False
            Dim consulta As String = String.Empty
            Try
                consulta = Libreria.LibPermiso.allowAccesAlta(columna, login)
                comando.CommandText = consulta
                conector.Fill(dt)
                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows(0).Item(columna)) Then
                        Dim valor As String = Trim(dt.Rows(0).Item(columna))
                        If valor = "S" Then
                            bandera = True
                        End If
                    End If
                End If
            Catch ex As Exception
                set_error("Error clsPermiso:: allowAcces", ex.Message & vbNewLine & consulta)
            End Try
            Return bandera
        End Using
    End Function

    Protected Function allowAcces(ByVal columna As String, ByVal login As String, ByVal modulo As Integer, ByVal programa As Integer) As Boolean
        Using dt As New DataTable
            Dim bandera As Boolean = False
            Dim consulta As String = String.Empty
            Try
                consulta = Libreria.LibPermiso.allowAccesAlta(columna, login, modulo, programa)
                comando.CommandText = consulta
                conector.Fill(dt)
                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows(0).Item(columna)) Then
                        Dim valor As String = Trim(dt.Rows(0).Item(columna))
                        If valor = "S" Then
                            bandera = True
                        End If
                    End If
                End If
            Catch ex As Exception
                set_error("Error clsPermiso:: allowAcces", ex.Message & vbNewLine & consulta)
            End Try
            Return bandera
        End Using
    End Function

#End Region

End Class
