Imports Entidades
Imports Negocios
Imports System.IO
Imports WindApp.My.Resources

Public Class UI_Configuracion : Inherits f_base

#Region "[atributosGlobales]"

    Private usuario As String
    Private clave As String
    Private opcion As Integer
    Private lista As List(Of tb_configuracion)
    Private index As Integer

#End Region

#Region "[constructor]"

    Public Sub New()
        MyBase.New("Formulario registro de certificados", "Realice la operacion necesaria...")
        InitializeComponent()
    End Sub

    Public Sub New(ByVal usuar As String, ByVal clav As String)
        MyBase.New("Formulario registro de certificados", "Realice la operacion necesaria...")
        InitializeComponent()
        usuario = usuar
        clave = clav
    End Sub

    Public Sub New(ByVal usuar As String, ByVal clav As String, ByVal opc As Integer)
        MyBase.New("Formulario registro de certificados", "Realice la operacion necesaria...")
        InitializeComponent()
        usuario = usuar : clave = clav
        opcion = opc
        Call getOpcion()
        Call limpiar()
    End Sub

    Public Sub New(ByVal usuar As String, ByVal clav As String, ByVal list As List(Of tb_configuracion), ByVal opc As Integer)
        MyBase.New("Formulario registro de certificados", "Realice la operacion necesaria...")
        InitializeComponent()
        usuario = usuar : clave = clav
        lista = list : opcion = opc
        Call getOpcion()
        Call inicio()
    End Sub

#End Region

