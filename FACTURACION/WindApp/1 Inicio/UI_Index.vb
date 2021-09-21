Imports System.IO
Imports System.Net
Imports System.Runtime.InteropServices

Public Class UI_Index

#Region "[atributosGlobales]"

    Private usuario As String
    Private clave As String
    'Private codActividad As String

#End Region

#Region "[contrutor]"

    Public Sub New()
        InitializeComponent()
        usuario = "frigor"
        clave = "mandioka"
        'codActividad = "1"
        actGlobal = 1
    End Sub

    Public Sub New(ByVal usuar As String, ByVal clav As String, ByVal codAct As String)
        InitializeComponent()
        usuario = usuar
        clave = clav
        'codActividad = codAct
        actGlobal = 1
    End Sub

#End Region

#Region "[metodos]"

#End Region

#Region "[eventos]"

    Private Sub DatosEmpresaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DatosEmpresaToolStripMenuItem.Click
        Dim obManejador As New UB_Empresa("mystic", "mystic") With {.MdiParent = Me}
        obManejador.Show()
    End Sub

    Private Sub FacturaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacturaToolStripMenuItem.Click
        Dim obManejador As New UI_Factura("mystic", "mystic") With {.MdiParent = Me}
        obManejador.Show()
    End Sub

    Private Sub ParametroFacturasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ParametroFacturasToolStripMenuItem.Click
        Dim obManejador As New UB_ParaFactura("mystic", "mystic") With {.MdiParent = Me}
        obManejador.Show()
    End Sub

    Private Sub AlgoritmosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AlgoritmosToolStripMenuItem.Click
        Dim obManejador As New UI_Pruebas("mystic", "mystic") With {.MdiParent = Me}
        obManejador.Show()
    End Sub

    Private Sub PruebasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PruebasToolStripMenuItem.Click
        Dim obManejador As New UI_PruebaGrid("mystic", "mystic") With {.MdiParent = Me}
        obManejador.Show()
    End Sub

    Private Sub FechasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FechasToolStripMenuItem.Click
        Dim obManejador As New UB_FechasFacturas("mystic", "mystic") With {.MdiParent = Me}
        obManejador.Show()
    End Sub
    Private Sub CierreVentasAutomaticosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CierreVentasAutomaticosToolStripMenuItem.Click
        Dim obManejador As New UI_CierreVentas("mystic", "mystic") With {.MdiParent = Me}
        obManejador.Show()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Dim obManejador As New UB_USUARIO("frigor", "mandioka") With {.MdiParent = Me}
        'obManejador.Show()
        'Dim obManejador As New Form1("frigor", "mandioka") With {.MdiParent = Me}
        'obManejador.Show()

        'Dim obManejador As New UI_ImportarClie("frigor", "mandioka") With {.MdiParent = Me}
        'obManejador.Show()

        'Dim obManejador As New UI_PDatos("frigor", "mandioka") With {.MdiParent = Me}
        'obManejador.Show()

        'Dim obManejador As New UI_PruebaCUFD("frigor", "mandioka") With {.MdiParent = Me}
        'obManejador.Show()

        'Dim obManejador As New UI_Pruebas("frigor", "mandioka") With {.MdiParent = Me}
        'obManejador.Show()

        Dim obManejador As New UI_FechaSistema("frigor", "mandioka") With {.MdiParent = Me}
        obManejador.Show()
    End Sub

    Private Sub UsuariosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UsuariosToolStripMenuItem.Click
        Dim recepcion2 As New UB_USUARIO("frigor", "mandioka") With {.MdiParent = Me}
        recepcion2.Show()
    End Sub

    Private Sub ModulosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModulosToolStripMenuItem.Click
        Dim recepcion2 As New UI_BModulos("frigor", "mandioka") With {.MdiParent = Me}
        recepcion2.Show()
    End Sub

    Private Sub MenusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenusToolStripMenuItem.Click
        Dim recepcion2 As New UI_BCobMenu11("frigor", "mandioka") With {.MdiParent = Me}
        recepcion2.Show()
    End Sub

    Private Sub VentasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VentasToolStripMenuItem.Click
        Dim recepcion2 As New UI_Venta("frigor", "mandioka") With {.MdiParent = Me}
        recepcion2.Show()
    End Sub

    Private Sub ClientsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClientsToolStripMenuItem.Click
        Dim recepcion2 As New UB_Cliente("frigor", "mandioka") With {.MdiParent = Me}
        recepcion2.Show()
    End Sub

    Private Sub CarteraDeClientesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CarteraDeClientesToolStripMenuItem.Click
        Dim recepcion2 As New UB_CarteraClientes("frigor", "mandioka") With {.MdiParent = Me}
        recepcion2.Show()
    End Sub


    Private Sub UI_Index_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Call crearDirectorio(usuario)
        Location = Screen.PrimaryScreen.WorkingArea.Location
        Size = Screen.PrimaryScreen.WorkingArea.Size
        '   Dim obi As Bitmap = WinApp.My.Resources.Aceptar16x16


    End Sub

