Imports WindApp.My.Resources
Public Class UB_Empresa : Inherits f_base

#Region "[atributosGlobales]"

    Private usuario As String
    Private clave As String

#End Region

#Region "[contrutor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String)
        MyBase.New(usuar, clav, "DATOS DEL REGISTRO EMPRESA", "Realice la operacion necesaria...")
        InitializeComponent()
        usuario = usuar
        clave = clav

    End Sub

#End Region

#Region "[metodos]"

    Private Sub getEmpresa()
        Using objEmpresa As New Negocios.EmpresaBL(usuario, clave)
            Dim dt As New DataTable
            dt = objEmpresa.getEmpresaBL()
            If objEmpresa.existeError Then
                MessageBox.Show(objEmpresa.mensajesErrorSistema & vbNewLine & objEmpresa.mensajesErrorUsuario, rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                dgv.DataSource = dt
                For Each col As DataGridViewColumn In dgv.Columns
                    If col.HeaderText = "cod_actividad" Then
                        col.HeaderText = "CODIGO"
                    ElseIf col.HeaderText = "nomb_actividad" Then
                        col.HeaderText = "ACTIVIDAD"
                    ElseIf col.HeaderText = "nomb_empresa" Then
                        col.HeaderText = "EMPRESA"
                    ElseIf col.HeaderText = "ciudad" Then
                        col.HeaderText = "CIUDAD"
                    ElseIf col.HeaderText = "pais" Then
                        col.HeaderText = "PAIS"
                    ElseIf col.HeaderText = "direccion" Then
                        col.HeaderText = "DIRECCION"

                    ElseIf col.HeaderText = "cod_postal" Then
                        col.HeaderText = "COD POSTAL"
                    ElseIf col.HeaderText = "email" Then
                        col.HeaderText = "EMAIL"
                    ElseIf col.HeaderText = "telefono1" Then
                        col.HeaderText = "TELEFONO 1"
                    ElseIf col.HeaderText = "telefono2" Then 'sobdia
                        col.HeaderText = "TELEFORNO 2"
                    ElseIf col.HeaderText = "nic" Then
                        col.HeaderText = "NIC"

                    ElseIf col.HeaderText = "cns" Then 'reisob
                        col.HeaderText = "C.N.S."
                    End If
                    col.SortMode = DataGridViewColumnSortMode.NotSortable
                Next

                dgv.Columns(0).Width = 85
                dgv.Columns(1).Width = 300
                dgv.Columns(2).Width = 110
                dgv.Columns(3).Width = 100
                dgv.Columns(4).Width = 100
                dgv.Columns(5).Width = 85
                dgv.Columns(6).Width = 95
                dgv.Columns(7).Width = 150
                dgv.Columns(8).Width = 100
                dgv.Columns(9).Width = 100
                dgv.Columns(10).Width = 85
                dgv.Columns(11).Width = 85

            End If
            objEmpresa.finalizar()
        End Using
    End Sub

    Private Function getListaEmpresa() As List(Of Entidades.tb_empresa)
        Dim lista As New List(Of Entidades.tb_empresa)
        For Each fila As DataGridViewRow In dgv.SelectedRows
            If Not fila.Cells(0).Value Is Nothing Then
                Dim item As Entidades.tb_empresa = New Entidades.tb_empresa With {.cod_actividad = fila.Cells(0).Value}
                lista.Add(item)
            End If
        Next
        Return lista
    End Function

#End Region

#Region "[eventos]"

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Dim objFormModulo As New UI_Empresa(usuario, clave, 1) With {.MdiParent = MdiParent}
        objFormModulo.Show()
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        Dim lista As New List(Of Entidades.tb_empresa)()
        lista = getListaEmpresa()
        If lista.Count > 0 Then
            Dim objFormModulo As New UI_Empresa(usuario, clave, lista, 2) With {.MdiParent = MdiParent}
            objFormModulo.Show()
        Else
            MessageBox.Show("Primero debe seleccionar las fila(s) a actualizar", rcRecursos.msTitulo,
                                                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim lista As New List(Of Entidades.tb_empresa)()
        lista = getListaEmpresa()
        If lista.Count > 0 Then
            Dim objFormModulo As New UI_Empresa(usuario, clave, lista, 3) With {.MdiParent = MdiParent}
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

#End Region

End Class