Imports Entidades
Imports Negocios
Imports WindApp.My.Resources
Imports DevExpress.XtraGrid
Public Class UB_DocuIdentidad : Inherits f_base

#Region "[atributosGlobales]"

    Private usuario As String
    Private clave As String
    Private codModulo As Integer
    Private codPrograma As Integer

#End Region

#Region "[constructor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String, ByVal codMod As Integer, ByVal codProg As Integer)
        MyBase.New("Formulario de Ambintes", "Realice la operación requerida...")
        InitializeComponent()
        usuario = usuar
        clave = clav
        codModulo = codModulo : codPrograma = codProg
    End Sub

#End Region

#Region "[metodos]"

    Private Sub nuevo()
        'Using oPermiso As New Negocios.PermisoBL(usuario, clave)
        '    If oPermiso.allowAccesBL(libPermiso.alta, usuario, codModulo, codPrograma) Then
        Dim objFormModulo As New UI_DocuIdentidad(usuario, clave) With {.MdiParent = MdiParent}
        objFormModulo.Show()
        '    Else
        'MessageBox.Show(rcRecursos.msgAccesoGrabar, rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    End If
        'Call oPermiso.finalizar()
        'End Using
    End Sub

    Private Sub listar()
        'Using oPermiso As New Negocios.PermisoBL(usuario, clave)
        '    If oPermiso.allowAccesBL(libPermiso.consulta, usuario, codModulo, codPrograma) Then
        Using oParametroSin As New Negocios.DocuIdentidadSinBL(usuario, clave)
            Dim dt As New DataTable
            dt = oParametroSin.listarBL()
            If oParametroSin.existeError Then
                MessageBox.Show(oParametroSin.mensajesErrorSistema & vbNewLine & oParametroSin.mensajesErrorUsuario, rcRecursos.msTitulo,
                                 MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                If dt.Rows.Count > 0 Then
                    dgv.DataSource = dt
                    For Each column As DataGridViewColumn In dgv.Columns
                        column.SortMode = DataGridViewColumnSortMode.NotSortable
                    Next
                    dgv.Columns(0).HeaderText = "CODIGO"
                    dgv.Columns(1).HeaderText = "DESCRIPCION"

                    dgv.Columns(0).Width = 90
                    dgv.Columns(1).Width = 250
                End If
            End If
            Call oParametroSin.finalizar()
        End Using
        '    Else
        'MessageBox.Show(rcRecursos.msgAccesoConsulta, rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    End If
        'Call oPermiso.finalizar()
        'End Using
    End Sub

    Private Sub modificar()
        'Using oPermiso As New Negocios.PermisoBL(usuario, clave)
        '    If oPermiso.allowAccesBL(libPermiso.modifica, usuario, codModulo, codPrograma) Then
        Dim lista As New List(Of Entidades.tb_docuIdentidad)()
        lista = getLista()
        If lista.Count > 0 Then
            Dim objFormModulo As New UI_DocuIdentidad(usuario, clave, lista, 2) With {.MdiParent = MdiParent}
            objFormModulo.Show()
        Else
            DevExpress.XtraEditors.XtraMessageBox.Show("Primero debe seleccionar las fila(s) a actualizar", "Información",
                                                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        '    Else
        'MessageBox.Show(rcRecursos.msgAccesoModificar, rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    End If
        'Call oPermiso.finalizar()
        'End Using
    End Sub

    Private Sub eliminar()
        'Using oPermiso As New Negocios.PermisoBL(usuario, clave)
        '    If oPermiso.allowAccesBL(libPermiso.elimina, usuario, codModulo, codPrograma) Then
        Dim lista As New List(Of Entidades.tb_docuIdentidad)()
        lista = getLista()
        If lista.Count > 0 Then
            Dim objFormModulo As New UI_DocuIdentidad(usuario, clave, lista, 3) With {.MdiParent = MdiParent}
            objFormModulo.Show()
        Else
            DevExpress.XtraEditors.XtraMessageBox.Show("Primero debe seleccionar las fila(s) a eleiminar", "Información",
                                                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        '    Else
        'MessageBox.Show(rcRecursos.msgAccesoBaja, rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    End If
        'Call oPermiso.finalizar()
        'End Using
    End Sub

    Private Function getLista() As List(Of Entidades.tb_docuIdentidad)
        Dim lista As New List(Of Entidades.tb_docuIdentidad)
        For Each fila As DataGridViewRow In dgv.SelectedRows
            If Not fila.Cells(0).Value Is Nothing Then
                Dim item As Entidades.tb_docuIdentidad = New Entidades.tb_docuIdentidad With {.codigo = fila.Cells(0).Value}
                lista.Add(item)
            End If
        Next
        Return lista
    End Function

#End Region

#Region "[eventos]"

    Private Sub UB_Ambiente_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Call listar()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Call nuevo()
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        Call modificar()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Call eliminar()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Call Close()
    End Sub

#End Region

End Class