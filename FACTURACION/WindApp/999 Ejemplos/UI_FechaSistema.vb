Imports WindApp.ServiceRefCufd
Imports WindApp.ServiceRefSinFechaHora
Imports WindApp.ServiceRefFEstandar
Imports System.IO
Imports Ionic.Zlib
Imports Ionic.Zip
Public Class UI_FechaSistema : Inherits f_base

#Region "[atributosGlobales]"

    Private usuario As String
    Private clave As String
    Private fSistema As String
    Private cufdObtenido As String

#End Region

#Region "[constructor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String)
        MyBase.New("FORMULARIO CAMBIO DE HORA", "Cambio y ajuete  de hora del servidor")
        InitializeComponent()
        usuario = usuar
        clave = clav
    End Sub

#End Region

#Region "[metodos]"

    Private Function getCUFD(ByVal codSucrusal As String) As Boolean
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
                For Each irespuesta As WindApp.ServiceRefCufd.respuestaCodigosMensajesSoapDto In objRespuesta.listaCodigosRespuestas
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
        Return False
    End Function

    Private Function getFechaYHoraSIN() As Boolean
        Try
            Dim oSolSincronizacion As New solicitudSincronizacion With {.codigoAmbiente = "2",
                                                                        .codigoPuntoVenta = 1,
                                                .codigoSistema = "5D07CC8BC36",
                                                .codigoSucursal = "0",
                                                .cuis = "A5654D3F",
                                                .nit = "1028739027"}

            Dim oSerSincrFechaHoraClient As New ServicioSincronizacionFechaHoraClient()
            Dim oRespuestaFHora As New respuestaFechaHora()

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
                fSistema = oRespuestaFHora.fechaHora
                Return True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try
        Return False
    End Function

    Private Sub getServicioFStandar()
        Dim objCliente As New ServicioFacturacionCufdClient

        'Dim item As New ServiceRefFEstandar.solicitudRecepcion With {. 

        'Dim objFacturacion As New ServiceRefFEstandar.ServicioFacturaElectronicaEstandarClient()

    End Sub


    '________________________________ Algoritmo SH256

    Public Sub getSH256()
        'Dim sh256 As String = clsAlgoritmos.getSHA256(txtExplorar.Text)
        'txtSH256.Text = sh256
    End Sub

    Public Sub getBase64(ByVal url As String)
        If Not String.IsNullOrEmpty(url) Then
            If Not String.IsNullOrEmpty(url) Then 'COMPRIMIMOS LA CADENA BASE64 
                Dim oFirma As New clsFirma
                Dim mensajeGZip As String = String.Empty
                If oFirma.comprimirGZip(url, mensajeGZip) Then
                    MessageBox.Show("Correcto Comprimido", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show(mensajeGZip, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End If


            'txtSH256.Text = cadBase64
        End If
    End Sub

    Public Function generaNZip(ByVal tramaXML As String, ByVal nombreArchivo As String)
        Dim memOrigemn = New MemoryStream(Convert.FromBase64String(tramaXML))
        Dim menDestino = New MemoryStream

        'Dim fileToBeGZipped As FileInfo = New FileInfo(memOrigemn)


        'Using File = New ZipFile("{nombreArchivo}.zip}")

        'End Using
    End Function

#End Region

#Region "[eventos]"

    Private Sub btnCuis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCuis.Click
        Call getCUFD("0")
        txtCuis.Text = cufdObtenido
    End Sub

    Private Sub btnFechaHora_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFechaHora.Click
        Call getFechaYHoraSIN()
        If Not String.IsNullOrEmpty(fSistema) Then
            txtFechaHora.Text = fSistema
        End If
    End Sub

    Private Sub btnExplorar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExplorar.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub btnSh256_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSh256.Click
        'Call getSH256()
        Call getBase64(txtExplorar.Text)
    End Sub

    Private Sub OpenFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        txtExplorar.Text = OpenFileDialog1.FileName
    End Sub

#End Region



End Class