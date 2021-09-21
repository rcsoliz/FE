Imports Entidades
Imports Libreria
Public Class MenuDinamico : Inherits BaseDatos

#Region "[Constructor]"

    Protected Sub New(ByVal usuar As String, ByVal clav As String)
        MyBase.New()
        Call abrir_coneccion(usuar, clav)
    End Sub

#End Region

#Region "[Metodos]"

    Protected Function darMenu(ByVal idUsuario As String) As DataTable
        Using dtMenu As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = MenuDinamicoLib.darMenu(idUsuario)
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dtMenu)
            Catch ex As Exception
                set_error("Fallo en MenuDinamico: Metodo darMenu ", consulta & vbNewLine & ex.Message)
            End Try
            Return dtMenu
        End Using
    End Function

    Protected Function darSubMenu(ByVal idUsuario As String) As DataTable
        Using dtSubMenu As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = MenuDinamicoLib.darSubMenu(idUsuario)
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dtSubMenu)
            Catch ex As Exception
                set_error("Fallo en MenuDinamico: Metodo darSubMenu ", consulta & vbNewLine & ex.Message)
            End Try
            Return dtSubMenu
        End Using
    End Function

    Protected Function darEvento(ByVal idUsuario As String) As DataTable
        Using dtEvento As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = MenuDinamicoLib.darEvento(idUsuario)
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dtEvento)
            Catch ex As Exception
                set_error("Fallo en MenuDinamico: Metodo darEvento ", consulta & vbNewLine & ex.Message)
            End Try
            Return dtEvento
        End Using
    End Function

#End Region

End Class
