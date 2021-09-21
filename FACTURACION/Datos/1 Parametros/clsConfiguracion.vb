Imports Entidades
Imports Libreria
Public Class clsConfiguracion : Inherits BaseDatos

#Region "[constructor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String)
        MyBase.New()
        Call abrir_coneccion(usuar, clav)
    End Sub

#End Region

#Region "[metodos]"

    Protected Sub alta(ByVal item As tb_configuracion)
        Dim consulta As String = String.Empty
        Try
            consulta = Libreria.LibConfiguracion.alta(item)
            comando.CommandType = CommandType.Text
            comando.CommandText = consulta
            comando.ExecuteNonQuery()
        Catch ex As Exception
            set_error("Error clsConfiguracion:: alta", ex.Message & vbNewLine & consulta)
        End Try
    End Sub

    Protected Sub update(ByVal item As tb_configuracion)
        Dim consulta As String = String.Empty
        Try
            consulta = Libreria.LibConfiguracion.update(item)
            comando.CommandType = CommandType.Text
            comando.CommandText = consulta
            comando.ExecuteNonQuery()
        Catch ex As Exception
            set_error("Error clsConfiguracion:: update", ex.Message & vbNewLine & consulta)
        End Try
    End Sub

    Protected Function getCorrelativo() As Integer
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Dim varCodigo As Integer = 1
            Try
                consulta = Libreria.LibConfiguracion.getCorrelativo()
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows(0).Item("codigo")) Then
                        varCodigo = dt.Rows(0).Item("codigo")
                    End If
                End If
            Catch ex As Exception
                set_error("Error clsConfiguracion:: getCorralativo", ex.Message & vbNewLine & consulta)
            End Try
            Return varCodigo
        End Using
    End Function

    Protected Sub bajaLogica(ByVal item As tb_configuracion)
        Dim consulta As String = String.Empty
        Try
            consulta = Libreria.LibConfiguracion.bajaLogica(item)
            comando.CommandType = CommandType.Text
            comando.CommandText = consulta
            comando.ExecuteNonQuery()
        Catch ex As Exception
            set_error("Error clsConfiguracion:: bajaLogica", ex.Message & vbNewLine & consulta)
        End Try
    End Sub

    Protected Sub bajaFisica(ByVal item As tb_configuracion)
        Dim consulta As String = String.Empty
        Try
            consulta = Libreria.LibConfiguracion.bajaFisica(item)
            comando.CommandType = CommandType.Text
            comando.CommandText = consulta
            comando.ExecuteNonQuery()
        Catch ex As Exception
            set_error("Error clsConfiguracion:: bajaFisica", ex.Message & vbNewLine & consulta)
        End Try
    End Sub

    Protected Function getConfiguracion() As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = LibConfiguracion.getConfiguracion()
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Error clsConfiguracion:: getConfiguracion", ex.Message & vbNewLine & consulta)
            End Try
            Return dt
        End Using
    End Function

    Protected Function getConfiguracion(ByVal item As tb_configuracion) As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = LibConfiguracion.getConfiguracion(item)
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Error clsConfiguracion:: getConfiguracion", ex.Message & vbNewLine & consulta)
            End Try
            Return dt
        End Using
    End Function

#End Region

End Class