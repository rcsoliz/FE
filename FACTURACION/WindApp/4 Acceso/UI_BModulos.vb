Imports System.Data
Imports ENTIDADES
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports DevExpress.XtraGrid
Imports DevExpress.XtraPrinting
Public Class UI_BModulos : Inherits f_base

#Region "[atributosGlobales]"

    Private usuario As String
    Private clave As String

#End Region

#Region "[constructor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String)
        MyBase.New("Datos Modulos del Sistema", "Realize la operacion necesaria...")
        InitializeComponent()
        usuario = usuar
        clave = clav
    End Sub

#End Region

#Region "[metodos]"

    Private Sub getModuloActivos()
        Using objModulo As New Negocios.CobModulBL(usuario, clave)
            Dim dt As New DataTable
            dt = objModulo.getCobModulActivoBL()
            If objModulo.existeError Then
                DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objModulo.mensajesErrorSistema, objModulo.mensajeErrorUsuarios),
                                                           "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                gcModActivos.DataSource = dt
            End If
            objModulo.finalizar()
        End Using
    End Sub

    Private Sub getModuloInactivos()
        Using objModulo As New Negocios.CobModulBL(usuario, clave)
            Dim dt As New DataTable
            dt = objModulo.getCobModulInactivoBL()
            If objModulo.existeError Then
                DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objModulo.mensajesErrorSistema, objModulo.mensajeErrorUsuarios),
                                                           "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                gcModInactivos.DataSource = dt
            End If
            objModulo.finalizar()
        End Using
    End Sub

    Private Function getListaModulos(ByVal opcion As Integer) As List(Of ENTIDADES.tb_codmodul)
        Dim lista As New List(Of ENTIDADES.tb_codmodul)()
        If opcion = 1 Then
            If gvModActivos.RowCount > 0 Then

                Dim filaDatos As DataRow
                Dim arrayFilaSel() As Integer = gvModActivos.GetSelectedRows()
                For i = 0 To arrayFilaSel.Length - 1 Step 1
                    filaDatos = gvModActivos.GetDataRow(arrayFilaSel(i))

                    Dim item As New ENTIDADES.tb_codmodul With {.modmodul = filaDatos.Item(0), .moddesc = filaDatos.Item(1),
                                                                .modinsta = filaDatos.Item(2), .modofici = filaDatos.Item(3),
                                                                .modsecue = filaDatos.Item(4)}
                    lista.Add(item)
                Next
            End If
        Else
            If gvModInactivos.RowCount > 0 Then

                Dim filaDatos As DataRow
                Dim arrayFilaSel() As Integer = gvModInactivos.GetSelectedRows()
                For i = 0 To arrayFilaSel.Length - 1 Step 1
                    filaDatos = gvModInactivos.GetDataRow(arrayFilaSel(i))

                    Dim item As New ENTIDADES.tb_codmodul With {.modmodul = filaDatos.Item(0), .moddesc = filaDatos.Item(1),
                                                                .modinsta = filaDatos.Item(2), .modofici = filaDatos.Item(3),
                                                                .modsecue = filaDatos.Item(4)}
                    lista.Add(item)
                Next
            End If
        End If
        Return lista
    End Function

    Private Function getListaSModulos() As List(Of ENTIDADES.tb_cobmopro)
        Dim lista As New List(Of ENTIDADES.tb_cobmopro)()
        If gvSubModulos.RowCount > 0 Then

            Dim filaDatos As DataRow
            Dim arrayFilaSel() As Integer = gvSubModulos.GetSelectedRows()
            For i = 0 To arrayFilaSel.Length - 1 Step 1
                filaDatos = gvSubModulos.GetDataRow(arrayFilaSel(i))

                Dim item As New ENTIDADES.tb_cobmopro With {.idcobpro = filaDatos.Item(0)}
                lista.Add(item)
            Next
        End If
        Return lista
    End Function

    Private Sub getSubModulos(ByVal item As tb_cobmopro)
        Using objSModulo As New Negocios.CobmoproBL(usuario, clave)
            Dim dt As New DataTable
            dt = objSModulo.getSubModuloBL(item)
            If objSModulo.existeError Then
                DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objSModulo.mensajesErrorSistema, objSModulo.mensajeErrorUsuarios),
                                                           "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                gcSubModulos.DataSource = dt
            End If

            objSModulo.finalizar()
        End Using
    End Sub

    Private Sub imprimirGrid(ByVal gc As GridControl)
        If Not gc.IsPrintingAvailable Then
            MessageBox.Show("La libreria para poder imprir ...")
            Return
        End If
        gc.ShowRibbonPrintPreview()
    End Sub

#End Region

