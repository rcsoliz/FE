Imports Entidades
Imports Negocios
Public Class UI_AuxVenta : Inherits f_base

#Region "[atributosGlobales]"

    Private usuario As String
    Private clave As String
    Private opcion As Integer
    Public Property codigo As String
    Public Property descripcion As String
    Public Property nroCorrelativo As String

#End Region

#Region "[constructores]"

    Public Sub New(ByVal usuar As String, ByVal clav As String, ByVal tit As String, ByVal opc As Integer)
        MyBase.New(usuar, clav, tit, "Realize la operacion necesaria...")
        InitializeComponent()
        usuario = usuar
        clave = clav
        opcion = opc
        If opcion = 1 Then
            getDatos()
        End If

    End Sub

#End Region

#Region "[metodos]"

    Private Sub getDatos()
        Dim objConexion As New Negocios.UtilitarioBL(usuario, clave)
        Dim dtConexion As New DataTable
        If opcion = 1 Then
            dtConexion = objConexion.getDatosConexion("93012", "1")
            'abrimos database pradcom
            Using objParametro As New Negocios.PreVentaBL(dtConexion)
                Dim dt As New DataTable
                dt = objParametro.getTipoDocumentoBL()
                If objParametro.existeError Then
                    DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objParametro.mensajesErrorSistema, objParametro.mensajesErrorUsuario),
                                                               "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    gcParame.DataSource = dt
                End If
                objParametro.finalizar()
            End Using
        End If
    End Sub

    Private Sub capturarDatos()
        If opcion = 1 Then
            codigo = If(IsDBNull(gvParame.GetFocusedRowCellValue("pacodigo")), Nothing, gvParame.GetFocusedRowCellValue("pacodigo"))
            descripcion = If(IsDBNull(gvParame.GetFocusedRowCellValue("tipo")), Nothing, gvParame.GetFocusedRowCellValue("tipo"))
            nroCorrelativo = If(IsDBNull(gvParame.GetFocusedRowCellValue("correlativo")), Nothing, gvParame.GetFocusedRowCellValue("correlativo"))
        End If
    End Sub

#End Region

#Region "[eventos]"

    Private Sub gvParame_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gvParame.DoubleClick
        Call capturarDatos()
        Call Close()
    End Sub

    Private Sub gvParame_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gvParame.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            Call capturarDatos()
            Call Close()
        End If
    End Sub

#End Region


End Class