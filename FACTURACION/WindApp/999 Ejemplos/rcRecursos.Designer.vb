'------------------------------------------------------------------------------
' <auto-generated>
'     Este código fue generado por una herramienta.
'     Versión de runtime:4.0.30319.42000
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'StronglyTypedResourceBuilder generó automáticamente esta clase
    'a través de una herramienta como ResGen o Visual Studio.
    'Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    'con la opción /str o recompile su proyecto de VS.
    '''<summary>
    '''  Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Public Class rcRecursos
        
        Private Shared resourceMan As Global.System.Resources.ResourceManager
        
        Private Shared resourceCulture As Global.System.Globalization.CultureInfo
        
        <Global.System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")>  _
        Friend Sub New()
            MyBase.New
        End Sub
        
        '''<summary>
        '''  Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Public Shared ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("WindApp.rcRecursos", GetType(rcRecursos).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        '''  búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Public Shared Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Desea abrir el archivo de resultado?.
        '''</summary>
        Public Shared ReadOnly Property abrirArchivo() As String
            Get
                Return ResourceManager.GetString("abrirArchivo", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Certificados Digitales (*.cer;*.pfx;*.p7b)|*.cer;*.pfx;*.p7b.
        '''</summary>
        Public Shared ReadOnly Property formatosCertificado() As String
            Get
                Return ResourceManager.GetString("formatosCertificado", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Documentos XML sin firma (*.xml)|*.xml.
        '''</summary>
        Public Shared ReadOnly Property formatosXml() As String
            Get
                Return ResourceManager.GetString("formatosXml", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a ¿Esta seguroo de eliminar el registro?.
        '''</summary>
        Public Shared ReadOnly Property msEliminar() As String
            Get
                Return ResourceManager.GetString("msEliminar", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a ¿Usted no tiene acceso a eliminar?.
        '''</summary>
        Public Shared ReadOnly Property msgAccesoBaja() As String
            Get
                Return ResourceManager.GetString("msgAccesoBaja", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a ¿Usted no tiene acceso a consultar?.
        '''</summary>
        Public Shared ReadOnly Property msgAccesoConsulta() As String
            Get
                Return ResourceManager.GetString("msgAccesoConsulta", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a ¿Usted no tiene acceso a exportar?.
        '''</summary>
        Public Shared ReadOnly Property msgAccesoExportar() As String
            Get
                Return ResourceManager.GetString("msgAccesoExportar", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a ¿Usted no tiene acceso a grabar?.
        '''</summary>
        Public Shared ReadOnly Property msgAccesoGrabar() As String
            Get
                Return ResourceManager.GetString("msgAccesoGrabar", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a ¿Usted no tiene acceso a imprimir?.
        '''</summary>
        Public Shared ReadOnly Property msgAccesoImprimir() As String
            Get
                Return ResourceManager.GetString("msgAccesoImprimir", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a ¿Usted no tiene acceso a modificar?.
        '''</summary>
        Public Shared ReadOnly Property msgAccesoModificar() As String
            Get
                Return ResourceManager.GetString("msgAccesoModificar", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Confirme.
        '''</summary>
        Public Shared ReadOnly Property msgConfirme() As String
            Get
                Return ResourceManager.GetString("msgConfirme", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Transacción realizada.
        '''</summary>
        Public Shared ReadOnly Property msOK() As String
            Get
                Return ResourceManager.GetString("msOK", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Información.
        '''</summary>
        Public Shared ReadOnly Property msTitulo() As String
            Get
                Return ResourceManager.GetString("msTitulo", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Proceso enviado a SIAT correctamente!.
        '''</summary>
        Public Shared ReadOnly Property procesoCorrecto() As String
            Get
                Return ResourceManager.GetString("procesoCorrecto", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Seleccione un Certificado.
        '''</summary>
        Public Shared ReadOnly Property seleccioneCertificado() As String
            Get
                Return ResourceManager.GetString("seleccioneCertificado", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Seleccione un Documento Pfx SIAT.
        '''</summary>
        Public Shared ReadOnly Property seleccionPfx() As String
            Get
                Return ResourceManager.GetString("seleccionPfx", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Busca una cadena traducida similar a Seleccione un Documento XML SIAT.
        '''</summary>
        Public Shared ReadOnly Property seleccionXml() As String
            Get
                Return ResourceManager.GetString("seleccionXml", resourceCulture)
            End Get
        End Property
    End Class
End Namespace
