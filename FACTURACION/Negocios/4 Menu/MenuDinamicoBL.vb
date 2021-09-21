Imports Entidades
Public Class MenuDinamicoBL : Inherits Datos.MenuDinamico

#Region "[Atributos/Globales]"

    Private _mensajeBL As String
    Private _DatosValidos As Boolean

#End Region

#Region "[Constructor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String)
        MyBase.New(usuar, clav)
        _mensajeBL = String.Empty
        _DatosValidos = True
    End Sub

#End Region

#Region "[Metodos]"

    Public Function darMenuBL(ByVal idUsuario As String) As DataTable
        Return darMenu(idUsuario)
    End Function

    Public Function darSubMenuBL(ByVal idUsuario As String) As DataTable
        Return darSubMenu(idUsuario)
    End Function

    Public Function darEventoBL(ByVal idUsuario As String) As DataTable
        Return darEvento(idUsuario)
    End Function

#End Region

#Region "[Metodos/Base]"

    Public Function Datos_Validos_Parametros() As Boolean
        Return _DatosValidos
    End Function

    Public Function mensaje_ErrorBL() As String
        Return _mensajeBL
    End Function

    Public Sub Limpiar_Error_Base()
        Call limpiar_error()
    End Sub

    Function Hay_Error()
        Return get_error()
    End Function

    Function mensaje_ErrorUsuario() As String
        Return get_mensaje_error()
    End Function
    'get_mensaje_error
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

    Public Shadows Sub Finalize()
        MyBase.Finalize()
    End Sub

#End Region


End Class
