Imports Entidades
Imports DevExpress.XtraEditors
Imports WindApp.My.Resources
Public Class UI_Cliente : Inherits f_base

#Region "[atributosGlobales]"

    Private usuario As String
    Private clave As String
    Private opcion As Integer
    Private lista As List(Of tb_clienteIn)
    Private index As Integer

#End Region

#Region "[constructor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String, ByVal opc As Integer)
        MyBase.New("FORMULARIO CLIENTES ", "Realice la operación requerida...")
        InitializeComponent()
        usuario = usuar
        clave = clav
        opcion = opc
        Call getOpcion()
        If opcion = 1 Then
            Call getCorrelativo()
        End If
    End Sub

    Public Sub New(ByVal usuar As String, ByVal clav As String, ByVal list As List(Of tb_clienteIn), ByVal opc As Integer)
        MyBase.New("FORMULARIO CLIENTES ", "Realice la operación requerida...")
        InitializeComponent()
        lista = list
        usuario = usuar
        clave = clav
        opcion = opc
        Call getOpcion()
        If opcion = 1 Then
            Call getCorrelativo()
        End If
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

            btnComplemento.Enabled = False

        ElseIf opcion = 2 Then
            btnAgregar.Enabled = False
            btnModificar.Enabled = True
            btnEliminar.Enabled = False
            txtCodigoIN.ReadOnly = Not False

        ElseIf opcion = 3 Then
            btnAgregar.Enabled = False
            btnModificar.Enabled = False
            btnEliminar.Enabled = True

            txtCodigoIN.ReadOnly = Not False
            txtNombre.ReadOnly = Not False
            txtApellidos.ReadOnly = Not False
            txtCINit.Enabled = False
        Else
            btnAgregar.Enabled = False
            btnModificar.Enabled = False
            btnEliminar.Enabled = False
        End If
    End Sub

    Private Sub limpiar()
        txtCodigoIN.Text = String.Empty
        txtNombre.Text = String.Empty
        txtApellidos.Text = String.Empty
        txtCINit.Text = String.Empty
        If opcion = 1 Then
            getCorrelativo()
        End If
    End Sub

    Private Sub getCorrelativo()
        Using objCliente As New Negocios.ClienteInBL(usuario, clave)
            Dim correlativo As Integer
            correlativo = objCliente.getCorrelativoBL()
            If objCliente.existeError Then
                DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objCliente.mensajesErrorSistema, objCliente.mensajeErrorUsuarios),
                                                                 rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                txtCodigoIN.Text = correlativo
            End If
        End Using
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
                lkNegocio.DataSource = dt
                lkNegocio.DisplayMember = "unidad"
                lkNegocio.ValueMember = "coduneg"
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
                XtraMessageBox.Show(String.Format("{0} {1}", objUtilitario.mensajesErrorSistema, objUtilitario.mensajesErrorUsuario),
                                                           rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                lkTipoCliente.DataSource = dt
                lkTipoCliente.ValueMember = "codigo"
                lkTipoCliente.DisplayMember = "descripcion"
            End If
            objUtilitario.finalizar()
        End Using
    End Sub

    Private Sub getDatosComplementarios()
        Using objCliente As New Negocios.ClienteNegocioBL(usuario, clave)
            If txtCodigoIN.Text <> String.Empty Then
                Dim dt As New DataTable
                Dim item As New Entidades.tb_clienteNegocio With {.codigoin = txtCodigoIN.Text}
                dt = objCliente.getClienteNegocioBL(item)
                If objCliente.existeError Then
                    XtraMessageBox.Show(String.Format("{0} {1}", objCliente.mensajesErrorSistema, objCliente.mensajeErrorUsuarios),
                                        rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    gcComplementario.DataSource = dt
                End If
                Call objCliente.finalizar()
            End If
        End Using
    End Sub


    Private Function validarAlta() As Boolean
        Dim Result As Integer = 0
        dxErrorProvider.ClearErrors()
        If Not Integer.TryParse(txtCodigoIN.Text, Result) Then
            dxErrorProvider.SetError(txtCodigoIN, "El código del Modulo es requerido")
            txtCodigoIN.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtNombre.Text) Then
            dxErrorProvider.SetError(txtNombre, "El campo nombre es requerido")
            txtNombre.Focus()
            Return False
        ElseIf Not Integer.TryParse(txtCINit.Text, Result) Then
            dxErrorProvider.SetError(txtCINit, "El campo NIT/CI es requerido")
            txtCINit.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub alta()
        Using objCliente As New Negocios.ClienteInBL(usuario, clave)
            If validarAlta() Then
                Dim item As New tb_clienteIn With {.codigoin = txtCodigoIN.Text, .nombre = txtNombre.Text,
                                                  .apellido = txtApellidos.Text, .nitci = txtCINit.Text}
                objCliente.validarDatosTransaccion()
                If (objCliente.DatosValidosEnNegocios) Then
                    Call objCliente.limpiarErrorBase()
                    Call objCliente.abrirTransaccion()
                    Call objCliente.altaBL(item)
                    If objCliente.existeError Then
                        Call objCliente.rechazarTransaccion()
                        XtraMessageBox.Show(String.Format("{0} {1}", objCliente.mensajesErrorSistema, objCliente.mensajeErrorUsuarios),
                                                                   rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        objCliente.aceptarTransaccion()
                        XtraMessageBox.Show(rcRecursos.msOK, rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Call limpiar()
                    End If
                End If
            End If
            objCliente.finalizar()
        End Using
    End Sub

    Private Sub baja()
        Using objCliente As New Negocios.ClienteInBL(usuario, clave)
            If validarAlta() Then
                If XtraMessageBox.Show(rcRecursos.msEliminar, rcRecursos.msTitulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MessageBoxButtons.OK Then
                    Dim item As New tb_clienteIn With {.codigoin = txtCodigoIN.Text, .nombre = txtNombre.Text,
                                                           .apellido = txtApellidos.Text, .nitci = txtCINit.Text}
                    objCliente.validarDatosTransaccion()
                    If (objCliente.DatosValidosEnNegocios) Then
                        Call objCliente.limpiarErrorBase()
                        Call objCliente.abrirTransaccion()
                        Call objCliente.bajaBL(item)
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
        Using objCliente As New Negocios.ClienteInBL(usuario, clave)
            If validarAlta() Then
                Dim item As New tb_clienteIn With {.codigoin = txtCodigoIN.Text, .nombre = txtNombre.Text,
                                                 .apellido = txtApellidos.Text, .nitci = txtCINit.Text}
                objCliente.validarDatosTransaccion()
                If (objCliente.DatosValidosEnNegocios) Then
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
            Using objCliente As New Negocios.ClienteInBL(usuario, clave)
                Dim dt As New DataTable
                Dim item(0) As tb_clienteIn
                item.SetValue(lista.ElementAt(0), 0)

                Dim itemTabla As New tb_clienteIn
                itemTabla = item.GetValue(0)
                dt = objCliente.getClienteInBL(itemTabla)

                If objCliente.existeError Then
                    DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objCliente.mensajesErrorSistema, objCliente.mensajeErrorUsuarios),
                                                                  rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf dt.Rows.Count > 0 Then
                    txtCodigoIN.Text = If(IsDBNull(dt.Rows(0).Item("codigoin")), Nothing, dt.Rows(0).Item("codigoin"))
                    txtNombre.Text = If(IsDBNull(dt.Rows(0).Item("nombre")), Nothing, dt.Rows(0).Item("nombre"))
                    txtApellidos.Text = If(IsDBNull(dt.Rows(0).Item("apellido")), Nothing, dt.Rows(0).Item("apellido"))
                    txtCINit.Text = If(IsDBNull(dt.Rows(0).Item("nitci")), Nothing, dt.Rows(0).Item("nitci"))

                    index = 0

                End If
                objCliente.finalizar()
            End Using
        End If
    End Sub

    Private Sub siguente()
        If lista.Count - 1 > 0 Then
            If index <> lista.Count - 1 Then
                Using objCliente As New Negocios.ClienteInBL(usuario, clave)
                    Dim dt As New DataTable
                    Dim item(0) As tb_clienteIn
                    item.SetValue(lista.ElementAt(index + 1), 0)
                    Dim itemTabla As New tb_clienteIn
                    itemTabla = item.GetValue(0)
                    dt = objCliente.getClienteInBL(itemTabla)

                    If objCliente.existeError Then
                        DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objCliente.mensajesErrorSistema, objCliente.mensajeErrorUsuarios),
                                                                      rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ElseIf dt.Rows.Count > 0 Then
                        txtCodigoIN.Text = If(IsDBNull(dt.Rows(0).Item("codigoin")), Nothing, dt.Rows(0).Item("codigoin"))
                        txtNombre.Text = If(IsDBNull(dt.Rows(0).Item("nombre")), Nothing, dt.Rows(0).Item("nombre"))
                        txtApellidos.Text = If(IsDBNull(dt.Rows(0).Item("apellido")), Nothing, dt.Rows(0).Item("apellido"))
                        txtCINit.Text = If(IsDBNull(dt.Rows(0).Item("nitci")), Nothing, dt.Rows(0).Item("nitci"))

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
                Using objCliente As New Negocios.ClienteInBL(usuario, clave)
                    Dim dt As New DataTable
                    Dim item(0) As tb_clienteIn
                    item.SetValue(lista.ElementAt(index - 1), 0)
                    Dim itemTabla As New tb_clienteIn
                    itemTabla = item.GetValue(0)
                    dt = objCliente.getClienteInBL(itemTabla)
                    If objCliente.existeError Then
                        DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objCliente.mensajesErrorSistema, objCliente.mensajeErrorUsuarios),
                                                                      rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ElseIf dt.Rows.Count > 0 Then
                        txtCodigoIN.Text = If(IsDBNull(dt.Rows(0).Item("codigoin")), Nothing, dt.Rows(0).Item("codigoin"))
                        txtNombre.Text = If(IsDBNull(dt.Rows(0).Item("nombre")), Nothing, dt.Rows(0).Item("nombre"))
                        txtApellidos.Text = If(IsDBNull(dt.Rows(0).Item("apellido")), Nothing, dt.Rows(0).Item("apellido"))
                        txtCINit.Text = If(IsDBNull(dt.Rows(0).Item("nitci")), Nothing, dt.Rows(0).Item("nitci"))

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
            Using objCliente As New Negocios.ClienteInBL(usuario, clave)
                Dim dt As New DataTable
                Dim item(0) As tb_clienteIn
                item.SetValue(lista.Last, 0)
                Dim itemTabla As New tb_clienteIn
                itemTabla = item.GetValue(0)
                dt = objCliente.getClienteInBL(itemTabla)
                If objCliente.existeError Then
                    DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objCliente.mensajesErrorSistema, objCliente.mensajeErrorUsuarios),
                                                                  rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf dt.Rows.Count > 0 Then
                    txtCodigoIN.Text = If(IsDBNull(dt.Rows(0).Item("codigoin")), Nothing, dt.Rows(0).Item("codigoin"))
                    txtNombre.Text = If(IsDBNull(dt.Rows(0).Item("nombre")), Nothing, dt.Rows(0).Item("nombre"))
                    txtApellidos.Text = If(IsDBNull(dt.Rows(0).Item("apellido")), Nothing, dt.Rows(0).Item("apellido"))
                    txtCINit.Text = If(IsDBNull(dt.Rows(0).Item("nitci")), Nothing, dt.Rows(0).Item("nitci"))

                    index = lista.Count - 1

                End If
            End Using
        End If
    End Sub

#End Region

#Region "Eventos"

    Private Sub UI_Cliente_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call getUnidad()
        Call getTipoCliente()
        Call getDatosComplementarios()
        txtNombre.Focus()
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

    Private Sub btnComplemento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComplemento.Click
        Dim nombre As String = txtNombre.Text & " " & txtApellidos.Text
        Dim objFormModulo As New UI_CarteraCliente(usuario, clave, 1, txtCodigoIN.Text, nombre) With {.MdiParent = MdiParent}
        objFormModulo.Show()
    End Sub

#End Region

End Class