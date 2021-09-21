Imports Entidades
Imports Negocios
Imports DevExpress.XtraEditors
Imports WindApp.My.Resources
Public Class UI_AuxClientes : Inherits f_base

#Region "[atributosGlobales]"

    Private usuario As String
    Private clave As String

    Public Property codigo As String
    Public Property nombre As String
    Public Property telefono As String
    Public Property direccion As String

#End Region

#Region "[constructores]"

    Public Sub New(ByVal usuar As String, ByVal clav As String)
        MyBase.New(usuar, clav, "DATOS CLIENTES/PROVEEDOR", "Seleccione el cliente/prov.")
        InitializeComponent()
        usuario = usuar
        clave = clav
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
                                                           "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                lkNegocio.Properties.DataSource = dt
                lkNegocio.Properties.ValueMember = "coduneg"
                lkNegocio.Properties.DisplayMember = "unidad"
                lkNegocio.EditValue = dt.Rows(0).Item("coduneg")
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
                                                           "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                lkTipoCliente.Properties.DataSource = dt
                lkTipoCliente.Properties.ValueMember = "codigo"
                lkTipoCliente.Properties.DisplayMember = "descripcion"
                lkTipoCliente.EditValue = dt.Rows(0).Item("codigo")
            End If
            objUtilitario.finalizar()
        End Using
    End Sub

    Public Sub getClienteProvedorBL()
        If Not lkNegocio.EditValue Is Nothing AndAlso Not lkTipoCliente.EditValue Is Nothing Then
            If lkTipoCliente.EditValue <> "10003" Then
                Dim objConexion As New Negocios.UtilitarioBL(usuario, clave)

                Dim dtConexion As New DataTable
                If lkNegocio.EditValue = 1 Then
                    'pradcom
                    dtConexion = objConexion.getDatosConexion("93012", "1")
                ElseIf lkNegocio.EditValue = 2 Then
                    'expcarne
                    dtConexion = objConexion.getDatosConexion("88011", "1")
                Else
                    XtraMessageBox.Show("Solo estan habilitados Ciclo I y II", rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If
                Using objUtilitario As New Negocios.ClienteInBL(dtConexion)
                    Dim dt As New DataTable
                    dt = objUtilitario.getClienteProvedorBL(lkTipoCliente.EditValue)
                    If objUtilitario.existeError Then
                        XtraMessageBox.Show(String.Format("{0} {1}", objUtilitario.mensajesErrorSistema, objUtilitario.mensajeErrorUsuarios),
                                                                   "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        gcClientes.DataSource = dt
                    End If
                    objUtilitario.finalizar()
                End Using
            End If
        End If
    End Sub

    Private Sub capturarDatos()
        If gvClientes.RowCount > 0 Then
            codigo = If(IsDBNull(gvClientes.GetFocusedRowCellValue("codigo")), Nothing, gvClientes.GetFocusedRowCellValue("codigo"))
            nombre = If(IsDBNull(gvClientes.GetFocusedRowCellValue("nombre")), Nothing, gvClientes.GetFocusedRowCellValue("nombre"))
            telefono = If(IsDBNull(gvClientes.GetFocusedRowCellValue("telefono")), Nothing, gvClientes.GetFocusedRowCellValue("telefono"))
            direccion = If(IsDBNull(gvClientes.GetFocusedRowCellValue("direccion")), Nothing, gvClientes.GetFocusedRowCellValue("direccion"))
        End If
    End Sub

#End Region

#Region "[eventos]"

    Private Sub UI_AuxClientes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call getUnidad()
        Call getTipoCliente()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Call getClienteProvedorBL()
    End Sub

    Private Sub gvClientes_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gvClientes.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            Call capturarDatos()
            Call Close()
        End If
    End Sub

    Private Sub gvClientes_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gvClientes.DoubleClick
        Call capturarDatos()
        Call Close()
    End Sub

#End Region

End Class