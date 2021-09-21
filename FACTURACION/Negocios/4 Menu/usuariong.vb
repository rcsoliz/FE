Imports Entidades
Public Class usuariong : Inherits Datos.usuarios_db

#Region "atributosGlobales"

    Private mensajeBL As String
    Private datosValidos As Boolean

    Dim usuariosbl As Negocios.usuariong

 
    Private Pretendiente As String

    Private Mensaje_Error As String
    Private Mensaje_Error_sistema_ As String

#End Region

#Region "[Constructor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String)
        MyBase.New(usuar, clav)
    End Sub

#End Region


#Region "[metodos]"

    Public Sub validarDatosTransaccion()
        datosValidos = False
        mensajeBL = "Procesando datos del formulario"
        datosValidos = True
        mensajeBL = String.Empty
    End Sub

    Public Sub alta_usuariong(ByVal item As Entidades.tb_Cobusuar)
        Call alta(item)
    End Sub

    Public Sub baja_usuariong(ByVal item As Entidades.tb_Cobusuar)
        Call baja(item)
    End Sub

    Public Sub modificacion_usuariong(ByVal item As tb_Cobusuar)
        Call actualizar(item)
    End Sub

    Public Function getUsuariosBL(ByVal item As Entidades.tb_Cobusuar) As DataTable
        Return getUsuarios(item)
    End Function

    Public Function getUnUsuariosBL(ByVal item As Entidades.tb_Cobusuar) As DataTable
        Return getUnUsuarios(item)
    End Function

    Public Function getCategoriaDeUsuariosBL() As DataTable
        Return getCategoriaDeUsuarios()
    End Function

    Public Function getUsuariosXSucrusalBL() As DataTable
        Return getUsuariosXSucrusal()
    End Function

    Public Function getMaxCodigoBL() As Integer
        Return getMaxCodigo()
    End Function

#End Region

#Region "[Metodos/Instancia]"


    Public Function DatosValidosEnNegocios() As Boolean
        Return datosValidos
    End Function

    Public Sub Limpiar_Error_Base()
        Call limpiar_error()
    End Sub

    Public Function existeError()
        Return get_error()
    End Function

    Public Function mensaje_ErrorUsuario() As String
        Return get_mensaje_error()
    End Function

    Public Function mensaje_ErrorSistema() As String
        Return get_mensaje_error2()
    End Function

    Public Shadows Sub Abrir_Transaccion()
        MyBase.abrir_transaccion()
    End Sub

    Public Shadows Sub Aceptar_Transaccion()
        MyBase.aceptar_transaccion()
    End Sub

    Public Shadows Sub Rechazar_Transaccion()
        MyBase.rechazar_transaccion()
    End Sub

    Public Shadows Sub finalizar()
        MyBase.Finalize()
    End Sub

#End Region

End Class