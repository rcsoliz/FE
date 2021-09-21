Imports ENTIDADES
Public Class CobmoproBL : Inherits DATOS.clsCobmopro

#Region "[atributosGlobales]"

    Private mensajeBL As String
    Private datosValidos As Boolean

#End Region

#Region "[constructor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String)
        MyBase.New(usuar, clav)
        mensajeBL = String.Empty
        datosValidos = True
    End Sub

#End Region

#Region "[métodos]"

    Public Sub altaCobMoproBL(ByVal item As tb_cobmopro)
        Call altaCobMopro(item)
    End Sub

    Public Sub bajaCobMoproBL(ByVal item As tb_cobmopro)
        Call bajaCobMopro(item)
    End Sub

    Public Sub modificarCobMoproBL(ByVal item As tb_cobmopro)
        Call modificarCobMopro(item)
    End Sub

    Public Function getMaxCobMoproBL() As Integer
        Return getMaxCobMopro()
    End Function

    Public Function getUnCobMoproBL(ByVal item As tb_cobmopro) As DataTable
        Return getUnCobMopro(item)
    End Function

    Public Function getSubModuloBL(ByVal item As tb_cobmopro) As DataTable
        Return getSubModulo(item)
    End Function

    Public Function getCobModproBL() As DataTable
        Return getCobModpro()
    End Function

#End Region

#Region "[métodosInstancia]"

    Public Sub validarDatosTransaccion()
        datosValidos = False
        mensajeBL = "Procesando datos del formulario"
        datosValidos = True
        mensajeBL = String.Empty
    End Sub

    Public Function DatosValidosEnNegocios() As Boolean
        Return datosValidos
    End Function

    Public Function mensajeErrorBL() As String
        Return mensajeBL
    End Function

    Public Sub LimpiarErrorBase()
        Call limpiar_error()
    End Sub

    Function existeError()
        Return get_error()
    End Function

    Function mensajeErrorUsuarios() As String
        Return get_mensaje_error()
    End Function

    Public Function mensajesErrorSistema()
        Return get_mensaje_error2()
    End Function

    Public Shadows Sub AbrirTransaccion()
        MyBase.abrir_transaccion()
    End Sub

    Public Shadows Sub AceptarTransaccion()
        MyBase.aceptar_transaccion()
    End Sub

    Public Shadows Sub RechazarTransaccion()
        MyBase.rechazar_transaccion()
    End Sub

    Public Shadows Sub finalizar()
        MyBase.Finalize()
    End Sub

#End Region

End Class