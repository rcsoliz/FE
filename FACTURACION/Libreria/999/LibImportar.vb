Imports Entidades
Public Class LibImportar

    Public Shared Function getDatos93012(ByVal codTipoDoc As String) As String
        Return "select unique  trim(ci_ruc) ci_ruc,  trim(nombre) nombre, trim(apellido) apellido, " &
               "cod_actividad, numerfact, nummov , trim(tipomov) tipomov " &
               "from facturas " &
               "where tipomov='93012'  and trim(ci_ruc)<>'0' " &
               "order by 1 ,2,3"
    End Function

    Public Shared Function getDatosFatura(ByVal codTipoDoc As String) As String
        Return "select unique  trim(ci_ruc) ci_ruc,  trim(nombre) nombre, trim(apellido) apellido, " &
           "cod_actividad, numerfact, nummov , trim(tipomov) tipomov " &
           "from facturas " &
           "where tipomov='" & codTipoDoc & "'  and trim(ci_ruc)<>'0' " &
           "order by 1 ,2,3, numerfact, nummov"
    End Function

    Public Shared Function getDatosCuerpoProv(ByVal codTipoDoc As String, ByVal nmov As Decimal) As String
        Return "select UNIQUE lqtipliq, lqnroliq, trim(prnombre) prnombre, " &
"trim(prapelli) prapelli,  trim(prdirecc) prdirecc, trim(ruc) ruc, trim(prdirecc) direccion, trim(prtelefo) telefono FROM afliqpro, afprovee,outer ruc_prove " &
"where lqtipliq = '" & codTipoDoc & "' AND " &
"lqcodpro = prcodigo AND " &
"lqcodpro = codigo AND " &
"lqnroliq=" & nmov
    End Function

    Public Shared Function getDatosComp93012(ByVal codTipoDoc As String) As String
        Return "select prcodigo, trim(prnombre) prnombre, trim(prapelli) prapelli, " &
"trim(prdirecc) prdirecc, trim(ruc) ruc, trim(prdirecc) direccion, " &
"trim(prtelefo) telefono from afprovee "
    End Function

    Public Shared Function alta(ByVal item As tb_impcliente) As String
        Return "insert into clientein(codigoin, nombre, apellido, nitci) values(" & item.codigoin & ",'" & item.nombre & "','" & item.apellido & "','" & item.ruc_ci & "')"
    End Function

    Public Shared Function altaNeg(ByVal item As tb_clienteNegocio) As String
        Return "insert into clientenegocio(codigoin, codigosistema, codunidad, tipocliente, telefono, celular, direccion, email, fregistro, estado) values(" &
            item.codigoin & "," & item.codigosistema & "," & item.codunidad & ",'" &
            item.tipocliente & "','" & item.telefono & "','" & item.celular & "','" &
            item.direccion & "','" & item.email & "','" & item.fregistro.ToShortDateString & "', 'a' )"
    End Function

End Class
