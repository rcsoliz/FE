Imports Entidades
Public Class ClsEmpresa : Inherits BaseDatos

#Region "[atributosGlobales]"

#End Region

#Region "[contrutor]"

    Protected Sub New(ByVal usuar As String, ByVal clav As String)
        MyBase.New()
        Call abrir_coneccion(usuar, clav)
    End Sub

#End Region

#Region "[metodos]"

    Public Sub alta(ByVal item As Entidades.tb_empresa)
        Dim consulta As String = String.Empty
        Try
            consulta = "insert into datos_actividad (cod_actividad ,nomb_actividad, nomb_empresa, ciudad, pais, direccion, " &
                "cod_postal, email, telefono1, telefono2,   nic , cns) values ('" & item.cod_actividad & "','" & item.nomb_actividad & "','" &
                item.nomb_empresa & "','" & item.ciudad & "','" & item.pais & "','" & item.direccion & "','" &
                item.cod_postal & "','" & item.email & "','" & item.telefono1 & "','" & item.telefono2 & "','" &
                item.nic & "','" & item.cns & "')"
            comando.CommandType = CommandType.Text
            comando.CommandText = consulta
            comando.ExecuteNonQuery()
        Catch ex As Exception
            set_error("Fallo en ClsEmpresa:: alta " & vbNewLine & consulta, ex.Message)
        End Try
    End Sub

    Public Sub actualizar(ByVal item As Entidades.tb_empresa)
        Dim consulta As String = String.Empty
        Try
            consulta = "update datos_actividad set nomb_actividad='" & item.nomb_actividad & "', nomb_empresa='" & item.nomb_empresa & "'," &
                "ciudad='" & item.ciudad & "', pais='" & item.pais & "', direccion='" & item.direccion & "'," &
                "cod_postal='" & item.cod_postal & "', email='" & item.email & "', telefono1='" & item.telefono1 & "'," &
                "telefono2='" & item.telefono2 & "', nic='" & item.nic & "', cns='" & item.cns & "' where cod_actividad='" & item.cod_actividad & "'"
            comando.CommandType = CommandType.Text
            comando.CommandText = consulta
            comando.ExecuteNonQuery()
        Catch ex As Exception
            set_error("Fallo en ClsEmpresa:: actualizar " & vbNewLine & consulta, ex.Message)
        End Try
    End Sub

    Public Sub baja(ByVal item As Entidades.tb_empresa)
        Dim consulta As String = String.Empty
        Try
            consulta = "delete from datos_actividad where cod_actividad='" & item.cod_actividad & "'"
            comando.CommandType = CommandType.Text
            comando.CommandText = consulta
            comando.ExecuteNonQuery()
        Catch ex As Exception
            set_error("Fallo en ClsEmpresa:: baja " & vbNewLine & consulta, ex.Message)
        End Try
    End Sub

    Public Function getEmpresa() As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = "select trim(cod_actividad) cod_actividad , trim(nomb_actividad) nomb_actividad, trim(nomb_empresa) nomb_empresa, " &
                "trim(ciudad) ciudad, trim(pais) pais, trim(direccion) direccion, " &
                "trim(cod_postal) cod_postal, trim(email) email, trim(telefono1) telefono1, trim(telefono2) telefono2, trim(nic) nic , " &
                "trim(cns) cns from datos_actividad order by 1,2"
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Fallo en ClsEmpresa:: getEmpresa " & vbNewLine & consulta, ex.Message)
            End Try
            Return dt
        End Using
    End Function

    Public Function getEmpresa(ByVal item As Entidades.tb_empresa) As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = "select trim(cod_actividad) cod_actividad , trim(nomb_actividad) nomb_actividad, trim(nomb_empresa) nomb_empresa, " &
                "trim(ciudad) ciudad, trim(pais) pais, trim(direccion) direccion, " &
                "trim(cod_postal) cod_postal, trim(email) email, trim(telefono1) telefono1, trim(telefono2) telefono2, trim(nic) nic , " &
                "trim(cns) cns from datos_actividad where cod_actividad='" & item.cod_actividad & "'"
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Fallo en ClsEmpresa:: getEmpresa " & vbNewLine & consulta, ex.Message)
            End Try
            Return dt
        End Using
    End Function

    Public Function getEmpresa(ByVal codActividad As String) As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = Libreria.LibEmpresa.getEmpresa(codActividad)
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Fallo en ClsEmpresa:: getEmpresa " & vbNewLine & consulta, ex.Message)
            End Try
            Return dt
        End Using
    End Function

#End Region

End Class
