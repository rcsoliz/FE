Imports ENTIDADES
Imports System
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data
Public Class UI_CobMenu11 : Inherits f_base

#Region "[atributosGlobales]"

    Private opcion As Integer
    Private usuario As String
    Private clave As String
    Private lista As List(Of tb_cobmenu11)
    Private index As Integer

#End Region

#Region "[constructor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String, ByVal opc As Integer)
        MyBase.New("REGISTROS SUB-MENUS", "Realice la operación requerida...")
        InitializeComponent()
        usuario = usuar
        clave = clav
        opcion = opc
        Call getOpcion()
        Call getModulo()
        If opcion = 1 Then
            Call getCorrelativo()
        End If
        lkModulo.Focus()
    End Sub

    Public Sub New(ByVal usuar As String, ByVal clav As String, ByVal list As List(Of tb_cobmenu11), ByVal opc As Integer)
        MyBase.New("REGISTROS SUB-MENUS", "Realice la operación requerida...")
        InitializeComponent()
        lista = list
        usuario = usuar
        clave = clav
        opcion = opc
        Call getOpcion()
        Call getModulo()
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
            txtCodSModulo.ReadOnly = Not False
        ElseIf opcion = 2 Then
            btnGrabar.Enabled = False
            btnModificar.Enabled = True
            btnEliminar.Enabled = False
            txtCodSModulo.ReadOnly = Not False

        ElseIf opcion = 3 Then
            btnGrabar.Enabled = False
            btnModificar.Enabled = False
            btnEliminar.Enabled = True

            txtCodSModulo.ReadOnly = Not False
            txtDescSubMod.ReadOnly = Not False
            txtSecuencia.ReadOnly = Not False
            lkModulo.ReadOnly = Not False
            RadioGroup1.Enabled = False
        Else
            btnGrabar.Enabled = False
            btnModificar.Enabled = False
            btnEliminar.Enabled = False
        End If
    End Sub

    Private Sub getModulo()
        Using objModulo As New Negocios.CobModulBL(usuario, clave)
            Dim dt As New DataTable
            dt = objModulo.getCobModulComboBL
            If objModulo.existeError Then
                DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objModulo.mensajesErrorSistema, objModulo.mensajeErrorUsuarios),
                                                 "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                lkModulo.Properties.DataSource = dt
                lkModulo.Properties.ValueMember = "modmodul"
                lkModulo.Properties.DisplayMember = "moddesc"
                lkModulo.EditValue = dt.Rows(0).Item("modmodul")
            End If
        End Using
    End Sub

    Private Function validarAlta() As Boolean
        Dim Result As Integer = 0
        dxErrorProvider.ClearErrors()
        If Not Integer.TryParse(txtCodSModulo.EditValue, Result) Then
            dxErrorProvider.SetError(txtCodSModulo, "El código del Sub-Modulo es requerido")
            txtCodSModulo.Focus()
            Return False
        ElseIf Not Integer.TryParse(lkModulo.EditValue, Result) Then
            dxErrorProvider.SetError(lkModulo, "El campo modulo es requerido")
            lkModulo.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtDescSubMod.Text) Then
            dxErrorProvider.SetError(txtDescSubMod, "El campo descripcion es requerido")
            txtDescSubMod.Focus()
            Return False
        ElseIf Not Integer.TryParse(txtSecuencia.Text, Result) Then
            dxErrorProvider.SetError(txtSecuencia, "El camopo secuencia es requerido")
            txtSecuencia.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub getCorrelativo()
        Using objSubModulo As New Negocios.CobMenu11BL(usuario, clave)
            Dim correlativo As Integer
            correlativo = objSubModulo.getMaxCobMenu11BL()
            If objSubModulo.existeError Then
                DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objSubModulo.mensajeErrorSistema, objSubModulo.mensajeErrorUsuarios),
                                                                 "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                txtCodSModulo.Text = correlativo
            End If
        End Using
    End Sub

    Private Sub limpiar()
        txtCodSModulo.Text = String.Empty
        txtDescSubMod.Text = String.Empty
        txtSecuencia.Text = String.Empty
        If opcion = 1 Then
            getCorrelativo()
        End If
    End Sub

    Private Sub alta()
        Using objModulo As New Negocios.CobMenu11BL(usuario, clave)
            If validarAlta() Then
                Dim vActivo As String = String.Empty
                If RadioGroup1.Properties.Items(RadioGroup1.SelectedIndex).Description = "Activos" Then
                    vActivo = "S"
                Else
                    vActivo = "N"
                End If
                'codmenu1 As Integer, me1subme As String , me1modul As Integer, me1ofici As String, me1secue As Int16
                Dim item As New tb_cobmenu11 With {.codmenu1 = txtCodSModulo.Text, .me1subme = txtDescSubMod.Text,
                                                  .me1modul = lkModulo.EditValue, .me1secue = txtSecuencia.Text,
                                                  .me1ofici = vActivo}
                objModulo.validarDatosTransaccion()
                If (objModulo.DatosValidosEnNegocios) Then
                    Call objModulo.LimpiarErrorBase()
                    Call objModulo.AbrirTransaccion()
                    Call objModulo.altaCobMenu11BL(item)
                    If objModulo.existeError Then
                        Call objModulo.RechazarTransaccion()
                        DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objModulo.mensajeErrorSistema, objModulo.mensajeErrorUsuarios),
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
        Using objModulo As New Negocios.CobMenu11BL(usuario, clave)
            If validarAlta() Then
                Dim vActivo As String = String.Empty
                'If RadioGroup1.Properties.Items(RadioGroup1.SelectedIndex).Description = "Activos" Then
                '    vActivo = "S"
                'Else
                vActivo = "N"
                'End If
                'codmenu1 As Integer, me1subme As String , me1modul As Integer, me1ofici As String, me1secue As Int16
                Dim item As New tb_cobmenu11 With {.codmenu1 = txtCodSModulo.Text, .me1subme = txtDescSubMod.Text,
                                                  .me1modul = lkModulo.EditValue, .me1secue = txtSecuencia.Text,
                                                  .me1ofici = vActivo}
                objModulo.validarDatosTransaccion()
                If (objModulo.DatosValidosEnNegocios) Then
                    Call objModulo.LimpiarErrorBase()
                    Call objModulo.AbrirTransaccion()
                    Call objModulo.bajaCobMenu11BL(item)
                    If objModulo.existeError Then
                        Call objModulo.RechazarTransaccion()
                        DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objModulo.mensajeErrorSistema, objModulo.mensajeErrorUsuarios),
                                                                   "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        objModulo.AceptarTransaccion()
                        DevExpress.XtraEditors.XtraMessageBox.Show("Sub-Modulo eliminado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Call limpiar()
                    End If
                End If
            End If
            objModulo.finalizar()
        End Using
    End Sub

    Private Sub modificar()
        Using objModulo As New Negocios.CobMenu11BL(usuario, clave)
            If validarAlta() Then
                Dim vActivo As String = String.Empty
                If RadioGroup1.Properties.Items(RadioGroup1.SelectedIndex).Description = "Activos" Then
                    vActivo = "S"
                Else
                    vActivo = "N"
                End If
                'codmenu1 As Integer, me1subme As String , me1modul As Integer, me1ofici As String, me1secue As Int16
                Dim item As New tb_cobmenu11 With {.codmenu1 = txtCodSModulo.Text, .me1subme = txtDescSubMod.Text,
                                                                .me1modul = lkModulo.EditValue, .me1secue = txtSecuencia.Text,
                                                                .me1ofici = vActivo}
                objModulo.validarDatosTransaccion()
                If (objModulo.DatosValidosEnNegocios) Then
                    Call objModulo.LimpiarErrorBase()
                    Call objModulo.AbrirTransaccion()
                    Call objModulo.modificarCobMenu11BL(item)
                    If objModulo.existeError Then
                        Call objModulo.RechazarTransaccion()
                        DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objModulo.mensajeErrorSistema, objModulo.mensajeErrorUsuarios), "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        objModulo.AceptarTransaccion()
                        DevExpress.XtraEditors.XtraMessageBox.Show("Sub-Modulo actualizado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Call limpiar()
                    End If
                End If
            End If
            objModulo.finalizar()
        End Using
    End Sub

    Private Sub inicio()
        If lista.Count > 0 Then
            Using objSModulo As New Negocios.CobMenu11BL(usuario, clave)
                Dim dt As New DataTable
                Dim item(0) As tb_cobmenu11
                item.SetValue(lista.ElementAt(0), 0)

                Dim itemTabla As New tb_cobmenu11
                itemTabla = item.GetValue(0)
                dt = objSModulo.getUnCobMenu11BL(itemTabla)

                If objSModulo.existeError Then
                    DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objSModulo.mensajeErrorSistema, objSModulo.mensajeErrorUsuarios),
                                                                  "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf dt.Rows.Count > 0 Then 'codmenu1 As Integer, me1subme As String , me1modul As Integer, me1ofici As String, me1secue As Int16
                    txtCodSModulo.Text = dt.Rows(0).Item("codmenu1")
                    txtDescSubMod.Text = dt.Rows(0).Item("me1subme")
                    lkModulo.EditValue = dt.Rows(0).Item("me1modul")
                    txtSecuencia.Text = dt.Rows(0).Item("me1secue")

                    If dt.Rows(0).Item("me1ofici") = "S" Then

                    Else
                        RadioGroup1.Properties.Items(RadioGroup1.SelectedIndex).Value = Not True
                    End If
                    index = 0
                End If
                objSModulo.finalizar()
            End Using
        End If
    End Sub

    Private Sub siguente()
        If lista.Count - 1 > 0 Then
            If index <> lista.Count - 1 Then
                Using objSModulo As New Negocios.CobMenu11BL(usuario, clave)
                    Dim dt As New DataTable
                    Dim item(0) As tb_cobmenu11
                    item.SetValue(lista.ElementAt(index + 1), 0)
                    Dim itemTabla As New tb_cobmenu11
                    itemTabla = item.GetValue(0)
                    dt = objSModulo.getUnCobMenu11BL(itemTabla)

                    If objSModulo.existeError Then
                        DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objSModulo.mensajeErrorSistema, objSModulo.mensajeErrorUsuarios),
                                                                      "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ElseIf dt.Rows.Count > 0 Then 'codmenu1 As Integer, me1subme As String , me1modul As Integer, me1ofici As String, me1secue As Int16
                        txtCodSModulo.Text = dt.Rows(0).Item("codmenu1")
                        txtDescSubMod.Text = dt.Rows(0).Item("me1subme")
                        lkModulo.EditValue = dt.Rows(0).Item("me1modul")
                        txtSecuencia.Text = dt.Rows(0).Item("me1secue")
                        If dt.Rows(0).Item("me1ofici") = "S" Then

                        Else
                            RadioGroup1.Properties.Items(RadioGroup1.SelectedIndex).Value = Not True
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
                Using objSModulo As New Negocios.CobMenu11BL(usuario, clave)
                    Dim dt As New DataTable
                    Dim item(0) As tb_cobmenu11
                    item.SetValue(lista.ElementAt(index - 1), 0)
                    Dim itemTabla As New tb_cobmenu11
                    itemTabla = item.GetValue(0)
                    dt = objSModulo.getUnCobMenu11BL(itemTabla)
                    If objSModulo.existeError Then
                        DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objSModulo.mensajeErrorSistema, objSModulo.mensajeErrorUsuarios),
                                                                      "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ElseIf dt.Rows.Count > 0 Then 'codmenu1 As Integer, me1subme As String , me1modul As Integer, me1ofici As String, me1secue As Int16
                        txtCodSModulo.Text = dt.Rows(0).Item("codmenu1")
                        txtDescSubMod.Text = dt.Rows(0).Item("me1subme")
                        lkModulo.EditValue = dt.Rows(0).Item("me1modul")
                        txtSecuencia.Text = dt.Rows(0).Item("me1secue")
                        If dt.Rows(0).Item("me1ofici") = "S" Then

                        Else
                            RadioGroup1.Properties.Items(RadioGroup1.SelectedIndex).Value = Not True
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
            Using objSModulo As New Negocios.CobMenu11BL(usuario, clave)
                Dim dt As New DataTable
                Dim item(0) As tb_cobmenu11
                item.SetValue(lista.Last, 0)
                Dim itemTabla As New tb_cobmenu11
                itemTabla = item.GetValue(0)
                dt = objSModulo.getUnCobMenu11BL(itemTabla)
                If objSModulo.existeError Then
                    DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objSModulo.mensajeErrorSistema, objSModulo.mensajeErrorUsuarios),
                                                                  "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf dt.Rows.Count > 0 Then  ' 'codmenu1 As Integer, me1subme As String , me1modul As Integer, me1ofici As String, me1secue As Int16
                    txtCodSModulo.Text = dt.Rows(0).Item("codmenu1")
                    txtDescSubMod.Text = dt.Rows(0).Item("me1subme")
                    lkModulo.EditValue = dt.Rows(0).Item("me1modul")
                    txtSecuencia.Text = dt.Rows(0).Item("me1secue")

                    If dt.Rows(0).Item("me1ofici") = "S" Then

                    Else
                        RadioGroup1.Properties.Items(RadioGroup1.SelectedIndex).Value = Not True
                    End If

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