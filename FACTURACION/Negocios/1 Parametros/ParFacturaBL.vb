Public Class ParFacturaBL : Inherits Datos.clsParFactura

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

    Public Sub altaBL(ByVal item As Entidades.tb_ParFatura)
        Call alta(item)
    End Sub

    Public Sub altaBL(ByVal lista As List(Of Entidades.tb_ParFatura))
        Call alta(lista)
    End Sub

    Public Sub actualizarBL(ByVal item As Entidades.tb_ParFatura)
        Call actualizar(item)
    End Sub

    Public Sub bajaBL(ByVal item As Entidades.tb_ParFatura)
        Call baja(item)
    End Sub

    Public Function getParametroBL() As DataTable
        Return getParametro()
    End Function

    Public Function getParametroBL(ByVal item As Entidades.tb_ParFatura) As DataTable
        Return getParametro(item)
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
