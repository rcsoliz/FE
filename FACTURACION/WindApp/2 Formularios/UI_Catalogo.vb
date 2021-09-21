Imports Entidades
Imports Negocios
Public Class UI_Catalogo : Inherits f_base

#Region "[atributosGlobales]"

    Private usuario As String
    Private clave As String
    Private lista As List(Of tb_CatalogoFe)
    Private opcion As Integer
    Private index As Integer

#End Region

#Region "[constructor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String, ByVal opc As Integer)
        MyBase.New(usuar, clav, "CATALOGO S.I.N.", "Realice la operación requerida...")
        InitializeComponent()
        usuario = usuar
        clave = clav
    End Sub


    Public Sub New(ByVal usuar As String, ByVal clav As String, ByVal list As List(Of tb_CatalogoFe), ByVal opc As Integer)
        MyBase.New(usuar, clav, "CATALOGO S.I.N.", "Realice la operación requerida...")
        InitializeComponent()
        lista = list
        usuario = usuar
        clave = clav
        opcion = opc
        Call getOpcion()
        If opcion = 1 Then
            'Call getCorrelativo()
        End If
        Call inicio()
    End Sub

#End Region

#Region "[metodos]"

    Private Sub getOpcion()
        If opcion = 1 Then
            btnGrabar.Enabled = True
            btnModificar.Enabled = False
            btnEliminar.Enabled = False

        ElseIf opcion = 2 Then
            btnGrabar.Enabled = False
            btnModificar.Enabled = True
            btnEliminar.Enabled = False


        ElseIf opcion = 3 Then
            btnGrabar.Enabled = False
            btnModificar.Enabled = False
            btnEliminar.Enabled = True

            txtTipo.ReadOnly = Not False
            txtCodigo.ReadOnly = Not False
            txtNombre.ReadOnly = Not False
        Else
            btnGrabar.Enabled = False
            btnModificar.Enabled = False
            btnEliminar.Enabled = False
        End If
    End Sub

    Private Sub limpiar()
        txtTipo.Text = String.Empty
        txtCodigo.Text = String.Empty
        txtNombre.Text = String.Empty
    End Sub

    Private Function validarAlta() As Boolean
        Dim Result As Integer = 0
        dxErrorProvider.ClearErrors()
        If Not Integer.TryParse(txtCodigo.Text, Result) Then
            dxErrorProvider.SetError(txtCodigo, "El Código es requerido")
            txtCodigo.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtTipo.Text) Then
            dxErrorProvider.SetError(txtTipo, "El campo Tipo es requerido")
            txtTipo.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtNombre.Text) Then
            dxErrorProvider.SetError(txtNombre, "El camopo Nombre es requerido")
            txtNombre.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub alta()
        Using objCatalogo As New Negocios.CatalogoBL(usuario, clave)
            If validarAlta() Then
                Dim item As New tb_CatalogoFe With {.codigo = txtCodigo.Text, .tipo = txtTipo.Text,
                                                  .nombre = txtNombre.Text}
                objCatalogo.validarDatosTransaccion()
                If (objCatalogo.datosValidosParametros) Then
                    Call objCatalogo.limpiarErrorBase()
                    Call objCatalogo.abrirTransaccion()
                    Call objCatalogo.altaBL(item)
                    If objCatalogo.existeError Then
                        Call objCatalogo.rechazarTransaccion()
                        DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objCatalogo.mensajesErrorSistema, objCatalogo.mensajesErrorUsuario),
                                                                   "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        objCatalogo.aceptarTransaccion()
                        DevExpress.XtraEditors.XtraMessageBox.Show("Transacción realizada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Call limpiar()
                    End If
                End If
            End If
            objCatalogo.finalizar()
        End Using
    End Sub

    Private Sub baja()
        Using objCatalogo As New Negocios.CatalogoBL(usuario, clave)
            If validarAlta() Then
                Dim item As New tb_CatalogoFe With {.codigo = txtCodigo.Text, .tipo = txtTipo.Text,
                                                  .nombre = txtNombre.Text}
                objCatalogo.validarDatosTransaccion()
                If (objCatalogo.datosValidosParametros) Then
                    Call objCatalogo.limpiarErrorBase()
                    Call objCatalogo.abrirTransaccion()
                    Call objCatalogo.bajaBL(item)
                    If objCatalogo.existeError Then
                        Call objCatalogo.rechazarTransaccion()
                        DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objCatalogo.mensajesErrorSistema, objCatalogo.mensajesErrorUsuario),
                                                                   "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        objCatalogo.aceptarTransaccion()
                        DevExpress.XtraEditors.XtraMessageBox.Show("Catalogo eliminado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Call limpiar()
                    End If
                End If
            End If
            objCatalogo.finalizar()
        End Using
    End Sub

    Private Sub modificar()
        Using objCatalogo As New Negocios.CatalogoBL(usuario, clave)
            If validarAlta() Then
                Dim item As New tb_CatalogoFe With {.codigo = txtCodigo.Text, .tipo = txtTipo.Text,
                                                      .nombre = txtNombre.Text}
                objCatalogo.validarDatosTransaccion()
                If (objCatalogo.datosValidosParametros) Then
                    Call objCatalogo.limpiarErrorBase()
                    Call objCatalogo.abrirTransaccion()
                    Call objCatalogo.actualizarBL(item)
                    If objCatalogo.existeError Then
                        Call objCatalogo.rechazarTransaccion()
                        DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objCatalogo.mensajesErrorSistema, objCatalogo.mensajesErrorUsuario), "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        objCatalogo.aceptarTransaccion()
                        DevExpress.XtraEditors.XtraMessageBox.Show("Catalogo actualizado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Call limpiar()
                    End If
                End If
            End If
            objCatalogo.finalizar()
        End Using
    End Sub

    Private Sub inicio()
        If lista.Count > 0 Then
            Using objCatalogo As New Negocios.CatalogoBL(usuario, clave)
                Dim dt As New DataTable
                Dim item(0) As tb_CatalogoFe
                item.SetValue(lista.ElementAt(0), 0)

                Dim itemTabla As New tb_CatalogoFe
                itemTabla = item.GetValue(0)
                dt = objCatalogo.getCatalogoBL(itemTabla)

                If objCatalogo.existeError Then 'trim(tipo) tipo, codigo, trim(nombre) nombre
                    DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objCatalogo.mensajesErrorSistema, objCatalogo.mensajesErrorUsuario),
                                                                  "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf dt.Rows.Count > 0 Then
                    txtTipo.Text = dt.Rows(0).Item("tipo")
                    txtCodigo.Text = dt.Rows(0).Item("codigo")
                    txtNombre.Text = dt.Rows(0).Item("nombre")
                    index = 0
                End If
                objCatalogo.finalizar()
            End Using
        End If
    End Sub

    Private Sub siguente()
        If lista.Count - 1 > 0 Then
            If index <> lista.Count - 1 Then
                Using objCatalogo As New Negocios.CatalogoBL(usuario, clave)
                    Dim dt As New DataTable
                    Dim item(0) As tb_CatalogoFe
                    item.SetValue(lista.ElementAt(index + 1), 0)

                    Dim itemTabla As New tb_CatalogoFe
                    itemTabla = item.GetValue(0)

                    dt = objCatalogo.getCatalogoBL(itemTabla)

                    If objCatalogo.existeError Then
                        DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objCatalogo.mensajesErrorSistema, objCatalogo.mensajesErrorUsuario),
                                                                      "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ElseIf dt.Rows.Count > 0 Then
                        txtTipo.Text = dt.Rows(0).Item("tipo")
                        txtCodigo.Text = dt.Rows(0).Item("codigo")
                        txtNombre.Text = dt.Rows(0).Item("nombre")

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
                Using objCatalogo As New Negocios.CatalogoBL(usuario, clave)
                    Dim dt As New DataTable
                    Dim item(0) As tb_CatalogoFe
                    item.SetValue(lista.ElementAt(index - 1), 0)

                    Dim itemTabla As New tb_CatalogoFe
                    itemTabla = item.GetValue(0)

                    dt = objCatalogo.getCatalogoBL(itemTabla)
                    If objCatalogo.existeError Then
                        DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objCatalogo.mensajesErrorSistema, objCatalogo.mensajesErrorUsuario),
                                                                      "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ElseIf dt.Rows.Count > 0 Then
                        txtTipo.Text = dt.Rows(0).Item("tipo")
                        txtCodigo.Text = dt.Rows(0).Item("codigo")
                        txtNombre.Text = dt.Rows(0).Item("nombre")

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
            Using objSModulo As New Negocios.CatalogoBL(usuario, clave)
                Dim dt As New DataTable
                Dim item(0) As tb_CatalogoFe
                item.SetValue(lista.Last, 0)

                Dim itemTabla As New tb_CatalogoFe
                itemTabla = item.GetValue(0)

                dt = objSModulo.getCatalogoBL(itemTabla)
                If objSModulo.existeError Then
                    DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objSModulo.mensajesErrorSistema, objSModulo.mensajesErrorUsuario),
                                                                  "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf dt.Rows.Count > 0 Then
                    txtTipo.Text = dt.Rows(0).Item("tipo")
                    txtCodigo.Text = dt.Rows(0).Item("codigo")
                    txtNombre.Text = dt.Rows(0).Item("nombre")

                    index = lista.Count - 1
                End If
            End Using
        End If
    End Sub

#End Region

#Region "[eventos]"

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Call alta()
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        Call modificar()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Call baja()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Call Close()
    End Sub

#End Region

End Class