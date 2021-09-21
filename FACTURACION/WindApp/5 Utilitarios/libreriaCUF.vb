Imports System.Numerics


Public Class libreriaCUF ': Implements IDisposable

    Public Function calculaDigitoModulo11(ByVal dado As String, ByVal numDig As Integer, ByVal limMult As Integer, ByVal x10 As Boolean) As String
        Dim mult, soma, i, n, dig As Integer
        If Not x10 Then
            numDig = 1
        End If

        For n = 1 To numDig
            soma = 0
            mult = 2

            Dim lon As Int64 = dado.Length - 1
            For i = lon To i >= 0 Step -1
                If i < 0 Then
                    Exit For
                End If
                Dim valor As String = JavaEStileSubstring(dado, i, (i + 1))
                soma += (mult * Integer.Parse(valor))

                If System.Threading.Interlocked.Increment(mult) > limMult Then
                    mult = 2
                End If
            Next

            Dim valmul As Integer = mult

            If (++mult) > limMult Then
                mult = 2
            End If

            If x10 Then
                dig = ((soma * 10) Mod 11) Mod 10
            Else
                dig = soma Mod 11
            End If

            If x10 Then
                dig = ((soma * 10) Mod 11) Mod 10
            Else
                dig = soma Mod 11
            End If

            If dig = 10 Then
                dado += "1"
            End If

            If dig = 11 Then
                dado += "0"
            End If

            If dig < 10 Then
                dado += Convert.ToString(dig)
            End If
        Next

        Dim valorf As String = JavaEStileSubstring(dado, (dado.Length - numDig), dado.Length)
        Return valorf
    End Function

    Public Function JavaEStileSubstring(ByVal s As String, ByVal beginIndex As Integer, ByVal endIndex As Integer) As String
        Dim len As Integer = endIndex - beginIndex
        Return s.Substring(beginIndex, len)
    End Function


    Public Function getNitFormato(ByVal n As String) As String
        Dim nit As String = String.Empty

        If n.Length = 1 Then
            nit = "000000000000" & n
        ElseIf n.Length = 2 Then
            nit = "00000000000" & n
        ElseIf n.Length = 3 Then
            nit = "0000000000" & n
        ElseIf n.Length = 4 Then
            nit = "000000000" & n
        ElseIf n.Length = 5 Then
            nit = "00000000" & n
        ElseIf n.Length = 6 Then
            nit = "0000000" & n
        ElseIf n.Length = 7 Then
            nit = "000000" & n
        ElseIf n.Length = 8 Then
            nit = "00000" & n
        ElseIf n.Length = 9 Then
            nit = "0000" & n
        ElseIf n.Length = 10 Then
            nit = "000" & n
        ElseIf n.Length = 11 Then
            nit = "00" & n
        ElseIf n.Length = 12 Then
            nit = "0" & n
        Else
            nit = n
        End If

        Return nit
    End Function


    Public Function getFechaHora(ByVal f As Date) As String
        Dim fecha As String = String.Empty
        Dim fhora As String = Convert.ToString(f)
        Dim anio As Integer = f.Year : Dim aniof As String
        Dim mes As Integer = f.Month : Dim mesf As String
        Dim dia As Integer = f.Day : Dim diaf As String
        Dim hora As Integer = f.Hour : Dim horaf As String
        Dim min As Integer = f.Minute : Dim minf As String
        Dim seg As Integer = f.Second : Dim segf As String
        Dim mseg As Integer = f.Millisecond : Dim msegf As String

        If Convert.ToString(anio).Length = 1 Then
            aniof = "000" & Convert.ToString(anio)
        ElseIf Convert.ToString(anio).Length = 1 Then
            aniof = "00" & Convert.ToString(anio)
        ElseIf Convert.ToString(anio).Length = 1 Then
            aniof = "0" & Convert.ToString(anio)
        Else
            aniof = Convert.ToString(anio)
        End If

        If Convert.ToString(mes).Length = 1 Then
            mesf = "0" & Convert.ToString(mes)
        Else
            mesf = Convert.ToString(mes)
        End If

        If Convert.ToString(dia).Length = 1 Then
            diaf = "0" & Convert.ToString(dia)
        Else
            diaf = Convert.ToString(dia)
        End If

        If Convert.ToString(hora).Length = 1 Then
            horaf = "0" & Convert.ToString(hora)
        Else
            horaf = Convert.ToString(hora)
        End If

        If Convert.ToString(min).Length = 1 Then
            minf = "0" & Convert.ToString(min)
        Else
            minf = Convert.ToString(min)
        End If

        If Convert.ToString(seg).Length = 1 Then
            segf = "0" & Convert.ToString(seg)
        Else
            segf = Convert.ToString(seg)
        End If

        If Convert.ToString(mseg).Length = 1 Then
            msegf = "00" & Convert.ToString(mseg)
        ElseIf Convert.ToString(mseg).Length = 1 Then
            msegf = "0" & Convert.ToString(mseg)
        Else
            msegf = Convert.ToString(mseg)
        End If

        fecha = aniof & mesf & diaf & horaf & minf & segf & msegf
        Return fecha
    End Function

    Public Function getAnioFormat(ByVal anio As String) As String
        Dim aniof As String = String.Empty
        If anio.Length > 0 Then
            If Convert.ToString(anio).Length = 1 Then
                aniof = "000" & Convert.ToString(anio)
            ElseIf Convert.ToString(anio).Length = 1 Then
                aniof = "00" & Convert.ToString(anio)
            ElseIf Convert.ToString(anio).Length = 1 Then
                aniof = "0" & Convert.ToString(anio)
            Else
                aniof = Convert.ToString(anio)
            End If
        End If
        Return anio
    End Function

    Public Function getMesFormat(ByVal mes As String) As String
        Dim mesf As String = String.Empty
        If mes.Length > 0 Then
            If Convert.ToString(mes).Length = 1 Then
                mesf = "0" & Convert.ToString(mes)
            Else
                mesf = Convert.ToString(mes)
            End If
        End If
        Return mesf
    End Function

    Public Function getDiaFormat(ByVal dia As String) As String
        Dim diaf As String = String.Empty
        If dia.Length > 0 Then
            If Convert.ToString(dia).Length = 1 Then
                diaf = "0" & Convert.ToString(dia)
            Else
                diaf = Convert.ToString(dia)
            End If
        End If
        Return diaf
    End Function

    Public Function getHoraFormat(ByVal hr As String) As String
        Dim horaf As String = String.Empty
        If hr.Length > 0 Then
            If Convert.ToString(hr).Length = 1 Then
                horaf = "0" & Convert.ToString(hr)
            Else
                horaf = Convert.ToString(hr)
            End If
        End If
        Return horaf
    End Function

    Public Function getMinutoFormat(ByVal min As String) As String
        Dim minf As String = String.Empty
        If min.Length > 0 Then
            If Convert.ToString(min).Length = 1 Then
                minf = "0" & Convert.ToString(min)
            Else
                minf = Convert.ToString(min)
            End If
        End If
        Return minf
    End Function

    Public Function getSegundoFormat(ByVal seg As String) As String
        Dim segf As String = String.Empty
        If seg.Length > 0 Then
            If seg.Length = 1 Then
                segf = "0" & Convert.ToString(seg)
            Else
                segf = Convert.ToString(seg)
            End If
        End If
        Return segf
    End Function

    Public Function getMilisegundoFormat(ByVal mseg As String) As String
        Dim msegf As String = String.Empty
        If mseg.Length > 0 Then

            If Convert.ToString(mseg).Length = 1 Then
                msegf = "00" & Convert.ToString(mseg)
            ElseIf Convert.ToString(mseg).Length = 1 Then
                msegf = "0" & Convert.ToString(mseg)
            Else
                msegf = Convert.ToString(mseg)
            End If
        End If
        Return msegf
    End Function


    Public Function getSucrusalFormat(ByVal suc As String) As String
        Dim sucrusal As String = String.Empty

        If suc.Length = 1 Then
            sucrusal = "000" & Convert.ToString(suc)
        ElseIf suc.Length = 2 Then
            sucrusal = "00" & Convert.ToString(suc)
        ElseIf suc.Length = 3 Then
            sucrusal = "0" & Convert.ToString(suc)
        Else
            sucrusal = Convert.ToString(suc)
        End If

        Return sucrusal
    End Function

    Public Function getTipoDocumentoSectorFormat(ByVal tdoc As String) As String
        Dim tdocumentoSector As String = String.Empty

        If tdoc.Length = 1 Then
            tdocumentoSector = "0" & tdoc
        Else
            tdocumentoSector = tdoc
        End If

        Return tdocumentoSector
    End Function

    Public Function getNroFacturaFormat(ByVal nroF As String) As String
        Dim nroFactura As String = String.Empty

        If nroF.Length = 1 Then
            nroFactura = "0000000" & nroF
        ElseIf nroF.Length = 2 Then
            nroFactura = "000000" & nroF
        ElseIf nroF.Length = 3 Then
            nroFactura = "00000" & nroF
        ElseIf nroF.Length = 4 Then
            nroFactura = "0000" & nroF
        ElseIf nroF.Length = 5 Then
            nroFactura = "000" & nroF
        ElseIf nroF.Length = 6 Then
            nroFactura = "00" & nroF
        ElseIf nroF.Length = 7 Then
            nroFactura = "0" & nroF
        Else
            nroFactura = nroF
        End If

        Return nroFactura
    End Function

    Public Function getPuntoVentaFormat(ByVal pVta As String) As String
        Dim puntoVenta As String = String.Empty

        If pVta.Length = 1 Then
            puntoVenta = "000" & pVta
        ElseIf pVta.Length = 2 Then
            puntoVenta = "00" & pVta
        ElseIf pVta.Length = 3 Then
            puntoVenta = "0" & pVta
        Else
            puntoVenta = pVta
        End If

        Return puntoVenta
    End Function


    Public Function convertir_decimal_hexadecimal(ByVal valor As BigInteger) As String
        Dim i As BigInteger
        Dim sal As String
        Dim vaux As BigInteger = 16
        If valor < 16 Then
            Return Trim(dar_simbolo(valor))
        Else
            i = valor Mod 16

            Dim aux222 As BigInteger = valor / vaux

            Dim divRem1 As BigInteger = BigInteger.Zero

            divRem1 = BigInteger.Divide(valor, vaux)
            ' BigInteger.DivRem(valor, vaux, divRem1)

            ' sal = Trim(convertir_decimal_hexadecimal(valor \ vaux)) + Trim(dar_simbolo(i))
            sal = Trim(convertir_decimal_hexadecimal(divRem1.ToString)) + Trim(dar_simbolo(i))
            Return Trim(sal)
        End If
    End Function

    Private Function dar_simbolo(ByVal valor As BigInteger) As Char
        Dim a As Char
        Select Case valor
            Case 0
                Return "0"
            Case 1
                Return "1"
            Case 2
                Return "2"
            Case 3
                Return "3"
            Case 4
                Return "4"
            Case 5
                Return "5"
            Case 6
                Return "6"
            Case 7
                Return "7"
            Case 8
                Return "8"
            Case 9
                Return "9"
            Case 10
                Return "A"
            Case 11
                Return "B"
            Case 12
                Return "C"
            Case 13
                Return "D"
            Case 14
                Return "E"
            Case 15
                Return "F"
            Case Else
                Return ""
        End Select
    End Function



    Public Function getHexadecimal(ByVal numero As BigInteger) As String

        'Dim auxNro As BigInteger = New BigInteger(numero)

        If numero.ToString() <> getValor(numero) Then
            Return getValor(numero)
        End If

        Dim digito As String = getValor(numero Mod 16)

        If numero >= 16 Then
            Dim resto As BigInteger = numero / 16
            Dim restoString As String = getHexadecimal(resto)
            'MessageBox.Show("El valor es.: " & restoString)
            Return restoString & digito
        End If

        Return numero.ToString()
    End Function

    Private Function getValor(ByVal numero As BigInteger) As String
        Select Case numero
            Case 10
                Return "A"
            Case 11
                Return "B"
            Case 12
                Return "C"
            Case 13
                Return "D"
            Case 14
                Return "E"
            Case 15
                Return "F"
        End Select

        Return numero.ToString()
    End Function


    Public Function getAnioFormatDoc(ByVal anio As String) As String
        Dim segf As String = String.Empty
        If anio.Length > 0 Then
            segf = anio.Substring(2, 2)
            'For i = 0 To anio.Length Step 1
            '    If i = 2 Then
            '        segf = segf
            '    End If
            'Next
        End If
        Return segf
    End Function


End Class

Public Class catalgofacturacion
    Public Shared Property ambiente As String = "AMBIE"
    Public Shared Property tEmision As String = "TEMIS"
    Public Shared Property modalidad As String = "MODAL"
    Public Shared Property dFiscal As String = "DFISC"
    Public Shared Property dSector As String = "DSECT"
    Public Shared Property mAnulacion As String = "MANUL"
    Public Shared Property mSoap As String = "MSOAP"
    Public Shared Property eSignificativo As String = "ESIGN"
    Public Shared Property dIdentidad As String = "DIDEN"
    Public Shared Property mPago As String = "MPAGO"
    Public Shared Property monedas As String = "MONED"
    Public Shared Property paises As String = "TPAIS"
    Public Shared Property uMedida As String = "UMEDI"


    Public Shared Property tmensaje As String = "Información"
End Class

