Imports Entidades
Public Class ClienteInBL : Inherits Datos.clsClienteIn

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

    Public Sub altaBL(ByVal item As tb_clienteIn)
        Call alta(item)
    End Sub

    Public Sub bajaBL(ByVal item As tb_clienteIn)
        Call baja(item)
    End Sub

    Public Sub actualizarBL(ByVal item As tb_clienteIn)
        Call actualizar(item)
    End Sub

    Public Function getClienteInBL() As DataTable
        Return getClienteIn()
    End Function

    Public Function getClienteInBL(ByVal item As tb_clienteIn) As DataTable
        Return getClienteIn()
    End Function

    Public Function getCorrelativoBL() As Integer
        Return getCorrelativo()
    End Function

    Public Function getClienteProvedorBL(ByVal codTipo As String) As DataTable
        Return getClienteProvedor(codTipo)
    End Function

#End Region

#Region "[metodosInstancia]"

    Public Sub validarDatosTransaccion()
        datosvalidos = False
        mensaje_error = "Procesando datos del formulario"
        datosvalidos = True
        mensaje_error = String.Empty
    End Sub

    Public Function DatosValidosEnNegocios() As Boolean
        Return datosValidos
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

    Public Function mensajeErrorUsuarios()
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
