Imports Entidades
Imports Datos
Public Class ImportarBL : Inherits Datos.clsImportar

#Region "[atributosGlobales]"

    Private mensaje_error As String
    Private datosvalidos As Boolean

#End Region

#Region "[contrutor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String)
        MyBase.new(usuar, clav)
        datosvalidos = False
        mensaje_error = String.Empty
    End Sub

    Public Sub New(ByVal dtConexion As DataTable)
        MyBase.new(dtConexion)
    End Sub

#End Region

#Region "[metodos]"

    Public Function getClientesFacturaBL(ByVal codTipo As String) As DataTable
        Return getClientesFactura(codTipo)
    End Function


    Public Function getClientesFactura93012BL(ByVal codTipo As String) As List(Of Entidades.tb_impcliente)
        Return getClientesFactura93012(codTipo)
    End Function

    Public Function getClienteBaseBL(ByRef listbase As List(Of tb_impcliente), ByVal codMov As String) As List(Of Entidades.tb_clienteIn)
        Return getClienteBase(listbase, codMov)
    End Function

    Public Function getDatosConexion(ByVal codGrupo As String, ByVal codActividad As String) As DataTable
        Return Obtener_Datos_Coneccion(codGrupo, codActividad)
    End Function

    Public Function getCorrelativoBL() As Integer
        Return getCorrelativo()
    End Function

    Public Sub updateCorrelativoBL(ByVal correlativo As Integer)
        Call updateCorrelativo(correlativo)
    End Sub


    Public Function listarProveedorBL(ByRef dtFactura As DataTable, ByRef correlativo As Integer) As List(Of Entidades.tb_cabimport)
        Return listarProveedor(dtFactura, correlativo)
    End Function

    Public Function listarClienteBL(ByRef dtFactura As DataTable, ByRef correlativo As Integer, ByVal esMenudo As Boolean, ByVal unidad As Integer) As List(Of Entidades.tb_cabimport)
        Return listarCliente(dtFactura, correlativo, esMenudo, unidad)
    End Function

    Public Function verificarProveedorBL(ByRef lista As List(Of Entidades.tb_cabimport), ByVal tcliente As String) As List(Of Entidades.tb_cabimport)
        Return verificarProveedor(lista, tcliente)
    End Function

    Public Function verificarClienteBL(ByVal lista As List(Of Entidades.tb_cabimport), ByVal tcliente As String, ByVal unidad As Integer) As List(Of Entidades.tb_cabimport)
        Return verificarCliente(lista, tcliente, unidad)
    End Function



    Public Function listarCuerpoProveedorBL(ByRef listProveedor As List(Of Entidades.tb_cabimport), ByVal unidad As Integer,
                                             ByVal tcliente As String) As List(Of Entidades.tb_cueimport)
        Return listarCuerpoProveedor(listProveedor, unidad, tcliente)
    End Function

    Public Function listarCuerpoClienteBL(ByRef listProveedor As List(Of Entidades.tb_cabimport), ByVal unidad As Integer, ByVal tcliente As String) As List(Of Entidades.tb_cueimport)
        Return listarCuerpoCliente(listProveedor, unidad, tcliente)
    End Function


    Public Function altaPorBloqueBL(ByRef listaCab As List(Of Entidades.tb_cabimport), ByRef listaCuep As List(Of Entidades.tb_cueimport), ByVal correlativo As Integer, ByVal tCliente As String) As Boolean
        Return altaPorBloque(listaCab, listaCuep, correlativo, tCliente)
    End Function



    Public Function getPruebaBL() As DataTable
        Return getPrueba()
    End Function

#End Region

#Region "[metodosInstancia]"

    Public Sub validarDatosTransaccion()
        datosvalidos = False
        mensaje_error = "Procesando datos del formulario"
        datosvalidos = True
        mensaje_error = String.Empty
    End Sub

    Public Function datosValidosParametros() As Boolean
        Return datosvalidos
    End Function

    Public Function mensajeErrorParametros() As String
        Return mensaje_error
    End Function

    Public Sub limpiarErrorBase()
        Call limpiar_error()
    End Sub

    Function existeError()
        Return get_error()
    End Function

    Public Function mensajesErrorSistema()
        Return get_mensaje_error2()
    End Function

    Function mensajesErrorUsuario()
        Return get_mensaje_error()
    End Function


    Public Shadows Sub abrirTransaccion()
        MyBase.abrir_transaccion()
    End Sub

    Public Shadows Sub aceptarTransaccion()
        MyBase.aceptar_transaccion()
    End Sub

    Public Shadows Sub rechazarTransaccion()
        MyBase.rechazar_transaccion()
    End Sub

    Public Shadows Sub finalizar()
        MyBase.Finalize()
    End Sub

#End Region


End Class
