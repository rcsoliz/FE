Imports Entidades
Imports Datos
Public Class ConfiguracionBL : Inherits Datos.clsConfiguracion

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

#End Region

#Region "[metodos]"

    Public Sub altaBL(ByVal item As tb_configuracion)
        Call alta(item)
    End Sub

    Public Sub updateBL(ByVal item As tb_configuracion)
        Call update(item)
    End Sub

    Public Function getCorrelativoBL() As Integer
        Return getCorrelativo()
    End Function

    Public Sub bajaLogicaBL(ByVal item As tb_configuracion)
        Call bajaLogica(item)
    End Sub

    Public Sub bajaFisicaBL(ByVal item As tb_configuracion)
        Call bajaFisica(item)
    End Sub

    Public Function getConfiguracionBL() As DataTable
        Return getConfiguracion()
    End Function

    Public Function getConfiguracionBL(ByVal item As tb_configuracion) As DataTable
        Return getConfiguracion(item)
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
