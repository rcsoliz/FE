Imports Entidades
Imports System.Data
Imports System.Windows.Forms
Imports DevExpress.XtraGrid
Imports System.Collections
Imports System.IO
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraPrintingLinks

Public Class UB_USUARIO : Inherits f_base

#Region "[atributosGlobales]"

    Private usuario As String
    Private clave As String
    Private mi_grillas As DataGridView

#End Region

#Region "[constructor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String)
        MyBase.New(usuar, clav, "FORMULARIO DATOS USUARIOS ", "Realice la operación requerida...")
        InitializeComponent()
        usuario = usuar
        clave = clav
        Call getCategoria()
        Call getCategoriaI()
    End Sub

#End Region

#Region "[metodos]"

    Private Sub getCategoria()
        Using objUsuario As New Negocios.usuariong(usuario, clave)
            Dim datos_tabla As New DataTable()
            datos_tabla = objUsuario.getCategoriaDeUsuariosBL()
            If objUsuario.existeError Then
                MessageBox.Show(objUsuario.mensaje_ErrorSistema & objUsuario.mensaje_ErrorUsuario, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                lkCategoria.DataSource = datos_tabla
                lkCategoria.ValueMember = "pacodigo"
                lkCategoria.DisplayMember = "padescri"
            End If

        End Using
    End Sub

    Private Sub getCategoriaI()
        Using objUsuario As New Negocios.usuariong(usuario, clave)
            Dim datos_tabla As New DataTable()
            datos_tabla = objUsuario.getCategoriaDeUsuariosBL()
            If objUsuario.existeError Then
                MessageBox.Show(objUsuario.mensaje_ErrorSistema & objUsuario.mensaje_ErrorUsuario, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                lkCategoriaBaja.DataSource = datos_tabla
                lkCategoriaBaja.ValueMember = "pacodigo"
                lkCategoriaBaja.DisplayMember = "padescri"
            End If

        End Using
    End Sub

    Public Sub getUsuarios(ByVal item As Entidades.tb_Cobusuar)
        Using objUsuario As New Negocios.usuariong(usuario, clave)
            Dim dtUsuario As New DataTable
            dtUsuario = objUsuario.getUsuariosBL(item)
            If objUsuario.existeError Then
                MessageBox.Show(objUsuario.mensaje_ErrorSistema & vbNewLine & objUsuario.mensaje_ErrorUsuario, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                If item.usrestad = "a" Then
                    GcUsuarioA.DataSource = dtUsuario
                Else
                    GcUsuarioI.DataSource = dtUsuario
                End If
            End If
        End Using
    End Sub

    Private Function getListaEvento() As List(Of Entidades.tb_Cobusuar)
        Dim lista As New List(Of Entidades.tb_Cobusuar)()
        If gvUsuarioA.RowCount > 0 Then
            Dim filaDatos As DataRow
            Dim arrayFilaSel() As Integer = gvUsuarioA.GetSelectedRows()
            For i = 0 To arrayFilaSel.Length - 1 Step 1
                filaDatos = gvUsuarioA.GetDataRow(arrayFilaSel(i))
                Dim item As New Entidades.tb_Cobusuar With {.usrlogin = filaDatos.Item(0)}
                lista.Add(item)
            Next
        End If
        Return lista
    End Function

    Private Function getListaEventoI() As List(Of Entidades.tb_Cobusuar)
        Dim lista As New List(Of Entidades.tb_Cobusuar)()
        If gvUsuarioI.RowCount > 0 Then
            Dim filaDatos As DataRow
            Dim arrayFilaSel() As Integer = gvUsuarioI.GetSelectedRows()
            For i = 0 To arrayFilaSel.Length - 1 Step 1
                filaDatos = gvUsuarioI.GetDataRow(arrayFilaSel(i))
                Dim item As New Entidades.tb_Cobusuar With {.usrlogin = filaDatos.Item(0)}
                lista.Add(item)
            Next
        End If
        Return lista
    End Function

    Private Function obtenerListaConcepto(ByVal mi_grilla_ As DataGridView) As ArrayList
        Dim lista As New ArrayList
        lista.Add(gvUsuarioA.GetFocusedRowCellValue(GridColumn1).ToString)
        Return lista
    End Function

    Private Sub printGrid(ByVal gv As GridControl)
        If Not gv.IsPrintingAvailable Then
            MessageBox.Show("No se encuentra la biblioteca 'DevExpress.XtraPrinting' ", " Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        gv.Print()
    End Sub

    Private Sub exportar()
        Using saveDialog As New SaveFileDialog
            saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html"
            If saveDialog.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
                Dim exportFilePath As String = saveDialog.FileName
                Dim fileExtenstion As String = New FileInfo(exportFilePath).Extension
                Select Case fileExtenstion

                End Select

            End If

        End Using
    End Sub

    Public Sub exportToExcel(ByVal gc As GridControl)
        Using saveDialog = New SaveFileDialog()
            saveDialog.Filter = "Excel (.xlsx)|*.xlsx"

            If saveDialog.ShowDialog() = DialogResult.OK Then
                Dim printingSystem = New PrintingSystemBase()
                Dim compositeLink = New CompositeLinkBase()
                compositeLink.PrintingSystemBase = printingSystem
                Dim link1 = New PrintableComponentLinkBase()
                link1.Component = gc

                compositeLink.Links.Add(link1)
                Dim options = New XlsxExportOptions()
                options.ExportMode = XlsxExportMode.SingleFilePageByPage
                compositeLink.CreatePageForEachLink()
                compositeLink.ExportToXlsx(saveDialog.FileName, options)
            End If
        End Using
    End Sub

#End Region

#Region "[eventos]"

    Private Sub UB_USUARIO_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Dim item As New Entidades.tb_Cobusuar With {.usrestad = "a"}
        Call getUsuarios(item)
        item = New Entidades.tb_Cobusuar With {.usrestad = "i"}
        Call getUsuarios(item)
    End Sub

    Private Sub btnAgregarA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim objForm As New UI_USUARIO(usuario, clave) With {.MdiParent = MdiParent}
        objForm.Show()
    End Sub

    Private Sub btnAgregarA_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarA.Click
        Dim objUsuario As New UI_USUARIO(usuario, clave) With {.MdiParent = MdiParent}
        objUsuario.Show()
    End Sub

    Private Sub btnModificarA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificarA.Click
        Dim lista As New List(Of Entidades.tb_Cobusuar)()
        lista = getListaEvento()
        If lista.Count > 0 Then
            Dim objFormModulo As New UI_USUARIO(usuario, clave, lista, 2) With {.MdiParent = MdiParent}
            objFormModulo.Show()
        Else
            DevExpress.XtraEditors.XtraMessageBox.Show("Primero debe seleccionar las fila(s) a actualizar", "Información",
                                                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btnEliminarA_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarA.Click
        Dim lista As New List(Of Entidades.tb_Cobusuar)()
        lista = getListaEvento()
        If lista.Count > 0 Then
            Dim objFormModulo As New UI_USUARIO(usuario, clave, lista, 3) With {.MdiParent = MdiParent}
            objFormModulo.Show()
        Else
            DevExpress.XtraEditors.XtraMessageBox.Show("Primero debe seleccionar las fila(s) a actualizar", "Información",
                                                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btnImprimirA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirA.Click
        Call printGrid(GcUsuarioA)
    End Sub

    Private Sub btnExportarA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportarA.Click
        Call exportToExcel(GcUsuarioA)
    End Sub

    Private Sub btnAsignacionA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAsignacionA.Click
        Dim objFormModulo As New UI_BCobAcces1(usuario, clave) With {.MdiParent = MdiParent}
        objFormModulo.Show()
    End Sub

    Private Sub btnSalirA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalirA.Click
        Call Close()
    End Sub



    Private Sub btnActivarI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActivarI.Click
        Dim lista As New List(Of Entidades.tb_Cobusuar)()
        lista = getListaEventoI()
        If lista.Count > 0 Then
            Dim objFormModulo As New UI_USUARIO(usuario, clave, lista, 2) With {.MdiParent = MdiParent}
            objFormModulo.Show()
        Else
            DevExpress.XtraEditors.XtraMessageBox.Show("Primero debe seleccionar las fila(s) a actualizar", "Información",
                                                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btnImprimirI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirI.Click
        Call printGrid(GcUsuarioI)
    End Sub

    Private Sub btnExportarI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportarI.Click
        Call exportToExcel(GcUsuarioI)
    End Sub

    Private Sub btnAsignacionI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAsignacionI.Click
        Dim objFormModulo As New UI_BCobAcces1(usuario, clave) With {.MdiParent = MdiParent}
        objFormModulo.Show()
    End Sub

    Private Sub btnSalirI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalirI.Click
        Call Close()
    End Sub

#End Region

End Class