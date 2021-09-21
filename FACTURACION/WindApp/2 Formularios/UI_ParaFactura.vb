Imports Entidades
Imports WindApp.My.Resources
Public Class UI_ParaFactura : Inherits f_base

#Region "[atributosGlobales]"

    Private usuario As String
    Private clave As String
    Private opcion As Integer
    Private lista As List(Of tb_ParFatura)
    Private index As Integer

#End Region

#Region "[contrutor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String, ByVal opc As Integer)
        MyBase.New(usuar, clav, "DATOS PARAMETROS MODULO-FACTURACION", "Realize la operacion necesaria...")
        InitializeComponent()
        usuario = usuar : clave = clav
        opcion = opc
        Call getOpcion()
        Call limpiar()
    End Sub

    Public Sub New(ByVal usuar As String, ByVal clav As String, ByVal list As List(Of tb_ParFatura), ByVal opc As Integer)
        MyBase.New(usuar, clav, "DATOS PARAMETROS MODULO-FACTURACION", "Realize la operacion necesaria...")
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
            txtcodparame.ReadOnly = Not False

        ElseIf opcion = 3 Then
            btnGuardar.Enabled = False
            btnModificar.Enabled = False
            btnEliminar.Enabled = True

            txtcodparame.ReadOnly = False
            txtdescripcion.ReadOnly = Not False
            txtValor1.ReadOnly = Not False
            txtValor2.ReadOnly = Not False
            txtValor3.Enabled = Not False
        Else
            btnGuardar.Enabled = False
            btnModificar.Enabled = False
            btnEliminar.Enabled = False
        End If
    End Sub

    Private Function validar() As Boolean
        Dim Result As Integer = 0
        dxErrorProvider.Clear()
        If String.IsNullOrEmpty(txtcodparame.Text) Then
            dxErrorProvider.SetError(txtcodparame, "El campo codigo es requerido")
            txtcodparame.Focus()
            Return False
        ElseIf Not Int32.TryParse(txtValor1.Text, Result) Then
            dxErrorProvider.SetError(txtValor1, "El campo valor 1 es requerido")
            txtValor1.Focus()
            Return False
        ElseIf Not Decimal.TryParse(txtValor2.Text, Result) Then
            dxErrorProvider.SetError(txtValor2, "El campo valor 2 no solo acepta valores numericos")
            txtValor2.Focus()
            Return False
        ElseIf Not Decimal.TryParse(txtValor3.Text, Result) Then
            dxErrorProvider.SetError(txtValor3, "El campo valor 3 no solo acepta valores numericos")
            txtValor3.Focus()
            Return False
        Else
            Return True
        End If
        Return True
    End Function

    Private Sub limpiar()
        txtcodparame.Text = String.Empty
        txtdescripcion.Text = String.Empty
        txtValor1.Text = String.Empty
        txtValor2.Text = String.Empty
        txtValor3.Text = String.Empty
    End Sub

    Private Sub alta()
        Using objParFactura As New Negocios.ParFacturaBL(usuario, clave)
            If validar() Then
                Dim item As New tb_ParFatura With {.codparame = txtcodparame.Text, .descripcion = txtdescripcion.Text,
                                                 .valor1 = txtValor1.Text, .valor2 = txtValor2.Text, .valor3 = txtValor3.Text}
                objParFactura.validarDatosTransaccion()
                If (objParFactura.datosValidosParametros) Then
                    Call objParFactura.limpiarErrorBase()
                    Call objParFactura.abrirTransaccion()
                    Call objParFactura.altaBL(item)
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

    Private Sub baja()
        Using objParFactura As New Negocios.ParFacturaBL(usuario, clave)
            If validar() Then
                Dim item As New tb_ParFatura With {.codparame = txtcodparame.Text}
                objParFactura.validarDatosTransaccion()
                If (objParFactura.datosValidosParametros) Then
                    Call objParFactura.limpiarErrorBase()
                    Call objParFactura.abrirTransaccion()
                    Call objParFactura.bajaBL(item)
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
        Using objParFactura As New Negocios.ParFacturaBL(usuario, clave)
            If validar() Then
                Dim item As New tb_ParFatura With {.codparame = txtcodparame.Text, .descripcion = txtdescripcion.Text,
                                          .valor1 = txtValor1.Text, .valor2 = txtValor2.Text, .valor3 = txtValor3.Text}
                objParFactura.validarDatosTransaccion()
                If (objParFactura.datosValidosParametros) Then
                    Call objParFactura.limpiarErrorBase()
                    Call objParFactura.abrirTransaccion()
                    Call objParFactura.actualizarBL(item)
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

    Private Sub inicio()
        If lista.Count > 0 Then
            Using objParFactura As New Negocios.ParFacturaBL(usuario, clave)
                Dim dt As New DataTable
                Dim item(0) As tb_ParFatura
                item.SetValue(lista.ElementAt(0), 0)

                Dim itemTabla As New tb_ParFatura
                itemTabla = item.GetValue(0)
                dt = objParFactura.getParametroBL(itemTabla)

                If objParFactura.existeError Then
                    MessageBox.Show(String.Format("{0} {1}", objParFactura.mensajesErrorSistema, objParFactura.mensajesErrorUsuario),
                                                      rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf dt.Rows.Count > 0 Then
                    txtcodparame.Text = dt.Rows(0).Item("codparame") 'codparame , trim(descripcion) descripcion, valor1, valor2, valor3
                    txtdescripcion.Text = dt.Rows(0).Item("descripcion")
                    txtValor1.Text = If(IsDBNull(dt.Rows(0).Item("valor1")), Nothing, dt.Rows(0).Item("valor1"))
                    txtValor2.Text = If(IsDBNull(dt.Rows(0).Item("valor2")), Nothing, dt.Rows(0).Item("valor2"))
                    txtValor3.Text = If(IsDBNull(dt.Rows(0).Item("valor3")), Nothing, dt.Rows(0).Item("valor3"))
                    index = 0
                End If
                objParFactura.finalizar()
            End Using
        End If
    End Sub

    Private Sub siguente()
        If lista.Count - 1 > 0 Then
            If index <> lista.Count - 1 Then
                Using objParFactura As New Negocios.ParFacturaBL(usuario, clave)
                    Dim dt As New DataTable
                    Dim item(0) As tb_ParFatura
                    item.SetValue(lista.ElementAt(index + 1), 0)
                    Dim itemTabla As New tb_ParFatura
                    itemTabla = item.GetValue(0)
                    dt = objParFactura.getParametroBL(itemTabla)

                    If objParFactura.existeError Then
                        MessageBox.Show(String.Format("{0} {1}", objParFactura.mensajesErrorSistema, objParFactura.mensajesErrorUsuario),
                                                       rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ElseIf dt.Rows.Count > 0 Then
                        txtcodparame.Text = dt.Rows(0).Item("codparame") 'codparame , trim(descripcion) descripcion, valor1, valor2, valor3
                        txtdescripcion.Text = dt.Rows(0).Item("descripcion")
                        txtValor1.Text = If(IsDBNull(dt.Rows(0).Item("valor1")), Nothing, dt.Rows(0).Item("valor1"))
                        txtValor2.Text = If(IsDBNull(dt.Rows(0).Item("valor2")), Nothing, dt.Rows(0).Item("valor2"))
                        txtValor3.Text = If(IsDBNull(dt.Rows(0).Item("valor3")), Nothing, dt.Rows(0).Item("valor3"))
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
                Using objParFactura As New Negocios.ParFacturaBL(usuario, clave)
                    Dim dt As New DataTable
                    Dim item(0) As tb_ParFatura
                    item.SetValue(lista.ElementAt(index - 1), 0)
                    Dim itemTabla As New tb_ParFatura
                    itemTabla = item.GetValue(0)
                    dt = objParFactura.getParametroBL(itemTabla)
                    If objParFactura.existeError Then
                        MessageBox.Show(String.Format("{0} {1}", objParFactura.mensajesErrorSistema, objParFactura.mensajesErrorUsuario),
                                           rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ElseIf dt.Rows.Count > 0 Then
                        txtcodparame.Text = dt.Rows(0).Item("codparame") 'codparame , trim(descripcion) descripcion, valor1, valor2, valor3
                        txtdescripcion.Text = dt.Rows(0).Item("descripcion")
                        txtValor1.Text = If(IsDBNull(dt.Rows(0).Item("valor1")), Nothing, dt.Rows(0).Item("valor1"))
                        txtValor2.Text = If(IsDBNull(dt.Rows(0).Item("valor2")), Nothing, dt.Rows(0).Item("valor2"))
                        txtValor3.Text = If(IsDBNull(dt.Rows(0).Item("valor3")), Nothing, dt.Rows(0).Item("valor3"))

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
            Using objParFactura As New Negocios.ParFacturaBL(usuario, clave)
                Dim dt As New DataTable
                Dim item(0) As tb_ParFatura
                item.SetValue(lista.Last, 0)
                Dim itemTabla As New tb_ParFatura
                itemTabla = item.GetValue(0)
                dt = objParFactura.getParametroBL(itemTabla)
                If objParFactura.existeError Then
                    MessageBox.Show(String.Format("{0} {1}", objParFactura.mensajesErrorSistema, objParFactura.mensajesErrorUsuario),
                                    rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf dt.Rows.Count > 0 Then
                    txtcodparame.Text = dt.Rows(0).Item("codparame") 'codparame , trim(descripcion) descripcion, valor1, valor2, valor3
                    txtdescripcion.Text = dt.Rows(0).Item("descripcion")
                    txtValor1.Text = If(IsDBNull(dt.Rows(0).Item("valor1")), Nothing, dt.Rows(0).Item("valor1"))
                    txtValor2.Text = If(IsDBNull(dt.Rows(0).Item("valor2")), Nothing, dt.Rows(0).Item("valor2"))
                    txtValor3.Text = If(IsDBNull(dt.Rows(0).Item("valor3")), Nothing, dt.Rows(0).Item("valor3"))

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