Imports ENTIDADES
Imports System
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System.Data
Imports DevExpress.XtraGrid
Public Class UI_BCobMenu11 : Inherits f_base

#Region "[atributosGlobales]"

    Private usuario As String
    Private clave As String

#End Region

#Region "[constructor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String)
        MyBase.New("DATOS SUB-MENUS", "Realice la operación requerida...")
        InitializeComponent()

        usuario = usuar
        clave = clav

        Call getModulo()
        Call getModuloGridControl()
    End Sub

#End Region

#Region "[metodos]"

    Private Sub getModulo()
        Using objMenu11 As New Negocios.CobMenu11BL(usuario, clave)
            Dim dt As New DataTable
            dt = objMenu11.getCobModulComboBL()
            If objMenu11.existeError Then
                DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objMenu11.mensajeErrorUsuarios, objMenu11.mensajeErrorUsuarios),
                                                 "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                lkModulo.Properties.DataSource = dt
                lkModulo.Properties.ValueMember = "modmodul"
                lkModulo.Properties.DisplayMember = "moddesc"
                lkModulo.EditValue = dt.Rows(0).Item("modmodul")
            End If
        End Using
    End Sub

    Private Sub getModuloGridControl()
        Using objMenu11 As New Negocios.CobMenu11BL(usuario, clave)
            Dim dt As New DataTable
            dt = objMenu11.getCobModulComboBL()
            If objMenu11.existeError Then
                DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objMenu11.mensajeErrorUsuarios, objMenu11.mensajeErrorUsuarios),
                                                 "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                RLEModulo.DataSource = dt
                RLEModulo.ValueMember = "modmodul"
                RLEModulo.DisplayMember = "moddesc"
            End If
        End Using
    End Sub

    Private Sub getSubModuloXModulo()
        Using objMenu11 As New Negocios.CobMenu11BL(usuario, clave)
            Dim item As New tb_cobmenu11 With {.me1modul = lkModulo.EditValue}
            Dim dt As New DataTable
            dt = objMenu11.getCobMenu11XModuloBL(item)
            If objMenu11.existeError Then
                DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objMenu11.mensajeErrorSistema, objMenu11.mensajeErrorUsuarios),
                                                 "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                gcSubModulo.DataSource = dt
            End If
        End Using
    End Sub

    Private Sub imprimirGrid(ByVal gc As GridControl)
        If Not gc.IsPrintingAvailable Then
            MessageBox.Show("La libreria para poder imprir ...")
            Return
        End If
        gc.ShowRibbonPrintPreview()
    End Sub

    Private Function getListaModulos() As List(Of ENTIDADES.tb_cobmenu11)
        Dim lista As New List(Of ENTIDADES.tb_cobmenu11)()
        If gvSubModulo.RowCount > 0 Then

            Dim filaDatos As DataRow
            Dim arrayFilaSel() As Integer = gvSubModulo.GetSelectedRows()
            For i = 0 To arrayFilaSel.Length - 1 Step 1
                filaDatos = gvSubModulo.GetDataRow(arrayFilaSel(i))
                'codmenu1 As Integer, me1subme As String , me1modul As Integer, me1ofici As String, me1secue As Int16
                Dim item As New ENTIDADES.tb_cobmenu11 With {.codmenu1 = filaDatos.Item(0), .me1subme = filaDatos.Item(1),
                                                            .me1modul = filaDatos.Item(2), .me1ofici = filaDatos.Item(3),
                                                            .me1secue = filaDatos.Item(4)}
                lista.Add(item)
            Next
        End If

        Return lista
    End Function

    Private Sub goFormEventos()
        If gvSubModulo.RowCount > 0 Then
            Dim filaDatos As DataRow
            Dim arrayFilaSel() As Integer = gvSubModulo.GetSelectedRows()
            For i = 0 To arrayFilaSel.Length - 1 Step 1
                filaDatos = gvSubModulo.GetDataRow(arrayFilaSel(i))
                Dim item As New ENTIDADES.tb_cobmenu11 With {.codmenu1 = filaDatos.Item(0), .me1subme = filaDatos.Item(1),
                                            .me1modul = filaDatos.Item(2), .me1ofici = filaDatos.Item(3),
                                            .me1secue = filaDatos.Item(4)}
                Dim objForm As New UI_BCobmenu22(usuario, clave, item) With {.MdiParent = MdiParent}
                objForm.Show()

            Next
        End If
    End Sub

#End Region

#Region "[eventos]"

    Private Sub UI_BCobMenu11_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If lkModulo.EditValue > 0 Then
            Call getSubModuloXModulo()
        End If
    End Sub

    Private Sub btnListar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnListar.Click
        Call getSubModuloXModulo()
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Dim objFormModulo As New UI_CobMenu11(usuario, clave, 1) With {.MdiParent = MdiParent}
        objFormModulo.Show()
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        Dim lista As New List(Of ENTIDADES.tb_cobmenu11)()
        lista = getListaModulos()
        If lista.Count > 0 Then
            Dim objFormModulo As New UI_CobMenu11(usuario, clave, lista, 2) With {.MdiParent = MdiParent}
            objFormModulo.Show()
        Else
            DevExpress.XtraEditors.XtraMessageBox.Show("Primero debe seleccionar las fila(s) a actualizar", "Información",
                                                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim lista As New List(Of ENTIDADES.tb_cobmenu11)()
        lista = getListaModulos()
        If lista.Count > 0 Then
            Dim objFormModulo As New UI_CobMenu11(usuario, clave, lista, 3) With {.MdiParent = MdiParent}
            objFormModulo.Show()
        Else
            DevExpress.XtraEditors.XtraMessageBox.Show("Primero debe seleccionar las fila(s) a eliminar", "Información",
                                                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Call imprimirGrid(gcSubModulo)
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Call Close()
    End Sub

    Private Sub gcSubModulo_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gcSubModulo.DoubleClick
        Call goFormEventos()
    End Sub

#End Region

End Class