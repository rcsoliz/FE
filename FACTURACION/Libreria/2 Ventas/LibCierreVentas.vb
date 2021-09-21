Public Class LibCierreVentas

    Public Shared Function altaCabPreFactura(ByVal item As Entidades.tb_CabVentas) As String 'pradcom@ol_suse:
        Return "insert into sol_cab_pendientefe(tipomov, nummov,     fechamov,  nombre,    apellido," &
        "ci_ruc, telefono, direccion, pais, email, " &
        "arancel, lugentrega, fob_fca, plazopago, pesobruto, " &
        "pesoneto, pedido, proforma, moneda, estado, " &
        "tipocambio,  " &
        "mdescuento, mtotal, msubtotal, mdolar, usuario) values ('" & item.tipomov & "'," & item.nummov & ",'" & item.fechamov.ToShortDateString & "','" &
        item.nombre & "','" & item.apellido & "'," &
        item.ci_ruc & ",'" & item.telefono & "','" & item.direccion & "','" & item.pais & "','" & item.email & "','" &
        item.arancel & "','" & item.lugentrega & "','" & item.fob_fca & "','" & item.plazopago & "'," & item.pesobruto & "," &
        item.pesoneto & ",'" & item.pedido & "','" & item.proforma & "','" & item.moneda & "','" & item.estado & "'," &
        item.tipocambio & "," &
        item.mdescuento & "," & item.mtotal & "," & item.msubtotal & "," & item.mdolar & ",'" & item.usuario & "')"
    End Function

    Public Shared Function altaCuepPreFactura(ByVal item As Entidades.tb_CueVentas) As String
        Return "insert into sol_cue_pendientefe(posicion,    tipomov,  nummov,    nroitem, kilos, " &
        "unidmedida, cantidad, undmedida, detalle, preciobs,  " &
        "descuentobs, importebs,  subtotal) values(" & item.posicion & ",'" & item.tipomov & "'," & item.nummov & ",'" & item.nroitem & "'," & item.kilos & ",'" &
        item.unidmedida & "'," & item.cantidad & ",'" & item.undmedida & "','" & item.detalle & "'," & item.preciobs & "," &
        item.descuentobs & "," & item.importebs & "," & item.subtotal & ")"
    End Function

    Public Shared Function getCabera(ByVal fecha As Date) As String
        Return "select trim(tipomov) tipomov, nummov,  fechamov from sol_cab_pendientefe where fechamov='" & fecha.ToShortDateString & "'"
    End Function

    Public Shared Function bajaCuerpo(ByVal item As Entidades.tb_CabVentas) As String
        Return "delete from sol_cue_pendientefe  where tipomov='" & item.tipomov & "' and  nummov=" & item.nummov
    End Function

    Public Shared Function bajaCabecera(ByVal item As Entidades.tb_CabVentas) As String
        Return "delete from sol_cab_pendientefe  where tipomov='" & item.tipomov & "' and  nummov=" & item.nummov & " and fechamov='" & item.fechamov.ToShortDateString & "'"
    End Function

End Class