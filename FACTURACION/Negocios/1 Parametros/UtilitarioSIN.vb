Imports Datos
Public Class UtilitarioSIN : Inherits Datos.clsUtilitarioSIN

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

    ''' <summary>
    ''' retorna todos los TIPOS CATALOGOS OFICIALES /SFE_FRIGOR
    ''' </summary>
    ''' <param name="tipo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getCataloFEBL(ByVal tipo As String) As DataTable
        Return getCataloFE(tipo)
    End Function

    ''' <summary>
    ''' retorna todos los TIPOS CATALOGOS OFICIALES ESPECIFICOS /SFE_FRIGOR
    ''' </summary>
    ''' <param name="tipo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getCataloFEBL(ByVal tipo As String, ByVal codigo As Integer) As DataTable
        Return getCataloFE(tipo, codigo)
    End Function

    '________________________________
    Public Function getAmbienteBL(ByVal codigo As String) As DataTable
        Return getAmbiente(codigo)
    End Function

    Public Function getDocuFicalesBL(ByVal codigo As String) As DataTable
        Return getDocuFicales(codigo)
    End Function

    Public Function getEmisionBL(ByVal codigo As String) As DataTable
        Return getEmision(codigo)
    End Function

    Public Function getModalidadBL(ByVal codigo As String) As DataTable
        Return getModalidad(codigo)
    End Function

    Public Function getMotivoAnulacionBL(ByVal codigo As String) As DataTable
        Return getMotivoAnulacion(codigo)
    End Function

    Public Function getMensSoapBL(ByVal codigo As String) As DataTable
        Return getMensSoap(codigo)
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