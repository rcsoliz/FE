﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Este código fue generado por una herramienta.
'     Versión de runtime:4.0.30319.42000
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System.Xml.Serialization

'
'Este código fuente fue generado automáticamente por xsd, Versión=4.0.30319.1.
'

'''<comentarios/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),  _
 System.SerializableAttribute(),  _
 System.Diagnostics.DebuggerStepThroughAttribute(),  _
 System.ComponentModel.DesignerCategoryAttribute("code"),  _
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true),  _
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=false)>  _
Partial Public Class facturaElectronicaEstandar
    
    Private cabeceraField As facturaElectronicaEstandarCabecera
    
    Private detalleField() As facturaElectronicaEstandarDetalle
    
    '''<comentarios/>
    Public Property cabecera() As facturaElectronicaEstandarCabecera
        Get
            Return Me.cabeceraField
        End Get
        Set
            Me.cabeceraField = value
        End Set
    End Property
    
    '''<comentarios/>
    <System.Xml.Serialization.XmlElementAttribute("detalle")>  _
    Public Property detalle() As facturaElectronicaEstandarDetalle()
        Get
            Return Me.detalleField
        End Get
        Set
            Me.detalleField = value
        End Set
    End Property


    Private certificadoField As String
    Private selloField As String


    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Certificado As String
        Get
            Return Me.certificadoField
        End Get
        Set(ByVal value As String)
            Me.certificadoField = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Sello As String
        Get
            Return Me.selloField
        End Get
        Set(ByVal value As String)
            Me.selloField = value
        End Set
    End Property

End Class

'''<comentarios/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),  _
 System.SerializableAttribute(),  _
 System.Diagnostics.DebuggerStepThroughAttribute(),  _
 System.ComponentModel.DesignerCategoryAttribute("code"),  _
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true)>  _
Partial Public Class facturaElectronicaEstandarCabecera
    
    Private nitEmisorField As String
    
    Private numeroFacturaField As String
    
    Private cufField As String
    
    Private cufdField As String
    
    Private codigoSucursalField As String
    
    Private direccionField As String
    
    Private codigoPuntoVentaField As String
    
    Private fechaEmisionField As String ' Date
    
    Private nombreRazonSocialField As String
    
    Private codigoTipoDocumentoIdentidadField As String
    
    Private numeroDocumentoField As String
    
    Private complementoField As String
    
    Private codigoClienteField As String
    
    Private codigoMetodoPagoField As String
    
    Private numeroTarjetaField As String
    
    Private montoTotalField As Decimal
    
    Private montoDescuentoField As System.Nullable(Of Decimal)
    
    Private codigoMonedaField As String
    
    Private tipoCambioField As Decimal
    
    Private montoTotalMonedaField As Decimal
    
    Private leyendaField As String
    
    Private usuarioField As String
    
    Private codigoDocumentoSectorField As String
    
    Private codigoExcepcionDocumentoField As String
    
    Public Sub New()
        MyBase.New
        Me.codigoDocumentoSectorField = "1"
    End Sub
    
    '''<comentarios/>
    <System.Xml.Serialization.XmlElementAttribute(DataType:="integer")>  _
    Public Property nitEmisor() As String
        Get
            Return Me.nitEmisorField
        End Get
        Set
            Me.nitEmisorField = value
        End Set
    End Property
    
    '''<comentarios/>
    <System.Xml.Serialization.XmlElementAttribute(DataType:="integer")>  _
    Public Property numeroFactura() As String
        Get
            Return Me.numeroFacturaField
        End Get
        Set
            Me.numeroFacturaField = value
        End Set
    End Property
    
    '''<comentarios/>
    Public Property cuf() As String
        Get
            Return Me.cufField
        End Get
        Set
            Me.cufField = value
        End Set
    End Property
    
    '''<comentarios/>
    Public Property cufd() As String
        Get
            Return Me.cufdField
        End Get
        Set
            Me.cufdField = value
        End Set
    End Property
    
    '''<comentarios/>
    <System.Xml.Serialization.XmlElementAttribute(DataType:="integer")>  _
    Public Property codigoSucursal() As String
        Get
            Return Me.codigoSucursalField
        End Get
        Set
            Me.codigoSucursalField = value
        End Set
    End Property
    
    '''<comentarios/>
    Public Property direccion() As String
        Get
            Return Me.direccionField
        End Get
        Set
            Me.direccionField = value
        End Set
    End Property
    
    '''<comentarios/>
    <System.Xml.Serialization.XmlElementAttribute(DataType:="integer", IsNullable:=true)>  _
    Public Property codigoPuntoVenta() As String
        Get
            Return Me.codigoPuntoVentaField
        End Get
        Set
            Me.codigoPuntoVentaField = value
        End Set
    End Property
    
    '''<comentarios/>
    Public Property fechaEmision() As String ' Date
        Get
            Return Me.fechaEmisionField
        End Get
        Set(ByVal value As String)
            Me.fechaEmisionField = Value
        End Set
    End Property
    
    '''<comentarios/>
    Public Property nombreRazonSocial() As String
        Get
            Return Me.nombreRazonSocialField
        End Get
        Set
            Me.nombreRazonSocialField = value
        End Set
    End Property
    
    '''<comentarios/>
    <System.Xml.Serialization.XmlElementAttribute(DataType:="integer")>  _
    Public Property codigoTipoDocumentoIdentidad() As String
        Get
            Return Me.codigoTipoDocumentoIdentidadField
        End Get
        Set
            Me.codigoTipoDocumentoIdentidadField = value
        End Set
    End Property
    
    '''<comentarios/>
    Public Property numeroDocumento() As String
        Get
            Return Me.numeroDocumentoField
        End Get
        Set
            Me.numeroDocumentoField = value
        End Set
    End Property
    
    '''<comentarios/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=true)>  _
    Public Property complemento() As String
        Get
            Return Me.complementoField
        End Get
        Set
            Me.complementoField = value
        End Set
    End Property
    
    '''<comentarios/>
    Public Property codigoCliente() As String
        Get
            Return Me.codigoClienteField
        End Get
        Set
            Me.codigoClienteField = value
        End Set
    End Property
    
    '''<comentarios/>
    <System.Xml.Serialization.XmlElementAttribute(DataType:="integer")>  _
    Public Property codigoMetodoPago() As String
        Get
            Return Me.codigoMetodoPagoField
        End Get
        Set
            Me.codigoMetodoPagoField = value
        End Set
    End Property
    
    '''<comentarios/>
    <System.Xml.Serialization.XmlElementAttribute(DataType:="integer", IsNullable:=true)>  _
    Public Property numeroTarjeta() As String
        Get
            Return Me.numeroTarjetaField
        End Get
        Set
            Me.numeroTarjetaField = value
        End Set
    End Property
    
    '''<comentarios/>
    Public Property montoTotal() As Decimal
        Get
            Return Me.montoTotalField
        End Get
        Set
            Me.montoTotalField = value
        End Set
    End Property
    
    '''<comentarios/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=true)>  _
    Public Property montoDescuento() As System.Nullable(Of Decimal)
        Get
            Return Me.montoDescuentoField
        End Get
        Set
            Me.montoDescuentoField = value
        End Set
    End Property
    
    '''<comentarios/>
    <System.Xml.Serialization.XmlElementAttribute(DataType:="integer")>  _
    Public Property codigoMoneda() As String
        Get
            Return Me.codigoMonedaField
        End Get
        Set
            Me.codigoMonedaField = value
        End Set
    End Property
    
    '''<comentarios/>
    Public Property tipoCambio() As Decimal
        Get
            Return Me.tipoCambioField
        End Get
        Set
            Me.tipoCambioField = value
        End Set
    End Property
    
    '''<comentarios/>
    Public Property montoTotalMoneda() As Decimal
        Get
            Return Me.montoTotalMonedaField
        End Get
        Set
            Me.montoTotalMonedaField = value
        End Set
    End Property
    
    '''<comentarios/>
    Public Property leyenda() As String
        Get
            Return Me.leyendaField
        End Get
        Set
            Me.leyendaField = value
        End Set
    End Property
    
    '''<comentarios/>
    Public Property usuario() As String
        Get
            Return Me.usuarioField
        End Get
        Set
            Me.usuarioField = value
        End Set
    End Property
    
    '''<comentarios/>
    <System.Xml.Serialization.XmlElementAttribute(DataType:="integer")>  _
    Public Property codigoDocumentoSector() As String
        Get
            Return Me.codigoDocumentoSectorField
        End Get
        Set
            Me.codigoDocumentoSectorField = value
        End Set
    End Property
    
    '''<comentarios/>
    <System.Xml.Serialization.XmlElementAttribute(DataType:="integer", IsNullable:=true)>  _
    Public Property codigoExcepcionDocumento() As String
        Get
            Return Me.codigoExcepcionDocumentoField
        End Get
        Set
            Me.codigoExcepcionDocumentoField = value
        End Set
    End Property
