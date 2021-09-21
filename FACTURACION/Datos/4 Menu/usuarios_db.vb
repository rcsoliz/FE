Imports Entidades
Imports Libreria
Public Class usuarios_db : Inherits BaseDatos

#Region "[CONSTRUCTOR]"

    Public Sub New(ByVal usuario As String, ByVal clave As String)
        MyBase.New()
        Call abrir_coneccion(usuario, clave)

    End Sub
#End Region

#Region "[metodos]"

    Protected Sub alta(ByVal item As Entidades.tb_Cobusuar)
        Dim consulta As String = String.Empty
        Try
            consulta = LibAcceso.alta(item)
            comando.CommandText = consulta
            comando.ExecuteNonQuery()
        Catch ex As Exception
            set_error(String.Format("usuarios_db ERROR AL GRABAR usuarios:alta"), ex.Message & vbNewLine & consulta)
        End Try
    End Sub

    Protected Sub baja(ByVal item As Entidades.tb_Cobusuar)
        Dim consulta As String = String.Empty
        comando.CommandText = consulta
        Try
            consulta = LibAcceso.baja(item)
            comando.CommandText = consulta
            comando.ExecuteNonQuery()
        Catch ex As Exception
            set_error(String.Format("error al actualizar usuario:baja"), ex.Message & vbNewLine & consulta)
        End Try
    End Sub

    Protected Sub actualizar(ByVal item As Entidades.tb_Cobusuar)
        Dim consulta As String = String.Empty
        Try
            consulta = LibAcceso.actualizar(item)
            comando.CommandText = consulta
            comando.ExecuteNonQuery()
        Catch ex As Exception
            set_error(String.Format("Error al modificar usuario: actualizar"), ex.Message & vbNewLine & consulta)
        End Try
    End Sub

    Protected Function getUsuarios(ByVal item As Entidades.tb_Cobusuar) As DataTable
        Using datas As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = Libreria.LibAcceso.getUsuario(item)
                comando.CommandText = consulta
                conector.Fill(datas)
            Catch ex As Exception
                Call set_error("Error en usuarios_db ::getUsuarios", ex.Message & vbNewLine & consulta)
            End Try
            Return datas
        End Using
    End Function

    Protected Function getUnUsuarios(ByVal item As Entidades.tb_Cobusuar) As DataTable
        Using datas As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = Libreria.LibAcceso.getUnUsuario(item)
                comando.CommandText = consulta
                conector.Fill(datas)
            Catch ex As Exception
                Call set_error("Error en usuarios_db ::getUnUsuarios", ex.Message & vbNewLine & consulta)
            End Try
            Return datas
        End Using
    End Function

    Protected Function getCategoriaDeUsuarios() As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = Libreria.LibGlobal.getCategoriaDeUsuario()
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                Call set_error("Error en Datos_usuario_db ::getCategoriaDeUsuarios", ex.Message & vbNewLine & consulta)
            End Try
            Return dt
        End Using
    End Function

    Protected Function getUsuariosXSucrusal() As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = Libreria.LibGlobal.getUsuariosXSucrusal()
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                Call set_error("Error en Datos_usuario_db ::getUsuariosXSucrusal", ex.Message & vbNewLine & consulta)
            End Try
            Return dt
        End Using
    End Function

    Protected Function getMaxCodigo() As Integer
        Using dt As New DataTable
            Dim consulta As String = String.Empty : Dim maxCodigo As Integer
            Try
                consulta = Libreria.LibAcceso.getMaxCodigo()
                comando.CommandText = consulta
                conector.Fill(dt)
                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows(0).Item("codigo")) Then
                        maxCodigo = dt.Rows(0).Item("codigo")
                    End If
                End If
            Catch ex As Exception
                Call set_error("Error en Datos_usuario_db ::getMaxCodigo", ex.Message & vbNewLine & consulta)
            End Try
            Return maxCodigo
        End Using
    End Function

#End Region

End Class