Imports ENTIDADES
Public Class CobMenu22BL : Inherits DATOS.clsCobMenu22

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

    Public Sub altaCobMenu22BL(ByVal item As tb_cobmenu22)
        Call altaCobMenu22(item)
    End Sub

    Public Sub bajaCobMenu22BL(ByVal item As tb_cobmenu22)
        Call bajaCobMenu22(item)
    End Sub

    Public Sub modificarCobMenu22BL(ByVal item As tb_cobmenu22)
        Call modificarCobMenu22(item)
    End Sub

    Public Function getMaxCobMenu22BL() As Integer
        Return getMaxCobMenu22()
    End Function

    Public Function getUnCobMenu22BL(ByVal item As tb_cobmenu22) As DataTable
        Return getUnCobMenu22(item)
    End Function

    Public Function getCobMenu22XModuloBL(ByVal item As tb_cobmenu22) As DataTable
        Return getCobMenu22XModulo(item)
    End Function

    Public Function getCobMenu22BL() As DataTable
        Return getCobMenu22
    End Function

    Public Function getCobModulComboBL() As DataTable
        Return getCobModulCombo()
    End Function

    Public Function getCobModulComboBL(ByVal item As tb_cobmenu22) As DataTable
        Return getCobModulCombo(item)
    End Function


    Public Function getCobMopro1ComboBL(ByVal item As tb_cobmenu22) As DataTable
        Return getCobMopro1Combo(item)
    End Function

    Public Function getCobMopro1ComboBL() As DataTable
        Return getCobMopro1Combo()
    End Function

    Public Function getCobMenu11BL(ByVal item As tb_cobmenu22) As DataTable
        Return getCobMenu11(item)
    End Function

    Public Function getCobMenu11BL() As DataTable
        Return getCobMenu11()
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
