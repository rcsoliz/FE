Public Class clsUtilitario : Inherits BaseDatos

#Region "[atributosGlobales]"

#End Region

#Region "[contrutor]"

    Protected Sub New(ByVal usuar As String, ByVal clav As String)
        MyBase.New()
        Call abrir_coneccion(usuar, clav)
    End Sub

    Protected Sub New(ByVal dtConexio As DataTable)
        MyBase.New()
        Call abrir_coneccion(dtConexio)
    End Sub

#End Region

#Region "[metodos]"

    Public Function getCatalogo(ByVal tipo As String, ByVal codigo As Integer) As String
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Dim varModalidad As String = String.Empty
            Try
                consulta = "select tipo, codigo, trim(nombre) nombre from catalogofe where tipo='" & tipo & "' AND codigo =" & codigo & ""
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows(0).Item("codigo")) Then
                        varModalidad = dt.Rows(0).Item("codigo")
                    End If
                End If
            Catch ex As Exception
                set_error("Fallo en clsUtilitario:: getCatalogo", ex.Message)
            End Try
            Return varModalidad
        End Using
    End Function

    Public Function getModalidad(ByVal tipo As String, ByVal codigo As Integer) As String
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Dim varModalidad As String = String.Empty
            Try
                'Case MODALIDADES: 1300  1301 ------ 1399
                'consulta = "select valor1 from parfactura where codparame=" & codparame

                consulta = "select tipo, codigo, trim(nombre) nombre from catalogofe where tipo='" & tipo & "' AND codigo =" & codigo & ""
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows(0).Item("codigo")) Then
                        varModalidad = dt.Rows(0).Item("codigo")
                    End If
                End If
            Catch ex As Exception
                set_error("Fallo en clsUtilitario:: getModalidad", ex.Message)
            End Try
            Return varModalidad
        End Using
    End Function

    Public Function getTipoEmision(ByVal codParame As Integer) As String
        Using dt As New DataTable
            Dim varTipoEmision As String = String.Empty
            Dim consulta As String = String.Empty
            Try
                'Case TIPOS DE EMISION: 1100  1101 ------ 1199
                consulta = "select valor1 from parfactura where codparame=" & codParame
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows(0).Item("valor1")) Then
                        varTipoEmision = dt.Rows(0).Item("valor1")
                    End If
                End If
            Catch ex As Exception
                set_error("Fallo en clsUtilitario:: getTipoEmision", ex.Message)
            End Try
            Return varTipoEmision
        End Using
    End Function

    Public Function getCodigoDocumentoFiscal(ByVal codParame As Integer) As String
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Dim varCodigoDocumentoFiscal As String = String.Empty
            Try
                'Case TIPOS DE EMISION: 1400  1401 ------ 1499
                consulta = "select valor1 from parfactura where codparame=" & codParame
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows(0).Item("valor1")) Then
                        varCodigoDocumentoFiscal = dt.Rows(0).Item("valor1")
                    End If
                End If
            Catch ex As Exception
                set_error("Fallo en clsUtilitario:: getCodigoDocumentoFiscal", ex.Message)
            End Try
            Return varCodigoDocumentoFiscal
        End Using
    End Function

    Public Function getTipoDocumentoSector(ByVal codParame As Integer) As String
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Dim varTipoDocumentoSector As String = String.Empty
            Try
                'Case TIPOS DE EMISION: 1500  1501 ------ 1599
                consulta = "select valor1 from parfactura where codparame=" & codParame
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows(0).Item("valor1")) Then
                        varTipoDocumentoSector = dt.Rows(0).Item("valor1")
                    End If
                End If
            Catch ex As Exception
                set_error("Fallo en clsUtilitario:: getTipoDocumentoSector", ex.Message)
            End Try
            Return varTipoDocumentoSector
        End Using
    End Function

    Public Function getPuntoDeVentaPOS(ByVal codParame As Integer) As String
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Dim varPuntoDeVenta As String = String.Empty
            Try
                'Case TIPOS DE EMISION: 1500  1501 ------ 1599
                'consulta = "select valor1 from parfactura where codparame=" & codParame
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows(0).Item("valor1")) Then
                        varPuntoDeVenta = dt.Rows(0).Item("valor1")
                    End If
                End If
            Catch ex As Exception
                set_error("Fallo en clsUtilitario:: getTipoDocumentoSector", ex.Message)
            End Try
            Return varPuntoDeVenta
        End Using
    End Function

    Protected Function getNegocio() As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Dim varPuntoDeVenta As String = String.Empty
            Try
                consulta = Libreria.LibGlobal.getNegocio()
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Fallo en clsUtilitario:: getNegocio", ex.Message)
            End Try
            Return dt
        End Using
    End Function

    Protected Function getNegocio(ByVal unidad As Integer) As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Dim varPuntoDeVenta As String = String.Empty
            Try
                consulta = Libreria.LibGlobal.getNegocio()
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Fallo en clsUtilitario:: getNegocio", ex.Message)
            End Try
            Return dt
        End Using
    End Function

    Protected Function getTipoCliente() As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Dim varPuntoDeVenta As String = String.Empty
            Try
                consulta = Libreria.LibGlobal.getTipoCliente()
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Fallo en clsUtilitario:: getTipoCliente", ex.Message)
            End Try
            Return dt
        End Using
    End Function

    Protected Function getParametro() As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = "select trim(pacodigo) pacodigo, trim(padescri) padescri, pavalor1, pavalor2, " &
                "1 cal1, '' cal2, '' cal3  from afparame order by 1"

                ' consulta = "select trim(pacodigo) pacodigo, trim(padescri) padescri, pavalor1, pavalor2 " &
                '" from afparame order by 1"
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Fallo en clsUtilitario:: getNegocio", ex.Message)
            End Try
            Return dt
        End Using
    End Function



    Protected Function getTipoDocumento() As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = Libreria.LibUtilitario.getTipoDocumento()
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Fallo en clsUtilitario:: getTipoDocumento" & vbNewLine & consulta, ex.Message)
            End Try
            Return dt
        End Using
    End Function

    Protected Function getActividad(ByVal codigo As String) As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = Libreria.LibUtilitario.getActividad(codigo)
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Fallo en clsUtilitario:: getActividad" & vbNewLine & consulta, ex.Message)
            End Try
            Return dt
        End Using
    End Function


#End Region

End Class
