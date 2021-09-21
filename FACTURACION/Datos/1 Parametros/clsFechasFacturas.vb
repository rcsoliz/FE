Imports Entidades
Public Class clsFechasFacturas : Inherits BaseDatos

#Region "[atributosGlobales]"

#End Region

#Region "[contrutor]"

    Protected Sub New(ByVal usuar As String, ByVal clav As String)
        MyBase.New()
        Call abrir_coneccion(usuar, clav)
    End Sub

#End Region

#Region "[metodos]"

    Public Sub alta(ByVal item As Entidades.tb_FechasFactura)
        Dim consulta As String = String.Empty
        Try
            consulta = Libreria.LibFechasFactura.alta(item)
            comando.CommandText = consulta
            comando.ExecuteNonQuery()
        Catch ex As Exception
            set_error("Fallo en clsFechasFacturas:: alta", ex.Message)
        End Try
    End Sub

    Public Sub alta(ByVal lista As List(Of Entidades.tb_FechasFactura))
        Dim consulta As String = String.Empty
        Try
            For Each item As tb_FechasFactura In lista
                consulta = Libreria.LibFechasFactura.alta(item)
                comando.CommandText = consulta
                comando.ExecuteNonQuery()
            Next
        Catch ex As Exception
            set_error("Fallo en clsFechasFacturas:: alta", ex.Message)
        End Try
    End Sub

    Public Sub update(ByVal item As Entidades.tb_FechasFactura)
        Dim consulta As String = String.Empty
        Try
            consulta = Libreria.LibFechasFactura.update(item)
            comando.CommandText = consulta
            comando.ExecuteNonQuery()
        Catch ex As Exception
            set_error("Fallo en clsFechasFacturas:: update", ex.Message)
        End Try
    End Sub

    Public Sub update(ByVal lista As List(Of Entidades.tb_FechasFactura))
        Dim consulta As String = String.Empty
        Try
            For Each item As tb_FechasFactura In lista
                consulta = Libreria.LibFechasFactura.update(item)
                comando.CommandText = consulta
                comando.ExecuteNonQuery()
            Next
        Catch ex As Exception
            set_error("Fallo en clsFechasFacturas:: update", ex.Message)
        End Try
    End Sub


    Public Function getGestion() As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = Libreria.LibFechasFactura.getGestion()
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Fallo en clsFechasFacturas:: getGestion", ex.Message)
            End Try
            Return dt
        End Using
    End Function

    Public Function getGestion(ByVal item As Entidades.tb_FechasFactura) As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = Libreria.LibFechasFactura.getGestion(item)
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Fallo en clsFechasFacturas:: getGestion", ex.Message)
            End Try
            Return dt
        End Using
    End Function

    Public Function getGestionYMes(ByVal item As Entidades.tb_FechasFactura) As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = Libreria.LibFechasFactura.getGestionYMes(item)
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Fallo en clsFechasFacturas:: getGestionYMes", ex.Message)
            End Try
            Return dt
        End Using
    End Function

#End Region

End Class