End Class

'''<comentarios/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),  _
 System.SerializableAttribute(),  _
 System.Diagnostics.DebuggerStepThroughAttribute(),  _
 System.ComponentModel.DesignerCategoryAttribute("code"),  _
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true)>  _
Partial Public Class facturaElectronicaEstandarDetalle
    
    Private actividadEconomicaField As Long
    
    Private codigoProductoSinField As String
    
    Private codigoProductoField As String
    
    Private descripcionField As String
    
    Private cantidadField As Decimal
    
    Private unidadMedidaField As String
    
    Private precioUnitarioField As Decimal
    
    Private montoDescuentoField As System.Nullable(Of Decimal)
    
    Private subTotalField As Decimal
    
    Private numeroSerieField As String
    
    Private numeroImeiField As String
    
    '''<comentarios/>
    Public Property actividadEconomica() As Long
        Get
            Return Me.actividadEconomicaField
        End Get
        Set
            Me.actividadEconomicaField = value
        End Set
    End Property
    
    '''<comentarios/>
    <System.Xml.Serialization.XmlElementAttribute(DataType:="integer")>  _
    Public Property codigoProductoSin() As String
        Get
            Return Me.codigoProductoSinField
        End Get
        Set
            Me.codigoProductoSinField = value
        End Set
    End Property
    
    '''<comentarios/>
    Public Property codigoProducto() As String
        Get
            Return Me.codigoProductoField
        End Get
        Set
            Me.codigoProductoField = value
        End Set
    End Property
    
    '''<comentarios/>
    Public Property descripcion() As String
        Get
            Return Me.descripcionField
        End Get
        Set
            Me.descripcionField = value
        End Set
    End Property
    
    '''<comentarios/>
    Public Property cantidad() As Decimal
        Get
            Return Me.cantidadField
        End Get
        Set
            Me.cantidadField = value
        End Set
    End Property
    
    '''<comentarios/>
    <System.Xml.Serialization.XmlElementAttribute(DataType:="integer")>  _
    Public Property unidadMedida() As String
        Get
            Return Me.unidadMedidaField
        End Get
        Set
            Me.unidadMedidaField = value
        End Set
    End Property
    
    '''<comentarios/>
    Public Property precioUnitario() As Decimal
        Get
            Return Me.precioUnitarioField
        End Get
        Set
            Me.precioUnitarioField = value
        End Set
    End Property
    
    '''<comentarios/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=true)>  _
    Public Property montoDescuento() As System.Nullable(Of Decimal)
        Get
            Return Me.montoDescuentoField
        End Get
        Set
            Me.montoDescuentoField = value
        End Set
    End Property
    
    '''<comentarios/>
    Public Property subTotal() As Decimal
        Get
            Return Me.subTotalField
        End Get
        Set
            Me.subTotalField = value
        End Set
    End Property
    
    '''<comentarios/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=true)>  _
    Public Property numeroSerie() As String
        Get
            Return Me.numeroSerieField
        End Get
        Set
            Me.numeroSerieField = value
        End Set
    End Property
    
    '''<comentarios/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=true)>  _
    Public Property numeroImei() As String
        Get
            Return Me.numeroImeiField
        End Get
        Set
            Me.numeroImeiField = value
        End Set
    End Property
End Class
