Imports ENTIDADES
Public Class CobModulBL : Inherits DATOS.clsCobModul

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

    Public Sub altaCobModuloBL(ByVal item As tb_codmodul)
        Call altaCobModul(item)
    End Sub

    Public Sub bajaCobModulBL(ByVal item As tb_codmodul)
        Call bajaCobModul(item)
    End Sub

    Public Sub modificarCobModulBL(ByVal item As tb_codmodul)
        Call modificarCobModul(item)
    End Sub

    Public Function getMaxCobModulBL() As Integer
        Return getMaxCobModul()
    End Function

    Public Function getUnCobModuloBL(ByVal item As tb_codmodul) As DataTable
        Return getUnCobModul(item)
    End Function

    Public Function getCobModulActivoBL() As DataTable
        Return getCobModulActivo()
    End Function

    Public Function getCobModulInactivoBL() As DataTable
        Return getCobModulInactivo()
    End Function

    Public Function getCobModulComboBL() As DataTable
        Return getCobModulCombo()
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
