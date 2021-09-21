Imports Entidades
Imports Negocios
Imports DevExpress.XtraEditors
Imports WindApp.My.Resources
Public Class UB_CarteraClientes : Inherits f_base

#Region "[atributosGlobales]"

    Private usuario As String
    Private clave As String
    Private lista As List(Of tb_clienteNegocio)
    Private opcion As Integer
    Private index As Integer

#End Region

#Region "[constructor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String)
        MyBase.New("DATOS COMPLEMENTARIOS CLIENTES ", "Realice la operación requerida...")
        InitializeComponent()
        usuario = usuar
        clave = clav
        Call getUnidad()
        Call getTipoCliente()

        Call getCliente()
    End Sub



#End Region

#Region "[metodos]"

    Private Sub getUnidad()
        Dim objConexion As New Negocios.UtilitarioBL(usuario, clave)
        Dim dtConexion As New DataTable
        dtConexion = objConexion.getDatosConexion("88002", "1")
        'abrimos database dbmystic
        Using objUtilitario As New Negocios.UtilitarioBL(dtConexion)
            Dim dt As New DataTable
            dt = objUtilitario.getNegocioBL()
            If objUtilitario.existeError Then
                XtraMessageBox.Show(String.Format("{0} {1}", objUtilitario.mensajesErrorSistema, objUtilitario.mensajesErrorUsuario),
                                                           rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                lkNegocio.DataSource = dt
                lkNegocio.DisplayMember = "unidad"
                lkNegocio.ValueMember = "coduneg"
            End If
            objUtilitario.finalizar()
        End Using
        'End If
    End Sub

    Private Sub getTipoCliente()
        Using objUtilitario As New Negocios.UtilitarioBL(usuario, clave)
            Dim dt As New DataTable
            dt = objUtilitario.getTipoClienteBL()
            If objUtilitario.existeError Then
                DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objUtilitario.mensajesErrorSistema, objUtilitario.mensajesErrorUsuario),
                                                           rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                lkTipoCliente.DataSource = dt
                lkTipoCliente.ValueMember = "codigo"
                lkTipoCliente.DisplayMember = "descripcion"
            End If
            objUtilitario.finalizar()
        End Using
    End Sub

    Private Sub getCliente()
        Using objCliente As New Negocios.ClienteNegocioBL(usuario, clave)
            Dim dt As New DataTable
            dt = objCliente.getClienteNegocioBL()
            If objCliente.existeError Then
                MessageBox.Show(objCliente.mensajesErrorSistema & vbNewLine & objCliente.mensajeErrorUsuarios, rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                gcClienteCom.DataSource = dt
            End If
        End Using
    End Sub

    Private Function getListaClienteIn() As List(Of Entidades.tb_clienteNegocio)
        Dim lista As New List(Of Entidades.tb_clienteNegocio)()
        If gvClienteCom.RowCount > 0 Then
            Dim filaDatos As DataRow
            Dim arrayFilaSel() As Integer = gvClienteCom.GetSelectedRows()
            For i = 0 To arrayFilaSel.Length - 1 Step 1
                filaDatos = gvClienteCom.GetDataRow(arrayFilaSel(i))

                Dim item As New Entidades.tb_clienteNegocio With {.codigoin = filaDatos.Item(0), .codigosistema = filaDatos.Item(1),
                                                                  .codunidad = filaDatos.Item(2)}
                lista.Add(item)
            Next
        End If
        Return lista
    End Function

    Private Sub imprimirGrid(ByVal gc As DevExpress.XtraGrid.GridControl)
        If Not gcClienteCom.IsPrintingAvailable Then
            MessageBox.Show("La libreria para poder imprir ...")
            Return
        End If
        gcClienteCom.ShowRibbonPrintPreview()
    End Sub

#End Region

#Region "[eventos]"

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Dim objFormModulo As New UI_CarteraCliente(usuario, clave, 1) With {.MdiParent = MdiParent}
        objFormModulo.Show()
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        Dim lista As New List(Of Entidades.tb_clienteNegocio)()
        lista = getListaClienteIn()
        If lista.Count > 0 Then
            Dim objFormModulo As New UI_CarteraCliente(usuario, clave, lista, 2) With {.MdiParent = MdiParent}
            objFormModulo.Show()
        Else
            XtraMessageBox.Show("Primero debe seleccionar las fila(s) a actualizar", rcRecursos.msTitulo,
                                 MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim lista As New List(Of Entidades.tb_clienteNegocio)()
        lista = getListaClienteIn()
        If lista.Count > 0 Then
            Dim objFormModulo As New UI_CarteraCliente(usuario, clave, lista, 3) With {.MdiParent = MdiParent}
            objFormModulo.Show()
        Else
            XtraMessageBox.Show("Primero debe seleccionar las fila(s) a actualizar", rcRecursos.msTitulo,
                                 MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Call imprimirGrid(gcClienteCom)
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Call Close()
    End Sub

#End Region

End Class