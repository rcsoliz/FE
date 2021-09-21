Imports Negocios
Imports Entidades
Imports WindApp.My.Resources
Public Class UI_Producto : Inherits f_base

#Region "[atributosGlobales]"

    Private usuario As String
    Private clave As String

#End Region

#Region "[constructor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String)
        MyBase.New(usuar, clav, "FORMULARIO PRODUCTOS", "Realice la operación requerida")
        InitializeComponent()
        usuario = usuar : clave = clav
    End Sub

#End Region

#Region "[metodos]"

    Private Sub limpiar()
        libControl.limpiarTexto(Me)
    End Sub

    Private Function validar() As Boolean

        Return True
    End Function

    Private Sub alta()
        Using oPermiso As New Negocios.PermisoBL(usuario, clave)
            If oPermiso.allowAccesBL(libPermiso.alta, usuario) Then
                Using oProducto As New Negocios.PermisoBL(usuario, clave)

                    Call oProducto.finalizar()
                End Using
            Else
                MessageBox.Show(rcRecursos.msgAccesoGrabar, rcRecursos.msTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            Call oPermiso.finalizar()
        End Using
    End Sub

#End Region

#Region "[eventos]"

#End Region

End Class