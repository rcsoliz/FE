Imports Entidades
Public Class MenuBL : Inherits Datos.clsMenu

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

    Public Function getModuloBL(ByVal usuario As String) As DataTable
        Return getModulo(usuario)
    End Function

    Public Function getSubModuloBL(ByVal usuario As String, ByVal codModulo As Integer) As DataTable
        Return getSubModulo(usuario, codModulo)
    End Function

    Public Function getEventoBL(ByVal usuario As String, ByVal codModulo As Integer, ByVal codEvento As Integer) As DataTable
        Return getEvento(usuario, codModulo, codEvento)
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

    Public Function mensajeErrorSistema() As String
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

    ''LOG SESION
    Public Sub grabarlog_bl(ByVal idusuario As String, ByVal idwindows As String, ByVal nequipo As String,
                           ByVal ip As String, ByVal fecha As Date, ByVal b As String)
        grabarlog_db(idusuario, idwindows, nequipo, ip, fecha, b)
    End Sub

End Class
