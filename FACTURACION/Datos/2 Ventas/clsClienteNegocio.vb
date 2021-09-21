Imports Entidades
Imports Libreria
Public Class clsClienteNegocio : Inherits BaseDatos
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

    Protected Sub alta(ByVal item As tb_clienteNegocio)
        Dim consulta As String = String.Empty
        Try
            consulta = LibClienteNegocio.alta(item)
            comando.CommandType = CommandType.Text
            comando.CommandText = consulta
            comando.ExecuteNonQuery()
        Catch ex As Exception
            set_error("Fallo en clsClienteNegocio:: alta" & vbNewLine & consulta, ex.Message)
        End Try
    End Sub

    Protected Sub bajaLogica(ByVal item As tb_clienteNegocio)
        Dim consulta As String = String.Empty
        Try
            consulta = LibClienteNegocio.bajaLogica(item)
            comando.CommandType = CommandType.Text
            comando.CommandText = consulta
            comando.ExecuteNonQuery()
        Catch ex As Exception
            set_error("Fallo en clsClienteNegocio:: bajaLogica" & vbNewLine & consulta, ex.Message)
        End Try
    End Sub

    Protected Sub baja(ByVal item As tb_clienteNegocio)
        Dim consulta As String = String.Empty
        Try
            consulta = LibClienteNegocio.baja(item)
            comando.CommandType = CommandType.Text
            comando.CommandText = consulta
            comando.ExecuteNonQuery()
        Catch ex As Exception
            set_error("Fallo en clsClienteNegocio:: baja" & vbNewLine & consulta, ex.Message)
        End Try
    End Sub

    Protected Sub actualizar(ByVal item As tb_clienteNegocio)
        Dim consulta As String = String.Empty
        Try
            consulta = LibClienteNegocio.actualizar(item)
            comando.CommandType = CommandType.Text
            comando.CommandText = consulta
            comando.ExecuteNonQuery()
        Catch ex As Exception
            set_error("Fallo en clsClienteNegocio:: actualizar" & vbNewLine & consulta, ex.Message)
        End Try
    End Sub

    Protected Function getClienteNegocio() As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = LibClienteNegocio.getClienteNegocio()
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Error clsClienteNegocio:: getClienteNegocio", ex.Message & vbNewLine & consulta)
            End Try
            Return dt
        End Using
    End Function

    Protected Function getClienteNegocio(ByVal item As tb_clienteNegocio) As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = LibClienteNegocio.getClienteNegocio(item)
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Error clsClienteNegocio:: getClienteNegocio", ex.Message & vbNewLine & consulta)
            End Try
            Return dt
        End Using
    End Function

    Public Function getCliente(ByVal item As tb_clienteNegocio) As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = LibClienteNegocio.getCliente(item)
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Error clsClienteNegocio:: getCliente", ex.Message & vbNewLine & consulta)
            End Try
            Return dt
        End Using
    End Function

#End Region

End Class