Imports Entidades
Imports Libreria
Public Class clsCierreVentas : Inherits BaseDatos

#Region "[atributosGlobales]"

#End Region

#Region "[contrutor]"

    Protected Sub New(ByVal usuar As String, ByVal clav As String)
        MyBase.New()
        Call abrir_coneccion(usuar, clav)
    End Sub

    Protected Sub New(ByVal dtConexio As DataTable)
        MyBase.New()
        Call abrir_coneccion(dtConexio)
    End Sub

#End Region

#Region "[metodos]"

    Public Function getCotizacion(ByVal fecha As Date) As Decimal
        Using dt As New DataTable
            Dim valor As Decimal = Decimal.Zero
            Dim consulta As String = String.Empty
            Try
                consulta = LibGlobal.getCotizacion(fecha)
                comando.CommandText = consulta
                conector.Fill(dt)
                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows(0).Item("fecha")) Then
                        valor = dt.Rows(0).Item("fecha")
                    End If
                End If
            Catch ex As Exception
                set_error("Fallo en clsPreFactura:: getCotizacion " & vbNewLine & consulta, ex.Message)
            End Try
            Return valor
        End Using
    End Function

    Public Function altaLiqProveedor(ByVal fecha As Date, ByVal tCambio As Decimal, ByVal usuario As String) As Boolean
        Dim consulta As String = String.Empty
        Try
            Using dtSebos As New DataTable
                consulta = LibVentas.cabLiqProveedor(fecha)
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dtSebos)
                '-- 1.- estado -> 0      anulado -> 1 pediente      2 -> facturado	
                Dim listaCab As New List(Of Entidades.tb_CabVentas)()
                For Each fila As DataRow In dtSebos.Rows 'lqfechal, lqtipliq, lqnroliq, prnombre, prapelli, ruc
                    Dim ruc As Decimal = If(IsDBNull(fila.Item("ruc")), Decimal.Zero, fila.Item("ruc"))

                    Dim item As New Entidades.tb_CabVentas With {.tipomov = fila.Item("lqtipliq"), .nummov = fila.Item("lqnroliq"),
                                                                     .fechamov = fila.Item("lqfechal"),
                                                                     .nombre = IIf((fila.Item("prnombre") Is DBNull.Value), String.Empty, fila.Item("prnombre")),
                                                                     .apellido = IIf((fila.Item("prapelli") Is DBNull.Value), String.Empty, fila.Item("prapelli")),
                                                                     .ci_ruc = ruc,
                                                                     .telefono = IIf((fila.Item("telefono") Is DBNull.Value), String.Empty, fila.Item("telefono")),
                                                                     .direccion = IIf((fila.Item("direccion") Is DBNull.Value), String.Empty, fila.Item("direccion")),
                                                                     .pais = "",
                                                                     .email = "",
                                                                     .arancel = "",
                                                                     .lugentrega = "", .fob_fca = "", .plazopago = "",
                                                                     .pesobruto = Decimal.Zero, .pesoneto = Decimal.Zero, .pedido = Decimal.Zero,
                                                                     .proforma = Decimal.Zero, .moneda = "28002", .estado = "1", .tipocambio = tCambio,
                                                                     .mdescuento = IIf((fila.Item("mdescuento") Is DBNull.Value), Decimal.Zero, fila.Item("mdescuento")),
                                                                     .mtotal = IIf((fila.Item("mtotal") Is DBNull.Value), Decimal.Zero, fila.Item("mtotal")),
                                                                     .msubtotal = IIf((fila.Item("msubtotal") Is DBNull.Value), Decimal.Zero, fila.Item("msubtotal")),
                                                                     .mdolar = IIf((fila.Item("mdolar") Is DBNull.Value), Decimal.Zero, fila.Item("mdolar")),
                                                                     .usuario = usuario}
                    listaCab.Add(item)
                Next
                'recorro todos las cabeceras
                For Each item As tb_CabVentas In listaCab
                    consulta = LibCierreVentas.altaCabPreFactura(item)
                    comando.CommandText = consulta
                    comando.ExecuteNonQuery()
                    Using dtCuerpo As New DataTable
                        'obtengo los cuerpos por cabecera
                        consulta = LibVentas.cuerpoLiqProveedor(fecha, item.nummov)
                        comando.CommandText = consulta
                        conector.Fill(dtCuerpo)

                        Dim posicion As Integer = 1
                        For Each fila As DataRow In dtCuerpo.Rows
                            Dim iCuerpo As New tb_CueVentas With {.posicion = posicion, .tipomov = item.tipomov, .nummov = item.nummov,
                                                                      .nroitem = IIf((fila.Item("lqcodcon") Is DBNull.Value), Decimal.Zero, fila.Item("lqcodcon")),
                                                                      .kilos = Decimal.Zero,
                                                                      .unidmedida = IIf((fila.Item("umedida") Is DBNull.Value), Decimal.Zero, fila.Item("umedida")),
                                                                      .cantidad = IIf((fila.Item("cant") Is DBNull.Value), Decimal.Zero, fila.Item("cant")),
                                                                      .detalle = IIf((fila.Item("detalle") Is DBNull.Value), Nothing, fila.Item("detalle")),
                                                                      .preciobs = IIf((fila.Item("precio") Is DBNull.Value), Decimal.Zero, fila.Item("precio")),
                                                                      .descuentobs = IIf((fila.Item("descuento") Is DBNull.Value), Decimal.Zero, fila.Item("descuento")),
                                                                      .importebs = IIf((fila.Item("monto") Is DBNull.Value), Decimal.Zero, fila.Item("monto")),
                                                                      .subtotal = IIf((fila.Item("subtotal") Is DBNull.Value), Decimal.Zero, fila.Item("subtotal"))}
                            If iCuerpo.importebs > 0 Then
                                consulta = LibCierreVentas.altaCuepPreFactura(iCuerpo)
                                comando.CommandType = CommandType.Text
                                comando.CommandText = consulta
                                comando.ExecuteNonQuery()
                                posicion = posicion + 1
                            End If
                        Next
                    End Using
                Next
            End Using
            Return True
        Catch ex As Exception
            set_error("Fallo en clsPreFactura:: altaLiqProveedor " & vbNewLine & consulta, ex.Message)
        End Try
        Return False
    End Function

    Public Function altaLimpiezaMenudos(ByVal fecha As Date, ByVal tCambio As Decimal, ByVal usuario As String) As Boolean
        Dim consulta As String = String.Empty
        Try
            Using dtSebos As New DataTable
                consulta = LibVentas.cabLimpiezaMenudo(fecha)
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dtSebos)
                '-- 1.- estado -> 0      anulado -> 1 pediente      2 -> facturado	
                Dim listaCab As New List(Of Entidades.tb_CabVentas)()
                For Each fila As DataRow In dtSebos.Rows 'select fpfechaf,fptipfac,fpnrofac,clnombre,clapelli,ruc
                    Dim item As New Entidades.tb_CabVentas With {.tipomov = fila.Item("fptipfac"), .nummov = fila.Item("fpnrofac"),
                                                                 .fechamov = fila.Item("fpfechaf"),
                                                                 .nombre = IIf((fila.Item("clnombre") Is DBNull.Value), String.Empty, fila.Item("clnombre")),
                                                                 .apellido = IIf((fila.Item("clapelli") Is DBNull.Value), String.Empty, fila.Item("clapelli")),
                                                                 .ci_ruc = If(IsDBNull(fila.Item("ruc")), String.Empty, fila.Item("ruc")),
                                                                 .telefono = IIf((fila.Item("telefono") Is DBNull.Value), String.Empty, fila.Item("telefono")),
                                                                 .direccion = IIf((fila.Item("direccion") Is DBNull.Value), String.Empty, fila.Item("direccion")),
                                                                 .pais = "",
                                                                 .email = "",
                                                                 .arancel = "",
                                                                 .lugentrega = "", .fob_fca = "", .plazopago = "",
                                                                 .pesobruto = Decimal.Zero, .pesoneto = Decimal.Zero, .pedido = Decimal.Zero,
                                                                 .proforma = Decimal.Zero, .moneda = "28002", .estado = "1", .tipocambio = tCambio,
                                                                 .mdescuento = IIf((fila.Item("mdescuento") Is DBNull.Value), Decimal.Zero, fila.Item("mdescuento")),
                                                                 .mtotal = IIf((fila.Item("mtotal") Is DBNull.Value), Decimal.Zero, fila.Item("mtotal")),
                                                                 .msubtotal = IIf((fila.Item("msubtotal") Is DBNull.Value), Decimal.Zero, fila.Item("msubtotal")),
                                                                 .mdolar = IIf((fila.Item("mdolar") Is DBNull.Value), Decimal.Zero, fila.Item("mdolar")),
                                                                 .usuario = usuario}
                    listaCab.Add(item)
                Next
                'recorro todos las cabeceras
                For Each item As tb_CabVentas In listaCab
                    consulta = LibCierreVentas.altaCabPreFactura(item)
                    comando.CommandText = consulta
                    comando.ExecuteNonQuery()
                    Using dtCuerpo As New DataTable
                        'obtengo los cuerpos por cabecera
                        consulta = LibVentas.cuerpoLimpiezaMenudo(fecha, item.nummov)
                        comando.CommandText = consulta
                        conector.Fill(dtCuerpo)

                        Dim posicion As Integer = 1
                        For Each fila As DataRow In dtCuerpo.Rows
                            Dim iCuerpo As New tb_CueVentas With {.posicion = posicion, .tipomov = item.tipomov, .nummov = item.nummov,
                                                                      .nroitem = IIf((fila.Item("fpcodcon") Is DBNull.Value), Decimal.Zero, fila.Item("fpcodcon")),
                                                                      .kilos = Decimal.Zero,
                                                                      .unidmedida = IIf((fila.Item("umedida") Is DBNull.Value), Decimal.Zero, fila.Item("umedida")),
                                                                      .cantidad = IIf((fila.Item("cant") Is DBNull.Value), Decimal.Zero, fila.Item("cant")),
                                                                      .undmedida = "", .detalle = fila.Item("detalle"),
                                                                      .preciobs = IIf((fila.Item("precio") Is DBNull.Value), Decimal.Zero, fila.Item("precio")),
                                                                      .descuentobs = IIf((fila.Item("descuento") Is DBNull.Value), Decimal.Zero, fila.Item("descuento")),
                                                                      .importebs = IIf((fila.Item("monto") Is DBNull.Value), Decimal.Zero, fila.Item("monto")),
                                                                      .subtotal = IIf((fila.Item("subtotal") Is DBNull.Value), Decimal.Zero, fila.Item("subtotal"))}
                            If iCuerpo.importebs > 0 Then
                                consulta = LibCierreVentas.altaCuepPreFactura(iCuerpo)
                                comando.CommandType = CommandType.Text
                                comando.CommandText = consulta
                                comando.ExecuteNonQuery()
                                posicion = posicion + 1
                            End If
                        Next
                    End Using
                Next
            End Using
            Return True
        Catch ex As Exception
            set_error("Fallo en clsPreFactura:: altaLimpiezaMenudos " & vbNewLine & consulta, ex.Message)
        End Try
        Return False
    End Function


    Public Function altaVentaSebos(ByVal fecha As Date, ByVal tCambio As Decimal, ByVal usuario As String) As Boolean
        Dim consulta As String = String.Empty
        Try
            Using dtSebos As New DataTable
                consulta = LibVentas.cabSebos(fecha)
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dtSebos)
                '-- 1.- estado -> 0      anulado -> 1 pediente      2 -> facturado	
                Dim listaCab As New List(Of Entidades.tb_CabVentas)()
                For Each fila As DataRow In dtSebos.Rows 'select UNIQUE fpfechaf,fptipfac,fpnrofac,clnombre,clapelli,ruc
                    Dim item As New Entidades.tb_CabVentas With {.tipomov = fila.Item("fptipfac"), .nummov = fila.Item("fpnrofac"),
                                                                 .fechamov = fila.Item("fpfechaf"),
                                                                 .nombre = IIf((fila.Item("clnombre")) Is DBNull.Value, Nothing, fila.Item("clnombre")),
                                                                 .apellido = IIf((fila.Item("clapelli")) Is DBNull.Value, Nothing, fila.Item("clapelli")),
                                                                 .ci_ruc = IIf((fila.Item("ruc") Is DBNull.Value), Nothing, fila.Item("ruc")),
                                                                 .telefono = IIf((fila.Item("telefono") Is DBNull.Value), String.Empty, fila.Item("telefono")),
                                                                 .direccion = IIf((fila.Item("direccion") Is DBNull.Value), String.Empty, fila.Item("direccion")),
                                                                 .pais = "",
                                                                 .email = "",
                                                                 .arancel = "",
                                                                 .lugentrega = "", .fob_fca = "", .plazopago = "",
                                                                 .pesobruto = Decimal.Zero, .pesoneto = Decimal.Zero, .pedido = Decimal.Zero,
                                                                 .proforma = Decimal.Zero, .moneda = "28002", .estado = "1", .tipocambio = tCambio,
                                                                 .mdescuento = IIf((fila.Item("mdescuento") Is DBNull.Value), Decimal.Zero, fila.Item("mdescuento")),
                                                                 .mtotal = IIf((fila.Item("mtotal") Is DBNull.Value), Decimal.Zero, fila.Item("mtotal")),
                                                                 .msubtotal = IIf((fila.Item("msubtotal") Is DBNull.Value), Decimal.Zero, fila.Item("msubtotal")),
                                                                 .mdolar = IIf((fila.Item("mdolar") Is DBNull.Value), Decimal.Zero, fila.Item("mdolar")),
                                                                 .usuario = usuario}
                    listaCab.Add(item)
                Next
                'recorro todos las cabeceras
                For Each item As tb_CabVentas In listaCab
                    consulta = LibCierreVentas.altaCabPreFactura(item)
                    comando.CommandText = consulta
                    comando.ExecuteNonQuery()
                    Using dtCuerpo As New DataTable
                        'obtengo los cuerpos por cabecera
                        consulta = LibVentas.cuerpoSebos(fecha, item.nummov)
                        comando.CommandText = consulta
                        conector.Fill(dtCuerpo)

                        Dim posicion As Integer = 1
                        For Each fila As DataRow In dtCuerpo.Rows
                            Dim iCuerpo As New tb_CueVentas With {.posicion = posicion, .tipomov = item.tipomov, .nummov = item.nummov,
                                                                      .nroitem = IIf((fila.Item("fpcodcon") Is DBNull.Value), Decimal.Zero, fila.Item("fpcodcon")),
                                                                      .kilos = Decimal.Zero,
                                                                      .unidmedida = IIf((fila.Item("umedida") Is DBNull.Value), Decimal.Zero, fila.Item("umedida")),
                                                                      .cantidad = IIf((fila.Item("cant") Is DBNull.Value), Decimal.Zero, fila.Item("cant")),
                                                                      .undmedida = IIf((fila.Item("umedida") Is DBNull.Value), "", fila.Item("umedida")),
                                                                      .detalle = IIf((fila.Item("detalle") Is DBNull.Value), Nothing, fila.Item("detalle")),
                                                                      .preciobs = IIf((fila.Item("precio") Is DBNull.Value), Decimal.Zero, fila.Item("precio")),
                                                                      .descuentobs = IIf((fila.Item("descuento") Is DBNull.Value), Decimal.Zero, fila.Item("descuento")),
                                                                      .importebs = IIf((fila.Item("monto") Is DBNull.Value), Decimal.Zero, fila.Item("monto")),
                                                                      .subtotal = IIf((fila.Item("subtotal") Is DBNull.Value), Decimal.Zero, fila.Item("subtotal"))}
                            If iCuerpo.importebs > 0 Then
                                consulta = LibCierreVentas.altaCuepPreFactura(iCuerpo)
                                comando.CommandType = CommandType.Text
                                comando.CommandText = consulta
                                comando.ExecuteNonQuery()
                                posicion = posicion + 1
                            End If
                        Next
                    End Using
                Next
            End Using
            Return True
        Catch ex As Exception
            set_error("Fallo en clsPreFactura:: altaVentaAffacsub " & vbNewLine & consulta, ex.Message)
        End Try
        Return False
    End Function

    Public Function altaVentaSangreFetal(ByVal fecha As Date, ByVal tCambio As Decimal, ByVal usuario As String) As Boolean
        Dim consulta As String = String.Empty
        Try
            Using dtSangreFetal As New DataTable
                consulta = LibVentas.cabSangreFetal(fecha)
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dtSangreFetal)
                '-- 1.- estado -> 0      anulado -> 1 pediente      2 -> facturado	
                Dim listaCab As New List(Of Entidades.tb_CabVentas)()
                For Each fila As DataRow In dtSangreFetal.Rows 'select UNIQUE fpfechaf,fptipfac,fpnrofac,clnombre,clapelli,ruc
                    Dim item As New Entidades.tb_CabVentas With {.tipomov = fila.Item("fptipfac"), .nummov = fila.Item("fpnrofac"),
                                                                 .fechamov = fila.Item("fpfechaf"),
                                                                 .nombre = IIf((fila.Item("clnombre") Is DBNull.Value), Nothing, fila.Item("clnombre")),
                                                                 .apellido = IIf((fila.Item("clapelli") Is DBNull.Value), Nothing, fila.Item("clapelli")),
                                                                 .ci_ruc = IIf((fila.Item("ruc") Is DBNull.Value), Nothing, fila.Item("ruc")),
                                                                 .telefono = IIf((fila.Item("telefono") Is DBNull.Value), String.Empty, fila.Item("telefono")),
                                                                 .direccion = IIf((fila.Item("direccion") Is DBNull.Value), String.Empty, fila.Item("direccion")),
                                                                 .pais = "",
                                                                 .email = "",
                                                                 .arancel = "",
                                                                 .lugentrega = "", .fob_fca = "", .plazopago = "",
                                                                 .pesobruto = Decimal.Zero, .pesoneto = Decimal.Zero, .pedido = Decimal.Zero,
                                                                 .proforma = Decimal.Zero, .moneda = "28002", .estado = "1", .tipocambio = tCambio,
                                                                 .mdescuento = IIf((fila.Item("mdescuento") Is DBNull.Value), Decimal.Zero, fila.Item("mdescuento")),
                                                                 .mtotal = IIf((fila.Item("mtotal") Is DBNull.Value), Decimal.Zero, fila.Item("mtotal")),
                                                                 .msubtotal = IIf((fila.Item("msubtotal") Is DBNull.Value), Decimal.Zero, fila.Item("msubtotal")),
                                                                 .mdolar = IIf((fila.Item("mdolar") Is DBNull.Value), Decimal.Zero, fila.Item("mdolar")),
                                                                 .usuario = usuario}
                    listaCab.Add(item)
                Next
                'recorro todos las cabeceras
                For Each item As tb_CabVentas In listaCab
                    consulta = LibCierreVentas.altaCabPreFactura(item)
                    comando.CommandText = consulta
                    comando.ExecuteNonQuery()
                    Using dtCuerpo As New DataTable
                        'obtengo los cuerpos por cabecera
                        consulta = LibVentas.cuerpoSangreFetal(fecha, item.nummov)
                        comando.CommandText = consulta
                        conector.Fill(dtCuerpo)

                        Dim posicion As Integer = 1
                        For Each fila As DataRow In dtCuerpo.Rows
                            Dim iCuerpo As New tb_CueVentas With {.posicion = posicion, .tipomov = item.tipomov, .nummov = item.nummov,
                                                                      .nroitem = IIf((fila.Item("fpcodcon") Is DBNull.Value), Decimal.Zero, fila.Item("fpcodcon")),
                                                                      .kilos = Decimal.Zero,
                                                                      .unidmedida = IIf((fila.Item("umedida") Is DBNull.Value), Decimal.Zero, fila.Item("umedida")),
                                                                      .cantidad = IIf((fila.Item("cant") Is DBNull.Value), Decimal.Zero, fila.Item("cant")),
                                                                      .undmedida = "",
                                                                      .detalle = IIf((fila.Item("detalle") Is DBNull.Value), Nothing, fila.Item("detalle")),
                                                                      .preciobs = IIf((fila.Item("precio") Is DBNull.Value), Decimal.Zero, fila.Item("precio")),
                                                                      .descuentobs = IIf((fila.Item("descuento") Is DBNull.Value), Decimal.Zero, fila.Item("descuento")),
                                                                      .importebs = IIf((fila.Item("monto") Is DBNull.Value), Decimal.Zero, fila.Item("monto")),
                                                                      .subtotal = IIf((fila.Item("subtotal") Is DBNull.Value), Decimal.Zero, fila.Item("subtotal"))}
                            If iCuerpo.importebs > 0 Then
                                consulta = LibCierreVentas.altaCuepPreFactura(iCuerpo)
                                comando.CommandType = CommandType.Text
                                comando.CommandText = consulta
                                comando.ExecuteNonQuery()
                                posicion = posicion + 1
                            End If
                        Next
                    End Using
                Next
            End Using
            Return True
        Catch ex As Exception
            set_error("Fallo en clsPreFactura:: altaVentaSangreFetal " & vbNewLine & consulta, ex.Message)
        End Try
        Return False
    End Function

    Public Function altaVentaDescarteUno(ByVal fecha As Date, ByVal tCambio As Decimal, ByVal usuario As String) As Boolean
        Dim consulta As String = String.Empty
        Try
            Using dtDescarteUno As New DataTable
                consulta = LibVentas.cabDescarteUno(fecha)
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dtDescarteUno)
                '-- 1.- estado -> 0      anulado -> 1 pediente      2 -> facturado	
                Dim listaCab As New List(Of Entidades.tb_CabVentas)()
                For Each fila As DataRow In dtDescarteUno.Rows 'select UNIQUE fpfechaf,fptipfac,fpnrofac,clnombre,clapelli,ruc
                    Dim item As New Entidades.tb_CabVentas With {.tipomov = fila.Item("fptipfac"), .nummov = fila.Item("fpnrofac"),
                                                                     .fechamov = fila.Item("fpfechaf"),
                                                                     .nombre = IIf((fila.Item("clnombre") Is DBNull.Value), Nothing, fila.Item("clnombre")),
                                                                     .apellido = IIf((fila.Item("clapelli") Is DBNull.Value), Nothing, fila.Item("clapelli")),
                                                                     .ci_ruc = IIf((fila.Item("ruc") Is DBNull.Value), Nothing, fila.Item("ruc")),
                                                                     .telefono = IIf((fila.Item("telefono") Is DBNull.Value), String.Empty, fila.Item("telefono")),
                                                                     .direccion = IIf((fila.Item("direccion") Is DBNull.Value), String.Empty, fila.Item("direccion")),
                                                                     .pais = "",
                                                                     .email = "",
                                                                     .arancel = "",
                                                                     .lugentrega = "", .fob_fca = "", .plazopago = "",
                                                                     .pesobruto = Decimal.Zero, .pesoneto = Decimal.Zero, .pedido = Decimal.Zero,
                                                                     .proforma = Decimal.Zero, .moneda = "28002", .estado = "1", .tipocambio = tCambio,
                                                                     .mdescuento = IIf((fila.Item("mdescuento") Is DBNull.Value), Decimal.Zero, fila.Item("mdescuento")),
                                                                     .mtotal = IIf((fila.Item("mtotal") Is DBNull.Value), Decimal.Zero, fila.Item("mtotal")),
                                                                     .msubtotal = IIf((fila.Item("msubtotal") Is DBNull.Value), Decimal.Zero, fila.Item("msubtotal")),
                                                                     .mdolar = IIf((fila.Item("mdolar") Is DBNull.Value), Decimal.Zero, fila.Item("mdolar")),
                                                                     .usuario = usuario}
                    listaCab.Add(item)
                Next
                'recorro todos las cabeceras
                For Each item As tb_CabVentas In listaCab
                    consulta = LibCierreVentas.altaCabPreFactura(item)
                    comando.CommandText = consulta
                    comando.ExecuteNonQuery()
                    Using dtCuerpo As New DataTable
                        'obtengo los cuerpos por cabecera
                        consulta = LibVentas.cuerpoDescarteUno(fecha, item.nummov)
                        comando.CommandText = consulta
                        conector.Fill(dtCuerpo)

                        Dim posicion As Integer = 1
                        For Each fila As DataRow In dtCuerpo.Rows
                            Dim iCuerpo As New tb_CueVentas With {.posicion = posicion, .tipomov = item.tipomov, .nummov = item.nummov,
                                                                      .nroitem = IIf((fila.Item("fpcodcon") Is DBNull.Value), Decimal.Zero, fila.Item("fpcodcon")),
                                                                      .kilos = Decimal.Zero,
                                                                      .unidmedida = IIf((fila.Item("umedida") Is DBNull.Value), Decimal.Zero, fila.Item("umedida")),
                                                                      .cantidad = IIf((fila.Item("cant") Is DBNull.Value), Decimal.Zero, fila.Item("cant")),
                                                                      .undmedida = "",
                                                                      .detalle = IIf((fila.Item("detalle") Is DBNull.Value), Nothing, fila.Item("detalle")),
                                                                      .preciobs = IIf((fila.Item("precio") Is DBNull.Value), Decimal.Zero, fila.Item("precio")),
                                                                      .descuentobs = IIf((fila.Item("descuento") Is DBNull.Value), Decimal.Zero, fila.Item("descuento")),
                                                                      .importebs = IIf((fila.Item("monto") Is DBNull.Value), Decimal.Zero, fila.Item("monto")),
                                                                      .subtotal = IIf((fila.Item("subtotal") Is DBNull.Value), Decimal.Zero, fila.Item("subtotal"))}
                            If iCuerpo.importebs > 0 Then
                                consulta = LibCierreVentas.altaCuepPreFactura(iCuerpo)
                                comando.CommandType = CommandType.Text
                                comando.CommandText = consulta
                                comando.ExecuteNonQuery()
                                posicion = posicion + 1
                            End If
                        Next
                    End Using
                Next
            End Using
            Return True
        Catch ex As Exception
            set_error("Fallo en clsPreFactura:: altaVentaDescarteUno " & vbNewLine & consulta, ex.Message)
        End Try
        Return False
    End Function

    Public Function altaVentaDescarteDos(ByVal fecha As Date, ByVal tCambio As Decimal, ByVal usuario As String) As Boolean
        Dim consulta As String = String.Empty
        Try
            Using dtDescarteUno As New DataTable
                consulta = LibVentas.cabDescarteDos(fecha)
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dtDescarteUno)
                '-- 1.- estado -> 0      anulado -> 1 pediente      2 -> facturado	
                Dim listaCab As New List(Of Entidades.tb_CabVentas)()
                For Each fila As DataRow In dtDescarteUno.Rows 'select UNIQUE fpfechaf,fptipfac,fpnrofac,clnombre,clapelli,ruc
                    Dim item As New Entidades.tb_CabVentas With {.tipomov = fila.Item("fptipfac"), .nummov = fila.Item("fpnrofac"),
                                                                 .fechamov = fila.Item("fpfechaf"),
                                                                 .nombre = IIf((fila.Item("clnombre") Is DBNull.Value), Nothing, fila.Item("clnombre")),
                                                                 .apellido = IIf((fila.Item("clapelli") Is DBNull.Value), Nothing, fila.Item("clapelli")),
                                                                 .ci_ruc = IIf((fila.Item("ruc") Is DBNull.Value), Nothing, fila.Item("ruc")),
                                                                 .telefono = IIf((fila.Item("telefono") Is DBNull.Value), String.Empty, fila.Item("telefono")),
                                                                 .direccion = IIf((fila.Item("direccion") Is DBNull.Value), String.Empty, fila.Item("direccion")),
                                                                 .pais = "",
                                                                 .email = "",
                                                                 .arancel = "",
                                                                 .lugentrega = "", .fob_fca = "", .plazopago = "",
                                                                 .pesobruto = Decimal.Zero, .pesoneto = Decimal.Zero, .pedido = Decimal.Zero,
                                                                 .proforma = Decimal.Zero, .moneda = "28002", .estado = "1", .tipocambio = tCambio,
                                                                 .mdescuento = IIf((fila.Item("mdescuento") Is DBNull.Value), Decimal.Zero, fila.Item("mdescuento")),
                                                                 .mtotal = IIf((fila.Item("mtotal") Is DBNull.Value), Decimal.Zero, fila.Item("mtotal")),
                                                                 .msubtotal = IIf((fila.Item("msubtotal") Is DBNull.Value), Decimal.Zero, fila.Item("msubtotal")),
                                                                 .mdolar = IIf((fila.Item("mdolar") Is DBNull.Value), Decimal.Zero, fila.Item("mdolar")),
                                                                 .usuario = usuario}
                    listaCab.Add(item)
                Next
                'recorro todos las cabeceras
                For Each item As tb_CabVentas In listaCab
                    consulta = LibCierreVentas.altaCabPreFactura(item)
                    comando.CommandText = consulta
                    comando.ExecuteNonQuery()
                    Using dtCuerpo As New DataTable
                        'obtengo los cuerpos por cabecera
                        consulta = LibVentas.cuerpoDescarteDos(fecha, item.nummov)
                        comando.CommandText = consulta
                        conector.Fill(dtCuerpo)

                        Dim posicion As Integer = 1
                        For Each fila As DataRow In dtCuerpo.Rows
                            Dim iCuerpo As New tb_CueVentas With {.posicion = posicion, .tipomov = item.tipomov, .nummov = item.nummov,
                                                                      .nroitem = IIf((fila.Item("fpcodcon") Is DBNull.Value), Decimal.Zero, fila.Item("fpcodcon")),
                                                                      .kilos = Decimal.Zero,
                                                                      .unidmedida = IIf((fila.Item("umedida") Is DBNull.Value), Decimal.Zero, fila.Item("umedida")),
                                                                      .cantidad = IIf((fila.Item("cant") Is DBNull.Value), Decimal.Zero, fila.Item("cant")),
                                                                      .undmedida = "",
                                                                      .detalle = IIf((fila.Item("detalle") Is DBNull.Value), Nothing, fila.Item("detalle")),
                                                                      .preciobs = IIf((fila.Item("precio") Is DBNull.Value), Decimal.Zero, fila.Item("precio")),
                                                                      .descuentobs = IIf((fila.Item("descuento") Is DBNull.Value), Decimal.Zero, fila.Item("descuento")),
                                                                      .importebs = IIf((fila.Item("monto") Is DBNull.Value), Decimal.Zero, fila.Item("monto")),
                                                                      .subtotal = IIf((fila.Item("subtotal") Is DBNull.Value), Decimal.Zero, fila.Item("subtotal"))}
                            If iCuerpo.importebs > 0 Then
                                consulta = LibCierreVentas.altaCuepPreFactura(iCuerpo)
                                comando.CommandType = CommandType.Text
                                comando.CommandText = consulta
                                comando.ExecuteNonQuery()
                                posicion = posicion + 1
                            End If
                        Next
                    End Using
                Next
            End Using
            Return True
        Catch ex As Exception
            set_error("Fallo en clsPreFactura:: altaVentaDescarteDos " & vbNewLine & consulta, ex.Message)
        End Try
        Return False
    End Function

    Public Function altaVentaDescarteTres(ByVal fecha As Date, ByVal tCambio As Decimal, ByVal usuario As String) As Boolean
        Dim consulta As String = String.Empty
        Try
            Using dtDescarteUno As New DataTable
                consulta = LibVentas.cabDescarteTres(fecha)
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dtDescarteUno)
                '-- 1.- estado -> 0      anulado -> 1 pediente      2 -> facturado	
                Dim listaCab As New List(Of Entidades.tb_CabVentas)()
                For Each fila As DataRow In dtDescarteUno.Rows 'select UNIQUE fpfechaf,fptipfac,fpnrofac,clnombre,clapelli,ruc
                    Dim item As New Entidades.tb_CabVentas With {.tipomov = fila.Item("fptipfac"), .nummov = fila.Item("fpnrofac"),
                                                                 .fechamov = fila.Item("fpfechaf"),
                                                                 .nombre = IIf((fila.Item("clnombre") Is DBNull.Value), Nothing, fila.Item("clnombre")),
                                                                 .apellido = IIf((fila.Item("clapelli") Is DBNull.Value), Nothing, fila.Item("clapelli")),
                                                                 .ci_ruc = IIf((fila.Item("ruc") Is DBNull.Value), Nothing, fila.Item("ruc")),
                                                                 .telefono = IIf((fila.Item("telefono") Is DBNull.Value), String.Empty, fila.Item("telefono")),
                                                                 .direccion = IIf((fila.Item("direccion") Is DBNull.Value), String.Empty, fila.Item("direccion")),
                                                                 .pais = "",
                                                                 .email = "",
                                                                 .arancel = "",
                                                                 .lugentrega = "", .fob_fca = "", .plazopago = "",
                                                                 .pesobruto = Decimal.Zero, .pesoneto = Decimal.Zero, .pedido = Decimal.Zero,
                                                                 .proforma = Decimal.Zero, .moneda = "28002", .estado = "1", .tipocambio = tCambio,
                                                                 .mdescuento = IIf((fila.Item("mdescuento") Is DBNull.Value), Decimal.Zero, fila.Item("mdescuento")),
                                                                 .mtotal = IIf((fila.Item("mtotal") Is DBNull.Value), Decimal.Zero, fila.Item("mtotal")),
                                                                 .msubtotal = IIf((fila.Item("msubtotal") Is DBNull.Value), Decimal.Zero, fila.Item("msubtotal")),
                                                                 .mdolar = IIf((fila.Item("mdolar") Is DBNull.Value), Decimal.Zero, fila.Item("mdolar")),
                                                                 .usuario = usuario}
                    listaCab.Add(item)
                Next
                'recorro todos las cabeceras
                For Each item As tb_CabVentas In listaCab
                    consulta = LibCierreVentas.altaCabPreFactura(item)
                    comando.CommandText = consulta
                    comando.ExecuteNonQuery()
                    Using dtCuerpo As New DataTable
                        'obtengo los cuerpos por cabecera
                        consulta = LibVentas.cuerpoDescarteTres(fecha, item.nummov)
                        comando.CommandText = consulta
                        conector.Fill(dtCuerpo)

                        Dim posicion As Integer = 1
                        For Each fila As DataRow In dtCuerpo.Rows
                            Dim iCuerpo As New tb_CueVentas With {.posicion = posicion, .tipomov = item.tipomov, .nummov = item.nummov,
                                                                      .nroitem = IIf((fila.Item("fpcodcon") Is DBNull.Value), Decimal.Zero, fila.Item("fpcodcon")),
                                                                      .kilos = Decimal.Zero,
                                                                      .unidmedida = IIf((fila.Item("umedida") Is DBNull.Value), Decimal.Zero, fila.Item("umedida")),
                                                                      .cantidad = IIf((fila.Item("cant") Is DBNull.Value), Decimal.Zero, fila.Item("cant")),
                                                                      .undmedida = "",
                                                                      .detalle = IIf((fila.Item("detalle") Is DBNull.Value), Nothing, fila.Item("detalle")),
                                                                      .preciobs = IIf((fila.Item("precio") Is DBNull.Value), Decimal.Zero, fila.Item("precio")),
                                                                      .descuentobs = IIf((fila.Item("descuento") Is DBNull.Value), Decimal.Zero, fila.Item("descuento")),
                                                                      .importebs = IIf((fila.Item("monto") Is DBNull.Value), Decimal.Zero, fila.Item("monto")),
                                                                      .subtotal = IIf((fila.Item("subtotal") Is DBNull.Value), Decimal.Zero, fila.Item("subtotal"))}
                            If iCuerpo.importebs > 0 Then
                                consulta = LibCierreVentas.altaCuepPreFactura(iCuerpo)
                                comando.CommandType = CommandType.Text
                                comando.CommandText = consulta
                                comando.ExecuteNonQuery()
                                posicion = posicion + 1
                            End If
                        Next
                    End Using
                Next
            End Using
            Return True
        Catch ex As Exception
            set_error("Fallo en clsPreFactura:: altaVentaDescarteTres " & vbNewLine & consulta, ex.Message)
        End Try
        Return False
    End Function

    Public Function altaServicioAcopioHiel(ByVal fecha As Date, ByVal tCambio As Decimal, ByVal usuario As String) As Boolean
        Dim consulta As String = String.Empty
        Try
            Using dtDescarteUno As New DataTable
                consulta = LibVentas.cabSevAcopioHiel(fecha)
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dtDescarteUno)
                '-- 1.- estado -> 0      anulado -> 1 pediente      2 -> facturado	
                Dim listaCab As New List(Of Entidades.tb_CabVentas)()
                For Each fila As DataRow In dtDescarteUno.Rows 'select UNIQUE fpfechaf,fptipfac,fpnrofac,clnombre,clapelli,ruc
                    Dim item As New Entidades.tb_CabVentas With {.tipomov = fila.Item("fptipfac"), .nummov = fila.Item("fpnrofac"),
                                                                 .fechamov = fila.Item("fpfechaf"),
                                                                 .nombre = IIf((fila.Item("clnombre") Is DBNull.Value), Nothing, fila.Item("clnombre")),
                                                                 .apellido = IIf((fila.Item("clapelli") Is DBNull.Value), Nothing, fila.Item("clapelli")),
                                                                 .ci_ruc = IIf((fila.Item("ruc") Is DBNull.Value), Nothing, fila.Item("ruc")),
                                                                 .telefono = IIf((fila.Item("telefono") Is DBNull.Value), String.Empty, fila.Item("telefono")),
                                                                 .direccion = IIf((fila.Item("direccion") Is DBNull.Value), String.Empty, fila.Item("direccion")),
                                                                 .pais = "",
                                                                 .email = "",
                                                                 .arancel = "",
                                                                 .lugentrega = "", .fob_fca = "", .plazopago = "",
                                                                 .pesobruto = Decimal.Zero, .pesoneto = Decimal.Zero, .pedido = Decimal.Zero,
                                                                 .proforma = Decimal.Zero, .moneda = "28002", .estado = "1", .tipocambio = tCambio,
                                                                 .mdescuento = IIf((fila.Item("mdescuento") Is DBNull.Value), Decimal.Zero, fila.Item("mdescuento")),
                                                                 .mtotal = IIf((fila.Item("mtotal") Is DBNull.Value), Decimal.Zero, fila.Item("mtotal")),
                                                                 .msubtotal = IIf((fila.Item("msubtotal") Is DBNull.Value), Decimal.Zero, fila.Item("msubtotal")),
                                                                 .mdolar = IIf((fila.Item("mdolar") Is DBNull.Value), Decimal.Zero, fila.Item("mdolar")),
                                                                 .usuario = usuario}
                    listaCab.Add(item)
                Next
                'recorro todos las cabeceras
                For Each item As tb_CabVentas In listaCab
                    consulta = LibCierreVentas.altaCabPreFactura(item)
                    comando.CommandText = consulta
                    comando.ExecuteNonQuery()
                    Using dtCuerpo As New DataTable
                        'obtengo los cuerpos por cabecera
                        consulta = LibVentas.cuerpoSerAcopioHiel(fecha, item.nummov)
                        comando.CommandText = consulta
                        conector.Fill(dtCuerpo)

                        Dim posicion As Integer = 1
                        For Each fila As DataRow In dtCuerpo.Rows
                            Dim iCuerpo As New tb_CueVentas With {.posicion = posicion, .tipomov = item.tipomov, .nummov = item.nummov,
                                                                      .nroitem = IIf((fila.Item("fpcodcon") Is DBNull.Value), Decimal.Zero, fila.Item("fpcodcon")),
                                                                      .kilos = Decimal.Zero,
                                                                      .unidmedida = IIf((fila.Item("umedida") Is DBNull.Value), Decimal.Zero, fila.Item("umedida")),
                                                                      .cantidad = IIf((fila.Item("cant") Is DBNull.Value), Decimal.Zero, fila.Item("cant")),
                                                                      .detalle = IIf((fila.Item("detalle") Is DBNull.Value), Nothing, fila.Item("detalle")),
                                                                      .preciobs = IIf((fila.Item("precio") Is DBNull.Value), Decimal.Zero, fila.Item("precio")),
                                                                      .descuentobs = IIf((fila.Item("descuento") Is DBNull.Value), Decimal.Zero, fila.Item("descuento")),
                                                                      .importebs = IIf((fila.Item("monto") Is DBNull.Value), Decimal.Zero, fila.Item("monto")),
                                                                      .subtotal = IIf((fila.Item("subtotal") Is DBNull.Value), Decimal.Zero, fila.Item("subtotal"))}
                            If iCuerpo.importebs > 0 Then
                                consulta = LibCierreVentas.altaCuepPreFactura(iCuerpo)
                                comando.CommandType = CommandType.Text
                                comando.CommandText = consulta
                                comando.ExecuteNonQuery()
                                posicion = posicion + 1
                            End If
                        Next
                    End Using
                Next
            End Using
            Return True
        Catch ex As Exception
            set_error("Fallo en clsPreFactura:: altaServicioAcopioHiel " & vbNewLine & consulta, ex.Message)
        End Try
        Return False
    End Function

    Public Function altaBosasCarneIndustrial(ByVal fecha As Date, ByVal tCambio As Decimal, ByVal usuario As String) As Boolean
        Dim consulta As String = String.Empty
        Try
            Using dtDescarteUno As New DataTable
                consulta = LibVentas.cabBolsasCarneIndustrial(fecha)
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dtDescarteUno)
                '-- 1.- estado -> 0      anulado -> 1 pediente      2 -> facturado	
                Dim listaCab As New List(Of Entidades.tb_CabVentas)()
                For Each fila As DataRow In dtDescarteUno.Rows 'select UNIQUE fpfechaf,fptipfac,fpnrofac,clnombre,clapelli,ruc
                    Dim item As New Entidades.tb_CabVentas With {.tipomov = fila.Item("fptipfac"), .nummov = fila.Item("fpnrofac"),
                                                                 .fechamov = fila.Item("fpfechaf"),
                                                                 .nombre = IIf((fila.Item("clnombre") Is DBNull.Value), Nothing, fila.Item("clnombre")),
                                                                 .apellido = IIf((fila.Item("clapelli") Is DBNull.Value), Nothing, fila.Item("clapelli")),
                                                                 .ci_ruc = IIf((fila.Item("ruc") Is DBNull.Value), Nothing, fila.Item("ruc")),
                                                                 .telefono = IIf((fila.Item("telefono") Is DBNull.Value), String.Empty, fila.Item("telefono")),
                                                                 .direccion = IIf((fila.Item("direccion") Is DBNull.Value), String.Empty, fila.Item("direccion")),
                                                                 .pais = "",
                                                                 .email = "",
                                                                 .arancel = "",
                                                                 .lugentrega = "",
                                                                 .fob_fca = "",
                                                                 .plazopago = "",
                                                                 .pesobruto = Decimal.Zero,
                                                                 .pesoneto = Decimal.Zero,
                                                                 .pedido = Decimal.Zero,
                                                                 .proforma = Decimal.Zero,
                                                                 .moneda = "28002", .estado = "1", .tipocambio = tCambio,
                                                                 .mdescuento = IIf((fila.Item("mdescuento") Is DBNull.Value), Decimal.Zero, fila.Item("mdescuento")),
                                                                 .mtotal = IIf((fila.Item("mtotal") Is DBNull.Value), Decimal.Zero, fila.Item("mtotal")),
                                                                 .msubtotal = IIf((fila.Item("msubtotal") Is DBNull.Value), Decimal.Zero, fila.Item("msubtotal")),
                                                                 .mdolar = IIf((fila.Item("mdolar") Is DBNull.Value), Decimal.Zero, fila.Item("mdolar")),
                                                                 .usuario = usuario}
                    listaCab.Add(item)
                Next
                'recorro todos las cabeceras
                For Each item As tb_CabVentas In listaCab
                    consulta = LibCierreVentas.altaCabPreFactura(item)
                    comando.CommandText = consulta
                    comando.ExecuteNonQuery()
                    Using dtCuerpo As New DataTable
                        'obtengo los cuerpos por cabecera
                        consulta = LibVentas.cuerpoBolsasCarneIndustrial(fecha, item.nummov)
                        comando.CommandText = consulta
                        conector.Fill(dtCuerpo)

                        Dim posicion As Integer = 1
                        For Each fila As DataRow In dtCuerpo.Rows
                            Dim iCuerpo As New tb_CueVentas With {.posicion = posicion, .tipomov = item.tipomov, .nummov = item.nummov,
                                                                      .nroitem = IIf((fila.Item("fpcodcon") Is DBNull.Value), Decimal.Zero, fila.Item("fpcodcon")),
                                                                      .kilos = Decimal.Zero,
                                                                      .unidmedida = IIf((fila.Item("umedida") Is DBNull.Value), Decimal.Zero, fila.Item("umedida")),
                                                                      .cantidad = IIf((fila.Item("cant") Is DBNull.Value), Decimal.Zero, fila.Item("cant")),
                                                                      .detalle = IIf((fila.Item("detalle") Is DBNull.Value), Nothing, fila.Item("detalle")),
                                                                      .preciobs = IIf((fila.Item("precio") Is DBNull.Value), Decimal.Zero, fila.Item("precio")),
                                                                      .descuentobs = IIf((fila.Item("descuento") Is DBNull.Value), Decimal.Zero, fila.Item("descuento")),
                                                                      .importebs = IIf((fila.Item("monto") Is DBNull.Value), Decimal.Zero, fila.Item("monto")),
                                                                      .subtotal = IIf((fila.Item("subtotal") Is DBNull.Value), Decimal.Zero, fila.Item("subtotal"))}
                            If iCuerpo.importebs > 0 Then
                                consulta = LibCierreVentas.altaCuepPreFactura(iCuerpo)
                                comando.CommandType = CommandType.Text
                                comando.CommandText = consulta
                                comando.ExecuteNonQuery()
                                posicion = posicion + 1
                            End If
                        Next
                    End Using
                Next
            End Using
            Return True
        Catch ex As Exception
            set_error("Fallo en clsPreFactura:: altaBosasCarneIndustrial " & vbNewLine & consulta, ex.Message)
        End Try
        Return False
    End Function

    Public Function altaServicioMenudoPorcino(ByVal fecha As Date, ByVal tCambio As Decimal, ByVal usuario As String) As Boolean
        Dim consulta As String = String.Empty
        Try
            Using dtDescarteUno As New DataTable
                consulta = LibVentas.cabServicioMenudoPorcino(fecha)
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dtDescarteUno)
                '-- 1.- estado -> 0      anulado -> 1 pediente      2 -> facturado	
                Dim listaCab As New List(Of Entidades.tb_CabVentas)()
                For Each fila As DataRow In dtDescarteUno.Rows 'select UNIQUE fpfechaf,fptipfac,fpnrofac,clnombre,clapelli,ruc
                    Dim item As New Entidades.tb_CabVentas With {.tipomov = fila.Item("fptipfac"), .nummov = fila.Item("fpnrofac"),
                                                                 .fechamov = fila.Item("fpfechaf"),
                                                                 .nombre = IIf((fila.Item("clnombre") Is DBNull.Value), Nothing, fila.Item("clnombre")),
                                                                 .apellido = IIf((fila.Item("clapelli") Is DBNull.Value), Nothing, fila.Item("clapelli")),
                                                                 .ci_ruc = IIf((fila.Item("ruc") Is DBNull.Value), Nothing, fila.Item("ruc")),
                                                                 .telefono = IIf((fila.Item("telefono") Is DBNull.Value), String.Empty, fila.Item("telefono")),
                                                                 .direccion = IIf((fila.Item("direccion") Is DBNull.Value), String.Empty, fila.Item("direccion")),
                                                                 .pais = "",
                                                                 .email = "",
                                                                 .arancel = "",
                                                                 .lugentrega = "", .fob_fca = "", .plazopago = "",
                                                                 .pesobruto = Decimal.Zero, .pesoneto = Decimal.Zero, .pedido = Decimal.Zero,
                                                                 .proforma = Decimal.Zero, .moneda = "28002", .estado = "1", .tipocambio = tCambio,
                                                                 .mdescuento = IIf((fila.Item("mdescuento") Is DBNull.Value), Decimal.Zero, fila.Item("mdescuento")),
                                                                 .mtotal = IIf((fila.Item("mtotal") Is DBNull.Value), Decimal.Zero, fila.Item("mtotal")),
                                                                 .msubtotal = IIf((fila.Item("msubtotal") Is DBNull.Value), Decimal.Zero, fila.Item("msubtotal")),
                                                                 .mdolar = IIf((fila.Item("mdolar") Is DBNull.Value), Decimal.Zero, fila.Item("mdolar")),
                                                                 .usuario = usuario}
                    listaCab.Add(item)
                Next
                'recorro todos las cabeceras
                For Each item As tb_CabVentas In listaCab
                    consulta = LibCierreVentas.altaCabPreFactura(item)
                    comando.CommandText = consulta
                    comando.ExecuteNonQuery()
                    Using dtCuerpo As New DataTable
                        'obtengo los cuerpos por cabecera
                        consulta = LibVentas.cuerpoServicioMenudoPorcino(fecha, item.nummov)
                        comando.CommandText = consulta
                        conector.Fill(dtCuerpo)

                        Dim posicion As Integer = 1
                        For Each fila As DataRow In dtCuerpo.Rows
                            Dim iCuerpo As New tb_CueVentas With {.posicion = posicion, .tipomov = item.tipomov, .nummov = item.nummov,
                                                                      .nroitem = IIf((fila.Item("fpcodcon") Is DBNull.Value), Decimal.Zero, fila.Item("fpcodcon")),
                                                                      .kilos = Decimal.Zero,
                                                                      .unidmedida = IIf((fila.Item("umedida") Is DBNull.Value), Decimal.Zero, fila.Item("umedida")),
                                                                      .cantidad = IIf((fila.Item("cant") Is DBNull.Value), Decimal.Zero, fila.Item("cant")),
                                                                      .detalle = IIf((fila.Item("detalle") Is DBNull.Value), Nothing, fila.Item("detalle")),
                                                                      .preciobs = IIf((fila.Item("precio") Is DBNull.Value), Decimal.Zero, fila.Item("precio")),
                                                                      .descuentobs = IIf((fila.Item("descuento") Is DBNull.Value), Decimal.Zero, fila.Item("descuento")),
                                                                      .importebs = IIf((fila.Item("monto") Is DBNull.Value), Decimal.Zero, fila.Item("monto")),
                                                                      .subtotal = IIf((fila.Item("subtotal") Is DBNull.Value), Decimal.Zero, fila.Item("subtotal"))}
                            If iCuerpo.importebs > 0 Then
                                consulta = LibCierreVentas.altaCuepPreFactura(iCuerpo)
                                comando.CommandType = CommandType.Text
                                comando.CommandText = consulta
                                comando.ExecuteNonQuery()
                                posicion = posicion + 1
                            End If
                        Next
                    End Using
                Next
            End Using
            Return True
        Catch ex As Exception
            set_error("Fallo en clsPreFactura:: altaServicioMenudoPorcino " & vbNewLine & consulta, ex.Message)
        End Try
        Return False
    End Function

    Public Function altaCuero(ByVal fecha As Date, ByVal tCambio As Decimal, ByVal usuario As String) As Boolean
        Dim consulta As String = String.Empty
        Try
            Using dtDescarteUno As New DataTable
                consulta = LibVentas.cabCueros(fecha)
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dtDescarteUno)
                '-- 1.- estado -> 0      anulado -> 1 pediente      2 -> facturado	
                Dim listaCab As New List(Of Entidades.tb_CabVentas)()
                For Each fila As DataRow In dtDescarteUno.Rows 'UNIQUE fpfechaf,'93070',fpnrofac,  trim(clnombre) clnombre, trim(clapelli) clapelli, trim(ruc) ruc "
                    Dim item As New Entidades.tb_CabVentas With {.tipomov = fila.Item("fptipfac"),
                                                                 .nummov = fila.Item("fpnrofac"),
                                                                 .fechamov = fila.Item("fpfechaf"),
                                                                 .nombre = IIf((fila.Item("clnombre") Is DBNull.Value), Nothing, fila.Item("clnombre")),
                                                                 .apellido = IIf((fila.Item("clapelli") Is DBNull.Value), Nothing, fila.Item("clapelli")),
                                                                 .ci_ruc = IIf((fila.Item("ruc") Is DBNull.Value), Nothing, fila.Item("ruc")),
                                                                 .telefono = IIf((fila.Item("telefono") Is DBNull.Value), String.Empty, fila.Item("telefono")),
                                                                 .direccion = IIf((fila.Item("direccion") Is DBNull.Value), String.Empty, fila.Item("direccion")),
                                                                 .pais = "",
                                                                 .email = "",
                                                                 .arancel = "",
                                                                 .lugentrega = "", .fob_fca = "", .plazopago = "",
                                                                 .pesobruto = Decimal.Zero, .pesoneto = Decimal.Zero, .pedido = Decimal.Zero,
                                                                 .proforma = Decimal.Zero, .moneda = "28002", .estado = "1", .tipocambio = tCambio,
                                                                 .mdescuento = IIf((fila.Item("mdescuento") Is DBNull.Value), Decimal.Zero, fila.Item("mdescuento")),
                                                                 .mtotal = IIf((fila.Item("mtotal") Is DBNull.Value), Decimal.Zero, fila.Item("mtotal")),
                                                                 .msubtotal = IIf((fila.Item("msubtotal") Is DBNull.Value), Decimal.Zero, fila.Item("msubtotal")),
                                                                 .mdolar = IIf((fila.Item("mdolar") Is DBNull.Value), Decimal.Zero, fila.Item("mdolar")),
                                                                 .usuario = usuario}
                    listaCab.Add(item)
                Next
                'recorro todos las cabeceras
                For Each item As tb_CabVentas In listaCab
                    consulta = LibCierreVentas.altaCabPreFactura(item)
                    comando.CommandText = consulta
                    comando.ExecuteNonQuery()
                    Using dtCuerpo As New DataTable 'cuerpoCuerosLimpieza
                        'obtengo los cuerpos por cabecera
                        consulta = LibVentas.cuerpoCuerosLimpieza(fecha, item.nummov)
                        comando.CommandText = consulta
                        conector.Fill(dtCuerpo)

                        Dim posicion As Integer = 1
                        For Each fila As DataRow In dtCuerpo.Rows
                            Dim iCuerpo As New tb_CueVentas With {.posicion = posicion, .tipomov = item.tipomov, .nummov = item.nummov,
                                                                      .nroitem = IIf((fila.Item("fpcodcon") Is DBNull.Value), Decimal.Zero, fila.Item("fpcodcon")),
                                                                      .kilos = Decimal.Zero,
                                                                      .unidmedida = IIf((fila.Item("umedida") Is DBNull.Value), Decimal.Zero, fila.Item("umedida")),
                                                                      .cantidad = IIf((fila.Item("cant") Is DBNull.Value), Decimal.Zero, fila.Item("cant")),
                                                                      .detalle = IIf((fila.Item("detalle") Is DBNull.Value), Nothing, fila.Item("detalle")),
                                                                      .preciobs = IIf((fila.Item("precio") Is DBNull.Value), Decimal.Zero, fila.Item("precio")),
                                                                      .descuentobs = IIf((fila.Item("descuento") Is DBNull.Value), Decimal.Zero, fila.Item("descuento")),
                                                                      .importebs = IIf((fila.Item("monto") Is DBNull.Value), Decimal.Zero, fila.Item("monto")),
                                                                      .subtotal = IIf((fila.Item("subtotal") Is DBNull.Value), Decimal.Zero, fila.Item("subtotal"))}
                            If iCuerpo.importebs > 0 Then
                                consulta = LibCierreVentas.altaCuepPreFactura(iCuerpo)
                                comando.CommandType = CommandType.Text
                                comando.CommandText = consulta
                                comando.ExecuteNonQuery()
                                posicion = posicion + 1
                            End If
                        Next
                    End Using

                    Using dtCuerpo As New DataTable 'cuerpoCuerosEnfriamiento
                        'obtengo los cuerpos por cabecera
                        consulta = LibVentas.cuerpoCuerosEnfriamiento(fecha, item.nummov)
                        comando.CommandText = consulta
                        conector.Fill(dtCuerpo)

                        Dim posicion As Integer = 1
                        For Each fila As DataRow In dtCuerpo.Rows
                            Dim iCuerpo As New tb_CueVentas With {.posicion = posicion, .tipomov = item.tipomov, .nummov = item.nummov,
                                                                      .unidmedida = IIf((fila.Item("umedida") Is DBNull.Value), Decimal.Zero, fila.Item("umedida")),
                                                                      .kilos = Decimal.Zero,
                                                                      .cantidad = IIf((fila.Item("cant") Is DBNull.Value), Decimal.Zero, fila.Item("cant")),
                                                                      .detalle = IIf((fila.Item("detalle") Is DBNull.Value), Nothing, fila.Item("detalle")),
                                                                      .preciobs = IIf((fila.Item("precio") Is DBNull.Value), Decimal.Zero, fila.Item("precio")),
                                                                      .descuentobs = IIf((fila.Item("descuento") Is DBNull.Value), Decimal.Zero, fila.Item("descuento")),
                                                                      .importebs = IIf((fila.Item("monto") Is DBNull.Value), Decimal.Zero, fila.Item("monto"))}
                            If iCuerpo.importebs > 0 Then
                                consulta = LibCierreVentas.altaCuepPreFactura(iCuerpo)
                                comando.CommandType = CommandType.Text
                                comando.CommandText = consulta
                                comando.ExecuteNonQuery()
                                posicion = posicion + 1
                            End If
                        Next
                    End Using
                Next
            End Using
            Return True
        Catch ex As Exception
            set_error("Fallo en clsPreFactura:: altaCuero " & vbNewLine & consulta, ex.Message)
        End Try
        Return False
    End Function

    Public Function bajaCierre(ByVal fecha As Date)
        Using dtCabera As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = LibCierreVentas.getCabera(fecha)
                comando.CommandText = consulta
                conector.Fill(dtCabera)
                For Each fila As DataRow In dtCabera.Rows
                    Dim item As New Entidades.tb_CabVentas With {.nummov = IIf(fila.Item("nummov") Is DBNull.Value, Nothing, fila.Item("nummov")),
                                                                 .tipomov = IIf(fila.Item("tipomov") Is DBNull.Value, Nothing, fila.Item("tipomov")),
                                                                 .fechamov = fecha.ToShortDateString}
                    consulta = LibCierreVentas.bajaCuerpo(item)
                    comando.CommandText = consulta
                    comando.ExecuteNonQuery()

                    consulta = LibCierreVentas.bajaCabecera(item)
                    comando.CommandText = consulta
                    comando.ExecuteNonQuery()
                Next
                Return True
            Catch ex As Exception
                set_error("Fallo en clsPreFactura:: bajaCierre " & vbNewLine & consulta, ex.Message)
            End Try
            Return False
        End Using
        Return True
    End Function

#End Region

End Class