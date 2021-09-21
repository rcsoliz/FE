Imports ENTIDADES
Imports System
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data

Public Class UI_Modulos : Inherits f_base

#Region "[atributosGlobales]"

    Private opcion As Integer
    Private usuario As String
    Private clave As String
    Private lista As List(Of tb_codmodul)
    Private index As Integer

#End Region

#Region "[constructor]"
    Public Sub New(ByVal usuar As String, ByVal clav As String, ByVal opc As Integer)
        MyBase.New("FORMULARIO MODULOS", "Realice la operación requerida...")
        InitializeComponent()
        usuario = usuar
        clave = clav
        opcion = opc
        Call getOpcion()
        If opcion = 1 Then
            Call getCorrelativo()
        End If
    End Sub
    Public Sub New(ByVal usuar As String, ByVal clav As String, ByVal list As List(Of tb_codmodul), ByVal opc As Integer)
        MyBase.New("FORMULARIO MODULOS ", "Realice la operación requerida...")
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
            btnGrabar.Enabled = True
            btnModificar.Enabled = False
            btnEliminar.Enabled = False
            txtCodModulo.ReadOnly = Not False

        ElseIf opcion = 2 Then
            btnGrabar.Enabled = False
            btnModificar.Enabled = True
            btnEliminar.Enabled = False
            txtCodModulo.ReadOnly = Not False

        ElseIf opcion = 3 Then
            btnGrabar.Enabled = False
            btnModificar.Enabled = False
            btnEliminar.Enabled = True

            txtCodModulo.ReadOnly = Not False
            txtDescModulo.ReadOnly = Not False
            txtSecuModulo.ReadOnly = Not False
            RadioGroup1.Enabled = False
        Else
            btnGrabar.Enabled = False
            btnModificar.Enabled = False
            btnEliminar.Enabled = False
        End If
    End Sub

    Private Function validarAlta() As Boolean
        Dim Result As Integer = 0
        dxErrorProvider.ClearErrors()
        If Not Integer.TryParse(txtCodModulo.Text, Result) Then
            dxErrorProvider.SetError(txtCodModulo, "El código del Modulo es requerido")
            txtCodModulo.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtDescModulo.Text) Then
            dxErrorProvider.SetError(txtDescModulo, "El campo descripcion es requerido")
            txtDescModulo.Focus()
            Return False
        ElseIf Not Integer.TryParse(txtSecuModulo.Text, Result) Then
            dxErrorProvider.SetError(txtSecuModulo, "El campo secuencia es requerido")
            txtSecuModulo.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub getCorrelativo()
        Using objModulo As New NEGOCIOS.CobModulBL(usuario, clave)
            Dim correlativo As Integer
            correlativo = objModulo.getMaxCobModulBL()
            If objModulo.existeError Then
                DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objModulo.mensajesErrorSistema, objModulo.mensajeErrorUsuarios),
                                                                 "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                txtCodModulo.Text = correlativo
            End If
        End Using
    End Sub

    Private Sub limpiar()
        txtCodModulo.Text = String.Empty
        txtDescModulo.Text = String.Empty
        txtSecuModulo.Text = String.Empty
        If opcion = 1 Then
            getCorrelativo()
        End If
    End Sub

    Private Sub alta()
        Using objModulo As New NEGOCIOS.CobModulBL(usuario, clave)
            If validarAlta() Then
                Dim vActivo As String = String.Empty
                If RadioGroup1.Properties.Items(RadioGroup1.SelectedIndex).Description = "Activos" Then
                    vActivo = "SI"
                Else
                    vActivo = "NO"
                End If

                Dim item As New tb_codmodul With {.modmodul = txtCodModulo.Text, .moddesc = txtDescModulo.Text,
                                                  .modinsta = vActivo, .modofici = "S", .modsecue = txtSecuModulo.Text}
                objModulo.validarDatosTransaccion()
                If (objModulo.DatosValidosEnNegocios) Then
                    Call objModulo.LimpiarErrorBase()
                    Call objModulo.AbrirTransaccion()
                    Call objModulo.altaCobModuloBL(item)
                    If objModulo.existeError Then
                        Call objModulo.RechazarTransaccion()
                        DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objModulo.mensajesErrorSistema, objModulo.mensajeErrorUsuarios),
                                                                   "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        objModulo.AceptarTransaccion()
                        DevExpress.XtraEditors.XtraMessageBox.Show("Transacción realizada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Call limpiar()
                    End If
                End If
            End If
            objModulo.finalizar()
        End Using
    End Sub

    Private Sub baja()
        Using objModulo As New NEGOCIOS.CobModulBL(usuario, clave)
            If validarAlta() Then
                Dim vActivo As String = String.Empty
                vActivo = "NO"
                Dim item As New tb_codmodul With {.modmodul = txtCodModulo.Text, .moddesc = txtDescModulo.Text,
                                                  .modinsta = vActivo, .modofici = "S", .modsecue = txtSecuModulo.Text}
                objModulo.validarDatosTransaccion()
                If (objModulo.DatosValidosEnNegocios) Then
                    Call objModulo.LimpiarErrorBase()
                    Call objModulo.AbrirTransaccion()
                    Call objModulo.bajaCobModulBL(item)
                    If objModulo.existeError Then
                        Call objModulo.RechazarTransaccion()
                        DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objModulo.mensajesErrorSistema, objModulo.mensajeErrorUsuarios),
                                                                   "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        objModulo.AceptarTransaccion()
                        DevExpress.XtraEditors.XtraMessageBox.Show("Modulo eliminado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Call limpiar()
                    End If
                End If
            End If
            objModulo.finalizar()
        End Using
    End Sub

    Private Sub modificar()
        Using objModulo As New NEGOCIOS.CobModulBL(usuario, clave)
            If validarAlta() Then
                Dim vActivo As String = String.Empty
                If RadioGroup1.Properties.Items(RadioGroup1.SelectedIndex).Description = "Activos" Then
                    vActivo = "SI"
                Else
                    vActivo = "NO"
                End If
                Dim item As New tb_codmodul With {.modmodul = txtCodModulo.Text, .moddesc = txtDescModulo.Text,
                                                  .modinsta = vActivo, .modofici = "S", .modsecue = txtSecuModulo.Text}
                objModulo.validarDatosTransaccion()
                If (objModulo.DatosValidosEnNegocios) Then
                    Call objModulo.LimpiarErrorBase()
                    Call objModulo.AbrirTransaccion()
                    Call objModulo.modificarCobModulBL(item)
                    If objModulo.existeError Then
                        Call objModulo.RechazarTransaccion()
                        DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objModulo.mensajesErrorSistema, objModulo.mensajeErrorUsuarios),
                                                                   "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        objModulo.AceptarTransaccion()
                        DevExpress.XtraEditors.XtraMessageBox.Show("Modulo actualizado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Call limpiar()
                    End If
                End If
            End If
            objModulo.finalizar()
        End Using
    End Sub


    Private Sub inicio()
        If lista.Count > 0 Then
            Using objModulo As New NEGOCIOS.CobModulBL(usuario, clave)
                Dim dt As New DataTable
                Dim item(0) As tb_codmodul
                item.SetValue(lista.ElementAt(0), 0)

                Dim itemTabla As New tb_codmodul
                itemTabla = item.GetValue(0)
                dt = objModulo.getUnCobModuloBL(itemTabla)

                If objModulo.existeError Then
                    DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objModulo.mensajesErrorSistema, objModulo.mensajeErrorUsuarios),
                                                                  "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf dt.Rows.Count > 0 Then
                    txtCodModulo.Text = dt.Rows(0).Item("modmodul")
                    txtDescModulo.Text = dt.Rows(0).Item("moddesc")
                    txtSecuModulo.Text = dt.Rows(0).Item("modsecue")
                    index = 0
                    If dt.Rows(0).Item("modinsta") = "SI" Then
                        '  RadioGroup1.Properties.Items(RadioGroup1.SelectedIndex).Value = True
                    Else
                        RadioGroup1.Properties.Items(RadioGroup1.SelectedIndex).Value = Not True ' "Inactivos"
                    End If
                End If
                objModulo.finalizar()
            End Using
        End If
    End Sub

    Private Sub siguente()
        If lista.Count - 1 > 0 Then
            If index <> lista.Count - 1 Then
                Using objModulo As New NEGOCIOS.CobModulBL(usuario, clave)
                    Dim dt As New DataTable
                    Dim item(0) As tb_codmodul
                    item.SetValue(lista.ElementAt(index + 1), 0)
                    Dim itemTabla As New tb_codmodul
                    itemTabla = item.GetValue(0)
                    dt = objModulo.getUnCobModuloBL(itemTabla)

                    If objModulo.existeError Then
                        DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objModulo.mensajesErrorSistema, objModulo.mensajeErrorUsuarios),
                                                                      "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ElseIf dt.Rows.Count > 0 Then
                        txtCodModulo.Text = dt.Rows(0).Item("modmodul")
                        txtDescModulo.Text = dt.Rows(0).Item("moddesc")
                        txtSecuModulo.Text = dt.Rows(0).Item("modsecue")
                        If index <> lista.Count - 1 Then
                            index = index + 1
                        End If

                        If dt.Rows(0).Item("modinsta") = "SI" Then
                        Else
                            RadioGroup1.Properties.Items(RadioGroup1.SelectedIndex).Value = Not True ' "Inactivos"
                        End If
                    End If
                End Using
            End If
        End If
    End Sub

    Private Sub anteriror()
        If lista.Count - 1 > 0 Then
            If index <> 0 Then
                Using objModulo As New NEGOCIOS.CobModulBL(usuario, clave)
                    Dim dt As New DataTable
                    Dim item(0) As tb_codmodul
                    item.SetValue(lista.ElementAt(index - 1), 0)
                    Dim itemTabla As New tb_codmodul
                    itemTabla = item.GetValue(0)
                    dt = objModulo.getUnCobModuloBL(itemTabla)
                    If objModulo.existeError Then
                        DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objModulo.mensajesErrorSistema, objModulo.mensajeErrorUsuarios),
                                                                      "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ElseIf dt.Rows.Count > 0 Then
                        txtCodModulo.Text = dt.Rows(0).Item("modmodul")
                        txtDescModulo.Text = dt.Rows(0).Item("moddesc")
                        txtSecuModulo.Text = dt.Rows(0).Item("modsecue")
                        If index = 0 Then
                            index = 0
                        Else
                            index = index - 1
                        End If
                        If dt.Rows(0).Item("modinsta") = "SI" Then
                        Else
                            RadioGroup1.Properties.Items(RadioGroup1.SelectedIndex).Value = Not True ' "Inactivos"
                        End If
                    End If
                End Using
            End If
        End If
    End Sub

    Private Sub final()
        If lista.Count > 0 Then
            Using objModulo As New NEGOCIOS.CobModulBL(usuario, clave)
                Dim dt As New DataTable
                Dim item(0) As tb_codmodul
                item.SetValue(lista.Last, 0)
                Dim itemTabla As New tb_codmodul
                itemTabla = item.GetValue(0)
                dt = objModulo.getUnCobModuloBL(itemTabla)
                If objModulo.existeError Then
                    DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objModulo.mensajesErrorSistema, objModulo.mensajeErrorUsuarios),
                                                                  "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf dt.Rows.Count > 0 Then
                    txtCodModulo.Text = dt.Rows(0).Item("modmodul")
                    txtDescModulo.Text = dt.Rows(0).Item("moddesc")
                    txtSecuModulo.Text = dt.Rows(0).Item("modsecue")
                    index = lista.Count - 1
                    If dt.Rows(0).Item("modinsta") = "SI" Then
                    Else
                        RadioGroup1.Properties.Items(RadioGroup1.SelectedIndex).Value = Not True ' "Inactivos"
                    End If
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