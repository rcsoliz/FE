Imports Entidades
Public Class PreVentaBL : Inherits Datos.clsPreVentas

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

    Public Function altaPreVentaBL(ByVal itemCab As Entidades.tb_CabVentas, ByVal lista As List(Of Entidades.tb_CueVentas)) As Boolean
        Return altaPreVenta(itemCab, lista)
    End Function

    Public Function anularPreVentaBL(ByVal item As Entidades.tb_CabVentas) As Boolean
        Return anularPreVenta(item)
    End Function

    Public Function bajaPreVentaBL(ByVal item As Entidades.tb_CabVentas) As Boolean
        Return bajaPreVenta(item)
    End Function

    Public Function getCabeceraVentaBL(ByVal item As Entidades.tb_CabVentas) As DataTable
        Return getCabeceraVenta(item)
    End Function

    Public Function getTipoDocumentoBL() As DataTable
        Return getTipoDocumento()
    End Function

    Public Function getCuerpoVentaBL(ByVal item As Entidades.tb_CabVentas) As DataTable
        Return getCuerpoVenta(item)
    End Function

    Public Function getParametroBL(ByVal codParametro As String) As DataTable
        Return getParametro(codParametro)
    End Function

    Public Function getCorrelativoBL(ByVal codtMovimiento As String) As Decimal
        Return getCorrelativo(codtMovimiento)
    End Function

    Public Function getEsConFacturaBL(ByVal codTipoDocumento As String) As Boolean
        Return getEsConFactura(codTipoDocumento)
    End Function


    Public Function getVentaDespachoCIIBL(ByVal codTipoDocumento As String, ByVal nroNota As String) As DataTable
        Return getVentaDespachoCII(codTipoDocumento, nroNota)
    End Function

    Public Function getCuerpoDespachoCIIBL(ByVal codTipoDocumento As String, ByVal nroNota As String) As DataTable
        Return getCuerpoDespachoCII(codTipoDocumento, nroNota)
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
    'mensajeerror = mensaje_sistema
    'mensajeerrorusuario = mensajeusuario
    Public Function mensajesErrorSistema()
        Return get_mensaje_error2()
    End Function

    Public Function mensajesErrorUsuario()
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
