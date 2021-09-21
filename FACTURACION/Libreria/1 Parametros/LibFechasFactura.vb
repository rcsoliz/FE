Imports Entidades
Public Class LibFechasFactura

    Public Shared Function alta(ByVal item As tb_FechasFactura) As String
        Return "insert into fechas_facturasfe (gestion, mes , estado) values(" & item.gestion & "," & item.mes & "," & item.estado & ")"
    End Function

    Public Shared Function update(ByVal item As tb_FechasFactura) As String
        Return "update fechas_facturasfe set estado=" & item.estado & " where gestion=" & item.gestion & " and mes=" & item.mes
    End Function

    Public Shared Function getGestion() As String
        Return "select gestion, " &
                "case when mes=1 then  'ENERO'  when mes=2 then 'FEBRERO' " &
                "when mes=3 then 'MARZO' when mes=4 then 'ABRIL' " &
                "when mes=5 then 'MAYO' when mes=6 then 'JUNIO' " &
                "when mes=7 then 'JULIO' when mes=8 then 'AGOSTO' " &
                "when mes=9 then 'SEPTIEMBRE' when mes=10 then 'OCTUBRE' " &
                "when mes=11 then 'NOVIEMBRE' " &
                "else 'DICIEMBRE' end descmes,  mes, " &
                "case when estado =0 then 'ABIERTO' " &
                "else 'CERRADO' end descestado, estado " &
                "from fechas_facturasfe order by gestion  desc, mes desc"
    End Function

    Public Shared Function getGestion(ByVal item As tb_FechasFactura) As String
        Return "select t gestion, " &
                "case when mes=1 then  'ENERO'  when mes=2 then 'FEBRERO' " &
                "when mes=3 then 'MARZO' when mes=4 then 'ABRIL' " &
                "when mes=5 then 'MAYO' when mes=6 then 'JUNIO' " &
                "when mes=7 then 'JULIO' when mes=8 then 'AGOSTO' " &
                "when mes=9 then 'SEPTIEMBRE' when mes=10 then 'OCTUBRE' " &
                "when mes=11 then 'NOVIEMBRE' " &
                "else 'DICIEMBRE' end descmes,  mes, " &
                "case when estado =0 then 'ABIERTO' " &
                "else 'CERRADO' end descestado, estado " &
                "from fechas_facturasfe where gestion=" & item.gestion & " gestion  desc, mes desc"
    End Function

    Public Shared Function getGestionYMes(ByVal item As tb_FechasFactura) As String
        Return "select gestion, mes, estado from fechas_facturasfe where gestion=" & item.gestion & " AND mes=" & item.mes & " order by gestion, mes"
    End Function

  

End Class
