Imports Libreria
Imports Entidades
Public Class clsCatalogofe : Inherits BaseDatos

#Region "[atributosGlobales]"

#End Region

#Region "[contrutor]"

    Protected Sub New(ByVal usuar As String, ByVal clav As String)
        MyBase.New()
        Call abrir_coneccion(usuar, clav)
    End Sub

#End Region

#Region "[metodos]"

    Protected Sub alta(ByVal item As Entidades.tb_CatalogoFe)
        Dim consulta As String = String.Empty
        Try
            consulta = LibCatalogoFe.alta(item)
            comando.CommandText = consulta
            comando.ExecuteNonQuery()
        Catch ex As Exception
            set_error("Fallo en clsCatalogofe:: alta" & vbNewLine & consulta, vbNewLine & ex.Message)
        End Try
    End Sub

    Protected Sub actualizar(ByVal item As Entidades.tb_CatalogoFe)
        Dim consulta As String = String.Empty
        Try
            consulta = LibCatalogoFe.update(item)
            comando.CommandType = CommandType.Text
            comando.CommandText = consulta
            comando.ExecuteNonQuery()
        Catch ex As Exception
            set_error("Fallo en clsCatalogofe:: actualizar" & vbNewLine & consulta, vbNewLine & ex.Message)
        End Try
    End Sub

    Protected Sub baja(ByVal item As Entidades.tb_CatalogoFe)
        Dim consulta As String = String.Empty
        Try
            consulta = LibCatalogoFe.baja(item)
            comando.CommandType = CommandType.Text
            comando.CommandText = consulta
            comando.ExecuteNonQuery()
        Catch ex As Exception
            set_error("Fallo en clsCatalogofe:: baja" & vbNewLine & consulta, vbNewLine & ex.Message)
        End Try
    End Sub

    Protected Function getCatalogo() As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = LibCatalogoFe.getCatalogo()
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Fallo en clsCatalogofe:: getCatalogo " & vbNewLine & consulta, vbNewLine & ex.Message)
            End Try
            Return dt
        End Using
    End Function

    Protected Function getCatalogo(ByVal item As tb_CatalogoFe) As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = LibCatalogoFe.getCatalogo(item)
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Fallo en clsCatalogofe:: getCatalogo " & vbNewLine & consulta, vbNewLine & ex.Message)
            End Try
            Return dt
        End Using
    End Function

    Protected Function getCatalogoGrupo(ByVal item As tb_CatalogoFe) As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = LibCatalogoFe.getCatalogoGrupo(item)
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Fallo en clsCatalogofe:: getCatalogoGrupo " & vbNewLine & consulta, vbNewLine & ex.Message)
            End Try
            Return dt
        End Using
    End Function

    Protected Function getCatalogo(ByVal tipo As String, ByVal codError As String) As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = LibCatalogoFe.getCatalogo(tipo, codError)
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Fallo en clsCatalogofe:: getCatalogo " & vbNewLine & consulta, vbNewLine & ex.Message)
            End Try
            Return dt
        End Using
    End Function

#End Region

End Class
