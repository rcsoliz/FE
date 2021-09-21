Imports Entidades
Imports Negocios
Imports DevExpress.XtraEditors
Imports WindApp.My.Resources

Public Class UI_CarteraCliente : Inherits f_base

#Region "[atributosGlobales]"

    Private usuario As String
    Private clave As String
    Private opcion As Integer
    Private lista As List(Of Entidades.tb_clienteNegocio)
    Private index As Integer

#End Region

#Region "[constructor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String, ByVal opc As Integer)
        MyBase.New(usuar, clav, "FORMULARIO DATOS COMPLEMENTARIOS", "Realice la operación requerida...")
        InitializeComponent()
        usuario = usuar
        clave = clav
        opcion = opc
        Call getOpcion()
    End Sub

    Public Sub New(ByVal usuar As String, ByVal clav As String, ByVal opc As Integer, ByVal codin As String, ByVal nom As String)
        MyBase.New(usuar, clav, "FORMULARIO DATOS COMPLEMENTARIOS", "Realice la operación requerida...")
        InitializeComponent()
        usuario = usuar
        clave = clav
        opcion = opc
        txtCodigoIN.Text = codin : txtNombre.Text = nom
        Call getOpcion()
    End Sub

    Public Sub New(ByVal usuar As String, ByVal clav As String, ByVal list As List(Of tb_clienteNegocio), ByVal opc As Integer)
        MyBase.New("DATOS COMPLEMENTARIOS CLIENTES ", "Realice la operación requerida...")
        InitializeComponent()
        usuario = usuar
        clave = clav

        opcion = opc
        lista = list
        Call getOpcion()
       
        Call inicio()
    End Sub

#End Region

