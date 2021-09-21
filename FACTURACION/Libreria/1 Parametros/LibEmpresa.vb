Public Class LibEmpresa

    Public Shared Function getEmpresa(ByVal codActividad As String) As String
        Return "select trim(cod_actividad) cod_actividad, " &
"trim(nomb_actividad) nomb_actividad, " &
"trim(nomb_empresa) nomb_empresa, " &
"trim(ciudad) ciudad, trim(pais) pais, " &
"trim(direccion) direccion, " &
"trim(cod_postal) cod_postal, trim(email) email, " &
"trim(telefono1) telefono1, trim(telefono2) telefono2, " &
"trim(nic) nic, trim(cns) cns  " &
"from datos_actividad where cod_actividad='" & codActividad & "'"
    End Function

End Class