#Region "[metodos]"

    Private Sub inicio()
        If lista.Count > 0 Then
            Using objCliente As New Negocios.ConfiguracionBL(usuario, clave)
                Dim dt As New DataTable
                Dim item(0) As tb_configuracion
                item.SetValue(lista.ElementAt(0), 0)

                Dim itemTabla As New tb_configuracion
                itemTabla = item.GetValue(0)
                dt = objCliente.getConfiguracionBL(itemTabla)

                If objCliente.existeError Then
                    DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objCliente.mensajesErrorSistema, objCliente.mensajesErrorUsuario),
                                                              rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf dt.Rows.Count > 0 Then
                    lblCodigo.Text = If(IsDBNull(dt.Rows(0).Item("codigo")), Nothing, dt.Rows(0).Item("codigo"))
                    txtCuis.Text = If(IsDBNull(dt.Rows(0).Item("cuis")), Nothing, dt.Rows(0).Item("cuis"))
                    txtUrlCert.Text = If(IsDBNull(dt.Rows(0).Item("urlcertificado")), Nothing, dt.Rows(0).Item("urlcertificado"))
                    txtPasswordCert.Text = If(IsDBNull(dt.Rows(0).Item("clave")), Nothing, dt.Rows(0).Item("clave"))

                    If Not IsDBNull(dt.Rows(0).Item("tambiente")) Then
                        Dim ambiente As String = dt.Rows(0).Item("tambiente")
                        If ambiente = "H" Then
                            rbHomologacion.Checked = True
                            rbProduccion.Checked = False
                        Else
                            rbProduccion.Checked = True
                            rbHomologacion.Checked = False
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
                Using objCliente As New Negocios.ConfiguracionBL(usuario, clave)
                    Dim dt As New DataTable
                    Dim item(0) As tb_configuracion
                    item.SetValue(lista.ElementAt(index + 1), 0)
                    Dim itemTabla As New tb_configuracion
                    itemTabla = item.GetValue(0)
                    dt = objCliente.getConfiguracionBL(itemTabla)

                    If objCliente.existeError Then
                        DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objCliente.mensajesErrorSistema, objCliente.mensajesErrorUsuario),
                                                                   rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ElseIf dt.Rows.Count > 0 Then
                        lblCodigo.Text = If(IsDBNull(dt.Rows(0).Item("codigo")), Nothing, dt.Rows(0).Item("codigo"))
                        txtCuis.Text = If(IsDBNull(dt.Rows(0).Item("cuis")), Nothing, dt.Rows(0).Item("cuis"))
                        txtUrlCert.Text = If(IsDBNull(dt.Rows(0).Item("urlcertificado")), Nothing, dt.Rows(0).Item("urlcertificado"))
                        txtPasswordCert.Text = If(IsDBNull(dt.Rows(0).Item("clave")), Nothing, dt.Rows(0).Item("clave"))

                        If Not IsDBNull(dt.Rows(0).Item("tambiente")) Then
                            Dim ambiente As String = dt.Rows(0).Item("tambiente")
                            If ambiente = "H" Then
                                rbHomologacion.Checked = True
                                rbProduccion.Checked = False
                            Else
                                rbProduccion.Checked = True
                                rbHomologacion.Checked = False
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
                Using objCliente As New Negocios.ConfiguracionBL(usuario, clave)
                    Dim dt As New DataTable
                    Dim item(0) As tb_configuracion
                    item.SetValue(lista.ElementAt(index - 1), 0)
                    Dim itemTabla As New tb_configuracion
                    itemTabla = item.GetValue(0)
                    dt = objCliente.getConfiguracionBL(itemTabla)
                    If objCliente.existeError Then
                        DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objCliente.mensajesErrorSistema, objCliente.mensajesErrorUsuario),
                                                                      rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ElseIf dt.Rows.Count > 0 Then
                        lblCodigo.Text = If(IsDBNull(dt.Rows(0).Item("codigo")), Nothing, dt.Rows(0).Item("codigo"))
                        txtCuis.Text = If(IsDBNull(dt.Rows(0).Item("cuis")), Nothing, dt.Rows(0).Item("cuis"))
                        txtUrlCert.Text = If(IsDBNull(dt.Rows(0).Item("urlcertificado")), Nothing, dt.Rows(0).Item("urlcertificado"))
                        txtPasswordCert.Text = If(IsDBNull(dt.Rows(0).Item("clave")), Nothing, dt.Rows(0).Item("clave"))

                        If Not IsDBNull(dt.Rows(0).Item("tambiente")) Then
                            Dim ambiente As String = dt.Rows(0).Item("tambiente")
                            If ambiente = "H" Then
                                rbHomologacion.Checked = True
                                rbProduccion.Checked = False
                            Else
                                rbProduccion.Checked = True
                                rbHomologacion.Checked = False
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
            Using objCliente As New Negocios.ConfiguracionBL(usuario, clave)
                Dim dt As New DataTable
                Dim item(0) As tb_configuracion
                item.SetValue(lista.Last, 0)
                Dim itemTabla As New tb_configuracion
                itemTabla = item.GetValue(0)
                dt = objCliente.getConfiguracionBL(itemTabla)
                If objCliente.existeError Then
                    DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objCliente.mensajesErrorSistema, objCliente.mensajesErrorUsuario),
                                                               rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf dt.Rows.Count > 0 Then
                    lblCodigo.Text = If(IsDBNull(dt.Rows(0).Item("codigo")), Nothing, dt.Rows(0).Item("codigo"))
                    txtCuis.Text = If(IsDBNull(dt.Rows(0).Item("cuis")), Nothing, dt.Rows(0).Item("cuis"))
                    txtUrlCert.Text = If(IsDBNull(dt.Rows(0).Item("urlcertificado")), Nothing, dt.Rows(0).Item("urlcertificado"))
                    txtPasswordCert.Text = If(IsDBNull(dt.Rows(0).Item("clave")), Nothing, dt.Rows(0).Item("clave"))

                    If Not IsDBNull(dt.Rows(0).Item("tambiente")) Then
                        Dim ambiente As String = dt.Rows(0).Item("tambiente")
                        If ambiente = "H" Then
                            rbHomologacion.Checked = True
                            rbProduccion.Checked = False
                        Else
                            rbProduccion.Checked = True
                            rbHomologacion.Checked = False
                        End If
                    End If

                    index = lista.Count - 1

                End If
            End Using
        End If
    End Sub


    Private Sub getOpcion()
        If opcion = 1 Then
            btnGuardar.Enabled = True
            btnModificar.Enabled = False
            btnEliminar.Enabled = False
        ElseIf opcion = 2 Then
            btnGuardar.Enabled = False
            btnModificar.Enabled = True
            btnEliminar.Enabled = False

        ElseIf opcion = 3 Then
            btnGuardar.Enabled = False
            btnModificar.Enabled = False
            btnEliminar.Enabled = True

            txtCuis.ReadOnly = False
            txtPasswordCert.ReadOnly = Not False
            txtUrlCert.ReadOnly = Not False
        Else
            btnGuardar.Enabled = False
            btnModificar.Enabled = False
            btnEliminar.Enabled = False
        End If
    End Sub

    Private Sub explorar()
        Try
            Using objexp As New OpenFileDialog
                objexp.InitialDirectory = "c:\"
                objexp.Filter = "txt files (*.txt)|*.pem|All files (*.*)|*.*"
                objexp.FilterIndex = 1
                objexp.RestoreDirectory = True
                If objexp.ShowDialog = Windows.Forms.DialogResult.OK Then
                    txtUrlCert.Text = objexp.FileName
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Function validarAlta() As Boolean
        Dim Result As Integer = 0
        dxErrorProvider.Clear()
        If String.IsNullOrEmpty(txtCuis.Text) Then
            dxErrorProvider.SetError(txtCuis, "El campo nombre es requerido")
            txtCuis.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtUrlCert.Text) Then
            dxErrorProvider.SetError(txtUrlCert, "El campo archivo del certificado es requerido")
            txtUrlCert.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub limpiar()
        txtCuis.Clear()
        txtPasswordCert.Clear()
        txtUrlCert.Clear()
    End Sub

    Private Sub alta()
        If validarAlta() Then
            Using oConfiguracion As New Negocios.ConfiguracionBL(usuario, clave)
                oConfiguracion.validarDatosTransaccion()
                If (oConfiguracion.datosValidosParametros) Then
                    Dim tAmbiente As String = "H"
                    If rbProduccion.Checked Then
                        tAmbiente = "P"
                    End If
                    Dim codigo As Integer = oConfiguracion.getCorrelativoBL()
                    Dim item As New tb_configuracion With {.codigo = codigo, .cuis = txtCuis.Text,
                                                           .urlcertificado = txtUrlCert.Text, .clave = txtPasswordCert.Text,
                                                           .tambiente = tAmbiente, .estado = "A"}
                    Call oConfiguracion.limpiarErrorBase()
                    Call oConfiguracion.abrirTransaccion()
                    Call oConfiguracion.altaBL(item)
                    If oConfiguracion.existeError Then
                        Call oConfiguracion.rechazarTransaccion()
                        MessageBox.Show(String.Format("{0} {1}", oConfiguracion.mensajesErrorSistema, oConfiguracion.mensajesErrorUsuario),
                                                                  rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        oConfiguracion.aceptarTransaccion()
                        MessageBox.Show(rcRecursos.msOK, rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Call limpiar()
                    End If
                End If
                Call oConfiguracion.finalizar()
            End Using
        End If
    End Sub

    Private Sub modificar()
        If validarAlta() Then
            Using oConfiguracion As New Negocios.ConfiguracionBL(usuario, clave)
                oConfiguracion.validarDatosTransaccion()
                If (oConfiguracion.datosValidosParametros) Then
                    Dim tAmbiente As String = "H"
                    If rbProduccion.Checked Then
                        tAmbiente = "P"
                    End If
                    Dim codigo As Integer = lblCodigo.Text
                    Dim item As New tb_configuracion With {.codigo = codigo, .cuis = txtCuis.Text,
                                                           .urlcertificado = txtUrlCert.Text, .clave = txtPasswordCert.Text,
                                                           .tambiente = tAmbiente, .estado = "H"}
                    Call oConfiguracion.limpiarErrorBase()
                    Call oConfiguracion.abrirTransaccion()
                    Call oConfiguracion.updateBL(item)
                    If oConfiguracion.existeError Then
                        Call oConfiguracion.rechazarTransaccion()
                        MessageBox.Show(String.Format("{0} {1}", oConfiguracion.mensajesErrorSistema, oConfiguracion.mensajesErrorUsuario),
                                                                 rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        oConfiguracion.aceptarTransaccion()
                        MessageBox.Show(rcRecursos.msOK, rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Call limpiar()
                    End If
                End If
                Call oConfiguracion.finalizar()
            End Using
        End If
    End Sub

    Private Sub baja()
        If validarAlta() Then
            Using oConfiguracion As New Negocios.ConfiguracionBL(usuario, clave)
                oConfiguracion.validarDatosTransaccion()
                If (oConfiguracion.datosValidosParametros) Then
                    Dim tAmbiente As String = "H"
                    If rbProduccion.Checked Then
                        tAmbiente = "P"
                    End If
                    Dim codigo As Integer = lblCodigo.Text
                    Dim item As New tb_configuracion With {.codigo = codigo, .cuis = txtCuis.Text,
                                                           .urlcertificado = txtUrlCert.Text, .clave = txtPasswordCert.Text,
                                                           .tambiente = tAmbiente, .estado = "I"}
                    Call oConfiguracion.limpiarErrorBase()
                    Call oConfiguracion.abrirTransaccion()
                    Call oConfiguracion.bajaLogicaBL(item)
                    If oConfiguracion.existeError Then
                        Call oConfiguracion.rechazarTransaccion()
                        MessageBox.Show(String.Format("{0} {1}", oConfiguracion.mensajesErrorSistema, oConfiguracion.mensajesErrorUsuario),
                                                                 rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        oConfiguracion.aceptarTransaccion()
                        MessageBox.Show(rcRecursos.msOK, rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Call limpiar()
                    End If
                End If
                Call oConfiguracion.finalizar()
            End Using
        End If
    End Sub

#End Region

#Region "[eventos]"

    Private Sub btnExplorar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExplorar.Click
        Call explorar()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Call alta()
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        Call modificar()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Call baja()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Call Close()
    End Sub

#End Region

End Class