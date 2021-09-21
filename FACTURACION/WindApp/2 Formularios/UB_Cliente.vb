Imports Entidades
Imports WindApp.My.Resources
Imports DevExpress.XtraEditors
Public Class UB_Cliente : Inherits f_base

#Region "[atributosGlobales]"

    Private usuario As String
    Private clave As String

#End Region

#Region "[constructor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String)
        MyBase.New(usuar, clav, "DATOS DEL REGISTRO CLIENTES", "Realize la operacion necesaria...")
        InitializeComponent()
        usuario = usuar
        clave = clav
        Call getCliente()
    End Sub

#End Region

#Region "[metodos]"

    Private Sub getCliente()
        Using objCliente As New Negocios.ClienteInBL(usuario, clave)
            Dim dt As New DataTable
            dt = objCliente.getClienteInBL()
            If objCliente.existeError Then
                MessageBox.Show(objCliente.mensajesErrorSistema & vbNewLine & objCliente.mensajeErrorUsuarios, rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                gcCliente.DataSource = dt
            End If
        End Using
    End Sub

    Private Function getListaClienteIn() As List(Of Entidades.tb_clienteIn)
        Dim lista As New List(Of Entidades.tb_clienteIn)()
        If gvCliente.RowCount > 0 Then
            Dim filaDatos As DataRow
            Dim arrayFilaSel() As Integer = gvCliente.GetSelectedRows()
            For i = 0 To arrayFilaSel.Length - 1 Step 1
                filaDatos = gvCliente.GetDataRow(arrayFilaSel(i))

                Dim item As New Entidades.tb_clienteIn With {.codigoin = filaDatos.Item(0), .nombre = filaDatos.Item(1),
                                                            .apellido = filaDatos.Item(2), .nitci = filaDatos.Item(3)}
                lista.Add(item)
            Next
        End If
        Return lista
    End Function

    Private Sub imprimirGrid(ByVal gc As DevExpress.XtraGrid.GridControl)
        If Not gcCliente.IsPrintingAvailable Then
            MessageBox.Show("La libreria para poder imprir ...")
            Return
        End If
        gcCliente.ShowRibbonPrintPreview()
    End Sub

#End Region

#Region "Eventos"

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Dim objFormModulo As New UI_Cliente(usuario, clave, 1) With {.MdiParent = MdiParent}
        objFormModulo.Show()
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        Dim lista As New List(Of Entidades.tb_clienteIn)()
        lista = getListaClienteIn()
        If lista.Count > 0 Then
            Dim objFormModulo As New UI_Cliente(usuario, clave, lista, 2) With {.MdiParent = MdiParent}
            objFormModulo.Show()
        Else
            DevExpress.XtraEditors.XtraMessageBox.Show("Primero debe seleccionar las fila(s) a actualizar", rcRecursos.msTitulo,
                                                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim lista As New List(Of Entidades.tb_clienteIn)()
        lista = getListaClienteIn()
        If lista.Count > 0 Then
            Dim objFormModulo As New UI_Cliente(usuario, clave, lista, 3) With {.MdiParent = MdiParent}
            objFormModulo.Show()
        Else
            DevExpress.XtraEditors.XtraMessageBox.Show("Primero debe seleccionar las fila(s) a eliminar", rcRecursos.msTitulo,
                                                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Call imprimirGrid(gcCliente)
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Call Close()
    End Sub

#End Region

End Class