#End Region

#Region "[eventos]"

    Private Sub crearDirectorio(ByVal usuario_ As String)
        If clDirectorio.crearDirectorio(usuario_) = False Then

            MessageBox.Show("ERROR !!!", String.Format("Su directorio de trabajo no se ha creado.{0}Contacte a su administrador de sistemas. No continue trabajando con MYSTIC hasta que su problema sea resuelto.", vbNewLine))
        Else
            'If Not File.Exists("C:\Mystic\Cargando.exe") Then
            '    Try
            '        If My.Computer.Network.IsAvailable Then
            '            My.Computer.Network.DownloadFile("\\Update\update\Recursos\Cargando.exe", "C:\Mystic\Cargando.exe")
            '        End If
            '    Catch ex As Exception

            '    End Try
            'End If
        End If
    End Sub

    Private Sub CatalogoSINToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CatalogoSINToolStripMenuItem.Click
        Dim obManejador As New UB_Catalogo("mystic", "mystic") With {.MdiParent = Me}
        obManejador.Show()
    End Sub

#End Region

  
    Private Sub ConfiguraciónBasicaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfiguraciónBasicaToolStripMenuItem.Click
        Dim obManejador As New UB_Configuracion("mystic", "mystic") With {.MdiParent = Me}
        obManejador.Show()
    End Sub


  
    Private Sub TiposDeAmbientesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TiposDeAmbientesToolStripMenuItem.Click
        Dim oForm As New UB_Ambinte("mystic", "mystic", 1, 2) With {.MdiParent = Me}
        oForm.Show()
    End Sub

    Private Sub DocumentosFiscalesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DocumentosFiscalesToolStripMenuItem.Click
        Dim oForm As New UB_DocuFiscales("mystic", "mystic", 1, 2) With {.MdiParent = Me}
        oForm.Show()
    End Sub

    Private Sub TiposDocumentosIdentidadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TiposDocumentosIdentidadToolStripMenuItem.Click
        Dim oForm As New UB_DocuIdentidad("mystic", "mystic", 1, 2) With {.MdiParent = Me}
        oForm.Show()
    End Sub

    Private Sub DocumentosPorSectorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DocumentosPorSectorToolStripMenuItem.Click
        Dim oForm As New UB_DocuSector("mystic", "mystic", 1, 2) With {.MdiParent = Me}
        oForm.Show()
    End Sub

    Private Sub EventosSignificativosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EventosSignificativosToolStripMenuItem.Click
        Dim oForm As New UB_EvenSignificativo("mystic", "mystic", 1, 2) With {.MdiParent = Me}
        oForm.Show()
    End Sub

    Private Sub MensajesSoapToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MensajesSoapToolStripMenuItem.Click
        Dim oForm As New UB_MensSoap("mystic", "mystic", 1, 2) With {.MdiParent = Me}
        oForm.Show()
    End Sub

    Private Sub MetodosDePagoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetodosDePagoToolStripMenuItem.Click
        Dim oForm As New UB_MetoPago("mystic", "mystic", 1, 2) With {.MdiParent = Me}
        oForm.Show()
    End Sub

    Private Sub ModalidadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModalidadToolStripMenuItem.Click
        Dim oForm As New UB_Modalidad("mystic", "mystic", 1, 2) With {.MdiParent = Me}
        oForm.Show()
    End Sub

    Private Sub MonedaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonedaToolStripMenuItem.Click
        Dim oForm As New UB_Moneda("mystic", "mystic", 1, 2) With {.MdiParent = Me}
        oForm.Show()
    End Sub

    Private Sub MotivoAnulacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MotivoAnulacionToolStripMenuItem.Click
        Dim oForm As New UB_MotiAnulacion("mystic", "mystic", 1, 2) With {.MdiParent = Me}
        oForm.Show()
    End Sub

    Private Sub PaisesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaisesToolStripMenuItem.Click
        Dim oForm As New UB_Pais("mystic", "mystic", 1, 2) With {.MdiParent = Me}
        oForm.Show()
    End Sub

    Private Sub TipoDeEmisiónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TipoDeEmisiónToolStripMenuItem.Click
        Dim oForm As New UB_TipoEmsion("mystic", "mystic", 1, 2) With {.MdiParent = Me}
        oForm.Show()
    End Sub

    Private Sub TiposDeUnidadesDeMedidaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TiposDeUnidadesDeMedidaToolStripMenuItem.Click
        Dim oForm As New UB_UnidMedida("mystic", "mystic", 1, 2) With {.MdiParent = Me}
        oForm.Show()
    End Sub

    Private Sub SincronizacionFechaYHorasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SincronizacionFechaYHorasToolStripMenuItem.Click
        Dim oForm As New UI_FechaSistema("mystic", "mystic") With {.MdiParent = Me}
        oForm.Show()
    End Sub
End Class