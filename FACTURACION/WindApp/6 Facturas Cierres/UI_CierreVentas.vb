Imports Entidades

Public Class UI_CierreVentas : Inherits f_base

#Region "[atributosGlobales]"

    Private usuario As String
    Private clave As String

#End Region

#Region "[contrutor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String)
        MyBase.New(usuar, clav, "DATOS CIERRE FACTURACIÓN", "Realize la operacion necesaria...")
        InitializeComponent()
        usuario = usuar
        clave = clav
    End Sub

#End Region

#Region "[metodos]"

    Private Function validar(ByVal cotizacion As Decimal)
        Dim Result As Integer = 0
        Dim value As DateTime
        dxErrorProvider.Clear()

        If String.IsNullOrEmpty(fcierre.Text) Then
            dxErrorProvider.SetError(fcierre, "El campo fecha es requerido")
            fcierre.Focus()
            Return False
        ElseIf Not DateTime.TryParse(fcierre.Text, value) Then
            dxErrorProvider.SetError(fcierre, "El campo fecha no tiene el formato correcto")
            fcierre.Focus()
            Return False
        ElseIf cotizacion <= Decimal.Zero Then
            MessageBox.Show("Cotizacion asignada no puede ser menor o igual que cero", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        ElseIf Not Decimal.TryParse(cotizacion, Result) Then
            MessageBox.Show("No existe cotizacon para la fecha asiganda", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If

        Return True
    End Function

    Private Sub altaCierre()

        Dim cotizacion As Decimal = Decimal.Zero
        Try
            Dim objConexion As New Negocios.UtilitarioBL(usuario, clave)
            Dim dtConexion As New DataTable
            dtConexion = objConexion.getDatosConexion("93012", "1")
            'cotizacion = objCierre.getCotizacionBL(fcierre.Text)
            Using objCierre As New Negocios.CierreVentasBL(dtConexion)
                cotizacion = objCierre.getCotizacionBL(fcierre.Text)
                If validar(cotizacion) Then
                    objCierre.validarDatosTransaccion()
                    If (objCierre.datosValidosParametros) Then
                        Call objCierre.limpiarErrorBase()
                        Call objCierre.abrirTransaccion()
                        Dim band As Boolean = False
                        'Call objCierre.altaBL(item)
                        If objCierre.altaLiqProveedorBL(fcierre.Text, cotizacion, usuario) Then
                            If objCierre.altaLimpiezaMenudosBL(fcierre.Text, cotizacion, usuario) Then
                                If objCierre.altaVentaSebosBL(fcierre.Text, cotizacion, usuario) Then
                                    If objCierre.altaVentaSangreFetalBL(fcierre.Text, cotizacion, usuario) Then
                                        If objCierre.altaVentaDescarteUnoBL(fcierre.Text, cotizacion, usuario) Then
                                            If objCierre.altaVentaDescarteDosbl(fcierre.Text, cotizacion, usuario) Then
                                                If objCierre.altaVentaDescarteTresBL(fcierre.Text, cotizacion, usuario) Then
                                                    If objCierre.altaServicioAcopioHielBL(fcierre.Text, cotizacion, usuario) Then
                                                        If objCierre.altaBosasCarneIndustrialBL(fcierre.Text, cotizacion, usuario) Then
                                                            If objCierre.altaServicioMenudoPorcinoBL(fcierre.Text, cotizacion, usuario) Then
                                                                If objCierre.altaCueroBL(fcierre.Text, cotizacion, usuario) Then
                                                                    band = True
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If

                        If band Then
                            If objCierre.existeError Then
                                Call objCierre.rechazarTransaccion()
                                MessageBox.Show(String.Format("{0} {1}", objCierre.mensajesErrorSistema, objCierre.mensajesErrorUsuario),
                                                                           "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Else
                                objCierre.aceptarTransaccion()
                                MessageBox.Show("Transacción realizada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                'Call limpiar()
                            End If
                        Else
                            Call objCierre.rechazarTransaccion()
                            MessageBox.Show(String.Format("{0} {1}", objCierre.mensajesErrorSistema, objCierre.mensajesErrorUsuario),
                                                                       "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                    End If
                End If
            End Using
        Catch ex As Exception

        End Try

    End Sub

    Private Function validar()
        Dim value As DateTime
        dxErrorProvider.Clear()

        If String.IsNullOrEmpty(fCierreBaja.Text) Then
            dxErrorProvider.SetError(fcierre, "El campo fecha es requerido")
            fCierreBaja.Focus()
            Return False
        ElseIf Not DateTime.TryParse(fCierreBaja.Text, value) Then
            dxErrorProvider.SetError(fCierreBaja, "El campo fecha no tiene el formato correcto")
            fCierreBaja.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub bajaCierre()
        Try
            Dim objConexion As New Negocios.UtilitarioBL(usuario, clave)
            Dim dtConexion As New DataTable
            dtConexion = objConexion.getDatosConexion("93012", "1")

            Using objCierre As New Negocios.CierreVentasBL(dtConexion)
                If validar() Then
                    objCierre.validarDatosTransaccion()
                    If (objCierre.datosValidosParametros) Then
                        Call objCierre.limpiarErrorBase()
                        Call objCierre.abrirTransaccion()
                        Dim band As Boolean = False

                        If objCierre.bajaCierreBL(fCierreBaja.Text) Then
                            band = True
                        End If

                        If band Then
                            If objCierre.existeError Then
                                Call objCierre.rechazarTransaccion()
                                MessageBox.Show(String.Format("{0} {1}", objCierre.mensajesErrorSistema, objCierre.mensajesErrorUsuario),
                                                                           "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Else
                                objCierre.aceptarTransaccion()
                                MessageBox.Show("Transacción realizada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                'Call limpiar()
                            End If
                        Else
                            Call objCierre.rechazarTransaccion()
                            MessageBox.Show(String.Format("{0} {1}", objCierre.mensajesErrorSistema, objCierre.mensajesErrorUsuario),
                                                                       "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                    End If

                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

#End Region

#Region "[eventos]"

    Private Sub btnCierre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCierre.Click
        Call altaCierre()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Call Close()
    End Sub

    Private Sub btnBaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBaja.Click
        Using oFormSeguridad As New UI_Seguridad(usuario, clave)
            If oFormSeguridad.ShowDialog <> Windows.Forms.DialogResult.OK Then
                Call Close()
            Else
                Call bajaCierre()
            End If
        End Using
    End Sub

    Private Sub btnSalirCierre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalirCierre.Click
        Call Close()
    End Sub

#End Region

End Class