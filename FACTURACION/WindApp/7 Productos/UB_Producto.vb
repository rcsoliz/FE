Imports Negocios
Imports Entidades
Public Class UB_Producto : Inherits f_base

#Region "[atributosGlobales]"

    Private usuario As String
    Private clave As String

#End Region

#Region "[constructor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String)
        MyBase.New(usuar, clav, "Formulario Busqueda Producción", "Realice la operación requerida...")
        InitializeComponent()
        usuario = usuar : clave = clav
    End Sub

#End Region

#Region "[metodos]"



#End Region

#Region "[eventos]"

#End Region

End Class