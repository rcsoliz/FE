Public Class UI_PDatos : Inherits f_base

    Private usuario As String
    Private clave As String

    Public Sub New(ByVal usuar As String, ByVal clav As String)
        InitializeComponent()
        usuario = usuar
        clave = clav
    End Sub

    Public Sub cargarDatos()
        Using objConexion As New Negocios.ImportarBL(usuario, clave)

            Dim dtConecta As New DataTable
            dtConecta = objConexion.getDatosConexion("93699", "1")
            Dim oImportar As New Negocios.ImportarBL(dtConecta)

            Dim dt As New DataTable
            dt = oImportar.getPruebaBL()
            GridControl1.DataSource = dt


            'GridView1.Columns("").Summary(DevExpress.Data.SummaryItem 

            Call objConexion.finalizar()
        End Using

    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call cargarDatos()
    End Sub
End Class