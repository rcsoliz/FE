Imports Entidades
Public Class LibConfiguracion

    Public Shared Function alta(ByVal item As tb_configuracion) As String
        Return "insert into configuracion(codigo, cuis, urlcertificado, clave, tambiente, estado, codsistema) values(" & item.codigo & ",'" & item.cuis & "','" & item.urlcertificado & "','" & item.clave & "','" & item.tambiente & "','" & item.estado & "','" & item.codsistema & "')"
    End Function

    Public Shared Function update(ByVal item As tb_configuracion) As String
        Return "update configuracion set cuis='" & item.cuis & "' urlcertificado='" & item.urlcertificado & "', clave='" & item.clave & "', tambiente='" & item.tambiente & "',  codsistema='" & item.codsistema & "' where codigo=" & item.codigo
    End Function

    Public Shared Function bajaLogica(ByVal item As tb_configuracion) As String
        Return "update configuracion set estado='D' where codigo=" & item.codigo
    End Function

    Public Shared Function bajaFisica(ByVal item As tb_configuracion) As String
        Return "delete from configuracion where codigo=" & item.codigo
    End Function

    Public Shared Function getCorrelativo() As String
        Return "select max(codigo) codigo from configuracion"
    End Function

    Public Shared Function getConfiguracion() As String
        Return "select codigo, trim(cuis) cuis, trim(urlcertificado) urlcertificado, trim(clave) clave, trim(tambiente) tambiente, trim(estado) estado, trim(codsistema) codsistema from configuracion order by 1"
    End Function

    Public Shared Function getConfiguracion(ByVal item As tb_configuracion) As String
        Return "select codigo, trim(cuis) cuis, trim(urlcertificado) urlcertificado, trim(clave) clave, trim(tambiente) tambiente, trim(estado) estado, trim(codsistema) codsistema from configuracion where codigo=" & item.codigo
    End Function

End Class
