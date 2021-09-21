Imports Entidades
Imports System.Threading.Tasks
Imports System.Xml
Imports System.Xml.Serialization
Imports System.IO
Imports System.Text
Imports System.Numerics
Imports WindApp.ServiceRefCufd
Imports WindApp.My.Resources.rcRecursos

Imports WindApp.ServiceRefFEstandar
Imports System.Security.Cryptography.X509Certificates

Public Class UI_Pruebas : Inherits f_base

#Region "[atributosGlobales]"

    Private usuario As String
    Private clave As String
    Private cufdObtenido As String
    'WindApp_TemporaryKey.pfx   D:\Certificado\frigorCsr.csr
    Private pathCertificado As String = "D:\Certificado\WindApp_TemporaryKey.pfx"
    Private pathKey As String = "C:\OpenSSL-Win64\bin\privateKey.pem"

    Private pathXml As String = String.Empty

    Private rutaCertificado As String = "D:\Facturacion\FACTURACION\WindApp\frigorCertificado.pfx"
    Private passCertificado As String = "123"
    Private rutaXml As String
    Private rutaXmlFirmado As String

#End Region

#Region "[constructor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String)
        MyBase.New("GENERACION DE DOCUMENTOS XML SELLADOS", "Paso a paso generando documentos")
        InitializeComponent()
        usuario = usuar
        clave = clav
    End Sub

#End Region

