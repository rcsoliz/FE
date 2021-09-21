Imports WindApp.My.Resources
Public Class UB_ParaFactura : Inherits f_base

#Region "[atributosGlobales]"

    Private usuario As String
    Private clave As String

#End Region

#Region "[contrutor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String)
        MyBase.New(usuar, clav, "DATOS PARÁMETROS MODULO FACTURACIÓN", "Realize la operacion necesaria...")
        InitializeComponent()
        usuario = usuar
        clave = clav
    End Sub

#End Region

#Region "[metodos]"

    Private Sub getEmpresa()
        Using objEmpresa As New Negocios.ParFacturaBL(usuario, clave)
            Dim dt As New DataTable
            dt = objEmpresa.getParametroBL()
            If objEmpresa.existeError Then
                MessageBox.Show(objEmpresa.mensajesErrorSistema & vbNewLine & objEmpresa.mensajesErrorUsuario, rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                dgv.DataSource = dt
                For Each col As DataGridViewColumn In dgv.Columns
                    If col.HeaderText = "codparame" Then 'codparame , trim(descripcion) descripcion, valor1, valor2, valor3
                        col.HeaderText = "CODIGO"
                    ElseIf col.HeaderText = "descripcion" Then
                        col.HeaderText = "ACTIVIDAD"
                    ElseIf col.HeaderText = "valor1" Then
                        col.HeaderText = "VALOR 1"
                    ElseIf col.HeaderText = "valor2" Then
                        col.HeaderText = "VALOR 2"
                    ElseIf col.HeaderText = "valor3" Then
                        col.HeaderText = "VALOR 3"
                    End If
                    col.SortMode = DataGridViewColumnSortMode.NotSortable
                Next

                dgv.Columns(0).Width = 85
                dgv.Columns(1).Width = 400
                dgv.Columns(2).Width = 110
                dgv.Columns(3).Width = 100
                dgv.Columns(4).Width = 100

            End If
            objEmpresa.finalizar()
        End Using
    End Sub

    Private Function getListaParFactura() As List(Of Entidades.tb_ParFatura)
        Dim lista As New List(Of Entidades.tb_ParFatura)
        For Each fila As DataGridViewRow In dgv.SelectedRows
            If Not fila.Cells(0).Value Is Nothing Then
                Dim item As Entidades.tb_ParFatura = New Entidades.tb_ParFatura With {.codparame = fila.Cells(0).Value}
                lista.Add(item)
            End If
        Next
        Return lista
    End Function

#End Region

#Region "[eventos]"

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Dim objFormModulo As New UI_ParaFactura(usuario, clave, 1) With {.MdiParent = MdiParent}
        objFormModulo.Show()
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        Dim lista As New List(Of Entidades.tb_ParFatura)()
        lista = getListaParFactura()
        If lista.Count > 0 Then
            Dim objFormModulo As New UI_ParaFactura(usuario, clave, lista, 2) With {.MdiParent = MdiParent}
            objFormModulo.Show()
        Else
            MessageBox.Show("Primero debe seleccionar las fila(s) a actualizar", rcRecursos.msTitulo,
                                                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim lista As New List(Of Entidades.tb_ParFatura)()
        lista = getListaParFactura()
        If lista.Count > 0 Then
            Dim objFormModulo As New UI_ParaFactura(usuario, clave, lista, 3) With {.MdiParent = MdiParent}
            objFormModulo.Show()
        Else
            MessageBox.Show("Primero debe seleccionar las fila(s) a actualizar", rcRecursos.msTitulo,
                                                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Call Close()
    End Sub

    Private Sub UB_Empresa_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Call getEmpresa()
    End Sub

    Private Sub dgv_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv.CellFormatting
        Try
            If dgv.RowCount > 0 Then
                If dgv.Columns(e.ColumnIndex).Name = "valor1" Then
                    Dim _filaDGV As DataGridViewRow = dgv.Rows(e.RowIndex)
                    If CStr(_filaDGV.Cells(2).Value) = "0" Then
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