Imports Entidades
Public Class UI_Acceso

#Region "[atributosGlobales]"

    Private usuario As String
    Private clave As String
    Private boton As Boolean

#End Region

#Region "[contrutor]"

    Public Sub New()
        InitializeComponent()
        usuario = String.Empty
        clave = String.Empty
        boton = False

    End Sub

#End Region

#Region "[metodos]"

    Public Function retornar_boton() As Boolean
        Return boton
    End Function

    Public Function apagar_boton() As Boolean
        boton = False
    End Function

    Private Sub limpiar()
        txtactividad.Text = String.Empty
        txtusuario.Text = String.Empty
        txtclave.Text = String.Empty
    End Sub

    Private Sub ingresar()
        Dim acceso_user As New Negocios.DatosAccesoBL(txtusuario.Text, txtclave.Text)
        Dim datos_activ As New Negocios.EmpresaBL(txtusuario.Text, txtclave.Text, Trim(txtactividad.Text))
        Dim dtEmpresa As New DataTable
        dtEmpresa = datos_activ.getEmpresaBL(Trim(txtactividad.Text))
        If acceso_user.getAccesoBL(txtusuario.Text, txtclave.Text) Then
            Timer1.Enabled = False
            Dim formsistem As UI_Inicio
            'formsistem = New UI_Inicio(txtusuario.Text, txtclave.Text, Trim(txtactividad.Text))
            formsistem = New UI_Inicio(txtusuario.Text, txtclave.Text, Trim(txtactividad.Text), lblVersion.Text)
            formsistem.Text = "**** NOMBRE ACTIVIDAD ECONOMICA " & IIf(IsDBNull(dtEmpresa.Rows(0).Item("nomb_actividad")),
                                                                       Nothing, dtEmpresa.Rows(0).Item("nomb_actividad").ToUpper) & "  **** "
            Me.Hide()
            formsistem.ShowDialog()
            Me.Close()
        Else
            MsgBox("Error de Acceso: Actividad o Nombre de usuario o clave incorrectas", MsgBoxStyle.Critical, "Acceso")
        End If
    End Sub

#End Region

#Region "[eventos]"

    Private Sub UI_Acceso_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Timer1.Enabled = False
        Dim dir As String = Trim(f_base.directorioRaiz) & "WriteLines.txt"
        If IO.File.Exists(dir) Then
            IO.File.Delete(dir)
        End If
        Dim direc As String = f_base.directorioRaiz
        If Not IO.Directory.Exists(direc) Then
            MsgBox("Directorios de trabajo ... No creados ... Favor habilitar ... " + Trim(direc), MsgBoxStyle.Critical, "Acceso")
            Close()
        End If
        direc = f_base.directorioRaiz + "Facturas_Emitidas"
        If Not IO.Directory.Exists(direc) Then
            MsgBox("Directorios de trabajo ... No creados ... Favor habilitar ... " + Trim(direc), MsgBoxStyle.Critical, "Acceso")
            Close()
        End If
        direc = f_base.directorioRaiz + "Tmp"
        If Not IO.Directory.Exists(direc) Then
            MsgBox("Directorios de trabajo ... No creados ... Favor habilitar ... " + Trim(direc), MsgBoxStyle.Critical, "Acceso")
            Close()
        End If
        direc = f_base.directorioRaiz + "Iconos"
        If Not IO.Directory.Exists(direc) Then
            MsgBox("Directorios de trabajo ... No creados ... Favor copiar con sus datos ... " + Trim(direc), MsgBoxStyle.Critical, "Acceso")
            Close()
        End If
    End Sub

    Private Sub tactividad_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtactividad.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtusuario.Focus()
        End If
    End Sub

    Private Sub tusuario_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtusuario.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtclave.Focus()
        End If
    End Sub

    Private Sub tclave_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtclave.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            bIngresar.Focus()
        End If
    End Sub

    Private Sub bModoOnline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bModoOnline.Click
        If Trim(txtusuario.Text) <> "" And Trim(txtclave.Text) <> "" Then
            txtusuario.Enabled = False
            txtclave.Enabled = False
            txtactividad.Enabled = False
            bLimpiar.Enabled = False
            bIngresar.Enabled = False
            Timer1.Enabled = True
            Me.WindowState = FormWindowState.Minimized
            Dim Process4 As New Process
            Process4.StartInfo.CreateNoWindow = False
            Process4.StartInfo.FileName = "AcroRd32"
            Process4.Start()
        Else
            txtactividad.Focus()
        End If
    End Sub

    Private Sub bLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bLimpiar.Click
        Call limpiar()
    End Sub

    Private Sub bReportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bReportes.Click

    End Sub

    Private Sub bIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bIngresar.Click
        Call ingresar()
    End Sub

    Private Sub bSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSalir.Click
        Call Close()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If bIngresar.Enabled = False Then
            If IO.File.Exists(Trim(f_base.directorioRaiz) & "factura") Then

                Dim fileReader As String = ""
                Dim hayerror As Boolean = True
                Do
                    hayerror = True
                    Try
                        fileReader = ""
                        fileReader = Trim(My.Computer.FileSystem.ReadAllText(Trim(f_base.directorioRaiz) & "factura"))
                        hayerror = False
                    Catch ex As Exception
                        hayerror = True
                    End Try
                Loop Until hayerror = False

                IO.File.Delete(Trim(f_base.directorioRaiz) & "factura")
                If fileReader.Length > 1 Then
                    Dim parm(7) As String
                    parm = fileReader.ToString.Split(CChar(";"))
                    If parm.Length = 7 Then
                        Dim actividad As String = Trim(parm(1))
                        Dim tiporem As String = Trim(parm(2))
                        Dim numrem As String = Trim(parm(3))
                        Dim tipoperacion As String = Trim(parm(4)) '1 es facturar 2 es anular 3 email
                        Dim ip As String = Trim(parm(5))

                        If tipoperacion = 1 Then 'facturar 
                            'facturacion 1=masiva
                            ' Dim formfact As New Form_factura(Trim(usuario.Text), Trim(clave.Text), tiporem, numrem, tipoperacion, actividad, 1, "printer") 

                        End If
                        If tipoperacion = 2 Then ' anular
                            'Dim formfactanulada As New Form_factura_anulada(Trim(usuario.Text), Trim(clave.Text), tiporem, numrem, actividad)
                            'formfactanulada.eliminar.Enabled = False
                            'formfactanulada.eliminar.Visible = False

                            'formfactanulada.Button3.Enabled = True
                            'formfactanulada.Button3.Visible = True

                            'formfactanulada.MdiParent = Me.MdiParent
                            'formfactanulada.Show()
                        End If
                        If tipoperacion = 3 Then 'enviar email 
                            'Dim formfactcorreo As New EnvioCorreo(Trim(usuario.Text), Trim(clave.Text), tiporem, numrem, actividad)
                            'If formfactcorreo.hayerror = False Then
                            '    formfactcorreo.MdiParent = Me.MdiParent
                            '    formfactcorreo.Show()
                            'End If
                        End If
                    Else
                        MsgBox("No se han indicado parámetros correctos en la línea de comandos" & vbCrLf & _
                              "El nombre (y path) del ejecutable es:" & vbCrLf & _
                              Environment.GetCommandLineArgs(0))
                    End If
                End If


            Else
            End If
        End If
    End Sub

#End Region

End Class