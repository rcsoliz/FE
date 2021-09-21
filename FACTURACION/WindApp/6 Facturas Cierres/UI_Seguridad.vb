Public Class UI_Seguridad

#Region "[atributosGlobales]"
    Private usuario As String
    Private clave As String
#End Region

#Region "[contrutor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String)
        InitializeComponent()
        usuario = usuar
        clave = clav
    End Sub

#End Region

#Region "[metodos]"

    Private Sub acceder()
        If txtClave.Text = "adm" AndAlso txtUsuario.Text = "adm" Then
            DialogResult = Windows.Forms.DialogResult.OK
            Close()
        End If
    End Sub

#End Region

#Region "[eventos]"

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Call acceder()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Call Close()
    End Sub

#End Region

    
End Class