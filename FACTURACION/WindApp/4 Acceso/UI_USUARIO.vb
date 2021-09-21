Imports System.Drawing.Printing
Imports System.Data
Imports Entidades
Imports System.Windows.Forms
Imports System.Collections
Public Class UI_USUARIO : Inherits f_base

#Region "[atributosGlobales]"

    Private usuario As String
    Private clave As String
    Private opcion As Integer
    Private lista As List(Of Entidades.tb_Cobusuar)
    Private index As Integer

#End Region

#Region "constructor"

    Public Sub New(ByVal usuar As String, ByVal clav As String)
        MyBase.new("CREACIÓN DE USUARIO", "Ingrese los datos solicitados...")
        InitializeComponent()
        usuario = usuar
        clave = clav
        opcion = 0
        Call getMaxCodigoBL()
    End Sub

    Public Sub New(ByVal usuar As String, ByVal clav As String, ByVal list As List(Of Entidades.tb_Cobusuar), ByVal Opc As Integer)
        MyBase.new("CREACIÓN DE USUARIO", "Ingrese los datos solicitados...")
        InitializeComponent()
        usuario = usuar
        clave = clav
        lista = list
        opcion = Opc
        Call getCategoria()
        Call getSucrusal()
        Call inicio()
        Call getOpcion()
    End Sub

#End Region

