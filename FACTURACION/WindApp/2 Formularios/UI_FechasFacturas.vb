Imports Entidades
Imports WindApp.My.Resources
Public Class UI_FechasFacturas : Inherits f_base

#Region "[atributosGlobales]"

    Private usuario As String
    Private clave As String
    Private opcion As Integer
    Private lista As List(Of tb_FechasFactura)
    Private index As Integer

#End Region

#Region "[contrutor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String, ByVal opc As Integer)
        MyBase.New(usuar, clav, "DATOS FECHAS MODULO-FACTURACION", "Realize la operacion necesaria...")
        InitializeComponent()
        usuario = usuar : clave = clav
        opcion = opc
        Call getOpcion()
        Call limpiar()
    End Sub

    Public Sub New(ByVal usuar As String, ByVal clav As String, ByVal list As List(Of tb_FechasFactura), ByVal opc As Integer)
        MyBase.New(usuar, clav, "DATOS FECHAS MODULO-FACTURACION", "Realize la operacion necesaria...")
        InitializeComponent()
        usuario = usuar : clave = clav
        lista = list
        opcion = opc
        Call getOpcion()
        Call inicio()
    End Sub

#End Region

#Region "[metodos]"

    Private Sub getOpcion()
        If opcion = 1 Then
            btnGuardar.Enabled = True
            btnModificar.Enabled = False
            btnEliminar.Enabled = False
        ElseIf opcion = 2 Then
            btnGuardar.Enabled = False
            btnModificar.Enabled = True
            btnEliminar.Enabled = False
            txtGestion.ReadOnly = Not False
            txtMes.ReadOnly = Not False

        ElseIf opcion = 3 Then
            btnGuardar.Enabled = False
            btnModificar.Enabled = False
            btnEliminar.Enabled = True

            txtGestion.ReadOnly = False
            txtMes.ReadOnly = False
        Else
            btnGuardar.Enabled = False
            btnModificar.Enabled = False
            btnEliminar.Enabled = False
        End If
    End Sub

    Private Function validar() As Boolean
        Dim Result As Integer = 0
        dxErrorProvider.Clear()
        If String.IsNullOrEmpty(txtGestion.Text) Then
            dxErrorProvider.SetError(txtGestion, "El campo gestion NO puede ser vacio")
            txtGestion.Focus()
        ElseIf Integer.Parse(txtGestion.Text) < 0 Then
            dxErrorProvider.SetError(txtGestion, "El campo gestión no puede ser menor que cero")
            txtGestion.Focus()
            Return False
        ElseIf txtGestion.Text.Length <> 4 Then
            dxErrorProvider.SetError(txtGestion, "El campo gestión solo acepta 4 digitos ")
            txtGestion.Focus()
        ElseIf Not Int32.TryParse(txtGestion.Text, Result) Then
            dxErrorProvider.SetError(txtGestion, "El campo gestión es requerido")
            txtGestion.Focus()
            Return False

        ElseIf String.IsNullOrEmpty(txtMes.Text) Then
            dxErrorProvider.SetError(txtMes, "El campo mes NO puede ser vacio")
            txtMes.Focus()
            Return False
        ElseIf Integer.Parse(txtMes.Text) < 0 Then
            dxErrorProvider.SetError(txtMes, "El campo mes NO puede ser menor que cero")
            txtMes.Focus()
            Return False
        ElseIf txtMes.Text.Length < 0 Or txtMes.Text.Length > 2 Then
            dxErrorProvider.SetError(txtMes, "El campo gestión solo acepta 2 digitos ")
            txtMes.Focus()
            Return False
        ElseIf Not Int32.TryParse(txtMes.Text, Result) Then
            dxErrorProvider.SetError(txtMes, "El campo mes es requerido")
            txtMes.Focus()
            Return False
        Else
            Return True
        End If
        Return True
    End Function

    Private Sub limpiar()
        txtGestion.Text = String.Empty
        txtMes.Text = String.Empty
        ckEstado.Checked = False
    End Sub

    Private Sub alta()
        Using objFechaFact As New Negocios.FechaFacturasBL(usuario, clave)
            If validar() Then
                Dim vEstado As Integer
                If ckEstado.Checked = True Then
                    vEstado = 0
                Else
                    vEstado = 1
                End If
                Dim item As New tb_FechasFactura With {.gestion = txtGestion.Text, .mes = txtMes.Text,
                                                 .estado = vEstado}
                objFechaFact.validarDatosTransaccion()
                If (objFechaFact.datosValidosParametros) Then
                    Call objFechaFact.limpiarErrorBase()
                    Call objFechaFact.abrirTransaccion()
                    Call objFechaFact.altaBL(item)
                    If objFechaFact.existeError Then
                        Call objFechaFact.rechazarTransaccion()
                        MessageBox.Show(String.Format("{0} {1}", objFechaFact.mensajesErrorSistema, objFechaFact.mensajesErrorUsuario),
                                                                   rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        objFechaFact.aceptarTransaccion()
                        MessageBox.Show(rcRecursos.msOK, rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Call limpiar()
                    End If
                End If
            End If
            objFechaFact.finalizar()
        End Using
    End Sub

    Private Sub baja()
        Using objParFactura As New Negocios.FechaFacturasBL(usuario, clave)
            If validar() Then
                Dim vEstado As Integer
                If ckEstado.Checked = True Then
                    vEstado = 0
                Else
                    vEstado = 1
                End If
                Dim item As New tb_FechasFactura With {.gestion = txtGestion.Text, .mes = txtMes.Text,
                                                 .estado = vEstado}
                objParFactura.validarDatosTransaccion()
                If (objParFactura.datosValidosParametros) Then
                    Call objParFactura.limpiarErrorBase()
                    Call objParFactura.abrirTransaccion()
                    Call objParFactura.updateBL(item)
                    If objParFactura.existeError Then
                        Call objParFactura.rechazarTransaccion()
                        MessageBox.Show(String.Format("{0} {1}", objParFactura.mensajesErrorSistema, objParFactura.mensajesErrorUsuario),
                                                                   rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        objParFactura.aceptarTransaccion()
                        MessageBox.Show(rcRecursos.msOK, rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Call limpiar()
                    End If
                End If
            End If
            objParFactura.finalizar()
        End Using
    End Sub

    Private Sub actualizar()
        Using objFechaFact As New Negocios.FechaFacturasBL(usuario, clave)
            If validar() Then
                Dim vEstado As Integer
                If ckEstado.Checked = True Then
                    vEstado = 0
                Else
                    vEstado = 1
                End If
                Dim item As New tb_FechasFactura With {.gestion = txtGestion.Text, .mes = txtMes.Text,
                                                 .estado = vEstado}
                objFechaFact.validarDatosTransaccion()
                If (objFechaFact.datosValidosParametros) Then
                    Call objFechaFact.limpiarErrorBase()
                    Call objFechaFact.abrirTransaccion()
                    Call objFechaFact.updateBL(item)
                    If objFechaFact.existeError Then
                        Call objFechaFact.rechazarTransaccion()
                        MessageBox.Show(String.Format("{0} {1}", objFechaFact.mensajesErrorSistema, objFechaFact.mensajesErrorUsuario),
                                                                   rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        objFechaFact.aceptarTransaccion()
                        MessageBox.Show(rcRecursos.msOK, rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Call limpiar()
                    End If
                End If
            End If
            objFechaFact.finalizar()
        End Using
    End Sub

    Private Sub inicio()
        If lista.Count > 0 Then
            Using objFechaFact As New Negocios.FechaFacturasBL(usuario, clave)
                Dim dt As New DataTable
                Dim item(0) As tb_FechasFactura
                item.SetValue(lista.ElementAt(0), 0)

                Dim itemTabla As New tb_FechasFactura
                itemTabla = item.GetValue(0)
                dt = objFechaFact.getGestionYMesBL(itemTabla)

                If objFechaFact.existeError Then
                    MessageBox.Show(String.Format("{0} {1}", objFechaFact.mensajesErrorSistema, objFechaFact.mensajesErrorUsuario),
                                                      rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf dt.Rows.Count > 0 Then
                    txtGestion.Text = dt.Rows(0).Item("gestion") 'select gestion, mes, estado 
                    txtMes.Text = dt.Rows(0).Item("mes")
                    Dim vEstado As Integer = If(IsDBNull(dt.Rows(0).Item("estado")), Nothing, dt.Rows(0).Item("estado"))
                    If vEstado = 0 Then
                        ckEstado.Checked = True
                    Else
                        ckEstado.Checked = Not True
                    End If

                    index = 0
                End If
                objFechaFact.finalizar()
            End Using
        End If
    End Sub

    Private Sub siguente()
        If lista.Count - 1 > 0 Then
            If index <> lista.Count - 1 Then
                Using objFechaFact As New Negocios.FechaFacturasBL(usuario, clave)
                    Dim dt As New DataTable
                    Dim item(0) As tb_FechasFactura
                    item.SetValue(lista.ElementAt(index + 1), 0)
                    Dim itemTabla As New tb_FechasFactura
                    itemTabla = item.GetValue(0)
                    dt = objFechaFact.getGestionYMesBL(itemTabla)

                    If objFechaFact.existeError Then
                        MessageBox.Show(String.Format("{0} {1}", objFechaFact.mensajesErrorSistema, objFechaFact.mensajesErrorUsuario),
                                                       rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ElseIf dt.Rows.Count > 0 Then
                        txtGestion.Text = If(IsDBNull(dt.Rows(0).Item("gestion")), Nothing, dt.Rows(0).Item("gestion")) 'select gestion, mes, estado 
                        txtMes.Text = If(IsDBNull(dt.Rows(0).Item("mes")), Nothing, dt.Rows(0).Item("mes")) '
                        Dim vEstado As Integer = If(IsDBNull(dt.Rows(0).Item("estado")), Nothing, dt.Rows(0).Item("estado"))
                        If vEstado = 0 Then
                            ckEstado.Checked = True
                        Else
                            ckEstado.Checked = Not True
                        End If

                        If index <> lista.Count - 1 Then
                            index = index + 1
                        End If
                    End If
                End Using
            End If
        End If
    End Sub

    Private Sub anteriror()
        If lista.Count - 1 > 0 Then
            If index <> 0 Then
                Using objFechaFact As New Negocios.FechaFacturasBL(usuario, clave)
                    Dim dt As New DataTable
                    Dim item(0) As tb_FechasFactura
                    item.SetValue(lista.ElementAt(index - 1), 0)
                    Dim itemTabla As New tb_FechasFactura
                    itemTabla = item.GetValue(0)
                    dt = objFechaFact.getGestionYMesBL(itemTabla)
                    If objFechaFact.existeError Then
                        MessageBox.Show(String.Format("{0} {1}", objFechaFact.mensajesErrorSistema, objFechaFact.mensajesErrorUsuario),
                                           rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ElseIf dt.Rows.Count > 0 Then
                        txtGestion.Text = If(IsDBNull(dt.Rows(0).Item("gestion")), Nothing, dt.Rows(0).Item("gestion")) 'select gestion, mes, estado 
                        txtMes.Text = If(IsDBNull(dt.Rows(0).Item("mes")), Nothing, dt.Rows(0).Item("mes")) '
                        Dim vEstado As Integer = If(IsDBNull(dt.Rows(0).Item("estado")), Nothing, dt.Rows(0).Item("estado"))
                        If vEstado = 0 Then
                            ckEstado.Checked = True
                        Else
                            ckEstado.Checked = Not True
                        End If

                        If index = 0 Then
                            index = 0
                        Else
                            index = index - 1
                        End If
                    End If
                End Using
            End If
        End If
    End Sub

    Private Sub final()
        If lista.Count > 0 Then
            Using objFechaFact As New Negocios.FechaFacturasBL(usuario, clave)
                Dim dt As New DataTable
                Dim item(0) As tb_FechasFactura
                item.SetValue(lista.Last, 0)
                Dim itemTabla As New tb_FechasFactura
                itemTabla = item.GetValue(0)
                dt = objFechaFact.getGestionYMesBL(itemTabla)
                If objFechaFact.existeError Then
                    MessageBox.Show(String.Format("{0} {1}", objFechaFact.mensajesErrorSistema, objFechaFact.mensajesErrorUsuario),
                                    rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf dt.Rows.Count > 0 Then
                    txtGestion.Text = If(IsDBNull(dt.Rows(0).Item("gestion")), Nothing, dt.Rows(0).Item("gestion")) 'select gestion, mes, estado 
                    txtMes.Text = If(IsDBNull(dt.Rows(0).Item("mes")), Nothing, dt.Rows(0).Item("mes")) '
                    Dim vEstado As Integer = If(IsDBNull(dt.Rows(0).Item("estado")), Nothing, dt.Rows(0).Item("estado"))
                    If vEstado = 0 Then
                        ckEstado.Checked = True
                    Else
                        ckEstado.Checked = Not True
                    End If

                    index = lista.Count - 1
                End If
            End Using
        End If
    End Sub

#End Region

#Region "[eventos]"

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Call alta()
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        Call actualizar()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Call baja()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Call Close()
    End Sub

#End Region

End Class