#Region "[eventos]"

    Private Sub UI_BModulos_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Call getModuloActivos()
        Call getModuloInactivos()
    End Sub

    Private Sub btnAgregarMod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarMod.Click
        Dim objFormModulo As New UI_Modulos(usuario, clave, 1) With {.MdiParent = MdiParent}
        objFormModulo.Show()
    End Sub

    Private Sub btnModificarMod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificarMod.Click
        'If TabbedControlGroup1.SelectedTabPage.Equals(LayoutControlGroup2) Then
        '    MessageBox.Show("aqui estoy 2")
        'ElseIf TabbedControlGroup1.SelectedTabPage.Equals(LayoutControlGroup4) Then
        '    MessageBox.Show("aqui estoy 4")
        'End If

        If TabbedControlGroup1.SelectedTabPage.Equals(LayoutControlGroup2) Then 'TabbedControlGroup1.SelectedTabPageName = "LayoutControlGroup2" Then
            Dim lista As New List(Of Entidades.tb_codmodul)()
            lista = getListaModulos(1)
            If lista.Count > 0 Then
                Dim objFormModulo As New UI_Modulos(usuario, clave, lista, 2) With {.MdiParent = MdiParent}
                objFormModulo.Show()
            Else
                DevExpress.XtraEditors.XtraMessageBox.Show("Primero debe seleccionar las fila(s) a actualizar", "Información",
                                                           MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else 'If TabbedControlGroup1.SelectedTabPageName = "LayoutControlGroup4" Then
            Dim lista As New List(Of Entidades.tb_codmodul)()
            lista = getListaModulos(2)
            If lista.Count > 0 Then
                Dim objFormModulo As New UI_Modulos(usuario, clave, lista, 2) With {.MdiParent = MdiParent}
                objFormModulo.Show()
            Else
                DevExpress.XtraEditors.XtraMessageBox.Show("Primero debe seleccionar las fila(s) a actualizar", "Información",
                                                           MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

    Private Sub btnEliminarMod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarMod.Click
        If TabbedControlGroup1.SelectedTabPageName = "LayoutControlGroup2" Then
            Dim lista As New List(Of ENTIDADES.tb_codmodul)()
            lista = getListaModulos(1)
            If lista.Count > 0 Then
                Dim objFormModulo As New UI_Modulos(usuario, clave, lista, 3) With {.MdiParent = MdiParent}
                objFormModulo.Show()
            Else
                DevExpress.XtraEditors.XtraMessageBox.Show("Primero debe seleccionar las fila(s) a actualizar", "Información",
                                                           MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        ElseIf TabbedControlGroup1.SelectedTabPageName = "LayoutControlGroup4" Then
            Dim lista As New List(Of ENTIDADES.tb_codmodul)()
            lista = getListaModulos(2)
            If lista.Count > 0 Then
                Dim objFormModulo As New UI_Modulos(usuario, clave, lista, 3) With {.MdiParent = MdiParent}
                objFormModulo.Show()
            Else
                DevExpress.XtraEditors.XtraMessageBox.Show("Primero debe seleccionar las fila(s) a actualizar", "Información",
                                                           MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

    Private Sub btnExportarMod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportarMod.Click
        Call imprimirGrid(gcModActivos)
    End Sub

    Private Sub btnSalirMod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalirMod.Click
        Call Close()
    End Sub


    Private Sub btnAgregarSMod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarSMod.Click
        Dim objFormModulo As New UI_SubModulos(usuario, clave, 1) With {.MdiParent = MdiParent}
        objFormModulo.Show()
    End Sub

    Private Sub btnModificarSMod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificarSMod.Click
        Dim lista As New List(Of ENTIDADES.tb_cobmopro)()
        lista = getListaSModulos()
        If lista.Count > 0 Then
            Dim objFormModulo As New UI_SubModulos(usuario, clave, lista, 2) With {.MdiParent = MdiParent}
            objFormModulo.Show()
        Else
            DevExpress.XtraEditors.XtraMessageBox.Show("Primero debe seleccionar las fila(s) a actualizar", "Información",
                                                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btnEliminarSMod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarSMod.Click
        Dim lista As New List(Of ENTIDADES.tb_cobmopro)()
        lista = getListaSModulos()
        If lista.Count > 0 Then
            Dim objFormModulo As New UI_SubModulos(usuario, clave, lista, 3) With {.MdiParent = MdiParent}
            objFormModulo.Show()
        Else
            DevExpress.XtraEditors.XtraMessageBox.Show("Primero debe seleccionar las fila(s) a actualizar", "Información",
                                                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btnExportarSMod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportarSMod.Click
        Call imprimirGrid(gcSubModulos)
    End Sub

    Private Sub btnSalirSMod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalirSMod.Click
        Call Close()
    End Sub

    Private Sub gcModActivos_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gcModActivos.DoubleClick
        If gvModActivos.RowCount > 0 Then
            Dim codModulo As Integer = gvModActivos.GetFocusedRowCellValue("modmodul")
            Dim item As New tb_cobmopro With {.mopmodul = codModulo}
            Call getSubModulos(item)
        End If
    End Sub

    Private Sub gcModInactivos_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gcModInactivos.DoubleClick
        If gvModActivos.RowCount > 0 Then
            Dim codModulo As Integer = gvModInactivos.GetFocusedRowCellValue("modmodul")
            Dim item As New tb_cobmopro With {.mopmodul = codModulo}
            Call getSubModulos(item)
        End If
    End Sub

    Private Sub gcModActivos_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gcModActivos.MouseMove
        If TabbedControlGroup1.SelectedTabPageIndex = 1 Then
            MessageBox.Show("primero as: 1 ", "")
        End If
        TabbedControlGroup2.SelectedTabPageIndex = 0
    End Sub

    Private Sub gcSubModulos_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gcSubModulos.MouseMove
        TabbedControlGroup2.SelectedTabPageIndex = 1
    End Sub

#End Region

    Private Sub gcModActivos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gcModActivos.Click

    End Sub

    Private Sub LayoutControlGroup2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LayoutControlGroup2.Click

    End Sub
End Class