#Region "[Metodos]"

    Private Sub inicio()
        If lista.Count > 0 Then
            Using objUsuario As New Negocios.usuariong(usuario, clave)
                Dim dt As New DataTable
                Dim item(0) As tb_Cobusuar
                item.SetValue(lista.ElementAt(0), 0)

                Dim itemTabla As New tb_Cobusuar
                itemTabla = item.GetValue(0)
                dt = objUsuario.getUnUsuariosBL(itemTabla)

                If objUsuario.existeError Then
                    DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objUsuario.mensaje_ErrorSistema, objUsuario.mensaje_ErrorUsuario),
                                                                  "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf dt.Rows.Count > 0 Then
                    txtIdUsuario.Text = dt.Rows(0).Item("usrcodig")
                    txtNombre.Text = dt.Rows(0).Item("usrnombr")
                    txtApellidos.Text = dt.Rows(0).Item("usrapell")
                    CbCategoria.SelectedValue = dt.Rows(0).Item("usrcdcat")
                    CbSucursal.SelectedValue = dt.Rows(0).Item("usrcdsuc")
                    txtLogin.Text = dt.Rows(0).Item("usrlogin")
                    txtPassword.Text = dt.Rows(0).Item("usrpassw")
                    dtFecha.Text = dt.Rows(0).Item("usrfecha")
                    txtEmail.Text = dt.Rows(0).Item("usremail")
                    txtObservaciones.Text = dt.Rows(0).Item("usrobser")
                    dtFechaCaducidad.Text = dt.Rows(0).Item("usrfecad")

                    index = 0
                    If dt.Rows(0).Item("usrestad") = "a" Then
                        rbActivo.Checked = True
                    Else
                        rbInactivo.Checked = True
                    End If
                End If
                objUsuario.finalizar()
            End Using
        End If
    End Sub

    Private Sub siguente()
        If lista.Count - 1 > 0 Then
            If index <> lista.Count - 1 Then
                Using objUsuario As New Negocios.usuariong(usuario, clave)
                    Dim dt As New DataTable
                    Dim item(0) As tb_Cobusuar
                    item.SetValue(lista.ElementAt(index + 1), 0)
                    Dim itemTabla As New tb_Cobusuar
                    itemTabla = item.GetValue(0)
                    dt = objUsuario.getUnUsuariosBL(itemTabla)

                    If objUsuario.existeError Then
                        DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objUsuario.mensaje_ErrorSistema, objUsuario.mensaje_ErrorUsuario),
                                                                      "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ElseIf dt.Rows.Count > 0 Then
                        txtIdUsuario.Text = dt.Rows(0).Item("usrcodig")
                        txtNombre.Text = dt.Rows(0).Item("usrnombr")
                        txtApellidos.Text = dt.Rows(0).Item("usrapell")
                        CbCategoria.SelectedValue = dt.Rows(0).Item("usrcdcat")
                        CbSucursal.SelectedValue = dt.Rows(0).Item("usrcdsuc")
                        txtLogin.Text = dt.Rows(0).Item("usrlogin")
                        txtPassword.Text = dt.Rows(0).Item("usrpassw")
                        dtFecha.Text = dt.Rows(0).Item("usrfecha")
                        txtEmail.Text = dt.Rows(0).Item("usremail")
                        txtObservaciones.Text = dt.Rows(0).Item("usrobser")
                        dtFechaCaducidad.Text = dt.Rows(0).Item("usrfecad")

                        If dt.Rows(0).Item("usrestad") = "a" Then
                            rbActivo.Checked = True
                        Else
                            rbInactivo.Checked = True
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
                Using objUsuario As New Negocios.usuariong(usuario, clave)
                    Dim dt As New DataTable
                    Dim item(0) As tb_Cobusuar
                    item.SetValue(lista.ElementAt(index - 1), 0)
                    Dim itemTabla As New tb_Cobusuar
                    itemTabla = item.GetValue(0)
                    dt = objUsuario.getUnUsuariosBL(itemTabla)
                    If objUsuario.existeError Then
                        DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objUsuario.mensaje_ErrorSistema, objUsuario.mensaje_ErrorUsuario),
                                                                      "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ElseIf dt.Rows.Count > 0 Then
                        txtIdUsuario.Text = dt.Rows(0).Item("usrcodig")
                        txtNombre.Text = dt.Rows(0).Item("usrnombr")
                        txtApellidos.Text = dt.Rows(0).Item("usrapell")
                        CbCategoria.SelectedValue = dt.Rows(0).Item("usrcdcat")
                        CbSucursal.SelectedValue = dt.Rows(0).Item("usrcdsuc")
                        txtLogin.Text = dt.Rows(0).Item("usrlogin")
                        txtPassword.Text = dt.Rows(0).Item("usrpassw")
                        dtFecha.Text = dt.Rows(0).Item("usrfecha")
                        txtEmail.Text = dt.Rows(0).Item("usremail")
                        txtObservaciones.Text = dt.Rows(0).Item("usrobser")
                        dtFechaCaducidad.Text = dt.Rows(0).Item("usrfecad")

                        If dt.Rows(0).Item("usrestad") = "a" Then
                            rbActivo.Checked = True
                        Else
                            rbInactivo.Checked = True
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
            Using objUsuario As New Negocios.usuariong(usuario, clave)
                Dim dt As New DataTable
                Dim item(0) As tb_Cobusuar
                item.SetValue(lista.Last, 0)
                Dim itemTabla As New tb_Cobusuar
                itemTabla = item.GetValue(0)
                dt = objUsuario.getUnUsuariosBL(itemTabla)
                If objUsuario.existeError Then
                    DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objUsuario.mensaje_ErrorSistema, objUsuario.mensaje_ErrorUsuario),
                                                                  "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf dt.Rows.Count > 0 Then
                    txtIdUsuario.Text = dt.Rows(0).Item("usrcodig")
                    txtNombre.Text = dt.Rows(0).Item("usrnombr")
                    txtApellidos.Text = dt.Rows(0).Item("usrapell")
                    CbCategoria.SelectedValue = dt.Rows(0).Item("usrcdcat")
                    CbSucursal.SelectedValue = dt.Rows(0).Item("usrcdsuc")
                    txtLogin.Text = dt.Rows(0).Item("usrlogin")
                    txtPassword.Text = dt.Rows(0).Item("usrpassw")
                    dtFecha.Text = dt.Rows(0).Item("usrfecha")
                    txtEmail.Text = dt.Rows(0).Item("usremail")
                    txtObservaciones.Text = dt.Rows(0).Item("usrobser")
                    dtFechaCaducidad.Text = dt.Rows(0).Item("usrfecad")

                    If dt.Rows(0).Item("usrestad") = "a" Then
                        rbActivo.Checked = True
                    Else
                        rbInactivo.Checked = True
                    End If

                    index = lista.Count - 1
                End If
            End Using
        End If
    End Sub

    Private Sub getOpcion()
        If opcion = 1 Then
            btnGrabar.Enabled = True
            btnModificar.Enabled = False
            btnEliminar.Enabled = False
            txtIdUsuario.ReadOnly = Not False

        ElseIf opcion = 2 Then
            btnGrabar.Enabled = False
            btnModificar.Enabled = True
            btnEliminar.Enabled = False
            txtIdUsuario.ReadOnly = Not False

        ElseIf opcion = 3 Then
            btnGrabar.Enabled = False
            btnModificar.Enabled = False
            btnEliminar.Enabled = True

            txtIdUsuario.ReadOnly = Not False
            txtNombre.ReadOnly = Not False
            txtApellidos.ReadOnly = Not False

        Else
            btnGrabar.Enabled = False
            btnModificar.Enabled = False
            btnEliminar.Enabled = False
        End If
    End Sub

    Private Sub getMaxCodigoBL()
        Using objUsuario As New Negocios.usuariong(usuario, clave)
            Dim maxCodigo As Integer
            maxCodigo = objUsuario.getMaxCodigoBL()
            If objUsuario.existeError Then
                MessageBox.Show(objUsuario.mensaje_ErrorUsuario & objUsuario.mensaje_ErrorSistema, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                txtIdUsuario.Text = maxCodigo
            End If
            objUsuario.finalizar()
        End Using
    End Sub

    Private Sub getCategoria()
        Using objUsuario As New Negocios.usuariong(usuario, clave)
            Dim dtCategoria As New DataTable()
            dtCategoria = objUsuario.getCategoriaDeUsuariosBL()
            If objUsuario.existeError Then
                MessageBox.Show(objUsuario.mensaje_ErrorUsuario & objUsuario.mensaje_ErrorSistema, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                CbCategoria.DataSource = dtCategoria
                CbCategoria.ValueMember = "pacodigo"
                CbCategoria.DisplayMember = "padescri"
                CbCategoria.AutoCompleteMode = AutoCompleteMode.Suggest
                CbCategoria.AutoCompleteSource = AutoCompleteSource.CustomSource
            End If
            objUsuario.finalizar()
        End Using

    End Sub

    Private Sub getSucrusal()
        Using objUsuario As New Negocios.usuariong(usuario, clave)
            Dim dtSucrusal As New DataTable()
            dtSucrusal = objUsuario.getUsuariosXSucrusalBL()
            If objUsuario.existeError Then
                MessageBox.Show(objUsuario.mensaje_ErrorUsuario & objUsuario.mensaje_ErrorSistema, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                CbSucursal.DataSource = dtSucrusal
                CbSucursal.ValueMember = "pacodigo"
                CbSucursal.DisplayMember = "padescri"
                CbSucursal.AutoCompleteMode = AutoCompleteMode.Suggest
                CbSucursal.AutoCompleteSource = AutoCompleteSource.CustomSource
            End If
            objUsuario.finalizar()
        End Using
    End Sub

    Private Function validar()
        Dim Result As Integer = 0
        Dim value As DateTime
        dxErrorProvider.ClearErrors()
        If Not Int32.TryParse(txtIdUsuario.Text, Result) Then
            dxErrorProvider.SetError(txtIdUsuario, "El campo codigo es requerido")
            txtIdUsuario.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtNombre.Text) Then
            dxErrorProvider.SetError(txtNombre, "El campo nombre es requerido")
            txtNombre.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtApellidos.Text) Then
            dxErrorProvider.SetError(txtApellidos, "El campo apellidos es requerido")
            txtApellidos.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtLogin.Text) Then
            dxErrorProvider.SetError(txtLogin, "El campo login es requerido")
            txtLogin.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtPassword.Text) Then
            dxErrorProvider.SetError(txtPassword, "El campo password es requerido")
            txtPassword.Focus()
            Return False
        ElseIf Not DateTime.TryParse(dtFecha.Text, value) Then
            dxErrorProvider.SetError(dtFecha, "El campo fecha es requerido")
            dtFecha.Focus()
            Return False
        ElseIf Not DateTime.TryParse(dtFechaCaducidad.Text, value) Then
            dxErrorProvider.SetError(dtFechaCaducidad, "El campo fecha de caducidad es requerido")
            dtFechaCaducidad.Focus()
            Return False
        ElseIf dtFecha.Text > dtFechaCaducidad.Text Then
            dxErrorProvider.SetError(dtFecha, "El campo fecha de caducidad no puede ser menor que la fecha de registro")
            dtFecha.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub limpiar()
        txtIdUsuario.Text = String.Empty
        txtNombre.Text = String.Empty : txtApellidos.Text = String.Empty
        txtObservaciones.Text = String.Empty
        txtLogin.Text = String.Empty : txtPassword.Text = String.Empty
        txtEmail.Text = String.Empty
        If opcion = 0 Then
            Call getMaxCodigoBL()
        End If
    End Sub

    Private Sub alta()
        If validar() Then
            Using objUsuario As New Negocios.usuariong(usuario, clave)
                Dim estado As String = String.Empty
                If rbActivo.Checked Then
                    estado = "a"
                Else
                    estado = "i"
                End If
                Dim item As New Entidades.tb_Cobusuar With {.usrlogin = txtLogin.Text, .usrcodig = txtIdUsuario.Text, .usrcdneg = 0,
                                                               .usrsbneg = 0, .usrcdcat = CbCategoria.SelectedValue,
                                                               .usrcdsuc = CbSucursal.SelectedValue,
                                                               .usrempld = 0, .usrpassw = txtPassword.Text,
                                                               .usrnombr = txtNombre.Text, .usrapell = txtApellidos.Text,
                                                               .usrfecha = dtFecha.Text, .usripeqp = "0", .usradrrs = "0",
                                                               .usrobser = txtObservaciones.Text, .usremail = txtEmail.Text,
                                                               .usrdepen = "", .usrejefe = "", .usrestad = estado,
                                                               .usrfecad = dtFechaCaducidad.Text, .login2 = "", .passwor2 = ""}
                objUsuario.validarDatosTransaccion()
                If (objUsuario.DatosValidosEnNegocios) Then
                    Call objUsuario.Limpiar_Error_Base()
                    Call objUsuario.Abrir_Transaccion()
                    Call objUsuario.alta_usuariong(item)
                    If objUsuario.existeError Then
                        Call objUsuario.Rechazar_Transaccion()
                        DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objUsuario.mensaje_ErrorUsuario, objUsuario.mensaje_ErrorSistema),
                                                                   "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        Call objUsuario.Aceptar_Transaccion()
                        DevExpress.XtraEditors.XtraMessageBox.Show("Transacción realizada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Call limpiar()
                    End If
                End If
            End Using
        End If
    End Sub

    Private Sub modificar()
        If validar() Then
            Using objUsuario As New Negocios.usuariong(usuario, clave)
                Dim estado As String = String.Empty
                If rbActivo.Checked Then
                    estado = "a"
                Else
                    estado = "i"
                End If
                Dim item As New Entidades.tb_Cobusuar With {.usrlogin = txtLogin.Text, .usrcodig = txtIdUsuario.Text, .usrcdneg = 0,
                                                               .usrsbneg = 0, .usrcdcat = CbCategoria.SelectedValue,
                                                               .usrcdsuc = CbSucursal.SelectedValue,
                                                               .usrempld = 0, .usrpassw = txtPassword.Text,
                                                               .usrnombr = txtNombre.Text, .usrapell = txtApellidos.Text,
                                                               .usrfecha = dtFecha.Text, .usripeqp = "0", .usradrrs = "0",
                                                               .usrobser = txtObservaciones.Text, .usremail = txtEmail.Text,
                                                               .usrdepen = "", .usrejefe = "", .usrestad = estado,
                                                               .usrfecad = dtFechaCaducidad.Text, .login2 = "", .passwor2 = ""}
                objUsuario.validarDatosTransaccion()
                If (objUsuario.DatosValidosEnNegocios) Then
                    Call objUsuario.Limpiar_Error_Base()
                    Call objUsuario.Abrir_Transaccion()
                    Call objUsuario.modificacion_usuariong(item)
                    If objUsuario.existeError Then
                        Call objUsuario.Rechazar_Transaccion()
                        DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objUsuario.mensaje_ErrorUsuario, objUsuario.mensaje_ErrorSistema),
                                                                   "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        Call objUsuario.Aceptar_Transaccion()
                        DevExpress.XtraEditors.XtraMessageBox.Show("Transacción realizada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Call limpiar()
                    End If
                End If
            End Using
        End If
    End Sub

    Private Sub baja()
        If validar() Then
            Using objUsuario As New Negocios.usuariong(usuario, clave)
                Dim estado As String = String.Empty
                If rbActivo.Checked Then
                    estado = "a"
                Else
                    estado = "i"
                End If
                Dim item As New Entidades.tb_Cobusuar With {.usrlogin = txtLogin.Text, .usrestad = estado}
                objUsuario.validarDatosTransaccion()
                If (objUsuario.DatosValidosEnNegocios) Then
                    Call objUsuario.Limpiar_Error_Base()
                    Call objUsuario.Abrir_Transaccion()
                    Call objUsuario.baja_usuariong(item)
                    If objUsuario.existeError Then
                        Call objUsuario.Rechazar_Transaccion()
                        DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objUsuario.mensaje_ErrorUsuario, objUsuario.mensaje_ErrorSistema),
                                                                   "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        Call objUsuario.Aceptar_Transaccion()
                        DevExpress.XtraEditors.XtraMessageBox.Show("Transacción realizada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Call limpiar()
                    End If
                End If
            End Using
        End If
    End Sub

#End Region

#Region "[Eventos]"

    Private Sub ALTA_USUARIO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Call getCategoria()
        'Call getSucrusal()
    End Sub

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