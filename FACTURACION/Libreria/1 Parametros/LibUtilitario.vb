Public Class LibUtilitario

    ''' <summary>
    ''' retorna los TIPOS DE SOLICITUD /PRADCOM
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getTipoDocumento() As String
        Return "SELECT b.pacodigo codigo, trim(a.padescri) tipo, " &
               "(select nvl(max(nummov),0) from sol_cab_pendiente where tipomov=b.pacodigo) correlativo " &
               "FROM sol_afparame b,outer afparame a  " &
               "WHERE b.pacodigo BETWEEN 00000 AND 99999 AND a.pacodigo=b.pacodigo ORDER BY a.pacodigo"

        'Return "SELECT b.pacodigo, trim(a.padescri) padescri, " &
        '       "(select nvl(max(nummov),0) from sol_cab_pendientefe where tipomov=b.pacodigo) correlativo " &
        '       "FROM sol_afparame b,outer afparame a  " &
        '       "WHERE b.pacodigo BETWEEN 00000 AND 99999 AND a.pacodigo=b.pacodigo ORDER BY a.pacodigo"
    End Function

    Public Shared Function getActividad(ByVal codigo As String)
        Return "select trim(cod_actividad) codactiviad, " &
"trim(nomb_actividad) nomactividad,  " &
"trim(nomb_empresa) nomempresa,  " &
"trim(ciudad) ciudad, trim(pais) pais,  " &
"trim(direccion) direccion, trim(cod_postal) cod_postal,  " &
"trim(email) email, trim(telefono1) telefono1,  " &
"trim(telefono2) telefono2, trim(nic)  nic,  " &
"trim(cns) cns  " &
"from datos_actividad where trim(cod_actividad)='" & codigo & "'"
    End Function

End Class