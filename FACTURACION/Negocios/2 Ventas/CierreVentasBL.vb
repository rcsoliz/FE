Imports Entidades
Public Class CierreVentasBL : Inherits Datos.clsCierreVentas

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

    Public Function getCotizacionBL(ByVal fecha As Date) As Decimal
        Return getCotizacion(fecha)
    End Function


    Public Function altaLiqProveedorBL(ByVal fecha As Date, ByVal tCambio As Decimal, ByVal usuario As String) As Boolean
        Return altaLiqProveedor(fecha, tCambio, usuario)
    End Function

    Public Function altaLimpiezaMenudosBL(ByVal fecha As Date, ByVal tCambio As Decimal, ByVal usuario As String) As Boolean
        Return altaLimpiezaMenudos(fecha, tCambio, usuario)
    End Function


    Public Function altaVentaSebosBL(ByVal fecha As Date, ByVal tCambio As Decimal, ByVal usuario As String) As Boolean
        Return altaVentaSebos(fecha, tCambio, usuario)
    End Function

    Public Function altaVentaSangreFetalBL(ByVal fecha As Date, ByVal tCambio As Decimal, ByVal usuario As String) As Boolean
        Return altaVentaSangreFetal(fecha, tCambio, usuario)
    End Function

    Public Function altaVentaDescarteUnoBL(ByVal fecha As Date, ByVal tCambio As Decimal, ByVal usuario As String) As Boolean
        Return altaVentaDescarteUno(fecha, tCambio, usuario)
    End Function

    Public Function altaVentaDescarteDosbl(ByVal fecha As Date, ByVal tCambio As Decimal, ByVal usuario As String) As Boolean
        Return altaVentaDescarteDos(fecha, tCambio, usuario)
    End Function

    Public Function altaVentaDescarteTresBL(ByVal fecha As Date, ByVal tCambio As Decimal, ByVal usuario As String) As Boolean
        Return altaVentaDescarteTres(fecha, tCambio, usuario)
    End Function

    Public Function altaServicioAcopioHielBL(ByVal fecha As Date, ByVal tCambio As Decimal, ByVal usuario As String) As Boolean
        Return altaServicioAcopioHiel(fecha, tCambio, usuario)
    End Function

    Public Function altaBosasCarneIndustrialBL(ByVal fecha As Date, ByVal tCambio As Decimal, ByVal usuario As String) As Boolean
        Return altaBosasCarneIndustrial(fecha, tCambio, usuario)
    End Function

    Public Function altaServicioMenudoPorcinoBL(ByVal fecha As Date, ByVal tCambio As Decimal, ByVal usuario As String) As Boolean
        Return altaServicioMenudoPorcino(fecha, tCambio, usuario)
    End Function

    Public Function altaCueroBL(ByVal fecha As Date, ByVal tCambio As Decimal, ByVal usuario As String) As Boolean
        Return altaCuero(fecha, tCambio, usuario)
    End Function


    Public Function bajaCierreBL(ByVal fecha As Date)
        Return bajaCierre(fecha)
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
