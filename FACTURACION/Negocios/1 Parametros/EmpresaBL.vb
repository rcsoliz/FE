Imports Datos
Public Class EmpresaBL : Inherits Datos.ClsEmpresa

#Region "[atributosGlobales]"

    Private mensaje_error As String
    Private datosvalidos As Boolean

    Private codActividad As String

#End Region

#Region "[contrutor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String)
        MyBase.new(usuar, clav)
        datosvalidos = False
        mensaje_error = String.Empty
    End Sub

    Public Sub New(ByVal usuar As String, ByVal clav As String, ByVal codAct As String)
        MyBase.New(usuar, clav)
        codActividad = codAct

    End Sub

#End Region

#Region "[metodos]"

    Public Sub altaBL(ByVal item As Entidades.tb_empresa)
        Call alta(item)
    End Sub

    Public Sub actualizarBL(ByVal item As Entidades.tb_empresa)
        Call actualizar(item)
    End Sub

    Public Sub bajaBL(ByVal item As Entidades.tb_empresa)
        Call baja(item)
    End Sub

    Public Function getEmpresaBL() As DataTable
        Return getEmpresa()
    End Function

    Public Function getEmpresaBL(ByVal item As Entidades.tb_empresa) As DataTable
        Return getEmpresa(item)
    End Function

    Public Function getEmpresaBL(ByVal codActividad As String) As DataTable
        Return getEmpresa(codActividad)
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
