Imports DevExpress.XtraGrid

Public Class UB_Catalogo : Inherits f_base

#Region "[atributosGlobales]"

    Private usuario As String
    Private clave As String

#End Region

#Region "[constructor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String)
        MyBase.New(usuar, clav, "DATOS CATALOGO FACTURACIÓN ELECTRÓNICA", "Realice la operación requerida...")
        InitializeComponent()
        usuario = usuar
        clave = clav
    End Sub

#End Region

#Region "[metodos]"

    Private Sub getCatalogo()
        Using objCatalogo As New Negocios.CatalogoBL(usuario, clave)
            Dim dt As New DataTable
            dt = objCatalogo.getCatalogoBL()
            If objCatalogo.existeError Then
                DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objCatalogo.mensajesErrorSistema, objCatalogo.mensajesErrorUsuario),
                                                          "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                gcCatalogo.DataSource = dt
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

    Private Function getListaCatalogo() As List(Of Entidades.tb_CatalogoFe)
        Dim lista As New List(Of Entidades.tb_CatalogoFe)()
        If gvCatalogo.RowCount > 0 Then

            Dim filaDatos As DataRow
            Dim arrayFilaSel() As Integer = gvCatalogo.GetSelectedRows()
            For i = 0 To arrayFilaSel.Length - 1 Step 1
                filaDatos = gvCatalogo.GetDataRow(arrayFilaSel(i))
                Dim item As New Entidades.tb_CatalogoFe With {.tipo = filaDatos.Item(0), .codigo = filaDatos.Item(1),
                                                            .nombre = filaDatos.Item(2)}
                lista.Add(item)
            Next
        End If
        Return lista
    End Function

#End Region

#Region "[eventos]"

    Private Sub UB_Catalogo_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Call getCatalogo()
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Dim objFormModulo As New UI_Catalogo(usuario, clave, 1) With {.MdiParent = MdiParent}
        objFormModulo.Show()
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        Dim lista As New List(Of Entidades.tb_CatalogoFe)()
        lista = getListaCatalogo()
        If lista.Count > 0 Then
            Dim objFormModulo As New UI_Catalogo(usuario, clave, lista, 2) With {.MdiParent = MdiParent}
            objFormModulo.Show()
        Else
            DevExpress.XtraEditors.XtraMessageBox.Show("Primero debe seleccionar las fila(s) a actualizar", "Información",
                                                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim lista As New List(Of Entidades.tb_CatalogoFe)()
        lista = getListaCatalogo()
        If lista.Count > 0 Then
            Dim objFormModulo As New UI_Catalogo(usuario, clave, lista, 3) With {.MdiParent = MdiParent}
            objFormModulo.Show()
        Else
            DevExpress.XtraEditors.XtraMessageBox.Show("Primero debe seleccionar las fila(s) a eliminar", "Información",
                                                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Call imprimirGrid(gcCatalogo)
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Call Close()
    End Sub

#End Region

End Class