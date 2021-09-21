Imports Entidades
Imports Libreria
Public Class clsPreVentas : Inherits BaseDatos

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

    Public Function altaPreVenta(ByVal itemCab As Entidades.tb_CabVentas, ByVal lista As List(Of Entidades.tb_CueVentas)) As Boolean
        Dim consulta As String = String.Empty
        Dim esCorrecto As Boolean = False
        Try
            'alta cabecera
            consulta = LibCierreVentas.altaCabPreFactura(itemCab)
            comando.CommandType = CommandType.Text
            comando.CommandText = consulta
            esCorrecto = comando.ExecuteNonQuery()
            'alta cuerpo
            For Each item As tb_CueVentas In lista
                consulta = LibCierreVentas.altaCuepPreFactura(item)
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                esCorrecto = comando.ExecuteNonQuery()
            Next
        Catch ex As Exception
            set_error("Fallo en clsPreVentas:: altaPreVenta " & vbNewLine & consulta, ex.Message)
        End Try
        Return esCorrecto
    End Function

    Protected Function anularPreVenta(ByVal item As Entidades.tb_CabVentas) As Boolean
        Dim consulta As String = String.Empty
        Dim esCorrecto As Boolean = False
        Try
            consulta = LibPreVentas.anularVenta(item)
            comando.CommandType = CommandType.Text
            comando.CommandText = consulta
            esCorrecto = comando.ExecuteNonQuery()
        Catch ex As Exception
            set_error("Fallo en clsPreVentas:: anularPreVenta " & vbNewLine & consulta, ex.Message)
        End Try
        Return esCorrecto
    End Function

    Protected Function bajaPreVenta(ByVal item As Entidades.tb_CabVentas) As Boolean
        Dim consulta As String = String.Empty
        Dim esCorrecto As Boolean = False
        Try
            consulta = LibPreVentas.bajaCuerpo(item)
            comando.CommandType = CommandType.Text
            comando.CommandText = consulta
            esCorrecto = comando.ExecuteNonQuery()

            consulta = LibPreVentas.bajaCabecera(item)
            comando.CommandType = CommandType.Text
            comando.CommandText = consulta
            esCorrecto = comando.ExecuteNonQuery()
        Catch ex As Exception
            set_error("Fallo en clsPreVentas:: bajaPreVenta " & vbNewLine & consulta, ex.Message)
        End Try
        Return esCorrecto
    End Function

    Protected Function getCabeceraVenta(ByVal item As Entidades.tb_CabVentas) As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = Libreria.LibPreVentas.getCabecera(item)
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Fallo en clsPreVentas:: getCabeceraVenta " & vbNewLine & consulta, ex.Message)
            End Try
            Return dt
        End Using
    End Function

    Protected Function getCuerpoVenta(ByVal item As Entidades.tb_CabVentas) As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = Libreria.LibPreVentas.getCuerpo(item)
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Fallo en clsPreVentas:: getCuerpoVenta " & vbNewLine & consulta, ex.Message)
            End Try
            Return dt
        End Using
    End Function

    Protected Function getParametro(ByVal codParametro As String) As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = Libreria.LibGlobal.getParametro(codParametro)
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Fallo en clsPreVentas:: getParametro" & vbNewLine & consulta, ex.Message)
            End Try
            Return dt
        End Using
    End Function

    Protected Function getTipoDocumento() As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = Libreria.LibPreVentas.getTipoDocumento()
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Fallo en clsPreVentas:: getTipoDocumento" & vbNewLine & consulta, ex.Message)
            End Try
            Return dt
        End Using
    End Function

    Protected Function getCorrelativo(ByVal codtMovimiento As String) As Decimal
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Dim varCorrelativo As Decimal = Decimal.One
            Try
                consulta = LibPreVentas.getCorrelativo(codtMovimiento)
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows(0).Item("nummov")) Then
                        varCorrelativo = dt.Rows(0).Item("nummov")
                    End If
                End If
            Catch ex As Exception
                set_error("Fallo en clsPreVentas:: getCorrelativo" & vbNewLine & consulta, ex.Message)
            End Try
            Return varCorrelativo
        End Using
    End Function

    Protected Function getEsConFactura(ByVal codTipoDocumento As String) As Boolean
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Dim esConFactura As Boolean = False
            Try 'pavalor1,pavalor2   
                consulta = Libreria.LibPreVentas.getEsConFactura(codTipoDocumento)
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt) 'Optiene el pavalor1 Es la Actividad (1,2,3, ..etc), IF pavalor2= 0 then Not Factura ELSE Con Factura 
                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows(0).Item("pavalor1")) AndAlso Not IsDBNull(dt.Rows(0).Item("pavalor1")) Then
                        If dt.Rows(0).Item("pavalor2") = 1 Then
                            esConFactura = True
                        End If
                    End If
                End If
            Catch ex As Exception
                set_error("Fallo en clsPreVentas:: getEsConFactura" & vbNewLine & consulta, ex.Message)
            End Try
            Return esConFactura
        End Using
    End Function


    Protected Function getVentaDespachoCII(ByVal codTipoDocumento As String, ByVal nroNota As String) As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = Libreria.LibPreVentas.getVentaDespachoCII(codTipoDocumento, nroNota)
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Fallo en clsPreVentas:: getVentaDespachoCII" & vbNewLine & consulta, ex.Message)
            End Try
            Return dt
        End Using
    End Function

    Protected Function getCuerpoDespachoCII(ByVal codTipoDocumento As String, ByVal nroNota As String) As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = Libreria.LibPreVentas.getCuerpoDespachoCII(codTipoDocumento, nroNota)
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Fallo en clsPreVentas:: getCuerpoDespachoCII" & vbNewLine & consulta, ex.Message)
            End Try
            Return dt
        End Using
    End Function

#End Region

End Class
