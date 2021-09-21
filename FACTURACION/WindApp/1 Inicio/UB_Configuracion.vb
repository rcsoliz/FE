Imports Negocios
Imports WindApp.My.Resources
Public Class UB_Configuracion : Inherits f_base

#Region "[atributosGlobales]"

    Private usuario As String
    Private clave As String

#End Region

#Region "[constructor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String)
        MyBase.New("Formulario datos Configuración", "Realice la operación requerida...")
        InitializeComponent()
        usuario = usuar
        clave = clav
    End Sub

#End Region

#Region "[metodos]"

    Private Sub getConfiguracion()
        Using oConfiguracion As New Negocios.ConfiguracionBL(usuario, clave)
            Dim dt As New DataTable
            dt = oConfiguracion.getConfiguracionBL()
            If oConfiguracion.existeError Then
                MessageBox.Show(oConfiguracion.mensajesErrorSistema & vbNewLine & oConfiguracion.mensajesErrorUsuario, rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                dgv.DataSource = dt
                If dgv.RowCount > 0 Then
                    For Each col As DataGridViewColumn In dgv.Columns
                        col.SortMode = DataGridViewColumnSortMode.NotSortable
                        If col.HeaderText = "codigo" Then
                            col.HeaderText = "Codigo"
                        ElseIf col.HeaderText = "cuis" Then
                            col.HeaderText = "Cuis"
                        ElseIf col.HeaderText = "urlcertificado" Then
                            col.HeaderText = "Url Certificado"
                        ElseIf col.HeaderText = "clave" Then
                            col.HeaderText = "Clave"
                        ElseIf col.HeaderText = "tambiente" Then
                            col.HeaderText = "Tipo Ambiente"
                        ElseIf col.HeaderText = "estado" Then
                            col.HeaderText = "Estado"
                        ElseIf col.HeaderText = "" Then
                            col.HeaderText = "Codigo Sistema"
                        End If
                        dgv.Columns(0).Width = 80
                        dgv.Columns(1).Width = 80
                        dgv.Columns(2).Width = 250
                        dgv.Columns(3).Width = 80
                        dgv.Columns(4).Width = 110
                        dgv.Columns(5).Width = 90
                        dgv.Columns(6).Width = 120
                        'select codigo, tri(cuis) cuis, trim(urlcertificado) urlcertificado, trim(clave) clave, trim(tambiente) tambiente, trim(estado) estado, codsistema
                    Next
                End If
            End If
            Call oConfiguracion.finalizar()
        End Using
    End Sub

    Private Function getListaCatalogo() As List(Of Entidades.tb_configuracion)
        Dim lista As New List(Of Entidades.tb_configuracion)()
        If dgv.RowCount > 0 Then
            For Each fila As DataGridViewRow In dgv.SelectedRows
                If Not fila.Cells(0).Value Is Nothing Then
                    'select codigo, tri(cuis) cuis, trim(urlcertificado) urlcertificado, trim(clave) clave, trim(tambiente) tambiente, trim(estado) estado
                    Dim item As New Entidades.tb_configuracion With {.codigo = fila.Cells(0).Value, .cuis = fila.Cells(1).Value,
                                                                     .urlcertificado = fila.Cells(2).Value, .clave = fila.Cells(3).Value,
                                                                     .tambiente = fila.Cells(4).Value, .estado = fila.Cells(5).Value,
                                                                     .codsistema = fila.Cells(6).Value}
                    lista.Add(item)
                End If
            Next
        End If
        Return lista
    End Function

#End Region

#Region "[eventos]"

    Private Sub UB_Configuracion_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Call getConfiguracion()
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Dim objFormModulo As New UI_Configuracion(usuario, clave, 1) With {.MdiParent = MdiParent}
        objFormModulo.Show()
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        Dim lista As New List(Of Entidades.tb_configuracion)()
        lista = getListaCatalogo()
        If lista.Count > 0 Then
            Dim objFormModulo As New UI_Configuracion(usuario, clave, lista, 2) With {.MdiParent = MdiParent}
            objFormModulo.Show()
        Else
            MessageBox.Show("Primero debe seleccionar las fila(s) a actualizar", rcRecursos.msTitulo,
                             MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim lista As New List(Of Entidades.tb_configuracion)()
        lista = getListaCatalogo()
        If lista.Count > 0 Then
            Dim objFormModulo As New UI_Configuracion(usuario, clave, lista, 3) With {.MdiParent = MdiParent}
            objFormModulo.Show()
        Else
            MessageBox.Show("Primero debe seleccionar las fila(s) a actualizar", rcRecursos.msTitulo,
                             MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Call Close()
    End Sub

#End Region


 
End Class