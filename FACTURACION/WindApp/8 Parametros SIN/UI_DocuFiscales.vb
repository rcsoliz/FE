Imports Entidades
Imports Negocios
Imports WindApp.My.Resources
Public Class UI_DocuFiscales : Inherits f_base

#Region "[atributosGlobales]"

    Private usuario As String
    Private clave As String
    Private lista As List(Of tb_docuFiscales)
    Private opcion As Integer
    Private index As Integer

#End Region

#Region "[constructor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String)
        MyBase.New("TIPOS DE DOCUMENTOS FISCALES", "Realice la operación requerida...")
        InitializeComponent()
        usuario = usuar
        clave = clav
        opcion = 1
        btnOpciones.Text = "Guardar"
        Call getCorrelativo()
    End Sub

    Public Sub New(ByVal usuar As String, ByVal clav As String, ByVal list As List(Of tb_docuFiscales), ByVal opc As Integer)
        MyBase.New("TIPOS DE DOCUMENTOS FISCALES", "Realice la operación requerida")
        InitializeComponent()
        lista = list
        usuario = usuar
        clave = clav
        opcion = opc
        Call getOpcion()
        Call inicio()
    End Sub

#End Region

#Region "[metodos]"

    Private Sub getCorrelativo()
        Using oParametroSin As New Negocios.DocuFiscalesSinBL(usuario, clave)
            Dim correlativo As Integer
            correlativo = oParametroSin.getCorrelativoBL()
            If oParametroSin.existeError Then
                MessageBox.Show(String.Format("{0} {1}", oParametroSin.mensajesErrorSistema, oParametroSin.mensajesErrorUsuario),
                                rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                txtCodigo.Text = correlativo
            End If
            Call oParametroSin.finalizar()
        End Using
    End Sub

    Private Sub limpiar()
        libControl.limpiarTexto(Me)
        If opcion = 1 Then
            Call getCorrelativo()
        End If
    End Sub

    Private Sub getOpcion()
        If opcion = 1 Then
            btnOpciones.Enabled = True
            txtCodigo.ReadOnly = Not False
            btnOpciones.Text = "Guardar"
            btnInicio.Enabled = False : btnAnterior.Enabled = False : btnSiguiente.Enabled = False : btnFin.Enabled = False
        ElseIf opcion = 2 Then
            btnOpciones.Enabled = True
            btnOpciones.Text = "Guardar"
        ElseIf opcion = 3 Then
            btnOpciones.Enabled = True
            txtCodigo.ReadOnly = Not False
            txtDescripcion.ReadOnly = Not False
            btnOpciones.Text = "Eliminar"
        Else
            btnOpciones.Enabled = False
            btnInicio.Enabled = False : btnAnterior.Enabled = False : btnSiguiente.Enabled = False : btnFin.Enabled = False
            txtCodigo.ReadOnly = Not False
            txtDescripcion.ReadOnly = Not False
            btnOpciones.Text = "N.N."
        End If
    End Sub

    Private Function validarAlta() As Boolean
        Dim Result As Integer = 0
        ErrorProvider1.Clear()
        If Not Integer.TryParse(txtCodigo.Text, Result) Then
            ErrorProvider1.SetError(txtCodigo, "El Código es requerido")
            txtCodigo.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtDescripcion.Text) Then
            ErrorProvider1.SetError(txtDescripcion, "El campo Descripción es requerido")
            txtDescripcion.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub abmSin()
        Using oParametroSin As New Negocios.DocuFiscalesSinBL(usuario, clave)
            If validarAlta() Then
                Dim item As New tb_docuFiscales With {.codigo = txtCodigo.Text, .descripcion = txtDescripcion.Text}
                oParametroSin.validarDatosTransaccion()
                If (oParametroSin.datosValidosParametros) Then
                    Call oParametroSin.limpiarErrorBase()
                    Call oParametroSin.abrirTransaccion()
                    If opcion = 1 Then
                        Call oParametroSin.altaBL(item)
                    ElseIf opcion = 2 Then
                        Call oParametroSin.modificarBL(item)
                    ElseIf opcion = 3 Then
                        Call oParametroSin.bajaBL(item)
                    Else
                        Return
                    End If
                    If oParametroSin.existeError Then
                        Call oParametroSin.rechazarTransaccion()
                        MessageBox.Show(String.Format("{0} {1}", oParametroSin.mensajesErrorSistema, oParametroSin.mensajesErrorUsuario),
                                                                   rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        oParametroSin.aceptarTransaccion()
                        MessageBox.Show(rcRecursos.msOK, rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Call limpiar()
                    End If
                End If
            End If
            Call oParametroSin.finalizar()
        End Using
    End Sub

    Private Sub inicio()
        If lista.Count > 0 Then
            Using oParametroSin As New Negocios.DocuFiscalesSinBL(usuario, clave)
                Dim dt As New DataTable
                Dim item(0) As tb_docuFiscales
                item.SetValue(lista.ElementAt(0), 0)

                Dim itemTabla As New tb_docuFiscales
                itemTabla = item.GetValue(0)
                dt = oParametroSin.listarBL(itemTabla)
                If oParametroSin.existeError Then
                    MessageBox.Show(String.Format("{0} {1}", oParametroSin.mensajesErrorSistema, oParametroSin.mensajesErrorUsuario),
                                                                  "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf dt.Rows.Count > 0 Then
                    txtCodigo.Text = IIf(IsDBNull(dt.Rows(0).Item("codigo")), Nothing, dt.Rows(0).Item("codigo"))
                    txtDescripcion.Text = IIf(IsDBNull(dt.Rows(0).Item("descripcion")), Nothing, dt.Rows(0).Item("descripcion"))
                    index = 0
                    lblRegistros.Text = "1 de " & lista.Count - 1
                End If
                Call oParametroSin.finalizar()
            End Using
        End If
    End Sub

    Private Sub siguente()
        If lista.Count - 1 > 0 Then
            If index <> lista.Count - 1 Then
                Using oParametroSin As New Negocios.DocuFiscalesSinBL(usuario, clave)
                    Dim dt As New DataTable
                    Dim item(0) As tb_docuFiscales
                    item.SetValue(lista.ElementAt(index + 1), 0)

                    Dim itemTabla As New tb_docuFiscales
                    itemTabla = item.GetValue(0)

                    dt = oParametroSin.listarBL(itemTabla)

                    If oParametroSin.existeError Then
                        MessageBox.Show(String.Format("{0} {1}", oParametroSin.mensajesErrorSistema, oParametroSin.mensajesErrorUsuario),
                                                                      "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ElseIf dt.Rows.Count > 0 Then
                        txtCodigo.Text = IIf(IsDBNull(dt.Rows(0).Item("codigo")), Nothing, dt.Rows(0).Item("codigo"))
                        txtDescripcion.Text = IIf(IsDBNull(dt.Rows(0).Item("nombre")), Nothing, dt.Rows(0).Item("nombre"))

                        If index <> lista.Count - 1 Then
                            index = index + 1
                        End If
                        lblRegistros.Text = index & "de " & lista.Count - 1
                    End If
                    Call oParametroSin.finalizar()
                End Using
            End If
        End If
    End Sub

    Private Sub anteriror()
        If lista.Count - 1 > 0 Then
            If index <> 0 Then
                Using oParametroSin As New Negocios.DocuFiscalesSinBL(usuario, clave)
                    Dim dt As New DataTable
                    Dim item(0) As tb_docuFiscales
                    item.SetValue(lista.ElementAt(index - 1), 0)

                    Dim itemTabla As New tb_docuFiscales
                    itemTabla = item.GetValue(0)

                    dt = oParametroSin.listarBL(itemTabla)
                    If oParametroSin.existeError Then
                        MessageBox.Show(String.Format("{0} {1}", oParametroSin.mensajesErrorSistema, oParametroSin.mensajesErrorUsuario),
                                                                      "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ElseIf dt.Rows.Count > 0 Then
                        txtCodigo.Text = IIf(IsDBNull(dt.Rows(0).Item("codigo")), Nothing, dt.Rows(0).Item("codigo"))
                        txtDescripcion.Text = IIf(IsDBNull(dt.Rows(0).Item("descripcion")), Nothing, dt.Rows(0).Item("descripcion"))
                        If index = 0 Then
                            index = 0
                        Else
                            index = index - 1
                        End If
                        lblRegistros.Text = index & "de " & lista.Count - 1
                    End If
                    Call oParametroSin.finalizar()
                End Using
            End If
        End If
    End Sub

    Private Sub final()
        If lista.Count > 0 Then
            Using oParametroSin As New Negocios.DocuFiscalesSinBL(usuario, clave)
                Dim dt As New DataTable
                Dim item(0) As tb_docuFiscales
                item.SetValue(lista.Last, 0)

                Dim itemTabla As New tb_docuFiscales
                itemTabla = item.GetValue(0)

                dt = oParametroSin.listarBL(itemTabla)
                If oParametroSin.existeError Then
                    MessageBox.Show(String.Format("{0} {1}", oParametroSin.mensajesErrorSistema, oParametroSin.mensajesErrorUsuario),
                                                                  "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf dt.Rows.Count > 0 Then
                    txtCodigo.Text = IIf(IsDBNull(dt.Rows(0).Item("codigo")), Nothing, dt.Rows(0).Item("codigo"))
                    txtDescripcion.Text = IIf(IsDBNull(dt.Rows(0).Item("descripcion")), Nothing, dt.Rows(0).Item("descripcion"))
                    index = lista.Count - 1
                End If
                lblRegistros.Text = index & "de " & lista.Count - 1
                Call oParametroSin.finalizar()
            End Using
        End If
    End Sub

#End Region

#Region "[eventos]"

    Private Sub btnOpciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpciones.Click
        Call abmSin()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Call Close()
    End Sub

    Private Sub btnInicio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInicio.Click
        Call inicio()
    End Sub

    Private Sub btnAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnterior.Click
        Call anteriror()
    End Sub

    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        Call siguente()
    End Sub

    Private Sub btnFin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFin.Click
        Call final()
    End Sub

#End Region

End Class