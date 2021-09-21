﻿'------------------------------------------------------------------------------
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


Namespace ServiceRefCufd
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.ServiceContractAttribute([Namespace]:="https://siat.impuestos.gob.bo/", ConfigurationName:="ServiceRefCufd.IServicioFacturacionCufd")>  _
    Public Interface IServicioFacturacionCufd
        
        'CODEGEN: El parámetro 'return' requiere información adicional de esquema que no se puede capturar con el modo de parámetros. El atributo específico es 'System.Xml.Serialization.XmlElementAttribute'.
        <System.ServiceModel.OperationContractAttribute(Action:="", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function verificarComunicacion(ByVal request As ServiceRefCufd.verificarComunicacion) As <System.ServiceModel.MessageParameterAttribute(Name:="return")> ServiceRefCufd.verificarComunicacionResponse
        
        'CODEGEN: El parámetro 'RespuestaCufd' requiere información adicional de esquema que no se puede capturar con el modo de parámetros. El atributo específico es 'System.Xml.Serialization.XmlElementAttribute'.
        <System.ServiceModel.OperationContractAttribute(Action:="", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function solicitudCufd(ByVal request As ServiceRefCufd.solicitudCufd) As <System.ServiceModel.MessageParameterAttribute(Name:="RespuestaCufd")> ServiceRefCufd.solicitudCufdResponse
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.ServiceModel.MessageContractAttribute(WrapperName:="verificarComunicacion", WrapperNamespace:="https://siat.impuestos.gob.bo/", IsWrapped:=true)>  _
    Partial Public Class verificarComunicacion
        
        Public Sub New()
            MyBase.New
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.ServiceModel.MessageContractAttribute(WrapperName:="verificarComunicacionResponse", WrapperNamespace:="https://siat.impuestos.gob.bo/", IsWrapped:=true)>  _
    Partial Public Class verificarComunicacionResponse
        
        <System.ServiceModel.MessageBodyMemberAttribute([Namespace]:="https://siat.impuestos.gob.bo/", Order:=0),  _
         System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>  _
        Public [return] As Integer
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal [return] As Integer)
            MyBase.New
            Me.[return] = [return]
        End Sub
    End Class
    
    '''<comentarios/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="https://siat.impuestos.gob.bo/")>  _
    Partial Public Class solicitudOperaciones
        Inherits Object
        Implements System.ComponentModel.INotifyPropertyChanged
        
        Private codigoAmbienteField As Integer 'OK 2 PRUEBA 1 PRODUCCION
        
        Private codigoModalidadField As Integer 'OK 1 ELECTRONICA
        
        Private codigoPuntoVentaField As System.Nullable(Of Integer) 'OK 0
        
        Private codigoPuntoVentaFieldSpecified As Boolean
        
        Private codigoSistemaField As String 'OK
        
        Private codigoSucursalField As Integer 'OK
        
        Private cuisField As String 'OK
        
        Private nitField As Long 'OK
        
        '''<comentarios/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, Order:=0)>  _
        Public Property codigoAmbiente() As Integer
            Get
                Return Me.codigoAmbienteField
            End Get
            Set
                Me.codigoAmbienteField = value
                Me.RaisePropertyChanged("codigoAmbiente")
            End Set
        End Property
        
        '''<comentarios/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, Order:=1)>  _
        Public Property codigoModalidad() As Integer
            Get
                Return Me.codigoModalidadField
            End Get
            Set
                Me.codigoModalidadField = value
                Me.RaisePropertyChanged("codigoModalidad")
            End Set
        End Property
        
        '''<comentarios/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable:=true, Order:=2)>  _
        Public Property codigoPuntoVenta() As System.Nullable(Of Integer)
            Get
                Return Me.codigoPuntoVentaField
            End Get
            Set
                Me.codigoPuntoVentaField = value
                Me.RaisePropertyChanged("codigoPuntoVenta")
            End Set
        End Property
        
        '''<comentarios/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>  _
        Public Property codigoPuntoVentaSpecified() As Boolean
            Get
                Return Me.codigoPuntoVentaFieldSpecified
            End Get
            Set
                Me.codigoPuntoVentaFieldSpecified = value
                Me.RaisePropertyChanged("codigoPuntoVentaSpecified")
            End Set
        End Property
        
        '''<comentarios/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, Order:=3)>  _
        Public Property codigoSistema() As String
            Get
                Return Me.codigoSistemaField
            End Get
            Set
                Me.codigoSistemaField = value
                Me.RaisePropertyChanged("codigoSistema")
            End Set
        End Property
        
        '''<comentarios/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, Order:=4)>  _
        Public Property codigoSucursal() As Integer
            Get
                Return Me.codigoSucursalField
            End Get
            Set
                Me.codigoSucursalField = value
                Me.RaisePropertyChanged("codigoSucursal")
            End Set
        End Property
        
        '''<comentarios/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, Order:=5)>  _
        Public Property cuis() As String
            Get
                Return Me.cuisField
            End Get
            Set
                Me.cuisField = value
                Me.RaisePropertyChanged("cuis")
            End Set
        End Property
        
        '''<comentarios/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, Order:=6)>  _
        Public Property nit() As Long
            Get
                Return Me.nitField
            End Get
            Set
                Me.nitField = value
                Me.RaisePropertyChanged("nit")
            End Set
        End Property
        
        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
        
        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
    End Class
    
    '''<comentarios/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="https://siat.impuestos.gob.bo/")>  _
    Partial Public Class respuestaCodigosMensajesSoapDto
        Inherits Object
        Implements System.ComponentModel.INotifyPropertyChanged
        
        Private codigoMensajeField As Integer
        
        Private codigoMensajeFieldSpecified As Boolean
        
        '''<comentarios/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, Order:=0)>  _
        Public Property codigoMensaje() As Integer
            Get
                Return Me.codigoMensajeField
            End Get
            Set
                Me.codigoMensajeField = value
                Me.RaisePropertyChanged("codigoMensaje")
            End Set
        End Property
        
        '''<comentarios/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>  _
        Public Property codigoMensajeSpecified() As Boolean
            Get
                Return Me.codigoMensajeFieldSpecified
            End Get
            Set
                Me.codigoMensajeFieldSpecified = value
                Me.RaisePropertyChanged("codigoMensajeSpecified")
            End Set
        End Property
        
        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
        
        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
    End Class
    
    '''<comentarios/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="https://siat.impuestos.gob.bo/")>  _
    Partial Public Class respuestaCufd
        Inherits Object
        Implements System.ComponentModel.INotifyPropertyChanged
        
        Private codigoField As String
        
        Private fechaVigenciaField As Date
        
        Private fechaVigenciaFieldSpecified As Boolean
        
        Private listaCodigosRespuestasField() As respuestaCodigosMensajesSoapDto
        
        Private transaccionField As Boolean
        
        '''<comentarios/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, Order:=0)>  _
        Public Property codigo() As String
            Get
                Return Me.codigoField
            End Get
            Set
                Me.codigoField = value
                Me.RaisePropertyChanged("codigo")
            End Set
        End Property
        
        '''<comentarios/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, Order:=1)>  _
        Public Property fechaVigencia() As Date
            Get
                Return Me.fechaVigenciaField
            End Get
            Set
                Me.fechaVigenciaField = value
                Me.RaisePropertyChanged("fechaVigencia")
            End Set
        End Property
        
        '''<comentarios/>
        <System.Xml.Serialization.XmlIgnoreAttribute()>  _
        Public Property fechaVigenciaSpecified() As Boolean
            Get
                Return Me.fechaVigenciaFieldSpecified
            End Get
            Set
                Me.fechaVigenciaFieldSpecified = value
                Me.RaisePropertyChanged("fechaVigenciaSpecified")
            End Set
        End Property
        
        '''<comentarios/>
        <System.Xml.Serialization.XmlElementAttribute("listaCodigosRespuestas", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable:=true, Order:=2)>  _
        Public Property listaCodigosRespuestas() As respuestaCodigosMensajesSoapDto()
            Get
                Return Me.listaCodigosRespuestasField
            End Get
            Set
                Me.listaCodigosRespuestasField = value
                Me.RaisePropertyChanged("listaCodigosRespuestas")
            End Set
        End Property
        
        '''<comentarios/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, Order:=3)>  _
        Public Property transaccion() As Boolean
            Get
                Return Me.transaccionField
            End Get
            Set
                Me.transaccionField = value
                Me.RaisePropertyChanged("transaccion")
            End Set
        End Property
        
        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
        
        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.ServiceModel.MessageContractAttribute(WrapperName:="solicitudCufd", WrapperNamespace:="https://siat.impuestos.gob.bo/", IsWrapped:=true)>  _
    Partial Public Class solicitudCufd
        
        <System.ServiceModel.MessageBodyMemberAttribute([Namespace]:="https://siat.impuestos.gob.bo/", Order:=0),  _
         System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>  _
        Public SolicitudOperaciones As ServiceRefCufd.solicitudOperaciones
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal SolicitudOperaciones As ServiceRefCufd.solicitudOperaciones)
            MyBase.New
            Me.SolicitudOperaciones = SolicitudOperaciones
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.ServiceModel.MessageContractAttribute(WrapperName:="solicitudCufdResponse", WrapperNamespace:="https://siat.impuestos.gob.bo/", IsWrapped:=true)>  _
    Partial Public Class solicitudCufdResponse
        
        <System.ServiceModel.MessageBodyMemberAttribute([Namespace]:="https://siat.impuestos.gob.bo/", Order:=0),  _
         System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>  _
        Public RespuestaCufd As ServiceRefCufd.respuestaCufd
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal RespuestaCufd As ServiceRefCufd.respuestaCufd)
            MyBase.New
            Me.RespuestaCufd = RespuestaCufd
        End Sub
    End Class
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Public Interface IServicioFacturacionCufdChannel
        Inherits ServiceRefCufd.IServicioFacturacionCufd, System.ServiceModel.IClientChannel
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Partial Public Class ServicioFacturacionCufdClient
        Inherits System.ServiceModel.ClientBase(Of ServiceRefCufd.IServicioFacturacionCufd)
        Implements ServiceRefCufd.IServicioFacturacionCufd
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String)
            MyBase.New(endpointConfigurationName)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(binding, remoteAddress)
        End Sub
        
        <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Function ServiceRefCufd_IServicioFacturacionCufd_verificarComunicacion(ByVal request As ServiceRefCufd.verificarComunicacion) As ServiceRefCufd.verificarComunicacionResponse Implements ServiceRefCufd.IServicioFacturacionCufd.verificarComunicacion
            Return MyBase.Channel.verificarComunicacion(request)
        End Function
        
        Public Function verificarComunicacion() As Integer
            Dim inValue As ServiceRefCufd.verificarComunicacion = New ServiceRefCufd.verificarComunicacion()
            Dim retVal As ServiceRefCufd.verificarComunicacionResponse = CType(Me,ServiceRefCufd.IServicioFacturacionCufd).verificarComunicacion(inValue)
            Return retVal.[return]
        End Function
        
        <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Function ServiceRefCufd_IServicioFacturacionCufd_solicitudCufd(ByVal request As ServiceRefCufd.solicitudCufd) As ServiceRefCufd.solicitudCufdResponse Implements ServiceRefCufd.IServicioFacturacionCufd.solicitudCufd
            Return MyBase.Channel.solicitudCufd(request)
        End Function
        
        Public Function solicitudCufd(ByVal SolicitudOperaciones As ServiceRefCufd.solicitudOperaciones) As ServiceRefCufd.respuestaCufd
            Dim inValue As ServiceRefCufd.solicitudCufd = New ServiceRefCufd.solicitudCufd()
            inValue.SolicitudOperaciones = SolicitudOperaciones
            Dim retVal As ServiceRefCufd.solicitudCufdResponse = CType(Me,ServiceRefCufd.IServicioFacturacionCufd).solicitudCufd(inValue)
            Return retVal.RespuestaCufd
        End Function
    End Class
End Namespace
