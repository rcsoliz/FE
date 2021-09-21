Imports Entidades
Imports System
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System.Data
Imports DevExpress.XtraGrid
Imports System.Threading
Public Class UI_BCobAcces1 : Inherits f_base

#Region "atributosGlobales"


    Private usuario As String
    Private clave As String
    Private listaXRegistrar As List(Of tb_cobacces)

#End Region

#Region "[constructor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String)
        MyBase.New("DATOS ACCESOS", "Realice la operación requerida...")
        InitializeComponent()
        usuario = usuar
        clave = clav
        lblUsuario.Text = usuar
        Call getCobModulCombo()
        listaXRegistrar = New List(Of tb_cobacces)
    End Sub

#End Region

#Region "[metodos]"

    'prglogin  prgmoul   prgnprog
    'prggraba  prgborra  prgmodif   prgconsu  prgimpri
    'prgexcel  prgexpdf  prgcopip   
    'prgofici  
    'modulo    programa 

    'colprglogin   colprgmoul   colprgnprog
    'colprggraba   colprgborra  colprgmodif   colprgconsu  colprgimpri
    'colprgexcel   colprgexpdf  colprgcopip   colprgofici
    'colmodulo     colevento

    Private Function listaAlta() As List(Of tb_cobacces)
        Dim lista As New List(Of tb_cobacces)()
        If gvEventoXRegistrar.RowCount > 0 Then
            For i = 0 To gvEventoXRegistrar.RowCount - 1 Step 1
                'prglogin, prgmodul , prgnprog, prggraba, prgborra, prgmodif, prgconsu, prgimpri, prgexcel, prgexpdf, prgcopip, prgofici
                Dim vgraba As String = "N" : Dim vprggraba As Boolean = gvEventoXRegistrar.GetRowCellValue(i, colprggraba)
                If vprggraba Then
                    vgraba = "S"
                End If
                Dim vborra As String = "N" : Dim vprgborra As Boolean = gvEventoXRegistrar.GetRowCellValue(i, colprgborra)
                If vprgborra Then
                    vborra = "S"
                End If
                Dim vmodi As String = "N" : Dim vprgmodif As Boolean = gvEventoXRegistrar.GetRowCellValue(i, colprgmodif)
                If vprgmodif Then
                    vmodi = "S"
                End If
                Dim vcons As String = "N" : Dim vprgconsu As Boolean = gvEventoXRegistrar.GetRowCellValue(i, colprgconsu)
                If vprgconsu Then
                    vcons = "S"
                End If
                Dim vimpr As String = "N" : Dim vprgimpri As Boolean = gvEventoXRegistrar.GetRowCellValue(i, colprgimpri)
                If vprgimpri Then
                    vimpr = "S"
                End If
                Dim vexce As String = "N" : Dim vprgexcel As Boolean = gvEventoXRegistrar.GetRowCellValue(i, colprgexcel)
                If vprgexcel Then
                    vexce = "S"
                End If
                Dim vpdf As String = "N" : Dim vprgexpdf As Boolean = gvEventoXRegistrar.GetRowCellValue(i, colprgexpdf)
                If vprgexpdf Then
                    vpdf = "S"
                End If
                Dim vcopi As String = "N" : Dim vprgcopip As Boolean = gvEventoXRegistrar.GetRowCellValue(i, colprgcopip)
                If vprgcopip Then
                    vpdf = "S"
                End If


                Dim item As New tb_cobacces With {.prglogin = usuario, .prgmodul = gvEventoXRegistrar.GetRowCellValue(i, colprgmoul),
                                                  .prgnprog = gvEventoXRegistrar.GetRowCellValue(i, colprgnprog),
                                                  .prggraba = vgraba, .prgborra = vborra, .prgmodif = vmodi, .prgconsu = vcons,
                                                  .prgimpri = vimpr, .prgexcel = vexce, .prgexpdf = vpdf, .prgcopip = vcopi,
                                                  .prgofici = "81001"}
                'prglogin, prgmodul , prgnprog, prggraba, prgborra, prgmodif, prgconsu, prgimpri, prgexcel, prgexpdf, prgcopip, prgofici
                lista.Add(item)
            Next
        End If
        Return lista
    End Function

    Private Function listaActualizar() As List(Of tb_cobacces) '_______________________________________ aqui estoys
        Dim lista As New List(Of tb_cobacces)()
        If gvEventoRegistrados.RowCount > 0 Then
            For i = 0 To gvEventoRegistrados.RowCount - 1 Step 1
                'prglogin, prgmodul , prgnprog, prggraba, prgborra, prgmodif, prgconsu, prgimpri, prgexcel, prgexpdf, prgcopip, prgofici
                Dim vgraba As String = "N" : Dim vprggraba As Boolean = gvEventoRegistrados.GetRowCellValue(i, colprggraba1)
                If vprggraba Then
                    vgraba = "S"
                End If
                Dim vborra As String = "N" : Dim vprgborra As Boolean = gvEventoRegistrados.GetRowCellValue(i, colprgborra1)
                If vprgborra Then
                    vborra = "S"
                End If
                Dim vmodi As String = "N" : Dim vprgmodif As Boolean = gvEventoRegistrados.GetRowCellValue(i, colprgmodif1)
                If vprgmodif Then
                    vmodi = "S"
                End If
                Dim vcons As String = "N" : Dim vprgconsu As Boolean = gvEventoRegistrados.GetRowCellValue(i, colprgconsu1)
                If vprgconsu Then
                    vcons = "S"
                End If
                Dim vimpr As String = "N" : Dim vprgimpri As Boolean = gvEventoRegistrados.GetRowCellValue(i, colprgimpri1)
                If vprgimpri Then
                    vimpr = "S"
                End If
                Dim vexce As String = "N" : Dim vprgexcel As Boolean = gvEventoRegistrados.GetRowCellValue(i, colprgexcel1)
                If vprgexcel Then
                    vexce = "S"
                End If
                Dim vpdf As String = "N" : Dim vprgexpdf As Boolean = gvEventoRegistrados.GetRowCellValue(i, colprgexpdf1)
                If vprgexpdf Then
                    vpdf = "S"
                End If
                Dim vcopi As String = "N" : Dim vprgcopip As Boolean = gvEventoRegistrados.GetRowCellValue(i, colprgcopip1)
                If vprgcopip Then
                    vcopi = "S"
                End If

                Dim item As New tb_cobacces With {.prglogin = usuario, .prgmodul = gvEventoRegistrados.GetRowCellValue(i, colprgmoul1),
                                            .prgnprog = gvEventoRegistrados.GetRowCellValue(i, colprgnprog1),
                                            .prggraba = vgraba, .prgborra = vborra, .prgmodif = vmodi, .prgconsu = vcons,
                                            .prgimpri = vimpr, .prgexcel = vexce, .prgexpdf = vpdf, .prgcopip = vcopi,
                                            .prgofici = "81001"}
                lista.Add(item)
            Next
        End If
        Return lista
    End Function

    Private Sub limpiar()
        listaXRegistrar = New List(Of tb_cobacces)()
        '  Using objDts As New DSERegistrados
        gcEventoRegistrados.DataSource = Nothing
        gcEventoRegistrados.DataSource = DSERegistrados.Tables("tb_cobacces1")
        'End Using
    End Sub

    Private Sub alta()
        Using objCobAcces1 As New Negocios.CobAcces1BL(usuario, clave)
            Dim lista As New List(Of tb_cobacces)()
            lista = listaAlta()

            Dim listaXActualizar As New List(Of tb_cobacces)
            listaXActualizar = listaActualizar()

            objCobAcces1.validarDatosTransaccion()
            If (objCobAcces1.DatosValidosEnNegocios) Then
                Call objCobAcces1.LimpiarErrorBase()
                Call objCobAcces1.AbrirTransaccion()
                Call objCobAcces1.altaCobAcces1BL(lista)
                Call objCobAcces1.modificarCobAcces1BL(listaXActualizar)
                If objCobAcces1.existeError Then
                    Call objCobAcces1.RechazarTransaccion()
                    DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objCobAcces1.mensajesErrorSistema, objCobAcces1.mensajeErrorUsuarios),
                                                               "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    objCobAcces1.AceptarTransaccion()
                    DevExpress.XtraEditors.XtraMessageBox.Show("Transacción realizada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Call limpiar()
                End If
            End If
        End Using
    End Sub

    Private Sub eliminar()
        Using objCobAcces1 As New Negocios.CobAcces1BL(usuario, clave)
            Dim item As New tb_cobacces With {.prglogin = lblUsuario.Text,
                                              .prgmodul = gvEventoRegistrados.GetRowCellValue(gvEventoRegistrados.FocusedRowHandle, colprgmoul1),
                                              .prgnprog = gvEventoRegistrados.GetRowCellValue(gvEventoRegistrados.FocusedRowHandle, colprgnprog1)}
            If MessageBox.Show("¿Está seguro de eliminar este evento?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                objCobAcces1.validarDatosTransaccion()
                If (objCobAcces1.DatosValidosEnNegocios) Then
                    Call objCobAcces1.LimpiarErrorBase()
                    Call objCobAcces1.AbrirTransaccion()
                    Call objCobAcces1.bajaCobAcces1BL(item)
                    If objCobAcces1.existeError Then
                        Call objCobAcces1.RechazarTransaccion()
                        DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objCobAcces1.mensajesErrorSistema, objCobAcces1.mensajeErrorUsuarios),
                                                                   "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        objCobAcces1.AceptarTransaccion()
                        DevExpress.XtraEditors.XtraMessageBox.Show("Transacción realizada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Call limpiar()
                    End If
                End If
            End If

            Call objCobAcces1.finalizar()
        End Using
    End Sub

    Private Sub eliminarXBloque()
        Using objCobAcces1 As New Negocios.CobAcces1BL(usuario, clave)

            Dim listaXActualizar As New List(Of tb_cobacces)
            listaXActualizar = listaActualizar()
            If MessageBox.Show(String.Format("¿Está seguro de eliminar estos eventos? del modulo: {0} al Usuario: {1}", lkModulo.Text, lblUsuario.Text), "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                objCobAcces1.validarDatosTransaccion()
                If (objCobAcces1.DatosValidosEnNegocios) Then
                    Call objCobAcces1.LimpiarErrorBase()
                    Call objCobAcces1.AbrirTransaccion()
                    Call objCobAcces1.bajaCobAcces1BL(listaXActualizar)
                    If objCobAcces1.existeError Then
                        Call objCobAcces1.RechazarTransaccion()
                        DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objCobAcces1.mensajesErrorSistema, objCobAcces1.mensajeErrorUsuarios),
                                                                   "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        objCobAcces1.AceptarTransaccion()
                        DevExpress.XtraEditors.XtraMessageBox.Show("Transacción realizada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Call limpiar()
                    End If
                End If
            End If
        End Using
    End Sub

    Private Sub actualizar()
        Using objCobAcces1 As New Negocios.CobAcces1BL(usuario, clave)

            Dim listaXActualizar As New List(Of tb_cobacces)
            listaXActualizar = listaActualizar()

            objCobAcces1.validarDatosTransaccion()
            If (objCobAcces1.DatosValidosEnNegocios) Then
                Call objCobAcces1.LimpiarErrorBase()
                Call objCobAcces1.AbrirTransaccion()
                Call objCobAcces1.modificarCobAcces1BL(listaXActualizar)
                If objCobAcces1.existeError Then
                    Call objCobAcces1.RechazarTransaccion()
                    DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objCobAcces1.mensajesErrorSistema, objCobAcces1.mensajeErrorUsuarios),
                                                               "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    objCobAcces1.AceptarTransaccion()
                    DevExpress.XtraEditors.XtraMessageBox.Show("Transacción realizada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Call limpiar()
                End If
            End If
        End Using
    End Sub

    Private Sub getCobModulCombo()
        Using objCobAcces As New Negocios.CobAcces1BL(usuario, clave)
            Dim dt As New DataTable
            dt = objCobAcces.getCobModulComboBL()
            If objCobAcces.existeError Then
                DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objCobAcces.mensajesErrorSistema, objCobAcces.mensajeErrorUsuarios),
                                                 "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                lkModulo1.Properties.DataSource = dt
                lkModulo1.Properties.ValueMember = "modmodul"
                lkModulo1.Properties.DisplayMember = "moddesc"
                lkModulo1.EditValue = dt.Rows(0).Item("modmodul")
            End If
            objCobAcces.finalizar()
        End Using
    End Sub

    Private Sub getModuloXEvento(ByVal item As tb_cobacces)
        Using objCobAcces As New Negocios.CobAcces1BL(usuario, clave)
            Dim dt As New DataTable
            dt = objCobAcces.getCobMopro1BL(item)
            If objCobAcces.existeError Then
                DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objCobAcces.mensajesErrorSistema, objCobAcces.mensajeErrorUsuarios),
                                                 "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                gcModuloXEvento.DataSource = dt
            End If
            Call objCobAcces.finalizar()
        End Using
    End Sub

    Private Sub cargarEventoXRegistrar(ByVal iEvento As tb_cobacces)
        Dim itemEvento As New tb_cobacces With {.prglogin = lblUsuario.Text, .prgmodul = iEvento.prgmodul, .prgnprog = iEvento.prgnprog,
                                          .prggraba1 = False, .prgborra1 = False, .prgmodif1 = False, .prgconsu1 = False,
                                          .prgimpri1 = False, .prgexcel1 = False, .prgexpdf1 = False, .prgcopip1 = False,
                                          .prgofici = "81001",
                                          .modulo = iEvento.modulo, .evento = iEvento.evento}
        Dim vEvento As String = itemEvento.evento
        Dim existe As Boolean = False

        For Each item As tb_cobacces In listaXRegistrar
            If (item.evento.Contains(vEvento)) Then
                existe = True
            End If
        Next
        If existe = False Then
            gcEventoXRegistrar.DataSource = Nothing
            listaXRegistrar.Add(itemEvento)
            gcEventoXRegistrar.DataSource = listaXRegistrar
        Else
            MessageBox.Show("El evento seleccionado ya se encuentra asignado !!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Function getEventosRegistrados(ByVal iEvento As tb_cobacces) As DataSet
        Using objCobAcces1 As New Negocios.CobAcces1BL(usuario, clave)
            Using dts As New DSERegistrados
                Dim dtAux As New DataSet
                dtAux = dts

                Dim dtERegistrado As DataTable
                dtERegistrado = objCobAcces1.getCobacces1XModuloYUsuarioBL(iEvento)

                For Each fila As DataRow In dtERegistrado.Rows
                    Dim vprggraba As Boolean = False : Dim vprgborra As Boolean = False : Dim vprgmodif As Boolean = False
                    Dim vprgconsu As Boolean = False
                    Dim vprgimpri As Boolean = False : Dim vprgexcel As Boolean = False : Dim vprgexpdf As Boolean = False
                    Dim vprgcopip As Boolean = False

                    If fila.Item("prggraba") = "S" Then
                        vprggraba = True
                    End If
                    If fila.Item("prgborra") = "S" Then
                        vprgborra = True
                    End If
                    If fila.Item("prgmodif") = "S" Then
                        vprgmodif = True
                    End If
                    If fila.Item("prgconsu") = "S" Then
                        vprgconsu = True
                    End If

                    If fila.Item("prgimpri") = "S" Then
                        vprgimpri = True
                    End If
                    If fila.Item("prgexcel") = "S" Then
                        vprgexcel = True
                    End If
                    If fila.Item("prgexpdf") = "S" Then
                        vprgexpdf = True
                    End If
                    If fila.Item("prgcopip") = "S" Then
                        vprgcopip = True
                    End If
                    'prgmoul()
                    'prgmodul()
                    dtAux.Tables(0).Rows.Add(New Object() {fila.Item("prglogin"), fila.Item("prgmodul"), fila.Item("prgnprog"),
                                                           vprggraba, vprgborra, vprgmodif, vprgconsu,
                                                           vprgimpri, vprgexcel, vprgexpdf, vprgcopip,
                                                           fila.Item("prgofici"),
                                                           fila.Item("modulo"), fila.Item("programa")})

                    'select trim(prglogin) prglogin, prgmodul, (select trim(mo.moddesc) from cobmodul1 mo where mo.modmodul=cobacces1.prgmodul) modulo, prgnprog, 
                    '(select trim(mopdescr) mopdescr from cobmopro1 pr where pr.idcobpro=cobacces1.prgnprog) programa, 
                    'trim(prggraba) prggraba, trim(prgborra) prgborra, trim(prgmodif) prgmodif, trim(prgconsu) prgconsu, 
                    'trim(prgimpri) prgimpri, trim(prgexcel) prgexcel, trim(prgexpdf) prgexpdf, trim(prgcopip) prgcopip, 
                    'trim(prgofici) prgofici 
                Next
                Return dts
            End Using
        End Using
    End Function

#End Region

#Region "[eventos]"

    Private Sub lkModulo1_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lkModulo1.EditValueChanged
        Dim item As New tb_cobacces With {.prgmodul = lkModulo1.EditValue, .prglogin = usuario}
        Call getModuloXEvento(item)
        listaXRegistrar = New List(Of tb_cobacces)
        '  Call limpiar()
        gcEventoRegistrados.DataSource = getEventosRegistrados(item)
    End Sub

    Private Sub gvEventoXRegistrar_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Windows.Forms.Keys.Delete Then
            If gvEventoXRegistrar.RowCount > 0 Then
                If listaXRegistrar.Count > 0 Then
                    Dim vEvento As String = gvEventoXRegistrar.GetRowCellValue(gvEventoXRegistrar.FocusedRowHandle, "evento").ToString
                    'Dim listaAux As New List(Of tb_cobacces)
                    'listaAux = listaXRegistrar
                    For Each item As tb_cobacces In listaXRegistrar
                        If (item.evento.Contains(vEvento)) Then
                            listaXRegistrar.Remove(item)
                            Exit For
                        End If
                    Next
                    gcEventoXRegistrar.DataSource = Nothing
                    gcEventoXRegistrar.DataSource = listaXRegistrar
                End If
            End If
        End If
    End Sub

    Private Sub gvEventoRegistrados_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Windows.Forms.Keys.Delete Then
            If gvEventoRegistrados.RowCount > 0 Then
                Call eliminar()
            End If
        End If
    End Sub

    Private Sub gcModuloXEvento_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gcModuloXEvento.DoubleClick
        If gvModuloXEvento.RowCount > 0 Then
            Dim descModulo As String = lkModulo.Text
            Dim descEvento As String = gvModuloXEvento.GetRowCellValue(gvModuloXEvento.FocusedRowHandle, "mopdescr").ToString
            Dim iEvento As New tb_cobacces With {.modulo = descModulo, .evento = descEvento,
                                                 .prgmodul = gvModuloXEvento.GetRowCellValue(gvModuloXEvento.FocusedRowHandle, "mopmodul"),
                                                 .prgnprog = gvModuloXEvento.GetRowCellValue(gvModuloXEvento.FocusedRowHandle, "idcobpro")}
            Call cargarEventoXRegistrar(iEvento)
        End If
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Call alta()
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        Call actualizar()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If gvEventoRegistrados.RowCount > 0 Then
            Call eliminarXBloque()
        End If
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Call Close()
    End Sub

#End Region

End Class