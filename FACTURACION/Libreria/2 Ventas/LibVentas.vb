Public Class LibVentas

    '__________________________________ Calculo facturacion para liquidaciones a proveedor
    Public Shared Function cabLiqProveedor(ByVal fecha As Date) As String
        Return "select UNIQUE lqfechal,lqtipliq,lqnroliq,trim(prnombre) prnombre, trim(prapelli) prapelli, trim(ruc) ruc " &
               " ,  trim(prdirecc) direccion " &
               " , trim(prtelefo) telefono " &
               " , 0 mdescuento " &
               " , sum(lqimpobs) mtotal  " &
               " , sum(lqimpobs) msubtotal  " &
               " , sum(lqimpous) mdolar  " &
               "from afliqpro,outer afprovee,outer ruc_prove  " &
               "where " &
               "lqtipliq = '93012' And " &
               "lqcodpro = prcodigo And " &
               "lqcodpro = codigo And " &
               "lqfechal ='" & fecha.ToShortDateString & "' " &
               "group by  1,2,3,4,5,6 ,  7,8 " &
               "order by lqnroliq"
    End Function

    Public Shared Function cuerpoLiqProveedor(ByVal fecha As Date, ByVal nrodoc As String) As String
        Return "select lqcodcon, count(*) cant, " &
               "'SERV DE FAENA Y ENFRIAMIENTO' detalle, " &
               "sum(lqimpobs)/count(*) precio, " &
               "sum(lqimpobs) monto  " &
               " , 0.00 descuento " &
               ", '' umedida " &
               ", sum(lqimpobs) subtotal " &
               "from afliqpro " &
               "where lqclacon = '92002' And lqcodcon = '11001' And " &
               "lqtipliq = '93012' And " &
               "lqnroliq = " & nrodoc & " And " &
               "lqfechal ='" & fecha.ToShortDateString & "' " &
               "group by lqcodcon " &
               "union " &
               "select lqcodcon, count(*) cant, " &
               "'SERV.COBRANZA Y ENTREGA' detalle, " &
               "sum(lqimpobs)/count(*) precio, " &
               "sum(lqimpobs) monto " &
               " , 0.00 descuento " &
               ", '' umedida " &
               ", sum(lqimpobs) subtotal " &
               "from afliqpro " &
               "where lqclacon = '92002' And lqcodcon = '11015' And " &
               "lqtipliq = '93012' And " &
               "lqnroliq = " & nrodoc & " And " &
               "lqfechal ='" & fecha.ToShortDateString & "' " &
               "group by lqcodcon " &
               "union " &
               "select lqcodcon, count(*) cant, 'SERVICIO DE CORRALAJE' detalle, " &
               "sum(lqimpobs)/count(*) precio, " &
               "sum(lqimpobs) monto " &
               " , 0.00 descuento " &
               " , '' umedida " &
               ", sum(lqimpobs) subtotal " &
               "From afliqpro " &
               "where lqclacon = '92002' And lqcodcon = '11016' And " &
               "lqtipliq = '93012' And " &
               "lqnroliq = " & nrodoc & " And " &
               "lqfechal ='" & fecha.ToShortDateString & "' " &
               "group by lqcodcon"
    End Function

    '____________________________________ Calculo facturacion para limpieza de menudos
    Public Shared Function cabLimpiezaMenudo(ByVal fecha As Date) As String
        Return "select UNIQUE fpfechaf,fptipfac,fpnrofac, trim(clnombre) clnombre, trim(clapelli) clapelli, trim(ruc) ruc " &
               ", trim(cldirecc) direccion " &
               ", trim(cltelcli) telefono " &
               ", nvl(sum(fpdescbs),0) mdescuento " &
               ", sum(fpimnebs) mtotal " &
               ", (sum(fpimnebs) - nvl(sum(fpdescbs),0)) msubtotal " &
               ", sum( fpimneus) mdolar " &
               "from affacsub,outer afclient,outer ruc_cliente  " &
               "where  " &
               "fptipfac = '93014' And  " &
               "fpcodcli = clcodcli And  " &
               "fpcodcli = codigo And  " &
               "fpcodcon = '16999' And  " &
               "fpfechaf ='" & fecha.ToShortDateString & "' " &
               "group by 1,2,3,4,5,6, 7,8 " &
               "order by fpnrofac"
    End Function

    Public Shared Function cuerpoLimpiezaMenudo(ByVal fecha As Date, ByVal nrodoc As String) As String
        Return "select fpcodcon, sum(fpcantid) cant, 'SERVICIO LAVADO MENUDO' detalle, " &
                "sum(fpimnebs)/sum(fpcantid) precio, " &
                "sum(fpimnebs) monto " &
                ", nvl(sum(fpdescbs),0) descuento " &
                ", (select (select trim(padescri) from afparame pr where pr.pacodigo= pa.pavalor1) " &
                "from afparame pa where pa.pacodigo=fpcodcon) umedida " &
                ", (sum(fpimnebs)-nvl(sum(fpdescbs),0)) subtotal " &
                "from affacsub " &
                "where fpcodcon = '16999' And " &
                "fptipfac = '93014' And " &
                "fpnrofac = " & nrodoc & " And " &
                "fpfechaf = '" & fecha.ToShortDateString & "' " &
                "group by fpcodcon"
    End Function


    '__________________________________ # Calculo facturacion para ventas de sebo
    Public Shared Function cabSebos(ByVal fecha As Date) As String
        Return "select UNIQUE fpfechaf,fptipfac,fpnrofac, trim(clnombre) clnombre, trim(clapelli) clapelli, trim(ruc) ruc  " &
               ", trim(cldirecc) direccion " &
               ", trim(cltelcli) telefono " &
               ", nvl(sum(fpdescbs),0) mdescuento " &
               ", sum(fpimnebs) mtotal " &
               ", (sum(fpimnebs) - nvl(sum(fpdescbs),0)) msubtotal " &
               ", sum( fpimneus) mdolar " &
               "from affacsub,outer afclient,outer ruc_cliente  " &
               "where fptipfac = '93014' and  " &
               "fpcodcli=clcodcli and  " &
               "fpcodcli=codigo  and  " &
               "fpcodcon='16043' and  " &
               "fpfechaf='" & fecha.ToShortDateString & "' " &
               "group by 1,2,3,4,5,6, 7, 8 " &
               "order by fpnrofac"
    End Function

    Public Shared Function cuerpoSebos(ByVal fecha As Date, ByVal nrodoc As String) As String
        Return " select fpcodcon, sum(fpcantid) cant, 'DESPERDICIO (SEBO)' detalle, " &
                "sum(fpimnebs)/sum(fpcantid) precio, " &
                "sum(fpimnebs) monto " &
                ", nvl(sum(fpdescbs),0) descuento " &
                ", (select (select trim(padescri) from afparame pr where pr.pacodigo= pa.pavalor1) " &
                "from afparame pa where pa.pacodigo=fpcodcon) umedida " &
                ", (sum(fpimnebs)-nvl(sum(fpdescbs),0)) subtotal " &
                "from affacsub " &
                "where fpcodcon = '16043' And fptipfac = '93014' " &
                "and fpnrofac=" & nrodoc & " and fpfechaf='" & fecha.ToShortDateString & "' " &
                "group by fpcodcon"
    End Function

    '__________________________________ # Calculo facturacion para ventas de sangre fetal
    Public Shared Function cabSangreFetal(ByVal fecha As Date) As String
        Return "select UNIQUE fpfechaf,fptipfac,fpnrofac, trim(clnombre) clnombre, trim(clapelli) clapelli, trim(ruc) ruc " &
               ", trim(cldirecc) direccion " &
               ", trim(cltelcli) telefono " &
               ", nvl(sum(fpdescbs),0) mdescuento " &
               ", sum(fpimnebs) mtotal " &
               ", (sum(fpimnebs) - nvl(sum(fpdescbs),0)) msubtotal " &
               ", sum( fpimneus) mdolar " &
               "from affacsub,outer afclient,outer ruc_cliente " &
               "where fptipfac ='93014' and " &
               "fpcodcli = clcodcli And " &
               "fpcodcli=codigo  and " &
               "fpcodcon='16118' and  " &
               "fpfechaf='" & fecha.ToShortDateString & "' " &
               "group by 1,2,3,4,5,6, 7, 8 " &
               "order by fpnrofac"
    End Function

    Public Shared Function cuerpoSangreFetal(ByVal fecha As Date, ByVal nrodoc As String) As String
        Return "select fpcodcon, sum(fpcantid) cant, 'SANGRE' detalle, " &
               "sum(fpimnebs)/sum(fpcantid) precio, " &
               "sum(fpimnebs) monto " &
               ", nvl(sum(fpdescbs),0) descuento " &
               ", (select (select trim(padescri) from afparame pr where pr.pacodigo= pa.pavalor1) " &
               "from afparame pa where pa.pacodigo=fpcodcon) umedida " &
               ", (sum(fpimnebs)-nvl(sum(fpdescbs),0)) subtotal " &
               "from affacsub " &
               "where fpcodcon='16118' and " &
               "fptipfac= '93014' and  " &
               "fpnrofac=" & nrodoc & " and " &
               "fpfechaf='" & fecha.ToShortDateString & "'  " &
               "group by fpcodcon"
    End Function

    '__________________________________ # Calculo facturacion para ventas de descarte 1

    Public Shared Function cabDescarteUno(ByVal fecha As Date) As String
        Return "select UNIQUE fpfechaf,fptipfac,fpnrofac,  trim(clnombre) clnombre, trim(clapelli) clapelli, trim(ruc) ruc " &
               ", trim(cldirecc) direccion " &
               ", trim(cltelcli) telefono " &
               ", nvl(sum(fpdescbs),0) mdescuento " &
               ", sum(fpimnebs) mtotal " &
               ", (sum(fpimnebs) - nvl(sum(fpdescbs),0)) msubtotal " &
               ", sum( fpimneus) mdolar " &
               "from affacsub,outer afclient,outer ruc_cliente  " &
               "where fptipfac = '93014' and " &
               "fpcodcli=clcodcli and " &
               "fpcodcli=codigo  and " &
               "fpcodcon='16300' and " &
               "fpfechaf='" & fecha.ToShortDateString & "' " &
                "group by 1,2,3,4,5,6, 7, 8 " &
               "order by fpnrofac"
    End Function

    Public Shared Function cuerpoDescarteUno(ByVal fecha As Date, ByVal nrodoc As String) As String
        Return "select fpcodcon, sum(fpcantid) cant, 'DESCARTES' detalle, " &
               "sum(fpimnebs)/sum(fpcantid) precio, " &
               "sum(fpimnebs) monto " &
               ", nvl(sum(fpdescbs),0) descuento " &
               ", (select (select trim(padescri) from afparame pr where pr.pacodigo= pa.pavalor1) " &
               "from afparame pa where pa.pacodigo=fpcodcon) umedida " &
               ", (sum(fpimnebs)-nvl(sum(fpdescbs),0)) subtotal " &
               "from affacsub " &
               "where fpcodcon='16300' and " &
               "fptipfac = '93014' and " &
               "fpnrofac=" & nrodoc & " And " &
               "fpfechaf='" & fecha.ToShortDateString & "' " &
               "group by fpcodcon"
    End Function

    '__________________________________ # Calculo facturacion para ventas de descarte 2
    Public Shared Function cabDescarteDos(ByVal fecha As Date) As String
        Return "select UNIQUE fpfechaf,fptipfac,fpnrofac,  trim(clnombre) clnombre, trim(clapelli) clapelli, trim(ruc) ruc " &
               ", trim(cldirecc) direccion " &
               ", trim(cltelcli) telefono " &
               ", nvl(sum(fpdescbs),0) mdescuento " &
               ", sum(fpimnebs) mtotal " &
               ", (sum(fpimnebs) - nvl(sum(fpdescbs),0)) msubtotal " &
               ", sum( fpimneus) mdolar " &
               "from affacsub,outer afclient,outer ruc_cliente  " &
               "where fptipfac = '93014' and " &
               "fpcodcli=clcodcli and " &
               "fpcodcli=codigo  and  " &
               "fpcodcon='16302' and  " &
               "fpfechaf='" & fecha.ToShortDateString & "'  " &
                "group by 1,2,3,4,5,6, 7, 8 " &
               "order by fpnrofac"
    End Function

    Public Shared Function cuerpoDescarteDos(ByVal fecha As Date, ByVal nrodoc As String) As String
        Return "select fpcodcon, sum(fpcantid) cant, 'DESCARTES' detalle," &
               "sum(fpimnebs)/sum(fpcantid) precio, sum(fpimnebs) monto " &
               ", nvl(sum(fpdescbs),0) descuento " &
               ", (select (select trim(padescri) from afparame pr where pr.pacodigo= pa.pavalor1) " &
               "from afparame pa where pa.pacodigo=fpcodcon) umedida " &
               ", (sum(fpimnebs)-nvl(sum(fpdescbs),0)) subtotal " &
               "from affacsub " &
               "where fpcodcon='16302' and " &
               "fptipfac='93014' and " &
               "fpnrofac=" & nrodoc & " and " &
               "fpfechaf='" & fecha.ToShortDateString & "' " &
               "group by fpcodcon"
    End Function


    '__________________________________ # Calculo facturacion para ventas de descarte 3
    Public Shared Function cabDescarteTres(ByVal fecha As Date) As String
        Return "select UNIQUE fpfechaf,fptipfac,fpnrofac,  trim(clnombre) clnombre, trim(clapelli) clapelli, trim(ruc) ruc " &
               ", trim(cldirecc) direccion " &
               ", trim(cltelcli) telefono " &
               ", nvl(sum(fpdescbs),0) mdescuento " &
               ", sum(fpimnebs) mtotal " &
               ", (sum(fpimnebs) - nvl(sum(fpdescbs),0)) msubtotal " &
               ", sum( fpimneus) mdolar " &
               "from affacsub,outer afclient,outer ruc_cliente " &
               "where fptipfac = '93014' and " &
               "fpcodcli=clcodcli and " &
               "fpcodcli=codigo and " &
               "fpcodcon in ('16084','16029','16066','16070','16080','16090', " &
                            "'16116','16519','16520','16521','16008','16517') " &
               "and fpfechaf='" & fecha.ToShortDateString & "' " &
                "group by 1,2,3,4,5,6, 7,8 " &
               "order by fpnrofac"
    End Function

    Public Shared Function cuerpoDescarteTres(ByVal fecha As Date, ByVal nrodoc As String) As String
        Return "select fpcodcon, sum(fpcantid) cant, 'DESCARTES' detalle, " &
               "sum(fpimnebs)/sum(fpcantid) precio, " &
               "sum(fpimnebs) monto " &
               ", nvl(sum(fpdescbs),0) descuento " &
               ", (select (select trim(padescri) from afparame pr where pr.pacodigo= pa.pavalor1) " &
               "from afparame pa where pa.pacodigo=fpcodcon) umedida " &
               ", (sum(fpimnebs)-nvl(sum(fpdescbs),0)) subtotal " &
               "from affacsub " &
               "where fpcodcon in ('16084','16029','16066','16070','16080','16090', " &
               "'16079','16116','16519','16520','16521','16008','16517')  and " &
               "fptipfac = '93014' and " &
               "fpnrofac=" & nrodoc & "  and " &
               "fpfechaf='" & fecha.ToShortDateString & "' " &
               "group by fpcodcon"
    End Function


    '__________________________________ # Calculo facturacion servicio de acopio hiel
    Public Shared Function cabSevAcopioHiel(ByVal fecha As Date) As String
        Return "select UNIQUE fpfechaf,fptipfac,fpnrofac,  trim(clnombre) clnombre, trim(clapelli) clapelli, trim(ruc) ruc " &
               ", trim(cldirecc) direccion " &
               ", trim(cltelcli) telefono " &
               ", nvl(sum(fpdescbs),0) mdescuento " &
               ", sum(fpimnebs) mtotal " &
               ", (sum(fpimnebs) - nvl(sum(fpdescbs),0)) msubtotal " &
               ", sum( fpimneus) mdolar " &
               "from affacsub,outer afclient,outer ruc_cliente " &
               "where " &
               "fptipfac = '93014' and " &
               "fpcodcli=clcodcli and " &
               "fpcodcli=codigo  and " &
               "(fpcodcon='16726' or fpcodcon='16088' ) and " &
               "fpfechaf='" & fecha.ToShortDateString & "' " &
               "group by 1,2,3,4,5,6, 7, 8 " &
               "order by fpnrofac"
    End Function

    Public Shared Function cuerpoSerAcopioHiel(ByVal fecha As Date, ByVal nrodoc As String) As String
        Return "select fpcodcon, sum(fpcantid) cant, 'HIEL' detalle, " &
                   "sum(fpimnebs)/sum(fpcantid) precio, " &
                   "sum(fpimnebs) monto " &
                   ", nvl(sum(fpdescbs),0) descuento " &
                   ", (select (select trim(padescri) from afparame pr where pr.pacodigo= pa.pavalor1) " &
                   "from afparame pa where pa.pacodigo=fpcodcon) umedida " &
                   ", (sum(fpimnebs)-nvl(sum(fpdescbs),0)) subtotal " &
               "from affacsub " &
               "where fpcodcon='16088' and fptipfac = '93014' and " &
               "fpnrofac=" & nrodoc & "  and " &
               "fpfechaf='" & fecha.ToShortDateString & "' " &
               "group by fpcodcon " &
               "union " &
               "select  fpcodcon, sum(fpcantid) cant, 'SERVICIO DE ACOPIO (HIEL)' detalle, " &
                   "sum(fpimnebs)/sum(fpcantid) precio, " &
                   "sum(fpimnebs) monto " &
                   ", nvl(sum(fpdescbs),0) descuento " &
                   ", (select (select trim(padescri) from afparame pr where pr.pacodigo= pa.pavalor1) " &
                   "from afparame pa where pa.pacodigo=fpcodcon) umedida " &
                   ", (sum(fpimnebs)-nvl(sum(fpdescbs),0)) subtotal " &
               "from affacsub " &
               "where fpcodcon='16726' and fptipfac = '93014' and " &
               "fpnrofac=" & nrodoc & "  and " &
               "fpfechaf='" & fecha.ToShortDateString & "' " &
               "group by fpcodcon"
    End Function

    '__________________________________ # Calculo facturacion bolsas carne industrial
    Public Shared Function cabBolsasCarneIndustrial(ByVal fecha As Date) As String
        Return "select UNIQUE fpfechaf,fptipfac,fpnrofac,  trim(clnombre) clnombre, trim(clapelli) clapelli, trim(ruc) ruc " &
               ", trim(cldirecc) direccion " &
               ", trim(cltelcli) telefono " &
               ", nvl(sum(fpdescbs),0) mdescuento " &
               ", sum(fpimnebs) mtotal " &
               ", (sum(fpimnebs) - nvl(sum(fpdescbs),0)) msubtotal " &
               ", sum( fpimneus) mdolar " &
               "from affacsub,outer afclient,outer ruc_cliente " &
               "where " &
               "fptipfac = '93014' and " &
               "fpcodcli=clcodcli and " &
               "fpcodcli=codigo  and " &
               "fpcodcon='08012' and " &
               "fpcantid>0 and " &
               "fpfechaf='" & fecha.ToShortDateString & "' " &
               "group by 1,2,3,4,5,6, 7,8 " &
               "order by fpnrofac"
    End Function

    Public Shared Function cuerpoBolsasCarneIndustrial(ByVal fecha As Date, ByVal nrodoc As String) As String
        Return "select fpcodcon, sum(fpcantid) cant, 'BOLSAS' detalle, " &
               "sum(fpimnebs)/sum(fpcantid) precio,  " &
               "sum(fpimnebs) monto  " &
               ", nvl(sum(fpdescbs),0) descuento " &
               ", (select (select trim(padescri) from afparame pr where pr.pacodigo= pa.pavalor1) " &
               "from afparame pa where pa.pacodigo=fpcodcon) umedida " &
               ", (sum(fpimnebs)-nvl(sum(fpdescbs),0)) subtotal " &
               "from affacsub  " &
               "where fpcodcon='08012' and  " &
               "fptipfac = '93014' and  " &
               "fpnrofac=" & nrodoc & "  and  " &
               "fpfechaf='" & fecha.ToShortDateString & "' " &
               "group by fpcodcon"
    End Function

    '__________________________________ #SERVICIO LAVADO MENUDO PORCINO
    Public Shared Function cabServicioMenudoPorcino(ByVal fecha As Date) As String
        Return "select UNIQUE fpfechaf,fptipfac,fpnrofac,  trim(clnombre) clnombre, trim(clapelli) clapelli, trim(ruc) ruc " &
               ", trim(cldirecc) direccion " &
               ", trim(cltelcli) telefono " &
               ", nvl(sum(fpdescbs),0) mdescuento " &
               ", sum(fpimnebs) mtotal " &
               ", (sum(fpimnebs) - nvl(sum(fpdescbs),0)) msubtotal " &
               ", sum( fpimneus) mdolar " &
               "from affacsub,outer afclient,outer ruc_cliente " &
               "where fptipfac = '93064' and " &
               "fpcodcli=clcodcli and " &
               "fpcodcli=codigo  and " &
               "fpcodcon='47008' and " &
               "fpfechaf='" & fecha.ToShortDateString & "' " &
               "group by 1,2,3,4,5,6 , 7,8 " &
               "order by fpnrofac"
    End Function

    Public Shared Function cuerpoServicioMenudoPorcino(ByVal fecha As Date, ByVal nrodoc As String) As String
        Return "select fpcodcon, sum(fpcantid) cant, 'SERVICIO LAVADO MENUDO PORCINO' detalle, " &
               "sum(fpimnebs)/sum(fpcantid) precio, " &
               "sum(fpimnebs) monto " &
               ", nvl(sum(fpdescbs),0) descuento " &
               ", (select (select trim(padescri) from afparame pr where pr.pacodigo= pa.pavalor1) " &
               "from afparame pa where pa.pacodigo=fpcodcon) umedida " &
               ", (sum(fpimnebs)-nvl(sum(fpdescbs),0)) subtotal " &
               "from  affacsub " &
               "where fpcodcon='47008' and " &
               "fptipfac = '93064' and " &
               "fpnrofac=" & nrodoc & "  and " &
               "fpfechaf='" & fecha.ToShortDateString & "' " &
               "group by fpcodcon"
    End Function

    '__________________________________ #FACTURACION CUEROS
    Public Shared Function cabCueros(ByVal fecha As Date) As String
        Return "select UNIQUE fpfechaf,'93070' fptipfac,fpnrofac,  trim(clnombre) clnombre, trim(clapelli) clapelli, trim(ruc) ruc " &
               ", trim(cldirecc) direccion " &
               ", trim(cltelcli) telefono " &
               ", nvl(sum(fpdescbs),0) mdescuento " &
               ", sum(fpimbrbs) mtotal " &
               ", (sum(fpimbrbs) - nvl(sum(fpdescbs),0)) msubtotal " &
               ", sum( fpimneus) mdolar " &
               "from  affacsub,outer  afclient,outer  ruc_cliente " &
               "where " &
               "fptipfac='93070' and " &
               "fpcodcli=clcodcli and " &
               "fpcodcli=codigo  and " &
               "fpfechaf='" & fecha.ToShortDateString & "' " &
               "group by 1,2,3,4,5,6 , 7,8 " &
               "order by fpnrofac"
    End Function

    Public Shared Function cuerpoCuerosLimpieza(ByVal fecha As Date, ByVal nrodoc As String) As String
        Return "select fpcodcon, sum(fpcantid) cant, 'SERVICIO LIMPIEZA CUERO' detalle, " &
               "sum(fpimbrbs)/sum(fpcantid) precio, " &
               "sum(fpimbrbs) monto " &
               ", nvl(sum(fpdescbs),0) descuento " &
               ", (select (select trim(padescri) from afparame pr where pr.pacodigo= pa.pavalor1) " &
               " from afparame pa where pa.pacodigo=fpcodcon) umedida " &
               ", (sum(fpimbrbs)-nvl(sum(fpdescbs),0)) subtotal " &
               "from  affacsub " &
               "where fptipfac='93070' and " &
               "fpnrofac=" & nrodoc & "  and " &
               "fpfechaf='" & fecha.ToShortDateString & "' and " &
               "fpcodcon='46016' " &
               "group by fpcodcon"
    End Function

    Public Shared Function cuerpoCuerosEnfriamiento(ByVal fecha As Date, ByVal nrodoc As String) As String
        Return "select fpcodcon, sum(fpcantid) cant,'SERV. DE ENFRIAMIENTO Y FUMIGADO DE CUEROS' detalle, " &
               "sum(fpimbrbs)/sum(fpcantid) precio, " &
               "sum(fpimbrbs) monto " &
               ", nvl(sum(fpdescbs),0) descuento " &
               ", (select (select trim(padescri) from afparame pr where pr.pacodigo= pa.pavalor1) " &
               "from afparame pa where pa.pacodigo=fpcodcon) umedida " &
               ", (sum(fpimbrbs)-nvl(sum(fpdescbs),0)) subtotal " &
               "from  affacsub " &
               "where fptipfac='93070' and " &
               "fpnrofac=" & nrodoc & " and " &
               "fpfechaf='" & fecha.ToShortDateString & "' and " &
               "fpcodcon='46889' " &
               "group by fpcodcon"
    End Function




End Class