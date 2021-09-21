Public Class LibPreVentas

    Public Shared Function anularVenta(ByVal item As Entidades.tb_CabVentas) As String
        Return "update sol_cab_pendientefe set estado =0 where tipomov='" & item.tipomov & "' and  nummov=" & item.nummov
    End Function

    Public Shared Function bajaCuerpo(ByVal item As Entidades.tb_CabVentas) As String
        Return "delete from sol_cue_pendientefe  where tipomov='" & item.tipomov & "' and  nummov=" & item.nummov
    End Function

    Public Shared Function bajaCabecera(ByVal item As Entidades.tb_CabVentas) As String
        Return "delete from sol_cab_pendientefe  where tipomov='" & item.tipomov & "' and  nummov=" & item.nummov
    End Function

    Public Shared Function getCabecera(ByVal item As Entidades.tb_CabVentas) As String
        Return "select " &
"trim(tipomov) tipomov,   nummov,                    fechamov,                trim(nombre) nombre, " &
"trim(apellido) apellido, trim(ci_ruc) ci_ruc,       trim(telefono) telefono, trim(direccion) direccion, " &
"trim(pais) pais,         trim(email) email,         trim(arancel) arancel,   trim(lugentrega) lugentrega, " &
"trim(fob_fca) fob_fca,   trim(plazopago) plazopago, pesobruto,               pesoneto, " &
"trim(pedido) pedido,     trim(proforma) proforma,   trim(moneda) moneda,     trim(estado) estado," &
"tipocambio,              mdescuento,                mtotal,                  msubtotal," &
"mdolar,                  trim(usuario) usuario from sol_cab_pendientefe where tipomov='" & item.tipomov & "' and nummov=" & item.nummov
    End Function

    Public Shared Function getCuerpo(ByVal item As Entidades.tb_CabVentas) As String
        Return "select " &
"posicion,               trim(tipomov) tipomov,       nummov,      trim(nroitem) nroitem, " &
"kilos,                  trim(unidmedida) unidmedida, cantidad,    trim(undmedida) undmedida, " &
"trim(detalle) detalle,  preciobs,                    descuentobs, importebs, " &
"subtotal from sol_cue_pendientefe  where tipomov='" & item.tipomov & "' and  nummov=" & item.nummov
    End Function

    'Public Shared Function getNumeroMaximo(ByVal codPar1 As String, ByVal codPar2 As String) As String
    '    Return "SELECT b.pacodigo,a.padescri, (SELECT nvl(max(nummov),0) FROM sol_cab_pendiente WHERE tipomov=b.pacodigo) vmaximo " &
    '           "FROM sol_afparame b,outer afparame a " &
    '           "WHERE b.pacodigo BETWEEN '" & codPar1 & "' AND '" & codPar2 & "' AND a.pacodigo=b.pacodigo ORDER BY a.pacodigo "
    'End Function

    Public Shared Function getTipoDocumento() As String
        Return "SELECT trim(b.pacodigo) pacodigo, trim(a.padescri) tipo, (SELECT nvl(max(nummov),0) FROM sol_cab_pendiente WHERE tipomov=b.pacodigo) correlativo " &
               "FROM sol_afparame b,outer afparame a " &
               "WHERE b.pacodigo BETWEEN '00000' AND '99999' AND a.pacodigo=b.pacodigo ORDER BY a.pacodigo "
    End Function

    Public Shared Function getCorrelativo(ByVal codTipoMovimiento As String) As String
        Return "SELECT max(nummov) nummov FROM sol_cab_pendientefe WHERE tipomov='" & codTipoMovimiento & "'"
    End Function

    ''' <summary>
    ''' Obtiene el pavalor1 Es la Actividad (1,2,3, ..etc), IF pavalor2= 0 then Not Factura ELSE Con Factura 
    ''' </summary>
    ''' <param name="codTipoDocumento"> codigo tipo documento</param>
    ''' <returns>string</returns>
    ''' <remarks></remarks>
    Public Shared Function getEsConFactura(ByVal codTipoDocumento As String) As String
        Return "SELECT pavalor1,pavalor2 FROM sol_afparame WHERE pacodigo ='" & codTipoDocumento & "'"
    End Function

    ''' <summary>
    ''' Funcion que obtine datos para la factura de despachos C-II (cabecera) db expcarne tdocumento = 99014 
    ''' </summary>
    ''' <param name="codTipoDocumento"></param>
    ''' <param name="nroNota"></param>
    ''' <returns>retorna una cadena</returns>
    ''' <remarks></remarks>
    Public Shared Function getVentaDespachoCII(ByVal codTipoDocumento As String, ByVal nroNota As String) As String
        Return "SELECT TRIM(nombre) nombre, TRIM(apellido) apellido, TRIM(nit_ci) nit_ci " &
               "FROM datos_factura, dembqdti " &
               "WHERE  tipoc='" & codTipoDocumento & "' AND nro_dc=" & nroNota & " AND codigocli=codcam"
        'expcarne@ol_suse:datos_factura,expcarne@ol_suse:dembqdti
    End Function

    ''' <summary>
    ''' Funcion que obtine datos para la factura despachos C-II (Cuerpo) db expcarne tdocumento = 99014 
    ''' </summary>
    ''' <param name="codTipoDocumento"></param>
    ''' <param name="nroNota"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getCuerpoDespachoCII(ByVal codTipoDocumento As String, ByVal nroNota As String) As String
        Return "SELECT  serial2, codigo, trim(detll) detalle, sum(ttimporte/prcdol) cantidad, prcdol precio, " &
               "0 descuento, sum(ttimporte) importe, sum(ttimporte) subtotal  " &
               "FROM dembqdtii  " &
               "WHERE tipo='" & codTipoDocumento & "' AND nro_d=" & nroNota & " " &
               "GROUP by 1,2,3, 5 " &
               "ORDER BY serial2,2 "
        'expcarne@ol_suse:dembqdtii
    End Function
End Class