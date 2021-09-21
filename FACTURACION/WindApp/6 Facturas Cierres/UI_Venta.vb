Public Class UI_Venta : Inherits f_base

#Region "[atributosGlobales]"

    Private usuario As String
    Private clave As String

#End Region

#Region "[constructor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String)
        MyBase.New("", "")
        InitializeComponent()
        usuario = usuar
        clave = clav
    End Sub

#End Region

#Region "[metodos]"

#End Region

#Region "[eventos]"

    Private Sub txtCodDocumento_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodDocumento.KeyPress
        If (e.KeyChar = Convert.ToChar(Keys.Enter)) Then
            Using obAyuda As New UI_AuxVenta(usuario, clave, "TIPOS DE DOCUMENTOS", 1)
                obAyuda.ShowDialog()
                Dim varAux As String = obAyuda.codigo ' = obAyuda.Codigo
                If varAux <> String.Empty Then
                    txtCodDocumento.Text = obAyuda.codigo
                    txtDescDocumento.Text = obAyuda.descripcion
                    txtNroDocumento.Text = obAyuda.nroCorrelativo
                    txtEstado.Text = "VIGENTE"
                    txtNit.Focus()
                End If
                obAyuda.Close()
            End Using
        End If
    End Sub

#End Region


End Class