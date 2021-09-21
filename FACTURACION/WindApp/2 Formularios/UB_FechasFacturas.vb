Imports WindApp.My.Resources
Public Class UB_FechasFacturas : Inherits f_base

#Region "[atributosGlobales]"

    Private usuario As String
    Private clave As String

#End Region

#Region "[contrutor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String)
        MyBase.New(usuar, clav, "DATOS FECHAS-FACTURAS MODULO FACTURACIÓN", "Realize la operacion necesaria...")
        InitializeComponent()
        usuario = usuar
        clave = clav

    End Sub

#End Region

#Region "[metodos]"

    Private Sub getFechasFacturas()
        Using objFechaFact As New Negocios.FechaFacturasBL(usuario, clave)
            Dim dt As New DataTable
            dt = objFechaFact.getGestionBL()
            If objFechaFact.existeError Then
                MessageBox.Show(objFechaFact.mensajesErrorSistema & vbNewLine & objFechaFact.mensajesErrorUsuario, rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                dgv.DataSource = dt 'gestion, descmes mes, descestado, estado
                For Each col As DataGridViewColumn In dgv.Columns
                    If col.HeaderText = "gestion" Then
                        col.HeaderText = "GESTION"

                    ElseIf col.HeaderText = "descmes" Then
                        col.HeaderText = "MESES"
                    ElseIf col.HeaderText = "mes" Then
                        col.Visible = False

                    ElseIf col.HeaderText = "descestado" Then
                        col.HeaderText = "ESTADO"
                    ElseIf col.HeaderText = "estado" Then
                        col.Visible = False
                    End If

                    col.SortMode = DataGridViewColumnSortMode.NotSortable
                Next

                dgv.Columns(0).Width = 100
                dgv.Columns(1).Width = 110
                dgv.Columns(2).Width = 110
                dgv.Columns(3).Width = 110
                dgv.Columns(4).Width = 110

            End If
            objFechaFact.finalizar()
        End Using
    End Sub

    Private Function getListaParFactura() As List(Of Entidades.tb_FechasFactura)
        Dim lista As New List(Of Entidades.tb_FechasFactura)
        For Each fila As DataGridViewRow In dgv.SelectedRows
            If Not fila.Cells(0).Value Is Nothing Then
                Dim item As Entidades.tb_FechasFactura = New Entidades.tb_FechasFactura With {.gestion = fila.Cells(0).Value,
                                                                                              .mes = fila.Cells(2).Value,
                                                                                              .estado = fila.Cells(4).Value}
                lista.Add(item)
            End If
        Next
        Return lista
    End Function

#End Region

#Region "[eventos]"

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Dim objFormModulo As New UI_FechasFacturas(usuario, clave, 1) With {.MdiParent = MdiParent}
        objFormModulo.Show()
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        Dim lista As New List(Of Entidades.tb_FechasFactura)()
        lista = getListaParFactura()
        If lista.Count > 0 Then
            Dim objFormModulo As New UI_FechasFacturas(usuario, clave, lista, 2) With {.MdiParent = MdiParent}
            objFormModulo.Show()
        Else
            MessageBox.Show("Primero debe seleccionar las fila(s) a actualizar", rcRecursos.msTitulo,
                                                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim lista As New List(Of Entidades.tb_FechasFactura)()
        lista = getListaParFactura()
        If lista.Count > 0 Then
            Dim objFormModulo As New UI_FechasFacturas(usuario, clave, lista, 3) With {.MdiParent = MdiParent}
            objFormModulo.Show()
        Else
            MessageBox.Show("Primero debe seleccionar las fila(s) a actualizar", rcRecursos.msTitulo,
                                                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Call Close()
    End Sub

    Private Sub UB_FechasFacturas_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Call getFechasFacturas()
    End Sub

    Private Sub dgv_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv.CellFormatting
        Try
            If dgv.RowCount > 0 Then
                If dgv.Columns(e.ColumnIndex).Name = "gestion" Then
                    Dim _filaDGV As DataGridViewRow = dgv.Rows(e.RowIndex)
                    If CStr(_filaDGV.Cells(4).Value) = "0" Then
                        _filaDGV.DefaultCellStyle.ForeColor = Color.Red
                        _filaDGV.DefaultCellStyle.BackColor = Color.LightGray
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region

End Class