#Region "[metodos]"

    Private Sub getOpcion()
        If opcion = 1 Then
            btnAgregar.Enabled = True
            btnModificar.Enabled = False
            btnEliminar.Enabled = False
            txtCodigoIN.ReadOnly = Not False

        ElseIf opcion = 2 Then
            btnAgregar.Enabled = False
            btnModificar.Enabled = True
            btnEliminar.Enabled = False
            txtCodigoIN.ReadOnly = Not False
            txtNombre.Enabled = False
            txtNitCI.Enabled = False

        ElseIf opcion = 3 Then
            btnAgregar.Enabled = False
            btnModificar.Enabled = False
            btnEliminar.Enabled = True

            txtCodigoIN.ReadOnly = Not False
            txtCodigoSis.ReadOnly = Not False
            txtNombre.ReadOnly = Not False
            txtTelefono.ReadOnly = Not False
            txtCelular.Enabled = Not False
            txtDireccion.Enabled = Not False
            txtNombre.ReadOnly = Not False
            txtNitCI.ReadOnly = Not False

        ElseIf opcion = 999 Then
            btnAgregar.Enabled = True
            btnModificar.Enabled = False
            btnEliminar.Enabled = False
            'txtCodigoIN.ReadOnly = Not False

        Else
            btnAgregar.Enabled = False
            btnModificar.Enabled = False
            btnEliminar.Enabled = False
        End If
    End Sub

    Private Sub getUnidad()
        Dim objConexion As New Negocios.UtilitarioBL(usuario, clave)
        Dim dtConexion As New DataTable
        dtConexion = objConexion.getDatosConexion("88002", "1")
        'abrimos database dbmystic
        Using objUtilitario As New Negocios.UtilitarioBL(dtConexion)
            Dim dt As New DataTable
            dt = objUtilitario.getNegocioBL()
            If objUtilitario.existeError Then
                XtraMessageBox.Show(String.Format("{0} {1}", objUtilitario.mensajesErrorSistema, objUtilitario.mensajesErrorUsuario),
                                                           rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                lkNegocio.Properties.DataSource = dt
                lkNegocio.Properties.ValueMember = "coduneg"
                lkNegocio.Properties.DisplayMember = "unidad"
                lkNegocio.EditValue = dt.Rows(0).Item("coduneg")
            End If
            objUtilitario.finalizar()
        End Using
        'End If
    End Sub

    Private Sub getTipoCliente()
        Using objUtilitario As New Negocios.UtilitarioBL(usuario, clave)
            Dim dt As New DataTable
            dt = objUtilitario.getTipoClienteBL()
            If objUtilitario.existeError Then
                DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objUtilitario.mensajesErrorSistema, objUtilitario.mensajesErrorUsuario),
                                                           rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                lkTipoCliente.Properties.DataSource = dt
                lkTipoCliente.Properties.ValueMember = "codigo"
                lkTipoCliente.Properties.DisplayMember = "descripcion"
                lkTipoCliente.EditValue = dt.Rows(0).Item("codigo")
            End If
            objUtilitario.finalizar()
        End Using
    End Sub

    Private Sub limpiar()
        'txtCodigoIN.Text = String.Empty
        txtCodigoSis.Text = String.Empty
        'txtNombre.Text = String.Empty
        txtTelefono.Text = String.Empty
        txtCelular.Text = String.Empty
        txtDireccion.Text = String.Empty
        txtEmail.Text = String.Empty
    End Sub

    Private Function validarAlta() As Boolean
        Dim Result As Decimal = 0
        Dim resEntero As Integer = 0
        dxErrorProvider.ClearErrors()
        If Not Decimal.TryParse(txtCodigoIN.Text, Result) Then
            dxErrorProvider.SetError(txtCodigoIN, "El código de Imp. Nacional es requerido")
            txtCodigoIN.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtNombre.Text) Then
            dxErrorProvider.SetError(txtNombre, "El campo nombre es requerido")
            txtNombre.Focus()
            Return False

        ElseIf Not Decimal.TryParse(txtCodigoSis.Text, Result) Then
            dxErrorProvider.SetError(txtCodigoSis, "El código del Sistema es requerido")
            txtCodigoSis.Focus()
            Return False

        ElseIf Not Integer.TryParse(lkNegocio.EditValue, resEntero) Then
            dxErrorProvider.SetError(lkNegocio, "El campo Unidad es requerido")
            lkNegocio.Focus()
            Return False

        ElseIf Not Integer.TryParse(lkTipoCliente.EditValue, resEntero) Then
            dxErrorProvider.SetError(lkTipoCliente, "El campo Tipo de Cliente es requerido")
            lkTipoCliente.Focus()
            Return False

        End If
        Return True
    End Function

    Private Sub alta()
        Using objCliente As New Negocios.ClienteNegocioBL(usuario, clave)
            If validarAlta() Then
                Dim vActivo As String = String.Empty
                If RadioGroup1.Properties.Items(RadioGroup1.SelectedIndex).Description = "Activos" Then
                    vActivo = "a"
                Else
                    vActivo = "i"
                End If
                Dim item As New tb_clienteNegocio With {.codigoin = txtCodigoIN.Text, .codigosistema = txtCodigoSis.Text,
                                                        .codUnidad = lkNegocio.EditValue, .tipocliente = lkTipoCliente.EditValue,
                                                        .telefono = txtTelefono.Text, .celular = txtCelular.Text,
                                                        .direccion = txtDireccion.Text, .email = txtDireccion.Text,
                                                        .fregistro = Date.Now.ToShortDateString, .estado = vActivo}
                objCliente.validarDatosTransaccion()
                If (objCliente.datosValidosParametros) Then
                    Call objCliente.limpiarErrorBase()
                    Call objCliente.abrirTransaccion()
                    Call objCliente.altaBL(item)
                    If objCliente.existeError Then
                        Call objCliente.rechazarTransaccion()
                        DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objCliente.mensajesErrorSistema, objCliente.mensajeErrorUsuarios),
                                                                   rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        objCliente.aceptarTransaccion()
                        DevExpress.XtraEditors.XtraMessageBox.Show(rcRecursos.msOK, rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Call limpiar()
                    End If
                End If
            End If
            objCliente.finalizar()
        End Using
    End Sub

    Private Sub baja()
        Using objCliente As New Negocios.ClienteNegocioBL(usuario, clave)
            If validarAlta() Then
                If XtraMessageBox.Show(rcRecursos.msEliminar, rcRecursos.msTitulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MessageBoxButtons.OK Then

                    Dim vActivo As String = String.Empty
                    vActivo = "i"
                    Dim item As New tb_clienteNegocio With {.codigoin = txtCodigoIN.Text, .codigosistema = txtCodigoSis.Text,
                                                            .codunidad = lkNegocio.EditValue, .tipocliente = lkTipoCliente.EditValue,
                                                            .telefono = txtTelefono.Text, .celular = txtCelular.Text,
                                                            .direccion = txtDireccion.Text, .email = txtDireccion.Text,
                                                            .fregistro = Date.Now.ToShortDateString, .estado = vActivo}
                    objCliente.validarDatosTransaccion()
                    If objCliente.datosValidosParametros Then
                        Call objCliente.limpiarErrorBase()
                        Call objCliente.abrirTransaccion()
                        Call objCliente.bajalogicaBL(item)
                        If objCliente.existeError Then
                            Call objCliente.rechazarTransaccion()
                            DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objCliente.mensajesErrorSistema, objCliente.mensajeErrorUsuarios),
                                                                       rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Else
                            objCliente.aceptarTransaccion()
                            DevExpress.XtraEditors.XtraMessageBox.Show(rcRecursos.msOK, rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Call limpiar()
                        End If
                    End If
                End If
            End If
            objCliente.finalizar()
        End Using
    End Sub

    Private Sub modificar()
        Using objCliente As New Negocios.ClienteNegocioBL(usuario, clave)
            If validarAlta() Then
                Dim vActivo As String = String.Empty
                If RadioGroup1.Properties.Items(RadioGroup1.SelectedIndex).Description = "Activos" Then
                    vActivo = "a"
                Else
                    vActivo = "i"
                End If

                Dim item As New tb_clienteNegocio With {.codigoin = txtCodigoIN.Text, .codigosistema = txtCodigoSis.Text,
                                                            .codUnidad = lkNegocio.EditValue, .tipocliente = lkTipoCliente.EditValue,
                                                            .telefono = txtTelefono.Text, .celular = txtCelular.Text,
                                                            .direccion = txtDireccion.Text, .email = txtDireccion.Text,
                                                            .fregistro = Date.Now.ToShortDateString, .estado = vActivo}
                objCliente.validarDatosTransaccion()
                If (objCliente.datosValidosParametros) Then
                    Call objCliente.limpiarErrorBase()
                    Call objCliente.abrirTransaccion()
                    Call objCliente.actualizarBL(item)
                    If objCliente.existeError Then
                        Call objCliente.rechazarTransaccion()
                        DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objCliente.mensajesErrorSistema, objCliente.mensajeErrorUsuarios),
                                                                   rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        objCliente.aceptarTransaccion()
                        DevExpress.XtraEditors.XtraMessageBox.Show(rcRecursos.msOK, rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Call limpiar()
                    End If
                End If
            End If
            objCliente.finalizar()
        End Using
    End Sub

    Private Sub inicio()
        If lista.Count > 0 Then
            Using objCliente As New Negocios.ClienteNegocioBL(usuario, clave)
                Dim dt As New DataTable
                Dim item(2) As tb_clienteNegocio
                item.SetValue(lista.ElementAt(0), 0)

                Dim itemTabla As New tb_clienteNegocio
                itemTabla = item.GetValue(0)
                dt = objCliente.getClienteNegocioBL(itemTabla)

                If objCliente.existeError Then
                    DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objCliente.mensajesErrorSistema, objCliente.mensajeErrorUsuarios),
                                                                  rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf dt.Rows.Count > 0 Then
                    txtCodigoIN.Text = If(IsDBNull(dt.Rows(0).Item("codigoin")), Nothing, dt.Rows(0).Item("codigoin"))
                    txtCodigoSis.Text = If(IsDBNull(dt.Rows(0).Item("codigosistema")), Nothing, dt.Rows(0).Item("codigosistema"))
                    lkNegocio.EditValue = If(IsDBNull(dt.Rows(0).Item("codunidad")), Nothing, dt.Rows(0).Item("codunidad"))
                    lkTipoCliente.EditValue = If(IsDBNull(dt.Rows(0).Item("tipocliente")), Nothing, dt.Rows(0).Item("tipocliente"))
                    txtTelefono.Text = If(IsDBNull(dt.Rows(0).Item("telefono")), Nothing, dt.Rows(0).Item("telefono"))
                    txtCelular.Text = If(IsDBNull(dt.Rows(0).Item("celular")), Nothing, dt.Rows(0).Item("celular"))
                    txtDireccion.Text = If(IsDBNull(dt.Rows(0).Item("direccion")), Nothing, dt.Rows(0).Item("direccion"))
                    txtEmail.Text = If(IsDBNull(dt.Rows(0).Item("email")), Nothing, dt.Rows(0).Item("email"))
                    If dt.Rows(0).Item("estado") = "a" Then
                        '  RadioGroup1.Properties.Items(RadioGroup1.SelectedIndex).Value = True
                    Else
                        RadioGroup1.Properties.Items(RadioGroup1.SelectedIndex).Value = Not True ' "Inactivos"
                    End If

                    Dim dtCliente As New DataTable
                    dtCliente = objCliente.getClienteBL(itemTabla)
                    If objCliente.existeError Then
                        DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objCliente.mensajesErrorSistema, objCliente.mensajeErrorUsuarios),
                                                                      rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        If dtCliente.Rows.Count > 0 Then
                            txtNombre.Text = If(IsDBNull(dtCliente.Rows(0).Item("nombre")), Nothing, dtCliente.Rows(0).Item("nombre"))
                            txtNitCI.Text = If(IsDBNull(dtCliente.Rows(0).Item("nitci")), Nothing, dtCliente.Rows(0).Item("nitci"))
                        End If
                    End If


                    index = 0

                End If
                objCliente.finalizar()
            End Using
        End If
    End Sub

    Private Sub siguente()
        If lista.Count - 1 > 0 Then
            If index <> lista.Count - 1 Then
                Using objCliente As New Negocios.ClienteNegocioBL(usuario, clave)
                    Dim dt As New DataTable
                    Dim item(0) As tb_clienteNegocio
                    item.SetValue(lista.ElementAt(index + 1), 0)
                    Dim itemTabla As New tb_clienteNegocio
                    itemTabla = item.GetValue(0)
                    dt = objCliente.getClienteNegocioBL(itemTabla)

                    If objCliente.existeError Then
                        DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objCliente.mensajesErrorSistema, objCliente.mensajeErrorUsuarios),
                                                                      rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ElseIf dt.Rows.Count > 0 Then
                        txtCodigoIN.Text = If(IsDBNull(dt.Rows(0).Item("codigoin")), Nothing, dt.Rows(0).Item("codigoin"))
                        txtCodigoSis.Text = If(IsDBNull(dt.Rows(0).Item("codigosistema")), Nothing, dt.Rows(0).Item("codigosistema"))
                        lkNegocio.EditValue = If(IsDBNull(dt.Rows(0).Item("codunidad")), Nothing, dt.Rows(0).Item("codunidad"))
                        lkTipoCliente.EditValue = If(IsDBNull(dt.Rows(0).Item("tipocliente")), Nothing, dt.Rows(0).Item("tipocliente"))
                        txtTelefono.Text = If(IsDBNull(dt.Rows(0).Item("telefono")), Nothing, dt.Rows(0).Item("telefono"))
                        txtCelular.Text = If(IsDBNull(dt.Rows(0).Item("celular")), Nothing, dt.Rows(0).Item("celular"))
                        txtDireccion.Text = If(IsDBNull(dt.Rows(0).Item("direccion")), Nothing, dt.Rows(0).Item("direccion"))
                        txtEmail.Text = If(IsDBNull(dt.Rows(0).Item("email")), Nothing, dt.Rows(0).Item("email"))
                        If dt.Rows(0).Item("estado") = "a" Then
                            '  RadioGroup1.Properties.Items(RadioGroup1.SelectedIndex).Value = True
                        Else
                            RadioGroup1.Properties.Items(RadioGroup1.SelectedIndex).Value = Not True ' "Inactivos"
                        End If

                        Dim dtCliente As New DataTable
                        dtCliente = objCliente.getClienteBL(itemTabla)
                        If objCliente.existeError Then
                            DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objCliente.mensajesErrorSistema, objCliente.mensajeErrorUsuarios),
                                                                          rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Else
                            If dtCliente.Rows.Count > 0 Then
                                txtNombre.Text = If(IsDBNull(dtCliente.Rows(0).Item("nombre")), Nothing, dtCliente.Rows(0).Item("nombre"))
                                txtNitCI.Text = If(IsDBNull(dtCliente.Rows(0).Item("nitci")), Nothing, dtCliente.Rows(0).Item("nitci"))
                            End If
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
                Using objCliente As New Negocios.ClienteNegocioBL(usuario, clave)
                    Dim dt As New DataTable
                    Dim item(0) As tb_clienteNegocio
                    item.SetValue(lista.ElementAt(index - 1), 0)
                    Dim itemTabla As New tb_clienteNegocio
                    itemTabla = item.GetValue(0)
                    dt = objCliente.getClienteNegocioBL(itemTabla)
                    If objCliente.existeError Then
                        DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objCliente.mensajesErrorSistema, objCliente.mensajeErrorUsuarios),
                                                                      rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ElseIf dt.Rows.Count > 0 Then
                        txtCodigoIN.Text = If(IsDBNull(dt.Rows(0).Item("codigoin")), Nothing, dt.Rows(0).Item("codigoin"))
                        txtCodigoSis.Text = If(IsDBNull(dt.Rows(0).Item("codigosistema")), Nothing, dt.Rows(0).Item("codigosistema"))
                        lkNegocio.EditValue = If(IsDBNull(dt.Rows(0).Item("codunidad")), Nothing, dt.Rows(0).Item("codunidad"))
                        lkTipoCliente.EditValue = If(IsDBNull(dt.Rows(0).Item("tipocliente")), Nothing, dt.Rows(0).Item("tipocliente"))
                        txtTelefono.Text = If(IsDBNull(dt.Rows(0).Item("telefono")), Nothing, dt.Rows(0).Item("telefono"))
                        txtCelular.Text = If(IsDBNull(dt.Rows(0).Item("celular")), Nothing, dt.Rows(0).Item("celular"))
                        txtDireccion.Text = If(IsDBNull(dt.Rows(0).Item("direccion")), Nothing, dt.Rows(0).Item("direccion"))
                        txtEmail.Text = If(IsDBNull(dt.Rows(0).Item("email")), Nothing, dt.Rows(0).Item("email"))
                        If dt.Rows(0).Item("estado") = "a" Then
                            '  RadioGroup1.Properties.Items(RadioGroup1.SelectedIndex).Value = True
                        Else
                            RadioGroup1.Properties.Items(RadioGroup1.SelectedIndex).Value = Not True ' "Inactivos"
                        End If

                        Dim dtCliente As New DataTable
                        dtCliente = objCliente.getClienteBL(itemTabla)
                        If objCliente.existeError Then
                            DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objCliente.mensajesErrorSistema, objCliente.mensajeErrorUsuarios),
                                                                          rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Else
                            If dtCliente.Rows.Count > 0 Then
                                txtNombre.Text = If(IsDBNull(dtCliente.Rows(0).Item("nombre")), Nothing, dtCliente.Rows(0).Item("nombre"))
                                txtNitCI.Text = If(IsDBNull(dtCliente.Rows(0).Item("nitci")), Nothing, dtCliente.Rows(0).Item("nitci"))
                            End If
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
            Using objCliente As New Negocios.ClienteNegocioBL(usuario, clave)
                Dim dt As New DataTable
                Dim item(0) As tb_clienteNegocio
                item.SetValue(lista.Last, 0)
                Dim itemTabla As New tb_clienteNegocio
                itemTabla = item.GetValue(0)
                dt = objCliente.getClienteNegocioBL(itemTabla)
                If objCliente.existeError Then
                    DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objCliente.mensajesErrorSistema, objCliente.mensajeErrorUsuarios),
                                                                  rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf dt.Rows.Count > 0 Then
                    txtCodigoIN.Text = If(IsDBNull(dt.Rows(0).Item("codigoin")), Nothing, dt.Rows(0).Item("codigoin"))
                    txtCodigoSis.Text = If(IsDBNull(dt.Rows(0).Item("codigosistema")), Nothing, dt.Rows(0).Item("codigosistema"))
                    lkNegocio.EditValue = If(IsDBNull(dt.Rows(0).Item("codunidad")), Nothing, dt.Rows(0).Item("codunidad"))
                    lkTipoCliente.EditValue = If(IsDBNull(dt.Rows(0).Item("tipocliente")), Nothing, dt.Rows(0).Item("tipocliente"))
                    txtTelefono.Text = If(IsDBNull(dt.Rows(0).Item("telefono")), Nothing, dt.Rows(0).Item("telefono"))
                    txtCelular.Text = If(IsDBNull(dt.Rows(0).Item("celular")), Nothing, dt.Rows(0).Item("celular"))
                    txtDireccion.Text = If(IsDBNull(dt.Rows(0).Item("direccion")), Nothing, dt.Rows(0).Item("direccion"))
                    txtEmail.Text = If(IsDBNull(dt.Rows(0).Item("email")), Nothing, dt.Rows(0).Item("email"))
                    If dt.Rows(0).Item("estado") = "a" Then
                        '  RadioGroup1.Properties.Items(RadioGroup1.SelectedIndex).Value = True
                    Else
                        RadioGroup1.Properties.Items(RadioGroup1.SelectedIndex).Value = Not True ' "Inactivos"
                    End If

                    Dim dtCliente As New DataTable
                    dtCliente = objCliente.getClienteBL(itemTabla)
                    If objCliente.existeError Then
                        DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objCliente.mensajesErrorSistema, objCliente.mensajeErrorUsuarios),
                                                                      rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        If dtCliente.Rows.Count > 0 Then
                            txtNombre.Text = If(IsDBNull(dtCliente.Rows(0).Item("nombre")), Nothing, dtCliente.Rows(0).Item("nombre"))
                            txtNitCI.Text = If(IsDBNull(dtCliente.Rows(0).Item("nitci")), Nothing, dtCliente.Rows(0).Item("nitci"))
                        End If
                    End If

                    index = lista.Count - 1

                End If
            End Using
        End If
    End Sub

#End Region

#Region "[eventos]"

    Private Sub UI_ClienteNegocio_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call getUnidad()
        Call getTipoCliente()
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
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

    Private Sub btnIrClientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIrClientes.Click
        If Not String.IsNullOrEmpty(usuario) AndAlso Not String.IsNullOrEmpty(usuario) Then
            Using objFormModulo As New UI_AuxClientes(usuario, clave)
                objFormModulo.ShowDialog()
                If Not String.IsNullOrEmpty(objFormModulo.codigo) Then
                    txtCodigoSis.Text = objFormModulo.codigo
                    txtTelefono.Text = objFormModulo.telefono
                    txtDireccion.Text = objFormModulo.direccion
                End If
                Call objFormModulo.Close()
            End Using
        End If
    End Sub

#End Region

End Class