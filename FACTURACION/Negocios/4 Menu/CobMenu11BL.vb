Imports ENTIDADES
Public Class CobMenu11BL : Inherits DATOS.clsCobmenu11

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

    Public Sub altaCobMenu11BL(ByVal item As tb_cobmenu11)
        Call altaCobMenu11(item)
    End Sub

    Public Sub bajaCobMenu11BL(ByVal item As tb_cobmenu11)
        Call bajaCobMenu11(item)
    End Sub

    Public Sub modificarCobMenu11BL(ByVal item As tb_cobmenu11)
        Call modificarCobMenu11(item)
    End Sub

    Public Function getMaxCobMenu11BL() As Integer
        Return getMaxCobMenu11()
    End Function

    Public Function getUnCobMenu11BL(ByVal item As tb_cobmenu11) As DataTable
        Return getUnCobMenu11(item)
    End Function

    Public Function getCobMenu11XModuloBL(ByVal item As tb_cobmenu11) As DataTable
        Return getCobMenu11XModulo(item)
    End Function

    Public Function getCobMenu11BL() As DataTable
        Return getCobMenu11()
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

    Public Function mensajeErrorSistema()
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
