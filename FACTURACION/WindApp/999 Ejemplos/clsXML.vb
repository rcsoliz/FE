Imports Entidades
Public Class clsXML

#Region "[atributosGlobales]"

    Private usuario As String
    Private clave As String

#End Region

#Region "[constructor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String)
        usuario = usuar
        clave = clav
    End Sub

#End Region

#Region "[metodos]"

    Public Function getProcesoArmadoXML(ByVal objCabecera As facturaElectronicaEstandarCabecera, ByVal lista As List(Of facturaElectronicaEstandarDetalle))

        Dim objUtilitario As New libreriaCUF()
        '1 Nit Base ....VALOR CABECERA, XML
        Dim nit As String = objCabecera.nitEmisor
        Dim nitCuf As String = objUtilitario.getNitFormato(nit) 'Nit formateado para el CUF

        '2 Capturo la fecha
        Dim fechaBase As String = CDate(objCabecera.fechaEmision).ToString("yyyy-MM-ddThh:mm:ss.fff")
        Dim fecha2 As String = fechaBase.Replace("T", "-")
        fecha2 = fecha2.Replace(":", "-")
        fecha2 = fecha2.Replace(".", "-")

        '2.1 Capturo la fecha en un array
        Dim array() As String = Split(fecha2, "-")
        Dim anio As String : Dim mes As String : Dim dia As String
        Dim hora As String : Dim minuto As String : Dim sg As String
        Dim mils As String

        '2.2 Damos el formato para general el CUF
        anio = objUtilitario.getAnioFormat(array.GetValue(0)) : mes = objUtilitario.getMesFormat(array.GetValue(1))
        dia = objUtilitario.getDiaFormat(array.GetValue(2)) : hora = objUtilitario.getHoraFormat(array.GetValue(3))
        minuto = objUtilitario.getMinutoFormat(array.GetValue(4)) : sg = objUtilitario.getSegundoFormat(array.GetValue(5))
        mils = objUtilitario.getMilisegundoFormat(array.GetValue(6))

        '2.3 Valor Cabecera tabla
        Dim cFechaCab As String = dia & "/" & mes & "/" & anio
        Dim cFechaCabXML As String = anio & "-" & mes & "-" & dia & "T" & minuto & ":" & sg & ":" & mils 'Valor cabecera XML

        '3 Valor Cabecera tabla
        Dim sucrusal As String = objCabecera.codigoSucursal  '0 para casa central a si sucesivamente
        Dim sucrusalCuf As String = objUtilitario.getSucrusalFormat(sucrusal) 'Valor cabecera XML

        Dim modalidad As String = objCabecera.codigoMetodoPago


    End Function

    Private Function generarCUF(ByVal array() As String) As String
        '................instancio un objte de la libreria
        Dim objUtilitario As New libreriaCUF()

        '................variable cuf
        Dim cuf As String = String.Empty

        '...............Declaro mis variables
        Dim anio As String : Dim mes As String : Dim dia As String
        Dim hora As String : Dim minuto As String : Dim sg As String
        Dim mils As String

        '................damos el formato para general el CUF
        anio = objUtilitario.getAnioFormat(array.GetValue(0)) : mes = objUtilitario.getMesFormat(array.GetValue(1))
        dia = objUtilitario.getDiaFormat(array.GetValue(2)) : hora = objUtilitario.getHoraFormat(array.GetValue(3))
        minuto = objUtilitario.getMinutoFormat(array.GetValue(4)) : sg = objUtilitario.getSegundoFormat(array.GetValue(5))
        mils = objUtilitario.getMilisegundoFormat(array.GetValue(6))

        '................agrupamos los el campo fecha para la cabera del XML
        Dim cFechaCab As String = anio & "-" & mes & "-" & dia & "T" & minuto & ":" & sg & ":" & mils

        '.................Declaramos variables para generar el Algoritmo Modulo Base 11
        Dim anio11 As String = objUtilitario.calculaDigitoModulo11(anio, 1, 9, False)
        Dim mes11 As String = objUtilitario.calculaDigitoModulo11(mes, 1, 9, False)
        Dim dia11 As String = objUtilitario.calculaDigitoModulo11(mes, 1, 9, False)
        Dim hora11 As String = objUtilitario.calculaDigitoModulo11(mes, 1, 9, False)
        Dim minu11 As String = objUtilitario.calculaDigitoModulo11(mes, 1, 9, False)
        Dim segu11 As String = objUtilitario.calculaDigitoModulo11(mes, 1, 9, False)



        Return cuf
    End Function

#End Region

End Class