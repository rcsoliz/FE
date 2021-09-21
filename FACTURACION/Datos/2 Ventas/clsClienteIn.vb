Imports Entidades
Imports Libreria
Public Class clsClienteIn : Inherits BaseDatos

#Region "[atributosGlobales]"

#End Region

#Region "[contrutor]"

    Protected Sub New(ByVal usuar As String, ByVal clav As String)
        MyBase.New()
        Call abrir_coneccion(usuar, clav)
    End Sub

    Protected Sub New(ByVal dtConexio As DataTable)
        MyBase.New()
        Call abrir_coneccion(dtConexio)
    End Sub

#End Region

#Region "[metodos]"

    Protected Sub alta(ByVal item As tb_clienteIn)
        Dim consulta As String = String.Empty
        Try
            consulta = LibClienteIn.alta(item)
            comando.CommandType = CommandType.Text
            comando.CommandText = consulta
            comando.ExecuteNonQuery()

            consulta = LibClienteIn.actualizarCorrelativo()
            comando.CommandType = CommandType.Text
            comando.CommandText = consulta
            comando.ExecuteNonQuery()
        Catch ex As Exception
            set_error("Fallo en clsClienteSin:: alta" & vbNewLine & consulta, ex.Message)
        End Try
    End Sub

    Protected Sub baja(ByVal item As tb_clienteIn)
        Dim consulta As String = String.Empty
        Try
            consulta = LibClienteIn.baja(item)
            comando.CommandType = CommandType.Text
            comando.CommandText = consulta
            comando.ExecuteNonQuery()
        Catch ex As Exception
            set_error("Fallo en clsClienteSin:: baja" & vbNewLine & consulta, ex.Message)
        End Try
    End Sub

    Protected Sub actualizar(ByVal item As tb_clienteIn)
        Dim consulta As String = String.Empty
        Try
            consulta = LibClienteIn.actualizar(item)
            comando.CommandType = CommandType.Text
            comando.CommandText = consulta
            comando.ExecuteNonQuery()
        Catch ex As Exception
            set_error("Fallo en clsClienteSin:: actualizar" & vbNewLine & consulta, ex.Message)
        End Try
    End Sub

    Protected Function getClienteIn() As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = LibClienteIn.getClienteSin()
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Error clsClienteSin:: getClienteIn", ex.Message & vbNewLine & consulta)
            End Try
            Return dt
        End Using
    End Function

    Protected Function getClienteIn(ByVal item As tb_clienteIn) As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = LibClienteIn.getClienteSin(item)
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Error clsClienteSin:: getClienteIn", ex.Message & vbNewLine & consulta)
            End Try
            Return dt
        End Using
    End Function

    Protected Function getCorrelativo() As Integer
        Using dt As New DataTable
            Dim consulta As String = String.Empty : Dim varCorrelativo As Integer = 1
            Try
                consulta = LibClienteIn.getCorrelativo()
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows(0).Item("valor")) Then
                        varCorrelativo = dt.Rows(0).Item("valor")
                    End If
                End If
            Catch ex As Exception
                set_error("Error clsClienteSin:: getCorrelativo", ex.Message & vbNewLine & consulta)
            End Try
            Return varCorrelativo
        End Using
    End Function

    Protected Function getClienteProvedor(ByVal codTipo As String) As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                If codTipo = "10001" Then
                    consulta = Libreria.LibClienteIn.getClienteAfclient()
                ElseIf codTipo = "10002" Then
                    consulta = Libreria.LibClienteIn.getClienteAfprovee()
                End If
                comando.CommandText = consulta
                conector.Fill(dt)

            Catch ex As Exception
                set_error("Error clsClienteSin:: getClienteProvedor", ex.Message & vbNewLine & consulta)
            End Try
            Return dt
        End Using
    End Function


#End Region

End Class
