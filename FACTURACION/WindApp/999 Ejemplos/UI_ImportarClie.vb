Imports Entidades
Imports Negocios
Imports DevExpress.XtraEditors
Imports WindApp.My.Resources
Public Class UI_ImportarClie : Inherits f_base

#Region "[atributosGlobales]"

    Private usuario As String
    Private clave As String
    Private lista As List(Of Entidades.tb_clienteIn)
    Private listaCuerProveedor As List(Of Entidades.tb_cueimport)
    Private listaProve As List(Of Entidades.tb_cabimport)
    Private correlativo As Integer

#End Region

#Region "[constructor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String)
        MyBase.New("", "", usuar, clav)
        InitializeComponent()
        usuario = usuar
        clave = clav
        lista = New List(Of Entidades.tb_clienteIn)

        listaCuerProveedor = New List(Of Entidades.tb_cueimport)
        listaProve = New List(Of Entidades.tb_cabimport)
        correlativo = 0
    End Sub

#End Region

#Region "[metodos]"


    Private Sub listarDatos()
        If Not String.IsNullOrEmpty(txtCodDoc.Text) Then

            Using objImportar As New Negocios.ImportarBL(usuario, clave)

                Dim dtConecta As New DataTable
                dtConecta = objImportar.getDatosConexion("88051", "1")
                Dim oImportar As New Negocios.ImportarBL(dtConecta)

                Dim dt As New DataTable
                dt = oImportar.getClientesFacturaBL(txtCodDoc.Text)
                gcCliente.DataSource = dt

            End Using
        End If
    End Sub




    Private Sub listarProveedor(ByVal tServicio As String)
        If Not String.IsNullOrEmpty(txtCodDoc.Text) Then
            If tServicio = "10002" Then 'proveedor
                listaProve = New List(Of Entidades.tb_cabimport)
                Dim listaAux As New List(Of Entidades.tb_cabimport)

                Using objImportar As New Negocios.ImportarBL(usuario, clave)

                    'Dim correlativo As Integer
                    correlativo = objImportar.getCorrelativoBL()

                    Dim dtConecta As New DataTable
                    dtConecta = objImportar.getDatosConexion("88051", "1")
                    Dim oImportar As New Negocios.ImportarBL(dtConecta)

                    Dim dtbase As New DataTable
                    dtbase = oImportar.getClientesFacturaBL(txtCodDoc.Text)

                    If dtbase.Rows.Count > 0 Then

                        Dim dtConexion As New DataTable
                        dtConexion = objImportar.getDatosConexion(txtCodDoc.Text, txtActividad.Text)

                        Using objImpCliente As New Negocios.ImportarBL(dtConexion)

                            'listaProve = objImpCliente.listarClienteProveedorBL(dtbase, correlativo)
                            'gcCliente.DataSource = listaProve
                            listaAux = objImpCliente.listarProveedorBL(dtbase, correlativo)
                            listaProve = objImportar.verificarProveedorBL(listaAux, txtTCliente.Text)

                            gcCliente.DataSource = listaProve

                            Call listarCuerpoProveedor(listaProve)
                        End Using

                    End If
                End Using
            ElseIf tServicio = "10001" Then 'cliente
                listaProve = New List(Of Entidades.tb_cabimport)
                Dim listaAux As New List(Of Entidades.tb_cabimport)

                Using objImportar As New Negocios.ImportarBL(usuario, clave)

                    correlativo = objImportar.getCorrelativoBL()

                    Dim dtConecta As New DataTable
                    dtConecta = objImportar.getDatosConexion("88051", "1")
                    Dim oImportar As New Negocios.ImportarBL(dtConecta)

                    Dim dtbase As New DataTable
                    dtbase = oImportar.getClientesFacturaBL(txtCodDoc.Text)

                    If dtbase.Rows.Count > 0 Then
                        Dim dtConexion As New DataTable
                        'Dim actividad As String = 1

                        If txtCodDoc.Text = "93711" Then
                            txtActividad.Text = "3"
                        End If

                        dtConexion = objImportar.getDatosConexion(txtCodDoc.Text, txtActividad.Text)

                        Using objImpCliente As New Negocios.ImportarBL(dtConexion)

                            Dim esMenudo As Boolean = False
                            If txtCodDoc.Text = "93711" Then
                                esMenudo = True
                            End If

                            listaAux = objImpCliente.listarClienteBL(dtbase, correlativo, esMenudo, txtUnidad.Text)
                            listaProve = objImportar.verificarClienteBL(listaAux, txtTCliente.Text, txtUnidad.Text)

                            gcCliente.DataSource = listaProve

                            Call listarCuerpoCliente(listaProve)
                        End Using
                    End If

                End Using
            End If
        End If
    End Sub

    Private Sub listarCuerpoProveedor(ByVal lista As List(Of Entidades.tb_cabimport))
        listaCuerProveedor = New List(Of Entidades.tb_cueimport)

        Using objImportar As New Negocios.ImportarBL(usuario, clave)

            Dim dtConexion As New DataTable
            dtConexion = objImportar.getDatosConexion(txtCodDoc.Text, txtActividad.Text)
            Using objImpCliente As New Negocios.ImportarBL(dtConexion)
                listaCuerProveedor = objImpCliente.listarCuerpoProveedorBL(lista, 1, "10002")     'tipo proveedor = 10002
                gcComp.DataSource = listaCuerProveedor
            End Using

        End Using
    End Sub

    Private Sub listarCuerpoCliente(ByVal lista As List(Of Entidades.tb_cabimport))
        listaCuerProveedor = New List(Of Entidades.tb_cueimport)

        Using objImportar As New Negocios.ImportarBL(usuario, clave)

            Dim dtConexion As New DataTable
            dtConexion = objImportar.getDatosConexion(txtCodDoc.Text, txtActividad.Text)
            Using objImpCliente As New Negocios.ImportarBL(dtConexion)
                listaCuerProveedor = objImpCliente.listarCuerpoClienteBL(lista, txtUnidad.Text, txtTCliente.Text)     'tipo proveedor = 10002
                gcComp.DataSource = listaCuerProveedor
            End Using

        End Using
    End Sub


    Private Sub alta()
        If listaProve.Count > 0 AndAlso listaCuerProveedor.Count > 0 AndAlso correlativo > 0 Then
            Using objCliente As New Negocios.ImportarBL(usuario, clave)
                objCliente.validarDatosTransaccion()
                If objCliente.datosValidosParametros() Then
                    Call objCliente.limpiarErrorBase()
                    Call objCliente.abrirTransaccion()
                    Call objCliente.altaPorBloqueBL(listaProve, listaCuerProveedor, correlativo, txtTCliente.Text)

                    If objCliente.existeError Then
                        Call objCliente.rechazarTransaccion()
                        XtraMessageBox.Show(String.Format("{0} {1}", objCliente.mensajesErrorSistema, objCliente.mensajesErrorUsuario),
                                                                   rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        objCliente.aceptarTransaccion()
                        XtraMessageBox.Show(rcRecursos.msOK, rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Call limpar()
                    End If
                End If
            End Using
        End If
    End Sub

    Private Sub limpar()
        gcCliente.DataSource = Nothing
        gcComp.DataSource = Nothing
    End Sub

#End Region

#Region "[eventos]"

    Private Sub btnListar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnListar.Click
        'Call listar()

        'Call listarDatos()

        Call listarProveedor(txtTCliente.Text)
    End Sub

    Private Sub btnAlta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlta.Click
        Call alta()
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Dim path As String = "output.xlsx"
        gcCliente.ExportToXlsx(path)
        ' Open the created XLSX file with the default application. 
        Process.Start(path)
    End Sub

#End Region


End Class