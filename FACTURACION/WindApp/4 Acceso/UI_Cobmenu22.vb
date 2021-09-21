Imports ENTIDADES
Imports System
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data
Public Class UI_Cobmenu22 : Inherits f_base

#Region "[atributosGlobales]"

    Private opcion As Integer
    Private usuario As String
    Private clave As String
    Private lista As List(Of tb_cobmenu22)
    Private index As Integer

#End Region

#Region "[constructor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String, ByVal iEvento As tb_cobmenu22, ByVal opc As Integer)
        MyBase.New("REGISTROS EVENTOS", "Realice la operación requerida...")
        InitializeComponent()
        usuario = usuar
        clave = clav
        opcion = opc
        Call getOpcion()
        Call getModulo(iEvento) : Call getSubMenu(iEvento) : Call getPrograma(iEvento)
        If opcion = 1 Then
            Call getCorrelativo()
        End If
        lkModulo.Focus()
    End Sub

    Public Sub New(ByVal usuar As String, ByVal clav As String, ByVal list As List(Of tb_cobmenu22), ByVal iEvento As tb_cobmenu22, ByVal opc As Integer)
        MyBase.New("REGISTROS EVENTOS", "Realice la operación requerida...")
        InitializeComponent()
        lista = list
        usuario = usuar
        clave = clav
        opcion = opc
        Call getOpcion()
        Call getModulo(iEvento) : Call getSubMenu(iEvento) : Call getPrograma(iEvento)
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
            txtCodEvento.ReadOnly = Not False
        ElseIf opcion = 2 Then
            btnGrabar.Enabled = False
            btnModificar.Enabled = True
            btnEliminar.Enabled = False
            txtCodEvento.ReadOnly = Not False

        ElseIf opcion = 3 Then
            btnGrabar.Enabled = False
            btnModificar.Enabled = False
            btnEliminar.Enabled = True

            txtCodEvento.ReadOnly = Not False
            txtDescEvento.ReadOnly = Not False
            txtSecuencia.ReadOnly = Not False
            lkModulo.ReadOnly = Not False
            lkSubMenu.ReadOnly = Not False
            lkPrograma.ReadOnly = Not False
            RadioGroup1.Enabled = False
        Else
            btnGrabar.Enabled = False
            btnModificar.Enabled = False
            btnEliminar.Enabled = False
        End If
    End Sub

    Private Sub getModulo(ByVal item As tb_cobmenu22)
        Using objEvento As New Negocios.CobMenu22BL(usuario, clave)
            Dim dt As New DataTable
            dt = objEvento.getCobModulComboBL(item)
            If objEvento.existeError Then
                DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objEvento.mensajeErrorSistema, objEvento.mensajeErrorUsuarios),
                                                 "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                lkModulo.Properties.DataSource = dt
                lkModulo.Properties.ValueMember = "modmodul"
                lkModulo.Properties.DisplayMember = "moddesc"
                lkModulo.EditValue = dt.Rows(0).Item("modmodul")
            End If
        End Using
    End Sub

    Private Sub getSubMenu(ByVal item As tb_cobmenu22)
        Using objEvento As New Negocios.CobMenu22BL(usuario, clave)
            Dim dt As New DataTable
            dt = objEvento.getCobMenu11BL(item)
            If objEvento.existeError Then
                DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objEvento.mensajeErrorSistema, objEvento.mensajeErrorUsuarios),
                                                 "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                lkSubMenu.Properties.DataSource = dt  'codmenu1, trim(me1subme) me1subme
                lkSubMenu.Properties.ValueMember = "codmenu1"
                lkSubMenu.Properties.DisplayMember = "me1subme"
                lkSubMenu.EditValue = dt.Rows(0).Item("codmenu1")
            End If
        End Using
    End Sub

    Private Sub getPrograma(ByVal item As tb_cobmenu22)
        Using objEvento As New Negocios.CobMenu22BL(usuario, clave)
            Dim dt As New DataTable
            dt = objEvento.getCobMopro1ComboBL(item)
            If objEvento.existeError Then
                DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objEvento.mensajeErrorSistema, objEvento.mensajeErrorUsuarios),
                                                 "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                lkPrograma.Properties.DataSource = dt  'idcobpro, trim(mopdescr) mopdescr
                lkPrograma.Properties.ValueMember = "idcobpro"
                lkPrograma.Properties.DisplayMember = "mopdescr"
                lkPrograma.EditValue = dt.Rows(0).Item("idcobpro")
            End If
        End Using
    End Sub


    Private Sub getCorrelativo()
        Using objEvento As New Negocios.CobMenu22BL(usuario, clave)
            Dim correlativo As Integer
            correlativo = objEvento.getMaxCobMenu22BL()
            If objEvento.existeError Then
                DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objEvento.mensajeErrorSistema, objEvento.mensajeErrorUsuarios),
                                                                 "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                txtCodEvento.Text = correlativo
            End If
        End Using
    End Sub

    Private Function validarAlta() As Boolean
        Dim Result As Integer = 0
        dxErrorProvider.ClearErrors()
        If Not Integer.TryParse(txtCodEvento.EditValue, Result) Then
            dxErrorProvider.SetError(txtCodEvento, "El código es requerido")
            txtCodEvento.Focus()
            Return False
        ElseIf Not Integer.TryParse(lkModulo.EditValue, Result) Then
            dxErrorProvider.SetError(lkModulo, "El campo modulo es requerido")
            lkModulo.Focus()
            Return False
        ElseIf Not Integer.TryParse(lkSubMenu.EditValue, Result) Then
            dxErrorProvider.SetError(lkSubMenu, "El campo sub-menú es requerido")
            lkSubMenu.Focus()
            Return False
        ElseIf Not Integer.TryParse(lkPrograma.EditValue, Result) Then
            dxErrorProvider.SetError(lkPrograma, "El campo programa es requerido")
            lkPrograma.Focus()
            Return False
        ElseIf String.IsNullOrEmpty(txtDescEvento.Text) Then
            dxErrorProvider.SetError(txtDescEvento, "El campo descripcion es requerido")
            txtDescEvento.Focus()
            Return False
        ElseIf Not Integer.TryParse(txtSecuencia.Text, Result) Then
            dxErrorProvider.SetError(txtSecuencia, "El camopo secuencia es requerido")
            txtSecuencia.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub limpiar()
        txtCodEvento.Text = String.Empty
        txtDescEvento.Text = String.Empty
        txtSecuencia.Text = String.Empty
        If opcion = 1 Then
            getCorrelativo()
        End If
    End Sub

    Private Sub alta()
        Using objEvento As New Negocios.CobMenu22BL(usuario, clave)
            If validarAlta() Then
                Dim vActivo As String = String.Empty
                If RadioGroup1.Properties.Items(RadioGroup1.SelectedIndex).Description = "Activos" Then
                    vActivo = "S"
                Else
                    vActivo = "N"
                End If
                'codevento As Integer, me2event As String, me2modul As Integer, me2subme As Integer, me2nprog As Integer, 
                'me2ofici As String,  me2secue As Int16                         cobmenu22
                Dim item As New tb_cobmenu22 With {.codevento = txtCodEvento.Text, .me2event = txtDescEvento.Text,
                                                  .me2modul = lkModulo.EditValue, .me2subme = lkSubMenu.EditValue,
                                                  .me2nprog = lkPrograma.EditValue, .me2ofici = vActivo, .me2secue = txtSecuencia.Text}
                objEvento.validarDatosTransaccion()
                If (objEvento.DatosValidosEnNegocios) Then
                    Call objEvento.LimpiarErrorBase()
                    Call objEvento.AbrirTransaccion()
                    Call objEvento.altaCobMenu22BL(item)
                    If objEvento.existeError Then
                        Call objEvento.RechazarTransaccion()
                        DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objEvento.mensajeErrorSistema, objEvento.mensajeErrorUsuarios),
                                                                   "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        objEvento.AceptarTransaccion()
                        DevExpress.XtraEditors.XtraMessageBox.Show("Transacción realizada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Call limpiar()
                    End If
                End If
            End If
            objEvento.finalizar()
        End Using
    End Sub

    Private Sub baja()
        Using objEvento As New Negocios.CobMenu22BL(usuario, clave)
            If validarAlta() Then
                Dim vActivo As String = String.Empty
                'If RadioGroup1.Properties.Items(RadioGroup1.SelectedIndex).Description = "Activos" Then
                '    vActivo = "S"
                'Else
                vActivo = "N"
                'End If
                'codevento As Integer, me2event As String, me2modul As Integer, me2subme As Integer, me2nprog As Integer, 
                'me2ofici As String,  me2secue As Int16   
                Dim item As New tb_cobmenu22 With {.codevento = txtCodEvento.Text, .me2ofici = vActivo}
                objEvento.validarDatosTransaccion()
                If (objEvento.DatosValidosEnNegocios) Then
                    Call objEvento.LimpiarErrorBase()
                    Call objEvento.AbrirTransaccion()
                    Call objEvento.bajaCobMenu22BL(item)
                    If objEvento.existeError Then
                        Call objEvento.RechazarTransaccion()
                        DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objEvento.mensajeErrorSistema, objEvento.mensajeErrorUsuarios),
                                                                   "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        objEvento.AceptarTransaccion()
                        DevExpress.XtraEditors.XtraMessageBox.Show("Evento eliminado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Call limpiar()
                    End If
                End If
            End If
            objEvento.finalizar()
        End Using
    End Sub

    Private Sub modificar()
        Using objEvento As New Negocios.CobMenu22BL(usuario, clave)
            If validarAlta() Then
                Dim vActivo As String = String.Empty
                If RadioGroup1.Properties.Items(RadioGroup1.SelectedIndex).Description = "Activos" Then
                    vActivo = "S"
                Else
                    vActivo = "N"
                End If
                'codevento As Integer, me2event As String, me2modul As Integer, me2subme As Integer, me2nprog As Integer, 
                'me2ofici As String,  me2secue As Int16                         cobmenu22
                Dim item As New tb_cobmenu22 With {.codevento = txtCodEvento.Text, .me2event = txtDescEvento.Text,
                                                  .me2modul = lkModulo.EditValue, .me2subme = lkSubMenu.EditValue,
                                                  .me2nprog = lkPrograma.EditValue, .me2ofici = vActivo, .me2secue = txtSecuencia.Text}
                objEvento.validarDatosTransaccion()
                If (objEvento.DatosValidosEnNegocios) Then
                    Call objEvento.LimpiarErrorBase()
                    Call objEvento.AbrirTransaccion()
                    Call objEvento.modificarCobMenu22BL(item)
                    If objEvento.existeError Then
                        Call objEvento.RechazarTransaccion()
                        DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objEvento.mensajeErrorSistema, objEvento.mensajeErrorUsuarios), "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        objEvento.AceptarTransaccion()
                        DevExpress.XtraEditors.XtraMessageBox.Show("Evento actualizado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Call limpiar()
                    End If
                End If
            End If
            objEvento.finalizar()
        End Using
    End Sub

    Private Sub inicio()
        If lista.Count > 0 Then
            Using objSModulo As New Negocios.CobMenu22BL(usuario, clave)
                Dim dt As New DataTable
                Dim item(0) As tb_cobmenu22
                item.SetValue(lista.ElementAt(0), 0)

                Dim itemTabla As New tb_cobmenu22
                itemTabla = item.GetValue(0)
                dt = objSModulo.getUnCobMenu22BL(itemTabla)

                If objSModulo.existeError Then
                    DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objSModulo.mensajeErrorSistema, objSModulo.mensajeErrorUsuarios),
                                                                  "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf dt.Rows.Count > 0 Then 'codevento, trim(me2event) me2event, me2modul, me2subme, me2nprog, trim(me2ofici) me2ofici, me2secue
                    txtCodEvento.Text = dt.Rows(0).Item("codevento")
                    lkModulo.EditValue = dt.Rows(0).Item("me2modul")
                    lkSubMenu.EditValue = dt.Rows(0).Item("me2subme")
                    lkPrograma.EditValue = dt.Rows(0).Item("me2nprog")

                    txtDescEvento.Text = dt.Rows(0).Item("me2event")
                    txtSecuencia.Text = dt.Rows(0).Item("me2secue")

                    If dt.Rows(0).Item("me2ofici") = "S" Then

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
                Using objSModulo As New Negocios.CobMenu22BL(usuario, clave)
                    Dim dt As New DataTable
                    Dim item(0) As tb_cobmenu22
                    item.SetValue(lista.ElementAt(index + 1), 0)
                    Dim itemTabla As New tb_cobmenu22
                    itemTabla = item.GetValue(0)
                    dt = objSModulo.getUnCobMenu22BL(itemTabla)

                    If objSModulo.existeError Then
                        DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objSModulo.mensajeErrorSistema, objSModulo.mensajeErrorUsuarios),
                                                                      "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ElseIf dt.Rows.Count > 0 Then 'codmenu1 As Integer, me1subme As String , me1modul As Integer, me1ofici As String, me1secue As Int16
                        txtCodEvento.Text = dt.Rows(0).Item("codevento")
                        lkModulo.EditValue = dt.Rows(0).Item("me2modul")
                        lkSubMenu.EditValue = dt.Rows(0).Item("me2subme")
                        lkPrograma.EditValue = dt.Rows(0).Item("me2nprog")

                        txtDescEvento.Text = dt.Rows(0).Item("me2event")
                        txtSecuencia.Text = dt.Rows(0).Item("me2secue")
                        If dt.Rows(0).Item("me2ofici") = "S" Then

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
                Using objSModulo As New Negocios.CobMenu22BL(usuario, clave)
                    Dim dt As New DataTable
                    Dim item(0) As tb_cobmenu22
                    item.SetValue(lista.ElementAt(index - 1), 0)
                    Dim itemTabla As New tb_cobmenu22
                    itemTabla = item.GetValue(0)
                    dt = objSModulo.getUnCobMenu22BL(itemTabla)
                    If objSModulo.existeError Then
                        DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objSModulo.mensajeErrorSistema, objSModulo.mensajeErrorUsuarios),
                                                                      "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ElseIf dt.Rows.Count > 0 Then 'codmenu1 As Integer, me1subme As String , me1modul As Integer, me1ofici As String, me1secue As Int16
                        txtCodEvento.Text = dt.Rows(0).Item("codevento")
                        lkModulo.EditValue = dt.Rows(0).Item("me2modul")
                        lkSubMenu.EditValue = dt.Rows(0).Item("me2subme")
                        lkPrograma.EditValue = dt.Rows(0).Item("me2nprog")

                        txtDescEvento.Text = dt.Rows(0).Item("me2event")
                        txtSecuencia.Text = dt.Rows(0).Item("me2secue")
                        If dt.Rows(0).Item("me2ofici") = "S" Then

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
            Using objSModulo As New Negocios.CobMenu22BL(usuario, clave)
                Dim dt As New DataTable
                Dim item(0) As tb_cobmenu22
                item.SetValue(lista.Last, 0)
                Dim itemTabla As New tb_cobmenu22
                itemTabla = item.GetValue(0)
                dt = objSModulo.getUnCobMenu22BL(itemTabla)
                If objSModulo.existeError Then
                    DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objSModulo.mensajeErrorSistema, objSModulo.mensajeErrorUsuarios),
                                                                  "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf dt.Rows.Count > 0 Then  ' 'codmenu1 As Integer, me1subme As String , me1modul As Integer, me1ofici As String, me1secue As Int16
                    txtCodEvento.Text = dt.Rows(0).Item("codevento")
                    lkModulo.EditValue = dt.Rows(0).Item("me2modul")
                    lkSubMenu.EditValue = dt.Rows(0).Item("me2subme")
                    lkPrograma.EditValue = dt.Rows(0).Item("me2nprog")

                    txtDescEvento.Text = dt.Rows(0).Item("me2event")
                    txtSecuencia.Text = dt.Rows(0).Item("me2secue")

                    If dt.Rows(0).Item("me2ofici") = "S" Then

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