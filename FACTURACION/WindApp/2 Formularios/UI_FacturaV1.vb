Imports Entidades
Imports Negocios
Imports WindApp.My.Resources
Public Class UI_FacturaV1 : Inherits f_base

#Region "[AtributosGlobales]"

    Private usuario As String
    Private clave As String

#End Region

#Region "[Constructor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String)
        MyBase.New(usuar, clav, "", "Realice la operacion necesaria...")
        InitializeComponent()
        usuario = usuar
        clave = clav
    End Sub

#End Region

#Region "[Constructor]"

    Private Sub getTipoSolicitud()
        Dim objConexion As New Negocios.UtilitarioBL(usuario, clave)
        Dim dtConexion As New DataTable
        dtConexion = objConexion.getDatosConexion("93012", actGlobal)
        Using oUtilitario As New Negocios.UtilitarioBL(dtConexion)
            Dim dt As New DataTable
            dt = oUtilitario.getTipoDocumentoBL()
            If oUtilitario.existeError Then
                MessageBox.Show(oUtilitario.mensajesErrorSistema & " " & oUtilitario.mensajesErrorUsuario, rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                cbxTipoDocumento.DataSource = dt
                cbxTipoDocumento.ValueMember = "codigo"
                cbxTipoDocumento.DisplayMember = "tipo"
            End If
        End Using
    End Sub

#End Region

#Region "[eventos]"

#End Region

End Class