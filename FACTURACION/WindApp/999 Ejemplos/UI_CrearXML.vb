Imports Entidades
Imports Negocios
Imports System.Numerics
Imports System.Xml
Imports System.Xml.Serialization
Imports WindApp.ServiceRefCufd
Imports WindApp.My.Resources.rcRecursos
Imports WindApp.ServiceRefFEstandar
Imports System.Security.Cryptography.X509Certificates
Imports System.Text

Public Class UI_CrearXML : Inherits f_base

#Region "[atributosGlobales]"

    Private usuario As String
    Private clave As String
    Private cufdObtenido As String
    Private pathXml As String
    Private pathCertificado As String
    Private pathKey As String

#End Region

#Region "[constructor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String)
        InitializeComponent()
        usuario = usuar
        clave = clav
        pathCertificado = "D:\Facturacion\FACTURACION\WindApp\frigorCertificado.pem"
        pathKey = "D:\Facturacion\FACTURACION\WindApp\frigorPrivateKey.pem"
    End Sub

#End Region

#Region "[metodos]"

    Private Sub generarXML()
        Try
            'obtenemos datos segun la ctividad (codactividad, nit, nombre, cns, etc.)
            Dim oActividad As New Negocios.UtilitarioBL(usuario, clave)
            Dim dtActividad As New DataTable
            dtActividad = oActividad.getActividadBL("1")
            If oActividad.existeError Then
                MessageBox.Show(oActividad.mensajesErrorUsuario & vbNewLine & oActividad.mensajesErrorUsuario,
                                WindApp.My.Resources.rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Dim nit As String = If(IsDBNull(dtActividad.Rows(0).Item("nic")), Nothing, dtActividad.Rows(0).Item("nic"))

            'obtnemos datos configuracion sistema (codigo, cuis,  urlcertificado, clave, codsistema, etc.)
            Dim oConfiguracion As New Negocios.ConfiguracionBL(usuario, clave)
            Dim dtConfiguracion As New DataTable
            Dim itemConf As New Entidades.tb_configuracion() With {.codigo = 1}
            dtConfiguracion = oConfiguracion.getConfiguracionBL(itemConf)
            If oConfiguracion.existeError Then
                MessageBox.Show(oConfiguracion.mensajesErrorUsuario & vbNewLine & oConfiguracion.mensajesErrorUsuario,
                                WindApp.My.Resources.rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Dim objUtilitario As New libreriaCUF()
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
            Dim cFechaCabXML As String = anio & "-" & mes & "-" & dia & "T" & minuto & ":" & sg & ":" & mils 'Valor cabecera XML

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
            Dim puntoVenta As String = "0"
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
            '____________________________________________________________________ END CUF________________________________________________________________

            Dim ambiente As String = oUtilitario.getCatalogoBL(catalgofacturacion.ambiente, 2)
            Dim codSistema As String = dtConfiguracion.Rows(0).Item("codsistema") ' "5D07CC8BC36"  codigo, cuis,  urlcertificado, clave, codsistema, etc.)
            Dim cuis As String = dtConfiguracion.Rows(0).Item("cuis")  ' "A5654D3F" 

            cufdObtenido = String.Empty
            Dim codMetodoPago As String = oUtilitario.getCatalogoBL(catalgofacturacion.mPago, 1)
            Dim codDocIdentidad As String = oUtilitario.getCatalogoBL(catalgofacturacion.dIdentidad, 1)
            Dim codMoneda As String = oUtilitario.getCatalogoBL(catalgofacturacion.monedas, 688)

            If getCUFD(ambiente, codigoDocumentoFiscal, codSistema, sucrusal, cuis, nit) Then
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
                                                                              .complemento = "Glosa de prueba facturas",
                                                                              .codigoCliente = "315",
                                                                              .codigoMetodoPago = codMetodoPago,
                                                                              .numeroTarjeta = Nothing,
                                                                              .montoTotal = 100,
                                                                              .montoDescuento = Nothing,
                                                                              .codigoMoneda = codMoneda,
                                                                              .tipoCambio = 6.96,
                                                                              .montoTotalMoneda = 14.37,
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

                    pathXml = directorio

                    Dim mensaje As String = String.Empty
                    If seralizarXML(objFactura, mensaje) Then

                        'Dim certificado As X509Certificate2 = New X509Certificate2(pathCertificado)
                        'Dim xmlDocumento As XmlDocument
                        'xmlDocumento = clsFirmando.SignXmlDocument(pathXml, certificado)

                    End If
                End If
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

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
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try
        Return True
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
            '_______________ Guardamos el string en un archivo
            System.IO.File.WriteAllText(pathXml, sXml)
        Catch ex As Exception
            mensaje = ex.Message ', catalgofacturacion.tmensaje, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End Try
        Return True
    End Function

#End Region

#Region "[eventos]"

#End Region

End Class