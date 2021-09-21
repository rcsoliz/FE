Imports Entidades
Imports Negocios
Public Class UI_AuxProducto : Inherits f_base

#Region "[atributosGlobales]"

    Private usuario As String
    Private clave As String
    Private opcion As Integer

#End Region

#Region "[constructor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String, ByVal titulo As String, ByVal opc As Integer)
        MyBase.New(usuar, clav, titulo, "Realice la operación requerida")
        InitializeComponent()
        usuario = usuar : clave = clav
        opcion = opc
    End Sub

#End Region

#Region "[metodos]"

    Private Sub getParametrosSIN()
        Using oParametroSin As New Negocios.UtilitarioSIN(usuario, clave)
            Dim dt As New DataTable
            If opcion = 1 Then

            ElseIf opcion = 2 Then


            End If

            oParametroSin.finalizar()
        End Using
    End Sub

#End Region

#Region "[eventos]"

#End Region

End Class