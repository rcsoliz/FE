Imports ENTIDADES
Public Class CobAcces1BL : Inherits DATOS.clsCobacces1

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

    Public Sub altaCobAcces1BL(ByVal lista As List(Of tb_cobacces))
        Call altaCobAcces1(lista)
    End Sub

    Public Sub bajaCobAcces1BL(ByVal item As tb_cobacces)
        Call bajaCobAcces1(item)
    End Sub

    Public Sub bajaCobAcces1BL(ByVal lista As List(Of tb_cobacces))
        Call bajaCobAcces1(lista)
    End Sub

    Public Sub modificarCobAcces1BL(ByVal lista As List(Of tb_cobacces))
        Call modificarCobAcces1(lista)
    End Sub

    Public Function getCobModulComboBL() As DataTable
        Return getCobModulCombo()
    End Function

    Public Function getCobMopro1BL(ByVal item As tb_cobacces) As DataTable
        Return getCobMopro1(item)
    End Function

    Public Function getCobacces1XModuloYUsuarioBL(ByVal item As tb_cobacces) As DataTable
        Return getCobacces1XModuloYUsuario(item)
    End Function

    Public Function getCobacces1XModuloBL(ByVal item As tb_cobacces) As DataTable
        Return getCobacces1XModulo(item)
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

    Public Function mensajeErrorUsuarios() As String
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
