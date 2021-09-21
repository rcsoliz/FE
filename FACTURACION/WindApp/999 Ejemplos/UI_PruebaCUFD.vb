Imports WindApp.ServiceRefCufd

Public Class UI_PruebaCUFD : Inherits f_base

#Region "[atributosGlobales]"

    Private usuario As String
    Private clave As String

#End Region

#Region "[constructor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String)
        InitializeComponent()
        usuario = usuar
        clave = clav
    End Sub

#End Region

#Region "[metodos]"

    Private Sub getCUFD()
        Try
            Dim item As New solicitudOperaciones With {.codigoAmbiente = 2, .codigoModalidad = 1,
                                                       .codigoSistema = "5D07CC8BC36",
                                                       .codigoSucursal = 0, .cuis = "A5654D3F", .nit = 1028739027}
                'oOperacion.codigoAmbiente = 2; oOperacion.codigoModalidad = 1; oOperacion.codigoSistema = "5D07CC8BC36";
                'oOperacion.codigoSucursal = 0; oOperacion.cuis = "A5654D3F";  oOperacion.nit = 1028739027;

            '______________________ServicioFacturacionCufdClient
            Dim objCliente As New ServicioFacturacionCufdClient
            Dim objRespuesta As New respuestaCufd
            objRespuesta = objCliente.solicitudCufd(item)

            Dim vComunicacion As Integer = objCliente.verificarComunicacion()

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

            Else
                Dim a As String = objRespuesta.codigo
                MessageBox.Show("El valor del CUFD es: " & a, catalgofacturacion.tmensaje, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region

#Region "[eventos]"

    Private Sub DataGridView1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.V Then
            Try
                For Each line As String In Clipboard.GetText.Split(vbNewLine)
                    Dim item() As String = line.Trim.Split(vbTab)
                    If item.Length = Me.DataGridView1.ColumnCount Then
                        DataGridView1.Rows.Add(item)
                    Else
                        DataGridView1.Rows.Add(item)
                    End If
                Next

            Catch ex As Exception
                MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnGenerar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Call getCUFD()
    End Sub

#End Region

  

End Class