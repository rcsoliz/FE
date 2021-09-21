Public Class UtilitarioBL : Inherits Datos.clsUtilitario

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

    Public Function getCatalogoBL(ByVal tipo As String, ByVal codigo As Integer) As String
        Return getCatalogo(tipo, codigo)
    End Function


    Public Function getModalidadBL(ByVal tipo As String, ByVal codigo As Integer) As String
        Return getModalidad(tipo, codigo)
    End Function

    Public Function getTipoEmisionBL(ByVal codParame As Integer) As String
        Return getTipoEmision(codParame)
    End Function

    Public Function getCodigoDocumentoFiscalBL(ByVal codParame As Integer) As String
        Return getCodigoDocumentoFiscal(codParame)
    End Function

    Public Function getTipoDocumentoSectorBL(ByVal codParame As Integer) As String
        Return getTipoDocumentoSector(codParame)
    End Function


    Public Function getDatosConexion(ByVal codGrupo As String, ByVal codActividad As String) As DataTable
        Return Obtener_Datos_Coneccion(codGrupo, codActividad)
    End Function

    Public Function getNegocioBL() As DataTable
        Return getNegocio()
    End Function

    Public Function getNegocioBL(ByVal unidad As Integer) As DataTable
        Return getNegocio(unidad)
    End Function

    Public Function getTipoClienteBL() As DataTable
        Return getTipoCliente()
    End Function


    Public Function getParametroBL() As DataTable
        Return getParametro
    End Function

    Public Function getTipoDocumentoBL() As DataTable
        Return getTipoDocumento()
    End Function


    Public Function getActividadBL(ByVal codigo As String) As DataTable
        Return getActividad(codigo)
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