#Region "[metodos]"

    Private Sub generarAlta()
        Try
            Dim objUtilitario As New libreriaCUF()
            Dim nit As String = "1028739027" 'nit base .............VALOR CABECERA, XML
            Dim nitCuf As String = objUtilitario.getNitFormato(nit) ' Nit formateado para el CUF

            '................capturo la fecha
            Dim fechaBase As String = DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss.fff")
            Dim fecha2 As String = fechaBase.Replace("T", "-")
            fecha2 = fecha2.Replace(":", "-")
            fecha2 = fecha2.Replace(".", "-")

            '................capturo la fecha en un array
            Dim array() As String = Split(fecha2, "-")
            '...............Declaro mis variables
            Dim anio As String : Dim mes As String : Dim dia As String
            Dim hora As String : Dim minuto As String : Dim sg As String
            Dim mils As String

            '................damos el formato para general el CUF
            anio = objUtilitario.getAnioFormat(array.GetValue(0)) : mes = objUtilitario.getMesFormat(array.GetValue(1))
            dia = objUtilitario.getDiaFormat(array.GetValue(2)) : hora = objUtilitario.getHoraFormat(array.GetValue(3))
            minuto = objUtilitario.getMinutoFormat(array.GetValue(4)) : sg = objUtilitario.getSegundoFormat(array.GetValue(5))
            mils = objUtilitario.getMilisegundoFormat(array.GetValue(6))

            '................agrupamos los el campo fecha para la cabera del XML
            Dim cFechaCab As String = dia & "/" & mes & "/" & anio 'Valor Cabecera tabla
            Dim cFechaCabXML As String = anio & "-" & mes & "-" & dia & "T" & hora & ":" & minuto & ":" & sg & "." & mils 'Valor cabecera XML

            Dim sucrusal As String = "0" 'Valor Cabecera tabla
            Dim sucrusalCuf As String = objUtilitario.getSucrusalFormat(sucrusal) 'Valor cabecera XML

            Dim oUtilitario As New Negocios.UtilitarioBL(usuario, clave)

            '1 Valor Cabecera tabla, Valor cabecera XML  ('1 = Electrónica 2 = Computarizada 3 = Manual)
            Dim modalidad As String = oUtilitario.getCatalogoBL(catalgofacturacion.modalidad, 1)

            '1 Valor Cabecera tabla, Valor cabecera XML  (1 = Online 2 = Offline)
            Dim tipoEmision As String = oUtilitario.getCatalogoBL(catalgofacturacion.tEmision, 2)

            '1 Valor Cab tabla, Valor cab XML (1 = Factura, 2= Nota Debito/Crédito, 3= Nota Fiscal, 4= Boleta contingencia, 5= Documento equivalente
            Dim codigoDocumentoFiscal As String = oUtilitario.getCatalogoBL(catalgofacturacion.dFiscal, 1)

            '1 Valor Cab tabla, Valor cab XML (1 = Factura Estandar 2 = Factura Sector Educativo ……. 22 = Boleto Aereo)
            Dim tipoDocumentoSector As String = oUtilitario.getCatalogoBL(catalgofacturacion.dSector, 1)

            'solo formato tipoDocumentoSectorCuf = "01"
            Dim tipoDocumentoSectorCuf As String = objUtilitario.getTipoDocumentoSectorFormat(tipoDocumentoSector)

            'Valor Cab tabla, XML
            Dim nroFactura As String = "1"

            'Formato nroFacturaCUF = "00000001"
            Dim nroFacturaCUF As String = objUtilitario.getNroFacturaFormat(nroFactura)

            'Valor Cab tabla, Valor cab XML (0 = No corresponde 1,2,3,4,….n)
            Dim puntoVenta As String = "1"
            'Formator Valor CUF
            Dim puntoVentaCuf As String = objUtilitario.getPuntoVentaFormat(puntoVenta)

            'Formato fecha CUF
            Dim fCUF As String = anio & mes & dia & hora & minuto & sg & mils

            'Juntamos todos las partes base para CUF Base 11
            Dim CufBase11 As String = nitCuf & fCUF & sucrusalCuf & modalidad & tipoEmision & codigoDocumentoFiscal &
                                      tipoDocumentoSectorCuf & nroFacturaCUF & puntoVentaCuf

            'Auxiliar base 11
            Dim auxBase11 As String = String.Empty
            'Aplicamos el algoritmo Base 11
            auxBase11 = objUtilitario.calculaDigitoModulo11(CufBase11, 1, 9, False)

            'Concatenamos el valor del Cuf mas el valor obtenido con el modulo base 11(Modulo base 11 aquirido)
            CufBase11 = CufBase11 & auxBase11

            'Pasamos el valaor del CUF con BASE11 a un BIGINTEGER
            Dim valor122 As BigInteger = System.Numerics.BigInteger.Parse(CufBase11)

            'Aplicamos la funcion hexadecimal a nuestro valor BIGINTEGER
            Dim Cuf As String = objUtilitario.getHexadecimal(valor122) 'Al fin tenemos nuestro CUF generador..... uhh uhh uhh  victoria, victoria pendejo

            Dim ambiente As String = oUtilitario.getCatalogoBL(catalgofacturacion.ambiente, 2)
            Dim codSistema As String = "5D07CC8BC36"
            Dim cuis As String = "A5654D3F"

            cufdObtenido = String.Empty
            Dim codMetodoPago As String = oUtilitario.getCatalogoBL(catalgofacturacion.mPago, 1)
            Dim codDocIdentidad As String = oUtilitario.getCatalogoBL(catalgofacturacion.dIdentidad, 1)
            Dim codMoneda As String = oUtilitario.getCatalogoBL(catalgofacturacion.monedas, 688)

            If getCUFD(ambiente, codigoDocumentoFiscal, codSistema, sucrusal, cuis, nit) Then
                ' cufdObtenido = "ABCDFG"
                If Not String.IsNullOrEmpty(cufdObtenido) Then
                    Dim objCabecera As facturaElectronicaEstandarCabecera
                    objCabecera = New facturaElectronicaEstandarCabecera With {.nitEmisor = nit,
                                                                              .numeroFactura = nroFactura,
                                                                              .cuf = Cuf,
                                                                              .cufd = cufdObtenido,
                                                                              .codigoSucursal = sucrusal,
                                                                              .direccion = "Parque Industrial PI-44",
                                                                              .codigoPuntoVenta = puntoVenta,
                                                                              .fechaEmision = cFechaCabXML,
                                                                              .nombreRazonSocial = "FRIGOR S.A.",
                                                                              .codigoTipoDocumentoIdentidad = codDocIdentidad,
                                                                              .numeroDocumento = "5861642",
                                                                              .complemento = Nothing,
                                                                              .codigoCliente = "315",
                                                                              .codigoMetodoPago = codMetodoPago,
                                                                              .numeroTarjeta = Nothing,
                                                                              .montoTotal = 100,
                                                                              .montoDescuento = Nothing,
                                                                              .codigoMoneda = codMoneda,
                                                                              .tipoCambio = 1,
                                                                              .montoTotalMoneda = 100,
                                                                              .leyenda = "Ley N° 453: Tienes",
                                                                              .usuario = "sa",
                                                                              .codigoDocumentoSector = codigoDocumentoFiscal,
                                                                              .codigoExcepcionDocumento = Nothing}


                    Dim codActEconomica As String = "101013"
                    Dim codProductoSin As String = "21111"
                    Dim unidadMedida As String = oUtilitario.getCatalogoBL(catalgofacturacion.uMedida, 22) 'KILOGRAMOS
                    Dim nroEmei As String = "0201.10.00.00"
                    Dim lista As New List(Of facturaElectronicaEstandarDetalle)
                    Dim objDetalle As New facturaElectronicaEstandarDetalle With {.actividadEconomica = codActEconomica,
                                                                                  .codigoProductoSin = codProductoSin,
                                                                                  .codigoProducto = "1005",
                                                                                  .descripcion = "COLITA DE CUADRIL",
                                                                                  .cantidad = 4,
                                                                                  .unidadMedida = unidadMedida,
                                                                                  .precioUnitario = 25,
                                                                                  .montoDescuento = Nothing,
                                                                                  .subTotal = 100,
                                                                                  .numeroSerie = Nothing,
                                                                                  .numeroImei = nroEmei}
                    lista.Add(objDetalle)

                    Dim objFactura As facturaElectronicaEstandar = New facturaElectronicaEstandar() With {.cabecera = objCabecera, .detalle = lista.ToArray()}
                    '---------------------------------------- SERIALIZAMOS ------------------------------------- 
                    '-- utf-16 lo cambiamos a UTF8
                    Dim anioregis As String = objUtilitario.getAnioFormatDoc(Date.Now.Year)
                    Dim mesregist As String = objUtilitario.getMesFormat(Date.Now.Month)
                    Dim diaresitr As String = objUtilitario.getDiaFormat(Date.Now.Day)

                    Dim horaregis As String = objUtilitario.getHoraFormat(Date.Now.Hour)

                    Dim mregistro As String = objUtilitario.getMinutoFormat(Date.Now.Minute)
                    Dim sregistro As String = objUtilitario.getSegundoFormat(Date.Now.Second)

                    Dim nombreArchivo As String = nroFactura & "_" & anioregis & mesregist & diaresitr & horaregis & mregistro & sregistro
                    Dim directorio As String = "C:\Facturacion\frigor\Archivos\" & Date.Now.Year & Date.Now.Month & Date.Now.Day & "\" &
                                               nroFactura & "_" & anioregis & mesregist & diaresitr & horaregis & mregistro & sregistro & ".xml"

                    nombreArchivo = nombreArchivo & "Firmado"
                    Dim directorioFirm As String = "C:\Facturacion\frigor\Archivos\" & Date.Now.Year & Date.Now.Month & Date.Now.Day & "\" &
                                                   nombreArchivo & ".xml"

                    pathXml = directorio

                    rutaXml = pathXml
                    rutaXmlFirmado = directorioFirm

                    Dim mensaje As String = String.Empty
                    If seralizarXML(objFactura, mensaje) Then
                        'Firmamos el XML generado
                        Dim menError As String = String.Empty
                        Dim oFirma As New clsFirmando()
                        If oFirma.Firmar(rutaCertificado, passCertificado, rutaXml, rutaXmlFirmado, menError) Then
                            Dim tramaZip As String = String.Empty
                            'If clsFirmando.Compacta(rutaXmlFirmado, tramaZip, menError) <> String.Empty Then
                            'If clsFirmando.GenerarZipDos(rutaXmlFirmado, tramaZip, menError) Then
                            If clsFirmando.Compacta2(rutaXmlFirmado, tramaZip, menError) Then
                                Dim hash As String = oFirma.getSHA256(tramaZip)

                                Dim fServer As String = String.Empty
                                If getFechaYHoraSIN(menError, fServer) Then
                                    Call respuestaFacturacion(objCabecera, "2", "1", "1", "1", "5D07CC8BC36", "A5654D3F", fServer,
                                                               "", tramaZip, hash)
                                End If
                            Else
                                MessageBox.Show(menError, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                        Else
                            MessageBox.Show(menError, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                End If
            Else
                MessageBox.Show("Searializacion generada correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, catalgofacturacion.tmensaje, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Function getCodigoAmbiente(ByVal codAmbiente As String)
        Using oParametros As New Negocios.UtilitarioSIN(usuario, clave)
            Dim ambiente As String = String.Empty
            Dim dtAmbiente As New DataTable
            dtAmbiente = oParametros.getAmbienteBL(codAmbiente)
            If oParametros.existeError Then
                MessageBox.Show(oParametros.mensajesErrorSistema & vbNewLine & oParametros.mensajesErrorUsuario, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                If dtAmbiente.Rows.Count > 0 Then
                    ambiente = IIf(IsDBNull(dtAmbiente.Rows(0).Item("codigo")), Nothing, dtAmbiente.Rows(0).Item("codigo"))
                End If
            End If
            Return ambiente
        End Using
    End Function

    Private Function getDocuFiscales(ByVal codDFicales As String)
        Using oParametros As New Negocios.UtilitarioSIN(usuario, clave)
            Dim docuFicales As String = String.Empty
            Dim dtDocuFiscal As New DataTable
            dtDocuFiscal = oParametros.getDocuFicalesBL(codDFicales)
            If oParametros.existeError Then
                MessageBox.Show(oParametros.mensajesErrorSistema & vbNewLine & oParametros.mensajesErrorUsuario, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                If dtDocuFiscal.Rows.Count > 0 Then
                    docuFicales = IIf(IsDBNull(dtDocuFiscal.Rows(0).Item("codigo")), Nothing, dtDocuFiscal.Rows(0).Item("codigo"))
                End If
            End If
            Return docuFicales
        End Using
    End Function

    Private Function getEmision(ByVal codEmision As String)
        Using oParametros As New Negocios.UtilitarioSIN(usuario, clave)
            Dim tipoEmison As String = String.Empty
            Dim dtEmision As New DataTable
            dtEmision = oParametros.getEmisionBL(codEmision)
            If oParametros.existeError Then
                MessageBox.Show(oParametros.mensajesErrorSistema & vbNewLine & oParametros.mensajesErrorUsuario, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                If dtEmision.Rows.Count > 0 Then
                    tipoEmison = IIf(IsDBNull(dtEmision.Rows(0).Item("codigo")), Nothing, dtEmision.Rows(0).Item("codigo"))
                End If
            End If
            Return tipoEmison
        End Using
    End Function

    Private Function getModalidad(ByVal codModalidad As String)
        Using oParametros As New Negocios.UtilitarioSIN(usuario, clave)
            Dim modalidad As String = String.Empty
            Dim dtModiladad As New DataTable
            dtModiladad = oParametros.getModalidadBL(codModalidad)
            If oParametros.existeError Then
                MessageBox.Show(oParametros.mensajesErrorSistema & vbNewLine & oParametros.mensajesErrorUsuario, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                If dtModiladad.Rows.Count > 0 Then
                    modalidad = IIf(IsDBNull(dtModiladad.Rows(0).Item("codigo")), Nothing, dtModiladad.Rows(0).Item("codigo"))
                End If
            End If
            Return modalidad
        End Using
    End Function

    Private Function getFechaYHoraSIN(ByRef menError As String, ByRef fechaServer As String) As Boolean
        Try
            Dim oSolSincronizacion As New WindApp.ServiceRefSinFechaHora.solicitudSincronizacion With {.codigoAmbiente = "2",
                                                .codigoPuntoVenta = 1,
                                                .codigoSistema = "5D07CC8BC36",
                                                .codigoSucursal = "0",
                                                .cuis = "A5654D3F",
                                                .nit = "1028739027"}

            Dim oSerSincrFechaHoraClient As New WindApp.ServiceRefSinFechaHora.ServicioSincronizacionFechaHoraClient()
            Dim oRespuestaFHora As New WindApp.ServiceRefSinFechaHora.respuestaFechaHora()

            oRespuestaFHora = oSerSincrFechaHoraClient.sincronizarFechaHora(oSolSincronizacion)
            If Not oRespuestaFHora.listaCodigosRespuestas Is Nothing Then
                Dim codRespuesta As String = String.Empty
                Dim contador As Integer = oRespuestaFHora.listaCodigosRespuestas.Count
                Dim nro As Integer = 0

                For Each irespuesta As WindApp.ServiceRefSinFechaHora.respuestaCodigosMensajesSoapDto In oRespuestaFHora.listaCodigosRespuestas
                    nro = nro + 1
                    If nro = contador Then
                        codRespuesta = codRespuesta & irespuesta.codigoMensaje
                    Else
                        codRespuesta = codRespuesta & irespuesta.codigoMensaje & ","
                    End If
                Next
                Using oMensajeSoap As New Negocios.UtilitarioSIN(usuario, clave)
                    Dim dt As New DataTable
                    dt = oMensajeSoap.getMensSoapBL(codRespuesta)
                    If oMensajeSoap.existeError Then
                        MessageBox.Show(oMensajeSoap.mensajesErrorSistema & vbNewLine & oMensajeSoap.mensajesErrorUsuario, catalgofacturacion.tmensaje, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        Dim mensajes As String = String.Empty
                        For Each fila As DataRow In dt.Rows
                            mensajes = mensajes & fila.Item("descripcion") & vbNewLine
                        Next
                        MessageBox.Show("Fallo Generar Fecha del Servidor es: " & vbNewLine & mensajes, catalgofacturacion.tmensaje, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
                Return False  '2019-09-06T09:18:53.783
            Else
                fechaServer = oRespuestaFHora.fechaHora
                Return True
            End If
        Catch ex As Exception
            menError = ex.Message
            Return False
        End Try
        Return False
    End Function

    Private Function seralizarXML(ByVal objFactura As facturaElectronicaEstandar, ByRef mensaje As String) As Boolean
        Try
            Dim objSerializar As XmlSerializer = New XmlSerializer(GetType(facturaElectronicaEstandar))
            Dim sXml As String = ""
            Using sww As StringWriterWithEncoding = New StringWriterWithEncoding(Encoding.UTF8)
                Using writter As XmlWriter = XmlWriter.Create(sww)
                    objSerializar.Serialize(writter, objFactura)
                    sXml = sww.ToString()
                End Using
            End Using
            '' ''Guardamos el string en un archivo
            System.IO.File.WriteAllText(pathXml, sXml)
        Catch ex As Exception
            mensaje = ex.Message ', catalgofacturacion.tmensaje, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End Try
        Return True
    End Function

    Private Function getCUFD(ByVal codAmbiente As String, ByVal codModalidad As String, ByVal codSistema As String,
                             ByVal codSucrusal As String, ByVal cuis As String, ByVal nit As String) As Boolean
        Try
            Dim item As New solicitudOperaciones With {.codigoAmbiente = "2", .codigoModalidad = 1,
                                                       .codigoSistema = "5D07CC8BC36",
                                                       .codigoSucursal = codSucrusal, .cuis = "A5654D3F", .nit = "1028739027"}


            Dim objCliente As New ServicioFacturacionCufdClient
            Dim objRespuesta As New respuestaCufd
            objRespuesta = objCliente.solicitudCufd(item)

            If Not objRespuesta.listaCodigosRespuestas Is Nothing Then
                Dim codRespuesta As String = String.Empty
                Dim contador As Integer = objRespuesta.listaCodigosRespuestas.Count
                Dim nro As Integer = 0
                For Each irespuesta As respuestaCodigosMensajesSoapDto In objRespuesta.listaCodigosRespuestas
                    nro = nro + 1
                    If nro = contador Then
                        codRespuesta = codRespuesta & irespuesta.codigoMensaje
                    Else
                        codRespuesta = codRespuesta & irespuesta.codigoMensaje & ","
                    End If
                Next

                Using objCatalogo As New Negocios.CatalogoBL(usuario, clave)
                    Dim dt As New DataTable
                    dt = objCatalogo.getCatalogoBL(catalgofacturacion.mSoap, codRespuesta)

                    If objCatalogo.existeError Then
                        MessageBox.Show(objCatalogo.mensajesErrorSistema & objCatalogo.mensajesErrorUsuario, catalgofacturacion.tmensaje, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        Dim mensajes As String = String.Empty
                        For Each fila As DataRow In dt.Rows
                            mensajes = mensajes & fila.Item("nombre") & vbNewLine
                        Next
                        MessageBox.Show("Fallo Generar CUFD es: " & vbNewLine & mensajes, catalgofacturacion.tmensaje, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                End Using

                Return False
            Else
                cufdObtenido = objRespuesta.codigo
                Return True
                'Dim a As String = objRespuesta.codigo
                'MessageBox.Show("El valor del CUFD es: " & a, catalgofacturacion.tmensaje, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try
        Return True
    End Function

    Private Sub respuestaFacturacion(ByVal iCabecera As facturaElectronicaEstandarCabecera, ByVal codAmbiente As String, ByVal codDFicales As String,
                                         ByVal codEmision As String, ByVal codModalidad As String, ByVal codSistema As String,
                                         ByVal cuis As String,
                                         ByVal fenivio As String,
                                         ByVal urlxml As String,
                                         ByVal tramaZip As String, ByVal hash As String)
        Dim oFactura As New ServicioFacturaElectronicaEstandarClient()

        If oFactura.verificarComunicacion() Then
            Using oParametros As New Negocios.UtilitarioSIN(usuario, clave)

                Dim ambiente As String = getCodigoAmbiente(codAmbiente)
                Dim docuFicales As String = getDocuFiscales(codDFicales)
                Dim tipoEmison As String = getEmision(codEmision)
                Dim modalidad As String = getModalidad(codModalidad)


                Dim iSolicitudRepcepcion As New solicitudRecepcion With {.archivo = tramaZip,
                                                                         .codigoAmbiente = ambiente,
                                                                         .codigoDocumentoFiscal = docuFicales,
                                                                         .codigoDocumentoSector = iCabecera.codigoDocumentoSector,
                                                                         .codigoEmision = tipoEmison,
                                                                         .codigoModalidad = modalidad,
                                                                         .codigoPuntoVenta = iCabecera.codigoPuntoVenta,
                                                                         .codigoSistema = codSistema,
                                                                         .codigoSucursal = iCabecera.codigoSucursal,
                                                                         .cufd = iCabecera.cufd,
                                                                         .cuis = cuis,
                                                                         .fechaEnvio = fenivio,
                                                                         .hashArchivo = hash,
                                                                         .nit = iCabecera.nitEmisor}

                Dim objClienteFactura As New WindApp.ServiceRefFEstandar.ServicioFacturaElectronicaEstandarClient()
                Dim objRespuesta As New ServiceRefFEstandar.respuesta
                Dim oRespuesta2 As New recepcionFacturaElectronicaEstandarResponse

                objRespuesta = objClienteFactura.recepcionFacturaElectronicaEstandar(iSolicitudRepcepcion)
                'oRespuesta2 = objClienteFactura.recepcionFacturaElectronicaEstandar(iSolicitudRepcepcion)

                If Not objRespuesta.listaErroresDetalles Is Nothing Then
                    Dim codRespuesta As String = String.Empty
                    Dim contador As Integer = objRespuesta.listaErroresDetalles.Count
                    Dim nro As Integer = 0
                    For i = 0 To objRespuesta.listaCodigosRespuestas.Count - 1 Step 1 '  nro = nro + 1
                        If i = objRespuesta.listaCodigosRespuestas.Count - 1 Then
                            codRespuesta = codRespuesta & objRespuesta.listaCodigosRespuestas.GetValue(i)
                        Else
                            codRespuesta = codRespuesta & objRespuesta.listaCodigosRespuestas.GetValue(i) & ","
                        End If
                    Next

                    Using objCatalogo As New Negocios.CatalogoBL(usuario, clave)
                        Dim dt As New DataTable
                        dt = objCatalogo.getCatalogoBL(catalgofacturacion.mSoap, codRespuesta)

                        If objCatalogo.existeError Then
                            MessageBox.Show(objCatalogo.mensajesErrorSistema & objCatalogo.mensajesErrorUsuario, catalgofacturacion.tmensaje, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            Dim mensajes As String = String.Empty
                            For Each fila As DataRow In dt.Rows
                                mensajes = mensajes & fila.Item("nombre") & vbNewLine
                            Next
                            MessageBox.Show("Fallo Codigo Recepción es: " & vbNewLine & mensajes, catalgofacturacion.tmensaje, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                    End Using
                Else
                    Dim iSolicitudValidacion As New WindApp.ServiceRefFEstandar.solicitudValidacionRecepcion With {.codigoAmbiente = ambiente,
                                                                                                              .codigoDocumentoFiscal = docuFicales,
                                                                                                              .codigoDocumentoSector = iCabecera.codigoDocumentoSector,
                                                                                                              .codigoEmision = tipoEmison,
                                                                                                              .codigoModalidad = modalidad,
                                                                                                              .codigoPuntoVenta = iCabecera.codigoPuntoVenta,
                                                                                                              .codigoRecepcion = objRespuesta.codigoRecepcion,
                                                                                                              .codigoSistema = codSistema,
                                                                                                              .codigoSucursal = iCabecera.codigoSucursal,
                                                                                                              .cufd = iCabecera.cufd,
                                                                                                              .cuis = cuis,
                                                                                                              .nit = iCabecera.nitEmisor}
                    Dim objValidar As New WindApp.ServiceRefFEstandar.validacionRecepcionFacturaElectronicaEstandar(iSolicitudValidacion)

                    Dim codigoResp = objClienteFactura.validacionRecepcionFacturaElectronicaEstandar(iSolicitudValidacion)


                    Dim a As String = objRespuesta.codigoRecepcion
                    MessageBox.Show("El valor el codigo recepcion es: " & a, catalgofacturacion.tmensaje, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End Using
        End If

    End Sub

#End Region

#Region "[Serializar]"

    Private Sub serializar()
        Try 'DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss")
            Dim objUtilitario As New libreriaCUF()
            Dim nit As String = "1028739027"
            nit = objUtilitario.getNitFormato(nit)
            Dim fecha As String = DateTimePicker1.Value




            Dim objCabecera As facturaElectronicaEstandarCabecera = New facturaElectronicaEstandarCabecera With {.nitEmisor = "1028739027",
                                                                   .numeroFactura = "1", .cuf = "a812312f1223892b",
                                                                   .codigoSucursal = "0",
                                                                   .direccion = "Parque Industrial PI-44",
                                                                   .codigoPuntoVenta = "1",
                                                                   .fechaEmision = DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss"),
                                                                   .nombreRazonSocial = "NOMBRE S.A.",
                                                                   .codigoTipoDocumentoIdentidad = "1",
                                                                   .numeroDocumento = "2615",
                                                                   .codigoCliente = "MMMario",
                                                                   .codigoMetodoPago = "1",
                                                                   .montoTotal = 3500,
                                                                   .montoDescuento = 0,
                                                                   .codigoMoneda = "688",
                                                                   .tipoCambio = 6.96,
                                                                   .montoTotalMoneda = 502.87,
                                                                   .leyenda = "Ley N° 453: Tienes derecho a recibir información sobre las características y contenidos de los servicios que utilices.",
                                                                   .usuario = "admin",
                                                                   .codigoDocumentoSector = "1"}

            Dim lista As New List(Of facturaElectronicaEstandarDetalle)
            Dim objDetalle As New facturaElectronicaEstandarDetalle With {.actividadEconomica = 103020, .codigoProductoSin = "21431", .codigoProducto = "1005",
                                                                          .descripcion = "COLITA DE CUADRIL", .cantidad = 100, .unidadMedida = "KG",
                                                                          .precioUnitario = 25, .montoDescuento = 0, .subTotal = 2500, .numeroSerie = "0"}
            lista.Add(objDetalle)

            Dim objFactura As facturaElectronicaEstandar = New facturaElectronicaEstandar() With {.cabecera = objCabecera, .detalle = lista.ToArray()}

            '---------------------------------------- SERIALIZAMOS ------------------------------------- 
            '-- utf-16 lo cambiamos a UTF8
            Dim pathXml As String = "D:\Facturacion\FACTURACION\WindApp\factxml.xml"
            Dim objSerializar As XmlSerializer = New XmlSerializer(GetType(facturaElectronicaEstandar))
            Dim sXml As String = ""
            Using sww As StringWriterWithEncoding = New StringWriterWithEncoding(Encoding.UTF8)
                Using writter As XmlWriter = XmlWriter.Create(sww)
                    objSerializar.Serialize(writter, objFactura)
                    sXml = sww.ToString()
                End Using
            End Using
            'Guardamos el string en un archivo
            System.IO.File.WriteAllText(pathXml, sXml)

            '-- utf-8 Genera automatico en UTF8 
            'Dim objSerializar1 As XmlSerializer = New XmlSerializer(GetType(facturaElectronicaEstandar))
            'Dim sw As StreamWriter = New StreamWriter("factura.xml", False)
            'objSerializar1.Serialize(sw, objFactura)
            'sw.Close()

            MessageBox.Show("Searializacion generada correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try
    End Sub

    Private Sub deserializar()
        Try
            Dim xmlSealizer As XmlSerializer = New XmlSerializer(GetType(facturaElectronicaEstandar))
            Dim sr As StreamReader = New StreamReader("factura.xml")
            Dim factura As facturaElectronicaEstandar = CType(xmlSealizer.Deserialize(sr), facturaElectronicaEstandar)

            dgvFactura.DataSource = factura.detalle

        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try
    End Sub

    Private Function generarCUF(ByVal array() As String) As String
        '................instancio un objte de la libreria
        Dim objUtilitario As New libreriaCUF()

        '................variable cuf
        Dim cuf As String = String.Empty

        '...............Declaro mis variables
        Dim anio As String : Dim mes As String : Dim dia As String
        Dim hora As String : Dim minuto As String : Dim sg As String
        Dim mils As String

        '................damos el formato para general el CUF
        anio = objUtilitario.getAnioFormat(array.GetValue(0)) : mes = objUtilitario.getMesFormat(array.GetValue(1))
        dia = objUtilitario.getDiaFormat(array.GetValue(2)) : hora = objUtilitario.getHoraFormat(array.GetValue(3))
        minuto = objUtilitario.getMinutoFormat(array.GetValue(4)) : sg = objUtilitario.getSegundoFormat(array.GetValue(5))
        mils = objUtilitario.getMilisegundoFormat(array.GetValue(6))

        '................agrupamos los el campo fecha para la cabera del XML
        Dim cFechaCab As String = anio & "-" & mes & "-" & dia & "T" & minuto & ":" & sg & ":" & mils

        '.................Declaramos variables para generar el Algoritmo Modulo Base 11
        Dim anio11 As String = objUtilitario.calculaDigitoModulo11(anio, 1, 9, False)
        Dim mes11 As String = objUtilitario.calculaDigitoModulo11(mes, 1, 9, False)
        Dim dia11 As String = objUtilitario.calculaDigitoModulo11(mes, 1, 9, False)
        Dim hora11 As String = objUtilitario.calculaDigitoModulo11(mes, 1, 9, False)
        Dim minu11 As String = objUtilitario.calculaDigitoModulo11(mes, 1, 9, False)
        Dim segu11 As String = objUtilitario.calculaDigitoModulo11(mes, 1, 9, False)



        Return cuf
    End Function

#End Region

#Region "[eventos]"

    Private Sub btnSerializar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSerializar.Click
        'Call serializar()
        Call generarAlta()
    End Sub

    Private Sub btnDeserializar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeserializar.Click
        Call deserializar()
    End Sub

#End Region

    Private Sub btnFormato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFormato.Click

        ''................capturo la fecha
        'Dim fechaBase As String = DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss.fff")
        'Dim fecha2 As String = fechaBase.Replace("T", "-")
        'fecha2 = fecha2.Replace(":", "-")
        'fecha2 = fecha2.Replace(".", "-")

        ''................capturo la fecha en un array
        'Dim array() As String = Split(fecha2, "-")

        ' Call generarAlta()
        Dim objUtilitario As New libreriaCUF
        'Dim nro As  BigInteger( txtFormatoCuf.Text)
        Dim varAux As String = txtFormatoCuf.Text  '123456789201901131637212310000111010000000100003
        Dim base1 As BigInteger = New BigInteger(123456789)

        Dim array(9) As String
        array.SetValue("0000123456789", 0) : array.SetValue("20190113163721231", 1)
        array.SetValue("0000", 2) : array.SetValue("1", 3)
        array.SetValue("1", 4) : array.SetValue("1", 5)
        array.SetValue("01", 6) : array.SetValue("00000001", 7)
        array.SetValue("0000", 8) : array.SetValue("3", 9)

        base1 = txtFormatoCuf.Text

        Dim valor122 As BigInteger = System.Numerics.BigInteger.Parse(txtFormatoCuf.Text)
        Dim vNit As String = objUtilitario.getHexadecimal(valor122)

        TextBox1.Text = vNit 'txtFormatoCuf.Text

        'Dim var As Integer = 50
        'Dim var1 As Integer = 5
        'Dim var2 As Integer = var / var1

        'Dim var3 As Integer = var \ var1

        'MessageBox.Show("Es /:" & var2 & " Es \:" & var3, "Informacion")
    End Sub



    Private Function darValor() As Decimal
        Try
            Dim intdd As Integer = 15 / 3
            Return True
        Catch ex As Exception
            'Return False
            ' MessageBox.Show("falso")
        End Try
        Return False
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
     
    End Sub

    Private Sub btnExplorar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExplorarCertificado.Click
        'Call explorar()
        Call explorarPfx()
    End Sub

    Private Sub explorar()
        Try
            Using objexp As New OpenFileDialog
                Dim directorio_ok As String = "C:\Facturacion\frigor\Archivos\" & Date.Now.Year & Date.Now.Month & Date.Now.Day '& "\" &
                objexp.Title = My.Resources.rcRecursos.seleccionXml
                objexp.Filter = My.Resources.rcRecursos.formatosXml
                objexp.InitialDirectory = directorio_ok
                objexp.FilterIndex = 1
                If objexp.ShowDialog() = DialogResult.OK Then
                    txtDirectorioXML.Text = objexp.FileName
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub explorarPfx()
        Try
            Using objexp As New OpenFileDialog
                'Dim directorio_ok As String = "D:\Facturacion\FACTURACION\WindApp"
                Dim directorio_ok As String = "C:\Facturacion\frigor\Archivos\" & Date.Now.Year & Date.Now.Month & Date.Now.Day '& "\" &
                objexp.Title = My.Resources.rcRecursos.seleccionPfx
                objexp.Filter = My.Resources.rcRecursos.formatosCertificado
                objexp.InitialDirectory = directorio_ok
                objexp.FilterIndex = 1
                If objexp.ShowDialog() = DialogResult.OK Then
                    txtDirectorioCetificado.Text = objexp.FileName
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub validarXml()

    End Sub

    Private Sub firmarXml()
        If Not String.IsNullOrEmpty(txtDirectorioCetificado.Text) Then

            Dim objSerializar As New clsSerializador
            objSerializar.RutaCertificadoDigital = Convert.ToBase64String(File.ReadAllBytes(txtDirectorioCetificado.Text))
            objSerializar.PasswordCertificado = ""
            objSerializar.TipoDocumento = 1

            Dim byteArray = File.ReadAllBytes(txtDirectorioXML.Text)

            Dim tramaFirmado = objSerializar.FirmarXml(Convert.ToBase64String(byteArray))

            Dim nombreArchivo = "primeraFirma"
            Using fs = File.Create(nombreArchivo & ".xml")
                Dim byteFirmado = Convert.FromBase64String(tramaFirmado)
                fs.Write(byteFirmado, 0, byteFirmado.Length)
            End Using

            Dim tramaZip = objSerializar.GenerarZip(tramaFirmado, nombreArchivo)

        End If

    End Sub

    Private Sub btnFirmarXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirmarXML.Click
        'Call firmarXml()
        Dim oFirma As New clsFirma
        oFirma.firmar(txtDirectorioXML.Text)

    End Sub


    Private Sub btnExpXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExpXML.Click
        Call explorar()
    End Sub

    Private Sub validarFacturaContraImpuestos()
        Try
            Dim oFactura As New ServicioFacturaElectronicaEstandarClient
            Dim CUFD As String = String.Empty
            If getCUFD(2, 1, "5D07CC8BC36", 0, "A5654D3F", "1028739027") Then
                CUFD = cufdObtenido
            End If
            Dim oSolicitud As New solicitudValidacionRecepcion With {.codigoAmbiente = 2, .codigoDocumentoFiscal = 1,
                                                                     .codigoDocumentoSector = 1, .codigoEmision = 1,
                                                                     .codigoModalidad = 1, .codigoPuntoVenta = Nothing,
                                                                     .codigoSistema = "5D07CC8BC36", .codigoSucursal = 0,
                                                                     .cufd = CUFD, .cuis = "A5654D3F",
                                                                     .nit = 1028739027}
            'Private codigoAmbiente As Integer        OK
            'Private codigoDocumentoFiscal As Integer OK
            'Private codigoDocumentoSector As Integer OK
            'Private codigoEmision As Integer  .......OK    
            'Private codigoModalidad As Integer       OK
            'Private codigoPuntoVenta As System.Nullable(Of Integer)
            'Private codigoPuntoVentaFieldSpecified As Boolean
            'Private codigoRecepcion As Long
            'Private codigoSistema As String
            'Private codigoSucursal As Integer
            'Private cufd As String
            'Private cuis As String
            'Private nitField As Long

            Dim oRespuesta As New respuesta
            oRespuesta = oFactura.validacionRecepcionFacturaElectronicaEstandar(oSolicitud)

            'Private listaCodigosRespuestasField() As System.Nullable(Of Integer)
            'Private listaDescripcionesRespuestasField() As String
            'Private listaErroresDetallesField() As recepcionErrorDetalleDto

            If Not oRespuesta.listaCodigosRespuestas Is Nothing Then
                Dim codRespuesta As String = String.Empty

                Dim contador As Integer = oRespuesta.listaCodigosRespuestas.Count
                Dim nro As Integer = 0

                For i = 0 To oRespuesta.listaCodigosRespuestas.Count - 1 Step 1
                    If i = contador Then
                        codRespuesta = codRespuesta & oRespuesta.listaCodigosRespuestas.GetValue(i)
                    Else
                        codRespuesta = codRespuesta & oRespuesta.listaCodigosRespuestas.GetValue(i)
                    End If
                Next
                MessageBox.Show(codRespuesta, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            If Not oRespuesta.listaErroresDetalles Is Nothing Then
                Dim codRespuesta As String = String.Empty
                Dim contador As Integer = oRespuesta.listaErroresDetalles.Count
                Dim nro As Integer = 0
                For Each irespuesta As recepcionErrorDetalleDto In oRespuesta.listaErroresDetalles
                    nro = nro + 1
                    If nro = contador Then
                        codRespuesta = codRespuesta & irespuesta.cuf
                    Else
                        codRespuesta = codRespuesta & irespuesta.numeroFactura & ","
                    End If
                Next
            End If
            ' codigoEmision codigoRecepcion
            If Not oRespuesta.listaDescripcionesRespuestas Is Nothing Then
                Dim codRespuesta As String = String.Empty

                Dim contador As Integer = oRespuesta.listaDescripcionesRespuestas.Count
                Dim nro As Integer = 0

                For i = 0 To oRespuesta.listaDescripcionesRespuestas.Count - 1 Step 1
                    If i = contador Then
                        codRespuesta = codRespuesta & oRespuesta.listaDescripcionesRespuestas.GetValue(i)
                    Else
                        codRespuesta = codRespuesta & oRespuesta.listaDescripcionesRespuestas.GetValue(i) & vbNewLine
                    End If
                Next
                MessageBox.Show(codRespuesta, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else

            End If
        Catch ex As Exception

        End Try
    End Sub

    '_________________________________AQUI ESTOY
    Private Sub respuestaFacturaImpuesto(ByVal iCabecera As facturaElectronicaEstandarCabecera, ByVal codAmbiente As String, ByVal codDFicales As String,
                                         ByVal codEmision As String, ByVal codModalidad As String, ByVal codSistema As String,
                                         ByVal cuis As String,
                                         ByVal codMotiAnulacion As String,
                                         ByVal fenivio As Date)
        Dim oFactura As New ServicioFacturaElectronicaEstandarClient()

        If oFactura.verificarComunicacion() Then
            Using oParametros As New Negocios.UtilitarioSIN(usuario, clave)
                Dim ambiente As String = String.Empty
                Dim dtAmbiente As New DataTable
                dtAmbiente = oParametros.getAmbienteBL(codAmbiente)
                If oParametros.existeError Then
                    MessageBox.Show(oParametros.mensajesErrorSistema & vbNewLine & oParametros.mensajesErrorUsuario, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    If dtAmbiente.Rows.Count > 0 Then
                        ambiente = IIf(IsDBNull(dtAmbiente.Rows(0).Item("codigo")), Nothing, dtAmbiente.Rows(0).Item("codigo"))
                    End If
                End If

                Dim docuFicales As String = String.Empty
                Dim dtDocuFiscal As New DataTable
                dtDocuFiscal = oParametros.getDocuFicalesBL(codDFicales)
                If oParametros.existeError Then
                    MessageBox.Show(oParametros.mensajesErrorSistema & vbNewLine & oParametros.mensajesErrorUsuario, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    If dtDocuFiscal.Rows.Count > 0 Then
                        docuFicales = IIf(IsDBNull(dtDocuFiscal.Rows(0).Item("codigo")), Nothing, dtDocuFiscal.Rows(0).Item("codigo"))
                    End If
                End If

                Dim tipoEmison As String = String.Empty
                Dim dtEmision As New DataTable
                dtEmision = oParametros.getEmisionBL(codEmision)
                If oParametros.existeError Then
                    MessageBox.Show(oParametros.mensajesErrorSistema & vbNewLine & oParametros.mensajesErrorUsuario, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    If dtEmision.Rows.Count > 0 Then
                        tipoEmison = IIf(IsDBNull(dtEmision.Rows(0).Item("codigo")), Nothing, dtEmision.Rows(0).Item("codigo"))
                    End If
                End If

                Dim modalidad As String = String.Empty
                Dim dtModiladad As New DataTable
                dtEmision = oParametros.getModalidadBL(codModalidad)
                If oParametros.existeError Then
                    MessageBox.Show(oParametros.mensajesErrorSistema & vbNewLine & oParametros.mensajesErrorUsuario, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    If dtModiladad.Rows.Count > 0 Then
                        modalidad = IIf(IsDBNull(dtModiladad.Rows(0).Item("codigo")), Nothing, dtModiladad.Rows(0).Item("codigo"))
                    End If
                End If


                '____________________ codigoRecepcion ???
                Dim iSolServicioValidacion As New solicitudValidacionRecepcion With {.codigoAmbiente = ambiente, .codigoDocumentoFiscal = docuFicales,
                                                                                     .codigoDocumentoSector = iCabecera.codigoDocumentoSector,
                                                                                     .codigoEmision = tipoEmison,
                                                                                     .codigoModalidad = modalidad,
                                                                                     .codigoPuntoVenta = iCabecera.codigoPuntoVenta,
                                                                                     .codigoRecepcion = "",
                                                                                     .codigoSistema = codSistema,
                                                                                     .codigoSucursal = iCabecera.codigoSucursal,
                                                                                     .cufd = iCabecera.cufd,
                                                                                     .cuis = cuis,
                                                                                     .nit = iCabecera.nitEmisor}

                oFactura.Open()
                oFactura.validacionRecepcionFacturaElectronicaEstandar(iSolServicioValidacion)

                oFactura.validacionRecepcionPaqueteFacturaElectronicaEstandar(iSolServicioValidacion)


                Dim motiAnulacion As String = String.Empty
                Dim dtMotiAnulacin As New DataTable
                dtMotiAnulacin = oParametros.getMotivoAnulacionBL(codMotiAnulacion)
                If oParametros.existeError Then
                    MessageBox.Show(oParametros.mensajesErrorSistema & vbNewLine & oParametros.mensajesErrorUsuario, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    If dtMotiAnulacin.Rows.Count > 0 Then
                        motiAnulacion = IIf(IsDBNull(dtMotiAnulacin.Rows(0).Item("codigo")), Nothing, dtMotiAnulacin.Rows(0).Item("codigo"))
                    End If
                End If

                Dim iSolValidacionAnulaicon As New solicitudValidacionAnulacion With {.codigoAmbiente = ambiente, .codigoDocumentoFiscal = docuFicales,
                                                                                      .codigoDocumentoSector = iCabecera.codigoDocumentoSector,
                                                                                      .codigoEmision = tipoEmison,
                                                                                      .codigoModalidad = modalidad,
                                                                                      .codigoMotivo = motiAnulacion,
                                                                                      .codigoPuntoVenta = iCabecera.codigoPuntoVenta,
                                                                                      .codigoRecepcion = "",
                                                                                      .codigoSistema = codSistema,
                                                                                      .codigoSucursal = iCabecera.codigoSucursal,
                                                                                      .cuf = iCabecera.cuf,
                                                                                      .cufd = iCabecera.cufd,
                                                                                      .cuis = cuis,
                                                                                      .nit = iCabecera.nitEmisor,
                                                                                      .numeroDocumentoFiscal = ""}

                '____________________ numeroDocumentoFiscal ???

                oFactura.validacionAnulacionFacturaElectronicaEstandar(iSolValidacionAnulaicon)

                Dim iSolicitudRepcepcion As New solicitudRecepcion With {.archivo = "",
                                                                         .codigoAmbiente = ambiente,
                                                                         .codigoDocumentoFiscal = docuFicales,
                                                                         .codigoDocumentoSector = iCabecera.codigoDocumentoSector,
                                                                         .codigoEmision = tipoEmison,
                                                                         .codigoModalidad = modalidad,
                                                                         .codigoPuntoVenta = iCabecera.codigoPuntoVenta,
                                                                         .codigoSistema = codSistema,
                                                                         .codigoSucursal = iCabecera.codigoSucursal,
                                                                         .cufd = iCabecera.cufd,
                                                                         .cuis = cuis,
                                                                         .fechaEnvio = fenivio,
                                                                         .hashArchivo = "",
                                                                         .nit = iCabecera.nitEmisor}

                oFactura.recepcionFacturaElectronicaEstandar(iSolicitudRepcepcion)
                oFactura.recepcionPaqueteFacturaElectronicaEstandar(iSolicitudRepcepcion)

                ' oFactura .
                'CONSUMIENTE EL SERVICIO DE RECCEPCION
                oFactura.Close()
            End Using
        End If
        Dim oSolicitud As New solicitudRecepcion With {.archivo = "",
                                                       .codigoAmbiente = 2,
                                                       .codigoDocumentoFiscal = "",
                                                       .codigoDocumentoSector = "",
                                                       .codigoEmision = "",
                                                       .codigoModalidad = "",
                                                       .codigoPuntoVenta = "",
                                                       .codigoSistema = "",
                                                       .codigoSucursal = "",
                                                       .cufd = "",
                                                       .cuis = "A5654D3F",
                                                       .fechaEnvio = Date.Now.ToShortDateString,
                                                       .hashArchivo = "",
                                                       .nit = 1028739027}
        ' Dim solicitud As New solicitudValidacionRecepcion With {.
        'oFactura.verificarComunicacion()
        'oFactura.validacionAnulacionFacturaElectronicaEstandar()

        'If oFactura.validacionRecepcionFacturaElectronicaEstandar(oSolicitud) Then

        'End If



    End Sub

    

    Private Sub btnValidarXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValidarXML.Click
        Call validarFacturaContraImpuestos()
    End Sub


    Private Sub btnComprir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComprir.Click
        Try
            Using objexp As New OpenFileDialog
                Dim directorio_ok As String = "C:\Facturacion\frigor\Archivos\" & Date.Now.Year & Date.Now.Month & Date.Now.Day '& "\" &
                objexp.Title = My.Resources.rcRecursos.seleccionXml
                objexp.Filter = My.Resources.rcRecursos.formatosXml
                objexp.InitialDirectory = directorio_ok
                objexp.FilterIndex = 1
                If objexp.ShowDialog() = DialogResult.OK Then
                    TextBox1.Text = objexp.FileName
                End If
            End Using

        Catch ex As Exception

        End Try
        If Not String.IsNullOrEmpty(TextBox1.Text) Then
            Dim oFirma As New clsFirma
            Dim mensajeGZip As String = String.Empty
            If oFirma.comprimirGZip(TextBox1.Text, mensajeGZip) Then
                MessageBox.Show("Correcto Comprimido", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show(mensajeGZip, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub btnFirmar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirmar.Click
        Dim oFirmar As New clsFirmando
        oFirmar.Firmar()

    End Sub
End Class