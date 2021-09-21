Imports Entidades
Imports WindApp.My.Resources
Public Class UI_Empresa : Inherits f_base

#Region "[atributosGlobales]"

    Private usuario As String
    Private clave As String
    Private opcion As Integer
    Private lista As List(Of tb_empresa)
    Private index As Integer

#End Region

#Region "[contrutor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String, ByVal opc As Integer)
        MyBase.New(usuar, clav, "Datos del registro Empresa", "Realize la operacion necesaria...")
        InitializeComponent()
        usuario = usuar : clave = clav
        opcion = opc
        Call getOpcion()
        Call limpiar()
    End Sub

    Public Sub New(ByVal usuar As String, ByVal clav As String, ByVal list As List(Of tb_empresa), ByVal opc As Integer)
        MyBase.New(usuar, clav, "Datos del registro Empresa", "Realize la operacion necesaria...")
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
            txtcod_actividad.ReadOnly = Not False

        ElseIf opcion = 3 Then
            btnGuardar.Enabled = False
            btnModificar.Enabled = False
            btnEliminar.Enabled = True

            txtcod_actividad.ReadOnly = False
            txtnomb_empresa.ReadOnly = Not False
            txtnomb_actividad.ReadOnly = Not False
            txtciudad.ReadOnly = Not False
            txtPais.Enabled = Not False
            txtDireccion.Enabled = Not False
        Else
            btnGuardar.Enabled = False
            btnModificar.Enabled = False
            btnEliminar.Enabled = False
        End If
    End Sub

    Private Function validar() As Boolean
        Dim Result As Integer = 0
        dxErrorProvider.Clear()
        If String.IsNullOrEmpty(txtcod_actividad.Text) Then
            dxErrorProvider.SetError(txtcod_actividad, "El campo codigo es requerido")
            txtcod_actividad.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtNit.Text) Then
            dxErrorProvider.SetError(txtNit, "El campo Nit es requerido")
            txtNit.Focus()
            Return False
        Else
            Return True
        End If
        Return True
    End Function

    Private Sub limpiar()
        txtcod_actividad.Text = String.Empty
        txtnomb_empresa.Text = String.Empty
        txtnomb_actividad.Text = String.Empty
        txtDireccion.Text = String.Empty
        txtciudad.Text = String.Empty
        txtPais.Text = String.Empty
        txtCodPostal.Text = String.Empty
        txtTelefono1.Text = String.Empty
        txtTelefono2.Text = String.Empty
        txtNit.Text = String.Empty : txtCNS.Text = String.Empty
    End Sub

    Private Sub alta()
        Using objEmpresa As New Negocios.EmpresaBL(usuario, clave)
            If validar() Then
                Dim item As New tb_empresa With {.cod_actividad = txtcod_actividad.Text, .nomb_actividad = txtnomb_actividad.Text,
                                                 .nomb_empresa = txtnomb_empresa.Text, .ciudad = txtciudad.Text,
                                                 .pais = txtPais.Text, .direccion = txtDireccion.Text,
                                                 .cod_postal = txtCodPostal.Text, .email = txtEmail.Text,
                                                 .telefono1 = txtTelefono1.Text, .telefono2 = txtTelefono2.Text,
                                                 .nic = txtNit.Text, .cns = txtCNS.Text}
                objEmpresa.validarDatosTransaccion()
                If (objEmpresa.datosValidosParametros) Then
                    Call objEmpresa.limpiarErrorBase()
                    Call objEmpresa.abrirTransaccion()
                    Call objEmpresa.altaBL(item)
                    If objEmpresa.existeError Then
                        Call objEmpresa.rechazarTransaccion()
                        MessageBox.Show(String.Format("{0} {1}", objEmpresa.mensajesErrorSistema, objEmpresa.mensajesErrorUsuario),
                                                                   rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        objEmpresa.aceptarTransaccion()
                        MessageBox.Show("Transacción realizada", rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Call limpiar()
                    End If
                End If
            End If
            objEmpresa.finalizar()
        End Using
    End Sub

    Private Sub baja()
        Using objEmpresa As New Negocios.EmpresaBL(usuario, clave)
            If validar() Then
                Dim item As New tb_empresa With {.cod_actividad = txtcod_actividad.Text}
                objEmpresa.validarDatosTransaccion()
                If (objEmpresa.datosValidosParametros) Then
                    Call objEmpresa.limpiarErrorBase()
                    Call objEmpresa.abrirTransaccion()
                    Call objEmpresa.bajaBL(item)
                    If objEmpresa.existeError Then
                        Call objEmpresa.rechazarTransaccion()
                        MessageBox.Show(String.Format("{0} {1}", objEmpresa.mensajesErrorSistema, objEmpresa.mensajesErrorUsuario),
                                                                   rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        objEmpresa.aceptarTransaccion()
                        MessageBox.Show("Transacción realizada", rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Call limpiar()
                    End If
                End If
            End If
            objEmpresa.finalizar()
        End Using
    End Sub

    Private Sub actualizar()
        Using objEmpresa As New Negocios.EmpresaBL(usuario, clave)
            If validar() Then
                Dim item As New tb_empresa With {.cod_actividad = txtcod_actividad.Text, .nomb_actividad = txtnomb_actividad.Text,
                                                 .nomb_empresa = txtnomb_empresa.Text, .ciudad = txtciudad.Text,
                                                 .pais = txtPais.Text, .direccion = txtDireccion.Text,
                                                 .cod_postal = txtCodPostal.Text, .email = txtEmail.Text,
                                                 .telefono1 = txtTelefono1.Text, .telefono2 = txtTelefono2.Text,
                                                 .nic = txtNit.Text, .cns = txtCNS.Text}
                objEmpresa.validarDatosTransaccion()
                If (objEmpresa.datosValidosParametros) Then
                    Call objEmpresa.limpiarErrorBase()
                    Call objEmpresa.abrirTransaccion()
                    Call objEmpresa.actualizarBL(item)
                    If objEmpresa.existeError Then
                        Call objEmpresa.rechazarTransaccion()
                        MessageBox.Show(String.Format("{0} {1}", objEmpresa.mensajesErrorSistema, objEmpresa.mensajesErrorUsuario),
                                                                   rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        objEmpresa.aceptarTransaccion()
                        MessageBox.Show("Transacción realizada", rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Call limpiar()
                    End If
                End If
            End If
            objEmpresa.finalizar()
        End Using
    End Sub

    Private Sub inicio()
        If lista.Count > 0 Then
            Using objEmpresa As New Negocios.EmpresaBL(usuario, clave)
                Dim dt As New DataTable
                Dim item(0) As tb_empresa
                item.SetValue(lista.ElementAt(0), 0)

                Dim itemTabla As New tb_empresa
                itemTabla = item.GetValue(0)
                dt = objEmpresa.getEmpresaBL(itemTabla)

                If objEmpresa.existeError Then
                    MessageBox.Show(String.Format("{0} {1}", objEmpresa.mensajesErrorSistema, objEmpresa.mensajesErrorUsuario),
                                                      rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf dt.Rows.Count > 0 Then
                    txtcod_actividad.Text = dt.Rows(0).Item("cod_actividad")
                    txtnomb_actividad.Text = dt.Rows(0).Item("nomb_actividad")
                    txtnomb_empresa.Text = dt.Rows(0).Item("nomb_empresa")
                    txtciudad.Text = dt.Rows(0).Item("ciudad")
                    txtPais.Text = dt.Rows(0).Item("pais")
                    txtDireccion.Text = dt.Rows(0).Item("direccion")
                    txtCodPostal.Text = dt.Rows(0).Item("cod_postal")
                    txtEmail.Text = dt.Rows(0).Item("email")
                    txtTelefono1.Text = dt.Rows(0).Item("telefono1") : txtTelefono2.Text = dt.Rows(0).Item("telefono2")
                    txtNit.Text = dt.Rows(0).Item("nic") : txtCNS.Text = dt.Rows(0).Item("cns")
                    index = 0
                End If
                objEmpresa.finalizar()
            End Using
        End If
    End Sub

    Private Sub siguente()
        If lista.Count - 1 > 0 Then
            If index <> lista.Count - 1 Then
                Using objEmpresa As New Negocios.EmpresaBL(usuario, clave)
                    Dim dt As New DataTable
                    Dim item(0) As tb_empresa
                    item.SetValue(lista.ElementAt(index + 1), 0)
                    Dim itemTabla As New tb_empresa
                    itemTabla = item.GetValue(0)
                    dt = objEmpresa.getEmpresaBL(itemTabla)

                    If objEmpresa.existeError Then
                        MessageBox.Show(String.Format("{0} {1}", objEmpresa.mensajesErrorSistema, objEmpresa.mensajesErrorUsuario),
                                                       rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ElseIf dt.Rows.Count > 0 Then
                        txtcod_actividad.Text = dt.Rows(0).Item("cod_actividad")
                        txtnomb_actividad.Text = dt.Rows(0).Item("nomb_actividad")
                        txtnomb_empresa.Text = dt.Rows(0).Item("nomb_empresa")
                        txtciudad.Text = dt.Rows(0).Item("ciudad")
                        txtPais.Text = dt.Rows(0).Item("pais")
                        txtDireccion.Text = dt.Rows(0).Item("direccion")
                        txtCodPostal.Text = dt.Rows(0).Item("cod_postal")
                        txtEmail.Text = dt.Rows(0).Item("email")
                        txtTelefono1.Text = dt.Rows(0).Item("telefono1") : txtTelefono2.Text = dt.Rows(0).Item("telefono2")
                        txtNit.Text = dt.Rows(0).Item("nic") : txtCNS.Text = dt.Rows(0).Item("cns")

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
                Using objEmpresa As New Negocios.EmpresaBL(usuario, clave)
                    Dim dt As New DataTable
                    Dim item(0) As tb_empresa
                    item.SetValue(lista.ElementAt(index - 1), 0)
                    Dim itemTabla As New tb_empresa
                    itemTabla = item.GetValue(0)
                    dt = objEmpresa.getEmpresaBL(itemTabla)
                    If objEmpresa.existeError Then
                        MessageBox.Show(String.Format("{0} {1}", objEmpresa.mensajesErrorSistema, objEmpresa.mensajesErrorUsuario),
                                           rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ElseIf dt.Rows.Count > 0 Then
                        txtcod_actividad.Text = dt.Rows(0).Item("cod_actividad")
                        txtnomb_actividad.Text = dt.Rows(0).Item("nomb_actividad")
                        txtnomb_empresa.Text = dt.Rows(0).Item("nomb_empresa")
                        txtciudad.Text = dt.Rows(0).Item("ciudad")
                        txtPais.Text = dt.Rows(0).Item("pais")
                        txtDireccion.Text = dt.Rows(0).Item("direccion")
                        txtCodPostal.Text = dt.Rows(0).Item("cod_postal")
                        txtEmail.Text = dt.Rows(0).Item("email")
                        txtTelefono1.Text = dt.Rows(0).Item("telefono1") : txtTelefono2.Text = dt.Rows(0).Item("telefono2")
                        txtNit.Text = dt.Rows(0).Item("nic") : txtCNS.Text = dt.Rows(0).Item("cns")

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
            Using objEmpresa As New Negocios.EmpresaBL(usuario, clave)
                Dim dt As New DataTable
                Dim item(0) As tb_empresa
                item.SetValue(lista.Last, 0)
                Dim itemTabla As New tb_empresa
                itemTabla = item.GetValue(0)
                dt = objEmpresa.getEmpresaBL(itemTabla)
                If objEmpresa.existeError Then
                    MessageBox.Show(String.Format("{0} {1}", objEmpresa.mensajesErrorSistema, objEmpresa.mensajesErrorUsuario),
                                    rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf dt.Rows.Count > 0 Then
                    txtcod_actividad.Text = dt.Rows(0).Item("cod_actividad")
                    txtnomb_actividad.Text = dt.Rows(0).Item("nomb_actividad")
                    txtnomb_empresa.Text = dt.Rows(0).Item("nomb_empresa")
                    txtciudad.Text = dt.Rows(0).Item("ciudad")
                    txtPais.Text = dt.Rows(0).Item("pais")
                    txtDireccion.Text = dt.Rows(0).Item("direccion")
                    txtCodPostal.Text = dt.Rows(0).Item("cod_postal")
                    txtEmail.Text = dt.Rows(0).Item("email")
                    txtTelefono1.Text = dt.Rows(0).Item("telefono1") : txtTelefono2.Text = dt.Rows(0).Item("telefono2")
                    txtNit.Text = dt.Rows(0).Item("nic") : txtCNS.Text = dt.Rows(0).Item("cns")

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